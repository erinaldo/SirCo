<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoActividades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoActividades))
        Me.Pnl_Grid = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Lbl_Satisfaccion = New System.Windows.Forms.Label
        Me.Txt_Satisfaccion = New System.Windows.Forms.TextBox
        Me.Txt_IdDepto = New System.Windows.Forms.TextBox
        Me.Txt_AreaDescrip = New System.Windows.Forms.TextBox
        Me.Txt_Area = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Lbl_Resultado = New System.Windows.Forms.Label
        Me.Txt_Resultado = New System.Windows.Forms.TextBox
        Me.Lbl_EstatusFecha = New System.Windows.Forms.Label
        Me.Cbo_TipoAct = New System.Windows.Forms.ComboBox
        Me.Lbl_Tipo = New System.Windows.Forms.Label
        Me.DTI_FechaAct = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Descripcion = New System.Windows.Forms.TextBox
        Me.Lbl_Descripcion = New System.Windows.Forms.Label
        Me.Txt_Folio = New System.Windows.Forms.TextBox
        Me.Txt_Asignado = New System.Windows.Forms.TextBox
        Me.Txt_DescripAsignado = New System.Windows.Forms.TextBox
        Me.Lbl_Asignado = New System.Windows.Forms.Label
        Me.Lbl_Reporta = New System.Windows.Forms.Label
        Me.Txt_ReportaDescrip = New System.Windows.Forms.TextBox
        Me.Txt_Reporta = New System.Windows.Forms.TextBox
        Me.CMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModificarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConsultarProveedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Editar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Grid.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.CMenu1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Grid
        '
        Me.Pnl_Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Grid.Controls.Add(Me.Panel1)
        Me.Pnl_Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_Grid.Location = New System.Drawing.Point(0, 0)
        Me.Pnl_Grid.Name = "Pnl_Grid"
        Me.Pnl_Grid.Size = New System.Drawing.Size(436, 440)
        Me.Pnl_Grid.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Lbl_Satisfaccion)
        Me.Panel1.Controls.Add(Me.Txt_Satisfaccion)
        Me.Panel1.Controls.Add(Me.Txt_IdDepto)
        Me.Panel1.Controls.Add(Me.Txt_AreaDescrip)
        Me.Panel1.Controls.Add(Me.Txt_Area)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Lbl_Resultado)
        Me.Panel1.Controls.Add(Me.Txt_Resultado)
        Me.Panel1.Controls.Add(Me.Lbl_EstatusFecha)
        Me.Panel1.Controls.Add(Me.Cbo_TipoAct)
        Me.Panel1.Controls.Add(Me.Lbl_Tipo)
        Me.Panel1.Controls.Add(Me.DTI_FechaAct)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Txt_Descripcion)
        Me.Panel1.Controls.Add(Me.Lbl_Descripcion)
        Me.Panel1.Controls.Add(Me.Txt_Folio)
        Me.Panel1.Controls.Add(Me.Txt_Asignado)
        Me.Panel1.Controls.Add(Me.Txt_DescripAsignado)
        Me.Panel1.Controls.Add(Me.Lbl_Asignado)
        Me.Panel1.Controls.Add(Me.Lbl_Reporta)
        Me.Panel1.Controls.Add(Me.Txt_ReportaDescrip)
        Me.Panel1.Controls.Add(Me.Txt_Reporta)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 430)
        Me.Panel1.TabIndex = 3
        '
        'Lbl_Satisfaccion
        '
        Me.Lbl_Satisfaccion.AutoSize = True
        Me.Lbl_Satisfaccion.Location = New System.Drawing.Point(13, 346)
        Me.Lbl_Satisfaccion.Name = "Lbl_Satisfaccion"
        Me.Lbl_Satisfaccion.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_Satisfaccion.TabIndex = 171
        Me.Lbl_Satisfaccion.Text = "Satisfacción"
        '
        'Txt_Satisfaccion
        '
        Me.Txt_Satisfaccion.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Satisfaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Satisfaccion.Location = New System.Drawing.Point(82, 343)
        Me.Txt_Satisfaccion.MaxLength = 250
        Me.Txt_Satisfaccion.Multiline = True
        Me.Txt_Satisfaccion.Name = "Txt_Satisfaccion"
        Me.Txt_Satisfaccion.Size = New System.Drawing.Size(325, 79)
        Me.Txt_Satisfaccion.TabIndex = 7
        '
        'Txt_IdDepto
        '
        Me.Txt_IdDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepto.Location = New System.Drawing.Point(376, 65)
        Me.Txt_IdDepto.MaxLength = 3
        Me.Txt_IdDepto.Name = "Txt_IdDepto"
        Me.Txt_IdDepto.ReadOnly = True
        Me.Txt_IdDepto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_IdDepto.TabIndex = 169
        Me.Txt_IdDepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_IdDepto.Visible = False
        '
        'Txt_AreaDescrip
        '
        Me.Txt_AreaDescrip.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_AreaDescrip.Enabled = False
        Me.Txt_AreaDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AreaDescrip.Location = New System.Drawing.Point(137, 65)
        Me.Txt_AreaDescrip.MaxLength = 30
        Me.Txt_AreaDescrip.Name = "Txt_AreaDescrip"
        Me.Txt_AreaDescrip.Size = New System.Drawing.Size(270, 20)
        Me.Txt_AreaDescrip.TabIndex = 168
        '
        'Txt_Area
        '
        Me.Txt_Area.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Area.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Area.Location = New System.Drawing.Point(82, 65)
        Me.Txt_Area.MaxLength = 3
        Me.Txt_Area.Name = "Txt_Area"
        Me.Txt_Area.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Area.TabIndex = 1
        Me.Txt_Area.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Reporta"
        '
        'Lbl_Resultado
        '
        Me.Lbl_Resultado.AutoSize = True
        Me.Lbl_Resultado.Location = New System.Drawing.Point(13, 261)
        Me.Lbl_Resultado.Name = "Lbl_Resultado"
        Me.Lbl_Resultado.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_Resultado.TabIndex = 165
        Me.Lbl_Resultado.Text = "Solución"
        '
        'Txt_Resultado
        '
        Me.Txt_Resultado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Resultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Resultado.Location = New System.Drawing.Point(82, 258)
        Me.Txt_Resultado.MaxLength = 250
        Me.Txt_Resultado.Multiline = True
        Me.Txt_Resultado.Name = "Txt_Resultado"
        Me.Txt_Resultado.Size = New System.Drawing.Size(325, 79)
        Me.Txt_Resultado.TabIndex = 6
        '
        'Lbl_EstatusFecha
        '
        Me.Lbl_EstatusFecha.AutoSize = True
        Me.Lbl_EstatusFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_EstatusFecha.Location = New System.Drawing.Point(79, 13)
        Me.Lbl_EstatusFecha.Name = "Lbl_EstatusFecha"
        Me.Lbl_EstatusFecha.Size = New System.Drawing.Size(92, 16)
        Me.Lbl_EstatusFecha.TabIndex = 163
        Me.Lbl_EstatusFecha.Text = "Lbl_Estatus:"
        Me.Lbl_EstatusFecha.Visible = False
        '
        'Cbo_TipoAct
        '
        Me.Cbo_TipoAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_TipoAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_TipoAct.FormattingEnabled = True
        Me.Cbo_TipoAct.Items.AddRange(New Object() {"DESARROLLO", "REPORTE", "DOCUMENTACION", "REPARACION", "SOPORTE", "RESPALDO", "COTIZACION", "INSTALACION"})
        Me.Cbo_TipoAct.Location = New System.Drawing.Point(82, 91)
        Me.Cbo_TipoAct.Name = "Cbo_TipoAct"
        Me.Cbo_TipoAct.Size = New System.Drawing.Size(325, 21)
        Me.Cbo_TipoAct.TabIndex = 2
        '
        'Lbl_Tipo
        '
        Me.Lbl_Tipo.AutoSize = True
        Me.Lbl_Tipo.Location = New System.Drawing.Point(13, 94)
        Me.Lbl_Tipo.Name = "Lbl_Tipo"
        Me.Lbl_Tipo.Size = New System.Drawing.Size(28, 13)
        Me.Lbl_Tipo.TabIndex = 161
        Me.Lbl_Tipo.Text = "Tipo"
        '
        'DTI_FechaAct
        '
        Me.DTI_FechaAct.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTI_FechaAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTI_FechaAct.Location = New System.Drawing.Point(82, 39)
        Me.DTI_FechaAct.Name = "DTI_FechaAct"
        Me.DTI_FechaAct.Size = New System.Drawing.Size(325, 20)
        Me.DTI_FechaAct.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 159
        Me.Label4.Text = "Fecha"
        '
        'Txt_Descripcion
        '
        Me.Txt_Descripcion.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Descripcion.Location = New System.Drawing.Point(82, 173)
        Me.Txt_Descripcion.MaxLength = 250
        Me.Txt_Descripcion.Multiline = True
        Me.Txt_Descripcion.Name = "Txt_Descripcion"
        Me.Txt_Descripcion.Size = New System.Drawing.Size(325, 79)
        Me.Txt_Descripcion.TabIndex = 5
        '
        'Lbl_Descripcion
        '
        Me.Lbl_Descripcion.AutoSize = True
        Me.Lbl_Descripcion.Location = New System.Drawing.Point(12, 176)
        Me.Lbl_Descripcion.Name = "Lbl_Descripcion"
        Me.Lbl_Descripcion.Size = New System.Drawing.Size(63, 13)
        Me.Lbl_Descripcion.TabIndex = 157
        Me.Lbl_Descripcion.Text = "Descripción"
        '
        'Txt_Folio
        '
        Me.Txt_Folio.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Folio.Location = New System.Drawing.Point(365, 13)
        Me.Txt_Folio.MaxLength = 3
        Me.Txt_Folio.Name = "Txt_Folio"
        Me.Txt_Folio.ReadOnly = True
        Me.Txt_Folio.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Folio.TabIndex = 0
        Me.Txt_Folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Folio.Visible = False
        '
        'Txt_Asignado
        '
        Me.Txt_Asignado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Asignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Asignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Asignado.Location = New System.Drawing.Point(82, 144)
        Me.Txt_Asignado.MaxLength = 3
        Me.Txt_Asignado.Name = "Txt_Asignado"
        Me.Txt_Asignado.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Asignado.TabIndex = 4
        Me.Txt_Asignado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_DescripAsignado
        '
        Me.Txt_DescripAsignado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripAsignado.Enabled = False
        Me.Txt_DescripAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripAsignado.Location = New System.Drawing.Point(137, 144)
        Me.Txt_DescripAsignado.MaxLength = 30
        Me.Txt_DescripAsignado.Name = "Txt_DescripAsignado"
        Me.Txt_DescripAsignado.ReadOnly = True
        Me.Txt_DescripAsignado.Size = New System.Drawing.Size(270, 20)
        Me.Txt_DescripAsignado.TabIndex = 126
        '
        'Lbl_Asignado
        '
        Me.Lbl_Asignado.AutoSize = True
        Me.Lbl_Asignado.Location = New System.Drawing.Point(12, 147)
        Me.Lbl_Asignado.Name = "Lbl_Asignado"
        Me.Lbl_Asignado.Size = New System.Drawing.Size(51, 13)
        Me.Lbl_Asignado.TabIndex = 133
        Me.Lbl_Asignado.Text = "Asignado"
        '
        'Lbl_Reporta
        '
        Me.Lbl_Reporta.AutoSize = True
        Me.Lbl_Reporta.Location = New System.Drawing.Point(13, 68)
        Me.Lbl_Reporta.Name = "Lbl_Reporta"
        Me.Lbl_Reporta.Size = New System.Drawing.Size(29, 13)
        Me.Lbl_Reporta.TabIndex = 130
        Me.Lbl_Reporta.Text = "Área"
        '
        'Txt_ReportaDescrip
        '
        Me.Txt_ReportaDescrip.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ReportaDescrip.Enabled = False
        Me.Txt_ReportaDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ReportaDescrip.Location = New System.Drawing.Point(137, 118)
        Me.Txt_ReportaDescrip.MaxLength = 30
        Me.Txt_ReportaDescrip.Name = "Txt_ReportaDescrip"
        Me.Txt_ReportaDescrip.Size = New System.Drawing.Size(270, 20)
        Me.Txt_ReportaDescrip.TabIndex = 118
        '
        'Txt_Reporta
        '
        Me.Txt_Reporta.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Reporta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Reporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Reporta.Location = New System.Drawing.Point(82, 118)
        Me.Txt_Reporta.MaxLength = 3
        Me.Txt_Reporta.Name = "Txt_Reporta"
        Me.Txt_Reporta.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Reporta.TabIndex = 3
        Me.Txt_Reporta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CMenu1
        '
        Me.CMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoProveedorToolStripMenuItem, Me.ModificarProveedorToolStripMenuItem, Me.ConsultarProveedorToolStripMenuItem})
        Me.CMenu1.Name = "CMenu1"
        Me.CMenu1.Size = New System.Drawing.Size(185, 70)
        '
        'NuevoProveedorToolStripMenuItem
        '
        Me.NuevoProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.NuevoProveedorToolStripMenuItem.Name = "NuevoProveedorToolStripMenuItem"
        Me.NuevoProveedorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.NuevoProveedorToolStripMenuItem.Text = "Nuevo Proveedor"
        '
        'ModificarProveedorToolStripMenuItem
        '
        Me.ModificarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.ModificarProveedorToolStripMenuItem.Name = "ModificarProveedorToolStripMenuItem"
        Me.ModificarProveedorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ModificarProveedorToolStripMenuItem.Text = "Modificar Proveedor"
        '
        'ConsultarProveedorToolStripMenuItem
        '
        Me.ConsultarProveedorToolStripMenuItem.Image = Global.SIRCO.My.Resources.Resources.find
        Me.ConsultarProveedorToolStripMenuItem.Name = "ConsultarProveedorToolStripMenuItem"
        Me.ConsultarProveedorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ConsultarProveedorToolStripMenuItem.Text = "Consultar Proveedor"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Nuevo)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Editar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 440)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(436, 55)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(330, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Nuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Nuevo.Image = Global.SIRCO.My.Resources.Resources.new_20doc
        Me.Btn_Nuevo.Location = New System.Drawing.Point(51, 0)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Nuevo.TabIndex = 140
        Me.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        Me.Btn_Nuevo.Visible = False
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(381, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Aceptar.TabIndex = 0
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Editar
        '
        Me.Btn_Editar.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Editar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Editar.Image = Global.SIRCO.My.Resources.Resources.Editar
        Me.Btn_Editar.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Editar.Name = "Btn_Editar"
        Me.Btn_Editar.Size = New System.Drawing.Size(51, 51)
        Me.Btn_Editar.TabIndex = 1
        Me.Btn_Editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Editar.UseVisualStyleBackColor = True
        Me.Btn_Editar.Visible = False
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmCatalogoActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 495)
        Me.Controls.Add(Me.Pnl_Grid)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCatalogoActividades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Help Desk"
        Me.Pnl_Grid.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.CMenu1.ResumeLayout(False)
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Grid As System.Windows.Forms.Panel
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Editar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarProveedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Txt_Asignado As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripAsignado As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Asignado As System.Windows.Forms.Label
    Friend WithEvents Lbl_Reporta As System.Windows.Forms.Label
    Friend WithEvents Txt_ReportaDescrip As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Reporta As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Txt_Folio As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Descripcion As System.Windows.Forms.Label
    Friend WithEvents Cbo_TipoAct As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_Tipo As System.Windows.Forms.Label
    Friend WithEvents DTI_FechaAct As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Lbl_EstatusFecha As System.Windows.Forms.Label
    Friend WithEvents Lbl_Resultado As System.Windows.Forms.Label
    Friend WithEvents Txt_Resultado As System.Windows.Forms.TextBox
    Friend WithEvents Txt_AreaDescrip As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Area As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdDepto As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Satisfaccion As System.Windows.Forms.Label
    Friend WithEvents Txt_Satisfaccion As System.Windows.Forms.TextBox
End Class
