Imports System.Data.Odbc
Public Class DALCatalogoActividades
    ''Tony Garcia 13/Octubre/2012 - 12:00 p.m.
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

    Public Function usp_Captura_Actividad(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia - 13/Octubre/2012 - 5:00 p.m.
        Try
            MyBase.SQL = "Call usp_Captura_Actividad(?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idactividad", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idactividad"))
            MyBase.AddParameter("@iddepto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@reporta", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("reporta"))
            MyBase.AddParameter("@asignado", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("asignado"))
            MyBase.AddParameter("@fechaalta", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fechaalta"))
            MyBase.AddParameter("@fechaproc", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fechaproc"))
            MyBase.AddParameter("@fechafin", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fechafin"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))

            usp_Captura_Actividad = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_ActividadDet(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia - 13/Octubre/2012 - 5:00 p.m.
        Try
            MyBase.SQL = "Call usp_Captura_ActividadDet(?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idactividad", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idactividad"))
            MyBase.AddParameter("@tipo", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@reporta", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("reporta"))
            MyBase.AddParameter("@asignado", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("asignado"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@descripcion", OdbcType.Char, 250, Section.Tables(0).Rows(0).Item("descripcion"))
            MyBase.AddParameter("@resultado", OdbcType.Char, 250, Section.Tables(0).Rows(0).Item("resultado"))
            MyBase.AddParameter("@satisfaccion", OdbcType.Char, 250, Section.Tables(0).Rows(0).Item("satisfaccion"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))

            usp_Captura_ActividadDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerActividadEmp(ByVal IdActividad As Integer, ByVal Fecha As Date, ByVal Estatus As String) As DataSet
        'Tony Garcia - 15/Octubre/2012 - 12:50 p.m.
        Try
            usp_TraerActividadEmp = New DataSet
            MyBase.SQL = "CALL usp_TraerActividadEmp(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdActividad)
            MyBase.AddParameter("@Fecha", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@Estatus", OdbcType.Char, 1, Estatus)

            MyBase.FillDataSet(usp_TraerActividadEmp, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalActividadesEmp(ByVal IdActividad As Integer, ByVal IdReporta As Integer, ByVal IdAsignado As Integer, _
                                   ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Sucursal As String, ByVal IdPuesto As Integer, _
                                   ByVal Depto As String, ByVal Estatus As String) As DataSet
        'Tony Garcia - 15/Octubre/2012 - 10:00 a.m

        Try
            usp_PpalActividadesEmp = New DataSet
            MyBase.SQL = "CALL usp_PpalActividadesEmp(?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdActividadB", OdbcType.Int, 16, IdActividad)
            MyBase.AddParameter("@IdReportaB", OdbcType.Int, 4, IdReporta)
            MyBase.AddParameter("@IdAsignadoB", OdbcType.Int, 4, IdAsignado)
            MyBase.AddParameter("@fechainiB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafinB", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idpuestoB", OdbcType.Int, 4, IdPuesto)
            MyBase.AddParameter("@deptoB", OdbcType.Char, 15, Depto)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 10, Estatus)

            MyBase.FillDataSet(usp_PpalActividadesEmp, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoFolioAct() As DataSet
        'Tony Garcia - 15/Octubre/2012 - 10:50 a.m

        Try
            usp_TraerUltimoFolioAct = New DataSet
            MyBase.SQL = "CALL usp_TraerUltimoFolioAct()"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerUltimoFolioAct, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstatusAct(ByVal Opcion As String, ByVal IdActividad As Integer, ByVal Estatus As String, _
                                             ByVal FechaProc As Date, ByVal FechaFin As Date, ByVal UsuMod As String, ByVal Fummod As String) As Boolean
        'Tony Garcia - 15/Octubre/2012 - 
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatusAct(?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Char, 3, Opcion)
            MyBase.AddParameter("@IdActividad", OdbcType.Int, 16, IdActividad)
            MyBase.AddParameter("@Estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@FechaProc", OdbcType.DateTime, 16, FechaProc)
            MyBase.AddParameter("@FechaFin", OdbcType.DateTime, 16, FechaFin)
            MyBase.AddParameter("@UsuMod", OdbcType.Char, 8, UsuMod)
            MyBase.AddParameter("@Fummod", OdbcType.DateTime, 16, Fummod)

            usp_ActualizarEstatusAct = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomDepto(ByVal Clave As String) As DataSet
        'Tony Garcia - 23/Octubre/2012 - 5:40 p.m.
        Try
            usp_TraerNomDepto = New DataSet
            MyBase.SQL = "CALL usp_TraerNomDepto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@claveB", OdbcType.Char, 3, Clave)

            MyBase.FillDataSet(usp_TraerNomDepto, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
