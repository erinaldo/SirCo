<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalComisionesCarteraVencida
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.LCMsj = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DEFechaFin = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFechaIni = New DevExpress.XtraEditors.DateEdit()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.Pnl_Detallado = New DevExpress.XtraEditors.PanelControl()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colGestor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRecuperacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPagoEsp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pnl_Principal = New DevExpress.XtraEditors.PanelControl()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFolio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRecuperacionDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComisionDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHora = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCajero = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCajeroCancela = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdDistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNDistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Detallado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Detallado.SuspendLayout()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Principal.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.LCMsj)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.DEFechaFin)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl1)
        Me.Pnl_Botones.Controls.Add(Me.DEFechaIni)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 532)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 50)
        Me.Pnl_Botones.TabIndex = 5
        '
        'LCMsj
        '
        Me.LCMsj.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCMsj.Location = New System.Drawing.Point(400, 14)
        Me.LCMsj.Name = "LCMsj"
        Me.LCMsj.Size = New System.Drawing.Size(29, 19)
        Me.LCMsj.TabIndex = 33
        Me.LCMsj.Text = "msj"
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(696, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 46)
        Me.Btn_Refrescar.TabIndex = 32
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(747, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 46)
        Me.Btn_Excel.TabIndex = 30
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
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 46)
        Me.Btn_Salir.TabIndex = 29
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DEFechaFin
        '
        Me.DEFechaFin.EditValue = Nothing
        Me.DEFechaFin.Location = New System.Drawing.Point(226, 11)
        Me.DEFechaFin.Name = "DEFechaFin"
        Me.DEFechaFin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaFin.TabIndex = 23
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Fecha"
        '
        'DEFechaIni
        '
        Me.DEFechaIni.EditValue = Nothing
        Me.DEFechaIni.Location = New System.Drawing.Point(72, 11)
        Me.DEFechaIni.Name = "DEFechaIni"
        Me.DEFechaIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaIni.TabIndex = 21
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(31, 14)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 20
        '
        'Pnl_Detallado
        '
        Me.Pnl_Detallado.Controls.Add(Me.DGrid2)
        Me.Pnl_Detallado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Detallado.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Detallado.Name = "Pnl_Detallado"
        Me.Pnl_Detallado.Size = New System.Drawing.Size(853, 237)
        Me.Pnl_Detallado.TabIndex = 9
        '
        'DGrid2
        '
        Me.DGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.DGrid2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.DGrid2.Location = New System.Drawing.Point(2, 2)
        Me.DGrid2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid2.MainView = Me.GridView2
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(849, 233)
        Me.DGrid2.TabIndex = 7
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colGestor, Me.colRecuperacion, Me.ColPagoEsp, Me.colComision})
        Me.GridView2.GridControl = Me.DGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'colGestor
        '
        Me.colGestor.AppearanceHeader.Options.UseTextOptions = True
        Me.colGestor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colGestor.Caption = "Gestor"
        Me.colGestor.FieldName = "NOMBRE"
        Me.colGestor.Name = "colGestor"
        Me.colGestor.OptionsColumn.ReadOnly = True
        Me.colGestor.Visible = True
        Me.colGestor.VisibleIndex = 0
        '
        'colRecuperacion
        '
        Me.colRecuperacion.AppearanceHeader.Options.UseTextOptions = True
        Me.colRecuperacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colRecuperacion.Caption = "Recuperación"
        Me.colRecuperacion.DisplayFormat.FormatString = "#,###,###"
        Me.colRecuperacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colRecuperacion.FieldName = "RECUPERACION"
        Me.colRecuperacion.Name = "colRecuperacion"
        Me.colRecuperacion.OptionsColumn.ReadOnly = True
        Me.colRecuperacion.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECUPERACION", "{0:$###,###,##0}", "0")})
        Me.colRecuperacion.Visible = True
        Me.colRecuperacion.VisibleIndex = 1
        '
        'colComision
        '
        Me.colComision.AppearanceHeader.Options.UseTextOptions = True
        Me.colComision.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colComision.Caption = "Comisión"
        Me.colComision.DisplayFormat.FormatString = "#,###,###"
        Me.colComision.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colComision.FieldName = "COMISION"
        Me.colComision.Name = "colComision"
        Me.colComision.OptionsColumn.ReadOnly = True
        Me.colComision.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COMISION", "{0:$###,###,##0}", "0")})
        Me.colComision.Tag = ""
        Me.colComision.Visible = True
        Me.colComision.VisibleIndex = 3
        '
        'ColPagoEsp
        '
        Me.ColPagoEsp.AppearanceCell.Options.UseTextOptions = True
        Me.ColPagoEsp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPagoEsp.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPagoEsp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColPagoEsp.Caption = "Pago Especie"
        Me.ColPagoEsp.FieldName = "PAGO ESPECIE"
        Me.ColPagoEsp.Name = "ColPagoEsp"
        Me.ColPagoEsp.OptionsColumn.ReadOnly = True
        Me.ColPagoEsp.Visible = True
        Me.ColPagoEsp.VisibleIndex = 2
        '
        'Pnl_Principal
        '
        Me.Pnl_Principal.Controls.Add(Me.DGrid1)
        Me.Pnl_Principal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Principal.Location = New System.Drawing.Point(0, 237)
        Me.Pnl_Principal.Name = "Pnl_Principal"
        Me.Pnl_Principal.Size = New System.Drawing.Size(853, 295)
        Me.Pnl_Principal.TabIndex = 8
        '
        'DGrid1
        '
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(2, 2)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(849, 291)
        Me.DGrid1.TabIndex = 6
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNombre, Me.colIdDistrib, Me.ColNDistrib, Me.colSucursal, Me.colFolio, Me.colRecuperacionDet, Me.colComisionDet, Me.colFecha, Me.colHora, Me.colStatus, Me.colCajero, Me.colCajeroCancela})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'colNombre
        '
        Me.colNombre.Caption = "Gestor"
        Me.colNombre.FieldName = "GESTOR"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.OptionsColumn.ReadOnly = True
        Me.colNombre.Visible = True
        Me.colNombre.VisibleIndex = 0
        '
        'colSucursal
        '
        Me.colSucursal.AppearanceCell.Options.UseTextOptions = True
        Me.colSucursal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSucursal.Caption = "Sucursal"
        Me.colSucursal.FieldName = "SUCURSAL"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.OptionsColumn.ReadOnly = True
        Me.colSucursal.Visible = True
        Me.colSucursal.VisibleIndex = 1
        '
        'colFolio
        '
        Me.colFolio.Caption = "Folio"
        Me.colFolio.FieldName = "FOLIO"
        Me.colFolio.Name = "colFolio"
        Me.colFolio.OptionsColumn.ReadOnly = True
        Me.colFolio.Visible = True
        Me.colFolio.VisibleIndex = 2
        '
        'colRecuperacionDet
        '
        Me.colRecuperacionDet.Caption = "Recuperación"
        Me.colRecuperacionDet.DisplayFormat.FormatString = "#,###,###"
        Me.colRecuperacionDet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colRecuperacionDet.FieldName = "RECUPERACION"
        Me.colRecuperacionDet.Name = "colRecuperacionDet"
        Me.colRecuperacionDet.OptionsColumn.ReadOnly = True
        Me.colRecuperacionDet.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RECUPERACION", "{0:$###,###,##0}")})
        Me.colRecuperacionDet.Visible = True
        Me.colRecuperacionDet.VisibleIndex = 3
        '
        'colComisionDet
        '
        Me.colComisionDet.Caption = "Comisión"
        Me.colComisionDet.DisplayFormat.FormatString = "#,###,###"
        Me.colComisionDet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colComisionDet.FieldName = "COMISION"
        Me.colComisionDet.Name = "colComisionDet"
        Me.colComisionDet.OptionsColumn.ReadOnly = True
        Me.colComisionDet.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "COMISION", "{0:$###,###,##0}")})
        Me.colComisionDet.Visible = True
        Me.colComisionDet.VisibleIndex = 4
        '
        'colFecha
        '
        Me.colFecha.AppearanceCell.Options.UseTextOptions = True
        Me.colFecha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colFecha.Caption = "Fecha"
        Me.colFecha.FieldName = "FECHA"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.OptionsColumn.ReadOnly = True
        Me.colFecha.Visible = True
        Me.colFecha.VisibleIndex = 5
        '
        'colHora
        '
        Me.colHora.AppearanceCell.Options.UseTextOptions = True
        Me.colHora.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colHora.Caption = "Hora"
        Me.colHora.FieldName = "HORA"
        Me.colHora.Name = "colHora"
        Me.colHora.OptionsColumn.ReadOnly = True
        Me.colHora.Visible = True
        Me.colHora.VisibleIndex = 6
        '
        'colStatus
        '
        Me.colStatus.AppearanceCell.Options.UseTextOptions = True
        Me.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colStatus.Caption = "Estatus"
        Me.colStatus.FieldName = "STATUS"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.OptionsColumn.ReadOnly = True
        Me.colStatus.Visible = True
        Me.colStatus.VisibleIndex = 7
        '
        'colCajero
        '
        Me.colCajero.Caption = "Cajero"
        Me.colCajero.FieldName = "CAJERO"
        Me.colCajero.Name = "colCajero"
        Me.colCajero.OptionsColumn.ReadOnly = True
        Me.colCajero.Visible = True
        Me.colCajero.VisibleIndex = 8
        '
        'colCajeroCancela
        '
        Me.colCajeroCancela.Caption = "Cajero Cancela"
        Me.colCajeroCancela.FieldName = "CAJERO CANCELA"
        Me.colCajeroCancela.Name = "colCajeroCancela"
        Me.colCajeroCancela.OptionsColumn.ReadOnly = True
        '
        'colIdDistrib
        '
        Me.colIdDistrib.AppearanceCell.Options.UseTextOptions = True
        Me.colIdDistrib.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIdDistrib.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colIdDistrib.AppearanceHeader.Options.UseFont = True
        Me.colIdDistrib.AppearanceHeader.Options.UseTextOptions = True
        Me.colIdDistrib.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIdDistrib.Caption = "Distrib"
        Me.colIdDistrib.FieldName = "DISTRIB"
        Me.colIdDistrib.Name = "colIdDistrib"
        Me.colIdDistrib.OptionsColumn.ReadOnly = True
        Me.colIdDistrib.Visible = True
        Me.colIdDistrib.VisibleIndex = 1
        '
        'ColNDistrib
        '
        Me.ColNDistrib.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColNDistrib.AppearanceHeader.Options.UseFont = True
        Me.ColNDistrib.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNDistrib.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNDistrib.Caption = "Nombre Distrib"
        Me.ColNDistrib.FieldName = "NDISTRIB"
        Me.ColNDistrib.Name = "ColNDistrib"
        Me.ColNDistrib.OptionsColumn.ReadOnly = True
        Me.ColNDistrib.Visible = True
        Me.ColNDistrib.VisibleIndex = 1
        '
        'frmPpalComisionesCarteraVencida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.Pnl_Detallado)
        Me.Controls.Add(Me.Pnl_Principal)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmPpalComisionesCarteraVencida"
        Me.Text = "Comisiones de Cartera Vencida"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Detallado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Detallado.ResumeLayout(False)
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Principal.ResumeLayout(False)
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents DEFechaFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFechaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents Pnl_Detallado As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Pnl_Principal As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colGestor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents colRecuperacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPagoEsp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFolio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRecuperacionDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComisionDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LCMsj As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colFecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHora As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCajero As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCajeroCancela As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdDistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNDistrib As DevExpress.XtraGrid.Columns.GridColumn
End Class
