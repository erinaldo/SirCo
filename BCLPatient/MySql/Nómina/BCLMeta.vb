Public Class BCLMeta
    'mreyes 01/Junio/2012 06:19 p.m.
    Implements IDisposable
    Private objDALMeta As DAL.DALMeta
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALMeta = New DAL.DALMeta(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALMeta.Dispose()
            objDALMeta = Nothing
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



    Public Function usp_TraerChecador(ByVal idchecador As Integer) As DataSet
        'mreyes 01/Junio/2012 06:58 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerChecador = objDALMeta.usp_TraerChecador(idchecador)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMarcaje(ByVal IdEmpleado As Integer, ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet

        'mreyes 23/Junio/2012 02:01 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalMarcaje = objDALMeta.usp_PpalMarcaje(IdEmpleado, Sucursal, IdDepto, IdPuesto, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMeta(ByVal Anio As Integer, ByVal Mes As Integer, ByVal Sucursal As String, ByVal GrupoArt As String) As DataSet

        'mreyes 28/Agosto/2012 01:50 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalMeta = objDALMeta.usp_PpalMeta(Anio, Mes, Sucursal, GrupoArt)
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
            Return objDALMeta.usp_Captura_Checada(Opcion, idchecador, Fecha, Hora, idempleado)
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
            Return objDALMeta.usp_TraerChecada(IdEmpleado, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_CalculaMetaVentasNetas(ByVal Sucursal As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Usuario As String, ByVal Porc As Integer) As Boolean
        'mreyes 21/Marzo/2012 07:05 p.m.
        Try
            'Call the data component to delete the group  SucursalB char(2), FechaInib date, FechaFinb date, UsuarioB char(8)
            Return objDALMeta.usp_CalculaMetaVentasNetas(Sucursal, FechaIni, FechaFin, Usuario, Porc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Meta(ByVal Opcion As Integer, ByVal IdMeta As Integer, ByVal Anio As Integer, ByVal Mes As Integer, _
                                     ByVal Sucursal As String, ByVal Grupo As String, ByVal Pares As Decimal, ByVal Usuario As String) As Boolean
        'mreyes 21/Marzo/2012 07:05 p.m.
        Try
            'Call the data component to delete the group  SucursalB char(2), FechaInib date, FechaFinb date, UsuarioB char(8)
            'ByVal Opcion As Integer, ByVal IdMeta As Integer, ByVal Anio As Integer, ByVal Mes As Integer, _
            'ByVal Sucursal As String, ByVal Grupo As String, ByVal Pares As Decimal, ByVal Usuario As String
            Return objDALMeta.usp_Captura_Meta(Opcion, IdMeta, Anio, Mes, Sucursal, Grupo, Pares, Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
