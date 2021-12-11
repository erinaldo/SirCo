Public Class frmFiltrosTraspasos
    'miguel pérez 09/Otubre/2012 01:00 p.m.
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
            If Chk_Fechas.Checked = False And Txt_Sucursal.Text = "" And Txt_Trasp1.Text = "" And Txt_Trasp2.Text = "" And Txt_NumSerie.Text = "" And Chk_Cancelados.Checked = False Then
                Sw_Filtro = False
            Else
                Sw_Filtro = True
            End If
            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try

            Txt_NumSerie.Text = ""
            If GLB_CveSucursal = "" Then
                Txt_DescripSucursal.Text = ""
                Txt_Sucursal.Text = ""
            End If
            Txt_Trasp1.Text = ""
            Txt_Trasp2.Text = ""
            Chk_Cancelados.Checked = False
            Chk_Fechas.Checked = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

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
        'If Val(Txt_Trasp1.Text) <> 0 Then
        '    Call TraerEmpleado()
        'End If
        If Txt_Sucursal.Text <> "" Then
            Call TraerSucursal()
            Txt_Sucursal.Enabled = False
            Txt_DescripSucursal.Enabled = False
        End If
        'If GLB_Sucursal.Trim <> "" Then
        '    Txt_Sucursal.Text = GLB_Sucursal
        '    Txt_Sucursal.Enabled = False
        'Else
        '    Txt_Sucursal.Text = ""
        '    Txt_Sucursal.Enabled = True
        'End If
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
        DTPicker2.Value = Now
        DTPicker3.Value = Now
        If GLB_CveSucursal = "" Then
            Txt_Sucursal.Text = ""
            Txt_DescripSucursal.Text = ""
        End If
        Chk_Fechas.Checked = False
        DTPicker2.Enabled = False
        DTPicker3.Enabled = False
    End Sub

    Private Sub Chk_FechaOrden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Fechas.CheckedChanged
        If Chk_Fechas.Checked = True Then
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

    Private Sub Txt_IdEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Trasp1.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Trasp1.LostFocus
    '    If Txt_Trasp1.Text.Length = 0 Then Exit Sub
    '    Call TraerEmpleado()
    'End Sub

    'Private Sub TraerEmpleado()
    '    If Txt_Trasp1.Text.Length = 0 Then Txt_Trasp2.Text = "" : Exit Sub


    '    Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
    '        Try
    '            If Val(Txt_Trasp1.Text) = 0 Then
    '                CargarFormaConsultaEmpleado()
    '            Else
    '                objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_Trasp1.Text), "", "", "", "")
    '                If objDataSet.Tables(0).Rows.Count = 1 Then
    '                    Txt_Trasp2.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
    '                Else
    '                    Call CargarFormaConsultaEmpleado()
    '                End If

    '            End If
    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub
    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        Txt_Trasp2.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_Trasp1.Text = myForm.Campo
        Txt_Trasp2.Text = myForm.Campo1
        If Txt_Trasp1.Text.Length = 0 Then
            Txt_Trasp1.Focus()
        End If
    End Sub

    Private Sub Txt_IdDepartamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_IdPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdPuesto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Txt_IdPuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Sucursal_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Trasp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Trasp1.LostFocus
        If Txt_Trasp1.Text.Trim <> "" Then
            Txt_Trasp1.Text = pub_RellenarIzquierda(Txt_Trasp1.Text, 6)
            Txt_Trasp2.Text = Txt_Trasp1.Text
        End If
    End Sub

    Private Sub Txt_Trasp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Trasp2.LostFocus
        If Txt_Trasp2.Text.Trim <> "" Then
            Txt_Trasp2.Text = pub_RellenarIzquierda(Txt_Trasp2.Text, 6)
        End If
    End Sub

    Private Sub Txt_NumSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NumSerie.LostFocus
        If Txt_NumSerie.Text.Trim <> "" Then
            Txt_NumSerie.Text = pub_RellenarIzquierda(Txt_NumSerie.Text, 13)
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

    Private Sub Txt_SucursalOri_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucursalOri.LostFocus
        Call TraerSucursalOri()
    End Sub

    Private Sub TraerSucursalOri()

        If Txt_SucursalOri.Text.Length = 0 Then Txt_DescripSucursalOri.Text = "" : Exit Sub

        Try
            'Get the specific project selected in the ListView control
            If Txt_SucursalOri.Text.Trim.Length < 2 Then
                Txt_SucursalOri.Text = pub_RellenarIzquierda(Txt_SucursalOri.Text.Trim, 2)
            End If

            Call TxtLostfocusPersis(Txt_SucursalOri, Txt_DescripSucursalOri, "S")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_ClaveDepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NumSerie.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Txt_ClavePuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

            myForm.Tipo = TipoC
            myForm.ShowDialog()
            If Opcion = 1 Then
                Txt_NumSerie.Text = myForm.Campo1
                If Txt_NumSerie.Text.Length = 0 Then
                    Txt_NumSerie.Focus()
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub
    
    Private Sub Txt_ClaveDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NumSerie.TextChanged

    End Sub

    Private Sub Txt_Sucursal_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Trasp1.TextChanged

    End Sub

    Private Sub Txt_Sucursal_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub
End Class