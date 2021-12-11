<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoFirmasDistrib
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoFirmasDistrib))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Pnl_Foto = New System.Windows.Forms.Panel
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Btn_Sig = New System.Windows.Forms.Button
        Me.Btn_Ant = New System.Windows.Forms.Button
        Me.Txt_NoFoto = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Txt_DescripDistrib = New System.Windows.Forms.TextBox
        Me.Txt_IdDistrib = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Foto.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Foto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDistrib)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDistrib)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(468, 238)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(390, 165)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Cancelar.TabIndex = 32
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Pnl_Foto
        '
        Me.Pnl_Foto.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Foto.Controls.Add(Me.Txt_Ruta)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Sig)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Ant)
        Me.Pnl_Foto.Controls.Add(Me.Txt_NoFoto)
        Me.Pnl_Foto.Controls.Add(Me.Label14)
        Me.Pnl_Foto.Location = New System.Drawing.Point(28, 60)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(433, 88)
        Me.Pnl_Foto.TabIndex = 58
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(362, 3)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Aceptar.TabIndex = 31
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(192, 3)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Limpiar.TabIndex = 30
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ruta.Location = New System.Drawing.Point(40, 30)
        Me.Txt_Ruta.MaxLength = 3
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.Size = New System.Drawing.Size(34, 20)
        Me.Txt_Ruta.TabIndex = 21
        Me.Txt_Ruta.Visible = False
        '
        'Btn_Sig
        '
        Me.Btn_Sig.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sig.Image = Global.SIRCO.My.Resources.Resources.arrowleftverde
        Me.Btn_Sig.Location = New System.Drawing.Point(305, 3)
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
        'Txt_NoFoto
        '
        Me.Txt_NoFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoFoto.Location = New System.Drawing.Point(40, 3)
        Me.Txt_NoFoto.MaxLength = 3
        Me.Txt_NoFoto.Name = "Txt_NoFoto"
        Me.Txt_NoFoto.Size = New System.Drawing.Size(34, 20)
        Me.Txt_NoFoto.TabIndex = 15
        Me.Txt_NoFoto.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Foto"
        Me.Label14.Visible = False
        '
        'Txt_DescripDistrib
        '
        Me.Txt_DescripDistrib.Enabled = False
        Me.Txt_DescripDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDistrib.Location = New System.Drawing.Point(152, 22)
        Me.Txt_DescripDistrib.MaxLength = 6
        Me.Txt_DescripDistrib.Name = "Txt_DescripDistrib"
        Me.Txt_DescripDistrib.Size = New System.Drawing.Size(294, 20)
        Me.Txt_DescripDistrib.TabIndex = 57
        '
        'Txt_IdDistrib
        '
        Me.Txt_IdDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDistrib.Location = New System.Drawing.Point(70, 22)
        Me.Txt_IdDistrib.MaxLength = 6
        Me.Txt_IdDistrib.Name = "Txt_IdDistrib"
        Me.Txt_IdDistrib.Size = New System.Drawing.Size(71, 20)
        Me.Txt_IdDistrib.TabIndex = 56
        Me.Txt_IdDistrib.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Distribuidor"
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
        Me.PBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBox.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(486, 3)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(298, 238)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 59
        Me.PBox.TabStop = False
        '
        'frmCatalogoFirmasDistrib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 247)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoFirmasDistrib"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Firmas de Distribuidor"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Foto.ResumeLayout(False)
        Me.Pnl_Foto.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Txt_IdDistrib As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDistrib As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Foto As System.Windows.Forms.Panel
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Sig As System.Windows.Forms.Button
    Friend WithEvents Btn_Ant As System.Windows.Forms.Button
    Friend WithEvents Txt_NoFoto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
End Class
