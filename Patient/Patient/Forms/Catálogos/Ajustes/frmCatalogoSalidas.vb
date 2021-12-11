Public Class frmCatalogoSalidas
    'mreyes10/Mayo/2016 11:19 a.m.
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
    Dim FolioB As Integer = 0


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



            GenerarToolTip()
            

            Call Edicion()
    

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

                   

                Case 2
                   

                Case 4
                  
                    Txt_Sucursal.Enabled = False
                    Txt_Observaciones.Enabled = False
                    Txt_Serie.Enabled = False
                    Txt_Precio.Enabled = False
                  
                    Txt_IdTraspaso.Enabled = False


                    Txt_Sucursal.BackColor = TextboxBackColor
                    Txt_Observaciones.BackColor = TextboxBackColor
                    Txt_Serie.BackColor = TextboxBackColor
                   
                    Txt_Estatus.ForeColor = Color.Black
                    Txt_Costo.ForeColor = Color.Black
                    Txt_Precio.ForeColor = Color.Black
            End Select


            If Opcion = 1 Or Opcion = 3 Then
           
                Txt_IdTraspaso.Visible = False
                Lbl_IdTras.Visible = False
                Lbl_LecturaSeries.Visible = False
              
                Lbl_Traspaso.Text = "Traspaso"

            ElseIf Opcion = 2 Or Opcion = 4 Then
                Lbl_LecturaSeries.Visible = False
              
                Btn_Archivo.Visible = False
                Label16.Text = "Recibe"
                Label4.Text = "Origen"
                Lbl_Traspaso.Text = "Recepción"

   
            End If
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

             Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 10/Mayo/2016    01:35 p.m.

        Dim Guardo As Boolean = False
        Dim Sw_FolioBulto As Boolean = False

        If Txt_NoBulto.TextLength > 0 Then
            Sw_FolioBulto = True
        End If

        If Sw_FolioBulto = True Then
            If MsgBox("Esta seguro de querer realizar la operación de Salida en el Folio de Bulto y Existencia", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
        Else

            If MsgBox("Esta seguro de querer realizar la operación de Salida de Inventario", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
        End If

        If ValidarDatos() = False Then Exit Sub


        'Using objAjuste As New BCL.BCLAjustes(GLB_ConStringCipSis)
        '    Guardo = objAjuste.usp_Captura_CajaCalzado(1, Txt_SucursalOri.Text, Txt_IdFolioSuc.Text, Txt_Proveedor.Text, Txt_SucursalAct.Text, Txt_Serie.Text, Txt_FechaRecibo.Text, Txt_Marca.Text, Txt_Modelo.Text, Txt_Corrida.Text, Txt_Medida.Text, Txt_MarcaNuevo.Text, Txt_ModeloNuevo.Text, Txt_CorridaNuevo.Text, Txt_MedidaNuevo.Text, Cbo_Motivo.Text, GLB_Idempleado)
        'End Using

        'If Guardo = True Then
        '    ' Cambiar en Factprov.
        '    Using objAjuste As New BCL.BCLAjustes(GLB_ConStringCipSis)
        '        Guardo = objAjuste.usp_Captura_CajaCalzado(2, Txt_SucursalOri.Text, Txt_IdFolioSuc.Text, Txt_Proveedor.Text, Txt_SucursalAct.Text, Txt_Serie.Text, Txt_FechaRecibo.Text, Txt_Marca.Text, Txt_Modelo.Text, Txt_Corrida.Text, Txt_Medida.Text, Txt_MarcaNuevo.Text, Txt_ModeloNuevo.Text, Txt_CorridaNuevo.Text, Txt_MedidaNuevo.Text, Cbo_Motivo.Text, GLB_Idempleado)
        '    End Using


        'Else

        '    MsgBox("No se registro el Caja Calzado, intente nuevamente. ")
        'End If



        MsgBox("Serie '" & Txt_Serie.Text & "', cambiada correctamente.", MsgBoxStyle.Information, "Confirmación")
        Sw_Registro = True
        Me.Close()
        Me.Dispose()

        '' Cambiar en factprov.
        '' Cambiar en serie.
        '' Hacer la salida y posterior entrada de la serie, 
        '' Guardar en Caja Calzado.




    End Sub

    Private Function ValidarDatos() As Boolean
        'mreyes 10/Mayo/2016    01:37 p.m.
        ValidarDatos = False
        Try
            If Txt_Sucursal.Text.Length = 0 Then
                MsgBox("Debe especificar la Sucursal de Origen del Traspaso.", MsgBoxStyle.Critical, "Validación")
                Txt_Sucursal.Focus()
                Exit Function
            End If


            If Txt_Observaciones.Text.Length = 0 Then
                MsgBox("Debe agregar las observaciones del traspaso.", MsgBoxStyle.Critical, "Validación")
                Txt_Observaciones.Focus()
                Exit Function
            End If

            If Cbo_Motivo.Text = "" Then
                MsgBox("Debe especificar un motivo.", MsgBoxStyle.Critical, "Error")
                Cbo_Motivo.Text = ""
                Cbo_Motivo.Focus()
            End If


            If DGridS.Rows.Count = 0 Then
                MsgBox("Debe agregar articulos en el Traspaso para poder generarlo.", MsgBoxStyle.Critical, "Validación")
                Txt_Serie.Focus()
                Exit Function
            End If



            ValidarDatos = True
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
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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


                        DGridS.Rows.Add(objDataSet.Tables(0).Rows(0).Item("serie").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("marca").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("estilon").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("corrida").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("medida").ToString,
                                           objDataSet.Tables(0).Rows(0).Item("descripc").ToString,
                                           Val(objDataSet.Tables(0).Rows(0).Item("costo")),
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
        Try
            Dim myForm As New frmReportsBrowser
            Opcion = Opcion
            If Opcion = 1 Or Opcion = 3 Then

                myForm.ReportIndex = 20
                myForm.WindowState = FormWindowState.Maximized
                myForm.Show()
            ElseIf Opcion = 2 Or Opcion = 4 Then

                myForm.WindowState = FormWindowState.Maximized
                myForm.ReportIndex = 21
                myForm.Show()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus
        'mreyes 10/Mayo/2016    12:51 p.m.
        Dim Costo As Decimal = CDec(Txt_Costo.Text)
        Dim Precio As Decimal = CDec(Txt_Precio.Text)
        Try

            If Txt_Serie.Text.Length = 0 Then Exit Sub

            'Si es de recibo, checar que exista la serie en el bulto

            If Txt_NoBulto.Text.Length > 0 Then

                For j As Integer = 0 To DGridS.Rows.Count - 1
                    If Txt_Serie.Text = DGridS.Rows(j).Cells("col_serie").Value Then
                        MessageBox.Show(" El Código YA está registrado en la Salida de Inventario.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()
                        Exit Sub
                    End If
                Next
                Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    Try

                        objDataSet = objMySqlGral.usp_TraerSeries("Z", "", "", 0, Txt_Serie.Text, Txt_Serie.Text, "", "", "", "", "", "", "", "", "", "")


                        'Populate the Project Details section

                        If objDataSet.Tables(0).Rows.Count > 0 Then

                            CargarFotoArticulo(objDataSet.Tables(0).Rows(0).Item("marca").ToString, objDataSet.Tables(0).Rows(0).Item("estilon").ToString)


                            DGridS.Rows.Add(objDataSet.Tables(0).Rows(0).Item("serie").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("marca").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("estilon").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("corrida").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("medida").ToString, _
                                           objDataSet.Tables(0).Rows(0).Item("descripc").ToString, _
                                           Val(objDataSet.Tables(0).Rows(0).Item("costo")), _
                                           Val(objDataSet.Tables(0).Rows(0).Item("precio")))


                            ContArt = ContArt + 1
                            Txt_Articulos.Text = ContArt
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()

                            Costo = Costo + DGridS.Rows(DGridS.RowCount - 1).Cells("col_costo").Value
                            Precio = Precio + DGridS.Rows(DGridS.RowCount - 1).Cells("col_precio").Value

                            Txt_Costo.Text = Format(Costo, "$#,##0.00")
                            Txt_Precio.Text = Format(Precio, "$#,##0.00")


                        Else
                            MsgBox("La serie no existe, verifique e intente nuevamente", MsgBoxStyle.Critical, "Aviso")
                            Txt_Serie.Text = ""
                            Txt_Serie.Focus()

                        End If
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

   

    Private Sub Txt_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Serie.TextChanged
        Try
            If Txt_Serie.Text.Length = 13 Then
                Txt_Serie.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub Txt_IdFolioSuc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NoBulto.LostFocus
        'mreyes 10/Mayo/2016    12:14 p.m.


        Try
            If Txt_NoBulto.Text.Length = 0 Or Accion <> 1 Then Exit Sub


            Txt_Sucursal.ReadOnly = True

            Dim objDataSet As Data.DataSet
            Using objEmpleado As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objEmpleado.usp_TraerBulto("", Txt_NoBulto.Text)
                If objDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No se encuentra el folio de bultos dado de alta. Verifique por favor.", MsgBoxStyle.Critical, "Error")
                    Txt_NoBulto.Text = ""
                    Txt_NoBulto.Focus()
                    Exit Sub
                End If
                If objDataSet.Tables(0).Rows(0).Item("status").ToString = "ZC" Then
                    MsgBox("El folio se encuentra CANCELADO no se puede modificar.", MsgBoxStyle.Critical, "Aviso")
                    Txt_NoBulto.Text = ""
                    Txt_NoBulto.Focus()
                    Exit Sub

                End If



            End Using


            FolioB = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idfolio").ToString, 6)
            If Val(objDataSet.Tables(0).Rows(0).Item("detalle").ToString) = 0 Then

                MsgBox("El folio de bultos '" & Txt_NoBulto.Text & "', no ha sido recibido.", MsgBoxStyle.Critical, "VALIDACIÓN")
                Txt_NoBulto.Text = ""
                Txt_NoBulto.Focus()
                Exit Sub

            End If

            Txt_NoBulto.Enabled = False

            Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString

            Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")


            '' SI ES DEVOLUCIÓN.
            Txt_Sucursal.Text = Mid(Txt_NoBulto.Text, 1, 2)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NoBulto.TextChanged

    End Sub

    Private Sub DGridS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridS.CellContentClick

    End Sub
End Class