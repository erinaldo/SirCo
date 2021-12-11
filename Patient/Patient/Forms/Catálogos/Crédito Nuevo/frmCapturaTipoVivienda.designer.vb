<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCapturaTipoVivienda
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
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbl_Observaciones = New DevExpress.XtraEditors.LabelControl()
        Me.lbl_tipoVivienda = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Observaciones = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_tipovivienda = New DevExpress.XtraEditors.TextEdit()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Botones = New DevExpress.XtraEditors.PanelControl()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LimpiarCampos = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Edicion = New DevExpress.XtraEditors.PanelControl()
        CType(Me.Txt_Observaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_tipovivienda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.Pnl_Edicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(97, 5)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(45, 48)
        Me.Btn_Aceptar.TabIndex = 2
        '
        'lbl_Observaciones
        '
        Me.lbl_Observaciones.Location = New System.Drawing.Point(13, 109)
        Me.lbl_Observaciones.Name = "lbl_Observaciones"
        Me.lbl_Observaciones.Size = New System.Drawing.Size(71, 13)
        Me.lbl_Observaciones.TabIndex = 160
        Me.lbl_Observaciones.Text = "Observaciones" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lbl_tipoVivienda
        '
        Me.lbl_tipoVivienda.Location = New System.Drawing.Point(13, 68)
        Me.lbl_tipoVivienda.Name = "lbl_tipoVivienda"
        Me.lbl_tipoVivienda.Size = New System.Drawing.Size(78, 13)
        Me.lbl_tipoVivienda.TabIndex = 159
        Me.lbl_tipoVivienda.Text = "Tipo de Vivienda" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.EnterMoveNextControl = True
        Me.Txt_Observaciones.Location = New System.Drawing.Point(97, 102)
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.Size = New System.Drawing.Size(357, 20)
        Me.Txt_Observaciones.TabIndex = 1
        '
        'Txt_tipovivienda
        '
        Me.Txt_tipovivienda.EnterMoveNextControl = True
        Me.Txt_tipovivienda.Location = New System.Drawing.Point(97, 61)
        Me.Txt_tipovivienda.Name = "Txt_tipovivienda"
        Me.Txt_tipovivienda.Size = New System.Drawing.Size(203, 20)
        Me.Txt_tipovivienda.TabIndex = 0
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_LimpiarCampos)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(1505, 184)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(149, 57)
        Me.Pnl_Botones.TabIndex = 6
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(52, 5)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(44, 48)
        Me.Btn_Cancelar.TabIndex = 3
        '
        'Btn_LimpiarCampos
        '
        Me.Btn_LimpiarCampos.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_LimpiarCampos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_LimpiarCampos.Location = New System.Drawing.Point(6, 5)
        Me.Btn_LimpiarCampos.Name = "Btn_LimpiarCampos"
        Me.Btn_LimpiarCampos.Size = New System.Drawing.Size(45, 48)
        Me.Btn_LimpiarCampos.TabIndex = 4
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.Controls.Add(Me.Txt_tipovivienda)
        Me.Pnl_Edicion.Controls.Add(Me.lbl_Observaciones)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Observaciones)
        Me.Pnl_Edicion.Controls.Add(Me.lbl_tipoVivienda)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 12)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(553, 163)
        Me.Pnl_Edicion.TabIndex = 161
        '
        'frmCapturaTipoVivienda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 248)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Name = "frmCapturaTipoVivienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Tipo de Vivienda"
        CType(Me.Txt_Observaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_tipovivienda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pnl_Botones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.Pnl_Edicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Txt_Observaciones As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_tipovivienda As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbl_tipoVivienda As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Observaciones As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Pnl_Botones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_LimpiarCampos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Pnl_Edicion As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
End Class
