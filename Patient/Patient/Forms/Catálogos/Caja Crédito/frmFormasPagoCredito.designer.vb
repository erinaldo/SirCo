<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormasPagoCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFormasPagoCredito))
        Me.pnl_FormasPago = New System.Windows.Forms.Panel()
        Me.btn_Dolares = New System.Windows.Forms.Button()
        Me.btn_Activos = New System.Windows.Forms.Button()
        Me.btn_Cheque = New System.Windows.Forms.Button()
        Me.btn_TarjetaCredito = New System.Windows.Forms.Button()
        Me.btn_Efectivo = New System.Windows.Forms.Button()
        Me.btn_TarjetaDebito = New System.Windows.Forms.Button()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_Cambiar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Pagar = New System.Windows.Forms.Button()
        Me.pnl_Datos = New System.Windows.Forms.Panel()
        Me.gb_Dolares = New System.Windows.Forms.GroupBox()
        Me.lbl_Dol6 = New System.Windows.Forms.Label()
        Me.lbl_DolPesos = New System.Windows.Forms.Label()
        Me.lbl_DolDolares = New System.Windows.Forms.Label()
        Me.lbl_Dol5 = New System.Windows.Forms.Label()
        Me.lbl_Dol4 = New System.Windows.Forms.Label()
        Me.lbl_Dol3 = New System.Windows.Forms.Label()
        Me.lbl_Dol2 = New System.Windows.Forms.Label()
        Me.lbl_Dol1 = New System.Windows.Forms.Label()
        Me.lbl_DolTipoCambio = New System.Windows.Forms.Label()
        Me.txt_DolTipoCambio = New System.Windows.Forms.TextBox()
        Me.lbl_DolPendiente = New System.Windows.Forms.Label()
        Me.txt_DolPendiente = New System.Windows.Forms.TextBox()
        Me.lbl_DolCambio = New System.Windows.Forms.Label()
        Me.lbl_DolRecibe = New System.Windows.Forms.Label()
        Me.lbl_DolTotal = New System.Windows.Forms.Label()
        Me.lbl_DolDescuento = New System.Windows.Forms.Label()
        Me.lbl_DolSubtotal = New System.Windows.Forms.Label()
        Me.txt_DolCambio = New System.Windows.Forms.TextBox()
        Me.txt_DolRecibe = New System.Windows.Forms.TextBox()
        Me.txt_DolTotal = New System.Windows.Forms.TextBox()
        Me.txt_DolDescuento = New System.Windows.Forms.TextBox()
        Me.txt_DolSubtotal = New System.Windows.Forms.TextBox()
        Me.gb_Activos = New System.Windows.Forms.GroupBox()
        Me.lbl_Comercio = New System.Windows.Forms.Label()
        Me.txt_Comercio = New System.Windows.Forms.TextBox()
        Me.rb_ActUsado = New System.Windows.Forms.RadioButton()
        Me.rb_ActNuevo = New System.Windows.Forms.RadioButton()
        Me.lbl_Importe = New System.Windows.Forms.Label()
        Me.lbl_Comercial = New System.Windows.Forms.Label()
        Me.lbl_NumSerie = New System.Windows.Forms.Label()
        Me.lbl_Marca = New System.Windows.Forms.Label()
        Me.lbl_Tipo = New System.Windows.Forms.Label()
        Me.lbl_Articulo = New System.Windows.Forms.Label()
        Me.txt_ImporteAdquirido = New System.Windows.Forms.TextBox()
        Me.txt_ImpComercial = New System.Windows.Forms.TextBox()
        Me.txt_NumSerie = New System.Windows.Forms.TextBox()
        Me.txt_Marca = New System.Windows.Forms.TextBox()
        Me.cb_Tipo = New System.Windows.Forms.ComboBox()
        Me.txt_Articulo = New System.Windows.Forms.TextBox()
        Me.btn_ActFactura = New System.Windows.Forms.Button()
        Me.btn_ActFotos = New System.Windows.Forms.Button()
        Me.txt_Sucursal = New System.Windows.Forms.TextBox()
        Me.lbl_Folio = New System.Windows.Forms.Label()
        Me.txt_Folio = New System.Windows.Forms.TextBox()
        Me.gb_TarjetaCyD = New System.Windows.Forms.GroupBox()
        Me.lbl_RecibeTarj = New System.Windows.Forms.Label()
        Me.lbl_Autorizacion = New System.Windows.Forms.Label()
        Me.lbl_NoTarjeta = New System.Windows.Forms.Label()
        Me.lbl_Emisor = New System.Windows.Forms.Label()
        Me.cb_Emisor = New System.Windows.Forms.ComboBox()
        Me.txt_RecibeTar = New System.Windows.Forms.TextBox()
        Me.txt_Autorizacion = New System.Windows.Forms.TextBox()
        Me.txt_Tarjeta4 = New System.Windows.Forms.TextBox()
        Me.txt_Tarjeta3 = New System.Windows.Forms.TextBox()
        Me.txt_Tarjeta2 = New System.Windows.Forms.TextBox()
        Me.txt_Tarjeta1 = New System.Windows.Forms.TextBox()
        Me.lbl_Distribuidor = New System.Windows.Forms.Label()
        Me.gb_Cheque = New System.Windows.Forms.GroupBox()
        Me.lbl_RecibeChe = New System.Windows.Forms.Label()
        Me.lbl_NoCheque = New System.Windows.Forms.Label()
        Me.lbl_NoCuenta = New System.Windows.Forms.Label()
        Me.lbl_RutaBancaria = New System.Windows.Forms.Label()
        Me.txt_RecibeChe = New System.Windows.Forms.TextBox()
        Me.txt_NoCheque = New System.Windows.Forms.TextBox()
        Me.txt_NoCuenta = New System.Windows.Forms.TextBox()
        Me.txt_RutaBancaria = New System.Windows.Forms.TextBox()
        Me.gb_PagoEfectivo = New System.Windows.Forms.GroupBox()
        Me.lbl_PendienteEfe = New System.Windows.Forms.Label()
        Me.txt_PendienteEfe = New System.Windows.Forms.TextBox()
        Me.lbl_CambioEfe = New System.Windows.Forms.Label()
        Me.lbl_RecibeEfe = New System.Windows.Forms.Label()
        Me.lbl_TotalEfe = New System.Windows.Forms.Label()
        Me.lbl_DescuentoEfe = New System.Windows.Forms.Label()
        Me.lbl_SubtotalEfe = New System.Windows.Forms.Label()
        Me.txt_CambioEfe = New System.Windows.Forms.TextBox()
        Me.txt_RecibeEfe = New System.Windows.Forms.TextBox()
        Me.txt_TotalEfe = New System.Windows.Forms.TextBox()
        Me.txt_DescuentoEfe = New System.Windows.Forms.TextBox()
        Me.txt_SubtotalEfe = New System.Windows.Forms.TextBox()
        Me.Txt_NombreDistrib = New System.Windows.Forms.TextBox()
        Me.Txt_Distrib = New System.Windows.Forms.TextBox()
        Me.pnl_FormasPago.SuspendLayout()
        Me.pnl_Botones.SuspendLayout()
        Me.pnl_Datos.SuspendLayout()
        Me.gb_Dolares.SuspendLayout()
        Me.gb_Activos.SuspendLayout()
        Me.gb_TarjetaCyD.SuspendLayout()
        Me.gb_Cheque.SuspendLayout()
        Me.gb_PagoEfectivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_FormasPago
        '
        Me.pnl_FormasPago.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_FormasPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_FormasPago.Controls.Add(Me.btn_Dolares)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Activos)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Cheque)
        Me.pnl_FormasPago.Controls.Add(Me.btn_TarjetaCredito)
        Me.pnl_FormasPago.Controls.Add(Me.btn_Efectivo)
        Me.pnl_FormasPago.Controls.Add(Me.btn_TarjetaDebito)
        Me.pnl_FormasPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_FormasPago.Location = New System.Drawing.Point(0, 0)
        Me.pnl_FormasPago.Name = "pnl_FormasPago"
        Me.pnl_FormasPago.Size = New System.Drawing.Size(511, 109)
        Me.pnl_FormasPago.TabIndex = 1
        '
        'btn_Dolares
        '
        Me.btn_Dolares.BackColor = System.Drawing.Color.White
        Me.btn_Dolares.Image = Global.SIRCO.My.Resources.Resources.NOMINA1
        Me.btn_Dolares.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Dolares.Location = New System.Drawing.Point(353, 12)
        Me.btn_Dolares.Name = "btn_Dolares"
        Me.btn_Dolares.Size = New System.Drawing.Size(64, 81)
        Me.btn_Dolares.TabIndex = 5
        Me.btn_Dolares.Text = "Dolares"
        Me.btn_Dolares.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Dolares.UseVisualStyleBackColor = False
        '
        'btn_Activos
        '
        Me.btn_Activos.BackColor = System.Drawing.Color.White
        Me.btn_Activos.Image = Global.SIRCO.My.Resources.Resources.images
        Me.btn_Activos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Activos.Location = New System.Drawing.Point(433, 12)
        Me.btn_Activos.Name = "btn_Activos"
        Me.btn_Activos.Size = New System.Drawing.Size(64, 81)
        Me.btn_Activos.TabIndex = 4
        Me.btn_Activos.Text = "Activos"
        Me.btn_Activos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Activos.UseVisualStyleBackColor = False
        '
        'btn_Cheque
        '
        Me.btn_Cheque.BackColor = System.Drawing.Color.White
        Me.btn_Cheque.Image = Global.SIRCO.My.Resources.Resources.bank_check__1_
        Me.btn_Cheque.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cheque.Location = New System.Drawing.Point(268, 12)
        Me.btn_Cheque.Name = "btn_Cheque"
        Me.btn_Cheque.Size = New System.Drawing.Size(64, 81)
        Me.btn_Cheque.TabIndex = 3
        Me.btn_Cheque.Text = "Cheque"
        Me.btn_Cheque.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cheque.UseVisualStyleBackColor = False
        '
        'btn_TarjetaCredito
        '
        Me.btn_TarjetaCredito.BackColor = System.Drawing.Color.White
        Me.btn_TarjetaCredito.Image = Global.SIRCO.My.Resources.Resources.credit_card__1_
        Me.btn_TarjetaCredito.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_TarjetaCredito.Location = New System.Drawing.Point(94, 12)
        Me.btn_TarjetaCredito.Name = "btn_TarjetaCredito"
        Me.btn_TarjetaCredito.Size = New System.Drawing.Size(64, 81)
        Me.btn_TarjetaCredito.TabIndex = 1
        Me.btn_TarjetaCredito.Text = "Tarjeta de Credito"
        Me.btn_TarjetaCredito.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_TarjetaCredito.UseVisualStyleBackColor = False
        '
        'btn_Efectivo
        '
        Me.btn_Efectivo.BackColor = System.Drawing.Color.White
        Me.btn_Efectivo.Image = Global.SIRCO.My.Resources.Resources.NOMINA11
        Me.btn_Efectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Efectivo.Location = New System.Drawing.Point(13, 12)
        Me.btn_Efectivo.Name = "btn_Efectivo"
        Me.btn_Efectivo.Size = New System.Drawing.Size(64, 81)
        Me.btn_Efectivo.TabIndex = 0
        Me.btn_Efectivo.Text = "Efectivo"
        Me.btn_Efectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Efectivo.UseVisualStyleBackColor = False
        '
        'btn_TarjetaDebito
        '
        Me.btn_TarjetaDebito.BackColor = System.Drawing.Color.White
        Me.btn_TarjetaDebito.Image = Global.SIRCO.My.Resources.Resources.credit_cards
        Me.btn_TarjetaDebito.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_TarjetaDebito.Location = New System.Drawing.Point(180, 12)
        Me.btn_TarjetaDebito.Name = "btn_TarjetaDebito"
        Me.btn_TarjetaDebito.Size = New System.Drawing.Size(64, 81)
        Me.btn_TarjetaDebito.TabIndex = 2
        Me.btn_TarjetaDebito.Text = "Tarjeta de Debito"
        Me.btn_TarjetaDebito.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_TarjetaDebito.UseVisualStyleBackColor = False
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Cambiar)
        Me.pnl_Botones.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Botones.Controls.Add(Me.btn_Pagar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 452)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(511, 70)
        Me.pnl_Botones.TabIndex = 2
        '
        'btn_Cambiar
        '
        Me.btn_Cambiar.BackColor = System.Drawing.Color.White
        Me.btn_Cambiar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Cambiar.Image = Global.SIRCO.My.Resources.Resources.money
        Me.btn_Cambiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Cambiar.Location = New System.Drawing.Point(0, 0)
        Me.btn_Cambiar.Name = "btn_Cambiar"
        Me.btn_Cambiar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Cambiar.TabIndex = 8
        Me.btn_Cambiar.Text = "Cambiar Forma Pago"
        Me.btn_Cambiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cambiar.UseVisualStyleBackColor = False
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.White
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelar.Location = New System.Drawing.Point(359, 0)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Cancelar.TabIndex = 1
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Pagar
        '
        Me.btn_Pagar.BackColor = System.Drawing.Color.White
        Me.btn_Pagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Pagar.Image = Global.SIRCO.My.Resources.Resources.ok_bag
        Me.btn_Pagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Pagar.Location = New System.Drawing.Point(433, 0)
        Me.btn_Pagar.Name = "btn_Pagar"
        Me.btn_Pagar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Pagar.TabIndex = 0
        Me.btn_Pagar.Text = "Pagar"
        Me.btn_Pagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Pagar.UseVisualStyleBackColor = False
        '
        'pnl_Datos
        '
        Me.pnl_Datos.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_Datos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Datos.Controls.Add(Me.gb_Dolares)
        Me.pnl_Datos.Controls.Add(Me.gb_Activos)
        Me.pnl_Datos.Controls.Add(Me.txt_Sucursal)
        Me.pnl_Datos.Controls.Add(Me.lbl_Folio)
        Me.pnl_Datos.Controls.Add(Me.txt_Folio)
        Me.pnl_Datos.Controls.Add(Me.gb_TarjetaCyD)
        Me.pnl_Datos.Controls.Add(Me.lbl_Distribuidor)
        Me.pnl_Datos.Controls.Add(Me.gb_Cheque)
        Me.pnl_Datos.Controls.Add(Me.gb_PagoEfectivo)
        Me.pnl_Datos.Controls.Add(Me.Txt_NombreDistrib)
        Me.pnl_Datos.Controls.Add(Me.Txt_Distrib)
        Me.pnl_Datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Datos.Location = New System.Drawing.Point(0, 109)
        Me.pnl_Datos.Name = "pnl_Datos"
        Me.pnl_Datos.Size = New System.Drawing.Size(511, 343)
        Me.pnl_Datos.TabIndex = 3
        '
        'gb_Dolares
        '
        Me.gb_Dolares.BackColor = System.Drawing.SystemColors.Control
        Me.gb_Dolares.Controls.Add(Me.lbl_Dol6)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolPesos)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolDolares)
        Me.gb_Dolares.Controls.Add(Me.lbl_Dol5)
        Me.gb_Dolares.Controls.Add(Me.lbl_Dol4)
        Me.gb_Dolares.Controls.Add(Me.lbl_Dol3)
        Me.gb_Dolares.Controls.Add(Me.lbl_Dol2)
        Me.gb_Dolares.Controls.Add(Me.lbl_Dol1)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolTipoCambio)
        Me.gb_Dolares.Controls.Add(Me.txt_DolTipoCambio)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolPendiente)
        Me.gb_Dolares.Controls.Add(Me.txt_DolPendiente)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolCambio)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolRecibe)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolTotal)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolDescuento)
        Me.gb_Dolares.Controls.Add(Me.lbl_DolSubtotal)
        Me.gb_Dolares.Controls.Add(Me.txt_DolCambio)
        Me.gb_Dolares.Controls.Add(Me.txt_DolRecibe)
        Me.gb_Dolares.Controls.Add(Me.txt_DolTotal)
        Me.gb_Dolares.Controls.Add(Me.txt_DolDescuento)
        Me.gb_Dolares.Controls.Add(Me.txt_DolSubtotal)
        Me.gb_Dolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Dolares.Location = New System.Drawing.Point(12, 70)
        Me.gb_Dolares.Name = "gb_Dolares"
        Me.gb_Dolares.Size = New System.Drawing.Size(485, 266)
        Me.gb_Dolares.TabIndex = 4
        Me.gb_Dolares.TabStop = False
        Me.gb_Dolares.Text = "Dolares"
        Me.gb_Dolares.Visible = False
        '
        'lbl_Dol6
        '
        Me.lbl_Dol6.AutoSize = True
        Me.lbl_Dol6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dol6.Location = New System.Drawing.Point(459, 64)
        Me.lbl_Dol6.Name = "lbl_Dol6"
        Me.lbl_Dol6.Size = New System.Drawing.Size(18, 24)
        Me.lbl_Dol6.TabIndex = 20
        Me.lbl_Dol6.Text = "*"
        '
        'lbl_DolPesos
        '
        Me.lbl_DolPesos.AutoSize = True
        Me.lbl_DolPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolPesos.Location = New System.Drawing.Point(386, 235)
        Me.lbl_DolPesos.Name = "lbl_DolPesos"
        Me.lbl_DolPesos.Size = New System.Drawing.Size(93, 24)
        Me.lbl_DolPesos.TabIndex = 19
        Me.lbl_DolPesos.Text = "* PESOS"
        '
        'lbl_DolDolares
        '
        Me.lbl_DolDolares.AutoSize = True
        Me.lbl_DolDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolDolares.Location = New System.Drawing.Point(296, 149)
        Me.lbl_DolDolares.Name = "lbl_DolDolares"
        Me.lbl_DolDolares.Size = New System.Drawing.Size(106, 24)
        Me.lbl_DolDolares.TabIndex = 18
        Me.lbl_DolDolares.Text = "DOLARES"
        '
        'lbl_Dol5
        '
        Me.lbl_Dol5.AutoSize = True
        Me.lbl_Dol5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dol5.Location = New System.Drawing.Point(296, 232)
        Me.lbl_Dol5.Name = "lbl_Dol5"
        Me.lbl_Dol5.Size = New System.Drawing.Size(18, 24)
        Me.lbl_Dol5.TabIndex = 17
        Me.lbl_Dol5.Text = "*"
        '
        'lbl_Dol4
        '
        Me.lbl_Dol4.AutoSize = True
        Me.lbl_Dol4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dol4.Location = New System.Drawing.Point(296, 190)
        Me.lbl_Dol4.Name = "lbl_Dol4"
        Me.lbl_Dol4.Size = New System.Drawing.Size(18, 24)
        Me.lbl_Dol4.TabIndex = 16
        Me.lbl_Dol4.Text = "*"
        '
        'lbl_Dol3
        '
        Me.lbl_Dol3.AutoSize = True
        Me.lbl_Dol3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dol3.Location = New System.Drawing.Point(296, 108)
        Me.lbl_Dol3.Name = "lbl_Dol3"
        Me.lbl_Dol3.Size = New System.Drawing.Size(18, 24)
        Me.lbl_Dol3.TabIndex = 15
        Me.lbl_Dol3.Text = "*"
        '
        'lbl_Dol2
        '
        Me.lbl_Dol2.AutoSize = True
        Me.lbl_Dol2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dol2.Location = New System.Drawing.Point(296, 67)
        Me.lbl_Dol2.Name = "lbl_Dol2"
        Me.lbl_Dol2.Size = New System.Drawing.Size(18, 24)
        Me.lbl_Dol2.TabIndex = 14
        Me.lbl_Dol2.Text = "*"
        '
        'lbl_Dol1
        '
        Me.lbl_Dol1.AutoSize = True
        Me.lbl_Dol1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dol1.Location = New System.Drawing.Point(296, 26)
        Me.lbl_Dol1.Name = "lbl_Dol1"
        Me.lbl_Dol1.Size = New System.Drawing.Size(18, 24)
        Me.lbl_Dol1.TabIndex = 13
        Me.lbl_Dol1.Text = "*"
        '
        'lbl_DolTipoCambio
        '
        Me.lbl_DolTipoCambio.AutoSize = True
        Me.lbl_DolTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolTipoCambio.Location = New System.Drawing.Point(320, 31)
        Me.lbl_DolTipoCambio.Name = "lbl_DolTipoCambio"
        Me.lbl_DolTipoCambio.Size = New System.Drawing.Size(159, 24)
        Me.lbl_DolTipoCambio.TabIndex = 12
        Me.lbl_DolTipoCambio.Text = "Tipo de Cambio"
        '
        'txt_DolTipoCambio
        '
        Me.txt_DolTipoCambio.BackColor = System.Drawing.Color.White
        Me.txt_DolTipoCambio.Enabled = False
        Me.txt_DolTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolTipoCambio.Location = New System.Drawing.Point(324, 60)
        Me.txt_DolTipoCambio.Name = "txt_DolTipoCambio"
        Me.txt_DolTipoCambio.ReadOnly = True
        Me.txt_DolTipoCambio.Size = New System.Drawing.Size(129, 35)
        Me.txt_DolTipoCambio.TabIndex = 11
        Me.txt_DolTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_DolPendiente
        '
        Me.lbl_DolPendiente.AutoSize = True
        Me.lbl_DolPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolPendiente.Location = New System.Drawing.Point(6, 232)
        Me.lbl_DolPendiente.Name = "lbl_DolPendiente"
        Me.lbl_DolPendiente.Size = New System.Drawing.Size(105, 24)
        Me.lbl_DolPendiente.TabIndex = 0
        Me.lbl_DolPendiente.Text = "Pendiente"
        '
        'txt_DolPendiente
        '
        Me.txt_DolPendiente.BackColor = System.Drawing.Color.White
        Me.txt_DolPendiente.Enabled = False
        Me.txt_DolPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolPendiente.Location = New System.Drawing.Point(122, 225)
        Me.txt_DolPendiente.Name = "txt_DolPendiente"
        Me.txt_DolPendiente.ReadOnly = True
        Me.txt_DolPendiente.Size = New System.Drawing.Size(170, 35)
        Me.txt_DolPendiente.TabIndex = 10
        Me.txt_DolPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_DolCambio
        '
        Me.lbl_DolCambio.AutoSize = True
        Me.lbl_DolCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolCambio.Location = New System.Drawing.Point(6, 190)
        Me.lbl_DolCambio.Name = "lbl_DolCambio"
        Me.lbl_DolCambio.Size = New System.Drawing.Size(81, 24)
        Me.lbl_DolCambio.TabIndex = 9
        Me.lbl_DolCambio.Text = "Cambio"
        '
        'lbl_DolRecibe
        '
        Me.lbl_DolRecibe.AutoSize = True
        Me.lbl_DolRecibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolRecibe.Location = New System.Drawing.Point(6, 149)
        Me.lbl_DolRecibe.Name = "lbl_DolRecibe"
        Me.lbl_DolRecibe.Size = New System.Drawing.Size(76, 24)
        Me.lbl_DolRecibe.TabIndex = 8
        Me.lbl_DolRecibe.Text = "Recibe"
        '
        'lbl_DolTotal
        '
        Me.lbl_DolTotal.AutoSize = True
        Me.lbl_DolTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolTotal.Location = New System.Drawing.Point(6, 108)
        Me.lbl_DolTotal.Name = "lbl_DolTotal"
        Me.lbl_DolTotal.Size = New System.Drawing.Size(56, 24)
        Me.lbl_DolTotal.TabIndex = 7
        Me.lbl_DolTotal.Text = "Total"
        '
        'lbl_DolDescuento
        '
        Me.lbl_DolDescuento.AutoSize = True
        Me.lbl_DolDescuento.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_DolDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolDescuento.Location = New System.Drawing.Point(6, 67)
        Me.lbl_DolDescuento.Name = "lbl_DolDescuento"
        Me.lbl_DolDescuento.Size = New System.Drawing.Size(110, 24)
        Me.lbl_DolDescuento.TabIndex = 6
        Me.lbl_DolDescuento.Text = "Descuento"
        '
        'lbl_DolSubtotal
        '
        Me.lbl_DolSubtotal.AutoSize = True
        Me.lbl_DolSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DolSubtotal.Location = New System.Drawing.Point(6, 26)
        Me.lbl_DolSubtotal.Name = "lbl_DolSubtotal"
        Me.lbl_DolSubtotal.Size = New System.Drawing.Size(85, 24)
        Me.lbl_DolSubtotal.TabIndex = 5
        Me.lbl_DolSubtotal.Text = "Subtotal"
        '
        'txt_DolCambio
        '
        Me.txt_DolCambio.BackColor = System.Drawing.Color.White
        Me.txt_DolCambio.Enabled = False
        Me.txt_DolCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolCambio.Location = New System.Drawing.Point(122, 183)
        Me.txt_DolCambio.Name = "txt_DolCambio"
        Me.txt_DolCambio.ReadOnly = True
        Me.txt_DolCambio.Size = New System.Drawing.Size(170, 35)
        Me.txt_DolCambio.TabIndex = 4
        Me.txt_DolCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DolRecibe
        '
        Me.txt_DolRecibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolRecibe.Location = New System.Drawing.Point(122, 142)
        Me.txt_DolRecibe.Name = "txt_DolRecibe"
        Me.txt_DolRecibe.Size = New System.Drawing.Size(170, 35)
        Me.txt_DolRecibe.TabIndex = 3
        Me.txt_DolRecibe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DolTotal
        '
        Me.txt_DolTotal.BackColor = System.Drawing.Color.White
        Me.txt_DolTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolTotal.Location = New System.Drawing.Point(122, 101)
        Me.txt_DolTotal.Name = "txt_DolTotal"
        Me.txt_DolTotal.ReadOnly = True
        Me.txt_DolTotal.Size = New System.Drawing.Size(170, 35)
        Me.txt_DolTotal.TabIndex = 2
        Me.txt_DolTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DolDescuento
        '
        Me.txt_DolDescuento.BackColor = System.Drawing.Color.White
        Me.txt_DolDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolDescuento.Location = New System.Drawing.Point(122, 60)
        Me.txt_DolDescuento.Name = "txt_DolDescuento"
        Me.txt_DolDescuento.ReadOnly = True
        Me.txt_DolDescuento.Size = New System.Drawing.Size(170, 35)
        Me.txt_DolDescuento.TabIndex = 1
        Me.txt_DolDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DolSubtotal
        '
        Me.txt_DolSubtotal.BackColor = System.Drawing.Color.White
        Me.txt_DolSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DolSubtotal.Location = New System.Drawing.Point(122, 19)
        Me.txt_DolSubtotal.Name = "txt_DolSubtotal"
        Me.txt_DolSubtotal.ReadOnly = True
        Me.txt_DolSubtotal.Size = New System.Drawing.Size(170, 35)
        Me.txt_DolSubtotal.TabIndex = 0
        Me.txt_DolSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gb_Activos
        '
        Me.gb_Activos.Controls.Add(Me.lbl_Comercio)
        Me.gb_Activos.Controls.Add(Me.txt_Comercio)
        Me.gb_Activos.Controls.Add(Me.rb_ActUsado)
        Me.gb_Activos.Controls.Add(Me.rb_ActNuevo)
        Me.gb_Activos.Controls.Add(Me.lbl_Importe)
        Me.gb_Activos.Controls.Add(Me.lbl_Comercial)
        Me.gb_Activos.Controls.Add(Me.lbl_NumSerie)
        Me.gb_Activos.Controls.Add(Me.lbl_Marca)
        Me.gb_Activos.Controls.Add(Me.lbl_Tipo)
        Me.gb_Activos.Controls.Add(Me.lbl_Articulo)
        Me.gb_Activos.Controls.Add(Me.txt_ImporteAdquirido)
        Me.gb_Activos.Controls.Add(Me.txt_ImpComercial)
        Me.gb_Activos.Controls.Add(Me.txt_NumSerie)
        Me.gb_Activos.Controls.Add(Me.txt_Marca)
        Me.gb_Activos.Controls.Add(Me.cb_Tipo)
        Me.gb_Activos.Controls.Add(Me.txt_Articulo)
        Me.gb_Activos.Controls.Add(Me.btn_ActFactura)
        Me.gb_Activos.Controls.Add(Me.btn_ActFotos)
        Me.gb_Activos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Activos.Location = New System.Drawing.Point(12, 70)
        Me.gb_Activos.Name = "gb_Activos"
        Me.gb_Activos.Size = New System.Drawing.Size(485, 267)
        Me.gb_Activos.TabIndex = 0
        Me.gb_Activos.TabStop = False
        Me.gb_Activos.Text = "Activos"
        Me.gb_Activos.Visible = False
        '
        'lbl_Comercio
        '
        Me.lbl_Comercio.AutoSize = True
        Me.lbl_Comercio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Comercio.Location = New System.Drawing.Point(218, 127)
        Me.lbl_Comercio.Name = "lbl_Comercio"
        Me.lbl_Comercio.Size = New System.Drawing.Size(74, 16)
        Me.lbl_Comercio.TabIndex = 25
        Me.lbl_Comercio.Text = "Comercio"
        '
        'txt_Comercio
        '
        Me.txt_Comercio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Comercio.Location = New System.Drawing.Point(296, 123)
        Me.txt_Comercio.Name = "txt_Comercio"
        Me.txt_Comercio.Size = New System.Drawing.Size(133, 22)
        Me.txt_Comercio.TabIndex = 5
        '
        'rb_ActUsado
        '
        Me.rb_ActUsado.AutoSize = True
        Me.rb_ActUsado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ActUsado.Location = New System.Drawing.Point(28, 231)
        Me.rb_ActUsado.Name = "rb_ActUsado"
        Me.rb_ActUsado.Size = New System.Drawing.Size(72, 20)
        Me.rb_ActUsado.TabIndex = 23
        Me.rb_ActUsado.Text = "Usado"
        Me.rb_ActUsado.UseVisualStyleBackColor = True
        '
        'rb_ActNuevo
        '
        Me.rb_ActNuevo.AutoSize = True
        Me.rb_ActNuevo.Checked = True
        Me.rb_ActNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ActNuevo.Location = New System.Drawing.Point(28, 201)
        Me.rb_ActNuevo.Name = "rb_ActNuevo"
        Me.rb_ActNuevo.Size = New System.Drawing.Size(71, 20)
        Me.rb_ActNuevo.TabIndex = 7
        Me.rb_ActNuevo.TabStop = True
        Me.rb_ActNuevo.Text = "Nuevo"
        Me.rb_ActNuevo.UseVisualStyleBackColor = True
        '
        'lbl_Importe
        '
        Me.lbl_Importe.AutoSize = True
        Me.lbl_Importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Importe.Location = New System.Drawing.Point(28, 154)
        Me.lbl_Importe.Name = "lbl_Importe"
        Me.lbl_Importe.Size = New System.Drawing.Size(72, 16)
        Me.lbl_Importe.TabIndex = 21
        Me.lbl_Importe.Text = "$ Importe"
        '
        'lbl_Comercial
        '
        Me.lbl_Comercial.AutoSize = True
        Me.lbl_Comercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Comercial.Location = New System.Drawing.Point(26, 126)
        Me.lbl_Comercial.Name = "lbl_Comercial"
        Me.lbl_Comercial.Size = New System.Drawing.Size(55, 16)
        Me.lbl_Comercial.TabIndex = 20
        Me.lbl_Comercial.Text = "$ Com."
        '
        'lbl_NumSerie
        '
        Me.lbl_NumSerie.AutoSize = True
        Me.lbl_NumSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NumSerie.Location = New System.Drawing.Point(225, 92)
        Me.lbl_NumSerie.Name = "lbl_NumSerie"
        Me.lbl_NumSerie.Size = New System.Drawing.Size(65, 16)
        Me.lbl_NumSerie.TabIndex = 19
        Me.lbl_NumSerie.Text = "N° Serie"
        '
        'lbl_Marca
        '
        Me.lbl_Marca.AutoSize = True
        Me.lbl_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Marca.Location = New System.Drawing.Point(25, 92)
        Me.lbl_Marca.Name = "lbl_Marca"
        Me.lbl_Marca.Size = New System.Drawing.Size(51, 16)
        Me.lbl_Marca.TabIndex = 18
        Me.lbl_Marca.Text = "Marca"
        '
        'lbl_Tipo
        '
        Me.lbl_Tipo.AutoSize = True
        Me.lbl_Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tipo.Location = New System.Drawing.Point(25, 55)
        Me.lbl_Tipo.Name = "lbl_Tipo"
        Me.lbl_Tipo.Size = New System.Drawing.Size(76, 16)
        Me.lbl_Tipo.TabIndex = 17
        Me.lbl_Tipo.Text = "Categoria"
        '
        'lbl_Articulo
        '
        Me.lbl_Articulo.AutoSize = True
        Me.lbl_Articulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Articulo.Location = New System.Drawing.Point(25, 22)
        Me.lbl_Articulo.Name = "lbl_Articulo"
        Me.lbl_Articulo.Size = New System.Drawing.Size(60, 16)
        Me.lbl_Articulo.TabIndex = 13
        Me.lbl_Articulo.Text = "Articulo"
        '
        'txt_ImporteAdquirido
        '
        Me.txt_ImporteAdquirido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ImporteAdquirido.Location = New System.Drawing.Point(106, 151)
        Me.txt_ImporteAdquirido.Name = "txt_ImporteAdquirido"
        Me.txt_ImporteAdquirido.Size = New System.Drawing.Size(106, 22)
        Me.txt_ImporteAdquirido.TabIndex = 6
        '
        'txt_ImpComercial
        '
        Me.txt_ImpComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ImpComercial.Location = New System.Drawing.Point(106, 123)
        Me.txt_ImpComercial.Name = "txt_ImpComercial"
        Me.txt_ImpComercial.Size = New System.Drawing.Size(106, 22)
        Me.txt_ImpComercial.TabIndex = 4
        '
        'txt_NumSerie
        '
        Me.txt_NumSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NumSerie.Location = New System.Drawing.Point(296, 89)
        Me.txt_NumSerie.Name = "txt_NumSerie"
        Me.txt_NumSerie.Size = New System.Drawing.Size(133, 22)
        Me.txt_NumSerie.TabIndex = 3
        '
        'txt_Marca
        '
        Me.txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Marca.Location = New System.Drawing.Point(106, 89)
        Me.txt_Marca.Name = "txt_Marca"
        Me.txt_Marca.Size = New System.Drawing.Size(117, 22)
        Me.txt_Marca.TabIndex = 2
        '
        'cb_Tipo
        '
        Me.cb_Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Tipo.FormattingEnabled = True
        Me.cb_Tipo.Location = New System.Drawing.Point(106, 52)
        Me.cb_Tipo.Name = "cb_Tipo"
        Me.cb_Tipo.Size = New System.Drawing.Size(323, 24)
        Me.cb_Tipo.TabIndex = 1
        '
        'txt_Articulo
        '
        Me.txt_Articulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Articulo.Location = New System.Drawing.Point(106, 19)
        Me.txt_Articulo.Name = "txt_Articulo"
        Me.txt_Articulo.Size = New System.Drawing.Size(323, 22)
        Me.txt_Articulo.TabIndex = 0
        '
        'btn_ActFactura
        '
        Me.btn_ActFactura.BackColor = System.Drawing.Color.White
        Me.btn_ActFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ActFactura.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.btn_ActFactura.Location = New System.Drawing.Point(355, 194)
        Me.btn_ActFactura.Name = "btn_ActFactura"
        Me.btn_ActFactura.Size = New System.Drawing.Size(74, 66)
        Me.btn_ActFactura.TabIndex = 9
        Me.btn_ActFactura.Text = "Factura"
        Me.btn_ActFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ActFactura.UseVisualStyleBackColor = False
        '
        'btn_ActFotos
        '
        Me.btn_ActFotos.BackColor = System.Drawing.Color.White
        Me.btn_ActFotos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ActFotos.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.btn_ActFotos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ActFotos.Location = New System.Drawing.Point(275, 194)
        Me.btn_ActFotos.Name = "btn_ActFotos"
        Me.btn_ActFotos.Size = New System.Drawing.Size(74, 66)
        Me.btn_ActFotos.TabIndex = 8
        Me.btn_ActFotos.Text = "Foto"
        Me.btn_ActFotos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ActFotos.UseVisualStyleBackColor = False
        '
        'txt_Sucursal
        '
        Me.txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Sucursal.Enabled = False
        Me.txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Sucursal.Location = New System.Drawing.Point(102, 42)
        Me.txt_Sucursal.Name = "txt_Sucursal"
        Me.txt_Sucursal.ReadOnly = True
        Me.txt_Sucursal.Size = New System.Drawing.Size(62, 22)
        Me.txt_Sucursal.TabIndex = 10
        '
        'lbl_Folio
        '
        Me.lbl_Folio.AutoSize = True
        Me.lbl_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Folio.Location = New System.Drawing.Point(8, 45)
        Me.lbl_Folio.Name = "lbl_Folio"
        Me.lbl_Folio.Size = New System.Drawing.Size(88, 16)
        Me.lbl_Folio.TabIndex = 9
        Me.lbl_Folio.Text = "Folio Pago:"
        '
        'txt_Folio
        '
        Me.txt_Folio.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Folio.Enabled = False
        Me.txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Folio.Location = New System.Drawing.Point(169, 42)
        Me.txt_Folio.Name = "txt_Folio"
        Me.txt_Folio.ReadOnly = True
        Me.txt_Folio.Size = New System.Drawing.Size(85, 22)
        Me.txt_Folio.TabIndex = 8
        '
        'gb_TarjetaCyD
        '
        Me.gb_TarjetaCyD.Controls.Add(Me.lbl_RecibeTarj)
        Me.gb_TarjetaCyD.Controls.Add(Me.lbl_Autorizacion)
        Me.gb_TarjetaCyD.Controls.Add(Me.lbl_NoTarjeta)
        Me.gb_TarjetaCyD.Controls.Add(Me.lbl_Emisor)
        Me.gb_TarjetaCyD.Controls.Add(Me.cb_Emisor)
        Me.gb_TarjetaCyD.Controls.Add(Me.txt_RecibeTar)
        Me.gb_TarjetaCyD.Controls.Add(Me.txt_Autorizacion)
        Me.gb_TarjetaCyD.Controls.Add(Me.txt_Tarjeta4)
        Me.gb_TarjetaCyD.Controls.Add(Me.txt_Tarjeta3)
        Me.gb_TarjetaCyD.Controls.Add(Me.txt_Tarjeta2)
        Me.gb_TarjetaCyD.Controls.Add(Me.txt_Tarjeta1)
        Me.gb_TarjetaCyD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_TarjetaCyD.Location = New System.Drawing.Point(12, 70)
        Me.gb_TarjetaCyD.Name = "gb_TarjetaCyD"
        Me.gb_TarjetaCyD.Size = New System.Drawing.Size(485, 266)
        Me.gb_TarjetaCyD.TabIndex = 5
        Me.gb_TarjetaCyD.TabStop = False
        Me.gb_TarjetaCyD.Text = "Credito y Debito"
        Me.gb_TarjetaCyD.Visible = False
        '
        'lbl_RecibeTarj
        '
        Me.lbl_RecibeTarj.AutoSize = True
        Me.lbl_RecibeTarj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RecibeTarj.Location = New System.Drawing.Point(11, 156)
        Me.lbl_RecibeTarj.Name = "lbl_RecibeTarj"
        Me.lbl_RecibeTarj.Size = New System.Drawing.Size(76, 24)
        Me.lbl_RecibeTarj.TabIndex = 10
        Me.lbl_RecibeTarj.Text = "Recibe"
        '
        'lbl_Autorizacion
        '
        Me.lbl_Autorizacion.AutoSize = True
        Me.lbl_Autorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Autorizacion.Location = New System.Drawing.Point(11, 115)
        Me.lbl_Autorizacion.Name = "lbl_Autorizacion"
        Me.lbl_Autorizacion.Size = New System.Drawing.Size(126, 24)
        Me.lbl_Autorizacion.TabIndex = 9
        Me.lbl_Autorizacion.Text = "Autorización"
        '
        'lbl_NoTarjeta
        '
        Me.lbl_NoTarjeta.AutoSize = True
        Me.lbl_NoTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NoTarjeta.Location = New System.Drawing.Point(11, 71)
        Me.lbl_NoTarjeta.Name = "lbl_NoTarjeta"
        Me.lbl_NoTarjeta.Size = New System.Drawing.Size(102, 24)
        Me.lbl_NoTarjeta.TabIndex = 8
        Me.lbl_NoTarjeta.Text = "N° Tarjeta"
        '
        'lbl_Emisor
        '
        Me.lbl_Emisor.AutoSize = True
        Me.lbl_Emisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Emisor.Location = New System.Drawing.Point(11, 30)
        Me.lbl_Emisor.Name = "lbl_Emisor"
        Me.lbl_Emisor.Size = New System.Drawing.Size(75, 24)
        Me.lbl_Emisor.TabIndex = 7
        Me.lbl_Emisor.Text = "Emisor"
        '
        'cb_Emisor
        '
        Me.cb_Emisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Emisor.FormattingEnabled = True
        Me.cb_Emisor.Location = New System.Drawing.Point(141, 24)
        Me.cb_Emisor.Name = "cb_Emisor"
        Me.cb_Emisor.Size = New System.Drawing.Size(264, 37)
        Me.cb_Emisor.TabIndex = 0
        '
        'txt_RecibeTar
        '
        Me.txt_RecibeTar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RecibeTar.Location = New System.Drawing.Point(143, 149)
        Me.txt_RecibeTar.Name = "txt_RecibeTar"
        Me.txt_RecibeTar.Size = New System.Drawing.Size(195, 35)
        Me.txt_RecibeTar.TabIndex = 6
        Me.txt_RecibeTar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Autorizacion
        '
        Me.txt_Autorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Autorizacion.Location = New System.Drawing.Point(143, 108)
        Me.txt_Autorizacion.Name = "txt_Autorizacion"
        Me.txt_Autorizacion.Size = New System.Drawing.Size(195, 35)
        Me.txt_Autorizacion.TabIndex = 5
        '
        'txt_Tarjeta4
        '
        Me.txt_Tarjeta4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Tarjeta4.Location = New System.Drawing.Point(344, 66)
        Me.txt_Tarjeta4.MaxLength = 4
        Me.txt_Tarjeta4.Name = "txt_Tarjeta4"
        Me.txt_Tarjeta4.Size = New System.Drawing.Size(61, 31)
        Me.txt_Tarjeta4.TabIndex = 4
        '
        'txt_Tarjeta3
        '
        Me.txt_Tarjeta3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Tarjeta3.Location = New System.Drawing.Point(277, 67)
        Me.txt_Tarjeta3.MaxLength = 4
        Me.txt_Tarjeta3.Name = "txt_Tarjeta3"
        Me.txt_Tarjeta3.Size = New System.Drawing.Size(61, 31)
        Me.txt_Tarjeta3.TabIndex = 3
        '
        'txt_Tarjeta2
        '
        Me.txt_Tarjeta2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Tarjeta2.Location = New System.Drawing.Point(210, 67)
        Me.txt_Tarjeta2.MaxLength = 4
        Me.txt_Tarjeta2.Name = "txt_Tarjeta2"
        Me.txt_Tarjeta2.Size = New System.Drawing.Size(61, 31)
        Me.txt_Tarjeta2.TabIndex = 2
        '
        'txt_Tarjeta1
        '
        Me.txt_Tarjeta1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Tarjeta1.Location = New System.Drawing.Point(143, 67)
        Me.txt_Tarjeta1.MaxLength = 4
        Me.txt_Tarjeta1.Name = "txt_Tarjeta1"
        Me.txt_Tarjeta1.Size = New System.Drawing.Size(61, 31)
        Me.txt_Tarjeta1.TabIndex = 1
        '
        'lbl_Distribuidor
        '
        Me.lbl_Distribuidor.AutoSize = True
        Me.lbl_Distribuidor.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_Distribuidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Distribuidor.Location = New System.Drawing.Point(8, 15)
        Me.lbl_Distribuidor.Name = "lbl_Distribuidor"
        Me.lbl_Distribuidor.Size = New System.Drawing.Size(88, 16)
        Me.lbl_Distribuidor.TabIndex = 6
        Me.lbl_Distribuidor.Text = "Distribuidor"
        '
        'gb_Cheque
        '
        Me.gb_Cheque.Controls.Add(Me.lbl_RecibeChe)
        Me.gb_Cheque.Controls.Add(Me.lbl_NoCheque)
        Me.gb_Cheque.Controls.Add(Me.lbl_NoCuenta)
        Me.gb_Cheque.Controls.Add(Me.lbl_RutaBancaria)
        Me.gb_Cheque.Controls.Add(Me.txt_RecibeChe)
        Me.gb_Cheque.Controls.Add(Me.txt_NoCheque)
        Me.gb_Cheque.Controls.Add(Me.txt_NoCuenta)
        Me.gb_Cheque.Controls.Add(Me.txt_RutaBancaria)
        Me.gb_Cheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_Cheque.Location = New System.Drawing.Point(12, 70)
        Me.gb_Cheque.Name = "gb_Cheque"
        Me.gb_Cheque.Size = New System.Drawing.Size(485, 266)
        Me.gb_Cheque.TabIndex = 7
        Me.gb_Cheque.TabStop = False
        Me.gb_Cheque.Text = "Cheque"
        Me.gb_Cheque.Visible = False
        '
        'lbl_RecibeChe
        '
        Me.lbl_RecibeChe.AutoSize = True
        Me.lbl_RecibeChe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RecibeChe.Location = New System.Drawing.Point(14, 163)
        Me.lbl_RecibeChe.Name = "lbl_RecibeChe"
        Me.lbl_RecibeChe.Size = New System.Drawing.Size(76, 24)
        Me.lbl_RecibeChe.TabIndex = 11
        Me.lbl_RecibeChe.Text = "Recibe"
        '
        'lbl_NoCheque
        '
        Me.lbl_NoCheque.AutoSize = True
        Me.lbl_NoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NoCheque.Location = New System.Drawing.Point(13, 122)
        Me.lbl_NoCheque.Name = "lbl_NoCheque"
        Me.lbl_NoCheque.Size = New System.Drawing.Size(112, 24)
        Me.lbl_NoCheque.TabIndex = 10
        Me.lbl_NoCheque.Text = "N° Cheque"
        '
        'lbl_NoCuenta
        '
        Me.lbl_NoCuenta.AutoSize = True
        Me.lbl_NoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NoCuenta.Location = New System.Drawing.Point(14, 78)
        Me.lbl_NoCuenta.Name = "lbl_NoCuenta"
        Me.lbl_NoCuenta.Size = New System.Drawing.Size(134, 24)
        Me.lbl_NoCuenta.TabIndex = 9
        Me.lbl_NoCuenta.Text = "N° de Cuenta"
        '
        'lbl_RutaBancaria
        '
        Me.lbl_RutaBancaria.AutoSize = True
        Me.lbl_RutaBancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RutaBancaria.Location = New System.Drawing.Point(13, 33)
        Me.lbl_RutaBancaria.Name = "lbl_RutaBancaria"
        Me.lbl_RutaBancaria.Size = New System.Drawing.Size(139, 24)
        Me.lbl_RutaBancaria.TabIndex = 8
        Me.lbl_RutaBancaria.Text = "Ruta Bancaria"
        '
        'txt_RecibeChe
        '
        Me.txt_RecibeChe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RecibeChe.Location = New System.Drawing.Point(158, 156)
        Me.txt_RecibeChe.Name = "txt_RecibeChe"
        Me.txt_RecibeChe.Size = New System.Drawing.Size(206, 35)
        Me.txt_RecibeChe.TabIndex = 3
        Me.txt_RecibeChe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_NoCheque
        '
        Me.txt_NoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NoCheque.Location = New System.Drawing.Point(158, 115)
        Me.txt_NoCheque.Name = "txt_NoCheque"
        Me.txt_NoCheque.Size = New System.Drawing.Size(206, 35)
        Me.txt_NoCheque.TabIndex = 2
        '
        'txt_NoCuenta
        '
        Me.txt_NoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NoCuenta.Location = New System.Drawing.Point(158, 71)
        Me.txt_NoCuenta.Name = "txt_NoCuenta"
        Me.txt_NoCuenta.Size = New System.Drawing.Size(206, 35)
        Me.txt_NoCuenta.TabIndex = 1
        '
        'txt_RutaBancaria
        '
        Me.txt_RutaBancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RutaBancaria.Location = New System.Drawing.Point(158, 30)
        Me.txt_RutaBancaria.Name = "txt_RutaBancaria"
        Me.txt_RutaBancaria.Size = New System.Drawing.Size(206, 35)
        Me.txt_RutaBancaria.TabIndex = 0
        '
        'gb_PagoEfectivo
        '
        Me.gb_PagoEfectivo.Controls.Add(Me.lbl_PendienteEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.txt_PendienteEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.lbl_CambioEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.lbl_RecibeEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.lbl_TotalEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.lbl_DescuentoEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.lbl_SubtotalEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.txt_CambioEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.txt_RecibeEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.txt_TotalEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.txt_DescuentoEfe)
        Me.gb_PagoEfectivo.Controls.Add(Me.txt_SubtotalEfe)
        Me.gb_PagoEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_PagoEfectivo.Location = New System.Drawing.Point(12, 70)
        Me.gb_PagoEfectivo.Name = "gb_PagoEfectivo"
        Me.gb_PagoEfectivo.Size = New System.Drawing.Size(485, 266)
        Me.gb_PagoEfectivo.TabIndex = 3
        Me.gb_PagoEfectivo.TabStop = False
        Me.gb_PagoEfectivo.Text = "Pago En Efectivo"
        Me.gb_PagoEfectivo.Visible = False
        '
        'lbl_PendienteEfe
        '
        Me.lbl_PendienteEfe.AutoSize = True
        Me.lbl_PendienteEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PendienteEfe.Location = New System.Drawing.Point(41, 232)
        Me.lbl_PendienteEfe.Name = "lbl_PendienteEfe"
        Me.lbl_PendienteEfe.Size = New System.Drawing.Size(105, 24)
        Me.lbl_PendienteEfe.TabIndex = 0
        Me.lbl_PendienteEfe.Text = "Pendiente"
        '
        'txt_PendienteEfe
        '
        Me.txt_PendienteEfe.BackColor = System.Drawing.Color.White
        Me.txt_PendienteEfe.Enabled = False
        Me.txt_PendienteEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PendienteEfe.Location = New System.Drawing.Point(157, 225)
        Me.txt_PendienteEfe.Name = "txt_PendienteEfe"
        Me.txt_PendienteEfe.ReadOnly = True
        Me.txt_PendienteEfe.Size = New System.Drawing.Size(192, 35)
        Me.txt_PendienteEfe.TabIndex = 10
        Me.txt_PendienteEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_CambioEfe
        '
        Me.lbl_CambioEfe.AutoSize = True
        Me.lbl_CambioEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CambioEfe.Location = New System.Drawing.Point(41, 190)
        Me.lbl_CambioEfe.Name = "lbl_CambioEfe"
        Me.lbl_CambioEfe.Size = New System.Drawing.Size(81, 24)
        Me.lbl_CambioEfe.TabIndex = 9
        Me.lbl_CambioEfe.Text = "Cambio"
        '
        'lbl_RecibeEfe
        '
        Me.lbl_RecibeEfe.AutoSize = True
        Me.lbl_RecibeEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RecibeEfe.Location = New System.Drawing.Point(41, 149)
        Me.lbl_RecibeEfe.Name = "lbl_RecibeEfe"
        Me.lbl_RecibeEfe.Size = New System.Drawing.Size(76, 24)
        Me.lbl_RecibeEfe.TabIndex = 8
        Me.lbl_RecibeEfe.Text = "Recibe"
        '
        'lbl_TotalEfe
        '
        Me.lbl_TotalEfe.AutoSize = True
        Me.lbl_TotalEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotalEfe.Location = New System.Drawing.Point(41, 108)
        Me.lbl_TotalEfe.Name = "lbl_TotalEfe"
        Me.lbl_TotalEfe.Size = New System.Drawing.Size(56, 24)
        Me.lbl_TotalEfe.TabIndex = 7
        Me.lbl_TotalEfe.Text = "Total"
        '
        'lbl_DescuentoEfe
        '
        Me.lbl_DescuentoEfe.AutoSize = True
        Me.lbl_DescuentoEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_DescuentoEfe.Location = New System.Drawing.Point(41, 67)
        Me.lbl_DescuentoEfe.Name = "lbl_DescuentoEfe"
        Me.lbl_DescuentoEfe.Size = New System.Drawing.Size(110, 24)
        Me.lbl_DescuentoEfe.TabIndex = 6
        Me.lbl_DescuentoEfe.Text = "Descuento"
        '
        'lbl_SubtotalEfe
        '
        Me.lbl_SubtotalEfe.AutoSize = True
        Me.lbl_SubtotalEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SubtotalEfe.Location = New System.Drawing.Point(41, 26)
        Me.lbl_SubtotalEfe.Name = "lbl_SubtotalEfe"
        Me.lbl_SubtotalEfe.Size = New System.Drawing.Size(85, 24)
        Me.lbl_SubtotalEfe.TabIndex = 5
        Me.lbl_SubtotalEfe.Text = "Subtotal"
        '
        'txt_CambioEfe
        '
        Me.txt_CambioEfe.BackColor = System.Drawing.Color.White
        Me.txt_CambioEfe.Enabled = False
        Me.txt_CambioEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CambioEfe.Location = New System.Drawing.Point(157, 183)
        Me.txt_CambioEfe.Name = "txt_CambioEfe"
        Me.txt_CambioEfe.ReadOnly = True
        Me.txt_CambioEfe.Size = New System.Drawing.Size(192, 35)
        Me.txt_CambioEfe.TabIndex = 4
        Me.txt_CambioEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_RecibeEfe
        '
        Me.txt_RecibeEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RecibeEfe.Location = New System.Drawing.Point(157, 142)
        Me.txt_RecibeEfe.Name = "txt_RecibeEfe"
        Me.txt_RecibeEfe.Size = New System.Drawing.Size(192, 35)
        Me.txt_RecibeEfe.TabIndex = 3
        Me.txt_RecibeEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_TotalEfe
        '
        Me.txt_TotalEfe.BackColor = System.Drawing.Color.White
        Me.txt_TotalEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TotalEfe.Location = New System.Drawing.Point(157, 101)
        Me.txt_TotalEfe.Name = "txt_TotalEfe"
        Me.txt_TotalEfe.ReadOnly = True
        Me.txt_TotalEfe.Size = New System.Drawing.Size(192, 35)
        Me.txt_TotalEfe.TabIndex = 2
        Me.txt_TotalEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_DescuentoEfe
        '
        Me.txt_DescuentoEfe.BackColor = System.Drawing.Color.White
        Me.txt_DescuentoEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DescuentoEfe.Location = New System.Drawing.Point(157, 60)
        Me.txt_DescuentoEfe.Name = "txt_DescuentoEfe"
        Me.txt_DescuentoEfe.ReadOnly = True
        Me.txt_DescuentoEfe.Size = New System.Drawing.Size(192, 35)
        Me.txt_DescuentoEfe.TabIndex = 1
        Me.txt_DescuentoEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_SubtotalEfe
        '
        Me.txt_SubtotalEfe.BackColor = System.Drawing.Color.White
        Me.txt_SubtotalEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SubtotalEfe.Location = New System.Drawing.Point(157, 19)
        Me.txt_SubtotalEfe.Name = "txt_SubtotalEfe"
        Me.txt_SubtotalEfe.ReadOnly = True
        Me.txt_SubtotalEfe.Size = New System.Drawing.Size(192, 35)
        Me.txt_SubtotalEfe.TabIndex = 0
        Me.txt_SubtotalEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_NombreDistrib
        '
        Me.Txt_NombreDistrib.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreDistrib.Enabled = False
        Me.Txt_NombreDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreDistrib.Location = New System.Drawing.Point(170, 14)
        Me.Txt_NombreDistrib.Name = "Txt_NombreDistrib"
        Me.Txt_NombreDistrib.ReadOnly = True
        Me.Txt_NombreDistrib.Size = New System.Drawing.Size(327, 22)
        Me.Txt_NombreDistrib.TabIndex = 2
        '
        'Txt_Distrib
        '
        Me.Txt_Distrib.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Distrib.Enabled = False
        Me.Txt_Distrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Distrib.Location = New System.Drawing.Point(102, 14)
        Me.Txt_Distrib.Name = "Txt_Distrib"
        Me.Txt_Distrib.ReadOnly = True
        Me.Txt_Distrib.Size = New System.Drawing.Size(62, 22)
        Me.Txt_Distrib.TabIndex = 1
        '
        'frmFormasPagoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 522)
        Me.Controls.Add(Me.pnl_Datos)
        Me.Controls.Add(Me.pnl_Botones)
        Me.Controls.Add(Me.pnl_FormasPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFormasPagoCredito"
        Me.Text = "Formas de Pago"
        Me.pnl_FormasPago.ResumeLayout(False)
        Me.pnl_Botones.ResumeLayout(False)
        Me.pnl_Datos.ResumeLayout(False)
        Me.pnl_Datos.PerformLayout()
        Me.gb_Dolares.ResumeLayout(False)
        Me.gb_Dolares.PerformLayout()
        Me.gb_Activos.ResumeLayout(False)
        Me.gb_Activos.PerformLayout()
        Me.gb_TarjetaCyD.ResumeLayout(False)
        Me.gb_TarjetaCyD.PerformLayout()
        Me.gb_Cheque.ResumeLayout(False)
        Me.gb_Cheque.PerformLayout()
        Me.gb_PagoEfectivo.ResumeLayout(False)
        Me.gb_PagoEfectivo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_FormasPago As System.Windows.Forms.Panel
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents pnl_Datos As System.Windows.Forms.Panel
    Friend WithEvents btn_Activos As System.Windows.Forms.Button
    Friend WithEvents btn_Cheque As System.Windows.Forms.Button
    Friend WithEvents btn_TarjetaDebito As System.Windows.Forms.Button
    Friend WithEvents btn_TarjetaCredito As System.Windows.Forms.Button
    Friend WithEvents btn_Efectivo As System.Windows.Forms.Button
    Friend WithEvents Txt_NombreDistrib As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Distrib As System.Windows.Forms.TextBox
    Friend WithEvents gb_TarjetaCyD As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Tarjeta4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Tarjeta3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Tarjeta2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Tarjeta1 As System.Windows.Forms.TextBox
    Friend WithEvents gb_PagoEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents txt_CambioEfe As System.Windows.Forms.TextBox
    Friend WithEvents txt_RecibeEfe As System.Windows.Forms.TextBox
    Friend WithEvents txt_TotalEfe As System.Windows.Forms.TextBox
    Friend WithEvents txt_DescuentoEfe As System.Windows.Forms.TextBox
    Friend WithEvents txt_SubtotalEfe As System.Windows.Forms.TextBox
    Friend WithEvents txt_RecibeTar As System.Windows.Forms.TextBox
    Friend WithEvents txt_Autorizacion As System.Windows.Forms.TextBox
    Friend WithEvents gb_Cheque As System.Windows.Forms.GroupBox
    Friend WithEvents txt_RecibeChe As System.Windows.Forms.TextBox
    Friend WithEvents txt_NoCheque As System.Windows.Forms.TextBox
    Friend WithEvents txt_NoCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txt_RutaBancaria As System.Windows.Forms.TextBox
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Pagar As System.Windows.Forms.Button
    Friend WithEvents lbl_CambioEfe As System.Windows.Forms.Label
    Friend WithEvents lbl_RecibeEfe As System.Windows.Forms.Label
    Friend WithEvents lbl_TotalEfe As System.Windows.Forms.Label
    Friend WithEvents lbl_DescuentoEfe As System.Windows.Forms.Label
    Friend WithEvents lbl_SubtotalEfe As System.Windows.Forms.Label
    Friend WithEvents lbl_Distribuidor As System.Windows.Forms.Label
    Friend WithEvents cb_Emisor As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_RecibeTarj As System.Windows.Forms.Label
    Friend WithEvents lbl_Autorizacion As System.Windows.Forms.Label
    Friend WithEvents lbl_NoTarjeta As System.Windows.Forms.Label
    Friend WithEvents lbl_Emisor As System.Windows.Forms.Label
    Friend WithEvents btn_Cambiar As System.Windows.Forms.Button
    Friend WithEvents lbl_RecibeChe As System.Windows.Forms.Label
    Friend WithEvents lbl_NoCheque As System.Windows.Forms.Label
    Friend WithEvents lbl_NoCuenta As System.Windows.Forms.Label
    Friend WithEvents lbl_RutaBancaria As System.Windows.Forms.Label
    Friend WithEvents lbl_Folio As System.Windows.Forms.Label
    Friend WithEvents txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents gb_Activos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ActFactura As System.Windows.Forms.Button
    Friend WithEvents btn_ActFotos As System.Windows.Forms.Button
    Friend WithEvents cb_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents txt_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Importe As System.Windows.Forms.Label
    Friend WithEvents lbl_Comercial As System.Windows.Forms.Label
    Friend WithEvents lbl_NumSerie As System.Windows.Forms.Label
    Friend WithEvents lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents lbl_Tipo As System.Windows.Forms.Label
    Friend WithEvents lbl_Articulo As System.Windows.Forms.Label
    Friend WithEvents txt_ImporteAdquirido As System.Windows.Forms.TextBox
    Friend WithEvents txt_ImpComercial As System.Windows.Forms.TextBox
    Friend WithEvents txt_NumSerie As System.Windows.Forms.TextBox
    Friend WithEvents txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents rb_ActUsado As System.Windows.Forms.RadioButton
    Friend WithEvents rb_ActNuevo As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_PendienteEfe As System.Windows.Forms.Label
    Friend WithEvents txt_PendienteEfe As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Comercio As System.Windows.Forms.Label
    Friend WithEvents txt_Comercio As System.Windows.Forms.TextBox
    Friend WithEvents btn_Dolares As System.Windows.Forms.Button
    Friend WithEvents gb_Dolares As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_DolPendiente As System.Windows.Forms.Label
    Friend WithEvents txt_DolPendiente As System.Windows.Forms.TextBox
    Friend WithEvents lbl_DolCambio As System.Windows.Forms.Label
    Friend WithEvents lbl_DolRecibe As System.Windows.Forms.Label
    Friend WithEvents lbl_DolTotal As System.Windows.Forms.Label
    Friend WithEvents lbl_DolDescuento As System.Windows.Forms.Label
    Friend WithEvents lbl_DolSubtotal As System.Windows.Forms.Label
    Friend WithEvents txt_DolCambio As System.Windows.Forms.TextBox
    Friend WithEvents txt_DolRecibe As System.Windows.Forms.TextBox
    Friend WithEvents txt_DolTotal As System.Windows.Forms.TextBox
    Friend WithEvents txt_DolDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txt_DolSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_DolTipoCambio As System.Windows.Forms.Label
    Friend WithEvents txt_DolTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Dol2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dol1 As System.Windows.Forms.Label
    Friend WithEvents lbl_DolPesos As System.Windows.Forms.Label
    Friend WithEvents lbl_DolDolares As System.Windows.Forms.Label
    Friend WithEvents lbl_Dol5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dol4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dol3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dol6 As System.Windows.Forms.Label
End Class
