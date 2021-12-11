Public Class frmPromocionesAgrupaciones

    Public IdPromocion As Integer
    Public TipoPromo As String

#Region "Metodos"

#End Region

#Region "Eventos"
    Private Sub frmPromocionesAgrupaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If TipoPromo = "DIRECTA" Then
                gc_AgrupacionCompra.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            If TipoPromo = "DIRECTA" Then
                If txt_IdAgrupacionPromo.Text.Trim = "" Then
                    MessageBox.Show("Debes indicar una agrupación de Promoción", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_IdAgrupacionPromo.Focus()
                    Exit Sub
                End If
            Else
                If txt_IdAgrupacionCompra.Text.Trim = "" Then
                    MessageBox.Show("Debes indicar una agrupación de compra", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_IdAgrupacionCompra.Focus()
                    Exit Sub
                End If
                If txt_IdAgrupacionPromo.Text.Trim = "" Then
                    MessageBox.Show("Debes indicar una agrupación de Promoción", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_IdAgrupacionPromo.Focus()
                    Exit Sub
                End If
            End If
            Dim objDataSet As DataSet
            Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                Dim AgruCompra1 As Integer
                If TipoPromo = "DIRECTA" Then
                    AgruCompra1 = 0
                Else
                    AgruCompra1 = CInt(txt_IdAgrupacionCompra.Text)
                End If
                objDataSet = objPromocion.usp_BuscaPromocionAgrupacion(IdPromocion, AgruCompra1, CInt(txt_IdAgrupacionPromo.Text.Trim))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("La selección ingresada ya se encuentra almacenada en la promoción", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If MessageBox.Show("Estas seguro que deseas agregar la Agrupación a la promoción?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                Dim AgruCompra As Integer
                If TipoPromo = "DIRECTA" Then
                    AgruCompra = 0
                Else
                    AgruCompra = CInt(txt_IdAgrupacionCompra.Text)
                End If
                blnTransaccion = objPromocion.usp_CapturaPromocionAgrupacion(IdPromocion, AgruCompra, CInt(txt_IdAgrupacionPromo.Text), GLB_Usuario)
            End Using
            MessageBox.Show("Agrupación agregada a la promoción correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_BuscaAgruCompra_Click(sender As Object, e As EventArgs) Handles btn_BuscaAgruCompra.Click
        Try
            Dim myform As New frmBuscarAgrupacion
            myform.ShowDialog()
            If myform.Selecciono = True Then
                txt_IdAgrupacionCompra.Text = myform.IdAgrupacion
                txt_IdAgrupacionCompra_LostFocus(sender, e)
            Else
                txt_IdAgrupacionCompra.Text = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_BuscaAgruPromo_Click(sender As Object, e As EventArgs) Handles btn_BuscaAgruPromo.Click
        Try
            Dim myform As New frmBuscarAgrupacion
            myform.ShowDialog()
            If myform.Selecciono = True Then
                txt_IdAgrupacionPromo.Text = myform.IdAgrupacion
                txt_IdAgrupacionPromo_LostFocus(sender, e)
            Else
                txt_IdAgrupacionPromo.Text = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_IdAgrupacionCompra_LostFocus(sender As Object, e As EventArgs) Handles txt_IdAgrupacionCompra.LostFocus
        Try
            If txt_IdAgrupacionCompra.Text.Trim = "" Then
                txt_AgrupacionCompra.Text = ""
                Exit Sub
            End If
            Dim objDataSet As DataSet
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                objDataSet = objAgrupaciones.usp_TraerAgrupaciones(CInt(txt_IdAgrupacionCompra.Text), "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_AgrupacionCompra.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString.Trim
            Else
                MessageBox.Show("La agrupación ingresada no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_IdAgrupacionCompra.Text = ""
                txt_AgrupacionCompra.Text = ""
                txt_IdAgrupacionCompra.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_IdAgrupacionPromo_LostFocus(sender As Object, e As EventArgs) Handles txt_IdAgrupacionPromo.LostFocus
        Try
            If txt_IdAgrupacionPromo.Text.Trim = "" Then
                txt_AgrupacionPromo.Text = ""
                Exit Sub
            End If
            Dim objDataSet As DataSet
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                objDataSet = objAgrupaciones.usp_TraerAgrupaciones(CInt(txt_IdAgrupacionPromo.Text), "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_AgrupacionPromo.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString.Trim
            Else
                MessageBox.Show("La agrupación ingresada no existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_IdAgrupacionPromo.Text = ""
                txt_AgrupacionPromo.Text = ""
                txt_IdAgrupacionPromo.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region
End Class