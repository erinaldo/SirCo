Public Class BCLCatalogoTarjetas

    Implements IDisposable
    Private objDALCatalogoTarjetas As DAL.DALCatalogoTarjetas
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoTarjetas = New DAL.DALCatalogoTarjetas(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoTarjetas.Dispose()
            objDALCatalogoTarjetas = Nothing
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

    Public Function usp_PpalCatalogoTarjetas() As DataSet
        'mreyes 17/Mayo/2012 05:31 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoTarjetas = objDALCatalogoTarjetas.usp_PpalCatalogoTarjetas()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoBancosFactoraje() As DataSet
        'mreyes 31/Octubre/2014 04:10 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoBancosFactoraje = objDALCatalogoTarjetas.usp_PpalCatalogoBancosFactoraje()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPagoTarjetas() As DataSet
        'mreyes 28/Mayo/2012 09:48 a.m.

        Try
            'Call the data component to get all groups
            usp_TraerPagoTarjetas = objDALCatalogoTarjetas.usp_TraerPagoTarjetas()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Tarjetas() As DataSet
        'mreyes 17/Mayo/2012 06:09 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Tarjetas = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Tarjetas.Tables.Add("tarjetas")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("banco", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("titular", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("notarjeta", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("limcred", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("saldo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechae", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fechav", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            'Type.GetType("System.Int16"))

            objDataColumn = New DataColumn("diacorte", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diapago", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("prioridad", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tarjeta_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Tarjetas_Det() As DataSet
        'mreyes 18/Mayo/2012 10:52 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Tarjetas_Det = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Tarjetas_Det.Tables.Add("tarjetas_det")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("tarjeta_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("meses", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comision", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Tarjetas(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 17/Mayo/2012 06:22 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoTarjetas.usp_Captura_Tarjetas(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Tarjetas_Det(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 18/Mayo/2012 10:56 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoTarjetas.usp_Captura_Tarjetas_Det(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTarjetas(ByVal Tarjeta_Id As Integer, ByVal Banco As String) As DataSet
        'mreyes 18/Mayo/2012 10:13 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerTarjetas = objDALCatalogoTarjetas.usp_TraerTarjetas(Tarjeta_Id, Banco)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerTarjetas_Det(ByVal Tarjeta_Id As Integer) As DataSet
        'mreyes 18/Mayo/2012 10:51 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerTarjetas_Det = objDALCatalogoTarjetas.usp_TraerTarjetas_Det(Tarjeta_Id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
