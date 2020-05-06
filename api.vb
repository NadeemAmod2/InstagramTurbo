Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class api
    Public Shared Function getaccountsettings(ByVal ssn As CookieContainer) As String
        Dim str4 As String = String.Empty
        Dim str5 As String = String.Empty
        Dim str6 As String = String.Empty
        Dim str7 As String = String.Empty
        Dim str8 As String = String.Empty
        Dim str9 As String = String.Empty
        Dim str10 As String = String.Empty
        Dim str11 As String = String.Empty
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create("https://i.instagram.com/api/v1/accounts/current_user/?edit=true"), HttpWebRequest)
        Dim str3 As String = Guid.NewGuid.ToString.ToUpper
        request.Host = "i.instagram.com"
        request.UserAgent = "Instagram 7.10.0 Android (24/5.0; 515dpi; 1440x2416; huawei/google; Nexus 6P; angler; angler; en_US)"
        request.Headers.Add("Accept-Language", "ar;q=1, en;q=0.9")
        request.KeepAlive = True
        request.Proxy = Nothing
        request.ContentType = ("multipart/form-data; boundary=" & str3)
        request.CookieContainer = ssn
        Using reader As StreamReader = New StreamReader(request.GetResponse.GetResponseStream)
            Dim input As String = reader.ReadToEnd
            str4 = Regex.Match(input, "pk"": (.*?),").Groups.Item(1).Value
            If (str4 = Nothing) Then
                str4 = Regex.Match(input, "pk"": (.*?)}").Groups.Item(1).Value
                If (str4 = Nothing) Then
                    Return "|||||||"
                End If
            End If
            str5 = Regex.Match(input, "full_name"": ""(.*?)""").Groups.Item(1).Value
            str6 = Regex.Match(input, "is_private"": (.*?),").Groups.Item(1).Value
            If (str6 = Nothing) Then
                str6 = Regex.Match(input, "is_private"": (.*?)}").Groups.Item(1).Value
                If (str6 = Nothing) Then
                    Return "|||||||"
                End If
            End If
            str7 = Regex.Match(input, "phone_number"": ""(.*?)""").Groups.Item(1).Value
            str8 = Regex.Match(input, "biography"": ""(.*?)""").Groups.Item(1).Value
            str9 = Regex.Match(input, "gender"": (.*?),").Groups.Item(1).Value
            If (str9 = Nothing) Then
                str9 = Regex.Match(input, "gender"": (.*?)}").Groups.Item(1).Value
                If (str9 = Nothing) Then
                    Return "|||||||"
                End If
            End If
            str10 = Regex.Match(input, "email"": ""(.*?)""").Groups.Item(1).Value
            str11 = Regex.Match(input, "external_url"": ""(.*?)""").Groups.Item(1).Value
            api.AccSettings = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", New Object() {str4, str5, str6, str7, str8, str9, str10, str11})
        End Using
        Return api.AccSettings
    End Function

    Public Shared Function login(ByVal Username As String, ByVal Password As String, ByVal uuID As String) As CookieContainer
        Try
            Dim str As String = Guid.NewGuid.ToString.ToUpper
            Dim builder As New StringBuilder
            Dim builder2 As StringBuilder = builder
            Dim str2 As String = String.Concat(New String() {"{""_uuid"":""", uuID, """,""password"":""", Password, """,""username"":""", Username, """,""device_id"":""", uuID, """,""from_reg"":false,""_csrftoken"":""missing"",""login_attempt_count"":0}"})
            str2 = String.Format("{0}.{1}", api.Sha256_hash(str2, "fc4720e1bf9d79463f62608c86fbddd374cc71bbfb98216b52e3f75333bd130d"), str2)
            builder2.AppendLine(("--" & str))
            builder2.AppendLine("Content-Disposition: form-data; name=""signed_body""")
            builder2.AppendLine()
            builder2.AppendLine(str2)
            builder2.AppendLine(("--" & str))
            builder2.AppendLine("Content-Disposition: form-data; name=""ig_sig_key_version""")
            builder2.AppendLine()
            builder2.AppendLine("4")
            builder2.Append(("--" & str & "--"))
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(builder.ToString)
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("https://i.instagram.com/api/v1/accounts/login/"), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip
            request.Method = "POST"
            request.Host = "i.instagram.com"
            request.UserAgent = "Instagram 9.4.0 Android (18/4.3; 320dpi; 720x1280; Xiaomi; HM 1SW; armani; qcom; en_US)"
            request.Headers.Add("Accept-Language", "ar;q=1, en;q=0.9")
            request.KeepAlive = True
            request.Proxy = Nothing
            request.ContentType = ("multipart/form-data; boundary=" & str)
            request.ContentLength = bytes.Length
            request.CookieContainer = api.Cookies
            Dim requestStream As Stream = request.GetRequestStream
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
            Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                If reader.ReadToEnd.Contains("logged_in_user") Then
                    Return api.Cookies
                End If
                reader.Close()
            End Using
            response.Close()
        Catch exception1 As Exception
        End Try
        Return Nothing
    End Function

    Public Shared Function logout(ByVal sn As CookieContainer) As CookieContainer
        Application.DoEvents()
        Try
            Dim str As String = Guid.NewGuid.ToString.ToUpper
            Dim builder As New StringBuilder
            Dim str2 As String = String.Concat(New String() {""})
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(builder.ToString)
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("https://i.instagram.com/api/v1/accounts/logout/"), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip
            request.Method = "POST"
            request.Host = "i.instagram.com"
            request.UserAgent = "Instagram 7.10.0 Android (24/5.0; 515dpi; 1440x2416; huawei/google; Nexus 6P; angler; angler; en_US)"
            request.Headers.Add("Accept-Language", "ar;q=1, en;q=0.9")
            request.KeepAlive = True
            request.Proxy = Nothing
            request.ContentType = ("multipart/form-data; boundary=" & str)
            request.ContentLength = bytes.Length
            request.CookieContainer = sn
            Dim requestStream As Stream = request.GetRequestStream
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
            Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                If reader.ReadToEnd.Contains("{""status"": ""ok""}") Then
                    Return Nothing
                End If
                reader.Close()
            End Using
            response.Close()
        Catch exception1 As Exception
        End Try
        Return sn
    End Function

    Public Shared Function Sha256_hash(ByVal value As String, ByVal salt As String) As String
        Dim num2 As Integer
        Dim builder As New StringBuilder
        Dim hmacsha As New HMACSHA256(Encoding.UTF8.GetBytes(salt))
        hmacsha.ComputeHash(Encoding.UTF8.GetBytes(value))
        Dim hash As Byte() = hmacsha.Hash
        Dim num3 As Integer = (hash.Length - 1)
        Dim index As Integer = 0
        Do While (index <= num2)
            builder.Append(hash(index).ToString("x2"))
            index += 1
            num2 = num3
        Loop
        Return builder.ToString
    End Function

    Public Shared AccSettings As String
    Public Shared Cookies As CookieContainer = New CookieContainer
End Class