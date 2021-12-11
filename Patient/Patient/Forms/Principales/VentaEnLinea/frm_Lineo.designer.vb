<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Lineo
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_ex = New System.Windows.Forms.Button()
        Me.Btn_rfsh = New System.Windows.Forms.Button()
        Me.Btn_excel = New System.Windows.Forms.Button()
        Me.SFdRuta = New System.Windows.Forms.SaveFileDialog()
        Me.Grido = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Btn_ex)
        Me.Panel1.Controls.Add(Me.Btn_rfsh)
        Me.Panel1.Controls.Add(Me.Btn_excel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 394)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 56)
        Me.Panel1.TabIndex = 3
        '
        'Btn_ex
        '
        Me.Btn_ex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_ex.Image = Global.SIRCO.My.Resources.Resources.arrow_left
        Me.Btn_ex.Location = New System.Drawing.Point(635, 0)
        Me.Btn_ex.Name = "Btn_ex"
        Me.Btn_ex.Size = New System.Drawing.Size(52, 52)
        Me.Btn_ex.TabIndex = 2
        Me.Btn_ex.UseVisualStyleBackColor = True
        '
        'Btn_rfsh
        '
        Me.Btn_rfsh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_rfsh.Image = Global.SIRCO.My.Resources.Resources.database_refresh
        Me.Btn_rfsh.Location = New System.Drawing.Point(688, 1)
        Me.Btn_rfsh.Name = "Btn_rfsh"
        Me.Btn_rfsh.Size = New System.Drawing.Size(52, 52)
        Me.Btn_rfsh.TabIndex = 1
        Me.Btn_rfsh.UseVisualStyleBackColor = True
        '
        'Btn_excel
        '
        Me.Btn_excel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_excel.Image = Global.SIRCO.My.Resources.Resources.table_excel
        Me.Btn_excel.Location = New System.Drawing.Point(741, 1)
        Me.Btn_excel.Name = "Btn_excel"
        Me.Btn_excel.Size = New System.Drawing.Size(52, 52)
        Me.Btn_excel.TabIndex = 0
        Me.Btn_excel.UseVisualStyleBackColor = True
        '
        'SFdRuta
        '
        Me.SFdRuta.FileName = "Lirbo1"
        Me.SFdRuta.Filter = "Archivos Excel | *.xlsx"
        '
        'Grido
        '
        Me.Grido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Grido.Location = New System.Drawing.Point(0, 0)
        Me.Grido.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Grido.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Grido.MainView = Me.GridView1
        Me.Grido.Name = "Grido"
        Me.Grido.Size = New System.Drawing.Size(800, 394)
        Me.Grido.TabIndex = 8
        Me.Grido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.ActiveFilterEnabled = False
        Me.GridView1.GridControl = Me.Grido
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.BestFitMaxRowCount = 12
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'frm_Lineo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Grido)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "frm_Lineo"
        Me.Text = "frm_Lineo"
        Me.Panel1.ResumeLayout(False)
        CType(Me.Grido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btn_excel As Button
    Friend WithEvents SFdRuta As SaveFileDialog
    Friend WithEvents Grido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Btn_rfsh As Button
    Friend WithEvents Btn_ex As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
