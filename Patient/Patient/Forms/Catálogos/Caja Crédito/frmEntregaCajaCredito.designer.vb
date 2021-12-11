<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregaCajaCredito
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnl_Botones = New System.Windows.Forms.Panel
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.btn_Aceptar = New System.Windows.Forms.Button
        Me.DGridFormasPagoEfe = New System.Windows.Forms.DataGridView
        Me.col_FormaPago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Efectivo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGridFormasPagoTarChe = New System.Windows.Forms.DataGridView
        Me.col_FormaPagoTarChe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_ImporteTarChe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_CantidadTarChe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGridFormasPagoAct = New System.Windows.Forms.DataGridView
        Me.col_FormaPagoAct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_ImporteAct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl_Activos = New System.Windows.Forms.Label
        Me.UP_Activos = New System.Windows.Forms.DomainUpDown
        Me.lbl_totEfe = New System.Windows.Forms.Label
        Me.lbl_TotTarChe = New System.Windows.Forms.Label
        Me.lbl_TotAct = New System.Windows.Forms.Label
        Me.lbl_Total = New System.Windows.Forms.Label
        Me.DGridDolares = New System.Windows.Forms.DataGridView
        Me.col_DolForma = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_DolDolares = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnl_Botones.SuspendLayout()
        CType(Me.DGridFormasPagoEfe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGridFormasPagoTarChe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGridFormasPagoAct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGridDolares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 351)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(974, 70)
        Me.pnl_Botones.TabIndex = 13
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.White
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelar.Location = New System.Drawing.Point(822, 0)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Cancelar.TabIndex = 1
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.BackColor = System.Drawing.Color.White
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.Location = New System.Drawing.Point(896, 0)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Aceptar.TabIndex = 0
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'DGridFormasPagoEfe
        '
        Me.DGridFormasPagoEfe.AllowUserToAddRows = False
        Me.DGridFormasPagoEfe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGridFormasPagoEfe.BackgroundColor = System.Drawing.Color.White
        Me.DGridFormasPagoEfe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridFormasPagoEfe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DGridFormasPagoEfe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridFormasPagoEfe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_FormaPago, Me.col_importe, Me.col_Cantidad, Me.col_Efectivo})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridFormasPagoEfe.DefaultCellStyle = DataGridViewCellStyle16
        Me.DGridFormasPagoEfe.Location = New System.Drawing.Point(12, 8)
        Me.DGridFormasPagoEfe.Name = "DGridFormasPagoEfe"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridFormasPagoEfe.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DGridFormasPagoEfe.RowHeadersVisible = False
        Me.DGridFormasPagoEfe.Size = New System.Drawing.Size(454, 144)
        Me.DGridFormasPagoEfe.TabIndex = 14
        '
        'col_FormaPago
        '
        Me.col_FormaPago.HeaderText = "Forma de Pago"
        Me.col_FormaPago.Name = "col_FormaPago"
        Me.col_FormaPago.ReadOnly = True
        '
        'col_importe
        '
        Me.col_importe.HeaderText = "Denominación"
        Me.col_importe.Name = "col_importe"
        Me.col_importe.ReadOnly = True
        '
        'col_Cantidad
        '
        Me.col_Cantidad.HeaderText = "Cantidad"
        Me.col_Cantidad.Name = "col_Cantidad"
        '
        'col_Efectivo
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "C2"
        Me.col_Efectivo.DefaultCellStyle = DataGridViewCellStyle15
        Me.col_Efectivo.HeaderText = "Importe"
        Me.col_Efectivo.Name = "col_Efectivo"
        Me.col_Efectivo.ReadOnly = True
        '
        'DGridFormasPagoTarChe
        '
        Me.DGridFormasPagoTarChe.AllowUserToAddRows = False
        Me.DGridFormasPagoTarChe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGridFormasPagoTarChe.BackgroundColor = System.Drawing.Color.White
        Me.DGridFormasPagoTarChe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridFormasPagoTarChe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DGridFormasPagoTarChe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridFormasPagoTarChe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_FormaPagoTarChe, Me.col_ImporteTarChe, Me.col_CantidadTarChe})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridFormasPagoTarChe.DefaultCellStyle = DataGridViewCellStyle19
        Me.DGridFormasPagoTarChe.Location = New System.Drawing.Point(472, 8)
        Me.DGridFormasPagoTarChe.Name = "DGridFormasPagoTarChe"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridFormasPagoTarChe.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.DGridFormasPagoTarChe.RowHeadersVisible = False
        Me.DGridFormasPagoTarChe.Size = New System.Drawing.Size(454, 103)
        Me.DGridFormasPagoTarChe.TabIndex = 15
        '
        'col_FormaPagoTarChe
        '
        Me.col_FormaPagoTarChe.HeaderText = "Formas de Pago"
        Me.col_FormaPagoTarChe.Name = "col_FormaPagoTarChe"
        Me.col_FormaPagoTarChe.ReadOnly = True
        '
        'col_ImporteTarChe
        '
        Me.col_ImporteTarChe.HeaderText = "Importe"
        Me.col_ImporteTarChe.Name = "col_ImporteTarChe"
        '
        'col_CantidadTarChe
        '
        Me.col_CantidadTarChe.HeaderText = "Vouchers/Cheques"
        Me.col_CantidadTarChe.Name = "col_CantidadTarChe"
        '
        'DGridFormasPagoAct
        '
        Me.DGridFormasPagoAct.AllowUserToAddRows = False
        Me.DGridFormasPagoAct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGridFormasPagoAct.BackgroundColor = System.Drawing.Color.White
        Me.DGridFormasPagoAct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridFormasPagoAct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DGridFormasPagoAct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridFormasPagoAct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_FormaPagoAct, Me.col_Articulo, Me.col_ImporteAct})
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridFormasPagoAct.DefaultCellStyle = DataGridViewCellStyle22
        Me.DGridFormasPagoAct.Location = New System.Drawing.Point(472, 189)
        Me.DGridFormasPagoAct.Name = "DGridFormasPagoAct"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridFormasPagoAct.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.DGridFormasPagoAct.RowHeadersVisible = False
        Me.DGridFormasPagoAct.Size = New System.Drawing.Size(454, 82)
        Me.DGridFormasPagoAct.TabIndex = 16
        '
        'col_FormaPagoAct
        '
        Me.col_FormaPagoAct.HeaderText = "Forma de Pago"
        Me.col_FormaPagoAct.Name = "col_FormaPagoAct"
        Me.col_FormaPagoAct.ReadOnly = True
        '
        'col_Articulo
        '
        Me.col_Articulo.HeaderText = "Articulo"
        Me.col_Articulo.Name = "col_Articulo"
        '
        'col_ImporteAct
        '
        Me.col_ImporteAct.HeaderText = "Importe"
        Me.col_ImporteAct.Name = "col_ImporteAct"
        '
        'lbl_Activos
        '
        Me.lbl_Activos.AutoSize = True
        Me.lbl_Activos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Activos.Location = New System.Drawing.Point(794, 165)
        Me.lbl_Activos.Name = "lbl_Activos"
        Me.lbl_Activos.Size = New System.Drawing.Size(79, 16)
        Me.lbl_Activos.TabIndex = 17
        Me.lbl_Activos.Text = "N° Activos"
        '
        'UP_Activos
        '
        Me.UP_Activos.Items.Add("0")
        Me.UP_Activos.Items.Add("1")
        Me.UP_Activos.Items.Add("2")
        Me.UP_Activos.Items.Add("3")
        Me.UP_Activos.Items.Add("4")
        Me.UP_Activos.Items.Add("5")
        Me.UP_Activos.Items.Add("6")
        Me.UP_Activos.Items.Add("7")
        Me.UP_Activos.Items.Add("8")
        Me.UP_Activos.Items.Add("9")
        Me.UP_Activos.Items.Add("10")
        Me.UP_Activos.Items.Add("11")
        Me.UP_Activos.Items.Add("12")
        Me.UP_Activos.Items.Add("13")
        Me.UP_Activos.Items.Add("14")
        Me.UP_Activos.Items.Add("15")
        Me.UP_Activos.Location = New System.Drawing.Point(879, 165)
        Me.UP_Activos.Name = "UP_Activos"
        Me.UP_Activos.ReadOnly = True
        Me.UP_Activos.Size = New System.Drawing.Size(47, 20)
        Me.UP_Activos.TabIndex = 18
        Me.UP_Activos.Text = "0"
        Me.UP_Activos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_totEfe
        '
        Me.lbl_totEfe.AutoSize = True
        Me.lbl_totEfe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totEfe.Location = New System.Drawing.Point(314, 155)
        Me.lbl_totEfe.Name = "lbl_totEfe"
        Me.lbl_totEfe.Size = New System.Drawing.Size(0, 16)
        Me.lbl_totEfe.TabIndex = 19
        '
        'lbl_TotTarChe
        '
        Me.lbl_TotTarChe.AutoSize = True
        Me.lbl_TotTarChe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotTarChe.Location = New System.Drawing.Point(774, 117)
        Me.lbl_TotTarChe.Name = "lbl_TotTarChe"
        Me.lbl_TotTarChe.Size = New System.Drawing.Size(0, 16)
        Me.lbl_TotTarChe.TabIndex = 20
        '
        'lbl_TotAct
        '
        Me.lbl_TotAct.AutoSize = True
        Me.lbl_TotAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotAct.Location = New System.Drawing.Point(799, 295)
        Me.lbl_TotAct.Name = "lbl_TotAct"
        Me.lbl_TotAct.Size = New System.Drawing.Size(0, 16)
        Me.lbl_TotAct.TabIndex = 21
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(799, 323)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(0, 16)
        Me.lbl_Total.TabIndex = 22
        '
        'DGridDolares
        '
        Me.DGridDolares.AllowUserToAddRows = False
        Me.DGridDolares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGridDolares.BackgroundColor = System.Drawing.Color.White
        Me.DGridDolares.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridDolares.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.DGridDolares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridDolares.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_DolForma, Me.col_DolDolares})
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridDolares.DefaultCellStyle = DataGridViewCellStyle25
        Me.DGridDolares.Location = New System.Drawing.Point(12, 189)
        Me.DGridDolares.Name = "DGridDolares"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridDolares.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.DGridDolares.RowHeadersVisible = False
        Me.DGridDolares.Size = New System.Drawing.Size(454, 61)
        Me.DGridDolares.TabIndex = 23
        '
        'col_DolForma
        '
        Me.col_DolForma.HeaderText = "Formas de Pago"
        Me.col_DolForma.Name = "col_DolForma"
        Me.col_DolForma.ReadOnly = True
        '
        'col_DolDolares
        '
        Me.col_DolDolares.HeaderText = "Importe"
        Me.col_DolDolares.Name = "col_DolDolares"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(314, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 16)
        Me.Label1.TabIndex = 24
        '
        'frmEntregaCajaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(974, 421)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGridDolares)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.lbl_TotAct)
        Me.Controls.Add(Me.lbl_TotTarChe)
        Me.Controls.Add(Me.lbl_totEfe)
        Me.Controls.Add(Me.UP_Activos)
        Me.Controls.Add(Me.lbl_Activos)
        Me.Controls.Add(Me.DGridFormasPagoAct)
        Me.Controls.Add(Me.DGridFormasPagoTarChe)
        Me.Controls.Add(Me.DGridFormasPagoEfe)
        Me.Controls.Add(Me.pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmEntregaCajaCredito"
        Me.Text = "Entrega de Caja"
        Me.pnl_Botones.ResumeLayout(False)
        CType(Me.DGridFormasPagoEfe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGridFormasPagoTarChe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGridFormasPagoAct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGridDolares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents DGridFormasPagoEfe As System.Windows.Forms.DataGridView
    Friend WithEvents DGridFormasPagoTarChe As System.Windows.Forms.DataGridView
    Friend WithEvents DGridFormasPagoAct As System.Windows.Forms.DataGridView
    Friend WithEvents col_FormaPagoAct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Articulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_ImporteAct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_Activos As System.Windows.Forms.Label
    Friend WithEvents UP_Activos As System.Windows.Forms.DomainUpDown
    Friend WithEvents col_FormaPagoTarChe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_ImporteTarChe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_CantidadTarChe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_totEfe As System.Windows.Forms.Label
    Friend WithEvents lbl_TotTarChe As System.Windows.Forms.Label
    Friend WithEvents lbl_TotAct As System.Windows.Forms.Label
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents col_FormaPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Efectivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGridDolares As System.Windows.Forms.DataGridView
    Friend WithEvents col_DolForma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_DolDolares As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
