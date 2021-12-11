Imports System.Data.Odbc
Public Class DALHuellasEmpleado
    'Tony Garcia - 28/Sept/2012 - 11:20 a.m.
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

    Public Function usp_TraerChecadores() As DataSet
        'Tony Garcia - 28/Septiembre/2012 - 60:35 p.m.
        Try
            usp_TraerChecadores = New DataSet
            MyBase.SQL = "CALL usp_TraerChecadores()"

            MyBase.InitializeCommand()

            MyBase.FillDataSet(usp_TraerChecadores, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerNomEmpleado(ByVal idEmpleado As Integer, ByVal ApPaterno As String, ByVal apMaterno As String, ByVal Nombre As String, ByVal Estatus As String) As DataSet
        'Tony Garcia - 28/Sept/2012 - 6:30 p.m.
        Try
            usp_TraerNomEmpleado = New DataSet
            MyBase.SQL = "CALL usp_TraerNomEmpleado(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idEmpleado", OdbcType.Int, 16, idEmpleado)
            MyBase.AddParameter("@ApPaterno", OdbcType.Char, 30, ApPaterno)
            MyBase.AddParameter("@ApMaterno", OdbcType.Char, 30, apMaterno)
            MyBase.AddParameter("@Nombre", OdbcType.Char, 30, Nombre)
            MyBase.AddParameter("@estatus", OdbcType.Char, 1, Estatus)

            MyBase.FillDataSet(usp_TraerNomEmpleado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_EliminarHuellas(ByVal IdChecador As Integer)
        'Tony Garcia - 01/Octubre/2012 - 3:30 p.m.
        Try
            usp_EliminarHuellas = New DataSet
            MyBase.SQL = "CALL usp_EliminarHuellas(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idChecador", OdbcType.Int, 16, IdChecador)
         
            MyBase.FillDataSet(usp_EliminarHuellas, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerChecador(ByVal IdChecador As Integer, ByVal Sucursal As String) As DataSet

        Try
            usp_TraerChecador = New DataSet
            MyBase.SQL = "CALL usp_TraerChecador(?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idchecador", OdbcType.Int, 4, IdChecador)
            MyBase.AddParameter("@sucursalb", OdbcType.Char, 2, Sucursal)

            MyBase.FillDataSet(usp_TraerChecador, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Huella(ByVal IdChecador As Integer, ByVal IdEmpleado As Integer, _
                                        ByVal IdDedo As Integer, ByVal Template() As Byte, ByVal Fecha As DateTime)
        'Tony Garcia - 01/Octubre/2012 - 10:05 a.m.
        Try
            usp_Captura_Huella = New DataSet
            MyBase.SQL = "CALL usp_Captura_Huella(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@IdChecador", OdbcType.Int, 6, IdChecador)
            MyBase.AddParameter("@IdEmpleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@IdDedo", OdbcType.Int, 4, IdDedo)
            MyBase.AddParameter("@Template", OdbcType.Binary, 700, Template)
            MyBase.AddParameter("@Fecha", OdbcType.DateTime, 8, Fecha)

            MyBase.FillDataSet(usp_Captura_Huella, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerHuellasEmp(ByVal IdEmpleado As Integer)
        'Tony Garcia - 05/Octubre/2012 - 4:00 p.m.
        Try
            usp_TraerHuellasEmp = New DataSet
            MyBase.SQL = "CALL usp_TraerHuellasEmp(?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Idempleado", OdbcType.Int, 4, IdEmpleado)

            MyBase.FillDataSet(usp_TraerHuellasEmp, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
