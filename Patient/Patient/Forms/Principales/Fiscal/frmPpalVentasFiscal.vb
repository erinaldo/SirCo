Public Class frmPpalVentasFiscal
    Private objDataSet As Data.DataSet
    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub frmPpalVentasFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        RellenaGrid()
    End Sub
    Private Sub RellenaGrid()
        If DEFechaIni.Text = "" Or DEFechaFin.Text = "" Then Exit Sub
        Using objVent As New BCL.BCLTraerVentasFiscal(GLB_ConStringDwhSQL)

            Try

                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                objDataSet = objVent.usp_PpalVentasFiscal(DEFechaIni.EditValue, DEFechaFin.EditValue)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                Else
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If

                Me.Cursor = Cursors.Default

                GridView1.BestFitColumns()
            Catch ExceptionErr As Exception

                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub InicializaGrid()
        Try
            GridView1.Columns("Sucursal").Caption = "Sucursal"
        GridView1.Columns("Real").Caption = "Real"
        GridView1.Columns("Primer_Corte").Caption = "Fiscal Primer Corte"
        GridView1.Columns("Segundo_Corte").Caption = "Fiscal Segundo Corte"


        GridView1.Columns("Real").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns("Real").DisplayFormat.FormatString = "###,###,###"
        GridView1.Columns("Primer_Corte").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns("Primer_Corte").DisplayFormat.FormatString = "###,###,###"
        GridView1.Columns("Segundo_Corte").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        GridView1.Columns("Segundo_Corte").DisplayFormat.FormatString = "###,###,###"

        GridView1.BestFitColumns()


        For I As Integer = 0 To GridView1.Columns.Count - 1

            GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
            GridView1.Columns(I).OptionsColumn.ReadOnly = True

        Next
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView1.OptionsView.ShowAutoFilterRow = False
        GridView1.OptionsView.ShowFooter = True
        GridView1.OptionsView.ShowGroupPanel = False

        GridView1.Columns("Real").SummaryItem.FieldName = "Real"
        GridView1.Columns("Real").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Real").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
        GridView1.Columns("Primer_Corte").SummaryItem.FieldName = "Primer_Corte"
        GridView1.Columns("Primer_Corte").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        GridView1.Columns("Primer_Corte").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
        GridView1.Columns("Segundo_Corte").SummaryItem.FieldName = "Segundo_Corte"
        GridView1.Columns("Segundo_Corte").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("Segundo_Corte").SummaryItem.DisplayFormat = "{0:$###,###,##0}"

        Catch ExceptionErr As Exception

            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalVentasFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DEFechaIni.EditValue = Now.AddDays(-1)
            DEFechaFin.EditValue = Now.AddDays(-1)
            Call RellenaGrid()
        Catch ExceptionErr As Exception

            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class