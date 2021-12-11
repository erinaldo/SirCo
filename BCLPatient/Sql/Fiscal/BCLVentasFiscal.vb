Public Class BCLTraerVentasFiscal
    Implements IDisposable
    Private objDALConsultaVentas As DAL.DALTraerVentasFiscal
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALConsultaVentas = New DAL.DALTraerVentasFiscal(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALConsultaVentas.Dispose()
            objDALConsultaVentas = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "
    Public Function usp_TraerVentaFiscal(ByVal Sucursal As String, ByVal Venta As String) As DataSet
        'fdoadame 22/Diciembre/2017   04:09 p.m.
        Try
            Return objDALConsultaVentas.usp_TraerVentaFiscal(Sucursal, Venta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_VentasFiscal(ByVal Sucursal As String, ByVal Venta As String) As DataSet
        'fdoadame 23/Diciembre/2017   10:50 a.m.
        Try
            Return objDALConsultaVentas.usp_VentasFiscal(Sucursal, Venta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalVentasFiscal(ByVal FechaInicio As String, ByVal FechaFin As String) As DataSet
        'fdoadame 28/Diciembre/2017   10:00 a.m.
        Try
            Return objDALConsultaVentas.usp_PpalVentasFiscal(FechaInicio, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class

