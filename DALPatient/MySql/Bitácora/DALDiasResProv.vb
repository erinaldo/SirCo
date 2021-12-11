Imports System.Data.Odbc

Public Class DALDiasResProv
    'Tony Garcia - 07/Diciembre/2012 12:45 p.m.
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

    Public Function usp_PpalDiasResProv(ByVal Proveedor As String, ByVal FecIni As String, ByVal FecFin As String)
        'Tony Garcia - 07/Diciembre/2012 - 1:10 p.m
        Try
            usp_PpalDiasResProv = New DataSet
            MyBase.SQL = "CALL usp_PpalDiasResProv(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@feciniB", OdbcType.Char, 10, FecIni)
            MyBase.AddParameter("@fecfinB", OdbcType.Char, 10, FecFin)

            MyBase.FillDataSet(usp_PpalDiasResProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizaDiasResProv(ByVal Proveedor As String, ByVal Marca As String, _
                                             ByVal Estilon As String, ByVal DiasResurt As Integer) As Boolean
        'Tony Garcia - 07/Diciembre/2012 - 02:00 p.m.
        Try
            MyBase.SQL = "CALL usp_ActualizaDiasResProv(?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            'Add a Parameter to the Parameters collection
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@diasresurtidoB", OdbcType.Int, 4, DiasResurt)

            'Execute the stored procedure
            usp_ActualizaDiasResProv = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_CapturaMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String, _
                                                   ByVal DiasRespuesta As Integer, ByVal UltimoRes As String, ByVal DiasResurtido As Integer) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:00 p.m.
        Try

            MyBase.SQL = "CALL usp_CapturaMarcaEstilonDiasRes(?,?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)
            MyBase.AddParameter("@diasrespuestaB", OdbcType.Int, 3, DiasRespuesta)
            MyBase.AddParameter("@ultimoresurtidoB", OdbcType.Char, 10, UltimoRes)
            MyBase.AddParameter("@diasresurtidoB", OdbcType.Int, 3, DiasResurtido)


            usp_CapturaMarcaEstilonDiasRes = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_EliminarMarcaEstilonDiasRes(ByVal Proveedor As String, ByVal Marca As String, ByVal Estilon As String) As Boolean
        'Tony Garcia -  18/Febrero/2013 - 07:35 p.m.
        Try

            MyBase.SQL = "CALL usp_EliminarMarcaEstilonDiasRes(?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedorB", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@marcaB", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@estilonB", OdbcType.Char, 7, Estilon)

            usp_EliminarMarcaEstilonDiasRes = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
