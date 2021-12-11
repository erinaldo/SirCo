<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuponesDet
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
        Me.txt_Cuantos = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Nombre = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Cuantos = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Tipo = New DevExpress.XtraEditors.LabelControl()
        Me.btn_Generar = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.lv_Cupones = New DevExpress.XtraEditors.ListBoxControl()
        Me.btn_Aleatorio = New DevExpress.XtraEditors.SimpleButton()
        Me.txt_Folio = New DevExpress.XtraEditors.TextEdit()
        Me.btn_Agregar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txt_Cuantos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.lv_Cupones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Folio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_Cuantos
        '
        Me.txt_Cuantos.Location = New System.Drawing.Point(65, 52)
        Me.txt_Cuantos.Name = "txt_Cuantos"
        Me.txt_Cuantos.Properties.MaxLength = 3
        Me.txt_Cuantos.Size = New System.Drawing.Size(100, 20)
        Me.txt_Cuantos.TabIndex = 0
        '
        'lbl_Nombre
        '
        Me.lbl_Nombre.Location = New System.Drawing.Point(12, 12)
        Me.lbl_Nombre.Name = "lbl_Nombre"
        Me.lbl_Nombre.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Nombre.TabIndex = 1
        Me.lbl_Nombre.Text = "Nombre"
        '
        'lbl_Cuantos
        '
        Me.lbl_Cuantos.Location = New System.Drawing.Point(19, 55)
        Me.lbl_Cuantos.Name = "lbl_Cuantos"
        Me.lbl_Cuantos.Size = New System.Drawing.Size(40, 13)
        Me.lbl_Cuantos.TabIndex = 2
        Me.lbl_Cuantos.Text = "Cuantos"
        '
        'lbl_Tipo
        '
        Me.lbl_Tipo.Location = New System.Drawing.Point(12, 31)
        Me.lbl_Tipo.Name = "lbl_Tipo"
        Me.lbl_Tipo.Size = New System.Drawing.Size(20, 13)
        Me.lbl_Tipo.TabIndex = 3
        Me.lbl_Tipo.Text = "Tipo"
        '
        'btn_Generar
        '
        Me.btn_Generar.Appearance.Options.UseTextOptions = True
        Me.btn_Generar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btn_Generar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Generar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Generar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Generar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Generar.Name = "btn_Generar"
        Me.btn_Generar.Size = New System.Drawing.Size(57, 50)
        Me.btn_Generar.TabIndex = 0
        Me.btn_Generar.ToolTip = "Generar Codigos"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Generar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 298)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(263, 54)
        Me.PanelControl1.TabIndex = 6
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(210, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(51, 50)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'lv_Cupones
        '
        Me.lv_Cupones.Location = New System.Drawing.Point(0, 104)
        Me.lv_Cupones.Name = "lv_Cupones"
        Me.lv_Cupones.Size = New System.Drawing.Size(165, 198)
        Me.lv_Cupones.TabIndex = 3
        '
        'btn_Aleatorio
        '
        Me.btn_Aleatorio.Location = New System.Drawing.Point(171, 104)
        Me.btn_Aleatorio.Name = "btn_Aleatorio"
        Me.btn_Aleatorio.Size = New System.Drawing.Size(75, 23)
        Me.btn_Aleatorio.TabIndex = 4
        Me.btn_Aleatorio.Text = "Aleatorio"
        Me.btn_Aleatorio.ToolTip = "Genera los codigos de manera aleatoria"
        '
        'txt_Folio
        '
        Me.txt_Folio.Location = New System.Drawing.Point(12, 78)
        Me.txt_Folio.Name = "txt_Folio"
        Me.txt_Folio.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Folio.Size = New System.Drawing.Size(153, 20)
        Me.txt_Folio.TabIndex = 1
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Location = New System.Drawing.Point(171, 75)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Agregar.TabIndex = 2
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.ToolTip = "Agregar el codigo ingresado"
        '
        'frmCuponesDet
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 352)
        Me.Controls.Add(Me.btn_Agregar)
        Me.Controls.Add(Me.txt_Folio)
        Me.Controls.Add(Me.btn_Aleatorio)
        Me.Controls.Add(Me.lv_Cupones)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.lbl_Tipo)
        Me.Controls.Add(Me.lbl_Cuantos)
        Me.Controls.Add(Me.lbl_Nombre)
        Me.Controls.Add(Me.txt_Cuantos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCuponesDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folios Cupones"
        CType(Me.txt_Cuantos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.lv_Cupones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Folio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_Cuantos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Nombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Cuantos As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Tipo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btn_Generar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lv_Cupones As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents btn_Aleatorio As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_Folio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_Agregar As DevExpress.XtraEditors.SimpleButton
End Class
