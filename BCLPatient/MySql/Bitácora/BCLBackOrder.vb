Public Class BCLBackOrder

    Implements IDisposable
    Private objDALBackOrder As DAL.DALBackOrder
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable 
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALBackOrder = New DAL.DALBackOrder(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALBackOrder.Dispose()
            objDALBackOrder = Nothing
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

    Public Function usp_PpalBackOrder(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Sucursal As String, _
                                    ByVal AnioIni As Integer, ByVal MesIni As Integer, ByVal AnioFin As Integer, ByVal MesFin As Integer, _
                                    ByVal IdDivision As Integer, _
                                    ByVal IdDepto As Integer, ByVal DescripFamilia As String, ByVal DescripLinea As String, _
                                    ByVal DescripL1 As String, ByVal DescripL2 As String, ByVal DescripL3 As String, ByVal DescripL4 As String, _
                                    ByVal DescripL5 As String, ByVal DescripL6 As String, ByVal Marca As String, ByVal Modelo As String, _
                                    ByVal FecIni As Date, ByVal FecFin As Date, ByVal S1 As Integer, _
                                    ByVal S2 As String, ByVal S3 As String, ByVal S4 As String, ByVal S5 As String) As DataSet
        'Tony Garcia - 31/Mar/2014 - 11:00 am

        Try
            usp_PpalBackOrder = objDALBackOrder.usp_PpalBackOrder(Opcion, Proveedor, Sucursal, AnioIni, MesIni, AnioFin, MesFin, IdDivision, IdDepto, DescripFamilia, DescripLinea, DescripL1, _
                                                                  DescripL2, DescripL3, DescripL4, DescripL5, DescripL6, Marca, Modelo, FecIni, FecFin, S1, S2, S3, S4, S5)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerSemanasBackOrder(ByVal FecIni As Date, ByVal FecFin As Date) As DataSet
        Try
            usp_TraerSemanasBackOrder = objDALBackOrder.usp_TraerSemanasBackOrder(FecIni, FecFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFechasSemana(ByVal Anio As Integer, ByVal Semana As Integer) As DataSet
        Try
            usp_TraerFechasSemana = objDALBackOrder.usp_TraerFechasSemana(Anio, Semana)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
