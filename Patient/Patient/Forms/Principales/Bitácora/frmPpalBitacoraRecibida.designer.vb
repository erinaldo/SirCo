<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalBitacoraRecibida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalBitacoraRecibida))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RegistrarSegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerSeguimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaOrdenDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarFechasOrdendeCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_OrdeComp = New System.Windows.Forms.Button()
        Me.PBar = New System.Windows.Forms.ProgressBar()
        Me.Btn_Foto = New System.Windows.Forms.Button()
        Me.Btn_Marca = New System.Windows.Forms.Button()
        Me.Btn_Estilos = New System.Windows.Forms.Button()
        Me.Btn_Proveedor = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenu.SuspendLayout()
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
        Me.DGrid.ContextMenuStrip = Me.CMenu
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.ReadOnly = True
        Me.DGrid.Size = New System.Drawing.Size(826, 456)
        Me.DGrid.TabIndex = 0
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarSegToolStripMenuItem, Me.VerSeguimientoToolStripMenuItem, Me.ConsultaOrdenDeCompraToolStripMenuItem, Me.ModificarFechasOrdendeCompra, Me.ImagenToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(279, 136)
        '
        'RegistrarSegToolStripMenuItem
        '
        Me.RegistrarSegToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.LOG
        Me.RegistrarSegToolStripMenuItem.Name = "RegistrarSegToolStripMenuItem"
        Me.RegistrarSegToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.RegistrarSegToolStripMenuItem.Text = "Registrar Seguimiento"
        '
        'VerSeguimientoToolStripMenuItem
        '
        Me.VerSeguimientoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.monitoreo
        Me.VerSeguimientoToolStripMenuItem.Name = "VerSeguimientoToolStripMenuItem"
        Me.VerSeguimientoToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.VerSeguimientoToolStripMenuItem.Text = "Reporte Seguimiento"
        '
        'ConsultaOrdenDeCompraToolStripMenuItem
        '
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.ORDEN_DE_COMPRA
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Name = "ConsultaOrdenDeCompraToolStripMenuItem"
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.ConsultaOrdenDeCompraToolStripMenuItem.Text = "Consulta Orden de Compra"
        '
        'ModificarFechasOrdendeCompra
        '
        Me.ModificarFechasOrdendeCompra.Image = Global.SIRCO.My.Resources.Resources.fechas
        Me.ModificarFechasOrdendeCompra.Name = "ModificarFechasOrdendeCompra"
        Me.ModificarFechasOrdendeCompra.Size = New System.Drawing.Size(278, 22)
        Me.ModificarFechasOrdendeCompra.Text = "Modificar Fechas de Orden de Compra"
        '
        'ImagenToolStripMenuItem
        '
        Me.ImagenToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.ImagenToolStripMenuItem.Name = "ImagenToolStripMenuItem"
        Me.ImagenToolStripMenuItem.Size = New System.Drawing.Size(278, 22)
        Me.ImagenToolStripMenuItem.Text = "Imagen"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_OrdeComp)
        Me.Pnl_Botones.Controls.Add(Me.PBar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Foto)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Marca)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Estilos)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Proveedor)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_OrdeComp
        '
        Me.Btn_OrdeComp.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_OrdeComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_OrdeComp.Image = Global.SIRCO.My.Resources.Resources.orden_de_compra1
        Me.Btn_OrdeComp.Location = New System.Drawing.Point(153, 0)
        Me.Btn_OrdeComp.Name = "Btn_OrdeComp"
        Me.Btn_OrdeComp.Size = New System.Drawing.Size(51, 52)
        Me.Btn_OrdeComp.TabIndex = 12
        Me.Btn_OrdeComp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_OrdeComp.UseVisualStyleBackColor = True
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(372, 19)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(111, 14)
        Me.PBar.TabIndex = 14
        Me.PBar.Visible = False
        '
        'Btn_Foto
        '
        Me.Btn_Foto.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Foto.Enabled = False
        Me.Btn_Foto.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Foto.Image = Global.SIRCO.My.Resources.Resources.camara
        Me.Btn_Foto.Location = New System.Drawing.Point(571, 0)
        Me.Btn_Foto.Name = "Btn_Foto"
        Me.Btn_Foto.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Foto.TabIndex = 13
        Me.Btn_Foto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Foto.UseVisualStyleBackColor = True
        '
        'Btn_Marca
        '
        Me.Btn_Marca.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Marca.Image = Global.SIRCO.My.Resources.Resources.document_mark_as_final
        Me.Btn_Marca.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Marca.Name = "Btn_Marca"
        Me.Btn_Marca.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Marca.TabIndex = 10
        Me.Btn_Marca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Marca.UseVisualStyleBackColor = True
        '
        'Btn_Estilos
        '
        Me.Btn_Estilos.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Estilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Estilos.Image = Global.SIRCO.My.Resources.Resources.page_add
        Me.Btn_Estilos.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Estilos.Name = "Btn_Estilos"
        Me.Btn_Estilos.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Estilos.TabIndex = 9
        Me.Btn_Estilos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Estilos.UseVisualStyleBackColor = True
        '
        'Btn_Proveedor
        '
        Me.Btn_Proveedor.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Proveedor.Image = Global.SIRCO.My.Resources.Resources.proveedor
        Me.Btn_Proveedor.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Proveedor.Name = "Btn_Proveedor"
        Me.Btn_Proveedor.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Proveedor.TabIndex = 8
        Me.Btn_Proveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Proveedor.UseVisualStyleBackColor = True
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(622, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 4
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
        Me.Btn_Imprimir.TabIndex = 6
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
        Me.Btn_Excel.TabIndex = 5
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
        Me.Btn_Salir.TabIndex = 7
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmPpalBitacoraRecibida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalBitacoraRecibida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bitácora Mercancía Recibida"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Proveedor As System.Windows.Forms.Button
    Friend WithEvents Btn_Estilos As System.Windows.Forms.Button
    Friend WithEvents Btn_Marca As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RegistrarSegToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerSeguimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Foto As System.Windows.Forms.Button
    Friend WithEvents ImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaOrdenDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Btn_OrdeComp As System.Windows.Forms.Button
    Friend WithEvents ModificarFechasOrdendeCompra As System.Windows.Forms.ToolStripMenuItem
End Class
