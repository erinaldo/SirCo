Public Class BCLDevoluciones
    'mreyes 29/Marzo/2012 09:58 p.m.

    Implements IDisposable
    Private objDALDevoluciones As DAL.DALDevoluciones
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALDevoluciones = New DAL.DALDevoluciones(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALDevoluciones.Dispose()
            objDALDevoluciones = Nothing
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







    Public Function usp_PpalDevoluciones(ByVal Sucursal As String, ByVal DevIni As String, ByVal DevFin As String, ByVal FactProvIni As String, ByVal FactProvFin As String, _
                                         ByVal Marca As String, ByVal Proveedor As String, ByVal Status As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String, ByVal VenceIni As String, ByVal VenceFin As String, _
                                         ByVal IdFolioSucIni As String, ByVal IdFolioSucFin As String) As DataSet
        'mreyes 29/Marzo/2012 10:02 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalDevoluciones = objDALDevoluciones.usp_PpalDevoluciones(Sucursal, DevIni, DevFin, FactProvIni, FactProvFin, Marca, _
                                                                     Proveedor, Status, FechaIni, _
                                                                    Fechafin, VenceIni, VenceFin, IdFolioSucIni, IdFolioSucFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
