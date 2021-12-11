Public Class BCLCreditoNew
    Implements IDisposable
    Private objDALCreditoNew As DAL.DALCreditoNew
    Private disposedValue As Boolean = False

    'jvargas 23/agosto/2018  09:28 a.m.

    Public Sub New(ByVal Constring As String)
9:      objDALCreditoNew = New DAL.DALCreditoNew(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCreditoNew.Dispose()
            objDALCreditoNew = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function usp_PpalEstadoCarteraNew(ByVal Opcion As Integer, ByVal fecha As Date) As DataSet
        'jvargas 23/agosto/2018  09:28 a.m.
        Try
            usp_PpalEstadoCarteraNew = objDALCreditoNew.usp_PpalEstadoCarteraNew(Opcion, fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalEstadoCarteraDrillDownNew(ByVal fecha_hasta As Date, tipo_cartera As Integer, id_consulta As Integer) As DataSet
        'jvargas 23/agosto/2018  09:28 a.m.
        Try
            usp_PpalEstadoCarteraDrillDownNew = objDALCreditoNew.usp_PpalEstadoCarteraDrillDownNew(fecha_hasta, tipo_cartera, id_consulta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
