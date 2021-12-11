Imports System.Data.Odbc


Public Class DALCatalogoEstilosClasif

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



    Public Function usp_Captura_Articulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_Articulo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
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


            usp_Captura_Articulo = ExecuteStoredProcedure()
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
            MyBase.SQL = "CALL usp_Captura_Corrida(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
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
            MyBase.SQL = "CALL usp_Captura_Medida(?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
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

    Public Function usp_TraerCorrida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        Try
            usp_TraerCorrida = New DataSet
            MyBase.SQL = "CALL usp_TraerCorrida(?,?, ?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)

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

    Public Function usp_TraerVentasEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerVentasEstilos = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasEstilos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerVentasEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerComprasEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerComprasEstilos = New DataSet
            MyBase.SQL = "CALL usp_TraerComprasEstilos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerComprasEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerExistenciaEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerExistenciaEstilos = New DataSet
            MyBase.SQL = "CALL usp_TraerExistenciaEstilos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerExistenciaEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPPEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerPPEstilos = New DataSet
            MyBase.SQL = "CALL usp_TraerPPEstilos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerPPEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimasComprasEstilos(ByVal Marca As String, ByVal EstiloN As String, ByVal EstiloF As String) As DataSet
        'Tony Garcia - 20/Diciembre/2012 - 5:40 p.m.
        Try
            usp_TraerUltimasComprasEstilos = New DataSet
            MyBase.SQL = "CALL usp_TraerUltimasComprasEstilos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, EstiloN)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, EstiloF)

            MyBase.FillDataSet(usp_TraerUltimasComprasEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstiloN(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 21/Diciembre/2012 - 10:18 a.m.
        Try
            usp_TraerEstiloN = New DataSet
            MyBase.SQL = "CALL usp_TraerEstiloN(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerEstiloN, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClasificacionEstiloUp(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 21/Diciembre/2012 - 10:18 a.m.
        Try
            usp_TraerClasificacionEstiloUp = New DataSet
            MyBase.SQL = "CALL usp_TraerClasificacionEstiloUp(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerClasificacionEstiloUp, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClasificacionEst(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'Tony Garcia - 21/Diciembre/2012 - 01:18 p.m.
        Try
            usp_TraerClasificacionEst = New DataSet
            MyBase.SQL = "CALL usp_TraerClasificacionEst(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            MyBase.FillDataSet(usp_TraerClasificacionEst, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
