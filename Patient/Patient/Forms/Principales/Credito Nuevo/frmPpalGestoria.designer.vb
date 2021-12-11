<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalGestoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalGestoria))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Chk_Direccion = New DevExpress.XtraEditors.CheckEdit()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Asignar = New System.Windows.Forms.Button()
        Me.Btn_FTP = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalGestoriaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalGestoria = New SIRCO.usp_PpalGestoria()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Distrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.corte1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.corte2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.corte3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.corten = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.vencido = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colultpago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colultfechapago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Direccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Telefono1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.aval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colClasificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UspPpalVencidoDiasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SirCoCreditoDataSet2 = New SIRCO.SirCoCreditoDataSet2()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Usp_PpalGestoriaTableAdapter = New SIRCO.usp_PpalGestoriaTableAdapters.usp_PpalGestoriaTableAdapter()
        Me.DGrid3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Chk_Direccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalGestoriaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalGestoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalVencidoDiasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoCreditoDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Chk_Direccion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Asignar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_FTP)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1364, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Chk_Direccion
        '
        Me.Chk_Direccion.EditValue = True
        Me.Chk_Direccion.Location = New System.Drawing.Point(28, 14)
        Me.Chk_Direccion.Name = "Chk_Direccion"
        Me.Chk_Direccion.Properties.Caption = "Ver Direccion"
        Me.Chk_Direccion.Size = New System.Drawing.Size(86, 19)
        Me.Chk_Direccion.TabIndex = 16
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(1054, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 15
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Asignar
        '
        Me.Btn_Asignar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Asignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Asignar.Image = Global.SIRCO.My.Resources.Resources.person
        Me.Btn_Asignar.Location = New System.Drawing.Point(1105, 0)
        Me.Btn_Asignar.Name = "Btn_Asignar"
        Me.Btn_Asignar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Asignar.TabIndex = 14
        Me.Btn_Asignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Asignar.UseVisualStyleBackColor = True
        '
        'Btn_FTP
        '
        Me.Btn_FTP.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_FTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_FTP.Image = Global.SIRCO.My.Resources.Resources.icons8_Subir_a_FTP_48_icon
        Me.Btn_FTP.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_FTP.Location = New System.Drawing.Point(1156, 0)
        Me.Btn_FTP.Name = "Btn_FTP"
        Me.Btn_FTP.Size = New System.Drawing.Size(51, 52)
        Me.Btn_FTP.TabIndex = 13
        Me.Btn_FTP.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_FTP.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(1207, 0)
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
        Me.Btn_Excel.Location = New System.Drawing.Point(1258, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(1309, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalGestoriaBindingSource
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DGrid1.Location = New System.Drawing.Point(0, 52)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(1364, 474)
        Me.DGrid1.TabIndex = 5
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalGestoriaBindingSource
        '
        Me.UspPpalGestoriaBindingSource.DataMember = "usp_PpalGestoria"
        Me.UspPpalGestoriaBindingSource.DataSource = Me.Usp_PpalGestoria
        '
        'Usp_PpalGestoria
        '
        Me.Usp_PpalGestoria.DataSetName = "usp_PpalGestoria"
        Me.Usp_PpalGestoria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Distrib, Me.Nombre, Me.status, Me.corte1, Me.corte2, Me.corte3, Me.colCampo5, Me.corten, Me.vencido, Me.colultpago, Me.colultfechapago, Me.Direccion, Me.colCampo2, Me.colCampo3, Me.Telefono1, Me.aval, Me.colCampo4, Me.colClasificacion, Me.GridColumn2, Me.GridColumn3})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Distrib
        '
        Me.Distrib.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Distrib.AppearanceHeader.Options.UseFont = True
        Me.Distrib.AppearanceHeader.Options.UseTextOptions = True
        Me.Distrib.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Distrib.FieldName = "Distrib"
        Me.Distrib.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Distrib.Name = "Distrib"
        Me.Distrib.OptionsColumn.ReadOnly = True
        Me.Distrib.Visible = True
        Me.Distrib.VisibleIndex = 1
        '
        'Nombre
        '
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "Nombre"
        Me.Nombre.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.ReadOnly = True
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 2
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
        Me.status.VisibleIndex = 4
        '
        'corte1
        '
        Me.corte1.Caption = "Corte 1"
        Me.corte1.DisplayFormat.FormatString = "#,###,###"
        Me.corte1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.corte1.FieldName = "corte1"
        Me.corte1.Name = "corte1"
        Me.corte1.OptionsColumn.ReadOnly = True
        Me.corte1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte1", "{0:$###,###,##0}", CType(0, Long))})
        Me.corte1.Visible = True
        Me.corte1.VisibleIndex = 5
        '
        'corte2
        '
        Me.corte2.Caption = "Corte2"
        Me.corte2.DisplayFormat.FormatString = "#,###,###"
        Me.corte2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.corte2.FieldName = "corte2"
        Me.corte2.Name = "corte2"
        Me.corte2.OptionsColumn.ReadOnly = True
        Me.corte2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte2", "{0:$###,###,##0}", CType(0, Long))})
        Me.corte2.Visible = True
        Me.corte2.VisibleIndex = 6
        '
        'corte3
        '
        Me.corte3.Caption = "Corte 3"
        Me.corte3.DisplayFormat.FormatString = "#,###,###"
        Me.corte3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.corte3.FieldName = "corte3"
        Me.corte3.Name = "corte3"
        Me.corte3.OptionsColumn.ReadOnly = True
        Me.corte3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte3", "{0:$###,###,##0}", CType(0, Long))})
        Me.corte3.Visible = True
        Me.corte3.VisibleIndex = 7
        '
        'colCampo5
        '
        Me.colCampo5.Caption = "Corte 4"
        Me.colCampo5.DisplayFormat.FormatString = "#,###,###"
        Me.colCampo5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colCampo5.FieldName = "Campo5"
        Me.colCampo5.Name = "colCampo5"
        Me.colCampo5.OptionsColumn.ReadOnly = True
        Me.colCampo5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Campo5", "{0:$###,###,##0}", "0")})
        Me.colCampo5.Visible = True
        Me.colCampo5.VisibleIndex = 8
        '
        'corten
        '
        Me.corten.Caption = "Cort ""N"""
        Me.corten.DisplayFormat.FormatString = "#,###,###"
        Me.corten.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.corten.FieldName = "corten"
        Me.corten.Name = "corten"
        Me.corten.OptionsColumn.ReadOnly = True
        Me.corten.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corten", "{0:$###,###,##0}", CType(0, Long))})
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
        Me.colultpago.VisibleIndex = 9
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
        Me.colultfechapago.VisibleIndex = 10
        '
        'Direccion
        '
        Me.Direccion.Caption = "Dirección"
        Me.Direccion.FieldName = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.OptionsColumn.ReadOnly = True
        Me.Direccion.Visible = True
        Me.Direccion.VisibleIndex = 11
        '
        'colCampo2
        '
        Me.colCampo2.AppearanceCell.Options.UseTextOptions = True
        Me.colCampo2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCampo2.AppearanceHeader.Options.UseFont = True
        Me.colCampo2.AppearanceHeader.Options.UseTextOptions = True
        Me.colCampo2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo2.Caption = "Ciudad"
        Me.colCampo2.FieldName = "Campo2"
        Me.colCampo2.Name = "colCampo2"
        Me.colCampo2.OptionsColumn.ReadOnly = True
        Me.colCampo2.Visible = True
        Me.colCampo2.VisibleIndex = 12
        '
        'colCampo3
        '
        Me.colCampo3.Caption = "Colonia"
        Me.colCampo3.FieldName = "Campo3"
        Me.colCampo3.Name = "colCampo3"
        Me.colCampo3.OptionsColumn.ReadOnly = True
        Me.colCampo3.Visible = True
        Me.colCampo3.VisibleIndex = 13
        '
        'Telefono1
        '
        Me.Telefono1.Caption = "Teléfonos"
        Me.Telefono1.FieldName = "Telefono1"
        Me.Telefono1.Name = "Telefono1"
        Me.Telefono1.OptionsColumn.ReadOnly = True
        Me.Telefono1.Visible = True
        Me.Telefono1.VisibleIndex = 14
        '
        'aval
        '
        Me.aval.Caption = "Aval"
        Me.aval.FieldName = "aval"
        Me.aval.Name = "aval"
        Me.aval.OptionsColumn.ReadOnly = True
        Me.aval.Visible = True
        Me.aval.VisibleIndex = 15
        '
        'colCampo4
        '
        Me.colCampo4.Caption = "Gestor Asignado"
        Me.colCampo4.FieldName = "Campo4"
        Me.colCampo4.Name = "colCampo4"
        Me.colCampo4.OptionsColumn.ReadOnly = True
        Me.colCampo4.Visible = True
        Me.colCampo4.VisibleIndex = 16
        '
        'colClasificacion
        '
        Me.colClasificacion.Caption = "Clasificación"
        Me.colClasificacion.FieldName = "clasificacion"
        Me.colClasificacion.Name = "colClasificacion"
        Me.colClasificacion.OptionsColumn.ReadOnly = True
        Me.colClasificacion.Visible = True
        Me.colClasificacion.VisibleIndex = 3
        '
        'GridColumn2
        '
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 17
        '
        'GridColumn3
        '
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 18
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
        'Usp_PpalGestoriaTableAdapter
        '
        Me.Usp_PpalGestoriaTableAdapter.ClearBeforeFill = True
        '
        'DGrid3
        '
        Me.DGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid3.Location = New System.Drawing.Point(0, 0)
        Me.DGrid3.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid3.MainView = Me.GridView3
        Me.DGrid3.Name = "DGrid3"
        Me.DGrid3.Size = New System.Drawing.Size(1364, 52)
        Me.DGrid3.TabIndex = 71
        Me.DGrid3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.GridControl = Me.DGrid3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'frmPpalGestoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 582)
        Me.Controls.Add(Me.DGrid3)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalGestoria"
        Me.Text = "Reporte de Gestoria"
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.Chk_Direccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalGestoriaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalGestoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalVencidoDiasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoCreditoDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Direccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Telefono1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents aval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents vencido As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents corte1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents corte2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents corte3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents corten As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colultpago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colultfechapago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Chk_Direccion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Usp_PpalGestoria As usp_PpalGestoria
    Friend WithEvents UspPpalGestoriaBindingSource As BindingSource
    Friend WithEvents Usp_PpalGestoriaTableAdapter As usp_PpalGestoriaTableAdapters.usp_PpalGestoriaTableAdapter
    Friend WithEvents Btn_FTP As Button
    Friend WithEvents Btn_Asignar As Button
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents DGrid3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colClasificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
