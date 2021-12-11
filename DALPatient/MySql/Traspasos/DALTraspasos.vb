Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALTraspasos
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
    Public Function usp_TraerTrasPendRecibo(ByVal OpcionSP As Integer, ByVal SucurOri As String, ByVal SucurDes As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'Tony Garcia - 22/Julio/2013 - 04:30 p.m.
        Try
            usp_TraerTrasPendRecibo = New DataSet
            MyBase.SQL = "CALL usp_TraerTrasPendRecibo(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", OdbcType.Int, 4, OpcionSP)
            MyBase.AddParameter("@SucuroriB", OdbcType.Char, 2, SucurOri)
            MyBase.AddParameter("@SucurdesB", OdbcType.Char, 2, SucurDes)
            MyBase.AddParameter("@fechainiB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@fechafinB", OdbcType.Char, 10, FechaFin)
            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTrasPendRecibo, "cipsis")
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
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@feciniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@fecfinB", OdbcType.Char, 10, FechaFin)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosDet(ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 9/Octubre/2012 12:28 p.m.
        Try
            usp_TraerTraspasosDet = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosDet(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosDet, "cipsis")
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
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosSerie, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosSerieDet(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Serie As String) As DataSet
        'Tony Garcia - 22/08/2013 - 11:22 am
        Try
            usp_TraerTraspasosSerieDet = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosSerieDet(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosSerieDet, "cipsis")
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
            MyBase.AddParameter("@FolioA", OdbcType.Char, 6, FolioA)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, FolioB)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIni", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosFolios, "cipsis")
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
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIni", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@FolioA", OdbcType.Char, 6, FolioA)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, FolioB)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosNoSurtidos, "cipsis")
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
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@feciniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@fecfinB", OdbcType.Char, 10, FechaFin)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosRecibidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosRecibidosDet(ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 22/Octubre/2012 07:21 p.m.
        Try
            usp_TraerTraspasosRecibidosDet = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasosRecibidosDet(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosRecibidosDet, "cipsis")
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
            MyBase.AddParameter("@FolioA", OdbcType.Char, 6, FolioA)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, FolioB)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FechaIni", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@SucursalOriB", OdbcType.Char, 2, SucursalOri)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerTraspasosFoliosRecibidos, "cipsis")
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
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurDes)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerSeriesTraspasos, "cipsis")
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
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

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

            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            usp_ActualizarFolioTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaTraspasoOri(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal IdFolio As Integer, ByVal Estatus As String, _
                                           ByVal Fecha As String, ByVal Hora As String, ByVal SucurDes As String, ByVal Observa As String, ByVal Usuario As String, _
                                           ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal, ByVal Envia As Integer, _
                                           ByVal Transporta As Integer, ByVal IdUsuario As Integer) As Boolean
        'miguel pérez 30/Octubre/2012 04:24 p.m.
        Try
            MyBase.SQL = "call usp_CapturaTraspasoOri(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@idfolioB", OdbcType.Int, 16, IdFolio)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", OdbcType.Char, 8, Hora)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurDes)
            MyBase.AddParameter("@ObservaB", OdbcType.Char, 60, Observa)
            MyBase.AddParameter("@UsuarioB", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@CtdB", OdbcType.SmallInt, 6, Ctd)
            MyBase.AddParameter("@CostoB", OdbcType.Double, 9, Costo)
            MyBase.AddParameter("@PrecioB", OdbcType.Double, 9, Precio)
            MyBase.AddParameter("@EnviaB", OdbcType.SmallInt, 4, Envia)
            MyBase.AddParameter("@TransportaB", OdbcType.SmallInt, 4, Transporta)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.SmallInt, 4, IdUsuario)

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
                                           ByVal Recibe As Integer, ByVal IdUsuario As Integer) As Boolean
        'Tony Garcia - 21/Agosto/2013 - 09:10 am
        Try
            MyBase.SQL = "call usp_CapturaTraspasoDes(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@TipoRecB", OdbcType.Char, 1, TipoRec)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", OdbcType.Char, 8, Hora)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurOri)
            MyBase.AddParameter("@ReferencB", OdbcType.Char, 6, Referenc)
            MyBase.AddParameter("@ObservaB", OdbcType.Char, 60, Observa)
            MyBase.AddParameter("@UsuarioB", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@IdReferencB", OdbcType.Int, 32, IdReferenc)
            MyBase.AddParameter("@CtdB", OdbcType.SmallInt, 6, Ctd)
            MyBase.AddParameter("@CostoB", OdbcType.Double, 9, Costo)
            MyBase.AddParameter("@PrecioB", OdbcType.Double, 9, Precio)
            MyBase.AddParameter("@RecibeB", OdbcType.SmallInt, 4, Recibe)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.SmallInt, 4, IdUsuario)

            usp_CapturaTraspasoDes = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaDetTraspasoOri(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                              ByVal IdArticulo As Integer, ByVal Marca As String, _
                                              ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                              ByVal Serie As String, ByVal ctdori As Integer, ByVal Costo As Double, ByVal Precio As Double) As Boolean
        'miguel pérez 30/Octubre/2012 04:24 p.m.
        Try
            MyBase.SQL = "call usp_CapturaDetTraspasoOri(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idtraspasob", OdbcType.Int, 6, Idtraspaso)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@idarticuloB", OdbcType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@ctdoriB", OdbcType.SmallInt, 3, ctdori)
            MyBase.AddParameter("@CostoB", OdbcType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", OdbcType.Decimal, 9, Precio)


            usp_CapturaDetTraspasoOri = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaDetTraspasoDes(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                              ByVal IdArticulo As Integer, ByVal Marca As String, _
                                              ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                              ByVal Serie As String, ByVal ctddes As Integer, ByVal Costo As Double, ByVal Precio As Double) As Boolean
        'Tony Garcia - 21/Agosto/2013 - 09:10 am
        Try
            MyBase.SQL = "call usp_CapturaDetTraspasoDes(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idtraspasob", OdbcType.Int, 16, Idtraspaso)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@idarticuloB", OdbcType.SmallInt, 6, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@ctddesB", OdbcType.SmallInt, 3, ctddes)
            MyBase.AddParameter("@CostoB", OdbcType.Decimal, 9, Costo)
            MyBase.AddParameter("@PrecioB", OdbcType.Decimal, 9, Precio)

            usp_CapturaDetTraspasoDes = ExecuteStoredProcedure()
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

            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurDes)

            usp_ActualizarSerie = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarDetTraspasoRecibido(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Serie As String, ByVal Recibido As String, ByVal IdTraspdes As Integer) As Boolean
        'miguel pérez 31/Octubre/2012 05:01 p.m.
        Try
            MyBase.SQL = "call usp_ActualizarDetTraspasoRecibido(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@RecibidoB", OdbcType.Char, 1, Recibido)
            MyBase.AddParameter("@IdTraspdesB", OdbcType.Int, 32, IdTraspdes)

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

            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurDes)

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

            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurDes)

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
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            'Execute the stored procedure
            MyBase.FillDataSet(usp_TraerCostoSerie, "cipsis")
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

            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)

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
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerTraspasoSerieDescrip, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalTraspasosManualOri(ByVal Sucursal As String, ByVal TraspasoIni As String, ByVal TraspasoFin As String, ByVal Sucurdes As String, _
                                               ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String, _
                                               ByVal IdTraspasoIni As Integer, ByVal IdTraspasoFin As Integer, ByVal FechaCanIni As String, ByVal FechaCanFin As String) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            usp_PpalTraspasosManualOri = New DataSet
            MyBase.SQL = "CALL usp_PpalTraspasosManualOri(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", OdbcType.Char, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", OdbcType.Char, 6, TraspasoFin)
            MyBase.AddParameter("@sucurdesb", OdbcType.Char, 2, Sucurdes)
            MyBase.AddParameter("@FechaInib", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", OdbcType.SmallInt, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", OdbcType.SmallInt, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", OdbcType.Char, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", OdbcType.Char, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosManualOri, "cipsis")
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
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", OdbcType.Char, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", OdbcType.Char, 6, TraspasoFin)
            MyBase.AddParameter("@sucurdesb", OdbcType.Char, 2, Sucurdes)
            MyBase.AddParameter("@FechaInib", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", OdbcType.SmallInt, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", OdbcType.SmallInt, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", OdbcType.Char, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", OdbcType.Char, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosDevOri, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalTraspasosManualDes(ByVal Sucursal As String, ByVal TraspasoIni As String, ByVal TraspasoFin As String, ByVal Sucurori As String, _
                                               ByVal Referenc As String, ByVal FechaIni As String, ByVal FechaFin As String, _
                                               ByVal Estatus As String, ByVal IdTraspasoIni As Integer, ByVal IdTraspasoFin As Integer, ByVal FechaCanIni As String, ByVal FechaCanFin As String) As DataSet
        'Tony Garcia - 20/Agosto/2013 - 11:20 am
        Try
            usp_PpalTraspasosManualDes = New DataSet
            MyBase.SQL = "CALL usp_PpalTraspasosManualDes(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", OdbcType.Char, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", OdbcType.Char, 6, TraspasoFin)
            MyBase.AddParameter("@sucurorib", OdbcType.Char, 2, Sucurori)
            MyBase.AddParameter("@Referencb", OdbcType.Char, 6, Referenc)
            MyBase.AddParameter("@FechaInib", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", OdbcType.SmallInt, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", OdbcType.SmallInt, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", OdbcType.Char, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", OdbcType.Char, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosManualDes, "cipsis")
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
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasoinib", OdbcType.Char, 6, TraspasoIni)
            MyBase.AddParameter("@Traspasofinb", OdbcType.Char, 6, TraspasoFin)
            MyBase.AddParameter("@sucurorib", OdbcType.Char, 2, Sucurori)
            MyBase.AddParameter("@Referencb", OdbcType.Char, 6, Referenc)
            MyBase.AddParameter("@FechaInib", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinb", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@Idtraspasoinib", OdbcType.SmallInt, 6, IdTraspasoIni)
            MyBase.AddParameter("@Idtraspasofinb", OdbcType.SmallInt, 6, IdTraspasoFin)
            MyBase.AddParameter("@FechacanInib", OdbcType.Char, 10, FechaCanIni)
            MyBase.AddParameter("@FechacanFinb", OdbcType.Char, 10, FechaCanFin)

            MyBase.FillDataSet(usp_PpalTraspasosDevDes, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoManualEnvioDet(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String, _
                                                    ByVal IdTraspaso As Integer) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            usp_TraerTraspasoManualEnvioDet = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasoManualEnvioDet(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasob", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@Sucurdesb", OdbcType.Char, 2, Sucurdes)
            MyBase.AddParameter("@Idtraspasob", OdbcType.Int, 32, IdTraspaso)

            MyBase.FillDataSet(usp_TraerTraspasoManualEnvioDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoManualReciboDet(ByVal Sucursal As String, ByVal Traspaso As String, _
                                                     ByVal Sucurori As String, ByVal IdTraspaso As Integer) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            usp_TraerTraspasoManualReciboDet = New DataSet
            MyBase.SQL = "CALL usp_TraerTraspasoManualReciboDet(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasob", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@Sucurorib", OdbcType.Char, 2, Sucurori)
            MyBase.AddParameter("@Idtraspasob", OdbcType.SmallInt, 6, IdTraspaso)

            MyBase.FillDataSet(usp_TraerTraspasoManualReciboDet, "cipsis")
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
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)


            MyBase.FillDataSet(usp_TraerDescripModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioUltimoTraspDes(ByVal Sucursal As String) As DataSet
        'Tony Garcia - 20/Agosto/2013 - 06:20 pm
        Try
            usp_TraerFolioUltimoTraspDes = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioUltimoTraspDes(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerFolioUltimoTraspDes, "cipsis")
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

            MyBase.FillDataSet(usp_TraerMotivosTrasCan, "cipsis")
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
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "call usp_ActualizarEstatusTraspaso(?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@TraspasoB", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@EstutusB", OdbcType.Char, 2, Estutus)
            MyBase.AddParameter("@idtransportab", OdbcType.SmallInt, 4, IdTRansporta)
            MyBase.AddParameter("@idusuariob", OdbcType.SmallInt, 4, idususario)
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
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerSerie, "cipsis")
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
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerIdArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdTraspaso(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        Try
            usp_TraerIdTraspaso = New DataSet
            MyBase.SQL = "CALL usp_TraerIdTraspaso(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@traspasob", OdbcType.Char, 6, Traspaso)

            MyBase.FillDataSet(usp_TraerIdTraspaso, "cipsis")
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

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@status", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@sucurdes", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucurdes"))
            MyBase.AddParameter("@idfolio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfolio"))

            MyBase.AddParameter("@idarticulo", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@precioini", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precioini"))
            MyBase.AddParameter("@costoini", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costoini"))
            MyBase.AddParameter("@preciovta", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("preciovta"))
            MyBase.AddParameter("@ultcosto", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("ultcosto"))
            MyBase.AddParameter("@proveedors", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedors"))


            usp_Captura_SerieDev = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaIdTraspasoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Idtraspaso As Integer) As Boolean
        'miguel pérez 08/Noviembre/2012 09:40 a.m.
        Try
            MyBase.SQL = "call usp_ActualizaIdTraspasoDet(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@traspasob", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@idtraspasob", OdbcType.Int, 32, Idtraspaso)
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
            MyBase.AddParameter("@Sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Traspasob", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@Sucurdesb", OdbcType.Char, 2, Sucurdes)
            MyBase.AddParameter("@Idtraspasob", OdbcType.SmallInt, 6, IdTraspaso)

            MyBase.FillDataSet(usp_TraerSeriesEnvioNoReci, "cipsis")
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

            MyBase.FillDataSet(usp_TraerMotivosTR, "cipsis")
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

            MyBase.AddParameter("@Idtraspasob", OdbcType.SmallInt, 6, Idtraspaso)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, sucursal)
            MyBase.AddParameter("@Traspasob", OdbcType.Char, 6, Traspaso)
            MyBase.AddParameter("@idarticulob", OdbcType.SmallInt, 6, Idarticulo)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corrida", OdbcType.Char, 3, Corrida)
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@sucurdes", OdbcType.Char, 2, Sucurdes)
            MyBase.AddParameter("@idmotivo", OdbcType.SmallInt, 2, Idmotivo)
            MyBase.AddParameter("@observacion", OdbcType.Text, 750, Observacion)
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 2, idusuario)


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

            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@SucurDesB", OdbcType.Char, 2, SucurDes)

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

            MyBase.AddParameter("@serieb", OdbcType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerSerieEnDetTraspasoAC, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCtdTraspasosOri(ByVal SucurOri As String, ByVal Referenc As String, ByVal IdReferenc As Integer) As DataSet
        Try
            usp_TraerCtdTraspasosOri = New DataSet
            MyBase.SQL = "CALL usp_TraerCtdTraspasosOri(?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@sucurorib", OdbcType.Char, 2, SucurOri)
            MyBase.AddParameter("@referencb", OdbcType.Char, 6, Referenc)
            MyBase.AddParameter("@idreferencB", OdbcType.Int, 32, IdReferenc)

            MyBase.FillDataSet(usp_TraerCtdTraspasosOri, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
