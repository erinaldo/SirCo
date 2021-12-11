<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalRelaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalRelaciones))
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Chk_TipoCredito = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.Cbo_Sucursal = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Cbo_TipoCredito = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DEFechaIni = New DevExpress.XtraEditors.DateEdit()
        Me.Btn_Recibos = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Relaciones = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_RelacionyRecibos = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Refrescar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Distrib2 = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Nombre2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Distrib1 = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Nombre1 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.Dgrid = New DevExpress.XtraGrid.GridControl()
        Me.UspPpalRelacionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Usp_PpalRelaciones = New SIRCO.usp_PpalRelaciones()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.coldistrib = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnombrecompleto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colapagar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Usp_PpalRelacionesTableAdapter = New SIRCO.usp_PpalRelacionesTableAdapters.usp_PpalRelacionesTableAdapter()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Chk_TipoCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_Sucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_TipoCredito.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Distrib2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Nombre2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Distrib1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Nombre1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UspPpalRelacionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Usp_PpalRelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.SimpleButton1)
        Me.Panel1.Controls.Add(Me.Chk_TipoCredito)
        Me.Panel1.Controls.Add(Me.Cbo_Sucursal)
        Me.Panel1.Controls.Add(Me.Cbo_TipoCredito)
        Me.Panel1.Controls.Add(Me.DEFechaIni)
        Me.Panel1.Controls.Add(Me.Btn_Recibos)
        Me.Panel1.Controls.Add(Me.Btn_Relaciones)
        Me.Panel1.Controls.Add(Me.Btn_RelacionyRecibos)
        Me.Panel1.Controls.Add(Me.Btn_Refrescar)
        Me.Panel1.Controls.Add(Me.LabelControl2)
        Me.Panel1.Controls.Add(Me.LabelControl1)
        Me.Panel1.Controls.Add(Me.LabelControl5)
        Me.Panel1.Controls.Add(Me.Txt_Distrib2)
        Me.Panel1.Controls.Add(Me.Txt_Nombre2)
        Me.Panel1.Controls.Add(Me.LabelControl7)
        Me.Panel1.Controls.Add(Me.Txt_Distrib1)
        Me.Panel1.Controls.Add(Me.Txt_Nombre1)
        Me.Panel1.Controls.Add(Me.LabelControl8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(961, 138)
        Me.Panel1.TabIndex = 2
        '
        'Chk_TipoCredito
        '
        Me.Chk_TipoCredito.Items.AddRange(New DevExpress.XtraEditors.Controls.CheckedListBoxItem() {New DevExpress.XtraEditors.Controls.CheckedListBoxItem("NORMAL"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("FRESCO"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("VENCIDO"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("DEMANDA")})
        Me.Chk_TipoCredito.Location = New System.Drawing.Point(85, 57)
        Me.Chk_TipoCredito.Name = "Chk_TipoCredito"
        Me.Chk_TipoCredito.Size = New System.Drawing.Size(120, 74)
        Me.Chk_TipoCredito.TabIndex = 49
        '
        'Cbo_Sucursal
        '
        Me.Cbo_Sucursal.EnterMoveNextControl = True
        Me.Cbo_Sucursal.Location = New System.Drawing.Point(85, 7)
        Me.Cbo_Sucursal.Name = "Cbo_Sucursal"
        Me.Cbo_Sucursal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_Sucursal.Properties.Items.AddRange(New Object() {"CRÉDITO", "TRIANA"})
        Me.Cbo_Sucursal.Size = New System.Drawing.Size(148, 20)
        Me.Cbo_Sucursal.TabIndex = 47
        '
        'Cbo_TipoCredito
        '
        Me.Cbo_TipoCredito.EnterMoveNextControl = True
        Me.Cbo_TipoCredito.Location = New System.Drawing.Point(256, 3)
        Me.Cbo_TipoCredito.Name = "Cbo_TipoCredito"
        Me.Cbo_TipoCredito.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Cbo_TipoCredito.Properties.Items.AddRange(New Object() {"NORMAL", "FRESCO", "VENCIDO", "DEMANDA"})
        Me.Cbo_TipoCredito.Size = New System.Drawing.Size(148, 20)
        Me.Cbo_TipoCredito.TabIndex = 46
        Me.Cbo_TipoCredito.Visible = False
        '
        'DEFechaIni
        '
        Me.DEFechaIni.EditValue = Nothing
        Me.DEFechaIni.Location = New System.Drawing.Point(338, 57)
        Me.DEFechaIni.Name = "DEFechaIni"
        Me.DEFechaIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaIni.TabIndex = 45
        '
        'Btn_Recibos
        '
        Me.Btn_Recibos.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.list__1_
        Me.Btn_Recibos.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Recibos.Location = New System.Drawing.Point(834, 60)
        Me.Btn_Recibos.Name = "Btn_Recibos"
        Me.Btn_Recibos.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Recibos.TabIndex = 44
        Me.Btn_Recibos.ToolTip = "Imprimir Solo Recibos"
        '
        'Btn_Relaciones
        '
        Me.Btn_Relaciones.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.document
        Me.Btn_Relaciones.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Relaciones.Location = New System.Drawing.Point(777, 60)
        Me.Btn_Relaciones.Name = "Btn_Relaciones"
        Me.Btn_Relaciones.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Relaciones.TabIndex = 43
        Me.Btn_Relaciones.ToolTip = "Imprimir Solo Relación"
        '
        'Btn_RelacionyRecibos
        '
        Me.Btn_RelacionyRecibos.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_RelacionyRecibos.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_RelacionyRecibos.Location = New System.Drawing.Point(720, 60)
        Me.Btn_RelacionyRecibos.Name = "Btn_RelacionyRecibos"
        Me.Btn_RelacionyRecibos.Size = New System.Drawing.Size(51, 52)
        Me.Btn_RelacionyRecibos.TabIndex = 42
        Me.Btn_RelacionyRecibos.ToolTip = "Imprimir Relación y Recibos"
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Refrescar.Location = New System.Drawing.Point(663, 60)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 41
        Me.Btn_Refrescar.ToolTip = "Refrescar Información"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(9, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl2.TabIndex = 39
        Me.LabelControl2.Text = "Tipo de Crédito"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(504, 34)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(9, 13)
        Me.LabelControl1.TabIndex = 38
        Me.LabelControl1.Text = "Al"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(256, 60)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(59, 13)
        Me.LabelControl5.TabIndex = 34
        Me.LabelControl5.Text = "Fecha Corte"
        '
        'Txt_Distrib2
        '
        Me.Txt_Distrib2.EnterMoveNextControl = True
        Me.Txt_Distrib2.Location = New System.Drawing.Point(538, 31)
        Me.Txt_Distrib2.Name = "Txt_Distrib2"
        Me.Txt_Distrib2.Size = New System.Drawing.Size(61, 20)
        Me.Txt_Distrib2.TabIndex = 3
        '
        'Txt_Nombre2
        '
        Me.Txt_Nombre2.Enabled = False
        Me.Txt_Nombre2.EnterMoveNextControl = True
        Me.Txt_Nombre2.Location = New System.Drawing.Point(605, 31)
        Me.Txt_Nombre2.Name = "Txt_Nombre2"
        Me.Txt_Nombre2.Size = New System.Drawing.Size(333, 20)
        Me.Txt_Nombre2.TabIndex = 4
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(11, 34)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl7.TabIndex = 29
        Me.LabelControl7.Text = "Distribuidor"
        '
        'Txt_Distrib1
        '
        Me.Txt_Distrib1.EnterMoveNextControl = True
        Me.Txt_Distrib1.Location = New System.Drawing.Point(86, 31)
        Me.Txt_Distrib1.Name = "Txt_Distrib1"
        Me.Txt_Distrib1.Size = New System.Drawing.Size(61, 20)
        Me.Txt_Distrib1.TabIndex = 1
        '
        'Txt_Nombre1
        '
        Me.Txt_Nombre1.Enabled = False
        Me.Txt_Nombre1.EnterMoveNextControl = True
        Me.Txt_Nombre1.Location = New System.Drawing.Point(153, 31)
        Me.Txt_Nombre1.Name = "Txt_Nombre1"
        Me.Txt_Nombre1.Size = New System.Drawing.Size(333, 20)
        Me.Txt_Nombre1.TabIndex = 2
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(9, 10)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl8.TabIndex = 25
        Me.LabelControl8.Text = "Oficina"
        '
        'Dgrid
        '
        Me.Dgrid.DataSource = Me.UspPpalRelacionesBindingSource
        Me.Dgrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgrid.Location = New System.Drawing.Point(0, 138)
        Me.Dgrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Dgrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Dgrid.MainView = Me.GridView2
        Me.Dgrid.Name = "Dgrid"
        Me.Dgrid.Size = New System.Drawing.Size(961, 350)
        Me.Dgrid.TabIndex = 3
        Me.Dgrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'UspPpalRelacionesBindingSource
        '
        Me.UspPpalRelacionesBindingSource.DataMember = "usp_PpalRelaciones"
        Me.UspPpalRelacionesBindingSource.DataSource = Me.Usp_PpalRelaciones
        '
        'Usp_PpalRelaciones
        '
        Me.Usp_PpalRelaciones.DataSetName = "usp_PpalRelaciones"
        Me.Usp_PpalRelaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.coldistrib, Me.colnombrecompleto, Me.colapagar})
        Me.GridView2.GridControl = Me.Dgrid
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'coldistrib
        '
        Me.coldistrib.Caption = "Distrib"
        Me.coldistrib.FieldName = "distrib"
        Me.coldistrib.Name = "coldistrib"
        Me.coldistrib.OptionsColumn.ReadOnly = True
        Me.coldistrib.Visible = True
        Me.coldistrib.VisibleIndex = 0
        '
        'colnombrecompleto
        '
        Me.colnombrecompleto.Caption = "Nombre"
        Me.colnombrecompleto.FieldName = "nombrecompleto"
        Me.colnombrecompleto.Name = "colnombrecompleto"
        Me.colnombrecompleto.OptionsColumn.ReadOnly = True
        Me.colnombrecompleto.Visible = True
        Me.colnombrecompleto.VisibleIndex = 1
        '
        'colapagar
        '
        Me.colapagar.Caption = "Total"
        Me.colapagar.FieldName = "apagar"
        Me.colapagar.Name = "colapagar"
        Me.colapagar.OptionsColumn.ReadOnly = True
        Me.colapagar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "apagar", "SUMA={0:#,###,###}")})
        Me.colapagar.Visible = True
        Me.colapagar.VisibleIndex = 2
        '
        'Usp_PpalRelacionesTableAdapter
        '
        Me.Usp_PpalRelacionesTableAdapter.ClearBeforeFill = True
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(891, 60)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(51, 52)
        Me.SimpleButton1.TabIndex = 50
        Me.SimpleButton1.ToolTip = "Imprimir EN PDF"
        '
        'frmPpalRelaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 488)
        Me.Controls.Add(Me.Dgrid)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalRelaciones"
        Me.Text = "Entrega de Relaciones"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Chk_TipoCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_Sucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_TipoCredito.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Distrib2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Nombre2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Distrib1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Nombre1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UspPpalRelacionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Usp_PpalRelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Distrib2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Nombre2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Distrib1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Nombre1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Dgrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UspPpalRelacionesBindingSource As BindingSource
    Friend WithEvents Usp_PpalRelaciones As usp_PpalRelaciones
    Friend WithEvents coldistrib As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnombrecompleto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colapagar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Usp_PpalRelacionesTableAdapter As usp_PpalRelacionesTableAdapters.usp_PpalRelacionesTableAdapter
    Friend WithEvents Btn_Refrescar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_RelacionyRecibos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Recibos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Relaciones As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEFechaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Cbo_TipoCredito As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Cbo_Sucursal As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Chk_TipoCredito As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
