<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalPresupuesto
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cbo_Año = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Modificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.tc_Presupuesto = New DevExpress.XtraTab.XtraTabControl()
        Me.tp_Presupuesto = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_Presupuesto = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Presupuesto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_PresupuestoCol1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Año1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Mes1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_UsuarioCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_FumCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_UsuarioModifica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_FumModifica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.tp_Detallado = New DevExpress.XtraTab.XtraTabPage()
        Me.gc_PresupuestoMensual = New DevExpress.XtraGrid.GridControl()
        Me.dgv_PresupuestoMensual = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_Plaza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_IdSucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Sucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Año = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Mes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_IdDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Division = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_PresupuestoCol = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rp_Importe = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Regresar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_GuardarPresupuesto = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cbo_Año.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tc_Presupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_Presupuesto.SuspendLayout()
        Me.tp_Presupuesto.SuspendLayout()
        CType(Me.gc_Presupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Presupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp_Detallado.SuspendLayout()
        CType(Me.gc_PresupuestoMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_PresupuestoMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rp_Importe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.cbo_Año)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Consultar)
        Me.PanelControl1.Controls.Add(Me.btn_Modificar)
        Me.PanelControl1.Controls.Add(Me.btn_Nuevo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 319)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(643, 54)
        Me.PanelControl1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(178, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Año"
        '
        'cbo_Año
        '
        Me.cbo_Año.Location = New System.Drawing.Point(203, 6)
        Me.cbo_Año.Name = "cbo_Año"
        Me.cbo_Año.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Año.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbo_Año.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Año.TabIndex = 3
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(592, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(49, 50)
        Me.btn_Salir.TabIndex = 4
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Consultar
        '
        Me.btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Consultar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Consultar.ImageOptions.ImageUri.Uri = "Preview"
        Me.btn_Consultar.Location = New System.Drawing.Point(114, 2)
        Me.btn_Consultar.Name = "btn_Consultar"
        Me.btn_Consultar.Size = New System.Drawing.Size(56, 50)
        Me.btn_Consultar.TabIndex = 2
        Me.btn_Consultar.ToolTip = "Consultar"
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Modificar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Modificar.ImageOptions.ImageUri.Uri = "Edit"
        Me.btn_Modificar.Location = New System.Drawing.Point(58, 2)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(56, 50)
        Me.btn_Modificar.TabIndex = 1
        Me.btn_Modificar.ToolTip = "Editar"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Nuevo.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.btn_Nuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Nuevo.ImageOptions.ImageUri.Uri = "AddItem"
        Me.btn_Nuevo.Location = New System.Drawing.Point(2, 2)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(56, 50)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.ToolTip = "Nuevo"
        '
        'tc_Presupuesto
        '
        Me.tc_Presupuesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tc_Presupuesto.Location = New System.Drawing.Point(0, 0)
        Me.tc_Presupuesto.Name = "tc_Presupuesto"
        Me.tc_Presupuesto.SelectedTabPage = Me.tp_Presupuesto
        Me.tc_Presupuesto.Size = New System.Drawing.Size(643, 319)
        Me.tc_Presupuesto.TabIndex = 1
        Me.tc_Presupuesto.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tp_Presupuesto, Me.tp_Detallado})
        '
        'tp_Presupuesto
        '
        Me.tp_Presupuesto.Controls.Add(Me.gc_Presupuesto)
        Me.tp_Presupuesto.Name = "tp_Presupuesto"
        Me.tp_Presupuesto.Size = New System.Drawing.Size(637, 291)
        Me.tp_Presupuesto.Text = "Presupuesto"
        '
        'gc_Presupuesto
        '
        Me.gc_Presupuesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Presupuesto.Location = New System.Drawing.Point(0, 0)
        Me.gc_Presupuesto.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gc_Presupuesto.LookAndFeel.UseWindowsXPTheme = True
        Me.gc_Presupuesto.MainView = Me.dgv_Presupuesto
        Me.gc_Presupuesto.Name = "gc_Presupuesto"
        Me.gc_Presupuesto.Size = New System.Drawing.Size(637, 291)
        Me.gc_Presupuesto.TabIndex = 0
        Me.gc_Presupuesto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Presupuesto})
        '
        'dgv_Presupuesto
        '
        Me.dgv_Presupuesto.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_PresupuestoCol1, Me.gc_Año1, Me.gc_Mes1, Me.gc_UsuarioCaptura, Me.gc_FumCaptura, Me.gc_UsuarioModifica, Me.gc_FumModifica})
        Me.dgv_Presupuesto.GridControl = Me.gc_Presupuesto
        Me.dgv_Presupuesto.Name = "dgv_Presupuesto"
        Me.dgv_Presupuesto.OptionsBehavior.Editable = False
        Me.dgv_Presupuesto.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        '
        'gc_PresupuestoCol1
        '
        Me.gc_PresupuestoCol1.Caption = "Presupuesto"
        Me.gc_PresupuestoCol1.FieldName = "presupuesto"
        Me.gc_PresupuestoCol1.Name = "gc_PresupuestoCol1"
        Me.gc_PresupuestoCol1.Visible = True
        Me.gc_PresupuestoCol1.VisibleIndex = 0
        '
        'gc_Año1
        '
        Me.gc_Año1.Caption = "Año"
        Me.gc_Año1.FieldName = "año"
        Me.gc_Año1.Name = "gc_Año1"
        Me.gc_Año1.Visible = True
        Me.gc_Año1.VisibleIndex = 1
        '
        'gc_Mes1
        '
        Me.gc_Mes1.Caption = "Mes"
        Me.gc_Mes1.FieldName = "mes"
        Me.gc_Mes1.Name = "gc_Mes1"
        Me.gc_Mes1.Visible = True
        Me.gc_Mes1.VisibleIndex = 2
        '
        'gc_UsuarioCaptura
        '
        Me.gc_UsuarioCaptura.Caption = "Captura"
        Me.gc_UsuarioCaptura.FieldName = "idusuariocaptura"
        Me.gc_UsuarioCaptura.Name = "gc_UsuarioCaptura"
        Me.gc_UsuarioCaptura.Visible = True
        Me.gc_UsuarioCaptura.VisibleIndex = 3
        '
        'gc_FumCaptura
        '
        Me.gc_FumCaptura.Caption = "FUM Captura"
        Me.gc_FumCaptura.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        Me.gc_FumCaptura.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gc_FumCaptura.FieldName = "fumcaptura"
        Me.gc_FumCaptura.Name = "gc_FumCaptura"
        Me.gc_FumCaptura.Visible = True
        Me.gc_FumCaptura.VisibleIndex = 4
        '
        'gc_UsuarioModifica
        '
        Me.gc_UsuarioModifica.Caption = "Modifica"
        Me.gc_UsuarioModifica.FieldName = "idusuariomodifica"
        Me.gc_UsuarioModifica.Name = "gc_UsuarioModifica"
        Me.gc_UsuarioModifica.Visible = True
        Me.gc_UsuarioModifica.VisibleIndex = 5
        '
        'gc_FumModifica
        '
        Me.gc_FumModifica.Caption = "FUM Modifica"
        Me.gc_FumModifica.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        Me.gc_FumModifica.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gc_FumModifica.FieldName = "fummodifica"
        Me.gc_FumModifica.Name = "gc_FumModifica"
        Me.gc_FumModifica.Visible = True
        Me.gc_FumModifica.VisibleIndex = 6
        '
        'tp_Detallado
        '
        Me.tp_Detallado.Controls.Add(Me.gc_PresupuestoMensual)
        Me.tp_Detallado.Controls.Add(Me.PanelControl2)
        Me.tp_Detallado.Name = "tp_Detallado"
        Me.tp_Detallado.Size = New System.Drawing.Size(637, 291)
        Me.tp_Detallado.Text = "Detallado"
        '
        'gc_PresupuestoMensual
        '
        Me.gc_PresupuestoMensual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_PresupuestoMensual.Location = New System.Drawing.Point(0, 0)
        Me.gc_PresupuestoMensual.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.gc_PresupuestoMensual.LookAndFeel.UseWindowsXPTheme = True
        Me.gc_PresupuestoMensual.MainView = Me.dgv_PresupuestoMensual
        Me.gc_PresupuestoMensual.Name = "gc_PresupuestoMensual"
        Me.gc_PresupuestoMensual.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rp_Importe})
        Me.gc_PresupuestoMensual.Size = New System.Drawing.Size(637, 236)
        Me.gc_PresupuestoMensual.TabIndex = 0
        Me.gc_PresupuestoMensual.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_PresupuestoMensual})
        '
        'dgv_PresupuestoMensual
        '
        Me.dgv_PresupuestoMensual.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_Plaza, Me.gc_IdSucursal, Me.gc_Sucursal, Me.gc_Año, Me.gc_Mes, Me.gc_IdDivision, Me.gc_Division, Me.gc_PresupuestoCol})
        Me.dgv_PresupuestoMensual.GridControl = Me.gc_PresupuestoMensual
        Me.dgv_PresupuestoMensual.Name = "dgv_PresupuestoMensual"
        Me.dgv_PresupuestoMensual.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        '
        'gc_Plaza
        '
        Me.gc_Plaza.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Plaza.AppearanceCell.Options.UseFont = True
        Me.gc_Plaza.Caption = "Plaza"
        Me.gc_Plaza.FieldName = "plaza"
        Me.gc_Plaza.Name = "gc_Plaza"
        Me.gc_Plaza.OptionsColumn.AllowEdit = False
        Me.gc_Plaza.OptionsColumn.AllowFocus = False
        Me.gc_Plaza.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gc_Plaza.Visible = True
        Me.gc_Plaza.VisibleIndex = 0
        '
        'gc_IdSucursal
        '
        Me.gc_IdSucursal.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_IdSucursal.AppearanceCell.Options.UseFont = True
        Me.gc_IdSucursal.Caption = "IdSucursal"
        Me.gc_IdSucursal.FieldName = "idsucursal"
        Me.gc_IdSucursal.Name = "gc_IdSucursal"
        Me.gc_IdSucursal.OptionsColumn.AllowEdit = False
        Me.gc_IdSucursal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'gc_Sucursal
        '
        Me.gc_Sucursal.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gc_Sucursal.AppearanceCell.Options.UseFont = True
        Me.gc_Sucursal.Caption = "Sucursal"
        Me.gc_Sucursal.FieldName = "sucursal"
        Me.gc_Sucursal.Name = "gc_Sucursal"
        Me.gc_Sucursal.OptionsColumn.AllowEdit = False
        Me.gc_Sucursal.OptionsColumn.AllowFocus = False
        Me.gc_Sucursal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gc_Sucursal.Visible = True
        Me.gc_Sucursal.VisibleIndex = 1
        '
        'gc_Año
        '
        Me.gc_Año.Caption = "Año"
        Me.gc_Año.FieldName = "año"
        Me.gc_Año.Name = "gc_Año"
        Me.gc_Año.OptionsColumn.AllowEdit = False
        Me.gc_Año.OptionsColumn.AllowFocus = False
        Me.gc_Año.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gc_Año.Visible = True
        Me.gc_Año.VisibleIndex = 2
        '
        'gc_Mes
        '
        Me.gc_Mes.Caption = "Mes"
        Me.gc_Mes.FieldName = "mes"
        Me.gc_Mes.Name = "gc_Mes"
        Me.gc_Mes.OptionsColumn.AllowEdit = False
        Me.gc_Mes.OptionsColumn.AllowFocus = False
        Me.gc_Mes.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gc_Mes.Visible = True
        Me.gc_Mes.VisibleIndex = 3
        '
        'gc_IdDivision
        '
        Me.gc_IdDivision.Caption = "IdDivision"
        Me.gc_IdDivision.FieldName = "iddivision"
        Me.gc_IdDivision.Name = "gc_IdDivision"
        Me.gc_IdDivision.OptionsColumn.AllowEdit = False
        Me.gc_IdDivision.OptionsColumn.AllowFocus = False
        '
        'gc_Division
        '
        Me.gc_Division.Caption = "División"
        Me.gc_Division.FieldName = "division"
        Me.gc_Division.Name = "gc_Division"
        Me.gc_Division.OptionsColumn.AllowEdit = False
        Me.gc_Division.OptionsColumn.AllowFocus = False
        Me.gc_Division.Visible = True
        Me.gc_Division.VisibleIndex = 4
        '
        'gc_PresupuestoCol
        '
        Me.gc_PresupuestoCol.Caption = "Presupuesto"
        Me.gc_PresupuestoCol.ColumnEdit = Me.rp_Importe
        Me.gc_PresupuestoCol.FieldName = "presupuesto"
        Me.gc_PresupuestoCol.Name = "gc_PresupuestoCol"
        Me.gc_PresupuestoCol.Visible = True
        Me.gc_PresupuestoCol.VisibleIndex = 5
        '
        'rp_Importe
        '
        Me.rp_Importe.AutoHeight = False
        Me.rp_Importe.DisplayFormat.FormatString = "$###,###,##0.00"
        Me.rp_Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Importe.EditFormat.FormatString = "$###,###,##0.00"
        Me.rp_Importe.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Importe.Mask.EditMask = "c"
        Me.rp_Importe.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.rp_Importe.Name = "rp_Importe"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btn_Regresar)
        Me.PanelControl2.Controls.Add(Me.btn_GuardarPresupuesto)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 236)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(637, 55)
        Me.PanelControl2.TabIndex = 1
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Regresar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Regresar.ImageOptions.ImageUri.Uri = "Reset"
        Me.btn_Regresar.Location = New System.Drawing.Point(525, 2)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(55, 51)
        Me.btn_Regresar.TabIndex = 0
        Me.btn_Regresar.ToolTip = "Regresar"
        '
        'btn_GuardarPresupuesto
        '
        Me.btn_GuardarPresupuesto.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_GuardarPresupuesto.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_GuardarPresupuesto.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_GuardarPresupuesto.Location = New System.Drawing.Point(580, 2)
        Me.btn_GuardarPresupuesto.Name = "btn_GuardarPresupuesto"
        Me.btn_GuardarPresupuesto.Size = New System.Drawing.Size(55, 51)
        Me.btn_GuardarPresupuesto.TabIndex = 1
        Me.btn_GuardarPresupuesto.ToolTip = "Guardar"
        '
        'frmPpalPresupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 373)
        Me.Controls.Add(Me.tc_Presupuesto)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.Name = "frmPpalPresupuesto"
        Me.Text = "Presupuesto"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.cbo_Año.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tc_Presupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_Presupuesto.ResumeLayout(False)
        Me.tp_Presupuesto.ResumeLayout(False)
        CType(Me.gc_Presupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Presupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp_Detallado.ResumeLayout(False)
        CType(Me.gc_PresupuestoMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_PresupuestoMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rp_Importe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents tc_Presupuesto As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tp_Presupuesto As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_Presupuesto As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Presupuesto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tp_Detallado As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gc_PresupuestoMensual As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_PresupuestoMensual As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_GuardarPresupuesto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Modificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbo_Año As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents gc_Plaza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_IdSucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Sucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Año As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Mes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_IdDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Division As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_PresupuestoCol As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rp_Importe As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents gc_PresupuestoCol1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Año1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Mes1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_UsuarioCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_FumCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_UsuarioModifica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_FumModifica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btn_Regresar As DevExpress.XtraEditors.SimpleButton
End Class
