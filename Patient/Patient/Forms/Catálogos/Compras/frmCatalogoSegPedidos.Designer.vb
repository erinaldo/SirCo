<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalogoSegPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatalogoSegPedidos))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Txt_DescripM1 = New System.Windows.Forms.TextBox()
        Me.Txt_IdMov1 = New System.Windows.Forms.TextBox()
        Me.Lbl_M1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cbo_Motivo = New System.Windows.Forms.ComboBox()
        Me.MotsegpedidoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SirCoDataSet = New SIRCO.SirCoDataSet()
        Me.Lbl_CodigoBarras = New System.Windows.Forms.Label()
        Me.Txt_IdFolioSuc = New System.Windows.Forms.TextBox()
        Me.Txt_Atiende = New System.Windows.Forms.TextBox()
        Me.Lbl_M2 = New System.Windows.Forms.Label()
        Me.DT_FechaTrasp = New System.Windows.Forms.DateTimePicker()
        Me.Lbl_Fecha = New System.Windows.Forms.Label()
        Me.Txt_Observaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MotsegpedidoTableAdapter = New SIRCO.SirCoDataSetTableAdapters.motsegpedidoTableAdapter()
        Me.Pnl_Botones.SuspendLayout()
        Me.Pnl_Edicion.SuspendLayout()
        CType(Me.MotsegpedidoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SirCoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pnl_Botones.Location = New System.Drawing.Point(0, 284)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(657, 56)
        Me.Pnl_Botones.TabIndex = 3
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(551, 0)
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
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.Btn_Cancelar.Location = New System.Drawing.Point(602, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 52)
        Me.Btn_Cancelar.TabIndex = 2
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripM1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdMov1)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_M1)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_Motivo)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_CodigoBarras)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdFolioSuc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Atiende)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_M2)
        Me.Pnl_Edicion.Controls.Add(Me.DT_FechaTrasp)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Fecha)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Observaciones)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 5)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(640, 275)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_DescripM1
        '
        Me.Txt_DescripM1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_DescripM1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripM1.Enabled = False
        Me.Txt_DescripM1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripM1.Location = New System.Drawing.Point(139, 170)
        Me.Txt_DescripM1.Name = "Txt_DescripM1"
        Me.Txt_DescripM1.ReadOnly = True
        Me.Txt_DescripM1.Size = New System.Drawing.Size(291, 20)
        Me.Txt_DescripM1.TabIndex = 146
        '
        'Txt_IdMov1
        '
        Me.Txt_IdMov1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_IdMov1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdMov1.Location = New System.Drawing.Point(88, 170)
        Me.Txt_IdMov1.MaxLength = 4
        Me.Txt_IdMov1.Name = "Txt_IdMov1"
        Me.Txt_IdMov1.Size = New System.Drawing.Size(45, 20)
        Me.Txt_IdMov1.TabIndex = 147
        Me.Txt_IdMov1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_M1
        '
        Me.Lbl_M1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_M1.AutoSize = True
        Me.Lbl_M1.Location = New System.Drawing.Point(8, 173)
        Me.Lbl_M1.Name = "Lbl_M1"
        Me.Lbl_M1.Size = New System.Drawing.Size(42, 13)
        Me.Lbl_M1.TabIndex = 148
        Me.Lbl_M1.Text = "Realiza"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Motivo"
        '
        'Cbo_Motivo
        '
        Me.Cbo_Motivo.DataSource = Me.MotsegpedidoBindingSource
        Me.Cbo_Motivo.DisplayMember = "motivo"
        Me.Cbo_Motivo.FormattingEnabled = True
        Me.Cbo_Motivo.Location = New System.Drawing.Point(89, 45)
        Me.Cbo_Motivo.Name = "Cbo_Motivo"
        Me.Cbo_Motivo.Size = New System.Drawing.Size(313, 21)
        Me.Cbo_Motivo.TabIndex = 144
        Me.Cbo_Motivo.ValueMember = "idmotivo"
        '
        'MotsegpedidoBindingSource
        '
        Me.MotsegpedidoBindingSource.DataMember = "motsegpedido"
        Me.MotsegpedidoBindingSource.DataSource = Me.SirCoDataSet
        '
        'SirCoDataSet
        '
        Me.SirCoDataSet.DataSetName = "SirCoDataSet"
        Me.SirCoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Lbl_CodigoBarras
        '
        Me.Lbl_CodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_CodigoBarras.AutoSize = True
        Me.Lbl_CodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CodigoBarras.Location = New System.Drawing.Point(9, 9)
        Me.Lbl_CodigoBarras.Name = "Lbl_CodigoBarras"
        Me.Lbl_CodigoBarras.Size = New System.Drawing.Size(82, 16)
        Me.Lbl_CodigoBarras.TabIndex = 143
        Me.Lbl_CodigoBarras.Text = "OrdeComp"
        '
        'Txt_IdFolioSuc
        '
        Me.Txt_IdFolioSuc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_IdFolioSuc.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_IdFolioSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Txt_IdFolioSuc.Location = New System.Drawing.Point(88, 7)
        Me.Txt_IdFolioSuc.MaxLength = 8
        Me.Txt_IdFolioSuc.Name = "Txt_IdFolioSuc"
        Me.Txt_IdFolioSuc.Size = New System.Drawing.Size(177, 26)
        Me.Txt_IdFolioSuc.TabIndex = 0
        Me.Txt_IdFolioSuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Atiende
        '
        Me.Txt_Atiende.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Atiende.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Atiende.Enabled = False
        Me.Txt_Atiende.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Atiende.Location = New System.Drawing.Point(88, 76)
        Me.Txt_Atiende.Name = "Txt_Atiende"
        Me.Txt_Atiende.ReadOnly = True
        Me.Txt_Atiende.Size = New System.Drawing.Size(314, 20)
        Me.Txt_Atiende.TabIndex = 13
        '
        'Lbl_M2
        '
        Me.Lbl_M2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_M2.AutoSize = True
        Me.Lbl_M2.Location = New System.Drawing.Point(8, 79)
        Me.Lbl_M2.Name = "Lbl_M2"
        Me.Lbl_M2.Size = New System.Drawing.Size(43, 13)
        Me.Lbl_M2.TabIndex = 136
        Me.Lbl_M2.Text = "Atiende"
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
        Me.Lbl_Fecha.Location = New System.Drawing.Point(338, 19)
        Me.Lbl_Fecha.Name = "Lbl_Fecha"
        Me.Lbl_Fecha.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Fecha.TabIndex = 118
        Me.Lbl_Fecha.Text = "Fecha"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Observaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Observaciones.Location = New System.Drawing.Point(89, 107)
        Me.Txt_Observaciones.MaxLength = 700
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.Size = New System.Drawing.Size(537, 57)
        Me.Txt_Observaciones.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Observaciones"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(102, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 102
        Me.Label5.Visible = False
        '
        'MotsegpedidoTableAdapter
        '
        Me.MotsegpedidoTableAdapter.ClearBeforeFill = True
        '
        'frmCatalogoSegPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 340)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCatalogoSegPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seguimiento a Pedidos"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        CType(Me.MotsegpedidoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SirCoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Atiende As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_M2 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdFolioSuc As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_CodigoBarras As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripM1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdMov1 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_M1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Motivo As System.Windows.Forms.ComboBox
    Friend WithEvents SirCoDataSet As SIRCO.SirCoDataSet
    Friend WithEvents MotsegpedidoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MotsegpedidoTableAdapter As SIRCO.SirCoDataSetTableAdapters.motsegpedidoTableAdapter
End Class
