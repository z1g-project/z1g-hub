Imports System.Runtime.InteropServices

Public Class Form1

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Visible = True
        Label5.Visible = False
        Label6.Visible = False
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        If ProgressBar1.Value = 25 Then
            Label4.Visible = False
            Label5.Visible = True
        End If
        If ProgressBar1.Value = 75 Then
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = True
            CheckforUpdates()
        End If

        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            Form2.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub CheckforUpdates()
        Dim remoteVersionUrl As String = "https://cdn.z1g-project.repl.co/z1g-hub/ver.txt"
        Dim webClient As New System.Net.WebClient()
        Dim remoteVersion As String = webClient.DownloadString(remoteVersionUrl)

        Dim currentVersion As String = My.Application.Info.Version.ToString()

        If remoteVersion = currentVersion Then
            Timer1.Stop()
            Me.Hide()
            updater.Show()
        Else

        End If
    End Sub
End Class
