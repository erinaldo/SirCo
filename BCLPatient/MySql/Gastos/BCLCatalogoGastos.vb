Public Class BCLCatalogoGastos
    'mreyes 11/Junio/2012 11:17 a.m.

    Implements IDisposable
    Private objDALCatalogoGastos As DAL.DALCatalogoGastos

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoGastos = New DAL.DALCatalogoGastos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoGastos.Dispose()
            objDALCatalogoGastos = Nothing
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


    Public Function usp_Captura_Gastos(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 11/Junio/2012 11:19 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoGastos.usp_Captura_Gastos(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetGastos() As DataSet
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoGastos.usp_TraerDetGastos()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoFolioGastos() As DataSet
        'Tony Garcia - 26/Sept/2012 - 5:35 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoGastos.usp_TraerUltimoFolioGastos()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function Inserta_Gastos() As DataSet
        'mreyes 11/Junio/2012 11:19 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Gastos = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Gastos.Tables.Add("Gastos")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("folio", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cantidad", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idgasto", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("solicita", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("autoriza", Type.GetType("System.Int16"))
            'objDataColumn.AllowDBNull = False
            'objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comentarios", Type.GetType("System.String"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            'timestamp()
            objDataColumn = New DataColumn("fum", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("foliosuc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            'objDataColumn = New DataColumn("usumodif", Type.GetType("System.Int16"))
            'objDataTable.Columns.Add(objDataColumn)

            ''timestamp()
            'objDataColumn = New DataColumn("fummodif", Type.GetType("System.DateTime"))
            'objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerGastos(ByVal folio As Integer) As DataSet
        'mreyes 11/Junio/2012 12:28 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerGastos = objDALCatalogoGastos.usp_TraerGastos(folio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdFolioGasto(ByVal CveSucursal As String) As DataSet
        'mreyes 20/Enero/2012   11:30 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerIdFolioGasto = objDALCatalogoGastos.usp_TraerIdFolioGasto(CveSucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoGastos(ByVal folio As Integer, ByVal Sucursal As String, ByVal idgasto As Integer, ByVal cantidadini As Double, ByVal cantidadfin As Double, _
                                         ByVal Solicita As Integer, ByVal status As String, ByVal fechaIni As String, ByVal fechaFin As String, ByVal foliosucini As String, ByVal foliosucfin As String) As DataSet

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoGastos = objDALCatalogoGastos.usp_PpalCatalogoGastos(folio, Sucursal, idgasto, cantidadini, cantidadfin, Solicita, status, fechaIni, fechaFin, foliosucini, foliosucfin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarEstatusGastos(ByVal Opcion As Integer, ByVal Folio As Integer, ByVal Estatus As String, ByVal Usuario As Integer, _
                                                 ByVal Fummodif As DateTime) As Boolean
        'mreyes 11/Junio/2012 10:14 a.m.
        Try
            'Call the data component to add the new group
            Return objDALCatalogoGastos.usp_ActualizarEstatusGastos(Opcion, Folio, Estatus, Usuario, Fummodif)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
