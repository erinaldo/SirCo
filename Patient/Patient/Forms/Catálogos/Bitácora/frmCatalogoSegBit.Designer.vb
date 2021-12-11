<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoSegBit
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoSegBit))
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Cbo_Motivo = New System.Windows.Forms.ComboBox()
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox()
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Estilon = New System.Windows.Forms.TextBox()
        Me.Txt_Marca = New System.Windows.Forms.TextBox()
        Me.Txt_Id_SegBit = New System.Windows.Forms.TextBox()
        Me.Txt_Comentarios = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Realiza = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Atiende = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPicker = New System.Windows.Forms.DateTimePicker()
        Me.Txt_OrdeComp = New System.Windows.Forms.TextBox()
        Me.SirCoDataSet = New SIRCO.SirCoDataSet()
        Me.SirCoDataSet1 = New SIRCO.SirCoDataSet1()
        Me.MotsegpedidoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MotsegpedidoTableAdapter = New SIRCO.SirCoDataSet1TableAdapters.motsegpedidoTableAdapter()
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Edicion.SuspendLayout()
        CType(Me.SirCoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MotsegpedidoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BackColor = System.Drawing.Color.White
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.PictureBox1)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(13, 305)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(559, 86)
        Me.Pnl_Botones.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = CType(resources.GetObject("PictureBox1.ErrorImage"), System.Drawing.Image)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(26, -17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(102, 101)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(453, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 82)
        Me.Btn_Cancelar.TabIndex = 26
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
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 82)
        Me.Btn_Aceptar.TabIndex = 25
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "OrdeComp"
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Motivo)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Edicion.Controls.Add(Me.Label8)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Estilon)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Id_SegBit)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Comentarios)
        Me.Pnl_Edicion.Controls.Add(Me.Label7)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Realiza)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Atiende)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_OrdeComp)
        Me.Pnl_Edicion.Controls.Add(Me.Label6)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(559, 296)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Cbo_Motivo
        '
        Me.Cbo_Motivo.DataSource = Me.MotsegpedidoBindingSource
        Me.Cbo_Motivo.DisplayMember = "motivo"
        Me.Cbo_Motivo.FormattingEnabled = True
        Me.Cbo_Motivo.Location = New System.Drawing.Point(109, 145)
        Me.Cbo_Motivo.Name = "Cbo_Motivo"
        Me.Cbo_Motivo.Size = New System.Drawing.Size(425, 21)
        Me.Cbo_Motivo.TabIndex = 9
        Me.Cbo_Motivo.ValueMember = "idmotivo"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Sucursal.Enabled = False
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(110, 13)
        Me.Txt_Sucursal.MaxLength = 3
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(34, 22)
        Me.Txt_Sucursal.TabIndex = 0
        Me.Txt_Sucursal.Text = "02"
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(266, 41)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(166, 20)
        Me.Txt_DescripMarca.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Modelo"
        '
        'Txt_Estilon
        '
        Me.Txt_Estilon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilon.Location = New System.Drawing.Point(150, 41)
        Me.Txt_Estilon.MaxLength = 7
        Me.Txt_Estilon.Name = "Txt_Estilon"
        Me.Txt_Estilon.Size = New System.Drawing.Size(110, 20)
        Me.Txt_Estilon.TabIndex = 4
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(110, 41)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(34, 20)
        Me.Txt_Marca.TabIndex = 3
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
        'Txt_Comentarios
        '
        Me.Txt_Comentarios.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Comentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Comentarios.Location = New System.Drawing.Point(110, 181)
        Me.Txt_Comentarios.MaxLength = 150
        Me.Txt_Comentarios.Multiline = True
        Me.Txt_Comentarios.Name = "Txt_Comentarios"
        Me.Txt_Comentarios.Size = New System.Drawing.Size(425, 98)
        Me.Txt_Comentarios.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Comentarios"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Motivo"
        '
        'Txt_Realiza
        '
        Me.Txt_Realiza.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Realiza.Enabled = False
        Me.Txt_Realiza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Realiza.Location = New System.Drawing.Point(109, 93)
        Me.Txt_Realiza.MaxLength = 100
        Me.Txt_Realiza.Name = "Txt_Realiza"
        Me.Txt_Realiza.Size = New System.Drawing.Size(425, 20)
        Me.Txt_Realiza.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Realiza"
        '
        'Txt_Atiende
        '
        Me.Txt_Atiende.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Atiende.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Atiende.Location = New System.Drawing.Point(109, 119)
        Me.Txt_Atiende.MaxLength = 100
        Me.Txt_Atiende.Name = "Txt_Atiende"
        Me.Txt_Atiende.Size = New System.Drawing.Size(425, 20)
        Me.Txt_Atiende.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Atiende"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Fecha"
        '
        'DTPicker
        '
        Me.DTPicker.Enabled = False
        Me.DTPicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker.Location = New System.Drawing.Point(109, 67)
        Me.DTPicker.Name = "DTPicker"
        Me.DTPicker.Size = New System.Drawing.Size(248, 20)
        Me.DTPicker.TabIndex = 6
        '
        'Txt_OrdeComp
        '
        Me.Txt_OrdeComp.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_OrdeComp.Enabled = False
        Me.Txt_OrdeComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_OrdeComp.Location = New System.Drawing.Point(150, 13)
        Me.Txt_OrdeComp.MaxLength = 6
        Me.Txt_OrdeComp.Name = "Txt_OrdeComp"
        Me.Txt_OrdeComp.Size = New System.Drawing.Size(110, 22)
        Me.Txt_OrdeComp.TabIndex = 2
        Me.Txt_OrdeComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SirCoDataSet
        '
        Me.SirCoDataSet.DataSetName = "SirCoDataSet"
        Me.SirCoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SirCoDataSet1
        '
        Me.SirCoDataSet1.DataSetName = "SirCoDataSet1"
        Me.SirCoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MotsegpedidoBindingSource
        '
        Me.MotsegpedidoBindingSource.DataMember = "motsegpedido"
        Me.MotsegpedidoBindingSource.DataSource = Me.SirCoDataSet1
        '
        'MotsegpedidoTableAdapter
        '
        Me.MotsegpedidoTableAdapter.ClearBeforeFill = True
        '
        'frmCatalogoSegBit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 403)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoSegBit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Catálogo de Seguimiento a Pedidos"
        Me.Pnl_Botones.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        CType(Me.SirCoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MotsegpedidoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_OrdeComp As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Comentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Realiza As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Atiende As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_Id_SegBit As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_Estilon As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Motivo As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents SirCoDataSet As SirCoDataSet
    Friend WithEvents SirCoDataSet1 As SirCoDataSet1
    Friend WithEvents MotsegpedidoBindingSource As BindingSource
    Friend WithEvents MotsegpedidoTableAdapter As SirCoDataSet1TableAdapters.motsegpedidoTableAdapter
End Class
