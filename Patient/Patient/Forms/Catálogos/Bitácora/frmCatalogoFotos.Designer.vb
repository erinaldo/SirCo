<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoFotos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoFotos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Pnl_Foto = New System.Windows.Forms.Panel()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Txt_Ruta = New System.Windows.Forms.TextBox()
        Me.Btn_AceptarF = New System.Windows.Forms.Button()
        Me.Btn_Sig = New System.Windows.Forms.Button()
        Me.Btn_Ant = New System.Windows.Forms.Button()
        Me.Btn_EliminarF = New System.Windows.Forms.Button()
        Me.Btn_NuevoF = New System.Windows.Forms.Button()
        Me.Txt_NoFoto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.Txt_Descripc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Estilof = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Estilon = New System.Windows.Forms.TextBox()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Lbl_Marca = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.PBox = New System.Windows.Forms.PictureBox()
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Foto.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Button2)
        Me.Pnl_Edicion.Controls.Add(Me.Button1)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Foto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Descripc)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Estilof)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Estilon)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 246)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Button2.Location = New System.Drawing.Point(459, 186)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(51, 47)
        Me.Button2.TabIndex = 27
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(477, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 48)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Pnl_Foto
        '
        Me.Pnl_Foto.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Foto.Controls.Add(Me.Txt_Ruta)
        Me.Pnl_Foto.Controls.Add(Me.Btn_AceptarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Sig)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Ant)
        Me.Pnl_Foto.Controls.Add(Me.Btn_EliminarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_NuevoF)
        Me.Pnl_Foto.Controls.Add(Me.Txt_NoFoto)
        Me.Pnl_Foto.Controls.Add(Me.Label14)
        Me.Pnl_Foto.Location = New System.Drawing.Point(20, 106)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(433, 100)
        Me.Pnl_Foto.TabIndex = 4
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(80, 3)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Limpiar.TabIndex = 30
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ruta.Location = New System.Drawing.Point(133, 98)
        Me.Txt_Ruta.MaxLength = 3
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.Size = New System.Drawing.Size(34, 20)
        Me.Txt_Ruta.TabIndex = 21
        Me.Txt_Ruta.Visible = False
        '
        'Btn_AceptarF
        '
        Me.Btn_AceptarF.Enabled = False
        Me.Btn_AceptarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_AceptarF.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_AceptarF.Location = New System.Drawing.Point(363, 3)
        Me.Btn_AceptarF.Name = "Btn_AceptarF"
        Me.Btn_AceptarF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_AceptarF.TabIndex = 20
        Me.Btn_AceptarF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_AceptarF.UseVisualStyleBackColor = True
        '
        'Btn_Sig
        '
        Me.Btn_Sig.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sig.Image = Global.SIRCO.My.Resources.Resources.arrowleftverde
        Me.Btn_Sig.Location = New System.Drawing.Point(306, 3)
        Me.Btn_Sig.Name = "Btn_Sig"
        Me.Btn_Sig.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Sig.TabIndex = 19
        Me.Btn_Sig.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Sig.UseVisualStyleBackColor = True
        '
        'Btn_Ant
        '
        Me.Btn_Ant.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Ant.Image = Global.SIRCO.My.Resources.Resources.arrowright
        Me.Btn_Ant.Location = New System.Drawing.Point(249, 3)
        Me.Btn_Ant.Name = "Btn_Ant"
        Me.Btn_Ant.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Ant.TabIndex = 18
        Me.Btn_Ant.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Ant.UseVisualStyleBackColor = True
        '
        'Btn_EliminarF
        '
        Me.Btn_EliminarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EliminarF.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_EliminarF.Location = New System.Drawing.Point(192, 3)
        Me.Btn_EliminarF.Name = "Btn_EliminarF"
        Me.Btn_EliminarF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_EliminarF.TabIndex = 17
        Me.Btn_EliminarF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_EliminarF.UseVisualStyleBackColor = True
        '
        'Btn_NuevoF
        '
        Me.Btn_NuevoF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_NuevoF.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_NuevoF.Location = New System.Drawing.Point(135, 3)
        Me.Btn_NuevoF.Name = "Btn_NuevoF"
        Me.Btn_NuevoF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_NuevoF.TabIndex = 16
        Me.Btn_NuevoF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_NuevoF.UseVisualStyleBackColor = True
        '
        'Txt_NoFoto
        '
        Me.Txt_NoFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoFoto.Location = New System.Drawing.Point(40, 3)
        Me.Txt_NoFoto.MaxLength = 3
        Me.Txt_NoFoto.Name = "Txt_NoFoto"
        Me.Txt_NoFoto.Size = New System.Drawing.Size(34, 20)
        Me.Txt_NoFoto.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Foto"
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(264, 16)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(290, 20)
        Me.Txt_DescripMarca.TabIndex = 25
        '
        'Txt_Descripc
        '
        Me.Txt_Descripc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripc.Location = New System.Drawing.Point(113, 40)
        Me.Txt_Descripc.MaxLength = 30
        Me.Txt_Descripc.Name = "Txt_Descripc"
        Me.Txt_Descripc.Size = New System.Drawing.Size(440, 20)
        Me.Txt_Descripc.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descripción Corta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Estilo Fábrica"
        '
        'Txt_Estilof
        '
        Me.Txt_Estilof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilof.Location = New System.Drawing.Point(113, 66)
        Me.Txt_Estilof.MaxLength = 14
        Me.Txt_Estilof.Name = "Txt_Estilof"
        Me.Txt_Estilof.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Estilof.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Estilo Nuestro"
        '
        'Txt_Estilon
        '
        Me.Txt_Estilon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilon.Location = New System.Drawing.Point(153, 16)
        Me.Txt_Estilon.MaxLength = 7
        Me.Txt_Estilon.Name = "Txt_Estilon"
        Me.Txt_Estilon.Size = New System.Drawing.Size(60, 20)
        Me.Txt_Estilon.TabIndex = 2
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(113, 16)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(34, 20)
        Me.Txt_Marca.TabIndex = 1
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.Location = New System.Drawing.Point(219, 19)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Marca.TabIndex = 0
        Me.Lbl_Marca.Text = "Marca"
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'PBox
        '
        Me.PBox.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(577, 3)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(298, 246)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 3
        Me.PBox.TabStop = False
        '
        'frmCatalogoFotos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 262)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoFotos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Fotos"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Foto.ResumeLayout(False)
        Me.Pnl_Foto.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Estilon As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Estilof As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Descripc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Pnl_Foto As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Btn_Sig As System.Windows.Forms.Button
    Friend WithEvents Btn_Ant As System.Windows.Forms.Button
    Friend WithEvents Btn_EliminarF As System.Windows.Forms.Button
    Friend WithEvents Btn_NuevoF As System.Windows.Forms.Button
    Friend WithEvents Txt_NoFoto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Btn_AceptarF As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As Button
End Class
