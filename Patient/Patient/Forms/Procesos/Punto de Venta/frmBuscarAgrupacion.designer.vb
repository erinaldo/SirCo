<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarAgrupacion
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txt_Agrupacion = New DevExpress.XtraEditors.TextEdit()
        Me.lbl_Agrupacion = New DevExpress.XtraEditors.LabelControl()
        Me.gc_Agrupacion = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Agrupacion = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txt_Agrupacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Agrupacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Agrupacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Aceptar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 257)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(360, 60)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(299, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(59, 56)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Aceptar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Aceptar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Aceptar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(58, 56)
        Me.btn_Aceptar.TabIndex = 0
        Me.btn_Aceptar.ToolTip = "Aceptar"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txt_Agrupacion)
        Me.PanelControl2.Controls.Add(Me.lbl_Agrupacion)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(360, 41)
        Me.PanelControl2.TabIndex = 1
        '
        'txt_Agrupacion
        '
        Me.txt_Agrupacion.Location = New System.Drawing.Point(66, 10)
        Me.txt_Agrupacion.Name = "txt_Agrupacion"
        Me.txt_Agrupacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Agrupacion.Size = New System.Drawing.Size(153, 20)
        Me.txt_Agrupacion.TabIndex = 1
        '
        'lbl_Agrupacion
        '
        Me.lbl_Agrupacion.Location = New System.Drawing.Point(6, 13)
        Me.lbl_Agrupacion.Name = "lbl_Agrupacion"
        Me.lbl_Agrupacion.Size = New System.Drawing.Size(54, 13)
        Me.lbl_Agrupacion.TabIndex = 0
        Me.lbl_Agrupacion.Text = "Agrupación"
        '
        'gc_Agrupacion
        '
        Me.gc_Agrupacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Agrupacion.Location = New System.Drawing.Point(0, 41)
        Me.gc_Agrupacion.MainView = Me.dgv_Agrupacion
        Me.gc_Agrupacion.Name = "gc_Agrupacion"
        Me.gc_Agrupacion.Size = New System.Drawing.Size(360, 216)
        Me.gc_Agrupacion.TabIndex = 2
        Me.gc_Agrupacion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Agrupacion})
        '
        'dgv_Agrupacion
        '
        Me.dgv_Agrupacion.GridControl = Me.gc_Agrupacion
        Me.dgv_Agrupacion.Name = "dgv_Agrupacion"
        '
        'frmBuscarAgrupacion
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 317)
        Me.Controls.Add(Me.gc_Agrupacion)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBuscarAgrupacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Agrupación"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txt_Agrupacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Agrupacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Agrupacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txt_Agrupacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_Agrupacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gc_Agrupacion As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Agrupacion As DevExpress.XtraGrid.Views.Grid.GridView
End Class
