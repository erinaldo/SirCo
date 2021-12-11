'Imports System.Data.Odbc
'mreyes 06/Julio/2016   06:14 p.m.

Imports System.Data
Imports System.Data.SqlClient

Public Class DALTraspasosAutomaticos
    ''''Inherits DALOdbc
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "



    Public Function usp_Captura_Empleado(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Junio/2012 04:07 p.m.
        Try
            'MyBase.SQL = "CALL usp_Captura_Empleado(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            MyBase.SQL = "usp_Captura_Empleado" 'Insert Query

            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@idempleadoB", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@claveB", SqlDbType.Char, 6, Section.Tables(0).Rows(0).Item("clave"))
            MyBase.AddParameter("@appaternoB", SqlDbType.Char, 30, Section.Tables(0).Rows(0).Item("appaterno"))
            MyBase.AddParameter("@apmaternoB", SqlDbType.Char, 30, Section.Tables(0).Rows(0).Item("apmaterno"))
            MyBase.AddParameter("@nombreB", SqlDbType.Char, 30, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@iddeptoB", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@idpuestoB", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idpuesto"))
            MyBase.AddParameter("@vendedorB", SqlDbType.Char, 2, Section.Tables(0).Rows(0).Item("vendedor"))
            MyBase.AddParameter("@idfrecpagoB", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idfrecpago"))
            MyBase.AddParameter("@jornadaB", SqlDbType.Int, 2, Section.Tables(0).Rows(0).Item("jornada"))
            MyBase.AddParameter("@entradaB", SqlDbType.Char, 5, Section.Tables(0).Rows(0).Item("entrada"))
            MyBase.AddParameter("@comidaB", SqlDbType.Int, 2, Section.Tables(0).Rows(0).Item("comida"))
            MyBase.AddParameter("@descansoB", SqlDbType.Int, 1, Section.Tables(0).Rows(0).Item("descanso"))

            MyBase.AddParameter("@extrasB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("extras"))
            MyBase.AddParameter("@bajaB", SqlDbType.Date, 8, Section.Tables(0).Rows(0).Item("baja"))
            MyBase.AddParameter("@ingresoB", SqlDbType.Date, 8, Section.Tables(0).Rows(0).Item("ingreso"))
            MyBase.AddParameter("@estatusB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@bonofijoB", SqlDbType.Decimal, 9, Section.Tables(0).Rows(0).Item("bonofijo"))
            MyBase.AddParameter("@tsalarioB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("tsalario"))
            MyBase.AddParameter("@zsalarioB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("zsalario"))

            MyBase.AddParameter("@porintegB", SqlDbType.Decimal, 5, Section.Tables(0).Rows(0).Item("porinteg"))
            MyBase.AddParameter("@sdiarioB", SqlDbType.Decimal, 5, Section.Tables(0).Rows(0).Item("sdiario"))
            MyBase.AddParameter("@shoraB", SqlDbType.Decimal, 5, Section.Tables(0).Rows(0).Item("shora"))
            MyBase.AddParameter("@sintegB", SqlDbType.Decimal, 5, Section.Tables(0).Rows(0).Item("sinteg"))
            MyBase.AddParameter("@ptuB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("ptu"))
            MyBase.AddParameter("@imssB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("imss"))
            MyBase.AddParameter("@bonoB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("bono"))

            MyBase.AddParameter("@cuentaB", SqlDbType.Char, 20, Section.Tables(0).Rows(0).Item("cuenta"))
            MyBase.AddParameter("@licenciaB", SqlDbType.Char, 18, Section.Tables(0).Rows(0).Item("licencia"))
            MyBase.AddParameter("@unimedB", SqlDbType.Char, 3, Section.Tables(0).Rows(0).Item("unimed"))
            MyBase.AddParameter("@calleB", SqlDbType.Char, 100, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@coloniaB", SqlDbType.Char, 60, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@ciudadB", SqlDbType.Char, 40, Section.Tables(0).Rows(0).Item("ciudad"))
            MyBase.AddParameter("@estadoB", SqlDbType.Char, 40, Section.Tables(0).Rows(0).Item("estado"))
            MyBase.AddParameter("@codposB", SqlDbType.Char, 5, Section.Tables(0).Rows(0).Item("codpos"))
            MyBase.AddParameter("@numextB", SqlDbType.Char, 5, Section.Tables(0).Rows(0).Item("numext"))
            MyBase.AddParameter("@numintB", SqlDbType.Char, 5, Section.Tables(0).Rows(0).Item("numint"))
            MyBase.AddParameter("@sexoB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("sexo"))
            MyBase.AddParameter("@telef1B", SqlDbType.Char, 15, Section.Tables(0).Rows(0).Item("telef1"))
            MyBase.AddParameter("@telef2B", SqlDbType.Char, 15, Section.Tables(0).Rows(0).Item("telef2"))
            MyBase.AddParameter("@emailB", SqlDbType.Char, 80, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@nacimB", SqlDbType.Date, 8, Section.Tables(0).Rows(0).Item("nacim"))
            MyBase.AddParameter("@ciudadnacB", SqlDbType.Char, 40, Section.Tables(0).Rows(0).Item("ciudadnac"))
            MyBase.AddParameter("@edocivilB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("edocivil"))
            MyBase.AddParameter("@numhijosB", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("numhijos"))
            MyBase.AddParameter("@nompadreB", SqlDbType.Char, 100, Section.Tables(0).Rows(0).Item("nompadre"))
            MyBase.AddParameter("@nommadreB", SqlDbType.Char, 100, Section.Tables(0).Rows(0).Item("nommadre"))
            MyBase.AddParameter("@rfcB", SqlDbType.Char, 18, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@curpB", SqlDbType.Char, 18, Section.Tables(0).Rows(0).Item("curp"))
            MyBase.AddParameter("@noimssB", SqlDbType.Char, 18, Section.Tables(0).Rows(0).Item("noimss"))
            MyBase.AddParameter("@checaB", SqlDbType.Char, 1, Section.Tables(0).Rows(0).Item("checa"))
            MyBase.AddParameter("@usuarioB", SqlDbType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodifB", SqlDbType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodifB", SqlDbType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))

            MyBase.AddParameter("@beneficiario1B", SqlDbType.Char, 150, Section.Tables(0).Rows(0).Item("beneficiario1"))
            MyBase.AddParameter("@parentesco1B", SqlDbType.Char, 50, Section.Tables(0).Rows(0).Item("parentesco1"))
            MyBase.AddParameter("@porcentaje1B", SqlDbType.Int, 8, Section.Tables(0).Rows(0).Item("porcentaje1"))

            MyBase.AddParameter("@beneficiario2B", SqlDbType.Char, 150, Section.Tables(0).Rows(0).Item("beneficiario2"))
            MyBase.AddParameter("@parentesco2B", SqlDbType.Char, 50, Section.Tables(0).Rows(0).Item("parentesco2"))
            MyBase.AddParameter("@porcentaje2B", SqlDbType.Int, 8, Section.Tables(0).Rows(0).Item("porcentaje2"))

            MyBase.AddParameter("@cuentabajioB", SqlDbType.Char, 20, Section.Tables(0).Rows(0).Item("cuentabajio"))



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
            MyBase.AddParameter("@idEmpleado", SqlDbType.Int, 16, idEmpleado)


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
            MyBase.AddParameter("@idEmpleado", SqlDbType.Int, 16, idEmpleado)
            MyBase.AddParameter("@ApPaterno", SqlDbType.Char, 30, ApPaterno)
            MyBase.AddParameter("@ApMaterno", SqlDbType.Char, 30, apMaterno)
            MyBase.AddParameter("@Nombre", SqlDbType.Char, 30, Nombre)
            MyBase.AddParameter("@estatus", SqlDbType.Char, 1, Estatus)
            MyBase.AddParameter("@iddeptob", SqlDbType.Int, 16, Iddepto)

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
            MyBase.AddParameter("@idEmpleado", SqlDbType.Int, 16, idEmpleado)
            MyBase.AddParameter("@ApPaterno", SqlDbType.Char, 30, ApPaterno)
            MyBase.AddParameter("@ApMaterno", SqlDbType.Char, 30, apMaterno)
            MyBase.AddParameter("@Nombre", SqlDbType.Char, 30, Nombre)
            MyBase.AddParameter("@estatus", SqlDbType.Char, 1, Estatus)
            MyBase.AddParameter("@iddeptob", SqlDbType.Int, 16, Iddepto)
            MyBase.AddParameter("@sucursal", SqlDbType.Char, 2, sucursal)

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
            'MyBase.SQL = "CALL usp_TraerHorarioEmpleado(?)"
            MyBase.SQL = "usp_TraerHorarioEmpleado"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleadob", SqlDbType.Int, 16, idEmpleado)

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
            MyBase.AddParameter("@idEmpleado", SqlDbType.Int, 16, idEmpleado)

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
            MyBase.AddParameter("@Sucursal", SqlDbType.Int, 2, Sucursal)


            MyBase.FillDataSet(usp_TraerClaveEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVendedor(ByVal Idempleado As Integer, ByVal Sucursal As String) As DataSet
        'mreyes 27/Diciembre/2016   10:56 a.m.
        Try
            usp_TraerVendedor = New DataSet
            MyBase.SQL = "usp_TraerVendedor"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idempleadob", SqlDbType.Int, 8, idempleado)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)


            MyBase.FillDataSet(usp_TraerVendedor, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:34 p.m.
        Try
            usp_TraerEmpleado = New DataSet
            MyBase.SQL = "usp_TraerEmpleado"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleadoB", SqlDbType.Int, 16, IdEmpleado)


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
            MyBase.SQL = "usp_TraerUsuarioNomina"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@passwordb", SqlDbType.Char, 30, Password)


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
            MyBase.AddParameter("@Idempleado", SqlDbType.Int, 8, IdEmpleado)


            MyBase.FillDataSet(usp_TraerCorreoNomina, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalProTraspDetNoAplica(ByVal IdSucursalB As Integer) As DataSet

        'mreyes 18/Agosto/2016  07:02 p.m.
        Try


            usp_PpalProTraspDetNoAplica = New DataSet
            MyBase.SQL = "usp_PpalProTraspDetNoAplica"


            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 16, IdSucursalB)



            MyBase.FillDataSet(usp_PpalProTraspDetNoAplica, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_MatchTraspAut(ByVal Opcion As Integer, ByVal IdProTras As Integer) As DataSet
        'mreyes 26/Enero/2017   04:29 p.m.
        Try


            usp_MatchTraspAut = New DataSet
            MyBase.SQL = "usp_MatchTraspAut"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@OpcionB", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@IdProTrasB", SqlDbType.Int, 8, IdProTras)


            MyBase.FillDataSet(usp_MatchTraspAut, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function
    Public Function usp_PpalNegBodega(ByVal Sucursal As String, ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalNegBodega = New DataSet
            MyBase.SQL = "usp_PpalNegBodega"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@FechaIniB", SqlDbType.Char, 10, fechaini)
            MyBase.AddParameter("@FechaFinB", SqlDbType.Char, 10, fechafin)

            MyBase.AddParameter("@Division", SqlDbType.VarChar, 30, Division)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, Depto)
            MyBase.AddParameter("@Familia", SqlDbType.VarChar, 30, Familia)
            MyBase.AddParameter("@Linea", SqlDbType.VarChar, 30, Linea)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 30, L1)
            MyBase.AddParameter("@l2", SqlDbType.VarChar, 30, L2)
            MyBase.AddParameter("@l3", SqlDbType.VarChar, 30, L3)
            MyBase.AddParameter("@l4", SqlDbType.VarChar, 30, L4)
            MyBase.AddParameter("@l5", SqlDbType.VarChar, 30, L5)
            MyBase.AddParameter("@l6", SqlDbType.VarChar, 30, L6)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 16, Idagrupacion)


            MyBase.FillDataSet(usp_PpalNegBodega, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalNoMostrados(ByVal Sucursal As String, ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalNoMostrados = New DataSet
            MyBase.SQL = "usp_PpalNoMostrados"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@FechaIniB", SqlDbType.Char, 10, fechaini)
            MyBase.AddParameter("@FechaFinB", SqlDbType.Char, 10, fechafin)

            MyBase.AddParameter("@Division", SqlDbType.VarChar, 30, Division)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, Depto)
            MyBase.AddParameter("@Familia", SqlDbType.VarChar, 30, Familia)
            MyBase.AddParameter("@Linea", SqlDbType.VarChar, 30, Linea)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 30, L1)
            MyBase.AddParameter("@l2", SqlDbType.VarChar, 30, L2)
            MyBase.AddParameter("@l3", SqlDbType.VarChar, 30, L3)
            MyBase.AddParameter("@l4", SqlDbType.VarChar, 30, L4)
            MyBase.AddParameter("@l5", SqlDbType.VarChar, 30, L5)
            MyBase.AddParameter("@l6", SqlDbType.VarChar, 30, L6)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 16, Idagrupacion)


            MyBase.FillDataSet(usp_PpalNoMostrados, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCurvaIdeal(ByVal Sucursal As String, ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalCurvaIdeal = New DataSet
            MyBase.SQL = "usp_PpalCurvaIdeal"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@FechaIniB", SqlDbType.Char, 10, fechaini)
            MyBase.AddParameter("@FechaFinB", SqlDbType.Char, 10, fechafin)

            MyBase.AddParameter("@Division", SqlDbType.VarChar, 30, Division)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, Depto)
            MyBase.AddParameter("@Familia", SqlDbType.VarChar, 30, Familia)
            MyBase.AddParameter("@Linea", SqlDbType.VarChar, 30, Linea)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 30, L1)
            MyBase.AddParameter("@l2", SqlDbType.VarChar, 30, L2)
            MyBase.AddParameter("@l3", SqlDbType.VarChar, 30, L3)
            MyBase.AddParameter("@l4", SqlDbType.VarChar, 30, L4)
            MyBase.AddParameter("@l5", SqlDbType.VarChar, 30, L5)
            MyBase.AddParameter("@l6", SqlDbType.VarChar, 30, L6)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 16, Idagrupacion)

            MyBase.Command.CommandTimeout = 0
            MyBase.FillDataSet(usp_PpalCurvaIdeal, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalPedSinVenta(ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalPedSinVenta = New DataSet
            MyBase.SQL = "usp_PpalPedSinVenta"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@FechaIniB", SqlDbType.Char, 10, fechaini)
            MyBase.AddParameter("@FechaFinB", SqlDbType.Char, 10, fechafin)

            MyBase.AddParameter("@Division", SqlDbType.VarChar, 30, Division)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, Depto)
            MyBase.AddParameter("@Familia", SqlDbType.VarChar, 30, Familia)
            MyBase.AddParameter("@Linea", SqlDbType.VarChar, 30, Linea)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 30, L1)
            MyBase.AddParameter("@l2", SqlDbType.VarChar, 30, L2)
            MyBase.AddParameter("@l3", SqlDbType.VarChar, 30, L3)
            MyBase.AddParameter("@l4", SqlDbType.VarChar, 30, L4)
            MyBase.AddParameter("@l5", SqlDbType.VarChar, 30, L5)
            MyBase.AddParameter("@l6", SqlDbType.VarChar, 30, L6)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 16, Idagrupacion)


            MyBase.FillDataSet(usp_PpalPedSinVenta, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalProTrasp(ByVal Opcion As Integer, ByVal IdProTras As Integer, ByVal IdSucursal As Integer,
                                            ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Estatus As String) As DataSet
        'mreyes 06/Julio/2016
        Try


            usp_PpalProTrasp = New DataSet
            MyBase.SQL = "usp_PpalProTrasp"
            'MyBase.SQL = "CALL usp_PpalCatalogoEmpleado(?,?,?,?,?,?,?,?,?,?,?)"
            '@OpcionB int, @IdProTrasB int, 
            '@IdSucursalB int, @FechaInib date, @FechaFinb date, @EstatusB varchar(2)

            MyBase.InitializeCommand()
            MyBase.AddParameter("@OpcionB", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@IdProTrasB", SqlDbType.Int, 8, IdProTras)
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 16, IdSucursal)
            MyBase.AddParameter("@FechaInib", SqlDbType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFinb", SqlDbType.Date, 8, FechaFin)
            MyBase.AddParameter("@EstatusB", SqlDbType.VarChar, 2, Estatus)


            MyBase.FillDataSet(usp_PpalProTrasp, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_TraspasoEnLineaSalida(Sucursal As String) As DataSet
        'mreyes 30/Mayo/2019    04:38 p.m.
        Try


            usp_TraspasoEnLineaSalida = New DataSet
            MyBase.SQL = "usp_TraspasoEnLineaSalida"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)

            MyBase.FillDataSet(usp_TraspasoEnLineaSalida, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_TraspasoEnLinea(Sucursal As String) As DataSet
        'mreyes 05/Abril/2018   11:51 a.m.
        Try


            usp_TraspasoEnLinea = New DataSet
            MyBase.SQL = "usp_TraspasoEnLinea"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)

            MyBase.FillDataSet(usp_TraspasoEnLinea, "SirCo")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_PpalResurtidoTmp(ByVal Opcion As Integer, ByVal Marca As String, ByVal IdSucursal As Integer, ByVal Proveedor As String, Depto As String) As DataSet
        'mreyes 06/Julio/2016
        Try


            usp_PpalResurtidoTmp = New DataSet
            MyBase.SQL = "usp_PpalResurtidoTmp"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@OpcionB", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@IdSucursalB", SqlDbType.Int, 8, IdSucursal)
            MyBase.AddParameter("@ProveedorB", SqlDbType.VarChar, 3, Proveedor)
            MyBase.AddParameter("@DeptoB", SqlDbType.VarChar, 50, Depto)

            MyBase.FillDataSet(usp_PpalResurtidoTmp, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function
    Public Function usp_PpalResumenProTrasp() As DataSet
        'mreyes 07/Octubre/2016 11:36 a.m.
        Try


            usp_PpalResumenProTrasp = New DataSet
            MyBase.SQL = "usp_PpalResumenProTrasp"
            'MyBase.SQL = "CALL usp_PpalCatalogoEmpleado(?,?,?,?,?,?,?,?,?,?,?)"
            '@OpcionB int, @IdProTrasB int, 
            '@IdSucursalB int, @FechaInib date, @FechaFinb date, @EstatusB varchar(2)

            MyBase.InitializeCommand()
  


            MyBase.FillDataSet(usp_PpalResumenProTrasp, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_PpalResumenUsuario() As DataSet
        'mreyes 03/Noviembre/2016   11:43 a.m.
        Try


            usp_PpalResumenUsuario = New DataSet
            MyBase.SQL = "usp_PpalResumenUsuario"
   

            MyBase.InitializeCommand()



            MyBase.FillDataSet(usp_PpalResumenUsuario, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function



    Public Function usp_GeneraPropuestaTraspasos(ByVal MarcaB As String, ByVal EstilonB As String, ByVal FechaIniB As String, ByVal FechaFinB As String, ByVal DivisionB As String, ByVal LineaB As String, ByVal L1B As String, ByVal Agrupacionb As Integer, ByVal Sw_Generar As Integer, ByVal IdUsuario As Integer) As DataSet
        'mreyes 18/Julio/2016   
        Try


            usp_GeneraPropuestaTraspasos = New DataSet
            MyBase.SQL = "usp_GeneraPropuestaTraspasos"
            'EXEC usp_GeneraPropuestaTraspasos 'FFF', '   2300','A','20160519','20160718', 'CALZADO','DAMAS','ESCOLAR'
            ' @MarcaB varchar(3), @EstilonB varchar(7), @CorridaB varchar(3),  @FechaIniB varchar(8), @FechaFinB varchar(8) ,
            '	 @DivisionB varchar(50), @LineaB varchar(50), @L1B varchar(50)


            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, EstilonB)
            MyBase.AddParameter("@FechaIniB", SqlDbType.VarChar, 8, FechaIniB)
            MyBase.AddParameter("@FechaFinB", SqlDbType.VarChar, 8, FechaFinB)
            MyBase.AddParameter("@DivisionB", SqlDbType.VarChar, 50, DivisionB)
            MyBase.AddParameter("@LineaB", SqlDbType.VarChar, 50, LineaB)
            MyBase.AddParameter("@L1B", SqlDbType.VarChar, 50, L1B)
            MyBase.AddParameter("@AgrupacionB", SqlDbType.SmallInt, 4, Agrupacionb)
            MyBase.AddParameter("@Sw_Generar", SqlDbType.SmallInt, 3, Sw_Generar)
            MyBase.AddParameter("@IdUsuario", SqlDbType.SmallInt, 8, IdUsuario)




            MyBase.FillDataSet(usp_GeneraPropuestaTraspasos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_GeneraPedidoxCurvaIdeal(Opcion As Integer, Entregas As Integer, ByVal Marca As String, ByVal Estilof As String, Linea As String, L1 As String, Intervalo As String, MedIni As String, MedFin As String, Pares As Integer) As DataSet
        'mreyes 17/Octubre/2017 05:44 p.m.

        Try


            usp_GeneraPedidoxCurvaIdeal = New DataSet
            MyBase.SQL = "usp_GeneraPedidoxCurvaIdeal"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.SmallInt, 8, Opcion)
            MyBase.AddParameter("@entregas", SqlDbType.SmallInt, 8, Entregas)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilof", SqlDbType.VarChar, 14, Estilof)
            MyBase.AddParameter("@linea", SqlDbType.VarChar, 50, Linea)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 50, L1)
            MyBase.AddParameter("@intervalo", SqlDbType.VarChar, 1, Intervalo)
            MyBase.AddParameter("@medini", SqlDbType.VarChar, 3, MedIni)
            MyBase.AddParameter("@medfin", SqlDbType.VarChar, 3, MedFin)
            MyBase.AddParameter("@pares", SqlDbType.Int, 8, Pares)


            MyBase.FillDataSet(usp_GeneraPedidoxCurvaIdeal, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_TraerCurva(ByVal MarcaB As String, ByVal EstilonB As String) As DataSet
        'mreyes 15/Enero/2019   03:56 p.m.
        Try


            usp_TraerCurva = New DataSet
            MyBase.SQL = "usp_TraerCurva"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, EstilonB)




            MyBase.FillDataSet(usp_TraerCurva, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function
    Public Function usp_TraerExistenciaDirectaMySqlporMedida(ByVal MarcaB As String, ByVal EstilonB As String, MedidaB As String, ByVal Sucursalb As String) As DataSet
        'mreyes 10/Abril/2017   11:04 a.m.
        Try


            usp_TraerExistenciaDirectaMySqlporMedida = New DataSet
            MyBase.SQL = "usp_TraerExistenciaDirectaMySqlporMedida"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, EstilonB)
            MyBase.AddParameter("@Medidab", SqlDbType.VarChar, 3, MedidaB)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursalb)




            MyBase.FillDataSet(usp_TraerExistenciaDirectaMySqlporMedida, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_TraerExistenciaDirectaMySql(ByVal MarcaB As String, ByVal EstilonB As String, ByVal Sucursalb As String) As DataSet
        'mreyes 27/Diciembre/2016   10:26 a.m.
        Try


            usp_TraerExistenciaDirectaMySql = New DataSet
            MyBase.SQL = "usp_TraerExistenciaDirectaMySql"
            'EXEC usp_GeneraPropuestaTraspasos 'FFF', '   2300','A','20160519','20160718', 'CALZADO','DAMAS','ESCOLAR'
            ' @MarcaB varchar(3), @EstilonB varchar(7), @CorridaB varchar(3),  @FechaIniB varchar(8), @FechaFinB varchar(8) ,
            '	 @DivisionB varchar(50), @LineaB varchar(50), @L1B varchar(50)


            MyBase.InitializeCommand()
            MyBase.AddParameter("@MarcaB", SqlDbType.VarChar, 3, MarcaB)
            MyBase.AddParameter("@EstilonB", SqlDbType.VarChar, 7, EstilonB)
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursalb)




            MyBase.FillDataSet(usp_TraerExistenciaDirectaMySql, "cipsis")
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
            MyBase.AddParameter("@ProveedorB", SqlDbType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerMarcaPrincipal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_ProTraspArticulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Julio/2016   11:34 a.m.
        Try
            'MyBase.SQL = "CALL usp_Captura_Empleado(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            MyBase.SQL = "usp_Captura_ProTraspArticulo" 'Insert Query

            'Initialize the Command object
            MyBase.InitializeCommand()


            MyBase.AddParameter("@opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@iddivisionesB", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("iddivisiones"))
            MyBase.AddParameter("@divisionB", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("division"))
            MyBase.AddParameter("@iddeptoB", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("iddepto"))
            MyBase.AddParameter("@deptob", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("depto"))
            MyBase.AddParameter("@idfamiliab", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idfamilia"))
            MyBase.AddParameter("@familiab", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("familia"))
            MyBase.AddParameter("@idlineab", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idlinea"))
            MyBase.AddParameter("@lineab", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("linea"))
            MyBase.AddParameter("@idl1b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl1"))
            MyBase.AddParameter("@l1b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l1"))
            MyBase.AddParameter("@idl2b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl2"))
            MyBase.AddParameter("@l2b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l2"))
            MyBase.AddParameter("@idl3b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl3"))
            MyBase.AddParameter("@l3b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l3"))
            MyBase.AddParameter("@idl4b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl4"))
            MyBase.AddParameter("@l4b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l4"))
            MyBase.AddParameter("@idl5b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl5"))
            MyBase.AddParameter("@l5b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l5"))
            MyBase.AddParameter("@idl6b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl5"))
            MyBase.AddParameter("@l6b", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("l6"))
            MyBase.AddParameter("@idl6b", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idl6"))
            MyBase.AddParameter("@idagrupacionb", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idagrupacion"))
            MyBase.AddParameter("@agrupacionb", SqlDbType.VarChar, 50, Section.Tables(0).Rows(0).Item("agrupacion"))
            MyBase.AddParameter("@fechab", SqlDbType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@statusb", SqlDbType.VarChar, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@marcab", SqlDbType.VarChar, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@estilonb", SqlDbType.VarChar, 7, Section.Tables(0).Rows(0).Item("estilon"))
            MyBase.AddParameter("@idusuariob", SqlDbType.Int, 6, Section.Tables(0).Rows(0).Item("idusuario"))




            usp_Captura_ProTraspArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraTraspasoCurvaIdeal(IdFolioB As Integer) As Boolean

        'mreyes 24/Febrero/2017     05:43 p.m.

        Try


            MyBase.SQL = "usp_GeneraTraspasoCurvaIdeal"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection

            MyBase.AddParameter("@IdFolioB", SqlDbType.Int, 8, IdFolioB)


            'Execute the stored procedure
            usp_GeneraTraspasoCurvaIdeal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As String, ByVal idusuario As String, ByVal Liq As Integer) As Boolean

        'mreyes 19/Julio/2016   01:27 p.m.

        Try


            MyBase.SQL = "usp_GeneraProTraspArticulo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@iddivisiones", SqlDbType.VarChar, 60, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.VarChar, 60, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.VarChar, 6, idagrupacion)
            MyBase.AddParameter("@idusuario", SqlDbType.VarChar, 6, idusuario)
            MyBase.AddParameter("@liq", SqlDbType.Int, 8, Liq)


            'Execute the stored procedure
            usp_GeneraProTraspArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerArticulosMismaEstructura(ByVal Sucursal As String, ByVal Medida As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String,
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, IdAgrupacion As Integer) As DataSet

        'mreyes 19/Julio/2016   01:27 p.m.

        Try

            usp_TraerArticulosMismaEstructura = New DataSet
            MyBase.SQL = "usp_TraerArticulosMismaEstructura"
            'Initialize the Command object
            MyBase.InitializeCommand()

            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@SucursalB", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)

            MyBase.AddParameter("@iddivisiones", SqlDbType.VarChar, 60, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.VarChar, 60, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 16, IdAgrupacion)



            MyBase.FillDataSet(usp_TraerArticulosMismaEstructura, "cipsis")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraAnaModArticulo(ByVal Opcion As Integer, ByVal Marca As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As String, ByVal idusuario As Integer) As Boolean

        'mreyes 16/Agosto/2016  04:27 p.m.

        Try


            MyBase.SQL = "usp_GeneraAnaModArticulo"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 6, opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@iddivisiones", SqlDbType.VarChar, 60, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.VarChar, 60, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.VarChar, 6, idagrupacion)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)


            'Execute the stored procedure
            usp_GeneraAnaModArticulo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As Integer, ByVal Propuesta As Integer) As DataSet
        'mreyes 21/Julio/2016   11:44 a.m.
        Try


            usp_TraerProTraspArticulo = New DataSet
            MyBase.SQL = "usp_TraerProTraspArticulo"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 6, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 6, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)

            MyBase.AddParameter("@propuesta", SqlDbType.Int, 6, Propuesta)


            MyBase.FillDataSet(usp_TraerProTraspArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_TraerAnaModArticulo(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer, ByVal idUsuario As Integer) As DataSet

        'mreyes 16/Agosto/2016  04:29 p.m.
        Try


            usp_TraerAnaModArticulo = New DataSet
            MyBase.SQL = "usp_TraerAnaModArticulo"


            MyBase.InitializeCommand()
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 6, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 6, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 60, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)

            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idUsuario)


            MyBase.FillDataSet(usp_TraerAnaModArticulo, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function
    Public Function usp_Captura_ProtraspDetNoaplica(ByVal Opcion As Integer, ByVal Serie As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Sucursal As String, ByVal Observa As String, ByVal IdUsuario As Integer) As Boolean
        'mreyes 18/Agosto/2016  05:40 p.m.

        Try
            MyBase.SQL = "usp_Captura_ProtraspDetNoaplica"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@observa", SqlDbType.VarChar, 200, Observa)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)



            usp_Captura_ProtraspDetNoaplica = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_ProtraspPropuesto(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal SucurOri As Integer, ByVal SucurDes As Integer, ByVal Ctd As Integer, ByVal IdUsuario As Integer) As Boolean
        'mreyes 25/Julio/2016   01:23 p.m.

        Try
            MyBase.SQL = "usp_Captura_ProtraspPropuesto"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@SucurOri", SqlDbType.Int, 6, SucurOri)
            MyBase.AddParameter("@SucurDes", SqlDbType.Int, 6, SucurDes)
            MyBase.AddParameter("@ctd", SqlDbType.Int, 16, Ctd)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)



            usp_Captura_ProtraspPropuesto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CurvaIdeal(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, Vigencia As Date, ByVal Medida As String,
                                           ByVal SucurOri As Integer, Frecuencia As String, Dia As String, MinimoPares As Integer, ByVal Ctd As Integer, ByVal IdUsuario As Integer) As Boolean
        'mreyes 15/Enero/2019   06:17 p.m.

        Try
            MyBase.SQL = "usp_Captura_CurvaIdeal"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 16, Opcion)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Vigencia", SqlDbType.Date, 10, Vigencia)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@SucurOri", SqlDbType.Int, 6, SucurOri)
            MyBase.AddParameter("@Frecuencia", SqlDbType.VarChar, 50, Frecuencia)
            MyBase.AddParameter("@Dia", SqlDbType.VarChar, 50, Dia)
            MyBase.AddParameter("@minimopares", SqlDbType.Int, 16, MinimoPares)
            MyBase.AddParameter("@ctd", SqlDbType.Int, 16, Ctd)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)



            usp_Captura_CurvaIdeal = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_PedBodega(ByVal Sucursal As String, ByVal Nota As String, ByVal Fecha As Date, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal IdUsuario As Integer, ByVal Vendedor As Integer, ByVal Propuesta As Integer) As Boolean
        'mreyes 29/Diciembre/2016   12:33 p.m.

        Try
            MyBase.SQL = "usp_Captura_PedBodega"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Nota", SqlDbType.VarChar, 6, Nota)
            MyBase.AddParameter("@Fecha", SqlDbType.Date, 8, Fecha)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)
            MyBase.AddParameter("@Vendedor", SqlDbType.Int, 8, Vendedor)
            MyBase.AddParameter("@propuesta", SqlDbType.SmallInt, 3, Propuesta)





            usp_Captura_PedBodega = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMuestrasdet(ByVal opcion As Integer, ByVal idmuestra As Integer, Estatus As String, ByVal marcaB As String,
                                                ByVal estilof As String,
                                                descrip As String,
                                               iddivisiones As Integer, division As String,
                                               iddepto As Integer, depto As String,
                                            idfamilia As Integer, familia As String,
                                            idlinea As Integer, linea As String,
                                            idl1 As Integer, l1 As String,
                                            idl2 As Integer, l2 As String,
                                            idl3 As Integer, l3 As String,
                                            idl4 As Integer, l4 As String,
                                            idl5 As Integer, l5 As String,
                                            idl6 As Integer, l6 As String) As DataSet
        'mreyes 09/Agosto/2017  01:21 p.m.
        Try

            usp_PpalMuestrasdet = New DataSet
            MyBase.SQL = "usp_PpalMuestrasdet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@idmuestra", SqlDbType.Int, 10, idmuestra)
            MyBase.AddParameter("@estatus", SqlDbType.VarChar, 2, Estatus)
            MyBase.AddParameter("@marcaB", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@estilof", SqlDbType.VarChar, 14, estilof)
            MyBase.AddParameter("@descrip", SqlDbType.VarChar, 70, descrip)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 8, iddivisiones)
            MyBase.AddParameter("@division", SqlDbType.VarChar, 30, division)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 8, iddepto)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, depto)
            MyBase.AddParameter("@idfamilia", SqlDbType.Int, 8, idfamilia)
            MyBase.AddParameter("@familia", SqlDbType.VarChar, 30, familia)
            MyBase.AddParameter("@idlinea", SqlDbType.Int, 8, idlinea)
            MyBase.AddParameter("@linea", SqlDbType.VarChar, 30, linea)
            MyBase.AddParameter("@idl1", SqlDbType.Int, 8, idl1)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 30, l1)
            MyBase.AddParameter("@idl2", SqlDbType.Int, 8, idl2)
            MyBase.AddParameter("@l2", SqlDbType.VarChar, 30, l2)
            MyBase.AddParameter("@idl3", SqlDbType.Int, 8, idl3)
            MyBase.AddParameter("@l3", SqlDbType.VarChar, 30, l3)
            MyBase.AddParameter("@idl4", SqlDbType.Int, 8, idl4)
            MyBase.AddParameter("@l4", SqlDbType.VarChar, 30, l4)
            MyBase.AddParameter("@idl5", SqlDbType.Int, 8, idl5)
            MyBase.AddParameter("@l5", SqlDbType.VarChar, 30, l5)
            MyBase.AddParameter("@idl6", SqlDbType.Int, 8, idl6)
            MyBase.AddParameter("@l6", SqlDbType.VarChar, 30, l6)


            MyBase.FillDataSet(usp_PpalMuestrasdet, "SirCoAPP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalBasicos(ByVal opcion As Integer, ByVal idmuestra As Integer, Estatus As String, ByVal marcaB As String,
                                                ByVal estilof As String,
                                                descrip As String,
                                               iddivisiones As Integer, division As String,
                                               iddepto As Integer, depto As String,
                                            idfamilia As Integer, familia As String,
                                            idlinea As Integer, linea As String,
                                            idl1 As String,
                                            idl2 As String,
                                            idl3 As String,
                                            idl4 As String,
                                            idl5 As String,
                                            idl6 As String, FechaReciboIni As Date, FechaReciboFin As Date,
                                    TodosCurva As Integer, TodosVencido As Integer,
                                    Dias As Integer, Existencia As Integer) As DataSet
        'mreyes 15/Enero/2019   09:40 a.m.
        Try

            usp_PpalBasicos = New DataSet
            MyBase.SQL = "usp_PpalBasicos"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@idmuestra", SqlDbType.Int, 10, idmuestra)
            MyBase.AddParameter("@estatus", SqlDbType.VarChar, 2, Estatus)
            MyBase.AddParameter("@marcaB", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@estilof", SqlDbType.VarChar, 14, estilof)
            MyBase.AddParameter("@descrip", SqlDbType.VarChar, 70, descrip)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 8, iddivisiones)
            MyBase.AddParameter("@division", SqlDbType.VarChar, 30, division)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 8, iddepto)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, depto)
            MyBase.AddParameter("@idfamilia", SqlDbType.Int, 8, idfamilia)
            MyBase.AddParameter("@familia", SqlDbType.VarChar, 30, familia)
            MyBase.AddParameter("@idlinea", SqlDbType.Int, 8, idlinea)
            MyBase.AddParameter("@linea", SqlDbType.VarChar, 30, linea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 50, idl1)

            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 50, idl2)

            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 50, idl3)

            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 50, idl4)

            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 50, idl5)

            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 50, idl6)
            MyBase.AddParameter("@Fechareciboini", SqlDbType.Date, 10, FechaReciboIni)
            MyBase.AddParameter("@FechaReciboFin", SqlDbType.Date, 10, FechaReciboFin)

            MyBase.AddParameter("@todoscurva", SqlDbType.Int, 8, TodosCurva)
            MyBase.AddParameter("@todosvencido", SqlDbType.Int, 8, TodosVencido)

            MyBase.AddParameter("@dias", SqlDbType.Int, 8, Dias)

            MyBase.AddParameter("@existencia", SqlDbType.Int, 8, Existencia)


            MyBase.FillDataSet(usp_PpalBasicos, "SirCoAPP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProveedorMuestras(ByVal marcaB As String,
                                                ByVal estilof As String) As DataSet
        'mreyes 24/Octubre/2017 10:13 a.m.
        Try

            usp_TraerProveedorMuestras = New DataSet
            MyBase.SQL = "usp_TraerProveedorMuestras"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@estilof", SqlDbType.VarChar, 14, estilof)


            MyBase.FillDataSet(usp_TraerProveedorMuestras, "SirCoAPP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostosPreciosMuestrasDet(ByVal opcion As Integer, ByVal marcaB As String,
                                                ByVal estilof As String
                                       ) As DataSet
        'mreyes 03/Octubre/2017 11:56   a.m.
        Try

            usp_TraerCostosPreciosMuestrasDet = New DataSet
            MyBase.SQL = "usp_TraerCostosPreciosMuestrasDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@estilof", SqlDbType.VarChar, 14, estilof)



            MyBase.FillDataSet(usp_TraerCostosPreciosMuestrasDet, "SirCoAPP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalMuestrasMarca(opcion, marcaB, NombreB, Raz_SocB, VendedorB, TarjetaB, ComentariosB, IdUsuarioB) As DataSet
        'mreyes 09/Agosto/2017  01:21 p.m.
        Try

            usp_PpalMuestrasMarca = New DataSet
            MyBase.SQL = "usp_Captura_MuestrasMarca"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 50, NombreB)
            MyBase.AddParameter("@raz_soc", SqlDbType.VarChar, 150, Raz_SocB)
            MyBase.AddParameter("@vendedor", SqlDbType.VarChar, 200, VendedorB)
            MyBase.AddParameter("@tarjeta", SqlDbType.Image, TarjetaB.Length, TarjetaB)
            MyBase.AddParameter("@comentarios", SqlDbType.NVarChar, 1000, ComentariosB)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, IdUsuarioB)



            MyBase.FillDataSet(usp_PpalMuestrasMarca, "SirCoAPP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdMuestras() As DataSet
        'mreyes 06/Septiembre/2017  09:58 a.m.
        Try

            usp_TraerIdMuestras = New DataSet
            MyBase.SQL = "usp_TraerIdMuestras"

            MyBase.InitializeCommand()



            MyBase.FillDataSet(usp_TraerIdMuestras, "SirCoAPP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Muestrasdet(ByVal opcion As Integer, ByVal idmuestra As Integer, ByVal marcaB As String,
                                                ByVal estilof As String,
                                                descrip As String,
                                               iddivisiones As Integer, division As String,
                                               iddepto As Integer, depto As String,
                                            idfamilia As Integer, familia As String,
                                            idlinea As Integer, linea As String,
                                            idl1 As Integer, l1 As String,
                                            idl2 As Integer, l2 As String,
                                            idl3 As Integer, l3 As String,
                                            idl4 As Integer, l4 As String,
                                            idl5 As Integer, l5 As String,
                                            idl6 As Integer, l6 As String,
                                             ByVal intervalo As String,
                                                ByVal medini As String, ByVal medfin As String,
        ByVal preciolista As Decimal,
        ByVal costo As Decimal, ByVal precio As Decimal, IMAGEN As Byte(),
                                                ByVal idusuario As Integer) As Boolean
        'mreyes 09/Agosto/2017  01:03 p.m.
        Try

            MyBase.SQL = "usp_Captura_Muestrasdet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@accion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@idmuestra", SqlDbType.Int, 10, idmuestra)
            MyBase.AddParameter("@marcaB", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@estilof", SqlDbType.VarChar, 14, estilof)
            MyBase.AddParameter("@descrip", SqlDbType.VarChar, 70, descrip)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 8, iddivisiones)
            MyBase.AddParameter("@division", SqlDbType.VarChar, 30, division)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 8, iddepto)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 30, depto)
            MyBase.AddParameter("@idfamilia", SqlDbType.Int, 8, idfamilia)
            MyBase.AddParameter("@familia", SqlDbType.VarChar, 30, familia)
            MyBase.AddParameter("@idlinea", SqlDbType.Int, 8, idlinea)
            MyBase.AddParameter("@linea", SqlDbType.VarChar, 30, linea)
            MyBase.AddParameter("@idl1", SqlDbType.Int, 8, idl1)
            MyBase.AddParameter("@l1", SqlDbType.VarChar, 30, l1)
            MyBase.AddParameter("@idl2", SqlDbType.Int, 8, idl2)
            MyBase.AddParameter("@l2", SqlDbType.VarChar, 30, l2)
            MyBase.AddParameter("@idl3", SqlDbType.Int, 8, idl3)
            MyBase.AddParameter("@l3", SqlDbType.VarChar, 30, l3)
            MyBase.AddParameter("@idl4", SqlDbType.Int, 8, idl4)
            MyBase.AddParameter("@l4", SqlDbType.VarChar, 30, l4)
            MyBase.AddParameter("@idl5", SqlDbType.Int, 8, idl5)
            MyBase.AddParameter("@l5", SqlDbType.VarChar, 30, l5)
            MyBase.AddParameter("@idl6", SqlDbType.Int, 8, idl6)
            MyBase.AddParameter("@l6", SqlDbType.VarChar, 30, l6)
            MyBase.AddParameter("@intervalo", SqlDbType.VarChar, 1, intervalo)
            MyBase.AddParameter("@medIni", SqlDbType.VarChar, 3, medini)
            MyBase.AddParameter("@medFin", SqlDbType.VarChar, 3, medfin)
            MyBase.AddParameter("@preciolista", SqlDbType.Decimal, 8, preciolista)
            MyBase.AddParameter("@costo", SqlDbType.Decimal, 8, costo)
            MyBase.AddParameter("@precio", SqlDbType.Decimal, 8, precio)
            MyBase.AddParameter("@imagen", SqlDbType.Image, IMAGEN.Length, IMAGEN)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, idusuario)



            usp_Captura_Muestrasdet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_MuestrasMarca(ByVal opcion As Integer, ByVal marcaB As String, NombreB As String, Raz_SocB As String, VendedorB As String, TarjetaB As Byte(), ComentariosB As String, IdUsuarioB As Integer) As Boolean
        'mreyes 06/Septiembre/2017  10:44 a.m.
        Try

            MyBase.SQL = "usp_Captura_MuestrasMarca"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@nombre", SqlDbType.VarChar, 50, NombreB)
            MyBase.AddParameter("@raz_soc", SqlDbType.VarChar, 150, Raz_SocB)
            MyBase.AddParameter("@vendedor", SqlDbType.VarChar, 200, VendedorB)
            MyBase.AddParameter("@tarjeta", SqlDbType.Image, TarjetaB.Length, TarjetaB)
            MyBase.AddParameter("@comentarios", SqlDbType.NVarChar, 1000, ComentariosB)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 8, IdUsuarioB)



            usp_Captura_MuestrasMarca = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PedidoTmp(opcion As Integer, marca As String, Estilof As String, EntregaAnt As String, EntregaNvo As String, Medida As String, IdSucursal As Integer, Ctd As Integer) As Boolean
        'mreyes 18/Octubre/2017     12:25 p.m.
        Try

            MyBase.SQL = "usp_Captura_PedidoTmp"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 8, opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, marca)
            MyBase.AddParameter("@estilof", SqlDbType.VarChar, 14, Estilof)

            MyBase.AddParameter("@entregaant", SqlDbType.VarChar, 10, EntregaAnt)
            MyBase.AddParameter("@entreganvo", SqlDbType.VarChar, 10, EntregaNvo)
            MyBase.AddParameter("@medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@idsucursal", SqlDbType.Int, 16, IdSucursal)
            MyBase.AddParameter("@ctd", SqlDbType.Int, 16, Ctd)


            usp_Captura_PedidoTmp = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Muestras(ByVal opcion As Integer, ByVal idmuestraB As Integer, ByVal marcaB As String, ByVal Fechab As Date, EstatusB As String, ProveedorB As String, Dsctob As Integer, PlazoB As Integer, RemisionB As Integer, IdUsuarioB As Integer, IdUsuarioCancelaB As Integer, IdUsuarioAutorizaB As Integer) As Boolean
        'mreyes 06/Septiembre/2017  10:12 a.m.
        Try

            MyBase.SQL = "usp_Captura_Muestras"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@idmuestrab", SqlDbType.Int, 10, idmuestraB)
            MyBase.AddParameter("@marcaB", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@fechab", SqlDbType.Date, 8, Fechab)
            MyBase.AddParameter("@estatusb", SqlDbType.VarChar, 2, EstatusB)
            MyBase.AddParameter("@proveedorb", SqlDbType.VarChar, 3, ProveedorB)
            MyBase.AddParameter("@dsctob", SqlDbType.Int, 16, Dsctob)
            MyBase.AddParameter("@plazob", SqlDbType.Int, 16, PlazoB)
            MyBase.AddParameter("@remisionb", SqlDbType.Int, 16, RemisionB)
            MyBase.AddParameter("@idusuariob", SqlDbType.Int, 16, IdUsuarioB)
            MyBase.AddParameter("@idusuariocancelab", SqlDbType.Int, 16, IdUsuarioCancelaB)
            MyBase.AddParameter("@idusuarioautorizab", SqlDbType.Int, 16, IdUsuarioAutorizaB)



            usp_Captura_Muestras = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_NegBodega(ByVal Sucursal As String, ByVal Nota As String, ByVal Fecha As Date, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal IdUsuario As Integer, ByVal Vendedor As Integer) As Boolean
        'mreyes 29/Diciembre/2016   12:23 p.m.

        Try
            MyBase.SQL = "usp_Captura_NegBodega"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Nota", SqlDbType.VarChar, 6, Nota)
            MyBase.AddParameter("@Fecha", SqlDbType.Date, 8, Fecha)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@Medida", SqlDbType.VarChar, 3, Medida)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)
            MyBase.AddParameter("@Vendedor", SqlDbType.Int, 8, Vendedor)





            usp_Captura_NegBodega = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_TmpMuestrasDet(Opcion As Integer, ByVal Marca As String, ByVal Estilof As String, IdUsuario As Integer) As Boolean
        'mreyes 22/Septiembre/2017  05:19 p.m.

        Try
            MyBase.SQL = "usp_Captura_TmpMuestrasDet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilof", SqlDbType.VarChar, 14, Estilof)
            MyBase.AddParameter("@IdUsuario", SqlDbType.Int, 16, IdUsuario)

            usp_Captura_TmpMuestrasDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CancelaMuestrasdet(Opcion As Integer, ByVal Marca As String, ByVal Estilof As String, Observaciones As String, IdUsuario As Integer) As Boolean
        'mreyes 10/Octubre/2017 10:33 a.m.

        Try
            MyBase.SQL = "usp_CancelaMuestrasdet"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilof", SqlDbType.VarChar, 14, Estilof)
            MyBase.AddParameter("@Observaciones", SqlDbType.VarChar, 250, Observaciones)
            MyBase.AddParameter("@IdUsuariocancela", SqlDbType.Int, 16, IdUsuario)

            usp_CancelaMuestrasdet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_MatchPropuestaTraspaso() As Boolean

        'mreyes 02/Noviembre/2016

        Try


            MyBase.SQL = "usp_MatchPropuestaTraspaso"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection



            'Execute the stored procedure
            usp_MatchPropuestaTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraPeticionTraspaso(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer, ByVal idusuario As Integer) As Boolean

        'mreyes 29/Julio/201612:06 p.m.

        Try


            MyBase.SQL = "usp_GeneraPeticionTraspaso"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@iddivisiones", SqlDbType.Int, 6, iddivisiones)
            MyBase.AddParameter("@iddepto", SqlDbType.Int, 6, iddepto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 6, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)


            'Execute the stored procedure
            usp_GeneraPeticionTraspaso = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    ' INICIA LIQUIDACIÓN AUTOMÁTICA. 

    Public Function usp_PpalLiqAutomatica(ByVal Marca As String, ByVal Division As String, ByVal Depto As String, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer) As DataSet
        'mreyes 06/Julio/2016   01:30 p.m.
        Try


            usp_PpalLiqAutomatica = New DataSet
            MyBase.SQL = "usp_PpalLiqAutomatica"


            MyBase.InitializeCommand()
            ' MyBase.AddParameter("@OpcionB", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@division", SqlDbType.VarChar, 60, Division)
            MyBase.AddParameter("@depto", SqlDbType.VarChar, 60, Depto)
            MyBase.AddParameter("@idfamilia", SqlDbType.VarChar, 60, idfamilia)
            MyBase.AddParameter("@idlinea", SqlDbType.VarChar, 6, idlinea)
            MyBase.AddParameter("@idl1", SqlDbType.VarChar, 60, idl1)
            MyBase.AddParameter("@idl2", SqlDbType.VarChar, 60, idl2)
            MyBase.AddParameter("@idl3", SqlDbType.VarChar, 60, idl3)
            MyBase.AddParameter("@idl4", SqlDbType.VarChar, 60, idl4)
            MyBase.AddParameter("@idl5", SqlDbType.VarChar, 60, idl5)
            MyBase.AddParameter("@idl6", SqlDbType.VarChar, 60, idl6)
            MyBase.AddParameter("@idagrupacion", SqlDbType.Int, 6, idagrupacion)


            MyBase.FillDataSet(usp_PpalLiqAutomatica, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function


    Public Function usp_PpalLiqAutomaticaTdas(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Fecha As Date) As DataSet
        'mreyes 23/Septiembre/2016   10:53 a.m.
        Try


            usp_PpalLiqAutomaticaTdas = New DataSet
            MyBase.SQL = "usp_PpalLiqAutomaticaTdas"
            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 8, Opcion)
            MyBase.AddParameter("@sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@fecha", SqlDbType.Date, 10, Fecha)

            MyBase.FillDataSet(usp_PpalLiqAutomaticaTdas, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try




    End Function

    Public Function usp_GeneraLiquidacion(ByVal FechIni As Date, ByVal FechFin As Date, ByVal idusuario As Integer, ByVal Usuario As String) As Boolean

        'mreyes 10/Septiembre/2016  12:45 p.m.

        Try


            MyBase.SQL = "usp_GeneraLiquidacion"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@fechini", SqlDbType.Date, 10, FechIni)
            MyBase.AddParameter("@fechfin", SqlDbType.Date, 10, FechFin)
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)
            MyBase.AddParameter("@usuario", SqlDbType.VarChar, 10, Usuario)


            'Execute the stored procedure
            usp_GeneraLiquidacion = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraLiqAutomatica(ByVal idusuario As Integer) As Boolean

        'mreyes 19/Septiembre/2016  04:16 p.m.

        Try


            MyBase.SQL = "usp_GeneraLiqAutomatica"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
 
            MyBase.AddParameter("@idusuario", SqlDbType.Int, 6, idusuario)



            'Execute the stored procedure
            usp_GeneraLiqAutomatica = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Elimina_LiqAutomatica(ByVal Marca As String, ByVal Estilon As String) As Boolean

        'mreyes 12/Septiembre/2016  10:23 a.m.

        Try


            MyBase.SQL = "usp_Elimina_LiqAutomatica"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection

            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)


            'Execute the stored procedure
            usp_Elimina_LiqAutomatica = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Elimina_ProTraspDetNoAplica(ByVal Serie As String) As Boolean

        'mreyes 25/Octubre/2016 04:14 p.m.

        Try


            MyBase.SQL = "usp_Elimina_ProTraspDetNoAplica"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection

            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, serie)


            'Execute the stored procedure
            usp_Elimina_ProTraspDetNoAplica = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_LiqAutomatica(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Regaladn As Integer, ByVal Porc As Integer, ByVal Contado As Integer, ByVal Credito As Integer, ByVal Tipo As String) As Boolean

        'mreyes 12/Septiembre/2016  10:38 a.m.

        Try


            MyBase.SQL = "usp_Captura_LiqAutomatica"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@Opcion", SqlDbType.Int, 6, Opcion)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Estilon", SqlDbType.VarChar, 7, Estilon)
            MyBase.AddParameter("@regaladn", SqlDbType.Int, 6, Regaladn)
            MyBase.AddParameter("@porc", SqlDbType.Int, 6, Porc)
            MyBase.AddParameter("@contado", SqlDbType.Int, 6, Contado)
            MyBase.AddParameter("@credito", SqlDbType.Int, 6, Credito)
            MyBase.AddParameter("@Tipo", SqlDbType.VarChar, 10, tipo)


            'Execute the stored procedure
            usp_Captura_LiqAutomatica = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalTraspasosRecyEnv(ByVal fechaini As String, ByVal fechafin As String) As DataSet
        'Manuel Vazquez, Paola Gonzalez 01:12 a.m. 
        Try
            usp_PpalTraspasosRecyEnv = New DataSet
            MyBase.SQL = "usp_PpalTraspasosRecyEnv"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", SqlDbType.Char, 10, fechaini)
            MyBase.AddParameter("@FechaFin", SqlDbType.Char, 10, fechafin)


            MyBase.FillDataSet(usp_PpalTraspasosRecyEnv, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalParesUnicos(ByVal fechaini1 As String, ByVal fechafin1 As String, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        'mreyes 14/Mayo/2018    01:31 p.m.
        Try
            usp_PpalParesUnicos = New DataSet
            MyBase.SQL = "usp_PpalParesUnicos"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni1", SqlDbType.Char, 10, fechaini1)
            MyBase.AddParameter("@FechaFin1", SqlDbType.Char, 10, fechafin1)
            MyBase.AddParameter("@FechaIni", SqlDbType.Char, 10, fechaini)
            MyBase.AddParameter("@FechaFin", SqlDbType.Char, 10, fechafin)


            MyBase.FillDataSet(usp_PpalParesUnicos, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoProveeBita(ByVal opcion As Integer, ByVal proveedorB As String, ByVal marcaB As String, fechaB As Date, ByVal comentarioB As String, ByVal idusuario As Integer) As DataSet
        'mreyes 11/Junio/2012 01;27 p.m.
        Try
            usp_PpalCatalogoProveeBita = New DataSet
            MyBase.SQL = "usp_PpalCatalogoProveeBita"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@accion", SqlDbType.Int, 2, opcion)
            MyBase.AddParameter("@proveedorB", SqlDbType.VarChar, 3, proveedorB)
            MyBase.AddParameter("@marcaB", SqlDbType.VarChar, 3, marcaB)
            MyBase.AddParameter("@fechaB", SqlDbType.Date, 15, fechaB)
            MyBase.AddParameter("@comentarioB", SqlDbType.VarChar, 1000, comentarioB)
            MyBase.AddParameter("@idusuarioB", SqlDbType.Int, 10, idusuario)


            MyBase.FillDataSet(usp_PpalCatalogoProveeBita, "SirCoAPP")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalDet_Serie(Serie As String) As DataSet
        'mreyes 09/Febrero/2018    10:20 a.m.
        Try
            usp_PpalDet_Serie = New DataSet
            MyBase.SQL = "usp_PpalDet_Serie"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Serie", SqlDbType.VarChar, 13, Serie)



            MyBase.FillDataSet(usp_PpalDet_Serie, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalLineaL1Existencia(Sucursal As String, Division As String, Linea As String, L1 As String, L2 As String,
                                              L3 As String, L4 As String, L5 As String, L6 As String, Marca As String, Modelo As String, ExiIni As Integer, ExiFin As Integer, FechaIni As Date, FechaFin As Date) As DataSet
        'mreyes 13/Febrero/2019 10:50 a.m.
        Try
            usp_PpalLineaL1Existencia = New DataSet
            MyBase.SQL = "usp_PpalLineaL1Existencia"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sucursal", SqlDbType.VarChar, 2, Sucursal)
            MyBase.AddParameter("@Division", SqlDbType.VarChar, 50, Division)
            MyBase.AddParameter("@Linea", SqlDbType.VarChar, 50, Linea)
            MyBase.AddParameter("@L1", SqlDbType.VarChar, 50, L1)
            MyBase.AddParameter("@L2", SqlDbType.VarChar, 50, L2)
            MyBase.AddParameter("@L3", SqlDbType.VarChar, 50, L3)
            MyBase.AddParameter("@L4", SqlDbType.VarChar, 50, L4)
            MyBase.AddParameter("@L5", SqlDbType.VarChar, 50, L5)
            MyBase.AddParameter("@L6", SqlDbType.VarChar, 50, L6)
            MyBase.AddParameter("@Marca", SqlDbType.VarChar, 3, Marca)
            MyBase.AddParameter("@Modelo", SqlDbType.VarChar, 7, Modelo)
            MyBase.AddParameter("@ExiIni", SqlDbType.Int, 8, ExiIni)
            MyBase.AddParameter("@ExiFin", SqlDbType.Int, 8, ExiIni)


            MyBase.AddParameter("@FecRecIni", SqlDbType.Date, 10, FechaIni)
            MyBase.AddParameter("@FecRecFin", SqlDbType.Date, 10, FechaFin)



            MyBase.FillDataSet(usp_PpalLineaL1Existencia, "SirCo")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
