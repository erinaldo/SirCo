Public Class BCLFacturas
    'mreyes 15/Marzo/2012 04:22 p.m.

    Implements IDisposable
    Private objDALFacturas As DAL.DALFacturas
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALFacturas = New DAL.DALFacturas(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALFacturas.Dispose()
            objDALFacturas = Nothing
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

    Public Function usp_PpalCancelaFactoraje(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                            ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                            ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                            ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 14/Octubre/2014 12:03 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalCancelaFactoraje = objDALFacturas.usp_PpalCancelaFactoraje(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalArchivoFactoraje(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                            ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                            ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                            ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 14/Octubre/2014 12:03 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalArchivoFactoraje = objDALFacturas.usp_PpalArchivoFactoraje(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasAFACTORAJE(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                    ByVal Proveedor As String, ByVal Status As String, _
                                    ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                    ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                    ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 07/Noviembre/2014   12:45 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturasAFACTORAJE = objDALFacturas.usp_PpalFacturasAFACTORAJE(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasDIFERIDOS(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                    ByVal Proveedor As String, ByVal Status As String, _
                                    ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                    ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                    ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 15/Marzo/2012 04:24 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturasDIFERIDOS = objDALFacturas.usp_PpalFacturasDIFERIDOS(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasINIPagoUnico(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                    ByVal Proveedor As String, ByVal Status As String, _
                                    ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                    ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                    ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 09/Diciembre/2014   10:18 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturasINIPagoUnico = objDALFacturas.usp_PpalFacturasINIPagoUnico(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalFacturas554(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                    ByVal Proveedor As String, ByVal Status As String, _
                                    ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                    ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                    ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 27/Mayo/2015    10:21 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturas554 = objDALFacturas.usp_PpalFacturas554(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasPendPago(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                        ByVal Proveedor As String, ByVal Status As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                        ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                        ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 11/Agosto/2015  06:27 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturasPendPago = objDALFacturas.usp_PpalFacturasPendPago(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasINI(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                        ByVal Proveedor As String, ByVal Status As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                        ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                        ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 15/Marzo/2012 04:24 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturasINI = objDALFacturas.usp_PpalFacturasINI(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturas(ByVal Opcion As Integer, ByVal FactNueva As Integer, ByVal Sucursal As String, ByVal FactIni As String, ByVal FactFin As String, ByVal Marca As String, _
                                            ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                            ByVal FechaRecIni As String, ByVal FechaRecFin As String, ByVal FechaPagoIni As String, ByVal FechaPagoFin As String, ByVal FactProvIni As String, _
                                            ByVal FactProvFin As String, ByVal IdFolioIni As String, ByVal IdFolioFin As String, ByVal Tipo As String) As DataSet
        'mreyes 15/Marzo/2012 04:24 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturas = objDALFacturas.usp_PpalFacturas(Opcion, FactNueva, Sucursal, FactIni, FactFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, FechaRecIni, FechaRecFin, _
                                                                    FechaPagoIni, FechaPagoFin, FactProvIni, FactProvFin, IdFolioIni, IdFolioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalFacturasDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Proveedor As String, _
                                                   ByVal FechaRecIni As String, ByVal FechaRecFin As String) As DataSet
        'mreyes 06/Diciembre/2013 10:16 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalFacturasDet = objDALFacturas.usp_PpalFacturasDet(Opcion, Sucursal, Marca, _
                                                                     Proveedor, _
                                                                     FechaRecIni, FechaRecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraDet_FPP(ByVal Proveedor As String, ByVal IdFolioB As Integer) As Boolean
        'mreyes 21/Enero/2013 10:17 a.m.
        Try
            'Call the data component to delete the group
            Return objDALFacturas.usp_GeneraDet_FPP(Proveedor, IdFolioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarFacturas(ByVal Proveedor As String, ByVal Referenc As String, ByVal Fecha As Date, ByVal FecVencB As Date) As Boolean
        'mreyes 23/Abril/2012 09:49 a.m.
        Try
            'Call the data component to delete the group
            Return objDALFacturas.usp_ActualizarFacturas(Proveedor, Referenc, Fecha, FecVencB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_FactProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 22/Mayo/2012 04:28 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALFacturas.usp_Captura_FactProv(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DevoProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 12/Junio/2013 04:29 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALFacturas.usp_Captura_DevoProv(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_DevoProv() As DataSet
        'mreyes 22/Mayo/2012 04:23 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_DevoProv = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_DevoProv.Tables.Add("DevProv")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("devoprov", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfolio", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("referenc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("gastos", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucurfpr", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("factprov", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("observa", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iva", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_FactProv() As DataSet
        'mreyes 22/Mayo/2012 04:23 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_FactProv = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_FactProv.Tables.Add("FactProv")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("factprov", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfolio", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecreci", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecvenc", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("referenc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("gastos", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descuento", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("observa", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dsctopp", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diaspp", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto01", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto02", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto03", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto04", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto05", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iva", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("subtotal", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impuesto", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("total", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("apagar", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("pares", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuariomodif", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuariocancela", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("entregavence", Type.GetType("System.DateTime"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("improcedente", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Det_fp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 22/Mayo/2012 05:21 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALFacturas.usp_Captura_Det_fp(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PedidoTemp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 25/Marzo/2014   10:36 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALFacturas.usp_Captura_PedidoTemp(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Det_dp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 22/Mayo/2012 05:21 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALFacturas.usp_Captura_Det_Dp(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Serie(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 22/Mayo/2012 06:24 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALFacturas.usp_Captura_Serie(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Det_fp() As DataSet
        'mreyes 22/Mayo/2012 05:17 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Det_fp = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Det_fp.Tables.Add("Det_fp")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("factprov", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("serie", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctd", Type.GetType("System.Int16"))
            'objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costo", Type.GetType("System.Decimal"))
            'objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costdesc", Type.GetType("System.Decimal"))
            'objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("precio", Type.GetType("System.Decimal"))
            'objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucurorc", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ordecomp", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)


            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Det_dp() As DataSet
        'mreyes 22/Mayo/2012 05:17 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Det_dp = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Det_dp.Tables.Add("Det_dp")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("devoprov", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("serie", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctd", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costdesc", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    'Public Function Inserta_Det_fp() As DataSet
    '    'mreyes 22/Mayo/2012 05:17 p.m.
    '    Try
    '        'Instantiate a new DataSet object
    '        Inserta_Det_fp = New DataSet
    '        'Create a DataTable object
    '        Dim objDataTable As DataTable = Inserta_Det_fp.Tables.Add("Det_fp")
    '        'Create a DataColumn object
    '        Dim objDataColumn As DataColumn

    '        'Instantiate a new DataColumn and set its properties
    '        objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 2
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("factprov", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 6
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 3
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 7
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 1
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 3
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("serie", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 13
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("ctd", Type.GetType("System.Int16"))
    '        objDataColumn.AllowDBNull = False
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("costo", Type.GetType("System.Decimal"))
    '        objDataColumn.AllowDBNull = False
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("costdesc", Type.GetType("System.Decimal"))
    '        objDataColumn.AllowDBNull = False
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("precio", Type.GetType("System.Decimal"))
    '        objDataColumn.AllowDBNull = False
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("sucurorc", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 2
    '        objDataTable.Columns.Add(objDataColumn)

    '        objDataColumn = New DataColumn("ordecomp", Type.GetType("System.String"))
    '        objDataColumn.AllowDBNull = False
    '        objDataColumn.MaxLength = 6
    '        objDataTable.Columns.Add(objDataColumn)


    '        'Add the column to the table


    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function
    Public Function Inserta_PedidoTemp() As DataSet
        'mreyes 24/Marzo/2014   05:17 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_PedidoTemp = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Det_dp.Tables.Add("Inserta_PedidoTemp")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ordeomp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Ta", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("Fam", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Lin", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Cat", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("EstiloFabrica", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 14
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("EstiloNuestro", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Descripcion", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 70
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("C", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("I", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("De", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("A", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("Pcomp", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("Porc", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("CSuc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("SucDescrip", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("prs", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M1", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M1_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M2", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M2_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M3", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M3_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M4", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M4_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M5", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M5_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M6", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M6_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M7", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M7_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M8", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M8_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M9", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M9_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M10", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M10_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M11", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M11_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M12", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M12_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M13", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M13_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M14", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M14_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M15", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M15_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M16", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M16_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M17", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M17_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M18", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M18_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M19", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M19_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M20", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M20_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M21", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M21_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M22", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M22_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M23", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M23_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M24", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M24_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M25", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M25_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M26", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M26_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M27", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M27_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M28", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M28_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M29", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M29_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M30", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M30_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M31", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M31_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M32", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M32_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M33", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M33_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M34", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M34_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M35", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M35_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M36", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M36_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M37", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M37_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M38", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M38_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M39", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M39_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M40", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M40_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M41", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M41_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M42", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M42_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M43", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M43_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M44", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M44_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M45", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M45_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M46", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M46_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M47", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M47_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M48", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M48_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("M49", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M49_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M50", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("M50_", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("Importe", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("FechaEntrega", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("FechaCancela", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("L1", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)



            objDataColumn = New DataColumn("L2", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("L3", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("L4", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("L5", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("L6", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("Estructura", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 250
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("Serie", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("IdArticulo", Type.GetType("System.decimal"))
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Serie() As DataSet
        'mreyes 22/Mayo/2012 06:30 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Serie = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Serie.Tables.Add("Serie")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

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
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("idarticulo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("precioini", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costoini", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("preciovta", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ultcosto", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedors", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)


            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_FichaRem() As DataSet

        Try
            'Instantiate a new DataSet object
            Inserta_FichaRem = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_FichaRem.Tables.Add("ficharem")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("foliof", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfolio", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfoliosuc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("importe", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Captura_FichaRem(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Tony Garcia 27/Junio/2013 11:30 a.m.
            Return objDALFacturas.usp_Captura_FichaRem(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_Traer_FichaRem(ByVal IdFolioSuc As String, ByVal IdFolio As Integer) As DataSet
        'Tony Garcia 27/Junio/2013 12:10 p.m.
        Try
            usp_Traer_FichaRem = objDALFacturas.usp_Traer_FichaRem(IdFolioSuc, IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivosRem() As DataSet
        'Tony Garcia 04/Julio/2013 05:10 p.m.
        Try
            usp_TraerMotivosRem = objDALFacturas.usp_TraerMotivosRem()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMotivoSB(ByVal IdFolio As Integer, ByVal IdFolioSuc As String, ByVal IdMotivo As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            'Tony Garcia 06/Julio/2013 11:30 a.m.
            Return objDALFacturas.usp_CapturaMotivoSB(IdFolio, IdFolioSuc, IdMotivo, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivoSB(ByVal IdFolio As Integer, ByVal IdFolioSuc As String) As DataSet
        'Tony Garcia 04/Julio/2013 05:10 p.m.
        Try
            usp_TraerMotivoSB = objDALFacturas.usp_TraerMotivoSB(IdFolio, IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ImprimirMasUno(ByVal sucursal As String, ByVal referenc As String) As DataSet
        'roberto

        Try
            'Call the data component to get all groups
            usp_ImprimirMasUno = objDALFacturas.usp_ImprimirMasUno(sucursal, referenc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltFolioFichaRem() As DataSet
        Try
            usp_TraerUltFolioFichaRem = objDALFacturas.usp_TraerUltFolioFichaRem()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDet_FPP(ByVal Opcion As Integer, ByVal IdFolioB As Integer) As DataSet
        'mreyes 21/Enero/2013 10:13 a.m.
        Try
            usp_TraerDet_FPP = objDALFacturas.usp_TraerDet_FPP(Opcion, IdFolioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
