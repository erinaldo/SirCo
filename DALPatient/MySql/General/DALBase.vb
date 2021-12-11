Imports System.Data
Imports System.Data.SqlClient


Public Class DALBase
    Implements IDisposable

    'Class level variables that are available to classes that instantiate me
    Public SQL As String


    Public Connection As SqlConnection
    Public Command As SqlCommand
    Public DataAdapter As SqlDataAdapter
    Public DataReader As SqlDataReader
    Private disposedValue As Boolean = False        ' To detect redundant calls

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

        Connection = New SqlConnection(ConString)
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

        Catch SQLExceptionErr As SqlException
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
                Command = New SqlCommand(SQL, Connection)


                'See if this is a stored procedure
                If Not SQL.ToUpper.StartsWith("SELECT ") _
                    And Not SQL.ToUpper.StartsWith("INSERT ") _
                    And Not SQL.ToUpper.StartsWith("UPDATE ") _
                    And Not SQL.ToUpper.StartsWith("DELETE ") Then
                    Command.CommandType = CommandType.StoredProcedure
                End If
            Catch SQLExceptionErr As SqlException
                Throw New System.Exception(SQLExceptionErr.Message, _
                    SQLExceptionErr.InnerException)
            End Try
        End If
    End Sub

    Public Sub AddParameter(ByVal Name As String, ByVal Type As SqlDbType, _
        ByVal Size As Integer, ByVal Value As Object)

        Try
            Command.Parameters.Add(Name, Type, Size).Value = Value
        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
                SQLExceptionErr.InnerException)
        End Try
    End Sub

    Public Sub ClearParameters()
        Command.Parameters.Clear()
    End Sub

    Public Sub InitializeDataAdapter()
        Try
            DataAdapter = New SqlDataAdapter
            DataAdapter.SelectCommand = Command
        Catch SQLExceptionErr As SqlException
            Throw New System.Exception(SQLExceptionErr.Message, _
            SQLExceptionErr.InnerException)
        End Try
    End Sub


    Public Sub FillDataSet(ByRef oDataSet As DataSet, ByVal TableName As String)
        Try
            InitializeCommand()
            InitializeDataAdapter()
            DataAdapter.Fill(oDataSet, TableName)
        Catch SQLExceptionErr As SqlException
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
        Catch SQLExceptionErr As SqlException
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
            'ExecuteStoredProcedure = Command.ExecuteNonQuery()
            ExecuteStoredProcedure = Command.ExecuteNonQuery()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally
            CloseConnection()
        End Try
    End Function

    Public Function ExecuteNonQuery_Int() As Integer
        Try
            Command.Parameters.Add(New SqlClient.SqlParameter("@ret", SqlDbType.Int, 16))
            Command.Parameters("@ret").Direction = ParameterDirection.ReturnValue
            Command.Parameters("@ret").Value = 0

            OpenConnection()
            Command.ExecuteNonQuery()
            
            ExecuteNonQuery_Int = Command.Parameters("@ret").Value
            
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally

            CloseConnection()
        End Try
    End Function

    Public Function ExecuteNonQuery_Dec() As Decimal
        Try
            Command.Parameters.Add(New SqlClient.SqlParameter("@ret", SqlDbType.Decimal, 16))
            Command.Parameters("@ret").Direction = ParameterDirection.ReturnValue
            Command.Parameters("@ret").Value = 0

            OpenConnection()
            Command.ExecuteNonQuery()

            ExecuteNonQuery_Dec = Command.Parameters("@ret").Value

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        Finally

            CloseConnection()
        End Try
    End Function
End Class
