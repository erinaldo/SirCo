Imports System.Data.Odbc
Public Class DALGeneraTimbrado
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

    Public Function usp_GeneraTimbrado(ByVal Periodo As Integer) As Boolean
        'Gmanvaz 04/Febrero/2017 04:07 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraTimbrado(?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@id_periodob", OdbcType.Int, 16, Periodo)
            usp_GeneraTimbrado = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
End Class
