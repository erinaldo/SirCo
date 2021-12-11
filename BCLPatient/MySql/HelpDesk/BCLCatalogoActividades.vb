Public Class BCLCatalogoActividades
    ''Tony Garcia 13/Octubre/2012 - 12:00 p.m.
    Implements IDisposable
    Private objDALCatalogoActividades As DAL.DALCatalogoActividades
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoActividades = New DAL.DALCatalogoActividades(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoActividades.Dispose()
            objDALCatalogoActividades = Nothing
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

    Public Function usp_PpalActividadesEmp(ByVal IdActividad As Integer, ByVal IdReporta As Integer, ByVal IdAsignado As Integer, _
                                   ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Sucursal As String, ByVal IdPuesto As Integer, _
                                   ByVal Depto As String, ByVal Estatus As String) As DataSet
        'Tony Garcia - 15/Octubre/2012 - 10:05 a.m
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoActividades.usp_PpalActividadesEmp(IdActividad, IdReporta, IdAsignado, FechaIni, FechaFin, Sucursal, IdPuesto, Depto, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Actividad(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia - 13/Octubre/2012 - 05:42 p.m.
        Try
            'Validate group data 

            'Call the data component to add the new group
            Return objDALCatalogoActividades.usp_Captura_Actividad(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_ActividadDet(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia - 13/Octubre/2012 - 05:42 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoActividades.usp_Captura_ActividadDet(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoFolioAct() As DataSet
        'Tony Garcia - 26/Sept/2012 - 5:35 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoActividades.usp_TraerUltimoFolioAct()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Actividad() As DataSet
        'Tony Garcia - 13/Octubre/2012 05:50 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Actividad = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Actividad.Tables.Add("actividades")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idactividad", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iddepto", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("reporta", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("asignado", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechaalta", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechaproc", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechafin", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
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

    Public Function Inserta_ActividadDet() As DataSet
        'Tony Garcia - 13/Octubre/2012 06:00 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_ActividadDet = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_ActividadDet.Tables.Add("actividadesdet")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idactividad", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("reporta", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("asignado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripcion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 250
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("resultado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 250
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("satisfaccion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 250
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


    Public Function usp_TraerActividadEmp(ByVal IdActividad As Integer, ByVal Fecha As Date, ByVal Estatus As String) As DataSet
        'Tony Garcia - 15/Octubre/2012 - 01:10 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerActividadEmp = objDALCatalogoActividades.usp_TraerActividadEmp(IdActividad, Fecha, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstatusAct(ByVal Opcion As String, ByVal IdActividad As Integer, ByVal Estatus As String, _
                                            ByVal FechaProc As Date, ByVal FechaFin As Date, ByVal UsuMod As String, ByVal Fummod As String) As Boolean
        'Tony Garcia - 15/Octubre/2012 - 04:10 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoActividades.usp_ActualizarEstatusAct(Opcion, IdActividad, Estatus, FechaProc, FechaFin, UsuMod, Fummod)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomDepto(ByVal Clave As String) As DataSet
        'Tony Garcia - 23/Octubre/2012 - 05:40 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerNomDepto = objDALCatalogoActividades.usp_TraerNomDepto(Clave)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
