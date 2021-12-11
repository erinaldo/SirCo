<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFormasPagoPV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFormasPagoPV))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_NotaCredito = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_DineroElectronico = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Efectivo = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_TarjetaCredito = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_TarjetaDebito = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_CreditoPersonal = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Vale = New DevExpress.XtraEditors.SimpleButton()
        Me.Pnl_Totales = New System.Windows.Forms.Panel()
        Me.Btn_Comprar = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_Total = New System.Windows.Forms.TextBox()
        Me.Txt_Descuento = New System.Windows.Forms.TextBox()
        Me.Txt_Subtotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Pnl_Totales.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Btn_NotaCredito)
        Me.Panel1.Controls.Add(Me.Btn_DineroElectronico)
        Me.Panel1.Controls.Add(Me.Btn_Efectivo)
        Me.Panel1.Controls.Add(Me.Btn_TarjetaCredito)
        Me.Panel1.Controls.Add(Me.Btn_TarjetaDebito)
        Me.Panel1.Controls.Add(Me.Btn_CreditoPersonal)
        Me.Panel1.Controls.Add(Me.Btn_Vale)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(436, 537)
        Me.Panel1.TabIndex = 0
        '
        'Btn_NotaCredito
        '
        Me.Btn_NotaCredito.ImageOptions.Image = CType(resources.GetObject("Btn_NotaCredito.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_NotaCredito.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_NotaCredito.Location = New System.Drawing.Point(57, 373)
        Me.Btn_NotaCredito.Name = "Btn_NotaCredito"
        Me.Btn_NotaCredito.Size = New System.Drawing.Size(105, 87)
        Me.Btn_NotaCredito.TabIndex = 6
        '
        'Btn_DineroElectronico
        '
        Me.Btn_DineroElectronico.ImageOptions.Image = CType(resources.GetObject("Btn_DineroElectronico.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_DineroElectronico.Location = New System.Drawing.Point(204, 257)
        Me.Btn_DineroElectronico.Name = "Btn_DineroElectronico"
        Me.Btn_DineroElectronico.Size = New System.Drawing.Size(105, 87)
        Me.Btn_DineroElectronico.TabIndex = 5
        '
        'Btn_Efectivo
        '
        Me.Btn_Efectivo.ImageOptions.Image = CType(resources.GetObject("Btn_Efectivo.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_Efectivo.Location = New System.Drawing.Point(57, 257)
        Me.Btn_Efectivo.Name = "Btn_Efectivo"
        Me.Btn_Efectivo.Size = New System.Drawing.Size(105, 87)
        Me.Btn_Efectivo.TabIndex = 4
        '
        'Btn_TarjetaCredito
        '
        Me.Btn_TarjetaCredito.ImageOptions.Image = CType(resources.GetObject("Btn_TarjetaCredito.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_TarjetaCredito.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_TarjetaCredito.Location = New System.Drawing.Point(204, 144)
        Me.Btn_TarjetaCredito.Name = "Btn_TarjetaCredito"
        Me.Btn_TarjetaCredito.Size = New System.Drawing.Size(105, 87)
        Me.Btn_TarjetaCredito.TabIndex = 3
        '
        'Btn_TarjetaDebito
        '
        Me.Btn_TarjetaDebito.ImageOptions.Image = CType(resources.GetObject("Btn_TarjetaDebito.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_TarjetaDebito.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_TarjetaDebito.Location = New System.Drawing.Point(57, 144)
        Me.Btn_TarjetaDebito.Name = "Btn_TarjetaDebito"
        Me.Btn_TarjetaDebito.Size = New System.Drawing.Size(105, 87)
        Me.Btn_TarjetaDebito.TabIndex = 2
        '
        'Btn_CreditoPersonal
        '
        Me.Btn_CreditoPersonal.ImageOptions.Image = CType(resources.GetObject("Btn_CreditoPersonal.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_CreditoPersonal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_CreditoPersonal.Location = New System.Drawing.Point(204, 33)
        Me.Btn_CreditoPersonal.Name = "Btn_CreditoPersonal"
        Me.Btn_CreditoPersonal.Size = New System.Drawing.Size(105, 87)
        Me.Btn_CreditoPersonal.TabIndex = 1
        '
        'Btn_Vale
        '
        Me.Btn_Vale.ImageOptions.Image = CType(resources.GetObject("Btn_Vale.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_Vale.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Vale.Location = New System.Drawing.Point(57, 33)
        Me.Btn_Vale.Name = "Btn_Vale"
        Me.Btn_Vale.Size = New System.Drawing.Size(105, 87)
        Me.Btn_Vale.TabIndex = 0
        Me.Btn_Vale.Text = "Vale"
        '
        'Pnl_Totales
        '
        Me.Pnl_Totales.Controls.Add(Me.Btn_Comprar)
        Me.Pnl_Totales.Controls.Add(Me.Txt_Total)
        Me.Pnl_Totales.Controls.Add(Me.Txt_Descuento)
        Me.Pnl_Totales.Controls.Add(Me.Txt_Subtotal)
        Me.Pnl_Totales.Controls.Add(Me.Label5)
        Me.Pnl_Totales.Controls.Add(Me.Label4)
        Me.Pnl_Totales.Controls.Add(Me.Label2)
        Me.Pnl_Totales.Dock = System.Windows.Forms.DockStyle.Right
        Me.Pnl_Totales.Location = New System.Drawing.Point(441, 0)
        Me.Pnl_Totales.Name = "Pnl_Totales"
        Me.Pnl_Totales.Size = New System.Drawing.Size(407, 537)
        Me.Pnl_Totales.TabIndex = 3
        '
        'Btn_Comprar
        '
        Me.Btn_Comprar.ImageOptions.Image = CType(resources.GetObject("Btn_Comprar.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_Comprar.Location = New System.Drawing.Point(247, 427)
        Me.Btn_Comprar.Name = "Btn_Comprar"
        Me.Btn_Comprar.Size = New System.Drawing.Size(131, 62)
        Me.Btn_Comprar.TabIndex = 8
        '
        'Txt_Total
        '
        Me.Txt_Total.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Total.ForeColor = System.Drawing.Color.Navy
        Me.Txt_Total.Location = New System.Drawing.Point(230, 117)
        Me.Txt_Total.Name = "Txt_Total"
        Me.Txt_Total.Size = New System.Drawing.Size(148, 44)
        Me.Txt_Total.TabIndex = 7
        Me.Txt_Total.Text = "0.0"
        Me.Txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Descuento
        '
        Me.Txt_Descuento.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descuento.Location = New System.Drawing.Point(230, 69)
        Me.Txt_Descuento.Name = "Txt_Descuento"
        Me.Txt_Descuento.Size = New System.Drawing.Size(148, 35)
        Me.Txt_Descuento.TabIndex = 6
        Me.Txt_Descuento.Text = "0.0"
        Me.Txt_Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Subtotal
        '
        Me.Txt_Subtotal.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Subtotal.Location = New System.Drawing.Point(230, 22)
        Me.Txt_Subtotal.Name = "Txt_Subtotal"
        Me.Txt_Subtotal.Size = New System.Drawing.Size(148, 35)
        Me.Txt_Subtotal.TabIndex = 5
        Me.Txt_Subtotal.Text = "0.0"
        Me.Txt_Subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(9, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 37)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "TOTAL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 29)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "DESC."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SUBTOTAL"
        '
        'frmFormasPagoPV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 537)
        Me.Controls.Add(Me.Pnl_Totales)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFormasPagoPV"
        Me.Text = "Fromas de Pago"
        Me.Panel1.ResumeLayout(False)
        Me.Pnl_Totales.ResumeLayout(False)
        Me.Pnl_Totales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Btn_NotaCredito As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_DineroElectronico As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Efectivo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_TarjetaCredito As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_TarjetaDebito As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_CreditoPersonal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Vale As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Pnl_Totales As Panel
    Friend WithEvents Btn_Comprar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Txt_Total As TextBox
    Friend WithEvents Txt_Descuento As TextBox
    Friend WithEvents Txt_Subtotal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
End Class
