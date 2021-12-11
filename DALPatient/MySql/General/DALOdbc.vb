Imports System.Data
Imports System.Data.Odbc

Public Class DALOdbc

    Implements IDisposable

    'Class level variables that are available to classes that instantiate me
    Public SQL As String

    Public Connection As OdbcConnection
    Public Command As OdbcCommand
    Public DataAdapter As OdbcDataAdapter
    Public DataReader As OdbcDataReader
    Private disposedValue As Boolean = False ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
                If Not DataReader Is Nothing Then
                    DataReader.Close()
                    DataReader = Nothing
                End If
                If Not DataAdapter Is Nothing Then
                    DataAdapter.Dispose()
                    DataAdapter = Nothing
                End If
                If Not Command Is Nothing Then
                    Command.Dispose()
                    Command = Nothing
                End If
                If Not Connection Is Nothing Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    Public Sub New(ByVal ConString As String)
        'Build the SQL connection string and initialize the Connection object
        
        Connection = New OdbcConnection(ConString)
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Public Sub OpenConnection()
        Try
            Connection.Open()

        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Catch InvalidOperationExceptionErr As InvalidOperationException
            Throw New System.Exception(InvalidOperationExceptionErr.Message, _
                InvalidOperationExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub CloseConnection()
        Connection.Close()

    End Sub

    Public Sub InitializeCommand()
        If Command Is Nothing Then
            Try
                Command = New OdbcCommand(SQL, Connection)

                'See if this is a stored procedure
                If Not SQL.ToUpper.StartsWith("SELECT ") _
                    And Not SQL.ToUpper.StartsWith("INSERT ") _
                    And Not SQL.ToUpper.StartsWith("UPDATE ") _
                    And Not SQL.ToUpper.StartsWith("DELETE ") Then
                    'Command.CommandType = CommandType.StoredProcedure
                    Command.CommandType = CommandType.StoredProcedure
                End If
            Catch SQLExceptionErr As OdbcException
                Throw New System.Exception(SQLExceptionErr.Message, _
                    SQLExceptionErr.InnerException)
            End Try
        End If
    End Sub

    Public Sub AddParameter(ByVal Name As String, ByVal Type As OdbcType, _
        ByVal Size As Integer, ByVal Value As Object)

        Try
            Command.Parameters.Add(Name, Type, Size).Value = Value
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub InitializeDataAdapter()
        Try
            DataAdapter = New OdbcDataAdapter
            DataAdapter.SelectCommand = Command
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
            SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub FillDataSet(ByRef oDataSet As DataSet, ByVal TableName As String)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataSet, TableName)
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Sub FillDataTable(ByRef oDataTable As DataTable)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataTable)
        Catch SQLExceptionErr As OdbcException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        Finally
            Command.Dispose()
            Command = Nothing
            DataAdapter.Dispose()
            DataAdapter = Nothing
        End Try
    End Sub

    Public Function ExecuteStoredProcedure() As Integer
        Try
            OpenConnection()
            ExecuteStoredProcedure = Command.ExecuteNonQuery()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function ExecuteScalar() As Integer
        Try
            OpenConnection()
            ExecuteScalar = Command.ExecuteScalar()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally
            CloseConnection()
        End Try
    End Function

End Class
