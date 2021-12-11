<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClinicList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnAll = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboSearchBy = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgClinic = New System.Windows.Forms.DataGridView
        Me.csmClinic = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCancel = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        CType(Me.dgClinic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.csmClinic.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(-1, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Clinic Information"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAll)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboSearchBy)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(3, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(695, 88)
        Me.Panel1.TabIndex = 8
        '
        'btnAll
        '
        Me.btnAll.Location = New System.Drawing.Point(634, 42)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(58, 21)
        Me.btnAll.TabIndex = 81
        Me.btnAll.Text = "&All"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(4, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 19)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Search Item"
        '
        'cboSearchBy
        '
        Me.cboSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchBy.FormattingEnabled = True
        Me.cboSearchBy.Items.AddRange(New Object() {"--Select One", "CLinic ID", "Patient Name", "Doctor Name", "Diagnosis", "Date", "Contact Date"})
        Me.cboSearchBy.Location = New System.Drawing.Point(72, 40)
        Me.cboSearchBy.Name = "cboSearchBy"
        Me.cboSearchBy.Size = New System.Drawing.Size(185, 21)
        Me.cboSearchBy.TabIndex = 78
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Search By:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(570, 41)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(58, 21)
        Me.btnSearch.TabIndex = 77
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(327, 42)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(237, 20)
        Me.txtSearch.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(270, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Keyword:"
        '
        'dgClinic
        '
        Me.dgClinic.AllowUserToAddRows = False
        Me.dgClinic.AllowUserToDeleteRows = False
        Me.dgClinic.AllowUserToResizeColumns = False
        Me.dgClinic.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgClinic.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgClinic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgClinic.BackgroundColor = System.Drawing.Color.DarkSeaGreen
        Me.dgClinic.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgClinic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgClinic.ContextMenuStrip = Me.csmClinic
        Me.dgClinic.Location = New System.Drawing.Point(4, 140)
        Me.dgClinic.Name = "dgClinic"
        Me.dgClinic.ReadOnly = True
        Me.dgClinic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgClinic.Size = New System.Drawing.Size(693, 336)
        Me.dgClinic.TabIndex = 11
        '
        'csmClinic
        '
        Me.csmClinic.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuEdit, Me.mnuDelete, Me.mnuPrint, Me.mnuCancel})
        Me.csmClinic.Name = "csmStaff"
        Me.csmClinic.Size = New System.Drawing.Size(144, 114)
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(143, 22)
        Me.mnuNew.Text = "&New Clinic"
        Me.mnuNew.Visible = False
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(143, 22)
        Me.mnuEdit.Text = "&Edit Clinic"
        Me.mnuEdit.Visible = False
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(143, 22)
        Me.mnuDelete.Text = "&Delete Clinic"
        Me.mnuDelete.Visible = False
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(143, 22)
        Me.mnuPrint.Text = "&Print"
        Me.mnuPrint.Visible = False
        '
        'mnuCancel
        '
        Me.mnuCancel.Name = "mnuCancel"
        Me.mnuCancel.Size = New System.Drawing.Size(143, 22)
        Me.mnuCancel.Text = "&Cancel"
        Me.mnuCancel.Visible = False
        '
        'ClinicList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgClinic)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ClinicList"
        Me.Size = New System.Drawing.Size(714, 471)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgClinic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.csmClinic.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgClinic As System.Windows.Forms.DataGridView
    Friend WithEvents csmClinic As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAll As System.Windows.Forms.Button

End Class
