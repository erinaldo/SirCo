<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalActividadesEmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalActividadesEmp))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.MenuAct = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ModificarActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProcesoActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelarActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RealizadoActEmpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Chk_Solucion = New System.Windows.Forms.CheckBox
        Me.Btn_Realizado = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_NoAplica = New System.Windows.Forms.Button
        Me.Btn_Espera = New System.Windows.Forms.Button
        Me.Btn_Pausa = New System.Windows.Forms.Button
        Me.Btn_EnProc = New System.Windows.Forms.Button
        Me.Btn_Consultar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Btn_Filtro = New System.Windows.Forms.Button
        Me.Btn_Excel = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuAct.SuspendLayout()
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
        Me.DGrid.ContextMenuStrip = Me.MenuAct
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(826, 456)
        Me.DGrid.TabIndex = 0
        '
        'MenuAct
        '
        Me.MenuAct.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModificarActEmpToolStripMenuItem, Me.ConsultarActEmpToolStripMenuItem, Me.ProcesoActEmpToolStripMenuItem, Me.CancelarActEmpToolStripMenuItem, Me.RealizadoActEmpToolStripMenuItem})
        Me.MenuAct.Name = "CMenu1"
        Me.MenuAct.Size = New System.Drawing.Size(220, 114)
        '
        'ModificarActEmpToolStripMenuItem
        '
        Me.ModificarActEmpToolStripMenuItem.Checked = True
        Me.ModificarActEmpToolStripMenuItem.CheckOnClick = True
        Me.ModificarActEmpToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ModificarActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarActEmpToolStripMenuItem.Name = "ModificarActEmpToolStripMenuItem"
        Me.ModificarActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ModificarActEmpToolStripMenuItem.Text = "Modificar Actividad"
        '
        'ConsultarActEmpToolStripMenuItem
        '
        Me.ConsultarActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarActEmpToolStripMenuItem.Name = "ConsultarActEmpToolStripMenuItem"
        Me.ConsultarActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ConsultarActEmpToolStripMenuItem.Text = "Consultar Actividad"
        '
        'ProcesoActEmpToolStripMenuItem
        '
        Me.ProcesoActEmpToolStripMenuItem.Image = CType(resources.GetObject("ProcesoActEmpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ProcesoActEmpToolStripMenuItem.Name = "ProcesoActEmpToolStripMenuItem"
        Me.ProcesoActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ProcesoActEmpToolStripMenuItem.Text = "Poner Actividad en Proceso"
        '
        'CancelarActEmpToolStripMenuItem
        '
        Me.CancelarActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.cancel
        Me.CancelarActEmpToolStripMenuItem.Name = "CancelarActEmpToolStripMenuItem"
        Me.CancelarActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.CancelarActEmpToolStripMenuItem.Text = "Cancelar Actividad"
        '
        'RealizadoActEmpToolStripMenuItem
        '
        Me.RealizadoActEmpToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.RealizadoActEmpToolStripMenuItem.Name = "RealizadoActEmpToolStripMenuItem"
        Me.RealizadoActEmpToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.RealizadoActEmpToolStripMenuItem.Text = "Finalizar Actividad"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Chk_Solucion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Realizado)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_NoAplica)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Espera)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Pausa)
        Me.Pnl_Botones.Controls.Add(Me.Btn_EnProc)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Chk_Solucion
        '
        Me.Chk_Solucion.AutoSize = True
        Me.Chk_Solucion.Location = New System.Drawing.Point(476, 15)
        Me.Chk_Solucion.Name = "Chk_Solucion"
        Me.Chk_Solucion.Size = New System.Drawing.Size(86, 17)
        Me.Chk_Solucion.TabIndex = 28
        Me.Chk_Solucion.Text = "Ver Solución"
        Me.Chk_Solucion.UseVisualStyleBackColor = True
        '
        'Btn_Realizado
        '
        Me.Btn_Realizado.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Realizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Realizado.Image = CType(resources.GetObject("Btn_Realizado.Image"), System.Drawing.Image)
        Me.Btn_Realizado.Location = New System.Drawing.Point(408, 0)
        Me.Btn_Realizado.Name = "Btn_Realizado"
        Me.Btn_Realizado.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Realizado.TabIndex = 27
        Me.Btn_Realizado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Realizado.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Cancelar.Location = New System.Drawing.Point(357, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 26
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_NoAplica
        '
        Me.Btn_NoAplica.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_NoAplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_NoAplica.Image = CType(resources.GetObject("Btn_NoAplica.Image"), System.Drawing.Image)
        Me.Btn_NoAplica.Location = New System.Drawing.Point(306, 0)
        Me.Btn_NoAplica.Name = "Btn_NoAplica"
        Me.Btn_NoAplica.Size = New System.Drawing.Size(51, 52)
        Me.Btn_NoAplica.TabIndex = 24
        Me.Btn_NoAplica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_NoAplica.UseVisualStyleBackColor = True
        '
        'Btn_Espera
        '
        Me.Btn_Espera.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Espera.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Espera.Image = CType(resources.GetObject("Btn_Espera.Image"), System.Drawing.Image)
        Me.Btn_Espera.Location = New System.Drawing.Point(255, 0)
        Me.Btn_Espera.Name = "Btn_Espera"
        Me.Btn_Espera.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Espera.TabIndex = 20
        Me.Btn_Espera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Espera.UseVisualStyleBackColor = True
        '
        'Btn_Pausa
        '
        Me.Btn_Pausa.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Pausa.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Pausa.Image = CType(resources.GetObject("Btn_Pausa.Image"), System.Drawing.Image)
        Me.Btn_Pausa.Location = New System.Drawing.Point(204, 0)
        Me.Btn_Pausa.Name = "Btn_Pausa"
        Me.Btn_Pausa.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Pausa.TabIndex = 19
        Me.Btn_Pausa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Pausa.UseVisualStyleBackColor = True
        '
        'Btn_EnProc
        '
        Me.Btn_EnProc.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_EnProc.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EnProc.Image = CType(resources.GetObject("Btn_EnProc.Image"), System.Drawing.Image)
        Me.Btn_EnProc.Location = New System.Drawing.Point(153, 0)
        Me.Btn_EnProc.Name = "Btn_EnProc"
        Me.Btn_EnProc.Size = New System.Drawing.Size(51, 52)
        Me.Btn_EnProc.TabIndex = 15
        Me.Btn_EnProc.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_EnProc.UseVisualStyleBackColor = True
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Consultar.TabIndex = 14
        Me.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Consultar.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Editar.TabIndex = 13
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
        Me.Btn_Nuevo.TabIndex = 12
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
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
        'frmPpalActividadesEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalActividadesEmp"
        Me.Text = "Help Desk"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuAct.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuAct As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ModificarActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Consultar As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_EnProc As System.Windows.Forms.Button
    Friend WithEvents ProcesoActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RealizadoActEmpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Espera As System.Windows.Forms.Button
    Friend WithEvents Btn_Pausa As System.Windows.Forms.Button
    Friend WithEvents Btn_NoAplica As System.Windows.Forms.Button
    Friend WithEvents Btn_Realizado As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Chk_Solucion As System.Windows.Forms.CheckBox
End Class
