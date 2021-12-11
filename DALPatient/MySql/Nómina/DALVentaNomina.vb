Imports System.Data.Odbc
'mreyes 23/Agosto/2012 10:02 p.m.

Public Class DALVentaNomina
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




    Public Function usp_PpalVentaNomina(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal IdEmpleado As Integer, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'mreyes 23/Agosto/2012 10:06 p.m.
        Try


            usp_PpalVentaNomina = New DataSet
            MyBase.SQL = "CALL usp_PpalVentaNomina(?,?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 16, Opcion)
            MyBase.AddParameter("@sucursal", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@idempleado", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)
            MyBase.AddParameter("@fechafin", OdbcType.Date, 8, FechaFin)
            MyBase.AddParameter("@iddepto", OdbcType.Int, 16, IdDepto)
            MyBase.AddParameter("@idpuesto", OdbcType.Int, 16, IdPuesto)

            MyBase.FillDataSet(usp_PpalVentaNomina, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalMatchTimbrado(ByVal IdPeriodo As String, ByVal FechaIni As Date) As DataSet
        'mreyes 20/Enero/2015   05:'07 p.m.
        Try


            usp_PpalMatchTimbrado = New DataSet
            MyBase.SQL = "CALL usp_PpalMatchTimbrado(?, ?)"

            MyBase.InitializeCommand()

            MyBase.AddParameter("@IDPERIODO", OdbcType.Char, 250, IdPeriodo)
            MyBase.AddParameter("@fechaini", OdbcType.Date, 8, FechaIni)



            MyBase.FillDataSet(usp_PpalMatchTimbrado, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
