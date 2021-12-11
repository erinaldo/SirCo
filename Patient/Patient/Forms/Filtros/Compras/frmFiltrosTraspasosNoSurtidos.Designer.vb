<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosTraspasosNoSurtidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosTraspasosNoSurtidos))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_Trasp2 = New System.Windows.Forms.TextBox
        Me.lbl_Al = New System.Windows.Forms.Label
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.lbl_Sucursal = New System.Windows.Forms.Label
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Txt_NumSerie = New System.Windows.Forms.TextBox
        Me.lbl_NumSerie = New System.Windows.Forms.Label
        Me.lbl_Traspasos = New System.Windows.Forms.Label
        Me.Txt_Trasp1 = New System.Windows.Forms.TextBox
        Me.Chk_Fechas = New System.Windows.Forms.CheckBox
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
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Trasp2)
        Me.Pnl_Edicion.Controls.Add(Me.lbl_Al)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.lbl_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NumSerie)
        Me.Pnl_Edicion.Controls.Add(Me.lbl_NumSerie)
        Me.Pnl_Edicion.Controls.Add(Me.lbl_Traspasos)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Trasp1)
        Me.Pnl_Edicion.Controls.Add(Me.Chk_Fechas)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker3)
        Me.Pnl_Edicion.Controls.Add(Me.DTPicker2)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 128)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_Trasp2
        '
        Me.Txt_Trasp2.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Trasp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Trasp2.Location = New System.Drawing.Point(201, 65)
        Me.Txt_Trasp2.MaxLength = 6
        Me.Txt_Trasp2.Name = "Txt_Trasp2"
        Me.Txt_Trasp2.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Trasp2.TabIndex = 4
        '
        'lbl_Al
        '
        Me.lbl_Al.AutoSize = True
        Me.lbl_Al.Location = New System.Drawing.Point(181, 68)
        Me.lbl_Al.Name = "lbl_Al"
        Me.lbl_Al.Size = New System.Drawing.Size(18, 13)
        Me.lbl_Al.TabIndex = 121
        Me.lbl_Al.Text = "al:"
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(201, 39)
        Me.Txt_DescripSucursal.MaxLength = 200
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(314, 20)
        Me.Txt_DescripSucursal.TabIndex = 119
        '
        'lbl_Sucursal
        '
        Me.lbl_Sucursal.AutoSize = True
        Me.lbl_Sucursal.Location = New System.Drawing.Point(13, 42)
        Me.lbl_Sucursal.Name = "lbl_Sucursal"
        Me.lbl_Sucursal.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Sucursal.TabIndex = 120
        Me.lbl_Sucursal.Text = "Sucursal"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(110, 39)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Sucursal.TabIndex = 2
        '
        'Txt_NumSerie
        '
        Me.Txt_NumSerie.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NumSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NumSerie.Location = New System.Drawing.Point(110, 91)
        Me.Txt_NumSerie.MaxLength = 13
        Me.Txt_NumSerie.Name = "Txt_NumSerie"
        Me.Txt_NumSerie.Size = New System.Drawing.Size(161, 20)
        Me.Txt_NumSerie.TabIndex = 5
        '
        'lbl_NumSerie
        '
        Me.lbl_NumSerie.AutoSize = True
        Me.lbl_NumSerie.Location = New System.Drawing.Point(14, 94)
        Me.lbl_NumSerie.Name = "lbl_NumSerie"
        Me.lbl_NumSerie.Size = New System.Drawing.Size(86, 13)
        Me.lbl_NumSerie.TabIndex = 100
        Me.lbl_NumSerie.Text = "Número de Serie"
        '
        'lbl_Traspasos
        '
        Me.lbl_Traspasos.AutoSize = True
        Me.lbl_Traspasos.Location = New System.Drawing.Point(13, 68)
        Me.lbl_Traspasos.Name = "lbl_Traspasos"
        Me.lbl_Traspasos.Size = New System.Drawing.Size(54, 13)
        Me.lbl_Traspasos.TabIndex = 97
        Me.lbl_Traspasos.Text = "Folios del:"
        '
        'Txt_Trasp1
        '
        Me.Txt_Trasp1.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Trasp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Trasp1.Location = New System.Drawing.Point(110, 65)
        Me.Txt_Trasp1.MaxLength = 6
        Me.Txt_Trasp1.Name = "Txt_Trasp1"
        Me.Txt_Trasp1.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Trasp1.TabIndex = 3
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
        Me.DTPicker3.TabIndex = 1
        '
        'DTPicker2
        '
        Me.DTPicker2.Enabled = False
        Me.DTPicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPicker2.Location = New System.Drawing.Point(111, 3)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(200, 20)
        Me.DTPicker2.TabIndex = 0
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 142)
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
        'frmFiltrosTraspasosNoSurtidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 207)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosTraspasosNoSurtidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Traspasos No Surtidos"
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
    Friend WithEvents Chk_Fechas As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Traspasos As System.Windows.Forms.Label
    Friend WithEvents Txt_Trasp1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_NumSerie As System.Windows.Forms.Label
    Friend WithEvents Txt_NumSerie As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Sucursal As System.Windows.Forms.Label
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Al As System.Windows.Forms.Label
    Friend WithEvents Txt_Trasp2 As System.Windows.Forms.TextBox
End Class
