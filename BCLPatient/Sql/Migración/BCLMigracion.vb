Public Class BCLMigracion
    'mreyes 19/Agosto/2016

    Implements IDisposable
    Private objDALMigracion As DAL.DALMigracion
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALMigracion = New DAL.DALMigracion(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALMigracion.Dispose()
            objDALMigracion = Nothing
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




  

    Public Function usp_PpalProTraspDetNoAplica(ByVal IdSucursalB As Integer) As DataSet
        'mreyes 18/Agosto/2016  07:01 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalProTraspDetNoAplica = objDALMigracion.usp_PpalProTraspDetNoAplica(IdSucursalB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalProTrasp(ByVal Opcion As Integer, ByVal IdProTras As Integer, ByVal IdSucursal As Integer, _
                                                ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Estatus As String) As DataSet
        'mreyes 06/Julio/2016   06:20 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalProTrasp = objDALMigracion.usp_PpalProTrasp(Opcion, IdProTras, IdSucursal, FechaIni, FechaFin, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVendedor(IdEmpleado As Integer) As DataSet
        'mreyes 06/Julio/2016   06:20 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerVendedor = objDALMigracion.usp_TraerVendedor(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_GeneraVentasBase(ByVal IdFechaIni As Integer, ByVal IdFechaFin As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As Boolean

        'mreyes 19/Agosto/2016   05:37 p.m.

        Try

            usp_GeneraVentasBase = objDALMigracion.usp_GeneraVentasBase(IdFechaIni, IdFechaFin, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_ProTraspArticulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Julio/2016   11:55 a.m.

        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMigracion.usp_Captura_ProTraspArticulo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As String, ByVal idusuario As String) As Boolean
        'mreyes 25/08/2012 12:39 p.m.
        Try
            Return objDALMigracion.usp_GeneraProTraspArticulo(Marca, Estilon, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraAnaModArticulo(ByVal Opcion As Integer, ByVal Marca As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As String, ByVal idusuario As Integer) As Boolean
        'mreyes 16/Agosto/2016  04:25 p.m.
        Try
            Return objDALMigracion.usp_GeneraAnaModArticulo(Opcion, Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnaModArticulo(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer, ByVal IdUsuario As Integer) As DataSet
        'mreyes 16/Agosto/2016  04:30 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerAnaModArticulo = objDALMigracion.usp_TraerAnaModArticulo(Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As Integer, ByVal Propuesta As Integer) As DataSet
        'mreyes 21/Julio/2016   11:43 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerProTraspArticulo = objDALMigracion.usp_TraerProTraspArticulo(Marca, Estilon, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, Propuesta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ProtraspDetNoaplica(ByVal Opcion As Integer, ByVal Serie As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Sucursal As Integer, ByVal Observa As String, ByVal IdUsuario As Integer) As Boolean

        'mreyes 18/Agosto/2016  05:39 p.m.


        Try

            usp_Captura_ProtraspDetNoaplica = objDALMigracion.usp_Captura_ProtraspDetNoaplica(Opcion, Serie, Marca, Estilon, Medida, Sucursal, Observa, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ProtraspPropuesto(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal SucurOri As Integer, ByVal SucurDes As Integer, ByVal Ctd As Integer) As Boolean

        'mreyes 25/Julio/2016   01:27 p.m.


        Try

            usp_Captura_ProtraspPropuesto = objDALMigracion.usp_Captura_ProtraspPropuesto(Opcion, Marca, Estilon, Medida, SucurOri, SucurDes, Ctd)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraPeticionTraspaso(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String,
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String,
             ByVal idagrupacion As Integer, ByVal idusuario As Integer) As Boolean

        'mreyes 29/Julio/2016   11:58 a.m.
        Try
            Return objDALMigracion.usp_GeneraPeticionTraspaso(Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraEstructura() As Boolean

        'mreyes 21/Noviembre/2018   11:18 a.m.

        Try

            usp_GeneraEstructura = objDALMigracion.usp_GeneraEstructura()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
