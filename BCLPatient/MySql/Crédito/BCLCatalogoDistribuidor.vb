Public Class BCLCatalogoDistribuidor
    Implements IDisposable
    Private objDALCatalogoDistribuidor As DAL.DALCatalogoDistribuidor
    Private disposedValue As Boolean = False

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoDistribuidor = New DAL.DALCatalogoDistribuidor(Constring)
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
    Public Function Inserta_Distribuidor() As DataSet
        Try
            'Instantiate a new DataSet object
            Inserta_Distribuidor = New DataSet
            'Create a DataTable object
            Dim objDataTable As DataTable = Inserta_Distribuidor.Tables.Add("Distribuidor")
            'Create a DataColumn object
            Dim objDataColumn As DataColumn
            objDataColumn = New DataColumn("iddistrib", Type.GetType("System.Int32"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("nombre", Type.GetType("System.String"))
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

            objDataColumn = New DataColumn("frecuen", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
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

            objDataColumn = New DataColumn("limcred", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("disponible", Type.GetType("System.String"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("limvale", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("dscto", Type.GetType("System.Decimal"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("cobrador", Type.GetType("System.Int16"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("sucursal", Type.GetType("System.String"))
            objDataColumn.MaxLength = 2
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("saldo", Type.GetType("System.Double"))
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("contravale", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("neexvale", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("promocion", Type.GetType("System.String"))
            objDataColumn.MaxLength = 1
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

            objDataColumn = New DataColumn("ingcony", Type.GetType("System.Double"))
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

            objDataColumn = New DataColumn("usuactivo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fumactivo", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usuinactivo", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fuminactivo", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usususpende", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fumsuspende", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("usubaja", Type.GetType("System.String"))
            objDataColumn.MaxLength = 8
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("fumbaja", Type.GetType("System.DateTime"))
            objDataColumn.AllowDBNull = False
            objDataTable.Columns.Add(objDataColumn)
            '


            objDataColumn = New DataColumn("twitter", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)

            objDataColumn = New DataColumn("facebook", Type.GetType("System.String"))
            objDataColumn.MaxLength = 50
            objDataTable.Columns.Add(objDataColumn)


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Captura_Distribuidor(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'ro.
        Try
            'Call the data component to add the new group
            Return objDALCatalogoDistribuidor.usp_Captura_Distribuidor(Opcion, Section)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Copiar_Distribuidor(ByVal IdProspecto As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_Copiar_Distribuidor = objDALCatalogoDistribuidor.usp_Copiar_Distribuidor(IdProspecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_Copiar_NE(ByVal IdProspecto As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_Copiar_NE = objDALCatalogoDistribuidor.usp_Copiar_NE(IdProspecto)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerNegociosExternos(ByVal opcion As String, ByVal distrib As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerNegociosExternos = objDALCatalogoDistribuidor.usp_TraerNegociosExternos(opcion, distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalCatalogoDistribuidor(ByVal distribA As String, ByVal distribB As String, ByVal estatus As String, ByVal promotorB As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_PpalCatalogoDistribuidor = objDALCatalogoDistribuidor.usp_PpalCatalogoDistribuidor(distribA, distribB, estatus, promotorB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDistribuidor(ByVal idDistrib As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerDistribuidor = objDALCatalogoDistribuidor.usp_TraerDistribuidor(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerCobrador(ByVal Idempleadob As Integer, ByVal CobradorB As String, ByVal TipoB As String, ByVal StatusB As String) As DataSet
        'mreyes 30/Junio/2014   12:33 p.m. IdEmpleadoB int, CobradorB char(2), TipoB char (2), StatusB char(2)
        Try
            'Call the data component to get all groups
            usp_TraerCobrador = objDALCatalogoDistribuidor.usp_TraerCobrador(Idempleadob, CobradorB, TipoB, StatusB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFumDistrib(ByVal distrib As Integer) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerFumDistrib = objDALCatalogoDistribuidor.usp_TraerFumDistrib(distrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_ActualizarEstatus(ByVal Opcion As String, ByVal idDistrib As Integer, ByVal Estatus As String) As Boolean
        Try
            'Call the data component to add the new group
            Return objDALCatalogoDistribuidor.usp_ActualizarEstatus(Opcion, idDistrib, Estatus)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistribLow(ByVal idDistrib As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnDistribLow = objDALCatalogoDistribuidor.usp_TraerUnDistribLow(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistrib(ByVal idDistrib As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnDistrib = objDALCatalogoDistribuidor.usp_TraerUnDistrib(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistribLikeLow(ByVal idDistrib As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnDistribLikeLow = objDALCatalogoDistribuidor.usp_TraerUnDistribLikeLow(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnDistribLike(ByVal idDistrib As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnDistribLike = objDALCatalogoDistribuidor.usp_TraerUnDistribLike(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerUnEmpresaLike(ByVal idDistrib As String) As DataSet
        'juan 17/09/2013
        Try
            'Call the data component to get all groups
            usp_TraerUnEmpresaLike = objDALCatalogoDistribuidor.usp_TraerUnEmpresaLike(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerUnNegocio(ByVal negocio As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerUnNegocio = objDALCatalogoDistribuidor.usp_TraerUnNegocio(negocio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    'Public Function usp_TraerFrecuencia2() As DataSet
    '    'juan-on 4/marzo/2013 5:43 p.m.
    '    Try
    '        usp_TraerFrecuencia2 = objDALCatalogoDistribuidor.usp_TraerFrecuencia2()
    '    Catch ExceptionErr As Exception
    '        Throw New System.Exception(ExceptionErr.Message, _
    '            ExceptionErr.InnerException)
    '    End Try
    'End Function
    Public Function usp_ImprimeDistribuidor(ByVal DistribA As String, ByVal DistribB As String, ByVal EstatusB As String, ByVal PromotorB As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_ImprimeDistribuidor = objDALCatalogoDistribuidor.usp_ImprimeDistribuidor(DistribA, DistribB, EstatusB, PromotorB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFrecuencia(ByVal frecuen As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerFrecuencia = objDALCatalogoDistribuidor.usp_TraerFrecuencia(frecuen)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFrecuenciaLike(ByVal descrip As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerFrecuenciaLike = objDALCatalogoDistribuidor.usp_TraerFrecuenciaLike(descrip)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerDocFotos(ByVal ruta As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_TraerDocFotos = objDALCatalogoDistribuidor.usp_TraerDocFotos(ruta)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDistribuidorID(ByVal idDistrib As Integer) As DataSet
        'juan 8-mayo-2013 12:48
        Try
            'Call the data component to get all groups
            usp_TraerDistribuidorID = objDALCatalogoDistribuidor.usp_TraerDistribuidorID(idDistrib)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function




    Public Function usp_PpalCatalogoEmpresaDistribuidora(ByVal distribA As String, ByVal distribB As String, ByVal estatus As String, ByVal promotorB As String) As DataSet
        'ro
        Try
            'Call the data component to get all groups
            usp_PpalCatalogoEmpresaDistribuidora = objDALCatalogoDistribuidor.usp_PpalCatalogoEmpresaDistribuidora(distribA, distribB, estatus, promotorB)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMovsDistrib(ByVal IdDistrib As Integer, ByVal Tipo As String, ByVal EstatusAnt As String, _
                                           ByVal EstatusNuevo As String, ByVal LimCredAnt As Double, ByVal LimCredNuevo As Double, _
                                           ByVal LimValeAnt As Double, ByVal LimValeNuevo As Double, ByVal Motivo As String, ByVal IdUsuario As Integer) As Boolean
        Try
            'Call the data component to add the new group
            Return objDALCatalogoDistribuidor.usp_CapturaMovsDistrib(IdDistrib, Tipo, EstatusAnt, _
                                            EstatusNuevo, LimCredAnt, LimCredNuevo, _
                                            LimValeAnt, LimValeNuevo, Motivo, IdUsuario)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActulizaLimites(ByVal IdDistrib As Integer, ByVal LimCred As Double, ByVal LimVale As Double) As Boolean
        Try
            'Call the data component to add the new group
            Return objDALCatalogoDistribuidor.usp_ActulizaLimites(IdDistrib, LimCred, LimVale)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
