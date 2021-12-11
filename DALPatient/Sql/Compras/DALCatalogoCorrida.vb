Imports System.Data.Odbc
Public Class DALCatalogoCorrida
    Inherits DALBase
    Sub New(ByVal ConString As String)
        MyBase.New(ConString)
    End Sub

    Public Shadows Sub Dispose()
        MyBase.Dispose()
    End Sub

    Public Function usp_Captura_Corrida(ByVal marca As String, ByVal estilon As Integer, ByVal corrida As String, ByVal peso As Decimal, ByVal alto As Decimal,
                               ByVal frente As Decimal, ByVal fondo As Decimal, ByVal matsuela As Integer, ByVal matcal As Integer)
        Try
            MyBase.SQL = "usp_Captura_Corrida"
            MyBase.InitializeCommand()
            MyBase.ClearParameters()
            AddParameter("@marca", SqlDbType.VarChar, 3, marca)
            AddParameter("@estilon", SqlDbType.Int, 16, estilon)
            AddParameter("@corrida", SqlDbType.VarChar, 1, corrida)
            AddParameter("@peso", SqlDbType.Decimal, 11, peso)
            AddParameter("@alto", SqlDbType.Decimal, 11, alto)
            AddParameter("@frente", SqlDbType.Decimal, 11, frente)
            AddParameter("@fondo", SqlDbType.Decimal, 11, fondo)
            AddParameter("@masuela", SqlDbType.Int, 16, matsuela)
            AddParameter("@macalza", SqlDbType.Int, 16, matcal)
            usp_Captura_Corrida = ExecuteStoredProcedure()
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try

    End Function
    Public Function usp_TraerMaterial(ByVal mat As String) As DataSet
        'Tony Garcia - 28/Febrero/2013 01:22 p.m.
        Try
            usp_TraerMaterial = New DataSet
            MyBase.SQL = "usp_TraerMateriales"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@Opcion", OdbcType.VarChar, 50, mat)

            MyBase.FillDataSet(usp_TraerMaterial, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function
End Class
