Public Class frmCatalogoSegPedidos
    'mreyes 15/Febrero/2017 04:40 p.m.


    Public Opcion As Integer = 0  '1 = Envío,  2 = Recibo,  3 = Dev Envío, 4 = Dev Recibo
    Public Accion As Integer = 0  '1 = Captura, 2 = Edicion, 4 = Consulta
    Public Estatus As String = ""
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0

    Private objDataSet As Data.DataSet


    Public ImprimeTrasp As Boolean = False
    Dim FolioB As String





    Private Sub frmCatalogoSegBit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoTraspasosManuales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'SirCoDataSet.motsegpedido' Puede moverla o quitarla según sea necesario.
        Me.MotsegpedidoTableAdapter.Fill(Me.SirCoDataSet.motsegpedido)
        Try

           
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class