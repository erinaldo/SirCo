Public Class BCLTraspasosSQL
    'mreyes 09/Diciembre/2016   10:47 a.m.

    Implements IDisposable
    Private objDALTraspasos As DAL.DALTraspasosSQL
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALTraspasos = New DAL.DALTraspasosSQL(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALTraspasos.Dispose()
            objDALTraspasos = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "

    Public Function Inserta_SerieDev() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_SerieDev = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_SerieDev.Tables.Add("seriedev")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("serie", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucurdes", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfolio", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idarticulo", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("precioini", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costoini", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("preciovta", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ultcosto", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedors", Type.GetType("System.String"))
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTrasPendRecibo(ByVal OpcionSP As Integer, ByVal SucurOri As String, ByVal SucurDes As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'Tony Garcia - 22/Julio/2013 - 04:30 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerTrasPendRecibo = objDALTraspasos.usp_TraerTrasPendRecibo(OpcionSP, SucurOri, SucurDes, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasos(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 8/Octubre/2012 05:27 p.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasos(Sucursal, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosDet(ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 9/Octubre/2012 12:30 p.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosDet(Sucursal, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosSerie(ByVal Serie As String) As DataSet
        'miguel pérez 9/Octubre/2012 4:53 p.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosSerie(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosSerieDet(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Serie As String) As DataSet
        'Tony Garcia - 22/08/2013 - 11:22 am
        Try
            Return objDALTraspasos.usp_TraerTraspasosSerieDet(Sucursal, Traspaso, Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProTraspDet(ByVal IdProtrasB As Integer, ByVal MarcaB As String, ByVal EstilonB As String, ByVal MedidaB As String) As DataSet
        'mreyes 20/Enero/2017   01:02 p.m.
        Try
            Return objDALTraspasos.usp_TraerProTraspDet(IdProtrasB, MarcaB, EstilonB, MedidaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTraspasosFolios(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, _
                                             ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String) As DataSet
        'miguel pérez 10/Octubre/2012 9:43 a.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosFolios(FolioA, FolioB, Sucursal, FechaIni, FechaFin, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosNoSurtidos(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Serie As String, ByVal FolioA As String, ByVal FolioB As String) As DataSet
        'miguel pérez 13/Octubre/2012 07:19 p.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosNoSurtidos(Sucursal, FechaIni, FechaFin, Serie, FolioA, FolioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosRecibidos(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 22/Octubre/2012 07:06 p.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosRecibidos(Sucursal, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosRecibidosDet(ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 9/Octubre/2012 12:30 p.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosRecibidosDet(Sucursal, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasosFoliosRecibidos(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, _
                                             ByVal FechaIni As String, ByVal FechaFin As String, ByVal Estatus As String, ByVal SucursalOri As String) As DataSet
        'miguel pérez 23/Octubre/2012 9:42 a.m.
        Try
            Return objDALTraspasos.usp_TraerTraspasosFoliosRecibidos(FolioA, FolioB, Sucursal, FechaIni, FechaFin, Estatus, SucursalOri)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSeriesTraspasos(ByVal Sucursal As String, ByVal SucurDes As String, ByVal Traspaso As String) As DataSet
        'miguel pérez 24/Octubre/2012 6:08 p.m.
        Try
            Return objDALTraspasos.usp_TraerSeriesTraspasos(Sucursal, SucurDes, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioUltimoTraspaso(ByVal Sucursal As String) As DataSet
        'miguel pérez 30/Octubre/2012 1:33 p.m.
        Try
            Return objDALTraspasos.usp_TraerFolioUltimoTraspaso(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarFolioTraspaso(ByVal Folio As String, ByVal Sucursal As String) As Boolean
        'miguel pérez 30/Octubre/2012 04:11 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasos.usp_ActualizarFolioTraspaso(Folio, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaTraspasoOri(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal IdFolio As Integer, ByVal Estatus As String, _
                                           ByVal Fecha As String, ByVal Hora As String, ByVal SucurDes As String, ByVal Observa As String, ByVal Usuario As String, _
                                           ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal, ByVal Envia As Integer, _
                                           ByVal Transporta As Integer, ByVal IdUsuario As Integer, ByVal IdProTras As Integer) As Boolean
        'miguel pérez 30/Octubre/2012 04:26 p.m.
        Try

            'Call the data component to add the new group
            Return objDALTraspasos.usp_CapturaTraspasoOri(Opcion, Sucursal, Traspaso, Tipo, IdFolio, Estatus, Fecha, Hora, SucurDes, Observa, Usuario, _
                                                          Ctd, Costo, Precio, Envia, Transporta, IdUsuario, IdProTras)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaTraspasoSAL(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal Estatus As String, _
                                       ByVal TipoRec As String, ByVal Fecha As String, ByVal Hora As String, ByVal SucurOri As String, _
                                       ByVal Referenc As String, ByVal Observa As String, ByVal Usuario As String, _
                                       ByVal IdReferenc As Integer, ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal, _
                                       ByVal Recibe As Integer, ByVal IdUsuario As Integer) As Boolean
        'mreyes 13/Diciembre/2016   02:15 p.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_CapturaTraspasoSAL(Opcion, Sucursal, Traspaso, Tipo, TipoRec, Estatus, Fecha, Hora, SucurOri, Referenc, Observa, Usuario, _
                                                          IdReferenc, Ctd, Costo, Precio, Recibe, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaTraspasoDes(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Tipo As String, ByVal Estatus As String,
                                           ByVal TipoRec As String, ByVal Fecha As String, ByVal Hora As String, ByVal SucurOri As String,
                                           ByVal Referenc As String, ByVal Observa As String, ByVal Usuario As String,
                                           ByVal IdReferenc As Integer, ByVal Ctd As Integer, ByVal Costo As Decimal, ByVal Precio As Decimal,
                                           ByVal Recibe As Integer, ByVal IdUsuario As Integer, ByVal IdProtras As Integer) As Boolean
        'Tony Garcia - 21/Agosto/2013 - 09:10 am
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_CapturaTraspasoDes(Opcion, Sucursal, Traspaso, Tipo, TipoRec, Estatus, Fecha, Hora, SucurOri, Referenc, Observa, Usuario,
                                                          IdReferenc, Ctd, Costo, Precio, Recibe, IdUsuario, IdProtras)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraReciboTraspaso(ByVal Sucursal As String, ByVal Traspaso As String,
                                                SucursalDes As String, Observaciones As String, Usuario As String, IdUsuario As Integer) As Boolean
        'mreyes 22/Enero/2021   12:08 p.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_GeneraReciboTraspaso(Sucursal, Traspaso, SucursalDes, Observaciones, Usuario, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraTraspasoReciboMYSQL(IdFolio As Integer, IdTraspaso As Integer, Sucursal As String, Traspaso As String) As Boolean
        'mreyes 22/Enero/2021   12:08 p.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_GeneraTraspasoReciboMYSQL(IdFolio, IdTraspaso, Sucursal, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaDetTraspasoOri(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                              ByVal IdArticulo As Integer, ByVal Marca As String, _
                                              ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                              ByVal Serie As String, ByVal ctdori As Integer, ByVal CostoMargen As Double, ByVal Costo As Double, ByVal Precio As Double) As Boolean
        'miguel pérez 30/Octubre/2012 04:51 p.m.
        Try

            'Call the data component to add the new group
            Return objDALTraspasos.usp_CapturaDetTraspasoOri(Opcion, Idtraspaso, Sucursal, Traspaso, IdArticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, ctdori, CostoMargen, Costo, Precio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaDetTraspasoDes(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                              ByVal IdArticulo As Integer, ByVal Marca As String, _
                                              ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                              ByVal Serie As String, ByVal ctddes As Integer, ByVal CostoMargen As Double, ByVal Costo As Double, ByVal Precio As Double) As Boolean

        'mreyes 10/Diciembre/2016   10:13 a.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_CapturaDetTraspasoDes(Opcion, Idtraspaso, Sucursal, Traspaso, IdArticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, ctddes, CostoMargen, Costo, Precio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaDetTraspasoSal(ByVal Opcion As Integer, ByVal Idtraspaso As Integer, ByVal Sucursal As String, ByVal Traspaso As String, _
                                          ByVal IdArticulo As Integer, ByVal Marca As String, _
                                          ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Medida As String, _
                                          ByVal Serie As String, ByVal ctddes As Integer, ByVal CostoMargen As Double, ByVal Costo As Double, ByVal Precio As Double) As Boolean

        'mreyes 10/Diciembre/2016   10:13 a.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_CapturaDetTraspasoSal(Opcion, Idtraspaso, Sucursal, Traspaso, IdArticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, ctddes, CostoMargen, Costo, Precio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerie(ByVal Serie As String, ByVal Sucursal As String, ByVal Estatus As String, ByVal SucurDes As String) As Boolean
        'miguel pérez 30/Octubre/2012 05:03 p.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_ActualizarSerie(Serie, Sucursal, Estatus, SucurDes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarDetTraspasoSal(ByVal Sucursal As String, ByVal Traspaso As String) As Boolean
        Try
            Return objDALTraspasos.usp_ActualizarDetTraspasoSal(Sucursal, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarDetTraspasoRecibido(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Serie As String, ByVal Recibido As String, ByVal IdTraspdes As Integer) As Boolean
        Try
            Return objDALTraspasos.usp_ActualizarDetTraspasoRecibido(Sucursal, Traspaso, Serie, Recibido, IdTraspdes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieRecibo(ByVal Serie As String, ByVal Sucursal As String, ByVal Estatus As String, ByVal SucurDes As String) As Boolean
        'miguel pérez 30/Octubre/2012 05:03 p.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_ActualizarSerieRecibo(Serie, Sucursal, Estatus, SucurDes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieReciboDev(ByVal Serie As String, ByVal Sucursal As String, ByVal Estatus As String, ByVal SucurDes As String) As Boolean
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_ActualizarSerieReciboDev(Serie, Sucursal, Estatus, SucurDes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCostoSerie(ByVal Serie As String) As DataSet
        'miguel pérez 30/Octubre/2012 05:05 p.m.
        Try
            Return objDALTraspasos.usp_TraerCostoSerie(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarTraspasoAutomatico(ByVal Sucursal As String, ByVal Traspaso As String) As Boolean
        'miguel pérez 08/Noviembre/2012 9:41 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasos.usp_ActualizarTraspasoAutomatico(Sucursal, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoSerieDescrip(ByVal Serie As String) As DataSet
        'Tony Garcia - 15/Agosto/2013 - 05:20 pm
        Try
            Return objDALTraspasos.usp_TraerTraspasoSerieDescrip(Serie)
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
            Return objDALTraspasos.usp_PpalTraspasosManualOri(Sucursal, TraspasoIni, TraspasoFin, Sucurdes, FechaIni, FechaFin, Estatus, IdTraspasoIni, IdTraspasoFin, FechaCanIni, FechaCanFin)
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
            Return objDALTraspasos.usp_PpalTraspasosDevOri(Sucursal, TraspasoIni, TraspasoFin, Sucurdes, FechaIni, FechaFin, Estatus, IdTraspasoIni, IdTraspasoFin, FechaCanIni, FechaCanFin)
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
            Return objDALTraspasos.usp_PpalTraspasosManualDes(Sucursal, TraspasoIni, TraspasoFin, Sucurori, Referenc, FechaIni, FechaFin, Estatus, IdTraspasoIni, IdTraspasoFin, FechaCanIni, FechaCanFin)
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
            Return objDALTraspasos.usp_PpalTraspasosDevDes(Sucursal, TraspasoIni, TraspasoFin, Sucurori, Referenc, FechaIni, FechaFin, Estatus, IdTraspasoIni, IdTraspasoFin, FechaCanIni, FechaCanFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoManualEnvioDet(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String,
                                                    ByVal IdTraspaso As Integer, ByVal Idprotras As Integer) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            Return objDALTraspasos.usp_TraerTraspasoManualEnvioDet(Sucursal, Traspaso, Sucurdes, IdTraspaso, Idprotras)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursalTraspResAut() As DataSet
        'mreyes 23/Febrero/2017     01:12 p.m.
        Try
            Return objDALTraspasos.usp_TraerSucursalTraspResAut()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerTraspasoManualReciboDet(ByVal Sucursal As String, ByVal Traspaso As String, _
                                                     ByVal Sucurori As String, ByVal IdTraspaso As Integer) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            Return objDALTraspasos.usp_TraerTraspasoManualReciboDet(Sucursal, Traspaso, Sucurori, IdTraspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDescripModelo(ByVal Marca As String, ByVal Modelo As String) As DataSet
        'Tony Garcia - 19/Agosto/2013 - 11:20 am
        Try
            Return objDALTraspasos.usp_TraerDescripModelo(Marca, Modelo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioUltimoTraspDes(ByVal Sucursal As String) As DataSet
        'Tony Garcia - 20/Agosto/2013 - 06:20 pm
        Try
            Return objDALTraspasos.usp_TraerFolioUltimoTraspDes(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMotivosTrasCan() As DataSet
        'Tony Garcia - 21/Agosto/2013 - 06:20 pm
        Try
            Return objDALTraspasos.usp_TraerMotivosTrasCan()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_IniciaTransaccion() As Boolean
        'miguel pérez 08/Noviembre/2012 9:41 a.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_IniciaTransaccion()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TerminaTransaccion() As Boolean
        'miguel pérez 08/Noviembre/2012 9:41 a.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_TerminaTransaccion()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_RollBackTransaccion() As Boolean
        'miguel pérez 08/Noviembre/2012 9:41 a.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_RollBackTransaccion()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarEstatusTraspaso(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Estutus As String, ByVal IdTRansporta As Integer, ByVal idususario As Integer) As Boolean
        'miguel pérez 08/Noviembre/2012 9:41 a.m.
        Try
            'Call the data component to add the new group
            Return objDALTraspasos.usp_ActualizarEstatusTraspaso(Opcion, Sucursal, Traspaso, Estutus, IdTRansporta, idususario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSerie(ByVal Serie As String) As DataSet
        'Tony Garcia - 15/Febrero/2013 - 01:20 pm
        Try
            Return objDALTraspasos.usp_TraerSerie(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdArticulo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        Try
            Return objDALTraspasos.usp_TraerIdArticulo(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdTraspaso(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String) As DataSet
        Try
            Return objDALTraspasos.usp_TraerIdTraspaso(Opcion, Sucursal, Traspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_SerieDev(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasos.usp_Captura_SerieDev(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaIdTraspasoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Traspaso As String, ByVal Idtraspaso As Integer) As Boolean

        Try
            Return objDALTraspasos.usp_ActualizaIdTraspasoDet(Opcion, Sucursal, Traspaso, Idtraspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSeriesEnvioNoReci(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String, _
                                                    ByVal IdTraspaso As Integer) As DataSet
        Try
            Return objDALTraspasos.usp_TraerSeriesEnvioNoReci(Sucursal, Traspaso, Sucurdes, IdTraspaso)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMotivosTR() As DataSet
        Try
            Return objDALTraspasos.usp_TraerMotivosTR()
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

            Return objDALTraspasos.usp_CapturaSeriesEnvioNoReci(Idtraspaso, sucursal, Traspaso, Idarticulo, Marca, Estilon, Corrida, Medida, _
                                                                Serie, Sucurdes, Idmotivo, Observacion, Idusuario)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieRegresoTR(ByVal Serie As String, ByVal Sucursal As String, ByVal SucurDes As String) As Boolean
        Try
            Return objDALTraspasos.usp_ActualizarSerieRegresoTR(Serie, Sucursal, SucurDes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSerieEnDetTraspasoAC(ByVal Serie As String) As DataSet
        Try
            Return objDALTraspasos.usp_TraerSerieEnDetTraspasoAC(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCtdTraspasosOri(ByVal SucurOri As String, ByVal Referenc As String, ByVal IdReferenc As Integer) As DataSet
        Try
            Return objDALTraspasos.usp_TraerCtdTraspasosOri(SucurOri, Referenc, IdReferenc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNegPropuestaVendido(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 05/Mayo/2019    01:19 p.m.
        Try
            Return objDALTraspasos.usp_PpalNegPropuestaVendido(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalBitacoraPedBod(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'fdoadame 14/Diciembre/2017   05:00 p.m.
        Try
            Return objDALTraspasos.usp_PpalBitacoraPedBod(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
