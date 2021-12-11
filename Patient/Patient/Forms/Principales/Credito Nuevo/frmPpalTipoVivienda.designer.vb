<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPpalTipoVivenda
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Btn_Consultar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Editar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Refrescar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(0, 0)
        Me.Grid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Grid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Grid.MainView = Me.GridView
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(661, 363)
        Me.Grid.TabIndex = 0
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.Grid
        Me.GridView.Name = "GridView"
        '
        'Btn_Consultar
        '
        Me.Btn_Consultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Consultar.Image = Global.SIRCO.My.Resources.Resources.find
        Me.Btn_Consultar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Consultar.Location = New System.Drawing.Point(87, 5)
        Me.Btn_Consultar.Name = "Btn_Consultar"
        Me.Btn_Consultar.Size = New System.Drawing.Size(42, 56)
        Me.Btn_Consultar.TabIndex = 167
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Nuevo.Location = New System.Drawing.Point(5, 5)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(39, 56)
        Me.Btn_Nuevo.TabIndex = 165
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Editar.Location = New System.Drawing.Point(46, 5)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(39, 56)
        Me.Btn_Editar.TabIndex = 168
        '
        'Btn_Refrescar
        '
        Me.Btn_Refrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Refrescar.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_Refrescar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Refrescar.Location = New System.Drawing.Point(528, 5)
        Me.Btn_Refrescar.Name = "Btn_Refrescar"
        Me.Btn_Refrescar.Size = New System.Drawing.Size(42, 56)
        Me.Btn_Refrescar.TabIndex = 169
        '
        'Btn_Excel
        '
        Me.Btn_Excel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_Excel.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.Btn_Excel.Location = New System.Drawing.Point(572, 5)
        Me.Btn_Excel.Name = "Btn_Excel"
        Me.Btn_Excel.Size = New System.Drawing.Size(42, 56)
        Me.Btn_Excel.TabIndex = 170
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Salir.Location = New System.Drawing.Point(617, 5)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(42, 56)
        Me.Btn_Salir.TabIndex = 171
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Salir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Consultar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Refrescar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Excel)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 363)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(661, 63)
        Me.Pnl_Botones.TabIndex = 172
        '
        'frmPpalTipoVivenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 426)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Grid)
        Me.Name = "frmPpalTipoVivenda"
        Me.Text = "Catálogo de Tipo de Vivienda"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Btn_Consultar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Editar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Refrescar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
End Class
