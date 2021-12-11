<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFiltrosRebaja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosRebaja))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Chk_FechaTraspaso = New System.Windows.Forms.CheckBox()
        Me.DTPicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Txt_Modelo = New System.Windows.Forms.TextBox()
        Me.Txt_DescripAgrup = New System.Windows.Forms.TextBox()
        Me.Txt_Agrupacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_IdL6 = New System.Windows.Forms.TextBox()
        Me.Txt_DescripL6 = New System.Windows.Forms.TextBox()
        Me.Txt_L6 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_IdL5 = New System.Windows.Forms.TextBox()
        Me.Txt_DescripL5 = New System.Windows.Forms.TextBox()
        Me.Txt_L5 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_IdL4 = New System.Windows.Forms.TextBox()
        Me.Txt_DescripL4 = New System.Windows.Forms.TextBox()
        Me.Txt_L4 = New System.Windows.Forms.TextBox()
        Me.Txt_IdL3 = New System.Windows.Forms.TextBox()
        Me.Txt_DescripL3 = New System.Windows.Forms.TextBox()
        Me.Txt_L3 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Txt_IdDivision = New System.Windows.Forms.TextBox()
        Me.Txt_DescripDivision = New System.Windows.Forms.TextBox()
        Me.Txt_Division = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Txt_IdL2 = New System.Windows.Forms.TextBox()
        Me.Txt_IdL1 = New System.Windows.Forms.TextBox()
        Me.Txt_IdLinea = New System.Windows.Forms.TextBox()
        Me.Txt_IdFamilia = New System.Windows.Forms.TextBox()
        Me.Txt_IdDepto = New System.Windows.Forms.TextBox()
        Me.Txt_DescripL2 = New System.Windows.Forms.TextBox()
        Me.Txt_L2 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_DescripDepto = New System.Windows.Forms.TextBox()
        Me.Txt_Depto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Txt_DescripL1 = New System.Windows.Forms.TextBox()
        Me.Txt_DescripLinea = New System.Windows.Forms.TextBox()
        Me.Txt_DescripFamilia = New System.Windows.Forms.TextBox()
        Me.Txt_L1 = New System.Windows.Forms.TextBox()
        Me.Txt_Linea = New System.Windows.Forms.TextBox()
        Me.Txt_Familia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_Sucursal = New System.Windows.Forms.ComboBox()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(16, 429)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(498, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Limpiar
        '
        Me.Btn_Limpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Limpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Limpiar.Image = Global.SIRCO.My.Resources.Resources.LIMPIAR_FILTROS
        Me.Btn_Limpiar.Location = New System.Drawing.Point(341, 0)
        Me.Btn_Limpiar.Name = "Btn_Limpiar"
        Me.Btn_Limpiar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Limpiar.TabIndex = 17
        Me.Btn_Limpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Limpiar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(392, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 18
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(443, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 16
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Chk_FechaTraspaso)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker3)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Modelo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripAgrup)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Agrupacion)
        Me.Pnl_Edicion.Controls.Add(Me.Label7)
        Me.Pnl_Edicion.Controls.Add(Me.txt_DescripMarca)
        Me.Pnl_Edicion.Controls.Add(Me.Label10)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL6)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL6)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_L6)
        Me.Pnl_Edicion.Controls.Add(Me.Label9)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL5)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL5)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_L5)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_L4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_L3)
        Me.Pnl_Edicion.Controls.Add(Me.Label26)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDivision)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDivision)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Division)
        Me.Pnl_Edicion.Controls.Add(Me.Label25)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdL1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdLinea)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFamilia)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_L2)
        Me.Pnl_Edicion.Controls.Add(Me.Label17)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Depto)
        Me.Pnl_Edicion.Controls.Add(Me.Label16)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripL1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripLinea)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripFamilia)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_L1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Linea)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Familia)
        Me.Pnl_Edicion.Controls.Add(Me.Label6)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.CB_Sucursal)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(16, 12)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(498, 411)
        Me.Pnl_Edicion.TabIndex = 2
        '
        'Chk_FechaTraspaso
        '
        Me.Chk_FechaTraspaso.AutoSize = True
        Me.Chk_FechaTraspaso.Location = New System.Drawing.Point(3, 25)
        Me.Chk_FechaTraspaso.Name = "Chk_FechaTraspaso"
        Me.Chk_FechaTraspaso.Size = New System.Drawing.Size(59, 17)
        Me.Chk_FechaTraspaso.TabIndex = 170
        Me.Chk_FechaTraspaso.Text = "Fecha "
        Me.Chk_FechaTraspaso.UseVisualStyleBackColor = True
        '
        'DTPicker3
        '
        Me.DTPicker3.Enabled = False
        Me.DTPicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker3.Location = New System.Drawing.Point(286, 22)
        Me.DTPicker3.Name = "DTPicker3"
        Me.DTPicker3.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker3.TabIndex = 1
        '
        'DTPicker2
        '
        Me.DTPicker2.Enabled = False
        Me.DTPicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker2.Location = New System.Drawing.Point(80, 22)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker2.TabIndex = 0
        '
        'Txt_Modelo
        '
        Me.Txt_Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Modelo.Location = New System.Drawing.Point(129, 85)
        Me.Txt_Modelo.MaxLength = 7
        Me.Txt_Modelo.Name = "Txt_Modelo"
        Me.Txt_Modelo.Size = New System.Drawing.Size(60, 20)
        Me.Txt_Modelo.TabIndex = 4
        '
        'Txt_DescripAgrup
        '
        Me.Txt_DescripAgrup.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripAgrup.Enabled = False
        Me.Txt_DescripAgrup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripAgrup.Location = New System.Drawing.Point(128, 371)
        Me.Txt_DescripAgrup.Name = "Txt_DescripAgrup"
        Me.Txt_DescripAgrup.ReadOnly = True
        Me.Txt_DescripAgrup.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripAgrup.TabIndex = 169
        '
        'Txt_Agrupacion
        '
        Me.Txt_Agrupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Agrupacion.Location = New System.Drawing.Point(80, 371)
        Me.Txt_Agrupacion.MaxLength = 3
        Me.Txt_Agrupacion.Name = "Txt_Agrupacion"
        Me.Txt_Agrupacion.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Agrupacion.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 374)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 168
        Me.Label7.Text = "Agrupación"
        '
        'txt_DescripMarca
        '
        Me.txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.txt_DescripMarca.Enabled = False
        Me.txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DescripMarca.Location = New System.Drawing.Point(195, 85)
        Me.txt_DescripMarca.Name = "txt_DescripMarca"
        Me.txt_DescripMarca.ReadOnly = True
        Me.txt_DescripMarca.Size = New System.Drawing.Size(152, 20)
        Me.txt_DescripMarca.TabIndex = 166
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 348)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 13)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "L6"
        '
        'Txt_IdL6
        '
        Me.Txt_IdL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL6.Location = New System.Drawing.Point(61, 345)
        Me.Txt_IdL6.MaxLength = 1
        Me.Txt_IdL6.Name = "Txt_IdL6"
        Me.Txt_IdL6.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdL6.TabIndex = 164
        Me.Txt_IdL6.Visible = False
        '
        'Txt_DescripL6
        '
        Me.Txt_DescripL6.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL6.Enabled = False
        Me.Txt_DescripL6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL6.Location = New System.Drawing.Point(128, 345)
        Me.Txt_DescripL6.Name = "Txt_DescripL6"
        Me.Txt_DescripL6.ReadOnly = True
        Me.Txt_DescripL6.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripL6.TabIndex = 163
        '
        'Txt_L6
        '
        Me.Txt_L6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_L6.Location = New System.Drawing.Point(80, 345)
        Me.Txt_L6.MaxLength = 3
        Me.Txt_L6.Name = "Txt_L6"
        Me.Txt_L6.Size = New System.Drawing.Size(42, 20)
        Me.Txt_L6.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 322)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 162
        Me.Label9.Text = "L5"
        '
        'Txt_IdL5
        '
        Me.Txt_IdL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL5.Location = New System.Drawing.Point(61, 319)
        Me.Txt_IdL5.MaxLength = 1
        Me.Txt_IdL5.Name = "Txt_IdL5"
        Me.Txt_IdL5.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdL5.TabIndex = 161
        Me.Txt_IdL5.Visible = False
        '
        'Txt_DescripL5
        '
        Me.Txt_DescripL5.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL5.Enabled = False
        Me.Txt_DescripL5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL5.Location = New System.Drawing.Point(128, 319)
        Me.Txt_DescripL5.Name = "Txt_DescripL5"
        Me.Txt_DescripL5.ReadOnly = True
        Me.Txt_DescripL5.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripL5.TabIndex = 160
        '
        'Txt_L5
        '
        Me.Txt_L5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_L5.Location = New System.Drawing.Point(80, 319)
        Me.Txt_L5.MaxLength = 3
        Me.Txt_L5.Name = "Txt_L5"
        Me.Txt_L5.Size = New System.Drawing.Size(42, 20)
        Me.Txt_L5.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 296)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "L4"
        '
        'Txt_IdL4
        '
        Me.Txt_IdL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL4.Location = New System.Drawing.Point(61, 293)
        Me.Txt_IdL4.MaxLength = 1
        Me.Txt_IdL4.Name = "Txt_IdL4"
        Me.Txt_IdL4.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdL4.TabIndex = 143
        Me.Txt_IdL4.Visible = False
        '
        'Txt_DescripL4
        '
        Me.Txt_DescripL4.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL4.Enabled = False
        Me.Txt_DescripL4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL4.Location = New System.Drawing.Point(128, 293)
        Me.Txt_DescripL4.Name = "Txt_DescripL4"
        Me.Txt_DescripL4.ReadOnly = True
        Me.Txt_DescripL4.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripL4.TabIndex = 142
        '
        'Txt_L4
        '
        Me.Txt_L4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_L4.Location = New System.Drawing.Point(80, 293)
        Me.Txt_L4.MaxLength = 3
        Me.Txt_L4.Name = "Txt_L4"
        Me.Txt_L4.Size = New System.Drawing.Size(42, 20)
        Me.Txt_L4.TabIndex = 12
        '
        'Txt_IdL3
        '
        Me.Txt_IdL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL3.Location = New System.Drawing.Point(61, 267)
        Me.Txt_IdL3.MaxLength = 1
        Me.Txt_IdL3.Name = "Txt_IdL3"
        Me.Txt_IdL3.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdL3.TabIndex = 158
        Me.Txt_IdL3.Visible = False
        '
        'Txt_DescripL3
        '
        Me.Txt_DescripL3.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL3.Enabled = False
        Me.Txt_DescripL3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL3.Location = New System.Drawing.Point(128, 267)
        Me.Txt_DescripL3.Name = "Txt_DescripL3"
        Me.Txt_DescripL3.ReadOnly = True
        Me.Txt_DescripL3.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripL3.TabIndex = 157
        '
        'Txt_L3
        '
        Me.Txt_L3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_L3.Location = New System.Drawing.Point(80, 267)
        Me.Txt_L3.MaxLength = 3
        Me.Txt_L3.Name = "Txt_L3"
        Me.Txt_L3.Size = New System.Drawing.Size(42, 20)
        Me.Txt_L3.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 270)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 13)
        Me.Label26.TabIndex = 156
        Me.Label26.Text = "L3"
        '
        'Txt_IdDivision
        '
        Me.Txt_IdDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDivision.Location = New System.Drawing.Point(61, 111)
        Me.Txt_IdDivision.MaxLength = 1
        Me.Txt_IdDivision.Name = "Txt_IdDivision"
        Me.Txt_IdDivision.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdDivision.TabIndex = 155
        Me.Txt_IdDivision.Visible = False
        '
        'Txt_DescripDivision
        '
        Me.Txt_DescripDivision.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDivision.Enabled = False
        Me.Txt_DescripDivision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDivision.Location = New System.Drawing.Point(128, 111)
        Me.Txt_DescripDivision.Name = "Txt_DescripDivision"
        Me.Txt_DescripDivision.ReadOnly = True
        Me.Txt_DescripDivision.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripDivision.TabIndex = 154
        '
        'Txt_Division
        '
        Me.Txt_Division.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Division.Location = New System.Drawing.Point(80, 111)
        Me.Txt_Division.MaxLength = 3
        Me.Txt_Division.Name = "Txt_Division"
        Me.Txt_Division.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Division.TabIndex = 5
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 114)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 13)
        Me.Label25.TabIndex = 153
        Me.Label25.Text = "Division"
        '
        'Txt_IdL2
        '
        Me.Txt_IdL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL2.Location = New System.Drawing.Point(61, 241)
        Me.Txt_IdL2.MaxLength = 1
        Me.Txt_IdL2.Name = "Txt_IdL2"
        Me.Txt_IdL2.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdL2.TabIndex = 152
        Me.Txt_IdL2.Visible = False
        '
        'Txt_IdL1
        '
        Me.Txt_IdL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdL1.Location = New System.Drawing.Point(61, 215)
        Me.Txt_IdL1.MaxLength = 1
        Me.Txt_IdL1.Name = "Txt_IdL1"
        Me.Txt_IdL1.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdL1.TabIndex = 151
        Me.Txt_IdL1.Visible = False
        '
        'Txt_IdLinea
        '
        Me.Txt_IdLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdLinea.Location = New System.Drawing.Point(61, 189)
        Me.Txt_IdLinea.MaxLength = 1
        Me.Txt_IdLinea.Name = "Txt_IdLinea"
        Me.Txt_IdLinea.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdLinea.TabIndex = 150
        Me.Txt_IdLinea.Visible = False
        '
        'Txt_IdFamilia
        '
        Me.Txt_IdFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdFamilia.Location = New System.Drawing.Point(61, 163)
        Me.Txt_IdFamilia.MaxLength = 1
        Me.Txt_IdFamilia.Name = "Txt_IdFamilia"
        Me.Txt_IdFamilia.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdFamilia.TabIndex = 149
        Me.Txt_IdFamilia.Visible = False
        '
        'Txt_IdDepto
        '
        Me.Txt_IdDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepto.Location = New System.Drawing.Point(61, 137)
        Me.Txt_IdDepto.MaxLength = 1
        Me.Txt_IdDepto.Name = "Txt_IdDepto"
        Me.Txt_IdDepto.Size = New System.Drawing.Size(17, 20)
        Me.Txt_IdDepto.TabIndex = 148
        Me.Txt_IdDepto.Visible = False
        '
        'Txt_DescripL2
        '
        Me.Txt_DescripL2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL2.Enabled = False
        Me.Txt_DescripL2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL2.Location = New System.Drawing.Point(128, 241)
        Me.Txt_DescripL2.Name = "Txt_DescripL2"
        Me.Txt_DescripL2.ReadOnly = True
        Me.Txt_DescripL2.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripL2.TabIndex = 147
        '
        'Txt_L2
        '
        Me.Txt_L2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_L2.Location = New System.Drawing.Point(80, 241)
        Me.Txt_L2.MaxLength = 3
        Me.Txt_L2.Name = "Txt_L2"
        Me.Txt_L2.Size = New System.Drawing.Size(42, 20)
        Me.Txt_L2.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 244)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 13)
        Me.Label17.TabIndex = 146
        Me.Label17.Text = "L2"
        '
        'Txt_DescripDepto
        '
        Me.Txt_DescripDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDepto.Enabled = False
        Me.Txt_DescripDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDepto.Location = New System.Drawing.Point(128, 137)
        Me.Txt_DescripDepto.Name = "Txt_DescripDepto"
        Me.Txt_DescripDepto.ReadOnly = True
        Me.Txt_DescripDepto.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripDepto.TabIndex = 145
        '
        'Txt_Depto
        '
        Me.Txt_Depto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Depto.Location = New System.Drawing.Point(80, 137)
        Me.Txt_Depto.MaxLength = 3
        Me.Txt_Depto.Name = "Txt_Depto"
        Me.Txt_Depto.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Depto.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 144
        Me.Label16.Text = "Departamento"
        '
        'Txt_DescripL1
        '
        Me.Txt_DescripL1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripL1.Enabled = False
        Me.Txt_DescripL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripL1.Location = New System.Drawing.Point(128, 215)
        Me.Txt_DescripL1.Name = "Txt_DescripL1"
        Me.Txt_DescripL1.ReadOnly = True
        Me.Txt_DescripL1.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripL1.TabIndex = 141
        '
        'Txt_DescripLinea
        '
        Me.Txt_DescripLinea.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripLinea.Enabled = False
        Me.Txt_DescripLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripLinea.Location = New System.Drawing.Point(128, 189)
        Me.Txt_DescripLinea.Name = "Txt_DescripLinea"
        Me.Txt_DescripLinea.ReadOnly = True
        Me.Txt_DescripLinea.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripLinea.TabIndex = 140
        '
        'Txt_DescripFamilia
        '
        Me.Txt_DescripFamilia.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripFamilia.Enabled = False
        Me.Txt_DescripFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripFamilia.Location = New System.Drawing.Point(128, 163)
        Me.Txt_DescripFamilia.Name = "Txt_DescripFamilia"
        Me.Txt_DescripFamilia.ReadOnly = True
        Me.Txt_DescripFamilia.Size = New System.Drawing.Size(358, 20)
        Me.Txt_DescripFamilia.TabIndex = 139
        '
        'Txt_L1
        '
        Me.Txt_L1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_L1.Location = New System.Drawing.Point(80, 215)
        Me.Txt_L1.MaxLength = 3
        Me.Txt_L1.Name = "Txt_L1"
        Me.Txt_L1.Size = New System.Drawing.Size(42, 20)
        Me.Txt_L1.TabIndex = 9
        '
        'Txt_Linea
        '
        Me.Txt_Linea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Linea.Location = New System.Drawing.Point(80, 189)
        Me.Txt_Linea.MaxLength = 3
        Me.Txt_Linea.Name = "Txt_Linea"
        Me.Txt_Linea.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Linea.TabIndex = 8
        '
        'Txt_Familia
        '
        Me.Txt_Familia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Familia.Location = New System.Drawing.Point(80, 163)
        Me.Txt_Familia.MaxLength = 3
        Me.Txt_Familia.Name = "Txt_Familia"
        Me.Txt_Familia.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Familia.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 138
        Me.Label6.Text = "L1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Línea"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Familia"
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(81, 85)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Marca.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Marca:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Sucursal:"
        Me.Label4.Visible = False
        '
        'CB_Sucursal
        '
        Me.CB_Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Sucursal.FormattingEnabled = True
        Me.CB_Sucursal.Location = New System.Drawing.Point(80, 54)
        Me.CB_Sucursal.Name = "CB_Sucursal"
        Me.CB_Sucursal.Size = New System.Drawing.Size(200, 21)
        Me.CB_Sucursal.TabIndex = 2
        Me.CB_Sucursal.Visible = False
        '
        'frmFiltrosRebaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 531)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosRebaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rebajas"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Pnl_Botones As Panel
    Friend WithEvents Btn_Limpiar As Button
    Friend WithEvents Btn_Cancelar As Button
    Friend WithEvents Btn_Aceptar As Button
    Friend WithEvents Pnl_Edicion As Panel
    Friend WithEvents Txt_Modelo As TextBox
    Friend WithEvents Txt_DescripAgrup As TextBox
    Friend WithEvents Txt_Agrupacion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_DescripMarca As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_IdL6 As TextBox
    Friend WithEvents Txt_DescripL6 As TextBox
    Friend WithEvents Txt_L6 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_IdL5 As TextBox
    Friend WithEvents Txt_DescripL5 As TextBox
    Friend WithEvents Txt_L5 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_IdL4 As TextBox
    Friend WithEvents Txt_DescripL4 As TextBox
    Friend WithEvents Txt_L4 As TextBox
    Friend WithEvents Txt_IdL3 As TextBox
    Friend WithEvents Txt_DescripL3 As TextBox
    Friend WithEvents Txt_L3 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Txt_IdDivision As TextBox
    Friend WithEvents Txt_DescripDivision As TextBox
    Friend WithEvents Txt_Division As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Txt_IdL2 As TextBox
    Friend WithEvents Txt_IdL1 As TextBox
    Friend WithEvents Txt_IdLinea As TextBox
    Friend WithEvents Txt_IdFamilia As TextBox
    Friend WithEvents Txt_IdDepto As TextBox
    Friend WithEvents Txt_DescripL2 As TextBox
    Friend WithEvents Txt_L2 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Txt_DescripDepto As TextBox
    Friend WithEvents Txt_Depto As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Txt_DescripL1 As TextBox
    Friend WithEvents Txt_DescripLinea As TextBox
    Friend WithEvents Txt_DescripFamilia As TextBox
    Friend WithEvents Txt_L1 As TextBox
    Friend WithEvents Txt_Linea As TextBox
    Friend WithEvents Txt_Familia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Marca As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CB_Sucursal As ComboBox
    Friend WithEvents Chk_FechaTraspaso As CheckBox
    Friend WithEvents DTPicker3 As DateTimePicker
    Friend WithEvents DTPicker2 As DateTimePicker
End Class
