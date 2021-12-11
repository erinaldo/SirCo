Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing.Printing
Public Class frmPpalVentasenLinea

    'mreyes    20/Marzo/2018
    Dim WithEvents Documento As New PrintDocument


    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet 'Segundo Nivel
    Dim SucurOriB As Integer = 0
    Dim SucurDesB As Integer = 0
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Public Opcion As Integer = 0   '1 = Enviado,  2 = Por Recibir
    Public OpcionSP As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False

    '-- filtros
    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    ' Public Marca As String = ""
    Public Modelo As String = ""
    Public IdAgrupacion As Integer = 0



    Private idpedido As String = ""
    Private Cantidad As String = ""
    Private NombreCliente As String = ""
    Private Canal As String = ""
    Private NoTraspaso As String = ""
    Private NoVenta As String = ""
    Private Marca As String = ""
    Private Estilon As String = ""
    Private Medida1 As String = ""
    Private Serie1 As String = ""

    Private tiempoInicial As DateTime
    Private tiempoFinal As DateTime
    Private evaluando As Boolean = False







    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2017     04:55 p.m.

        DGrid1.Visible = False

        Using objTrasp As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalVentasENLinea(11)

                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid1.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("LA INFORMACIÓN SE ESTA ACTUALIZANDO, FAVOR DE INTENTAR EN UNOS MINUTOS", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid1.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Sub InicializaGrid()
        'GridView1
        Try
            GridView1.BestFitColumns()
            GridView1.Columns("nombrecliente").Visible = False
            GridView1.Columns("NoTraspaso").Visible = False
            GridView1.Columns("marca").Visible = False
            GridView1.Columns("estilon").Visible = False
            GridView1.Columns("medida").Visible = False
            GridView1.Columns("serie").Visible = False
            GridView1.Columns("guia_pdf").Visible = False
            GridView1.Columns("NoVenta").Visible = False



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmPpalVentasenLinea_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try



    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Configurar()
        impresora.Document = Documento
        ' impresora.ShowDialog()

        Documento.PrinterSettings = impresora.PrinterSettings
        '    Documento.PrinterSettings.PaperSizes("Custom Paper Size", 100, 200)

    End Sub
    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub


    Private Sub Documento_PrintPage(ByVal sender As System.Object,
                                ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Documento.PrintPage



        'idpedido = Row("idpedido")
        'Cantidad = Row("cantidad")
        'NombreCliente = Row("nombrecliente")
        'Canal = Row("notraspaso")
        'NoVenta = Row("noventa")
        'Marca = Row("marca")
        'Estilon = Row("estilon")
        'Medida1 = Row("medida1")
        'Serie1 = Row("serie1")


        Contenido = e
        Contenido.Graphics.DrawString("Pedido: " & idpedido, New Font("Arial", 34), Brushes.Black, 40, 10)
        ' Contenido.Graphics.DrawString(Glb_CorridaEtiqueta, New Font("Wide Latin", 12), Brushes.Black, 250, 20)
        Contenido.Graphics.DrawString("Cantidad: " & Cantidad, New Font("Arial", 20), Brushes.Black, 40, 70)

        Contenido.Graphics.DrawString("Nombre Cliente : " & NombreCliente, New Font("Arial", 20), Brushes.Black, 40, 100)
        Contenido.Graphics.DrawString("Canal : " & Canal, New Font("Arial", 20), Brushes.Black, 40, 130)
        Contenido.Graphics.DrawString("Traspaso : " & NoTraspaso, New Font("Arial", 20), Brushes.Black, 40, 160)
        Contenido.Graphics.DrawString("No Venta : " & NoVenta, New Font("Arial", 20), Brushes.Black, 40, 190)
        Contenido.Graphics.DrawString("Marca : " & Marca, New Font("Arial", 20), Brushes.Black, 40, 220)
        Contenido.Graphics.DrawString("Modelo : " & Estilon, New Font("Arial", 20), Brushes.Black, 40, 250)
        Contenido.Graphics.DrawString("Medida : " & Medida1, New Font("Arial", 20), Brushes.Black, 40, 280)
        Contenido.Graphics.DrawString("Serie : " & Serie1, New Font("Arial", 34), Brushes.Black, 40, 320)





        Contenido.HasMorePages = False



    End Sub
    Private Sub Btn_PDF_Click(sender As Object, e As EventArgs) Handles Btn_PDF.Click
        Try
            Dim printPDF As New Process
            Dim objProcess = New System.Diagnostics.Process

            Dim RutaOrigen As String = "https://software.madkting.com/temps/labels/1083288132038835657MLM648055609-32957312528.pdf"
            Dim RutaDestino As String = "c:\MERCADOLIBRE\1083288132038835657MLM648055609-32957312528.pdf"


            'Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
            '    objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)

            'End Using

            Dim Rows As New ArrayList()
            ' Add the selected rows to the list.
            Dim I As Integer
            For I = 0 To GridView1.SelectedRowsCount() - 1
                If (GridView1.GetSelectedRows()(I) >= 0) Then
                    Rows.Add(GridView1.GetDataRow(GridView1.GetSelectedRows()(I)))
                End If
            Next



            For I = 0 To Rows.Count - 1
                Dim Row As DataRow = CType(Rows(I), DataRow)
                '' IMPRIMIR


                idpedido = Row("idpedido")
                Cantidad = Row("cantidad")
                NombreCliente = Row("nombrecliente")
                Canal = Row("canal")
                NoTraspaso = Row("notraspaso")
                NoVenta = Row("noventa")
                Marca = Row("marca")
                Estilon = Row("estilon")
                Medida1 = Row("medida")
                Serie1 = Row("serie")


                Documento.Print()

                RutaDestino = "c:\MERCADOLIBRE\" & Row("idventa") & ".pdf"

                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    PBox.Image = Nothing
                    objIO.pub_EliminarArchivo(RutaDestino)
                End Using

                My.Computer.Network.DownloadFile(Row("guia_pdf"), "c:\MERCADOLIBRE\" & Row("idventa") & ".pdf")






                'Dim myForm As New frmReportsBrowser

                'myForm.objDataVentasEnLinea = GenerarReporte(Row("idpedido"), Row("cantidad"), Row("nombrecliente"), Row("canal"), Row("notraspaso"), Row("noventa"), Row("marca"), Row("estilon"), Row("medida"), Row("serie"))

                'myForm.ReportIndex = 6004
                'myForm.WindowState = FormWindowState.Maximized

                'myForm.Show()





                With printPDF
                    .StartInfo.FileName = RutaDestino


                    .StartInfo.Verb = "PrintTo"
                    .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    .StartInfo.CreateNoWindow = True


                    .Start()
                    .WaitForExit(3000)
                End With


                objProcess = printPDF

                objProcess.Kill()  'Cerra


            Next






            'Dim psi As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo()
            'psi.UseShellExecute = True
            'psi.Verb = "print"
            'psi.FileName = "https://software.madkting.com/temps/labels/1083288132038835657MLM648055609-32957312528.pdf"
            'psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
            'psi.ErrorDialog = False
            'psi.Arguments = "/p"
            'Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psi)
            'p.WaitForInputIdle()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalVentasenLinea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call RellenaGrid()
    End Sub


    Private Function GenerarReporte(Idpedido As String, Cantidad As String, NombreCliente As String, Canal As String,
                                    NoTraspaso As String, NoVenta As String, Marca As String, Estilon As String, Medida As String,
                                    Serie As String) As DSPVentasEnLinea
        'mreyes 31/Mayo/2019    10:18 p.m.
        Try

            GenerarReporte = New DSPVentasEnLinea

            Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
            objDataRow.Item("idpedido") = Idpedido
            objDataRow.Item("cantidad") = Cantidad
            objDataRow.Item("nombrecliente") = NombreCliente
            objDataRow.Item("canal") = Canal
            objDataRow.Item("Notraspaso") = NoTraspaso
            objDataRow.Item("noventa") = NoVenta
            objDataRow.Item("marca") = Marca
            objDataRow.Item("estilon") = Estilon
            objDataRow.Item("medida") = Medida
            objDataRow.Item("serie") = Serie


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function BorrarClipboard()

        Clipboard.Clear()

    End Function
    Private Sub Txt_Serie_TextChanged(sender As Object, e As EventArgs) Handles Txt_Serie.TextChanged
        Try
            If GLB_Idempleado <> 132 Then
                Call BorrarClipboard()
                If Txt_Serie.Text = "" Then Txt_Serie.Focus() : Exit Sub
                Dim largo As Long = Me.Txt_Serie.Text.Length
                If evaluando = False And largo >= 1 Then
                    tiempoInicial = Now
                    evaluando = True
                Else
                    If largo >= 1 Then 'evaluamos el tiempo
                        tiempoFinal = Now
                        Dim segundos As Long = DateDiff(DateInterval.Second, tiempoInicial, tiempoFinal)
                        If segundos >= 1 Then
                            'MsgBox("Entrada no permitida por teclado", MsgBoxStyle.Exclamation, "Error")
                            evaluando = False
                            Me.Txt_Serie.Text = ""

                        End If
                    End If
                End If
                If largo = 0 Then
                    evaluando = False
                End If

                If evaluando = True Then

                    If Txt_Serie.Text.Length = 13 Then
                        'Txt_Serie_LostFocus(sender, e)
                        Txt_Serie.Focus()
                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_LostFocus(sender As Object, e As EventArgs) Handles Txt_Serie.LostFocus
        Try
            If Txt_Serie.Text = "" Then Exit Sub
            Txt_Serie.Text = pub_RellenarIzquierda(Txt_Serie.Text, 13)

            Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoSQL)
                objDataSet = objTraspasos.usp_TraerTraspasoSerieDescrip(Txt_Serie.Text)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                If objDataSet.Tables(0).Rows(0).Item("status") = "BA" Then
                    MsgBox("La serie ya fue cobrada. Verifique", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If

            End If

            ' MAndar llamar la siguiente forma.

            Try
                Dim myForm As New frmRegistroVentaenLinea

                myForm.Opcion = Opcion
                myForm.Accion = 1
                myForm.Serie = Txt_Serie.Text
                Txt_Serie.Text = ""


                myForm.ShowDialog()

                If myForm.Sw_Registro = True Then
                    Call RellenaGrid()
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Serie.KeyPress
        pub_SoloNumeros(sender, e)
        If GLB_Idempleado <> 132 Then
            Call BorrarClipboard()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class