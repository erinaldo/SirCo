<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoCancelarVentas
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Txt_Folio1 = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Distri = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Distri = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Motivo = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Motivo = New DevExpress.XtraEditors.LabelControl()
        Me.Dt_FechaEntrega = New DevExpress.XtraEditors.DateEdit()
        Me.Lbl_FechaEntrega = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_Folio = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Fin = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_AL = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Inicio = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Rango = New DevExpress.XtraEditors.LabelControl()
        Me.Lbl_OpcionesBusqueda = New DevExpress.XtraEditors.LabelControl()
        Me.pnlBotones = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_Limpiar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.Txt_Folio1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Distri.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Motivo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_FechaEntrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt_FechaEntrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Fin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Inicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlBotones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Txt_Folio1)
        Me.PanelControl1.Controls.Add(Me.Txt_Distri)
        Me.PanelControl1.Controls.Add(Me.Lbl_Distri)
        Me.PanelControl1.Controls.Add(Me.Txt_Motivo)
        Me.PanelControl1.Controls.Add(Me.Lbl_Motivo)
        Me.PanelControl1.Controls.Add(Me.Dt_FechaEntrega)
        Me.PanelControl1.Controls.Add(Me.Lbl_FechaEntrega)
        Me.PanelControl1.Controls.Add(Me.Lbl_Folio)
        Me.PanelControl1.Controls.Add(Me.Txt_Fin)
        Me.PanelControl1.Controls.Add(Me.Lbl_AL)
        Me.PanelControl1.Controls.Add(Me.Txt_Inicio)
        Me.PanelControl1.Controls.Add(Me.Lbl_Rango)
        Me.PanelControl1.Controls.Add(Me.Lbl_OpcionesBusqueda)
        Me.PanelControl1.Location = New System.Drawing.Point(71, 12)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(264, 179)
        Me.PanelControl1.TabIndex = 0
        '
        'Txt_Folio1
        '
        Me.Txt_Folio1.EnterMoveNextControl = True
        Me.Txt_Folio1.Location = New System.Drawing.Point(108, 67)
        Me.Txt_Folio1.Name = "Txt_Folio1"
        Me.Txt_Folio1.Size = New System.Drawing.Size(146, 20)
        Me.Txt_Folio1.TabIndex = 2
        '
        'Txt_Distri
        '
        Me.Txt_Distri.EnterMoveNextControl = True
        Me.Txt_Distri.Location = New System.Drawing.Point(71, 117)
        Me.Txt_Distri.Name = "Txt_Distri"
        Me.Txt_Distri.Size = New System.Drawing.Size(183, 20)
        Me.Txt_Distri.TabIndex = 4
        '
        'Lbl_Distri
        '
        Me.Lbl_Distri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Distri.Location = New System.Drawing.Point(5, 121)
        Me.Lbl_Distri.Name = "Lbl_Distri"
        Me.Lbl_Distri.Size = New System.Drawing.Size(58, 13)
        Me.Lbl_Distri.TabIndex = 11
        Me.Lbl_Distri.Text = "Distribuidor:"
        '
        'Txt_Motivo
        '
        Me.Txt_Motivo.EnterMoveNextControl = True
        Me.Txt_Motivo.Location = New System.Drawing.Point(53, 143)
        Me.Txt_Motivo.Name = "Txt_Motivo"
        Me.Txt_Motivo.Size = New System.Drawing.Size(206, 20)
        Me.Txt_Motivo.TabIndex = 5
        '
        'Lbl_Motivo
        '
        Me.Lbl_Motivo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Motivo.Location = New System.Drawing.Point(5, 147)
        Me.Lbl_Motivo.Name = "Lbl_Motivo"
        Me.Lbl_Motivo.Size = New System.Drawing.Size(36, 13)
        Me.Lbl_Motivo.TabIndex = 9
        Me.Lbl_Motivo.Text = "Motivo:"
        '
        'Dt_FechaEntrega
        '
        Me.Dt_FechaEntrega.EditValue = Nothing
        Me.Dt_FechaEntrega.EnterMoveNextControl = True
        Me.Dt_FechaEntrega.Location = New System.Drawing.Point(149, 93)
        Me.Dt_FechaEntrega.Name = "Dt_FechaEntrega"
        Me.Dt_FechaEntrega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_FechaEntrega.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Dt_FechaEntrega.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic
        Me.Dt_FechaEntrega.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.Dt_FechaEntrega.Size = New System.Drawing.Size(105, 20)
        Me.Dt_FechaEntrega.TabIndex = 3
        '
        'Lbl_FechaEntrega
        '
        Me.Lbl_FechaEntrega.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_FechaEntrega.Location = New System.Drawing.Point(5, 98)
        Me.Lbl_FechaEntrega.Name = "Lbl_FechaEntrega"
        Me.Lbl_FechaEntrega.Size = New System.Drawing.Size(137, 13)
        Me.Lbl_FechaEntrega.TabIndex = 7
        Me.Lbl_FechaEntrega.Text = "Fecha de Entrega de Valera:"
        '
        'Lbl_Folio
        '
        Me.Lbl_Folio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Folio.Location = New System.Drawing.Point(5, 72)
        Me.Lbl_Folio.Name = "Lbl_Folio"
        Me.Lbl_Folio.Size = New System.Drawing.Size(74, 13)
        Me.Lbl_Folio.TabIndex = 5
        Me.Lbl_Folio.Text = "Folio de Valera:"
        '
        'Txt_Fin
        '
        Me.Txt_Fin.EnterMoveNextControl = True
        Me.Txt_Fin.Location = New System.Drawing.Point(207, 42)
        Me.Txt_Fin.Name = "Txt_Fin"
        Me.Txt_Fin.Size = New System.Drawing.Size(47, 20)
        Me.Txt_Fin.TabIndex = 1
        '
        'Lbl_AL
        '
        Me.Lbl_AL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_AL.Location = New System.Drawing.Point(174, 45)
        Me.Lbl_AL.Name = "Lbl_AL"
        Me.Lbl_AL.Size = New System.Drawing.Size(8, 13)
        Me.Lbl_AL.TabIndex = 3
        Me.Lbl_AL.Text = "al"
        '
        'Txt_Inicio
        '
        Me.Txt_Inicio.EnterMoveNextControl = True
        Me.Txt_Inicio.Location = New System.Drawing.Point(108, 42)
        Me.Txt_Inicio.Name = "Txt_Inicio"
        Me.Txt_Inicio.Size = New System.Drawing.Size(47, 20)
        Me.Txt_Inicio.TabIndex = 0
        '
        'Lbl_Rango
        '
        Me.Lbl_Rango.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_Rango.Location = New System.Drawing.Point(5, 47)
        Me.Lbl_Rango.Name = "Lbl_Rango"
        Me.Lbl_Rango.Size = New System.Drawing.Size(96, 13)
        Me.Lbl_Rango.TabIndex = 1
        Me.Lbl_Rango.Text = "Rango de Vales Del:"
        '
        'Lbl_OpcionesBusqueda
        '
        Me.Lbl_OpcionesBusqueda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lbl_OpcionesBusqueda.Location = New System.Drawing.Point(5, 5)
        Me.Lbl_OpcionesBusqueda.Name = "Lbl_OpcionesBusqueda"
        Me.Lbl_OpcionesBusqueda.Size = New System.Drawing.Size(113, 13)
        Me.Lbl_OpcionesBusqueda.TabIndex = 0
        Me.Lbl_OpcionesBusqueda.Text = "Opciones de Busqueda:"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btn_Aceptar)
        Me.pnlBotones.Controls.Add(Me.btn_Cancelar)
        Me.pnlBotones.Controls.Add(Me.btn_Limpiar)
        Me.pnlBotones.Location = New System.Drawing.Point(207, 197)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(165, 58)
        Me.pnlBotones.TabIndex = 13
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btn_Aceptar.Location = New System.Drawing.Point(106, 6)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(49, 47)
        Me.btn_Aceptar.TabIndex = 6
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.btn_Cancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btn_Cancelar.Location = New System.Drawing.Point(57, 6)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(47, 47)
        Me.btn_Cancelar.TabIndex = 7
        '
        'btn_Limpiar
        '
        Me.btn_Limpiar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.btn_Limpiar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btn_Limpiar.Location = New System.Drawing.Point(11, 6)
        Me.btn_Limpiar.Name = "btn_Limpiar"
        Me.btn_Limpiar.Size = New System.Drawing.Size(44, 47)
        Me.btn_Limpiar.TabIndex = 8
        '
        'frmCatalogoCancelarVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 255)
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "frmCatalogoCancelarVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Cancelar Vales"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.Txt_Folio1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Distri.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Motivo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_FechaEntrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt_FechaEntrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Fin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Inicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlBotones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Txt_Motivo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Motivo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Dt_FechaEntrega As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Lbl_FechaEntrega As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_Folio As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Fin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_AL As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Inicio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Rango As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Lbl_OpcionesBusqueda As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlBotones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Limpiar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Txt_Distri As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Lbl_Distri As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Folio1 As DevExpress.XtraEditors.TextEdit
End Class
