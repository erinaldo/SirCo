Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalBonoSemanal

    Private objDataSet As Data.DataSet
    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Dim PeriodoUnico As Integer = 0
    Dim FechaIniB As Date
    Dim FechaFinB As Date
    Dim Idperiodo As Integer = 0




    Dim idEmpleadoB As Integer = 0
    Dim SucursalB As String = ""
    Dim IdDeptoB As Integer = 0
    Dim IdPuestoB As Integer = 0


    Dim idPercDeducB As Integer = 0
    Dim IdPeriodoB As String = ""
    Dim TipoNomB As String = ""



    Dim Opcion As Integer = 1

    Private Sub FechaUltimoPeriodo(ByVal Estatus As String)
        'mreyes 23/Agosto/2012 06:43 p.m.
        Try
            Dim objDataSet1 As Data.DataSet
            Using objCantArti As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                objDataSet1 = objCantArti.usp_TraerUltimoPeriodo(2, Estatus, PeriodoUnico)

                If objDataSet1.Tables(0).Rows.Count > 0 Then

                    FechaIniB = Format(objDataSet1.Tables(0).Rows(0).Item("fechaini"), "yyyy-MM-dd")
                    FechaFinB = Format(objDataSet1.Tables(0).Rows(0).Item("fechafin"), "yyyy-MM-dd")
                    Idperiodo = objDataSet1.Tables(0).Rows(0).Item("idperiodo")
                End If


            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenaGrid()
        'mreyes 26/Octubre/2017     04:55 p.m.
        Dim objDataSet As Data.DataSet
        DGrid1.Visible = False
        '  Idperiodo = 290
        Dim IdSucursal As Integer = 0


        If GLB_CveSucursal <> "" Then
            IdSucursal = GLB_CveSucursal
        Else
            IdSucursal = 0
        End If
        If GLB_IdDeptoEmpleado = 7 Then
            IdSucursal = 0
        End If

        If GLB_IdDeptoEmpleado = 9 Then
            IdSucursal = 0
        End If


        If GLB_IdDeptoEmpleado = 2 Then
            IdSucursal = 0
        End If

        Call usp_TraerFumComisionEmp()


        '  InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringNominaSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalBonoSemanal(Idperiodo, IdSucursal)


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
            ' Call Colorear()
            GridView1.FixedLineWidth = 4
            GridView1.Columns(0).Fixed = 1
            GridView1.Columns(1).Fixed = 1
            GridView1.Columns(2).Fixed = 1
            GridView1.Columns(3).Fixed = 1

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Private Sub frmPpalBonoSemanal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If GLB_Idempleado <> 132 And GLB_Idempleado <> 92 Then
            Btn_Excel.Visible = False
        End If
        Call FechaUltimoPeriodo("P")
        Call RellenaGrid()
    End Sub

    Private Sub frmPpalBonoSemanal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            DGrid1.ExportToXls(sfdRuta.FileName)
        End If
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Try

            If MsgBox("Esta seguro actualizar la Información de Comisiones ?  .. Este proceso puede tornarse lento.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            PictureBox1.Visible = True
            Call usp_TraerVentasNetas()
            Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringNominaSQL)
                If objTrasp.usp_GeneraEstructuraComision(Idperiodo) = False Then

                End If
            End Using
            Me.Cursor = Cursors.Default
            PictureBox1.Visible = False
            MsgBox("Información Actualizada", MsgBoxStyle.Information, "Aviso")
            Call RellenaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(sender As Object, e As EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmPpalBonoSemanal_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Filtro_Click(sender As Object, e As EventArgs) Handles Btn_Filtro.Click


        Dim myForm As New frmFiltrosNomina
        Dim Estatus As String = ""

        Dim TipoNomina = ""

        TipoNomina = ""
        If TipoNomB = "F" Then TipoNomina = "FISCAL"
        If TipoNomB = "A" Then TipoNomina = "AMBAS"
        If TipoNomB = "B" Then TipoNomina = "BONO"



        myForm.Txt_IdEmpleado.Text = idEmpleadoB
        ' myForm.Cbo_Periodo.ValueMember = IdPeriodoB
        myForm.Cbo_TipoNom.Text = TipoNomina

        myForm.Txt_Sucursal.Text = SucursalB
        myForm.Txt_IdDepto.Text = IdDeptoB
        myForm.Txt_IdPuesto.Text = IdPuestoB

        ' myForm.Cbo_Estatus.Text = Estatus
        myForm.ShowDialog()
        idEmpleadoB = Val(myForm.Txt_IdEmpleado.Text)
        'IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES (" & pub_TraerUltimoPeriodo(2) & ");"
        ' periodounico = myForm.Periodo
        ' IdPeriodoB = "INSERT INTO periodotemp (idperiodo1) VALUES " & myForm.Periodo & ";"
        'FechaIniB = myForm.FechaIniB
        '        PeriodoUnico = Val(Mid(myForm.Periodo, 2, 2))
        If Len(myForm.Periodo) >= 5 Then
            PeriodoUnico = Val(Mid(myForm.Periodo, 2, 3))
        Else
            PeriodoUnico = Val(Mid(myForm.Periodo, 2, 2))
        End If
        Call FechaUltimoPeriodo("")
        TipoNomB = Mid(myForm.Cbo_TipoNom.Text, 1, 1)

        SucursalB = myForm.Txt_Sucursal.Text
        IdDeptoB = Val(myForm.Txt_IdDepto.Text)
        IdPuestoB = Val(myForm.Txt_IdPuesto.Text)



        If myForm.Sw_Filtro = True Then
            Call RellenaGrid()
        End If

    End Sub



    Private Sub usp_TraerVentasNetas()
        Dim Vendedor As String = ""
        Dim Z As Integer = 0
        'mreyes 18/Agosto/2012 10:38 a.m.
        Try
            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                Try

                    objDataSet = objMySqlGral.usp_TraerVendedor(0)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Vendedor = objDataSet.Tables(0).Rows(0).Item("vendedor").ToString
                    Else
                        Vendedor = ""
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            ' Borrar Ventas 
            Using objElimina As New BCL.BCLNomina(GLB_ConStringNomSis)
                Try
                    'Get the specific project selected in the ListView control
                    If objElimina.usp_EliminaVenta("", 0, FechaIniB, FechaFinB) = False Then

                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetas("", Vendedor, FechaIniB, FechaFinB)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using


            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetas("", "1", FechaIniB, FechaFinB)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using




            'Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
            '    Dim objDatasetE As Data.DataSet


            '    objDatasetE = objMicrosipE.usp_TraerVentasNetasCajero("", Vendedor, FechaIniB, FechaFinB)
            '    If objDatasetE.Tables(0).Rows.Count > 0 Then
            '        Application.DoEvents()
            '        PBar.Minimum = 0
            '        PBar.Maximum = objDatasetE.Tables(0).Rows.Count
            '        PBar.Value = 0
            '        Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
            '        For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
            '            ' Insertar en Empleados
            '            PBar.Value = PBar.Value + 1
            '            Txt_Porc.Text = Z & " de " & Cont
            '            Application.DoEvents()
            '            Call Inserta_VentaNominaCajero(objDatasetE, Z)

            '        Next
            '    End If
            'End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub usp_TraerFumComisionEmp()
        'mreyes 02/Octubre/2018 09:52 a.m.
        Try
            Dim objDataSet1 As Data.DataSet

            Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringNominaSQL)
                objDataSet1 = objTrasp.usp_TraerFumComisionEmp()

                If objDataSet1.Tables(0).Rows.Count > 0 Then

                    Lbl_Leyenda.Text = "Fecha última actualización : " & objDataSet1.Tables(0).Rows(0).Item("fum") & ""

                End If


            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


End Class