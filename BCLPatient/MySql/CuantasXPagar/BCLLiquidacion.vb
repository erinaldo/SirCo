Public Class BCLLiquidacion

    Implements IDisposable
    Private objDALCatalogoCuentas As DAL.DALLiquidacion
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoCuentas = New DAL.DALLiquidacion(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoCuentas.Dispose()
            objDALCatalogoCuentas = Nothing
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

    Public Function usp_CapturaLiquidacionTransferencia(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, Improcedente As Double) As Boolean
        Try
            'mreyes 09/Mayo/2019    12:08 p.m.
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionTransferencia(IdCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Status, Tipo, Fum, Usuario, FecIni, FecFin, Improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionFactoraje(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, Improcedente As Double) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionFactoraje(IdCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Status, Tipo, Fum, Usuario, FecIni, FecFin, Improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDiferidos(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, Improcedente As Double) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionDiferidos(IdCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Status, Tipo, Fum, Usuario, FecIni, FecFin, Improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaLiquidacion(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, improcedente As Double) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacion(IdCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Status, Tipo, Fum, Usuario, FecIni, FecFin, improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDetFactoraje(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, Improcedente As Double) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionDetFactoraje(idLiquidacion, IdFolio, NoCheque, Proveedor, Factura, Estatus, FechaFactura, Fecha, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDetDiferidos(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal NoPago As Integer, ByVal Pagos As Integer, improcedente As Double) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionDetDiferidos(idLiquidacion, IdFolio, NoCheque, Proveedor, Factura, Estatus, FechaFactura, Fecha, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, NoPago, Pagos, improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDet(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, Improcedente As Double) As Boolean
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionDet(idLiquidacion, IdFolio, NoCheque, Proveedor, Factura, Estatus, FechaFactura, Fecha, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaLiquidacionDetTransferencia(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, Improcedente As Double) As Boolean
        Try
            'mreyes 09/Mayo/2019    03:51 p.m.
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_CapturaLiquidacionDetTransferencia(idLiquidacion, IdFolio, NoCheque, Proveedor, Factura, Estatus, FechaFactura, Fecha, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Improcedente)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdLiquidacionTransferencia() As DataSet
        'mreyes 096/Mayo/2019   01:05 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerIdLiquidacionTransferencia = objDALCatalogoCuentas.usp_TraerIdLiquidacionTransferencia()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdLiquidacionFactoraje() As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerIdLiquidacionFactoraje = objDALCatalogoCuentas.usp_TraerIdLiquidacionFactoraje()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdLiquidacionDiferidos() As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerIdLiquidacionDiferidos = objDALCatalogoCuentas.usp_TraerIdLiquidacionDiferidos()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdLiquidacion() As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerIdLiquidacion = objDALCatalogoCuentas.usp_TraerIdLiquidacion()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionFactoraje(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal Tipo As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionFactoraje = objDALCatalogoCuentas.usp_TraerLiquidacionFactoraje(idLiquidacion, FecIni, FecFin, strEstatus, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacionTransferencia(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal strEstatus1 As String, ByVal strEstatus2 As String, ByVal Tipo As String) As DataSet
        'mreyes 09/Mayo/2019    11:25 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionTransferencia = objDALCatalogoCuentas.usp_TraerLiquidacionTransferencia(idLiquidacion, FecIni, FecFin, strEstatus, strEstatus1, strEstatus2, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerLiquidacion(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal strEstatus1 As String, ByVal strEstatus2 As String, strEstatus3 As String, ByVal Tipo As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacion = objDALCatalogoCuentas.usp_TraerLiquidacion(idLiquidacion, FecIni, FecFin, strEstatus, strEstatus1, strEstatus2, strEstatus3, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDiferidos(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal strEstatus1 As String, ByVal strEstatus2 As String, ByVal Tipo As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDiferidos = objDALCatalogoCuentas.usp_TraerLiquidacionDiferidos(idLiquidacion, FecIni, FecFin, strEstatus, strEstatus1, strEstatus2, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDetFactoraje = objDALCatalogoCuentas.usp_TraerLiquidacionDetFactoraje(Opcion, idLiquidacion, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacionDetTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            'mreyes 09/Mayo/2019    09:56 a.m.
            usp_TraerLiquidacionDetTransferencia = objDALCatalogoCuentas.usp_TraerLiquidacionDettransferencia(Opcion, idLiquidacion, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDetDiferidos = objDALCatalogoCuentas.usp_TraerLiquidacionDetDiferidos(Opcion, idLiquidacion, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDet(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDet = objDALCatalogoCuentas.usp_TraerLiquidacionDet(Opcion, idLiquidacion, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    '' modificado 5 dic 2013

    Public Function usp_TraerLiquidacionDetalleTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            'mreyes 09/Mayo/2019    10:01 a.m.
            'Call the data component to get all groups
            usp_TraerLiquidacionDetalleTransferencia = objDALCatalogoCuentas.usp_TraerLiquidacionDetalleTransferencia(Opcion, idLiquidacion, proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetalleFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDetalleFactoraje = objDALCatalogoCuentas.usp_TraerLiquidacionDetalleFactoraje(Opcion, idLiquidacion, proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetalleDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDetalleDiferidos = objDALCatalogoCuentas.usp_TraerLiquidacionDetalleDiferidos(Opcion, idLiquidacion, proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetalle(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerLiquidacionDetalle = objDALCatalogoCuentas.usp_TraerLiquidacionDetalle(Opcion, idLiquidacion, proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaLiquidacionDetTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String) As Boolean
        Try
            'Call the data component to get all groups
            'mreyes 09/Mayo/2019    10:24 a.m.
            usp_ActualizaLiquidacionDetTransferencia = objDALCatalogoCuentas.usp_ActualizaLiquidacionDetTransferencia(Opcion, idLiquidacion, idFolio, noCheque, Estatus, noChequeAnt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaLiquidacionDetFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaLiquidacionDetFactoraje = objDALCatalogoCuentas.usp_ActualizaLiquidacionDetFactoraje(Opcion, idLiquidacion, idFolio, noCheque, Estatus, noChequeAnt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizaLiquidacionDetDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String, ByVal NoPago As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaLiquidacionDetDiferidos = objDALCatalogoCuentas.usp_ActualizaLiquidacionDetDiferidos(Opcion, idLiquidacion, idFolio, noCheque, Estatus, noChequeAnt, NoPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaLiquidacionDet(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaLiquidacionDet = objDALCatalogoCuentas.usp_ActualizaLiquidacionDet(Opcion, idLiquidacion, idFolio, noCheque, Estatus, noChequeAnt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusLiquidacionTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        Try
            'Call the data component to get all groups
            'mreyes 09/Mayo/2019    10:08 a.m.
            usp_ActualizaEstatusLiquidacionTransferencia = objDALCatalogoCuentas.usp_ActualizaEstatusLiquidacionTransferencia(Opcion, idLiquidacion, Estatus, idCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Fum, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusLiquidacionFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaEstatusLiquidacionFactoraje = objDALCatalogoCuentas.usp_ActualizaEstatusLiquidacionFactoraje(Opcion, idLiquidacion, Estatus, idCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Fum, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusLiquidacionDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaEstatusLiquidacionDiferidos = objDALCatalogoCuentas.usp_ActualizaEstatusLiquidacionDiferidos(Opcion, idLiquidacion, Estatus, idCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Fum, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusLiquidacion(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaEstatusLiquidacion = objDALCatalogoCuentas.usp_ActualizaEstatusLiquidacion(Opcion, idLiquidacion, Estatus, idCuenta, Subtotal, Gastos, Impuesto, Cargo, Credito, Descuento, Total, Fum, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFacturaReferenc(ByVal idFolioSuc As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerFacturaReferenc = objDALCatalogoCuentas.usp_TraerFacturaReferenc(idFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
