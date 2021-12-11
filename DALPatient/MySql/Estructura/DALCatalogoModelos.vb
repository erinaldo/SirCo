Imports System.Data.Odbc


Public Class DALCatalogoModelos
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


    Public Function usp_TraerDetSucArt(ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'Tony Garcia - 28/Febrero/2013 01:22 p.m.
        Try
            usp_TraerDetSucArt = New DataSet
            MyBase.SQL = "CALL usp_TraerDetSucArt(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridaB", OdbcType.Char, 1, Corrida)

            MyBase.FillDataSet(usp_TraerDetSucArt, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucMarca(ByVal Marca As String, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 28/Febrero/2013 01:22 p.m.
        Try
            usp_TraerSucMarca = New DataSet
            MyBase.SQL = "CALL usp_TraerSucMarca(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)


            MyBase.FillDataSet(usp_TraerSucMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetSucArtMarca(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String,
                                         ByVal Proveedor As String, ByVal IdUsuario As Integer) As Boolean
        'Tony Garcia - 07/Marzo/2012 - 01:25 p.m.
        Try

            MyBase.SQL = "CALL usp_Captura_DetSucArtMarca(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@usuarioB", OdbcType.Char, 8, IdUsuario)

            usp_Captura_DetSucArtMarca = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CorridaMedidas(opcion As Integer, ByVal marca As String, ByVal estilon As String, ByVal corrida As String,
                                               ByVal peso As Decimal, ByVal alto As Decimal,
                               ByVal frente As Decimal, ByVal fondo As Decimal, ByVal matsuela As Integer, ByVal matcal As Integer,
                                               idrecibo As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_CorridaMedidas(?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 8, opcion)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, marca)
            MyBase.AddParameter("@estilonb", OdbcType.Char, 7, estilon)
            MyBase.AddParameter("@corridab", OdbcType.Char, 1, corrida)
            MyBase.AddParameter("@pesob", OdbcType.Decimal, 8, peso)
            MyBase.AddParameter("@altob", OdbcType.Decimal, 8, alto)
            MyBase.AddParameter("@frenteb", OdbcType.Decimal, 8, frente)
            MyBase.AddParameter("@fondob", OdbcType.Decimal, 8, fondo)
            MyBase.AddParameter("@masuelab", OdbcType.Int, 8, matsuela)
            MyBase.AddParameter("@macalzab", OdbcType.Int, 8, matcal)
            MyBase.AddParameter("@idrecibob", OdbcType.Int, 8, idrecibo)

            usp_Captura_CorridaMedidas = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_TraerDetSucArtMarca(ByVal Marca As String) As DataSet
        'Tony Garcia - 07/Marzo/2013 12:22 p.m.
        Try
            usp_TraerDetSucArtMarca = New DataSet
            MyBase.SQL = "CALL usp_TraerDetSucArtMarca(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerDetSucArtMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetSucArt(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Proveedor As String, _
                                          ByVal Estilon As String, ByVal Corrida As String, ByVal Precio As Decimal, ByVal IdUsuario As Integer) As Boolean
        'Tony Garcia - 28/Febrero/2012 - 09:50 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_DetSucArt(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@precioB", OdbcType.Double, 9, Precio)
            MyBase.AddParameter("@usuarioB", OdbcType.Char, 8, IdUsuario)

            usp_Captura_DetSucArt = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Articulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_Articulo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@estilof", OdbcType.Char, 14, Section.Tables(0).Rows(0).Item("estilof"))
            MyBase.AddParameter("@descripc", OdbcType.Char, 70, Section.Tables(0).Rows(0).Item("descripc"))
            MyBase.AddParameter("@familia", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("familia"))
            MyBase.AddParameter("@linea", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("linea"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipoart"))
            MyBase.AddParameter("@categoria", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("categoria"))
            MyBase.AddParameter("@descripl", OdbcType.Char, 70, Section.Tables(0).Rows(0).Item("descripl"))
            MyBase.AddParameter("@medida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@acepdevo", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("acepdevo"))
            MyBase.AddParameter("@fecha", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@hora", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))
            MyBase.AddParameter("@resmin", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("resmin"))
            MyBase.AddParameter("@artcat", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("artcat"))
            MyBase.AddParameter("@usumodartcat", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodartcat"))
            MyBase.AddParameter("@fummodartcat", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodartcat"))

            MyBase.AddParameter("@diasinvideal", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("diasinvideal"))

            usp_Captura_Articulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_EstArticulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_EstArticulo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idarticulob", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@modelob", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("modelo"))
            MyBase.AddParameter("@estilof", OdbcType.Char, 14, Section.Tables(0).Rows(0).Item("estilof"))
            MyBase.AddParameter("@descripcb", OdbcType.Char, 70, Section.Tables(0).Rows(0).Item("descripc"))
            MyBase.AddParameter("@descripapb", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("descripap"))
            MyBase.AddParameter("@iddivisionesb", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("iddivisiones"))
            MyBase.AddParameter("@iddeptob", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@idfamiliab", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idfamilia"))
            MyBase.AddParameter("@idlineab", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idlinea"))
            MyBase.AddParameter("@idl1b", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idl1"))
            MyBase.AddParameter("@idl2b", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idl2"))
            MyBase.AddParameter("@idl3b", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idl3"))
            MyBase.AddParameter("@idl4b", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idl4"))
            MyBase.AddParameter("@idl5b", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idl5"))
            MyBase.AddParameter("@idl6b", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idl6"))
            MyBase.AddParameter("@proveedorb", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@idestatribb", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idestatributo"))
            MyBase.AddParameter("@descripl", OdbcType.Char, 70, Section.Tables(0).Rows(0).Item("descripl"))
            MyBase.AddParameter("@medidab", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@acepdevo", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("acepdevo"))
            MyBase.AddParameter("@fecha", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@hora", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))
            MyBase.AddParameter("@resmin", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("resmin"))
            MyBase.AddParameter("@diasinvideal", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("diasinvideal"))
            MyBase.AddParameter("@vigenciaa", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("vigenciaa"))
            MyBase.AddParameter("@ventaenlinea", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("ventaenlinea"))

            usp_Captura_EstArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_CostosxMarca(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Mayo/2012 10:40 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_CostosxMarca(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@orden", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("orden"))
            MyBase.AddParameter("@concepto", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("concepto"))
            MyBase.AddParameter("@porcent", OdbcType.Decimal, 6, Section.Tables(0).Rows(0).Item("porcent"))


            usp_Captura_CostosxMarca = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_ArtFotos(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 26/Marzo/2012 04:38 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_ArtFotos(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@fotoart", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("fotoart"))
            MyBase.AddParameter("@fecha", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@hora", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))



            usp_Captura_ArtFotos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Corrida(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 09:49 a.m.
            MyBase.SQL = "CALL usp_Captura_Corrida(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idarticulo", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@iddivisiones", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("iddivisiones"))
            MyBase.AddParameter("@iddepto", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@idfamilia", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idfamilia"))
            MyBase.AddParameter("@idlinea", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idlinea"))
            MyBase.AddParameter("@idl1", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idl1"))
            MyBase.AddParameter("@idl2", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idl2"))
            MyBase.AddParameter("@idl3", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idl3"))
            MyBase.AddParameter("@idl4", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idl4"))
            MyBase.AddParameter("@idl5", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idl5"))
            MyBase.AddParameter("@idl6", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idl6"))
            MyBase.AddParameter("@intervalo", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("intervalo"))
            MyBase.AddParameter("@medini", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medini"))
            MyBase.AddParameter("@medfin", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medfin"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))
            MyBase.AddParameter("@precio", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precio"))
            MyBase.AddParameter("@ult_cmp", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ult_cmp"))
            MyBase.AddParameter("@ult_vta", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ult_vta"))
            MyBase.AddParameter("@blofer", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("blofer"))
            MyBase.AddParameter("@tipocrr", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipocrr"))
            ''  MyBase.AddParameter("@fechor", OdbcType.Timestamp, 14, Section.Tables(0).Rows(0).Item("fechor"))


            usp_Captura_Corrida = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_CambPrec(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 26/Abril/2012 06:27 a.m.
            MyBase.SQL = "CALL usp_Captura_CambPrec(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@intervalo", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("intervalo"))
            MyBase.AddParameter("@medini", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medini"))
            MyBase.AddParameter("@medfin", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medfin"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))
            MyBase.AddParameter("@precio", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precio"))
            MyBase.AddParameter("@ult_cmp", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ult_cmp"))
            MyBase.AddParameter("@ult_vta", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ult_vta"))
            MyBase.AddParameter("@blofer", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("blofer"))
            MyBase.AddParameter("@tipocrr", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipocrr"))
            ''  MyBase.AddParameter("@fechor", OdbcType.Timestamp, 14, Section.Tables(0).Rows(0).Item("fechor"))


            usp_Captura_CambPrec = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Medida(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 13:09 p.m.
            MyBase.SQL = "CALL usp_Captura_Medida(?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idarticulo", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idarticulo"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@ctdcri", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("ctdcri"))
            MyBase.AddParameter("@ctdide", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("ctdide"))
            MyBase.AddParameter("@ctdsol", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("ctdsol"))
            MyBase.AddParameter("@orden", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("orden"))



            usp_Captura_Medida = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstilo(ByVal Marca As String, ByVal Estilon As String, ByVal EstiloF As String, ByVal Familia As String, ByVal Linea As String, ByVal Categoria As String, ByVal TipoArt As String, ByVal Proveedor As String, ByVal DescripC As String) As DataSet
        Try
            usp_TraerEstilo = New DataSet
            MyBase.SQL = "CALL usp_TraerEstilo(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, IIf(IsNothing(Estilon) = True, "", Estilon))
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@FamiliaB", OdbcType.Char, 3, IIf(IsNothing(Familia) = True, "", Familia))
            MyBase.AddParameter("@LineaB", OdbcType.Char, 3, IIf(IsNothing(Linea) = True, "", Linea))
            MyBase.AddParameter("@CategoriaB", OdbcType.Char, 3, IIf(IsNothing(Categoria) = True, "", Categoria))
            MyBase.AddParameter("@TipoArtB", OdbcType.Char, 1, IIf(IsNothing(TipoArt) = True, "", TipoArt))
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, IIf(IsNothing(Proveedor) = True, "", Proveedor))
            MyBase.AddParameter("@DescripcB", OdbcType.Char, 3, IIf(IsNothing(DescripC) = True, "", DescripC))

            MyBase.FillDataSet(usp_TraerEstilo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerModeloCATALOGO(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDepto As Integer, ByVal IdFamilia As String, _
                                ByVal IdLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdSSubLinea As Integer, ByVal DescripC As String, ByVal Proveedor As String, ByVal Corrida As String) As DataSet
        'Tony García - 24/Abril/2013 - 04:50 p.m.
        Try
            usp_TraerModeloCATALOGO = New DataSet
            MyBase.SQL = "CALL usp_TraerModeloCATALOGO(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idarticuloB", OdbcType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, IIf(IsNothing(Modelo) = True, "", Modelo))
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@iddeptoB", OdbcType.Int, 16, IIf(IsNothing(IdDepto) = True, "", IdDepto))
            MyBase.AddParameter("@idfamiliaB", OdbcType.Int, 16, IIf(IsNothing(IdFamilia) = True, "", IdFamilia))
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, IIf(IsNothing(IdLinea) = True, "", IdLinea))
            MyBase.AddParameter("@idSubLineaB", OdbcType.Int, 16, IIf(IsNothing(IdSubLinea) = True, "", IdSubLinea))
            MyBase.AddParameter("@idSSubLineaB", OdbcType.Int, 16, IIf(IsNothing(IdSSubLinea) = True, "", IdSSubLinea))
            MyBase.AddParameter("@DescripcB", OdbcType.Char, 3, IIf(IsNothing(DescripC) = True, "", DescripC))
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, IIf(IsNothing(Proveedor) = True, "", Proveedor))
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, IIf(IsNothing(Corrida) = True, "", Corrida))

            MyBase.FillDataSet(usp_TraerModeloCATALOGO, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerModelo(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDepto As Integer, ByVal IdFamilia As String, _
                                    ByVal IdLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdSSubLinea As Integer, ByVal DescripC As String) As DataSet
        'Tony García - 24/Abril/2013 - 04:50 p.m.
        Try
            usp_TraerModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerModelo(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idarticuloB", OdbcType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, IIf(IsNothing(Modelo) = True, "", Modelo))
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@iddeptoB", OdbcType.Int, 16, IIf(IsNothing(IdDepto) = True, "", IdDepto))
            MyBase.AddParameter("@idfamiliaB", OdbcType.Int, 16, IIf(IsNothing(IdFamilia) = True, "", IdFamilia))
            MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, IIf(IsNothing(IdLinea) = True, "", IdLinea))
            MyBase.AddParameter("@idSubLineaB", OdbcType.Int, 16, IIf(IsNothing(IdSubLinea) = True, "", IdSubLinea))
            MyBase.AddParameter("@idSSubLineaB", OdbcType.Int, 16, IIf(IsNothing(IdSSubLinea) = True, "", IdSSubLinea))
            MyBase.AddParameter("@DescripcB", OdbcType.Char, 3, IIf(IsNothing(DescripC) = True, "", DescripC))


            MyBase.FillDataSet(usp_TraerModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerModelosMarca(ByVal IdArticulo As Integer, ByVal Marca As String) As DataSet
        'Tony García - 10/Mayo/2013 - 10:10 a.m.
        Try
            usp_TraerModelosMarca = New DataSet
            MyBase.SQL = "CALL usp_TraerModelosMarca(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idarticuloB", OdbcType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerModelosMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstructura(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String) As DataSet
        'Tony García - 25/Abril/2013 - 12:10 p.m.
        Try
            usp_TraerEstructura = New DataSet
            MyBase.SQL = "CALL usp_TraerEstructura(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idarticuloB", OdbcType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, IIf(IsNothing(Modelo) = True, "", Modelo))


            MyBase.FillDataSet(usp_TraerEstructura, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerLetrasIniFin(ByVal OrdenIni As String, ByVal OrdenFin As String, ByVal TipoLet As String) As DataSet
        'mreyes 23/Febrero/2012 02:01 p.m.
        Try
            usp_TraerLetrasIniFin = New DataSet
            MyBase.SQL = "CALL usp_TraerLetrasIniFin(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@OrdenINIb", OdbcType.Char, 2, OrdenIni)
            MyBase.AddParameter("@OrdenFINb", OdbcType.Char, 2, OrdenFin)
            MyBase.AddParameter("@TipoLetb", OdbcType.Char, 2, TipoLet)
            MyBase.FillDataSet(usp_TraerLetrasIniFin, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCorrida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Proveedor As String) As DataSet
        Try
            usp_TraerCorrida = New DataSet
            MyBase.SQL = "CALL usp_TraerCorrida(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerCorrida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarca(ByVal Marca As String, ByVal Descrip As String) As DataSet
        'mreyes 12/Marzo/2012 11:51 a.m.
        Try
            usp_TraerMarca = New DataSet
            MyBase.SQL = "CALL usp_TraerMarca(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@DescripB", OdbcType.Char, 30, Descrip)

            MyBase.FillDataSet(usp_TraerMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostosxMarca(ByVal Marca As String, ByVal Concepto As String) As DataSet
        'mreyes 13/Febrero/2012 09:44 a.m.
        Try
            usp_TraerCostosxMarca = New DataSet
            MyBase.SQL = "CALL usp_TraerCostosxMarca(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ConceptoB", OdbcType.Char, 20, Concepto)

            MyBase.FillDataSet(usp_TraerCostosxMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostosGrales(ByVal Marca As String) As DataSet
        'mreyes 13/Febrero/2012 09:45 a.m.
        Try
            usp_TraerCostosGrales = New DataSet
            MyBase.SQL = "CALL usp_TraerCostosGrales(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerCostosGrales, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClasifMargen() As DataSet
        'mreyes 13/Febrero/2012 11:37 a.m.
        Try
            usp_TraerClasifMargen = New DataSet
            MyBase.SQL = "CALL usp_TraerClasifMargen()"

            MyBase.InitializeCommand()


            MyBase.FillDataSet(usp_TraerClasifMargen, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPorcenDinero(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date) As DataSet
        'mreyes 13/Febrero/2012 09:45 a.m.
        Try
            usp_TraerPorcenDinero = New DataSet
            MyBase.SQL = "CALL usp_TraerPorcenDinero(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 8, Fecha)


            MyBase.FillDataSet(usp_TraerPorcenDinero, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPorcenBoletin(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date) As DataSet
        'mreyes 13/Febrero/2012 09:45 a.m.
        Try
            usp_TraerPorcenBoletin = New DataSet
            MyBase.SQL = "CALL usp_TraerPorcenBoletin(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 8, Fecha)


            MyBase.FillDataSet(usp_TraerPorcenBoletin, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPorcenBoletinNivel(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date, ByVal Nivel As String) As DataSet
        'mreyes 13/Febrero/2012 10:48 a.m.
        Try
            usp_TraerPorcenBoletinNivel = New DataSet
            MyBase.SQL = "CALL usp_TraerPorcenBoletinNivel(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@NivelB", OdbcType.Char, 1, Nivel)


            MyBase.FillDataSet(usp_TraerPorcenBoletinNivel, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPorcenDineroNivel(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Fecha As Date, ByVal Nivel As String) As DataSet
        'mreyes 13/Febrero/2012 10:48 a.m.
        Try
            usp_TraerPorcenDineroNivel = New DataSet
            MyBase.SQL = "CALL usp_TraerPorcenDineroNivel(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@FechaB", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@NivelB", OdbcType.Char, 1, Nivel)


            MyBase.FillDataSet(usp_TraerPorcenDineroNivel, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:54 p.m.
        Try
            MyBase.SQL = "CALL usp_EliminarMedida(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 1, Corrida)
            'Execute the stored procedure
            usp_EliminarMedida = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosSinFoto(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'miguel pérez 02/Noviembre/2012 05:22 p.m.
        Try
            usp_TraerArticulosSinFoto = New DataSet
            MyBase.SQL = "CALL usp_TraerArticulosSinFoto(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 8, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 8, FechaFin)

            MyBase.FillDataSet(usp_TraerArticulosSinFoto, "cipsis")
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
            usp_TraerArticulosFamLinea = New DataSet
            MyBase.SQL = "CALL usp_TraerArticulosFamLinea(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)
            MyBase.AddParameter("@sucursalesB", OdbcType.Char, 40, Sucursales)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@estilofB", OdbcType.Char, 14, Estilof)
            MyBase.AddParameter("@familiaB", OdbcType.Char, 3, Familia)
            MyBase.AddParameter("@lineaB", OdbcType.Char, 3, Linea)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@categoriaB", OdbcType.Char, 3, Categoria)
            MyBase.AddParameter("@tipoartB", OdbcType.Char, 1, TipoArt)
            MyBase.AddParameter("@costoiniB", OdbcType.Decimal, 9, CostoIni)
            MyBase.AddParameter("@costofinB", OdbcType.Decimal, 9, CostoFin)
            MyBase.AddParameter("@precioiniB", OdbcType.Decimal, 9, PrecioIni)
            MyBase.AddParameter("@preciofinB", OdbcType.Decimal, 9, PrecioFin)
            MyBase.AddParameter("@medidainiB", OdbcType.Char, 3, MedidaIni)
            MyBase.AddParameter("@medidafinB", OdbcType.Char, 3, MedidaFin)
            MyBase.AddParameter("@clasifB", OdbcType.Char, 250, Clasificacion)
            MyBase.AddParameter("@statusB", OdbcType.Char, 1, Estatus)

            MyBase.FillDataSet(usp_TraerArticulosFamLinea, "cipsis")
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
            usp_TraerArticulosEstructura = New DataSet
            MyBase.SQL = "CALL usp_TraerArticulosEstructura(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)
            MyBase.AddParameter("@sucursalesB", OdbcType.Char, 40, Sucursales)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@estilofB", OdbcType.Char, 14, Estilof)
            MyBase.AddParameter("@iddivisionb", OdbcType.Char, 30, IdDivision)
            MyBase.AddParameter("@iddeptob", OdbcType.Char, 30, IdDepto)
            MyBase.AddParameter("@idfamiliaB", OdbcType.Char, 30, IdFamilia)
            MyBase.AddParameter("@idlineaB", OdbcType.Char, 30, IdLinea)
            MyBase.AddParameter("@idl1B", OdbcType.Char, 30, IdL1)
            MyBase.AddParameter("@idl2B", OdbcType.Char, 30, IdL2)
            MyBase.AddParameter("@idl3B", OdbcType.Char, 30, IdL3)
            MyBase.AddParameter("@idl4B", OdbcType.Char, 30, IdL4)
            MyBase.AddParameter("@idl5B", OdbcType.Char, 30, IdL5)
            MyBase.AddParameter("@idl6B", OdbcType.Char, 30, IdL6)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@costoiniB", OdbcType.Decimal, 9, CostoIni)
            MyBase.AddParameter("@costofinB", OdbcType.Decimal, 9, CostoFin)
            MyBase.AddParameter("@precioiniB", OdbcType.Decimal, 9, PrecioIni)
            MyBase.AddParameter("@preciofinB", OdbcType.Decimal, 9, PrecioFin)
            MyBase.AddParameter("@medidainiB", OdbcType.Char, 3, MedidaIni)
            MyBase.AddParameter("@medidafinB", OdbcType.Char, 3, MedidaFin)
            MyBase.AddParameter("@statusB", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecRecA)
            MyBase.AddParameter("@FecREcB", OdbcType.Char, 10, FecRecB)
            MyBase.AddParameter("@RecibidoB", OdbcType.Char, 10, Recibido)
            MyBase.AddParameter("@FecEntA", OdbcType.Char, 10, FecEntA)
            MyBase.AddParameter("@FecEntB", OdbcType.Char, 10, FecEntB)
            MyBase.AddParameter("@AGrupacionB", OdbcType.Int, 6, AgrupacionB)

            MyBase.FillDataSet(usp_TraerArticulosEstructura, "cipsis")
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
            usp_TraerEstilosTrackCoqueta = New DataSet
            MyBase.SQL = "CALL usp_TraerEstilosTrackCoqueta(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@estilofB", OdbcType.Char, 14, Estilof)
            MyBase.AddParameter("@familiaB", OdbcType.Char, 3, Familia)
            MyBase.AddParameter("@lineaB", OdbcType.Char, 3, Linea)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@categoriaB", OdbcType.Char, 3, Categoria)
            MyBase.AddParameter("@tipoartB", OdbcType.Char, 1, TipoArt)
            MyBase.AddParameter("@clasifB", OdbcType.Char, 250, Clasificacion)
            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)

            MyBase.FillDataSet(usp_TraerEstilosTrackCoqueta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerExistenciaEstilos2(ByVal Sucursal As String, ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 01/Febrero/2013 - 4:40 p.m.
        Try
            usp_TraerExistenciaEstilos2 = New DataSet
            MyBase.SQL = "CALL usp_TraerExistenciaEstilos2(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerExistenciaEstilos2, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasModeloSuc(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal FecIni As String, ByVal FecFin As String) As DataSet
        'Tony Garcia - 23/Mayo/2013 - 11:00 a.m.
        Try
            usp_TraerVentasModeloSuc = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasModeloSuc(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcab", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@fecini", OdbcType.Char, 8, FecIni)
            MyBase.AddParameter("@fecfin", OdbcType.Char, 8, FecFin)

            MyBase.FillDataSet(usp_TraerVentasModeloSuc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerVentasModeloMed(ByVal Sucursal As String, ByVal IdArticulo As Integer, ByVal FecIni As String, ByVal FecFin As String) As DataSet
        'Tony Garcia - 27/Septiembre/2013 - 07:00 p.m.
        Try
            usp_TraerVentasModeloMed = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasModeloMed(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcab", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcab", OdbcType.Int, 8, IdArticulo)
            MyBase.AddParameter("@fecini", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@fecfin", OdbcType.Char, 10, FecFin)

            MyBase.FillDataSet(usp_TraerVentasModeloMed, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCorrida2(ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String) As DataSet
        Try
            usp_TraerCorrida2 = New DataSet
            MyBase.SQL = "CALL usp_TraerCorrida2(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)

            MyBase.FillDataSet(usp_TraerCorrida2, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPrecios(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        Try
            'mreyes 29/Junio/2016   11:34 a.m.

            usp_TraerPrecios = New DataSet
            MyBase.SQL = "CALL usp_TraerPrecios(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 6, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)


            MyBase.FillDataSet(usp_TraerPrecios, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPreciosAnalisisModelo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        Try
            'mreyes 21/Abril/2016   04:28 p.m.

            usp_TraerPreciosAnalisisModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerPreciosAnalisisModelo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)


            MyBase.FillDataSet(usp_TraerPreciosAnalisisModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCorridaOferta(ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Corrida As String, ByVal Sucursal As String) As DataSet
        Try
            'mreyes 30/Julio/2014   10:48 a.m.

            usp_TraerCorridaOferta = New DataSet
            MyBase.SQL = "CALL usp_TraerCorridaOferta(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerCorridaOferta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerAtributosModelo(ByVal IdArticulo As Integer) As DataSet
        'Tony Garcia - 02/MAyo/2013 10:50 a.m.
        Try
            usp_TraerAtributosModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerAtributosModelo(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idarticuloB", OdbcType.Int, 10, IdArticulo)

            MyBase.FillDataSet(usp_TraerAtributosModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAtributos(ByVal Tipo As String, ByVal Descripcion As String) As DataSet
        'Tony Garcia - 02/MAyo/2013 10:50 a.m.
        Try
            usp_TraerAtributos = New DataSet
            MyBase.SQL = "CALL usp_TraerAtributos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@tipob", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@descripb", OdbcType.Char, 70, Descripcion)

            MyBase.FillDataSet(usp_TraerAtributos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Captura_EstAtributo(ByVal Opcion As Integer, ByVal IdArticulo As Integer) As DataSet
        'Tony Garcia - 02/MAyo/2013 12:50 p.m.
        Try
            usp_Captura_EstAtributo = New DataSet
            MyBase.SQL = "CALL usp_Captura_EstAtributo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 10, Opcion)
            MyBase.AddParameter("@Idarticulob", OdbcType.Int, 10, IdArticulo)

            MyBase.FillDataSet(usp_Captura_EstAtributo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DetEstAtributo(ByVal Opcion As Integer, ByVal IdEstAtrib As Integer, ByVal IdAtributo As Integer) As DataSet
        'Tony Garcia - 06/MAyo/2013 12:55 p.m.
        Try
            usp_Captura_DetEstAtributo = New DataSet
            MyBase.SQL = "CALL usp_Captura_DetEstAtributo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 10, Opcion)
            MyBase.AddParameter("@IdEstAtribb", OdbcType.Int, 10, IdEstAtrib)
            MyBase.AddParameter("@IdAtributob", OdbcType.Int, 10, IdAtributo)

            MyBase.FillDataSet(usp_Captura_DetEstAtributo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEstAtributo(ByVal IdArticulo As Integer) As DataSet
        'Tony Garcia - 06/MAyo/2013 12:50 p.m.
        Try
            usp_TraerEstAtributo = New DataSet
            MyBase.SQL = "CALL usp_TraerEstAtributo(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idarticulob", OdbcType.Int, 10, IdArticulo)

            MyBase.FillDataSet(usp_TraerEstAtributo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Atributo(ByVal Opcion As Integer, ByVal Descripcion As String, ByVal Tipo As String) As DataSet
        'Tony Garcia - 02/MAyo/2013 12:50 p.m.
        Try
            usp_Captura_Atributo = New DataSet
            MyBase.SQL = "CALL usp_Captura_Atributo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 10, Opcion)
            MyBase.AddParameter("@descripb", OdbcType.Char, 70, Descripcion)
            MyBase.AddParameter("@tipob", OdbcType.Char, 1, Tipo)

            MyBase.FillDataSet(usp_Captura_Atributo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstConcepto(ByVal TipoN As String, ByVal ClaveN As String, ByVal TipoAnt As String, ByVal Descrip As String) As DataSet
        'Tony Garcia - 02/MAyo/2013 07:15 p.m.
        Try
            usp_TraerEstConcepto = New DataSet
            MyBase.SQL = "CALL usp_TraerEstConcepto(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@tiponb", OdbcType.Char, 3, TipoN)
            MyBase.AddParameter("@cvenb", OdbcType.Char, 3, ClaveN)
            MyBase.AddParameter("@tipoantb", OdbcType.Char, 1, TipoAnt)
            MyBase.AddParameter("@descripb", OdbcType.Char, 30, Descrip)

            MyBase.FillDataSet(usp_TraerEstConcepto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerModeloSerie(ByVal Serie As String) As DataSet
        'mreyes 12/Octubre/2014 06:28 p.m.
        Try
            usp_TraerModeloSerie = New DataSet
            MyBase.SQL = "CALL usp_TraerModeloSerie(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)


            MyBase.FillDataSet(usp_TraerModeloSerie, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdArticulo(ByVal Marca As String, ByVal Modelo As String) As DataSet
        'Tony Garcia - 08/MAyo/2013 12:15 p.m.
        Try


            usp_TraerIdArticulo = New DataSet
            MyBase.SQL = "CALL usp_TraerIdArticulo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@modeloB", OdbcType.Char, 7, Modelo)

            MyBase.FillDataSet(usp_TraerIdArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_PpalCatalogoModelos(ByVal IdArticulo As Integer, ByVal Marca As String, ByVal Modelo As String, ByVal EstiloF As String, _
    '                                   ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
    '                                   ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
    '                                   ByVal IdL6 As Integer, ByVal Proveedor As String, ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
    '    'Tony García 25/Abril/2012 10:00 a.m.


    '    Try
    '        usp_PpalCatalogoModelos = New DataSet
    '        MyBase.SQL = "CALL usp_PpalCatalogoModelos(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

    '        MyBase.InitializeCommand()

    '        MyBase.AddParameter("@IdArticuloB", OdbcType.Int, 16, IdArticulo)
    '        MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
    '        MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
    '        MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
    '        MyBase.AddParameter("@idDivisionb", OdbcType.Int, 16, IdDivision)
    '        MyBase.AddParameter("@idDeptob", OdbcType.Int, 16, IdDepto)
    '        MyBase.AddParameter("@FamiliaB", OdbcType.Int, 16, IdFamilia)
    '        MyBase.AddParameter("@idLineaB", OdbcType.Int, 16, IdLinea)
    '        MyBase.AddParameter("@idL1B", OdbcType.Int, 16, IdL1)
    '        MyBase.AddParameter("@idL2B", OdbcType.Int, 16, IdL2)
    '        MyBase.AddParameter("@idL3B", OdbcType.Int, 16, IdL3)
    '        MyBase.AddParameter("@idL4B", OdbcType.Int, 16, IdL4)
    '        MyBase.AddParameter("@idL5B", OdbcType.Int, 16, IdL5)
    '        MyBase.AddParameter("@idL6B", OdbcType.Int, 16, IdL6)
    '        MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
    '        MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
    '        MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)


    '        MyBase.FillDataSet(usp_PpalCatalogoModelos, "cipsis")
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
            usp_PpalCatalogoModelos = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoModelos(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdArticuloB", OdbcType.Int, 16, IdArticulo)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@idDivisionb", OdbcType.Char, 30, IdDivision)
            MyBase.AddParameter("@idDeptob", OdbcType.Char, 30, IdDepto)
            MyBase.AddParameter("@FamiliaB", OdbcType.Char, 30, IdFamilia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, IdLinea)
            MyBase.AddParameter("@idL1B", OdbcType.Char, 30, IdL1)
            MyBase.AddParameter("@idL2B", OdbcType.Char, 30, IdL2)
            MyBase.AddParameter("@idL3B", OdbcType.Char, 30, IdL3)
            MyBase.AddParameter("@idL4B", OdbcType.Char, 30, IdL4)
            MyBase.AddParameter("@idL5B", OdbcType.Char, 30, IdL5)
            MyBase.AddParameter("@idL6B", OdbcType.Char, 30, IdL6)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)
            MyBase.AddParameter("@FecRecA", OdbcType.Char, 10, FecReciA)
            MyBase.AddParameter("@FecRecB", OdbcType.Char, 10, FecReciB)


            MyBase.FillDataSet(usp_PpalCatalogoModelos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnalisisModeloSinCeros(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 29/Abril/2016   12:53 p.m.


        Try
            usp_TraerAnalisisModeloSinCeros = New DataSet
            MyBase.SQL = "CALL usp_TraerAnalisisModeloSinCeros(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, FechaFin)



            MyBase.FillDataSet(usp_TraerAnalisisModeloSinCeros, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnalisisModeloPlaza(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 27/Mayo/2016   05:37 p.m.


        Try
            usp_TraerAnalisisModeloPlaza = New DataSet
            MyBase.SQL = "CALL usp_TraerAnalisisModeloPlaza(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, FechaFin)



            MyBase.FillDataSet(usp_TraerAnalisisModeloPlaza, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnalisisModelo(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 08/Marzo/2016   06:22 p.m.


        Try
            usp_TraerAnalisisModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerAnalisisModelo(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, FechaFin)



            MyBase.FillDataSet(usp_TraerAnalisisModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerAnalisisModeloLetras(ByVal Marca As String, ByVal Modelo As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 22/Noviembre/2018   04:48 p.m.


        Try
            usp_TraerAnalisisModeloLetras = New DataSet
            MyBase.SQL = "CALL usp_TraerAnalisisModeloLetras(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, FechaFin)



            MyBase.FillDataSet(usp_TraerAnalisisModeloLetras, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDet_Serie(ByVal Serie As String) As DataSet
        'mreyes 13/Octubre/2014 09:15 a.m.


        Try
            usp_PpalDet_Serie = New DataSet
            MyBase.SQL = "CALL usp_PpalDet_Serie(?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 13, Serie)


            MyBase.FillDataSet(usp_PpalDet_Serie, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstFiltroDescrip(ByVal Opcion As Integer, ByVal Id As Integer) As DataSet
        'Tony Garcia - 21/MAyo/2013 12:15 p.m.
        Try
            usp_TraerEstFiltroDescrip = New DataSet
            MyBase.SQL = "CALL usp_TraerEstFiltroDescrip(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 10, Opcion)
            MyBase.AddParameter("@IdB", OdbcType.Int, 10, Id)

            MyBase.FillDataSet(usp_TraerEstFiltroDescrip, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCategoria(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 05/Julio/2013 12:15 p.m.
        Try
            usp_TraerCategoria = New DataSet
            MyBase.SQL = "CALL usp_TraerCategoria(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonb", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerCategoria, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarCategoria(ByVal Marca As String, ByVal Estilon As String, ByVal Categoria As String) As Boolean
        'Tony Garcia - 05/Julio/2013 01:15 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarCategoria(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@categoriab", OdbcType.Char, 3, Categoria)
            'Execute the stored procedure
            usp_ActualizarCategoria = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPedidoPendienteModelo(ByVal Marca As String, ByVal Estilon As String, ByVal Fecha As DateTime) As DataSet
        'Tony Garcia - 03/Julio/2013 09:15 a.m.
        Try
            usp_TraerPedidoPendienteModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerPedidoPendienteModelo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@fechab", OdbcType.DateTime, 10, Fecha)

            MyBase.FillDataSet(usp_TraerPedidoPendienteModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFechaUltVenta(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 23/Septiembre/2013 12:15 p.m.
        Try
            usp_TraerFechaUltVenta = New DataSet
            MyBase.SQL = "CALL usp_TraerFechaUltVenta(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerFechaUltVenta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaUltReciboEstilo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 23/Septiembre/2013 01:15 p.m.
        Try
            usp_TraerFechaUltReciboEstilo = New DataSet
            MyBase.SQL = "CALL usp_TraerFechaUltReciboEstilo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerFechaUltReciboEstilo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostoPrecioModelo(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 24/Septiembre/2013 10:15 a.m.
        Try
            usp_TraerCostoPrecioModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerCostoPrecioModelo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerCostoPrecioModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasModeloAnalisis(ByVal Sucursal As String, ByVal IdArticulo As Integer, ByVal FecIni As Date, ByVal FecFin As Date) As DataSet
        'Tony Garcia - 27/Septiembre/2013 - 07:00 p.m.
        Try
            usp_TraerVentasModeloAnalisis = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasModeloAnalisis(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@marcab", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idarticulob", OdbcType.Int, 8, IdArticulo)
            MyBase.AddParameter("@fecini", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@fecfin", OdbcType.Date, 10, FecFin)

            MyBase.FillDataSet(usp_TraerVentasModeloAnalisis, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

  
#End Region
End Class
