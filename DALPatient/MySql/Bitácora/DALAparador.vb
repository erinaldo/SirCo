Imports System.Data.Odbc

Public Class DALAparador
    'mreyes 24/Abril/2015   10:12 a.m.
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
    Public Function usp_PpalDineroElectronico(ByVal Cuenta As String) As DataSet
        'mreyes 10/Noviembre/2016   11:02 a.m.
        Try
            usp_PpalDineroElectronico = New DataSet
            MyBase.SQL = "CALL usp_PpalDineroElectronico(?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Cuentab", OdbcType.Char, 13, Cuenta)
     

            MyBase.FillDataSet(usp_PpalDineroElectronico, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerReciboAparador(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal FecReciInib As String, ByVal FecReciFinB As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String,
                                                   ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, IdAgrupacion As String,
                                                   ByVal NomTabla As String) As DataSet
        'mreyes 25/Mayo/2016    11:34 a.m.
        Try
            usp_TraerReciboAparador = New DataSet
            MyBase.SQL = "CALL usp_TraerReciboAparador1(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalesB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FecReciIniB", OdbcType.Date, 8, FecReciInib)
            MyBase.AddParameter("@FecRecifinB", OdbcType.Date, 8, FecReciFinB)
            MyBase.AddParameter("@idDivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@iddeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Char, 30, Familia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@idl1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@idl2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@idl3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@idl4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@idl5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@idl6B", OdbcType.Char, 30, L6)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@IdAGrupacionB", OdbcType.Char, 7, IdAgrupacion)
            MyBase.AddParameter("@NomTabla", OdbcType.Char, 350, NomTabla)

            MyBase.FillDataSet(usp_TraerReciboAparador, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMatchAparador(ByVal Opcion As Integer, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                       ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                                       ByVal NomTabla As String) As DataSet
        'mreyes 22/Mayo/2015    05:39 p.m.
        Try
            usp_TraerMatchAparador = New DataSet
            MyBase.SQL = "CALL usp_TraerMatchAparador(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalesB", OdbcType.Char, 250, Sucursales)
            MyBase.AddParameter("@idDivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@iddeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Char, 30, Familia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@idl1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@idl2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@idl3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@idl4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@idl5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@idl6B", OdbcType.Char, 30, L6)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@NomTabla", OdbcType.Char, 350, NomTabla)

            MyBase.FillDataSet(usp_TraerMatchAparador, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerAparadorReal(ByVal Opcion As Integer, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                       ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                                       ByVal NomTabla As String) As DataSet
        'mreyes 29/Abril/2015   11:42 a.m.
        Try
            usp_TraerAparadorReal = New DataSet
            MyBase.SQL = "CALL usp_TraerAparadorReal(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalesB", OdbcType.Char, 250, Sucursales)
            MyBase.AddParameter("@idDivisionB", OdbcType.Char, 30, Division)
            MyBase.AddParameter("@iddeptoB", OdbcType.Char, 30, Depto)
            MyBase.AddParameter("@idFamiliaB", OdbcType.Char, 30, Familia)
            MyBase.AddParameter("@idLineaB", OdbcType.Char, 30, Linea)
            MyBase.AddParameter("@idl1B", OdbcType.Char, 30, L1)
            MyBase.AddParameter("@idl2B", OdbcType.Char, 30, L2)
            MyBase.AddParameter("@idl3B", OdbcType.Char, 30, L3)
            MyBase.AddParameter("@idl4B", OdbcType.Char, 30, L4)
            MyBase.AddParameter("@idl5B", OdbcType.Char, 30, L5)
            MyBase.AddParameter("@idl6B", OdbcType.Char, 30, L6)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ModeloB", OdbcType.Char, 7, Modelo)
            MyBase.AddParameter("@NomTabla", OdbcType.Char, 350, NomTabla)

            MyBase.FillDataSet(usp_TraerAparadorReal, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_AparadorLeer(ByVal Section As DataSet) As Boolean
        Try
            'mreyes 29/Febrero/2012 10:54 a.m.
            MyBase.SQL = "CALL usp_Captura_AparadorLeer(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@serie", OdbcType.Char, 14, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@idusuarioinicialapab", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idusuarioinicialapa"))



            usp_Captura_AparadorLeer = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_TraspasoLeer(ByVal Section As DataSet) As Boolean
        Try
            'mreyes 02/Noviembre/2016   05:29 p.m.
            MyBase.SQL = "CALL usp_Captura_TraspasoLeer(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@serie", OdbcType.Char, 14, Section.Tables(0).Rows(0).Item("serie"))
            MyBase.AddParameter("@idusuarioinicialapab", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idusuarioinicialapa"))



            usp_Captura_TraspasoLeer = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalAparador(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal FecReciIni As String, _
                                        ByVal FecReciFin As String, ByVal idusuarioinicialapa As Integer)
        'mreyes 24/Abril/2015   10:17 a.m.
        Try
            'SucursalB char(2),Marcab char(3), Estilonb char(7),fecreciinib char(10), fecrecifinb char(10), idusuarioinicialapab(Int)
            usp_PpalAparador = New DataSet
            MyBase.SQL = "CALL usp_PpalAparador(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonb", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@fecreciinib", OdbcType.Char, 10, FecReciIni)
            MyBase.AddParameter("@fecrecifinb", OdbcType.Char, 10, FecReciFin)

            MyBase.AddParameter("@idusuarioinicialapa", OdbcType.Int, 16, idusuarioinicialapa)


            MyBase.FillDataSet(usp_PpalAparador, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaAparador(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal IdUsuarioInicialApa As Integer, ByVal Observaciones As String) As Boolean
        'mreyes 24/Abril/2015   11:44 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaAparador(?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", OdbcType.Int, 7, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@corridab", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@IDUSUARIOINICIALAPAB", OdbcType.Int, 8, IdUsuarioInicialApa)
            MyBase.AddParameter("@observacionesb", OdbcType.Char, 230, Observaciones)



            'Execute the stored procedure
            usp_ActualizaAparador = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_ActualizaDiasResProv(ByVal Proveedor As String, ByVal Marca As String, _
                                             ByVal Estilon As String, ByVal DiasResurt As Integer) As Boolean
        'Tony Garcia - 07/Diciembre/2012 - 02:00 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaDiasResProv(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@diasresurtidoB", OdbcType.Int, 4, DiasResurt)

            'Execute the stored procedure
            usp_ActualizaDiasResProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String, _
                                                   ByVal DiasRespuesta As Integer, ByVal UltimoRes As String, ByVal DiasResurtido As Integer) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:00 p.m.
        Try

            MyBase.SQL = "CALL usp_CapturaMarcaEstilonDiasRes(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@diasrespuestaB", OdbcType.Int, 3, DiasRespuesta)
            MyBase.AddParameter("@ultimoresurtidoB", OdbcType.Char, 10, UltimoRes)
            MyBase.AddParameter("@diasresurtidoB", OdbcType.Int, 3, DiasResurtido)


            usp_CapturaMarcaEstilonDiasRes = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_EliminarMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:35 p.m.
        Try

            MyBase.SQL = "CALL usp_EliminarMarcaEstilonDiasRes(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)

            usp_EliminarMarcaEstilonDiasRes = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
