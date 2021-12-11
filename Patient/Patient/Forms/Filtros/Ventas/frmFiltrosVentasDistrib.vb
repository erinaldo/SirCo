Public Class frmFiltrosVentasDistrib
    'Tony Garcia - 02/Junio/2013 11:25 a.m.
    Dim Sql As String

    Private objDataSet As Data.DataSet

    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
            Txt_Sucursal.Text = ""
            Txt_DescripSucursal.Text = ""
            Txt_NumDistrib.Text = ""
            Txt_NumDistrib2.Text = ""
            Txt_NombreDistrib.Text = ""
            Txt_NombreDistrib2.Text = ""
            Cbo_Estatus.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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
                    myForm.Tipo = Tipo
                    myForm.Sw_Nomina = True
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

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            Sw_Cancelar = True
            Sw_Filtro = False
            ' Me.Dispose()
            Me.Close()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Call LimpiarDatos()
    End Sub

    Private Sub frmFiltrosVentasDistrib_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

    End Sub

    Private Sub frmFiltrosVentasDistrib_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()

        If Txt_Sucursal.Text <> "" Then
            Call Txt_Sucursal_LostFocus(sender, e)
        End If

        'If Txt_NumDistrib.Text <> "" Then
        '    Call Txt_NumDistrib_LostFocus(sender, e)
        'End If

        'If Txt_NumDistrib2.Text <> "" Then
        '    Call Txt_NumDistrib2_LostFocus(sender, e)
        'End If
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Txt_NumDistrib_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NumDistrib.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_NumDistrib2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NumDistrib2.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_NumDistrib_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NumDistrib.LostFocus
        If Txt_NumDistrib.Text.Length = 0 Then Exit Sub
        Txt_NumDistrib.Text = pub_RellenarIzquierda(Txt_NumDistrib.Text, 6)


        Using objDistribuidores As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)
            Try

                objDataSet = objDistribuidores.usp_TraerNombreDistribuidor(Txt_NumDistrib.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombre")
                    If Txt_NumDistrib.Text.Length > 0 Then
                        Txt_NumDistrib2.Text = Txt_NumDistrib.Text
                    End If
                Else
                    Txt_NumDistrib.Text = ""
                    Txt_NombreDistrib.Text = ""
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_NumDistrib2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NumDistrib2.LostFocus
        If Txt_NumDistrib2.Text.Length = 0 Then Exit Sub
        Txt_NumDistrib2.Text = pub_RellenarIzquierda(Txt_NumDistrib2.Text, 6)


        Using objDistribuidores As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)
            Try

                objDataSet = objDistribuidores.usp_TraerNombreDistribuidor(Txt_NumDistrib2.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_NombreDistrib2.Text = objDataSet.Tables(0).Rows(0).Item("nombre")
                Else
                    Txt_NumDistrib2.Text = ""
                    Txt_NombreDistrib2.Text = ""
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Chk_Fecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Fecha.CheckedChanged
        If Chk_Fecha.Checked = True Then
            DTPicker2.Enabled = True
            DTPicker3.Enabled = True
        Else
            DTPicker2.Enabled = False
            DTPicker3.Enabled = False
        End If
    End Sub

    Private Sub Cbo_Estatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estatus.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class