<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalVencidosDias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalVencidosDias))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.Chk_Direccion = New DevExpress.XtraEditors.CheckEdit()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalVencidoDiasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SirCoCreditoDataSet2 = New SIRCO.SirCoCreditoDataSet2()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Distrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.frecuen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Direccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Telefono1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.aval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.compras = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.porpagar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.vencido = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldias_14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldias_29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldias_44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldias_59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldias_60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colultpago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colultfechapago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Usp_PpalVencidoDiasTableAdapter = New SIRCO.SirCoCreditoDataSet2TableAdapters.usp_PpalVencidoDiasTableAdapter()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chk_Direccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalVencidoDiasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoCreditoDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.LabelControl1)
        Me.Pnl_Botones.Controls.Add(Me.DateEdit1)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Direccion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(146, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "Fecha Vencido"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(235, 4)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(148, 20)
        Me.DateEdit1.TabIndex = 14
        '
        'Chk_Direccion
        '
        Me.Chk_Direccion.Location = New System.Drawing.Point(29, 4)
        Me.Chk_Direccion.Name = "Chk_Direccion"
        Me.Chk_Direccion.Properties.Caption = "Ver Dirección"
        Me.Chk_Direccion.Size = New System.Drawing.Size(86, 19)
        Me.Chk_Direccion.TabIndex = 12
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(696, 0)
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
        Me.Btn_Excel.Location = New System.Drawing.Point(747, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(798, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalVencidoDiasBindingSource
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(853, 526)
        Me.DGrid1.TabIndex = 5
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalVencidoDiasBindingSource
        '
        Me.UspPpalVencidoDiasBindingSource.DataMember = "usp_PpalVencidoDias"
        Me.UspPpalVencidoDiasBindingSource.DataSource = Me.SirCoCreditoDataSet2
        '
        'SirCoCreditoDataSet2
        '
        Me.SirCoCreditoDataSet2.DataSetName = "SirCoCreditoDataSet2"
        Me.SirCoCreditoDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Distrib, Me.Nombre, Me.status, Me.frecuen, Me.Direccion, Me.Telefono1, Me.aval, Me.compras, Me.porpagar, Me.vencido, Me.coldias_14, Me.coldias_29, Me.coldias_44, Me.coldias_59, Me.coldias_60, Me.colultpago, Me.colultfechapago, Me.colCampo1, Me.colCampo2, Me.colCampo3, Me.colCampo4, Me.colCampo5})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Distrib
        '
        Me.Distrib.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Distrib.AppearanceHeader.Options.UseFont = True
        Me.Distrib.AppearanceHeader.Options.UseTextOptions = True
        Me.Distrib.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Distrib.FieldName = "Distrib"
        Me.Distrib.Name = "Distrib"
        Me.Distrib.OptionsColumn.ReadOnly = True
        Me.Distrib.Visible = True
        Me.Distrib.VisibleIndex = 0
        '
        'Nombre
        '
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.ReadOnly = True
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 1
        '
        'status
        '
        Me.status.AppearanceCell.Options.UseTextOptions = True
        Me.status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.status.Caption = "Est"
        Me.status.FieldName = "status"
        Me.status.Name = "status"
        Me.status.OptionsColumn.ReadOnly = True
        Me.status.Visible = True
        Me.status.VisibleIndex = 2
        '
        'frecuen
        '
        Me.frecuen.AppearanceCell.Options.UseTextOptions = True
        Me.frecuen.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.frecuen.Caption = "Frec"
        Me.frecuen.FieldName = "frecuen"
        Me.frecuen.Name = "frecuen"
        Me.frecuen.OptionsColumn.ReadOnly = True
        Me.frecuen.Visible = True
        Me.frecuen.VisibleIndex = 3
        '
        'Direccion
        '
        Me.Direccion.Caption = "Dirección"
        Me.Direccion.FieldName = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.OptionsColumn.ReadOnly = True
        Me.Direccion.Visible = True
        Me.Direccion.VisibleIndex = 4
        '
        'Telefono1
        '
        Me.Telefono1.Caption = "Teléfonos"
        Me.Telefono1.FieldName = "Telefono1"
        Me.Telefono1.Name = "Telefono1"
        Me.Telefono1.OptionsColumn.ReadOnly = True
        Me.Telefono1.Visible = True
        Me.Telefono1.VisibleIndex = 5
        '
        'aval
        '
        Me.aval.Caption = "Aval"
        Me.aval.FieldName = "aval"
        Me.aval.Name = "aval"
        Me.aval.OptionsColumn.ReadOnly = True
        '
        'compras
        '
        Me.compras.Caption = "Compras"
        Me.compras.DisplayFormat.FormatString = "#,###,###"
        Me.compras.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.compras.FieldName = "compras"
        Me.compras.Name = "compras"
        Me.compras.OptionsColumn.ReadOnly = True
        Me.compras.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "compras", "{0:$###,###,##0}", New Decimal(New Integer() {0, 0, 0, 0}))})
        Me.compras.Visible = True
        Me.compras.VisibleIndex = 6
        '
        'porpagar
        '
        Me.porpagar.Caption = "Por Pagar"
        Me.porpagar.DisplayFormat.FormatString = "#,###,###"
        Me.porpagar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.porpagar.FieldName = "porpagar"
        Me.porpagar.Name = "porpagar"
        Me.porpagar.OptionsColumn.ReadOnly = True
        Me.porpagar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "porpagar", "{0:$###,###,##0}", CType(0, Long))})
        Me.porpagar.Visible = True
        Me.porpagar.VisibleIndex = 7
        '
        'vencido
        '
        Me.vencido.Caption = "Vencido"
        Me.vencido.DisplayFormat.FormatString = "#,###,###"
        Me.vencido.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.vencido.FieldName = "vencido"
        Me.vencido.Name = "vencido"
        Me.vencido.OptionsColumn.ReadOnly = True
        Me.vencido.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vencido", "{0:$###,###,##0}", CType(0, Long))})
        Me.vencido.Visible = True
        Me.vencido.VisibleIndex = 9
        '
        'coldias_14
        '
        Me.coldias_14.Caption = " 0 a 14"
        Me.coldias_14.DisplayFormat.FormatString = "#,###,###"
        Me.coldias_14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.coldias_14.FieldName = "dias_14"
        Me.coldias_14.Name = "coldias_14"
        Me.coldias_14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dias_14", "{0:$###,###,##0}", CType(0, Long))})
        Me.coldias_14.Visible = True
        Me.coldias_14.VisibleIndex = 10
        '
        'coldias_29
        '
        Me.coldias_29.Caption = "15 a 29"
        Me.coldias_29.DisplayFormat.FormatString = "#,###,###"
        Me.coldias_29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.coldias_29.FieldName = "dias_29"
        Me.coldias_29.Name = "coldias_29"
        Me.coldias_29.OptionsColumn.ReadOnly = True
        Me.coldias_29.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dias_29", "{0:$###,###,##0}", CType(0, Long))})
        Me.coldias_29.Visible = True
        Me.coldias_29.VisibleIndex = 11
        '
        'coldias_44
        '
        Me.coldias_44.Caption = "30 a 44"
        Me.coldias_44.DisplayFormat.FormatString = "#,###,###"
        Me.coldias_44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.coldias_44.FieldName = "dias_44"
        Me.coldias_44.Name = "coldias_44"
        Me.coldias_44.OptionsColumn.ReadOnly = True
        Me.coldias_44.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dias_44", "{0:$###,###,##0}", CType(0, Long))})
        Me.coldias_44.Visible = True
        Me.coldias_44.VisibleIndex = 12
        '
        'coldias_59
        '
        Me.coldias_59.Caption = "45 a 59"
        Me.coldias_59.DisplayFormat.FormatString = "#,###,###"
        Me.coldias_59.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.coldias_59.FieldName = "dias_59"
        Me.coldias_59.Name = "coldias_59"
        Me.coldias_59.OptionsColumn.ReadOnly = True
        Me.coldias_59.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dias_59", "{0:$###,###,##0}", CType(0, Long))})
        Me.coldias_59.Visible = True
        Me.coldias_59.VisibleIndex = 13
        '
        'coldias_60
        '
        Me.coldias_60.Caption = ">= 60"
        Me.coldias_60.DisplayFormat.FormatString = "#,###,###"
        Me.coldias_60.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.coldias_60.FieldName = "dias_60"
        Me.coldias_60.Name = "coldias_60"
        Me.coldias_60.OptionsColumn.ReadOnly = True
        Me.coldias_60.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dias_60", "{0:$###,###,##0}", CType(0, Long))})
        Me.coldias_60.Visible = True
        Me.coldias_60.VisibleIndex = 14
        '
        'colultpago
        '
        Me.colultpago.Caption = "Ult Pago"
        Me.colultpago.DisplayFormat.FormatString = "#,###,###"
        Me.colultpago.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colultpago.FieldName = "ultpago"
        Me.colultpago.Name = "colultpago"
        Me.colultpago.OptionsColumn.ReadOnly = True
        Me.colultpago.Visible = True
        Me.colultpago.VisibleIndex = 15
        '
        'colultfechapago
        '
        Me.colultfechapago.AppearanceCell.Options.UseTextOptions = True
        Me.colultfechapago.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colultfechapago.Caption = "Fecha Ult Pago"
        Me.colultfechapago.FieldName = "ultfechapago"
        Me.colultfechapago.Name = "colultfechapago"
        Me.colultfechapago.OptionsColumn.ReadOnly = True
        Me.colultfechapago.Visible = True
        Me.colultfechapago.VisibleIndex = 16
        '
        'colCampo1
        '
        Me.colCampo1.AppearanceCell.Options.UseTextOptions = True
        Me.colCampo1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCampo1.AppearanceHeader.Options.UseFont = True
        Me.colCampo1.AppearanceHeader.Options.UseTextOptions = True
        Me.colCampo1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo1.Caption = "Fecha Vencido"
        Me.colCampo1.FieldName = "Campo1"
        Me.colCampo1.Name = "colCampo1"
        Me.colCampo1.OptionsColumn.ReadOnly = True
        Me.colCampo1.Visible = True
        Me.colCampo1.VisibleIndex = 17
        '
        'colCampo2
        '
        Me.colCampo2.AppearanceCell.Options.UseTextOptions = True
        Me.colCampo2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCampo2.AppearanceHeader.Options.UseFont = True
        Me.colCampo2.AppearanceHeader.Options.UseTextOptions = True
        Me.colCampo2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo2.Caption = "Por Vencer"
        Me.colCampo2.DisplayFormat.FormatString = "#,###,###"
        Me.colCampo2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colCampo2.FieldName = "Campo2"
        Me.colCampo2.Name = "colCampo2"
        Me.colCampo2.OptionsColumn.ReadOnly = True
        Me.colCampo2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Campo2", "{0:$###,###,##0}")})
        Me.colCampo2.Visible = True
        Me.colCampo2.VisibleIndex = 8
        '
        'colCampo3
        '
        Me.colCampo3.FieldName = "Campo3"
        Me.colCampo3.Name = "colCampo3"
        Me.colCampo3.OptionsColumn.ReadOnly = True
        '
        'colCampo4
        '
        Me.colCampo4.FieldName = "Campo4"
        Me.colCampo4.Name = "colCampo4"
        Me.colCampo4.OptionsColumn.ReadOnly = True
        '
        'colCampo5
        '
        Me.colCampo5.FieldName = "Campo5"
        Me.colCampo5.Name = "colCampo5"
        Me.colCampo5.OptionsColumn.ReadOnly = True
        '
        'Usp_PpalVencidoDiasTableAdapter
        '
        Me.Usp_PpalVencidoDiasTableAdapter.ClearBeforeFill = True
        '
        'PdfViewer1
        '
        Me.PdfViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.Size = New System.Drawing.Size(150, 150)
        Me.PdfViewer1.TabIndex = 0
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'SaveFileDialog1
        '
        '
        'frmPpalVencidosDias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalVencidosDias"
        Me.Text = "Listado de Saldos Vencidos"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chk_Direccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalVencidoDiasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoCreditoDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Imprimir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UspPpalVencidoDiasBindingSource As BindingSource
    Friend WithEvents SirCoCreditoDataSet2 As SirCoCreditoDataSet2
    Friend WithEvents Distrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents frecuen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Direccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Telefono1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents aval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents compras As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents porpagar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents vencido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldias_14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldias_29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldias_44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldias_59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldias_60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colultpago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colultfechapago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Usp_PpalVencidoDiasTableAdapter As SirCoCreditoDataSet2TableAdapters.usp_PpalVencidoDiasTableAdapter
    Friend WithEvents Chk_Direccion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
