<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoCajaCalzado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoCajaCalzado))
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Txt_Porc = New System.Windows.Forms.TextBox
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PBoxNuevo = New System.Windows.Forms.PictureBox
        Me.Txt_CorridaNuevo = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Txt_MedidaNuevo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txt_ModeloNuevo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txt_DescripMarcaNuevo = New System.Windows.Forms.TextBox
        Me.Txt_MarcaNuevo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Pnl_Anterior = New System.Windows.Forms.Panel
        Me.Txt_SucursalOri = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Txt_SucursalAct = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Cbo_Motivo = New System.Windows.Forms.ComboBox
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.PBoxAnterior = New System.Windows.Forms.PictureBox
        Me.Txt_Corrida = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Txt_IdFolioSuc = New System.Windows.Forms.TextBox
        Me.Txt_FechaRecibo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox
        Me.Txt_Medida = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txt_Modelo = New System.Windows.Forms.TextBox
        Me.Txt_Marca = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Serie = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Id_SegBit = New System.Windows.Forms.TextBox
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PBoxNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Anterior.SuspendLayout()
        CType(Me.PBoxAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 389)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(619, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(462, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Limpiar.TabIndex = 6
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(513, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 5
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(564, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 4
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Aceptar, "Registrar Caja Calzado")
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Txt_Porc
        '
        Me.Txt_Porc.Enabled = False
        Me.Txt_Porc.Location = New System.Drawing.Point(163, 32)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Porc.TabIndex = 86
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(3, 3)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(439, 23)
        Me.PBar.TabIndex = 85
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Panel1)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Anterior)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Id_SegBit)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(614, 380)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PBoxNuevo)
        Me.Panel1.Controls.Add(Me.Txt_CorridaNuevo)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Txt_MedidaNuevo)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Txt_ModeloNuevo)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Txt_DescripMarcaNuevo)
        Me.Panel1.Controls.Add(Me.Txt_MarcaNuevo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(3, 234)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 139)
        Me.Panel1.TabIndex = 84
        '
        'PBoxNuevo
        '
        Me.PBoxNuevo.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBoxNuevo.InitialImage = Nothing
        Me.PBoxNuevo.Location = New System.Drawing.Point(464, 3)
        Me.PBoxNuevo.Name = "PBoxNuevo"
        Me.PBoxNuevo.Size = New System.Drawing.Size(109, 120)
        Me.PBoxNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBoxNuevo.TabIndex = 17
        Me.PBoxNuevo.TabStop = False
        '
        'Txt_CorridaNuevo
        '
        Me.Txt_CorridaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CorridaNuevo.Location = New System.Drawing.Point(64, 85)
        Me.Txt_CorridaNuevo.MaxLength = 1
        Me.Txt_CorridaNuevo.Name = "Txt_CorridaNuevo"
        Me.Txt_CorridaNuevo.Size = New System.Drawing.Size(48, 20)
        Me.Txt_CorridaNuevo.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Corrida"
        '
        'Txt_MedidaNuevo
        '
        Me.Txt_MedidaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MedidaNuevo.Location = New System.Drawing.Point(64, 110)
        Me.Txt_MedidaNuevo.MaxLength = 3
        Me.Txt_MedidaNuevo.Name = "Txt_MedidaNuevo"
        Me.Txt_MedidaNuevo.Size = New System.Drawing.Size(48, 20)
        Me.Txt_MedidaNuevo.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Medida"
        '
        'Txt_ModeloNuevo
        '
        Me.Txt_ModeloNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ModeloNuevo.Location = New System.Drawing.Point(64, 59)
        Me.Txt_ModeloNuevo.MaxLength = 7
        Me.Txt_ModeloNuevo.Name = "Txt_ModeloNuevo"
        Me.Txt_ModeloNuevo.Size = New System.Drawing.Size(48, 20)
        Me.Txt_ModeloNuevo.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Modelo"
        '
        'Txt_DescripMarcaNuevo
        '
        Me.Txt_DescripMarcaNuevo.Enabled = False
        Me.Txt_DescripMarcaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarcaNuevo.Location = New System.Drawing.Point(118, 33)
        Me.Txt_DescripMarcaNuevo.Name = "Txt_DescripMarcaNuevo"
        Me.Txt_DescripMarcaNuevo.Size = New System.Drawing.Size(122, 20)
        Me.Txt_DescripMarcaNuevo.TabIndex = 11
        '
        'Txt_MarcaNuevo
        '
        Me.Txt_MarcaNuevo.Enabled = False
        Me.Txt_MarcaNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MarcaNuevo.Location = New System.Drawing.Point(64, 33)
        Me.Txt_MarcaNuevo.Name = "Txt_MarcaNuevo"
        Me.Txt_MarcaNuevo.Size = New System.Drawing.Size(48, 20)
        Me.Txt_MarcaNuevo.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Marca"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Datos Nuevos"
        '
        'Pnl_Anterior
        '
        Me.Pnl_Anterior.Controls.Add(Me.Txt_SucursalOri)
        Me.Pnl_Anterior.Controls.Add(Me.Label18)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_SucursalAct)
        Me.Pnl_Anterior.Controls.Add(Me.Label17)
        Me.Pnl_Anterior.Controls.Add(Me.Label16)
        Me.Pnl_Anterior.Controls.Add(Me.Cbo_Motivo)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_Proveedor)
        Me.Pnl_Anterior.Controls.Add(Me.Label15)
        Me.Pnl_Anterior.Controls.Add(Me.PBoxAnterior)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_Corrida)
        Me.Pnl_Anterior.Controls.Add(Me.Label13)
        Me.Pnl_Anterior.Controls.Add(Me.Label10)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_IdFolioSuc)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_FechaRecibo)
        Me.Pnl_Anterior.Controls.Add(Me.Label7)
        Me.Pnl_Anterior.Controls.Add(Me.Label6)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_Medida)
        Me.Pnl_Anterior.Controls.Add(Me.Label5)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_Modelo)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Anterior.Controls.Add(Me.Label4)
        Me.Pnl_Anterior.Controls.Add(Me.Label3)
        Me.Pnl_Anterior.Controls.Add(Me.Txt_Serie)
        Me.Pnl_Anterior.Controls.Add(Me.Label2)
        Me.Pnl_Anterior.Location = New System.Drawing.Point(3, 7)
        Me.Pnl_Anterior.Name = "Pnl_Anterior"
        Me.Pnl_Anterior.Size = New System.Drawing.Size(604, 206)
        Me.Pnl_Anterior.TabIndex = 83
        '
        'Txt_SucursalOri
        '
        Me.Txt_SucursalOri.BackColor = System.Drawing.Color.White
        Me.Txt_SucursalOri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SucursalOri.Location = New System.Drawing.Point(348, 183)
        Me.Txt_SucursalOri.Name = "Txt_SucursalOri"
        Me.Txt_SucursalOri.ReadOnly = True
        Me.Txt_SucursalOri.Size = New System.Drawing.Size(116, 20)
        Me.Txt_SucursalOri.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(274, 186)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Det. Original"
        '
        'Txt_SucursalAct
        '
        Me.Txt_SucursalAct.BackColor = System.Drawing.Color.White
        Me.Txt_SucursalAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SucursalAct.Location = New System.Drawing.Point(348, 160)
        Me.Txt_SucursalAct.Name = "Txt_SucursalAct"
        Me.Txt_SucursalAct.ReadOnly = True
        Me.Txt_SucursalAct.Size = New System.Drawing.Size(116, 20)
        Me.Txt_SucursalAct.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(274, 163)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Det. Actual"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Motivo"
        '
        'Cbo_Motivo
        '
        Me.Cbo_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Motivo.FormattingEnabled = True
        Me.Cbo_Motivo.Items.AddRange(New Object() {"ERROR DE RECIBO", "LLEGO DE PROVEEDOR", "SE DETECTO EN INVENTARIO", "SE DETECTO EN PRE-INVENTARIO DE TDA", "SE GENERO EN PROCESO DE VENTA", "SE GENERO EN TRASPASO"})
        Me.Cbo_Motivo.Location = New System.Drawing.Point(65, 45)
        Me.Cbo_Motivo.Name = "Cbo_Motivo"
        Me.Cbo_Motivo.Size = New System.Drawing.Size(285, 21)
        Me.Cbo_Motivo.TabIndex = 1
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.Color.White
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(348, 134)
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(116, 20)
        Me.Txt_Proveedor.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(274, 137)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "No. Proveedor"
        '
        'PBoxAnterior
        '
        Me.PBoxAnterior.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBoxAnterior.InitialImage = Nothing
        Me.PBoxAnterior.Location = New System.Drawing.Point(470, 17)
        Me.PBoxAnterior.Name = "PBoxAnterior"
        Me.PBoxAnterior.Size = New System.Drawing.Size(109, 120)
        Me.PBoxAnterior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBoxAnterior.TabIndex = 18
        Me.PBoxAnterior.TabStop = False
        '
        'Txt_Corrida
        '
        Me.Txt_Corrida.BackColor = System.Drawing.Color.White
        Me.Txt_Corrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Corrida.Location = New System.Drawing.Point(65, 130)
        Me.Txt_Corrida.Name = "Txt_Corrida"
        Me.Txt_Corrida.ReadOnly = True
        Me.Txt_Corrida.Size = New System.Drawing.Size(48, 20)
        Me.Txt_Corrida.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Corrida"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Datos Anteriores"
        '
        'Txt_IdFolioSuc
        '
        Me.Txt_IdFolioSuc.BackColor = System.Drawing.Color.White
        Me.Txt_IdFolioSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFolioSuc.Location = New System.Drawing.Point(348, 108)
        Me.Txt_IdFolioSuc.Name = "Txt_IdFolioSuc"
        Me.Txt_IdFolioSuc.ReadOnly = True
        Me.Txt_IdFolioSuc.Size = New System.Drawing.Size(116, 20)
        Me.Txt_IdFolioSuc.TabIndex = 12
        '
        'Txt_FechaRecibo
        '
        Me.Txt_FechaRecibo.BackColor = System.Drawing.Color.White
        Me.Txt_FechaRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_FechaRecibo.Location = New System.Drawing.Point(348, 82)
        Me.Txt_FechaRecibo.Name = "Txt_FechaRecibo"
        Me.Txt_FechaRecibo.ReadOnly = True
        Me.Txt_FechaRecibo.Size = New System.Drawing.Size(116, 20)
        Me.Txt_FechaRecibo.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(274, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Folio de Bulto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(274, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Fecha Recibo"
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.Color.White
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(119, 78)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(122, 20)
        Me.Txt_DescripMarca.TabIndex = 8
        '
        'Txt_Medida
        '
        Me.Txt_Medida.BackColor = System.Drawing.Color.White
        Me.Txt_Medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medida.Location = New System.Drawing.Point(65, 156)
        Me.Txt_Medida.Name = "Txt_Medida"
        Me.Txt_Medida.ReadOnly = True
        Me.Txt_Medida.Size = New System.Drawing.Size(48, 20)
        Me.Txt_Medida.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Medida"
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.Color.White
        Me.Txt_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Modelo.Location = New System.Drawing.Point(65, 104)
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.ReadOnly = True
        Me.Txt_Modelo.Size = New System.Drawing.Size(48, 20)
        Me.Txt_Modelo.TabIndex = 5
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.Color.White
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(65, 78)
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.ReadOnly = True
        Me.Txt_Marca.Size = New System.Drawing.Size(48, 20)
        Me.Txt_Marca.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Marca"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Modelo"
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Location = New System.Drawing.Point(64, 17)
        Me.Txt_Serie.MaxLength = 13
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Size = New System.Drawing.Size(134, 22)
        Me.Txt_Serie.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Serie"
        '
        'Txt_Id_SegBit
        '
        Me.Txt_Id_SegBit.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Id_SegBit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Id_SegBit.Location = New System.Drawing.Point(542, -2)
        Me.Txt_Id_SegBit.MaxLength = 6
        Me.Txt_Id_SegBit.Name = "Txt_Id_SegBit"
        Me.Txt_Id_SegBit.Size = New System.Drawing.Size(10, 20)
        Me.Txt_Id_SegBit.TabIndex = 82
        Me.Txt_Id_SegBit.Visible = False
        '
        'frmCatalogoCajaCalzado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 457)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoCajaCalzado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Arreglo Caja Calzado"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PBoxNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Anterior.ResumeLayout(False)
        Me.Pnl_Anterior.PerformLayout()
        CType(Me.PBoxAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    'Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_Id_SegBit As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Porc As System.Windows.Forms.TextBox
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Pnl_Anterior As System.Windows.Forms.Panel
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Serie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Medida As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Modelo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdFolioSuc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_FechaRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Txt_MedidaNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_ModeloNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripMarcaNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_MarcaNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_CorridaNuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Txt_Corrida As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PBoxNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents PBoxAnterior As System.Windows.Forms.PictureBox
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Motivo As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_SucursalAct As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_SucursalOri As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
