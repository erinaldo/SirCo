Public Class BCLCatalogoRepetitivo
    'mreyes 11/Junio/2012 11:17 a.m.

    Implements IDisposable
    Private objDALCatalogoRepetitivo As DAL.DALCatalogoRepetitivo
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoRepetitivo = New DAL.DALCatalogoRepetitivo(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoRepetitivo.Dispose()
            objDALCatalogoRepetitivo = Nothing
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




    Public Function usp_Captura_Repetitivo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 11/Junio/2012 11:19 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoRepetitivo.usp_Captura_Repetitivo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function Inserta_Repetitivo() As DataSet
        'mreyes 11/Junio/2012 11:19 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Repetitivo = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Repetitivo.Tables.Add("Repetitivo")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("idrepetitivo", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idpercdeduc", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descrip", Type.GetType("System.String"))

            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("folio", Type.GetType("System.String"))
            objDataColumn.MaxLength = 12
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("importe", Type.GetType("System.Decimal"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cuota", Type.GetType("System.Decimal"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("saldo", Type.GetType("System.Decimal"))

            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("inicio", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))

            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idcuenta", Type.GetType("System.Int16"))

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

            objDataColumn = New DataColumn("observaciones", Type.GetType("System.String"))
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table
            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fin", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_TraerRepetitivo(ByVal idRepetitivo As Integer) As DataSet
        'mreyes 11/Junio/2012 12:28 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerRepetitivo = objDALCatalogoRepetitivo.usp_TraerRepetitivo(idRepetitivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoPreNomina(ByVal idEmpleado As Integer, ByVal idPercDeduc As Integer, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, ByVal Tienda As String, ByVal Sucursal As String) As DataSet
        'mreyes 21/Abril/2015   10:24 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoPreNomina = objDALCatalogoRepetitivo.usp_PpalCatalogoPreNomina(idEmpleado, idPercDeduc, Estatus, InicioIni, InicioFin, Tienda, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalCatalogoRepetitivo(ByVal idEmpleado As Integer, ByVal idPercDeduc As Integer, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, ByVal Tienda As String) As DataSet
        'mreyes 11/Junio/2012 11:19 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoRepetitivo = objDALCatalogoRepetitivo.usp_PpalCatalogoRepetitivo(idEmpleado, idPercDeduc, Estatus, InicioIni, InicioFin, Tienda)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



#End Region
End Class
