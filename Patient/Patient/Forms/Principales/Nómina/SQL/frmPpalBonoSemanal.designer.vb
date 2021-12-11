<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalBonoSemanal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalBonoSemanal))
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalBonoSemanalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalBonoSemanal = New SIRCO.usp_PpalBonoSemanal()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.coldescrip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldescrip1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbono2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtacalzado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonocalzado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtaparesunicos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonoparesunicos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtaaccesorios = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonoaccesorios = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtaelectronica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonoelectronica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtalentes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonolentes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvta1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbono1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvta2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.Txt_Porc = New System.Windows.Forms.TextBox()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Usp_PpalBonoSemanalTableAdapter = New SIRCO.usp_PpalBonoSemanalTableAdapters.usp_PpalBonoSemanalTableAdapter()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalBonoSemanalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalBonoSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalBonoSemanalBindingSource
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(831, 330)
        Me.DGrid1.TabIndex = 7
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalBonoSemanalBindingSource
        '
        Me.UspPpalBonoSemanalBindingSource.DataMember = "usp_PpalBonoSemanal"
        Me.UspPpalBonoSemanalBindingSource.DataSource = Me.Usp_PpalBonoSemanal
        '
        'Usp_PpalBonoSemanal
        '
        Me.Usp_PpalBonoSemanal.DataSetName = "usp_PpalBonoSemanal"
        Me.Usp_PpalBonoSemanal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.coldescrip, Me.coldescrip1, Me.colnombre, Me.colbono2, Me.coltotal, Me.colvtacalzado, Me.colbonocalzado, Me.colvtaparesunicos, Me.colbonoparesunicos, Me.colvtaaccesorios, Me.colbonoaccesorios, Me.colvtaelectronica, Me.colbonoelectronica, Me.colvtalentes, Me.colbonolentes, Me.colvta1, Me.colbono1, Me.colvta2})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'coldescrip
        '
        Me.coldescrip.Caption = "Sucursal"
        Me.coldescrip.FieldName = "descrip"
        Me.coldescrip.Name = "coldescrip"
        Me.coldescrip.OptionsColumn.ReadOnly = True
        Me.coldescrip.Visible = True
        Me.coldescrip.VisibleIndex = 0
        '
        'coldescrip1
        '
        Me.coldescrip1.Caption = "Puesto"
        Me.coldescrip1.FieldName = "descrip1"
        Me.coldescrip1.Name = "coldescrip1"
        Me.coldescrip1.OptionsColumn.ReadOnly = True
        Me.coldescrip1.Visible = True
        Me.coldescrip1.VisibleIndex = 1
        '
        'colnombre
        '
        Me.colnombre.Caption = "Nombre"
        Me.colnombre.FieldName = "nombre"
        Me.colnombre.Name = "colnombre"
        Me.colnombre.OptionsColumn.ReadOnly = True
        Me.colnombre.Visible = True
        Me.colnombre.VisibleIndex = 2
        '
        'colbono2
        '
        Me.colbono2.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.colbono2.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colbono2.AppearanceCell.Options.UseBackColor = True
        Me.colbono2.Caption = "Garantía"
        Me.colbono2.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colbono2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbono2.FieldName = "bono2"
        Me.colbono2.Name = "colbono2"
        Me.colbono2.OptionsColumn.ReadOnly = True
        Me.colbono2.Visible = True
        Me.colbono2.VisibleIndex = 3
        '
        'coltotal
        '
        Me.coltotal.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.coltotal.AppearanceCell.BackColor2 = System.Drawing.Color.Yellow
        Me.coltotal.AppearanceCell.Options.UseBackColor = True
        Me.coltotal.Caption = "Gran Bono"
        Me.coltotal.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.coltotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.coltotal.FieldName = "total"
        Me.coltotal.Name = "coltotal"
        Me.coltotal.OptionsColumn.ReadOnly = True
        Me.coltotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:$#,###,##0.00}")})
        Me.coltotal.Visible = True
        Me.coltotal.VisibleIndex = 4
        '
        'colvtacalzado
        '
        Me.colvtacalzado.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.colvtacalzado.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.colvtacalzado.AppearanceCell.Options.UseBackColor = True
        Me.colvtacalzado.Caption = "Vta Calzado"
        Me.colvtacalzado.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colvtacalzado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtacalzado.FieldName = "vtacalzado"
        Me.colvtacalzado.Name = "colvtacalzado"
        Me.colvtacalzado.OptionsColumn.ReadOnly = True
        Me.colvtacalzado.Visible = True
        Me.colvtacalzado.VisibleIndex = 5
        '
        'colbonocalzado
        '
        Me.colbonocalzado.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colbonocalzado.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colbonocalzado.AppearanceCell.Options.UseBackColor = True
        Me.colbonocalzado.Caption = "Bono Calzado"
        Me.colbonocalzado.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colbonocalzado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonocalzado.FieldName = "bonocalzado"
        Me.colbonocalzado.Name = "colbonocalzado"
        Me.colbonocalzado.OptionsColumn.ReadOnly = True
        Me.colbonocalzado.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonocalzado", "{0:$#,###,##0.00}")})
        Me.colbonocalzado.Visible = True
        Me.colbonocalzado.VisibleIndex = 6
        '
        'colvtaparesunicos
        '
        Me.colvtaparesunicos.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.colvtaparesunicos.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.colvtaparesunicos.AppearanceCell.Options.UseBackColor = True
        Me.colvtaparesunicos.Caption = "Vta Prs Unicos"
        Me.colvtaparesunicos.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colvtaparesunicos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtaparesunicos.FieldName = "vtaparesunicos"
        Me.colvtaparesunicos.Name = "colvtaparesunicos"
        Me.colvtaparesunicos.OptionsColumn.ReadOnly = True
        Me.colvtaparesunicos.Visible = True
        Me.colvtaparesunicos.VisibleIndex = 7
        '
        'colbonoparesunicos
        '
        Me.colbonoparesunicos.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colbonoparesunicos.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colbonoparesunicos.AppearanceCell.Options.UseBackColor = True
        Me.colbonoparesunicos.Caption = "Bono Prs Unicos"
        Me.colbonoparesunicos.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colbonoparesunicos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonoparesunicos.FieldName = "bonoparesunicos"
        Me.colbonoparesunicos.Name = "colbonoparesunicos"
        Me.colbonoparesunicos.OptionsColumn.ReadOnly = True
        Me.colbonoparesunicos.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonoparesunicos", "{0:$#,###,##0.00}")})
        Me.colbonoparesunicos.Visible = True
        Me.colbonoparesunicos.VisibleIndex = 8
        '
        'colvtaaccesorios
        '
        Me.colvtaaccesorios.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.colvtaaccesorios.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.colvtaaccesorios.AppearanceCell.Options.UseBackColor = True
        Me.colvtaaccesorios.Caption = "Vta Accesorios"
        Me.colvtaaccesorios.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colvtaaccesorios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtaaccesorios.FieldName = "vtaaccesorios"
        Me.colvtaaccesorios.Name = "colvtaaccesorios"
        Me.colvtaaccesorios.OptionsColumn.ReadOnly = True
        Me.colvtaaccesorios.Visible = True
        Me.colvtaaccesorios.VisibleIndex = 9
        '
        'colbonoaccesorios
        '
        Me.colbonoaccesorios.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colbonoaccesorios.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colbonoaccesorios.AppearanceCell.Options.UseBackColor = True
        Me.colbonoaccesorios.Caption = "Bono Accesorios"
        Me.colbonoaccesorios.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colbonoaccesorios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonoaccesorios.FieldName = "bonoaccesorios"
        Me.colbonoaccesorios.Name = "colbonoaccesorios"
        Me.colbonoaccesorios.OptionsColumn.ReadOnly = True
        Me.colbonoaccesorios.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonoaccesorios", "{0:$#,###,##0.00}")})
        Me.colbonoaccesorios.Visible = True
        Me.colbonoaccesorios.VisibleIndex = 10
        '
        'colvtaelectronica
        '
        Me.colvtaelectronica.AppearanceCell.BackColor = System.Drawing.Color.White
        Me.colvtaelectronica.AppearanceCell.BackColor2 = System.Drawing.Color.White
        Me.colvtaelectronica.AppearanceCell.Options.UseBackColor = True
        Me.colvtaelectronica.Caption = "Vta Electrónica"
        Me.colvtaelectronica.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colvtaelectronica.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtaelectronica.FieldName = "vtaelectronica"
        Me.colvtaelectronica.Name = "colvtaelectronica"
        Me.colvtaelectronica.OptionsColumn.ReadOnly = True
        Me.colvtaelectronica.Visible = True
        Me.colvtaelectronica.VisibleIndex = 11
        '
        'colbonoelectronica
        '
        Me.colbonoelectronica.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colbonoelectronica.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colbonoelectronica.AppearanceCell.Options.UseBackColor = True
        Me.colbonoelectronica.Caption = "Bono Electrónica"
        Me.colbonoelectronica.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colbonoelectronica.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonoelectronica.FieldName = "bonoelectronica"
        Me.colbonoelectronica.Name = "colbonoelectronica"
        Me.colbonoelectronica.OptionsColumn.ReadOnly = True
        Me.colbonoelectronica.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonoelectronica", "{0:$#,###,##0.00}")})
        Me.colbonoelectronica.Visible = True
        Me.colbonoelectronica.VisibleIndex = 12
        '
        'colvtalentes
        '
        Me.colvtalentes.Caption = "Vta Lentes"
        Me.colvtalentes.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colvtalentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtalentes.FieldName = "vtalentes"
        Me.colvtalentes.Name = "colvtalentes"
        Me.colvtalentes.OptionsColumn.ReadOnly = True
        Me.colvtalentes.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vtalentes", "{0:#,###,##0}")})
        '
        'colbonolentes
        '
        Me.colbonolentes.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colbonolentes.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.colbonolentes.AppearanceCell.Options.UseBackColor = True
        Me.colbonolentes.Caption = "Bono Lentes"
        Me.colbonolentes.DisplayFormat.FormatString = "$#,###,##0.00"
        Me.colbonolentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonolentes.FieldName = "bonolentes"
        Me.colbonolentes.Name = "colbonolentes"
        Me.colbonolentes.OptionsColumn.ReadOnly = True
        Me.colbonolentes.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonolentes", "{0:$#,###,##0.00}")})
        '
        'colvta1
        '
        Me.colvta1.Caption = "Vta1"
        Me.colvta1.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvta1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvta1.FieldName = "vta1"
        Me.colvta1.Name = "colvta1"
        Me.colvta1.OptionsColumn.ReadOnly = True
        Me.colvta1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vta1", "{0:#,###,##0.00}")})
        '
        'colbono1
        '
        Me.colbono1.Caption = "Bono1"
        Me.colbono1.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbono1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbono1.FieldName = "bono1"
        Me.colbono1.Name = "colbono1"
        Me.colbono1.OptionsColumn.ReadOnly = True
        Me.colbono1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bono1", "{0:#,###,##0.00}")})
        '
        'colvta2
        '
        Me.colvta2.Caption = "Vta2"
        Me.colvta2.FieldName = "vta2"
        Me.colvta2.Name = "colvta2"
        Me.colvta2.OptionsColumn.ReadOnly = True
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 330)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(831, 56)
        Me.Pnl_Botones.TabIndex = 6
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.ForeColor = System.Drawing.Color.DarkRed
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(299, 31)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 15)
        Me.Lbl_Leyenda.TabIndex = 89
        '
        'Txt_Porc
        '
        Me.Txt_Porc.Enabled = False
        Me.Txt_Porc.Location = New System.Drawing.Point(158, 27)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Porc.TabIndex = 88
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(-2, -2)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(415, 23)
        Me.PBar.TabIndex = 87
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(572, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 13
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(623, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 12
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(674, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 11
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        Me.Btn_Imprimir.Visible = False
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(725, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(776, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Usp_PpalBonoSemanalTableAdapter
        '
        Me.Usp_PpalBonoSemanalTableAdapter.ClearBeforeFill = True
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(486, 94)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 101)
        Me.PictureBox1.TabIndex = 90
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'frmPpalBonoSemanal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 386)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalBonoSemanal"
        Me.Text = "Reporte de Bono Semanal"
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalBonoSemanalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalBonoSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Imprimir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents UspPpalBonoSemanalBindingSource As BindingSource
    Friend WithEvents Usp_PpalBonoSemanal As usp_PpalBonoSemanal
    Friend WithEvents Usp_PpalBonoSemanalTableAdapter As usp_PpalBonoSemanalTableAdapters.usp_PpalBonoSemanalTableAdapter
    Friend WithEvents coldescrip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldescrip1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtacalzado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonocalzado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtaparesunicos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonoparesunicos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtaaccesorios As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonoaccesorios As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtaelectronica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonoelectronica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtalentes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonolentes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvta1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbono1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvta2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbono2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents Btn_Filtro As Button
    Friend WithEvents Txt_Porc As TextBox
    Friend WithEvents PBar As ProgressBar
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
