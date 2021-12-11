<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalNomina))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.Pnl_Bar = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LBL_PORC = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pbar1 = New System.Windows.Forms.ProgressBar
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_BanBajio = New System.Windows.Forms.Button
        Me.Chk_AguiTemp = New System.Windows.Forms.CheckBox
        Me.Chk_Aguinaldo = New System.Windows.Forms.CheckBox
        Me.Chk_Filtros = New System.Windows.Forms.CheckBox
        Me.Btn_InvertirSeleccion = New System.Windows.Forms.Button
        Me.Btn_ImprimirRpt = New System.Windows.Forms.Button
        Me.Chk_IdEmpleado = New System.Windows.Forms.CheckBox
        Me.Chk_VerDepto = New System.Windows.Forms.CheckBox
        Me.Btn_Layout = New System.Windows.Forms.Button
        Me.Btn_PercDeduc = New System.Windows.Forms.Button
        Me.Btn_Filtro = New System.Windows.Forms.Button
        Me.Btn_Imprimir = New System.Windows.Forms.Button
        Me.Btn_Excel = New System.Windows.Forms.Button
        Me.Btn_Empleado = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Btn_Sucursal = New System.Windows.Forms.Button
        Me.Btn_Nomina = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarSelecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Grid.SuspendLayout()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.CMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Bar)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(830, 460)
        Me.Pnl_Grid.TabIndex = 4
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.Size = New System.Drawing.Size(826, 456)
        Me.DGrid.TabIndex = 0
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_BanBajio)
        Me.Pnl_Botones.Controls.Add(Me.Chk_AguiTemp)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Aguinaldo)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Filtros)
        Me.Pnl_Botones.Controls.Add(Me.Btn_InvertirSeleccion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_ImprimirRpt)
        Me.Pnl_Botones.Controls.Add(Me.Chk_IdEmpleado)
        Me.Pnl_Botones.Controls.Add(Me.Chk_VerDepto)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Layout)
        Me.Pnl_Botones.Controls.Add(Me.Btn_PercDeduc)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Empleado)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Sucursal)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nomina)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_BanBajio
        '
        Me.Btn_BanBajio.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BanBajio.Image = Global.SIRCO.My.Resources.Resources.invoice
        Me.Btn_BanBajio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_BanBajio.Location = New System.Drawing.Point(304, 0)
        Me.Btn_BanBajio.Name = "Btn_BanBajio"
        Me.Btn_BanBajio.Size = New System.Drawing.Size(51, 52)
        Me.Btn_BanBajio.TabIndex = 20
        Me.Btn_BanBajio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_BanBajio.UseVisualStyleBackColor = True
        '
        'Chk_AguiTemp
        '
        Me.Chk_AguiTemp.AutoSize = True
        Me.Chk_AguiTemp.Location = New System.Drawing.Point(628, 4)
        Me.Chk_AguiTemp.Name = "Chk_AguiTemp"
        Me.Chk_AguiTemp.Size = New System.Drawing.Size(173, 17)
        Me.Chk_AguiTemp.TabIndex = 19
        Me.Chk_AguiTemp.Text = "Ver Solo Aguinaldo Temporada"
        Me.Chk_AguiTemp.UseVisualStyleBackColor = True
        Me.Chk_AguiTemp.Visible = False
        '
        'Chk_Aguinaldo
        '
        Me.Chk_Aguinaldo.AutoSize = True
        Me.Chk_Aguinaldo.Location = New System.Drawing.Point(464, 25)
        Me.Chk_Aguinaldo.Name = "Chk_Aguinaldo"
        Me.Chk_Aguinaldo.Size = New System.Drawing.Size(172, 17)
        Me.Chk_Aguinaldo.TabIndex = 18
        Me.Chk_Aguinaldo.Text = "Ver Solo Aguinaldo a Dispersar"
        Me.Chk_Aguinaldo.UseVisualStyleBackColor = True
        Me.Chk_Aguinaldo.Visible = False
        '
        'Chk_Filtros
        '
        Me.Chk_Filtros.AutoSize = True
        Me.Chk_Filtros.Location = New System.Drawing.Point(464, 4)
        Me.Chk_Filtros.Name = "Chk_Filtros"
        Me.Chk_Filtros.Size = New System.Drawing.Size(92, 17)
        Me.Chk_Filtros.TabIndex = 17
        Me.Chk_Filtros.Text = "Eliminar Filtros"
        Me.Chk_Filtros.UseVisualStyleBackColor = True
        '
        'Btn_InvertirSeleccion
        '
        Me.Btn_InvertirSeleccion.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_InvertirSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_InvertirSeleccion.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.Btn_InvertirSeleccion.Location = New System.Drawing.Point(571, 0)
        Me.Btn_InvertirSeleccion.Name = "Btn_InvertirSeleccion"
        Me.Btn_InvertirSeleccion.Size = New System.Drawing.Size(51, 52)
        Me.Btn_InvertirSeleccion.TabIndex = 16
        Me.Btn_InvertirSeleccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_InvertirSeleccion.UseVisualStyleBackColor = True
        '
        'Btn_ImprimirRpt
        '
        Me.Btn_ImprimirRpt.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_ImprimirRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ImprimirRpt.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_ImprimirRpt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_ImprimirRpt.Location = New System.Drawing.Point(622, 0)
        Me.Btn_ImprimirRpt.Name = "Btn_ImprimirRpt"
        Me.Btn_ImprimirRpt.Size = New System.Drawing.Size(51, 52)
        Me.Btn_ImprimirRpt.TabIndex = 15
        Me.Btn_ImprimirRpt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ImprimirRpt.UseVisualStyleBackColor = True
        '
        'Chk_IdEmpleado
        '
        Me.Chk_IdEmpleado.AutoSize = True
        Me.Chk_IdEmpleado.Location = New System.Drawing.Point(355, 2)
        Me.Chk_IdEmpleado.Name = "Chk_IdEmpleado"
        Me.Chk_IdEmpleado.Size = New System.Drawing.Size(106, 17)
        Me.Chk_IdEmpleado.TabIndex = 14
        Me.Chk_IdEmpleado.Text = "Ver ID Empleado"
        Me.Chk_IdEmpleado.UseVisualStyleBackColor = True
        '
        'Chk_VerDepto
        '
        Me.Chk_VerDepto.AutoSize = True
        Me.Chk_VerDepto.Location = New System.Drawing.Point(355, 25)
        Me.Chk_VerDepto.Name = "Chk_VerDepto"
        Me.Chk_VerDepto.Size = New System.Drawing.Size(112, 17)
        Me.Chk_VerDepto.TabIndex = 13
        Me.Chk_VerDepto.Text = "Ver Departamento"
        Me.Chk_VerDepto.UseVisualStyleBackColor = True
        '
        'Btn_Layout
        '
        Me.Btn_Layout.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Layout.Image = Global.SIRCO.My.Resources.Resources.LAYOUTBANCO
        Me.Btn_Layout.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Layout.Location = New System.Drawing.Point(256, 0)
        Me.Btn_Layout.Name = "Btn_Layout"
        Me.Btn_Layout.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Layout.TabIndex = 12
        Me.Btn_Layout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Layout.UseVisualStyleBackColor = True
        Me.Btn_Layout.Visible = False
        '
        'Btn_PercDeduc
        '
        Me.Btn_PercDeduc.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_PercDeduc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_PercDeduc.Image = Global.SIRCO.My.Resources.Resources.percdeduc
        Me.Btn_PercDeduc.Location = New System.Drawing.Point(153, 0)
        Me.Btn_PercDeduc.Name = "Btn_PercDeduc"
        Me.Btn_PercDeduc.Size = New System.Drawing.Size(51, 52)
        Me.Btn_PercDeduc.TabIndex = 11
        Me.Btn_PercDeduc.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_PercDeduc.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(673, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 9
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(210, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 8
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(724, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 7
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Empleado
        '
        Me.Btn_Empleado.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Empleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Empleado.Image = Global.SIRCO.My.Resources.Resources.employe
        Me.Btn_Empleado.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Empleado.Name = "Btn_Empleado"
        Me.Btn_Empleado.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Empleado.TabIndex = 6
        Me.Btn_Empleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Empleado.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(775, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Sucursal
        '
        Me.Btn_Sucursal.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sucursal.Image = Global.SIRCO.My.Resources.Resources.store_plus
        Me.Btn_Sucursal.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Sucursal.Name = "Btn_Sucursal"
        Me.Btn_Sucursal.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Sucursal.TabIndex = 1
        Me.Btn_Sucursal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Sucursal.UseVisualStyleBackColor = True
        '
        'Btn_Nomina
        '
        Me.Btn_Nomina.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Nomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nomina.Image = Global.SIRCO.My.Resources.Resources.emblem_money
        Me.Btn_Nomina.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Nomina.Name = "Btn_Nomina"
        Me.Btn_Nomina.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Nomina.TabIndex = 0
        Me.Btn_Nomina.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nomina.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarSelecciónToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(163, 26)
        '
        'CopiarSelecciónToolStripMenuItem
        '
        Me.CopiarSelecciónToolStripMenuItem.Image = CType(resources.GetObject("CopiarSelecciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopiarSelecciónToolStripMenuItem.Name = "CopiarSelecciónToolStripMenuItem"
        Me.CopiarSelecciónToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.CopiarSelecciónToolStripMenuItem.Text = "Copiar Selección"
        '
        'frmPpalNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalNomina"
        Me.Text = "Nóminas Calculadas"
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.CMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Empleado As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Sucursal As System.Windows.Forms.Button
    Friend WithEvents Btn_Nomina As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_PercDeduc As System.Windows.Forms.Button
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Layout As System.Windows.Forms.Button
    Friend WithEvents Pnl_Bar As System.Windows.Forms.Panel
    Friend WithEvents LBL_PORC As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Chk_VerDepto As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_IdEmpleado As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_ImprimirRpt As System.Windows.Forms.Button
    Friend WithEvents Btn_InvertirSeleccion As System.Windows.Forms.Button
    Friend WithEvents Chk_Filtros As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Aguinaldo As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_AguiTemp As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_BanBajio As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarSelecciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
