Public Class BCLResurtido
    'miguel pérez 12/Noviembre/2012 05:53 p.m.

    Implements IDisposable
    Private objDALPedidos As DAL.DALResurtido
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPedidos = New DAL.DALResurtido(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPedidos.Dispose()
            objDALPedidos = Nothing
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

    Public Function usp_TraerEstilosVendExis(ByVal FechaIni As String, ByVal FechaFin As String, ByVal Sucursal As String, ByVal Marca As String) As DataSet
        'miguel pérez 12/Noviembre/2012 05:55 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstilosVendExis = objDALPedidos.usp_TraerEstilosVendExis(FechaIni, FechaFin, Sucursal, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResmin(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 12/Noviembre/2012 05:55 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerResmin = objDALPedidos.usp_TraerResmin(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMedida2(ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String) As DataSet
        'miguel pérez 12/Noviembre/2012 09:25 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerMedida2 = objDALPedidos.usp_TraerMedida2(Marca, Estilon, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDiasResProv(ByVal Proveedor As String) As DataSet
        'miguel pérez 20/Noviembre/2012 10:10 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerDiasResProv = objDALPedidos.usp_TraerDiasResProv(Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarcasProveedor(ByVal Proveedor As String, ByVal Marca As String) As DataSet
        'miguel pérez 20/Diciembre/2012 02:44 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMarcasProveedor = objDALPedidos.usp_TraerMarcasProveedor(Proveedor, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCantidadPP(ByVal Marca As String, ByVal Sucursal As String) As Integer
        'miguel pérez 20/Diciembre/2012 04:08 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadPP = CInt(objDALPedidos.usp_TraerCantidadPP(Marca, Sucursal).Tables(0).Rows(0).Item("PedidoPendiente"))
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCantidadVentas(ByVal Marca As String, ByVal FecIni As String, ByVal FecFin As String, ByVal Sucursal As String) As Integer
        'miguel pérez 20/Diciembre/2012 04:12 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadVentas = CInt(objDALPedidos.usp_TraerCantidadVentas(Marca, FecIni, FecFin, Sucursal).Tables(0).Rows(0).Item("Ventas"))
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerVentasMedida(ByVal FechaIni As String, ByVal FechaFin As String, ByVal Sucursal As String, ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Estilof As String, ByVal Categoria As String) As DataSet
        'miguel pérez 03/Diciembre/2012 10:12 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerVentasMedida = objDALPedidos.usp_TraerVentasMedida(FechaIni, FechaFin, Sucursal, Marca, Proveedor, Estilon, Estilof, Categoria)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerExistenciaMedida(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Categoria As String) As DataSet
        'miguel pérez 03/Diciembre/2012 11:50 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerExistenciaMedida = objDALPedidos.usp_TraerExistenciaMedida(Sucursal, Marca, Estilon, Proveedor, Categoria)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, _
                                           ByVal Estatus As String, ByVal Marca As String, ByVal Proveedor As String, _
                                           ByVal Fecha As String, ByVal Hora As String, ByVal Observaciones As String, _
                                           ByVal Usuario As String, ByVal DiasResurtido As String) As Boolean
        'miguel pérez 04/Diciembre/2012 2:06 p.m.
        Try
            'Call the data component to get all groups
            usp_CapturaResurtido = objDALPedidos.usp_CapturaResurtido(Resurtido, Sucursal, OrdeComp, Estatus, Marca, Proveedor, Fecha, Hora, Observaciones, Usuario, DiasResurtido)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Estilon As String, ByVal objDataRow As DataRow, ByVal Prioridad As Integer) As Boolean
        'miguel pérez 04/Diciembre/2012 2:06 p.m.
        Try
            'Call the data component to get all groups
            usp_CapturaResurtidoDet = objDALPedidos.usp_CapturaResurtidoDet(Resurtido, Sucursal, Marca, Estilon, objDataRow, Prioridad)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPPMedida(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 03/Diciembre/2012 12:06 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPPMedida = objDALPedidos.usp_TraerPPMedida(Sucursal, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFoliosResurtido(ByVal Sucursal As String, ByVal Opcion As String) As DataSet
        'miguel pérez 4/Diciembre/2012 2:50 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFoliosResurtido = objDALPedidos.usp_TraerFoliosResurtido(Sucursal, Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeCompA As String, ByVal OrdeCompB As String, ByVal FechaA As String, ByVal FechaB As String, ByVal Marca As String, ByVal Proveedor As String, _
                                       ByVal Estatus As String, ByVal Opcion As Integer, ByVal IdEmpleado As Integer) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerResurtido = objDALPedidos.usp_TraerResurtido(Resurtido, Sucursal, OrdeCompA, OrdeCompB, FechaA, FechaB, Marca, Proveedor, Estatus, Opcion, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_TraerResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeCompA As String, ByVal OrdeCompB As String, ByVal FechaA As String, ByVal FechaB As String, ByVal Marca As String, ByVal Proveedor As String, _
    '                                   ByVal Estatus As String, ByVal Opcion As Integer) As DataSet
    '    'miguel pérez 4/Diciembre/2012 5:05 p.m.
    '    Try
    '        'Call the data component to get all groups
    '        usp_TraerResurtido = objDALPedidos.usp_TraerResurtido(Resurtido, Sucursal, OrdeCompA, OrdeCompB, FechaA, FechaB, Marca, Proveedor, Estatus, Opcion)
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_TraerResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Tipo As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerResurtidoDet = objDALPedidos.usp_TraerResurtidoDet(Resurtido, Sucursal, Marca, Estilon, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetOC(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String) As DataSet
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetOC = objDALPedidos.usp_TraerDetOC(Sucursal, OrdeComp, Marca, Estilon, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarDetOC(ByVal Ctd As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Entrega As String, ByVal Cancela As String) As Boolean
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarDetOC = objDALPedidos.usp_ActualizarDetOC(Ctd, Sucursal, OrdeComp, Marca, Estilon, Medida, Entrega, Cancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Estilon As String, ByVal objDataRow As DataRow) As Boolean
        'miguel pérez 05/Diciembre/2012 01:53 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizaResurtidoDet = objDALPedidos.usp_ActualizaResurtidoDet(Resurtido, Sucursal, Marca, Estilon, objDataRow)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstatusResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarEstatusResurtido = objDALPedidos.usp_ActualizarEstatusResurtido(Resurtido, Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstatusOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Fecha As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarEstatusOrdeComp = objDALPedidos.usp_ActualizarEstatusOrdeComp(Sucursal, OrdeComp, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarUltimoResurtido(ByVal FecUltRes As String, ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'miguel pérez 13/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarUltimoResurtido = objDALPedidos.usp_ActualizarUltimoResurtido(FecUltRes, Proveedor, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'miguel pérez 13/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarOrdeComp = objDALPedidos.usp_ActualizarOrdeComp(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarResurtido = objDALPedidos.usp_ActualizarResurtido(Resurtido, Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPedidoPendiente(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String) As DataSet
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPedidoPendiente = objDALPedidos.usp_TraerPedidoPendiente(Sucursal, Marca, Estilon, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarPedidoPendiente(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Cantidad As Integer) As Boolean
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarPedidoPendiente = objDALPedidos.usp_ActualizarPedidoPendiente(Sucursal, Marca, Estilon, Medida, Cantidad)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaPedidoPendiente(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Cantidad As Integer) As Boolean
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_CapturaPedidoPendiente = objDALPedidos.usp_CapturaPedidoPendiente(Sucursal, Marca, Estilon, Medida, Cantidad)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerResurtidoConsolidado(ByVal Fecha As String, ByVal FechaB As String) As DataSet
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerResurtidoConsolidado = objDALPedidos.usp_TraerResurtidoConsolidado(Fecha, FechaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtidoConsolidadoMar(ByVal Fecha As String, ByVal FechaPres As String) As DataSet
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerResurtidoConsolidadoMar = objDALPedidos.usp_TraerResurtidoConsolidadoMar(Fecha, FechaPres)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtidoConsolidadoSuc(ByVal Fecha As String, ByVal FechaPres As String) As DataSet
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerResurtidoConsolidadoSuc = objDALPedidos.usp_TraerResurtidoConsolidadoSuc(Fecha, FechaPres)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasFechas(ByVal Marca As String, ByVal Estilon As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerVentasFechas = objDALPedidos.usp_TraerVentasFechas(Marca, Estilon, FechaIni, FechaFin, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstilosResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstilosResurtidoDet = objDALPedidos.usp_TraerEstilosResurtidoDet(Resurtido, Sucursal, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltVenta(ByVal Marca As String, ByVal Estilon As String, ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFecUltVenta = objDALPedidos.usp_TraerFecUltVenta(Marca, Estilon, Sucursal, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltRecibo(ByVal Marca As String, ByVal Estilon As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFecUltRecibo = objDALPedidos.usp_TraerFecUltRecibo(Marca, Estilon, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarcasPP(ByVal Sucursal As String, ByVal Marca As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMarcasPP = objDALPedidos.usp_TraerMarcasPP(Sucursal, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoRecibo(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerUltimoRecibo = objDALPedidos.usp_TraerUltimoRecibo(Sucursal, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltPedido(ByVal Marca As String, ByVal Estilon As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFecUltPedido = objDALPedidos.usp_TraerFecUltPedido(Marca, Estilon, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPresupuesto(ByVal Sucursal As String, ByVal CostoPedido As Decimal, ByVal Proveedor As String, ByVal Fecha As String) As Boolean
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarPresupuesto = objDALPedidos.usp_ActualizarPresupuesto(Sucursal, CostoPedido, Proveedor, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPresupuesto(ByVal Sucursal As String, ByVal Proveedor As String, ByVal Fecha As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPresupuesto = objDALPedidos.usp_TraerPresupuesto(Sucursal, Proveedor, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDetOCMedida(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetOCMedida = objDALPedidos.usp_TraerDetOCMedida(Sucursal, OrdeComp, Marca, Estilon, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOCSinEnvio(ByVal Sucursal As String, ByVal Proveedor As String, ByVal Marca As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerOCSinEnvio = objDALPedidos.usp_TraerOCSinEnvio(Sucursal, Proveedor, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioRes(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFolioRes = objDALPedidos.usp_TraerFolioRes(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaResurtidoDetMed(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Estilon As String, ByVal objDataRow As DataRow) As Boolean
        'miguel pérez 05/Diciembre/2012 01:53 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizaResurtidoDetMed = objDALPedidos.usp_ActualizaResurtidoDetMed(Resurtido, Sucursal, Marca, Estilon, objDataRow)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarDetOCMed(ByVal Ctd As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Costo As Double, ByVal CostoDesc As Double) As Boolean
        'miguel pérez 5/Diciembre/2012 12:00 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarDetOCMed = objDALPedidos.usp_ActualizarDetOCMed(Ctd, Sucursal, OrdeComp, Marca, Estilon, Medida, Costo, CostoDesc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDatosResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDatosResurtido = objDALPedidos.usp_TraerDatosResurtido(Resurtido, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDatosArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Clasif As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDatosArticulo = objDALPedidos.usp_TraerDatosArticulo(Marca, Estilon, Proveedor, Clasif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursal(ByVal Sucursal As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerSucursal = objDALPedidos.usp_TraerSucursal(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDifEstFamilia(ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDifEstFamilia = objDALPedidos.usp_TraerDifEstFamilia(Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdEstFamilia(ByVal Clasif As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerIdEstFamilia = objDALPedidos.usp_TraerIdEstFamilia(Clasif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetFPMedida(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal FecIni As Date, ByVal FecFin As Date) As DataSet
        'Tony García - 05/10/2013 - 10:20 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetFPMedida = objDALPedidos.usp_TraerDetFPMedida(Sucursal, Marca, Estilon, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProvMarcaModelo(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 4/Diciembre/2012 5:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerProvMarcaModelo = objDALPedidos.usp_TraerProvMarcaModelo(Opcion, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
