Public Class BCLGeneraTimbrado

    Implements IDisposable
    Private objDALGeneraTimbrado As DAL.DALGeneraTimbrado
    Private disposedValue As Boolean = False        ' To detect redundant calls



#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALGeneraTimbrado = New DAL.DALGeneraTimbrado(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALGeneraTimbrado.Dispose()
            objDALGeneraTimbrado = Nothing
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

#End Region
    Public Function usp_GeneraTimbrado(ByVal Periodo As Integer) As Boolean
        'Gmanvaz 04/Febrero/2017 04:42 p.m.
        Try
            Return objDALGeneraTimbrado.usp_GeneraTimbrado(Periodo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
