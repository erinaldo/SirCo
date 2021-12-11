Public Class BCLCorteFolios
    'mreyes 17/Junio/2015   10:21 a.m.

    Implements IDisposable
    Private objDALCorteFolios As DAL.DALCorteFolios
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCorteFolios = New DAL.DALCorteFolios(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCorteFolios.Dispose()
            objDALCorteFolios = Nothing
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
    Public Function usp_PpalCorteFolios(ByVal Sucursal As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 17/Junio/2015   11:03 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalCorteFolios = objDALCorteFolios.usp_PpalCorteFolios(Sucursal, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Plano(ByVal Marca As String, ByVal Estilon As String, ByVal Archivo As String) As Boolean


        'mreyes 01/Abril/2015 10:26 a.m.

        Try

            usp_Captura_Plano = objDALCorteFolios.usp_Captura_Plano(Marca, Estilon, Archivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Bulto(ByVal Opcion As Integer, ByVal IdFolioB As Integer, ByVal ProveedorB As String, ByVal MarcaB As String, ByVal NoGuiaB As String, _
                               ByVal TransportaB As String, ByVal NoBultosB As Decimal, ByVal NoSucursalB As Integer, _
                               ByVal comentariosB As String, ByVal RecibeB As Integer, ByVal fecrecibeB As Date, ByVal asignaB As Integer, ByVal fecasignaB As Date, _
                              ByVal usuarioB As String, ByVal fumB As DateTime, ByVal usuarioasignaB As String, ByVal fumasignaB As DateTime, _
                              ByVal detalleB As Integer, ByVal fumdetalleB As DateTime, ByVal entrajaulaB As Integer, ByVal salejaulaB As Integer, _
                              ByVal subecamionB As Integer, ByVal generotraspasoB As Integer, ByVal IdFolioSucB As String, ByVal statusb As String, ByVal tipob As String, ByVal SFb As Integer) As Boolean



        Try

            usp_Captura_Bulto = objDALCorteFolios.usp_Captura_Bulto(Opcion, IdFolioB, ProveedorB, MarcaB, NoGuiaB, _
                                                              TransportaB, NoBultosB, NoSucursalB, comentariosB, RecibeB, fecrecibeB, asignaB, fecasignaB, usuarioB, fumB, usuarioasignaB, fumasignaB, detalleB, fumdetalleB, entrajaulaB, salejaulaB, subecamionB, generotraspasoB, IdFolioSucB, statusb, tipob, SFb)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetCodigo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 17/Febrero/2013 01:19 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCorteFolios.usp_Captura_DetCodigo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_DetCodigo() As DataSet
        'mreyes 17/Febrero/2013 01:06 p.m. 
        Try
            'Instantiate a new DataSet object
            Inserta_DetCodigo = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_DetCodigo.Tables.Add("DetCodigo")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idfolio", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("codigo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impreso", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("fum", Type.GetType("System.DateTime"))

            objDataColumn = New DataColumn("usuarioimprime", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)


            'objDataColumn = New DataColumn("fumimprime", Type.GetType("System.DateTime"))

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalBultosDetalladoDet(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Proveedor As String, ByVal Noguia As String, _
                                                    ByVal Folio As Integer, ByVal Recibe As Integer, _
                                                    ByVal Asigna As Integer, ByVal FechaRecIni As String, ByVal FechaRecFin As String, _
                                                    ByVal FechaAsigIni As String, ByVal FechaAsigFin As String, ByVal CveSucursal As String, ByVal Status As String, ByVal Tipo As String) As DataSet
        'Tony Garcia - 24/Enero/2013 - 12:50 p.m.
        Try
            Return objDALCorteFolios.usp_PpalBultosDetalladoDet(Opcion, Sucursal, Proveedor, Noguia, Folio, Recibe, Asigna, FechaRecIni, FechaRecFin, FechaAsigIni, FechaAsigFin, CveSucursal, Status, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerBulto(ByVal IdFolio As String, ByVal IdFolioSuc As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerBulto = objDALCorteFolios.usp_TraerBulto(IdFolio, IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetCodigo(ByVal Codigo As String) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            usp_TraerDetCodigo = objDALCorteFolios.usp_TraerDetCodigo(Codigo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_TraerIdFolio(ByVal IdFolioSuc As String) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            pub_TraerIdFolio = objDALCorteFolios.pub_TraerIdFolio(IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdFolioSucBulto(ByVal IdFolio As Integer) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            usp_TraerIdFolioSucBulto = objDALCorteFolios.usp_TraerIdFolioSucBulto(IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_TraerIdFolioBulto(ByVal IdFolioSuc As String) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            pub_TraerIdFolioBulto = objDALCorteFolios.pub_TraerIdFolioBulto(IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetBulto(ByVal IdFolio As Integer, ByVal Sucursal As String, ByVal Pedido As String) As DataSet
        'mreyes 20/Enero/2012 01:02 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetBulto = objDALCorteFolios.usp_TraerDetBulto(IdFolio, Sucursal, Pedido)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalBulto(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, ByVal Proveedor As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalBulto = objDALCorteFolios.usp_PpalBulto(FolioA, FolioB, Sucursal, Proveedor, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaBultos(ByVal Folio As String, ByVal Sucursal As String, ByVal Proveedor As String, ByVal NoGuia As String, _
                                      ByVal Transporta As String, ByVal NoBultos As Integer, ByVal Recibe As Integer, ByVal NombreRec As String, _
                                      ByVal Entrega As Integer, ByVal NombreEnt As String, ByVal Factura As String, ByVal Comentarios As String) As Boolean
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizaBultos = objDALCorteFolios.usp_ActualizaBultos(Folio, Sucursal, Proveedor, NoGuia, Transporta, NoBultos, Recibe, _
                                                                NombreRec, Entrega, NombreEnt, Factura, Comentarios)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function Inserta_DetBulto() As DataSet
        Try
            'mreyes 20/Enero/2013 01:36 p.m.

            Inserta_DetBulto = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_DetBulto.Tables.Add("DetBulto")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("idfolio", Type.GetType("System.Int32"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))

            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nobultos", Type.GetType("System.Decimal"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucurorc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ordecomp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("factura", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("fecfactura", Type.GetType("System.DateTime"))

            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetBulto(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 20/Enero/2013 01:46 p.m.

            Return objDALCorteFolios.usp_Captura_DetBulto(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalAntiJaula(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 22/Febrero/2013 - 06:50 p.m.
        Try
            Return objDALCorteFolios.usp_PpalAntiJaula(Accion, Opcion, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_PpalAntiJaulaDet(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Proveedor As String, ByVal Noguia As String, _
                                                      ByVal Folio As Integer, ByVal Recibe As Integer, _
                                                      ByVal Asigna As Integer, ByVal FechaRecIni As String, ByVal FechaRecFin As String, _
                                                      ByVal FechaAsigIni As String, ByVal FechaAsigFin As String, _
                                                      ByVal DiasIni As Integer, ByVal DiasFin As Integer) As DataSet
        'Tony Garcia - 23/Febrero/2013 - 11:20 a.m.
        Try
            Return objDALCorteFolios.usp_PpalAntiJaulaDet(Accion, Opcion, Sucursal, Proveedor, Noguia, Folio, Recibe, Asigna, FechaRecIni, FechaRecFin, FechaAsigIni, FechaAsigFin, DiasIni, DiasFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
