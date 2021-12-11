Public Class frmFiltroAnalisisFull
    Dim objDataSet As DataSet
    Public tipo As Integer
    Public Marca As String
    Public Modelo As String
    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs)
        txt_estilon.Clear()
        txt_marca.Clear()
        txt_descripmarca.Clear()
    End Sub

    Private Sub btn_aceptar_Click(sender As Object, e As EventArgs) Handles btn_aceptar.Click
        tipo = 2
        If dtp_FechaFin.Value.Date < dtp_FechaFin.Value.Date Then
            MsgBox("La fecha Inicial no puede ser menor que la fecha Final, pruebe seleccionando otra fecha", MsgBoxStyle.Critical, "ERROR")
            dtp_FechaIni.Select()
        End If

        Dim frm As New frmAnalisisfull
        Marca = txt_marca.Text
        Modelo = txt_estilon.Text

        If txt_estilon.Text = "" Then
            MsgBox("Debe especificar un modelo", MsgBoxStyle.Critical, "ERROR")
            txt_estilon.Focus()
            Exit Sub
        End If

        If txt_marca.Text = "" Then
            MsgBox("Debe especificar una marca", MsgBoxStyle.Critical, "ERROR")
            txt_marca.Focus()
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub frmFiltroAnalisisFull_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_estilon.SelectAll()
    End Sub

    Private Sub btn_cancelar_Click_1(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        tipo = 1
        Me.Close()
    End Sub

    Private Sub btn_limpiar_Click_1(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        txt_marca.Clear()
        txt_estilon.Clear()
        txt_descripmarca.Clear()
        dtp_FechaIni.Value = Date.Now
        dtp_FechaFin.Value = Date.Now
        txt_estilon.Focus()
    End Sub

    Private Sub txt_marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If txt_marca.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If txt_marca.Text.Trim.Length < 3 Then
                    txt_marca.Text = pub_RellenarIzquierda(txt_marca.Text.Trim, 3)
                End If
                Call TxtLostfocus(txt_marca, txt_descripmarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
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

    Private Sub txt_estilon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_estilon.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub frmFiltroAnalisisFull_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call btn_cancelar_Click_1(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            Call btn_aceptar_Click(sender, e)
        End If
    End Sub

    Private Sub txt_marca_TextChanged(sender As Object, e As EventArgs) Handles txt_marca.TextChanged

    End Sub
End Class