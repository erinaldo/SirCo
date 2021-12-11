Public Class DALTraerVentasFiscal
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
    Public Function usp_TraerVentaFiscal(ByVal Sucursal As String, ByVal Venta As String) As DataSet
        'fdoadame 22/Diciembre/2017   04:06 p.m.
        Try
            usp_TraerVentaFiscal = New DataSet
            MyBase.SQL = "usp_TraerVentaFiscal"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 3, Sucursal)
            MyBase.AddParameter("@Venta", SqlDbType.VarChar, 6, Venta)
            MyBase.FillDataSet(usp_TraerVentaFiscal, "dwh")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_VentasFiscal(ByVal Sucursal As String, ByVal Venta As String) As DataSet
        'fdoadame 23/Diciembre/2017   10:52 a.m.
        Try
            usp_VentasFiscal = New DataSet
            MyBase.SQL = "usp_VentasFiscal"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 3, Sucursal)
            MyBase.AddParameter("@Venta", SqlDbType.VarChar, 6, Venta)
            MyBase.FillDataSet(usp_VentasFiscal, "dwh")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try

    End Function
    Public Function usp_PpalVentasFiscal(ByVal FechaInicio As String, ByVal FechaFin As String) As DataSet
        'fdoadame 28/Diciembre/2017   10:00 a.m.
        Try
            usp_PpalVentasFiscal = New DataSet
            MyBase.SQL = "usp_PpalVentasFiscal"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaInicio", SqlDbType.Date, 10, FechaInicio)
            MyBase.AddParameter("@FechaFin", SqlDbType.Date, 10, FechaFin)
            MyBase.FillDataSet(usp_PpalVentasFiscal, "dwh")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
