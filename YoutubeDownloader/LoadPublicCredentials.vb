Module LoadPublicCredentials
    Const CredentialsURL As String = "https://raw.githubusercontent.com/ShimmyMySherbet/YoutubeDownloader/master/YoutubeDownloader/SpotifyCredentials"
    Public Function GetRandomPublicCredentials() As KeyValuePair(Of String, String)
        Dim Webclient As New Net.WebClient
        Console.WriteLine("Fetching public credentials...")
        Try
            Dim Creds As String = Webclient.DownloadString(CredentialsURL)
            Creds = Creds.Replace(ChrW(13), ChrW(10))
            Dim Credl As New List(Of KeyValuePair(Of String, String))

            Dim SplitChar As Char = vbNewLine
            If Creds.Contains(ChrW(10)) Then
                SplitChar = ChrW(10)
            ElseIf Creds.Contains(ChrW(13)) Then
                SplitChar = ChrW(13)
            End If
            For Each line In Creds.Split(SplitChar)
                If line <> "" And Not line.StartsWith("#") Then
                    If line.Contains("|") Then
                        Dim ClientID As String = line.Split("|")(0)
                        Dim Secret As String = line.Split("|")(1)
                        Credl.Add(New KeyValuePair(Of String, String)(ClientID, Secret))
                    End If
                End If
            Next
            Dim index As Integer = Math.Ceiling(Rnd() * Credl.Count - 1)
            If index = -1 Then
                Console.WriteLine("[Error] No public credentials found.")
                Return New KeyValuePair(Of String, String)("Error", "No public credentials available.")
            Else
                Console.WriteLine("Recieved public credentials.")
                Return Credl(index)
            End If
        Catch ex As Exception
            Console.WriteLine("[Error] Couldn't get public credentials: " & ex.Message)
            Return New KeyValuePair(Of String, String)("Error", ex.Message)
        End Try
    End Function
End Module
