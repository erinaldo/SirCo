Imports System.Data.Odbc
'Tony García 

Public Class DALCompras
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

    Public Function usp_PpalPptoCompras(ByVal Opcion As Integer) As DataSet
        'Tony García - 31/Octubre/2013 10:43 a.m.
        Try
            usp_PpalPptoCompras = New DataSet
            MyBase.SQL = "CALL usp_PpalPptoCompras(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 2, Opcion)

            MyBase.FillDataSet(usp_PpalPptoCompras, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPptoComprasEst(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal DescripDivision As String, _
                                    ByVal DescripDepto As String, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String) As DataSet
        'Tony García - 31/Octubre/2013 11:43 a.m.
        Try
            usp_PpalPptoComprasEst = New DataSet
            MyBase.SQL = "CALL usp_PpalPptoComprasEst(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 2, Opcion)
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@divisionb", OdbcType.Char, 30, DescripDivision)
            MyBase.AddParameter("@deptob", OdbcType.Char, 30, DescripDepto)
            MyBase.AddParameter("@familiab", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@lineab", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@l1b", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@l2b", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@l3b", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@l4b", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@l5b", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@l6b", OdbcType.Char, 30, DescripL6)

            MyBase.FillDataSet(usp_PpalPptoComprasEst, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPptoVentaEst(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal DescripDivision As String, _
                                    ByVal DescripDepto As String, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String) As DataSet
        'Tony García - 31/Octubre/2013 11:43 a.m.
        Try
            usp_PpalPptoVentaEst = New DataSet
            MyBase.SQL = "CALL usp_PpalPptoVentaEst(?,?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 2, Opcion)
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@divisionb", OdbcType.Char, 30, DescripDivision)
            MyBase.AddParameter("@deptob", OdbcType.Char, 30, DescripDepto)
            MyBase.AddParameter("@familiab", OdbcType.Char, 30, DescripFamilia)
            MyBase.AddParameter("@lineab", OdbcType.Char, 30, DescripLinea)
            MyBase.AddParameter("@l1b", OdbcType.Char, 30, DescripL1)
            MyBase.AddParameter("@l2b", OdbcType.Char, 30, DescripL2)
            MyBase.AddParameter("@l3b", OdbcType.Char, 30, DescripL3)
            MyBase.AddParameter("@l4b", OdbcType.Char, 30, DescripL4)
            MyBase.AddParameter("@l5b", OdbcType.Char, 30, DescripL5)
            MyBase.AddParameter("@l6b", OdbcType.Char, 30, DescripL6)

            MyBase.FillDataSet(usp_PpalPptoVentaEst, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOCParaCancelar(ByVal Fecha As Date) As DataSet
        'Miguel Pérez- 23/Dic/2013 
        Try
            usp_TraerOCParaCancelar = New DataSet
            MyBase.SQL = "CALL usp_TraerOCParaCancelar(?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@FechaB", OdbcType.Date, 10, Fecha)

            MyBase.FillDataSet(usp_TraerOCParaCancelar, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOCCanceladas(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Estatus As String) As DataSet
        'Miguel Pérez- 23/Dic/2013 
        Try
            usp_TraerOCCanceladas = New DataSet
            MyBase.SQL = "CALL usp_TraerOCCanceladas(?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 10, FechaIni)
            MyBase.AddParameter("@FechaFinB", OdbcType.Date, 10, FechaFin)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)

            MyBase.FillDataSet(usp_TraerOCCanceladas, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaOCCancel(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Estatus As String, ByVal Proveedor As String, ByVal FecCancela As Date, ByVal UsuarioCancela As String, ByVal FecReactiva As Date, ByVal UsuarioReactiva As String, ByVal Motivo As String) As Boolean
        'Tony Garcia 26/Junio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_CapturaOCCancel(?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idCuentaB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@SubtotalB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@GastosB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@ImpuestoB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@CargoB", OdbcType.Date, 10, FecCancela)
            MyBase.AddParameter("@CreditoB", OdbcType.Char, 30, UsuarioCancela)
            MyBase.AddParameter("@DescuentoB", OdbcType.Date, 10, FecReactiva)
            MyBase.AddParameter("@TotalB", OdbcType.Char, 30, UsuarioReactiva)
            MyBase.AddParameter("@StatusB", OdbcType.Char, 100, Motivo)

            usp_CapturaOCCancel = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarOCCancel(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal FechaReactiva As Date, ByVal UsuarioReactiva As String, ByVal Motivo As String) As Boolean
        'miguel pérez 10/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarOCCancel(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@FecReactivaB", OdbcType.Date, 10, FechaReactiva)
            MyBase.AddParameter("@UsuarioReactivaB", OdbcType.Char, 30, UsuarioReactiva)
            MyBase.AddParameter("@MotivoB", OdbcType.Char, 100, Motivo)
            usp_ActualizarOCCancel = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarFechasDetOC(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal FecEntrega As Date, ByVal FecCancela As Date) As Boolean
        'miguel pérez 10/Diciembre/2012 12:13 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarFechasDetOC(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@OrdeCompB", OdbcType.Char, 6, OrdeComp)
            MyBase.AddParameter("@FecEntregaB", OdbcType.Date, 10, FecEntrega)
            MyBase.AddParameter("@FecCancelaB", OdbcType.Date, 10, FecCancela)
            usp_ActualizarFechasDetOC = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraPrecios() As Boolean
        'mreyes 21/Noviembre/2018   12:05 p.m.
        Try
            MyBase.SQL = "CALL usp_GeneraPrecios()"

            MyBase.InitializeCommand()



            usp_GeneraPrecios = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_QuitarParesUnicos(Marca As String, Modelo As String) As Boolean
        'mreyes 21/Noviembre/2018   12:05 p.m.
        Try
            MyBase.SQL = "CALL usp_QuitarParesUnicos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Marcab", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Modelob", OdbcType.Char, 7, Modelo)

            usp_QuitarParesUnicos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
