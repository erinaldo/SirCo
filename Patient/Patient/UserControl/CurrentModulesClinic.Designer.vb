<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CurrentModulesClinic
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblDeleteClinic = New System.Windows.Forms.Label
        Me.lblEditClinic = New System.Windows.Forms.Label
        Me.lblNewClinic = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblDeleteClinic
        '
        Me.lblDeleteClinic.AutoSize = True
        Me.lblDeleteClinic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDeleteClinic.Location = New System.Drawing.Point(3, 78)
        Me.lblDeleteClinic.Name = "lblDeleteClinic"
        Me.lblDeleteClinic.Size = New System.Drawing.Size(66, 13)
        Me.lblDeleteClinic.TabIndex = 5
        Me.lblDeleteClinic.Text = "Delete Clinic"
        '
        'lblEditClinic
        '
        Me.lblEditClinic.AutoSize = True
        Me.lblEditClinic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEditClinic.Location = New System.Drawing.Point(3, 47)
        Me.lblEditClinic.Name = "lblEditClinic"
        Me.lblEditClinic.Size = New System.Drawing.Size(53, 13)
        Me.lblEditClinic.TabIndex = 4
        Me.lblEditClinic.Text = "Edit Clinic"
        '
        'lblNewClinic
        '
        Me.lblNewClinic.AutoSize = True
        Me.lblNewClinic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNewClinic.Location = New System.Drawing.Point(3, 19)
        Me.lblNewClinic.Name = "lblNewClinic"
        Me.lblNewClinic.Size = New System.Drawing.Size(57, 13)
        Me.lblNewClinic.TabIndex = 3
        Me.lblNewClinic.Text = "New Clinic"
        '
        'CurrentModulesClinic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDeleteClinic)
        Me.Controls.Add(Me.lblEditClinic)
        Me.Controls.Add(Me.lblNewClinic)
        Me.Name = "CurrentModulesClinic"
        Me.Size = New System.Drawing.Size(151, 241)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDeleteClinic As System.Windows.Forms.Label
    Friend WithEvents lblEditClinic As System.Windows.Forms.Label
    Friend WithEvents lblNewClinic As System.Windows.Forms.Label

End Class
