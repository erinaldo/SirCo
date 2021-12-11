Public Class BCLVentaNomina
    'mreyes 23/Agosto/2012 10:01 p.m.

    Implements IDisposable
    Private objDALVentaNomina As DAL.DALVentaNomina
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALVentaNomina = New DAL.DALVentaNomina(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALVentaNomina.Dispose()
            objDALVentaNomina = Nothing
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



    Public Function usp_PpalVentaNomina(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal iddepto As Integer, ByVal idpuesto As Integer) As DataSet
        'mreyes 30/Junio/2012 10:42 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalVentaNomina = objDALVentaNomina.usp_PpalVentaNomina(Opcion, Sucursal, IdEmpleado, FechaIni, FechaFin, iddepto, idpuesto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_PpalMatchTimbrado(ByVal IdPeriodo As String, ByVal FechaIni As Date) As DataSet
        'mreyes 20/Enero/2015   05:06 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalMatchTimbrado = objDALVentaNomina.usp_PpalMatchTimbrado(IdPeriodo, FechaIni)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
