Public Class BCLSobranteInv


    Implements IDisposable
    Private objDALSobranteInv As DAL.DALSobranteInv
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALSobranteInv = New DAL.DALSobranteInv(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALSobranteInv.Dispose()
            objDALSobranteInv = Nothing
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

    Public Function usp_PpalSobranteInv(ByVal Sucursal As String) As DataSet
        'mreyes 25/Mayo/2016    11:31 a.m.
        Try
            usp_PpalSobranteInv = objDALSobranteInv.usp_PpalSobranteInv(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
               ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSucursalEnInventario(ByVal Sucursal As String) As DataSet
        'mreyes 25/Mayo/2016    11:31 a.m.
        Try
            usp_PpalSucursalEnInventario = objDALSobranteInv.usp_PpalSucursalEnInventario(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
               ExceptionErr.InnerException)
        End Try
    End Function

End Class


