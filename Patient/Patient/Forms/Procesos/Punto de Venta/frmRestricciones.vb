Public Class frmRestricciones

    Public Id As Integer
    Public Tipo As String
    Public Prioridad As Integer
    Private Sub frmRestricciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lbl_Tipo.Text = Tipo
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmRestricciones_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            If pb_Imagen.EditValue Is Nothing Then
                MessageBox.Show("Por favor selecciona una imagen", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txt_Descripcion.Text.Trim = "" Then
                MessageBox.Show("Por favor ingresa una descripción", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_Descripcion.Focus()
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas guardar la restricción", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                objPromociones.usp_CapturaRestriccion(Id, Tipo, txt_Descripcion.Text.Trim, pb_Imagen.EditValue, Prioridad, GLB_Usuario)
            End Using
            MessageBox.Show("Restricción creada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub
End Class