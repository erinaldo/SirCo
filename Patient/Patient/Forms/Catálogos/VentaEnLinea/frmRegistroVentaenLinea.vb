
Public Class frmRegistroVentaenLinea
    'mreyes 13/Mayo/2021    12:48 p.m.




    Dim Sql As String
    Dim ContArt As Integer = 0
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEsSuc As Boolean = False
    Dim cantArt As Integer = 0
    Dim Tipo As String = ""

    Public Opcion As Integer = 0  '1 = Envío,  2 = Recibo,  3 = Dev Envío, 4 = Dev Recibo
    Public Accion As Integer = 0  '1 = Captura, 2 = Edicion, 4 = Consulta
    Public Estatus As String = ""
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0
    Public IdTRaspaso As Integer = 0
    Dim IdTRaspRec As Integer = 0
    Private objDataSet As Data.DataSet
    Private objDataSet2 As Data.DataSet
    Private objDataSetEmp As Data.DataSet

    Public ImprimeTrasp As Boolean = False
    Dim FolioB As String

    Private tiempoInicial As DateTime
    Private tiempoFinal As DateTime
    Private evaluando As Boolean = False

    Public Sw_Automatico As Boolean = False
    Public Sw_ParesUnicos As Boolean = False
    Dim idfoliosucresaut As String = ""
    Dim Plaza As Integer = 1

    Public Serie As String = ""


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
        Try
            Dim blankContextMenu = New ContextMenuStrip()

            If blnEsSuc = True Then
                DGridS.Columns("col_costomargen").Visible = False
            End If

            If Serie <> "" Then
                '' es directo del ppal
                Txt_Serie.Text = Serie
                Call Txt_Serie_LostFocus(sender, e)
                Lbl_LecturaSeries.Text = "Escaneados: 1 de 1"
                'Txt_Serie.Enabled = False

                '-- hay que buscar  el marketplace y el pedido
                '' primero se busca por la serietmp sino lo encuentra busca marca, modelo, medida, sucursal marketplace.



            End If


            Call Edicion()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 1



                    If Opcion = 1 Or Opcion = 3 Then

                    ElseIf Opcion = 2 Then

                    End If

                Case 2

                Case 4
                    'Btn_Imprimir.Enabled = False
                    Btn_Aceptar.Enabled = False

                    Txt_Serie.Enabled = False
                    Txt_Precio.Enabled = False

                    Txt_Serie.BackColor = TextboxBackColor

                    Txt_Precio.ForeColor = Color.Black

            End Select


            If Opcion = 1 Or Opcion = 3 Then

                Lbl_LecturaSeries.Visible = False



            ElseIf Opcion = 2 Or Opcion = 4 Then





                ' Rb_Parcial.Visible = True
                ' Rb_Total.Visible = True


                'Txt_IdMov2.Visible = False
                'Txt_DescripM2.Visible = False
                'Lbl_M2.Visible = False
            End If

            If Accion = 1 And GLB_CveSucursal = "15" Then

            ElseIf Accion = 1 And blnEsSuc = True Then


            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub CalculaImportes()

        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try
            For i As Integer = 0 To DGridS.Rows.Count - 1

                Precio = Precio + CDec(DGridS.Rows(i).Cells("col_precio").Value)
            Next


            Txt_Precio.Text = Format(Precio, "$#,##0.00")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If MessageBox.Show("Está seguro que desea Salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:30
        Dim myForm As New frmConsulta
        Dim objDataSet As Data.DataSet


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Plaza = Val(objDataSet.Tables(0).Rows(0).Item("idplaza"))

                    'Else
                    '    Txt_Campo.Text = ""
                    '    myForm.Tipo = Tipo
                    '    myForm.ShowDialog()
                    '    Txt_Campo.Text = myForm.Campo
                    '    Txt_Campo1.Text = myForm.Campo1
                    '    If Txt_Campo.Text.Length = 0 Then
                    '        Txt_Campo.Focus()
                    '    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub











    Private Sub Btn_AgregarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Serie.KeyPress
        pub_SoloNumeros(sender, e)
        If GLB_Idempleado <> 132 Then
            Call BorrarClipboard()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub ups_TraerPedidoVEL()
        'mreyes 19/Mayo/2021    11:30 a.m.
        Dim objDataSet As Data.DataSet
        Dim ContArt As Integer
        ContArt = 0
        Try

            Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                objDataSet = objTraspasos.usp_TraerPedidoVEL(Txt_OperationId.Text)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then


                For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    DGridP.Rows.Add(objDataSet.Tables(0).Rows(I).Item("serie").ToString,
                                    objDataSet.Tables(0).Rows(I).Item("marca").ToString,
                                    objDataSet.Tables(0).Rows(I).Item("estilon").ToString,
                                    objDataSet.Tables(0).Rows(I).Item("medida").ToString
                               )

                    CargarFotoArticulo(objDataSet.Tables(0).Rows(I).Item("marca").ToString, objDataSet.Tables(0).Rows(I).Item("estilon").ToString)

                    ContArt = ContArt + 1

                Next

                Txt_Articulos.Text = ContArt
                'Txt_Serie.Text = ""
                'Txt_Serie.Focus()

                If objDataSet.Tables(0).Rows(0).Item("multiple") = 1 Then
                    Lbl_Multiple.Visible = True
                    'Txt_Serie.Enabled = True
                    'Txt_Serie.Text = ""
                    'Txt_Serie.Focus()

                End If


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus

        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Dim objDataSet1 As Data.DataSet
        Try

            If GLB_Idempleado <> 132 Then
                Call BorrarClipboard()
            End If
            If Txt_Serie.Text.Length = 0 Or Txt_Serie.Text = "0" Then Exit Sub

            Txt_Serie.Text = pub_RellenarIzquierda(Txt_Serie.Text, 13)


            If Txt_OperationId.Text = "" Then
                Using objTraspasos1 As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                    objDataSet1 = objTraspasos1.usp_TraerSerieTmp(Txt_Serie.Text)
                End Using
                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    Txt_OperationId.Text = objDataSet1.Tables(0).Rows(0).Item("pedido")
                    Txt_Marketplace.Text = objDataSet1.Tables(0).Rows(0).Item("marketplace") & " - " & objDataSet1.Tables(0).Rows(0).Item("descrip")

                Else
                    '' quiere decir que no lo encontro y hay que buscar por marca modelo medida, según 
                    MsgBox("No se encontro la serie asignada a ninguna venta.", MsgBoxStyle.Exclamation, "Error")
                    Txt_Serie.Focus()
                    Me.Close()
                    Me.Dispose()
                    Txt_Serie.Focus()
                    Exit Sub

                End If

                Call ups_TraerPedidoVEL()
            End If




            Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                objDataSet = objTraspasos.usp_TraerTraspasoSerieDescripVEL(Txt_OperationId.Text, Txt_Serie.Text)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then



                If objDataSet.Tables(0).Rows(0).Item("status") = "AC" Then

                    DGridS.Columns("col_costo").Visible = False




                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        DGridS.Rows.Add(objDataSet.Tables(0).Rows(I).Item("serie").ToString,
                                        objDataSet.Tables(0).Rows(I).Item("idarticulo").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("marca").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("estilon").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("corrida").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("medida").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("descripc").ToString,
                                       Val(objDataSet.Tables(0).Rows(I).Item("costo")),
                                    Val(objDataSet.Tables(0).Rows(I).Item("costomargen")),
                                       Val(objDataSet.Tables(0).Rows(I).Item("precio")),
                                       Val(objDataSet.Tables(0).Rows(I).Item("proveedors")),
                                                      Val(objDataSet.Tables(0).Rows(I).Item("preciovta")),
                                                                     Val(objDataSet.Tables(0).Rows(I).Item("status"))
                        )
                        CargarFotoArticulo(objDataSet.Tables(0).Rows(I).Item("marca").ToString, objDataSet.Tables(0).Rows(I).Item("estilon").ToString)


                        ContArt = ContArt + 1
                    Next

                    ' Txt_Articulos.Text = ContArt
                    Lbl_LecturaSeries.Text = "Escaneados: " + DGridS.Rows.Count.ToString + " de " + Txt_Articulos.Text

                    Txt_Serie.Text = ""
                    Txt_Serie.Focus()


                    Precio = Precio + DGridS.Rows(DGridS.RowCount - 1).Cells("col_precio").Value


                    Txt_Precio.Text = Format(Precio, "$#,##0.00")



                Else
                    '' agarrar otra serie... 



                End If
            End If


            If ContArt = Val(Txt_Articulos.Text) Then
                Btn_Aceptar.Enabled = True
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Eliminar_Serie()

        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try
            If DGridS.Rows.Count = 0 Then Exit Sub
            If DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value <> "" Then


                Precio = Precio - DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_precio").Value


                Txt_Precio.Text = Format(Precio, "$#,##0.00")

                DGridS.Rows().Remove(DGridS.CurrentRow)
                ContArt = ContArt - 1
                '  Txt_Articulos.Text = ContArt
                'Txt_Serie.Text = DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value

                If DGridS.Rows.Count = 0 Then
                    Txt_Serie.Text = ""
                    PBox.Image = Nothing
                Else
                    'Txt_Serie.Text = DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value
                End If

                If Opcion = 2 Or Opcion = 4 Then
                    Lbl_LecturaSeries.Text = "Escaneados: " + DGridS.Rows.Count.ToString + " de " + cantArt.ToString
                End If

                If ContArt <> Val(Txt_Articulos.Text) Then
                    Btn_Aceptar.Enabled = False
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridS.KeyDown
        Try
            If Accion = 4 Then Exit Sub
            If (e.KeyCode = Keys.Delete) Then
                'If Accion = 1 Or Accion = 2 Then
                If DGridS.Rows.Count = 0 Then Exit Sub
                If MessageBox.Show("Está seguro de quitar esta serie del traspaso?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
                If DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value <> "" Then
                    Call Eliminar_Serie()
                End If
                'Else
                '    Me.Dispose()
                '    Me.Close()
                'End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            MarcaFOTO = Marca
            EstiloNFOTO = Estilon
            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub
                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGridS.Click
        Try
            If DGridS.Rows.Count = 0 Then Exit Sub
            If IsDBNull(DGridS.Rows(DGridS.CurrentRow.Index).Cells(1).Value) Then
            Else
                'If Opcion = 1 Then
                '    Txt_Serie.Text = DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value
                'End If
                CargarFotoArticulo(DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_marca").Value, DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_estilon").Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridS.KeyUp
        Try
            If DGridS.Rows.Count = 0 Then Exit Sub
            If IsDBNull(DGridS.Rows(DGridS.CurrentRow.Index).Cells(1).Value) Then
            Else
                If Opcion = 1 Then
                    'Txt_Serie.Text = DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value
                End If
                CargarFotoArticulo(DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_marca").Value, DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_estilon").Value)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Function BorrarClipboard()

        Clipboard.Clear()

    End Function

    Private Sub Txt_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Serie.TextChanged
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

    Private Sub Pnl_Edicion_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Lbl_LecturaSeries_Click(sender As Object, e As EventArgs) Handles Lbl_LecturaSeries.Click

    End Sub

    Private Sub DGridS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGridS.CellContentClick

    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        Try
            Dim Sucursal As String = ""
            Dim Marca As String = ""
            Dim Estilon As String = ""
            Dim Corrida As String = ""
            Dim Medida As String = ""
            Dim Serie As String = ""
            Dim Precio As Decimal = 0
            Dim PrecDesc As Decimal = 0
            Dim Iva As Decimal = 16
            Dim CostoMargen As Decimal = 0
            Dim MontoTotal As Decimal = 0

            '' SI ES DE MERCADO LIBRE IMPRIMIR GUIA, ABRIRLA PRIMERO.

            With DGridS
                For i As Integer = 0 To DGridS.Rows.Count - 1

                    Sucursal = Mid(Txt_Marketplace.Text, 1, 2)
                    Serie = DGridS.Rows(i).Cells("col_serie").Value
                    Marca = DGridS.Rows(i).Cells("col_marca").Value
                    Estilon = DGridS.Rows(i).Cells("col_estilon").Value
                    Medida = DGridS.Rows(i).Cells("col_medida").Value
                    Corrida = DGridS.Rows(i).Cells("col_corrida").Value
                    CostoMargen = DGridS.Rows(i).Cells("col_costomargen").Value
                    Precio = DGridS.Rows(i).Cells("col_preciovta").Value
                    PrecDesc = DGridS.Rows(i).Cells("col_precio").Value
                    MontoTotal = DGridS.Rows(i).Cells("col_precio").Value

                    Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                        objTraspasos.usp_Captura_VentaEnLinea(Txt_OperationId.Text, Sucursal, Marca, Estilon, Corrida, Medida, Serie, Precio, PrecDesc, Iva, CostoMargen, MontoTotal)
                    End Using
                Next
            End With

            ' termina guardar venta.

            MsgBox("Se ha generado la venta correspondiente.", MsgBoxStyle.Information, "Venta")


            Sw_Registro = True
            Me.Close()

            ' update 


            'HACER LA VENTA





        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_PDF_Click(sender As Object, e As EventArgs) Handles Btn_PDF.Click
        ' imprimir según el nombre 
        Try
            Dim Archivo As String = "\\10.10.1.1\YUJU\GUIAS\"


            Archivo = "\\10.10.1.1\YUJU\GUIAS\" & Txt_OperationId.Text & ".pdf"

            'Process.Start("\\10.10.1.1\YUJU\GUIAS\4580586076.PDF")
            Process.Start(Archivo)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Botones_Paint_1(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class
