<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodoPresupuesto
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
        Me.btn_Nuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.cbo_Año = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbo_Mes = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cbo_Año.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Mes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Controls.Add(Me.btn_Nuevo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 82)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(255, 58)
        Me.PanelControl1.TabIndex = 2
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(204, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(49, 54)
        Me.btn_Salir.TabIndex = 3
        Me.btn_Salir.ToolTip = "Salir"
        '
        'btn_Nuevo
        '
        Me.btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Nuevo.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Nuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Nuevo.ImageOptions.ImageUri.Uri = "AddItem"
        Me.btn_Nuevo.Location = New System.Drawing.Point(2, 2)
        Me.btn_Nuevo.Name = "btn_Nuevo"
        Me.btn_Nuevo.Size = New System.Drawing.Size(56, 54)
        Me.btn_Nuevo.TabIndex = 0
        Me.btn_Nuevo.ToolTip = "Nuevo"
        '
        'cbo_Año
        '
        Me.cbo_Año.Location = New System.Drawing.Point(74, 13)
        Me.cbo_Año.Name = "cbo_Año"
        Me.cbo_Año.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Año.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbo_Año.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Año.TabIndex = 3
        '
        'cbo_Mes
        '
        Me.cbo_Mes.Location = New System.Drawing.Point(74, 39)
        Me.cbo_Mes.Name = "cbo_Mes"
        Me.cbo_Mes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Mes.Properties.Items.AddRange(New Object() {"01-Enero", "02-Febrero", "03-Marzo", "04-Abril", "05-Mayo", "06-Junio", "07-Julio", "08-Agosto", "09-Septiembre", "10-Octubre", "11-Noviembre", "12-Diciembre"})
        Me.cbo_Mes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbo_Mes.Size = New System.Drawing.Size(100, 20)
        Me.cbo_Mes.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(49, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Año"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(49, 42)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Mes"
        '
        'frmPeriodoPresupuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(255, 140)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cbo_Mes)
        Me.Controls.Add(Me.cbo_Año)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPeriodoPresupuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodo Presupuesto"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.cbo_Año.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Mes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Nuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbo_Año As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbo_Mes As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
