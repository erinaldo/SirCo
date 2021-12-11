Public Class BCLChecador
    'mreyes 01/Junio/2012 06:19 p.m.
    Implements IDisposable
    Private objDALChecador As DAL.DALChecador
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALChecador = New DAL.DALChecador(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALChecador.Dispose()
            objDALChecador = Nothing
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



    Public Function usp_TraerChecador(ByVal idchecador As Integer, ByVal Sucursal As String) As DataSet
        'mreyes 01/Junio/2012 06:58 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerChecador = objDALChecador.usp_TraerChecador(idchecador, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMarcaje(ByVal IdEmpleado As Integer, ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet

        'mreyes 23/Junio/2012 02:01 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalMarcaje = objDALChecador.usp_PpalMarcaje(IdEmpleado, Sucursal, IdDepto, IdPuesto, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Checada(ByVal Opcion As Integer, ByVal idchecador As Integer, ByVal Fecha As Date, ByVal Hora As String, ByVal idempleado As Integer) As Boolean
        'mreyes 01/Junio/2012 07:19 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALChecador.usp_Captura_Checada(Opcion, idchecador, Fecha, Hora, idempleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerChecada(ByVal IdEmpleado As Integer, ByVal Fecha As Date) As DataSet
        'mreyes 22/Junio/2012 09:31 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALChecador.usp_TraerChecada(IdEmpleado, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
