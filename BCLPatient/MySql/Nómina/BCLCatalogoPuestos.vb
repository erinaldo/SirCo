Public Class BCLCatalogoPuestos
    'mreyes 05/Junio/2012 10:28 a.m.
    Implements IDisposable
    Private objDALCatalogoPuestos As DAL.DALCatalogoPuestos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoPuestos = New DAL.DALCatalogoPuestos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoPuestos.Dispose()
            objDALCatalogoPuestos = Nothing
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





    Public Function usp_PpalCatalogoPuesto(ByVal Puesto As Integer, ByVal IdDepto As Integer, ByVal ClavePuesto As String, ByVal Descrip As String) As DataSet
        'mreyes 05/Junio/2012 10:01 a.m.
        Try

            usp_PpalCatalogoPuesto = objDALCatalogoPuestos.usp_PpalCatalogoPuesto(Puesto, IdDepto, ClavePuesto, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Captura_Puesto(ByVal Accion As Integer, ByVal IdPuesto As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String, ByVal Comision As String, ByVal TVenta As String) As Boolean
        'mreyes 05/Mayo/2012 12:10 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoPuestos.usp_Captura_Puesto(Accion, IdPuesto, IdDepto, Clave, Descrip, Comision, TVenta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
