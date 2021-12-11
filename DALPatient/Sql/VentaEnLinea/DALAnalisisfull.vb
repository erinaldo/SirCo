Imports System.Data
Imports System.Data.SqlClient
Public Class DALAnalisisFull
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
    Public Function usp_GeneraAnalisis(ByVal FechaIni As String, ByVal FechaFin As String, ByVal Marca As String, ByVal Modelo As String) As DataSet
        Try
            usp_GeneraAnalisis = New DataSet
            MyBase.SQL = "usp_GeneraAnalisisFull"
            MyBase.InitializeCommand()
            MyBase.ClearParameters()
            MyBase.AddParameter("@FechaIni", SqlDbType.Date, 100, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 100, FechaFin)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.FillDataSet(usp_GeneraAnalisis, "Analisis")
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraAnalisisdet(ByVal Marca As String, ByVal Modelo As String) As DataSet
        Try
            usp_GeneraAnalisisdet = New DataSet
            MyBase.SQL = "usp_GeneraAnalisisFulldet"
            MyBase.InitializeCommand()
            MyBase.ClearParameters()
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.FillDataSet(usp_GeneraAnalisisdet, "Analisis")
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
