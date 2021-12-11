<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CollapseContainer
	Inherits System.Windows.Forms.Panel

	'UserControl overrides dispose to clean up the component list.
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CollapseContainer))
		Me.imgButtons = New System.Windows.Forms.ImageList(Me.components)
		Me.SuspendLayout()
		'
		'imgButtons
		'
		Me.imgButtons.ImageStream = CType(resources.GetObject("imgButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgButtons.TransparentColor = System.Drawing.Color.Transparent
		Me.imgButtons.Images.SetKeyName(0, "UpArrow.gif")
		Me.imgButtons.Images.SetKeyName(1, "DownArrow.gif")
		'
		'CollapseContainer
		'
		Me.Size = New System.Drawing.Size(179, 189)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents imgButtons As System.Windows.Forms.ImageList

End Class
