Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing.Drawing2D


<System.Drawing.ToolboxBitmapAttribute(GetType(System.Windows.Forms.Panel)), _
  System.ComponentModel.DefaultProperty("HeaderText")> _
Public Class CollapseContainer
	Inherits System.Windows.Forms.Panel

#Region " Variables"
	' Colors
	Private _BorderColor As Color = Color.FromArgb(101, 147, 207)
	Private _NormalLightColor As Color = Color.FromArgb(227, 239, 255)
	Private _NormalDarkColor As Color = Color.FromArgb(214, 232, 255)
	Private _RollOverLightColor As Color = Color.White
	Private _RollOverDarkColor As Color = Color.FromArgb(227, 239, 255)

	Private _MouseOver As Boolean = False

	Private _NoCheckControllAdded As Boolean

	Private _HeaderHeight As Integer = 20
	Private _HeaderText As String
	Private _ContentHider As Panel

	Private _Collapsable As Boolean = True
	Private _PanelOpen As Boolean = True
	Private _OpenHeight As Integer
#End Region

#Region " Control New"
	Public Sub New()
		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.BackColor = System.Drawing.SystemColors.Control
		_HeaderText = Me.Name.ToString

		' When the CollapseContainer is docked-filled - we cant really change it's height can we?
		' So...instead of altering its height property, we have to 'fake it' by covering up any controls
		' the user may have placed inside the panel (we could have created a collection to grab the visible property of all controls
		' added to the container - then turning them all to false when hidden...and restoring them when opened up again
		' but I didnt want the overhead involved in this
		_ContentHider = New Panel
		_ContentHider.Dock = DockStyle.Fill
		_ContentHider.Visible = False

		_NoCheckControllAdded = True
		Me.Controls.Add(_ContentHider)
		_NoCheckControllAdded = False
	End Sub
#End Region

