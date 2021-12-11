Public Class frmPpalComisionesCarteraVencida
    Private objDataSet As Data.DataSet
    'Private objDataSet1 As Data.DataSet 'Detalle
    Private Gestor As String



    Private Sub frmPpalComisionesCarteraVencida_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DEFechaIni.EditValue = DateSerial(Year(Date.Now), Month(Date.Now), 1)
        DEFechaFin.EditValue = Date.Now.ToShortDateString
        MostrarMensaje()
        RellenaGrid(" ", 1) 'GridPrincipal
        RellenaGrid(" ", 2)  'GridDetalle
    End Sub
    Private Sub MostrarMensaje()
        Dim UltimoDiaMes = DateSerial(Year(DEFechaFin.EditValue), Month(DEFechaFin.EditValue) + 1, 0)
        If UltimoDiaMes > DEFechaFin.EditValue Then
            LCMsj.Text = "AVANCE DEL MES"
        ElseIf UltimoDiaMes = DEFechaFin.EditValue Then
            LCMsj.Text = "RESULTADO FINAL DEL MES"
        End If
    End Sub

    Private Sub RellenaGrid(idgestor As String, opcion As Integer)

        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor

                objDataSet = objTrasp.usp_PpalComisionesCarteraVencida(DEFechaIni.EditValue, DEFechaFin.EditValue, glb_porcComision, idgestor, opcion)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If opcion = 1 Then
                        DGrid2.DataSource = Nothing
                        DGrid2.DataSource = objDataSet.Tables(0)
                    ElseIf opcion = 2 Then
                        DGrid1.DataSource = Nothing
                        DGrid1.DataSource = objDataSet.Tables(0)
                    End If

                    Me.Cursor = Cursors.Default

                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default
                GridView1.BestFitColumns()
                GridView2.BestFitColumns()
            Catch ExceptionErr As Exception

                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub frmPpalComisionesCarteraVencida_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs)
        'If DEFechaIni.Text <> "" And DEFechaFin.Text <> "" Then
        '    RellenaGrid()
        'End If

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click

        MostrarMensaje()
        RellenaGrid(" ", 1)
        RellenaGrid(" ", 2)

    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowClick
        Gestor = GridView2.GetRowCellValue(GridView2.GetSelectedRows()(0), "NOMBRE").ToString.Trim
        Dim idgestor = Gestor.Split("-")
        RellenaGrid(idgestor(0), 2)

    End Sub

    Private Sub DGrid2_Click(sender As Object, e As EventArgs) Handles DGrid2.Click
        RellenaGrid(" ", 2)
    End Sub

    Private Sub GridView2_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView2.SelectionChanged
        Gestor = GridView2.GetRowCellValue(GridView2.GetSelectedRows()(0), "NOMBRE").ToString.Trim
        Dim idgestor = Gestor.Split("-")
        RellenaGrid(idgestor(0), 2)
    End Sub
End Class