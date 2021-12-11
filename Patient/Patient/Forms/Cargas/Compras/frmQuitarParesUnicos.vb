Public Class frmQuitarParesUnicos

    Private objDataSet As Data.DataSet
    Private Sub Txt_Marca_LostFocus(sender As Object, e As EventArgs) Handles Txt_Marca.LostFocus
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

    Private Sub Txt_Marca_TextChanged(sender As Object, e As EventArgs) Handles Txt_Marca.TextChanged

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

    Private Sub Txt_Modelo_TextChanged(sender As Object, e As EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub Txt_Modelo_LostFocus(sender As Object, e As EventArgs) Handles Txt_Modelo.LostFocus
        If Txt_Modelo.Text.Length > 0 Then
            Txt_Modelo.Text = Txt_Modelo.Text.PadLeft(7)
        End If
    End Sub

    Public Function usp_QuitarParesUnicos(Marca As String, Modelo As String) As Boolean
        'mreyes 21/Noviembre/2018   12:51 p.m.
        Try
            'Validate group data
            Using objDALCargaMysqlSql As New BCL.BCLCompras(GLB_ConStringCipSis)
                'Call the data component to add the new group
                If objDALCargaMysqlSql.usp_QuitarParesUnicos(Marca, Modelo) Then
                End If
            End Using





        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Private Sub frmQuitarParesUnicos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try


            Me.Cursor = Cursors.WaitCursor

            If usp_QuitarParesUnicos(Txt_Marca.Text, Txt_Modelo.Text) = False Then

            End If


            MsgBox("Proceso Terminado", MsgBoxStyle.Information, "Aviso")
            Me.Cursor = Cursors.Default

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Sub
End Class