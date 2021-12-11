<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoVisitaDistrib
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    Me.components = New System.ComponentModel.Container
    '    Me.Pnl_Botones = New System.Windows.Forms.Panel
    '    Me.Btn_Cancelar = New System.Windows.Forms.Button
    '    Me.Btn_Aceptar = New System.Windows.Forms.Button
    '    Me.txt_nombre = New System.Windows.Forms.TextBox
    '    Me.Label1 = New System.Windows.Forms.Label
    '    Me.txt_id = New System.Windows.Forms.TextBox
    '    Me.txt_nomDistrib = New System.Windows.Forms.TextBox
    '    Me.Label2 = New System.Windows.Forms.Label
    '    Me.txt_Distrib = New System.Windows.Forms.TextBox
    '    Me.Panel1 = New System.Windows.Forms.Panel
    '    Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
    '    Me.Label3 = New System.Windows.Forms.Label
    '    Me.Label4 = New System.Windows.Forms.Label
    '    Me.Label5 = New System.Windows.Forms.Label
    '    Me.Label6 = New System.Windows.Forms.Label
    '    Me.txt_resultado = New System.Windows.Forms.TextBox
    '    Me.Label7 = New System.Windows.Forms.Label
    '    Me.txt_impXcobrar = New System.Windows.Forms.TextBox
    '    Me.Label8 = New System.Windows.Forms.Label
    '    Me.txt_importe = New System.Windows.Forms.TextBox
    '    Me.Label9 = New System.Windows.Forms.Label
    '    Me.Cbo_VisitoAval = New System.Windows.Forms.ComboBox
    '    Me.Msk_horavisita = New System.Windows.Forms.MaskedTextBox
    '    Me.Msk_horadisponible = New System.Windows.Forms.MaskedTextBox
    '    Me.Panel2 = New System.Windows.Forms.Panel
    '    Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
    '    Me.Label10 = New System.Windows.Forms.Label
    '    Me.txt_folio = New System.Windows.Forms.TextBox
    '    Me.Pnl_Botones.SuspendLayout()
    '    Me.Panel1.SuspendLayout()
    '    Me.Panel2.SuspendLayout()
    '    Me.SuspendLayout()
    '    '
    '    'Pnl_Botones
    '    '
    '    Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    '    Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
    '    Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
    '    Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
    '    Me.Pnl_Botones.Location = New System.Drawing.Point(0, 336)
    '    Me.Pnl_Botones.Name = "Pnl_Botones"
    '    Me.Pnl_Botones.Size = New System.Drawing.Size(564, 56)
    '    Me.Pnl_Botones.TabIndex = 8
    '    '
    '    'Btn_Cancelar
    '    '
    '    Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
    '    Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
    '    Me.Btn_Cancelar.Location = New System.Drawing.Point(458, 0)
    '    Me.Btn_Cancelar.Name = "Btn_Cancelar"
    '    Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
    '    Me.Btn_Cancelar.TabIndex = 51
    '    Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.Btn_Cancelar.UseVisualStyleBackColor = True
    '    '
    '    'Btn_Aceptar
    '    '
    '    Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
    '    Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
    '    Me.Btn_Aceptar.Location = New System.Drawing.Point(509, 0)
    '    Me.Btn_Aceptar.Name = "Btn_Aceptar"
    '    Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
    '    Me.Btn_Aceptar.TabIndex = 50
    '    Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '    Me.Btn_Aceptar.UseVisualStyleBackColor = True
    '    '
    '    'txt_nombre
    '    '
    '    Me.txt_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_nombre.Location = New System.Drawing.Point(180, 6)
    '    Me.txt_nombre.Name = "txt_nombre"
    '    Me.txt_nombre.Size = New System.Drawing.Size(305, 20)
    '    Me.txt_nombre.TabIndex = 124
    '    '
    '    'Label1
    '    '
    '    Me.Label1.AutoSize = True
    '    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label1.Location = New System.Drawing.Point(14, 9)
    '    Me.Label1.Name = "Label1"
    '    Me.Label1.Size = New System.Drawing.Size(86, 13)
    '    Me.Label1.TabIndex = 125
    '    Me.Label1.Text = "Cobrador/Gestor"
    '    '
    '    'txt_id
    '    '
    '    Me.txt_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_id.Location = New System.Drawing.Point(106, 6)
    '    Me.txt_id.Name = "txt_id"
    '    Me.txt_id.Size = New System.Drawing.Size(68, 20)
    '    Me.txt_id.TabIndex = 123
    '    '
    '    'txt_nomDistrib
    '    '
    '    Me.txt_nomDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_nomDistrib.Location = New System.Drawing.Point(180, 39)
    '    Me.txt_nomDistrib.Name = "txt_nomDistrib"
    '    Me.txt_nomDistrib.Size = New System.Drawing.Size(305, 20)
    '    Me.txt_nomDistrib.TabIndex = 127
    '    '
    '    'Label2
    '    '
    '    Me.Label2.AutoSize = True
    '    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label2.Location = New System.Drawing.Point(14, 42)
    '    Me.Label2.Name = "Label2"
    '    Me.Label2.Size = New System.Drawing.Size(59, 13)
    '    Me.Label2.TabIndex = 128
    '    Me.Label2.Text = "Distribuidor"
    '    '
    '    'txt_Distrib
    '    '
    '    Me.txt_Distrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_Distrib.Location = New System.Drawing.Point(106, 39)
    '    Me.txt_Distrib.Name = "txt_Distrib"
    '    Me.txt_Distrib.Size = New System.Drawing.Size(68, 20)
    '    Me.txt_Distrib.TabIndex = 126
    '    '
    '    'Panel1
    '    '
    '    Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
    '    Me.Panel1.Controls.Add(Me.txt_nomDistrib)
    '    Me.Panel1.Controls.Add(Me.txt_id)
    '    Me.Panel1.Controls.Add(Me.Label2)
    '    Me.Panel1.Controls.Add(Me.Label1)
    '    Me.Panel1.Controls.Add(Me.txt_Distrib)
    '    Me.Panel1.Controls.Add(Me.txt_nombre)
    '    Me.Panel1.Enabled = False
    '    Me.Panel1.Location = New System.Drawing.Point(27, 5)
    '    Me.Panel1.Name = "Panel1"
    '    Me.Panel1.Size = New System.Drawing.Size(509, 68)
    '    Me.Panel1.TabIndex = 129
    '    '
    '    'DTPicker1
    '    '
    '    Me.DTPicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.DTPicker1.Location = New System.Drawing.Point(99, 14)
    '    Me.DTPicker1.Name = "DTPicker1"
    '    Me.DTPicker1.Size = New System.Drawing.Size(238, 20)
    '    Me.DTPicker1.TabIndex = 0
    '    '
    '    'Label3
    '    '
    '    Me.Label3.AutoSize = True
    '    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label3.Location = New System.Drawing.Point(13, 18)
    '    Me.Label3.Name = "Label3"
    '    Me.Label3.Size = New System.Drawing.Size(80, 13)
    '    Me.Label3.TabIndex = 129
    '    Me.Label3.Text = "Fecha de Visita"
    '    '
    '    'Label4
    '    '
    '    Me.Label4.AutoSize = True
    '    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label4.Location = New System.Drawing.Point(13, 51)
    '    Me.Label4.Name = "Label4"
    '    Me.Label4.Size = New System.Drawing.Size(73, 13)
    '    Me.Label4.TabIndex = 131
    '    Me.Label4.Text = "Hora de Visita"
    '    '
    '    'Label5
    '    '
    '    Me.Label5.AutoSize = True
    '    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label5.Location = New System.Drawing.Point(13, 84)
    '    Me.Label5.Name = "Label5"
    '    Me.Label5.Size = New System.Drawing.Size(82, 13)
    '    Me.Label5.TabIndex = 133
    '    Me.Label5.Text = "Hora Disponible"
    '    '
    '    'Label6
    '    '
    '    Me.Label6.AutoSize = True
    '    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label6.Location = New System.Drawing.Point(13, 147)
    '    Me.Label6.Name = "Label6"
    '    Me.Label6.Size = New System.Drawing.Size(98, 13)
    '    Me.Label6.TabIndex = 135
    '    Me.Label6.Text = "Resultado de Visita"
    '    '
    '    'txt_resultado
    '    '
    '    Me.txt_resultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_resultado.Location = New System.Drawing.Point(117, 144)
    '    Me.txt_resultado.Multiline = True
    '    Me.txt_resultado.Name = "txt_resultado"
    '    Me.txt_resultado.Size = New System.Drawing.Size(397, 90)
    '    Me.txt_resultado.TabIndex = 6
    '    '
    '    'Label7
    '    '
    '    Me.Label7.AutoSize = True
    '    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label7.Location = New System.Drawing.Point(355, 51)
    '    Me.Label7.Name = "Label7"
    '    Me.Label7.Size = New System.Drawing.Size(94, 13)
    '    Me.Label7.TabIndex = 137
    '    Me.Label7.Text = "Importe por Cobrar"
    '    '
    '    'txt_impXcobrar
    '    '
    '    Me.txt_impXcobrar.Enabled = False
    '    Me.txt_impXcobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_impXcobrar.Location = New System.Drawing.Point(455, 48)
    '    Me.txt_impXcobrar.Name = "txt_impXcobrar"
    '    Me.txt_impXcobrar.Size = New System.Drawing.Size(89, 20)
    '    Me.txt_impXcobrar.TabIndex = 136
    '    Me.txt_impXcobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '    '
    '    'Label8
    '    '
    '    Me.Label8.AutoSize = True
    '    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label8.Location = New System.Drawing.Point(355, 84)
    '    Me.Label8.Name = "Label8"
    '    Me.Label8.Size = New System.Drawing.Size(85, 13)
    '    Me.Label8.TabIndex = 139
    '    Me.Label8.Text = "Importe Cobrado"
    '    '
    '    'txt_importe
    '    '
    '    Me.txt_importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txt_importe.Location = New System.Drawing.Point(455, 81)
    '    Me.txt_importe.Name = "txt_importe"
    '    Me.txt_importe.Size = New System.Drawing.Size(89, 20)
    '    Me.txt_importe.TabIndex = 5
    '    Me.txt_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '    '
    '    'Label9
    '    '
    '    Me.Label9.AutoSize = True
    '    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label9.Location = New System.Drawing.Point(355, 18)
    '    Me.Label9.Name = "Label9"
    '    Me.Label9.Size = New System.Drawing.Size(56, 13)
    '    Me.Label9.TabIndex = 141
    '    Me.Label9.Text = "Visito Aval"
    '    '
    '    'Cbo_VisitoAval
    '    '
    '    Me.Cbo_VisitoAval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Cbo_VisitoAval.FormattingEnabled = True
    '    Me.Cbo_VisitoAval.Items.AddRange(New Object() {"SI", "NO"})
    '    Me.Cbo_VisitoAval.Location = New System.Drawing.Point(455, 15)
    '    Me.Cbo_VisitoAval.Name = "Cbo_VisitoAval"
    '    Me.Cbo_VisitoAval.Size = New System.Drawing.Size(59, 21)
    '    Me.Cbo_VisitoAval.TabIndex = 4
    '    '
    '    'Msk_horavisita
    '    '
    '    Me.Msk_horavisita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Msk_horavisita.Location = New System.Drawing.Point(99, 48)
    '    Me.Msk_horavisita.Mask = "00:00 Hrs"
    '    Me.Msk_horavisita.Name = "Msk_horavisita"
    '    Me.Msk_horavisita.Size = New System.Drawing.Size(131, 20)
    '    Me.Msk_horavisita.TabIndex = 1
    '    '
    '    'Msk_horadisponible
    '    '
    '    Me.Msk_horadisponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Msk_horadisponible.Location = New System.Drawing.Point(99, 81)
    '    Me.Msk_horadisponible.Mask = "DE 00:00 - 00:00 Hrs"
    '    Me.Msk_horadisponible.Name = "Msk_horadisponible"
    '    Me.Msk_horadisponible.Size = New System.Drawing.Size(131, 20)
    '    Me.Msk_horadisponible.TabIndex = 2
    '    '
    '    'Panel2
    '    '
    '    Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    '    Me.Panel2.Controls.Add(Me.txt_folio)
    '    Me.Panel2.Controls.Add(Me.Label10)
    '    Me.Panel2.Controls.Add(Me.Label4)
    '    Me.Panel2.Controls.Add(Me.Label8)
    '    Me.Panel2.Controls.Add(Me.Msk_horadisponible)
    '    Me.Panel2.Controls.Add(Me.txt_importe)
    '    Me.Panel2.Controls.Add(Me.DTPicker1)
    '    Me.Panel2.Controls.Add(Me.Label7)
    '    Me.Panel2.Controls.Add(Me.Msk_horavisita)
    '    Me.Panel2.Controls.Add(Me.txt_impXcobrar)
    '    Me.Panel2.Controls.Add(Me.Label3)
    '    Me.Panel2.Controls.Add(Me.Label6)
    '    Me.Panel2.Controls.Add(Me.Cbo_VisitoAval)
    '    Me.Panel2.Controls.Add(Me.txt_resultado)
    '    Me.Panel2.Controls.Add(Me.Label5)
    '    Me.Panel2.Controls.Add(Me.Label9)
    '    Me.Panel2.Location = New System.Drawing.Point(0, 79)
    '    Me.Panel2.Name = "Panel2"
    '    Me.Panel2.Size = New System.Drawing.Size(564, 251)
    '    Me.Panel2.TabIndex = 145
    '    '
    '    'ToolTip
    '    '
    '    Me.ToolTip.IsBalloon = True
    '    '
    '    'Label10
    '    '
    '    Me.Label10.AutoSize = True
    '    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.Label10.Location = New System.Drawing.Point(13, 116)
    '    Me.Label10.Name = "Label10"
    '    Me.Label10.Size = New System.Drawing.Size(52, 13)
    '    Me.Label10.TabIndex = 145
    '    Me.Label10.Text = "No. Folio:"
    '    '
    '    'txt_folio
    '    '
    '    Me.txt_folio.Location = New System.Drawing.Point(99, 113)
    '    Me.txt_folio.Name = "txt_folio"
    '    Me.txt_folio.Size = New System.Drawing.Size(100, 20)
    '    Me.txt_folio.TabIndex = 3
    '    '
    '    'frmCatalogoVisitaDistrib
    '    '
    '    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    Me.ClientSize = New System.Drawing.Size(564, 392)
    '    Me.Controls.Add(Me.Panel2)
    '    Me.Controls.Add(Me.Panel1)
    '    Me.Controls.Add(Me.Pnl_Botones)
    '    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    '    Me.KeyPreview = True
    '    Me.Name = "frmCatalogoVisitaDistrib"
    '    Me.Text = "Catálogo de Visitas"
    '    Me.Pnl_Botones.ResumeLayout(False)
    '    Me.Panel1.ResumeLayout(False)
    '    Me.Panel1.PerformLayout()
    '    Me.Panel2.ResumeLayout(False)
    '    Me.Panel2.PerformLayout()
    '    Me.ResumeLayout(False)

    'End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_id As System.Windows.Forms.TextBox
    Friend WithEvents txt_nomDistrib As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Distrib As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_importe As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents txt_folio As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ruta As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripRuta As System.Windows.Forms.TextBox
End Class
