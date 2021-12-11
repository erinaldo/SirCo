<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoRepetitivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoRepetitivos))
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_ModifSaldo = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Lbl_Repetitivo = New System.Windows.Forms.Label
        Me.Txt_IdRepetitivo = New System.Windows.Forms.TextBox
        Me.Txt_IdEmpleado = New System.Windows.Forms.TextBox
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.DtFin = New System.Windows.Forms.DateTimePicker
        Me.Lbl_Hora = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txt_Observaciones = New System.Windows.Forms.TextBox
        Me.Txt_Folio = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Txt_Descrip = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_Clave = New System.Windows.Forms.TextBox
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Lbl_Fecha = New System.Windows.Forms.Label
        Me.DtInicio = New System.Windows.Forms.DateTimePicker
        Me.Txt_Saldo = New System.Windows.Forms.TextBox
        Me.Lbl_Saldo = New System.Windows.Forms.Label
        Me.Txt_Cuota = New System.Windows.Forms.TextBox
        Me.Lbl_Cuota = New System.Windows.Forms.Label
        Me.Txt_Importe = New System.Windows.Forms.TextBox
        Me.Lbl_Importe = New System.Windows.Forms.Label
        Me.Txt_DescripPerceDeduc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_IdPercDeduc = New System.Windows.Forms.TextBox
        Me.Txt_NombreEmpleado = New System.Windows.Forms.TextBox
        Me.Empleado = New System.Windows.Forms.Label
        Me.DTime = New System.Windows.Forms.DateTimePicker
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_ModifSaldo)
        Me.Pnl_Botones.Controls.Add(Me.Button1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Eliminar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 315)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(559, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_ModifSaldo
        '
        Me.Btn_ModifSaldo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_ModifSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ModifSaldo.Image = Global.SIRCO.My.Resources.Resources.emblem_money
        Me.Btn_ModifSaldo.Location = New System.Drawing.Point(0, 0)
        Me.Btn_ModifSaldo.Name = "Btn_ModifSaldo"
        Me.Btn_ModifSaldo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_ModifSaldo.TabIndex = 29
        Me.Btn_ModifSaldo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_ModifSaldo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Button1.Location = New System.Drawing.Point(321, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 47)
        Me.Button1.TabIndex = 27
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Eliminar.Image = Global.SIRCO.My.Resources.Resources.document_delete
        Me.Btn_Eliminar.Location = New System.Drawing.Point(200, 3)
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
        Me.Btn_Cancelar.Location = New System.Drawing.Point(453, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 28
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(504, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 27
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(143, 3)
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
        Me.Btn_Nuevo.Location = New System.Drawing.Point(86, 3)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'Lbl_Repetitivo
        '
        Me.Lbl_Repetitivo.AutoSize = True
        Me.Lbl_Repetitivo.Location = New System.Drawing.Point(24, 16)
        Me.Lbl_Repetitivo.Name = "Lbl_Repetitivo"
        Me.Lbl_Repetitivo.Size = New System.Drawing.Size(64, 13)
        Me.Lbl_Repetitivo.TabIndex = 10
        Me.Lbl_Repetitivo.Text = "IdRepetitivo"
        '
        'Txt_IdRepetitivo
        '
        Me.Txt_IdRepetitivo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdRepetitivo.Enabled = False
        Me.Txt_IdRepetitivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdRepetitivo.Location = New System.Drawing.Point(113, 12)
        Me.Txt_IdRepetitivo.MaxLength = 3
        Me.Txt_IdRepetitivo.Name = "Txt_IdRepetitivo"
        Me.Txt_IdRepetitivo.ReadOnly = True
        Me.Txt_IdRepetitivo.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdRepetitivo.TabIndex = 0
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(113, 38)
        Me.Txt_IdEmpleado.MaxLength = 10
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdEmpleado.TabIndex = 1
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.DTime)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.DtFin)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Hora)
        Me.Pnl_Edicion.Controls.Add(Me.Label11)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Observaciones)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Folio)
        Me.Pnl_Edicion.Controls.Add(Me.Label10)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Descrip)
        Me.Pnl_Edicion.Controls.Add(Me.Label9)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Clave)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Estatus)
        Me.Pnl_Edicion.Controls.Add(Me.Label8)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Fecha)
        Me.Pnl_Edicion.Controls.Add(Me.DtInicio)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Saldo)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Saldo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Cuota)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Cuota)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Importe)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Importe)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripPerceDeduc)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdPercDeduc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NombreEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Empleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdRepetitivo)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Repetitivo)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 306)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Fin"
        '
        'DtFin
        '
        Me.DtFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtFin.Location = New System.Drawing.Point(113, 114)
        Me.DtFin.Name = "DtFin"
        Me.DtFin.Size = New System.Drawing.Size(233, 20)
        Me.DtFin.TabIndex = 98
        '
        'Lbl_Hora
        '
        Me.Lbl_Hora.AutoSize = True
        Me.Lbl_Hora.Location = New System.Drawing.Point(397, 94)
        Me.Lbl_Hora.Name = "Lbl_Hora"
        Me.Lbl_Hora.Size = New System.Drawing.Size(30, 13)
        Me.Lbl_Hora.TabIndex = 96
        Me.Lbl_Hora.Text = "Hora"
        Me.Lbl_Hora.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(25, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 95
        Me.Label11.Text = "Observaciones"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Observaciones.Location = New System.Drawing.Point(113, 221)
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.Size = New System.Drawing.Size(439, 67)
        Me.Txt_Observaciones.TabIndex = 12
        '
        'Txt_Folio
        '
        Me.Txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Folio.Location = New System.Drawing.Point(113, 142)
        Me.Txt_Folio.MaxLength = 12
        Me.Txt_Folio.Name = "Txt_Folio"
        Me.Txt_Folio.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Folio.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Folio"
        '
        'Txt_Descrip
        '
        Me.Txt_Descrip.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Descrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descrip.Location = New System.Drawing.Point(405, 9)
        Me.Txt_Descrip.MaxLength = 30
        Me.Txt_Descrip.Name = "Txt_Descrip"
        Me.Txt_Descrip.Size = New System.Drawing.Size(147, 20)
        Me.Txt_Descrip.TabIndex = 5
        Me.Txt_Descrip.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Descripción"
        Me.Label9.Visible = False
        '
        'Txt_Clave
        '
        Me.Txt_Clave.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Clave.Location = New System.Drawing.Point(113, 64)
        Me.Txt_Clave.MaxLength = 3
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Clave.TabIndex = 3
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.AutoCompleteCustomSource.AddRange(New String() {"CANCELADO", "VIGENTE", "SUSPENDIDO", "FINALIZADO"})
        Me.Cbo_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"CANCELADO", "VIGENTE", "SUSPENDIDO", "FINALIZADO"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(113, 194)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Estatus.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Estatus"
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.AutoSize = True
        Me.Lbl_Fecha.Location = New System.Drawing.Point(24, 91)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(32, 13)
        Me.Lbl_Fecha.TabIndex = 85
        Me.Lbl_Fecha.Text = "Inicio"
        '
        'DtInicio
        '
        Me.DtInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtInicio.Location = New System.Drawing.Point(113, 88)
        Me.DtInicio.Name = "DtInicio"
        Me.DtInicio.Size = New System.Drawing.Size(233, 20)
        Me.DtInicio.TabIndex = 10
        '
        'Txt_Saldo
        '
        Me.Txt_Saldo.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Saldo.Enabled = False
        Me.Txt_Saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Saldo.Location = New System.Drawing.Point(435, 168)
        Me.Txt_Saldo.MaxLength = 50
        Me.Txt_Saldo.Name = "Txt_Saldo"
        Me.Txt_Saldo.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Saldo.TabIndex = 8
        Me.Txt_Saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Saldo
        '
        Me.Lbl_Saldo.AutoSize = True
        Me.Lbl_Saldo.Location = New System.Drawing.Point(395, 171)
        Me.Lbl_Saldo.Name = "Lbl_Saldo"
        Me.Lbl_Saldo.Size = New System.Drawing.Size(34, 13)
        Me.Lbl_Saldo.TabIndex = 82
        Me.Lbl_Saldo.Text = "Saldo"
        '
        'Txt_Cuota
        '
        Me.Txt_Cuota.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Cuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Cuota.Location = New System.Drawing.Point(275, 168)
        Me.Txt_Cuota.MaxLength = 50
        Me.Txt_Cuota.Name = "Txt_Cuota"
        Me.Txt_Cuota.Size = New System.Drawing.Size(121, 20)
        Me.Txt_Cuota.TabIndex = 9
        Me.Txt_Cuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Cuota
        '
        Me.Lbl_Cuota.AutoSize = True
        Me.Lbl_Cuota.Location = New System.Drawing.Point(234, 171)
        Me.Lbl_Cuota.Name = "Lbl_Cuota"
        Me.Lbl_Cuota.Size = New System.Drawing.Size(35, 13)
        Me.Lbl_Cuota.TabIndex = 80
        Me.Lbl_Cuota.Text = "Cuota"
        '
        'Txt_Importe
        '
        Me.Txt_Importe.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Importe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Importe.Location = New System.Drawing.Point(113, 168)
        Me.Txt_Importe.MaxLength = 50
        Me.Txt_Importe.Name = "Txt_Importe"
        Me.Txt_Importe.Size = New System.Drawing.Size(121, 20)
        Me.Txt_Importe.TabIndex = 7
        Me.Txt_Importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Importe
        '
        Me.Lbl_Importe.AutoSize = True
        Me.Lbl_Importe.Location = New System.Drawing.Point(24, 171)
        Me.Lbl_Importe.Name = "Lbl_Importe"
        Me.Lbl_Importe.Size = New System.Drawing.Size(42, 13)
        Me.Lbl_Importe.TabIndex = 78
        Me.Lbl_Importe.Text = "Importe"
        '
        'Txt_DescripPerceDeduc
        '
        Me.Txt_DescripPerceDeduc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPerceDeduc.Enabled = False
        Me.Txt_DescripPerceDeduc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPerceDeduc.Location = New System.Drawing.Point(190, 64)
        Me.Txt_DescripPerceDeduc.MaxLength = 200
        Me.Txt_DescripPerceDeduc.Name = "Txt_DescripPerceDeduc"
        Me.Txt_DescripPerceDeduc.ReadOnly = True
        Me.Txt_DescripPerceDeduc.Size = New System.Drawing.Size(367, 20)
        Me.Txt_DescripPerceDeduc.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Concepto"
        '
        'Txt_IdPercDeduc
        '
        Me.Txt_IdPercDeduc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdPercDeduc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdPercDeduc.Location = New System.Drawing.Point(225, 13)
        Me.Txt_IdPercDeduc.MaxLength = 50
        Me.Txt_IdPercDeduc.Name = "Txt_IdPercDeduc"
        Me.Txt_IdPercDeduc.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdPercDeduc.TabIndex = 75
        Me.Txt_IdPercDeduc.Visible = False
        '
        'Txt_NombreEmpleado
        '
        Me.Txt_NombreEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreEmpleado.Enabled = False
        Me.Txt_NombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreEmpleado.Location = New System.Drawing.Point(189, 38)
        Me.Txt_NombreEmpleado.MaxLength = 200
        Me.Txt_NombreEmpleado.Name = "Txt_NombreEmpleado"
        Me.Txt_NombreEmpleado.ReadOnly = True
        Me.Txt_NombreEmpleado.Size = New System.Drawing.Size(367, 20)
        Me.Txt_NombreEmpleado.TabIndex = 2
        '
        'Empleado
        '
        Me.Empleado.AutoSize = True
        Me.Empleado.Location = New System.Drawing.Point(24, 41)
        Me.Empleado.Name = "Empleado"
        Me.Empleado.Size = New System.Drawing.Size(54, 13)
        Me.Empleado.TabIndex = 29
        Me.Empleado.Text = "Empleado"
        '
        'DTime
        '
        Me.DTime.CustomFormat = "HH:mm:ss"
        Me.DTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTime.Location = New System.Drawing.Point(435, 90)
        Me.DTime.Name = "DTime"
        Me.DTime.ShowUpDown = True
        Me.DTime.Size = New System.Drawing.Size(117, 22)
        Me.DTime.TabIndex = 100
        Me.DTime.Value = New Date(2016, 10, 13, 16, 38, 0, 0)
        Me.DTime.Visible = False
        '
        'frmCatalogoRepetitivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 379)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoRepetitivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Repetitivos"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Repetitivo As System.Windows.Forms.Label
    Friend WithEvents Txt_IdRepetitivo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Empleado As System.Windows.Forms.Label
    Friend WithEvents Txt_NombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Txt_Cuota As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Cuota As System.Windows.Forms.Label
    Friend WithEvents Txt_Importe As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Importe As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripPerceDeduc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdPercDeduc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Saldo As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Saldo As System.Windows.Forms.Label
    Friend WithEvents Lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents DtInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cbo_Estatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Descrip As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Btn_ModifSaldo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Hora As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTime As System.Windows.Forms.DateTimePicker
End Class