#Region " Properties"

	''' <summary>
	''' This returns the height of the control when it's fully opened
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property OpenHeight() As Integer
		Get
			Return _OpenHeight
		End Get
		Set(ByVal value As Integer)
			_OpenHeight = value
		End Set
	End Property


	''' <summary>
	''' The text to be displayed in the control
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property HeaderText() As String
		Get
			Return _HeaderText
		End Get
		Set(ByVal value As String)
			_HeaderText = value
			Me.Refresh()
		End Set
	End Property


	''' <summary>
	''' If true, the control can be collapsed.  If false, it cannot
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Collapsable() As Boolean
		Get
			Return _Collapsable
		End Get
		Set(ByVal value As Boolean)
			_Collapsable = value
			Me.Refresh()
		End Set
	End Property

	''' <summary>
	''' Sets or returns the current panels open or closed status
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	<RefreshProperties(RefreshProperties.All)> _
	Public Property PanelOpen() As Boolean
		Get
			Return _PanelOpen
		End Get
		Set(ByVal value As Boolean)
			_PanelOpen = value

			' If the user has collapsed the control in the designer - force Collapsable to true
			If Not _PanelOpen Then
				Me.Collapsable = True
			End If
			SetContentPanel()
		End Set
	End Property

	''' <summary>
	''' Override this to simulate the header panel
	''' Notice I leave one pixel at the bottom for the bottom line :)
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Overrides ReadOnly Property DisplayRectangle() As System.Drawing.Rectangle
		Get
			Dim myPadding As Padding = Me.Padding
			Dim myClientRect As New Rectangle(0 + myPadding.Left, _HeaderHeight + myPadding.Top, Me.Width - myPadding.Right, (Me.Height - (_HeaderHeight + 1)) - myPadding.Bottom)
			Return myClientRect
			'Return MyBase.DisplayRectangle
		End Get
	End Property

#End Region



#Region " Methods"
	''' <summary>
	''' If the user changes the header font - resize the header area and refresh the controls layout engine
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub CollapseContainer_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
		_HeaderHeight = CInt(CType(sender, Control).Font.Size + 11)
		If Not _PanelOpen Then
			Me.Height = _HeaderHeight
		End If

		' Recalc our layout
		Me.PerformLayout()
	End Sub


	''' <summary>
	''' The primary purpose of trapping the Paint is to add the seperator bar - but since we're trapping the entire paint event, 
	''' we need to fill in the backcolor as well
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub CollapseContainer_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
		If _PanelOpen Then _OpenHeight = Me.Height
		e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), 0, 0, Bounds.Width, Bounds.Height)


		' Paint my background
		e.Graphics.FillRectangle(Brushes.White, 0, 0, Bounds.Width, Bounds.Height)

		' Setup our colors
		Dim SepColor As Color = Color.FromArgb(173, 209, 255)
		Dim ColorLight As Color = Color.FromArgb(226, 238, 255)
		Dim ColorDark As Color = Color.FromArgb(214, 232, 255)

		If _MouseOver Then
			ColorDark = ColorLight
			ColorLight = Color.White
		End If

		Dim HeaderRect As Rectangle = New Rectangle(0, 0, Bounds.Width, _HeaderHeight)
		Dim HeaderBrush As LinearGradientBrush = New LinearGradientBrush(HeaderRect, Color.White, Color.White, LinearGradientMode.Horizontal)
		HeaderBrush.WrapMode = WrapMode.TileFlipX
		HeaderBrush.SetSigmaBellShape(0.1)

		' Set the gradient colors
		Dim cb As New ColorBlend(3)

		' The Positions properties tell the gradient where to change colors
		' For this panel - our gradient is horizontal - so our positions are along the horizontal axis
		' the 1st position is 0 - the very beginning of the gradient and we should be at the 1st color
		' the 2nd position is 0.5 which means at 50% of the WIDTH of the gradient, we should be on the 2nd color
		' the 3rd position is 1.0 which means at 100% of the WIDTH of the graidne we should be on the 3rd color

		' Far left color (when horizontal) - this would be the Far Top color if Vertical
		cb.Positions(0) = 0
		cb.Colors(0) = ColorDark

		' Middle color
		cb.Positions(1) = 0.5
		cb.Colors(1) = ColorLight

		' Far right color (or bottom)
		cb.Positions(2) = 1
		cb.Colors(2) = ColorDark

		HeaderBrush.InterpolationColors = cb
		e.Graphics.CompositingQuality = CompositingQuality.HighQuality
		e.Graphics.SmoothingMode = SmoothingMode.HighQuality
		e.Graphics.CompositingMode = CompositingMode.SourceOver
		e.Graphics.FillRectangle(HeaderBrush, HeaderRect)

		' Draw our button
		If _Collapsable Then
			Dim ButtonY As Integer = CInt((_HeaderHeight / 2) - (imgButtons.Images(0).Height / 2))
			If _PanelOpen Then
				' Display the Up Arrows
				e.Graphics.DrawImage(imgButtons.Images(0), Bounds.Width - 15, ButtonY)
			Else
				' Display the Down Arrows
				e.Graphics.DrawImage(imgButtons.Images(1), Bounds.Width - 15, ButtonY)
			End If
		End If

		' Draw the borders (if not dock-filled)
		e.Graphics.DrawLine(New Pen(SepColor), 0, _HeaderHeight - 1, Bounds.Width, _HeaderHeight - 1)

		' Setup to draw the text (Font, Alignment, etc. etc.)
		Dim ActiveFont As New Font(Font.FontFamily, Font.Size, Font.Style)
		Dim TextFormat As New StringFormat
		Dim FontBrush As New SolidBrush(Color.FromArgb(16, 45, 100))
		TextFormat.FormatFlags = StringFormatFlags.NoWrap
		TextFormat.Trimming = StringTrimming.EllipsisCharacter
		TextFormat.Alignment = StringAlignment.Near
		TextFormat.LineAlignment = StringAlignment.Center

		' Draw the font - but do it with style :)
		Dim FontBounds As Rectangle
		FontBounds.X = 10
		FontBounds.Y = 2
		FontBounds.Width = Bounds.Width
		FontBounds.Height = _HeaderHeight - 2

		Dim TextGraphicsPath As New GraphicsPath
		Try
			'TextGraphicsPath.AddString(_HeaderText, ActiveFont.FontFamily, ActiveFont.Style, ActiveFont.Size + 3, FontBounds, TextFormat)
			'e.Graphics.SmoothingMode = SmoothingMode.HighQuality
			e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
			e.Graphics.DrawString(_HeaderText, ActiveFont, FontBrush, FontBounds, TextFormat)
			'e.Graphics.FillPath(FontBrush, TextGraphicsPath)

		Catch ex As Exception

		End Try

		TextGraphicsPath.Dispose() : TextGraphicsPath = Nothing
		ActiveFont.Dispose() : ActiveFont = Nothing
		TextFormat.Dispose() : TextFormat = Nothing
		FontBounds = Nothing




		' Draw the bottom Seperator line (if we're not dock-filled)
		If Me.Dock <> DockStyle.Fill Then
			e.Graphics.DrawLine(New Pen(_BorderColor), 0, Bounds.Height - 1, Bounds.Width, Bounds.Height - 1)
		End If
	End Sub

	''' <summary>
	''' When our size changes, we'll get ghosting from the custom lines - so to ensure the lines are drawn properly, we force a refresh
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	<RefreshProperties(RefreshProperties.All)> _
	 Private Sub CollapseContainer_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
		Me.Refresh()
	End Sub
