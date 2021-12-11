Imports System.Data.Odbc
'mreyes 01/Junio/2012 06:19 p.m.

Public Class DALChecador
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


    Public Function usp_TraerChecador(ByVal idchecador As String, ByVal Sucursal As String) As DataSet
        'mreyes 01/Junio/2012 07:00 p.m.
        Try
            usp_TraerChecador = New DataSet
            MyBase.SQL = "CALL usp_TraerChecador(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idchecadorb", OdbcType.SmallInt, 8, idchecador)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerChecador, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalMarcaje(ByVal IdEmpleado As Integer, ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date) As DataSet
        'mreyes 23/Junio/2012 02:03 p.m.
        Try
            usp_PpalMarcaje = New DataSet
            MyBase.SQL = "CALL usp_PpalMarcaje(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleadob", OdbcType.SmallInt, 4, IdEmpleado)
            MyBase.AddParameter("@sucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 6, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 6, IdPuesto)
            MyBase.AddParameter("@FechaIniB", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechaFinB", OdbcType.Date, 8, FechaFin)

            MyBase.FillDataSet(usp_PpalMarcaje, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_Captura_Checada(ByVal Opcion As Integer, ByVal idchecador As Integer, ByVal Fecha As Date, ByVal Hora As String, ByVal idempleado As Integer) As Boolean
        'mreyes 01/Junio/2012 07:08 p.m.
        Try

            MyBase.SQL = "CALL usp_Captura_Checada(?,?,?,?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@idchecador", OdbcType.SmallInt, 8, idchecador)
            MyBase.AddParameter("@Fecha", OdbcType.Date, 8, Fecha)
            MyBase.AddParameter("@marca", OdbcType.Char, 8, Hora)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, idempleado)


            usp_Captura_Checada = ExecuteStoredProcedure()

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerChecada(ByVal IdEmpleado As Integer, ByVal Fecha As Date) As DataSet
        'mreyes 22/Junio/2012 09:31 a.m.
        Try
            usp_TraerChecada = New DataSet
            MyBase.SQL = "CALL usp_TraerChecada(?,?)" 'Insert Query
            'Initialize the Command object
            MyBase.InitializeCommand()

            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@Fecha", OdbcType.Date, 8, Fecha)

            MyBase.FillDataSet(usp_TraerChecada, "nomsis")

            

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
