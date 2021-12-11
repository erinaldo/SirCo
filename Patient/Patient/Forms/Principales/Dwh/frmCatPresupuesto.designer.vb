<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatPresupuesto
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
        Me.btn_Regresar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cbo_Mes = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbo_Año = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.gc_CatPresupuesto = New DevExpress.XtraGrid.GridControl()
        Me.dgv_CatPresupuesto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_IdPlaza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Plaza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_IdSucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Sucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_IdDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Division = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Venta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rp_Importe = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_Presupuesto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Alcance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.rp_Porcentaje = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_Tendencia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_AlcTen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbl_TextoFecha = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Texto = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cbo_Mes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Año.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_CatPresupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_CatPresupuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rp_Importe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rp_Porcentaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.lbl_Texto)
        Me.PanelControl1.Controls.Add(Me.lbl_TextoFecha)
        Me.PanelControl1.Controls.Add(Me.btn_Regresar)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.cbo_Mes)
        Me.PanelControl1.Controls.Add(Me.cbo_Año)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 254)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(708, 61)
        Me.PanelControl1.TabIndex = 1
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Regresar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.arrow_left
        Me.btn_Regresar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Regresar.Location = New System.Drawing.Point(578, 2)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(64, 57)
        Me.btn_Regresar.TabIndex = 2
        Me.btn_Regresar.ToolTip = "Regresar"
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(642, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(64, 57)
        Me.btn_Salir.TabIndex = 3
        Me.btn_Salir.ToolTip = "Salir"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 35)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 10
        Me.LabelControl2.Text = "Mes"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 9
        Me.LabelControl1.Text = "Año"
        '
        'cbo_Mes
        '
        Me.cbo_Mes.Location = New System.Drawing.Point(37, 32)
        Me.cbo_Mes.Name = "cbo_Mes"
        Me.cbo_Mes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Mes.Properties.Items.AddRange(New Object() {"01-Enero", "02-Febrero", "03-Marzo", "04-Abril", "05-Mayo", "06-Junio", "07-Julio", "08-Agosto", "09-Septiembre", "10-Octubre", "11-Noviembre", "12-Diciembre"})
        Me.cbo_Mes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbo_Mes.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Mes.TabIndex = 1
        '
        'cbo_Año
        '
        Me.cbo_Año.Location = New System.Drawing.Point(37, 6)
        Me.cbo_Año.Name = "cbo_Año"
        Me.cbo_Año.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Año.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbo_Año.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Año.TabIndex = 0
        '
        'gc_CatPresupuesto
        '
        Me.gc_CatPresupuesto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_CatPresupuesto.Location = New System.Drawing.Point(0, 0)
        Me.gc_CatPresupuesto.MainView = Me.dgv_CatPresupuesto
        Me.gc_CatPresupuesto.Name = "gc_CatPresupuesto"
        Me.gc_CatPresupuesto.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.rp_Porcentaje, Me.rp_Importe})
        Me.gc_CatPresupuesto.Size = New System.Drawing.Size(708, 254)
        Me.gc_CatPresupuesto.TabIndex = 0
        Me.gc_CatPresupuesto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_CatPresupuesto})
        '
        'dgv_CatPresupuesto
        '
        Me.dgv_CatPresupuesto.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_IdPlaza, Me.gc_Plaza, Me.gc_IdSucursal, Me.gc_Sucursal, Me.gc_IdDivision, Me.gc_Division, Me.gc_Venta, Me.gc_Presupuesto, Me.gc_Alcance, Me.gc_Tendencia, Me.gc_AlcTen})
        Me.dgv_CatPresupuesto.GridControl = Me.gc_CatPresupuesto
        Me.dgv_CatPresupuesto.Name = "dgv_CatPresupuesto"
        Me.dgv_CatPresupuesto.OptionsBehavior.Editable = False
        '
        'gc_IdPlaza
        '
        Me.gc_IdPlaza.Caption = "IdPlaza"
        Me.gc_IdPlaza.FieldName = "idplaza"
        Me.gc_IdPlaza.Name = "gc_IdPlaza"
        '
        'gc_Plaza
        '
        Me.gc_Plaza.Caption = "Plaza"
        Me.gc_Plaza.FieldName = "plaza"
        Me.gc_Plaza.Name = "gc_Plaza"
        Me.gc_Plaza.Visible = True
        Me.gc_Plaza.VisibleIndex = 0
        '
        'gc_IdSucursal
        '
        Me.gc_IdSucursal.Caption = "IdSucursal"
        Me.gc_IdSucursal.FieldName = "idsucursal"
        Me.gc_IdSucursal.Name = "gc_IdSucursal"
        '
        'gc_Sucursal
        '
        Me.gc_Sucursal.Caption = "Sucursal"
        Me.gc_Sucursal.FieldName = "sucursal"
        Me.gc_Sucursal.Name = "gc_Sucursal"
        Me.gc_Sucursal.Visible = True
        Me.gc_Sucursal.VisibleIndex = 1
        '
        'gc_IdDivision
        '
        Me.gc_IdDivision.Caption = "IdDivision"
        Me.gc_IdDivision.FieldName = "iddivision"
        Me.gc_IdDivision.Name = "gc_IdDivision"
        '
        'gc_Division
        '
        Me.gc_Division.Caption = "División"
        Me.gc_Division.FieldName = "division"
        Me.gc_Division.Name = "gc_Division"
        Me.gc_Division.Visible = True
        Me.gc_Division.VisibleIndex = 2
        '
        'gc_Venta
        '
        Me.gc_Venta.Caption = "Venta"
        Me.gc_Venta.ColumnEdit = Me.rp_Importe
        Me.gc_Venta.FieldName = "venta"
        Me.gc_Venta.Name = "gc_Venta"
        Me.gc_Venta.Visible = True
        Me.gc_Venta.VisibleIndex = 3
        '
        'rp_Importe
        '
        Me.rp_Importe.AutoHeight = False
        Me.rp_Importe.DisplayFormat.FormatString = "$###,###,##0.00"
        Me.rp_Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Importe.EditFormat.FormatString = "$###,###,##0.00"
        Me.rp_Importe.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Importe.Name = "rp_Importe"
        '
        'gc_Presupuesto
        '
        Me.gc_Presupuesto.Caption = "Presupuesto"
        Me.gc_Presupuesto.ColumnEdit = Me.rp_Importe
        Me.gc_Presupuesto.FieldName = "presupuesto"
        Me.gc_Presupuesto.Name = "gc_Presupuesto"
        Me.gc_Presupuesto.Visible = True
        Me.gc_Presupuesto.VisibleIndex = 4
        '
        'gc_Alcance
        '
        Me.gc_Alcance.Caption = "Alcance"
        Me.gc_Alcance.ColumnEdit = Me.rp_Porcentaje
        Me.gc_Alcance.FieldName = "alcance"
        Me.gc_Alcance.Name = "gc_Alcance"
        Me.gc_Alcance.Visible = True
        Me.gc_Alcance.VisibleIndex = 5
        '
        'rp_Porcentaje
        '
        Me.rp_Porcentaje.AutoHeight = False
        Me.rp_Porcentaje.DisplayFormat.FormatString = "##%"
        Me.rp_Porcentaje.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Porcentaje.EditFormat.FormatString = "##%"
        Me.rp_Porcentaje.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.rp_Porcentaje.Mask.EditMask = "p"
        Me.rp_Porcentaje.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.rp_Porcentaje.Name = "rp_Porcentaje"
        '
        'gc_Tendencia
        '
        Me.gc_Tendencia.Caption = "Tendencia"
        Me.gc_Tendencia.ColumnEdit = Me.rp_Importe
        Me.gc_Tendencia.FieldName = "tendencia"
        Me.gc_Tendencia.Name = "gc_Tendencia"
        Me.gc_Tendencia.Visible = True
        Me.gc_Tendencia.VisibleIndex = 6
        '
        'gc_AlcTen
        '
        Me.gc_AlcTen.Caption = "Alcance Tendencia"
        Me.gc_AlcTen.ColumnEdit = Me.rp_Porcentaje
        Me.gc_AlcTen.FieldName = "alcancetendencia"
        Me.gc_AlcTen.Name = "gc_AlcTen"
        Me.gc_AlcTen.Visible = True
        Me.gc_AlcTen.VisibleIndex = 7
        '
        'lbl_TextoFecha
        '
        Me.lbl_TextoFecha.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TextoFecha.Appearance.Options.UseFont = True
        Me.lbl_TextoFecha.Location = New System.Drawing.Point(144, 9)
        Me.lbl_TextoFecha.Name = "lbl_TextoFecha"
        Me.lbl_TextoFecha.Size = New System.Drawing.Size(0, 14)
        Me.lbl_TextoFecha.TabIndex = 11
        '
        'lbl_Texto
        '
        Me.lbl_Texto.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Texto.Appearance.Options.UseFont = True
        Me.lbl_Texto.Location = New System.Drawing.Point(143, 34)
        Me.lbl_Texto.Name = "lbl_Texto"
        Me.lbl_Texto.Size = New System.Drawing.Size(0, 14)
        Me.lbl_Texto.TabIndex = 12
        '
        'frmCatPresupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 315)
        Me.Controls.Add(Me.gc_CatPresupuesto)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.Name = "frmCatPresupuesto"
        Me.Text = "Reporte Presupuesto"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.cbo_Mes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Año.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_CatPresupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_CatPresupuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rp_Importe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rp_Porcentaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gc_CatPresupuesto As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_CatPresupuesto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_IdPlaza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Plaza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_IdSucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Sucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_IdDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Division As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Venta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Presupuesto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Alcance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Tendencia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_AlcTen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rp_Importe As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents rp_Porcentaje As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbo_Mes As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbo_Año As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btn_Regresar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_Texto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_TextoFecha As DevExpress.XtraEditors.LabelControl
End Class
