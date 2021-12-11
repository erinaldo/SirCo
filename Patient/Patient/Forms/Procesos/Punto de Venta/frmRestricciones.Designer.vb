<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestricciones
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
        Me.btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_Tip = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Tipo = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Imagen = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Descripcion = New DevExpress.XtraEditors.LabelControl()
        Me.pb_Imagen = New DevExpress.XtraEditors.PictureEdit()
        Me.txt_Descripcion = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.pb_Imagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Descripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Aceptar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 166)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(355, 60)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(302, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(51, 56)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Aceptar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(53, 56)
        Me.btn_Aceptar.TabIndex = 0
        Me.btn_Aceptar.ToolTip = "Aceptar"
        '
        'lbl_Tip
        '
        Me.lbl_Tip.Location = New System.Drawing.Point(43, 12)
        Me.lbl_Tip.Name = "lbl_Tip"
        Me.lbl_Tip.Size = New System.Drawing.Size(24, 13)
        Me.lbl_Tip.TabIndex = 1
        Me.lbl_Tip.Text = "Tipo:"
        '
        'lbl_Tipo
        '
        Me.lbl_Tipo.Location = New System.Drawing.Point(73, 12)
        Me.lbl_Tipo.Name = "lbl_Tipo"
        Me.lbl_Tipo.Size = New System.Drawing.Size(66, 13)
        Me.lbl_Tipo.TabIndex = 2
        Me.lbl_Tipo.Text = "LabelControl2"
        '
        'lbl_Imagen
        '
        Me.lbl_Imagen.Location = New System.Drawing.Point(26, 43)
        Me.lbl_Imagen.Name = "lbl_Imagen"
        Me.lbl_Imagen.Size = New System.Drawing.Size(40, 13)
        Me.lbl_Imagen.TabIndex = 3
        Me.lbl_Imagen.Text = "Imagen:"
        '
        'lbl_Descripcion
        '
        Me.lbl_Descripcion.Location = New System.Drawing.Point(8, 133)
        Me.lbl_Descripcion.Name = "lbl_Descripcion"
        Me.lbl_Descripcion.Size = New System.Drawing.Size(58, 13)
        Me.lbl_Descripcion.TabIndex = 4
        Me.lbl_Descripcion.Text = "Descripción:"
        '
        'pb_Imagen
        '
        Me.pb_Imagen.Location = New System.Drawing.Point(73, 43)
        Me.pb_Imagen.Name = "pb_Imagen"
        Me.pb_Imagen.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray
        Me.pb_Imagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.pb_Imagen.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_Imagen.Size = New System.Drawing.Size(87, 77)
        Me.pb_Imagen.TabIndex = 5
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.Location = New System.Drawing.Point(73, 130)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Descripcion.Properties.MaxLength = 100
        Me.txt_Descripcion.Size = New System.Drawing.Size(270, 20)
        Me.txt_Descripcion.TabIndex = 6
        '
        'frmRestricciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 226)
        Me.Controls.Add(Me.txt_Descripcion)
        Me.Controls.Add(Me.pb_Imagen)
        Me.Controls.Add(Me.lbl_Descripcion)
        Me.Controls.Add(Me.lbl_Imagen)
        Me.Controls.Add(Me.lbl_Tipo)
        Me.Controls.Add(Me.lbl_Tip)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRestricciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Restricción"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.pb_Imagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Descripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_Tip As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Tipo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Imagen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Descripcion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pb_Imagen As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txt_Descripcion As DevExpress.XtraEditors.TextEdit
End Class
