Imports System.Data.Odbc
'mreyes 07/Julio/2012 10:55 a.m.

Public Class DALCatalogoIncapacidad
    Inherits DALOdbc
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region

#Region " Public Role Functions "



    Public Function usp_Captura_Incapacidad(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 07/Agosto/2012 10:56 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Incapacidad(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idincapacidadb", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idincapacidad"))
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@fechaB", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@tipoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@riesgoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("riesgo"))
            MyBase.AddParameter("@dictamenB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("dictamen"))
            MyBase.AddParameter("@certificadoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("certificado"))
            MyBase.AddParameter("@diasb", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("dias"))
            MyBase.AddParameter("@casoB", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("caso"))
            MyBase.AddParameter("@descripcionB", OdbcType.Char, 50, Section.Tables(0).Rows(0).Item("descripcion"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@usuariob", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodifb", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodifb", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))

            usp_Captura_Incapacidad = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerIncapacidad(ByVal IdIncapacidad As Integer) As DataSet
        'mreyes 08/Agosto/2012 05:48 p.m.
        Try
            usp_TraerIncapacidad = New DataSet
            MyBase.SQL = "CALL usp_TraerIncapacidad(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdIncapacidad", OdbcType.Int, 16, IdIncapacidad)

            MyBase.FillDataSet(usp_TraerIncapacidad, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoIncapacidad(ByVal idEmpleado As Integer, ByVal Sucursal As String, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, ByVal Tipo As String) As DataSet
        'mreyes 07/Agosto/2012 11:58 a.m.
        Try


            usp_PpalCatalogoIncapacidad = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoIncapacidad(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 1, Sucursal)
            MyBase.AddParameter("@estatusB", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@inicioini", OdbcType.Date, 8, InicioIni)
            MyBase.AddParameter("@iniciofin", OdbcType.Date, 8, InicioFin)
            MyBase.AddParameter("@tipo", OdbcType.Char, 1, Tipo)


            MyBase.FillDataSet(usp_PpalCatalogoIncapacidad, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerMarcaPrincipal(ByVal Proveedor As String) As DataSet
        'mreyes 14/Marzo/2012 05:06 p.m.
        Try
            usp_TraerMarcaPrincipal = New DataSet
            MyBase.SQL = "CALL usp_TraerMarcaPrincipal(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@ProveedorB", OdbcType.Char, 3, Proveedor)

            MyBase.FillDataSet(usp_TraerMarcaPrincipal, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
