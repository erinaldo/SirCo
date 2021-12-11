Public Class LoginForm1
    Private objDataSet As Data.DataSet
    Private objUserDataSet As DataSet
    Private veces As Integer = 0
    Private Const NumeroIntentos As Integer = 3
    Private objUser As BCL.BCLUser

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        End
        'Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Using objUser As New BCL.BCLUser(G_ConString)
            If objUser.CanLogIn(txtUserName.Text.Trim, txtPassword.Text.Trim) = True Then
                DialogResult = DialogResult.OK
                G_Usuario = txtUserName.Text

            Else
                veces = veces + 1
                If veces < NumeroIntentos Then
                    MessageBox.Show("Usuario o Password incorrecto!", "Quedan " & (NumeroIntentos - veces) & " intentos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUserName.Focus()
                    Exit Sub
                End If

            End If
            Me.Close()
        End Using
    End Sub

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
End Class
