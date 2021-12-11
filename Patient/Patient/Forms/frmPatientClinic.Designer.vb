<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientClinic
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcClinic = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cboDoctor = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtOthers = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.dtpContactDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgClinicHis = New System.Windows.Forms.DataGridView
        Me.cms2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem
        Me.lnkPatient = New System.Windows.Forms.LinkLabel
        Me.brwPatient = New System.Windows.Forms.Button
        Me.txtInvestigation = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtTreatement = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtDiagnosis = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtBP = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPR = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtBW = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtHistory = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDrugAllergy = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtRgsNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgPic = New System.Windows.Forms.DataGridView
        Me.cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lnkPictureBwr = New System.Windows.Forms.LinkLabel
        Me.picParts = New System.Windows.Forms.PictureBox
        Me.lnkViewImage = New System.Windows.Forms.LinkLabel
        Me.txtPicRemark = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblNew = New System.Windows.Forms.Label
        Me.picNew = New System.Windows.Forms.PictureBox
        Me.lblExit = New System.Windows.Forms.Label
        Me.picExit = New System.Windows.Forms.PictureBox
        Me.lblDelete = New System.Windows.Forms.Label
        Me.PicDelete = New System.Windows.Forms.PictureBox
        Me.lblSave = New System.Windows.Forms.Label
        Me.PicSaveAndClose = New System.Windows.Forms.PictureBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveAndCloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.oflg = New System.Windows.Forms.OpenFileDialog
        Me.tcClinic.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgClinicHis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSaveAndClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcClinic
        '
        Me.tcClinic.Controls.Add(Me.TabPage1)
        Me.tcClinic.Controls.Add(Me.TabPage2)
        Me.tcClinic.Location = New System.Drawing.Point(3, 61)
        Me.tcClinic.Name = "tcClinic"
        Me.tcClinic.SelectedIndex = 0
        Me.tcClinic.Size = New System.Drawing.Size(550, 675)
        Me.tcClinic.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cboDoctor)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.txtOthers)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.dtpDate)
        Me.TabPage1.Controls.Add(Me.dtpContactDate)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.lnkPatient)
        Me.TabPage1.Controls.Add(Me.brwPatient)
        Me.TabPage1.Controls.Add(Me.txtInvestigation)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtTreatement)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.txtDiagnosis)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.txtHistory)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtDrugAllergy)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtRgsNo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.ForeColor = System.Drawing.Color.SteelBlue
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(542, 649)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cboDoctor
        '
        Me.cboDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDoctor.FormattingEnabled = True
        Me.cboDoctor.Location = New System.Drawing.Point(328, 375)
        Me.cboDoctor.Name = "cboDoctor"
        Me.cboDoctor.Size = New System.Drawing.Size(201, 21)
        Me.cboDoctor.TabIndex = 38
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(252, 379)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 13)
        Me.Label21.TabIndex = 57
        Me.Label21.Text = "Doctor Name"
        '
        'txtOthers
        '
        Me.txtOthers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOthers.Location = New System.Drawing.Point(131, 402)
        Me.txtOthers.Multiline = True
        Me.txtOthers.Name = "txtOthers"
        Me.txtOthers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOthers.Size = New System.Drawing.Size(399, 37)
        Me.txtOthers.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 402)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Others"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(325, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Date"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(364, 9)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpDate.TabIndex = 51
        '
        'dtpContactDate
        '
        Me.dtpContactDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpContactDate.Location = New System.Drawing.Point(133, 376)
        Me.dtpContactDate.Name = "dtpContactDate"
        Me.dtpContactDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpContactDate.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Contact Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgClinicHis)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox2.Location = New System.Drawing.Point(15, 445)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 200)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Clinic History"
        '
        'dgClinicHis
        '
        Me.dgClinicHis.AllowUserToAddRows = False
        Me.dgClinicHis.AllowUserToDeleteRows = False
        Me.dgClinicHis.AllowUserToResizeColumns = False
        Me.dgClinicHis.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgClinicHis.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgClinicHis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgClinicHis.BackgroundColor = System.Drawing.Color.LightSlateGray
        Me.dgClinicHis.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgClinicHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgClinicHis.ContextMenuStrip = Me.cms2
        Me.dgClinicHis.Location = New System.Drawing.Point(11, 17)
        Me.dgClinicHis.Name = "dgClinicHis"
        Me.dgClinicHis.ReadOnly = True
        Me.dgClinicHis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgClinicHis.Size = New System.Drawing.Size(503, 177)
        Me.dgClinicHis.TabIndex = 57
        '
        'cms2
        '
        Me.cms2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuView})
        Me.cms2.Name = "cms"
        Me.cms2.Size = New System.Drawing.Size(108, 26)
        '
        'mnuView
        '
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(107, 22)
        Me.mnuView.Text = "&View"
        '
        'lnkPatient
        '
        Me.lnkPatient.BackColor = System.Drawing.Color.MistyRose
        Me.lnkPatient.Location = New System.Drawing.Point(20, 39)
        Me.lnkPatient.Name = "lnkPatient"
        Me.lnkPatient.Size = New System.Drawing.Size(302, 23)
        Me.lnkPatient.TabIndex = 44
        '
        'brwPatient
        '
        Me.brwPatient.Location = New System.Drawing.Point(328, 39)
        Me.brwPatient.Name = "brwPatient"
        Me.brwPatient.Size = New System.Drawing.Size(139, 23)
        Me.brwPatient.TabIndex = 40
        Me.brwPatient.Text = "Brw : Patient"
        Me.brwPatient.UseVisualStyleBackColor = True
        '
        'txtInvestigation
        '
        Me.txtInvestigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInvestigation.Location = New System.Drawing.Point(134, 347)
        Me.txtInvestigation.Name = "txtInvestigation"
        Me.txtInvestigation.Size = New System.Drawing.Size(399, 20)
        Me.txtInvestigation.TabIndex = 36
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 349)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Investigation"
        '
        'txtTreatement
        '
        Me.txtTreatement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTreatement.Location = New System.Drawing.Point(133, 299)
        Me.txtTreatement.Multiline = True
        Me.txtTreatement.Name = "txtTreatement"
        Me.txtTreatement.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTreatement.Size = New System.Drawing.Size(399, 42)
        Me.txtTreatement.TabIndex = 35
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 301)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "Treatment"
        '
        'txtDiagnosis
        '
        Me.txtDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiagnosis.Location = New System.Drawing.Point(133, 273)
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.Size = New System.Drawing.Size(399, 20)
        Me.txtDiagnosis.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 275)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "Diagnosis"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(18, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Examination"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtBP)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtPR)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtBW)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(134, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 106)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Examination"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label14.Location = New System.Drawing.Point(153, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "mmhg"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label15.Location = New System.Drawing.Point(153, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "/min"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.DarkMagenta
        Me.Label16.Location = New System.Drawing.Point(153, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "lb"
        '
        'txtBP
        '
        Me.txtBP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBP.Location = New System.Drawing.Point(47, 76)
        Me.txtBP.Name = "txtBP"
        Me.txtBP.Size = New System.Drawing.Size(100, 20)
        Me.txtBP.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(12, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "BP"
        '
        'txtPR
        '
        Me.txtPR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPR.Location = New System.Drawing.Point(47, 50)
        Me.txtPR.Name = "txtPR"
        Me.txtPR.Size = New System.Drawing.Size(100, 20)
        Me.txtPR.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(12, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "PR"
        '
        'txtBW
        '
        Me.txtBW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBW.Location = New System.Drawing.Point(47, 24)
        Me.txtBW.Name = "txtBW"
        Me.txtBW.Size = New System.Drawing.Size(100, 20)
        Me.txtBW.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(12, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "BW"
        '
        'txtHistory
        '
        Me.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHistory.Location = New System.Drawing.Point(137, 103)
        Me.txtHistory.Multiline = True
        Me.txtHistory.Name = "txtHistory"
        Me.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtHistory.Size = New System.Drawing.Size(399, 52)
        Me.txtHistory.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(20, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Current's History"
        '
        'txtDrugAllergy
        '
        Me.txtDrugAllergy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDrugAllergy.Location = New System.Drawing.Point(137, 77)
        Me.txtDrugAllergy.Name = "txtDrugAllergy"
        Me.txtDrugAllergy.Size = New System.Drawing.Size(399, 20)
        Me.txtDrugAllergy.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(20, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Drug Allergy"
        '
        'txtRgsNo
        '
        Me.txtRgsNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRgsNo.Enabled = False
        Me.txtRgsNo.Location = New System.Drawing.Point(133, 10)
        Me.txtRgsNo.Name = "txtRgsNo"
        Me.txtRgsNo.Size = New System.Drawing.Size(61, 20)
        Me.txtRgsNo.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Registration Number"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgPic)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.txtPicRemark)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(542, 649)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Extra Information"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgPic
        '
        Me.dgPic.AllowUserToAddRows = False
        Me.dgPic.AllowUserToDeleteRows = False
        Me.dgPic.AllowUserToResizeColumns = False
        Me.dgPic.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dgPic.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgPic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPic.BackgroundColor = System.Drawing.Color.LightSlateGray
        Me.dgPic.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgPic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPic.ContextMenuStrip = Me.cms
        Me.dgPic.Location = New System.Drawing.Point(9, 284)
        Me.dgPic.Name = "dgPic"
        Me.dgPic.ReadOnly = True
        Me.dgPic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPic.Size = New System.Drawing.Size(530, 359)
        Me.dgPic.TabIndex = 56
        '
        'cms
        '
        Me.cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDelete})
        Me.cms.Name = "cms"
        Me.cms.Size = New System.Drawing.Size(117, 26)
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(116, 22)
        Me.mnuDelete.Text = "&Delete"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(375, 176)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 55
        Me.btnSave.Text = "&Save Picture"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Wheat
        Me.GroupBox3.Controls.Add(Me.lnkPictureBwr)
        Me.GroupBox3.Controls.Add(Me.picParts)
        Me.GroupBox3.Controls.Add(Me.lnkViewImage)
        Me.GroupBox3.Location = New System.Drawing.Point(164, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(205, 198)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Picture"
        '
        'lnkPictureBwr
        '
        Me.lnkPictureBwr.AutoSize = True
        Me.lnkPictureBwr.Location = New System.Drawing.Point(41, 172)
        Me.lnkPictureBwr.Name = "lnkPictureBwr"
        Me.lnkPictureBwr.Size = New System.Drawing.Size(42, 13)
        Me.lnkPictureBwr.TabIndex = 55
        Me.lnkPictureBwr.TabStop = True
        Me.lnkPictureBwr.Text = "Browse"
        '
        'picParts
        '
        Me.picParts.Location = New System.Drawing.Point(24, 21)
        Me.picParts.Name = "picParts"
        Me.picParts.Size = New System.Drawing.Size(153, 147)
        Me.picParts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picParts.TabIndex = 39
        Me.picParts.TabStop = False
        '
        'lnkViewImage
        '
        Me.lnkViewImage.AutoSize = True
        Me.lnkViewImage.Location = New System.Drawing.Point(125, 171)
        Me.lnkViewImage.Name = "lnkViewImage"
        Me.lnkViewImage.Size = New System.Drawing.Size(30, 13)
        Me.lnkViewImage.TabIndex = 40
        Me.lnkViewImage.TabStop = True
        Me.lnkViewImage.Text = "View"
        '
        'txtPicRemark
        '
        Me.txtPicRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPicRemark.Location = New System.Drawing.Point(129, 222)
        Me.txtPicRemark.Multiline = True
        Me.txtPicRemark.Name = "txtPicRemark"
        Me.txtPicRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPicRemark.Size = New System.Drawing.Size(393, 56)
        Me.txtPicRemark.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(5, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Picture Information :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.lblNew)
        Me.Panel1.Controls.Add(Me.picNew)
        Me.Panel1.Controls.Add(Me.lblExit)
        Me.Panel1.Controls.Add(Me.picExit)
        Me.Panel1.Controls.Add(Me.lblDelete)
        Me.Panel1.Controls.Add(Me.PicDelete)
        Me.Panel1.Controls.Add(Me.lblSave)
        Me.Panel1.Controls.Add(Me.PicSaveAndClose)
        Me.Panel1.Location = New System.Drawing.Point(-2, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(559, 31)
        Me.Panel1.TabIndex = 49
        '
        'lblNew
        '
        Me.lblNew.AutoSize = True
        Me.lblNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNew.Location = New System.Drawing.Point(34, 8)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(29, 13)
        Me.lblNew.TabIndex = 39
        Me.lblNew.Text = "New"
        '
        'picNew
        '
        Me.picNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picNew.Location = New System.Drawing.Point(7, 3)
        Me.picNew.Name = "picNew"
        Me.picNew.Size = New System.Drawing.Size(91, 25)
        Me.picNew.TabIndex = 38
        Me.picNew.TabStop = False
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Location = New System.Drawing.Point(318, 8)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(24, 13)
        Me.lblExit.TabIndex = 37
        Me.lblExit.Text = "Exit"
        '
        'picExit
        '
        Me.picExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picExit.Location = New System.Drawing.Point(291, 3)
        Me.picExit.Name = "picExit"
        Me.picExit.Size = New System.Drawing.Size(91, 25)
        Me.picExit.TabIndex = 36
        Me.picExit.TabStop = False
        '
        'lblDelete
        '
        Me.lblDelete.AutoSize = True
        Me.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDelete.Location = New System.Drawing.Point(225, 8)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(38, 13)
        Me.lblDelete.TabIndex = 33
        Me.lblDelete.Text = "Delete"
        '
        'PicDelete
        '
        Me.PicDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicDelete.Location = New System.Drawing.Point(199, 3)
        Me.PicDelete.Name = "PicDelete"
        Me.PicDelete.Size = New System.Drawing.Size(91, 25)
        Me.PicDelete.TabIndex = 32
        Me.PicDelete.TabStop = False
        '
        'lblSave
        '
        Me.lblSave.AutoSize = True
        Me.lblSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSave.Location = New System.Drawing.Point(127, 8)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(32, 13)
        Me.lblSave.TabIndex = 31
        Me.lblSave.Text = "Save"
        '
        'PicSaveAndClose
        '
        Me.PicSaveAndClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicSaveAndClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicSaveAndClose.Location = New System.Drawing.Point(99, 3)
        Me.PicSaveAndClose.Name = "PicSaveAndClose"
        Me.PicSaveAndClose.Size = New System.Drawing.Size(99, 25)
        Me.PicSaveAndClose.TabIndex = 0
        Me.PicSaveAndClose.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(558, 24)
        Me.MenuStrip1.TabIndex = 48
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveAndCloseToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SaveAndCloseToolStripMenuItem
        '
        Me.SaveAndCloseToolStripMenuItem.Name = "SaveAndCloseToolStripMenuItem"
        Me.SaveAndCloseToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SaveAndCloseToolStripMenuItem.Text = "&Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.EditToolStripMenuItem1.Text = "&Help"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyToolStripMenuItem.Text = "&About Software"
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'oflg
        '
        Me.oflg.FileName = "ofd"
        '
        'frmPatientClinic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 748)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tcClinic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientClinic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clinic Information ( Insert / Edit / Delete )"
        Me.tcClinic.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgClinicHis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.picParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSaveAndClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcClinic As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkPatient As System.Windows.Forms.LinkLabel
    Friend WithEvents brwPatient As System.Windows.Forms.Button
    Friend WithEvents txtInvestigation As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTreatement As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBP As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPR As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBW As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtHistory As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDrugAllergy As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRgsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtPicRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lnkViewImage As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents picParts As System.Windows.Forms.PictureBox
    Friend WithEvents lnkPictureBwr As System.Windows.Forms.LinkLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDelete As System.Windows.Forms.Label
    Friend WithEvents PicDelete As System.Windows.Forms.PictureBox
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents PicSaveAndClose As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAndCloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblExit As System.Windows.Forms.Label
    Friend WithEvents picExit As System.Windows.Forms.PictureBox
    Friend WithEvents dtpContactDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOthers As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDoctor As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblNew As System.Windows.Forms.Label
    Friend WithEvents picNew As System.Windows.Forms.PictureBox
    Friend WithEvents oflg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dgPic As System.Windows.Forms.DataGridView
    Friend WithEvents cms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgClinicHis As System.Windows.Forms.DataGridView
    Friend WithEvents cms2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
End Class
