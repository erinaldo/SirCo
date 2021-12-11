Imports System.Data.Odbc
'mreyes 18/Junio/2015   05:46 p.m.

Public Class DALInventarios
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



    Public Function usp_ActualizarSucursalInv(ByVal Opcion As Integer, ByVal Sucursal As String) As Boolean
        'mreyes 18/Junio/2015   05:59 p.m.
        Try
            MyBase.SQL = "call usp_ActualizarSucursalInv(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@OpcionB", OdbcType.Int, 6, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)

            usp_ActualizarSucursalInv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaInvFis(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal NumIf As Integer, _
                                            ByVal Estatus As String, ByVal Fecha As String, ByVal Hora As String, ByVal Observa As String, ByVal Usuario As String, _
                                            ByVal idusuario As Integer) As Boolean

        'mreyes 19/Junio/2015   01:05 p.m.
        Try
            MyBase.SQL = "call usp_CapturaInvFis(?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)

            MyBase.AddParameter("@NumIfB", OdbcType.Int, 16, NumIf)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@FechaB", OdbcType.Char, 10, Fecha)
            MyBase.AddParameter("@HoraB", OdbcType.Char, 8, Hora)
            MyBase.AddParameter("@ObservaB", OdbcType.Char, 60, Observa)
            MyBase.AddParameter("@UsuarioB", OdbcType.Char, 8, Usuario)

            MyBase.AddParameter("@IdUsuarioB", OdbcType.SmallInt, 4, idusuario)

            usp_CapturaInvFis = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_CapturaLeerSeriesInv(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal NumIf As Integer, ByVal Archivo As String, ByVal Serie As String, ByVal IdUsuario As String) As Boolean

        'mreyes 19/Junio/2015   01:05 p.m.
        Try
            MyBase.SQL = "call usp_CapturaLeerSeriesInv(?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NumIfB", OdbcType.Int, 8, NumIf)
            MyBase.AddParameter("@ArchivoB", OdbcType.Char, 100, Archivo)


            MyBase.AddParameter("@Serieb", OdbcType.Char, 13, Serie)

            MyBase.AddParameter("@IdUsuarioB", OdbcType.SmallInt, 4, IdUsuario)

            usp_CapturaLeerSeriesInv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInvFis(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal NumIf As Integer, ByVal FechaIni As String) As DataSet
        'mreyes 24/Junio/2015   12:52 p.m.
        Try
            usp_PpalInvFis = New DataSet
            MyBase.SQL = "CALL usp_PpalInvFis(?,?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@Opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)


            MyBase.AddParameter("@FolioB", OdbcType.Char, 8, Folio)
            MyBase.AddParameter("@NumIfB", OdbcType.Int, 8, NumIf)

            MyBase.AddParameter("@fechainiB", OdbcType.Char, 10, FechaIni)


            MyBase.FillDataSet(usp_PpalInvFis, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaDet_If(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Serie As String, ByVal Ctd As Integer, ByVal Costo As Double, ByVal Precio As Double) As Boolean

        'mreyes 23/Junio/2015   10:33 a.m.

        Try
            MyBase.SQL = "call usp_CapturaDet_If(?,?,?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FolioB", OdbcType.Char, 6, Folio)


            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@EstilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@CorridaB", OdbcType.Char, 1, Corrida)
            MyBase.AddParameter("@MedidaB", OdbcType.Char, 3, Medida)
            MyBase.AddParameter("@serieB", OdbcType.Char, 13, Serie)

            MyBase.AddParameter("@ctdb", OdbcType.Int, 8, Ctd)
            MyBase.AddParameter("@costoB", OdbcType.Double, 9, Costo)
            MyBase.AddParameter("@precioB", OdbcType.Double, 9, Precio)


            usp_CapturaDet_If = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSubirInv(ByVal Sucursal As String, ByVal NumInv As Integer, ByVal GeneradoB As Integer) As DataSet
        'mreyes 22/Junio/2015   05:39 p.m.
        Try
            usp_PpalSubirInv = New DataSet
            MyBase.SQL = "CALL usp_PpalSubirInv(?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@NumInvB", OdbcType.Int, 8, NumInv)
            MyBase.AddParameter("@generadob", OdbcType.Int, 8, GeneradoB)



            MyBase.FillDataSet(usp_PpalSubirInv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
