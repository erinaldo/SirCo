Imports System.Data.Odbc
'mreyes 17/Febrero/2012 10:00 a.m.

Public Class DALCatalogoProveedores
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



    Public Function usp_Captura_Proveedor(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 17/Febrero/2012 10:18 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Proveedor(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add the Parameters to the Parameters collection
            'User_Name Text 15
            'MyBase.AddParameter("@Nomina_ID", SqlDbType.Int, 16, Section.Tables(0).Rows(0).Item("Nomina_ID"))
            'MyBase.AddParameter("@Emp_ID", Data.SqlDbType.VarChar, 10, Section.Tables(0).Rows(0).Item("Emp_ID"))
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
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
            MyBase.AddParameter("@fax", OdbcType.Char, 15, Section.Tables(0).Rows(0).Item("fax"))
            MyBase.AddParameter("@contact1", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("contact1"))
            MyBase.AddParameter("@contact2", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("contact2"))
            MyBase.AddParameter("@condic", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("condic"))
            MyBase.AddParameter("@transp", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("transp"))
            MyBase.AddParameter("@agente", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("agente"))
            MyBase.AddParameter("@dsctopp", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dsctopp"))
            MyBase.AddParameter("@diaspp", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("diaspp"))
            MyBase.AddParameter("@dscto01", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto01"))
            MyBase.AddParameter("@dscto02", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto02"))
            MyBase.AddParameter("@dscto03", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto03"))
            MyBase.AddParameter("@dscto04", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto04"))
            MyBase.AddParameter("@dscto05", OdbcType.SmallInt, 3, Section.Tables(0).Rows(0).Item("dscto05"))
            MyBase.AddParameter("@email01", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("email01"))
            MyBase.AddParameter("@email02", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("email02"))
            MyBase.AddParameter("@status", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@remision", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("remision"))
            MyBase.AddParameter("@adicional", OdbcType.SmallInt, 2, Section.Tables(0).Rows(0).Item("adicional"))
            MyBase.AddParameter("@pquincenal", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("pquincenal"))
            MyBase.AddParameter("@numpagos", OdbcType.SmallInt, 2, Section.Tables(0).Rows(0).Item("numpagos"))
            MyBase.AddParameter("@consignacion", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("consignacion"))
            MyBase.AddParameter("@dsctofact", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("dsctofact"))
            MyBase.AddParameter("@devoluciones", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("devoluciones"))
            MyBase.AddParameter("@contactopago", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("contactopago"))
            MyBase.AddParameter("@emailcp01", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("emailcp01"))
            MyBase.AddParameter("@emailcp02", OdbcType.Char, 80, Section.Tables(0).Rows(0).Item("emailcp02"))

            usp_Captura_Proveedor = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProveedorMarca(ByVal Proveedor As String) As DataSet
        'mreyes 17/Febrero/2012 11:11 a.m.
        Try
            usp_TraerProveedorMarca = New DataSet
            MyBase.SQL = "CALL usp_TraerProveedorMarca(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)


            MyBase.FillDataSet(usp_TraerProveedorMarca, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProveedorNoPagos(ByVal Proveedor As String) As DataSet
        'mreyes 17/Febrero/2012 11:11 a.m.
        Try
            usp_TraerProveedorNoPagos = New DataSet
            MyBase.SQL = "CALL usp_TraerProveedorNoPagos(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)


            MyBase.FillDataSet(usp_TraerProveedorNoPagos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProveedoBanregio(ByVal Proveedor As String) As DataSet
        'mreyes 20/Agosto/2021  10:25 a.m.
        Try
            usp_TraerProveedoBanregio = New DataSet
            MyBase.SQL = "CALL usp_TraerProveedoBanregio(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)


            MyBase.FillDataSet(usp_TraerProveedoBanregio, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerProveedor(ByVal Proveedor As String, ByVal Marca As String) As DataSet
        'mreyes 17/Febrero/2012 11:11 a.m.
        Try
            usp_TraerProveedor = New DataSet
            MyBase.SQL = "CALL usp_TraerProveedor(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)

            MyBase.FillDataSet(usp_TraerProveedor, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoProveedores(ByVal Raz_Soc As String, ByVal Estado As String, ByVal Ciudad As String, ByVal Estatus As String) As DataSet
        'mreyes 28/Febrero/2012 01:45 p.m.
        Try
            usp_PpalCatalogoProveedores = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoProveedores(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Raz_Socb", OdbcType.Char, 50, Raz_Soc)
            MyBase.AddParameter("@Estadob", OdbcType.Char, 4, Estado)
            MyBase.AddParameter("@CiudadB", OdbcType.Char, 40, Ciudad)
            MyBase.AddParameter("@EstatusB", OdbcType.Char, 2, Estatus)


            MyBase.FillDataSet(usp_PpalCatalogoProveedores, "cipsis")
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
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, proveedor)

            MyBase.FillDataSet(usp_TraerMarcaPrincipal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ExisteProveedor(ByVal RazSoc As String, ByVal RFC As String) As DataSet
        'Tony Garcia - 06/Julio/2013 12:06 p.m.
        Try
            usp_ExisteProveedor = New DataSet
            MyBase.SQL = "CALL usp_ExisteProveedor(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@razsocb", OdbcType.Char, 50, RazSoc)
            MyBase.AddParameter("@rfcb", OdbcType.Char, 13, RFC)

            MyBase.FillDataSet(usp_ExisteProveedor, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
