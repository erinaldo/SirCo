Public Class BCLCalendario
    ''Tony Garcia 28/Diciembre/2012 - 09:15 a.m.
    Implements IDisposable
    Private objDALCalendario As DAL.DALCalendario
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCalendario = New DAL.DALCalendario(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCalendario.Dispose()
            objDALCalendario = Nothing
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

#Region " Public Patient Functions "

    Public Function usp_TraerDiasFestivosCal(ByVal Mes As String, ByVal Año As String) As DataSet
        ''Tony Garcia - 28/Diciembre/2012 - 09:45 a.m.
        Try
            'Validate group data

            '        'Call the data component to add the new group
            Return objDALCalendario.usp_TraerDiasFestivosCal(Mes, Año)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSapicaCal(ByVal Año As String) As DataSet
        ''Tony Garcia - 08/Enero/2013 - 10:45 a.m.
        Try
            'Validate group data

            '        'Call the data component to add the new group
            Return objDALCalendario.usp_TraerSapicaCal(Año)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDiasResProvCal(ByVal Proveedor As String, ByVal Marca As String, ByVal FechaIni As String, _
                                            ByVal FechaFin As String) As DataSet
        ''Tony Garcia - 28/Diciembre/2012 - 04:40 p.m.
        Try
            Return objDALCalendario.usp_TraerDiasResProvCal(Proveedor, Marca, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarca(ByVal Marca As String, ByVal Descripcion As String) As DataSet
        ''Tony Garcia - 12/Enero/2013 - 01:00 p.m.
        Try
            Return objDALCalendario.usp_TraerMarca(Marca, Descripcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
