<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosAntiBultos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosAntiBultos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Chk_FechaAsigna = New System.Windows.Forms.CheckBox
        Me.DTFecAsigFin = New System.Windows.Forms.DateTimePicker
        Me.DTFecAsigIni = New System.Windows.Forms.DateTimePicker
        Me.Txt_Descrip_Asigna = New System.Windows.Forms.TextBox
        Me.Txt_Asigna = New System.Windows.Forms.TextBox
        Me.Txt_DescripRecibe = New System.Windows.Forms.TextBox
        Me.Txt_Recibe = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Chk_FechaRecibo = New System.Windows.Forms.CheckBox
        Me.Txt_NoGuia = New System.Windows.Forms.TextBox
        Me.Txt_Folio = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.DTFecRecFin = New System.Windows.Forms.DateTimePicker
        Me.DTFecRecIni = New System.Windows.Forms.DateTimePicker
        Me.Txt_Raz_Soc = New System.Windows.Forms.TextBox
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Cbo_Estatus = New System.Windows.Forms.ComboBox
        Me.Cbo_Tipo = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Tipo)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Estatus)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_FechaAsigna)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecAsigFin)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecAsigIni)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Descrip_Asigna)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Asigna)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripRecibe)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Recibe)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_FechaRecibo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NoGuia)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Folio)
        Me.Pnl_Edicion.Controls.Add(Me.Label12)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label11)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecRecFin)
        Me.Pnl_Edicion.Controls.Add(Me.DTFecRecIni)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Raz_Soc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Proveedor)
        Me.Pnl_Edicion.Controls.Add(Me.Label6)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 301)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "N° Guía"
        '
        'Chk_FechaAsigna
        '
        Me.Chk_FechaAsigna.AutoSize = True
        Me.Chk_FechaAsigna.Location = New System.Drawing.Point(17, 32)
        Me.Chk_FechaAsigna.Name = "Chk_FechaAsigna"
        Me.Chk_FechaAsigna.Size = New System.Drawing.Size(91, 17)
        Me.Chk_FechaAsigna.TabIndex = 53
        Me.Chk_FechaAsigna.Text = "Fecha Asigna"
        Me.Chk_FechaAsigna.UseVisualStyleBackColor = True
        '
        'DTFecAsigFin
        '
        Me.DTFecAsigFin.Enabled = False
        Me.DTFecAsigFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecAsigFin.Location = New System.Drawing.Point(317, 29)
        Me.DTFecAsigFin.Name = "DTFecAsigFin"
        Me.DTFecAsigFin.Size = New System.Drawing.Size(200, 20)
        Me.DTFecAsigFin.TabIndex = 3
        '
        'DTFecAsigIni
        '
        Me.DTFecAsigIni.Enabled = False
        Me.DTFecAsigIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecAsigIni.Location = New System.Drawing.Point(111, 29)
        Me.DTFecAsigIni.Name = "DTFecAsigIni"
        Me.DTFecAsigIni.Size = New System.Drawing.Size(200, 20)
        Me.DTFecAsigIni.TabIndex = 2
        '
        'Txt_Descrip_Asigna
        '
        Me.Txt_Descrip_Asigna.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Descrip_Asigna.Enabled = False
        Me.Txt_Descrip_Asigna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descrip_Asigna.Location = New System.Drawing.Point(159, 245)
        Me.Txt_Descrip_Asigna.Name = "Txt_Descrip_Asigna"
        Me.Txt_Descrip_Asigna.ReadOnly = True
        Me.Txt_Descrip_Asigna.Size = New System.Drawing.Size(293, 20)
        Me.Txt_Descrip_Asigna.TabIndex = 13
        '
        'Txt_Asigna
        '
        Me.Txt_Asigna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Asigna.Location = New System.Drawing.Point(111, 245)
        Me.Txt_Asigna.MaxLength = 3
        Me.Txt_Asigna.Name = "Txt_Asigna"
        Me.Txt_Asigna.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Asigna.TabIndex = 12
        Me.Txt_Asigna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_DescripRecibe
        '
        Me.Txt_DescripRecibe.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripRecibe.Enabled = False
        Me.Txt_DescripRecibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripRecibe.Location = New System.Drawing.Point(159, 219)
        Me.Txt_DescripRecibe.Name = "Txt_DescripRecibe"
        Me.Txt_DescripRecibe.ReadOnly = True
        Me.Txt_DescripRecibe.Size = New System.Drawing.Size(293, 20)
        Me.Txt_DescripRecibe.TabIndex = 11
        '
        'Txt_Recibe
        '
        Me.Txt_Recibe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Recibe.Location = New System.Drawing.Point(111, 219)
        Me.Txt_Recibe.MaxLength = 3
        Me.Txt_Recibe.Name = "Txt_Recibe"
        Me.Txt_Recibe.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Recibe.TabIndex = 10
        Me.Txt_Recibe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Asigna"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Recibe"
        '
        'Chk_FechaRecibo
        '
        Me.Chk_FechaRecibo.AutoSize = True
        Me.Chk_FechaRecibo.Location = New System.Drawing.Point(17, 6)
        Me.Chk_FechaRecibo.Name = "Chk_FechaRecibo"
        Me.Chk_FechaRecibo.Size = New System.Drawing.Size(93, 17)
        Me.Chk_FechaRecibo.TabIndex = 0
        Me.Chk_FechaRecibo.Text = "Fecha Recibo"
        Me.Chk_FechaRecibo.UseVisualStyleBackColor = True
        '
        'Txt_NoGuia
        '
        Me.Txt_NoGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoGuia.Location = New System.Drawing.Point(111, 141)
        Me.Txt_NoGuia.MaxLength = 20
        Me.Txt_NoGuia.Name = "Txt_NoGuia"
        Me.Txt_NoGuia.Size = New System.Drawing.Size(200, 20)
        Me.Txt_NoGuia.TabIndex = 5
        '
        'Txt_Folio
        '
        Me.Txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Folio.Location = New System.Drawing.Point(111, 115)
        Me.Txt_Folio.MaxLength = 8
        Me.Txt_Folio.Name = "Txt_Folio"
        Me.Txt_Folio.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Folio.TabIndex = 4
        Me.Txt_Folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 118)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Folio"
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(159, 167)
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(151, 20)
        Me.Txt_DescripSucursal.TabIndex = 7
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(111, 167)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Sucursal.TabIndex = 6
        Me.Txt_Sucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 170)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Sucursal"
        '
        'DTFecRecFin
        '
        Me.DTFecRecFin.Enabled = False
        Me.DTFecRecFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecRecFin.Location = New System.Drawing.Point(317, 3)
        Me.DTFecRecFin.Name = "DTFecRecFin"
        Me.DTFecRecFin.Size = New System.Drawing.Size(200, 20)
        Me.DTFecRecFin.TabIndex = 1
        '
        'DTFecRecIni
        '
        Me.DTFecRecIni.Enabled = False
        Me.DTFecRecIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFecRecIni.Location = New System.Drawing.Point(111, 3)
        Me.DTFecRecIni.Name = "DTFecRecIni"
        Me.DTFecRecIni.Size = New System.Drawing.Size(200, 20)
        Me.DTFecRecIni.TabIndex = 0
        '
        'Txt_Raz_Soc
        '
        Me.Txt_Raz_Soc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Raz_Soc.Enabled = False
        Me.Txt_Raz_Soc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Raz_Soc.Location = New System.Drawing.Point(159, 193)
        Me.Txt_Raz_Soc.Name = "Txt_Raz_Soc"
        Me.Txt_Raz_Soc.ReadOnly = True
        Me.Txt_Raz_Soc.Size = New System.Drawing.Size(293, 20)
        Me.Txt_Raz_Soc.TabIndex = 9
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(111, 193)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Proveedor.TabIndex = 8
        Me.Txt_Proveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Proveedor"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 308)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Estatus"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Cbo_Estatus
        '
        Me.Cbo_Estatus.FormattingEnabled = True
        Me.Cbo_Estatus.Items.AddRange(New Object() {"APLICADO", "CAPTURA", "CANCELADO"})
        Me.Cbo_Estatus.Location = New System.Drawing.Point(111, 61)
        Me.Cbo_Estatus.Name = "Cbo_Estatus"
        Me.Cbo_Estatus.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Estatus.TabIndex = 58
        '
        'Cbo_Tipo
        '
        Me.Cbo_Tipo.FormattingEnabled = True
        Me.Cbo_Tipo.Items.AddRange(New Object() {"RECIBO", "DEVOLUCIÓN"})
        Me.Cbo_Tipo.Location = New System.Drawing.Point(112, 88)
        Me.Cbo_Tipo.Name = "Cbo_Tipo"
        Me.Cbo_Tipo.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_Tipo.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Tipo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmFiltrosAntiBultos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 366)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosAntiBultos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Bultos"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Txt_Raz_Soc As System.Windows.Forms.TextBox
    'Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    'Friend WithEvents Tbl_EmpleadoTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DTFecRecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTFecRecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_NoGuia As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Chk_FechaRecibo As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Descrip_Asigna As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Asigna As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripRecibe As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Recibe As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chk_FechaAsigna As System.Windows.Forms.CheckBox
    Friend WithEvents DTFecAsigFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTFecAsigIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Estatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
