Imports System.Data.Odbc
'Miguel Pérez 12/Noviembre/2012 05:09 p.m.

Public Class DALResurtido
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

    Public Function usp_TraerEstilosVendExis(ByVal FechaIni As String, ByVal FechaFin As String, ByVal Sucursal As String, ByVal Marca As String) As DataSet
        'miguel pérez 12/Noviembre/2012 05:23 p.m.
        Try
            usp_TraerEstilosVendExis = New DataSet
            MyBase.SQL = "CALL usp_TraerEstilosVendExis(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIni", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FecFin", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.FillDataSet(usp_TraerEstilosVendExis, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResmin(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 12/Noviembre/2012 05:23 p.m.
        Try
            usp_TraerResmin = New DataSet
            MyBase.SQL = "CALL usp_TraerResmin(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.FillDataSet(usp_TraerResmin, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMedida2(ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String) As DataSet
        'miguel pérez 17/Noviembre/2012 09:23 a.m.
        Try
            usp_TraerMedida2 = New DataSet
            MyBase.SQL = "CALL usp_TraerMedida2(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.FillDataSet(usp_TraerMedida2, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDiasResProv(ByVal Proveedor As String) As DataSet
        'miguel pérez 20/Noviembre/2012 10:09 a.m.
        Try
            usp_TraerDiasResProv = New DataSet
            MyBase.SQL = "CALL usp_TraerDiasResProv(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerDiasResProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarcasProveedor(ByVal Proveedor As String, ByVal Marca As String) As DataSet
        'miguel pérez 02/Diciembre/2012 02:42 p.m.
        Try
            usp_TraerMarcasProveedor = New DataSet
            MyBase.SQL = "CALL usp_TraerMarcasProveedor(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.FillDataSet(usp_TraerMarcasProveedor, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCantidadVentas(ByVal Marca As String, ByVal FecIni As String, ByVal FecFin As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 02/Diciembre/2012 04:03 p.m.
        Try
            usp_TraerCantidadVentas = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadVentas(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@FecIni", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@FecFin", OdbcType.Char, 10, FecFin)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.FillDataSet(usp_TraerCantidadVentas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCantidadPP(ByVal Marca As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 02/Diciembre/2012 04:05 p.m.
        Try
            usp_TraerCantidadPP = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadPP(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.FillDataSet(usp_TraerCantidadPP, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasMedida(ByVal FechaIni As String, ByVal FechaFin As String, ByVal Sucursal As String, ByVal Marca As String, ByVal ProveedorB As String, ByVal Estilon As String, ByVal Estilof As String, ByVal Categoria As String) As DataSet
        'miguel pérez 03/Diciembre/2012 10:09 a.m.
        Try
            usp_TraerVentasMedida = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasMedida(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecIni", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@FecFin", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, ProveedorB)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 14, Estilof)
            MyBase.AddParameter("@CategoriaB", OdbcType.Char, 200, Categoria)
            MyBase.FillDataSet(usp_TraerVentasMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerExistenciaMedida(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Categoria As String) As DataSet
        'miguel pérez 03/Diciembre/2012 11:47 a.m.
        Try
            usp_TraerExistenciaMedida = New DataSet
            MyBase.SQL = "CALL usp_TraerExistenciaMedida(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@CategoriaB", OdbcType.Char, 200, Categoria)
            MyBase.FillDataSet(usp_TraerExistenciaMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPPMedida(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 03/Diciembre/2012 12:04 p.m.
        Try
            usp_TraerPPMedida = New DataSet
            MyBase.SQL = "CALL usp_TraerPPMedida(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.FillDataSet(usp_TraerPPMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, _
                                           ByVal Estatus As String, ByVal Marca As String, ByVal Proveedor As String, _
                                           ByVal Fecha As String, ByVal Hora As String, ByVal Observaciones As String, _
                                           ByVal Usuario As String, ByVal DiasResurtido As String) As Boolean
        'miguel pérez 04/Diciembre/2012 01:24 p.m.
        Try
            MyBase.SQL = "call usp_CapturaResurtido(?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", OdbcType.Char, 8, Hora)
            MyBase.AddParameter("@ObservacionesB", OdbcType.Char, 50, Observaciones)
            MyBase.AddParameter("@UsuarioB", OdbcType.Char, 13, Usuario)
            MyBase.AddParameter("@DiasResB", OdbcType.Char, 4, DiasResurtido)

            usp_CapturaResurtido = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Estilon As String, ByVal objDataRow As DataRow, ByVal Prioridad As Integer) As Boolean
        'miguel pérez 04/Diciembre/2012 01:49 p.m.
        Try
            MyBase.SQL = "call usp_CapturaResurtidoDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 16, objDataRow.Item(3).ToString)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 16, objDataRow.Item(4).ToString)
            MyBase.AddParameter("@M1B", OdbcType.Char, 3, objDataRow.Item(5).ToString)
            MyBase.AddParameter("@M1_B", OdbcType.Char, 3, objDataRow.Item(6).ToString)
            MyBase.AddParameter("@M2B", OdbcType.Char, 3, objDataRow.Item(7).ToString)
            MyBase.AddParameter("@M2_B", OdbcType.Char, 3, objDataRow.Item(8).ToString)
            MyBase.AddParameter("@M3B", OdbcType.Char, 3, objDataRow.Item(9).ToString)
            MyBase.AddParameter("@M3_B", OdbcType.Char, 3, objDataRow.Item(10).ToString)
            MyBase.AddParameter("@M4B", OdbcType.Char, 3, objDataRow.Item(11).ToString)
            MyBase.AddParameter("@M4_B", OdbcType.Char, 3, objDataRow.Item(12).ToString)
            MyBase.AddParameter("@M5B", OdbcType.Char, 3, objDataRow.Item(13).ToString)
            MyBase.AddParameter("@M5_B", OdbcType.Char, 3, objDataRow.Item(14).ToString)
            MyBase.AddParameter("@M6B", OdbcType.Char, 3, objDataRow.Item(15).ToString)
            MyBase.AddParameter("@M6_B", OdbcType.Char, 3, objDataRow.Item(16).ToString)
            MyBase.AddParameter("@M7B", OdbcType.Char, 3, objDataRow.Item(17).ToString)
            MyBase.AddParameter("@M7_B", OdbcType.Char, 3, objDataRow.Item(18).ToString)
            MyBase.AddParameter("@M8B", OdbcType.Char, 3, objDataRow.Item(19).ToString)
            MyBase.AddParameter("@M8_B", OdbcType.Char, 3, objDataRow.Item(20).ToString)
            MyBase.AddParameter("@M9B", OdbcType.Char, 3, objDataRow.Item(21).ToString)
            MyBase.AddParameter("@M9_B", OdbcType.Char, 3, objDataRow.Item(22).ToString)
            MyBase.AddParameter("@M10B", OdbcType.Char, 3, objDataRow.Item(23).ToString)
            MyBase.AddParameter("@M10_B", OdbcType.Char, 3, objDataRow.Item(24).ToString)
            MyBase.AddParameter("@M11B", OdbcType.Char, 3, objDataRow.Item(25).ToString)
            MyBase.AddParameter("@M11_B", OdbcType.Char, 3, objDataRow.Item(26).ToString)
            MyBase.AddParameter("@M12B", OdbcType.Char, 3, objDataRow.Item(27).ToString)
            MyBase.AddParameter("@M12_B", OdbcType.Char, 3, objDataRow.Item(28).ToString)
            MyBase.AddParameter("@M13B", OdbcType.Char, 3, objDataRow.Item(29).ToString)
            MyBase.AddParameter("@M13_B", OdbcType.Char, 3, objDataRow.Item(30).ToString)
            MyBase.AddParameter("@M14B", OdbcType.Char, 3, objDataRow.Item(31).ToString)
            MyBase.AddParameter("@M14_B", OdbcType.Char, 3, objDataRow.Item(32).ToString)
            MyBase.AddParameter("@M15B", OdbcType.Char, 3, objDataRow.Item(33).ToString)
            MyBase.AddParameter("@M15_B", OdbcType.Char, 3, objDataRow.Item(34).ToString)
            MyBase.AddParameter("@M16B", OdbcType.Char, 3, objDataRow.Item(35).ToString)
            MyBase.AddParameter("@M16_B", OdbcType.Char, 3, objDataRow.Item(36).ToString)
            MyBase.AddParameter("@M17B", OdbcType.Char, 3, objDataRow.Item(37).ToString)
            MyBase.AddParameter("@M17_B", OdbcType.Char, 3, objDataRow.Item(38).ToString)
            MyBase.AddParameter("@M18B", OdbcType.Char, 3, objDataRow.Item(39).ToString)
            MyBase.AddParameter("@M18_B", OdbcType.Char, 3, objDataRow.Item(40).ToString)
            MyBase.AddParameter("@M19B", OdbcType.Char, 3, objDataRow.Item(41).ToString)
            MyBase.AddParameter("@M19_B", OdbcType.Char, 3, objDataRow.Item(42).ToString)
            MyBase.AddParameter("@M20B", OdbcType.Char, 3, objDataRow.Item(43).ToString)
            MyBase.AddParameter("@M20_B", OdbcType.Char, 3, objDataRow.Item(44).ToString)
            MyBase.AddParameter("@M21B", OdbcType.Char, 3, objDataRow.Item(45).ToString)
            MyBase.AddParameter("@M21_B", OdbcType.Char, 3, objDataRow.Item(46).ToString)
            MyBase.AddParameter("@M22B", OdbcType.Char, 3, objDataRow.Item(47).ToString)
            MyBase.AddParameter("@M22_B", OdbcType.Char, 3, objDataRow.Item(48).ToString)
            MyBase.AddParameter("@M23B", OdbcType.Char, 3, objDataRow.Item(49).ToString)
            MyBase.AddParameter("@M23_B", OdbcType.Char, 3, objDataRow.Item(50).ToString)
            MyBase.AddParameter("@M24B", OdbcType.Char, 3, objDataRow.Item(51).ToString)
            MyBase.AddParameter("@M24_B", OdbcType.Char, 3, objDataRow.Item(52).ToString)
            MyBase.AddParameter("@M25B", OdbcType.Char, 3, objDataRow.Item(53).ToString)
            MyBase.AddParameter("@M25_B", OdbcType.Char, 3, objDataRow.Item(54).ToString)
            MyBase.AddParameter("@M26B", OdbcType.Char, 3, objDataRow.Item(55).ToString)
            MyBase.AddParameter("@M26_B", OdbcType.Char, 3, objDataRow.Item(56).ToString)
            MyBase.AddParameter("@M27B", OdbcType.Char, 3, objDataRow.Item(57).ToString)
            MyBase.AddParameter("@M27_B", OdbcType.Char, 3, objDataRow.Item(58).ToString)
            MyBase.AddParameter("@M28B", OdbcType.Char, 3, objDataRow.Item(59).ToString)
            MyBase.AddParameter("@M28_B", OdbcType.Char, 3, objDataRow.Item(60).ToString)
            MyBase.AddParameter("@M29B", OdbcType.Char, 3, objDataRow.Item(61).ToString)
            MyBase.AddParameter("@M29_B", OdbcType.Char, 3, objDataRow.Item(62).ToString)
            MyBase.AddParameter("@M30B", OdbcType.Char, 3, objDataRow.Item(63).ToString)
            MyBase.AddParameter("@M30_B", OdbcType.Char, 3, objDataRow.Item(64).ToString)
            MyBase.AddParameter("@M31B", OdbcType.Char, 3, objDataRow.Item(65).ToString)
            MyBase.AddParameter("@M31_B", OdbcType.Char, 3, objDataRow.Item(66).ToString)
            MyBase.AddParameter("@M32B", OdbcType.Char, 3, objDataRow.Item(67).ToString)
            MyBase.AddParameter("@M32_B", OdbcType.Char, 3, objDataRow.Item(68).ToString)
            MyBase.AddParameter("@M33B", OdbcType.Char, 3, objDataRow.Item(69).ToString)
            MyBase.AddParameter("@M33_B", OdbcType.Char, 3, objDataRow.Item(70).ToString)
            MyBase.AddParameter("@M34B", OdbcType.Char, 3, objDataRow.Item(71).ToString)
            MyBase.AddParameter("@M34_B", OdbcType.Char, 3, objDataRow.Item(72).ToString)
            MyBase.AddParameter("@M35B", OdbcType.Char, 3, objDataRow.Item(73).ToString)
            MyBase.AddParameter("@M35_B", OdbcType.Char, 3, objDataRow.Item(74).ToString)
            MyBase.AddParameter("@M36B", OdbcType.Char, 3, objDataRow.Item(75).ToString)
            MyBase.AddParameter("@M36_B", OdbcType.Char, 3, objDataRow.Item(76).ToString)
            MyBase.AddParameter("@M37B", OdbcType.Char, 3, objDataRow.Item(77).ToString)
            MyBase.AddParameter("@M37_B", OdbcType.Char, 3, objDataRow.Item(78).ToString)
            MyBase.AddParameter("@M38B", OdbcType.Char, 3, objDataRow.Item(79).ToString)
            MyBase.AddParameter("@M38_B", OdbcType.Char, 3, objDataRow.Item(80).ToString)
            MyBase.AddParameter("@M39B", OdbcType.Char, 3, objDataRow.Item(81).ToString)
            MyBase.AddParameter("@M39_B", OdbcType.Char, 3, objDataRow.Item(82).ToString)
            MyBase.AddParameter("@M40B", OdbcType.Char, 3, objDataRow.Item(83).ToString)
            MyBase.AddParameter("@M40_B", OdbcType.Char, 3, objDataRow.Item(84).ToString)
            MyBase.AddParameter("@M41B", OdbcType.Char, 3, objDataRow.Item(85).ToString)
            MyBase.AddParameter("@M41_B", OdbcType.Char, 3, objDataRow.Item(86).ToString)
            MyBase.AddParameter("@M42B", OdbcType.Char, 3, objDataRow.Item(87).ToString)
            MyBase.AddParameter("@M42_B", OdbcType.Char, 3, objDataRow.Item(88).ToString)
            MyBase.AddParameter("@M43B", OdbcType.Char, 3, objDataRow.Item(89).ToString)
            MyBase.AddParameter("@M43_B", OdbcType.Char, 3, objDataRow.Item(90).ToString)
            MyBase.AddParameter("@M44B", OdbcType.Char, 3, objDataRow.Item(91).ToString)
            MyBase.AddParameter("@M44_B", OdbcType.Char, 3, objDataRow.Item(92).ToString)
            MyBase.AddParameter("@M45B", OdbcType.Char, 3, objDataRow.Item(93).ToString)
            MyBase.AddParameter("@M45_B", OdbcType.Char, 3, objDataRow.Item(94).ToString)
            MyBase.AddParameter("@M46B", OdbcType.Char, 3, objDataRow.Item(95).ToString)
            MyBase.AddParameter("@M46_B", OdbcType.Char, 3, objDataRow.Item(96).ToString)
            MyBase.AddParameter("@M47B", OdbcType.Char, 3, objDataRow.Item(97).ToString)
            MyBase.AddParameter("@M47_B", OdbcType.Char, 3, objDataRow.Item(98).ToString)
            MyBase.AddParameter("@M48B", OdbcType.Char, 3, objDataRow.Item(99).ToString)
            MyBase.AddParameter("@M48_B", OdbcType.Char, 3, objDataRow.Item(100).ToString)
            MyBase.AddParameter("@M49B", OdbcType.Char, 3, objDataRow.Item(101).ToString)
            MyBase.AddParameter("@M49_B", OdbcType.Char, 3, objDataRow.Item(102).ToString)
            MyBase.AddParameter("@M50B", OdbcType.Char, 3, objDataRow.Item(103).ToString)
            MyBase.AddParameter("@M50_B", OdbcType.Char, 3, objDataRow.Item(104).ToString)
            MyBase.AddParameter("@PrioridadB", OdbcType.Int, 16, Prioridad)

            usp_CapturaResurtidoDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFoliosResurtido(ByVal Sucursal As String, ByVal Opcion As String) As DataSet
        'miguel pérez 04/Diciembre/2012 2:30 p.m.
        Try
            usp_TraerFoliosResurtido = New DataSet
            MyBase.SQL = "CALL usp_TraerFoliosResurtido(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@Opcion", OdbcType.Char, 1, Opcion)
            MyBase.FillDataSet(usp_TraerFoliosResurtido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeCompA As String, ByVal OrdeCompB As String, ByVal FechaA As String, ByVal FechaB As String, ByVal Marca As String, ByVal Proveedor As String, _
                                       ByVal Estatus As String, ByVal Opcion As Integer, ByVal IdEmpleado As Integer) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 p.m.
        Try
            usp_TraerResurtido = New DataSet
            MyBase.SQL = "CALL usp_TraerResurtido(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompBA", OdbcType.Char, 6, OrdeCompA)
            MyBase.AddParameter("@OrdeCompBB", OdbcType.Char, 6, OrdeCompB)
            MyBase.AddParameter("@FechaBA", OdbcType.Char, 10, FechaA)
            MyBase.AddParameter("@FechaBB", OdbcType.Char, 10, FechaB)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@idempleadoB", OdbcType.SmallInt, 4, IdEmpleado)
            MyBase.FillDataSet(usp_TraerResurtido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_TraerResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeCompA As String, ByVal OrdeCompB As String, ByVal FechaA As String, ByVal FechaB As String, ByVal Marca As String, ByVal Proveedor As String, _
    '                                   ByVal Estatus As String, ByVal Opcion As Integer) As DataSet
    '    'miguel pérez 04/Diciembre/2012 5:00 p.m.
    '    Try
    '        usp_TraerResurtido = New DataSet
    '        MyBase.SQL = "CALL usp_TraerResurtido(?,?,?,?,?,?,?,?,?,?)"

    '        MyBase.InitializeCommand()
    '        MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
    '        MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
    '        MyBase.AddParameter("@OrdeCompBA", OdbcType.Char, 6, OrdeCompA)
    '        MyBase.AddParameter("@OrdeCompBB", OdbcType.Char, 6, OrdeCompB)
    '        MyBase.AddParameter("@FechaBA", OdbcType.Char, 10, FechaA)
    '        MyBase.AddParameter("@FechaBB", OdbcType.Char, 10, FechaB)
    '        MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
    '        MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
    '        MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
    '        MyBase.AddParameter("@opcion", OdbcType.Int, 8, Opcion)

    '        MyBase.FillDataSet(usp_TraerResurtido, "cipsis")
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_TraerResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Tipo As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerResurtidoDet = New DataSet
            MyBase.SQL = "CALL usp_TraerResurtidoDet(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 16, Tipo)
            MyBase.FillDataSet(usp_TraerResurtidoDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetOC(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String) As DataSet
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            usp_TraerDetOC = New DataSet
            MyBase.SQL = "CALL usp_TraerDetOC(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 6, Medida)
            MyBase.FillDataSet(usp_TraerDetOC, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarDetOC(ByVal Ctd As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Entrega As String, ByVal Cancela As String) As Boolean
        'miguel pérez 05/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarDetOC(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ctdB", OdbcType.Int, 16, Ctd)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 6, Medida)
            MyBase.AddParameter("@EntregaB", OdbcType.Char, 10, Entrega)
            MyBase.AddParameter("@CancelaB", OdbcType.Char, 10, Cancela)
            usp_ActualizarDetOC = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Estilon As String, ByVal objDataRow As DataRow) As Boolean
        'miguel pérez 5/Diciembre/2012 10:42 a.m.
        Try
            MyBase.SQL = "call usp_ActualizaResurtidoDet(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, objDataRow.Item(5).ToString)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 16, objDataRow.Item(7).ToString)
            MyBase.AddParameter("@M1B", OdbcType.Char, 3, objDataRow.Item(8).ToString)
            MyBase.AddParameter("@M1_B", OdbcType.Char, 3, objDataRow.Item(9).ToString)
            MyBase.AddParameter("@M2B", OdbcType.Char, 3, objDataRow.Item(10).ToString)
            MyBase.AddParameter("@M2_B", OdbcType.Char, 3, objDataRow.Item(11).ToString)
            MyBase.AddParameter("@M3B", OdbcType.Char, 3, objDataRow.Item(12).ToString)
            MyBase.AddParameter("@M3_B", OdbcType.Char, 3, objDataRow.Item(13).ToString)
            MyBase.AddParameter("@M4B", OdbcType.Char, 3, objDataRow.Item(14).ToString)
            MyBase.AddParameter("@M4_B", OdbcType.Char, 3, objDataRow.Item(15).ToString)
            MyBase.AddParameter("@M5B", OdbcType.Char, 3, objDataRow.Item(16).ToString)
            MyBase.AddParameter("@M5_B", OdbcType.Char, 3, objDataRow.Item(17).ToString)
            MyBase.AddParameter("@M6B", OdbcType.Char, 3, objDataRow.Item(18).ToString)
            MyBase.AddParameter("@M6_B", OdbcType.Char, 3, objDataRow.Item(19).ToString)
            MyBase.AddParameter("@M7B", OdbcType.Char, 3, objDataRow.Item(20).ToString)
            MyBase.AddParameter("@M7_B", OdbcType.Char, 3, objDataRow.Item(21).ToString)
            MyBase.AddParameter("@M8B", OdbcType.Char, 3, objDataRow.Item(22).ToString)
            MyBase.AddParameter("@M8_B", OdbcType.Char, 3, objDataRow.Item(23).ToString)
            MyBase.AddParameter("@M9B", OdbcType.Char, 3, objDataRow.Item(24).ToString)
            MyBase.AddParameter("@M9_B", OdbcType.Char, 3, objDataRow.Item(25).ToString)
            MyBase.AddParameter("@M10B", OdbcType.Char, 3, objDataRow.Item(26).ToString)
            MyBase.AddParameter("@M10_B", OdbcType.Char, 3, objDataRow.Item(27).ToString)
            MyBase.AddParameter("@M11B", OdbcType.Char, 3, objDataRow.Item(28).ToString)
            MyBase.AddParameter("@M11_B", OdbcType.Char, 3, objDataRow.Item(29).ToString)
            MyBase.AddParameter("@M12B", OdbcType.Char, 3, objDataRow.Item(30).ToString)
            MyBase.AddParameter("@M12_B", OdbcType.Char, 3, objDataRow.Item(31).ToString)
            MyBase.AddParameter("@M13B", OdbcType.Char, 3, objDataRow.Item(32).ToString)
            MyBase.AddParameter("@M13_B", OdbcType.Char, 3, objDataRow.Item(33).ToString)
            MyBase.AddParameter("@M14B", OdbcType.Char, 3, objDataRow.Item(34).ToString)
            MyBase.AddParameter("@M14_B", OdbcType.Char, 3, objDataRow.Item(35).ToString)
            MyBase.AddParameter("@M15B", OdbcType.Char, 3, objDataRow.Item(36).ToString)
            MyBase.AddParameter("@M15_B", OdbcType.Char, 3, objDataRow.Item(37).ToString)
            MyBase.AddParameter("@M16B", OdbcType.Char, 3, objDataRow.Item(38).ToString)
            MyBase.AddParameter("@M16_B", OdbcType.Char, 3, objDataRow.Item(39).ToString)
            MyBase.AddParameter("@M17B", OdbcType.Char, 3, objDataRow.Item(40).ToString)
            MyBase.AddParameter("@M17_B", OdbcType.Char, 3, objDataRow.Item(41).ToString)
            MyBase.AddParameter("@M18B", OdbcType.Char, 3, objDataRow.Item(42).ToString)
            MyBase.AddParameter("@M18_B", OdbcType.Char, 3, objDataRow.Item(43).ToString)
            MyBase.AddParameter("@M19B", OdbcType.Char, 3, objDataRow.Item(44).ToString)
            MyBase.AddParameter("@M19_B", OdbcType.Char, 3, objDataRow.Item(45).ToString)
            MyBase.AddParameter("@M20B", OdbcType.Char, 3, objDataRow.Item(46).ToString)
            MyBase.AddParameter("@M20_B", OdbcType.Char, 3, objDataRow.Item(47).ToString)
            MyBase.AddParameter("@M21B", OdbcType.Char, 3, objDataRow.Item(48).ToString)
            MyBase.AddParameter("@M21_B", OdbcType.Char, 3, objDataRow.Item(49).ToString)
            MyBase.AddParameter("@M22B", OdbcType.Char, 3, objDataRow.Item(50).ToString)
            MyBase.AddParameter("@M22_B", OdbcType.Char, 3, objDataRow.Item(51).ToString)
            MyBase.AddParameter("@M23B", OdbcType.Char, 3, objDataRow.Item(52).ToString)
            MyBase.AddParameter("@M23_B", OdbcType.Char, 3, objDataRow.Item(53).ToString)
            MyBase.AddParameter("@M24B", OdbcType.Char, 3, objDataRow.Item(54).ToString)
            MyBase.AddParameter("@M24_B", OdbcType.Char, 3, objDataRow.Item(55).ToString)
            MyBase.AddParameter("@M25B", OdbcType.Char, 3, objDataRow.Item(56).ToString)
            MyBase.AddParameter("@M25_B", OdbcType.Char, 3, objDataRow.Item(57).ToString)
            MyBase.AddParameter("@M26B", OdbcType.Char, 3, objDataRow.Item(58).ToString)
            MyBase.AddParameter("@M26_B", OdbcType.Char, 3, objDataRow.Item(59).ToString)
            MyBase.AddParameter("@M27B", OdbcType.Char, 3, objDataRow.Item(60).ToString)
            MyBase.AddParameter("@M27_B", OdbcType.Char, 3, objDataRow.Item(61).ToString)
            MyBase.AddParameter("@M28B", OdbcType.Char, 3, objDataRow.Item(62).ToString)
            MyBase.AddParameter("@M28_B", OdbcType.Char, 3, objDataRow.Item(63).ToString)
            MyBase.AddParameter("@M29B", OdbcType.Char, 3, objDataRow.Item(64).ToString)
            MyBase.AddParameter("@M29_B", OdbcType.Char, 3, objDataRow.Item(65).ToString)
            MyBase.AddParameter("@M30B", OdbcType.Char, 3, objDataRow.Item(66).ToString)
            MyBase.AddParameter("@M30_B", OdbcType.Char, 3, objDataRow.Item(67).ToString)
            MyBase.AddParameter("@M31B", OdbcType.Char, 3, objDataRow.Item(68).ToString)
            MyBase.AddParameter("@M31_B", OdbcType.Char, 3, objDataRow.Item(69).ToString)
            MyBase.AddParameter("@M32B", OdbcType.Char, 3, objDataRow.Item(70).ToString)
            MyBase.AddParameter("@M32_B", OdbcType.Char, 3, objDataRow.Item(71).ToString)
            MyBase.AddParameter("@M33B", OdbcType.Char, 3, objDataRow.Item(72).ToString)
            MyBase.AddParameter("@M33_B", OdbcType.Char, 3, objDataRow.Item(73).ToString)
            MyBase.AddParameter("@M34B", OdbcType.Char, 3, objDataRow.Item(74).ToString)
            MyBase.AddParameter("@M34_B", OdbcType.Char, 3, objDataRow.Item(75).ToString)
            MyBase.AddParameter("@M35B", OdbcType.Char, 3, objDataRow.Item(76).ToString)
            MyBase.AddParameter("@M35_B", OdbcType.Char, 3, objDataRow.Item(77).ToString)
            MyBase.AddParameter("@M36B", OdbcType.Char, 3, objDataRow.Item(78).ToString)
            MyBase.AddParameter("@M36_B", OdbcType.Char, 3, objDataRow.Item(79).ToString)
            MyBase.AddParameter("@M37B", OdbcType.Char, 3, objDataRow.Item(80).ToString)
            MyBase.AddParameter("@M37_B", OdbcType.Char, 3, objDataRow.Item(81).ToString)
            MyBase.AddParameter("@M38B", OdbcType.Char, 3, objDataRow.Item(82).ToString)
            MyBase.AddParameter("@M38_B", OdbcType.Char, 3, objDataRow.Item(83).ToString)
            MyBase.AddParameter("@M39B", OdbcType.Char, 3, objDataRow.Item(84).ToString)
            MyBase.AddParameter("@M39_B", OdbcType.Char, 3, objDataRow.Item(85).ToString)
            MyBase.AddParameter("@M40B", OdbcType.Char, 3, objDataRow.Item(86).ToString)
            MyBase.AddParameter("@M40_B", OdbcType.Char, 3, objDataRow.Item(87).ToString)
            MyBase.AddParameter("@M41B", OdbcType.Char, 3, objDataRow.Item(88).ToString)
            MyBase.AddParameter("@M41_B", OdbcType.Char, 3, objDataRow.Item(89).ToString)
            MyBase.AddParameter("@M42B", OdbcType.Char, 3, objDataRow.Item(90).ToString)
            MyBase.AddParameter("@M42_B", OdbcType.Char, 3, objDataRow.Item(91).ToString)
            MyBase.AddParameter("@M43B", OdbcType.Char, 3, objDataRow.Item(92).ToString)
            MyBase.AddParameter("@M43_B", OdbcType.Char, 3, objDataRow.Item(93).ToString)
            MyBase.AddParameter("@M44B", OdbcType.Char, 3, objDataRow.Item(94).ToString)
            MyBase.AddParameter("@M44_B", OdbcType.Char, 3, objDataRow.Item(95).ToString)
            MyBase.AddParameter("@M45B", OdbcType.Char, 3, objDataRow.Item(96).ToString)
            MyBase.AddParameter("@M45_B", OdbcType.Char, 3, objDataRow.Item(97).ToString)
            MyBase.AddParameter("@M46B", OdbcType.Char, 3, objDataRow.Item(98).ToString)
            MyBase.AddParameter("@M46_B", OdbcType.Char, 3, objDataRow.Item(99).ToString)
            MyBase.AddParameter("@M47B", OdbcType.Char, 3, objDataRow.Item(100).ToString)
            MyBase.AddParameter("@M47_B", OdbcType.Char, 3, objDataRow.Item(101).ToString)
            MyBase.AddParameter("@M48B", OdbcType.Char, 3, objDataRow.Item(102).ToString)
            MyBase.AddParameter("@M48_B", OdbcType.Char, 3, objDataRow.Item(103).ToString)
            MyBase.AddParameter("@M49B", OdbcType.Char, 3, objDataRow.Item(104).ToString)
            MyBase.AddParameter("@M49_B", OdbcType.Char, 3, objDataRow.Item(105).ToString)
            MyBase.AddParameter("@M50B", OdbcType.Char, 3, objDataRow.Item(106).ToString)
            MyBase.AddParameter("@M50_B", OdbcType.Char, 3, objDataRow.Item(107).ToString)

            usp_ActualizaResurtidoDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarEstatusResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatusResurtido(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            usp_ActualizarEstatusResurtido = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarEstatusOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Fecha As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatusOrdeComp(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            usp_ActualizarEstatusOrdeComp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarUltimoResurtido(ByVal FecUltRes As String, ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'miguel pérez 13/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarUltimoResurtido(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FecUltResB", OdbcType.Char, 10, FecUltRes)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            usp_ActualizarUltimoResurtido = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'miguel pérez 13/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarOrdeComp(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            usp_ActualizarOrdeComp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarResurtido(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            usp_ActualizarResurtido = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPedidoPendiente(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String) As DataSet
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            usp_TraerPedidoPendiente = New DataSet
            MyBase.SQL = "CALL usp_TraerPedidoPendiente(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.FillDataSet(usp_TraerPedidoPendiente, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarPedidoPendiente(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Cantidad As Integer) As Boolean
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarPedidoPendiente(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@CantidadB", OdbcType.Int, 16, Cantidad)
            usp_ActualizarPedidoPendiente = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaPedidoPendiente(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Cantidad As Integer) As Boolean
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            MyBase.SQL = "CALL usp_CapturaPedidoPendiente(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@CantidadB", OdbcType.Int, 16, Cantidad)
            usp_CapturaPedidoPendiente = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtidoConsolidado(ByVal Fecha As String, ByVal FechaB As String) As DataSet
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            usp_TraerResurtidoConsolidado = New DataSet
            MyBase.SQL = "CALL usp_TraerResurtidoConsolidado(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@FechaBB", OdbcType.Char, 7, FechaB)
            MyBase.FillDataSet(usp_TraerResurtidoConsolidado, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtidoConsolidadoMar(ByVal Fecha As String, ByVal FechaPres As String) As DataSet
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            usp_TraerResurtidoConsolidadoMar = New DataSet
            MyBase.SQL = "CALL usp_TraerResurtidoConsolidadoMar(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@FechaPres", OdbcType.Char, 7, FechaPres)
            MyBase.FillDataSet(usp_TraerResurtidoConsolidadoMar, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerResurtidoConsolidadoSuc(ByVal Fecha As String, ByVal FechaPres As String) As DataSet
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            usp_TraerResurtidoConsolidadoSuc = New DataSet
            MyBase.SQL = "CALL usp_TraerResurtidoConsolidadoSuc(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@FechaPres", OdbcType.Char, 7, FechaPres)
            MyBase.FillDataSet(usp_TraerResurtidoConsolidadoSuc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasFechas(ByVal Marca As String, ByVal Estilon As String, ByVal FechaIni As String, ByVal FechaFin As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 04/Diciembre/2012 11:59 p.m.
        Try
            usp_TraerVentasFechas = New DataSet
            MyBase.SQL = "CALL usp_TraerVentasFechas(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@fecini", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@fecfin", OdbcType.Char, 10, FechaFin)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerVentasFechas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstilosResurtidoDet(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerEstilosResurtidoDet = New DataSet
            MyBase.SQL = "CALL usp_TraerEstilosResurtidoDet(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.FillDataSet(usp_TraerEstilosResurtidoDet, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltVenta(ByVal Marca As String, ByVal Estilon As String, ByVal Sucursal As String, ByVal FecIni As String, ByVal FecFin As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerFecUltVenta = New DataSet
            MyBase.SQL = "CALL usp_TraerFecUltVenta(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@FecFinB", OdbcType.Char, 10, FecFin)
            MyBase.FillDataSet(usp_TraerFecUltVenta, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltRecibo(ByVal Marca As String, ByVal Estilon As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerFecUltRecibo = New DataSet
            MyBase.SQL = "CALL usp_TraerFecUltRecibo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerFecUltRecibo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerMarcasPP(ByVal Sucursal As String, ByVal Marca As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerMarcasPP = New DataSet
            MyBase.SQL = "CALL usp_TraerMarcasPP(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.FillDataSet(usp_TraerMarcasPP, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoRecibo(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerUltimoRecibo = New DataSet
            MyBase.SQL = "CALL usp_TraerUltimoRecibo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.FillDataSet(usp_TraerUltimoRecibo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFecUltPedido(ByVal Marca As String, ByVal Estilon As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerFecUltPedido = New DataSet
            MyBase.SQL = "CALL usp_TraerFecUltPedido(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerFecUltPedido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPresupuesto(ByVal Sucursal As String, ByVal CostoPedido As Decimal, ByVal Proveedor As String, ByVal Fecha As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarPresupuesto(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@CostoPedidoB", OdbcType.Decimal, 6, CostoPedido)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 7, Fecha)
            usp_ActualizarPresupuesto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPresupuesto(ByVal Sucursal As String, ByVal Proveedor As String, ByVal Fecha As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerPresupuesto = New DataSet
            MyBase.SQL = "CALL usp_TraerPresupuesto(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 7, Fecha)
            MyBase.FillDataSet(usp_TraerPresupuesto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetOCMedida(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerDetOCMedida = New DataSet
            MyBase.SQL = "CALL usp_TraerDetOCMedida(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 3, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 3, Proveedor)
            MyBase.FillDataSet(usp_TraerDetOCMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOCSinEnvio(ByVal Sucursal As String, ByVal Proveedor As String, ByVal Marca As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerOCSinEnvio = New DataSet
            MyBase.SQL = "CALL usp_TraerOCSinEnvio(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.FillDataSet(usp_TraerOCSinEnvio, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolioRes(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerFolioRes = New DataSet
            MyBase.SQL = "CALL usp_TraerFolioRes(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.FillDataSet(usp_TraerFolioRes, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaResurtidoDetMed(ByVal Resurtido As Integer, ByVal Sucursal As String, ByVal Marca As String, _
                                           ByVal Estilon As String, ByVal objDataRow As DataRow) As Boolean
        'miguel pérez 5/Diciembre/2012 10:42 a.m.
        Try
            MyBase.SQL = "call usp_ActualizaResurtidoDetMed(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@EstilofB", OdbcType.Char, 14, objDataRow.Item(3).ToString)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 16, objDataRow.Item(4).ToString)
            MyBase.AddParameter("@M1B", OdbcType.Char, 3, objDataRow.Item(5).ToString)
            MyBase.AddParameter("@M1_B", OdbcType.Char, 3, objDataRow.Item(6).ToString)
            MyBase.AddParameter("@M2B", OdbcType.Char, 3, objDataRow.Item(7).ToString)
            MyBase.AddParameter("@M2_B", OdbcType.Char, 3, objDataRow.Item(8).ToString)
            MyBase.AddParameter("@M3B", OdbcType.Char, 3, objDataRow.Item(9).ToString)
            MyBase.AddParameter("@M3_B", OdbcType.Char, 3, objDataRow.Item(10).ToString)
            MyBase.AddParameter("@M4B", OdbcType.Char, 3, objDataRow.Item(11).ToString)
            MyBase.AddParameter("@M4_B", OdbcType.Char, 3, objDataRow.Item(12).ToString)
            MyBase.AddParameter("@M5B", OdbcType.Char, 3, objDataRow.Item(13).ToString)
            MyBase.AddParameter("@M5_B", OdbcType.Char, 3, objDataRow.Item(14).ToString)
            MyBase.AddParameter("@M6B", OdbcType.Char, 3, objDataRow.Item(15).ToString)
            MyBase.AddParameter("@M6_B", OdbcType.Char, 3, objDataRow.Item(16).ToString)
            MyBase.AddParameter("@M7B", OdbcType.Char, 3, objDataRow.Item(17).ToString)
            MyBase.AddParameter("@M7_B", OdbcType.Char, 3, objDataRow.Item(18).ToString)
            MyBase.AddParameter("@M8B", OdbcType.Char, 3, objDataRow.Item(19).ToString)
            MyBase.AddParameter("@M8_B", OdbcType.Char, 3, objDataRow.Item(20).ToString)
            MyBase.AddParameter("@M9B", OdbcType.Char, 3, objDataRow.Item(21).ToString)
            MyBase.AddParameter("@M9_B", OdbcType.Char, 3, objDataRow.Item(22).ToString)
            MyBase.AddParameter("@M10B", OdbcType.Char, 3, objDataRow.Item(23).ToString)
            MyBase.AddParameter("@M10_B", OdbcType.Char, 3, objDataRow.Item(24).ToString)
            MyBase.AddParameter("@M11B", OdbcType.Char, 3, objDataRow.Item(25).ToString)
            MyBase.AddParameter("@M11_B", OdbcType.Char, 3, objDataRow.Item(26).ToString)
            MyBase.AddParameter("@M12B", OdbcType.Char, 3, objDataRow.Item(27).ToString)
            MyBase.AddParameter("@M12_B", OdbcType.Char, 3, objDataRow.Item(28).ToString)
            MyBase.AddParameter("@M13B", OdbcType.Char, 3, objDataRow.Item(29).ToString)
            MyBase.AddParameter("@M13_B", OdbcType.Char, 3, objDataRow.Item(30).ToString)
            MyBase.AddParameter("@M14B", OdbcType.Char, 3, objDataRow.Item(31).ToString)
            MyBase.AddParameter("@M14_B", OdbcType.Char, 3, objDataRow.Item(32).ToString)
            MyBase.AddParameter("@M15B", OdbcType.Char, 3, objDataRow.Item(33).ToString)
            MyBase.AddParameter("@M15_B", OdbcType.Char, 3, objDataRow.Item(34).ToString)
            MyBase.AddParameter("@M16B", OdbcType.Char, 3, objDataRow.Item(35).ToString)
            MyBase.AddParameter("@M16_B", OdbcType.Char, 3, objDataRow.Item(36).ToString)
            MyBase.AddParameter("@M17B", OdbcType.Char, 3, objDataRow.Item(37).ToString)
            MyBase.AddParameter("@M17_B", OdbcType.Char, 3, objDataRow.Item(38).ToString)
            MyBase.AddParameter("@M18B", OdbcType.Char, 3, objDataRow.Item(39).ToString)
            MyBase.AddParameter("@M18_B", OdbcType.Char, 3, objDataRow.Item(40).ToString)
            MyBase.AddParameter("@M19B", OdbcType.Char, 3, objDataRow.Item(41).ToString)
            MyBase.AddParameter("@M19_B", OdbcType.Char, 3, objDataRow.Item(42).ToString)
            MyBase.AddParameter("@M20B", OdbcType.Char, 3, objDataRow.Item(43).ToString)
            MyBase.AddParameter("@M20_B", OdbcType.Char, 3, objDataRow.Item(44).ToString)
            MyBase.AddParameter("@M21B", OdbcType.Char, 3, objDataRow.Item(45).ToString)
            MyBase.AddParameter("@M21_B", OdbcType.Char, 3, objDataRow.Item(46).ToString)
            MyBase.AddParameter("@M22B", OdbcType.Char, 3, objDataRow.Item(47).ToString)
            MyBase.AddParameter("@M22_B", OdbcType.Char, 3, objDataRow.Item(48).ToString)
            MyBase.AddParameter("@M23B", OdbcType.Char, 3, objDataRow.Item(49).ToString)
            MyBase.AddParameter("@M23_B", OdbcType.Char, 3, objDataRow.Item(50).ToString)
            MyBase.AddParameter("@M24B", OdbcType.Char, 3, objDataRow.Item(51).ToString)
            MyBase.AddParameter("@M24_B", OdbcType.Char, 3, objDataRow.Item(52).ToString)
            MyBase.AddParameter("@M25B", OdbcType.Char, 3, objDataRow.Item(53).ToString)
            MyBase.AddParameter("@M25_B", OdbcType.Char, 3, objDataRow.Item(54).ToString)
            MyBase.AddParameter("@M26B", OdbcType.Char, 3, objDataRow.Item(55).ToString)
            MyBase.AddParameter("@M26_B", OdbcType.Char, 3, objDataRow.Item(56).ToString)
            MyBase.AddParameter("@M27B", OdbcType.Char, 3, objDataRow.Item(57).ToString)
            MyBase.AddParameter("@M27_B", OdbcType.Char, 3, objDataRow.Item(58).ToString)
            MyBase.AddParameter("@M28B", OdbcType.Char, 3, objDataRow.Item(59).ToString)
            MyBase.AddParameter("@M28_B", OdbcType.Char, 3, objDataRow.Item(60).ToString)
            MyBase.AddParameter("@M29B", OdbcType.Char, 3, objDataRow.Item(61).ToString)
            MyBase.AddParameter("@M29_B", OdbcType.Char, 3, objDataRow.Item(62).ToString)
            MyBase.AddParameter("@M30B", OdbcType.Char, 3, objDataRow.Item(63).ToString)
            MyBase.AddParameter("@M30_B", OdbcType.Char, 3, objDataRow.Item(64).ToString)
            MyBase.AddParameter("@M31B", OdbcType.Char, 3, objDataRow.Item(65).ToString)
            MyBase.AddParameter("@M31_B", OdbcType.Char, 3, objDataRow.Item(66).ToString)
            MyBase.AddParameter("@M32B", OdbcType.Char, 3, objDataRow.Item(67).ToString)
            MyBase.AddParameter("@M32_B", OdbcType.Char, 3, objDataRow.Item(68).ToString)
            MyBase.AddParameter("@M33B", OdbcType.Char, 3, objDataRow.Item(69).ToString)
            MyBase.AddParameter("@M33_B", OdbcType.Char, 3, objDataRow.Item(70).ToString)
            MyBase.AddParameter("@M34B", OdbcType.Char, 3, objDataRow.Item(71).ToString)
            MyBase.AddParameter("@M34_B", OdbcType.Char, 3, objDataRow.Item(72).ToString)
            MyBase.AddParameter("@M35B", OdbcType.Char, 3, objDataRow.Item(73).ToString)
            MyBase.AddParameter("@M35_B", OdbcType.Char, 3, objDataRow.Item(74).ToString)
            MyBase.AddParameter("@M36B", OdbcType.Char, 3, objDataRow.Item(75).ToString)
            MyBase.AddParameter("@M36_B", OdbcType.Char, 3, objDataRow.Item(76).ToString)
            MyBase.AddParameter("@M37B", OdbcType.Char, 3, objDataRow.Item(77).ToString)
            MyBase.AddParameter("@M37_B", OdbcType.Char, 3, objDataRow.Item(78).ToString)
            MyBase.AddParameter("@M38B", OdbcType.Char, 3, objDataRow.Item(79).ToString)
            MyBase.AddParameter("@M38_B", OdbcType.Char, 3, objDataRow.Item(80).ToString)
            MyBase.AddParameter("@M39B", OdbcType.Char, 3, objDataRow.Item(81).ToString)
            MyBase.AddParameter("@M39_B", OdbcType.Char, 3, objDataRow.Item(82).ToString)
            MyBase.AddParameter("@M40B", OdbcType.Char, 3, objDataRow.Item(83).ToString)
            MyBase.AddParameter("@M40_B", OdbcType.Char, 3, objDataRow.Item(84).ToString)
            MyBase.AddParameter("@M41B", OdbcType.Char, 3, objDataRow.Item(85).ToString)
            MyBase.AddParameter("@M41_B", OdbcType.Char, 3, objDataRow.Item(86).ToString)
            MyBase.AddParameter("@M42B", OdbcType.Char, 3, objDataRow.Item(87).ToString)
            MyBase.AddParameter("@M42_B", OdbcType.Char, 3, objDataRow.Item(88).ToString)
            MyBase.AddParameter("@M43B", OdbcType.Char, 3, objDataRow.Item(89).ToString)
            MyBase.AddParameter("@M43_B", OdbcType.Char, 3, objDataRow.Item(90).ToString)
            MyBase.AddParameter("@M44B", OdbcType.Char, 3, objDataRow.Item(91).ToString)
            MyBase.AddParameter("@M44_B", OdbcType.Char, 3, objDataRow.Item(92).ToString)
            MyBase.AddParameter("@M45B", OdbcType.Char, 3, objDataRow.Item(93).ToString)
            MyBase.AddParameter("@M45_B", OdbcType.Char, 3, objDataRow.Item(94).ToString)
            MyBase.AddParameter("@M46B", OdbcType.Char, 3, objDataRow.Item(95).ToString)
            MyBase.AddParameter("@M46_B", OdbcType.Char, 3, objDataRow.Item(96).ToString)
            MyBase.AddParameter("@M47B", OdbcType.Char, 3, objDataRow.Item(97).ToString)
            MyBase.AddParameter("@M47_B", OdbcType.Char, 3, objDataRow.Item(98).ToString)
            MyBase.AddParameter("@M48B", OdbcType.Char, 3, objDataRow.Item(99).ToString)
            MyBase.AddParameter("@M48_B", OdbcType.Char, 3, objDataRow.Item(100).ToString)
            MyBase.AddParameter("@M49B", OdbcType.Char, 3, objDataRow.Item(101).ToString)
            MyBase.AddParameter("@M49_B", OdbcType.Char, 3, objDataRow.Item(102).ToString)
            MyBase.AddParameter("@M50B", OdbcType.Char, 3, objDataRow.Item(103).ToString)
            MyBase.AddParameter("@M50_B", OdbcType.Char, 3, objDataRow.Item(104).ToString)

            usp_ActualizaResurtidoDetMed = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarDetOCMed(ByVal Ctd As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Costo As Double, ByVal CostoDesc As Double) As Boolean
        'miguel pérez 05/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarDetOCMed(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ctdB", OdbcType.Int, 16, Ctd)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 6, Medida)
            MyBase.AddParameter("@CostoB", OdbcType.Double, 9, Costo)
            MyBase.AddParameter("@CostoDescB", OdbcType.Double, 9, CostoDesc)
            usp_ActualizarDetOCMed = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDatosResurtido(ByVal Resurtido As Integer, ByVal Sucursal As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerDatosResurtido = New DataSet
            MyBase.SQL = "CALL usp_TraerDatosResurtido(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ResurtidoB", OdbcType.Int, 16, Resurtido)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 6, Sucursal)
            MyBase.FillDataSet(usp_TraerDatosResurtido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDatosArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String, ByVal Clasif As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerDatosArticulo = New DataSet
            MyBase.SQL = "CALL usp_TraerDatosArticulo(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@ClasifB", OdbcType.Char, 255, Clasif)
            MyBase.FillDataSet(usp_TraerDatosArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursal(ByVal Sucursal As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerSucursal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerSucursal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDifEstFamilia(ByVal Opcion As Integer, ByVal Descrip As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerDifEstFamilia = New DataSet
            MyBase.SQL = "CALL usp_TraerDifEstFamilia(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@Descrip", OdbcType.Char, 30, Descrip)
            MyBase.FillDataSet(usp_TraerDifEstFamilia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdEstFamilia(ByVal Clasif As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerIdEstFamilia = New DataSet
            MyBase.SQL = "CALL usp_TraerIdEstFamilia(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ClasifB", OdbcType.Char, 255, Clasif)
            MyBase.FillDataSet(usp_TraerIdEstFamilia, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetFPMedida(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal FecIni As Date, ByVal FecFin As Date) As DataSet
        'Tony García - 05/10/2013 - 10:20 a.m.
        Try
            usp_TraerDetFPMedida = New DataSet
            MyBase.SQL = "CALL usp_TraerDetFPMedida(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@Fecini", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@Fecfin", OdbcType.Date, 10, FecFin)
            MyBase.FillDataSet(usp_TraerDetFPMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProvMarcaModelo(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'miguel pérez 04/Diciembre/2012 5:00 pm
        Try
            usp_TraerProvMarcaModelo = New DataSet
            MyBase.SQL = "CALL usp_TraerProvMarcaModelo(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.FillDataSet(usp_TraerProvMarcaModelo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
