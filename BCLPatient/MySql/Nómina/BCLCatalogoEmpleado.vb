Public Class BCLCatalogoEmpleado
    'mreyes 11/Junio/2012 01:25 p.m.

    Implements IDisposable
    Private objDALCatalogoEmpleado As DAL.DALCatalogoEmpleado
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoEmpleado = New DAL.DALCatalogoEmpleado(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoEmpleado.Dispose()
            objDALCatalogoEmpleado = Nothing
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

    Public Function usp_Captura_Horario(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 20/Abril/2015   05:31 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoEmpleado.usp_Captura_Horario(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Empleado(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 11/Junio/2012 04:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoEmpleado.usp_Captura_Empleado(Opcion, Section)
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
            usp_TraerNomEmpleadoCedis = objDALCatalogoEmpleado.usp_TraerNomEmpleadoCedis(idEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal iddepto As Integer) As DataSet
        'mreyes 11/Junio/2012 01:26
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleado = objDALCatalogoEmpleado.usp_TraerNomEmpleado(idEmpleado, ApPaterno, apMaterno, Nombre, Estatus, iddepto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNomEmpleadosuc(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal iddepto As Integer, ByVal sucursal As String) As DataSet
        'mreyes 11/Junio/2012 01:26
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleadosuc = objDALCatalogoEmpleado.usp_TraerNomEmpleadosuc(idEmpleado, ApPaterno, apMaterno, Nombre, Estatus, iddepto, sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerHorarioEmpleado(ByVal idEmpleado As Integer) As DataSet
        'mreyes 19/Abril/2015   01:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerHorarioEmpleado = objDALCatalogoEmpleado.usp_TraerHorarioEmpleado(idEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerVendedor(ByVal idEmpleado As Integer) As DataSet
        'mreyes 18/Agosto/2012 01:07 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerVendedor = objDALCatalogoEmpleado.usp_TraerVendedor(idEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClaveEmpleado(ByVal Sucursal As String) As DataSet
        'mreyes 19/Junio/2012 05:01 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerClaveEmpleado = objDALCatalogoEmpleado.usp_TraerClaveEmpleado(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEmpleado = objDALCatalogoEmpleado.usp_TraerEmpleado(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCorreoNomina(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCorreoNomina = objDALCatalogoEmpleado.usp_TraerCorreoNomina(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUsuarioNomina(ByVal Password As String) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerUsuarioNomina = objDALCatalogoEmpleado.usp_TraerUsuarioNomina(Password)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoEmpleado(ByVal idEmpleado As Integer, ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, _
                                                ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, _
                                                ByVal BajaIni As Date, ByVal BajaFin As Date, ByVal NacimIni As Date, ByVal NacimFin As Date) As DataSet
        'mreyes 11/Junio/2012 11:19 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoEmpleado = objDALCatalogoEmpleado.usp_PpalCatalogoEmpleado(idEmpleado, Sucursal, IdDepto, IdPuesto, Estatus, InicioIni, InicioFin, BajaIni, BajaFin, NacimIni, NacimFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalCatalogoCajero() As DataSet
        'mreyes 26/Octubre/2016 11:47 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoCajero = objDALCatalogoEmpleado.usp_PpalCatalogoCajero()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Cajero(ByVal Cajero As String, ByVal SucNueva As String) As Boolean

        Try

            usp_Captura_Cajero = objDALCatalogoEmpleado.usp_Captura_Cajero(Cajero, SucNueva)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
