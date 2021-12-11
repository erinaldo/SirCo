Public Class frmPpalInventSucursales
    'mreyes 18/Octubre/2012 01:54 p.m.
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Private objDataSet As Data.DataSet
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim Sw_Load As Boolean = True


    Public Opcion As Integer = 0
    Dim OpcionAnterior As Integer
    Dim OpcionAntAnt As Integer
    Dim OpcionAntAntAnt As Integer
    Dim OpcionAntAntAntAnt As Integer
    Public Sucursal As String = ""
    Public Marca As String = ""
    Public Estilon As String = ""
    Public Proveedor As String = ""
    Public SucursalAnterior As String = ""
    Public MarcaAnterior As String = ""
    Public EstilonAnterior As String = ""
    Public ProveedorAnterior As String = ""

    Private Sub frmPpalNomina_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmPpalProveedores_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Close()
            End If

            If e.KeyCode = Keys.F5 Then
                Call Btn_Filtro_Click_1(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmPpalProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Opcion = 0 Then
                Opcion = 1
            End If
            RellenaGrid()
            GenerarToolTip()
            'Btn_Filtro.Enabled = False
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub GenerarToolTip()
        Try
            '
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Foto, "Imagen del Producto")
            ToolTip.SetToolTip(Btn_Sucursal, "Inventario por Sucursal")
            ToolTip.SetToolTip(Btn_Marca, "Inventario por Marca")
            ToolTip.SetToolTip(Btn_Proveedor, "Inventario por Proveedor")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLInventario(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                'If Sucursal = "" Then
                '    Sucursal = 15
                'End If
                objDataSet = objRegistro.usp_PpalInventario(Opcion, Sucursal, Marca, Estilon, Proveedor)
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    Sw_Pintar = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontro Información que cumpla con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                SucursalAnterior = Sucursal
                MarcaAnterior = Marca
                EstilonAnterior = Estilon
                ProveedorAnterior = Proveedor
                Sucursal = ""
                Marca = ""
                Estilon = ""
                Proveedor = ""
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try
            DGrid.RowHeadersVisible = False
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            If Opcion = 1 Then
                DGrid.Columns(0).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(0).HeaderText = "Sucursal"
                DGrid.Columns(1).HeaderText = "PRS"
                DGrid.Columns(2).HeaderText = "Costo"
                DGrid.Columns(3).HeaderText = "Venta"
                DGrid.Columns(2).DefaultCellStyle.Format = "c"
                DGrid.Columns(3).DefaultCellStyle.Format = "c"
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                InicioToolStripMenuItem.Visible = False
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = True
                MarcaToolStripMenuItem.Visible = True
                ModeloToolStripMenuItem.Visible = True
            End If

            If Opcion = 2 Then
                DGrid.Columns(0).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.Columns(0).HeaderText = "Det"
                DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(2).HeaderText = "PRS"
                DGrid.Columns(3).HeaderText = "Costo"
                DGrid.Columns(4).HeaderText = "Venta"
                DGrid.Columns(3).DefaultCellStyle.Format = "c"
                DGrid.Columns(4).DefaultCellStyle.Format = "c"
                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "

                row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = False
                ProveedorToolStripMenuItem.Visible = True
                MarcaToolStripMenuItem.Visible = True
                ModeloToolStripMenuItem.Visible = True
            End If

            If Opcion = 3 Then
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                
                'DGrid.Columns(2).Frozen = True
                'DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                'DGrid.Columns(4).Frozen = True
                'DGrid.Columns(4).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(4).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                'DGrid.Columns(0).HeaderText = "Det"
                'DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(0).HeaderText = "Proveedor"
                DGrid.Columns(1).HeaderText = "Marca"
                DGrid.Columns(2).HeaderText = "Marca"
                DGrid.Columns(3).HeaderText = "PRS"
                DGrid.Columns(4).HeaderText = "Costo"
                DGrid.Columns(5).HeaderText = "Venta"
                DGrid.Columns(4).DefaultCellStyle.Format = "c"
                DGrid.Columns(5).DefaultCellStyle.Format = "c"
                'DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "

                row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt

                DGrid.Columns(0).Visible = False
                DGrid.Columns(2).Visible = False
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = True
                MarcaToolStripMenuItem.Visible = False
                ModeloToolStripMenuItem.Visible = True
            End If

            If Opcion = 4 Then
                'DGrid.Columns(0).Frozen = True
                'DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                'DGrid.Columns(1).Frozen = True
                'DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                'DGrid.Columns(0).Visible = False
                'DGrid.Columns(1).Frozen = True
                'DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                'DGrid.Columns(0).HeaderText = "Det"
                'DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(0).HeaderText = "Proveedor"
                DGrid.Columns(1).HeaderText = "Proveedor"
                DGrid.Columns(2).HeaderText = "PRS"
                DGrid.Columns(3).HeaderText = "Costo"
                DGrid.Columns(4).HeaderText = "Venta"
                DGrid.Columns(3).DefaultCellStyle.Format = "c"
                DGrid.Columns(4).DefaultCellStyle.Format = "c"
                'DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "

                row(2) = pub_SumarColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
                row(3) = pub_SumarColumnaGrid(DGrid, 3, DGrid.RowCount - 1)
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt

                DGrid.Columns(0).Visible = False
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = False
                MarcaToolStripMenuItem.Visible = True
                ModeloToolStripMenuItem.Visible = True
            End If

            If Opcion = 5 Then
                DGrid.Columns(0).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).Visible = False
                'DGrid.Columns(1).Frozen = True
                'DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                'DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                'DGrid.Columns(0).HeaderText = "Det"
                'DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(0).HeaderText = "Marca"
                DGrid.Columns(1).HeaderText = "Marca"
                DGrid.Columns(2).HeaderText = "Modelo"
                DGrid.Columns(3).HeaderText = "Descripción"
                DGrid.Columns(4).HeaderText = "Categoria"
                DGrid.Columns(5).HeaderText = "PRS"
                DGrid.Columns(6).HeaderText = "Último Recibo"
                DGrid.Columns(7).HeaderText = "Dias"
                DGrid.Columns(8).HeaderText = "Costo"
                DGrid.Columns(9).HeaderText = "Venta"
                DGrid.Columns(8).DefaultCellStyle.Format = "c"
                DGrid.Columns(9).DefaultCellStyle.Format = "c"
                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(3) = "Total: "
                row(4) = CStr(DGrid.RowCount - 1) + " Artículos"
                row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row(8) = pub_SumarColumnaGrid(DGrid, 8, DGrid.RowCount - 1)
                row(9) = pub_SumarColumnaGrid(DGrid, 9, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = True
                MarcaToolStripMenuItem.Visible = True
                ModeloToolStripMenuItem.Visible = False
            End If

            If Opcion = 6 Then
                DGrid.Columns(0).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(2).Frozen = True
                DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(3).Frozen = True
                DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                
                DGrid.Columns(0).HeaderText = "Det"
                DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(2).HeaderText = "Proveedor"
                DGrid.Columns(3).HeaderText = "Proveedor"
                DGrid.Columns(4).HeaderText = "PRS"
                DGrid.Columns(5).HeaderText = "Costo"
                DGrid.Columns(6).HeaderText = "Venta"
                DGrid.Columns(5).DefaultCellStyle.Format = "c"
                DGrid.Columns(6).DefaultCellStyle.Format = "c"
                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "
                row(3) = CStr(DGrid.RowCount - 1) + " Proveedores"
                row(4) = pub_SumarColumnaGrid(DGrid, 4, DGrid.RowCount - 1)
                row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt
                DGrid.Columns(0).Visible = False
                DGrid.Columns(2).Visible = False
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = False
                MarcaToolStripMenuItem.Visible = True
                ModeloToolStripMenuItem.Visible = True
            End If

            If Opcion = 7 Then
                DGrid.Columns(0).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(2).Frozen = True
                DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(3).Frozen = True
                DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.Columns(0).HeaderText = "Det"
                DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(2).HeaderText = "Proveedor"
                DGrid.Columns(3).HeaderText = "Marca"
                DGrid.Columns(4).HeaderText = "Marca"
                DGrid.Columns(5).HeaderText = "PRS"
                DGrid.Columns(6).HeaderText = "Costo"
                DGrid.Columns(7).HeaderText = "Venta"
                DGrid.Columns(6).DefaultCellStyle.Format = "c"
                DGrid.Columns(7).DefaultCellStyle.Format = "c"
                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(1) = "Total: "
                row(3) = CStr(DGrid.RowCount - 1) + " Marcas"
                row(5) = pub_SumarColumnaGrid(DGrid, 5, DGrid.RowCount - 1)
                row(6) = pub_SumarColumnaGrid(DGrid, 6, DGrid.RowCount - 1)
                row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt
                DGrid.Columns(0).Visible = False
                DGrid.Columns(2).Visible = False
                DGrid.Columns(4).Visible = False
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = True
                MarcaToolStripMenuItem.Visible = False
                ModeloToolStripMenuItem.Visible = True
            End If

            If Opcion = 8 Then
                DGrid.Columns(0).Frozen = True
                DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(1).Frozen = True
                DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(2).Frozen = True
                DGrid.Columns(2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.Columns(3).Frozen = True
                DGrid.Columns(3).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Columns(3).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.Columns(0).HeaderText = "Det"
                DGrid.Columns(1).HeaderText = "Sucursal"
                DGrid.Columns(2).HeaderText = "Marca"
                DGrid.Columns(3).HeaderText = "Marca"
                DGrid.Columns(4).HeaderText = "Modelo"
                DGrid.Columns(5).HeaderText = "Descripción"
                DGrid.Columns(6).HeaderText = "Categoria"
                DGrid.Columns(7).HeaderText = "PRS"
                DGrid.Columns(8).HeaderText = "Último Recibo"
                DGrid.Columns(9).HeaderText = "Dias"
                DGrid.Columns(10).HeaderText = "Costo"
                DGrid.Columns(11).HeaderText = "Venta"
                DGrid.Columns(10).DefaultCellStyle.Format = "c"
                DGrid.Columns(11).DefaultCellStyle.Format = "c"
                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

                Dim row As DataRow = dt.NewRow()

                row(5) = "Total: "
                row(6) = CStr(DGrid.RowCount - 1) + " Artículos"
                row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)
                row(10) = pub_SumarColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
                row(11) = pub_SumarColumnaGrid(DGrid, 11, DGrid.RowCount - 1)
                dt.Rows.Add(row)
                DGrid.DataSource = dt
                DGrid.Columns(0).Visible = False
                DGrid.Columns(3).Visible = False
                InicioToolStripMenuItem.Visible = True
                SucursalToolStripMenuItem.Visible = True
                ProveedorToolStripMenuItem.Visible = True
                MarcaToolStripMenuItem.Visible = True
                ModeloToolStripMenuItem.Visible = False
            End If

            If Opcion <> 1 Then
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Rows(DGrid.RowCount - 2).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            End If

            'If Opcion <> 3 Then
            PBox.Visible = False
            'End If

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

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        
    End Sub

    Private Sub DGrid_KeyUp_1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        Try
            If Opcion = 5 Or Opcion = 8 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
                    Exit Sub
                End If
                CargarFotoArticulo(DGrid.CurrentRow.Cells("marca").Value, DGrid.CurrentRow.Cells("estilon").Value)
            End If
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
            ESTILONFOTO = Estilon
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

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Foto.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try
            If Opcion = 5 Or Opcion = 8 Then
                If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells("marca").Value) Then
                    Exit Sub
                End If
                CargarFotoArticulo(DGrid.CurrentRow.Cells("marca").Value, DGrid.CurrentRow.Cells("estilon").Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    
    Private Sub Btn_Sucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sucursal.Click
        Try
            OpcionAntAntAntAnt = OpcionAntAntAnt
            OpcionAntAntAnt = OpcionAntAnt
            OpcionAntAnt = OpcionAnterior
            OpcionAnterior = Opcion
            Opcion = 2
            RellenaGrid()
            'Btn_Filtro.Enabled = False
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Marca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Marca.Click
        Try
            OpcionAntAntAntAnt = OpcionAntAntAnt
            OpcionAntAntAnt = OpcionAntAnt
            OpcionAntAnt = OpcionAnterior
            OpcionAnterior = Opcion
            Opcion = 3
            RellenaGrid()
            Btn_Filtro.Enabled = True
            Btn_Foto.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Proveedor.Click
        Try
            OpcionAntAntAntAnt = OpcionAntAntAnt
            OpcionAntAntAnt = OpcionAntAnt
            OpcionAntAnt = OpcionAnterior
            OpcionAnterior = Opcion
            Opcion = 4
            RellenaGrid()
            Btn_Filtro.Enabled = True
            Btn_Foto.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            If Opcion = 1 Then
                Btn_Sucursal_Click(sender, e)
                Exit Sub
            End If
            If Opcion = 2 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value.ToString
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 6
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 3 Then
                Marca = DGrid.CurrentRow.Cells("marca").Value.ToString
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value.ToString
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 5
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 4 Then
                'Sucursal = DGrid.CurrentRow.Cells("sucursal").Value.ToString
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value.ToString
                Btn_Marca_Click(sender, e)
                Exit Sub
            End If
            If Opcion = 5 Then
                Btn_Foto_Click(sender, e)
                Exit Sub
            End If
            If Opcion = 6 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value.ToString
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value.ToString
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 7
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 7 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value.ToString
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value.ToString
                Marca = DGrid.CurrentRow.Cells("marca").Value.ToString
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 8
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 8 Then
                Btn_Foto_Click(sender, e)
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Opcion = 1 Then Exit Sub
            If Opcion = 2 Then
                Opcion = OpcionAnterior
                OpcionAnterior = OpcionAntAnt
                OpcionAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAntAntAnt
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 3 Then
                Opcion = OpcionAnterior
                OpcionAnterior = OpcionAntAnt
                OpcionAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAntAntAnt
                Proveedor = ProveedorAnterior
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 4 Then
                'Opcion = OpcionAnterior
                'RellenaGrid()
            End If
            If Opcion = 5 Then
                Opcion = OpcionAnterior
                OpcionAnterior = OpcionAntAnt
                OpcionAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAntAntAnt
                Proveedor = ProveedorAnterior
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 6 Then
                Opcion = OpcionAnterior
                OpcionAnterior = OpcionAntAnt
                OpcionAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAntAntAnt
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 7 Then
                Opcion = OpcionAnterior
                OpcionAnterior = OpcionAntAnt
                OpcionAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAntAntAnt
                Sucursal = SucursalAnterior
                RellenaGrid()
                Exit Sub
            End If
            If Opcion = 8 Then
                Opcion = OpcionAnterior
                OpcionAnterior = OpcionAntAnt
                OpcionAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAntAntAnt
                Sucursal = SucursalAnterior
                Proveedor = ProveedorAnterior
                RellenaGrid()
                Exit Sub
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        Try
            Btn_Foto_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InicioToolStripMenuItem.Click
        Try
            If IsDBNull(DGrid.CurrentCell.Value) Then Exit Sub
            OpcionAntAntAntAnt = OpcionAntAntAnt
            OpcionAntAntAnt = OpcionAntAnt
            OpcionAntAnt = OpcionAnterior
            OpcionAnterior = Opcion
            Opcion = 1
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub SucursalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SucursalToolStripMenuItem.Click
        Try
            If IsDBNull(DGrid.CurrentCell.Value) Then Exit Sub
            OpcionAntAntAntAnt = OpcionAntAntAnt
            OpcionAntAntAnt = OpcionAntAnt
            OpcionAntAnt = OpcionAnterior
            OpcionAnterior = Opcion
            Opcion = 2
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ProveedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedorToolStripMenuItem.Click
        Try
            If IsDBNull(DGrid.CurrentCell.Value) Then Exit Sub
            If Opcion = 2 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 6
                RellenaGrid()
            End If
            If Opcion = 3 Then
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 4
                RellenaGrid()
            End If
            If Opcion = 5 Then
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 4
                RellenaGrid()
            End If
            If Opcion = 7 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 6
                RellenaGrid()
            End If
            If Opcion = 8 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 6
                RellenaGrid()
            End If
            If Opcion = 1 Then
                Btn_Proveedor_Click(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub MarcaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcaToolStripMenuItem.Click
        Try
            If IsDBNull(DGrid.CurrentCell.Value) Then Exit Sub
            If Opcion = 2 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 7
                RellenaGrid()
            End If
            If Opcion = 6 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 7
                RellenaGrid()
            End If
            If Opcion = 8 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 7
                RellenaGrid()
            End If
            If Opcion = 4 Then
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 3
                RellenaGrid()
            End If
            If Opcion = 5 Then
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 3
                RellenaGrid()
            End If
            If Opcion = 1 Then
                Btn_Marca_Click(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ModeloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModeloToolStripMenuItem.Click
        Try
            If IsDBNull(DGrid.CurrentCell.Value) Then Exit Sub
            If Opcion = 2 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 8
                RellenaGrid()
            End If
            If Opcion = 6 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 8
                RellenaGrid()
            End If
            If Opcion = 7 Then
                Sucursal = DGrid.CurrentRow.Cells("sucursal").Value
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value
                Marca = DGrid.CurrentRow.Cells("marca").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 8
                RellenaGrid()
            End If
            If Opcion = 4 Then
                Proveedor = DGrid.CurrentRow.Cells("proveedor").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 5
                RellenaGrid()
            End If
            If Opcion = 1 Then
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 5
                RellenaGrid()
            End If
            If Opcion = 3 Then
                Marca = DGrid.CurrentRow.Cells("marca").Value
                OpcionAntAntAntAnt = OpcionAntAntAnt
                OpcionAntAntAnt = OpcionAntAnt
                OpcionAntAnt = OpcionAnterior
                OpcionAnterior = Opcion
                Opcion = 5
                RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            With Me.DGrid
                Dim Hitest As DataGridView.HitTestInfo = .HitTest(e.X, e.Y)
                If Hitest.Type = DataGridViewHitTestType.Cell Then
                    .CurrentCell = .Rows(Hitest.RowIndex).Cells(Hitest.ColumnIndex)
                End If
            End With
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub
End Class