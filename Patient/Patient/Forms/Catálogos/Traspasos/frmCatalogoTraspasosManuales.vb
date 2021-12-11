Public Class frmCatalogoTraspasosManuales
    'Tony Garcia - 14/Agosto/2013
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
            Txt_Observaciones.ContextMenuStrip = blankContextMenu
            Txt_Serie.ContextMenuStrip = blankContextMenu

            If ImprimeTrasp = True Then
                Call usp_TraerTraspaso(Txt_Sucursal.Text, Txt_Traspaso.Text, Txt_Destino.Text)
                If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "15" Then
                    blnEsSuc = True
                End If
                ImprimirReporte()
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If
            If blnEsSuc = True Then
                DGridS.Columns("col_costomargen").Visible = False
            End If

            If Opcion = 1 Then
                Me.Text = "Enviar Traspaso"
                Tipo = "M"
            ElseIf Opcion = 2 Then
                Me.Text = "Recibir Traspaso"
                Tipo = "M"
                Btn_Aplicar.Enabled = False
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

            GenerarToolTip()
            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" _
                Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Then
                'Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "15" Then
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
                If Opcion = 1 Then
                    If Txt_Estatus.Text = "" And GLB_CveSucursal <> "15" Then
                        Lbl_CodigoBarras.Text = "Trasp Aut"
                        Lbl_CodigoBarras.Visible = True

                        Txt_IdTraspAut.Visible = True
                        If Val(Txt_IdTraspAut.Text) > 0 Then
                            Txt_IdTraspAut.Enabled = False
                            Txt_Destino.Enabled = False


                        Else
                            Txt_IdTraspAut.Focus()
                        End If
                    End If
                End If
            Else
                Txt_CodigoBarras.Visible = True
                Lbl_CodigoBarras.Visible = True
                Txt_CodigoBarras.Focus()
            End If

            Call Edicion()
            If Accion = 4 Or Accion = 2 Then
                Call usp_TraerTraspaso(Txt_Sucursal.Text, Txt_Traspaso.Text, Txt_Destino.Text)

                If Txt_IdMov1.Text.Length > 0 Then
                    Call Txt_IdMov1_LostFocus(sender, e)
                End If

                If Txt_IdMov2.Text.Length > 0 Then
                    Call Txt_IdMov2_LostFocus(sender, e)
                End If
                ' Btn_Aplicar.Enabled = False
            End If
            If Opcion = 1 And Accion = 1 And blnEsSuc = False Then

                Txt_CodigoBarras.Text = ""
                Txt_CodigoBarras.Visible = False
                Txt_IdFolioSuc.Text = ""
                Txt_IdFolioSuc.Visible = True
                Txt_IdFolioSuc.Enabled = True
                Lbl_IdFolioSuc.Visible = True
                Txt_IdFolioSuc.Focus()
                Lbl_CodigoBarras.Visible = True

            End If
            If GLB_CveSucursal = "15" Then
                Lbl_CodigoBarras.Visible = True
                Txt_IdFolioSuc.Enabled = True
                Txt_IdFolioSuc.Focus()
            End If
            If GLB_Idempleado = 132 Then
                Btn_Archivo.Visible = True
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
                    ElseIf Opcion = 2 Then
                        Txt_Sucursal.Enabled = False
                        Txt_Destino.Enabled = False
                        Txt_Referencia.Enabled = False
                        Txt_IdTraspaso.Enabled = False
                        Txt_CodigoBarras.Visible = True
                        Lbl_CodigoBarras.Visible = True
                        Txt_CodigoBarras.Focus()

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
                    'Btn_Imprimir.Enabled = False
                    Btn_Aceptar.Enabled = False
                    Btn_Aplicar.Enabled = False
                    Txt_IdFolioSuc.Enabled = False


                    ' Btn_Archivo.Enabled = False
                    Txt_Destino.Enabled = False
                    Txt_Sucursal.Enabled = False
                    Txt_Observaciones.Enabled = False
                    Txt_Serie.Enabled = False
                    Txt_Precio.Enabled = False
                    Txt_Referencia.Enabled = False
                    Txt_IdMov1.Enabled = False
                    Txt_IdMov2.Enabled = False
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
                    If Opcion = 4 Then
                        Btn_Imprimir.Enabled = False
                    End If
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
                Label16.Text = "Recibe"
                Label4.Text = "Origen"
                Lbl_Traspaso.Text = "Recepción"

                Lbl_M1.Text = "Transporta"
                Lbl_M2.Text = "Recibe"
                Txt_IdMov1.Enabled = False
                Txt_IdMov2.Enabled = False
                If Opcion = 2 Or Opcion = 4 Then
                    Txt_IdFolioSuc.Visible = False
                    Txt_CodigoBarras.Visible = True
                    Txt_CodigoBarras.Focus()
                End If

                ' Rb_Parcial.Visible = True
                ' Rb_Total.Visible = True


                'Txt_IdMov2.Visible = False
                'Txt_DescripM2.Visible = False
                'Lbl_M2.Visible = False
            End If

            If Accion = 1 And GLB_CveSucursal = "15" Then
                Lbl_IdFolioSuc.Visible = True
                Txt_IdFolioSuc.Visible = True
                Txt_IdFolioSuc.Focus()
            ElseIf Accion = 1 And blnEsSuc = True Then
                Lbl_IdFolioSuc.Visible = False
                Txt_IdFolioSuc.Visible = False
               
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub usp_TraerReciboTraspaso(ByVal FolioB As String)
        'mreyes 15/Diciembre/2016   04:58 p.m.
        Dim intContador As Integer = 0

        Try
            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

                Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    objDataSet = objPedidos.usp_TraerDet_FPTraspaso("", "", Val(FolioB))
                End Using

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

                    Txt_Sucursal.Text = Mid(Txt_IdFolioSuc.Text, 1, 2)

                    Txt_Destino.Text = objDataSet.Tables(0).Rows(0).Item("sucurorc").ToString

                    If Txt_Sucursal.Text = Txt_Destino.Text Then
                        Txt_Observaciones.Text = "RESURTIDO AUTOMÁTICO"
                    End If
                    Txt_DescripDestino.Text = pub_TraerNomSucursal(Txt_Destino.Text)
                    Txt_DescripSucursal.Text = pub_TraerNomSucursal(Txt_Sucursal.Text)


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
                                    Val(objDataSet.Tables(0).Rows(I).Item("proveedor")))
                        intContador += 1
                    Next

                    If intContador > 0 Then
                        ContArt = DGridS.Rows.Count
                        Txt_Articulos.Text = ContArt
                        CargarFotoArticulo(DGridS.Rows(0).Cells("col_marca").Value, DGridS.Rows(0).Cells("col_estilon").Value)
                    End If

                    CalculaImportes()

                End If
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub usp_TraerSeriesTrasResAut(ByVal FolioB As String, SucursalB As String, ultimoFolio As String)
        'mreyes 24/Febrero/2017 05:48 p.m.
        Dim objDataSet As Data.DataSet
        Dim intContador As Integer = 0
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

        Try
            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)

                Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    objDataSet = objPedidos.usp_TraerDet_FPTraspasoResAut(2, Val(FolioB), SucursalB)
                End Using

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If DGridS.Rows.Count >= 1 Then
                        DGridS.RowCount = 2
                        DGridS.Rows.Clear()
                    End If
                    If blnEsSuc Then
                        DGridS.Columns("col_costo").Visible = False
                        DGridS.Columns("col_costomargen").Visible = False
                        'DGridS.Columns("col_precio").Visible = False
                        Lbl_Costo.Visible = False
                        'Lbl_Precio.Visible = False
                        Txt_Costo.Visible = False
                        'Txt_Precio.Visible = False
                    End If

                    Txt_Sucursal.Text = Mid(Txt_IdFolioSuc.Text, 1, 2)

                    Txt_Destino.Text = objDataSet.Tables(0).Rows(0).Item("sucurorc").ToString
                    Txt_DescripDestino.Text = pub_TraerNomSucursal(Txt_Destino.Text)
                    Txt_DescripSucursal.Text = pub_TraerNomSucursal(Txt_Destino.Text)


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
                                    Val(objDataSet.Tables(0).Rows(I).Item("proveedor")))


                        Serie = DGridS.Rows(I).Cells("col_serie").Value



                        Marca = DGridS.Rows(I).Cells("col_marca").Value
                        Estilon = DGridS.Rows(I).Cells("col_estilon").Value
                        Medida = DGridS.Rows(I).Cells("col_medida").Value
                        Corrida = DGridS.Rows(I).Cells("col_corrida").Value
                        Costo = DGridS.Rows(I).Cells("col_costo").Value
                        CostoMargen = DGridS.Rows(I).Cells("col_costomargen").Value
                        Precio = DGridS.Rows(I).Cells("col_precio").Value
                        Proveedor = DGridS.Rows(I).Cells("col_proveedor").Value
                        Idarticulo = DGridS.Rows(I).Cells("col_idarticulo").Value

                        'Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                        '    objDataSet = objTraspasos.usp_TraerIdArticulo(Marca, Estilon)
                        '    If objDataSet.Tables(0).Rows.Count > 0 Then
                        '        Idarticulo = objDataSet.Tables(0).Rows(0).Item("idarticulo").ToString
                        '    End If
                        'End Using




                        Using objTraspasos1 As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objTraspasos1.usp_CapturaDetTraspasoOri(1, IdTRaspaso, Txt_Sucursal.Text, ultimoFolio, Idarticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, 1, CostoMargen, CDbl(Costo), Precio)
                        End Using


                        intContador += 1
                    Next

                    If intContador > 0 Then
                        ContArt = DGridS.Rows.Count
                        Txt_Articulos.Text = ContArt
                        CargarFotoArticulo(DGridS.Rows(0).Cells("col_marca").Value, DGridS.Rows(0).Cells("col_estilon").Value)
                    End If

                    CalculaImportes()

                End If
            End Using


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
                            Rb_Total.Checked = True
                        ElseIf objDataSet.Tables(0).Rows(0).Item("tiporec") = "P" Then
                            Rb_Parcial.Checked = True
                        End If
                    End If
                    Txt_IdTraspAut.Text = objDataSet.Tables(0).Rows(0).Item("idprotras")
                    If Txt_IdTraspAut.Text <> "" Then
                        Txt_IdTraspAut.Enabled = False

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


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CalculaImportes()
        Dim Costo As Decimal = CDec(Txt_Costo.Text)
        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try
            For i As Integer = 0 To DGridS.Rows.Count - 1
                Costo = Costo + CDec(DGridS.Rows(i).Cells("col_costomargen").Value)
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
    Private Sub Subir_Camion(ByVal FolioB As String, ByVal Proveedor As String)
        'mreyes 15/Diciembre/2016 04:44 p.m.
        Try


            Dim Folio As String = ""


            Dim NoGuia As String = ""
            Dim Transporta As String = ""
            Dim NoBultos As Integer = 0
            Dim Recibe As Integer = 0
            Dim FecRecibe As Date = "1900-01-01"
            Dim NombreRec As String = ""
            Dim Entrega As Integer = 0
            Dim NombreEnt As String = ""
            Dim Factura As String = ""
            Dim Comentarios As String = ""
            Dim Usuario As String = ""
            Dim NoSucursal As Integer = 0
            Dim Asigna As Integer = 0
            Dim FecAsigna As Date = "1900-01-01"
            Dim Serie As String = ""
            Dim IdArticulo As Integer = 0
            Dim Marca As String = ""
            Dim Estilon As String = ""
            Dim Medida As String = ""
            Dim Corrida As String = ""
            'Dim Proveedor As String = ""
            Dim Costo As Double = 0
            Dim Precio As Double = 0
            Dim CostoT As Double = 0
            Dim PrecioT As Double = 0

            Dim Idtraspaso As Integer = 0
            Dim CostoTot As Double = 0
            Dim PrecioTot As Double = 0
            Dim intContadorCtd As Integer = 0

            Dim I As Integer = 0
            Dim blnActualizo As Boolean = False
            Dim blnTraspOri As Boolean = False
            Dim ultimoFolio As String = ""
            Dim Sucursal As String = ""
            Dim Guardo As Boolean = False

            Folio = FolioB

            FecAsigna = GLB_FechaHoy


            Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                Guardo = objBultos.usp_Captura_Bulto(6, Val(Folio), Proveedor, "", NoGuia, Transporta, NoBultos, NoSucursal, Comentarios, Recibe, FecRecibe, Asigna, FecAsigna, GLB_Usuario, "1900-01-01 00:00:00", GLB_Usuario, Format(Now, "yyyy-MM-dd hh:mm:ss"), 0, "1900-01-01 00:00:00", GLB_Idempleado, GLB_Idempleado, GLB_Idempleado, 0, GLB_CveSucursal, "", "", 0, "")
            End Using




            Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)
                Guardo = objBultos.usp_Captura_Bulto(7, Val(Folio), Proveedor, "", NoGuia, Transporta, NoBultos, NoSucursal, Comentarios, Recibe, FecRecibe, Asigna, FecAsigna, GLB_Usuario, "1900-01-01 00:00:00", GLB_Usuario, Format(Now, "yyyy-MM-dd hh:mm:ss"), 0, "1900-01-01 00:00:00", GLB_Idempleado, GLB_Idempleado, GLB_Idempleado, GLB_Idempleado, GLB_CveSucursal, "", "", 0, "")
            End Using


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Dim CtdResAut As Integer = 0

        If Txt_Destino.Text = "00" Or Txt_Destino.Text = "" Then
            MsgBox("Se detendrá el proceso, ya que el traspaso en captura pretende ser enviado a una tienda NO OPERATIVA, VUELVA A INICIAR.", MsgBoxStyle.Critical, "Error")
            Btn_Aceptar.Enabled = True
            Exit Sub
        End If

        Using objTransaccion As New BCL.BCLTraspasos(GLB_ConStringSirCoSQL)
            Try
                If Not ValidarEdicion() Then Exit Sub

                If Opcion = 1 Or Opcion = 3 Then 'Envio de Traspaso
                    Dim ultimoFolio As String = ""
                    Dim blnTraspOri As Boolean = False
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

                    If Accion = 1 Then
                        If GLB_IdDeptoEmpleado <> 4 And Txt_Destino.Text = "15" Then
                            GoTo equis
                        End If
                        If Txt_Destino.Text = "15" And GLB_Idempleado <> 132 Then


                            If MessageBox.Show("El sistema generará traspasos para varias sucursales." + Txt_DescripDestino.Text + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                            '' CORRER EL DESGLOSE PARA LOS TRASPASOS

                            Btn_Aceptar.Enabled = False

                            If usp_GeneraTraspasoCurvaIdeal() = False Then

                            End If
                            Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                objDataSet = objMySqlGral.usp_TraerSeries("R", "", FolioB, FolioB, "", "", "", "", "", "", "", "", "", "", "", "")
                                '' mostrar como quedarían los traspasos,.. mandar imprimir 
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    'Populate the Project Details section
                                    DGridS.DataSource = Nothing
                                    DGridS.Columns.Clear()
                                    DGridS.Rows.Clear()
                                    DGridS.DataSource = objDataSet.Tables(0)
                                    'InicializaGrid()
                                End If
                            End Using
                            If Txt_IdFolioSuc.Text <> "" Then
                                Call Subir_Camion(FolioB, "")
                            End If


                            MsgBox("Se generaron los listados para realización de traspasos correspondientes", MsgBoxStyle.Information, "Confirmación")
                            Opcion = 8
                            Call ImprimirReporte()
                            Sw_Registro = True
                            Me.Close()

                            GoTo BRINCO

                        Else
equis:
                            If MessageBox.Show("Esta seguro que desea generar el traspaso para la sucursal " + Txt_DescripDestino.Text + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub


                                Btn_Aceptar.Enabled = False

                                If idfoliosucresaut = "" Then
                                    If Txt_IdFolioSuc.Text <> "" Then
                                        Call Subir_Camion(FolioB, "")
                                    End If
                                Else
                                    '' es de traspaso automático
                                    Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                        objDataSet = objMySqlGral.usp_TraerSeries("Z", Txt_Destino.Text, FolioB, FolioB, "", "", "", "", "", "", "", "", "", "", "", "")
                                        '' mostrar como quedarían los traspasos,.. mandar imprimir 
                                        If objDataSet.Tables(0).Rows.Count > 0 Then
                                            CtdResAut = Val(objDataSet.Tables(0).Rows(0).Item("CTD"))

                                        End If
                                    End Using
                                    If CtdResAut <> Val(Txt_Articulos.Text) Then
                                        MsgBox("Se detendrá el proceso, ya que el traspaso en captura no concuerda con la petición de compras.", MsgBoxStyle.Critical, "Error")
                                        Btn_Aceptar.Enabled = True
                                        Exit Sub
                                    End If

                                    Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                        objDataSet = objMySqlGral.usp_TraerSeries("Y", Txt_Destino.Text, FolioB, FolioB, "", "", "", "", "", "", "", "", "", "", "", "")
                                    End Using

                                End If

                                Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringPerSis)
                                    objDataSet = objTraspasos.usp_TraerFolioUltimoTraspaso(Txt_Sucursal.Text)
                                End Using
                                ultimoFolio = CStr(CInt(objDataSet.Tables(0).Rows(0).Item("Traspaso")) + 1)
                                ultimoFolio = pub_RellenarIzquierda(ultimoFolio, 6)

                                If Accion = 1 Then
                                    Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringPerSis)
                                        objTraspasos.usp_ActualizarFolioTraspaso(ultimoFolio, Txt_Sucursal.Text)
                                    End Using
                                End If

                            End If
                        ElseIf Accion = 2 Then
                            If MessageBox.Show("Esta seguro que desea modificar el traspaso con el folio " + Txt_Traspaso.Text + " de sucursal " + Txt_DescripSucursal.Text + "?", "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub
                        Btn_Aceptar.Enabled = False

                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objTraspasos.usp_CapturaDetTraspasoOri(2, 0, Txt_Sucursal.Text, Txt_Traspaso.Text, 0, "", "", "", "", "", "", 0, 0.0, 0.0, 0.0)
                        End Using
                        ultimoFolio = Txt_Traspaso.Text
                    End If

                    ''' PROGRAMACIÓN PERDIDA, TRASPASO AUTOMATICO
                    If Txt_IdFolioSuc.Text <> "" Then

                        contador = Val(Txt_Articulos.Text)
                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objTraspasos.usp_GeneraTraspasoReciboMYSQL(FolioB, Idtraspaso, Txt_Sucursal.Text, ultimoFolio)
                        End Using
                        '-- termino de generar detallado.
                        Using objTraspasos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                            objTraspasos.usp_ActualizarSerieReciboSQL(FolioB, Txt_Destino.Text)
                        End Using


                    Else



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

                            'Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                            '    objDataSet = objTraspasos.usp_TraerIdArticulo(Marca, Estilon)
                            '    If objDataSet.Tables(0).Rows.Count > 0 Then
                            '        Idarticulo = objDataSet.Tables(0).Rows(0).Item("idarticulo").ToString
                            '    End If
                            'End Using



                            contador += 1
                            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                                objTraspasos.usp_CapturaDetTraspasoOri(1, Idtraspaso, Txt_Sucursal.Text, ultimoFolio, Idarticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, 1, CostoMargen, CDbl(Costo), Precio)
                            End Using
                            If FolioB > 0 Then
                                Using objTraspasos11 As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                                    objTraspasos11.usp_ActualizarSerie(Serie, (Txt_Sucursal.Text), "TR", (Txt_Destino.Text))
                                End Using




                            End If

                        Next

                    End If  '' del que tiene folio


                    If contador > 0 Then
                        'solo checa si foliob > 0 then, lo esta aplicando 
                        If FolioB > 0 Then
                            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                                blnTraspOri = objTraspasos.usp_CapturaTraspasoOri(Accion, Txt_Sucursal.Text, ultimoFolio, Tipo, FolioB, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd"), Now.TimeOfDay.ToString,
                                                                                  Txt_Destino.Text, Txt_Observaciones.Text.Trim, GLB_Usuario, CInt(Txt_Articulos.Text), CDec(Txt_Costo.Text), CDec(Txt_Precio.Text),
                                                                                  CInt(Txt_IdMov1.Text), CInt(Txt_IdMov2.Text), GLB_Idempleado, Val(Txt_IdTraspAut.Text))
                            End Using

                            ' agregar el cambio serie SQL
                            ' mreyes 20/Julio/2021  01:01 p.m.




                        Else
                            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                                blnTraspOri = objTraspasos.usp_CapturaTraspasoOri(Accion, Txt_Sucursal.Text, ultimoFolio, Tipo, FolioB, "CA", GLB_FechaHoy.ToString("yyyy-MM-dd"), Now.TimeOfDay.ToString,
                                                                                  Txt_Destino.Text, Txt_Observaciones.Text.Trim, GLB_Usuario, CInt(Txt_Articulos.Text), CDec(Txt_Costo.Text), CDec(Txt_Precio.Text),
                                                                                  CInt(Txt_IdMov1.Text), CInt(Txt_IdMov2.Text), GLB_Idempleado, Val(Txt_IdTraspAut.Text))
                            End Using

                        End If
                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objDataSet = objTraspasos.usp_TraerIdTraspaso(1, Txt_Sucursal.Text, ultimoFolio)
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Idtraspaso = objDataSet.Tables(0).Rows(0).Item("idtraspaso").ToString
                                Txt_IdTraspaso.Text = objDataSet.Tables(0).Rows(0).Item("idtraspaso").ToString
                            End If
                        End Using

                        Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                            objTraspasos.usp_ActualizaIdTraspasoDet(1, Txt_Sucursal.Text, ultimoFolio, Idtraspaso)
                        End Using
                        If FolioB > 0 Then
                            ' HACER EL MATCH DE TRASPASO
                            If usp_MatchPropuestaTraspaso() Then

                            End If

                            Txt_Estatus.Text = "APLICADO"
                            Txt_Traspaso.Text = ultimoFolio

                            Call ImprimirReporte()
                        End If


                        MessageBox.Show(contador.ToString + " artículos capturados correctamente en el traspaso con el Folio: " + ultimoFolio + " para sucursal " + Txt_DescripDestino.Text, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Btn_Aceptar.Enabled = True
                        If GLB_CveSucursal.Trim = "" Then
                            Txt_Sucursal.Enabled = False
                            Txt_DescripSucursal.Enabled = False
                            Txt_Sucursal.BackColor = Color.White
                        End If
                        Lbl_Traspaso.Visible = True
                        Txt_Traspaso.Visible = True
                        Txt_Traspaso.Text = ultimoFolio
                        Label5.Visible = True
                        Label5.Text = "Artículos en el traspaso: " + contador.ToString
                        Txt_Destino.Enabled = False
                        Txt_Sucursal.Enabled = False
                        Txt_DescripDestino.Enabled = False
                        Txt_Serie.Enabled = False
                        'Btn_Archivo.Enabled = False
                        Accion = 4
                        Txt_Observaciones.Enabled = False
                        Txt_Observaciones.BackColor = Color.White
                        Btn_Aceptar.Enabled = False
                        Btn_Aplicar.Enabled = False

                        'Call Btn_Imprimir_Click(sender, e)
                        Sw_Registro = True
                        Me.Close()
                    Else
                        MessageBox.Show("No se pudo realizar el traspaso, ya que los artículos no deben estar en la sucursal " + Txt_DescripSucursal.Text, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If



                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                ElseIf Opcion = 2 Or Opcion = 4 Then 'Recepción de Traspaso
                    If cantArt <> Val(Txt_Articulos.Text) Then

                        MsgBox("No se puede recibir parcial el Traspaso, verifique el escaneo.", MsgBoxStyle.Critical, "Error")
                        Txt_Serie.Focus()
                        Exit Sub
                    End If


                    If MessageBox.Show("Está seguro de Recibir el Traspaso con Folio '" + Txt_Referencia.Text + "' de sucursal " + Txt_DescripDestino.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    Btn_Aceptar.Enabled = False
                    Dim myForm As New frmSeriesNoRecibidasTR

                    Dim ultimoFolio As String = ""
                    Dim blnTraspDes As Boolean = False
                    'Dim Serie As String = ""
                    'Dim Marca As String = ""
                    'Dim Estilon As String = ""
                    'Dim Medida As String = ""
                    'Dim Proveedor As String = ""
                    'Dim Corrida As String = ""
                    'Dim Costo As String = ""
                    'Dim CostoMargen As Double = 0.0
                    'Dim Precio As Double = 0.0
                    'Dim Idarticulo As Integer = 0
                    'Dim Idtraspaso As Integer = 0
                    'Dim blnActualizo As Boolean = False
                    'Dim contador As Integer = 0
                    'Dim blnCompleto As Boolean = False
                    'Dim blnValidaNumTR As Boolean = False

                    Dim intContArt As Integer = 0
                    ultimoFolio = Mid(Txt_CodigoBarras.Text, 3, 6)
                    Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                        blnTraspDes = objTraspasos.usp_GeneraReciboTraspaso(Txt_Destino.Text, ultimoFolio, Txt_Sucursal.Text, Txt_Observaciones.Text.Trim, GLB_Usuario, GLB_Idempleado)
                    End Using



                    ' HACER EL MATCH DE TRASPASO
                    'If usp_MatchPropuestaTraspaso() Then

                    'End If


                    MessageBox.Show(cantArt.ToString + " Artículos Recibidos Correctamente con el Folio: " + ultimoFolio, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If GLB_CveSucursal = "" Then
                        Txt_Sucursal.Enabled = False
                        Txt_DescripSucursal.Enabled = False
                        Txt_Sucursal.BackColor = Color.White
                    End If
                    Lbl_Traspaso.Visible = True
                    Txt_Traspaso.Visible = True
                    Txt_Traspaso.Text = ultimoFolio
                    Label5.Visible = True
                    Label5.Text = "Articulos Recibidos: " + cantArt.ToString
                    Txt_Destino.Enabled = False
                    Txt_Sucursal.Enabled = False
                    Txt_DescripDestino.Enabled = False
                    Txt_Serie.Enabled = False
                    'Btn_Archivo.Enabled = False
                    Accion = 4
                    Txt_Observaciones.Enabled = False
                    Txt_Observaciones.BackColor = Color.White
                    Btn_Aceptar.Enabled = False
                    Btn_Aplicar.Enabled = False

                    Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                        objDataSet = objTraspasos.usp_TraerIdTraspaso(2, Txt_Sucursal.Text, ultimoFolio)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Idtraspaso = objDataSet.Tables(0).Rows(0).Item("idtraspaso").ToString
                            Txt_IdTraspaso.Text = objDataSet.Tables(0).Rows(0).Item("idtraspaso").ToString
                        End If
                    End Using


                    ''Call Btn_Imprimir_Click(sender, e)
                    Sw_Registro = True
                        Me.Close()
                    'Else
                    '    MessageBox.Show("No se pudo recibir el traspaso...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'End If

                End If
                BRINCO:
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try
        End Using
    End Sub
    Private Function usp_GeneraTraspasoCurvaIdeal() As Boolean
        'mreyes 24/Febrero/2012 05:40 a.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()


                usp_GeneraTraspasoCurvaIdeal = objCalculo.usp_GeneraTraspasoCurvaIdeal(FolioB)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
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

            If (Opcion = 1 Or Opcion = 3) And Txt_Destino.Text <> "15" Then
                If Txt_Sucursal.Text = Txt_Destino.Text Then
                    If Sw_ParesUnicos = False Then
                        MsgBox("La sucursal de Destino no puede ser igual a la sucursal de Orígen.", MsgBoxStyle.Critical, "Validación")
                        Txt_Sucursal.Focus()
                        Exit Function
                    End If
                End If
            ElseIf Opcion = 4 Or Opcion = 2 Then
                ''If Txt_Sucursal.Text = Txt_Destino.Text Then
                ''    MsgBox("La sucursal de Orígen no puede ser igual a la sucursal que recibe.", MsgBoxStyle.Critical, "Validación")
                ''    Txt_Sucursal.Focus()
                ''    Exit Function
                ''End If
            End If

            If Txt_Destino.Text = "15" Then
                Txt_Observaciones.Text = "RESURTIDO AUTOMÁTICO"
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

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        If blnEsSuc = True Then
            If Txt_Sucursal.Text = "15" And Txt_IdFolioSuc.Text = "" Then
                MsgBox("No puede realizar un traspaso, sin un recibo previo en folio de bulto.", MsgBoxStyle.Critical, "Error")
                Btn_Aceptar.Enabled = False
                Btn_Aplicar.Enabled = False

                Exit Sub
            End If
        End If

        If GLB_IdDeptoEmpleado = 4 Then 'es cedis
            If Txt_Sucursal.Text = "08" Or Txt_Sucursal.Text = "01" Or Txt_Sucursal.Text = "02" Or Txt_Sucursal.Text = "06" _
                 Or Txt_Sucursal.Text = "20" Or Txt_Sucursal.Text = "95" Or Txt_Sucursal.Text = "19" Or Txt_Sucursal.Text = "18" Or Txt_Sucursal.Text = "11" _
                 Or Txt_Sucursal.Text = "13" Or Txt_Sucursal.Text = "09" Or Txt_Sucursal.Text = "21" Or Txt_Sucursal.Text = "98" Then

                MsgBox("No cuenta con los permisos para realizar un traspaso de esta tienda.", MsgBoxStyle.Critical, "Error")
                Btn_Aceptar.Enabled = False
                Btn_Aplicar.Enabled = False
                Txt_Sucursal.Text = ""
                Txt_Sucursal.Focus()
                Exit Sub
            End If
        End If

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
    End Sub

    Private Sub Txt_Destino_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Destino.LostFocus
        If blnEsSuc = True Then
            If GLB_CveSucursal <> "15" Then

                If Txt_Destino.Text = "20" Or Txt_Destino.Text = "98" Or Txt_Destino.Text = "91" Then
                    MsgBox("No puede enviar traspasos a CEDIS, verifique por favor.", MsgBoxStyle.Critical, "Error")
                    Txt_Destino.Text = ""
                    Txt_Destino.Focus()
                    Exit Sub

                End If
            End If
        End If





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
        If GLB_Idempleado <> 132 Then
            Call BorrarClipboard()
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus
        Dim Costo As Decimal = CDec(Txt_Costo.Text)
        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Dim objDataSet1 As Data.DataSet
        Try
            If GLB_Idempleado <> 132 Then
                Call BorrarClipboard()
            End If
            If Txt_Serie.Text.Length = 0 Or Txt_Serie.Text = "0" Then Exit Sub
            If Txt_Sucursal.Text = "" Then
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                MessageBox.Show("Debe ingresar la sucursal de envío del traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Txt_Sucursal.Text = ""
                Txt_Sucursal.Focus()
                Exit Sub
            End If

            Txt_Serie.Text = pub_RellenarIzquierda(Txt_Serie.Text, 13)


            If Opcion = 1 Or Opcion = 3 Then ''ENVIO
                ' no me convence esta parte
                Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                    objDataSet = objTraspasos.usp_TraerSerieEnDetTraspasoAC(Txt_Serie.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        If objDataSet.Tables(0).Rows(0).Item("serie") = Txt_Serie.Text Then
                            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                            MessageBox.Show("La serie ya está registrada en otro traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()
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

                        If GLB_IdDeptoEmpleado = 3 And (GLB_IdPuestoEmpleado = 5 Or GLB_IdPuestoEmpleado = 6) And Txt_IdFolioSuc.Text = "" And Txt_IdTraspAut.Text = "" Then

                            'If objDataSet.Tables(0).Rows(0).Item("iddivisiones") = 1 Then
                            '    My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                            '    MessageBox.Show("No tiene el permiso para hacer este tipo de traspasos.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                            '    Txt_Serie.Text = ""
                            '    Txt_Sucursal.Focus()
                            '    Exit Sub

                            'End If
                            Txt_Observaciones.Text = "***** TRASPASO HORMIGA ******"
                            Txt_Observaciones.Enabled = False
                        End If


                        If Txt_Sucursal.Text.Length = 0 Then
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                                MessageBox.Show("Debe ingresar la Sucursal que Envía el traspaso.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                Txt_Serie.Text = ""
                                Txt_Sucursal.Focus()
                                Exit Sub
                            End If

                            If Txt_Sucursal.Text <> objDataSet.Tables(0).Rows(0).Item("sucursal") Then
                                MessageBox.Show(" El Código NO existe en la sucursal que Envía.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                                Txt_Serie.Text = ""
                                Txt_Serie.Focus()
                                Exit Sub
                            End If
                            '' CHECAR DE IDPROTRASPAUTOMATICO
                            If Val(Txt_IdTraspAut.Text) > 0 Then
                                Using objIdAut As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                                    objDataSet1 = objIdAut.usp_TraerProTraspDet(Val(Txt_IdTraspAut.Text), objDataSet.Tables(0).Rows(0).Item("marca").ToString, objDataSet.Tables(0).Rows(0).Item("estilon").ToString, objDataSet.Tables(0).Rows(0).Item("medida").ToString)
                                    If objDataSet1.Tables(0).Rows.Count = 0 Then
                                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)

                                        Txt_Serie.Text = ""
                                        Txt_Serie.Focus()

                                        'MessageBox.Show("La serie NO pertenece al traspaso automático.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


                                        Exit Sub

                                    End If
                                End Using
                            End If


                            For j As Integer = 0 To DGridS.Rows.Count - 1
                                If Txt_Serie.Text = DGridS.Rows(j).Cells("col_serie").Value Then
                                    My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                                    MessageBox.Show(" El Código YA está registrado en el Envío.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                                    Txt_Serie.Text = ""
                                    Txt_Serie.Focus()
                                    Exit Sub
                                End If
                            Next

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
                        ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "IF" Then
                            MessageBox.Show(" El Código está en proceso pendiente IF, INFORME A SISTEMAS.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()
                    End If
                Else
                    If Txt_Serie.Text <> "" Then
                        MessageBox.Show(" El Código NO éxiste.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                    Txt_Serie.Text = ""
                    Txt_Serie.Focus()
                End If


            ElseIf Opcion = 2 Or Opcion = 4 Then ''RECIBO

                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                    If Opcion = 2 Or Opcion = 4 Then 'Recibo Traspaso Normal
                        objDataSet = objTraspasos.usp_TraerTraspasosSerieDet(Txt_Destino.Text, Txt_Referencia.Text, Txt_Serie.Text)
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

                Costo = Costo - DGridS.Rows(DGridS.CurrentRow.Index).Cells("col_costomargen").Value
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

    Private Sub Btn_Archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Archivo.Click
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

            DGridS.Visible = False
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


                Using objTraspasos As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoSQL)
                    objDataSet = objTraspasos.usp_TraerTraspasoSerieDescrip(Serie)
                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        'If Txt_Sucursal.Text <> objDataSet.Tables(0).Rows(0).Item("sucursal") Then
                        '    'MessageBox.Show(" El Código NO existe en la sucursal que Envía.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '    Continue For
                        'End If

                        'If objDataSet.Tables(0).Rows(0).Item("status") = "BA" Then
                        '    intContadorBA += 1
                        '    Continue For
                        'ElseIf objDataSet.Tables(0).Rows(0).Item("status") = "TR" Then
                        '    intContadorTR += 1
                        '    Continue For
                        'End If


                        DGridS.Rows.Add(objDataSet.Tables(0).Rows(0).Item("serie").ToString,
                                            objDataSet.Tables(0).Rows(0).Item("idarticulo").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("marca").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("estilon").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("corrida").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("medida").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("descripc").ToString,
                                           Val(objDataSet.Tables(0).Rows(0).Item("costo")),
                                        Val(objDataSet.Tables(0).Rows(0).Item("costomargen")),
                                           Val(objDataSet.Tables(0).Rows(0).Item("precio")),
                                           Val(objDataSet.Tables(0).Rows(0).Item("proveedors")))

                        intContador += 1
                    End If
                End Using
            Next
            DGridS.Visible = True

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
            If Opcion = 1 Or Opcion = 3 Then
                If Txt_Estatus.Text = "CAPTURA" Then Exit Sub
            ElseIf Opcion = 2 Or Opcion = 4 Then
                Txt_Estatus.Text = "APLICADO"
            End If

            Call ImprimirReporte()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImprimirReporte()
        ' se agrega la impresión en detallado para ventas en línea
        ' mreyes    12/05/2021  09:41 a.m.

        Try
            Dim myForm As New frmReportsBrowser
            Opcion = Opcion



            If Opcion = 1 Or Opcion = 3 Then
                myForm.objDataSetReporteTraspaso = GenerarReporte()
                If blnEsSuc = True Then
                    If Plaza = 2 Then
                        myForm.ReportIndex = 20010940
                    Else
                        myForm.ReportIndex = 2001
                    End If
                Else
                    If Plaza = 2 Then
                        myForm.ReportIndex = 200940
                    Else
                        myForm.ReportIndex = 20
                    End If


                End If
                myForm.WindowState = FormWindowState.Maximized
                myForm.Show()
            ElseIf Opcion = 2 Or Opcion = 4 Then
                myForm.objDataSetReporteTraspaso = GenerarReporte()
                myForm.WindowState = FormWindowState.Maximized
                If blnEsSuc = True Then
                    myForm.ReportIndex = 2101
                Else

                    myForm.ReportIndex = 21
                End If
                myForm.Show()
            ElseIf Opcion = 8 Then
                '' CUANDO ES RESURTIDO AUTOMÁTICO 
                myForm.objDataSetReporteTraspaso = GenerarReporte()
                myForm.WindowState = FormWindowState.Maximized

                myForm.ReportIndex = 210102
                myForm.Show()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function GenerarReporte() As DSPReporteTraspasos
        'Roberto 04/03/13
        Try
            If Opcion = 8 Then
                GenerarReporte = New DSPReporteTraspasos
                For I As Integer = 0 To DGridS.RowCount - 1
                    Dim objDataRow As Data.DataRow = GenerarReporte.Tables(0).NewRow()
                    objDataRow.Item("sucurdes") = Mid(DGridS.Rows(I).Cells("sucursal").Value, 1, 2)
                    objDataRow.Item("destino") = Mid(DGridS.Rows(I).Cells("sucursal").Value, 4)
                    objDataRow.Item("marca") = DGridS.Rows(I).Cells("marca").Value
                    objDataRow.Item("estilon") = DGridS.Rows(I).Cells("modelo").Value
                    objDataRow.Item("medida") = DGridS.Rows(I).Cells("medida").Value
                    objDataRow.Item("ctdori") = DGridS.Rows(I).Cells("ctd").Value
                    objDataRow.Item("foliosuc") = Txt_IdFolioSuc.Text
                    objDataRow.Item("fecha") = DT_FechaTrasp.Value
                    objDataRow.Item("folio") = Mid(Txt_IdFolioSuc.Text, 1, 2) & "-" & Mid(Txt_IdFolioSuc.Text, 3)
                    GenerarReporte.Tables(0).Rows.Add(objDataRow)
                Next
            End If


            If Opcion = 1 Or Opcion = 3 Then
                Dim origen As String = ""
                Dim destino As String = ""
                Dim origendescrip As String = ""
                Dim destinodescrip As String = ""
                Dim usuario As String = ""
                Dim envia As String = ""
                Dim transporta As String = ""
                Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringSirCoSQL)
                    objDataSet = objReporte.usp_ImprimeTraspasos(1, Txt_Sucursal.Text, Txt_Traspaso.Text)
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
                Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("envia"), "", "", "", "", 0)
                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                        envia = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString
                    End If
                End Using
                Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("transporta"), "", "", "", "", 0)
                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                        transporta = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString
                    End If
                End Using

                If destino = 11 Or destino = 13 Or destino = 12 Or destino = 41 Or destino = 9 Or destino = 32 Or destino = 33 Or destino = 19 Then
                    Plaza = 2
                Else
                    Plaza = 1
                End If


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
            ElseIf Opcion = 2 Or Opcion = 4 Then
                Dim origen As String = ""
                Dim destino As String = ""
                Dim origendescrip As String = ""
                Dim destinodescrip As String = ""
                Dim usuario As String = ""
                Dim recibe As String = ""
                Dim transporta As String = ""
                Dim Enviados As Integer = 0

                Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                    objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Txt_Destino.Text, Txt_Referencia.Text, Txt_Sucursal.Text, 0, 0)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Enviados = objDataSet.Tables(0).Rows.Count
                    End If
                End Using

                Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringSirCoSQL)
                    objDataSet = objReporte.usp_ImprimeTraspasos(2, Txt_Sucursal.Text, Txt_Traspaso.Text)
                    destino = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    origen = objDataSet.Tables(0).Rows(0).Item("sucurori").ToString
                End Using
                Using objReporte As New BCL.BCLImprimeTraspasos(GLB_ConStringDwhSQL)
                    objDataSet2 = objReporte.usp_TraerSucursalTR(destino)
                    destinodescrip = objDataSet2.Tables(0).Rows(0).Item("descrip").ToString
                    objDataSet2 = objReporte.usp_TraerSucursalTR(origen)
                    origendescrip = objDataSet2.Tables(0).Rows(0).Item("descrip").ToString
                End Using
                Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("idusuario"), "", "", "", "", 0)
                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                        usuario = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString
                    End If
                End Using
                Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("transporta"), "", "", "", "", 0)
                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                        transporta = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString
                    End If
                End Using
                Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                    objDataSetEmp = objMySqlGral.usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("recibe"), "", "", "", "", 0)
                    If objDataSetEmp.Tables(0).Rows.Count = 1 Then
                        recibe = objDataSetEmp.Tables(0).Rows(0).Item("nomcompleto").ToString
                    End If
                End Using
              

                GenerarReporte = New DSPReporteTraspasos
                With objDataSet
                    For I As Integer = 0 To .Tables(0).Rows.Count - 1
                        Dim objDataRow As Data.DataRow = GenerarReporte.Tables("Tbl_Traspasos1").NewRow()

                        objDataRow.Item("folio") = .Tables(0).Rows(I).Item("folio").ToString
                        objDataRow.Item("foliosuc") = .Tables(0).Rows(I).Item("folioenvio").ToString
                        objDataRow.Item("origen") = destinodescrip
                        objDataRow.Item("usuario") = usuario
                        objDataRow.Item("observa") = .Tables(0).Rows(I).Item("observa").ToString
                        objDataRow.Item("sucurori") = .Tables(0).Rows(I).Item("sucurori").ToString
                        objDataRow.Item("destino") = origendescrip
                        objDataRow.Item("fecha") = .Tables(0).Rows(I).Item("fecha").ToString
                        objDataRow.Item("serie") = .Tables(0).Rows(I).Item("serie").ToString
                        objDataRow.Item("marca") = .Tables(0).Rows(I).Item("marca").ToString
                        objDataRow.Item("estilon") = .Tables(0).Rows(I).Item("estilon").ToString
                        objDataRow.Item("estilof") = .Tables(0).Rows(I).Item("estilof").ToString
                        objDataRow.Item("medida") = .Tables(0).Rows(I).Item("medida").ToString
                        objDataRow.Item("descripc") = .Tables(0).Rows(I).Item("descripc").ToString
                        objDataRow.Item("ctdori") = .Tables(0).Rows(I).Item("ctddes").ToString
                        'If DGridS.Rows(I).Cells("col_serie").Value = .Tables(0).Rows(I).Item("serie").ToString Then
                        objDataRow.Item("costo") = DGridS.Rows(I).Cells("col_costomargen").Value
                        'End If

                        'If DGridS.Rows(I).Cells("col_serie").Value = .Tables(0).Rows(I).Item("serie").ToString Then
                        objDataRow.Item("precio") = DGridS.Rows(I).Cells("col_precio").Value
                        'End If
                        If blnEsSuc = True Then
                            objDataRow.Item("estienda") = True
                            objDataRow.Item("costo") = 0.0
                        Else
                            objDataRow.Item("estienda") = False
                        End If
                        objDataRow.Item("opcion") = Opcion
                        objDataRow.Item("recibe") = recibe
                        objDataRow.Item("transporta") = transporta
                        If ImprimeTrasp = True Then
                            objDataRow.Item("estatus") = "APLICADO"
                        Else
                            objDataRow.Item("estatus") = Txt_Estatus.Text
                        End If
                        objDataRow.Item("idtraspaso") = CInt(Txt_IdTraspaso.Text)
                        objDataRow.Item("enviados") = Enviados
                        GenerarReporte.Tables("Tbl_Traspasos1").Rows.Add(objDataRow)
                    Next
                End With
            End If
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

    Private Sub Txt_IdTraspaso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdTraspaso.LostFocus
        Dim intContador As Integer = 0
        Dim objDataSetAux As Data.DataSet
        Try
            If Txt_IdTraspaso.Text.Length = 0 Then Exit Sub
            'Txt_Referencia.Text = pub_RellenarIzquierda(Txt_Referencia.Text, 6)

            If Txt_Sucursal.Text.Length = 0 Then
                MessageBox.Show("Debe ingresar la Sucursal que Recibe el Traspaso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_Sucursal.Text = ""
                Txt_Sucursal.Focus()
                Exit Sub
            End If

            If Txt_Destino.Text.Length = 0 Then
                MessageBox.Show("Debe ingresar la Sucursal de Orígen del Traspaso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_Destino.Text = ""
                Txt_Destino.Focus()
                Exit Sub
            End If

            Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSet = objTraspasos.usp_PpalTraspasosManualOri(Txt_Destino.Text, Txt_Referencia.Text, Txt_Referencia.Text, Txt_Sucursal.Text, "1900-01-01", "1900-01-01", "", CInt(Txt_IdTraspaso.Text), CInt(Txt_IdTraspaso.Text), "1900-01-01", "1900-01-01")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                If objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "RECIBIDO" Then
                    MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' ya fue recibido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_IdTraspaso.Text = ""
                    Txt_IdTraspaso.Focus()
                    Exit Sub
                ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "PARCIAL" Then
                    Using objTraspasos1 As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                        objDataSetAux = objTraspasos1.usp_TraerCtdTraspasosOri(Txt_Destino.Text, "", CInt(Txt_IdTraspaso.Text))
                    End Using
                    If objDataSetAux.Tables(0).Rows.Count < 3 Then
                    Else
                        MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' ya fue recibido.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_IdTraspaso.Text = ""
                        Txt_IdTraspaso.Focus()
                        Exit Sub
                    End If
                ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "CANCELADO" Then
                    MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' está cancelado.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_IdTraspaso.Text = ""
                    Txt_IdTraspaso.Focus()
                    Exit Sub
                ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString.Trim = "CAPTURA" Then
                    MessageBox.Show("El Traspaso con el IdTraspaso '" + Txt_IdTraspaso.Text + "' tiene estatus de CAPTURA, no puede recibirlo aún.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_IdTraspaso.Text = ""
                    Txt_IdTraspaso.Focus()
                    Exit Sub
                End If
            End If



            Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Txt_Destino.Text, Txt_Referencia.Text, Txt_Sucursal.Text, CInt(Txt_IdTraspaso.Text))

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If blnEsSuc Then
                        DGridS.Columns("col_costo").Visible = False
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

                    Lbl_LecturaSeries.Text = "Escaneados: 0 de " + cantArt.ToString

                    Txt_Referencia.Text = objDataSet.Tables(0).Rows(0).Item("traspaso")

                    Txt_IdMov1.Text = objDataSet.Tables(0).Rows(0).Item("transporta")
                    If Txt_IdMov1.Text.Length > 0 Then
                        Call Txt_IdMov1_LostFocus(sender, e)
                    End If

                    '' Edicion de componentes
                    Lbl_LecturaSeries.Visible = True
                    Txt_Sucursal.Enabled = False
                    Txt_Destino.Enabled = False
                    Txt_Referencia.Enabled = False
                    Txt_IdTraspaso.Enabled = False

                    'Txt_Serie.Enabled = False

                    Txt_Destino.BackColor = TextboxBackColor
                    Txt_Sucursal.BackColor = TextboxBackColor
                    Txt_Observaciones.BackColor = TextboxBackColor
                    Txt_Serie.BackColor = TextboxBackColor
                Else
                    MessageBox.Show(" El Envío no existe...", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_Referencia.Text = ""
                    Txt_Referencia.Focus()
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Referencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Referencia.LostFocus
       
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

    Private Sub Txt_Sucursal_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged
        Try
            If Txt_Sucursal.Text.Length = 2 Then
                If Txt_IdFolioSuc.Text = "" Then
                    Txt_IdFolioSuc.Enabled = False
                End If
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

    Private Sub Txt_Costo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Costo.TextChanged

    End Sub

    Private Sub DGridS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridS.CellContentClick

    End Sub

    Private Sub Txt_Observaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Observaciones.TextChanged
        If GLB_Idempleado <> 132 Then
            Call BorrarClipboard()
        End If
    End Sub

    Private Sub Txt_CodigoBarras_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CodigoBarras.LostFocus


        Dim intContador As Integer = 0
        Dim objDataSetAux As Data.DataSet
        Try
            'If Txt_CodigoBarras.Text = "" Then Exit Sub
            'If blnEsSuc = True Then
            '    If Opcion = 2 Then
            '        ' aqui merengues mreyes 14/Julio/2020   05:04 p.m.
            '        If Mid(Txt_CodigoBarras.Text, 1, 2) <> GLB_CveSucursal Then
            '            Txt_CodigoBarras.Text = ""

            '            MsgBox("No puede recibir un traspaso, que no pertenece a su sucursal.", MsgBoxStyle.Critical, "Error")
            '            Btn_Aceptar.Enabled = False
            '            Btn_Imprimir.Enabled = False
            '            Txt_CodigoBarras.Focus()
            '            Exit Sub
            '        End If
            '    End If
            'Else



            'End If

            Txt_Destino.Text = Mid(Txt_CodigoBarras.Text, 1, 2)
            Txt_Referencia.Text = Mid(Txt_CodigoBarras.Text, 3, 6)


            If Txt_Referencia.Text.Length = 0 Then Exit Sub
            Txt_Referencia.Text = pub_RellenarIzquierda(Txt_Referencia.Text, 6)


            Call TxtLostfocusPersis(Txt_Destino, Txt_DescripDestino, "S")

            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                objDataSet = objTraspasos.usp_PpalTraspasosManualOri(Txt_Destino.Text, Txt_Referencia.Text, Txt_Referencia.Text, Txt_Sucursal.Text, "1900-01-01", "1900-01-01", "", 0, 0, "1900-01-01", "1900-01-01")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdTraspAut.Text = Val(objDataSet.Tables(0).Rows(0).Item("idprotras"))
                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucurdes").ToString.Trim
                    If blnEsSuc = True Then
                        If Txt_Sucursal.Text <> GLB_CveSucursal Then


                            If GLB_Idempleado <> 132 Or GLB_Usuario <> "FELIX" Then
                                ''' checar que no sea yo.
                                ''' 
                                If Mid(Txt_CodigoBarras.Text, 1, 2) = "11" Or Mid(Txt_CodigoBarras.Text, 1, 2) = "10" Or Mid(Txt_CodigoBarras.Text, 1, 2) = "13" Or Mid(Txt_CodigoBarras.Text, 1, 2) = "12" Or Mid(Txt_CodigoBarras.Text, 1, 2) = "20" Or Mid(Txt_CodigoBarras.Text, 1, 2) = "18" Then

                                Else
                                    ''' checar que no sea yo.
                                    ''' 
                                    Txt_CodigoBarras.Text = ""

                                    MsgBox("No puede recibir un traspaso, que no pertenece a sus permisos por  sucursal.", MsgBoxStyle.Critical, "Error")
                                    Btn_Aceptar.Enabled = False
                                    Btn_Imprimir.Enabled = False
                                    Txt_CodigoBarras.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    Else
                        If GLB_Idempleado <> 132 Or GLB_Usuario <> "FELIX" Then
                            ''' checar que no sea yo.
                            ''' 
                            If Txt_Sucursal.Text = "11" Or Txt_Sucursal.Text = "10" Or Txt_Sucursal.Text = "13" Or Txt_Sucursal.Text = "12" Or Txt_Sucursal.Text = "20" Or Txt_Sucursal.Text = "18" Or Txt_Sucursal.Text = "19" Or Txt_Sucursal.Text = "16" Or Txt_Sucursal.Text = "17" Then

                            Else
                                ''' checar que no sea yo.
                                ''' 
                                If GLB_Idempleado <> 132 And GLB_IdDeptoEmpleado <> 8 And GLB_IdDeptoEmpleado <> 4 Then
                                    Txt_CodigoBarras.Text = ""

                                    MsgBox("No puede recibir un traspaso, que no pertenece a sus permisos por  sucursal.", MsgBoxStyle.Critical, "Error")
                                    Btn_Aceptar.Enabled = False
                                    Btn_Imprimir.Enabled = False
                                    Txt_CodigoBarras.Focus()
                                    Exit Sub
                                End If
                            End If
                            End If

                    End If
                    Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")
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
                        MessageBox.Show("El Traspaso con el Folio '" + Txt_Referencia.Text + "' tiene estatus de CAPTURA, no puede recibirlo aún.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_Referencia.Text = ""
                        Txt_Referencia.Focus()
                        Exit Sub
                    End If
                End If
            End Using


            Using objTraspasos As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                objDataSet = objTraspasos.usp_TraerTraspasoManualEnvioDet(Txt_Destino.Text, Txt_Referencia.Text, Txt_Sucursal.Text, 0, 0)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Observaciones.Text = objDataSet.Tables(0).Rows(0).Item("observa").ToString.Trim
                    If objDataSet.Tables(0).Rows(0).Item("salida") = 0 Then
                        If Txt_Sucursal.Text <> Txt_Destino.Text Then
                            MsgBox("No puede recibir el traspaso, porque no se le ha dado salida.", MsgBoxStyle.Critical, "Error")

                            Btn_Aceptar.Enabled = False
                            Btn_Aplicar.Enabled = False
                            Btn_Imprimir.Enabled = False
                            Txt_Observaciones.Enabled = False
                            Txt_Serie.Enabled = False
                            Exit Sub
                        End If
                    End If
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

                    Lbl_LecturaSeries.Text = "Escaneados: 0 de " + cantArt.ToString

                    Txt_IdTraspaso.Text = objDataSet.Tables(0).Rows(0).Item("idtraspaso")


                    Txt_IdMov1.Text = objDataSet.Tables(0).Rows(0).Item("transporta")
                    If Txt_IdMov1.Text.Length > 0 Then
                        Call Txt_IdMov1_LostFocus(sender, e)
                    End If

                    '05/Septiembre/2019 12:07 p.m.

                    If GLB_Idempleado <> 132 Then
                        If Txt_IdMov2.Text = Txt_IdMov1.Text Then
                            MessageBox.Show("No puede realizar el Recibo del traspaso, la misma persona que le dio Salida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Txt_IdMov2.Text = ""
                            Me.Close()
                            Me.Dispose()
                            Exit Sub
                        End If
                    End If

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
                    Txt_CodigoBarras.Enabled = True
                Else
                    MessageBox.Show(" El Envío no existe para la sucursal " + Txt_DescripDestino.Text + ".", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Btn_Aceptar.Enabled = False
                    Txt_Referencia.Text = ""
                    Txt_Referencia.Focus()
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_CodigoBarras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CodigoBarras.TextChanged
        If Txt_CodigoBarras.Text.Length = 8 Then
            '  BlockInput(False)
            Txt_Observaciones.ForeColor = Color.Black
            Txt_Observaciones.Focus()
        Else
            '  Txt_CodigoBarras.Text = ""
            Txt_CodigoBarras.ForeColor = Color.PowderBlue
        End If
    End Sub

    Private Sub Txt_IdFolioSuc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdFolioSuc.LostFocus
        'mreyes 15/Diciembre/2016   05:10 p.m. 
        Try
            '' traer idfolio 
            If Txt_IdFolioSuc.Text = "" Then Exit Sub
            Dim objDataSet As Data.DataSet

            If Len(Txt_IdFolioSuc.Text) = 10 Then
                idfoliosucresaut = Txt_IdFolioSuc.Text
                Txt_IdFolioSuc.Text = Mid(Txt_IdFolioSuc.Text, 1, 8)
            End If


            Using objEmpleado As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objEmpleado.usp_TraerBulto("", Txt_IdFolioSuc.Text)
                If objDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No se encuentra el folio de bultos dado de alta. Verifique por favor.", MsgBoxStyle.Critical, "Error")
                    Txt_IdFolioSuc.Text = ""
                    Txt_IdFolioSuc.Focus()
                    Exit Sub
                End If
                If objDataSet.Tables(0).Rows(0).Item("status").ToString = "ZC" Then
                    MsgBox("El folio se encuentra CANCELADO no se puede traspasar.", MsgBoxStyle.Critical, "Aviso")
                    Txt_IdFolioSuc.Text = ""
                    Txt_IdFolioSuc.Focus()
                    Exit Sub

                End If

            End Using

            If Val(objDataSet.Tables(0).Rows(0).Item("detalle").ToString) = 0 Then

                MsgBox("El folio de bultos '" & Txt_IdFolioSuc.Text & "', no ha sido recibido a detalle.", MsgBoxStyle.Critical, "VALIDACIÓN")
                Txt_IdFolioSuc.Text = ""
                Txt_IdFolioSuc.Focus()
                Exit Sub

            End If

            'entrajaula
            If idfoliosucresaut = "" Then
                If Val(objDataSet.Tables(0).Rows(0).Item("generotraspaso").ToString) <> 0 Then

                    MsgBox("El traspaso para el  folio de bultos '" & Txt_IdFolioSuc.Text & "', ya ha sido generado.", MsgBoxStyle.Critical, "VALIDACIÓN")
                    Txt_IdFolioSuc.Text = ""
                    Txt_IdFolioSuc.Focus()
                    Exit Sub

                End If
            End If
            FolioB = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idfolio").ToString, 6)

            If idfoliosucresaut = "" Then
                Call usp_TraerReciboTraspaso(FolioB)
                If GLB_CveSucursal = "15" Then
                    Txt_Destino.Enabled = False
                    Txt_Sucursal.Enabled = False
                End If
            Else
                Txt_Sucursal.Text = Mid(Txt_IdFolioSuc.Text, 1, 2)

                Txt_Destino.Text = Mid(idfoliosucresaut, 9, 2)

                Txt_Destino.Enabled = False
                Txt_Sucursal.Enabled = False
                Txt_Observaciones.Text = "RESURTIDO AUTOMÁTICO"

                Txt_DescripDestino.Text = pub_TraerNomSucursal(Txt_Destino.Text)
                Txt_DescripSucursal.Text = pub_TraerNomSucursal(Txt_Sucursal.Text)
                Txt_Destino.Enabled = False
                Txt_Serie.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Txt_IdFolioSuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdFolioSuc.TextChanged
        If Txt_IdFolioSuc.Text.Length = 10 Then
            Txt_IdFolioSuc_LostFocus(sender, e)
            Txt_Serie.Focus()
        End If
    End Sub



    Private Sub Txt_IdTraspAut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdTraspAut.LostFocus
        Try
            If Txt_IdTraspAut.Text = "" Then Exit Sub
            Using objTraspasos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                objDataSet = objTraspasos.usp_PpalProTrasp(1, Txt_IdTraspAut.Text, 0, "1900-01-01", "1900-01-01", "")

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If objDataSet.Tables(0).Rows(0).Item("idsucursal1") <> GLB_CveSucursal Then
                        MsgBox("El Id de Traspaso automático, no pertenece a la tienda.", MsgBoxStyle.Critical, "Error")
                        Btn_Aceptar.Enabled = False
                        Btn_Aplicar.Enabled = False
                        Btn_Imprimir.Enabled = False
                        Exit Sub
                    End If
                    cantArt = objDataSet.Tables(0).Rows(0).Item("pedida")


                    'cantArt = objDataSet.Tables(0).Rows.Count

                    Lbl_LecturaSeries.Text = "Escaneados: 0 de " + cantArt.ToString




                    Txt_Destino.Text = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idsucursal2"), 2)
                    If Txt_Destino.Text.Length > 0 Then
                        Txt_Destino.Enabled = False
                        Call Txt_Destino_LostFocus(sender, e)
                    End If


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
                    Txt_CodigoBarras.Enabled = True
                Else
                    MessageBox.Show(" El Envío no existe para la sucursal " + Txt_DescripDestino.Text + ".", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_IdTraspAut.Text = ""
                    Txt_IdTraspAut.Focus()
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdTraspAut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdTraspAut.TextChanged

    End Sub
    Private Function usp_MatchPropuestaTraspaso() As Boolean
        'mreyes 02/Noviembre/2016   05:32 p.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_MatchPropuestaTraspaso = objCalculo.usp_MatchPropuestaTraspaso




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aplicar.Click
        Try
            Dim objDataSet1 As Data.DataSet



            If Txt_Observaciones.Text = "***** TRASPASO HORMIGA ******" Then
                If (GLB_IdDeptoEmpleado <> 7 And GLB_IdPuestoEmpleado <> 23) Then
                    MsgBox("Solo se pueden APLICAR TRASPASOS HORMIGA, por Supervisión de Tiendas.", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If
            End If

            If Val(Txt_IdTraspAut.Text) <> 0 Then
                Using objTraspasos1 As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    objDataSet1 = objTraspasos1.usp_PpalProTrasp(1, Val(Txt_IdTraspAut.Text), 0, "1900-01-01", "1900-01-01", "")

                    If objDataSet1.Tables(0).Rows.Count > 0 Then

                        If Val(objDataSet1.Tables(0).Rows(0).Item("pedida")) <> Val(Txt_Articulos.Text) Then
                            MsgBox("Se detendrá el proceso, ya que el traspaso en captura no concuerda con la petición de compras.", MsgBoxStyle.Critical, "Error")

                            'Dim myForm As New frmSeriesNoTraspasoAutomatico

                            'myForm.Txt_IdTraspAut.Text = Val(Txt_IdTraspAut.Text)
                            'myForm.Txt_Sucursal.Text = (Txt_Sucursal.Text)
                            'myForm.Txt_DescripSucursal.Text = Txt_DescripSucursal.Text
                            'myForm.Txt_Destino.Text = Txt_Destino.Text
                            'myForm.Txt_DescripDestino.Text = Txt_DescripDestino.Text
                            'myForm.ShowDialog()

                            Exit Sub
                        End If
                    End If
                End Using
            End If

            FolioB = 1
            Call Btn_Aceptar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoTraspasosManuales_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub Txt_IdMov1_TextChanged(sender As Object, e As EventArgs) Handles Txt_IdMov1.TextChanged

    End Sub

    Private Sub Txt_Observaciones_LostFocus(sender As Object, e As EventArgs) Handles Txt_Observaciones.LostFocus

    End Sub

    Private Sub Pnl_Edicion_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class