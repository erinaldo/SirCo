<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportBrowserCredito
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
        Me.crReports = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crReports
        '
        Me.crReports.ActiveViewIndex = -1
        Me.crReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crReports.DisplayGroupTree = False
        Me.crReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crReports.Location = New System.Drawing.Point(0, 0)
        Me.crReports.Name = "crReports"
        Me.crReports.SelectionFormula = ""
        Me.crReports.ShowGroupTreeButton = False
        Me.crReports.Size = New System.Drawing.Size(712, 539)
        Me.crReports.TabIndex = 2
        Me.crReports.ViewTimeSelectionFormula = ""
        '
        'frmReportBrowserCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 539)
        Me.Controls.Add(Me.crReports)
        Me.Name = "frmReportBrowserCredito"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crReports As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
