Imports System.Data.Odbc
Public Class DALCatalogoMovEmp
    ''Tony Garcia 04/Sept/2012 5:30 p.m.
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
    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'Tony Garcia - 05/Septiembre/2012 - 10:36 a.m.
        Try
            usp_TraerEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerEmpleado(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)


            MyBase.FillDataSet(usp_TraerEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerRepetitivoEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 10/Octubre/2014 11:11 a.m.
        Try
            usp_TraerRepetitivoEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerRepetitivoEmpleado(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)


            MyBase.FillDataSet(usp_TraerRepetitivoEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivoBaja() As DataSet
        'Tony Garcia - 05/Septiembre/2012 - 12:35 p.m.
        Try
            usp_TraerMotivoBaja = New DataSet
            MyBase.SQL = "CALL usp_TraerMotivoBaja()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerMotivoBaja, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovEmp(ByVal Opcion As Integer, ByVal IdEmpleado As Integer, ByVal Fecha As Date, ByVal Tipo As String) As DataSet
        'Tony Garcia - 10/Septiembre/2012 - 12:10 p.m.
        Try
            usp_TraerMovEmp = New DataSet
            MyBase.SQL = "CALL usp_TraerMovEmp(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@Fecha", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 3, Tipo)

            MyBase.FillDataSet(usp_TraerMovEmp, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMovEmp(ByVal IdMovEmp As Integer, ByVal Clave As String, ByVal IdEmpleado As Integer, ByVal Tipo As String, _
                                   ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Sucursal As String, ByVal IdPuesto As Integer, ByVal Estatus As String) As DataSet
        'miguel perez, tony garcia 31/Agosto/2012 01:40 p.m.
        Try
            usp_PpalMovEmp = New DataSet
            MyBase.SQL = "CALL usp_PpalMovEmp(?,?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idmovemp", OdbcType.Int, 16, IdMovEmp)
            MyBase.AddParameter("@clave", OdbcType.Char, 2, Clave)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@tipo", OdbcType.Char, 3, Tipo)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idpuesto", OdbcType.Int, 4, IdPuesto)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 1, Estatus)

            MyBase.FillDataSet(usp_PpalMovEmp, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_MovEmp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "Call usp_Captura_MovEmp(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idmovemp", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idmovemp"))
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@tipo", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@fecha", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@fechaact", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fechaact"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@baja", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("baja"))
            MyBase.AddParameter("@idmotivo", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idmotivo"))
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("vendedor"))
            MyBase.AddParameter("@vendnuevo", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("vendnuevo"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@sucnueva", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucnueva"))
            MyBase.AddParameter("@comentario", OdbcType.Char, 250, Section.Tables(0).Rows(0).Item("comentario"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            'MyBase.AddParameter("@fum", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fum"))
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))


            MyBase.AddParameter("@iddepto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@iddeptonuevo", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("iddeptonuevo"))


            MyBase.AddParameter("@idpuesto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idpuesto"))
            MyBase.AddParameter("@idpuestonuevo", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idpuestonuevo"))

            usp_Captura_MovEmp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_UpdateEmpleadoMov(ByVal Opcion As String, ByVal Section As DataSet) As Boolean
        'Tony Garcia Septiembre/2012
        Try
            MyBase.SQL = "CALL usp_UpdateEmpleadoMov(?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Char, 3, Opcion) '
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado")) '
            MyBase.AddParameter("@clave", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("clave")) '     
            MyBase.AddParameter("@iddepto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto")) '
            MyBase.AddParameter("@idpuesto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idpuesto")) '
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("vendedor")) '
            MyBase.AddParameter("@idfrecpago", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idfrecpago")) '        
            MyBase.AddParameter("@baja", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("baja")) '
            MyBase.AddParameter("@ingreso", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ingreso")) '
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus")) '
            MyBase.AddParameter("@bonofijo", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("bonofijo")) '      
            MyBase.AddParameter("@bono", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("bono")) '
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif")) '
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif")) '

            usp_UpdateEmpleadoMov = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CancelarMovEmp(ByVal Tipo As String, ByVal IdEmpleado As Integer, ByVal IdMovEmp As Integer, _
                                       ByVal UsuMod As String, ByVal Fummodif As Date) As Boolean
        'Tony Garcia - 26/Septiembre/2012 - 5:20 p.m.
        Try
            MyBase.SQL = "CALL usp_CancelarMovEmp(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@tipo", OdbcType.Char, 3, Tipo)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@idmovemp", OdbcType.Char, 16, IdMovEmp)
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, UsuMod)
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, Fummodif)

            usp_CancelarMovEmp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
