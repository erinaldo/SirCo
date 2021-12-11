<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoGestoresDeCartera
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
        Me.components = New System.ComponentModel.Container()
        Me.Pnl_Gestor = New DevExpress.XtraEditors.PanelControl()
        Me.Chk_CarteraVencida = New DevExpress.XtraEditors.CheckEdit()
        Me.Chk_CarteraFresca = New DevExpress.XtraEditors.CheckEdit()
        Me.Lbl_Apmaterno = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Apmaterno = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Appaterno = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_id = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_id = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Appaterno = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Nombre = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Nombre = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Pnl_Gestor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Gestor.SuspendLayout()
        CType(Me.Chk_CarteraVencida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chk_CarteraFresca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Apmaterno.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_id.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Appaterno.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Gestor
        '
        Me.Pnl_Gestor.Controls.Add(Me.Chk_CarteraVencida)
        Me.Pnl_Gestor.Controls.Add(Me.Chk_CarteraFresca)
        Me.Pnl_Gestor.Controls.Add(Me.Lbl_Apmaterno)
        Me.Pnl_Gestor.Controls.Add(Me.Txt_Apmaterno)
        Me.Pnl_Gestor.Controls.Add(Me.Lbl_Appaterno)
        Me.Pnl_Gestor.Controls.Add(Me.Lbl_id)
        Me.Pnl_Gestor.Controls.Add(Me.Txt_id)
        Me.Pnl_Gestor.Controls.Add(Me.Txt_Appaterno)
        Me.Pnl_Gestor.Controls.Add(Me.Lbl_Nombre)
        Me.Pnl_Gestor.Controls.Add(Me.Txt_Nombre)
        Me.Pnl_Gestor.Location = New System.Drawing.Point(12, 12)
        Me.Pnl_Gestor.Name = "Pnl_Gestor"
        Me.Pnl_Gestor.Size = New System.Drawing.Size(363, 182)
        Me.Pnl_Gestor.TabIndex = 1
        '
        'Chk_CarteraVencida
        '
        Me.Chk_CarteraVencida.Location = New System.Drawing.Point(184, 141)
        Me.Chk_CarteraVencida.Name = "Chk_CarteraVencida"
        Me.Chk_CarteraVencida.Properties.Caption = "Cartera Vencida"
        Me.Chk_CarteraVencida.Size = New System.Drawing.Size(107, 19)
        Me.Chk_CarteraVencida.TabIndex = 6
        '
        'Chk_CarteraFresca
        '
        Me.Chk_CarteraFresca.Location = New System.Drawing.Point(55, 141)
        Me.Chk_CarteraFresca.Name = "Chk_CarteraFresca"
        Me.Chk_CarteraFresca.Properties.Caption = "Cartera Fresca"
        Me.Chk_CarteraFresca.Size = New System.Drawing.Size(104, 19)
        Me.Chk_CarteraFresca.TabIndex = 5
        '
        'Lbl_Apmaterno
        '
        Me.Lbl_Apmaterno.Location = New System.Drawing.Point(5, 86)
        Me.Lbl_Apmaterno.Name = "Lbl_Apmaterno"
        Me.Lbl_Apmaterno.Size = New System.Drawing.Size(80, 13)
        Me.Lbl_Apmaterno.TabIndex = 4
        Me.Lbl_Apmaterno.Text = "Apellido Materno"
        '
        'Txt_Apmaterno
        '
        Me.Txt_Apmaterno.Enabled = False
        Me.Txt_Apmaterno.Location = New System.Drawing.Point(94, 83)
        Me.Txt_Apmaterno.Name = "Txt_Apmaterno"
        Me.Txt_Apmaterno.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Apmaterno.Properties.Appearance.Options.UseFont = True
        Me.Txt_Apmaterno.Properties.MaxLength = 30
        Me.Txt_Apmaterno.Size = New System.Drawing.Size(229, 20)
        Me.Txt_Apmaterno.TabIndex = 4
        '
        'Lbl_Appaterno
        '
        Me.Lbl_Appaterno.Location = New System.Drawing.Point(5, 60)
        Me.Lbl_Appaterno.Name = "Lbl_Appaterno"
        Me.Lbl_Appaterno.Size = New System.Drawing.Size(78, 13)
        Me.Lbl_Appaterno.TabIndex = 3
        Me.Lbl_Appaterno.Text = "Apellido Paterno"
        '
        'Lbl_id
        '
        Me.Lbl_id.Location = New System.Drawing.Point(5, 8)
        Me.Lbl_id.Name = "Lbl_id"
        Me.Lbl_id.Size = New System.Drawing.Size(10, 13)
        Me.Lbl_id.TabIndex = 1
        Me.Lbl_id.Text = "Id"
        '
        'Txt_id
        '
        Me.Txt_id.Location = New System.Drawing.Point(94, 5)
        Me.Txt_id.Name = "Txt_id"
        Me.Txt_id.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_id.Properties.Appearance.Options.UseFont = True
        Me.Txt_id.Properties.MaxLength = 6
        Me.Txt_id.Size = New System.Drawing.Size(133, 20)
        Me.Txt_id.TabIndex = 1
        '
        'Txt_Appaterno
        '
        Me.Txt_Appaterno.Enabled = False
        Me.Txt_Appaterno.Location = New System.Drawing.Point(94, 57)
        Me.Txt_Appaterno.Name = "Txt_Appaterno"
        Me.Txt_Appaterno.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Appaterno.Properties.Appearance.Options.UseFont = True
        Me.Txt_Appaterno.Properties.MaxLength = 30
        Me.Txt_Appaterno.Size = New System.Drawing.Size(226, 20)
        Me.Txt_Appaterno.TabIndex = 3
        '
        'Lbl_Nombre
        '
        Me.Lbl_Nombre.Location = New System.Drawing.Point(5, 34)
        Me.Lbl_Nombre.Name = "Lbl_Nombre"
        Me.Lbl_Nombre.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Nombre.TabIndex = 2
        Me.Lbl_Nombre.Text = "Nombre"
        '
        'Txt_Nombre
        '
        Me.Txt_Nombre.Enabled = False
        Me.Txt_Nombre.Location = New System.Drawing.Point(94, 31)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nombre.Properties.Appearance.Options.UseFont = True
        Me.Txt_Nombre.Properties.MaxLength = 30
        Me.Txt_Nombre.Size = New System.Drawing.Size(229, 20)
        Me.Txt_Nombre.TabIndex = 2
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.AutoSize = True
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 200)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(363, 58)
        Me.Pnl_Botones.TabIndex = 7
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(259, 2)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Cancelar.TabIndex = 7
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(310, 2)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Aceptar.TabIndex = 8
        '
        'frmCatalogoGestoresDeCartera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 267)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Gestor)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoGestoresDeCartera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cátalogo Gestores de Cartera"
        CType(Me.Pnl_Gestor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Gestor.ResumeLayout(False)
        Me.Pnl_Gestor.PerformLayout()
        CType(Me.Chk_CarteraVencida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chk_CarteraFresca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Apmaterno.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_id.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Appaterno.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Nombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pnl_Gestor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Lbl_Apmaterno As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Apmaterno As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Appaterno As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_id As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_id As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Appaterno As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Nombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Nombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Chk_CarteraVencida As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Chk_CarteraFresca As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ToolTip1 As ToolTip
End Class
