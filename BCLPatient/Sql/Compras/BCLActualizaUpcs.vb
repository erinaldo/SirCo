Public Class BCLActualizaUpcs
    'josue hernandez 02/Octubre/2020   17:10
    Implements IDisposable
    Private objDALActualizaUpcs As DAL.DALActualizaUpcs
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALActualizaUpcs = New DAL.DALActualizaUpcs(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALActualizaUpcs.Dispose()
            objDALActualizaUpcs = Nothing
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
    Public Function usp_ActualizaUpcs(ByVal IDUsuario As Integer) As DataSet
        'josue hernandez 02/Octubre/2020   17:11
        Try
            usp_ActualizaUpcs = objDALActualizaUpcs.usp_ActualizaUpcs(IDUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
