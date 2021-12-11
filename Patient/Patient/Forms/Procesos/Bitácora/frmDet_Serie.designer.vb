<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDet_Serie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDet_Serie))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarSeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Pnl_Gral = New System.Windows.Forms.Panel()
        Me.Txt_Medida = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Descripc = New System.Windows.Forms.TextBox()
        Me.Lbl_Marca = New System.Windows.Forms.Label()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Txt_Modelo = New System.Windows.Forms.TextBox()
        Me.Txt_IdArticulo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_Estilof = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Raz_Soc = New System.Windows.Forms.TextBox()
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Pnl_Prec = New System.Windows.Forms.Panel()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Lbl_UltEntrada = New System.Windows.Forms.Label()
        Me.Lbl_FechaUltVta = New System.Windows.Forms.Label()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Lbl_Estructura = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Serie = New System.Windows.Forms.TextBox()
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.Lbl_Aparador = New System.Windows.Forms.Label()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Panel2.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Gral.SuspendLayout()
        Me.Pnl_Prec.SuspendLayout()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.DGrid1)
        Me.Panel2.Location = New System.Drawing.Point(3, 209)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1299, 303)
        Me.Panel2.TabIndex = 6
        '
        'DGrid1
        '
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(1172, 299)
        Me.DGrid1.TabIndex = 22
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 516)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1303, 58)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(1146, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Limpiar.TabIndex = 2
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1197, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Excel.TabIndex = 4
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1248, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Gral)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Prec)
        Me.Pnl_Edicion.Controls.Add(Me.PBox)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Estructura)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(5, 43)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(1299, 165)
        Me.Pnl_Edicion.TabIndex = 8
        '
        'Pnl_Gral
        '
        Me.Pnl_Gral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Gral.Controls.Add(Me.Txt_Medida)
        Me.Pnl_Gral.Controls.Add(Me.Label4)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Descripc)
        Me.Pnl_Gral.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Modelo)
        Me.Pnl_Gral.Controls.Add(Me.Txt_IdArticulo)
        Me.Pnl_Gral.Controls.Add(Me.Label11)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Estilof)
        Me.Pnl_Gral.Controls.Add(Me.Label3)
        Me.Pnl_Gral.Controls.Add(Me.Label2)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Raz_Soc)
        Me.Pnl_Gral.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Proveedor)
        Me.Pnl_Gral.Controls.Add(Me.Label8)
        Me.Pnl_Gral.Enabled = False
        Me.Pnl_Gral.Location = New System.Drawing.Point(3, 3)
        Me.Pnl_Gral.Name = "Pnl_Gral"
        Me.Pnl_Gral.Size = New System.Drawing.Size(463, 123)
        Me.Pnl_Gral.TabIndex = 246
        '
        'Txt_Medida
        '
        Me.Txt_Medida.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Medida.Enabled = False
        Me.Txt_Medida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Medida.Location = New System.Drawing.Point(237, 31)
        Me.Txt_Medida.MaxLength = 14
        Me.Txt_Medida.Name = "Txt_Medida"
        Me.Txt_Medida.ReadOnly = True
        Me.Txt_Medida.Size = New System.Drawing.Size(52, 20)
        Me.Txt_Medida.TabIndex = 239
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(194, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Medida"
        '
        'Txt_Descripc
        '
        Me.Txt_Descripc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Descripc.Enabled = False
        Me.Txt_Descripc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripc.Location = New System.Drawing.Point(81, 57)
        Me.Txt_Descripc.MaxLength = 70
        Me.Txt_Descripc.Name = "Txt_Descripc"
        Me.Txt_Descripc.ReadOnly = True
        Me.Txt_Descripc.Size = New System.Drawing.Size(374, 20)
        Me.Txt_Descripc.TabIndex = 236
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.Location = New System.Drawing.Point(194, 10)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Marca.TabIndex = 200
        Me.Lbl_Marca.Text = "Marca"
        '
        'Txt_Marca
        '
        Me.Txt_Marca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Marca.Enabled = False
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(81, 7)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.ReadOnly = True
        Me.Txt_Marca.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Marca.TabIndex = 0
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Modelo.Enabled = False
        Me.Txt_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Modelo.Location = New System.Drawing.Point(129, 7)
        Me.Txt_Modelo.MaxLength = 7
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.ReadOnly = True
        Me.Txt_Modelo.Size = New System.Drawing.Size(60, 20)
        Me.Txt_Modelo.TabIndex = 1
        '
        'Txt_IdArticulo
        '
        Me.Txt_IdArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdArticulo.Location = New System.Drawing.Point(257, 101)
        Me.Txt_IdArticulo.MaxLength = 14
        Me.Txt_IdArticulo.Name = "Txt_IdArticulo"
        Me.Txt_IdArticulo.Size = New System.Drawing.Size(46, 20)
        Me.Txt_IdArticulo.TabIndex = 238
        Me.Txt_IdArticulo.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Modelo"
        '
        'Txt_Estilof
        '
        Me.Txt_Estilof.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Estilof.Enabled = False
        Me.Txt_Estilof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilof.Location = New System.Drawing.Point(81, 31)
        Me.Txt_Estilof.MaxLength = 14
        Me.Txt_Estilof.Name = "Txt_Estilof"
        Me.Txt_Estilof.ReadOnly = True
        Me.Txt_Estilof.Size = New System.Drawing.Size(108, 20)
        Me.Txt_Estilof.TabIndex = 188
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Descripción "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 203
        Me.Label2.Text = "Estilo Fábrica"
        '
        'Txt_Raz_Soc
        '
        Me.Txt_Raz_Soc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Raz_Soc.Enabled = False
        Me.Txt_Raz_Soc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Raz_Soc.Location = New System.Drawing.Point(129, 83)
        Me.Txt_Raz_Soc.Name = "Txt_Raz_Soc"
        Me.Txt_Raz_Soc.ReadOnly = True
        Me.Txt_Raz_Soc.Size = New System.Drawing.Size(326, 20)
        Me.Txt_Raz_Soc.TabIndex = 209
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(237, 7)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(218, 20)
        Me.Txt_DescripMarca.TabIndex = 201
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Proveedor.Enabled = False
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(81, 83)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Proveedor.TabIndex = 199
        Me.Txt_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 208
        Me.Label8.Text = "Proveedor"
        '
        'Pnl_Prec
        '
        Me.Pnl_Prec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl_Prec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Prec.Controls.Add(Me.DGrid2)
        Me.Pnl_Prec.Controls.Add(Me.Lbl_UltEntrada)
        Me.Pnl_Prec.Controls.Add(Me.Lbl_FechaUltVta)
        Me.Pnl_Prec.Location = New System.Drawing.Point(471, 3)
        Me.Pnl_Prec.Name = "Pnl_Prec"
        Me.Pnl_Prec.Size = New System.Drawing.Size(623, 135)
        Me.Pnl_Prec.TabIndex = 59
        '
        'DGrid2
        '
        Me.DGrid2.Dock = System.Windows.Forms.DockStyle.Left
        Me.DGrid2.Location = New System.Drawing.Point(0, 0)
        Me.DGrid2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid2.MainView = Me.GridView2
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(616, 131)
        Me.DGrid2.TabIndex = 245
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.DGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'Lbl_UltEntrada
        '
        Me.Lbl_UltEntrada.AutoSize = True
        Me.Lbl_UltEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_UltEntrada.Location = New System.Drawing.Point(102, 8)
        Me.Lbl_UltEntrada.Name = "Lbl_UltEntrada"
        Me.Lbl_UltEntrada.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_UltEntrada.TabIndex = 244
        '
        'Lbl_FechaUltVta
        '
        Me.Lbl_FechaUltVta.AutoSize = True
        Me.Lbl_FechaUltVta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FechaUltVta.Location = New System.Drawing.Point(102, 32)
        Me.Lbl_FechaUltVta.Name = "Lbl_FechaUltVta"
        Me.Lbl_FechaUltVta.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_FechaUltVta.TabIndex = 242
        '
        'PBox
        '
        Me.PBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(1100, 0)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(195, 161)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 245
        Me.PBox.TabStop = False
        '
        'Lbl_Estructura
        '
        Me.Lbl_Estructura.AutoSize = True
        Me.Lbl_Estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estructura.Location = New System.Drawing.Point(82, 138)
        Me.Lbl_Estructura.Name = "Lbl_Estructura"
        Me.Lbl_Estructura.Size = New System.Drawing.Size(50, 13)
        Me.Lbl_Estructura.TabIndex = 240
        Me.Lbl_Estructura.Text = "Descrip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Estructura"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 24)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Serie"
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Location = New System.Drawing.Point(93, 8)
        Me.Txt_Serie.MaxLength = 13
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Size = New System.Drawing.Size(182, 29)
        Me.Txt_Serie.TabIndex = 0
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Status.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Status.Location = New System.Drawing.Point(350, 8)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(0, 24)
        Me.Lbl_Status.TabIndex = 10
        '
        'Lbl_Aparador
        '
        Me.Lbl_Aparador.AutoSize = True
        Me.Lbl_Aparador.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Aparador.ForeColor = System.Drawing.Color.ForestGreen
        Me.Lbl_Aparador.Location = New System.Drawing.Point(572, 8)
        Me.Lbl_Aparador.Name = "Lbl_Aparador"
        Me.Lbl_Aparador.Size = New System.Drawing.Size(0, 24)
        Me.Lbl_Aparador.TabIndex = 11
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmDet_Serie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1303, 574)
        Me.Controls.Add(Me.Lbl_Aparador)
        Me.Controls.Add(Me.Lbl_Status)
        Me.Controls.Add(Me.Txt_Serie)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmDet_Serie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos de Serie"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Gral.ResumeLayout(False)
        Me.Pnl_Gral.PerformLayout()
        Me.Pnl_Prec.ResumeLayout(False)
        Me.Pnl_Prec.PerformLayout()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarSeleccionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Prec As System.Windows.Forms.Panel
    Friend WithEvents Lbl_UltEntrada As System.Windows.Forms.Label
    Friend WithEvents Lbl_FechaUltVta As System.Windows.Forms.Label
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Lbl_Estructura As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Gral As System.Windows.Forms.Panel
    Friend WithEvents Txt_Descripc As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Modelo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_Estilof As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Raz_Soc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Serie As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Status As System.Windows.Forms.Label
    Friend WithEvents Txt_Medida As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Aparador As System.Windows.Forms.Label
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
