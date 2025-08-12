
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports SkyeTag.My

Public Class SelectOnlineImage

    'Declarations
    Private NetClient As New System.Net.Http.HttpClient
    Private MBQuery As New MetaBrainz.MusicBrainz.Query(NetClient)
    Private MBArt As New MetaBrainz.MusicBrainz.CoverArt.CoverArt(NetClient)
    Private MBImageFront As MetaBrainz.MusicBrainz.CoverArt.CoverArtImage = Nothing
    Private MBImageBack As MetaBrainz.MusicBrainz.CoverArt.CoverArtImage = Nothing
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Friend ReadOnly Property NewPic As TagLib.IPicture
        Get
            Return selectedpic
        End Get
    End Property
    Private query As String = String.Empty
    Private selectedpic As TagLib.IPicture = Nothing
    Private mMove As Boolean = False
    Private mOffset, mPosition As Point

    'Form Events
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            If m.Msg = My.WinAPI.WM_SYSCOMMAND AndAlso m.WParam.ToInt32 = My.WinAPI.SC_CLOSE Then
                DialogResult = DialogResult.Cancel
            End If
        Catch ex As Exception
            My.App.WriteToLog("SelectImageOnline WndProc Handler Error" + Chr(13) + ex.ToString)
        Finally
            MyBase.WndProc(m)
        End Try
    End Sub
    Private Sub Frm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        query = App.frmMain.txbxArtist.Text + " " + frmMain.txbxAlbum.Text
        If query = " " Then query = String.Empty
        TxtBoxSearchPhrase.Text = query
        Search()
    End Sub
    Private Sub SelectOnlineImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MBArt.Dispose()
        MBQuery.Dispose()
        NetClient.Dispose()
    End Sub
    Private Sub Frm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, PicBoxArt.MouseDown, PicBoxFrontThumb.MouseDown, PicBoxBackThumb.MouseDown, LblDimBack.MouseDown, LblStatus.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso WindowState = FormWindowState.Normal Then
            mMove = True
            cSender = DirectCast(sender, Control)
            If cSender Is PicBoxArt OrElse cSender Is PicBoxFrontThumb OrElse cSender Is PicBoxBackThumb OrElse cSender Is LblDimFront OrElse cSender Is LblDimBack OrElse cSender Is LblStatus Then
                mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            Else
                mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            End If
        End If
        'cSender = Nothing
    End Sub
    Private Sub Frm_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove, PicBoxArt.MouseMove, PicBoxFrontThumb.MouseMove, PicBoxBackThumb.MouseMove, LblDimBack.MouseMove, LblStatus.MouseMove
        If mMove Then
            mPosition = MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            CheckMove(mPosition)
            Location = mPosition
        End If
    End Sub
    Private Sub Frm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp, PicBoxArt.MouseUp, PicBoxFrontThumb.MouseUp, PicBoxBackThumb.MouseUp, LblDimBack.MouseUp, LblStatus.MouseUp
        mMove = False
    End Sub
    Private Sub Frm_Move(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then CheckMove(Me.Location)
    End Sub
    Private Sub Frm_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick, PicBoxArt.DoubleClick
        ToggleMaximized()
    End Sub

    'Control Events
    Private Sub TxtBoxSearchPhrase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBoxSearchPhrase.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            e.Handled = True
            Validate()
        End If
    End Sub
    Private Sub TxtBoxSearchPhrase_Validated(sender As Object, e As EventArgs) Handles TxtBoxSearchPhrase.Validated
        LVIDs.Focus()
        If Not query = TxtBoxSearchPhrase.Text.Trim Then
            query = TxtBoxSearchPhrase.Text.Trim
            Search()
        End If
    End Sub
    Private Sub LVIDs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LVIDs.SelectedIndexChanged
        If LVIDs.SelectedItems.Count > 0 Then
            LVIDs.Enabled = False
            LblStatus.Visible = True
            LblDimFront.Text = String.Empty
            LblDimBack.Text = String.Empty
            PicBoxArt.Image = Nothing
            PicBoxFrontThumb.Image = Nothing
            PicBoxBackThumb.Image = Nothing
            BtnSaveArt.Enabled = False
            Refresh()
            Try
                MBImageFront = MBArt.FetchFront(Guid.Parse(LVIDs.SelectedItems(0).Tag.ToString))
                PicBoxArt.Image = New Bitmap(MBImageFront.Data)
                PicBoxFrontThumb.Image = New Bitmap(MBImageFront.Data)
                'selectedpic = New TagLib.Picture(DirectCast(MBImageFront.Data, MemoryStream).ToArray)
                Dim ms As New MemoryStream
                PicBoxArt.Image.Save(ms, ImageFormat.Jpeg)
                selectedpic = New TagLib.Picture(ms.ToArray())
                ms.Dispose()
                LblDimFront.Text = PicBoxFrontThumb.Image.Width.ToString + " x " + PicBoxFrontThumb.Image.Height.ToString
                BtnSaveArt.Enabled = True
            Catch ex As MetaBrainz.Common.HttpError
            End Try
            Try
                MBImageBack = MBArt.FetchBack(Guid.Parse(LVIDs.SelectedItems(0).Tag.ToString))
                PicBoxBackThumb.Image = New Bitmap(MBImageBack.Data)
                LblDimBack.Text = PicBoxBackThumb.Image.Width.ToString + " x " + PicBoxBackThumb.Image.Height.ToString
            Catch ex As MetaBrainz.Common.HttpError
            End Try
            LblStatus.Visible = False
            LVIDs.Enabled = True
            LVIDs.Select()
        End If
    End Sub
    Private Sub LVIDs_SizeChanged(sender As Object, e As EventArgs) Handles LVIDs.SizeChanged
        LVIDs.Columns(0).Width = LVIDs.Width - SystemInformation.VerticalScrollBarWidth - 4
    End Sub
    Private Sub PicBoxFrontThumb_Click(sender As Object, e As EventArgs) Handles PicBoxFrontThumb.Click
        If MBImageFront IsNot Nothing Then
            PicBoxArt.Image = New Bitmap(MBImageFront.Data)
            'selectedpic = New TagLib.Picture(DirectCast(MBImageFront.Data, MemoryStream).ToArray)
            Dim ms As New MemoryStream
            PicBoxArt.Image.Save(ms, ImageFormat.Jpeg)
            selectedpic = New TagLib.Picture(ms.ToArray())
            ms.Dispose()
        End If
    End Sub
    Private Sub PicBoxBackThumb_Click(sender As Object, e As EventArgs) Handles PicBoxBackThumb.Click
        If MBImageBack IsNot Nothing Then
            PicBoxArt.Image = New Bitmap(MBImageBack.Data)
            'selectedpic = New TagLib.Picture(DirectCast(MBImageBack.Data, MemoryStream).ToArray)
            Dim ms As New MemoryStream
            PicBoxArt.Image.Save(ms, ImageFormat.Jpeg)
            selectedpic = New TagLib.Picture(ms.ToArray())
            ms.Dispose()
        End If
    End Sub
    Private Sub BtnSaveArt_Click(sender As Object, e As EventArgs) Handles BtnSaveArt.Click
        Dim frmSaveOnlineImage As New SaveOnlineImage
        frmSaveOnlineImage.PicBoxThumb.Image = PicBoxArt.Image
        frmSaveOnlineImage.ShowDialog()
        If frmSaveOnlineImage.DialogResult = DialogResult.OK Then
            Select Case frmSaveOnlineImage.GetFilename
                Case String.Empty
                    'Do nothing, user cancelled
                Case Else
                    If PicBoxArt.Image IsNot Nothing Then
                        Dim ext As String = Path.GetExtension(frmSaveOnlineImage.GetFilename).ToLowerInvariant()
                        Select Case ext
                            Case ".jpg", ".jpeg"
                                PicBoxArt.Image.Save(frmSaveOnlineImage.GetFilename, ImageFormat.Jpeg)
                            Case ".png"
                                PicBoxArt.Image.Save(frmSaveOnlineImage.GetFilename, ImageFormat.Png)
                            Case ".bmp"
                                PicBoxArt.Image.Save(frmSaveOnlineImage.GetFilename, ImageFormat.Bmp)
                        End Select
                        App.WriteToLog("Saved cover art to " + frmSaveOnlineImage.GetFilename, False)
                    End If
            End Select
        End If
        frmSaveOnlineImage.Dispose()
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    'Procedures
    Private Sub Search()
        If Not String.IsNullOrEmpty(query) Then
            LVIDs.Enabled = False
            LVIDs.Items.Clear()
            LblDimFront.Text = String.Empty
            LblDimBack.Text = String.Empty
            PicBoxArt.Image = Nothing
            PicBoxFrontThumb.Image = Nothing
            PicBoxBackThumb.Image = Nothing
            BtnSaveArt.Enabled = False
            Dim results As MetaBrainz.MusicBrainz.Interfaces.Searches.ISearchResults(Of MetaBrainz.MusicBrainz.Interfaces.Searches.ISearchResult(Of MetaBrainz.MusicBrainz.Interfaces.Entities.IRelease)) = MBQuery.FindReleases(query)
            For Each result As MetaBrainz.MusicBrainz.Interfaces.Searches.ISearchResult(Of MetaBrainz.MusicBrainz.Interfaces.Entities.IRelease) In results.Results
                Dim lvitem As New ListViewItem
                lvitem.Tag = result.Item.Id.ToString
                lvitem.SubItems(0).Text = result.Item.ArtistCredit(0).Artist.Name.ToString
                lvitem.SubItems(0).Text += ", " + result.Item.Title
                LVIDs.Items.Add(lvitem)
            Next
            LVIDs.Enabled = True
            LVIDs.Select()
        End If
    End Sub
    Private Sub ToggleMaximized()
        Select Case WindowState
            Case FormWindowState.Normal
                WindowState = FormWindowState.Maximized
            Case FormWindowState.Maximized, FormWindowState.Minimized
                WindowState = FormWindowState.Normal
        End Select
    End Sub
    Private Sub CheckMove(ByRef location As Point)
        If location.X + Width > My.Computer.Screen.WorkingArea.Right Then location.X = My.Computer.Screen.WorkingArea.Right - Width + App.AdjustScreenBoundsDialogWindow
        If location.Y + Height > My.Computer.Screen.WorkingArea.Bottom Then location.Y = My.Computer.Screen.WorkingArea.Bottom - Height + App.AdjustScreenBoundsDialogWindow
        If location.X < My.Computer.Screen.WorkingArea.Left Then location.X = My.Computer.Screen.WorkingArea.Left - App.AdjustScreenBoundsDialogWindow
        If location.Y < App.AdjustScreenBoundsDialogWindow Then location.Y = My.Computer.Screen.WorkingArea.Top
    End Sub

End Class
