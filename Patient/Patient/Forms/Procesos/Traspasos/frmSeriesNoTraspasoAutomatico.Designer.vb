<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeriesNoTraspasoAutomatico
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Pnl_Botones = New System.Windows.Forms.Panel
        Me.Txt_Serie = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Aceptar = New System.Windows.Forms.Button
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Medida = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Observacion = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Sucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGrid2 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_IdTraspAut = New System.Windows.Forms.TextBox
        Me.Lbl_CodigoBarras = New System.Windows.Forms.Label
        Me.Txt_DescripDestino = New System.Windows.Forms.TextBox
        Me.Txt_DescripSucursal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Destino = New System.Windows.Forms.TextBox
        Me.Txt_Sucursal = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Pnl_Botones.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Botones
        '
        Me.Pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Botones.Controls.Add(Me.Txt_Serie)
        Me.Pnl_Botones.Controls.Add(Me.Label7)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Cancelar)
        Me.Pnl_Botones.Controls.Add(Me.Btn_Aceptar)
        Me.Pnl_Botones.Location = New System.Drawing.Point(12, 325)
        Me.Pnl_Botones.Name = "Pnl_Botones"
        Me.Pnl_Botones.Size = New System.Drawing.Size(754, 59)
        Me.Pnl_Botones.TabIndex = 0
        '
        'Txt_Serie
        '
        Me.Txt_Serie.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Serie.BackColor = System.Drawing.Color.PowderBlue
        Me.Txt_Serie.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Serie.Location = New System.Drawing.Point(79, 3)
        Me.Txt_Serie.MaxLength = 13
        Me.Txt_Serie.Name = "Txt_Serie"
        Me.Txt_Serie.Size = New System.Drawing.Size(174, 29)
        Me.Txt_Serie.TabIndex = 1
        Me.Txt_Serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(24, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 18)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "Serie"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Cancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.dialog_close
        Me.Btn_Cancelar.Location = New System.Drawing.Point(648, 0)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(51, 55)
        Me.Btn_Cancelar.TabIndex = 1
        Me.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Aceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.Btn_Aceptar.Location = New System.Drawing.Point(699, 0)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(51, 55)
        Me.Btn_Aceptar.TabIndex = 2
        Me.Btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'DGrid
        '
        Me.DGrid.AllowUserToResizeColumns = False
        Me.DGrid.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Serie, Me.Marca, Me.Modelo, Me.Medida, Me.Observacion, Me.Sucursal})
        Me.DGrid.Location = New System.Drawing.Point(12, 390)
        Me.DGrid.Name = "DGrid"
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(754, 167)
        Me.DGrid.TabIndex = 4
        '
        'Serie
        '
        Me.Serie.HeaderText = "Serie"
        Me.Serie.Name = "Serie"
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.Width = 80
        '
        'Modelo
        '
        Me.Modelo.HeaderText = "Modelo"
        Me.Modelo.Name = "Modelo"
        '
        'Medida
        '
        Me.Medida.HeaderText = "Medida"
        Me.Medida.Name = "Medida"
        Me.Medida.Width = 60
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observación"
        Me.Observacion.Items.AddRange(New Object() {"AMARILLO", "CAMBIADO", "FALLADO", "NO SE ENCUENTRA FISICAMENTE", "PROMESA DE VENTA", "EN TRASPASO", "CAJA SOLA", "PIE SOLO", "CAJA CALZADO"})
        Me.Observacion.Name = "Observacion"
        Me.Observacion.Width = 250
        '
        'Sucursal
        '
        Me.Sucursal.HeaderText = "Sucursal"
        Me.Sucursal.Name = "Sucursal"
        Me.Sucursal.Visible = False
        '
        'DGrid2
        '
        Me.DGrid2.AllowUserToResizeColumns = False
        Me.DGrid2.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid2.Location = New System.Drawing.Point(10, 133)
        Me.DGrid2.Name = "DGrid2"
        Me.DGrid2.RowHeadersVisible = False
        Me.DGrid2.Size = New System.Drawing.Size(754, 159)
        Me.DGrid2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Diferencias"
        '
        'Txt_IdTraspAut
        '
        Me.Txt_IdTraspAut.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_IdTraspAut.BackColor = System.Drawing.Color.MistyRose
        Me.Txt_IdTraspAut.Enabled = False
        Me.Txt_IdTraspAut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IdTraspAut.Location = New System.Drawing.Point(93, 6)
        Me.Txt_IdTraspAut.MaxLength = 8
        Me.Txt_IdTraspAut.Name = "Txt_IdTraspAut"
        Me.Txt_IdTraspAut.Size = New System.Drawing.Size(177, 26)
        Me.Txt_IdTraspAut.TabIndex = 144
        Me.Txt_IdTraspAut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbl_CodigoBarras
        '
        Me.Lbl_CodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Lbl_CodigoBarras.AutoSize = True
        Me.Lbl_CodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CodigoBarras.Location = New System.Drawing.Point(14, 8)
        Me.Lbl_CodigoBarras.Name = "Lbl_CodigoBarras"
        Me.Lbl_CodigoBarras.Size = New System.Drawing.Size(48, 20)
        Me.Lbl_CodigoBarras.TabIndex = 145
        Me.Lbl_CodigoBarras.Text = "Folio"
        '
        'Txt_DescripDestino
        '
        Me.Txt_DescripDestino.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_DescripDestino.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripDestino.Enabled = False
        Me.Txt_DescripDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripDestino.Location = New System.Drawing.Point(142, 64)
        Me.Txt_DescripDestino.Name = "Txt_DescripDestino"
        Me.Txt_DescripDestino.ReadOnly = True
        Me.Txt_DescripDestino.Size = New System.Drawing.Size(291, 20)
        Me.Txt_DescripDestino.TabIndex = 149
        '
        'Txt_DescripSucursal
        '
        Me.Txt_DescripSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_DescripSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_DescripSucursal.Enabled = False
        Me.Txt_DescripSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DescripSucursal.Location = New System.Drawing.Point(142, 38)
        Me.Txt_DescripSucursal.Name = "Txt_DescripSucursal"
        Me.Txt_DescripSucursal.ReadOnly = True
        Me.Txt_DescripSucursal.Size = New System.Drawing.Size(291, 20)
        Me.Txt_DescripSucursal.TabIndex = 147
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Destino"
        '
        'Txt_Destino
        '
        Me.Txt_Destino.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Destino.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Destino.Enabled = False
        Me.Txt_Destino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Destino.Location = New System.Drawing.Point(91, 64)
        Me.Txt_Destino.MaxLength = 2
        Me.Txt_Destino.Name = "Txt_Destino"
        Me.Txt_Destino.Size = New System.Drawing.Size(45, 20)
        Me.Txt_Destino.TabIndex = 148
        Me.Txt_Destino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txt_Sucursal
        '
        Me.Txt_Sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Txt_Sucursal.Enabled = False
        Me.Txt_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Sucursal.Location = New System.Drawing.Point(91, 38)
        Me.Txt_Sucursal.MaxLength = 2
        Me.Txt_Sucursal.Name = "Txt_Sucursal"
        Me.Txt_Sucursal.Size = New System.Drawing.Size(45, 20)
        Me.Txt_Sucursal.TabIndex = 146
        Me.Txt_Sucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 150
        Me.Label16.Text = "Sucursal"
        '
        'frmSeriesNoTraspasoAutomatico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 563)
        Me.Controls.Add(Me.Txt_DescripDestino)
        Me.Controls.Add(Me.Txt_DescripSucursal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_Destino)
        Me.Controls.Add(Me.Txt_Sucursal)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Txt_IdTraspAut)
        Me.Controls.Add(Me.Lbl_CodigoBarras)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGrid2)
        Me.Controls.Add(Me.Pnl_Botones)
        Me.Controls.Add(Me.DGrid)
        Me.MaximizeBox = False
        Me.Name = "frmSeriesNoTraspasoAutomatico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Series No Traspaso"
        Me.Pnl_Botones.ResumeLayout(False)
        Me.Pnl_Botones.PerformLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modelo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Sucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Txt_Serie As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGrid2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_IdTraspAut As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_CodigoBarras As System.Windows.Forms.Label
    Friend WithEvents Txt_DescripDestino As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DescripSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Destino As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Sucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
