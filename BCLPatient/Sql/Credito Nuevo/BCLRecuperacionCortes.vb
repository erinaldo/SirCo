Public Class BCLRecuperacionCortes
    Implements IDisposable
    Private objDALRecuperacionCortes As DAL.DALRecuperacionCortes
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALRecuperacionCortes = New DAL.DALRecuperacionCortes(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALRecuperacionCortes.Dispose()
            objDALRecuperacionCortes = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "
    Public Function usp_Ppalrecuperacioncortes(ByVal Año As Integer) As DataSet
        'Tony Garcia - 22/Julio/2013 - 04:30 p.m.
        Try
            'Call the data component to get all groups
            usp_Ppalrecuperacioncortes = objDALRecuperacionCortes.usp_Ppalrecuperacioncortes(Año)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region


End Class
