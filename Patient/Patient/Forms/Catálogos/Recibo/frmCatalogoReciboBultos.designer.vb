<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoReciboBultos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoReciboBultos))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.Pnl_Detalle = New System.Windows.Forms.Panel
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.Suc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pedido = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Bultos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Factura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaFactura = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox
        Me.Txt_Marca = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Cbo_Paqueteria = New System.Windows.Forms.ComboBox
        Me.Chk_SinFactura = New System.Windows.Forms.CheckBox
        Me.Opt_Devolucion = New System.Windows.Forms.RadioButton
        Me.Opt_Recibo = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_NombreEmpleado = New System.Windows.Forms.TextBox
        Me.Lbl_Asigna = New System.Windows.Forms.Label
        Me.Txt_IdEmpleado = New System.Windows.Forms.TextBox
        Me.Txt_Campo1 = New System.Windows.Forms.TextBox
        Me.Txt_Campo = New System.Windows.Forms.TextBox
        Me.Lbl_Folio = New System.Windows.Forms.Label
        Me.Txt_Folio = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Lbl_Proveedor = New System.Windows.Forms.Label
        Me.Txt_Raz_Soc = New System.Windows.Forms.TextBox
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Lbl_NoGuia = New System.Windows.Forms.Label
        Me.Txt_NoGuia = New System.Windows.Forms.TextBox
        Me.Lbl_Transporta = New System.Windows.Forms.Label
        Me.Txt_Transporta = New System.Windows.Forms.TextBox
        Me.Lbl_Bultos = New System.Windows.Forms.Label
        Me.Txt_NoBultos = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Comentarios = New System.Windows.Forms.TextBox
        Me.Lbl_Comentarios = New System.Windows.Forms.Label
        Me.Txt_DescripRecibe = New System.Windows.Forms.TextBox
        Me.Txt_Recibe = New System.Windows.Forms.TextBox
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Condiciones = New System.Windows.Forms.Button
        Me.Btn_Imprimir = New System.Windows.Forms.Button
        Me.Btn_Talon = New System.Windows.Forms.Button
        Me.Btn_Factura = New System.Windows.Forms.Button
        Me.Btn_IFE = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        Me.Pnl_Detalle.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Detalle)
        Me.Pnl_Grid.Controls.Add(Me.Panel1)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(848, 518)
        Me.Pnl_Grid.TabIndex = 4
        '
        'Pnl_Detalle
        '
        Me.Pnl_Detalle.Controls.Add(Me.DGrid)
        Me.Pnl_Detalle.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Detalle.Controls.Add(Me.Chk_SinFactura)
        Me.Pnl_Detalle.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Detalle.Controls.Add(Me.Label4)
        Me.Pnl_Detalle.Location = New System.Drawing.Point(4, 324)
        Me.Pnl_Detalle.Name = "Pnl_Detalle"
        Me.Pnl_Detalle.Size = New System.Drawing.Size(828, 186)
        Me.Pnl_Detalle.TabIndex = 501
        Me.Pnl_Detalle.Visible = False
        '
        'DGrid
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Suc, Me.Nombre, Me.Pedido, Me.Bultos, Me.Factura, Me.FechaFactura})
        Me.DGrid.Location = New System.Drawing.Point(78, 50)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(566, 118)
        Me.DGrid.TabIndex = 7
        '
        'Suc
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Suc.DefaultCellStyle = DataGridViewCellStyle2
        Me.Suc.HeaderText = "Det"
        Me.Suc.MaxInputLength = 2
        Me.Suc.Name = "Suc"
        Me.Suc.ReadOnly = True
        Me.Suc.Width = 40
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Sucursal"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Pedido
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Pedido.DefaultCellStyle = DataGridViewCellStyle3
        Me.Pedido.HeaderText = "Pedido"
        Me.Pedido.MaxInputLength = 8
        Me.Pedido.Name = "Pedido"
        Me.Pedido.ReadOnly = True
        '
        'Bultos
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Bultos.DefaultCellStyle = DataGridViewCellStyle4
        Me.Bultos.HeaderText = "Bultos"
        Me.Bultos.MaxInputLength = 4
        Me.Bultos.Name = "Bultos"
        Me.Bultos.ReadOnly = True
        Me.Bultos.Width = 50
        '
        'Factura
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Factura.DefaultCellStyle = DataGridViewCellStyle5
        Me.Factura.HeaderText = "Factura"
        Me.Factura.MaxInputLength = 20
        Me.Factura.Name = "Factura"
        Me.Factura.ReadOnly = True
        '
        'FechaFactura
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.FechaFactura.DefaultCellStyle = DataGridViewCellStyle6
        Me.FechaFactura.HeaderText = "Fecha Factura"
        Me.FechaFactura.MaxInputLength = 10
        Me.FechaFactura.Name = "FechaFactura"
        Me.FechaFactura.ReadOnly = True
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(128, 3)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(142, 20)
        Me.Txt_DescripMarca.TabIndex = 7
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Enabled = False
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(78, 3)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Marca.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Marca"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Cbo_Paqueteria)
        Me.Panel1.Controls.Add(Me.Opt_Devolucion)
        Me.Panel1.Controls.Add(Me.Opt_Recibo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Txt_NombreEmpleado)
        Me.Panel1.Controls.Add(Me.Lbl_Asigna)
        Me.Panel1.Controls.Add(Me.Txt_IdEmpleado)
        Me.Panel1.Controls.Add(Me.Txt_Campo1)
        Me.Panel1.Controls.Add(Me.Txt_Campo)
        Me.Panel1.Controls.Add(Me.Lbl_Folio)
        Me.Panel1.Controls.Add(Me.Txt_Folio)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Lbl_Proveedor)
        Me.Panel1.Controls.Add(Me.Txt_Raz_Soc)
        Me.Panel1.Controls.Add(Me.Txt_Proveedor)
        Me.Panel1.Controls.Add(Me.Lbl_NoGuia)
        Me.Panel1.Controls.Add(Me.Txt_NoGuia)
        Me.Panel1.Controls.Add(Me.Lbl_Transporta)
        Me.Panel1.Controls.Add(Me.Txt_Transporta)
        Me.Panel1.Controls.Add(Me.Lbl_Bultos)
        Me.Panel1.Controls.Add(Me.Txt_NoBultos)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Txt_Comentarios)
        Me.Panel1.Controls.Add(Me.Lbl_Comentarios)
        Me.Panel1.Controls.Add(Me.Txt_DescripRecibe)
        Me.Panel1.Controls.Add(Me.Txt_Recibe)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(832, 317)
        Me.Panel1.TabIndex = 500
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "Paquetería"
        '
        'Cbo_Paqueteria
        '
        Me.Cbo_Paqueteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cbo_Paqueteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Cbo_Paqueteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Paqueteria.FormattingEnabled = True
        Me.Cbo_Paqueteria.Location = New System.Drawing.Point(78, 149)
        Me.Cbo_Paqueteria.Name = "Cbo_Paqueteria"
        Me.Cbo_Paqueteria.Size = New System.Drawing.Size(318, 21)
        Me.Cbo_Paqueteria.TabIndex = 3
        '
        'Chk_SinFactura
        '
        Me.Chk_SinFactura.AutoSize = True
        Me.Chk_SinFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SinFactura.Location = New System.Drawing.Point(523, 3)
        Me.Chk_SinFactura.Name = "Chk_SinFactura"
        Me.Chk_SinFactura.Size = New System.Drawing.Size(121, 24)
        Me.Chk_SinFactura.TabIndex = 200
        Me.Chk_SinFactura.Text = "Sin Factura"
        Me.Chk_SinFactura.UseVisualStyleBackColor = True
        '
        'Opt_Devolucion
        '
        Me.Opt_Devolucion.AutoSize = True
        Me.Opt_Devolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Devolucion.Location = New System.Drawing.Point(181, 7)
        Me.Opt_Devolucion.Name = "Opt_Devolucion"
        Me.Opt_Devolucion.Size = New System.Drawing.Size(115, 24)
        Me.Opt_Devolucion.TabIndex = 196
        Me.Opt_Devolucion.Text = "Devolución"
        Me.Opt_Devolucion.UseVisualStyleBackColor = True
        '
        'Opt_Recibo
        '
        Me.Opt_Recibo.AutoSize = True
        Me.Opt_Recibo.Checked = True
        Me.Opt_Recibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Recibo.Location = New System.Drawing.Point(78, 7)
        Me.Opt_Recibo.Name = "Opt_Recibo"
        Me.Opt_Recibo.Size = New System.Drawing.Size(83, 24)
        Me.Opt_Recibo.TabIndex = 195
        Me.Opt_Recibo.TabStop = True
        Me.Opt_Recibo.Text = "Recibo"
        Me.Opt_Recibo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Tipo"
        '
        'Txt_NombreEmpleado
        '
        Me.Txt_NombreEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreEmpleado.Enabled = False
        Me.Txt_NombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreEmpleado.Location = New System.Drawing.Point(726, 174)
        Me.Txt_NombreEmpleado.MaxLength = 200
        Me.Txt_NombreEmpleado.Name = "Txt_NombreEmpleado"
        Me.Txt_NombreEmpleado.ReadOnly = True
        Me.Txt_NombreEmpleado.Size = New System.Drawing.Size(316, 20)
        Me.Txt_NombreEmpleado.TabIndex = 192
        Me.Txt_NombreEmpleado.Visible = False
        '
        'Lbl_Asigna
        '
        Me.Lbl_Asigna.AutoSize = True
        Me.Lbl_Asigna.Location = New System.Drawing.Point(698, 174)
        Me.Lbl_Asigna.Name = "Lbl_Asigna"
        Me.Lbl_Asigna.Size = New System.Drawing.Size(51, 13)
        Me.Lbl_Asigna.TabIndex = 193
        Me.Lbl_Asigna.Text = "Asignado"
        Me.Lbl_Asigna.Visible = False
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(745, 174)
        Me.Txt_IdEmpleado.MaxLength = 5
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.ReadOnly = True
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(44, 20)
        Me.Txt_IdEmpleado.TabIndex = 191
        Me.Txt_IdEmpleado.Visible = False
        '
        'Txt_Campo1
        '
        Me.Txt_Campo1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Campo1.Enabled = False
        Me.Txt_Campo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Campo1.Location = New System.Drawing.Point(698, 148)
        Me.Txt_Campo1.MaxLength = 30
        Me.Txt_Campo1.Name = "Txt_Campo1"
        Me.Txt_Campo1.ReadOnly = True
        Me.Txt_Campo1.Size = New System.Drawing.Size(270, 20)
        Me.Txt_Campo1.TabIndex = 190
        Me.Txt_Campo1.Visible = False
        '
        'Txt_Campo
        '
        Me.Txt_Campo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Campo.Enabled = False
        Me.Txt_Campo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Campo.Location = New System.Drawing.Point(698, 122)
        Me.Txt_Campo.MaxLength = 30
        Me.Txt_Campo.Name = "Txt_Campo"
        Me.Txt_Campo.ReadOnly = True
        Me.Txt_Campo.Size = New System.Drawing.Size(270, 20)
        Me.Txt_Campo.TabIndex = 189
        Me.Txt_Campo.Visible = False
        '
        'Lbl_Folio
        '
        Me.Lbl_Folio.AutoSize = True
        Me.Lbl_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Folio.Location = New System.Drawing.Point(614, 1)
        Me.Lbl_Folio.Name = "Lbl_Folio"
        Me.Lbl_Folio.Size = New System.Drawing.Size(57, 24)
        Me.Lbl_Folio.TabIndex = 187
        Me.Lbl_Folio.Text = "Folio"
        '
        'Txt_Folio
        '
        Me.Txt_Folio.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Folio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Folio.Location = New System.Drawing.Point(677, 1)
        Me.Txt_Folio.MaxLength = 8
        Me.Txt_Folio.Name = "Txt_Folio"
        Me.Txt_Folio.ReadOnly = True
        Me.Txt_Folio.Size = New System.Drawing.Size(145, 31)
        Me.Txt_Folio.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(459, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(320, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(402, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Fecha"
        '
        'Lbl_Proveedor
        '
        Me.Lbl_Proveedor.AutoSize = True
        Me.Lbl_Proveedor.Location = New System.Drawing.Point(11, 99)
        Me.Lbl_Proveedor.Name = "Lbl_Proveedor"
        Me.Lbl_Proveedor.Size = New System.Drawing.Size(56, 13)
        Me.Lbl_Proveedor.TabIndex = 180
        Me.Lbl_Proveedor.Text = "Proveedor"
        '
        'Txt_Raz_Soc
        '
        Me.Txt_Raz_Soc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Raz_Soc.Enabled = False
        Me.Txt_Raz_Soc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Raz_Soc.Location = New System.Drawing.Point(128, 96)
        Me.Txt_Raz_Soc.MaxLength = 30
        Me.Txt_Raz_Soc.Name = "Txt_Raz_Soc"
        Me.Txt_Raz_Soc.ReadOnly = True
        Me.Txt_Raz_Soc.Size = New System.Drawing.Size(270, 20)
        Me.Txt_Raz_Soc.TabIndex = 179
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Proveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(78, 96)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Proveedor.TabIndex = 1
        '
        'Lbl_NoGuia
        '
        Me.Lbl_NoGuia.AutoSize = True
        Me.Lbl_NoGuia.Location = New System.Drawing.Point(9, 125)
        Me.Lbl_NoGuia.Name = "Lbl_NoGuia"
        Me.Lbl_NoGuia.Size = New System.Drawing.Size(49, 13)
        Me.Lbl_NoGuia.TabIndex = 177
        Me.Lbl_NoGuia.Text = "No. Guia"
        '
        'Txt_NoGuia
        '
        Me.Txt_NoGuia.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NoGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NoGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoGuia.Location = New System.Drawing.Point(78, 122)
        Me.Txt_NoGuia.MaxLength = 20
        Me.Txt_NoGuia.Name = "Txt_NoGuia"
        Me.Txt_NoGuia.Size = New System.Drawing.Size(318, 20)
        Me.Txt_NoGuia.TabIndex = 2
        '
        'Lbl_Transporta
        '
        Me.Lbl_Transporta.AutoSize = True
        Me.Lbl_Transporta.Location = New System.Drawing.Point(9, 176)
        Me.Lbl_Transporta.Name = "Lbl_Transporta"
        Me.Lbl_Transporta.Size = New System.Drawing.Size(58, 13)
        Me.Lbl_Transporta.TabIndex = 175
        Me.Lbl_Transporta.Text = "Transporta"
        '
        'Txt_Transporta
        '
        Me.Txt_Transporta.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Transporta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Transporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Transporta.Location = New System.Drawing.Point(78, 176)
        Me.Txt_Transporta.MaxLength = 25
        Me.Txt_Transporta.Name = "Txt_Transporta"
        Me.Txt_Transporta.Size = New System.Drawing.Size(318, 20)
        Me.Txt_Transporta.TabIndex = 4
        '
        'Lbl_Bultos
        '
        Me.Lbl_Bultos.AutoSize = True
        Me.Lbl_Bultos.Location = New System.Drawing.Point(9, 71)
        Me.Lbl_Bultos.Name = "Lbl_Bultos"
        Me.Lbl_Bultos.Size = New System.Drawing.Size(56, 13)
        Me.Lbl_Bultos.TabIndex = 173
        Me.Lbl_Bultos.Text = "No. Bultos"
        '
        'Txt_NoBultos
        '
        Me.Txt_NoBultos.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NoBultos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NoBultos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoBultos.Location = New System.Drawing.Point(78, 68)
        Me.Txt_NoBultos.MaxLength = 4
        Me.Txt_NoBultos.Name = "Txt_NoBultos"
        Me.Txt_NoBultos.Size = New System.Drawing.Size(42, 22)
        Me.Txt_NoBultos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 290)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Recibe"
        '
        'Txt_Comentarios
        '
        Me.Txt_Comentarios.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Comentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Comentarios.Location = New System.Drawing.Point(78, 202)
        Me.Txt_Comentarios.MaxLength = 250
        Me.Txt_Comentarios.Multiline = True
        Me.Txt_Comentarios.Name = "Txt_Comentarios"
        Me.Txt_Comentarios.Size = New System.Drawing.Size(614, 79)
        Me.Txt_Comentarios.TabIndex = 5
        '
        'Lbl_Comentarios
        '
        Me.Lbl_Comentarios.AutoSize = True
        Me.Lbl_Comentarios.Location = New System.Drawing.Point(9, 205)
        Me.Lbl_Comentarios.Name = "Lbl_Comentarios"
        Me.Lbl_Comentarios.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_Comentarios.TabIndex = 157
        Me.Lbl_Comentarios.Text = "Comentarios"
        '
        'Txt_DescripRecibe
        '
        Me.Txt_DescripRecibe.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripRecibe.Enabled = False
        Me.Txt_DescripRecibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripRecibe.Location = New System.Drawing.Point(126, 287)
        Me.Txt_DescripRecibe.MaxLength = 30
        Me.Txt_DescripRecibe.Name = "Txt_DescripRecibe"
        Me.Txt_DescripRecibe.ReadOnly = True
        Me.Txt_DescripRecibe.Size = New System.Drawing.Size(270, 20)
        Me.Txt_DescripRecibe.TabIndex = 118
        '
        'Txt_Recibe
        '
        Me.Txt_Recibe.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Recibe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Recibe.Enabled = False
        Me.Txt_Recibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Recibe.Location = New System.Drawing.Point(78, 287)
        Me.Txt_Recibe.MaxLength = 3
        Me.Txt_Recibe.Name = "Txt_Recibe"
        Me.Txt_Recibe.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Recibe.TabIndex = 6
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_Condiciones)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Talon)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Factura)
        Me.Pnl_Botones.Controls.Add(Me.Btn_IFE)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 518)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(848, 55)
        Me.Pnl_Botones.TabIndex = 501
        '
        'Btn_Condiciones
        '
        Me.Btn_Condiciones.Image = Global.SIRCO.My.Resources.Resources.folder_customer_icon
        Me.Btn_Condiciones.Location = New System.Drawing.Point(397, 0)
        Me.Btn_Condiciones.Name = "Btn_Condiciones"
        Me.Btn_Condiciones.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Condiciones.TabIndex = 35
        Me.Btn_Condiciones.UseVisualStyleBackColor = True
        Me.Btn_Condiciones.Visible = False
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(691, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Imprimir.TabIndex = 34
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Talon
        '
        Me.Btn_Talon.Image = Global.SIRCO.My.Resources.Resources.Empty_document_new
        Me.Btn_Talon.Location = New System.Drawing.Point(167, 3)
        Me.Btn_Talon.Name = "Btn_Talon"
        Me.Btn_Talon.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Talon.TabIndex = 4
        Me.Btn_Talon.Text = "Talón"
        Me.Btn_Talon.UseVisualStyleBackColor = True
        '
        'Btn_Factura
        '
        Me.Btn_Factura.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.Btn_Factura.Location = New System.Drawing.Point(110, 2)
        Me.Btn_Factura.Name = "Btn_Factura"
        Me.Btn_Factura.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Factura.TabIndex = 3
        Me.Btn_Factura.UseVisualStyleBackColor = True
        Me.Btn_Factura.Visible = False
        '
        'Btn_IFE
        '
        Me.Btn_IFE.Image = Global.SIRCO.My.Resources.Resources.identificación
        Me.Btn_IFE.Location = New System.Drawing.Point(53, 2)
        Me.Btn_IFE.Name = "Btn_IFE"
        Me.Btn_IFE.Size = New System.Drawing.Size(51, 51)
        Me.Btn_IFE.TabIndex = 2
        Me.Btn_IFE.Text = "IFE"
        Me.Btn_IFE.UseVisualStyleBackColor = True
        Me.Btn_IFE.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(742, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(793, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Aceptar.TabIndex = 0
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmCatalogoReciboBultos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 573)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoReciboBultos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibo de Bultos"
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Pnl_Detalle.ResumeLayout(False)
        Me.Pnl_Detalle.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txt_DescripRecibe As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Recibe As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Lbl_Comentarios As System.Windows.Forms.Label
    Friend WithEvents Txt_Comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Bultos As System.Windows.Forms.Label
    Friend WithEvents Txt_NoBultos As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Transporta As System.Windows.Forms.Label
    Friend WithEvents Txt_Transporta As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_NoGuia As System.Windows.Forms.Label
    Friend WithEvents Txt_NoGuia As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Proveedor As System.Windows.Forms.Label
    Friend WithEvents Txt_Raz_Soc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Folio As System.Windows.Forms.Label
    Friend WithEvents Txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_Campo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Campo1 As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Talon As System.Windows.Forms.Button
    Friend WithEvents Btn_Factura As System.Windows.Forms.Button
    Friend WithEvents Btn_IFE As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Txt_NombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Asigna As System.Windows.Forms.Label
    Friend WithEvents Txt_IdEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Suc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pedido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bultos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaFactura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Opt_Devolucion As System.Windows.Forms.RadioButton
    Friend WithEvents Opt_Recibo As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Condiciones As System.Windows.Forms.Button
    Friend WithEvents Chk_SinFactura As System.Windows.Forms.CheckBox
    Friend WithEvents Pnl_Detalle As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Paqueteria As System.Windows.Forms.ComboBox
End Class
