Public Class frmPpalEstadoCartera
    Private objDataSet As Data.DataSet
    Private Opcion As Integer = 1
    Private IdGestor As String = ""
    Private Sub frmPpalEstadoCartera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RellenaGrid()
        Catch ExceptionErr As Exception

            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        Using objVent As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try

                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                GridView1.Columns.Clear()
                objDataSet = objVent.usp_PpalEstadoCartera(Opcion, IdGestor)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    'Else
                    '    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

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
            GridView1.OptionsBehavior.Editable = False
            If Opcion = 1 Then
                GridView1.Columns("tipodistrib").Caption = " "
            ElseIf Opcion = 2 Then
                GridView1.Columns("idgestor").Visible = False
                GridView1.Columns("GESTOR").Caption = "Gestor"
            ElseIf Opcion = 3 Then
                GridView1.Columns("GESTOR").Caption = "Gestor"
                GridView1.Columns("distrib").Caption = "Distrib"
                GridView1.Columns("nombre").Caption = "Nombre"

            End If

            GridView1.Columns("porc").Caption = "%"
            GridView1.Columns("saldo").Caption = "Total"
            GridView1.Columns("capital").Caption = "Capital"
            GridView1.Columns("intereses").Caption = "Intereses"
            GridView1.Columns("cobranza").Caption = "Cobranza"


            GridView1.Columns("saldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("saldo").DisplayFormat.FormatString = "###,###,###"
            GridView1.Columns("capital").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("capital").DisplayFormat.FormatString = "###,###,###"
            GridView1.Columns("intereses").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("intereses").DisplayFormat.FormatString = "###,###,###"
            GridView1.Columns("cobranza").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("cobranza").DisplayFormat.FormatString = "###,###,###"

            GridView1.BestFitColumns()


            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.ShowAutoFilterRow = False
            GridView1.OptionsView.ShowFooter = True

            GridView1.Columns("saldo").SummaryItem.FieldName = "saldo"
            GridView1.Columns("saldo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("saldo").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
            GridView1.Columns("porc").SummaryItem.FieldName = "porc"
            GridView1.Columns("porc").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("porc").SummaryItem.DisplayFormat = "{0:###}"
            GridView1.Columns("capital").SummaryItem.FieldName = "capital"
            GridView1.Columns("capital").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("capital").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
            GridView1.Columns("intereses").SummaryItem.FieldName = "intereses"
            GridView1.Columns("intereses").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("intereses").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
            GridView1.Columns("cobranza").SummaryItem.FieldName = "cobranza"
            GridView1.Columns("cobranza").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("cobranza").SummaryItem.DisplayFormat = "{0:$###,###,##0}"
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Grid_DobleClick()
        Try

            If Opcion = 1 Then
                Opcion = 2
                RellenaGrid()
            ElseIf Opcion = 2 Then

                IdGestor = GridView1.GetFocusedRowCellValue("idgestor").ToString()
                Opcion = 3
                RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                DGrid.ExportToXls(sfdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmPpalEstadoCartera_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then

            Me.Close()
        End If
    End Sub

    Private Sub Btn_Regresar_Click(sender As Object, e As EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 3 Then
                Opcion = 2
                RellenaGrid()
            ElseIf Opcion = 2 Then
                Opcion = 1
                RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    ' Private obj As Object = Nothing
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try

            Dim ea As MouseEventArgs = TryCast(e, MouseEventArgs)
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitinfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(ea.Location)
            If hitinfo.InRowCell Then 'AndAlso hitinfo.Column Is OpCode Then

                'obj = view.GetRowCellValue(hitinfo.RowHandle, hitinfo.Column)
                ' System.Diagnostics.Debugger.Break()

                Grid_DobleClick()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub DGrid_Click(sender As Object, e As EventArgs) Handles DGrid.Click

    End Sub
End Class