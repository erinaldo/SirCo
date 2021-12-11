Public Class BCLEstilosSinExist
    ''Tony Garcia 03/Noviembre/2012 - 04:45 p.m.
    Implements IDisposable
    Private objDALEstilosSinExist As DAL.DALEstilosSinExist
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALEstilosSinExist = New DAL.DALEstilosSinExist(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALEstilosSinExist.Dispose()
            objDALEstilosSinExist = Nothing
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

    Public Function usp_PpalEstilosSinExist(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, _
                                            ByVal FecIni As DateTime, ByVal FecFin As DateTime)
        'Tony Garcia - 03/Diciembre/2012 - 5:10 p.m

        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALEstilosSinExist.usp_PpalEstilosSinExist(Sucursal, Marca, Estilon, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
