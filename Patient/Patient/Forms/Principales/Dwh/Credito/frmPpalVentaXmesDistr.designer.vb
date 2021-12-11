<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalVentaXmesDistr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalVentaXmesDistr))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Pnl_Bar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LBL_PORC = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pbar1 = New System.Windows.Forms.ProgressBar()
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFecAlta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEnero = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFebrero = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMarzo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAbril = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMayo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJunio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJulio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAgosto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSeptiembre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOctubre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNoviembre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDiciembre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Txt_Ejercicio = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Txt_Ejercicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Pnl_Grid.Size = New System.Drawing.Size(963, 460)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PBox
        '
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(665, 51)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(270, 244)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 12
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'Pnl_Bar
        '
        Me.Pnl_Bar.Controls.Add(Me.PictureBox1)
        Me.Pnl_Bar.Controls.Add(Me.LBL_PORC)
        Me.Pnl_Bar.Controls.Add(Me.Label1)
        Me.Pnl_Bar.Controls.Add(Me.Pbar1)
        Me.Pnl_Bar.Location = New System.Drawing.Point(10, 111)
        Me.Pnl_Bar.Name = "Pnl_Bar"
        Me.Pnl_Bar.Size = New System.Drawing.Size(473, 98)
        Me.Pnl_Bar.TabIndex = 11
        Me.Pnl_Bar.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SIRCO.My.Resources.Resources.ordenador04
        Me.PictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
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
        'Pbar1
        '
        Me.Pbar1.Location = New System.Drawing.Point(99, 34)
        Me.Pbar1.Name = "Pbar1"
        Me.Pbar1.Size = New System.Drawing.Size(349, 22)
        Me.Pbar1.TabIndex = 1
        '
        'DGrid
        '
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(959, 456)
        Me.DGrid.TabIndex = 7
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDistrib, Me.colNombre, Me.colFecAlta, Me.colEstatus, Me.colTotal, Me.colEnero, Me.colFebrero, Me.colMarzo, Me.colAbril, Me.colMayo, Me.colJunio, Me.colJulio, Me.colAgosto, Me.colSeptiembre, Me.colOctubre, Me.colNoviembre, Me.colDiciembre})
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'colDistrib
        '
        Me.colDistrib.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDistrib.AppearanceHeader.Options.UseFont = True
        Me.colDistrib.AppearanceHeader.Options.UseTextOptions = True
        Me.colDistrib.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDistrib.Caption = "Distrib"
        Me.colDistrib.FieldName = "Distrib"
        Me.colDistrib.Name = "colDistrib"
        Me.colDistrib.Visible = True
        Me.colDistrib.VisibleIndex = 0
        '
        'colNombre
        '
        Me.colNombre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colNombre.AppearanceHeader.Options.UseFont = True
        Me.colNombre.AppearanceHeader.Options.UseTextOptions = True
        Me.colNombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colNombre.Caption = "Nombre"
        Me.colNombre.FieldName = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Visible = True
        Me.colNombre.VisibleIndex = 1
        '
        'colFecAlta
        '
        Me.colFecAlta.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colFecAlta.AppearanceHeader.Options.UseFont = True
        Me.colFecAlta.AppearanceHeader.Options.UseTextOptions = True
        Me.colFecAlta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFecAlta.Caption = "Fecha Alta"
        Me.colFecAlta.FieldName = "FECALTA"
        Me.colFecAlta.Name = "colFecAlta"
        Me.colFecAlta.Visible = True
        Me.colFecAlta.VisibleIndex = 2
        '
        'colEstatus
        '
        Me.colEstatus.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colEstatus.AppearanceHeader.Options.UseFont = True
        Me.colEstatus.AppearanceHeader.Options.UseTextOptions = True
        Me.colEstatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colEstatus.Caption = "Estatus"
        Me.colEstatus.FieldName = "Estatus"
        Me.colEstatus.Name = "colEstatus"
        Me.colEstatus.Visible = True
        Me.colEstatus.VisibleIndex = 3
        '
        'colTotal
        '
        Me.colTotal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colTotal.AppearanceHeader.Options.UseFont = True
        Me.colTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colTotal.Caption = "Total"
        Me.colTotal.DisplayFormat.FormatString = "###,###,###"
        Me.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colTotal.FieldName = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:$###,###,##0}")})
        Me.colTotal.Visible = True
        Me.colTotal.VisibleIndex = 4
        '
        'colEnero
        '
        Me.colEnero.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colEnero.AppearanceHeader.Options.UseFont = True
        Me.colEnero.AppearanceHeader.Options.UseTextOptions = True
        Me.colEnero.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colEnero.Caption = "Enero"
        Me.colEnero.DisplayFormat.FormatString = "###,###,###"
        Me.colEnero.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colEnero.FieldName = "Enero"
        Me.colEnero.Name = "colEnero"
        Me.colEnero.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Enero", "{0:$###,###,##0}")})
        Me.colEnero.Visible = True
        Me.colEnero.VisibleIndex = 5
        '
        'colFebrero
        '
        Me.colFebrero.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colFebrero.AppearanceHeader.Options.UseFont = True
        Me.colFebrero.AppearanceHeader.Options.UseTextOptions = True
        Me.colFebrero.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFebrero.Caption = "Febrero"
        Me.colFebrero.DisplayFormat.FormatString = "###,###,###"
        Me.colFebrero.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colFebrero.FieldName = "Febrero"
        Me.colFebrero.Name = "colFebrero"
        Me.colFebrero.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Febrero", "{0:$###,###,##0}")})
        Me.colFebrero.Visible = True
        Me.colFebrero.VisibleIndex = 6
        '
        'colMarzo
        '
        Me.colMarzo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colMarzo.AppearanceHeader.Options.UseFont = True
        Me.colMarzo.AppearanceHeader.Options.UseTextOptions = True
        Me.colMarzo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMarzo.Caption = "Marzo"
        Me.colMarzo.DisplayFormat.FormatString = "###,###,###"
        Me.colMarzo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colMarzo.FieldName = "Marzo"
        Me.colMarzo.Name = "colMarzo"
        Me.colMarzo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Marzo", "{0:$###,###,##0}")})
        Me.colMarzo.Visible = True
        Me.colMarzo.VisibleIndex = 7
        '
        'colAbril
        '
        Me.colAbril.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAbril.AppearanceHeader.Options.UseFont = True
        Me.colAbril.AppearanceHeader.Options.UseTextOptions = True
        Me.colAbril.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAbril.Caption = "Abril"
        Me.colAbril.DisplayFormat.FormatString = "###,###,###"
        Me.colAbril.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAbril.FieldName = "Abril"
        Me.colAbril.Name = "colAbril"
        Me.colAbril.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Abril", "{0:$###,###,##0}")})
        Me.colAbril.Visible = True
        Me.colAbril.VisibleIndex = 8
        '
        'colMayo
        '
        Me.colMayo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colMayo.AppearanceHeader.Options.UseFont = True
        Me.colMayo.AppearanceHeader.Options.UseTextOptions = True
        Me.colMayo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colMayo.Caption = "Mayo"
        Me.colMayo.DisplayFormat.FormatString = "###,###,###"
        Me.colMayo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colMayo.FieldName = "Mayo"
        Me.colMayo.Name = "colMayo"
        Me.colMayo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Mayo", "{0:$###,###,##0}")})
        Me.colMayo.Visible = True
        Me.colMayo.VisibleIndex = 9
        '
        'colJunio
        '
        Me.colJunio.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colJunio.AppearanceHeader.Options.UseFont = True
        Me.colJunio.AppearanceHeader.Options.UseTextOptions = True
        Me.colJunio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colJunio.Caption = "Junio"
        Me.colJunio.DisplayFormat.FormatString = "###,###,###"
        Me.colJunio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJunio.FieldName = "Junio"
        Me.colJunio.Name = "colJunio"
        Me.colJunio.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Junio", "{0:$###,###,##0}")})
        Me.colJunio.Visible = True
        Me.colJunio.VisibleIndex = 10
        '
        'colJulio
        '
        Me.colJulio.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colJulio.AppearanceHeader.Options.UseFont = True
        Me.colJulio.AppearanceHeader.Options.UseTextOptions = True
        Me.colJulio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colJulio.Caption = "Julio"
        Me.colJulio.DisplayFormat.FormatString = "###,###,###"
        Me.colJulio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colJulio.FieldName = "Julio"
        Me.colJulio.Name = "colJulio"
        Me.colJulio.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Julio", "{0:$###,###,##0}")})
        Me.colJulio.Visible = True
        Me.colJulio.VisibleIndex = 11
        '
        'colAgosto
        '
        Me.colAgosto.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAgosto.AppearanceHeader.Options.UseFont = True
        Me.colAgosto.AppearanceHeader.Options.UseTextOptions = True
        Me.colAgosto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAgosto.Caption = "Agosto"
        Me.colAgosto.DisplayFormat.FormatString = "###,###,###"
        Me.colAgosto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAgosto.FieldName = "Agosto"
        Me.colAgosto.Name = "colAgosto"
        Me.colAgosto.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Agosto", "{0:$###,###,##0}")})
        Me.colAgosto.Visible = True
        Me.colAgosto.VisibleIndex = 12
        '
        'colSeptiembre
        '
        Me.colSeptiembre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colSeptiembre.AppearanceHeader.Options.UseFont = True
        Me.colSeptiembre.AppearanceHeader.Options.UseTextOptions = True
        Me.colSeptiembre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSeptiembre.Caption = "Septiembre"
        Me.colSeptiembre.DisplayFormat.FormatString = "###,###,###"
        Me.colSeptiembre.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colSeptiembre.FieldName = "Septiembre"
        Me.colSeptiembre.Name = "colSeptiembre"
        Me.colSeptiembre.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Septiembre", "{0:$###,###,##0}")})
        Me.colSeptiembre.Visible = True
        Me.colSeptiembre.VisibleIndex = 13
        '
        'colOctubre
        '
        Me.colOctubre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colOctubre.AppearanceHeader.Options.UseFont = True
        Me.colOctubre.AppearanceHeader.Options.UseTextOptions = True
        Me.colOctubre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colOctubre.Caption = "Octubre"
        Me.colOctubre.DisplayFormat.FormatString = "###,###,###"
        Me.colOctubre.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colOctubre.FieldName = "Octubre"
        Me.colOctubre.Name = "colOctubre"
        Me.colOctubre.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Octubre", "{0:$###,###,##0}")})
        Me.colOctubre.Visible = True
        Me.colOctubre.VisibleIndex = 14
        '
        'colNoviembre
        '
        Me.colNoviembre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colNoviembre.AppearanceHeader.Options.UseFont = True
        Me.colNoviembre.AppearanceHeader.Options.UseTextOptions = True
        Me.colNoviembre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colNoviembre.Caption = "Noviembre"
        Me.colNoviembre.DisplayFormat.FormatString = "###,###,###"
        Me.colNoviembre.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colNoviembre.FieldName = "Noviembre"
        Me.colNoviembre.Name = "colNoviembre"
        Me.colNoviembre.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Noviembre", "{0:$###,###,##0}")})
        Me.colNoviembre.Visible = True
        Me.colNoviembre.VisibleIndex = 15
        '
        'colDiciembre
        '
        Me.colDiciembre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colDiciembre.AppearanceHeader.Options.UseFont = True
        Me.colDiciembre.AppearanceHeader.Options.UseTextOptions = True
        Me.colDiciembre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colDiciembre.Caption = "Diciembre"
        Me.colDiciembre.DisplayFormat.FormatString = "###,###,###"
        Me.colDiciembre.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colDiciembre.FieldName = "Diciembre"
        Me.colDiciembre.Name = "colDiciembre"
        Me.colDiciembre.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Diciembre", "{0:$###,###,##0}")})
        Me.colDiciembre.Visible = True
        Me.colDiciembre.VisibleIndex = 16
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
        Me.Pnl_Botones.Controls.Add(Me.Txt_Ejercicio)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(963, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(62, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "Año"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(202, 16)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(40, 33)
        Me.Btn_Aceptar.TabIndex = 13
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(806, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 11
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(857, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 7
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(908, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Txt_Ejercicio
        '
        Me.Txt_Ejercicio.EditValue = "2017"
        Me.Txt_Ejercicio.Location = New System.Drawing.Point(87, 19)
        Me.Txt_Ejercicio.Name = "Txt_Ejercicio"
        Me.Txt_Ejercicio.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ejercicio.Properties.Appearance.Options.UseFont = True
        Me.Txt_Ejercicio.Properties.Appearance.Options.UseTextOptions = True
        Me.Txt_Ejercicio.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.Txt_Ejercicio.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.Txt_Ejercicio.Properties.MaxLength = 4
        Me.Txt_Ejercicio.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Ejercicio.TabIndex = 16
        '
        'frmPpalVentaXmesDistr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalVentaXmesDistr"
        Me.Text = "Ventas Por Mes Distribuidores"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.Txt_Ejercicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PBox As PictureBox
    Friend WithEvents Pnl_Bar As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LBL_PORC As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Pbar1 As ProgressBar
    Friend WithEvents colDistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFecAlta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEnero As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFebrero As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMarzo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAbril As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMayo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJunio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJulio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAgosto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSeptiembre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOctubre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNoviembre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDiciembre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Txt_Ejercicio As DevExpress.XtraEditors.TextEdit
End Class
