<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModificarDescuentoCaja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.lbl_Distribuidor = New System.Windows.Forms.Label()
        Me.txt_NombreDistrib = New System.Windows.Forms.TextBox()
        Me.txt_Distrib = New System.Windows.Forms.TextBox()
        Me.txt_Motivo = New System.Windows.Forms.TextBox()
        Me.lbl_Motivo = New System.Windows.Forms.Label()
        Me.lbl_Descuento = New System.Windows.Forms.Label()
        Me.txt_Descuento = New System.Windows.Forms.TextBox()
        Me.lbl_Porc = New System.Windows.Forms.Label()
        Me.lbl_Al = New System.Windows.Forms.Label()
        Me.txt_NombreDistrib2 = New System.Windows.Forms.TextBox()
        Me.txt_Distrib2 = New System.Windows.Forms.TextBox()
        Me.DT_FechaIni = New System.Windows.Forms.DateTimePicker()
        Me.lbl_FechaAl = New System.Windows.Forms.Label()
        Me.lbl_Fecha = New System.Windows.Forms.Label()
        Me.DT_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 303)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(478, 70)
        Me.pnl_Botones.TabIndex = 13
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.White
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelar.Location = New System.Drawing.Point(326, 0)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Cancelar.TabIndex = 1
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.BackColor = System.Drawing.Color.White
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.Location = New System.Drawing.Point(400, 0)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Aceptar.TabIndex = 36
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'lbl_Distribuidor
        '
        Me.lbl_Distribuidor.AutoSize = True
        Me.lbl_Distribuidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Distribuidor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Distribuidor.Location = New System.Drawing.Point(9, 33)
        Me.lbl_Distribuidor.Name = "lbl_Distribuidor"
        Me.lbl_Distribuidor.Size = New System.Drawing.Size(116, 16)
        Me.lbl_Distribuidor.TabIndex = 21
        Me.lbl_Distribuidor.Text = "DISTRIBUIDOR"
        '
        'txt_NombreDistrib
        '
        Me.txt_NombreDistrib.BackColor = System.Drawing.SystemColors.Window
        Me.txt_NombreDistrib.Enabled = False
        Me.txt_NombreDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NombreDistrib.Location = New System.Drawing.Point(211, 27)
        Me.txt_NombreDistrib.Name = "txt_NombreDistrib"
        Me.txt_NombreDistrib.ReadOnly = True
        Me.txt_NombreDistrib.Size = New System.Drawing.Size(255, 26)
        Me.txt_NombreDistrib.TabIndex = 1
        '
        'txt_Distrib
        '
        Me.txt_Distrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Distrib.Location = New System.Drawing.Point(131, 27)
        Me.txt_Distrib.MaxLength = 6
        Me.txt_Distrib.Name = "txt_Distrib"
        Me.txt_Distrib.Size = New System.Drawing.Size(74, 26)
        Me.txt_Distrib.TabIndex = 0
        '
        'txt_Motivo
        '
        Me.txt_Motivo.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Motivo.Location = New System.Drawing.Point(131, 187)
        Me.txt_Motivo.MaxLength = 50
        Me.txt_Motivo.Multiline = True
        Me.txt_Motivo.Name = "txt_Motivo"
        Me.txt_Motivo.Size = New System.Drawing.Size(335, 99)
        Me.txt_Motivo.TabIndex = 35
        '
        'lbl_Motivo
        '
        Me.lbl_Motivo.AutoSize = True
        Me.lbl_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Motivo.ForeColor = System.Drawing.Color.Black
        Me.lbl_Motivo.Location = New System.Drawing.Point(59, 187)
        Me.lbl_Motivo.Name = "lbl_Motivo"
        Me.lbl_Motivo.Size = New System.Drawing.Size(66, 16)
        Me.lbl_Motivo.TabIndex = 23
        Me.lbl_Motivo.Text = "MOTIVO"
        '
        'lbl_Descuento
        '
        Me.lbl_Descuento.AutoSize = True
        Me.lbl_Descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Descuento.ForeColor = System.Drawing.Color.Black
        Me.lbl_Descuento.Location = New System.Drawing.Point(23, 161)
        Me.lbl_Descuento.Name = "lbl_Descuento"
        Me.lbl_Descuento.Size = New System.Drawing.Size(102, 16)
        Me.lbl_Descuento.TabIndex = 25
        Me.lbl_Descuento.Text = "DESCUENTO"
        '
        'txt_Descuento
        '
        Me.txt_Descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Descuento.Location = New System.Drawing.Point(131, 155)
        Me.txt_Descuento.MaxLength = 6
        Me.txt_Descuento.Name = "txt_Descuento"
        Me.txt_Descuento.Size = New System.Drawing.Size(74, 26)
        Me.txt_Descuento.TabIndex = 34
        '
        'lbl_Porc
        '
        Me.lbl_Porc.AutoSize = True
        Me.lbl_Porc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Porc.ForeColor = System.Drawing.Color.Black
        Me.lbl_Porc.Location = New System.Drawing.Point(211, 161)
        Me.lbl_Porc.Name = "lbl_Porc"
        Me.lbl_Porc.Size = New System.Drawing.Size(21, 16)
        Me.lbl_Porc.TabIndex = 26
        Me.lbl_Porc.Text = "%"
        '
        'lbl_Al
        '
        Me.lbl_Al.AutoSize = True
        Me.lbl_Al.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Al.ForeColor = System.Drawing.Color.Black
        Me.lbl_Al.Location = New System.Drawing.Point(99, 65)
        Me.lbl_Al.Name = "lbl_Al"
        Me.lbl_Al.Size = New System.Drawing.Size(26, 16)
        Me.lbl_Al.TabIndex = 29
        Me.lbl_Al.Text = "AL"
        '
        'txt_NombreDistrib2
        '
        Me.txt_NombreDistrib2.BackColor = System.Drawing.SystemColors.Window
        Me.txt_NombreDistrib2.Enabled = False
        Me.txt_NombreDistrib2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NombreDistrib2.Location = New System.Drawing.Point(211, 59)
        Me.txt_NombreDistrib2.Name = "txt_NombreDistrib2"
        Me.txt_NombreDistrib2.ReadOnly = True
        Me.txt_NombreDistrib2.Size = New System.Drawing.Size(255, 26)
        Me.txt_NombreDistrib2.TabIndex = 28
        '
        'txt_Distrib2
        '
        Me.txt_Distrib2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Distrib2.Location = New System.Drawing.Point(131, 59)
        Me.txt_Distrib2.MaxLength = 6
        Me.txt_Distrib2.Name = "txt_Distrib2"
        Me.txt_Distrib2.Size = New System.Drawing.Size(74, 26)
        Me.txt_Distrib2.TabIndex = 27
        '
        'DT_FechaIni
        '
        Me.DT_FechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_FechaIni.Location = New System.Drawing.Point(131, 91)
        Me.DT_FechaIni.Name = "DT_FechaIni"
        Me.DT_FechaIni.Size = New System.Drawing.Size(335, 26)
        Me.DT_FechaIni.TabIndex = 30
        '
        'lbl_FechaAl
        '
        Me.lbl_FechaAl.AutoSize = True
        Me.lbl_FechaAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FechaAl.ForeColor = System.Drawing.Color.Black
        Me.lbl_FechaAl.Location = New System.Drawing.Point(99, 129)
        Me.lbl_FechaAl.Name = "lbl_FechaAl"
        Me.lbl_FechaAl.Size = New System.Drawing.Size(26, 16)
        Me.lbl_FechaAl.TabIndex = 32
        Me.lbl_FechaAl.Text = "AL"
        '
        'lbl_Fecha
        '
        Me.lbl_Fecha.AutoSize = True
        Me.lbl_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fecha.ForeColor = System.Drawing.Color.Black
        Me.lbl_Fecha.Location = New System.Drawing.Point(67, 97)
        Me.lbl_Fecha.Name = "lbl_Fecha"
        Me.lbl_Fecha.Size = New System.Drawing.Size(58, 16)
        Me.lbl_Fecha.TabIndex = 31
        Me.lbl_Fecha.Text = "FECHA"
        '
        'DT_FechaFin
        '
        Me.DT_FechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_FechaFin.Location = New System.Drawing.Point(131, 123)
        Me.DT_FechaFin.Name = "DT_FechaFin"
        Me.DT_FechaFin.Size = New System.Drawing.Size(335, 26)
        Me.DT_FechaFin.TabIndex = 33
        '
        'frmModificarDescuentoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(478, 373)
        Me.Controls.Add(Me.DT_FechaFin)
        Me.Controls.Add(Me.lbl_FechaAl)
        Me.Controls.Add(Me.lbl_Fecha)
        Me.Controls.Add(Me.DT_FechaIni)
        Me.Controls.Add(Me.lbl_Al)
        Me.Controls.Add(Me.txt_NombreDistrib2)
        Me.Controls.Add(Me.txt_Distrib2)
        Me.Controls.Add(Me.lbl_Porc)
        Me.Controls.Add(Me.lbl_Descuento)
        Me.Controls.Add(Me.txt_Descuento)
        Me.Controls.Add(Me.lbl_Motivo)
        Me.Controls.Add(Me.txt_Motivo)
        Me.Controls.Add(Me.lbl_Distribuidor)
        Me.Controls.Add(Me.txt_NombreDistrib)
        Me.Controls.Add(Me.txt_Distrib)
        Me.Controls.Add(Me.pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmModificarDescuentoCaja"
        Me.Text = "Descuento Especial"
        Me.pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents lbl_Distribuidor As System.Windows.Forms.Label
    Friend WithEvents txt_NombreDistrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_Distrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_Motivo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Motivo As System.Windows.Forms.Label
    Friend WithEvents lbl_Descuento As System.Windows.Forms.Label
    Friend WithEvents txt_Descuento As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Porc As System.Windows.Forms.Label
    Friend WithEvents lbl_Al As System.Windows.Forms.Label
    Friend WithEvents txt_NombreDistrib2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Distrib2 As System.Windows.Forms.TextBox
    Friend WithEvents DT_FechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_FechaAl As System.Windows.Forms.Label
    Friend WithEvents lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents DT_FechaFin As System.Windows.Forms.DateTimePicker
End Class
