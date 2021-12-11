<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalBitacoraPedBod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalBitacoraPedBod))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.DEFechaFin = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFechaIni = New DevExpress.XtraEditors.DateEdit()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSucursal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIngreso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIdEmpleado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNoregistrados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 526)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(696, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 31
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
        Me.Btn_Excel.TabIndex = 28
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
        Me.Btn_Salir.TabIndex = 27
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'DEFechaFin
        '
        Me.DEFechaFin.EditValue = Nothing
        Me.DEFechaFin.Location = New System.Drawing.Point(229, 15)
        Me.DEFechaFin.Name = "DEFechaFin"
        Me.DEFechaFin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DEFechaFin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DEFechaFin.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaFin.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Fecha"
        '
        'DEFechaIni
        '
        Me.DEFechaIni.EditValue = Nothing
        Me.DEFechaIni.Location = New System.Drawing.Point(75, 15)
        Me.DEFechaIni.Name = "DEFechaIni"
        Me.DEFechaIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DEFechaIni.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DEFechaIni.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaIni.TabIndex = 1
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
        'DGrid
        '
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid.MainView = Me.GridView2
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(853, 526)
        Me.DGrid.TabIndex = 9
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSucursal, Me.colIngreso, Me.colIdEmpleado, Me.colNombre, Me.colNoregistrados})
        Me.GridView2.GridControl = Me.DGrid
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.SynchronizeClones = False
        '
        'colSucursal
        '
        Me.colSucursal.AppearanceCell.Options.UseTextOptions = True
        Me.colSucursal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSucursal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colSucursal.AppearanceHeader.Options.UseFont = True
        Me.colSucursal.AppearanceHeader.Options.UseTextOptions = True
        Me.colSucursal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colSucursal.Caption = "Sucursal"
        Me.colSucursal.FieldName = "sucursal"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.OptionsColumn.ReadOnly = True
        Me.colSucursal.Visible = True
        Me.colSucursal.VisibleIndex = 0
        '
        'colIngreso
        '
        Me.colIngreso.AppearanceCell.Options.UseTextOptions = True
        Me.colIngreso.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIngreso.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colIngreso.AppearanceHeader.Options.UseFont = True
        Me.colIngreso.AppearanceHeader.Options.UseTextOptions = True
        Me.colIngreso.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIngreso.Caption = "Ingreso"
        Me.colIngreso.FieldName = "ingreso"
        Me.colIngreso.Name = "colIngreso"
        Me.colIngreso.OptionsColumn.ReadOnly = True
        Me.colIngreso.Visible = True
        Me.colIngreso.VisibleIndex = 1
        '
        'colIdEmpleado
        '
        Me.colIdEmpleado.AppearanceCell.Options.UseTextOptions = True
        Me.colIdEmpleado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIdEmpleado.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colIdEmpleado.AppearanceHeader.Options.UseFont = True
        Me.colIdEmpleado.AppearanceHeader.Options.UseTextOptions = True
        Me.colIdEmpleado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colIdEmpleado.Caption = "IdEmpleado"
        Me.colIdEmpleado.FieldName = "idemplado"
        Me.colIdEmpleado.Name = "colIdEmpleado"
        Me.colIdEmpleado.OptionsColumn.ReadOnly = True
        '
        'colNombre
        '
        Me.colNombre.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNombre.AppearanceHeader.Options.UseFont = True
        Me.colNombre.AppearanceHeader.Options.UseTextOptions = True
        Me.colNombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colNombre.Caption = "Nombre"
        Me.colNombre.FieldName = "nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.OptionsColumn.ReadOnly = True
        Me.colNombre.Visible = True
        Me.colNombre.VisibleIndex = 2
        '
        'colNoregistrados
        '
        Me.colNoregistrados.AppearanceCell.Options.UseTextOptions = True
        Me.colNoregistrados.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colNoregistrados.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNoregistrados.AppearanceHeader.Options.UseFont = True
        Me.colNoregistrados.AppearanceHeader.Options.UseTextOptions = True
        Me.colNoregistrados.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colNoregistrados.Caption = "No Registrados"
        Me.colNoregistrados.FieldName = "NOREGISTRADOS"
        Me.colNoregistrados.Name = "colNoregistrados"
        Me.colNoregistrados.OptionsColumn.ReadOnly = True
        Me.colNoregistrados.Visible = True
        Me.colNoregistrados.VisibleIndex = 3
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalBitacoraPedBod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 582)
        Me.Controls.Add(Me.DGrid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalBitacoraPedBod"
        Me.Text = "Bitacora"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents DEFechaFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFechaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSucursal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIngreso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIdEmpleado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNoregistrados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
