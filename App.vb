
Imports Skye.UI

Namespace My

	Friend Module App

		' Declarations
		Friend Enum ImageSource
			File
			SelectFile
			SelectOnline
			ClipBoard
		End Enum
		Friend Enum CopyModes
			Basic
			Art
			Full
		End Enum
		Friend Enum FormatFileSizeUnits
			Auto
			Bytes
			KiloBytes
			MegaBytes
			GigaBytes
		End Enum
		Friend Class TagType
			Public Mode As CopyModes
			Public Artists As New Collections.Generic.List(Of String)
			Public Genre As String = String.Empty
			Public Title As String = String.Empty
			Public Track As UInteger = 0
			Public TrackCount As UInteger = 0
			Public Album As String = String.Empty
			Public Year As UInteger = 0
			Public Comment As String = String.Empty
			Public Art As New Collections.Generic.List(Of TagLib.IPicture)
			Public Lyrics As String = String.Empty
			Public Function TagContainsData() As Boolean
				If Artists.Count > 0 OrElse Not String.IsNullOrEmpty(Genre) OrElse Not String.IsNullOrEmpty(Title) _
					OrElse Track > 0 OrElse TrackCount > 0 OrElse Not String.IsNullOrEmpty(Album) _
					OrElse Year > 0 OrElse Not String.IsNullOrEmpty(Comment) _
					OrElse Art.Count > 0 OrElse Not String.IsNullOrEmpty(Lyrics) Then
					Return True
				End If
				Return False
			End Function
			Public Function TagContainsArtData() As Boolean
				If Art.Count > 0 Then
					Return True
				End If
				Return False
			End Function
			Public Function TagContainsExtendedData() As Boolean
				If Art.Count > 0 OrElse Not String.IsNullOrEmpty(Lyrics) Then
					Return True
				End If
				Return False
			End Function
		End Class
		Friend tagCopy As New TagType
		Friend AppAlert As Boolean = False
		Friend AppAlertMessage As String = String.Empty
		Friend tagPath As String
		Friend tagPaths As New List(Of String) From {tagPath}
		Friend tagArtistIndex As Integer
		Friend tagArtIndex As Integer
		Friend FrmMain As MainForm
		Friend FrmLog As Log
		Private FrmHelp As Help
		Private FrmSettings As SkyeTag.Settings
		Friend ReadOnly CMFont As New Font("Segoe UI", 12, FontStyle.Regular) 'Font for context menus
		Friend Const AdjustScreenBoundsNormalWindow As Byte = 8
		Friend Const AdjustScreenBoundsDialogWindow As Byte = 10
		Friend Const sError As String = "Error Opening File"
		Friend Const sNoFile As String = "Media File(s) Not Specified"
		Friend Const sNotFound As String = "File Does Not Exist"
		Friend Const sNotFile As String = "Folders Not Supported"
		Friend Const sBadFile As String = "Corrupt File"
		Friend Const sUnSupportedFile As String = "UnSupported File Type"
		Friend Const sUnAccessibleFile As String = "File Not Accessible"
		Friend Const hArtist As String = "Artist"
		Friend Const hArt As String = "Art"
		Friend ReadOnly Property IsMultiFile As Boolean
			Get
				Return App.tagPaths IsNot Nothing AndAlso App.tagPaths.Count > 1
			End Get
		End Property
		Friend Class Settings

			Friend Shared SaveMetrics As Boolean ' SaveMetrics determines whether the application saves the StartLocation and StartSize when it closes.
			Friend Shared IsMaximized As Boolean ' IsMaximized determines whether the Main Window is maximized.
			Friend Shared StartLocation As Point ' StartLocation is the location of the Main Window on the screen.
			Friend Shared StartSize As Size ' StartSize is the size of the Main Window.
			Friend Shared Theme As Skye.UI.SkyeTheme ' Theme is the current theme of the application. Default is Light.
			Friend Shared ThemeAuto As Boolean ' ThemeAuto determines whether the application theme changes automatically based on the current Windows theme. Default is True.

			Friend Shared Sub Load()
				Dim starttime As TimeSpan = DateTime.Now.TimeOfDay

                ' Metrics
                SaveMetrics = Skye.Common.RegistryHelper.GetBool("SaveMetrics", False)
                IsMaximized = Skye.Common.RegistryHelper.GetBool("IsMaximized", False)
                Dim x As Integer = Skye.Common.RegistryHelper.GetInt("StartLocationX", 80)
				Dim y As Integer = Skye.Common.RegistryHelper.GetInt("StartLocationY", 120)
				StartLocation = New Point(x, y)
				Dim w As Integer = Skye.Common.RegistryHelper.GetInt("StartSizeW", 400)
				Dim h As Integer = Skye.Common.RegistryHelper.GetInt("StartSizeH", 600)
				StartSize = New Size(w, h)

				' Theme
				Dim themeName As String = Skye.Common.RegistryHelper.GetString("Theme", "Light")
				Theme = SkyeThemes.GetTheme(themeName)
				ThemeAuto = Skye.Common.RegistryHelper.GetBool("ThemeAuto", True)

				WriteToLog("Settings Loaded (" & Skye.Common.GenerateLogTime(starttime, DateTime.Now.TimeOfDay, True) & ")", False)
			End Sub
			Friend Shared Sub Save()
				Dim starttime As TimeSpan = DateTime.Now.TimeOfDay

                ' Metrics
                Skye.Common.RegistryHelper.SetBool("SaveMetrics", SaveMetrics)
				Skye.Common.RegistryHelper.SetBool("IsMaximized", IsMaximized)
				Skye.Common.RegistryHelper.SetInt("StartLocationX", StartLocation.X)
				Skye.Common.RegistryHelper.SetInt("StartLocationY", StartLocation.Y)
				Skye.Common.RegistryHelper.SetInt("StartSizeW", StartSize.Width)
				Skye.Common.RegistryHelper.SetInt("StartSizeH", StartSize.Height)

				' Theme
				Skye.Common.RegistryHelper.SetString("Theme", Theme.Name)
				Skye.Common.RegistryHelper.SetBool("ThemeAuto", ThemeAuto)

				WriteToLog("Settings Saved (" & Skye.Common.GenerateLogTime(starttime, DateTime.Now.TimeOfDay, True) & ")", False)
			End Sub

		End Class

		' Handlers
		Private Sub OnThemeChanged(sender As Object, e As EventArgs)
			Skye.UI.ThemeManager.ApplyThemeToAllOpenForms()
		End Sub

		' Methods
		Friend Sub Initialize()
