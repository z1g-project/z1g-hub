Imports System.Threading

Public Class ErrorHandler
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Cursor = Cursors.WaitCursor
        Thread.Sleep(3000)
        Me.Cursor = Cursors.Default
        Button5.Enabled = False
    End Sub
End Class