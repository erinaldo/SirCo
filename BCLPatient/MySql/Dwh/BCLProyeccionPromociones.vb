Public Class BCLProyeccionPromociones
    'miguel pérez 09/Octubre/2012 10:43 a.m.

    Implements IDisposable
    Private objDALProyPromo As DAL.DALProyeccionPromociones
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALProyPromo = New DAL.DALProyeccionPromociones(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALProyPromo.Dispose()
            objDALProyPromo = Nothing
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

    Public Function usp_TraerVentasNetasCosto(ByVal Sucursal As String, ByVal Vendedor As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Opcion As String) As DataSet
        'miguel pérez 05/Octubre/2012 01:33 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerVentasNetasCosto = objDALProyPromo.usp_TraerVentasNetasCosto(Sucursal, Vendedor, FechaIni, FechaFin, Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
