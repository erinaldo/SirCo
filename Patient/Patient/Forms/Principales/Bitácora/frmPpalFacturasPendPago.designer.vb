<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalFacturasPendPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalFacturasPendPago))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoPDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarPDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaMotivoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StandByToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecibidoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConsultarBultoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerPagoFichaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarLiquidaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarDevoluciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarNotaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Btn_Proveedor = New System.Windows.Forms.Button()
        Me.Btn_PagarRemision = New System.Windows.Forms.Button()
        Me.Chk_Observaciones = New System.Windows.Forms.CheckBox()
        Me.Btn_Factura = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Consultar = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Eliminar = New System.Windows.Forms.Button()
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
        Me.Pnl_Grid.Size = New System.Drawing.Size(1118, 460)
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
        Me.DGrid.Size = New System.Drawing.Size(1114, 456)
        Me.DGrid.TabIndex = 0
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoPDToolStripMenuItem, Me.EditarPDToolStripMenuItem, Me.ConsultaMotivoToolStripMenuItem1, Me.StandByToolStripMenuItem, Me.RecibidoToolStripMenuItem1, Me.ToolStripSeparator1, Me.ConsultarBultoToolStripMenuItem, Me.VerPagoFichaToolStripMenuItem1, Me.ConsultarLiquidaciónToolStripMenuItem, Me.ConsultarDevoluciónToolStripMenuItem, Me.ConsultarNotaToolStripMenuItem1})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(258, 252)
        '
        'NuevoPDToolStripMenuItem
        '
        Me.NuevoPDToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.cajita
        Me.NuevoPDToolStripMenuItem.Name = "NuevoPDToolStripMenuItem"
        Me.NuevoPDToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.NuevoPDToolStripMenuItem.Text = "Traspasar las Entradas a MicroSip"
        Me.NuevoPDToolStripMenuItem.Visible = False
        '
        'EditarPDToolStripMenuItem
        '
        Me.EditarPDToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.EditarPDToolStripMenuItem.Name = "EditarPDToolStripMenuItem"
        Me.EditarPDToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.EditarPDToolStripMenuItem.Text = "Detalle de Entrada"
        '
        'ConsultaMotivoToolStripMenuItem1
        '
        Me.ConsultaMotivoToolStripMenuItem1.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultaMotivoToolStripMenuItem1.Name = "ConsultaMotivoToolStripMenuItem1"
        Me.ConsultaMotivoToolStripMenuItem1.Size = New System.Drawing.Size(257, 22)
        Me.ConsultaMotivoToolStripMenuItem1.Text = "Consulta Motivo Stand By"
        '
        'StandByToolStripMenuItem
        '
        Me.StandByToolStripMenuItem.Image = CType(resources.GetObject("StandByToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StandByToolStripMenuItem.Name = "StandByToolStripMenuItem"
        Me.StandByToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.StandByToolStripMenuItem.Text = "Poner en Stand by"
        '
        'RecibidoToolStripMenuItem1
        '
        Me.RecibidoToolStripMenuItem1.Image = CType(resources.GetObject("RecibidoToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.RecibidoToolStripMenuItem1.Name = "RecibidoToolStripMenuItem1"
        Me.RecibidoToolStripMenuItem1.Size = New System.Drawing.Size(257, 22)
        Me.RecibidoToolStripMenuItem1.Text = "Recibido"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(254, 6)
        '
        'ConsultarBultoToolStripMenuItem
        '
        Me.ConsultarBultoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.package
        Me.ConsultarBultoToolStripMenuItem.Name = "ConsultarBultoToolStripMenuItem"
        Me.ConsultarBultoToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.ConsultarBultoToolStripMenuItem.Text = "Consultar Bulto"
        '
        'VerPagoFichaToolStripMenuItem1
        '
        Me.VerPagoFichaToolStripMenuItem1.Image = CType(resources.GetObject("VerPagoFichaToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.VerPagoFichaToolStripMenuItem1.Name = "VerPagoFichaToolStripMenuItem1"
        Me.VerPagoFichaToolStripMenuItem1.Size = New System.Drawing.Size(257, 22)
        Me.VerPagoFichaToolStripMenuItem1.Text = "Consultar Ficha de Pago"
        '
        'ConsultarLiquidaciónToolStripMenuItem
        '
        Me.ConsultarLiquidaciónToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.emblem_money
        Me.ConsultarLiquidaciónToolStripMenuItem.Name = "ConsultarLiquidaciónToolStripMenuItem"
        Me.ConsultarLiquidaciónToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.ConsultarLiquidaciónToolStripMenuItem.Text = "Consultar Liquidación"
        '
        'ConsultarDevoluciónToolStripMenuItem
        '
        Me.ConsultarDevoluciónToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.send_email_user_alternative
        Me.ConsultarDevoluciónToolStripMenuItem.Name = "ConsultarDevoluciónToolStripMenuItem"
        Me.ConsultarDevoluciónToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.ConsultarDevoluciónToolStripMenuItem.Text = "Consultar Devolución"
        '
        'ConsultarNotaToolStripMenuItem1
        '
        Me.ConsultarNotaToolStripMenuItem1.Image = Global.SIRCO.My.Resources.Resources.document
        Me.ConsultarNotaToolStripMenuItem1.Name = "ConsultarNotaToolStripMenuItem1"
        Me.ConsultarNotaToolStripMenuItem1.Size = New System.Drawing.Size(257, 22)
        Me.ConsultarNotaToolStripMenuItem1.Text = "Consultar Nota de Cargo ó Crédito"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Proveedor)
        Me.Pnl_Botones.Controls.Add(Me.Btn_PagarRemision)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Observaciones)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Factura)
        Me.Pnl_Botones.Controls.Add(Me.Label1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtro)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1118, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = Global.SIRCO.My.Resources.Resources.arrow_left
        Me.Btn_Regresar.Location = New System.Drawing.Point(859, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 26
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
        '
        'Btn_Proveedor
        '
        Me.Btn_Proveedor.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Proveedor.Image = Global.SIRCO.My.Resources.Resources.proveedor
        Me.Btn_Proveedor.Location = New System.Drawing.Point(204, 0)
        Me.Btn_Proveedor.Name = "Btn_Proveedor"
        Me.Btn_Proveedor.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Proveedor.TabIndex = 14
        Me.Btn_Proveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Proveedor.UseVisualStyleBackColor = True
        '
        'Btn_PagarRemision
        '
        Me.Btn_PagarRemision.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_PagarRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_PagarRemision.Image = Global.SIRCO.My.Resources.Resources.medical_invoice_information
        Me.Btn_PagarRemision.Location = New System.Drawing.Point(153, 0)
        Me.Btn_PagarRemision.Name = "Btn_PagarRemision"
        Me.Btn_PagarRemision.Size = New System.Drawing.Size(51, 52)
        Me.Btn_PagarRemision.TabIndex = 13
        Me.Btn_PagarRemision.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_PagarRemision.UseVisualStyleBackColor = True
        '
        'Chk_Observaciones
        '
        Me.Chk_Observaciones.AutoSize = True
        Me.Chk_Observaciones.Location = New System.Drawing.Point(456, 20)
        Me.Chk_Observaciones.Name = "Chk_Observaciones"
        Me.Chk_Observaciones.Size = New System.Drawing.Size(116, 17)
        Me.Chk_Observaciones.TabIndex = 12
        Me.Chk_Observaciones.Text = "Ver Observaciones"
        Me.Chk_Observaciones.UseVisualStyleBackColor = True
        '
        'Btn_Factura
        '
        Me.Btn_Factura.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Factura.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.Btn_Factura.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Factura.Name = "Btn_Factura"
        Me.Btn_Factura.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Factura.TabIndex = 11
        Me.Btn_Factura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Factura.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(362, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Consultar.TabIndex = 3
        Me.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Consultar.UseVisualStyleBackColor = True
        Me.Btn_Consultar.Visible = False
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(910, 0)
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
        Me.Btn_Imprimir.Location = New System.Drawing.Point(961, 0)
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
        Me.Btn_Excel.Location = New System.Drawing.Point(1012, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 5
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Eliminar.Enabled = False
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Eliminar.TabIndex = 2
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1063, 0)
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
        'frmPpalFacturasPendPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalFacturasPendPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturas Con Pendiente Pago"
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
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Consultar As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Factura As System.Windows.Forms.Button
    Friend WithEvents Chk_Observaciones As System.Windows.Forms.CheckBox
    Friend WithEvents ConsultarBultoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_PagarRemision As System.Windows.Forms.Button
    Friend WithEvents Btn_Proveedor As System.Windows.Forms.Button
    Friend WithEvents StandByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecibidoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaMotivoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerPagoFichaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Regresar As System.Windows.Forms.Button
    Friend WithEvents ConsultarLiquidaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConsultarDevoluciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarNotaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
