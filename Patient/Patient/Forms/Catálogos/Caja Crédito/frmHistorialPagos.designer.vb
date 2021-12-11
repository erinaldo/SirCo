<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorialPagos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnl_Botones = New System.Windows.Forms.Panel()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.DGridCobrado = New System.Windows.Forms.DataGridView()
        Me.lbl_Historial = New System.Windows.Forms.Label()
        Me.lbl_Distribuidor = New System.Windows.Forms.Label()
        Me.txt_NombreDistrib = New System.Windows.Forms.TextBox()
        Me.txt_Distrib = New System.Windows.Forms.TextBox()
        Me.pnl_Botones.SuspendLayout()
        CType(Me.DGridCobrado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Botones
        '
        Me.pnl_Botones.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_Botones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Botones.Controls.Add(Me.btn_Aceptar)
        Me.pnl_Botones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_Botones.Location = New System.Drawing.Point(0, 361)
        Me.pnl_Botones.Name = "pnl_Botones"
        Me.pnl_Botones.Size = New System.Drawing.Size(671, 70)
        Me.pnl_Botones.TabIndex = 13
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.BackColor = System.Drawing.Color.White
        Me.btn_Aceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Aceptar.Image = Global.SIRCO.My.Resources.Resources.OK
        Me.btn_Aceptar.Location = New System.Drawing.Point(593, 0)
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
        Me.DGridCobrado.Location = New System.Drawing.Point(12, 109)
        Me.DGridCobrado.Name = "DGridCobrado"
        Me.DGridCobrado.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridCobrado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGridCobrado.RowHeadersVisible = False
        Me.DGridCobrado.Size = New System.Drawing.Size(657, 246)
        Me.DGridCobrado.TabIndex = 14
        '
        'lbl_Historial
        '
        Me.lbl_Historial.AutoSize = True
        Me.lbl_Historial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Historial.Location = New System.Drawing.Point(12, 90)
        Me.lbl_Historial.Name = "lbl_Historial"
        Me.lbl_Historial.Size = New System.Drawing.Size(129, 16)
        Me.lbl_Historial.TabIndex = 21
        Me.lbl_Historial.Text = "Ultimos 10 Pagos"
        '
        'lbl_Distribuidor
        '
        Me.lbl_Distribuidor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lbl_Distribuidor.AutoSize = True
        Me.lbl_Distribuidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Distribuidor.ForeColor = System.Drawing.Color.Black
        Me.lbl_Distribuidor.Location = New System.Drawing.Point(8, 9)
        Me.lbl_Distribuidor.Name = "lbl_Distribuidor"
        Me.lbl_Distribuidor.Size = New System.Drawing.Size(139, 20)
        Me.lbl_Distribuidor.TabIndex = 24
        Me.lbl_Distribuidor.Text = "DISTRIBUIDOR"
        '
        'txt_NombreDistrib
        '
        Me.txt_NombreDistrib.BackColor = System.Drawing.SystemColors.Window
        Me.txt_NombreDistrib.Enabled = False
        Me.txt_NombreDistrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NombreDistrib.Location = New System.Drawing.Point(118, 44)
        Me.txt_NombreDistrib.Name = "txt_NombreDistrib"
        Me.txt_NombreDistrib.ReadOnly = True
        Me.txt_NombreDistrib.Size = New System.Drawing.Size(551, 29)
        Me.txt_NombreDistrib.TabIndex = 23
        '
        'txt_Distrib
        '
        Me.txt_Distrib.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txt_Distrib.Enabled = False
        Me.txt_Distrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Distrib.Location = New System.Drawing.Point(15, 44)
        Me.txt_Distrib.MaxLength = 6
        Me.txt_Distrib.Name = "txt_Distrib"
        Me.txt_Distrib.Size = New System.Drawing.Size(100, 29)
        Me.txt_Distrib.TabIndex = 22
        '
        'frmHistorialPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(671, 431)
        Me.Controls.Add(Me.lbl_Distribuidor)
        Me.Controls.Add(Me.txt_NombreDistrib)
        Me.Controls.Add(Me.txt_Distrib)
        Me.Controls.Add(Me.lbl_Historial)
        Me.Controls.Add(Me.DGridCobrado)
        Me.Controls.Add(Me.pnl_Botones)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmHistorialPagos"
        Me.Text = "Historial de Pagos"
        Me.pnl_Botones.ResumeLayout(False)
        CType(Me.DGridCobrado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_Botones As System.Windows.Forms.Panel
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents DGridCobrado As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_Historial As System.Windows.Forms.Label
    Friend WithEvents lbl_Distribuidor As System.Windows.Forms.Label
    Friend WithEvents txt_NombreDistrib As System.Windows.Forms.TextBox
    Friend WithEvents txt_Distrib As System.Windows.Forms.TextBox
End Class
