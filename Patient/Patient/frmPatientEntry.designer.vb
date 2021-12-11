<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientEntry
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
        Me.tcPatientInfo = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CboBono = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CboPuesto = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboSection = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lnkPictureBwr = New System.Windows.Forms.LinkLabel
        Me.picPatient = New System.Windows.Forms.PictureBox
        Me.txtNrcNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPhone_Hp = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPhone_O = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPhone_R = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker
        Me.cboBloodGroup = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboMartialStatus = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtPatientName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPatientID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtContact_Phone = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.oflg = New System.Windows.Forms.OpenFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblExit = New System.Windows.Forms.Label
        Me.picExit = New System.Windows.Forms.PictureBox
        Me.lblDelete = New System.Windows.Forms.Label
        Me.PicDelete = New System.Windows.Forms.PictureBox
        Me.lblSave = New System.Windows.Forms.Label
        Me.PicSaveAndClose = New System.Windows.Forms.PictureBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveAndClose = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem
        Me.ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tcPatientInfo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picPatient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSaveAndClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcPatientInfo
        '
        Me.tcPatientInfo.Controls.Add(Me.TabPage1)
        Me.tcPatientInfo.Controls.Add(Me.TabPage2)
        Me.tcPatientInfo.Location = New System.Drawing.Point(12, 60)
        Me.tcPatientInfo.Name = "tcPatientInfo"
        Me.tcPatientInfo.SelectedIndex = 0
        Me.tcPatientInfo.Size = New System.Drawing.Size(667, 425)
        Me.tcPatientInfo.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CboBono)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.CboPuesto)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.cboSection)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.txtNrcNo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.dtpDOB)
        Me.TabPage1.Controls.Add(Me.cboBloodGroup)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cboMartialStatus)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtPatientName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtPatientID)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtAddress)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(659, 399)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Infomacion"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'CboBono
        '
        Me.CboBono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboBono.FormattingEnabled = True
        Me.CboBono.Items.AddRange(New Object() {"--Seleccione"})
        Me.CboBono.Location = New System.Drawing.Point(327, 357)
        Me.CboBono.Name = "CboBono"
        Me.CboBono.Size = New System.Drawing.Size(110, 21)
        Me.CboBono.TabIndex = 81
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(247, 359)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 80
        Me.Label16.Text = "Nivel Bono"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(125, 359)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox1.TabIndex = 79
        Me.CheckBox1.Text = "Activo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 359)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "Estatus"
        '
        'CboPuesto
        '
        Me.CboPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPuesto.FormattingEnabled = True
        Me.CboPuesto.Items.AddRange(New Object() {"--Seleccione"})
        Me.CboPuesto.Location = New System.Drawing.Point(327, 323)
        Me.CboPuesto.Name = "CboPuesto"
        Me.CboPuesto.Size = New System.Drawing.Size(110, 21)
        Me.CboPuesto.TabIndex = 76
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(247, 328)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Puesto"
        '
        'cboSection
        '
        Me.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSection.FormattingEnabled = True
        Me.cboSection.Items.AddRange(New Object() {"--Seleccione"})
        Me.cboSection.Location = New System.Drawing.Point(327, 291)
        Me.cboSection.Name = "cboSection"
        Me.cboSection.Size = New System.Drawing.Size(110, 21)
        Me.cboSection.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(247, 296)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 13)
        Me.Label14.TabIndex = 75
        Me.Label14.Text = "Departamento"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lnkPictureBwr)
        Me.GroupBox2.Controls.Add(Me.picPatient)
        Me.GroupBox2.Location = New System.Drawing.Point(456, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 244)
        Me.GroupBox2.TabIndex = 73
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Foto"
        '
        'lnkPictureBwr
        '
        Me.lnkPictureBwr.AutoSize = True
        Me.lnkPictureBwr.Location = New System.Drawing.Point(69, 222)
        Me.lnkPictureBwr.Name = "lnkPictureBwr"
        Me.lnkPictureBwr.Size = New System.Drawing.Size(87, 13)
        Me.lnkPictureBwr.TabIndex = 13
        Me.lnkPictureBwr.TabStop = True
        Me.lnkPictureBwr.Text = "Seleccionar Foto"
        '
        'picPatient
        '
        Me.picPatient.Location = New System.Drawing.Point(16, 26)
        Me.picPatient.Name = "picPatient"
        Me.picPatient.Size = New System.Drawing.Size(178, 193)
        Me.picPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPatient.TabIndex = 0
        Me.picPatient.TabStop = False
        '
        'txtNrcNo
        '
        Me.txtNrcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNrcNo.Location = New System.Drawing.Point(125, 67)
        Me.txtNrcNo.Name = "txtNrcNo"
        Me.txtNrcNo.Size = New System.Drawing.Size(256, 20)
        Me.txtNrcNo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "N.Seg.Social"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPhone_Hp)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtPhone_O)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtPhone_R)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(125, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 108)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Telefonos"
        '
        'txtPhone_Hp
        '
        Me.txtPhone_Hp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone_Hp.Location = New System.Drawing.Point(125, 76)
        Me.txtPhone_Hp.Name = "txtPhone_Hp"
        Me.txtPhone_Hp.Size = New System.Drawing.Size(179, 20)
        Me.txtPhone_Hp.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(36, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Celular"
        '
        'txtPhone_O
        '
        Me.txtPhone_O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone_O.Location = New System.Drawing.Point(125, 50)
        Me.txtPhone_O.Name = "txtPhone_O"
        Me.txtPhone_O.Size = New System.Drawing.Size(179, 20)
        Me.txtPhone_O.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "Oficina"
        '
        'txtPhone_R
        '
        Me.txtPhone_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone_R.Location = New System.Drawing.Point(125, 19)
        Me.txtPhone_R.Name = "txtPhone_R"
        Me.txtPhone_R.Size = New System.Drawing.Size(179, 20)
        Me.txtPhone_R.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Casa"
        '
        'dtpDOB
        '
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDOB.Location = New System.Drawing.Point(125, 95)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(100, 20)
        Me.dtpDOB.TabIndex = 3
        '
        'cboBloodGroup
        '
        Me.cboBloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBloodGroup.FormattingEnabled = True
        Me.cboBloodGroup.Items.AddRange(New Object() {"--Seleccione", "A", "B", "AB", "O"})
        Me.cboBloodGroup.Location = New System.Drawing.Point(125, 320)
        Me.cboBloodGroup.Name = "cboBloodGroup"
        Me.cboBloodGroup.Size = New System.Drawing.Size(110, 21)
        Me.cboBloodGroup.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Tipo Sangre"
        '
        'cboMartialStatus
        '
        Me.cboMartialStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMartialStatus.FormattingEnabled = True
        Me.cboMartialStatus.Items.AddRange(New Object() {"--Seleccione ", "Soltero", "Casado", "Viudo", "Divorciado", "Union Libre"})
        Me.cboMartialStatus.Location = New System.Drawing.Point(125, 293)
        Me.cboMartialStatus.Name = "cboMartialStatus"
        Me.cboMartialStatus.Size = New System.Drawing.Size(110, 21)
        Me.cboMartialStatus.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 293)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Estado Civil"
        '
        'txtPatientName
        '
        Me.txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPatientName.Location = New System.Drawing.Point(125, 38)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(256, 20)
        Me.txtPatientName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Nombre"
        '
        'txtPatientID
        '
        Me.txtPatientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPatientID.Enabled = False
        Me.txtPatientID.Location = New System.Drawing.Point(125, 12)
        Me.txtPatientID.Name = "txtPatientID"
        Me.txtPatientID.Size = New System.Drawing.Size(92, 20)
        Me.txtPatientID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Empleado  Id"
        '
        'txtAddress
        '
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Location = New System.Drawing.Point(125, 122)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAddress.Size = New System.Drawing.Size(312, 49)
        Me.txtAddress.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Direccion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Fecha Ingreso"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtRemark)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.txtContact_Phone)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(659, 399)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Adficional"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.Location = New System.Drawing.Point(134, 54)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemark.Size = New System.Drawing.Size(508, 258)
        Me.txtRemark.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 76
        Me.Label12.Text = "Notas :"
        '
        'txtContact_Phone
        '
        Me.txtContact_Phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContact_Phone.Location = New System.Drawing.Point(134, 15)
        Me.txtContact_Phone.Name = "txtContact_Phone"
        Me.txtContact_Phone.Size = New System.Drawing.Size(155, 20)
        Me.txtContact_Phone.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Telefono Contacto :"
        '
        'oflg
        '
        Me.oflg.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.lblExit)
        Me.Panel1.Controls.Add(Me.picExit)
        Me.Panel1.Controls.Add(Me.lblDelete)
        Me.Panel1.Controls.Add(Me.PicDelete)
        Me.Panel1.Controls.Add(Me.lblSave)
        Me.Panel1.Controls.Add(Me.PicSaveAndClose)
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(691, 31)
        Me.Panel1.TabIndex = 49
        '
        'lblExit
        '
        Me.lblExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExit.Location = New System.Drawing.Point(243, 7)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(39, 17)
        Me.lblExit.TabIndex = 35
        Me.lblExit.Text = "Salir"
        '
        'picExit
        '
        Me.picExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picExit.Location = New System.Drawing.Point(214, 3)
        Me.picExit.Name = "picExit"
        Me.picExit.Size = New System.Drawing.Size(89, 25)
        Me.picExit.TabIndex = 34
        Me.picExit.TabStop = False
        '
        'lblDelete
        '
        Me.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDelete.Location = New System.Drawing.Point(141, 7)
        Me.lblDelete.Name = "lblDelete"
        Me.lblDelete.Size = New System.Drawing.Size(55, 18)
        Me.lblDelete.TabIndex = 33
        Me.lblDelete.Text = "Eliminar"
        '
        'PicDelete
        '
        Me.PicDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicDelete.Location = New System.Drawing.Point(124, 3)
        Me.PicDelete.Name = "PicDelete"
        Me.PicDelete.Size = New System.Drawing.Size(84, 25)
        Me.PicDelete.TabIndex = 32
        Me.PicDelete.TabStop = False
        '
        'lblSave
        '
        Me.lblSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblSave.Location = New System.Drawing.Point(18, 8)
        Me.lblSave.Name = "lblSave"
        Me.lblSave.Size = New System.Drawing.Size(84, 17)
        Me.lblSave.TabIndex = 31
        Me.lblSave.Text = "Grabar y Cerrar"
        '
        'PicSaveAndClose
        '
        Me.PicSaveAndClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicSaveAndClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicSaveAndClose.Location = New System.Drawing.Point(3, 3)
        Me.PicSaveAndClose.Name = "PicSaveAndClose"
        Me.PicSaveAndClose.Size = New System.Drawing.Size(119, 25)
        Me.PicSaveAndClose.TabIndex = 0
        Me.PicSaveAndClose.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(691, 24)
        Me.MenuStrip1.TabIndex = 48
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSaveAndClose, Me.mnuDelete, Me.mnuClose})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.FileToolStripMenuItem.Text = "&Archivo"
        '
        'mnuSaveAndClose
        '
        Me.mnuSaveAndClose.Name = "mnuSaveAndClose"
        Me.mnuSaveAndClose.Size = New System.Drawing.Size(164, 22)
        Me.mnuSaveAndClose.Text = "&Grabar y Cerrar"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(164, 22)
        Me.mnuDelete.Text = "&Eliminar y Cerrar"
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(164, 22)
        Me.mnuClose.Text = "&Cerrar"
        '
        'ep
        '
        Me.ep.ContainerControl = Me
        '
        'frmPatientEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(691, 491)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tcPatientInfo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo de Empleados"
        Me.tcPatientInfo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picPatient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSaveAndClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcPatientInfo As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtNrcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPhone_Hp As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPhone_O As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPhone_R As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboBloodGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboMartialStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtContact_Phone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lnkPictureBwr As System.Windows.Forms.LinkLabel
    Friend WithEvents picPatient As System.Windows.Forms.PictureBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents oflg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDelete As System.Windows.Forms.Label
    Friend WithEvents PicDelete As System.Windows.Forms.PictureBox
    Friend WithEvents lblSave As System.Windows.Forms.Label
    Friend WithEvents PicSaveAndClose As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveAndClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblExit As System.Windows.Forms.Label
    Friend WithEvents picExit As System.Windows.Forms.PictureBox
    Friend WithEvents cboSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CboPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CboBono As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
