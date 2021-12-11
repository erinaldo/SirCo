Public Class BCLCostoMargen
    'mreyes 02/Agosto/2017   07:03 p.m.

    Implements IDisposable
    Private objDALCostoMargen As DAL.DALcostomargen
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCostoMargen = New DAL.DALcostomargen(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCostoMargen.Dispose()
            objDALCostoMargen = Nothing
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
    Public Function usp_CapturaProyeccionReciboL1(Opcion As Integer, Linea As String, L1 As String, Recibo1 As Integer, Recibo2 As Integer, Recibo3 As Integer, Recibo4 As Integer, Recibo5 As Integer, Recibo6 As Integer, Recibo7 As Integer, Recibo8 As Integer, Recibo9 As Integer, Recibo10 As Integer, Recibo11 As Integer, Recibo12 As Integer) As Boolean
        'mreyes 30/Agosto/2017  05:32 p.m.
        Try

            'Call the data component to add the new group
            Return objDALCostoMargen.usp_CapturaProyeccionReciboL1(Opcion, Linea, L1, Recibo1, Recibo2, Recibo3, Recibo4, Recibo5, Recibo6, Recibo7, Recibo8, Recibo9, Recibo10, Recibo11, Recibo12)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraProyeccionCompra(ByVal FechaIni As String, ByVal FechaFin As String) As Boolean
        'mreyes 30/Agosto/201705:53 p.m.
        Try

            'Call the data component to add the new group
            Return objDALCostoMargen.usp_GeneraProyeccionCompra(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCostoMargenSVenta(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 08/Agosto/2017  04:39 p.m.
        Try
            Return objDALCostoMargen.usp_PpalCostoMargenSVenta(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCostoMargen(ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'mreyes 02/Agosto/2017  07:06 p.m.
        Try
            Return objDALCostoMargen.usp_PpalCostoMargen(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalProyeccionComprasL1() As DataSet
        'mreyes 14/Agosto/2017  04:27 p.m.
        Try
            Return objDALCostoMargen.usp_PpalProyeccionComprasL1()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
