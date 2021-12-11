Public Class BCLReporteVentas
    Implements IDisposable
    Private objDALReporteVentas As DAL.DALReporteVentas
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALReporteVentas = New DAL.DALReporteVentas(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
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
    Public Function usp_PpalReporteVentas(ByVal opcion As Integer, ByVal opcion2 As Integer, ByVal FechaA As Date, ByVal FechaB As Date, ByVal distribB As String, ByVal sucursalB As String, ByVal ventaB As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_PpalReporteVentas = objDALReporteVentas.usp_PpalReporteVentas(opcion, opcion2, FechaA, FechaB, distribB, sucursalB, ventaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalReporteVentas2(ByVal opcion As Integer, ByVal FechaA As Date, ByVal FechaB As Date, ByVal distribB As String, ByVal sucursalB As String, ByVal ventaB As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_PpalReporteVentas2 = objDALReporteVentas.usp_PpalReporteVentas2(opcion, FechaA, FechaB, distribB, sucursalB, ventaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxFechaCargo() As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_TraerMaxFechaCargo = objDALReporteVentas.usp_TraerMaxFechaCargo()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
