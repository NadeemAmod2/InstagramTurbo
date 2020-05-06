Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic.CompilerServices

Public Class Form1

    Private HWID As String
    Public accSettings As String
    Public GetSettingsBool As Boolean
    Public IfLoggedIn As Boolean
    Private intt As Integer
    Public IsChanged As Boolean
    Public list As Object
    Public lThreads As Object
    Public mpp As Integer
    Public numis As String
    Public numToDone As Integer
    Public once As Integer
    Public Sessionz As CookieContainer
    Public stopp As Boolean
    Public SwitchLoginBool As Boolean
    Public Shared TellMe As Boolean = False
    Private Shared usernum As String()
    Public uuID As String
    Public inputt As String
    Public Lst As ListBox
    Public llbl As Label
    Dim i As Boolean
    Dim x As Integer
    Dim y As Integer

    Friend Delegate Sub VBAnonymousDelegate_0()

    Public Sub New()
        Me.HWID = ""
        Me.mpp = 0
        Me.stopp = False
        Me.once = 0
        Me.uuID = Guid.NewGuid().ToString().ToUpper()
        Me.lThreads = New List(Of Thread)()
        Me.IfLoggedIn = False
        Me.SwitchLoginBool = False
        Me.GetSettingsBool = False
        Me.IsChanged = False
        Me.numis = Nothing
        Me.numToDone = 0
        Me.InitializeComponent()
    End Sub


    Public Sub Starting(c As Integer)
        Dim flag As Boolean = Operators.ConditionalCompareObjectGreater(c, RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Operators.SubtractObject(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.TextBox4.Text)), Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing)))), 1)))), False)
        If flag Then
            c = Conversions.ToInteger(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Operators.SubtractObject(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.TextBox4.Text)), Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing)))), 1)))))
            Me.TurboThreads.Text = Conversions.ToString(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.TextBox4.Text)), Nothing, "length", New Object(-1) {}, Nothing, Nothing, Nothing))))))
        End If
        Form1.usernum = New String(c + 1 - 1 + 1 - 1 + 1 - 1) {}
        Dim num As Integer = Form1.usernum.Length - 1
        For i As Integer = 0 To num
            Form1.usernum(i) = ""
            Dim thread As New Thread(New ParameterizedThreadStart(AddressOf Me._Lambda__3), 1)
            thread.Start(i)
        Next
        While True
            Try
                flag = Not Me.stopp
                If flag Then
                    Dim num2 As Integer = Form1.usernum.Length - 1
                    For j As Integer = 0 To num2
                        flag = (Form1.usernum(j).Length <= 0)
                        If flag Then
                            Dim flag2 As Boolean = Operators.ConditionalCompareObjectGreater(Me.intt, RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Operators.SubtractObject(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.TextBox4.Text)), Nothing, "Length", New Object(-1) {}, Nothing, Nothing, Nothing)))), 1)))), False)
                            If flag2 Then
                                Me.intt = 0
                                Me.checkerTaken.Clear()
                            End If
                            Form1.usernum(j) = Conversions.ToString(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.TextBox4.Text)), New Object() {Me.intt}, Nothing)))))
                            Me.intt += 1
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
            Thread.Sleep(TurboSleep.Text)
        End While
    End Sub

    Public Function MoveUsername(Username As String) As Object
        Dim result As Object = False
        Try
            Dim text As String = Guid.NewGuid().ToString().ToUpper()
            Dim stringBuilder As StringBuilder = New StringBuilder()
            Dim stringBuilder2 As StringBuilder = stringBuilder
            Dim array As String() = Me.accSettings.Split(New Char() {"|"c})
            Dim text2 As String = String.Concat(New String() {"{""_uid"":""", array(0), """,""_csrftoken"":""missing"",""first_name"":""", array(1), """,""is_private"":""", array(2), """,""phone_number"":""", array(3), """,""biography"":""", array(4), """,""username"":""", Me.Tok.Text, """,""gender"":""", array(5), """,""email"":""", array(6), """,""_uuid"":""", text, """,""external_url"":""", array(7), """}"})
            text2 = String.Format("{0}.{1}", Form1.Sha256_hash(text2, "5ad7d6f013666cc93c88fc8af940348bd067b68f0dce3c85122a923f4f74b251"), text2)
            stringBuilder2.AppendLine("signed_body=" + WebUtility.UrlEncode(text2) + "&ig_sig_key_version=5")
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(stringBuilder.ToString())
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/"), HttpWebRequest)
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip
            httpWebRequest.Method = "POST"
            httpWebRequest.Host = "i.instagram.com"
            httpWebRequest.UserAgent = "Instagram 7.9.1 Android (18/4.3; 320dpi; 720x1280; Xiaomi; HM 1SW; armani; qcom; en_US)"
            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
            httpWebRequest.Headers.Add("Accept-Language", "ar;q=1, en;q=0.9")
            httpWebRequest.KeepAlive = True
            httpWebRequest.ContentLength = CLng(bytes.Length)
            httpWebRequest.CookieContainer = Me.Sessionz
            Dim requestStream As Stream = httpWebRequest.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
            Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
                If streamReader.ReadToEnd().Contains("""status"": ""ok""") Then
                    result = True
                End If
                streamReader.Close()
            End Using
            httpWebResponse.Close()
        Catch expr_253 As Exception
            ProjectData.SetProjectError(expr_253)
            result = False
            ProjectData.ClearProjectError()
        End Try
        Return result
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        ThreadPool.SetMinThreads(Integer.MaxValue, Integer.MaxValue)
        ServicePointManager.DefaultConnectionLimit = Integer.MaxValue
        Me.Username.[Select]()
        Me.Width = 94
        Me.CenterToParent()
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Public Sub Successfully(i As Integer)
        Try
            While Not Me.stopp
                Dim flag As Boolean = Form1.usernum(i).Length > 0
                If flag Then
                    Dim text As String = Form1.usernum(i)
                    Form1.usernum(i) = ""
                    flag = Operators.ConditionalCompareObjectEqual(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.Scan(Me.Tok.Text)))))))), True, False)
                    If flag Then
                        Dim flag2 As Boolean = Me.once = 0
                        If flag2 Then
                            Dim flag3 As Boolean = Operators.ConditionalCompareObjectEqual(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(Me.MoveUsername(Me.Tok.Text)))))))), True, False)
                            If flag3 Then
                                Me.once += 1
                                flag3 = Not Me.stopp
                                If flag3 Then
                                    Me.stopp = True
                                    Me.numis = text
                                    Me.loginButton.Text = "Available !"
                                    loginButton.ForeColor = Color.Red
                                    Me.checkerAvailable.AppendText(Me.Tok.Text + vbCrLf)
                                    MsgBox("This username @" & Tok.Text & " Has Been Raped !
- By The King @speedUp !
- Try Again Later Bitches", MsgBoxStyle.Information, "#speedUp")
                                    Thread.CurrentThread.Abort()
                                End If
                            Else
                                Me.checkerAvailable.AppendText(Me.Tok.Text + vbCrLf)
                            End If
                        End If
                    Else
                        Me.checkerTaken.AppendText(Me.Tok.Text + vbCrLf)
                    End If
                End If
                Thread.Sleep(1)
            End While
        Catch ex As Exception
        End Try
    End Sub

    Public Function Scan(e As String) As Object
        Dim result As Object = False
        Application.DoEvents()
        Try
            Guid.NewGuid().ToString().ToUpper()
            Me.accSettings.Split(New Char() {"|"c})
            Dim str As String = Guid.NewGuid().ToString().ToUpper()
            Dim stringBuilder As StringBuilder = New StringBuilder()
            Dim stringBuilder2 As StringBuilder = stringBuilder
            Dim text As String = String.Concat(New String() {""})
            text = String.Format("{0}.{1}", Form1.Sha256_hash(text, "5ad7d6f013666cc93c88fc8af940348bd067b68f0dce3c85122a923f4f74b251"), text)
            stringBuilder2.AppendLine("--" + str)
            stringBuilder2.AppendLine("Content-Disposition: form-data; name=""signed_body""")
            stringBuilder2.AppendLine()
            stringBuilder2.AppendLine(text)
            stringBuilder2.AppendLine("--" + str)
            stringBuilder2.AppendLine("Content-Disposition: form-data; name=""ig_sig_key_version""")
            stringBuilder2.AppendLine()
            stringBuilder2.AppendLine("4")
            stringBuilder2.Append("--" + str + "--")
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(stringBuilder.ToString())
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(My.Resources.scan + e + "/username/"), HttpWebRequest)
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip
            httpWebRequest.Method = "POST"
            httpWebRequest.Host = "i.instagram.com"
            httpWebRequest.UserAgent = "Instagram 26.15.0 Android (18/4.3; 320dpi; 720x1280; Xiaomi; HM 1SW; armani; qcom; en_US)"
            httpWebRequest.Headers.Add("Accept-Language", "ar;q=1, en;q=0.9")
            httpWebRequest.KeepAlive = True
            httpWebRequest.Proxy = Nothing
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + str
            httpWebRequest.ContentLength = CLng(bytes.Length)
            httpWebRequest.CookieContainer = Me.Sessionz
            Dim requestStream As Stream = httpWebRequest.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
            Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
                result = Not streamReader.ReadToEnd().Contains("auto_load_more_enabled")
                If streamReader.ReadToEnd().Contains("wait") Then
                    result = True
                End If
                streamReader.Close()
            End Using
            httpWebResponse.Close()
        Catch expr_256 As Exception
            ProjectData.SetProjectError(expr_256)
            result = False
            ProjectData.ClearProjectError()
        End Try
        Return result
    End Function

    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
        Dim flag As Boolean = Me.SwitchLoginBool
        If flag Then
            Dim thread As New Thread(New ThreadStart(AddressOf Me.AccountSettings))
            thread.Start()
        Else
            flag = Not Me.SwitchLoginBool
            If flag Then
                Dim thread2 As New Thread(New ThreadStart(AddressOf Me.LoginCheck))
                thread2.Start()
            End If
        End If
    End Sub

    Public Sub AccountSettings()
        Dim flag As Boolean = api.logout(Me.Sessionz) IsNot Nothing
        If flag Then
            MsgBox("Cannot Logout !", MsgBoxStyle.Critical)
        Else
            Me.accSettings = Nothing
            Me.Sessionz = Nothing
            Me.GetSettingsBool = False
            Me.stopp = True
            Me.StatusButton(Me.loginButton, "Start")
            Me.SwitchTextz(Me.Username, True)
            Me.SwitchTextz(Me.Password, True)
            Me.SwitchLoginBool = False
            Me.IfLoggedIn = False
        End If
    End Sub

    Public Sub LoginCheck()
        Me.accSettings = Nothing
        Me.Sessionz = Nothing
        Me.GetSettingsBool = False
        Dim cookieContainer As CookieContainer = api.login(Me.Username.Text, Me.Password.Text, Me.uuID)
        Dim flag As Boolean = cookieContainer Is Nothing
        If flag Then
            Me.SwitchButton(Me.loginButton, True)
            Me.SwitchTextz(Me.Username, True)
            Me.SwitchTextz(Me.Password, True)
            MsgBox("Error Username or Password !", MsgBoxStyle.Critical)
            Me.StatusButton(Me.loginButton, "Start")
            Me.SwitchLoginBool = False
            Thread.CurrentThread.Abort()
        Else
            flag = Not Me.GetSettingsBool
            If flag Then
                Dim text As String = api.getaccountsettings(cookieContainer)
                Me.accSettings = text
                Me.Sessionz = cookieContainer
                Me.GetSettingsBool = True
            End If
            flag = (Operators.CompareString(Me.accSettings, "|||||||", False) = 0)
            If flag Then
                MsgBox("Error On Login !", MsgBoxStyle.Critical)
            Else
                Me.SwitchButton(Me.loginButton, True)
                Me.once = 0
                Me.stopp = False
                Dim thread As Thread = New Thread(Sub(a0 As Object)
                                                      Me.Starting(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(a0)))
                                                  End Sub, 105)
                thread.Start(Conversions.ToDouble(Me.TurboThreads.Text) - 1.0)
                Me.StatusButton(Me.loginButton, "Stop")
                Me.SwitchLoginBool = True
                Me.IfLoggedIn = True
                flag = (Form1.TellMe > False)
                If flag Then
                    MessageBox.Show("logged in, but your account needs To Be activated !", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Form1.TellMe = False
                End If
            End If
        End If
    End Sub

    Public Function RunThreads(count As Integer, start As ThreadStart) As List(Of Thread)
        Dim list As List(Of Thread) = New List(Of Thread)()
        For i As Integer = 1 To count
            Dim thread As Thread = New Thread(start)
            thread.Start()
            list.Add(thread)
        Next
        Return list
    End Function

    Public Shared Function Sha256_hash(value As String, salt As String) As String
        Dim num As Integer = 0
        Dim stringBuilder As StringBuilder = New StringBuilder()
        Dim hMACSHA As HMACSHA256 = New HMACSHA256(Encoding.UTF8.GetBytes(salt))
        hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(value))
        Dim hash As Byte() = hMACSHA.Hash
        ' The following expression was wrapped in a checked-statement
        Dim num2 As Integer = hash.Length - 1
        Dim i As Integer = 0
        While i <= num
            stringBuilder.Append(hash(i).ToString("x2"))
            i += 1
            num = num2
        End While
        Return stringBuilder.ToString()

    End Function
    Private Sub _Lambda__10(a0 As Object)
        Me.Starting(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(a0)))))))))
    End Sub

    Private Sub _Lambda__3(a0 As Object)
        Me.Successfully(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(a0)))))))))
    End Sub

    Private Sub _Lambda__4(a0 As Object)
        Me.Starting(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(a0)))))))))
    End Sub

    Public Sub _Lambda__1()
        Me.Lst.Items.Add(Me.inputt)
    End Sub

    Private Sub Lambda__380(a0 As Object)
        Me.Successfully(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(a0)))))))))
    End Sub

    Private Sub Lambda__440(a0 As Object)
        Me.Starting(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(a0)))))
    End Sub

    Public Sub _Lambda__2()
        Dim label As Label = Me.llbl
        Dim label2 As Label = label
        label.Text = Conversions.ToString(Conversions.ToDouble(label2.Text) + 1.0)
    End Sub

    Private Sub AddCheckForList(Lst As ListBox, input As String)
        Me.inputt = input
        Lst = Lst
        Lst.Invoke(New VBAnonymousDelegate_0(AddressOf Me._Lambda__1))
    End Sub

    Private Sub AddChecks(lbl As Label)
        Me.llbl = lbl
        Me.llbl.Invoke(New VBAnonymousDelegate_0(AddressOf Me._Lambda__2))
    End Sub

    Private Sub StatusButton(btn As Button, input As String)
        btn.Invoke(New Form1.VBAnonymousDelegate_0(Sub()
                                                       btn.Text = String.Format(input, New Object(-1) {})
                                                   End Sub))
    End Sub

    Private Sub StatusLabel(lbl As Label, input As String)
        lbl.Invoke(New Form1.VBAnonymousDelegate_0(Sub()
                                                       lbl.Text = String.Format(input, New Object(-1) {})
                                                   End Sub))
    End Sub

    Private Sub SwitchButton(Btn As Button, input As Boolean)
        Btn.Invoke(New Form1.VBAnonymousDelegate_0(Sub()
                                                       Btn.Enabled = input
                                                   End Sub))
    End Sub

    Private Sub SwitchCheckBox(Chk As CheckBox, input As Boolean)
        Chk.Invoke(New Form1.VBAnonymousDelegate_0(Sub()
                                                       Chk.Enabled = input
                                                   End Sub))
    End Sub

    Private Sub SwitchTextz(txt As TextBox, input As Boolean)
        txt.Invoke(New Form1.VBAnonymousDelegate_0(Sub()
                                                       txt.Enabled = input
                                                   End Sub))
    End Sub

    Private Sub checkerTaken_TextChanged(sender As Object, e As EventArgs) Handles checkerTaken.TextChanged
        Me.TextBox1.Text = Conversions.ToString(Conversions.ToDouble(Me.TextBox1.Text) + 1.0)
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Close()
    End Sub
    Private Sub Label14_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label14.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Me.i = True
            Dim x As Integer = Control.MousePosition.X
            Dim location As Point = MyBase.Location
            Me.x = x - location.X
            Dim y As Integer = Control.MousePosition.Y
            location = MyBase.Location
            Me.y = y - location.Y
        End If
    End Sub

    Private Sub Label14_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label14.MouseMove
        If (Me.i) Then
            Dim mousePosition As System.Drawing.Point = Control.MousePosition
            Dim x As Integer = mousePosition.X - Me.x
            mousePosition = Control.MousePosition
            Dim point As System.Drawing.Point = New System.Drawing.Point(x, mousePosition.Y - Me.y)
            MyBase.Location = point
        End If
    End Sub
    Private Sub Label14_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label14.MouseUp
        Me.i = False
    End Sub

    Private Sub Label15_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label15.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Me.i = True
            Dim x As Integer = Control.MousePosition.X
            Dim location As Point = MyBase.Location
            Me.x = x - location.X
            Dim y As Integer = Control.MousePosition.Y
            location = MyBase.Location
            Me.y = y - location.Y
        End If
    End Sub

    Private Sub Label15_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label15.MouseMove
        If (Me.i) Then
            Dim mousePosition As System.Drawing.Point = Control.MousePosition
            Dim x As Integer = mousePosition.X - Me.x
            mousePosition = Control.MousePosition
            Dim point As System.Drawing.Point = New System.Drawing.Point(x, mousePosition.Y - Me.y)
            MyBase.Location = point
        End If
    End Sub
    Private Sub Label15_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Label15.MouseUp
        Me.i = False
    End Sub


    Private Function ValidateServerCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors__1 As SslPolicyErrors) As Boolean
        Return sslPolicyErrors__1 = SslPolicyErrors.None
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Operators.CompareString(Me.Username.Text, Nothing, False) = 0 Then
            MsgBox("Check Your Username")
        ElseIf Operators.CompareString(Me.Password.Text, Nothing, False) <> 0 Then
            If Not Me.SwitchLoginBool AndAlso Not Me.SwitchLoginBool Then
                Dim thread As New Thread(AddressOf Me.LoginCheck)
                thread.Start()
            End If
        Else
            MsgBox("Check Your Password")
        End If
    End Sub

    Private Sub Tok_TextChanged(sender As Object, e As EventArgs) Handles Tok.TextChanged

    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
