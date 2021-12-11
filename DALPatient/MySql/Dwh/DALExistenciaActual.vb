Imports System.Data.Odbc
Public Class DALExistenciaActual

    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region


    Public Function usp_PpalEstructuraYExistActual(ByVal fechaIniB As String, ByVal fechaFinB As String, ByVal Division As String, ByVal Depto As String, ByVal Linea As String,
                                                   ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String) As DataSet
        'mreyes 29/Abril/2015   11:42 a.m.
        Try
            usp_PpalEstructuraYExistActual = New DataSet
            MyBase.SQL = "CALL usp_PpalEstExistActual(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fechaIniB", OdbcType.Date, 10, fechaIniB)
            MyBase.AddParameter("@fechaFinB", OdbcType.Date, 10, fechaFinB)
            MyBase.AddParameter("@DivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@DeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@LineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@L1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@L2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@L3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@L4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@L5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@L6B", OdbcType.Char, 30, L6)



            MyBase.FillDataSet(usp_PpalEstructuraYExistActual, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


End Class
