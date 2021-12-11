<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroCorrida
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.LblEstilof = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAlto = New System.Windows.Forms.TextBox()
        Me.txtFrente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFondo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbmatsuela = New System.Windows.Forms.ComboBox()
        Me.cbmatcalzado = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblTalla)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblColor)
        Me.Panel1.Controls.Add(Me.LblEstilof)
        Me.Panel1.Controls.Add(Me.lblModelo)
        Me.Panel1.Controls.Add(Me.lblMarca)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(7, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(641, 151)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(205, 139)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(214, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Marca:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(214, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modelo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(214, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Estilo F:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(214, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Color 1:"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.Location = New System.Drawing.Point(272, 8)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(0, 17)
        Me.lblMarca.TabIndex = 5
        '
        'lblModelo
        '
        Me.lblModelo.AutoSize = True
        Me.lblModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelo.Location = New System.Drawing.Point(272, 43)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(0, 17)
        Me.lblModelo.TabIndex = 6
        '
        'LblEstilof
        '
        Me.LblEstilof.AutoSize = True
        Me.LblEstilof.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstilof.Location = New System.Drawing.Point(272, 80)
        Me.LblEstilof.Name = "LblEstilof"
        Me.LblEstilof.Size = New System.Drawing.Size(0, 17)
        Me.LblEstilof.TabIndex = 7
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(272, 115)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(0, 17)
        Me.lblColor.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(379, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 46)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Talla:"
        '
        'lblTalla
        '
        Me.lblTalla.AutoSize = True
        Me.lblTalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTalla.Location = New System.Drawing.Point(481, 56)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(0, 46)
        Me.lblTalla.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.cbmatcalzado)
        Me.Panel2.Controls.Add(Me.cbmatsuela)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtFondo)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtFrente)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.txtAlto)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtPeso)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(7, 163)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(641, 209)
        Me.Panel2.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Peso de la caja:"
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(108, 11)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(45, 20)
        Me.txtPeso.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(153, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Kgs"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(217, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Medidas de la caja (centimetros):"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(217, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 17)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Alto"
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(251, 62)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Size = New System.Drawing.Size(39, 20)
        Me.txtAlto.TabIndex = 5
        '
        'txtFrente
        '
        Me.txtFrente.Location = New System.Drawing.Point(359, 62)
        Me.txtFrente.Name = "txtFrente"
        Me.txtFrente.Size = New System.Drawing.Size(39, 20)
        Me.txtFrente.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(296, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 17)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "x Frente"
        '
        'txtFondo
        '
        Me.txtFondo.Location = New System.Drawing.Point(465, 62)
        Me.txtFondo.Name = "txtFondo"
        Me.txtFondo.Size = New System.Drawing.Size(39, 20)
        Me.txtFondo.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(404, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 17)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "x Fondo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(135, 17)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Material de la suela:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 162)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 17)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Material de la calzado:"
        '
        'cbmatsuela
        '
        Me.cbmatsuela.FormattingEnabled = True
        Me.cbmatsuela.Location = New System.Drawing.Point(151, 111)
        Me.cbmatsuela.Name = "cbmatsuela"
        Me.cbmatsuela.Size = New System.Drawing.Size(114, 21)
        Me.cbmatsuela.TabIndex = 12
        '
        'cbmatcalzado
        '
        Me.cbmatcalzado.FormattingEnabled = True
        Me.cbmatcalzado.Location = New System.Drawing.Point(151, 161)
        Me.cbmatcalzado.Name = "cbmatcalzado"
        Me.cbmatcalzado.Size = New System.Drawing.Size(114, 21)
        Me.cbmatcalzado.TabIndex = 13
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(-2, 213)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(641, 56)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.btnaceptar)
        Me.Panel4.Location = New System.Drawing.Point(7, 380)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(641, 56)
        Me.Panel4.TabIndex = 2
        '
        'btnaceptar
        '
        Me.btnaceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btnaceptar.Location = New System.Drawing.Point(586, 1)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(51, 52)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'frmRegistroCorrida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(654, 443)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmRegistroCorrida"
        Me.Text = "Registro de corridas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTalla As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblColor As Label
    Friend WithEvents LblEstilof As Label
    Friend WithEvents lblModelo As Label
    Friend WithEvents lblMarca As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cbmatcalzado As ComboBox
    Friend WithEvents cbmatsuela As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFondo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFrente As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAlto As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPeso As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnaceptar As Button
End Class
