<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClinicReportOption
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboPatientName = New System.Windows.Forms.ComboBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.rbPatientName = New System.Windows.Forms.RadioButton
        Me.rdoDate = New System.Windows.Forms.RadioButton
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPatientName)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.rbPatientName)
        Me.GroupBox1.Controls.Add(Me.rdoDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 102)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione Opción del Reporte"
        '
        'cboPatientName
        '
        Me.cboPatientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatientName.Enabled = False
        Me.cboPatientName.FormattingEnabled = True
        Me.cboPatientName.Location = New System.Drawing.Point(167, 67)
        Me.cboPatientName.Name = "cboPatientName"
        Me.cboPatientName.Size = New System.Drawing.Size(200, 21)
        Me.cboPatientName.TabIndex = 4
        '
        'dtpDate
        '
        Me.dtpDate.Enabled = False
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(167, 32)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpDate.TabIndex = 3
        '
        'rbPatientName
        '
        Me.rbPatientName.AutoSize = True
        Me.rbPatientName.ForeColor = System.Drawing.Color.Purple
        Me.rbPatientName.Location = New System.Drawing.Point(7, 67)
        Me.rbPatientName.Name = "rbPatientName"
        Me.rbPatientName.Size = New System.Drawing.Size(131, 17)
        Me.rbPatientName.TabIndex = 1
        Me.rbPatientName.TabStop = True
        Me.rbPatientName.Text = "Por Nombre Empleado"
        Me.rbPatientName.UseVisualStyleBackColor = True
        '
        'rdoDate
        '
        Me.rdoDate.AutoSize = True
        Me.rdoDate.ForeColor = System.Drawing.Color.Purple
        Me.rdoDate.Location = New System.Drawing.Point(7, 32)
        Me.rdoDate.Name = "rdoDate"
        Me.rdoDate.Size = New System.Drawing.Size(74, 17)
        Me.rdoDate.TabIndex = 0
        Me.rdoDate.TabStop = True
        Me.rdoDate.Text = "Por Fecha"
        Me.rdoDate.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(246, 121)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Imprimir"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(328, 120)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Cerrar"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ClinicReportOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.ClientSize = New System.Drawing.Size(409, 152)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ClinicReportOption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Opción Reporte"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents rdoDate As System.Windows.Forms.RadioButton
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbPatientName As System.Windows.Forms.RadioButton
    Friend WithEvents cboPatientName As System.Windows.Forms.ComboBox
End Class
