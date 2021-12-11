Public Class BCLCatalogoEstilosClasif

    Implements IDisposable
    Private objDALCatalogoEstilosClasif As DAL.DALCatalogoEstilosClasif
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoEstilosClasif = New DAL.DALCatalogoEstilosClasif(Constring)

    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoEstilosClasif.Dispose()
            objDALCatalogoEstilosClasif = Nothing
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




    Public Function usp_Captura_Articulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoEstilosClasif.usp_Captura_Articulo(Opcion, Section)
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
            Return objDALCatalogoEstilosClasif.usp_Captura_ArtFotos(Opcion, Section)
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
            Return objDALCatalogoEstilosClasif.usp_Captura_CostosxMarca(Opcion, Section)
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
            Return objDALCatalogoEstilosClasif.usp_Captura_Corrida(Opcion, Section)
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
            Return objDALCatalogoEstilosClasif.usp_Captura_CambPrec(Opcion, Section)
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
            Return objDALCatalogoEstilosClasif.usp_Captura_Medida(Opcion, Section)
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
            usp_TraerEstilo = objDALCatalogoEstilosClasif.usp_TraerEstilo(Marca, Estilon, EstiloF, Familia, Linea, Categoria, TipoArt, Proveedor, Descripc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerLetrasIniFin(ByVal OrdenIni As String, ByVal OrdenFin As String, ByVal TipoLet As String) As DataSet
        'mreyes 23/Febrero/2012 01:58 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerLetrasIniFin = objDALCatalogoEstilosClasif.usp_TraerLetrasIniFin(OrdenIni, OrdenFin, TipoLet)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCorrida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'mreyes 11/Febrero/2012 10:17 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCorrida = objDALCatalogoEstilosClasif.usp_TraerCorrida(Marca, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarca(ByVal Marca As String, ByVal Descrip As String) As DataSet
        'mreyes 12/Marzo/2012 11:51 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerMarca = objDALCatalogoEstilosClasif.usp_TraerMarca(Marca, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostosxMarca(ByVal Marca As String, ByVal Concepto As String) As DataSet
        'mreyes 13/Abril/2012 09:43 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCostosxMarca = objDALCatalogoEstilosClasif.usp_TraerCostosxMarca(Marca, Concepto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCostosGrales(ByVal Marca As String) As DataSet
        'mreyes 13/Abril/2012 09:45 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCostosGrales = objDALCatalogoEstilosClasif.usp_TraerCostosGrales(Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerClasifMargen() As DataSet
        'mreyes 13/Abril/2012 11:36 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerClasifMargen = objDALCatalogoEstilosClasif.usp_TraerClasifMargen()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPorcenDinero(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date) As DataSet
        'mreyes 13/Abril/2012 10:15 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenDinero = objDALCatalogoEstilosClasif.usp_TraerPorcenDinero(Marca, Estilon, Corrida, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPorcenBoletin(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date) As DataSet
        'mreyes 13/Abril/2012 10:27 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenBoletin = objDALCatalogoEstilosClasif.usp_TraerPorcenBoletin(Marca, Estilon, Corrida, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPorcenBoletinNivel(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date, ByVal Nivel As String) As DataSet
        'mreyes 13/Abril/2012 10:47 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenBoletinNivel = objDALCatalogoEstilosClasif.usp_TraerPorcenBoletinNivel(Marca, Estilon, Corrida, Fecha, Nivel)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPorcenDineroNivel(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date, ByVal Nivel As String) As DataSet
        'mreyes 13/Abril/2012 11:04 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPorcenDineroNivel = objDALCatalogoEstilosClasif.usp_TraerPorcenDineroNivel(Marca, Estilon, Corrida, Fecha, Nivel)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:49 p.m.
        Try
            'Call the data component to delete the group
            Return objDALCatalogoEstilosClasif.usp_EliminarMedida(Marca, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosSinFoto(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 02/Noviembre/2012 05:25 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerArticulosSinFoto = objDALCatalogoEstilosClasif.usp_TraerArticulosSinFoto(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerVentasEstilos = objDALCatalogoEstilosClasif.usp_TraerVentasEstilos(Marca, EstiloN, EstiloF)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerComprasEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerComprasEstilos = objDALCatalogoEstilosClasif.usp_TraerComprasEstilos(Marca, EstiloN, EstiloF)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerExistenciaEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerExistenciaEstilos = objDALCatalogoEstilosClasif.usp_TraerExistenciaEstilos(Marca, EstiloN, EstiloF)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPPEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerPPEstilos = objDALCatalogoEstilosClasif.usp_TraerPPEstilos(Marca, EstiloN, EstiloF)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimasComprasEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerUltimasComprasEstilos = objDALCatalogoEstilosClasif.usp_TraerUltimasComprasEstilos(Marca, EstiloN, EstiloF)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEstiloN(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 10:40 a.m.
        Try
            usp_TraerEstiloN = objDALCatalogoEstilosClasif.usp_TraerEstiloN(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClasificacionEstiloUp(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 10:40 a.m.
        Try
            usp_TraerClasificacionEstiloUp = objDALCatalogoEstilosClasif.usp_TraerClasificacionEstiloUp(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClasificacionEst(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 01:18 p.m.
        Try
            usp_TraerClasificacionEst = objDALCatalogoEstilosClasif.usp_TraerClasificacionEst(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
