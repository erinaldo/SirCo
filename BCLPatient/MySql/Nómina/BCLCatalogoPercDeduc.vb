Public Class BCLCatalogoPercDeduc
    'mreyes 06/Junio/2012 10:19 a.m.

    Implements IDisposable
    Private objDALCatalogoPercDeduc As DAL.DALCatalogoPercDeduc
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
#Region "Constructor And Destructor"
    Public Sub New(ByVal Constring As String)
9:      objDALCatalogoPercDeduc = New DAL.DALCatalogoPercDeduc(Constring)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
            objDALCatalogoPercDeduc.Dispose()
            objDALCatalogoPercDeduc = Nothing
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





    Public Function usp_PpalCatalogoPercDeduc(ByVal IdPercDeduc As Integer, ByVal Clave As String, ByVal Naturaleza As String, ByVal DescripC As String, ByVal DescripL As String, _
                                                    ByVal Repetitivo As String, ByVal TipoNom As String, ByVal Estatus As String, ByVal Tienda As String) As DataSet
        'mreyes 08/Junio/2012 11:58 a.m.
        Try
            'idpercdeduc int, clave char(3), naturaleza char(1), descripc char(30), descripl char(60), activo int
            usp_PpalCatalogoPercDeduc = objDALCatalogoPercDeduc.usp_PpalCatalogoPercDeduc(IdPercDeduc, Clave, Naturaleza, DescripC, DescripL, Repetitivo, TipoNom, Estatus, Tienda)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

    Public Function usp_Captura_Percdeduc(ByVal Opcion As Integer, ByVal IdPercdeduc As Integer, ByVal Clave As String, _
                                          ByVal Naturaleza As String, ByVal DescripC As String, ByVal DescripL As String, _
                                          ByVal Repetitivo As String, ByVal TipoNom As String, ByVal Estatus As String, ByVal Tienda As String) As Boolean
        'mreyes 06/Junio/2012 10:50 a.m.
        Try
            'Validate group data

            'Call the data component to add the new group
            Return objDALCatalogoPercDeduc.usp_Captura_PercDeduc(Opcion, IdPercdeduc, Clave, Naturaleza, DescripC, DescripL, Repetitivo, TipoNom, Estatus, Tienda)
        Catch ExceptionErr As Exception
            Throw New System.Exception(ExceptionErr.Message, _
                ExceptionErr.InnerException)
        End Try
    End Function

#End Region
End Class
