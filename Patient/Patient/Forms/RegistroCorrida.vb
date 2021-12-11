Public Class frmRegistroCorrida
    Dim marca As String
    Dim modelo As Integer
    Dim estilof As String
    Dim color As String
    Dim talla As Decimal
    Private Sub RegistroCorrida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMarca.Text = marca
        lblModelo.Text = modelo
        lblEstilof.Text = estilof
        lblColor.Text = color
        lblTalla.Text = talla
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If txtPeso.Text = "" Or txtAlto.Text = "" Or txtFondo.Text = "" Or txtFrente.Text = "" Or cbmatcalzado.Text = "" Or cbmatsuela.Text = "" Then
            MsgBox("Todos los campos son obligatorios!!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "ERROR")
        Else
            If MsgBox("Esta seguro de que desea guardar el articulo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Me.Close()
            Else

            End If
        End If
    End Sub
End Class