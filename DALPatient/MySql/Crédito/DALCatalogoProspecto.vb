Imports System.Data.Odbc

Public Class DALCatalogoProspecto
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

    Public Function usp_Captura_Prospecto(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_Prospecto(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idprospectoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idprospecto"))
            MyBase.AddParameter("@nombreB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@appaternoB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("appaterno"))
            MyBase.AddParameter("@apmaternoB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("apmaterno"))
            MyBase.AddParameter("@idpromotorB", OdbcType.Int, 4, Section.Tables(0).Rows(0).Item("idpromotor"))
            MyBase.AddParameter("@avalB", OdbcType.Int, 6, Section.Tables(0).Rows(0).Item("aval"))
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@comentarioB", OdbcType.Text, 999, Section.Tables(0).Rows(0).Item("comentario"))
            MyBase.AddParameter("@limcredB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("limcred"))
            MyBase.AddParameter("@limvaleB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("limvale"))
            MyBase.AddParameter("@disponibleB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("disponible"))
            MyBase.AddParameter("@saldoB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("saldo"))
            MyBase.AddParameter("@telef1B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef1"))
            MyBase.AddParameter("@telef2B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef2"))
            MyBase.AddParameter("@celularB", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("celular"))
            MyBase.AddParameter("@rfcB", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@curpB", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("curp"))
            MyBase.AddParameter("@ifeB", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("ife"))
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
            MyBase.AddParameter("@ingrconyB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("ingrcony"))
            MyBase.AddParameter("@otringconyB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("otringcony"))
            MyBase.AddParameter("@referencia1B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("referencia1"))
            MyBase.AddParameter("@telref1B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telref1"))
            MyBase.AddParameter("@direcref1B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("direcref1"))
            MyBase.AddParameter("@ocupacionref1B", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("ocupacionref1"))
            MyBase.AddParameter("@referencia2B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("referencia2"))
            MyBase.AddParameter("@telref2B", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telref2"))
            MyBase.AddParameter("@direcref2B", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("direcref2"))
            MyBase.AddParameter("@ocupacionref2B", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("ocupacionref2"))
            MyBase.AddParameter("@usuariocapturaB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuariocaptura"))
            MyBase.AddParameter("@usuariorevisionB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuariorevision"))
            MyBase.AddParameter("@fumrevisionB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fumrevision"))
            MyBase.AddParameter("@usupausadoB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usupausado"))
            MyBase.AddParameter("@fumpausadoB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fumpausado"))
            MyBase.AddParameter("@usuautorizoB", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuautorizo"))
            MyBase.AddParameter("@fumautorizoB", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fumautorizo"))

            MyBase.AddParameter("@twitterB", OdbcType.Char, 255, Section.Tables(0).Rows(0).Item("twitter"))
            MyBase.AddParameter("@facebookB", OdbcType.Char, 255, Section.Tables(0).Rows(0).Item("facebook"))
            MyBase.AddParameter("@pagareB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("pagare"))
            MyBase.AddParameter("@catastroB", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("catastro"))

            usp_Captura_Prospecto = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEmpleadoProspecto(ByVal IdEmpleado As Integer) As DataSet
        '
        Try
            usp_TraerEmpleadoProspecto = New DataSet
            MyBase.SQL = "CALL usp_TraerEmpleadoProspecto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)


            MyBase.FillDataSet(usp_TraerEmpleadoProspecto, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEmpleadoProspectoLike(ByVal Descrip As String, ByVal Empleado As String) As DataSet
        '
        Try
            usp_TraerEmpleadoProspectoLike = New DataSet
            MyBase.SQL = "CALL usp_TraerEmpleadoProspectoLike(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@descripB", OdbcType.Char, 80, Descrip)
            MyBase.AddParameter("@dEmpleadoB", OdbcType.Char, 80, Empleado)


            MyBase.FillDataSet(usp_TraerEmpleadoProspectoLike, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProspecto(ByVal IdProspecto As Integer) As DataSet

        Try
            usp_TraerProspecto = New DataSet
            MyBase.SQL = "CALL usp_TraerProspecto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idProspectoB", OdbcType.Int, 16, IdProspecto)


            MyBase.FillDataSet(usp_TraerProspecto, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnProspectoLike(ByVal estatus As String, ByVal nombre As String) As DataSet

        Try
            usp_TraerUnProspectoLike = New DataSet
            MyBase.SQL = "CALL usp_TraerUnProspectoLike(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, estatus)
            MyBase.AddParameter("@idprospectoB", OdbcType.Char, 80, nombre)


            MyBase.FillDataSet(usp_TraerUnProspectoLike, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCodPos(ByVal Colonia As String, ByVal Ciudad As String) As DataSet
        '
        Try
            usp_TraerCodPos = New DataSet
            MyBase.SQL = "CALL usp_TraerCodPos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@coloniaB", OdbcType.Char, 45, Colonia)
            MyBase.AddParameter("@municipioB", OdbcType.Char, 45, Ciudad)

            MyBase.FillDataSet(usp_TraerCodPos, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxPros() As DataSet
        'Ro. 25/03/2013
        Try
            usp_TraerMaxPros = New DataSet
            MyBase.SQL = "CALL usp_TraerMaxPros()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@coloniaB", OdbcType.Char, 45, nombre)


            MyBase.FillDataSet(usp_TraerMaxPros, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxAval() As DataSet
        'Ro. 25/03/2013
        Try
            usp_TraerMaxAval = New DataSet
            MyBase.SQL = "CALL usp_TraerMaxAval()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@coloniaB", OdbcType.Char, 45, nombre)


            MyBase.FillDataSet(usp_TraerMaxAval, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFum(ByVal prospecto As Integer) As DataSet
        'Ro. 25/03/2013
        Try
            usp_TraerFum = New DataSet
            MyBase.SQL = "CALL usp_TraerFum(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@prospectoB", OdbcType.Int, 16, prospecto)


            MyBase.FillDataSet(usp_TraerFum, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoProspecto(ByVal ProspectoA As String, ByVal ProspectoB As String, ByVal EstatusB As String, ByVal PromotorB As String) As DataSet
        'Ro
        Try

            usp_PpalCatalogoProspecto = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoProspecto(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@prospectoA", OdbcType.Char, 6, ProspectoA)
            MyBase.AddParameter("@prospectoB", OdbcType.Char, 6, ProspectoB)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, EstatusB)
            MyBase.AddParameter("@promotorB", OdbcType.Char, 6, PromotorB)
            MyBase.FillDataSet(usp_PpalCatalogoProspecto, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnProspecto(ByVal IdProspecto As String) As DataSet

        Try
            usp_TraerUnProspecto = New DataSet
            MyBase.SQL = "CALL usp_TraerUnProspecto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Char, 6, IdProspecto)


            MyBase.FillDataSet(usp_TraerUnProspecto, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarEstatus(ByVal Opcion As String, ByVal idProspecto As Integer, ByVal Estatus As String) As Boolean
        'Tony Garcia - 15/Octubre/2012 - 
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatus(?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Char, 3, Opcion)
            MyBase.AddParameter("@idprospectoB", OdbcType.Int, 16, idProspecto)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, Estatus)

            usp_ActualizarEstatus = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNegEx(ByVal negocio As String) As DataSet

        Try
            usp_TraerNegEx = New DataSet
            MyBase.SQL = "CALL usp_TraerNE(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@dnegocioB", OdbcType.Char, 2, negocio)


            MyBase.FillDataSet(usp_TraerNegEx, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNegociosExternos(ByVal opcion As String, ByVal prospecto As String) As DataSet

        Try
            usp_TraerNegociosExternos = New DataSet
            MyBase.SQL = "CALL usp_TraerNegEx(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, opcion)
            MyBase.AddParameter("@idB", OdbcType.Char, 6, prospecto)


            MyBase.FillDataSet(usp_TraerNegociosExternos, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ClaveNEP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_ClaveNE(?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@iddistribB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("iddistrib"))
            MyBase.AddParameter("@idprospectoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idprospecto"))
            MyBase.AddParameter("@negocioB", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("negocio"))
            MyBase.AddParameter("@claveB", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("clave"))
            MyBase.AddParameter("@feccorteB", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("feccorte"))
            MyBase.AddParameter("@ventaB", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("venta"))

            usp_Captura_ClaveNEP = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxDistrib() As DataSet
        'Ro. 25/03/2013
        Try
            usp_TraerMaxDistrib = New DataSet
            MyBase.SQL = "CALL usp_TraerMaxDistrib()"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@coloniaB", OdbcType.Char, 45, nombre)


            MyBase.FillDataSet(usp_TraerMaxDistrib, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_DocFotos(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_DocFotos(?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idB", OdbcType.Char, 6, Section.Tables(0).Rows(0).Item("id"))
            MyBase.AddParameter("@tipoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@docfotoB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("docfoto"))
            MyBase.AddParameter("@nofotoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("nofoto"))
            MyBase.AddParameter("@perteneceB", OdbcType.Char, 200, Section.Tables(0).Rows(0).Item("pertenece"))
            MyBase.AddParameter("@rutaB", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("ruta"))
            MyBase.AddParameter("@fecha", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@hora", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))



            usp_Captura_DocFotos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Actualiza_DocFotos(ByVal IdDistrib As Integer, ByVal IdProspecto As Integer) As DataSet
        Try
            usp_Actualiza_DocFotos = New DataSet
            MyBase.SQL = "CALL usp_Actualiza_DocFotos(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idDistribB", OdbcType.Int, 16, IdDistrib)
            MyBase.AddParameter("@IdProspectoB", OdbcType.Int, 16, IdProspecto)

            MyBase.FillDataSet(usp_Actualiza_DocFotos, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Elimina_Negocio(ByVal prospecto As String, ByVal distrib As String) As DataSet

        Try
            usp_Elimina_Negocio = New DataSet
            MyBase.SQL = "CALL usp_Elimina_Negocio(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idprospecto", OdbcType.Char, 6, prospecto)
            MyBase.AddParameter("@iddistrib", OdbcType.Char, 6, distrib)


            MyBase.FillDataSet(usp_Elimina_Negocio, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDistribNE(ByVal distrib As String) As DataSet
        'Ro. 25/03/2013
        Try
            usp_TraerDistribNE = New DataSet
            MyBase.SQL = "CALL usp_TraerDistribNE(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@distribB", OdbcType.Char, 6, distrib)


            MyBase.FillDataSet(usp_TraerDistribNE, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Motivo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_ProspMotivoNA(?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idprospectoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idprospecto"))
            MyBase.AddParameter("@idB", OdbcType.Char, 4, Section.Tables(0).Rows(0).Item("idmotivo"))
            MyBase.AddParameter("@motivoB", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("motivo"))
            usp_Captura_Motivo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNoAutorizados(ByVal prospecto As String) As DataSet

        Try
            usp_TraerNoAutorizados = New DataSet
            MyBase.SQL = "CALL usp_TraerNoAutorizados(?)"

            MyBase.InitializeCommand()
            'MyBase.AddParameter("@opcion", OdbcType.Int, 16, opcion)
            MyBase.AddParameter("@idprospectoB", OdbcType.Char, 6, prospecto)


            MyBase.FillDataSet(usp_TraerNoAutorizados, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnProspectoNA(ByVal IdProspecto As String) As DataSet

        Try
            usp_TraerUnProspectoNA = New DataSet
            MyBase.SQL = "CALL usp_TraerUnProspectoNA(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdEmpleado", OdbcType.Char, 6, IdProspecto)


            MyBase.FillDataSet(usp_TraerUnProspectoNA, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ImprimeProspecto(ByVal ProspectoA As String, ByVal ProspectoB As String, ByVal EstatusB As String, ByVal PromotorB As String) As DataSet

        Try

            usp_ImprimeProspecto = New DataSet
            MyBase.SQL = "CALL usp_ImprimeProspecto(?,?,?,?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@prospectoA", OdbcType.Char, 6, ProspectoA)
            MyBase.AddParameter("@prospectoB", OdbcType.Char, 6, ProspectoB)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, EstatusB)
            MyBase.AddParameter("@promotorB", OdbcType.Char, 6, PromotorB)
            MyBase.FillDataSet(usp_ImprimeProspecto, "crvsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
