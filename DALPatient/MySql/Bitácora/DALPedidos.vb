Imports System.Data.Odbc
'mreyes 10/Febrero/2012 11:51 a.m.

Public Class DALPedidos
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
    Public Function usp_TraerSeriesConsultaModelos(ByVal Sucursal As String, ByVal Marca As String, ByVal Modelo As String, ByVal Serie As String) As DataSet
        'Tony Garcia -  23/Septiembre/2013 07:10 p.m.
        Try
            usp_TraerSeriesConsultaModelos = New DataSet
            MyBase.SQL = "CALL usp_TraerSeriesConsultaModelos(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@modelob", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@serieb", OdbcType.Char, 13, Serie)

            MyBase.FillDataSet(usp_TraerSeriesConsultaModelos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_OrdeComp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 11:51 a.m.
            MyBase.SQL = "CALL usp_Captura_OrdeComp(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))
            MyBase.AddParameter("@status", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@observa", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("observa"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@resurtsn", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("resurtsn"))
            MyBase.AddParameter("@dsctopp", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dsctopp"))
            MyBase.AddParameter("@diaspp", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("diaspp"))
            MyBase.AddParameter("@dscto01", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto01"))
            MyBase.AddParameter("@dscto02", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto02"))
            MyBase.AddParameter("@dscto03", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto03"))
            MyBase.AddParameter("@dscto04", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto04"))
            MyBase.AddParameter("@dscto05", OdbcType.Double, 10, Section.Tables(0).Rows(0).Item("dscto05"))
            MyBase.AddParameter("@iva", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("iva"))
            MyBase.AddParameter("@tipopedido", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("tipopedido"))


            usp_Captura_OrdeComp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarDetOCPedida(ByVal Ctd As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Entrega As Date) As Boolean
        'mreyes 02/Marzo/2013 10:57 a.m. usp_ActualizarModeloCancelado

        Try
            MyBase.SQL = "CALL usp_ActualizarDetOCPedida(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ctdB", OdbcType.Int, 16, Ctd)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 6, Medida)
            MyBase.AddParameter("@EntregaB", OdbcType.Date, 8, entrega)

            usp_ActualizarDetOCPedida = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarModeloCancelado(ByVal IdUsuarioCancela As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Entrega As Date, ByVal corrida As String) As Boolean
        'mreyes 02/Marzo/2013 10:57 a.m. usp_ActualizarModeloCancelado

        Try
            MyBase.SQL = "CALL usp_ActualizarModeloCancelado(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdUsuarioCancelaB", OdbcType.Int, 16, IdUsuarioCancela)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EntregaB", OdbcType.Date, 8, Entrega)
            MyBase.AddParameter("@corridab", OdbcType.Char, 1, corrida)

            usp_ActualizarModeloCancelado = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarFecReci(ByVal FecReci As Date, ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'mreyes 02/Marzo/2013 10:57 a.m.

        Try
            MyBase.SQL = "CALL usp_ActualizarFecReci(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@FecReci", OdbcType.Date, 8, FecReci)
            MyBase.AddParameter("@Proveedorb", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)

            usp_ActualizarFecReci = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieDEVOPROV(ByVal Serie As String) As Boolean
        'mreyes 02/Marzo/2013 10:57 a.m.

        Try
            MyBase.SQL = "CALL usp_ActualizarSerieDEVOPROV(?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@SerieB", OdbcType.Char, 13, Serie)

            usp_ActualizarSerieDEVOPROV = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_CancEOC(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 11:51 a.m.
            MyBase.SQL = "CALL usp_Captura_CancEOC(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@sucurorc", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucurorc"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))


            usp_Captura_CancEOC = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Det_ocResAut(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 12:02 a.m.
            MyBase.SQL = "CALL usp_Captura_Det_ocResAut(?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@ctd", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("ctd"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))
            MyBase.AddParameter("@costdesc", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costdesc"))
            MyBase.AddParameter("@precio", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precio"))
            MyBase.AddParameter("@entrega", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("entrega"))
            MyBase.AddParameter("@cancela", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("cancela"))
            MyBase.AddParameter("@ordecompresaut", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecompresaut"))


            usp_Captura_Det_ocResAut = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Det_oc(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 12:02 a.m.
            MyBase.SQL = "CALL usp_Captura_Det_oc(?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@ordecomp", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("ordecomp"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@ctd", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("ctd"))
            MyBase.AddParameter("@costo", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costo"))
            MyBase.AddParameter("@costdesc", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("costdesc"))
            MyBase.AddParameter("@precio", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("precio"))
            MyBase.AddParameter("@entrega", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("entrega"))
            MyBase.AddParameter("@cancela", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("cancela"))



            usp_Captura_Det_oc = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CancDOC(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 10/Febrero/2012 12:02 a.m.
            MyBase.SQL = "CALL usp_Captura_CancDOC(?,?,?,?,?,?,?)" 'Insert Query"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@canocid", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("canocid"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("corrida"))
            MyBase.AddParameter("@medida", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("medida"))
            MyBase.AddParameter("@ctd", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("ctd"))

            usp_Captura_CancDOC = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function fn_FolioOrdeComp(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal MasSerie As Integer) As DataSet
        'mreyes 15/Febrero/2012 04:39 p.m.
        Try
            fn_FolioOrdeComp = New DataSet
            MyBase.SQL = "CALL usp_FolioOrdeComp(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MasSerie", OdbcType.Int, 16, MasSerie)

            MyBase.FillDataSet(fn_FolioOrdeComp, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function fn_FolioCambPrec(ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        'mreyes 26/Abril/2012 05:56 p.m.
        Try
            fn_FolioCambPrec = New DataSet
            MyBase.SQL = "CALL usp_FolioCambPrec(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(fn_FolioCambPrec, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_FolioBodega(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 15/Febrero/2012 05:33 a.m.
            MyBase.SQL = "CALL usp_FolioBodega(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))


            usp_FolioBodega = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_FolioOrdeComp(ByVal Opcion As Integer, ByVal Section As DataSet, ByVal MasSerie As Integer) As Boolean
        Try
            'mreyes 15/Febrero/2012 05:33 a.m.
            MyBase.SQL = "CALL usp_FolioOrdeComp(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@MasSerieb", OdbcType.Int, 16, MasSerie)

            usp_FolioOrdeComp = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_FolioCambPrec(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 15/Febrero/2012 05:33 a.m.
            MyBase.SQL = "CALL usp_FolioCambPrec(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))

            usp_FolioCambPrec = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        Try
            usp_TraerOrdeComp = New DataSet
            MyBase.SQL = "CALL usp_TraerOrdeComp(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 7, OrdeComp)
            MyBase.FillDataSet(usp_TraerOrdeComp, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.    Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerOrdeCompMaxEntrega(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        Try
            usp_TraerOrdeCompMaxEntrega = New DataSet
            MyBase.SQL = "CALL usp_TraerOrdeCompMaxEntrega(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 7, OrdeComp)
            MyBase.FillDataSet(usp_TraerOrdeCompMaxEntrega, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactProv(ByVal Sucursal As String, ByVal FactProv As String, ByVal IdFolio As Integer, ByVal Proveedor As String) As DataSet
        'mreyes 22/Marzo/2012 01:25 p.m.
        Try
            usp_TraerFactProv = New DataSet
            MyBase.SQL = "CALL usp_TraerFactProv(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@FactProvB", OdbcType.Char, 10, FactProv)
            MyBase.AddParameter("@idFolioB", OdbcType.Char, 8, IdFolio)
            MyBase.AddParameter("@proveedorb", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerFactProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ExisteFactProv(ByVal Sucursal As String, ByVal Referenc As String) As DataSet
        'mreyes 23/Mayo/2012 05:15 p.m.
        Try
            usp_ExisteFactProv = New DataSet
            MyBase.SQL = "CALL usp_ExisteFactProv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@ReferencB", OdbcType.Char, 10, Referenc)
            MyBase.FillDataSet(usp_ExisteFactProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDevProv(ByVal Sucursal As String, ByVal DevProv As String) As DataSet
        'mreyes 22/Marzo/2012 01:25 p.m.
        Try
            usp_TraerDevProv = New DataSet
            MyBase.SQL = "CALL usp_TraerDevProv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@DevProvB", OdbcType.Char, 7, DevProv)
            MyBase.FillDataSet(usp_TraerDevProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        Try
            usp_TraerDet_Oc = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_Oc(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 7, OrdeComp)
            MyBase.FillDataSet(usp_TraerDet_Oc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDet_OcEstilo(ByVal Marca As String, ByVal Estilon As String, ByVal SucCancela As String, ByVal OrdeComp As String, ByVal Descripcion As String) As DataSet
        Try
            usp_TraerDet_OcEstilo = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_OcEstilo(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@SucCancelaB", OdbcType.Char, 2, SucCancela)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@DescripcB", OdbcType.Char, 30, Descripcion)
            MyBase.FillDataSet(usp_TraerDet_OcEstilo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_FP(ByVal Sucursal As String, ByVal FactProv As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 22/Marzo/2012 01:46 p.m.
        Try
            usp_TraerDet_FP = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_FP(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@FactProvB", OdbcType.Char, 10, FactProv)
            MyBase.AddParameter("@SucursalB", OdbcType.Int, 8, IdFolio)
            MyBase.FillDataSet(usp_TraerDet_FP, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_FPDevoProv(ByVal IdFolio As Integer, ByVal EStilon As String, ByVal Medida As String) As DataSet
        'mreyes 22/Marzo/2012 01:46 p.m.
        Try
            usp_TraerDet_FPDevoProv = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_FPDevoProv(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 8, IdFolio)
            MyBase.AddParameter("@estilonb", OdbcType.Char, 7, EStilon)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.FillDataSet(usp_TraerDet_FPDevoProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDet_FPTraspasoResAut(Opcion As Integer, ByVal IdFolio As Integer, Sucursal As String) As DataSet
        'mreyes 22/Marzo/2012 01:46 p.m.
        Try
            usp_TraerDet_FPTraspasoResAut = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_FPTraspasoResAut(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 6, Opcion)
            MyBase.AddParameter("@idfolioB", OdbcType.Int, 6, IdFolio)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerDet_FPTraspasoResAut, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDet_FPTraspaso(ByVal Sucursal As String, ByVal FactProv As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 22/Marzo/2012 01:46 p.m.
        Try
            usp_TraerDet_FPTraspaso = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_FPTraspaso(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@FactProvB", OdbcType.Char, 10, FactProv)
            MyBase.AddParameter("@idfolioB", OdbcType.Int, 6, idfolio)
            MyBase.FillDataSet(usp_TraerDet_FPTraspaso, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_DP(ByVal Sucursal As String, ByVal DevProv As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 29/Marzo/2012 11:09 a.m.
        Try
            usp_TraerDet_DP = New DataSet
            MyBase.SQL = "CALL usp_TraerDet_DP(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@DevProvB", OdbcType.Char, 7, DevProv)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 6, IdFolio)
            MyBase.FillDataSet(usp_TraerDet_DP, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSeries(ByVal Tipo As String, ByVal Sucursal As String, ByVal Folio As String, ByVal IdFolio As Integer, ByVal Serie As String, ByVal Serie1 As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String) As DataSet
        'mreyes 24/Agosto/2013 10:39 a.m.
        Try
            usp_TraerSeries = New DataSet
            MyBase.SQL = "CALL usp_TraerSeries(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Tipo", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 6, IdFolio)
            MyBase.AddParameter("@serie", OdbcType.Char, 13, Serie)
            MyBase.AddParameter("@serie1", OdbcType.Char, 13, Serie1)

            MyBase.AddParameter("@DIVISION", OdbcType.Char, 100, Division)
            MyBase.AddParameter("@depto", OdbcType.Char, 100, Depto)
            MyBase.AddParameter("@familia", OdbcType.Char, 100, Familia)
            MyBase.AddParameter("@linea", OdbcType.Char, 100, Linea)
            MyBase.AddParameter("@l1", OdbcType.Char, 100, L1)
            MyBase.AddParameter("@l2", OdbcType.Char, 100, L2)
            MyBase.AddParameter("@l3", OdbcType.Char, 100, L3)
            MyBase.AddParameter("@l4", OdbcType.Char, 100, L4)
            MyBase.AddParameter("@l5", OdbcType.Char, 100, L5)
            MyBase.AddParameter("@l6", OdbcType.Char, 100, L6)



            MyBase.FillDataSet(usp_TraerSeries, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieReciboSQL(ByVal IdFolio As Integer, SucurDes As String) As Boolean
        'mreyes 21/Octubre/2012 01:08 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarSerieReciboSQL(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 8, IdFolio)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, SucurDes)

            'Execute the stored procedure
            usp_ActualizarSerieReciboSQL = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'mreyes 18/Febrero/2012 01:43 p.m.
        Try
            MyBase.SQL = "CALL usp_EliminarDet_Oc(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 7, OrdeComp)
            'Execute the stored procedure
            usp_EliminarDet_Oc = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarCantSolMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As Boolean
        'mreyes 20/Marzo/2012 07:06 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarCantSolMedida(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilon", OdbcType.Char, 7, estilon)
            MyBase.AddParameter("@corrida", OdbcType.Char, 1, corrida)
            MyBase.AddParameter("@medida", OdbcType.Char, 3, medida)
            'Execute the stored procedure
            usp_ActualizarCantSolMedida = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCantidadesDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Entrega As Date) As DataSet
        Try
            usp_TraerCantidadesDet_Oc = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadesDet_Oc(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@entrega", OdbcType.Date, 8, Entrega)
            MyBase.FillDataSet(usp_TraerCantidadesDet_Oc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCantidadesSXRecDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Entrega As Date) As DataSet
        Try
            usp_TraerCantidadesSXRecDet_Oc = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadesSXRecDet_Oc(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@entrega", OdbcType.Date, 8, Entrega)
            MyBase.FillDataSet(usp_TraerCantidadesSXRecDet_Oc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCantidadesDet_OcCancela(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As DataSet
        Try
            usp_TraerCantidadesDet_OcCancela = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadesDet_OcCancela(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.FillDataSet(usp_TraerCantidadesDet_OcCancela, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCantidadesDet_FP(ByVal Sucursal As String, ByVal FactProv As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal IdFolio As Integer) As DataSet
        Try
            usp_TraerCantidadesDet_FP = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadesDet_FP(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 10, FactProv)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@idfoliob", OdbcType.Int, 6, idfolio)
            MyBase.FillDataSet(usp_TraerCantidadesDet_FP, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCantidadesDet_DP(ByVal Sucursal As String, ByVal DevoProv As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As DataSet
        'mreyes 29/Marzo/2012 11:23 a.m.
        Try
            usp_TraerCantidadesDet_DP = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadesDet_DP(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@DevoProvB", OdbcType.Char, 6, DevoProv)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.FillDataSet(usp_TraerCantidadesDet_DP, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantArtSolicitados(ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As DataSet
        Try
            usp_TraerCantArtSolicitados = New DataSet
            MyBase.SQL = "CALL usp_TraerCantArtSolicitados(?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@medidab", OdbcType.Char, 3, Medida)
            MyBase.FillDataSet(usp_TraerCantArtSolicitados, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalPedidoNuevo(ByVal Accion As Integer, ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                          ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As String, ByVal IdDepto As String, ByVal IdFamilia As String, ByVal IdLinea As String, _
                                        ByVal IdL1 As String, ByVal IdL2 As String, ByVal IdL3 As String, ByVal IdL4 As String, ByVal IdL5 As String, _
                                        ByVal IdL6 As String, ByVal Proveedor As String, ByVal Status As String, _
                                          ByVal FechaIni As String, ByVal Fechafin As String, ByVal EntregaIni As String, ByVal EntregaFin As String, ByVal ResurtSN As String, ByVal TipoPedido As String, ResAut As Integer) As DataSet
        'mreyes 25/Febrero/2012 06:55 p.m.


        Try
            usp_PpalPedidoNuevo = New DataSet
            MyBase.SQL = "CALL usp_PpalPedidoNuevo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Accion", OdbcType.Int, 8, Accion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeComIniB", OdbcType.Char, 6, OrdeComIni)
            MyBase.AddParameter("@OrdeComFinB", OdbcType.Char, 6, OrdeComFin)
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
            MyBase.AddParameter("@StatusB", OdbcType.Char, 2, Status)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)
            MyBase.AddParameter("@EntregaIni", OdbcType.Char, 10, EntregaIni)
            MyBase.AddParameter("@EntregaFin", OdbcType.Char, 10, EntregaFin)
            MyBase.AddParameter("@ResurtSN", OdbcType.Char, 1, ResurtSN)
            MyBase.AddParameter("@TipoPedidoB", OdbcType.Char, 10, TipoPedido)
            MyBase.AddParameter("@ResAut", OdbcType.Int, 8, resaut)

            MyBase.FillDataSet(usp_PpalPedidoNuevo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalTraerPedidos(ByVal IdFolio As Integer) As DataSet
        'mreyes 28/Abril/2013 02:58 p.m.


        Try
            usp_PpalTraerPedidos = New DataSet
            MyBase.SQL = "CALL usp_PpalTraerPedidos(?)"

            MyBase.InitializeCommand()
            
            MyBase.AddParameter("@IdFolioB", OdbcType.Int, 8, IdFolio)



            MyBase.FillDataSet(usp_PpalTraerPedidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoEstilos(ByVal Marca As String, _
                                       ByVal Estilon As String, ByVal EstiloF As String, ByVal Familia As String, ByVal Linea As String, _
                                       ByVal Proveedor As String, ByVal TipoArt As String, ByVal Categoria As String, _
                                       ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
        'mreyes 25/Febrero/2012 10:00 p.m.


        Try
            usp_PpalCatalogoEstilos = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoEstilos(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
        
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@FamiliaB", OdbcType.Char, 3, Familia)
            MyBase.AddParameter("@LineaB", OdbcType.Char, 3, Linea)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@TipoArtB", OdbcType.Char, 1, TipoArt)
            MyBase.AddParameter("@CategoriaB", OdbcType.Char, 3, Categoria)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)


            MyBase.FillDataSet(usp_PpalCatalogoEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalClasificacionEstilos(ByVal Marca As String, _
                                     ByVal Estilon As String, ByVal EstiloF As String, ByVal Familia As String, ByVal Linea As String, _
                                     ByVal Proveedor As String, ByVal TipoArt As String, ByVal Categoria As String, ByVal ArtCat As String, _
                                     ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
        'Tony Garcia - 29/Noviembre/2012 01:00 p.m.


        Try
            usp_PpalClasificacionEstilos = New DataSet
            MyBase.SQL = "CALL usp_PpalClasificacionEstilos(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstiloFB", OdbcType.Char, 14, EstiloF)
            MyBase.AddParameter("@FamiliaB", OdbcType.Char, 3, Familia)
            MyBase.AddParameter("@LineaB", OdbcType.Char, 3, Linea)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@TipoArtB", OdbcType.Char, 1, TipoArt)
            MyBase.AddParameter("@CategoriaB", OdbcType.Char, 3, Categoria)
            MyBase.AddParameter("@ArtCatB", OdbcType.Char, 15, ArtCat)
            MyBase.AddParameter("@FechaIniB", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Char, 10, Fechafin)


            MyBase.FillDataSet(usp_PpalClasificacionEstilos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosSolicitados(ByVal Marca As String, _
                                      ByVal Proveedor As String, ByVal Track As Integer) As DataSet
        'mreyes 21/Marzo/2012 01:51 p.m.


        Try
            usp_TraerArticulosSolicitados = New DataSet
            MyBase.SQL = "CALL usp_TraerArticulosSolicitados(?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Track", OdbcType.Int, 16, Track)

            MyBase.FillDataSet(usp_TraerArticulosSolicitados, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerMedida(ByVal Opcion As Integer, ByVal Marca As String, _
                                      ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'mreyes 21/Marzo/2012 01:51 p.m.


        Try
            usp_TraerMedida = New DataSet
            MyBase.SQL = "CALL usp_TraerMedida(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)

            MyBase.FillDataSet(usp_TraerMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMedidaMinima(ByVal Opcion As Integer, ByVal Marca As String, _
                                      ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'mreyes 21/Marzo/2012 01:51 p.m.


        Try
            usp_TraerMedidaMinima = New DataSet
            MyBase.SQL = "CALL usp_TraerMedidaMinima(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)

            MyBase.FillDataSet(usp_TraerMedidaMinima, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaUltResurt() As DataSet
        'mreyes 02/Mayo/2012 10:41 a.m.


        Try
            usp_TraerFechaUltResurt = New DataSet
            MyBase.SQL = "CALL usp_TraerFechaUltResurt()"

            MyBase.InitializeCommand()



            MyBase.FillDataSet(usp_TraerFechaUltResurt, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtidoAuto() As DataSet
        'mreyes 30/Abril/2012 03:50 p.m.


        Try
            usp_TraerResurtidoAuto = New DataSet
            MyBase.SQL = "CALL usp_TraerResurtidoAuto()"

            MyBase.InitializeCommand()


            MyBase.FillDataSet(usp_TraerResurtidoAuto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'mreyes 28/Abril/2013 11:53 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarOrdeComp(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeComp", OdbcType.Char, 6, OrdeComp)


            'Execute the stored procedure
            usp_ActualizarOrdeComp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaClasifEstilos(ByVal Opcion As String, ByVal Marca As String, ByVal Estilon As String, _
                                            ByVal Tipo As String, ByVal UsuModArtCat As String, ByVal FummodArtCat As DateTime) As Boolean
        'Tony Garcia - 30/Noviembre/2012 10:00 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaClasifEstilos(?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcionB", OdbcType.Int, 4, Opcion)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@tipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@usumodartcatb", OdbcType.Char, 8, UsuModArtCat)
            MyBase.AddParameter("@fummodartcatb", OdbcType.DateTime, 16, FummodArtCat)

            'Execute the stored procedure
            usp_CapturaClasifEstilos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