#If DEBUG Then
			Skye.Common.Log.Initialize(Application.Info.ProductName + "DEV") 'Use separate log file for debug builds
			Skye.Common.RegistryHelper.BaseKey = "Software\" + My.Application.Info.ProductName + "DEV" 'Use separate registry key for debug builds
#Else
            Skye.Common.Log.Initialize(My.Application.Info.ProductName) 'Initialize the log file
            Skye.Common.RegistryHelper.BaseKey = "Software\" + My.Application.Info.ProductName 'Use standard registry key for release builds
#End If
			WriteToLog(My.Application.Info.ProductName + " Started", False)
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance) 'Allows use of Windows-1252 character encoding, needed for Skye Library context menu Proper Case function.
			If My.Application.CommandLineArgs.Count > 0 Then
				WriteToLog("Processing CommandLine (" + My.Application.CommandLineArgs.Count.ToString + ")", False)
				ProcessPassedParameters(My.Application.CommandLineArgs)
			End If
			Settings.Load()
			If Settings.ThemeAuto Then
				Skye.UI.ThemeManager.SetTheme(Skye.UI.ThemeManager.DetectWindowsTheme())
			Else
				Skye.UI.ThemeManager.CurrentTheme = Settings.Theme
			End If
			AddHandler Skye.UI.ThemeManager.ThemeChanged, AddressOf OnThemeChanged
#If DEBUG Then
			tagPaths(0) = "C:\Users\YodeS\Dev\TESTDATA\AvrilLavigne Smile (Multiple Art).mp3"
