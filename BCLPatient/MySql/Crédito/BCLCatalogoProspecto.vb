Public Class BCLCatalogoProspecto
    Implements IDisposable
    Private objDALCatalogoProspecto As DAL.DALCatalogoProspecto
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoProspecto = New DAL.DALCatalogoProspecto(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            ' TODO: free your own state (unmanaged objects).
            ' TODO: set large fields to null.
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
    Public Function usp_Captura_Prospecto(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'ro.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProspecto.usp_Captura_Prospecto(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Prospecto() As DataSet

        Try
            'Instantiate a new DataSet object
            Inserta_Prospecto = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Prospecto.Tables.Add("Prospecto")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn


            objDataColumn = New DataColumn("idprospecto", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("appaterno", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("apmaterno", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idpromotor", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("aval", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("estatus", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("comentario", Type.GetType("System.String"))
            objDataColumn.MaxLength = 999
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("limcred", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("limvale", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("saldo", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("disponible", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telef1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)
            objDataColumn = New DataColumn("telef2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("celular", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("rfc", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("curp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ife", Type.GetType("System.String"))
            objDataColumn.MaxLength = 18
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nacionalidad", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("profesion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("edocivil", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sexo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("email", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tiempores", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nacim", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ciudadnac", Type.GetType("System.String"))
            objDataColumn.MaxLength = 40
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calle", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numero", Type.GetType("System.String"))
            objDataColumn.MaxLength = 4
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idcolonia", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("idciudad", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idestado", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("codpos", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("entrecalles", Type.GetType("System.String"))
            objDataColumn.MaxLength = 255
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("vivienda", Type.GetType("System.String"))
            objDataColumn.MaxLength = 3
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("domanterior", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ingresomen", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ingresootro", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dependen", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("empresaact", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("depto", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("puesto", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("antiguedad", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("calleemp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("numemp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 4
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idcolemp", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("codposemp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 5
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idcdemp", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idedoemp", Type.GetType("System.Int32"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telemp", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("empant", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dptoant", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pstoant", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nomcony", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("emprcony", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dptocony", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pstocony", Type.GetType("System.String"))
            objDataColumn.MaxLength = 45
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("antigcony", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telcony", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ingrcony", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("otringcony", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("referencia1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telref1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("direcref1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ocupacionref1", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("referencia2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("telref2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("direcref2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ocupacionref2", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuariocaptura", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuariorevision", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fumrevision", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            objDataColumn = New DataColumn("usupausado", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fumpausado", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuautorizo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fumautorizo", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("twitter", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("facebook", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pagare", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("catastro", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoProspecto(ByVal ProspectoA As String, ByVal ProspectoB As String, ByVal EstatusB As String, ByVal PromotorB As String) As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_PpalCatalogoProspecto = objDALCatalogoProspecto.usp_PpalCatalogoProspecto(ProspectoA, ProspectoB, EstatusB, PromotorB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleadoProspecto(ByVal IdEmpleado As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerEmpleadoProspecto = objDALCatalogoProspecto.usp_TraerEmpleadoProspecto(IdEmpleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerEmpleadoProspectoLike(ByVal Descrip As String, ByVal Empleado As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerEmpleadoProspectoLike = objDALCatalogoProspecto.usp_TraerEmpleadoProspectoLike(Descrip, Empleado)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerProspecto(ByVal IdProspecto As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerProspecto = objDALCatalogoProspecto.usp_TraerProspecto(IdProspecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCodPos(ByVal Colonia As String, ByVal Ciudad As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerCodPos = objDALCatalogoProspecto.usp_TraerCodPos(Colonia, Ciudad)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxPros() As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_TraerMaxPros = objDALCatalogoProspecto.usp_TraerMaxPros()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxAval() As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_TraerMaxAval = objDALCatalogoProspecto.usp_TraerMaxAval()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaxDistrib() As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_TraerMaxDistrib = objDALCatalogoProspecto.usp_TraerMaxDistrib()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFum(ByVal prospecto As Integer) As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_TraerFum = objDALCatalogoProspecto.usp_TraerFum(prospecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnProspecto(ByVal IdProspecto As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnProspecto = objDALCatalogoProspecto.usp_TraerUnProspecto(IdProspecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnProspectoLike(ByVal estatus As String, ByVal nombre As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnProspectoLike = objDALCatalogoProspecto.usp_TraerUnProspectoLike(estatus, nombre)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarEstatus(ByVal Opcion As String, ByVal idProspecto As Integer, ByVal Estatus As String) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProspecto.usp_ActualizarEstatus(Opcion, idProspecto, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_DocsFotos() As DataSet
        'mreyes 26/Marzo/2012 04:11 p.m.
        Try
            'Instantiate a new DataSet object
            Inserta_DocsFotos = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_DocsFotos.Tables.Add("fotodocs")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("id", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("tipo", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("docfoto", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 30
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nofoto", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("pertenece", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("ruta", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 200
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fecha", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("hora", Type.GetType("System.String"))
            objDataColumn.AllowDBNull = False
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)



        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNegEx(ByVal negocio As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerNegEx = objDALCatalogoProspecto.usp_TraerNegEx(negocio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNegociosExternos(ByVal opcion As String, ByVal prospecto As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerNegociosExternos = objDALCatalogoProspecto.usp_TraerNegociosExternos(opcion, prospecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_ClaveNEP(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'ro.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProspecto.usp_Captura_ClaveNEP(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Clave() As DataSet
        'mreyes 05/Mayo/2012 09:29 a.m.
        Try
            'Instantiate a new DataSet object
            Inserta_Clave = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Clave.Tables.Add("distribne")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            'Instantiate a new DataColumn and set its properties
            objDataColumn = New DataColumn("iddistrib", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idprospecto", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("negocio", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)


            objDataColumn = New DataColumn("clave", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("feccorte", Type.GetType("System.String"))
            objDataColumn.MaxLength = 10
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("venta", Type.GetType("System.String"))
            objDataColumn.MaxLength = 15
            objDataTable.Columns.Add(objDataColumn)
            'Add the column to the table


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_DocFotos(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoProspecto.usp_Captura_DocFotos(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Actualiza_DocFotos(ByVal IdDistrib As Integer, ByVal IdProspecto As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_Actualiza_DocFotos = objDALCatalogoProspecto.usp_Actualiza_DocFotos(IdDistrib, IdProspecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Elimina_Negocio(ByVal prospecto As String, ByVal distrib As String) As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_Elimina_Negocio = objDALCatalogoProspecto.usp_Elimina_Negocio(prospecto, distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDistribNE(ByVal distrib As String) As DataSet
        'ro

        Try
            'Call the data component to get all groups
            usp_TraerDistribNE = objDALCatalogoProspecto.usp_TraerDistribNE(distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function Inserta_Motivo() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Motivo = New DataSet

            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Motivo.Tables.Add("prospna")

            'Create a DataColumn object
            Dim objDataColumn As DataColumn

            objDataColumn = New DataColumn("idprospecto", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("idmotivo", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("motivo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 80
            objDataTable.Columns.Add(objDataColumn)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Motivo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'ro.
        Try
            'Validate group data
            'Call the data component to add the new group
            Return objDALCatalogoProspecto.usp_Captura_Motivo(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNoAutorizados(ByVal prospecto As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerNoAutorizados = objDALCatalogoProspecto.usp_TraerNoAutorizados(prospecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnProspectoNA(ByVal IdProspecto As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnProspectoNA = objDALCatalogoProspecto.usp_TraerUnProspectoNA(IdProspecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ImprimeProspecto(ByVal ProspectoA As String, ByVal ProspectoB As String, ByVal EstatusB As String, ByVal PromotorB As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_ImprimeProspecto = objDALCatalogoProspecto.usp_ImprimeProspecto(ProspectoA, ProspectoB, EstatusB, PromotorB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region

End Class
