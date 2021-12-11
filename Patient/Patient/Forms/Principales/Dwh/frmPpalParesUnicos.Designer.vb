<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalParesUnicos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalParesUnicos))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Refrescar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFechaFin = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFechaIni = New DevExpress.XtraEditors.DateEdit()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalParesUnicosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalParesUnicos1 = New SIRCO.usp_PpalParesUnicos1()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colx = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldescrip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colventadia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colventaacum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UspPpalParesUnicosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalParesUnicos = New SIRCO.usp_PpalParesUnicos()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Usp_PpalParesUnicosTableAdapter = New SIRCO.usp_PpalParesUnicos1TableAdapters.usp_PpalParesUnicosTableAdapter()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalParesUnicosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalParesUnicos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalParesUnicosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalParesUnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.DEFechaFin)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl1)
        Me.Pnl_Botones.Controls.Add(Me.DEFechaIni)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 361)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(835, 56)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Refrescar.Location = New System.Drawing.Point(678, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 4
        Me.Btn_Refrescar.ToolTip = "Refrescar Información"
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(729, 0)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Excel.TabIndex = 3
        Me.Btn_Excel.ToolTip = "Exportar a Excel"
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Salir.Location = New System.Drawing.Point(780, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 2
        Me.Btn_Salir.ToolTip = "Salir"
        '
        'DEFechaFin
        '
        Me.DEFechaFin.EditValue = Nothing
        Me.DEFechaFin.Location = New System.Drawing.Point(220, 16)
        Me.DEFechaFin.Name = "DEFechaFin"
        Me.DEFechaFin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaFin.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Fecha"
        '
        'DEFechaIni
        '
        Me.DEFechaIni.EditValue = Nothing
        Me.DEFechaIni.Location = New System.Drawing.Point(66, 16)
        Me.DEFechaIni.Name = "DEFechaIni"
        Me.DEFechaIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaIni.TabIndex = 0
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(33, 18)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 20
        '
        'DGrid1
        '
        Me.DGrid1.DataSource = Me.UspPpalParesUnicosBindingSource1
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(835, 361)
        Me.DGrid1.TabIndex = 8
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'UspPpalParesUnicosBindingSource1
        '
        Me.UspPpalParesUnicosBindingSource1.DataMember = "usp_PpalParesUnicos"
        Me.UspPpalParesUnicosBindingSource1.DataSource = Me.Usp_PpalParesUnicos1
        '
        'Usp_PpalParesUnicos1
        '
        Me.Usp_PpalParesUnicos1.DataSetName = "usp_PpalParesUnicos1"
        Me.Usp_PpalParesUnicos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colx, Me.colsucursal, Me.coldescrip, Me.colventadia, Me.colventaacum})
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, Nothing, Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'colx
        '
        Me.colx.FieldName = "x"
        Me.colx.Name = "colx"
        Me.colx.OptionsColumn.ReadOnly = True
        Me.colx.Visible = True
        Me.colx.VisibleIndex = 0
        '
        'colsucursal
        '
        Me.colsucursal.FieldName = "sucursal"
        Me.colsucursal.Name = "colsucursal"
        Me.colsucursal.OptionsColumn.ReadOnly = True
        Me.colsucursal.Visible = True
        Me.colsucursal.VisibleIndex = 1
        '
        'coldescrip
        '
        Me.coldescrip.FieldName = "descrip"
        Me.coldescrip.Name = "coldescrip"
        Me.coldescrip.OptionsColumn.ReadOnly = True
        Me.coldescrip.Visible = True
        Me.coldescrip.VisibleIndex = 2
        '
        'colventadia
        '
        Me.colventadia.FieldName = "ventadia"
        Me.colventadia.Name = "colventadia"
        Me.colventadia.OptionsColumn.ReadOnly = True
        Me.colventadia.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ventadia", "{0:#,###0}")})
        Me.colventadia.Visible = True
        Me.colventadia.VisibleIndex = 3
        '
        'colventaacum
        '
        Me.colventaacum.FieldName = "ventaacum"
        Me.colventaacum.Name = "colventaacum"
        Me.colventaacum.OptionsColumn.ReadOnly = True
        Me.colventaacum.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ventaacum", "{0:#,###0}")})
        Me.colventaacum.Visible = True
        Me.colventaacum.VisibleIndex = 4
        '
        'UspPpalParesUnicosBindingSource
        '
        Me.UspPpalParesUnicosBindingSource.DataSource = Me.Usp_PpalParesUnicos
        Me.UspPpalParesUnicosBindingSource.Position = 0
        '
        'Usp_PpalParesUnicos
        '
        Me.Usp_PpalParesUnicos.DataSetName = "usp_PpalParesUnicos"
        Me.Usp_PpalParesUnicos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'Usp_PpalParesUnicosTableAdapter
        '
        Me.Usp_PpalParesUnicosTableAdapter.ClearBeforeFill = True
        '
        'frmPpalParesUnicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 417)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalParesUnicos"
        Me.Text = "Pares Únicos"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalParesUnicosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalParesUnicos1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalParesUnicosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalParesUnicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents DEFechaFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFechaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Btn_Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Refrescar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents UspPpalParesUnicosBindingSource As BindingSource
    Friend WithEvents Usp_PpalParesUnicos As usp_PpalParesUnicos
    Friend WithEvents UspPpalParesUnicosBindingSource1 As BindingSource
    Friend WithEvents Usp_PpalParesUnicos1 As usp_PpalParesUnicos1
    Friend WithEvents colx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldescrip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colventadia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colventaacum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Usp_PpalParesUnicosTableAdapter As usp_PpalParesUnicos1TableAdapters.usp_PpalParesUnicosTableAdapter
End Class
