Imports System.Net
Imports System.Runtime.InteropServices
Imports Newtonsoft.Json.Linq

Public Class Form2
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

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        fetchNews()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Visible = False
        Panel2.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button4.Visible = True
        Panel2.Visible = False
    End Sub

    Private Sub fetchNews()
        Try
            ServicePointManager.ServerCertificateValidationCallback = Function() True

            Dim webClient As New WebClient()
            Dim json As String = webClient.DownloadString("https://cdn.z1g-project.repl.co/z1g-hub/newsdata.json")
            Dim newsData As JArray = JArray.Parse(json)

            If newsData.Count >= 3 Then
                Dim newsItem1 = newsData(0)
                Label16.Text = newsItem1("title").ToString()
                PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox2.ImageLocation = newsItem1("image").ToString()

                Dim newsItem2 = newsData(1)
                Label14.Text = newsItem2("title").ToString()
                PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox4.ImageLocation = newsItem2("image").ToString()

                Dim newsItem3 = newsData(2)
                Label15.Text = newsItem3("title").ToString()
                PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
                PictureBox3.ImageLocation = newsItem3("image").ToString()
            End If
        Catch ex As Exception
            ErrorHandler.Button5.Enabled = True
            ErrorHandler.Label3.Text = ex.Message
            Me.Hide()
            ErrorHandler.Show()
            Me.Show()
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        NewsDiag.show
        NewsDiag.chromiumwebbrowser1.load("https://cdn.z1g-project.repl.co/z1g-hub/news1.html")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        NewsDiag.Show()
        NewsDiag.ChromiumWebBrowser1.Load("https://cdn.z1g-project.repl.co/z1g-hub/news2.html")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        NewsDiag.Show()
        NewsDiag.ChromiumWebBrowser1.Load("https://cdn.z1g-project.repl.co/z1g-hub/news3.html")
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        NewsDiag.Show()
        NewsDiag.ChromiumWebBrowser1.Load("https://cdn.z1g-project.repl.co/z1g-hub/news3.html")
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        NewsDiag.Show()
        NewsDiag.ChromiumWebBrowser1.Load("https://cdn.z1g-project.repl.co/z1g-hub/news2.html")
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        NewsDiag.Show()
        NewsDiag.ChromiumWebBrowser1.Load("https://cdn.z1g-project.repl.co/z1g-hub/news1.html")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Panel3.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = False
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Panel3.Visible = True
        Panel4.Visible = True
        Panel5.Visible = True
        Panel6.Visible = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
    End Sub
End Class