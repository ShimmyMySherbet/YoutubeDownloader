Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports HtmlAgilityPack
Namespace GeniusAPI
    Module GeniusAPI
        Private AccessToken As String
        Public Sub Init(Token As String)
            AccessToken = Token
        End Sub
        Public Function GetLyrics(Artist As String, Song As String, Explicit As Boolean) As GeniusResult
            Dim HTTPR As HttpWebRequest = HttpWebRequest.Create($"https://api.genius.com/search?q={$"{Artist} {Song}".Replace(" ", "%20")}")
            HTTPR.Headers("Authorization") = $"Bearer {AccessToken}"
            Dim RespJson As String
            Using streamReader As StreamReader = New StreamReader(HTTPR.GetResponse.GetResponseStream())
                RespJson = streamReader.ReadToEnd
            End Using
            Dim Document As JObject = JObject.Parse(RespJson)
            Dim responce As JObject = Document("response")
            Dim Hits As New List(Of Hit)
            For Each child In responce("hits").Children.ToList
                Console.WriteLine("res")
                Console.WriteLine(child.Path)
                Hits.Add(child.ToObject(Of Hit))
            Next
            Dim ReturnResult As Hit = Nothing
            If Explicit Then
                ReturnResult = Hits.Where(Function(x)
                                              If x.result.title.ToLower.Replace(" ", "") = Song.ToLower.Replace(" ", "") Then
                                                  If x.result.primary_artist.name.ToLower = Artist.ToLower Then
                                                      Return True
                                                  Else
                                                      Return False
                                                  End If
                                              Else
                                                  Return False
                                              End If
                                          End Function)(0)

            Else
                ReturnResult = Hits.Where(Function(x)
                                              If x.result.title.ToLower.Replace(" ", "").Contains(Song.ToLower.Replace(" ", "")) Then
                                                  If x.result.primary_artist.name.ToLower.Replace(" ", "").Contains(Artist.ToLower.Replace(" ", "")) Then
                                                      Return True
                                                  Else
                                                      Return False
                                                  End If
                                              Else
                                                  Return False
                                              End If
                                          End Function)(0)
            End If
            If Not IsNothing(ReturnResult) Then
                Dim Web As New HtmlWeb
                Dim HtmlDoc As HtmlDocument = Web.Load(ReturnResult.result.url)
                Dim Node As HtmlNode = HtmlDoc.DocumentNode.SelectSingleNode("//div[@class=""lyrics""]")
                Dim DirtyLyrics As String = Node.InnerText
                Dim Lyrics As String = DirtyLyrics.Trim(ChrW(10), ChrW(13), " ")
                Return New GeniusResult(Lyrics, ReturnResult.result.url, True)
            Else
                Return New GeniusResult(Nothing, Nothing, False)
            End If
        End Function
    End Module
    Public Class HitResult
        Public annotation_count As Integer
        Public api_path As String
        Public full_title As String
        Public header_image_thumbnail_url As String
        Public header_image_url As String
        Public id As Long
        Public lyrics_owner_id As String
        Public lyrics_state As String
        Public path As String
        Public pyongs_count As String
        Public title As String
        Public url As String
        Public primary_artist As HitArtist
    End Class
    Public Class Hit
        Public highlights As List(Of String)
        Public index As String
        Public type As String
        Public result As HitResult
    End Class
    Public Class HitArtist
        Public name As String
    End Class
    Public Class GeniusResult
        Public Lyrics As String
        Public URL As String
        Public Available As Boolean
        Public Sub New(L As String, U As String, A As Boolean)
            Lyrics = L
            URL = U
            Available = A
        End Sub
    End Class
End Namespace
