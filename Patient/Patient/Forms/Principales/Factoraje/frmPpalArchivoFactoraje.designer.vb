<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalArchivoFactoraje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalArchivoFactoraje))
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
        Me.Btn_Layout = New System.Windows.Forms.Button()
        Me.Btn_Factura = New System.Windows.Forms.Button()
        Me.Btn_InvertirSeleccion = New System.Windows.Forms.Button()
        Me.Btn_Consultar = New System.Windows.Forms.Button()
        Me.Btn_Filtro = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout
        CType(Me.DGrid,System.ComponentModel.ISupportInitialize).BeginInit
        Me.CMenu.SuspendLayout
        Me.Pnl_Botones.SuspendLayout
        Me.SuspendLayout
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
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
        Me.NuevoPDToolStripMenuItem.Visible = false
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
        Me.StandByToolStripMenuItem.Image = CType(resources.GetObject("StandByToolStripMenuItem.Image"),System.Drawing.Image)
        Me.StandByToolStripMenuItem.Name = "StandByToolStripMenuItem"
        Me.StandByToolStripMenuItem.Size = New System.Drawing.Size(257, 22)
        Me.StandByToolStripMenuItem.Text = "Poner en Stand by"
        '
        'RecibidoToolStripMenuItem1
        '
        Me.RecibidoToolStripMenuItem1.Image = CType(resources.GetObject("RecibidoToolStripMenuItem1.Image"),System.Drawing.Image)
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
        Me.VerPagoFichaToolStripMenuItem1.Image = CType(resources.GetObject("VerPagoFichaToolStripMenuItem1.Image"),System.Drawing.Image)
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_Layout)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Factura)
        Me.Pnl_Botones.Controls.Add(Me.Btn_InvertirSeleccion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
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
        'Btn_Layout
        '
        Me.Btn_Layout.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Layout.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Layout.Image = Global.SIRCO.My.Resources.Resources.LAYOUTBANCO
        Me.Btn_Layout.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Layout.Location = New System.Drawing.Point(153, 0)
        Me.Btn_Layout.Name = "Btn_Layout"
        Me.Btn_Layout.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Layout.TabIndex = 17
        Me.Btn_Layout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Layout.UseVisualStyleBackColor = true
        '
        'Btn_Factura
        '
        Me.Btn_Factura.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Factura.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Factura.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.Btn_Factura.Location = New System.Drawing.Point(102, 0)
        Me.Btn_Factura.Name = "Btn_Factura"
        Me.Btn_Factura.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Factura.TabIndex = 11
        Me.Btn_Factura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Factura.UseVisualStyleBackColor = true
        '
        'Btn_InvertirSeleccion
        '
        Me.Btn_InvertirSeleccion.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_InvertirSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_InvertirSeleccion.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.Btn_InvertirSeleccion.Location = New System.Drawing.Point(51, 0)
        Me.Btn_InvertirSeleccion.Name = "Btn_InvertirSeleccion"
        Me.Btn_InvertirSeleccion.Size = New System.Drawing.Size(51, 52)
        Me.Btn_InvertirSeleccion.TabIndex = 10
        Me.Btn_InvertirSeleccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_InvertirSeleccion.UseVisualStyleBackColor = true
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Consultar.TabIndex = 3
        Me.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Consultar.UseVisualStyleBackColor = true
        Me.Btn_Consultar.Visible = false
        '
        'Btn_Filtro
        '
        Me.Btn_Filtro.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Filtro.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtro.Location = New System.Drawing.Point(622, 0)
        Me.Btn_Filtro.Name = "Btn_Filtro"
        Me.Btn_Filtro.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtro.TabIndex = 4
        Me.Btn_Filtro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtro.UseVisualStyleBackColor = true
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Enabled = false
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(673, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 6
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = true
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(724, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 5
        Me.Btn_Excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Excel.UseVisualStyleBackColor = true
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(775, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 7
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = true
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = true
        '
        'frmPpalArchivoFactoraje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmPpalArchivoFactoraje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Archivo Factoraje"
        Me.Pnl_Grid.ResumeLayout(false)
        CType(Me.DGrid,System.ComponentModel.ISupportInitialize).EndInit
        Me.CMenu.ResumeLayout(false)
        Me.Pnl_Botones.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Filtro As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Consultar As System.Windows.Forms.Button
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarPDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_InvertirSeleccion As System.Windows.Forms.Button
    Friend WithEvents Btn_Factura As System.Windows.Forms.Button
    Friend WithEvents ConsultarBultoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StandByToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecibidoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaMotivoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerPagoFichaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarLiquidaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ConsultarDevoluciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarNotaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Layout As System.Windows.Forms.Button
End Class
