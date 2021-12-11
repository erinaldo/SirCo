Imports System.Data.Odbc


Public Class DALLiquidacion
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

    Public Function usp_CapturaLiquidacionTransferencia(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, Improcedente As Double) As Boolean
        'mreyes 09/Mayo/2019    12:31 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionTransferencia(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@idUsuarioB", OdbcType.Int, 16, Usuario)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 10, FecFin)

            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)



            usp_CapturaLiquidacionTransferencia = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionFactoraje(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, Improcedente As Double) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionFactoraje(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@idUsuarioB", OdbcType.Int, 16, Usuario)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 10, FecFin)

            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)

            usp_CapturaLiquidacionFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaLiquidacionDiferidos(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, Improcedente As Double) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionDiferidos(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@idUsuarioB", OdbcType.Int, 16, Usuario)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 10, FecFin)

            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)


            usp_CapturaLiquidacionDiferidos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaLiquidacion(ByVal IdCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Status As String, ByVal Tipo As String, ByVal Fum As String, ByVal Usuario As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal Improcedente As Double) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacion(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@idUsuarioB", OdbcType.Int, 16, Usuario)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)


            usp_CapturaLiquidacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDetTransferencia(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, Improcedente As Double) As Boolean
        'mreyes 09/Mayo/2019    03:52 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionDetTransferencia(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, IdFolio)
            MyBase.AddParameter("@NoChequeB", OdbcType.Char, 7, NoCheque)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 50, Proveedor)
            MyBase.AddParameter("@FacturaB", OdbcType.Char, 10, Factura)
            MyBase.AddParameter("@EstatusB", OdbcType.Int, 16, Estatus)
            MyBase.AddParameter("@FechaFacturaB", OdbcType.DateTime, 10, FechaFactura)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)

            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)

            usp_CapturaLiquidacionDetTransferencia = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDetFactoraje(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, Improcedente As Double) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionDetFactoraje(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, IdFolio)
            MyBase.AddParameter("@NoChequeB", OdbcType.Char, 7, NoCheque)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 50, Proveedor)
            MyBase.AddParameter("@FacturaB", OdbcType.Char, 10, Factura)
            MyBase.AddParameter("@EstatusB", OdbcType.Int, 16, Estatus)
            MyBase.AddParameter("@FechaFacturaB", OdbcType.DateTime, 10, FechaFactura)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)

            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)

            usp_CapturaLiquidacionDetFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDetDiferidos(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal NoPago As Integer, ByVal Pagos As Integer, Improcedente As Double) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionDetDiferidos(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, IdFolio)
            MyBase.AddParameter("@NoChequeB", OdbcType.Char, 7, NoCheque)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 50, Proveedor)
            MyBase.AddParameter("@FacturaB", OdbcType.Char, 10, Factura)
            MyBase.AddParameter("@EstatusB", OdbcType.Int, 16, Estatus)
            MyBase.AddParameter("@FechaFacturaB", OdbcType.DateTime, 10, FechaFactura)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)

            MyBase.AddParameter("@PagoB", OdbcType.Int, 8, NoPago)
            MyBase.AddParameter("@NoPagosB", OdbcType.Int, 8, Pagos)

            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)

            usp_CapturaLiquidacionDetDiferidos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CapturaLiquidacionDet(ByVal idLiquidacion As Integer, ByVal IdFolio As String, ByVal NoCheque As String, ByVal Proveedor As String, ByVal Factura As String, ByVal Estatus As Integer, ByVal FechaFactura As Date, ByVal Fecha As Date, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, Improcedente As Double) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaLiquidacionDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, IdFolio)
            MyBase.AddParameter("@NoChequeB", OdbcType.Char, 7, NoCheque)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 50, Proveedor)
            MyBase.AddParameter("@FacturaB", OdbcType.Char, 10, Factura)
            MyBase.AddParameter("@EstatusB", OdbcType.Int, 16, Estatus)
            MyBase.AddParameter("@FechaFacturaB", OdbcType.DateTime, 10, FechaFactura)
            MyBase.AddParameter("@FechaB", OdbcType.DateTime, 10, Fecha)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@ImprocedenteB", OdbcType.Double, 9, Improcedente)

            usp_CapturaLiquidacionDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdLiquidacionTransferencia() As DataSet
        Try
            usp_TraerIdLiquidacionTransferencia = New DataSet
            MyBase.SQL = "CALL usp_TraerIdLiquidacionTransferencia()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerIdLiquidacionTransferencia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdLiquidacionFactoraje() As DataSet
        Try
            usp_TraerIdLiquidacionFactoraje = New DataSet
            MyBase.SQL = "CALL usp_TraerIdLiquidacionFactoraje()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerIdLiquidacionFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdLiquidacionDiferidos() As DataSet
        Try
            usp_TraerIdLiquidacionDiferidos = New DataSet
            MyBase.SQL = "CALL usp_TraerIdLiquidacionDiferidos()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerIdLiquidacionDiferidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdLiquidacion() As DataSet
        Try
            usp_TraerIdLiquidacion = New DataSet
            MyBase.SQL = "CALL usp_TraerIdLiquidacion()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerIdLiquidacion, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacionFactoraje(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal Tipo As String) As DataSet
        Try
            usp_TraerLiquidacionFactoraje = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionFactoraje(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 8, idLiquidacion)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 9, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 9, FecFin)
            MyBase.AddParameter("@ClasifB", OdbcType.Char, 250, strEstatus)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.FillDataSet(usp_TraerLiquidacionFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerLiquidacionTransferencia(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal strEstatus1 As String, ByVal strEstatus2 As String, ByVal Tipo As String) As DataSet
        Try
            'mreyes 09/Mayo/2019    11:29 a.m.
            usp_TraerLiquidacionTransferencia = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionTransferencia(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 8, idLiquidacion)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 9, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 9, FecFin)
            MyBase.AddParameter("@ClasifB", OdbcType.Char, 250, strEstatus)
            MyBase.AddParameter("@ClasifBB", OdbcType.Char, 250, strEstatus1)
            MyBase.AddParameter("@ClasifBBB", OdbcType.Char, 250, strEstatus2)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.FillDataSet(usp_TraerLiquidacionTransferencia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacionDiferidos(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal strEstatus1 As String, ByVal strEstatus2 As String, ByVal Tipo As String) As DataSet
        Try
            usp_TraerLiquidacionDiferidos = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDiferidos(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 8, idLiquidacion)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 9, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 9, FecFin)
            MyBase.AddParameter("@ClasifB", OdbcType.Char, 250, strEstatus)
            MyBase.AddParameter("@ClasifBB", OdbcType.Char, 250, strEstatus1)
            MyBase.AddParameter("@ClasifBBB", OdbcType.Char, 250, strEstatus2)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.FillDataSet(usp_TraerLiquidacionDiferidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacion(ByVal idLiquidacion As Integer, ByVal FecIni As Date, ByVal FecFin As Date, ByVal strEstatus As String, ByVal strEstatus1 As String, ByVal strEstatus2 As String, strEstatus3 As String, ByVal Tipo As String) As DataSet
        Try
            usp_TraerLiquidacion = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacion(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 8, idLiquidacion)
            MyBase.AddParameter("@FecIniB", OdbcType.Date, 9, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Date, 9, FecFin)
            MyBase.AddParameter("@ClasifB", OdbcType.Char, 250, strEstatus)
            MyBase.AddParameter("@ClasifBB", OdbcType.Char, 250, strEstatus1)
            MyBase.AddParameter("@ClasifBBB", OdbcType.Char, 250, strEstatus2)
            MyBase.AddParameter("@ClasifBBBB", OdbcType.Char, 250, strEstatus3)

            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)

            MyBase.FillDataSet(usp_TraerLiquidacion, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDetFactoraje = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetFactoraje(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacionDetTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDetTransferencia = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetTransferencia(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetTransferencia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDetDiferidos = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetDiferidos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetDiferidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDet(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDet = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDet(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetalleFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDetalleFactoraje = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetalleFactoraje(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 255, proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetalleFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLiquidacionDetalleTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            'mreyes 09/Mayo/2019    10:02 a.m.
            usp_TraerLiquidacionDetalleTransferencia = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetalleTransferencia(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 255, proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetalleTransferencia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetalleDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDetalleDiferidos = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetalleDiferidos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 255, proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetalleDiferidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLiquidacionDetalle(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal proveedor As String) As DataSet
        Try
            usp_TraerLiquidacionDetalle = New DataSet
            MyBase.SQL = "CALL usp_TraerLiquidacionDetalle(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 255, proveedor)
            MyBase.FillDataSet(usp_TraerLiquidacionDetalle, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizaEstatusLiquidacionFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaEstatusLiquidacionFactoraje(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, idCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)

            usp_ActualizaEstatusLiquidacionFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaEstatusLiquidacionTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 09/Mayo/2019    10:09 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaEstatusLiquidacionTransferencia(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, idCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)

            usp_ActualizaEstatusLiquidacionTransferencia = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusLiquidacionDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaEstatusLiquidacionDiferidos(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, idCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)

            usp_ActualizaEstatusLiquidacionDiferidos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusLiquidacion(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal Estatus As String, ByVal idCuenta As Integer, ByVal Subtotal As Double, ByVal Gastos As Double, ByVal Impuesto As Double, ByVal Cargo As Double, ByVal Credito As Double, ByVal Descuento As Double, ByVal Total As Double, ByVal Fum As String, ByVal IdEmpleado As Integer) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaEstatusLiquidacion(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, idCuenta)
            MyBase.AddParameter("@SubtotalB", OdbcType.Double, 9, Subtotal)
            MyBase.AddParameter("@GastosB", OdbcType.Double, 9, Gastos)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Double, 9, Impuesto)
            MyBase.AddParameter("@CargoB", OdbcType.Double, 9, Cargo)
            MyBase.AddParameter("@CreditoB", OdbcType.Double, 9, Credito)
            MyBase.AddParameter("@DescuentoB", OdbcType.Double, 9, Descuento)
            MyBase.AddParameter("@TotalB", OdbcType.Double, 9, Total)
            MyBase.AddParameter("@FumB", OdbcType.Char, 19, Fum)
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, idEmpleado)

            usp_ActualizaEstatusLiquidacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaLiquidacionDetFactoraje(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaLiquidacionDetFactoraje(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, idFolio)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noCheque)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noChequeAnt)

            usp_ActualizaLiquidacionDetFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizaLiquidacionDetTransferencia(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String) As Boolean
        'mreyes 09/Mayo/2019    10:24 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaLiquidacionDetTransferencia(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, idFolio)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noCheque)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noChequeAnt)

            usp_ActualizaLiquidacionDetTransferencia = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizaLiquidacionDetDiferidos(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String, ByVal NoPago As Integer) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaLiquidacionDetDiferidos(?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, idFolio)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noCheque)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noChequeAnt)

            MyBase.AddParameter("@NoPagoB", OdbcType.Int, 8, NoPago)

            usp_ActualizaLiquidacionDetDiferidos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaLiquidacionDet(ByVal Opcion As Integer, ByVal idLiquidacion As Integer, ByVal idFolio As String, ByVal noCheque As String, ByVal Estatus As String, ByVal noChequeAnt As String) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaLiquidacionDet(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idLiquidacionB", OdbcType.Int, 16, idLiquidacion)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, idFolio)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noCheque)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 8, noChequeAnt)

            usp_ActualizaLiquidacionDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFacturaReferenc(ByVal idFolioSuc As String) As DataSet
        Try
            usp_TraerFacturaReferenc = New DataSet
            MyBase.SQL = "CALL usp_TraerFacturaReferenc(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idFolioSucB", OdbcType.Char, 8, idFolioSuc)
            MyBase.FillDataSet(usp_TraerFacturaReferenc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
