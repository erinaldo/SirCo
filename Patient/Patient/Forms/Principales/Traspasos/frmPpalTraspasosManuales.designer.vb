<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalTraspasosManuales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalTraspasosManuales))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Pnl_Bar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LBL_PORC = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pbar1 = New System.Windows.Forms.ProgressBar()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_ImprimirRpt = New System.Windows.Forms.Button()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Btn_Consultar = New System.Windows.Forms.Button()
        Me.Btn_Aplicar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Modificar = New System.Windows.Forms.Button()
        Me.Btn_Nuevo = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.PBox)
        Me.Pnl_Grid.Controls.Add(Me.Pnl_Bar)
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1174, 460)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PBox
        '
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(897, 3)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(270, 244)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 6
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'Pnl_Bar
        '
        Me.Pnl_Bar.Controls.Add(Me.PictureBox1)
        Me.Pnl_Bar.Controls.Add(Me.LBL_PORC)
        Me.Pnl_Bar.Controls.Add(Me.Label1)
        Me.Pnl_Bar.Controls.Add(Me.Pbar1)
        Me.Pnl_Bar.Location = New System.Drawing.Point(3, 21)
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
        Me.Label1.Location = New System.Drawing.Point(110, 18)
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
        Me.DGrid.AllowUserToResizeColumns = False
        Me.DGrid.AllowUserToResizeRows = False
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
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(1170, 456)
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_ImprimirRpt)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aplicar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Modificar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1174, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_ImprimirRpt
        '
        Me.Btn_ImprimirRpt.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_ImprimirRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ImprimirRpt.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_ImprimirRpt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_ImprimirRpt.Location = New System.Drawing.Point(966, 0)
        Me.Btn_ImprimirRpt.Name = "Btn_ImprimirRpt"
        Me.Btn_ImprimirRpt.Size = New System.Drawing.Size(51, 52)
        Me.Btn_ImprimirRpt.TabIndex = 41
        Me.Btn_ImprimirRpt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ImprimirRpt.UseVisualStyleBackColor = True
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Enabled = False
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(903, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 42
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.Location = New System.Drawing.Point(204, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Consultar.TabIndex = 40
        Me.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Consultar.UseVisualStyleBackColor = True
        '
        'Btn_Aplicar
        '
        Me.Btn_Aplicar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Aplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aplicar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aplicar.Location = New System.Drawing.Point(153, 0)
        Me.Btn_Aplicar.Name = "Btn_Aplicar"
        Me.Btn_Aplicar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aplicar.TabIndex = 39
        Me.Btn_Aplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aplicar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.Btn_Cancelar.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 38
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Modificar
        '
        Me.Btn_Modificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Modificar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Modificar.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Modificar.Name = "Btn_Modificar"
        Me.Btn_Modificar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Modificar.TabIndex = 37
        Me.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Modificar.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Nuevo.TabIndex = 11
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(1017, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 10
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(1068, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(1119, 0)
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
        'frmPpalTraspasosManuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalTraspasosManuales"
        Me.Text = "Trapasos Manuales"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Pnl_Bar As System.Windows.Forms.Panel
    Friend WithEvents LBL_PORC As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pbar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents Btn_Consultar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aplicar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Regresar As System.Windows.Forms.Button
    Friend WithEvents Btn_ImprimirRpt As System.Windows.Forms.Button
End Class
