Imports System.Data.Odbc


Public Class DALSaldosProv
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

    Public Function usp_PpalSaldosProvDIADiferidos(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Opcion As Integer, ByVal Proveedor As String, _
                   ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 05/Diciembre/2014   06:02 p.m.
        Try
            usp_PpalSaldosProvDIADiferidos = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosProvDIADiferidos(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 30, Tipo)


            MyBase.FillDataSet(usp_PpalSaldosProvDIADiferidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalSaldosProvDIA(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Opcion As Integer, ByVal Proveedor As String, _
                       ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 23/Octubre/2014 01:17 p.m.
        Try
            usp_PpalSaldosProvDIA = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosProvDIA(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 30, Tipo)


            MyBase.FillDataSet(usp_PpalSaldosProvDIA, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosFactorajeDIAEjercido(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Opcion As Integer, ByVal Proveedor As String, _
                       ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet

        'mreyes 05/Diciembre/2014   01:20 p.m.
        Try
            usp_PpalSaldosFactorajeDIAEjercido = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosFactorajeDIAEjercido(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)

            MyBase.FillDataSet(usp_PpalSaldosFactorajeDIAEjercido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosFactorajeDIA(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Opcion As Integer, ByVal Proveedor As String, _
                           ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 23/Octubre/2014 01:17 p.m.
        Try
            usp_PpalSaldosFactorajeDIA = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosFactorajeDIA(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@FechaIni", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@FechaFin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)

            MyBase.FillDataSet(usp_PpalSaldosFactorajeDIA, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosFactorajeBANCOEjercido(ByVal Opcion As Integer, ByVal Proveedor As String, _
                           ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 05/Diciembre/2014   01:17 p.m.
        Try
            usp_PpalSaldosFactorajeBANCOEjercido = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosFactorajeBANCOEjercido(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)

            MyBase.FillDataSet(usp_PpalSaldosFactorajeBANCOEjercido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosFactorajeBANCO(ByVal Opcion As Integer, ByVal Proveedor As String, _
                               ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 22/Octubre/2014 05:53 p.m.
        Try
            usp_PpalSaldosFactorajeBANCO = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosFactorajeBANCO(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)

            MyBase.FillDataSet(usp_PpalSaldosFactorajeBANCO, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSaldosProvORIPedido(ByVal Opcion As Integer, ByVal Proveedor As String, _
                               ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet

        'mreyes 11/Septiembre/2015  07:24 p.m.
        Try
            usp_PpalSaldosProvORIPedido = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosProvORIPedido(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 30, Tipo)

            MyBase.FillDataSet(usp_PpalSaldosProvORIPedido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSaldosProvORI(ByVal Opcion As Integer, ByVal Proveedor As String, _
                                   ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 01/Diciembre/2014   11:43 a.m.
        Try
            usp_PpalSaldosProvORI = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosProvORI(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 30, Tipo)

            MyBase.FillDataSet(usp_PpalSaldosProvORI, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalSaldosFactorajeORI(ByVal Opcion As Integer, ByVal Proveedor As String, _
                                   ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 22/Octubre/2014 04:47 p.m.
        Try
            usp_PpalSaldosFactorajeORI = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosFactorajeORI(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)

            MyBase.FillDataSet(usp_PpalSaldosFactorajeORI, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function



    Public Function usp_PpalSaldosFactoraje(ByVal Opcion As Integer, ByVal Proveedor As String, _
                                       ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        Try
            usp_PpalSaldosFactoraje = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosFactoraje(?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)

            MyBase.FillDataSet(usp_PpalSaldosFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSaldosProv(ByVal Opcion As Integer, ByVal Proveedor As String, _
                                       ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Importados As String) As DataSet
        Try
            usp_PpalSaldosProv = New DataSet
            MyBase.SQL = "CALL usp_PpalSaldosProv(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Int, 8, Ejercicio)
            MyBase.AddParameter("@Importados", OdbcType.Char, 1, Importados)
            MyBase.FillDataSet(usp_PpalSaldosProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactSaldosProv(ByVal Proveedor As String, ByVal Marca As String,
                                       ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String) As DataSet
        Try
            usp_TraerFactSaldosProv = New DataSet
            MyBase.SQL = "CALL usp_TraerFactSaldosProv(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@Importados", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@Importados", OdbcType.Char, 1, Importados)

            ''MyBase.AddParameter("@Tipo", OdbcType.Char, 20, TiPO)
            MyBase.FillDataSet(usp_TraerFactSaldosProv, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFactSaldosFactorajeEjercido(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                               ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String) As DataSet

        'mreyes 05/Diciembre/2014   01:22 p.m.
        Try
            usp_TraerFactSaldosFactorajeEjercido = New DataSet
            MyBase.SQL = "CALL usp_TraerFactSaldosFactorajeEjercido(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@fecini", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@FecFin", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@Importados", OdbcType.Char, 1, Importados)
            MyBase.FillDataSet(usp_TraerFactSaldosFactorajeEjercido, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFactSaldosFactoraje(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                                   ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String) As DataSet
        'mreyes 16/Octubre/2014 04:40 p.m.
        Try
            usp_TraerFactSaldosFactoraje = New DataSet
            MyBase.SQL = "CALL usp_TraerFactSaldosFactoraje(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@fecini", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@FecFin", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@Importados", OdbcType.Char, 1, Importados)
            MyBase.FillDataSet(usp_TraerFactSaldosFactoraje, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFactSaldosProvORIDiferidos(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                           ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String, ByVal Tipo As String) As DataSet
        'mreyes 16/Octubre/2014 04:40 p.m.
        Try
            usp_TraerFactSaldosProvORIDiferidos = New DataSet
            MyBase.SQL = "CALL usp_TraerFactSaldosProvORIDiferidos(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@Importados", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@Importados", OdbcType.Char, 1, Importados)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 30, Tipo)


            MyBase.FillDataSet(usp_TraerFactSaldosProvORIDiferidos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactSaldosProvORI(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                               ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String, ByVal Tipo As String) As DataSet
        'mreyes 16/Octubre/2014 04:40 p.m.
        Try
            usp_TraerFactSaldosProvORI = New DataSet
            MyBase.SQL = "CALL usp_TraerFactSaldosProvORI(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.SmallInt, 2, Opcion)
            MyBase.AddParameter("@proveedor", OdbcType.Char, 3, Proveedor)
            MyBase.AddParameter("@Marca", OdbcType.Char, 3, Marca)
            MyBase.AddParameter("@Ejercicio", OdbcType.Date, 10, FecIni)
            MyBase.AddParameter("@Importados", OdbcType.Date, 10, FecFin)
            MyBase.AddParameter("@Importados", OdbcType.Char, 1, Importados)
            MyBase.AddParameter("@Tipo", OdbcType.Char, 30, Tipo)


            MyBase.FillDataSet(usp_TraerFactSaldosProvORI, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
