Imports System.Data.Odbc
'mreyes 11/Junio/2012 10:13 a.m.

Public Class DALCatalogoEmpleado
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
    Public Function usp_Captura_Horario(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 20/Abril/2015   05:36 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Horario(?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
           
            MyBase.AddParameter("@dia", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("dia"))
            MyBase.AddParameter("@entrada", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("entrada"))
            MyBase.AddParameter("@salida", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("salida"))
            MyBase.AddParameter("@entrada1", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("entrada1"))
            MyBase.AddParameter("@salida1", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("salida1"))

            MyBase.AddParameter("@prioridad", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("prioridad"))
            MyBase.AddParameter("@diaingles", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("diaingles"))


            usp_Captura_Horario = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Empleado(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Junio/2012 04:07 p.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Empleado(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
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
            MyBase.AddParameter("@vendedor", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("vendedor"))
            MyBase.AddParameter("@idfrecpago", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("idfrecpago"))
            MyBase.AddParameter("@jornada", OdbcType.Int, 2, Section.Tables(0).Rows(0).Item("jornada"))
            MyBase.AddParameter("@entrada", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("entrada"))
            MyBase.AddParameter("@comida", OdbcType.Int, 2, Section.Tables(0).Rows(0).Item("comida"))
            MyBase.AddParameter("@descanso", OdbcType.Int, 1, Section.Tables(0).Rows(0).Item("descanso"))

            MyBase.AddParameter("@extras", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("extras"))
            MyBase.AddParameter("@baja", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("baja"))
            MyBase.AddParameter("@ingreso", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("ingreso"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@bonofijo", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("bonofijo"))
            MyBase.AddParameter("@tsalario", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tsalario"))
            MyBase.AddParameter("@zsalario", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("zsalario"))

            MyBase.AddParameter("@porinteg", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("porinteg"))
            MyBase.AddParameter("@sdiario", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("sdiario"))
            MyBase.AddParameter("@shora", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("shora"))
            MyBase.AddParameter("@sinteg", OdbcType.Decimal, 5, Section.Tables(0).Rows(0).Item("sinteg"))
            MyBase.AddParameter("@ptu", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("ptu"))
            MyBase.AddParameter("@imss", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("imss"))
            MyBase.AddParameter("@bono", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("bono"))

            MyBase.AddParameter("@cuenta", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("cuenta"))
            MyBase.AddParameter("@licencia", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("licencia"))
            MyBase.AddParameter("@unimed", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("unimed"))
            MyBase.AddParameter("@calle", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@colonia", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@ciudad", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("ciudad"))
            MyBase.AddParameter("@estado", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("estado"))
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

            MyBase.AddParameter("@beneficiario1", OdbcType.Char, 150, Section.Tables(0).Rows(0).Item("beneficiario1"))
            MyBase.AddParameter("@parentesco1", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("parentesco1"))
            MyBase.AddParameter("@porcentaje1", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("porcentaje1"))

            MyBase.AddParameter("@beneficiario2", OdbcType.Char, 150, Section.Tables(0).Rows(0).Item("beneficiario2"))
            MyBase.AddParameter("@parentesco2", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("parentesco2"))
            MyBase.AddParameter("@porcentaje2", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("porcentaje2"))

            MyBase.AddParameter("@cuentabajio", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("cuentabajio"))



            usp_Captura_Empleado = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleadoCedis(ByVal idEmpleado As Integer) As DataSet
        'mreyes 11/Junio/2012 01;27 p.m.
        Try
            usp_TraerNomEmpleadoCedis = New DataSet
            MyBase.SQL = "CALL usp_TraerNomEmpleadoCedis(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleado", OdbcType.Int, 16, idEmpleado)


            MyBase.FillDataSet(usp_TraerNomEmpleadoCedis, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal Iddepto As Integer) As DataSet
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
            MyBase.AddParameter("@iddeptob", OdbcType.Int, 16, iddepto)

            MyBase.FillDataSet(usp_TraerNomEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNomEmpleadosuc(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal Iddepto As Integer, ByVal sucursal As String) As DataSet
        'mreyes 11/Junio/2012 01;27 p.m.
        Try
            usp_TraerNomEmpleadosuc = New DataSet
            MyBase.SQL = "CALL usp_TraerNomEmpleadosuc(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@ApPaterno", OdbcType.Char, 30, ApPaterno)
            MyBase.AddParameter("@ApMaterno", OdbcType.Char, 30, apMaterno)
            MyBase.AddParameter("@Nombre", OdbcType.Char, 30, Nombre)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@iddeptob", OdbcType.Int, 16, Iddepto)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, sucursal)

            MyBase.FillDataSet(usp_TraerNomEmpleadosuc, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerHorarioEmpleado(ByVal idEmpleado As Integer) As DataSet
        'mreyes 19/Abril/2015   01:23 p.m.
        Try
            usp_TraerHorarioEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerHorarioEmpleado(?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleado", OdbcType.Int, 16, idEmpleado)

            MyBase.FillDataSet(usp_TraerHorarioEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVendedor(ByVal idEmpleado As Integer) As DataSet
        'mreyes 18/AGosto/2012 01:08 p.m.
        Try
            usp_TraerVendedor = New DataSet
            MyBase.SQL = "CALL usp_TraerVendedor(?)"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleado", OdbcType.Int, 16, idEmpleado)

            MyBase.FillDataSet(usp_TraerVendedor, "nomsis")
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
            MyBase.AddParameter("@Sucursal", OdbcType.Int, 2, Sucursal)
            

            MyBase.FillDataSet(usp_TraerClaveEmpleado, "nomsis")
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



    Public Function usp_TraerUsuarioNomina(ByVal Password As String) As DataSet
        'mreyes 20/Junio/2012 12:34 p.m.
        Try
            usp_TraerUsuarioNomina = New DataSet
            MyBase.SQL = "CALL usp_TraerUsuarioNomina(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@passwordb", OdbcType.Char, 30, password)


            MyBase.FillDataSet(usp_TraerUsuarioNomina, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCorreoNomina(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:34 p.m.
        Try
            usp_TraerCorreoNomina = New DataSet
            MyBase.SQL = "CALL usp_TraerCorreoNomina(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idempleado", OdbcType.Int, 8, IdEmpleado)


            MyBase.FillDataSet(usp_TraerCorreoNomina, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoCajero() As DataSet
        'mreyes 26/Otubre/2016  11:48 a.m.

        Try


            usp_PpalCatalogoCajero = New DataSet
            'MyBase.SQL = "usp_PpalCatalogoEmpleado"
            MyBase.SQL = "CALL usp_PpalCatalogoCajero()"

            MyBase.InitializeCommand()


            MyBase.FillDataSet(usp_PpalCatalogoCajero, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_PpalCatalogoEmpleado(ByVal idEmpleado As Integer, ByVal Sucursal As String, _
                                                ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, _
                                                ByVal BajaIni As Date, ByVal BajaFin As Date, ByVal NacimIni As Date, ByVal NacimFin As Date) As DataSet
        'mreyes 15/Junio/2012 04:54 p.m.
        Try


            usp_PpalCatalogoEmpleado = New DataSet
            'MyBase.SQL = "usp_PpalCatalogoEmpleado"
            MyBase.SQL = "CALL usp_PpalCatalogoEmpleado(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@iddepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@idpuesto", OdbcType.Int, 16, IdPuesto)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@inicioini", OdbcType.Date, 8, InicioIni)
            MyBase.AddParameter("@iniciofin", OdbcType.Date, 8, InicioFin)
            MyBase.AddParameter("@bajaini", OdbcType.Date, 8, BajaIni)
            MyBase.AddParameter("@bajafin", OdbcType.Date, 8, BajaFin)
            MyBase.AddParameter("@nacimini", OdbcType.Date, 8, NacimIni)
            MyBase.AddParameter("@nacimfin", OdbcType.Date, 8, NacimFin)

            MyBase.FillDataSet(usp_PpalCatalogoEmpleado, "carganomina")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
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

    Public Function usp_Captura_Cajero(ByVal Cajero As String, ByVal SucNueva As String) As Boolean
        'mreyes 26/Octubre/2016 11:53 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Cajero(?,?)"

            MyBase.InitializeCommand()


            MyBase.AddParameter("@CajeroB", OdbcType.Char, 2, Cajero)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, SucNueva)





            usp_Captura_Cajero = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
