Public Class frmCancelaMuestra
    'mreyes 07/Octubre/2017 10:30 a.m.
    Public Sw_Guardo As Boolean = False
    Public Marca As String
    Public Modelo As String
    Private Sub Btn_Cancelar_Click(sender As Object, e As EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Limpiar_Click(sender As Object, e As EventArgs) Handles Btn_Limpiar.Click
        Txt_Observaciones.Text = ""
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            ' cancelar muestra 
            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                Sw_Guardo = objBultos.usp_CancelaMuestrasdet(1, Marca, Modelo, Txt_Observaciones.Text, GLB_Idempleado)
            End Using
            Sw_Guardo = True
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCancelaMuestra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim S As String

        S = UCase(e.KeyChar)

        S = ChrW(Asc(S))

        e.KeyChar = S
    End Sub

    Private Sub frmCancelaMuestra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmCancelaMuestra_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class