<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalAlcanceMetas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalAlcanceMetas))
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.coldescrip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldescrip1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtacalzado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonocalzado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtaparesunicos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonoparesunicos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtaaccesorios = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonoaccesorios = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtaelectronica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonoelectronica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvtalentes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbonolentes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvta1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbono1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colvta2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colbono2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Imprimir = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGrid1
        '
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(738, 278)
        Me.DGrid1.TabIndex = 9
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.coldescrip, Me.coldescrip1, Me.colnombre, Me.coltotal, Me.colvtacalzado, Me.colbonocalzado, Me.colvtaparesunicos, Me.colbonoparesunicos, Me.colvtaaccesorios, Me.colbonoaccesorios, Me.colvtaelectronica, Me.colbonoelectronica, Me.colvtalentes, Me.colbonolentes, Me.colvta1, Me.colbono1, Me.colvta2, Me.colbono2})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 278)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(738, 56)
        Me.Pnl_Botones.TabIndex = 8
        '
        'coldescrip
        '
        Me.coldescrip.Caption = "Sucursal"
        Me.coldescrip.FieldName = "descrip"
        Me.coldescrip.Name = "coldescrip"
        Me.coldescrip.OptionsColumn.ReadOnly = True
        Me.coldescrip.Visible = True
        Me.coldescrip.VisibleIndex = 0
        '
        'coldescrip1
        '
        Me.coldescrip1.Caption = "Puesto"
        Me.coldescrip1.FieldName = "descrip1"
        Me.coldescrip1.Name = "coldescrip1"
        Me.coldescrip1.OptionsColumn.ReadOnly = True
        Me.coldescrip1.Visible = True
        Me.coldescrip1.VisibleIndex = 1
        '
        'colnombre
        '
        Me.colnombre.Caption = "Nombre"
        Me.colnombre.FieldName = "nombre"
        Me.colnombre.Name = "colnombre"
        Me.colnombre.OptionsColumn.ReadOnly = True
        Me.colnombre.Visible = True
        Me.colnombre.VisibleIndex = 2
        '
        'coltotal
        '
        Me.coltotal.Caption = "Total"
        Me.coltotal.FieldName = "total"
        Me.coltotal.Name = "coltotal"
        Me.coltotal.OptionsColumn.ReadOnly = True
        Me.coltotal.Visible = True
        Me.coltotal.VisibleIndex = 3
        '
        'colvtacalzado
        '
        Me.colvtacalzado.Caption = "Vta Calzado"
        Me.colvtacalzado.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvtacalzado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtacalzado.FieldName = "vtacalzado"
        Me.colvtacalzado.Name = "colvtacalzado"
        Me.colvtacalzado.OptionsColumn.ReadOnly = True
        Me.colvtacalzado.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vtacalzado", "{0:#,###,##0.00}")})
        Me.colvtacalzado.Visible = True
        Me.colvtacalzado.VisibleIndex = 4
        '
        'colbonocalzado
        '
        Me.colbonocalzado.Caption = "Bono Calzado"
        Me.colbonocalzado.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbonocalzado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonocalzado.FieldName = "bonocalzado"
        Me.colbonocalzado.Name = "colbonocalzado"
        Me.colbonocalzado.OptionsColumn.ReadOnly = True
        Me.colbonocalzado.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonocalzado", "{0:#,###,##0.00}")})
        Me.colbonocalzado.Visible = True
        Me.colbonocalzado.VisibleIndex = 5
        '
        'colvtaparesunicos
        '
        Me.colvtaparesunicos.Caption = "Vta Prs Unicos"
        Me.colvtaparesunicos.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvtaparesunicos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtaparesunicos.FieldName = "vtaparesunicos"
        Me.colvtaparesunicos.Name = "colvtaparesunicos"
        Me.colvtaparesunicos.OptionsColumn.ReadOnly = True
        Me.colvtaparesunicos.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vtaparesunicos", "{0:#,###,##0.00}")})
        Me.colvtaparesunicos.Visible = True
        Me.colvtaparesunicos.VisibleIndex = 6
        '
        'colbonoparesunicos
        '
        Me.colbonoparesunicos.Caption = "Bono Prs Unicos"
        Me.colbonoparesunicos.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbonoparesunicos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonoparesunicos.FieldName = "bonoparesunicos"
        Me.colbonoparesunicos.Name = "colbonoparesunicos"
        Me.colbonoparesunicos.OptionsColumn.ReadOnly = True
        Me.colbonoparesunicos.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonoparesunicos", "{0:#,###,##0.00}")})
        Me.colbonoparesunicos.Visible = True
        Me.colbonoparesunicos.VisibleIndex = 7
        '
        'colvtaaccesorios
        '
        Me.colvtaaccesorios.Caption = "Vta Accesorios"
        Me.colvtaaccesorios.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvtaaccesorios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtaaccesorios.FieldName = "vtaaccesorios"
        Me.colvtaaccesorios.Name = "colvtaaccesorios"
        Me.colvtaaccesorios.OptionsColumn.ReadOnly = True
        Me.colvtaaccesorios.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vtaaccesorios", "{0:#,###,##0.00}")})
        Me.colvtaaccesorios.Visible = True
        Me.colvtaaccesorios.VisibleIndex = 8
        '
        'colbonoaccesorios
        '
        Me.colbonoaccesorios.Caption = "Bono Accesorios"
        Me.colbonoaccesorios.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbonoaccesorios.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonoaccesorios.FieldName = "bonoaccesorios"
        Me.colbonoaccesorios.Name = "colbonoaccesorios"
        Me.colbonoaccesorios.OptionsColumn.ReadOnly = True
        Me.colbonoaccesorios.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonoaccesorios", "{0:#,###,##0.00}")})
        Me.colbonoaccesorios.Visible = True
        Me.colbonoaccesorios.VisibleIndex = 9
        '
        'colvtaelectronica
        '
        Me.colvtaelectronica.Caption = "Vta Electrónica"
        Me.colvtaelectronica.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvtaelectronica.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtaelectronica.FieldName = "vtaelectronica"
        Me.colvtaelectronica.Name = "colvtaelectronica"
        Me.colvtaelectronica.OptionsColumn.ReadOnly = True
        Me.colvtaelectronica.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vtaelectronica", "{0:#,###,##0.00}")})
        Me.colvtaelectronica.Visible = True
        Me.colvtaelectronica.VisibleIndex = 10
        '
        'colbonoelectronica
        '
        Me.colbonoelectronica.Caption = "Bono Electrónica"
        Me.colbonoelectronica.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbonoelectronica.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonoelectronica.FieldName = "bonoelectronica"
        Me.colbonoelectronica.Name = "colbonoelectronica"
        Me.colbonoelectronica.OptionsColumn.ReadOnly = True
        Me.colbonoelectronica.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonoelectronica", "{0:#,###,##0.00}")})
        Me.colbonoelectronica.Visible = True
        Me.colbonoelectronica.VisibleIndex = 11
        '
        'colvtalentes
        '
        Me.colvtalentes.Caption = "Vta Lentes"
        Me.colvtalentes.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvtalentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvtalentes.FieldName = "vtalentes"
        Me.colvtalentes.Name = "colvtalentes"
        Me.colvtalentes.OptionsColumn.ReadOnly = True
        Me.colvtalentes.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vtalentes", "{0:#,###,##0.00}")})
        '
        'colbonolentes
        '
        Me.colbonolentes.Caption = "Bono Lentes"
        Me.colbonolentes.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbonolentes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbonolentes.FieldName = "bonolentes"
        Me.colbonolentes.Name = "colbonolentes"
        Me.colbonolentes.OptionsColumn.ReadOnly = True
        Me.colbonolentes.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bonolentes", "{0:#,###,##0.00}")})
        '
        'colvta1
        '
        Me.colvta1.Caption = "Vta1"
        Me.colvta1.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colvta1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colvta1.FieldName = "vta1"
        Me.colvta1.Name = "colvta1"
        Me.colvta1.OptionsColumn.ReadOnly = True
        Me.colvta1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vta1", "{0:#,###,##0.00}")})
        '
        'colbono1
        '
        Me.colbono1.Caption = "Bono1"
        Me.colbono1.DisplayFormat.FormatString = "#,###,##0.00"
        Me.colbono1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colbono1.FieldName = "bono1"
        Me.colbono1.Name = "colbono1"
        Me.colbono1.OptionsColumn.ReadOnly = True
        Me.colbono1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bono1", "{0:#,###,##0.00}")})
        '
        'colvta2
        '
        Me.colvta2.Caption = "Vta2"
        Me.colvta2.FieldName = "vta2"
        Me.colvta2.Name = "colvta2"
        Me.colvta2.OptionsColumn.ReadOnly = True
        '
        'colbono2
        '
        Me.colbono2.Caption = "Bono2"
        Me.colbono2.FieldName = "bono2"
        Me.colbono2.Name = "colbono2"
        Me.colbono2.OptionsColumn.ReadOnly = True
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(530, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 12
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(581, 0)
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
        Me.Btn_Excel.Location = New System.Drawing.Point(632, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(683, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 5
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'frmPpalAlcanceMetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 334)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalAlcanceMetas"
        Me.Text = "Reporte de Alcance de Meta"
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents coldescrip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldescrip1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtacalzado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonocalzado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtaparesunicos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonoparesunicos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtaaccesorios As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonoaccesorios As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtaelectronica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonoelectronica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvtalentes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbonolentes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvta1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbono1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colvta2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colbono2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Imprimir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
End Class
