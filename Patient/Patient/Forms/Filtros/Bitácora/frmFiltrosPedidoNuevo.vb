Public Class frmFiltrosPedidoNuevo
    'mreyes 16/Febrero/2012 11:52 p.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private objDataSet As Data.DataSet

    'Catálogo de Artículos
    'mreyes 07/Febrero/2012 05:37 p.m.
    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.GotFocus
        Txt_Marca.SelectAll()
    End Sub
    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
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
            Txt_Marca.Text = ""
            Txt_Estilon.Text = ""
            Txt_Estilof.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Marca_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LocationChanged

    End Sub
    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If Txt_Marca.Text.Trim.Length < 3 Then
                    Txt_Marca.Text = pub_RellenarIzquierda(Txt_Marca.Text.Trim, 3)
                End If
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.GotFocus
        Txt_Estilon.SelectAll()
    End Sub
    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilon.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Estilof_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.GotFocus
        Txt_Estilof.SelectAll()
    End Sub
    Private Sub Txt_Estilof_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Estilof.KeyDown

    End Sub
    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged

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
    Private Sub frmFiltrosPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        'Call CargaDescripcion(sender, e)
    End Sub
    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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
    Private Sub Txt_OrdeComp1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_OrdeComp1.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_OrdeComp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_OrdeComp1.LostFocus
        If Txt_OrdeComp1.Text.Length = 0 Then Exit Sub
        Txt_OrdeComp1.Text = pub_RellenarIzquierda(Txt_OrdeComp1.Text, 6)
        Txt_OrdeComp2.Text = Txt_OrdeComp1.Text
    End Sub
    Private Sub Txt_OrdeComp1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_OrdeComp1.TextChanged

    End Sub
    Private Sub Txt_OrdeComp2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_OrdeComp2.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_OrdeComp2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_OrdeComp2.LostFocus
        If Txt_OrdeComp2.Text.Length = 0 Then Exit Sub
        Txt_OrdeComp2.Text = pub_RellenarIzquierda(Txt_OrdeComp2.Text, 6)
    End Sub
    Private Sub Txt_OrdeComp2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_OrdeComp2.TextChanged

    End Sub
    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Chk_TipoPedido.Checked = False
        Opt_PedidoCatalogo.Checked = False
        Opt_PedidoUnico.Checked = False

        Me.Txt_DescripMarca.Text = ""
        Me.Txt_Estilof.Text = ""
        Me.Txt_Estilon.Text = ""
        Me.Txt_Marca.Text = ""

        Me.Txt_IdDivision.Text = 0
        Me.Txt_Division.Text = ""
        Me.Txt_DescripDivision.Text = ""
        Me.Txt_IdDepto.Text = 0
        Me.Txt_Depto.Text = ""
        Me.Txt_DescripDepto.Text = ""
        Me.Txt_IdFamilia.Text = 0
        Me.Txt_Familia.Text = ""
        Me.Txt_DescripFamilia.Text = ""
        Me.Txt_IdLinea.Text = 0
        Me.Txt_Linea.Text = ""
        Me.Txt_DescripLinea.Text = ""
        Me.Txt_IdL1.Text = 0
        Me.Txt_L1.Text = ""
        Me.Txt_DescripL1.Text = ""
        Me.Txt_IdL2.Text = 0
        Me.Txt_L2.Text = ""
        Me.Txt_DescripL2.Text = ""
        Me.Txt_IdL3.Text = 0
        Me.Txt_L3.Text = ""
        Me.Txt_DescripL3.Text = ""
        Me.Txt_IdL4.Text = 0
        Me.Txt_L4.Text = ""
        Me.Txt_DescripL4.Text = ""
        Me.Txt_IdL5.Text = 0
        Me.Txt_L5.Text = ""
        Me.Txt_DescripL5.Text = ""
        Me.Txt_IdL6.Text = 0
        Me.Txt_L6.Text = ""
        Me.Txt_DescripL6.Text = ""
        Me.Txt_Proveedor.Text = ""
        Me.Txt_Raz_Soc.Text = ""


        Me.Txt_OrdeComp1.Text = ""
        Me.Txt_OrdeComp2.Text = ""
        Cbo_Estatus.Text = ""
        DTPicker2.Value = Now
        DTPicker3.Value = Now
        DTPicker4.Value = Now
        DTPicker5.Value = Now
        Txt_Sucursal.Text = ""
        Txt_DescripSucursal.Text = ""
        Chk_FechaOrden.Checked = False
        Chk_FechaEntrega.Checked = False
        DTPicker2.Enabled = False
        DTPicker3.Enabled = False
        DTPicker4.Enabled = False
        DTPicker5.Enabled = False


    End Sub
    Private Sub Chk_FechaOrden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_FechaOrden.CheckedChanged
        If Chk_FechaOrden.Checked = True Then
            DTPicker2.Enabled = True
            DTPicker3.Enabled = True
        Else
            DTPicker2.Enabled = False
            DTPicker3.Enabled = False
        End If
    End Sub
    Private Sub Chk_FechaEntrega_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_FechaEntrega.CheckedChanged
        If Chk_FechaEntrega.Checked = True Then
            DTPicker4.Enabled = True
            DTPicker5.Enabled = True
        Else
            DTPicker4.Enabled = False
            DTPicker5.Enabled = False
        End If
    End Sub
    Private Sub DTPicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPicker3.ValueChanged

    End Sub
    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Sucursal_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
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
    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub
    Private Sub Cbo_Estatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Estilon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.LostFocus
        If Txt_Estilon.Text.Length > 0 Then
            Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
        End If
    End Sub
    Private Sub Txt_Division_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.GotFocus
        Txt_Division.SelectAll()
    End Sub
    Private Sub Txt_Division_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Division.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Division_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.LostFocus
        Try
            If Txt_Division.Text.Length = 0 Then Exit Sub
            If Txt_Division.Text.Trim.Length < 3 Then
                Txt_Division.Text = pub_RellenarIzquierda(Txt_Division.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("EDI", Txt_Division.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdDivision.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                Else
                    Call CargarFormaConsulta("EDI", 1)
                End If
            End Using

            'Call TxtLostfocus(Txt_Depto, Txt_DescripDepto, "ED")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Depto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Depto.GotFocus
        Txt_Depto.SelectAll()
    End Sub
    Private Sub Txt_Depto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Depto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Depto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Depto.LostFocus
        Try
            If Txt_Depto.Text.Length = 0 Then Exit Sub
            If Txt_Depto.Text.Trim.Length < 3 Then
                Txt_Depto.Text = pub_RellenarIzquierda(Txt_Depto.Text.Trim, 3)
            End If

            'If Txt_IdDepto.Text = "" Then
            '    Txt_IdDepto.Text = 0
            'End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)
                'objDataSet = objMySqlGral.usp_TraerDescripcion("ED", Txt_Depto.Text, "")

                If Txt_IdDivision.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstDepto(0, Val(Txt_IdDivision.Text), Txt_Depto.Text, 0, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstDepto(0, 0, Txt_Depto.Text, 0, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                Else
                    Call CargarFormaConsulta("ED", 2)
                End If
            End Using

            'Call TxtLostfocus(Txt_Depto, Txt_DescripDepto, "ED")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.GotFocus
        Txt_Familia.SelectAll()
    End Sub
    Private Sub Txt_Familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Familia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.LostFocus
        Try
            If Txt_Familia.Text.Length = 0 Then Exit Sub
            If Txt_Familia.Text.Trim.Length < 3 Then
                Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text.Trim, 3)
            End If

            'If Txt_IdDepto.Text = "" Then
            '    Txt_IdDepto.Text = 0
            'End If

            'If Txt_IdFamilia.Text = "" Then
            '    Txt_IdFamilia.Text = 0
            'End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)

                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstFamilia(0, Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_Familia.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstFamilia(0, 0, 0, Txt_Familia.Text, 4, "")
                End If



                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString
                Else
                    'If Txt_Depto.Text = "" AndAlso Txt_DescripDepto.Text = "" Then
                    '    MsgBox("Debe especificar un Departamento para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_Familia.Text = ""
                    '    Txt_Depto.Focus()
                    'Else
                    Call CargarFormaConsulta("EF", 3)
                    'End If
                End If
            End Using

            'If Txt_Familia.Text.Length = 0 Then Exit Sub
            'If Txt_Familia.Text.Trim.Length < 3 Then
            '    Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text.Trim, 3)
            'End If
            'Call TxtLostfocus(Txt_Familia, Txt_DescripFamilia, "EF")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Linea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.GotFocus
        Txt_Linea.SelectAll()
    End Sub
    Private Sub Txt_Linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Linea.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Linea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.LostFocus
        Try

            If Txt_Linea.Text.Length = 0 Then Exit Sub
            If Txt_Linea.Text.Trim.Length < 3 Then
                Txt_Linea.Text = pub_RellenarIzquierda(Txt_Linea.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)


                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" Then

                    objDataSet = objEstructura.usp_TraerEstLinea(0, Val(Txt_IdFamilia.Text), Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), _
                                                                 Txt_Linea.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstLinea(0, 0, 0, _
                                                            0, 0, 4, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idlinea").ToString
                Else
                    'If Txt_Familia.Text = "" AndAlso Txt_DescripFamilia.Text = "" Then
                    '    MsgBox("Debe especificar una Familia para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_Linea.Text = ""
                    '    Txt_Familia.Focus()
                    'Else
                    Call CargarFormaConsulta("EL", 4)
                End If
                'End If
            End Using

            'If Txt_Linea.Text.Length = 0 Then Exit Sub
            'If Txt_Linea.Text.Trim.Length < 3 Then
            '    Txt_Linea.Text = pub_RellenarIzquierda(Txt_Linea.Text.Trim, 3)
            'End If

            'Call TxtLostfocus(Txt_Linea, Txt_DescripLinea, "EL")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L1.GotFocus
        Txt_L1.SelectAll()
    End Sub
    Private Sub Txt_L1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L1.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_L1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L1.LostFocus
        Try
            If Txt_L1.Text.Length = 0 Then Exit Sub
            If Txt_L1.Text.Trim.Length < 3 Then
                Txt_L1.Text = pub_RellenarIzquierda(Txt_L1.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)


                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" AndAlso Txt_IdLinea.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstl1(0, Val(Txt_IdLinea.Text), Val(Txt_IdFamilia.Text), _
                                                               Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_L1.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstl1(0, 0, 0, _
                                                               0, 0, Txt_L1.Text, 4, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdL1.Text = objDataSet.Tables(0).Rows(0).Item("idl1").ToString
                Else
                    'If Txt_Linea.Text = "" AndAlso Txt_DescripLinea.Text = "" Then
                    '    MsgBox("Debe especificar una Linea para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_L1.Text = ""
                    '    Txt_Linea.Focus()
                    'Else
                    Call CargarFormaConsulta("L1", 5)
                    'End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L2.GotFocus
        Txt_L2.SelectAll()
    End Sub
    Private Sub Txt_L2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L2.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_L2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L2.LostFocus
        Try
            If Txt_L2.Text.Length = 0 Then Exit Sub
            If Txt_L2.Text.Trim.Length < 3 Then
                Txt_L2.Text = pub_RellenarIzquierda(Txt_L2.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)

                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" AndAlso Txt_IdLinea.Text <> "" _
                AndAlso Txt_L1.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstl2(0, Val(Txt_IdL1.Text), Val(Txt_IdLinea.Text), _
                                                                Val(Txt_IdFamilia.Text), Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_L2.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstl2(0, 0, 0, _
                                                                0, 0, 0, Txt_L2.Text, 4, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdL2.Text = objDataSet.Tables(0).Rows(0).Item("idl2").ToString
                Else
                    'If Txt_L1.Text = "" AndAlso Txt_DescripL1.Text = "" Then
                    '    MsgBox("Debe especificar una L1 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_L2.Text = ""
                    '    Txt_L1.Focus()
                    'Else
                    Call CargarFormaConsulta("L2", 6)
                    'End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L3.GotFocus
        Txt_L3.SelectAll()
    End Sub
    Private Sub Txt_L3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L3.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_L3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L3.LostFocus
        Try
            If Txt_L3.Text.Length = 0 Then Exit Sub
            If Txt_L3.Text.Trim.Length < 3 Then
                Txt_L3.Text = pub_RellenarIzquierda(Txt_L3.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)

                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" AndAlso Txt_IdLinea.Text <> "" _
                AndAlso Txt_L1.Text <> "" AndAlso Txt_IdL2.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstl3(0, Val(Txt_IdL2.Text), Val(Txt_IdL1.Text), Val(Txt_IdLinea.Text), _
                                                                 Val(Txt_IdFamilia.Text), Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_L3.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstl3(0, 0, 0, 0, _
                                                                 0, 0, 0, Txt_L3.Text, 4, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdL3.Text = objDataSet.Tables(0).Rows(0).Item("idl3").ToString
                Else
                    'If Txt_L2.Text = "" AndAlso Txt_DescripL2.Text = "" Then
                    '    MsgBox("Debe especificar una L2 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_L3.Text = ""
                    '    Txt_L2.Focus()
                    'Else
                    Call CargarFormaConsulta("L3", 7)
                    'End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L4.GotFocus
        Txt_L4.SelectAll()
    End Sub
    Private Sub Txt_L4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L4.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_L4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L4.LostFocus
        Try
            If Txt_L4.Text.Length = 0 Then Exit Sub
            If Txt_L4.Text.Trim.Length < 3 Then
                Txt_L4.Text = pub_RellenarIzquierda(Txt_L4.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)

                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" AndAlso Txt_IdLinea.Text <> "" _
                AndAlso Txt_L1.Text <> "" AndAlso Txt_IdL2.Text <> "" AndAlso Txt_IdL3.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstl4(0, Val(Txt_IdL3.Text), Val(Txt_IdL2.Text), Val(Txt_IdL1.Text), Val(Txt_IdLinea.Text), _
                                                                  Val(Txt_IdFamilia.Text), Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_L4.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstl4(0, 0, 0, 0, 0, _
                                                                  0, 0, 0, Txt_L4.Text, 4, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdL4.Text = objDataSet.Tables(0).Rows(0).Item("idl4").ToString
                Else
                    'If Txt_L3.Text = "" AndAlso Txt_DescripL3.Text = "" Then
                    '    MsgBox("Debe especificar L3 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_L4.Text = ""
                    '    Txt_L3.Focus()
                    'Else
                    Call CargarFormaConsulta("L4", 11)
                End If
                'End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L5.GotFocus
        Txt_L5.SelectAll()
    End Sub
    Private Sub Txt_L5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L5.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_L5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L5.LostFocus
        Try
            If Txt_L5.Text.Length = 0 Then Exit Sub
            If Txt_L5.Text.Trim.Length < 3 Then
                Txt_L5.Text = pub_RellenarIzquierda(Txt_L5.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)

                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" AndAlso Txt_IdLinea.Text <> "" _
                AndAlso Txt_L1.Text <> "" AndAlso Txt_IdL2.Text <> "" AndAlso Txt_IdL3.Text <> "" AndAlso Txt_L4.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstl5(0, Val(Txt_IdL4.Text), Val(Txt_IdL3.Text), Val(Txt_IdL2.Text), Val(Txt_IdL1.Text), Val(Txt_IdLinea.Text), _
                                                                    Val(Txt_IdFamilia.Text), Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_L5.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstl5(0, 0, 0, 0, 0, 0, _
                                                                   0, 0, 0, Txt_L5.Text, 4, "")
                End If



                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdL5.Text = objDataSet.Tables(0).Rows(0).Item("idl5").ToString
                Else
                    'If Txt_L4.Text = "" AndAlso Txt_DescripL4.Text = "" Then
                    '    MsgBox("Debe especificar L4 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_L5.Text = ""
                    '    Txt_L4.Focus()
                    'Else
                    Call CargarFormaConsulta("L5", 12)
                    'End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_L6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L6.GotFocus
        Txt_L6.SelectAll()
    End Sub
    Private Sub Txt_L6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_L6.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_L6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L6.LostFocus
        Try
            If Txt_L6.Text.Length = 0 Then Exit Sub
            If Txt_L6.Text.Trim.Length < 3 Then
                Txt_L6.Text = pub_RellenarIzquierda(Txt_L6.Text.Trim, 3)
            End If

            Using objEstructura As New BCL.BCLEstructura(GLB_ConStringCipSis)
                If Txt_IdDivision.Text <> "" AndAlso Txt_IdDepto.Text <> "" AndAlso Txt_IdFamilia.Text <> "" AndAlso Txt_IdLinea.Text <> "" _
                AndAlso Txt_L1.Text <> "" AndAlso Txt_IdL2.Text <> "" AndAlso Txt_IdL3.Text <> "" AndAlso Txt_L4.Text <> "" Then
                    objDataSet = objEstructura.usp_TraerEstl6(0, Val(Txt_IdL5.Text), Val(Txt_IdL4.Text), Val(Txt_IdL3.Text), Val(Txt_IdL2.Text), Val(Txt_IdL1.Text), Val(Txt_IdLinea.Text), _
                                                                    Val(Txt_IdFamilia.Text), Val(Txt_IdDepto.Text), Val(Txt_IdDivision.Text), Txt_L6.Text, 2, "")
                Else
                    objDataSet = objEstructura.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, _
                                                                  0, 0, 0, Txt_L6.Text, 4, "")
                End If


                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_IdL6.Text = objDataSet.Tables(0).Rows(0).Item("idl6").ToString
                Else
                    'If Txt_L5.Text = "" AndAlso Txt_DescripL5.Text = "" Then
                    '    MsgBox("Debe especificar L5 para el Modelo.", MsgBoxStyle.Critical, "Validación")
                    '    Txt_L6.Text = ""
                    '    Txt_L5.Focus()
                    'Else
                    Call CargarFormaConsulta("L6", 13)
                    'End If
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Division_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.TextChanged
        'Txt_IdDepto.Text = ""
        'Txt_Depto.Text = ""
        'Txt_DescripDepto.Text = ""
    End Sub
    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Familia.TextChanged
        'Txt_IdLinea.Text = ""
        'Txt_Linea.Text = ""
        'Txt_DescripLinea.Text = ""
    End Sub
    Private Sub Txt_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea.TextChanged
        'Txt_IdL1.Text = ""
        'Txt_L1.Text = ""
        'Txt_DescripL1.Text = ""
    End Sub
    Private Sub Txt_L1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L1.TextChanged
        'Txt_IdL2.Text = ""
        'Txt_L2.Text = ""
        'Txt_DescripL2.Text = ""
    End Sub
    Private Sub Txt_L2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L2.TextChanged
        'Txt_IdL3.Text = ""
        'Txt_L3.Text = ""
        'Txt_DescripL3.Text = ""
    End Sub
    Private Sub Txt_L3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L3.TextChanged
        'Txt_IdL4.Text = ""
        'Txt_L4.Text = ""
        'Txt_DescripL4.Text = ""
    End Sub
    Private Sub Txt_L4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L4.TextChanged
        'Txt_IdL5.Text = ""
        'Txt_L5.Text = ""
        'Txt_DescripL5.Text = ""
    End Sub
    Private Sub Txt_L5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_L5.TextChanged
        'Txt_IdL6.Text = ""
        'Txt_L6.Text = ""
        'Txt_DescripL6.Text = ""
    End Sub
    Private Sub Txt_Proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.GotFocus
        Txt_Proveedor.SelectAll()
    End Sub
    Private Sub Txt_Proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Txt_Proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.LostFocus
        Try
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFormaConsulta(ByVal TipoC As String, ByVal Opcion As Integer)

        Try
            Dim myForm As New frmConsulta

            If Opcion = 1 Then 'division
                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If
            End If

            If Opcion = 2 Then 'depto
                Txt_IdDepto.Text = ""

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 3 Then 'familia
                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior2 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If
            If Opcion = 4 Then 'linea
                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If
                myForm.IdSuperior1 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior2 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior3 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If
            If Opcion = 5 Then 'sublinea
                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If
                myForm.IdSuperior1 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior2 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior3 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior4 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 6 Then 'subsublinea
                If Txt_L2.Text.Trim.Length < 3 Then
                    Txt_L2.Text = pub_RellenarIzquierda(Txt_L2.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If
                myForm.IdSuperior1 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior2 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior3 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior4 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior5 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 7 Then 'sub sub sub linea
                If Txt_L2.Text.Trim.Length < 3 Then
                    Txt_L2.Text = pub_RellenarIzquierda(Txt_L2.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior3 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior4 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior5 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior6 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 11 Then 'sub sub sub sub linea
                If Txt_L3.Text.Trim.Length < 3 Then
                    Txt_L3.Text = pub_RellenarIzquierda(Txt_L3.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                If Txt_IdL4.Text = "" Then
                    Txt_IdL4.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL3.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior3 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior4 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior5 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior6 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior7 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 12 Then 'L5
                If Txt_L5.Text.Trim.Length < 3 Then
                    Txt_L5.Text = pub_RellenarIzquierda(Txt_L5.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                If Txt_IdL4.Text = "" Then
                    Txt_IdL4.Text = 0
                End If

                If Txt_IdL5.Text = "" Then
                    Txt_IdL5.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL4.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL3.Text)
                myForm.IdSuperior3 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior4 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior5 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior6 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior7 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior8 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            If Opcion = 13 Then 'L6
                If Txt_L6.Text.Trim.Length < 3 Then
                    Txt_L6.Text = pub_RellenarIzquierda(Txt_L6.Text.Trim, 3)
                End If

                If Txt_IdFamilia.Text = "" Then
                    Txt_IdFamilia.Text = 0
                End If

                If Txt_IdDivision.Text = "" Then
                    Txt_IdDivision.Text = 0
                End If

                If Txt_IdDepto.Text = "" Then
                    Txt_IdDepto.Text = 0
                End If

                If Txt_IdLinea.Text = "" Then
                    Txt_IdLinea.Text = 0
                End If

                If Txt_IdL1.Text = "" Then
                    Txt_IdL1.Text = 0
                End If

                If Txt_IdL2.Text = "" Then
                    Txt_IdL2.Text = 0
                End If

                If Txt_IdL3.Text = "" Then
                    Txt_IdL3.Text = 0
                End If

                If Txt_IdL4.Text = "" Then
                    Txt_IdL4.Text = 0
                End If

                If Txt_IdL5.Text = "" Then
                    Txt_IdL5.Text = 0
                End If

                If Txt_IdL6.Text = "" Then
                    Txt_IdL6.Text = 0
                End If

                myForm.IdSuperior1 = CInt(Txt_IdL5.Text)
                myForm.IdSuperior2 = CInt(Txt_IdL4.Text)
                myForm.IdSuperior3 = CInt(Txt_IdL3.Text)
                myForm.IdSuperior4 = CInt(Txt_IdL2.Text)
                myForm.IdSuperior5 = CInt(Txt_IdL1.Text)
                myForm.IdSuperior6 = CInt(Txt_IdLinea.Text)
                myForm.IdSuperior7 = CInt(Txt_IdFamilia.Text)
                myForm.IdSuperior8 = CInt(Txt_IdDepto.Text)
                myForm.IdSuperior9 = CInt(Txt_IdDivision.Text)
                myForm.Opcion = 1
            End If

            myForm.Tipo = TipoC
            myForm.ShowDialog()

            If Opcion = 1 Then 'Division
                Txt_IdDivision.Text = myForm.Campo
                Txt_Division.Text = myForm.Campo1
                Txt_DescripDivision.Text = myForm.Campo2
                If Txt_Division.Text.Length = 0 Then
                    Txt_Division.Focus()
                End If
            End If

            If Opcion = 2 Then 'Departamento
                Txt_IdDepto.Text = myForm.Campo
                Txt_Depto.Text = myForm.Campo1
                Txt_DescripDepto.Text = myForm.Campo2
                If Txt_Depto.Text.Length = 0 Then
                    Txt_Depto.Focus()
                End If
            End If

            If Opcion = 3 Then 'Familia
                Txt_IdFamilia.Text = myForm.Campo
                Txt_Familia.Text = myForm.Campo1
                Txt_DescripFamilia.Text = myForm.Campo2
                If Txt_Familia.Text.Length = 0 Then
                    Txt_Familia.Focus()
                End If
            End If

            If Opcion = 4 Then 'Linea
                Txt_IdLinea.Text = myForm.Campo
                Txt_Linea.Text = myForm.Campo1
                Txt_DescripLinea.Text = myForm.Campo2

                If Txt_Linea.Text.Length = 0 Then
                    Txt_Linea.Focus()
                End If
            End If

            If Opcion = 5 Then 'L1
                Txt_IdL1.Text = myForm.Campo
                Txt_L1.Text = myForm.Campo1
                Txt_DescripL1.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La Línea " + Txt_DescripLinea.Text + " no cuenta con L1.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L1.Text.Length = 0 Then
                    Txt_L1.Focus()
                End If
            End If

            If Opcion = 6 Then 'L2
                Txt_IdL2.Text = myForm.Campo
                Txt_L2.Text = myForm.Campo1
                Txt_DescripL2.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L1 " + Txt_DescripL1.Text + " no cuenta con L2.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L2.Text.Length = 0 Then
                    Txt_L2.Focus()
                End If
            End If


            If Opcion = 7 Then 'L3
                Txt_IdL3.Text = myForm.Campo
                Txt_L3.Text = myForm.Campo1
                Txt_DescripL3.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L2 " + Txt_DescripL2.Text + " no cuenta con L3.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L3.Text.Length = 0 Then
                    Txt_L3.Focus()
                End If
            End If

            If Opcion = 11 Then 'L4
                Txt_IdL4.Text = myForm.Campo
                Txt_L4.Text = myForm.Campo1
                Txt_DescripL4.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L3 " + Txt_DescripL3.Text + " no cuenta con L4.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L4.Text.Length = 0 Then
                    Txt_L4.Focus()
                End If
            End If

            If Opcion = 12 Then 'L5
                Txt_IdL5.Text = myForm.Campo
                Txt_L5.Text = myForm.Campo1
                Txt_DescripL5.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L4 " + Txt_DescripL4.Text + " no cuenta con L5.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L5.Text.Length = 0 Then
                    Txt_L5.Focus()
                End If
            End If

            If Opcion = 13 Then 'L6
                Txt_IdL6.Text = myForm.Campo
                Txt_L6.Text = myForm.Campo1
                Txt_DescripL6.Text = myForm.Campo2

                If myForm.blnVacio = True Then
                    MsgBox("La L5 " + Txt_DescripL5.Text + " no cuenta con L6.", MsgBoxStyle.Critical, "Validación")
                End If

                If Txt_L6.Text.Length = 0 Then
                    Txt_L6.Focus()
                End If
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargaDescripcion(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If Txt_Marca.Text <> "" Then
                Call Txt_Marca_LostFocus(sender, e)
            End If

            If Txt_IdDivision.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(1, Val(Txt_IdDivision.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Division.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdDepto.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(2, Val(Txt_IdDepto.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdFamilia.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(3, Val(Txt_IdFamilia.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdLinea.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(4, Val(Txt_IdLinea.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdL1.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(5, Val(Txt_IdL1.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdL2.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(6, Val(Txt_IdL2.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdL3.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(7, Val(Txt_IdL3.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdL4.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(8, Val(Txt_IdL4.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdL5.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(9, Val(Txt_IdL5.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_IdL6.Text <> 0 Then
                Using objCatModelos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSet = objCatModelos.usp_TraerEstFiltroDescrip(10, Val(Txt_IdL6.Text))
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip")
                    End If
                End Using
            End If

            If Txt_Proveedor.Text <> "" Then
                Call Txt_Proveedor_LostFocus(sender, e)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class