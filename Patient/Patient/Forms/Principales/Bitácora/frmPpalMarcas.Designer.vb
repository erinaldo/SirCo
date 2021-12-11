<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalMarcas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalMarcas))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Chk_Activas = New System.Windows.Forms.CheckBox
        Me.Btn_Asignar = New System.Windows.Forms.Button
        Me.Btn_Consultar = New System.Windows.Forms.Button
        Me.Btn_Filtro = New System.Windows.Forms.Button
        Me.Btn_Imprimir = New System.Windows.Forms.Button
        Me.Btn_Excel = New System.Windows.Forms.Button
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Btn_Activas = New System.Windows.Forms.Button
        Me.Btn_Inactivas = New System.Windows.Forms.Button
        Me.InactivaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
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
        Me.DGrid.ContextMenuStrip = Me.CMenu1
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(826, 456)
        Me.DGrid.TabIndex = 0
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProveedorToolStripMenuItem, Me.ModificarProveedorToolStripMenuItem, Me.ConsultarProveedorToolStripMenuItem, Me.ActivaToolStripMenuItem2, Me.InactivaToolStripMenuItem1})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(162, 114)
        '
        'NuevoProveedorToolStripMenuItem
        '
        Me.NuevoProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProveedorToolStripMenuItem.Name = "NuevoProveedorToolStripMenuItem"
        Me.NuevoProveedorToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.NuevoProveedorToolStripMenuItem.Text = "Nueva Marca"
        '
        'ModificarProveedorToolStripMenuItem
        '
        Me.ModificarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarProveedorToolStripMenuItem.Name = "ModificarProveedorToolStripMenuItem"
        Me.ModificarProveedorToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ModificarProveedorToolStripMenuItem.Text = "Modificar Marca"
        '
        'ConsultarProveedorToolStripMenuItem
        '
        Me.ConsultarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarProveedorToolStripMenuItem.Name = "ConsultarProveedorToolStripMenuItem"
        Me.ConsultarProveedorToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ConsultarProveedorToolStripMenuItem.Text = "Consultar Marca"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Inactivas)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Activas)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Activas)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Asignar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Chk_Activas
        '
        Me.Chk_Activas.AutoSize = True
        Me.Chk_Activas.Location = New System.Drawing.Point(397, 16)
        Me.Chk_Activas.Name = "Chk_Activas"
        Me.Chk_Activas.Size = New System.Drawing.Size(99, 17)
        Me.Chk_Activas.TabIndex = 13
        Me.Chk_Activas.Text = "Marcas Activas"
        Me.Chk_Activas.UseVisualStyleBackColor = True
        '
        'Btn_Asignar
        '
        Me.Btn_Asignar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Asignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Asignar.Image = Global.SIRCO.My.Resources.Resources.user_male1
        Me.Btn_Asignar.Location = New System.Drawing.Point(204, 0)
        Me.Btn_Asignar.Name = "Btn_Asignar"
        Me.Btn_Asignar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Asignar.TabIndex = 12
        Me.Btn_Asignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Asignar.UseVisualStyleBackColor = True
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.Location = New System.Drawing.Point(153, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Consultar.TabIndex = 11
        Me.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Consultar.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Enabled = False
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(622, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 9
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Enabled = False
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(673, 0)
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
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Eliminar.Enabled = False
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Eliminar.TabIndex = 6
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
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
        'Btn_Editar
        '
        Me.Btn_Editar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Editar.TabIndex = 1
        Me.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Editar.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Nuevo.TabIndex = 0
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Btn_Activas
        '
        Me.Btn_Activas.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Activas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Activas.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Activas.Location = New System.Drawing.Point(255, 0)
        Me.Btn_Activas.Name = "Btn_Activas"
        Me.Btn_Activas.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Activas.TabIndex = 14
        Me.Btn_Activas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Activas.UseVisualStyleBackColor = True
        '
        'Btn_Inactivas
        '
        Me.Btn_Inactivas.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Inactivas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Inactivas.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.Btn_Inactivas.Location = New System.Drawing.Point(306, 0)
        Me.Btn_Inactivas.Name = "Btn_Inactivas"
        Me.Btn_Inactivas.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Inactivas.TabIndex = 15
        Me.Btn_Inactivas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Inactivas.UseVisualStyleBackColor = True
        '
        'InactivaToolStripMenuItem1
        '
        Me.InactivaToolStripMenuItem1.Image = Global.SIRCO.My.Resources.Resources.cancel
        Me.InactivaToolStripMenuItem1.Name = "InactivaToolStripMenuItem1"
        Me.InactivaToolStripMenuItem1.Size = New System.Drawing.Size(161, 22)
        Me.InactivaToolStripMenuItem1.Text = "Marca Inactiva"
        '
        'ActivaToolStripMenuItem2
        '
        Me.ActivaToolStripMenuItem2.Image = Global.SIRCO.My.Resources.Resources.accept
        Me.ActivaToolStripMenuItem2.Name = "ActivaToolStripMenuItem2"
        Me.ActivaToolStripMenuItem2.Size = New System.Drawing.Size(161, 22)
        Me.ActivaToolStripMenuItem2.Text = "Marca Activa"
        '
        'frmPpalMarcas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalMarcas"
        Me.Text = "Catálogo de Marcas"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Consultar As System.Windows.Forms.Button
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Asignar As System.Windows.Forms.Button
    Friend WithEvents Chk_Activas As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Inactivas As System.Windows.Forms.Button
    Friend WithEvents Btn_Activas As System.Windows.Forms.Button
    Friend WithEvents ActivaToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InactivaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
