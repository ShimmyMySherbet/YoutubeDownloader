Imports System.Reflection
Namespace Plugins
    Public Class Plugin
        Public ReadOnly Domain As String
        Public ReadOnly ReturnType As ReturnTypes
        Public UnderlyingObject As Object
        Public Assembly As Assembly
        Private Const AllowedCharacters As String = "`1234567890-=\][poiuytrewq asdfghjkl;'/.,mnbvcxz~!@#$%^&*()_+|}{POIUYTREWQASDFGHJKL:""?><MNBVCXZ "
        Public Function RunRequest(Request As String) As List(Of String)
            Dim res As New List(Of String)
            For Each rep In UnderlyingObject.GetSongs(Request)
                res.Add(ScrubString(rep))
            Next
            Return res
        End Function
        Public Enum ReturnTypes
            Unknown = -1
            Track = 0
            Album = 1
        End Enum
        Public Shared Function ScrubString(InString As String) As String
            Dim ScrubbedString As String = ""
            For Each cha As Char In InString
                If AllowedCharacters.Contains(cha.ToString) Then
                    ScrubbedString = ScrubbedString & cha
                End If
            Next
            Return ScrubbedString
        End Function
        Public Sub New(dll As String)
            Dim ipinf As New IO.FileInfo(dll)
            Assembly = Assembly.LoadFrom(dll)
            UnderlyingObject = Activator.CreateInstance(Assembly.GetType($"{ipinf.Name.Split(".")(0)}.Classmain"))
            UnderlyingObject.Start()
            Domain = UnderlyingObject.GetDomain()
            Dim ReturnTypeStr As String = UnderlyingObject.GetReturnType()
            Select Case ReturnTypeStr.ToLower
                Case "name"
                    ReturnType = ReturnTypes.Track
                Case "album_name"
                    ReturnType = ReturnTypes.Album
                Case ReturnType = ReturnTypes.Unknown
            End Select
        End Sub
    End Class
    Public Class PluginManager
        Public Plugins As New List(Of Plugin)
        Public Function PluginsLoaded() As Integer
            Return Plugins.Count
        End Function
        Public Sub LoadPlugin(Plugin As String)
            Plugins.Add(New Plugin(Plugin))
        End Sub
        Public Function UrlSupported(Query As String)
            Dim Domain As String = ""
            If Query.Contains("://") Then
                Dim lst As List(Of String) = Query.Replace("://", vbNewLine).Split(vbNewLine).ToList
                Domain = lst(1)
            End If
            Domain = Domain.Split("/")(0).ToLower
            Domain = Plugin.ScrubString(Domain)
            Dim retv As Boolean = False
            For Each Plugin In Plugins
                If Not Plugin.Domain.Contains("%") Then
                    If Plugin.Domain.ToLower = Domain Then
                        retv = True
                    End If
                End If
            Next
            Return retv
        End Function
        Public Sub LoadPlugins()
            For Each PluginDir In IO.Directory.GetDirectories("Plugins\")
                If IO.File.Exists($"{PluginDir}\config.ini") Then
                    Dim Config As IniReader = New IniReader($"{PluginDir}\config.ini")
                    Dim PluginFile As String = Config.GetValue("file")
                    Dim Plugin As String = $"{PluginDir}\{PluginFile}"
                    LoadPlugin(Plugin)
                End If
            Next
        End Sub
        Public Function QueryByURL(url As String) As List(Of String)
            Dim Domain As String = ""
            If url.Contains("://") Then
                Dim lst As List(Of String) = url.Replace("://", vbNewLine).Split(vbNewLine).ToList
                Domain = lst(1)
            End If
            Domain = Domain.Split("/")(0).ToLower
            Domain = Plugin.ScrubString(Domain)
            Dim MyPlugin As Plugin = Nothing
            Dim retv As Boolean = False
            For Each Plugin In Plugins
                If Not Plugin.Domain.Contains("%") Then
                    If Plugin.Domain.ToLower = Domain Then
                        MyPlugin = Plugin
                        retv = True
                    End If
                End If
            Next
            If retv Then
                Return MyPlugin.RunRequest(url)
            Else
                Return Nothing
            End If
        End Function
    End Class
    Public Class IniReader
        Public Contents As New Dictionary(Of String, String)
        Public Sub New(File As String)
            For Each line In IO.File.ReadLines(File)
                If line <> "" And Not line.StartsWith("#") Then
                    Dim Key As String = line.Split("=")(0)
                    Dim Value As String = line.Remove(0, Key.Length + 1)
                    Contents.Add(Key.ToLower, Value)
                End If
            Next
        End Sub
        Public Function GetValue(Key As String) As String
            Return Contents(Key.ToLower)
        End Function
    End Class
End Namespace
