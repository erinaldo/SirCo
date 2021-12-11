Public Class BCLMySqlGral

    Implements IDisposable
    Private objDALMySqlGral As DAL.DALMySqlGral
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALMySqlGral = New DAL.DALMySqlGral(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALMySqlGral.Dispose()
            objDALMySqlGral = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region " Public Section Functions "
   


    Public Function usp_TraerUnCampo(ByVal Sentencia As String) As DataSet
        Try
            'Call the data component to get all groups
            usp_TraerUnCampo = objDALMySqlGral.usp_TraerUnCampo(Sentencia)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function ufn_RellenaCombo(ByVal Opcion As String, ByVal SqlWhere As String) As DataSet
        Try
            'Call the data component to get all groups
            ufn_RellenaCombo = objDALMySqlGral.ufn_RellenaCombo(Opcion, SqlWhere)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_ComboPeriodo(ByVal IdFrecPago As Integer) As DataSet
        'mreyes 05/Julio/2012 10:40 a.m.
        Try
            'Call the data component to get all groups
            usp_ComboPeriodo = objDALMySqlGral.usp_ComboPeriodo(IdFrecPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerPeriodoNomina(ByVal IdFrecPago As Integer) As DataSet
        'mreyes 05/Julio/2012 10:40 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerPeriodoNomina = objDALMySqlGral.usp_TraerPeriodoNomina(IdFrecPago)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerUltimoPeriodo(ByVal IdFrecPago As Integer, ByVal Estatus As String, ByVal IdPeriodo As Integer) As DataSet
        'mreyes 05/Julio/2012 10:51 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerUltimoPeriodo = objDALMySqlGral.usp_TraerUltimoPeriodo(IdFrecPago, Estatus, IdPeriodo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function ufn_Consultas(ByVal Opcion As String, ByVal SqlWhere As String) As DataSet
        Try
            'Call the data component to get all groups
            ufn_Consultas = objDALMySqlGral.ufn_Consultas(Opcion, SqlWhere)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerSucursalInv(ByVal Sucursal As String) As DataSet
        'mreyes 18/Junio/2015   01:02 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerSucursalInv = objDALMySqlGral.usp_TraerSucursalInv(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerDescripcion(ByVal Opcion As String, ByVal Campo As String, ByVal Campo1 As String) As DataSet
        'mreyes 28/Febrero/2012 10:21 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerDescripcion = objDALMySqlGral.usp_TraerDescripcion(Opcion, Campo, Campo1)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerAutorizacion(ByVal Opcion As String, ByVal Campo As String, ByVal Campo1 As String) As DataSet
        'mreyes 18/Agosto/2014  04:45 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerAutorizacion = objDALMySqlGral.usp_TraerAutorizacion(Opcion, Campo, Campo1)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function ufn_TraeSqlBuscar(ByVal Opcion As String, ByVal SqlWhere As String) As String
        'mreyes 23/Febrero/2012 05:03 p.m.

        Try

            ufn_TraeSqlBuscar = ""
            ufn_TraeSqlBuscar = objDALMySqlGral.ufn_TraeSqlBuscar(Opcion, SqlWhere)

        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try

    End Function

    Public Function usp_TraerFolio(ByVal Opcion As String, ByVal Campo As String) As DataSet
        'mreyes 28/Febrero/2012 12:08 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerFolio = objDALMySqlGral.usp_TraerFolio(Opcion, Campo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerIVA() As DataSet
        'mreyes 28/Febrero/2012 01:56 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerIVA = objDALMySqlGral.usp_TraerIVA()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerParame_Det(ByVal Clave As String) As DataSet
        'mreyes 23/Marzo/2012 10:10 a.m.
        Try
            'Call the data component to get all groups
            usp_TraerParame_Det = objDALMySqlGral.usp_TraerParame_Det(Clave)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_ActualizarParameDet(ByVal Clave As String, ByVal Valor As String) As Boolean
        'mreyes 23/Abril/2012 09:49 a.m.
        Try
            'Call the data component to delete the group
            Return objDALMySqlGral.usp_ActualizarParameDet(Clave, Valor)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
