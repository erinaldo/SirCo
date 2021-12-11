

Public Class DALCipSIS
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

    Public Function ObtenSalarioDiario() As DataSet
        Try
            ObtenSalarioDiario = New DataSet
            MyBase.SQL = "SELECT * FROM SUCURSAL"
            'MyBase.SQL = "SELECT * FROM EMPLEADOS " 'EMPLEADO_ID, NUMERO, NOMBRE_COMPLETO, APELLIDO_PATERNO," & _
            '"APELLIDO_MATERNO, NOMBRES, SALARIO_DIARIO, SALARIO_INTEG FROM EMPLEADOS"
            MyBase.InitializeCommand()
            'Fill the DataSet
            MyBase.FillDataSet(ObtenSalarioDiario, "microsip")
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try

    End Function


    Public Function CargaMaxID() As Integer
        Try
            Dim Doctor As New DataSet
            MyBase.SQL = "usp_SelMaxDeduccion"
            'Fill the DataSet
            MyBase.FillDataSet(Doctor, "Deduccion")
            CargaMaxID = Val(Doctor.Tables(0).Rows(0).Item("MaxID").ToString) + 1
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
            ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
