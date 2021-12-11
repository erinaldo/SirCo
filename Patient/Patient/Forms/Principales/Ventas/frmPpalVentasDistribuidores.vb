Public Class frmPpalVentasDistribuidores
    'Tony García - 01/Junio/2013 12:30 p.m.

    Private objDataSet As Data.DataSet 'Primer Nivel 
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Private objDataSet2 As Data.DataSet 'Tercer Nivel

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False

    Dim DistribuidorIniB As String
    Dim DistribuidorFinB As String
    Dim SucursalB As String
    Dim EstatusB As String

    Dim Opcion As Integer = 1
    Dim blnPrimero As Boolean = False

    Private FechaInicio As String
    Private FechaFin As String
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""

    Private Sub frmPpalNumValesPorNegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Opcion = 1 Then
            Btn_Regresar.Enabled = False
        End If
        Call LimpiarBusqueda()
        Lbl_RangoFechas.Text = "Periodo:  " + Format(CDate(FechaInicio), "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(CDate(FechaFin), "dd-MMM-yyyy").ToString.ToUpper
        Call RellenaGrid()
        'Sw_Pintar = True

        'Sw_Load = False 
    End Sub

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    'Método LimpiarBusqueda
    Private Sub LimpiarBusqueda()
        FechaInicio = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        FechaFin = Format(Now.Add(New TimeSpan(-1, 0, 0, 0)), "yyyy-MM-dd")
        DistribuidorIniB = ""
        DistribuidorFinB = ""
        EstatusB = ""
        SucursalB = ""
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 17/Enero/2013 
        Using objVentasDistrib As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)

            Try

                Me.Cursor = Cursors.WaitCursor

                DGrid.DataSource = Nothing

                'If objDataSet.Tables(0).Rows.Count = 0 Then
                If Opcion = 1 Then
                    objDataSet = objVentasDistrib.usp_PpalVentasDistrib(DistribuidorIniB, DistribuidorFinB, SucursalB, EstatusB, FechaInicio, FechaFin)
                End If
                'End If

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    If Opcion = 1 Then
                        DGrid.DataSource = objDataSet.Tables(0)
                    ElseIf Opcion = 2 Then
                        DGrid.DataSource = objDataSet1.Tables(0)
                    End If

                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    'MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Public Function pub_SumaRenglonGrid(ByVal DGrid As DataGridView, ByVal Renglon As Integer, Optional ByVal HastaColumna As Integer = 0) As Decimal
        Try
            If objDataSet.Tables(0).Rows.Count > 0 Then
                'Dim row As Integer = DGrid.CurrentRow.Index

                For i As Integer = 0 To DGrid.Rows.Count - 2
                    pub_SumaRenglonGrid = 0
                    For col As Integer = 6 To DGrid.ColumnCount - 3
                        'If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value > 0) Then
                        If DGrid.Rows(i).Cells(col).Value > 0 Then
                            pub_SumaRenglonGrid = (Val(DGrid.Rows(i).Cells(col).Value)) + pub_SumaRenglonGrid
                        End If
                        'If DGrid.Rows(Renglon).Cells(col).Value < 0 Then
                        '    pub_SumaRenglonGrid = pub_SumaRenglonGrid + DGrid.Rows(Renglon).Cells(col).Value
                        'End If
                    Next

                    objDataSet.Tables(0).Rows(i).Item("total") = Val(pub_SumaRenglonGrid)
                Next
                
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Sub InicializaGrid()

        Try

            If Opcion = 1 Then 'Principal Ventas Distribuidor

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                'Dim dtEnc As New DataTable
                'Dim dtFinal As New DataTable

                'YA ESTABA COMENTADO
                'dtEnc.Columns.Add("Distribuidor", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("Fecha Alta", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("Estatus", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("Fechaa", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("2mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("3mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("4mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("5mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("6mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("7mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("8mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("9mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("10mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("20mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("30mil", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("30milmas", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("distrib", System.Type.GetType("System.String"))
                'dtEnc.Columns.Add("total", System.Type.GetType("System.String"))

                Dim row As DataRow = dt.NewRow()
                'Dim rowEncabezados As DataRow = dt.NewRow() 'YA ESTABA COMENTADO

                row(0) = " "
                'row(6) = pub_SumaColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                'row(7) = pub_SumaColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                'row(8) = pub_SumaColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                'row(9) = pub_SumaColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                'row(10) = pub_SumaColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                'row(11) = pub_SumaColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                'row(12) = pub_SumaColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                'row(13) = pub_SumaColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                'row(14) = pub_SumaColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                'row(15) = pub_SumaColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                'row(16) = pub_SumaColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                'row(17) = pub_SumaColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                'row(18) = pub_SumaColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                'row(19) = CDec(0.0)
                'row(20) = CDec(0.0)

                If objDataSet.Tables(0).Rows.Count > 1 Then
                    dt.Rows.InsertAt(row, 0)
                End If

                DGrid.DataSource = dt

                'pub_SumaRenglonGrid(DGrid, 0, DGrid.ColumnCount - 1)*************************

                GridView1.Columns("total").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

                GridView1.Columns(0).Caption = "Distribuidor"
                GridView1.Columns(1).Caption = "Fecha Alta"
                GridView1.Columns(2).Caption = "Estatus"
                GridView1.Columns(3).Caption = "Límite Crédito"
                GridView1.Columns(4).Caption = "Saldo"
                GridView1.Columns(5).Caption = "Fecha" 'oculto
                GridView1.Columns(6).Caption = "$1,000.00" '*
                GridView1.Columns(7).Caption = "$2,000.00"
                GridView1.Columns(8).Caption = "$3,000.00"
                GridView1.Columns(9).Caption = "$4,000.00"
                GridView1.Columns(10).Caption = "$5,000.00"
                GridView1.Columns(11).Caption = "$6,000.00"
                GridView1.Columns(12).Caption = "$7,000.00"
                GridView1.Columns(13).Caption = "$8,000.00"
                GridView1.Columns(14).Caption = "$9,000.00"
                GridView1.Columns(15).Caption = "$10,000.00"
                GridView1.Columns(16).Caption = "$20,000.00"
                GridView1.Columns(17).Caption = "$30,000.00"
                GridView1.Columns(18).Caption = "$30,000.00 +"
                GridView1.Columns(19).Caption = "Distrib"
                GridView1.Columns(20).Caption = "Total General" '*

                GridView1.Columns(5).Visible = False
                GridView1.Columns(19).Visible = False

                'GridView1.Columns(20).DisplayIndex = 6 ******************************************

                'DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                GridView1.Columns(0).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(9).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(10).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(11).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(12).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(13).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(14).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(15).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(16).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(17).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(18).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(19).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(20).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far


                GridView1.Columns(3).DisplayFormat.FormatType = "c"
                GridView1.Columns(4).DisplayFormat.FormatType = "c"
                GridView1.Columns(5).DisplayFormat.FormatType = "c"
                GridView1.Columns(6).DisplayFormat.FormatType = "c"
                GridView1.Columns(7).DisplayFormat.FormatType = "c"
                GridView1.Columns(8).DisplayFormat.FormatType = "c"
                GridView1.Columns(9).DisplayFormat.FormatType = "c"
                GridView1.Columns(10).DisplayFormat.FormatType = "c"
                GridView1.Columns(11).DisplayFormat.FormatType = "c"
                GridView1.Columns(12).DisplayFormat.FormatType = "c"
                GridView1.Columns(13).DisplayFormat.FormatType = "c"
                GridView1.Columns(14).DisplayFormat.FormatType = "c"
                GridView1.Columns(15).DisplayFormat.FormatType = "c"
                GridView1.Columns(16).DisplayFormat.FormatType = "c"
                GridView1.Columns(18).DisplayFormat.FormatType = "c"
                GridView1.Columns(20).DisplayFormat.FormatType = "c"


                If GridView1.GetRowCellValue(0, "distribuidor") = " " Then 'If DGrid.Rows(0).Cells("distribuidor").Value = " " Then
                    'DGrid.Rows(0).Frozen = True 'DESCOMENTAR DESPUES 
                End If

                '*************************************************
                'DGrid.Columns(0).Frozen = True
                'DGrid.Columns(1).Frozen = True
                'DGrid.Columns(2).Frozen = True
                'DGrid.Columns(3).Frozen = True
                'DGrid.Columns(4).Frozen = True
                'DGrid.Columns(20).Frozen = True


                GridView1.Focus()
                'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue '*****************************************************
                'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight'*****************************************************
                'DGrid.Rows(0).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter'*****************************************************

                'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)'*************


                GridView1.Columns(0).AppearanceCell.BackColor = Color.PowderBlue
                GridView1.Columns(1).AppearanceCell.BackColor = Color.PowderBlue
                GridView1.Columns(2).AppearanceCell.BackColor = Color.PowderBlue
                GridView1.Columns(3).AppearanceCell.BackColor = Color.PowderBlue
                GridView1.Columns(4).AppearanceCell.BackColor = Color.PowderBlue
                GridView1.Columns(20).AppearanceCell.BackColor = Color.PowderBlue
                'DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue

                GridView1.Columns(0).AppearanceCell.Font = New Font(GridView1.Columns(0).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(1).AppearanceCell.Font = New Font(GridView1.Columns(1).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(2).AppearanceCell.Font = New Font(GridView1.Columns(2).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(3).AppearanceCell.Font = New Font(GridView1.Columns(3).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(4).AppearanceCell.Font = New Font(GridView1.Columns(4).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(20).AppearanceCell.Font = New Font(GridView1.Columns(20).AppearanceCell.Font, FontStyle.Bold)
                'DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                GridView1.OptionsView.ColumnAutoWidth = False
                GridView1.OptionsView.BestFitMaxRowCount = -1
                GridView1.BestFitColumns()
                'Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


                'GridView1.OptionsView.RowAutoHeight = True                

                'YA ESTABA COMENTADO

                'For i As Integer = 1 To DGrid.Rows.Count - 2
                '    For j As Integer = 4 To DGrid.Columns.Count - 1
                '        If DGrid.Rows(i).Cells(j).Value = 0 Then
                '            DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White
                '        End If
                '    Next
                'Next


                'For k As Integer = 1 To DGrid.Rows.Count - 2
                '    For l As Integer = 18 To 18
                '        If DGrid.Rows(k).Cells(l).Value = 0 Then
                '            DGrid.Rows(k).Cells(l).Style.ForeColor = Color.PowderBlue
                '        End If
                '    Next
                'Next


            ElseIf Opcion = 2 Then  'Detalle de Cargo - Ventas Distribuidor

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row(7) = " "

                'row(9) = pub_SumaColumnaGrid(DGrid, 9, GridView1.RowCount - 1) '*****************************************************

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt


                ' DGrid.RowHeadersVisible = False '*****************************************************
                'DGrid.Columns(0).HeaderText = "Sucursal"
                GridView1.Columns(0).Caption = "sucursal"
                GridView1.Columns(1).Caption = "Nota"
                GridView1.Columns(2).Caption = "Estatus"
                GridView1.Columns(3).Caption = "Negocio"
                GridView1.Columns(4).Caption = "Vale"
                GridView1.Columns(5).Caption = "Descripción" 'oculto
                GridView1.Columns(6).Caption = "Distribuidor"
                GridView1.Columns(7).Caption = "Cliente"
                GridView1.Columns(8).Caption = "Fecha"
                GridView1.Columns(9).Caption = "Importe"
                GridView1.Columns(10).Caption = "Quincenas"
                GridView1.Columns(11).Caption = "Usuario"

                'DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


                GridView1.Columns(9).DisplayFormat.FormatType = "c"
                'Grid.Columns(9).DefaultCellStyle.Format = "c" 

                'GridView1.Rows(0).Frozen = True '*****************************************************
                'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue'*****************************************************
                'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight'*****************************************************
                'DGrid.Rows(0).Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleCenter'*****************************************************

                'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)'****************

                GridView1.BestFitColumns()
                'DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells 

            ElseIf Opcion = 3 Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                'row(5) = pub_SumaColumnaGrid(GridView1, 5, GridView1.RowCount - 1) '*****************************************************
                'row(6) = pub_SumaColumnaGrid(DGrid, 6, GridView1.RowCount - 1)'*****************************************************

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                ' DGrid.RowHeadersVisible = False
                GridView1.Columns(0).Caption = "Venta"
                GridView1.Columns(1).Caption = "Marca"
                GridView1.Columns(2).Caption = "Modelo"
                GridView1.Columns(3).Caption = "EstiloF"
                GridView1.Columns(4).Caption = "Serie" 'oculto
                GridView1.Columns(5).Caption = "Precio"
                GridView1.Columns(6).Caption = "Importe"
                GridView1.Columns(7).Caption = "Usuario"
                GridView1.Columns(8).Caption = "Fecha"
                GridView1.Columns(9).Caption = "Hora"


                GridView1.Columns(0).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(4).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(5).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(6).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GridView1.Columns(7).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(8).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(9).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                'DGrid.Columns(5).DefaultCellStyle.Format = "c"
                GridView1.Columns(5).DisplayFormat.Format = "c2"
                GridView1.Columns(6).DisplayFormat.Format = "c2"

                'DGrid.Rows(0).Frozen = True '************************************************

                'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue '************************************************
                'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight '************************************************
                'DGrid.Rows(0).Cells(5).Style.Alignment = DataGridViewContentAlignment.MiddleCenter '************************************************

                'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold) '*****************

                'DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                GridView1.OptionsView.ColumnAutoWidth = False
                GridView1.OptionsView.BestFitMaxRowCount = -1
                GridView1.BestFitColumns()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'row(9) = pub_SumaColumnaGrid(DGrid, 9, GridView1.RowCount - 1)
    Public Function pub_SumaColumnaGrid(ByVal DGrid As DataGridView, ByVal Columna As Integer, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try

            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumaColumnaGrid = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                'If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value > 0) Then
                If DGrid.Rows(renglon).Cells(Columna).Value > 0 Then
                    pub_SumaColumnaGrid = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumaColumnaGrid
                End If
                If DGrid.Rows(renglon).Cells(Columna).Value < 0 Then
                    pub_SumaColumnaGrid = pub_SumaColumnaGrid + DGrid.Rows(renglon).Cells(Columna).Value
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            'If ExportarDGridAExcel(DGrid) = False Then
            '    MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            'End If
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                DGrid.ExportToXls(sfdRuta.FileName)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosVentasDistrib

            Opcion = 1

            If FechaInicio <> "1900-01-01" Then
                myForm.Chk_Fecha.Checked = True
                myForm.DTPicker2.Value = FechaInicio
                myForm.DTPicker3.Value = FechaFin
            End If

            myForm.Txt_Sucursal.Text = SucursalB
            myForm.Txt_NumDistrib.Text = DistribuidorIniB
            myForm.Txt_NumDistrib2.Text = DistribuidorFinB

            If EstatusB <> "" Then
                If EstatusB = "AC" Then
                    myForm.Cbo_Estatus.Text = "ACTIVO"
                ElseIf EstatusB = "BA" Then
                    myForm.Cbo_Estatus.Text = "BAJA"
                ElseIf EstatusB = "SU" Then
                    myForm.Cbo_Estatus.Text = "SUSPENDIDO"
                End If
            Else
                myForm.Cbo_Estatus.Text = ""
            End If

            myForm.ShowDialog()

            SucursalB = myForm.Txt_Sucursal.Text
            DistribuidorIniB = myForm.Txt_NumDistrib.Text
            DistribuidorFinB = myForm.Txt_NumDistrib2.Text

            If myForm.Cbo_Estatus.Text = "ACTIVO" Then
                EstatusB = "AC"
            ElseIf myForm.Cbo_Estatus.Text = "BAJA" Then
                EstatusB = "BA"
            ElseIf myForm.Cbo_Estatus.Text = "SUSPENDIDO" Then
                EstatusB = "SU"
            End If

            If myForm.Chk_Fecha.Checked = True Then
                FechaInicio = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFin = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")

                Lbl_RangoFechas.Text = "Periodo:  " + Format(myForm.DTPicker2.Value, "dd-MMM-yyyy").ToString.ToUpper + "  al  " + Format(myForm.DTPicker3.Value, "dd-MMM-yyyy").ToString.ToUpper

                'dt_Inicio.Value = myForm.DTPicker2.Value
                'dt_Fin.Value = myForm.DTPicker3.Value

                'dt_Inicio.Value = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                'dt_Fin.Value = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInicio = "1900-01-01"
                FechaFin = "1900-01-01"

                Lbl_RangoFechas.Text = ""
            End If

            If myForm.Sw_Filtro = True Then

                Opcion = 1
                PBox.Visible = False
                'DGrid.DataSource = Nothing
                'DGrid.DataSource = objDataSet.Tables(0)
                'objDataSet.Tables(0).Rows(0).Delete()
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        Try
            'If Me.DGrid.Columns(e.ColumnIndex).Name <> "status" Then Exit Sub
            ' ''If Me.DGrid.Columns(e.ColumnIndex).Name <> "fecha" Then Exit Sub
            'If e.RowIndex >= DGrid.RowCount - 3 Then
            '    If Sw_Load = False Then
            '        Sw_Pintar = False
            '    End If
            '    Exit Sub
            'End If


            'If DGrid.Rows(e.RowIndex).Cells("status").Value = "Total" Then
            '    Exit Sub
            'End If

            'If DGrid.Rows(e.RowIndex).Cells("importe").Value <= 0 Then
            '    DGrid.Rows(e.RowIndex).Cells("importe").Style.BackColor = Color.Red
            '    DGrid.Rows(e.RowIndex).Cells("importe").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim renglon = GridView1.FocusedRowHandle 'Se agrego

        Try
            If Opcion = 1 Then
                'If IsNumeric(DGrid.CurrentCell.Value) = False Then Exit Sub
                If IsNumeric(GridView1.FocusedValue) = False Then Exit Sub

                'If DGrid.CurrentCell.Value = 0 Then Exit Sub
                If GridView1.FocusedValue = 0 Then Exit Sub

                'FORMA1
                'Using objVentasDistrib As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)
                '    objDataSet1 = objVentasDistrib.usp_PpalVentasDistribDet(SucursalB,
                '                                                            GridView1.FocusedValue("distrib").Value.ToString,
                '                                                                    FechaInicio,
                '                                                                        FechaFin)

                'FORMA2
                Using objVentasDistrib As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)
                    objDataSet1 = objVentasDistrib.usp_PpalVentasDistribDet(SucursalB,
                                                                                GridView1.GetRowCellValue(renglon, "distrib").ToString,
                                                                                        FechaInicio,
                                                                                            FechaFin)
                    'ORIGINAL
                    ' objDataSet1 = objVentasDistrib.usp_PpalVentasDistribDet(SucursalB,
                    'DGrid.CurrentRow.Cells("distrib").Value.ToString, FechaInicio, FechaFin)
                End Using

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Opcion = 2

                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet1.Tables(0)

                    InicializaGrid()

                    Btn_Regresar.Enabled = True
                End If

            ElseIf Opcion = 2 Then

                Dim Sucursal As String
                Dim Venta As String

                Sucursal = GridView1.GetRowCellValue(GridView1.FocusedValue, "sucursal")
                Venta = GridView1.GetRowCellValue(GridView1.FocusedValue, "nota")
                'Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                'Venta = DGrid.CurrentRow.Cells("nota").Value

                Using objVentasDistrib As New BCL.BCLValesPorNegocio(GLB_ConStringCipSis)
                    objDataSet2 = objVentasDistrib.usp_TraerDetalleVentasDistrib(Sucursal, Venta)
                End Using

                If objDataSet2.Tables(0).Rows.Count > 0 Then
                    Opcion = 3
                    PBox.Image = Nothing
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet2.Tables(0)

                    InicializaGrid()

                    Btn_Regresar.Enabled = True
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 2 Then
                'DGrid.DataSource = Nothing
                'DGrid.DataSource = objDataSet.Tables(0)
                objDataSet.Tables(0).Rows(0).Delete()
                'DGrid.DataSource = objDataSet.Tables(0)
                Opcion = 1
                Btn_Regresar.Enabled = False
                PBox.Visible = False
                'Call LimpiarBusqueda()

                Call RellenaGrid()

            ElseIf Opcion = 3 Then

                'DGrid.DataSource = Nothing
                'DGrid.DataSource = objDataSet1.Tables(0)
                objDataSet1.Tables(0).Rows(0).Delete()
                'DGrid.DataSource = objDataSet1.Tables(0)
                Opcion = 2
                Btn_Regresar.Enabled = True
                PBox.Visible = False
                'Call LimpiarBusqueda()

                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Sorted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim renglon = GridView1.FocusedRowHandle

        Try

            If Opcion = 1 Then
                'For i As Integer = 1 To DGrid.Rows.Count - 2
                For i As Integer = 1 To GridView1.DataRowCount - 2
                    ' For j As Integer = 6 To DGrid.Columns.Count - 1
                    For j As Integer = 6 To GridView1.Columns.Count - 1
                        'If DGrid.Rows(i).Cells(j).Value = 0 Then
                        If GridView1.GetRowCellValue(i, j) = 0 Then
                            ' DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White '***************************************************
                            GridView1.Appearance.FocusedCell.BackColor = Color.White ' CAMBIAR ES PARA UNA CELDA ESPECIFICA

                        End If
                    Next
                Next


                For k As Integer = 1 To GridView1.DataRowCount - 2
                    For l As Integer = 20 To 20
                        ' If DGrid.Rows(k).Cells(l).Value = 0 Then
                        If GridView1.GetRowCellValue(k, l) = 0 Then
                            'DGrid.Rows(k).Cells(l).Style.ForeColor = Color.PowderBlue '*****************************************
                            GridView1.Appearance.FocusedCell.BackColor = Color.White ' CAMBIAR ES PARA UNA CELDA ESPECIFICA
                        End If
                    Next
                Next

                'If DGrid.Rows(0).Cells("distribuidor").Value = " " Then
                If GridView1.GetRowCellValue(0, "distribuidor") = " " Then

                    'DGrid.Rows(0).Frozen = True '******************************

                    GridView1.Columns(0).AppearanceHeader.Font = New Font(GridView1.Columns(0).AppearanceCell.Font, FontStyle.Bold)

                    'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue '*****************************************
                    'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight '*****************************************

                    'DGrid.Rows(0).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    GridView1.Columns(0).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                    'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold) '****************************

                Else
                    ' DGrid.Rows(0).Frozen = False '*****************************************
                End If

            ElseIf Opcion = 2 Then

                If GridView1.GetRowCellValue(0, "cliente") = " " Then
                    'If DGrid.Rows(0).Cells("cliente").Value = " " Then
                    'DGrid.Rows(0).Frozen = True '*****************************************


                    'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue '*****************************************
                    'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight '*****************************************
                    'DGrid.Rows(0).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter '*****************************************

                    'GridView1.Rows(0).AppearanceHeader.Font = New Font(GridView1.Columns(0).AppearanceCell.Font, FontStyle.Bold)
                    ' DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Else
                    'DGrid.Rows(0).Frozen = False  '*****************************************
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon) 'NO CAMBIAR
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function ArchivoFotoArticulo(ByVal Marca As String, ByVal Estilon As String) As String
        'mreyes 07/Marzo/2012 06:49 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            ArchivoFotoArticulo = ""
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    ArchivoFotoArticulo = Archivo
                    Exit Function
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        ArchivoFotoArticulo = Archivo
                        Exit Function
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            ArchivoFotoArticulo = ""
        End Try
    End Function

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Opcion = 3 Then
            If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedValue, 1)) Then
                'If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
            Else
                CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedValue, 1), GridView1.GetRowCellValue(GridView1.FocusedValue, 2))
                ' CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
            End If
        End If
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Opcion = 3 Then
            If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedValue, 1)) Then
                'If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then

            Else
                CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedValue, 1), GridView1.GetRowCellValue(GridView1.FocusedValue, 2))
                'CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value)
            End If
        End If

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        Try

            'If blnPrimero = False Then
            If Opcion = 1 Then
                For i As Integer = 1 To GridView1.DataRowCount - 2
                    'For i As Integer = 1 To DGrid.Row.Count - 2
                    For j As Integer = 6 To GridView1.Columns.Count - 1
                        If GridView1.GetRowCellValue(i, j).Value = 0 Then
                            'If DGrid.Rows(i).Cells(j).Value = 0 Then
                            'DGrid.Rows(i).Cells(j).Style.ForeColor = Color.White '*********************************************************
                        End If
                    Next
                Next

                For k As Integer = 1 To GridView1.DataRowCount - 2
                    'For k As Integer = 1 To DGrid.Row.Count - 2
                    For l As Integer = 20 To 20

                        If GridView1.GetRowCellValue(k, l) = 0 Then
                            'If DGrid.Rows(k).Cells(l).Value = 0 Then
                            'GridView1.GetRowCellValue(k, l)
                            'DGrid.Rows(k).Cells(l).Style.ForeColor = Color.PowderBlue '***********************************************************
                        End If

                    Next
                Next

                If GridView1.GetRowCellValue(0, "distribuidor").Value = " " Then
                    'If DGrid.Rows(0).Cells("distribuidor").Value = " " Then
                    'DGrid.Rows(0).Frozen = True '***********************************************************
                End If



                'DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue'***********************************************************
                'DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight'***********************************************************
                'DGrid.Rows(0).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter'***********************************************************

                'DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                GridView1.Columns(20).AppearanceCell.BackColor = Color.PowderBlue
                'DGrid.Columns(20).DefaultCellStyle.BackColor = Color.PowderBlue
                GridView1.Columns(20).AppearanceCell.Font = New Font(GridView1.Columns(20).AppearanceCell.Font, FontStyle.Bold)
                'DGrid.Columns(20).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                GridView1.BestFitColumns()
                'DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            End If

            blnPrimero = True
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        Try
            'If ScrollOrientation.HorizontalScroll = ScrollOrientation.HorizontalScroll Then
            '    DGrid.Rows(0).Frozen = False

            '    DGrid.Columns(0).Frozen = True
            '    DGrid.Columns(1).Frozen = True
            '    DGrid.Columns(2).Frozen = True
            '    DGrid.Columns(3).Frozen = True

            'ElseIf ScrollOrientation.VerticalScroll Then
            '    DGrid.Rows(0).Frozen = True

            '    DGrid.Columns(0).Frozen = False
            '    DGrid.Columns(1).Frozen = False
            '    DGrid.Columns(2).Frozen = False
            '    DGrid.Columns(3).Frozen = False

            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class