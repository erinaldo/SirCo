Public Class frmPpalSaldosProv

    Public Opcion As Integer = 0

    Private objDataSet As Data.DataSet

    Dim ProveedorB As String
    Dim MarcaB As String
    Dim EjercicioB As Integer
    Dim ImportadosB As String

    Dim FecIni As Date
    Dim FecFin As Date

    Dim OpcionAnt As Integer = 0
    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False

    Private Sub frmPpalSaldoProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Txt_Ejercicio.Text = Year(GLB_FechaHoy)
        Call LimpiarBusqueda()
        Rb_Todos.Checked = True
        Sw_Pintar = True
        'Sw_Load = False 
    End Sub

    Private Sub frmPpalSaldoProveedores_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        'InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub LimpiarBusqueda()
        ProveedorB = ""
        MarcaB = ""
        EjercicioB = CInt(Txt_Ejercicio.Text)
        ImportadosB = "0"
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 23/Abril/2014 - 11:00 am
        Using objSaldosProv As New BCL.BCLSaldosProv(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Opcion = 1 Or Opcion = 2 Then
                    objDataSet = objSaldosProv.usp_PpalSaldosProv(Opcion, ProveedorB, MarcaB, EjercicioB, ImportadosB)
                ElseIf Opcion = 3 Then
                    objDataSet = objSaldosProv.usp_TraerFactSaldosProv(ProveedorB, MarcaB, FecIni, FecFin, ImportadosB)
                End If


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 

                    DGrid.DataSource = objDataSet.Tables(0)
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
                    MsgBox("No se encontraron registros para el Ejercicio ingresado. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    'Txt_Ejercicio.Text = ""
                    Txt_Ejercicio.Focus()
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        Try
            If Opcion = 1 Then 'proveedor

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row("raz_soc") = "TOTAL: "
                row("saldoact") = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                row("saldoant") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row("enero") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row("febrero") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                row("marzo") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row("abril") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row("mayo") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row("junio") = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                row("julio") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                row("agosto") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                row("septiembre") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row("octubre") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row("noviembre") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row("diciembre") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                row("saldopos") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns("idproveedor").HeaderText = "IdProv" 'oculto
                DGrid.Columns("proveedor").HeaderText = "Proveedor"
                DGrid.Columns("raz_soc").HeaderText = "Razón Social"
                DGrid.Columns("ejercicio").HeaderText = "Ejercicio" 'oculto
                DGrid.Columns("saldoact").HeaderText = "Saldo"
                DGrid.Columns("saldoant").HeaderText = "Antes de Enero"
                DGrid.Columns("enero").HeaderText = "Enero"
                DGrid.Columns("febrero").HeaderText = "Febrero"
                DGrid.Columns("marzo").HeaderText = "Marzo"
                DGrid.Columns("abril").HeaderText = "Abril"
                DGrid.Columns("mayo").HeaderText = "Mayo"
                DGrid.Columns("junio").HeaderText = "Junio"
                DGrid.Columns("julio").HeaderText = "Julio"
                DGrid.Columns("agosto").HeaderText = "Agosto"
                DGrid.Columns("septiembre").HeaderText = "Septiembre"
                DGrid.Columns("octubre").HeaderText = "Octubre"
                DGrid.Columns("noviembre").HeaderText = "Noviembre"
                DGrid.Columns("diciembre").HeaderText = "Diciembre"
                DGrid.Columns("saldopos").HeaderText = "Después de Diciembre"

                DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("raz_soc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                DGrid.Columns("saldoact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("saldoant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("enero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("febrero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("marzo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abril").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("mayo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("junio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("julio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("agosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("septiembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("octubre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("noviembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("diciembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("saldopos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns("saldoact").DefaultCellStyle.Format = "c"
                DGrid.Columns("saldoant").DefaultCellStyle.Format = "c"
                DGrid.Columns("enero").DefaultCellStyle.Format = "c"
                DGrid.Columns("febrero").DefaultCellStyle.Format = "c"
                DGrid.Columns("marzo").DefaultCellStyle.Format = "c"
                DGrid.Columns("abril").DefaultCellStyle.Format = "c"
                DGrid.Columns("mayo").DefaultCellStyle.Format = "c"
                DGrid.Columns("junio").DefaultCellStyle.Format = "c"
                DGrid.Columns("julio").DefaultCellStyle.Format = "c"
                DGrid.Columns("agosto").DefaultCellStyle.Format = "c"
                DGrid.Columns("septiembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("octubre").DefaultCellStyle.Format = "c"
                DGrid.Columns("noviembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("diciembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("saldopos").DefaultCellStyle.Format = "c"

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                For i As Integer = 0 To 4
                    DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Next

                DGrid.Columns("saldoact").Frozen = True
                DGrid.Columns("idproveedor").Visible = False
                DGrid.Columns("ejercicio").Visible = False

                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



            ElseIf Opcion = 2 Then 'marca


                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row("raz_soc") = "TOTAL: "
                row("saldoact") = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row("saldoant") = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row("enero") = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                row("febrero") = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row("marzo") = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                row("abril") = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row("mayo") = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                row("junio") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                row("julio") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                row("agosto") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row("septiembre") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row("octubre") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row("noviembre") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                row("diciembre") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                row("saldopos") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns("idproveedor").HeaderText = "IdProv" 'oculto
                DGrid.Columns("proveedor").HeaderText = "Proveedor"
                DGrid.Columns("raz_soc").HeaderText = "Razón Social"
                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("ejercicio").HeaderText = "Ejercicio" 'oculto
                DGrid.Columns("saldoact").HeaderText = "Saldo"
                DGrid.Columns("saldoant").HeaderText = "Antes de Enero"
                DGrid.Columns("enero").HeaderText = "Enero"
                DGrid.Columns("febrero").HeaderText = "Febrero"
                DGrid.Columns("marzo").HeaderText = "Marzo"
                DGrid.Columns("abril").HeaderText = "Abril"
                DGrid.Columns("mayo").HeaderText = "Mayo"
                DGrid.Columns("junio").HeaderText = "Junio"
                DGrid.Columns("julio").HeaderText = "Julio"
                DGrid.Columns("agosto").HeaderText = "Agosto"
                DGrid.Columns("septiembre").HeaderText = "Septiembre"
                DGrid.Columns("octubre").HeaderText = "Octubre"
                DGrid.Columns("noviembre").HeaderText = "Noviembre"
                DGrid.Columns("diciembre").HeaderText = "Diciembre"
                DGrid.Columns("saldopos").HeaderText = "Después de Diciembre"

                DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("raz_soc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns("saldoact").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("saldoant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("enero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("febrero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("marzo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("abril").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("mayo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("junio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("julio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("agosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("septiembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("octubre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("noviembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("diciembre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("saldopos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns("saldoact").DefaultCellStyle.Format = "c"
                DGrid.Columns("saldoant").DefaultCellStyle.Format = "c"
                DGrid.Columns("enero").DefaultCellStyle.Format = "c"
                DGrid.Columns("febrero").DefaultCellStyle.Format = "c"
                DGrid.Columns("marzo").DefaultCellStyle.Format = "c"
                DGrid.Columns("abril").DefaultCellStyle.Format = "c"
                DGrid.Columns("mayo").DefaultCellStyle.Format = "c"
                DGrid.Columns("junio").DefaultCellStyle.Format = "c"
                DGrid.Columns("julio").DefaultCellStyle.Format = "c"
                DGrid.Columns("agosto").DefaultCellStyle.Format = "c"
                DGrid.Columns("septiembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("octubre").DefaultCellStyle.Format = "c"
                DGrid.Columns("noviembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("diciembre").DefaultCellStyle.Format = "c"
                DGrid.Columns("saldopos").DefaultCellStyle.Format = "c"

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                For i As Integer = 0 To 5
                    DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Next

                DGrid.Columns("saldoact").Frozen = True
                DGrid.Columns("idproveedor").Visible = False
                DGrid.Columns("ejercicio").Visible = False

                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)



            ElseIf Opcion = 3 Then

                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
                Dim row As DataRow = dt.NewRow()

                row("proveedor") = "TOTAL: "
                row("pares") = pub_SumarColumnaGrid(DGrid, 12, DGrid.RowCount - 1)
                row("subtotal") = pub_SumarColumnaGrid(DGrid, 13, DGrid.RowCount - 1)
                row("gastos") = pub_SumarColumnaGrid(DGrid, 14, DGrid.RowCount - 1)
                row("impuesto") = pub_SumarColumnaGrid(DGrid, 15, DGrid.RowCount - 1)
                row("cargo") = pub_SumarColumnaGrid(DGrid, 16, DGrid.RowCount - 1)
                row("credito") = pub_SumarColumnaGrid(DGrid, 17, DGrid.RowCount - 1)
                row("descuento") = pub_SumarColumnaGrid(DGrid, 18, DGrid.RowCount - 1)
                row("importe") = pub_SumarColumnaGrid(DGrid, 19, DGrid.RowCount - 1)

                dt.Rows.InsertAt(row, 0)
                DGrid.DataSource = dt

                DGrid.RowHeadersVisible = False
                DGrid.Columns("sucursal").HeaderText = "Sucursal" 'oculto
                DGrid.Columns("factprov").HeaderText = "FactProv"
                DGrid.Columns("idfolio").HeaderText = "IdFolio" 'oculto
                DGrid.Columns("idfoliosuc").HeaderText = "Folio Bulto"
                DGrid.Columns("marca").HeaderText = "Marca"
                DGrid.Columns("referenc").HeaderText = "Referenc"
                DGrid.Columns("status").HeaderText = "Estatus"
                DGrid.Columns("fecha").HeaderText = "Fecha Factura"
                DGrid.Columns("dias").HeaderText = "Días por Vencer"
                DGrid.Columns("fecvenc").HeaderText = "Fecha Vence"
                DGrid.Columns("dev").HeaderText = "Folio Devolución"
                DGrid.Columns("proveedor").HeaderText = "Proveedor"
                DGrid.Columns("pares").HeaderText = "Pares"
                DGrid.Columns("subtotal").HeaderText = "SubTotal"
                DGrid.Columns("gastos").HeaderText = "Gastos"
                DGrid.Columns("impuesto").HeaderText = "Impuesto"
                DGrid.Columns("cargo").HeaderText = "NCargo"
                DGrid.Columns("credito").HeaderText = "NCredito"
                DGrid.Columns("descuento").HeaderText = "Descuento"
                DGrid.Columns("importe").HeaderText = "Total"


                DGrid.Columns("sucursal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("factprov").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("marca").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("referenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("idfolio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("idfoliosuc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("fecvenc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("dev").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                DGrid.Columns("pares").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns("subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("gastos").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("impuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("cargo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns("importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns("subtotal").DefaultCellStyle.Format = "c"
                DGrid.Columns("gastos").DefaultCellStyle.Format = "c"
                DGrid.Columns("impuesto").DefaultCellStyle.Format = "c"
                DGrid.Columns("cargo").DefaultCellStyle.Format = "c"
                DGrid.Columns("credito").DefaultCellStyle.Format = "c"
                DGrid.Columns("descuento").DefaultCellStyle.Format = "c"
                DGrid.Columns("importe").DefaultCellStyle.Format = "c"

                DGrid.Columns("sucursal").Visible = False
                DGrid.Columns("idfolio").Visible = False
                DGrid.Columns("referenc").Visible = False

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                For i As Integer = 0 To 3
                    DGrid.Columns(i).DefaultCellStyle.BackColor = Color.PowderBlue
                    DGrid.Columns(i).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Next

                'DGrid.Columns("saldoact").Frozen = True
                'DGrid.Columns("idproveedor").Visible = False
                'DGrid.Columns("ejercicio").Visible = False

                DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            End If

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

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            'Dim Sw_NoEntro As Boolean = False
            'If Opcion <> 3 Then Exit Sub

            'Dim DiasEntrega As Integer = 0
            'If Sw_Pintar = False Then Exit Sub
            ''If Opcion <> 1 Then Exit Sub

            'If Me.DGrid.Columns(e.ColumnIndex).Name <> "dias" Then Exit Sub
            'If e.RowIndex = DGrid.RowCount - 1 Then
            '    If Sw_Load = False Then
            '        Sw_Pintar = False
            '    End If
            '    Exit Sub
            'End If

            'If IsNothing(DGrid.Rows(e.RowIndex).Cells("dias").Value) Then Exit Sub
            'If IsDBNull(DGrid.Rows(e.RowIndex).Cells("dias").Value) Then Exit Sub


            'If DGrid.Rows(e.RowIndex).Cells("dias").Value < 0 Then
            '    DGrid.Rows(e.RowIndex).Cells("dias").Style.BackColor = Color.Red
            '    DGrid.Rows(e.RowIndex).Cells("dias").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            'End If

            'If DGrid.Rows(e.RowIndex).Cells("dev").Value <> "" Then
            '    DGrid.Rows(e.RowIndex).Cells("dev").Style.BackColor = Color.Yellow
            '    DGrid.Rows(e.RowIndex).Cells("dev").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            '    If DGrid.Rows(e.RowIndex).Cells("cargo").Value = 0 Then
            '        DGrid.Rows(e.RowIndex).Cells("dev").Style.BackColor = Color.Red
            '        DGrid.Rows(e.RowIndex).Cells("dev").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

            '    End If

            'End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            If IsDBNull(DGrid.CurrentRow.Cells(DGrid.Columns.Count - 1).Value) Then
                Exit Sub
            End If


            'If columna <= 2 Then
            If Opcion = 1 Then 'proveedor 
                If ProveedorB <> "" Then
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL:" Then

                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                Else
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL: " Then
                        ProveedorB = ""
                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                End If

                OpcionAnt = Opcion

                Opcion = 2

                RellenaGrid()
                Btn_Regresar.Enabled = True
                Exit Sub


            ElseIf Opcion = 2 Then
                Dim NombreCol As String = ""
                If ProveedorB <> "" Then
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL:" Then

                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                Else
                    If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL: " Then
                        ProveedorB = ""
                    Else
                        ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
                    End If
                End If

                If OpcionAnt = Opcion Then
                    Exit Sub
                Else
                    OpcionAnt = Opcion
                End If

                NombreCol = Me.DGrid.Columns(columna).Name
                GeneraFechas(NombreCol)
                OpcionAnt = Opcion
                Opcion = 3

                RellenaGrid()
                Btn_Regresar.Enabled = True
                Exit Sub
            End If
            'End If


            'If columna >= 4 Then
            '    Dim NombreCol As String = ""
            '    If Opcion = 1 Then 'proveedor 

            '        If DGrid.CurrentCell.Value = 0 Then Exit Sub

            '        If ProveedorB <> "" Then
            '            If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL:" Then

            '            Else
            '                ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
            '            End If
            '        Else
            '            If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL: " Then
            '                ProveedorB = ""
            '            Else
            '                ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
            '            End If
            '        End If

            '        NombreCol = Me.DGrid.Columns(columna).Name
            '        GeneraFechas(NombreCol)
            '        OpcionAnt = Opcion

            '        Opcion = 3

            '        RellenaGrid()
            '        Btn_Regresar.Enabled = True
            '        Exit Sub


            '    ElseIf Opcion = 2 Then

            '        If DGrid.CurrentCell.Value = 0 Then Exit Sub

            '        If ProveedorB <> "" Then
            '            If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL:" Then

            '            Else
            '                ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
            '            End If
            '        Else
            '            If DGrid.CurrentRow.Cells("raz_soc").Value = "TOTAL: " Then
            '                ProveedorB = ""
            '            Else
            '                ProveedorB = DGrid.CurrentRow.Cells("proveedor").Value
            '            End If
            '        End If

            '        NombreCol = Me.DGrid.Columns(columna).Name
            '        GeneraFechas(NombreCol)
            '        OpcionAnt = Opcion
            '        Opcion = 3

            '        RellenaGrid()
            '        Btn_Regresar.Enabled = True
            '        Exit Sub
            '    End If
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GeneraFechas(ByVal NomCol As String)
        Dim Anio As Integer = 0
        Dim Mes As Integer = 0
        Dim DiaIni As Integer = 1
        Dim DiaFin As Integer = 0
        Try

            Anio = CInt(Txt_Ejercicio.Text)

            If NomCol = "saldoact" Then

                FecIni = New Date(Anio, 1, 1)
                FecFin = New Date(Anio, 12, 31)
                FecFin = DateAdd(DateInterval.Day, -1, FecFin)

            ElseIf NomCol = "saldoant" Then

                FecIni = "1900-01-01"
                FecFin = New Date(Anio, 1, 1)
                FecFin = DateAdd(DateInterval.Day, -1, FecFin)

            ElseIf NomCol = "enero" Then
                Mes = 1
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "febrero" Then
                Dim FEcFeb As Date
                Mes = 2
                FEcFeb = DateSerial(Anio, Mes + 1, 0)
                DiaFin = FEcFeb.Day

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "marzo" Then
                Mes = 3
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "abril" Then
                Mes = 4
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "mayo" Then
                Mes = 5
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "junio" Then
                Mes = 6
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "julio" Then
                Mes = 7
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "agosto" Then
                Mes = 8
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "septiembre" Then
                Mes = 9
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "octubre" Then
                Mes = 10
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "noviembre" Then
                Mes = 11
                DiaFin = 30

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "diciembre" Then
                Mes = 12
                DiaFin = 31

                FecIni = New Date(Anio, Mes, DiaIni)
                FecFin = New Date(Anio, Mes, DiaFin)

            ElseIf NomCol = "saldopos" Then

                FecIni = New Date(Anio, 12, 31)
                FecIni = DateAdd(DateInterval.Day, 1, FecIni)
                FecFin = "2050-12-31"

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 3 Then
                Opcion = OpcionAnt

                MarcaB = ""
                ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If

            ElseIf Opcion = 2 Then

                If Opcion = OpcionAnt Then
                    Opcion = 1
                Else
                    Opcion = OpcionAnt
                End If
                MarcaB = ""
                ProveedorB = ""

                RellenaGrid()

                If Opcion = 1 Then
                    Btn_Regresar.Enabled = False
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Rb_Todos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_Todos.CheckedChanged
        Try
            If Rb_Todos.Checked = True Then
                ImportadosB = "0"
                RellenaGrid()
            ElseIf Rb_Todos.Checked = False Then

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Rb_NoImp_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_NoImp.CheckedChanged
        Try
            If Rb_NoImp.Checked = True Then
                ImportadosB = "2"
                RellenaGrid()
            ElseIf Rb_NoImp.Checked = False Then

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Rb_Importados_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rb_Importados.CheckedChanged
        Try
            If Rb_Importados.Checked = True Then
                ImportadosB = "1"
                RellenaGrid()
            ElseIf Rb_Importados.Checked = False Then

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Ejercicio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Ejercicio.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim Anio As Integer = 0

            If Txt_Ejercicio.Text.Length < 4 Then Exit Sub
            Anio = CInt(Txt_Ejercicio.Text)

            If Txt_Ejercicio.Text.Length = 4 Then
                EjercicioB = CInt(Txt_Ejercicio.Text)
            Else
                MessageBox.Show("Ingrese un año válido")
                Exit Sub
            End If

            RellenaGrid()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


End Class