Imports System.Data
Imports System.Data.SqlClient

Public Class DALImprimeTraspasos
    ''''Inherits DALOdbc
    Inherits DALBase
#Region "Constructor And Destructor"
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub
#End Region
#Region " Public Role Functions "
    Public Function usp_ImprimeTraspasos(ByVal opcion As Integer, ByVal sucursal As String, ByVal traspaso As String) As DataSet
        'Ro
        Try
            usp_ImprimeTraspasos = New DataSet
            MyBase.SQL = "usp_ImprimeTraspaso"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", SqlDbType.Int, 10, opcion)
            MyBase.AddParameter("@sucursalB", SqlDbType.VarChar, 2, sucursal)
            MyBase.AddParameter("@traspasoB", SqlDbType.VarChar, 6, traspaso)

            MyBase.FillDataSet(usp_ImprimeTraspasos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSucursalTR(ByVal sucursal As String) As DataSet
        '
        Try
            usp_TraerSucursalTR = New DataSet
            MyBase.SQL = "usp_TraerSucursalTR"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@sucursalb", SqlDbType.VarChar, 2, sucursal)


            MyBase.FillDataSet(usp_TraerSucursalTR, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
