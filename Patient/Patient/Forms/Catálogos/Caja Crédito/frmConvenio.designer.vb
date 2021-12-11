<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConvenio
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnl_Botones = New System.Windows.Forms.Panel
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.btn_Aceptar = New System.Windows.Forms.Button
        Me.lbl_Fecha = New System.Windows.Forms.Label
        Me.txt_Observaciones = New System.Windows.Forms.TextBox
        Me.lbl_Observaciones = New System.Windows.Forms.Label
        Me.DGrid = New System.Windows.Forms.DataGridView
        Me.col_Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Pago = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl_TotPag = New System.Windows.Forms.Label
        Me.lbl_Pendiente = New System.Windows.Forms.Label
        Me.lbl_TotImp = New System.Windows.Forms.Label
        Me.lbl_PenImp = New System.Windows.Forms.Label
        Me.pnl_Botones.SuspendLayout()
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 371)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(543, 70)
        Me.pnl_Botones.TabIndex = 13
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.White
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelar.Location = New System.Drawing.Point(391, 0)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Cancelar.TabIndex = 1
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Cancelar.UseVisualStyleBackColor = False
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.BackColor = System.Drawing.Color.White
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.Location = New System.Drawing.Point(465, 0)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Aceptar.TabIndex = 0
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'lbl_Fecha
        '
        Me.lbl_Fecha.AutoSize = True
        Me.lbl_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fecha.ForeColor = System.Drawing.Color.Black
        Me.lbl_Fecha.Location = New System.Drawing.Point(9, 19)
        Me.lbl_Fecha.Name = "lbl_Fecha"
        Me.lbl_Fecha.Size = New System.Drawing.Size(68, 16)
        Me.lbl_Fecha.TabIndex = 21
        Me.lbl_Fecha.Text = "FECHAS"
        '
        'txt_Observaciones
        '
        Me.txt_Observaciones.BackColor = System.Drawing.SystemColors.Window
        Me.txt_Observaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Observaciones.Location = New System.Drawing.Point(12, 284)
        Me.txt_Observaciones.MaxLength = 100
        Me.txt_Observaciones.Multiline = True
        Me.txt_Observaciones.Name = "txt_Observaciones"
        Me.txt_Observaciones.Size = New System.Drawing.Size(519, 75)
        Me.txt_Observaciones.TabIndex = 3
        '
        'lbl_Observaciones
        '
        Me.lbl_Observaciones.AutoSize = True
        Me.lbl_Observaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Observaciones.ForeColor = System.Drawing.Color.Black
        Me.lbl_Observaciones.Location = New System.Drawing.Point(12, 261)
        Me.lbl_Observaciones.Name = "lbl_Observaciones"
        Me.lbl_Observaciones.Size = New System.Drawing.Size(136, 16)
        Me.lbl_Observaciones.TabIndex = 23
        Me.lbl_Observaciones.Text = "OBSERVACIONES"
        '
        'DGrid
        '
        Me.DGrid.AllowUserToAddRows = False
        Me.DGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGrid.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_Fecha, Me.col_Pago, Me.col_importe})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGrid.Location = New System.Drawing.Point(12, 38)
        Me.DGrid.Name = "DGrid"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGrid.RowHeadersVisible = False
        Me.DGrid.Size = New System.Drawing.Size(519, 169)
        Me.DGrid.TabIndex = 28
        '
        'col_Fecha
        '
        Me.col_Fecha.HeaderText = "Fecha"
        Me.col_Fecha.Name = "col_Fecha"
        '
        'col_Pago
        '
        Me.col_Pago.HeaderText = "Pago"
        Me.col_Pago.Name = "col_Pago"
        Me.col_Pago.ReadOnly = True
        '
        'col_importe
        '
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.col_importe.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_importe.HeaderText = "Importe"
        Me.col_importe.Name = "col_importe"
        '
        'lbl_TotPag
        '
        Me.lbl_TotPag.AutoSize = True
        Me.lbl_TotPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotPag.ForeColor = System.Drawing.Color.Black
        Me.lbl_TotPag.Location = New System.Drawing.Point(272, 212)
        Me.lbl_TotPag.Name = "lbl_TotPag"
        Me.lbl_TotPag.Size = New System.Drawing.Size(140, 16)
        Me.lbl_TotPag.TabIndex = 29
        Me.lbl_TotPag.Text = "TOTAL DEL PAGO:"
        '
        'lbl_Pendiente
        '
        Me.lbl_Pendiente.AutoSize = True
        Me.lbl_Pendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Pendiente.ForeColor = System.Drawing.Color.Black
        Me.lbl_Pendiente.Location = New System.Drawing.Point(313, 241)
        Me.lbl_Pendiente.Name = "lbl_Pendiente"
        Me.lbl_Pendiente.Size = New System.Drawing.Size(99, 16)
        Me.lbl_Pendiente.TabIndex = 30
        Me.lbl_Pendiente.Text = "PENDIENTE:"
        '
        'lbl_TotImp
        '
        Me.lbl_TotImp.AutoSize = True
        Me.lbl_TotImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_TotImp.ForeColor = System.Drawing.Color.Black
        Me.lbl_TotImp.Location = New System.Drawing.Point(418, 212)
        Me.lbl_TotImp.Name = "lbl_TotImp"
        Me.lbl_TotImp.Size = New System.Drawing.Size(0, 16)
        Me.lbl_TotImp.TabIndex = 31
        '
        'lbl_PenImp
        '
        Me.lbl_PenImp.AutoSize = True
        Me.lbl_PenImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PenImp.ForeColor = System.Drawing.Color.Black
        Me.lbl_PenImp.Location = New System.Drawing.Point(418, 241)
        Me.lbl_PenImp.Name = "lbl_PenImp"
        Me.lbl_PenImp.Size = New System.Drawing.Size(0, 16)
        Me.lbl_PenImp.TabIndex = 32
        '
        'frmConvenio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(543, 441)
        Me.Controls.Add(Me.lbl_PenImp)
        Me.Controls.Add(Me.lbl_TotImp)
        Me.Controls.Add(Me.lbl_Pendiente)
        Me.Controls.Add(Me.lbl_TotPag)
        Me.Controls.Add(Me.DGrid)
        Me.Controls.Add(Me.lbl_Observaciones)
        Me.Controls.Add(Me.txt_Observaciones)
        Me.Controls.Add(Me.lbl_Fecha)
        Me.Controls.Add(Me.pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmConvenio"
        Me.Text = "Convenio"
        Me.pnl_Botones.ResumeLayout(False)
        CType(Me.DGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Observaciones As System.Windows.Forms.Label
    Friend WithEvents DGrid As System.Windows.Forms.DataGridView
    Friend WithEvents col_Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Pago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_TotPag As System.Windows.Forms.Label
    Friend WithEvents lbl_Pendiente As System.Windows.Forms.Label
    Friend WithEvents lbl_TotImp As System.Windows.Forms.Label
    Friend WithEvents lbl_PenImp As System.Windows.Forms.Label
End Class
