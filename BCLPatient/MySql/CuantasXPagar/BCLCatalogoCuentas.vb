Public Class BCLCatalogoCuentas

    Implements IDisposable
    Private objDALCatalogoCuentas As DAL.DALCatalogoCuentas
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoCuentas = New DAL.DALCatalogoCuentas(Constring)
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

    Public Function usp_PpalCatalogoCuentas() As DataSet
        'Tony Garcia 26/Junio/2013 10:32 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalCatalogoCuentas = objDALCatalogoCuentas.usp_PpalCatalogoCuentas()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_TraerPagoTarjetas() As DataSet
    '    'mreyes 28/Mayo/2012 09:48 a.m.

    '    Try
    '        'Call the data component to get all groups
    '        usp_TraerPagoTarjetas = objDALCatalogoTarjetas.usp_TraerPagoTarjetas()
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function Inserta_Cuenta() As DataSet
        'Tony Garcia 26/Junio/2013 10:09 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Cuenta = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Cuenta.Tables.Add("cuentas")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("banco", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("titular", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nocuenta", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nocheque", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("noultcheque", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("saldo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("prioridad", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("subcuenta", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Cuenta(ByVal Opcion As Integer, ByVal IdCuenta As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoCuentas.usp_Captura_Cuenta(Opcion, IdCuenta, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCuenta(ByVal IdCuenta As Integer, ByVal Banco As String) As DataSet
        'Tony Garcia 26/Junio/2013 10:45 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCuenta = objDALCatalogoCuentas.usp_TraerCuenta(IdCuenta, Banco)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaNoCheque(ByVal IdCuenta As Integer, ByVal noCheque As String) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaNoCheque = objDALCatalogoCuentas.usp_ActualizaNoCheque(IdCuenta, noCheque)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaPagoFacturaDiferidos(ByVal Opcion As Integer, ByVal idFolioSuc As String, ByVal Pagado As String, ByVal Fecha As String, ByVal idLiquidacion As Integer, ByVal nopago As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaPagoFacturaDiferidos = objDALCatalogoCuentas.usp_ActualizaPagoFacturaDiferidos(Opcion, idFolioSuc, Pagado, Fecha, idLiquidacion, nopago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaPagoFactura(ByVal Opcion As Integer, ByVal idFolioSuc As String, ByVal Pagado As String, ByVal Fecha As String, ByVal idLiquidacion As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_ActualizaPagoFactura = objDALCatalogoCuentas.usp_ActualizaPagoFactura(Opcion, idFolioSuc, Pagado, Fecha, idLiquidacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraFactprovFactorajeCancela(ByVal Proveedor As String, ByVal idFolio As Integer, ByVal IdEmpleado As Integer) As Boolean
        Try
            'mreyes 07/Noviembre/2014   06:09 p.m.
            'Call the data component to get all groups
            usp_GeneraFactprovFactorajeCancela = objDALCatalogoCuentas.usp_GeneraFactprovFactorajeCancela(Proveedor, idFolio, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaDisponibleFactoraje(ByVal IdBancoFactorajeB As Integer) As Boolean
        Try
            'mreyes 07/Noviembre/2014   01:04 p.m.
            'Call the data component to get all groups
            usp_ActualizaDisponibleFactoraje = objDALCatalogoCuentas.usp_ActualizaDisponibleFactoraje(IdBancoFactorajeB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraDatosFactprovArchivoFactoraje(ByVal Proveedor As String, ByVal idFolio As Integer, ByVal IdEmpleado As Integer) As Boolean
        Try
            'mreyes 07/Noviembre/2014   01:04 p.m.
            'Call the data component to get all groups
            usp_GeneraDatosFactprovArchivoFactoraje = objDALCatalogoCuentas.usp_GeneraDatosFactprovArchivoFactoraje(Proveedor, idFolio, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraFactprovFactoraje(ByVal Proveedor As String, ByVal idFolio As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_GeneraFactprovFactoraje = objDALCatalogoCuentas.usp_GeneraFactprovFactoraje(Proveedor, idFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    'usp_GeneraSaldoProvFactoraje
    Public Function usp_GeneraSaldoProvFactoraje() As Boolean
        'mreyes 31/Octubre/2014 05:59 p.m.

        Try
            'Call the data component to get all groups
            usp_GeneraSaldoProvFactoraje = objDALCatalogoCuentas.usp_GeneraSaldoProvFactoraje()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraSaldoProv() As Boolean
        'mreyes 25/Noviembre/2014   12:43 p.m.

        Try
            'Call the data component to get all groups
            usp_GeneraSaldoProv = objDALCatalogoCuentas.usp_GeneraSaldoProv()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraSaldoProvFactorajeArt() As Boolean
        'mreyes 31/Octubre/2014 06:04 p.m.

        Try
            'Call the data component to get all groups
            usp_GeneraSaldoProvFactorajeArt = objDALCatalogoCuentas.usp_GeneraSaldoProvFactorajeArt()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
