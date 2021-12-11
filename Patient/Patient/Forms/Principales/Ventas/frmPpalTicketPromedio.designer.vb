<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalTicketPromedio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPpalTicketPromedio))
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        Me.DEditHasta = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DEditDesde = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.DGrid1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DGrid2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEditHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEditDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.Pnl_Botones.Controls.Add(Me.DEditHasta)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl2)
        Me.Pnl_Botones.Controls.Add(Me.DEditDesde)
        Me.Pnl_Botones.Controls.Add(Me.LabelControl1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 352)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(920, 60)
        Me.Pnl_Botones.TabIndex = 20
        '
        'DEditHasta
        '
        Me.DEditHasta.EditValue = Nothing
        Me.DEditHasta.Location = New System.Drawing.Point(265, 20)
        Me.DEditHasta.Name = "DEditHasta"
        Me.DEditHasta.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEditHasta.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEditHasta.Size = New System.Drawing.Size(145, 20)
        Me.DEditHasta.TabIndex = 9
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(228, 23)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(8, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "al"
        '
        'DEditDesde
        '
        Me.DEditDesde.EditValue = Nothing
        Me.DEditDesde.Location = New System.Drawing.Point(59, 20)
        Me.DEditDesde.Name = "DEditDesde"
        Me.DEditDesde.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEditDesde.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEditDesde.Size = New System.Drawing.Size(145, 20)
        Me.DEditDesde.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(22, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(15, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Del"
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Consultar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Consultar.Location = New System.Drawing.Point(765, 2)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Consultar.TabIndex = 5
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(816, 2)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Excel.TabIndex = 3
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Salir.Location = New System.Drawing.Point(867, 2)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Salir.TabIndex = 4
        '
        'DGrid1
        '
        Me.DGrid1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DGrid1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid1.MainView = Me.GridView1
        Me.DGrid1.Name = "DGrid1"
        Me.DGrid1.Size = New System.Drawing.Size(410, 352)
        Me.DGrid1.TabIndex = 21
        Me.DGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'DGrid2
        '
        Me.DGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid2.Location = New System.Drawing.Point(410, 0)
        Me.DGrid2.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid2.MainView = Me.GridView2
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.Size = New System.Drawing.Size(510, 352)
        Me.DGrid2.TabIndex = 22
        Me.DGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.DGrid2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalTicketPromedio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 412)
        Me.Controls.Add(Me.DGrid2)
        Me.Controls.Add(Me.DGrid1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPpalTicketPromedio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ticket Promedio"
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DEditHasta.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEditHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEditDesde.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEditDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DGrid1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DGrid2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DEditHasta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEditDesde As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
