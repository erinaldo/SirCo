Public Class frmPpalNegPropuestaVendido
    Private objDataSet As Data.DataSet

    Private Sub RellenaGrid()

        Using objTrasp As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalNegPropuestaVendido(DEFechaIni.EditValue, DEFechaFin.EditValue)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = objDataSet.Tables(0)
                    'InicializaGrid()
                    GridView2.BestFitColumns()

                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If

                Me.Cursor = Cursors.Default

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs)
        RellenaGrid()
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalBitacoraPedBod_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmPpalBitacoraPedBod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dia = Date.Now.DayOfWeek
        DEFechaFin.EditValue = Date.Now.ToShortDateString
        DEFechaIni.EditValue = Date.Now.AddDays(-(dia - 1))

        RellenaGrid()
    End Sub

    Sub InicializaGrid()
        Try


            GridView2.Columns(0).Caption = "Sucursal"
            GridView2.Columns(1).Caption = "Id Empleado"
            GridView2.Columns(2).Caption = "Nombre"
            GridView2.Columns(3).Caption = "Sin Existencia"
            GridView2.Columns(4).Caption = "Propuestos"
            GridView2.Columns(5).Caption = "Vendidos"


            GridView2.OptionsView.ColumnAutoWidth = False

            For I As Integer = 0 To GridView2.Columns.Count - 1

                GridView2.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView2.Columns(I).AppearanceHeader.Font = New Font(GridView2.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView2.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView2.BestFitColumns()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click(sender As Object, e As EventArgs) Handles DGrid.Click

    End Sub

    Private Sub Btn_Refrescar_Click_1(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Salir_Click_1(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class