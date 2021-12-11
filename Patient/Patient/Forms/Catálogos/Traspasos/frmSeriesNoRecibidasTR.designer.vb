<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeriesNoRecibidasTR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeriesNoRecibidasTR))
        Me.Pnl_Edicion = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.col_idtraspaso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_traspaso = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_idarticulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_marca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_modelo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_corrida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_medida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_serie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_sucurdes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_motivo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.col_observa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pnl_Edicion.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pnl_Botones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl_Edicion
        '
        Me.Pnl_Edicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Edicion.Controls.Add(Me.Label1)
        Me.Pnl_Edicion.Controls.Add(Me.DGrid)
        Me.Pnl_Edicion.Location = New System.Drawing.Point(6, 3)
        Me.Pnl_Edicion.Name = "Pnl_Edicion"
        Me.Pnl_Edicion.Size = New System.Drawing.Size(926, 346)
        Me.Pnl_Edicion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(435, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ingrese el motivo por el cual no recibe estos artículos"
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.AllowUserToResizeColumns = False
        Me.DGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idtraspaso, Me.col_sucursal, Me.col_traspaso, Me.col_idarticulo, Me.col_marca, Me.col_modelo, Me.col_corrida, Me.col_medida, Me.col_serie, Me.col_sucurdes, Me.col_motivo, Me.col_observa})
        Me.DGrid.Location = New System.Drawing.Point(4, 40)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(915, 299)
        Me.DGrid.TabIndex = 2
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(6, 355)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(919, 56)
        Me.Pnl_Botones.TabIndex = 1
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(813, 0)
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
        Me.Btn_Aceptar.Location = New System.Drawing.Point(864, 0)
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
        'col_idtraspaso
        '
        Me.col_idtraspaso.HeaderText = "Idtraspaso"
        Me.col_idtraspaso.Name = "col_idtraspaso"
        Me.col_idtraspaso.ReadOnly = True
        Me.col_idtraspaso.Visible = False
        Me.col_idtraspaso.Width = 15
        '
        'col_sucursal
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_sucursal.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_sucursal.HeaderText = "Sucursal"
        Me.col_sucursal.MaxInputLength = 2
        Me.col_sucursal.Name = "col_sucursal"
        Me.col_sucursal.ReadOnly = True
        Me.col_sucursal.Width = 70
        '
        'col_traspaso
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_traspaso.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_traspaso.HeaderText = "Traspaso"
        Me.col_traspaso.Name = "col_traspaso"
        Me.col_traspaso.ReadOnly = True
        Me.col_traspaso.Width = 80
        '
        'col_idarticulo
        '
        Me.col_idarticulo.HeaderText = "Idart"
        Me.col_idarticulo.Name = "col_idarticulo"
        Me.col_idarticulo.Visible = False
        '
        'col_marca
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_marca.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_marca.HeaderText = "Marca"
        Me.col_marca.Name = "col_marca"
        Me.col_marca.ReadOnly = True
        Me.col_marca.Width = 70
        '
        'col_modelo
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_modelo.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_modelo.HeaderText = "Modelo"
        Me.col_modelo.Name = "col_modelo"
        Me.col_modelo.ReadOnly = True
        Me.col_modelo.Width = 70
        '
        'col_corrida
        '
        Me.col_corrida.HeaderText = "Corrida"
        Me.col_corrida.Name = "col_corrida"
        Me.col_corrida.Visible = False
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
        'col_serie
        '
        Me.col_serie.HeaderText = "Serie"
        Me.col_serie.Name = "col_serie"
        Me.col_serie.ReadOnly = True
        Me.col_serie.Width = 90
        '
        'col_sucurdes
        '
        Me.col_sucurdes.HeaderText = "Destino"
        Me.col_sucurdes.Name = "col_sucurdes"
        Me.col_sucurdes.Visible = False
        '
        'col_motivo
        '
        Me.col_motivo.HeaderText = "Motivo"
        Me.col_motivo.Items.AddRange(New Object() {"AMARILLO", "FALLADO", "CAMBIADO", "NO ENVIADO", "VENDIDO", "MERCANCIA DAÑADA", "CODIGO ILEGIBLE", "CAJA EN MAL ESTADO", "OTRO"})
        Me.col_motivo.Name = "col_motivo"
        Me.col_motivo.Width = 150
        '
        'col_observa
        '
        Me.col_observa.HeaderText = "Observaciones"
        Me.col_observa.Name = "col_observa"
        Me.col_observa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_observa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_observa.Width = 300
        '
        'frmSeriesNoRecibidasTR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 422)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.Pnl_Edicion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeriesNoRecibidasTR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Series No Recibidas"
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
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents col_idtraspaso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_traspaso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_idarticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_corrida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_medida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_sucurdes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_motivo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents col_observa As System.Windows.Forms.DataGridViewTextBoxColumn
    ' Friend WithEvents Tbl_EmpleadoTableAdapter1 As Bitacora.DataSet1TableAdapters.tbl_EmpleadoTableAdapter
End Class
