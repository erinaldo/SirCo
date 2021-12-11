Public Class BCLCatalogoMarca

    Implements IDisposable
    Private objDALCatalogoMarca As DAL.DALCatalogoMarca
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoMarca = New DAL.DALCatalogoMarca(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoMarca.Dispose()
            objDALCatalogoMarca = Nothing
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

    Public Function usp_PpalCatalogoMarca(ByVal Marca As String, ByVal Estatus As String) As DataSet
        'mreyes 04/Mayo/2012 07:40 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoMarca = objDALCatalogoMarca.usp_PpalCatalogoMarca(Marca, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Marca() As DataSet
        'mreyes 05/Mayo/2012 09:29 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Marca = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Marca.Tables.Add("Marca")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descrip", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("factor", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("resmin", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_Marca(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Mayo/2012 09:32 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoMarca.usp_Captura_Marca(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_MarcaProvCosto(ByVal Opcion As Integer, ByVal Marca As String, ByVal Proveedor As String, _
                                     ByVal Costo As Decimal, ByVal IdUsuario As Integer) As Boolean
        'Tony Grcia - 12/Marzo/2013 - 11:33 a.m.

        'Call the data component to add the new group
        Return objDALCatalogoMarca.usp_Captura_MarcaProvCosto(Opcion, Marca, Proveedor, Costo, IdUsuario)
    End Function

    Public Function usp_Traer_MarcaProvCosto(ByVal Marca As String) As DataSet
        'Tony Garcia - 13/Marzo/2013 - 12:33 p.m.
        usp_Traer_MarcaProvCosto = objDALCatalogoMarca.usp_Traer_MarcaProvCosto(Marca)
    End Function

    Public Function usp_TraerEmpleadoCompras() As DataSet
        Try
            usp_TraerEmpleadoCompras = objDALCatalogoMarca.usp_TraerEmpleadoCompras()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_AsignarMarca(ByVal Marca As String, ByVal IdEmpleado As Integer) As Boolean
        Try
            Return objDALCatalogoMarca.usp_AsignarMarca(Marca, IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstatusMarca(ByVal Marca As String, ByVal Estatus As String) As Boolean

        Try
            Return objDALCatalogoMarca.usp_ActualizarEstatusMarca(Marca, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
