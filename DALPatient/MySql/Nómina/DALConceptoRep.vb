Imports System.Data.Odbc
'miguel perez, tony garcia 31/Agosto/2012 12:05 p.m.

Public Class DALConceptoRep
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

    Public Function usp_PpalConceptoReporte(ByVal idPeriodo As String, ByVal TipoNom As String, ByVal IdEmpleado As Integer, _
                                       ByVal Sucursal As String, ByVal IdDepto As Integer, ByVal IdPuesto As Integer, ByVal ClaveConcepto As String) As DataSet
        'miguel perez, tony garcia 31/Agosto/2012 01:40 p.m.

        Try
            usp_PpalConceptoReporte = New DataSet
            MyBase.SQL = "CALL usp_PpalConceptoReporte(?,?,?,?,?,?,?)"
            'Initialize the Command object
            MyBase.InitializeCommand()
            MyBase.AddParameter("@idPeridoB", OdbcType.Char, 250, idPeriodo)
            MyBase.AddParameter("@tiponomB", OdbcType.Char, 1, TipoNom)
            MyBase.AddParameter("@idempleadoB", OdbcType.Int, 16, IdEmpleado)
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@IdDeptoB", OdbcType.Int, 4, IdDepto)
            MyBase.AddParameter("@IdPuestoB", OdbcType.Int, 4, IdPuesto)
            MyBase.AddParameter("@ClaveConceptoB", OdbcType.Char, 5, ClaveConcepto)

            MyBase.FillDataSet(usp_PpalConceptoReporte, "nomsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class