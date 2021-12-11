<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalCatalogoDistrib
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalCatalogoDistrib))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Editar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalDistribBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalDistrib = New SIRCO.usp_PpalDistrib()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.coliddistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltipodistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnombrecompleto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colestatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfecalta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UspPpalCallCenterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SirCoCreditoDataSet4 = New SIRCO.SirCoCreditoDataSet4()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Usp_PpalCallCenterTableAdapter = New SIRCO.SirCoCreditoDataSet4TableAdapters.usp_PpalCallCenterTableAdapter()
        Me.Usp_PpalDistribTableAdapter = New SIRCO.usp_PpalDistribTableAdapters.usp_PpalDistribTableAdapter()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalDistribBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalDistrib, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalCallCenterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoCreditoDataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Consultar.Location = New System.Drawing.Point(117, 0)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 50)
        Me.Btn_Consultar.TabIndex = 15
        Me.Btn_Consultar.ToolTip = "Registrar llamada Call Center"
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Editar.Location = New System.Drawing.Point(60, 0)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 50)
        Me.Btn_Editar.TabIndex = 14
        Me.Btn_Editar.ToolTip = "Registrar llamada Call Center"
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Nuevo.Location = New System.Drawing.Point(3, 0)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 50)
        Me.Btn_Nuevo.TabIndex = 13
        Me.Btn_Nuevo.ToolTip = "Registrar llamada Call Center"
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(696, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 12
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
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
        Me.DGrid1.DataSource = Me.UspPpalDistribBindingSource
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
        'UspPpalDistribBindingSource
        '
        Me.UspPpalDistribBindingSource.DataMember = "usp_PpalDistrib"
        Me.UspPpalDistribBindingSource.DataSource = Me.Usp_PpalDistrib
        '
        'Usp_PpalDistrib
        '
        Me.Usp_PpalDistrib.DataSetName = "usp_PpalDistrib"
        Me.Usp_PpalDistrib.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.coliddistrib, Me.coltipodistrib, Me.coldistrib, Me.colnombrecompleto, Me.colestatus, Me.colfecalta, Me.colcampo1, Me.colcampo2, Me.colcampo3, Me.colcampo4, Me.colcampo5})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'coliddistrib
        '
        Me.coliddistrib.Caption = "Id Distrib"
        Me.coliddistrib.FieldName = "iddistrib"
        Me.coliddistrib.Name = "coliddistrib"
        '
        'coltipodistrib
        '
        Me.coltipodistrib.Caption = "Clasificación"
        Me.coltipodistrib.FieldName = "tipodistrib"
        Me.coltipodistrib.Name = "coltipodistrib"
        Me.coltipodistrib.Visible = True
        Me.coltipodistrib.VisibleIndex = 0
        '
        'coldistrib
        '
        Me.coldistrib.Caption = "Distrib"
        Me.coldistrib.FieldName = "distrib"
        Me.coldistrib.Name = "coldistrib"
        Me.coldistrib.Visible = True
        Me.coldistrib.VisibleIndex = 1
        '
        'colnombrecompleto
        '
        Me.colnombrecompleto.Caption = "Nombre"
        Me.colnombrecompleto.FieldName = "nombrecompleto"
        Me.colnombrecompleto.Name = "colnombrecompleto"
        Me.colnombrecompleto.Visible = True
        Me.colnombrecompleto.VisibleIndex = 2
        '
        'colestatus
        '
        Me.colestatus.Caption = "Estatus"
        Me.colestatus.FieldName = "estatus"
        Me.colestatus.Name = "colestatus"
        Me.colestatus.Visible = True
        Me.colestatus.VisibleIndex = 3
        '
        'colfecalta
        '
        Me.colfecalta.Caption = "Alta"
        Me.colfecalta.FieldName = "fecalta"
        Me.colfecalta.Name = "colfecalta"
        Me.colfecalta.Visible = True
        Me.colfecalta.VisibleIndex = 4
        '
        'colcampo1
        '
        Me.colcampo1.FieldName = "campo1"
        Me.colcampo1.Name = "colcampo1"
        '
        'colcampo2
        '
        Me.colcampo2.FieldName = "campo2"
        Me.colcampo2.Name = "colcampo2"
        '
        'colcampo3
        '
        Me.colcampo3.FieldName = "campo3"
        Me.colcampo3.Name = "colcampo3"
        '
        'colcampo4
        '
        Me.colcampo4.FieldName = "campo4"
        Me.colcampo4.Name = "colcampo4"
        '
        'colcampo5
        '
        Me.colcampo5.FieldName = "campo5"
        Me.colcampo5.Name = "colcampo5"
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
        'Usp_PpalDistribTableAdapter
        '
        Me.Usp_PpalDistribTableAdapter.ClearBeforeFill = True
        '
        'frmPpalCatalogoDistrib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalCatalogoDistrib"
        Me.Text = "Reporte de Call Center"
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalDistribBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalDistrib, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalCallCenterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoCreditoDataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SirCoCreditoDataSet4 As SirCoCreditoDataSet4
    Friend WithEvents UspPpalCallCenterBindingSource As BindingSource
    Friend WithEvents Usp_PpalCallCenterTableAdapter As SirCoCreditoDataSet4TableAdapters.usp_PpalCallCenterTableAdapter
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Usp_PpalDistrib As usp_PpalDistrib
    Friend WithEvents UspPpalDistribBindingSource As BindingSource
    Friend WithEvents Usp_PpalDistribTableAdapter As usp_PpalDistribTableAdapters.usp_PpalDistribTableAdapter
    Friend WithEvents coliddistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltipodistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnombrecompleto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colestatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfecalta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Editar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Consultar As DevExpress.XtraEditors.SimpleButton
End Class
