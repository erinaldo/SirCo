Public Class BCLAnalisisFull
    Implements IDisposable
    Private objDALAnalisis As DAL.DALAnalisisFull
    Private disposedValue As Boolean = False
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAnalisis = New DAL.DALAnalisisFull(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
            objDALAnalisis.Dispose()
            objDALAnalisis = Nothing
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "
    Public Function usp_GeneraAnalisis(ByVal FechaIni As String, ByVal FechaFin As String, ByVal Marca As String, ByVal Modelo As String) As DataSet
        Try
            usp_GeneraAnalisis = objDALAnalisis.usp_GeneraAnalisis(FechaIni, FechaFin, Marca, Modelo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraAnalisisdet(ByVal Marca As String, ByVal Modelo As String) As DataSet
        Try
            usp_GeneraAnalisisdet = objDALAnalisis.usp_GeneraAnalisisdet(Marca, Modelo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
