Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalDescuentosXMes
    'vgallegos modificado el 23/Enero/2018 04:56 pm se agrego el componente dev express en el Grid
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As String = ""
    Dim SucurDesB As String = ""
    Dim Sucursal As String = ""
    Dim division As String = ""
    Dim marca As String = ""
    Dim estatus As String = ""

    Dim FechaFinB As String = "1900-01-01"
    Dim FechaIniB As String = "1900-01-01"
    Dim SucursalB As String = ""
    Dim IdDivisionb As String = ""

    Dim EstatusB As String = "1900-01-01"
    Dim TraspasoIniB As String = "1900-01-01"
    Dim TraspasoFinB As String = "1900-01-01"
    Dim Opcion As Integer = 1

    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel ko")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Reporte")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'Manuel vazquez, Paola Gonzales - 27/Enero/2017 - 10:15 a.m.
        Using objFalt As New BCL.BCLDescuentosXMes(GLB_ConStringCipSis)

            Try
                'Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                objDataSet = objFalt.usp_PpalDescuentosXMes(Opcion, FechaIniB, FechaFinB, Sucursal)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.DataSource = Nothing
                    GridView1.Columns.Clear()
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                Call LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()

            If Opcion = 1 Then


                'row(1) = "Total : "
                'row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                'dt.Rows.InsertAt(row, 0)
                'DGrid.DataSource = dt

                'DGrid.RowHeadersVisible = False
                'DGrid.Columns("sucursal").HeaderText = "Sucursal"
                'DGrid.Columns("descrip").HeaderText = "Descripcion"
                'DGrid.Columns("importetotal").HeaderText = "Total Importe"

                'DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("descrip").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("importetotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("importetotal").DefaultCellStyle.Format = "c"

                GridView1.Columns("sucursal").Caption = "Sucursal"
                GridView1.Columns("descrip").Caption = "Descripción"
                GridView1.Columns("importetotal").Caption = "Total Importe"

                GridView1.Columns("sucursal").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("descrip").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("importetotal").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("importetotal").GroupFormat.FormatString = "c"


                GridView1.Columns("importetotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns("importetotal").DisplayFormat.FormatString = "###,###,##0.00"



                ' CODIGO DE SUMA-------------------------
                GridView1.Columns("importetotal").SummaryItem.FieldName = "importetotal"
                GridView1.Columns("importetotal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GridView1.Columns("importetotal").SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"


            Else

                'row(1) = "Total : "
                'row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                'dt.Rows.InsertAt(row, 0)
                'DGrid.DataSource = dt

                GridView1.Columns("sucursal").Caption = "Sucursal"
                GridView1.Columns("descrip").Caption = "Descripción"
                GridView1.Columns("referenc").Caption = "Referencia"
                GridView1.Columns("fecha").Caption = "Fecha"
                GridView1.Columns("hora").Caption = "Hora"
                GridView1.Columns("importe").Caption = "Importe"
                GridView1.Columns("observa").Caption = "Observa"
                GridView1.Columns("cajero").Caption = "Cajero"
                GridView1.Columns("nombre").Caption = "Nombre"

                GridView1.Columns("sucursal").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("descrip").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("importe").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("referenc").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("fecha").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("hora").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("importe").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("importe").GroupFormat.FormatString = "c"
                GridView1.Columns("observa").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("cajero").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("nombre").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


                GridView1.Columns("importe").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                GridView1.Columns("importe").DisplayFormat.FormatString = "###,###,##0.00"

                'CODIGO SUMA---
                GridView1.Columns("importe").SummaryItem.FieldName = "importe"
                GridView1.Columns("importe").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GridView1.Columns("importe").SummaryItem.DisplayFormat = "{0:$###,###,##0.00}"

                'DGrid.Columns("sucursal").HeaderText = "Sucursal"
                'DGrid.Columns("descrip").HeaderText = "Descripcion"
                'DGrid.Columns("referenc").HeaderText = "Referencia"
                'DGrid.Columns("fecha").HeaderText = "Fecha"
                'DGrid.Columns("hora").HeaderText = "Hora"
                'DGrid.Columns("importe").HeaderText = "Importe"
                'DGrid.Columns("observa").HeaderText = "Observa"
                'DGrid.Columns("cajero").HeaderText = "Cajero"
                'DGrid.Columns("nombre").HeaderText = "Nombre"

                'DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("descrip").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("referenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("hora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("importe").DefaultCellStyle.Format = "c"
                'DGrid.Columns("observa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("cajero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DGrid.Columns("nombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            End If
            'GridView1.OptionsView = DataGridViewAutoSizeColumnsMode.AllCells

            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.ShowAutoFilterRow = True
            GridView1.OptionsView.ShowFooter = True



            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next
            GridView1.BestFitColumns()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    'Private Sub frmPpalPpalDetFactProv_|KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    'If (e.KeyCode = Keys.Escape) Then
    '    '    Me.Close()
    '    'End If
    'End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try

            Dim myForm As New frmFiltrosDescuentosPoMes

            If FechaIniB <> "1900-01-01" Then
                ' myForm.Chk_FechaTraspaso.Checked = True
                myForm.DTPicker2.Value = FechaIniB
                myForm.DTPicker3.Value = FechaFinB
            End If


            myForm.ShowDialog()


            ' If myForm.Chk_FechaTraspaso.Checked = True Then
            FechaIniB = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
            FechaFinB = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            'Else
            'FechaIniB = "1900-01-01"
            'FechaFinB = "1900-01-01"

            'End If


            If myForm.Sw_Filtro = True Then
                RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub frmPpalPpalTraspasosAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()

        FechaIniB = Format(Now.Add(New TimeSpan(-10, 0, 0, 0)), "yyyy-MM-dd")
        FechaFinB = Format(Now.Date, "yyyy-MM-dd")
        FechaIniB = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")

        FechaFinB = Format(Now.Date, "yyyy-MM-dd")
        Call RellenaGrid()
        Call LimpiarBusqueda()


    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim myForm As New frmReportsBrowser
            myForm.objDataSetDescuentosPorMes = GenerarDescuentosPorMes()
            If Opcion = 1 Then
                myForm.ReportIndex = 5526
            Else
                myForm.ReportIndex = 5527

            End If

            myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Public Function GenerarDescuentosPorMes() As DSDescuentosPorMes
        Try
            Dim cont As Integer = 0
            GenerarDescuentosPorMes = New DSDescuentosPorMes

            For i As Integer = 0 To GridView1.RowCount - 2
                Dim objDataRow1 As Data.DataRow = GenerarDescuentosPorMes.Tables("Tbl_DescuentosXMes").NewRow()
                If Opcion = 1 Then
                    cont = 0


                    objDataRow1.Item("sucursal") = GridView1.GetRowCellValue(i, "sucursal").ToString
                    objDataRow1.Item("descrip") = GridView1.GetRowCellValue(i, "descrip").ToString
                    objDataRow1.Item("importetotal") = GridView1.GetRowCellValue(i, "importetotal").ToString
                    'objDataRow1.Item("sucursal") = DGrid.Rows(i).Cells("sucursal").Value.ToString
                    'objDataRow1.Item("descrip") = DGrid.Rows(i).Cells("descrip").Value.ToString
                    'objDataRow1.Item("importetotal") = DGrid.Rows(i).Cells("importetotal").Value.ToString

                Else

                    cont = 0

                    objDataRow1.Item("sucursal") = GridView1.GetRowCellValue(i, "sucursal").ToString
                    objDataRow1.Item("descrip") = GridView1.GetRowCellValue(i, "descrip").ToString
                    objDataRow1.Item("referenc") = GridView1.GetRowCellValue(i, "referenc").ToString
                    objDataRow1.Item("fecha") = GridView1.GetRowCellValue(i, "fecha").ToString
                    objDataRow1.Item("hora") = GridView1.GetRowCellValue(i, "hora").ToString
                    objDataRow1.Item("importe") = GridView1.GetRowCellValue(i, "importe").ToString
                    objDataRow1.Item("observa") = GridView1.GetRowCellValue(i, "observa").ToString
                    objDataRow1.Item("cajero") = GridView1.GetRowCellValue(i, "cajero").ToString
                    objDataRow1.Item("nombre") = GridView1.GetRowCellValue(i, "nombre").ToString
                    'objDataRow1.Item("sucursal") = DGrid.Rows(i).Cells("sucursal").Value.ToString
                    'objDataRow1.Item("descrip") = DGrid.Rows(i).Cells("descrip").Value.ToString
                    'objDataRow1.Item("referenc") = DGrid.Rows(i).Cells("referenc").Value.ToString
                    'objDataRow1.Item("fecha") = DGrid.Rows(i).Cells("fecha").Value.ToString
                    'objDataRow1.Item("hora") = DGrid.Rows(i).Cells("hora").Value.ToString
                    'objDataRow1.Item("importe") = DGrid.Rows(i).Cells("importe").Value.ToString
                    'objDataRow1.Item("observa") = DGrid.Rows(i).Cells("observa").Value.ToString
                    'objDataRow1.Item("cajero") = DGrid.Rows(i).Cells("cajero").Value.ToString
                    'objDataRow1.Item("nombre") = DGrid.Rows(i).Cells("nombre").Value.ToString
                End If

                GenerarDescuentosPorMes.Tables("Tbl_DescuentosXMes").Rows.Add(objDataRow1)

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Function

    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Or GLB_CveSucursal = "15" Then
            SucursalB = GLB_CveSucursal
        Else
            SucursalB = ""
        End If


        PBox.Visible = False


    End Sub
    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_DoubleClick(sender As Object, e As EventArgs)
        Try

            If Opcion = 1 Then

                Opcion = 2
                If GridView1.GetFocusedRowCellValue(1) <> "Total : " Then
                    Sucursal = GridView1.GetFocusedRowCellValue("sucursal")
                Else
                    Sucursal = ""
                End If
                Btn_Regresar.Enabled = True

            ElseIf Opcion = 2 Then
                Opcion = 1
                Btn_Regresar.Enabled = False
            End If

            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Btn_Regresar_Click(sender As Object, e As EventArgs) Handles Btn_Regresar.Click
        Try
            If Btn_Regresar.Enabled = True Then

                Opcion = 1

                RellenaGrid()
                PBox.Image = Nothing
                PBox.Visible = False
                Btn_Regresar.Enabled = False
                blnEntraDet = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Sub DGrid_DoubleClick_2(sender As Object, e As EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 1 Then
                Opcion = 2
                Dim Renglon As Point = DGrid.PointToClient(Control.MousePosition)
                Dim info As GridHitInfo = GridView1.CalcHitInfo(Renglon)
                Dim Renglon1 As Integer = info.RowHandle

                Sucursal = GridView1.GetRowCellValue(Renglon1, "sucursal")
                Btn_Regresar.Enabled = True
            ElseIf Opcion = 2 Then
                Opcion = 1
                Btn_Regresar.Enabled = False
            End If

            Call RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub PBox_MouseUp_1(sender As Object, e As MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove_1(sender As Object, e As MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseDown_1(sender As Object, e As MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Click_1(sender As Object, e As EventArgs) Handles DGrid.Click

    End Sub
End Class