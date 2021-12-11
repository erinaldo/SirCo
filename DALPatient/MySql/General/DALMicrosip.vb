Imports System.Data.Odbc
'mreyes 05/Marzo/2012 09:52 a.m.

Public Class DALMicrosip
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


    Public Function usp_Inserta_Estados(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 02/Marzo/2012 11:22 a.m.
            MyBase.SQL = "execute procedure ALTA_ESTADOS(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@estado_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("estado_id"))
            MyBase.AddParameter("@nombre", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@nombre_abrev", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("nombre_abrev"))
            MyBase.AddParameter("@es_predet", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("es_predet"))
            MyBase.AddParameter("@pais_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("pais_id"))
            MyBase.AddParameter("@usuario_creador", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_creador"))



            usp_Inserta_Estados = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    ''GEN_CATALOGO_ID

    Public Function usp_Inserta_Ciudades(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 05/Marzo/2012 06:38 p.m.
            MyBase.SQL = "execute procedure ALTA_CIUDADES(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@ciudad_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("ciudad_id"))
            MyBase.AddParameter("@nombre", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@es_predet", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("es_predet"))
            MyBase.AddParameter("@estado_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("estado_id"))
            MyBase.AddParameter("@usuario_creador", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_creador"))



            usp_Inserta_Ciudades = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Claves_Proveedores(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 05/Marzo/2012 07:31 p.m.
            MyBase.SQL = "execute procedure ALTA_CLAVES_PROVEEDORES(?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@clave_prov_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("clave_prov_id"))
            MyBase.AddParameter("@clave_prov", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("clave_prov"))
            MyBase.AddParameter("@proveedor_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("proveedor_id"))
            MyBase.AddParameter("@rol_clave_prov_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("rol_clave_prov_id"))


            usp_Inserta_Claves_Proveedores = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Gen_Catalogo_Id() As DataSet
        'mreyes 05/Marzo/2012 11:29 p.m.
        Try
            usp_Gen_Catalogo_Id = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE GEN_CATALOGO_ID"

            MyBase.InitializeCommand()
            ' MyBase.AddParameter("@catalogo_id", OdbcType.Int, 16, catalogo_id)
            MyBase.FillDataSet(usp_Gen_Catalogo_Id, "MICROSIP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Gen_Docto_Id() As DataSet
        'mreyes 16/Marzo/2012 10:58 p.m.
        Try
            usp_Gen_Docto_Id = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE GEN_DOCTO_ID"

            MyBase.InitializeCommand()
            ' MyBase.AddParameter("@catalogo_id", OdbcType.Int, 16, catalogo_id)
            MyBase.FillDataSet(usp_Gen_Docto_Id, "MICROSIP")

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Estado(ByVal Nombre As String, ByVal Nombre_Abrev As String) As DataSet
        'mreyes 05/Marzo/2012 11:29 p.m.
        Try
            usp_Traer_Estado = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE Traer_Estado(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@nombre", OdbcType.Char, 50, Nombre)
            MyBase.AddParameter("@nombre_ABREV", OdbcType.Char, 10, Nombre_aBREV)
            MyBase.FillDataSet(usp_Traer_Estado, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Traer_Condicion_Pago_CP(ByVal Porc As Decimal, ByVal Dias As Integer) As DataSet
        'mreyes 06/Marzo/2012 04:26 p.m.
        Try
            usp_Traer_Condicion_Pago_CP = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE Traer_Condicion_Pago_CP(?,?)"
            MyBase.SQL = "SELECT * FROM Traer_Condicion_Pago_CP(?,?)"
            '"SELECT * FROM Traer_Empleado"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@porc", OdbcType.Numeric, 9, Porc)
            MyBase.AddParameter("@dias", OdbcType.SmallInt, 3, Dias)
            MyBase.FillDataSet(usp_Traer_Condicion_Pago_CP, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Ciudad(ByVal Nombre As String) As DataSet
        'mreyes 05/Marzo/2012 06:32 p.m.
        Try
            usp_Traer_Ciudad = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE Traer_Ciudad(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@nombre", OdbcType.Char, 50, Nombre)
            MyBase.FillDataSet(usp_Traer_Ciudad, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Traer_Proveedor(ByVal Proveedor_Id As Integer, ByVal Nombre As String) As DataSet
        'mreyes 06/Marzo/2012 01:47 p.m.
        Try
            usp_Traer_Proveedor = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE Traer_Proveedor(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedor_id", OdbcType.Int, 16, Proveedor_Id)
            MyBase.AddParameter("@nombre", OdbcType.Char, 100, Nombre)
            MyBase.FillDataSet(usp_Traer_Proveedor, "MICROSIP")

            'usp_Traer_Plazos_Cond_Pag_Cp

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Empleado() As DataSet
        'mreyes 21/Junio/2012 11:08 a.m.
        Try
            usp_Traer_Empleado = New DataSet
            MyBase.SQL = "SELECT * FROM Traer_Empleado"

            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_Traer_Empleado, "MICROSIP")

            'usp_Traer_Plazos_Cond_Pag_Cp

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Plazos_Cond_Pag_Cp(ByVal cond_pago_id As Integer) As DataSet
        'mreyes 25/Mayo/2012 10:56 a.m.
        Try
            usp_Traer_Plazos_Cond_Pag_Cp = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE usp_Traer_Plazos_Cond_Pag_Cp(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@cond_pago_id", OdbcType.Int, 16, cond_pago_id)

            MyBase.FillDataSet(usp_Traer_Plazos_Cond_Pag_Cp, "MICROSIP")

            '

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Doctos_CP(ByVal Concepto_CP_ID As Integer, ByVal Proveedor_Id As Integer, ByVal Folio As String, ByVal Fecha As Date, ByVal Clave_Prov As String) As DataSet
        'mreyes 17/Marzo/2012 11:08 a.m.
        Try
            usp_Traer_Doctos_CP = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE Traer_Doctos_CP(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@concepto_cp_idB", OdbcType.Int, 16, Concepto_CP_ID)
            MyBase.AddParameter("@proveedor_id", OdbcType.Int, 16, Proveedor_Id)
            MyBase.AddParameter("@folio", OdbcType.Char, 9, Folio)
            MyBase.AddParameter("@Fecha", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@Clave_Prov", OdbcType.Char, 30, Clave_Prov)

            MyBase.FillDataSet(usp_Traer_Doctos_CP, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Fact_Pend(ByVal V_PROVEEDOR_ID As Integer, ByVal V_FECHA_CORTE1 As Date, ByVal V_FECHA_CORTE2 As Date, ByVal V_FECHA_SALDOS As Date, ByVal V_INCL_SALDADOS As String, ByVal V_FECHA_VENCIMIENTO1 As Date, ByVal V_FECHA_VENCIMIENTO2 As Date, ByVal V_FOLIO1 As String, ByVal V_FOLIO2 As String, ByVal V_PROVEEDOR As Integer) As DataSet
        'mreyes 25/Abril/2012 06:35 p.m.
        Try
            usp_Fact_Pend = New DataSet
            ''MyBase.SQL = "EXECUTE PROCEDURE Fact_Pend(?,?,?,?)"
            MyBase.SQL = " SELECT * FROM FACT_PEND(?,?,?,?,?,?,?,?,?,?)"
            'MyBase.SQL = " SELECT * FROM FACT_PAGADAS(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@V_PROVEEDOR_ID", OdbcType.Int, 16, V_PROVEEDOR_ID)
            MyBase.AddParameter("@V_FECHA_CORTE1", OdbcType.Date, 8, V_FECHA_CORTE1)
            MyBase.AddParameter("@V_FECHA_CORTE2", OdbcType.Date, 8, V_FECHA_CORTE2)
            MyBase.AddParameter("@V_FECHA_SALDOS", OdbcType.Date, 8, V_FECHA_SALDOS)
            MyBase.AddParameter("@V_INCL_SALDADOS", OdbcType.Char, 1, V_INCL_SALDADOS)
            MyBase.AddParameter("@V_FECHA_VENCIMIENTO1", OdbcType.Date, 8, V_FECHA_VENCIMIENTO1)
            MyBase.AddParameter("@V_FECHA_VENCIMIENTO2", OdbcType.Date, 8, V_FECHA_VENCIMIENTO2)
            MyBase.AddParameter("@V_FOLIO1", OdbcType.Char, 10, V_FOLIO1)
            MyBase.AddParameter("@V_FOLIO2", OdbcType.Char, 10, V_FOLIO2)
            MyBase.AddParameter("@V_PROVEEDOR", OdbcType.Int, 16, V_PROVEEDOR)


            MyBase.FillDataSet(usp_Fact_Pend, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Fact_Pagadas(ByVal V_PROVEEDOR_ID As Integer, ByVal V_FECHA_CORTE1 As Date, ByVal V_FECHA_CORTE2 As Date, ByVal V_FECHA_SALDOS As Date, ByVal V_INCL_SALDADOS As String, ByVal V_FECHA_VENCIMIENTO1 As Date, ByVal V_FECHA_VENCIMIENTO2 As Date, ByVal V_FOLIO1 As String, ByVal V_FOLIO2 As String, ByVal V_PROVEEDOR As Integer) As DataSet
        'mreyes 25/Abril/2012 06:35 p.m.
        Try
            usp_Fact_Pagadas = New DataSet
            ''MyBase.SQL = "EXECUTE PROCEDURE Fact_Pend(?,?,?,?)"
            'MyBase.SQL = " SELECT * FROM FACT_PEND(?,?,?,?,?,?,?,?,?,?)"
            MyBase.SQL = " SELECT * FROM FACT_PAGADAS(?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@V_PROVEEDOR_ID", OdbcType.Int, 16, V_PROVEEDOR_ID)
            MyBase.AddParameter("@V_FECHA_CORTE1", OdbcType.Date, 8, V_FECHA_CORTE1)
            MyBase.AddParameter("@V_FECHA_CORTE2", OdbcType.Date, 8, V_FECHA_CORTE2)
            MyBase.AddParameter("@V_FECHA_SALDOS", OdbcType.Date, 8, V_FECHA_SALDOS)
            MyBase.AddParameter("@V_INCL_SALDADOS", OdbcType.Char, 1, V_INCL_SALDADOS)
            MyBase.AddParameter("@V_FECHA_VENCIMIENTO1", OdbcType.Date, 8, V_FECHA_VENCIMIENTO1)
            MyBase.AddParameter("@V_FECHA_VENCIMIENTO2", OdbcType.Date, 8, V_FECHA_VENCIMIENTO2)
            MyBase.AddParameter("@V_FOLIO1", OdbcType.Char, 10, V_FOLIO1)
            MyBase.AddParameter("@V_FOLIO2", OdbcType.Char, 10, V_FOLIO2)
            MyBase.AddParameter("@V_PROVEEDOR", OdbcType.Int, 16, V_PROVEEDOR)


            MyBase.FillDataSet(usp_Fact_Pagadas, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Libres_Proveedor(ByVal Proveedor_Id As Integer) As DataSet
        'mreyes 14/Marzo/2012 05:21 p.m.
        Try
            usp_Traer_Libres_Proveedor = New DataSet
            MyBase.SQL = "EXECUTE PROCEDURE Traer_Libres_Proveedor(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor_Id", OdbcType.Int, 16, Proveedor_Id)
            MyBase.FillDataSet(usp_Traer_Libres_Proveedor, "MICROSIP")



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Inserta_Proveedores(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 02/Marzo/2012 01:36 p.m.
            MyBase.SQL = "execute procedure ALTA_PROVEEDORES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@proveedor_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("proveedor_id"))
            MyBase.AddParameter("@nombre", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@contacto1", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("contacto1"))
            MyBase.AddParameter("@contacto2", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("contacto2"))
            MyBase.AddParameter("@calle", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@nombrE_calle", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("nombrE_calle"))
            MyBase.AddParameter("@num_exterior", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("num_exterior"))
            MyBase.AddParameter("@num_interior", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("num_interior"))
            MyBase.AddParameter("@colonia", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@referencia", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("referencia"))
            MyBase.AddParameter("@ciudad_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("ciudad_id"))
            MyBase.AddParameter("@estado_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("estado_id"))
            MyBase.AddParameter("@codigo_postal", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("codigo_postal"))
            MyBase.AddParameter("@pais_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("pais_id"))
            MyBase.AddParameter("@telefono1", OdbcType.Char, 35, Section.Tables(0).Rows(0).Item("telefono1"))
            MyBase.AddParameter("@telefono2", OdbcType.Char, 35, Section.Tables(0).Rows(0).Item("telefono2"))
            MyBase.AddParameter("@fax", OdbcType.Char, 35, Section.Tables(0).Rows(0).Item("fax"))
            MyBase.AddParameter("@email", OdbcType.Char, 35, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@rfc_curp", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("rfc_curp"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@causa_susp", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("causa_susp"))
            MyBase.AddParameter("@carga_impuestos", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("carga_impuestos"))
            MyBase.AddParameter("@retener_impuestos", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("retener_impuestos"))
            MyBase.AddParameter("@extranjero", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("extranjero"))
            MyBase.AddParameter("@limite_credito", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("limite_credito"))
            MyBase.AddParameter("@moneda_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("moneda_id"))
            MyBase.AddParameter("@cond_pago_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("cond_pago_id"))
            MyBase.AddParameter("@notas", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("notas"))
            MyBase.AddParameter("@cuenta_cxp", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("cuenta_cxp"))
            MyBase.AddParameter("@formatos_email", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("formatos_email"))
            MyBase.AddParameter("@actividad_principal", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("actividad_principal"))
            MyBase.AddParameter("@usuario_creador", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_creador"))

            usp_Inserta_Proveedores = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Inserta_Empleados(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 31/Mayo/2012 05:23 p.m.
            MyBase.SQL = "execute procedure ALTA_EMPLEADOS(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@numero", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("numero"))
            MyBase.AddParameter("@nombre_completo", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("nombre_completo"))
            MyBase.AddParameter("@apellido_paterno", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("apellido_paterno"))
            MyBase.AddParameter("@apellido_materno", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("apellido_materno"))
            MyBase.AddParameter("@nombres", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("nombres"))
            MyBase.AddParameter("@puesto_no_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("puesto_no_id"))
            MyBase.AddParameter("@depto_no_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("depto_no_id"))
            MyBase.AddParameter("@frepag_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("frepag_id"))
            MyBase.AddParameter("@forma_pago", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("forma_pago"))
            MyBase.AddParameter("@contrato", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("contrato"))
            MyBase.AddParameter("@dias_hrs_jsr", OdbcType.Decimal, 15, Section.Tables(0).Rows(0).Item("dias_hrs_jsr"))
            MyBase.AddParameter("@horario", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("horario"))
            MyBase.AddParameter("@turno", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("turno"))
            MyBase.AddParameter("@jornada", OdbcType.Decimal, 15, Section.Tables(0).Rows(0).Item("jornada"))
            MyBase.AddParameter("@fecha_ingreso", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha_ingreso"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@zona_salmin", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("zona_salmin"))
            MyBase.AddParameter("@tabla_antig_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("tabla_antig_id"))
            MyBase.AddParameter("@tipo_salario", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipo_salario"))
            MyBase.AddParameter("@pctje_integ", OdbcType.Decimal, 15, Section.Tables(0).Rows(0).Item("pctje_integ"))
            MyBase.AddParameter("@salario_diario", OdbcType.Decimal, 15, Section.Tables(0).Rows(0).Item("salario_diario"))
            MyBase.AddParameter("@salario_hora", OdbcType.Decimal, 15, Section.Tables(0).Rows(0).Item("salario_hora"))
            MyBase.AddParameter("@salario_integ", OdbcType.Decimal, 15, Section.Tables(0).Rows(0).Item("salario_integ"))
            MyBase.AddParameter("@ptu", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("ptu"))
            MyBase.AddParameter("@imss", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("imss"))
            MyBase.AddParameter("@cas", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("cas"))
            MyBase.AddParameter("@infonavit", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("infonavit"))
            MyBase.AddParameter("@pensionado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("pensionado"))
            MyBase.AddParameter("@deshab_imptos", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("deshab_imptos"))
            MyBase.AddParameter("@calc_isr_anual", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("calc_isr_anual"))
            MyBase.AddParameter("@calle", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@nombre_calle", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("nombre_calle"))
            MyBase.AddParameter("@num_exterior", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("num_exterior"))
            MyBase.AddParameter("@num_interior", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("num_interior"))
            MyBase.AddParameter("@colonia", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@referencia", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("referencia"))
            MyBase.AddParameter("@ciudad_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("ciudad_id"))
            MyBase.AddParameter("@codigo_postal", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("codigo_postal"))
            MyBase.AddParameter("@telefono1", OdbcType.Char, 35, Section.Tables(0).Rows(0).Item("telefono1"))
            MyBase.AddParameter("@telefono2", OdbcType.Char, 35, Section.Tables(0).Rows(0).Item("telefono2"))
            MyBase.AddParameter("@email", OdbcType.Char, 200, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@sexo", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("sexo"))
            MyBase.AddParameter("@fecha_nacimiento", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha_nacimiento"))
            MyBase.AddParameter("@ciudad_nacimiento_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("ciudad_nacimiento_id"))
            MyBase.AddParameter("@estado_civil", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estado_civil"))
            MyBase.AddParameter("@num_hijos", OdbcType.SmallInt, 8, Section.Tables(0).Rows(0).Item("num_hijos"))
            MyBase.AddParameter("@nombre_padre", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("nombre_padre"))
            MyBase.AddParameter("@nombre_madre", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("nombre_madre"))
            MyBase.AddParameter("@rfc", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@curp", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("curp"))
            MyBase.AddParameter("@reg_imss", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("reg_imss"))
            MyBase.AddParameter("@otro_reg", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("otro_reg"))
            MyBase.AddParameter("@unidad_medica", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("unidad_medica"))
            MyBase.AddParameter("@grupo_pago_elect_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("grupo_pago_elect_id"))
            MyBase.AddParameter("@tipo_ctaban_pago_elect", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipo_ctaban_pago_elect"))
            MyBase.AddParameter("@num_ctaban_pago_elect", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("num_ctaban_pago_elect"))
            MyBase.AddParameter("@usuario_creador", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_creador"))
            MyBase.AddParameter("@fecha_hora_creacion", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fecha_hora_creacion"))
            MyBase.AddParameter("@usuario_aut_creacion", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_aut_creacion"))
            MyBase.AddParameter("@usuario_ult_modif", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_ult_modif"))
            MyBase.AddParameter("@fecha_hora_ult_modif", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fecha_hora_ult_modif"))
            MyBase.AddParameter("@usuario_aut_modif", OdbcType.Char, 31, Section.Tables(0).Rows(0).Item("usuario_aut_modif"))

            usp_Inserta_Empleados = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Inserta_Doctos_CP(ByVal Opcion As Integer, ByVal idfoliob As String, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 16/Marzo/2012 11:13 p.m.
            MyBase.SQL = "execute procedure ALTA_DOCTOS_CP(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            'MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@docto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("docto_cp_id"))
            MyBase.AddParameter("@concepto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("concepto_cp_id"))
            MyBase.AddParameter("@folio", OdbcType.Char, 9, Section.Tables(0).Rows(0).Item("folio"))
            MyBase.AddParameter("@naturaleza_concepto", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("naturaleza_concepto"))
            MyBase.AddParameter("@fecha", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@clave_prov", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("clave_prov"))
            MyBase.AddParameter("@proveedor_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("proveedor_id"))
            MyBase.AddParameter("@tipo_cambio", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("tipo_cambio"))
            MyBase.AddParameter("@cancelado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("cancelado"))
            MyBase.AddParameter("@aplicado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("aplicado"))
            MyBase.AddParameter("@descripcion", OdbcType.Char, 200, Section.Tables(0).Rows(0).Item("descripcion"))
            MyBase.AddParameter("@forma_emitida", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("forma_emitida"))
            MyBase.AddParameter("@contabilizado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("contabilizado"))
            MyBase.AddParameter("@contabilizado_gyp", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("contabilizado_gyp"))
            MyBase.AddParameter("@cond_pago_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("cond_pago_id"))
            MyBase.AddParameter("@fecha_dscto_ppag", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha_dscto_ppag"))
            MyBase.AddParameter("@pctje_dscto_ppag", OdbcType.Numeric, 15, Section.Tables(0).Rows(0).Item("pctje_dscto_ppag"))
            MyBase.AddParameter("@exportado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("exportado"))
            MyBase.AddParameter("@sistema_origen", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sistema_origen"))
            MyBase.AddParameter("@integ_ba", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("integ_ba"))
            MyBase.AddParameter("@contabilizado_ba", OdbcType.VarChar, 1, Section.Tables(0).Rows(0).Item("contabilizado_ba"))
            MyBase.AddParameter("@usuario_creador", OdbcType.VarChar, 31, Section.Tables(0).Rows(0).Item("usuario_creador"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idfoliob", OdbcType.VarChar, 8, idfoliob)

            usp_Inserta_Doctos_CP = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Inserta_Importes_Doctos_CP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 16/Marzo/2012 11:29 p.m.
            MyBase.SQL = "execute procedure ALTA_IMPORTES_DOCTOS_CP(?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            'MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@impte_docto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("impte_docto_cp_id"))
            MyBase.AddParameter("@docto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("docto_cp_id"))
            MyBase.AddParameter("@cancelado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("cancelado"))
            MyBase.AddParameter("@aplicado", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("aplicado"))
            MyBase.AddParameter("@tipo_impte", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipo_impte"))
            MyBase.AddParameter("@docto_cp_acr_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("docto_cp_acr_id"))
            MyBase.AddParameter("@importe", OdbcType.Double, 15, Section.Tables(0).Rows(0).Item("importe"))
            MyBase.AddParameter("@impuesto", OdbcType.Double, 15, Section.Tables(0).Rows(0).Item("impuesto"))
            MyBase.AddParameter("@iva_retenido", OdbcType.Numeric, 9, Section.Tables(0).Rows(0).Item("iva_retenido"))
            MyBase.AddParameter("@isr_retenido", OdbcType.Numeric, 9, Section.Tables(0).Rows(0).Item("isr_retenido"))
            MyBase.AddParameter("@dscto_ppag", OdbcType.Numeric, 9, Section.Tables(0).Rows(0).Item("dscto_ppag"))

            usp_Inserta_Importes_Doctos_CP = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Inserta_Importes_Doctos_CP_IMPTOS(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 20/Marzo/2012 05:16 p.m.
            MyBase.SQL = "execute procedure ALTA_IMPORTES_DOCTOS_CP_IMPTOS(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            'MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@impte_docto_cp_impto_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("impte_docto_cp_impto_id"))
            MyBase.AddParameter("@impte_docto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("impte_docto_cp_id"))
            MyBase.AddParameter("@imIdPuesto", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("imIdPuesto"))
            MyBase.AddParameter("@importe", OdbcType.Numeric, 9, Section.Tables(0).Rows(0).Item("importe"))
            MyBase.AddParameter("@pctje_impuesto", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("pctje_impuesto"))
            MyBase.AddParameter("@impuesto", OdbcType.Numeric, 9, Section.Tables(0).Rows(0).Item("impuesto"))
               usp_Inserta_Importes_Doctos_CP_IMPTOS = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Libres_Cargos_CP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 20/Marzo/2012 04:56 p.m.
            MyBase.SQL = "execute procedure ALTA_LIBRES_CARGOS_CP(?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            'MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)

            MyBase.AddParameter("@docto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("docto_cp_id"))
            
            usp_Inserta_Libres_Cargos_CP = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Vencimientos_Cargos_CP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 20/Marzo/2012 04:56 p.m.
            MyBase.SQL = "execute procedure ALTA_VENCIMIENTOS_CARGOS_CP(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            'MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)

            MyBase.AddParameter("@docto_cp_id", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("docto_cp_id"))
            MyBase.AddParameter("@fecha_vencimiento", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha_vencimiento"))
            MyBase.AddParameter("@pctje_ven", OdbcType.Int, 32, Section.Tables(0).Rows(0).Item("pctje_ven"))

            usp_Inserta_Vencimientos_Cargos_CP = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Inserta_Libres_Proveedores(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'mreyes 02/Marzo/2012 01:36 p.m.
            MyBase.SQL = "execute procedure ALTA_LIBRES_PROVEEDOR(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@proveedor_id", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("proveedor_id"))
            MyBase.AddParameter("@Marca", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("marca"))
           

            usp_Inserta_Libres_Proveedores = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
