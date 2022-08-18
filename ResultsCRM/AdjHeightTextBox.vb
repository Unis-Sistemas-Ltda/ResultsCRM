Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Web.UI.WebControls

' Adjustable Height Text Box
' (c)Adrian Hayes, 2008.
' hayes.adrian@gmail.com
' * Source Code and Executable Files can be freely used in commercial applications;
' * Source Code can be modified to create derivative works.
' * No claim of suitability, guarantee, or any warranty whatsoever is provided. 
'   The software is provided "as-is".
' * If you publish the Source Code or any portion thereof, please include a
'   reference link back to http://www.bearnakedcode.com.
Namespace AdjustableHeightTextbox
	''' <summary>
	''' A TextBox control that allows you to set the height of the TextBox.
	''' </summary>
	Public Partial Class AdjHeightTextBox
		Inherits TextBox
		' Original height before Dock property set
		Private ciPreDockHeight As Integer
		' Original Distance to Bottom - used when set to AnchorStyles.Bottom
		Private ciOrigDistanceToBottom As Integer
		' If the textbox is set to multi-line, do the default value
		Private IsMultiLine As Boolean = False

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Sets the height of a textbox by adjusting the size of the font
		''' </summary>
		''' <param name="TextBoxHeight">Height of the textbox</param>
		''' <param name="OriginalFont">Font used</param>
		''' <returns>Returns a font object with the correct size to adjust the TextBox size.</returns>
		Private Shared Function GetFontForTextBoxHeight(TextBoxHeight As Integer, OriginalFont As Font) As Font
			' What is the target size of the text box?
			Dim desiredheight As Single = CSng(TextBoxHeight)

			' Set the font from the existing TextBox font.
			' We use the fnt = new Font(...) method so we can ensure that
			'  we're setting the GraphicsUnit to Pixels.  This avoids all
			'  the DPI conversions between point & pixel.
			Dim fnt As New Font(OriginalFont.FontFamily, OriginalFont.Size, OriginalFont.Style, GraphicsUnit.Pixel)

			' TextBoxes never size below 8 pixels. This consists of the
			' 4 pixels above & 3 below of whitespace, and 1 pixel line of
			' greeked text.
			If desiredheight < 8 Then
				desiredheight = 8
			End If

			' Determine the Em sizes of the font and font line spacing
			' These values are constant for each font at the given font style.
			' and screen DPI.
			Dim FontEmSize As Single = fnt.FontFamily.GetEmHeight(fnt.Style)
			Dim FontLineSpacing As Single = fnt.FontFamily.GetLineSpacing(fnt.Style)

			' emSize is the target font size.  TextBoxes have a total of
			' 7 pixels above and below the FontHeight of the font.
			Dim emSize As Single = (desiredheight - 7) * FontEmSize / FontLineSpacing

			' Create the font, with the proper size to change the TextBox Height to the desired size.
			fnt = New Font(fnt.FontFamily, emSize, fnt.Style, GraphicsUnit.Pixel)

			Return fnt
		End Function

		''' <summary>
		''' Determines if we should perform the default base.XXX action.
		''' </summary>
		''' <returns>
		''' True if the parent is null, the control is disposing
		''' or the Multi-Line property is true.
		''' </returns>
		Private Function DoDefault() As Boolean
			Return (Parent Is Nothing OrElse Disposing OrElse IsMultiLine)
		End Function

		''' <summary>
		''' Sets the height of the TextBox - the Size.Height property is ignored on TextBox controls
		''' </summary>
		<System.ComponentModel.Category("Layout")> _
		<System.ComponentModel.Description("Set the TextBox.Height.")> _
		Public Property Size_AdjustableHeight() As Integer
			Get
				Return Me.Height
			End Get
			Set
				' If the parent does not exist, we're set to multi-line
				' or we are disposing, do default
				If DoDefault() Then
					Return
				End If
				If value <> Me.Height Then
					Me.Height = value
					ciOrigDistanceToBottom = Parent.ClientSize.Height + Me.Top - value
					Me.Font = GetFontForTextBoxHeight(value, Me.Font)
				End If
			End Set
		End Property

		' If multi-line is set to true, set IsMultiline.  The control
		' will perform the default base.XXX actions.
		Public Overrides Property Multiline() As Boolean
			Get
				Return MyBase.Multiline
			End Get
			Set
				IsMultiLine = value
				MyBase.Multiline = value
			End Set
		End Property

		' If the dock style changes to a height-adjusting value, get the original
		' size first
		Public Overrides Property Dock() As DockStyle
			Get
				Return MyBase.Dock
			End Get
			Set
				' If the parent does not exist, we're set to multi-line
				' or we are disposing, do default
				If DoDefault() Then
					MyBase.Dock = value
					Return
				End If

				' if this docking change should affect the height
				If (value And DockStyle.Left) = DockStyle.Left OrElse (value And DockStyle.Right) = DockStyle.Right OrElse (value And DockStyle.Fill) = DockStyle.Fill Then
					' and if the base.dock is NOT ALREADY set to a height-adjusting
					' DockStyle, then get the original height.
					If (MyBase.Dock And DockStyle.Left) <> DockStyle.Left AndAlso (MyBase.Dock And DockStyle.Right) <> DockStyle.Right AndAlso (MyBase.Dock And DockStyle.Fill) <> DockStyle.Fill Then
						ciPreDockHeight = Height
					End If
				End If
				MyBase.Dock = value
			End Set
		End Property

		' Intercept TextBox.OnDockChanged to adjust the height of textbox
		' back to its original pre-dock value, if necessary.
		Protected Overrides Sub OnDockChanged(e As EventArgs)
			' If the parent does not exist, we're set to multi-line
			' or we are disposing, do default
			If DoDefault() Then
				MyBase.OnDockChanged(e)
				Return
			End If

			' if this docking change is bottom or none, set the height back to 
			' the original pre-dock value.
			If (Me.Dock And DockStyle.Bottom) = DockStyle.Bottom OrElse (Me.Dock And DockStyle.None) = DockStyle.None Then
				Me.Font = GetFontForTextBoxHeight(ciPreDockHeight, Me.Font)
			End If
			MyBase.OnDockChanged(e)
		End Sub

		' Intercept OnParentChanged to set distance to bottom for Anchoring
		' and add an event subscription to Parent.ClientSizeChanged
		Protected Overrides Sub OnParentChanged(e As EventArgs)
			' If the parent does not exist, we're set to multi-line
			' or we are disposing, do default
			If DoDefault() Then
				MyBase.OnDockChanged(e)
				Return
			End If
			ciOrigDistanceToBottom = Parent.ClientSize.Height - Me.Bottom
			ciPreDockHeight = Me.Height
			AddHandler Parent.ClientSizeChanged, New EventHandler(AddressOf Parent_ClientSizeChanged)
			MyBase.OnParentChanged(e)
		End Sub

		' Event Handler for Parent.ClientSizeChanged
		' If the parent size changes, we may need to adjust the textbox size
		' if it is docked or anchored.
		Private Sub Parent_ClientSizeChanged(sender As Object, e As EventArgs)
			' If the parent does not exist, we're set to multi-line
			' or we are disposing, do default
			If DoDefault() Then
				MyBase.OnDockChanged(e)
				Return
			End If

			If (Me.Dock And DockStyle.Left) = DockStyle.Left OrElse (Me.Dock And DockStyle.Right) = DockStyle.Right OrElse (Me.Dock And DockStyle.Fill) = DockStyle.Fill OrElse (Me.Anchor And AnchorStyles.Bottom) = AnchorStyles.Bottom Then
				Me.Font = GetFontForTextBoxHeight(Parent.ClientSize.Height, Me.Font)
			End If
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			' If the parent does not exist, we're set to multi-line
			' or we are disposing, do default
			If DoDefault() Then
				MyBase.OnSizeChanged(e)
				Return
			End If

			Dim height As Integer = Me.Height
			' Is the control docked or anchored to bottom?
			Select Case Me.Dock
				Case DockStyle.Fill, DockStyle.Left, DockStyle.Right
					height = Parent.ClientSize.Height
					Me.Font = GetFontForTextBoxHeight(height, Me.Font)
					Exit Select
				Case Else
					' Not docked in a way that should modify height.
					' Check for Anchoring that should change the height.
					' If so, set the height based on the original distance to bottom.
					If (Me.Anchor And AnchorStyles.Bottom) = AnchorStyles.Bottom Then
						height = Parent.ClientSize.Height - ciOrigDistanceToBottom
						Me.Font = GetFontForTextBoxHeight(height, Me.Font)
					End If
					Exit Select
			End Select

			MyBase.OnSizeChanged(e)
		End Sub
	End Class

End Namespace
