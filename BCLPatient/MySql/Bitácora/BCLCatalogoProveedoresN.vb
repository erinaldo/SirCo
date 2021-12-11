Public Class BCLCatalogoProveedoresN
    Implements IDisposable
    Private objDALCatalogoProveedores As DAL.DALCatalogoProveedoresN
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoProveedores = New DAL.DALCatalogoProveedoresN(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoProveedores.Dispose()
            objDALCatalogoProveedores = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "

    Public Function Inserta_Proveedor() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Proveedor = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Proveedor.Tables.Add("proveedo")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idproveedor", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("raz_soc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rfc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 13
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calle", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("colonia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudad", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 4
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("codpos", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telef1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telef2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telef3", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("web", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("password", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("paqueteria", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("convenio", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porcobrar", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipopag", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("librea", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("motivo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 750
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dsctopp", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diaspp", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto01", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto02", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto03", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto04", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto05", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("aceptafactoraje", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechafactoraje", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idbancofactoraje", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipopago", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)




        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Condicion() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Condicion = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Condicion.Tables.Add("condicionesp")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idcondicion", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idproveedor", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("basevenc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("factorc", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipopago", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numpagos", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dsctopp", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diaspp", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("plazoporc", Type.GetType("System.Double"))
            'objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto01", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto02", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto03", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto04", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto05", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("lotemin", Type.GetType("System.Int16"))
            'objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("univta", Type.GetType("System.Int16"))
            'objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dsctofact", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rprov", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("aceptadev", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costeopv", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costeomargen", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("consignacion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("plazo", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("condicion", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cpdias", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cpporc", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("VIGENCIA", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("factrem", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Devolucion() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Devolucion = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Devolucion.Tables.Add("devolp")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("iddevolprov", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idproveedor", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipodev", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("paresmin", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impmin", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("plazo", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("procedimd", Type.GetType("System.String"))
            objDataColumn.MaxLength = 750
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contacto", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calle", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("colonia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudad", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 4
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("codpos", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telef1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telef2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("viaemail", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("email", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("paqueteria", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("convenio", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porcobrar", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipopag", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("librea", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("procedimp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 750
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Cuentas() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Cuentas = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Cuentas.Tables.Add("cuentasp")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idcuenta", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idproveedor", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("plaza", Type.GetType("System.String"))
            objDataColumn.MaxLength = 4
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("banco", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("clabe", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("referencia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cuenta", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Contactos() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Contactos = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Contactos.Tables.Add("contactosp")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties

            objDataColumn = New DataColumn("idcontacto", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idproveedor", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("puesto", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("email", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telefono", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("extension", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("celular", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nextel", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ubicacion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProveedorN(ByVal idProveedor As Integer) As DataSet
        'mreyes 17/Febrero/2012 11:10 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerProveedorN = objDALCatalogoProveedores.usp_TraerProveedorN(idProveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoProveedoresN(ByVal IdProveedor As Integer, ByVal Raz_Soc As String, ByVal Estado As String, _
                                                 ByVal Ciudad As String, ByVal Estatus As String, ByVal Marca As String, ByVal TipoB As String, ByVal AceptaFactorajeB As Integer, ByVal FactRemB As Integer) As DataSet

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoProveedoresN = objDALCatalogoProveedores.usp_PpalCatalogoProveedoresN(IdProveedor, Raz_Soc, Estado, Ciudad, Estatus, Marca, TipoB, AceptaFactorajeB, FactRemB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerContactosProv(ByVal IdProveedor As Integer, ByVal Marca As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerContactosProv = objDALCatalogoProveedores.usp_TraerContactosProv(IdProveedor, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCuentasProv(ByVal IdProveedor As Integer) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerCuentasProv = objDALCatalogoProveedores.usp_TraerCuentasProv(IdProveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerBancoFactoraje(ByVal Banco As String) As DataSet
        Try
            'mreyes 15/Octubre/2014 12:40 p.m.

            'Call the data component to get all groups
            usp_TraerBancoFactoraje = objDALCatalogoProveedores.usp_TraerBancoFactoraje(Banco)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCondicionesProv(ByVal IdProveedor As Integer, ByVal Marca As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerCondicionesProv = objDALCatalogoProveedores.usp_TraerCondicionesProv(IdProveedor, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDevolucionesProv(ByVal IdProveedor As Integer, ByVal Marca As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerDevolucionesProv = objDALCatalogoProveedores.usp_TraerDevolucionesProv(IdProveedor, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ProveedorN(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data 

            'Call the data component to add the new group
            Return objDALCatalogoProveedores.usp_Captura_ProveedorN(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CuentasProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProveedores.usp_Captura_CuentasProv(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ContactosProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProveedores.usp_Captura_ContactosProv(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CondicionesProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProveedores.usp_Captura_CondicionesProv(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_DevolucionesProv(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProveedores.usp_Captura_DevolucionesProv(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CondPlazoPorc(ByVal Opcion As Integer, ByVal IdProveedor As Integer, ByVal Proveedor As String, _
                                              ByVal IdCondicion As Integer, ByVal Marca As String, ByVal Porcentaje As Double, ByVal IdUsuario As Integer) As Boolean
        Try
            Return objDALCatalogoProveedores.usp_Captura_CondPlazoPorc(Opcion, IdProveedor, Proveedor, IdCondicion, Marca, Porcentaje, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdProveedor(ByVal Proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerIdProveedor = objDALCatalogoProveedores.usp_TraerIdProveedor(Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantidadDetProv(ByVal Tipo As String, ByVal Proveedor As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerCantidadDetProv = objDALCatalogoProveedores.usp_TraerCantidadDetProv(Tipo, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizaEstatusDetProv(ByVal Tipo As String, ByVal Proveedor As String, ByVal Id As Integer, ByVal IdUsuario As Integer) As Boolean
        Try
            Return objDALCatalogoProveedores.usp_ActualizaEstatusDetProv(Tipo, Proveedor, Id, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPaqueterias() As DataSet
        Try
            usp_TraerPaqueterias = objDALCatalogoProveedores.usp_TraerPaqueterias()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCondPlazoPorc(ByVal IdProveedor As Integer, ByVal IdCondicion As Integer, ByVal Marca As String) As DataSet
        Try
            usp_TraerCondPlazoPorc = objDALCatalogoProveedores.usp_TraerCondPlazoPorc(IdProveedor, IdCondicion, Marca)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
