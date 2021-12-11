Public Class BCLDetFactProv
    ''Tony Garcia 03/Noviembre/2012 - 04:45 p.m.
    Implements IDisposable
    Private objDALDetFactProv As DAL.DALDetFactProv
    Private disposedValue As Boolean = False        ' To detect redundant calls

#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALDetFactProv = New DAL.DALDetFactProv(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALDetFactProv.Dispose()
            objDALDetFactProv = Nothing
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

#Region " Public Patient Functions "

    Public Function ups_TraerUltimaFactProv(ByVal Sucursal As String) As DataSet
        'Tony Garcia - 04/Diciembre/2012 - 5:10 p.m
        Try
            'Validate group data 

            'Call the data component to add the new group
            Return objDALDetFactProv.ups_TraerUltimaFactProv(Sucursal)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_PpalDetFactProv(ByVal Sucursal As String, ByVal FactProv As String, ByVal SerieIni As String, _
                                            ByVal SerieFin As String)
        'Tony Garcia - 04/Diciembre/2012 - 5:10 p.m
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALDetFactProv.usp_PpalDetFactProv(Sucursal, FactProv, SerieIni, SerieFin)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function
#End Region
End Class
