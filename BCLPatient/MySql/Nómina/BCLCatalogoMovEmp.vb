Public Class BCLCatalogoMovEmp
    ''Tony Garcia 04/Sept/2012 5:30 p.m.
    Implements IDisposable
    Private objDALCatalogoMovEmp As DAL.DALCatalogoMovEmp
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoMovEmp = New DAL.DALCatalogoMovEmp(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoMovEmp.Dispose()
            objDALCatalogoMovEmp = Nothing
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

    Public Function usp_Captura_MovEmp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia - 08/Septiembre/2012 - 09:42 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMovEmp.usp_Captura_MovEmp(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Actualiza_Emp() As DataSet
        'mreyes 18/Junio/2012 05:50 p.m.
        Try
            'Instantiate a new DataSet object
            Actualiza_Emp = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Actualiza_Emp.Tables.Add("empleado")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("clave", Type.GetType("System.String"))
            objDataColumn.MaxLength = 6
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

            objDataColumn = New DataColumn("bono", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
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

    Public Function Inserta_MovEmp() As DataSet
        'mreyes 18/Junio/2012 05:50 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_MovEmp = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_MovEmp.Tables.Add("movemp")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idmovemp", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechaact", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("baja", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idmotivo", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("vendedor", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("vendnuevo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucnueva", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comentario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 250
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fum", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usumodif", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iddepto", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("iddeptonuevo", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("idpuesto", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("idpuestonuevo", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 20/Junio/2012 12:32 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEmpleado = objDALCatalogoMovEmp.usp_TraerEmpleado(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerRepetitivoEmpleado(ByVal IdEmpleado As Integer) As DataSet
        'mreyes 10/Octubre/2014 11:11 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerRepetitivoEmpleado = objDALCatalogoMovEmp.usp_TraerRepetitivoEmpleado(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMotivoBaja() As DataSet
        'Tony Garcia - 05/Septiembre/2012 - 12:42 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMotivoBaja = objDALCatalogoMovEmp.usp_TraerMotivoBaja()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMovEmp(ByVal Opcion As Integer, ByVal IdEmpleado As Integer, ByVal Fecha As Date, ByVal Tipo As String) As DataSet
        'Tony Garcia - 10/Septiembre/2012 - 12:10 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMovEmp = objDALCatalogoMovEmp.usp_TraerMovEmp(Opcion, IdEmpleado, Fecha, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalMovEmp(ByVal IdMovEmp As Integer, ByVal Clave As String, ByVal IdEmpleado As Integer, ByVal Tipo As String, _
                                   ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Sucursal As String, ByVal IdPuesto As Integer, ByVal Estatus As String) As DataSet
        'miguel perez, tony garcia 31/Agosto/2012 01:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMovEmp.usp_PpalMovEmp(IdMovEmp, Clave, IdEmpleado, Tipo, FechaIni, FechaFin, Sucursal, IdPuesto, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_UpdateEmpleadoMov(ByVal Opcion As String, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMovEmp.usp_UpdateEmpleadoMov(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CancelarMovEmp(ByVal Tipo As String, ByVal IdEmpleado As Integer, ByVal IdMovEmp As Integer, _
                                       ByVal UsuMod As String, ByVal Fummodif As Date) As Boolean
        'Tony Garcia - 26/Sept/2012 - 5:35 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMovEmp.usp_CancelarMovEmp(Tipo, IdEmpleado, IdMovEmp, UsuMod, Fummodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
