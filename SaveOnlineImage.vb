
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
			If m.Msg = Skye.WinAPI.WM_SYSCOMMAND AndAlso m.WParam.ToInt32 = Skye.WinAPI.SC_CLOSE Then
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
		Dim ofd As New FolderBrowserDialog With {
			.Description = "Select File Location",
			.Multiselect = False}
		Dim result As DialogResult = ofd.ShowDialog(Me)
		If result = DialogResult.OK AndAlso Not String.IsNullOrEmpty(ofd.SelectedPath) Then
			TxtBoxLocation.Text = ofd.SelectedPath
		End If
		ofd.Dispose()
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

End Class
