Public Class BCLEstructura

    Implements IDisposable
    Private objDALEstructura As DAL.DALEstructura
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALEstructura = New DAL.DALEstructura(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALEstructura.Dispose()
            objDALEstructura = Nothing
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

    Public Function usp_TraerEstDivisiones(ByVal Id As Integer, ByVal Clave As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstDivisiones = objDALEstructura.usp_TraerEstDivisiones(Id, Clave)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstDivisiones(ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstDivisiones = objDALEstructura.usp_CapturaEstDivisiones(Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstDepto(ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descripcion As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstDepto = objDALEstructura.usp_TraerEstDepto(IdDepto, idDivisiones, Clave, Opcion, Descripcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstDepto(ByVal IdDivisiones As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstDepto = objDALEstructura.usp_CapturaEstDepto(IdDivisiones, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstDepto(ByVal Id As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:26 p.m.

        Try
            'Call the data component to get all groups
            usp_ActualizarEstDepto = objDALEstructura.usp_ActualizarEstDepto(Id, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstFamilia(ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstFamilia = objDALEstructura.usp_TraerEstFamilia(IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstFamilia(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstFamilia = objDALEstructura.usp_CapturaEstFamilia(IdDivisiones, IdDepto, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstFamilia(ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:26 p.m.

        Try
            'Call the data component to get all groups
            usp_ActualizarEstFamilia = objDALEstructura.usp_ActualizarEstFamilia(IdFamilia, IdDepto, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstLinea(ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstLinea = objDALEstructura.usp_TraerEstLinea(IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstLinea(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstLinea = objDALEstructura.usp_CapturaEstLinea(IdDivisiones, IdDepto, idFamilia, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarEstLinea(ByVal idLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 12/Septiembre/2012 12:26 p.m.

        Try
            'Call the data component to get all groups
            usp_ActualizarEstLinea = objDALEstructura.usp_ActualizarEstLinea(idLinea, IdFamilia, IdDepto, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstl1(ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstl1 = objDALEstructura.usp_TraerEstl1(Idl1, IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaEstl1(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstl1 = objDALEstructura.usp_CapturaEstl1(IdDivisiones, IdDepto, idFamilia, idLinea, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_ActualizarEstSubLinea(ByVal idSubLinea As Integer, ByVal idLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
    '    'miguel pérez 12/Septiembre/2012 12:26 p.m.

    '    Try
    '        'Call the data component to get all groups
    '        usp_ActualizarEstSubLinea = objDALEstructura.usp_ActualizarEstSubLinea(idSubLinea, idLinea, IdFamilia, IdDepto, Clave, Descrip)
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_TraerEstl2(ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstl2 = objDALEstructura.usp_TraerEstl2(Idl2, Idl1, IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl2(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstl2 = objDALEstructura.usp_CapturaEstl2(IdDivisiones, IdDepto, idFamilia, idLinea, idl1, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    'Public Function usp_ActualizarEstSubSubLinea(ByVal IdSubSubLinea As Integer, ByVal idSubLinea As Integer, ByVal idLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
    '    'miguel pérez 12/Septiembre/2012 12:26 p.m.

    '    Try
    '        'Call the data component to get all groups
    '        usp_ActualizarEstSubSubLinea = objDALEstructura.usp_ActualizarEstSubSubLinea(IdSubSubLinea, idSubLinea, idLinea, IdFamilia, IdDepto, Clave, Descrip)
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function

    Public Function usp_TraerEstl3(ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstl3 = objDALEstructura.usp_TraerEstl3(idl3, Idl2, Idl1, IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl3(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstl3 = objDALEstructura.usp_CapturaEstl3(IdDivisiones, IdDepto, idFamilia, idLinea, idl1, idl2, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstEstructura(ByVal idSubSubSubLinea As Integer, ByVal IdSubSubLinea As Integer, ByVal IdSubLinea As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstEstructura = objDALEstructura.usp_TraerEstEstructura(idSubSubSubLinea, IdSubSubLinea, IdSubLinea, IdLinea, IdFamilia, IdDepto, idDivisiones)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstl4(ByVal idl4 As Integer, ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstl4 = objDALEstructura.usp_TraerEstl4(idl4, idl3, Idl2, Idl1, IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl4(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal idl3 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstl4 = objDALEstructura.usp_CapturaEstl4(IdDivisiones, IdDepto, idFamilia, idLinea, idl1, idl2, idl3, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstl5(ByVal idl5 As Integer, ByVal idl4 As Integer, ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstl5 = objDALEstructura.usp_TraerEstl5(idl5, idl4, idl3, Idl2, Idl1, IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl5(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal idl3 As Integer, ByVal idl4 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstl5 = objDALEstructura.usp_CapturaEstl5(IdDivisiones, IdDepto, idFamilia, idLinea, idl1, idl2, idl3, idl4, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEstl6(ByVal idl6 As Integer, ByVal idl5 As Integer, ByVal idl4 As Integer, ByVal idl3 As Integer, ByVal Idl2 As Integer, ByVal Idl1 As Integer, ByVal IdLinea As Integer, ByVal IdFamilia As Integer, ByVal IdDepto As Integer, ByVal idDivisiones As Integer, ByVal Clave As String, ByVal Opcion As Integer, ByVal Descrip As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_TraerEstl6 = objDALEstructura.usp_TraerEstl6(idl6, idl5, idl4, idl3, Idl2, Idl1, IdLinea, IdFamilia, IdDepto, idDivisiones, Clave, Opcion, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaEstl6(ByVal IdDivisiones As Integer, ByVal IdDepto As Integer, ByVal idFamilia As Integer, ByVal idLinea As Integer, ByVal idl1 As Integer, ByVal idl2 As Integer, ByVal idl3 As Integer, ByVal idl4 As Integer, ByVal idl5 As Integer, ByVal Clave As String, ByVal Descrip As String) As Boolean
        'miguel pérez 27/Septiembre/2012 5:10 p.m.

        Try
            'Call the data component to get all groups
            usp_CapturaEstl6 = objDALEstructura.usp_CapturaEstl6(IdDivisiones, IdDepto, idFamilia, idLinea, idl1, idl2, idl3, idl4, idl5, Clave, Descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
