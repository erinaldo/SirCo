
Imports System.Data
Imports System.Data.SqlClient

Public Class DALTraspasosSQL
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
    Public Function usp_TraerTrasPendRecibo(ByVal OpcionSP As Integer, ByVal SucurOri As String, ByVal SucurDes As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 12/Diciembre/2016   12:29 p.m.

        Try
            usp_TraerTrasPendRecibo = New DataSet
            MyBase.SQL = "usp_TraerTrasPendRecibo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 4, OpcionSP)
            MyBase.AddParameter("@SucuroriB", SqlDbType.VarChar, 2, SucurOri)
            MyBase.AddParameter("@SucurdesB", SqlDbType.VarChar, 2, SucurDes)
            MyBase.AddParameter("@fechainiB", SqlDbType.VarChar, 10, FechaIni)
            MyBase.AddParameter("@fechafinB", SqlDbType.VarChar, 10, FechaFin)
            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTrasPendRecibo, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasos(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 8/Octubre/2012 05:25 p.m.
        Try
            usp_TraerTraspasos = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasos(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@feciniB", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@fecfinB", SqlDbType.Char, 10, FechaFin)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosDet(ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        'mreyes 12/Diciembre/2016   05:09 p.m.
        Try
            usp_TraerTraspasosDet = New DataSet
            MyBase.SQL = "usp_TraerTraspasosDet"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosDet, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosSerie(ByVal Serie As String) As DataSet
        'miguel pérez 9/Octubre/2012 04:51 p.m.
        Try
            usp_TraerTraspasosSerie = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosSerie(?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosSerie, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosSerieDet(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Serie As String) As DataSet
        'mreyes 10/Diciembre/2016   09:49 a.m.
        Try
            usp_TraerTraspasosSerieDet = New DataSet
            MyBase.SQL = "usp_TraerTraspasosSerieDet"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@SerieB", SqlDbType.VarChar, 13, Serie)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosSerieDet, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerProTraspDet(ByVal IdProtrasB As Integer, ByVal MarcaB As String, ByVal EstilonB As String, ByVal MedidaB As String) As DataSet
        'mreyes 10/Diciembre/2016   09:49 a.m.
        Try
            usp_TraerProTraspDet = New DataSet
            MyBase.SQL = "usp_TraerProTraspDet"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@IdProtrasB", SqlDbType.Int, 16, IdProtrasB)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, EstilonB)
            MyBase.AddParameter("@MedidaB", SqlDbType.VarChar, 3, MedidaB)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerProTraspDet, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTraspasosFolios(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, _
                                             ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String) As DataSet
        'miguel pérez 9/Octubre/2012 04:51 p.m.
        Try
            usp_TraerTraspasosFolios = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosFolios(?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@FolioA", SqlDbType.Char, 6, FolioA)
            MyBase.AddParameter("@FolioB", SqlDbType.Char, 6, FolioB)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIni", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Char, 10, FechaFin)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosFolios, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosNoSurtidos(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Serie As String, ByVal FolioA As String, ByVal FolioB As String) As DataSet
        'miguel pérez 13/Octubre/2012 07:16 p.m.
        Try
            usp_TraerTraspasosNoSurtidos = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosNoSurtidos(?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIni", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Char, 10, FechaFin)
            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)
            MyBase.AddParameter("@FolioA", SqlDbType.Char, 6, FolioA)
            MyBase.AddParameter("@FolioB", SqlDbType.Char, 6, FolioB)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosNoSurtidos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosRecibidos(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 22/Octubre/2012 07:03 p.m.
        Try
            usp_TraerTraspasosRecibidos = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosRecibidos(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@feciniB", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@fecfinB", SqlDbType.Char, 10, FechaFin)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosRecibidos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosRecibidosDet(ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 22/Octubre/2012 07:21 p.m.
        Try
            usp_TraerTraspasosRecibidosDet = New DataSet
            MyBase.SQL = "usp_TraerTraspasosRecibidosDet"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosRecibidosDet, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosFoliosRecibidos(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, _
                                             ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String, ByVal SucursalOri As String) As DataSet
        'miguel pérez 23/Octubre/2012 09:41 a.m.
        Try
            usp_TraerTraspasosFoliosRecibidos = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosFoliosRecibidos(?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@FolioA", SqlDbType.Char, 6, FolioA)
            MyBase.AddParameter("@FolioB", SqlDbType.Char, 6, FolioB)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIni", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", SqlDbType.Char, 10, FechaFin)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@SucursalOriB", SqlDbType.Char, 2, SucursalOri)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosFoliosRecibidos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSeriesTraspasos(ByVal Sucursal As String, ByVal SucurDes As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 24/Octubre/2012 06:06 p.m.
        Try
            usp_TraerSeriesTraspasos = New DataSet
            MyBase.SQL = "CALL usp_TraerSeriesTraspasos(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurDes)
            MyBase.AddParameter("@TraspasoB", SqlDbType.Char, 6, Traspaso)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerSeriesTraspasos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioUltimoTraspaso(ByVal Sucursal As String) As DataSet
        'miguel pérez 30/Octubre/2012 1:33 p.m.
        Try
            usp_TraerFolioUltimoTraspaso = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioUltimoTraspaso(?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerFolioUltimoTraspaso, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarFolioTraspaso(ByVal Folio As String, ByVal Sucursal As String) As Boolean
        'miguel pérez 31/Octubre/2012 04:10 p.m.
        Try
            MyBase.SQL = "call usp_ActualizarFolioTraspaso(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@FolioB", SqlDbType.Char, 6, Folio)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)

            usp_ActualizarFolioTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaTraspasoOri(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal IdFolio As Integer, ByVal Estatus As String, _
                                           ByVal Fecha As String, ByVal Hora As String, ByVal SucurDes As String, ByVal Observa As String, ByVal Usuario As String, _
                                           ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal, ByVal Envia As Integer, _
                                           ByVal Transporta As Integer, ByVal IdUsuario As Integer, ByVal IdProtras As Integer) As Boolean

        'mreyes 09/Diciembre/2016   01:49 p.m.
        Try
            MyBase.SQL = "usp_CapturaTraspasoOri"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@TipoB", SqlDbType.VarChar, 1, Tipo)
            MyBase.AddParameter("@idfolioB", SqlDbType.Int, 16, IdFolio)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 2, Estatus)
            MyBase.AddParameter("@FechaB", SqlDbType.VarChar, 10, Fecha)
            MyBase.AddParameter("@HoraB", SqlDbType.VarChar, 8, Hora)
            MyBase.AddParameter("@SucurDesB", SqlDbType.VarChar, 2, SucurDes)
            MyBase.AddParameter("@ObservaB", SqlDbType.VarChar, 200, Observa)
            MyBase.AddParameter("@UsuarioB", SqlDbType.VarChar, 8, Usuario)
            MyBase.AddParameter("@CtdB", SqlDbType.Int, 6, Ctd)
            MyBase.AddParameter("@CostoB", SqlDbType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", SqlDbType.Decimal, 9, Precio)
            MyBase.AddParameter("@EnviaB", SqlDbType.Int, 4, Envia)
            MyBase.AddParameter("@TransportaB", SqlDbType.Int, 4, Transporta)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.Int, 4, IdUsuario)
            MyBase.AddParameter("@IdProTrasB", SqlDbType.Int, 16, IdProtras)

            usp_CapturaTraspasoOri = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaTraspasoDes(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal Estatus As String, _
                                           ByVal TipoRec As String, ByVal Fecha As String, ByVal Hora As String, ByVal SucurOri As String, _
                                           ByVal Referenc As String, ByVal Observa As String, ByVal Usuario As String, _
                                           ByVal IdReferenc As Integer, ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal, _
                                           ByVal Recibe As Integer, ByVal IdUsuario As Integer, ByVal IdProTras As Integer) As Boolean
        'meyes  10/Diciembre/2016   10:21 a.m.
        Try
            MyBase.SQL = "usp_CapturaTraspasoDes"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.Char, 6, Traspaso)
            MyBase.AddParameter("@TipoB", SqlDbType.Char, 1, Tipo)
            MyBase.AddParameter("@TipoRecB", SqlDbType.Char, 1, TipoRec)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@FechaB", SqlDbType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", SqlDbType.Char, 8, Hora)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurOri)
            MyBase.AddParameter("@ReferencB", SqlDbType.Char, 6, Referenc)
            MyBase.AddParameter("@ObservaB", SqlDbType.Char, 60, Observa)
            MyBase.AddParameter("@UsuarioB", SqlDbType.Char, 8, Usuario)
            MyBase.AddParameter("@IdReferencB", SqlDbType.Int, 32, IdReferenc)
            MyBase.AddParameter("@CtdB", SqlDbType.Int, 6, Ctd)
            MyBase.AddParameter("@CostoB", SqlDbType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", SqlDbType.Decimal, 9, Precio)
            MyBase.AddParameter("@RecibeB", SqlDbType.Int, 4, Recibe)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.Int, 4, IdUsuario)
            MyBase.AddParameter("@IdProTrasB", SqlDbType.Int, 16, IdProTras)

            usp_CapturaTraspasoDes = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraReciboTraspaso(ByVal SucurOri As String, ByVal Traspaso As String,
                                                SucursalDes As String, Observaciones As String, Usuario As String, IdUsuario As Integer) As Boolean
        'meyes  22/Enero/2020   12:11 p.m.
        Try
            MyBase.SQL = "usp_GeneraReciboTraspaso"
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@SucurOri", SqlDbType.Char, 2, SucurOri)
            MyBase.AddParameter("@Traspaso", SqlDbType.Char, 6, Traspaso)
            MyBase.AddParameter("@SucurDes", SqlDbType.Char, 2, SucursalDes)
            MyBase.AddParameter("@Observaciones", SqlDbType.Char, 60, Observaciones)
            MyBase.AddParameter("@Usuario", SqlDbType.Char, 8, Usuario)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 4, IdUsuario)


            usp_GeneraReciboTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraTraspasoReciboMYSQL(IdFolio As Integer, IdTraspaso As Integer, Sucursal As String, Traspaso As String) As Boolean
        'meyes  21/Octubre/2021 01:04 p.m.
        Try
            MyBase.SQL = "usp_GeneraTraspasoReciboMYSQL"
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@idfolio", SqlDbType.Char, 6, IdFolio)
            MyBase.AddParameter("@idTraspaso", SqlDbType.Int, 8, IdTraspaso)
            MyBase.AddParameter("@Sucursal", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspaso", SqlDbType.Char, 6, Traspaso)

            usp_GeneraTraspasoReciboMYSQL = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaTraspasoSal(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal Estatus As String, _
                                          ByVal TipoRec As String, ByVal Fecha As String, ByVal Hora As String, ByVal SucurOri As String, _
                                          ByVal Referenc As String, ByVal Observa As String, ByVal Usuario As String, _
                                          ByVal IdReferenc As Integer, ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal, _
                                          ByVal Recibe As Integer, ByVal IdUsuario As Integer) As Boolean
        'meyes  13/Diciembre/2016   02:15 p.m.
        Try
            MyBase.SQL = "usp_CapturaTraspasoSal"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.Char, 6, Traspaso)
            MyBase.AddParameter("@TipoB", SqlDbType.Char, 1, Tipo)
            MyBase.AddParameter("@TipoRecB", SqlDbType.Char, 1, TipoRec)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@FechaB", SqlDbType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", SqlDbType.Char, 8, Hora)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurOri)
            MyBase.AddParameter("@ReferencB", SqlDbType.Char, 6, Referenc)
            MyBase.AddParameter("@ObservaB", SqlDbType.Char, 60, Observa)
            MyBase.AddParameter("@UsuarioB", SqlDbType.Char, 8, Usuario)
            MyBase.AddParameter("@IdReferencB", SqlDbType.Int, 32, IdReferenc)
            MyBase.AddParameter("@CtdB", SqlDbType.Int, 6, Ctd)
            MyBase.AddParameter("@CostoB", SqlDbType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", SqlDbType.Decimal, 9, Precio)
            MyBase.AddParameter("@RecibeB", SqlDbType.Int, 4, Recibe)
            MyBase.AddParameter("@IdUsuarioB", SqlDbType.Int, 4, IdUsuario)

            usp_CapturaTraspasoSal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaDetTraspasoOri(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                              ByVal IdArticulo As Integer, ByVal Marca As String, _
                                              ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                              ByVal Serie As String, ByVal ctdori As Integer, ByVal CostoMargen As Double, ByVal Costo As Double, ByVal Precio As Double) As Boolean
        'mreyes 09/Diciembre/2016   11:42 a.m.
        Try
            MyBase.SQL = "usp_CapturaDetTraspasoOri"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@idtraspasob", SqlDbType.Int, 6, Idtraspaso)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@idarticuloB", SqlDbType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", SqlDbType.VarChar, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", SqlDbType.VarChar, 1, Corrida)
            MyBase.AddParameter("@MedidaB", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@SerieB", SqlDbType.VarChar, 13, Serie)
            MyBase.AddParameter("@ctdoriB", SqlDbType.Int, 3, ctdori)
            MyBase.AddParameter("@CostoMargenB", SqlDbType.Decimal, 9, CostoMargen)
            MyBase.AddParameter("@CostoB", SqlDbType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", SqlDbType.Decimal, 9, Precio)


            usp_CapturaDetTraspasoOri = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaDetTraspasoDes(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                              ByVal IdArticulo As Integer, ByVal Marca As String, _
                                              ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                              ByVal Serie As String, ByVal ctddes As Integer, ByVal CostoMargen As Double, ByVal Costo As Double, ByVal Precio As Double) As Boolean
        'mreyes 10/Diciembre/2016   10:11 a.m.
        Try
            MyBase.SQL = "usp_CapturaDetTraspasoDes"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@idtraspasob", SqlDbType.Int, 16, Idtraspaso)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@idarticuloB", SqlDbType.Int, 6, IdArticulo)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", SqlDbType.VarChar, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", SqlDbType.VarChar, 1, Corrida)
            MyBase.AddParameter("@MedidaB", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@SerieB", SqlDbType.VarChar, 13, Serie)
            MyBase.AddParameter("@ctddesB", SqlDbType.Int, 3, ctddes)
            MyBase.AddParameter("@CostoMargenB", SqlDbType.Decimal, 9, CostoMargen)
            MyBase.AddParameter("@CostoB", SqlDbType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", SqlDbType.Decimal, 9, Precio)

            usp_CapturaDetTraspasoDes = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaDetTraspasoSal(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                          ByVal IdArticulo As Integer, ByVal Marca As String, _
                                          ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                          ByVal Serie As String, ByVal ctddes As Integer, ByVal CostoMargen As Double, ByVal Costo As Double, ByVal Precio As Double) As Boolean
        'mreyes 10/Diciembre/2016   10:11 a.m.
        Try
            MyBase.SQL = "usp_CapturaDetTraspasoSal"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@idtraspasob", SqlDbType.Int, 16, Idtraspaso)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@idarticuloB", SqlDbType.Int, 6, IdArticulo)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", SqlDbType.VarChar, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", SqlDbType.VarChar, 1, Corrida)
            MyBase.AddParameter("@MedidaB", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@SerieB", SqlDbType.VarChar, 13, Serie)
            MyBase.AddParameter("@ctddesB", SqlDbType.Int, 3, ctddes)
            MyBase.AddParameter("@CostoMargenB", SqlDbType.Decimal, 9, CostoMargen)
            MyBase.AddParameter("@CostoB", SqlDbType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", SqlDbType.Decimal, 9, Precio)

            usp_CapturaDetTraspasoSal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerie(ByVal Serie As String, ByVal Sucursal As String, ByVal Estatus As String, ByVal SucurDes As String) As Boolean
        'miguel pérez 31/Octubre/2012 05:01 p.m.
        Try
            MyBase.SQL = "call usp_ActualizarSerie(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurDes)

            usp_ActualizarSerie = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarDetTraspasoSal(ByVal Sucursal As String, ByVal Traspaso As String) As Boolean
        'mreyes 10/Diciembre/2016   10:17 a.m.
        Try
            MyBase.SQL = "usp_ActualizarDetTraspasoSal"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
           

            usp_ActualizarDetTraspasoSal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarDetTraspasoRecibido(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Serie As String, ByVal Recibido As String, ByVal IdTraspdes As Integer) As Boolean
        'mreyes 10/Diciembre/2016   10:17 a.m.
        Try
            MyBase.SQL = "usp_ActualizarDetTraspasoRecibido"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@SerieB", SqlDbType.VarChar, 13, Serie)
            MyBase.AddParameter("@RecibidoB", SqlDbType.VarChar, 1, Recibido)
            MyBase.AddParameter("@IdTraspdesB", SqlDbType.Int, 32, IdTraspdes)

            usp_ActualizarDetTraspasoRecibido = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieRecibo(ByVal Serie As String, ByVal Sucursal As String, ByVal Estatus As String, ByVal SucurDes As String) As Boolean
        'miguel pérez 31/Octubre/2012 05:01 p.m.
        Try
            MyBase.SQL = "call usp_ActualizarSerieRecibo(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurDes)

            usp_ActualizarSerieRecibo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieReciboDev(ByVal Serie As String, ByVal Sucursal As String, ByVal Estatus As String, ByVal SucurDes As String) As Boolean
        Try
            MyBase.SQL = "call usp_ActualizarSerieReciboDev(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@EstatusB", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurDes)

            usp_ActualizarSerieReciboDev = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCostoSerie(ByVal Serie As String) As DataSet
        'miguel pérez 30/Octubre/2012 1:33 p.m.
        Try
            usp_TraerCostoSerie = New DataSet
            MyBase.SQL = "CALL usp_TraerCostoSerie(?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerCostoSerie, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarTraspasoAutomatico(ByVal Sucursal As String, ByVal Traspaso As String) As Boolean
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "call usp_ActualizarTraspasoAutomatico(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.Char, 6, Traspaso)

            usp_ActualizarTraspasoAutomatico = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoSerieDescrip(ByVal Serie As String) As DataSet
        'Tony Garcia - 15/Agosto/2013 - 05:20 pm
        Try
            usp_TraerTraspasoSerieDescrip = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasoSerieDescrip(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerTraspasoSerieDescrip, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalTraspasosManualOri(ByVal Sucursal As String, ByVal TraspasoIni As String, ByVal TraspasoFin As String, ByVal Sucurdes As String, _
                                               ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String, _
                                               ByVal IdTraspasoIni As Integer, ByVal IdTraspasoFin As Integer, ByVal FechaCanIni As String, ByVal FechaCanFin As String) As DataSet
        'mreyes 09/Diciembre/2016   11:12 a.m.
        Try
            usp_PpalTraspasosManualOri = New DataSet
            MyBase.SQL = "usp_PpalTraspasosManualOri"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", SqlDbType.VarChar, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", SqlDbType.VarChar, 6, TraspasoFin)
            MyBase.AddParameter("@sucurdesb", SqlDbType.VarChar, 2, Sucurdes)
            MyBase.AddParameter("@FechaInib", SqlDbType.VarChar, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.VarChar, 10, FechaFin)
            MyBase.AddParameter("@statusb", SqlDbType.VarChar, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", SqlDbType.Int, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", SqlDbType.Int, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", SqlDbType.VarChar, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", SqlDbType.VarChar, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosManualOri, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalTraspasosDevOri(ByVal Sucursal As String, ByVal TraspasoIni As String, ByVal TraspasoFin As String, ByVal Sucurdes As String, _
                                               ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String, _
                                               ByVal IdTraspasoIni As Integer, ByVal IdTraspasoFin As Integer, ByVal FechaCanIni As String, ByVal FechaCanFin As String) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            usp_PpalTraspasosDevOri = New DataSet
            MyBase.SQL = "CALL usp_PpalTraspasosDevOri(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", SqlDbType.Char, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", SqlDbType.Char, 6, TraspasoFin)
            MyBase.AddParameter("@sucurdesb", SqlDbType.Char, 2, Sucurdes)
            MyBase.AddParameter("@FechaInib", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.Char, 10, FechaFin)
            MyBase.AddParameter("@statusb", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", SqlDbType.SmallInt, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", SqlDbType.SmallInt, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", SqlDbType.Char, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", SqlDbType.Char, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosDevOri, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalTraspasosManualDes(ByVal Sucursal As String, ByVal TraspasoIni As String, ByVal TraspasoFin As String, ByVal Sucurori As String, _
                                               ByVal Referenc As String, ByVal FechaIni As String, ByVal FechaFin As String, _
                                               ByVal Estatus As String, ByVal IdTraspasoIni As Integer, ByVal IdTraspasoFin As Integer, ByVal FechaCanIni As String, ByVal FechaCanFin As String) As DataSet
        'mreyes 09/Diciembre/2016   11:19 a.m.
        Try
            usp_PpalTraspasosManualDes = New DataSet
            MyBase.SQL = "usp_PpalTraspasosManualDes"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", SqlDbType.VarChar, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", SqlDbType.VarChar, 6, TraspasoFin)
            MyBase.AddParameter("@sucurorib", SqlDbType.VarChar, 2, Sucurori)
            MyBase.AddParameter("@Referencb", SqlDbType.VarChar, 6, Referenc)
            MyBase.AddParameter("@FechaInib", SqlDbType.VarChar, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.VarChar, 10, FechaFin)
            MyBase.AddParameter("@statusb", SqlDbType.VarChar, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", SqlDbType.Int, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", SqlDbType.Int, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", SqlDbType.VarChar, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", SqlDbType.VarChar, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosManualDes, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalTraspasosDevDes(ByVal Sucursal As String, ByVal TraspasoIni As String, ByVal TraspasoFin As String, ByVal Sucurori As String, _
                                               ByVal Referenc As String, ByVal FechaIni As String, ByVal FechaFin As String, _
                                               ByVal Estatus As String, ByVal IdTraspasoIni As Integer, ByVal IdTraspasoFin As Integer, ByVal FechaCanIni As String, ByVal FechaCanFin As String) As DataSet
        'Tony Garcia - 20/Agosto/2013 - 11:20 am
        Try
            usp_PpalTraspasosDevDes = New DataSet
            MyBase.SQL = "CALL usp_PpalTraspasosDevDes(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", SqlDbType.Char, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", SqlDbType.Char, 6, TraspasoFin)
            MyBase.AddParameter("@sucurorib", SqlDbType.Char, 2, Sucurori)
            MyBase.AddParameter("@Referencb", SqlDbType.Char, 6, Referenc)
            MyBase.AddParameter("@FechaInib", SqlDbType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.Char, 10, FechaFin)
            MyBase.AddParameter("@statusb", SqlDbType.Char, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", SqlDbType.SmallInt, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", SqlDbType.SmallInt, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", SqlDbType.Char, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", SqlDbType.Char, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosDevDes, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoManualEnvioDet(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String,
                                                    ByVal IdTraspaso As Integer, ByVal IdProtras As Integer) As DataSet
        'mreyes 09/Diciembre/2016   04:32 p.m.
        Try
            usp_TraerTraspasoManualEnvioDet = New DataSet
            MyBase.SQL = "usp_TraerTraspasoManualEnvioDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Traspasob", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@Sucurdesb", SqlDbType.VarChar, 2, Sucurdes)
            MyBase.AddParameter("@Idtraspasob", SqlDbType.Int, 32, IdTraspaso)
            MyBase.AddParameter("@idprotrasb", SqlDbType.Int, 32, IdProtras)

            MyBase.FillDataSet(usp_TraerTraspasoManualEnvioDet, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursalTraspResAut() As DataSet
        'mreyes 23/Febrero/2017 01:12 p.m.
        Try
            usp_TraerSucursalTraspResAut = New DataSet
            MyBase.SQL = "usp_TraerSucursalTraspResAut"

            MyBase.InitializeCommand()


            MyBase.FillDataSet(usp_TraerSucursalTraspResAut, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTraspasoManualReciboDet(ByVal Sucursal As String, ByVal Traspaso As String, _
                                                     ByVal Sucurori As String, ByVal IdTraspaso As Integer) As DataSet
        'mreyes 10/Diciembre/2016   10:53 a.m.
        Try
            usp_TraerTraspasoManualReciboDet = New DataSet
            MyBase.SQL = "usp_TraerTraspasoManualReciboDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Traspasob", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@Sucurorib", SqlDbType.VarChar, 2, Sucurori)
            MyBase.AddParameter("@Idtraspasob", SqlDbType.Int, 6, IdTraspaso)

            MyBase.FillDataSet(usp_TraerTraspasoManualReciboDet, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDescripModelo(ByVal Marca As String, ByVal Modelo As String) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            usp_TraerDescripModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerDescripModelo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", SqlDbType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", SqlDbType.Char, 7, Modelo)


            MyBase.FillDataSet(usp_TraerDescripModelo, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioUltimoTraspDes(ByVal Sucursal As String) As DataSet
        'mreyes 10/Diciembre/2016   10:00 a.m.
        Try
            usp_TraerFolioUltimoTraspDes = New DataSet
            MyBase.SQL = "usp_TraerFolioUltimoTraspDes"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", SqlDbType.VarChar, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerFolioUltimoTraspDes, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMotivosTrasCan() As DataSet
        'Tony Garcia - 21/Agosto/2013 - 06:20 pm
        Try
            usp_TraerMotivosTrasCan = New DataSet

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerMotivosTrasCan, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_IniciaTransaccion() As Boolean
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "call usp_IniciaTransaccion()"
            'Initialize the Command object
            MyBase.InitializeCommand()
            usp_IniciaTransaccion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TerminaTransaccion() As Boolean
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "call usp_TerminaTransaccion()"
            'Initialize the Command object
            MyBase.InitializeCommand()
            usp_TerminaTransaccion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_RollBackTransaccion() As Boolean
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "call usp_RollBackTransaccion()"
            'Initialize the Command object
            MyBase.InitializeCommand()
            usp_RollBackTransaccion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarEstatusTraspaso(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Estutus As String, ByVal IdTRansporta As Integer, ByVal idususario As Integer) As Boolean
        'mreyes 09/Diciembre/2016   05:01 p.m.
        Try
            MyBase.SQL = "usp_ActualizarEstatusTraspaso"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 2, Estutus)
            MyBase.AddParameter("@transportab", SqlDbType.Int, 4, IdTRansporta)
            MyBase.AddParameter("@idusuariob", SqlDbType.Int, 4, idususario)
            usp_ActualizarEstatusTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSerie(ByVal Serie As String) As DataSet
        'Tony Garcia - 15/Febrero/2013 - 01:20 pm
        Try
            usp_TraerSerie = New DataSet
            MyBase.SQL = "CALL usp_TraerSerie(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerSerie, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdArticulo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        Try
            usp_TraerIdArticulo = New DataSet
            MyBase.SQL = "CALL usp_TraerIdArticulo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", SqlDbType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", SqlDbType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerIdArticulo, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdTraspaso(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        Try
            usp_TraerIdTraspaso = New DataSet
            MyBase.SQL = "usp_TraerIdTraspaso"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 1, Opcion)
            MyBase.AddParameter("@sucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@traspasob", SqlDbType.Char, 6, Traspaso)

            MyBase.FillDataSet(usp_TraerIdTraspaso, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_SerieDev(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try

            MyBase.SQL = "CALL usp_Captura_SerieDev(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@serie", SqlDbType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@sucursal", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@status", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@marca", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", SqlDbType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@medida", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@sucurdes", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("sucurdes"))
            MyBase.AddParameter("@idfolio", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))

            MyBase.AddParameter("@idarticulo", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@precioini", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("precioini"))
            MyBase.AddParameter("@costoini", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("costoini"))
            MyBase.AddParameter("@preciovta", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("preciovta"))
            MyBase.AddParameter("@ultcosto", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("ultcosto"))
            MyBase.AddParameter("@proveedors", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("proveedors"))


            usp_Captura_SerieDev = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaIdTraspasoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Idtraspaso As Integer) As Boolean
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "usp_ActualizaIdTraspasoDet"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 1, Opcion)
            MyBase.AddParameter("@sucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@traspasob", SqlDbType.VarChar, 6, Traspaso)
            MyBase.AddParameter("@idtraspasob", SqlDbType.Int, 32, Idtraspaso)
            usp_ActualizaIdTraspasoDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSeriesEnvioNoReci(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String, _
                                                    ByVal IdTraspaso As Integer) As DataSet
        Try
            usp_TraerSeriesEnvioNoReci = New DataSet
            MyBase.SQL = "CALL usp_TraerSeriesEnvioNoReci(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasob", SqlDbType.Char, 6, Traspaso)
            MyBase.AddParameter("@Sucurdesb", SqlDbType.Char, 2, Sucurdes)
            MyBase.AddParameter("@Idtraspasob", SqlDbType.SmallInt, 6, IdTraspaso)

            MyBase.FillDataSet(usp_TraerSeriesEnvioNoReci, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMotivosTR() As DataSet
        Try
            usp_TraerMotivosTR = New DataSet
            MyBase.SQL = "CALL usp_TraerMotivosTR()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerMotivosTR, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaSeriesEnvioNoReci(ByVal Idtraspaso As Integer, ByVal sucursal As String, ByVal Traspaso As String, _
                                                 ByVal Idarticulo As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, _
                                                 ByVal Medida As String, ByVal Serie As String, ByVal Sucurdes As String, ByVal Idmotivo As Integer, ByVal Observacion As String, _
                                                 ByVal Idusuario As Integer) As Boolean
        Try

            MyBase.SQL = "CALL usp_CapturaSeriesEnvioNoReci(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@Idtraspasob", SqlDbType.SmallInt, 6, Idtraspaso)
            MyBase.AddParameter("@sucursal", SqlDbType.Char, 2, sucursal)
            MyBase.AddParameter("@Traspasob", SqlDbType.Char, 6, Traspaso)
            MyBase.AddParameter("@idarticulob", SqlDbType.SmallInt, 6, Idarticulo)
            MyBase.AddParameter("@marca", SqlDbType.Char, 3, Marca)
            MyBase.AddParameter("@estilon", SqlDbType.Char, 7, Estilon)
            MyBase.AddParameter("@corrida", SqlDbType.Char, 3, Corrida)
            MyBase.AddParameter("@medida", SqlDbType.Char, 3, Medida)
            MyBase.AddParameter("@serie", SqlDbType.Char, 13, Serie)
            MyBase.AddParameter("@sucurdes", SqlDbType.Char, 2, Sucurdes)
            MyBase.AddParameter("@idmotivo", SqlDbType.SmallInt, 2, Idmotivo)
            MyBase.AddParameter("@observacion", SqlDbType.Text, 750, Observacion)
            MyBase.AddParameter("@idusuario", SqlDbType.SmallInt, 2, Idusuario)


            usp_CapturaSeriesEnvioNoReci = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieRegresoTR(ByVal Serie As String, ByVal Sucursal As String, ByVal SucurDes As String) As Boolean
        Try
            MyBase.SQL = "call usp_ActualizarSerieRegresoTR(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SerieB", SqlDbType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", SqlDbType.Char, 2, Sucursal)
            MyBase.AddParameter("@SucurDesB", SqlDbType.Char, 2, SucurDes)

            usp_ActualizarSerieRegresoTR = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSerieEnDetTraspasoAC(ByVal Serie As String) As DataSet
        Try
            usp_TraerSerieEnDetTraspasoAC = New DataSet
            MyBase.SQL = "CALL usp_TraerSerieEnDetTraspasoAC(?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@serieb", SqlDbType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerSerieEnDetTraspasoAC, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCtdTraspasosOri(ByVal SucurOri As String, ByVal Referenc As String, ByVal IdReferenc As Integer) As DataSet
        'mreyes 10/Diciembre/2016   09:41 a.m.
        Try
            usp_TraerCtdTraspasosOri = New DataSet
            MyBase.SQL = "usp_TraerCtdTraspasosOri"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@sucurorib", SqlDbType.VarChar, 2, SucurOri)
            MyBase.AddParameter("@referencb", SqlDbType.VarChar, 6, Referenc)
            MyBase.AddParameter("@idreferencB", SqlDbType.Int, 32, IdReferenc)

            MyBase.FillDataSet(usp_TraerCtdTraspasosOri, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalBitacoraPedBod(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'fdoadame 14/Diciembre/2017   05:00 p.m.
        Try
            usp_PpalBitacoraPedBod = New DataSet
            MyBase.SQL = "usp_PpalBitacoraPedBod"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaInicial", SqlDbType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinal", SqlDbType.Date, 10, FechaFin)
            MyBase.FillDataSet(usp_PpalBitacoraPedBod, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalNegPropuestaVendido(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 14/Mayo/2019    01:20 p.m.    
        Try
            usp_PpalNegPropuestaVendido = New DataSet
            MyBase.SQL = "usp_PpalNegPropuestaVendido"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaInib", SqlDbType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.Date, 10, FechaFin)
            MyBase.FillDataSet(usp_PpalNegPropuestaVendido, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



#End Region
End Class
