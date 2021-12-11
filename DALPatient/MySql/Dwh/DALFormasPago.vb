Imports System.Data.Odbc
'miguel pérez 09/Octubre/2012 10:43 a.m.

Public Class DALFormasPago
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

    Public Function usp_TraerFormasPago(ByVal Sucursal As String, ByVal FecIniA As String, ByVal FecIniB As String, ByVal IVA As Decimal, ByVal MInicio As String) As DataSet
        'miguel perez 13JUN2013

        Try
            usp_TraerFormasPago = New DataSet
            MyBase.SQL = "CALL usp_TraerFormasPago(?,?,?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@SucursalB", OdbcType.Char, 2, Sucursal)
            MyBase.AddParameter("@FecIniA", OdbcType.Char, 10, FecIniA)
            MyBase.AddParameter("@FecIniB", OdbcType.Char, 10, FecIniB)
            MyBase.AddParameter("@IVA", OdbcType.Decimal, 9, IVA)

            MyBase.AddParameter("@MInicioB", OdbcType.Char, 1, minicio)

            MyBase.FillDataSet(usp_TraerFormasPago, "dwh")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
