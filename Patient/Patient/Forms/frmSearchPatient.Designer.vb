<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchPatient
    Inherits System.Windows.Forms.Form

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
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnExitII = New System.Windows.Forms.Button
        Me.btnSaveII = New System.Windows.Forms.Button
        Me.btnDeleteII = New System.Windows.Forms.Button
        Me.btnNewII = New System.Windows.Forms.Button
        Me.lnkViewImage = New System.Windows.Forms.LinkLabel
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboSearchBy = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(10, 140)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(529, 195)
        Me.DataGridView2.TabIndex = 39
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(316, 7)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 35
        Me.btnBrowse.Text = "Bwr :"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(125, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(173, 20)
        Me.TextBox1.TabIndex = 33
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Wheat
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(164, 341)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 188)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Picture"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(24, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(153, 147)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'btnExitII
        '
        Me.btnExitII.Location = New System.Drawing.Point(486, 535)
        Me.btnExitII.Name = "btnExitII"
        Me.btnExitII.Size = New System.Drawing.Size(47, 23)
        Me.btnExitII.TabIndex = 53
        Me.btnExitII.Text = "E&xit"
        Me.btnExitII.UseVisualStyleBackColor = True
        '
        'btnSaveII
        '
        Me.btnSaveII.Location = New System.Drawing.Point(326, 535)
        Me.btnSaveII.Name = "btnSaveII"
        Me.btnSaveII.Size = New System.Drawing.Size(47, 23)
        Me.btnSaveII.TabIndex = 50
        Me.btnSaveII.Text = "&Save"
        Me.btnSaveII.UseVisualStyleBackColor = True
        '
        'btnDeleteII
        '
        Me.btnDeleteII.Location = New System.Drawing.Point(433, 535)
        Me.btnDeleteII.Name = "btnDeleteII"
        Me.btnDeleteII.Size = New System.Drawing.Size(47, 23)
        Me.btnDeleteII.TabIndex = 52
        Me.btnDeleteII.Text = "&Delete"
        Me.btnDeleteII.UseVisualStyleBackColor = True
        '
        'btnNewII
        '
        Me.btnNewII.Location = New System.Drawing.Point(379, 535)
        Me.btnNewII.Name = "btnNewII"
        Me.btnNewII.Size = New System.Drawing.Size(47, 23)
        Me.btnNewII.TabIndex = 51
        Me.btnNewII.Text = "&New"
        Me.btnNewII.UseVisualStyleBackColor = True
        '
        'lnkViewImage
        '
        Me.lnkViewImage.AutoSize = True
        Me.lnkViewImage.Location = New System.Drawing.Point(362, 496)
        Me.lnkViewImage.Name = "lnkViewImage"
        Me.lnkViewImage.Size = New System.Drawing.Size(104, 13)
        Me.lnkViewImage.TabIndex = 40
        Me.lnkViewImage.TabStop = True
        Me.lnkViewImage.Text = "Click To View Image"
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(125, 44)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(407, 74)
        Me.TextBox2.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Picture Information :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Picture's Path"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 84)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(728, 470)
        Me.DataGridView1.TabIndex = 45
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSearchBy)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 66)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Item"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchBy.FormattingEnabled = True
        Me.cboSearchBy.Items.AddRange(New Object() {"--Seleccione Uno", "Empleado ID", "Nombre", "Pueblo", "Enfermedad"})
        Me.cboSearchBy.Location = New System.Drawing.Point(97, 24)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(185, 21)
        Me.cboSearchBy.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Busqueda por:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(620, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 21)
        Me.btnSearch.TabIndex = 72
        Me.btnSearch.Text = "&Buscar"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(391, 24)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(207, 20)
        Me.TextBox4.TabIndex = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(304, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Palabra Clave:"
        '
        'frmSearchPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 557)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchPatient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "(  Busqueda Empleado )"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnExitII As System.Windows.Forms.Button
    Friend WithEvents btnSaveII As System.Windows.Forms.Button
    Friend WithEvents btnDeleteII As System.Windows.Forms.Button
    Friend WithEvents btnNewII As System.Windows.Forms.Button
    Friend WithEvents lnkViewImage As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
