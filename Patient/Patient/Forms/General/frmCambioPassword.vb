Public Class frmCambioPassword
    Private objDataSet As Data.DataSet
    Private objUserDataSet As DataSet
    Private veces As Integer = 0
    Private Const NumeroIntentos As Integer = 3
    Private Opcion As Integer = 1


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      
        Me.Close()
    End Sub

    Private Sub Inicializar()
        Txt_NuevoPassword.Text = ""
        Txt_PasswordAnt.Text = ""
        Txt_Usuario.Text = ""
        Txt_Usuario.Select()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        ''mreyes 22/Febrero/2012 12:56 p.m.
        Try

            If MsgBox("Esta seguro de Realizar el cambio de Contraseña?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            If Txt_PasswordAnt.Text = "REDADM" Then
                MsgBox("Usuario no registrado. Intente Nuevamente", MsgBoxStyle.Critical, "Validación de usuario")

                Txt_PasswordAnt.Focus()
                Exit Sub
            End If

            If Txt_NuevoPassword.Text = "" Or Txt_NuevoPassword.Text.Length < 6 Then
                MsgBox("La Nueva Contraseña no debe ser menor a 6 caracteres.", MsgBoxStyle.Critical, "Validación de contraseña")
                Txt_NuevoPassword.Select()
                Exit Sub
            End If

            If ValidaNumLetras(Txt_NuevoPassword.Text) = False Then
                MsgBox("La Nueva Contraseña debe contener Números y Letras.", MsgBoxStyle.Critical, "Validación de contraseña")
                Txt_NuevoPassword.Select()
                Exit Sub
            End If

            If usp_TraerUsuario() = True Then
                Call usp_ActualizarPass()
                Call usp_TraerUsuBitContrasena()
                MsgBox("La contraseña del usuario se ha cambiado correctamente.", MsgBoxStyle.Information, "Validación de usuario")
                Call Inicializar()
            Else
                'Me.Close()
                MsgBox("El usuario y contraseña no coinciden. Intente Nuevamente", MsgBoxStyle.Critical, "Validación de contraseña")
                Txt_Usuario.Select()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerUsuario() As Boolean
        'mreyes 22/Febrero/2012 12:48 p.m.
        Using objPersis As New BCL.BCLPersis(GLB_ConStringPerSis)

            Try
                'Get the specific project selected in the ListView control
                If objPersis.usp_TraerUsuarioPass(Txt_Usuario.Text.Trim, Txt_PasswordAnt.Text.Trim) Then
                    usp_TraerUsuario = True
                Else
                    usp_TraerUsuario = False
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_TraerUsuarioNomina() As Boolean
        'mreyes 19/Septiembre/2012 09:38 a.m.
        Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

            Try
                'Get the specific project selected in the ListView control
                objDataSet = objPersis.usp_TraerUsuarioNomina(Txt_PasswordAnt.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    GLB_Usuario = Mid((objDataSet.Tables(0).Rows(0).Item("usuario").ToString), 1, 8)
                    '' cambiar cuando se tenga el campo 
                    GLB_NomUsuario = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    GLB_Sucursal = objDataSet.Tables(0).Rows(0).Item("descripsucursal").ToString
                    GLB_CveSucursal = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    If GLB_CveSucursal = "99" Then GLB_CveSucursal = "15"

                    usp_TraerUsuarioNomina = True
                    GLB_AccesoEmpleado = True
                Else
                    usp_TraerUsuarioNomina = False
                    '''' buscar el de nómina

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Function

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If My.Application.IsNetworkDeployed Then
        '    Me.Text = "SIRCO  Version " & My.Application.Deployment.CurrentVersion.ToString()
        'Else
        '    Me.Text = "SIRCO  Version " & Application.ProductVersion
        'End If

        If CheckDatabaseConnection() = False Then
            Me.Close()
        End If

        Txt_Usuario.Select()

    End Sub

    Private Sub Txt_Password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_PasswordAnt.GotFocus
        Txt_PasswordAnt.SelectAll()
    End Sub

    Private Sub Txt_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_PasswordAnt.TextChanged

    End Sub

    Private Function usp_ActualizarPass() As Boolean
        'Tony Garcia - 09/Octubre/2012 - 11:00 a.m.
        Using objPersis As New BCL.BCLPersis(GLB_ConStringPerSis)

            Try
                'Get the specific project selected in the ListView control
                objPersis.usp_ActualizarPassword(Txt_Usuario.Text.Trim, Txt_PasswordAnt.Text.Trim, Txt_NuevoPassword.Text.Trim)

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_TraerUsuBitContrasena() As Boolean
        'Tony Garcia - 09/Octubre/2012 - 12:50 p.m.
        Using objPersis As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try
                If objPersis.usp_TraerUsuBitContrasena(Txt_Usuario.Text.Trim) Then
                    usp_TraerUsuBitContrasena = True
                    Opcion = 2
                    Call usp_Captura_CambioPass()
                Else
                    usp_TraerUsuBitContrasena = False
                    Opcion = 1
                    Call usp_Captura_CambioPass()
                End If


                'If objDataSet.Tables(0).Rows.Count > 0 Then

                '    usp_TraerUsuBitContrasena = True
                '    Opcion = 2
                '    Call usp_Captura_CambioPass()
                'Else
                '    usp_TraerUsuBitContrasena = False
                '    Opcion = 1
                '    Call usp_Captura_CambioPass()
                'End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_Captura_CambioPass() As Boolean
        'Tony Garcia - 09/Octubre/2012 - 12:00 p.m.
        Using objPersis As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try
                objPersis.usp_Captura_CambioPass(Opcion, Txt_Usuario.Text.Trim, Txt_PasswordAnt.Text.Trim, Txt_NuevoPassword.Text.Trim, GLB_Usuario, DateTime.Now)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function ValidaNumLetras(ByVal Password As String) As Boolean
        Try
            Dim TieneLetras As Boolean = False
            Dim TieneNumeros As Boolean = False

            For i As Integer = 0 To Txt_NuevoPassword.Text.Length - 1
                Dim ch As Char = Txt_NuevoPassword.Text(i)
                If Char.IsNumber(ch) Then       ' Si el caracter es un numero
                    TieneNumeros = True
                ElseIf Char.IsLetter(ch) Then   ' Si es un caracter alfabetico
                    TieneLetras = True
                End If
            Next

            If TieneLetras AndAlso TieneNumeros Then
                ValidaNumLetras = True
            Else
                ValidaNumLetras = False
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Txt_NuevoPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_NuevoPassword.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Usuario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Usuario.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_PasswordAnt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PasswordAnt.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class
