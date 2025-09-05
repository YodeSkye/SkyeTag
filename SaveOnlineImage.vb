
Imports SkyeTag.My

Public Class SaveOnlineImage

	'Declarations
	Friend ReadOnly Property GetFilename As String
		Get
			Return filename
		End Get
	End Property
	Private filename As String = String.Empty

	'Form Events
	Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
		Try
			If m.Msg = My.WinAPI.WM_SYSCOMMAND AndAlso m.WParam.ToInt32 = My.WinAPI.SC_CLOSE Then
				DialogResult = DialogResult.Cancel
			End If
		Catch ex As Exception
			My.App.WriteToLog("SaveOnlineImage WndProc Handler Error" + Chr(13) + ex.ToString)
		Finally
			MyBase.WndProc(m)
		End Try
	End Sub

	'Control Events
	Private Sub BtnLocation_Click(sender As Object, e As EventArgs) Handles BtnLocation.Click
		Dim ofd As New FolderBrowserDialog
		ofd.Description = "Select File Location"
		ofd.Multiselect = False
		Dim result As DialogResult = ofd.ShowDialog(Me)
		If result = DialogResult.OK AndAlso Not String.IsNullOrEmpty(ofd.SelectedPath) Then
			TxtBoxLocation.Text = ofd.SelectedPath
		End If
		result = Nothing
		ofd.Dispose()
		ofd = Nothing
	End Sub
	Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
		filename = TxtBoxLocation.Text.Trim + "\" + TxtBoxFilename.Text.Trim
		If RadBtnImageFormatJPG.Checked Then
			filename += ".jpg"
		ElseIf RadBtnImageFormatPNG.Checked Then
			filename += ".png"
		ElseIf RadBtnImageFormatBMP.Checked Then
			filename += ".bmp"
		End If
		LblFilename.ResetForeColor()
		LblLocation.ResetForeColor()
		If String.IsNullOrEmpty(TxtBoxFilename.Text) OrElse TxtBoxFilename.Text.Intersect(System.IO.Path.GetInvalidFileNameChars).Any OrElse System.IO.File.Exists(filename) Then
			TxtBoxFilename.Focus()
			LblFilename.ForeColor = Color.Red
		ElseIf String.IsNullOrEmpty(TxtBoxLocation.Text) OrElse TxtBoxLocation.Text.Intersect(System.IO.Path.GetInvalidPathChars).Any OrElse Not System.IO.Directory.Exists(TxtBoxLocation.Text) Then
			TxtBoxLocation.Focus()
			LblLocation.ForeColor = Color.Red
		Else
			DialogResult = DialogResult.OK
			Close()
		End If
	End Sub
	Private Sub tipInfo_Popup(sender As Object, e As PopupEventArgs) Handles tipInfo.Popup
		Static s As Size
		s = TextRenderer.MeasureText(tipInfo.GetToolTip(e.AssociatedControl), App.TipFont)
		If tipInfo.Tag Is Nothing Then
			s.Width += 14
			s.Height += 14
		Else
			s.Width += CType(tipInfo.Tag, Bitmap).Width + 14
			s.Height = CType(tipInfo.Tag, Bitmap).Height + 12
		End If
		e.ToolTipSize = s
	End Sub
	Private Sub tipInfo_Draw(sender As Object, e As DrawToolTipEventArgs) Handles tipInfo.Draw

		'Declarations
		Dim g As Graphics = e.Graphics

		'Draw background
		Dim brbg As New SolidBrush(App.TipBackColor)
		g.FillRectangle(brbg, e.Bounds)

		'Draw border
		Using p As New Pen(App.TipBorderColor, CInt(App.TipFont.Size / 4)) 'Scale border thickness with font
			g.DrawRectangle(p, 0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1)
		End Using

		'Draw text
		TextRenderer.DrawText(g, e.ToolTipText, App.TipFont, New Point(7, 7), App.TipTextColor)

		'Finalize
		brbg.Dispose()
		g.Dispose()

	End Sub

End Class
