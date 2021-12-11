Public Class BCLCreditoNuevo
    'mreyes 06/Junio/2017   12:34 p.m.

    Implements IDisposable
    Private objDALCreditoNuevo As DAL.DALCreditoNuevo
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCreditoNuevo = New DAL.DALCreditoNuevo(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCreditoNuevo.Dispose()
            objDALCreditoNuevo = Nothing
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
    Public Function usp_PpalEstadoCartera(ByVal Opcion As Integer, ByVal IdGestor As String) As DataSet
        'fdoadame 30/Diciembre/2017   09:28 a.m.
        Try
            usp_PpalEstadoCartera = objDALCreditoNuevo.usp_PpalEstadoCartera(Opcion, IdGestor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencido(Fecha As String) As DataSet
        'mreyes 12/Junio/2017   12:09 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalVencido = objDALCreditoNuevo.usp_PpalVencido(Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencidoDias(Fecha As String) As DataSet
        'mreyes 19/Julio/2017  05:11 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalVencidoDias = objDALCreditoNuevo.usp_PpalVencidoDias(Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalVencido() As DataSet
        'mreyes 28/Noviembre/2017   12:12 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalVencido = objDALCreditoNuevo.usp_PpalVencido()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalVencidoGestor(IdGestor As Integer) As DataSet
        'mreyes 29/Noviembre/2017   04:28 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalVencidoGestor = objDALCreditoNuevo.usp_PpalVencidoGestor(IdGestor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalVencidoxAnio() As DataSet
        'mreyes 28/Noviembre/2017   13:28 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalVencidoxAnio = objDALCreditoNuevo.usp_PpalVencidoxAnio()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalGestoria() As DataSet
        'mreyes 26/Octubre/2017     04:56 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalGestoria = objDALCreditoNuevo.usp_PpalGestoria()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerGestoriaxDistrib(Distrib As String) As DataSet
        'mreyes 03/Noviembre/2017   10:16 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerGestoriaxDistrib = objDALCreditoNuevo.usp_TraerGestoriaxDistrib(Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCPEstadoCiudadColonia(Opcion As Integer, CodigoPostal As String, IdEstado As Integer, IdCiudad As Integer, IdColonia As Integer) As DataSet
        'mreyes 09/Febrero/2018 04:55 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerCPEstadoCiudadColonia = objDALCreditoNuevo.usp_TraerCPEstadoCiudadColonia(Opcion, CodigoPostal, IdEstado, IdCiudad, IdColonia)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCallCenter() As DataSet
        'mreyes 29/Octubre/2017 12:42 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalCallCenter = objDALCreditoNuevo.usp_PpalCallCenter()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalBonoSemanal(IdPeriodo As Integer, idsucursal As Integer) As DataSet
        'mreyes 12/Junio/2018   01:15 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalBonoSemanal = objDALCreditoNuevo.usp_PpalBonoSemanal(IdPeriodo, idsucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalRelaciones(Opcion As Integer, Distrib1 As String, Distrib2 As String, TipoDistrib As String, FechaCorte As Date, IdSucursal As Integer) As DataSet
        'mreyes 10/Abril/2018   11:45 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalRelaciones = objDALCreditoNuevo.usp_PpalRelaciones(Opcion, Distrib1, Distrib2, TipoDistrib, FechaCorte, IdSucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalRelacionesBlindaje(Opcion As Integer, Distrib1 As String, Distrib2 As String, TipoDistrib As String, FechaCorte As Date, IdSucursal As Integer) As DataSet
        'mreyes 14/Noviembre/2019   05:58 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalRelacionesBlindaje = objDALCreditoNuevo.usp_PpalRelacionesBlindaje(Opcion, Distrib1, Distrib2, TipoDistrib, FechaCorte, IdSucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalDistrib() As DataSet
        'mreyes 07/Enero/2018

        Try
            'Call the data component to get all groups
            usp_PpalDistrib = objDALCreditoNuevo.usp_PpalDistrib()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalDistribTarjetaHabiente() As DataSet
        'mreyes 19/Septiembre/2018  12:20 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalDistribTarjetaHabiente = objDALCreditoNuevo.usp_PpalDistribTarjetaHabiente()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCallCenterAdmon(FechaIni As Date, FechaFin As Date, FechaPromesadoIni As Date,
                                            FechaPromesadoFin As Date, IdEmpleado As Integer) As DataSet
        'mreyes 03/Noviembre/2017 16:18 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalCallCenterAdmon = objDALCreditoNuevo.usp_PpalCallCenterAdmon(FechaIni, FechaFin, FechaPromesadoIni, FechaPromesadoFin, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDistribLimites() As DataSet
        'mreyes 06/Junio/2017   12:51 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalDistribLimites = objDALCreditoNuevo.usp_PpalDistribLimites()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_GestoriaAsignada(Opcion As Integer, idgestor As Integer, distrib As String, corte1 As Decimal,
                                                 corte2 As Decimal, corte3 As Decimal, corte4 As Decimal,
                                                 corten As Decimal, vencido As Decimal, ultpago As Decimal,
                                                 ultfechapago As Date, idusuario As Integer) As Boolean

        'mreyes 24/Noviembre/2017   12:22 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_GestoriaAsignada(Opcion, idgestor, distrib, corte1, corte2, corte3, corte4, corten, vencido, ultpago, ultfechapago, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_VencidoAsignada(Opcion As Integer, Fecha As Date, Distrib As String, IdGestor As Integer, IdAsigna As Integer) As Boolean

        'mreyes 28/Noviembre/2017   06:06 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_VencidoAsignada(Opcion, Fecha, Distrib, IdGestor, IdAsigna)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_RutaGestor(Opcion As Integer, Fecha As Date, Distrib As String, IdGestor As Integer) As Boolean

        'mreyes 08/Diciembre/2017   12:15 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_RutaGestor(Opcion, Fecha, Distrib, IdGestor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DistribDocumentos(Opcion As Integer, IdDistrib As Integer, Documento As String,
                                              NumImagen As Integer,
                                               Imagen As Byte(), idusuario As Integer, idusuariomodif As Integer) As Boolean

        'mreyes 13/Febrero/2018 04:09 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_DistribDocumentos(Opcion, IdDistrib, Documento, NumImagen, Imagen, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DistribComerciales(Opcion As Integer, IdDistrib As Integer, IdNegExterno As Integer,
                                                   Comercial As String,
                                                   NoCuenta As String,
                                                   limite As Decimal, EdoCuenta As Byte(), EdoCuenta1 As Byte(),
                                                   idusuario As Integer) As Boolean

        'mreyes 15/Agosto/2018  10:08 a.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_DistribComerciales(Opcion, IdDistrib, IdNegExterno, Comercial, NoCuenta, limite, EdoCuenta, EdoCuenta1, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_DistribFirmas(Opcion As Integer, IdDistrib As Integer, Principal As Integer,
                                               Nombre As String, Domicilio As String, NumFirma As Integer,
                                               firma As Byte(), pagare As Byte(), idusuario As Integer, idusuariomodif As Integer) As Boolean

        'mreyes 13/Febrero/2018 04:09 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_DistribFirmas(Opcion, IdDistrib, Principal, Nombre, Domicilio, NumFirma, firma, pagare, idusuario, idusuariomodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CallCenter(Opcion As Integer, IdCallCenter As Integer, Distrib As String, ByVal Fecha As Date, FechaPromesado As Date,
                                           adeudo As Decimal, comentarios As String, llamada As Integer, idusuario As Integer) As Boolean

        'mreyes 03/Noviembre/2017   12:20 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_CallCenter(Opcion, IdCallCenter, Distrib, Fecha, FechaPromesado, adeudo, comentarios, llamada, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_AumentoLimite(Opcion As Integer, Distrib As String, ByVal Fecha As Date, NuevoLimite As Decimal, idusuario As Integer) As Boolean

        'mreyes 06/Junio/2017   04:25 p.m.

        Try
            Return objDALCreditoNuevo.usp_AumentoLimite(Opcion, Distrib, Fecha, NuevoLimite, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalPagosDistribuidor(FechaInicio As String, FechaFin As String, distrib As String) As DataSet

        Try

            usp_PpalPagosDistribuidor = objDALCreditoNuevo.usp_PpalPagosDistribuidor(FechaInicio, FechaFin, distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPagosDistribuidorXCorte(Opcion As Integer, FechaInicio As String, FechaFin As String, distrib As String) As DataSet

        Try

            usp_PpalPagosDistribuidorXCorte = objDALCreditoNuevo.usp_PpalPagosDistribuidorXCorte(Opcion, FechaInicio, FechaFin, distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ValidarDistrib(distrib As String) As DataSet

        Try
            usp_ValidarDistrib = objDALCreditoNuevo.usp_ValidarDistrib(distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    'Public Function usp_AumentoLimite(Opcion As Integer, Distrib As String, ByVal Fecha As Date, NuevoLimite As Decimal, idusuario As Integer) As Boolean

    '    'mreyes 06/Junio/2017   04:25 p.m.

    '    Try
    '        Return objDALCreditoNuevo.usp_AumentoLimite(Opcion, Distrib, Fecha, NuevoLimite, idusuario)
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message,
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_PpalComisionesCarteraVencida(FechaInicio As String, FechaFin As String, Porcentaje As Integer, idgestor As String, opcion As Integer) As DataSet
        'fdoadame 12/Diciembre/2017   10:30 a.m.
        Try

            usp_PpalComisionesCarteraVencida = objDALCreditoNuevo.usp_PpalComisionesCarteraVencida(FechaInicio, FechaFin, Porcentaje, idgestor, opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDistrib(IdDistrib As Integer) As DataSet
        'mreyes 07/Febrero/2018 12:39 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerDistrib = objDALCreditoNuevo.usp_TraerDistrib(IdDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribDocumentos(IdDistrib As Integer) As DataSet
        'mreyes 196/Septiembre/2018 11:57 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerDistribDocumentos = objDALCreditoNuevo.usp_TraerDistribDocumentos(IdDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribComerciales(IdDistrib As Integer) As DataSet
        'mreyes 196/Septiembre/2018 11:57 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerDistribComerciales = objDALCreditoNuevo.usp_TraerDistribComerciales(IdDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdDistrib(Distrib As String) As DataSet
        'mreyes 13/Febrero/2018 04:02 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerIdDistrib = objDALCreditoNuevo.usp_TraerIdDistrib(Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerMenspaga() As DataSet
        'mreyes 12/Abril/2018 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerMenspaga = objDALCreditoNuevo.usp_TraerMenspaga
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

        'mreyes 11/Julio/2018   04:54 p.m.

        Try
            Return objDALCreditoNuevo.usp_Captura_Distrib(Opcion, IdPromotor, IdCoordinador, IdTienda, Distrib, TipoDistrib, IdTipocredito, IdPeriodicidad, IdEstatus, IdAval, NombreCompleto, Nombre, Appaterno, ApMaterno, Sexo, FechaNacim, IdEStadoCivil, Dependientes, IdEstado, IdCiudad, IdColonia, CodigoPostal, Calle, Numero, EntreCalles, IdTipoVivienda, AntiguedadVivienda, ValorCasa, ValorAutos, TelCasa, TelOtro, Celular1, Celular2, Email, Empresa, DireccionEmpresa, Puesto, AntiguedadEmpresa, IngresoMensual,
                                        OtrosIngresos, IngresoTotal, LimiteCredito,
                                        Saldo, Disponible, LimiteVale, Contravale,
                                        NegExt, Promocion, NombreConyuge,
                                        AppaternoConyuge, ApMaternoConyuge, EmpresaConyuge,
                                        PuestoConyuge, AntiguedadConyuge, TelConyuge,
                                        CelConyuge, IngresoConyuge, NombreMadre,
                                        NombrePadre, DireccionPadres, TelPadres,
                                        CelPadres, TelPadres1, TelPadres2,
                                        NombreAmigo, DireccionAmigo, TelAmigo, CelAmigo,
                                        IdUsuario, IdUsuarioModif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraEstructuraComision(IdPeriodo As Integer) As Boolean

        'mreyes 02/Octubre/2018 09:30 a.m.

        Try
            Return objDALCreditoNuevo.usp_GeneraEstructuraComision(IdPeriodo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFumComisionEmp() As DataSet
        'mreyes 02/Octubre/2018 11:11 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerFumComisionEmp = objDALCreditoNuevo.usp_TraerFumComisionEmp()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCargo(Sucursal As String, Nota As String) As DataSet
        'mreyes 22/Noviembre/2018   10:45 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerCargo = objDALCreditoNuevo.usp_TraerCargo(Sucursal, Nota)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ModificarCargo(Sucursal As String, Notas As String, Vale As String,
                                       Distrib As String, NombreCliente As String, Apellp As String,
                                       Apellm As String, FechaAplicar As Date, SucCte As String,
                                       Cliente As String, IdUsuario As Integer) As Boolean

        'mreyes 22/Noviembre/2018   12:53 p.m.


        '
        '

        Try
            Return objDALCreditoNuevo.usp_ModificarCargo(Sucursal, Notas, Vale, Distrib, NombreCliente, Apellp, Apellm, FechaAplicar, SucCte, Cliente, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ModificarSoloCalzado(Distrib As String, SoloCalzado As Integer) As Boolean

        'mreyes 26/Noviembre/2018   04:00 p.m.


        '
        '

        Try
            Return objDALCreditoNuevo.usp_ModificarSoloCalzado(Distrib, SoloCalzado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_MovimientosDistrib(Opcion As Integer, Distrib As String, SoloCalzado As Integer, Promocion As Integer,
                                           LimiteVale As Decimal, LimiteCredito As Decimal, Estatus As String) As Boolean

        'mreyes 27/Diciembre/2018   12:28 p.m.

        Try
            Return objDALCreditoNuevo.usp_MovimientosDistrib(Opcion, Distrib, SoloCalzado, Promocion, LimiteVale, LimiteCredito, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)

        End Try
    End Function

    Public Function usp_TraerCortesCaja(Opcion As Integer, Distrib As String) As DataSet
        'mreyes 27/Noviembre/2018   05:25 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerCortesCaja = objDALCreditoNuevo.usp_TraerCortesCaja(Opcion, Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFolioPago(Sucursal As String) As DataSet
        'mreyes 28/Noviembre/2018   10:39 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerFolioPago = objDALCreditoNuevo.usp_TraerFolioPago(Sucursal)
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

        'mreyes 28/Noviembre/2017   12:23 p.m.


        Try
            Return objDALCreditoNuevo.usp_CapturaPago(Opcion, sucursalb, Foliob, DistribB, statusb, FechaB, subtotalb, descuentob, descuentoadicionalb, interesb, interesmorb, gastoscobranzab, importeb, vencidob, descuentovencidob, cobradorb, idconveniob, idusuariob, idusuariocancelab)
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

        'mreyes 07/Diciembre/2018   12:04 p.m .


        Try
            Return objDALCreditoNuevo.usp_CapturaPagoDet(Opcion, idpagos, sucursal, sucnot, nota, pago, subtotal,
                                                         descuento, descuentoadicional, interes, interesmoratorio, gastoscobranza,
                                                         importe, vencido, descuentovencido, numpago, pagado, porcdescto, porcdesctoadicional,
                                                         porcdesctovencido, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerIdPagoDistrib(Opcion As Integer, DistribB As String, SucursalB As String, IdUsuarioB As Integer, SucNotB As String, NotaB As String, PagoB As Integer) As DataSet
        'mreyes 28/Noviembre/2018   04:51 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerIdPagoDistrib = objDALCreditoNuevo.usp_TraerIdPagoDistrib(Opcion, DistribB, SucursalB, IdUsuarioB, SucNotB, NotaB, PagoB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_GeneraDetallePago(Opcion As Integer, Sucursal As String, Distrib As String, Apagar As Decimal, Descuento As Decimal, IdPago As Integer, IdUsuario As Integer) As Boolean

        'mreyes 30/Noviembre/2018   01:04 p.m.


        Try
            Return objDALCreditoNuevo.usp_GeneraDetallePago(Opcion, Sucursal, Distrib, Apagar, Descuento, IdPago, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovimientos(Opcion As Integer, Sucursal As String) As DataSet
        'mreyes 05/Diciembre/2018   09:44 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerMovimientos = objDALCreditoNuevo.usp_TraerMovimientos(Opcion, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPago(Opcion As Integer, Sucursal As String, Folio As String, IdUsuario As Integer, Fecha As Date) As DataSet
        'mreyes 05/Diciembre/2018   09:59 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPago = objDALCreditoNuevo.usp_TraerPago(Opcion, Sucursal, Folio, IdUsuario, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoUPDATE(Opcion As Integer, Sucursal As String, Folio As String, IdUsuario As Integer, Fecha As Date) As Boolean
        'mreyes 05/Diciembre/2018   09:59 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPagoUPDATE = objDALCreditoNuevo.usp_TraerPagoUPDATE(Opcion, Sucursal, Folio, IdUsuario, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_ActualizarPlanPagos(Opcion As Integer, Distrib As String, Sucursal As String, Nota As String, Pago As Integer, Abono As Decimal, FechaPago As Date, IdPago As Integer, IdUsuario As Integer) As Boolean

        'mreyes 05/Diciembre/2018   10:09 a.m.


        Try
            Return objDALCreditoNuevo.usp_ActualizarPlanPagos(Opcion, Distrib, Sucursal, Nota, Pago, Abono, FechaPago, IdPago, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizaStatusInfoPagos(Status As String, IdPagos As Integer, IdUsuarioCancela As Integer) As Boolean

        'mreyes 05/Diciembre/2018   10:43 a.m.


        Try
            Return objDALCreditoNuevo.usp_ActualizaStatusInfoPagos(Status, IdPagos, IdUsuarioCancela)
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

        'mreyes 05/Diciembre/2018   11:37 a.m.


        Try
            Return objDALCreditoNuevo.usp_CapturaMovimiento(Folio, Distrib, Tipo, IdPago, IdAnticipo,
                                                            IdConvenio, SucNot, Nota, FechaAplicar, Plazo,
                                                            Motivo, Fecha, Importe, Interes, IdUsuario,
                                                            IdUsuarioCancela)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarSaldoDistrib(Opcion As Integer, Distrib As String, Importe As Decimal) As Boolean

        'mreyes 05/Diciembre/2018   12:14 p.m.


        Try
            Return objDALCreditoNuevo.usp_ActualizarSaldoDistrib(Opcion, Distrib, Importe)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try


    End Function


    Public Function usp_TraerHistorialPagos(Distrib As String) As DataSet
        'mreyes 05/Diciembre/2018   12:27 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerHistorialPagos = objDALCreditoNuevo.usp_TraerHistorialPagos(Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaDescuentoAdicional(Opcion As Integer, FechaIni As Date, Fechafin As Date,
                                                  DistribIni As String, DistribFin As String, Sucursal As String, Clasificacion As String,
                                                  Estatus As String, Descto As Decimal, Motivo As String, IdUsuario As Integer,
                                                  IdUsuarioCancela As Integer) As Boolean

        'mreyes 05/Diciembre/2018   12:54 p.m.

        Try
            Return objDALCreditoNuevo.usp_CapturaDescuentoAdicional(Opcion, FechaIni, Fechafin, DistribIni, DistribFin, Sucursal, Clasificacion, Estatus, Descto, Motivo, IdUsuario, IdUsuarioCancela)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try


    End Function


    Public Function usp_TraerInfoPagoDet(Opcion As Integer, Sucursal As String, Nota As String, Pago As Integer) As DataSet
        'mreyes 07/Diciembre/2018   11:58 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerInfoPagoDet = objDALCreditoNuevo.usp_TraerInfoPagoDet(Opcion, Sucursal, Nota, Pago)
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

        'mreyes 07/Diciembre/2018   12:57 p.m.

        Try
            Return objDALCreditoNuevo.usp_CapturaTipoPagos(Opcion, IdPagos, Sucursal, FormaPago, Status, Fecha, Importe, Dolares, Cambio, Emisor, NoTarjeta, Autorizacion, RutaBancaria, NoCuenta, NoCheque, IdActivos, IdUsuario)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try


    End Function


    Public Function usp_TraerMotivos(Tipo As String) As DataSet
        'mreyes 07/Diciembre/2018   05:25 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMotivos = objDALCreditoNuevo.usp_TraerMotivos(Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPermisosCaja(IdDepto As Integer, IdPuesto As Integer, Tipo As String, Subtipo As String) As DataSet
        'mreyes 07/Diciembre/2018   06:17 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPermisosCaja = objDALCreditoNuevo.usp_TraerPermisosCaja(IdDepto, IdPuesto, Tipo, Subtipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaEntrega(Opcion As Integer, IdEmpleado As Integer, Fecha As Date,
                                       IdEntrega As Integer, Forma As String, Cantidad As Integer,
                                       Articulo As String, Importe As Decimal, Dolares As Decimal) As Boolean

        'mreyes 08/Diciembre/2018   12:34 p.m.


        Try
            Return objDALCreditoNuevo.usp_CapturaEntrega(Opcion, IdEmpleado, Fecha, IdEntrega, Forma, Cantidad, Articulo, Importe, Dolares)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEntrega(Opcion As Integer, IdEmpleado As Integer, Fecha As Date) As DataSet
        'mreyes 07/Diciembre/2018   12:41 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEntrega = objDALCreditoNuevo.usp_TraerEntrega(Opcion, IdEmpleado, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerInfoCorte(Opcion As Integer, Fecha As Date, IdUsuario As Integer) As DataSet
        'mreyes 07/Diciembre/2018   01:08 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerInfoCorte = objDALCreditoNuevo.usp_TraerInfoCorte(Opcion, Fecha, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDistribuidorCredito(Opcion As Integer, Distrib As String, Nombre As String) As DataSet
        'mreyes 11/Diciembre/2018   04:49 p.m .
        Try
            'Call the data component to get all groups
            usp_TraerDistribuidorCredito = objDALCreditoNuevo.usp_TraerDistribuidorCredito(Opcion, Distrib, Nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaAnticipo(Opcion As Integer, IdAnticipob As Integer, SucursalB As String,
    DistribB As String, StatusB As String, ImporteB As Decimal,
    AplicadoB As Integer, IdUsuarioB As Integer, IdPagoAplicaB As Integer) As Boolean

        'mreyes 19/Diciembre/2018   04:49 p.m.


        Try
            Return objDALCreditoNuevo.usp_CapturaAnticipo(Opcion, IdAnticipob, SucursalB, DistribB, StatusB, ImporteB, AplicadoB, IdUsuarioB, IdPagoAplicaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAnticipo(Opcion As Integer, DistribB As String, SucursalB As String, IdUsuarioB As Integer, FechaB As Date) As DataSet
        'mreyes 19/Diciembre/2018   04:49 p.m .
        Try
            'Call the data component to get all groups
            usp_TraerAnticipo = objDALCreditoNuevo.usp_TraerAnticipo(Opcion, DistribB, SucursalB, IdUsuarioB, FechaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescuentoCaja(ImporteB As Decimal) As DataSet
        'mreyes 19/Diciembre/2018   04:59 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDescuentoCaja = objDALCreditoNuevo.usp_TraerDescuentoCaja(ImporteB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPlanPagos(Opcion As Integer, Distrib As String) As DataSet
        'mreyes 19/Diciembre/2018   05:21 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPlanPagos = objDALCreditoNuevo.usp_TraerPlanPagos(Opcion, Distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerParametrosCredito(TipoB As String) As DataSet
        'mreyes 19/Diciembre/2018   05:26 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerParametrosCredito = objDALCreditoNuevo.usp_TraerParametrosCredito(TipoB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerNotaPP(Opcion As Integer, SucursalB As String, NotaB As String) As DataSet
        'mreyes 19/Diciembre/2018   05:26 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerNotaPP = objDALCreditoNuevo.usp_TraerNotaPP(Opcion, SucursalB, NotaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCargos(Opcion As Integer, SucursalB As String, NotaB As String) As DataSet
        'mreyes 19/Diciembre/2018   06:56 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCargos = objDALCreditoNuevo.usp_TraerCargos(Opcion, SucursalB, NotaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
