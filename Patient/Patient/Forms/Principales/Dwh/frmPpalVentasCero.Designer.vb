<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalVentasCero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalVentasCero))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.lbl_Modelo = New System.Windows.Forms.Label
        Me.lbl_Marca = New System.Windows.Forms.Label
        Me.lbl_L6 = New System.Windows.Forms.Label
        Me.lbl_L5 = New System.Windows.Forms.Label
        Me.lbl_L4 = New System.Windows.Forms.Label
        Me.lbl_L3 = New System.Windows.Forms.Label
        Me.lbl_L2 = New System.Windows.Forms.Label
        Me.lbl_L1 = New System.Windows.Forms.Label
        Me.lbl_Linea = New System.Windows.Forms.Label
        Me.lbl_Familia = New System.Windows.Forms.Label
        Me.lbl_Depto = New System.Windows.Forms.Label
        Me.lbl_Division = New System.Windows.Forms.Label
        Me.lbl_Sucursal = New System.Windows.Forms.Label
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemSucursal = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemDivision = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemDepto = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemFamilia = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemLinea = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemL1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemL2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemL3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemL4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemL5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemL6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemMarca = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemModelo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemCatModelo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemAnaModelo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemInicio = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Bar = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LBL_PORC = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pbar1 = New System.Windows.Forms.ProgressBar
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Actualizar = New System.Windows.Forms.Button
        Me.Pnl_Pares = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_CtdFin = New System.Windows.Forms.TextBox
        Me.Txt_CtdIni = New System.Windows.Forms.TextBox
        Me.Lbl_Periodo = New System.Windows.Forms.Label
        Me.lbl_Final = New System.Windows.Forms.Label
        Me.Lbl_FUM = New System.Windows.Forms.Label
        Me.GB_Sucursales = New System.Windows.Forms.GroupBox
        Me.RB_SinLerdo = New System.Windows.Forms.RadioButton
        Me.RB_Activas = New System.Windows.Forms.RadioButton
        Me.Chk_Calzado = New System.Windows.Forms.CheckBox
        Me.Btn_Regresar = New System.Windows.Forms.Button
        Me.Btn_Foto = New System.Windows.Forms.Button
        Me.Btn_Filtro = New System.Windows.Forms.Button
        Me.Btn_Excel = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Lbl_UltMod = New System.Windows.Forms.Label
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Pares.SuspendLayout()
        Me.GB_Sucursales.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.PBox)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Modelo)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Marca)
        Me.Pnl_Grid.Controls.Add(Me.lbl_L6)
        Me.Pnl_Grid.Controls.Add(Me.lbl_L5)
        Me.Pnl_Grid.Controls.Add(Me.lbl_L4)
        Me.Pnl_Grid.Controls.Add(Me.lbl_L3)
        Me.Pnl_Grid.Controls.Add(Me.lbl_L2)
        Me.Pnl_Grid.Controls.Add(Me.lbl_L1)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Linea)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Familia)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Depto)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Division)
        Me.Pnl_Grid.Controls.Add(Me.lbl_Sucursal)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Bar)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1178, 460)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PBox
        '
        Me.PBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBox.Location = New System.Drawing.Point(978, 290)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(193, 162)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 57
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'lbl_Modelo
        '
        Me.lbl_Modelo.AutoSize = True
        Me.lbl_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Modelo.Location = New System.Drawing.Point(487, 395)
        Me.lbl_Modelo.Name = "lbl_Modelo"
        Me.lbl_Modelo.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Modelo.TabIndex = 56
        Me.lbl_Modelo.Text = "A"
        Me.lbl_Modelo.Visible = False
        '
        'lbl_Marca
        '
        Me.lbl_Marca.AutoSize = True
        Me.lbl_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Marca.Location = New System.Drawing.Point(466, 395)
        Me.lbl_Marca.Name = "lbl_Marca"
        Me.lbl_Marca.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Marca.TabIndex = 55
        Me.lbl_Marca.Text = "A"
        Me.lbl_Marca.Visible = False
        '
        'lbl_L6
        '
        Me.lbl_L6.AutoSize = True
        Me.lbl_L6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L6.Location = New System.Drawing.Point(445, 395)
        Me.lbl_L6.Name = "lbl_L6"
        Me.lbl_L6.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L6.TabIndex = 54
        Me.lbl_L6.Text = "A"
        Me.lbl_L6.Visible = False
        '
        'lbl_L5
        '
        Me.lbl_L5.AutoSize = True
        Me.lbl_L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L5.Location = New System.Drawing.Point(424, 395)
        Me.lbl_L5.Name = "lbl_L5"
        Me.lbl_L5.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L5.TabIndex = 53
        Me.lbl_L5.Text = "A"
        Me.lbl_L5.Visible = False
        '
        'lbl_L4
        '
        Me.lbl_L4.AutoSize = True
        Me.lbl_L4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L4.Location = New System.Drawing.Point(403, 395)
        Me.lbl_L4.Name = "lbl_L4"
        Me.lbl_L4.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L4.TabIndex = 52
        Me.lbl_L4.Text = "A"
        Me.lbl_L4.Visible = False
        '
        'lbl_L3
        '
        Me.lbl_L3.AutoSize = True
        Me.lbl_L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L3.Location = New System.Drawing.Point(382, 395)
        Me.lbl_L3.Name = "lbl_L3"
        Me.lbl_L3.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L3.TabIndex = 51
        Me.lbl_L3.Text = "A"
        Me.lbl_L3.Visible = False
        '
        'lbl_L2
        '
        Me.lbl_L2.AutoSize = True
        Me.lbl_L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L2.Location = New System.Drawing.Point(361, 395)
        Me.lbl_L2.Name = "lbl_L2"
        Me.lbl_L2.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L2.TabIndex = 50
        Me.lbl_L2.Text = "A"
        Me.lbl_L2.Visible = False
        '
        'lbl_L1
        '
        Me.lbl_L1.AutoSize = True
        Me.lbl_L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_L1.Location = New System.Drawing.Point(340, 395)
        Me.lbl_L1.Name = "lbl_L1"
        Me.lbl_L1.Size = New System.Drawing.Size(15, 15)
        Me.lbl_L1.TabIndex = 49
        Me.lbl_L1.Text = "A"
        Me.lbl_L1.Visible = False
        '
        'lbl_Linea
        '
        Me.lbl_Linea.AutoSize = True
        Me.lbl_Linea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Linea.Location = New System.Drawing.Point(319, 395)
        Me.lbl_Linea.Name = "lbl_Linea"
        Me.lbl_Linea.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Linea.TabIndex = 48
        Me.lbl_Linea.Text = "A"
        Me.lbl_Linea.Visible = False
        '
        'lbl_Familia
        '
        Me.lbl_Familia.AutoSize = True
        Me.lbl_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Familia.Location = New System.Drawing.Point(298, 395)
        Me.lbl_Familia.Name = "lbl_Familia"
        Me.lbl_Familia.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Familia.TabIndex = 47
        Me.lbl_Familia.Text = "A"
        Me.lbl_Familia.Visible = False
        '
        'lbl_Depto
        '
        Me.lbl_Depto.AutoSize = True
        Me.lbl_Depto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Depto.Location = New System.Drawing.Point(277, 395)
        Me.lbl_Depto.Name = "lbl_Depto"
        Me.lbl_Depto.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Depto.TabIndex = 46
        Me.lbl_Depto.Text = "A"
        Me.lbl_Depto.Visible = False
        '
        'lbl_Division
        '
        Me.lbl_Division.AutoSize = True
        Me.lbl_Division.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Division.Location = New System.Drawing.Point(256, 395)
        Me.lbl_Division.Name = "lbl_Division"
        Me.lbl_Division.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Division.TabIndex = 45
        Me.lbl_Division.Text = "A"
        Me.lbl_Division.Visible = False
        '
        'lbl_Sucursal
        '
        Me.lbl_Sucursal.AutoSize = True
        Me.lbl_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Sucursal.Location = New System.Drawing.Point(232, 395)
        Me.lbl_Sucursal.Name = "lbl_Sucursal"
        Me.lbl_Sucursal.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Sucursal.TabIndex = 44
        Me.lbl_Sucursal.Text = "A"
        Me.lbl_Sucursal.Visible = False
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
        Me.DGrid.ContextMenuStrip = Me.CMenu1
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(1174, 456)
        Me.DGrid.TabIndex = 2
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSucursal, Me.ToolStripMenuItemDivision, Me.ToolStripMenuItemDepto, Me.ToolStripMenuItemFamilia, Me.ToolStripMenuItemLinea, Me.ToolStripMenuItemL1, Me.ToolStripMenuItemL2, Me.ToolStripMenuItemL3, Me.ToolStripMenuItemL4, Me.ToolStripMenuItemL5, Me.ToolStripMenuItemL6, Me.ToolStripMenuItemMarca, Me.ToolStripMenuItemModelo, Me.ToolStripMenuItemCatModelo, Me.ToolStripMenuItemAnaModelo, Me.ToolStripSeparator1, Me.ToolStripMenuItemInicio})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(188, 362)
        '
        'ToolStripMenuItemSucursal
        '
        Me.ToolStripMenuItemSucursal.Image = Global.SIRCO.My.Resources.Resources.store_plus
        Me.ToolStripMenuItemSucursal.Name = "ToolStripMenuItemSucursal"
        Me.ToolStripMenuItemSucursal.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemSucursal.Text = "Sucursal"
        '
        'ToolStripMenuItemDivision
        '
        Me.ToolStripMenuItemDivision.Image = Global.SIRCO.My.Resources.Resources.box_full
        Me.ToolStripMenuItemDivision.Name = "ToolStripMenuItemDivision"
        Me.ToolStripMenuItemDivision.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemDivision.Text = "División"
        '
        'ToolStripMenuItemDepto
        '
        Me.ToolStripMenuItemDepto.Image = Global.SIRCO.My.Resources.Resources.DEPTOS
        Me.ToolStripMenuItemDepto.Name = "ToolStripMenuItemDepto"
        Me.ToolStripMenuItemDepto.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemDepto.Text = "Departamento"
        '
        'ToolStripMenuItemFamilia
        '
        Me.ToolStripMenuItemFamilia.Image = Global.SIRCO.My.Resources.Resources.usuario1
        Me.ToolStripMenuItemFamilia.Name = "ToolStripMenuItemFamilia"
        Me.ToolStripMenuItemFamilia.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemFamilia.Text = "Familia"
        '
        'ToolStripMenuItemLinea
        '
        Me.ToolStripMenuItemLinea.Image = CType(resources.GetObject("ToolStripMenuItemLinea.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemLinea.Name = "ToolStripMenuItemLinea"
        Me.ToolStripMenuItemLinea.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemLinea.Text = "Linea"
        '
        'ToolStripMenuItemL1
        '
        Me.ToolStripMenuItemL1.Image = CType(resources.GetObject("ToolStripMenuItemL1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemL1.Name = "ToolStripMenuItemL1"
        Me.ToolStripMenuItemL1.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemL1.Text = "L1"
        '
        'ToolStripMenuItemL2
        '
        Me.ToolStripMenuItemL2.Image = CType(resources.GetObject("ToolStripMenuItemL2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemL2.Name = "ToolStripMenuItemL2"
        Me.ToolStripMenuItemL2.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemL2.Text = "L2"
        '
        'ToolStripMenuItemL3
        '
        Me.ToolStripMenuItemL3.Image = CType(resources.GetObject("ToolStripMenuItemL3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemL3.Name = "ToolStripMenuItemL3"
        Me.ToolStripMenuItemL3.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemL3.Text = "L3"
        '
        'ToolStripMenuItemL4
        '
        Me.ToolStripMenuItemL4.Image = CType(resources.GetObject("ToolStripMenuItemL4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemL4.Name = "ToolStripMenuItemL4"
        Me.ToolStripMenuItemL4.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemL4.Text = "L4"
        '
        'ToolStripMenuItemL5
        '
        Me.ToolStripMenuItemL5.Image = CType(resources.GetObject("ToolStripMenuItemL5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemL5.Name = "ToolStripMenuItemL5"
        Me.ToolStripMenuItemL5.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemL5.Text = "L5"
        '
        'ToolStripMenuItemL6
        '
        Me.ToolStripMenuItemL6.Image = CType(resources.GetObject("ToolStripMenuItemL6.Image"), System.Drawing.Image)
        Me.ToolStripMenuItemL6.Name = "ToolStripMenuItemL6"
        Me.ToolStripMenuItemL6.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemL6.Text = "L6"
        '
        'ToolStripMenuItemMarca
        '
        Me.ToolStripMenuItemMarca.Image = Global.SIRCO.My.Resources.Resources.document_mark_as_final
        Me.ToolStripMenuItemMarca.Name = "ToolStripMenuItemMarca"
        Me.ToolStripMenuItemMarca.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemMarca.Text = "Marca"
        '
        'ToolStripMenuItemModelo
        '
        Me.ToolStripMenuItemModelo.Image = Global.SIRCO.My.Resources.Resources.ZAPATO
        Me.ToolStripMenuItemModelo.Name = "ToolStripMenuItemModelo"
        Me.ToolStripMenuItemModelo.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemModelo.Text = "Modelo"
        '
        'ToolStripMenuItemCatModelo
        '
        Me.ToolStripMenuItemCatModelo.Image = Global.SIRCO.My.Resources.Resources.document_add
        Me.ToolStripMenuItemCatModelo.Name = "ToolStripMenuItemCatModelo"
        Me.ToolStripMenuItemCatModelo.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemCatModelo.Text = "Catálogo de Modelos"
        '
        'ToolStripMenuItemAnaModelo
        '
        Me.ToolStripMenuItemAnaModelo.Image = Global.SIRCO.My.Resources.Resources.monitoreo
        Me.ToolStripMenuItemAnaModelo.Name = "ToolStripMenuItemAnaModelo"
        Me.ToolStripMenuItemAnaModelo.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemAnaModelo.Text = "Análisis de Modelos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'ToolStripMenuItemInicio
        '
        Me.ToolStripMenuItemInicio.Image = Global.SIRCO.My.Resources.Resources.arrowright
        Me.ToolStripMenuItemInicio.Name = "ToolStripMenuItemInicio"
        Me.ToolStripMenuItemInicio.Size = New System.Drawing.Size(187, 22)
        Me.ToolStripMenuItemInicio.Text = "Inicio"
        '
        'Pnl_Bar
        '
        Me.Pnl_Bar.Controls.Add(Me.PictureBox1)
        Me.Pnl_Bar.Controls.Add(Me.LBL_PORC)
        Me.Pnl_Bar.Controls.Add(Me.Label1)
        Me.Pnl_Bar.Controls.Add(Me.Pbar1)
        Me.Pnl_Bar.Location = New System.Drawing.Point(355, 3)
        Me.Pnl_Bar.Name = "Pnl_Bar"
        Me.Pnl_Bar.Size = New System.Drawing.Size(473, 98)
        Me.Pnl_Bar.TabIndex = 1
        Me.Pnl_Bar.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SIRCO.My.Resources.Resources.ordenador04
        Me.PictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'LBL_PORC
        '
        Me.LBL_PORC.AutoSize = True
        Me.LBL_PORC.Location = New System.Drawing.Point(245, 69)
        Me.LBL_PORC.Name = "LBL_PORC"
        Me.LBL_PORC.Size = New System.Drawing.Size(39, 13)
        Me.LBL_PORC.TabIndex = 3
        Me.LBL_PORC.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Espere mientras procesamos la información..."
        '
        'Pbar1
        '
        Me.Pbar1.Location = New System.Drawing.Point(99, 34)
        Me.Pbar1.Name = "Pbar1"
        Me.Pbar1.Size = New System.Drawing.Size(349, 22)
        Me.Pbar1.TabIndex = 1
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Lbl_UltMod)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Actualizar)
        Me.Pnl_Botones.Controls.Add(Me.Pnl_Pares)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Periodo)
        Me.Pnl_Botones.Controls.Add(Me.lbl_Final)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_FUM)
        Me.Pnl_Botones.Controls.Add(Me.GB_Sucursales)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Calzado)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Foto)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1178, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Actualizar
        '
        Me.Btn_Actualizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Actualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Actualizar.Image = CType(resources.GetObject("Btn_Actualizar.Image"), System.Drawing.Image)
        Me.Btn_Actualizar.Location = New System.Drawing.Point(868, 0)
        Me.Btn_Actualizar.Name = "Btn_Actualizar"
        Me.Btn_Actualizar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Actualizar.TabIndex = 60
        Me.Btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Actualizar.UseVisualStyleBackColor = True
        '
        'Pnl_Pares
        '
        Me.Pnl_Pares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Pares.Controls.Add(Me.Label4)
        Me.Pnl_Pares.Controls.Add(Me.Label3)
        Me.Pnl_Pares.Controls.Add(Me.Label2)
        Me.Pnl_Pares.Controls.Add(Me.Txt_CtdFin)
        Me.Pnl_Pares.Controls.Add(Me.Txt_CtdIni)
        Me.Pnl_Pares.Location = New System.Drawing.Point(578, 24)
        Me.Pnl_Pares.Name = "Pnl_Pares"
        Me.Pnl_Pares.Size = New System.Drawing.Size(216, 27)
        Me.Pnl_Pares.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pares"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "a"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "De"
        '
        'Txt_CtdFin
        '
        Me.Txt_CtdFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CtdFin.Location = New System.Drawing.Point(118, 2)
        Me.Txt_CtdFin.Name = "Txt_CtdFin"
        Me.Txt_CtdFin.Size = New System.Drawing.Size(41, 20)
        Me.Txt_CtdFin.TabIndex = 1
        Me.Txt_CtdFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_CtdIni
        '
        Me.Txt_CtdIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CtdIni.Location = New System.Drawing.Point(39, 2)
        Me.Txt_CtdIni.Name = "Txt_CtdIni"
        Me.Txt_CtdIni.Size = New System.Drawing.Size(41, 20)
        Me.Txt_CtdIni.TabIndex = 0
        Me.Txt_CtdIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_Periodo
        '
        Me.Lbl_Periodo.AutoSize = True
        Me.Lbl_Periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Periodo.Location = New System.Drawing.Point(298, 34)
        Me.Lbl_Periodo.Name = "Lbl_Periodo"
        Me.Lbl_Periodo.Size = New System.Drawing.Size(57, 15)
        Me.Lbl_Periodo.TabIndex = 58
        Me.Lbl_Periodo.Text = "Periodo"
        '
        'lbl_Final
        '
        Me.lbl_Final.AutoSize = True
        Me.lbl_Final.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Final.Location = New System.Drawing.Point(206, 7)
        Me.lbl_Final.Name = "lbl_Final"
        Me.lbl_Final.Size = New System.Drawing.Size(15, 15)
        Me.lbl_Final.TabIndex = 43
        Me.lbl_Final.Text = "A"
        '
        'Lbl_FUM
        '
        Me.Lbl_FUM.AutoSize = True
        Me.Lbl_FUM.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FUM.Location = New System.Drawing.Point(270, 30)
        Me.Lbl_FUM.Name = "Lbl_FUM"
        Me.Lbl_FUM.Size = New System.Drawing.Size(0, 20)
        Me.Lbl_FUM.TabIndex = 42
        '
        'GB_Sucursales
        '
        Me.GB_Sucursales.Controls.Add(Me.RB_SinLerdo)
        Me.GB_Sucursales.Controls.Add(Me.RB_Activas)
        Me.GB_Sucursales.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_Sucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_Sucursales.Location = New System.Drawing.Point(0, 0)
        Me.GB_Sucursales.Name = "GB_Sucursales"
        Me.GB_Sucursales.Size = New System.Drawing.Size(190, 52)
        Me.GB_Sucursales.TabIndex = 41
        Me.GB_Sucursales.TabStop = False
        Me.GB_Sucursales.Text = "Sucursales"
        '
        'RB_SinLerdo
        '
        Me.RB_SinLerdo.AutoSize = True
        Me.RB_SinLerdo.Location = New System.Drawing.Point(69, 23)
        Me.RB_SinLerdo.Name = "RB_SinLerdo"
        Me.RB_SinLerdo.Size = New System.Drawing.Size(117, 17)
        Me.RB_SinLerdo.TabIndex = 1
        Me.RB_SinLerdo.Text = "Activas S/Lerdo"
        Me.RB_SinLerdo.UseVisualStyleBackColor = True
        '
        'RB_Activas
        '
        Me.RB_Activas.AutoSize = True
        Me.RB_Activas.Location = New System.Drawing.Point(3, 23)
        Me.RB_Activas.Name = "RB_Activas"
        Me.RB_Activas.Size = New System.Drawing.Size(67, 17)
        Me.RB_Activas.TabIndex = 0
        Me.RB_Activas.Text = "Activas"
        Me.RB_Activas.UseVisualStyleBackColor = True
        '
        'Chk_Calzado
        '
        Me.Chk_Calzado.AutoSize = True
        Me.Chk_Calzado.Location = New System.Drawing.Point(206, 35)
        Me.Chk_Calzado.Name = "Chk_Calzado"
        Me.Chk_Calzado.Size = New System.Drawing.Size(64, 17)
        Me.Chk_Calzado.TabIndex = 0
        Me.Chk_Calzado.Text = "Calzado"
        Me.Chk_Calzado.UseVisualStyleBackColor = True
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(919, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 1
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        '
        'Btn_Foto
        '
        Me.Btn_Foto.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Foto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Foto.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.Btn_Foto.Location = New System.Drawing.Point(970, 0)
        Me.Btn_Foto.Name = "Btn_Foto"
        Me.Btn_Foto.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Foto.TabIndex = 2
        Me.Btn_Foto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Foto.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(1021, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 3
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1072, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 4
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1123, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Lbl_UltMod
        '
        Me.Lbl_UltMod.AutoSize = True
        Me.Lbl_UltMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_UltMod.Location = New System.Drawing.Point(587, 33)
        Me.Lbl_UltMod.Name = "Lbl_UltMod"
        Me.Lbl_UltMod.Size = New System.Drawing.Size(57, 15)
        Me.Lbl_UltMod.TabIndex = 61
        Me.Lbl_UltMod.Text = "Ult Mod"
        Me.Lbl_UltMod.Visible = False
        '
        'frmPpalVentasCero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalVentasCero"
        Me.Text = "Ventas Cero"
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Pnl_Grid.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.Pnl_Pares.ResumeLayout(False)
        Me.Pnl_Pares.PerformLayout()
        Me.GB_Sucursales.ResumeLayout(False)
        Me.GB_Sucursales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Pnl_Bar As System.Windows.Forms.Panel
    Friend WithEvents LBL_PORC As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Regresar As System.Windows.Forms.Button
    Friend WithEvents Btn_Foto As System.Windows.Forms.Button
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Chk_Calzado As System.Windows.Forms.CheckBox
    Friend WithEvents GB_Sucursales As System.Windows.Forms.GroupBox
    Friend WithEvents RB_SinLerdo As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Activas As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripMenuItemSucursal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDivision As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDepto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFamilia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemL1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemL2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemL3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemL4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemL5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemL6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMarca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemModelo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lbl_FUM As System.Windows.Forms.Label
    Friend WithEvents lbl_Final As System.Windows.Forms.Label
    Friend WithEvents lbl_Modelo As System.Windows.Forms.Label
    Friend WithEvents lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents lbl_L6 As System.Windows.Forms.Label
    Friend WithEvents lbl_L5 As System.Windows.Forms.Label
    Friend WithEvents lbl_L4 As System.Windows.Forms.Label
    Friend WithEvents lbl_L3 As System.Windows.Forms.Label
    Friend WithEvents lbl_L2 As System.Windows.Forms.Label
    Friend WithEvents lbl_L1 As System.Windows.Forms.Label
    Friend WithEvents lbl_Linea As System.Windows.Forms.Label
    Friend WithEvents lbl_Familia As System.Windows.Forms.Label
    Friend WithEvents lbl_Depto As System.Windows.Forms.Label
    Friend WithEvents lbl_Division As System.Windows.Forms.Label
    Friend WithEvents lbl_Sucursal As System.Windows.Forms.Label
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItemCatModelo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAnaModelo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lbl_Periodo As System.Windows.Forms.Label
    Friend WithEvents Pnl_Pares As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_CtdFin As System.Windows.Forms.TextBox
    Friend WithEvents Txt_CtdIni As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Actualizar As System.Windows.Forms.Button
    Friend WithEvents Lbl_UltMod As System.Windows.Forms.Label
End Class
