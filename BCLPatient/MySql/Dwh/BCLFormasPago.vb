Public Class BCLFormasPago
    'mreyes 18/Octubre/2012 02:06 p.m.

    Implements IDisposable
    Private objDALAntiInvent As DAL.DALFormasPago
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAntiInvent = New DAL.DALFormasPago(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALAntiInvent.Dispose()
            objDALAntiInvent = Nothing
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
    Public Function usp_TraerFormasPago(ByVal Sucursal As String, ByVal FecIniA As String, ByVal FecIniB As String, ByVal IVA As Decimal, ByVal MInicio As String) As DataSet
        'mreyes 18/Octubre/2012 04:08 p.m.
        Try
            usp_TraerFormasPago = objDALAntiInvent.usp_TraerFormasPago(Sucursal, FecIniA, FecIniB, IVA, MInicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
