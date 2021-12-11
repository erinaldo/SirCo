Public Class BCLInventario
    'mreyes 18/Octubre/2012 02:06 p.m.

    Implements IDisposable
    Private objDALInventario As DAL.DALInventario
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALInventario = New DAL.DALInventario(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALInventario.Dispose()
            objDALInventario = Nothing
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
    Public Function usp_PpalInventario(ByVal Opcion As String, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal Proveedor As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_PpalInventario = objDALInventario.usp_PpalInventario(Opcion, Sucursal, Marca, Estilon, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CalculaAntInvent(ByVal Sucursal As String, ByVal Marca As String) As Boolean
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_CalculaAntInvent = objDALInventario.usp_CalculaAntInvent(Sucursal, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    
#End Region
End Class
