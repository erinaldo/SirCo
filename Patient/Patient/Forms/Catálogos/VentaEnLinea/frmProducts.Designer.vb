<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProducts))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txt_DescripMarca = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_EstiloF = New DevExpress.XtraEditors.TextEdit()
        Me.PBox = New DevExpress.XtraEditors.PictureEdit()
        Me.Lbl_Estructura = New System.Windows.Forms.Label()
        Me.Txt_Modelo = New DevExpress.XtraEditors.TextEdit()
        Me.Txt_Marca = New DevExpress.XtraEditors.TextEdit()
        Me.Modelo = New System.Windows.Forms.Label()
        Me.Txt_Titulo = New DevExpress.XtraEditors.TextEdit()
        Me.Lbl_Titulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Chk_Fotos = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cbo_Color2 = New DevExpress.XtraEditors.ListBoxControl()
        Me.Cbo_Color1 = New DevExpress.XtraEditors.ListBoxControl()
        Me.Cbo_Material = New DevExpress.XtraEditors.ListBoxControl()
        Me.PBox8 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox10 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox4 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox9 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox3 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox6 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox2 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox7 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox5 = New DevExpress.XtraEditors.PictureEdit()
        Me.PBox1 = New DevExpress.XtraEditors.PictureEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Mem_Descripcion = New DevExpress.XtraEditors.MemoEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Editar = New System.Windows.Forms.Panel()
        Me.Btn_Cancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_Aceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.CachedCrystalReport11 = New SIRCO.CachedCrystalReport1()
        Me.Panel1.SuspendLayout()
        CType(Me.Txt_DescripMarca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_EstiloF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Modelo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Marca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt_Titulo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Cbo_Color2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_Color1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo_Material, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox10.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox9.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mem_Descripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Editar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txt_DescripMarca)
        Me.Panel1.Controls.Add(Me.Txt_EstiloF)
        Me.Panel1.Controls.Add(Me.PBox)
        Me.Panel1.Controls.Add(Me.Lbl_Estructura)
        Me.Panel1.Controls.Add(Me.Txt_Modelo)
        Me.Panel1.Controls.Add(Me.Txt_Marca)
        Me.Panel1.Controls.Add(Me.Modelo)
        Me.Panel1.Controls.Add(Me.Txt_Titulo)
        Me.Panel1.Controls.Add(Me.Lbl_Titulo)
        Me.Panel1.Location = New System.Drawing.Point(8, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1083, 95)
        Me.Panel1.TabIndex = 0
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.EnterMoveNextControl = True
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(83, 6)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(140, 20)
        Me.Txt_DescripMarca.TabIndex = 17
        '
        'Txt_EstiloF
        '
        Me.Txt_EstiloF.Enabled = False
        Me.Txt_EstiloF.EnterMoveNextControl = True
        Me.Txt_EstiloF.Location = New System.Drawing.Point(229, 6)
        Me.Txt_EstiloF.Name = "Txt_EstiloF"
        Me.Txt_EstiloF.Size = New System.Drawing.Size(158, 20)
        Me.Txt_EstiloF.TabIndex = 18
        '
        'PBox
        '
        Me.PBox.Location = New System.Drawing.Point(974, -2)
        Me.PBox.Name = "PBox"
        Me.PBox.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox.Size = New System.Drawing.Size(100, 96)
        Me.PBox.TabIndex = 21
        '
        'Lbl_Estructura
        '
        Me.Lbl_Estructura.AutoSize = True
        Me.Lbl_Estructura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Estructura.Location = New System.Drawing.Point(14, 64)
        Me.Lbl_Estructura.Name = "Lbl_Estructura"
        Me.Lbl_Estructura.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_Estructura.TabIndex = 12
        Me.Lbl_Estructura.Text = "Estructura"
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.Enabled = False
        Me.Txt_Modelo.EnterMoveNextControl = True
        Me.Txt_Modelo.Location = New System.Drawing.Point(868, 19)
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.Size = New System.Drawing.Size(99, 20)
        Me.Txt_Modelo.TabIndex = 20
        Me.Txt_Modelo.Visible = False
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Enabled = False
        Me.Txt_Marca.EnterMoveNextControl = True
        Me.Txt_Marca.Location = New System.Drawing.Point(794, 19)
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(53, 20)
        Me.Txt_Marca.TabIndex = 19
        Me.Txt_Marca.Visible = False
        '
        'Modelo
        '
        Me.Modelo.AutoSize = True
        Me.Modelo.Location = New System.Drawing.Point(14, 12)
        Me.Modelo.Name = "Modelo"
        Me.Modelo.Size = New System.Drawing.Size(42, 13)
        Me.Modelo.TabIndex = 9
        Me.Modelo.Text = "Modelo"
        '
        'Txt_Titulo
        '
        Me.Txt_Titulo.EnterMoveNextControl = True
        Me.Txt_Titulo.Location = New System.Drawing.Point(83, 32)
        Me.Txt_Titulo.Name = "Txt_Titulo"
        Me.Txt_Titulo.Size = New System.Drawing.Size(429, 20)
        Me.Txt_Titulo.TabIndex = 0
        '
        'Lbl_Titulo
        '
        Me.Lbl_Titulo.AutoSize = True
        Me.Lbl_Titulo.Location = New System.Drawing.Point(14, 35)
        Me.Lbl_Titulo.Name = "Lbl_Titulo"
        Me.Lbl_Titulo.Size = New System.Drawing.Size(35, 13)
        Me.Lbl_Titulo.TabIndex = 0
        Me.Lbl_Titulo.Text = "Título"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Chk_Fotos)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Cbo_Color2)
        Me.Panel2.Controls.Add(Me.Cbo_Color1)
        Me.Panel2.Controls.Add(Me.Cbo_Material)
        Me.Panel2.Controls.Add(Me.PBox8)
        Me.Panel2.Controls.Add(Me.PBox10)
        Me.Panel2.Controls.Add(Me.PBox4)
        Me.Panel2.Controls.Add(Me.PBox9)
        Me.Panel2.Controls.Add(Me.PBox3)
        Me.Panel2.Controls.Add(Me.PBox6)
        Me.Panel2.Controls.Add(Me.PBox2)
        Me.Panel2.Controls.Add(Me.PBox7)
        Me.Panel2.Controls.Add(Me.PBox5)
        Me.Panel2.Controls.Add(Me.PBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Mem_Descripcion)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(8, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1083, 367)
        Me.Panel2.TabIndex = 1
        '
        'Chk_Fotos
        '
        Me.Chk_Fotos.AutoSize = True
        Me.Chk_Fotos.Location = New System.Drawing.Point(550, 13)
        Me.Chk_Fotos.Name = "Chk_Fotos"
        Me.Chk_Fotos.Size = New System.Drawing.Size(86, 17)
        Me.Chk_Fotos.TabIndex = 28
        Me.Chk_Fotos.Text = "Cargar Fotos"
        Me.Chk_Fotos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(557, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Color Secundario"
        '
        'Cbo_Color2
        '
        Me.Cbo_Color2.Location = New System.Drawing.Point(656, 275)
        Me.Cbo_Color2.Name = "Cbo_Color2"
        Me.Cbo_Color2.Size = New System.Drawing.Size(142, 84)
        Me.Cbo_Color2.TabIndex = 4
        '
        'Cbo_Color1
        '
        Me.Cbo_Color1.Location = New System.Drawing.Point(370, 275)
        Me.Cbo_Color1.Name = "Cbo_Color1"
        Me.Cbo_Color1.Size = New System.Drawing.Size(142, 84)
        Me.Cbo_Color1.TabIndex = 3
        '
        'Cbo_Material
        '
        Me.Cbo_Material.Location = New System.Drawing.Point(83, 270)
        Me.Cbo_Material.Name = "Cbo_Material"
        Me.Cbo_Material.Size = New System.Drawing.Size(142, 84)
        Me.Cbo_Material.TabIndex = 2
        '
        'PBox8
        '
        Me.PBox8.Location = New System.Drawing.Point(762, 153)
        Me.PBox8.Name = "PBox8"
        Me.PBox8.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox8.Size = New System.Drawing.Size(100, 96)
        Me.PBox8.TabIndex = 12
        '
        'PBox10
        '
        Me.PBox10.Location = New System.Drawing.Point(974, 153)
        Me.PBox10.Name = "PBox10"
        Me.PBox10.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox10.Size = New System.Drawing.Size(100, 96)
        Me.PBox10.TabIndex = 14
        '
        'PBox4
        '
        Me.PBox4.Location = New System.Drawing.Point(868, 51)
        Me.PBox4.Name = "PBox4"
        Me.PBox4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox4.Size = New System.Drawing.Size(100, 96)
        Me.PBox4.TabIndex = 8
        '
        'PBox9
        '
        Me.PBox9.Location = New System.Drawing.Point(868, 153)
        Me.PBox9.Name = "PBox9"
        Me.PBox9.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox9.Size = New System.Drawing.Size(100, 96)
        Me.PBox9.TabIndex = 13
        '
        'PBox3
        '
        Me.PBox3.Location = New System.Drawing.Point(762, 51)
        Me.PBox3.Name = "PBox3"
        Me.PBox3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox3.Size = New System.Drawing.Size(100, 96)
        Me.PBox3.TabIndex = 7
        '
        'PBox6
        '
        Me.PBox6.Location = New System.Drawing.Point(550, 153)
        Me.PBox6.Name = "PBox6"
        Me.PBox6.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox6.Size = New System.Drawing.Size(100, 96)
        Me.PBox6.TabIndex = 10
        '
        'PBox2
        '
        Me.PBox2.Location = New System.Drawing.Point(656, 51)
        Me.PBox2.Name = "PBox2"
        Me.PBox2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox2.Size = New System.Drawing.Size(100, 96)
        Me.PBox2.TabIndex = 6
        '
        'PBox7
        '
        Me.PBox7.Location = New System.Drawing.Point(656, 153)
        Me.PBox7.Name = "PBox7"
        Me.PBox7.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox7.Size = New System.Drawing.Size(100, 96)
        Me.PBox7.TabIndex = 11
        '
        'PBox5
        '
        Me.PBox5.Location = New System.Drawing.Point(974, 51)
        Me.PBox5.Name = "PBox5"
        Me.PBox5.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox5.Size = New System.Drawing.Size(100, 96)
        Me.PBox5.TabIndex = 9
        '
        'PBox1
        '
        Me.PBox1.Location = New System.Drawing.Point(550, 51)
        Me.PBox1.Name = "PBox1"
        Me.PBox1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PBox1.Size = New System.Drawing.Size(100, 96)
        Me.PBox1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(303, 277)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Color"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 277)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Material"
        '
        'Mem_Descripcion
        '
        Me.Mem_Descripcion.Location = New System.Drawing.Point(83, 12)
        Me.Mem_Descripcion.Name = "Mem_Descripcion"
        Me.Mem_Descripcion.Size = New System.Drawing.Size(429, 252)
        Me.Mem_Descripcion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Descripción"
        '
        'Pnl_Editar
        '
        Me.Pnl_Editar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pnl_Editar.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Editar.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Editar.Location = New System.Drawing.Point(8, 479)
        Me.Pnl_Editar.Name = "Pnl_Editar"
        Me.Pnl_Editar.Size = New System.Drawing.Size(1083, 51)
        Me.Pnl_Editar.TabIndex = 3
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.Btn_Cancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Cancelar.Location = New System.Drawing.Point(981, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(50, 49)
        Me.Btn_Cancelar.TabIndex = 16
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.ImageOptions.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.Btn_Aceptar.Location = New System.Drawing.Point(1031, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(50, 49)
        Me.Btn_Aceptar.TabIndex = 15
        '
        'frmProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 534)
        Me.Controls.Add(Me.Pnl_Editar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProducts"
        Me.Text = "Modelos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Txt_DescripMarca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_EstiloF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Modelo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Marca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt_Titulo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Cbo_Color2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_Color1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo_Material, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox10.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox9.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mem_Descripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Editar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Pnl_Editar As Panel
    Friend WithEvents Btn_Cancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Aceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Lbl_Titulo As Label
    Friend WithEvents Txt_Titulo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Mem_Descripcion As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Modelo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_Marca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Modelo As Label
    Friend WithEvents PBox1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PBox4 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox9 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox3 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox6 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox2 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox7 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox5 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox8 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox10 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PBox As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents Lbl_Estructura As Label
    Friend WithEvents Cbo_Material As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents Label4 As Label
    Friend WithEvents Cbo_Color2 As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents Cbo_Color1 As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents Txt_DescripMarca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txt_EstiloF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Chk_Fotos As CheckBox
    Friend WithEvents CachedCrystalReport11 As CachedCrystalReport1
End Class
