<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoFotosBultos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoFotosBultos))
        Me.Pnl_Foto = New System.Windows.Forms.Panel
        Me.Btn_Sig = New System.Windows.Forms.Button
        Me.Btn_Ant = New System.Windows.Forms.Button
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Btn_AceptarF = New System.Windows.Forms.Button
        Me.Btn_EliminarF = New System.Windows.Forms.Button
        Me.Btn_NuevoF = New System.Windows.Forms.Button
        Me.Txt_NoFoto = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Pnl_Foto.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Foto
        '
        Me.Pnl_Foto.Controls.Add(Me.Btn_Sig)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Ant)
        Me.Pnl_Foto.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Foto.Controls.Add(Me.Txt_Ruta)
        Me.Pnl_Foto.Controls.Add(Me.Btn_AceptarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_EliminarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_NuevoF)
        Me.Pnl_Foto.Controls.Add(Me.Txt_NoFoto)
        Me.Pnl_Foto.Controls.Add(Me.Label14)
        Me.Pnl_Foto.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(433, 69)
        Me.Pnl_Foto.TabIndex = 4
        '
        'Btn_Sig
        '
        Me.Btn_Sig.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sig.Image = Global.SIRCO.My.Resources.Resources.arrowleftverde
        Me.Btn_Sig.Location = New System.Drawing.Point(359, 3)
        Me.Btn_Sig.Name = "Btn_Sig"
        Me.Btn_Sig.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Sig.TabIndex = 32
        Me.Btn_Sig.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Sig.UseVisualStyleBackColor = True
        '
        'Btn_Ant
        '
        Me.Btn_Ant.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Ant.Image = Global.SIRCO.My.Resources.Resources.arrowright
        Me.Btn_Ant.Location = New System.Drawing.Point(302, 3)
        Me.Btn_Ant.Name = "Btn_Ant"
        Me.Btn_Ant.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Ant.TabIndex = 31
        Me.Btn_Ant.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Ant.UseVisualStyleBackColor = True
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
        Me.Btn_AceptarF.Location = New System.Drawing.Point(249, 3)
        Me.Btn_AceptarF.Name = "Btn_AceptarF"
        Me.Btn_AceptarF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_AceptarF.TabIndex = 20
        Me.Btn_AceptarF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_AceptarF.UseVisualStyleBackColor = True
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
        Me.Label14.UseWaitCursor = True
        Me.Label14.Visible = False
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
        Me.PBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.PBox.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(0, 0)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(524, 438)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 3
        Me.PBox.TabStop = False
        '
        'frmCatalogoFotosBultos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 438)
        Me.Controls.Add(Me.Pnl_Foto)
        Me.Controls.Add(Me.PBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCatalogoFotosBultos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Fotos Bultos"
        Me.Pnl_Foto.ResumeLayout(False)
        Me.Pnl_Foto.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Pnl_Foto As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Btn_EliminarF As System.Windows.Forms.Button
    Friend WithEvents Btn_NuevoF As System.Windows.Forms.Button
    Friend WithEvents Txt_NoFoto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Btn_AceptarF As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Btn_Sig As System.Windows.Forms.Button
    Friend WithEvents Btn_Ant As System.Windows.Forms.Button
End Class
