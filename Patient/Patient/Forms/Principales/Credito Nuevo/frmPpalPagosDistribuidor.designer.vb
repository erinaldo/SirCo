<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalPagosDistribuidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalPagosDistribuidor))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Refrescar = New System.Windows.Forms.Button()
        Me.Txt_NomDistrib = New DevExpress.XtraEditors.TextEdit()
        Me.Btn_Excel = New System.Windows.Forms.Button()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Distrib = New DevExpress.XtraEditors.TextEdit()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.DEFechaFin = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFechaIni = New DevExpress.XtraEditors.DateEdit()
        Me.Lbl_Leyenda = New System.Windows.Forms.Label()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Txt_NomDistrib.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Distrib.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Txt_NomDistrib)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl2)
        Me.Pnl_Botones.Controls.Add(Me.Txt_Distrib)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.DEFechaFin)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl1)
        Me.Pnl_Botones.Controls.Add(Me.DEFechaIni)
        Me.Pnl_Botones.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 446)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(853, 56)
        Me.Pnl_Botones.TabIndex = 6
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Refrescar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.Location = New System.Drawing.Point(645, 0)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Refrescar.TabIndex = 31
        Me.Btn_Refrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Refrescar.UseVisualStyleBackColor = True
        '
        'Txt_NomDistrib
        '
        Me.Txt_NomDistrib.EditValue = ""
        Me.Txt_NomDistrib.Location = New System.Drawing.Point(139, 3)
        Me.Txt_NomDistrib.Name = "Txt_NomDistrib"
        Me.Txt_NomDistrib.Properties.MaxLength = 6
        Me.Txt_NomDistrib.Size = New System.Drawing.Size(301, 20)
        Me.Txt_NomDistrib.TabIndex = 30
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(696, 0)
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
        Me.Btn_Salir.Location = New System.Drawing.Point(747, 0)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Salir.TabIndex = 27
        Me.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(20, 6)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl2.TabIndex = 26
        Me.LabelControl2.Text = "Distribuidor"
        '
        'Txt_Distrib
        '
        Me.Txt_Distrib.EditValue = ""
        Me.Txt_Distrib.Location = New System.Drawing.Point(74, 3)
        Me.Txt_Distrib.Name = "Txt_Distrib"
        Me.Txt_Distrib.Properties.MaxLength = 6
        Me.Txt_Distrib.Size = New System.Drawing.Size(59, 20)
        Me.Txt_Distrib.TabIndex = 0
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Location = New System.Drawing.Point(798, 0)
        Me.Btn_Aceptar.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Btn_Aceptar.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Btn_Aceptar.LookAndFeel.UseWindowsXPTheme = True
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 24
        Me.Btn_Aceptar.ToolTipTitle = "Actualizar Información"
        Me.Btn_Aceptar.Visible = False
        '
        'DEFechaFin
        '
        Me.DEFechaFin.EditValue = Nothing
        Me.DEFechaFin.Location = New System.Drawing.Point(228, 29)
        Me.DEFechaFin.Name = "DEFechaFin"
        Me.DEFechaFin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaFin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaFin.Size = New System.Drawing.Size(148, 20)
        Me.DEFechaFin.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(20, 32)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "Fecha"
        '
        'DEFechaIni
        '
        Me.DEFechaIni.EditValue = Nothing
        Me.DEFechaIni.Location = New System.Drawing.Point(74, 29)
        Me.DEFechaIni.Name = "DEFechaIni"
        Me.DEFechaIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.DEFechaIni.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
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
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'DGrid2
        '
        Me.DGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid2.Location = New System.Drawing.Point(0, 0)
        Me.DGrid2.MainView = Me.GridView2
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(853, 446)
        Me.DGrid2.TabIndex = 7
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.DGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'frmPpalPagosDistribuidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 502)
        Me.Controls.Add(Me.DGrid2)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPpalPagosDistribuidor"
        Me.Text = "Pagos por Distribuidor"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.Txt_NomDistrib.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Distrib.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaFin.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFechaIni.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEFechaFin As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFechaIni As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Lbl_Leyenda As Label
    Friend WithEvents Txt_Distrib As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Btn_Excel As Button
    Friend WithEvents sfdRuta As SaveFileDialog
    Friend WithEvents Txt_NomDistrib As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
