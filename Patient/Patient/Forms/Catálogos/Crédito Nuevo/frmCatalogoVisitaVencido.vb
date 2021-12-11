Public Class frmCatalogoVisitaVencido
    'mreyes 09/Diciembre/2017   10:08 p.m.


    Public Distrib As String = ""
    Public Adeudo As Decimal = 0
    Public Accion As Integer = 0
    Public Sw_Registro As Boolean = False

    Private Sub frmCatalogoCallCenter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim S As String

        S = UCase(e.KeyChar)

        S = ChrW(Asc(S))

        e.KeyChar = S
    End Sub

    Private Sub frmCatalogoCallCenter_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Lbl_Leyenda.Visible = True
    End Sub

    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False



        ValidarEdicion = True

    End Function
    Private Function usp_Captura_CallCenter() As Boolean
        'mreyes 06/Junio/2017   04:23 p.m.
        Dim Llamada As Integer = 0

        If Lbl_Leyenda.Visible = True Then
            Llamada = 0
        Else
            Llamada = 1
        End If

        Using objCalculo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_Captura_CallCenter = objCalculo.usp_Captura_CallCenter(1, 0, Distrib, GLB_FechaHoy, Dt_Promesado.Text, Val(Txt_Adeudo.Text), Mem_Comentarios.Text, Llamada, GLB_Idempleado)


                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        'mreyes 29/Febrero/2012 10:40 a.m.
        Try

            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If usp_Captura_CallCenter() = True Then


                    Sw_Registro = True
                    Me.Close()
                    '' Me.Dispose()

                End If
            ElseIf Accion = 2 Then ' es una actualización

            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub PanelControl3_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl3.Paint

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmCatalogoCallCenter_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class