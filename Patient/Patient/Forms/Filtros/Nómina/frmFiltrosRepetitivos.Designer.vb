<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosRepetitivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosRepetitivos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Chk_Fecha = New System.Windows.Forms.CheckBox
        Me.DTPicker3 = New System.Windows.Forms.DateTimePicker
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
        Me.Txt_IdPercDeduc = New System.Windows.Forms.TextBox
        Me.Txt_DescripPerceDeduc = New System.Windows.Forms.TextBox
        Me.Txt_NombreEmpleado = New System.Windows.Forms.TextBox
        Me.Txt_Clave = New System.Windows.Forms.TextBox
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Empleado = New System.Windows.Forms.Label
        Me.Txt_IdEmpleado = New System.Windows.Forms.TextBox
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Chk_Fecha)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker3)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdPercDeduc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripPerceDeduc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NombreEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Clave)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Estatus)
        Me.Pnl_Edicion.Controls.Add(Me.Label8)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Empleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdEmpleado)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(533, 155)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Chk_Fecha
        '
        Me.Chk_Fecha.AutoSize = True
        Me.Chk_Fecha.Location = New System.Drawing.Point(21, 32)
        Me.Chk_Fecha.Name = "Chk_Fecha"
        Me.Chk_Fecha.Size = New System.Drawing.Size(56, 17)
        Me.Chk_Fecha.TabIndex = 97
        Me.Chk_Fecha.Text = "Fecha"
        Me.Chk_Fecha.UseVisualStyleBackColor = True
        '
        'DTPicker3
        '
        Me.DTPicker3.Enabled = False
        Me.DTPicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker3.Location = New System.Drawing.Point(320, 32)
        Me.DTPicker3.Name = "DTPicker3"
        Me.DTPicker3.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker3.TabIndex = 99
        '
        'DTPicker2
        '
        Me.DTPicker2.Enabled = False
        Me.DTPicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker2.Location = New System.Drawing.Point(106, 32)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker2.TabIndex = 98
        '
        'Txt_IdPercDeduc
        '
        Me.Txt_IdPercDeduc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdPercDeduc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdPercDeduc.Location = New System.Drawing.Point(244, 111)
        Me.Txt_IdPercDeduc.MaxLength = 50
        Me.Txt_IdPercDeduc.Name = "Txt_IdPercDeduc"
        Me.Txt_IdPercDeduc.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdPercDeduc.TabIndex = 76
        Me.Txt_IdPercDeduc.Visible = False
        '
        'Txt_DescripPerceDeduc
        '
        Me.Txt_DescripPerceDeduc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPerceDeduc.Enabled = False
        Me.Txt_DescripPerceDeduc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPerceDeduc.Location = New System.Drawing.Point(183, 84)
        Me.Txt_DescripPerceDeduc.MaxLength = 200
        Me.Txt_DescripPerceDeduc.Name = "Txt_DescripPerceDeduc"
        Me.Txt_DescripPerceDeduc.ReadOnly = True
        Me.Txt_DescripPerceDeduc.Size = New System.Drawing.Size(337, 20)
        Me.Txt_DescripPerceDeduc.TabIndex = 96
        '
        'Txt_NombreEmpleado
        '
        Me.Txt_NombreEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreEmpleado.Enabled = False
        Me.Txt_NombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreEmpleado.Location = New System.Drawing.Point(182, 58)
        Me.Txt_NombreEmpleado.MaxLength = 200
        Me.Txt_NombreEmpleado.Name = "Txt_NombreEmpleado"
        Me.Txt_NombreEmpleado.ReadOnly = True
        Me.Txt_NombreEmpleado.Size = New System.Drawing.Size(338, 20)
        Me.Txt_NombreEmpleado.TabIndex = 95
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Clave.Location = New System.Drawing.Point(106, 84)
        Me.Txt_Clave.MaxLength = 3
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Clave.TabIndex = 1
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.AutoCompleteCustomSource.AddRange(New String() {"CANCELADO", "VIGENTE", "SUSPENDIDO", "FINALIZADO"})
        Me.Cbo_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"CANCELADO", "VIGENTE", "SUSPENDIDO", "FINALIZADO"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(106, 110)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Estatus.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 113)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Estatus"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Concepto"
        '
        'Empleado
        '
        Me.Empleado.AutoSize = True
        Me.Empleado.Location = New System.Drawing.Point(17, 61)
        Me.Empleado.Name = "Empleado"
        Me.Empleado.Size = New System.Drawing.Size(54, 13)
        Me.Empleado.TabIndex = 92
        Me.Empleado.Text = "Empleado"
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(106, 58)
        Me.Txt_IdEmpleado.MaxLength = 50
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdEmpleado.TabIndex = 0
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 164)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(522, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(365, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Limpiar.TabIndex = 3
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(1505, 0)
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
        Me.Btn_Aceptar.Location = New System.Drawing.Point(467, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 5
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmFiltrosRepetitivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 232)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosRepetitivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Repetitivos"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    'Friend WithEvents Tbl_EmpleadoTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Estatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Empleado As System.Windows.Forms.Label
    Friend WithEvents Txt_IdEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripPerceDeduc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdPercDeduc As System.Windows.Forms.TextBox
    Friend WithEvents Chk_Fecha As System.Windows.Forms.CheckBox
    Friend WithEvents DTPicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
End Class
