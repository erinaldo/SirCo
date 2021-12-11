<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnalisisModelo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalisisModelo))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarSeleccionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.DT_FecFin = New System.Windows.Forms.DateTimePicker()
        Me.DT_FecIni = New System.Windows.Forms.DateTimePicker()
        Me.Lbl_fecfin = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Lbl_Totales = New System.Windows.Forms.Label()
        Me.Chk_Plaza = New System.Windows.Forms.CheckBox()
        Me.Chk_ConCeros = New System.Windows.Forms.CheckBox()
        Me.Chk_Lerdo = New System.Windows.Forms.CheckBox()
        Me.Btn_ModSiguiente = New System.Windows.Forms.Button()
        Me.Btn_ModAnterior = New System.Windows.Forms.Button()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Btn_Series = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.DGrid2 = New System.Windows.Forms.DataGridView()
        Me.Pnl_Gral = New System.Windows.Forms.Panel()
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
        Me.Panel2.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Gral.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Btn_Filtro.Location = New System.Drawing.Point(911, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Filtro.TabIndex = 248
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Filtro, "Búsqueda Estructura")
        Me.Btn_Filtro.UseVisualStyleBackColor = True
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
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(1163, 286)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Btn_Aceptar)
        Me.Panel1.Controls.Add(Me.DT_FecFin)
        Me.Panel1.Controls.Add(Me.DT_FecIni)
        Me.Panel1.Controls.Add(Me.Lbl_fecfin)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(396, 56)
        Me.Panel1.TabIndex = 243
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(343, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Aceptar.TabIndex = 2
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'DT_FecFin
        '
        Me.DT_FecFin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_FecFin.Location = New System.Drawing.Point(90, 28)
        Me.DT_FecFin.Name = "DT_FecFin"
        Me.DT_FecFin.Size = New System.Drawing.Size(241, 20)
        Me.DT_FecFin.TabIndex = 1
        '
        'DT_FecIni
        '
        Me.DT_FecIni.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_FecIni.Location = New System.Drawing.Point(90, 3)
        Me.DT_FecIni.Name = "DT_FecIni"
        Me.DT_FecIni.Size = New System.Drawing.Size(241, 20)
        Me.DT_FecIni.TabIndex = 0
        '
        'Lbl_fecfin
        '
        Me.Lbl_fecfin.AutoSize = True
        Me.Lbl_fecfin.Location = New System.Drawing.Point(16, 32)
        Me.Lbl_fecfin.Name = "Lbl_fecfin"
        Me.Lbl_fecfin.Size = New System.Drawing.Size(54, 13)
        Me.Lbl_fecfin.TabIndex = 243
        Me.Lbl_fecfin.Text = "Fecha Fin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Fecha Inicio"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Totales)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Plaza)
        Me.Pnl_Botones.Controls.Add(Me.Chk_ConCeros)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Lerdo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_ModSiguiente)
        Me.Pnl_Botones.Controls.Add(Me.Btn_ModAnterior)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Series)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Panel1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 516)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1170, 58)
        Me.Pnl_Botones.TabIndex = 7
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
        'Chk_Plaza
        '
        Me.Chk_Plaza.AutoSize = True
        Me.Chk_Plaza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Plaza.Location = New System.Drawing.Point(676, 8)
        Me.Chk_Plaza.Name = "Chk_Plaza"
        Me.Chk_Plaza.Size = New System.Drawing.Size(121, 20)
        Me.Chk_Plaza.TabIndex = 246
        Me.Chk_Plaza.Text = "Ver por Plaza"
        Me.Chk_Plaza.UseVisualStyleBackColor = True
        '
        'Chk_ConCeros
        '
        Me.Chk_ConCeros.AutoSize = True
        Me.Chk_ConCeros.Checked = True
        Me.Chk_ConCeros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chk_ConCeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_ConCeros.Location = New System.Drawing.Point(676, 21)
        Me.Chk_ConCeros.Name = "Chk_ConCeros"
        Me.Chk_ConCeros.Size = New System.Drawing.Size(205, 20)
        Me.Chk_ConCeros.TabIndex = 245
        Me.Chk_ConCeros.Text = "CON Conceptos en  ceros"
        Me.Chk_ConCeros.UseVisualStyleBackColor = True
        Me.Chk_ConCeros.Visible = False
        '
        'Chk_Lerdo
        '
        Me.Chk_Lerdo.AutoSize = True
        Me.Chk_Lerdo.Location = New System.Drawing.Point(418, 21)
        Me.Chk_Lerdo.Name = "Chk_Lerdo"
        Me.Chk_Lerdo.Size = New System.Drawing.Size(75, 17)
        Me.Chk_Lerdo.TabIndex = 244
        Me.Chk_Lerdo.Text = "Con Lerdo"
        Me.Chk_Lerdo.UseVisualStyleBackColor = True
        Me.Chk_Lerdo.Visible = False
        '
        'Btn_ModSiguiente
        '
        Me.Btn_ModSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ModSiguiente.Image = Global.SIRCO.My.Resources.Resources.arrowleftverde
        Me.Btn_ModSiguiente.Location = New System.Drawing.Point(598, 0)
        Me.Btn_ModSiguiente.Name = "Btn_ModSiguiente"
        Me.Btn_ModSiguiente.Size = New System.Drawing.Size(51, 53)
        Me.Btn_ModSiguiente.TabIndex = 1
        Me.Btn_ModSiguiente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ModSiguiente.UseVisualStyleBackColor = True
        '
        'Btn_ModAnterior
        '
        Me.Btn_ModAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ModAnterior.Image = Global.SIRCO.My.Resources.Resources.arrowright
        Me.Btn_ModAnterior.Location = New System.Drawing.Point(547, 0)
        Me.Btn_ModAnterior.Name = "Btn_ModAnterior"
        Me.Btn_ModAnterior.Size = New System.Drawing.Size(51, 53)
        Me.Btn_ModAnterior.TabIndex = 0
        Me.Btn_ModAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ModAnterior.UseVisualStyleBackColor = True
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(962, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Limpiar.TabIndex = 2
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Series
        '
        Me.Btn_Series.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Series.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Series.Image = Global.SIRCO.My.Resources.Resources.barcode
        Me.Btn_Series.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Series.Location = New System.Drawing.Point(1013, 0)
        Me.Btn_Series.Name = "Btn_Series"
        Me.Btn_Series.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Series.TabIndex = 3
        Me.Btn_Series.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Series.UseVisualStyleBackColor = True
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
        Me.Btn_Excel.UseVisualStyleBackColor = True
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
        Me.Pnl_Edicion.Controls.Add(Me.DGrid2)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Gral)
        Me.Pnl_Edicion.Controls.Add(Me.PBox)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(3, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(1166, 213)
        Me.Pnl_Edicion.TabIndex = 8
        '
        'DGrid2
        '
        Me.DGrid2.AllowUserToAddRows = False
        Me.DGrid2.AllowUserToResizeRows = False
        Me.DGrid2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid2.ContextMenuStrip = Me.CMenu
        Me.DGrid2.Location = New System.Drawing.Point(3, 74)
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.ReadOnly = True
        Me.DGrid2.Size = New System.Drawing.Size(958, 145)
        Me.DGrid2.TabIndex = 247
        '
        'Pnl_Gral
        '
        Me.Pnl_Gral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
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
        Me.Pnl_Gral.Size = New System.Drawing.Size(958, 209)
        Me.Pnl_Gral.TabIndex = 246
        '
        'Txt_Descripc
        '
        Me.Txt_Descripc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Descripc.Enabled = False
        Me.Txt_Descripc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripc.Location = New System.Drawing.Point(569, 4)
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
        Me.Lbl_Estructura.Location = New System.Drawing.Point(291, 45)
        Me.Lbl_Estructura.Name = "Lbl_Estructura"
        Me.Lbl_Estructura.Size = New System.Drawing.Size(50, 13)
        Me.Lbl_Estructura.TabIndex = 240
        Me.Lbl_Estructura.Text = "Descrip"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(218, 45)
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
        Me.Label3.Location = New System.Drawing.Point(499, 7)
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
        Me.PBox.Size = New System.Drawing.Size(195, 209)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 245
        Me.PBox.TabStop = False
        '
        'frmAnalisisModelo
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
        Me.Name = "frmAnalisisModelo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modelo"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.Pnl_Edicion.ResumeLayout(False)
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Gral.ResumeLayout(False)
        Me.Pnl_Gral.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DT_FecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT_FecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lbl_fecfin As System.Windows.Forms.Label
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Series As System.Windows.Forms.Button
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Btn_ModAnterior As System.Windows.Forms.Button
    Friend WithEvents Btn_ModSiguiente As System.Windows.Forms.Button
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
    Friend WithEvents Chk_Lerdo As System.Windows.Forms.CheckBox
    Friend WithEvents DGrid2 As System.Windows.Forms.DataGridView
    Friend WithEvents Chk_ConCeros As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Plaza As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents Lbl_Totales As System.Windows.Forms.Label
End Class
