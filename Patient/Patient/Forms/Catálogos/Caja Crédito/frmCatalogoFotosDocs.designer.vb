<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoFotosDocs
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
        Me.components = New System.ComponentModel.Container
        Me.Pnl_Foto = New System.Windows.Forms.Panel
        Me.Btn_Ant = New System.Windows.Forms.Button
        Me.Btn_Sig = New System.Windows.Forms.Button
        Me.txt_numFoto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_pertenece = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_EliminarF = New System.Windows.Forms.Button
        Me.Btn_NuevoF = New System.Windows.Forms.Button
        Me.Txt_NombreFoto = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Pnl_Foto.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Foto
        '
        Me.Pnl_Foto.Controls.Add(Me.Btn_Ant)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Sig)
        Me.Pnl_Foto.Controls.Add(Me.txt_numFoto)
        Me.Pnl_Foto.Controls.Add(Me.Label2)
        Me.Pnl_Foto.Controls.Add(Me.txt_pertenece)
        Me.Pnl_Foto.Controls.Add(Me.Label1)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Foto.Controls.Add(Me.Txt_Ruta)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Foto.Controls.Add(Me.Btn_EliminarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_NuevoF)
        Me.Pnl_Foto.Controls.Add(Me.Txt_NombreFoto)
        Me.Pnl_Foto.Controls.Add(Me.Label14)
        Me.Pnl_Foto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Foto.Location = New System.Drawing.Point(0, 566)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(728, 76)
        Me.Pnl_Foto.TabIndex = 6
        '
        'Btn_Ant
        '
        Me.Btn_Ant.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Ant.Image = Global.SIRCO.My.Resources.Resources.arrowright
        Me.Btn_Ant.Location = New System.Drawing.Point(325, 26)
        Me.Btn_Ant.Name = "Btn_Ant"
        Me.Btn_Ant.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Ant.TabIndex = 39
        Me.Btn_Ant.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Ant.UseVisualStyleBackColor = True
        '
        'Btn_Sig
        '
        Me.Btn_Sig.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sig.Image = Global.SIRCO.My.Resources.Resources.arrowleftverde
        Me.Btn_Sig.Location = New System.Drawing.Point(382, 26)
        Me.Btn_Sig.Name = "Btn_Sig"
        Me.Btn_Sig.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Sig.TabIndex = 38
        Me.Btn_Sig.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Sig.UseVisualStyleBackColor = True
        '
        'txt_numFoto
        '
        Me.txt_numFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_numFoto.Location = New System.Drawing.Point(282, 10)
        Me.txt_numFoto.MaxLength = 40
        Me.txt_numFoto.Name = "txt_numFoto"
        Me.txt_numFoto.Size = New System.Drawing.Size(37, 20)
        Me.txt_numFoto.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "No. Foto:"
        Me.Label2.UseWaitCursor = True
        '
        'txt_pertenece
        '
        Me.txt_pertenece.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pertenece.Location = New System.Drawing.Point(71, 39)
        Me.txt_pertenece.MaxLength = 255
        Me.txt_pertenece.Name = "txt_pertenece"
        Me.txt_pertenece.Size = New System.Drawing.Size(248, 20)
        Me.txt_pertenece.TabIndex = 35
        Me.txt_pertenece.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Pertenece:"
        Me.Label1.UseWaitCursor = True
        Me.Label1.Visible = False
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(442, 26)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Limpiar.TabIndex = 30
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ruta.Location = New System.Drawing.Point(439, 6)
        Me.Txt_Ruta.MaxLength = 255
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.Size = New System.Drawing.Size(130, 20)
        Me.Txt_Ruta.TabIndex = 21
        Me.Txt_Ruta.Visible = False
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Enabled = False
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(603, 26)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Aceptar.TabIndex = 20
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_EliminarF
        '
        Me.Btn_EliminarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EliminarF.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_EliminarF.Location = New System.Drawing.Point(549, 26)
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
        Me.Btn_NuevoF.Location = New System.Drawing.Point(495, 26)
        Me.Btn_NuevoF.Name = "Btn_NuevoF"
        Me.Btn_NuevoF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_NuevoF.TabIndex = 16
        Me.Btn_NuevoF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_NuevoF.UseVisualStyleBackColor = True
        '
        'Txt_NombreFoto
        '
        Me.Txt_NombreFoto.Enabled = False
        Me.Txt_NombreFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreFoto.Location = New System.Drawing.Point(71, 10)
        Me.Txt_NombreFoto.MaxLength = 40
        Me.Txt_NombreFoto.Name = "Txt_NombreFoto"
        Me.Txt_NombreFoto.Size = New System.Drawing.Size(151, 20)
        Me.Txt_NombreFoto.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Imagen:"
        Me.Label14.UseWaitCursor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'PBox
        '
        Me.PBox.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(6, 2)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(710, 561)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 5
        Me.PBox.TabStop = False
        '
        'frmCatalogoFotosDocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 642)
        Me.Controls.Add(Me.Pnl_Foto)
        Me.Controls.Add(Me.PBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmCatalogoFotosDocs"
        Me.Text = "Catalogo Documento "
        Me.Pnl_Foto.ResumeLayout(False)
        Me.Pnl_Foto.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Foto As System.Windows.Forms.Panel
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_EliminarF As System.Windows.Forms.Button
    Friend WithEvents Btn_NuevoF As System.Windows.Forms.Button
    Friend WithEvents Txt_NombreFoto As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_pertenece As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_numFoto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Btn_Sig As System.Windows.Forms.Button
    Friend WithEvents Btn_Ant As System.Windows.Forms.Button
End Class
