Public Class SqliteClient
    Implements IDisposable
    Public Connection As SQLite.SQLiteConnection
    Public Sub New(File As String)
        Connection = New SQLite.SQLiteConnection("Data Source=" & File)
        Connection.Open()
    End Sub
    Public Overridable Sub Dispose() Implements IDisposable.Dispose
        Connection.Close()
    End Sub
    Public Function RunQuery(Query As String, ParamArray Param() As String) As DataRow()
        Query = String.Format(Query, Param)
        Try
            Using cmd As New SQLite.SQLiteCommand(Query, Connection)
                Using Reader As SQLite.SQLiteDataReader = cmd.ExecuteReader()
                    Using Dat As New DataTable
                        Dat.Load(Reader)
                        Return Dat.Select()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub RunNonQuery(NonQuery As String, ParamArray param() As String)
        NonQuery = String.Format(NonQuery, param)
        Dim Cm As New SQLite.SQLiteCommand(NonQuery, Connection)
        Cm.ExecuteNonQuery()
    End Sub
End Class
