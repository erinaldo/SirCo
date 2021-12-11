<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoL2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoL2))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.Txt_CveDivisiones = New System.Windows.Forms.TextBox
        Me.Txt_DescripDivisiones = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Txt_IdDivisiones = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txt_CveL2 = New System.Windows.Forms.TextBox
        Me.Txt_DescripL2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Txt_idL2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_CveL1 = New System.Windows.Forms.TextBox
        Me.Txt_DescripL1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Txt_IdL1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txt_CveLinea = New System.Windows.Forms.TextBox
        Me.Txt_DescripLinea = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Txt_IdLinea = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_CveFam = New System.Windows.Forms.TextBox
        Me.Txt_DescripFam = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_IdFamilia = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Clave = New System.Windows.Forms.TextBox
        Me.Txt_Campo1 = New System.Windows.Forms.TextBox
        Me.Txt_Campo = New System.Windows.Forms.TextBox
        Me.Txt_DescripDepto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_IdDepto = New System.Windows.Forms.TextBox
        Me.Lbl_Marca = New System.Windows.Forms.Label
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Label15)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_CveDivisiones)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDivisiones)
        Me.Pnl_Edicion.Controls.Add(Me.Label16)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDivisiones)
        Me.Pnl_Edicion.Controls.Add(Me.Label17)
        Me.Pnl_Edicion.Controls.Add(Me.Label12)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_CveL2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL2)
        Me.Pnl_Edicion.Controls.Add(Me.Label13)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_idL2)
        Me.Pnl_Edicion.Controls.Add(Me.Label14)
        Me.Pnl_Edicion.Controls.Add(Me.Label9)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_CveL1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL1)
        Me.Pnl_Edicion.Controls.Add(Me.Label10)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL1)
        Me.Pnl_Edicion.Controls.Add(Me.Label11)
        Me.Pnl_Edicion.Controls.Add(Me.Label6)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_CveLinea)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripLinea)
        Me.Pnl_Edicion.Controls.Add(Me.Label7)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdLinea)
        Me.Pnl_Edicion.Controls.Add(Me.Label8)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_CveFam)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripFam)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFamilia)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Clave)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Campo1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Campo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 316)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 85
        Me.Label15.Text = "Divisiones"
        '
        'Txt_CveDivisiones
        '
        Me.Txt_CveDivisiones.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_CveDivisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CveDivisiones.Location = New System.Drawing.Point(94, 29)
        Me.Txt_CveDivisiones.MaxLength = 3
        Me.Txt_CveDivisiones.Name = "Txt_CveDivisiones"
        Me.Txt_CveDivisiones.Size = New System.Drawing.Size(42, 20)
        Me.Txt_CveDivisiones.TabIndex = 1
        '
        'Txt_DescripDivisiones
        '
        Me.Txt_DescripDivisiones.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDivisiones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripDivisiones.Enabled = False
        Me.Txt_DescripDivisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDivisiones.Location = New System.Drawing.Point(214, 28)
        Me.Txt_DescripDivisiones.MaxLength = 30
        Me.Txt_DescripDivisiones.Name = "Txt_DescripDivisiones"
        Me.Txt_DescripDivisiones.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripDivisiones.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(24, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 84
        Me.Label16.Text = "IdDivisiones"
        Me.Label16.Visible = False
        '
        'Txt_IdDivisiones
        '
        Me.Txt_IdDivisiones.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDivisiones.Enabled = False
        Me.Txt_IdDivisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDivisiones.Location = New System.Drawing.Point(94, 3)
        Me.Txt_IdDivisiones.MaxLength = 6
        Me.Txt_IdDivisiones.Name = "Txt_IdDivisiones"
        Me.Txt_IdDivisiones.ReadOnly = True
        Me.Txt_IdDivisiones.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdDivisiones.TabIndex = 0
        Me.Txt_IdDivisiones.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(144, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 81
        Me.Label17.Text = "Descripción"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(60, 291)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 13)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "L2"
        '
        'Txt_CveL2
        '
        Me.Txt_CveL2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_CveL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CveL2.Location = New System.Drawing.Point(94, 288)
        Me.Txt_CveL2.MaxLength = 3
        Me.Txt_CveL2.Name = "Txt_CveL2"
        Me.Txt_CveL2.Size = New System.Drawing.Size(42, 20)
        Me.Txt_CveL2.TabIndex = 16
        '
        'Txt_DescripL2
        '
        Me.Txt_DescripL2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL2.Location = New System.Drawing.Point(214, 288)
        Me.Txt_DescripL2.MaxLength = 30
        Me.Txt_DescripL2.Name = "Txt_DescripL2"
        Me.Txt_DescripL2.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripL2.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(52, 265)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 78
        Me.Label13.Text = "IdL2"
        Me.Label13.Visible = False
        '
        'Txt_idL2
        '
        Me.Txt_idL2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_idL2.Enabled = False
        Me.Txt_idL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_idL2.Location = New System.Drawing.Point(94, 262)
        Me.Txt_idL2.MaxLength = 6
        Me.Txt_idL2.Name = "Txt_idL2"
        Me.Txt_idL2.ReadOnly = True
        Me.Txt_idL2.Size = New System.Drawing.Size(42, 20)
        Me.Txt_idL2.TabIndex = 15
        Me.Txt_idL2.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(144, 291)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 77
        Me.Label14.Text = "Descripción"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(60, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "L1"
        '
        'Txt_CveL1
        '
        Me.Txt_CveL1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_CveL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CveL1.Location = New System.Drawing.Point(94, 236)
        Me.Txt_CveL1.MaxLength = 3
        Me.Txt_CveL1.Name = "Txt_CveL1"
        Me.Txt_CveL1.Size = New System.Drawing.Size(42, 20)
        Me.Txt_CveL1.TabIndex = 13
        '
        'Txt_DescripL1
        '
        Me.Txt_DescripL1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripL1.Enabled = False
        Me.Txt_DescripL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL1.Location = New System.Drawing.Point(214, 236)
        Me.Txt_DescripL1.MaxLength = 30
        Me.Txt_DescripL1.Name = "Txt_DescripL1"
        Me.Txt_DescripL1.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripL1.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(57, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 13)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "IdL1"
        Me.Label10.Visible = False
        '
        'Txt_IdL1
        '
        Me.Txt_IdL1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdL1.Enabled = False
        Me.Txt_IdL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL1.Location = New System.Drawing.Point(94, 210)
        Me.Txt_IdL1.MaxLength = 6
        Me.Txt_IdL1.Name = "Txt_IdL1"
        Me.Txt_IdL1.ReadOnly = True
        Me.Txt_IdL1.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdL1.TabIndex = 12
        Me.Txt_IdL1.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(144, 239)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 71
        Me.Label11.Text = "Descripción"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(46, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Linea"
        '
        'Txt_CveLinea
        '
        Me.Txt_CveLinea.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_CveLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CveLinea.Location = New System.Drawing.Point(94, 184)
        Me.Txt_CveLinea.MaxLength = 3
        Me.Txt_CveLinea.Name = "Txt_CveLinea"
        Me.Txt_CveLinea.Size = New System.Drawing.Size(42, 20)
        Me.Txt_CveLinea.TabIndex = 10
        '
        'Txt_DescripLinea
        '
        Me.Txt_DescripLinea.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripLinea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripLinea.Enabled = False
        Me.Txt_DescripLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripLinea.Location = New System.Drawing.Point(214, 184)
        Me.Txt_DescripLinea.MaxLength = 30
        Me.Txt_DescripLinea.Name = "Txt_DescripLinea"
        Me.Txt_DescripLinea.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripLinea.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "IdLinea"
        Me.Label7.Visible = False
        '
        'Txt_IdLinea
        '
        Me.Txt_IdLinea.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdLinea.Enabled = False
        Me.Txt_IdLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdLinea.Location = New System.Drawing.Point(94, 158)
        Me.Txt_IdLinea.MaxLength = 6
        Me.Txt_IdLinea.Name = "Txt_IdLinea"
        Me.Txt_IdLinea.ReadOnly = True
        Me.Txt_IdLinea.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdLinea.TabIndex = 9
        Me.Txt_IdLinea.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(144, 187)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Familia"
        '
        'Txt_CveFam
        '
        Me.Txt_CveFam.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_CveFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CveFam.Location = New System.Drawing.Point(94, 132)
        Me.Txt_CveFam.MaxLength = 3
        Me.Txt_CveFam.Name = "Txt_CveFam"
        Me.Txt_CveFam.Size = New System.Drawing.Size(42, 20)
        Me.Txt_CveFam.TabIndex = 7
        '
        'Txt_DescripFam
        '
        Me.Txt_DescripFam.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripFam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripFam.Enabled = False
        Me.Txt_DescripFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripFam.Location = New System.Drawing.Point(214, 132)
        Me.Txt_DescripFam.MaxLength = 30
        Me.Txt_DescripFam.Name = "Txt_DescripFam"
        Me.Txt_DescripFam.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripFam.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "IdFamilia"
        Me.Label4.Visible = False
        '
        'Txt_IdFamilia
        '
        Me.Txt_IdFamilia.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdFamilia.Enabled = False
        Me.Txt_IdFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFamilia.Location = New System.Drawing.Point(94, 106)
        Me.Txt_IdFamilia.MaxLength = 6
        Me.Txt_IdFamilia.Name = "Txt_IdFamilia"
        Me.Txt_IdFamilia.ReadOnly = True
        Me.Txt_IdFamilia.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdFamilia.TabIndex = 6
        Me.Txt_IdFamilia.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(144, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Departamento"
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Clave.Location = New System.Drawing.Point(94, 81)
        Me.Txt_Clave.MaxLength = 3
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Clave.TabIndex = 4
        '
        'Txt_Campo1
        '
        Me.Txt_Campo1.Location = New System.Drawing.Point(482, 7)
        Me.Txt_Campo1.Name = "Txt_Campo1"
        Me.Txt_Campo1.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Campo1.TabIndex = 53
        Me.Txt_Campo1.Visible = False
        '
        'Txt_Campo
        '
        Me.Txt_Campo.Location = New System.Drawing.Point(444, 7)
        Me.Txt_Campo.Name = "Txt_Campo"
        Me.Txt_Campo.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Campo.TabIndex = 52
        Me.Txt_Campo.Visible = False
        '
        'Txt_DescripDepto
        '
        Me.Txt_DescripDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DescripDepto.Enabled = False
        Me.Txt_DescripDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDepto.Location = New System.Drawing.Point(214, 81)
        Me.Txt_DescripDepto.MaxLength = 30
        Me.Txt_DescripDepto.Name = "Txt_DescripDepto"
        Me.Txt_DescripDepto.ReadOnly = True
        Me.Txt_DescripDepto.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripDepto.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "IdDepto"
        Me.Label1.Visible = False
        '
        'Txt_IdDepto
        '
        Me.Txt_IdDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepto.Enabled = False
        Me.Txt_IdDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepto.Location = New System.Drawing.Point(94, 55)
        Me.Txt_IdDepto.MaxLength = 6
        Me.Txt_IdDepto.Name = "Txt_IdDepto"
        Me.Txt_IdDepto.ReadOnly = True
        Me.Txt_IdDepto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdDepto.TabIndex = 3
        Me.Txt_IdDepto.Visible = False
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.Location = New System.Drawing.Point(144, 84)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(63, 13)
        Me.Lbl_Marca.TabIndex = 0
        Me.Lbl_Marca.Text = "Descripción"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 325)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(559, 55)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(131, 3)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Eliminar.TabIndex = 6
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(453, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Cancelar.TabIndex = 4
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(504, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Aceptar.TabIndex = 3
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(74, 3)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Editar.TabIndex = 1
        Me.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Editar.UseVisualStyleBackColor = True
        Me.Btn_Editar.Visible = False
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(17, 3)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Nuevo.TabIndex = 0
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        Me.Btn_Nuevo.Visible = False
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'frmCatalogoL2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 392)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoL2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de L2"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_IdDepto As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripDepto As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Txt_Campo1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Campo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_CveFam As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripFam As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdFamilia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_CveLinea As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdLinea As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_CveL1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripL1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdL1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_CveL2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripL2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txt_idL2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Txt_CveDivisiones As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDivisiones As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdDivisiones As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
