Public Class BCLNomina
    'mreyes 30/Junio/2012 10:35 a.m.

    Implements IDisposable
    Private objDALNomina As DAL.DALNomina
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALNomina = New DAL.DALNomina(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALNomina.Dispose()
            objDALNomina = Nothing
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




    Public Function usp_TraerPercdeduc(ByVal idPeriodo As String, ByVal tipoNom As String, ByVal idPercdeduc As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPercdeduc = objDALNomina.usp_TraerPercdeduc(idPeriodo, tipoNom, idPercdeduc)
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
            Return objDALNomina.usp_Captura_Empleado(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalNominaPercdeduc(ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                    ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'miguel perez, tony garcia 29/Agosto/2012 10:02 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalNominaPercdeduc = objDALNomina.usp_PpalNominaPercdeduc(IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_NominaDet(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 19/Julio/2012 10:14 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALNomina.usp_Captura_NominaDet(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminarNomina(ByVal Opcion As Integer, ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer) As Boolean
        'mreyes 24/Agosto/2012 11:28 p.m.
        Try
            'Call the data component to delete the group
            Return objDALNomina.usp_EliminarNomina(Opcion, IdPeriodo, TipoNom, Sucursal, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_GeneraNomina(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal Usuario As String) As Boolean
        'mreyes 12/Septiembre/2012 10:37 p.m.
        Try
            'Call the data component to delete the group
            Return objDALNomina.usp_GeneraNomina(IdPeriodo, TipoNom, Sucursal, IdEmpleado, Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminarNominaDet(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer, ByVal IdPercDeduc As Integer) As Boolean
        'mreyes 24/Agosto/2012 11:28 p.m.
        Try
            'Call the data component to delete the group
            Return objDALNomina.usp_EliminarNominaDet(IdPeriodo, TipoNom, IdEmpleado, IdPercDeduc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CaculoNominaFiscal(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal FechaIni As Date, ByVal FechaFin As Date, _
                                                                     ByVal Sucursal As String, ByVal Idempleado As Integer, ByVal Usuario As String, ByVal ComEmb As Decimal) As Boolean
        'mreyes 25/08/2012 12:39 p.m.
        Try
            'Call the data component to delete the group
            Return objDALNomina.usp_CaculoNominaFiscal(IdPeriodo, TipoNom, FechaIni, FechaFin, Sucursal, Idempleado, Usuario, comemb)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_CaculoAguinaldo(ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
                                                                 ByVal Sucursal As String, ByVal Idempleado As Integer, ByVal Usuario As String) As Boolean
        'mreyes 10/Diciembre/2012 01:42 p.m.
        Try
            'Call the data component to delete the group
            Return objDALNomina.usp_CaculoAguinaldo(IdPeriodo, TipoNom, Sucursal, Idempleado, Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Periodo(ByVal Opcion As Integer, ByVal Idperiodo As Integer, _
                                        ByVal IdFrecPago As Integer, ByVal FechaIni As Date, _
                                            ByVal FechaFin As Date, ByVal Estatus As String, _
                                            ByVal Usuario As String, ByVal usumodif As String, ByVal fummodif As DateTime) As Boolean
        'mreyes 13/Julio/2012 10:25 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALNomina.usp_Captura_Periodo(Opcion, Idperiodo, IdFrecPago, FechaIni, FechaFin, Estatus, Usuario, usumodif, fummodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_MatchTimbrado(ByVal Section As DataSet) As Boolean
        'mreyes 20/Enero/2015   05:59 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALNomina.usp_Captura_MatchTimbrado(Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Venta(ByVal Section As DataSet) As Boolean
        'mreyes 18/Agosto/2012 01:31 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALNomina.usp_Captura_Venta(Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_VentaCajero(ByVal Section As DataSet) As Boolean
        'mreyes 12/Junio/2018 05:01 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALNomina.usp_Captura_VentaCajero(Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_DiaFestivo(ByVal Opcion As Integer, ByVal IdDiaFestivo As Integer, ByVal Fecha As Date, ByVal Descrip As String, _
                                            ByVal Usuario As String) As Boolean
        'mreyes 13/Julio/2012 10:25 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALNomina.usp_Captura_DiaFestivo(Opcion, IdDiaFestivo, Fecha, Descrip, Usuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaPeriodo(ByVal IdFrecPago As Integer) As DataSet
        'mreyes 16/Julio/2012 10:24 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerFechaPeriodo = objDALNomina.usp_TraerFechaPeriodo(IdFrecPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTotalPercDeduc(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As String) As DataSet
        'mreyes 11/Septiembre/2012 04:09 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerTotalPercDeduc = objDALNomina.usp_TraerTotalPercDeduc(IdPeriodo, TipoNom, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CalculaSubsidio(ByVal IdFrecPago As Integer, ByVal sDiario As Decimal, ByVal Subsidio As Decimal) As DataSet
        'mreyes 19/Julio/2012 01:29 p.m.
        Try
            'Call the data component to get all groups
            usp_CalculaSubsidio = objDALNomina.usp_CalculaSubsidio(IdFrecPago, sDiario, Subsidio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerCalculaSubsidio(ByVal IdFrecPago As Integer, ByVal sDiario As Decimal) As DataSet
        'mreyes 03/Agosto/2012 04:53 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCalculaSubsidio = objDALNomina.usp_TraerCalculaSubsidio(IdFrecPago, sDiario)
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

            objDataColumn = New DataColumn("idfrecpago", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("jornada", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("entrada", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comida", Type.GetType("System.Int16"))
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




        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomSucursal(ByVal Sucursal As String) As DataSet
        'mreyes 09/Septiembre/2012 10:34 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerNomSucursal = objDALNomina.usp_TraerNomSucursal(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String, ByVal iddepto As Integer) As DataSet
        'mreyes 11/Junio/2012 01:26
        Try
            'Call the data component to get all groups
            usp_TraerNomEmpleado = objDALNomina.usp_TraerNomEmpleado(idEmpleado, ApPaterno, apMaterno, Nombre, Estatus, iddepto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerClaveEmpleado(ByVal Sucursal As String) As DataSet
        'mreyes 19/Junio/2012 05:01 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerClaveEmpleado = objDALNomina.usp_TraerClaveEmpleado(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIDEmpleado(ByVal Sucursal As String, ByVal Vendedor As String) As DataSet
        'mreyes 18/AGosto/2012 02:24 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerIDEmpleado = objDALNomina.usp_TraerIDEmpleado(Sucursal, Vendedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCajero(ByVal Cajero As String) As DataSet
        'mreyes 14/Junio/2018   04:14 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCajero = objDALNomina.usp_TraerCajero(Cajero)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerEncargadoTienda(ByVal Sucursal As String) As DataSet
        'mreyes 18/AGosto/2012 02:24 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEncargadoTienda = objDALNomina.usp_TraerEncargadoTienda(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ConsecutivoEmp(ByVal Sucursal As String) As DataSet
        'mreyes 22/Julio/2012 01:02 p.m.
        Try
            'Call the data component to get all groups
            usp_ConsecutivoEmp = objDALNomina.usp_ConsecutivoEmp(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEmpleado = objDALNomina.usp_TraerEmpleado(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNominaBono(ByVal Opcion As Integer, ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                            ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'mreyes 15/Abril/2015   12:50 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalNominaBono = objDALNomina.usp_PpalNominaBono(Opcion, IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNominaBanBajio(ByVal Opcion As Integer, ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal BanBajio As Integer) As DataSet
        'mreyes 15/Julio/2015   10:23 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalNominaBanBajio = objDALNomina.usp_PpalNominaBanBajio(Opcion, IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto, BanBajio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalNominaFiscal(ByVal Opcion As Integer, ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal BanBajio As Integer) As DataSet
        'mreyes 05/Noviembre/2014   07:29 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalNominaFiscal = objDALNomina.usp_PpalNominaFiscal(Opcion, IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto, BanBajio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNomina(ByVal Opcion As Integer, ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                    ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'mreyes 30/Junio/2012 10:42 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalNomina = objDALNomina.usp_PpalNomina(Opcion, IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalAguinaldo(ByVal Opcion As Integer, ByVal IdPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal Dis As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 10/Diciembre/2012 02:27 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalAguinaldo = objDALNomina.usp_PpalAguinaldo(Opcion, IdPeriodo, TipoNom, IdEmpleado, Sucursal, IdDepto, IdPuesto, Dis, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoDiaFestivo() As DataSet
        'mreyes 30/Junio/2012 10:42 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoDiaFestivo = objDALNomina.usp_PpalCatalogoDiaFestivo()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ReciboNominaDet(ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer) As DataSet

        'mreyes 11/Julio/2012 05:56 p.m.

        Try
            'Call the data component to get all groups
            usp_ReciboNominaDet = objDALNomina.usp_ReciboNominaDet(IdPeriodo, TipoNom, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNominaDet(ByVal Accion As Integer, ByVal IdPeriodo As Integer, ByVal TipoNom As String, ByVal IdEmpleado As Integer, ByVal Naturaleza As String, ByVal IdRepetitivo As Integer, ByVal IdPercdeduc As Integer) As DataSet
        'mreyes 18/Julio/2012 10:49 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerNominaDet = objDALNomina.usp_TraerNominaDet(Accion, IdPeriodo, TipoNom, IdEmpleado, Naturaleza, IdRepetitivo, IdPercdeduc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_EliminaVenta(ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As Boolean
        'mreyes 18/Agosto/2012 01:45 p.m.
        Try
            'Call the data component to delete the group
            Return objDALNomina.usp_EliminaVenta(Sucursal, IdEmpleado, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerVentasNetas(ByVal Sucursal As String, ByVal Vendedor As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 18/Agosto/2012 10:40 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerVentasNetas = objDALNomina.usp_TraerVentasNetas(Sucursal, Vendedor, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerVentasNetasCajero(ByVal Sucursal As String, ByVal Vendedor As String, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 14/Junio/2018   04:32 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerVentasNetasCajero = objDALNomina.usp_TraerVentasNetasCajero(Sucursal, Vendedor, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_NominaDet() As DataSet
        'mreyes 19/Julio/2012 10:08 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_NominaDet = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_NominaDet.Tables.Add("NominaDet")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            objDataColumn = New DataColumn("idperiodo", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tiponom", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idpercdeduc", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idrepetitivo", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("unidades", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impgrav", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impexento", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usumodif", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Venta() As DataSet
        'mreyes 18/Agosto/2012 01:10 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Venta = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Venta.Tables.Add("Venta")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("vendedor", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("tipoart", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pares", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impvta", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_VentaCajero() As DataSet
        'mreyes 14/Junio/2018   05:01 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_VentaCajero = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_VentaCajero.Tables.Add("ventacajero")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cajero", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("tipoart", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pares", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impvta", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_MatchTimbrado() As DataSet
        'mreyes 20/Enero/2015   04:54 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_MatchTimbrado = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_MatchTimbrado.Tables.Add("MatchTimbrado")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("folio", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rfc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("folioerp", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
       

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPagoNomina(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPagoNomina = objDALNomina.usp_TraerPagoNomina(idPeriodo, tipoNom)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNominaADispersar(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerNominaADispersar = objDALNomina.usp_TraerNominaADispersar(idPeriodo, tipoNom)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoPersonalIng(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPagoPersonalIng = objDALNomina.usp_TraerPagoPersonalIng(idPeriodo, tipoNom)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoPersonalSinTarjeta(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPagoPersonalSinTarjeta = objDALNomina.usp_TraerPagoPersonalSinTarjeta(idPeriodo, tipoNom)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPersonalIng(ByVal idPeriodo As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerPersonalIng = objDALNomina.usp_TraerPersonalIng(idPeriodo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerBonoSucursal(ByVal idPeriodo As String, ByVal Sucursal As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerBonoSucursal = objDALNomina.usp_TraerBonoSucursal(idPeriodo, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPersSinTarjNom(ByVal idPeriodo As String, ByVal tipoNom As String) As DataSet
        'miguel perez 20/Septiembre/2012 05:09 p.m.

        Try
            'Call the data component to get all groups
            usp_TraerPersSinTarjNom = objDALNomina.usp_TraerPersSinTarjNom(idPeriodo, tipoNom)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
