Public Class frmSeriesNoRecibidasTR

    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Public IdTRaspaso As Integer = 0
    Public Sucursal As String = ""
    Public Traspaso As String = ""
    Public Sucurdes As String = ""
    Public Opcion As Integer = 0
    Public Tipo As String = ""
    Public Costo As Decimal = 0.0
    Public Precio As Decimal = 0.0

    Private objDataSet As Data.DataSet
    Dim myFormt As New frmCatalogoTraspasosManuales

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()

        Call usp_TraerSeriesEnvioNoReci(Sucursal, Traspaso, Sucurdes, IdTRaspaso)
    End Sub

    Private Sub usp_TraerSeriesEnvioNoReci(ByVal Sucursal As String, ByVal Traspaso As String, ByVal Sucurdes As String, _
                                                    ByVal IdTraspaso As Integer)
        Try
            Using objTRasp As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSet = objTRasp.usp_TraerSeriesEnvioNoReci(Sucursal, Traspaso, Sucurdes, IdTraspaso)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item("idtraspaso").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("sucursal").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("traspaso").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("idarticulo").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("marca").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("estilon").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("corrida").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("medida").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("serie").ToString, _
                                       objDataSet.Tables(0).Rows(I).Item("sucurdes").ToString)
                    Next

                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function usp_TraerMotivosTR(ByVal Motivo As String) As Integer
        Try
            Using objTRasp As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSet = objTRasp.usp_TraerMotivosTR()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If objDataSet.Tables(0).Rows(i).Item("descrip") = Motivo Then
                            usp_TraerMotivosTR = objDataSet.Tables(0).Rows(i).Item("idmotivo")
                        End If
                    Next
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            If ValidarEdicion() = True Then

                If MessageBox.Show("Desea grabar los motivos por los que no recibe los artículos?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then Exit Sub


                If Inserta_MotivosTR() = True Then


                    'If Opcion = 1 Or Opcion = 3 Then 'Envio de Traspaso
                    Dim ultimoFolio As String = ""
                    Dim blnTraspOri As Boolean = False
                    Dim Serie As String = ""
                    Dim Marca As String = ""
                    Dim Estilon As String = ""
                    Dim Medida As String = ""
                    Dim Proveedor As String = ""
                    Dim Corrida As String = ""
                    Dim Costo As String = ""
                    Dim Precio As Double = 0.0
                    Dim Idarticulo As Integer = 0
                    Dim Idtraspaso As Integer = 0
                    Dim blnActualizo As Boolean = False
                    Dim contador As Integer = 0


                    Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringPerSis)
                        objDataSet = objTraspasos.usp_TraerFolioUltimoTraspaso(Sucurdes)
                    End Using
                    ultimoFolio = CStr(CInt(objDataSet.Tables(0).Rows(0).Item("Traspaso")) + 1)
                    ultimoFolio = pub_RellenarIzquierda(ultimoFolio, 6)


                    For i As Integer = 0 To DGrid.Rows.Count - 1
                        Serie = DGrid.Rows(i).Cells("col_serie").Value

                        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                            objDataSet = objTraspasos.usp_TraerCostoSerie(Serie)
                        End Using
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Marca = objDataSet.Tables(0).Rows(0).Item("marca").ToString.Trim
                            Estilon = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                            Medida = objDataSet.Tables(0).Rows(0).Item("medida").ToString
                            Corrida = objDataSet.Tables(0).Rows(0).Item("corrida").ToString
                            Costo = objDataSet.Tables(0).Rows(0).Item("ultcosto").ToString
                            Precio = objDataSet.Tables(0).Rows(0).Item("preciovta")
                            Proveedor = objDataSet.Tables(0).Rows(0).Item("proveedors").ToString

                            Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                                objDataSet = objTraspasos.usp_TraerIdArticulo(Marca, Estilon)
                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Idarticulo = objDataSet.Tables(0).Rows(0).Item("idarticulo").ToString
                                End If
                            End Using

                            '' preparar para
                            Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                                blnActualizo = objTraspasos.usp_ActualizarSerieRegresoTR(Serie, Sucursal, Sucurdes)
                            End Using

                            contador += 1
                            Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                                objTraspasos.usp_CapturaDetTraspasoOri(1, Idtraspaso, Sucurdes, ultimoFolio, Idarticulo, Marca, Estilon, Proveedor, Corrida, Medida, Serie, 1, CDbl(Costo), Precio)
                            End Using
                        End If
                    Next
                    If contador > 0 Then

                        ''completar
                        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                            blnTraspOri = objTraspasos.usp_CapturaTraspasoOri(1, Sucurdes, ultimoFolio, Tipo, 0, "AP", GLB_FechaHoy.ToString("yyyy-MM-dd"), Now.TimeOfDay.ToString, _
                                                                              Sucursal, "REGRESADO AUTOMATICAMENTE A SUC ORIGEN", GLB_Usuario, DGrid.Rows.Count, Costo, Precio, _
                                                                              GLB_Idempleado, GLB_Idempleado, GLB_Idempleado)
                        End Using

                        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                            objDataSet = objTraspasos.usp_TraerIdTraspaso(1, Sucurdes, ultimoFolio)
                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                Idtraspaso = objDataSet.Tables(0).Rows(0).Item("idtraspaso").ToString
                            End If
                        End Using

                        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                            objTraspasos.usp_ActualizaIdTraspasoDet(1, Sucurdes, ultimoFolio, Idtraspaso)
                        End Using


                        Using objTraspasos As New BCL.BCLTraspasos(GLB_ConStringPerSis)
                            objTraspasos.usp_ActualizarFolioTraspaso(ultimoFolio, Sucurdes)
                        End Using


                        MessageBox.Show("Se generó el traspaso con " + contador.ToString + " artículos capturados correctamente con el Folio: '" + ultimoFolio + "' para la sucursal " + Sucursal.ToString, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If GLB_CveSucursal.Trim = "" Then

                        End If

                        Btn_Aceptar.Enabled = False

                        myFormt.Txt_Sucursal.Text = Sucurdes
                        myFormt.Txt_Traspaso.Text = ultimoFolio
                        myFormt.Txt_Destino.Text = Sucursal
                        myFormt.Txt_Estatus.Text = "APLICADO"
                        myFormt.Txt_IdTraspaso.Text = Idtraspaso


                        myFormt.ImprimeTrasp = True
                        myFormt.Opcion = 1


                        myFormt.ShowDialog()
                        'Call im
                        'Sw_Registro = True
                        Me.Close()
                    Else
                        'MessageBox.Show("No se pudo realizar el traspaso, ya que los artículos no deben estar en la sucursal " + Txt_DescripSucursal.Text, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If



                    'End If

                    Me.Close()
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_MotivosTR() As Boolean

        Dim objDataSetT As Data.DataSet
        Dim blnTraeSerie As Boolean = False
        'Get a new Project DataSet
        Try

            Using objTraspaso As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                objDataSetT = objTraspaso.usp_TraerSeriesEnvioNoReci(Sucursal, Traspaso, Sucurdes, IdTRaspaso)
            End Using

            Dim IdTraspasoB As Integer = 0
            Dim SucursalB As String = ""
            Dim TRaspasoB As String = ""
            Dim IdArticuloB As Integer = 0
            Dim MarcaB As String = ""
            Dim EstiloB As String = ""
            Dim CorridaB As String = ""
            Dim MedidaB As String = ""
            Dim SerieB As String = ""
            Dim SucurdesB As String = ""


            'If objDataSetT.Tables(0).Rows.Count > 0 Then
            If DGrid.Rows.Count > 0 Then
                For i As Integer = 0 To DGrid.Rows.Count - 1
                    Using objTraspaso As New BCL.BCLTraspasos(GLB_ConStringCipSis)
                        IdTraspasoB = DGrid.Rows(i).Cells("col_idtraspaso").Value
                        SucursalB = DGrid.Rows(i).Cells("col_sucursal").Value
                        TRaspasoB = DGrid.Rows(i).Cells("col_traspaso").Value
                        IdArticuloB = DGrid.Rows(i).Cells("col_idarticulo").Value
                        MarcaB = DGrid.Rows(i).Cells("col_marca").Value
                        EstiloB = DGrid.Rows(i).Cells("col_modelo").Value
                        CorridaB = DGrid.Rows(i).Cells("col_corrida").Value
                        MedidaB = DGrid.Rows(i).Cells("col_medida").Value
                        SerieB = DGrid.Rows(i).Cells("col_serie").Value
                        SucurdesB = DGrid.Rows(i).Cells("col_sucurdes").Value

                        If Not objTraspaso.usp_CapturaSeriesEnvioNoReci(IdTraspasoB, SucursalB, TRaspasoB, IdArticuloB, MarcaB, EstiloB, _
                                                                        CorridaB, MedidaB, SerieB, SucurdesB, usp_TraerMotivosTR(DGrid.Rows(i).Cells("col_motivo").Value.ToString), _
                                                                       DGrid.Rows(i).Cells("col_observa").Value, GLB_Idempleado) Then
                            '    Throw New Exception("Falló Inserción de Artículo")
                        Else
                            Inserta_MotivosTR = True
                        End If

                    End Using
                Next
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Private Function ValidarEdicion() As Boolean
        ValidarEdicion = False
        Try

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("col_motivo").Value = "" Then
                    MsgBox("Debe seleccionar un motivo para cada serie.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Function
                End If
            Next


            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("col_observa").Value = "" Then
                    MsgBox("Debe ingresar la descripción del motivo para cada modelo.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Function
                End If
            Next

            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("col_observa").Value Is Nothing Then
                    MsgBox("Debe ingresar la descripción del motivo para cada modelo.", MsgBoxStyle.OkOnly, "Aviso")
                    Exit Function
                End If
            Next

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub frmMotivos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Descripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        If columna = 10 Then Exit Sub

        Try
            Dim validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            e.KeyChar = UCase(e.KeyChar)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class