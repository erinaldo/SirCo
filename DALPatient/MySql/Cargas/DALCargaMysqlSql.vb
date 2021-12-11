Imports System.Data.SqlClient
'mreyes 10/Febrero/2012 11:51 a.m.

Public Class DALCargaMysqlSql
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

    Public Function usp_TraerSERIENS(ByVal Sucursal As String) As DataSet

        Try
            usp_TraerSERIENS = New DataSet
            MyBase.SQL = "usp_TraerSERIENS()"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", SqlDbType.Char, 2, Sucursal)


            MyBase.FillDataSet(usp_TraerSERIENS, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Serie(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 22/Mayo/2012 06:25 p.m.
            MyBase.SQL = "usp_Captura_Serie" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@serieb", SqlDbType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@sucursalb", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@statusb", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@marcab", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilonb", SqlDbType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@medidab", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@sucurdesb", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("sucurdes"))
            MyBase.AddParameter("@idfoliob", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))

            MyBase.AddParameter("@idarticulob", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@precioinib", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("precioini"))
            MyBase.AddParameter("@costoinib", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("costoini"))
            MyBase.AddParameter("@preciovtab", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("preciovta"))
            MyBase.AddParameter("@ultcostob", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("ultcosto"))
            MyBase.AddParameter("@proveedorsb", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("proveedors"))


            usp_Captura_Serie = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_EliminarSerie(ByVal Sucursal As String) As Boolean
        'mreyes 23/Febrero/2012 03:54 p.m.
        Try
            MyBase.SQL = "usp_EliminarSerie"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection

            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            'Execute the stored procedure
            usp_EliminarSerie = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Eliminar_VentasBase(ByVal Sucursal As String) As Boolean
        'mreyes 19/Febrero/2016 11:22 a.m.
        Try
            MyBase.SQL = "usp_Eliminar_VentasBase"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection

            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            'Execute the stored procedure
            usp_Eliminar_VentasBase = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraPrecios() As Boolean
        Try
            'mreyes 21/Noviembre/2018   11:01 a.m.
            MyBase.SQL = "usp_Generaprecios" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15


            usp_GeneraPrecios = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
