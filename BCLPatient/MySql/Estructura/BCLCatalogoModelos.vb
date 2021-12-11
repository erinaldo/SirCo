Public Class BCLCatalogoModelos

    Implements IDisposable
    Private objDALCatalogoModelos As DAL.DALCatalogoModelos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable 
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoModelos = New DAL.DALCatalogoModelos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoModelos.Dispose()
            objDALCatalogoModelos = Nothing
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


    Public Function usp_Captura_DetSucArt(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Proveedor As String, _
                                          ByVal Estilon As String, ByVal Corrida As String, ByVal Precio As Decimal, ByVal IdUsuario As Integer) As Boolean
        'Tony Garcia - 28/Febrero/2012 - 09:50 a.m.
        Try
            Return objDALCatalogoModelos.usp_Captura_DetSucArt(Opcion, Sucursal, Marca, Proveedor, Estilon, Corrida, Precio, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucMarca(ByVal Marca As String, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 28/Febrero/2013 01:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerSucMarca = objDALCatalogoModelos.usp_TraerSucMarca(Marca, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetSucArt(ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'Tony Garcia - 28/Febrero/2013 01:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetSucArt = objDALCatalogoModelos.usp_TraerDetSucArt(Marca, Proveedor, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEstilosTrackCoqueta(ByVal Marca As String, ByVal Estilon As String, ByVal Estilof As String, ByVal Familia As String, _
                                               ByVal Linea As String, ByVal Proveedor As String, ByVal Categoria As String, ByVal TipoArt As String, _
                                               ByVal Clasificacion As String, ByVal Opcion As String)
        'Tony Garcia - 16/Febrero/2013 - 12:00 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstilosTrackCoqueta = objDALCatalogoModelos.usp_TraerEstilosTrackCoqueta(Marca, Estilon, Estilof, Familia, Linea, Proveedor, _
                                                                                          Categoria, TipoArt, Clasificacion, Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosFamLinea(ByVal Opcion As String, ByVal Sucursales As String, ByVal Sucursal As String, ByVal Marca As String, _
                                                      ByVal Estilon As String, ByVal Estilof As String, ByVal Familia As String, ByVal Linea As String, _
                                                      ByVal Proveedor As String, ByVal Categoria As String, ByVal TipoArt As String, _
                                                      ByVal CostoIni As Decimal, ByVal CostoFin As Decimal, ByVal PrecioIni As Decimal, ByVal PrecioFin As Decimal, _
                                                      ByVal MedidaIni As String, ByVal MedidaFin As String, ByVal Clasificacion As String, _
                                                      ByVal Estatus As String)
        'Tony Garcia - 29/Enero/2013 - 12:35 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerArticulosFamLinea = objDALCatalogoModelos.usp_TraerArticulosFamLinea(Opcion, Sucursales, Sucursal, Marca, Estilon, Estilof, Familia, Linea, Proveedor, _
                                                                                          Categoria, TipoArt, CostoIni, CostoFin, PrecioIni, PrecioFin, _
                                                                                          MedidaIni, MedidaFin, Clasificacion, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosEstructura(ByVal Opcion As String, ByVal Sucursales As String, ByVal Sucursal As String, ByVal Marca As String, _
                                                    ByVal Modelo As String, ByVal Estilof As String, ByVal IdDivision As String, ByVal IdDepto As String, _
                                                    ByVal IdFamilia As String, ByVal IdLinea As String, ByVal IdL1 As String, ByVal IdL2 As String, ByVal IdL3 As String, _
                                                    ByVal IdL4 As String, ByVal IdL5 As String, ByVal IdL6 As String, ByVal Proveedor As String, _
                                                    ByVal CostoIni As Decimal, ByVal CostoFin As Decimal, ByVal PrecioIni As Decimal, ByVal PrecioFin As Decimal, _
                                                    ByVal MedidaIni As String, ByVal MedidaFin As String, ByVal Estatus As String, ByVal FecRecA As String, ByVal FecRecB As String, _
                                                    ByVal Recibido As String, ByVal FecEntA As String, ByVal FecEntB As String, ByVal AgrupacionB As Integer)
        'Tony Garcia - 21/Mayo/2013 - 05:35 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerArticulosEstructura = objDALCatalogoModelos.usp_TraerArticulosEstructura(Opcion, Sucursales, Sucursal, Marca, Modelo, Estilof, IdDivision, IdDepto, IdFamilia, _
                                                                                            IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Proveedor, _
                                                                                          CostoIni, CostoFin, PrecioIni, PrecioFin, MedidaIni, MedidaFin, Estatus, FecRecA, FecRecB, Recibido, FecEntA, FecEntB, AgrupacionB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerExistenciaEstilos2(ByVal Sucursal As String, ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 01/Febrero/2013 - 5:40 p.m.
        Try
            usp_TraerExistenciaEstilos2 = objDALCatalogoModelos.usp_TraerExistenciaEstilos2(Sucursal, Marca, EstiloN, EstiloF)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasModeloSuc(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal FecIni As String, ByVal FecFin As String) As DataSet
        'Tony Garcia - 23/Mayo/2013 - 11:00 a.m.
        Try
            usp_TraerVentasModeloSuc = objDALCatalogoModelos.usp_TraerVentasModeloSuc(Sucursal, Marca, Estilon, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasModeloMed(ByVal Sucursal As String, ByVal IdArticulo As Integer, ByVal FecIni As String, ByVal FecFin As String) As DataSet
        'Tony Garcia - 27/Septiembre/2013 - 07:00 p.m.
        Try
            usp_TraerVentasModeloMed = objDALCatalogoModelos.usp_TraerVentasModeloMed(Sucursal, IdArticulo, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Articulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_Articulo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CorridaMedidas(opcion As Integer, ByVal marca As String, ByVal estilon As String, ByVal corrida As String, ByVal peso As Decimal, ByVal alto As Decimal,
                               ByVal frente As Decimal, ByVal fondo As Decimal, ByVal matsuela As Integer, ByVal matcal As Integer, IdRecibo As Integer) As Boolean
        Try
            'Call the data component to get all groups
            Return objDALCatalogoModelos.usp_Captura_CorridaMedidas(opcion, marca, estilon, corrida, peso, alto, frente, fondo, matsuela, matcal, IdRecibo)
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_EstArticulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_EstArticulo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_ArtFotos(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 26/Marzo/2012 04:37 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_ArtFotos(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CostosxMarca(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Mayo/2012 10:41 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_CostosxMarca(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Corrida(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 09:46 a.m.
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_Corrida(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CambPrec(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 26/Abril/2012 06:25 p.m.
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_CambPrec(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Medida(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2011 12:52 a.m.
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoModelos.usp_Captura_Medida(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Articulo() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Articulo = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Articulo.Tables.Add("Articulo")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilof", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 14
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 70
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("familia", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("linea", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipoart", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("categoria", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripl", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 70
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("acepdevo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("resmin", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("artcat", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usumodartcat", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fummodartcat", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diasinvideal", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_EstArticulo() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_EstArticulo = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_EstArticulo.Tables.Add("estarticulo")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idarticulo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("modelo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilof", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 14
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 70
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripap", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iddivisiones", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iddepto", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfamilia", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idlinea", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl1", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl2", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl3", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl4", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl5", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl6", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("tipoart", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            'objDataColumn.MaxLength = 1
            'objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idestatributo", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripl", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 70
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("artcat", Type.GetType("System.String"))
            'objDataColumn.AllowDBNull = False
            'objDataColumn.MaxLength = 1
            'objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("acepdevo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("resmin", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diasinvideal", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("vigenciaa", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ventaenlinea", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_ArtFotos() As DataSet
        'mreyes 26/Marzo/2012 04:11 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_ArtFotos = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_ArtFotos.Tables.Add("ArtFotos")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fotoart", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_CambPrec() As DataSet
        'mreyes 26/Abril/2012 06:14 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_CambPrec = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_CambPrec.Tables.Add("CambPrec")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cambprec", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nivel", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("mlfp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porcent", Type.GetType("System.Int16"))
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

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Corrida() As DataSet
        Try
            'mreyes 09/Febrero/2012 06:51 p.m.
            'Instantiate a new DataSet object
            Inserta_Corrida = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Corrida.Tables.Add("Corrida")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("idarticulo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
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

            objDataColumn = New DataColumn("iddivisiones", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iddepto", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfamilia", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idlinea", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl1", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl2", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl3", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl4", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl5", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idl6", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("intervalo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medini", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medfin", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costo", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("precio", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ult_cmp", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ult_vta", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("blofer", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipocrr", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            ''objDataColumn = New DataColumn("fechor", Type.GetType("System.DateTime"))
            ''objDataColumn.AllowDBNull = False
            ''objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Medida() As DataSet
        Try
            'mreyes 10/Febrero/2012 06:51 p.m.
            'Instantiate a new DataSet object
            Inserta_Medida = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Medida.Tables.Add("Medida")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idarticulo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
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

            objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctdcri", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctdide", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctdsol", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("orden", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_CostosxMarca() As DataSet
        'mreyes 05/Mayo/2012 10:34 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_CostosxMarca = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_CostosxMarca.Tables.Add("CostosxMarca")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("orden", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("concepto", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porcent", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEstilo(ByVal Marca As String, ByVal Estilon As String, ByVal EstiloF As String, ByVal Familia As String, ByVal Linea As String, ByVal Categoria As String, ByVal TipoArt As String, ByVal Proveedor As String, ByVal Descripc As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerEstilo = objDALCatalogoModelos.usp_TraerEstilo(Marca, Estilon, EstiloF, Familia, Linea, Categoria, TipoArt, Proveedor, Descripc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerModeloCATALOGO(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDepto As Integer, ByVal IdFamilia As String, _
                               ByVal IdLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdSSubLinea As Integer, ByVal DescripC As String, ByVal Proveedor As String, ByVal Corrida As String) As DataSet
        'Tony García - 24/Abril/2013 - 04:50 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerModeloCATALOGO = objDALCatalogoModelos.usp_TraerModeloCATALOGO(IdArticulo, Marca, Modelo, EstiloF, IdDepto, IdFamilia, IdLinea, IdSubLinea, IdSSubLinea, DescripC, Proveedor, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerModelo(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDepto As Integer, ByVal IdFamilia As String, _
                                   ByVal IdLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdSSubLinea As Integer, ByVal DescripC As String) As DataSet
        'Tony García - 24/Abril/2013 - 04:50 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerModelo = objDALCatalogoModelos.usp_TraerModelo(IdArticulo, Marca, Modelo, EstiloF, IdDepto, IdFamilia, IdLinea, IdSubLinea, IdSSubLinea, DescripC)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerModelosMarca(ByVal IdArticulo As Integer, ByVal Marca As String) As DataSet
        'Tony García - 10/Mayo/2013 - 10:10 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerModelosMarca = objDALCatalogoModelos.usp_TraerModelosMarca(IdArticulo, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstructura(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String) As DataSet
        'Tony García - 25/Abril/2013 - 12:10 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstructura = objDALCatalogoModelos.usp_TraerEstructura(IdArticulo, Marca, Modelo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerLetrasIniFin(ByVal OrdenIni As String, ByVal OrdenFin As String, ByVal TipoLet As String) As DataSet
        'mreyes 23/Febrero/2012 01:58 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerLetrasIniFin = objDALCatalogoModelos.usp_TraerLetrasIniFin(OrdenIni, OrdenFin, TipoLet)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCorrida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Proveedor As String) As DataSet
        'mreyes 11/Febrero/2012 10:17 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCorrida = objDALCatalogoModelos.usp_TraerCorrida(Marca, Estilon, Corrida, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarca(ByVal Marca As String, ByVal Descrip As String) As DataSet
        'mreyes 12/Marzo/2012 11:51 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerMarca = objDALCatalogoModelos.usp_TraerMarca(Marca, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostosxMarca(ByVal Marca As String, ByVal Concepto As String) As DataSet
        'mreyes 13/Abril/2012 09:43 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCostosxMarca = objDALCatalogoModelos.usp_TraerCostosxMarca(Marca, Concepto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCostosGrales(ByVal Marca As String) As DataSet
        'mreyes 13/Abril/2012 09:45 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCostosGrales = objDALCatalogoModelos.usp_TraerCostosGrales(Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerClasifMargen() As DataSet
        'mreyes 13/Abril/2012 11:36 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerClasifMargen = objDALCatalogoModelos.usp_TraerClasifMargen()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPorcenDinero(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date) As DataSet
        'mreyes 13/Abril/2012 10:15 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenDinero = objDALCatalogoModelos.usp_TraerPorcenDinero(Marca, Estilon, Corrida, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPorcenBoletin(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date) As DataSet
        'mreyes 13/Abril/2012 10:27 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenBoletin = objDALCatalogoModelos.usp_TraerPorcenBoletin(Marca, Estilon, Corrida, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPorcenBoletinNivel(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date, ByVal Nivel As String) As DataSet
        'mreyes 13/Abril/2012 10:47 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenBoletinNivel = objDALCatalogoModelos.usp_TraerPorcenBoletinNivel(Marca, Estilon, Corrida, Fecha, Nivel)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPorcenDineroNivel(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date, ByVal Nivel As String) As DataSet
        'mreyes 13/Abril/2012 11:04 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenDineroNivel = objDALCatalogoModelos.usp_TraerPorcenDineroNivel(Marca, Estilon, Corrida, Fecha, Nivel)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:49 p.m.
        Try
            'Call the data component to delete the group
            Return objDALCatalogoModelos.usp_EliminarMedida(Marca, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosSinFoto(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 02/Noviembre/2012 05:25 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerArticulosSinFoto = objDALCatalogoModelos.usp_TraerArticulosSinFoto(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCorrida2(ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String) As DataSet
        'mreyes 11/Febrero/2012 10:17 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCorrida2 = objDALCatalogoModelos.usp_TraerCorrida2(Marca, Estilon, Proveedor, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPrecios(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'mreyes 29/Junio/2016   11:33 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPrecios = objDALCatalogoModelos.usp_TraerPrecios(Opcion, Sucursal, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPreciosAnalisisModelo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'mreyes 21/Abril/2016   01:44 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPreciosAnalisisModelo = objDALCatalogoModelos.usp_TraerPreciosAnalisisModelo(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCorridaOferta(ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Sucursal As String) As DataSet
        'mreyes 30/Julio/2014   10:46 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCorridaOferta = objDALCatalogoModelos.usp_TraerCorridaOferta(Marca, Estilon, Proveedor, Corrida, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_DetSucArtMarca(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                         ByVal Proveedor As String, ByVal IdUsuario As Integer) As Boolean
        'Tony Garcia - 07/Marzo/2013 - 01:25 p.m.
        Try
            Return objDALCatalogoModelos.usp_Captura_DetSucArtMarca(Opcion, Sucursal, Marca, Proveedor, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetSucArtMarca(ByVal Marca As String) As DataSet
        'Tony Garcia - 07/Marzo/2013 12:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDetSucArtMarca = objDALCatalogoModelos.usp_TraerDetSucArtMarca(Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAtributosModelo(ByVal IdArticulo As Integer) As DataSet
        'Tony Garcia - 02/MAyo/2013 10:50 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerAtributosModelo = objDALCatalogoModelos.usp_TraerAtributosModelo(IdArticulo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAtributos(ByVal Tipo As String, ByVal Descripcion As String) As DataSet
        'Tony Garcia - 02/MAyo/2013 10:50 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerAtributos = objDALCatalogoModelos.usp_TraerAtributos(Tipo, Descripcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_EstAtributo(ByVal Opcion As Integer, ByVal IdArticulo As Integer) As DataSet
        'Tony Garcia - 02/MAyo/2013 12:50 p.m.
        Try
            'Call the data component to get all groups
            usp_Captura_EstAtributo = objDALCatalogoModelos.usp_Captura_EstAtributo(Opcion, IdArticulo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetEstAtributo(ByVal Opcion As Integer, ByVal IdEstAtrib As Integer, ByVal IdAtributo As Integer) As DataSet
        'Tony Garcia - 02/MAyo/2013 12:50 p.m.
        Try
            'Call the data component to get all groups
            usp_Captura_DetEstAtributo = objDALCatalogoModelos.usp_Captura_DetEstAtributo(Opcion, IdEstAtrib, IdAtributo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstAtributo(ByVal IdArticulo As Integer) As DataSet
        'Tony Garcia - 06/MAyo/2013 12:50 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstAtributo = objDALCatalogoModelos.usp_TraerEstAtributo(IdArticulo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Atributo(ByVal Opcion As Integer, ByVal Descripcion As String, ByVal Tipo As String) As DataSet
        'Tony Garcia - 02/MAyo/2013 12:50 p.m.
        Try
            'Call the data component to get all groups
            usp_Captura_Atributo = objDALCatalogoModelos.usp_Captura_Atributo(Opcion, Descripcion, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstConcepto(ByVal TipoN As String, ByVal ClaveN As String, ByVal TipoAnt As String, ByVal Descrip As String) As DataSet
        'Tony Garcia - 02/MAyo/2013 07:15 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstConcepto = objDALCatalogoModelos.usp_TraerEstConcepto(TipoN, ClaveN, TipoAnt, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdArticulo(ByVal Marca As String, ByVal Modelo As String) As DataSet
        'Tony Garcia - 08/MAyo/2013 12:15 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerIdArticulo = objDALCatalogoModelos.usp_TraerIdArticulo(Marca, Modelo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerModeloSerie(ByVal Serie As String) As DataSet
        'mreyes 12/Octubre/2014 06:26 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerModeloSerie = objDALCatalogoModelos.usp_TraerModeloSerie(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_PpalCatalogoModelos(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, _
    '                                   ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
    '                                   ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
    '                                   ByVal IdL6 As Integer, ByVal Proveedor As String, ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
    '    'Tony García 25/Abril/2013 09:58 a.m.
    '    Try
    '        'Call the data component to get all groups
    '        usp_PpalCatalogoModelos = objDALCatalogoModelos.usp_PpalCatalogoModelos(IdArticulo, Marca, Modelo, EstiloF, IdDivision, _
    '                                                                IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Proveedor, FechaIni, Fechafin)
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_PpalCatalogoModelos(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, _
                                       ByVal IdDivision As String, ByVal IdDepto As String, ByVal IdFamilia As String, ByVal IdLinea As String, _
                                       ByVal IdL1 As String, ByVal IdL2 As String, ByVal IdL3 As String, ByVal IdL4 As String, ByVal IdL5 As String, _
                                       ByVal IdL6 As String, ByVal Proveedor As String, ByVal FechaIni As String, ByVal Fechafin As String, _
                                       ByVal FecReciA As String, ByVal FecReciB As String) As DataSet
        'Tony García 25/Abril/2012 10:00 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalCatalogoModelos = objDALCatalogoModelos.usp_PpalCatalogoModelos(IdArticulo, Marca, Modelo, EstiloF, IdDivision, _
                                                                    IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Proveedor, FechaIni, Fechafin, FecReciA, FecReciB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnalisisModeloSinCeros(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 29/Abril/2016   12:52 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerAnalisisModeloSinCeros = objDALCatalogoModelos.usp_TraerAnalisisModeloSinCeros(Marca, Modelo, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnalisisModeloPlaza(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 27/Mayo/201605:34 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerAnalisisModeloPlaza = objDALCatalogoModelos.usp_TraerAnalisisModeloPlaza(Marca, Modelo, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAnalisisModeloLetras(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 22/Noviembre/2018   04:47 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerAnalisisModeloLetras = objDALCatalogoModelos.usp_TraerAnalisisModeloLetras(Marca, Modelo, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnalisisModelo(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 08/Marzo/2016   06:21 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerAnalisisModelo = objDALCatalogoModelos.usp_TraerAnalisisModelo(Marca, Modelo, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalDet_Serie(ByVal Serie As String) As DataSet
        'mreyes 13/Octubre/2014 09:14 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalDet_Serie = objDALCatalogoModelos.usp_PpalDet_Serie(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstFiltroDescrip(ByVal Opcion As Integer, ByVal Id As Integer) As DataSet
        'Tony Garcia - 21/MAyo/2013 12:15 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerEstFiltroDescrip = objDALCatalogoModelos.usp_TraerEstFiltroDescrip(Opcion, Id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCategoria(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 05/Julio/2013 12:15 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCategoria = objDALCatalogoModelos.usp_TraerCategoria(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarCategoria(ByVal Marca As String, ByVal Estilon As String, ByVal Categoria As String) As Boolean
        'Tony Garcia - 05/Julio/2013 01:15 p.m.
        Try
            Return objDALCatalogoModelos.usp_ActualizarCategoria(Marca, Estilon, Categoria)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPedidoPendienteModelo(ByVal Marca As String, ByVal Estilon As String, ByVal Fecha As DateTime) As DataSet
        'Tony Garcia - 03/Julio/2013 09:15 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPedidoPendienteModelo = objDALCatalogoModelos.usp_TraerPedidoPendienteModelo(Marca, Estilon, Fecha)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaUltVenta(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 23/Septiembre/2013 12:15 p.m.
        Try
            usp_TraerFechaUltVenta = objDALCatalogoModelos.usp_TraerFechaUltVenta(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFechaUltReciboEstilo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 23/Septiembre/2013 01:15 p.m.
        Try
            usp_TraerFechaUltReciboEstilo = objDALCatalogoModelos.usp_TraerFechaUltReciboEstilo(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostoPrecioModelo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 24/Septiembre/2013 10:15 a.m.
        Try
            usp_TraerCostoPrecioModelo = objDALCatalogoModelos.usp_TraerCostoPrecioModelo(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasModeloAnalisis(ByVal Sucursal As String, ByVal IdArticulo As Integer, ByVal FecIni As Date, ByVal FecFin As Date) As DataSet
        'Tony Garcia - 27/Septiembre/2013 - 07:00 p.m.
        Try
            usp_TraerVentasModeloAnalisis = objDALCatalogoModelos.usp_TraerVentasModeloAnalisis(Sucursal, IdArticulo, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
