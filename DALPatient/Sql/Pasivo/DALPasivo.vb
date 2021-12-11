'Imports System.Data.Odbc
'mreyes 20/Febrero/2020 01:11 p.m.

Imports System.Data
Imports System.Data.SqlClient

Public Class DALPasivo
    ''''Inherits DALOdbc
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
    Public Function usp_PpalPasivoProveedores() As DataSet
        'mreyes 20/Febrero/2020 01:14 p.m.

        Try

            usp_PpalPasivoProveedores = New DataSet
            MyBase.SQL = "usp_PpalPasivoProveedores"
            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_PpalPasivoProveedores, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function


    Public Function usp_PpalAsigLiquidaciones(Opcion As Integer) As DataSet
        'mreyes 26/Febrero/2020 11:33 a.m.

        Try

            usp_PpalAsigLiquidaciones = New DataSet
            MyBase.SQL = "usp_PpalAsigLiquidaciones"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.SmallInt, 8, Opcion)

            MyBase.FillDataSet(usp_PpalAsigLiquidaciones, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_PpalPagosProveedores(FechaIni As Date, FechaFin As Date) As DataSet
        'mreyes 21/Febrero/2020 04:33 p.m.

        Try

            usp_PpalPagosProveedores = New DataSet
            MyBase.SQL = "usp_PpalPagosProveedores"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fechaini", SqlDbType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", SqlDbType.Date, 8, FechaFin)

            MyBase.FillDataSet(usp_PpalPagosProveedores, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_Captura_PasivoTemp(Opcion As Integer, Proveedor As String, Marca As String, IdFolio As Integer, Referenc As String, FecVenc As Date) As Boolean
        'mreyes 21/Marzo/2018   10:06 a.m.

        Try
            MyBase.SQL = "usp_Captura_PasivoTemp"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Proveedor", SqlDbType.VarChar, 3, Proveedor)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@IdFolio", SqlDbType.Int, 8, IdFolio)
            MyBase.AddParameter("@Referenc", SqlDbType.VarChar, 10, Referenc)


            MyBase.AddParameter("@fecvenc", SqlDbType.Date, 8, FecVenc)





            usp_Captura_PasivoTemp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraSeriesReciboMYSQL(Sucursal As String, Factprov As String) As Boolean
        'mreyes 22/Julio/2021   12:57 p.m.

        Try
            MyBase.SQL = "usp_GeneraSeriesReciboMYSQL"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Factprov", SqlDbType.VarChar, 6, Factprov)



            usp_GeneraSeriesReciboMYSQL = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraLiquidacionesPasivo() As Boolean
        'mreyes 28/Mayo/2021   07:03 p.m.

        Try
            MyBase.SQL = "usp_GeneraLiquidacionesPasivo"

            MyBase.InitializeCommand()




            usp_GeneraLiquidacionesPasivo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
