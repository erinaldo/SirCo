Public Class BCLAjustes
    'mreyes 19/Febrero/2016 01:27 p.m.

    Implements IDisposable
    Private objDALAjustes As DAL.DALAjustes
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAjustes = New DAL.DALAjustes(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALAjustes.Dispose()
            objDALAjustes = Nothing
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


    Public Function usp_Captura_Plano(ByVal Marca As String, ByVal Estilon As String, ByVal Archivo As String) As Boolean


        'mreyes 01/Abril/2015 10:26 a.m.

        Try

            usp_Captura_Plano = objDALAjustes.usp_Captura_Plano(Marca, Estilon, Archivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_TraerImpreSeries(ByVal Opcion As Integer, ByVal SucursalOri As String, ByVal IdFolioSuc As String, ByVal Serie As String, ByVal IdUsuario As String) As DataSet

        Try

            usp_Captura_TraerImpreSeries = objDALAjustes.usp_Captura_TraerImpreSeries(Opcion, SucursalOri, IdFolioSuc, Serie, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ImpreSeries(ByVal Opcion As Integer, ByVal SucursalOri As String, ByVal IdFolioSuc As String, ByVal Serie As String, ByVal IMPRIME As String, ByVal IdUsuario As String) As Boolean

        Try

            usp_Captura_ImpreSeries = objDALAjustes.usp_Captura_ImpreSeries(Opcion, SucursalOri, IdFolioSuc, Serie, IMPRIME, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    'Public Function usp_Captura_AjustexSob(ByVal Opcion As Integer, ByVal SucursalOri As String, ByVal IdFollioSuc As String, ByVal Proveedor As String, ByVal SucursalAct As String, ByVal Serie As String, ByVal FecReci As Date, ByVal MarcaAnterior As String, ByVal ModeloAnterior As String, ByVal CorridaAnterior As String, ByVal MedidaAnterior As String, ByVal MarcaNuevo As String, ByVal ModeloNuevo As String, ByVal CorridaNuevo As String, ByVal MedidaNuevo As String, ByVal Observaciones As String, ByVal IdUsuario As Integer) As Boolean
    '    'mreyes 09/Marzo/2016   05:49 p.m.

    '    Try

    '        usp_Captura_AjustexSob = objDALAjustes.usp_Captura_AjustexSob(Opcion, SucursalOri, IdFollioSuc, Proveedor, SucursalAct, Serie, FecReci, MarcaAnterior, ModeloAnterior, CorridaAnterior, MedidaAnterior, MarcaNuevo, ModeloNuevo, CorridaNuevo, MedidaNuevo, Observaciones, IdUsuario)
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_Captura_CajaCalzado(ByVal Opcion As Integer, ByVal SucursalOri As String, ByVal IdFollioSuc As String, ByVal Proveedor As String, ByVal SucursalAct As String, ByVal Serie As String, ByVal FecReci As Date, ByVal MarcaAnterior As String, ByVal ModeloAnterior As String, ByVal CorridaAnterior As String, ByVal MedidaAnterior As String, ByVal MarcaNuevo As String, ByVal ModeloNuevo As String, ByVal CorridaNuevo As String, ByVal MedidaNuevo As String, ByVal Observaciones As String, ByVal IdUsuario As Integer) As Boolean

        Try

            usp_Captura_CajaCalzado = objDALAjustes.usp_Captura_CajaCalzado(Opcion, SucursalOri, IdFollioSuc, Proveedor, SucursalAct, Serie, FecReci, MarcaAnterior, ModeloAnterior, CorridaAnterior, MedidaAnterior, MarcaNuevo, ModeloNuevo, CorridaNuevo, MedidaNuevo, Observaciones, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_PreciosDet(ByVal Opcion As Integer, ByVal SucContado As String, ByVal BloContado As String, ByVal SucCredito As String, ByVal BloCredito As String, ByVal Promocion As String, ByVal Fecha As String, ByVal IdUsuario As Integer) As Boolean

        Try

            usp_Captura_PreciosDet = objDALAjustes.usp_Captura_PreciosDet(Opcion, SucContado, BloContado, SucCredito, BloCredito, Promocion, Fecha, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalPreciosDet() As DataSet
        'mreyes 24/Octubre/2016   12:27 p.m.

        Try
            Return objDALAjustes.usp_PpalPreciosDet()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try


    End Function
    Public Function usp_PpalCajaCalzado(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal IdCajaCalzadoIni As Integer, _
                                            ByVal IdCajaCalzadoFin As Integer, ByVal FechaInib As String, ByVal FechaFinB As String) As DataSet
        'mreyes 02/Marzo/2016   06:41 p.m.
        'sucursalb char(2), idcajacalzadoini int(16), idcajacalzadofin int(16), fechainib char(10),  fechafinb char(10)
        Try
            Return objDALAjustes.usp_PpalCajaCalzado(Opcion, Sucursal, IdCajaCalzadoIni, IdCajaCalzadoFin, FechaInib, FechaFinB)
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
            Return objDALAjustes.usp_Captura_DetCodigo(Opcion, Section)
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
            Return objDALAjustes.usp_PpalBultosDetalladoDet(Opcion, Sucursal, Proveedor, Noguia, Folio, Recibe, Asigna, FechaRecIni, FechaRecFin, FechaAsigIni, FechaAsigFin, CveSucursal, Status, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerBulto(ByVal IdFolio As String, ByVal IdFolioSuc As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerBulto = objDALAjustes.usp_TraerBulto(IdFolio, IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetCodigo(ByVal Codigo As String) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            usp_TraerDetCodigo = objDALAjustes.usp_TraerDetCodigo(Codigo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_TraerIdFolio(ByVal IdFolioSuc As String) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            pub_TraerIdFolio = objDALAjustes.pub_TraerIdFolio(IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioDevoProv(ByVal IdFolio As Integer) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            usp_TraerFolioDevoProv = objDALAjustes.usp_TraerFolioDevoProv(IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFolioEntrada(ByVal IdFolio As Integer) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            usp_TraerFolioEntrada = objDALAjustes.usp_TraerFolioEntrada(IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdFolioSucBulto(ByVal IdFolio As Integer) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            usp_TraerIdFolioSucBulto = objDALAjustes.usp_TraerIdFolioSucBulto(IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function pub_TraerIdFolioBulto(ByVal IdFolioSuc As String) As DataSet
        'mreyes 
        Try
            'Call the data component to get all groups
            pub_TraerIdFolioBulto = objDALAjustes.pub_TraerIdFolioBulto(IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarAparadorLeer(ByVal Serie As String) As DataSet
        'mreyes 28/Octubre/2015 11:11 a.m.
        Try
            'Call the data component to get all groups
            usp_EliminarAparadorLeer = objDALAjustes.usp_EliminarAparadorLeer(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminarDetBulto(ByVal IdFolio As Integer) As DataSet
        'mreyes 28/Octubre/2015 11:11 a.m.
        Try
            'Call the data component to get all groups
            usp_EliminarDetBulto = objDALAjustes.usp_EliminarDetBulto(IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetBulto(ByVal IdFolio As Integer, ByVal Sucursal As String, ByVal Pedido As String) As DataSet
        'mreyes 20/Enero/2012 01:02 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetBulto = objDALAjustes.usp_TraerDetBulto(IdFolio, Sucursal, Pedido)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalBulto(ByVal FolioA As String, ByVal FolioB As String, ByVal Sucursal As String, ByVal Proveedor As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalBulto = objDALAjustes.usp_PpalBulto(FolioA, FolioB, Sucursal, Proveedor, FechaIni, FechaFin)
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
            usp_ActualizaBultos = objDALAjustes.usp_ActualizaBultos(Folio, Sucursal, Proveedor, NoGuia, Transporta, NoBultos, Recibe, _
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

            Return objDALAjustes.usp_Captura_DetBulto(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalAntiJaula(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 22/Febrero/2013 - 06:50 p.m.
        Try
            Return objDALAjustes.usp_PpalAntiJaula(Accion, Opcion, Sucursal)
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
            Return objDALAjustes.usp_PpalAntiJaulaDet(Accion, Opcion, Sucursal, Proveedor, Noguia, Folio, Recibe, Asigna, FechaRecIni, FechaRecFin, FechaAsigIni, FechaAsigFin, DiasIni, DiasFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
