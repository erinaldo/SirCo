'Imports System.Data.Odbc
'mreyes 19/Agosto/2016  05:15 p.m.

Imports System.Data
Imports System.Data.SqlClient

Public Class DALMigracion
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


    Public Function usp_PpalProTraspDetNoAplica(ByVal IdSucursalB As Integer) As DataSet

        'mreyes 18/Agosto/2016  07:02 p.m.
        Try


            usp_PpalProTraspDetNoAplica = New DataSet
            MyBase.SQL = "usp_PpalProTraspDetNoAplica"


            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 16, IdSucursalB)



            MyBase.FillDataSet(usp_PpalProTraspDetNoAplica, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function
    Public Function usp_PpalProTrasp(ByVal Opcion As Integer, ByVal IdProTras As Integer, ByVal IdSucursal As Integer,
                                                ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Estatus As String) As DataSet
        'mreyes 06/Julio/2016
        Try


            usp_PpalProTrasp = New DataSet
            MyBase.SQL = "usp_PpalProTrasp"
            'MyBase.SQL = "CALL usp_PpalCatalogoEmpleado(?,?,?,?,?,?,?,?,?,?,?)"
            '@OpcionB int, @IdProTrasB int, 
            '@IdSucursalB int, @FechaInib date, @FechaFinb date, @EstatusB varchar(2)

            MyBase.InitializeCommand()
            MyBase.AddParameter("@OpcionB", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@IdProTrasB", SqlDbType.Int, 8, IdProTras)
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 16, IdSucursal)
            MyBase.AddParameter("@FechaInib", SqlDbType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.Date, 8, FechaFin)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 2, Estatus)


            MyBase.FillDataSet(usp_PpalProTrasp, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_TraerVendedor(IdEmpleado As Integer) As DataSet
        'mreyes 27/Marzo/2019   11:28 a.m.
        Try


            usp_TraerVendedor = New DataSet
            MyBase.SQL = "usp_TraerVendedor"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleadoB", SqlDbType.Int, 8, IdEmpleado)



            MyBase.FillDataSet(usp_TraerVendedor, "SirCoNomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_GeneraVentasBase(ByVal IdFechaIni As Integer, ByVal IdFechaFin As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As Boolean
        'mreyes 19/Agosto/2016  05:34 p.m.   
        Try


            MyBase.SQL = "usp_GeneraVentasBase"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFechaIni", SqlDbType.Int, 16, IdFechaIni)
            MyBase.AddParameter("@IdFechaFin", SqlDbType.Int, 16, IdFechaFin)
            MyBase.AddParameter("@FechaIni", SqlDbType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 8, FechaFin)



            usp_GeneraVentasBase = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_TraerMarcaPrincipal(ByVal Proveedor As String) As DataSet
        'mreyes 14/Marzo/2012 05:06 p.m.
        Try
            usp_TraerMarcaPrincipal = New DataSet
            MyBase.SQL = "CALL usp_TraerMarcaPrincipal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ProveedorB", SqlDbType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerMarcaPrincipal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_ProTraspArticulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Julio/2016   11:34 a.m.
        Try
            'MyBase.SQL = "CALL usp_Captura_Empleado(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            MyBase.SQL = "usp_Captura_ProTraspArticulo" 'Insert Query

            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@iddivisionesB", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("iddivisiones"))
            MyBase.AddParameter("@divisionB", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("division"))
            MyBase.AddParameter("@iddeptoB", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@deptob", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("depto"))
            MyBase.AddParameter("@idfamiliab", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idfamilia"))
            MyBase.AddParameter("@familiab", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("familia"))
            MyBase.AddParameter("@idlineab", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idlinea"))
            MyBase.AddParameter("@lineab", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("linea"))
            MyBase.AddParameter("@idl1b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl1"))
            MyBase.AddParameter("@l1b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l1"))
            MyBase.AddParameter("@idl2b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl2"))
            MyBase.AddParameter("@l2b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l2"))
            MyBase.AddParameter("@idl3b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl3"))
            MyBase.AddParameter("@l3b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l3"))
            MyBase.AddParameter("@idl4b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl4"))
            MyBase.AddParameter("@l4b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l4"))
            MyBase.AddParameter("@idl5b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl5"))
            MyBase.AddParameter("@l5b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l5"))
            MyBase.AddParameter("@idl6b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl5"))
            MyBase.AddParameter("@l6b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l6"))
            MyBase.AddParameter("@idl6b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl6"))
            MyBase.AddParameter("@idagrupacionb", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idagrupacion"))
            MyBase.AddParameter("@agrupacionb", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("agrupacion"))
            MyBase.AddParameter("@fechab", SqlDbType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@statusb", SqlDbType.VarChar, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@marcab", SqlDbType.VarChar, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilonb", SqlDbType.VarChar, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@idusuariob", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idusuario"))




            usp_Captura_ProTraspArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As String, ByVal idusuario As String) As Boolean

        'mreyes 19/Julio/2016   01:27 p.m.

        Try


            MyBase.SQL = "usp_GeneraProTraspArticulo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@iddivisiones", SqlDbType.VarChar, 60, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.VarChar, 60, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.VarChar, 6, idagrupacion)
            MyBase.AddParameter("@idusuario", SqlDbType.VarChar, 6, idusuario)


            'Execute the stored procedure
            usp_GeneraProTraspArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraAnaModArticulo(ByVal Opcion As Integer, ByVal Marca As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As String, ByVal idusuario As Integer) As Boolean

        'mreyes 16/Agosto/2016  04:27 p.m.

        Try


            MyBase.SQL = "usp_GeneraAnaModArticulo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 6, opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@iddivisiones", SqlDbType.VarChar, 60, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.VarChar, 60, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.VarChar, 6, idagrupacion)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)


            'Execute the stored procedure
            usp_GeneraAnaModArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As Integer, ByVal Propuesta As Integer) As DataSet
        'mreyes 21/Julio/2016   11:44 a.m.
        Try


            usp_TraerProTraspArticulo = New DataSet
            MyBase.SQL = "usp_TraerProTraspArticulo"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 6, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 6, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)

            MyBase.AddParameter("@propuesta", SqlDbType.Int, 6, Propuesta)


            MyBase.FillDataSet(usp_TraerProTraspArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_TraerAnaModArticulo(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer, ByVal idUsuario As Integer) As DataSet

        'mreyes 16/Agosto/2016  04:29 p.m.
        Try


            usp_TraerAnaModArticulo = New DataSet
            MyBase.SQL = "usp_TraerAnaModArticulo"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 6, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 6, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)

            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idUsuario)


            MyBase.FillDataSet(usp_TraerAnaModArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function
    Public Function usp_Captura_ProtraspDetNoaplica(ByVal Opcion As Integer, ByVal Serie As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Sucursal As String, ByVal Observa As String, ByVal IdUsuario As Integer) As Boolean
        'mreyes 18/Agosto/2016  05:40 p.m.

        Try
            MyBase.SQL = "usp_Captura_ProtraspDetNoaplica"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@observa", SqlDbType.VarChar, 200, Observa)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)



            usp_Captura_ProtraspDetNoaplica = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_ProtraspPropuesto(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal SucurOri As Integer, ByVal SucurDes As Integer, ByVal Ctd As Integer) As Boolean
        'mreyes 25/Julio/2016   01:23 p.m.

        Try
            MyBase.SQL = "usp_Captura_ProtraspPropuesto"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@SucurOri", SqlDbType.Int, 6, Sucurori)
            MyBase.AddParameter("@SucurDes", SqlDbType.Int, 6, SucurDes)
            MyBase.AddParameter("@ctd", SqlDbType.Int, 16, Ctd)



            usp_Captura_ProtraspPropuesto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraPeticionTraspaso(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String,
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String,
             ByVal idagrupacion As Integer, ByVal idusuario As Integer) As Boolean

        'mreyes 29/Julio/201612:06 p.m.

        Try


            MyBase.SQL = "usp_GeneraPeticionTraspaso"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 6, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 6, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 6, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)


            'Execute the stored procedure
            usp_GeneraPeticionTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_GeneraEstructura() As Boolean
        'mreyes 21/Noviembre/2018   11:18 a.m.   
        Try


            MyBase.SQL = "usp_GeneraEstructuraCompras"


            MyBase.InitializeCommand()

            usp_GeneraEstructura = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function
#End Region
End Class
