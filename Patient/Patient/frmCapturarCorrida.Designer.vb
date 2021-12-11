<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturarCorrida
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
        Me.lbl_Color = New System.Windows.Forms.Label()
        Me.lbl_Estilof = New System.Windows.Forms.Label()
        Me.lbl_Modelo = New System.Windows.Forms.Label()
        Me.lbl_Marca = New System.Windows.Forms.Label()
        Me.lbl_Talla = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_Peso = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_Alto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_Frente = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_Fondo = New System.Windows.Forms.TextBox()
        Me.cb_Msuela = New System.Windows.Forms.ComboBox()
        Me.cb_mcalzado = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txt_Corrida = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lbl_Color)
        Me.Panel1.Controls.Add(Me.lbl_Estilof)
        Me.Panel1.Controls.Add(Me.lbl_Modelo)
        Me.Panel1.Controls.Add(Me.lbl_Marca)
        Me.Panel1.Controls.Add(Me.lbl_Talla)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(10, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 179)
        Me.Panel1.TabIndex = 0
        '
        'lbl_Color
        '
        Me.lbl_Color.AutoSize = True
        Me.lbl_Color.Location = New System.Drawing.Point(289, 136)
        Me.lbl_Color.Name = "lbl_Color"
        Me.lbl_Color.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Color.TabIndex = 10
        '
        'lbl_Estilof
        '
        Me.lbl_Estilof.AutoSize = True
        Me.lbl_Estilof.Location = New System.Drawing.Point(272, 96)
        Me.lbl_Estilof.Name = "lbl_Estilof"
        Me.lbl_Estilof.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Estilof.TabIndex = 9
        '
        'lbl_Modelo
        '
        Me.lbl_Modelo.AutoSize = True
        Me.lbl_Modelo.Location = New System.Drawing.Point(272, 59)
        Me.lbl_Modelo.Name = "lbl_Modelo"
        Me.lbl_Modelo.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Modelo.TabIndex = 8
        '
        'lbl_Marca
        '
        Me.lbl_Marca.AutoSize = True
        Me.lbl_Marca.Location = New System.Drawing.Point(269, 22)
        Me.lbl_Marca.Name = "lbl_Marca"
        Me.lbl_Marca.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Marca.TabIndex = 7
        '
        'lbl_Talla
        '
        Me.lbl_Talla.AutoSize = True
        Me.lbl_Talla.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Talla.Location = New System.Drawing.Point(524, 68)
        Me.lbl_Talla.Name = "lbl_Talla"
        Me.lbl_Talla.Size = New System.Drawing.Size(0, 46)
        Me.lbl_Talla.TabIndex = 6
        Me.lbl_Talla.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(407, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 46)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Talla:"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(221, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Descripcion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(221, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Estilo F:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(221, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modelo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(221, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Marca:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(206, 164)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Location = New System.Drawing.Point(10, 377)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(650, 56)
        Me.Panel4.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.SIRCO.My.Resources.Resources.OK
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(593, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 47)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Peso de la caja:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(15, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(162, 13)
        Me.Label20.TabIndex = 12
        Me.Label20.Text = "Medidas de la caja (centimetros):"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(183, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 13)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Alto"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 98)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Material de la suela:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 140)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Material del calzado: "
        '
        'txt_Peso
        '
        Me.txt_Peso.Location = New System.Drawing.Point(108, 14)
        Me.txt_Peso.Name = "txt_Peso"
        Me.txt_Peso.Size = New System.Drawing.Size(50, 20)
        Me.txt_Peso.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(161, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(25, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Kgs"
        '
        'txt_Alto
        '
        Me.txt_Alto.Location = New System.Drawing.Point(214, 55)
        Me.txt_Alto.Name = "txt_Alto"
        Me.txt_Alto.Size = New System.Drawing.Size(44, 20)
        Me.txt_Alto.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(266, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "x Frente"
        '
        'txt_Frente
        '
        Me.txt_Frente.Location = New System.Drawing.Point(317, 55)
        Me.txt_Frente.Name = "txt_Frente"
        Me.txt_Frente.Size = New System.Drawing.Size(44, 20)
        Me.txt_Frente.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(367, 58)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "x Fondo"
        '
        'txt_Fondo
        '
        Me.txt_Fondo.Location = New System.Drawing.Point(418, 55)
        Me.txt_Fondo.Name = "txt_Fondo"
        Me.txt_Fondo.Size = New System.Drawing.Size(44, 20)
        Me.txt_Fondo.TabIndex = 21
        '
        'cb_Msuela
        '
        Me.cb_Msuela.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_Msuela.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_Msuela.FormattingEnabled = True
        Me.cb_Msuela.Location = New System.Drawing.Point(122, 95)
        Me.cb_Msuela.Name = "cb_Msuela"
        Me.cb_Msuela.Size = New System.Drawing.Size(121, 21)
        Me.cb_Msuela.TabIndex = 22
        '
        'cb_mcalzado
        '
        Me.cb_mcalzado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_mcalzado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_mcalzado.FormattingEnabled = True
        Me.cb_mcalzado.Location = New System.Drawing.Point(122, 137)
        Me.cb_mcalzado.Name = "cb_mcalzado"
        Me.cb_mcalzado.Size = New System.Drawing.Size(121, 21)
        Me.cb_mcalzado.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.txt_Corrida)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cb_mcalzado)
        Me.Panel3.Controls.Add(Me.cb_Msuela)
        Me.Panel3.Controls.Add(Me.txt_Fondo)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txt_Frente)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txt_Alto)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txt_Peso)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Location = New System.Drawing.Point(10, 192)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(650, 179)
        Me.Panel3.TabIndex = 24
        '
        'txt_Corrida
        '
        Me.txt_Corrida.Location = New System.Drawing.Point(260, 14)
        Me.txt_Corrida.Name = "txt_Corrida"
        Me.txt_Corrida.Size = New System.Drawing.Size(46, 20)
        Me.txt_Corrida.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Corrida:"
        '
        'frmCapturarCorrida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 440)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCapturarCorrida"
        Me.Text = "Capturar Corrida"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbl_Talla As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_Color As Label
    Friend WithEvents lbl_Estilof As Label
    Friend WithEvents lbl_Modelo As Label
    Friend WithEvents lbl_Marca As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txt_Peso As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_Alto As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_Frente As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_Fondo As TextBox
    Friend WithEvents cb_Msuela As ComboBox
    Friend WithEvents cb_mcalzado As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txt_Corrida As TextBox
    Friend WithEvents Label6 As Label
End Class
