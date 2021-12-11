Imports System.Data.Odbc


Public Class DALNotasCC
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


    Public Function usp_TraerNotaCC(ByVal Opcion As Integer, ByVal IdFolioSuc As String, ByVal IdFolio As Integer, ByVal Tipo As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_TraerNotaCC = New DataSet
            MyBase.SQL = "CALL usp_TraerNotaCC(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 8, Opcion)
            MyBase.AddParameter("@idfoliosucb", OdbcType.Char, 8, IdFolioSuc)
            MyBase.AddParameter("@idfolio", OdbcType.Int, 8, IdFolio)
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, Tipo)

            MyBase.FillDataSet(usp_TraerNotaCC, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerUltFolioNotaCC(ByVal Tipo As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_TraerUltFolioNotaCC = New DataSet
            MyBase.SQL = "CALL usp_TraerUltFolioNotaCC(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, Tipo)

            MyBase.FillDataSet(usp_TraerUltFolioNotaCC, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalNotasCC(ByVal Folio As Integer, ByVal IdFolioSucIni As String, ByVal IdFolioSucFin As String, _
                                    ByVal Estatus As String, ByVal Proveedor As String, ByVal FechaIni As String, ByVal FechaFin As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_PpalNotasCC = New DataSet
            MyBase.SQL = "CALL usp_PpalNotasCC(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@foliob", OdbcType.Int, 10, Folio)
            MyBase.AddParameter("@idfoliosucinib", OdbcType.Char, 10, IdFolioSucIni)
            MyBase.AddParameter("@idfoliosucfinb", OdbcType.Char, 10, IdFolioSucFin)
            MyBase.AddParameter("@estatusb", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@proveedorb", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@fechainib", OdbcType.Char, 10, FechaIni)
            MyBase.AddParameter("@fechafinb", OdbcType.Char, 10, FechaFin)

            MyBase.FillDataSet(usp_PpalNotasCC, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_Captura_NotaCC(ByVal Opcion As Integer, ByVal Section As DataSet) As Boolean
        'Tony Garcia 29/Junio/2013 11:23 a.m.
        Try
            MyBase.SQL = "CALL usp_Captura_NotaCC(?,?,?,?,?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcionb", OdbcType.Int, 10, Opcion)
            MyBase.AddParameter("@foliob", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("folio"))
            MyBase.AddParameter("@idfoliosucb", OdbcType.Char, 8, Section.Tables(0).Rows(0).Item("idfoliosuc"))
            MyBase.AddParameter("@cvesucb", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("cvesuc"))
            MyBase.AddParameter("@fechab", OdbcType.Date, 10, Section.Tables(0).Rows(0).Item("fecha"))
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("tipo"))
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, Section.Tables(0).Rows(0).Item("status"))
            MyBase.AddParameter("@aplicadab", OdbcType.Date, 10, Section.Tables(0).Rows(0).Item("aplicada"))
            MyBase.AddParameter("@idmotivob", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idmotivo"))
            MyBase.AddParameter("@importeb", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("importe"))
            MyBase.AddParameter("@ivab", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("iva"))
            MyBase.AddParameter("@imptotalb", OdbcType.Double, 9, Section.Tables(0).Rows(0).Item("imptotal"))
            MyBase.AddParameter("@descripb", OdbcType.Char, 150, Section.Tables(0).Rows(0).Item("descrip"))
            MyBase.AddParameter("@idusuariob", OdbcType.Int, 10, Section.Tables(0).Rows(0).Item("idusuario"))

            usp_Captura_NotaCC = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaEstatusNotaCC(ByVal IdFolio As Integer, ByVal Tipo As String, ByVal Estatus As String, _
                                               ByVal Aplicada As DateTime, ByVal IdMotivo As Integer) As Boolean
        'Tony Garcia 29/Junio/2013 11:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaEstatusNotaCC(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@foliob", OdbcType.Int, 10, IdFolio)
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, Tipo)
            MyBase.AddParameter("@statusb", OdbcType.Char, 2, Estatus)
            MyBase.AddParameter("@aplicadab", OdbcType.DateTime, 10, Aplicada)
            MyBase.AddParameter("@idmotivob", OdbcType.Int, 10, IdMotivo)

            usp_ActualizaEstatusNotaCC = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUnMotivosRem(ByVal idmotivo As String) As DataSet
        'Tony Garcia 29/Junio/2013 10:00 a.m.
        Try
            usp_TraerUnMotivosRem = New DataSet
            MyBase.SQL = "CALL usp_TraerUnMotivosRem(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, idmotivo)

            MyBase.FillDataSet(usp_TraerUnMotivosRem, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaFacturaNotaCC(ByVal IdFolioSuc As String, ByVal Tipo As String, ByVal Importe As Decimal, ByVal IdMotivo As Integer, _
                                               ByVal dsctopp As Integer, ByVal dscto01 As Integer, ByVal dscto02 As Integer, _
                                               ByVal dscto03 As Integer, ByVal dscto04 As Integer, ByVal dscto05 As Integer) As Boolean
        'Tony Garcia 11/Julio/2013 10:23 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaFacturaNotaCC(?,?,?,?,?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idfoliosucb", OdbcType.Char, 8, IdFolioSuc)
            MyBase.AddParameter("@tipob", OdbcType.Char, 2, Tipo)
            MyBase.AddParameter("@importeb", OdbcType.Double, 9, Importe)
            MyBase.AddParameter("@idmotivob", OdbcType.SmallInt, 2, IdMotivo)
            MyBase.AddParameter("@dsctopp", OdbcType.SmallInt, 3, dsctopp)
            MyBase.AddParameter("@dscto01", OdbcType.SmallInt, 3, dscto01)
            MyBase.AddParameter("@dscto02", OdbcType.SmallInt, 3, dscto02)
            MyBase.AddParameter("@dscto03", OdbcType.SmallInt, 3, dscto03)
            MyBase.AddParameter("@dscto04", OdbcType.SmallInt, 3, dscto04)
            MyBase.AddParameter("@dscto05", OdbcType.SmallInt, 3, dscto05)

            usp_ActualizaFacturaNotaCC = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerDevProvImporte(ByVal Sucursal As String, ByVal IdFolioSuc As String, ByVal DevoProv As String) As DataSet
        'Tony Garcia 17/Octubre/2013 10:00 a.m.
        Try
            usp_TraerDevProvImporte = New DataSet
            MyBase.SQL = "CALL usp_TraerDevProvImporte(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@foliosucb", OdbcType.Char, 8, IdFolioSuc)
            MyBase.AddParameter("@devoprovb", OdbcType.Char, 6, DevoProv)

            MyBase.FillDataSet(usp_TraerDevProvImporte, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
