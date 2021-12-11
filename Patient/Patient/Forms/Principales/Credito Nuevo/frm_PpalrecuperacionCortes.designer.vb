<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_PpalrecuperacionCortes
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
        Me.Grido = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CB_año = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.P2 = New System.Windows.Forms.Panel()
        Me.P1 = New System.Windows.Forms.Panel()
        Me.Btn_rf = New System.Windows.Forms.Button()
        Me.Btn_ex = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SFdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grido
        '
        Me.Grido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Grido.Location = New System.Drawing.Point(0, 0)
        Me.Grido.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Grido.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Grido.MainView = Me.GridView1
        Me.Grido.Name = "Grido"
        Me.Grido.Size = New System.Drawing.Size(1190, 373)
        Me.Grido.TabIndex = 8
        Me.Grido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Grido
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'CB_año
        '
        Me.CB_año.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CB_año.FormattingEnabled = True
        Me.CB_año.Location = New System.Drawing.Point(941, 21)
        Me.CB_año.Name = "CB_año"
        Me.CB_año.Size = New System.Drawing.Size(59, 21)
        Me.CB_año.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Btn_Salir)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.P2)
        Me.Panel1.Controls.Add(Me.P1)
        Me.Panel1.Controls.Add(Me.Btn_rf)
        Me.Panel1.Controls.Add(Me.Btn_ex)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CB_año)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1190, 61)
        Me.Panel1.TabIndex = 9
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Salir.AutoSize = True
        Me.Btn_Salir.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Salir.Location = New System.Drawing.Point(1133, 2)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(54, 54)
        Me.Btn_Salir.TabIndex = 14
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Cartera Vencida"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cartera Fresca"
        '
        'P2
        '
        Me.P2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.P2.Location = New System.Drawing.Point(10, 34)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(20, 19)
        Me.P2.TabIndex = 11
        '
        'P1
        '
        Me.P1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.P1.Location = New System.Drawing.Point(10, 9)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(20, 19)
        Me.P1.TabIndex = 10
        '
        'Btn_rf
        '
        Me.Btn_rf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_rf.AutoSize = True
        Me.Btn_rf.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_rf.Location = New System.Drawing.Point(1024, 2)
        Me.Btn_rf.Name = "Btn_rf"
        Me.Btn_rf.Size = New System.Drawing.Size(54, 54)
        Me.Btn_rf.TabIndex = 4
        Me.Btn_rf.UseVisualStyleBackColor = True
        '
        'Btn_ex
        '
        Me.Btn_ex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_ex.AutoSize = True
        Me.Btn_ex.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_ex.Location = New System.Drawing.Point(1079, 2)
        Me.Btn_ex.Name = "Btn_ex"
        Me.Btn_ex.Size = New System.Drawing.Size(54, 54)
        Me.Btn_ex.TabIndex = 3
        Me.Btn_ex.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(910, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Año:"
        '
        'SFdRuta
        '
        Me.SFdRuta.FileName = "Libro1"
        Me.SFdRuta.Filter = "Archivos Excel | *.xls"
        '
        'frm_PpalrecuperacionCortes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1190, 436)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Grido)
        Me.KeyPreview = True
        Me.Name = "frm_PpalrecuperacionCortes"
        Me.Text = "frm_PpalrecuperacionCortes"
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CB_año As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_ex As Button
    Friend WithEvents SFdRuta As SaveFileDialog
    Friend WithEvents Btn_rf As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents P2 As Panel
    Friend WithEvents P1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Salir As Button
End Class
