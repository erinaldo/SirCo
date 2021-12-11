Public Class frmPermisoProceso
    Private objDataSet As Data.DataSet
    Private objUserDataSet As DataSet
    Private veces As Integer = 0
    Private Const NumeroIntentos As Integer = 3



    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Glb_PermisoProceso = False
        Me.DialogResult = DialogResult.Cancel

        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'mreyes 22/Febrero/2012 12:56 p.m.
        Try
            glb_PermisoProceso = True
            If usp_TraerUsuario() = True Then
                DialogResult = DialogResult.OK
                glb_permisoproceso = True
            Else
                'Me.Close()
                MsgBox("Intente Nuevamente", MsgBoxStyle.Critical, "Validación de usuario")
                glb_permisoproceso = False
                Txt_Password.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerUsuario() As Boolean
        'mreyes 22/Febrero/2012 12:48 p.m.
        Using objPersis As New BCL.BCLPersis(Glb_ConStringPerSis)

            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPersis.usp_TraerPermisoProceso(GLB_Usuario, GLB_Programa, GLB_Proceso, Txt_Password.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If Txt_Password.Text = (objDataSet.Tables(0).Rows(0).Item("passpRoc").ToString) Then
                        '' cambiar cuando se tenga el campo 
                        usp_TraerUsuario = True
                    Else
                        usp_TraerUsuario = False
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Function

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Application.IsNetworkDeployed Then
            LblVersion.Text = "Version " & My.Application.Deployment.CurrentVersion.ToString()
        Else
            LblVersion.Text = "Version " & Application.ProductVersion
        End If

        If CheckDatabaseConnection() = False Then
            Me.Close()
        End If

    End Sub

    Private Sub Txt_Password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Password.GotFocus
        Txt_Password.SelectAll()
    End Sub


    Private Sub Txt_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Password.TextChanged

    End Sub
End Class
