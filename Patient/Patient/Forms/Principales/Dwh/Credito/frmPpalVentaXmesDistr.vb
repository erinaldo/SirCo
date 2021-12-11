Public Class frmPpalVentaXmesDistr
    Dim Sw_NoRegistros As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As String = ""
    Dim SucurDesB As String = ""
    Dim Sucursal As String = ""

    Dim FechaInib As String
    Dim FechaFinb As String
    Dim SucursalB As String = ""
    Dim año As String = ""

    Dim EstatusB As String = "1900-01-01"
    Dim TraspasoIniB As String = "1900-01-01"
    Dim TraspasoFinB As String = "1900-01-01"
    Dim Opcion As Integer

    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Private izquierda As Integer = 0
    Private alto As Integer = 0

    Private Sub GenerarToolTip()
        Try
            ' ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Reporte")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()

        DGrid.Visible = False
        Using obj As New BCL.BCLVentaPorMes(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.DataSource = Nothing
                objDataSet = obj.usp_PpalVentaPorMes(Txt_Ejercicio.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then



                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Sw_NoRegistros = True
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else
                    Me.Cursor = Cursors.Default
                    Sw_NoRegistros = False
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                Call LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
        DGrid.Visible = True

    End Sub

    Sub InicializaGrid()
        Try

            GridView1.Columns(0).Caption = "Distrib"
            GridView1.Columns(1).Caption = "Nombre"
            GridView1.Columns(2).Caption = "Fecha Alta"
            GridView1.Columns(3).Caption = "Estatus"
            GridView1.Columns(4).Caption = "Total"
            GridView1.Columns(5).Caption = "Enero"
            GridView1.Columns(6).Caption = "Febrero"
            GridView1.Columns(7).Caption = "Marzo"
            GridView1.Columns(8).Caption = "Abril"
            GridView1.Columns(9).Caption = "Mayo"
            GridView1.Columns(10).Caption = "Junio"
            GridView1.Columns(11).Caption = "Julio"
            GridView1.Columns(12).Caption = "Agosto"
            GridView1.Columns(13).Caption = "Septiembre"
            GridView1.Columns(14).Caption = "Octubre"
            GridView1.Columns(15).Caption = "Noviembre"
            GridView1.Columns(16).Caption = "Diciembre"



            For I As Integer = 0 To GridView1.Columns.Count - 1

                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True

            Next

            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.ShowAutoFilterRow = True
            GridView1.OptionsView.ShowFooter = True

            GridView1.BestFitColumns()


            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        'Try
        '    If ExportarDGridAExcel(DGrid) = False Then
        '        MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
        '    End If
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try
    End Sub

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmFiltrosEficienciaVend


            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaTraspaso.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If

            myForm.ShowDialog()


            If myForm.Chk_FechaTraspaso.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"

            End If



            If myForm.Sw_Filtro = True Then

                RellenaGrid()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmPpalPpalTraspasosAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call LimpiarBusqueda()
        FechaInib = Format(Now.Date, "yyyy-MM-dd")
        FechaFinb = Format(Now.Date, "yyyy-MM-dd")
        Txt_Ejercicio.Text = Year(Now.Date)
        Call RellenaGrid()
        Call GenerarToolTip()
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
            Dim myForm As New frmReportsBrowser
            myForm.objDataSetVentasPorMes = GenerarVentasPorMes()
            myForm.ReportIndex = 5525
            myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Public Function GenerarVentasPorMes() As DSVentasPorMes
        Try

            Dim cont As Integer = 0
            GenerarVentasPorMes = New DSVentasPorMes

            For i As Integer = 0 To GridView1.RowCount - 2

                cont = 0
                Dim objDataRow1 As Data.DataRow = GenerarVentasPorMes.Tables("Tbl_VentasPorMes").NewRow()
                objDataRow1.Item("Distrib") = GridView1.GetRowCellValue(i, "Distrib").ToString '
                objDataRow1.Item("nombre") = GridView1.GetRowCellValue(i, "Nombre").ToString
                objDataRow1.Item("fecalta") = GridView1.GetRowCellValue(i, "FECALTA").ToString
                objDataRow1.Item("estatus") = GridView1.GetRowCellValue(i, "Estatus").ToString
                objDataRow1.Item("total") = GridView1.GetRowCellValue(i, "Total").ToString
                objDataRow1.Item("Enero") = GridView1.GetRowCellValue(i, "Enero").ToString
                objDataRow1.Item("Febrero") = GridView1.GetRowCellValue(i, "Febrero").ToString
                objDataRow1.Item("Marzo") = GridView1.GetRowCellValue(i, "Marzo").ToString
                objDataRow1.Item("Abril") = GridView1.GetRowCellValue(i, "Abril").ToString
                objDataRow1.Item("Mayo") = GridView1.GetRowCellValue(i, "Mayo").ToString
                objDataRow1.Item("Junio") = GridView1.GetRowCellValue(i, "Junio").ToString
                objDataRow1.Item("Julio") = GridView1.GetRowCellValue(i, "Julio").ToString
                objDataRow1.Item("Agosto") = GridView1.GetRowCellValue(i, "Agosto").ToString
                objDataRow1.Item("Septiembre") = GridView1.GetRowCellValue(i, "Septiembre").ToString
                objDataRow1.Item("Octubre") = GridView1.GetRowCellValue(i, "Octubre").ToString
                objDataRow1.Item("Noviembre") = GridView1.GetRowCellValue(i, "Noviembre").ToString
                objDataRow1.Item("Diciembre") = GridView1.GetRowCellValue(i, "Diciembre").ToString


                GenerarVentasPorMes.Tables("Tbl_VentasPorMes").Rows.Add(objDataRow1)

                'Val(objDataRow1.Item("")=DGrid.Rows(i).Cells("").Value)

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

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        If Txt_Ejercicio.Text.Length = 4 Then
            año = Txt_Ejercicio.Text
        Else
            MessageBox.Show("Ingrese un año válido")
            Exit Sub
        End If

        RellenaGrid()

    End Sub

    Private Sub DGrid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)

    End Sub

    Private Sub frmPpalVentaXmesDistr_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        'If Sw_NoRegistros = True Then
        '    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
        '    DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        'End If
    End Sub


End Class