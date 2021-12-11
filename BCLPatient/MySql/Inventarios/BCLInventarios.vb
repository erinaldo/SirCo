Public Class BCLInventarios
    'mreyes 18/Junio/2015   05:46 p.m.

    Implements IDisposable
    Private objDALInventarios As DAL.DALInventarios
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALInventarios = New DAL.DALInventarios(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALInventarios.Dispose()
            objDALInventarios = Nothing
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

    Public Function usp_ActualizarSucursalInv(ByVal Opcion As Integer, ByVal Sucursal As String) As Boolean
        'mreyes 18/Junio/2015   05:54 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALInventarios.usp_ActualizarSucursalInv(Opcion, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaInvFis(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal NumIf As Integer, _
                                            ByVal Estatus As String, ByVal Fecha As String, ByVal Hora As String, ByVal Observa As String, ByVal Usuario As String, _
                                            ByVal idusuario As Integer) As Boolean

        'mreyes 19/Junio/2015   01:00 p.m.

        'opcion int, SucursalB char(2), FolioB char(6),  NumIfB int, EstatusB char(2), FechaB char(10),HoraB char(8), ObservaB char(60), UsuarioB char(8),
        'idusuarioB(smallint(4))


        Try

            'Call the data component to add the new group
            Return objDALInventarios.usp_CapturaInvFis(Opcion, Sucursal, Folio, NumIf, Estatus, Fecha, Hora, Observa, Usuario, idusuario)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
   End Function
    Public Function usp_CapturaLeerSeriesInv(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal NumIf As Integer, ByVal Archivo As String, ByVal Serie As String, ByVal IdUsuario As String) As Boolean

        'mreyes 19/Junio/2015   04:02 p.m.


        Try

            'Call the data component to add the new group
            Return objDALInventarios.usp_CapturaLeerSeriesInv(Opcion, Sucursal, NumIf, Archivo, Serie, IdUsuario)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalInvFis(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal NumIf As Integer, ByVal FechaIni As String) As DataSet
        'mreyes 24/Junio/2015   12:50 p.m.
        Try
            ' Opcion int, SucursalB CHAR(2), folioB char(6), NumIfB int, FechaIniB char(10)
            'Call the data component to get all groups
            usp_PpalInvFis = objDALInventarios.usp_PpalInvFis(Opcion, Sucursal, Folio, NumIf, FechaIni)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CapturaDet_If(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Folio As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Serie As String, ByVal Ctd As Integer, ByVal Costo As Double, ByVal Precio As Double) As Boolean

        'mreyes 23/Junio/2015   10:32 a.m.

        Try

            'Call the data component to add the new group
            Return objDALInventarios.usp_CapturaDet_If(Opcion, Sucursal, Folio, Marca, Estilon, Corrida, Medida, Serie, Ctd, Costo, Precio)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalSubirInv(ByVal Sucursal As String, ByVal NumInv As Integer, ByVal GeneradoB As Integer) As DataSet
        'mreyes 23/Junio/2015   12:21 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalSubirInv = objDALInventarios.usp_PpalSubirInv(Sucursal, NumInv, GeneradoB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
