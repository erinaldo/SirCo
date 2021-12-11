Imports System.Data.Odbc
'mreyes 22/Febrero/2012 12:47 p.m.

Public Class DALPersis
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "


    Public Function usp_TraerUsuario(ByVal Password As String) As DataSet
        'mreyes 22/Febrero/2012 12:47 p.m.
        Try
            usp_TraerUsuario = New DataSet
            MyBase.SQL = "CALL usp_TraerUsuario(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Password", OdbcType.Char, 6, Password)
            MyBase.FillDataSet(usp_TraerUsuario, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursal(ByVal Descripcion As String) As DataSet
        'mreyes 28/Febrero/2012 12:38 p.m.
        Try
            usp_TraerSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerSucursal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Descripb", OdbcType.Char, 40, Descripcion)
            MyBase.FillDataSet(usp_TraerSucursal, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDatosSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 04/Julio/2012 12:20 p.m.
        Try
            usp_TraerDatosSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerDatosSucursal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerDatosSucursal, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSucursalSel(ByVal Descripcion As String) As DataSet
        'mreyes 28/Febrero/2012 12:38 p.m.
        Try
            usp_TraerSucursalSel = New DataSet
            MyBase.SQL = "CALL usp_TraerSucursalSel(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Descripb", OdbcType.Char, 40, Descripcion)
            MyBase.FillDataSet(usp_TraerSucursalSel, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 21/Junio/2012 12:28 p.m.
        Try
            usp_TraerNomSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerNomSucursal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.FillDataSet(usp_TraerNomSucursal, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaHoy() As DataSet
        'mreyes 09/Septiembre/2012 12:34 p.m.
        Try
            usp_TraerFechaHoy = New DataSet
            MyBase.SQL = "CALL usp_TraerFechaHoy()"

            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_TraerFechaHoy, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function pub_TraerUltoPrimDiaMes(ByVal Opcion As Integer, ByVal FechaB As Date) As DataSet
        'mreyes 09/Septiembre/2012 02;04 p.m.
        Try
            pub_TraerUltoPrimDiaMes = New DataSet
            MyBase.SQL = "CALL pub_TraerUltoPrimDiaMes(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 6, Opcion)
            MyBase.AddParameter("@fechaB", OdbcType.Date, 8, FechaB)

            MyBase.FillDataSet(pub_TraerUltoPrimDiaMes, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPermiso(ByVal Usuario As String, ByVal Programa As String) As DataSet
        'mreyes 13/Marzo/2012 04:50 p.m.
        Try
            usp_TraerPermiso = New DataSet
            MyBase.SQL = "CALL usp_TraerPermiso(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@usuariob", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@programab", OdbcType.Char, 8, Programa)

            MyBase.FillDataSet(usp_TraerPermiso, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPermisoProceso(ByVal Usuario As String, ByVal Programa As String, ByVal Proceso As String, ByVal Passproc As String) As DataSet
        'mreyes 13/Marzo/2012 04:50 p.m.
        Try
            usp_TraerPermisoProceso = New DataSet
            MyBase.SQL = "CALL usp_TraerPermisoProceso(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@usuariob", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@programab", OdbcType.Char, 8, Programa)
            MyBase.AddParameter("@procesob", OdbcType.Char, 2, Proceso)
            MyBase.AddParameter("@passprocb", OdbcType.Char, 6, Passproc)

            MyBase.FillDataSet(usp_TraerPermisoProceso, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarPassword(ByVal Usuario As String, ByVal PasswordAnt As String, ByVal PasswordNew As String) As Boolean
        'Tony Garcia - 08/Octubre/2012 - 6:35 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarPassword(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@passwordAnt", OdbcType.Char, 6, PasswordAnt)
            MyBase.AddParameter("@passwordNew", OdbcType.Char, 6, PasswordNew)

            usp_ActualizarPassword = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuarioPass(ByVal Usuario As String, ByVal Password As String) As Boolean
        'Tony Garcia - 08/Octubre/2012 - 6:35 p.m.
        Try
            MyBase.SQL = "CALL usp_TraerUsuarioPass(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@password", OdbcType.Char, 6, Password)

            usp_TraerUsuarioPass = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CambioPass(ByVal Opcion As String, ByVal Usuario As String, ByVal PasswordAnt As String, _
                                            ByVal PasswordNew As String, ByVal UsuModif As String, ByVal Fummod As DateTime) As Boolean
        'Tony Garcia - 09/Octubre/2012 - 12:30 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_CambioPass(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Char, 8, Opcion)
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@passwordant", OdbcType.Char, 6, PasswordAnt)
            MyBase.AddParameter("@passwordnew", OdbcType.Char, 8, PasswordNew)
            MyBase.AddParameter("@usumodif", OdbcType.Char, 6, UsuModif)
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 8, Fummod)

            usp_Captura_CambioPass = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuBitContrasena(ByVal Usuario As String)
        'Tony Garcia - 09/Octubre/2012 - 12:45 p.m.
        Try
            MyBase.SQL = "CALL usp_TraerUsuBitContrasena(?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@usario", OdbcType.Char, 8, Usuario)

            usp_TraerUsuBitContrasena = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
