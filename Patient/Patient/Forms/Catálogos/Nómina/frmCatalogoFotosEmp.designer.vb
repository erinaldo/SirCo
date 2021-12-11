<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoFotosEmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoFotosEmp))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Pnl_Foto = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Txt_Ruta = New System.Windows.Forms.TextBox
        Me.Btn_AceptarF = New System.Windows.Forms.Button
        Me.Btn_Sig = New System.Windows.Forms.Button
        Me.Btn_Ant = New System.Windows.Forms.Button
        Me.Btn_EliminarF = New System.Windows.Forms.Button
        Me.Btn_NuevoF = New System.Windows.Forms.Button
        Me.Txt_Nombre = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Empleado = New System.Windows.Forms.TextBox
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
        Me.Pnl_Edicion.Controls.Add(Me.Pnl_Foto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Nombre)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Empleado)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 246)
        Me.Pnl_Edicion.TabIndex = 0
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
        Me.Pnl_Foto.Location = New System.Drawing.Point(3, 57)
        Me.Pnl_Foto.Name = "Pnl_Foto"
        Me.Pnl_Foto.Size = New System.Drawing.Size(433, 107)
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
        Me.Txt_Ruta.Size = New System.Drawing.Size(235, 20)
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
        'Txt_Nombre
        '
        Me.Txt_Nombre.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Nombre.Enabled = False
        Me.Txt_Nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nombre.Location = New System.Drawing.Point(132, 13)
        Me.Txt_Nombre.Name = "Txt_Nombre"
        Me.Txt_Nombre.ReadOnly = True
        Me.Txt_Nombre.Size = New System.Drawing.Size(290, 20)
        Me.Txt_Nombre.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Empleado"
        '
        'Txt_Empleado
        '
        Me.Txt_Empleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Empleado.Location = New System.Drawing.Point(84, 13)
        Me.Txt_Empleado.MaxLength = 4
        Me.Txt_Empleado.Name = "Txt_Empleado"
        Me.Txt_Empleado.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Empleado.TabIndex = 1
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
        'frmCatalogoFotosEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 262)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoFotosEmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Empleado"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Foto.ResumeLayout(False)
        Me.Pnl_Foto.PerformLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_Empleado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Nombre As System.Windows.Forms.TextBox
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Pnl_Foto As System.Windows.Forms.Panel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Btn_Sig As System.Windows.Forms.Button
    Friend WithEvents Btn_Ant As System.Windows.Forms.Button
    Friend WithEvents Btn_EliminarF As System.Windows.Forms.Button
    Friend WithEvents Btn_NuevoF As System.Windows.Forms.Button
    Friend WithEvents Btn_AceptarF As System.Windows.Forms.Button
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
End Class
