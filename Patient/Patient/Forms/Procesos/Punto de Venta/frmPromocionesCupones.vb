Public Class frmPromocionesCupones

    Public IdPromocion As Integer

#Region "Metodos"
    Private Sub RellenaGrids()
        Dim objDataSet As New DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerCuponesPromocion(IdPromocion, "DISPONIBLES")
            gc_Disponibles.DataSource = objDataSet.Tables(0)
            objDataSet = objPromociones.usp_TraerCuponesPromocion(IdPromocion, "AGREGADOS")
            gc_Agregados.DataSource = objDataSet.Tables(0)
        End Using
    End Sub
#End Region

#Region "Eventos"
    Private Sub frmBuscarCupones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RellenaGrids()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        Try
            If dgv_Disponibles.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_CapturaPromocionCupon(IdPromocion, CInt(dgv_Disponibles.GetRowCellValue(dgv_Disponibles.FocusedRowHandle, "idcupon")), GLB_Usuario)
            End Using
            RellenaGrids()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Quitar_Click(sender As Object, e As EventArgs) Handles btn_Quitar.Click
        Try
            If dgv_Agregados.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_EliminaPromocionCupon(IdPromocion, CInt(dgv_Agregados.GetRowCellValue(dgv_Agregados.FocusedRowHandle, "idcupon")))
            End Using
            RellenaGrids()
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