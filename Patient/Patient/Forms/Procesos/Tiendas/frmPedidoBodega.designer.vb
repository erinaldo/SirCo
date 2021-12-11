<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoBodega
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoBodega))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Series = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGridExistencia = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarSeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGridNegado = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Txt_Porc = New System.Windows.Forms.TextBox()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Totales = New System.Windows.Forms.Label()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Pnl_Vendedor = New System.Windows.Forms.Panel()
        Me.Txt_Nombre = New System.Windows.Forms.TextBox()
        Me.Txt_Vendedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Pnl_Gral = New System.Windows.Forms.Panel()
        Me.Lbl_Marca = New System.Windows.Forms.Label()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Txt_Modelo = New System.Windows.Forms.TextBox()
        Me.Txt_IdArticulo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgridPedido = New System.Windows.Forms.DataGridView()
        Me.Pnl_Img = New System.Windows.Forms.Panel()
        Me.Pnl_Todo = New System.Windows.Forms.Panel()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.DGridExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DGridNegado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Vendedor.SuspendLayout()
        Me.Pnl_Gral.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DgridPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Todo.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(774, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Filtro.TabIndex = 4
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Filtro, "Búsqueda Estructura")
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Series
        '
        Me.Btn_Series.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Series.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Series.Location = New System.Drawing.Point(825, 0)
        Me.Btn_Series.Name = "Btn_Series"
        Me.Btn_Series.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Series.TabIndex = 5
        Me.Btn_Series.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Series, "Finalizar Pedido")
        Me.Btn_Series.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.DGridExistencia)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 130)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(931, 61)
        Me.Panel2.TabIndex = 6
        '
        'DGridExistencia
        '
        Me.DGridExistencia.AllowUserToAddRows = False
        Me.DGridExistencia.AllowUserToResizeRows = False
        Me.DGridExistencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gold
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridExistencia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGridExistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridExistencia.ContextMenuStrip = Me.CMenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridExistencia.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGridExistencia.Location = New System.Drawing.Point(30, 3)
        Me.DGridExistencia.Name = "DGridExistencia"
        Me.DGridExistencia.ReadOnly = True
        Me.DGridExistencia.Size = New System.Drawing.Size(891, 51)
        Me.DGridExistencia.TabIndex = 65
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarSeleccionToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(163, 26)
        '
        'CopiarSeleccionToolStripMenuItem
        '
        Me.CopiarSeleccionToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Paper_pencil
        Me.CopiarSeleccionToolStripMenuItem.Name = "CopiarSeleccionToolStripMenuItem"
        Me.CopiarSeleccionToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CopiarSeleccionToolStripMenuItem.Text = "Copiar Selección"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Label2)
        Me.Pnl_Botones.Controls.Add(Me.DGridNegado)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Porc)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Totales)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Series)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 627)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(931, 58)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(445, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "Negados"
        Me.Label2.Visible = False
        '
        'DGridNegado
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridNegado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGridNegado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridNegado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.DGridNegado.Location = New System.Drawing.Point(566, 4)
        Me.DGridNegado.Name = "DGridNegado"
        Me.DGridNegado.ReadOnly = True
        Me.DGridNegado.RowHeadersVisible = False
        Me.DGridNegado.Size = New System.Drawing.Size(95, 55)
        Me.DGridNegado.TabIndex = 252
        Me.DGridNegado.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Marca"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Modelo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Medida"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Txt_Porc
        '
        Me.Txt_Porc.Enabled = False
        Me.Txt_Porc.Location = New System.Drawing.Point(99, 31)
        Me.Txt_Porc.Name = "Txt_Porc"
        Me.Txt_Porc.ReadOnly = True
        Me.Txt_Porc.Size = New System.Drawing.Size(80, 20)
        Me.Txt_Porc.TabIndex = 251
        Me.Txt_Porc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Porc.Visible = False
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(5, 4)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(269, 23)
        Me.PBar.TabIndex = 250
        Me.PBar.Visible = False
        '
        'Lbl_Totales
        '
        Me.Lbl_Totales.AutoSize = True
        Me.Lbl_Totales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Totales.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Totales.Location = New System.Drawing.Point(412, 21)
        Me.Lbl_Totales.Name = "Lbl_Totales"
        Me.Lbl_Totales.Size = New System.Drawing.Size(0, 20)
        Me.Lbl_Totales.TabIndex = 249
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(876, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Salir.TabIndex = 6
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Vendedor)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Gral)
        Me.Pnl_Edicion.Controls.Add(Me.PBox)
        Me.Pnl_Edicion.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Edicion.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(931, 130)
        Me.Pnl_Edicion.TabIndex = 8
        '
        'Pnl_Vendedor
        '
        Me.Pnl_Vendedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Vendedor.Controls.Add(Me.Txt_Nombre)
        Me.Pnl_Vendedor.Controls.Add(Me.Txt_Vendedor)
        Me.Pnl_Vendedor.Controls.Add(Me.Label4)
        Me.Pnl_Vendedor.Location = New System.Drawing.Point(9, 7)
        Me.Pnl_Vendedor.Name = "Pnl_Vendedor"
        Me.Pnl_Vendedor.Size = New System.Drawing.Size(586, 55)
        Me.Pnl_Vendedor.TabIndex = 0
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Nombre.Enabled = False
        Me.Txt_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nombre.Location = New System.Drawing.Point(131, 15)
        Me.Txt_Nombre.MaxLength = 70
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.ReadOnly = True
        Me.Txt_Nombre.Size = New System.Drawing.Size(382, 26)
        Me.Txt_Nombre.TabIndex = 237
        '
        'Txt_Vendedor
        '
        Me.Txt_Vendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vendedor.Location = New System.Drawing.Point(84, 15)
        Me.Txt_Vendedor.Name = "Txt_Vendedor"
        Me.Txt_Vendedor.Size = New System.Drawing.Size(45, 26)
        Me.Txt_Vendedor.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "No. Vendedor"
        '
        'Pnl_Gral
        '
        Me.Pnl_Gral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Gral.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Modelo)
        Me.Pnl_Gral.Controls.Add(Me.Txt_IdArticulo)
        Me.Pnl_Gral.Controls.Add(Me.Label11)
        Me.Pnl_Gral.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Gral.Location = New System.Drawing.Point(9, 68)
        Me.Pnl_Gral.Name = "Pnl_Gral"
        Me.Pnl_Gral.Size = New System.Drawing.Size(586, 46)
        Me.Pnl_Gral.TabIndex = 246
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.Location = New System.Drawing.Point(215, 10)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Marca.TabIndex = 200
        Me.Lbl_Marca.Text = "Marca"
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(83, 7)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(44, 26)
        Me.Txt_Marca.TabIndex = 1
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Modelo.Location = New System.Drawing.Point(129, 7)
        Me.Txt_Modelo.MaxLength = 7
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.Size = New System.Drawing.Size(80, 26)
        Me.Txt_Modelo.TabIndex = 2
        '
        'Txt_IdArticulo
        '
        Me.Txt_IdArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdArticulo.Location = New System.Drawing.Point(797, 3)
        Me.Txt_IdArticulo.MaxLength = 14
        Me.Txt_IdArticulo.Name = "Txt_IdArticulo"
        Me.Txt_IdArticulo.Size = New System.Drawing.Size(46, 20)
        Me.Txt_IdArticulo.TabIndex = 238
        Me.Txt_IdArticulo.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Modelo"
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(285, 7)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(197, 20)
        Me.Txt_DescripMarca.TabIndex = 201
        '
        'PBox
        '
        Me.PBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(742, 7)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(179, 107)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 245
        Me.PBox.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DgridPedido)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(164, 432)
        Me.Panel1.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Pedido"
        '
        'DgridPedido
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgridPedido.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgridPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgridPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DgridPedido.Location = New System.Drawing.Point(3, 37)
        Me.DgridPedido.Name = "DgridPedido"
        Me.DgridPedido.ReadOnly = True
        Me.DgridPedido.RowHeadersVisible = False
        Me.DgridPedido.Size = New System.Drawing.Size(148, 350)
        Me.DgridPedido.TabIndex = 68
        '
        'Pnl_Img
        '
        Me.Pnl_Img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Img.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Img.Location = New System.Drawing.Point(164, 0)
        Me.Pnl_Img.Name = "Pnl_Img"
        Me.Pnl_Img.Size = New System.Drawing.Size(763, 432)
        Me.Pnl_Img.TabIndex = 3
        '
        'Pnl_Todo
        '
        Me.Pnl_Todo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Todo.Controls.Add(Me.Pnl_Img)
        Me.Pnl_Todo.Controls.Add(Me.Panel1)
        Me.Pnl_Todo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Todo.Location = New System.Drawing.Point(0, 191)
        Me.Pnl_Todo.Name = "Pnl_Todo"
        Me.Pnl_Todo.Size = New System.Drawing.Size(931, 436)
        Me.Pnl_Todo.TabIndex = 13
        '
        'Column1
        '
        Me.Column1.HeaderText = "Marca"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Modelo"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Med"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 40
        '
        'Column4
        '
        Me.Column4.HeaderText = "Propuesta"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Linea"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "L1"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'frmPedidoBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(931, 685)
        Me.Controls.Add(Me.Pnl_Todo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPedidoBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedido Bodega"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGridExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DGridNegado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Vendedor.ResumeLayout(False)
        Me.Pnl_Vendedor.PerformLayout()
        Me.Pnl_Gral.ResumeLayout(False)
        Me.Pnl_Gral.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DgridPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Todo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Series As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarSeleccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Pnl_Gral As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Modelo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Lbl_Totales As System.Windows.Forms.Label
    Friend WithEvents Pnl_Vendedor As System.Windows.Forms.Panel
    Friend WithEvents Txt_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGridExistencia As System.Windows.Forms.DataGridView
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Txt_Porc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGridNegado As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgridPedido As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Img As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Todo As System.Windows.Forms.Panel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
End Class
