Imports System.Data.Odbc
'mreyes 11/Junio/2012 10:13 a.m.

Public Class DALCatalogoRepetitivo
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



    Public Function usp_Captura_Repetitivo(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 11/Junio/2012 10:14 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Repetitivo(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idrepetitivob", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idrepetitivo"))
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idempleado"))
            MyBase.AddParameter("@idpercdeducB", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idpercdeduc"))
            MyBase.AddParameter("@descripB", OdbcType.Char, 30, Section.Tables(0).Rows(0).Item("descrip"))
            MyBase.AddParameter("@folioB", OdbcType.Char, 12, Section.Tables(0).Rows(0).Item("folio"))
            MyBase.AddParameter("@importeB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("importe"))
            MyBase.AddParameter("@cuotaB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("cuota"))
            MyBase.AddParameter("@saldoB", OdbcType.Decimal, 9, Section.Tables(0).Rows(0).Item("saldo"))
            MyBase.AddParameter("@inicioB", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("inicio"))
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Section.Tables(0).Rows(0).Item("estatus"))
            MyBase.AddParameter("@idcuentab", OdbcType.Int, 16, Section.Tables(0).Rows(0).Item("idcuenta"))
            MyBase.AddParameter("@usuariob", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@usumodifb", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("usumodif"))
            MyBase.AddParameter("@fummodifb", OdbcType.DateTime, 16, Section.Tables(0).Rows(0).Item("fummodif"))
            MyBase.AddParameter("@observacionesb", OdbcType.Char, 200, Section.Tables(0).Rows(0).Item("observaciones"))

            MyBase.AddParameter("@horab", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("hora"))
            MyBase.AddParameter("@finb", OdbcType.Date, 8, Section.Tables(0).Rows(0).Item("fin"))


            usp_Captura_Repetitivo = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_TraerRepetitivo(ByVal IdRepetitivo As Integer) As DataSet
        'mreyes 11/Junio/2012 12:29 p.m.
        Try
            usp_TraerRepetitivo = New DataSet
            MyBase.SQL = "CALL usp_TraerRepetitivo(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idRepetitivo", OdbcType.Int, 16, IdRepetitivo)

            MyBase.FillDataSet(usp_TraerRepetitivo, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalCatalogoPreNomina(ByVal idEmpleado As Integer, ByVal idPercDeduc As Integer, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, ByVal Tienda As String, ByVal Sucursal As String) As DataSet
        'mreyes 21/Abril/2015   10:25 a.m.
        Try


            usp_PpalCatalogoPreNomina = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoPreNomina(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@idpercdeduc", OdbcType.Int, 16, idPercDeduc)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@inicioini", OdbcType.Date, 8, InicioIni)
            MyBase.AddParameter("@iniciofin", OdbcType.Date, 8, InicioFin)

            MyBase.AddParameter("@tiendab", OdbcType.Char, 1, Tienda)
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)


            MyBase.FillDataSet(usp_PpalCatalogoPreNomina, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoRepetitivo(ByVal idEmpleado As Integer, ByVal idPercDeduc As Integer, ByVal Estatus As String, ByVal InicioIni As Date, ByVal InicioFin As Date, ByVal Tienda As String) As DataSet
        'mreyes 11/Junio/2012 10:20 a.m.
        Try


            usp_PpalCatalogoRepetitivo = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoRepetitivo(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@idpercdeduc", OdbcType.Int, 16, idPercDeduc)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@inicioini", OdbcType.Date, 8, InicioIni)
            MyBase.AddParameter("@iniciofin", OdbcType.Date, 8, InicioFin)

            MyBase.AddParameter("@tiendab", OdbcType.Char, 1, Tienda)


            MyBase.FillDataSet(usp_PpalCatalogoRepetitivo, "nomsis")
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
