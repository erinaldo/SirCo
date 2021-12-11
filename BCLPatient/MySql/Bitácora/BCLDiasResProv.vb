Public Class BCLDiasResProv
    ''Tony Garcia 07/Diciembre/2012 - 04:45 p.m.
    Implements IDisposable
    Private objDALDiasResProv As DAL.DALDiasResProv
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALDiasResProv = New DAL.DALDiasResProv(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALDiasResProv.Dispose()
            objDALDiasResProv = Nothing
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

    Public Function usp_PpalDiasResProv(ByVal Proveedor As String, ByVal FecIni As String, ByVal FecFin As String)
        'Tony Garcia - 07/Diciembre/2012 - 01:10 p.m
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALDiasResProv.usp_PpalDiasResProv(Proveedor, FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_ActualizaDiasResProv(ByVal Proveedor As String, ByVal Marca As String, _
                                            ByVal Estilon As String, ByVal DiasResurt As Integer) As Boolean
        'Tony Garcia - 07/Diciembre/2012 - 02:10 p.m
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALDiasResProv.usp_ActualizaDiasResProv(Proveedor, Marca, Estilon, DiasResurt)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String, _
                                                  ByVal DiasRespuesta As Integer, ByVal UltimoRes As String, ByVal DiasResurtido As Integer) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:00 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALDiasResProv.usp_CapturaMarcaEstilonDiasRes(Proveedor, Marca, Estilon, DiasRespuesta, UltimoRes, DiasResurtido)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminarMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:35 p.m.
        Try
            Return objDALDiasResProv.usp_EliminarMarcaEstilonDiasRes(Proveedor, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
