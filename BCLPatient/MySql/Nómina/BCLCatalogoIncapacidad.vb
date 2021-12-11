Public Class BCLCatalogoIncapacidad
    'mreyes 07/Agosto/2012 11:01 a.m.

    Implements IDisposable
    Private objDALCatalogoIncapacidad As DAL.DALCatalogoIncapacidad
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoIncapacidad = New DAL.DALCatalogoIncapacidad(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoIncapacidad.Dispose()
            objDALCatalogoIncapacidad = Nothing
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




    Public Function usp_Captura_Incapacidad(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 08/Agosto/2012 11:01 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoIncapacidad.usp_Captura_Incapacidad(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function Inserta_Incapacidad() As DataSet
        'mreyes 07/Agosto/2012 11:01 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Incapacidad = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Incapacidad.Tables.Add("Incapacidad")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("idincapacidad", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("riesgo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("dictamen", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("certificado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dias", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("caso", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripcion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 150
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
            'timestamp()
            objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)



            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_TraerIncapacidad(ByVal idIncapacidad As Integer) As DataSet
        'mreyes 07/Agosto/2012 05:47 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerIncapacidad = objDALCatalogoIncapacidad.usp_TraerIncapacidad(idIncapacidad)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoIncapacidad(ByVal idEmpleado As Integer, ByVal Sucursal As String, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, ByVal Tipo As String) As DataSet
        'mreyes 07/Agosto/2012 11:50 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoIncapacidad = objDALCatalogoIncapacidad.usp_PpalCatalogoIncapacidad(idEmpleado, Sucursal, Estatus, InicioIni, InicioFin, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



#End Region
End Class
