Public Class frmAbrirInventario
    'mreyes 18/Junio/2015   11:34 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0
    Private objDataSet As Data.DataSet
    Dim FolioInvB As Integer






    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 18/Agosto/2012 10:37 a.m.
        Try

            If MsgBox("Esta seguro de querer Abrir el Inventario y Generar los archivos de Zonas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            'checar traspasos.

            If usp_TraerTraspasos() = True Then
                Call GenerarArchivos()
                'Abrir el inventario cambiar a IF, en persis.

                Using objTraspasos As New BCL.BCLInventarios(GLB_ConStringPerSis)
                    objTraspasos.usp_ActualizarSucursalInv(1, Txt_Sucursal.Text)
                End Using

            Else
                Exit Sub
            End If

            MsgBox("Inventario Abierto. Archivos generados.", MsgBoxStyle.Information, "Confirmación")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function usp_TraerTraspasos() As Boolean
        'mreyes 18/Agosto/2012 05:09 p.m.
        Try
            usp_TraerTraspasos = False
            Using objTrasp As New BCL.BCLTraspasos(GLB_ConStringCipSis)

                Try
                    Me.Cursor = Cursors.WaitCursor
                    'DGrid.ReadOnly = True


                    objDataSet = objTrasp.usp_TraerTrasPendRecibo(3, Txt_Sucursal.Text, Txt_Sucursal.Text, "1900-01-01", "1900-01-01")

                    'Populate the Project Details section
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        'Populate the Project Details section 

                        MsgBox("No se puede abrir el inventario, hay Traspasos Pendientes.", MsgBoxStyle.Critical, "Aviso")
                        Me.Close()
                        Me.Dispose()
                        Dim myForm As New frmPpalTrasPendRecibo

                        myForm.MdiParent = BitacoraMain
                        myForm.WindowState = FormWindowState.Maximized
                        myForm.Opcion = 1
                        myForm.OpcionSP = 3
                        myForm.Show()
                        myForm.Refresh()
                        Exit Function









                    End If
                    Me.Cursor = Cursors.Default
                    ' LimpiarBusqueda()
                    usp_TraerTraspasos = True
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Function
    Private Sub GenerarArchivos()
        Try
            Dim Directorio As String = GLB_DireInv & Txt_DescripSucursal.Text & FolioInvB & "\"
            Dim Archivo As String = ""  ' Directorio & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"
            Dim Linea As String = ""

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                If objIO.pub_CrearDirectorio(Directorio) = False Then
                    'MsgBox("No se pudo generar la carpeta '" & RutaDestino & "'", MsgBoxStyle.Critical, "Error")

                End If
            End Using


            For I As Integer = 1 To Val(Txt_NoZonas.Text)
                Archivo = "ZONA" & I
                Dim sw As New System.IO.StreamWriter(Directorio & Archivo & ".txt")

                sw.WriteLine(Linea)


                sw.Close()
            Next
            ' los archivos que son especiales

            Dim sw1 As New System.IO.StreamWriter(Directorio & "AMARILLOS" & ".txt")
            Dim sw2 As New System.IO.StreamWriter(Directorio & "DEVOLUCIONES" & ".txt")
            Dim sw3 As New System.IO.StreamWriter(Directorio & "CAMBIADOS" & ".txt")
            Dim sw4 As New System.IO.StreamWriter(Directorio & "PIESOLO" & ".txt")
            Dim sw5 As New System.IO.StreamWriter(Directorio & "CAJASOLA" & ".txt")
            Dim sw6 As New System.IO.StreamWriter(Directorio & "FALLADOS" & ".txt")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub
    Private Sub usp_GeberarSerie()
        Dim Vendedor As String = ""
        Dim Z As Integer = 0
        Dim Serie = ""

        Dim ObjDataSet1 As Data.DataSet
        Try
            Application.DoEvents()
            PBar.Minimum = 0
            PBar.Maximum = Val(Txt_NoZonas.Text)
            PBar.Value = 0
            For I As Integer = 1 To Val(Txt_NoZonas.Text)
                Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                    ObjDataSet1 = objPedidos.Inserta_Serie  'INSERTA NUEVO DATASET
                    Dim objDataRow1 As Data.DataRow = ObjDataSet1.Tables(0).NewRow

                    Serie = fn_TraerFolioOrdeComp(5, Txt_Sucursal.Text, 1)
                    Serie = pub_RellenarIzquierda(Serie, 13)

                    If Actualiza_FolioOrdeComp(6, Txt_Sucursal.Text, 1) = False Then
                        MsgBox("Error")
                        Exit Sub
                    End If

                    objDataRow1.Item("serie") = Serie
                    objDataRow1.Item("sucursal") = Trim(Txt_Sucursal.Text)
                    objDataRow1.Item("status") = "AC"
                    objDataRow1.Item("marca") = "COP"
                    objDataRow1.Item("estilon") = "      4"

                    objDataRow1.Item("medida") = "01"

                    objDataRow1.Item("sucurdes") = Trim(Txt_Sucursal.Text)
                    'Add the DataRow to the DataSet
                    ObjDataSet1.Tables(0).Rows.Add(objDataRow1)

                    If Not objPedidos.usp_Captura_Serie(1, ObjDataSet1) Then
                        Throw New Exception("Falló Inserción de Detalle ")
                    End If
                End Using
                PBar.Value = PBar.Value + 1
                Txt_Porc.Text = I & " de " & Val(Txt_NoZonas.Text)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub frmCatalogoSegBit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Sw_Registro = False
                        Me.Dispose()
                        Me.Close()

                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmCatalogoSegBit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

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



    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Accion = 1
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Pnl_Edicion.Enabled = False
                    Pnl_Edicion.Enabled = False

                    Call CambiaBackcolor()

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True

            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CambiaBackcolor()
        Try
            'mreyes 02/Marzo/2012 10:25 a.m.


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Accion = 2
        Call Edicion()
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                'If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                'Me.Dispose()
                Me.Close()
                Sw_Registro = False
                'End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Call TraerSucursal()
        ' ir a buscar última referencia de inventario.


        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try


                objDataSet = objMySqlGral.usp_TraerSucursalInv(Txt_Sucursal.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Lbl_Leyenda.Text = "Último Inventario :" & Format(CDate(objDataSet.Tables(0).Rows(0).Item("invini").ToString), "yyyy-MM-dd") & " con folio: " & objDataSet.Tables(0).Rows(0).Item("numif").ToString
                    FolioInvB = objDataSet.Tables(0).Rows(0).Item("numif")
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
        If Txt_Sucursal.TextLength > 0 Then Txt_Sucursal.Enabled = False


    End Sub
    Private Sub TraerSucursal()

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

    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:30
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text.Trim, "")

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

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub
End Class