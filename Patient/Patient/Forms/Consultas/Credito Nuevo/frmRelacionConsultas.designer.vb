<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelacionConsultas
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtBuscar = New DevExpress.XtraEditors.TextEdit()
        Me.LblBuscar = New System.Windows.Forms.Label()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.TxtBuscar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGrid
        '
        Me.DGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGrid.Location = New System.Drawing.Point(2, 2)
        Me.DGrid.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DGrid.LookAndFeel.UseDefaultLookAndFeel = False
        Me.DGrid.MainView = Me.GridView1
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(556, 393)
        Me.DGrid.TabIndex = 0
        Me.DGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.DGrid
        Me.GridView1.Name = "GridView1"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.LblBuscar)
        Me.PanelControl1.Controls.Add(Me.TxtBuscar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(560, 41)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DGrid)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 41)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(560, 397)
        Me.PanelControl2.TabIndex = 2
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(69, 12)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscar.Properties.Appearance.Options.UseFont = True
        Me.TxtBuscar.Size = New System.Drawing.Size(211, 20)
        Me.TxtBuscar.TabIndex = 0
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Location = New System.Drawing.Point(24, 15)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(39, 13)
        Me.LblBuscar.TabIndex = 1
        Me.LblBuscar.Text = "Buscar"
        '
        'frmRelacionConsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 438)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmRelacionConsultas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Relación"
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.TxtBuscar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LblBuscar As Label
    Friend WithEvents TxtBuscar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
End Class
