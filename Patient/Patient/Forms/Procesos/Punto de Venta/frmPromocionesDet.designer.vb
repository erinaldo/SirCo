<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocionesDet
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
        Me.components = New System.ComponentModel.Container()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_GuardaPromocionesDet = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txt_TipoUni = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_TipoUni = New DevExpress.XtraEditors.LabelControl()
        Me.txt_NumUnidad = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_NumUnidad = New DevExpress.XtraEditors.LabelControl()
        Me.txt_TipoPromo = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_TipoPromo = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Fum = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_FUM = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Usuario = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Usuario = New DevExpress.XtraEditors.LabelControl()
        Me.txt_NombrePromocion = New DevExpress.XtraEditors.TextEdit()
        Me.txt_IdPromocion = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Promocion = New DevExpress.XtraEditors.LabelControl()
        Me.UnboundSource1 = New DevExpress.Data.UnboundSource(Me.components)
        Me.gc_PromocionesDet = New DevExpress.XtraGrid.GridControl()
        Me.dgv_PromocionesDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_FP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_FormaPago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_ImpFijo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ri_txtImpFijo = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_PorcDirecto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ri_txtPorcDirecto = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_PorcDE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ri_txtPorcDE = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.gc_Bono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ri_txtBono = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txt_TipoUni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NumUnidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TipoPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Fum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Usuario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NombrePromocion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdPromocion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnboundSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_PromocionesDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_PromocionesDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ri_txtImpFijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ri_txtPorcDirecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ri_txtPorcDE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ri_txtBono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_GuardaPromocionesDet)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 403)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(878, 57)
        Me.PanelControl1.TabIndex = 2
        '
        'btn_GuardaPromocionesDet
        '
        Me.btn_GuardaPromocionesDet.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_GuardaPromocionesDet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_GuardaPromocionesDet.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_GuardaPromocionesDet.Location = New System.Drawing.Point(2, 2)
        Me.btn_GuardaPromocionesDet.Name = "btn_GuardaPromocionesDet"
        Me.btn_GuardaPromocionesDet.Size = New System.Drawing.Size(52, 53)
        Me.btn_GuardaPromocionesDet.TabIndex = 0
        Me.btn_GuardaPromocionesDet.ToolTip = "Guardar"
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(826, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(50, 53)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txt_TipoUni)
        Me.PanelControl2.Controls.Add(Me.lbl_TipoUni)
        Me.PanelControl2.Controls.Add(Me.txt_NumUnidad)
        Me.PanelControl2.Controls.Add(Me.lbl_NumUnidad)
        Me.PanelControl2.Controls.Add(Me.txt_TipoPromo)
        Me.PanelControl2.Controls.Add(Me.lbl_TipoPromo)
        Me.PanelControl2.Controls.Add(Me.txt_Fum)
        Me.PanelControl2.Controls.Add(Me.lbl_FUM)
        Me.PanelControl2.Controls.Add(Me.txt_Usuario)
        Me.PanelControl2.Controls.Add(Me.lbl_Usuario)
        Me.PanelControl2.Controls.Add(Me.txt_NombrePromocion)
        Me.PanelControl2.Controls.Add(Me.txt_IdPromocion)
        Me.PanelControl2.Controls.Add(Me.lbl_Promocion)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(878, 58)
        Me.PanelControl2.TabIndex = 0
        '
        'txt_TipoUni
        '
        Me.txt_TipoUni.Location = New System.Drawing.Point(211, 31)
        Me.txt_TipoUni.Name = "txt_TipoUni"
        Me.txt_TipoUni.Properties.ReadOnly = True
        Me.txt_TipoUni.Size = New System.Drawing.Size(92, 20)
        Me.txt_TipoUni.TabIndex = 3
        '
        'lbl_TipoUni
        '
        Me.lbl_TipoUni.Location = New System.Drawing.Point(185, 34)
        Me.lbl_TipoUni.Name = "lbl_TipoUni"
        Me.lbl_TipoUni.Size = New System.Drawing.Size(20, 13)
        Me.lbl_TipoUni.TabIndex = 12
        Me.lbl_TipoUni.Text = "Tipo"
        '
        'txt_NumUnidad
        '
        Me.txt_NumUnidad.Location = New System.Drawing.Point(110, 31)
        Me.txt_NumUnidad.Name = "txt_NumUnidad"
        Me.txt_NumUnidad.Properties.ReadOnly = True
        Me.txt_NumUnidad.Size = New System.Drawing.Size(42, 20)
        Me.txt_NumUnidad.TabIndex = 2
        '
        'lbl_NumUnidad
        '
        Me.lbl_NumUnidad.Location = New System.Drawing.Point(47, 34)
        Me.lbl_NumUnidad.Name = "lbl_NumUnidad"
        Me.lbl_NumUnidad.Size = New System.Drawing.Size(57, 13)
        Me.lbl_NumUnidad.TabIndex = 10
        Me.lbl_NumUnidad.Text = "Num Unidad"
        '
        'txt_TipoPromo
        '
        Me.txt_TipoPromo.Location = New System.Drawing.Point(368, 5)
        Me.txt_TipoPromo.Name = "txt_TipoPromo"
        Me.txt_TipoPromo.Properties.ReadOnly = True
        Me.txt_TipoPromo.Size = New System.Drawing.Size(88, 20)
        Me.txt_TipoPromo.TabIndex = 4
        '
        'lbl_TipoPromo
        '
        Me.lbl_TipoPromo.Location = New System.Drawing.Point(309, 8)
        Me.lbl_TipoPromo.Name = "lbl_TipoPromo"
        Me.lbl_TipoPromo.Size = New System.Drawing.Size(53, 13)
        Me.lbl_TipoPromo.TabIndex = 8
        Me.lbl_TipoPromo.Text = "Tipo Promo"
        '
        'txt_Fum
        '
        Me.txt_Fum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Fum.Location = New System.Drawing.Point(772, 5)
        Me.txt_Fum.Name = "txt_Fum"
        Me.txt_Fum.Properties.ReadOnly = True
        Me.txt_Fum.Size = New System.Drawing.Size(94, 20)
        Me.txt_Fum.TabIndex = 6
        '
        'lbl_FUM
        '
        Me.lbl_FUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_FUM.Location = New System.Drawing.Point(745, 8)
        Me.lbl_FUM.Name = "lbl_FUM"
        Me.lbl_FUM.Size = New System.Drawing.Size(21, 13)
        Me.lbl_FUM.TabIndex = 6
        Me.lbl_FUM.Text = "FUM"
        '
        'txt_Usuario
        '
        Me.txt_Usuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Usuario.Location = New System.Drawing.Point(643, 5)
        Me.txt_Usuario.Name = "txt_Usuario"
        Me.txt_Usuario.Properties.ReadOnly = True
        Me.txt_Usuario.Size = New System.Drawing.Size(96, 20)
        Me.txt_Usuario.TabIndex = 5
        '
        'lbl_Usuario
        '
        Me.lbl_Usuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Usuario.Location = New System.Drawing.Point(601, 8)
        Me.lbl_Usuario.Name = "lbl_Usuario"
        Me.lbl_Usuario.Size = New System.Drawing.Size(36, 13)
        Me.lbl_Usuario.TabIndex = 4
        Me.lbl_Usuario.Text = "Usuario"
        '
        'txt_NombrePromocion
        '
        Me.txt_NombrePromocion.Location = New System.Drawing.Point(110, 5)
        Me.txt_NombrePromocion.Name = "txt_NombrePromocion"
        Me.txt_NombrePromocion.Properties.ReadOnly = True
        Me.txt_NombrePromocion.Size = New System.Drawing.Size(193, 20)
        Me.txt_NombrePromocion.TabIndex = 1
        '
        'txt_IdPromocion
        '
        Me.txt_IdPromocion.Location = New System.Drawing.Point(60, 5)
        Me.txt_IdPromocion.Name = "txt_IdPromocion"
        Me.txt_IdPromocion.Properties.ReadOnly = True
        Me.txt_IdPromocion.Size = New System.Drawing.Size(44, 20)
        Me.txt_IdPromocion.TabIndex = 0
        '
        'lbl_Promocion
        '
        Me.lbl_Promocion.Location = New System.Drawing.Point(5, 8)
        Me.lbl_Promocion.Name = "lbl_Promocion"
        Me.lbl_Promocion.Size = New System.Drawing.Size(49, 13)
        Me.lbl_Promocion.TabIndex = 0
        Me.lbl_Promocion.Text = "Promoción"
        '
        'gc_PromocionesDet
        '
        Me.gc_PromocionesDet.DataSource = Me.UnboundSource1
        Me.gc_PromocionesDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_PromocionesDet.Location = New System.Drawing.Point(0, 58)
        Me.gc_PromocionesDet.MainView = Me.dgv_PromocionesDet
        Me.gc_PromocionesDet.Name = "gc_PromocionesDet"
        Me.gc_PromocionesDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ri_txtImpFijo, Me.ri_txtPorcDirecto, Me.ri_txtPorcDE, Me.ri_txtBono})
        Me.gc_PromocionesDet.Size = New System.Drawing.Size(878, 345)
        Me.gc_PromocionesDet.TabIndex = 1
        Me.gc_PromocionesDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_PromocionesDet})
        '
        'dgv_PromocionesDet
        '
        Me.dgv_PromocionesDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_FP, Me.gc_FormaPago, Me.gc_ImpFijo, Me.gc_PorcDirecto, Me.gc_PorcDE, Me.gc_Bono})
        Me.dgv_PromocionesDet.GridControl = Me.gc_PromocionesDet
        Me.dgv_PromocionesDet.Name = "dgv_PromocionesDet"
        '
        'gc_FP
        '
        Me.gc_FP.Caption = "FP"
        Me.gc_FP.FieldName = "fp"
        Me.gc_FP.Name = "gc_FP"
        '
        'gc_FormaPago
        '
        Me.gc_FormaPago.Caption = "Formas de Pago"
        Me.gc_FormaPago.FieldName = "formapago"
        Me.gc_FormaPago.Name = "gc_FormaPago"
        Me.gc_FormaPago.OptionsColumn.AllowEdit = False
        Me.gc_FormaPago.Visible = True
        Me.gc_FormaPago.VisibleIndex = 0
        Me.gc_FormaPago.Width = 184
        '
        'gc_ImpFijo
        '
        Me.gc_ImpFijo.Caption = "$ Fijo"
        Me.gc_ImpFijo.ColumnEdit = Me.ri_txtImpFijo
        Me.gc_ImpFijo.FieldName = "ImpFijo"
        Me.gc_ImpFijo.Name = "gc_ImpFijo"
        Me.gc_ImpFijo.Visible = True
        Me.gc_ImpFijo.VisibleIndex = 1
        Me.gc_ImpFijo.Width = 109
        '
        'ri_txtImpFijo
        '
        Me.ri_txtImpFijo.AutoHeight = False
        Me.ri_txtImpFijo.DisplayFormat.FormatString = "$ ###,##0.00"
        Me.ri_txtImpFijo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ri_txtImpFijo.Name = "ri_txtImpFijo"
        '
        'gc_PorcDirecto
        '
        Me.gc_PorcDirecto.Caption = "% Descuento"
        Me.gc_PorcDirecto.ColumnEdit = Me.ri_txtPorcDirecto
        Me.gc_PorcDirecto.FieldName = "PorcDesc"
        Me.gc_PorcDirecto.Name = "gc_PorcDirecto"
        Me.gc_PorcDirecto.Visible = True
        Me.gc_PorcDirecto.VisibleIndex = 2
        Me.gc_PorcDirecto.Width = 114
        '
        'ri_txtPorcDirecto
        '
        Me.ri_txtPorcDirecto.AutoHeight = False
        Me.ri_txtPorcDirecto.DisplayFormat.FormatString = "#0.00"
        Me.ri_txtPorcDirecto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ri_txtPorcDirecto.Mask.EditMask = "##0.00"
        Me.ri_txtPorcDirecto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ri_txtPorcDirecto.Name = "ri_txtPorcDirecto"
        '
        'gc_PorcDE
        '
        Me.gc_PorcDE.Caption = "% Din Elect"
        Me.gc_PorcDE.ColumnEdit = Me.ri_txtPorcDE
        Me.gc_PorcDE.FieldName = "PorcDE"
        Me.gc_PorcDE.Name = "gc_PorcDE"
        Me.gc_PorcDE.Visible = True
        Me.gc_PorcDE.VisibleIndex = 3
        Me.gc_PorcDE.Width = 113
        '
        'ri_txtPorcDE
        '
        Me.ri_txtPorcDE.AutoHeight = False
        Me.ri_txtPorcDE.DisplayFormat.FormatString = "#0.00"
        Me.ri_txtPorcDE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ri_txtPorcDE.Mask.EditMask = "##0.00"
        Me.ri_txtPorcDE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ri_txtPorcDE.Name = "ri_txtPorcDE"
        '
        'gc_Bono
        '
        Me.gc_Bono.Caption = "Bono $"
        Me.gc_Bono.ColumnEdit = Me.ri_txtBono
        Me.gc_Bono.FieldName = "Bono"
        Me.gc_Bono.Name = "gc_Bono"
        Me.gc_Bono.Visible = True
        Me.gc_Bono.VisibleIndex = 4
        Me.gc_Bono.Width = 172
        '
        'ri_txtBono
        '
        Me.ri_txtBono.AutoHeight = False
        Me.ri_txtBono.DisplayFormat.FormatString = "$ ###,##0.00"
        Me.ri_txtBono.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ri_txtBono.Name = "ri_txtBono"
        '
        'frmPromocionesDet
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 460)
        Me.Controls.Add(Me.gc_PromocionesDet)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPromocionesDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Promociones"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txt_TipoUni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NumUnidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TipoPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Fum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Usuario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NombrePromocion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdPromocion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnboundSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_PromocionesDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_PromocionesDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ri_txtImpFijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ri_txtPorcDirecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ri_txtPorcDE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ri_txtBono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txt_Fum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_FUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Usuario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Usuario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_NombrePromocion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_IdPromocion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Promocion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_TipoPromo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_TipoPromo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UnboundSource1 As DevExpress.Data.UnboundSource
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gc_PromocionesDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_PromocionesDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_FP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_FormaPago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_ImpFijo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ri_txtImpFijo As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents gc_PorcDirecto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ri_txtPorcDirecto As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents gc_PorcDE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ri_txtPorcDE As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents gc_Bono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ri_txtBono As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btn_GuardaPromocionesDet As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_TipoUni As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_TipoUni As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_NumUnidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_NumUnidad As DevExpress.XtraEditors.LabelControl
End Class
