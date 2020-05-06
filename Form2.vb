Imports System.Net
Imports System.Net.Mail
Imports System.IO
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://pastebin.com/raw/BDYAUVVQ")
            Dim response As System.Net.HttpWebResponse = request.GetResponse
            Dim stream As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim page As String = stream.ReadToEnd
            If page.Contains("8ax") Then
            Else
                End
            End If

        Catch ex As Exception
            MsgBox("Error Internet", MsgBoxStyle.Exclamation, "")
            End
        End Try
        Dim hostname As String = Dns.GetHostName
        Dim ipaddress As String = CType(Dns.GetHostByName(hostname).AddressList.GetValue(0), IPAddress).ToString
        TextBox1.Text = ipaddress
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Pastebin As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://pastebin.com/raw/sNpRZMTT ")
        Dim GR As System.Net.HttpWebResponse = Pastebin.GetResponse
        Dim RE As System.IO.StreamReader = New System.IO.StreamReader(GR.GetResponseStream())
        Dim RD As String = RE.ReadToEnd
        Dim CN As String = RD
        If CN.Contains(TextBox1.Text) Then
            Me.Hide()
            Form1.Show()

        Else
            MsgBox("Your ip isn't Activated !
Please Contact The Programmer For Activation")
            End
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class