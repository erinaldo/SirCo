
Imports System.Data.Odbc
Public Class DALApendice


    Inherits DALOdbc

#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

    Public Function usp_traer_detalle_ventas_por_articulos(ByVal fecha As String, ByVal sucursal As String, ByVal tipoart As String) As DataSet
        Try
            usp_traer_detalle_ventas_por_articulos = New DataSet
            MyBase.SQL = "CALL usp_traer_detalle_ventas_por_articulos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, fecha)
            MyBase.AddParameter("@sucursal ", OdbcType.Char, 2, sucursal)
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, tipoart)
            ' '2013-05-04','02','C'
0:
            MyBase.FillDataSet(usp_traer_detalle_ventas_por_articulos, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_traer_forma_pago(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_forma_pago = New DataSet
            MyBase.SQL = "CALL usp_traer_forma_pago(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, fecha)
            MyBase.AddParameter("@sucursal ", OdbcType.Char, 2, sucursal)

            MyBase.FillDataSet(usp_traer_forma_pago, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_traer_consecutivo_folio(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_consecutivo_folio = New DataSet
            MyBase.SQL = "CALL usp_traer_consecutivo_folio(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, fecha)
            MyBase.AddParameter("@sucursal ", OdbcType.Char, 2, sucursal)

            MyBase.FillDataSet(usp_traer_consecutivo_folio, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_traer_Cancelados_NoAplicados(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_Cancelados_NoAplicados = New DataSet
            MyBase.SQL = "CALL usp_traer_Cancelados_NoAplicados(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, fecha)
            MyBase.AddParameter("@sucursal ", OdbcType.Char, 2, sucursal)

            MyBase.FillDataSet(usp_traer_Cancelados_NoAplicados, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_traer_detalle_Devoluciones(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_detalle_Devoluciones = New DataSet
            MyBase.SQL = "CALL usp_traer_detalle_Devoluciones(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, fecha)
            MyBase.AddParameter("@sucursal ", OdbcType.Char, 2, sucursal)

            MyBase.FillDataSet(usp_traer_detalle_Devoluciones, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_traer_desglose_movimientos_x_articulo(ByVal fecha As String, ByVal sucursal As String) As DataSet
        Try
            usp_traer_desglose_movimientos_x_articulo = New DataSet
            MyBase.SQL = "CALL usp_traer_desglose_movimientos_x_articulo(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, fecha)
            MyBase.AddParameter("@sucursal ", OdbcType.Char, 2, sucursal)

            MyBase.FillDataSet(usp_traer_desglose_movimientos_x_articulo, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Cargar_Apendice(ByVal opcion As Integer, ByVal sucursal As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal Importe As Double, ByVal porcentaje As Integer, ByVal Cajero As String) As DataSet
        Try
            usp_Cargar_Apendice = New DataSet
            MyBase.SQL = "CALL usp_Cargar_Apendice(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Char, 1, opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, sucursal)
            MyBase.AddParameter("@fechaInicio", OdbcType.Char, 10, fechaInicio)
            MyBase.AddParameter("@fechaFin ", OdbcType.Char, 10, fechaFin)
            MyBase.AddParameter("@Importe", OdbcType.Double, 12, Importe)
            MyBase.AddParameter("@porcentaje ", OdbcType.Int, 2, porcentaje)
            MyBase.AddParameter("@CajeroB ", OdbcType.Char, 2, Cajero)

            MyBase.FillDataSet(usp_Cargar_Apendice, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


End Class
