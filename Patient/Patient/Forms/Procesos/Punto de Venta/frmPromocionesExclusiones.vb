Imports DevExpress.XtraEditors

Public Class frmPromocionesExclusiones

    Public IdPromocion As Integer

#Region "Metodos"

    Private Sub TraerPromocionesExclusiones()
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionesExclusiones(IdPromocion)
        End Using
        gc_Exclusiones.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Exclusiones.DataSource = objDataSet.Tables(0)
            InicializaGridExclusiones()
        End If
    End Sub

    Private Sub InicializaGridExclusiones()
        dgv_Exclusiones.BestFitColumns()
        dgv_Exclusiones.Columns("idpromocion").Visible = False

        dgv_Exclusiones.Columns("marca").Caption = "Marca"
        dgv_Exclusiones.Columns("estilon").Caption = "Estilo"
        dgv_Exclusiones.Columns("idusuario").Caption = "Usuario"
        dgv_Exclusiones.Columns("fum").Caption = "FUM"

        dgv_Exclusiones.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextEdit, ByVal Txt_Campo1 As TextEdit, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                Dim objDataSet As DataSet
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

#End Region

#Region "Eventos"
    Private Sub frmPromocionesExclusiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TraerPromocionesExclusiones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            If txt_Marca.Text.Trim = "" Then
                MessageBox.Show("Debes agregar una marca", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_CapturaPromocionesExclusiones(IdPromocion, txt_Marca.Text.Trim, txt_Estilo.Text, GLB_Usuario)
            End Using
            MessageBox.Show("Se almaceno la exclusión correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txt_Marca.Text = ""
            txt_Estilo.Text = ""
            TraerPromocionesExclusiones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        Try
            If dgv_Exclusiones.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas eliminar la exclusión seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_EliminaPromocionExclusion(IdPromocion, dgv_Exclusiones.GetRowCellValue(dgv_Exclusiones.FocusedRowHandle, "marca"), dgv_Exclusiones.GetRowCellValue(dgv_Exclusiones.FocusedRowHandle, "estilon"))
            End Using
            MessageBox.Show("Se elimino la exclusión correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerPromocionesExclusiones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub txt_Marca_LostFocus(sender As Object, e As EventArgs) Handles txt_Marca.LostFocus
        If txt_Marca.Text.Trim = "" Then Exit Sub
        Try
            Call TxtLostfocus(txt_Marca, txt_NomMarca, "M")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Estilo_LostFocus(sender As Object, e As EventArgs) Handles txt_Estilo.LostFocus
        Try
            If txt_Estilo.Text.Trim = "" Then Exit Sub
            txt_Estilo.Text = pub_RellenarEspaciosIzquierda(txt_Estilo.Text.Trim, 7)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region
End Class