Imports DevExpress.XtraEditors.TextEdit
Imports DevExpress.XtraGrid.Views.Grid


Public Class frmPpalParesUnicos
    Public FechaIni1 As Date = "1900-01-01"
    Public FechaFin1 As Date = "1900-01-01"
    Public FechaIni As Date = "1900-01-01"
    Public FechaFin As Date = "1900-01-01"
    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs)
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub frmPpalParesUnicos_Load(sender As Object, e As EventArgs) Handles Me.Load
        DEFechaIni.EditValue = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        DEFechaFin.EditValue = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")


        FechaIni = DEFechaIni.EditValue
        FechaFin = DEFechaFin.EditValue

        ' acumuladas
        FechaIni1 = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")
        FechaFin1 = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")


        Call RellenaGrid()
    End Sub

    Private Sub RellenaGrid()
        Dim objDataSet As Data.DataSet

        FechaIni = DEFechaIni.EditValue
        FechaFin = DEFechaFin.EditValue

        FechaIni1 = Format(DateSerial(FechaIni.Year, FechaIni.Month, 1), "yyyy-MM-dd")
        FechaFin1 = DEFechaFin.EditValue


        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringDwhSQL)

            Try

                Me.Cursor = Cursors.WaitCursor
                DGrid1.DataSource = Nothing
                objDataSet = objTrasp.usp_PpalParesUnicos(FechaIni1, FechaFin1, FechaIni, FechaFin)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    DGrid1.DataSource = objDataSet.Tables(0)
                    Call InicializaGrid()
                    Me.Cursor = Cursors.Default

                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default

                GridView1.BestFitColumns()
            Catch ExceptionErr As Exception

                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try


            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(1).AppearanceHeader.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)

            GridView1.Columns(0).Visible = False
            GridView1.Columns(1).Caption = "Det"
            GridView1.Columns(2).Caption = "Sucursal"
            GridView1.Columns(3).Caption = "Día"
            GridView1.Columns(4).Caption = "Acumulado"

            GridView1.Columns(3).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(3).DisplayFormat.FormatString = "#,###,###"
            GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns(4).DisplayFormat.FormatString = "#,###,###"
            GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center





            ' Call Colorear()
            GridView1.FixedLineWidth = 4
            GridView1.Columns(0).Fixed = 0
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub frmPpalParesUnicos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class