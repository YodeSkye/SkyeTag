
Namespace My

    Partial Friend Class MyApplication

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

    End Class

End Namespace
