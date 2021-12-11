Public Class BCLExistenciaActual

    Implements IDisposable
    Private objDALExistenciaActual As DAL.DALExistenciaActual
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALExistenciaActual = New DAL.DALExistenciaActual(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALExistenciaActual.Dispose()
            objDALExistenciaActual = Nothing
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

    Public Function usp_PpalEstructuraYExistActual(ByVal fechaIniB As String, ByVal fechaFinB As String, ByVal Division As String, ByVal Depto As String, ByVal Linea As String,
                                                   ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String) As DataSet
        'mreyes 25/Mayo/2016    11:31 a.m.
        Try
            usp_PpalEstructuraYExistActual = objDALExistenciaActual.usp_PpalEstructuraYExistActual(fechaIniB, fechaFinB, Division, Depto, Linea, L1, L2, L3, L4, L5, L6)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
               ExceptionErr.InnerException)
        End Try
    End Function

End Class
