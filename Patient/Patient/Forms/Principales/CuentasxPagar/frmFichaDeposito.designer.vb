<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaDeposito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFichaDeposito))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txt_Banco = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Dt_Fecha = New System.Windows.Forms.DateTimePicker
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Txt_NoCheque = New System.Windows.Forms.TextBox
        Me.Txt_Liquidacion = New System.Windows.Forms.TextBox
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
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Foto.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Banco)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Dt_Fecha)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Proveedor)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NoCheque)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Liquidacion)
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Foto)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 6)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(360, 243)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Banco"
        '
        'Txt_Banco
        '
        Me.Txt_Banco.Enabled = False
        Me.Txt_Banco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Banco.Location = New System.Drawing.Point(88, 63)
        Me.Txt_Banco.Name = "Txt_Banco"
        Me.Txt_Banco.Size = New System.Drawing.Size(114, 20)
        Me.Txt_Banco.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "N° Cheque"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Liquidación"
        '
        'Dt_Fecha
        '
        Me.Dt_Fecha.Enabled = False
        Me.Dt_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dt_Fecha.Location = New System.Drawing.Point(88, 141)
        Me.Dt_Fecha.Name = "Dt_Fecha"
        Me.Dt_Fecha.Size = New System.Drawing.Size(200, 20)
        Me.Dt_Fecha.TabIndex = 8
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.Enabled = False
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(88, 115)
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.Size = New System.Drawing.Size(240, 20)
        Me.Txt_Proveedor.TabIndex = 7
        '
        'Txt_NoCheque
        '
        Me.Txt_NoCheque.Enabled = False
        Me.Txt_NoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoCheque.Location = New System.Drawing.Point(88, 89)
        Me.Txt_NoCheque.Name = "Txt_NoCheque"
        Me.Txt_NoCheque.Size = New System.Drawing.Size(114, 20)
        Me.Txt_NoCheque.TabIndex = 6
        '
        'Txt_Liquidacion
        '
        Me.Txt_Liquidacion.Enabled = False
        Me.Txt_Liquidacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Liquidacion.Location = New System.Drawing.Point(88, 37)
        Me.Txt_Liquidacion.Name = "Txt_Liquidacion"
        Me.Txt_Liquidacion.Size = New System.Drawing.Size(114, 20)
        Me.Txt_Liquidacion.TabIndex = 5
        '
        'Pnl_Foto
        '
        Me.Pnl_Foto.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Foto.Controls.Add(Me.Txt_Ruta)
        Me.Pnl_Foto.Controls.Add(Me.Btn_AceptarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_EliminarF)
        Me.Pnl_Foto.Controls.Add(Me.Btn_NuevoF)
        Me.Pnl_Foto.Controls.Add(Me.Txt_NoFoto)
        Me.Pnl_Foto.Location = New System.Drawing.Point(3, 178)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(350, 58)
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
        Me.PBox.Location = New System.Drawing.Point(378, 6)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(298, 243)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 3
        Me.PBox.TabStop = False
        '
        'frmFichaDeposito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 257)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFichaDeposito"
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dt_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NoCheque As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Liquidacion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Banco As System.Windows.Forms.TextBox
End Class
