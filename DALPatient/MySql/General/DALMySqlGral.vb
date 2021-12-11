Imports System.Data.Odbc


Public Class DALMySqlGral
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
    

    Public Function usp_TraerUnCampo(ByVal Sentencia As String) As DataSet
        Try
            usp_TraerUnCampo = New DataSet
            MyBase.SQL = "CALL usp_TraerUnCampo(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Sentencia", OdbcType.VarChar, 1000, Sentencia)
            MyBase.FillDataSet(usp_TraerUnCampo, "persis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ufn_RellenaCombo(ByVal Opcion As String, ByVal SqlWhere As String) As DataSet
        Try
            ufn_RellenaCombo = New DataSet
            MyBase.SQL = "SELECT ufn_RellenaCombo(?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.VarChar, 30, Opcion)
            MyBase.AddParameter("@SqlWhere", OdbcType.VarChar, 500, SqlWhere)
            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(ufn_RellenaCombo, "x")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ComboPeriodo(ByVal IdFrecPago As Integer) As DataSet
        Try
            usp_ComboPeriodo = New DataSet
            MyBase.SQL = "CALL usp_ComboPeriodo(?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_ComboPeriodo, "nomsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerPeriodoNomina(ByVal IdFrecPago As Integer) As DataSet
        Try
            usp_TraerPeriodoNomina = New DataSet
            MyBase.SQL = "CALL usp_TraerPeriodoNomina(?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_TraerPeriodoNomina, "nomsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoPeriodo(ByVal IdFrecPago As Integer, ByVal Estatus As String, ByVal IdPeriodo As Integer) As DataSet
        'mreyes 05/Julio/2012 10:52 a.m.
        Try
            usp_TraerUltimoPeriodo = New DataSet
            MyBase.SQL = "CALL usp_TraerUltimoPeriodo(?,?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdFrecPago", OdbcType.Int, 16, IdFrecPago)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)
            MyBase.AddParameter("@idperiodo", OdbcType.Int, 16, IdPeriodo)
            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_TraerUltimoPeriodo, "x")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ufn_Consultas(ByVal Opcion As String, ByVal SqlWhere As String) As DataSet
        'mreyes 23/Febrero/2012 04:54 p.m.
        Try
            ufn_Consultas = New DataSet
            MyBase.SQL = "SELECT ufn_Consultas(?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.VarChar, 30, Opcion)
            MyBase.AddParameter("@SqlWhere", OdbcType.VarChar, 1000, SqlWhere)
            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(ufn_Consultas, "x")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function ufn_TraeSqlBuscar(ByVal Opcion As String, ByVal SqlWhere As String) As String
        'mreyes 23/Febrero/2012 04:58 p.m.

        Try
            Dim ObjDataSet As Data.DataSet

            ufn_TraeSqlBuscar = ""

            ObjDataSet = ufn_Consultas(Opcion, SqlWhere)

            If ObjDataSet.Tables(0).Rows.Count > 0 Then
                ufn_TraeSqlBuscar = ObjDataSet.Tables(0).Rows(0).Item(0).ToString
            End If


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try

    End Function


    Public Function usp_TraerSucursalInv(ByVal Sucursal As String) As DataSet
        'mreyes 18/Junio/2015   01:04 p.m.
        Try
            usp_TraerSucursalInv = New DataSet
            MyBase.SQL = "CALL usp_TraerSucursalInv(?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.VarChar, 2, Sucursal)

            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_TraerSucursalInv, "cipsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescripcion(ByVal Opcion As String, ByVal Campo As String, ByVal Campo1 As String) As DataSet
        'mreyes 28/Febrero/2012 10:22 a.m.
        Try
            usp_TraerDescripcion = New DataSet
            MyBase.SQL = "CALL usp_TraerDescripcion(?,?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.VarChar, 3, Opcion)
            MyBase.AddParameter("@Campob", OdbcType.VarChar, 60, Campo)
            MyBase.AddParameter("@Campo1b", OdbcType.VarChar, 60, Campo1)

            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_TraerDescripcion, "cipsis")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAutorizacion(ByVal Opcion As String, ByVal Campo As String, ByVal Campo1 As String) As DataSet
        'mreyes 18/Agosto/2014  04:47 p.m.
        Try
            usp_TraerAutorizacion = New DataSet
            MyBase.SQL = "CALL usp_TraerAutorizacion(?,?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.VarChar, 3, Opcion)
            MyBase.AddParameter("@Campob", OdbcType.VarChar, 60, Campo)
            MyBase.AddParameter("@Campo1b", OdbcType.VarChar, 60, Campo1)

            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_TraerAutorizacion, "credito")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFolio(ByVal Opcion As String, ByVal Campo As String) As DataSet
        'mreyes 28/Febrero/2012 10:22 a.m.
        Try
            usp_TraerFolio = New DataSet
            MyBase.SQL = "CALL usp_TraerFolio(?,?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.VarChar, 3, Opcion)
            MyBase.AddParameter("@Campob", OdbcType.VarChar, 60, Campo)

            '            MyBase.ExecuteStoredProcedure()

            MyBase.FillDataSet(usp_TraerFolio, "Folio")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerIVA() As DataSet
        'mreyes 28/Febrero/2012 01:57 p.m.
        Try
            usp_TraerIVA = New DataSet
            MyBase.SQL = "CALL usp_TraerIVA();"

            MyBase.InitializeCommand()
            MyBase.FillDataSet(usp_TraerIVA, "parametros")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerParame_Det(ByVal Clave As String) As DataSet
        'mreyes 23/Marzo/2012 10:09 a.m.
        Try
            usp_TraerParame_Det = New DataSet
            MyBase.SQL = "CALL usp_TraerParame_Det(?);"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@claveB", OdbcType.VarChar, 8, Clave)
            MyBase.FillDataSet(usp_TraerParame_Det, "parametros")


        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarParameDet(ByVal Clave As String, ByVal Valor As String) As Boolean
        'mreyes 28/Septiembre/2012 11:25 a.m.
        Try
            MyBase.SQL = "CALL usp_ActualizarParameDet(?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@claveB", OdbcType.Char, 8, Clave)
            MyBase.AddParameter("@valorB", OdbcType.Char, 255, Valor)


            'Execute the stored procedure
            usp_ActualizarParameDet = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
