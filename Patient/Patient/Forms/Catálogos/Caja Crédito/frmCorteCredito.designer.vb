<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorteCredito
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pnl_Botones = New System.Windows.Forms.Panel
        Me.btn_Cancelar = New System.Windows.Forms.Button
        Me.btn_Aceptar = New System.Windows.Forms.Button
        Me.DGridCobrado = New System.Windows.Forms.DataGridView
        Me.lbl_Fecha = New System.Windows.Forms.Label
        Me.DT_Fecha = New System.Windows.Forms.DateTimePicker
        Me.lbl_Cajero = New System.Windows.Forms.Label
        Me.cb_Cajero = New System.Windows.Forms.ComboBox
        Me.lbl_Desglose = New System.Windows.Forms.Label
        Me.pnl_Botones.SuspendLayout()
        CType(Me.DGridCobrado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Cancelar)
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 442)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(1017, 70)
        Me.pnl_Botones.TabIndex = 13
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.BackColor = System.Drawing.Color.White
        Me.btn_Cancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Cancelar.Image = Global.SIRCO.My.Resources.Resources.cancel1
        Me.btn_Cancelar.Location = New System.Drawing.Point(865, 0)
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
        Me.btn_Aceptar.Location = New System.Drawing.Point(939, 0)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(74, 66)
        Me.btn_Aceptar.TabIndex = 0
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Aceptar.UseVisualStyleBackColor = False
        '
        'DGridCobrado
        '
        Me.DGridCobrado.AllowUserToAddRows = False
        Me.DGridCobrado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGridCobrado.BackgroundColor = System.Drawing.Color.White
        Me.DGridCobrado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridCobrado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGridCobrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridCobrado.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGridCobrado.Location = New System.Drawing.Point(12, 134)
        Me.DGridCobrado.Name = "DGridCobrado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridCobrado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGridCobrado.RowHeadersVisible = False
        Me.DGridCobrado.Size = New System.Drawing.Size(506, 290)
        Me.DGridCobrado.TabIndex = 14
        '
        'lbl_Fecha
        '
        Me.lbl_Fecha.AutoSize = True
        Me.lbl_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fecha.Location = New System.Drawing.Point(12, 27)
        Me.lbl_Fecha.Name = "lbl_Fecha"
        Me.lbl_Fecha.Size = New System.Drawing.Size(51, 16)
        Me.lbl_Fecha.TabIndex = 17
        Me.lbl_Fecha.Text = "Fecha"
        '
        'DT_Fecha
        '
        Me.DT_Fecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Fecha.Location = New System.Drawing.Point(99, 25)
        Me.DT_Fecha.Name = "DT_Fecha"
        Me.DT_Fecha.Size = New System.Drawing.Size(252, 20)
        Me.DT_Fecha.TabIndex = 18
        '
        'lbl_Cajero
        '
        Me.lbl_Cajero.AutoSize = True
        Me.lbl_Cajero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Cajero.Location = New System.Drawing.Point(12, 68)
        Me.lbl_Cajero.Name = "lbl_Cajero"
        Me.lbl_Cajero.Size = New System.Drawing.Size(54, 16)
        Me.lbl_Cajero.TabIndex = 19
        Me.lbl_Cajero.Text = "Cajero"
        '
        'cb_Cajero
        '
        Me.cb_Cajero.FormattingEnabled = True
        Me.cb_Cajero.Location = New System.Drawing.Point(99, 67)
        Me.cb_Cajero.Name = "cb_Cajero"
        Me.cb_Cajero.Size = New System.Drawing.Size(252, 21)
        Me.cb_Cajero.TabIndex = 20
        '
        'lbl_Desglose
        '
        Me.lbl_Desglose.AutoSize = True
        Me.lbl_Desglose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Desglose.Location = New System.Drawing.Point(12, 109)
        Me.lbl_Desglose.Name = "lbl_Desglose"
        Me.lbl_Desglose.Size = New System.Drawing.Size(123, 16)
        Me.lbl_Desglose.TabIndex = 21
        Me.lbl_Desglose.Text = "Formas de Pago"
        '
        'frmCorteCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1017, 512)
        Me.Controls.Add(Me.lbl_Desglose)
        Me.Controls.Add(Me.cb_Cajero)
        Me.Controls.Add(Me.lbl_Cajero)
        Me.Controls.Add(Me.DT_Fecha)
        Me.Controls.Add(Me.lbl_Fecha)
        Me.Controls.Add(Me.DGridCobrado)
        Me.Controls.Add(Me.pnl_Botones)
        Me.KeyPreview = True
        Me.Name = "frmCorteCredito"
        Me.Text = "Corte Crédito"
        Me.pnl_Botones.ResumeLayout(False)
        CType(Me.DGridCobrado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents DGridCobrado As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Fecha As System.Windows.Forms.Label
    Friend WithEvents DT_Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Cajero As System.Windows.Forms.Label
    Friend WithEvents cb_Cajero As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Desglose As System.Windows.Forms.Label
End Class
