Public Class BCLSeguimientoCedis
    'josue hernandez 26/Septiembre/2020   09:58 a.m.
    Implements IDisposable
    Private objDALSeguimientoCedis As DAL.DALSeguimientoCedis
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALSeguimientoCedis = New DAL.DALSeguimientoCedis(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALSeguimientoCedis.Dispose()
            objDALSeguimientoCedis = Nothing
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

#Region " Public Patient Functions "
    Public Function usp_PpalSeguimientoCedis(ByVal FechIni As String, ByVal FechFin As String) As DataSet
        'josue hernandez 26/Septiembre/2020   10:02 a.m.
        Try
            usp_PpalSeguimientoCedis = objDALSeguimientoCedis.usp_PpalSeguimientoCedis(FechIni, FechFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
