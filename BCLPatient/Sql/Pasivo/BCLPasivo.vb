Public Class BCLPasivo
    'mreyes 20/Febrero/2020 01:12 p.m.

    Implements IDisposable
    Private objDALpasivo As DAL.DALPasivo
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALpasivo = New DAL.DALPasivo(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALpasivo.Dispose()
            objDALpasivo = Nothing
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

    Public Function usp_PpalPasivoProveedores() As DataSet
        'mreyes 20/Febrero/2020 01:14 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalPasivoProveedores = objDALpasivo.usp_PpalPasivoProveedores()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalAsigLiquidaciones(Opcion As Integer) As DataSet
        'mreyes 26/Febrero/2020 11:32 a.m.

        Try
            'Call the data component to get all groups
            usp_PpalAsigLiquidaciones = objDALpasivo.usp_PpalAsigLiquidaciones(Opcion)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_PpalPagosProveedores(FechaIni As Date, FechaFin As Date) As DataSet
        'mreyes 21/Febrero/2020 04:32 p.m.

        Try
            'Call the data component to get all groups
            usp_PpalPagosProveedores = objDALpasivo.usp_PpalPagosProveedores(FechaIni, FechaFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_PasivoTemp(Opcion As Integer, Proveedor As String, Marca As String, IdFolio As Integer, Referenc As String, FecVenc As Date) As Boolean

        'mreyes 03/Marzo/2020   11:56 a.m.


        Try

            usp_Captura_PasivoTemp = objDALpasivo.usp_Captura_PasivoTemp(Opcion, Proveedor, Marca, IdFolio, Referenc, FecVenc)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraSeriesReciboMYSQL(Sucursal As String, FactProv As String) As Boolean

        'mreyes 22/Junio/2021   12:57 p.m.


        Try

            usp_GeneraSeriesReciboMYSQL = objDALpasivo.usp_GeneraSeriesReciboMYSQL(Sucursal, FactProv)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


    Public Function usp_GeneraLiquidacionesPasivo() As Boolean

        'mreyes 28/Mayo/2021    07:02 p.m.


        Try

            usp_GeneraLiquidacionesPasivo = objDALpasivo.usp_GeneraLiquidacionesPasivo()
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message,
                ExceptionErr.InnerException)
        End Try
    End Function


#End Region
End Class
