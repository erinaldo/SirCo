﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalFormasPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalFormasPago))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.Pnl_Bar = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LBL_PORC = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pbar1 = New System.Windows.Forms.ProgressBar
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
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.lbl_Texto = New System.Windows.Forms.Label
        Me.GB_Transacciones = New System.Windows.Forms.GroupBox
        Me.RB_TranImportes = New System.Windows.Forms.RadioButton
        Me.RB_Transacciones = New System.Windows.Forms.RadioButton
        Me.RB_Importes = New System.Windows.Forms.RadioButton
        Me.Btn_Filtro = New System.Windows.Forms.Button
        Me.Btn_Excel = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Chk_Sucursal = New System.Windows.Forms.CheckBox
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.GB_Transacciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Bar)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(830, 460)
        Me.Pnl_Grid.TabIndex = 4
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
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(826, 456)
        Me.DGrid.TabIndex = 2
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
        Me.ToolStripMenuItemAnaModelo.Text = "Analisis de Modelos"
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
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Chk_Sucursal)
        Me.Pnl_Botones.Controls.Add(Me.lbl_Texto)
        Me.Pnl_Botones.Controls.Add(Me.GB_Transacciones)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'lbl_Texto
        '
        Me.lbl_Texto.AutoSize = True
        Me.lbl_Texto.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbl_Texto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Texto.Location = New System.Drawing.Point(240, 0)
        Me.lbl_Texto.Name = "lbl_Texto"
        Me.lbl_Texto.Size = New System.Drawing.Size(0, 16)
        Me.lbl_Texto.TabIndex = 11
        '
        'GB_Transacciones
        '
        Me.GB_Transacciones.Controls.Add(Me.RB_TranImportes)
        Me.GB_Transacciones.Controls.Add(Me.RB_Transacciones)
        Me.GB_Transacciones.Controls.Add(Me.RB_Importes)
        Me.GB_Transacciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.GB_Transacciones.Location = New System.Drawing.Point(0, 0)
        Me.GB_Transacciones.Name = "GB_Transacciones"
        Me.GB_Transacciones.Size = New System.Drawing.Size(240, 52)
        Me.GB_Transacciones.TabIndex = 10
        Me.GB_Transacciones.TabStop = False
        Me.GB_Transacciones.Text = "Operaciones"
        '
        'RB_TranImportes
        '
        Me.RB_TranImportes.AutoSize = True
        Me.RB_TranImportes.Location = New System.Drawing.Point(177, 19)
        Me.RB_TranImportes.Name = "RB_TranImportes"
        Me.RB_TranImportes.Size = New System.Drawing.Size(57, 17)
        Me.RB_TranImportes.TabIndex = 2
        Me.RB_TranImportes.TabStop = True
        Me.RB_TranImportes.Text = "Ambas"
        Me.RB_TranImportes.UseVisualStyleBackColor = True
        '
        'RB_Transacciones
        '
        Me.RB_Transacciones.AutoSize = True
        Me.RB_Transacciones.Location = New System.Drawing.Point(76, 19)
        Me.RB_Transacciones.Name = "RB_Transacciones"
        Me.RB_Transacciones.Size = New System.Drawing.Size(95, 17)
        Me.RB_Transacciones.TabIndex = 1
        Me.RB_Transacciones.TabStop = True
        Me.RB_Transacciones.Text = "Transacciones"
        Me.RB_Transacciones.UseVisualStyleBackColor = True
        '
        'RB_Importes
        '
        Me.RB_Importes.AutoSize = True
        Me.RB_Importes.Location = New System.Drawing.Point(10, 19)
        Me.RB_Importes.Name = "RB_Importes"
        Me.RB_Importes.Size = New System.Drawing.Size(60, 17)
        Me.RB_Importes.TabIndex = 0
        Me.RB_Importes.TabStop = True
        Me.RB_Importes.Text = "Importe"
        Me.RB_Importes.UseVisualStyleBackColor = True
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
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Chk_Sucursal
        '
        Me.Chk_Sucursal.AutoSize = True
        Me.Chk_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_Sucursal.Location = New System.Drawing.Point(246, 25)
        Me.Chk_Sucursal.Name = "Chk_Sucursal"
        Me.Chk_Sucursal.Size = New System.Drawing.Size(127, 17)
        Me.Chk_Sucursal.TabIndex = 40
        Me.Chk_Sucursal.Text = "Todas Sucursales"
        Me.Chk_Sucursal.UseVisualStyleBackColor = True
        '
        'frmPpalFormasPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalFormasPago"
        Me.Text = "Formas de Pago"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.GB_Transacciones.ResumeLayout(False)
        Me.GB_Transacciones.PerformLayout()
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
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
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
    Friend WithEvents ToolStripMenuItemCatModelo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAnaModelo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GB_Transacciones As System.Windows.Forms.GroupBox
    Friend WithEvents RB_TranImportes As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Transacciones As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Importes As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_Texto As System.Windows.Forms.Label
    Friend WithEvents Chk_Sucursal As System.Windows.Forms.CheckBox
End Class
