Imports System.Data.Odbc
Public Class DALReporteVentas
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
    Public Function usp_PpalReporteVentas(ByVal opcion As Integer, ByVal opcion2 As Integer, ByVal FechaA As Date, ByVal FechaB As Date, ByVal distribB As String, ByVal sucursalB As String, ByVal ventaB As String) As DataSet
        'Ro
        Try

            usp_PpalReporteVentas = New DataSet
            MyBase.SQL = "CALL usp_PpalReporteVentas(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, opcion)
            MyBase.AddParameter("@opcion2", OdbcType.Int, 16, opcion2)
            MyBase.AddParameter("@fechaA", OdbcType.Date, 10, FechaA)
            MyBase.AddParameter("@fechaB", OdbcType.Date, 10, FechaB)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, distribB)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, sucursalB)
            MyBase.AddParameter("@ventaB", OdbcType.Char, 6, ventaB)
            MyBase.FillDataSet(usp_PpalReporteVentas, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalReporteVentas2(ByVal opcion As Integer, ByVal FechaA As Date, ByVal FechaB As Date, ByVal distribB As String, ByVal sucursalB As String, ByVal ventaB As String) As DataSet
        'Ro
        Try

            usp_PpalReporteVentas2 = New DataSet
            MyBase.SQL = "CALL usp_PpalReporteVentas2(?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, opcion)
            MyBase.AddParameter("@fechaA", OdbcType.Date, 10, FechaA)
            MyBase.AddParameter("@fechaB", OdbcType.Date, 10, FechaB)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, distribB)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, sucursalB)
            MyBase.AddParameter("@ventaB", OdbcType.Char, 6, ventaB)
            MyBase.FillDataSet(usp_PpalReporteVentas2, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxFechaCargo() As DataSet
        'Ro. 25/03/2013
        Try
            usp_TraerMaxFechaCargo = New DataSet
            MyBase.SQL = "CALL usp_TraerMaxFechaCargo()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@coloniaB", OdbcType.Char, 45, nombre)


            MyBase.FillDataSet(usp_TraerMaxFechaCargo, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
