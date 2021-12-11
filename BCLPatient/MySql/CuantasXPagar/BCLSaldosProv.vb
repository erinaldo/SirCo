Public Class BCLSaldosProv

    Implements IDisposable
    Private objDALSaldosProv As DAL.DALSaldosProv
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable 
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALSaldosProv = New DAL.DALSaldosProv(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALSaldosProv.Dispose()
            objDALSaldosProv = Nothing
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

    Public Function usp_PpalSaldosProv(ByVal Opcion As Integer, ByVal Proveedor As String, _
                                       ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Importados As String) As DataSet
        Try
            usp_PpalSaldosProv = objDALSaldosProv.usp_PpalSaldosProv(Opcion, Proveedor, Marca, Ejercicio, Importados)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosFactoraje(ByVal Opcion As Integer, ByVal Proveedor As String, _
                                   ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 15/Octubre/2014 04:11p.m.
        Try

            usp_PpalSaldosFactoraje = objDALSaldosProv.usp_PpalSaldosFactoraje(Opcion, Proveedor, Marca, Ejercicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosProvORIPedido(ByVal Opcion As Integer, ByVal Proveedor As String, _
                       ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 11/Septiembre/2015  07:23 p.m.
        Try

            usp_PpalSaldosProvORIPedido = objDALSaldosProv.usp_PpalSaldosProvORIPedido(Opcion, Proveedor, Marca, Ejercicio, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalSaldosProvORI(ByVal Opcion As Integer, ByVal Proveedor As String, _
                           ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 01/Diciembre/2014   11:43 a.m.
        Try

            usp_PpalSaldosProvORI = objDALSaldosProv.usp_PpalSaldosProvORI(Opcion, Proveedor, Marca, Ejercicio, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalSaldosFactorajeORI(ByVal Opcion As Integer, ByVal Proveedor As String, _
                               ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 22/Octubre/2014 04:46 p.m.
        Try

            usp_PpalSaldosFactorajeORI = objDALSaldosProv.usp_PpalSaldosFactorajeORI(Opcion, Proveedor, Marca, Ejercicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalSaldosFactorajeBANCOEjercido(ByVal Opcion As Integer, ByVal Proveedor As String, _
                           ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 05/Diciembre/2014   01:17 p.m.
        Try

            usp_PpalSaldosFactorajeBANCOEjercido = objDALSaldosProv.usp_PpalSaldosFactorajeBANCOEjercido(Opcion, Proveedor, Marca, Ejercicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSaldosFactorajeBANCO(ByVal Opcion As Integer, ByVal Proveedor As String, _
                           ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 22/Octubre/2014 05:53 p.m.
        Try

            usp_PpalSaldosFactorajeBANCO = objDALSaldosProv.usp_PpalSaldosFactorajeBANCO(Opcion, Proveedor, Marca, Ejercicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosProvDIADiferidos(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Opcion As Integer, ByVal Proveedor As String, _
                   ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 05/Diciembre/2014   06:02 p.m.
        Try

            usp_PpalSaldosProvDIADiferidos = objDALSaldosProv.usp_PpalSaldosProvDIADiferidos(FechaIni, FechaFin, Opcion, Proveedor, Marca, Ejercicio, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosProvDIA(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Opcion As Integer, ByVal Proveedor As String, _
                       ByVal Marca As String, ByVal Ejercicio As Integer, ByVal Tipo As String) As DataSet
        'mreyes 01/Diciembre/2014   11:56 a.m.
        Try

            usp_PpalSaldosProvDIA = objDALSaldosProv.usp_PpalSaldosProvDIA(FechaIni, FechaFin, Opcion, Proveedor, Marca, Ejercicio, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_PpalSaldosFactorajeDIAEjercido(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Opcion As Integer, ByVal Proveedor As String, _
                       ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 05/Diciembre/2014   01:20 p.m.
        Try

            usp_PpalSaldosFactorajeDIAEjercido = objDALSaldosProv.usp_PpalSaldosFactorajeDIAEjercido(FechaIni, FechaFin, Opcion, Proveedor, Marca, Ejercicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalSaldosFactorajeDIA(ByVal FechaIni As DateTime, ByVal FechaFin As DateTime, ByVal Opcion As Integer, ByVal Proveedor As String, _
                           ByVal Marca As String, ByVal Ejercicio As Integer) As DataSet
        'mreyes 23/Octubre/2014 01:14 p.m.
        Try

            usp_PpalSaldosFactorajeDIA = objDALSaldosProv.usp_PpalSaldosFactorajeDIA(FechaIni, FechaFin, Opcion, Proveedor, Marca, Ejercicio)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
    Public Function usp_TraerFactSaldosProv(ByVal Proveedor As String, ByVal Marca As String,
                                       ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String) As DataSet
        Try
            usp_TraerFactSaldosProv = objDALSaldosProv.usp_TraerFactSaldosProv(Proveedor, Marca, FecIni, FecFin, Importados)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactSaldosProvORIDiferidos(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                               ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String, ByVal Tipo As String) As DataSet
        'mreyes 05/Diciembre/2014   06:09 p.m.
        Try
            usp_TraerFactSaldosProvORIDiferidos = objDALSaldosProv.usp_TraerFactSaldosProvORIDiferidos(Opcion, Proveedor, Marca, FecIni, FecFin, Importados, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_TraerFactSaldosProvORI(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                                   ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String, ByVal Tipo As String) As DataSet
        'mreyes 01/Diciembre/2014   12:27 p.m.
        Try
            usp_TraerFactSaldosProvORI = objDALSaldosProv.usp_TraerFactSaldosProvORI(Opcion, Proveedor, Marca, FecIni, FecFin, Importados, Tipo)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactSaldosFactoraje(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                                   ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String) As DataSet
        'mreyes 16/Octubre/2014 04:40 p.m.
        Try
            usp_TraerFactSaldosFactoraje = objDALSaldosProv.usp_TraerFactSaldosFactoraje(Opcion, Proveedor, Marca, FecIni, FecFin, Importados)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_TraerFactSaldosFactorajeEjercido(ByVal Opcion As Integer, ByVal Proveedor As String, ByVal Marca As String, _
                               ByVal FecIni As Date, ByVal FecFin As Date, ByVal Importados As String) As DataSet
        'mreyes 05/Diciembre/2014   01:22 p.m.
        Try
            usp_TraerFactSaldosFactorajeEjercido = objDALSaldosProv.usp_TraerFactSaldosFactorajeEjercido(Opcion, Proveedor, Marca, FecIni, FecFin, Importados)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
