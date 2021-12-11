<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltrosNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltrosNomina))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Txt_DescriConcepto = New System.Windows.Forms.TextBox
        Me.Txt_IdConcepto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.Cbo_TipoNom = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_IdDepto = New System.Windows.Forms.TextBox
        Me.Txt_ClavePuesto = New System.Windows.Forms.TextBox
        Me.Txt_ClaveDepto = New System.Windows.Forms.TextBox
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Txt_DescripPuesto = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_IdPuesto = New System.Windows.Forms.TextBox
        Me.Txt_DescripDepto = New System.Windows.Forms.TextBox
        Me.Departamento = New System.Windows.Forms.Label
        Me.Txt_IdDepartamento = New System.Windows.Forms.TextBox
        Me.Txt_NombreEmpleado = New System.Windows.Forms.TextBox
        Me.Empleado = New System.Windows.Forms.Label
        Me.Txt_IdEmpleado = New System.Windows.Forms.TextBox
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Limpiar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Pnl_Edicion.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescriConcepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdConcepto)
        Me.Pnl_Edicion.Controls.Add(Me.Label5)
        Me.Pnl_Edicion.Controls.Add(Me.DGrid)
        Me.Pnl_Edicion.Controls.Add(Me.Label4)
        Me.Pnl_Edicion.Controls.Add(Me.Cbo_TipoNom)
        Me.Pnl_Edicion.Controls.Add(Me.Label3)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_ClavePuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_ClaveDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripSucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_Sucursal)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripPuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Label2)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdPuesto)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_DescripDepto)
        Me.Pnl_Edicion.Controls.Add(Me.Departamento)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdDepartamento)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_NombreEmpleado)
        Me.Pnl_Edicion.Controls.Add(Me.Empleado)
        Me.Pnl_Edicion.Controls.Add(Me.Txt_IdEmpleado)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(12, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(528, 278)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Txt_DescriConcepto
        '
        Me.Txt_DescriConcepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescriConcepto.Enabled = False
        Me.Txt_DescriConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescriConcepto.Location = New System.Drawing.Point(186, 254)
        Me.Txt_DescriConcepto.MaxLength = 200
        Me.Txt_DescriConcepto.Name = "Txt_DescriConcepto"
        Me.Txt_DescriConcepto.ReadOnly = True
        Me.Txt_DescriConcepto.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescriConcepto.TabIndex = 123
        '
        'Txt_IdConcepto
        '
        Me.Txt_IdConcepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdConcepto.Location = New System.Drawing.Point(110, 254)
        Me.Txt_IdConcepto.MaxLength = 3
        Me.Txt_IdConcepto.Name = "Txt_IdConcepto"
        Me.Txt_IdConcepto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdConcepto.TabIndex = 121
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Concepto"
        '
        'DGrid
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Location = New System.Drawing.Point(110, 3)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.Size = New System.Drawing.Size(408, 114)
        Me.DGrid.TabIndex = 120
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Tipo Nómina"
        '
        'Cbo_TipoNom
        '
        Me.Cbo_TipoNom.AutoCompleteCustomSource.AddRange(New String() {"FISCAL", "BONO"})
        Me.Cbo_TipoNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_TipoNom.FormattingEnabled = True
        Me.Cbo_TipoNom.Items.AddRange(New Object() {"FISCAL", "BONO"})
        Me.Cbo_TipoNom.Location = New System.Drawing.Point(110, 123)
        Me.Cbo_TipoNom.Name = "Cbo_TipoNom"
        Me.Cbo_TipoNom.Size = New System.Drawing.Size(121, 21)
        Me.Cbo_TipoNom.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Periodo Nómina"
        '
        'Txt_IdDepto
        '
        Me.Txt_IdDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepto.Location = New System.Drawing.Point(335, 124)
        Me.Txt_IdDepto.MaxLength = 50
        Me.Txt_IdDepto.Name = "Txt_IdDepto"
        Me.Txt_IdDepto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdDepto.TabIndex = 115
        Me.Txt_IdDepto.Visible = False
        '
        'Txt_ClavePuesto
        '
        Me.Txt_ClavePuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClavePuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClavePuesto.Location = New System.Drawing.Point(110, 228)
        Me.Txt_ClavePuesto.MaxLength = 3
        Me.Txt_ClavePuesto.Name = "Txt_ClavePuesto"
        Me.Txt_ClavePuesto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_ClavePuesto.TabIndex = 8
        '
        'Txt_ClaveDepto
        '
        Me.Txt_ClaveDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_ClaveDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ClaveDepto.Location = New System.Drawing.Point(110, 202)
        Me.Txt_ClaveDepto.MaxLength = 3
        Me.Txt_ClaveDepto.Name = "Txt_ClaveDepto"
        Me.Txt_ClaveDepto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_ClaveDepto.TabIndex = 6
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(186, 176)
        Me.Txt_DescripSucursal.MaxLength = 200
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripSucursal.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Sucursal"
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(110, 176)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(70, 20)
        Me.Txt_Sucursal.TabIndex = 4
        '
        'Txt_DescripPuesto
        '
        Me.Txt_DescripPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripPuesto.Enabled = False
        Me.Txt_DescripPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripPuesto.Location = New System.Drawing.Point(186, 228)
        Me.Txt_DescripPuesto.MaxLength = 200
        Me.Txt_DescripPuesto.Name = "Txt_DescripPuesto"
        Me.Txt_DescripPuesto.ReadOnly = True
        Me.Txt_DescripPuesto.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripPuesto.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 231)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Puesto"
        '
        'Txt_IdPuesto
        '
        Me.Txt_IdPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdPuesto.Location = New System.Drawing.Point(446, 129)
        Me.Txt_IdPuesto.MaxLength = 50
        Me.Txt_IdPuesto.Name = "Txt_IdPuesto"
        Me.Txt_IdPuesto.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdPuesto.TabIndex = 102
        Me.Txt_IdPuesto.Visible = False
        '
        'Txt_DescripDepto
        '
        Me.Txt_DescripDepto.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDepto.Enabled = False
        Me.Txt_DescripDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDepto.Location = New System.Drawing.Point(186, 202)
        Me.Txt_DescripDepto.MaxLength = 200
        Me.Txt_DescripDepto.Name = "Txt_DescripDepto"
        Me.Txt_DescripDepto.ReadOnly = True
        Me.Txt_DescripDepto.Size = New System.Drawing.Size(330, 20)
        Me.Txt_DescripDepto.TabIndex = 7
        '
        'Departamento
        '
        Me.Departamento.AutoSize = True
        Me.Departamento.Location = New System.Drawing.Point(13, 205)
        Me.Departamento.Name = "Departamento"
        Me.Departamento.Size = New System.Drawing.Size(74, 13)
        Me.Departamento.TabIndex = 100
        Me.Departamento.Text = "Departamento"
        '
        'Txt_IdDepartamento
        '
        Me.Txt_IdDepartamento.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdDepartamento.Location = New System.Drawing.Point(448, 103)
        Me.Txt_IdDepartamento.MaxLength = 50
        Me.Txt_IdDepartamento.Name = "Txt_IdDepartamento"
        Me.Txt_IdDepartamento.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdDepartamento.TabIndex = 99
        Me.Txt_IdDepartamento.Visible = False
        '
        'Txt_NombreEmpleado
        '
        Me.Txt_NombreEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_NombreEmpleado.Enabled = False
        Me.Txt_NombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreEmpleado.Location = New System.Drawing.Point(186, 150)
        Me.Txt_NombreEmpleado.MaxLength = 200
        Me.Txt_NombreEmpleado.Name = "Txt_NombreEmpleado"
        Me.Txt_NombreEmpleado.ReadOnly = True
        Me.Txt_NombreEmpleado.Size = New System.Drawing.Size(330, 20)
        Me.Txt_NombreEmpleado.TabIndex = 3
        '
        'Empleado
        '
        Me.Empleado.AutoSize = True
        Me.Empleado.Location = New System.Drawing.Point(13, 153)
        Me.Empleado.Name = "Empleado"
        Me.Empleado.Size = New System.Drawing.Size(54, 13)
        Me.Empleado.TabIndex = 97
        Me.Empleado.Text = "Empleado"
        '
        'Txt_IdEmpleado
        '
        Me.Txt_IdEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_IdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdEmpleado.Location = New System.Drawing.Point(110, 150)
        Me.Txt_IdEmpleado.MaxLength = 5
        Me.Txt_IdEmpleado.Name = "Txt_IdEmpleado"
        Me.Txt_IdEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.Txt_IdEmpleado.TabIndex = 2
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Limpiar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 287)
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
        Me.Btn_Limpiar.TabIndex = 10
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
        Me.Btn_Cancelar.TabIndex = 11
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
        Me.Btn_Aceptar.TabIndex = 12
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        '
        'frmFiltrosNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 354)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltrosNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Filtros Nómina"
        Me.Pnl_Edicion.ResumeLayout(False)
        Me.Pnl_Edicion.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Btn_Limpiar As System.Windows.Forms.Button
    Friend WithEvents Txt_NombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Empleado As System.Windows.Forms.Label
    Friend WithEvents Txt_IdEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdPuesto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripDepto As System.Windows.Forms.TextBox
    Friend WithEvents Departamento As System.Windows.Forms.Label
    Friend WithEvents Txt_IdDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ClavePuesto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ClaveDepto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_IdDepto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cbo_TipoNom As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Txt_IdConcepto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_DescriConcepto As System.Windows.Forms.TextBox
End Class
