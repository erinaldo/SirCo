Public Class BCLBitacora
    'mreyes 26/Febrero/2012 10:22 p.m.

    Implements IDisposable
    Private objDALBitacora As DAL.DALBitacora
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALBitacora = New DAL.DALBitacora(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALBitacora.Dispose()
            objDALBitacora = Nothing
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




    Public Function usp_PpalBitacora(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                           ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As String, ByVal IdDepto As String, ByVal IdFamilia As String, ByVal IdLinea As String, _
                                          ByVal IdL1 As String, ByVal IdL2 As String, ByVal IdL3 As String, ByVal IdL4 As String, ByVal IdL5 As String, _
                                          ByVal IdL6 As String, ByVal Proveedor As String, ByVal Status As String, _
                                           ByVal FechaIni As String, ByVal Fechafin As String, ByVal EntregaIni As String, ByVal EntregaFin As String) As DataSet
        'mreyes 26/Febrero/2012 10:30 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalBitacora = objDALBitacora.usp_PpalBitacora(Accion, Opcion, Sucursal, OrdeComIni, OrdeComFin, Marca, Modelo, EstiloF, _
                                                                   IdDivision, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, _
                                                                   Proveedor, Status, FechaIni, Fechafin, EntregaIni, EntregaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalBitacoraRecibida(ByVal Accion As Integer, ByVal Opcion As Integer, ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                            ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As Integer, ByVal IdDepto As Integer, ByVal IdFamilia As Integer, ByVal IdLinea As Integer, _
                                            ByVal IdL1 As Integer, ByVal IdL2 As Integer, ByVal IdL3 As Integer, ByVal IdL4 As Integer, ByVal IdL5 As Integer, _
                                            ByVal IdL6 As Integer, ByVal Proveedor As String, ByVal Status As String, _
                                            ByVal FechaIni As String, ByVal Fechafin As String, ByVal EntregaIni As String, ByVal EntregaFin As String) As DataSet
        'mreyes 26/Febrero/2012 10:30 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalBitacoraRecibida = objDALBitacora.usp_PpalBitacoraRecibida(Accion, Opcion, Sucursal, OrdeComIni, OrdeComFin, Marca, Modelo, EstiloF, _
                                                                   IdDivision, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, _
                                                                   Proveedor, Status, FechaIni, Fechafin, EntregaIni, EntregaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


  
 



    Public Function usp_Captura_SegBit(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 29/Febrero/2012 12:11 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALBitacora.usp_Captura_SegBit(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_SigBit() As DataSet
        'mreyes 29/Febrero/2012 10:46 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_SigBit = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_SigBit.Tables.Add("SigBit")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("ordecomp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("atiende", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("realiza", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("motivo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comentarios", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 150
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSegBit(ByVal Id_SegBit As Integer, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String) As DataSet
        'mreyes 17/Febrero/2012 11:10 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerSegBit = objDALBitacora.usp_TraerSegBit(Id_SegBit, OrdeComp, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaEntrega(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'mreyes 07/Marzo/2012 12:31 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFechaEntrega = objDALBitacora.usp_TraerFechaEntrega(sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerEstiloF(ByVal Marca As String, ByVal Estilon As String) As DataSet
        'mreyes 07/Marzo/2012 01:07 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerEstiloF = objDALBitacora.usp_TraerEstiloF(Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSeguimientos(ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                     ByVal Estilon As String, ByVal EstiloF As String, _
                                     ByVal Proveedor As String, _
                                     ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
        'mreyes 07/Marzo/2012 10:31 a.m.
        Try
            'Call the data component to get all groups
            usp_PpalSeguimientos = objDALBitacora.usp_PpalSeguimientos(Sucursal, OrdeComIni, OrdeComFin, Marca, Estilon, EstiloF, _
                                                                      Proveedor, FechaIni, _
                                                                    Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
