<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocionesExclusiones
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
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_Estilo = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Marca = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Estilo = New DevExpress.XtraEditors.TextEdit()
        Me.txt_NomMarca = New DevExpress.XtraEditors.TextEdit()
        Me.txt_Marca = New DevExpress.XtraEditors.TextEdit()
        Me.gc_Exclusiones = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Exclusiones = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txt_Estilo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_NomMarca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Marca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Exclusiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Exclusiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Eliminar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 209)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(351, 54)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(300, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(49, 50)
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
        Me.btn_Eliminar.Size = New System.Drawing.Size(46, 50)
        Me.btn_Eliminar.TabIndex = 0
        Me.btn_Eliminar.ToolTip = "Eliminar"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btn_Guardar)
        Me.PanelControl2.Controls.Add(Me.lbl_Estilo)
        Me.PanelControl2.Controls.Add(Me.lbl_Marca)
        Me.PanelControl2.Controls.Add(Me.txt_Estilo)
        Me.PanelControl2.Controls.Add(Me.txt_NomMarca)
        Me.PanelControl2.Controls.Add(Me.txt_Marca)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(351, 70)
        Me.PanelControl2.TabIndex = 1
        '
        'btn_Guardar
        '
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(246, 11)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(57, 51)
        Me.btn_Guardar.TabIndex = 3
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'lbl_Estilo
        '
        Me.lbl_Estilo.Location = New System.Drawing.Point(8, 42)
        Me.lbl_Estilo.Name = "lbl_Estilo"
        Me.lbl_Estilo.Size = New System.Drawing.Size(25, 13)
        Me.lbl_Estilo.TabIndex = 6
        Me.lbl_Estilo.Text = "Estilo"
        '
        'lbl_Marca
        '
        Me.lbl_Marca.Location = New System.Drawing.Point(8, 16)
        Me.lbl_Marca.Name = "lbl_Marca"
        Me.lbl_Marca.Size = New System.Drawing.Size(29, 13)
        Me.lbl_Marca.TabIndex = 5
        Me.lbl_Marca.Text = "Marca"
        '
        'txt_Estilo
        '
        Me.txt_Estilo.Location = New System.Drawing.Point(81, 38)
        Me.txt_Estilo.Name = "txt_Estilo"
        Me.txt_Estilo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Estilo.Properties.MaxLength = 7
        Me.txt_Estilo.Size = New System.Drawing.Size(48, 20)
        Me.txt_Estilo.TabIndex = 2
        '
        'txt_NomMarca
        '
        Me.txt_NomMarca.Enabled = False
        Me.txt_NomMarca.Location = New System.Drawing.Point(135, 12)
        Me.txt_NomMarca.Name = "txt_NomMarca"
        Me.txt_NomMarca.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_NomMarca.Properties.ReadOnly = True
        Me.txt_NomMarca.Size = New System.Drawing.Size(105, 20)
        Me.txt_NomMarca.TabIndex = 1
        '
        'txt_Marca
        '
        Me.txt_Marca.Location = New System.Drawing.Point(81, 12)
        Me.txt_Marca.Name = "txt_Marca"
        Me.txt_Marca.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Marca.Properties.MaxLength = 3
        Me.txt_Marca.Size = New System.Drawing.Size(48, 20)
        Me.txt_Marca.TabIndex = 0
        '
        'gc_Exclusiones
        '
        Me.gc_Exclusiones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Exclusiones.Location = New System.Drawing.Point(0, 70)
        Me.gc_Exclusiones.MainView = Me.dgv_Exclusiones
        Me.gc_Exclusiones.Name = "gc_Exclusiones"
        Me.gc_Exclusiones.Size = New System.Drawing.Size(351, 139)
        Me.gc_Exclusiones.TabIndex = 0
        Me.gc_Exclusiones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Exclusiones})
        '
        'dgv_Exclusiones
        '
        Me.dgv_Exclusiones.GridControl = Me.gc_Exclusiones
        Me.dgv_Exclusiones.Name = "dgv_Exclusiones"
        '
        'frmPromocionesExclusiones
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 263)
        Me.Controls.Add(Me.gc_Exclusiones)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPromocionesExclusiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exclusiones"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txt_Estilo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_NomMarca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Marca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Exclusiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Exclusiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Eliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_Estilo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Marca As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_Estilo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_NomMarca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_Marca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents gc_Exclusiones As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Exclusiones As DevExpress.XtraGrid.Views.Grid.GridView
End Class
