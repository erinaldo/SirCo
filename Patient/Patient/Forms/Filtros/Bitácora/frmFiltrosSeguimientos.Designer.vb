<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosSeguimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosSeguimientos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Chk_FechaOrden = New System.Windows.Forms.CheckBox
        Me.Label = New System.Windows.Forms.Label
        Me.Txt_OrdeComp2 = New System.Windows.Forms.TextBox
        Me.Txt_OrdeComp1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.DTPicker3 = New System.Windows.Forms.DateTimePicker
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
        Me.Txt_Raz_Soc = New System.Windows.Forms.TextBox
        Me.Txt_DescripMarca = New System.Windows.Forms.TextBox
        Me.Txt_Proveedor = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Estilof = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Estilon = New System.Windows.Forms.TextBox
        Me.Txt_Marca = New System.Windows.Forms.TextBox
        Me.Lbl_Marca = New System.Windows.Forms.Label
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        'Me.Tbl_asistencia_diariaTableAdapter1 = New Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        'Me.Tbl_EmpleadoTableAdapter1 = New Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
        Me.Pnl_Edicion.SuspendLayout()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Chk_FechaOrden)
        Me.Pnl_Edicion.Controls.Add(Me.Label)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_OrdeComp2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_OrdeComp1)
        Me.Pnl_Edicion.Controls.Add(Me.Label12)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label11)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker3)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Raz_Soc)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripMarca)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Proveedor)
        Me.Pnl_Edicion.Controls.Add(Me.Label6)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Estilof)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Estilon)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Marca)
        Me.Pnl_Edicion.Controls.Add(Me.Lbl_Marca)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 163)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Chk_FechaOrden
        '
        Me.Chk_FechaOrden.AutoSize = True
        Me.Chk_FechaOrden.Location = New System.Drawing.Point(17, 3)
        Me.Chk_FechaOrden.Name = "Chk_FechaOrden"
        Me.Chk_FechaOrden.Size = New System.Drawing.Size(81, 17)
        Me.Chk_FechaOrden.TabIndex = 0
        Me.Chk_FechaOrden.Text = "Fecha Seg."
        Me.Chk_FechaOrden.UseVisualStyleBackColor = True
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(234, 32)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(25, 13)
        Me.Label.TabIndex = 46
        Me.Label.Text = "A la"
        '
        'Txt_OrdeComp2
        '
        Me.Txt_OrdeComp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_OrdeComp2.Location = New System.Drawing.Point(277, 29)
        Me.Txt_OrdeComp2.MaxLength = 6
        Me.Txt_OrdeComp2.Name = "Txt_OrdeComp2"
        Me.Txt_OrdeComp2.Size = New System.Drawing.Size(100, 20)
        Me.Txt_OrdeComp2.TabIndex = 7
        '
        'Txt_OrdeComp1
        '
        Me.Txt_OrdeComp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_OrdeComp1.Location = New System.Drawing.Point(111, 29)
        Me.Txt_OrdeComp1.MaxLength = 6
        Me.Txt_OrdeComp1.Name = "Txt_OrdeComp1"
        Me.Txt_OrdeComp1.Size = New System.Drawing.Size(100, 20)
        Me.Txt_OrdeComp1.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Orden Compra"
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(159, 55)
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(151, 20)
        Me.Txt_DescripSucursal.TabIndex = 9
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(111, 55)
        Me.Txt_Sucursal.MaxLength = 3
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Sucursal.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Sucursal"
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
        'Txt_Raz_Soc
        '
        Me.Txt_Raz_Soc.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Raz_Soc.Enabled = False
        Me.Txt_Raz_Soc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Raz_Soc.Location = New System.Drawing.Point(159, 133)
        Me.Txt_Raz_Soc.Name = "Txt_Raz_Soc"
        Me.Txt_Raz_Soc.ReadOnly = True
        Me.Txt_Raz_Soc.Size = New System.Drawing.Size(282, 20)
        Me.Txt_Raz_Soc.TabIndex = 20
        '
        'Txt_DescripMarca
        '
        Me.Txt_DescripMarca.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripMarca.Enabled = False
        Me.Txt_DescripMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripMarca.Location = New System.Drawing.Point(277, 81)
        Me.Txt_DescripMarca.Name = "Txt_DescripMarca"
        Me.Txt_DescripMarca.ReadOnly = True
        Me.Txt_DescripMarca.Size = New System.Drawing.Size(164, 20)
        Me.Txt_DescripMarca.TabIndex = 13
        '
        'Txt_Proveedor
        '
        Me.Txt_Proveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Proveedor.Location = New System.Drawing.Point(111, 133)
        Me.Txt_Proveedor.MaxLength = 3
        Me.Txt_Proveedor.Name = "Txt_Proveedor"
        Me.Txt_Proveedor.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Proveedor.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Estilo Fábrica"
        '
        'Txt_Estilof
        '
        Me.Txt_Estilof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilof.Location = New System.Drawing.Point(111, 107)
        Me.Txt_Estilof.MaxLength = 14
        Me.Txt_Estilof.Name = "Txt_Estilof"
        Me.Txt_Estilof.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Estilof.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Estilo Nuestro"
        '
        'Txt_Estilon
        '
        Me.Txt_Estilon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Estilon.Location = New System.Drawing.Point(159, 81)
        Me.Txt_Estilon.MaxLength = 7
        Me.Txt_Estilon.Name = "Txt_Estilon"
        Me.Txt_Estilon.Size = New System.Drawing.Size(69, 20)
        Me.Txt_Estilon.TabIndex = 12
        '
        'Txt_Marca
        '
        Me.Txt_Marca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Marca.Location = New System.Drawing.Point(111, 81)
        Me.Txt_Marca.MaxLength = 3
        Me.Txt_Marca.Name = "Txt_Marca"
        Me.Txt_Marca.Size = New System.Drawing.Size(42, 20)
        Me.Txt_Marca.TabIndex = 11
        '
        'Lbl_Marca
        '
        Me.Lbl_Marca.AutoSize = True
        Me.Lbl_Marca.Location = New System.Drawing.Point(234, 81)
        Me.Lbl_Marca.Name = "Lbl_Marca"
        Me.Lbl_Marca.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Marca.TabIndex = 0
        Me.Lbl_Marca.Text = "Marca"
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 172)
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
        Me.Btn_Limpiar.TabIndex = 25
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
        Me.Btn_Cancelar.TabIndex = 27
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
        Me.Btn_Aceptar.TabIndex = 26
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Tbl_asistencia_diariaTableAdapter1
        '
        ' Me.Tbl_asistencia_diariaTableAdapter1.ClearBeforeFill = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'Tbl_EmpleadoTableAdapter1
        '
        ' Me.Tbl_EmpleadoTableAdapter1.ClearBeforeFill = True
        '
        'frmFiltrosSeguimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 233)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosSeguimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Seguimiento"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        Me.Pnl_Botones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pnl_Edicion As System.Windows.Forms.Panel
    Friend WithEvents Txt_Marca As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Marca As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Estilon As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Estilof As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripMarca As System.Windows.Forms.TextBox
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    ' Friend WithEvents Tbl_asistencia_diariaTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_asistencia_diariaTableAdapter
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    'Friend WithEvents Tbl_EmpleadoTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DTPicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents Txt_OrdeComp2 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_OrdeComp1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Chk_FechaOrden As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Raz_Soc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Proveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
