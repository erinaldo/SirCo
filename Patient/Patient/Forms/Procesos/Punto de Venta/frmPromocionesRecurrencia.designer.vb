<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocionesRecurrencia
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
        Me.btn_Eliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Salir = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.txt_HFin = New DevExpress.XtraEditors.TextEdit()
        Me.txt_HInicio = New DevExpress.XtraEditors.TextEdit()
        Me.btn_Guardar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_HFin = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_HInicio = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_Dia = New DevExpress.XtraEditors.LabelControl()
        Me.cbo_Dia = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.gc_Recurrencia = New DevExpress.XtraGrid.GridControl()
        Me.dgv_Recurrencia = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txt_HFin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_HInicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbo_Dia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gc_Recurrencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Recurrencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Eliminar)
        Me.PanelControl1.Controls.Add(Me.btn_Salir)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 245)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(312, 51)
        Me.PanelControl1.TabIndex = 2
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Eliminar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Eliminar.ImageOptions.ImageUri.Uri = "Delete"
        Me.btn_Eliminar.Location = New System.Drawing.Point(2, 2)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(50, 47)
        Me.btn_Eliminar.TabIndex = 0
        Me.btn_Eliminar.ToolTip = "Eliminar"
        '
        'btn_Salir
        '
        Me.btn_Salir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Salir.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.btn_Salir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Salir.Location = New System.Drawing.Point(261, 2)
        Me.btn_Salir.Name = "btn_Salir"
        Me.btn_Salir.Size = New System.Drawing.Size(49, 47)
        Me.btn_Salir.TabIndex = 1
        Me.btn_Salir.ToolTip = "Salir"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.txt_HFin)
        Me.PanelControl2.Controls.Add(Me.txt_HInicio)
        Me.PanelControl2.Controls.Add(Me.btn_Guardar)
        Me.PanelControl2.Controls.Add(Me.lbl_HFin)
        Me.PanelControl2.Controls.Add(Me.lbl_HInicio)
        Me.PanelControl2.Controls.Add(Me.lbl_Dia)
        Me.PanelControl2.Controls.Add(Me.cbo_Dia)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(312, 67)
        Me.PanelControl2.TabIndex = 0
        '
        'txt_HFin
        '
        Me.txt_HFin.Location = New System.Drawing.Point(156, 32)
        Me.txt_HFin.Name = "txt_HFin"
        Me.txt_HFin.Properties.DisplayFormat.FormatString = "HH:mm"
        Me.txt_HFin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txt_HFin.Properties.EditFormat.FormatString = "HH:mm"
        Me.txt_HFin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txt_HFin.Properties.Mask.EditMask = "HH:mm"
        Me.txt_HFin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.txt_HFin.Size = New System.Drawing.Size(37, 20)
        Me.txt_HFin.TabIndex = 2
        '
        'txt_HInicio
        '
        Me.txt_HInicio.Location = New System.Drawing.Point(79, 32)
        Me.txt_HInicio.Name = "txt_HInicio"
        Me.txt_HInicio.Properties.DisplayFormat.FormatString = "HH:mm"
        Me.txt_HInicio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txt_HInicio.Properties.EditFormat.FormatString = "HH:mm"
        Me.txt_HInicio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txt_HInicio.Properties.Mask.EditMask = "HH:mm"
        Me.txt_HInicio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.txt_HInicio.Properties.MaxLength = 5
        Me.txt_HInicio.Size = New System.Drawing.Size(37, 20)
        Me.txt_HInicio.TabIndex = 1
        '
        'btn_Guardar
        '
        Me.btn_Guardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btn_Guardar.ImageOptions.ImageUri.Uri = "Apply"
        Me.btn_Guardar.Location = New System.Drawing.Point(199, 5)
        Me.btn_Guardar.Name = "btn_Guardar"
        Me.btn_Guardar.Size = New System.Drawing.Size(58, 53)
        Me.btn_Guardar.TabIndex = 3
        Me.btn_Guardar.ToolTip = "Guardar"
        '
        'lbl_HFin
        '
        Me.lbl_HFin.Location = New System.Drawing.Point(122, 35)
        Me.lbl_HFin.Name = "lbl_HFin"
        Me.lbl_HFin.Size = New System.Drawing.Size(28, 13)
        Me.lbl_HFin.TabIndex = 3
        Me.lbl_HFin.Text = "Hr Fin"
        '
        'lbl_HInicio
        '
        Me.lbl_HInicio.Location = New System.Drawing.Point(34, 35)
        Me.lbl_HInicio.Name = "lbl_HInicio"
        Me.lbl_HInicio.Size = New System.Drawing.Size(39, 13)
        Me.lbl_HInicio.TabIndex = 2
        Me.lbl_HInicio.Text = "Hr Inicio"
        '
        'lbl_Dia
        '
        Me.lbl_Dia.Location = New System.Drawing.Point(58, 9)
        Me.lbl_Dia.Name = "lbl_Dia"
        Me.lbl_Dia.Size = New System.Drawing.Size(15, 13)
        Me.lbl_Dia.TabIndex = 1
        Me.lbl_Dia.Text = "Día"
        '
        'cbo_Dia
        '
        Me.cbo_Dia.EditValue = "SELECCIONE"
        Me.cbo_Dia.Location = New System.Drawing.Point(79, 6)
        Me.cbo_Dia.Name = "cbo_Dia"
        Me.cbo_Dia.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbo_Dia.Properties.Items.AddRange(New Object() {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"})
        Me.cbo_Dia.Size = New System.Drawing.Size(114, 20)
        Me.cbo_Dia.TabIndex = 0
        '
        'gc_Recurrencia
        '
        Me.gc_Recurrencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gc_Recurrencia.Location = New System.Drawing.Point(0, 67)
        Me.gc_Recurrencia.MainView = Me.dgv_Recurrencia
        Me.gc_Recurrencia.Name = "gc_Recurrencia"
        Me.gc_Recurrencia.Size = New System.Drawing.Size(312, 178)
        Me.gc_Recurrencia.TabIndex = 1
        Me.gc_Recurrencia.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgv_Recurrencia})
        '
        'dgv_Recurrencia
        '
        Me.dgv_Recurrencia.GridControl = Me.gc_Recurrencia
        Me.dgv_Recurrencia.Name = "dgv_Recurrencia"
        '
        'frmPromocionesRecurrencia
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 296)
        Me.Controls.Add(Me.gc_Recurrencia)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPromocionesRecurrencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recurrencia"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txt_HFin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_HInicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbo_Dia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gc_Recurrencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Recurrencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cbo_Dia As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btn_Salir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_HFin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt_HInicio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btn_Guardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbl_HFin As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_HInicio As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Dia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gc_Recurrencia As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgv_Recurrencia As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_Eliminar As DevExpress.XtraEditors.SimpleButton
End Class
