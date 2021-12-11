<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalDistribLimites
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalDistribLimites))
        Me.Pnl_Grid = New System.Windows.Forms.Panel()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Pnl_Bar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LBL_PORC = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pbar1 = New System.Windows.Forms.ProgressBar()
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLimCred = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDisponible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAumento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNuevoLimite = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNvoLimiteMod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTel1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTelef2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRFC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemAnaModelo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_InvertirSeleccion = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Bar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.Pnl_Grid.Size = New System.Drawing.Size(1028, 460)
        Me.Pnl_Grid.TabIndex = 4
        '
        'PBox
        '
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(744, 58)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(270, 244)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 12
        Me.PBox.TabStop = False
        Me.PBox.Visible = False
        '
        'Pnl_Bar
        '
        Me.Pnl_Bar.Controls.Add(Me.PictureBox1)
        Me.Pnl_Bar.Controls.Add(Me.LBL_PORC)
        Me.Pnl_Bar.Controls.Add(Me.Label1)
        Me.Pnl_Bar.Controls.Add(Me.Pbar1)
        Me.Pnl_Bar.Location = New System.Drawing.Point(32, 82)
        Me.Pnl_Bar.Name = "Pnl_Bar"
        Me.Pnl_Bar.Size = New System.Drawing.Size(473, 98)
        Me.Pnl_Bar.TabIndex = 11
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
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(1024, 456)
        Me.DGrid.TabIndex = 0
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDistrib, Me.colNombre, Me.colFecha, Me.colLimCred, Me.colDisponible, Me.colVenta, Me.colAumento, Me.colNuevoLimite, Me.colNvoLimiteMod, Me.colTel1, Me.colTelef2, Me.colRFC})
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        '
        'colDistrib
        '
        Me.colDistrib.Caption = "GridColumn1"
        Me.colDistrib.FieldName = "distrib"
        Me.colDistrib.Name = "colDistrib"
        Me.colDistrib.Visible = True
        Me.colDistrib.VisibleIndex = 1
        '
        'colNombre
        '
        Me.colNombre.Caption = "GridColumn2"
        Me.colNombre.FieldName = "nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Visible = True
        Me.colNombre.VisibleIndex = 2
        '
        'colFecha
        '
        Me.colFecha.Caption = "GridColumn3"
        Me.colFecha.FieldName = "fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.Visible = True
        Me.colFecha.VisibleIndex = 3
        '
        'colLimCred
        '
        Me.colLimCred.Caption = "GridColumn4"
        Me.colLimCred.DisplayFormat.FormatString = "###,###,###"
        Me.colLimCred.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colLimCred.FieldName = "limcred"
        Me.colLimCred.Name = "colLimCred"
        Me.colLimCred.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "limcred", "{0:$###,###,##0}")})
        Me.colLimCred.Visible = True
        Me.colLimCred.VisibleIndex = 4
        '
        'colDisponible
        '
        Me.colDisponible.Caption = "GridColumn5"
        Me.colDisponible.DisplayFormat.FormatString = "###,###,###"
        Me.colDisponible.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colDisponible.FieldName = "disponible"
        Me.colDisponible.Name = "colDisponible"
        Me.colDisponible.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "disponible", "{0:$###,###,##0}")})
        Me.colDisponible.Visible = True
        Me.colDisponible.VisibleIndex = 5
        '
        'colVenta
        '
        Me.colVenta.Caption = "GridColumn6"
        Me.colVenta.DisplayFormat.FormatString = "###,###,###"
        Me.colVenta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colVenta.FieldName = "venta"
        Me.colVenta.Name = "colVenta"
        Me.colVenta.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "venta", "{0:$###,###,##0}")})
        Me.colVenta.Visible = True
        Me.colVenta.VisibleIndex = 6
        '
        'colAumento
        '
        Me.colAumento.Caption = "GridColumn7"
        Me.colAumento.DisplayFormat.FormatString = "###,###,###"
        Me.colAumento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAumento.FieldName = "aumento"
        Me.colAumento.Name = "colAumento"
        Me.colAumento.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "aumento", "{0:$###,###,##0}")})
        Me.colAumento.Visible = True
        Me.colAumento.VisibleIndex = 7
        '
        'colNuevoLimite
        '
        Me.colNuevoLimite.Caption = "GridColumn8"
        Me.colNuevoLimite.DisplayFormat.FormatString = "###,###,###"
        Me.colNuevoLimite.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colNuevoLimite.FieldName = "nuevolimite"
        Me.colNuevoLimite.Name = "colNuevoLimite"
        Me.colNuevoLimite.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nuevolimite", "{0:$###,###,##0}")})
        Me.colNuevoLimite.Visible = True
        Me.colNuevoLimite.VisibleIndex = 8
        '
        'colNvoLimiteMod
        '
        Me.colNvoLimiteMod.Caption = "GridColumn9"
        Me.colNvoLimiteMod.DisplayFormat.FormatString = "###,###,###"
        Me.colNvoLimiteMod.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colNvoLimiteMod.FieldName = "nuevolimitemodif"
        Me.colNvoLimiteMod.Name = "colNvoLimiteMod"
        Me.colNvoLimiteMod.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "nuevolimitemod", "{0:$###,###,##0}")})
        Me.colNvoLimiteMod.Visible = True
        Me.colNvoLimiteMod.VisibleIndex = 9
        '
        'colTel1
        '
        Me.colTel1.Caption = "GridColumn10"
        Me.colTel1.FieldName = "telef1"
        Me.colTel1.Name = "colTel1"
        Me.colTel1.Visible = True
        Me.colTel1.VisibleIndex = 10
        '
        'colTelef2
        '
        Me.colTelef2.Caption = "GridColumn1"
        Me.colTelef2.FieldName = "telef2"
        Me.colTelef2.Name = "colTelef2"
        Me.colTelef2.Visible = True
        Me.colTelef2.VisibleIndex = 11
        '
        'colRFC
        '
        Me.colRFC.Caption = "GridColumn2"
        Me.colRFC.FieldName = "rfc"
        Me.colRFC.Name = "colRFC"
        Me.colRFC.Visible = True
        Me.colRFC.VisibleIndex = 12
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAnaModelo, Me.ToolStripSeparator1})
        Me.ContextMenuStrip1.Name = "CMenu1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 32)
        '
        'ToolStripMenuItemAnaModelo
        '
        Me.ToolStripMenuItemAnaModelo.Image = Global.SIRCO.My.Resources.Resources.monitoreo
        Me.ToolStripMenuItemAnaModelo.MergeIndex = 10
        Me.ToolStripMenuItemAnaModelo.Name = "ToolStripMenuItemAnaModelo"
        Me.ToolStripMenuItemAnaModelo.Size = New System.Drawing.Size(179, 22)
        Me.ToolStripMenuItemAnaModelo.Text = "Análisis de Modelos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_InvertirSeleccion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 460)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(1028, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(820, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 250
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_Aceptar, "Confirmar Liquidación")
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_InvertirSeleccion
        '
        Me.Btn_InvertirSeleccion.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_InvertirSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_InvertirSeleccion.Image = Global.SIRCO.My.Resources.Resources.invertir
        Me.Btn_InvertirSeleccion.Location = New System.Drawing.Point(871, 0)
        Me.Btn_InvertirSeleccion.Name = "Btn_InvertirSeleccion"
        Me.Btn_InvertirSeleccion.Size = New System.Drawing.Size(51, 52)
        Me.Btn_InvertirSeleccion.TabIndex = 39
        Me.Btn_InvertirSeleccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip.SetToolTip(Me.Btn_InvertirSeleccion, "Invertir Selección")
        Me.Btn_InvertirSeleccion.UseVisualStyleBackColor = True
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(922, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(973, 0)
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
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalDistribLimites
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 516)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalDistribLimites"
        Me.Text = "Límites Distribuidores"
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Bar.ResumeLayout(False)
        Me.Pnl_Bar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Excel As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Btn_InvertirSeleccion As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemAnaModelo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PBox As PictureBox
    Friend WithEvents Pnl_Bar As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LBL_PORC As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Pbar1 As ProgressBar
    Friend WithEvents colDistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLimCred As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDisponible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAumento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNuevoLimite As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNvoLimiteMod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTel1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTelef2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRFC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
