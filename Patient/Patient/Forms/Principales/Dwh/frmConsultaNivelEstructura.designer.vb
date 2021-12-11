<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaNivelEstructura
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
        Me.btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.gc_NivelEstructura = New DevExpress.XtraGrid.GridControl()
        Me.dgv_NivelEstructura = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gc_Id = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Clave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gc_Descrip = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.gc_NivelEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_NivelEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Aceptar)
        Me.PanelControl1.Controls.Add(Me.btn_Cancelar)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 374)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(403, 61)
        Me.PanelControl1.TabIndex = 0
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Aceptar.Location = New System.Drawing.Point(279, 2)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(61, 57)
        Me.btn_Aceptar.TabIndex = 1
        Me.btn_Aceptar.ToolTip = "Aceptar"
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Cancelar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Cancelar.Location = New System.Drawing.Point(340, 2)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(61, 57)
        Me.btn_Cancelar.TabIndex = 0
        Me.btn_Cancelar.ToolTip = "Cancelar"
        '
        'gc_NivelEstructura
        '
        Me.gc_NivelEstructura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_NivelEstructura.Location = New System.Drawing.Point(0, 0)
        Me.gc_NivelEstructura.MainView = Me.dgv_NivelEstructura
        Me.gc_NivelEstructura.Name = "gc_NivelEstructura"
        Me.gc_NivelEstructura.Size = New System.Drawing.Size(403, 374)
        Me.gc_NivelEstructura.TabIndex = 1
        Me.gc_NivelEstructura.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_NivelEstructura})
        '
        'dgv_NivelEstructura
        '
        Me.dgv_NivelEstructura.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gc_Id, Me.gc_Clave, Me.gc_Descrip})
        Me.dgv_NivelEstructura.GridControl = Me.gc_NivelEstructura
        Me.dgv_NivelEstructura.Name = "dgv_NivelEstructura"
        Me.dgv_NivelEstructura.OptionsBehavior.Editable = False
        Me.dgv_NivelEstructura.OptionsView.ShowAutoFilterRow = True
        '
        'gc_Id
        '
        Me.gc_Id.Caption = "Id"
        Me.gc_Id.FieldName = "id"
        Me.gc_Id.Name = "gc_Id"
        '
        'gc_Clave
        '
        Me.gc_Clave.Caption = "Clave"
        Me.gc_Clave.FieldName = "clave"
        Me.gc_Clave.Name = "gc_Clave"
        Me.gc_Clave.Visible = True
        Me.gc_Clave.VisibleIndex = 0
        '
        'gc_Descrip
        '
        Me.gc_Descrip.Caption = "Descrip"
        Me.gc_Descrip.FieldName = "descrip"
        Me.gc_Descrip.Name = "gc_Descrip"
        Me.gc_Descrip.Visible = True
        Me.gc_Descrip.VisibleIndex = 1
        '
        'frmConsultaNivelEstructura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 435)
        Me.Controls.Add(Me.gc_NivelEstructura)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmConsultaNivelEstructura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.gc_NivelEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_NivelEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents gc_NivelEstructura As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_NivelEstructura As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gc_Id As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Clave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gc_Descrip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancelar As DevExpress.XtraEditors.SimpleButton
End Class
