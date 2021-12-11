
Public Class frmFirmaPV
    'mreyes 27/Marzo/2019   11:22 a.m.
    Private Sub frmFirmaPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbl_Cajero.Text = GLB_Idempleado & " " & GLB_NomUsuario
        Txt_Sucursal.Text = GLB_CveSucursal & " " & GLB_Sucursal
    End Sub

    Private Sub usp_TraerVendedor()
        'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLMigracion(GLB_ConStringNominaSQL)
            Try
                If Txt_Vendedor.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerVendedor(Val(Txt_Vendedor.Text))
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_NombreVendedor.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString

                Else

                    MessageBox.Show("El vendedor no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Me.Controls(0).Name = "Txt_Vendedor"
                    Me.Controls(0).Focus()


                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Vendedor_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Vendedor.EditValueChanged

    End Sub

    Private Sub Cmd_Limpiar_Click(sender As Object, e As EventArgs) Handles Cmd_Limpiar.Click
        Try
            Txt_Vendedor.Text = ""
            Txt_Sucursal.Text = ""
            Txt_NombreVendedor.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class