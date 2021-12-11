Public Class frmCatalogoGestoresDeCartera

    Public Accion As Integer = 0
    Dim blnValGestor As Boolean = False
    Dim idusuario As Integer
    Dim idusuariomodif As Integer
    Public tipoGestor As String
    Dim carterafresca As Integer
    Dim carteravencida As Integer
    Public idgestor As Integer

    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        If Accion = 1 Or Accion = 2 Then
            If MsgBox("Estas Seguro de salir ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmCatalogoGestoresDeCartera_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            If Accion = 1 Or Accion = 2 Then
                If MsgBox("Estas Seguro de salir ?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub GenerarToolTip()
        Try

            ToolTip1.SetToolTip(Btn_Aceptar, "Aceptar")
            ToolTip1.SetToolTip(Btn_Cancelar, "Cancelar")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Nombre.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_Nombre.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_Appaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Appaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_Appaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Private Sub Txt_idGestor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_id.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Apmaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Apmaterno.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsLower(e.KeyChar) Then


            Txt_Apmaterno.SelectedText = Char.ToUpper(e.KeyChar)

            e.Handled = True
        End If
    End Sub

    Function usp_CapturaGestorDeCartera() As Boolean

        Using objCatalogo As New BCL.BCLGestoresDeCartera(GLB_ConStringCreditoSQL)

            Try
                blnValGestor = ValidarGestor()
                If blnValGestor = True Then

                    If Chk_CarteraFresca.Checked = True Then
                        carterafresca = 1
                    Else
                        carterafresca = 0
                    End If
                    If Chk_CarteraVencida.Checked = True Then
                        carteravencida = 1
                    Else
                        carteravencida = 0
                    End If
                    idgestor = Txt_id.Text
                    If Accion = 1 Then
                        idusuario = GLB_Idempleado
                        idusuariomodif = 0

                        Application.DoEvents()
                        usp_CapturaGestorDeCartera = objCatalogo.usp_CapturaGestorDeCartera(Accion, idgestor, tipoGestor, carterafresca, carteravencida, idusuario, idusuariomodif)
                        Application.DoEvents()
                    ElseIf Accion = 2 Then
                        idusuariomodif = GLB_Idempleado
                        Application.DoEvents()
                        usp_CapturaGestorDeCartera = objCatalogo.usp_CapturaGestorDeCartera(Accion, idgestor, tipoGestor, carterafresca, carteravencida, idusuario, idusuariomodif)
                        Application.DoEvents()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        End Using

    End Function

    Private Function ValidarGestor() As Boolean
        ValidarGestor = True
        Dim BolVal As Boolean = True
        If Txt_id.Text = "" Then
            ValidarGestor = False
            Txt_id.Focus()
            MessageBox.Show("Debe ingresar el un Número del Gestor correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
        If Chk_CarteraFresca.Checked = False And Chk_CarteraVencida.Checked = False Then
            ValidarGestor = False
            Chk_CarteraFresca.Focus()
            MessageBox.Show("Debe elegir un tipo de Cartera correctamente.", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Function
        End If
    End Function
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try

            GLB_RefrescarPedido = False
            If Accion = 1 Then '-NUEVO
                If usp_CapturaGestorDeCartera() = True Then
                    If MsgBox("Estas Seguro de Grabar el Gestor de Cartera?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Gestor de Cartera '" & " !", "Agregando Gestor de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    If blnValGestor = False Then Exit Sub
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Accion = 2 Then '-ACTUALIZACION
                If usp_CapturaGestorDeCartera() = True Then
                    If MsgBox("Esta Seguro de Actualizar el Gestor de Cartera?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        GLB_RefrescarPedido = True
                        MessageBox.Show("Exitosamente Grabado el Gestor de Cartera  '" & Txt_Nombre.Text & "  " & Txt_Appaterno.Text & " !", "Actualizando Gestor de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    If blnValGestor = False Then Exit Sub
                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_idGestor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_id.LostFocus
        Dim ObjDataValidacion As Data.DataSet
        If Txt_id.Text <> "" Then
            Using objTrasp As New BCL.BCLGestoresDeCartera(GLB_ConStringCreditoSQL)
                If Accion = 1 Then 'Validacion si exsite un gestor con el mismo idgestor ya insertado en gestores
                    ObjDataValidacion = objTrasp.usp_TraerGestoresDeCartera(1, Txt_id.Text)
                    If ObjDataValidacion.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("Ya existe un Gestor de Cartera con el mismo Número " + Txt_id.Text + " .", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Txt_id.Text = ""
                        Txt_Nombre.Text = ""
                        Txt_Appaterno.Text = ""
                        Txt_Apmaterno.Text = ""
                    Else
                        ObjDataValidacion = Nothing
                        ObjDataValidacion = objTrasp.usp_TraerGestoresDeCartera(2, Txt_id.Text)
                        If ObjDataValidacion.Tables(0).Rows.Count = 1 Then
                            Txt_Nombre.Text = ObjDataValidacion.Tables(0).Rows(0).Item("nombre").ToString
                            Txt_Appaterno.Text = ObjDataValidacion.Tables(0).Rows(0).Item("appaterno").ToString
                            Txt_Apmaterno.Text = ObjDataValidacion.Tables(0).Rows(0).Item("apmaterno").ToString
                            tipoGestor = ObjDataValidacion.Tables(0).Rows(0).Item("tipo").ToString
                            tipoGestor = tipoGestor.Substring(0, 1)
                        ElseIf ObjDataValidacion.Tables(0).Rows.Count > 1 Then
                            Dim myForm As New frmRelacionGestor

                            myForm.Txt_Id.Text = Txt_id.Text
                            myForm.ShowDialog()
                            Txt_Nombre.Text = myForm.Nombre
                            Txt_Appaterno.Text = myForm.appaterno
                            Txt_Apmaterno.Text = myForm.apmaterno
                            tipoGestor = myForm.tipo
                        Else
                            MessageBox.Show("No existen datos que cumplan con ese Número " + Txt_id.Text + " .", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Txt_id.Text = ""
                        End If
                    End If
                End If
            End Using
        End If
    End Sub

    Private Sub Chk_CarteraFresca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_CarteraFresca.LostFocus

    End Sub

    Private Sub Chk_CarteraVencida_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_CarteraVencida.LostFocus

    End Sub

    Private Sub Chk_CarteraVencida_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_CarteraVencida.CheckedChanged
        If Chk_CarteraVencida.Checked = True Then
            Chk_CarteraFresca.Checked = False
        Else
            Chk_CarteraFresca.Checked = True
        End If
    End Sub

    Private Sub Chk_CarteraFresca_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_CarteraFresca.CheckedChanged
        If Chk_CarteraFresca.Checked = True Then
            Chk_CarteraVencida.Checked = False
        Else
            Chk_CarteraVencida.Checked = True
        End If
    End Sub

    Private Sub frmCatalogoGestoresDeCartera_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If Accion = 1 Or Accion = 2 Then
        '    If MessageBox.Show("Estas seguro de salir ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
        '        Me.Dispose()
        '        Me.Close()
        '    End If
        'Else
        '    Me.Dispose()
        '    Me.Close()
        'End If
    End Sub

    Private Sub frmCatalogoGestoresDeCartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
    End Sub
End Class