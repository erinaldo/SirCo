Public Class BCLUPCs
    Implements IDisposable
    Private objDALLineo As DAL.DALUPCs
    Private disposedValue As Boolean = False
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALLineo = New DAL.DALUPCs(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
            objDALLineo.Dispose()
            objDALLineo = Nothing
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


#Region " Public Section Functions "
    Public Function usp_UPCs(ByVal Ruta As String) As Boolean
        Try
            usp_UPCs = objDALLineo.usp_UPCs(Ruta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
