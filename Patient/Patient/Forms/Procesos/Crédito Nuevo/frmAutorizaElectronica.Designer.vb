<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAutorizaElectronica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizaElectronica))
        Me.Txt_DistribNuevo = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_DistribNombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.Dt_FecAlta = New DevExpress.XtraEditors.DateEdit()
        Me.Opt_Acepta = New System.Windows.Forms.RadioButton()
        Me.Opt_NoAcepta = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txt_LimiteValeNuevo = New System.Windows.Forms.TextBox()
        Me.Txt_LimiteCreditoNuevo = New System.Windows.Forms.TextBox()
        Me.Txt_LimiteVale = New System.Windows.Forms.TextBox()
        Me.Txt_LimiteCredito = New System.Windows.Forms.TextBox()
        Me.Txt_Saldo = New System.Windows.Forms.TextBox()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_DisponibleNuevo = New System.Windows.Forms.MaskedTextBox()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.Txt_Disponible = New System.Windows.Forms.MaskedTextBox()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Opt_NoPromo = New System.Windows.Forms.RadioButton()
        Me.Opt_SiPromo = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_DistribNuevo
        '
        Me.Txt_DistribNuevo.Location = New System.Drawing.Point(94, 32)
        Me.Txt_DistribNuevo.Name = "Txt_DistribNuevo"
        Me.Txt_DistribNuevo.Size = New System.Drawing.Size(79, 20)
        Me.Txt_DistribNuevo.TabIndex = 0
        '
        'Txt_DistribNombre
        '
        Me.Txt_DistribNombre.Location = New System.Drawing.Point(179, 32)
        Me.Txt_DistribNombre.Name = "Txt_DistribNombre"
        Me.Txt_DistribNombre.Size = New System.Drawing.Size(362, 20)
        Me.Txt_DistribNombre.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(19, 35)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "Distribuidor"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 77)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "Fecha Alta"
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(702, 352)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(58, 46)
        Me.Btn_Aceptar.TabIndex = 8
        Me.Btn_Aceptar.ToolTip = "Aplicar Cambios en el Cargo"
        '
        'Dt_FecAlta
        '
        Me.Dt_FecAlta.EditValue = Nothing
        Me.Dt_FecAlta.Enabled = False
        Me.Dt_FecAlta.Location = New System.Drawing.Point(94, 74)
        Me.Dt_FecAlta.Name = "Dt_FecAlta"
        Me.Dt_FecAlta.Size = New System.Drawing.Size(100, 20)
        Me.Dt_FecAlta.TabIndex = 49
        '
        'Opt_Acepta
        '
        Me.Opt_Acepta.AutoSize = True
        Me.Opt_Acepta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Acepta.Location = New System.Drawing.Point(19, 128)
        Me.Opt_Acepta.Name = "Opt_Acepta"
        Me.Opt_Acepta.Size = New System.Drawing.Size(161, 19)
        Me.Opt_Acepta.TabIndex = 1
        Me.Opt_Acepta.TabStop = True
        Me.Opt_Acepta.Text = "SI Acepta Electrónica"
        Me.Opt_Acepta.UseVisualStyleBackColor = True
        '
        'Opt_NoAcepta
        '
        Me.Opt_NoAcepta.AutoSize = True
        Me.Opt_NoAcepta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_NoAcepta.Location = New System.Drawing.Point(205, 128)
        Me.Opt_NoAcepta.Name = "Opt_NoAcepta"
        Me.Opt_NoAcepta.Size = New System.Drawing.Size(168, 19)
        Me.Opt_NoAcepta.TabIndex = 2
        Me.Opt_NoAcepta.TabStop = True
        Me.Opt_NoAcepta.Text = "NO Acepta Electrónica"
        Me.Opt_NoAcepta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Txt_LimiteValeNuevo)
        Me.Panel1.Controls.Add(Me.Txt_LimiteCreditoNuevo)
        Me.Panel1.Controls.Add(Me.Txt_LimiteVale)
        Me.Panel1.Controls.Add(Me.Txt_LimiteCredito)
        Me.Panel1.Controls.Add(Me.Txt_Saldo)
        Me.Panel1.Controls.Add(Me.LabelControl9)
        Me.Panel1.Controls.Add(Me.LabelControl10)
        Me.Panel1.Controls.Add(Me.LabelControl7)
        Me.Panel1.Controls.Add(Me.Txt_DisponibleNuevo)
        Me.Panel1.Controls.Add(Me.LabelControl8)
        Me.Panel1.Controls.Add(Me.Txt_Disponible)
        Me.Panel1.Controls.Add(Me.LabelControl6)
        Me.Panel1.Controls.Add(Me.LabelControl4)
        Me.Panel1.Controls.Add(Me.LabelControl2)
        Me.Panel1.Controls.Add(Me.LabelControl1)
        Me.Panel1.Controls.Add(Me.Cbo_Estatus)
        Me.Panel1.Location = New System.Drawing.Point(12, 159)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 187)
        Me.Panel1.TabIndex = 52
        '
        'Txt_LimiteValeNuevo
        '
        Me.Txt_LimiteValeNuevo.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_LimiteValeNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteValeNuevo.Location = New System.Drawing.Point(368, 91)
        Me.Txt_LimiteValeNuevo.Name = "Txt_LimiteValeNuevo"
        Me.Txt_LimiteValeNuevo.Size = New System.Drawing.Size(121, 20)
        Me.Txt_LimiteValeNuevo.TabIndex = 7
        Me.Txt_LimiteValeNuevo.Text = "0"
        Me.Txt_LimiteValeNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_LimiteCreditoNuevo
        '
        Me.Txt_LimiteCreditoNuevo.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_LimiteCreditoNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteCreditoNuevo.Location = New System.Drawing.Point(368, 65)
        Me.Txt_LimiteCreditoNuevo.Name = "Txt_LimiteCreditoNuevo"
        Me.Txt_LimiteCreditoNuevo.Size = New System.Drawing.Size(121, 20)
        Me.Txt_LimiteCreditoNuevo.TabIndex = 6
        Me.Txt_LimiteCreditoNuevo.Text = "0"
        Me.Txt_LimiteCreditoNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_LimiteVale
        '
        Me.Txt_LimiteVale.Enabled = False
        Me.Txt_LimiteVale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteVale.Location = New System.Drawing.Point(76, 92)
        Me.Txt_LimiteVale.Name = "Txt_LimiteVale"
        Me.Txt_LimiteVale.Size = New System.Drawing.Size(121, 20)
        Me.Txt_LimiteVale.TabIndex = 29
        Me.Txt_LimiteVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_LimiteCredito
        '
        Me.Txt_LimiteCredito.Enabled = False
        Me.Txt_LimiteCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimiteCredito.Location = New System.Drawing.Point(76, 69)
        Me.Txt_LimiteCredito.Name = "Txt_LimiteCredito"
        Me.Txt_LimiteCredito.Size = New System.Drawing.Size(121, 20)
        Me.Txt_LimiteCredito.TabIndex = 28
        Me.Txt_LimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Saldo
        '
        Me.Txt_Saldo.Enabled = False
        Me.Txt_Saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Saldo.Location = New System.Drawing.Point(76, 44)
        Me.Txt_Saldo.Name = "Txt_Saldo"
        Me.Txt_Saldo.Size = New System.Drawing.Size(121, 20)
        Me.Txt_Saldo.TabIndex = 6
        Me.Txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(263, 98)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl9.TabIndex = 26
        Me.LabelControl9.Text = "Límite Vale Nuevo"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(7, 99)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl10.TabIndex = 24
        Me.LabelControl10.Text = "Límite Vale"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(504, 47)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(82, 13)
        Me.LabelControl7.TabIndex = 22
        Me.LabelControl7.Text = "Disponible Nuevo"
        '
        'Txt_DisponibleNuevo
        '
        Me.Txt_DisponibleNuevo.BackColor = System.Drawing.Color.White
        Me.Txt_DisponibleNuevo.Location = New System.Drawing.Point(594, 40)
        Me.Txt_DisponibleNuevo.Name = "Txt_DisponibleNuevo"
        Me.Txt_DisponibleNuevo.ReadOnly = True
        Me.Txt_DisponibleNuevo.Size = New System.Drawing.Size(121, 20)
        Me.Txt_DisponibleNuevo.TabIndex = 21
        Me.Txt_DisponibleNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(263, 47)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl8.TabIndex = 20
        Me.LabelControl8.Text = "Disponible Actual"
        '
        'Txt_Disponible
        '
        Me.Txt_Disponible.BackColor = System.Drawing.Color.White
        Me.Txt_Disponible.Location = New System.Drawing.Point(368, 40)
        Me.Txt_Disponible.Name = "Txt_Disponible"
        Me.Txt_Disponible.ReadOnly = True
        Me.Txt_Disponible.Size = New System.Drawing.Size(121, 20)
        Me.Txt_Disponible.TabIndex = 19
        Me.Txt_Disponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(263, 72)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(99, 13)
        Me.LabelControl6.TabIndex = 18
        Me.LabelControl6.Text = "Límite Crédito Nuevo"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(7, 73)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "Límite Crédito"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(7, 47)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 12
        Me.LabelControl2.Text = "Saldo"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(7, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl1.TabIndex = 10
        Me.LabelControl1.Text = "Estatus"
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.AutoCompleteCustomSource.AddRange(New String() {"ACTIVO", "BAJA", "DEMANDA", "SUSPENDIDO"})
        Me.Cbo_Estatus.BackColor = System.Drawing.Color.PowderBlue
        Me.Cbo_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"ACTIVO", "BAJA", "DEMANDA", "SUSPENDIDO"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(76, 12)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Estatus.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Opt_NoPromo)
        Me.Panel3.Controls.Add(Me.Opt_SiPromo)
        Me.Panel3.Location = New System.Drawing.Point(380, 119)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(359, 34)
        Me.Panel3.TabIndex = 54
        '
        'Opt_NoPromo
        '
        Me.Opt_NoPromo.AutoSize = True
        Me.Opt_NoPromo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_NoPromo.Location = New System.Drawing.Point(181, 6)
        Me.Opt_NoPromo.Name = "Opt_NoPromo"
        Me.Opt_NoPromo.Size = New System.Drawing.Size(165, 19)
        Me.Opt_NoPromo.TabIndex = 4
        Me.Opt_NoPromo.TabStop = True
        Me.Opt_NoPromo.Text = "NO Acepta Promoción"
        Me.Opt_NoPromo.UseVisualStyleBackColor = True
        '
        'Opt_SiPromo
        '
        Me.Opt_SiPromo.AutoSize = True
        Me.Opt_SiPromo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_SiPromo.Location = New System.Drawing.Point(9, 6)
        Me.Opt_SiPromo.Name = "Opt_SiPromo"
        Me.Opt_SiPromo.Size = New System.Drawing.Size(158, 19)
        Me.Opt_SiPromo.TabIndex = 3
        Me.Opt_SiPromo.TabStop = True
        Me.Opt_SiPromo.Text = "SI Acepta Promoción"
        Me.Opt_SiPromo.UseVisualStyleBackColor = True
        '
        'frmAutorizaElectronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 410)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Opt_NoAcepta)
        Me.Controls.Add(Me.Opt_Acepta)
        Me.Controls.Add(Me.Dt_FecAlta)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.Txt_DistribNuevo)
        Me.Controls.Add(Me.Txt_DistribNombre)
        Me.Controls.Add(Me.LabelControl5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAutorizaElectronica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Movimientos Distribuidor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_DistribNuevo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_DistribNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Dt_FecAlta As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Opt_Acepta As RadioButton
    Friend WithEvents Opt_NoAcepta As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Cbo_Estatus As ComboBox
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_DisponibleNuevo As MaskedTextBox
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Txt_Disponible As MaskedTextBox
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Opt_NoPromo As RadioButton
    Friend WithEvents Opt_SiPromo As RadioButton
    Friend WithEvents Txt_LimiteCreditoNuevo As TextBox
    Friend WithEvents Txt_LimiteVale As TextBox
    Friend WithEvents Txt_LimiteCredito As TextBox
    Friend WithEvents Txt_Saldo As TextBox
    Friend WithEvents Txt_LimiteValeNuevo As TextBox
End Class
