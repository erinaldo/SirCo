<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApendiceSql
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApendiceSql))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_txt = New System.Windows.Forms.Button()
        Me.Btn_generar = New System.Windows.Forms.Button()
        Me.Txt_Cajero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_sucursal = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP_Fin = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_total = New System.Windows.Forms.Label()
        Me.lb_porcentaje = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_porcentaje = New System.Windows.Forms.TextBox()
        Me.rb_Importe = New System.Windows.Forms.RadioButton()
        Me.rb_porcentaje = New System.Windows.Forms.RadioButton()
        Me.Pnl_Botones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.btn_txt)
        Me.Pnl_Botones.Controls.Add(Me.Btn_generar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 126)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(437, 58)
        Me.Pnl_Botones.TabIndex = 54
        '
        'btn_txt
        '
        Me.btn_txt.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_txt.Location = New System.Drawing.Point(0, 0)
        Me.btn_txt.Name = "btn_txt"
        Me.btn_txt.Size = New System.Drawing.Size(54, 54)
        Me.btn_txt.TabIndex = 41
        Me.btn_txt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_txt.UseVisualStyleBackColor = True
        '
        'Btn_generar
        '
        Me.Btn_generar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_generar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_generar.Location = New System.Drawing.Point(379, 0)
        Me.Btn_generar.Name = "Btn_generar"
        Me.Btn_generar.Size = New System.Drawing.Size(54, 54)
        Me.Btn_generar.TabIndex = 40
        Me.Btn_generar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_generar.UseVisualStyleBackColor = True
        '
        'Txt_Cajero
        '
        Me.Txt_Cajero.Location = New System.Drawing.Point(137, 85)
        Me.Txt_Cajero.Name = "Txt_Cajero"
        Me.Txt_Cajero.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Cajero.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(54, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Cajero"
        '
        'cb_sucursal
        '
        Me.cb_sucursal.FormattingEnabled = True
        Me.cb_sucursal.Items.AddRange(New Object() {"08"})
        Me.cb_sucursal.Location = New System.Drawing.Point(137, 58)
        Me.cb_sucursal.Name = "cb_sucursal"
        Me.cb_sucursal.Size = New System.Drawing.Size(161, 21)
        Me.cb_sucursal.TabIndex = 61
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Sucursal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Fecha Fin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(54, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Fecha Inicio"
        '
        'DTP_Fin
        '
        Me.DTP_Fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Fin.Location = New System.Drawing.Point(137, 34)
        Me.DTP_Fin.Name = "DTP_Fin"
        Me.DTP_Fin.Size = New System.Drawing.Size(242, 20)
        Me.DTP_Fin.TabIndex = 57
        '
        'DTP_Inicio
        '
        Me.DTP_Inicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Inicio.Location = New System.Drawing.Point(137, 12)
        Me.DTP_Inicio.Name = "DTP_Inicio"
        Me.DTP_Inicio.Size = New System.Drawing.Size(242, 20)
        Me.DTP_Inicio.TabIndex = 56
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lb_total)
        Me.GroupBox1.Controls.Add(Me.lb_porcentaje)
        Me.GroupBox1.Controls.Add(Me.txt_total)
        Me.GroupBox1.Controls.Add(Me.txt_porcentaje)
        Me.GroupBox1.Controls.Add(Me.rb_Importe)
        Me.GroupBox1.Controls.Add(Me.rb_porcentaje)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 77)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'lb_total
        '
        Me.lb_total.AutoSize = True
        Me.lb_total.BackColor = System.Drawing.Color.White
        Me.lb_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total.Location = New System.Drawing.Point(143, 48)
        Me.lb_total.Name = "lb_total"
        Me.lb_total.Size = New System.Drawing.Size(14, 13)
        Me.lb_total.TabIndex = 5
        Me.lb_total.Text = "$"
        Me.lb_total.Visible = False
        '
        'lb_porcentaje
        '
        Me.lb_porcentaje.AutoSize = True
        Me.lb_porcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_porcentaje.Location = New System.Drawing.Point(242, 23)
        Me.lb_porcentaje.Name = "lb_porcentaje"
        Me.lb_porcentaje.Size = New System.Drawing.Size(16, 13)
        Me.lb_porcentaje.TabIndex = 4
        Me.lb_porcentaje.Text = "%"
        Me.lb_porcentaje.Visible = False
        '
        'txt_total
        '
        Me.txt_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(141, 45)
        Me.txt_total.MaxLength = 12
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(100, 20)
        Me.txt_total.TabIndex = 3
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_total.Visible = False
        '
        'txt_porcentaje
        '
        Me.txt_porcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_porcentaje.Location = New System.Drawing.Point(141, 19)
        Me.txt_porcentaje.MaxLength = 10
        Me.txt_porcentaje.Name = "txt_porcentaje"
        Me.txt_porcentaje.Size = New System.Drawing.Size(100, 20)
        Me.txt_porcentaje.TabIndex = 2
        Me.txt_porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_porcentaje.Visible = False
        '
        'rb_Importe
        '
        Me.rb_Importe.AutoSize = True
        Me.rb_Importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_Importe.Location = New System.Drawing.Point(63, 45)
        Me.rb_Importe.Name = "rb_Importe"
        Me.rb_Importe.Size = New System.Drawing.Size(67, 17)
        Me.rb_Importe.TabIndex = 1
        Me.rb_Importe.TabStop = True
        Me.rb_Importe.Text = "Importe"
        Me.rb_Importe.UseVisualStyleBackColor = True
        '
        'rb_porcentaje
        '
        Me.rb_porcentaje.AutoSize = True
        Me.rb_porcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_porcentaje.Location = New System.Drawing.Point(63, 22)
        Me.rb_porcentaje.Name = "rb_porcentaje"
        Me.rb_porcentaje.Size = New System.Drawing.Size(34, 17)
        Me.rb_porcentaje.TabIndex = 0
        Me.rb_porcentaje.TabStop = True
        Me.rb_porcentaje.Text = "%"
        Me.rb_porcentaje.UseVisualStyleBackColor = True
        '
        'frmApendiceSql
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 184)
        Me.Controls.Add(Me.Txt_Cajero)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cb_sucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTP_Fin)
        Me.Controls.Add(Me.DTP_Inicio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmApendiceSql"
        Me.Text = "Apéndice Fiscal"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents btn_txt As Button
    Friend WithEvents Btn_generar As Button
    Friend WithEvents Txt_Cajero As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cb_sucursal As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DTP_Fin As DateTimePicker
    Friend WithEvents DTP_Inicio As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lb_total As Label
    Friend WithEvents lb_porcentaje As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents txt_porcentaje As TextBox
    Friend WithEvents rb_Importe As RadioButton
    Friend WithEvents rb_porcentaje As RadioButton
End Class
