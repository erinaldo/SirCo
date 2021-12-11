Imports System.Data.Odbc

Public Class DALDetFactProv
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

    Public Function ups_TraerUltimaFactProv(ByVal Sucursal As String) As DataSet
        'Tony Garcia - 04/Diciembre/2012 - 10:00 a.m.
        Try
            ups_TraerUltimaFactProv = New DataSet
            MyBase.SQL = "CALL usp_TraerUltimaFactProv(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(ups_TraerUltimaFactProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDetFactProv(ByVal Sucursal As String, ByVal FactProv As String, ByVal SerieIni As String, _
                                            ByVal SerieFin As String)
        'Tony Garcia - 04/Diciembre/2012 - 5:10 p.m
        Try
            usp_PpalDetFactProv = New DataSet
            MyBase.SQL = "CALL usp_PpalDetFactProv(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 6, FactProv)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 13, SerieIni)
            MyBase.AddParameter("@feciniB", OdbcType.Char, 13, SerieFin)

            MyBase.FillDataSet(usp_PpalDetFactProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
