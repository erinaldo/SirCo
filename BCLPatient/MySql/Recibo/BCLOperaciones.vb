Public Class BCLOperaciones
    'miguel pérez 29/Diciembre/2012 01:44 p.m.

    Implements IDisposable
    Private objDALOperaciones As DAL.DALOperaciones
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALOperaciones = New DAL.DALOperaciones(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALOperaciones.Dispose()
            objDALOperaciones = Nothing
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

    Public Function usp_TraerIdFolioBulto(ByVal CveSucursal As String) As DataSet
        'mreyes 20/Enero/2012   11:30 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerIdFolioBulto = objDALOperaciones.usp_TraerIdFolioBulto(CveSucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdFolio(ByVal IdFolioSuc As String) As DataSet
        'mreyes 20/Enero/2012   11:30 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerIdFolio = objDALOperaciones.usp_TraerIdFolio(IdFolioSuc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerOperaciones(ByVal Tipo As String, ByVal Sucursal As String) As DataSet
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerOperaciones = objDALOperaciones.usp_TraerOperaciones(Tipo, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarFoliosOperaciones(ByVal Tipo As String, ByVal Sucursal As String) As Boolean
        'miguel pérez 30/Diciembre/2012 09:30 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarFoliosOperaciones = objDALOperaciones.usp_ActualizarFoliosOperaciones(Tipo, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
