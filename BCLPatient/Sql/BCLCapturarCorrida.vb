Public Class BCLCapturarCorrida
    Implements IDisposable
    Private objregistrar As DAL.DALCapturarCorrida
    Private disposedValue As Boolean = False        ' To detect redundant calls
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objregistrar = New DAL.DALCapturarCorrida(Constring)
    End Sub
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objregistrar.Dispose()
            objregistrar = Nothing
            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Public Function usp_Captura_Corrida(ByVal marca As String, ByVal estilon As Integer, ByVal corrida As String, ByVal peso As Decimal, ByVal alto As Decimal,
                               ByVal frente As Decimal, ByVal fondo As Decimal, ByVal matsuela As Integer, ByVal matcal As Integer) As Boolean
        Try
            'Call the data component to get all groups
            usp_Captura_Corrida = objregistrar.usp_Captura_Corrida(marca, estilon, corrida, peso, alto, frente, fondo, matsuela, matcal)
        Catch ExceptionErr As Exception
            Throw New Exception(ExceptionErr.Message,
            ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerMaterial(ByVal mat As String) As DataSet
        'Tony Garcia - 28/Febrero/2013 01:22 p.m.
        Try
            'Call the data component to get all groups
            usp_TraerMaterial = objregistrar.usp_TraerMaterial(mat)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

End Class
