Imports System.Data.Odbc
'mreyes 11/Junio/2012 10:13 a.m.

Public Class DALCatalogoGastos
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



    Public Function usp_Captura_Gastos(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'mreyes 11/Junio/2012 10:14 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_Gastos(?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@foliob", OdbcType.Int, 8, Section.Tables(0).Rows(0).Item("folio"))
            MyBase.AddParameter("@cantidadB", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("cantidad"))
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("sucursal"))
            MyBase.AddParameter("@fechaB", OdbcType.Char, 10, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@idgastosB", OdbcType.Int, 4, Section.Tables(0).Rows(0).Item("idgasto"))
            MyBase.AddParameter("@solicitaB", OdbcType.Int, 4, Section.Tables(0).Rows(0).Item("solicita"))
            MyBase.AddParameter("@statusB", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@comentariosB", OdbcType.Text, 1000, Section.Tables(0).Rows(0).Item("comentarios"))
            MyBase.AddParameter("@usuarioB", OdbcType.Int, 4, Section.Tables(0).Rows(0).Item("usuario"))
            MyBase.AddParameter("@fumb", OdbcType.DateTime, 19, Section.Tables(0).Rows(0).Item("fum"))
            MyBase.AddParameter("@foliosucb", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("foliosuc"))
         
            usp_Captura_Gastos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIdFolioGasto(ByVal CveSucursal As String) As DataSet
        'mreyes 20/Enero/2012 11:29 a.m.
        Try
            usp_TraerIdFolioGasto = New DataSet
            MyBase.SQL = "CALL usp_TraerIdFolioGasto(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, CveSucursal)

            MyBase.FillDataSet(usp_TraerIdFolioGasto, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerGastos(ByVal folio As Integer) As DataSet
        'mreyes 11/Junio/2012 12:29 p.m.
        Try
            usp_TraerGastos = New DataSet
            MyBase.SQL = "CALL usp_TraerGastos(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@folio", OdbcType.Int, 16, folio)

            MyBase.FillDataSet(usp_TraerGastos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDetGastos() As DataSet
        'mreyes 11/Junio/2012 12:29 p.m.
        Try
            usp_TraerDetGastos = New DataSet
            MyBase.SQL = "CALL usp_TraerDetGastos()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerDetGastos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoFolioGastos() As DataSet
        'raul reyes

        Try
            usp_TraerUltimoFolioGastos = New DataSet
            MyBase.SQL = "CALL usp_TraerUltimoFolioGastos()"
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerUltimoFolioGastos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalCatalogoGastos(ByVal folio As Integer, ByVal Sucursal As String, ByVal idgasto As Integer, ByVal cantidadini As Double, ByVal cantidadfin As Double, _
                                           ByVal Solicita As Integer, ByVal status As String, ByVal fechaIni As String, ByVal fechaFin As String, ByVal foliosucini As String, ByVal foliosucfin As String) As DataSet
        'mreyes 11/Junio/2012 10:20 a.m.
        Try


            usp_PpalCatalogoGastos = New DataSet
            MyBase.SQL = "CALL usp_PpalCatalogoGastos(?,?,?,?,?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@folio", OdbcType.Int, 8, folio)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idgasto", OdbcType.Int, 4, idgasto)
            MyBase.AddParameter("@cantidadini", OdbcType.Double, 9, cantidadini)
            MyBase.AddParameter("@cantidadfin", OdbcType.Double, 9, cantidadfin)
            MyBase.AddParameter("@solicita", OdbcType.Int, 4, Solicita)
            MyBase.AddParameter("@status", OdbcType.Char, 2, status)
            MyBase.AddParameter("@fechaini", OdbcType.Char, 10, fechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Char, 10, fechaFin)
            MyBase.AddParameter("@foliosucini", OdbcType.Char, 8, foliosucini)
            MyBase.AddParameter("@foliosucfin", OdbcType.Char, 8, foliosucfin)


            MyBase.FillDataSet(usp_PpalCatalogoGastos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarEstatusGastos(ByVal Opcion As Integer, ByVal Folio As Integer, ByVal Estatus As String, ByVal Usuario As Integer, _
                                                 ByVal Fummodif As DateTime) As Boolean
        'mreyes 11/Junio/2012 10:14 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarEstatusGastos(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@foliob", OdbcType.Int, 8, Folio)
            MyBase.AddParameter("@statusB", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@usuarioB", OdbcType.Int, 4, Usuario)
            MyBase.AddParameter("@fummodifb", OdbcType.DateTime, 19, Fummodif)

            usp_ActualizarEstatusGastos = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
