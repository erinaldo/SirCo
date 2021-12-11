<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCliente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCliente))
        Me.Pnl_Principal = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cmd_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit2 = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Nombre = New System.Windows.Forms.Label()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_CP = New System.Windows.Forms.ComboBox()
        Me.Cmb_Estado = New System.Windows.Forms.ComboBox()
        Me.Cmb_Ciudad = New System.Windows.Forms.ComboBox()
        Me.Cmb_Colonia = New System.Windows.Forms.ComboBox()
        Me.Lbl_Calle = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_CP = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Colonia = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Numero = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Ciudad = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Numero = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Estado = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Calle = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Email = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_Principal.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Numero.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Calle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Email.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Principal
        '
        Me.Pnl_Principal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Principal.Controls.Add(Me.LabelControl2)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Email)
        Me.Pnl_Principal.Controls.Add(Me.LabelControl1)
        Me.Pnl_Principal.Controls.Add(Me.TextEdit4)
        Me.Pnl_Principal.Controls.Add(Me.Cmb_CP)
        Me.Pnl_Principal.Controls.Add(Me.Cmb_Estado)
        Me.Pnl_Principal.Controls.Add(Me.Cmb_Ciudad)
        Me.Pnl_Principal.Controls.Add(Me.Cmb_Colonia)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Calle)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_CP)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Colonia)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Numero)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Ciudad)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Numero)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Estado)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Calle)
        Me.Pnl_Principal.Controls.Add(Me.Label3)
        Me.Pnl_Principal.Controls.Add(Me.Label2)
        Me.Pnl_Principal.Controls.Add(Me.Label1)
        Me.Pnl_Principal.Controls.Add(Me.TextEdit3)
        Me.Pnl_Principal.Controls.Add(Me.Lbl_Nombre)
        Me.Pnl_Principal.Controls.Add(Me.TextEdit2)
        Me.Pnl_Principal.Controls.Add(Me.TextEdit1)
        Me.Pnl_Principal.Controls.Add(Me.Txt_Nombre)
        Me.Pnl_Principal.Controls.Add(Me.PictureBox2)
        Me.Pnl_Principal.Controls.Add(Me.PictureBox1)
        Me.Pnl_Principal.Location = New System.Drawing.Point(5, 2)
        Me.Pnl_Principal.Name = "Pnl_Principal"
        Me.Pnl_Principal.Size = New System.Drawing.Size(814, 374)
        Me.Pnl_Principal.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SIRCO.My.Resources.Resources.whats
        Me.PictureBox2.Location = New System.Drawing.Point(193, 111)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SIRCO.My.Resources.Resources.app
        Me.PictureBox1.Location = New System.Drawing.Point(34, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 94)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Cmd_Aceptar)
        Me.Panel1.Location = New System.Drawing.Point(5, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(814, 63)
        Me.Panel1.TabIndex = 1
        '
        'Cmd_Aceptar
        '
        Me.Cmd_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Cmd_Aceptar.Location = New System.Drawing.Point(684, 16)
        Me.Cmd_Aceptar.Name = "Cmd_Aceptar"
        Me.Cmd_Aceptar.Size = New System.Drawing.Size(75, 28)
        Me.Cmd_Aceptar.TabIndex = 6
        Me.Cmd_Aceptar.Text = "&Aceptar"
        Me.Cmd_Aceptar.ToolTip = "Comenzar proceso de Venta"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.Location = New System.Drawing.Point(241, 36)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Nombre.Size = New System.Drawing.Size(199, 20)
        Me.Txt_Nombre.TabIndex = 2
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(241, 62)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEdit1.Size = New System.Drawing.Size(199, 20)
        Me.TextEdit1.TabIndex = 3
        '
        'TextEdit2
        '
        Me.TextEdit2.Location = New System.Drawing.Point(241, 88)
        Me.TextEdit2.Name = "TextEdit2"
        Me.TextEdit2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEdit2.Size = New System.Drawing.Size(199, 20)
        Me.TextEdit2.TabIndex = 4
        '
        'Lbl_Nombre
        '
        Me.Lbl_Nombre.AutoSize = True
        Me.Lbl_Nombre.Location = New System.Drawing.Point(162, 39)
        Me.Lbl_Nombre.Name = "Lbl_Nombre"
        Me.Lbl_Nombre.Size = New System.Drawing.Size(44, 13)
        Me.Lbl_Nombre.TabIndex = 5
        Me.Lbl_Nombre.Text = "Nombre"
        '
        'TextEdit3
        '
        Me.TextEdit3.Location = New System.Drawing.Point(241, 123)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEdit3.Size = New System.Drawing.Size(199, 20)
        Me.TextEdit3.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Para recibir promociones!!"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(162, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ap. Paterno"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(162, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Ap. Materno"
        '
        'Cmb_CP
        '
        Me.Cmb_CP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_CP.FormattingEnabled = True
        Me.Cmb_CP.Location = New System.Drawing.Point(118, 208)
        Me.Cmb_CP.MaxLength = 5
        Me.Cmb_CP.Name = "Cmb_CP"
        Me.Cmb_CP.Size = New System.Drawing.Size(132, 21)
        Me.Cmb_CP.TabIndex = 15
        '
        'Cmb_Estado
        '
        Me.Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Estado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Estado.FormattingEnabled = True
        Me.Cmb_Estado.Location = New System.Drawing.Point(605, 239)
        Me.Cmb_Estado.Name = "Cmb_Estado"
        Me.Cmb_Estado.Size = New System.Drawing.Size(194, 21)
        Me.Cmb_Estado.TabIndex = 21
        '
        'Cmb_Ciudad
        '
        Me.Cmb_Ciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Ciudad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Ciudad.FormattingEnabled = True
        Me.Cmb_Ciudad.Location = New System.Drawing.Point(362, 239)
        Me.Cmb_Ciudad.Name = "Cmb_Ciudad"
        Me.Cmb_Ciudad.Size = New System.Drawing.Size(194, 21)
        Me.Cmb_Ciudad.TabIndex = 19
        '
        'Cmb_Colonia
        '
        Me.Cmb_Colonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Colonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Colonia.FormattingEnabled = True
        Me.Cmb_Colonia.Location = New System.Drawing.Point(118, 239)
        Me.Cmb_Colonia.Name = "Cmb_Colonia"
        Me.Cmb_Colonia.Size = New System.Drawing.Size(194, 21)
        Me.Cmb_Colonia.TabIndex = 17
        '
        'Lbl_Calle
        '
        Me.Lbl_Calle.Location = New System.Drawing.Point(31, 278)
        Me.Lbl_Calle.Name = "Lbl_Calle"
        Me.Lbl_Calle.Size = New System.Drawing.Size(23, 13)
        Me.Lbl_Calle.TabIndex = 11
        Me.Lbl_Calle.Text = "Calle"
        '
        'Lbl_CP
        '
        Me.Lbl_CP.Location = New System.Drawing.Point(31, 208)
        Me.Lbl_CP.Name = "Lbl_CP"
        Me.Lbl_CP.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_CP.TabIndex = 16
        Me.Lbl_CP.Text = "Código Postal"
        '
        'Lbl_Colonia
        '
        Me.Lbl_Colonia.Location = New System.Drawing.Point(31, 242)
        Me.Lbl_Colonia.Name = "Lbl_Colonia"
        Me.Lbl_Colonia.Size = New System.Drawing.Size(35, 13)
        Me.Lbl_Colonia.TabIndex = 18
        Me.Lbl_Colonia.Text = "Colonia"
        '
        'Lbl_Numero
        '
        Me.Lbl_Numero.Location = New System.Drawing.Point(468, 278)
        Me.Lbl_Numero.Name = "Lbl_Numero"
        Me.Lbl_Numero.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Numero.TabIndex = 13
        Me.Lbl_Numero.Text = "Número"
        '
        'Lbl_Ciudad
        '
        Me.Lbl_Ciudad.Location = New System.Drawing.Point(323, 242)
        Me.Lbl_Ciudad.Name = "Lbl_Ciudad"
        Me.Lbl_Ciudad.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_Ciudad.TabIndex = 20
        Me.Lbl_Ciudad.Text = "Ciudad"
        '
        'Txt_Numero
        '
        Me.Txt_Numero.Location = New System.Drawing.Point(511, 275)
        Me.Txt_Numero.Name = "Txt_Numero"
        Me.Txt_Numero.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Numero.Properties.Appearance.Options.UseFont = True
        Me.Txt_Numero.Properties.MaxLength = 2
        Me.Txt_Numero.Size = New System.Drawing.Size(59, 20)
        Me.Txt_Numero.TabIndex = 14
        '
        'Lbl_Estado
        '
        Me.Lbl_Estado.Location = New System.Drawing.Point(566, 242)
        Me.Lbl_Estado.Name = "Lbl_Estado"
        Me.Lbl_Estado.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_Estado.TabIndex = 22
        Me.Lbl_Estado.Text = "Estado"
        '
        'Txt_Calle
        '
        Me.Txt_Calle.Location = New System.Drawing.Point(118, 275)
        Me.Txt_Calle.Name = "Txt_Calle"
        Me.Txt_Calle.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Calle.Properties.Appearance.Options.UseFont = True
        Me.Txt_Calle.Size = New System.Drawing.Size(344, 20)
        Me.Txt_Calle.TabIndex = 12
        '
        'TextEdit4
        '
        Me.TextEdit4.Location = New System.Drawing.Point(118, 301)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextEdit4.Properties.Appearance.Options.UseFont = True
        Me.TextEdit4.Size = New System.Drawing.Size(344, 20)
        Me.TextEdit4.TabIndex = 23
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(31, 304)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 24
        Me.LabelControl1.Text = "Entre Calles"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(31, 330)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 26
        Me.LabelControl2.Text = "Email"
        '
        'Txt_Email
        '
        Me.Txt_Email.Location = New System.Drawing.Point(118, 327)
        Me.Txt_Email.Name = "Txt_Email"
        Me.Txt_Email.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Txt_Email.Properties.Appearance.Options.UseFont = True
        Me.Txt_Email.Size = New System.Drawing.Size(344, 20)
        Me.Txt_Email.TabIndex = 25
        '
        'frmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl_Principal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCliente"
        Me.Text = "Clientes"
        Me.Pnl_Principal.ResumeLayout(False)
        Me.Pnl_Principal.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Numero.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Calle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Email.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Principal As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Nombre As Label
    Friend WithEvents TextEdit2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Cmd_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Email As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Cmb_CP As ComboBox
    Friend WithEvents Cmb_Estado As ComboBox
    Friend WithEvents Cmb_Ciudad As ComboBox
    Friend WithEvents Cmb_Colonia As ComboBox
    Friend WithEvents Lbl_Calle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_CP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Colonia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Numero As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Ciudad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Numero As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Estado As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Calle As DevExpress.XtraEditors.TextEdit
End Class
