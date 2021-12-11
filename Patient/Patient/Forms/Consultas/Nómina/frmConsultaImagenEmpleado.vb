Public Class frmConsultaImagenEmpleado

    Private Sub frmConsultaImagen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    'miguel pérez 04/Septiembre/2012 09:51 a.m.


    Private Sub frmConsultaImagen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarFotoEmpleado()
        Me.Text = "Empleado: " & Txt_Empleado.Text & " " & Txt_Nombre.Text
    End Sub
    Private Sub CargarFotoEmpleado()
        'miguel pérez 04/Septiembre/2012 10:00 a.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEmpleado(GLB_RutaFotoEmpleado, Txt_Empleado.Text)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



End Class