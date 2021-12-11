<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioPassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioPassword))
        Me.LblVersion = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Txt_PasswordAnt = New System.Windows.Forms.TextBox
        Me.Txt_NuevoPassword = New System.Windows.Forms.TextBox
        Me.Lbl_NewPass = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Lbl_PassAnt = New System.Windows.Forms.Label
        Me.Lbl_Usuario = New System.Windows.Forms.Label
        Me.Txt_Usuario = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Location = New System.Drawing.Point(13, 224)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(0, 13)
        Me.LblVersion.TabIndex = 15
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.Image = Global.SIRCO.My.Resources.Resources.accept
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(354, 141)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(94, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&OK"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SIRCO.My.Resources.Resources.martha
        Me.PictureBox2.Location = New System.Drawing.Point(12, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(192, 116)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Txt_PasswordAnt
        '
        Me.Txt_PasswordAnt.ForeColor = System.Drawing.Color.DarkBlue
        Me.Txt_PasswordAnt.Location = New System.Drawing.Point(130, 47)
        Me.Txt_PasswordAnt.MaxLength = 6
        Me.Txt_PasswordAnt.Name = "Txt_PasswordAnt"
        Me.Txt_PasswordAnt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_PasswordAnt.Size = New System.Drawing.Size(103, 20)
        Me.Txt_PasswordAnt.TabIndex = 1
        '
        'Txt_NuevoPassword
        '
        Me.Txt_NuevoPassword.ForeColor = System.Drawing.Color.DarkBlue
        Me.Txt_NuevoPassword.Location = New System.Drawing.Point(130, 73)
        Me.Txt_NuevoPassword.MaxLength = 6
        Me.Txt_NuevoPassword.Name = "Txt_NuevoPassword"
        Me.Txt_NuevoPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_NuevoPassword.Size = New System.Drawing.Size(103, 20)
        Me.Txt_NuevoPassword.TabIndex = 2
        '
        'Lbl_NewPass
        '
        Me.Lbl_NewPass.AutoSize = True
        Me.Lbl_NewPass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_NewPass.Location = New System.Drawing.Point(12, 76)
        Me.Lbl_NewPass.Name = "Lbl_NewPass"
        Me.Lbl_NewPass.Size = New System.Drawing.Size(112, 13)
        Me.Lbl_NewPass.TabIndex = 11
        Me.Lbl_NewPass.Text = "Nueva Contraseña"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lbl_PassAnt)
        Me.GroupBox1.Controls.Add(Me.Lbl_Usuario)
        Me.GroupBox1.Controls.Add(Me.Txt_Usuario)
        Me.GroupBox1.Controls.Add(Me.Lbl_NewPass)
        Me.GroupBox1.Controls.Add(Me.Txt_NuevoPassword)
        Me.GroupBox1.Controls.Add(Me.Txt_PasswordAnt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.GroupBox1.Location = New System.Drawing.Point(210, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 116)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cambio de Contraseña"
        '
        'Lbl_PassAnt
        '
        Me.Lbl_PassAnt.AutoSize = True
        Me.Lbl_PassAnt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_PassAnt.Location = New System.Drawing.Point(5, 50)
        Me.Lbl_PassAnt.Name = "Lbl_PassAnt"
        Me.Lbl_PassAnt.Size = New System.Drawing.Size(119, 13)
        Me.Lbl_PassAnt.TabIndex = 14
        Me.Lbl_PassAnt.Text = "Contraseña Anterior"
        '
        'Lbl_Usuario
        '
        Me.Lbl_Usuario.AutoSize = True
        Me.Lbl_Usuario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Usuario.Location = New System.Drawing.Point(74, 24)
        Me.Lbl_Usuario.Name = "Lbl_Usuario"
        Me.Lbl_Usuario.Size = New System.Drawing.Size(50, 13)
        Me.Lbl_Usuario.TabIndex = 13
        Me.Lbl_Usuario.Text = "Usuario"
        '
        'Txt_Usuario
        '
        Me.Txt_Usuario.Location = New System.Drawing.Point(130, 21)
        Me.Txt_Usuario.MaxLength = 8
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.Size = New System.Drawing.Size(103, 20)
        Me.Txt_Usuario.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Image = Global.SIRCO.My.Resources.Resources.cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(234, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmCambioPassword
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(457, 170)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioPassword"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Contraseña"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents LblVersion As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Txt_PasswordAnt As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NuevoPassword As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_NewPass As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Lbl_Usuario As System.Windows.Forms.Label
    Friend WithEvents Txt_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_PassAnt As System.Windows.Forms.Label

End Class
