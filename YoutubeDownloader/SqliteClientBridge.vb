Public Class SqliteClientBridge
    Public UnderlyingClient As SqliteClient
    Public Sub New(File As String)
        UnderlyingClient = New SqliteClient(File)
    End Sub
    Public Function GetSettingsValue(Key As String) As String
        Dim result As DataRow() = UnderlyingClient.RunQuery("Select value from 'settings' where key = '{0}'", Key)
        If result.Count <> 0 Then
            Dim Res As DataRow = result(0)
            Dim val As String = Res.Item(0)
            Return val
        Else
            Return Nothing
        End If
    End Function
    Public Function TryGetSettingsValue(Key As String) As String
        Dim result As DataRow() = UnderlyingClient.RunQuery("Select value from 'settings' where key = '{0}'", Key)
        If result.Count <> 0 Then
            Dim Res As DataRow = result(0)
            For Each item In Res.ItemArray
                Console.WriteLine(item)
            Next
            Dim val As String = Res.Item(0)
            Return val
        Else
            Return ""
        End If
    End Function
    Public Function SettingsKeyExists(key As String) As Boolean
        Dim result As DataRow() = UnderlyingClient.RunQuery("Select * from 'settings' where key = '{0}'", key)
        If result.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub UpdateSettingsKey(Key As String, Value As String)
        Console.WriteLine("Updating key '{0}' with value '{1}'", Key, Value)
        If SettingsKeyExists(Key) Then
            Console.WriteLine("patching...")
            UnderlyingClient.RunNonQuery("Update settings SET value = '{1}' WHERE key = '{0}'", Key, Value)
        Else
            Console.WriteLine("creating...")
            UnderlyingClient.RunNonQuery("Insert into settings Values('{0}', '{1}')", Key, Value)
        End If
    End Sub
End Class
