<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoBancosFactoraje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoBancosFactoraje))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_Saldo = New System.Windows.Forms.TextBox
        Me.Txt_LimCred = New System.Windows.Forms.TextBox
        Me.Txt_Tarjeta_ID = New System.Windows.Forms.TextBox
        Me.Txt_Prioridad = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Cbo_Banco = New System.Windows.Forms.ComboBox
        Me.Txt_Campo1 = New System.Windows.Forms.TextBox
        Me.Txt_Campo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Txt_Disponible = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Comision = New System.Windows.Forms.TextBox
        Me.Txt_Dias = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txt_Usuario = New System.Windows.Forms.TextBox
        Me.Txt_ClaveAcceso = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_Observaciones = New System.Windows.Forms.TextBox
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Dias)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Comision)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Disponible)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Saldo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_LimCred)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Tarjeta_ID)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Prioridad)
        Me.Pnl_Edicion.Controls.Add(Me.Label11)
        Me.Pnl_Edicion.Controls.Add(Me.Label8)
        Me.Pnl_Edicion.Controls.Add(Me.Label7)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Banco)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Campo1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Campo)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(588, 153)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_Saldo
        '
        Me.Txt_Saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Saldo.Location = New System.Drawing.Point(288, 119)
        Me.Txt_Saldo.Name = "Txt_Saldo"
        Me.Txt_Saldo.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Saldo.TabIndex = 6
        Me.Txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_LimCred
        '
        Me.Txt_LimCred.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LimCred.Location = New System.Drawing.Point(92, 119)
        Me.Txt_LimCred.Name = "Txt_LimCred"
        Me.Txt_LimCred.Size = New System.Drawing.Size(100, 20)
        Me.Txt_LimCred.TabIndex = 5
        Me.Txt_LimCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Tarjeta_ID
        '
        Me.Txt_Tarjeta_ID.Location = New System.Drawing.Point(406, 53)
        Me.Txt_Tarjeta_ID.Name = "Txt_Tarjeta_ID"
        Me.Txt_Tarjeta_ID.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Tarjeta_ID.TabIndex = 76
        Me.Txt_Tarjeta_ID.Visible = False
        '
        'Txt_Prioridad
        '
        Me.Txt_Prioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Prioridad.Location = New System.Drawing.Point(288, 14)
        Me.Txt_Prioridad.Name = "Txt_Prioridad"
        Me.Txt_Prioridad.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Prioridad.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(234, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 74
        Me.Label11.Text = "Prioridad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(210, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Saldo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Límite Crédito"
        '
        'Cbo_Banco
        '
        Me.Cbo_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.Cbo_Banco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Banco.FormattingEnabled = True
        Me.Cbo_Banco.Items.AddRange(New Object() {"BANCOMER", "BANAMEX", "SANTANDER", "SCOTIABANK", "AMERICAN EXPRESS"})
        Me.Cbo_Banco.Location = New System.Drawing.Point(92, 13)
        Me.Cbo_Banco.Name = "Cbo_Banco"
        Me.Cbo_Banco.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Banco.TabIndex = 0
        '
        'Txt_Campo1
        '
        Me.Txt_Campo1.Location = New System.Drawing.Point(394, 13)
        Me.Txt_Campo1.Name = "Txt_Campo1"
        Me.Txt_Campo1.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Campo1.TabIndex = 53
        Me.Txt_Campo1.Visible = False
        '
        'Txt_Campo
        '
        Me.Txt_Campo.Location = New System.Drawing.Point(356, 13)
        Me.Txt_Campo.Name = "Txt_Campo"
        Me.Txt_Campo.Size = New System.Drawing.Size(32, 20)
        Me.Txt_Campo.TabIndex = 52
        Me.Txt_Campo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Banco"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 378)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(588, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(131, 3)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Eliminar.TabIndex = 6
        Me.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        Me.Btn_Eliminar.Visible = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(482, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 4
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(533, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 5
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(74, 3)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Editar.TabIndex = 1
        Me.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Editar.UseVisualStyleBackColor = True
        Me.Btn_Editar.Visible = False
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(17, 3)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 47)
        Me.Btn_Nuevo.TabIndex = 0
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        Me.Btn_Nuevo.Visible = False
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Txt_Disponible
        '
        Me.Txt_Disponible.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Disponible.Location = New System.Drawing.Point(482, 119)
        Me.Txt_Disponible.Name = "Txt_Disponible"
        Me.Txt_Disponible.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Disponible.TabIndex = 77
        Me.Txt_Disponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(404, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Disponible"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Comisión"
        '
        'Txt_Comision
        '
        Me.Txt_Comision.Location = New System.Drawing.Point(92, 56)
        Me.Txt_Comision.Name = "Txt_Comision"
        Me.Txt_Comision.Size = New System.Drawing.Size(57, 20)
        Me.Txt_Comision.TabIndex = 80
        '
        'Txt_Dias
        '
        Me.Txt_Dias.Location = New System.Drawing.Point(92, 88)
        Me.Txt_Dias.Name = "Txt_Dias"
        Me.Txt_Dias.Size = New System.Drawing.Size(57, 20)
        Me.Txt_Dias.TabIndex = 82
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Días Vence"
        '
        'Pnl1
        '
        Me.Pnl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl1.Controls.Add(Me.Txt_Observaciones)
        Me.Pnl1.Controls.Add(Me.Label9)
        Me.Pnl1.Controls.Add(Me.Txt_ClaveAcceso)
        Me.Pnl1.Controls.Add(Me.Label6)
        Me.Pnl1.Controls.Add(Me.Txt_Usuario)
        Me.Pnl1.Controls.Add(Me.Label5)
        Me.Pnl1.Location = New System.Drawing.Point(15, 166)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(585, 200)
        Me.Pnl1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Usuario Portal"
        '
        'Txt_Usuario
        '
        Me.Txt_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Usuario.Location = New System.Drawing.Point(89, 19)
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Usuario.TabIndex = 6
        Me.Txt_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_ClaveAcceso
        '
        Me.Txt_ClaveAcceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClaveAcceso.Location = New System.Drawing.Point(89, 45)
        Me.Txt_ClaveAcceso.Name = "Txt_ClaveAcceso"
        Me.Txt_ClaveAcceso.Size = New System.Drawing.Size(100, 20)
        Me.Txt_ClaveAcceso.TabIndex = 8
        Me.Txt_ClaveAcceso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Password Portal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Observaciones"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.Location = New System.Drawing.Point(89, 96)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.Size = New System.Drawing.Size(489, 102)
        Me.Txt_Observaciones.TabIndex = 10
        '
        'frmCatalogoBancosFactoraje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 446)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoBancosFactoraje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Tarjetas"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl1.ResumeLayout(False)
        Me.Pnl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Txt_Campo1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Campo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Cbo_Banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_Prioridad As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_Tarjeta_ID As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Saldo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_LimCred As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Disponible As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Dias As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Comision As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_ClaveAcceso As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
