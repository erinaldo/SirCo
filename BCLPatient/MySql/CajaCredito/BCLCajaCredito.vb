Public Class BCLCajaCredito

    Implements IDisposable
    Private objDALCaja As DAL.DALCajaCredito
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCaja = New DAL.DALCajaCredito(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
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


    Public Function usp_TraerInfoPagos(ByVal IdPagosB As Integer) As DataSet
        'mreyes 15/Febrero/2016 12:16 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerInfoPagos = objDALCaja.usp_TraerInfoPagos(IdPagosB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalPagoCredito(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Descuento As Double) As DataSet
        Try
            'Call the data component to get all groups
            usp_PpalPagoCredito = objDALCaja.usp_PpalPagoCredito(Opcion, Distrib, Descuento)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPagoCreditoAdelantado(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Descuento As Double) As DataSet
        Try
            'Call the data component to get all groups
            usp_PpalPagoCreditoAdelantado = objDALCaja.usp_PpalPagoCreditoAdelantado(Opcion, Distrib, Descuento)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoDistribuidorPorPago(ByVal Distrib As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerPagoDistribuidorPorPago = objDALCaja.usp_TraerPagoDistribuidorPorPago(Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    


    Public Function usp_CapturaPago(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal Distrib As String, ByVal Status As String, _
                                    ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Descuento As Double, ByVal DescuentoAdicional As Double, _
                                    ByVal Interes As Double, ByVal InteresMor As Double, ByVal GastosCobranza As Double, ByVal Importe As Double, _
                                    ByVal Vencido As Double, ByVal DescuentoVencido As Double, ByVal Cobrador As Integer, ByVal IdConvenio As Integer, _
                                    ByVal IdUsuario As Integer, ByVal Fum As Date, ByVal IdUsuarioCancela As Integer, ByVal FumCancela As Date) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaPago(Opcion, Sucursal, Folio, Distrib, Status, _
                                              Fecha, Subtotal, Descuento, DescuentoAdicional, _
                                              Interes, InteresMor, GastosCobranza, Importe, _
                                              Vencido, DescuentoVencido, Cobrador, IdConvenio, _
                                              IdUsuario, Fum, IdUsuarioCancela, FumCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPagoDet(ByVal IdPago As Integer, ByVal Sucursal As String, ByVal SucNot As String, ByVal Nota As String, ByVal Pago As Integer, _
                                    ByVal Subtotal As Double, ByVal Descuento As Double, ByVal DescuentoAdicional As Double, _
                                    ByVal Interes As Double, ByVal InteresMor As Double, ByVal GastosCobranza As Double, ByVal Importe As Double, _
                                    ByVal Vencido As Double, ByVal DescuentoVencido As Double, ByVal NumPago As Integer, ByVal Pagado As Integer, ByVal PorcDescto As Double, _
                                    ByVal PorcDesctoAdicional As Double, ByVal PorcDesctoVencido As Double, ByVal IdUsuario As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaPagoDet(IdPago, Sucursal, SucNot, Nota, Pago, _
                                              Subtotal, Descuento, DescuentoAdicional, _
                                              Interes, InteresMor, GastosCobranza, Importe, _
                                              Vencido, DescuentoVencido, NumPago, Pagado, _
                                              PorcDescto, PorcDesctoAdicional, PorcDesctoVencido, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdPagoDistrib(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Sucursal As String, ByVal IdUsuario As Integer, _
                                           ByVal SucNot As String, ByVal Nota As String, ByVal Pago As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerIdPagoDistrib = objDALCaja.usp_TraerIdPagoDistrib(Opcion, Distrib, Sucursal, IdUsuario, SucNot, Nota, Pago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaTipoPagos(ByVal Opcion As Integer, ByVal IdPago As Integer, ByVal Sucursal As String, ByVal FormaPago As String, ByVal Status As String, _
                                    ByVal Fecha As DateTime, ByVal Importe As Double, ByVal Dolares As Double, ByVal Cambio As Double, ByVal Emisor As String, ByVal NoTarjeta As String, _
                                    ByVal Autorizacion As String, ByVal RutaBancaria As String, ByVal NoCuenta As String, ByVal Nocheque As String, ByVal IdActivos As Integer, ByVal IdUsuario As Integer, ByVal TCambio As Double) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaTipoPagos(Opcion, IdPago, Sucursal, FormaPago, Status, _
                                              Fecha, Importe, Dolares, Cambio, Emisor, NoTarjeta, Autorizacion, _
                                              RutaBancaria, NoCuenta, Nocheque, IdActivos, IdUsuario, TCambio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GenerarCorte(ByVal Distrib As String) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_GenerarCorte(Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPagosDetDesglose(ByVal IdPago As Integer, ByVal Sucursal As String, ByVal Nota As String, ByVal Pago As Integer, ByVal Importe As Double) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaPagosDetDesglose(IdPago, Sucursal, Nota, Pago, Importe)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPlanPagos(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Sucursal As String, ByVal Nota As String, _
                                            ByVal Pago As Integer, ByVal Abono As Double, ByVal FechaPago As DateTime, _
                                            ByVal IdPago As Integer, ByVal idUsuario As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_ActualizarPlanPagos(Opcion, Distrib, Sucursal, Nota, Pago, Abono, FechaPago, IdPago, idUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerImporteEntregaCaja(ByVal IdUsuario As Integer, ByVal Fecha As Date) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerImporteEntregaCaja = objDALCaja.usp_TraerImporteEntregaCaja(IdUsuario, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoPagoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Nota As String, ByVal Pago As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerInfoPagoDet = objDALCaja.usp_TraerInfoPagoDet(Opcion, Sucursal, Nota, Pago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPermisosCaja(ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal Tipo As String, ByVal Subtipo As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerPermisosCaja = objDALCaja.usp_TraerPermisosCaja(IdDepto, IdPuesto, Tipo, Subtipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovimientos(ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerMovimientos = objDALCaja.usp_TraerMovimientos(Opcion, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivos(ByVal Tipo As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerMotivos = objDALCaja.usp_TraerMotivos(Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCargos(ByVal Opcion As Integer, ByVal Sucursal As Integer, ByVal Nota As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerCargos = objDALCaja.usp_TraerCargos(Opcion, Sucursal, Nota)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMovimiento(ByVal Folio As String, ByVal Distrib As String, ByVal Tipo As String, ByVal IdPago As Integer, ByVal IdAnticipo As Integer, ByVal IdConvenio As Integer, _
                                          ByVal SucNot As String, ByVal Nota As String, ByVal FechaAplicar As Date, ByVal Plazo As Integer, _
                                          ByVal Motivo As Integer, ByVal Fecha As Date, ByVal Importe As Double, ByVal Interes As Double, _
                                          ByVal IdUsuario As Integer, ByVal Fum As Date, ByVal IdUsuarioCancela As Integer, ByVal FumCancela As Date) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaMovimiento(Folio, Distrib, Tipo, IdPago, IdAnticipo, IdConvenio, SucNot, Nota, FechaAplicar, Plazo, Motivo, _
                                                    Fecha, Importe, Interes, IdUsuario, Fum, IdUsuarioCancela, FumCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribuidorCredito(ByVal Opcion As Integer, ByVal IdDistrib As String, ByVal Nombre As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerDistribuidorCredito = objDALCaja.usp_TraerDistribuidorCredito(Opcion, IdDistrib, Nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioPago(ByVal Sucursal As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerFolioPago = objDALCaja.usp_TraerFolioPago(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPago(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal IdUsuario As Integer, ByVal Fecha As Date) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerPago = objDALCaja.usp_TraerPago(Opcion, Sucursal, Folio, IdUsuario, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPago(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal IdUsuario As Integer, ByVal Fecha As Date, ByVal CancelaPago As Boolean) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_TraerPago(Opcion, Sucursal, Folio, IdUsuario, Fecha, CancelaPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAnticipo(ByVal Opcion As Integer, ByVal IdAnticipo As Integer, ByVal Sucursal As String, _
                                        ByVal Distrib As String, ByVal Status As String, ByVal Importe As Double, _
                                        ByVal Aplicado As Integer, ByVal IdUsuario As Integer, ByVal Fum As Date, ByVal IdPagoAplica As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaAnticipo(Opcion, IdAnticipo, Sucursal, Distrib, Status, Importe, Aplicado, IdUsuario, Fum, IdPagoAplica)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaStatusInfoPagos(ByVal Estatus As String, ByVal IdPago As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_ActualizaStatusInfoPagos(Estatus, IdPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAnticipo(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Sucursal As String, ByVal IdUsuario As Integer, ByVal Fecha As Date) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerAnticipo = objDALCaja.usp_TraerAnticipo(Opcion, Distrib, Sucursal, IdUsuario, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaActivos(ByVal Opcion As Integer, ByVal Status As Integer, ByVal Articulo As String, ByVal Tipo As String, _
                                       ByVal Marca As String, ByVal NumSerie As String, ByVal Nuevo As Integer, ByVal ImpComercial As Double, ByVal Comercio As String, _
                                       ByVal ImpAdquirido As Double, ByVal ImpVenta As Double, ByVal IdUsuario As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaActivos(Opcion, Status, Articulo, Tipo, Marca, NumSerie, Nuevo, ImpComercial, Comercio, ImpAdquirido, ImpVenta, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerActivos(ByVal Opcion As Integer, ByVal Articulo As String, ByVal Tipo As String, ByVal Marca As String, ByVal NumSerie As String, ByVal IdUsuario As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerActivos = objDALCaja.usp_TraerActivos(Opcion, Articulo, Tipo, Marca, NumSerie, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEntrega(ByVal Opcion As Integer, ByVal IdEmpleado As Integer, ByVal Fecha As Date, _
                                       ByVal IdEntrega As Integer, ByVal forma As String, ByVal Cantidad As Integer, _
                                       ByVal Articulo As String, ByVal Importe As Double, ByVal Dolares As Double) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaEntrega(Opcion, IdEmpleado, Fecha, IdEntrega, forma, Cantidad, Articulo, Importe, Dolares)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEntrega(ByVal Opcion As Integer, ByVal IdEmpleado As Integer, ByVal Fecha As Date) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerEntrega = objDALCaja.usp_TraerEntrega(Opcion, IdEmpleado, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescuentoCaja(ByVal Importe As Double) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerDescuentoCaja = objDALCaja.usp_TraerDescuentoCaja(Importe)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarSaldoDistrib(ByVal Opcion As Integer, ByVal Distrib As Integer, ByVal Importe As Double) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_ActualizarSaldoDistrib(Opcion, Distrib, Importe)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerParametrosCredito(ByVal Tipo As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerParametrosCredito = objDALCaja.usp_TraerParametrosCredito(Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoCorte(ByVal Opcion As Integer, ByVal Fecha As Date, ByVal IdUsuario As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerInfoCorte = objDALCaja.usp_TraerInfoCorte(Opcion, Fecha, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlanPagos(ByVal Opcion As Integer, ByVal Distrib As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerPlanPagos = objDALCaja.usp_TraerPlanPagos(Opcion, Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNotaPP(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Nota As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerNotaPP = objDALCaja.usp_TraerNotaPP(Opcion, Sucursal, Nota)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaDescuentoAdicional(ByVal Opcion As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date, _
                                                  ByVal DistribIni As String, ByVal DistribFin As String, ByVal Sucursal As String, _
                                                  ByVal Clasificacion As String, ByVal Status As String, ByVal Descuento As Double, _
                                                  ByVal Motivo As String, ByVal IdUsuario As String, ByVal Fum As Date, _
                                                  ByVal IdUsuarioCancela As Integer, ByVal FumCancela As Date) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaDescuentoAdicional(Opcion, FechaIni, FechaFin, DistribIni, DistribFin, Sucursal, _
                                                            Clasificacion, Status, Descuento, Motivo, IdUsuario, _
                                                            Fum, IdUsuarioCancela, FumCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaConvenio(ByVal Opcion As Integer, ByVal IdConvenio As Integer, ByVal Distrib As String, ByVal Tipo As String, ByVal Estatus As Integer, _
                                                  ByVal Fecha As Date, ByVal Importe As Double, ByVal Descuento As Double, _
                                                  ByVal Cobrador As Integer, ByVal Plazo As String, ByVal Motivo As Integer, _
                                                  ByVal Observaciones As String, ByVal IdUsuario As Integer, _
                                                  ByVal IdUsuarioCancela As Integer, ByVal FumCancela As Date) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaConvenio(Opcion, IdConvenio, Distrib, Tipo, Estatus, _
                                                  Fecha, Importe, Descuento, _
                                                  Cobrador, Plazo, Motivo, _
                                                  Observaciones, IdUsuario, IdUsuarioCancela, FumCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaConvenioDet(ByVal Opcion As Integer, ByVal IdConvenio As Integer, ByVal FechaAplicar As Date, ByVal Pago As Integer, _
                                                  ByVal Pagos As Integer, ByVal FechaVencimiento As Date, ByVal Importe As Double, _
                                                  ByVal Abono As Double, ByVal Descuento As Double, ByVal Interes As Double, _
                                                  ByVal GastosCobranza As Double, ByVal Pagado As String, ByVal Fechapago As Date, _
                                                  ByVal TipoPago As String, ByVal Cobrador As Integer, ByVal IdPago As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaConvenioDet(Opcion, IdConvenio, FechaAplicar, Pago, Pagos, FechaVencimiento, _
                                                     Importe, Abono, Descuento, Interes, GastosCobranza, Pagado, _
                                                     Fechapago, TipoPago, Cobrador, IdPago, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerConvenio(ByVal Opcion As Integer, ByVal Fecha As Date, ByVal Distrib As String, ByVal IdUsuario As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerConvenio = objDALCaja.usp_TraerConvenio(Opcion, Fecha, Distrib, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarConvenio(ByVal Opcion As Integer, ByVal IdConvenio As Integer, _
                                            ByVal Pago As Integer, ByVal Abono As Double, ByVal FechaPago As Date, _
                                           ByVal Cobrador As Integer, ByVal IdPago As Integer, ByVal idUsuario As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_ActualizarConvenio(Opcion, IdConvenio, Pago, Abono, FechaPago, Cobrador, IdPago, idUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTipoCambio() As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerTipoCambio = objDALCaja.usp_TraerTipoCambio()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerHistorialPagos(ByVal Distrib As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerHistorialPagos = objDALCaja.usp_TraerHistorialPagos(Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GenerarConvenio(ByVal Opcion As Integer, ByVal IdConvenio As Integer, ByVal Distrib As String, ByVal Tipo As String, ByVal Estatus As Integer, _
                                                  ByVal Fecha As Date, ByVal Importe As Double, ByVal Descuento As Double, _
                                                  ByVal Cobrador As Integer, ByVal Plazo As String, ByVal Motivo As Integer, _
                                                  ByVal Observaciones As String, ByVal IdUsuario As Integer, _
                                                  ByVal IdUsuarioCancela As Integer, ByVal FumCancela As Date) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_GenerarConvenio(Opcion, IdConvenio, Distrib, Tipo, Estatus, _
                                                  Fecha, Importe, Descuento, _
                                                  Cobrador, Plazo, Motivo, _
                                                  Observaciones, IdUsuario, IdUsuarioCancela, FumCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaCargo(ByVal Sucursal As String, ByVal Nota As String, ByVal Estatus As String, ByVal FechaCompra As Date, _
                                     ByVal Distrib As String, ByVal SucCliente As String, ByVal IdCliente As String, ByVal idNegocio As String, _
                                     ByVal dNegocio As String, ByVal Vale As String, ByVal Importe As Double, ByVal Interes As Double, _
                                     ByVal Aplicar As Date, ByVal Plazo As Integer, ByVal NumPlazo As Integer, ByVal IdUsuario As String, ByVal Observaciones As String) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaCargo(Sucursal, Nota, Estatus, FechaCompra, Distrib, _
                                               SucCliente, IdCliente, idNegocio, dNegocio, Vale, _
                                               Importe, Interes, Aplicar, Plazo, NumPlazo, IdUsuario, Observaciones)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioNota(ByVal Sucursal As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerFolioNota = objDALCaja.usp_TraerFolioNota(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPlanPagosConvenio(ByVal Sucursal As String, ByVal Nota As String, ByVal Distrib As String) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaPlanPagosConvenio(Sucursal, Nota, Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPlanPagosDetConvenio(ByVal Sucursal As String, ByVal Nota As String, ByVal FechaAplicar As Date, _
                                                    ByVal Pago As Integer, ByVal Pagos As Integer, ByVal FechaVencimiento As Date, ByVal Importe As Double) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCaja.usp_CapturaPlanPagosDetConvenio(Sucursal, Nota, FechaAplicar, Pago, Pagos, FechaVencimiento, Importe)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlanPagosDetConvenio(ByVal Sucursal As String, ByVal Nota As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerPlanPagosDetConvenio = objDALCaja.usp_TraerPlanPagosDetConvenio(Sucursal, Nota)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
