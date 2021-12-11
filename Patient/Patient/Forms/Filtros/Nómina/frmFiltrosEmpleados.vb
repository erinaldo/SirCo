Public Class frmFiltrosEmpleados
    'mreyes 15/Junio/2012 05:29 p.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Dim Sw_Load As Boolean = False
    Private objDataSet As Data.DataSet



    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            Sw_Filtro = True
            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try

            Txt_ClaveDepto.Text = ""
            Txt_ClavePuesto.Text = ""
            Txt_DescripPuesto.Text = ""
            Txt_DescripDepto.Text = ""
            Txt_DescripSucursal.Text = ""
            Txt_Sucursal.Text = ""
            Txt_IdPuesto.Text = ""
            Txt_IdDepartamento.Text = ""
            Txt_IdEmpleado.Text = ""
            Txt_NombreEmpleado.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Marca_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:25 a.m.

        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub frmFiltrosFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call GenerarToolTip()
        If Val(Txt_IdEmpleado.Text) <> 0 Then
            Call TraerEmpleado()
        End If
        If Val(Txt_IdDepto.Text) <> 0 Then
            Sw_Load = True
            Call TraerDepto()
        End If
        If Val(Txt_IdPuesto.Text) <> 0 Then
            Sw_Load = True
            Call TraerPuesto()
        End If
        If Txt_Sucursal.Text <> "" Then
            Call TraerSucursal()
        End If
    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try


                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Sw_Nomina = True
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringPerSis)
            If Txt_Sucursal.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                Sql = ""
                Sql = Sql & "SELECT descrip as campo "
                Sql = Sql & " FROM sucursal "
                Sql = Sql & " WHERE sucursal = '" & Txt_Sucursal.Text.Trim & "';"

                Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

 
    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Call LimpiarDatos()
        Cbo_Estatus.Text = ""
        DTPicker2.Value = Now
        DTPicker3.Value = Now
        DTPicker6.Value = Now
        DTPicker7.Value = Now
        DTPicker8.Value = Now
        DTPicker9.Value = Now

        Txt_Sucursal.Text = ""
        Txt_DescripSucursal.Text = ""
        Chk_FechaIngreso.Checked = False
        Chk_FechaBaja.Checked = False
        Chk_Nacim.Checked = False
        DTPicker2.Enabled = False
        DTPicker3.Enabled = False
        DTPicker6.Enabled = False
        DTPicker7.Enabled = False

        DTPicker8.Enabled = False
        DTPicker9.Enabled = False


    End Sub

    Private Sub Chk_FechaOrden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_FechaIngreso.CheckedChanged
        If Chk_FechaIngreso.Checked = True Then
            DTPicker2.Enabled = True
            DTPicker3.Enabled = True
        Else
            DTPicker2.Enabled = False
            DTPicker3.Enabled = False
        End If
    End Sub

    Private Sub Chk_FechaEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
 
    End Sub

    Private Sub DTPicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPicker3.ValueChanged

    End Sub

    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Sucursal_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_Sucursal.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If Txt_Sucursal.Text.Trim.Length < 2 Then
                    Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                End If

                Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cbo_Estatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Estatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_TipoArt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Categoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Chk_FechaRec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_FechaBaja.CheckedChanged
        If Chk_FechaBaja.Checked = True Then
            DTPicker6.Enabled = True
            DTPicker7.Enabled = True
        Else
            DTPicker6.Enabled = False
            DTPicker7.Enabled = False
        End If
    End Sub

    Private Sub Chk_Nacim_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Nacim.CheckedChanged
        If Chk_Nacim.Checked = True Then
            DTPicker8.Enabled = True
            DTPicker9.Enabled = True
        Else
            DTPicker8.Enabled = False
            DTPicker9.Enabled = False
        End If
    End Sub

    Private Sub Txt_IdEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdEmpleado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        If Txt_IdEmpleado.Text.Length = 0 Then Exit Sub
        Call TraerEmpleado()
    End Sub

    Private Sub TraerEmpleado()
        If Txt_IdEmpleado.Text.Length = 0 Then Txt_NombreEmpleado.Text = "" : Exit Sub


        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Val(Txt_IdEmpleado.Text) = 0 Then
                    CargarFormaConsultaEmpleado()
                Else
                    objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_IdEmpleado.Text), "", "", "", "", 0)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    Else
                        Call CargarFormaConsultaEmpleado()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        Txt_NombreEmpleado.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_IdEmpleado.Text = myForm.Campo
        Txt_NombreEmpleado.Text = myForm.Campo1
        If Txt_IdEmpleado.Text.Length = 0 Then
            Txt_IdEmpleado.Focus()
        End If
    End Sub

    Private Sub Txt_IdDepartamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdDepartamento.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdDepartamento.TextChanged

    End Sub

    Private Sub Txt_IdPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdPuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdPuesto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdPuesto.LostFocus


    End Sub

    Private Sub Txt_IdPuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdPuesto.TextChanged

    End Sub

    Private Sub Txt_Sucursal_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Sucursal_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Call TraerSucursal()
    End Sub

    Private Sub TraerSucursal()

        If Txt_Sucursal.Text.Length = 0 Then Txt_DescripSucursal.Text = "" : Exit Sub

        Try
            'Get the specific project selected in the ListView control
            If Txt_Sucursal.Text.Trim.Length < 2 Then
                Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
            End If

            Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_ClaveDepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClaveDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

 
    Private Sub Txt_ClavePuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClavePuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CargarFormaConsulta(ByVal TipoC As String, ByVal Opcion As Integer)
        'mreyes 26/Junio/2012 09:26 a.m.
        Try
            Dim myForm As New frmConsulta
            If Opcion = 1 Then 'depto
                Txt_IdDepto.Text = ""
            End If
            If Opcion = 2 Then
                Txt_IdPuesto.Text = ""
                myForm.idDepto = Val(Txt_IdDepto.Text)
            End If


            myForm.Tipo = TipoC
            myForm.ShowDialog()
            If Opcion = 1 Then
                Txt_IdDepto.Text = Val(myForm.Campo)
                Txt_ClaveDepto.Text = myForm.Campo1
                Txt_DescripDepto.Text = myForm.Campo2
                If Txt_ClaveDepto.Text.Length = 0 Then
                    Txt_ClaveDepto.Focus()
                End If
            End If

            If Opcion = 2 Then
                Txt_IdPuesto.Text = Val(myForm.Campo)
                Txt_ClavePuesto.Text = myForm.Campo1
                Txt_DescripPuesto.Text = myForm.Campo2
                If Txt_ClavePuesto.Text.Length = 0 Then
                    Txt_ClavePuesto.Focus()
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub
    Private Sub TraerDepto()

        'mreyes 26/Junio/2012 09:27 a.m.
        Try
            If Txt_IdDepto.Text.Length = 0 And Sw_Load = True Then Exit Sub

            Using objMySqlGral As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoDepto(Val(Txt_IdDepto.Text), Txt_ClaveDepto.Text, "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto")
                        Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta("DE", 1)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub
    Private Sub TraerPuesto()
        'mreyes 13/Junio/2012 07:03 p.m.
        Try

            If Txt_ClavePuesto.Text.Length = 0 And Sw_Load = False Then Txt_DescripPuesto.Text = "" : Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPuesto(Val(Txt_IdPuesto.Text), Val(Txt_IdDepto.Text), Txt_ClavePuesto.Text, "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdPuesto.Text = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                        Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString
                        Txt_ClavePuesto.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto").ToString
                    Else
                        Call CargarFormaConsulta("PU", 2)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClavePuesto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClavePuesto.LostFocus
        If Txt_ClavePuesto.Text.Length = 0 Then Exit Sub
        Call TraerPuesto()
    End Sub

    Private Sub Txt_ClavePuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClavePuesto.TextChanged

    End Sub

    Private Sub Txt_ClaveDepto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.LostFocus
        If Txt_ClaveDepto.Text.Length = 0 Then Exit Sub
        Call TraerDepto()
    End Sub

    Private Sub Txt_ClaveDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.TextChanged

    End Sub

    Private Sub Txt_Sucursal_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub
End Class