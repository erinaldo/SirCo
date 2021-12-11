Public Class frmModificarCargo
    'mreyes 22/Noviembre/2018   10:43 a.m.
    Dim SucCte As String = ""
    Dim Cliente As String = ""
    Private Sub Txt_Nota_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Nota.EditValueChanged

    End Sub

    Private Sub usp_TraerCargo()
        'mreyes 22/Noviembre/2018   10:43 a.m.
        Dim objDataSet As Data.DataSet
        Dim Sucursal As String = ""
        Dim Nota As String = ""

        '  DGrid1.Visible = False

        Sucursal = Mid(Txt_Nota.Text, 1, 2)
        Nota = Mid(Txt_Nota.Text, 3, 6)
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor


                objDataSet = objTrasp.usp_TraerCargo(Sucursal, Nota)


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    ' DGrid1.DataSource = objDataSet.Tables(0)


                    Txt_Distribuidor.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString & "-" & objDataSet.Tables(0).Rows(0).Item("nombredistrib").ToString
                    Txt_Cliente.Text = objDataSet.Tables(0).Rows(0).Item("nombrecliente").ToString
                    SucCte = objDataSet.Tables(0).Rows(0).Item("succte").ToString
                    Cliente = objDataSet.Tables(0).Rows(0).Item("cliente").ToString
                    Txt_Importe.Text = Format(objDataSet.Tables(0).Rows(0).Item("importe"), "$#,##0.00")
                    Txt_FechaCompra.Text = objDataSet.Tables(0).Rows(0).Item("fechacompra").ToString
                    Dt_Apagar.Text = objDataSet.Tables(0).Rows(0).Item("aplicar").ToString

                    Lbl_Status.Text = objDataSet.Tables(0).Rows(0).Item("status").ToString
                    Txt_Vale.Text = objDataSet.Tables(0).Rows(0).Item("vale").ToString


                    DGridPagos.DataSource = objDataSet.Tables(1)
                    DGridVenta.DataSource = objDataSet.Tables(2)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                '    DGrid1.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        'GridView1
        Try
            GridView1.BestFitColumns()
            GridView2.BestFitColumns()
            ' marca, estilon, descripc, precio, precdesc'
            GridView2.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView2.Columns(1).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center



            GridView2.Columns(0).Caption = "Marca"
            GridView2.Columns(1).Caption = "Modelo"
            GridView2.Columns(2).Caption = "Descripción"
            GridView2.Columns(3).Caption = "Precio Normal"
            GridView2.Columns(4).Caption = "Precio Oferta"


            GridView2.OptionsView.ColumnAutoWidth = False
            GridView2.OptionsView.BestFitMaxRowCount = -1
            GridView2.BestFitColumns()
            'For I As Integer = 0 To GridView1.Columns.Count - 1
            '    GridView1.Columns(I).OptionsColumn.ReadOnly = True
            '    ' GridView1.Columns(I).OptionsColumn.AllowMerge = True
            'Next

            GridView1.Columns(1).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns(2).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            GridView1.Columns(3).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            GridView1.Columns(0).Caption = "Pago"
            GridView1.Columns(1).Caption = "Fecha Aplicar"
            GridView1.Columns(2).Caption = "Importe"
            GridView1.Columns(3).Caption = "Abono"



            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.OptionsView.BestFitMaxRowCount = -1
            GridView1.BestFitColumns()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Private Sub Txt_Nota_LostFocus(sender As Object, e As EventArgs) Handles Txt_Nota.LostFocus
        Try
            If Len(Txt_Nota.Text) < 8 Then Exit Sub

            Call usp_TraerCargo()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click
        'mreyes 22/Noviembre/2018   12:47 p.m.

        Try
            Dim Fecha As Date = "1900-01-01"

            If DEFechaIni.Text <> "" Then
                Fecha = DEFechaIni.Text

            End If
            If MsgBox("Esta seguro actualizar la Información del Cargo ?  ... ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor

            Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                If objTrasp.usp_ModificarCargo(Mid(Txt_Nota.Text, 1, 2), Mid(Txt_Nota.Text, 3, 6), Txt_ValeNew.Text, Txt_DistribNuevo.Text, Txt_NombreClie.Text, Txt_ApPaternoClie.Text, Txt_ApMaternoClie.Text, Fecha, SucCte, Cliente, GLB_Idempleado) Then
                    '   MsgBox("Error, no se pudo actualizar", MsgBoxStyle.Critical, "Error")
                End If
            End Using
            Me.Cursor = Cursors.Default

            MsgBox("Información Actualizada", MsgBoxStyle.Information, "Aviso")

            Call Limpiar()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub Limpiar()
        Txt_Nota.Text = ""
        SucCte = ""
    End Sub

    Private Sub Pnl__Paint(sender As Object, e As PaintEventArgs) Handles Pnl_.Paint

    End Sub

    Private Sub Btn_Aceptar_KeyDown(sender As Object, e As KeyEventArgs) Handles Btn_Aceptar.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmModificarCargo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocusDistrib(ByVal Txt_Campo As String)
        '   Dim myForm As New frmRelacionConsultas
        Dim objDataSet As Data.DataSet
        Dim objDataDistrib As Data.DataSet
        Dim idDistrib As Integer
        If Txt_Campo.Length = 0 Then Exit Sub
        Using objCatalogo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                objDataDistrib = objCatalogo.usp_TraerIdDistrib(Txt_Campo)
                If objDataDistrib.Tables(0).Rows.Count > 0 Then
                    idDistrib = objDataDistrib.Tables(0).Rows(0).Item("iddistrib").ToString
                    ''--------------------------------------------------------------------

                    ' Txt_idDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                    Txt_DistribNombre.Text = objDataDistrib.Tables(0).Rows(0).Item("nombrecompleto").ToString

                Else
                    Txt_DistribNombre.Text = ""
                End If
                'objDataSet = objCatalogo.usp_TraerDistrib(Txt_Campo)

                'If objDataSet.Tables(0).Rows.Count > 0 Then
                '    Txt_idDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                '    Txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                ' Else
                '    Txt_Campo = ""
                '    myForm.Tipo = "D"
                '    myForm.ShowDialog()
                '    If Txt_Campo.Length = 0 Then
                '        Txt_idDistrib.Focus()
                '    End If
                ' End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub Txt_DistribNuevo_LostFocus(sender As Object, e As EventArgs) Handles Txt_DistribNuevo.LostFocus
        Try
            ''rellena ceros
            If (Txt_DistribNuevo.Text <> "") Then
                If Txt_DistribNuevo.Text.Trim.Length < 6 Then
                    Txt_DistribNuevo.Text = pub_RellenarIzquierda(Txt_DistribNuevo.Text.Trim, 6)
                End If
                'consulta si existe
                Using objMySqlGral As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                    If Txt_DistribNuevo.Text.Length = 0 Then Exit Sub
                    Try
                        Call TxtLostfocusDistrib(Txt_DistribNuevo.Text)
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_DistribNuevo_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_DistribNuevo.EditValueChanged

    End Sub
End Class