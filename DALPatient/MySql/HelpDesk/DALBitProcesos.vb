Imports System.Data.Odbc


Public Class DALBitProcesos
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

    Public Function usp_PpalBitProcesos(ByVal Opcion As Integer, ByVal Fecha As Date, ByVal FechaAntiinvent As Date) As DataSet
        'Tony Garcia - 26/Abril/2014 - 11:00 am
        Try
            usp_PpalBitProcesos = New DataSet
            MyBase.SQL = "CALL usp_PpalBitProcesos(?,?,?)"

            MyBase.InitializeCommand()
            MyBase.AddParameter("@opcion", OdbcType.Int, 1, Opcion)
            MyBase.AddParameter("@fechab", OdbcType.Date, 10, Fecha)
            MyBase.AddParameter("@fechaantiinventb", OdbcType.Date, 10, FechaAntiinvent)

            MyBase.FillDataSet(usp_PpalBitProcesos, "cipsis")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
