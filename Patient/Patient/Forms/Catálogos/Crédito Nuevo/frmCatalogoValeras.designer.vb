<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoValeras
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
        Me.Pnl_Valera = New DevExpress.XtraEditors.PanelControl()
        Me.Lbl_Valera = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Valera = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_FechaEntrega = New DevExpress.XtraEditors.LabelControl()
        Me.Dt_Entrega = New DevExpress.XtraEditors.DateEdit()
        Me.Lbl_Recoge = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Recoge = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_ValeHasta = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_ValeDesde = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_NombreDistrib = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Distribuidor = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_idDistrib = New DevExpress.XtraEditors.TextEdit()
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.Pnl_Valera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Valera.SuspendLayout()
        CType(Me.Txt_Valera.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_Entrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_Entrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Recoge.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ValeHasta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_ValeDesde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_NombreDistrib.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_idDistrib.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Valera
        '
        Me.Pnl_Valera.Controls.Add(Me.Lbl_Valera)
        Me.Pnl_Valera.Controls.Add(Me.Txt_Valera)
        Me.Pnl_Valera.Controls.Add(Me.Lbl_FechaEntrega)
        Me.Pnl_Valera.Controls.Add(Me.Dt_Entrega)
        Me.Pnl_Valera.Controls.Add(Me.Lbl_Recoge)
        Me.Pnl_Valera.Controls.Add(Me.Txt_Recoge)
        Me.Pnl_Valera.Controls.Add(Me.LabelControl2)
        Me.Pnl_Valera.Controls.Add(Me.Txt_ValeHasta)
        Me.Pnl_Valera.Controls.Add(Me.LabelControl1)
        Me.Pnl_Valera.Controls.Add(Me.Txt_ValeDesde)
        Me.Pnl_Valera.Controls.Add(Me.Txt_NombreDistrib)
        Me.Pnl_Valera.Controls.Add(Me.Lbl_Distribuidor)
        Me.Pnl_Valera.Controls.Add(Me.Txt_idDistrib)
        Me.Pnl_Valera.Location = New System.Drawing.Point(12, 12)
        Me.Pnl_Valera.Name = "Pnl_Valera"
        Me.Pnl_Valera.Size = New System.Drawing.Size(479, 144)
        Me.Pnl_Valera.TabIndex = 1
        '
        'Lbl_Valera
        '
        Me.Lbl_Valera.Location = New System.Drawing.Point(5, 8)
        Me.Lbl_Valera.Name = "Lbl_Valera"
        Me.Lbl_Valera.Size = New System.Drawing.Size(30, 13)
        Me.Lbl_Valera.TabIndex = 1
        Me.Lbl_Valera.Text = "Valera"
        '
        'Txt_Valera
        '
        Me.Txt_Valera.Location = New System.Drawing.Point(75, 5)
        Me.Txt_Valera.Name = "Txt_Valera"
        Me.Txt_Valera.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Valera.Properties.Appearance.Options.UseFont = True
        Me.Txt_Valera.Properties.MaxLength = 14
        Me.Txt_Valera.Size = New System.Drawing.Size(133, 20)
        Me.Txt_Valera.TabIndex = 1
        '
        'Lbl_FechaEntrega
        '
        Me.Lbl_FechaEntrega.Location = New System.Drawing.Point(5, 83)
        Me.Lbl_FechaEntrega.Name = "Lbl_FechaEntrega"
        Me.Lbl_FechaEntrega.Size = New System.Drawing.Size(85, 13)
        Me.Lbl_FechaEntrega.TabIndex = 6
        Me.Lbl_FechaEntrega.Text = "Fecha de entrega"
        '
        'Dt_Entrega
        '
        Me.Dt_Entrega.EditValue = Nothing
        Me.Dt_Entrega.EnterMoveNextControl = True
        Me.Dt_Entrega.Location = New System.Drawing.Point(96, 83)
        Me.Dt_Entrega.Name = "Dt_Entrega"
        Me.Dt_Entrega.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Dt_Entrega.Properties.Appearance.Options.UseFont = True
        Me.Dt_Entrega.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.Dt_Entrega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_Entrega.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_Entrega.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d"
        Me.Dt_Entrega.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Dt_Entrega.Properties.MaxLength = 3
        Me.Dt_Entrega.Size = New System.Drawing.Size(153, 20)
        Me.Dt_Entrega.TabIndex = 6
        '
        'Lbl_Recoge
        '
        Me.Lbl_Recoge.Location = New System.Drawing.Point(5, 112)
        Me.Lbl_Recoge.Name = "Lbl_Recoge"
        Me.Lbl_Recoge.Size = New System.Drawing.Size(36, 13)
        Me.Lbl_Recoge.TabIndex = 7
        Me.Lbl_Recoge.Text = "Recoge"
        '
        'Txt_Recoge
        '
        Me.Txt_Recoge.Location = New System.Drawing.Point(75, 109)
        Me.Txt_Recoge.Name = "Txt_Recoge"
        Me.Txt_Recoge.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Recoge.Properties.Appearance.Options.UseFont = True
        Me.Txt_Recoge.Properties.MaxLength = 150
        Me.Txt_Recoge.Size = New System.Drawing.Size(316, 20)
        Me.Txt_Recoge.TabIndex = 7
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(219, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Hasta"
        '
        'Txt_ValeHasta
        '
        Me.Txt_ValeHasta.Location = New System.Drawing.Point(253, 57)
        Me.Txt_ValeHasta.Name = "Txt_ValeHasta"
        Me.Txt_ValeHasta.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValeHasta.Properties.Appearance.Options.UseFont = True
        Me.Txt_ValeHasta.Properties.MaxLength = 14
        Me.Txt_ValeHasta.Size = New System.Drawing.Size(133, 20)
        Me.Txt_ValeHasta.TabIndex = 5
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 60)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Desde el Vale "
        '
        'Txt_ValeDesde
        '
        Me.Txt_ValeDesde.Location = New System.Drawing.Point(75, 57)
        Me.Txt_ValeDesde.Name = "Txt_ValeDesde"
        Me.Txt_ValeDesde.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ValeDesde.Properties.Appearance.Options.UseFont = True
        Me.Txt_ValeDesde.Properties.MaxLength = 14
        Me.Txt_ValeDesde.Size = New System.Drawing.Size(133, 20)
        Me.Txt_ValeDesde.TabIndex = 4
        '
        'Txt_NombreDistrib
        '
        Me.Txt_NombreDistrib.Enabled = False
        Me.Txt_NombreDistrib.Location = New System.Drawing.Point(167, 31)
        Me.Txt_NombreDistrib.Name = "Txt_NombreDistrib"
        Me.Txt_NombreDistrib.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreDistrib.Properties.Appearance.Options.UseFont = True
        Me.Txt_NombreDistrib.Properties.MaxLength = 250
        Me.Txt_NombreDistrib.Size = New System.Drawing.Size(293, 20)
        Me.Txt_NombreDistrib.TabIndex = 3
        '
        'Lbl_Distribuidor
        '
        Me.Lbl_Distribuidor.Location = New System.Drawing.Point(5, 34)
        Me.Lbl_Distribuidor.Name = "Lbl_Distribuidor"
        Me.Lbl_Distribuidor.Size = New System.Drawing.Size(54, 13)
        Me.Lbl_Distribuidor.TabIndex = 2
        Me.Lbl_Distribuidor.Text = "Distribuidor"
        '
        'Txt_idDistrib
        '
        Me.Txt_idDistrib.Location = New System.Drawing.Point(75, 31)
        Me.Txt_idDistrib.Name = "Txt_idDistrib"
        Me.Txt_idDistrib.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_idDistrib.Properties.Appearance.Options.UseFont = True
        Me.Txt_idDistrib.Properties.MaxLength = 6
        Me.Txt_idDistrib.Size = New System.Drawing.Size(86, 20)
        Me.Txt_idDistrib.TabIndex = 2
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.AutoSize = True
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 162)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(479, 58)
        Me.Pnl_Botones.TabIndex = 8
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(375, 2)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Cancelar.TabIndex = 8
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(426, 2)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 54)
        Me.Btn_Aceptar.TabIndex = 9
        '
        'frmCatalogoValeras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 230)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Valera)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoValeras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo  Entrega de Valeras"
        CType(Me.Pnl_Valera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Valera.ResumeLayout(False)
        Me.Pnl_Valera.PerformLayout()
        CType(Me.Txt_Valera.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_Entrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_Entrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Recoge.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ValeHasta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_ValeDesde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_NombreDistrib.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_idDistrib.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pnl_Valera As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Lbl_Distribuidor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_idDistrib As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_NombreDistrib As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ValeHasta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_ValeDesde As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Recoge As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Recoge As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_FechaEntrega As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Dt_Entrega As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Lbl_Valera As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Valera As DevExpress.XtraEditors.TextEdit
End Class
