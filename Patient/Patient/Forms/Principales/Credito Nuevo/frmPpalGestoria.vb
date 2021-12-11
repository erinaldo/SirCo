Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class frmPpalGestoria
    'mreyes     26/Octubre/201704:54 p.m.
    'tabla gestoria, ppalgestoria


    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False

    '-- filtros
    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""
    Public IdAgrupacion As Integer = 0

    Dim dt_totales_gestoria As New DataTable
    Dim corte_1t, corte_2t, corte_3t, corte_4t As Double
    Dim corte_1d, corte_2d, corte_3d, corte_4d As Double
    Dim tot_corte_1, tot_corte_2, tot_corte_3, tot_corte_4 As Double
    Dim footer_corte1, footer_corte2, footer_corte3, footer_corte4 As GridColumnSummaryItem

    Private Sub frmPpalVencidosDias_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalGestoria._usp_PpalGestoria' Puede moverla o quitarla según sea necesario.
        '  Me.Usp_PpalGestoriaTableAdapter.Fill(Me.Usp_PpalGestoria._usp_PpalGestoria)
        Sw_Load = True
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        dt_totales_gestoria.Columns.Add("tipo_distribuidor").DataType = System.Type.GetType("System.String")
        dt_totales_gestoria.Columns.Add("corte1").DataType = System.Type.GetType("System.String")
        dt_totales_gestoria.Columns.Add("corte2").DataType = System.Type.GetType("System.String")
        dt_totales_gestoria.Columns.Add("corte3").DataType = System.Type.GetType("System.String")
        dt_totales_gestoria.Columns.Add("corte4").DataType = System.Type.GetType("System.String")

        Call LimpiarBusqueda()

        Call RellenaGrid()
    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub GenerarToolTip()
        Try


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarBusqueda()

        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurOriB = GLB_CveSucursal
            ElseIf Opcion = 2 Then
                SucurOriB = GLB_CveSucursal
            End If
        Else
            SucurOriB = 0
            SucurDesB = 0
        End If

        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"


    End Sub

    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2017     04:55 p.m.

        tot_corte_1 = 0
        tot_corte_2 = 0
        tot_corte_3 = 0
        tot_corte_4 = 0

        DGrid1.Visible = False

        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalGestoria()

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid1.DataSource = objDataSet.Tables(0)

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("La información se esta actualizando, favor de esperar o intentarlo más tarde.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If

                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid1.Visible = True
                calcula_totales_gestoria()
                configura_totales()
                InicializaGrid(GridView1, 1)
                GridView1.BestFitColumns()

                InicializaGrid(GridView3, 2)
                totales_columnas(GridView3)
                GridView3.BestFitColumns()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid(gridview As GridView, id_gridview As Integer)
        'GridView1
        Try
            If (id_gridview = 1) Then
                If Chk_Direccion.Checked = True Then
                    gridview.Columns("Direccion").Visible = True
                    gridview.Columns("Campo2").Visible = True
                    gridview.Columns("Campo3").Visible = True
                    gridview.Columns("Telefono1").Visible = True
                    gridview.Columns("aval").Visible = True

                    gridview.Columns("Direccion").VisibleIndex = 10
                    gridview.Columns("Campo2").VisibleIndex = 11
                    gridview.Columns("Campo3").VisibleIndex = 12
                    gridview.Columns("Telefono1").VisibleIndex = 13
                    gridview.Columns("aval").VisibleIndex = 14
                Else
                    gridview.Columns("Direccion").Visible = False
                    gridview.Columns("Campo2").Visible = False
                    gridview.Columns("Campo3").Visible = False
                    gridview.Columns("Telefono1").Visible = False
                    gridview.Columns("aval").Visible = False
                End If
            ElseIf id_gridview = 2 Then
                gridview.Columns("tipo_distribuidor").Caption = "Clasificación"
                gridview.Columns("corte1").Caption = "Corte1"
                gridview.Columns("corte2").Caption = "Corte2"
                gridview.Columns("corte3").Caption = "Corte3"
                gridview.Columns("corte4").Caption = "Corte4"

                gridview.Columns("tipo_distribuidor").Fixed = Columns.FixedStyle.Left

                For i As Integer = 1 To 4 Step 1
                    gridview.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    gridview.Columns(i).OptionsColumn.ReadOnly = True
                Next
            End If

            gridview.OptionsView.ColumnAutoWidth = False
            gridview.OptionsView.ShowAutoFilterRow = False
            gridview.OptionsView.ShowFooter = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Private Sub totales_columnas(gridview As Views.Grid.GridView)
        Try
            footer_corte1 = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte1", "$" + Format(Math.Round(tot_corte_1), "##,##0"))
            footer_corte2 = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte2", "$" + Format(Math.Round(tot_corte_2), "##,##0"))
            footer_corte3 = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte3", "$" + Format(Math.Round(tot_corte_3), "##,##0"))
            footer_corte4 = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte4", "$" + Format(Math.Round(tot_corte_4), "##,##0"))

            gridview.Columns("corte1").Summary.Clear()
            gridview.Columns("corte2").Summary.Clear()
            gridview.Columns("corte3").Summary.Clear()
            gridview.Columns("corte4").Summary.Clear()

            gridview.Columns("corte1").Summary.Add(footer_corte1)
            gridview.Columns("corte2").Summary.Add(footer_corte2)
            gridview.Columns("corte3").Summary.Add(footer_corte3)
            gridview.Columns("corte4").Summary.Add(footer_corte4)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click
        ' DGrid1.ExportToPdf("c:\equis.pdf")
        'DGrid1.ExportToHtml("c:\prueba.htm")

        'mreyes 24/Julio/2017   11:51 a.m.
        Dim myForm1 As New frmReportsBrowser

        myForm1.objDataSetPpalVencidoDias = GenerarReporteVencidoDias()
        '  myForm1.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
        myForm1.Text = "Listado de Saldos Vencidos con Dirección"
        myForm1.ReportIndex = 6001
        myForm1.Show()

        Dim myForm As New frmReportsBrowser

        myForm.objDataSetPpalVencidoDias = GenerarReporteVencidoDias()
        ' myForm.objDataSetPpalVencidoDireccion = myForm.objDataSetPpalVencidoDias.Copy
        'myForm.r_Titulo = "Fecha Vencido :" & Format(DateEdit1.EditValue, "dd/MM/yyyy")
        myForm.Text = "Listado de Saldos Vencidos"
        myForm.ReportIndex = 6000
        myForm.Show()





    End Sub

    Private Function GenerarReporteVencidoDias() As DSVencidoDias
        'mreyes 24/Julio/2017   11:50 a.m.
        Try
            GenerarReporteVencidoDias = New DSVencidoDias
            With GridView1
                For I As Integer = 0 To .RowCount - 1

                    Dim objDataRow As Data.DataRow = GenerarReporteVencidoDias.Tables(0).NewRow()
                    objDataRow.Item("Distrib") = .GetRowCellValue(I, "Distrib").ToString.Trim
                    objDataRow.Item("Nombre") = .GetRowCellValue(I, "Nombre").ToString.Trim
                    objDataRow.Item("status") = .GetRowCellValue(I, "status").ToString.Trim
                    objDataRow.Item("frecuen") = .GetRowCellValue(I, "frecuen").ToString.Trim
                    objDataRow.Item("direccion") = .GetRowCellValue(I, "Direccion").ToString.Trim
                    objDataRow.Item("Telefono1") = .GetRowCellValue(I, "Telefono1").ToString.Trim
                    objDataRow.Item("Aval") = .GetRowCellValue(I, "aval").ToString.Trim
                    objDataRow.Item("Compras") = Val(.GetRowCellValue(I, "compras").ToString)
                    objDataRow.Item("porpagar") = Val(.GetRowCellValue(I, "porpagar").ToString)
                    objDataRow.Item("vencido") = Val(.GetRowCellValue(I, "vencido").ToString)
                    objDataRow.Item("dias_14") = Val(.GetRowCellValue(I, "dias_14").ToString)
                    objDataRow.Item("dias_29") = Val(.GetRowCellValue(I, "dias_29").ToString)
                    objDataRow.Item("dias_44") = Val(.GetRowCellValue(I, "dias_44").ToString)
                    objDataRow.Item("dias_59") = Val(.GetRowCellValue(I, "dias_59").ToString)
                    objDataRow.Item("dias_60") = Val(.GetRowCellValue(I, "dias_60").ToString)
                    objDataRow.Item("ultpago") = Val(.GetRowCellValue(I, "ultpago").ToString)
                    objDataRow.Item("ultfechapago") = Format(CDate(.GetRowCellValue(I, "ultfechapago").ToString.Trim), "dd/MM/yyyy")
                    '        objDataRow.Item("ultfechapago") = .GetRowCellValue(I, "ultfechapago").ToString.Trim
                    objDataRow.Item("campo1") = .GetRowCellValue(I, "Campo1").ToString.Trim
                    objDataRow.Item("campo2") = Val(.GetRowCellValue(I, "Campo2").ToString)
                    objDataRow.Item("campo3") = .GetRowCellValue(I, "Campo3").ToString.Trim
                    objDataRow.Item("campo4") = .GetRowCellValue(I, "Campo4").ToString.Trim
                    objDataRow.Item("campo5") = .GetRowCellValue(I, "Campo5").ToString.Trim




                    GenerarReporteVencidoDias.Tables(0).Rows.Add(objDataRow)
                Next

            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs)
        If Sw_Load = False Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DateEdit1_LostFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub UspPpalGestoriaBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles UspPpalGestoriaBindingSource.CurrentChanged

    End Sub

    Private Sub frmPpalVencidosDias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub Btn_FTP_Click(sender As Object, e As EventArgs) Handles Btn_FTP.Click
        My.Computer.Network.UploadFile("c:\gestoria.xls", "ftp://home587140532.1and1-data.host/gestoria.xls", "u81839252-credito", "ZT_Sirco33")
    End Sub

    Private Sub Chk_Direccion_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Direccion.CheckedChanged
        GridView1.BestFitColumns()
        If Chk_Direccion.Checked = True Then
            GridView1.Columns("Direccion").Visible = True
            GridView1.Columns("Campo2").Visible = True
            GridView1.Columns("Campo3").Visible = True
            GridView1.Columns("Telefono1").Visible = True
            GridView1.Columns("aval").Visible = True

            GridView1.Columns("Direccion").VisibleIndex = 10
            GridView1.Columns("Campo2").VisibleIndex = 11
            GridView1.Columns("Campo3").VisibleIndex = 12
            GridView1.Columns("Telefono1").VisibleIndex = 13
            GridView1.Columns("aval").VisibleIndex = 14

        Else


            GridView1.Columns("Direccion").Visible = False
            GridView1.Columns("Campo2").Visible = False
            GridView1.Columns("Campo3").Visible = False
            GridView1.Columns("Telefono1").Visible = False
            GridView1.Columns("aval").Visible = False
        End If
    End Sub

    Private Sub Btn_Asignar_Click(sender As Object, e As EventArgs) Handles Btn_Asignar.Click
        Try
            Dim Idempleado As Integer = 0
            Dim Gestor As String = ""
            Dim myForm As New frmConsultaEmpleado

            myForm.Text = "Gestores"
            myForm.Estatus = "A"
            myForm.Pnl_Edicion.Visible = False
            myForm.Height = 200
            myForm.IdDepto = 5
            myForm.IdPuesto = 30



            myForm.ShowDialog()
            Idempleado = Val(myForm.Campo)
            Gestor = Idempleado & "-" & myForm.Campo1

            Dim Corte1 As Decimal = 0
            Dim Corte2 As Decimal = 0
            Dim Corte3 As Decimal = 0
            Dim Corte4 As Decimal = 0
            Dim Corten As Decimal = 0
            Dim Vencido As Decimal = 0
            Dim UltPAgo As Decimal = 0
            Dim Ultfechapago As Date
            Dim Distrib As String = ""


            '''----
            Dim Rows As New ArrayList()
            ' Add the selected rows to the list.
            Dim I As Integer
            For I = 0 To GridView1.SelectedRowsCount() - 1
                If (GridView1.GetSelectedRows()(I) >= 0) Then
                    GridView1.SetRowCellValue(GridView1.GetSelectedRows()(I), "Campo4", Gestor)
                    Corte1 = GridView1.GetRowCellValue(I, "corte1").ToString.Trim
                    Corte2 = GridView1.GetRowCellValue(I, "corte2").ToString.Trim
                    Corte3 = GridView1.GetRowCellValue(I, "corte3").ToString.Trim
                    Distrib = GridView1.GetRowCellValue(I, "distrib").ToString.Trim



                    GridView1.SetRowCellValue(I, "Campo4", Gestor)
                    Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        If objTrasp.usp_Captura_GestoriaAsignada(1, Idempleado, Distrib, Corte1, Corte2, Corte3, Corte4, Corten, Vencido, UltPAgo, Ultfechapago, GLB_Idempleado) Then

                        End If
                    End Using



                End If
            Next

            '' Guardar el gestor asignado, por la fecha.


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub configura_totales()
        Try
            dt_totales_gestoria.Rows.Clear()

            Dim Rd As DataRow = dt_totales_gestoria.NewRow
            Rd("tipo_distribuidor") = "DISTRIBUIDOR"
            Rd("corte1") = "$" + Format(corte_1d, "##,##0.00")
            Rd("corte2") = "$" + Format(corte_2d, "##,##0.00")
            Rd("corte3") = "$" + Format(corte_3d, "##,##0.00")
            Rd("corte4") = "$" + Format(corte_4d, "##,##0.00")
            dt_totales_gestoria.Rows.Add(Rd)

            Dim Rt As DataRow = dt_totales_gestoria.NewRow
            Rt("tipo_distribuidor") = "TARJETAHABIENTE"
            Rt("corte1") = "$" + Format(corte_1t, "##,##0.00")
            Rt("corte2") = "$" + Format(corte_2t, "##,##0.00")
            Rt("corte3") = "$" + Format(corte_3t, "##,##0.00")
            Rt("corte4") = "$" + Format(corte_4t, "##,##0.00")
            dt_totales_gestoria.Rows.Add(Rt)

            DGrid3.DataSource = dt_totales_gestoria
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub calcula_totales_gestoria()
        Try
            corte_1t = 0
            corte_2t = 0
            corte_3t = 0
            corte_4t = 0
            corte_1d = 0
            corte_2d = 0
            corte_3d = 0
            corte_4d = 0

            For Each row As DataRow In objDataSet.Tables(0).Rows
                If (CStr(row("clasificacion")).ToUpper() = "TARJETAHABIENTE") Then
                    corte_1t = corte_1t + CDbl(row("corte1"))
                    corte_2t = corte_2t + CDbl(row("corte2"))
                    corte_3t = corte_3t + CDbl(row("corte3"))
                    corte_4t = corte_4t + CDbl(row("Campo5"))
                Else
                    corte_1d = corte_1d + CDbl(row("corte1"))
                    corte_2d = corte_2d + CDbl(row("corte2"))
                    corte_3d = corte_3d + CDbl(row("corte3"))
                    corte_4d = corte_4d + CDbl(row("Campo5"))
                End If

                tot_corte_1 = tot_corte_1 + CDbl(row("corte1"))
                tot_corte_2 = tot_corte_2 + CDbl(row("corte2"))
                tot_corte_3 = tot_corte_3 + CDbl(row("corte3"))
                tot_corte_4 = tot_corte_4 + CDbl(row("Campo5"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Function valida_cifra(cifra As String) As Double
        Try
            If String.IsNullOrEmpty(cifra) Then
                Return 0
            Else
                Return CDbl(cifra)
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                e.Appearance.ForeColor = Color.Black

                Dim clasificacion As String = Mid((View.GetRowCellDisplayText(e.RowHandle, View.Columns("clasificacion"))), 1, 1)
                If clasificacion = "T" Then
                    e.Appearance.BackColor = Color.PaleGreen
                    e.Appearance.BackColor2 = Color.SeaShell
                    e.Appearance.BorderColor = Color.White
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class