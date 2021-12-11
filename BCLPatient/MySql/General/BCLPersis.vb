Public Class BCLPersis
    'mreyes 22/Febrero/2012 12:46 p.m.
    Implements IDisposable
    Private objDALPersis As DAL.DALPersis
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPersis = New DAL.DALPersis(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPersis.Dispose()
            objDALPersis = Nothing
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



    Public Function usp_TraerUsuario(ByVal Password As String) As DataSet
        'mreyes 22/Febrero/2012 12:46 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerUsuario = objDALPersis.usp_TraerUsuario(Password)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursal(ByVal Descripcion As String) As DataSet
        'mreyes 28/Febrero/2012 12:40 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerSucursal = objDALPersis.usp_TraerSucursal(Descripcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDatosSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 04/Julio/2012 12:20 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDatosSucursal = objDALPersis.usp_TraerDatosSucursal(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerSucursalSel(ByVal Descripcion As String) As DataSet
        'mreyes 28/Febrero/2012 12:40 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerSucursalSel = objDALPersis.usp_TraerSucursalSel(Descripcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNomSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 21/Junio/2012 12:28 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerNomSucursal = objDALPersis.usp_TraerNomSucursal(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaHoy() As DataSet
        'mreyes 09/Septimbre/2012 12:33 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFechaHoy = objDALPersis.usp_TraerFechaHoy()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function pub_TraerUltoPrimDiaMes(ByVal Opcion As Integer, ByVal FechaB As Date) As DataSet
        'mreyes 09/Septimbre/2012 02:03 p.m.
        Try
            'Call the data component to get all groups
            pub_TraerUltoPrimDiaMes = objDALPersis.pub_TraerUltoPrimDiaMes(Opcion, FechaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPermiso(ByVal Usuario As String, ByVal Programa As String) As DataSet
        'mreyes 13/Marzo/2012 04:49 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPermiso = objDALPersis.usp_TraerPermiso(Usuario, Programa)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPermisoProceso(ByVal Usuario As String, ByVal Programa As String, ByVal Proceso As String, ByVal Passproc As String) As DataSet
        'mreyes 13/Marzo/2012 05:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPermisoProceso = objDALPersis.usp_TraerPermisoProceso(Usuario, Programa, Proceso, Passproc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPassword(ByVal Usuario As String, ByVal PasswordAnt As String, ByVal PasswordNew As String) As Boolean
        'Tony Garcia - 08/Octubre/2012 - 6:30 p.m.
        Try
            Return objDALPersis.usp_ActualizarPassword(Usuario, PasswordAnt, PasswordNew)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuarioPass(ByVal Usuario As String, ByVal Password As String) As Boolean
        'Tony Garcia - 08/Octubre/2012 - 6:30 p.m.
        Try
            Return objDALPersis.usp_TraerUsuarioPass(Usuario, Password)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CambioPass(ByVal Opcion As String, ByVal Usuario As String, ByVal PasswordAnt As String, _
                                           ByVal PasswordNew As String, ByVal UsuModif As String, ByVal Fummod As DateTime) As Boolean
        'Tony Garcia - 09/Octubre/2012 - 12:30 p.m.
        Try
            Return objDALPersis.usp_Captura_CambioPass(Opcion, Usuario, PasswordAnt, PasswordNew, UsuModif, Fummod)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuBitContrasena(ByVal Usuario As String)
        'Tony Garcia - 09/Octubre/2012 - 12:45 p.m.
        Try
            Return objDALPersis.usp_TraerUsuBitContrasena(Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
