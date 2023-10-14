Imports System.Runtime.InteropServices
Imports CefSharp

Public Class NewsDiag
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HT_CAPTION As Integer = &H2

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ChromiumWebBrowser1.Stop
        ChromiumWebBrowser1.Load("about:blank")
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ChromiumWebBrowser1_LoadingStateChanged(sender As Object, e As LoadingStateChangedEventArgs) Handles ChromiumWebBrowser1.LoadingStateChanged
        If e.IsLoading = False Then
            Me.Invoke(Sub()
                          PictureBox2.Visible = False
                          Label2.Visible = False
                      End Sub)
        Else
            Me.Invoke(Sub()
                          PictureBox2.Visible = True
                          Label2.Visible = True
                      End Sub)
        End If
    End Sub

End Class