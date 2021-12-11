Public Class BCLAparador
    'mreyes 24/Abril/2015   10:11 a.m.
    Implements IDisposable
    Private objDALAparador As DAL.DALAparador
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALAparador = New DAL.DALAparador(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALAparador.Dispose()
            objDALAparador = Nothing
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

#Region " Public Patient Functions "
    Public Function usp_PpalDineroElectronico(ByVal Cuenta As String) As DataSet
        'mreyes 10/Noviembre/2016   11:01 a.m.
        Try
            usp_PpalDineroElectronico = objDALAparador.usp_PpalDineroElectronico(Cuenta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerReciboAparador(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal FecReciIniB As String, ByVal FecReciFinB As String,
                                     ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String,
                                            ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, IdAgrupacion As String,
                                            ByVal NomTabla As String) As DataSet
        'mreyes 25/Mayo/2016    11:31 a.m.
        Try
            usp_TraerReciboAparador = objDALAparador.usp_TraerReciboAparador(Opcion, Sucursal, FecReciIniB, FecReciFinB, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, IdAgrupacion, NomTabla)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerMatchAparador(ByVal Opcion As Integer, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                                ByVal NomTabla As String) As DataSet
        'mreyes 22/Mayo/2015    05:39 p.m.
        Try
            usp_TraerMatchAparador = objDALAparador.usp_TraerMatchAparador(Opcion, Sucursales, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, NomTabla)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerAparadorReal(ByVal Opcion As Integer, ByVal Sucursales As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, _
                                                    ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                                    ByVal NomTabla As String) As DataSet
        'mreyes 29/Abril/2015   11:41 a.m.
        Try
            usp_TraerAparadorReal = objDALAparador.usp_TraerAparadorReal(Opcion, Sucursales, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, Marca, Modelo, NomTabla)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_AparadorLeer(ByVal Section As DataSet) As Boolean
        'mreyes 28/Abril/2015   10:31 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALAparador.usp_Captura_AparadorLeer(Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_TraspasoLeer(ByVal Section As DataSet) As Boolean
        'mreyes 02/Noviembre/2016   05:28 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALAparador.usp_Captura_TraspasoLeer(Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_AparadorLeer() As DataSet
        'mreyes 28/Abril/2015   10:30 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_AparadorLeer = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_AparadorLeer.Tables.Add("AparadorLeer")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn



            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))

            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("serie", Type.GetType("System.String"))

            objDataColumn.MaxLength = 14
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("IDUSUARIOINICIALAPA", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)


            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_TraspasoLeer() As DataSet
        'mreyes 02/Noviembre/2016   05:22 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_TraspasoLeer = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_TraspasoLeer.Tables.Add("TraspasoLeer")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn



            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))

            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("serie", Type.GetType("System.String"))

            objDataColumn.MaxLength = 14
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("IDUSUARIOINICIALAPA", Type.GetType("System.Int16"))

            objDataTable.Columns.Add(objDataColumn)


            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalAparador(ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, ByVal FecReciIni As String, _
                                        ByVal FecReciFin As String, ByVal idusuarioinicialapa As Integer)
        'mreyes 24/Abril/2015   10:16 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALAparador.usp_PpalAparador(Sucursal, Marca, Estilon, FecReciIni, FecReciFin, idusuarioinicialapa)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaAparador(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal Marca As String, ByVal Estilon As String, _
                 ByVal Corrida As String, ByVal IdUsuarioInicialApa As Integer, ByVal Observaciones As String) As Boolean
        'mreyes 24/Abril/2015   11:44 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALAparador.usp_ActualizaAparador(Opcion, Sucursal, Marca, Estilon, Corrida, IdUsuarioInicialApa, Observaciones)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String, _
                                                  ByVal DiasRespuesta As Integer, ByVal UltimoRes As String, ByVal DiasResurtido As Integer) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:00 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALAparador.usp_CapturaMarcaEstilonDiasRes(Proveedor, Marca, Estilon, DiasRespuesta, UltimoRes, DiasResurtido)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminarMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:35 p.m.
        Try
            Return objDALAparador.usp_EliminarMarcaEstilonDiasRes(Proveedor, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
