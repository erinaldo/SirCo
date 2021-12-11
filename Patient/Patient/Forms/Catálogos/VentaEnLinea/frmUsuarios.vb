Imports DevExpress.XtraEditors.Controls

Public Class frmUsuarios
    Public Accion As Integer = 1
    Public UsuarioSistema As String = ""
    Private Sub Txt_IdEmpleado_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_IdEmpleado.EditValueChanged

    End Sub

    Private Sub Txt_IdEmpleado_LostFocus(sender As Object, e As EventArgs) Handles Txt_IdEmpleado.LostFocus
        If Accion <> 1 Then Exit Sub

        If Txt_IdEmpleado.Text = "0" Then
            'es nuevo, 
            Txt_UsuarioSistema.Enabled = True
            Txt_UsuarioSistema.Focus()

        End If
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_IdEmpleado.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_IdEmpleado.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                    DTNacim.Text = objDataSet.Tables(0).Rows(0).Item("nacim")
                    Txt_UsuarioSistema.Text = objDataSet.Tables(0).Rows(0).Item("usuariosistema").ToString
                    Txt_Nombre.Enabled = False
                    Txt_IdEmpleado.Enabled = False
                    DTNacim.Enabled = False
                Else
                    Call CargarFormaConsultaEmpleadoM1()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub CargarFormaConsultaEmpleadoM1()
        Try
            Dim myForm As New frmConsultaEmpleado
            Txt_Nombre.Text = ""
            myForm.Estatus = "A"
            myForm.ShowDialog()
            Txt_IdEmpleado.Text = myForm.Campo
            Txt_Nombre.Text = myForm.Campo1
            If Txt_IdEmpleado.Text.Length = 0 Then
                Txt_IdEmpleado.Focus()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Nombre_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Nombre.EditValueChanged

    End Sub

    Private Sub Txt_Nombre_LostFocus(sender As Object, e As EventArgs) Handles Txt_Nombre.LostFocus
        If Accion <> 1 Then Exit Sub
        If Len(Txt_Nombre.Text) = 0 Then Exit Sub
        Txt_UsuarioSistema.Text = Mid(Txt_Nombre.Text, 1, 2) & Mid(Txt_Nombre.Text, InStr(Txt_Nombre.Text, " ") + 1, 2) & Year(DTNacim.Text)
    End Sub

    Private Sub DTNacim_EditValueChanged(sender As Object, e As EventArgs) Handles DTNacim.EditValueChanged

    End Sub

    Private Sub DTNacim_LostFocus(sender As Object, e As EventArgs) Handles DTNacim.LostFocus
        If Accion <> 1 Then Exit Sub
        If Txt_IdEmpleado.Text = "0" And Len(Txt_Nombre.Text) > 0 Then
            Txt_UsuarioSistema.Text = Mid(Txt_Nombre.Text, 1, 2) & Mid(Txt_Nombre.Text, InStr(Txt_Nombre.Text, " ") + 1, 2) & Year(DTNacim.Text)
        End If
    End Sub

    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        'DTNacim.Text = GLB_FechaHoy
        Try
            If Accion = 4 Then
                '' consulta
                Pnl_Botones.Enabled = False
                Pnl_Datos.Enabled = False

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function ValidarEdicion() As Boolean

        Try
            ValidarEdicion = False
            If Txt_UsuarioSistema.Text = "" Then
                MsgBox("No se puede registrar el usuario, verifique los datos", MsgBoxStyle.Critical, "Error")
                Exit Function
            End If
            ValidarEdicion = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim Sw_Guardo As Boolean = False

            Dim Damas As Integer = 0
            Dim Caballeros As Integer = 0
            Dim Ninas As Integer = 0
            Dim Ninos As Integer = 0
            Dim Bebes As Integer = 0
            Dim Accesorios As Integer = 0

            If Btn_Damas.Checked = True Then
                Damas = 1
            End If

            If Btn_Caballeros.Checked = True Then
                Caballeros = 1
            End If
            If Btn_Ninas.Checked = True Then
                Ninas = 1
            End If
            If Btn_Ninos.Checked = True Then
                Ninos = 1
            End If
            If Btn_Bebes.Checked = True Then
                Bebes = 1
            End If
            If Btn_Accesorios.Checked = True Then
                Accesorios = 1
            End If


            ' grabar permisos y usuario



            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar Los permisos al Usuario?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Using objUsuario As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                        Sw_Guardo = objUsuario.usp_Captura_Usuario(Accion, Txt_UsuarioSistema.Text, Txt_IdEmpleado.Text, Txt_Nombre.Text, DTNacim.Text, Txt_Password.Text, GLB_Idempleado, 0)
                    End Using
                    Sw_Guardo = True
                    Using objUsuario As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                        Sw_Guardo = objUsuario.usp_Captura_Permisos(Accion, Txt_UsuarioSistema.Text, Damas, Caballeros, Ninas, Ninos, Bebes, Accesorios, GLB_Idempleado, 0)
                    End Using



                    MsgBox("Usuario Registrado Correctamente", MsgBoxStyle.Information, "Confirmación")

                    'SALIR 
                    GLB_RefrescarPedido = True
                    Me.Close()
                    Me.Dispose()
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar los Permisos?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Using objUsuario As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                        Sw_Guardo = objUsuario.usp_Captura_Usuario(Accion, Txt_UsuarioSistema.Text, Txt_IdEmpleado.Text, Txt_Nombre.Text, DTNacim.Text, Txt_Password.Text, GLB_Idempleado, GLB_Idempleado)
                    End Using
                    Using objUsuario As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                        Sw_Guardo = objUsuario.usp_Captura_Permisos(Accion, Txt_UsuarioSistema.Text, Damas, Caballeros, Ninas, Ninos, Bebes, Accesorios, GLB_Idempleado, GLB_Idempleado)
                    End Using

                    Sw_Guardo = True
                    MsgBox("Usuario Actualizado Correctamente", MsgBoxStyle.Information, "Confirmación")
                    GLB_RefrescarPedido = True
                    Me.Close()
                    Me.Dispose()

                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Confirmacion_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Confirmacion.EditValueChanged

    End Sub

    Private Sub Txt_Confirmacion_FormatEditValue(sender As Object, e As ConvertEditValueEventArgs) Handles Txt_Confirmacion.FormatEditValue
        Try
            If Accion <> 1 Or Accion <> 2 Then Exit Sub
            If Txt_Password.Text <> "" And Txt_Confirmacion.Text <> "" Then Exit Sub
            If Txt_Confirmacion.Text <> Txt_Password.Text Then
                MsgBox("La contraseña no coincide, intente nuevamente.", MsgBoxStyle.Critical, "Error")
                Txt_Confirmacion.Text = ""
                Txt_Confirmacion.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click

        If Accion = 4 Then
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If
    End Sub

    Private Sub Pnl_Datos_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Datos.Paint

    End Sub

    Private Sub frmUsuarios_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class