<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCatalogosNegExternos
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
        Me.pnlBotones = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_Acepta = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Limpia = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Componentes = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Descripcion1 = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Negocio1 = New DevExpress.XtraEditors.TextEdit()
        CType(Me.pnlBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        CType(Me.Pnl_Componentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Componentes.SuspendLayout()
        CType(Me.Txt_Descripcion1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Negocio1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Btn_Acepta)
        Me.pnlBotones.Controls.Add(Me.Btn_Cancelar)
        Me.pnlBotones.Controls.Add(Me.Btn_Limpia)
        Me.pnlBotones.Location = New System.Drawing.Point(130, 139)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(153, 59)
        Me.pnlBotones.TabIndex = 13
        '
        'Btn_Acepta
        '
        Me.Btn_Acepta.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Acepta.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Acepta.Location = New System.Drawing.Point(103, 5)
        Me.Btn_Acepta.Name = "Btn_Acepta"
        Me.Btn_Acepta.Size = New System.Drawing.Size(43, 49)
        Me.Btn_Acepta.TabIndex = 12
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(57, 5)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(44, 48)
        Me.Btn_Cancelar.TabIndex = 9
        '
        'Btn_Limpia
        '
        Me.Btn_Limpia.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpia.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Limpia.Location = New System.Drawing.Point(9, 5)
        Me.Btn_Limpia.Name = "Btn_Limpia"
        Me.Btn_Limpia.Size = New System.Drawing.Size(46, 48)
        Me.Btn_Limpia.TabIndex = 10
        '
        'Pnl_Componentes
        '
        Me.Pnl_Componentes.Controls.Add(Me.LabelControl2)
        Me.Pnl_Componentes.Controls.Add(Me.LabelControl1)
        Me.Pnl_Componentes.Controls.Add(Me.Txt_Descripcion1)
        Me.Pnl_Componentes.Controls.Add(Me.Txt_Negocio1)
        Me.Pnl_Componentes.Location = New System.Drawing.Point(12, 12)
        Me.Pnl_Componentes.Name = "Pnl_Componentes"
        Me.Pnl_Componentes.Size = New System.Drawing.Size(270, 124)
        Me.Pnl_Componentes.TabIndex = 14
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(23, 56)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Descripción"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(23, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Negocio"
        '
        'Txt_Descripcion1
        '
        Me.Txt_Descripcion1.EnterMoveNextControl = True
        Me.Txt_Descripcion1.Location = New System.Drawing.Point(84, 51)
        Me.Txt_Descripcion1.Name = "Txt_Descripcion1"
        Me.Txt_Descripcion1.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Descripcion1.TabIndex = 1
        '
        'Txt_Negocio1
        '
        Me.Txt_Negocio1.EnterMoveNextControl = True
        Me.Txt_Negocio1.Location = New System.Drawing.Point(84, 25)
        Me.Txt_Negocio1.Name = "Txt_Negocio1"
        Me.Txt_Negocio1.Properties.MaxLength = 2
        Me.Txt_Negocio1.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Negocio1.TabIndex = 0
        '
        'frmCatalogosNegExternos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 201)
        Me.Controls.Add(Me.Pnl_Componentes)
        Me.Controls.Add(Me.pnlBotones)
        Me.Name = "frmCatalogosNegExternos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Negocios Externos"
        CType(Me.pnlBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        CType(Me.Pnl_Componentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Componentes.ResumeLayout(False)
        Me.Pnl_Componentes.PerformLayout()
        CType(Me.Txt_Descripcion1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Negocio1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Limpia As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Acepta As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Pnl_Componentes As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Descripcion1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Negocio1 As DevExpress.XtraEditors.TextEdit
End Class
