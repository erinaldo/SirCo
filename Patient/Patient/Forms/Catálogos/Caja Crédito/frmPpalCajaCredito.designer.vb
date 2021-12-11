<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalCajaCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalCajaCredito))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Distrib = New System.Windows.Forms.Panel()
        Me.Lbl_TipoDistrib = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Vencido1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Disponible = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Saldo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_LimiteCredito = New System.Windows.Forms.TextBox()
        Me.lbl_Distribuidor = New System.Windows.Forms.Label()
        Me.dt_Fecha = New System.Windows.Forms.DateTimePicker()
        Me.txt_NombreDistrib = New System.Windows.Forms.TextBox()
        Me.txt_Distrib = New System.Windows.Forms.TextBox()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_DesctoEspecial = New System.Windows.Forms.Button()
        Me.btn_Movimientos = New System.Windows.Forms.Button()
        Me.btn_Entrega = New System.Windows.Forms.Button()
        Me.btn_Nuevo = New System.Windows.Forms.Button()
        Me.btn_Pagar = New System.Windows.Forms.Button()
        Me.pnl_Pago = New System.Windows.Forms.Panel()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.btn_Historial = New System.Windows.Forms.Button()
        Me.txt_DescuentoAdicional = New System.Windows.Forms.TextBox()
        Me.btn_DetalladoPago = New System.Windows.Forms.Button()
        Me.lbl_PorcAdicional = New System.Windows.Forms.Label()
        Me.txt_Adicional = New System.Windows.Forms.TextBox()
        Me.lbl_Adicional = New System.Windows.Forms.Label()
        Me.btn_Invertir = New System.Windows.Forms.Button()
        Me.btn_Regresar = New System.Windows.Forms.Button()
        Me.lbl_PorcDescto = New System.Windows.Forms.Label()
        Me.txt_PorcDescto = New System.Windows.Forms.TextBox()
        Me.lbl_Vencido = New System.Windows.Forms.Label()
        Me.txt_Vencido = New System.Windows.Forms.TextBox()
        Me.lbl_Descuento = New System.Windows.Forms.Label()
        Me.txt_Descuento = New System.Windows.Forms.TextBox()
        Me.lbl_Pagar = New System.Windows.Forms.Label()
        Me.lbl_Subtotal = New System.Windows.Forms.Label()
        Me.txt_Subtotal = New System.Windows.Forms.TextBox()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.txt_Pagar = New System.Windows.Forms.TextBox()
        Me.pnl_Distrib.SuspendLayout()
        Me.pnl_Botones.SuspendLayout()
        Me.pnl_Pago.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Distrib
        '
        Me.pnl_Distrib.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnl_Distrib.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Distrib.Controls.Add(Me.Lbl_TipoDistrib)
        Me.pnl_Distrib.Controls.Add(Me.Label4)
        Me.pnl_Distrib.Controls.Add(Me.Txt_Vencido1)
        Me.pnl_Distrib.Controls.Add(Me.Label3)
        Me.pnl_Distrib.Controls.Add(Me.Txt_Disponible)
        Me.pnl_Distrib.Controls.Add(Me.Label2)
        Me.pnl_Distrib.Controls.Add(Me.Txt_Saldo)
        Me.pnl_Distrib.Controls.Add(Me.Label1)
        Me.pnl_Distrib.Controls.Add(Me.Txt_LimiteCredito)
        Me.pnl_Distrib.Controls.Add(Me.lbl_Distribuidor)
        Me.pnl_Distrib.Controls.Add(Me.dt_Fecha)
        Me.pnl_Distrib.Controls.Add(Me.txt_NombreDistrib)
        Me.pnl_Distrib.Controls.Add(Me.txt_Distrib)
        Me.pnl_Distrib.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Distrib.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Distrib.Name = "pnl_Distrib"
        Me.pnl_Distrib.Size = New System.Drawing.Size(1157, 93)
        Me.pnl_Distrib.TabIndex = 0
        '
        'Lbl_TipoDistrib
        '
        Me.Lbl_TipoDistrib.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Lbl_TipoDistrib.AutoSize = True
        Me.Lbl_TipoDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_TipoDistrib.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_TipoDistrib.Location = New System.Drawing.Point(680, 14)
        Me.Lbl_TipoDistrib.Name = "Lbl_TipoDistrib"
        Me.Lbl_TipoDistrib.Size = New System.Drawing.Size(0, 20)
        Me.Lbl_TipoDistrib.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(774, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Vencido"
        '
        'Txt_Vencido1
        '
        Me.Txt_Vencido1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Txt_Vencido1.Enabled = False
        Me.Txt_Vencido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vencido1.Location = New System.Drawing.Point(857, 48)
        Me.Txt_Vencido1.MaxLength = 6
        Me.Txt_Vencido1.Name = "Txt_Vencido1"
        Me.Txt_Vencido1.Size = New System.Drawing.Size(136, 29)
        Me.Txt_Vencido1.TabIndex = 25
        Me.Txt_Vencido1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(528, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Disponible"
        '
        'Txt_Disponible
        '
        Me.Txt_Disponible.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Txt_Disponible.Enabled = False
        Me.Txt_Disponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Disponible.Location = New System.Drawing.Point(617, 48)
        Me.Txt_Disponible.MaxLength = 6
        Me.Txt_Disponible.Name = "Txt_Disponible"
        Me.Txt_Disponible.Size = New System.Drawing.Size(136, 29)
        Me.Txt_Disponible.TabIndex = 23
        Me.Txt_Disponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(313, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Saldo"
        '
        'Txt_Saldo
        '
        Me.Txt_Saldo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Txt_Saldo.Enabled = False
        Me.Txt_Saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Saldo.Location = New System.Drawing.Point(361, 48)
        Me.Txt_Saldo.MaxLength = 6
        Me.Txt_Saldo.Name = "Txt_Saldo"
        Me.Txt_Saldo.Size = New System.Drawing.Size(136, 29)
        Me.Txt_Saldo.TabIndex = 21
        Me.Txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(2, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Línea de Crédito"
        '
        'Txt_LimiteCredito
        '
        Me.Txt_LimiteCredito.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Txt_LimiteCredito.Enabled = False
        Me.Txt_LimiteCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteCredito.Location = New System.Drawing.Point(149, 48)
        Me.Txt_LimiteCredito.MaxLength = 6
        Me.Txt_LimiteCredito.Name = "Txt_LimiteCredito"
        Me.Txt_LimiteCredito.Size = New System.Drawing.Size(136, 29)
        Me.Txt_LimiteCredito.TabIndex = 19
        Me.Txt_LimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_Distribuidor
        '
        Me.lbl_Distribuidor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_Distribuidor.AutoSize = True
        Me.lbl_Distribuidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Distribuidor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Distribuidor.Location = New System.Drawing.Point(4, 13)
        Me.lbl_Distribuidor.Name = "lbl_Distribuidor"
        Me.lbl_Distribuidor.Size = New System.Drawing.Size(139, 20)
        Me.lbl_Distribuidor.TabIndex = 18
        Me.lbl_Distribuidor.Text = "DISTRIBUIDOR"
        '
        'dt_Fecha
        '
        Me.dt_Fecha.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.dt_Fecha.CalendarTrailingForeColor = System.Drawing.SystemColors.Window
        Me.dt_Fecha.Enabled = False
        Me.dt_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt_Fecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dt_Fecha.Location = New System.Drawing.Point(803, 10)
        Me.dt_Fecha.Name = "dt_Fecha"
        Me.dt_Fecha.Size = New System.Drawing.Size(339, 29)
        Me.dt_Fecha.TabIndex = 2
        '
        'txt_NombreDistrib
        '
        Me.txt_NombreDistrib.BackColor = System.Drawing.SystemColors.Window
        Me.txt_NombreDistrib.Enabled = False
        Me.txt_NombreDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NombreDistrib.Location = New System.Drawing.Point(255, 10)
        Me.txt_NombreDistrib.Name = "txt_NombreDistrib"
        Me.txt_NombreDistrib.ReadOnly = True
        Me.txt_NombreDistrib.Size = New System.Drawing.Size(410, 29)
        Me.txt_NombreDistrib.TabIndex = 1
        '
        'txt_Distrib
        '
        Me.txt_Distrib.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Distrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Distrib.Location = New System.Drawing.Point(149, 10)
        Me.txt_Distrib.MaxLength = 6
        Me.txt_Distrib.Name = "txt_Distrib"
        Me.txt_Distrib.Size = New System.Drawing.Size(100, 29)
        Me.txt_Distrib.TabIndex = 0
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_DesctoEspecial)
        Me.pnl_Botones.Controls.Add(Me.btn_Movimientos)
        Me.pnl_Botones.Controls.Add(Me.btn_Entrega)
        Me.pnl_Botones.Controls.Add(Me.btn_Nuevo)
        Me.pnl_Botones.Controls.Add(Me.btn_Pagar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 394)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(1157, 80)
        Me.pnl_Botones.TabIndex = 1
        '
        'btn_DesctoEspecial
        '
        Me.btn_DesctoEspecial.BackColor = System.Drawing.Color.White
        Me.btn_DesctoEspecial.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_DesctoEspecial.Image = CType(resources.GetObject("btn_DesctoEspecial.Image"), System.Drawing.Image)
        Me.btn_DesctoEspecial.Location = New System.Drawing.Point(166, 0)
        Me.btn_DesctoEspecial.Name = "btn_DesctoEspecial"
        Me.btn_DesctoEspecial.Size = New System.Drawing.Size(83, 76)
        Me.btn_DesctoEspecial.TabIndex = 4
        Me.btn_DesctoEspecial.Text = "&Descuento"
        Me.btn_DesctoEspecial.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_DesctoEspecial.UseVisualStyleBackColor = False
        '
        'btn_Movimientos
        '
        Me.btn_Movimientos.BackColor = System.Drawing.Color.White
        Me.btn_Movimientos.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Movimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Movimientos.Image = Global.SIRCO.My.Resources.Resources.emblem_money
        Me.btn_Movimientos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Movimientos.Location = New System.Drawing.Point(987, 0)
        Me.btn_Movimientos.Name = "btn_Movimientos"
        Me.btn_Movimientos.Size = New System.Drawing.Size(83, 76)
        Me.btn_Movimientos.TabIndex = 3
        Me.btn_Movimientos.Text = "&Movimientos Especiales"
        Me.btn_Movimientos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Movimientos.UseVisualStyleBackColor = False
        '
        'btn_Entrega
        '
        Me.btn_Entrega.BackColor = System.Drawing.Color.White
        Me.btn_Entrega.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Entrega.Image = Global.SIRCO.My.Resources.Resources.NOMINA11
        Me.btn_Entrega.Location = New System.Drawing.Point(83, 0)
        Me.btn_Entrega.Name = "btn_Entrega"
        Me.btn_Entrega.Size = New System.Drawing.Size(83, 76)
        Me.btn_Entrega.TabIndex = 2
        Me.btn_Entrega.Text = "&Entrega"
        Me.btn_Entrega.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Entrega.UseVisualStyleBackColor = False
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.BackColor = System.Drawing.Color.White
        Me.btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.document
        Me.btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Nuevo.Location = New System.Drawing.Point(0, 0)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(83, 76)
        Me.btn_Nuevo.TabIndex = 1
        Me.btn_Nuevo.Text = "&Nuevo Pago"
        Me.btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Nuevo.UseVisualStyleBackColor = False
        '
        'btn_Pagar
        '
        Me.btn_Pagar.BackColor = System.Drawing.Color.White
        Me.btn_Pagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Pagar.Image = Global.SIRCO.My.Resources.Resources.ok_bag
        Me.btn_Pagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Pagar.Location = New System.Drawing.Point(1070, 0)
        Me.btn_Pagar.Name = "btn_Pagar"
        Me.btn_Pagar.Size = New System.Drawing.Size(83, 76)
        Me.btn_Pagar.TabIndex = 0
        Me.btn_Pagar.Text = "&Pagar"
        Me.btn_Pagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Pagar.UseVisualStyleBackColor = False
        '
        'pnl_Pago
        '
        Me.pnl_Pago.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnl_Pago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Pago.Controls.Add(Me.Btn_Excel)
        Me.pnl_Pago.Controls.Add(Me.btn_Historial)
        Me.pnl_Pago.Controls.Add(Me.txt_DescuentoAdicional)
        Me.pnl_Pago.Controls.Add(Me.btn_DetalladoPago)
        Me.pnl_Pago.Controls.Add(Me.lbl_PorcAdicional)
        Me.pnl_Pago.Controls.Add(Me.txt_Adicional)
        Me.pnl_Pago.Controls.Add(Me.lbl_Adicional)
        Me.pnl_Pago.Controls.Add(Me.btn_Invertir)
        Me.pnl_Pago.Controls.Add(Me.btn_Regresar)
        Me.pnl_Pago.Controls.Add(Me.lbl_PorcDescto)
        Me.pnl_Pago.Controls.Add(Me.txt_PorcDescto)
        Me.pnl_Pago.Controls.Add(Me.lbl_Vencido)
        Me.pnl_Pago.Controls.Add(Me.txt_Vencido)
        Me.pnl_Pago.Controls.Add(Me.lbl_Descuento)
        Me.pnl_Pago.Controls.Add(Me.txt_Descuento)
        Me.pnl_Pago.Controls.Add(Me.lbl_Pagar)
        Me.pnl_Pago.Controls.Add(Me.lbl_Subtotal)
        Me.pnl_Pago.Controls.Add(Me.txt_Subtotal)
        Me.pnl_Pago.Controls.Add(Me.DGrid)
        Me.pnl_Pago.Controls.Add(Me.txt_Pagar)
        Me.pnl_Pago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Pago.Location = New System.Drawing.Point(0, 93)
        Me.pnl_Pago.Name = "pnl_Pago"
        Me.pnl_Pago.Size = New System.Drawing.Size(1157, 301)
        Me.pnl_Pago.TabIndex = 1
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.excel
        Me.Btn_Excel.Location = New System.Drawing.Point(992, 187)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(33, 31)
        Me.Btn_Excel.TabIndex = 28
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'btn_Historial
        '
        Me.btn_Historial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Historial.Image = Global.SIRCO.My.Resources.Resources.resurtir
        Me.btn_Historial.Location = New System.Drawing.Point(13, 187)
        Me.btn_Historial.Name = "btn_Historial"
        Me.btn_Historial.Size = New System.Drawing.Size(33, 31)
        Me.btn_Historial.TabIndex = 27
        Me.btn_Historial.UseVisualStyleBackColor = True
        Me.btn_Historial.Visible = False
        '
        'txt_DescuentoAdicional
        '
        Me.txt_DescuentoAdicional.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_DescuentoAdicional.BackColor = System.Drawing.Color.White
        Me.txt_DescuentoAdicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DescuentoAdicional.Location = New System.Drawing.Point(583, 235)
        Me.txt_DescuentoAdicional.Name = "txt_DescuentoAdicional"
        Me.txt_DescuentoAdicional.ReadOnly = True
        Me.txt_DescuentoAdicional.Size = New System.Drawing.Size(157, 35)
        Me.txt_DescuentoAdicional.TabIndex = 26
        Me.txt_DescuentoAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_DetalladoPago
        '
        Me.btn_DetalladoPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_DetalladoPago.Image = Global.SIRCO.My.Resources.Resources.zoom
        Me.btn_DetalladoPago.Location = New System.Drawing.Point(1070, 187)
        Me.btn_DetalladoPago.Name = "btn_DetalladoPago"
        Me.btn_DetalladoPago.Size = New System.Drawing.Size(33, 31)
        Me.btn_DetalladoPago.TabIndex = 25
        Me.btn_DetalladoPago.UseVisualStyleBackColor = True
        Me.btn_DetalladoPago.Visible = False
        '
        'lbl_PorcAdicional
        '
        Me.lbl_PorcAdicional.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_PorcAdicional.AutoSize = True
        Me.lbl_PorcAdicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PorcAdicional.Location = New System.Drawing.Point(552, 242)
        Me.lbl_PorcAdicional.Name = "lbl_PorcAdicional"
        Me.lbl_PorcAdicional.Size = New System.Drawing.Size(25, 24)
        Me.lbl_PorcAdicional.TabIndex = 24
        Me.lbl_PorcAdicional.Text = "%"
        '
        'txt_Adicional
        '
        Me.txt_Adicional.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_Adicional.BackColor = System.Drawing.Color.White
        Me.txt_Adicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Adicional.Location = New System.Drawing.Point(482, 236)
        Me.txt_Adicional.Name = "txt_Adicional"
        Me.txt_Adicional.ReadOnly = True
        Me.txt_Adicional.Size = New System.Drawing.Size(64, 35)
        Me.txt_Adicional.TabIndex = 23
        Me.txt_Adicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_Adicional
        '
        Me.lbl_Adicional.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_Adicional.AutoSize = True
        Me.lbl_Adicional.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Adicional.Location = New System.Drawing.Point(367, 242)
        Me.lbl_Adicional.Name = "lbl_Adicional"
        Me.lbl_Adicional.Size = New System.Drawing.Size(109, 24)
        Me.lbl_Adicional.TabIndex = 22
        Me.lbl_Adicional.Text = "ADICIONAL"
        '
        'btn_Invertir
        '
        Me.btn_Invertir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Invertir.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.btn_Invertir.Location = New System.Drawing.Point(1109, 187)
        Me.btn_Invertir.Name = "btn_Invertir"
        Me.btn_Invertir.Size = New System.Drawing.Size(33, 31)
        Me.btn_Invertir.TabIndex = 21
        Me.btn_Invertir.UseVisualStyleBackColor = True
        Me.btn_Invertir.Visible = False
        '
        'btn_Regresar
        '
        Me.btn_Regresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Regresar.Image = Global.SIRCO.My.Resources.Resources.retornar
        Me.btn_Regresar.Location = New System.Drawing.Point(1031, 187)
        Me.btn_Regresar.Name = "btn_Regresar"
        Me.btn_Regresar.Size = New System.Drawing.Size(33, 31)
        Me.btn_Regresar.TabIndex = 20
        Me.btn_Regresar.UseVisualStyleBackColor = True
        Me.btn_Regresar.Visible = False
        '
        'lbl_PorcDescto
        '
        Me.lbl_PorcDescto.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_PorcDescto.AutoSize = True
        Me.lbl_PorcDescto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PorcDescto.Location = New System.Drawing.Point(552, 199)
        Me.lbl_PorcDescto.Name = "lbl_PorcDescto"
        Me.lbl_PorcDescto.Size = New System.Drawing.Size(25, 24)
        Me.lbl_PorcDescto.TabIndex = 19
        Me.lbl_PorcDescto.Text = "%"
        '
        'txt_PorcDescto
        '
        Me.txt_PorcDescto.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_PorcDescto.BackColor = System.Drawing.Color.White
        Me.txt_PorcDescto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PorcDescto.Location = New System.Drawing.Point(482, 193)
        Me.txt_PorcDescto.Name = "txt_PorcDescto"
        Me.txt_PorcDescto.ReadOnly = True
        Me.txt_PorcDescto.Size = New System.Drawing.Size(64, 35)
        Me.txt_PorcDescto.TabIndex = 18
        Me.txt_PorcDescto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_Vencido
        '
        Me.lbl_Vencido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Vencido.AutoSize = True
        Me.lbl_Vencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Vencido.Location = New System.Drawing.Point(15, 199)
        Me.lbl_Vencido.Name = "lbl_Vencido"
        Me.lbl_Vencido.Size = New System.Drawing.Size(95, 24)
        Me.lbl_Vencido.TabIndex = 17
        Me.lbl_Vencido.Text = "VENCIDO"
        Me.lbl_Vencido.Visible = False
        '
        'txt_Vencido
        '
        Me.txt_Vencido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_Vencido.BackColor = System.Drawing.Color.White
        Me.txt_Vencido.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Vencido.Location = New System.Drawing.Point(116, 192)
        Me.txt_Vencido.Name = "txt_Vencido"
        Me.txt_Vencido.ReadOnly = True
        Me.txt_Vencido.Size = New System.Drawing.Size(157, 35)
        Me.txt_Vencido.TabIndex = 16
        Me.txt_Vencido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Vencido.Visible = False
        '
        'lbl_Descuento
        '
        Me.lbl_Descuento.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lbl_Descuento.AutoSize = True
        Me.lbl_Descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Descuento.Location = New System.Drawing.Point(348, 199)
        Me.lbl_Descuento.Name = "lbl_Descuento"
        Me.lbl_Descuento.Size = New System.Drawing.Size(128, 24)
        Me.lbl_Descuento.TabIndex = 15
        Me.lbl_Descuento.Text = "DESCUENTO"
        '
        'txt_Descuento
        '
        Me.txt_Descuento.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txt_Descuento.BackColor = System.Drawing.Color.White
        Me.txt_Descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Descuento.Location = New System.Drawing.Point(583, 192)
        Me.txt_Descuento.Name = "txt_Descuento"
        Me.txt_Descuento.ReadOnly = True
        Me.txt_Descuento.Size = New System.Drawing.Size(157, 35)
        Me.txt_Descuento.TabIndex = 14
        Me.txt_Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Pagar
        '
        Me.lbl_Pagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Pagar.AutoSize = True
        Me.lbl_Pagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Pagar.Location = New System.Drawing.Point(783, 239)
        Me.lbl_Pagar.Name = "lbl_Pagar"
        Me.lbl_Pagar.Size = New System.Drawing.Size(115, 29)
        Me.lbl_Pagar.TabIndex = 13
        Me.lbl_Pagar.Text = "A PAGAR"
        '
        'lbl_Subtotal
        '
        Me.lbl_Subtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Subtotal.AutoSize = True
        Me.lbl_Subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Subtotal.Location = New System.Drawing.Point(3, 242)
        Me.lbl_Subtotal.Name = "lbl_Subtotal"
        Me.lbl_Subtotal.Size = New System.Drawing.Size(109, 24)
        Me.lbl_Subtotal.TabIndex = 10
        Me.lbl_Subtotal.Text = "SUBTOTAL"
        '
        'txt_Subtotal
        '
        Me.txt_Subtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_Subtotal.BackColor = System.Drawing.Color.White
        Me.txt_Subtotal.Enabled = False
        Me.txt_Subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Subtotal.Location = New System.Drawing.Point(118, 235)
        Me.txt_Subtotal.Name = "txt_Subtotal"
        Me.txt_Subtotal.ReadOnly = True
        Me.txt_Subtotal.Size = New System.Drawing.Size(157, 35)
        Me.txt_Subtotal.TabIndex = 9
        Me.txt_Subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(1153, 186)
        Me.DGrid.TabIndex = 8
        '
        'txt_Pagar
        '
        Me.txt_Pagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Pagar.BackColor = System.Drawing.Color.White
        Me.txt_Pagar.Enabled = False
        Me.txt_Pagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Pagar.Location = New System.Drawing.Point(904, 218)
        Me.txt_Pagar.Name = "txt_Pagar"
        Me.txt_Pagar.ReadOnly = True
        Me.txt_Pagar.Size = New System.Drawing.Size(239, 56)
        Me.txt_Pagar.TabIndex = 7
        Me.txt_Pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPpalCajaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1157, 474)
        Me.Controls.Add(Me.pnl_Pago)
        Me.Controls.Add(Me.pnl_Botones)
        Me.Controls.Add(Me.pnl_Distrib)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPpalCajaCredito"
        Me.Text = "Caja de Crédito"
        Me.pnl_Distrib.ResumeLayout(False)
        Me.pnl_Distrib.PerformLayout()
        Me.pnl_Botones.ResumeLayout(False)
        Me.pnl_Pago.ResumeLayout(False)
        Me.pnl_Pago.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Distrib As System.Windows.Forms.Panel
    Friend WithEvents txt_NombreDistrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_Distrib As System.Windows.Forms.TextBox
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents pnl_Pago As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents txt_Pagar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Vencido As System.Windows.Forms.Label
    Friend WithEvents lbl_Descuento As System.Windows.Forms.Label
    Friend WithEvents txt_Descuento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Pagar As System.Windows.Forms.Label
    Friend WithEvents lbl_Subtotal As System.Windows.Forms.Label
    Friend WithEvents txt_Subtotal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Distribuidor As System.Windows.Forms.Label
    Friend WithEvents btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_Pagar As System.Windows.Forms.Button
    Friend WithEvents txt_Vencido As System.Windows.Forms.TextBox
    Friend WithEvents lbl_PorcDescto As System.Windows.Forms.Label
    Friend WithEvents txt_PorcDescto As System.Windows.Forms.TextBox
    Friend WithEvents btn_Regresar As System.Windows.Forms.Button
    Friend WithEvents btn_Entrega As System.Windows.Forms.Button
    Friend WithEvents btn_Invertir As System.Windows.Forms.Button
    Friend WithEvents lbl_PorcAdicional As System.Windows.Forms.Label
    Friend WithEvents txt_Adicional As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Adicional As System.Windows.Forms.Label
    Friend WithEvents btn_DetalladoPago As System.Windows.Forms.Button
    Friend WithEvents txt_DescuentoAdicional As System.Windows.Forms.TextBox
    Friend WithEvents btn_Movimientos As System.Windows.Forms.Button
    Friend WithEvents btn_DesctoEspecial As System.Windows.Forms.Button
    Friend WithEvents btn_Historial As System.Windows.Forms.Button
    Friend WithEvents dt_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Vencido1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Disponible As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Saldo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_LimiteCredito As TextBox
    Friend WithEvents Lbl_TipoDistrib As Label
    Friend WithEvents Btn_Excel As Button
End Class
