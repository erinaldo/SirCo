<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.cvwmain = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'cvwmain
        '
        Me.cvwmain.ActiveViewIndex = -1
        Me.cvwmain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cvwmain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cvwmain.Location = New System.Drawing.Point(0, 0)
        Me.cvwmain.Name = "cvwmain"
        Me.cvwmain.SelectionFormula = ""
        Me.cvwmain.Size = New System.Drawing.Size(426, 397)
        Me.cvwmain.TabIndex = 0
        Me.cvwmain.ViewTimeSelectionFormula = ""
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 397)
        Me.Controls.Add(Me.cvwmain)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cvwmain As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
