Public Class BCLBitProcesos

    Implements IDisposable
    Private objDALBitProcesos As DAL.DALBitProcesos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable 
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALBitProcesos = New DAL.DALBitProcesos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALBitProcesos.Dispose()
            objDALBitProcesos = Nothing
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


    Public Function usp_PpalBitProcesos(ByVal Opcion As Integer, ByVal Fecha As Date, ByVal FechaAntiinvent As Date) As DataSet
        'Tony Garcia - 26/Abril/2014 - 11:00 am
        Try
            usp_PpalBitProcesos = objDALBitProcesos.usp_PpalBitProcesos(Opcion, Fecha, FechaAntiinvent)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
