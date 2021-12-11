Imports System.Data.Odbc
Public Class DALCatalogoDistribuidor
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
    Public Function usp_Captura_Distribuidor(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_Distribuidor(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@iddistribB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("iddistrib"))
            MyBase.AddParameter("@nombreB", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@idpromotorB", OdbcType.Int, 4, Section.Tables(0).Rows(0).Item("idpromotor"))
            MyBase.AddParameter("@avalB", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("aval"))
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@comentarioB", OdbcType.Text, 999, Section.Tables(0).Rows(0).Item("comentario"))
            MyBase.AddParameter("@frecuenB", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("frecuen"))
            MyBase.AddParameter("@telef1B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef1"))
            MyBase.AddParameter("@telef2B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef2"))
            MyBase.AddParameter("@celularB", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("celular"))
            MyBase.AddParameter("@rfcB", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@curpB", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("curp"))
            MyBase.AddParameter("@nacionalidadB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("nacionalidad"))
            MyBase.AddParameter("@profesionB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("profesion"))
            MyBase.AddParameter("@edocivilB", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("edocivil"))
            MyBase.AddParameter("@sexoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("sexo"))
            MyBase.AddParameter("@emailB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@tiemporesB", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("tiempores"))
            MyBase.AddParameter("@nacimB", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("nacim"))
            MyBase.AddParameter("@ciudadnacB", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("ciudadnac"))
            MyBase.AddParameter("@calleB", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@numeroB", OdbcType.Char, 4, Section.Tables(0).Rows(0).Item("numero"))
            MyBase.AddParameter("@idcoloniaB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idcolonia"))
            MyBase.AddParameter("@idciudadB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idciudad"))
            MyBase.AddParameter("@idestadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idestado"))
            MyBase.AddParameter("@codposB", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("codpos"))
            MyBase.AddParameter("@entrecallesB", OdbcType.Char, 255, Section.Tables(0).Rows(0).Item("entrecalles"))
            MyBase.AddParameter("@viviendaB", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("vivienda"))
            MyBase.AddParameter("@domanteriorB", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("domanterior"))
            MyBase.AddParameter("@ingresomenB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("ingresomen"))
            MyBase.AddParameter("@ingresootroB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("ingresootro"))
            MyBase.AddParameter("@dependenB", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("dependen"))
            MyBase.AddParameter("@limcredB", OdbcType.Int, 9, Section.Tables(0).Rows(0).Item("limcred"))
            MyBase.AddParameter("@disponibleB", OdbcType.Char, 12, Section.Tables(0).Rows(0).Item("disponible"))
            MyBase.AddParameter("@limvaleB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("limvale"))
            MyBase.AddParameter("@dsctoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("dscto"))
            MyBase.AddParameter("@cobradorB", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("cobrador"))
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@saldoB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("saldo"))
            MyBase.AddParameter("@contravaleB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("contravale"))
            MyBase.AddParameter("@neexvaleB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("neexvale"))
            MyBase.AddParameter("@promocionB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("promocion"))
            MyBase.AddParameter("@empresaactB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("empresaact"))
            MyBase.AddParameter("@deptoB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("depto"))
            MyBase.AddParameter("@puestoB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("puesto"))
            MyBase.AddParameter("@antiguedadB", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("antiguedad"))
            MyBase.AddParameter("@calleempB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("calleemp"))
            MyBase.AddParameter("@numempB", OdbcType.Char, 4, Section.Tables(0).Rows(0).Item("numemp"))
            MyBase.AddParameter("@idcolempB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idcolemp"))
            MyBase.AddParameter("@codposempB", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("codposemp"))
            MyBase.AddParameter("@idcdempB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idcdemp"))
            MyBase.AddParameter("@idedoempB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idedoemp"))
            MyBase.AddParameter("@telempB", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telemp"))
            MyBase.AddParameter("@empantB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("empant"))
            MyBase.AddParameter("@dptoantB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("dptoant"))
            MyBase.AddParameter("@pstoantB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("pstoant"))
            MyBase.AddParameter("@nomconyB", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("nomcony"))
            MyBase.AddParameter("@emprconyB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("emprcony"))
            MyBase.AddParameter("@dptoconyB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("dptocony"))
            MyBase.AddParameter("@pstoconyB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("pstocony"))
            MyBase.AddParameter("@antigconyB", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("antigcony"))
            MyBase.AddParameter("@telconyB", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telcony"))
            MyBase.AddParameter("@ingrconyB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("ingcony"))
            MyBase.AddParameter("@otringconyB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("otringcony"))
            MyBase.AddParameter("@referencia1B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("referencia1"))
            MyBase.AddParameter("@telref1B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telref1"))
            MyBase.AddParameter("@direcref1B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("direcref1"))
            MyBase.AddParameter("@ocupacionref1B", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("ocupacionref1"))
            MyBase.AddParameter("@referencia2B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("referencia2"))
            MyBase.AddParameter("@telref2B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telref2"))
            MyBase.AddParameter("@direcref2B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("direcref2"))
            MyBase.AddParameter("@ocupacionref2B", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("ocupacionref2"))
            MyBase.AddParameter("@usuactivoB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuactivo"))
            MyBase.AddParameter("@fumactivoB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fumactivo"))
            MyBase.AddParameter("@usuinactivoB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuinactivo"))
            MyBase.AddParameter("@fuminactivoB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fuminactivo"))
            MyBase.AddParameter("@usubajaB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usubaja"))
            MyBase.AddParameter("@fumbajaB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fumbaja"))
            MyBase.AddParameter("@usususpendeB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usususpende"))
            MyBase.AddParameter("@fumsuspendeB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fumsuspende"))

            '
            MyBase.AddParameter("@twitterB", OdbcType.Char, 255, Section.Tables(0).Rows(0).Item("twitter"))
            MyBase.AddParameter("@facebookB", OdbcType.Char, 255, Section.Tables(0).Rows(0).Item("facebook"))

            usp_Captura_Distribuidor = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Copiar_Distribuidor(ByVal IdProspecto As Integer) As DataSet
        Try
            usp_Copiar_Distribuidor = New DataSet
            MyBase.SQL = "CALL usp_Copiar_Distribuidor(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdProspecto)

            MyBase.FillDataSet(usp_Copiar_Distribuidor, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Copiar_NE(ByVal IdProspecto As Integer) As DataSet
        Try
            usp_Copiar_NE = New DataSet
            MyBase.SQL = "CALL usp_Copiar_NE(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdProspecto)

            MyBase.FillDataSet(usp_Copiar_NE, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNegociosExternos(ByVal opcion As String, ByVal distrib As String) As DataSet

        Try
            usp_TraerNegociosExternos = New DataSet
            MyBase.SQL = "CALL usp_TraerNegEx(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, opcion)
            MyBase.AddParameter("@idB", OdbcType.Char, 6, distrib)

            MyBase.FillDataSet(usp_TraerNegociosExternos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoDistribuidor(ByVal distribA As String, ByVal distribB As String, ByVal estatus As String, ByVal promotorB As String) As DataSet
        'Ro
        Try
            usp_PpalCatalogoDistribuidor = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoDistribuidor(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@distribA", OdbcType.Char, 6, distribA)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, distribB)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, estatus)
            MyBase.AddParameter("@promotorB", OdbcType.Char, 6, promotorB)

            MyBase.FillDataSet(usp_PpalCatalogoDistribuidor, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribuidor(ByVal idDistrib As Integer) As DataSet
        Try
            usp_TraerDistribuidor = New DataSet
            MyBase.SQL = "CALL usp_TraerDistrib(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Int, 16, idDistrib)

            MyBase.FillDataSet(usp_TraerDistribuidor, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCobrador(ByVal Idempleadob As Integer, ByVal CobradorB As String, ByVal TipoB As String, ByVal StatusB As String) As DataSet
        'mreyes 30/Junio/2014   12:34 p.m   IdEmpleadoB int, CobradorB char(2), TipoB char (2), StatusB char(2)
        Try
            usp_TraerCobrador = New DataSet
            MyBase.SQL = "CALL usp_TraerCobrador(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdempleadoB", OdbcType.Int, 16, Idempleadob)
            MyBase.AddParameter("@cobradorb", OdbcType.Char, 2, CobradorB)
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, TipoB)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, StatusB)

            MyBase.FillDataSet(usp_TraerCobrador, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFumDistrib(ByVal distrib As Integer) As DataSet
        'Ro. 01/04/2013
        Try
            usp_TraerFumDistrib = New DataSet
            MyBase.SQL = "CALL usp_TraerFumDistrib(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@distribB", OdbcType.Int, 16, distrib)

            MyBase.FillDataSet(usp_TraerFumDistrib, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarEstatus(ByVal Opcion As String, ByVal idDistrib As Integer, ByVal Estatus As String) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatusDis(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Char, 3, Opcion)
            MyBase.AddParameter("@idprospectoB", OdbcType.Int, 16, idDistrib)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, Estatus)

            usp_ActualizarEstatus = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistribLow(ByVal idDistrib As String) As DataSet
        Try
            usp_TraerUnDistribLow = New DataSet
            MyBase.SQL = "CALL usp_TraerUnDistribLow(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Char, 6, idDistrib)

            MyBase.FillDataSet(usp_TraerUnDistribLow, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistrib(ByVal idDistrib As String) As DataSet
        Try
            usp_TraerUnDistrib = New DataSet
            MyBase.SQL = "CALL usp_TraerUnDistrib(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Char, 6, idDistrib)

            MyBase.FillDataSet(usp_TraerUnDistrib, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistribLikeLow(ByVal idDistrib As String) As DataSet
        Try
            usp_TraerUnDistribLikeLow = New DataSet
            MyBase.SQL = "CALL usp_TraerUnDistribLikeLow(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Char, 80, idDistrib)

            MyBase.FillDataSet(usp_TraerUnDistribLikeLow, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistribLike(ByVal idDistrib As String) As DataSet
        Try
            usp_TraerUnDistribLike = New DataSet
            MyBase.SQL = "CALL usp_TraerUnDistribLike(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Char, 80, idDistrib)

            MyBase.FillDataSet(usp_TraerUnDistribLike, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerUnEmpresaLike(ByVal idDistrib As String) As DataSet
        'juan 17/10/2013
        Try
            usp_TraerUnEmpresaLike = New DataSet
            MyBase.SQL = "CALL usp_TraerUnEmpresaLike(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Char, 80, idDistrib)

            MyBase.FillDataSet(usp_TraerUnEmpresaLike, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUnNegocio(ByVal negocio As String) As DataSet
        Try
            usp_TraerUnNegocio = New DataSet
            MyBase.SQL = "CALL usp_TraerUnNegEx(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@negocioB", OdbcType.Char, 80, negocio)

            MyBase.FillDataSet(usp_TraerUnNegocio, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    'Public Function usp_TraerFrecuencia2() As DataSet
    '    Try
    '        usp_TraerFrecuencia2 = New DataSet
    '        MyBase.SQL = "call usp_TraerFrecuencia2()"
    '        MyBase.InitializeCommand()

    '        'MyBase.AddParameter("@distribB", OdbcType.Char, 4, Frecuencia)
    '        MyBase.FillDataSet(usp_TraerFrecuencia2, "credito")

    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function
    Public Function usp_ImprimeDistribuidor(ByVal DistribA As String, ByVal DistribB As String, ByVal EstatusB As String, ByVal PromotorB As String) As DataSet

        Try

            usp_ImprimeDistribuidor = New DataSet
            MyBase.SQL = "CALL usp_ImprimeDistrib(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@prospectoA", OdbcType.Char, 6, DistribA)
            MyBase.AddParameter("@prospectoB", OdbcType.Char, 6, DistribB)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, EstatusB)
            MyBase.AddParameter("@promotorB", OdbcType.Char, 6, PromotorB)
            MyBase.FillDataSet(usp_ImprimeDistribuidor, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFrecuencia(ByVal frecuen As String) As DataSet
        '
        Try
            usp_TraerFrecuencia = New DataSet
            MyBase.SQL = "CALL usp_TraerFrecuencia2(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idcobradorB", OdbcType.Char, 2, frecuen)


            MyBase.FillDataSet(usp_TraerFrecuencia, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFrecuenciaLike(ByVal descrip As String) As DataSet
        '
        Try
            usp_TraerFrecuenciaLike = New DataSet
            MyBase.SQL = "CALL usp_TraerFrecuenciaLike(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idcobradorB", OdbcType.Char, 40, descrip)


            MyBase.FillDataSet(usp_TraerFrecuenciaLike, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDocFotos(ByVal ruta As String) As DataSet
        '
        Try
            usp_TraerDocFotos = New DataSet
            MyBase.SQL = "CALL usp_TraerFotoDocs(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@rutaB", OdbcType.Char, 60, ruta)


            MyBase.FillDataSet(usp_TraerDocFotos, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribuidorID(ByVal idDistrib As Integer) As DataSet
        'juan 8-mayo-2013 12:48
        Try
            usp_TraerDistribuidorID = New DataSet
            MyBase.SQL = "CALL usp_traerDistribuidorID(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@iddistribB", OdbcType.Int, 6, idDistrib)

            MyBase.FillDataSet(usp_TraerDistribuidorID, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoEmpresaDistribuidora(ByVal distribA As String, ByVal distribB As String, ByVal estatus As String, ByVal promotorB As String) As DataSet
        'Ro
        Try
            usp_PpalCatalogoEmpresaDistribuidora = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoEmpresaDistribuidora(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@distribA", OdbcType.Char, 6, distribA)
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, distribB)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, estatus)
            MyBase.AddParameter("@promotorB", OdbcType.Char, 6, promotorB)

            MyBase.FillDataSet(usp_PpalCatalogoEmpresaDistribuidora, "credito")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMovsDistrib(ByVal IdDistrib As Integer, ByVal Tipo As String, ByVal EstatusAnt As String, _
                                           ByVal EstatusNuevo As String, ByVal LimCredAnt As Double, ByVal LimCredNuevo As Double, _
                                           ByVal LimValeAnt As Double, ByVal LimValeNuevo As Double, ByVal Motivo As String, ByVal IdUsuario As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_CapturaMovsDistrib(?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdDistribB", OdbcType.Int, 8, IdDistrib)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 1, Tipo)
            MyBase.AddParameter("@StatusAntB", OdbcType.Char, 1, EstatusAnt)
            MyBase.AddParameter("@StatusNuevoB", OdbcType.Char, 1, EstatusNuevo)
            MyBase.AddParameter("@LimCredAntB", OdbcType.Double, 9, LimCredAnt)
            MyBase.AddParameter("@LimCredNuevoB", OdbcType.Double, 9, LimCredNuevo)
            MyBase.AddParameter("@LimValeAntB", OdbcType.Double, 9, LimValeAnt)
            MyBase.AddParameter("@LimValeNuevoB", OdbcType.Double, 9, LimValeNuevo)
            MyBase.AddParameter("@MotivoB", OdbcType.Char, 100, Motivo)
            MyBase.AddParameter("@IdUsuarioB", OdbcType.Int, 8, IdUsuario)

            usp_CapturaMovsDistrib = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActulizaLimites(ByVal IdDistrib As Integer, ByVal LimCred As Double, ByVal LimVale As Double) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActulizaLimites(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@IdDistribB", OdbcType.Int, 8, IdDistrib)
            MyBase.AddParameter("@LimCredB", OdbcType.Double, 9, LimCred)
            MyBase.AddParameter("@LimValeB", OdbcType.Double, 9, LimVale)

            usp_ActulizaLimites = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
