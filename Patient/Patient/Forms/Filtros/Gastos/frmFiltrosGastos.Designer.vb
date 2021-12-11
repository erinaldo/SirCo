<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosGastos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_IdFolioSucFin = New System.Windows.Forms.TextBox
        Me.Txt_IdFolioSucIni = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Sucursal = New System.Windows.Forms.Label
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Cbo_IdGasto = New System.Windows.Forms.ComboBox
        Me.Concepto = New System.Windows.Forms.Label
        Me.Txt_DescripEmpleado2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_IdEmpleado2 = New System.Windows.Forms.TextBox
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_DescripEmpleado = New System.Windows.Forms.TextBox
        Me.Empleado = New System.Windows.Forms.Label
        Me.Txt_IdEmpleado = New System.Windows.Forms.TextBox
        Me.Chk_FechaCaptura = New System.Windows.Forms.CheckBox
        Me.DTPicker3 = New System.Windows.Forms.DateTimePicker
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
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
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFolioSucFin)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFolioSucIni)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_IdGasto)
        Me.Pnl_Edicion.Controls.Add(Me.Concepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripEmpleado2)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdEmpleado2)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Estatus)
        Me.Pnl_Edicion.Controls.Add(Me.Label8)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Empleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_FechaCaptura)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker3)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker2)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 195)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "al"
        '
        'Txt_IdFolioSucFin
        '
        Me.Txt_IdFolioSucFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFolioSucFin.Location = New System.Drawing.Point(239, 56)
        Me.Txt_IdFolioSucFin.MaxLength = 8
        Me.Txt_IdFolioSucFin.Name = "Txt_IdFolioSucFin"
        Me.Txt_IdFolioSucFin.Size = New System.Drawing.Size(93, 20)
        Me.Txt_IdFolioSucFin.TabIndex = 5
        '
        'Txt_IdFolioSucIni
        '
        Me.Txt_IdFolioSucIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFolioSucIni.Location = New System.Drawing.Point(111, 56)
        Me.Txt_IdFolioSucIni.MaxLength = 8
        Me.Txt_IdFolioSucIni.Name = "Txt_IdFolioSucIni"
        Me.Txt_IdFolioSucIni.Size = New System.Drawing.Size(93, 20)
        Me.Txt_IdFolioSucIni.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Folio Gasto"
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(187, 82)
        Me.Txt_DescripSucursal.MaxLength = 200
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripSucursal.TabIndex = 118
        '
        'Sucursal
        '
        Me.Sucursal.AutoSize = True
        Me.Sucursal.Location = New System.Drawing.Point(14, 85)
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.Size = New System.Drawing.Size(48, 13)
        Me.Sucursal.TabIndex = 117
        Me.Sucursal.Text = "Sucursal"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(111, 82)
        Me.Txt_Sucursal.MaxLength = 5
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Sucursal.TabIndex = 6
        '
        'Cbo_IdGasto
        '
        Me.Cbo_IdGasto.AutoCompleteCustomSource.AddRange(New String() {"CANCELADO", "VIGENTE", "SUSPENDIDO"})
        Me.Cbo_IdGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_IdGasto.FormattingEnabled = True
        Me.Cbo_IdGasto.Location = New System.Drawing.Point(111, 29)
        Me.Cbo_IdGasto.Name = "Cbo_IdGasto"
        Me.Cbo_IdGasto.Size = New System.Drawing.Size(157, 21)
        Me.Cbo_IdGasto.TabIndex = 3
        '
        'Concepto
        '
        Me.Concepto.AutoSize = True
        Me.Concepto.Location = New System.Drawing.Point(14, 32)
        Me.Concepto.Name = "Concepto"
        Me.Concepto.Size = New System.Drawing.Size(53, 13)
        Me.Concepto.TabIndex = 31
        Me.Concepto.Text = "Concepto"
        '
        'Txt_DescripEmpleado2
        '
        Me.Txt_DescripEmpleado2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripEmpleado2.Enabled = False
        Me.Txt_DescripEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripEmpleado2.Location = New System.Drawing.Point(187, 133)
        Me.Txt_DescripEmpleado2.MaxLength = 200
        Me.Txt_DescripEmpleado2.Name = "Txt_DescripEmpleado2"
        Me.Txt_DescripEmpleado2.ReadOnly = True
        Me.Txt_DescripEmpleado2.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripEmpleado2.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Autoriza"
        '
        'Txt_IdEmpleado2
        '
        Me.Txt_IdEmpleado2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado2.Location = New System.Drawing.Point(111, 133)
        Me.Txt_IdEmpleado2.MaxLength = 5
        Me.Txt_IdEmpleado2.Name = "Txt_IdEmpleado2"
        Me.Txt_IdEmpleado2.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdEmpleado2.TabIndex = 8
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.AutoCompleteCustomSource.AddRange(New String() {"ACTIVO", "BAJA"})
        Me.Cbo_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"CAPTURA", "CANCELADO", "REVISADO", "AUTORIZADO"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(111, 161)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(157, 21)
        Me.Cbo_Estatus.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Estatus"
        '
        'Txt_DescripEmpleado
        '
        Me.Txt_DescripEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripEmpleado.Enabled = False
        Me.Txt_DescripEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripEmpleado.Location = New System.Drawing.Point(187, 107)
        Me.Txt_DescripEmpleado.MaxLength = 200
        Me.Txt_DescripEmpleado.Name = "Txt_DescripEmpleado"
        Me.Txt_DescripEmpleado.ReadOnly = True
        Me.Txt_DescripEmpleado.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripEmpleado.TabIndex = 5
        '
        'Empleado
        '
        Me.Empleado.AutoSize = True
        Me.Empleado.Location = New System.Drawing.Point(14, 110)
        Me.Empleado.Name = "Empleado"
        Me.Empleado.Size = New System.Drawing.Size(41, 13)
        Me.Empleado.TabIndex = 97
        Me.Empleado.Text = "Solicita"
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(111, 107)
        Me.Txt_IdEmpleado.MaxLength = 5
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdEmpleado.TabIndex = 7
        '
        'Chk_FechaCaptura
        '
        Me.Chk_FechaCaptura.AutoSize = True
        Me.Chk_FechaCaptura.Location = New System.Drawing.Point(17, 6)
        Me.Chk_FechaCaptura.Name = "Chk_FechaCaptura"
        Me.Chk_FechaCaptura.Size = New System.Drawing.Size(56, 17)
        Me.Chk_FechaCaptura.TabIndex = 0
        Me.Chk_FechaCaptura.Text = "Fecha"
        Me.Chk_FechaCaptura.UseVisualStyleBackColor = True
        '
        'DTPicker3
        '
        Me.DTPicker3.Enabled = False
        Me.DTPicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker3.Location = New System.Drawing.Point(317, 3)
        Me.DTPicker3.Name = "DTPicker3"
        Me.DTPicker3.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker3.TabIndex = 2
        '
        'DTPicker2
        '
        Me.DTPicker2.Enabled = False
        Me.DTPicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker2.Location = New System.Drawing.Point(111, 3)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker2.TabIndex = 1
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 204)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(528, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(371, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Limpiar.TabIndex = 0
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
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
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
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 2
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmFiltrosGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 267)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Gastos"
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
    Friend WithEvents DTPicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Chk_FechaCaptura As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_DescripEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Empleado As System.Windows.Forms.Label
    Friend WithEvents Txt_IdEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Estatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripEmpleado2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdEmpleado2 As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_IdGasto As System.Windows.Forms.ComboBox
    Friend WithEvents Concepto As System.Windows.Forms.Label
    Friend WithEvents Sucursal As System.Windows.Forms.Label
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdFolioSucFin As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdFolioSucIni As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
