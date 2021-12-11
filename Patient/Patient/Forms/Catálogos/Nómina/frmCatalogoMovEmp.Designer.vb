<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoMovEmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoMovEmp))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.Tbc_Movimientos = New System.Windows.Forms.TabControl
        Me.Tbp_Baja = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DTBaja = New System.Windows.Forms.DateTimePicker
        Me.Cbo_MotivoBaja = New System.Windows.Forms.ComboBox
        Me.Txt_ComentariosBaja = New System.Windows.Forms.TextBox
        Me.Tbp_Sueldo = New System.Windows.Forms.TabPage
        Me.Tbp_Reingreso = New System.Windows.Forms.TabPage
        Me.Txt_PuestoReingreso = New System.Windows.Forms.TextBox
        Me.Txt_DescripPuestoR = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_DeptoReingreso = New System.Windows.Forms.TextBox
        Me.Txt_DescripDeptoR = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTReingreso = New System.Windows.Forms.DateTimePicker
        Me.Tbp_CambioDep = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.Txt_ComentariosDep = New System.Windows.Forms.TextBox
        Me.Lbl_FechaDepPue = New System.Windows.Forms.Label
        Me.DTDeptoPuesto = New System.Windows.Forms.DateTimePicker
        Me.Txt_ClavePuestoDep = New System.Windows.Forms.TextBox
        Me.Txt_DescripPuestoD = New System.Windows.Forms.TextBox
        Me.Lbl_PuestoDep = New System.Windows.Forms.Label
        Me.Txt_ClaveDeptoDep = New System.Windows.Forms.TextBox
        Me.Txt_DescripDeptoD = New System.Windows.Forms.TextBox
        Me.Lbl_DeptoDep = New System.Windows.Forms.Label
        Me.Tbp_CambioSuc = New System.Windows.Forms.TabPage
        Me.Lbl_ComentariosSuc = New System.Windows.Forms.Label
        Me.Txt_ComentariosSuc = New System.Windows.Forms.TextBox
        Me.Lbl_FechaSuc = New System.Windows.Forms.Label
        Me.DTSucursal = New System.Windows.Forms.DateTimePicker
        Me.Txt_DescripSusSuc = New System.Windows.Forms.TextBox
        Me.Txt_VendedorSuc = New System.Windows.Forms.TextBox
        Me.Txt_SucursalSuc = New System.Windows.Forms.TextBox
        Me.Lbl_VenSuc = New System.Windows.Forms.Label
        Me.Lbl_SucSuc = New System.Windows.Forms.Label
        Me.Tbp_CambioBono = New System.Windows.Forms.TabPage
        Me.Tbp_CambioVend = New System.Windows.Forms.TabPage
        Me.Lbl_ComentariosVen = New System.Windows.Forms.Label
        Me.Txt_ComentariosVen = New System.Windows.Forms.TextBox
        Me.Lbl_FechaVen = New System.Windows.Forms.Label
        Me.DTVendedor = New System.Windows.Forms.DateTimePicker
        Me.Txt_DescripSucVen = New System.Windows.Forms.TextBox
        Me.Txt_VendedorVen = New System.Windows.Forms.TextBox
        Me.Txt_SucursalVen = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Lbl_SucursalVen = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Txt_Vendedor = New System.Windows.Forms.TextBox
        Me.Lbl_Vendedor = New System.Windows.Forms.Label
        Me.Lbl_FechaMov = New System.Windows.Forms.Label
        Me.Txt_FechaMov = New System.Windows.Forms.TextBox
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Lbl_SDiario = New System.Windows.Forms.Label
        Me.Txt_SDiario = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Txt_Ingreso = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txt_RFC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txt_NoIMSS = New System.Windows.Forms.TextBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.Txt_Clave = New System.Windows.Forms.TextBox
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_ClavePuesto = New System.Windows.Forms.TextBox
        Me.Txt_DescripPuesto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txt_ClaveDepto = New System.Windows.Forms.TextBox
        Me.Txt_DescripDepto = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Nombre = New System.Windows.Forms.TextBox
        Me.Txt_idempleado = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        Me.Tbc_Movimientos.SuspendLayout()
        Me.Tbp_Baja.SuspendLayout()
        Me.Tbp_Reingreso.SuspendLayout()
        Me.Tbp_CambioDep.SuspendLayout()
        Me.Tbp_CambioSuc.SuspendLayout()
        Me.Tbp_CambioVend.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.Tbc_Movimientos)
        Me.Pnl_Grid.Controls.Add(Me.Panel1)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(852, 395)
        Me.Pnl_Grid.TabIndex = 4
        '
        'Tbc_Movimientos
        '
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_Baja)
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_Sueldo)
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_Reingreso)
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_CambioDep)
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_CambioSuc)
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_CambioBono)
        Me.Tbc_Movimientos.Controls.Add(Me.Tbp_CambioVend)
        Me.Tbc_Movimientos.Location = New System.Drawing.Point(-2, 170)
        Me.Tbc_Movimientos.Name = "Tbc_Movimientos"
        Me.Tbc_Movimientos.SelectedIndex = 0
        Me.Tbc_Movimientos.Size = New System.Drawing.Size(852, 222)
        Me.Tbc_Movimientos.TabIndex = 4
        Me.Tbc_Movimientos.Visible = False
        '
        'Tbp_Baja
        '
        Me.Tbp_Baja.Controls.Add(Me.Label15)
        Me.Tbp_Baja.Controls.Add(Me.Label14)
        Me.Tbp_Baja.Controls.Add(Me.Label8)
        Me.Tbp_Baja.Controls.Add(Me.DTBaja)
        Me.Tbp_Baja.Controls.Add(Me.Cbo_MotivoBaja)
        Me.Tbp_Baja.Controls.Add(Me.Txt_ComentariosBaja)
        Me.Tbp_Baja.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_Baja.Name = "Tbp_Baja"
        Me.Tbp_Baja.Padding = New System.Windows.Forms.Padding(3)
        Me.Tbp_Baja.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_Baja.TabIndex = 0
        Me.Tbp_Baja.Text = "Baja"
        Me.Tbp_Baja.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 153
        Me.Label15.Text = "Comentarios"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 152
        Me.Label14.Text = "Motivo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "Fecha Baja"
        '
        'DTBaja
        '
        Me.DTBaja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTBaja.Location = New System.Drawing.Point(96, 13)
        Me.DTBaja.Name = "DTBaja"
        Me.DTBaja.Size = New System.Drawing.Size(247, 20)
        Me.DTBaja.TabIndex = 0
        '
        'Cbo_MotivoBaja
        '
        Me.Cbo_MotivoBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_MotivoBaja.FormattingEnabled = True
        Me.Cbo_MotivoBaja.Location = New System.Drawing.Point(96, 39)
        Me.Cbo_MotivoBaja.Name = "Cbo_MotivoBaja"
        Me.Cbo_MotivoBaja.Size = New System.Drawing.Size(247, 21)
        Me.Cbo_MotivoBaja.TabIndex = 1
        Me.Cbo_MotivoBaja.Text = "Seleccionar..."
        '
        'Txt_ComentariosBaja
        '
        Me.Txt_ComentariosBaja.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ComentariosBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ComentariosBaja.Location = New System.Drawing.Point(96, 66)
        Me.Txt_ComentariosBaja.MaxLength = 250
        Me.Txt_ComentariosBaja.Multiline = True
        Me.Txt_ComentariosBaja.Name = "Txt_ComentariosBaja"
        Me.Txt_ComentariosBaja.Size = New System.Drawing.Size(733, 87)
        Me.Txt_ComentariosBaja.TabIndex = 2
        '
        'Tbp_Sueldo
        '
        Me.Tbp_Sueldo.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_Sueldo.Name = "Tbp_Sueldo"
        Me.Tbp_Sueldo.Padding = New System.Windows.Forms.Padding(3)
        Me.Tbp_Sueldo.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_Sueldo.TabIndex = 1
        Me.Tbp_Sueldo.Text = "Sueldo"
        Me.Tbp_Sueldo.UseVisualStyleBackColor = True
        '
        'Tbp_Reingreso
        '
        Me.Tbp_Reingreso.Controls.Add(Me.Txt_PuestoReingreso)
        Me.Tbp_Reingreso.Controls.Add(Me.Txt_DescripPuestoR)
        Me.Tbp_Reingreso.Controls.Add(Me.Label9)
        Me.Tbp_Reingreso.Controls.Add(Me.Txt_DeptoReingreso)
        Me.Tbp_Reingreso.Controls.Add(Me.Txt_DescripDeptoR)
        Me.Tbp_Reingreso.Controls.Add(Me.Label10)
        Me.Tbp_Reingreso.Controls.Add(Me.Label1)
        Me.Tbp_Reingreso.Controls.Add(Me.DTReingreso)
        Me.Tbp_Reingreso.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_Reingreso.Name = "Tbp_Reingreso"
        Me.Tbp_Reingreso.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_Reingreso.TabIndex = 2
        Me.Tbp_Reingreso.Text = "Reingreso"
        Me.Tbp_Reingreso.UseVisualStyleBackColor = True
        '
        'Txt_PuestoReingreso
        '
        Me.Txt_PuestoReingreso.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_PuestoReingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PuestoReingreso.Location = New System.Drawing.Point(96, 74)
        Me.Txt_PuestoReingreso.MaxLength = 3
        Me.Txt_PuestoReingreso.Name = "Txt_PuestoReingreso"
        Me.Txt_PuestoReingreso.Size = New System.Drawing.Size(42, 20)
        Me.Txt_PuestoReingreso.TabIndex = 175
        '
        'Txt_DescripPuestoR
        '
        Me.Txt_DescripPuestoR.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPuestoR.Enabled = False
        Me.Txt_DescripPuestoR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPuestoR.Location = New System.Drawing.Point(151, 74)
        Me.Txt_DescripPuestoR.MaxLength = 30
        Me.Txt_DescripPuestoR.Name = "Txt_DescripPuestoR"
        Me.Txt_DescripPuestoR.ReadOnly = True
        Me.Txt_DescripPuestoR.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripPuestoR.TabIndex = 176
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 178
        Me.Label9.Text = "Puesto"
        '
        'Txt_DeptoReingreso
        '
        Me.Txt_DeptoReingreso.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DeptoReingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DeptoReingreso.Location = New System.Drawing.Point(95, 45)
        Me.Txt_DeptoReingreso.MaxLength = 3
        Me.Txt_DeptoReingreso.Name = "Txt_DeptoReingreso"
        Me.Txt_DeptoReingreso.Size = New System.Drawing.Size(42, 20)
        Me.Txt_DeptoReingreso.TabIndex = 173
        '
        'Txt_DescripDeptoR
        '
        Me.Txt_DescripDeptoR.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDeptoR.Enabled = False
        Me.Txt_DescripDeptoR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDeptoR.Location = New System.Drawing.Point(150, 45)
        Me.Txt_DescripDeptoR.MaxLength = 30
        Me.Txt_DescripDeptoR.Name = "Txt_DescripDeptoR"
        Me.Txt_DescripDeptoR.ReadOnly = True
        Me.Txt_DescripDeptoR.Size = New System.Drawing.Size(236, 20)
        Me.Txt_DescripDeptoR.TabIndex = 174
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 177
        Me.Label10.Text = "Departamento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Fecha Reingreso"
        '
        'DTReingreso
        '
        Me.DTReingreso.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTReingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTReingreso.Location = New System.Drawing.Point(96, 19)
        Me.DTReingreso.Name = "DTReingreso"
        Me.DTReingreso.Size = New System.Drawing.Size(291, 20)
        Me.DTReingreso.TabIndex = 171
        '
        'Tbp_CambioDep
        '
        Me.Tbp_CambioDep.Controls.Add(Me.Label16)
        Me.Tbp_CambioDep.Controls.Add(Me.Txt_ComentariosDep)
        Me.Tbp_CambioDep.Controls.Add(Me.Lbl_FechaDepPue)
        Me.Tbp_CambioDep.Controls.Add(Me.DTDeptoPuesto)
        Me.Tbp_CambioDep.Controls.Add(Me.Txt_ClavePuestoDep)
        Me.Tbp_CambioDep.Controls.Add(Me.Txt_DescripPuestoD)
        Me.Tbp_CambioDep.Controls.Add(Me.Lbl_PuestoDep)
        Me.Tbp_CambioDep.Controls.Add(Me.Txt_ClaveDeptoDep)
        Me.Tbp_CambioDep.Controls.Add(Me.Txt_DescripDeptoD)
        Me.Tbp_CambioDep.Controls.Add(Me.Lbl_DeptoDep)
        Me.Tbp_CambioDep.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_CambioDep.Name = "Tbp_CambioDep"
        Me.Tbp_CambioDep.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_CambioDep.TabIndex = 3
        Me.Tbp_CambioDep.Text = "Cambio Departamento y Puesto"
        Me.Tbp_CambioDep.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 172
        Me.Label16.Text = "Comentarios"
        '
        'Txt_ComentariosDep
        '
        Me.Txt_ComentariosDep.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ComentariosDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ComentariosDep.Location = New System.Drawing.Point(96, 99)
        Me.Txt_ComentariosDep.MaxLength = 250
        Me.Txt_ComentariosDep.Multiline = True
        Me.Txt_ComentariosDep.Name = "Txt_ComentariosDep"
        Me.Txt_ComentariosDep.Size = New System.Drawing.Size(733, 87)
        Me.Txt_ComentariosDep.TabIndex = 171
        '
        'Lbl_FechaDepPue
        '
        Me.Lbl_FechaDepPue.AutoSize = True
        Me.Lbl_FechaDepPue.Location = New System.Drawing.Point(7, 22)
        Me.Lbl_FechaDepPue.Name = "Lbl_FechaDepPue"
        Me.Lbl_FechaDepPue.Size = New System.Drawing.Size(78, 13)
        Me.Lbl_FechaDepPue.TabIndex = 170
        Me.Lbl_FechaDepPue.Text = "Fecha Cambio "
        '
        'DTDeptoPuesto
        '
        Me.DTDeptoPuesto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDeptoPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDeptoPuesto.Location = New System.Drawing.Point(96, 18)
        Me.DTDeptoPuesto.Name = "DTDeptoPuesto"
        Me.DTDeptoPuesto.Size = New System.Drawing.Size(291, 20)
        Me.DTDeptoPuesto.TabIndex = 169
        '
        'Txt_ClavePuestoDep
        '
        Me.Txt_ClavePuestoDep.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClavePuestoDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClavePuestoDep.Location = New System.Drawing.Point(97, 73)
        Me.Txt_ClavePuestoDep.MaxLength = 3
        Me.Txt_ClavePuestoDep.Name = "Txt_ClavePuestoDep"
        Me.Txt_ClavePuestoDep.Size = New System.Drawing.Size(42, 20)
        Me.Txt_ClavePuestoDep.TabIndex = 137
        '
        'Txt_DescripPuestoD
        '
        Me.Txt_DescripPuestoD.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPuestoD.Enabled = False
        Me.Txt_DescripPuestoD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPuestoD.Location = New System.Drawing.Point(152, 73)
        Me.Txt_DescripPuestoD.MaxLength = 30
        Me.Txt_DescripPuestoD.Name = "Txt_DescripPuestoD"
        Me.Txt_DescripPuestoD.ReadOnly = True
        Me.Txt_DescripPuestoD.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripPuestoD.TabIndex = 138
        '
        'Lbl_PuestoDep
        '
        Me.Lbl_PuestoDep.AutoSize = True
        Me.Lbl_PuestoDep.Location = New System.Drawing.Point(8, 76)
        Me.Lbl_PuestoDep.Name = "Lbl_PuestoDep"
        Me.Lbl_PuestoDep.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_PuestoDep.TabIndex = 140
        Me.Lbl_PuestoDep.Text = "Puesto"
        '
        'Txt_ClaveDeptoDep
        '
        Me.Txt_ClaveDeptoDep.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClaveDeptoDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClaveDeptoDep.Location = New System.Drawing.Point(96, 44)
        Me.Txt_ClaveDeptoDep.MaxLength = 3
        Me.Txt_ClaveDeptoDep.Name = "Txt_ClaveDeptoDep"
        Me.Txt_ClaveDeptoDep.Size = New System.Drawing.Size(42, 20)
        Me.Txt_ClaveDeptoDep.TabIndex = 135
        '
        'Txt_DescripDeptoD
        '
        Me.Txt_DescripDeptoD.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDeptoD.Enabled = False
        Me.Txt_DescripDeptoD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDeptoD.Location = New System.Drawing.Point(151, 44)
        Me.Txt_DescripDeptoD.MaxLength = 30
        Me.Txt_DescripDeptoD.Name = "Txt_DescripDeptoD"
        Me.Txt_DescripDeptoD.ReadOnly = True
        Me.Txt_DescripDeptoD.Size = New System.Drawing.Size(236, 20)
        Me.Txt_DescripDeptoD.TabIndex = 136
        '
        'Lbl_DeptoDep
        '
        Me.Lbl_DeptoDep.AutoSize = True
        Me.Lbl_DeptoDep.Location = New System.Drawing.Point(7, 48)
        Me.Lbl_DeptoDep.Name = "Lbl_DeptoDep"
        Me.Lbl_DeptoDep.Size = New System.Drawing.Size(74, 13)
        Me.Lbl_DeptoDep.TabIndex = 139
        Me.Lbl_DeptoDep.Text = "Departamento"
        '
        'Tbp_CambioSuc
        '
        Me.Tbp_CambioSuc.Controls.Add(Me.Lbl_ComentariosSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.Txt_ComentariosSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.Lbl_FechaSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.DTSucursal)
        Me.Tbp_CambioSuc.Controls.Add(Me.Txt_DescripSusSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.Txt_VendedorSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.Txt_SucursalSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.Lbl_VenSuc)
        Me.Tbp_CambioSuc.Controls.Add(Me.Lbl_SucSuc)
        Me.Tbp_CambioSuc.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_CambioSuc.Name = "Tbp_CambioSuc"
        Me.Tbp_CambioSuc.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_CambioSuc.TabIndex = 4
        Me.Tbp_CambioSuc.Text = "Cambio Sucursal"
        Me.Tbp_CambioSuc.UseVisualStyleBackColor = True
        '
        'Lbl_ComentariosSuc
        '
        Me.Lbl_ComentariosSuc.AutoSize = True
        Me.Lbl_ComentariosSuc.Location = New System.Drawing.Point(7, 96)
        Me.Lbl_ComentariosSuc.Name = "Lbl_ComentariosSuc"
        Me.Lbl_ComentariosSuc.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_ComentariosSuc.TabIndex = 170
        Me.Lbl_ComentariosSuc.Text = "Comentarios"
        '
        'Txt_ComentariosSuc
        '
        Me.Txt_ComentariosSuc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ComentariosSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ComentariosSuc.Location = New System.Drawing.Point(96, 93)
        Me.Txt_ComentariosSuc.MaxLength = 250
        Me.Txt_ComentariosSuc.Multiline = True
        Me.Txt_ComentariosSuc.Name = "Txt_ComentariosSuc"
        Me.Txt_ComentariosSuc.Size = New System.Drawing.Size(727, 87)
        Me.Txt_ComentariosSuc.TabIndex = 3
        '
        'Lbl_FechaSuc
        '
        Me.Lbl_FechaSuc.AutoSize = True
        Me.Lbl_FechaSuc.Location = New System.Drawing.Point(7, 19)
        Me.Lbl_FechaSuc.Name = "Lbl_FechaSuc"
        Me.Lbl_FechaSuc.Size = New System.Drawing.Size(78, 13)
        Me.Lbl_FechaSuc.TabIndex = 168
        Me.Lbl_FechaSuc.Text = "Fecha Cambio "
        '
        'DTSucursal
        '
        Me.DTSucursal.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTSucursal.Location = New System.Drawing.Point(96, 15)
        Me.DTSucursal.Name = "DTSucursal"
        Me.DTSucursal.Size = New System.Drawing.Size(290, 20)
        Me.DTSucursal.TabIndex = 0
        '
        'Txt_DescripSusSuc
        '
        Me.Txt_DescripSusSuc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSusSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSusSuc.Location = New System.Drawing.Point(151, 41)
        Me.Txt_DescripSusSuc.MaxLength = 30
        Me.Txt_DescripSusSuc.Name = "Txt_DescripSusSuc"
        Me.Txt_DescripSusSuc.ReadOnly = True
        Me.Txt_DescripSusSuc.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripSusSuc.TabIndex = 166
        '
        'Txt_VendedorSuc
        '
        Me.Txt_VendedorSuc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_VendedorSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_VendedorSuc.Location = New System.Drawing.Point(96, 67)
        Me.Txt_VendedorSuc.MaxLength = 2
        Me.Txt_VendedorSuc.Name = "Txt_VendedorSuc"
        Me.Txt_VendedorSuc.Size = New System.Drawing.Size(42, 20)
        Me.Txt_VendedorSuc.TabIndex = 2
        '
        'Txt_SucursalSuc
        '
        Me.Txt_SucursalSuc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_SucursalSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SucursalSuc.Location = New System.Drawing.Point(96, 41)
        Me.Txt_SucursalSuc.MaxLength = 2
        Me.Txt_SucursalSuc.Name = "Txt_SucursalSuc"
        Me.Txt_SucursalSuc.Size = New System.Drawing.Size(42, 20)
        Me.Txt_SucursalSuc.TabIndex = 1
        '
        'Lbl_VenSuc
        '
        Me.Lbl_VenSuc.AutoSize = True
        Me.Lbl_VenSuc.Location = New System.Drawing.Point(7, 70)
        Me.Lbl_VenSuc.Name = "Lbl_VenSuc"
        Me.Lbl_VenSuc.Size = New System.Drawing.Size(53, 13)
        Me.Lbl_VenSuc.TabIndex = 164
        Me.Lbl_VenSuc.Text = "Vendedor"
        '
        'Lbl_SucSuc
        '
        Me.Lbl_SucSuc.AutoSize = True
        Me.Lbl_SucSuc.Location = New System.Drawing.Point(7, 44)
        Me.Lbl_SucSuc.Name = "Lbl_SucSuc"
        Me.Lbl_SucSuc.Size = New System.Drawing.Size(83, 13)
        Me.Lbl_SucSuc.TabIndex = 163
        Me.Lbl_SucSuc.Text = "Sucursal Nueva"
        '
        'Tbp_CambioBono
        '
        Me.Tbp_CambioBono.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_CambioBono.Name = "Tbp_CambioBono"
        Me.Tbp_CambioBono.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_CambioBono.TabIndex = 5
        Me.Tbp_CambioBono.Text = "Cambio Bono Fijo"
        Me.Tbp_CambioBono.UseVisualStyleBackColor = True
        '
        'Tbp_CambioVend
        '
        Me.Tbp_CambioVend.Controls.Add(Me.Lbl_ComentariosVen)
        Me.Tbp_CambioVend.Controls.Add(Me.Txt_ComentariosVen)
        Me.Tbp_CambioVend.Controls.Add(Me.Lbl_FechaVen)
        Me.Tbp_CambioVend.Controls.Add(Me.DTVendedor)
        Me.Tbp_CambioVend.Controls.Add(Me.Txt_DescripSucVen)
        Me.Tbp_CambioVend.Controls.Add(Me.Txt_VendedorVen)
        Me.Tbp_CambioVend.Controls.Add(Me.Txt_SucursalVen)
        Me.Tbp_CambioVend.Controls.Add(Me.Label7)
        Me.Tbp_CambioVend.Controls.Add(Me.Lbl_SucursalVen)
        Me.Tbp_CambioVend.Location = New System.Drawing.Point(4, 22)
        Me.Tbp_CambioVend.Name = "Tbp_CambioVend"
        Me.Tbp_CambioVend.Size = New System.Drawing.Size(844, 196)
        Me.Tbp_CambioVend.TabIndex = 6
        Me.Tbp_CambioVend.Text = "Cambio Vendedor"
        Me.Tbp_CambioVend.UseVisualStyleBackColor = True
        '
        'Lbl_ComentariosVen
        '
        Me.Lbl_ComentariosVen.AutoSize = True
        Me.Lbl_ComentariosVen.Location = New System.Drawing.Point(7, 94)
        Me.Lbl_ComentariosVen.Name = "Lbl_ComentariosVen"
        Me.Lbl_ComentariosVen.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_ComentariosVen.TabIndex = 161
        Me.Lbl_ComentariosVen.Text = "Comentarios"
        '
        'Txt_ComentariosVen
        '
        Me.Txt_ComentariosVen.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ComentariosVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ComentariosVen.Location = New System.Drawing.Point(96, 91)
        Me.Txt_ComentariosVen.MaxLength = 250
        Me.Txt_ComentariosVen.Multiline = True
        Me.Txt_ComentariosVen.Name = "Txt_ComentariosVen"
        Me.Txt_ComentariosVen.Size = New System.Drawing.Size(733, 87)
        Me.Txt_ComentariosVen.TabIndex = 3
        '
        'Lbl_FechaVen
        '
        Me.Lbl_FechaVen.AutoSize = True
        Me.Lbl_FechaVen.Location = New System.Drawing.Point(7, 17)
        Me.Lbl_FechaVen.Name = "Lbl_FechaVen"
        Me.Lbl_FechaVen.Size = New System.Drawing.Size(78, 13)
        Me.Lbl_FechaVen.TabIndex = 159
        Me.Lbl_FechaVen.Text = "Fecha Cambio "
        '
        'DTVendedor
        '
        Me.DTVendedor.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTVendedor.Location = New System.Drawing.Point(96, 13)
        Me.DTVendedor.Name = "DTVendedor"
        Me.DTVendedor.Size = New System.Drawing.Size(290, 20)
        Me.DTVendedor.TabIndex = 0
        '
        'Txt_DescripSucVen
        '
        Me.Txt_DescripSucVen.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucVen.Location = New System.Drawing.Point(151, 39)
        Me.Txt_DescripSucVen.MaxLength = 30
        Me.Txt_DescripSucVen.Name = "Txt_DescripSucVen"
        Me.Txt_DescripSucVen.ReadOnly = True
        Me.Txt_DescripSucVen.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripSucVen.TabIndex = 157
        '
        'Txt_VendedorVen
        '
        Me.Txt_VendedorVen.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_VendedorVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_VendedorVen.Location = New System.Drawing.Point(96, 65)
        Me.Txt_VendedorVen.MaxLength = 2
        Me.Txt_VendedorVen.Name = "Txt_VendedorVen"
        Me.Txt_VendedorVen.Size = New System.Drawing.Size(42, 20)
        Me.Txt_VendedorVen.TabIndex = 2
        '
        'Txt_SucursalVen
        '
        Me.Txt_SucursalVen.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_SucursalVen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SucursalVen.Location = New System.Drawing.Point(96, 39)
        Me.Txt_SucursalVen.MaxLength = 2
        Me.Txt_SucursalVen.Name = "Txt_SucursalVen"
        Me.Txt_SucursalVen.Size = New System.Drawing.Size(42, 20)
        Me.Txt_SucursalVen.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 155
        Me.Label7.Text = "Vendedor Nuevo"
        '
        'Lbl_SucursalVen
        '
        Me.Lbl_SucursalVen.AutoSize = True
        Me.Lbl_SucursalVen.Location = New System.Drawing.Point(7, 42)
        Me.Lbl_SucursalVen.Name = "Lbl_SucursalVen"
        Me.Lbl_SucursalVen.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_SucursalVen.TabIndex = 154
        Me.Lbl_SucursalVen.Text = "Sucursal"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Txt_Vendedor)
        Me.Panel1.Controls.Add(Me.Lbl_Vendedor)
        Me.Panel1.Controls.Add(Me.Lbl_FechaMov)
        Me.Panel1.Controls.Add(Me.Txt_FechaMov)
        Me.Panel1.Controls.Add(Me.PBox)
        Me.Panel1.Controls.Add(Me.Lbl_SDiario)
        Me.Panel1.Controls.Add(Me.Txt_SDiario)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Txt_Ingreso)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Txt_RFC)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Txt_NoIMSS)
        Me.Panel1.Controls.Add(Me.Label47)
        Me.Panel1.Controls.Add(Me.Txt_Clave)
        Me.Panel1.Controls.Add(Me.Txt_Sucursal)
        Me.Panel1.Controls.Add(Me.Txt_DescripSucursal)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Txt_ClavePuesto)
        Me.Panel1.Controls.Add(Me.Txt_DescripPuesto)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Txt_ClaveDepto)
        Me.Panel1.Controls.Add(Me.Txt_DescripDepto)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Txt_Nombre)
        Me.Panel1.Controls.Add(Me.Txt_idempleado)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(846, 167)
        Me.Panel1.TabIndex = 3
        '
        'Txt_Vendedor
        '
        Me.Txt_Vendedor.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Vendedor.Enabled = False
        Me.Txt_Vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vendedor.Location = New System.Drawing.Point(94, 135)
        Me.Txt_Vendedor.MaxLength = 3
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Vendedor.TabIndex = 155
        '
        'Lbl_Vendedor
        '
        Me.Lbl_Vendedor.AutoSize = True
        Me.Lbl_Vendedor.Location = New System.Drawing.Point(5, 138)
        Me.Lbl_Vendedor.Name = "Lbl_Vendedor"
        Me.Lbl_Vendedor.Size = New System.Drawing.Size(53, 13)
        Me.Lbl_Vendedor.TabIndex = 154
        Me.Lbl_Vendedor.Text = "Vendedor"
        '
        'Lbl_FechaMov
        '
        Me.Lbl_FechaMov.AutoSize = True
        Me.Lbl_FechaMov.Location = New System.Drawing.Point(409, 112)
        Me.Lbl_FechaMov.Name = "Lbl_FechaMov"
        Me.Lbl_FechaMov.Size = New System.Drawing.Size(61, 13)
        Me.Lbl_FechaMov.TabIndex = 153
        Me.Lbl_FechaMov.Text = "Fecha Mov"
        Me.Lbl_FechaMov.Visible = False
        '
        'Txt_FechaMov
        '
        Me.Txt_FechaMov.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_FechaMov.Enabled = False
        Me.Txt_FechaMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_FechaMov.Location = New System.Drawing.Point(495, 109)
        Me.Txt_FechaMov.MaxLength = 30
        Me.Txt_FechaMov.Name = "Txt_FechaMov"
        Me.Txt_FechaMov.ReadOnly = True
        Me.Txt_FechaMov.Size = New System.Drawing.Size(165, 20)
        Me.Txt_FechaMov.TabIndex = 152
        Me.Txt_FechaMov.Visible = False
        '
        'PBox
        '
        Me.PBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBox.Location = New System.Drawing.Point(666, 7)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(175, 154)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 151
        Me.PBox.TabStop = False
        '
        'Lbl_SDiario
        '
        Me.Lbl_SDiario.AutoSize = True
        Me.Lbl_SDiario.Location = New System.Drawing.Point(409, 87)
        Me.Lbl_SDiario.Name = "Lbl_SDiario"
        Me.Lbl_SDiario.Size = New System.Drawing.Size(69, 13)
        Me.Lbl_SDiario.TabIndex = 150
        Me.Lbl_SDiario.Text = "Salario Diario"
        '
        'Txt_SDiario
        '
        Me.Txt_SDiario.BackColor = System.Drawing.Color.White
        Me.Txt_SDiario.Enabled = False
        Me.Txt_SDiario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SDiario.Location = New System.Drawing.Point(495, 83)
        Me.Txt_SDiario.MaxLength = 30
        Me.Txt_SDiario.Name = "Txt_SDiario"
        Me.Txt_SDiario.ReadOnly = True
        Me.Txt_SDiario.Size = New System.Drawing.Size(83, 20)
        Me.Txt_SDiario.TabIndex = 149
        Me.Txt_SDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(409, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 148
        Me.Label13.Text = "Fecha Ingreso"
        '
        'Txt_Ingreso
        '
        Me.Txt_Ingreso.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Ingreso.Enabled = False
        Me.Txt_Ingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ingreso.Location = New System.Drawing.Point(495, 59)
        Me.Txt_Ingreso.MaxLength = 30
        Me.Txt_Ingreso.Name = "Txt_Ingreso"
        Me.Txt_Ingreso.ReadOnly = True
        Me.Txt_Ingreso.Size = New System.Drawing.Size(165, 20)
        Me.Txt_Ingreso.TabIndex = 147
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(409, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 146
        Me.Label12.Text = "RFC"
        '
        'Txt_RFC
        '
        Me.Txt_RFC.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_RFC.Enabled = False
        Me.Txt_RFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFC.Location = New System.Drawing.Point(495, 7)
        Me.Txt_RFC.MaxLength = 30
        Me.Txt_RFC.Name = "Txt_RFC"
        Me.Txt_RFC.ReadOnly = True
        Me.Txt_RFC.Size = New System.Drawing.Size(165, 20)
        Me.Txt_RFC.TabIndex = 145
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(409, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "IMSS"
        '
        'Txt_NoIMSS
        '
        Me.Txt_NoIMSS.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NoIMSS.Enabled = False
        Me.Txt_NoIMSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoIMSS.Location = New System.Drawing.Point(495, 33)
        Me.Txt_NoIMSS.MaxLength = 30
        Me.Txt_NoIMSS.Name = "Txt_NoIMSS"
        Me.Txt_NoIMSS.ReadOnly = True
        Me.Txt_NoIMSS.Size = New System.Drawing.Size(165, 20)
        Me.Txt_NoIMSS.TabIndex = 143
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(265, 11)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(34, 13)
        Me.Label47.TabIndex = 136
        Me.Label47.Text = "Clave"
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Clave.Enabled = False
        Me.Txt_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Clave.Location = New System.Drawing.Point(306, 7)
        Me.Txt_Clave.MaxLength = 30
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.ReadOnly = True
        Me.Txt_Clave.Size = New System.Drawing.Size(78, 20)
        Me.Txt_Clave.TabIndex = 120
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.Enabled = False
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(94, 59)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Sucursal.TabIndex = 123
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(149, 59)
        Me.Txt_DescripSucursal.MaxLength = 30
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripSucursal.TabIndex = 124
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Sucursal"
        '
        'Txt_ClavePuesto
        '
        Me.Txt_ClavePuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClavePuesto.Enabled = False
        Me.Txt_ClavePuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClavePuesto.Location = New System.Drawing.Point(94, 109)
        Me.Txt_ClavePuesto.MaxLength = 3
        Me.Txt_ClavePuesto.Name = "Txt_ClavePuesto"
        Me.Txt_ClavePuesto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_ClavePuesto.TabIndex = 127
        '
        'Txt_DescripPuesto
        '
        Me.Txt_DescripPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPuesto.Enabled = False
        Me.Txt_DescripPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPuesto.Location = New System.Drawing.Point(149, 109)
        Me.Txt_DescripPuesto.MaxLength = 30
        Me.Txt_DescripPuesto.Name = "Txt_DescripPuesto"
        Me.Txt_DescripPuesto.ReadOnly = True
        Me.Txt_DescripPuesto.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripPuesto.TabIndex = 128
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Puesto"
        '
        'Txt_ClaveDepto
        '
        Me.Txt_ClaveDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClaveDepto.Enabled = False
        Me.Txt_ClaveDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClaveDepto.Location = New System.Drawing.Point(94, 83)
        Me.Txt_ClaveDepto.MaxLength = 3
        Me.Txt_ClaveDepto.Name = "Txt_ClaveDepto"
        Me.Txt_ClaveDepto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_ClaveDepto.TabIndex = 125
        '
        'Txt_DescripDepto
        '
        Me.Txt_DescripDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDepto.Enabled = False
        Me.Txt_DescripDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDepto.Location = New System.Drawing.Point(149, 83)
        Me.Txt_DescripDepto.MaxLength = 30
        Me.Txt_DescripDepto.Name = "Txt_DescripDepto"
        Me.Txt_DescripDepto.ReadOnly = True
        Me.Txt_DescripDepto.Size = New System.Drawing.Size(235, 20)
        Me.Txt_DescripDepto.TabIndex = 126
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Departamento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Nombre(s)"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Nombre.Enabled = False
        Me.Txt_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nombre.Location = New System.Drawing.Point(94, 33)
        Me.Txt_Nombre.MaxLength = 30
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Size = New System.Drawing.Size(290, 20)
        Me.Txt_Nombre.TabIndex = 118
        '
        'Txt_idempleado
        '
        Me.Txt_idempleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_idempleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_idempleado.Location = New System.Drawing.Point(94, 2)
        Me.Txt_idempleado.MaxLength = 4
        Me.Txt_idempleado.Name = "Txt_idempleado"
        Me.Txt_idempleado.Size = New System.Drawing.Size(101, 26)
        Me.Txt_idempleado.TabIndex = 119
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "IdEmpleado"
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProveedorToolStripMenuItem, Me.ModificarProveedorToolStripMenuItem, Me.ConsultarProveedorToolStripMenuItem})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(183, 70)
        '
        'NuevoProveedorToolStripMenuItem
        '
        Me.NuevoProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProveedorToolStripMenuItem.Name = "NuevoProveedorToolStripMenuItem"
        Me.NuevoProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.NuevoProveedorToolStripMenuItem.Text = "Nuevo Proveedor"
        '
        'ModificarProveedorToolStripMenuItem
        '
        Me.ModificarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarProveedorToolStripMenuItem.Name = "ModificarProveedorToolStripMenuItem"
        Me.ModificarProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ModificarProveedorToolStripMenuItem.Text = "Modificar Proveedor"
        '
        'ConsultarProveedorToolStripMenuItem
        '
        Me.ConsultarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarProveedorToolStripMenuItem.Name = "ConsultarProveedorToolStripMenuItem"
        Me.ConsultarProveedorToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ConsultarProveedorToolStripMenuItem.Text = "Consultar Proveedor"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 395)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(852, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Nuevo.TabIndex = 140
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        Me.Btn_Nuevo.Visible = False
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(746, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 139
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(797, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(51, -2)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Editar.TabIndex = 1
        Me.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Editar.UseVisualStyleBackColor = True
        Me.Btn_Editar.Visible = False
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmCatalogoMovEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 451)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoMovEmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Movimientos de Empleados"
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Tbc_Movimientos.ResumeLayout(False)
        Me.Tbp_Baja.ResumeLayout(False)
        Me.Tbp_Baja.PerformLayout()
        Me.Tbp_Reingreso.ResumeLayout(False)
        Me.Tbp_Reingreso.PerformLayout()
        Me.Tbp_CambioDep.ResumeLayout(False)
        Me.Tbp_CambioDep.PerformLayout()
        Me.Tbp_CambioSuc.ResumeLayout(False)
        Me.Tbp_CambioSuc.PerformLayout()
        Me.Tbp_CambioVend.ResumeLayout(False)
        Me.Tbp_CambioVend.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Txt_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_ClavePuesto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_ClaveDepto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDepto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Txt_idempleado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_RFC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_NoIMSS As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_SDiario As System.Windows.Forms.Label
    Friend WithEvents Txt_SDiario As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ingreso As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Tbc_Movimientos As System.Windows.Forms.TabControl
    Friend WithEvents Tbp_Baja As System.Windows.Forms.TabPage
    Friend WithEvents Tbp_Sueldo As System.Windows.Forms.TabPage
    Friend WithEvents Txt_ComentariosBaja As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_MotivoBaja As System.Windows.Forms.ComboBox
    Friend WithEvents DTBaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tbp_Reingreso As System.Windows.Forms.TabPage
    Friend WithEvents Tbp_CambioDep As System.Windows.Forms.TabPage
    Friend WithEvents Tbp_CambioSuc As System.Windows.Forms.TabPage
    Friend WithEvents Tbp_CambioBono As System.Windows.Forms.TabPage
    Friend WithEvents Tbp_CambioVend As System.Windows.Forms.TabPage
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Lbl_FechaMov As System.Windows.Forms.Label
    Friend WithEvents Txt_FechaMov As System.Windows.Forms.TextBox
    Friend WithEvents Txt_VendedorVen As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SucursalVen As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Lbl_SucursalVen As System.Windows.Forms.Label
    Friend WithEvents Lbl_ComentariosVen As System.Windows.Forms.Label
    Friend WithEvents Txt_ComentariosVen As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_FechaVen As System.Windows.Forms.Label
    Friend WithEvents DTVendedor As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_DescripSucVen As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Vendedor As System.Windows.Forms.Label
    Friend WithEvents Lbl_ComentariosSuc As System.Windows.Forms.Label
    Friend WithEvents Txt_ComentariosSuc As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_FechaSuc As System.Windows.Forms.Label
    Friend WithEvents DTSucursal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_DescripSusSuc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_VendedorSuc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SucursalSuc As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_VenSuc As System.Windows.Forms.Label
    Friend WithEvents Lbl_SucSuc As System.Windows.Forms.Label
    Friend WithEvents Lbl_FechaDepPue As System.Windows.Forms.Label
    Friend WithEvents DTDeptoPuesto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_ClavePuestoDep As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripPuestoD As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_PuestoDep As System.Windows.Forms.Label
    Friend WithEvents Txt_ClaveDeptoDep As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDeptoD As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_DeptoDep As System.Windows.Forms.Label
    Friend WithEvents Txt_PuestoReingreso As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripPuestoR As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_DeptoReingreso As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDeptoR As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTReingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_ComentariosDep As System.Windows.Forms.TextBox
End Class