#End Region



#Region " HeaderPanel"

	''' <summary>
	''' We're only interested in lighting up the header when the control is collapsable
	''' We also only want to light up the header - if it's not ALREADY lit up...this prevents blinking
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub CollapseContainer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
		If _Collapsable Then
			If e.Y > 0 And e.Y < 21 Then
				If Not _MouseOver Then
					_MouseOver = True
					Me.Cursor = Cursors.Hand
					Me.Refresh()
				End If
			Else
				If _MouseOver Then
					_MouseOver = False
					Me.Cursor = Cursors.Default
					Me.Refresh()
				End If
			End If
		End If
	End Sub

	''' <summary>
	''' If we're collapsable and the header was lit - go turn it off and refresh the painting
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub CollapseContainer_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
		If _Collapsable Then
			_MouseOver = False
			Me.Refresh()
		End If
	End Sub

	''' <summary>
	''' If we're collapsable and the user clicked...toggle the collapse state
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	''' <remarks></remarks>
	Private Sub CollapseContainer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
		If _Collapsable Then
			_PanelOpen = (_PanelOpen = False)
			SetContentPanel()
		End If
	End Sub

	''' <summary>
	''' Adjusts the Height of the control based on the _PanelOpen settings
	''' </summary>
	''' <remarks></remarks>
	Private Sub SetContentPanel()
		If _PanelOpen Then
			If Me.Dock = DockStyle.Fill Then
				_ContentHider.Visible = False
			Else
				Me.Height = Me.OpenHeight
			End If
		Else
			If Me.Dock = DockStyle.Fill Then
				_ContentHider.Visible = True
				_ContentHider.BringToFront()
			Else
				_OpenHeight = Me.Height
				Me.Height = _HeaderHeight
			End If
		End If
		Me.Refresh()
	End Sub


#End Region

#Region " Hidden Properties"
	<Browsable(False)> _
	 Public Overrides Property Autosize() As Boolean
		Get
			Return MyBase.AutoSize
		End Get
		Set(ByVal value As Boolean)
			MyBase.AutoSize = value
		End Set
	End Property

	<Browsable(False)> _
	 Public Overrides Property AllowDrop() As Boolean
		Get
			Return MyBase.AllowDrop
		End Get
		Set(ByVal value As Boolean)
			MyBase.AllowDrop = value
		End Set
	End Property

	<Browsable(False)> _
	Public Overrides Property AutoScroll() As Boolean
		Get
			Return MyBase.AutoScroll
		End Get
		Set(ByVal value As Boolean)
			MyBase.AutoScroll = value
		End Set
	End Property

	<Browsable(False)> _
	Public Overrides Property BackgroundImage() As System.Drawing.Image
		Get
			Return MyBase.BackgroundImage
		End Get
		Set(ByVal value As System.Drawing.Image)
			MyBase.BackgroundImage = value
		End Set
	End Property

	<Browsable(False)> _
	Public Overrides Property BackgroundImageLayout() As System.Windows.Forms.ImageLayout
		Get
			Return MyBase.BackgroundImageLayout
		End Get
		Set(ByVal value As System.Windows.Forms.ImageLayout)
			MyBase.BackgroundImageLayout = value
		End Set
	End Property

#End Region

End Class

