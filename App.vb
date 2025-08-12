
Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Namespace My

	Partial Friend Class MyApplication
		'App Declarations
		'App Events
		Public Sub New()
			MyBase.New(VisualBasic.ApplicationServices.AuthenticationMode.Windows)
			Me.IsSingleInstance = False
			Me.EnableVisualStyles = True
			Me.SaveMySettingsOnExit = False
			Me.ShutdownStyle = VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
		End Sub
		Protected Overrides Function OnStartup(e As ApplicationServices.StartupEventArgs) As Boolean
			If e.Cancel Then : Return False
			Else
				My.App.Initialize()
				Return True
			End If
		End Function
		Protected Overrides Sub OnCreateMainForm()
			Me.MainForm = My.App.frmMain
		End Sub
		'App Procedures
	End Class

	Friend Module App

		'Declarations
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
		Friend Class SettingsType
			Public Class DefaultsType
				Public ReadOnly StartLocation As New Point(80, 120)
				Public ReadOnly StartSize As New Size(400, 600)
				Public ReadOnly SaveMetrics As Boolean = False
			End Class
			Public Defaults As New DefaultsType
			Public NeedsSaved As Boolean = False
			Public MetricsNeedSaved As Boolean = False

			'Saved Settings
			Public StartLocation As Point
			Public StartSize As Size
			Public SaveMetrics As Boolean

		End Class
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
		Friend Settings As SettingsType
		Friend tagPath As String
		Friend tagArtistIndex As Integer
		Friend tagArtIndex As Integer
		Private RegKey As Microsoft.Win32.RegistryKey
		Friend frmMain As MainForm
		Friend FrmLog As Log
		Private FrmHelp As Help
		Private FrmSettings As Settings
		Friend Const AdjustScreenBoundsNormalWindow As Byte = 8
		Friend Const AdjustScreenBoundsDialogWindow As Byte = 10
		Friend Const sError As String = "Error Opening File"
		Friend Const sNoFile As String = "Media File Not Specified"
		Friend Const sNotFound As String = "File Does Not Exist"
		Friend Const sNotFile As String = "Folders Not Supported"
		Friend Const sBadFile As String = "Corrupt File"
		Friend Const sUnSupportedFile As String = "UnSupported File Type"
		Friend Const sUnAccessibleFile As String = "File Not Accessible"
		Friend Const hArtist As String = "Artist"
		Friend Const hArt As String = "Art"
#If DEBUG Then
        Friend ReadOnly PicPath As String = Computer.FileSystem.SpecialDirectories.Temp + "\" + Application.Info.ProductName + "DEV" 'PicPath is the path to the temporary image file.
        Friend ReadOnly LogPath As String = Computer.FileSystem.SpecialDirectories.Temp + "\" + Application.Info.ProductName + "LogDEV.txt" 'LogPath is the path to the log file.
		Private ReadOnly RegPath As String = "Software\\" + Application.Info.ProductName + "DEV" 'RegPath is the path to the registry key where application settings are stored.
#Else
		Friend ReadOnly PicPath As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\" + My.Application.Info.ProductName 'PicPath is the path to the temporary image file.
		Friend ReadOnly LogPath As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\" + My.Application.Info.ProductName + "Log.txt" 'LogPath is the path to the log file.
		Private ReadOnly RegPath As String = "Software\\" + My.Application.Info.ProductName 'RegPath is the path to the registry key where application settings are stored.
#End If

		'Procedures
		Friend Sub Initialize()
			WriteToLog(My.Application.Info.ProductName + " Started")
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance) 'Allows use of Windows-1252 character encoding, needed for Components context menu Proper Case function.
			If My.Application.CommandLineArgs.Count > 0 Then
				WriteToLog("Processing CommandLine (" + My.Application.CommandLineArgs.Count.ToString + ")", False)
				ProcessPassedParameters(My.Application.CommandLineArgs)
			End If
			GetSettings()
			frmMain = New MainForm
		End Sub
		Friend Sub Finalize()
			If Settings.NeedsSaved Then SaveSettings()
			If Settings.MetricsNeedSaved Then SaveMetrics()
			My.App.WriteToLog(My.Application.Info.ProductName + " Closed")
		End Sub
		Friend Sub GetSettings()
			Try
				Settings = New SettingsType
				RegKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegPath)
				Settings.StartLocation.X = CInt(Val(RegKey.GetValue("StartLocationX", Settings.Defaults.StartLocation.X.ToString)))
				Settings.StartLocation.Y = CInt(Val(RegKey.GetValue("StartLocationY", Settings.Defaults.StartLocation.Y.ToString)))
				Settings.StartSize.Width = CInt(Val(RegKey.GetValue("StartSizeX", Settings.Defaults.StartSize.Width.ToString)))
				Settings.StartSize.Height = CInt(Val(RegKey.GetValue("StartSizeY", Settings.Defaults.StartSize.Height.ToString)))
				Select Case RegKey.GetValue("SaveMetrics", Settings.Defaults.SaveMetrics.ToString).ToString
					Case "True", "1" : Settings.SaveMetrics = True
					Case Else : Settings.SaveMetrics = False
				End Select
