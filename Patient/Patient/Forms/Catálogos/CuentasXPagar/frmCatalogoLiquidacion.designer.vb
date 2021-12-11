<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoLiquidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoLiquidacion))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.DGrid = New System.Windows.Forms.DataGridView()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Lbl_Factura = New System.Windows.Forms.Label()
        Me.Txt_Factura = New System.Windows.Forms.TextBox()
        Me.Lbl_IdLiquidacion = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.DetalleLiquidacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarLiquidacionBultoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarLiquidaciónPagadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarDetalladoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirChequeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirAnexoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirLiquidacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasCCProvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotasCCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarChequeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FichadeDepositoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarBultoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerFichaDepositoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarDetalladoProvToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Btn_BanRegio = New System.Windows.Forms.Button()
        Me.Btn_Publicar = New System.Windows.Forms.Button()
        Me.Btn_Layout = New System.Windows.Forms.Button()
        Me.Btn_Pagados = New System.Windows.Forms.Button()
        Me.Btn_Filtros = New System.Windows.Forms.Button()
        Me.Btn_Aplicar = New System.Windows.Forms.Button()
        Me.Btn_Revisado = New System.Windows.Forms.Button()
        Me.Btn_Regresar = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
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
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetalleLiquidacionToolStripMenuItem, Me.CancelarLiquidacionBultoToolStripMenuItem, Me.CancelarLiquidaciónPagadaToolStripMenuItem, Me.MostrarDetalladoToolStripMenuItem, Me.ImprimirChequeToolStripMenuItem, Me.ImprimirAnexoToolStripMenuItem, Me.ImprimirLiquidacionToolStripMenuItem, Me.NotasCCProvToolStripMenuItem, Me.NotasCCToolStripMenuItem, Me.CancelarChequeToolStripMenuItem, Me.FichadeDepositoToolStripMenuItem, Me.ConsultarBultoToolStripMenuItem, Me.DetalleFacturaToolStripMenuItem, Me.VerFichaDepositoToolStripMenuItem, Me.MostrarDetalladoProvToolStripMenuItem})
        Me.CMenu.Name = "CMenu"
        Me.CMenu.Size = New System.Drawing.Size(318, 334)
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_BanRegio)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Publicar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Layout)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Factura)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Factura)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_IdLiquidacion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Pagados)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Filtros)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aplicar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Revisado)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Regresar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(830, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Lbl_Factura
        '
        Me.Lbl_Factura.AutoSize = True
        Me.Lbl_Factura.Location = New System.Drawing.Point(106, 27)
        Me.Lbl_Factura.Name = "Lbl_Factura"
        Me.Lbl_Factura.Size = New System.Drawing.Size(79, 13)
        Me.Lbl_Factura.TabIndex = 14
        Me.Lbl_Factura.Text = "Buscar Factura"
        '
        'Txt_Factura
        '
        Me.Txt_Factura.Location = New System.Drawing.Point(217, 24)
        Me.Txt_Factura.Name = "Txt_Factura"
        Me.Txt_Factura.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Factura.TabIndex = 13
        '
        'Lbl_IdLiquidacion
        '
        Me.Lbl_IdLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_IdLiquidacion.AutoSize = True
        Me.Lbl_IdLiquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_IdLiquidacion.Location = New System.Drawing.Point(108, 0)
        Me.Lbl_IdLiquidacion.Name = "Lbl_IdLiquidacion"
        Me.Lbl_IdLiquidacion.Size = New System.Drawing.Size(105, 20)
        Me.Lbl_IdLiquidacion.TabIndex = 12
        Me.Lbl_IdLiquidacion.Text = "Liquidación:"
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'DetalleLiquidacionToolStripMenuItem
        '
        Me.DetalleLiquidacionToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.DetalleLiquidacionToolStripMenuItem.Name = "DetalleLiquidacionToolStripMenuItem"
        Me.DetalleLiquidacionToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.DetalleLiquidacionToolStripMenuItem.Text = "Detalle de Liquidación"
        '
        'CancelarLiquidacionBultoToolStripMenuItem
        '
        Me.CancelarLiquidacionBultoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.CancelarLiquidacionBultoToolStripMenuItem.Name = "CancelarLiquidacionBultoToolStripMenuItem"
        Me.CancelarLiquidacionBultoToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.CancelarLiquidacionBultoToolStripMenuItem.Text = "Cancelar Liquidación"
        '
        'CancelarLiquidaciónPagadaToolStripMenuItem
        '
        Me.CancelarLiquidaciónPagadaToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources._1328834184_cancel
        Me.CancelarLiquidaciónPagadaToolStripMenuItem.Name = "CancelarLiquidaciónPagadaToolStripMenuItem"
        Me.CancelarLiquidaciónPagadaToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.CancelarLiquidaciónPagadaToolStripMenuItem.Text = "Cancelar Liquidación Pagada"
        '
        'MostrarDetalladoToolStripMenuItem
        '
        Me.MostrarDetalladoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.devolucion
        Me.MostrarDetalladoToolStripMenuItem.Name = "MostrarDetalladoToolStripMenuItem"
        Me.MostrarDetalladoToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.MostrarDetalladoToolStripMenuItem.Text = "Mostrar Detallado"
        '
        'ImprimirChequeToolStripMenuItem
        '
        Me.ImprimirChequeToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.identificación1
        Me.ImprimirChequeToolStripMenuItem.Name = "ImprimirChequeToolStripMenuItem"
        Me.ImprimirChequeToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.ImprimirChequeToolStripMenuItem.Text = "Imprimir Cheque"
        '
        'ImprimirAnexoToolStripMenuItem
        '
        Me.ImprimirAnexoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.report_check
        Me.ImprimirAnexoToolStripMenuItem.Name = "ImprimirAnexoToolStripMenuItem"
        Me.ImprimirAnexoToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.ImprimirAnexoToolStripMenuItem.Text = "Imprimir reporte de liquidación por proveedor"
        '
        'ImprimirLiquidacionToolStripMenuItem
        '
        Me.ImprimirLiquidacionToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Paper_pencil
        Me.ImprimirLiquidacionToolStripMenuItem.Name = "ImprimirLiquidacionToolStripMenuItem"
        Me.ImprimirLiquidacionToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.ImprimirLiquidacionToolStripMenuItem.Text = "Imprimir liquidación pagada"
        '
        'NotasCCProvToolStripMenuItem
        '
        Me.NotasCCProvToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.proveedor
        Me.NotasCCProvToolStripMenuItem.Name = "NotasCCProvToolStripMenuItem"
        Me.NotasCCProvToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.NotasCCProvToolStripMenuItem.Text = "Reporte Notas Cargo/Credito Proveedor"
        '
        'NotasCCToolStripMenuItem
        '
        Me.NotasCCToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.percdeduc
        Me.NotasCCToolStripMenuItem.Name = "NotasCCToolStripMenuItem"
        Me.NotasCCToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.NotasCCToolStripMenuItem.Text = "Reporte Notas Cargo/Credito"
        '
        'CancelarChequeToolStripMenuItem
        '
        Me.CancelarChequeToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.CancelarChequeToolStripMenuItem.Name = "CancelarChequeToolStripMenuItem"
        Me.CancelarChequeToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.CancelarChequeToolStripMenuItem.Text = "Cancelar y reemplazar cheque"
        '
        'FichadeDepositoToolStripMenuItem
        '
        Me.FichadeDepositoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.transfer_document
        Me.FichadeDepositoToolStripMenuItem.Name = "FichadeDepositoToolStripMenuItem"
        Me.FichadeDepositoToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.FichadeDepositoToolStripMenuItem.Text = "Guardar ficha de depósito"
        '
        'ConsultarBultoToolStripMenuItem
        '
        Me.ConsultarBultoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.package
        Me.ConsultarBultoToolStripMenuItem.Name = "ConsultarBultoToolStripMenuItem"
        Me.ConsultarBultoToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.ConsultarBultoToolStripMenuItem.Text = "Consultar Bulto"
        '
        'DetalleFacturaToolStripMenuItem
        '
        Me.DetalleFacturaToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.factura
        Me.DetalleFacturaToolStripMenuItem.Name = "DetalleFacturaToolStripMenuItem"
        Me.DetalleFacturaToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.DetalleFacturaToolStripMenuItem.Text = "Detalle Factura"
        '
        'VerFichaDepositoToolStripMenuItem
        '
        Me.VerFichaDepositoToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.identificación
        Me.VerFichaDepositoToolStripMenuItem.Name = "VerFichaDepositoToolStripMenuItem"
        Me.VerFichaDepositoToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.VerFichaDepositoToolStripMenuItem.Text = "Ver Ficha de Depósito"
        '
        'MostrarDetalladoProvToolStripMenuItem
        '
        Me.MostrarDetalladoProvToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.person
        Me.MostrarDetalladoProvToolStripMenuItem.Name = "MostrarDetalladoProvToolStripMenuItem"
        Me.MostrarDetalladoProvToolStripMenuItem.Size = New System.Drawing.Size(317, 22)
        Me.MostrarDetalladoProvToolStripMenuItem.Text = "Detallado Por Proveedor"
        '
        'Btn_BanRegio
        '
        Me.Btn_BanRegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_BanRegio.Image = Global.SIRCO.My.Resources.Resources.WhatsApp_Image_2021_08_23_at_09_48_06
        Me.Btn_BanRegio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_BanRegio.Location = New System.Drawing.Point(463, 0)
        Me.Btn_BanRegio.Name = "Btn_BanRegio"
        Me.Btn_BanRegio.Size = New System.Drawing.Size(51, 52)
        Me.Btn_BanRegio.TabIndex = 19
        Me.Btn_BanRegio.Text = "Banregio"
        Me.Btn_BanRegio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_BanRegio, "Generar Archivo Factoraje a Publicar BANREGIO")
        Me.Btn_BanRegio.UseVisualStyleBackColor = True
        '
        'Btn_Publicar
        '
        Me.Btn_Publicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Publicar.Image = Global.SIRCO.My.Resources.Resources.WhatsApp_Image_2021_08_23_at_09_48_04
        Me.Btn_Publicar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Publicar.Location = New System.Drawing.Point(408, 0)
        Me.Btn_Publicar.Name = "Btn_Publicar"
        Me.Btn_Publicar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Publicar.TabIndex = 18
        Me.Btn_Publicar.Text = "BanBajio"
        Me.Btn_Publicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Publicar, "Generar Archivo Factoraje a Publicar BANBAJIO")
        Me.Btn_Publicar.UseVisualStyleBackColor = True
        '
        'Btn_Layout
        '
        Me.Btn_Layout.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Layout.Image = Global.SIRCO.My.Resources.Resources.LAYOUTBANCO
        Me.Btn_Layout.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Layout.Location = New System.Drawing.Point(351, 0)
        Me.Btn_Layout.Name = "Btn_Layout"
        Me.Btn_Layout.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Layout.TabIndex = 15
        Me.Btn_Layout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Layout.UseVisualStyleBackColor = True
        '
        'Btn_Pagados
        '
        Me.Btn_Pagados.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Pagados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Pagados.Image = Global.SIRCO.My.Resources.Resources.NOMINA11
        Me.Btn_Pagados.Location = New System.Drawing.Point(520, 0)
        Me.Btn_Pagados.Name = "Btn_Pagados"
        Me.Btn_Pagados.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Pagados.TabIndex = 11
        Me.Btn_Pagados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Pagados.UseVisualStyleBackColor = True
        '
        'Btn_Filtros
        '
        Me.Btn_Filtros.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Filtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filtros.Image = Global.SIRCO.My.Resources.Resources.magnifier_zoom_in
        Me.Btn_Filtros.Location = New System.Drawing.Point(571, 0)
        Me.Btn_Filtros.Name = "Btn_Filtros"
        Me.Btn_Filtros.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Filtros.TabIndex = 10
        Me.Btn_Filtros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Filtros.UseVisualStyleBackColor = True
        '
        'Btn_Aplicar
        '
        Me.Btn_Aplicar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Aplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aplicar.Image = Global.SIRCO.My.Resources.Resources.invoice
        Me.Btn_Aplicar.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Aplicar.Name = "Btn_Aplicar"
        Me.Btn_Aplicar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aplicar.TabIndex = 9
        Me.Btn_Aplicar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aplicar.UseVisualStyleBackColor = True
        '
        'Btn_Revisado
        '
        Me.Btn_Revisado.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Revisado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Revisado.Image = Global.SIRCO.My.Resources.Resources.devolucion1
        Me.Btn_Revisado.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Revisado.Name = "Btn_Revisado"
        Me.Btn_Revisado.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Revisado.TabIndex = 8
        Me.Btn_Revisado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Revisado.UseVisualStyleBackColor = True
        '
        'Btn_Regresar
        '
        Me.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Regresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Regresar.Image = CType(resources.GetObject("Btn_Regresar.Image"), System.Drawing.Image)
        Me.Btn_Regresar.Location = New System.Drawing.Point(622, 0)
        Me.Btn_Regresar.Name = "Btn_Regresar"
        Me.Btn_Regresar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Regresar.TabIndex = 4
        Me.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Regresar.UseVisualStyleBackColor = True
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
        'frmCatalogoLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCatalogoLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Liquidación"
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
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Regresar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DetalleLiquidacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarLiquidacionBultoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Revisado As System.Windows.Forms.Button
    Friend WithEvents Btn_Aplicar As System.Windows.Forms.Button
    Friend WithEvents MostrarDetalladoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirChequeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirAnexoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirLiquidacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarChequeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Filtros As System.Windows.Forms.Button
    Friend WithEvents Btn_Pagados As System.Windows.Forms.Button
    Friend WithEvents FichadeDepositoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Lbl_IdLiquidacion As System.Windows.Forms.Label
    Friend WithEvents Lbl_Factura As System.Windows.Forms.Label
    Friend WithEvents Txt_Factura As System.Windows.Forms.TextBox
    Friend WithEvents ConsultarBultoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetalleFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerFichaDepositoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Layout As System.Windows.Forms.Button
    Friend WithEvents NotasCCProvToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotasCCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MostrarDetalladoProvToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_Publicar As System.Windows.Forms.Button
    Friend WithEvents CancelarLiquidaciónPagadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_BanRegio As Button
End Class
