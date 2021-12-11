Imports System.Data.Odbc
Public Class DALCajaCredito
    Inherits DALOdbc

#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

    Public Function usp_TraerInfoPagos(ByVal IdPagosB) As DataSet
        Try
            usp_TraerInfoPagos = New DataSet
            MyBase.SQL = "CALL usp_TraerInfoPagos(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPagosB", OdbcType.Int, 16, IdPagosB)

            MyBase.FillDataSet(usp_TraerInfoPagos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPagoCredito(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Descuento As Double) As DataSet
        Try
            usp_PpalPagoCredito = New DataSet
            MyBase.SQL = "CALL usp_PpalPagoCredito(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)

            MyBase.FillDataSet(usp_PpalPagoCredito, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPagoCreditoAdelantado(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Descuento As Double) As DataSet
        Try
            usp_PpalPagoCreditoAdelantado = New DataSet
            MyBase.SQL = "CALL usp_PpalPagoCreditoAdelantado(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)

            MyBase.FillDataSet(usp_PpalPagoCreditoAdelantado, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoDistribuidorPorPago(ByVal Distrib As String) As DataSet
        Try
            usp_TraerPagoDistribuidorPorPago = New DataSet
            MyBase.SQL = "CALL usp_TraerPagoDistribuidorPorPago(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)

            MyBase.FillDataSet(usp_TraerPagoDistribuidorPorPago, "credito")
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
            MyBase.SQL = "CALL usp_CapturaPago(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@DescuentoAdicionalB", OdbcType.Double, 9, DescuentoAdicional)
            MyBase.AddParameter("@InteresB", OdbcType.Double, 9, Interes)
            MyBase.AddParameter("@InteresMorB", OdbcType.Double, 9, InteresMor)
            MyBase.AddParameter("@GastosCobranzaB", OdbcType.Double, 9, GastosCobranza)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@VencidoB", OdbcType.Double, 9, Vencido)
            MyBase.AddParameter("@DescuentoVencidoB", OdbcType.Double, 9, DescuentoVencido)
            MyBase.AddParameter("@CobradorB", OdbcType.Int, 8, Cobrador)
            MyBase.AddParameter("@IdConvenioB", OdbcType.Int, 8, IdConvenio)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FumB", OdbcType.DateTime, 10, Fum)
            MyBase.AddParameter("@IdUsuarioCancelaB", OdbcType.Int, 8, IdUsuarioCancela)
            MyBase.AddParameter("@FumCancelaB", OdbcType.DateTime, 10, FumCancela)

            usp_CapturaPago = ExecuteStoredProcedure()

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
            MyBase.SQL = "CALL usp_CapturaPagoDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@SucNotB", OdbcType.Char, 2, SucNot)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@DescuentoAdicionalB", OdbcType.Double, 9, DescuentoAdicional)
            MyBase.AddParameter("@InteresB", OdbcType.Double, 9, Interes)
            MyBase.AddParameter("@InteresMorB", OdbcType.Double, 9, InteresMor)
            MyBase.AddParameter("@GastosCobranzaB", OdbcType.Double, 9, GastosCobranza)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@VencidoB", OdbcType.Double, 9, Vencido)
            MyBase.AddParameter("@DesctoVencidoB", OdbcType.Double, 9, DescuentoVencido)
            MyBase.AddParameter("@NumPagoB", OdbcType.Int, 8, NumPago)
            MyBase.AddParameter("@PagadoB", OdbcType.Int, 8, Pagado)
            MyBase.AddParameter("@PorcDesctoB", OdbcType.Double, 9, PorcDescto)
            MyBase.AddParameter("@PorcDesctoAdicionalB", OdbcType.Double, 9, PorcDesctoAdicional)
            MyBase.AddParameter("@PorcDesctoVencido", OdbcType.Double, 9, PorcDesctoVencido)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            usp_CapturaPagoDet = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdPagoDistrib(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Sucursal As String, ByVal IdUsuario As Integer, _
                                           ByVal SucNot As String, ByVal Nota As String, ByVal Pago As Integer) As DataSet
        Try
            usp_TraerIdPagoDistrib = New DataSet
            MyBase.SQL = "CALL usp_TraerIdPagoDistrib(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@SucNotB", OdbcType.Char, 2, SucNot)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 6, Pago)

            MyBase.FillDataSet(usp_TraerIdPagoDistrib, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaTipoPagos(ByVal Opcion As Integer, ByVal IdPago As Integer, ByVal Sucursal As String, ByVal FormaPago As String, ByVal Status As String, _
                                    ByVal Fecha As DateTime, ByVal Importe As Double, ByVal Dolares As Double, ByVal Cambio As Double, ByVal Emisor As String, ByVal NoTarjeta As String, _
                                    ByVal Autorizacion As String, ByVal RutaBancaria As String, ByVal NoCuenta As String, ByVal Nocheque As String, ByVal IdActivos As Integer, ByVal IdUsuario As Integer, ByVal TCambio As Double) As Boolean
        Try
            MyBase.SQL = "CALL usp_CapturaTipoPagos(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FormaPagoB", OdbcType.Char, 3, FormaPago)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@DolaresB", OdbcType.Double, 9, Dolares)
            MyBase.AddParameter("@CambioB", OdbcType.Double, 9, Cambio)
            MyBase.AddParameter("@EmisorB", OdbcType.Char, 25, Emisor)
            MyBase.AddParameter("@NoTarjetaB", OdbcType.Char, 16, NoTarjeta)
            MyBase.AddParameter("@AutorizacionB", OdbcType.Char, 5, Autorizacion)
            MyBase.AddParameter("@RutaBancariaB", OdbcType.Char, 50, RutaBancaria)
            MyBase.AddParameter("@NoCuentaB", OdbcType.Char, 20, NoCuenta)
            MyBase.AddParameter("@NoChequeB", OdbcType.Char, 20, Nocheque)
            MyBase.AddParameter("@IdActivosB", OdbcType.Int, 8, IdActivos)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@TCambioB", OdbcType.Double, 9, TCambio)
            usp_CapturaTipoPagos = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GenerarCorte(ByVal Distrib As String) As Boolean
        Try
            MyBase.SQL = "CALL usp_GenerarCorte(?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)

            usp_GenerarCorte = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPagosDetDesglose(ByVal IdPago As Integer, ByVal Sucursal As String, ByVal Nota As String, ByVal Pago As Integer, ByVal Importe As Double) As Boolean
        Try
            MyBase.SQL = "CALL usp_CapturaPagosDetDesglose(?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdPagosB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)

            usp_CapturaPagosDetDesglose = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPlanPagos(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Sucursal As String, ByVal Nota As String, _
                                            ByVal Pago As Integer, ByVal Abono As Double, ByVal FechaPago As DateTime, _
                                            ByVal IdPago As Integer, ByVal idUsuario As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizarPlanPagos(?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)
            MyBase.AddParameter("@AbonoB", OdbcType.Double, 9, Abono)
            MyBase.AddParameter("@FechaPagoB", OdbcType.Date, 10, FechaPago)
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, idUsuario)

            usp_ActualizarPlanPagos = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerImporteEntregaCaja(ByVal IdUsuario As Integer, ByVal Fecha As Date) As DataSet
        Try
            usp_TraerImporteEntregaCaja = New DataSet
            MyBase.SQL = "CALL usp_TraerImporteEntregaCaja(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)

            MyBase.FillDataSet(usp_TraerImporteEntregaCaja, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoPagoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Nota As String, ByVal Pago As Integer) As DataSet
        Try
            usp_TraerInfoPagoDet = New DataSet
            MyBase.SQL = "CALL usp_TraerInfoPagoDet(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)

            MyBase.FillDataSet(usp_TraerInfoPagoDet, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPermisosCaja(ByVal idDepto As Integer, ByVal IdPuesto As Integer, ByVal Tipo As String, ByVal Subtipo As String) As DataSet
        Try
            usp_TraerPermisosCaja = New DataSet
            MyBase.SQL = "CALL usp_TraerPermisosCaja(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 8, idDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 8, IdPuesto)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 3, Tipo)
            MyBase.AddParameter("@SubtipoB", OdbcType.Char, 15, Subtipo)

            MyBase.FillDataSet(usp_TraerPermisosCaja, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovimientos(ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        Try
            usp_TraerMovimientos = New DataSet
            MyBase.SQL = "CALL usp_TraerMovimientos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerMovimientos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivos(ByVal Tipo As String) As DataSet
        Try
            usp_TraerMotivos = New DataSet
            MyBase.SQL = "CALL usp_TraerMotivos(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", OdbcType.Char, 3, Tipo)

            MyBase.FillDataSet(usp_TraerMotivos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCargos(ByVal Opcion As Integer, ByVal Sucursal As Integer, ByVal Nota As Integer) As DataSet
        Try
            usp_TraerCargos = New DataSet
            MyBase.SQL = "CALL usp_TraerCargos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@TipoB", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@TipoB", OdbcType.Int, 8, Sucursal)
            MyBase.AddParameter("@TipoB", OdbcType.Int, 8, Nota)

            MyBase.FillDataSet(usp_TraerCargos, "credito")
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
            MyBase.SQL = "CALL usp_CapturaMovimiento(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@FolioB", OdbcType.Char, 8, Folio)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 3, Tipo)
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@IdAnticipoB", OdbcType.Int, 8, IdAnticipo)
            MyBase.AddParameter("@IdConvenioB", OdbcType.Int, 8, IdConvenio)
            MyBase.AddParameter("@SucNotB", OdbcType.Char, 2, SucNot)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@FechaAplicarB", OdbcType.Date, 10, FechaAplicar)
            MyBase.AddParameter("@PlazoB", OdbcType.Int, 8, Plazo)
            MyBase.AddParameter("@MotivoB", OdbcType.Int, 8, Motivo)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@InteresB", OdbcType.Double, 9, Interes)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FumB", OdbcType.Date, 10, Fum)
            MyBase.AddParameter("@IdUsuarioCancelaB", OdbcType.Int, 8, IdUsuarioCancela)
            MyBase.AddParameter("@FumCancelaB", OdbcType.Date, 10, FumCancela)

            usp_CapturaMovimiento = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribuidorCredito(ByVal Opcion As Integer, ByVal IdDistrib As String, ByVal Nombre As String) As DataSet
        Try
            usp_TraerDistribuidorCredito = New DataSet
            MyBase.SQL = "CALL usp_TraerDistribuidorCredito(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdDistribB", OdbcType.Char, 6, IdDistrib)
            MyBase.AddParameter("@NombreB", OdbcType.Char, 80, Nombre)

            MyBase.FillDataSet(usp_TraerDistribuidorCredito, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioPago(ByVal Sucursal As String) As DataSet
        Try
            usp_TraerFolioPago = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioPago(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerFolioPago, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPago(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal IdUsuario As Integer, ByVal Fecha As Date) As DataSet
        Try
            usp_TraerPago = New DataSet
            MyBase.SQL = "CALL usp_TraerPago(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)

            MyBase.FillDataSet(usp_TraerPago, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPago(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal IdUsuario As Integer, ByVal Fecha As Date, ByVal CancelaPago As Boolean) As Boolean
        Try

            MyBase.SQL = "CALL usp_TraerPago(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)

            usp_TraerPago = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaAnticipo(ByVal Opcion As Integer, ByVal IdAnticipo As String, ByVal Sucursal As String, _
                                        ByVal Distrib As String, ByVal Status As String, ByVal Importe As Double, _
                                        ByVal Aplicado As Integer, ByVal IdUsuario As Integer, ByVal Fum As Date, ByVal IdPagoAplica As Integer) As Boolean
        Try

            MyBase.SQL = "CALL usp_CapturaAnticipo(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdAnticipoB", OdbcType.Int, 8, IdAnticipo)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@AplicadoB", OdbcType.Int, 8, Aplicado)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FumB", OdbcType.Date, 10, Fum)
            MyBase.AddParameter("@IdPagoAplicaB", OdbcType.Int, 8, IdPagoAplica)

            usp_CapturaAnticipo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaStatusInfoPagos(ByVal Estatus As String, ByVal IdPago As Integer) As Boolean
        Try

            MyBase.SQL = "CALL usp_ActualizaStatusInfoPagos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)

            usp_ActualizaStatusInfoPagos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAnticipo(ByVal Opcion As Integer, ByVal Distrib As String, ByVal Sucursal As String, ByVal IdUsuario As Integer, ByVal Fecha As Date) As DataSet
        Try
            usp_TraerAnticipo = New DataSet
            MyBase.SQL = "CALL usp_TraerAnticipo(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)

            MyBase.FillDataSet(usp_TraerAnticipo, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaActivos(ByVal Opcion As Integer, ByVal Status As Integer, ByVal Articulo As String, ByVal Tipo As String, _
                                       ByVal Marca As String, ByVal NumSerie As String, ByVal Nuevo As Integer, ByVal ImpComercial As Double, ByVal Comercio As String, _
                                       ByVal ImpAdquirido As Double, ByVal ImpVenta As Double, ByVal IdUsuario As Integer) As Boolean
        Try

            MyBase.SQL = "CALL usp_CapturaActivos(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@StatusB", OdbcType.Int, 8, Status)
            MyBase.AddParameter("@ArticuloB", OdbcType.Char, 50, Articulo)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 30, Tipo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 20, Marca)
            MyBase.AddParameter("@NumSerieB", OdbcType.Char, 30, NumSerie)
            MyBase.AddParameter("@NuevoB", OdbcType.Int, 8, Nuevo)
            MyBase.AddParameter("@ImpComercialB", OdbcType.Double, 9, ImpComercial)
            MyBase.AddParameter("@ComercioB", OdbcType.Char, 30, Comercio)
            MyBase.AddParameter("@ImpAdquiridoB", OdbcType.Double, 9, ImpAdquirido)
            MyBase.AddParameter("@ImpVentaB", OdbcType.Double, 9, ImpVenta)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            usp_CapturaActivos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerActivos(ByVal Opcion As Integer, ByVal Articulo As String, ByVal Tipo As String, ByVal Marca As String, ByVal NumSerie As String, ByVal IdUsuario As Integer) As DataSet
        Try
            usp_TraerActivos = New DataSet
            MyBase.SQL = "CALL usp_TraerActivos(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@ArticuloB", OdbcType.Char, 50, Articulo)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 30, Tipo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 20, Marca)
            MyBase.AddParameter("@NumSerieB", OdbcType.Char, 30, NumSerie)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            MyBase.FillDataSet(usp_TraerActivos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEntrega(ByVal Opcion As Integer, ByVal IdEmpleado As Integer, ByVal Fecha As Date, _
                                       ByVal IdEntrega As Integer, ByVal forma As String, ByVal Cantidad As Integer, _
                                       ByVal Articulo As String, ByVal Importe As Double, ByVal Dolares As Double) As Boolean
        Try

            MyBase.SQL = "CALL usp_CapturaEntrega(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdEmpleadoB", OdbcType.Int, 8, IdEmpleado)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@idEntregaB", OdbcType.Int, 8, IdEntrega)
            MyBase.AddParameter("@FormaB", OdbcType.Char, 3, forma)
            MyBase.AddParameter("@CantidadB", OdbcType.Int, 8, Cantidad)
            MyBase.AddParameter("@ArticuloB", OdbcType.Char, 50, Articulo)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@DolaresB", OdbcType.Double, 9, Dolares)

            usp_CapturaEntrega = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEntrega(ByVal Opcion As Integer, ByVal IdEmpleado As Integer, ByVal Fecha As Date) As DataSet
        Try
            usp_TraerEntrega = New DataSet
            MyBase.SQL = "CALL usp_TraerEntrega(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdEmpleadoB", OdbcType.Int, 8, IdEmpleado)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)

            MyBase.FillDataSet(usp_TraerEntrega, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescuentoCaja(ByVal Importe As Double) As DataSet
        Try
            usp_TraerDescuentoCaja = New DataSet
            MyBase.SQL = "CALL usp_TraerDescuentoCaja(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)

            MyBase.FillDataSet(usp_TraerDescuentoCaja, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarSaldoDistrib(ByVal Opcion As Integer, ByVal Distrib As Integer, ByVal Importe As Double) As Boolean
        Try

            MyBase.SQL = "CALL usp_ActualizarSaldoDistrib(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)

            usp_ActualizarSaldoDistrib = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerParametrosCredito(ByVal Tipo As String) As DataSet
        Try
            usp_TraerParametrosCredito = New DataSet
            MyBase.SQL = "CALL usp_TraerParametrosCredito(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ImporteB", OdbcType.Char, 25, Tipo)

            MyBase.FillDataSet(usp_TraerParametrosCredito, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoCorte(ByVal Opcion As Integer, ByVal Fecha As Date, ByVal IdUsuario As Integer) As DataSet
        Try
            usp_TraerInfoCorte = New DataSet
            MyBase.SQL = "CALL usp_TraerInfoCorte(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            MyBase.FillDataSet(usp_TraerInfoCorte, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlanPagos(ByVal Opcion As Integer, ByVal Distrib As String) As DataSet
        Try
            usp_TraerPlanPagos = New DataSet
            MyBase.SQL = "CALL usp_TraerPlanPagos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)

            MyBase.FillDataSet(usp_TraerPlanPagos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNotaPP(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Nota As String) As DataSet
        Try
            usp_TraerNotaPP = New DataSet
            MyBase.SQL = "CALL usp_TraerNotaPP(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)

            MyBase.FillDataSet(usp_TraerNotaPP, "credito")
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
            MyBase.SQL = "CALL usp_CapturaDescuentoAdicional(?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 10, FechaFin)
            MyBase.AddParameter("@DistribIniB", OdbcType.Char, 6, DistribIni)
            MyBase.AddParameter("@DistribFinB", OdbcType.Char, 6, DistribFin)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ClasificacionB", OdbcType.Char, 2, Clasificacion)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@DesctoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@MotivoB", OdbcType.Char, 50, Motivo)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@FumB", OdbcType.Date, 10, Fum)
            MyBase.AddParameter("@IdUsuarioCancelaB", OdbcType.Int, 8, IdUsuarioCancela)
            MyBase.AddParameter("@FumCancelaB", OdbcType.Date, 10, FumCancela)

            usp_CapturaDescuentoAdicional = ExecuteStoredProcedure()
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
            MyBase.SQL = "CALL usp_CapturaConvenio(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdConvenioB", OdbcType.Int, 8, IdConvenio)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@StatusB", OdbcType.Int, 8, Estatus)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@CobradorB", OdbcType.Int, 8, Cobrador)
            MyBase.AddParameter("@PlazoB", OdbcType.Char, 25, Plazo)
            MyBase.AddParameter("@MotivoB", OdbcType.Int, 8, Motivo)
            MyBase.AddParameter("@ObservacionesB", OdbcType.Char, 100, Observaciones)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@IdUsuarioCancelaB", OdbcType.Int, 8, IdUsuarioCancela)
            MyBase.AddParameter("@FumCancelaB", OdbcType.Date, 10, FumCancela)

            usp_CapturaConvenio = ExecuteStoredProcedure()
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
            MyBase.SQL = "CALL usp_CapturaConvenioDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdConvenioB", OdbcType.Int, 8, IdConvenio)
            MyBase.AddParameter("@FechaAplicarB", OdbcType.Date, 10, FechaAplicar)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)
            MyBase.AddParameter("@PagosB", OdbcType.Int, 8, Pagos)
            MyBase.AddParameter("@FechaVencimientoB", OdbcType.Date, 10, FechaVencimiento)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@AbonoB", OdbcType.Double, 9, Abono)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@InteresB", OdbcType.Double, 9, Interes)
            MyBase.AddParameter("@GastosCobranzaB", OdbcType.Double, 9, GastosCobranza)
            MyBase.AddParameter("@PagadoB", OdbcType.Char, 1, Pagado)
            MyBase.AddParameter("@FechaPagoB", OdbcType.Date, 10, Fechapago)
            MyBase.AddParameter("@TipoPagoB", OdbcType.Char, 1, TipoPago)
            MyBase.AddParameter("@CobradorB", OdbcType.Int, 8, Cobrador)
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            usp_CapturaConvenioDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerConvenio(ByVal Opcion As Integer, ByVal Fecha As Date, ByVal Distrib As String, ByVal IdUsuario As Integer) As DataSet
        Try
            usp_TraerConvenio = New DataSet
            MyBase.SQL = "CALL usp_TraerConvenio(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            MyBase.FillDataSet(usp_TraerConvenio, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarConvenio(ByVal Opcion As Integer, ByVal IdConvenio As Integer, _
                                            ByVal Pago As Integer, ByVal Abono As Double, ByVal FechaPago As Date, _
                                           ByVal Cobrador As Integer, ByVal IdPago As Integer, ByVal idUsuario As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizarConvenio(?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, IdConvenio)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)
            MyBase.AddParameter("@AbonoB", OdbcType.Double, 9, Abono)
            MyBase.AddParameter("@FechaPagoB", OdbcType.Date, 10, FechaPago)
            MyBase.AddParameter("@CobradorB", OdbcType.Int, 8, Cobrador)
            MyBase.AddParameter("@IdPagoB", OdbcType.Int, 8, IdPago)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, idUsuario)

            usp_ActualizarConvenio = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTipoCambio() As DataSet
        Try
            usp_TraerTipoCambio = New DataSet
            MyBase.SQL = "CALL usp_TraerTipoCambio()"

            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_TraerTipoCambio, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerHistorialPagos(ByVal Distrib As String) As DataSet
        Try
            usp_TraerHistorialPagos = New DataSet
            MyBase.SQL = "CALL usp_TraerHistorialPagos(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.FillDataSet(usp_TraerHistorialPagos, "credito")
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
            MyBase.SQL = "CALL usp_GenerarConvenio(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@IdConvenioB", OdbcType.Int, 8, IdConvenio)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@StatusB", OdbcType.Int, 8, Estatus)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@CobradorB", OdbcType.Int, 8, Cobrador)
            MyBase.AddParameter("@PlazoB", OdbcType.Char, 25, Plazo)
            MyBase.AddParameter("@MotivoB", OdbcType.Int, 8, Motivo)
            MyBase.AddParameter("@ObservacionesB", OdbcType.Char, 100, Observaciones)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)
            MyBase.AddParameter("@IdUsuarioCancelaB", OdbcType.Int, 8, IdUsuarioCancela)
            MyBase.AddParameter("@FumCancelaB", OdbcType.Date, 10, FumCancela)

            usp_GenerarConvenio = ExecuteStoredProcedure()
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
            MyBase.SQL = "CALL usp_CapturaCargo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@FechaCompraB", OdbcType.Date, 10, FechaCompra)
            MyBase.AddParameter("@IdDistrib", OdbcType.Char, 6, Distrib)
            MyBase.AddParameter("@SucClienteB", OdbcType.Char, 2, SucCliente)
            MyBase.AddParameter("@IdClienteB", OdbcType.Char, 8, IdCliente)
            MyBase.AddParameter("@idNegocio", OdbcType.Char, 3, idNegocio)
            MyBase.AddParameter("@dNegocioB", OdbcType.Char, 3, dNegocio)
            MyBase.AddParameter("@IdValeB", OdbcType.Char, 10, Vale)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@InteresB", OdbcType.Double, 9, Interes)
            MyBase.AddParameter("@AplicarB", OdbcType.Date, 10, Aplicar)
            MyBase.AddParameter("@IdPlazoB", OdbcType.Int, 8, Plazo)
            MyBase.AddParameter("@NPlazosB", OdbcType.Int, 8, NumPlazo)
            MyBase.AddParameter("@UsuarioB", OdbcType.Char, 8, IdUsuario)
            MyBase.AddParameter("@ObservacionesB", OdbcType.Text, 100, Observaciones)

            usp_CapturaCargo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioNota(ByVal Sucursal As String) As DataSet
        Try
            usp_TraerFolioNota = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioNota(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerFolioNota, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPlanPagosConvenio(ByVal Sucursal As String, ByVal Nota As String, ByVal Distrib As String) As Boolean
        Try
            MyBase.SQL = "CALL usp_CapturaPlanPagosConvenio(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@DistribB", OdbcType.Char, 6, Distrib)

            usp_CapturaPlanPagosConvenio = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaPlanPagosDetConvenio(ByVal Sucursal As String, ByVal Nota As String, ByVal FechaAplicar As Date, _
                                                    ByVal Pago As Integer, ByVal Pagos As Integer, ByVal FechaVencimiento As Date, ByVal Importe As Double) As Boolean
        Try
            MyBase.SQL = "CALL usp_CapturaPlanPagosDetConvenio(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)
            MyBase.AddParameter("@FechaAplicarB", OdbcType.Date, 10, FechaAplicar)
            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, Pago)
            MyBase.AddParameter("@PagosB", OdbcType.Int, 8, Pagos)
            MyBase.AddParameter("@FechaVencimientoB", OdbcType.Date, 10, FechaVencimiento)
            MyBase.AddParameter("@ImporteB", OdbcType.Double, 9, Importe)

            usp_CapturaPlanPagosDetConvenio = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlanPagosDetConvenio(ByVal Sucursal As String, ByVal Nota As String) As DataSet
        Try
            usp_TraerPlanPagosDetConvenio = New DataSet
            MyBase.SQL = "CALL usp_TraerPlanPagosDetConvenio(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NotaB", OdbcType.Char, 6, Nota)

            MyBase.FillDataSet(usp_TraerPlanPagosDetConvenio, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
