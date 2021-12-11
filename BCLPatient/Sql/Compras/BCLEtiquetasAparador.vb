Public Class BCLEtiquetasAparador
    'mreyes 26/Agosto/2016   12:18 p.m.

    Implements IDisposable
    Private objDALEtiquetasAparador As DAL.DALEtiquetasAparador
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALEtiquetasAparador = New DAL.DALEtiquetasAparador(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALEtiquetasAparador.Dispose()
            objDALEtiquetasAparador = Nothing
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





    Public Function usp_PpalEtiquetasAparador(ByVal IdSucursal As Integer, _
                                                ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 26/Agosto/2016   12:20 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalEtiquetasAparador = objDALEtiquetasAparador.usp_PpalEtiquetasAparador(IdSucursal, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



#End Region
End Class
