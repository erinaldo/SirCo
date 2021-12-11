<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPpalValeras
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
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Editar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.sfdRuta = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGrid
        '
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(779, 398)
        Me.DGrid.TabIndex = 0
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 338)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(779, 60)
        Me.Pnl_Botones.TabIndex = 19
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Consultar.Location = New System.Drawing.Point(104, 2)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Consultar.TabIndex = 5
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(675, 2)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Excel.TabIndex = 3
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Salir.Location = New System.Drawing.Point(726, 2)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Salir.TabIndex = 4
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Editar.Location = New System.Drawing.Point(53, 2)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Editar.TabIndex = 2
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Nuevo.Location = New System.Drawing.Point(2, 2)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 56)
        Me.Btn_Nuevo.TabIndex = 1
        '
        'sfdRuta
        '
        Me.sfdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frmPpalValeras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 398)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.DGrid)
        Me.Name = "frmPpalValeras"
        Me.Text = "Valeras"
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Editar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents sfdRuta As SaveFileDialog
End Class
