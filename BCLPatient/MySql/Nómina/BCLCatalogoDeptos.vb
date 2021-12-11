Public Class BCLCatalogoDeptos
    'mreyes 04/Junio/2012 10:26 a.m.
    Implements IDisposable
    Private objDALCatalogoDeptos As DAL.DALCatalogoDeptos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoDeptos = New DAL.DALCatalogoDeptos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoDeptos.Dispose()
            objDALCatalogoDeptos = Nothing
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




    Public Function usp_PpalCatalogoDepto(ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As DataSet
        'mreyes 04/Junio/2012 10:37 a.m.
        Try

            usp_PpalCatalogoDepto = objDALCatalogoDeptos.usp_PpalCatalogoDepto(IdDepto, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoPuesto(ByVal Puesto As Integer, ByVal IdDepto As Integer, ByVal Descrip As String) As DataSet
        'mreyes 05/Junio/2012 10:01 a.m.
        Try

            usp_PpalCatalogoPuesto = objDALCatalogoDeptos.usp_PpalCatalogoPuesto(Puesto, IdDepto, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Depto(ByVal Accion As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'mreyes 04/Junio/2012 10:42 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoDeptos.usp_Captura_Depto(Accion, IdDepto, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
