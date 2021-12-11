'Imports System.Data.Odbc
'mreyes 06/Junio/2017   12:52 p.m.

Imports System.Data
Imports System.Data.SqlClient

Public Class DALCreditoNuevo
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
    Public Function usp_PpalEstadoCartera(ByVal Opcion As Integer, ByVal IdGestor As String) As DataSet
        'fdoadame 30/Diciembre/2017   09:30 a.m.
        Try
            usp_PpalEstadoCartera = New DataSet
            MyBase.SQL = "usp_PpalEstadoCartera"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 3, Opcion)
            MyBase.AddParameter("@IdGestor", SqlDbType.VarChar, 5, IdGestor)
            MyBase.FillDataSet(usp_PpalEstadoCartera, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencido(Fecha As String) As DataSet
        'mreyes 12/Junio/2017   12:10 p.m.
        Try
            usp_PpalVencido = New DataSet
            MyBase.SQL = "usp_PpalVencido"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.FillDataSet(usp_PpalVencido, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencidoDias(Fecha As String) As DataSet
        'mreyes 19/Julio/2017   05:11 p.m.
        Try
            usp_PpalVencidoDias = New DataSet
            MyBase.SQL = "usp_PpalVencidoDias"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.FillDataSet(usp_PpalVencidoDias, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencido() As DataSet
        'mreyes 28/Noviembre/2017   12:13 p.m.
        Try
            usp_PpalVencido = New DataSet
            MyBase.SQL = "usp_PpalVencido"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalVencido, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencidoGestor(IdGestor As Integer) As DataSet
        'mreyes 29/Noviembre/2017   04:29 p.m.
        Try
            usp_PpalVencidoGestor = New DataSet
            MyBase.SQL = "usp_PpalVencidoGestor"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idgestor", SqlDbType.Int, 86, IdGestor)
            MyBase.FillDataSet(usp_PpalVencidoGestor, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalVencidoxAnio() As DataSet
        'mreyes 28/Noviembre/2017   12:13 p.m.
        Try
            usp_PpalVencidoxAnio = New DataSet
            MyBase.SQL = "usp_PpalVencidoxAnio"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalVencidoxAnio, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalGestoria() As DataSet
        'mreyes 26/Octubre/2017   04:57 p.m.
        Try
            usp_PpalGestoria = New DataSet
            MyBase.SQL = "usp_PpalGestoria"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalGestoria, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerGestoriaxDistrib(Distrib As String) As DataSet
        'mreyes 03/Noviembre/2017   10:20 a.m.
        Try
            usp_TraerGestoriaxDistrib = New DataSet
            MyBase.SQL = "usp_TraerGestoriaxDistrib"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.FillDataSet(usp_TraerGestoriaxDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCPEstadoCiudadColonia(Opcion As Integer, CodigoPostal As String, IdEstado As Integer, IdCiudad As Integer, IdColonia As Integer) As DataSet
        'mreyes 09/Febrero/2018 04:58 p.m.
        Try
            usp_TraerCPEstadoCiudadColonia = New DataSet
            MyBase.SQL = "usp_TraerCPEstadoCiudadColonia"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@CodigoPostal", SqlDbType.VarChar, 5, CodigoPostal)
            MyBase.AddParameter("@IdEstado", SqlDbType.Int, 16, IdEstado)
            MyBase.AddParameter("@IdCiudad", SqlDbType.Int, 16, IdCiudad)
            MyBase.AddParameter("@IdColonia", SqlDbType.Int, 16, IdColonia)
            MyBase.FillDataSet(usp_TraerCPEstadoCiudadColonia, "SirCoControl")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistrib(IdDistrib As Integer) As DataSet
        'mreyes 07/Febrero/2018 12:41 p.m.
        Try
            usp_TraerDistrib = New DataSet
            MyBase.SQL = "usp_TraerDistrib"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, IdDistrib)
            MyBase.FillDataSet(usp_TraerDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribDocumentos(IdDistrib As Integer) As DataSet
        'mreyes 19/Septiembre/2018  11:57 a.m.
        Try
            usp_TraerDistribDocumentos = New DataSet
            MyBase.SQL = "usp_TraerDistribDocumentos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, IdDistrib)
            MyBase.FillDataSet(usp_TraerDistribDocumentos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribComerciales(IdDistrib As Integer) As DataSet
        'mreyes 19/Septiembre/2018  11:57 a.m.
        Try
            usp_TraerDistribComerciales = New DataSet
            MyBase.SQL = "usp_TraerDistribComerciales"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, IdDistrib)
            MyBase.FillDataSet(usp_TraerDistribComerciales, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMensPaga() As DataSet
        'mreyes 12/Abril/2018   05:10 p.m.
        Try
            usp_TraerMensPaga = New DataSet
            MyBase.SQL = "usp_TraerMensPaga"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_TraerMensPaga, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdDistrib(Distrib As String) As DataSet
        'mreyes 13/Febrero/2018 04:03 p.m.
        Try
            usp_TraerIdDistrib = New DataSet
            MyBase.SQL = "usp_TraerIdDistrib"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.FillDataSet(usp_TraerIdDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCallCenter() As DataSet
        'mreyes 29/Octubre/2017   12:43 p.m.
        Try
            usp_PpalCallCenter = New DataSet
            MyBase.SQL = "usp_PpalCallCenter"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalCallCenter, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalBonoSemanal(IdPeriodo As Integer, idsucursal As Integer) As DataSet
        'mreyes 12/Junio/2018   01:15 p.m.
        Try
            usp_PpalBonoSemanal = New DataSet
            MyBase.SQL = "usp_PpalBonoSemanal"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idperiodo", SqlDbType.Int, 8, IdPeriodo)
            MyBase.AddParameter("@idsucursal", SqlDbType.Int, 8, idsucursal)
            MyBase.FillDataSet(usp_PpalBonoSemanal, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalRelaciones(Opcion As Integer, Distrib1 As String, Distrib2 As String, TipoDistrib As String, FechaCorte As Date, IdSucursal As Integer) As DataSet
        'mreyes 10/Abril/2018   11:45 a.m.
        Try
            usp_PpalRelaciones = New DataSet
            MyBase.SQL = "usp_PpalRelaciones"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@distrib1", SqlDbType.VarChar, 6, Distrib1)
            MyBase.AddParameter("@distrib2", SqlDbType.VarChar, 6, Distrib2)
            MyBase.AddParameter("@tipodistrib", SqlDbType.VarChar, 50, TipoDistrib)
            MyBase.AddParameter("@fechacorte", SqlDbType.VarChar, 10, FechaCorte)
            MyBase.AddParameter("@idsucursal", SqlDbType.Int, 8, IdSucursal)
            MyBase.FillDataSet(usp_PpalRelaciones, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalRelacionesBlindaje(Opcion As Integer, Distrib1 As String, Distrib2 As String, TipoDistrib As String, FechaCorte As Date, IdSucursal As Integer) As DataSet
        'mreyes 14/Noviembre/2019   05:57 a.m.
        Try
            usp_PpalRelacionesBlindaje = New DataSet
            MyBase.SQL = "usp_PpalRelacionesBlindaje"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@distrib1", SqlDbType.VarChar, 6, Distrib1)
            MyBase.AddParameter("@distrib2", SqlDbType.VarChar, 6, Distrib2)
            MyBase.AddParameter("@tipodistrib", SqlDbType.VarChar, 50, TipoDistrib)
            MyBase.AddParameter("@fechacorte", SqlDbType.VarChar, 10, FechaCorte)
            MyBase.AddParameter("@idsucursal", SqlDbType.Int, 8, IdSucursal)
            MyBase.FillDataSet(usp_PpalRelacionesBlindaje, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDistrib() As DataSet
        'mreyes 07/Febrero/2018 12:30 p.m.
        Try
            usp_PpalDistrib = New DataSet
            MyBase.SQL = "usp_PpalDistrib"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDistribTarjetaHabiente() As DataSet
        'mreyes 07/Febrero/2018 12:30 p.m.
        Try
            usp_PpalDistribTarjetaHabiente = New DataSet
            MyBase.SQL = "usp_PpalDistribTarjetaHabiente"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCallCenterAdmon(FechaIni As Date, FechaFin As Date, FechaPromesadoIni As Date,
                                            FechaPromesadoFin As Date, IdEmpleado As Integer) As DataSet
        'mreyes 29/Octubre/2017   12:43 p.m.
        Try
            usp_PpalCallCenterAdmon = New DataSet
            MyBase.SQL = "usp_PpalCallCenterAdmon"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fechaini", SqlDbType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 10, FechaFin)
            MyBase.AddParameter("@FechaPromesadoIni", SqlDbType.Date, 10, FechaPromesadoIni)
            MyBase.AddParameter("@FechaPromesadoFin", SqlDbType.Date, 10, FechaPromesadoFin)
            MyBase.AddParameter("@idempleado", SqlDbType.Int, 8, IdEmpleado)
            MyBase.FillDataSet(usp_PpalCallCenterAdmon, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDistribLimites() As DataSet
        'mreyes 06/Junio/2017   12:52 p.m.
        Try
            usp_PpalDistribLimites = New DataSet
            MyBase.SQL = "usp_PpalDistribLimites"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_PpalDistribLimites, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_AumentoLimite(Opcion As Integer, Distrib As String, ByVal Fecha As Date, NuevoLimite As Decimal, idusuario As Integer) As Boolean
        'mreyes 06/Junio/2017   04:42 p.m.
        Try
            MyBase.SQL = "usp_AumentoLimite"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@nuevolimite", SqlDbType.Decimal, 12, NuevoLimite)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)
            'Execute the stored procedure
            usp_AumentoLimite = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CallCenter(Opcion As Integer, IdCallCenter As Integer, Distrib As String, ByVal Fecha As Date, FechaPromesado As Date,
                                           adeudo As Decimal, comentarios As String, llamada As Integer, idusuario As Integer) As Boolean
        'mreyes 03/Noviembre/2017   12:24 p.m.
        Try
            MyBase.SQL = "usp_Captura_CallCenter"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@idcallcenter", SqlDbType.Int, 16, IdCallCenter)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@FechaPromesado", SqlDbType.Date, 10, FechaPromesado)
            MyBase.AddParameter("@adeudo", SqlDbType.Decimal, 18, adeudo)
            MyBase.AddParameter("@comentarios", SqlDbType.VarChar, 250, comentarios)
            MyBase.AddParameter("@llamada", SqlDbType.Int, 6, llamada)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)
            'Execute the stored procedure
            usp_Captura_CallCenter = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_GestoriaAsignada(Opcion As Integer, idgestor As Integer, distrib As String, corte1 As Decimal,
                                                 corte2 As Decimal, corte3 As Decimal, corte4 As Decimal,
                                                 corten As Decimal, vencido As Decimal, ultpago As Decimal,
                                                 ultfechapago As Date, idusuario As Integer) As Boolean
        'mreyes 24/Noviembre/2017   12:25 p.m.
        Try
            MyBase.SQL = "usp_Captura_GestoriaAsignada"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@idgestor", SqlDbType.Int, 16, idgestor)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, distrib)
            MyBase.AddParameter("@corte1", SqlDbType.Decimal, 18, corte1)
            MyBase.AddParameter("@corte2", SqlDbType.Decimal, 18, corte2)
            MyBase.AddParameter("@corte3", SqlDbType.Decimal, 18, corte3)
            MyBase.AddParameter("@corte4", SqlDbType.Decimal, 18, corte4)
            MyBase.AddParameter("@corten", SqlDbType.Decimal, 18, corten)
            MyBase.AddParameter("@vencido", SqlDbType.Decimal, 18, vencido)
            MyBase.AddParameter("@ultpago", SqlDbType.Decimal, 18, ultpago)
            MyBase.AddParameter("@ultfechapago", SqlDbType.Date, 10, ultfechapago)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)
            'Execute the stored procedure
            usp_Captura_GestoriaAsignada = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_VencidoAsignada(Opcion As Integer, Fecha As Date, Distrib As String, IdGestor As Integer, IdAsigna As Integer) As Boolean
        'mreyes 28/Noviembre/2017   06:08 p.m.
        Try
            MyBase.SQL = "usp_Captura_VencidoAsignada"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@idgestor", SqlDbType.Int, 16, IdGestor)
            MyBase.AddParameter("@idasigna", SqlDbType.Int, 6, IdAsigna)
            'Execute the stored procedure
            usp_Captura_VencidoAsignada = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_RutaGestor(Opcion As Integer, Fecha As Date, Distrib As String, IdGestor As Integer) As Boolean
        'mreyes 08/Diciembre/2017   12:16 p.m.
        Try
            MyBase.SQL = "usp_Captura_RutaGestor"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@idgestor", SqlDbType.Int, 16, IdGestor)
            'Execute the stored procedure
            usp_Captura_RutaGestor = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_DistribFirmas(Opcion As Integer, IdDistrib As Integer, Principal As Integer,
                                               Nombre As String, Domicilio As String, NumFirma As Integer,
                                               firma As Byte(), pagare As Byte(), idusuario As Integer, idusuariomodif As Integer) As Boolean
        'mreyes 13/Febrero/2018 04:14 p.m.
        Try
            MyBase.SQL = "usp_Captura_DistribFirmas"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, IdDistrib)
            MyBase.AddParameter("@principal", SqlDbType.Int, 16, Principal)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 250, Nombre)
            MyBase.AddParameter("@domicilio", SqlDbType.VarChar, 250, Domicilio)
            MyBase.AddParameter("@numfirma", SqlDbType.Int, 8, NumFirma)
            MyBase.AddParameter("@firma", SqlDbType.Image, firma.Length, firma)
            MyBase.AddParameter("@pagare", SqlDbType.Image, pagare.Length, pagare)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            'Execute the stored procedure
            usp_Captura_DistribFirmas = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DistribDocumentos(Opcion As Integer, IdDistrib As Integer, Documento As String,
                                              NumImagen As Integer,
                                               Imagen As Byte(), idusuario As Integer, idusuariomodif As Integer) As Boolean
        'mreyes 12/Julio/2018   01:08 p.m.
        Try
            MyBase.SQL = "usp_Captura_DistribDocumentos"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, IdDistrib)
            MyBase.AddParameter("@documento", SqlDbType.VarChar, 50, Documento)
            MyBase.AddParameter("@numimagen", SqlDbType.Int, 16, NumImagen)
            MyBase.AddParameter("@imagen", SqlDbType.Image, Imagen.Length, Imagen)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 16, idusuariomodif)
            'Execute the stored procedure
            usp_Captura_DistribDocumentos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DistribComerciales(Opcion As Integer, IdDistrib As Integer, IdNegExterno As Integer, Comercial As String,
                                                   NoCuenta As String, limite As Decimal, EdoCuenta As Byte(), EdoCuenta1 As Byte(),
                                                   idusuario As Integer) As Boolean
        'mreyes 15/Agosto/2018 10:10 a.m.
        Try
            MyBase.SQL = "usp_Captura_DistribComerciales"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@iddistrib", SqlDbType.Int, 16, IdDistrib)
            MyBase.AddParameter("@IdNegExterno", SqlDbType.Int, 16, IdNegExterno)
            MyBase.AddParameter("@comercial", SqlDbType.VarChar, 50, Comercial)
            MyBase.AddParameter("@nocuenta", SqlDbType.VarChar, 50, NoCuenta)
            MyBase.AddParameter("@limite", SqlDbType.Decimal, 18, limite)
            MyBase.AddParameter("@edocuenta", SqlDbType.Image, EdoCuenta.Length, EdoCuenta)
            MyBase.AddParameter("@edocuenta1", SqlDbType.Image, EdoCuenta.Length, EdoCuenta1)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 16, idusuario)
            'Execute the stored procedure
            usp_Captura_DistribComerciales = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPagosDistribuidorXCorte(Opcion As Integer, FechaInicio As String, FechaFin As String, Distrib As String) As DataSet
        Try
            usp_PpalPagosDistribuidorXCorte = New DataSet
            MyBase.SQL = "usp_PpalPagosDistribuidorXCorte"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 10, Opcion)
            MyBase.AddParameter("@FechaInicio", SqlDbType.Date, 10, FechaInicio)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 10, FechaFin)
            MyBase.AddParameter("@distrib", SqlDbType.NVarChar, 10, Distrib)
            MyBase.FillDataSet(usp_PpalPagosDistribuidorXCorte, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPagosDistribuidor(FechaInicio As String, FechaFin As String, Distrib As String) As DataSet
        Try
            usp_PpalPagosDistribuidor = New DataSet
            MyBase.SQL = "usp_PpalPagosDistribuidor"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaInicio", SqlDbType.Date, 10, FechaInicio)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 10, FechaFin)
            MyBase.AddParameter("@distrib", SqlDbType.NVarChar, 10, Distrib)
            MyBase.FillDataSet(usp_PpalPagosDistribuidor, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ValidarDistrib(Distrib As String) As DataSet
        Try
            usp_ValidarDistrib = New DataSet
            MyBase.SQL = "usp_ValidarDistrib"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@distrib", SqlDbType.NVarChar, 10, Distrib)
            MyBase.FillDataSet(usp_ValidarDistrib, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function


    Public Function usp_PpalComisionesCarteraVencida(FechaInicio As String, FechaFin As String, Porcentaje As Integer, idgestor As String, opcion As Integer) As DataSet
        'fdoadame 12/Diciembre/2017   10:30 p.m.
        Try
            usp_PpalComisionesCarteraVencida = New DataSet
            MyBase.SQL = "usp_PpalComisionesCarteraVencida"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fechaInicio", SqlDbType.Date, 10, FechaInicio)
            MyBase.AddParameter("@fechaFin", SqlDbType.Date, 10, FechaFin)
            MyBase.AddParameter("@porcentaje", SqlDbType.Int, 3, Porcentaje)
            MyBase.AddParameter("@idgestor", SqlDbType.VarChar, 4, idgestor)
            MyBase.AddParameter("@opcion", SqlDbType.SmallInt, 1, opcion)
            MyBase.FillDataSet(usp_PpalComisionesCarteraVencida, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Distrib(Opcion As Integer, IdPromotor As Integer, IdCoordinador As Integer, IdTienda As Integer,
                                        Distrib As String, TipoDistrib As String, IdTipocredito As Integer, IdPeriodicidad As Integer, IdEstatus As Integer,
                                        IdAval As Integer, NombreCompleto As String, Nombre As String, Appaterno As String,
                                        ApMaterno As String, Sexo As String, FechaNacim As Date, IdEStadoCivil As Integer,
                                        Dependientes As Integer, IdEstado As Integer, IdCiudad As Integer, IdColonia As Integer,
                                        CodigoPostal As Integer, Calle As String, Numero As Integer, EntreCalles As String,
                                        IdTipoVivienda As Integer, AntiguedadVivienda As Integer, ValorCasa As Decimal, ValorAutos As Decimal,
                                       TelCasa As String, TelOtro As String, Celular1 As String, Celular2 As String,
                                        Email As String, Empresa As String, DireccionEmpresa As String, Puesto As String, AntiguedadEmpresa As Integer, IngresoMensual As Decimal,
                                        OtrosIngresos As Decimal, IngresoTotal As Decimal, LimiteCredito As Decimal,
                                        Saldo As Decimal, Disponible As Decimal, LimiteVale As Decimal, Contravale As Integer,
                                        NegExt As Integer, Promocion As Integer, NombreConyuge As String,
                                        AppaternoConyuge As String, ApMaternoConyuge As String, EmpresaConyuge As String,
                                        PuestoConyuge As String, AntiguedadConyuge As Integer, TelConyuge As String,
                                        CelConyuge As String, IngresoConyuge As Decimal, NombreMadre As String,
                                        NombrePadre As String, DireccionPadres As String, TelPadres As String,
                                        CelPadres As String, TelPadres1 As String, TelPadres2 As String,
                                        NombreAmigo As String, DireccionAmigo As String, TelAmigo As String, CelAmigo As String,
                                        IdUsuario As Integer, IdUsuarioModif As Integer) As Boolean
        'mreyes 11/Julio/2018   05:32 p.m.
        Try
            MyBase.SQL = "usp_Captura_Distrib"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@idpromotor", SqlDbType.Int, 16, IdPromotor)
            MyBase.AddParameter("@idcoordinador", SqlDbType.Int, 16, IdCoordinador)
            MyBase.AddParameter("@idtienda", SqlDbType.Int, 16, IdTienda)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@tipodistrib", SqlDbType.VarChar, 50, TipoDistrib)
            MyBase.AddParameter("@idtipocredito", SqlDbType.Int, 6, IdTipocredito)
            MyBase.AddParameter("@idperiodicidad", SqlDbType.Int, 6, IdPeriodicidad)
            MyBase.AddParameter("@idestatus", SqlDbType.Int, 6, IdEstatus)
            MyBase.AddParameter("@idaval", SqlDbType.Int, 6, IdAval)
            MyBase.AddParameter("@nombrecompleto", SqlDbType.VarChar, 250, NombreCompleto)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 100, Nombre)
            MyBase.AddParameter("@appaterno", SqlDbType.VarChar, 100, Appaterno)
            MyBase.AddParameter("@apmaterno", SqlDbType.VarChar, 100, ApMaterno)
            MyBase.AddParameter("@sexo", SqlDbType.VarChar, 1, Sexo)
            MyBase.AddParameter("@fechanacim", SqlDbType.Date, 10, FechaNacim)
            MyBase.AddParameter("@idestadocivil", SqlDbType.Int, 6, IdEStadoCivil)
            MyBase.AddParameter("@dependientes", SqlDbType.Int, 6, Dependientes)
            MyBase.AddParameter("@idestado", SqlDbType.Int, 6, IdEstado)
            MyBase.AddParameter("@idciudad", SqlDbType.Int, 6, IdCiudad)
            MyBase.AddParameter("@idcolonia", SqlDbType.Int, 6, IdColonia)
            MyBase.AddParameter("@codigopostal", SqlDbType.Int, 6, CodigoPostal)
            MyBase.AddParameter("@calle", SqlDbType.VarChar, 250, Calle)
            MyBase.AddParameter("@numero", SqlDbType.Int, 6, Numero)
            MyBase.AddParameter("@entrecalles", SqlDbType.VarChar, 250, EntreCalles)
            MyBase.AddParameter("@idtipovivienda", SqlDbType.Int, 6, IdTipoVivienda)
            MyBase.AddParameter("@antiguedadvivienda", SqlDbType.Int, 6, AntiguedadVivienda)
            MyBase.AddParameter("@valorcasa", SqlDbType.Decimal, 18, ValorCasa)
            MyBase.AddParameter("@valorautos", SqlDbType.Decimal, 18, ValorAutos)
            MyBase.AddParameter("@telcasa", SqlDbType.VarChar, 50, TelCasa)
            MyBase.AddParameter("@telotro", SqlDbType.VarChar, 50, TelOtro)
            MyBase.AddParameter("@celular1", SqlDbType.VarChar, 10, Celular1)
            MyBase.AddParameter("@celular2", SqlDbType.VarChar, 10, Celular2)
            MyBase.AddParameter("@email", SqlDbType.VarChar, 150, Email)
            MyBase.AddParameter("@empresa", SqlDbType.VarChar, 150, Empresa)
            MyBase.AddParameter("@direccionempresa", SqlDbType.VarChar, 150, DireccionEmpresa)
            MyBase.AddParameter("@puesto", SqlDbType.VarChar, 50, Puesto)
            MyBase.AddParameter("@antiguedadempresa", SqlDbType.Int, 6, AntiguedadEmpresa)
            MyBase.AddParameter("@ingresomensual", SqlDbType.Decimal, 18, IngresoMensual)
            MyBase.AddParameter("@otrosingresos", SqlDbType.Decimal, 18, OtrosIngresos)
            MyBase.AddParameter("@ingresototal", SqlDbType.Decimal, 18, IngresoTotal)
            MyBase.AddParameter("@limitecredito", SqlDbType.Decimal, 18, LimiteCredito)
            MyBase.AddParameter("@saldo", SqlDbType.Decimal, 18, Saldo)
            MyBase.AddParameter("@disponible", SqlDbType.Decimal, 18, Disponible)
            MyBase.AddParameter("@limitevale", SqlDbType.Decimal, 18, LimiteVale)
            MyBase.AddParameter("@contravale", SqlDbType.Int, 6, Contravale)
            MyBase.AddParameter("@negext", SqlDbType.Int, 6, NegExt)
            MyBase.AddParameter("@promocion", SqlDbType.Int, 6, NegExt)
            MyBase.AddParameter("@nombreconyuge", SqlDbType.VarChar, 150, NombreConyuge)
            MyBase.AddParameter("@appaternoconyuge", SqlDbType.VarChar, 50, AppaternoConyuge)
            MyBase.AddParameter("@apmaternoconyuge", SqlDbType.VarChar, 50, ApMaternoConyuge)
            MyBase.AddParameter("@empresaconyuge", SqlDbType.VarChar, 50, EmpresaConyuge)
            MyBase.AddParameter("@puestoconyuge", SqlDbType.VarChar, 50, PuestoConyuge)
            MyBase.AddParameter("@antiguedadconyuge", SqlDbType.Int, 6, AntiguedadConyuge)
            MyBase.AddParameter("@telconyuge", SqlDbType.VarChar, 20, TelConyuge)
            MyBase.AddParameter("@celconyuge", SqlDbType.VarChar, 10, CelConyuge)
            MyBase.AddParameter("@ingresoconyuge", SqlDbType.Decimal, 18, IngresoConyuge)
            MyBase.AddParameter("@nombremadre", SqlDbType.VarChar, 200, NombreMadre)
            MyBase.AddParameter("@nombrepadre", SqlDbType.VarChar, 200, NombrePadre)
            MyBase.AddParameter("@direccionpadres", SqlDbType.VarChar, 250, DireccionPadres)
            MyBase.AddParameter("@telpadres", SqlDbType.VarChar, 20, TelPadres)
            MyBase.AddParameter("@celpadres", SqlDbType.VarChar, 20, CelPadres)
            MyBase.AddParameter("@telpadres1", SqlDbType.VarChar, 20, TelPadres1)
            MyBase.AddParameter("@telpadres2", SqlDbType.VarChar, 20, TelPadres2)
            MyBase.AddParameter("@nombreamigo", SqlDbType.VarChar, 250, NombreAmigo)
            MyBase.AddParameter("@direccionamigo", SqlDbType.VarChar, 250, DireccionAmigo)
            MyBase.AddParameter("@telamigo", SqlDbType.VarChar, 20, TelAmigo)
            MyBase.AddParameter("@celamigo", SqlDbType.VarChar, 10, CelAmigo)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, IdUsuario)
            MyBase.AddParameter("@idusuariomodif", SqlDbType.Int, 6, IdUsuarioModif)
            'Execute the stored procedure
            usp_Captura_Distrib = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraEstructuraComision(IdPeriodo As Integer) As Boolean
        'mreyes 02/Octubre/2018 09:36 a.m.
        Try
            MyBase.SQL = "usp_GeneraEstructuraComision"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@idperiodo", SqlDbType.Int, 6, IdPeriodo)
            'Execute the stored procedure
            usp_GeneraEstructuraComision = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFumComisionEmp() As DataSet
        'mreyes 02/Octubre/2018 11:11 a.m.
        Try
            usp_TraerFumComisionEmp = New DataSet
            MyBase.SQL = "usp_TraerFumComisionEmp"
            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_TraerFumComisionEmp, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCargo(Sucursal As String, Nota As String) As DataSet
        'mreyes 22/Noviembre/2018   10:47 a.m.
        Try
            usp_TraerCargo = New DataSet
            MyBase.SQL = "usp_TraerCargo"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Nota", SqlDbType.VarChar, 6, Nota)
            MyBase.FillDataSet(usp_TraerCargo, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ModificarCargo(Sucursal As String, Nota As String, Vale As String,
                                       Distrib As String, NombreCliente As String, Apellp As String, Apellm As String,
                                       FechaAplicar As Date, SucCte As String, Cliente As String, IdUsuario As Integer) As Boolean
        'mreyes 21/Noviembre/2018   12:54 p.m.
        Try
            ' usp_ModificarCargo()
            MyBase.SQL = "usp_ModificarCargo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@nota", SqlDbType.VarChar, 6, Nota)
            MyBase.AddParameter("@vale", SqlDbType.VarChar, 20, Vale)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@NombreCliente", SqlDbType.VarChar, 60, NombreCliente)
            MyBase.AddParameter("@Apellp", SqlDbType.VarChar, 60, Apellp)
            MyBase.AddParameter("@Apellm", SqlDbType.VarChar, 60, Apellm)
            MyBase.AddParameter("@FechaAplicar", SqlDbType.Date, 10, FechaAplicar)
            MyBase.AddParameter("@SucCte", SqlDbType.VarChar, 2, SucCte)
            MyBase.AddParameter("@Cliente", SqlDbType.VarChar, 6, Cliente)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, IdUsuario)
            'Execute the stored procedure
            usp_ModificarCargo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ModificarSoloCalzado(Distrib As String, SoloCalzado As Integer) As Boolean
        'mreyes 26/Noviembre/2018   04:00 p.m.
        Try
            ' usp_ModificarCargo()
            MyBase.SQL = "usp_ModificarSoloCalzado"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@solocalzado", SqlDbType.SmallInt, 6, SoloCalzado)
            'Execute the stored procedure
            usp_ModificarSoloCalzado = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_MovimientosDistrib(Opcion As Integer, Distrib As String, SoloCalzado As Integer, Promocion As Integer,
                                           LimiteVale As Decimal, LimiteCredito As Decimal, Estatus As String) As Boolean
        'mreyes 27/Noviembre/2018   04:00 p.m.
        Try
            ' usp_ModificarCargo()
            MyBase.SQL = "usp_MovimientosDistrib"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@solocalzado", SqlDbType.Int, 6, SoloCalzado)
            MyBase.AddParameter("@Promocion", SqlDbType.Int, 6, Promocion)
            MyBase.AddParameter("@LimiteVale", SqlDbType.Decimal, 18, LimiteVale)
            MyBase.AddParameter("@LimiteCredito", SqlDbType.Decimal, 18, LimiteCredito)
            MyBase.AddParameter("@estatus", SqlDbType.VarChar, 16, Estatus)
            'Execute the stored procedure
            usp_MovimientosDistrib = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCortesCaja(Opcion As Integer, Distrib As String) As DataSet
        'mreyes 27/Noviembre/2018   05:26 p.m.
        Try
            usp_TraerCortesCaja = New DataSet
            MyBase.SQL = "usp_TraerCortesCaja"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.FillDataSet(usp_TraerCortesCaja, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioPago(Sucursal As String) As DataSet
        'mreyes 28/Noviembre/2018   10:40 a.m.
        Try
            usp_TraerFolioPago = New DataSet
            MyBase.SQL = "usp_TraerFolioPago"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerFolioPago, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPago(Opcion As Integer, sucursalb As String, Foliob As String, DistribB As String,
                                           statusb As String, FechaB As Date, subtotalb As Decimal, descuentob As Decimal, descuentoadicionalb As Decimal,
                                           interesb As Decimal, interesmorb As Decimal, gastoscobranzab As Decimal, importeb As Decimal,
                                           vencidob As Decimal, descuentovencidob As Decimal, cobradorb As Integer, idconveniob As Integer, idusuariob As Integer,
                                           idusuariocancelab As Integer) As Boolean

        'mreyes 28/Noviembre/2018   12:26 p.m.
        Try
            MyBase.SQL = "usp_CapturaPago"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@sucursalb", SqlDbType.VarChar, 2, sucursalb)
            MyBase.AddParameter("@foliob", SqlDbType.VarChar, 6, Foliob)
            MyBase.AddParameter("@distribb", SqlDbType.VarChar, 6, DistribB)
            MyBase.AddParameter("@statusb", SqlDbType.VarChar, 2, statusb)
            MyBase.AddParameter("@fechab", SqlDbType.Date, 10, FechaB)
            MyBase.AddParameter("@subtotalb", SqlDbType.Decimal, 18, subtotalb)
            MyBase.AddParameter("@descuentob", SqlDbType.Decimal, 18, descuentob)
            MyBase.AddParameter("@descuentoadicionalb", SqlDbType.Decimal, 18, descuentoadicionalb)
            MyBase.AddParameter("@interesb", SqlDbType.Decimal, 18, interesb)
            MyBase.AddParameter("@interesmorb", SqlDbType.Decimal, 18, interesmorb)
            MyBase.AddParameter("@gastoscobranzab", SqlDbType.Decimal, 18, gastoscobranzab)
            MyBase.AddParameter("@importeb", SqlDbType.Decimal, 18, importeb)
            MyBase.AddParameter("@vencidob", SqlDbType.Decimal, 18, vencidob)
            MyBase.AddParameter("@descuentovencidob", SqlDbType.Decimal, 18, descuentovencidob)
            MyBase.AddParameter("@cobradorb", SqlDbType.Int, 8, cobradorb)
            MyBase.AddParameter("@idconveniob", SqlDbType.Int, 8, idconveniob)
            MyBase.AddParameter("@idusuariob", SqlDbType.Int, 6, idusuariob)
            MyBase.AddParameter("@idusuariocancelab", SqlDbType.Int, 6, idusuariocancelab)
            'Execute the stored procedure
            usp_CapturaPago = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPagoDet(Opcion As Integer, idpagos As Integer, sucursal As String, sucnot As String, nota As String,
        pago As Integer, subtotal As Decimal, descuento As Decimal,
        descuentoadicional As Decimal, interes As Decimal, interesmoratorio As Decimal, gastoscobranza As Decimal,
        importe As Decimal, vencido As Decimal, descuentovencido As Decimal,
        numpago As Integer, pagado As Integer, porcdescto As Decimal, porcdesctoadicional As Decimal,
        porcdesctovencido As Decimal, idusuario As Integer) As Boolean
        'mreyes 07/Diciembre/2018   12:06 p.m.
        Try
            MyBase.SQL = "usp_CapturaPagoDet"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@idpagos", SqlDbType.Int, 8, idpagos)
            MyBase.AddParameter("@sucursal", SqlDbType.VarChar, 2, sucursal)
            MyBase.AddParameter("@sucnot", SqlDbType.VarChar, 2, sucnot)
            MyBase.AddParameter("@nota", SqlDbType.VarChar, 6, nota)
            MyBase.AddParameter("@pago", SqlDbType.Int, 6, pago)
            MyBase.AddParameter("@subtotal", SqlDbType.Decimal, 18, subtotal)
            MyBase.AddParameter("@descuento", SqlDbType.Decimal, 18, descuento)
            MyBase.AddParameter("@descuentoadicional", SqlDbType.Decimal, 18, descuentoadicional)
            MyBase.AddParameter("@interes", SqlDbType.Decimal, 18, interes)
            MyBase.AddParameter("@interesmoratorio", SqlDbType.Decimal, 18, interesmoratorio)
            MyBase.AddParameter("@gastoscobranza", SqlDbType.Decimal, 18, gastoscobranza)
            MyBase.AddParameter("@importe", SqlDbType.Decimal, 18, importe)
            MyBase.AddParameter("@vencido", SqlDbType.Decimal, 18, vencido)
            MyBase.AddParameter("@descuentovencido", SqlDbType.Decimal, 18, descuentovencido)
            MyBase.AddParameter("@numpago", SqlDbType.Int, 8, numpago)
            MyBase.AddParameter("@pagado", SqlDbType.Int, 8, pagado)
            MyBase.AddParameter("@porcdescto", SqlDbType.Decimal, 18, porcdescto)
            MyBase.AddParameter("@porcdesctoadicional", SqlDbType.Decimal, 18, porcdesctoadicional)
            MyBase.AddParameter("@porcdesctovencido", SqlDbType.Decimal, 18, porcdesctovencido)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, idusuario)
            'Execute the stored procedure
            usp_CapturaPagoDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdPagoDistrib(Opcion As Integer, DistribB As String, SucursalB As String, IdUsuarioB As Integer, SucNotB As String, NotaB As String, PagoB As Integer) As DataSet
        'mreyes 28/Noviembre/2018   04:53 p.m.
        Try
            usp_TraerIdPagoDistrib = New DataSet
            MyBase.SQL = "usp_TraerIdPagoDistrib"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 2, Opcion)
            MyBase.AddParameter("@DistribB", SqlDbType.VarChar, 6, DistribB)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, SucursalB)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.Int, 8, IdUsuarioB)
            MyBase.AddParameter("@SucNotB", SqlDbType.VarChar, 2, SucNotB)
            MyBase.AddParameter("@NotaB", SqlDbType.VarChar, 6, NotaB)
            MyBase.AddParameter("@PagoB", SqlDbType.Int, 8, PagoB)
            MyBase.FillDataSet(usp_TraerIdPagoDistrib, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraDetallePago(Opcion As Integer, Sucursal As String, Distrib As String, Apagar As Decimal, Descuento As Decimal, IdPago As Integer, IdUsuario As Integer) As Boolean
        'mreyes 30/Noviembre/2018   01:09 p.m.
        Try
            'usp_ActualizarPlanPagos(Opcion As Integer, Distrib As String, Sucursal As String, Nota As String, Pago As Integer, Abono As Integer, FechaPago As Date, IdPago As Integer, IdUsuario As Integer)
            MyBase.SQL = "usp_GeneraDetallePago"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@apagar", SqlDbType.Decimal, 18, Apagar)
            MyBase.AddParameter("@descuento", SqlDbType.Decimal, 18, Descuento)
            MyBase.AddParameter("@idpago", SqlDbType.Int, 8, IdPago)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, IdUsuario)
            'Execute the stored procedure
            usp_GeneraDetallePago = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovimientos(Opcion As Integer, Sucursal As String) As DataSet
        'mreyes 05/Diciembre/2018   09:45 a.m.
        Try
            usp_TraerMovimientos = New DataSet
            MyBase.SQL = "usp_TraerMovimientos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 2, Opcion)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerMovimientos, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPago(Opcion As Integer, Sucursal As String, Folio As String, IdUsuario As Integer, Fecha As Date) As DataSet
        'mreyes 05/Diciembre/2018   10:01 a.m.
        Try
            usp_TraerPago = New DataSet
            MyBase.SQL = "usp_TraerPago"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 2, Opcion)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@folio", SqlDbType.VarChar, 6, Folio)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, IdUsuario)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.FillDataSet(usp_TraerPago, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoUPDATE(Opcion As Integer, Sucursal As String, Folio As String, IdUsuario As Integer, Fecha As Date) As Boolean
        'mreyes 30/Noviembre/2018   01:09 p.m.
        Try
            'usp_ActualizarPlanPagos(Opcion As Integer, Distrib As String, Sucursal As String, Nota As String, Pago As Integer, Abono As Integer, FechaPago As Date, IdPago As Integer, IdUsuario As Integer)
            MyBase.SQL = "usp_TraerPagoUPDATE"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 2, Opcion)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@folio", SqlDbType.VarChar, 6, Folio)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, IdUsuario)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            'Execute the stored procedure
            usp_TraerPagoUPDATE = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPlanPagos(Opcion As Integer, Distrib As String, Sucursal As String, Nota As String, Pago As Integer, Abono As Decimal, FechaPago As Date, IdPago As Integer, IdUsuario As Integer) As Boolean
        'mreyes 05/Diciembre/2018   10:12 a.m.
        Try
            'usp_ActualizarPlanPagos(Opcion As Integer, Distrib As String, Sucursal As String, Nota As String, Pago As Integer, Abono As Integer, FechaPago As Date, IdPago As Integer, IdUsuario As Integer)
            MyBase.SQL = "usp_ActualizarPlanPagos"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@nota", SqlDbType.VarChar, 6, Nota)
            MyBase.AddParameter("@pago", SqlDbType.Int, 6, Pago)
            MyBase.AddParameter("@abono", SqlDbType.Decimal, 18, Abono)
            MyBase.AddParameter("@FechaPago", SqlDbType.Date, 10, FechaPago)
            MyBase.AddParameter("@IdPago", SqlDbType.Int, 6, IdPago)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, IdUsuario)
            'Execute the stored procedure
            usp_ActualizarPlanPagos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaStatusInfoPagos(Status As String, IdPagos As Integer, IdUsuarioCancela As Integer) As Boolean
        'mreyes 05/Diciembre/2018   10:45 a.m.
        Try
            'usp_ActualizarPlanPagos(Opcion As Integer, Distrib As String, Sucursal As String, Nota As String, Pago As Integer, Abono As Integer, FechaPago As Date, IdPago As Integer, IdUsuario As Integer)
            MyBase.SQL = "usp_ActualizaStatusInfoPagos"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@status", SqlDbType.VarChar, 2, Status)
            MyBase.AddParameter("@idpagos", SqlDbType.Int, 6, IdPagos)
            MyBase.AddParameter("@idusuariocancela", SqlDbType.Int, 6, IdUsuarioCancela)
            'Execute the stored procedure
            usp_ActualizaStatusInfoPagos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMovimiento(Folio As String, Distrib As String,
    Tipo As String, IdPago As Integer,
        IdAnticipo As Integer, IdConvenio As Integer,
        SucNot As String, Nota As String, FechaAplicar As Date, Plazo As Integer,
        Motivo As Integer, Fecha As Date, Importe As Decimal, Interes As Decimal,
        IdUsuario As Integer, IdUsuarioCancela As Integer) As Boolean
        'mreyes 05/Diciembre/2018   10:44 a.m.
        Try
            MyBase.SQL = "usp_CapturaMovimiento"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Folio", SqlDbType.VarChar, 8, Folio)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@tipo", SqlDbType.VarChar, 3, Tipo)
            MyBase.AddParameter("@idpago", SqlDbType.Int, 8, IdPago)
            MyBase.AddParameter("@idanticipo", SqlDbType.Int, 8, IdAnticipo)
            MyBase.AddParameter("@idconvenio", SqlDbType.Int, 8, IdConvenio)
            MyBase.AddParameter("@sucnot", SqlDbType.VarChar, 2, SucNot)
            MyBase.AddParameter("@nota", SqlDbType.VarChar, 6, Nota)
            MyBase.AddParameter("@fechaAPLICAR", SqlDbType.Date, 10, FechaAplicar)
            MyBase.AddParameter("@PLAZO", SqlDbType.Int, 8, Plazo)
            MyBase.AddParameter("@MOTIVO", SqlDbType.Int, 8, Motivo)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@importe", SqlDbType.Decimal, 18, Importe)
            MyBase.AddParameter("@INTERES", SqlDbType.Decimal, 18, Interes)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, IdUsuario)
            MyBase.AddParameter("@IdUsuarioCancela", SqlDbType.Int, 8, IdUsuarioCancela)
            'Execute the stored procedure
            usp_CapturaMovimiento = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarSaldoDistrib(Opcion As Integer, Distrib As String, Importe As Integer) As Boolean
        'mreyes 05/Diciembre/2018   12:16 p.m.
        Try
            MyBase.SQL = "usp_ActualizarSaldoDistrib"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@importe", SqlDbType.Decimal, 18, Importe)
            'Execute the stored procedure
            usp_ActualizarSaldoDistrib = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerHistorialPagos(Distrib As String) As DataSet
        'mreyes 05/Diciembre/2018   12:28 p.m.
        Try
            usp_TraerHistorialPagos = New DataSet
            MyBase.SQL = "usp_TraerHistorialPagos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@distrib", SqlDbType.VarChar, 6, Distrib)
            MyBase.FillDataSet(usp_TraerHistorialPagos, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaDescuentoAdicional(Opcion As Integer, FechaIni As Date, Fechafin As Date,
                                                  DistribIni As String, DistribFin As String, Sucursal As String, Clasificacion As String,
                                                  status As String, Descto As Decimal, Motivo As String, IdUsuario As Integer,
                                                  IdUsuarioCancela As Integer) As Boolean
        'mreyes 05/Diciembre/2018   13:01 p.m.
        Try
            MyBase.SQL = "usp_CapturaDescuentoAdicional"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@FechaIni", SqlDbType.Date, 10, FechaIni)
            MyBase.AddParameter("@Fechafin", SqlDbType.Date, 10, Fechafin)
            MyBase.AddParameter("@DistribIni", SqlDbType.VarChar, 6, DistribIni)
            MyBase.AddParameter("@DistribFin", SqlDbType.VarChar, 6, DistribFin)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, DistribFin)
            MyBase.AddParameter("@clasificacion", SqlDbType.VarChar, 2, Clasificacion)
            MyBase.AddParameter("@status", SqlDbType.VarChar, 2, status)
            MyBase.AddParameter("@descto", SqlDbType.Decimal, 18, Descto)
            MyBase.AddParameter("@motivo", SqlDbType.VarChar, 50, Motivo)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, IdUsuario)
            MyBase.AddParameter("@IdUsuarioCancela", SqlDbType.Int, 8, IdUsuarioCancela)
            'Execute the stored procedure
            usp_CapturaDescuentoAdicional = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoPagoDet(Opcion As Integer, Sucursal As String, Nota As String, Pago As Integer) As DataSet
        'mreyes 07/Diciembre/2018   11:59 p.m.
        Try
            usp_TraerInfoPagoDet = New DataSet
            MyBase.SQL = "usp_TraerInfoPagoDet"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Nota", SqlDbType.VarChar, 6, Nota)
            MyBase.AddParameter("@Pago", SqlDbType.Int, 8, Pago)
            MyBase.FillDataSet(usp_TraerInfoPagoDet, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaTipoPagos(Opcion As Integer, IdPagos As Integer, Sucursal As String, FormaPago As String,
    Status As String, Fecha As Date, Importe As Decimal, Dolares As Decimal, Cambio As Decimal,
    Emisor As String,
    NoTarjeta As String, Autorizacion As String, RutaBancaria As String,
    NoCuenta As String, NoCheque As String, IdActivos As Integer, IdUsuario As Integer) As Boolean
        'mreyes 07/Diciembre/2018   12:58 p.m.
        Try
            MyBase.SQL = "usp_CapturaTipoPagos"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@IdPagos", SqlDbType.Int, 8, IdPagos)
            MyBase.AddParameter("@sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@FormaPago", SqlDbType.VarChar, 3, FormaPago)
            MyBase.AddParameter("@Status", SqlDbType.VarChar, 2, Status)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@Importe", SqlDbType.Decimal, 18, Importe)
            MyBase.AddParameter("@Dolares", SqlDbType.Decimal, 18, Dolares)
            MyBase.AddParameter("@Cambio", SqlDbType.Decimal, 18, Cambio)
            MyBase.AddParameter("@Emisor", SqlDbType.VarChar, 25, Emisor)
            MyBase.AddParameter("@NoTarjeta", SqlDbType.VarChar, 16, NoTarjeta)
            MyBase.AddParameter("@autorizacion", SqlDbType.VarChar, 5, Autorizacion)
            MyBase.AddParameter("@rutabancaria", SqlDbType.VarChar, 50, RutaBancaria)
            MyBase.AddParameter("@nocuenta", SqlDbType.VarChar, 20, NoCuenta)
            MyBase.AddParameter("@NoCheque", SqlDbType.VarChar, 20, NoCheque)
            MyBase.AddParameter("@IdActivos", SqlDbType.Int, 8, IdActivos)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 8, IdUsuario)
            'Execute the stored procedure
            usp_CapturaTipoPagos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivos(Tipo As String) As DataSet
        'mreyes 07/Diciembre/2018   11:59 p.m.
        Try
            usp_TraerMotivos = New DataSet
            MyBase.SQL = "usp_TraerMotivos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Tipo", SqlDbType.VarChar, 3, Tipo)
            MyBase.FillDataSet(usp_TraerMotivos, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPermisosCaja(IdDepto As Integer, IdPuesto As Integer, Tipo As String, Subtipo As String) As DataSet
        'mreyes 07/Diciembre/2018   06:20 p.m.
        Try
            usp_TraerPermisosCaja = New DataSet
            MyBase.SQL = "usp_TraerPermisosCaja"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 8, IdDepto)
            MyBase.AddParameter("@idpuesto", SqlDbType.Int, 8, IdPuesto)
            MyBase.AddParameter("@Tipo", SqlDbType.VarChar, 3, Tipo)
            MyBase.AddParameter("@Subtipo", SqlDbType.VarChar, 15, Subtipo)
            MyBase.FillDataSet(usp_TraerPermisosCaja, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEntrega(Opcion As Integer, IdEmpleado As Integer, Fecha As Date,
                                       IdEntrega As Integer, Forma As String, Cantidad As Integer,
                                       Articulo As String, Importe As Decimal, Dolares As Decimal) As Boolean
        'mreyes 08/Diciembre/2018   12:35 p.m.
        Try
            MyBase.SQL = "usp_CapturaEntrega"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@IdEmpleado", SqlDbType.Int, 8, IdEmpleado)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@IdEntrega", SqlDbType.Int, 8, IdEntrega)
            MyBase.AddParameter("@Forma", SqlDbType.VarChar, 3, Forma)
            MyBase.AddParameter("@cantidad", SqlDbType.Int, 8, Cantidad)
            MyBase.AddParameter("@Articulo", SqlDbType.VarChar, 150, Articulo)
            MyBase.AddParameter("@Importe", SqlDbType.Decimal, 18, Importe)
            MyBase.AddParameter("@Dolares", SqlDbType.Decimal, 18, Dolares)
            'Execute the stored procedure
            usp_CapturaEntrega = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEntrega(Opcion As Integer, IdEmpleado As Integer, Fecha As Date) As DataSet
        'mreyes 08/Diciembre/2018   12:42 p.m.
        Try
            usp_TraerEntrega = New DataSet
            MyBase.SQL = "usp_TraerEntrega"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@idempleado", SqlDbType.Int, 8, IdEmpleado)
            MyBase.AddParameter("@Fecha", SqlDbType.Date, 10, Fecha)
            MyBase.FillDataSet(usp_TraerEntrega, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoCorte(Opcion As Integer, Fecha As Date, IdUsuario As Integer) As DataSet
        'mreyes 08/Diciembre/2018   01:09 p.m.
        Try
            usp_TraerInfoCorte = New DataSet
            MyBase.SQL = "usp_TraerInfoCorte"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Fecha", SqlDbType.Date, 10, Fecha)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 8, IdUsuario)
            MyBase.FillDataSet(usp_TraerInfoCorte, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribuidorCredito(Opcion As Integer, Distrib As String, Nombre As String) As DataSet
        'mreyes 11/Diciembre/2018   04:50 p.m.
        Try
            usp_TraerDistribuidorCredito = New DataSet
            MyBase.SQL = "usp_TraerDistribuidorCredito"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", SqlDbType.VarChar, 6, Distrib)
            MyBase.AddParameter("@NombreB", SqlDbType.VarChar, 100, Nombre)
            MyBase.FillDataSet(usp_TraerDistribuidorCredito, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAnticipo(Opcion As Integer, IdAnticipob As Integer, SucursalB As String,
                                        DistribB As String, StatusB As String, ImporteB As Decimal, AplicadoB As Integer,
                                        IdUsuarioB As Integer, IdPagoAplicaB As Integer) As Boolean
        'mreyes 19/Diciembre/2018   04:49 p.m.
        Try
            MyBase.SQL = "usp_CapturaAnticipo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@IdAnticipob", SqlDbType.Int, 8, IdAnticipob)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, SucursalB)
            MyBase.AddParameter("@DistribB", SqlDbType.VarChar, 6, DistribB)
            MyBase.AddParameter("@StatusB", SqlDbType.VarChar, 2, StatusB)
            MyBase.AddParameter("@ImporteB", SqlDbType.Decimal, 18, ImporteB)
            MyBase.AddParameter("@AplicadoB", SqlDbType.Int, 8, AplicadoB)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.Int, 8, IdUsuarioB)
            MyBase.AddParameter("@IdPagoAplicaB", SqlDbType.Int, 8, IdPagoAplicaB)
            'Execute the stored procedure
            usp_CapturaAnticipo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAnticipo(Opcion As Integer, DistribB As String, SucursalB As String, IdUsuarioB As Integer, FechaB As Date) As DataSet
        'mreyes 18/Diciembre/2018   04:55 p.m.
        Try
            usp_TraerAnticipo = New DataSet
            MyBase.SQL = "usp_TraerAnticipo"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", SqlDbType.VarChar, 6, DistribB)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, SucursalB)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.Int, 8, IdUsuarioB)
            MyBase.AddParameter("@FechaB", SqlDbType.Date, 10, FechaB)
            MyBase.FillDataSet(usp_TraerAnticipo, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescuentoCaja(ImporteB As Decimal) As DataSet
        'mreyes 18/Diciembre/2018   04:55 p.m.
        Try
            usp_TraerDescuentoCaja = New DataSet
            MyBase.SQL = "usp_TraerDescuentoCaja"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@ImporteB", SqlDbType.Decimal, 18, ImporteB)
            MyBase.FillDataSet(usp_TraerDescuentoCaja, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlanPagos(Opcion As Integer, DistribB As String) As DataSet
        'mreyes 18/Diciembre/2018   05:22 p.m.
        Try
            usp_TraerPlanPagos = New DataSet
            MyBase.SQL = "usp_TraerPlanPagos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@ImporteB", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@DistribB", SqlDbType.VarChar, 6, DistribB)
            MyBase.FillDataSet(usp_TraerPlanPagos, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerParametrosCredito(TipoB As String) As DataSet
        'mreyes 18/Diciembre/2018   05:27 p.m.
        Try
            usp_TraerParametrosCredito = New DataSet
            MyBase.SQL = "usp_TraerParametrosCredito"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 25, TipoB)
            MyBase.FillDataSet(usp_TraerParametrosCredito, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNotaPP(Opcion As Integer, SucursalB As String, NotaB As String) As DataSet
        'mreyes 18/Diciembre/2018   05:27 p.m.
        Try
            usp_TraerNotaPP = New DataSet
            MyBase.SQL = "usp_TraerNotaPP"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, SucursalB)
            MyBase.AddParameter("@NotaB", SqlDbType.VarChar, 6, NotaB)
            MyBase.FillDataSet(usp_TraerNotaPP, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCargos(Opcion As Integer, SucursalB As String, NotaB As String) As DataSet
        'mreyes 18/Diciembre/2018   05:27 p.m.
        Try
            usp_TraerCargos = New DataSet
            MyBase.SQL = "usp_TraerCargos"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, SucursalB)
            MyBase.AddParameter("@NotaB", SqlDbType.VarChar, 6, NotaB)
            MyBase.FillDataSet(usp_TraerCargos, "SirCoCredito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
