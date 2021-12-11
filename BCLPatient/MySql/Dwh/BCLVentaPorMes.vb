Public Class BCLVentaPorMes

    Implements IDisposable
    Private objDALVentaPorMes As DAL.DALVentaPorMes
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
        objDALVentaPorMes = New DAL.DALVentaPorMes(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALVentaPorMes.Dispose()
            objDALVentaPorMes = Nothing
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

    Public Function usp_PpalVentaPorMes(ByVal año As String) As DataSet
        'mreyes 25/Mayo/2016    11:31 a.m.
        Try
            usp_PpalVentaPorMes = objDALVentaPorMes.usp_PpalVentaPorMes(año)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
               ExceptionErr.InnerException)
        End Try
    End Function


End Class
