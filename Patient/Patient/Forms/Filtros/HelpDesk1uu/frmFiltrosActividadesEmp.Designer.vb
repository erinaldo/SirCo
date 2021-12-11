<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosActividades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosActividades))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Txt_IdPuesto = New System.Windows.Forms.TextBox
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_NombreAsignado = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_IdAsignado = New System.Windows.Forms.TextBox
        Me.Txt_IdDepto = New System.Windows.Forms.TextBox
        Me.Txt_ClavePuesto = New System.Windows.Forms.TextBox
        Me.Txt_DescripPuesto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_IdDepartamento = New System.Windows.Forms.TextBox
        Me.Txt_NombreReporta = New System.Windows.Forms.TextBox
        Me.Empleado = New System.Windows.Forms.Label
        Me.Txt_IdReporta = New System.Windows.Forms.TextBox
        Me.Chk_Fecha = New System.Windows.Forms.CheckBox
        Me.DTFecha2 = New System.Windows.Forms.DateTimePicker
        Me.DTFecha1 = New System.Windows.Forms.DateTimePicker
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
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdPuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Estatus)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NombreAsignado)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdAsignado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_ClavePuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripPuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepartamento)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NombreReporta)
        Me.Pnl_Edicion.Controls.Add(Me.Empleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdReporta)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_Fecha)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecha2)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecha1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 163)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(186, 29)
        Me.Txt_DescripSucursal.MaxLength = 200
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripSucursal.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Sucursal"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(110, 29)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Sucursal.TabIndex = 2
        '
        'Txt_IdPuesto
        '
        Me.Txt_IdPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdPuesto.Location = New System.Drawing.Point(352, 134)
        Me.Txt_IdPuesto.MaxLength = 50
        Me.Txt_IdPuesto.Name = "Txt_IdPuesto"
        Me.Txt_IdPuesto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdPuesto.TabIndex = 120
        Me.Txt_IdPuesto.Visible = False
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"CAPTURA", "EN PROCESO", "REALIZADO", "CANCELADO"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(110, 131)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(201, 21)
        Me.Cbo_Estatus.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Estatus"
        '
        'Txt_NombreAsignado
        '
        Me.Txt_NombreAsignado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreAsignado.Enabled = False
        Me.Txt_NombreAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreAsignado.Location = New System.Drawing.Point(186, 79)
        Me.Txt_NombreAsignado.MaxLength = 200
        Me.Txt_NombreAsignado.Name = "Txt_NombreAsignado"
        Me.Txt_NombreAsignado.ReadOnly = True
        Me.Txt_NombreAsignado.Size = New System.Drawing.Size(330, 20)
        Me.Txt_NombreAsignado.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Asignado"
        '
        'Txt_IdAsignado
        '
        Me.Txt_IdAsignado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdAsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_IdAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdAsignado.Location = New System.Drawing.Point(110, 79)
        Me.Txt_IdAsignado.MaxLength = 3
        Me.Txt_IdAsignado.Name = "Txt_IdAsignado"
        Me.Txt_IdAsignado.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdAsignado.TabIndex = 5
        '
        'Txt_IdDepto
        '
        Me.Txt_IdDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepto.Location = New System.Drawing.Point(227, 81)
        Me.Txt_IdDepto.MaxLength = 50
        Me.Txt_IdDepto.Name = "Txt_IdDepto"
        Me.Txt_IdDepto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdDepto.TabIndex = 115
        Me.Txt_IdDepto.Visible = False
        '
        'Txt_ClavePuesto
        '
        Me.Txt_ClavePuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClavePuesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ClavePuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClavePuesto.Location = New System.Drawing.Point(110, 105)
        Me.Txt_ClavePuesto.MaxLength = 3
        Me.Txt_ClavePuesto.Name = "Txt_ClavePuesto"
        Me.Txt_ClavePuesto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_ClavePuesto.TabIndex = 4
        '
        'Txt_DescripPuesto
        '
        Me.Txt_DescripPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPuesto.Enabled = False
        Me.Txt_DescripPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPuesto.Location = New System.Drawing.Point(186, 105)
        Me.Txt_DescripPuesto.MaxLength = 200
        Me.Txt_DescripPuesto.Name = "Txt_DescripPuesto"
        Me.Txt_DescripPuesto.ReadOnly = True
        Me.Txt_DescripPuesto.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripPuesto.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Puesto"
        '
        'Txt_IdDepartamento
        '
        Me.Txt_IdDepartamento.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepartamento.Location = New System.Drawing.Point(451, 134)
        Me.Txt_IdDepartamento.MaxLength = 50
        Me.Txt_IdDepartamento.Name = "Txt_IdDepartamento"
        Me.Txt_IdDepartamento.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdDepartamento.TabIndex = 99
        Me.Txt_IdDepartamento.Visible = False
        '
        'Txt_NombreReporta
        '
        Me.Txt_NombreReporta.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreReporta.Enabled = False
        Me.Txt_NombreReporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreReporta.Location = New System.Drawing.Point(186, 53)
        Me.Txt_NombreReporta.MaxLength = 200
        Me.Txt_NombreReporta.Name = "Txt_NombreReporta"
        Me.Txt_NombreReporta.ReadOnly = True
        Me.Txt_NombreReporta.Size = New System.Drawing.Size(330, 20)
        Me.Txt_NombreReporta.TabIndex = 4
        '
        'Empleado
        '
        Me.Empleado.AutoSize = True
        Me.Empleado.Location = New System.Drawing.Point(13, 56)
        Me.Empleado.Name = "Empleado"
        Me.Empleado.Size = New System.Drawing.Size(45, 13)
        Me.Empleado.TabIndex = 97
        Me.Empleado.Text = "Reporta"
        '
        'Txt_IdReporta
        '
        Me.Txt_IdReporta.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdReporta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_IdReporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdReporta.Location = New System.Drawing.Point(110, 53)
        Me.Txt_IdReporta.MaxLength = 5
        Me.Txt_IdReporta.Name = "Txt_IdReporta"
        Me.Txt_IdReporta.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdReporta.TabIndex = 3
        '
        'Chk_Fecha
        '
        Me.Chk_Fecha.AutoSize = True
        Me.Chk_Fecha.Location = New System.Drawing.Point(17, 6)
        Me.Chk_Fecha.Name = "Chk_Fecha"
        Me.Chk_Fecha.Size = New System.Drawing.Size(56, 17)
        Me.Chk_Fecha.TabIndex = 0
        Me.Chk_Fecha.Text = "Fecha"
        Me.Chk_Fecha.UseVisualStyleBackColor = True
        '
        'DTFecha2
        '
        Me.DTFecha2.Enabled = False
        Me.DTFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecha2.Location = New System.Drawing.Point(317, 3)
        Me.DTFecha2.Name = "DTFecha2"
        Me.DTFecha2.Size = New System.Drawing.Size(200, 20)
        Me.DTFecha2.TabIndex = 1
        '
        'DTFecha1
        '
        Me.DTFecha1.Enabled = False
        Me.DTFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecha1.Location = New System.Drawing.Point(111, 3)
        Me.DTFecha1.Name = "DTFecha1"
        Me.DTFecha1.Size = New System.Drawing.Size(200, 20)
        Me.DTFecha1.TabIndex = 0
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 172)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(528, 65)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(371, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 61)
        Me.Btn_Limpiar.TabIndex = 2
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(422, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 61)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(473, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 61)
        Me.Btn_Aceptar.TabIndex = 0
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmFiltrosActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 241)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosActividades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Actividades de Empleados"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    '  Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    ' Friend WithEvents Tbl_EmpleadoTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
    Friend WithEvents DTFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Chk_Fecha As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_NombreReporta As System.Windows.Forms.TextBox
    Friend WithEvents Empleado As System.Windows.Forms.Label
    Friend WithEvents Txt_IdReporta As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ClavePuesto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdDepto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NombreAsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdAsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Estatus As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_IdPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
End Class
