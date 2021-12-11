<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalPedidoNuevo
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
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoPDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarPDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarPDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarPDFOriginalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerarTracCoquetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Chk_Observaciones = New System.Windows.Forms.CheckBox()
        Me.Btn_EntregaMano = New System.Windows.Forms.Button()
        Me.Lbl_Auto = New System.Windows.Forms.Label()
        Me.PBar1 = New System.Windows.Forms.ProgressBar()
        Me.Btn_Correo = New System.Windows.Forms.Button()
        Me.Btn_Transferir = New System.Windows.Forms.Button()
        Me.Btn_Pdf = New System.Windows.Forms.Button()
        Me.Btn_InvertirSeleccion = New System.Windows.Forms.Button()
        Me.Btn_Consultar = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Editar = New System.Windows.Forms.Button()
        Me.Btn_Nuevo = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RegistrarSegToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerSeguimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.DGrid.Size = New System.Drawing.Size(826, 456)
        Me.DGrid.TabIndex = 0
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoPDToolStripMenuItem, Me.EditarPDToolStripMenuItem, Me.ConsultarPDToolStripMenuItem, Me.ConsultarPDFOriginalToolStripMenuItem, Me.GenerarTracCoquetaToolStripMenuItem, Me.ToolStripSeparator1, Me.RegistrarSegToolStripMenuItem, Me.VerSeguimientoToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(195, 186)
        '
        'NuevoPDToolStripMenuItem
        '
        Me.NuevoPDToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoPDToolStripMenuItem.Name = "NuevoPDToolStripMenuItem"
        Me.NuevoPDToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.NuevoPDToolStripMenuItem.Text = "Nuevo Pedido"
        '
        'EditarPDToolStripMenuItem
        '
        Me.EditarPDToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.EditarPDToolStripMenuItem.Name = "EditarPDToolStripMenuItem"
        Me.EditarPDToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.EditarPDToolStripMenuItem.Text = "Editar Pedido"
        '
        'ConsultarPDToolStripMenuItem
        '
        Me.ConsultarPDToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.ORDEN_DE_COMPRA
        Me.ConsultarPDToolStripMenuItem.Name = "ConsultarPDToolStripMenuItem"
        Me.ConsultarPDToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ConsultarPDToolStripMenuItem.Text = "Consultar Pedido"
        '
        'ConsultarPDFOriginalToolStripMenuItem
        '
        Me.ConsultarPDFOriginalToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.pdf
        Me.ConsultarPDFOriginalToolStripMenuItem.Name = "ConsultarPDFOriginalToolStripMenuItem"
        Me.ConsultarPDFOriginalToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ConsultarPDFOriginalToolStripMenuItem.Text = "Consultar PDF Original"
        '
        'GenerarTracCoquetaToolStripMenuItem
        '
        Me.GenerarTracCoquetaToolStripMenuItem.Name = "GenerarTracCoquetaToolStripMenuItem"
        Me.GenerarTracCoquetaToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.GenerarTracCoquetaToolStripMenuItem.Text = "Generar Trac Coqueta"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Chk_Observaciones)
        Me.Pnl_Botones.Controls.Add(Me.Btn_EntregaMano)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Auto)
        Me.Pnl_Botones.Controls.Add(Me.PBar1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Correo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Transferir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Pdf)
        Me.Pnl_Botones.Controls.Add(Me.Btn_InvertirSeleccion)
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
        'Chk_Observaciones
        '
        Me.Chk_Observaciones.AutoSize = True
        Me.Chk_Observaciones.Location = New System.Drawing.Point(363, 28)
        Me.Chk_Observaciones.Name = "Chk_Observaciones"
        Me.Chk_Observaciones.Size = New System.Drawing.Size(116, 17)
        Me.Chk_Observaciones.TabIndex = 11
        Me.Chk_Observaciones.Text = "Ver Observaciones"
        Me.Chk_Observaciones.UseVisualStyleBackColor = True
        '
        'Btn_EntregaMano
        '
        Me.Btn_EntregaMano.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_EntregaMano.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EntregaMano.Image = Global.SIRCO.My.Resources.Resources.handpaper
        Me.Btn_EntregaMano.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_EntregaMano.Location = New System.Drawing.Point(306, 0)
        Me.Btn_EntregaMano.Name = "Btn_EntregaMano"
        Me.Btn_EntregaMano.Size = New System.Drawing.Size(51, 52)
        Me.Btn_EntregaMano.TabIndex = 10
        Me.Btn_EntregaMano.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_EntregaMano, "Entrega En Mano")
        Me.Btn_EntregaMano.UseVisualStyleBackColor = True
        '
        'Lbl_Auto
        '
        Me.Lbl_Auto.AutoSize = True
        Me.Lbl_Auto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Auto.Location = New System.Drawing.Point(363, 29)
        Me.Lbl_Auto.Name = "Lbl_Auto"
        Me.Lbl_Auto.Size = New System.Drawing.Size(55, 16)
        Me.Lbl_Auto.TabIndex = 9
        Me.Lbl_Auto.Text = "Label1"
        Me.Lbl_Auto.Visible = False
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(363, 2)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(151, 24)
        Me.PBar1.TabIndex = 8
        Me.PBar1.Visible = False
        '
        'Btn_Correo
        '
        Me.Btn_Correo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Correo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Correo.Image = Global.SIRCO.My.Resources.Resources.EMAILARROBA
        Me.Btn_Correo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Correo.Location = New System.Drawing.Point(255, 0)
        Me.Btn_Correo.Name = "Btn_Correo"
        Me.Btn_Correo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Correo.TabIndex = 5
        Me.Btn_Correo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Correo.UseVisualStyleBackColor = True
        '
        'Btn_Transferir
        '
        Me.Btn_Transferir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Transferir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Transferir.Image = Global.SIRCO.My.Resources.Resources.TRANSFERIR
        Me.Btn_Transferir.Location = New System.Drawing.Point(520, 0)
        Me.Btn_Transferir.Name = "Btn_Transferir"
        Me.Btn_Transferir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Transferir.TabIndex = 6
        Me.Btn_Transferir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Transferir.UseVisualStyleBackColor = True
        Me.Btn_Transferir.Visible = False
        '
        'Btn_Pdf
        '
        Me.Btn_Pdf.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Pdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Pdf.Image = Global.SIRCO.My.Resources.Resources.pdf
        Me.Btn_Pdf.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Pdf.Location = New System.Drawing.Point(204, 0)
        Me.Btn_Pdf.Name = "Btn_Pdf"
        Me.Btn_Pdf.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Pdf.TabIndex = 4
        Me.Btn_Pdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Pdf.UseVisualStyleBackColor = True
        '
        'Btn_InvertirSeleccion
        '
        Me.Btn_InvertirSeleccion.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_InvertirSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_InvertirSeleccion.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.Btn_InvertirSeleccion.Location = New System.Drawing.Point(571, 0)
        Me.Btn_InvertirSeleccion.Name = "Btn_InvertirSeleccion"
        Me.Btn_InvertirSeleccion.Size = New System.Drawing.Size(51, 52)
        Me.Btn_InvertirSeleccion.TabIndex = 7
        Me.Btn_InvertirSeleccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_InvertirSeleccion.UseVisualStyleBackColor = True
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.Location = New System.Drawing.Point(153, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Consultar.TabIndex = 3
        Me.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Consultar.UseVisualStyleBackColor = True
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
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Eliminar.TabIndex = 2
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
        Me.Btn_Salir.TabIndex = 7
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        'RegistrarSegToolStripMenuItem
        '
        Me.RegistrarSegToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.LOG
        Me.RegistrarSegToolStripMenuItem.Name = "RegistrarSegToolStripMenuItem"
        Me.RegistrarSegToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.RegistrarSegToolStripMenuItem.Text = "Registrar Seguimiento"
        '
        'VerSeguimientoToolStripMenuItem
        '
        Me.VerSeguimientoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.monitoreo
        Me.VerSeguimientoToolStripMenuItem.Name = "VerSeguimientoToolStripMenuItem"
        Me.VerSeguimientoToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.VerSeguimientoToolStripMenuItem.Text = "Reporte Seguimiento"
        '
        'frmPpalPedidoNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmPpalPedidoNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pedido Nuevo"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenu.ResumeLayout(False)
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
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_InvertirSeleccion As System.Windows.Forms.Button
    Friend WithEvents Btn_Transferir As System.Windows.Forms.Button
    Friend WithEvents Btn_Pdf As System.Windows.Forms.Button
    Friend WithEvents Btn_Correo As System.Windows.Forms.Button
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Lbl_Auto As System.Windows.Forms.Label
    Friend WithEvents Btn_EntregaMano As System.Windows.Forms.Button
    Friend WithEvents ConsultarPDFOriginalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerarTracCoquetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Chk_Observaciones As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents RegistrarSegToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerSeguimientoToolStripMenuItem As ToolStripMenuItem
End Class