#If DEBUG Then
				tagPath = "C:\Users\YodeS\Dev\TESTDATA\AvrilLavigne Smile (Multiple Art).mp3"
#End If
				Debug.Print("GetSettings")
				WriteToLog("Settings Retrieved", False)
			Catch ex As Exception
				WriteToLog("Error Retrieving Settings" + vbCr + ex.Message)
				ex = Nothing
			Finally
				RegKey.Close()
				RegKey.Dispose()
				RegKey = Nothing
			End Try
		End Sub
		Friend Sub SaveSettings()
			Try
				RegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegPath, True)
				RegKey.SetValue("SaveMetrics", Settings.SaveMetrics.ToString, Microsoft.Win32.RegistryValueKind.String)
				RegKey.Flush()
				Settings.NeedsSaved = False
				WriteToLog("Settings Saved", False)
			Catch ex As Exception
				WriteToLog("Error Saving Settings" + vbCr + ex.Message)
				ex = Nothing
			Finally
				RegKey.Close()
				RegKey.Dispose()
				RegKey = Nothing
			End Try
		End Sub
		Friend Sub SaveMetrics()
			If Settings.SaveMetrics AndAlso Settings.MetricsNeedSaved Then
				Try
					RegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegPath, True)
					RegKey.SetValue("StartLocationX", Settings.StartLocation.X.ToString, Microsoft.Win32.RegistryValueKind.String)
					RegKey.SetValue("StartLocationY", Settings.StartLocation.Y.ToString, Microsoft.Win32.RegistryValueKind.String)
					RegKey.SetValue("StartSizeX", Settings.StartSize.Width.ToString, Microsoft.Win32.RegistryValueKind.String)
					RegKey.SetValue("StartSizeY", Settings.StartSize.Height.ToString, Microsoft.Win32.RegistryValueKind.String)
					RegKey.Flush()
					Settings.MetricsNeedSaved = False
					WriteToLog("Metrics Saved", False)
				Catch ex As Exception
					WriteToLog("Error Saving Metrics" + vbCr + ex.Message)
					ex = Nothing
				Finally
					RegKey.Close()
					RegKey.Dispose()
					RegKey = Nothing
				End Try
			End If
		End Sub
		''' <summary>
		''' Sets the App Alert Mode and notifies the user.
		''' </summary>
		''' <param name="mode">Optional. True turns ON App Alert Mode and notifies the user. False turns OFF App Alert Mode and clears user notifications. Default is True.</param>
		Friend Sub ErrorNotification(Optional mode As Boolean = True)
			Select Case mode
				Case True
					AppAlert = True
					If Not frmMain Is Nothing Then frmMain.SetError()
				Case False
					If AppAlert Then
						AppAlert = False
						If Not frmMain Is Nothing Then frmMain.ClearError()
					End If
			End Select
			My.AppAlertMessage = String.Empty
		End Sub
		''' <summary>
		''' Writes Text To The Log File
		''' </summary>
		''' <param name="logtext">Text to be written.</param>
		''' <param name="showfilename">Optional. True = Show [tagPath] after the Text, False = DO NOT Show [tagPath], Default = True.</param>
		Friend Sub WriteToLog(logtext As String, Optional showfilename As Boolean = True)
			Static fInfo As IO.FileInfo
			Try
				fInfo = New IO.FileInfo(LogPath)
				If fInfo.Exists AndAlso fInfo.Length >= 1000000 Then IO.File.Move(LogPath, LogPath.Insert(LogPath.Length - 4, "Backup@" + My.Computer.Clock.LocalTime.ToString("yyyyMMdd") + "@" + My.Computer.Clock.LocalTime.ToString("HHmmss")))
				IO.File.AppendAllText(LogPath, IIf(String.IsNullOrEmpty(logtext), String.Empty, My.Computer.Clock.LocalTime.ToString("yyyy/MM/dd") + " @ " + My.Computer.Clock.LocalTime.ToString("HH:mm:ss") + " --> " + logtext + IIf(showfilename, " (" + IIf(String.IsNullOrEmpty(tagPath), sNoFile, tagPath).ToString + ")", String.Empty).ToString + Chr(13)).ToString)
				Debug.Print("WriteToLog: " & IIf(String.IsNullOrEmpty(logtext), String.Empty, logtext + IIf(showfilename, " (" + IIf(String.IsNullOrEmpty(tagPath), sNoFile, tagPath).ToString + ")", String.Empty).ToString).ToString)
			Catch
			Finally : fInfo = Nothing
			End Try
		End Sub
		Friend Sub ShowLog()

			'Set Form
			If FrmLog Is Nothing Then
				FrmLog = New Log
				FrmLog.Text = My.Application.Info.ProductName + " " + FrmLog.Text
				FrmLog.Show()
			Else
				FrmLog.WindowState = FormWindowState.Normal
				FrmLog.BringToFront()
				FrmLog.Focus()
			End If

			'Show Log
			Dim logtext As String = String.Empty
			Dim lines As Integer = 0
			FrmLog.RTxBoxLog.Clear()
			Try : logtext = IO.File.ReadAllText(LogPath)
			Catch
			Finally
				If String.IsNullOrEmpty(logtext) Then logtext = "Log Empty"
				FrmLog.RTxBoxLog.AppendText(logtext)
				FrmLog.Lblnfo.Text = LogPath
				If FrmLog.RTxBoxLog.Lines.Length > 0 AndAlso FrmLog.RTxBoxLog.Lines(0).Length > 0 Then lines = FrmLog.RTxBoxLog.GetLineFromCharIndex(FrmLog.RTxBoxLog.Text.Length)
				FrmLog.Lblnfo.Text += " (" + lines.ToString + IIf(lines = 1, " Line", " Lines").ToString + ")"
				If lines > 0 Then
					FrmLog.BtnDelete.Visible = True
					FrmLog.btnRefresh.Visible = True
					FrmLog.RTxBoxLog.ScrollToCaret()
				Else
					FrmLog.BtnDelete.Visible = False
				End If
				FrmLog.RTxBoxLog.ReadOnly = True
				FrmLog.BtnClose.Select()
			End Try

		End Sub
		Friend Sub DeleteLog()
			If IO.File.Exists(LogPath) Then IO.File.Delete(LogPath)
			ShowLog()
		End Sub
		Friend Sub ShowHelp()
			Dim logtext As String = String.Empty
			logtext += "Interface -->"
			logtext += vbCr + vbTab + "Hovering over the App Button will briefly show extended media information. RightClick on the App Button will show extended media information in a balloon until closed by the user."
			logtext += vbCr + vbTab + "Clicking Insert on the Album Art Menu will perform the default insertion behavior, Insert Last."
			logtext += vbCr + vbTab + "You may drag an image file or files onto the Album Art Menu Button. The file or files will be added using the default insertion behavior, Insert Last."
			logtext += vbCr + vbCr + "Settings -->"
			logtext += vbCr + vbTab + "AutoSave Main Window Location will save the location of the Main Window each time you exit the App."
			logtext += vbCr + vbTab + "If you set AutoSave Main Window Location, but do not Save Settings, the location of the Main Window will be saved only the next time you exit the App. This, and the Save Current Location button, are useful if you want to change the startup location of the App permanently."
			logtext += vbCr + vbCr + "KeyBoard -->"
			logtext += vbCr + vbTab + "Pressing CtrlW will close a window without saving."
			logtext += vbCr + vbTab + "Pressing CtrlShiftW or Escape will minimize the window."
			logtext += vbCr + vbTab + "Pressing F12 will toggle the window state."
			logtext += vbCr + vbCr + "Opening Files -->"
			logtext += vbCr + vbTab + "Because of the way Windows works, 'Open With' from the Shell Context Menu only opens a single file. However, you may put a link to " + My.Application.Info.ProductName + ".exe in the 'SendTo' menu. This will allow you to open single or multiple files."
			logtext += vbCr + vbTab + "You may use the 'Open' button to open single or multiple files."
			logtext += vbCr + vbTab + "You may drag any file or files onto any other part of the window. A single file will be loaded in the current window. Additional files will be loaded into separate windows."
			logtext += vbCr + vbTab + "You may open one or more files from the command line. For each file you wish to open, provide the full path to the file in quotation marks(" + My.Application.Info.ProductName + ".exe " + """" + "filepath" + """" + "). Separate each file with a single space(" + My.Application.Info.ProductName + ".exe " + """" + "filepath1" + """" + " " + """" + "filepath2" + """" + "). Make sure the path to " + My.Application.Info.ProductName + ".exe is set in the Windows Environment Variable 'Path'."
			logtext += vbCr + vbTab + "Regardless of method used, a maximum of ten files can be opened at one time to keep from overloading the system. Each file over ten will be ignored."
			FrmHelp = New Help
			FrmHelp.Text = My.Application.Info.ProductName + " " + FrmHelp.Text
			FrmHelp.RTxBoxHelp.Text = logtext
			FrmHelp.LblVersion.Text = "v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
			logtext = String.Empty
			FrmHelp.ShowDialog()
		End Sub
		Friend Sub ShowSettings()
			FrmSettings = New Settings
			FrmSettings.ShowDialog()
		End Sub
		Friend Sub CloseSettings()
			If FrmSettings IsNot Nothing Then
				FrmSettings.Close()
				FrmSettings = Nothing
			End If
		End Sub
		Friend Sub OpenFileLocation(filename As String)
			Dim psi As New Diagnostics.ProcessStartInfo("EXPLORER.EXE")
			psi.Arguments = "/SELECT," + """" + filename + """"
			Try
				Diagnostics.Process.Start(psi)
				WriteToLog("File Location Opened (" + filename + ")")
			Catch ex As Exception
				App.WriteToLog("Error Opening File Location (" + filename + ")" + vbCr + ex.Message)
			Finally
				psi = Nothing
			End Try
		End Sub
		Friend Sub ProcessPassedParameters(ByRef parameters As Collections.ObjectModel.ReadOnlyCollection(Of String))
			Try
				If String.IsNullOrEmpty(parameters(0)) Then : Throw New Exception
				Else
					tagPath = parameters(0)
					Select Case parameters.Count
						Case 2 To 10
							For index As Integer = 1 To parameters.Count - 1
								If String.IsNullOrEmpty(parameters(index)) Then : Throw New Exception
								Else : App.OpenSkyeTag(parameters(index))
								End If
							Next
						Case > 10
							App.WriteToLog("Too Many Parameters, Opening First 10 Only", False)
							For index As Integer = 1 To 9
								If String.IsNullOrEmpty(parameters(index)) Then : Throw New Exception
								Else
									App.OpenSkyeTag(parameters(index))
									Threading.Thread.Sleep(500)
								End If
							Next
					End Select
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
				psi = New Diagnostics.ProcessStartInfo(My.tagPath)
				psi.UseShellExecute = True
				Try : Diagnostics.Process.Start(psi)
				Catch
					My.App.WriteToLog("Error Playing Media")
					My.App.ErrorNotification()
				End Try
				psi = Nothing
			End If
		End Sub
		Friend Sub OpenSkyeTag(filename As String)
			Dim pInfo As New Diagnostics.ProcessStartInfo
			pInfo.UseShellExecute = False
			pInfo.FileName = My.Application.Info.AssemblyName
			pInfo.Arguments = """" + filename + """"
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
					Dim ofd As New OpenFileDialog
					ofd.Title = "Select An Image File"
					ofd.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;*.png;*.tif;*.tiff"
					Dim result As DialogResult = ofd.ShowDialog(frmMain)
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
		Friend Function FormatFileSize(filesizeinbytes As Long, unit As FormatFileSizeUnits, Optional decimalDigits As Integer = 2, Optional omitThousandSeparators As Boolean = False) As String 'Converts a number of bytes into Kbytes, Megabytes, or Gigabytes
			'Simple Error Checking
			If filesizeinbytes <= 0 Then Return "0 B"
			'Auto-Select Best Units Of Measure
			If unit = FormatFileSizeUnits.Auto Then
				Select Case filesizeinbytes
					Case Is < 1023
						unit = FormatFileSizeUnits.Bytes
						decimalDigits = 0
					Case Is < 1024 * 1023 : unit = FormatFileSizeUnits.KiloBytes
					Case Is < 1048576 * 1023 : unit = FormatFileSizeUnits.MegaBytes
					Case Else : unit = FormatFileSizeUnits.GigaBytes
				End Select
			End If
			'Evaluate The Decimal Value
			Dim value As Decimal
			Dim suffix As String = ""
			Select Case unit
				Case FormatFileSizeUnits.Bytes
					value = CDec(filesizeinbytes)
					suffix = " B"
				Case FormatFileSizeUnits.KiloBytes
					value = CDec(filesizeinbytes / 1024)
					suffix = " KB"
				Case FormatFileSizeUnits.MegaBytes
					value = CDec(filesizeinbytes / 1048576)
					suffix = " MB"
				Case FormatFileSizeUnits.GigaBytes
					value = CDec(filesizeinbytes / 1073741824)
					suffix = " GB"
			End Select
			'Get The String Representation
			Dim format As String
			If omitThousandSeparators Then : format = "F" & decimalDigits.ToString
			Else : format = "N" & decimalDigits.ToString
			End If
			Return value.ToString(format) & suffix
		End Function

	End Module

End Namespace