#End If
			FrmMain = New MainForm
		End Sub
		Friend Sub Finalize()
			App.Settings.Save()
			My.App.WriteToLog(My.Application.Info.ProductName + " Closed", False)
		End Sub
		''' <summary>
		''' Sets the App Alert Mode and notifies the user.
		''' </summary>
		''' <param name="mode">Optional. True turns ON App Alert Mode and notifies the user. False turns OFF App Alert Mode and clears user notifications. Default is True.</param>
		Friend Sub ErrorNotification(Optional mode As Boolean = True)
			Select Case mode
				Case True
					AppAlert = True
					If FrmMain IsNot Nothing Then FrmMain.SetError()
				Case False
					If AppAlert Then
						AppAlert = False
						If FrmMain IsNot Nothing Then FrmMain.ClearError()
					End If
			End Select
			My.AppAlertMessage = String.Empty
		End Sub
		Friend Sub WriteToLog(logtext As String, Optional showfilename As Boolean = True)
			Dim finalText As String = logtext
			If showfilename Then
				If IsMultiFile Then
					finalText &= $" (Multiple Files ({tagPaths.Count}))"
				Else
					finalText &= $" ({If(String.IsNullOrEmpty(tagPath), sNoFile, tagPath)})"
				End If
			End If
			Skye.Common.Log.Write(finalText)
		End Sub
		Friend Sub ShowLog()
			If FrmLog Is Nothing Then
				FrmLog = New Log
				FrmLog.Text = My.Application.Info.ProductName + " " + FrmLog.Text
				FrmLog.Show()
			Else
				FrmLog.WindowState = FormWindowState.Normal
				FrmLog.BringToFront()
				FrmLog.Focus()
			End If
		End Sub
		Friend Sub DeleteLog()
			If IO.File.Exists(Skye.Common.Log.LogFilePath) Then IO.File.Delete(Skye.Common.Log.LogFilePath)
		End Sub
		Friend Sub ShowHelp()
			Dim logtext As String = String.Empty
			logtext += "Interface -->"
			logtext += vbCr + vbTab + "Hovering over the Filename will briefly show extended media information."
			logtext += vbCr + vbTab + "Clicking Insert On the Album Art Menu will perform the Default insertion behavior, Insert Last."
			logtext += vbCr + vbTab + "You may drag an image file Or files onto the Album Art Menu Button. The file Or files will be added Using the Default insertion behavior, Insert Last."
			logtext += vbCr + vbCr + "Settings -->"
			logtext += vbCr + vbTab + "Save Window Metrics will save the location Of the Main Window And its size Each time you Exit the App."
			logtext += vbCr + vbCr + "KeyBoard -->"
			logtext += vbCr + vbTab + "Pressing CtrlW will close a window without saving."
			logtext += vbCr + vbTab + "Pressing CtrlShiftW Or Escape will minimize the window."
			logtext += vbCr + vbTab + "Pressing F12 will toggle the window state."
			logtext += vbCr + vbCr + "Opening Files -->"
			logtext += vbCr + vbTab + "Because Of the way Windows works, 'Open With' from the Shell Context Menu only opens a single file. However, you may put a link to " + My.Application.Info.ProductName + ".exe in the 'SendTo' menu. This will allow you to open single or multiple files."
			logtext += vbCr + vbTab + "You may use the 'Open' button to open single or multiple files."
			logtext += vbCr + vbTab + "You may drag any file or files onto any part of the window, except the Album Art Menu Button."
			logtext += vbCr + vbTab + "You may open one or more files from the command line. For each file you wish to open, provide the full path to the file in quotation marks(" + My.Application.Info.ProductName + ".exe " + """" + "filepath" + """" + "). Separate each file with a single space(" + My.Application.Info.ProductName + ".exe " + """" + "filepath1" + """" + " " + """" + "filepath2" + """" + "). Make sure the path to " + My.Application.Info.ProductName + ".exe is set in the Windows Environment Variable 'Path'."
			FrmHelp = New Help
			FrmHelp.Text = My.Application.Info.ProductName + " " + FrmHelp.Text
			FrmHelp.RTxBoxHelp.Text = logtext
			FrmHelp.LblVersion.Text = "v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString + "." + My.Application.Info.Version.Build.ToString
			logtext = String.Empty
			FrmHelp.ShowDialog()
		End Sub
		Friend Sub ShowSettings()
			FrmSettings = New SkyeTag.Settings
			FrmSettings.ShowDialog()
		End Sub
		Friend Sub CloseSettings()
			If FrmSettings IsNot Nothing Then
				FrmSettings.Close()
				FrmSettings = Nothing
			End If
		End Sub
		Friend Sub OpenFileLocation(filename As String)
			Dim psi As New Diagnostics.ProcessStartInfo("EXPLORER.EXE") With {
				.Arguments = "/SELECT," + """" + filename + """"}
			Try
				Diagnostics.Process.Start(psi)
				WriteToLog("File Location Opened (" + filename + ")")
			Catch ex As Exception
				App.WriteToLog("Error Opening File Location (" + filename + ")" + vbCr + ex.Message)
			End Try
		End Sub
		Friend Sub ProcessPassedParameters(ByRef parameters As Collections.ObjectModel.ReadOnlyCollection(Of String))
			Try
				If String.IsNullOrEmpty(parameters(0)) Then : Throw New Exception
				Else
					tagPaths = parameters.ToList()
				End If
			Catch
				Dim commandlineparameters As String = String.Empty
				For Each s As String In parameters : commandlineparameters += IIf(String.IsNullOrEmpty(s), "<NULL>", s).ToString + " " : Next
				commandlineparameters = commandlineparameters.Trim(CType(" ", Char))
				App.WriteToLog("Invalid CommandLine Parameters (" + parameters.Count.ToString + ") : " + commandlineparameters)
				App.ErrorNotification()
			End Try
		End Sub
		Friend Sub PlayMedia()
			If Not String.IsNullOrEmpty(My.tagPath) Then
				Static psi As Diagnostics.ProcessStartInfo
				psi = New Diagnostics.ProcessStartInfo(My.tagPath) With {
					.UseShellExecute = True}
				Try : Diagnostics.Process.Start(psi)
				Catch
					My.App.WriteToLog("Error Playing Media")
					My.App.ErrorNotification()
				End Try
				psi = Nothing
			End If
		End Sub
		Friend Sub OpenSkyeTag(filename As String)
			Dim pInfo As New Diagnostics.ProcessStartInfo With {
				.UseShellExecute = False,
				.FileName = My.Application.Info.AssemblyName,
				.Arguments = """" + filename + """"}
			Diagnostics.Process.Start(pInfo)
			pInfo = Nothing
		End Sub
		Friend Function GetNewPic(picsource As ImageSource, Optional picpath As String = Nothing) As TagLib.IPicture
			Select Case picsource
				Case ImageSource.File
					If Not String.IsNullOrEmpty(picpath) AndAlso My.Computer.FileSystem.FileExists(picpath) Then : GetNewPic = New TagLib.Picture(picpath)
					Else : GetNewPic = Nothing
					End If
				Case ImageSource.SelectFile
					Dim ofd As New OpenFileDialog With {
						.Title = "Select An Image File",
						.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;*.png;*.tif;*.tiff"}
					Dim result As DialogResult = ofd.ShowDialog(FrmMain)
					If result = DialogResult.OK AndAlso Not String.IsNullOrEmpty(ofd.FileName) Then : GetNewPic = New TagLib.Picture(ofd.FileName)
					Else : GetNewPic = Nothing
					End If
					result = Nothing
					ofd.Dispose()
					ofd = Nothing
				Case ImageSource.SelectOnline
					Dim frmSelectOnline As New SelectOnlineImage
					frmSelectOnline.ShowDialog()
					If frmSelectOnline.DialogResult = DialogResult.OK Then
						GetNewPic = frmSelectOnline.NewPic
					Else
						GetNewPic = Nothing
					End If
					frmSelectOnline.Dispose()
				Case ImageSource.ClipBoard
					If My.Computer.Clipboard.ContainsImage Then
						Dim ms As New IO.MemoryStream
						My.Computer.Clipboard.GetImage.Save(ms, Drawing.Imaging.ImageFormat.Bmp)
						Dim bv As New TagLib.ByteVector(ms.ToArray)
						GetNewPic = New TagLib.Picture(bv)
						bv.Clear()
						bv = Nothing
						ms.Dispose()
						ms = Nothing
					Else : GetNewPic = Nothing
					End If
				Case Else
					GetNewPic = Nothing
			End Select
		End Function
		Friend Function HasImageFileExtension(s As String) As Boolean
			If s.EndsWith(".jpg", True, Nothing) _
			OrElse s.EndsWith(".jpeg", True, Nothing) _
			OrElse s.EndsWith(".bmp", True, Nothing) _
			OrElse s.EndsWith(".png", True, Nothing) _
			OrElse s.EndsWith(".tif", True, Nothing) _
			OrElse s.EndsWith(".tiff", True, Nothing) Then : Return True
			Else : Return False
			End If
		End Function
		''' <summary>
		'''Checks whether the Mouse Pointer is within the bounds of the Control. Useful for MouseUp Control Events so a user can 'wander' off the control, while holding the button down, without the event triggering.
		''' </summary>
		''' <param name="control">A reference to a Control.</param>
		''' <param name="mouseposition">A reference to the current Mouse Position, relative to the Control.</param>
		''' <returns>True if 'mouseposition' is within the bounds of 'control'; otherwise False.</returns>
		Friend Function MouseInBounds(ByRef control As Control, ByRef mouseposition As Point) As Boolean
			If mouseposition.X >= 0 AndAlso mouseposition.X <= control.Width AndAlso mouseposition.Y >= 0 AndAlso mouseposition.Y <= control.Height Then Return True
			Return False
		End Function
		Friend Function Blend(c1 As Color, c2 As Color, amount As Double) As Color
			' amount = how much of c2 to add in (0.0–1.0)
			Dim a = Math.Max(0.0, Math.Min(1.0, amount))
			Return Color.FromArgb(
				CInt(c1.R * (1 - a) + c2.R * a),
				CInt(c1.G * (1 - a) + c2.G * a),
				CInt(c1.B * (1 - a) + c2.B * a)
			)
		End Function

	End Module

End Namespace
