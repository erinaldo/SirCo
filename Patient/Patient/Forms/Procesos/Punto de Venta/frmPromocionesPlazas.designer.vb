<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocionesPlazas
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
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Eliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.lbl_Sucursal = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Plaza = New DevExpress.XtraEditors.LabelControl()
        Me.cbo_Sucursal = New DevExpress.XtraEditors.LookUpEdit()
        Me.cbo_Plaza = New DevExpress.XtraEditors.LookUpEdit()
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.gc_Plazas = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Plazas = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.cbo_Sucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Plaza.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Plazas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Plazas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Eliminar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 219)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(267, 55)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(216, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(49, 51)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Eliminar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Eliminar.ImageOptions.ImageUri.Uri = "Delete"
        Me.btn_Eliminar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(51, 51)
        Me.btn_Eliminar.TabIndex = 0
        Me.btn_Eliminar.ToolTip = "Eliminar"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.lbl_Sucursal)
        Me.PanelControl2.Controls.Add(Me.lbl_Plaza)
        Me.PanelControl2.Controls.Add(Me.cbo_Sucursal)
        Me.PanelControl2.Controls.Add(Me.cbo_Plaza)
        Me.PanelControl2.Controls.Add(Me.btn_Guardar)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(267, 67)
        Me.PanelControl2.TabIndex = 0
        '
        'lbl_Sucursal
        '
        Me.lbl_Sucursal.Location = New System.Drawing.Point(13, 41)
        Me.lbl_Sucursal.Name = "lbl_Sucursal"
        Me.lbl_Sucursal.Size = New System.Drawing.Size(40, 13)
        Me.lbl_Sucursal.TabIndex = 7
        Me.lbl_Sucursal.Text = "Sucursal"
        '
        'lbl_Plaza
        '
        Me.lbl_Plaza.Location = New System.Drawing.Point(28, 15)
        Me.lbl_Plaza.Name = "lbl_Plaza"
        Me.lbl_Plaza.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Plaza.TabIndex = 6
        Me.lbl_Plaza.Text = "Plaza"
        '
        'cbo_Sucursal
        '
        Me.cbo_Sucursal.Location = New System.Drawing.Point(59, 38)
        Me.cbo_Sucursal.Name = "cbo_Sucursal"
        Me.cbo_Sucursal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Sucursal.Properties.NullText = "Seleccione"
        Me.cbo_Sucursal.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Sucursal.TabIndex = 1
        '
        'cbo_Plaza
        '
        Me.cbo_Plaza.Location = New System.Drawing.Point(59, 12)
        Me.cbo_Plaza.Name = "cbo_Plaza"
        Me.cbo_Plaza.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Plaza.Properties.NullText = "Seleccione"
        Me.cbo_Plaza.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Plaza.TabIndex = 0
        '
        'btn_Guardar
        '
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(165, 10)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(57, 47)
        Me.btn_Guardar.TabIndex = 2
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'gc_Plazas
        '
        Me.gc_Plazas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Plazas.Location = New System.Drawing.Point(0, 67)
        Me.gc_Plazas.MainView = Me.dgv_Plazas
        Me.gc_Plazas.Name = "gc_Plazas"
        Me.gc_Plazas.Size = New System.Drawing.Size(267, 152)
        Me.gc_Plazas.TabIndex = 2
        Me.gc_Plazas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Plazas})
        '
        'dgv_Plazas
        '
        Me.dgv_Plazas.GridControl = Me.gc_Plazas
        Me.dgv_Plazas.Name = "dgv_Plazas"
        Me.dgv_Plazas.OptionsBehavior.Editable = False
        '
        'frmPromocionesPlazas
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 274)
        Me.Controls.Add(Me.gc_Plazas)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPromocionesPlazas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plazas"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.cbo_Sucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Plaza.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Plazas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Plazas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Eliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lbl_Sucursal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Plaza As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbo_Sucursal As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cbo_Plaza As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gc_Plazas As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Plazas As DevExpress.XtraGrid.Views.Grid.GridView
End Class
