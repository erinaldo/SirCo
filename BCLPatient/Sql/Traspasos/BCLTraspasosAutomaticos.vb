Public Class BCLTraspasosAutomaticos
    'mreyes 06/Julio/2016   06:14 p.m.

    Implements IDisposable
    Private objDALTraspasosAutomaticos As DAL.DALTraspasosAutomaticos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALTraspasosAutomaticos = New DAL.DALTraspasosAutomaticos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALTraspasosAutomaticos.Dispose()
            objDALTraspasosAutomaticos = Nothing
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




    Public Function usp_Captura_Empleado(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 11/Junio/2012 04:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_Captura_Empleado(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function Inserta_Empleado() As DataSet
        'mreyes 18/Junio/2012 05:50 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Empleado = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Empleado.Tables.Add("Empleado")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("clave", Type.GetType("System.String"))
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("appaterno", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("apmaterno", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iddepto", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idpuesto", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("vendedor", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfrecpago", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("jornada", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("entrada", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comida", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descanso", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("extras", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("baja", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ingreso", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("bonofijo", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tsalario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("zsalario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("porinteg", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sdiario", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("shora", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sinteg", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ptu", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("imss", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("bono", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cuenta", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("licencia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("unimed", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calle", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("colonia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudad", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("estado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numext", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numint", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sexo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
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

            objDataColumn = New DataColumn("email", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nacim", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudadnac", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("edocivil", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numhijos", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nompadre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nommadre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rfc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("curp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("noimss", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("checa", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usumodif", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("beneficiario1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 150
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("parentesco1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("porcentaje1", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("beneficiario2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 150
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("parentesco2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("porcentaje2", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cuentabajio", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)






        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function Inserta_Horario() As DataSet
        'mreyes 20/Abril/2015   05:27 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Horario = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Horario.Tables.Add("Horario")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("dia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("entrada", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("salida", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("entrada1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("salida1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("prioridad", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("diaingles", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleadoCedis(ByVal idEmpleado As Integer) As DataSet
        'mreyes 24/Febrero/2013 12:24 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleadoCedis = objDALTraspasosAutomaticos.usp_TraerNomEmpleadoCedis(idEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal iddepto As Integer) As DataSet
        'mreyes 11/Junio/2012 01:26
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleado = objDALTraspasosAutomaticos.usp_TraerNomEmpleado(idEmpleado, ApPaterno, apMaterno, Nombre, Estatus, iddepto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNomEmpleadosuc(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal iddepto As Integer, ByVal sucursal As String) As DataSet
        'mreyes 11/Junio/2012 01:26
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleadosuc = objDALTraspasosAutomaticos.usp_TraerNomEmpleadosuc(idEmpleado, ApPaterno, apMaterno, Nombre, Estatus, iddepto, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerHorarioEmpleado(ByVal idEmpleado As Integer) As DataSet
        'mreyes 19/Abril/2015   01:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerHorarioEmpleado = objDALTraspasosAutomaticos.usp_TraerHorarioEmpleado(idEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVendedor(ByVal idEmpleado As Integer) As DataSet
        'mreyes 18/Agosto/2012 01:07 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerVendedor = objDALTraspasosAutomaticos.usp_TraerVendedor(idEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClaveEmpleado(ByVal Sucursal As String) As DataSet
        'mreyes 19/Junio/2012 05:01 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerClaveEmpleado = objDALTraspasosAutomaticos.usp_TraerClaveEmpleado(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEmpleado = objDALTraspasosAutomaticos.usp_TraerEmpleado(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVendedor(ByVal IdEmpleado As Integer, ByVal Sucursal As String) As DataSet
        'mreyes 27/Diciembre/2016   10:59 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerVendedor = objDALTraspasosAutomaticos.usp_TraerVendedor(IdEmpleado, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCorreoNomina(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCorreoNomina = objDALTraspasosAutomaticos.usp_TraerCorreoNomina(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuarioNomina(ByVal Password As String) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerUsuarioNomina = objDALTraspasosAutomaticos.usp_TraerUsuarioNomina(Password)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalProTraspDetNoAplica(ByVal IdSucursalB As Integer) As DataSet
        'mreyes 18/Agosto/2016  07:01 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalProTraspDetNoAplica = objDALTraspasosAutomaticos.usp_PpalProTraspDetNoAplica(IdSucursalB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalProTrasp(ByVal Opcion As Integer, ByVal IdProTras As Integer, ByVal IdSucursal As Integer,
                                                ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Estatus As String) As DataSet
        'mreyes 06/Julio/2016   06:20 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalProTrasp = objDALTraspasosAutomaticos.usp_PpalProTrasp(Opcion, IdProTras, IdSucursal, FechaIni, FechaFin, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraspasoEnLineaSalida(Cve_Sucursal As String) As DataSet
        'mreyes 30/Mayo/2019    04:36 p.m.

        Try
            'Call the data component to get all groups
            usp_TraspasoEnLineaSalida = objDALTraspasosAutomaticos.usp_TraspasoEnLineaSalida(Cve_Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraspasoEnLinea(Cve_Sucursal As String) As DataSet
        'mreyes 05/Abril/2018 a.m.

        Try
            'Call the data component to get all groups
            usp_TraspasoEnLinea = objDALTraspasosAutomaticos.usp_TraspasoEnLinea(Cve_Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNoMostrados(ByVal Sucursal As String, ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'mreyes 12/Mayo/2017    07:14 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalNoMostrados(Sucursal, fechaini, fechafin, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, Idagrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalNegBodega(ByVal Sucursal As String, ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'mreyes 18/Abril/2017   04:16 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalNegBodega(Sucursal, fechaini, fechafin, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, Idagrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCurvaIdeal(ByVal Sucursal As String, ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'mreyes 25/Abril/2017   10:57 a.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalCurvaIdeal(Sucursal, fechaini, fechafin, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, Idagrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_MatchTraspAut(ByVal Opcion As Integer, ByVal IdProTras As Integer) As DataSet
        'mreyes 26/Enero/2017   04:28 p.m.

        Try
            'Call the data component to get all groups
            usp_MatchTraspAut = objDALTraspasosAutomaticos.usp_MatchTraspAut(Opcion, IdProTras)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_PpalResurtidoTmp(ByVal Opcion As Integer, ByVal Marca As String, ByVal Sucursal As Integer, ByVal Proveedor As String, Depto As String) As DataSet
        'mreyes 19/Octubre/2016   07:21 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalResurtidoTmp = objDALTraspasosAutomaticos.usp_PpalResurtidoTmp(Opcion, Marca, Sucursal, Proveedor, Depto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalResumenProTrasp() As DataSet
        'mreyes 07/Octubre/2016 11:35 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalResumenProTrasp = objDALTraspasosAutomaticos.usp_PpalResumenProTrasp()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalResumenUsuario() As DataSet
        'mreyes 07/Octubre/2016 11:35 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalResumenUsuario = objDALTraspasosAutomaticos.usp_PpalResumenUsuario()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerExistenciaDirectaMySqlporMedida(ByVal MarcaB As String, ByVal EstilonB As String, MedidaB As String, ByVal SucursalB As String) As DataSet

        'mreyes 10/Abril/2017   11:03 a.m.

        Try

            '	 @DivisionB varchar(50), @LineaB varchar(50), @L1B varchar(50)

            usp_TraerExistenciaDirectaMySqlporMedida = objDALTraspasosAutomaticos.usp_TraerExistenciaDirectaMySqlporMedida(MarcaB, EstilonB, MedidaB, SucursalB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerExistenciaDirectaMySql(ByVal MarcaB As String, ByVal EstilonB As String, ByVal SucursalB As String) As DataSet

        'mreyes 27/Diciembre/2016   10:11 a.m.

        Try

            '	 @DivisionB varchar(50), @LineaB varchar(50), @L1B varchar(50)

            usp_TraerExistenciaDirectaMySql = objDALTraspasosAutomaticos.usp_TraerExistenciaDirectaMySql(MarcaB, EstilonB, SucursalB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCurva(ByVal MarcaB As String, ByVal EstilonB As String) As DataSet

        'mreyes 15/Enero/2019   03:55 p.m.

        Try


            usp_TraerCurva = objDALTraspasosAutomaticos.usp_TraerCurva(MarcaB, EstilonB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraPropuestaTraspasos(ByVal MarcaB As String, ByVal EstilonB As String, ByVal FechaIniB As String, ByVal FechaFinB As String, ByVal DivisionB As String, ByVal LineaB As String, ByVal L1B As String, ByVal Agrupacion As Integer, ByVal Sw_Generar As Integer, ByVal IdUsuario As Integer) As DataSet

        'mreyes 18/Julio/2016   12:08 p.m.

        Try
            'EXEC usp_GeneraPropuestaTraspasos 'FFF', '   2300','A','20160519','20160718', 'CALZADO','DAMAS','ESCOLAR'
            ' @MarcaB varchar(3), @EstilonB varchar(7), @CorridaB varchar(3),  @FechaIniB varchar(8), @FechaFinB varchar(8) ,
            '	 @DivisionB varchar(50), @LineaB varchar(50), @L1B varchar(50)

            usp_GeneraPropuestaTraspasos = objDALTraspasosAutomaticos.usp_GeneraPropuestaTraspasos(MarcaB, EstilonB, FechaIniB, FechaFinB, DivisionB, LineaB, L1B, Agrupacion, Sw_Generar, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraPedidoxCurvaIdeal(Opcion As Integer, Entregas As Integer, ByVal Marca As String, ByVal Estilof As String, Linea As String, L1 As String, Intervalo As String, MedIni As String, MedFin As String, Pares As Integer) As DataSet

        'mreyes 17/Octubre/2017 05:33 p.m.

        Try

            usp_GeneraPedidoxCurvaIdeal = objDALTraspasosAutomaticos.usp_GeneraPedidoxCurvaIdeal(Opcion, Entregas, Marca, Estilof, Linea, L1, Intervalo, MedIni, MedFin, Pares)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_ProTraspArticulo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Julio/2016   11:55 a.m.

        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_Captura_ProTraspArticulo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerArticulosMismaEstructura(ByVal Sucursal As String, ByVal Medida As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String,
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, IdAgrupacion As Integer) As DataSet
        'mreyes 28/Diciembre/2016   10:31 a.m.
        Try
            Return objDALTraspasosAutomaticos.usp_TraerArticulosMismaEstructura(Sucursal, Medida, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, IdAgrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraTraspasoCurvaIdeal(IdFolioB As Integer) As Boolean
        'mreyes 24/Febrero/2017 05:42 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_GeneraTraspasoCurvaIdeal(IdFolioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As String, ByVal idusuario As String, ByVal Liq As Integer) As Boolean
        'mreyes 25/08/2012 12:39 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_GeneraProTraspArticulo(Marca, Estilon, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, idusuario, Liq)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraAnaModArticulo(ByVal Opcion As Integer, ByVal Marca As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As String, ByVal idusuario As Integer) As Boolean
        'mreyes 16/Agosto/2016  04:25 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_GeneraAnaModArticulo(Opcion, Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerAnaModArticulo(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer, ByVal IdUsuario As Integer) As DataSet
        'mreyes 16/Agosto/2016  04:30 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerAnaModArticulo = objDALTraspasosAutomaticos.usp_TraerAnaModArticulo(Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerProTraspArticulo(ByVal Marca As String, ByVal Estilon As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
                 ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
                 ByVal idagrupacion As Integer, ByVal Propuesta As Integer) As DataSet
        'mreyes 21/Julio/2016   11:43 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerProTraspArticulo = objDALTraspasosAutomaticos.usp_TraerProTraspArticulo(Marca, Estilon, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, Propuesta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ProtraspDetNoaplica(ByVal Opcion As Integer, ByVal Serie As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Sucursal As Integer, ByVal Observa As String, ByVal IdUsuario As Integer) As Boolean

        'mreyes 18/Agosto/2016  05:39 p.m.


        Try

            usp_Captura_ProtraspDetNoaplica = objDALTraspasosAutomaticos.usp_Captura_ProtraspDetNoaplica(Opcion, Serie, Marca, Estilon, Medida, Sucursal, Observa, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_CurvaIdeal(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, Vigencia As Date, ByVal Medida As String,
                                           ByVal SucurOri As Integer, Frecuencia As String, Dia As String, MinimoPares As Integer, ByVal Ctd As Integer, ByVal IdUsuario As Integer) As Boolean

        'mreyes 15/Enero/2019   06:16 p.m.


        Try

            usp_Captura_CurvaIdeal = objDALTraspasosAutomaticos.usp_Captura_CurvaIdeal(Opcion, Marca, Estilon, Vigencia, Medida, SucurOri, Frecuencia, Dia, MinimoPares, Ctd, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ProtraspPropuesto(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal SucurOri As Integer, ByVal SucurDes As Integer, ByVal Ctd As Integer, ByVal IdUsuario As Integer) As Boolean

        'mreyes 25/Julio/2016   01:27 p.m.


        Try

            usp_Captura_ProtraspPropuesto = objDALTraspasosAutomaticos.usp_Captura_ProtraspPropuesto(Opcion, Marca, Estilon, Medida, SucurOri, SucurDes, Ctd, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_NegBodega(ByVal Sucursal As String, ByVal Nota As String, ByVal Fecha As Date, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal IdUsuario As Integer, ByVal Vendedor As Integer) As Boolean

        'mreyes 29/Diciembre/2016   12:05 p.m.


        Try

            usp_Captura_NegBodega = objDALTraspasosAutomaticos.usp_Captura_NegBodega(Sucursal, Nota, Fecha, Marca, Estilon, Medida, IdUsuario, Vendedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_TmpMuestrasDet(Opcion As Integer, ByVal Marca As String, ByVal Estilof As String, IdUsuario As Integer) As Boolean

        'mreyes 22/Septiembre/2017  05:18 p.m.


        Try

            usp_Captura_TmpMuestrasDet = objDALTraspasosAutomaticos.usp_Captura_TmpMuestrasDet(Opcion, Marca, Estilof, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_CancelaMuestrasdet(Opcion As Integer, ByVal Marca As String, ByVal Estilof As String, Observaciones As String, IdUsuario As Integer) As Boolean

        'mreyes 10/Octubre/2017 10:31 a.m.


        Try

            usp_CancelaMuestrasdet = objDALTraspasosAutomaticos.usp_CancelaMuestrasdet(Opcion, Marca, Estilof, Observaciones, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_MuestrasMarca(ByVal opcion As Integer, ByVal marcaB As String, NombreB As String, Raz_SocB As String, VendedorB As String, TarjetaB As Byte(), ComentariosB As String, IdUsuarioB As Integer) As Boolean
        'mreyes 06/Septiembre/2017  10:37 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_Captura_MuestrasMarca(opcion, marcaB, NombreB, Raz_SocB, VendedorB, TarjetaB, ComentariosB, IdUsuarioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMuestrasMarca(ByVal opcion As Integer, ByVal marcaB As String, NombreB As String, Raz_SocB As String, VendedorB As String, TarjetaB As Byte(), ComentariosB As String, IdUsuarioB As Integer) As DataSet
        'mreyes 07/Septiembre/2017  12:39 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_PpalMuestrasMarca(opcion, marcaB, NombreB, Raz_SocB, VendedorB, TarjetaB, ComentariosB, IdUsuarioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Muestras(ByVal opcion As Integer, ByVal idmuestraB As Integer, ByVal marcaB As String, ByVal Fechab As Date, EstatusB As String, Proveedorb As String, Dsctob As Integer, PlazoB As Integer, RemisionB As Integer, IdUsuarioB As Integer, IdUsuarioCancelaB As Integer, IdUsuaurioAutorizaB As Integer) As Boolean
        'mreyes 06/Septiembre/2017  10:04 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_Captura_Muestras(opcion, idmuestraB, marcaB, Fechab, EstatusB, Proveedorb, Dsctob, PlazoB, RemisionB, IdUsuarioB, IdUsuarioCancelaB, IdUsuaurioAutorizaB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PedidoTmp(ByVal opcion As Integer, ByVal marcaB As String, Estilof As String, ByVal EntregaAnt As String, EntregaNvo As String, Medida As String, IdSucursal As Integer, Ctd As Integer) As Boolean
        'mreyes 18/Octubre/2017     12:23 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_Captura_PedidoTmp(opcion, marcaB, Estilof, EntregaAnt, EntregaNvo, Medida, IdSucursal, Ctd)
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
        preciolista As Decimal,
        ByVal costo As Decimal, ByVal precio As Decimal, IMAGEN As Byte(),
                                                ByVal idusuario As Integer) As Boolean
        'mreyes 09/Agosto/2017  01:02 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_Captura_Muestrasdet(opcion, idmuestra, marcaB, estilof, descrip, iddivisiones, division, iddepto, depto, idfamilia, familia, idlinea, linea, idl1, l1, idl2, l2, idl3, l3, idl4, l4, idl5, l5, idl6, l6, intervalo, medini, medfin, preciolista, costo, precio, IMAGEN, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIdMuestras() As DataSet
        'mreyes 06/Septiembre/2017  09:57 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_TraerIdMuestras()
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
        'mreyes 09/Agosto/2017  01:20 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_PpalMuestrasdet(opcion, idmuestra, Estatus, marcaB, estilof, descrip, iddivisiones, division, iddepto, depto, idfamilia, familia, idlinea, linea, idl1, l1, idl2, l2, idl3, l3, idl4, l4, idl5, l5, idl6, l6)
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
                                            idl6 As String,
                                    FechaReciboIni As Date, FechaReciboFin As Date,
                                    TodosCurva As Integer, TodosVencido As Integer,
                                    Dias As Integer, Existencia As Integer) As DataSet
        'mreyes 15/Enero/2019   09:40 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_PpalBasicos(opcion, idmuestra, Estatus, marcaB, estilof, descrip, iddivisiones, division, iddepto, depto, idfamilia, familia, idlinea, linea, idl1, idl2, idl3, idl4, idl5, idl6, FechaReciboIni, FechaReciboFin, TodosCurva, TodosVencido, Dias, Existencia)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProveedorMuestras(ByVal marcaB As String,
                                                ByVal estilof As String
                                               ) As DataSet
        'mreyes 24/Octubre/2017 10:11 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_TraerProveedorMuestras(marcaB, estilof)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCostosPreciosMuestrasDet(ByVal opcion As Integer, ByVal marcaB As String,
                                                ByVal estilof As String
                                                  ) As DataSet
        'mreyes 03/Octubre/2017 11:55 a.m.

        'Validate group data
        Try

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_TraerCostosPreciosMuestrasDet(opcion, marcaB, estilof)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PedBodega(ByVal Sucursal As String, ByVal Nota As String, ByVal Fecha As Date, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal IdUsuario As Integer, ByVal Vendedor As Integer, ByVal Propuesta As Integer) As Boolean

        'mreyes 29/Diciembre/2016   12:33 p.m.


        Try

            usp_Captura_PedBodega = objDALTraspasosAutomaticos.usp_Captura_PedBodega(Sucursal, Nota, Fecha, Marca, Estilon, Medida, IdUsuario, Vendedor, Propuesta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_MatchPropuestaTraspaso() As Boolean

        'mreyes 02/Noviembre/2016   05:32 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_MatchPropuestaTraspaso()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraPeticionTraspaso(ByVal Marca As String, ByVal iddivisiones As Integer, ByVal iddepto As Integer, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer, ByVal idusuario As Integer) As Boolean

        'mreyes 29/Julio/2016   11:58 a.m.
        Try
            Return objDALTraspasosAutomaticos.usp_GeneraPeticionTraspaso(Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion, idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    ' INICIA, LIQUIDACIÓN  AUTOMÁTICA ..
    Public Function usp_PpalLiqAutomatica(ByVal Marca As String, ByVal iddivisiones As String, ByVal iddepto As String, ByVal idfamilia As String, ByVal idlinea As String, _
             ByVal idl1 As String, ByVal idl2 As String, ByVal idl3 As String, ByVal idl4 As String, ByVal idl5 As String, ByVal idl6 As String, _
             ByVal idagrupacion As Integer) As DataSet
        'mreyes 08/Septiembre/2016  01:28 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalLiqAutomatica = objDALTraspasosAutomaticos.usp_PpalLiqAutomatica(Marca, iddivisiones, iddepto, idfamilia, idlinea, idl1, idl2, idl3, idl4, idl5, idl6, idagrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalLiqAutomaticaTdas(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Fecha As Date) As DataSet
        'mreyes 23/Septiembre/2016  10:52 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalLiqAutomaticaTdas = objDALTraspasosAutomaticos.usp_PpalLiqAutomaticaTdas(Opcion, Sucursal, Fecha)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_GeneraLiquidacion(ByVal FechIni As Date, ByVal FechFin As Date, ByVal idusuario As Integer, ByVal Usuario As String) As Boolean

        'mreyes 10/Septiembre/2016  12:41 p.m.

        Try
            Return objDALTraspasosAutomaticos.usp_GeneraLiquidacion(FechIni, FechFin, idusuario, Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraLiqAutomatica(ByVal idusuario As Integer) As Boolean

        'mreyes 19/Septiembre/2016  04:16 p.m.


        Try
            Return objDALTraspasosAutomaticos.usp_GeneraLiqAutomatica(idusuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Elimina_ProTraspDetNoAplica(ByVal Serie As String) As Boolean

        'mreyes 25/Octubre/2016  04:17 p.m.

        Try
            Return objDALTraspasosAutomaticos.usp_Elimina_ProTraspDetNoAplica(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Elimina_LiqAutomatica(ByVal Marca As String, ByVal Estilon As String) As Boolean

        'mreyes 12/Septiembre/2016  10:22 a.m.

        Try
            Return objDALTraspasosAutomaticos.usp_Elimina_LiqAutomatica(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_LiqAutomatica(ByVal Opcion As Integer, ByVal Marca As String, ByVal Estilon As String, ByVal Regaladn As Integer, ByVal Porc As Integer, ByVal Contado As Integer, ByVal Credito As Integer, ByVal Tipo As String) As Boolean

        'mreyes 12/Septiembre/2016  10:37 a.m.

        Try
            Return objDALTraspasosAutomaticos.usp_Captura_LiqAutomatica(Opcion, Marca, Estilon, Regaladn, Porc, Contado, Credito, tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPedSinVenta(ByVal fechaini As String, ByVal fechafin As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, Idagrupacion As Integer) As DataSet
        'mreyes 19/Abril/2017   01:36 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalPedSinVenta(fechaini, fechafin, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, Idagrupacion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalTraspasosRecyEnv(ByVal fechaini As String, ByVal fechafin As String) As DataSet
        'Manuel vazquez, paola Gonzalez - 30/Enero/2017 - 01:20 pm
        Try
            Return objDALTraspasosAutomaticos.usp_PpalTraspasosRecyEnv(fechaini, fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoProveeBita(ByVal Opcion As Integer, ByVal proveedorB As String, ByVal marcaB As String, ByVal fechaB As String, comentarioB As String, idusuarioB As Integer) As DataSet
        'mreyes 11/Junio/2012 04:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALTraspasosAutomaticos.usp_PpalCatalogoProveeBita(Opcion, proveedorB, marcaB, fechaB, comentarioB, idusuarioB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalParesUnicos(ByVal fechaini1 As String, ByVal fechafin1 As String, ByVal fechaini As String, ByVal fechafin As String) As DataSet
        'mreyes 14/Mayo/2018    01:30 p.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalParesUnicos(fechaini1, fechafin1, fechaini, fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalDet_Serie(Serie As String) As DataSet
        'mreyes 09/Febrero/2019 10:19 a.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalDet_Serie(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalLineaL1Existencia(Sucursal As String, Division As String, Linea As String, L1 As String, L2 As String,
                                              L3 As String, L4 As String, L5 As String, L6 As String, Marca As String, Modelo As String, ExiIni As Integer, ExiFin As Integer, FechaIni As Date, FechaFin As Date) As DataSet
        'mreyes 19/Febrero/2019 10:49 a.m.
        Try
            Return objDALTraspasosAutomaticos.usp_PpalLineaL1Existencia(Sucursal, Division, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, ExiIni, ExiFin, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
