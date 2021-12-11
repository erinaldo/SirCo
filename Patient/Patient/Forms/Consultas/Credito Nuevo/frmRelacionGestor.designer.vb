<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelacionGestor
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
        Me.Pnl_Header = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_Id = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_Grid = New DevExpress.XtraEditors.PanelControl()
        Me.DGrid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.Pnl_Header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Header.SuspendLayout()
        CType(Me.Txt_Id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Grid.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Header
        '
        Me.Pnl_Header.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Pnl_Header.Controls.Add(Me.Txt_Id)
        Me.Pnl_Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pnl_Header.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Header.Name = "Pnl_Header"
        Me.Pnl_Header.Size = New System.Drawing.Size(572, 41)
        Me.Pnl_Header.TabIndex = 1
        '
        'Txt_Id
        '
        Me.Txt_Id.Location = New System.Drawing.Point(47, 12)
        Me.Txt_Id.Name = "Txt_Id"
        Me.Txt_Id.Size = New System.Drawing.Size(200, 20)
        Me.Txt_Id.TabIndex = 1
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Pnl_Grid.Controls.Add(Me.DGrid)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 41)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(572, 374)
        Me.Pnl_Grid.TabIndex = 2
        '
        'DGrid
        '
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(0, 0)
        Me.DGrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(572, 374)
        Me.DGrid.TabIndex = 2
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        '
        'frmRelacionGestor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 415)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Header)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelacionGestor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Empleado y Promotor Externo"
        CType(Me.Pnl_Header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Header.ResumeLayout(False)
        CType(Me.Txt_Id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Grid.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pnl_Header As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_Id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Pnl_Grid As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
