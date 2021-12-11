Imports DevExpress
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDistribInfo
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
        Me.Grido = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Pnl_Edicion = New DevExpress.XtraEditors.PanelControl()
        Me.Cb_Año = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SFDRuta = New System.Windows.Forms.SaveFileDialog()
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Edicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grido
        '
        Me.Grido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grido.Location = New System.Drawing.Point(0, -3)
        Me.Grido.MainView = Me.GridView1
        Me.Grido.Name = "Grido"
        Me.Grido.Size = New System.Drawing.Size(833, 438)
        Me.Grido.TabIndex = 93
        Me.Grido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Grido
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.Controls.Add(Me.Cb_Año)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Button3)
        Me.Pnl_Edicion.Controls.Add(Me.Button2)
        Me.Pnl_Edicion.Controls.Add(Me.Button1)
        Me.Pnl_Edicion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Edicion.Location = New System.Drawing.Point(0, 439)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(833, 56)
        Me.Pnl_Edicion.TabIndex = 94
        '
        'Cb_Año
        '
        Me.Cb_Año.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cb_Año.FormattingEnabled = True
        Me.Cb_Año.Location = New System.Drawing.Point(573, 19)
        Me.Cb_Año.Name = "Cb_Año"
        Me.Cb_Año.Size = New System.Drawing.Size(83, 21)
        Me.Cb_Año.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(541, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Año"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Button3.Location = New System.Drawing.Point(678, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(51, 52)
        Me.Button3.TabIndex = 8
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Button2.Location = New System.Drawing.Point(729, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(51, 52)
        Me.Button2.TabIndex = 7
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Button1.Location = New System.Drawing.Point(780, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 52)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SFDRuta
        '
        Me.SFDRuta.Filter = "Archivos Excel | .xls"
        '
        'frmDistribInfo
        '
        Me.ClientSize = New System.Drawing.Size(833, 495)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Grido)
        Me.Name = "frmDistribInfo"
        Me.Text = "Info Distrib"
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Edicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Excel As Button
    Friend WithEvents Btn_Refrescar As Button
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Grido As XtraGrid.GridControl
    Friend WithEvents GridView1 As XtraGrid.Views.Grid.GridView
    Friend WithEvents Pnl_Edicion As XtraEditors.PanelControl
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Cb_Año As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SFDRuta As SaveFileDialog
End Class
