Public Class frmSalidaTraspasos
    'mreyes 10/Diciembre/2016   01:25 p.m.
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
    'Declare Function BlockInput Lib "User32" (ByVal fBlockIt As Boolean) As Boolean



    Private tiempoInicial As DateTime
    Private tiempoFinal As DateTime
    Private evaluando As Boolean = False

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

            If ImprimeTrasp = True Then
                Call usp_TraerTraspaso(Txt_Sucursal.Text, Txt_Traspaso.Text, Txt_Destino.Text)
                If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Then
                    blnEsSuc = True
                End If
                ImprimirReporte()
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If

            If Opcion = 1 Then
                Me.Text = "Salida Traspaso"
                Tipo = "M"
            ElseIf Opcion = 2 Then
                Me.Text = "Salida Traspaso"
                Tipo = "M"
            ElseIf Opcion = 3 Then
                Me.Text = "Enviar Traspaso de Devolución"
                Tipo = "D"
            ElseIf Opcion = 4 Then
                Me.Text = "Recibir Traspaso de Devolución"
                Tipo = "D"
            End If

            If Txt_IdMov1.Text.Length > 0 Then
                Call Txt_IdMov1_LostFocus(sender, e)
            End If

            If Txt_IdMov2.Text.Length > 0 Then
                Call Txt_IdMov2_LostFocus(sender, e)
            End If

            Txt_IdMov1.Text = ""
            Txt_IdMov2.Text = GLB_Idempleado
            Txt_IdMov2.Enabled = False

            Txt_DescripM1.Text = ""
            Txt_DescripM2.Text = ""

            GenerarToolTip()
            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Then
                blnEsSuc = True
                Txt_Sucursal.Text = GLB_CveSucursal
                Txt_DescripSucursal.Text = GLB_Sucursal
                Txt_Sucursal.Enabled = False
                Txt_Sucursal.ReadOnly = True
                Txt_Sucursal.BackColor = Color.White
                Txt_Costo.Visible = False
                Lbl_Costo.Visible = False
                Txt_Precio.Visible = True
                Lbl_Precio.Visible = True


                If Txt_Estatus.Text = "CAPTURA" Then
                    Btn_Imprimir.Enabled = False
                End If
            End If

            Call Edicion()

            Txt_IdMov2.Enabled = False
            If Txt_IdMov2.Text.Length > 0 Then
                Call Txt_IdMov2_LostFocus(sender, e)
            End If
            If Accion = 4 Or Accion = 2 Then
                Call usp_TraerTraspaso(Txt_Sucursal.Text, Txt_Traspaso.Text, Txt_Destino.Text)

                If Txt_IdMov1.Text.Length > 0 Then
                    Call Txt_IdMov1_LostFocus(sender, e)
                End If

                If Txt_IdMov2.Text.Length > 0 Then
                    Call Txt_IdMov2_LostFocus(sender, e)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 1
                    Btn_Imprimir.Enabled = False
                    Txt_Estatus.Text = "CAPTURA"
                    Lbl_Traspaso.Visible = False
                    Txt_Traspaso.Visible = False
                    Txt_IdMov1.Enabled = False

                    If Opcion = 1 Or Opcion = 3 Then
                        Txt_IdMov2.Visible = False
                        Txt_DescripM2.Visible = False
                        Lbl_M2.Visible = False
                    End If

                Case 2
                    Txt_IdMov1.Enabled = False
                    If Opcion = 1 Or Opcion = 3 Then
                        Txt_IdMov2.Visible = False
                        Txt_DescripM2.Visible = False
                        Lbl_M2.Visible = False
                        Txt_IdMov2.Text = ""
                    End If

                Case 4
                    Btn_Aceptar.Enabled = False
                    'Btn_Archivo.Enabled = False
                    Txt_Destino.Enabled = False
                    Txt_Sucursal.Enabled = False
                    Txt_Observaciones.Enabled = False
                    Txt_Serie.Enabled = False
                    Txt_Precio.Enabled = False
                    Txt_Referencia.Enabled = False
                    Txt_IdMov1.Enabled = False
                    Txt_IdMov2.Enabled = True
                    Txt_IdTraspaso.Enabled = False

                    Txt_Destino.BackColor = TextboxBackColor
                    Txt_Sucursal.BackColor = TextboxBackColor
                    Txt_Observaciones.BackColor = TextboxBackColor
                    Txt_Serie.BackColor = TextboxBackColor
                    Txt_IdMov1.BackColor = TextboxBackColor
                    Txt_IdMov2.BackColor = TextboxBackColor
                    Txt_Estatus.ForeColor = Color.Black
                    Txt_Costo.ForeColor = Color.Black
                    Txt_Precio.ForeColor = Color.Black
            End Select


            If Opcion = 1 Or Opcion = 3 Then
                Lbl_Referencia.Visible = False
                Txt_Referencia.Visible = False
                Txt_IdTraspaso.Visible = False
                Lbl_IdTras.Visible = False
                Lbl_LecturaSeries.Visible = False
                Lbl_M1.Text = "Envía"
                Lbl_M2.Text = "Transporta"
                Lbl_Traspaso.Text = "Traspaso"

            ElseIf Opcion = 2 Or Opcion = 4 Then
                Lbl_LecturaSeries.Visible = False
                Lbl_Referencia.Visible = True
                Txt_Referencia.Visible = True
                'Btn_Archivo.Visible = False
                'Label16.Text = "Recibe"
                'Label4.Text = "Origen"
                Lbl_Traspaso.Text = "Recepción"

                Lbl_M1.Text = "Envía"
                Lbl_M2.Text = "Verifica"
                Txt_IdMov1.Enabled = False
                Txt_IdMov2.Enabled = True


                'Txt_IdMov2.Visible = False
                'Txt_DescripM2.Visible = False
                'Lbl_M2.Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerTraspaso(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String)
        Dim intContador As Integer = 0
        'Dim sender As Object
        'Dim e As System.EventArgs
        Try
            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

                If Opcion = 1 Or Opcion = 3 Then 'Envío
                    objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Txt_Sucursal.Text, Txt_Traspaso.Text, Txt_Destino.Text, IdTRaspaso, 0)
                ElseIf Opcion = 2 Or Opcion = 4 Then 'Recibo
                    objDataSet = objTraspasos.usp_TraerTraspasoManualReciboDet(Txt_Sucursal.Text, Txt_Traspaso.Text, Txt_Destino.Text, IdTRaspaso)
                End If

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If blnEsSuc Then
                        DGridS.Columns("col_costo").Visible = False
                        DGridS.Columns("col_costomargen").Visible = False
                        'DGridS.Columns("col_precio").Visible = False
                        Lbl_Costo.Visible = False
                        'Lbl_Precio.Visible = False
                        Txt_Costo.Visible = False
                        'Txt_Precio.Visible = False
                    End If

                    If Opcion = 1 Then
                        If Txt_Sucursal.Text <> objDataSet.Tables(0).Rows(0).Item("sucursal") Then
                            MessageBox.Show(" El Código NO existe en la sucursal que Envía.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()
                            Exit Sub
                        End If
                    End If

                    Txt_Observaciones.Text = objDataSet.Tables(0).Rows(0).Item("observa").ToString

                    If Opcion = 1 Or Opcion = 3 Then
                        Txt_IdMov1.Text = objDataSet.Tables(0).Rows(0).Item("envia").ToString
                        Txt_IdMov2.Text = objDataSet.Tables(0).Rows(0).Item("transporta").ToString
                    ElseIf Opcion = 2 Or Opcion = 4 Then
                        Txt_IdMov1.Text = objDataSet.Tables(0).Rows(0).Item("transporta").ToString
                        Txt_IdMov2.Text = objDataSet.Tables(0).Rows(0).Item("recibe").ToString

                        If objDataSet.Tables(0).Rows(0).Item("tiporec") = "T" Then

                        ElseIf objDataSet.Tables(0).Rows(0).Item("tiporec") = "P" Then

                        End If
                    End If


                    'For j As Integer = 0 To DGridS.Rows.Count - 1
                    '    If Txt_Serie.Text = DGridS.Rows(j).Cells("col_serie").Value Then
                    '        MessageBox.Show(" El Código YA está registrado en el Envío.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '        Txt_Serie.Text = ""
                    '        Txt_Serie.Focus()
                    '        Exit Sub
                    '    End If
                    'Next

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        DGridS.Rows.Add(objDataSet.Tables(0).Rows(I).Item("serie").ToString, _
                                        objDataSet.Tables(0).Rows(I).Item("idarticulo").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("marca").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("estilon").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("corrida").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("medida").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("descripc").ToString, _
                                       Val(objDataSet.Tables(0).Rows(I).Item("costo")), _
                                        Val(objDataSet.Tables(0).Rows(I).Item("costomargen")), _
                                        Val(objDataSet.Tables(0).Rows(I).Item("precio")), _
                                    Val(objDataSet.Tables(0).Rows(I).Item("proveedor")))
                        intContador += 1
                    Next

                    If intContador > 0 Then
                        ContArt = DGridS.Rows.Count
                        Txt_Articulos.Text = ContArt
                        CargarFotoArticulo(DGridS.Rows(0).Cells("col_marca").Value, DGridS.Rows(0).Cells("col_estilon").Value)
                    End If

                    CalculaImportes()
                    'Txt_Serie.Text = ""
                    'Txt_Serie.Focus()
                    'Else
                    '    MessageBox.Show(" El Código NO éxiste o ya está dado de BAJA.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    '    Txt_Serie.Text = ""
                    '    Txt_Serie.Focus()
                End If
            End Using

            'If intContador > 0 Then
            '    Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)

            '        For i As Integer = 0 To DGridS.Rows.Count - 1
            '            objDataSet = objTraspasos.usp_TraerDescripModelo(DGridS.Rows(i).Cells("col_marca").Value, DGridS.Rows(i).Cells("col_estilon").Value)
            '            If objDataSet.Tables(0).Rows.Count > 0 Then
            '                DGridS.Rows(i).Cells("col_descrip").Value = objDataSet.Tables(0).Rows(0).Item("descripc")
            '            End If
            '        Next
            '    End Using
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CalculaImportes()
        Dim Costo As Decimal = CDec(Txt_Costo.Text)
        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try
            For i As Integer = 0 To DGridS.Rows.Count - 1
                Costo = Costo + CDec(DGridS.Rows(i).Cells("col_costo").Value)
                Precio = Precio + CDec(DGridS.Rows(i).Cells("col_precio").Value)
            Next

            Txt_Costo.Text = Format(Costo, "$#,##0.00")
            Txt_Precio.Text = Format(Precio, "$#,##0.00")

            'Txt_Gastos.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("gastos")), "$#,##0.00")
            'Txt_Descuento.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("descuento")), "$#,##0.00")
            'Txt_Subtotal.Text = Format(Importe / ((1 + Val(Txt_Iva.Text) / 100) * (1 - Val(Txt_Dsctopp.Text) / 100)), "$#,##0.00")
            'Txt_TotalIVA.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)), "$#,##0.00")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Using objTransaccion As New BCL.BCLTraspasos(GLB_ConStringSirCoSQL)
            Try
                If Not ValidarEdicion() Then Exit Sub

                If cantArt <> Val(Txt_Articulos.Text) Then

                    MsgBox("No se puede realizar el Match correctamente, verifique el escaneo.", MsgBoxStyle.Critical, "Error")
                    Txt_Serie.Focus()
                    Exit Sub
               

                ElseIf Val(Txt_Articulos.Text) = cantArt Then
                    If Val(Txt_IdMov2.Text) = 0 Then
                        MsgBox("Debe especificar quién verifica la salida del traspaso.", MsgBoxStyle.Critical, "Error")
                        Exit Sub
                    End If
                    'If MessageBox.Show("Está seguro de Realizar el Match Traspaso con Folio '" + Txt_Referencia.Text + "' de sucursal " + Txt_DescripDestino.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

                    Dim myForm As New frmSeriesNoRecibidasTR

                    Dim ultimoFolio As String = ""
                    Dim blnTraspDes As Boolean = False
                    Dim Serie As String = ""
                    Dim Marca As String = ""
                    Dim Estilon As String = ""
                    Dim Medida As String = ""
                    Dim Proveedor As String = ""
                    Dim Corrida As String = ""
                    Dim Costo As String = ""
                    Dim CostoMargen As Double = 0.0
                    Dim Precio As Double = 0.0
                    Dim Idarticulo As Integer = 0
                    Dim Idtraspaso As Integer = 0
                    Dim blnActualizo As Boolean = False
                    Dim contador As Integer = 0
                    Dim blnCompleto As Boolean = False
                    Dim blnValidaNumTR As Boolean = False

                    Dim intContArt As Integer = 0




                    For i As Integer = 0 To DGridS.Rows.Count - 1
                        Serie = DGridS.Rows(i).Cells("col_serie").Value



                        Marca = DGridS.Rows(i).Cells("col_marca").Value
                        Estilon = DGridS.Rows(i).Cells("col_estilon").Value
                        Medida = DGridS.Rows(i).Cells("col_medida").Value
                        Corrida = DGridS.Rows(i).Cells("col_corrida").Value
                        Costo = DGridS.Rows(i).Cells("col_costo").Value
                        CostoMargen = DGridS.Rows(i).Cells("col_costomargen").Value
                        Precio = DGridS.Rows(i).Cells("col_precio").Value
                        Proveedor = DGridS.Rows(i).Cells("col_proveedor").Value
                        Idarticulo = DGridS.Rows(i).Cells("col_idarticulo").Value

                        contador += 1
                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objTraspasos.usp_CapturaDetTraspasoSal(Accion, Idtraspaso, Txt_Sucursal.Text, Txt_Referencia.Text, Idarticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, 1, CostoMargen, CDbl(Costo), Precio)
                        End Using





                    Next



                    ''''''''''''
                    If contador > 0 Then
                        Dim TipoRec As String = ""
                        'Actualizar el transporta en origen
                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

                            objTraspasos.usp_ActualizarEstatusTraspaso(1, Txt_Sucursal.Text, Txt_Referencia.Text, "AP", Txt_IdMov2.Text, GLB_Idempleado)

                        End Using


                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objTraspasos.usp_ActualizarDetTraspasoSal(Txt_Sucursal.Text, Txt_Referencia.Text)
                        End Using
                        'End If


                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            blnTraspDes = objTraspasos.usp_CapturaTraspasoSAL(Accion, Txt_Sucursal.Text, Txt_Referencia.Text, Tipo, TipoRec, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd"), Now.TimeOfDay.ToString, _
                                                                              Txt_Destino.Text, Txt_Referencia.Text, Txt_Observaciones.Text.Trim, GLB_Usuario, Idtraspaso, CInt(Txt_Articulos.Text), _
                                                                              CDec(Txt_Costo.Text), CDec(Txt_Precio.Text), CInt(Txt_IdMov2.Text), GLB_Idempleado)
                        End Using



                        MessageBox.Show(contador.ToString + " Artículos en Match de traspaso Correctamente del Folio: " + Txt_Referencia.Text, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If GLB_CveSucursal = "" Then
                            Txt_Sucursal.Enabled = False
                            Txt_DescripSucursal.Enabled = False
                            Txt_Sucursal.BackColor = Color.White
                        End If
                        Lbl_Traspaso.Visible = True
                        Txt_Traspaso.Visible = True
                        Txt_Traspaso.Text = ultimoFolio
                        Label5.Visible = True
                        Label5.Text = "Articulos en Match : " + contador.ToString
                        Txt_Destino.Enabled = False
                        Txt_Sucursal.Enabled = False
                        Txt_DescripDestino.Enabled = False
                        Txt_Serie.Enabled = False

                        Accion = 4
                        Txt_Observaciones.Enabled = False
                        Txt_Observaciones.BackColor = Color.White
                        Btn_Aceptar.Enabled = False


                        Call Btn_Imprimir_Click(sender, e)
                        Sw_Registro = True
                        Me.Close()
                    Else
                        MessageBox.Show("No se pudo recibir el traspaso...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try
        End Using
    End Sub

    Function Inserta_SerieDev(ByVal Serie As String) As Boolean
        'Dim AccionT As Integer = 0
        Dim objDataSetT As Data.DataSet
        Dim blnTraeSerie As Boolean = False
        'Get a new Project DataSet
        Try

            Using objTraspaso As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSet = objTraspaso.usp_TraerSerie(Serie)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    blnTraeSerie = True
                End If
            End Using

            If blnTraeSerie = True Then
                Using objTraspaso As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                    objDataSetT = objTraspaso.Inserta_SerieDev  'INSERTA NUEVO DATASET
                    'Initialize a datarow object from the Project DataSet
                    Dim objDataRow As Data.DataRow = objDataSetT.Tables(0).NewRow

                    'Set the values in the DataRow

                    objDataRow.Item("serie") = Serie
                    objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                    objDataRow.Item("status") = "TR"
                    objDataRow.Item("marca") = objDataSet.Tables(0).Rows(0).Item("marca")
                    objDataRow.Item("estilon") = objDataSet.Tables(0).Rows(0).Item("estilon")
                    objDataRow.Item("medida") = objDataSet.Tables(0).Rows(0).Item("medida")
                    objDataRow.Item("sucurdes") = objDataSet.Tables(0).Rows(0).Item("sucurdes")
                    objDataRow.Item("idfolio") = objDataSet.Tables(0).Rows(0).Item("idfolio")
                    objDataRow.Item("idarticulo") = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    objDataRow.Item("precioini") = objDataSet.Tables(0).Rows(0).Item("precioini")
                    objDataRow.Item("costoini") = objDataSet.Tables(0).Rows(0).Item("costoini")
                    objDataRow.Item("preciovta") = objDataSet.Tables(0).Rows(0).Item("preciovta")
                    objDataRow.Item("ultcosto") = objDataSet.Tables(0).Rows(0).Item("ultcosto")
                    objDataRow.Item("proveedors") = objDataSet.Tables(0).Rows(0).Item("proveedors")

                    'Add the DataRow to the DataSet
                    objDataSetT.Tables(0).Rows.Add(objDataRow)

                    'Add the Project
                    If Not objTraspaso.usp_Captura_SerieDev(3, objDataSetT) Then
                        '    Throw New Exception("Falló Inserción de Artículo")
                    Else
                        Inserta_SerieDev = True
                    End If
                End Using
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Function

    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_Sucursal.Text.Length = 0 Then
                MsgBox("Debe especificar la Sucursal de Origen del Traspaso.", MsgBoxStyle.Critical, "Validación")
                Txt_Sucursal.Focus()
                Exit Function
            End If


            If Txt_Destino.Text.Length = 0 Then
                MsgBox("Debe especificar la Sucursal de Destino del Traspaso.", MsgBoxStyle.Critical, "Validación")
                Txt_Destino.Focus()
                Exit Function
            End If

            If Txt_Observaciones.Text.Length = 0 Then
                MsgBox("Debe agregar las observaciones del traspaso.", MsgBoxStyle.Critical, "Validación")
                Txt_Observaciones.Focus()
                Exit Function
            End If

            If Opcion = 1 Or Opcion = 3 Then
                If Txt_Sucursal.Text = Txt_Destino.Text Then
                    MsgBox("La sucursal de Destino no puede ser igual a la sucursal de Orígen.", MsgBoxStyle.Critical, "Validación")
                    Txt_Sucursal.Focus()
                    Exit Function
                End If
            ElseIf Opcion = 4 Or Opcion = 2 Then
                ''If Txt_Sucursal.Text = Txt_Destino.Text Then
                ''    MsgBox("La sucursal de Orígen no puede ser igual a la sucursal que recibe.", MsgBoxStyle.Critical, "Validación")
                ''    Txt_Sucursal.Focus()
                ''    Exit Function
                ''End If
            End If


            If DGridS.Rows.Count = 0 Then
                MsgBox("Debe agregar articulos en el Traspaso para poder generarlo.", MsgBoxStyle.Critical, "Validación")
                Txt_Serie.Focus()
                Exit Function
            End If

            If Txt_IdMov2.Text = "" Then
                Txt_IdMov2.Text = 0
            End If

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Adjuntar Series desde archivo")
            ToolTip.SetToolTip(Btn_Aceptar, "Generar Traspaso")
            ToolTip.SetToolTip(Btn_Cancelar, "Salir")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
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
        ' Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
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

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus

    End Sub

    Private Sub Txt_Destino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Destino.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_Destino.Text.Length = 0 Then Exit Sub
            Try
                If Txt_Destino.Text.Trim.Length < 2 Then
                    Txt_Destino.Text = pub_RellenarIzquierda(Txt_Destino.Text.Trim, 2)
                End If

                Call TxtLostfocusPersis(Txt_Destino, Txt_DescripDestino, "S")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Txt_Sucursal.Text.Length = 2 Then
            Txt_Destino.Focus()
        End If
    End Sub

    Private Sub Txt_Destino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Txt_Destino.Text.Length = 2 Then
            'Btn_Adjuntar.Focus()
        End If
    End Sub

    Private Sub Txt_Observaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Observaciones.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_AgregarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Serie.KeyPress
        pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus
        Dim Costo As Decimal = CDec(Txt_Costo.Text)
        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try
            If Txt_Sucursal.Text = "" Then
                MessageBox.Show("Debe ingresar la sucursal de envío del traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_Sucursal.Text = ""
                Txt_Sucursal.Focus()
                Exit Sub
            End If
            If Txt_Serie.Text.Length = 0 Or Txt_Serie.Text = "0" Then Exit Sub
            Txt_Serie.Text = pub_RellenarIzquierda(Txt_Serie.Text, 13)

            If Opcion = 1 Or Opcion = 3 Then ''ENVIO
                ' no me convence esta parte
                Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                    objDataSet = objTraspasos.usp_TraerSerieEnDetTraspasoAC(Txt_Serie.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("serie") = Txt_Serie.Text Then
                            MessageBox.Show("La serie ya está registrada en otro traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Serie.Text = ""
                            Txt_Sucursal.Focus()
                            Exit Sub
                        End If
                    End If
                End Using
                ' no me convence esta parte

                Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoSQL)
                    objDataSet = objTraspasos.usp_TraerTraspasoSerieDescrip(Txt_Serie.Text)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If objDataSet.Tables(0).Rows(0).Item("status") = "AC" Then
                        If blnEsSuc Then
                            DGridS.Columns("col_costo").Visible = False
                            'DGridS.Columns("col_precio").Visible = False
                        End If

                        If Txt_Sucursal.Text.Length = 0 Then
                            MessageBox.Show("Debe ingresar la Sucursal que Envía el traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Serie.Text = ""
                            Txt_Sucursal.Focus()
                            Exit Sub
                        End If

                        If Txt_Sucursal.Text <> objDataSet.Tables(0).Rows(0).Item("sucursal") Then
                            MessageBox.Show(" El Código NO existe en la sucursal que Envía.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()
                            Exit Sub
                        End If

                        For j As Integer = 0 To DGridS.Rows.Count - 1
                            If Txt_Serie.Text = DGridS.Rows(j).Cells("col_serie").Value Then
                                MessageBox.Show(" El Código YA está registrado en el Envío.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Txt_Serie.Text = ""
                                Txt_Serie.Focus()
                                Exit Sub
                            End If
                        Next

                        For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            DGridS.Rows.Add(objDataSet.Tables(0).Rows(I).Item("serie").ToString, _
                                            objDataSet.Tables(0).Rows(I).Item("idarticulo").ToString, _
                                           objDataSet.Tables(0).Rows(I).Item("marca").ToString, _
                                           objDataSet.Tables(0).Rows(I).Item("estilon").ToString, _
                                           objDataSet.Tables(0).Rows(I).Item("corrida").ToString, _
                                           objDataSet.Tables(0).Rows(I).Item("medida").ToString, _
                                           objDataSet.Tables(0).Rows(I).Item("descripc").ToString, _
                                           Val(objDataSet.Tables(0).Rows(I).Item("costo")), _
                                        Val(objDataSet.Tables(0).Rows(I).Item("costomargen")), _
                                           Val(objDataSet.Tables(0).Rows(I).Item("precio")), _
                                           Val(objDataSet.Tables(0).Rows(I).Item("proveedors")))
                            CargarFotoArticulo(objDataSet.Tables(0).Rows(I).Item("marca").ToString, objDataSet.Tables(0).Rows(I).Item("estilon").ToString)

                        Next
                        ContArt = ContArt + 1
                        Txt_Articulos.Text = ContArt
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()

                        Costo = Costo + DGridS.Rows(DGridS.RowCount - 1).Cells("col_costomargen").Value
                        Precio = Precio + DGridS.Rows(DGridS.RowCount - 1).Cells("col_precio").Value

                        Txt_Costo.Text = Format(Costo, "$#,##0.00")
                        Txt_Precio.Text = Format(Precio, "$#,##0.00")

                        If blnEsSuc Then
                            DGridS.Columns("col_costo").Visible = False
                            DGridS.Columns("col_costomargen").Visible = False
                            'DGridS.Columns("col_precio").Visible = False
                            Lbl_Costo.Visible = False
                            'Lbl_Precio.Visible = False
                        End If
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "TR" Then
                        If Txt_Sucursal.Text <> objDataSet.Tables(0).Rows(0).Item("sucursal") Then
                            MessageBox.Show(" El Código NO existe en la sucursal que Envía.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()
                            Exit Sub
                        Else
                            MessageBox.Show(" El Código ingresado se encuentra en TRASPASO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()
                        End If

                    ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "BA" Then
                        MessageBox.Show(" El Código ya está dado de BAJA.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()
                    End If
                Else
                    MessageBox.Show(" El Código NO éxiste.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_Serie.Text = ""
                    Txt_Serie.Focus()
                End If


            ElseIf Opcion = 2 Or Opcion = 4 Then ''RECIBO

                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                    If Opcion = 2 Or Opcion = 4 Then 'Recibo Traspaso Normal
                        objDataSet = objTraspasos.usp_TraerTraspasosSerieDet(Txt_Sucursal.Text, Txt_Referencia.Text, Txt_Serie.Text)
                        'ElseIf Opcion = 4 Then 'Recibo Traspaso de Devolución

                    End If

                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        If objDataSet.Tables(0).Rows(0).Item("recibido").ToString.Trim = "1" Then
                            MessageBox.Show("El código YA se recibió.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()
                            Exit Sub
                        Else


                            For j As Integer = 0 To DGridS.Rows.Count - 1
                                If Txt_Serie.Text = DGridS.Rows(j).Cells("col_serie").Value Then
                                    MessageBox.Show(" El Código YA está registrado en la Recepción.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Txt_Serie.Text = ""
                                    Txt_Serie.Focus()
                                    Exit Sub
                                End If
                            Next

                            DGridS.Rows.Add(objDataSet.Tables(0).Rows(0).Item("serie").ToString, _
                                            objDataSet.Tables(0).Rows(0).Item("idarticulo").ToString, _
                                               objDataSet.Tables(0).Rows(0).Item("marca").ToString, _
                                               objDataSet.Tables(0).Rows(0).Item("estilon").ToString, _
                                               objDataSet.Tables(0).Rows(0).Item("corrida").ToString, _
                                               objDataSet.Tables(0).Rows(0).Item("medida").ToString, _
                                               objDataSet.Tables(0).Rows(0).Item("descripc").ToString, _
                                                Val(objDataSet.Tables(0).Rows(0).Item("costo")), _
                                                Val(objDataSet.Tables(0).Rows(0).Item("costomargen")), _
                                                Val(objDataSet.Tables(0).Rows(0).Item("precio")), _
                                               objDataSet.Tables(0).Rows(0).Item("proveedor").ToString)
                            CargarFotoArticulo(objDataSet.Tables(0).Rows(0).Item("marca").ToString, objDataSet.Tables(0).Rows(0).Item("estilon").ToString)
                            ContArt = ContArt + 1
                            Txt_Articulos.Text = ContArt
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()

                            Costo = Costo + DGridS.Rows(DGridS.RowCount - 1).Cells("col_costomargen").Value
                            Precio = Precio + DGridS.Rows(DGridS.RowCount - 1).Cells("col_precio").Value

                            Txt_Costo.Text = Format(Costo, "$#,##0.00")
                            Txt_Precio.Text = Format(Precio, "$#,##0.00")

                            If blnEsSuc Then
                                DGridS.Columns("col_costomargen").Visible = False
                                'DGridS.Columns("col_precio").Visible = False
                                Lbl_Costo.Visible = False
                                'Lbl_Precio.Visible = False
                            End If

                            Lbl_LecturaSeries.Text = "Escaneados: " + DGridS.Rows.Count.ToString + " de " + cantArt.ToString
                        End If
                    Else
                        MessageBox.Show(" El Código NO se encuentra registrado en el Envío proporcionado.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()
                    End If
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Eliminar_Serie()
        Dim Costo As Decimal = CDec(Txt_Costo.Text)
        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try
            If DGridS.Rows.Count = 0 Then Exit Sub
            If DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value <> "" Then

                Costo = Costo - DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_costo").Value
                Precio = Precio - DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_precio").Value

                Txt_Costo.Text = Format(Costo, "$#,##0.00")
                Txt_Precio.Text = Format(Precio, "$#,##0.00")

                DGridS.Rows().Remove(DGridS.CurrentRow)
                ContArt = ContArt - 1
                Txt_Articulos.Text = ContArt
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
        If DGridS.Rows.Count = 0 Then Exit Sub
        If IsDBNull(DGridS.Rows(DGridS.CurrentRow.Index).Cells(1).Value) Then
        Else
            'If Opcion = 1 Then
            '    Txt_Serie.Text = DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value
            'End If
            CargarFotoArticulo(DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_marca").Value, DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_estilon").Value)
        End If
    End Sub

    Private Sub DGridS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGridS.KeyUp
        If DGridS.Rows.Count = 0 Then Exit Sub
        If IsDBNull(DGridS.Rows(DGridS.CurrentRow.Index).Cells(1).Value) Then
        Else
            If Opcion = 1 Then
                'Txt_Serie.Text = DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_serie").Value
            End If
            CargarFotoArticulo(DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_marca").Value, DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_estilon").Value)
        End If
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

    Private Sub Btn_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Serie As String = ""
        Dim intContador As Integer = 0

        Dim intContadorBA As Integer = 0
        Dim intContadorTR As Integer = 0
        Try

            If Txt_Sucursal.Text = "" Then
                MessageBox.Show("Debe ingresar la sucursal de envío del traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_Sucursal.Text = ""
                Txt_Sucursal.Focus()
                Exit Sub
            End If

            Dim myForm As New frmCargaArchivoTaspaso


            myForm.ShowDialog()


            For i As Integer = 0 To myForm.DGrid.Rows.Count - 1

                If myForm.DGrid.Rows(i).Cells("colCorrectos").Value <> "" Then
                    Serie = myForm.DGrid.Rows(i).Cells("colCorrectos").Value
                End If

                Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                    objDataSet = objTraspasos.usp_TraerSerieEnDetTraspasoAC(Serie)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("serie") = Serie Then
                            intContadorTR += 1
                            Continue For
                        End If
                    End If
                End Using


                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                    objDataSet = objTraspasos.usp_TraerTraspasoSerieDescrip(Serie)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        If Txt_Sucursal.Text <> objDataSet.Tables(0).Rows(0).Item("sucursal") Then
                            'MessageBox.Show(" El Código NO existe en la sucursal que Envía.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Continue For
                        End If

                        If objDataSet.Tables(0).Rows(0).Item("status") = "BA" Then
                            intContadorBA += 1
                            Continue For
                        ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "TR" Then
                            intContadorTR += 1
                            Continue For
                        End If


                        DGridS.Rows.Add(objDataSet.Tables(0).Rows(0).Item("serie").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("marca").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("estilon").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("corrida").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("medida").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("descripc").ToString, _
                                           Val(objDataSet.Tables(0).Rows(0).Item("costo")), _
                                           Val(objDataSet.Tables(0).Rows(0).Item("costomargen")), _
                                           Val(objDataSet.Tables(0).Rows(0).Item("precio")))
                        intContador += 1
                    End If
                End Using
            Next

            If intContador > 0 Then
                MessageBox.Show(intContador.ToString + " Articulos agregados correctamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'DGrid.Rows.Clear()
                ContArt = DGridS.Rows.Count
                Txt_Articulos.Text = ContArt

                If blnEsSuc Then
                    DGridS.Columns("col_costo").Visible = False
                    DGridS.Columns("col_precio").Visible = False
                    Lbl_Costo.Visible = False
                    Lbl_Precio.Visible = False
                End If

                Call CalculaImportes()
            End If

            If intContadorBA > 0 Then
                MessageBox.Show(intContadorBA.ToString + " series del archivo se encuentran dadas de BAJA.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If intContadorTR > 0 Then
                MessageBox.Show(intContadorTR.ToString + " series del archivo ya se encuentran en otro TRASPASO.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        Try
  
            Txt_Estatus.Text = "SALIDA"


            Call ImprimirReporte()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReporte()
        Try
            Dim myForm As New frmReportsBrowser
            Opcion = Opcion
           
            myForm.objDataSetReporteTraspaso = GenerarReporte()
            myForm.WindowState = FormWindowState.Maximized
           
            myForm.ReportIndex = 2301

            myForm.Show()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function GenerarReporte() As DSPReporteTraspasos
        'mreyes 13/Diciembre/2016   05:02 p.m.

        Try


            Dim origen As String = ""
            Dim destino As String = ""
            Dim origendescrip As String = ""
            Dim destinodescrip As String = ""
            Dim usuario As String = ""
            Dim envia As String = ""
            Dim transporta As String = ""
            Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringSirCoSQL)
                objDataSet = objReporte.usp_ImprimeTraspasos(1, Txt_Sucursal.Text, Txt_Referencia.Text)
                origen = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                destino = objDataSet.Tables(0).Rows(0).Item("sucurdes").ToString
            End Using
            Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringDwhSQL)
                objDataSet2 = objReporte.usp_TraerSucursalTR(origen)
                origendescrip = objDataSet2.Tables(0).Rows(0).Item("descrip").ToString
                objDataSet2 = objReporte.usp_TraerSucursalTR(destino)
                destinodescrip = objDataSet2.Tables(0).Rows(0).Item("descrip").ToString
            End Using
            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("idusuario"), "", "", "", "", 0)
                If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                    usuario = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString
                End If
            End Using

            envia = Txt_IdMov1.Text
      
            transporta = Txt_IdMov2.Text


            GenerarReporte = New DSPReporteTraspasos
            With objDataSet
                For I As Integer = 0 To .Tables(0).Rows.Count - 1
                    Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()


                    objDataRow.Item("folio") = .Tables(0).Rows(I).Item("folio").ToString
                    objDataRow.Item("foliosuc") = .Tables(0).Rows(I).Item("foliosuc").ToString
                    objDataRow.Item("origen") = origendescrip
                    objDataRow.Item("usuario") = usuario
                    objDataRow.Item("observa") = .Tables(0).Rows(I).Item("observa").ToString
                    objDataRow.Item("sucurdes") = .Tables(0).Rows(I).Item("sucurdes").ToString
                    objDataRow.Item("destino") = destinodescrip
                    objDataRow.Item("fecha") = .Tables(0).Rows(I).Item("fecha").ToString
                    objDataRow.Item("serie") = .Tables(0).Rows(I).Item("serie").ToString
                    objDataRow.Item("marca") = .Tables(0).Rows(I).Item("marca").ToString
                    objDataRow.Item("estilon") = .Tables(0).Rows(I).Item("estilon").ToString
                    objDataRow.Item("estilof") = .Tables(0).Rows(I).Item("estilof").ToString
                    objDataRow.Item("medida") = .Tables(0).Rows(I).Item("medida").ToString
                    objDataRow.Item("descripc") = .Tables(0).Rows(I).Item("descripc").ToString
                    objDataRow.Item("ctdori") = .Tables(0).Rows(I).Item("ctdori").ToString
                    If DGridS.Rows(I).Cells("col_serie").Value = .Tables(0).Rows(I).Item("serie").ToString Then
                        objDataRow.Item("costo") = DGridS.Rows(I).Cells("col_costomargen").Value
                    End If
                    If DGridS.Rows(I).Cells("col_serie").Value = .Tables(0).Rows(I).Item("serie").ToString Then
                        objDataRow.Item("precio") = DGridS.Rows(I).Cells("col_precio").Value
                    End If
                    If blnEsSuc = True Then
                        objDataRow.Item("estienda") = True
                        objDataRow.Item("costo") = 0.0
                    Else
                        objDataRow.Item("estienda") = False
                    End If
                    objDataRow.Item("opcion") = Opcion.ToString
                    objDataRow.Item("envia") = envia
                    objDataRow.Item("transporta") = transporta

                    If ImprimeTrasp = True Then
                        objDataRow.Item("estatus") = "APLICADO"
                    Else
                        objDataRow.Item("estatus") = Txt_Estatus.Text
                    End If

                    objDataRow.Item("idtraspaso") = CInt(Txt_IdTraspaso.Text)
                    GenerarReporte.Tables(0).Rows.Add(objDataRow)
                Next
            End With

            'Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Txt_Referencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Referencia.KeyPress
        pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdTraspaso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdTraspaso.KeyPress
        pub_SoloNumeros(sender, e)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    ''Private Sub Txt_IdTraspaso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdTraspaso.LostFocus
    ''    Dim intContador As Integer = 0
    ''    Dim objDataSetAux As Data.DataSet
    ''    Try
    ''        If Txt_IdTraspaso.Text.Length = 0 Then Exit Sub
    ''        'Txt_Referencia.Text = pub_RellenarIzquierda(Txt_Referencia.Text, 6)

    ''        If Txt_Sucursal.Text.Length = 0 Then
    ''            MessageBox.Show("Debe ingresar la Sucursal que Recibe el Traspaso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''            Txt_Sucursal.Text = ""
    ''            Txt_Sucursal.Focus()
    ''            Exit Sub
    ''        End If

    ''        If Txt_Destino.Text.Length = 0 Then
    ''            MessageBox.Show("Debe ingresar la Sucursal de Orígen del Traspaso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''            Txt_Destino.Text = ""
    ''            Txt_Destino.Focus()
    ''            Exit Sub
    ''        End If

    ''        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
    ''            objDataSet = objTraspasos.usp_PpalTraspasosManualOri(Txt_Destino.Text, Txt_Referencia.Text, Txt_Referencia.Text, Txt_Sucursal.Text, "1900-01-01", "1900-01-01", "", CInt(Txt_IdTraspaso.Text), CInt(Txt_IdTraspaso.Text), "1900-01-01", "1900-01-01")
    ''        End Using
    ''        If objDataSet.Tables(0).Rows.Count > 0 Then
    ''            If objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "RECIBIDO" Then
    ''                MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' ya fue recibido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''                Txt_IdTraspaso.Text = ""
    ''                Txt_IdTraspaso.Focus()
    ''                Exit Sub
    ''            ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "PARCIAL" Then
    ''                Using objTraspasos1 As New BCL.BCLTraspasos(GLB_ConStringCipSis)
    ''                    objDataSetAux = objTraspasos1.usp_TraerCtdTraspasosOri(Txt_Destino.Text, "", CInt(Txt_IdTraspaso.Text))
    ''                End Using
    ''                If objDataSetAux.Tables(0).Rows.Count < 3 Then
    ''                Else
    ''                    MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' ya fue recibido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''                    Txt_IdTraspaso.Text = ""
    ''                    Txt_IdTraspaso.Focus()
    ''                    Exit Sub
    ''                End If
    ''            ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "CANCELADO" Then
    ''                MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' está cancelado.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''                Txt_IdTraspaso.Text = ""
    ''                Txt_IdTraspaso.Focus()
    ''                Exit Sub
    ''            ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "CAPTURA" Then
    ''                MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' tiene estatus de CAPTURA, no puede recibirlo aún.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''                Txt_IdTraspaso.Text = ""
    ''                Txt_IdTraspaso.Focus()
    ''                Exit Sub
    ''            End If
    ''        End If



    ''        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
    ''            objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Txt_Destino.Text, Txt_Referencia.Text, Txt_Sucursal.Text, CInt(Txt_IdTraspaso.Text))

    ''            If objDataSet.Tables(0).Rows.Count > 0 Then
    ''                If blnEsSuc Then
    ''                    DGridS.Columns("col_costo").Visible = False
    ''                    DGridS.Columns("col_precio").Visible = False
    ''                    Lbl_Costo.Visible = False
    ''                    Lbl_Precio.Visible = False
    ''                    Txt_Costo.Visible = False
    ''                    Txt_Precio.Visible = False
    ''                End If

    ''                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
    ''                    If objDataSet.Tables(0).Rows(i).Item("recibido") = 0 Then
    ''                        cantArt += 1
    ''                    End If
    ''                Next

    ''                'cantArt = objDataSet.Tables(0).Rows.Count

    ''                Lbl_LecturaSeries.Text = "Escaneados: 0 de " + cantArt.ToString

    ''                Txt_Referencia.Text = objDataSet.Tables(0).Rows(0).Item("traspaso")

    ''                Txt_IdMov1.Text = objDataSet.Tables(0).Rows(0).Item("transporta")
    ''                If Txt_IdMov1.Text.Length > 0 Then
    ''                    Call Txt_IdMov1_LostFocus(sender, e)
    ''                End If

    ''                '' Edicion de componentes
    ''                Lbl_LecturaSeries.Visible = True
    ''                Txt_Sucursal.Enabled = False
    ''                Txt_Destino.Enabled = False
    ''                Txt_Referencia.Enabled = False
    ''                Txt_IdTraspaso.Enabled = False

    ''                'Txt_Serie.Enabled = False

    ''                Txt_Destino.BackColor = TextboxBackColor
    ''                Txt_Sucursal.BackColor = TextboxBackColor
    ''                Txt_Observaciones.BackColor = TextboxBackColor
    ''                Txt_Serie.BackColor = TextboxBackColor
    ''            Else
    ''                MessageBox.Show(" El Envío no existe...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''                Txt_Referencia.Text = ""
    ''                Txt_Referencia.Focus()
    ''            End If
    ''        End Using
    ''    Catch ExceptionErr As Exception
    ''        MessageBox.Show(ExceptionErr.Message.ToString)
    ''    End Try
    ''End Sub

    Private Sub Txt_Referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Referencia.LostFocus
       
    End Sub

    Private Sub Txt_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Serie.TextChanged
        If Txt_Serie.Text = "" Then Exit Sub
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
                Txt_Serie.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Sucursal_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged
        Try
            If Txt_Sucursal.Text.Length = 2 Then
                Txt_Destino.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Destino_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Destino.TextChanged
        Try
            If Txt_Destino.Text.Length = 2 Then
                Txt_Referencia.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Referencia.TextChanged
        Try
            If Txt_Referencia.Text.Length = 6 Then
                Txt_Observaciones.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFormaConsultaEmpleadoM1()
        Dim myForm As New frmConsultaEmpleado
        Txt_DescripM1.Text = ""
        myForm.Estatus = "A"
        myForm.ShowDialog()
        Txt_IdMov1.Text = myForm.Campo
        Txt_DescripM1.Text = myForm.Campo1
        If Txt_IdMov1.Text.Length = 0 Then
            Txt_IdMov1.Focus()
        End If
    End Sub

    Private Sub CargarFormaConsultaEmpleadoM2()
        Dim myForm As New frmConsultaEmpleado
        Txt_DescripM2.Text = ""
        myForm.Estatus = "A"
        myForm.ShowDialog()
        Txt_IdMov2.Text = myForm.Campo
        Txt_DescripM2.Text = myForm.Campo1
        If Txt_IdMov2.Text.Length = 0 Then
            Txt_IdMov2.Focus()
        End If
    End Sub

    Private Sub usp_TraerEmpleadoM1()
        'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_IdMov1.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_IdMov1.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_DescripM1.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoM1()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerEmpleadoM2()

        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_IdMov2.Text.Length = 0 Then Exit Sub
                'If Txt_IdMov2.Text.Length = 1 Then
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_IdMov2.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count = 1 Then

                    Txt_DescripM2.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoM2()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                'End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_IdMov1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdMov1.LostFocus
        Try
            If Txt_IdMov1.Text.Length = 0 Then Exit Sub
            If Txt_IdMov1.Text = "0" Then Exit Sub
            Call usp_TraerEmpleadoM1()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdMov2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdMov2.LostFocus
        Try
            If Txt_IdMov2.Text.Length = 0 Then Exit Sub
            If Txt_IdMov2.Text = "0" Then Exit Sub

            Call usp_TraerEmpleadoM2()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGridS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridS.CellContentClick

    End Sub

    Private Sub Txt_IdMov1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdMov1.TextChanged

    End Sub

    Private Sub Txt_CodigoBarras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CodigoBarras.KeyPress
        
    End Sub

    Private Sub Txt_CodigoBarras_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CodigoBarras.LostFocus
        'mreyes 15/Diciembre/2016   11:33 a.m.
        Try
       
            'If Txt_CodigoBarras.TextLength <> 8 Then
            '    BlockInput(True)
            'End If
            If Txt_CodigoBarras.Text = "" Then Exit Sub
            If blnEsSuc = True Then
                If Mid(Txt_CodigoBarras.Text, 1, 2) <> GLB_CveSucursal Then
                    Txt_CodigoBarras.Text = ""

                    MsgBox("No puede dar Salida a un traspaso, que no pertenece a su sucursal.", MsgBoxStyle.Critical, "Error")
                    Btn_Aceptar.Enabled = False
                    Btn_Imprimir.Enabled = False
                    Txt_CodigoBarras.Focus()
                    Exit Sub
                End If
            End If

            Txt_Sucursal.Text = Mid(Txt_CodigoBarras.Text, 1, 2)
            Txt_Referencia.Text = Mid(Txt_CodigoBarras.Text, 3, 6)

            


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                If Txt_Sucursal.Text.Length = 0 Then Exit Sub

                Try
                    'Get the specific project selected in the ListView control
                    If Txt_Sucursal.Text.Trim.Length < 2 Then
                        Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                    End If

                    Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


            Dim intContador As Integer = 0
            Dim objDataSetAux As Data.DataSet
            Try

                If Txt_Referencia.Text.Length = 0 Then Txt_CodigoBarras.Focus() : Exit Sub
                Txt_Referencia.Text = pub_RellenarIzquierda(Txt_Referencia.Text, 6)


                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                    objDataSet = objTraspasos.usp_PpalTraspasosManualOri(Txt_Sucursal.Text, Txt_Referencia.Text, Txt_Referencia.Text, Txt_Destino.Text, "1900-01-01", "1900-01-01", "", 0, 0, "1900-01-01", "1900-01-01")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Destino.Text = objDataSet.Tables(0).Rows(0).Item("sucurdes").ToString.Trim

                        If objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "RECIBIDO" Then
                            MessageBox.Show("El Traspaso con el Folio '" + Txt_Referencia.Text + "' ya fue recibido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Referencia.Text = ""
                            Txt_Referencia.Focus()
                            Exit Sub
                        ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "PARCIAL" Then
                            Using objTraspasos1 As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                                objDataSetAux = objTraspasos1.usp_TraerCtdTraspasosOri(Txt_Sucursal.Text, Txt_Referencia.Text, 0)
                            End Using
                            If objDataSetAux.Tables(0).Rows.Count = 3 Then
                            Else
                                MessageBox.Show("El Traspaso con el Folio '" + Txt_Referencia.Text + "' ya fue recibido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Txt_Referencia.Text = ""
                                Txt_Referencia.Focus()
                                Exit Sub
                            End If

                        ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "CANCELADO" Then
                            MessageBox.Show("El Traspaso con el Folio '" + Txt_Referencia.Text + "' está cancelado.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Referencia.Text = ""
                            Txt_Referencia.Focus()
                            Exit Sub
                        ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "CAPTURA" Then
                            MessageBox.Show("El Traspaso con el Folio '" + Txt_Referencia.Text + "' tiene estatus de CAPTURA, no puede hacer el MATCH aún.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_Referencia.Text = ""
                            Txt_Referencia.Focus()
                            Exit Sub
                        End If
                    End If
                End Using


                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                    objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Txt_Sucursal.Text, Txt_Referencia.Text, Txt_Destino.Text, 0, 0)

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If blnEsSuc Then
                            DGridS.Columns("col_costomargen").Visible = False
                            DGridS.Columns("col_precio").Visible = False
                            Lbl_Costo.Visible = False
                            Lbl_Precio.Visible = False
                            Txt_Costo.Visible = False
                            Txt_Precio.Visible = False
                        End If

                        For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            If objDataSet.Tables(0).Rows(i).Item("recibido") = 0 Then
                                cantArt += 1
                            End If
                        Next

                        'cantArt = objDataSet.Tables(0).Rows.Count
                        If objDataSet.Tables(0).Rows(0).Item("salida") = 1 Then
                            MsgBox("Salida de Traspaso ya realizada, con anterioridad.", MsgBoxStyle.Critical, "Aviso")
                            Btn_Aceptar.Enabled = False
                        End If

                        Lbl_LecturaSeries.Text = "Escaneados: 0 de " + cantArt.ToString

                        Txt_IdTraspaso.Text = objDataSet.Tables(0).Rows(0).Item("idtraspaso")


                        Txt_IdMov1.Text = objDataSet.Tables(0).Rows(0).Item("envia")

                        Txt_Observaciones.Text = objDataSet.Tables(0).Rows(0).Item("observa")
                        If Txt_IdMov1.Text.Length > 0 Then
                            Call Txt_IdMov1_LostFocus(sender, e)
                        End If

                        ' se agrega el 05/Septiembre/2019   11:32 el usuario que hace salida.


                        'Txt_IdMov2.Enabled = False


                        'Txt_IdMov2.Text = GLB_Idempleado
                        'If Txt_IdMov2.Text.Length > 0 Then
                        '    Call Txt_IdMov2_LostFocus(sender, e)
                        '    Txt_IdMov2.Enabled = False
                        '    ' Txt_Serie.Focus()
                        'End If
                        ' se quita validación el 20/enero/2021  09:07 a.m.

                        ''If GLB_Idempleado <> 132 Then
                        ''    If Txt_IdMov2.Text = Txt_IdMov1.Text Then
                        ''        MessageBox.Show("No puede realizar la salida del traspaso, la misma persona que lo opero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        ''        Txt_IdMov2.Text = ""
                        ''        Me.Close()
                        ''        Me.Dispose()
                        ''        Exit Sub
                        ''    End If
                        ''End If


                        '' Edicion de componentes
                        Lbl_LecturaSeries.Visible = True
                            Txt_Sucursal.Enabled = False
                            Txt_Destino.Enabled = False
                            Txt_Referencia.Enabled = False
                            Txt_Referencia.Enabled = False
                            Txt_IdTraspaso.Enabled = False

                            'Txt_Serie.Enabled = False

                            Txt_Destino.BackColor = TextboxBackColor
                            Txt_Sucursal.BackColor = TextboxBackColor
                            Txt_Observaciones.BackColor = TextboxBackColor
                            Txt_Serie.BackColor = TextboxBackColor
                        Txt_CodigoBarras.Enabled = False

                    Else
                            MessageBox.Show(" El Envío no existe para la sucursal " + Txt_DescripDestino.Text + ".", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_CodigoBarras.Text = ""
                        Txt_CodigoBarras.Focus()
                    End If
                End Using
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Sub Txt_CodigoBarras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CodigoBarras.TextChanged
        Try

            If Txt_CodigoBarras.Text.Length = 8 Then
                '  BlockInput(False)
                Txt_CodigoBarras.ForeColor = Color.Black
                Txt_IdMov2.Focus()
            Else
                '  Txt_CodigoBarras.Text = ""
                Txt_CodigoBarras.ForeColor = Color.PowderBlue
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Lbl_M1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbl_M1.Click

    End Sub

    Private Sub Txt_IdMov2_TextChanged(sender As Object, e As EventArgs) Handles Txt_IdMov2.TextChanged

    End Sub
End Class