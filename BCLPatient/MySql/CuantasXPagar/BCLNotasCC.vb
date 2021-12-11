Public Class BCLNotasCC

    Implements IDisposable
    Private objDALNotasCC As DAL.DALNotasCC
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALNotasCC = New DAL.DALNotasCC(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALNotasCC.Dispose()
            objDALNotasCC = Nothing
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

    Public Function usp_TraerNotaCC(ByVal Opcion As Integer, ByVal IdFolioSuc As String, ByVal IdFolio As Integer, ByVal Tipo As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerNotaCC = objDALNotasCC.usp_TraerNotaCC(Opcion, IdFolioSuc, IdFolio, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Nota() As DataSet
        'Tony Garcia 26/Junio/2013 10:09 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Nota = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Nota.Tables.Add("notascc")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("folio", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idfoliosuc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cvesuc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("aplicada", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idmotivo", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("importe", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iva", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("imptotal", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descrip", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 150
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idusuario", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerUltFolioNotaCC(ByVal Tipo As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_TraerUltFolioNotaCC = objDALNotasCC.usp_TraerUltFolioNotaCC(Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNotasCC(ByVal Folio As Integer, ByVal IdFolioSucIni As String, ByVal IdFolioSucFin As String, _
                                    ByVal Estatus As String, ByVal Proveedor As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_PpalNotasCC = objDALNotasCC.usp_PpalNotasCC(Folio, IdFolioSucIni, IdFolioSucFin, Estatus, Proveedor, FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_NotaCC(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia 29/Junio/2013 11:23 a.m.
        Try
            Return objDALNotasCC.usp_Captura_NotaCC(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaEstatusNotaCC(ByVal IdFolio As Integer, ByVal Tipo As String, ByVal Estatus As String, _
                                              ByVal Aplicada As DateTime, ByVal IdMotivo As Integer) As Boolean
        'Tony Garcia 29/Junio/2013 11:23 a.m.
        Try
            Return objDALNotasCC.usp_ActualizaEstatusNotaCC(IdFolio, Tipo, Estatus, Aplicada, IdMotivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerUnMotivosRem(ByVal idmotivo As Integer) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_TraerUnMotivosRem = objDALNotasCC.usp_TraerUnMotivosRem(idmotivo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaFacturaNotaCC(ByVal IdFolioSuc As String, ByVal Tipo As String, ByVal Importe As Decimal, ByVal IdMotivo As Integer, _
                                              ByVal dsctopp As Integer, ByVal dscto01 As Integer, ByVal dscto02 As Integer, _
                                              ByVal dscto03 As Integer, ByVal dscto04 As Integer, ByVal dscto05 As Integer) As Boolean
        'Tony Garcia 11/Julio/2013 10:23 a.m.
        Try
            Return objDALNotasCC.usp_ActualizaFacturaNotaCC(IdFolioSuc, Tipo, Importe, IdMotivo, dsctopp, dscto01, dscto02, dscto03, dscto04, dscto05)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDevProvImporte(ByVal Sucursal As String, ByVal IdFolioSuc As String, ByVal DevoProv As String) As DataSet
        'Tony Garcia 17/Octubre/2013 10:00 a.m.
        Try
            usp_TraerDevProvImporte = objDALNotasCC.usp_TraerDevProvImporte(Sucursal, IdFolioSuc, DevoProv)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
