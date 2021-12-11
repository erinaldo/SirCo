<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopiarFolioBulto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopiarFolioBulto))
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Lbl_Leyenda = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_NoBulto = New System.Windows.Forms.TextBox
        Me.Txt_Id_SegBit = New System.Windows.Forms.TextBox
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 87)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(288, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(182, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 7
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(233, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 6
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Leyenda)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NoBulto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Id_SegBit)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(288, 78)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Lbl_Leyenda
        '
        Me.Lbl_Leyenda.AutoSize = True
        Me.Lbl_Leyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Leyenda.Location = New System.Drawing.Point(13, 41)
        Me.Lbl_Leyenda.Name = "Lbl_Leyenda"
        Me.Lbl_Leyenda.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Leyenda.TabIndex = 109
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Folio Bulto"
        '
        'Txt_NoBulto
        '
        Me.Txt_NoBulto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NoBulto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoBulto.Location = New System.Drawing.Point(74, 4)
        Me.Txt_NoBulto.MaxLength = 8
        Me.Txt_NoBulto.Name = "Txt_NoBulto"
        Me.Txt_NoBulto.Size = New System.Drawing.Size(207, 31)
        Me.Txt_NoBulto.TabIndex = 0
        '
        'Txt_Id_SegBit
        '
        Me.Txt_Id_SegBit.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Id_SegBit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Id_SegBit.Location = New System.Drawing.Point(542, -2)
        Me.Txt_Id_SegBit.MaxLength = 6
        Me.Txt_Id_SegBit.Name = "Txt_Id_SegBit"
        Me.Txt_Id_SegBit.Size = New System.Drawing.Size(10, 20)
        Me.Txt_Id_SegBit.TabIndex = 82
        Me.Txt_Id_SegBit.Visible = False
        '
        'frmCopiarFolioBulto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 157)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCopiarFolioBulto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Copiar Folio Bulto"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    'Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_Id_SegBit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_NoBulto As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Leyenda As System.Windows.Forms.Label
End Class
