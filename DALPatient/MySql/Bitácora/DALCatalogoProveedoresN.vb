Imports System.Data.Odbc

Public Class DALCatalogoProveedoresN
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

    Public Function usp_TraerProveedorN(ByVal idProveedor As Integer) As DataSet
        Try
            usp_TraerProveedorN = New DataSet
            MyBase.SQL = "CALL usp_TraerProveedorN(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idProveedorB", OdbcType.SmallInt, 4, idProveedor)

            MyBase.FillDataSet(usp_TraerProveedorN, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoProveedoresN(ByVal IdProveedor As Integer, ByVal Raz_Soc As String, ByVal Estado As String, _
                                                 ByVal Ciudad As String, ByVal Estatus As String, ByVal Marca As String, _
                                                 ByVal TipoB As String, ByVal aceptafactorajeb As Integer, _
                                                 ByVal FactRemB As Integer) As DataSet
        Try
            usp_PpalCatalogoProveedoresN = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoProveedoresN(?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idproveedorb", OdbcType.SmallInt, 4, IdProveedor)
            MyBase.AddParameter("@Raz_Socb", OdbcType.Char, 50, Raz_Soc)
            MyBase.AddParameter("@Estadob", OdbcType.Char, 4, Estado)
            MyBase.AddParameter("@CiudadB", OdbcType.Char, 40, Ciudad)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@MarcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@TipoB", OdbcType.Char, 10, TipoB)
            MyBase.AddParameter("@AceptaFactorajeB", OdbcType.Int, 1, aceptafactorajeb)
            MyBase.AddParameter("@FactRemB", OdbcType.Int, 1, FactRemB)


            MyBase.FillDataSet(usp_PpalCatalogoProveedoresN, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerContactosProv(ByVal IdProveedor As Integer, ByVal Marca As String) As DataSet
        Try
            usp_TraerContactosProv = New DataSet
            MyBase.SQL = "CALL usp_TraerContactosProv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idproveedorb", OdbcType.SmallInt, 4, IdProveedor)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerContactosProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCuentasProv(ByVal IdProveedor As Integer) As DataSet
        Try
            usp_TraerCuentasProv = New DataSet
            MyBase.SQL = "CALL usp_TraerCuentasProv(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idproveedorb", OdbcType.SmallInt, 4, IdProveedor)

            MyBase.FillDataSet(usp_TraerCuentasProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerBancoFactoraje(ByVal Banco As String) As DataSet
        Try
            usp_TraerBancoFactoraje = New DataSet
            MyBase.SQL = "CALL usp_TraerBancoFactoraje(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Banco", OdbcType.Char, 100, Banco)

            MyBase.FillDataSet(usp_TraerBancoFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCondicionesProv(ByVal IdProveedor As Integer, ByVal Marca As String) As DataSet
        Try
            usp_TraerCondicionesProv = New DataSet
            MyBase.SQL = "CALL usp_TraerCondicionesProv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idproveedorb", OdbcType.SmallInt, 4, IdProveedor)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerCondicionesProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDevolucionesProv(ByVal IdProveedor As Integer, ByVal Marca As String) As DataSet
        Try
            usp_TraerDevolucionesProv = New DataSet
            MyBase.SQL = "CALL usp_TraerDevolucionesProv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idproveedorb", OdbcType.SmallInt, 4, IdProveedor)
            MyBase.AddParameter("@marcab", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerDevolucionesProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ProveedorN(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_ProveedorN(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idproveedor", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idproveedor"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@raz_soc", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("raz_soc"))
            MyBase.AddParameter("@rfc", OdbcType.Char, 13, Section.Tables(0).Rows(0).Item("rfc"))
            MyBase.AddParameter("@calle", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@colonia", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@ciudad", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("ciudad"))
            MyBase.AddParameter("@estado", OdbcType.Char, 4, Section.Tables(0).Rows(0).Item("estado"))
            MyBase.AddParameter("@codpos", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("codpos"))
            MyBase.AddParameter("@telef1", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef1"))
            MyBase.AddParameter("@telef2", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef2"))
            MyBase.AddParameter("@telef3", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef3"))
            MyBase.AddParameter("@web", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("web"))
            MyBase.AddParameter("@usuario", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@password", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("password"))
            MyBase.AddParameter("@paqueteria", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("paqueteria"))
            MyBase.AddParameter("@convenio", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("convenio"))
            MyBase.AddParameter("@porcobrar", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("porcobrar"))
            MyBase.AddParameter("@tipopag", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("tipopag"))
            MyBase.AddParameter("@librea", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("librea"))
            MyBase.AddParameter("@status", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@motivo", OdbcType.Text, 750, Section.Tables(0).Rows(0).Item("motivo"))
            MyBase.AddParameter("@dsctopp", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dsctopp"))
            MyBase.AddParameter("@diaspp", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("diaspp"))
            MyBase.AddParameter("@dscto01", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto01"))
            MyBase.AddParameter("@dscto02", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto02"))
            MyBase.AddParameter("@dscto03", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto03"))
            MyBase.AddParameter("@dscto04", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto04"))
            MyBase.AddParameter("@dscto05", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto05"))
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idusuario"))
            MyBase.AddParameter("@tipo", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@aceptafactoraje", OdbcType.SmallInt, 5, Section.Tables(0).Rows(0).Item("aceptafactoraje"))
            MyBase.AddParameter("@fechafactoraje", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fechafactoraje"))
            MyBase.AddParameter("@idbancofactoraje", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idbancofactoraje"))


            MyBase.AddParameter("@tipopago", OdbcType.Char, 45, Section.Tables(0).Rows(0).Item("tipopago"))



            usp_Captura_ProveedorN = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CuentasProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_CuentasProv(?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idcuenta", OdbcType.SmallInt, 6, Section.Tables(0).Rows(0).Item("idcuenta"))
            MyBase.AddParameter("@idproveedor", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idproveedor"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@plaza", OdbcType.Char, 4, Section.Tables(0).Rows(0).Item("plaza"))
            MyBase.AddParameter("@banco", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("banco"))
            MyBase.AddParameter("@sucursal", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@clabe", OdbcType.Char, 18, Section.Tables(0).Rows(0).Item("clabe"))
            MyBase.AddParameter("@referencia", OdbcType.Char, 100, Section.Tables(0).Rows(0).Item("referencia"))
            MyBase.AddParameter("@cuenta", OdbcType.Char, 20, Section.Tables(0).Rows(0).Item("cuenta"))
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idusuario"))

            usp_Captura_CuentasProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ContactosProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_ContactosProv(?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idcontacto", OdbcType.SmallInt, 6, Section.Tables(0).Rows(0).Item("idcontacto"))
            MyBase.AddParameter("@idproveedor", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idproveedor"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@nombre", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("nombre"))
            MyBase.AddParameter("@puesto", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("puesto"))
            MyBase.AddParameter("@email", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@telefono", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telefono"))
            MyBase.AddParameter("@extension", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("extension"))
            MyBase.AddParameter("@celular", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("celular"))
            MyBase.AddParameter("@nextel", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("nextel"))
            MyBase.AddParameter("@ubicacion", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("ubicacion"))
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idusuario"))

            usp_Captura_ContactosProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CondicionesProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_CondicionesProv(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idcondicion", OdbcType.SmallInt, 6, Section.Tables(0).Rows(0).Item("idcondicion"))
            MyBase.AddParameter("@idproveedor", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idproveedor"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@basevenc", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("basevenc"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@factorc", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("factorc"))
            MyBase.AddParameter("@tipopago", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipopago"))
            MyBase.AddParameter("@numpagos", OdbcType.SmallInt, 2, Section.Tables(0).Rows(0).Item("numpagos"))
            MyBase.AddParameter("@diaspp", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("diaspp"))
            MyBase.AddParameter("@dsctopp", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("dsctopp"))
            MyBase.AddParameter("@dscto01", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("dscto01"))
            MyBase.AddParameter("@dscto02", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("dscto02"))
            MyBase.AddParameter("@dscto03", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("dscto03"))
            MyBase.AddParameter("@dscto04", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("dscto04"))
            MyBase.AddParameter("@dscto05", OdbcType.SmallInt, 1, Section.Tables(0).Rows(0).Item("dscto05"))
            MyBase.AddParameter("@dsctofact", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("dsctofact"))
            MyBase.AddParameter("@rprov", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("rprov"))
            MyBase.AddParameter("@aceptadev", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("aceptadev"))
            MyBase.AddParameter("@costeopv", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("costeopv"))
            MyBase.AddParameter("@consignacion", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("consignacion"))
            MyBase.AddParameter("@plazo", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("plazo"))
            MyBase.AddParameter("@condicion", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("condicion"))
            MyBase.AddParameter("@cpdias", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("cpdias"))
            MyBase.AddParameter("@cpporc", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("cpporc"))
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idusuario"))
            MyBase.AddParameter("@vigencia", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("vigencia"))

            MyBase.AddParameter("@factrem", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("factrem"))

            usp_Captura_CondicionesProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_DevolucionesProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_DevolucionesProv(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@iddevolprov", OdbcType.SmallInt, 6, Section.Tables(0).Rows(0).Item("iddevolprov"))
            MyBase.AddParameter("@idproveedor", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idproveedor"))
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("proveedor"))
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Section.Tables(0).Rows(0).Item("marca"))
            MyBase.AddParameter("@tipodev", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipodev"))
            MyBase.AddParameter("@paresmin", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("paresmin"))
            MyBase.AddParameter("@impmin", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("impmin"))
            MyBase.AddParameter("@plazo", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("plazo"))
            MyBase.AddParameter("@procedimd", OdbcType.Text, 750, Section.Tables(0).Rows(0).Item("procedimd"))
            MyBase.AddParameter("@contacto", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("contacto"))
            MyBase.AddParameter("@calle", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("calle"))
            MyBase.AddParameter("@colonia", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("colonia"))
            MyBase.AddParameter("@ciudad", OdbcType.Char, 40, Section.Tables(0).Rows(0).Item("ciudad"))
            MyBase.AddParameter("@estado", OdbcType.Char, 4, Section.Tables(0).Rows(0).Item("estado"))
            MyBase.AddParameter("@codpos", OdbcType.Char, 5, Section.Tables(0).Rows(0).Item("codpos"))
            MyBase.AddParameter("@telef1", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef1"))
            MyBase.AddParameter("@telef2", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("telef2"))
            MyBase.AddParameter("@viaemail", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("viaemail"))
            MyBase.AddParameter("@email", OdbcType.Char, 60, Section.Tables(0).Rows(0).Item("email"))
            MyBase.AddParameter("@paqueteria", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("paqueteria"))
            MyBase.AddParameter("@convenio", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("convenio"))
            MyBase.AddParameter("@porcobrar", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("porcobrar"))
            MyBase.AddParameter("@tipopag", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("tipopag"))
            MyBase.AddParameter("@librea", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("librea"))
            MyBase.AddParameter("@procedimp", OdbcType.Text, 750, Section.Tables(0).Rows(0).Item("procedimp"))
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 4, Section.Tables(0).Rows(0).Item("idusuario"))

            usp_Captura_DevolucionesProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CondPlazoPorc(ByVal Opcion As Integer, ByVal IdProveedor As Integer, ByVal Proveedor As String, _
                                              ByVal IdCondicion As Integer, ByVal Marca As String, ByVal Porcentaje As Double, ByVal IdUsuario As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_Captura_CondPlazoPorc(?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idproveedor", OdbcType.SmallInt, 4, IdProveedor)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@idcondicion", OdbcType.SmallInt, 6, IdCondicion)
            MyBase.AddParameter("@marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@porcentaje", OdbcType.Double, 9, Porcentaje)
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 6, IdUsuario)

            usp_Captura_CondPlazoPorc = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdProveedor(ByVal Proveedor As String) As DataSet
        Try
            usp_TraerIdProveedor = New DataSet
            MyBase.SQL = "CALL usp_TraerIdProveedor(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorb", OdbcType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerIdProveedor, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantidadDetProv(ByVal Tipo As String, ByVal Proveedor As String) As DataSet
        Try
            usp_TraerCantidadDetProv = New DataSet
            MyBase.SQL = "CALL usp_TraerCantidadDetProv(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@tipo", OdbcType.Char, 2, Tipo)
            MyBase.AddParameter("@proveedorb", OdbcType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerCantidadDetProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusDetProv(ByVal Tipo As String, ByVal Proveedor As String, ByVal Id As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            MyBase.SQL = "CALL usp_ActualizaEstatusDetProv(?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection

            MyBase.AddParameter("@tipo", OdbcType.Char, 2, Tipo)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@id", OdbcType.SmallInt, 6, Id)
            MyBase.AddParameter("@idusuario", OdbcType.SmallInt, 4, IdUsuario)

            usp_ActualizaEstatusDetProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPaqueterias() As DataSet
        Try
            usp_TraerPaqueterias = New DataSet
            MyBase.SQL = "CALL usp_TraerPaqueterias()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerPaqueterias, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCondPlazoPorc(ByVal IdProveedor As Integer, ByVal IdCondicion As Integer, ByVal Marca As String) As DataSet
        Try
            usp_TraerCondPlazoPorc = New DataSet
            MyBase.SQL = "CALL usp_TraerCondPlazoPorc(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdProveedor", OdbcType.SmallInt, 4, IdProveedor)
            MyBase.AddParameter("@IdCondicion", OdbcType.SmallInt, 6, IdCondicion)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerCondPlazoPorc, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
