<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocionesAgrupaciones
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
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.gc_AgrupacionCompra = New DevExpress.XtraEditors.GroupControl()
        Me.txt_AgrupacionCompra = New DevExpress.XtraEditors.TextEdit()
        Me.btn_BuscaAgruCompra = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_IdAgrupacionCompra = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_AgruCompra = New DevExpress.XtraEditors.LabelControl()
        Me.gb_AgrupacionPromo = New DevExpress.XtraEditors.GroupControl()
        Me.txt_AgrupacionPromo = New DevExpress.XtraEditors.TextEdit()
        Me.btn_BuscaAgruPromo = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_IdAgrupacionPromo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.gc_AgrupacionCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gc_AgrupacionCompra.SuspendLayout()
        CType(Me.txt_AgrupacionCompra.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdAgrupacionCompra.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gb_AgrupacionPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_AgrupacionPromo.SuspendLayout()
        CType(Me.txt_AgrupacionPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_IdAgrupacionPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Guardar)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 86)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(460, 51)
        Me.PanelControl1.TabIndex = 2
        '
        'btn_Guardar
        '
        Me.btn_Guardar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(45, 47)
        Me.btn_Guardar.TabIndex = 0
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(410, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(48, 47)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'gc_AgrupacionCompra
        '
        Me.gc_AgrupacionCompra.Controls.Add(Me.txt_AgrupacionCompra)
        Me.gc_AgrupacionCompra.Controls.Add(Me.btn_BuscaAgruCompra)
        Me.gc_AgrupacionCompra.Controls.Add(Me.txt_IdAgrupacionCompra)
        Me.gc_AgrupacionCompra.Controls.Add(Me.lbl_AgruCompra)
        Me.gc_AgrupacionCompra.Dock = System.Windows.Forms.DockStyle.Left
        Me.gc_AgrupacionCompra.Location = New System.Drawing.Point(0, 0)
        Me.gc_AgrupacionCompra.Name = "gc_AgrupacionCompra"
        Me.gc_AgrupacionCompra.Size = New System.Drawing.Size(224, 86)
        Me.gc_AgrupacionCompra.TabIndex = 0
        Me.gc_AgrupacionCompra.Text = "Agruapción COMPRA"
        '
        'txt_AgrupacionCompra
        '
        Me.txt_AgrupacionCompra.Location = New System.Drawing.Point(65, 55)
        Me.txt_AgrupacionCompra.Name = "txt_AgrupacionCompra"
        Me.txt_AgrupacionCompra.Properties.ReadOnly = True
        Me.txt_AgrupacionCompra.Size = New System.Drawing.Size(132, 20)
        Me.txt_AgrupacionCompra.TabIndex = 2
        '
        'btn_BuscaAgruCompra
        '
        Me.btn_BuscaAgruCompra.Location = New System.Drawing.Point(104, 27)
        Me.btn_BuscaAgruCompra.Name = "btn_BuscaAgruCompra"
        Me.btn_BuscaAgruCompra.Size = New System.Drawing.Size(29, 23)
        Me.btn_BuscaAgruCompra.TabIndex = 1
        Me.btn_BuscaAgruCompra.Text = "..."
        '
        'txt_IdAgrupacionCompra
        '
        Me.txt_IdAgrupacionCompra.Location = New System.Drawing.Point(65, 29)
        Me.txt_IdAgrupacionCompra.Name = "txt_IdAgrupacionCompra"
        Me.txt_IdAgrupacionCompra.Size = New System.Drawing.Size(33, 20)
        Me.txt_IdAgrupacionCompra.TabIndex = 0
        '
        'lbl_AgruCompra
        '
        Me.lbl_AgruCompra.Location = New System.Drawing.Point(5, 32)
        Me.lbl_AgruCompra.Name = "lbl_AgruCompra"
        Me.lbl_AgruCompra.Size = New System.Drawing.Size(54, 13)
        Me.lbl_AgruCompra.TabIndex = 1
        Me.lbl_AgruCompra.Text = "Agrupación"
        '
        'gb_AgrupacionPromo
        '
        Me.gb_AgrupacionPromo.Controls.Add(Me.txt_AgrupacionPromo)
        Me.gb_AgrupacionPromo.Controls.Add(Me.btn_BuscaAgruPromo)
        Me.gb_AgrupacionPromo.Controls.Add(Me.txt_IdAgrupacionPromo)
        Me.gb_AgrupacionPromo.Controls.Add(Me.LabelControl3)
        Me.gb_AgrupacionPromo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gb_AgrupacionPromo.Location = New System.Drawing.Point(224, 0)
        Me.gb_AgrupacionPromo.Name = "gb_AgrupacionPromo"
        Me.gb_AgrupacionPromo.Size = New System.Drawing.Size(236, 86)
        Me.gb_AgrupacionPromo.TabIndex = 1
        Me.gb_AgrupacionPromo.Text = "Agrupación PROMO"
        '
        'txt_AgrupacionPromo
        '
        Me.txt_AgrupacionPromo.Location = New System.Drawing.Point(66, 55)
        Me.txt_AgrupacionPromo.Name = "txt_AgrupacionPromo"
        Me.txt_AgrupacionPromo.Properties.ReadOnly = True
        Me.txt_AgrupacionPromo.Size = New System.Drawing.Size(132, 20)
        Me.txt_AgrupacionPromo.TabIndex = 2
        '
        'btn_BuscaAgruPromo
        '
        Me.btn_BuscaAgruPromo.Location = New System.Drawing.Point(105, 27)
        Me.btn_BuscaAgruPromo.Name = "btn_BuscaAgruPromo"
        Me.btn_BuscaAgruPromo.Size = New System.Drawing.Size(29, 23)
        Me.btn_BuscaAgruPromo.TabIndex = 1
        Me.btn_BuscaAgruPromo.Text = "..."
        '
        'txt_IdAgrupacionPromo
        '
        Me.txt_IdAgrupacionPromo.Location = New System.Drawing.Point(66, 29)
        Me.txt_IdAgrupacionPromo.Name = "txt_IdAgrupacionPromo"
        Me.txt_IdAgrupacionPromo.Size = New System.Drawing.Size(33, 20)
        Me.txt_IdAgrupacionPromo.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(6, 32)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Agrupación"
        '
        'frmPromocionesAgrupaciones
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 137)
        Me.Controls.Add(Me.gb_AgrupacionPromo)
        Me.Controls.Add(Me.gc_AgrupacionCompra)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPromocionesAgrupaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Agrupación"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.gc_AgrupacionCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gc_AgrupacionCompra.ResumeLayout(False)
        Me.gc_AgrupacionCompra.PerformLayout()
        CType(Me.txt_AgrupacionCompra.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdAgrupacionCompra.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gb_AgrupacionPromo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_AgrupacionPromo.ResumeLayout(False)
        Me.gb_AgrupacionPromo.PerformLayout()
        CType(Me.txt_AgrupacionPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_IdAgrupacionPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gc_AgrupacionCompra As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_AgrupacionCompra As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_BuscaAgruCompra As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_IdAgrupacionCompra As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_AgruCompra As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gb_AgrupacionPromo As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txt_AgrupacionPromo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_BuscaAgruPromo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_IdAgrupacionPromo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
