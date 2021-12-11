<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalVencido
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_QuitarAsignacion = New System.Windows.Forms.Button()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Asignar = New System.Windows.Forms.Button()
        Me.Chk_Direccion = New DevExpress.XtraEditors.CheckEdit()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.UspPpalVencidoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalVencido = New SIRCO.usp_PpalVencido()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Usp_PpalGestoriaTableAdapter = New SIRCO.usp_PpalGestoriaTableAdapters.usp_PpalGestoriaTableAdapter()
        Me.Usp_PpalVencidoTableAdapter = New SIRCO.usp_PpalVencidoTableAdapters.usp_PpalVencidoTableAdapter()
        Me.Pnl_Principal = New DevExpress.XtraEditors.PanelControl()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gestor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Distrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.fecalta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.saldo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.capital = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.interes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cobranza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colultpago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colultfechapago = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.direccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ciudad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colonia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Telefono1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.aval = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcampo4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pnl_Detallado = New DevExpress.XtraEditors.PanelControl()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalVencidoxAnioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalVencidoxAnio = New SIRCO.usp_PpalVencidoxAnio()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colgestor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2019 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2018 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2017 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2016 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2015 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2014 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2013 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2012 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2011 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2010 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAnio2010_ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Usp_PpalVencidoxAnioTableAdapter = New SIRCO.usp_PpalVencidoxAnioTableAdapters.usp_PpalVencidoxAnioTableAdapter()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Chk_Direccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalVencidoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalVencido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Principal.SuspendLayout()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Detallado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Detallado.SuspendLayout()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalVencidoxAnioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalVencidoxAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_QuitarAsignacion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Asignar)
        Me.Pnl_Botones.Controls.Add(Me.Chk_Direccion)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 4
        '
        'Btn_QuitarAsignacion
        '
        Me.Btn_QuitarAsignacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_QuitarAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_QuitarAsignacion.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.Btn_QuitarAsignacion.Location = New System.Drawing.Point(543, 0)
        Me.Btn_QuitarAsignacion.Name = "Btn_QuitarAsignacion"
        Me.Btn_QuitarAsignacion.Size = New System.Drawing.Size(51, 52)
        Me.Btn_QuitarAsignacion.TabIndex = 16
        Me.Btn_QuitarAsignacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_QuitarAsignacion.UseVisualStyleBackColor = True
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(594, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 15
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        Me.Btn_Refrescar.Visible = False
        '
        'Btn_Asignar
        '
        Me.Btn_Asignar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Asignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Asignar.Image = Global.SIRCO.My.Resources.Resources.person
        Me.Btn_Asignar.Location = New System.Drawing.Point(645, 0)
        Me.Btn_Asignar.Name = "Btn_Asignar"
        Me.Btn_Asignar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Asignar.TabIndex = 14
        Me.Btn_Asignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Asignar.UseVisualStyleBackColor = True
        '
        'Chk_Direccion
        '
        Me.Chk_Direccion.EditValue = True
        Me.Chk_Direccion.Location = New System.Drawing.Point(29, 4)
        Me.Chk_Direccion.Name = "Chk_Direccion"
        Me.Chk_Direccion.Properties.Caption = "Ver Dirección"
        Me.Chk_Direccion.Size = New System.Drawing.Size(86, 19)
        Me.Chk_Direccion.TabIndex = 12
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
        'UspPpalVencidoBindingSource
        '
        Me.UspPpalVencidoBindingSource.DataMember = "usp_PpalVencido"
        Me.UspPpalVencidoBindingSource.DataSource = Me.Usp_PpalVencido
        '
        'Usp_PpalVencido
        '
        Me.Usp_PpalVencido.DataSetName = "usp_PpalVencido"
        Me.Usp_PpalVencido.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'Usp_PpalGestoriaTableAdapter
        '
        Me.Usp_PpalGestoriaTableAdapter.ClearBeforeFill = True
        '
        'Usp_PpalVencidoTableAdapter
        '
        Me.Usp_PpalVencidoTableAdapter.ClearBeforeFill = True
        '
        'Pnl_Principal
        '
        Me.Pnl_Principal.Controls.Add(Me.DGrid1)
        Me.Pnl_Principal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Principal.Location = New System.Drawing.Point(0, 167)
        Me.Pnl_Principal.Name = "Pnl_Principal"
        Me.Pnl_Principal.Size = New System.Drawing.Size(853, 359)
        Me.Pnl_Principal.TabIndex = 6
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalVencidoBindingSource
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.DGrid1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.DGrid1.Location = New System.Drawing.Point(2, 2)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(849, 355)
        Me.DGrid1.TabIndex = 6
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gestor, Me.Distrib, Me.Nombre, Me.status, Me.fecalta, Me.saldo, Me.capital, Me.interes, Me.cobranza, Me.colultpago, Me.colultfechapago, Me.direccion, Me.ciudad, Me.colonia, Me.Telefono1, Me.aval, Me.colcampo1, Me.colcampo2, Me.colcampo3, Me.colcampo4})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'gestor
        '
        Me.gestor.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gestor.AppearanceHeader.Options.UseFont = True
        Me.gestor.AppearanceHeader.Options.UseTextOptions = True
        Me.gestor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gestor.Caption = "Gestor Asignado"
        Me.gestor.FieldName = "gestor"
        Me.gestor.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gestor.Name = "gestor"
        Me.gestor.OptionsColumn.ReadOnly = True
        Me.gestor.Visible = True
        Me.gestor.VisibleIndex = 1
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
        Me.Distrib.VisibleIndex = 2
        '
        'Nombre
        '
        Me.Nombre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Nombre.AppearanceHeader.Options.UseFont = True
        Me.Nombre.AppearanceHeader.Options.UseTextOptions = True
        Me.Nombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Nombre.Caption = "Nombre"
        Me.Nombre.FieldName = "nombre"
        Me.Nombre.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Nombre.Name = "Nombre"
        Me.Nombre.OptionsColumn.ReadOnly = True
        Me.Nombre.Visible = True
        Me.Nombre.VisibleIndex = 3
        '
        'status
        '
        Me.status.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.status.AppearanceHeader.Options.UseFont = True
        Me.status.AppearanceHeader.Options.UseTextOptions = True
        Me.status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.status.Caption = "Est"
        Me.status.FieldName = "status"
        Me.status.Name = "status"
        Me.status.OptionsColumn.ReadOnly = True
        Me.status.Visible = True
        Me.status.VisibleIndex = 5
        '
        'fecalta
        '
        Me.fecalta.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fecalta.AppearanceHeader.Options.UseFont = True
        Me.fecalta.AppearanceHeader.Options.UseTextOptions = True
        Me.fecalta.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.fecalta.Caption = "Antigüedad"
        Me.fecalta.FieldName = "fecalta"
        Me.fecalta.Name = "fecalta"
        Me.fecalta.Visible = True
        Me.fecalta.VisibleIndex = 4
        '
        'saldo
        '
        Me.saldo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.saldo.AppearanceHeader.Options.UseFont = True
        Me.saldo.AppearanceHeader.Options.UseTextOptions = True
        Me.saldo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.saldo.Caption = "Saldo"
        Me.saldo.DisplayFormat.FormatString = "#,###,###"
        Me.saldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.saldo.FieldName = "saldo"
        Me.saldo.Name = "saldo"
        Me.saldo.OptionsColumn.ReadOnly = True
        Me.saldo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "saldo", "{0:$###,###,##0}", CType(0, Long))})
        Me.saldo.Visible = True
        Me.saldo.VisibleIndex = 6
        '
        'capital
        '
        Me.capital.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.capital.AppearanceHeader.Options.UseFont = True
        Me.capital.AppearanceHeader.Options.UseTextOptions = True
        Me.capital.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.capital.Caption = "Capital"
        Me.capital.DisplayFormat.FormatString = "#,###,###"
        Me.capital.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.capital.FieldName = "capital"
        Me.capital.Name = "capital"
        Me.capital.OptionsColumn.ReadOnly = True
        Me.capital.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "capital", "{0:$###,###,##0}", CType(0, Long))})
        Me.capital.Visible = True
        Me.capital.VisibleIndex = 7
        '
        'interes
        '
        Me.interes.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.interes.AppearanceHeader.Options.UseFont = True
        Me.interes.AppearanceHeader.Options.UseTextOptions = True
        Me.interes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.interes.Caption = "Interes"
        Me.interes.DisplayFormat.FormatString = "#,###,###"
        Me.interes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.interes.FieldName = "interes"
        Me.interes.Name = "interes"
        Me.interes.OptionsColumn.ReadOnly = True
        Me.interes.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "interes", "{0:$###,###,##0}", CType(0, Long))})
        Me.interes.Visible = True
        Me.interes.VisibleIndex = 8
        '
        'cobranza
        '
        Me.cobranza.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cobranza.AppearanceHeader.Options.UseFont = True
        Me.cobranza.AppearanceHeader.Options.UseTextOptions = True
        Me.cobranza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cobranza.Caption = "Gastos"
        Me.cobranza.DisplayFormat.FormatString = "#,###,###"
        Me.cobranza.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.cobranza.FieldName = "cobranza"
        Me.cobranza.Name = "cobranza"
        Me.cobranza.OptionsColumn.ReadOnly = True
        Me.cobranza.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cobranza", "{0:$###,###,##0}", "0")})
        Me.cobranza.Visible = True
        Me.cobranza.VisibleIndex = 9
        '
        'colultpago
        '
        Me.colultpago.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colultpago.AppearanceHeader.Options.UseFont = True
        Me.colultpago.AppearanceHeader.Options.UseTextOptions = True
        Me.colultpago.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colultpago.Caption = "Ult Pago"
        Me.colultpago.DisplayFormat.FormatString = "#,###,###"
        Me.colultpago.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colultpago.FieldName = "ultpago"
        Me.colultpago.Name = "colultpago"
        Me.colultpago.OptionsColumn.ReadOnly = True
        Me.colultpago.Visible = True
        Me.colultpago.VisibleIndex = 15
        '
        'colultfechapago
        '
        Me.colultfechapago.AppearanceCell.Options.UseTextOptions = True
        Me.colultfechapago.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colultfechapago.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colultfechapago.AppearanceHeader.Options.UseFont = True
        Me.colultfechapago.AppearanceHeader.Options.UseTextOptions = True
        Me.colultfechapago.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colultfechapago.Caption = "Fecha Ult Pago"
        Me.colultfechapago.FieldName = "ULTfechapago"
        Me.colultfechapago.Name = "colultfechapago"
        Me.colultfechapago.OptionsColumn.ReadOnly = True
        Me.colultfechapago.Visible = True
        Me.colultfechapago.VisibleIndex = 16
        '
        'direccion
        '
        Me.direccion.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.direccion.AppearanceHeader.Options.UseFont = True
        Me.direccion.AppearanceHeader.Options.UseTextOptions = True
        Me.direccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.direccion.Caption = "Dirección"
        Me.direccion.FieldName = "direccion"
        Me.direccion.Name = "direccion"
        Me.direccion.OptionsColumn.ReadOnly = True
        Me.direccion.Visible = True
        Me.direccion.VisibleIndex = 10
        '
        'ciudad
        '
        Me.ciudad.AppearanceCell.Options.UseTextOptions = True
        Me.ciudad.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ciudad.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ciudad.AppearanceHeader.Options.UseFont = True
        Me.ciudad.AppearanceHeader.Options.UseTextOptions = True
        Me.ciudad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ciudad.Caption = "Ciudad"
        Me.ciudad.FieldName = "Ciudad"
        Me.ciudad.Name = "ciudad"
        Me.ciudad.OptionsColumn.ReadOnly = True
        Me.ciudad.Visible = True
        Me.ciudad.VisibleIndex = 11
        '
        'colonia
        '
        Me.colonia.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colonia.AppearanceHeader.Options.UseFont = True
        Me.colonia.AppearanceHeader.Options.UseTextOptions = True
        Me.colonia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colonia.Caption = "Colonia"
        Me.colonia.FieldName = "colonia"
        Me.colonia.Name = "colonia"
        Me.colonia.OptionsColumn.ReadOnly = True
        Me.colonia.Visible = True
        Me.colonia.VisibleIndex = 12
        '
        'Telefono1
        '
        Me.Telefono1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Telefono1.AppearanceHeader.Options.UseFont = True
        Me.Telefono1.AppearanceHeader.Options.UseTextOptions = True
        Me.Telefono1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Telefono1.Caption = "Teléfonos"
        Me.Telefono1.FieldName = "Telefono1"
        Me.Telefono1.Name = "Telefono1"
        Me.Telefono1.OptionsColumn.ReadOnly = True
        Me.Telefono1.Visible = True
        Me.Telefono1.VisibleIndex = 13
        '
        'aval
        '
        Me.aval.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.aval.AppearanceHeader.Options.UseFont = True
        Me.aval.AppearanceHeader.Options.UseTextOptions = True
        Me.aval.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.aval.Caption = "Aval"
        Me.aval.FieldName = "aval"
        Me.aval.Name = "aval"
        Me.aval.OptionsColumn.ReadOnly = True
        Me.aval.Visible = True
        Me.aval.VisibleIndex = 14
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
        'Pnl_Detallado
        '
        Me.Pnl_Detallado.Controls.Add(Me.DGrid2)
        Me.Pnl_Detallado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Detallado.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Detallado.Name = "Pnl_Detallado"
        Me.Pnl_Detallado.Size = New System.Drawing.Size(853, 167)
        Me.Pnl_Detallado.TabIndex = 7
        '
        'DGrid2
        '
        Me.DGrid2.DataSource = Me.UspPpalVencidoxAnioBindingSource
        Me.DGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid2.Location = New System.Drawing.Point(2, 2)
        Me.DGrid2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid2.MainView = Me.GridView2
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(849, 163)
        Me.DGrid2.TabIndex = 7
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'UspPpalVencidoxAnioBindingSource
        '
        Me.UspPpalVencidoxAnioBindingSource.DataMember = "usp_PpalVencidoxAnio"
        Me.UspPpalVencidoxAnioBindingSource.DataSource = Me.Usp_PpalVencidoxAnio
        '
        'Usp_PpalVencidoxAnio
        '
        Me.Usp_PpalVencidoxAnio.DataSetName = "usp_PpalVencidoxAnio"
        Me.Usp_PpalVencidoxAnio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView2
        '
        Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colgestor, Me.total, Me.colAnio2019, Me.colAnio2018, Me.colAnio2017, Me.colAnio2016, Me.colAnio2015, Me.colAnio2014, Me.colAnio2013, Me.colAnio2012, Me.colAnio2011, Me.colAnio2010, Me.colAnio2010_})
        Me.GridView2.GridControl = Me.DGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'colgestor
        '
        Me.colgestor.Caption = "Gestor Asignado"
        Me.colgestor.FieldName = "gestor"
        Me.colgestor.Name = "colgestor"
        Me.colgestor.OptionsColumn.ReadOnly = True
        Me.colgestor.Visible = True
        Me.colgestor.VisibleIndex = 0
        '
        'total
        '
        Me.total.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total.AppearanceHeader.Options.UseFont = True
        Me.total.AppearanceHeader.Options.UseTextOptions = True
        Me.total.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.total.Caption = "Total"
        Me.total.DisplayFormat.FormatString = "#,###,###"
        Me.total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.total.FieldName = "total"
        Me.total.Name = "total"
        Me.total.OptionsColumn.ReadOnly = True
        Me.total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:$###,###,##0}", "0")})
        Me.total.Visible = True
        Me.total.VisibleIndex = 1
        '
        'colAnio2019
        '
        Me.colAnio2019.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colAnio2019.AppearanceHeader.Options.UseFont = True
        Me.colAnio2019.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2019.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2019.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2019.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2019.FieldName = "Anio2019"
        Me.colAnio2019.Name = "colAnio2019"
        Me.colAnio2019.OptionsColumn.ReadOnly = True
        Me.colAnio2019.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2019", "{0:$###,###,##0}", "0")})
        '
        'colAnio2018
        '
        Me.colAnio2018.Caption = "2018"
        Me.colAnio2018.FieldName = "Anio2018"
        Me.colAnio2018.Name = "colAnio2018"
        Me.colAnio2018.OptionsColumn.ReadOnly = True
        Me.colAnio2018.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2018", "{0:$###,###,##0}", "0")})
        Me.colAnio2018.Visible = True
        Me.colAnio2018.VisibleIndex = 2
        '
        'colAnio2017
        '
        Me.colAnio2017.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colAnio2017.AppearanceHeader.Options.UseFont = True
        Me.colAnio2017.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2017.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2017.Caption = "2017"
        Me.colAnio2017.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2017.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2017.FieldName = "Anio2017"
        Me.colAnio2017.Name = "colAnio2017"
        Me.colAnio2017.OptionsColumn.ReadOnly = True
        Me.colAnio2017.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2017", "{0:$###,###,##0}", "0")})
        Me.colAnio2017.Visible = True
        Me.colAnio2017.VisibleIndex = 3
        '
        'colAnio2016
        '
        Me.colAnio2016.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2016.AppearanceHeader.Options.UseFont = True
        Me.colAnio2016.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2016.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2016.Caption = "2016"
        Me.colAnio2016.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2016.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2016.FieldName = "Anio2016"
        Me.colAnio2016.Name = "colAnio2016"
        Me.colAnio2016.OptionsColumn.ReadOnly = True
        Me.colAnio2016.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2016", "{0:$###,###,##0}", "0")})
        Me.colAnio2016.Visible = True
        Me.colAnio2016.VisibleIndex = 4
        '
        'colAnio2015
        '
        Me.colAnio2015.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2015.AppearanceHeader.Options.UseFont = True
        Me.colAnio2015.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2015.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2015.Caption = "2015"
        Me.colAnio2015.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2015.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2015.FieldName = "Anio2015"
        Me.colAnio2015.Name = "colAnio2015"
        Me.colAnio2015.OptionsColumn.ReadOnly = True
        Me.colAnio2015.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2015", "{0:$###,###,##0}", "0")})
        Me.colAnio2015.Visible = True
        Me.colAnio2015.VisibleIndex = 5
        '
        'colAnio2014
        '
        Me.colAnio2014.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2014.AppearanceHeader.Options.UseFont = True
        Me.colAnio2014.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2014.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2014.Caption = "2014"
        Me.colAnio2014.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2014.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2014.FieldName = "Anio2014"
        Me.colAnio2014.Name = "colAnio2014"
        Me.colAnio2014.OptionsColumn.ReadOnly = True
        Me.colAnio2014.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2014", "{0:$###,###,##0}", "0")})
        Me.colAnio2014.Visible = True
        Me.colAnio2014.VisibleIndex = 6
        '
        'colAnio2013
        '
        Me.colAnio2013.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2013.AppearanceHeader.Options.UseFont = True
        Me.colAnio2013.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2013.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2013.Caption = "2013"
        Me.colAnio2013.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2013.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2013.FieldName = "Anio2013"
        Me.colAnio2013.Name = "colAnio2013"
        Me.colAnio2013.OptionsColumn.ReadOnly = True
        Me.colAnio2013.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2013", "{0:$###,###,##0}", "0")})
        Me.colAnio2013.Visible = True
        Me.colAnio2013.VisibleIndex = 7
        '
        'colAnio2012
        '
        Me.colAnio2012.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2012.AppearanceHeader.Options.UseFont = True
        Me.colAnio2012.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2012.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2012.Caption = "2012"
        Me.colAnio2012.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2012.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2012.FieldName = "Anio2012"
        Me.colAnio2012.Name = "colAnio2012"
        Me.colAnio2012.OptionsColumn.ReadOnly = True
        Me.colAnio2012.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2012", "{0:$###,###,##0}", "0")})
        Me.colAnio2012.Visible = True
        Me.colAnio2012.VisibleIndex = 8
        '
        'colAnio2011
        '
        Me.colAnio2011.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2011.AppearanceHeader.Options.UseFont = True
        Me.colAnio2011.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2011.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2011.Caption = "2011"
        Me.colAnio2011.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2011.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2011.FieldName = "Anio2011"
        Me.colAnio2011.Name = "colAnio2011"
        Me.colAnio2011.OptionsColumn.ReadOnly = True
        Me.colAnio2011.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2011", "{0:$###,###,##0}", "0")})
        Me.colAnio2011.Visible = True
        Me.colAnio2011.VisibleIndex = 9
        '
        'colAnio2010
        '
        Me.colAnio2010.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2010.AppearanceHeader.Options.UseFont = True
        Me.colAnio2010.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2010.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2010.Caption = "2010"
        Me.colAnio2010.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2010.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2010.FieldName = "Anio2010"
        Me.colAnio2010.Name = "colAnio2010"
        Me.colAnio2010.OptionsColumn.ReadOnly = True
        Me.colAnio2010.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2010", "{0:$###,###,##0}", "0")})
        Me.colAnio2010.Visible = True
        Me.colAnio2010.VisibleIndex = 10
        '
        'colAnio2010_
        '
        Me.colAnio2010_.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colAnio2010_.AppearanceHeader.Options.UseFont = True
        Me.colAnio2010_.AppearanceHeader.Options.UseTextOptions = True
        Me.colAnio2010_.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colAnio2010_.Caption = "Anteriores"
        Me.colAnio2010_.DisplayFormat.FormatString = "#,###,###"
        Me.colAnio2010_.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colAnio2010_.FieldName = "Anio2010_"
        Me.colAnio2010_.Name = "colAnio2010_"
        Me.colAnio2010_.OptionsColumn.ReadOnly = True
        Me.colAnio2010_.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anio2010_", "{0:$###,###,##0}", "0")})
        Me.colAnio2010_.Visible = True
        Me.colAnio2010_.VisibleIndex = 11
        '
        'Usp_PpalVencidoxAnioTableAdapter
        '
        Me.Usp_PpalVencidoxAnioTableAdapter.ClearBeforeFill = True
        '
        'frmPpalVencido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.Pnl_Detallado)
        Me.Controls.Add(Me.Pnl_Principal)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmPpalVencido"
        Me.Text = "Asignación de Vencido"
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.Chk_Direccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalVencidoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalVencido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Principal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Principal.ResumeLayout(False)
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Detallado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Detallado.ResumeLayout(False)
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalVencidoxAnioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalVencidoxAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Imprimir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Chk_Direccion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Usp_PpalGestoriaTableAdapter As usp_PpalGestoriaTableAdapters.usp_PpalGestoriaTableAdapter
    Friend WithEvents Btn_Asignar As Button
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Usp_PpalVencido As usp_PpalVencido
    Friend WithEvents UspPpalVencidoBindingSource As BindingSource
    Friend WithEvents Usp_PpalVencidoTableAdapter As usp_PpalVencidoTableAdapters.usp_PpalVencidoTableAdapter
    Friend WithEvents Pnl_Principal As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Pnl_Detallado As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Distrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents fecalta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents saldo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents capital As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents interes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cobranza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colultpago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colultfechapago As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents direccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ciudad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colonia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Telefono1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents aval As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gestor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcampo4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Usp_PpalVencidoxAnio As usp_PpalVencidoxAnio
    Friend WithEvents UspPpalVencidoxAnioBindingSource As BindingSource
    Friend WithEvents Usp_PpalVencidoxAnioTableAdapter As usp_PpalVencidoxAnioTableAdapters.usp_PpalVencidoxAnioTableAdapter
    Friend WithEvents colgestor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2019 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2018 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2017 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2016 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2015 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2014 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2013 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2012 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2011 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2010 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAnio2010_ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Btn_QuitarAsignacion As Button
End Class
