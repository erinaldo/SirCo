<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalCallCenterAdmon
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalCallCenterAdmon))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalCallCenterAdmonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalCallCenterAdmon = New SIRCO.usp_PpalCallCenterAdmon()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Distrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.fecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfechapromesado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.corte1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcomentarios = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcredito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colseencontro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCampo5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UspPpalCallCenterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SirCoCreditoDataSet4 = New SIRCO.SirCoCreditoDataSet4()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Usp_PpalCallCenterTableAdapter = New SIRCO.SirCoCreditoDataSet4TableAdapters.usp_PpalCallCenterTableAdapter()
        Me.Usp_PpalCallCenterAdmonTableAdapter = New SIRCO.usp_PpalCallCenterAdmonTableAdapters.usp_PpalCallCenterAdmonTableAdapter()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalCallCenterAdmonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalCallCenterAdmon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalCallCenterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoCreditoDataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(696, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 11
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        Me.Btn_Imprimir.Visible = False
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(747, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(798, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalCallCenterAdmonBindingSource
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(853, 526)
        Me.DGrid1.TabIndex = 5
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalCallCenterAdmonBindingSource
        '
        Me.UspPpalCallCenterAdmonBindingSource.DataMember = "usp_PpalCallCenterAdmon"
        Me.UspPpalCallCenterAdmonBindingSource.DataSource = Me.Usp_PpalCallCenterAdmon
        '
        'Usp_PpalCallCenterAdmon
        '
        Me.Usp_PpalCallCenterAdmon.DataSetName = "usp_PpalCallCenterAdmon"
        Me.Usp_PpalCallCenterAdmon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Distrib, Me.Nombre, Me.status, Me.fecha, Me.colfechapromesado, Me.corte1, Me.colcomentarios, Me.colcredito, Me.colseencontro, Me.colCampo2, Me.colCampo3, Me.colCampo4, Me.colCampo5})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Distrib
        '
        Me.Distrib.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Distrib.AppearanceHeader.Options.UseFont = True
        Me.Distrib.AppearanceHeader.Options.UseTextOptions = True
        Me.Distrib.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Distrib.Caption = "Distrib"
        Me.Distrib.FieldName = "distrib"
        Me.Distrib.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Distrib.Name = "Distrib"
        Me.Distrib.OptionsColumn.ReadOnly = True
        Me.Distrib.Visible = True
        Me.Distrib.VisibleIndex = 0
        '
        'Nombre
        '
        Me.Nombre.AppearanceHeader.Options.UseTextOptions = True
        Me.Nombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "nombre"
        Me.Nombre.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.ReadOnly = True
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 1
        '
        'status
        '
        Me.status.AppearanceCell.Options.UseTextOptions = True
        Me.status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.status.Caption = "Est"
        Me.status.FieldName = "status"
        Me.status.Name = "status"
        Me.status.OptionsColumn.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.AppearanceHeader.Options.UseTextOptions = True
        Me.fecha.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.fecha.Caption = "Fecha"
        Me.fecha.FieldName = "fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.Visible = True
        Me.fecha.VisibleIndex = 2
        '
        'colfechapromesado
        '
        Me.colfechapromesado.AppearanceHeader.Options.UseTextOptions = True
        Me.colfechapromesado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colfechapromesado.Caption = "Promesado"
        Me.colfechapromesado.FieldName = "fechapromesado"
        Me.colfechapromesado.Name = "colfechapromesado"
        Me.colfechapromesado.Visible = True
        Me.colfechapromesado.VisibleIndex = 3
        '
        'corte1
        '
        Me.corte1.Caption = "Adeudo"
        Me.corte1.DisplayFormat.FormatString = "#,###,###"
        Me.corte1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.corte1.FieldName = "adeudo"
        Me.corte1.Name = "corte1"
        Me.corte1.OptionsColumn.ReadOnly = True
        Me.corte1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "corte1", "{0:$###,###,##0}", CType(0, Long))})
        '
        'colcomentarios
        '
        Me.colcomentarios.Caption = "Comentarios"
        Me.colcomentarios.FieldName = "comentarios"
        Me.colcomentarios.Name = "colcomentarios"
        Me.colcomentarios.Visible = True
        Me.colcomentarios.VisibleIndex = 4
        '
        'colcredito
        '
        Me.colcredito.AppearanceHeader.Options.UseTextOptions = True
        Me.colcredito.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colcredito.Caption = "Usuario Crédito"
        Me.colcredito.FieldName = "credito"
        Me.colcredito.Name = "colcredito"
        Me.colcredito.Visible = True
        Me.colcredito.VisibleIndex = 6
        '
        'colseencontro
        '
        Me.colseencontro.AppearanceCell.Options.UseTextOptions = True
        Me.colseencontro.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colseencontro.AppearanceHeader.Options.UseTextOptions = True
        Me.colseencontro.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colseencontro.Caption = "Localizado"
        Me.colseencontro.FieldName = "seencontro"
        Me.colseencontro.Name = "colseencontro"
        Me.colseencontro.Visible = True
        Me.colseencontro.VisibleIndex = 5
        '
        'colCampo2
        '
        Me.colCampo2.AppearanceCell.Options.UseTextOptions = True
        Me.colCampo2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCampo2.AppearanceHeader.Options.UseFont = True
        Me.colCampo2.AppearanceHeader.Options.UseTextOptions = True
        Me.colCampo2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colCampo2.Caption = "Ciudad"
        Me.colCampo2.FieldName = "Campo2"
        Me.colCampo2.Name = "colCampo2"
        Me.colCampo2.OptionsColumn.ReadOnly = True
        '
        'colCampo3
        '
        Me.colCampo3.Caption = "Colonia"
        Me.colCampo3.FieldName = "Campo3"
        Me.colCampo3.Name = "colCampo3"
        Me.colCampo3.OptionsColumn.ReadOnly = True
        '
        'colCampo4
        '
        Me.colCampo4.Caption = "Gestor Asignado"
        Me.colCampo4.FieldName = "Campo4"
        Me.colCampo4.Name = "colCampo4"
        Me.colCampo4.OptionsColumn.ReadOnly = True
        '
        'colCampo5
        '
        Me.colCampo5.FieldName = "Campo5"
        Me.colCampo5.Name = "colCampo5"
        Me.colCampo5.OptionsColumn.ReadOnly = True
        '
        'UspPpalCallCenterBindingSource
        '
        Me.UspPpalCallCenterBindingSource.DataMember = "usp_PpalCallCenter"
        Me.UspPpalCallCenterBindingSource.DataSource = Me.SirCoCreditoDataSet4
        '
        'SirCoCreditoDataSet4
        '
        Me.SirCoCreditoDataSet4.DataSetName = "SirCoCreditoDataSet4"
        Me.SirCoCreditoDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PdfViewer1
        '
        Me.PdfViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.Size = New System.Drawing.Size(150, 150)
        Me.PdfViewer1.TabIndex = 0
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'SaveFileDialog1
        '
        '
        'Usp_PpalCallCenterTableAdapter
        '
        Me.Usp_PpalCallCenterTableAdapter.ClearBeforeFill = True
        '
        'Usp_PpalCallCenterAdmonTableAdapter
        '
        Me.Usp_PpalCallCenterAdmonTableAdapter.ClearBeforeFill = True
        '
        'frmPpalCallCenterAdmon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalCallCenterAdmon"
        Me.Text = "Reporte de Call Center Admon"
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalCallCenterAdmonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalCallCenterAdmon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalCallCenterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoCreditoDataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Imprimir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Distrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents corte1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCampo5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SirCoCreditoDataSet4 As SirCoCreditoDataSet4
    Friend WithEvents UspPpalCallCenterBindingSource As BindingSource
    Friend WithEvents Usp_PpalCallCenterTableAdapter As SirCoCreditoDataSet4TableAdapters.usp_PpalCallCenterTableAdapter
    Friend WithEvents UspPpalCallCenterAdmonBindingSource As BindingSource
    Friend WithEvents Usp_PpalCallCenterAdmon As usp_PpalCallCenterAdmon
    Friend WithEvents Usp_PpalCallCenterAdmonTableAdapter As usp_PpalCallCenterAdmonTableAdapters.usp_PpalCallCenterAdmonTableAdapter
    Friend WithEvents fecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfechapromesado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcomentarios As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcredito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colseencontro As DevExpress.XtraGrid.Columns.GridColumn
End Class
