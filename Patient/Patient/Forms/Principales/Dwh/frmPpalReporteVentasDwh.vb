Public Class frmPpalReporteVentasDwh
    'Miguel Pérez 

    Private objDataSet As Data.DataSet
    Private FechaInicioA As String
    Private FechaInicioB As String
    Private FechaFinA As String
    Private FechaFinB As String
    Private Sucursal As Integer
    Private Plaza As Integer = 0
    Private Division As Integer = 0
    Private Departamento As Integer = 0
    Private Familia As Integer = 0
    Private Linea As Integer = 0
    Private L1 As Integer = 0
    Private L2 As Integer = 0
    Private L3 As Integer = 0
    Private L4 As Integer = 0
    Private L5 As Integer = 0
    Private L6 As Integer = 0
    Private strMarca As String = ""
    Private intAgrupacion As Integer
    Private blnDoubleClick As Boolean = False
    Private FamiliaDescrip As String = ""
    Private LineaDescrip As String = ""
    Private L1Descrip As String = ""
    Private L2Descrip As String = ""
    Private L3Descrip As String = ""
    Private L4Descrip As String = ""
    Private L5Descrip As String = ""
    Private L6Descrip As String = ""
    Private strModelo As String = ""
    Private FecRecA As String = ""
    Private FecRecB As String = ""
    Private idAgrupacionB As Integer = 0

    Dim Sw_Load As Boolean = True
    Dim Sw_Load2 As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0
    Public Marca As Boolean = False
    Public Modelo As Boolean = False
    Public RegresoModelo As Boolean = False
    Public Agrupacion As Boolean = False
    Dim strAñoAnterior As String
    Dim strAñoActual As String
    Dim OpcionAgrupacion As Integer = 0
    Dim blnBorroCol As Boolean = False
    Dim SucursalB As String
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Private blnBD As Boolean = False
    Private TextoSelec As String = ""
    Private OpcionLinea As Integer = 0
    Dim myFormFiltros As frmFiltrosVentasDWH
    Private arreglo(100) As Integer
    Private intArreglo As Integer = 0
    Private sinLinea As Boolean = False
    Private AñoAnterior As Boolean = False
    Private AñoAnteriorIgual As Boolean = False
    Private blnEntro As Boolean = False


    Public Function pub_SumarColumnaGridNombre(ByVal DGrid As DataGridView, ByVal Columna As String, Optional ByVal HastaRenglon As Integer = 0) As Decimal
        'mreyes 14/Febrero/2012 05:08 p.m.
        Try
            ''Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            ''pub_SumarColumnaGrid = 0
            ''For Each row As DataGridViewRow In DGrid.Rows
            ''    If IsNumeric(row.Cells(Columna).Value) Then
            ''        pub_SumarColumnaGrid = (row.Cells(Columna).Value) + pub_SumarColumnaGrid
            ''    End If
            ''Next

            Dim Col As Integer = DGrid.CurrentCell.ColumnIndex

            pub_SumarColumnaGridNombre = 0
            For renglon As Integer = 0 To IIf(HastaRenglon = 0, DGrid.RowCount - 2, HastaRenglon)
                If IsNumeric(DGrid.Rows(renglon).Cells(Columna).Value) Then
                    pub_SumarColumnaGridNombre = (DGrid.Rows(renglon).Cells(Columna).Value) + pub_SumarColumnaGridNombre
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub SumaModelo()
        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()

        row(3) = "TOTAL: "

        row("paresnetoactual") = pub_SumarColumnaGridNombre(DGrid, "paresnetoactual", DGrid.RowCount - 1)
        row("existe") = pub_SumarColumnaGridNombre(DGrid, "existe", DGrid.RowCount - 1)
        row("paresnormalactual") = pub_SumarColumnaGridNombre(DGrid, "paresnormalactual", DGrid.RowCount - 1)
        row("paresdescactual") = pub_SumarColumnaGridNombre(DGrid, "paresdescactual", DGrid.RowCount - 1)
        row("parespromactual") = pub_SumarColumnaGridNombre(DGrid, "parespromactual", DGrid.RowCount - 1)
        row("paresregactual") = pub_SumarColumnaGridNombre(DGrid, "paresregactual", DGrid.RowCount - 1)
        If row("paresnetoactual") > 0 Then
            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
        Else
            row("porcparesnormalac") = 0
            row("porcparesdescac") = 0
            row("porcparespromac") = 0
            row("porcparesregac") = 0
        End If

        row("impnetoactual") = pub_SumarColumnaGridNombre(DGrid, "impnetoactual", DGrid.RowCount - 1)
        row("impnormalactual") = pub_SumarColumnaGridNombre(DGrid, "impnormalactual", DGrid.RowCount - 1)
        row("impdescactual") = pub_SumarColumnaGridNombre(DGrid, "impdescactual", DGrid.RowCount - 1)
        row("imppromactual") = pub_SumarColumnaGridNombre(DGrid, "imppromactual", DGrid.RowCount - 1)
        row("impregactual") = pub_SumarColumnaGridNombre(DGrid, "impregactual", DGrid.RowCount - 1)
        If row("impnetoactual") > 0 Then
            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
        Else
            row("porcimpnormalac") = 0
            row("porcimpdescac") = 0
            row("porcimppromac") = 0
            row("porcimpregac") = 0
        End If
        If AñoAnterior = True Then
            row("paresnetoanterior") = pub_SumarColumnaGridNombre(DGrid, "paresnetoanterior", DGrid.RowCount - 1)
            row("paresnormalanterior") = pub_SumarColumnaGridNombre(DGrid, "paresnormalanterior", DGrid.RowCount - 1)
            row("paresdescanterior") = pub_SumarColumnaGridNombre(DGrid, "paresdescanterior", DGrid.RowCount - 1)
            row("parespromanterior") = pub_SumarColumnaGridNombre(DGrid, "parespromanterior", DGrid.RowCount - 1)
            row("paresreganterior") = pub_SumarColumnaGridNombre(DGrid, "paresreganterior", DGrid.RowCount - 1)
            If row("paresnetoanterior") > 0 Then
                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
            Else
                row("porcparesnormalan") = 0
                row("porcparesdescan") = 0
                row("porcparesproman") = 0
                row("porcparesregan") = 0
            End If

            row("impnetoanterior") = pub_SumarColumnaGridNombre(DGrid, "impnetoanterior", DGrid.RowCount - 1)
            row("impnormalanterior") = pub_SumarColumnaGridNombre(DGrid, "impnormalanterior", DGrid.RowCount - 1)
            row("impdescanterior") = pub_SumarColumnaGridNombre(DGrid, "impdescanterior", DGrid.RowCount - 1)
            row("imppromanterior") = pub_SumarColumnaGridNombre(DGrid, "imppromanterior", DGrid.RowCount - 1)
            row("impreganterior") = pub_SumarColumnaGridNombre(DGrid, "impreganterior", DGrid.RowCount - 1)
            If row("impnetoanterior") > 0 Then
                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
            Else
                row("porcimpnormalan") = 0
                row("porcimpdescan") = 0
                row("porcimpproman") = 0
                row("porcimpregan") = 0
            End If

            If row("paresnetoanterior") > 0 Then
                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
            Else
                row("incrementopares") = 0
            End If
            If row("impnetoanterior") > 0 Then
                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
            Else
                row("incrementoimporte") = 0
            End If
        End If
        dt.Rows.InsertAt(row, 0)
        DGrid.DataSource = dt

        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

        'If Chk_Miles.Checked = False Then
        '    For i As Integer = 0 To DGrid.Rows.Count - 1
        '        If IsDBNull(DGrid.Rows(i).Cells("impnetoactual").Value) = False Then
        '            DGrid.Rows(i).Cells("impnetoactual").Value = Math.Round(DGrid.Rows(i).Cells("impnetoactual").Value * 1000)
        '        End If
        '        If IsDBNull(DGrid.Rows(i).Cells("impnormalactual").Value) = False Then
        '            DGrid.Rows(i).Cells("impnormalactual").Value = Math.Round(DGrid.Rows(i).Cells("impnormalactual").Value * 1000)
        '        End If
        '        If IsDBNull(DGrid.Rows(i).Cells("impdescactual").Value) = False Then
        '            DGrid.Rows(i).Cells("impdescactual").Value = Math.Round(DGrid.Rows(i).Cells("impdescactual").Value * 1000)
        '        End If
        '        If IsDBNull(DGrid.Rows(i).Cells("imppromactual").Value) = False Then
        '            DGrid.Rows(i).Cells("imppromactual").Value = Math.Round(DGrid.Rows(i).Cells("imppromactual").Value * 1000)
        '        End If
        '        If IsDBNull(DGrid.Rows(i).Cells("impregactual").Value) = False Then
        '            DGrid.Rows(i).Cells("impregactual").Value = Math.Round(DGrid.Rows(i).Cells("impregactual").Value * 1000)
        '        End If
        '        If AñoAnterior = True Then
        '            If IsDBNull(DGrid.Rows(i).Cells("impnetoanterior").Value) = False Then
        '                DGrid.Rows(i).Cells("impnetoanterior").Value = Math.Round(DGrid.Rows(i).Cells("impnetoanterior").Value * 1000)
        '            End If
        '            If IsDBNull(DGrid.Rows(i).Cells("impnormalanterior").Value) = False Then
        '                DGrid.Rows(i).Cells("impnormalanterior").Value = Math.Round(DGrid.Rows(i).Cells("impnormalanterior").Value * 1000)
        '            End If
        '            If IsDBNull(DGrid.Rows(i).Cells("impdescanterior").Value) = False Then
        '                DGrid.Rows(i).Cells("impdescanterior").Value = Math.Round(DGrid.Rows(i).Cells("impdescanterior").Value * 1000)
        '            End If
        '            If IsDBNull(DGrid.Rows(i).Cells("imppromanterior").Value) = False Then
        '                DGrid.Rows(i).Cells("imppromanterior").Value = Math.Round(DGrid.Rows(i).Cells("imppromanterior").Value * 1000)
        '            End If
        '            If IsDBNull(DGrid.Rows(i).Cells("impreganterior").Value) = False Then
        '                DGrid.Rows(i).Cells("impreganterior").Value = Math.Round(DGrid.Rows(i).Cells("impreganterior").Value * 1000)
        '            End If
        '        End If
        '    Next
        'End If
        blnBorroCol = False
        FechaFinA = DGrid.Rows(1).Cells("FecFinA").Value
        FechaFinB = DGrid.Rows(1).Cells("FecFinB").Value
        Lbl_FecIni.Text = CDate(FechaInicioA).ToString("dd/MMM/yyyy").ToUpper + " - " + CDate(FechaInicioB).ToString("dd/MMM/yyyy").ToUpper
        If AñoAnterior = True Then
            Lbl_FecFin.Text = "ANTERIOR: " + CDate(FechaFinA).ToString("dd/MMM/yyyy").ToUpper + " - " + CDate(FechaFinB).ToString("dd/MMM/yyyy").ToUpper
        Else
            Lbl_FecFin.Text = ""
        End If
    End Sub

    Private Sub InicializaGrid()
        Try
            lbl_Suma.Visible = False
            If DGrid.DataSource Is Nothing Then Exit Sub
            If blnBorroCol = True Then
                DGrid.Columns.Remove(DGrid.Columns("Renglon"))
            End If
            If Marca = True Then
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row(1) = "TOTAL: "
                row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row("parespromactual") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row("paresregactual") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                If row("paresnetoactual") > 0 Then
                    row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                    row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                    row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                    row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                Else
                    row("porcparesnormalac") = 0
                    row("porcparesdescac") = 0
                    row("porcparespromac") = 0
                    row("porcparesregac") = 0
                End If

                row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row("impdescactual") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row("imppromactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row("impregactual") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                If row("impnetoactual") > 0 Then
                    row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                    row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                    row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                    row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                Else
                    row("porcimpnormalac") = 0
                    row("porcimpdescac") = 0
                    row("porcimppromac") = 0
                    row("porcimpregac") = 0
                End If
                If AñoAnterior = True Then
                    row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                    row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                    row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                    row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                    row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                    If row("paresnetoanterior") > 0 Then
                        row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                        row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                        row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                        row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                    Else
                        row("porcparesnormalan") = 0
                        row("porcparesdescan") = 0
                        row("porcparesproman") = 0
                        row("porcparesregan") = 0
                    End If

                    row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                    row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                    row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                    row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                    row("impreganterior") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                    If row("impnetoanterior") > 0 Then
                        row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                        row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                        row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                        row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                    Else
                        row("porcimpnormalan") = 0
                        row("porcimpdescan") = 0
                        row("porcimpproman") = 0
                        row("porcimpregan") = 0
                    End If

                    If row("paresnetoanterior") > 0 Then
                        row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                    Else
                        row("incrementopares") = 0
                    End If
                    If row("impnetoanterior") > 0 Then
                        row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                    Else
                        row("incrementoimporte") = 0
                    End If
                End If
                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt
                ToolStripMenuItemSucursal.Visible = True
                ToolStripMenuItemDivision.Visible = True
                ToolStripMenuItemDepto.Visible = True
                ToolStripMenuItemFamilia.Visible = True
                ToolStripMenuItemLinea.Visible = True
                ToolStripMenuItemL1.Visible = True
                ToolStripMenuItemL2.Visible = True
                ToolStripMenuItemL3.Visible = True
                ToolStripMenuItemL4.Visible = True
                ToolStripMenuItemL5.Visible = True
                ToolStripMenuItemL6.Visible = True
                ToolStripMenuItemMarca.Visible = False
                ToolStripMenuItemModelo.Visible = True
                ToolStripMenuItemAnaModelo.Visible = False
                ToolStripMenuItemCatModelo.Visible = False
                DGrid.Columns("descrip").Frozen = True
                DGrid.Columns("descrip").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("descrip").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns("marca").Visible = False
                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("descrip").HeaderText = "Marca"
            Else
                If Modelo = True Then
                    'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                    'Dim row As DataRow = dt.NewRow()

                    'row(3) = "TOTAL: "

                    'row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                    'row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                    'row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                    'row("parespromactual") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                    'row("paresregactual") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                    'If row("paresnetoactual") > 0 Then
                    '    row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                    '    row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                    '    row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                    '    row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                    'Else
                    '    row("porcparesnormalac") = 0
                    '    row("porcparesdescac") = 0
                    '    row("porcparespromac") = 0
                    '    row("porcparesregac") = 0
                    'End If

                    'row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                    'row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                    'row("impdescactual") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                    'row("imppromactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                    'row("impregactual") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                    'If row("impnetoactual") > 0 Then
                    '    row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                    '    row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                    '    row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                    '    row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                    'Else
                    '    row("porcimpnormalac") = 0
                    '    row("porcimpdescac") = 0
                    '    row("porcimppromac") = 0
                    '    row("porcimpregac") = 0
                    'End If
                    'If AñoAnterior = True Then
                    '    row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                    '    row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                    '    row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                    '    row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                    '    row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 29, DGrid.RowCount - 1)
                    '    If row("paresnetoanterior") > 0 Then
                    '        row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                    '        row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                    '        row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                    '        row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                    '    Else
                    '        row("porcparesnormalan") = 0
                    '        row("porcparesdescan") = 0
                    '        row("porcparesproman") = 0
                    '        row("porcparesregan") = 0
                    '    End If

                    '    row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                    '    row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                    '    row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                    '    row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                    '    row("impreganterior") = pub_SumarColumnaGrid(DGrid, 39, DGrid.RowCount - 1)
                    '    If row("impnetoanterior") > 0 Then
                    '        row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                    '        row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                    '        row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                    '        row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                    '    Else
                    '        row("porcimpnormalan") = 0
                    '        row("porcimpdescan") = 0
                    '        row("porcimpproman") = 0
                    '        row("porcimpregan") = 0
                    '    End If

                    '    If row("paresnetoanterior") > 0 Then
                    '        row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                    '    Else
                    '        row("incrementopares") = 0
                    '    End If
                    '    If row("impnetoanterior") > 0 Then
                    '        row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                    '    Else
                    '        row("incrementoimporte") = 0
                    '    End If
                    'End If
                    'dt.Rows.InsertAt(row, 0)
                    'DGrid.DataSource = dt
                    ToolStripMenuItemSucursal.Visible = True
                    ToolStripMenuItemDivision.Visible = True
                    ToolStripMenuItemDepto.Visible = True
                    ToolStripMenuItemFamilia.Visible = True
                    ToolStripMenuItemLinea.Visible = True
                    ToolStripMenuItemL1.Visible = True
                    ToolStripMenuItemL2.Visible = True
                    ToolStripMenuItemL3.Visible = True
                    ToolStripMenuItemL4.Visible = True
                    ToolStripMenuItemL5.Visible = True
                    ToolStripMenuItemL6.Visible = True
                    ToolStripMenuItemMarca.Visible = True
                    ToolStripMenuItemModelo.Visible = False
                    If GLB_CveSucursal > "0" And GLB_CveSucursal < "90" Then
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                    Else
                        ToolStripMenuItemAnaModelo.Visible = True
                        ToolStripMenuItemCatModelo.Visible = True
                    End If
                    DGrid.Columns("marca").Frozen = True
                    DGrid.Columns("marca").DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns("marca").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns("modelo").Frozen = True
                    DGrid.Columns("modelo").DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns("modelo").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns("estilof").Frozen = True
                    DGrid.Columns("estilof").DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns("estilof").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns("descripc").Frozen = True
                    DGrid.Columns("descripc").DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns("descripc").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Columns("marca").HeaderText = "Marca"
                    DGrid.Columns("modelo").HeaderText = "Modelo"
                    DGrid.Columns("estilof").HeaderText = "Estilo"
                    DGrid.Columns("descripc").HeaderText = "Descripción"
                    DGrid.Columns("existe").HeaderText = "Existencia"
                    DGrid.Columns("inventario").HeaderText = "Días Inv."
                    'DGrid.Columns("existe").DisplayIndex = 8
                Else
                    If Opcion = 1 Or Opcion = 2 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        'mreyes 13/10/2015  11:51 a.m.
                        'Se agrego plaza

                        row(1) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                        row("aplicadasact") = pub_SumarColumnaGridNombre(DGrid, "aplicadasact", DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                            row("aplicadasant") = pub_SumarColumnaGridNombre(DGrid, "aplicadasant", DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If
                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 33, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = False
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        'If blnBD = True Then
                        '    GeneraLabel(1, TextoSelec + ", " + CB_Sucursal.Text)
                        'Else
                        '    GeneraLabel(1, CB_Sucursal.Text)
                        'End If
                        If Opcion = 1 Then
                            lbl_Mensaje.Text = "PLAZAS"
                            DGrid.Columns("plaza").Frozen = True
                            DGrid.Columns("plaza").DefaultCellStyle.BackColor = Color.PowderBlue
                            DGrid.Columns("plaza").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                            DGrid.Columns("idplaza").Visible = False
                            DGrid.Columns("idplaza").HeaderText = "IdPlaza"
                            DGrid.Columns("plaza").HeaderText = "Plaza"
                        Else
                            lbl_Mensaje.Text = "SUCURSALES"
                            DGrid.Columns("sucursal").Frozen = True
                            DGrid.Columns("sucursal").DefaultCellStyle.BackColor = Color.PowderBlue
                            DGrid.Columns("sucursal").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                            DGrid.Columns("idsucursal").Visible = False
                            DGrid.Columns("idsucursal").HeaderText = "IdSucursal"
                            DGrid.Columns("sucursal").HeaderText = "Sucursal"
                        End If
                        DGrid.Columns("aplicadasact").HeaderText = "Transacciones"
                        DGrid.Columns("aplicadasact").DisplayIndex = 4
                        If Chk_AnioAnterior.Checked Or Chk_AnioAnterior1.Checked Then
                            DGrid.Columns("aplicadasant").HeaderText = "Transacciones"
                            DGrid.Columns("aplicadasant").DisplayIndex = 25
                        End If
                        If (Division = 0 Or Division = 1) And Departamento = 0 And FamiliaDescrip = "" And LineaDescrip = "" And L1Descrip = "" _
                            And L2Descrip = "" And L3Descrip = "" And L4Descrip = "" And L5Descrip = "" And L6Descrip = "" _
                            And strMarca = "" And strModelo = "" And FecRecA = "" And FecRecB = "" Then
                            DGrid.Columns("aplicadasact").Visible = True
                            If Chk_AnioAnterior.Checked Then
                                DGrid.Columns("aplicadasant").Visible = True
                            End If
                        Else
                            DGrid.Columns("aplicadasact").Visible = False
                            If Chk_AnioAnterior.Checked Or Chk_AnioAnterior1.Checked Then
                                DGrid.Columns("aplicadasant").Visible = False
                            End If
                        End If
                    ElseIf Opcion = 3 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(3) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 29, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 39, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = False
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "DIVISIONES")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", DIVISIONES"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "DIVISIONES")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", DIVISIONES"
                            End If
                        End If
                        DGrid.Columns("division").Frozen = True
                        DGrid.Columns("division").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("division").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("iddivisiones").HeaderText = "Iddivision"
                        DGrid.Columns("division").HeaderText = "División"

                    ElseIf Opcion = 4 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(5) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 29, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 31, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 39, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 41, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = False
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "DEPARTAMENTO")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", DEPARTAMENTO"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "DEPARTAMENTO")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", DEPARTAMENTO"
                            End If
                        End If
                        DGrid.Columns("depto").Frozen = True
                        DGrid.Columns("depto").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("depto").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("iddepto").HeaderText = "Iddepto"
                        DGrid.Columns("depto").HeaderText = "Departamento"

                    ElseIf Opcion = 5 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(7) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 31, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 33, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 41, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 43, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = False
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "FAMILIA")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", FAMILIA"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "FAMILIA")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", FAMILIA"
                            End If
                        End If
                        DGrid.Columns("familia").Frozen = True
                        DGrid.Columns("familia").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("familia").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("idfamilia").HeaderText = "Idfamilia"
                        DGrid.Columns("familia").HeaderText = "Familia"

                    ElseIf Opcion = 6 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(9) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 33, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 43, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 45, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = False
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "LINEA")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", LINEA"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "LINEA")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", LINEA"
                            End If
                        End If
                        DGrid.Columns("linea").Frozen = True
                        DGrid.Columns("linea").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("linea").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("idlinea").HeaderText = "Idlinea"
                        DGrid.Columns("linea").HeaderText = "Linea"

                    ElseIf Opcion = 7 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(11) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 45, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 46, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 47, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = False
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L1")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", L1"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L1")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", L1"
                            End If
                        End If
                        DGrid.Columns("l1").Frozen = True
                        DGrid.Columns("l1").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("l1").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("linea").Visible = False
                        DGrid.Columns("idl1").Visible = False
                        DGrid.Columns("idl1").HeaderText = "Idl1"
                        DGrid.Columns("l1").HeaderText = "L1"

                    ElseIf Opcion = 8 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(13) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 29, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 39, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 46, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 47, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 48, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 49, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = False
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L2")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", L2"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L2")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", L2"
                            End If
                        End If
                        DGrid.Columns("l2").Frozen = True
                        DGrid.Columns("l2").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("l2").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("linea").Visible = False
                        DGrid.Columns("idl1").Visible = False
                        DGrid.Columns("l1").Visible = False
                        DGrid.Columns("idl2").Visible = False
                        DGrid.Columns("idl2").HeaderText = "Idl2"
                        DGrid.Columns("l2").HeaderText = "L2"

                    ElseIf Opcion = 9 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(15) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 29, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 31, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 39, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 41, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 46, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 48, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 49, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 50, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 51, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = False
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L3")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", L3"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L3")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", L3"
                            End If
                        End If
                        DGrid.Columns("l3").Frozen = True
                        DGrid.Columns("l3").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("l3").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("linea").Visible = False
                        DGrid.Columns("idl1").Visible = False
                        DGrid.Columns("l1").Visible = False
                        DGrid.Columns("idl2").Visible = False
                        DGrid.Columns("l2").Visible = False
                        DGrid.Columns("idl3").Visible = False
                        DGrid.Columns("idl3").HeaderText = "Idl3"
                        DGrid.Columns("l3").HeaderText = "L3"

                    ElseIf Opcion = 10 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(17) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 21, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 28, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 31, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 33, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 38, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 41, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 43, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 48, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 50, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 51, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 52, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 53, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = False
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L4")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", " + DGrid.Rows(1).Cells("l3").Value + ", L4"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L4")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", " + DGrid.Rows(1).Cells("l3").Value + ", L4"
                            End If
                        End If
                        DGrid.Columns("l4").Frozen = True
                        DGrid.Columns("l4").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("l4").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("linea").Visible = False
                        DGrid.Columns("idl1").Visible = False
                        DGrid.Columns("l1").Visible = False
                        DGrid.Columns("idl2").Visible = False
                        DGrid.Columns("l2").Visible = False
                        DGrid.Columns("idl3").Visible = False
                        DGrid.Columns("l3").Visible = False
                        DGrid.Columns("idl4").Visible = False
                        DGrid.Columns("idl4").HeaderText = "Idl4"
                        DGrid.Columns("l4").HeaderText = "L4"

                    ElseIf Opcion = 11 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(19) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 20, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 23, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 30, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 33, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 40, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 43, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 45, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 50, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 52, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 53, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 54, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 55, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = False
                        ToolStripMenuItemL6.Visible = True
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L5")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", " + DGrid.Rows(1).Cells("l3").Value + ", " + DGrid.Rows(1).Cells("l4").Value + ", L5"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L5")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", " + DGrid.Rows(1).Cells("l3").Value + ", " + DGrid.Rows(1).Cells("l4").Value + ", L5"
                            End If
                        End If
                        DGrid.Columns("l5").Frozen = True
                        DGrid.Columns("l5").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("l5").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("linea").Visible = False
                        DGrid.Columns("idl1").Visible = False
                        DGrid.Columns("l1").Visible = False
                        DGrid.Columns("idl2").Visible = False
                        DGrid.Columns("l2").Visible = False
                        DGrid.Columns("idl3").Visible = False
                        DGrid.Columns("l3").Visible = False
                        DGrid.Columns("idl4").Visible = False
                        DGrid.Columns("l4").Visible = False
                        DGrid.Columns("idl5").Visible = False
                        DGrid.Columns("idl5").HeaderText = "Idl5"
                        DGrid.Columns("l5").HeaderText = "L5"

                    ElseIf Opcion = 12 Then
                        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                        Dim row As DataRow = dt.NewRow()

                        row(21) = "TOTAL: "

                        row("paresnetoactual") = pub_SumarColumnaGrid(DGrid, 22, DGrid.RowCount - 1)
                        row("paresnormalactual") = pub_SumarColumnaGrid(DGrid, 24, DGrid.RowCount - 1)
                        row("paresdescactual") = pub_SumarColumnaGrid(DGrid, 25, DGrid.RowCount - 1)
                        row("parespromactual") = pub_SumarColumnaGrid(DGrid, 26, DGrid.RowCount - 1)
                        row("paresregactual") = pub_SumarColumnaGrid(DGrid, 27, DGrid.RowCount - 1)
                        If row("paresnetoactual") > 0 Then
                            row("porcparesnormalac") = row("paresnormalactual") / row("paresnetoactual") * 100
                            row("porcparesdescac") = row("paresdescactual") / row("paresnetoactual") * 100
                            row("porcparespromac") = row("parespromactual") / row("paresnetoactual") * 100
                            row("porcparesregac") = row("paresregactual") / row("paresnetoactual") * 100
                        Else
                            row("porcparesnormalac") = 0
                            row("porcparesdescac") = 0
                            row("porcparespromac") = 0
                            row("porcparesregac") = 0
                        End If

                        row("impnetoactual") = pub_SumarColumnaGrid(DGrid, 32, DGrid.RowCount - 1)
                        row("impnormalactual") = pub_SumarColumnaGrid(DGrid, 34, DGrid.RowCount - 1)
                        row("impdescactual") = pub_SumarColumnaGrid(DGrid, 35, DGrid.RowCount - 1)
                        row("imppromactual") = pub_SumarColumnaGrid(DGrid, 36, DGrid.RowCount - 1)
                        row("impregactual") = pub_SumarColumnaGrid(DGrid, 37, DGrid.RowCount - 1)
                        If row("impnetoactual") > 0 Then
                            row("porcimpnormalac") = row("impnormalactual") / row("impnetoactual") * 100
                            row("porcimpdescac") = row("impdescactual") / row("impnetoactual") * 100
                            row("porcimppromac") = row("imppromactual") / row("impnetoactual") * 100
                            row("porcimpregac") = row("impregactual") / row("impnetoactual") * 100
                        Else
                            row("porcimpnormalac") = 0
                            row("porcimpdescac") = 0
                            row("porcimppromac") = 0
                            row("porcimpregac") = 0
                        End If
                        If AñoAnterior = True Then
                            row("paresnetoanterior") = pub_SumarColumnaGrid(DGrid, 42, DGrid.RowCount - 1)
                            row("paresnormalanterior") = pub_SumarColumnaGrid(DGrid, 44, DGrid.RowCount - 1)
                            row("paresdescanterior") = pub_SumarColumnaGrid(DGrid, 45, DGrid.RowCount - 1)
                            row("parespromanterior") = pub_SumarColumnaGrid(DGrid, 46, DGrid.RowCount - 1)
                            row("paresreganterior") = pub_SumarColumnaGrid(DGrid, 47, DGrid.RowCount - 1)
                            If row("paresnetoanterior") > 0 Then
                                row("porcparesnormalan") = row("paresnormalanterior") / row("paresnetoanterior") * 100
                                row("porcparesdescan") = row("paresdescanterior") / row("paresnetoanterior") * 100
                                row("porcparesproman") = row("parespromanterior") / row("paresnetoanterior") * 100
                                row("porcparesregan") = row("paresreganterior") / row("paresnetoanterior") * 100
                            Else
                                row("porcparesnormalan") = 0
                                row("porcparesdescan") = 0
                                row("porcparesproman") = 0
                                row("porcparesregan") = 0
                            End If

                            row("impnetoanterior") = pub_SumarColumnaGrid(DGrid, 52, DGrid.RowCount - 1)
                            row("impnormalanterior") = pub_SumarColumnaGrid(DGrid, 54, DGrid.RowCount - 1)
                            row("impdescanterior") = pub_SumarColumnaGrid(DGrid, 55, DGrid.RowCount - 1)
                            row("imppromanterior") = pub_SumarColumnaGrid(DGrid, 56, DGrid.RowCount - 1)
                            row("impreganterior") = pub_SumarColumnaGrid(DGrid, 57, DGrid.RowCount - 1)
                            If row("impnetoanterior") > 0 Then
                                row("porcimpnormalan") = row("impnormalanterior") / row("impnetoanterior") * 100
                                row("porcimpdescan") = row("impdescanterior") / row("impnetoanterior") * 100
                                row("porcimpproman") = row("imppromanterior") / row("impnetoanterior") * 100
                                row("porcimpregan") = row("impreganterior") / row("impnetoanterior") * 100
                            Else
                                row("porcimpnormalan") = 0
                                row("porcimpdescan") = 0
                                row("porcimpproman") = 0
                                row("porcimpregan") = 0
                            End If

                            If row("paresnetoanterior") > 0 Then
                                row("incrementopares") = (row("paresnetoactual") - row("paresnetoanterior")) / row("paresnetoanterior") * 100
                            Else
                                row("incrementopares") = 0
                            End If
                            If row("impnetoanterior") > 0 Then
                                row("incrementoimporte") = (row("impnetoactual") - row("impnetoanterior")) / row("impnetoanterior") * 100
                            Else
                                row("incrementoimporte") = 0
                            End If
                        End If
                        dt.Rows.InsertAt(row, 0)
                        DGrid.DataSource = dt
                        ToolStripMenuItemSucursal.Visible = True
                        ToolStripMenuItemDivision.Visible = True
                        ToolStripMenuItemDepto.Visible = True
                        ToolStripMenuItemFamilia.Visible = True
                        ToolStripMenuItemLinea.Visible = True
                        ToolStripMenuItemL1.Visible = True
                        ToolStripMenuItemL2.Visible = True
                        ToolStripMenuItemL3.Visible = True
                        ToolStripMenuItemL4.Visible = True
                        ToolStripMenuItemL5.Visible = True
                        ToolStripMenuItemL6.Visible = False
                        ToolStripMenuItemMarca.Visible = True
                        ToolStripMenuItemModelo.Visible = True
                        ToolStripMenuItemAnaModelo.Visible = False
                        ToolStripMenuItemCatModelo.Visible = False
                        If blnBD = True Then
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L6")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", " + DGrid.Rows(1).Cells("l3").Value + ", " + DGrid.Rows(1).Cells("l4").Value + ", " + DGrid.Rows(1).Cells("l5").Value + ", L6"
                            End If
                        Else
                            If Sucursal = 0 Then
                                GeneraLabel(2, "L6")
                            Else
                                Lbl_Texto.Text = DGrid.Rows(1).Cells("Sucursal").Value + ", " + DGrid.Rows(1).Cells("division").Value + ", " + DGrid.Rows(1).Cells("depto").Value + ", " + DGrid.Rows(1).Cells("familia").Value + ", " + DGrid.Rows(1).Cells("linea").Value + ", " + DGrid.Rows(1).Cells("l1").Value + ", " + DGrid.Rows(1).Cells("l2").Value + ", " + DGrid.Rows(1).Cells("l3").Value + ", " + DGrid.Rows(1).Cells("l4").Value + ", " + DGrid.Rows(1).Cells("l5").Value + ", L6"
                            End If
                        End If
                        DGrid.Columns("l6").Frozen = True
                        DGrid.Columns("l6").DefaultCellStyle.BackColor = Color.PowderBlue
                        DGrid.Columns("l6").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                        DGrid.Columns("idsucursal").Visible = False
                        DGrid.Columns("sucursal").Visible = False
                        DGrid.Columns("iddivisiones").Visible = False
                        DGrid.Columns("division").Visible = False
                        DGrid.Columns("iddepto").Visible = False
                        DGrid.Columns("depto").Visible = False
                        DGrid.Columns("idfamilia").Visible = False
                        DGrid.Columns("familia").Visible = False
                        DGrid.Columns("idlinea").Visible = False
                        DGrid.Columns("linea").Visible = False
                        DGrid.Columns("idl1").Visible = False
                        DGrid.Columns("l1").Visible = False
                        DGrid.Columns("idl2").Visible = False
                        DGrid.Columns("l2").Visible = False
                        DGrid.Columns("idl3").Visible = False
                        DGrid.Columns("l3").Visible = False
                        DGrid.Columns("idl4").Visible = False
                        DGrid.Columns("l4").Visible = False
                        DGrid.Columns("idl5").Visible = False
                        DGrid.Columns("l5").Visible = False
                        DGrid.Columns("idl6").Visible = False
                        DGrid.Columns("idl6").HeaderText = "Idl6"
                        DGrid.Columns("l6").HeaderText = "L6"
                    End If
                    End If
                End If
            For i As Integer = 0 To DGrid.Columns.Count - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            If AñoAnterior = True Then
                DGrid.Columns("incrementopares").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("incrementopares").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns("incrementoimporte").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("incrementoimporte").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If
            DGrid.RowHeadersVisible = False

            DGrid.Columns("paresnetoactual").HeaderText = "Pares"
            DGrid.Columns("porcparesnetoac").HeaderText = "% Part."
            DGrid.Columns("paresnormalactual").HeaderText = "Pares Normal"
            DGrid.Columns("paresdescactual").HeaderText = "Pares Descto"
            DGrid.Columns("parespromactual").HeaderText = "Pares Promoción"
            DGrid.Columns("paresregactual").HeaderText = "Pares Regalo"
            DGrid.Columns("porcparesnormalac").HeaderText = "% Normal"
            DGrid.Columns("porcparesdescac").HeaderText = "% Descto"
            DGrid.Columns("porcparespromac").HeaderText = "% Promoción"
            DGrid.Columns("porcparesregac").HeaderText = "% Regalo"
            DGrid.Columns("impnetoactual").HeaderText = "Imp C/IVA (En Miles)"
            DGrid.Columns("porcimpnetoac").HeaderText = "% Part."
            DGrid.Columns("impnormalactual").HeaderText = "Imp C/IVA Normal (En Miles)"
            DGrid.Columns("impdescactual").HeaderText = "Imp C/IVA Descto (En Miles)"
            DGrid.Columns("imppromactual").HeaderText = "Imp C/IVA Promoción (En Miles)"
            DGrid.Columns("impregactual").HeaderText = "Imp C/IVA Regalo (En Miles)"
            DGrid.Columns("porcimpnormalac").HeaderText = "% Normal"
            DGrid.Columns("porcimpdescac").HeaderText = "% Descto"
            DGrid.Columns("porcimppromac").HeaderText = "% Promoción"
            DGrid.Columns("porcimpregac").HeaderText = "% Regalo"
            If AñoAnterior = True Then
                DGrid.Columns("paresnetoanterior").HeaderText = "Pares"
                DGrid.Columns("porcparesnetoan").HeaderText = "% Part."
                DGrid.Columns("paresnormalanterior").HeaderText = "Pares Normal"
                DGrid.Columns("paresdescanterior").HeaderText = "Pares Descto"
                DGrid.Columns("parespromanterior").HeaderText = "Pares Promoción"
                DGrid.Columns("paresreganterior").HeaderText = "Pares Regalo"
                DGrid.Columns("porcparesnormalan").HeaderText = "% Normal"
                DGrid.Columns("porcparesdescan").HeaderText = "% Descto"
                DGrid.Columns("porcparesproman").HeaderText = "% Promoción"
                DGrid.Columns("porcparesregan").HeaderText = "% Regalo"
                DGrid.Columns("impnetoanterior").HeaderText = "Imp C/IVA (En Miles)"
                DGrid.Columns("porcimpnetoan").HeaderText = "% Part."
                DGrid.Columns("impnormalanterior").HeaderText = "Imp C/IVA Normal (En Miles)"
                DGrid.Columns("impdescanterior").HeaderText = "Imp C/IVA Descto (En Miles)"
                DGrid.Columns("imppromanterior").HeaderText = "Imp C/IVA Promoción (En Miles)"
                DGrid.Columns("impreganterior").HeaderText = "Imp C/IVA Regalo (En Miles)"
                DGrid.Columns("porcimpnormalan").HeaderText = "% Normal"
                DGrid.Columns("porcimpdescan").HeaderText = "% Descto"
                DGrid.Columns("porcimpproman").HeaderText = "% Promoción"
                DGrid.Columns("porcimpregan").HeaderText = "% Regalo"
                DGrid.Columns("incrementopares").HeaderText = "%Inc. Pares"
                DGrid.Columns("incrementoimporte").HeaderText = "%Inc. Importe"
            End If
            DGrid.Columns("paresnetoactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("paresnormalactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("paresdescactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("parespromactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("paresregactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("impnetoactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("impnormalactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("impdescactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("imppromactual").DefaultCellStyle.Format = "###,###,##0"
            DGrid.Columns("impregactual").DefaultCellStyle.Format = "###,###,##0"
            If AñoAnterior = True Then
                DGrid.Columns("paresnetoanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("paresnormalanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("paresdescanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("parespromanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("paresreganterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("impnetoanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("impnormalanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("impdescanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("imppromanterior").DefaultCellStyle.Format = "###,###,##0"
                DGrid.Columns("impreganterior").DefaultCellStyle.Format = "###,###,##0"
            End If
            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns("porcparesnetoac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcparesnormalac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcparesdescac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcparespromac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcparesregac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcimpnetoac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcimpnormalac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcimpdescac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcimppromac").DefaultCellStyle.Format = "#0"
            DGrid.Columns("porcimpregac").DefaultCellStyle.Format = "#0"
            If AñoAnterior = True Then
                DGrid.Columns("porcparesnetoan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcparesnormalan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcparesdescan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcparesproman").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcparesregan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcimpnetoan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcimpnormalan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcimpdescan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcimpproman").DefaultCellStyle.Format = "#0"
                DGrid.Columns("porcimpregan").DefaultCellStyle.Format = "#0"
                DGrid.Columns("incrementopares").DefaultCellStyle.Format = "#0"
                DGrid.Columns("incrementoimporte").DefaultCellStyle.Format = "#0"
            End If
            DGrid.Columns("fecfina").Visible = False
            DGrid.Columns("fecfinb").Visible = False



            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            If Modelo = False Then
                AgregarColumna()
                If blnBorroCol = False And Marca = False Then
                    DGrid.Columns("Renglon").Visible = False
                End If
                blnBorroCol = True
                If Chk_Miles.Checked = True Then
                    For i As Integer = 0 To DGrid.Rows.Count - 2
                        If IsDBNull(DGrid.Rows(i).Cells("impnetoactual").Value) = False Then
                            DGrid.Rows(i).Cells("impnetoactual").Value = Math.Round(DGrid.Rows(i).Cells("impnetoactual").Value / 1000)
                        End If
                        If IsDBNull(DGrid.Rows(i).Cells("impnormalactual").Value) = False Then
                            DGrid.Rows(i).Cells("impnormalactual").Value = Math.Round(DGrid.Rows(i).Cells("impnormalactual").Value / 1000)
                        End If
                        If IsDBNull(DGrid.Rows(i).Cells("impdescactual").Value) = False Then
                            DGrid.Rows(i).Cells("impdescactual").Value = Math.Round(DGrid.Rows(i).Cells("impdescactual").Value / 1000)
                        End If
                        If IsDBNull(DGrid.Rows(i).Cells("imppromactual").Value) = False Then
                            DGrid.Rows(i).Cells("imppromactual").Value = Math.Round(DGrid.Rows(i).Cells("imppromactual").Value / 1000)
                        End If
                        If IsDBNull(DGrid.Rows(i).Cells("impregactual").Value) = False Then
                            DGrid.Rows(i).Cells("impregactual").Value = Math.Round(DGrid.Rows(i).Cells("impregactual").Value / 1000)
                        End If
                        If AñoAnterior = True Then
                            If IsDBNull(DGrid.Rows(i).Cells("impnetoanterior").Value) = False Then
                                DGrid.Rows(i).Cells("impnetoanterior").Value = Math.Round(DGrid.Rows(i).Cells("impnetoanterior").Value / 1000)
                            End If
                            If IsDBNull(DGrid.Rows(i).Cells("impnormalanterior").Value) = False Then
                                DGrid.Rows(i).Cells("impnormalanterior").Value = Math.Round(DGrid.Rows(i).Cells("impnormalanterior").Value / 1000)
                            End If
                            If IsDBNull(DGrid.Rows(i).Cells("impdescanterior").Value) = False Then
                                DGrid.Rows(i).Cells("impdescanterior").Value = Math.Round(DGrid.Rows(i).Cells("impdescanterior").Value / 1000)
                            End If
                            If IsDBNull(DGrid.Rows(i).Cells("imppromanterior").Value) = False Then
                                DGrid.Rows(i).Cells("imppromanterior").Value = Math.Round(DGrid.Rows(i).Cells("imppromanterior").Value / 1000)
                            End If
                            If IsDBNull(DGrid.Rows(i).Cells("impreganterior").Value) = False Then
                                DGrid.Rows(i).Cells("impreganterior").Value = Math.Round(DGrid.Rows(i).Cells("impreganterior").Value / 1000)
                            End If
                        End If
                        If i > 0 Then
                            DGrid.Rows(i).Cells("Renglon").Value = i.ToString
                        End If
                    Next
                    DGrid.Columns("impnetoactual").DefaultCellStyle.Format = ""
                    DGrid.Columns("impnormalactual").DefaultCellStyle.Format = ""
                    DGrid.Columns("impdescactual").DefaultCellStyle.Format = ""
                    DGrid.Columns("imppromactual").DefaultCellStyle.Format = ""
                    DGrid.Columns("impregactual").DefaultCellStyle.Format = ""
                    If AñoAnterior = True Then
                        DGrid.Columns("impnetoanterior").DefaultCellStyle.Format = ""
                        DGrid.Columns("impnormalanterior").DefaultCellStyle.Format = ""
                        DGrid.Columns("impdescanterior").DefaultCellStyle.Format = ""
                        DGrid.Columns("imppromanterior").DefaultCellStyle.Format = ""
                        DGrid.Columns("impreganterior").DefaultCellStyle.Format = ""
                    End If
                Else
                    DGrid.Columns("impnetoactual").DefaultCellStyle.Format = "c"
                    DGrid.Columns("impnormalactual").DefaultCellStyle.Format = "c"
                    DGrid.Columns("impdescactual").DefaultCellStyle.Format = "c"
                    DGrid.Columns("imppromactual").DefaultCellStyle.Format = "c"
                    DGrid.Columns("impregactual").DefaultCellStyle.Format = "c"
                    If AñoAnterior = True Then
                        DGrid.Columns("impnetoanterior").DefaultCellStyle.Format = "c"
                        DGrid.Columns("impnormalanterior").DefaultCellStyle.Format = "c"
                        DGrid.Columns("impdescanterior").DefaultCellStyle.Format = "c"
                        DGrid.Columns("imppromanterior").DefaultCellStyle.Format = "c"
                        DGrid.Columns("impreganterior").DefaultCellStyle.Format = "c"
                    End If
                    DGrid.Columns("impnetoactual").HeaderText = "Imp C/IVA"
                    DGrid.Columns("impnormalactual").HeaderText = "Imp C/IVA Normal"
                    DGrid.Columns("impdescactual").HeaderText = "Imp C/IVA Descto"
                    DGrid.Columns("imppromactual").HeaderText = "Imp C/IVA Promoción"
                    DGrid.Columns("impregactual").HeaderText = "Imp C/IVA Regalo"
                    If AñoAnterior = True Then
                        DGrid.Columns("impnetoanterior").HeaderText = "Imp C/IVA"
                        DGrid.Columns("impnormalanterior").HeaderText = "Imp C/IVA Normal"
                        DGrid.Columns("impdescanterior").HeaderText = "Imp C/IVA Descto"
                        DGrid.Columns("imppromanterior").HeaderText = "Imp C/IVA Promoción"
                        DGrid.Columns("impreganterior").HeaderText = "Imp C/IVA Regalo"
                    End If
                End If
            Else
                DGrid.Columns("renglon").Frozen = True
                DGrid.Columns("renglon").DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns("renglon").DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                'For i As Integer = 0 To DGrid.Rows.Count - 1
                '    If Chk_Miles.Checked = False Then
                '        If IsDBNull(DGrid.Rows(i).Cells("impnetoactual").Value) = False Then
                '            DGrid.Rows(i).Cells("impnetoactual").Value = Math.Round(DGrid.Rows(i).Cells("impnetoactual").Value * 1000)
                '        End If
                '        If IsDBNull(DGrid.Rows(i).Cells("impnormalactual").Value) = False Then
                '            DGrid.Rows(i).Cells("impnormalactual").Value = Math.Round(DGrid.Rows(i).Cells("impnormalactual").Value * 1000)
                '        End If
                '        If IsDBNull(DGrid.Rows(i).Cells("impdescactual").Value) = False Then
                '            DGrid.Rows(i).Cells("impdescactual").Value = Math.Round(DGrid.Rows(i).Cells("impdescactual").Value * 1000)
                '        End If
                '        If IsDBNull(DGrid.Rows(i).Cells("imppromactual").Value) = False Then
                '            DGrid.Rows(i).Cells("imppromactual").Value = Math.Round(DGrid.Rows(i).Cells("imppromactual").Value * 1000)
                '        End If
                '        If IsDBNull(DGrid.Rows(i).Cells("impregactual").Value) = False Then
                '            DGrid.Rows(i).Cells("impregactual").Value = Math.Round(DGrid.Rows(i).Cells("impregactual").Value * 1000)
                '        End If
                '        If AñoAnterior = True Then
                '            If IsDBNull(DGrid.Rows(i).Cells("impnetoanterior").Value) = False Then
                '                DGrid.Rows(i).Cells("impnetoanterior").Value = Math.Round(DGrid.Rows(i).Cells("impnetoanterior").Value * 1000)
                '            End If
                '            If IsDBNull(DGrid.Rows(i).Cells("impnormalanterior").Value) = False Then
                '                DGrid.Rows(i).Cells("impnormalanterior").Value = Math.Round(DGrid.Rows(i).Cells("impnormalanterior").Value * 1000)
                '            End If
                '            If IsDBNull(DGrid.Rows(i).Cells("impdescanterior").Value) = False Then
                '                DGrid.Rows(i).Cells("impdescanterior").Value = Math.Round(DGrid.Rows(i).Cells("impdescanterior").Value * 1000)
                '            End If
                '            If IsDBNull(DGrid.Rows(i).Cells("imppromanterior").Value) = False Then
                '                DGrid.Rows(i).Cells("imppromanterior").Value = Math.Round(DGrid.Rows(i).Cells("imppromanterior").Value * 1000)
                '            End If
                '            If IsDBNull(DGrid.Rows(i).Cells("impreganterior").Value) = False Then
                '                DGrid.Rows(i).Cells("impreganterior").Value = Math.Round(DGrid.Rows(i).Cells("impreganterior").Value * 1000)
                '            End If
                '        End If
                '    End If
                '    If i > 0 Then
                '        DGrid.Rows(i).Cells("Renglon").Value = i.ToString
                '    End If
                'Next
            End If
            If Modelo = False Then
                FechaFinA = DGrid.Rows(1).Cells("FecFinA").Value
                FechaFinB = DGrid.Rows(1).Cells("FecFinB").Value

                Lbl_FecIni.Text = CDate(FechaInicioA).ToString("dd/MMM/yyyy").ToUpper + " - " + CDate(FechaInicioB).ToString("dd/MMM/yyyy").ToUpper
                If AñoAnterior = True Then
                    Lbl_FecFin.Text = "ANTERIOR: " + CDate(FechaFinA).ToString("dd/MMM/yyyy").ToUpper + " - " + CDate(FechaFinB).ToString("dd/MMM/yyyy").ToUpper
                Else
                    Lbl_FecFin.Text = ""
                End If
            End If
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'AgregarColumna()
            'If blnBorroCol = False Then
            '    DGrid.Columns("Renglon").Visible = False
            'End If
            'blnBorroCol = True
            'For i As Integer = 1 To DGrid.Rows.Count - 2
            '    DGrid.Rows(i).Cells("Renglon").Value = i.ToString
            'Next
            DGrid.Columns("parespromactual").Visible = False
            DGrid.Columns("porcparespromac").Visible = False
            DGrid.Columns("imppromactual").Visible = False
            DGrid.Columns("porcimppromac").Visible = False
            If AñoAnterior = True Then
                DGrid.Columns("parespromanterior").Visible = False
                DGrid.Columns("porcparesproman").Visible = False
                DGrid.Columns("imppromanterior").Visible = False
                DGrid.Columns("porcimpproman").Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalNumValesPorNegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myFormFiltros = New frmFiltrosVentasDWH
            If GLB_CveSucursal = "" Then
                Sucursal = 0
            Else
                If CInt(GLB_CveSucursal) < 35 And CInt(GLB_CveSucursal) > 0 Then
                    Sucursal = CInt(GLB_CveSucursal)
                    Chk_Lerdo.Visible = False
                    Chk_AnioAnterior.Visible = False
                    Chk_AnioAnterior1.Visible = False
                    Chk_Miles.Visible = False
                    ToolStripMenuItemPlaza.Enabled = False
                    ToolStripMenuItemSucursal.Enabled = False

                Else
                    Sucursal = 0
                    Chk_Lerdo.Visible = True
                    Chk_AnioAnterior.Visible = True
                    Chk_AnioAnterior1.Visible = True
                    Chk_Miles.Visible = True
                End If
            End If

            'Division = 1   'mreyes 14/Mayo/2018    05:28 p.m.
            Division = 0
            FechaInicioA = GLB_FechaHoy.ToString("yyyy-MM-dd")
            FechaInicioB = GLB_FechaHoy.ToString("yyyy-MM-dd")
            strAñoActual = CDate(FechaInicioA).ToString("yyyy")
            strAñoAnterior = CDate(FechaInicioA).AddYears(-1).ToString("yyyy")
            If GLB_Sw_Plaza = True Then
                Opcion = 1
            Else
                'Opcion = 2
                Opcion = 3 'mreyes 14/Mayo/2018    05:28 p.m.
            End If
            '  Chk_Miles.Checked = True
            RellenaGrid()
            Sw_Pintar = True
            InicializaGrid()
            Sw_Load = False
            GenerarToolTip()
            Lbl_Renglones.Visible = False
            'blnBorroCol = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtros, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Regresar, "Regresar al nivel anterior")
            ToolTip.SetToolTip(Btn_Actualizar, "Cargar ventas de Hoy")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If blnEntro = False Then
            blnEntro = True
            DGrid.Columns("Renglon").Visible = True
            For i As Integer = 0 To DGrid.RowCount - 2
                If i = 0 Then Continue For
                DGrid.Rows(i).Cells("Renglon").Value = i.ToString()
            Next
            DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
        End If
    End Sub

    Private Sub RellenaGrid()

        Using objRepVentasNetas As New BCL.BCLVentas(GLB_ConStringDWH)

            Try

                If GLB_IdDeptoEmpleado = 1 Or GLB_IdDeptoEmpleado = 8 Or GLB_IdDeptoEmpleado = 0 Then
                    If Plaza = 1 Then '' YA SELECCIONO UNA PLAZA 
                        Plaza = 1
                    Else
                        Plaza = 0
                    End If
                Else
                        Plaza = 1
                End If

                Dim MInicioB As String = "S"
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.Visible = False
                DGrid.DataSource = Nothing
                EliminarTotal()
                Dim blnCambio As Boolean = False
                'If Chk_Lerdo.Checked = False Then
                '    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                '        blnCambio = objSucursal.usp_ActualizarSucursal("98", "N")
                '    End Using
                'End If
                If Chk_Lerdo.Checked = True Then
                    MInicioB = "N"
                End If
                Dim DataSetAuxiliar As Data.DataSet
                If RegresoModelo = False Then
                    If Marca = False Then
                        If Opcion = 1 Then
                            'mreyes 13/Octubre/2015 12:10 p.m.
                            ' Se cambio a Plaza
                            If ToolStripMenuItemSucursal.Enabled = False Then
                                Sucursal = GLB_CveSucursal
                            End If
                            objDataSet = objRepVentasNetas.usp_PpalVentasPlaza(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                            If objDataSet.Tables(0).Rows.Count < 1 Then
                                If CDate(FechaInicioA) = GLB_FechaHoy Then
                                    FechaInicioA = CDate(FechaInicioA).AddDays(-1).ToString("yyyy-MM-dd")
                                    FechaInicioB = CDate(FechaInicioB).AddDays(-1).ToString("yyyy-MM-dd")
                                    objDataSet = objRepVentasNetas.usp_PpalVentasPlaza(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                                End If
                            End If

                        ElseIf Opcion = 2 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentas(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                            If objDataSet.Tables(0).Rows.Count < 1 Then
                                If CDate(FechaInicioA) = GLB_FechaHoy Then
                                    FechaInicioA = CDate(FechaInicioA).AddDays(-1).ToString("yyyy-MM-dd")
                                    FechaInicioB = CDate(FechaInicioB).AddDays(-1).ToString("yyyy-MM-dd")
                                    objDataSet = objRepVentasNetas.usp_PpalVentas(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                                End If
                            End If


                        ElseIf Opcion = 3 Then

                            objDataSet = objRepVentasNetas.usp_PpalVentasDivisiones(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                            If objDataSet.Tables(0).Rows.Count < 1 Then
                                If CDate(FechaInicioA) = GLB_FechaHoy Then
                                    FechaInicioA = CDate(FechaInicioA).AddDays(-1).ToString("yyyy-MM-dd")
                                    FechaInicioB = CDate(FechaInicioB).AddDays(-1).ToString("yyyy-MM-dd")
                                    objDataSet = objRepVentasNetas.usp_PpalVentasDivisiones(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                                End If
                            End If


                            'objDataSet = objRepVentasNetas.usp_PpalVentasDivisiones(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 4 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasDepto(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 5 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasFamilia(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 6 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasLinea(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 7 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasL1(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 8 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasL2(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 9 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasL3(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 10 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasL4(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 11 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasL5(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        ElseIf Opcion = 12 Then
                            objDataSet = objRepVentasNetas.usp_PpalVentasL6(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        End If
                        'If blnCambio = True Then
                        '    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                        '        blnCambio = objSucursal.usp_ActualizarSucursal("98", "S")
                        '    End Using
                        'End If
                    Else
                        Dim Miles As Integer = 0
                        If Chk_Miles.Checked Then
                            Miles = 1000
                        Else
                            Miles = 1
                        End If
                        objDataSet = objRepVentasNetas.usp_PpalVentasMarcaModelo(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, Miles, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        DataSetAuxiliar = objDataSet.Clone
                        'If blnCambio = True Then
                        '    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                        '        blnCambio = objSucursal.usp_ActualizarSucursal("98", "S")
                        '    End Using
                        'End If
                        Marca = False
                        Modelo = True
                    End If
                Else
                    OpcionLineas()
                    objDataSet = objRepVentasNetas.usp_PpalVentasMarca(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                    'If blnCambio = True Then
                    '    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                    '        blnCambio = objSucursal.usp_ActualizarSucursal("98", "S")
                    '    End Using
                    'End If
                    'InicializaGrid()
                    DGrid.DataSource = Nothing
                    DGrid.DataSource = objDataSet.Tables(0)

                    Me.Cursor = Cursors.Default
                    Marca = True
                    Modelo = False
                    RegresoModelo = False
                End If
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    If Modelo = True Then
                        DGrid.DataSource = DataSetAuxiliar.Tables(0)
                        InicializaGrid()
                        DGrid.DataSource = objDataSet.Tables(0)
                        SumaModelo()
                    Else
                        DGrid.DataSource = Nothing
                        DGrid.DataSource = objDataSet.Tables(0)
                        If Sw_Load = False Then
                            InicializaGrid()
                        End If
                    End If

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    If Sw_Load = False Then
                        OpcionLineas()
                        OpcionLinea -= 1
                        objDataSet = objRepVentasNetas.usp_PpalVentasMarca(FechaInicioA, FechaInicioB, Plaza, Sucursal, Division, Departamento, FamiliaDescrip, LineaDescrip, L1Descrip, L2Descrip, L3Descrip, L4Descrip, L5Descrip, L6Descrip, strMarca, strModelo, FecRecA, FecRecB, AñoAnterior, idAgrupacionB, AñoAnteriorIgual, MInicioB)
                        'If blnCambio = True Then
                        '    Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                        '        blnCambio = objSucursal.usp_ActualizarSucursal("98", "S")
                        '    End Using
                        'End If
                        'InicializaGrid()
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            sinLinea = True
                            DGrid.DataSource = Nothing
                            DGrid.DataSource = objDataSet.Tables(0)
                            Marca = True
                            InicializaGrid()
                            Me.Cursor = Cursors.Default
                        Else
                            DGrid.DataSource = Nothing
                            MessageBox.Show("No se encontro información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    End If
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    'MessageBox.Show("No se encontro Información", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

                GeneraTexto()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                'Using objSucursal As New BCL.BCLVentas(GLB_ConStringDWH)
                '    objSucursal.usp_ActualizarSucursal("98", "S")
                'End Using
                Me.Cursor = Cursors.Default
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GeneraTexto()

        'PLAZA
        If Plaza = 0 Then
            Lbl_Plaza.Text = "TODAS LAS PLAZAS"
        ElseIf Plaza = 1 Then
            Lbl_Plaza.Text = "TORREÓN"
        ElseIf Plaza = 2 Then
            Lbl_Plaza.Text = "EN LÍNEA"

        End If



        'SUCURSALES
        If Sucursal = 0 Then
            lbl_Suc.Text = "TODAS LAS SUCURSALES"
        ElseIf Sucursal = 1 Then
            lbl_Suc.Text = "JUAREZ"
        ElseIf Sucursal = 2 Then
            lbl_Suc.Text = "HIDALGO"
        ElseIf Sucursal = 6 Then
            lbl_Suc.Text = "TRIANA"
        ElseIf Sucursal = 7 Then
            lbl_Suc.Text = "LERDO"
        ElseIf Sucursal = 8 Then
            lbl_Suc.Text = "MATRIZ"
        ElseIf Sucursal = 11 Then
            lbl_Suc.Text = "MONTERREY"
        ElseIf Sucursal = "98" Then
            lbl_Suc.Text = "INVENTARIO"
        End If
        'DIVISIONES
        If Division = 0 Then
            If Opcion = 2 Then
                lbl_Div.Text = "DIVISIONES"
            Else
                lbl_Div.Text = ""
            End If
        Else
            If Division = 1 Then
                lbl_Div.Text = "CALZADO"
            ElseIf Division = 2 Then
                lbl_Div.Text = "ACCESORIOS"
            ElseIf Division = 3 Then
                lbl_Div.Text = "ELECTRONICA"
            ElseIf Division = 4 Then
                lbl_Div.Text = "GENERAL"
            End If
        End If
        'DEPARTAMENTO
        If Departamento = 0 Then
            If Opcion = 3 Then
                lbl_dep.Text = "DEPARTAMENTO"
            Else
                lbl_dep.Text = ""
            End If
        Else
            If Departamento = 1 Then
                lbl_dep.Text = "DAMAS"
            ElseIf Departamento = 2 Then
                lbl_dep.Text = "CABALLEROS"
            ElseIf Departamento = 8 Then
                lbl_dep.Text = "ACCESORIOS CALZADO"
            ElseIf Departamento = 9 Then
                lbl_dep.Text = "ACCESORIOS ESCOLARES"
            ElseIf Departamento = 10 Then
                lbl_dep.Text = "ACCESORIOS CALCETINES"
            ElseIf Departamento = 11 Then
                lbl_dep.Text = "CUIDADO DE CALZADO"
            ElseIf Departamento = 12 Then
                lbl_dep.Text = "ACCESORIOS CABALLERO"
            ElseIf Departamento = 13 Then
                lbl_dep.Text = "ACCESORIOS DAMA"
            ElseIf Departamento = 14 Then
                lbl_dep.Text = "ACCESORIOS DEPORTIVOS"
            ElseIf Departamento = 15 Then
                lbl_dep.Text = "INFANTIL"
            ElseIf Departamento = 16 Then
                lbl_dep.Text = "BEBES"
            ElseIf Departamento = 17 Then
                lbl_dep.Text = "CELULARES"
            ElseIf Departamento = 18 Then
                lbl_dep.Text = "GENERAL"
            Else
                lbl_dep.Text = ""
            End If
        End If
        'FAMILIA
        If FamiliaDescrip = "" Then
            If Opcion = 4 Then
                lbl_Fam.Text = "FAMILIA"
            Else
                lbl_Fam.Text = ""
            End If
        Else
            lbl_Fam.Text = FamiliaDescrip
        End If
        If LineaDescrip = "" Then
            If Opcion = 5 Then
                lbl_Lin.Text = "LINEA"
            Else
                lbl_Lin.Text = ""
            End If
        Else
            lbl_Lin.Text = LineaDescrip
        End If
        If L1Descrip = "" Then
            If Opcion = 6 Then
                lbl_L1.Text = "L1"
            Else
                lbl_L1.Text = ""
            End If
        Else
            lbl_L1.Text = L1Descrip
        End If
        If L2Descrip = "" Then
            If Opcion = 7 Then
                lbl_L2.Text = "L2"
            Else
                lbl_L2.Text = ""
            End If
        Else
            lbl_L2.Text = L2Descrip
        End If
        If L3Descrip = "" Then
            If Opcion = 8 Then
                lbl_L3.Text = "L3"
            Else
                lbl_L3.Text = ""
            End If
        Else
            lbl_L3.Text = L3Descrip
        End If
        If L4Descrip = "" Then
            If Opcion = 9 Then
                lbl_L4.Text = "L4"
            Else
                lbl_L4.Text = ""
            End If
        Else
            lbl_L4.Text = L4Descrip
        End If
        If L5Descrip = "" Then
            If Opcion = 10 Then
                lbl_L5.Text = "L5"
            Else
                lbl_L5.Text = ""
            End If
        Else
            lbl_L5.Text = L5Descrip
        End If
        If L6Descrip = "" Then
            If Opcion = 11 Then
                lbl_L6.Text = "L6"
            Else
                lbl_L6.Text = ""
            End If
        Else
            lbl_L6.Text = L6Descrip
        End If
        If strMarca = "" Then
            If Marca = True Then
                lbl_Mar.Text = "MARCAS"
            Else
                lbl_Mar.Text = ""
            End If
        Else
            lbl_Mar.Text = strMarca
        End If
        If strModelo = "" Then
            If Modelo = True Then
                lbl_Modelo.Text = "MODELOS"
            Else
                lbl_Modelo.Text = ""
            End If
        Else
            lbl_Modelo.Text = strModelo
        End If

        If lbl_Suc.Text.Trim <> "" Then
            lbl_Final.Text = Lbl_Plaza.Text
        End If

        If lbl_Suc.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Suc.Text
        End If
        If lbl_Div.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Div.Text
        End If
        If lbl_dep.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_dep.Text
        End If
        If lbl_Fam.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Fam.Text
        End If
        If lbl_Lin.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Lin.Text
        End If
        If lbl_L1.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L1.Text
        End If
        If lbl_L2.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L2.Text
        End If
        If lbl_L3.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L3.Text
        End If
        If lbl_L4.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L4.Text
        End If
        If lbl_L5.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L5.Text
        End If
        If lbl_L6.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_L6.Text
        End If
        If lbl_Mar.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Mar.Text
        End If
        If lbl_Modelo.Text.Trim <> "" Then
            lbl_Final.Text += ", " + lbl_Modelo.Text
        End If

        Me.Text = "Estadística de Ventas: " + lbl_Final.Text
    End Sub

    Private Sub EliminarTotal()
        If FamiliaDescrip = "TOTAL: " Then
            FamiliaDescrip = ""
        End If
        If LineaDescrip = "TOTAL: " Then
            LineaDescrip = ""
        End If
        If L1Descrip = "TOTAL: " Then
            L1Descrip = ""
        End If
        If L2Descrip = "TOTAL: " Then
            L2Descrip = ""
        End If
        If L3Descrip = "TOTAL: " Then
            L3Descrip = ""
        End If
        If L4Descrip = "TOTAL: " Then
            L4Descrip = ""
        End If
        If L5Descrip = "TOTAL: " Then
            L5Descrip = ""
        End If
        If L6Descrip = "TOTAL: " Then
            L6Descrip = ""
        End If
    End Sub

    Private Sub OpcionLineas()
        If Opcion <= 5 Then
            OpcionLinea = 1
        ElseIf Opcion = 6 Then
            OpcionLinea = 2
        ElseIf Opcion = 7 Then
            OpcionLinea = 3
        ElseIf Opcion = 8 Then
            OpcionLinea = 4
        ElseIf Opcion = 9 Then
            OpcionLinea = 5
        ElseIf Opcion = 10 Then
            OpcionLinea = 6
        ElseIf Opcion = 11 Then
            OpcionLinea = 7
        End If
    End Sub

    Private Sub DibujaGrafica()

        Dim dt As New DataTable
        dt = DGrid.DataSource
        Dim strOpcion As String = ""
        If Modelo = True Then
            strOpcion = "modelo"
        Else
            If Marca = True Then
                strOpcion = "marca"
            Else
                If Opcion = 1 Then
                    strOpcion = "sucursal"
                ElseIf Opcion = 2 Then
                    strOpcion = "division"
                ElseIf Opcion = 3 Then
                    strOpcion = "depto"
                ElseIf Opcion = 4 Then
                    strOpcion = "familia"
                ElseIf Opcion = 5 Then
                    strOpcion = "linea"
                ElseIf Opcion = 6 Then
                    strOpcion = "l1"
                ElseIf Opcion = 7 Then
                    strOpcion = "l2"
                ElseIf Opcion = 8 Then
                    strOpcion = "l3"
                ElseIf Opcion = 9 Then
                    strOpcion = "l4"
                ElseIf Opcion = 10 Then
                    strOpcion = "l5"
                ElseIf Opcion = 11 Then
                    strOpcion = "l6"
                End If
            End If
        End If
        If DGrid.Columns(DGrid.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = Color.PowderBlue Then
            MessageBox.Show("Seleccione una columna diferente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim str As String = ""
        Dim num As Integer = 0
        Dim myForm As New frmConsultaVentasDWH
        Dim col As String = DGrid.Columns(DGrid.CurrentCell.ColumnIndex).Name
        For i As Integer = 0 To dt.Rows.Count - 1
            If IsDBNull(dt.Rows(i).Item(0)) Then Continue For
            If dt.Rows(i).Item(col).ToString.Trim = "" Then Continue For
            str = dt.Rows(i).Item(strOpcion).ToString
            num = dt.Rows(i).Item(col).ToString
            myForm.Crt_Porcentajes.Series(0).Points.AddXY(str + " " + num.ToString, num)
        Next
        myForm.Crt_Porcentajes.Series(0).YValueType = DataVisualization.Charting.ChartValueType.String
        myForm.Crt_Porcentajes.Series(0).YValuesPerPoint = 1
        myForm.Text = "Gráfica " + strOpcion.ToUpper
        myForm.Label1.Text = lbl_Final.Text
        myForm.StartPosition = FormStartPosition.CenterScreen
        myForm.lbl_Periodo.Text = "PERIODO ACTUAL: " + Lbl_FecIni.Text + " " + Lbl_FecFin.Text
        myForm.Label2.Text = DGrid.Columns(DGrid.CurrentCell.ColumnIndex).HeaderText
        myForm.Show()
    End Sub

    Private Sub AgregarColumna()
        Try
            Dim colRenglon As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
            colRenglon.Name = "Renglon"
            colRenglon.HeaderText = "Ren"
            colRenglon.Frozen = True
            colRenglon.DefaultCellStyle.BackColor = Color.PowderBlue
            colRenglon.DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            colRenglon.DisplayIndex = 0
            colRenglon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colRenglon.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colRenglon.CellTemplate = New DataGridViewTextBoxCell

            'colPorcentaje.DefaultCellStyle.Format = "%"
            'colPorcentaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            Me.DGrid.Columns.Add(colRenglon)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            'Btn_Regresar_Click(sender, e)
            Me.Close()
        End If
        If (e.KeyCode = Keys.F12) Then
            If Lbl_Renglones.Visible = False Then
                Lbl_Renglones.Visible = True
            Else
                Lbl_Renglones.Visible = False
            End If
        End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
      
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            'If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then Exit Sub
            Dim txt As String = ""
            If Modelo = True Then
                Exit Sub
            End If
            blnDoubleClick = True
            If Agrupacion = False Then
                If Marca = False Then
                    If Opcion = 1 Or Opcion = 2 Then
                        If Opcion = 1 Then
                            If IsDBNull(DGrid.CurrentRow.Cells("idplaza").Value) Then
                                Plaza = 0
                                txt = "TODAS"
                            Else
                                Plaza = DGrid.CurrentRow.Cells("idplaza").Value
                                txt = DGrid.CurrentRow.Cells("plaza").Value
                            End If
                            If GLB_Sw_Plaza = True Then
                                arreglo(intArreglo) = Opcion
                            Else
                                arreglo(0) = 0
                            End If
                            intArreglo += 1
                            Opcion = 2
                            RellenaGrid()
                            lbl_Mensaje.Text = txt
                            blnDoubleClick = False
                            Exit Sub
                        Else
                            If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                                Sucursal = 0
                                txt = "TODAS"
                            Else
                                Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                                txt = DGrid.CurrentRow.Cells("sucursal").Value
                            End If
                            arreglo(intArreglo) = Opcion
                            intArreglo += 1
                            Opcion = 3
                            RellenaGrid()
                            lbl_Mensaje.Text += " ," + txt
                            blnDoubleClick = False
                            Exit Sub
                        End If
                        End If
                    '' cambiar desde el dos para plaza
                    '' mreyes   13/Octubre/2015 04:59 p.m.
                    If Opcion = 3 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                            If Division = 0 Then
                                Division = 0
                                txt = "DIVISIONES"
                            Else
                                txt = "DIVISIONES"
                            End If
                        Else
                            Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                            txt = DGrid.CurrentRow.Cells("Division").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 4
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 4 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        Else
                            Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                            txt = DGrid.CurrentRow.Cells("depto").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 5
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 5 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                            Familia = 0
                        Else
                            Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        Else
                            FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                            txt = DGrid.CurrentRow.Cells("Familia").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 6
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 6 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                            Linea = 0
                        Else
                            Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        Else
                            LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                            txt = DGrid.CurrentRow.Cells("linea").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 7
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 7 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        '    Linea = 0
                        'Else
                        '    Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                            L1 = 0
                        Else
                            L1 = DGrid.CurrentRow.Cells("idl1").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            L1Descrip = ""
                            txt = "L1"
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 8
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 8 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        '    Linea = 0
                        'Else
                        '    Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        '    L1 = 0
                        'Else
                        '    L1 = DGrid.CurrentRow.Cells("idl1").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                            L2 = 0
                        Else
                            L2 = DGrid.CurrentRow.Cells("idl2").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            L2Descrip = ""
                            txt = "L2"
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 9
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 9 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        '    Linea = 0
                        'Else
                        '    Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        '    L1 = 0
                        'Else
                        '    L1 = DGrid.CurrentRow.Cells("idl1").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        '    L2 = 0
                        'Else
                        '    L2 = DGrid.CurrentRow.Cells("idl2").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                            L3 = 0
                        Else
                            L3 = DGrid.CurrentRow.Cells("idl3").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            L3Descrip = ""
                            txt = "L3"
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 10
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 10 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        '    Linea = 0
                        'Else
                        '    Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        '    L1 = 0
                        'Else
                        '    L1 = DGrid.CurrentRow.Cells("idl1").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        '    L2 = 0
                        'Else
                        '    L2 = DGrid.CurrentRow.Cells("idl2").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        '    L3 = 0
                        'Else
                        '    L3 = DGrid.CurrentRow.Cells("idl3").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                            L4 = 0
                        Else
                            L4 = DGrid.CurrentRow.Cells("idl4").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            L4Descrip = ""
                            txt = "L4"
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("l4").Value
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 11
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 11 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        '    Linea = 0
                        'Else
                        '    Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        '    L1 = 0
                        'Else
                        '    L1 = DGrid.CurrentRow.Cells("idl1").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        '    L2 = 0
                        'Else
                        '    L2 = DGrid.CurrentRow.Cells("idl2").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        '    L3 = 0
                        'Else
                        '    L3 = DGrid.CurrentRow.Cells("idl3").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                        '    L4 = 0
                        'Else
                        '    L4 = DGrid.CurrentRow.Cells("idl4").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idl5").Value) Then
                            L5 = 0
                        Else
                            L5 = DGrid.CurrentRow.Cells("idl5").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            L5Descrip = ""
                            txt = "L5"
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("l5").Value
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        arreglo(intArreglo) = Opcion
                        intArreglo += 1
                        Opcion = 12
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                    If Opcion = 12 Then
                        'If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        '    Sucursal = 0
                        'Else
                        '    Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        '    Division = 0
                        'Else
                        '    Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        '    Departamento = 0
                        'Else
                        '    Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        '    Familia = 0
                        'Else
                        '    Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        '    Linea = 0
                        'Else
                        '    Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        '    L1 = 0
                        'Else
                        '    L1 = DGrid.CurrentRow.Cells("idl1").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        '    L2 = 0
                        'Else
                        '    L2 = DGrid.CurrentRow.Cells("idl2").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        '    L3 = 0
                        'Else
                        '    L3 = DGrid.CurrentRow.Cells("idl3").Value
                        'End If
                        'If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                        '    L4 = 0
                        'Else
                        '    L4 = DGrid.CurrentRow.Cells("idl4").Value
                        'End If
                        If IsDBNull(DGrid.CurrentRow.Cells("idl6").Value) Then
                            L6 = 0
                        Else
                            L6 = DGrid.CurrentRow.Cells("idl6").Value
                        End If
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            L6Descrip = ""
                            txt = "L6"
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("l6").Value
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        RegresoModelo = True
                        RellenaGrid()
                        lbl_Mensaje.Text += " ," + txt
                        blnDoubleClick = False
                        Exit Sub
                    End If
                Else
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        strMarca = ""
                    Else
                        strMarca = DGrid.CurrentRow.Cells("marca").Value
                    End If
                    RellenaGrid()
                    blnDoubleClick = False
                    RegresoModelo = True
                    Exit Sub
                End If
            Else
                If OpcionAgrupacion = 2 Then
                    Sucursal = 0
                End If
                intAgrupacion = DGrid.CurrentRow.Cells("idagrupacion").Value
                RegresoModelo = True
                Agrupacion = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            End If
            blnDoubleClick = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If ToolStripMenuItemSucursal.Enabled = False Then
                Sucursal = GLB_CveSucursal
            End If

            PBox.Visible = False
            blnDoubleClick = True
            If Agrupacion = True Then
                Agrupacion = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            End If
            If Marca = True Then
                Marca = False
                'If Opcion = 1 Then
                '    Btn_Agrupacion_Click(sender, e)
                'End If
                If sinLinea = True Then
                    If Opcion > 1 Then
                        Opcion = Opcion - 1
                        intArreglo -= 1
                    End If
                    sinLinea = False
                End If
                If Opcion = 12 Then
                    L6Descrip = ""
                ElseIf Opcion = 11 Then
                    L5Descrip = ""
                ElseIf Opcion = 10 Then
                    L4Descrip = ""
                ElseIf Opcion = 9 Then
                    L3Descrip = ""
                ElseIf Opcion = 8 Then
                    L2Descrip = ""
                ElseIf Opcion = 7 Then
                    L1Descrip = ""
                ElseIf Opcion = 6 Then
                    LineaDescrip = ""
                ElseIf Opcion = 5 Then
                    FamiliaDescrip = ""
                ElseIf Opcion = 4 Then
                    Departamento = 0
                ElseIf Opcion = 3 Then
                    Division = 0
                ElseIf Opcion = 2 Then
                    If ToolStripMenuItemSucursal.Enabled = False Then
                        Sucursal = GLB_CveSucursal
                    Else
                        Sucursal = 0
                    End If
                ElseIf Opcion = 1 Then
                    Plaza = 0
                End If
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            End If
            If Modelo = True Then
                'RegresoModelo = True 
                If RegresoModelo = False Then
                    If Opcion = 1 Then
                        Plaza = 0
                    ElseIf Opcion = 2 Then
                        If ToolStripMenuItemSucursal.Enabled = False Then
                            Sucursal = GLB_CveSucursal
                        Else
                            Sucursal = 0
                        End If

                    ElseIf Opcion = 3 Then
                        Division = 0
                    ElseIf Opcion = 4 Then
                        Departamento = 0
                    ElseIf Opcion = 5 Then
                        FamiliaDescrip = ""
                    ElseIf Opcion = 6 Then
                        LineaDescrip = ""
                    ElseIf Opcion = 7 Then
                        L1Descrip = ""
                    ElseIf Opcion = 8 Then
                        L2Descrip = ""
                    ElseIf Opcion = 9 Then
                        L3Descrip = ""
                    ElseIf Opcion = 10 Then
                        L4Descrip = ""
                    ElseIf Opcion = 11 Then
                        L5Descrip = ""
                    ElseIf Opcion = 12 Then
                        L6Descrip = ""
                    End If
                End If
                strMarca = ""
                Modelo = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            End If
            If Opcion = 1 Then
                Me.Close()
                Exit Sub
            End If
            intArreglo -= 1
            If GLB_Sw_Plaza = True Then
                Opcion = arreglo(intArreglo)
            Else
                Opcion = 1
            End If
            If Opcion = 12 Then
                'Opcion = 10
                L6 = 0
                L6Descrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 11 Then
                'L6 = 0
                L5 = 0
                'L6Descrip = ""
                L5Descrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 10 Then
                'L6 = 0
                'L5 = 0
                L4 = 0
                'L6Descrip = ""
                'L5Descrip = ""
                L4Descrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 9 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                L3 = 0
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                L3Descrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 8 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                L2 = 0
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                L2Descrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 7 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                'L2 = 0
                L1 = 0
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                'L2Descrip = ""
                L1Descrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 6 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                'L2 = 0
                'L1 = 0
                Linea = 0
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                'L2Descrip = ""
                'L1Descrip = ""
                LineaDescrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 5 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                'L2 = 0
                'L1 = 0
                'Linea = 0
                Familia = 0
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                'L2Descrip = ""
                'L1Descrip = ""
                'LineaDescrip = ""
                FamiliaDescrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 4 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                'L2 = 0
                'L1 = 0
                'Linea = 0
                'Familia = 0
                Departamento = 0
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                'L2Descrip = ""
                'L1Descrip = ""
                'LineaDescrip = ""
                'FamiliaDescrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 3 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                'L2 = 0
                'L1 = 0
                'Linea = 0
                'Familia = 0
                'Departamento = 0

                'Division = 0

                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                'L2Descrip = ""
                'L1Descrip = ""
                'LineaDescrip = ""
                'FamiliaDescrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            ElseIf Opcion = 1 Or Opcion = 2 Then
                'L6 = 0
                'L5 = 0
                'L4 = 0
                'L3 = 0
                'L2 = 0
                'L1 = 0
                'Linea = 0
                'Familia = 0
                'Departamento = 0
                'Division = 0
                If Opcion = 1 Then Plaza = 0
                If Opcion = 2 Then
                    If ToolStripMenuItemSucursal.Enabled = False Then
                        Sucursal = GLB_CveSucursal
                    Else
                        Sucursal = 0
                    End If
                End If
                'L6Descrip = ""
                'L5Descrip = ""
                'L4Descrip = ""
                'L3Descrip = ""
                'L2Descrip = ""
                'L1Descrip = ""
                'LineaDescrip = ""
                'FamiliaDescrip = ""
                'Marca = False
                RellenaGrid()
                blnDoubleClick = False
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DGrid.DataBindingComplete
        Try
            If Sw_Load2 = True Then
                If Opcion = 1 Then
                    DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                End If
                Sw_Load2 = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_Miles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Miles.CheckedChanged
        Try
            '  If Sw_Load = True Then Exit Sub
            blnDoubleClick = True
            If Modelo = True Then
                Marca = True
                Modelo = False
            End If
            RellenaGrid()
            blnDoubleClick = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 1 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub

                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            PBox.Visible = True
                            Exit Sub
                        End If

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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try
            'mreyes 20/Mayo/2021    10:24 a.m., se quito el lbl_renglones
            DGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ' Lbl_Renglones.Text = DGrid.CurrentRow.Index.ToString + " de: " + (objDataSet.Tables(0).Rows.Count - 1).ToString + " "
            If Modelo = True Then
                If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                    PBox.Visible = False
                Else
                    CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
                End If
            Else
                PBox.Visible = False
            End If

            If DGrid.SelectedRows.Count > 1 Then
                Dim Renglon As Integer = 0
                Dim Suma As Integer = 0
                For i As Integer = 0 To DGrid.SelectedRows.Count - 1
                    Renglon = DGrid.SelectedRows.Item(i).Index
                    If IsDBNull(DGrid.Rows(Renglon).Cells("PorcParesNetoAc").Value) Then Continue For
                    Suma += DGrid.Rows(Renglon).Cells("PorcParesNetoAc").Value
                Next
                lbl_Suma.Text = "SUMA % Part: " + Suma.ToString
                lbl_Suma.Visible = True
            Else
                lbl_Suma.Visible = False
                lbl_Suma.Text = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            Lbl_Renglones.Text = DGrid.CurrentRow.Index.ToString + " de: " + (objDataSet.Tables(0).Rows.Count - 1).ToString + " "
            If Modelo = True Then
                If IsDBNull(DGrid.CurrentRow.Cells("Marca").Value) Then
                    PBox.Visible = False
                Else
                    CargarFotoArticulo(DGrid.CurrentRow.Cells("Marca").Value, DGrid.CurrentRow.Cells("Modelo").Value)
                End If
            Else
                PBox.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemInicio.Click
        Try
            blnBD = True
            TextoSelec = ""
            If GLB_CveSucursal = "" Then
                Sucursal = 0
            Else
                If CInt(GLB_CveSucursal) < 35 And CInt(GLB_CveSucursal) > 0 Then
                    Sucursal = CInt(GLB_CveSucursal)
                    Chk_Lerdo.Visible = False
                    Chk_AnioAnterior.Visible = False
                    Chk_AnioAnterior1.Visible = False
                    Chk_Miles.Visible = False
                Else
                    Sucursal = 0
                    Chk_Lerdo.Visible = True
                    Chk_AnioAnterior.Visible = True
                    Chk_AnioAnterior1.Visible = True
                    Chk_Miles.Visible = True
                End If
            End If
            Division = 0
            Departamento = 0
            Familia = 0
            Linea = 0
            FamiliaDescrip = ""
            LineaDescrip = ""
            L1Descrip = ""
            L2Descrip = ""
            L3Descrip = ""
            L4Descrip = ""
            L5Descrip = ""
            L6Descrip = ""
            L6 = 0
            strMarca = ""
            strModelo = ""
            intArreglo = 0
            arreglo(100) = New Integer
            Opcion = 1
            Marca = False
            Modelo = False
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSucursal.Click
        Try
            blnBD = True
            'Division = 0
            'Departamento = 0
            'Familia = 0
            'Linea = 0
            Dim txt As String = ""
            If Modelo = False Then
                If Marca = False Then
                    If Opcion = 1 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Plaza = 0 Then
                                Plaza = 0
                                TextoSelec = "PLAZA"
                                txt = "PLAZA"
                            End If
                        Else
                            Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                            TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                            txt = DGrid.CurrentRow.Cells("PLAZA").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If


                    If Opcion = 3 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Division = 0 Then
                                Division = 0
                                TextoSelec = "DIVISION"
                                txt = "DIVISION"
                            End If
                        Else

                            'If Division = 0 Then  'mreyes 14/Mayo/2018  05:32 p.m.
                            '    Division = 0
                            '    TextoSelec = "DIVISION"
                            '    txt = "DIVISION"
                            'Else
                            If DGrid.CurrentRow.Cells("Division").Value = "TOTAL: " Then
                                Division = 0
                                TextoSelec = "DIVISION"
                                txt = "DIVISION"
                            Else
                                Division = DGrid.CurrentRow.Cells("IdDivisiones").Value
                                TextoSelec = DGrid.CurrentRow.Cells("Division").Value & ""
                                txt = DGrid.CurrentRow.Cells("Division").Value & ""
                            End If
                        End If
                            lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 4 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Departamento = 0 Then
                                Departamento = 0
                                TextoSelec = "DEPARTAMENTO"
                                txt = "DEPARTAMENTO"
                            End If
                        Else
                            Departamento = DGrid.CurrentRow.Cells("idDepto").Value
                            TextoSelec = DGrid.CurrentRow.Cells("Depto").Value
                            txt = DGrid.CurrentRow.Cells("depto").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 5 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If FamiliaDescrip = "" Then
                                FamiliaDescrip = ""
                                TextoSelec = "FAMILIA"
                                txt = "FAMILIA"
                            End If
                        Else
                            FamiliaDescrip = DGrid.CurrentRow.Cells("Familia").Value
                            TextoSelec = FamiliaDescrip
                            txt = DGrid.CurrentRow.Cells("familia").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 6 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If LineaDescrip = "" Then
                                LineaDescrip = ""
                                TextoSelec = "LINEA"
                                txt = "LINEA"
                            End If
                        Else
                            LineaDescrip = DGrid.CurrentRow.Cells("Linea").Value
                            TextoSelec = LineaDescrip
                            txt = DGrid.CurrentRow.Cells("linea").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 7 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L1Descrip = "" Then
                                L1Descrip = ""
                                TextoSelec = "L1"
                                txt = "L1"
                            End If
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("L1").Value
                            TextoSelec = L1Descrip
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                Else
                    If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                        If strMarca = "" Then
                            strMarca = ""
                        End If
                    Else
                        strMarca = DGrid.CurrentRow.Cells("marca").Value
                    End If
                End If
                lbl_Mar.Text = strMarca
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                    End If
                    PBox.Visible = False
                    lbl_Mar.Text = strMarca + " " + strModelo
                End If
            Sucursal = 0
            L1 = 0
            L2 = 0
            L3 = 0
            L4 = 0
            L5 = 0
            L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 2
            Marca = False
            Modelo = False
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDivision.Click
        Try
            Dim txt As String
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'Departamento = 0
                'Familia = 0
                'Linea = 0
                'L1 = 0
                'L2 = 0
                'L3 = 0
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 3
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                lbl_Mar.Text = strMarca
                blnDoubleClick = True
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 3 Then
                    blnDoubleClick = True
                    If Opcion = 4 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Departamento = 0 Then
                                Departamento = 0
                                TextoSelec = "DEPARTAMENTO"
                                txt = "DEPARTAMENTO"
                            End If
                        Else
                            Departamento = DGrid.CurrentRow.Cells("idDepto").Value
                            TextoSelec = DGrid.CurrentRow.Cells("Depto").Value
                            txt = DGrid.CurrentRow.Cells("depto").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 5 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If FamiliaDescrip = "" Then
                                FamiliaDescrip = ""
                                TextoSelec = "FAMILIA"
                                txt = "FAMILIA"
                            End If
                        Else
                            FamiliaDescrip = DGrid.CurrentRow.Cells("Familia").Value
                            TextoSelec = FamiliaDescrip
                            txt = DGrid.CurrentRow.Cells("familia").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 6 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If LineaDescrip = "" Then
                                LineaDescrip = ""
                                TextoSelec = "LINEA"
                                txt = "LINEA"
                            End If
                        Else
                            LineaDescrip = DGrid.CurrentRow.Cells("Linea").Value
                            TextoSelec = LineaDescrip
                            txt = DGrid.CurrentRow.Cells("linea").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 7 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L1Descrip = "" Then
                                L1Descrip = ""
                                TextoSelec = "L1"
                                txt = "L1"
                            End If
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("L1").Value
                            TextoSelec = L1Descrip
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    Division = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'Departamento = 0
            'Familia = 0
            'Linea = 0
            'L1 = 0
            'L2 = 0
            'L3 = 0
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 3
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemDepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDepto.Click
        Try
            blnBD = True
            blnDoubleClick = True
            Dim txt As String = ""
            If Marca = True Then
                Marca = False
                Modelo = False
                'Familia = 0
                'Linea = 0
                'L1 = 0
                'L2 = 0
                'L3 = 0
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 4
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                lbl_Mar.Text = strMarca
                blnDoubleClick = True
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("IDPLAZA").Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 4 Then
                    blnDoubleClick = True
                    If Opcion = 5 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If FamiliaDescrip = "" Then
                                FamiliaDescrip = ""
                                TextoSelec = "FAMILIA"
                                txt = "FAMILIA"
                            End If
                        Else
                            FamiliaDescrip = DGrid.CurrentRow.Cells("Familia").Value
                            TextoSelec = FamiliaDescrip
                            txt = DGrid.CurrentRow.Cells("familia").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 6 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If LineaDescrip = "" Then
                                LineaDescrip = ""
                                TextoSelec = "LINEA"
                                txt = "LINEA"
                            End If
                        Else
                            LineaDescrip = DGrid.CurrentRow.Cells("Linea").Value
                            TextoSelec = LineaDescrip
                            txt = DGrid.CurrentRow.Cells("linea").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 7 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L1Descrip = "" Then
                                L1Descrip = ""
                                TextoSelec = "L1"
                                txt = "L1"
                            End If
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("L1").Value
                            TextoSelec = L1Descrip
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    Departamento = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'Familia = 0
            'Linea = 0
            'L1 = 0
            'L2 = 0
            'L3 = 0
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 4
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemFamilia.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'Linea = 0
                'L1 = 0
                'L2 = 0
                'L3 = 0
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 5
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                lbl_Mar.Text = strMarca
                blnDoubleClick = True
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then

                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 5 Then
                    blnDoubleClick = True
                    If Opcion = 6 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If LineaDescrip = "" Then
                                LineaDescrip = ""
                                TextoSelec = "LINEA"
                                txt = "LINEA"
                            End If
                        Else
                            LineaDescrip = DGrid.CurrentRow.Cells("Linea").Value
                            TextoSelec = LineaDescrip
                            txt = DGrid.CurrentRow.Cells("linea").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 7 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L1Descrip = "" Then
                                L1Descrip = ""
                                TextoSelec = "L1"
                                txt = "L1"
                            End If
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("L1").Value
                            TextoSelec = L1Descrip
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    Familia = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'Linea = 0
            'L1 = 0
            'L2 = 0
            'L3 = 0
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 5
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemLinea.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'L1 = 0
                'L2 = 0
                'L3 = 0
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 6
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                blnDoubleClick = True
                lbl_Mar.Text = strMarca
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 6 Then
                    blnDoubleClick = True
                    If Opcion = 7 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L1Descrip = "" Then
                                L1Descrip = ""
                                TextoSelec = "L1"
                                txt = "L1"
                            End If
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("L1").Value
                            TextoSelec = L1Descrip
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    Linea = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'L1 = 0
            'L2 = 0
            'L3 = 0
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 6
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemL1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL1.Click
        Try
            blnBD = True
            blnDoubleClick = True
            Dim txt As String = ""
            If Marca = True Then
                Marca = False
                Modelo = False
                'L2 = 0
                'L3 = 0
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 7
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                lbl_Mar.Text = strMarca
                blnDoubleClick = True
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 7 Then
                    blnDoubleClick = True
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    L1 = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'L2 = 0
            'L3 = 0
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 7
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemL2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL2.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'L3 = 0
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 8
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                blnDoubleClick = True
                lbl_Mar.Text = strMarca
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then

                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 7 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                        txt = "L1"
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                            txt = "L1"
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 8 Then
                    blnDoubleClick = True
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    L2 = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'L3 = 0
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 8
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemL3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL3.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'L4 = 0
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 9
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                lbl_Mar.Text = strMarca
                blnDoubleClick = True
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 2 Then


                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 7 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                        txt = "L1"
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                            txt = "L1"
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 8 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        L2 = 0
                        txt = "L2"
                    Else
                        L2 = DGrid.CurrentRow.Cells("idl2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L2Descrip = "" Then
                            L2Descrip = ""
                            txt = "L2"
                        End If
                    Else
                        L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 9 Then
                    blnDoubleClick = True
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    L3 = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'L4 = 0
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 9
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemL4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL4.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'L5 = 0
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 10
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                blnDoubleClick = True
                lbl_Mar.Text = strMarca
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 7 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                        txt = "L1"
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                            txt = "L1"
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 8 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        L2 = 0
                        txt = "L2"
                    Else
                        L2 = DGrid.CurrentRow.Cells("idl2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L2Descrip = "" Then
                            L2Descrip = ""
                            txt = "L2"
                        End If
                    Else
                        L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 9 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        L3 = 0
                        txt = "L3"
                    Else
                        L3 = DGrid.CurrentRow.Cells("idl3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L3Descrip = "" Then
                            L3Descrip = ""
                            txt = "L3"
                        End If
                    Else
                        L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 10 Then
                    blnDoubleClick = True
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    L4 = 0
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            'L5 = 0
            'L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 10
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemL5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL5.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                'L6 = 0
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 11
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                blnDoubleClick = True
                lbl_Mar.Text = strMarca
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then

                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 7 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                        txt = "L1"
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                            txt = "L1"
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 8 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        L2 = 0
                        txt = "L2"
                    Else
                        L2 = DGrid.CurrentRow.Cells("idl2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L2Descrip = "" Then
                            L2Descrip = ""
                            txt = "L2"
                        End If
                    Else
                        L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 9 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        L3 = 0
                        txt = "L3"
                    Else
                        L3 = DGrid.CurrentRow.Cells("idl3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L3Descrip = "" Then
                            L3Descrip = ""
                            txt = "L3"
                        End If
                    Else
                        L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 10 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                        L4 = 0
                        txt = "L4"
                    Else
                        L4 = DGrid.CurrentRow.Cells("idl4").Value
                        txt = DGrid.CurrentRow.Cells("L4").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L4Descrip = "" Then
                            L4Descrip = ""
                            txt = "L4"
                        End If
                    Else
                        L4Descrip = DGrid.CurrentRow.Cells("l4").Value
                        txt = DGrid.CurrentRow.Cells("L4").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion > 11 Then
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 11
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemL6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemL6.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Marca = True Then
                Marca = False
                Modelo = False
                arreglo(intArreglo) = Opcion
                intArreglo += 1
                Opcion = 12
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                blnDoubleClick = True
                lbl_Mar.Text = strMarca
                RellenaGrid()
                Exit Sub
            End If
            If Modelo = False Then

                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 7 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                        txt = "L1"
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                            txt = "L1"
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 8 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        L2 = 0
                        txt = "L2"
                    Else
                        L2 = DGrid.CurrentRow.Cells("idl2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L2Descrip = "" Then
                            L2Descrip = ""
                            txt = "L2"
                        End If
                    Else
                        L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 9 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        L3 = 0
                        txt = "L3"
                    Else
                        L3 = DGrid.CurrentRow.Cells("idl3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L3Descrip = "" Then
                            L3Descrip = ""
                            txt = "L3"
                        End If
                    Else
                        L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 10 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                        L4 = 0
                        txt = "L4"
                    Else
                        L4 = DGrid.CurrentRow.Cells("idl4").Value
                        txt = DGrid.CurrentRow.Cells("L4").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L4Descrip = "" Then
                            L4Descrip = ""
                            txt = "L4"
                        End If
                    Else
                        L4Descrip = DGrid.CurrentRow.Cells("l4").Value
                        txt = DGrid.CurrentRow.Cells("L4").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 11 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl5").Value) Then
                        L5 = 0
                        txt = "L5"
                    Else
                        L5 = DGrid.CurrentRow.Cells("idl5").Value
                        txt = DGrid.CurrentRow.Cells("L5").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L5Descrip = "" Then
                            L5Descrip = ""
                            txt = "L5"
                        End If
                    Else
                        L5Descrip = DGrid.CurrentRow.Cells("l5").Value
                        txt = DGrid.CurrentRow.Cells("L5").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Marca = False
            Modelo = False
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 12
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMarca.Click
        Try
            Dim txt As String = ""
            blnBD = True
            blnDoubleClick = True
            If Modelo = False Then
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                            TextoSelec = "PLAZA"
                            txt = "PLAZA"
                        End If
                    Else
                        Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                        txt = DGrid.CurrentRow.Cells("PLAZA").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                            blnDoubleClick = True
                            txt = "SUCURSALES"
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                        txt = DGrid.CurrentRow.Cells("sucursal").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 3 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                            txt = "DIVISION"
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                        txt = DGrid.CurrentRow.Cells("division").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 4 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                            txt = "DEPARTAMENTO"
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                        txt = DGrid.CurrentRow.Cells("depto").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 5 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                        txt = "FAMILIA"
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                            txt = "FAMILIA"
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                        txt = DGrid.CurrentRow.Cells("familia").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 6 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                        txt = "LINEA"
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                        txt = DGrid.CurrentRow.Cells("Linea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                            txt = "LINEA"
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                        txt = DGrid.CurrentRow.Cells("linea").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 7 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                        txt = "L1"
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                            txt = "L1"
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                        txt = DGrid.CurrentRow.Cells("L1").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 8 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        L2 = 0
                        txt = "L2"
                    Else
                        L2 = DGrid.CurrentRow.Cells("idl2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L2Descrip = "" Then
                            L2Descrip = ""
                            txt = "L2"
                        End If
                    Else
                        L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                        txt = DGrid.CurrentRow.Cells("L2").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 9 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        L3 = 0
                        txt = "L3"
                    Else
                        L3 = DGrid.CurrentRow.Cells("idl3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L3Descrip = "" Then
                            L3Descrip = ""
                            txt = "L3"
                        End If
                    Else
                        L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                        txt = DGrid.CurrentRow.Cells("L3").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 10 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                        L4 = 0
                        txt = "L4"
                    Else
                        L4 = DGrid.CurrentRow.Cells("idl4").Value
                        txt = DGrid.CurrentRow.Cells("L4").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L4Descrip = "" Then
                            L4Descrip = ""
                            txt = "L4"
                        End If
                    Else
                        L4Descrip = DGrid.CurrentRow.Cells("l4").Value
                        txt = DGrid.CurrentRow.Cells("L4").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 11 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl5").Value) Then
                        L5 = 0
                        txt = "L5"
                    Else
                        L5 = DGrid.CurrentRow.Cells("idl5").Value
                        txt = DGrid.CurrentRow.Cells("L5").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L5Descrip = "" Then
                            L5Descrip = ""
                            txt = "L5"
                        End If
                    Else
                        L5Descrip = DGrid.CurrentRow.Cells("l5").Value
                        txt = DGrid.CurrentRow.Cells("L5").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
                If Opcion = 12 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idl6").Value) Then
                        L6 = 0
                        txt = "L6"
                    Else
                        L6 = DGrid.CurrentRow.Cells("idl6").Value
                        txt = DGrid.CurrentRow.Cells("L6").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L6Descrip = "" Then
                            L6Descrip = ""
                            txt = "L6"
                        End If
                    Else
                        L6Descrip = DGrid.CurrentRow.Cells("l6").Value
                        txt = DGrid.CurrentRow.Cells("L6").Value
                    End If
                    lbl_Mensaje.Text += ", " + txt
                End If
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
            End If
            RegresoModelo = True
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemModelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemModelo.Click
        Try
            blnBD = True
            blnDoubleClick = True
            If Marca = False Then
                Marca = True
                If Opcion = 1 Then
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If Plaza = 0 Then
                            Plaza = 0
                           
                        End If
                    Else
                        If IsDBNull(DGrid.CurrentRow.Cells("idplaza").Value) Then
                            Plaza = 0
                        Else
                            Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                        End If
                        End If

                End If

                If Opcion = 2 Then
                    If IsDBNull(DGrid.CurrentRow.Cells("idsucursal").Value) Then
                        If Sucursal = 0 Then
                            Sucursal = 0
                        End If
                    Else
                        Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    End If
                End If
                If Opcion = 3 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("iddivisiones").Value) Then
                        If Division = 0 Then
                            Division = 0
                        End If
                    Else
                        Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    End If
                End If
                If Opcion = 4 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("iddepto").Value) Then
                        If Departamento = 0 Then
                            Departamento = 0
                        End If
                    Else
                        Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    End If
                End If
                If Opcion = 5 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idfamilia").Value) Then
                        Familia = 0
                    Else
                        Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If FamiliaDescrip = "" Then
                            FamiliaDescrip = ""
                        End If
                    Else
                        FamiliaDescrip = DGrid.CurrentRow.Cells("familia").Value
                    End If
                End If
                If Opcion = 6 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idlinea").Value) Then
                        Linea = 0
                    Else
                        Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If LineaDescrip = "" Then
                            LineaDescrip = ""
                        End If
                    Else
                        LineaDescrip = DGrid.CurrentRow.Cells("linea").Value
                    End If
                End If
                If Opcion = 7 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idl1").Value) Then
                        L1 = 0
                    Else
                        L1 = DGrid.CurrentRow.Cells("idl1").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L1Descrip = "" Then
                            L1Descrip = ""
                        End If
                    Else
                        L1Descrip = DGrid.CurrentRow.Cells("l1").Value
                    End If
                End If
                If Opcion = 8 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    'L1 = DGrid.CurrentRow.Cells("idl1").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idl2").Value) Then
                        L2 = 0
                    Else
                        L2 = DGrid.CurrentRow.Cells("idl2").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L2Descrip = "" Then
                            L2Descrip = ""
                        End If
                    Else
                        L2Descrip = DGrid.CurrentRow.Cells("l2").Value
                    End If
                End If
                If Opcion = 9 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    'L1 = DGrid.CurrentRow.Cells("idl1").Value
                    'L2 = DGrid.CurrentRow.Cells("idl2").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idl3").Value) Then
                        L3 = 0
                    Else
                        L3 = DGrid.CurrentRow.Cells("idl3").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L3Descrip = "" Then
                            L3Descrip = ""
                        End If
                    Else
                        L3Descrip = DGrid.CurrentRow.Cells("l3").Value
                    End If
                End If
                If Opcion = 10 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    'L1 = DGrid.CurrentRow.Cells("idl1").Value
                    'L2 = DGrid.CurrentRow.Cells("idl2").Value
                    'L3 = DGrid.CurrentRow.Cells("idl3").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idl4").Value) Then
                        L4 = 0
                    Else
                        L4 = DGrid.CurrentRow.Cells("idl4").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L4Descrip = "" Then
                            L4Descrip = ""
                        End If
                    Else
                        L4Descrip = DGrid.CurrentRow.Cells("l4").Value
                    End If
                End If
                If Opcion = 11 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    'L1 = DGrid.CurrentRow.Cells("idl1").Value
                    'L2 = DGrid.CurrentRow.Cells("idl2").Value
                    'L3 = DGrid.CurrentRow.Cells("idl3").Value
                    'L4 = DGrid.CurrentRow.Cells("idl4").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idl5").Value) Then
                        L5 = 0
                    Else
                        L5 = DGrid.CurrentRow.Cells("idl5").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L5Descrip = "" Then
                            L5Descrip = ""
                        End If
                    Else
                        L5Descrip = DGrid.CurrentRow.Cells("l5").Value
                    End If
                End If
                If Opcion = 12 Then
                    'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                    'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                    'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                    'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                    'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                    'L1 = DGrid.CurrentRow.Cells("idl1").Value
                    'L2 = DGrid.CurrentRow.Cells("idl2").Value
                    'L3 = DGrid.CurrentRow.Cells("idl3").Value
                    'L4 = DGrid.CurrentRow.Cells("idl4").Value
                    'L5 = DGrid.CurrentRow.Cells("idl5").Value
                    If IsDBNull(DGrid.CurrentRow.Cells("idl6").Value) Then
                        L6 = 0
                    Else
                        L6 = DGrid.CurrentRow.Cells("idl6").Value
                    End If
                    If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                        If L6Descrip = "" Then
                            L6Descrip = ""
                        End If
                    Else
                        L6Descrip = DGrid.CurrentRow.Cells("l6").Value
                    End If
                End If
                RellenaGrid()
                blnBD = False
            Else
                'Sucursal = DGrid.CurrentRow.Cells("idsucursal").Value
                'Division = DGrid.CurrentRow.Cells("iddivisiones").Value
                'Departamento = DGrid.CurrentRow.Cells("iddepto").Value
                'Familia = DGrid.CurrentRow.Cells("idfamilia").Value
                'FamiliaAnt = DGrid.CurrentRow.Cells("famant").Value
                'Linea = DGrid.CurrentRow.Cells("idlinea").Value
                'LineaAnt = DGrid.CurrentRow.Cells("lineaant").Value
                'L1 = DGrid.CurrentRow.Cells("idl1").Value
                'L1Ant = DGrid.CurrentRow.Cells("l1ant").Value
                'L2 = DGrid.CurrentRow.Cells("idl2").Value
                'L2Ant = DGrid.CurrentRow.Cells("l2ant").Value
                'L3 = DGrid.CurrentRow.Cells("idl3").Value
                'L3Ant = DGrid.CurrentRow.Cells("l3ant").Value
                'L4 = DGrid.CurrentRow.Cells("idl4").Value
                'L4Ant = DGrid.CurrentRow.Cells("l4ant").Value
                'L5 = DGrid.CurrentRow.Cells("idl5").Value
                'L5Ant = DGrid.CurrentRow.Cells("l5ant").Value
                'L6 = DGrid.CurrentRow.Cells("idl6").Value
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                RellenaGrid()
                blnBD = False
                RegresoModelo = True
            End If
            'RegresoModelo = False
            'Marca = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ToolStripMenuItemGrafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemGrafica.Click
        Try
            DibujaGrafica()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                With Me.DGrid
                    Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                    If Hitest.Type = DataGridViewHitTestType.Cell Then
                        .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                    End If
                End With
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtros.Click
        Try
            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Txt_Agrupacion.Text = Val(idAgrupacionB)
            myFormFiltros.Txt_Modelo.Text = strModelo
            myFormFiltros.Sw_Filtro = False
            myFormFiltros.DT_Inicio.Value = CDate(FechaInicioA)
            myFormFiltros.DT_Fin.Value = CDate(FechaInicioB)

            If Plaza <> 0 Then
                myFormFiltros.Plaza = "0" + Plaza.ToString
            End If



            If Sucursal <> 0 Then
                myFormFiltros.Suc = "0" + Sucursal.ToString
            End If
            If Division <> 0 Then
                myFormFiltros.Txt_IdDivision.Text = Division
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(Division, "")
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Division.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Departamento <> 0 Then
                myFormFiltros.Txt_IdDepto.Text = Departamento
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(Departamento, 0, "", 0, "")
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If FamiliaDescrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, FamiliaDescrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If LineaDescrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, LineaDescrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6Descrip <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6Descrip)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If strMarca <> "" Then
                myFormFiltros.Txt_Marca.Text = strMarca
            End If
            myFormFiltros.ShowDialog()
            If myFormFiltros.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                DGrid.Rows.Clear()

                If myFormFiltros.Cbo_Plaza.Text <> "Todas" Then

                    If myFormFiltros.Cbo_Plaza.Text = "TORREÓN" Then
                        Plaza = 1
                    Else
                        Plaza = 2
                    End If
                End If

                FechaInicioA = myFormFiltros.DT_Inicio.Value.ToString("yyyy-MM-dd")
                FechaInicioB = myFormFiltros.DT_Fin.Value.ToString("yyyy-MM-dd")
                strAñoActual = CDate(FechaInicioA).ToString("yyyy")
                strAñoAnterior = CDate(FechaInicioA).AddYears(-1).ToString("yyyy")
                Sucursal = CInt(myFormFiltros.CB_Sucursal.SelectedValue.ToString)
                strMarca = myFormFiltros.Txt_Marca.Text
                If strMarca.Trim <> "" Then
                    lbl_Mar.Text = strMarca
                End If
                If myFormFiltros.Chk_UltRecibo.Checked Then
                    FecRecA = myFormFiltros.DT_RecIni.Value.ToString("yyyy-MM-dd")
                    FecRecB = myFormFiltros.DT_RecFin.Value.ToString("yyyy-MM-dd")
                Else
                    FecRecA = ""
                    FecRecB = ""
                End If
                If myFormFiltros.Txt_Modelo.Text <> "" Then
                    strModelo = myFormFiltros.Txt_Modelo.Text
                Else
                    strModelo = ""


                End If
                blnDoubleClick = True
                If Marca = True Then
                    Marca = False
                    RegresoModelo = True
                Else
                    If Modelo = True Then
                        Modelo = False
                        Marca = True
                    End If
                End If
                If myFormFiltros.Txt_IdDivision.Text.Trim = "" Then
                    Division = 0
                Else
                    Division = CInt(myFormFiltros.Txt_IdDivision.Text)
                End If
                If myFormFiltros.Txt_IdDepto.Text.Trim = "" Then
                    Departamento = 0
                Else
                    Departamento = CInt(myFormFiltros.Txt_IdDepto.Text)
                End If
                If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                    FamiliaDescrip = ""
                Else
                    FamiliaDescrip = myFormFiltros.Txt_DescripFamilia.Text
                End If
                If myFormFiltros.Txt_DescripLinea.Text = "" Then
                    LineaDescrip = ""
                Else
                    LineaDescrip = myFormFiltros.Txt_DescripLinea.Text
                End If
                If myFormFiltros.Txt_DescripL1.Text = "" Then
                    L1Descrip = ""
                Else
                    L1Descrip = myFormFiltros.Txt_DescripL1.Text
                End If
                If myFormFiltros.Txt_DescripL2.Text = "" Then
                    L2Descrip = ""
                Else
                    L2Descrip = myFormFiltros.Txt_DescripL2.Text
                End If
                If myFormFiltros.Txt_DescripL3.Text = "" Then
                    L3Descrip = ""
                Else
                    L3Descrip = myFormFiltros.Txt_DescripL3.Text
                End If
                If myFormFiltros.Txt_DescripL4.Text = "" Then
                    L4Descrip = ""
                Else
                    L4Descrip = myFormFiltros.Txt_DescripL4.Text
                End If
                If myFormFiltros.Txt_DescripL5.Text = "" Then
                    L5Descrip = ""
                Else
                    L5Descrip = myFormFiltros.Txt_DescripL5.Text
                End If
                If myFormFiltros.Txt_DescripL6.Text = "" Then
                    L6Descrip = ""
                Else
                    L6Descrip = myFormFiltros.Txt_DescripL6.Text
                End If

                idAgrupacionB = Val(myFormFiltros.Txt_Agrupacion.Text)



                Call RellenaGrid()
                blnDoubleClick = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
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

    Private Sub PBox_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GeneraLabel(ByVal Estado As Integer, ByVal Texto As String)
        If Estado = 1 Then
            Lbl_Texto.Text = Texto
        ElseIf Estado = 2 Then
            Lbl_Texto.Text = Lbl_Texto.Text + ", " + Texto
        End If
    End Sub

    Private Sub DGrid_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.Sorted
        Try
            'DGrid.Rows(0).DisplayIndex = 0
            For i As Integer = 1 To DGrid.Rows.Count - 2
                DGrid.Rows(i).Cells("Renglon").Value = i.ToString
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_Lerdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Lerdo.CheckedChanged
        Try
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Actualizar.Click
        Dim Guardo As Boolean
        Try
            If MessageBox.Show("Esta seguro que desea actualizar las ventas del día de hoy?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If GLB_FechaHoy <> pub_TraerFechaHoy() Then
                    GLB_FechaHoy = pub_TraerFechaHoy()
                End If
                Using objRepVentasNetas As New BCL.BCLVentas(GLB_ConStringCipSis)
                    objRepVentasNetas.usp_GeneraVentasBase(GLB_FechaHoy.ToString("yyyy-MM-dd"), GLB_FechaHoy.ToString("yyyy-MM-dd"), 0)
                End Using

                Using objVentas As New BCL.BCLMigracion(GLB_ConStringdwhSQL)

                    Guardo = objVentas.usp_GeneraVentasBase(0, 0, GLB_FechaHoy.ToString("yyyy-MM-dd"), GLB_FechaHoy.ToString("yyyy-MM-dd"))

                End Using


                Me.Cursor = Cursors.Default
                MessageBox.Show("Ventas actualizadas del día " + GLB_FechaHoy.ToString("dd-MMM-yyyy").ToUpper + " a las " + Now.ToString("hh:mm:ss tt"), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FechaInicioA = GLB_FechaHoy.ToString("yyyy-MM-dd")
                FechaInicioB = GLB_FechaHoy.ToString("yyyy-MM-dd")
                If MessageBox.Show("Desea Actualizar la existencia Actual?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    Using objRepVentasNetas As New BCL.BCLVentasCero(GLB_ConStringDWH)
                        objRepVentasNetas.usp_GeneraExist(GLB_FechaHoy.ToString("yyyy-MM-dd"), True)
                    End Using
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("Existencia Actualizada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se mostrara la existencia actualizada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

 
    Private Sub Chk_AnioAnterior_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_AnioAnterior.CheckedChanged
        Try
            If Chk_AnioAnterior.Checked Then
                AñoAnterior = True
                If Marca = True Then
                    Marca = False
                End If
                RellenaGrid()
            Else
                AñoAnterior = False
                If Marca = True Then
                    Marca = False
                End If
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CatModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCatModelo.Click
        Try
            Dim myForm As New frmCatalogoModelos
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("Modelo").Value
            myForm.Accion = 2
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AnaModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnaModelo.Click
        Try
            Dim myForm As New frmAnalisisModelo
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("Modelo").Value
            myForm.Accion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub ToolStripMenuItemPlaza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemPlaza.Click
        Try
            blnBD = True
            'Division = 0
            'Departamento = 0
            'Familia = 0
            'Linea = 0
            Dim txt As String = ""
            If Modelo = False Then
                If Marca = False Then

                    If Opcion = 1 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Plaza = 0 Then
                                Plaza = 0
                                TextoSelec = "PLAZA"
                                txt = "PLAZA"
                            End If
                        Else
                            Plaza = DGrid.CurrentRow.Cells("IDPLAZA").Value
                            TextoSelec = DGrid.CurrentRow.Cells("PLAZA").Value
                            txt = DGrid.CurrentRow.Cells("PLAZA").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If




                    If Opcion = 2 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Sucursal = 0 Then
                                Sucursal = 0
                                TextoSelec = "SUCURSAL"
                                txt = "SUCURSAL"
                            End If
                        Else
                            Sucursal = DGrid.CurrentRow.Cells("IdSucursal").Value
                            TextoSelec = DGrid.CurrentRow.Cells("sucursal").Value
                            txt = DGrid.CurrentRow.Cells("sucursal").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If

                    If Opcion = 3 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Division = 0 Then
                                Division = 0
                                TextoSelec = "DIVISION"
                                txt = "DIVISION"
                            End If
                        Else
                            If DGrid.CurrentRow.Cells("Division").Value = "TOTAL: " Then
                                Division = 0
                                TextoSelec = "DIVISION"
                                txt = "DIVISION"
                            Else
                                Division = DGrid.CurrentRow.Cells("IdDivisiones").Value
                                TextoSelec = DGrid.CurrentRow.Cells("Division").Value
                                txt = DGrid.CurrentRow.Cells("Division").Value
                            End If
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 4 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If Departamento = 0 Then
                                Departamento = 0
                                TextoSelec = "DEPARTAMENTO"
                                txt = "DEPARTAMENTO"
                            End If
                        Else
                            Departamento = DGrid.CurrentRow.Cells("idDepto").Value
                            TextoSelec = DGrid.CurrentRow.Cells("Depto").Value
                            txt = DGrid.CurrentRow.Cells("depto").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 5 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If FamiliaDescrip = "" Then
                                FamiliaDescrip = ""
                                TextoSelec = "FAMILIA"
                                txt = "FAMILIA"
                            End If
                        Else
                            FamiliaDescrip = DGrid.CurrentRow.Cells("Familia").Value
                            TextoSelec = FamiliaDescrip
                            txt = DGrid.CurrentRow.Cells("familia").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 6 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If LineaDescrip = "" Then
                                LineaDescrip = ""
                                TextoSelec = "LINEA"
                                txt = "LINEA"
                            End If
                        Else
                            LineaDescrip = DGrid.CurrentRow.Cells("Linea").Value
                            TextoSelec = LineaDescrip
                            txt = DGrid.CurrentRow.Cells("linea").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 7 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L1Descrip = "" Then
                                L1Descrip = ""
                                TextoSelec = "L1"
                                txt = "L1"
                            End If
                        Else
                            L1Descrip = DGrid.CurrentRow.Cells("L1").Value
                            TextoSelec = L1Descrip
                            txt = DGrid.CurrentRow.Cells("l1").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 8 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L2Descrip = "" Then
                                L2Descrip = ""
                                TextoSelec = "L2"
                                txt = "L2"
                            End If
                        Else
                            L2Descrip = DGrid.CurrentRow.Cells("L2").Value
                            TextoSelec = L2Descrip
                            txt = DGrid.CurrentRow.Cells("l2").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 9 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L3Descrip = "" Then
                                L3Descrip = ""
                                TextoSelec = "L3"
                                txt = "L3"
                            End If
                        Else
                            L3Descrip = DGrid.CurrentRow.Cells("L3").Value
                            TextoSelec = L3Descrip
                            txt = DGrid.CurrentRow.Cells("l3").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 10 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L4Descrip = "" Then
                                L4Descrip = ""
                                TextoSelec = "L4"
                                txt = "L4"
                            End If
                        Else
                            L4Descrip = DGrid.CurrentRow.Cells("L4").Value
                            TextoSelec = L4Descrip
                            txt = DGrid.CurrentRow.Cells("l4").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 11 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L5Descrip = "" Then
                                L5Descrip = ""
                                TextoSelec = "L5"
                                txt = "L5"
                            End If
                        Else
                            L5Descrip = DGrid.CurrentRow.Cells("L5").Value
                            TextoSelec = L5Descrip
                            txt = DGrid.CurrentRow.Cells("l5").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                    If Opcion = 12 Then
                        If IsDBNull(DGrid.CurrentRow.Cells(0).Value) Then
                            If L6Descrip = "" Then
                                L6Descrip = ""
                                TextoSelec = "L6"
                                txt = "L6"
                            End If
                        Else
                            L6Descrip = DGrid.CurrentRow.Cells("L6").Value
                            TextoSelec = L6Descrip
                            txt = DGrid.CurrentRow.Cells("l6").Value
                        End If
                        lbl_Mensaje.Text += ", " + txt
                    End If
                Else
                    If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                        If strMarca = "" Then
                            strMarca = ""
                        End If
                    Else
                        strMarca = DGrid.CurrentRow.Cells("marca").Value
                    End If
                End If
                lbl_Mar.Text = strMarca
            Else
                If IsDBNull(DGrid.CurrentRow.Cells("modelo").Value) Then
                    If strModelo = "" Then
                        strModelo = ""
                    End If
                Else
                    strModelo = DGrid.CurrentRow.Cells("modelo").Value
                End If
                If IsDBNull(DGrid.CurrentRow.Cells("marca").Value) Then
                    If strMarca = "" Then
                        strMarca = ""
                    End If
                Else
                    strMarca = DGrid.CurrentRow.Cells("marca").Value
                End If
                PBox.Visible = False
                lbl_Mar.Text = strMarca + " " + strModelo
            End If
            Sucursal = 0
            L1 = 0
            L2 = 0
            L3 = 0
            L4 = 0
            L5 = 0
            L6 = 0
            arreglo(intArreglo) = Opcion
            intArreglo += 1
            Opcion = 1
            Marca = False
            Modelo = False
            RellenaGrid()
            blnBD = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Chk_AnioAnterior1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_AnioAnterior1.CheckedChanged
        Try
            If Chk_AnioAnterior.Checked = True Then Chk_AnioAnterior.Checked = False

            If Chk_AnioAnterior1.Checked Then
                AñoAnterior = True
                AñoAnteriorIgual = True
                If Marca = True Then
                    Marca = False
                End If
                RellenaGrid()
            Else
                AñoAnterior = False
                AñoAnteriorIgual = False
                If Marca = True Then
                    Marca = False
                End If
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalReporteVentasDwh_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

    End Sub

    Private Sub frmPpalReporteVentasDwh_BindingContextChanged(sender As Object, e As EventArgs) Handles Me.BindingContextChanged

    End Sub


End Class