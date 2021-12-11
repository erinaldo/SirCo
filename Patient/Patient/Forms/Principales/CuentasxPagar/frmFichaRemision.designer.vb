<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaRemision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFichaRemision))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Folio = New System.Windows.Forms.TextBox
        Me.Txt_Importe = New System.Windows.Forms.TextBox
        Me.DTFicha = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl_Foto = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Btn_AceptarF = New System.Windows.Forms.Button
        Me.Btn_EliminarF = New System.Windows.Forms.Button
        Me.Btn_NuevoF = New System.Windows.Forms.Button
        Me.Txt_NoFoto = New System.Windows.Forms.TextBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Txt_FolioF = New System.Windows.Forms.TextBox
        Me.Txt_IdFolio = New System.Windows.Forms.TextBox
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Foto.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFolio)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_FolioF)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Folio)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Importe)
        Me.Pnl_Edicion.Controls.Add(Me.DTFicha)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Foto)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 6)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(466, 155)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(246, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 18)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "PAGADO"
        Me.Label4.Visible = False
        '
        'Txt_Folio
        '
        Me.Txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Folio.Location = New System.Drawing.Point(378, 11)
        Me.Txt_Folio.Name = "Txt_Folio"
        Me.Txt_Folio.Size = New System.Drawing.Size(33, 20)
        Me.Txt_Folio.TabIndex = 11
        Me.Txt_Folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_Folio.Visible = False
        '
        'Txt_Importe
        '
        Me.Txt_Importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Importe.Location = New System.Drawing.Point(110, 43)
        Me.Txt_Importe.MaxLength = 10
        Me.Txt_Importe.Name = "Txt_Importe"
        Me.Txt_Importe.Size = New System.Drawing.Size(122, 20)
        Me.Txt_Importe.TabIndex = 10
        Me.Txt_Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DTFicha
        '
        Me.DTFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFicha.Location = New System.Drawing.Point(110, 11)
        Me.DTFicha.Name = "DTFicha"
        Me.DTFicha.Size = New System.Drawing.Size(251, 20)
        Me.DTFicha.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Importe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha Depósito"
        '
        'Pnl_Foto
        '
        Me.Pnl_Foto.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Foto.Controls.Add(Me.Txt_Ruta)
        Me.Pnl_Foto.Controls.Add(Me.Btn_AceptarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_EliminarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_NuevoF)
        Me.Pnl_Foto.Controls.Add(Me.Txt_NoFoto)
        Me.Pnl_Foto.Location = New System.Drawing.Point(6, 82)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(394, 58)
        Me.Pnl_Foto.TabIndex = 4
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(120, 5)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Limpiar.TabIndex = 30
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ruta.Location = New System.Drawing.Point(346, 32)
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
        Me.Btn_AceptarF.Location = New System.Drawing.Point(289, 5)
        Me.Btn_AceptarF.Name = "Btn_AceptarF"
        Me.Btn_AceptarF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_AceptarF.TabIndex = 20
        Me.Btn_AceptarF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_AceptarF.UseVisualStyleBackColor = True
        '
        'Btn_EliminarF
        '
        Me.Btn_EliminarF.Enabled = False
        Me.Btn_EliminarF.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_EliminarF.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_EliminarF.Location = New System.Drawing.Point(232, 5)
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
        Me.Btn_NuevoF.Location = New System.Drawing.Point(175, 5)
        Me.Btn_NuevoF.Name = "Btn_NuevoF"
        Me.Btn_NuevoF.Size = New System.Drawing.Size(51, 47)
        Me.Btn_NuevoF.TabIndex = 16
        Me.Btn_NuevoF.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_NuevoF.UseVisualStyleBackColor = True
        '
        'Txt_NoFoto
        '
        Me.Txt_NoFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoFoto.Location = New System.Drawing.Point(346, 5)
        Me.Txt_NoFoto.MaxLength = 3
        Me.Txt_NoFoto.Name = "Txt_NoFoto"
        Me.Txt_NoFoto.Size = New System.Drawing.Size(34, 20)
        Me.Txt_NoFoto.TabIndex = 15
        Me.Txt_NoFoto.Visible = False
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
        Me.PBox.Location = New System.Drawing.Point(497, 6)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(298, 243)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 3
        Me.PBox.TabStop = False
        '
        'Txt_FolioF
        '
        Me.Txt_FolioF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_FolioF.Location = New System.Drawing.Point(378, 43)
        Me.Txt_FolioF.Name = "Txt_FolioF"
        Me.Txt_FolioF.Size = New System.Drawing.Size(33, 20)
        Me.Txt_FolioF.TabIndex = 13
        Me.Txt_FolioF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_FolioF.Visible = False
        '
        'Txt_IdFolio
        '
        Me.Txt_IdFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFolio.Location = New System.Drawing.Point(417, 11)
        Me.Txt_IdFolio.Name = "Txt_IdFolio"
        Me.Txt_IdFolio.Size = New System.Drawing.Size(33, 20)
        Me.Txt_IdFolio.TabIndex = 14
        Me.Txt_IdFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txt_IdFolio.Visible = False
        '
        'frmFichaRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 257)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFichaRemision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ficha de Depósito"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Foto.ResumeLayout(False)
        Me.Pnl_Foto.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Pnl_Foto As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Btn_EliminarF As System.Windows.Forms.Button
    Friend WithEvents Btn_NuevoF As System.Windows.Forms.Button
    Friend WithEvents Txt_NoFoto As System.Windows.Forms.TextBox
    Friend WithEvents Btn_AceptarF As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents DTFicha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_FolioF As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdFolio As System.Windows.Forms.TextBox
End Class
