Public Class DALApendiceSQL
    Inherits DALBase
    Private objDALConsultasVentas As DAL.DALTraerVentasFiscal
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region
#Region " Public Section Functions "
    Public Function usp_Traer_Forma_Pago(ByVal fecha As String, ByVal Sucursal As String) As DataSet
        'mreyes 27/Diciembre/2017   07:08 p.m.
        Try
            usp_Traer_Forma_Pago = New DataSet
            MyBase.SQL = "usp_Traer_Forma_Pago"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, fecha)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.FillDataSet(usp_Traer_Forma_Pago, "dwh")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_traer_desglose_movimientos_x_articulo(ByVal fecha As String, ByVal Sucursal As String) As DataSet
        'fdoadame 27/Diciembre/2017   09:56 a.m.
        Try
            usp_traer_desglose_movimientos_x_articulo = New DataSet
            MyBase.SQL = "usp_traer_desglose_movimientos_x_articulo"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, fecha)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.FillDataSet(usp_traer_desglose_movimientos_x_articulo, "dwh")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSucursalTR(ByVal Sucursal As String) As DataSet
        'fdoadame 27/Diciembre/2017 11:42 a.m.
        Try
            usp_TraerSucursalTR = New DataSet
            MyBase.SQL = "usp_TraerSucursalTR"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerSucursalTR, "dhw")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region


End Class
