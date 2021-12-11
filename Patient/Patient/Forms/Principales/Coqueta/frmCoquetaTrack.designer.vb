<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCoquetaTrack
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCoquetaTrack))
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Bot_Layout = New System.Windows.Forms.Button
        Me.Btn_Foto = New System.Windows.Forms.Button
        Me.Btn_Invertir = New System.Windows.Forms.Button
        Me.Btn_Excel = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.EstiloFabrica = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstiloNuestro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.C = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.I = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.De = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.A = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SKU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Track = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoEstiloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EliminarFilaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopiarSelecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PegarSelecciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProveedorToolStripMenuItem, Me.ModificarProveedorToolStripMenuItem})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(182, 48)
        '
        'NuevoProveedorToolStripMenuItem
        '
        Me.NuevoProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProveedorToolStripMenuItem.Name = "NuevoProveedorToolStripMenuItem"
        Me.NuevoProveedorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.NuevoProveedorToolStripMenuItem.Text = "Nuevo Proveedor"
        '
        'ModificarProveedorToolStripMenuItem
        '
        Me.ModificarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarProveedorToolStripMenuItem.Name = "ModificarProveedorToolStripMenuItem"
        Me.ModificarProveedorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ModificarProveedorToolStripMenuItem.Text = "Modificar Proveedor"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Bot_Layout)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Foto)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Invertir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 423)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1028, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Bot_Layout
        '
        Me.Bot_Layout.Dock = System.Windows.Forms.DockStyle.Left
        Me.Bot_Layout.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bot_Layout.Image = Global.SIRCO.My.Resources.Resources.send_email_user_alternative
        Me.Bot_Layout.Location = New System.Drawing.Point(0, 0)
        Me.Bot_Layout.Name = "Bot_Layout"
        Me.Bot_Layout.Size = New System.Drawing.Size(51, 52)
        Me.Bot_Layout.TabIndex = 33
        Me.Bot_Layout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Bot_Layout.UseVisualStyleBackColor = True
        '
        'Btn_Foto
        '
        Me.Btn_Foto.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Foto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Foto.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.Btn_Foto.Location = New System.Drawing.Point(769, 0)
        Me.Btn_Foto.Name = "Btn_Foto"
        Me.Btn_Foto.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Foto.TabIndex = 32
        Me.Btn_Foto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Foto.UseVisualStyleBackColor = True
        '
        'Btn_Invertir
        '
        Me.Btn_Invertir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Invertir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Invertir.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.Btn_Invertir.Location = New System.Drawing.Point(820, 0)
        Me.Btn_Invertir.Name = "Btn_Invertir"
        Me.Btn_Invertir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Invertir.TabIndex = 30
        Me.Btn_Invertir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Invertir.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.Location = New System.Drawing.Point(871, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 28
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(922, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 26
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(973, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 25
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(1028, 423)
        Me.Pnl_Grid.TabIndex = 2
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
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EstiloFabrica, Me.EstiloNuestro, Me.Descripcion, Me.C, Me.I, Me.De, Me.A, Me.SKU, Me.Track})
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(1024, 419)
        Me.DGrid.TabIndex = 24
        '
        'EstiloFabrica
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EstiloFabrica.DefaultCellStyle = DataGridViewCellStyle2
        Me.EstiloFabrica.HeaderText = "Estilo Fábrica"
        Me.EstiloFabrica.MaxInputLength = 14
        Me.EstiloFabrica.Name = "EstiloFabrica"
        Me.EstiloFabrica.Width = 90
        '
        'EstiloNuestro
        '
        Me.EstiloNuestro.HeaderText = "Estilo Nuestro"
        Me.EstiloNuestro.Name = "EstiloNuestro"
        Me.EstiloNuestro.Width = 70
        '
        'Descripcion
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Descripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.MaxInputLength = 70
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 200
        '
        'C
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.C.DefaultCellStyle = DataGridViewCellStyle4
        Me.C.HeaderText = "C"
        Me.C.MaxInputLength = 1
        Me.C.Name = "C"
        Me.C.Width = 20
        '
        'I
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.I.DefaultCellStyle = DataGridViewCellStyle5
        Me.I.HeaderText = "I"
        Me.I.Name = "I"
        Me.I.ReadOnly = True
        Me.I.Visible = False
        Me.I.Width = 20
        '
        'De
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.De.DefaultCellStyle = DataGridViewCellStyle6
        Me.De.HeaderText = "Medida:"
        Me.De.Name = "De"
        Me.De.ReadOnly = True
        Me.De.Width = 50
        '
        'A
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.A.DefaultCellStyle = DataGridViewCellStyle7
        Me.A.HeaderText = "A:"
        Me.A.Name = "A"
        Me.A.ReadOnly = True
        Me.A.Visible = False
        Me.A.Width = 33
        '
        'SKU
        '
        Me.SKU.HeaderText = "SKU"
        Me.SKU.MaxInputLength = 13
        Me.SKU.Name = "SKU"
        Me.SKU.Width = 150
        '
        'Track
        '
        Me.Track.HeaderText = "Track"
        Me.Track.Name = "Track"
        Me.Track.Visible = False
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoEstiloToolStripMenuItem, Me.EditarToolStripMenuItem, Me.EliminarFilaToolStripMenuItem, Me.CopiarSelecciónToolStripMenuItem, Me.PegarSelecciónToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(164, 114)
        '
        'NuevoEstiloToolStripMenuItem
        '
        Me.NuevoEstiloToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoEstiloToolStripMenuItem.Name = "NuevoEstiloToolStripMenuItem"
        Me.NuevoEstiloToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.NuevoEstiloToolStripMenuItem.Text = "Nuevo Estilo"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.EditarToolStripMenuItem.Text = "Editar Estilo"
        '
        'EliminarFilaToolStripMenuItem
        '
        Me.EliminarFilaToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.EliminarFilaToolStripMenuItem.Name = "EliminarFilaToolStripMenuItem"
        Me.EliminarFilaToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.EliminarFilaToolStripMenuItem.Text = "Eliminar Fila"
        '
        'CopiarSelecciónToolStripMenuItem
        '
        Me.CopiarSelecciónToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Paper_pencil
        Me.CopiarSelecciónToolStripMenuItem.Name = "CopiarSelecciónToolStripMenuItem"
        Me.CopiarSelecciónToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CopiarSelecciónToolStripMenuItem.Text = "Copiar Selección"
        '
        'PegarSelecciónToolStripMenuItem
        '
        Me.PegarSelecciónToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.percdeduc
        Me.PegarSelecciónToolStripMenuItem.Name = "PegarSelecciónToolStripMenuItem"
        Me.PegarSelecciónToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.PegarSelecciónToolStripMenuItem.Text = "Pegar Selección"
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmCoquetaTrack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 479)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCoquetaTrack"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Track Coqueta"
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminarFilaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents NuevoEstiloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarSelecciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PegarSelecciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstiloFabrica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstiloNuestro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents C As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents De As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents A As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Track As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Btn_Invertir As System.Windows.Forms.Button
    Friend WithEvents Btn_Foto As System.Windows.Forms.Button
    Friend WithEvents Bot_Layout As System.Windows.Forms.Button
End Class
