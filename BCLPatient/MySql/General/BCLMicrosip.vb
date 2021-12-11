Public Class BCLMicrosip
    'mreyes 05/Marzo/2012 09:53 a.m.
    Implements IDisposable
    Private objDALMicrosip As DAL.DALMicrosip
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALMicrosip = New DAL.DALMicrosip(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALMicrosip.Dispose()
            objDALMicrosip = Nothing
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

    Public Function Inserta_Estados() As DataSet
        'mreyes 05/Marzo/2012 10:00 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Estados = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Estados.Tables.Add("Estados")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("estado_id", Type.GetType("System.Int16"))
            'objDataColumn.AllowDBNull = False
            'objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre_abrev", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("es_predet", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pais_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("usuario_creador", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Proveedores() As DataSet
        'mreyes 05/Marzo/2012 01:11 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Proveedores = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Proveedores.Tables.Add("Proveedores")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("proveedor_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contacto1", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contacto2", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calle", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre_calle", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("num_exterior", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("num_interior", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("colonia", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("referencia", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudad_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estado_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("codigo_postal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pais_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telefono1", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 35
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telefono2", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 35
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fax", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 35
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("email", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rfc_curp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("causa_susp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("carga_impuestos", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("retener_impuestos", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("extranjero", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("limite_credito", Type.GetType("System.Decimal"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("moneda_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cond_pago_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            
            objDataColumn = New DataColumn("notas", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cuenta_cxp", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            
            objDataColumn = New DataColumn("formatos_email", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("actividad_principal", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_creador", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Libres_Proveedores() As DataSet
        'mreyes 14/Marzo/2012 05:34 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Libres_Proveedores = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Libres_Proveedores.Tables.Add("Libres_Proveedor")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("proveedor_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("marca", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

           


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Inserta_Estados(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Marzo/2012 10:45 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Estados(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Ciudades(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Marzo/2012 06:37 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Ciudades(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Gen_Catalogo_Id() As DataSet
        'mreyes 05/Marzo/2012 11:31 a.m.
        Try
            'Call the data component to get all groups
            usp_Gen_Catalogo_Id = objDALMicrosip.usp_Gen_Catalogo_Id()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Gen_Docto_Id() As DataSet
        'mreyes 15/Marzo/2012 10:58 a.m.
        Try
            'Call the data component to get all groups
            usp_Gen_Docto_Id = objDALMicrosip.usp_Gen_Docto_Id()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Estado(ByVal Nombre As String, ByVal Nombre_Abrev As String) As DataSet
        'mreyes 05/Marzo/2012 06:16 p.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Estado = objDALMicrosip.usp_Traer_Estado(Nombre, Nombre_abrev)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Traer_Ciudad(ByVal Nombre As String) As DataSet
        'mreyes 05/Marzo/2012 06:31 p.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Ciudad = objDALMicrosip.usp_Traer_Ciudad(Nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Traer_Proveedor(ByVal Proveedor_Id As Integer, ByVal Nombre As String) As DataSet
        'mreyes 06/Marzo/2012 01:46 p.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Proveedor = objDALMicrosip.usp_Traer_Proveedor(Proveedor_Id, Nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Traer_Empleado() As DataSet
        'mreyes 21/Junio/2012 11:06 a.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Empleado = objDALMicrosip.usp_Traer_Empleado()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Traer_Plazos_Cond_Pag_Cp(ByVal cond_pago_id As Integer) As DataSet
        'mreyes 25/Mayo/2012 10:54 a.m.TRAER_PLAZOS_COND_PAG_CP
        Try
            'Call the data component to get all groups
            usp_Traer_Plazos_Cond_Pag_Cp = objDALMicrosip.usp_Traer_Plazos_Cond_Pag_Cp(cond_pago_id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Fact_Pend(ByVal V_PROVEEDOR_ID As Integer, ByVal V_FECHA_CORTE1 As Date, ByVal V_FECHA_CORTE2 As Date, ByVal V_FECHA_SALDOS As Date, ByVal V_INCL_SALDADOS As String, ByVal V_FECHA_VENCIMIENTO1 As Date, ByVal V_FECHA_VENCIMIENTO2 As Date, ByVal V_FOLIO1 As String, ByVal V_FOLIO2 As String, ByVal V_PROVEEDOR As Integer) As DataSet
        'mreyes 25/Abril/2012 06:34 p.m.
        Try
            'Call the data component to get all groups
            usp_Fact_Pend = objDALMicrosip.usp_Fact_Pend(V_PROVEEDOR_ID, V_FECHA_CORTE1, V_FECHA_CORTE2, V_FECHA_SALDOS, V_INCL_SALDADOS, V_FECHA_VENCIMIENTO1, V_FECHA_VENCIMIENTO2, V_FOLIO1, V_FOLIO2, V_PROVEEDOR)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Fact_Pagadas(ByVal V_PROVEEDOR_ID As Integer, ByVal V_FECHA_CORTE1 As Date, ByVal V_FECHA_CORTE2 As Date, ByVal V_FECHA_SALDOS As Date, ByVal V_INCL_SALDADOS As String, ByVal V_FECHA_VENCIMIENTO1 As Date, ByVal V_FECHA_VENCIMIENTO2 As Date, ByVal V_FOLIO1 As String, ByVal V_FOLIO2 As String, ByVal V_PROVEEDOR As Integer) As DataSet
        'mreyes 25/Abril/2012 06:34 p.m.
        Try
            'Call the data component to get all groups
            usp_Fact_Pagadas = objDALMicrosip.usp_Fact_pagadas(V_PROVEEDOR_ID, V_FECHA_CORTE1, V_FECHA_CORTE2, V_FECHA_SALDOS, V_INCL_SALDADOS, V_FECHA_VENCIMIENTO1, V_FECHA_VENCIMIENTO2, V_FOLIO1, V_FOLIO2, V_PROVEEDOR)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Traer_Doctos_CP(ByVal Concepto_Id_Cp As Integer, ByVal Proveedor_Id As Integer, ByVal Folio As String, ByVal Fecha As Date, ByVal Clave_Prov As String) As DataSet
        'mreyes 17/Marzo/2012 11:06 p.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Doctos_CP = objDALMicrosip.usp_Traer_Doctos_CP(Concepto_Id_Cp, Proveedor_Id, Folio, Fecha, Clave_Prov)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Traer_Libres_Proveedor(ByVal Proveedor_Id As Integer) As DataSet
        'mreyes 14/Marzo/2012 05:20 p.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Libres_Proveedor = objDALMicrosip.usp_traer_libres_proveedor(Proveedor_Id)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Traer_Condicion_Pago_CP(ByVal Porc As Decimal, ByVal Dias As Integer) As DataSet
        'mreyes 06/Marzo/2012 04:31 p.m.
        Try
            'Call the data component to get all groups
            usp_Traer_Condicion_Pago_CP = objDALMicrosip.usp_Traer_Condicion_Pago_CP(Porc, Dias)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Inserta_Proveedores(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Marzo/2012 01:34 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Proveedores(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Empleados(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 31/Mayo/2012 05:49 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Empleados(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Doctos_CP(ByVal Opcion As Integer, ByVal IdFolioB As String, ByVal Section As DataSet) As Boolean
        'mreyes 16/Marzo/2012 11:12 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Doctos_CP(Opcion, idfoliob, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Inserta_Importes_Doctos_CP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 16/Marzo/2012 11:47 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Importes_Doctos_CP(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Importes_Doctos_CP_IMPTOS(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 20/Marzo/2012 05:09 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Importes_Doctos_CP_IMPTOS(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Inserta_Libres_Cargos_CP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 20/Marzo/2012 04:55 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Libres_Cargos_CP(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Vencimientos_Cargos_CP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 20/Marzo/2012 05:51 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Vencimientos_Cargos_CP(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Inserta_Libres_Proveedores(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 14/Marzo/2012 05:36 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Libres_Proveedores(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Inserta_Claves_Proveedores(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 05/Marzo/2012 07:31 p.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALMicrosip.usp_Inserta_Claves_Proveedores(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Ciudad() As DataSet
        'mreyes 05/Marzo/2012 10:00 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Ciudad = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Ciudad.Tables.Add("Ciudades")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("ciudad_id", Type.GetType("System.Int16"))
            'objDataColumn.AllowDBNull = False
            'objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("es_predet", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estado_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_creador", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Claves_Proveedores() As DataSet
        'mreyes 05/Marzo/2012 07:29 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Claves_Proveedores = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Claves_Proveedores.Tables.Add("Claves_Proveedores")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("clave_prov_id", Type.GetType("System.Int16"))
            'objDataColumn.AllowDBNull = False
            'objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("clave_prov", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("proveedor_id", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("ROL_CLAVE_PROV_ID", Type.GetType("System.Int16"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Doctos_CP() As DataSet
        'mreyes 16/Marzo/2012 11:01 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Doctos_CP = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Doctos_CP.Tables.Add("Doctos_CP")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("docto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("concepto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("folio", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 9
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("naturaleza_concepto", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("clave_prov", Type.GetType("System.String"))
            objDataColumn.MaxLength = 20
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("proveedor_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo_cambio", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cancelado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("aplicado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("descripcion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("forma_emitida", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contabilizado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contabilizado_gyp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cond_pago_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha_dscto_ppag", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pctje_dscto_ppag", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("exportado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sistema_origen", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("integ_ba", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contabilizado_ba", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_creador", Type.GetType("System.String"))
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Importes_Doctos_CP() As DataSet
        'mreyes 16/Marzo/2012 11:44 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Importes_Doctos_CP = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Importes_Doctos_CP.Tables.Add("Importes_Doctos_CP")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("impte_docto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("docto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cancelado", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("aplicado", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo_impte", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("docto_cp_acr_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("importe", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impuesto", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("iva_retenido", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("isr_retenido", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto_ppag", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)
  

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Importes_Doctos_CP_IMPTOS() As DataSet
        'mreyes 20/Marzo/2012 05:20 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Importes_Doctos_CP_IMPTOS = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Importes_Doctos_CP_IMPTOS.Tables.Add("Importes_Doctos_CP_IMPTOS")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("impte_docto_cp_impto_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impte_docto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("imIdPuesto", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("importe", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pctje_impuesto", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("impuesto", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Libres_Cargos_CP() As DataSet
        'mreyes 20/Marzo/2012 04:54 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Libres_Cargos_CP = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Libres_Cargos_CP.Tables.Add("Libres_Cargos_CP")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("docto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function Inserta_Vencimientos_Cargos_CP() As DataSet
        'mreyes 20/Marzo/2012 04:54 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Vencimientos_Cargos_CP = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Vencimientos_Cargos_CP.Tables.Add("Vencimientos_Cargos_CP")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("docto_cp_id", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha_vencimiento", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pctje_ven", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function Inserta_Empleados() As DataSet
        'mreyes 31/Mayo/2012 05:50 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Empleados = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Empleados.Tables.Add("Empleados")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("idempleado", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numero", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre_completo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("apellido_paterno", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("apellido_materno", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombres", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("puesto_no_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("depto_no_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("frepag_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("forma_pago", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("contrato", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("dias_hrs_jsr", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("horario", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("turno", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("jornada", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha_ingreso", Type.GetType("System.Date"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("zona_salmin", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tabla_antig_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo_salario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pctje_integ", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("salario_hora", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("salario_integ", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ptu", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("imss", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cas", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("infonavit", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pensionado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("deshab_imptos", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calc_isr_anual", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calle", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre_calle", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("num_exterior", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("num_interior", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("colonia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("referencia", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudad_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("codigo_postal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telefono1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 35
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telefono2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 35
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("email", Type.GetType("System.String"))
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sexo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha_nacimiento", Type.GetType("System.Date"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudad_nacimiento", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estado_civil", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("num_hijos", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre_padre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre_madre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 100
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rfc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("curp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("reg_imss", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("otro_reg", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("unidad_medica", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("grupo_pago_elect_id", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("num_ctaban_pago", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_creador", Type.GetType("System.String"))
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha_hora_creacion", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_aut_creacion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_ult_modif", Type.GetType("System.String"))
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha_hora_ult_modif", Type.GetType("System.DateTime"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuario_aut_modif", Type.GetType("System.String"))
            objDataColumn.MaxLength = 31
            objDataTable.Columns.Add(objDataColumn)




            
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
