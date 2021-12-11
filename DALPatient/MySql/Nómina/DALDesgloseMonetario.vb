Imports System.Data.Odbc
Public Class DALDesgloseMonetario
    'Tony Garcia - 19/Sept/2012 - 09:55 a.m.
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

    Public Function usp_PpalDesgloseMon(ByVal IdEmpleado As Integer, ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
                                        ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer) As DataSet
        'Tony Garcia - 19/Septiembre/2012 10:00 a.m.
        Try
            '(idempleadoB smallint(4), idperiodoB smallint(4),  TipoNomB char(1),
            '                               sucursalB char(2), iddeptoB smallint(4), idpuestoB smallint(4)

            usp_PpalDesgloseMon = New DataSet
            MyBase.SQL = "CALL usp_PpalDesgloseMon(?,?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@idPeridoB", OdbcType.Int, 250, IdPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)


            MyBase.FillDataSet(usp_PpalDesgloseMon, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
