Public Class BCLPedidos
    'mreyes 10/Febrero/2012 11:49 a.m.

    Implements IDisposable
    Private objDALPedidos As DAL.DALPedidos
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALPedidos = New DAL.DALPedidos(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALPedidos.Dispose()
            objDALPedidos = Nothing
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

    Public Function usp_TraerSeriesConsultaModelos(ByVal Sucursal As String, ByVal Marca As String, ByVal Modelo As String, ByVal Serie As String) As DataSet
        'Tony Garcia -  23/Septiembre/2013 07:10 p.m.
        Try
            usp_TraerSeriesConsultaModelos = objDALPedidos.usp_TraerSeriesConsultaModelos(Sucursal, Marca, Modelo, Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_OrdeComp(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 10/Febrero/2012 11:58 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_Captura_OrdeComp(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CancEOC(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 24/Marzo/2012 12:07 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_Captura_CancEOC(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarDetOCPedida(ByVal Ctd As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Medida As String, ByVal Entrega As Date) As Boolean
        'mreyes 02/Marzo/2013 10:55 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarDetOCPedida = objDALPedidos.usp_ActualizarDetOCPedida(Ctd, Sucursal, OrdeComp, Marca, Estilon, Medida, Entrega)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarModeloCancelado(ByVal IdUsuarioCancela As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Entrega As Date, ByVal corrida As String) As Boolean
        'mreyes 02/Marzo/2013 10:55 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarModeloCancelado = objDALPedidos.usp_ActualizarModeloCancelado(IdUsuarioCancela, Sucursal, OrdeComp, Marca, Estilon, Entrega, corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarFecReci(ByVal FecReci As Date, ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'mreyes 02/Marzo/2013 10:55 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarFecReci = objDALPedidos.usp_ActualizarFecReci(FecReci, Proveedor, Marca, Estilon)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarSerieDEVOPROV(ByVal Serie As String) As Boolean
        'mreyes 02/Marzo/2013 10:55 a.m.
        Try
            'Call the data component to get all groups
            usp_ActualizarSerieDEVOPROV = objDALPedidos.usp_ActualizarSerieDEVOPROV(Serie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_CancDOC(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 24/Marzo/2012 12:13 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_Captura_CancDOC(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Det_ocResAut(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 16/Febrero/2017 05:27 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_Captura_Det_ocResAut(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Det_oc(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 10/Febrero/2012 12:11 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_Captura_Det_oc(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function fn_FolioCambPrec(ByVal Opcion As Integer, ByVal Sucursal As String) As DataSet
        Try
            'Call the data component to get all groups
            fn_FolioCambPrec = objDALPedidos.fn_FolioCambPrec(Opcion, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function fn_FolioOrdeComp(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal MasSerie As Integer) As DataSet
        Try
            'Call the data component to get all groups
            fn_FolioOrdeComp = objDALPedidos.fn_FolioOrdeComp(Opcion, Sucursal, MasSerie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_OrdeCompResAut() As DataSet
        'mreyes 16/Febrero/2016 05:19 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_OrdeCompResAut = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_OrdeCompResAut.Tables.Add("OrdecompResAut")

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

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("observa", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("resurtsn", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dsctopp", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diaspp", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto01", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto02", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto03", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto04", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto05", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iva", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("tipopedido", Type.GetType("System.String"))

            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_OrdeComp() As DataSet
        'mreyes 10/Febrero/2012 11:58 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_OrdeComp = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_OrdeComp.Tables.Add("Ordecomp")

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

            objDataColumn = New DataColumn("status", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("observa", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 60
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("resurtsn", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dsctopp", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("diaspp", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto01", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto02", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto03", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto04", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto05", Type.GetType("System.Double"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iva", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("tipopedido", Type.GetType("System.String"))

            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_CancEOC() As DataSet
        'mreyes 24/Marzo/2012 12:04 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_CancEOC = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_CancEOC.Tables.Add("CancEOC")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Type.GetType("System.Int16"))
            ' Type.GetType("System.DateTime")
            'Type.GetType("System.Decimal")

            'Instantiate a new DataColumn and set its properties


            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucurorc", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ordecomp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)
          


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Det_ocResAut() As DataSet
        'mreyes 16/Febrero/2016 05:25 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Det_ocResAut = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Det_ocResAut.Tables.Add("Det_ocResAut")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn



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

            objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctd", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costdesc", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("precio", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("entrega", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cancela", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("ordecompresaut", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 6
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Det_oc() As DataSet
        'mreyes 10/Febrero/2012 12:11 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Det_oc = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Det_oc.Tables.Add("Det_oc")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

    

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

            objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctd", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costo", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("costdesc", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("precio", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("entrega", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cancela", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_CancDOC() As DataSet
        'mreyes 24/Marzo/2012 11:56 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_CancDOC = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_CancDOC.Tables.Add("CanDOC")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("canocid", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estilon", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 7
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("corrida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("medida", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ctd", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

           

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Actualiza_FolioOrdeComp() As DataSet
        'mreyes 15/Febrero/2012 05:26 p.m.
        Try
            'Instantiate a new DataSet object
            Actualiza_FolioOrdeComp = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Actualiza_FolioOrdeComp.Tables.Add("sucursal")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Actualiza_FolioCambPrec() As DataSet
        'mreyes 15/Febrero/2012 05:26 p.m.
        Try
            'Instantiate a new DataSet object
            Actualiza_FolioCambPrec = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Actualiza_FolioCambPrec.Tables.Add("sucursal")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_FolioBodega(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 28/Diciembre/2016   06:03 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_FolioBodega(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_FolioOrdeComp(ByVal Opcion As Integer, ByVal Section As DataSet, ByVal MasSerie As Integer) As Boolean
        'mreyes 15/Febrero/2012 05:37 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_FolioOrdeComp(Opcion, Section, MasSerie)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_FolioCambPrec(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 15/Febrero/2012 05:37 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALPedidos.usp_FolioCambPrec(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerOrdeComp = objDALPedidos.usp_TraerOrdeComp(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerOrdeCompMaxEntrega(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        'mreyes 22/Enero/2014 06:21 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerOrdeCompMaxEntrega = objDALPedidos.usp_TraerOrdeCompMaxEntrega(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactProv(ByVal Sucursal As String, ByVal FactProv As String, ByVal idfolio As Integer, ByVal Proveedor As String) As DataSet
        'mreyes 22/Marzo/2012 01:25 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFactProv = objDALPedidos.usp_TraerFactProv(Sucursal, FactProv, idfolio, Proveedor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ExisteFactProv(ByVal Sucursal As String, ByVal Referenc As String) As DataSet
        'mreyes 23/Mayo/2012 05:14 p.m.
        Try
            'Call the data component to get all groups
            usp_ExisteFactProv = objDALPedidos.usp_ExisteFactProv(Sucursal, Referenc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDevProv(ByVal Sucursal As String, ByVal DevProv As String) As DataSet
        'mreyes 29/Marzo/2012 11:04 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDevProv = objDALPedidos.usp_TraerDevProv(Sucursal, DevProv)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerDet_Oc = objDALPedidos.usp_TraerDet_OC(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDet_OcEstilo(ByVal Marca As String, ByVal Estilon As String, ByVal SucCancela As String, ByVal OrdeComp As String, ByVal Descripcion As String) As DataSet
        'mreyes 22/Marzo/2012 10:06 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerDet_OcEstilo = objDALPedidos.usp_TraerDet_OcEstilo(Marca, Estilon, SucCancela, OrdeComp, Descripcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDet_FP(ByVal Sucursal As String, ByVal FactProv As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 22/Marzo/2012 01:45 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDet_FP = objDALPedidos.usp_TraerDet_FP(Sucursal, FactProv, IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_FPDevoProv(ByVal IdFolio As Integer, ByVal EStilon As String, ByVal Medida As String) As DataSet
        'mreyes 22/Marzo/2012 01:45 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDet_FPDevoProv = objDALPedidos.usp_TraerDet_FPDevoProv(IdFolio, EStilon, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_FPTraspasoResAut(Opcion As Integer, ByVal IdFolio As Integer, Sucursal As String) As DataSet
        'mreyes 23/Febrero/2017 01:24 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDet_FPTraspasoResAut = objDALPedidos.usp_TraerDet_FPTraspasoResAut(Opcion, IdFolio, Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDet_FPTraspaso(ByVal Sucursal As String, ByVal FactProv As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 22/Marzo/2012 01:45 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDet_FPTraspaso = objDALPedidos.usp_TraerDet_FPTraspaso(Sucursal, FactProv, IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDet_DP(ByVal Sucursal As String, ByVal DevProv As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 29/Marzo/2012 11:08 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerDet_DP = objDALPedidos.usp_TraerDet_DP(Sucursal, DevProv, IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerSeries(ByVal Tipo As String, ByVal Sucursal As String, ByVal Folio As String, ByVal IdFolio As Integer, ByVal Serie As String, ByVal Serie1 As String, ByVal Division As String, ByVal Depto As String, ByVal Familia As String, ByVal Linea As String, ByVal L1 As String, ByVal L2 As String, ByVal L3 As String, ByVal L4 As String, ByVal L5 As String, ByVal L6 As String) As DataSet
        'mreyes 24/Agosto/2013 10:38 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerSeries = objDALPedidos.usp_TraerSeries(Tipo, Sucursal, Folio, IdFolio, Serie, Serie1, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarSerieReciboSQL(ByVal IdFolio As Integer, SucurDes As String) As Boolean
        'mreyes 21/Octubre/2021 01:07 p.m.
        Try
            'Call the data component to delete the group
            Return objDALPedidos.usp_ActualizarSerieReciboSQL(IdFolio, SucurDes)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_EliminarDet_Oc(ByVal Sucursal As String, ByVal Ordecomp As String) As Boolean
        'mreyes 18/Febrero/2012 01:45 p.m.
        Try
            'Call the data component to delete the group
            Return objDALPedidos.usp_EliminarDet_Oc(Sucursal, Ordecomp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ActualizarCantSolMedida(ByVal Marca As String, ByVal Estilo As String, ByVal Corrida As String, ByVal Medida As String) As Boolean
        'mreyes 21/Marzo/2012 07:05 p.m.
        Try
            'Call the data component to delete the group
            Return objDALPedidos.usp_ActualizarCantSolMedida(Marca, Estilo, Corrida, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantidadesDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Entrega As Date) As DataSet
        'mreyes 24/Febrero/2012 11:10 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadesDet_Oc = objDALPedidos.usp_TraerCantidadesDet_Oc(Sucursal, OrdeComp, Marca, Estilon, Corrida, Medida, Entrega)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerCantidadesSXRecDet_Oc(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal Entrega As Date) As DataSet
        'mreyes 24/Febrero/2012 11:10 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadesSXRecDet_Oc = objDALPedidos.usp_TraerCantidadesSXRecDet_Oc(Sucursal, OrdeComp, Marca, Estilon, Corrida, Medida, Entrega)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerCantidadesDet_OcCancela(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As DataSet
        'mreyes 16/Abril/2012 04:09 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadesDet_OcCancela = objDALPedidos.usp_TraerCantidadesDet_OcCancela(Sucursal, OrdeComp, Marca, Estilon, Corrida, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantidadesDet_FP(ByVal Sucursal As String, ByVal FactProv As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String, ByVal IdFolio As Integer) As DataSet
        'mreyes 22/Marzo/2012 02:10 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadesDet_FP = objDALPedidos.usp_TraerCantidadesDet_FP(Sucursal, FactProv, Marca, Estilon, Corrida, Medida, IdFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantidadesDet_DP(ByVal Sucursal As String, ByVal DevoProv As String, ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As DataSet
        'mreyes 29/Marzo/2012 11:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantidadesDet_DP = objDALPedidos.usp_TraerCantidadesDet_DP(Sucursal, DevoProv, Marca, Estilon, Corrida, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCantArtSolicitados(ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As DataSet
        'mreyes 20/Marzo/2012 04:18 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerCantArtSolicitados = objDALPedidos.usp_TraerCantArtSolicitados(Marca, Proveedor, Estilon, Corrida, Medida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPedidoNuevo(ByVal Accion As Integer, ByVal Sucursal As String, ByVal OrdeComIni As String, ByVal OrdeComFin As String, ByVal Marca As String, _
                                             ByVal Modelo As String, ByVal EstiloF As String, ByVal IdDivision As String, ByVal IdDepto As String, ByVal IdFamilia As String, ByVal IdLinea As String, _
                                           ByVal IdL1 As String, ByVal IdL2 As String, ByVal IdL3 As String, ByVal IdL4 As String, ByVal IdL5 As String, _
                                           ByVal IdL6 As String, ByVal Proveedor As String, ByVal Status As String, _
                                             ByVal FechaIni As String, ByVal Fechafin As String, ByVal EntregaIni As String, ByVal EntregaFin As String, ByVal ResurtSN As String, ByVal TipoPedido As String, ResAut As Integer) As DataSet
        'mreyes 24/Febrero/2012 07:07 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalPedidoNuevo = objDALPedidos.usp_PpalPedidoNuevo(Accion, Sucursal, OrdeComIni, OrdeComFin, Marca, Modelo, EstiloF, _
                                                                    IdDivision, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, _
                                                                    Proveedor, Status, FechaIni, _
                                                                    Fechafin, EntregaIni, EntregaFin, ResurtSN, TipoPedido, ResAut)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalTraerPedidos(ByVal idFolio As Integer) As DataSet
        'mreyes 28/Abril/2013 02:57 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalTraerPedidos = objDALPedidos.usp_PpalTraerPedidos(idFolio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoEstilos(ByVal Marca As String, _
                                        ByVal Estilon As String, ByVal EstiloF As String, ByVal Familia As String, ByVal Linea As String, _
                                        ByVal Proveedor As String, ByVal TipoArt As String, ByVal Categoria As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
        'mreyes 25/Febrero/2012 09:58 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalCatalogoEstilos = objDALPedidos.usp_PpalCatalogoEstilos(Marca, Estilon, EstiloF, _
                                                                    Familia, Linea, Proveedor, TipoArt, Categoria, FechaIni, _
                                                                    Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalClasificacionEstilos(ByVal Marca As String, _
                                        ByVal Estilon As String, ByVal EstiloF As String, ByVal Familia As String, ByVal Linea As String, _
                                        ByVal Proveedor As String, ByVal TipoArt As String, ByVal Categoria As String, ByVal ArtCat As String, _
                                        ByVal FechaIni As String, ByVal Fechafin As String) As DataSet
        'Tony Garcia - 29/Noviembre/2012 01:30 p.m.
        Try
            'Call the data component to get all groups
            usp_PpalClasificacionEstilos = objDALPedidos.usp_PpalClasificacionEstilos(Marca, Estilon, EstiloF, _
                                                                    Familia, Linea, Proveedor, TipoArt, Categoria, ArtCat, FechaIni, _
                                                                    Fechafin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerArticulosSolicitados(ByVal Marca As String, ByVal Proveedor As String, ByVal Track As Integer) As DataSet
        'mreyes 21/Marzo/2012 01:49 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerArticulosSolicitados = objDALPedidos.usp_TraerArticulosSolicitados(Marca, Proveedor, Track)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMedida(ByVal Opcion As Integer, ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'mreyes 21/Marzo/2012 01:49 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMedida = objDALPedidos.usp_TraerMedida(Opcion, Marca, Proveedor, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMedidaMinima(ByVal Opcion As Integer, ByVal Marca As String, ByVal Proveedor As String, ByVal Estilon As String, ByVal Corrida As String) As DataSet
        'mreyes 21/Marzo/2012 01:49 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMedidaMinima = objDALPedidos.usp_TraerMedidaMinima(Opcion, Marca, Proveedor, Estilon, Corrida)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechaUltResurt() As DataSet
        'mreyes 02/Mayo0/2012 10:40 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerFechaUltResurt = objDALPedidos.usp_TraerFechaUltResurt()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerResurtidoAuto() As DataSet
        'mreyes 21/Marzo/2012 01:49 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerResurtidoAuto = objDALPedidos.usp_TraerResurtidoAuto()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarOrdeComp(ByVal Sucursal As String, ByVal OrdeComp As String) As Boolean
        'mreyes 23/Abril/2012 09:49 a.m.
        Try
            'Call the data component to delete the group
            Return objDALPedidos.usp_ActualizarOrdeComp(Sucursal, OrdeComp)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaClasifEstilos(ByVal Opcion As String, ByVal Marca As String, ByVal Estilon As String, _
                                            ByVal Tipo As String, ByVal UsuModArtCat As String, ByVal FummodArtCat As DateTime) As Boolean
        'Tony Garcia - 30/Noviembre/2012 10:15 a.m.
        Try
            'Call the data component to delete the group
            Return objDALPedidos.usp_CapturaClasifEstilos(Opcion, Marca, Estilon, Tipo, UsuModArtCat, FummodArtCat)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
