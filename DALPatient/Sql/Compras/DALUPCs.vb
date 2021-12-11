Imports System.Data
Imports System.Data.SqlClient
Public Class DALUPCs
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "
    Public Function usp_UPCs(ByVal Ruta As String)
        Try
            MyBase.SQL = "usp_UPCs"
            MyBase.InitializeCommand()
            MyBase.ClearParameters()
            AddParameter("@Ruta", SqlDbType.VarChar, 100, Ruta)
            usp_UPCs = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
