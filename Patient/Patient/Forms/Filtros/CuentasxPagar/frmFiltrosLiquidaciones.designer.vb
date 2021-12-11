<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosLiquidaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosLiquidaciones))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_Tipo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chk_Pagados = New System.Windows.Forms.CheckBox()
        Me.Chk_Cancelados = New System.Windows.Forms.CheckBox()
        Me.Chk_Generados = New System.Windows.Forms.CheckBox()
        Me.Chk_Revisados = New System.Windows.Forms.CheckBox()
        Me.Chk_Fechas = New System.Windows.Forms.CheckBox()
        Me.DTPicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Pnl_Botones = New System.Windows.Forms.Panel()
        Me.Btn_Limpiar = New System.Windows.Forms.Button()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Edicion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.CB_Tipo)
        Me.Pnl_Edicion.Controls.Add(Me.GroupBox1)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_Fechas)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker3)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker2)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 131)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Tipo"
        '
        'CB_Tipo
        '
        Me.CB_Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Tipo.FormattingEnabled = True
        Me.CB_Tipo.Items.AddRange(New Object() {"FACTURA/CONSIGNACIÓN", "FACTURA", "CONSIGNACIÓN", "TRANSFERENCIA"})
        Me.CB_Tipo.Location = New System.Drawing.Point(111, 88)
        Me.CB_Tipo.Name = "CB_Tipo"
        Me.CB_Tipo.Size = New System.Drawing.Size(200, 21)
        Me.CB_Tipo.TabIndex = 11
        Me.CB_Tipo.Text = "FACTURA/CONSIGNACIÓN"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Chk_Pagados)
        Me.GroupBox1.Controls.Add(Me.Chk_Cancelados)
        Me.GroupBox1.Controls.Add(Me.Chk_Generados)
        Me.GroupBox1.Controls.Add(Me.Chk_Revisados)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 50)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Liquidaciones"
        '
        'Chk_Pagados
        '
        Me.Chk_Pagados.AutoSize = True
        Me.Chk_Pagados.Location = New System.Drawing.Point(6, 19)
        Me.Chk_Pagados.Name = "Chk_Pagados"
        Me.Chk_Pagados.Size = New System.Drawing.Size(68, 17)
        Me.Chk_Pagados.TabIndex = 6
        Me.Chk_Pagados.Text = "Pagadas"
        Me.Chk_Pagados.UseVisualStyleBackColor = True
        '
        'Chk_Cancelados
        '
        Me.Chk_Cancelados.AutoSize = True
        Me.Chk_Cancelados.Location = New System.Drawing.Point(405, 19)
        Me.Chk_Cancelados.Name = "Chk_Cancelados"
        Me.Chk_Cancelados.Size = New System.Drawing.Size(82, 17)
        Me.Chk_Cancelados.TabIndex = 9
        Me.Chk_Cancelados.Text = "Canceladas"
        Me.Chk_Cancelados.UseVisualStyleBackColor = True
        '
        'Chk_Generados
        '
        Me.Chk_Generados.AutoSize = True
        Me.Chk_Generados.Location = New System.Drawing.Point(126, 19)
        Me.Chk_Generados.Name = "Chk_Generados"
        Me.Chk_Generados.Size = New System.Drawing.Size(78, 17)
        Me.Chk_Generados.TabIndex = 7
        Me.Chk_Generados.Text = "Generadas"
        Me.Chk_Generados.UseVisualStyleBackColor = True
        '
        'Chk_Revisados
        '
        Me.Chk_Revisados.AutoSize = True
        Me.Chk_Revisados.Location = New System.Drawing.Point(273, 19)
        Me.Chk_Revisados.Name = "Chk_Revisados"
        Me.Chk_Revisados.Size = New System.Drawing.Size(76, 17)
        Me.Chk_Revisados.TabIndex = 8
        Me.Chk_Revisados.Text = "Revisadas"
        Me.Chk_Revisados.UseVisualStyleBackColor = True
        '
        'Chk_Fechas
        '
        Me.Chk_Fechas.AutoSize = True
        Me.Chk_Fechas.Location = New System.Drawing.Point(17, 6)
        Me.Chk_Fechas.Name = "Chk_Fechas"
        Me.Chk_Fechas.Size = New System.Drawing.Size(61, 17)
        Me.Chk_Fechas.TabIndex = 0
        Me.Chk_Fechas.Text = "Fechas"
        Me.Chk_Fechas.UseVisualStyleBackColor = True
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
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 140)
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
        'frmFiltrosLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 211)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosLiquidaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Liquidación"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Chk_Fechas As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Pagados As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Chk_Cancelados As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Revisados As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Generados As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CB_Tipo As System.Windows.Forms.ComboBox
End Class
