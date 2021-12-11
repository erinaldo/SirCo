Public Class frmFiltrosPercDeduc
    'mreyes 08/Junio/2012 06:29 p.m.
    Dim Sql As String

    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False
    Private objDataSet As Data.DataSet



    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            Sw_Filtro = True
            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            Sw_Filtro = False
            ' Me.Dispose()
            Me.Close()




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Raz_Soc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Raz_Soc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Raz_Soc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Raz_Soc.LostFocus

    End Sub



    Private Sub Txt_Raz_Soc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Raz_Soc.TextChanged

    End Sub

    Private Sub Cbo_Estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Estado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Cbo_Estado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Estado.LostFocus
        Call RellenaCombos(Cbo_Ciudad, "CIUDAD", " WHERE estado = '" & Cbo_Estado.Text & "'", GLB_ConStringPerSis, True)

    End Sub


    Private Sub Cbo_Ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Ciudad.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmFiltrosProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub



    Private Sub frmFiltrosProveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call RellenaCombos(Cbo_Estado, "ESTADO", "", GLB_ConStringPerSis, True)
        Call GenerarToolTip()
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

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

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Cbo_Ciudad.Text = ""
        Cbo_Estado.Text = ""
        Txt_Raz_Soc.Text = ""
    End Sub

    Private Sub Cbo_Estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Estado.SelectedIndexChanged

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



    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:25 a.m.

        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
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

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged

    End Sub
End Class