Public Class BCLCatalogoFrecPago
    'mreyes 18/Junio/2012 11:09 a.m.
    Implements IDisposable
    Private objDALCatalogoFrecPago As DAL.DALCatalogoFrecPago
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoFrecPago = New DAL.DALCatalogoFrecPago(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoFrecPago.Dispose()
            objDALCatalogoFrecPago = Nothing
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





    Public Function usp_PpalCatalogoFrecPago(ByVal Clave As String) As DataSet
        'mreyes 19/Junio/2012 
        Try

            usp_PpalCatalogoFrecPago = objDALCatalogoFrecPago.usp_PpalCatalogoFrecPago(Clave)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_FrecPago(ByVal Accion As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'mreyes 05/Mayo/2012 12:10 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoFrecPago.usp_Captura_FrecPago(Accion, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
