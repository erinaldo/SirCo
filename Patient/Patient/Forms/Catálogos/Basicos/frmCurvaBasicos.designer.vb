<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCurvaBasicos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCurvaBasicos))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarSeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Pnl_Gral = New System.Windows.Forms.Panel()
        Me.Txt_MinimoPares = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cbo_Mensual = New System.Windows.Forms.ComboBox()
        Me.Cbo_Quincenal = New System.Windows.Forms.ComboBox()
        Me.Cbo_Semanal = New System.Windows.Forms.ComboBox()
        Me.Opt_Mensual = New System.Windows.Forms.RadioButton()
        Me.Opt_Quincenal = New System.Windows.Forms.RadioButton()
        Me.Opt_Semanal = New System.Windows.Forms.RadioButton()
        Me.Opt_Diario = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DT_FecFin = New System.Windows.Forms.DateTimePicker()
        Me.Txt_Descripc = New System.Windows.Forms.TextBox()
        Me.Lbl_Marca = New System.Windows.Forms.Label()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Lbl_Estructura = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.PBar_1 = New System.Windows.Forms.ProgressBar()
        Me.Panel2.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Gral.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(1013, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Limpiar.TabIndex = 2
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Limpiar, "Limpiar Curva")
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1064, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Excel.TabIndex = 4
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Excel, "Importar Excel")
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(962, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Aceptar.TabIndex = 6
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Aceptar, "Guardar la Curva")
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
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
        Me.Panel2.Controls.Add(Me.DGrid)
        Me.Panel2.Location = New System.Drawing.Point(3, 222)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1166, 290)
        Me.Panel2.TabIndex = 6
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToResizeRows = False
        Me.DGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.ContextMenuStrip = Me.CMenu
        Me.DGrid.Location = New System.Drawing.Point(0, 24)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(1163, 262)
        Me.DGrid.TabIndex = 63
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
        Me.Pnl_Botones.Controls.Add(Me.PBar_1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 516)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1170, 58)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1115, 0)
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
        Me.Pnl_Edicion.Controls.Add(Me.PBox)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(3, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(1166, 249)
        Me.Pnl_Edicion.TabIndex = 8
        '
        'Pnl_Gral
        '
        Me.Pnl_Gral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Gral.Controls.Add(Me.Txt_MinimoPares)
        Me.Pnl_Gral.Controls.Add(Me.Label6)
        Me.Pnl_Gral.Controls.Add(Me.Label5)
        Me.Pnl_Gral.Controls.Add(Me.Panel1)
        Me.Pnl_Gral.Controls.Add(Me.DT_FecFin)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Descripc)
        Me.Pnl_Gral.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Gral.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Gral.Controls.Add(Me.Lbl_Estructura)
        Me.Pnl_Gral.Controls.Add(Me.Label1)
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
        Me.Pnl_Gral.Location = New System.Drawing.Point(3, 0)
        Me.Pnl_Gral.Name = "Pnl_Gral"
        Me.Pnl_Gral.Size = New System.Drawing.Size(958, 242)
        Me.Pnl_Gral.TabIndex = 246
        '
        'Txt_MinimoPares
        '
        Me.Txt_MinimoPares.Location = New System.Drawing.Point(530, 143)
        Me.Txt_MinimoPares.Name = "Txt_MinimoPares"
        Me.Txt_MinimoPares.Size = New System.Drawing.Size(100, 20)
        Me.Txt_MinimoPares.TabIndex = 245
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(427, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "Mínimo de Pares"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(427, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 243
        Me.Label5.Text = "Vigencia"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Cbo_Mensual)
        Me.Panel1.Controls.Add(Me.Cbo_Quincenal)
        Me.Panel1.Controls.Add(Me.Cbo_Semanal)
        Me.Panel1.Controls.Add(Me.Opt_Mensual)
        Me.Panel1.Controls.Add(Me.Opt_Quincenal)
        Me.Panel1.Controls.Add(Me.Opt_Semanal)
        Me.Panel1.Controls.Add(Me.Opt_Diario)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(8, 126)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(372, 109)
        Me.Panel1.TabIndex = 242
        '
        'Cbo_Mensual
        '
        Me.Cbo_Mensual.AutoCompleteCustomSource.AddRange(New String() {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.Cbo_Mensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Mensual.FormattingEnabled = True
        Me.Cbo_Mensual.Items.AddRange(New Object() {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.Cbo_Mensual.Location = New System.Drawing.Point(164, 84)
        Me.Cbo_Mensual.Name = "Cbo_Mensual"
        Me.Cbo_Mensual.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Mensual.TabIndex = 247
        '
        'Cbo_Quincenal
        '
        Me.Cbo_Quincenal.AutoCompleteCustomSource.AddRange(New String() {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.Cbo_Quincenal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Quincenal.FormattingEnabled = True
        Me.Cbo_Quincenal.Items.AddRange(New Object() {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.Cbo_Quincenal.Location = New System.Drawing.Point(164, 61)
        Me.Cbo_Quincenal.Name = "Cbo_Quincenal"
        Me.Cbo_Quincenal.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Quincenal.TabIndex = 246
        '
        'Cbo_Semanal
        '
        Me.Cbo_Semanal.AutoCompleteCustomSource.AddRange(New String() {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.Cbo_Semanal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Semanal.FormattingEnabled = True
        Me.Cbo_Semanal.Items.AddRange(New Object() {"LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO", "DOMINGO"})
        Me.Cbo_Semanal.Location = New System.Drawing.Point(164, 38)
        Me.Cbo_Semanal.Name = "Cbo_Semanal"
        Me.Cbo_Semanal.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Semanal.TabIndex = 245
        '
        'Opt_Mensual
        '
        Me.Opt_Mensual.AutoSize = True
        Me.Opt_Mensual.Location = New System.Drawing.Point(75, 85)
        Me.Opt_Mensual.Name = "Opt_Mensual"
        Me.Opt_Mensual.Size = New System.Drawing.Size(65, 17)
        Me.Opt_Mensual.TabIndex = 244
        Me.Opt_Mensual.TabStop = True
        Me.Opt_Mensual.Text = "Mensual"
        Me.Opt_Mensual.UseVisualStyleBackColor = True
        '
        'Opt_Quincenal
        '
        Me.Opt_Quincenal.AutoSize = True
        Me.Opt_Quincenal.Location = New System.Drawing.Point(75, 62)
        Me.Opt_Quincenal.Name = "Opt_Quincenal"
        Me.Opt_Quincenal.Size = New System.Drawing.Size(73, 17)
        Me.Opt_Quincenal.TabIndex = 243
        Me.Opt_Quincenal.TabStop = True
        Me.Opt_Quincenal.Text = "Quincenal"
        Me.Opt_Quincenal.UseVisualStyleBackColor = True
        '
        'Opt_Semanal
        '
        Me.Opt_Semanal.AutoSize = True
        Me.Opt_Semanal.Location = New System.Drawing.Point(75, 39)
        Me.Opt_Semanal.Name = "Opt_Semanal"
        Me.Opt_Semanal.Size = New System.Drawing.Size(66, 17)
        Me.Opt_Semanal.TabIndex = 242
        Me.Opt_Semanal.TabStop = True
        Me.Opt_Semanal.Text = "Semanal"
        Me.Opt_Semanal.UseVisualStyleBackColor = True
        '
        'Opt_Diario
        '
        Me.Opt_Diario.AutoSize = True
        Me.Opt_Diario.Location = New System.Drawing.Point(75, 16)
        Me.Opt_Diario.Name = "Opt_Diario"
        Me.Opt_Diario.Size = New System.Drawing.Size(52, 17)
        Me.Opt_Diario.TabIndex = 241
        Me.Opt_Diario.TabStop = True
        Me.Opt_Diario.Text = "Diario"
        Me.Opt_Diario.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Frecuencia de Pedido"
        '
        'DT_FecFin
        '
        Me.DT_FecFin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_FecFin.Location = New System.Drawing.Point(495, 120)
        Me.DT_FecFin.Name = "DT_FecFin"
        Me.DT_FecFin.Size = New System.Drawing.Size(241, 20)
        Me.DT_FecFin.TabIndex = 241
        '
        'Txt_Descripc
        '
        Me.Txt_Descripc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Descripc.Enabled = False
        Me.Txt_Descripc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripc.Location = New System.Drawing.Point(83, 69)
        Me.Txt_Descripc.MaxLength = 70
        Me.Txt_Descripc.Name = "Txt_Descripc"
        Me.Txt_Descripc.ReadOnly = True
        Me.Txt_Descripc.Size = New System.Drawing.Size(382, 20)
        Me.Txt_Descripc.TabIndex = 236
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
        Me.Txt_Marca.Enabled = False
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(83, 7)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.ReadOnly = True
        Me.Txt_Marca.Size = New System.Drawing.Size(44, 26)
        Me.Txt_Marca.TabIndex = 0
        '
        'Lbl_Estructura
        '
        Me.Lbl_Estructura.AutoSize = True
        Me.Lbl_Estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estructura.Location = New System.Drawing.Point(80, 99)
        Me.Lbl_Estructura.Name = "Lbl_Estructura"
        Me.Lbl_Estructura.Size = New System.Drawing.Size(50, 13)
        Me.Lbl_Estructura.TabIndex = 240
        Me.Lbl_Estructura.Text = "Descrip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "Estructura"
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Modelo.Enabled = False
        Me.Txt_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Modelo.Location = New System.Drawing.Point(129, 7)
        Me.Txt_Modelo.MaxLength = 7
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.ReadOnly = True
        Me.Txt_Modelo.Size = New System.Drawing.Size(80, 26)
        Me.Txt_Modelo.TabIndex = 1
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
        'Txt_Estilof
        '
        Me.Txt_Estilof.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Estilof.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilof.Location = New System.Drawing.Point(83, 37)
        Me.Txt_Estilof.MaxLength = 14
        Me.Txt_Estilof.Name = "Txt_Estilof"
        Me.Txt_Estilof.Size = New System.Drawing.Size(126, 26)
        Me.Txt_Estilof.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Descripción "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 45)
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
        Me.Txt_Raz_Soc.Location = New System.Drawing.Point(508, 7)
        Me.Txt_Raz_Soc.Name = "Txt_Raz_Soc"
        Me.Txt_Raz_Soc.ReadOnly = True
        Me.Txt_Raz_Soc.Size = New System.Drawing.Size(55, 20)
        Me.Txt_Raz_Soc.TabIndex = 209
        Me.Txt_Raz_Soc.Visible = False
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
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Proveedor.Enabled = False
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(569, 7)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.ReadOnly = True
        Me.Txt_Proveedor.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Proveedor.TabIndex = 199
        Me.Txt_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Proveedor.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(627, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 208
        Me.Label8.Text = "Proveedor"
        Me.Label8.Visible = False
        '
        'PBox
        '
        Me.PBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(967, 0)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(195, 245)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 245
        Me.PBox.TabStop = False
        '
        'PBar_1
        '
        Me.PBar_1.Location = New System.Drawing.Point(473, 16)
        Me.PBar_1.Name = "PBar_1"
        Me.PBar_1.Size = New System.Drawing.Size(220, 23)
        Me.PBar_1.TabIndex = 250
        '
        'frmCurvaBasicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1170, 574)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCurvaBasicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modelo"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Gral.ResumeLayout(False)
        Me.Pnl_Gral.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Opt_Semanal As RadioButton
    Friend WithEvents Opt_Diario As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents DT_FecFin As DateTimePicker
    Friend WithEvents Opt_Mensual As RadioButton
    Friend WithEvents Opt_Quincenal As RadioButton
    Friend WithEvents Cbo_Mensual As ComboBox
    Friend WithEvents Cbo_Quincenal As ComboBox
    Friend WithEvents Cbo_Semanal As ComboBox
    Friend WithEvents Txt_MinimoPares As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Btn_Aceptar As Button
    Friend WithEvents PBar_1 As ProgressBar
End Class
