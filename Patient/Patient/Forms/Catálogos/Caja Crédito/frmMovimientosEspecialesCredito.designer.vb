<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientosEspecialesCredito
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_FormasPago = New System.Windows.Forms.Panel()
        Me.btn_Convenio = New System.Windows.Forms.Button()
        Me.btn_Abono = New System.Windows.Forms.Button()
        Me.btn_Cancelacion = New System.Windows.Forms.Button()
        Me.btn_Cargo = New System.Windows.Forms.Button()
        Me.btn_Anticipo = New System.Windows.Forms.Button()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_Salir = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.pnl_Datos = New System.Windows.Forms.Panel()
        Me.gb_AnticiparPago = New System.Windows.Forms.GroupBox()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.lbl_AntCortes = New System.Windows.Forms.Label()
        Me.lbl_AntImporte = New System.Windows.Forms.Label()
        Me.txt_AntImporte = New System.Windows.Forms.TextBox()
        Me.txt_AntDistribNombre = New System.Windows.Forms.TextBox()
        Me.lbl_AntDistrib = New System.Windows.Forms.Label()
        Me.txt_AntDistrib = New System.Windows.Forms.TextBox()
        Me.lbl_AntFolio = New System.Windows.Forms.Label()
        Me.txt_AntFolio = New System.Windows.Forms.TextBox()
        Me.gb_Abono = New System.Windows.Forms.GroupBox()
        Me.lbl_AboApagar = New System.Windows.Forms.Label()
        Me.txt_AboApagar = New System.Windows.Forms.TextBox()
        Me.lbl_AboDescto = New System.Windows.Forms.Label()
        Me.txt_AboDescto = New System.Windows.Forms.TextBox()
        Me.lbl_AboAbono = New System.Windows.Forms.Label()
        Me.txt_AboAbono = New System.Windows.Forms.TextBox()
        Me.txt_AboNota = New System.Windows.Forms.TextBox()
        Me.lbl_AboNota = New System.Windows.Forms.Label()
        Me.txt_AboSucNota = New System.Windows.Forms.TextBox()
        Me.txt_AboClienteNombre = New System.Windows.Forms.TextBox()
        Me.lbl_AboCliente = New System.Windows.Forms.Label()
        Me.txt_AboCliente = New System.Windows.Forms.TextBox()
        Me.lbl_AboImporte = New System.Windows.Forms.Label()
        Me.lbl_AboFolio = New System.Windows.Forms.Label()
        Me.txt_AboImporte = New System.Windows.Forms.TextBox()
        Me.txt_AboFolio = New System.Windows.Forms.TextBox()
        Me.txt_AboDistribNombre = New System.Windows.Forms.TextBox()
        Me.lbl_AboDistrib = New System.Windows.Forms.Label()
        Me.txt_AboDistrib = New System.Windows.Forms.TextBox()
        Me.gb_GenerarCargo = New System.Windows.Forms.GroupBox()
        Me.lbl_CarMotivo = New System.Windows.Forms.Label()
        Me.cb_CarMotivo = New System.Windows.Forms.ComboBox()
        Me.lbl_CarPlazo = New System.Windows.Forms.Label()
        Me.lbl_CarAplicar = New System.Windows.Forms.Label()
        Me.lbl_CarInteres = New System.Windows.Forms.Label()
        Me.lbl_CarImporte = New System.Windows.Forms.Label()
        Me.lbl_CarDistrib = New System.Windows.Forms.Label()
        Me.lbl_CarNota = New System.Windows.Forms.Label()
        Me.lbl_CarFolio = New System.Windows.Forms.Label()
        Me.txt_CarPlazo = New System.Windows.Forms.TextBox()
        Me.dt_CarAplicar = New System.Windows.Forms.DateTimePicker()
        Me.txt_CarInteres = New System.Windows.Forms.TextBox()
        Me.txt_CarImporte = New System.Windows.Forms.TextBox()
        Me.txt_CarDistribNombre = New System.Windows.Forms.TextBox()
        Me.txt_CarDistrib = New System.Windows.Forms.TextBox()
        Me.txt_CarNota = New System.Windows.Forms.TextBox()
        Me.txt_CarSucNot = New System.Windows.Forms.TextBox()
        Me.txt_CarFolio = New System.Windows.Forms.TextBox()
        Me.gb_ConvenioPago = New System.Windows.Forms.GroupBox()
        Me.lbl_ConAnticipo = New System.Windows.Forms.Label()
        Me.txt_ConAnticipo = New System.Windows.Forms.TextBox()
        Me.txt_ConPlazo = New System.Windows.Forms.TextBox()
        Me.lbl_ConApagar = New System.Windows.Forms.Label()
        Me.txt_ConApagar = New System.Windows.Forms.TextBox()
        Me.txt_ConCobrador = New System.Windows.Forms.TextBox()
        Me.lbl_ConCobrador = New System.Windows.Forms.Label()
        Me.txt_ConCobradorNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_ConPlazo = New System.Windows.Forms.ComboBox()
        Me.lbl_ConPorc = New System.Windows.Forms.Label()
        Me.lbl_ConDescuento = New System.Windows.Forms.Label()
        Me.txt_ConDescuento = New System.Windows.Forms.TextBox()
        Me.Gb_Convenio = New System.Windows.Forms.GroupBox()
        Me.rb_ConSaldo = New System.Windows.Forms.RadioButton()
        Me.rb_ConVencido = New System.Windows.Forms.RadioButton()
        Me.lbl_ConVencido = New System.Windows.Forms.Label()
        Me.txt_ConVencido = New System.Windows.Forms.TextBox()
        Me.lbl_ConMotivo = New System.Windows.Forms.Label()
        Me.cb_ConMotivo = New System.Windows.Forms.ComboBox()
        Me.lbl_ConSaldo = New System.Windows.Forms.Label()
        Me.txt_ConFolio = New System.Windows.Forms.TextBox()
        Me.lbl_ConFolio = New System.Windows.Forms.Label()
        Me.txt_ConDistrib = New System.Windows.Forms.TextBox()
        Me.txt_ConSaldo = New System.Windows.Forms.TextBox()
        Me.lbl_ConDistrib = New System.Windows.Forms.Label()
        Me.txt_ConDistribNombre = New System.Windows.Forms.TextBox()
        Me.gb_CancelarPago = New System.Windows.Forms.GroupBox()
        Me.txt_CanDistribNombre = New System.Windows.Forms.TextBox()
        Me.dt_CanFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.lbl_CanFecha = New System.Windows.Forms.Label()
        Me.lbl_CanImporte = New System.Windows.Forms.Label()
        Me.txt_CanImporte = New System.Windows.Forms.TextBox()
        Me.lbl_CanDistrib = New System.Windows.Forms.Label()
        Me.txt_CanDistrib = New System.Windows.Forms.TextBox()
        Me.lbl_CanMotivo = New System.Windows.Forms.Label()
        Me.cb_CanMotivo = New System.Windows.Forms.ComboBox()
        Me.txt_CanPago = New System.Windows.Forms.TextBox()
        Me.lbl_CanPago = New System.Windows.Forms.Label()
        Me.txt_CanSucPago = New System.Windows.Forms.TextBox()
        Me.lbl_CanFolio = New System.Windows.Forms.Label()
        Me.txt_CanFolio = New System.Windows.Forms.TextBox()
        Me.pnl_FormasPago.SuspendLayout()
        Me.pnl_Botones.SuspendLayout()
        Me.pnl_Datos.SuspendLayout()
        Me.gb_AnticiparPago.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_Abono.SuspendLayout()
        Me.gb_GenerarCargo.SuspendLayout()
        Me.gb_ConvenioPago.SuspendLayout()
        Me.Gb_Convenio.SuspendLayout()
        Me.gb_CancelarPago.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_FormasPago
        '
        Me.pnl_FormasPago.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_FormasPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_FormasPago.Controls.Add(Me.btn_Convenio)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Abono)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Cancelacion)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Cargo)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Anticipo)
        Me.pnl_FormasPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_FormasPago.Location = New System.Drawing.Point(0, 0)
        Me.pnl_FormasPago.Name = "pnl_FormasPago"
        Me.pnl_FormasPago.Size = New System.Drawing.Size(593, 109)
        Me.pnl_FormasPago.TabIndex = 1
        '
        'btn_Convenio
        '
        Me.btn_Convenio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Convenio.BackColor = System.Drawing.Color.White
        Me.btn_Convenio.Image = Global.SIRCO.My.Resources.Resources.imagess
        Me.btn_Convenio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Convenio.Location = New System.Drawing.Point(509, 19)
        Me.btn_Convenio.Name = "btn_Convenio"
        Me.btn_Convenio.Size = New System.Drawing.Size(70, 65)
        Me.btn_Convenio.TabIndex = 4
        Me.btn_Convenio.Text = "Convenio de Pago"
        Me.btn_Convenio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Convenio.UseVisualStyleBackColor = False
        '
        'btn_Abono
        '
        Me.btn_Abono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Abono.BackColor = System.Drawing.Color.White
        Me.btn_Abono.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.btn_Abono.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Abono.Location = New System.Drawing.Point(397, 19)
        Me.btn_Abono.Name = "btn_Abono"
        Me.btn_Abono.Size = New System.Drawing.Size(73, 65)
        Me.btn_Abono.TabIndex = 3
        Me.btn_Abono.Text = "Anticipar Nota"
        Me.btn_Abono.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Abono.UseVisualStyleBackColor = False
        '
        'btn_Cancelacion
        '
        Me.btn_Cancelacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancelacion.BackColor = System.Drawing.Color.White
        Me.btn_Cancelacion.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cancelacion.Location = New System.Drawing.Point(118, 19)
        Me.btn_Cancelacion.Name = "btn_Cancelacion"
        Me.btn_Cancelacion.Size = New System.Drawing.Size(73, 65)
        Me.btn_Cancelacion.TabIndex = 1
        Me.btn_Cancelacion.Text = "Cancelar Pago"
        Me.btn_Cancelacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelacion.UseVisualStyleBackColor = False
        '
        'btn_Cargo
        '
        Me.btn_Cargo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Cargo.BackColor = System.Drawing.Color.White
        Me.btn_Cargo.Image = Global.SIRCO.My.Resources.Resources.FACTURA1
        Me.btn_Cargo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cargo.Location = New System.Drawing.Point(3, 19)
        Me.btn_Cargo.Name = "btn_Cargo"
        Me.btn_Cargo.Size = New System.Drawing.Size(73, 65)
        Me.btn_Cargo.TabIndex = 0
        Me.btn_Cargo.Text = "Generar Cargo"
        Me.btn_Cargo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cargo.UseVisualStyleBackColor = False
        '
        'btn_Anticipo
        '
        Me.btn_Anticipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btn_Anticipo.BackColor = System.Drawing.Color.White
        Me.btn_Anticipo.Image = Global.SIRCO.My.Resources.Resources.bank
        Me.btn_Anticipo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Anticipo.Location = New System.Drawing.Point(260, 19)
        Me.btn_Anticipo.Name = "btn_Anticipo"
        Me.btn_Anticipo.Size = New System.Drawing.Size(73, 65)
        Me.btn_Anticipo.TabIndex = 2
        Me.btn_Anticipo.Text = "Anticipar Pago"
        Me.btn_Anticipo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Anticipo.UseVisualStyleBackColor = False
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Salir)
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 411)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(593, 66)
        Me.pnl_Botones.TabIndex = 2
        '
        'btn_Salir
        '
        Me.btn_Salir.BackColor = System.Drawing.Color.White
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.Location = New System.Drawing.Point(441, 0)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(74, 62)
        Me.btn_Salir.TabIndex = 8
        Me.btn_Salir.Text = "Salir"
        Me.btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Salir.UseVisualStyleBackColor = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.BackColor = System.Drawing.Color.White
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.Location = New System.Drawing.Point(515, 0)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(74, 62)
        Me.btn_Aceptar.TabIndex = 6
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'pnl_Datos
        '
        Me.pnl_Datos.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_Datos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Datos.Controls.Add(Me.gb_AnticiparPago)
        Me.pnl_Datos.Controls.Add(Me.gb_Abono)
        Me.pnl_Datos.Controls.Add(Me.gb_GenerarCargo)
        Me.pnl_Datos.Controls.Add(Me.gb_ConvenioPago)
        Me.pnl_Datos.Controls.Add(Me.gb_CancelarPago)
        Me.pnl_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Datos.Location = New System.Drawing.Point(0, 109)
        Me.pnl_Datos.Name = "pnl_Datos"
        Me.pnl_Datos.Size = New System.Drawing.Size(593, 302)
        Me.pnl_Datos.TabIndex = 3
        '
        'gb_AnticiparPago
        '
        Me.gb_AnticiparPago.BackColor = System.Drawing.SystemColors.Control
        Me.gb_AnticiparPago.Controls.Add(Me.DGrid)
        Me.gb_AnticiparPago.Controls.Add(Me.lbl_AntCortes)
        Me.gb_AnticiparPago.Controls.Add(Me.lbl_AntImporte)
        Me.gb_AnticiparPago.Controls.Add(Me.txt_AntImporte)
        Me.gb_AnticiparPago.Controls.Add(Me.txt_AntDistribNombre)
        Me.gb_AnticiparPago.Controls.Add(Me.lbl_AntDistrib)
        Me.gb_AnticiparPago.Controls.Add(Me.txt_AntDistrib)
        Me.gb_AnticiparPago.Controls.Add(Me.lbl_AntFolio)
        Me.gb_AnticiparPago.Controls.Add(Me.txt_AntFolio)
        Me.gb_AnticiparPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_AnticiparPago.Location = New System.Drawing.Point(3, 3)
        Me.gb_AnticiparPago.Name = "gb_AnticiparPago"
        Me.gb_AnticiparPago.Size = New System.Drawing.Size(583, 287)
        Me.gb_AnticiparPago.TabIndex = 1
        Me.gb_AnticiparPago.TabStop = False
        Me.gb_AnticiparPago.Text = "Anticipar Pago"
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.Location = New System.Drawing.Point(18, 153)
        Me.DGrid.Name = "DGrid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(559, 128)
        Me.DGrid.TabIndex = 27
        '
        'lbl_AntCortes
        '
        Me.lbl_AntCortes.AutoSize = True
        Me.lbl_AntCortes.Location = New System.Drawing.Point(14, 130)
        Me.lbl_AntCortes.Name = "lbl_AntCortes"
        Me.lbl_AntCortes.Size = New System.Drawing.Size(139, 20)
        Me.lbl_AntCortes.TabIndex = 26
        Me.lbl_AntCortes.Text = "Próximos Cortes"
        '
        'lbl_AntImporte
        '
        Me.lbl_AntImporte.AutoSize = True
        Me.lbl_AntImporte.Location = New System.Drawing.Point(14, 92)
        Me.lbl_AntImporte.Name = "lbl_AntImporte"
        Me.lbl_AntImporte.Size = New System.Drawing.Size(71, 20)
        Me.lbl_AntImporte.TabIndex = 25
        Me.lbl_AntImporte.Text = "Importe"
        '
        'txt_AntImporte
        '
        Me.txt_AntImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AntImporte.Location = New System.Drawing.Point(121, 89)
        Me.txt_AntImporte.Name = "txt_AntImporte"
        Me.txt_AntImporte.Size = New System.Drawing.Size(137, 26)
        Me.txt_AntImporte.TabIndex = 24
        '
        'txt_AntDistribNombre
        '
        Me.txt_AntDistribNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AntDistribNombre.Location = New System.Drawing.Point(221, 57)
        Me.txt_AntDistribNombre.Name = "txt_AntDistribNombre"
        Me.txt_AntDistribNombre.ReadOnly = True
        Me.txt_AntDistribNombre.Size = New System.Drawing.Size(355, 26)
        Me.txt_AntDistribNombre.TabIndex = 23
        '
        'lbl_AntDistrib
        '
        Me.lbl_AntDistrib.AutoSize = True
        Me.lbl_AntDistrib.Location = New System.Drawing.Point(14, 60)
        Me.lbl_AntDistrib.Name = "lbl_AntDistrib"
        Me.lbl_AntDistrib.Size = New System.Drawing.Size(101, 20)
        Me.lbl_AntDistrib.TabIndex = 22
        Me.lbl_AntDistrib.Text = "Distribuidor"
        '
        'txt_AntDistrib
        '
        Me.txt_AntDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AntDistrib.Location = New System.Drawing.Point(121, 57)
        Me.txt_AntDistrib.MaxLength = 6
        Me.txt_AntDistrib.Name = "txt_AntDistrib"
        Me.txt_AntDistrib.Size = New System.Drawing.Size(94, 26)
        Me.txt_AntDistrib.TabIndex = 21
        '
        'lbl_AntFolio
        '
        Me.lbl_AntFolio.AutoSize = True
        Me.lbl_AntFolio.Location = New System.Drawing.Point(14, 28)
        Me.lbl_AntFolio.Name = "lbl_AntFolio"
        Me.lbl_AntFolio.Size = New System.Drawing.Size(48, 20)
        Me.lbl_AntFolio.TabIndex = 20
        Me.lbl_AntFolio.Text = "Folio"
        '
        'txt_AntFolio
        '
        Me.txt_AntFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AntFolio.Location = New System.Drawing.Point(121, 25)
        Me.txt_AntFolio.Name = "txt_AntFolio"
        Me.txt_AntFolio.ReadOnly = True
        Me.txt_AntFolio.Size = New System.Drawing.Size(137, 26)
        Me.txt_AntFolio.TabIndex = 19
        '
        'gb_Abono
        '
        Me.gb_Abono.Controls.Add(Me.lbl_AboApagar)
        Me.gb_Abono.Controls.Add(Me.txt_AboApagar)
        Me.gb_Abono.Controls.Add(Me.lbl_AboDescto)
        Me.gb_Abono.Controls.Add(Me.txt_AboDescto)
        Me.gb_Abono.Controls.Add(Me.lbl_AboAbono)
        Me.gb_Abono.Controls.Add(Me.txt_AboAbono)
        Me.gb_Abono.Controls.Add(Me.txt_AboNota)
        Me.gb_Abono.Controls.Add(Me.lbl_AboNota)
        Me.gb_Abono.Controls.Add(Me.txt_AboSucNota)
        Me.gb_Abono.Controls.Add(Me.txt_AboClienteNombre)
        Me.gb_Abono.Controls.Add(Me.lbl_AboCliente)
        Me.gb_Abono.Controls.Add(Me.txt_AboCliente)
        Me.gb_Abono.Controls.Add(Me.lbl_AboImporte)
        Me.gb_Abono.Controls.Add(Me.lbl_AboFolio)
        Me.gb_Abono.Controls.Add(Me.txt_AboImporte)
        Me.gb_Abono.Controls.Add(Me.txt_AboFolio)
        Me.gb_Abono.Controls.Add(Me.txt_AboDistribNombre)
        Me.gb_Abono.Controls.Add(Me.lbl_AboDistrib)
        Me.gb_Abono.Controls.Add(Me.txt_AboDistrib)
        Me.gb_Abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Abono.Location = New System.Drawing.Point(3, 3)
        Me.gb_Abono.Name = "gb_Abono"
        Me.gb_Abono.Size = New System.Drawing.Size(542, 287)
        Me.gb_Abono.TabIndex = 1
        Me.gb_Abono.TabStop = False
        Me.gb_Abono.Text = "Abono Nota"
        '
        'lbl_AboApagar
        '
        Me.lbl_AboApagar.AutoSize = True
        Me.lbl_AboApagar.Location = New System.Drawing.Point(12, 188)
        Me.lbl_AboApagar.Name = "lbl_AboApagar"
        Me.lbl_AboApagar.Size = New System.Drawing.Size(73, 20)
        Me.lbl_AboApagar.TabIndex = 42
        Me.lbl_AboApagar.Text = "A Pagar"
        '
        'txt_AboApagar
        '
        Me.txt_AboApagar.Enabled = False
        Me.txt_AboApagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboApagar.Location = New System.Drawing.Point(119, 185)
        Me.txt_AboApagar.Name = "txt_AboApagar"
        Me.txt_AboApagar.Size = New System.Drawing.Size(98, 26)
        Me.txt_AboApagar.TabIndex = 41
        '
        'lbl_AboDescto
        '
        Me.lbl_AboDescto.AutoSize = True
        Me.lbl_AboDescto.Location = New System.Drawing.Point(223, 156)
        Me.lbl_AboDescto.Name = "lbl_AboDescto"
        Me.lbl_AboDescto.Size = New System.Drawing.Size(96, 20)
        Me.lbl_AboDescto.TabIndex = 40
        Me.lbl_AboDescto.Text = "Descuento"
        '
        'txt_AboDescto
        '
        Me.txt_AboDescto.Enabled = False
        Me.txt_AboDescto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboDescto.Location = New System.Drawing.Point(323, 153)
        Me.txt_AboDescto.Name = "txt_AboDescto"
        Me.txt_AboDescto.Size = New System.Drawing.Size(98, 26)
        Me.txt_AboDescto.TabIndex = 39
        '
        'lbl_AboAbono
        '
        Me.lbl_AboAbono.AutoSize = True
        Me.lbl_AboAbono.Location = New System.Drawing.Point(16, 220)
        Me.lbl_AboAbono.Name = "lbl_AboAbono"
        Me.lbl_AboAbono.Size = New System.Drawing.Size(61, 20)
        Me.lbl_AboAbono.TabIndex = 38
        Me.lbl_AboAbono.Text = "Abono"
        '
        'txt_AboAbono
        '
        Me.txt_AboAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboAbono.Location = New System.Drawing.Point(119, 217)
        Me.txt_AboAbono.Name = "txt_AboAbono"
        Me.txt_AboAbono.Size = New System.Drawing.Size(137, 26)
        Me.txt_AboAbono.TabIndex = 37
        '
        'txt_AboNota
        '
        Me.txt_AboNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboNota.Location = New System.Drawing.Point(223, 57)
        Me.txt_AboNota.MaxLength = 6
        Me.txt_AboNota.Name = "txt_AboNota"
        Me.txt_AboNota.Size = New System.Drawing.Size(171, 26)
        Me.txt_AboNota.TabIndex = 36
        '
        'lbl_AboNota
        '
        Me.lbl_AboNota.AutoSize = True
        Me.lbl_AboNota.Location = New System.Drawing.Point(12, 60)
        Me.lbl_AboNota.Name = "lbl_AboNota"
        Me.lbl_AboNota.Size = New System.Drawing.Size(47, 20)
        Me.lbl_AboNota.TabIndex = 35
        Me.lbl_AboNota.Text = "Nota"
        '
        'txt_AboSucNota
        '
        Me.txt_AboSucNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboSucNota.Location = New System.Drawing.Point(119, 57)
        Me.txt_AboSucNota.MaxLength = 2
        Me.txt_AboSucNota.Name = "txt_AboSucNota"
        Me.txt_AboSucNota.Size = New System.Drawing.Size(97, 26)
        Me.txt_AboSucNota.TabIndex = 34
        '
        'txt_AboClienteNombre
        '
        Me.txt_AboClienteNombre.Enabled = False
        Me.txt_AboClienteNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboClienteNombre.Location = New System.Drawing.Point(222, 121)
        Me.txt_AboClienteNombre.Name = "txt_AboClienteNombre"
        Me.txt_AboClienteNombre.Size = New System.Drawing.Size(313, 26)
        Me.txt_AboClienteNombre.TabIndex = 33
        '
        'lbl_AboCliente
        '
        Me.lbl_AboCliente.AutoSize = True
        Me.lbl_AboCliente.Location = New System.Drawing.Point(12, 124)
        Me.lbl_AboCliente.Name = "lbl_AboCliente"
        Me.lbl_AboCliente.Size = New System.Drawing.Size(65, 20)
        Me.lbl_AboCliente.TabIndex = 32
        Me.lbl_AboCliente.Text = "Cliente"
        '
        'txt_AboCliente
        '
        Me.txt_AboCliente.Enabled = False
        Me.txt_AboCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboCliente.Location = New System.Drawing.Point(119, 121)
        Me.txt_AboCliente.MaxLength = 6
        Me.txt_AboCliente.Name = "txt_AboCliente"
        Me.txt_AboCliente.Size = New System.Drawing.Size(97, 26)
        Me.txt_AboCliente.TabIndex = 31
        '
        'lbl_AboImporte
        '
        Me.lbl_AboImporte.AutoSize = True
        Me.lbl_AboImporte.Location = New System.Drawing.Point(12, 156)
        Me.lbl_AboImporte.Name = "lbl_AboImporte"
        Me.lbl_AboImporte.Size = New System.Drawing.Size(71, 20)
        Me.lbl_AboImporte.TabIndex = 30
        Me.lbl_AboImporte.Text = "Importe"
        '
        'lbl_AboFolio
        '
        Me.lbl_AboFolio.AutoSize = True
        Me.lbl_AboFolio.Location = New System.Drawing.Point(12, 29)
        Me.lbl_AboFolio.Name = "lbl_AboFolio"
        Me.lbl_AboFolio.Size = New System.Drawing.Size(48, 20)
        Me.lbl_AboFolio.TabIndex = 27
        Me.lbl_AboFolio.Text = "Folio"
        '
        'txt_AboImporte
        '
        Me.txt_AboImporte.Enabled = False
        Me.txt_AboImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboImporte.Location = New System.Drawing.Point(119, 153)
        Me.txt_AboImporte.Name = "txt_AboImporte"
        Me.txt_AboImporte.Size = New System.Drawing.Size(98, 26)
        Me.txt_AboImporte.TabIndex = 29
        '
        'txt_AboFolio
        '
        Me.txt_AboFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboFolio.Location = New System.Drawing.Point(119, 26)
        Me.txt_AboFolio.Name = "txt_AboFolio"
        Me.txt_AboFolio.ReadOnly = True
        Me.txt_AboFolio.Size = New System.Drawing.Size(137, 26)
        Me.txt_AboFolio.TabIndex = 26
        '
        'txt_AboDistribNombre
        '
        Me.txt_AboDistribNombre.Enabled = False
        Me.txt_AboDistribNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboDistribNombre.Location = New System.Drawing.Point(222, 89)
        Me.txt_AboDistribNombre.Name = "txt_AboDistribNombre"
        Me.txt_AboDistribNombre.Size = New System.Drawing.Size(313, 26)
        Me.txt_AboDistribNombre.TabIndex = 28
        '
        'lbl_AboDistrib
        '
        Me.lbl_AboDistrib.AutoSize = True
        Me.lbl_AboDistrib.Location = New System.Drawing.Point(12, 92)
        Me.lbl_AboDistrib.Name = "lbl_AboDistrib"
        Me.lbl_AboDistrib.Size = New System.Drawing.Size(101, 20)
        Me.lbl_AboDistrib.TabIndex = 27
        Me.lbl_AboDistrib.Text = "Distribuidor"
        '
        'txt_AboDistrib
        '
        Me.txt_AboDistrib.Enabled = False
        Me.txt_AboDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AboDistrib.Location = New System.Drawing.Point(119, 89)
        Me.txt_AboDistrib.MaxLength = 6
        Me.txt_AboDistrib.Name = "txt_AboDistrib"
        Me.txt_AboDistrib.Size = New System.Drawing.Size(97, 26)
        Me.txt_AboDistrib.TabIndex = 26
        '
        'gb_GenerarCargo
        '
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarMotivo)
        Me.gb_GenerarCargo.Controls.Add(Me.cb_CarMotivo)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarPlazo)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarAplicar)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarInteres)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarImporte)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarDistrib)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarNota)
        Me.gb_GenerarCargo.Controls.Add(Me.lbl_CarFolio)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarPlazo)
        Me.gb_GenerarCargo.Controls.Add(Me.dt_CarAplicar)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarInteres)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarImporte)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarDistribNombre)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarDistrib)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarNota)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarSucNot)
        Me.gb_GenerarCargo.Controls.Add(Me.txt_CarFolio)
        Me.gb_GenerarCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_GenerarCargo.Location = New System.Drawing.Point(3, 3)
        Me.gb_GenerarCargo.Name = "gb_GenerarCargo"
        Me.gb_GenerarCargo.Size = New System.Drawing.Size(542, 287)
        Me.gb_GenerarCargo.TabIndex = 0
        Me.gb_GenerarCargo.TabStop = False
        Me.gb_GenerarCargo.Text = "Generar Cargo"
        '
        'lbl_CarMotivo
        '
        Me.lbl_CarMotivo.AutoSize = True
        Me.lbl_CarMotivo.Location = New System.Drawing.Point(7, 223)
        Me.lbl_CarMotivo.Name = "lbl_CarMotivo"
        Me.lbl_CarMotivo.Size = New System.Drawing.Size(61, 20)
        Me.lbl_CarMotivo.TabIndex = 41
        Me.lbl_CarMotivo.Text = "Motivo"
        '
        'cb_CarMotivo
        '
        Me.cb_CarMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_CarMotivo.FormattingEnabled = True
        Me.cb_CarMotivo.Location = New System.Drawing.Point(114, 220)
        Me.cb_CarMotivo.Name = "cb_CarMotivo"
        Me.cb_CarMotivo.Size = New System.Drawing.Size(315, 28)
        Me.cb_CarMotivo.TabIndex = 40
        '
        'lbl_CarPlazo
        '
        Me.lbl_CarPlazo.AutoSize = True
        Me.lbl_CarPlazo.Location = New System.Drawing.Point(7, 191)
        Me.lbl_CarPlazo.Name = "lbl_CarPlazo"
        Me.lbl_CarPlazo.Size = New System.Drawing.Size(53, 20)
        Me.lbl_CarPlazo.TabIndex = 17
        Me.lbl_CarPlazo.Text = "Plazo"
        '
        'lbl_CarAplicar
        '
        Me.lbl_CarAplicar.AutoSize = True
        Me.lbl_CarAplicar.Location = New System.Drawing.Point(7, 159)
        Me.lbl_CarAplicar.Name = "lbl_CarAplicar"
        Me.lbl_CarAplicar.Size = New System.Drawing.Size(64, 20)
        Me.lbl_CarAplicar.TabIndex = 16
        Me.lbl_CarAplicar.Text = "Aplicar"
        '
        'lbl_CarInteres
        '
        Me.lbl_CarInteres.AutoSize = True
        Me.lbl_CarInteres.Location = New System.Drawing.Point(7, 127)
        Me.lbl_CarInteres.Name = "lbl_CarInteres"
        Me.lbl_CarInteres.Size = New System.Drawing.Size(66, 20)
        Me.lbl_CarInteres.TabIndex = 15
        Me.lbl_CarInteres.Text = "Interes"
        '
        'lbl_CarImporte
        '
        Me.lbl_CarImporte.AutoSize = True
        Me.lbl_CarImporte.Location = New System.Drawing.Point(7, 95)
        Me.lbl_CarImporte.Name = "lbl_CarImporte"
        Me.lbl_CarImporte.Size = New System.Drawing.Size(71, 20)
        Me.lbl_CarImporte.TabIndex = 14
        Me.lbl_CarImporte.Text = "Importe"
        '
        'lbl_CarDistrib
        '
        Me.lbl_CarDistrib.AutoSize = True
        Me.lbl_CarDistrib.Location = New System.Drawing.Point(7, 63)
        Me.lbl_CarDistrib.Name = "lbl_CarDistrib"
        Me.lbl_CarDistrib.Size = New System.Drawing.Size(101, 20)
        Me.lbl_CarDistrib.TabIndex = 13
        Me.lbl_CarDistrib.Text = "Distribuidor"
        '
        'lbl_CarNota
        '
        Me.lbl_CarNota.AutoSize = True
        Me.lbl_CarNota.Location = New System.Drawing.Point(304, 28)
        Me.lbl_CarNota.Name = "lbl_CarNota"
        Me.lbl_CarNota.Size = New System.Drawing.Size(47, 20)
        Me.lbl_CarNota.TabIndex = 12
        Me.lbl_CarNota.Text = "Nota"
        '
        'lbl_CarFolio
        '
        Me.lbl_CarFolio.AutoSize = True
        Me.lbl_CarFolio.Location = New System.Drawing.Point(7, 28)
        Me.lbl_CarFolio.Name = "lbl_CarFolio"
        Me.lbl_CarFolio.Size = New System.Drawing.Size(48, 20)
        Me.lbl_CarFolio.TabIndex = 11
        Me.lbl_CarFolio.Text = "Folio"
        '
        'txt_CarPlazo
        '
        Me.txt_CarPlazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarPlazo.Location = New System.Drawing.Point(114, 188)
        Me.txt_CarPlazo.MaxLength = 2
        Me.txt_CarPlazo.Name = "txt_CarPlazo"
        Me.txt_CarPlazo.Size = New System.Drawing.Size(160, 26)
        Me.txt_CarPlazo.TabIndex = 9
        '
        'dt_CarAplicar
        '
        Me.dt_CarAplicar.Location = New System.Drawing.Point(114, 156)
        Me.dt_CarAplicar.Name = "dt_CarAplicar"
        Me.dt_CarAplicar.Size = New System.Drawing.Size(324, 26)
        Me.dt_CarAplicar.TabIndex = 8
        '
        'txt_CarInteres
        '
        Me.txt_CarInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarInteres.Location = New System.Drawing.Point(114, 124)
        Me.txt_CarInteres.Name = "txt_CarInteres"
        Me.txt_CarInteres.Size = New System.Drawing.Size(160, 26)
        Me.txt_CarInteres.TabIndex = 7
        '
        'txt_CarImporte
        '
        Me.txt_CarImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarImporte.Location = New System.Drawing.Point(114, 92)
        Me.txt_CarImporte.Name = "txt_CarImporte"
        Me.txt_CarImporte.Size = New System.Drawing.Size(160, 26)
        Me.txt_CarImporte.TabIndex = 6
        '
        'txt_CarDistribNombre
        '
        Me.txt_CarDistribNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarDistribNombre.Location = New System.Drawing.Point(206, 60)
        Me.txt_CarDistribNombre.Name = "txt_CarDistribNombre"
        Me.txt_CarDistribNombre.ReadOnly = True
        Me.txt_CarDistribNombre.Size = New System.Drawing.Size(329, 26)
        Me.txt_CarDistribNombre.TabIndex = 5
        '
        'txt_CarDistrib
        '
        Me.txt_CarDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarDistrib.Location = New System.Drawing.Point(114, 60)
        Me.txt_CarDistrib.MaxLength = 6
        Me.txt_CarDistrib.Name = "txt_CarDistrib"
        Me.txt_CarDistrib.Size = New System.Drawing.Size(86, 26)
        Me.txt_CarDistrib.TabIndex = 4
        '
        'txt_CarNota
        '
        Me.txt_CarNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarNota.Location = New System.Drawing.Point(427, 25)
        Me.txt_CarNota.MaxLength = 6
        Me.txt_CarNota.Name = "txt_CarNota"
        Me.txt_CarNota.Size = New System.Drawing.Size(108, 26)
        Me.txt_CarNota.TabIndex = 3
        '
        'txt_CarSucNot
        '
        Me.txt_CarSucNot.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarSucNot.Location = New System.Drawing.Point(357, 25)
        Me.txt_CarSucNot.MaxLength = 2
        Me.txt_CarSucNot.Name = "txt_CarSucNot"
        Me.txt_CarSucNot.Size = New System.Drawing.Size(64, 26)
        Me.txt_CarSucNot.TabIndex = 2
        '
        'txt_CarFolio
        '
        Me.txt_CarFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CarFolio.Location = New System.Drawing.Point(114, 25)
        Me.txt_CarFolio.Name = "txt_CarFolio"
        Me.txt_CarFolio.ReadOnly = True
        Me.txt_CarFolio.Size = New System.Drawing.Size(137, 26)
        Me.txt_CarFolio.TabIndex = 1
        '
        'gb_ConvenioPago
        '
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConAnticipo)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConAnticipo)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConPlazo)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConApagar)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConApagar)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConCobrador)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConCobrador)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConCobradorNombre)
        Me.gb_ConvenioPago.Controls.Add(Me.Label1)
        Me.gb_ConvenioPago.Controls.Add(Me.cb_ConPlazo)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConPorc)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConDescuento)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConDescuento)
        Me.gb_ConvenioPago.Controls.Add(Me.Gb_Convenio)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConVencido)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConVencido)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConMotivo)
        Me.gb_ConvenioPago.Controls.Add(Me.cb_ConMotivo)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConSaldo)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConFolio)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConFolio)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConDistrib)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConSaldo)
        Me.gb_ConvenioPago.Controls.Add(Me.lbl_ConDistrib)
        Me.gb_ConvenioPago.Controls.Add(Me.txt_ConDistribNombre)
        Me.gb_ConvenioPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_ConvenioPago.Location = New System.Drawing.Point(3, 3)
        Me.gb_ConvenioPago.Name = "gb_ConvenioPago"
        Me.gb_ConvenioPago.Size = New System.Drawing.Size(542, 287)
        Me.gb_ConvenioPago.TabIndex = 1
        Me.gb_ConvenioPago.TabStop = False
        Me.gb_ConvenioPago.Text = "Convenio de Pago"
        '
        'lbl_ConAnticipo
        '
        Me.lbl_ConAnticipo.AutoSize = True
        Me.lbl_ConAnticipo.Location = New System.Drawing.Point(19, 185)
        Me.lbl_ConAnticipo.Name = "lbl_ConAnticipo"
        Me.lbl_ConAnticipo.Size = New System.Drawing.Size(74, 20)
        Me.lbl_ConAnticipo.TabIndex = 57
        Me.lbl_ConAnticipo.Text = "Anticipo"
        '
        'txt_ConAnticipo
        '
        Me.txt_ConAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConAnticipo.Location = New System.Drawing.Point(126, 182)
        Me.txt_ConAnticipo.Name = "txt_ConAnticipo"
        Me.txt_ConAnticipo.Size = New System.Drawing.Size(137, 26)
        Me.txt_ConAnticipo.TabIndex = 5
        Me.txt_ConAnticipo.Text = "$0.00"
        '
        'txt_ConPlazo
        '
        Me.txt_ConPlazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConPlazo.Location = New System.Drawing.Point(126, 214)
        Me.txt_ConPlazo.Name = "txt_ConPlazo"
        Me.txt_ConPlazo.Size = New System.Drawing.Size(62, 26)
        Me.txt_ConPlazo.TabIndex = 7
        '
        'lbl_ConApagar
        '
        Me.lbl_ConApagar.AutoSize = True
        Me.lbl_ConApagar.Location = New System.Drawing.Point(318, 217)
        Me.lbl_ConApagar.Name = "lbl_ConApagar"
        Me.lbl_ConApagar.Size = New System.Drawing.Size(73, 20)
        Me.lbl_ConApagar.TabIndex = 54
        Me.lbl_ConApagar.Text = "A Pagar"
        '
        'txt_ConApagar
        '
        Me.txt_ConApagar.Enabled = False
        Me.txt_ConApagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConApagar.Location = New System.Drawing.Point(396, 214)
        Me.txt_ConApagar.Name = "txt_ConApagar"
        Me.txt_ConApagar.Size = New System.Drawing.Size(137, 26)
        Me.txt_ConApagar.TabIndex = 9
        '
        'txt_ConCobrador
        '
        Me.txt_ConCobrador.Enabled = False
        Me.txt_ConCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConCobrador.Location = New System.Drawing.Point(126, 87)
        Me.txt_ConCobrador.MaxLength = 6
        Me.txt_ConCobrador.Name = "txt_ConCobrador"
        Me.txt_ConCobrador.Size = New System.Drawing.Size(91, 26)
        Me.txt_ConCobrador.TabIndex = 1
        '
        'lbl_ConCobrador
        '
        Me.lbl_ConCobrador.AutoSize = True
        Me.lbl_ConCobrador.Location = New System.Drawing.Point(19, 90)
        Me.lbl_ConCobrador.Name = "lbl_ConCobrador"
        Me.lbl_ConCobrador.Size = New System.Drawing.Size(83, 20)
        Me.lbl_ConCobrador.TabIndex = 51
        Me.lbl_ConCobrador.Text = "Cobrador"
        '
        'txt_ConCobradorNombre
        '
        Me.txt_ConCobradorNombre.Enabled = False
        Me.txt_ConCobradorNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConCobradorNombre.Location = New System.Drawing.Point(223, 87)
        Me.txt_ConCobradorNombre.Name = "txt_ConCobradorNombre"
        Me.txt_ConCobradorNombre.Size = New System.Drawing.Size(312, 26)
        Me.txt_ConCobradorNombre.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Plazo"
        '
        'cb_ConPlazo
        '
        Me.cb_ConPlazo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ConPlazo.FormattingEnabled = True
        Me.cb_ConPlazo.Items.AddRange(New Object() {"SEMANAS", "QUINCENAS", "MESES"})
        Me.cb_ConPlazo.Location = New System.Drawing.Point(194, 214)
        Me.cb_ConPlazo.Name = "cb_ConPlazo"
        Me.cb_ConPlazo.Size = New System.Drawing.Size(120, 28)
        Me.cb_ConPlazo.TabIndex = 8
        '
        'lbl_ConPorc
        '
        Me.lbl_ConPorc.AutoSize = True
        Me.lbl_ConPorc.Location = New System.Drawing.Point(461, 185)
        Me.lbl_ConPorc.Name = "lbl_ConPorc"
        Me.lbl_ConPorc.Size = New System.Drawing.Size(24, 20)
        Me.lbl_ConPorc.TabIndex = 47
        Me.lbl_ConPorc.Text = "%"
        '
        'lbl_ConDescuento
        '
        Me.lbl_ConDescuento.AutoSize = True
        Me.lbl_ConDescuento.Location = New System.Drawing.Point(289, 185)
        Me.lbl_ConDescuento.Name = "lbl_ConDescuento"
        Me.lbl_ConDescuento.Size = New System.Drawing.Size(96, 20)
        Me.lbl_ConDescuento.TabIndex = 46
        Me.lbl_ConDescuento.Text = "Descuento"
        '
        'txt_ConDescuento
        '
        Me.txt_ConDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConDescuento.Location = New System.Drawing.Point(396, 182)
        Me.txt_ConDescuento.Name = "txt_ConDescuento"
        Me.txt_ConDescuento.Size = New System.Drawing.Size(62, 26)
        Me.txt_ConDescuento.TabIndex = 6
        '
        'Gb_Convenio
        '
        Me.Gb_Convenio.Controls.Add(Me.rb_ConSaldo)
        Me.Gb_Convenio.Controls.Add(Me.rb_ConVencido)
        Me.Gb_Convenio.Location = New System.Drawing.Point(269, 117)
        Me.Gb_Convenio.Name = "Gb_Convenio"
        Me.Gb_Convenio.Size = New System.Drawing.Size(267, 60)
        Me.Gb_Convenio.TabIndex = 4
        Me.Gb_Convenio.TabStop = False
        Me.Gb_Convenio.Text = "Convenio por:"
        '
        'rb_ConSaldo
        '
        Me.rb_ConSaldo.AutoSize = True
        Me.rb_ConSaldo.Checked = True
        Me.rb_ConSaldo.Location = New System.Drawing.Point(3, 25)
        Me.rb_ConSaldo.Name = "rb_ConSaldo"
        Me.rb_ConSaldo.Size = New System.Drawing.Size(118, 24)
        Me.rb_ConSaldo.TabIndex = 42
        Me.rb_ConSaldo.TabStop = True
        Me.rb_ConSaldo.Text = "Total Saldo"
        Me.rb_ConSaldo.UseVisualStyleBackColor = True
        '
        'rb_ConVencido
        '
        Me.rb_ConVencido.AutoSize = True
        Me.rb_ConVencido.Location = New System.Drawing.Point(127, 25)
        Me.rb_ConVencido.Name = "rb_ConVencido"
        Me.rb_ConVencido.Size = New System.Drawing.Size(137, 24)
        Me.rb_ConVencido.TabIndex = 43
        Me.rb_ConVencido.Text = "Total Vencido"
        Me.rb_ConVencido.UseVisualStyleBackColor = True
        '
        'lbl_ConVencido
        '
        Me.lbl_ConVencido.AutoSize = True
        Me.lbl_ConVencido.Location = New System.Drawing.Point(19, 154)
        Me.lbl_ConVencido.Name = "lbl_ConVencido"
        Me.lbl_ConVencido.Size = New System.Drawing.Size(74, 20)
        Me.lbl_ConVencido.TabIndex = 41
        Me.lbl_ConVencido.Text = "Vencido"
        '
        'txt_ConVencido
        '
        Me.txt_ConVencido.Enabled = False
        Me.txt_ConVencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConVencido.Location = New System.Drawing.Point(126, 151)
        Me.txt_ConVencido.Name = "txt_ConVencido"
        Me.txt_ConVencido.Size = New System.Drawing.Size(137, 26)
        Me.txt_ConVencido.TabIndex = 3
        '
        'lbl_ConMotivo
        '
        Me.lbl_ConMotivo.AutoSize = True
        Me.lbl_ConMotivo.Location = New System.Drawing.Point(19, 251)
        Me.lbl_ConMotivo.Name = "lbl_ConMotivo"
        Me.lbl_ConMotivo.Size = New System.Drawing.Size(61, 20)
        Me.lbl_ConMotivo.TabIndex = 39
        Me.lbl_ConMotivo.Text = "Motivo"
        '
        'cb_ConMotivo
        '
        Me.cb_ConMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ConMotivo.FormattingEnabled = True
        Me.cb_ConMotivo.Location = New System.Drawing.Point(126, 248)
        Me.cb_ConMotivo.Name = "cb_ConMotivo"
        Me.cb_ConMotivo.Size = New System.Drawing.Size(315, 28)
        Me.cb_ConMotivo.TabIndex = 10
        '
        'lbl_ConSaldo
        '
        Me.lbl_ConSaldo.AutoSize = True
        Me.lbl_ConSaldo.Location = New System.Drawing.Point(19, 122)
        Me.lbl_ConSaldo.Name = "lbl_ConSaldo"
        Me.lbl_ConSaldo.Size = New System.Drawing.Size(55, 20)
        Me.lbl_ConSaldo.TabIndex = 37
        Me.lbl_ConSaldo.Text = "Saldo"
        '
        'txt_ConFolio
        '
        Me.txt_ConFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConFolio.Location = New System.Drawing.Point(126, 23)
        Me.txt_ConFolio.Name = "txt_ConFolio"
        Me.txt_ConFolio.ReadOnly = True
        Me.txt_ConFolio.Size = New System.Drawing.Size(137, 26)
        Me.txt_ConFolio.TabIndex = 32
        '
        'lbl_ConFolio
        '
        Me.lbl_ConFolio.AutoSize = True
        Me.lbl_ConFolio.Location = New System.Drawing.Point(19, 26)
        Me.lbl_ConFolio.Name = "lbl_ConFolio"
        Me.lbl_ConFolio.Size = New System.Drawing.Size(48, 20)
        Me.lbl_ConFolio.TabIndex = 34
        Me.lbl_ConFolio.Text = "Folio"
        '
        'txt_ConDistrib
        '
        Me.txt_ConDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConDistrib.Location = New System.Drawing.Point(126, 55)
        Me.txt_ConDistrib.MaxLength = 6
        Me.txt_ConDistrib.Name = "txt_ConDistrib"
        Me.txt_ConDistrib.Size = New System.Drawing.Size(91, 26)
        Me.txt_ConDistrib.TabIndex = 0
        '
        'txt_ConSaldo
        '
        Me.txt_ConSaldo.Enabled = False
        Me.txt_ConSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConSaldo.Location = New System.Drawing.Point(126, 119)
        Me.txt_ConSaldo.Name = "txt_ConSaldo"
        Me.txt_ConSaldo.Size = New System.Drawing.Size(137, 26)
        Me.txt_ConSaldo.TabIndex = 2
        '
        'lbl_ConDistrib
        '
        Me.lbl_ConDistrib.AutoSize = True
        Me.lbl_ConDistrib.Location = New System.Drawing.Point(19, 58)
        Me.lbl_ConDistrib.Name = "lbl_ConDistrib"
        Me.lbl_ConDistrib.Size = New System.Drawing.Size(101, 20)
        Me.lbl_ConDistrib.TabIndex = 33
        Me.lbl_ConDistrib.Text = "Distribuidor"
        '
        'txt_ConDistribNombre
        '
        Me.txt_ConDistribNombre.Enabled = False
        Me.txt_ConDistribNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConDistribNombre.Location = New System.Drawing.Point(223, 55)
        Me.txt_ConDistribNombre.Name = "txt_ConDistribNombre"
        Me.txt_ConDistribNombre.Size = New System.Drawing.Size(312, 26)
        Me.txt_ConDistribNombre.TabIndex = 35
        '
        'gb_CancelarPago
        '
        Me.gb_CancelarPago.Controls.Add(Me.txt_CanDistribNombre)
        Me.gb_CancelarPago.Controls.Add(Me.dt_CanFechaPago)
        Me.gb_CancelarPago.Controls.Add(Me.lbl_CanFecha)
        Me.gb_CancelarPago.Controls.Add(Me.lbl_CanImporte)
        Me.gb_CancelarPago.Controls.Add(Me.txt_CanImporte)
        Me.gb_CancelarPago.Controls.Add(Me.lbl_CanDistrib)
        Me.gb_CancelarPago.Controls.Add(Me.txt_CanDistrib)
        Me.gb_CancelarPago.Controls.Add(Me.lbl_CanMotivo)
        Me.gb_CancelarPago.Controls.Add(Me.cb_CanMotivo)
        Me.gb_CancelarPago.Controls.Add(Me.txt_CanPago)
        Me.gb_CancelarPago.Controls.Add(Me.lbl_CanPago)
        Me.gb_CancelarPago.Controls.Add(Me.txt_CanSucPago)
        Me.gb_CancelarPago.Controls.Add(Me.lbl_CanFolio)
        Me.gb_CancelarPago.Controls.Add(Me.txt_CanFolio)
        Me.gb_CancelarPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_CancelarPago.Location = New System.Drawing.Point(3, 3)
        Me.gb_CancelarPago.Name = "gb_CancelarPago"
        Me.gb_CancelarPago.Size = New System.Drawing.Size(542, 287)
        Me.gb_CancelarPago.TabIndex = 1
        Me.gb_CancelarPago.TabStop = False
        Me.gb_CancelarPago.Text = "Cancelar Pago"
        '
        'txt_CanDistribNombre
        '
        Me.txt_CanDistribNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CanDistribNombre.Location = New System.Drawing.Point(207, 130)
        Me.txt_CanDistribNombre.MaxLength = 2
        Me.txt_CanDistribNombre.Name = "txt_CanDistribNombre"
        Me.txt_CanDistribNombre.ReadOnly = True
        Me.txt_CanDistribNombre.Size = New System.Drawing.Size(328, 26)
        Me.txt_CanDistribNombre.TabIndex = 51
        '
        'dt_CanFechaPago
        '
        Me.dt_CanFechaPago.Enabled = False
        Me.dt_CanFechaPago.Location = New System.Drawing.Point(119, 194)
        Me.dt_CanFechaPago.Name = "dt_CanFechaPago"
        Me.dt_CanFechaPago.Size = New System.Drawing.Size(324, 26)
        Me.dt_CanFechaPago.TabIndex = 50
        '
        'lbl_CanFecha
        '
        Me.lbl_CanFecha.AutoSize = True
        Me.lbl_CanFecha.Location = New System.Drawing.Point(12, 196)
        Me.lbl_CanFecha.Name = "lbl_CanFecha"
        Me.lbl_CanFecha.Size = New System.Drawing.Size(105, 20)
        Me.lbl_CanFecha.TabIndex = 49
        Me.lbl_CanFecha.Text = "Fecha Pago"
        '
        'lbl_CanImporte
        '
        Me.lbl_CanImporte.AutoSize = True
        Me.lbl_CanImporte.Location = New System.Drawing.Point(12, 164)
        Me.lbl_CanImporte.Name = "lbl_CanImporte"
        Me.lbl_CanImporte.Size = New System.Drawing.Size(71, 20)
        Me.lbl_CanImporte.TabIndex = 47
        Me.lbl_CanImporte.Text = "Importe"
        '
        'txt_CanImporte
        '
        Me.txt_CanImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CanImporte.Location = New System.Drawing.Point(119, 162)
        Me.txt_CanImporte.MaxLength = 2
        Me.txt_CanImporte.Name = "txt_CanImporte"
        Me.txt_CanImporte.ReadOnly = True
        Me.txt_CanImporte.Size = New System.Drawing.Size(119, 26)
        Me.txt_CanImporte.TabIndex = 46
        '
        'lbl_CanDistrib
        '
        Me.lbl_CanDistrib.AutoSize = True
        Me.lbl_CanDistrib.Location = New System.Drawing.Point(12, 133)
        Me.lbl_CanDistrib.Name = "lbl_CanDistrib"
        Me.lbl_CanDistrib.Size = New System.Drawing.Size(101, 20)
        Me.lbl_CanDistrib.TabIndex = 45
        Me.lbl_CanDistrib.Text = "Distribuidor"
        '
        'txt_CanDistrib
        '
        Me.txt_CanDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CanDistrib.Location = New System.Drawing.Point(119, 130)
        Me.txt_CanDistrib.MaxLength = 2
        Me.txt_CanDistrib.Name = "txt_CanDistrib"
        Me.txt_CanDistrib.ReadOnly = True
        Me.txt_CanDistrib.Size = New System.Drawing.Size(80, 26)
        Me.txt_CanDistrib.TabIndex = 44
        '
        'lbl_CanMotivo
        '
        Me.lbl_CanMotivo.AutoSize = True
        Me.lbl_CanMotivo.Location = New System.Drawing.Point(12, 98)
        Me.lbl_CanMotivo.Name = "lbl_CanMotivo"
        Me.lbl_CanMotivo.Size = New System.Drawing.Size(61, 20)
        Me.lbl_CanMotivo.TabIndex = 43
        Me.lbl_CanMotivo.Text = "Motivo"
        '
        'cb_CanMotivo
        '
        Me.cb_CanMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_CanMotivo.FormattingEnabled = True
        Me.cb_CanMotivo.Location = New System.Drawing.Point(79, 95)
        Me.cb_CanMotivo.Name = "cb_CanMotivo"
        Me.cb_CanMotivo.Size = New System.Drawing.Size(315, 28)
        Me.cb_CanMotivo.TabIndex = 42
        '
        'txt_CanPago
        '
        Me.txt_CanPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CanPago.Location = New System.Drawing.Point(165, 63)
        Me.txt_CanPago.MaxLength = 6
        Me.txt_CanPago.Name = "txt_CanPago"
        Me.txt_CanPago.Size = New System.Drawing.Size(122, 26)
        Me.txt_CanPago.TabIndex = 16
        '
        'lbl_CanPago
        '
        Me.lbl_CanPago.AutoSize = True
        Me.lbl_CanPago.Location = New System.Drawing.Point(12, 66)
        Me.lbl_CanPago.Name = "lbl_CanPago"
        Me.lbl_CanPago.Size = New System.Drawing.Size(50, 20)
        Me.lbl_CanPago.TabIndex = 15
        Me.lbl_CanPago.Text = "Pago"
        '
        'txt_CanSucPago
        '
        Me.txt_CanSucPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CanSucPago.Location = New System.Drawing.Point(79, 63)
        Me.txt_CanSucPago.MaxLength = 2
        Me.txt_CanSucPago.Name = "txt_CanSucPago"
        Me.txt_CanSucPago.Size = New System.Drawing.Size(80, 26)
        Me.txt_CanSucPago.TabIndex = 14
        '
        'lbl_CanFolio
        '
        Me.lbl_CanFolio.AutoSize = True
        Me.lbl_CanFolio.Location = New System.Drawing.Point(12, 31)
        Me.lbl_CanFolio.Name = "lbl_CanFolio"
        Me.lbl_CanFolio.Size = New System.Drawing.Size(48, 20)
        Me.lbl_CanFolio.TabIndex = 13
        Me.lbl_CanFolio.Text = "Folio"
        '
        'txt_CanFolio
        '
        Me.txt_CanFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CanFolio.Location = New System.Drawing.Point(79, 28)
        Me.txt_CanFolio.Name = "txt_CanFolio"
        Me.txt_CanFolio.ReadOnly = True
        Me.txt_CanFolio.Size = New System.Drawing.Size(137, 26)
        Me.txt_CanFolio.TabIndex = 12
        '
        'frmMovimientosEspecialesCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 477)
        Me.Controls.Add(Me.pnl_Datos)
        Me.Controls.Add(Me.pnl_Botones)
        Me.Controls.Add(Me.pnl_FormasPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMovimientosEspecialesCredito"
        Me.Text = "Movimientos Especiales"
        Me.pnl_FormasPago.ResumeLayout(False)
        Me.pnl_Botones.ResumeLayout(False)
        Me.pnl_Datos.ResumeLayout(False)
        Me.gb_AnticiparPago.ResumeLayout(False)
        Me.gb_AnticiparPago.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_Abono.ResumeLayout(False)
        Me.gb_Abono.PerformLayout()
        Me.gb_GenerarCargo.ResumeLayout(False)
        Me.gb_GenerarCargo.PerformLayout()
        Me.gb_ConvenioPago.ResumeLayout(False)
        Me.gb_ConvenioPago.PerformLayout()
        Me.Gb_Convenio.ResumeLayout(False)
        Me.Gb_Convenio.PerformLayout()
        Me.gb_CancelarPago.ResumeLayout(False)
        Me.gb_CancelarPago.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_FormasPago As System.Windows.Forms.Panel
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents pnl_Datos As System.Windows.Forms.Panel
    Friend WithEvents btn_Convenio As System.Windows.Forms.Button
    Friend WithEvents btn_Abono As System.Windows.Forms.Button
    Friend WithEvents btn_Anticipo As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelacion As System.Windows.Forms.Button
    Friend WithEvents btn_Cargo As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents gb_GenerarCargo As System.Windows.Forms.GroupBox
    Friend WithEvents gb_CancelarPago As System.Windows.Forms.GroupBox
    Friend WithEvents gb_AnticiparPago As System.Windows.Forms.GroupBox
    Friend WithEvents gb_Abono As System.Windows.Forms.GroupBox
    Friend WithEvents gb_ConvenioPago As System.Windows.Forms.GroupBox
    Friend WithEvents txt_CarFolio As System.Windows.Forms.TextBox
    Friend WithEvents txt_CarDistrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_CarNota As System.Windows.Forms.TextBox
    Friend WithEvents txt_CarSucNot As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CarPlazo As System.Windows.Forms.Label
    Friend WithEvents lbl_CarAplicar As System.Windows.Forms.Label
    Friend WithEvents lbl_CarInteres As System.Windows.Forms.Label
    Friend WithEvents lbl_CarImporte As System.Windows.Forms.Label
    Friend WithEvents lbl_CarDistrib As System.Windows.Forms.Label
    Friend WithEvents lbl_CarNota As System.Windows.Forms.Label
    Friend WithEvents lbl_CarFolio As System.Windows.Forms.Label
    Friend WithEvents txt_CarPlazo As System.Windows.Forms.TextBox
    Friend WithEvents dt_CarAplicar As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_CarInteres As System.Windows.Forms.TextBox
    Friend WithEvents txt_CarImporte As System.Windows.Forms.TextBox
    Friend WithEvents txt_CarDistribNombre As System.Windows.Forms.TextBox
    Friend WithEvents txt_CanPago As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CanPago As System.Windows.Forms.Label
    Friend WithEvents txt_CanSucPago As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CanFolio As System.Windows.Forms.Label
    Friend WithEvents txt_CanFolio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AntFolio As System.Windows.Forms.Label
    Friend WithEvents txt_AntFolio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AntImporte As System.Windows.Forms.Label
    Friend WithEvents txt_AntImporte As System.Windows.Forms.TextBox
    Friend WithEvents txt_AntDistribNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AntDistrib As System.Windows.Forms.Label
    Friend WithEvents txt_AntDistrib As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AboImporte As System.Windows.Forms.Label
    Friend WithEvents lbl_AboFolio As System.Windows.Forms.Label
    Friend WithEvents txt_AboImporte As System.Windows.Forms.TextBox
    Friend WithEvents txt_AboFolio As System.Windows.Forms.TextBox
    Friend WithEvents txt_AboDistribNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AboDistrib As System.Windows.Forms.Label
    Friend WithEvents txt_AboDistrib As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConSaldo As System.Windows.Forms.Label
    Friend WithEvents txt_ConFolio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConFolio As System.Windows.Forms.Label
    Friend WithEvents txt_ConDistrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_ConSaldo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConDistrib As System.Windows.Forms.Label
    Friend WithEvents txt_ConDistribNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConMotivo As System.Windows.Forms.Label
    Friend WithEvents cb_ConMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_CarMotivo As System.Windows.Forms.Label
    Friend WithEvents cb_CarMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_CanMotivo As System.Windows.Forms.Label
    Friend WithEvents cb_CanMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_Salir As System.Windows.Forms.Button
    Friend WithEvents dt_CanFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_CanFecha As System.Windows.Forms.Label
    Friend WithEvents lbl_CanImporte As System.Windows.Forms.Label
    Friend WithEvents txt_CanImporte As System.Windows.Forms.TextBox
    Friend WithEvents lbl_CanDistrib As System.Windows.Forms.Label
    Friend WithEvents txt_CanDistrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_CanDistribNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AntCortes As System.Windows.Forms.Label
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_AboAbono As System.Windows.Forms.Label
    Friend WithEvents txt_AboAbono As System.Windows.Forms.TextBox
    Friend WithEvents txt_AboNota As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AboNota As System.Windows.Forms.Label
    Friend WithEvents txt_AboSucNota As System.Windows.Forms.TextBox
    Friend WithEvents txt_AboClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AboCliente As System.Windows.Forms.Label
    Friend WithEvents txt_AboCliente As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AboApagar As System.Windows.Forms.Label
    Friend WithEvents txt_AboApagar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AboDescto As System.Windows.Forms.Label
    Friend WithEvents txt_AboDescto As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConVencido As System.Windows.Forms.Label
    Friend WithEvents txt_ConVencido As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_ConPorc As System.Windows.Forms.Label
    Friend WithEvents lbl_ConDescuento As System.Windows.Forms.Label
    Friend WithEvents txt_ConDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Gb_Convenio As System.Windows.Forms.GroupBox
    Friend WithEvents rb_ConSaldo As System.Windows.Forms.RadioButton
    Friend WithEvents rb_ConVencido As System.Windows.Forms.RadioButton
    Friend WithEvents txt_ConCobrador As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConCobrador As System.Windows.Forms.Label
    Friend WithEvents txt_ConCobradorNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ConApagar As System.Windows.Forms.Label
    Friend WithEvents txt_ConApagar As System.Windows.Forms.TextBox
    Friend WithEvents txt_ConPlazo As System.Windows.Forms.TextBox
    Friend WithEvents cb_ConPlazo As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_ConAnticipo As System.Windows.Forms.Label
    Friend WithEvents txt_ConAnticipo As System.Windows.Forms.TextBox
End Class
