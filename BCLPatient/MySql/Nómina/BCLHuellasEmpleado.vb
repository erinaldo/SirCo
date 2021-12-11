Public Class BCLHuellasEmpleado
    'Tony Garcia - 19/Sept/2012 - 09:50 a.m.

    Implements IDisposable
    Private objDALHuellasEmpleado As DAL.DALHuellasEmpleado
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALHuellasEmpleado = New DAL.DALHuellasEmpleado(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALHuellasEmpleado.Dispose()
            objDALHuellasEmpleado = Nothing
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

    Public Function usp_TraerChecadores() As DataSet
        'Tony Garcia - 28/Septiembre/2012 - 06:35 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerChecadores = objDALHuellasEmpleado.usp_TraerChecadores()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String) As DataSet
        'Tony Garcia - 28/Sept/2012 - 6:30 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleado = objDALHuellasEmpleado.usp_TraerNomEmpleado(idEmpleado, ApPaterno, apMaterno, Nombre, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminarHuellas(ByVal IdChecador As Integer)
        'Tony Garcia - 01/Octubre/2012 - 3:30 p.m.
        Try
            usp_EliminarHuellas = objDALHuellasEmpleado.usp_EliminarHuellas(IdChecador)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerChecador(ByVal IdChecador As String, ByVal Sucursal As String) As DataSet
        'Tony Garcia - 01/Octubre/2012 - 7:00 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerChecador = objDALHuellasEmpleado.usp_TraerChecador(IdChecador, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Huella(ByVal IdChecador As Integer, ByVal IdEmpleado As Integer, _
                                        ByVal IdDedo As Integer, ByVal Template() As Byte, ByVal Fecha As DateTime)
        'Tony Garcia - 02/Octubre/2012 - 10:00 a.m.
        Try
            usp_Captura_Huella = objDALHuellasEmpleado.usp_Captura_Huella(IdChecador, IdEmpleado, IdDedo, Template, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

    Public Function usp_TraerHuellasEmp(ByVal IdEmpleado As Integer)
        'Tony Garcia - 05/Octubre/2012 - 4:00 p.m.
        Try
            usp_TraerHuellasEmp = objDALHuellasEmpleado.usp_TraerHuellasEmp(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
