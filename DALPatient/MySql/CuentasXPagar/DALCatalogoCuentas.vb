Imports System.Data.Odbc


Public Class DALCatalogoCuentas
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


    Public Function usp_PpalCatalogoCuentas() As DataSet
        'Tony Garcia 26/Junio/2013 10:32 a.m.
        Try
            usp_PpalCatalogoCuentas = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoCuentas()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_PpalCatalogoCuentas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_TraerPagoTarjetas() As DataSet
    '    'mreyes 28/Mayo/2012 09:48 a.m.
    '    Try
    '        usp_TraerPagoTarjetas = New DataSet
    '        MyBase.SQL = "CALL usp_TraerPagoTarjetas()"

    '        MyBase.InitializeCommand()
    '        'MyBase.AddParameter("@Marcab", OdbcType.Char, 50, Marca)


    '        MyBase.FillDataSet(usp_TraerPagoTarjetas, "cipsis")
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function


    Public Function usp_Captura_Cuenta(ByVal Opcion As Integer, ByVal IdCuenta As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Cuenta(?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idcuenta", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@banco", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("banco"))
            MyBase.AddParameter("@titular", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("titular"))
            MyBase.AddParameter("@nocuenta", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("nocuenta"))
            MyBase.AddParameter("@nocheque", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("nocheque"))
            MyBase.AddParameter("@noultcheque", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("noultcheque"))
            MyBase.AddParameter("@saldo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("saldo"))
            MyBase.AddParameter("@prioridad", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("prioridad"))
            MyBase.AddParameter("@subcuenta", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("subcuenta"))
            MyBase.AddParameter("@idusuario", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idusuario"))

            usp_Captura_Cuenta = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCuenta(ByVal IdCuenta As Integer, ByVal Banco As String) As DataSet
        'Tony Garcia 26/Junio/2013 10:45 a.m.
        Try
            usp_TraerCuenta = New DataSet
            MyBase.SQL = "CALL usp_TraerCuenta(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idcuentab", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@BancoB", OdbcType.Char, 20, Banco)

            MyBase.FillDataSet(usp_TraerCuenta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizaNoCheque(ByVal IdCuenta As Integer, ByVal noCheque As String) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizaNoCheque(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idCuentaB", OdbcType.Int, 16, IdCuenta)
            MyBase.AddParameter("@noChequeB", OdbcType.Char, 7, noCheque)

            usp_ActualizaNoCheque = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaPagoFacturaDiferidos(ByVal Opcion As Integer, ByVal idFolioSuc As String, ByVal Pagado As String, ByVal Fecha As String, ByVal idLiquidacion As Integer, ByVal NoPago As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizaPagoFacturaDiferidos(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@idFolioSucB", OdbcType.Char, 8, idFolioSuc)
            MyBase.AddParameter("@PagadoB", OdbcType.Char, 2, Pagado)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@idLiquidacion", OdbcType.Int, 8, idLiquidacion)
            MyBase.AddParameter("@NoPago", OdbcType.Int, 8, nopago)

            usp_ActualizaPagoFacturaDiferidos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaPagoFactura(ByVal Opcion As Integer, ByVal idFolioSuc As String, ByVal Pagado As String, ByVal Fecha As String, ByVal idLiquidacion As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizaPagoFactura(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@idFolioSucB", OdbcType.Char, 8, idFolioSuc)
            MyBase.AddParameter("@PagadoB", OdbcType.Char, 2, Pagado)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@idLiquidacion", OdbcType.Int, 8, idLiquidacion)

            usp_ActualizaPagoFactura = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraFactprovFactorajeCancela(ByVal Proveedor As String, ByVal IdFolio As Integer, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 07/Noviembre/2014   06:10 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraFactprovFactorajeCancela(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@idFolioB", OdbcType.Int, 8, IdFolio)
            MyBase.AddParameter("@IdEmpleadoB", OdbcType.Int, 8, IdEmpleado)


            usp_GeneraFactprovFactorajeCancela = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaDisponibleFactoraje(ByVal IdBancoFactoraje As Integer) As Boolean
        'mreyes 07/Noviembre/2014   01:04 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaDisponibleBancoFactoraje(?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idBancoFactorajeB", OdbcType.Int, 8, IdBancoFactoraje)



            usp_ActualizaDisponibleFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraDatosFactprovArchivoFactoraje(ByVal Proveedor As String, ByVal IdFolio As Integer, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 07/Noviembre/2014   01:04 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraDatosFactprovArchivoFactoraje(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@idFolioB", OdbcType.Int, 8, IdFolio)
            MyBase.AddParameter("@IdEmpleadoB", OdbcType.Int, 8, IdEmpleado)


            usp_GeneraDatosFactprovArchivoFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraFactprovFactoraje(ByVal Proveedor As String, ByVal IdFolio As Integer) As Boolean
        'mreyes 31/Octubre/2014 05:47 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraFactprovFactoraje(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@idFolioB", OdbcType.Int, 8, IdFolio)

         
            usp_GeneraFactprovFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraSaldoProv() As Boolean
        'mreyes 25/Noviembre/2014   12:43 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraSaldoProv()" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()



            usp_GeneraSaldoProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraSaldoProvFactoraje() As Boolean
        'mreyes 31/Octubre/2014 06:00 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraSaldoProvFactoraje()" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()



            usp_GeneraSaldoProvFactoraje = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraSaldoProvFactorajeArt() As Boolean
        'mreyes 31/Octubre/2014 06:03 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraSaldoProvFactorajeArt()" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()



            usp_GeneraSaldoProvFactorajeArt = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
