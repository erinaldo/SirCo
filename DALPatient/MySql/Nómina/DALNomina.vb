Imports System.Data.Odbc
'mreyes 30/Junio/2012 10:37 a.m.

Public Class DALNomina
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
    Public Function usp_TraerPercdeduc(ByVal idPeriodo As String, ByVal tipoNom As String, ByVal idPercdeduc As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerPercdeduc = New DataSet
            MyBase.SQL = "CALL usp_TraerPercdeduc(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@tipoNomB", OdbcType.Char, 1, tipoNom)
            MyBase.AddParameter("@idPercdeducB", OdbcType.SmallInt, 4, idPercdeduc)

            MyBase.FillDataSet(usp_TraerPercdeduc, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNominaPercdeduc(ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                       ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'miguel perez, tony garcia 29/Agosto/2012 10:00 a.m.
        Try

            usp_PpalNominaPercdeduc = New DataSet
            MyBase.SQL = "CALL usp_PpalNominaPercdeduc(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)


            MyBase.FillDataSet(usp_PpalNominaPercdeduc, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Empleado(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Junio/2012 04:07 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Empleado(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@clave", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("clave"))
            MyBase.AddParameter("@appaterno", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("appaterno"))
            MyBase.AddParameter("@apmaterno", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("apmaterno"))
            MyBase.AddParameter("@nombre", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@iddepto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@idpuesto", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idpuesto"))
            MyBase.AddParameter("@idfrecpago", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idfrecpago"))
            MyBase.AddParameter("@jornada", OdbcType.Int, 2, Section.Tables(0).Rows(0).Item("jornada"))
            MyBase.AddParameter("@entrada", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("entrada"))
            MyBase.AddParameter("@comida", OdbcType.Int, 2, Section.Tables(0).Rows(0).Item("comida"))

            MyBase.AddParameter("@extras", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("extras"))
            MyBase.AddParameter("@baja", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("baja"))
            MyBase.AddParameter("@ingreso", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ingreso"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@tsalario", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tsalario"))
            MyBase.AddParameter("@zsalario", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("zsalario"))

            MyBase.AddParameter("@porinteg", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("porinteg"))
            MyBase.AddParameter("@sdiario", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("sdiario"))
            MyBase.AddParameter("@shora", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("shora"))
            MyBase.AddParameter("@sinteg", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("sinteg"))
            MyBase.AddParameter("@ptu", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("ptu"))
            MyBase.AddParameter("@imss", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("imss"))
            MyBase.AddParameter("@licencia", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("licencia"))
            MyBase.AddParameter("@unimed", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("unimed"))
            MyBase.AddParameter("@calle", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@colonia", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@ciudad", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("ciudad"))
            MyBase.AddParameter("@codpos", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("codpos"))
            MyBase.AddParameter("@numext", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("numext"))
            MyBase.AddParameter("@numint", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("numint"))
            MyBase.AddParameter("@sexo", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("sexo"))
            MyBase.AddParameter("@telef1", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef1"))
            MyBase.AddParameter("@telef2", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef2"))
            MyBase.AddParameter("@email", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@nacim", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("nacim"))
            MyBase.AddParameter("@ciudadnac", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("ciudadnac"))
            MyBase.AddParameter("@edocivil", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("edocivil"))
            MyBase.AddParameter("@numhijos", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("numhijos"))
            MyBase.AddParameter("@nompadre", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("nompadre"))
            MyBase.AddParameter("@nommadre", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("nommadre"))
            MyBase.AddParameter("@rfc", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@curp", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("curp"))
            MyBase.AddParameter("@noimss", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("noimss"))
            MyBase.AddParameter("@checa", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("checa"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))

            usp_Captura_Empleado = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_MatchTimbrado(ByVal Section As DataSet) As Boolean
        'mreyes 20/Enero/2014   05:00 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_MatchTimbrado(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@folio", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("folio"))
            MyBase.AddParameter("@rfc", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@folioerp", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("folioerp"))
            

            usp_Captura_MatchTimbrado = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Venta(ByVal Section As DataSet) As Boolean
        'mreyes 18/Agosto/2012 01:32 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Venta(?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("vendedor"))
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipoart"))
            MyBase.AddParameter("@pares", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("pares"))
            MyBase.AddParameter("@impvta", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("impvta"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            
            usp_Captura_Venta = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_VentaCajero(ByVal Section As DataSet) As Boolean
        'mreyes 12/Junio/2018   05:02 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_VentaCajero(?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@cajero", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("cajero"))
            MyBase.AddParameter("@tipoart", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipoart"))
            MyBase.AddParameter("@pares", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("pares"))
            MyBase.AddParameter("@impvta", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("impvta"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))

            usp_Captura_VentaCajero = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_NominaDet(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Julio/2012 10:15 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_NominaDet(?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idperiodoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idperiodo"))
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tiponom"))
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@idpercdeducB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idpercdeduc"))
            MyBase.AddParameter("@idrepetitivoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idrepetitivo"))
            MyBase.AddParameter("@unidadesB", OdbcType.Decimal, 8, Section.Tables(0).Rows(0).Item("unidades"))
            MyBase.AddParameter("@impgravB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("impgrav"))
            MyBase.AddParameter("@impexentoB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("impexento"))
            MyBase.AddParameter("@usuarioB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodifB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodifB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))



            usp_Captura_NominaDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_EliminarNomina(ByVal Opcion As Integer, ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 23/Agosto/2012 09:40 a.m.
        ' valor de 2 para borrar todo
        Try
            'idperiodoB integer, TipoNomB char(1),sucursalB char(2), idempleadoB smallint(4)
            MyBase.SQL = "CALL usp_EliminarNomina(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idperiodoB", OdbcType.Int, 16, IdPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)

            'Execute the stored procedure
            usp_EliminarNomina = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraNomina(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal Usuario As String) As Boolean
        'mreyes 12/Septiembre/2012 10:38 p.m.
        ' valor de 2 para borrar todo
        Try
            'idperiodoB integer, TipoNomB char(1),sucursalB char(2), idempleadoB smallint(4)
            MyBase.SQL = "CALL usp_GeneraNomina(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@idperiodoB", OdbcType.Int, 16, IdPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@usuariob", OdbcType.Char, 8, Usuario)

            'Execute the stored procedure
            usp_GeneraNomina = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarNominaDet(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer, ByVal IdPercDeduc As Integer) As Boolean
        'mreyes 03/Septiembre/2012 05:41 p.m.

        Try
            'idperiodoB integer, TipoNomB char(1),sucursalB char(2), idempleadoB smallint(4)
            MyBase.SQL = "CALL usp_EliminarNominaDet(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@idperiodoB", OdbcType.Int, 16, IdPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@idpercdeducB", OdbcType.Int, 16, IdPercdeDuc)


            'Execute the stored procedure
            usp_EliminarNominaDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CaculoNominaFiscal(ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
                                           ByVal FechaIni As Date, ByVal FechaFin As Date, _
                                           ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal Usuario As String, ByVal ComEmb As Decimal) As Boolean
        'mreyes 23/Agosto/2012 09:40 a.m.

        Try
            'idperiodoB integer, TipoNomB char(1),sucursalB char(2), idempleadoB smallint(4)
            MyBase.SQL = "CALL usp_CaculoNominaFiscal(?,?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@idperiodoB", OdbcType.Int, 16, IdPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@ComEmb", OdbcType.Decimal, 9, ComEmb)

            'Execute the stored procedure
            usp_CaculoNominaFiscal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CaculoAguinaldo(ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
                                        ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal Usuario As String) As Boolean

        'mreyes 10/Diciembre/2012 01:43 p.m.

        Try
            'idperiodoB integer, TipoNomB char(1),sucursalB char(2), idempleadoB smallint(4)
            MyBase.SQL = "CALL usp_CaculoAguinaldo(?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@idperiodoB", OdbcType.Int, 16, IdPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
         
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)


            'Execute the stored procedure
            usp_CaculoAguinaldo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Periodo(ByVal Opcion As Integer, ByVal Idperiodo As Integer, _
                                        ByVal IdFrecPago As Integer, ByVal FechaIni As Date, _
                                            ByVal FechaFin As Date, ByVal Estatus As String, _
                                            ByVal Usuario As String, ByVal usumodif As String, ByVal fummodif As DateTime) As Boolean
        'mreyes 13/Julio/2012 10:30 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_Periodo(?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@Idperiodo", OdbcType.Int, 16, Idperiodo)
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            MyBase.AddParameter("@FechaIni", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@Estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)
            MyBase.AddParameter("@usumodif", OdbcType.Char, 8, usumodif)
            MyBase.AddParameter("@fummodif", OdbcType.DateTime, 16, fummodif)

            usp_Captura_Periodo = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DiaFestivo(ByVal Opcion As Integer, ByVal IdDiaFestivo As Integer, _
                                           ByVal Fecha As Date, ByVal Descrip As String, _
                                            ByVal Usuario As String) As Boolean
        'mreyes 13/Julio/2012 10:30 a.m.
        Try

            MyBase.SQL = "CALL usp_Captura_DiaFestivo(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@iddiafestivo", OdbcType.Int, 16, IdDiaFestivo)
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Fecha)
           
            MyBase.AddParameter("@descrip", OdbcType.Char, 60, Descrip)
            MyBase.AddParameter("@usuario", OdbcType.Char, 8, Usuario)
            usp_Captura_DiaFestivo = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal iddepto As Integer) As DataSet
        'mreyes 11/Junio/2012 01;27 p.m.
        Try
            usp_TraerNomEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerNomEmpleado(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@ApPaterno", OdbcType.Char, 30, ApPaterno)
            MyBase.AddParameter("@ApMaterno", OdbcType.Char, 30, apMaterno)
            MyBase.AddParameter("@Nombre", OdbcType.Char, 30, Nombre)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@iddepto", OdbcType.Int, 16, iddepto)

            MyBase.FillDataSet(usp_TraerNomEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 09/Septiembre/2012 10:35 a.m. 
        Try
            usp_TraerNomSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerNomSucursal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)


            MyBase.FillDataSet(usp_TraerNomSucursal, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaPeriodo(ByVal IdFrecPago As Integer) As DataSet
        'mreyes 16/Julio/2012 10:25 a.m.
        Try
            usp_TraerFechaPeriodo = New DataSet
            MyBase.SQL = "CALL usp_TraerFechaPeriodo(?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            '            MyBase.ExecuteStoredProcedure()
            MyBase.FillDataSet(usp_TraerFechaPeriodo, "nomsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerTotalPercDeduc(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer) As DataSet
        'mreyes 16/Julio/2012 10:25 a.m.
        Try
            usp_TraerTotalPercDeduc = New DataSet
            MyBase.SQL = "CALL usp_TraerTotalPercDeduc(?,?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idperiodo", OdbcType.Int, 16, IdPeriodo)
            MyBase.AddParameter("@tiponom", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, IdEmpleado)
            '            MyBase.ExecuteStoredProcedure()
            MyBase.FillDataSet(usp_TraerTotalPercDeduc, "nomsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CalculaSubsidio(ByVal IdFrecPago As Integer, ByVal sDiario As Decimal, ByRef SubSidio As Decimal) As DataSet
        'mreyes 19/Julio/2012 01:30 p.m.
        Try
            usp_CalculaSubsidio = New DataSet
            MyBase.SQL = "CALL usp_CalculaSubsidio(?,?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            MyBase.AddParameter("@sdiario", OdbcType.Decimal, 9, sDiario)
            MyBase.AddParameter("@subsidio", OdbcType.Decimal, 9, SubSidio)
            '            MyBase.ExecuteStoredProcedure()
            MyBase.FillDataSet(usp_CalculaSubsidio, "nomsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCalculaSubsidio(ByVal IdFrecPago As Integer, ByVal sDiario As Decimal) As DataSet
        'mreyes 
        Try
            usp_TraerCalculaSubsidio = New DataSet
            MyBase.SQL = "CALL usp_TraerCalculaSubsidio(?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            MyBase.AddParameter("@sdiario", OdbcType.Decimal, 9, sDiario)

            '            MyBase.ExecuteStoredProcedure()
            MyBase.FillDataSet(usp_TraerCalculaSubsidio, "nomsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerClaveEmpleado(ByVal Sucursal As String) As DataSet
        'mreyes 19/Junio/2012 05:02 p.m.
        Try
            usp_TraerClaveEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerClaveEmpleado(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)


            MyBase.FillDataSet(usp_TraerClaveEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIDEmpleado(ByVal Sucursal As String, ByVal Vendedor As String) As DataSet
        'mreyes 18/Agosto/2012 02:26 p.m.
        Try
            usp_TraerIDEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerIDEmpleado(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Vendedor)


            MyBase.FillDataSet(usp_TraerIDEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCajero(ByVal Cajero As String) As DataSet
        'mreyes 18/Agosto/2012 02:26 p.m.
        Try
            usp_TraerCajero = New DataSet
            MyBase.SQL = "CALL usp_TraerCajero(?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@cajero", OdbcType.Char, 2, Cajero)


            MyBase.FillDataSet(usp_TraerCajero, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEncargadoTienda(ByVal Sucursal As String) As DataSet
        'mreyes 30/Agosto/2012 06:18 p.m.
        Try
            usp_TraerEncargadoTienda = New DataSet
            MyBase.SQL = "CALL usp_TraerEncargadoTienda(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)



            MyBase.FillDataSet(usp_TraerEncargadoTienda, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ConsecutivoEmp(ByVal Sucursal As String) As DataSet
        'mreyes 22/Julio/2012 01:02 p.m.
        Try
            usp_ConsecutivoEmp = New DataSet
            MyBase.SQL = "CALL usp_ConsecutivoEmp(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", OdbcType.Char, 2, Sucursal)


            MyBase.FillDataSet(usp_ConsecutivoEmp, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:34 p.m.
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

    Public Function usp_PpalNomina(ByVal Opcion As Integer, ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                        ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'mreyes 30/Junio/2012 10:42 a.m.
        Try


            usp_PpalNomina = New DataSet
            MyBase.SQL = "CALL usp_PpalNomina(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)


            MyBase.FillDataSet(usp_PpalNomina, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalNominaBono(ByVal Opcion As Integer, ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'mreyes 15/Abril/2015   12:51 p.m.
        Try


            usp_PpalNominaBono = New DataSet
            MyBase.SQL = "CALL usp_PpalNominaBono(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)


            MyBase.FillDataSet(usp_PpalNominaBono, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNominaBanBajio(ByVal Opcion As Integer, ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                    ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal BanBajio As Integer) As DataSet
        'mreyes 15/Julio/2015   10:24 a.m.
        Try


            usp_PpalNominaBanBajio = New DataSet
            MyBase.SQL = "CALL usp_PpalNominaBanBajio(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)
            MyBase.AddParameter("@BanBajio", OdbcType.Int, 4, BanBajio)


            MyBase.FillDataSet(usp_PpalNominaBanBajio, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalNominaFiscal(ByVal Opcion As Integer, ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                    ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal BanBajio As Integer) As DataSet
        'mreyes 05/Noviembre/2014   07:29 p.m.
        Try


            usp_PpalNominaFiscal = New DataSet
            MyBase.SQL = "CALL usp_PpalNominaFiscal(?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)
            MyBase.AddParameter("@BanBajio", OdbcType.Int, 4, BanBajio)


            MyBase.FillDataSet(usp_PpalNominaFiscal, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalAguinaldo(ByVal Opcion As Integer, ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                        ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal Dis As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 10/Diciembre/2012 02:27 p.m.
        Try


            usp_PpalAguinaldo = New DataSet
            If Dis = 1 Then
                MyBase.SQL = "CALL usp_PpalAguinaldoDis(?,?,?,?,?,?,?,?,?)"
            Else
                MyBase.SQL = "CALL usp_PpalAguinaldo(?,?,?,?,?,?,?,?,?)"
            End If

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafinB", OdbcType.Date, 8, FechaFin)


            MyBase.FillDataSet(usp_PpalAguinaldo, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoDiaFestivo() As DataSet
        'mreyes 23/Agosto/2012 12:44 p.m.
        Try


            usp_PpalCatalogoDiaFestivo = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoDiaFestivo()"

            MyBase.InitializeCommand()



            MyBase.FillDataSet(usp_PpalCatalogoDiaFestivo, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ReciboNominaDet(ByVal idPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer) As DataSet
        'mreyes 11/Julio/2012 05:47 p.m.
        Try


            usp_ReciboNominaDet = New DataSet
            MyBase.SQL = "CALL usp_ReciboNominaDet(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeridoB", OdbcType.Int, 16, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)


            MyBase.FillDataSet(usp_ReciboNominaDet, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminaVenta(ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As Boolean
        'mreyes 18/Agosto/2012 01:46 p.m.
        Try
            MyBase.SQL = "CALL usp_EliminaVenta(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 3, Sucursal)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)
            'Execute the stored procedure
            usp_EliminaVenta = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNominaDet(ByVal Opcion As Integer, ByVal idPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer, ByVal Naturaleza As String, ByVal IdRepetitivo As Integer, ByVal IdPercDeduc As Integer) As DataSet
        'mreyes 18/Julio/2012 10:50 a.m.
        Try


            usp_TraerNominaDet = New DataSet
            MyBase.SQL = "CALL usp_TraerNominaDet(?,?,?,?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idPeridoB", OdbcType.Int, 16, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@naturalezaB", OdbcType.Char, 1, Naturaleza)
            MyBase.AddParameter("@idrepetitivoB", OdbcType.Int, 16, IdRepetitivo)
            MyBase.AddParameter("@idpercdeducB", OdbcType.Int, 16, IdPercDeduc)

            MyBase.FillDataSet(usp_TraerNominaDet, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVentasNetas(ByVal Sucursal As String, ByVal Vendedor As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 18/Agosto/2012 10:45 a.m.
        Try


            usp_TraerVentasNetas = New DataSet
            If Vendedor = "1" Then
                Vendedor = ""
                MyBase.SQL = "CALL usp_TraerVentasNetas300(?,?,?,?)"
            Else
                MyBase.SQL = "CALL usp_TraerVentasNetasNUEVO(?,?,?,?)"
            End If

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Vendedor)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)


            MyBase.FillDataSet(usp_TraerVentasNetas, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerVentasNetasCajero(ByVal Sucursal As String, ByVal Vendedor As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 18/Agosto/2012 10:45 a.m.
        Try


            usp_TraerVentasNetasCajero = New DataSet

            MyBase.SQL = "CALL usp_TraerVentasNetasCajero(?,?,?,?)"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Vendedor)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)


            MyBase.FillDataSet(usp_TraerVentasNetasCajero, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMarcaPrincipal(ByVal Proveedor As String) As DataSet
        'mreyes 14/Marzo/2012 05:06 p.m.
        Try
            usp_TraerMarcaPrincipal = New DataSet
            MyBase.SQL = "CALL usp_TraerMarcaPrincipal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerMarcaPrincipal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPagoNomina(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerPagoNomina = New DataSet
            MyBase.SQL = "CALL usp_TraerPagoNomina(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@tipoNomB", OdbcType.Char, 1, tipoNom)

            MyBase.FillDataSet(usp_TraerPagoNomina, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNominaADispersar(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerNominaADispersar = New DataSet
            MyBase.SQL = "CALL usp_TraerNominaADispersar(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@tipoNomB", OdbcType.Char, 1, tipoNom)

            MyBase.FillDataSet(usp_TraerNominaADispersar, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoPersonalIng(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerPagoPersonalIng = New DataSet
            MyBase.SQL = "CALL usp_TraerPagoPersonalIng(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@tipoNomB", OdbcType.Char, 1, tipoNom)

            MyBase.FillDataSet(usp_TraerPagoPersonalIng, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoPersonalSinTarjeta(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerPagoPersonalSinTarjeta = New DataSet
            MyBase.SQL = "CALL usp_TraerPagoPersonalSinTarjeta(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@tipoNomB", OdbcType.Char, 1, tipoNom)

            MyBase.FillDataSet(usp_TraerPagoPersonalSinTarjeta, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerPersonalIng(ByVal idPeriodo As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerPersonalIng = New DataSet
            MyBase.SQL = "CALL usp_TraerPersonalIng(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)

            MyBase.FillDataSet(usp_TraerPersonalIng, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerBonoSucursal(ByVal idPeriodo As String, ByVal Sucursal As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerBonoSucursal = New DataSet
            MyBase.SQL = "CALL usp_TraerBonoSucursal(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@idPeriodoB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerBonoSucursal, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPersSinTarjNom(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:06 p.m.
        Try
            usp_TraerPersSinTarjNom = New DataSet
            MyBase.SQL = "CALL usp_TraerPersSinTarjNom(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeriodoB", OdbcType.SmallInt, 4, idPeriodo)
            MyBase.AddParameter("@tipoNomB", OdbcType.Char, 1, tipoNom)

            MyBase.FillDataSet(usp_TraerPersSinTarjNom, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
