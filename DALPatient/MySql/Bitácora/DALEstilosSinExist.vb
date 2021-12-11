Imports System.Data.Odbc

Public Class DALEstilosSinExist
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "

    Public Function usp_PpalEstilosSinExist(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, _
                                            ByVal FecIni As DateTime, ByVal FecFin As DateTime)
        'Tony Garcia - 03/Diciembre/2012 - 5:10 p.m
        Try
            usp_PpalEstilosSinExist = New DataSet
            MyBase.SQL = "CALL usp_PpalEstilosSinExist(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@feciniB", OdbcType.Date, 8, FecIni)
            MyBase.AddParameter("@fecfinB", OdbcType.Date, 8, FecFin)

            MyBase.FillDataSet(usp_PpalEstilosSinExist, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
