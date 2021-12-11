<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoSalidas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoSalidas))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Imprimir = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_Raz_Soc = New System.Windows.Forms.TextBox
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cbo_Motivo = New System.Windows.Forms.ComboBox
        Me.Txt_NoBulto = New System.Windows.Forms.TextBox
        Me.Lbl_IdTras = New System.Windows.Forms.Label
        Me.Txt_IdTraspaso = New System.Windows.Forms.TextBox
        Me.Txt_Estatus = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Costo = New System.Windows.Forms.TextBox
        Me.Lbl_Costo = New System.Windows.Forms.Label
        Me.Txt_Precio = New System.Windows.Forms.TextBox
        Me.Lbl_Precio = New System.Windows.Forms.Label
        Me.DT_FechaTrasp = New System.Windows.Forms.DateTimePicker
        Me.Lbl_Fecha = New System.Windows.Forms.Label
        Me.Txt_Traspaso = New System.Windows.Forms.TextBox
        Me.Lbl_Traspaso = New System.Windows.Forms.Label
        Me.Txt_Observaciones = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Pnl_GridTrasp = New System.Windows.Forms.Panel
        Me.Lbl_LecturaSeries = New System.Windows.Forms.Label
        Me.Btn_Archivo = New System.Windows.Forms.Button
        Me.Txt_Articulos = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DGridS = New System.Windows.Forms.DataGridView
        Me.col_serie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_marca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_estilon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_corrida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_medida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_costo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_precio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Txt_Serie = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Pnl_Series = New System.Windows.Forms.Panel
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_GridTrasp.SuspendLayout()
        CType(Me.DGridS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Series.SuspendLayout()
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Imprimir)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 614)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(982, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.Btn_Imprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Imprimir.Image = Global.SIRCO.My.Resources.Resources.document_print
        Me.Btn_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Btn_Imprimir.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Imprimir.TabIndex = 0
        Me.Btn_Imprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(876, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Aceptar.TabIndex = 1
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.door_out
        Me.Btn_Cancelar.Location = New System.Drawing.Point(927, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 2
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Raz_Soc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Proveedor)
        Me.Pnl_Edicion.Controls.Add(Me.Label6)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Motivo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NoBulto)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_IdTras)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdTraspaso)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Estatus)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Costo)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Costo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Precio)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Precio)
        Me.Pnl_Edicion.Controls.Add(Me.DT_FechaTrasp)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Fecha)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Traspaso)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Traspaso)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Observaciones)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label16)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 5)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(640, 267)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_Raz_Soc
        '
        Me.Txt_Raz_Soc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Raz_Soc.Enabled = False
        Me.Txt_Raz_Soc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Raz_Soc.Location = New System.Drawing.Point(139, 107)
        Me.Txt_Raz_Soc.MaxLength = 50
        Me.Txt_Raz_Soc.Name = "Txt_Raz_Soc"
        Me.Txt_Raz_Soc.ReadOnly = True
        Me.Txt_Raz_Soc.Size = New System.Drawing.Size(291, 20)
        Me.Txt_Raz_Soc.TabIndex = 145
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(88, 107)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.Size = New System.Drawing.Size(45, 20)
        Me.Txt_Proveedor.TabIndex = 144
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "Proveedor"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 142
        Me.Label4.Text = "Folio de Bulto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Motivo"
        '
        'Cbo_Motivo
        '
        Me.Cbo_Motivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Motivo.FormattingEnabled = True
        Me.Cbo_Motivo.Items.AddRange(New Object() {"ERROR DE RECIBO", "LLEGO DE PROVEEDOR", "SE DETECTO EN INVENTARIO", "SE DETECTO EN PRE-INVENTARIO DE TDA", "SE GENERO EN PROCESO DE VENTA"})
        Me.Cbo_Motivo.Location = New System.Drawing.Point(88, 133)
        Me.Cbo_Motivo.Name = "Cbo_Motivo"
        Me.Cbo_Motivo.Size = New System.Drawing.Size(285, 21)
        Me.Cbo_Motivo.TabIndex = 140
        '
        'Txt_NoBulto
        '
        Me.Txt_NoBulto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_NoBulto.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_NoBulto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NoBulto.Location = New System.Drawing.Point(88, 41)
        Me.Txt_NoBulto.MaxLength = 12
        Me.Txt_NoBulto.Name = "Txt_NoBulto"
        Me.Txt_NoBulto.Size = New System.Drawing.Size(120, 26)
        Me.Txt_NoBulto.TabIndex = 139
        Me.Txt_NoBulto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_IdTras
        '
        Me.Lbl_IdTras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_IdTras.AutoSize = True
        Me.Lbl_IdTras.Location = New System.Drawing.Point(462, 41)
        Me.Lbl_IdTras.Name = "Lbl_IdTras"
        Me.Lbl_IdTras.Size = New System.Drawing.Size(63, 13)
        Me.Lbl_IdTras.TabIndex = 138
        Me.Lbl_IdTras.Text = "Id Traspaso"
        '
        'Txt_IdTraspaso
        '
        Me.Txt_IdTraspaso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_IdTraspaso.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdTraspaso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdTraspaso.Location = New System.Drawing.Point(529, 38)
        Me.Txt_IdTraspaso.MaxLength = 6
        Me.Txt_IdTraspaso.Name = "Txt_IdTraspaso"
        Me.Txt_IdTraspaso.Size = New System.Drawing.Size(96, 20)
        Me.Txt_IdTraspaso.TabIndex = 7
        Me.Txt_IdTraspaso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Estatus
        '
        Me.Txt_Estatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Estatus.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Estatus.Enabled = False
        Me.Txt_Estatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estatus.Location = New System.Drawing.Point(212, 12)
        Me.Txt_Estatus.MaxLength = 2
        Me.Txt_Estatus.Name = "Txt_Estatus"
        Me.Txt_Estatus.ReadOnly = True
        Me.Txt_Estatus.Size = New System.Drawing.Size(107, 20)
        Me.Txt_Estatus.TabIndex = 1
        Me.Txt_Estatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(166, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Estatus"
        '
        'Txt_Costo
        '
        Me.Txt_Costo.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Costo.Enabled = False
        Me.Txt_Costo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Costo.Location = New System.Drawing.Point(267, 234)
        Me.Txt_Costo.Name = "Txt_Costo"
        Me.Txt_Costo.ReadOnly = True
        Me.Txt_Costo.Size = New System.Drawing.Size(139, 26)
        Me.Txt_Costo.TabIndex = 14
        Me.Txt_Costo.Text = "$0.00"
        Me.Txt_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Costo
        '
        Me.Lbl_Costo.AutoSize = True
        Me.Lbl_Costo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Costo.Location = New System.Drawing.Point(213, 240)
        Me.Lbl_Costo.Name = "Lbl_Costo"
        Me.Lbl_Costo.Size = New System.Drawing.Size(52, 16)
        Me.Lbl_Costo.TabIndex = 122
        Me.Lbl_Costo.Text = "Costo:"
        '
        'Txt_Precio
        '
        Me.Txt_Precio.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Precio.Enabled = False
        Me.Txt_Precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Precio.Location = New System.Drawing.Point(465, 234)
        Me.Txt_Precio.Name = "Txt_Precio"
        Me.Txt_Precio.ReadOnly = True
        Me.Txt_Precio.Size = New System.Drawing.Size(160, 26)
        Me.Txt_Precio.TabIndex = 15
        Me.Txt_Precio.Text = "$0.00"
        Me.Txt_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_Precio
        '
        Me.Lbl_Precio.AutoSize = True
        Me.Lbl_Precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Precio.Location = New System.Drawing.Point(409, 240)
        Me.Lbl_Precio.Name = "Lbl_Precio"
        Me.Lbl_Precio.Size = New System.Drawing.Size(57, 16)
        Me.Lbl_Precio.TabIndex = 120
        Me.Lbl_Precio.Text = "Precio:"
        '
        'DT_FechaTrasp
        '
        Me.DT_FechaTrasp.Enabled = False
        Me.DT_FechaTrasp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_FechaTrasp.Location = New System.Drawing.Point(387, 9)
        Me.DT_FechaTrasp.Name = "DT_FechaTrasp"
        Me.DT_FechaTrasp.Size = New System.Drawing.Size(238, 20)
        Me.DT_FechaTrasp.TabIndex = 2
        '
        'Lbl_Fecha
        '
        Me.Lbl_Fecha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Fecha.AutoSize = True
        Me.Lbl_Fecha.Location = New System.Drawing.Point(338, 15)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Fecha.TabIndex = 118
        Me.Lbl_Fecha.Text = "Fecha"
        '
        'Txt_Traspaso
        '
        Me.Txt_Traspaso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Traspaso.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Traspaso.Enabled = False
        Me.Txt_Traspaso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Traspaso.Location = New System.Drawing.Point(86, 12)
        Me.Txt_Traspaso.MaxLength = 2
        Me.Txt_Traspaso.Name = "Txt_Traspaso"
        Me.Txt_Traspaso.ReadOnly = True
        Me.Txt_Traspaso.Size = New System.Drawing.Size(74, 20)
        Me.Txt_Traspaso.TabIndex = 0
        Me.Txt_Traspaso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_Traspaso
        '
        Me.Lbl_Traspaso.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_Traspaso.AutoSize = True
        Me.Lbl_Traspaso.Location = New System.Drawing.Point(8, 15)
        Me.Lbl_Traspaso.Name = "Lbl_Traspaso"
        Me.Lbl_Traspaso.Size = New System.Drawing.Size(36, 13)
        Me.Lbl_Traspaso.TabIndex = 116
        Me.Lbl_Traspaso.Text = "Salida"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Observaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Observaciones.Location = New System.Drawing.Point(88, 160)
        Me.Txt_Observaciones.MaxLength = 700
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.Size = New System.Drawing.Size(537, 57)
        Me.Txt_Observaciones.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Observaciones"
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(139, 81)
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(291, 20)
        Me.Txt_DescripSucursal.TabIndex = 4
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(88, 81)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(45, 20)
        Me.Txt_Sucursal.TabIndex = 3
        Me.Txt_Sucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 84)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "Sucursal"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(102, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 102
        Me.Label5.Visible = False
        '
        'Pnl_GridTrasp
        '
        Me.Pnl_GridTrasp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_GridTrasp.Controls.Add(Me.Lbl_LecturaSeries)
        Me.Pnl_GridTrasp.Controls.Add(Me.Btn_Archivo)
        Me.Pnl_GridTrasp.Controls.Add(Me.Txt_Articulos)
        Me.Pnl_GridTrasp.Controls.Add(Me.Label8)
        Me.Pnl_GridTrasp.Controls.Add(Me.DGridS)
        Me.Pnl_GridTrasp.Controls.Add(Me.Txt_Serie)
        Me.Pnl_GridTrasp.Controls.Add(Me.Label7)
        Me.Pnl_GridTrasp.Location = New System.Drawing.Point(12, 278)
        Me.Pnl_GridTrasp.Name = "Pnl_GridTrasp"
        Me.Pnl_GridTrasp.Size = New System.Drawing.Size(965, 333)
        Me.Pnl_GridTrasp.TabIndex = 2
        '
        'Lbl_LecturaSeries
        '
        Me.Lbl_LecturaSeries.AutoSize = True
        Me.Lbl_LecturaSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_LecturaSeries.Location = New System.Drawing.Point(428, 20)
        Me.Lbl_LecturaSeries.Name = "Lbl_LecturaSeries"
        Me.Lbl_LecturaSeries.Size = New System.Drawing.Size(106, 18)
        Me.Lbl_LecturaSeries.TabIndex = 123
        Me.Lbl_LecturaSeries.Text = "Escaneados:"
        '
        'Btn_Archivo
        '
        Me.Btn_Archivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Archivo.Image = Global.SIRCO.My.Resources.Resources.document_add
        Me.Btn_Archivo.Location = New System.Drawing.Point(349, 3)
        Me.Btn_Archivo.Name = "Btn_Archivo"
        Me.Btn_Archivo.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Archivo.TabIndex = 1
        Me.Btn_Archivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Archivo.UseVisualStyleBackColor = True
        '
        'Txt_Articulos
        '
        Me.Txt_Articulos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Articulos.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_Articulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Articulos.Location = New System.Drawing.Point(888, 15)
        Me.Txt_Articulos.Name = "Txt_Articulos"
        Me.Txt_Articulos.ReadOnly = True
        Me.Txt_Articulos.Size = New System.Drawing.Size(56, 29)
        Me.Txt_Articulos.TabIndex = 2
        Me.Txt_Articulos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(791, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 24)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "Articulos"
        '
        'DGridS
        '
        Me.DGridS.AllowUserToAddRows = False
        Me.DGridS.AllowUserToResizeColumns = False
        Me.DGridS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGridS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_serie, Me.col_marca, Me.col_estilon, Me.col_corrida, Me.col_medida, Me.col_descrip, Me.col_costo, Me.col_precio})
        Me.DGridS.Location = New System.Drawing.Point(2, 61)
        Me.DGridS.Name = "DGridS"
        Me.DGridS.ReadOnly = True
        Me.DGridS.RowHeadersVisible = False
        Me.DGridS.Size = New System.Drawing.Size(955, 265)
        Me.DGridS.TabIndex = 3
        '
        'col_serie
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_serie.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_serie.HeaderText = "Serie"
        Me.col_serie.Name = "col_serie"
        Me.col_serie.ReadOnly = True
        Me.col_serie.Width = 125
        '
        'col_marca
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_marca.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_marca.HeaderText = "Marca"
        Me.col_marca.Name = "col_marca"
        Me.col_marca.ReadOnly = True
        Me.col_marca.Width = 60
        '
        'col_estilon
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_estilon.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_estilon.HeaderText = "Estilo"
        Me.col_estilon.Name = "col_estilon"
        Me.col_estilon.ReadOnly = True
        Me.col_estilon.Width = 60
        '
        'col_corrida
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_corrida.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_corrida.HeaderText = "Corrida"
        Me.col_corrida.Name = "col_corrida"
        Me.col_corrida.ReadOnly = True
        Me.col_corrida.Width = 60
        '
        'col_medida
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_medida.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_medida.HeaderText = "Medida"
        Me.col_medida.Name = "col_medida"
        Me.col_medida.ReadOnly = True
        Me.col_medida.Width = 60
        '
        'col_descrip
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.col_descrip.DefaultCellStyle = DataGridViewCellStyle7
        Me.col_descrip.HeaderText = "Descripción"
        Me.col_descrip.Name = "col_descrip"
        Me.col_descrip.ReadOnly = True
        Me.col_descrip.Width = 370
        '
        'col_costo
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.col_costo.DefaultCellStyle = DataGridViewCellStyle8
        Me.col_costo.HeaderText = "Costo"
        Me.col_costo.Name = "col_costo"
        Me.col_costo.ReadOnly = True
        Me.col_costo.Width = 70
        '
        'col_precio
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.col_precio.DefaultCellStyle = DataGridViewCellStyle9
        Me.col_precio.HeaderText = "Precio"
        Me.col_precio.Name = "col_precio"
        Me.col_precio.ReadOnly = True
        Me.col_precio.Width = 70
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Serie.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Location = New System.Drawing.Point(105, 21)
        Me.Txt_Serie.MaxLength = 13
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Size = New System.Drawing.Size(142, 26)
        Me.Txt_Serie.TabIndex = 0
        Me.Txt_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(39, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 18)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Serie"
        '
        'Pnl_Series
        '
        Me.Pnl_Series.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Series.Controls.Add(Me.PBox)
        Me.Pnl_Series.Location = New System.Drawing.Point(658, 5)
        Me.Pnl_Series.Name = "Pnl_Series"
        Me.Pnl_Series.Size = New System.Drawing.Size(319, 267)
        Me.Pnl_Series.TabIndex = 1
        '
        'PBox
        '
        Me.PBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBox.Image = Global.SIRCO.My.Resources.Resources.ZAPATERIA_TORREON
        Me.PBox.InitialImage = Nothing
        Me.PBox.Location = New System.Drawing.Point(5, 3)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(306, 257)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox.TabIndex = 4
        Me.PBox.TabStop = False
        '
        'frmCatalogoSalidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 670)
        Me.Controls.Add(Me.Pnl_Series)
        Me.Controls.Add(Me.Pnl_GridTrasp)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoSalidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Salidas de Inventario"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_GridTrasp.ResumeLayout(False)
        Me.Pnl_GridTrasp.PerformLayout()
        CType(Me.DGridS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Series.ResumeLayout(False)
        CType(Me.PBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DT_FechaTrasp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents Txt_Traspaso As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Traspaso As System.Windows.Forms.Label
    Friend WithEvents Txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Pnl_GridTrasp As System.Windows.Forms.Panel
    Friend WithEvents Txt_Serie As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGridS As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_Articulos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Series As System.Windows.Forms.Panel
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
    Friend WithEvents Btn_Archivo As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents col_serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_estilon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_corrida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_medida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_costo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Txt_Costo As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Costo As System.Windows.Forms.Label
    Friend WithEvents Txt_Precio As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Precio As System.Windows.Forms.Label
    Friend WithEvents Lbl_LecturaSeries As System.Windows.Forms.Label
    Friend WithEvents Txt_Estatus As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lbl_IdTras As System.Windows.Forms.Label
    Friend WithEvents Txt_IdTraspaso As System.Windows.Forms.TextBox
    Friend WithEvents Txt_NoBulto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Motivo As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Raz_Soc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
