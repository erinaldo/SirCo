Public Class BCLCapturaUPCs
    'Josue Hernandez 30/Septiembre/2020   17:07
    Implements IDisposable
    Private objDALCapturaUPCs As DAL.DALCapturaUPCs
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCapturaUPCs = New DAL.DALCapturaUPCs(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCapturaUPCs.Dispose()
            objDALCapturaUPCs = Nothing
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
    Public Function usp_CapturaUPCs(ByVal Marca As String, ByVal Modelo As String,
            ByVal Talla As String, ByVal UPC As String, ByVal IDUsuario As Integer) As DataSet
        'josue hernandez 30/Septiembre/2020   17:13
        Try
            usp_CapturaUPCs = objDALCapturaUPCs.usp_CapturaUPCs(Marca, Modelo, Talla, UPC, IDUsuario)
        Catch ExceptionErr As Exception   
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
