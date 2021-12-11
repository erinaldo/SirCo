
Imports System.Data
Imports System.Data.SqlClient

Public Class DALcostomargen
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

    Public Function usp_PpalCostoMargen(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 02/Agosto/2017  07:07 p.m.
        Try
            usp_PpalCostoMargen = New DataSet
            MyBase.SQL = "usp_PpalCostoMargen"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", SqlDbType.VarChar, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.VarChar, 10, FechaFin)


            MyBase.FillDataSet(usp_PpalCostoMargen, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalProyeccionComprasL1() As DataSet
        'mreyes 14/Agosto/2017  04:27 p.m.
        Try
            usp_PpalProyeccionComprasL1 = New DataSet
            MyBase.SQL = "usp_PpalProyeccionComprasL1"

            MyBase.InitializeCommand()



            MyBase.FillDataSet(usp_PpalProyeccionComprasL1, "SirCoDWH")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraProyeccionCompra(ByVal FechaIni As String, ByVal FechaFin As String) As Boolean

        'mreyes 30/Agosto/2017  05:54 p.m.
        Try
            MyBase.SQL = "usp_GeneraProyeccionCompra"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@FechaIni", SqlDbType.VarChar, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.VarChar, 10, FechaFin)



            usp_GeneraProyeccionCompra = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaProyeccionReciboL1(Opcion As Integer, Linea As String, L1 As String, Recibo1 As Integer, Recibo2 As Integer, Recibo3 As Integer, Recibo4 As Integer, Recibo5 As Integer, Recibo6 As Integer, Recibo7 As Integer, Recibo8 As Integer, Recibo9 As Integer, Recibo10 As Integer, Recibo11 As Integer, Recibo12 As Integer) As Boolean

        'mreyes 30/Agosto/2017  05:34 p.m.
        Try
            MyBase.SQL = "usp_CapturaProyeccionReciboL1"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'sqlComman.Parameters.Clear()

            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@Linea", SqlDbType.VarChar, 50, Linea)
            MyBase.AddParameter("@L1", SqlDbType.VarChar, 50, L1)
            MyBase.AddParameter("@Recibo1", SqlDbType.Int, 16, Recibo1)
            MyBase.AddParameter("@Recibo2", SqlDbType.Int, 16, Recibo2)
            MyBase.AddParameter("@Recibo3", SqlDbType.Int, 16, Recibo3)
            MyBase.AddParameter("@Recibo4", SqlDbType.Int, 16, Recibo4)
            MyBase.AddParameter("@Recibo5", SqlDbType.Int, 16, Recibo5)
            MyBase.AddParameter("@Recibo6", SqlDbType.Int, 16, Recibo6)
            MyBase.AddParameter("@Recibo7", SqlDbType.Int, 16, Recibo7)
            MyBase.AddParameter("@Recibo8", SqlDbType.Int, 16, Recibo8)
            MyBase.AddParameter("@Recibo9", SqlDbType.Int, 16, Recibo9)
            MyBase.AddParameter("@Recibo10", SqlDbType.Int, 16, Recibo10)
            MyBase.AddParameter("@Recibo11", SqlDbType.Int, 16, Recibo11)
            MyBase.AddParameter("@Recibo12", SqlDbType.Int, 16, Recibo12)



            usp_CapturaProyeccionReciboL1 = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCostoMargenSVenta(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 02/Agosto/2017  04:39 p.m.
        Try
            usp_PpalCostoMargenSVenta = New DataSet
            MyBase.SQL = "usp_PpalCostoMargenSVenta"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", SqlDbType.VarChar, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.VarChar, 10, FechaFin)


            MyBase.FillDataSet(usp_PpalCostoMargenSVenta, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
