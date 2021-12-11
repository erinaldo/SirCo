<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalVentasDistribuidores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalVentasDistribuidores))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Pnl_Bar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pbar1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.LBL_PORC = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColDistribuidor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColFechaAlta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLimiteCredito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSaldo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col1000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col2000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col3000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col4000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col5000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col6000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col7000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col8000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col9000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col10000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col20000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col30000 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Col30000mas = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTotalGeneral = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Lbl_RangoFechas = New System.Windows.Forms.Label()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pbar1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.PBox)
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Bar)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1284, 451)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PBox
        '
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(870, 20)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(308, 248)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 39
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'Pnl_Bar
        '
        Me.Pnl_Bar.Controls.Add(Me.PictureBox1)
        Me.Pnl_Bar.Controls.Add(Me.Pbar1)
        Me.Pnl_Bar.Controls.Add(Me.LBL_PORC)
        Me.Pnl_Bar.Controls.Add(Me.Label1)
        Me.Pnl_Bar.Location = New System.Drawing.Point(236, 130)
        Me.Pnl_Bar.Name = "Pnl_Bar"
        Me.Pnl_Bar.Size = New System.Drawing.Size(473, 98)
        Me.Pnl_Bar.TabIndex = 38
        Me.Pnl_Bar.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SIRCO.My.Resources.Resources.ordenador04
        Me.PictureBox1.Location = New System.Drawing.Point(9, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Pbar1
        '
        Me.Pbar1.Location = New System.Drawing.Point(113, 39)
        Me.Pbar1.Name = "Pbar1"
        Me.Pbar1.Size = New System.Drawing.Size(349, 27)
        Me.Pbar1.TabIndex = 40
        '
        'LBL_PORC
        '
        Me.LBL_PORC.AutoSize = True
        Me.LBL_PORC.Location = New System.Drawing.Point(245, 69)
        Me.LBL_PORC.Name = "LBL_PORC"
        Me.LBL_PORC.Size = New System.Drawing.Size(39, 13)
        Me.LBL_PORC.TabIndex = 3
        Me.LBL_PORC.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Espere mientras procesamos la información..."
        '
        'DGrid
        '
        Me.DGrid.Location = New System.Drawing.Point(-2, -2)
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(1284, 451)
        Me.DGrid.TabIndex = 37
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColDistribuidor, Me.ColFechaAlta, Me.ColEstatus, Me.ColLimiteCredito, Me.ColSaldo, Me.colFecha, Me.Col1000, Me.Col2000, Me.Col3000, Me.Col4000, Me.Col5000, Me.Col6000, Me.Col7000, Me.Col8000, Me.Col9000, Me.Col10000, Me.Col20000, Me.Col30000, Me.Col30000mas, Me.ColTotalGeneral, Me.ColDistrib})
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        '
        'ColDistribuidor
        '
        Me.ColDistribuidor.Caption = "Distribuidor"
        Me.ColDistribuidor.FieldName = "Distribuidor"
        Me.ColDistribuidor.Name = "ColDistribuidor"
        Me.ColDistribuidor.Visible = True
        Me.ColDistribuidor.VisibleIndex = 0
        '
        'ColFechaAlta
        '
        Me.ColFechaAlta.Caption = "Fecha Alta"
        Me.ColFechaAlta.FieldName = "Fecha Alta"
        Me.ColFechaAlta.Name = "ColFechaAlta"
        Me.ColFechaAlta.Visible = True
        Me.ColFechaAlta.VisibleIndex = 1
        '
        'ColEstatus
        '
        Me.ColEstatus.Caption = "Estatus"
        Me.ColEstatus.FieldName = "Estatus"
        Me.ColEstatus.Name = "ColEstatus"
        Me.ColEstatus.Visible = True
        Me.ColEstatus.VisibleIndex = 2
        '
        'ColLimiteCredito
        '
        Me.ColLimiteCredito.Caption = "Limite credito"
        Me.ColLimiteCredito.FieldName = "LimiteCredito"
        Me.ColLimiteCredito.Name = "ColLimiteCredito"
        Me.ColLimiteCredito.Visible = True
        Me.ColLimiteCredito.VisibleIndex = 3
        '
        'ColSaldo
        '
        Me.ColSaldo.Caption = "Saldo"
        Me.ColSaldo.FieldName = "Saldo"
        Me.ColSaldo.Name = "ColSaldo"
        Me.ColSaldo.Visible = True
        Me.ColSaldo.VisibleIndex = 4
        '
        'colFecha
        '
        Me.colFecha.Caption = "Fecha"
        Me.colFecha.FieldName = "fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.Visible = True
        Me.colFecha.VisibleIndex = 5
        '
        'Col1000
        '
        Me.Col1000.AppearanceHeader.Options.UseBackColor = True
        Me.Col1000.Caption = "$1,000.00"
        Me.Col1000.FieldName = "mil"
        Me.Col1000.Name = "Col1000"
        Me.Col1000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mil", "SUMA={0:#.##}")})
        Me.Col1000.Visible = True
        Me.Col1000.VisibleIndex = 6
        '
        'Col2000
        '
        Me.Col2000.Caption = "$2,000.00"
        Me.Col2000.FieldName = "dosmil"
        Me.Col2000.Name = "Col2000"
        Me.Col2000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dosmil", "SUMA={0:#.##}")})
        Me.Col2000.Visible = True
        Me.Col2000.VisibleIndex = 7
        '
        'Col3000
        '
        Me.Col3000.Caption = "$3,000.00"
        Me.Col3000.FieldName = "tresmil"
        Me.Col3000.Name = "Col3000"
        Me.Col3000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tresmil", "SUMA={0:#.##}")})
        Me.Col3000.Visible = True
        Me.Col3000.VisibleIndex = 8
        '
        'Col4000
        '
        Me.Col4000.Caption = "$4,000.00"
        Me.Col4000.FieldName = "cuatromil"
        Me.Col4000.Name = "Col4000"
        Me.Col4000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cuatromil", "SUMA={0:#.##}")})
        Me.Col4000.Visible = True
        Me.Col4000.VisibleIndex = 9
        '
        'Col5000
        '
        Me.Col5000.Caption = "$5,000.00"
        Me.Col5000.FieldName = "cincomil"
        Me.Col5000.Name = "Col5000"
        Me.Col5000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cincomil", "SUMA={0:#.##}")})
        Me.Col5000.Visible = True
        Me.Col5000.VisibleIndex = 10
        '
        'Col6000
        '
        Me.Col6000.Caption = "$6,000.00"
        Me.Col6000.FieldName = "seismil"
        Me.Col6000.Name = "Col6000"
        Me.Col6000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "seismil", "SUMA={0:#.##}")})
        Me.Col6000.Visible = True
        Me.Col6000.VisibleIndex = 11
        '
        'Col7000
        '
        Me.Col7000.Caption = "$7,000.00"
        Me.Col7000.FieldName = "sietemil"
        Me.Col7000.Name = "Col7000"
        Me.Col7000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sietemil", "SUMA={0:#.##}")})
        Me.Col7000.Visible = True
        Me.Col7000.VisibleIndex = 12
        '
        'Col8000
        '
        Me.Col8000.Caption = "$8,000.00"
        Me.Col8000.FieldName = "ochomil"
        Me.Col8000.Name = "Col8000"
        Me.Col8000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ochomil", "SUMA={0:#.##}")})
        Me.Col8000.Visible = True
        Me.Col8000.VisibleIndex = 13
        '
        'Col9000
        '
        Me.Col9000.Caption = "$9,000.00"
        Me.Col9000.FieldName = "nuevemil"
        Me.Col9000.Name = "Col9000"
        Me.Col9000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nuevemil", "SUMA={0:#.##}")})
        Me.Col9000.Visible = True
        Me.Col9000.VisibleIndex = 14
        '
        'Col10000
        '
        Me.Col10000.Caption = "$10,000.00"
        Me.Col10000.FieldName = "diezmil"
        Me.Col10000.Name = "Col10000"
        Me.Col10000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diezmil", "SUMA={0:#.##}")})
        Me.Col10000.Visible = True
        Me.Col10000.VisibleIndex = 15
        '
        'Col20000
        '
        Me.Col20000.Caption = "$20,000.00"
        Me.Col20000.FieldName = "veintemil"
        Me.Col20000.Name = "Col20000"
        Me.Col20000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "veintemil", "SUMA={0:#.##}")})
        Me.Col20000.Visible = True
        Me.Col20000.VisibleIndex = 16
        '
        'Col30000
        '
        Me.Col30000.Caption = "$30,000.00"
        Me.Col30000.FieldName = "treintamil"
        Me.Col30000.Name = "Col30000"
        Me.Col30000.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "treintamil", "SUMA={0:#.##}")})
        Me.Col30000.Visible = True
        Me.Col30000.VisibleIndex = 17
        '
        'Col30000mas
        '
        Me.Col30000mas.Caption = "$30,000.00+"
        Me.Col30000mas.FieldName = "treintamilmas"
        Me.Col30000mas.Name = "Col30000mas"
        Me.Col30000mas.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "treintamilmas", "SUMA={0:#.##}")})
        Me.Col30000mas.Visible = True
        Me.Col30000mas.VisibleIndex = 18
        '
        'ColTotalGeneral
        '
        Me.ColTotalGeneral.Caption = "Total General"
        Me.ColTotalGeneral.FieldName = "totalGeneral"
        Me.ColTotalGeneral.Name = "ColTotalGeneral"
        Me.ColTotalGeneral.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totalGeneral", "SUMA={0:#.##}")})
        Me.ColTotalGeneral.Visible = True
        Me.ColTotalGeneral.VisibleIndex = 20
        '
        'ColDistrib
        '
        Me.ColDistrib.Caption = "Distrib"
        Me.ColDistrib.FieldName = "distrib"
        Me.ColDistrib.Name = "ColDistrib"
        Me.ColDistrib.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "distrib", "SUMA={0:#.##}")})
        Me.ColDistrib.Visible = True
        Me.ColDistrib.VisibleIndex = 19
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProveedorToolStripMenuItem, Me.ModificarProveedorToolStripMenuItem, Me.ConsultarProveedorToolStripMenuItem})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(183, 70)
        '
        'NuevoProveedorToolStripMenuItem
        '
        Me.NuevoProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProveedorToolStripMenuItem.Name = "NuevoProveedorToolStripMenuItem"
        Me.NuevoProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.NuevoProveedorToolStripMenuItem.Text = "Nuevo Proveedor"
        '
        'ModificarProveedorToolStripMenuItem
        '
        Me.ModificarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarProveedorToolStripMenuItem.Name = "ModificarProveedorToolStripMenuItem"
        Me.ModificarProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ModificarProveedorToolStripMenuItem.Text = "Modificar Proveedor"
        '
        'ConsultarProveedorToolStripMenuItem
        '
        Me.ConsultarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarProveedorToolStripMenuItem.Name = "ConsultarProveedorToolStripMenuItem"
        Me.ConsultarProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ConsultarProveedorToolStripMenuItem.Text = "Consultar Proveedor"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_RangoFechas)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 451)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1284, 53)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(1076, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 49)
        Me.Btn_Regresar.TabIndex = 35
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        '
        'Lbl_RangoFechas
        '
        Me.Lbl_RangoFechas.AutoSize = True
        Me.Lbl_RangoFechas.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RangoFechas.Location = New System.Drawing.Point(108, 16)
        Me.Lbl_RangoFechas.Name = "Lbl_RangoFechas"
        Me.Lbl_RangoFechas.Size = New System.Drawing.Size(53, 20)
        Me.Lbl_RangoFechas.TabIndex = 14
        Me.Lbl_RangoFechas.Text = "Fecha:"
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(1127, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 49)
        Me.Btn_Filtro.TabIndex = 13
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1178, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 49)
        Me.Btn_Excel.TabIndex = 7
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1229, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 49)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmPpalVentasDistribuidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 504)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalVentasDistribuidores"
        Me.Text = "Reporte de Ventas Distribuidores"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pbar1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Lbl_RangoFechas As System.Windows.Forms.Label
    Friend WithEvents Btn_Regresar As System.Windows.Forms.Button
    Friend WithEvents PBox As PictureBox
    Friend WithEvents Pnl_Bar As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LBL_PORC As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Pbar1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents ColDistribuidor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColFechaAlta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLimiteCredito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSaldo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col1000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col2000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col3000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col4000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col5000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col6000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col7000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col8000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col9000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col10000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col20000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col30000 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Col30000mas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotalGeneral As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDistrib As DevExpress.XtraGrid.Columns.GridColumn
End Class
