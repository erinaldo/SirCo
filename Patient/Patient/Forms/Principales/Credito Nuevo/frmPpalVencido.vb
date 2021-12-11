Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmPpalVencido
    'mreyes     28/Noviembre/2017   11:27 a.m.
    ' tabla vencido


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

    Dim blnEntraDet As Boolean = False

    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False


    Private Sub frmPpalVencidosDias_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalVencidoxAnio._usp_PpalVencidoxAnio' Puede moverla o quitarla según sea necesario.
        ' Me.Usp_PpalVencidoxAnioTableAdapter.Fill(Me.Usp_PpalVencidoxAnio._usp_PpalVencidoxAnio)
        ''TODO: esta línea de código carga datos en la tabla 'Usp_PpalVencido._usp_PpalVencido' Puede moverla o quitarla según sea necesario.
        'Me.Usp_PpalVencidoTableAdapter.Fill(Me.Usp_PpalVencido._usp_PpalVencido)
        'TODO: esta línea de código carga datos en la tabla 'Usp_PpalGestoria._usp_PpalGestoria' Puede moverla o quitarla según sea necesario.
        '  Me.Usp_PpalGestoriaTableAdapter.Fill(Me.Usp_PpalGestoria._usp_PpalGestoria)
        Sw_Load = True
        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True

        Call LimpiarBusqueda()

        Call RellenaGrid()
        Call RellenaGrid1()


    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
    Private Sub GenerarToolTip()
        Try


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()

        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurOriB = GLB_CveSucursal
            ElseIf Opcion = 2 Then
                SucurOriB = GLB_CveSucursal
            End If
        Else
            SucurOriB = 0
            SucurDesB = 0
        End If

        FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"


    End Sub

    Private Sub RellenaGrid1()
        'mreyes 28/Noviembre/2017   12:12 p.m.

        DGrid1.Visible = False
        InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalVencidoxAnio()


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    '
                    DGrid2.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                Else

                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("La información se esta actualizando, favor de esperar o intentarlo más tarde.", MsgBoxStyle.Critical, "Aviso")
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


    Private Sub RellenaGrid()
        'mreyes 28/Noviembre/2017   12:12 p.m.

        DGrid1.Visible = False
        InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Load = False
                'DGrid.ReadOnly = True
                ' GridControl.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalVencido()


                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then

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
                    MsgBox("La información se esta actualizando, favor de esperar o intentarlo más tarde.", MsgBoxStyle.Critical, "Aviso")
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
            GridView2.BestFitColumns()
            If Chk_Direccion.Checked = True Then
                GridView1.Columns("direccion").Visible = True
                GridView1.Columns("Telefono1").Visible = True
                GridView1.Columns("Ciudad").Visible = True
                GridView1.Columns("colonia").Visible = True
                GridView1.Columns("aval").Visible = True

                GridView1.Columns("direccion").VisibleIndex = 11
                GridView1.Columns("Ciudad").VisibleIndex = 12
                GridView1.Columns("colonia").VisibleIndex = 13
                GridView1.Columns("Telefono1").VisibleIndex = 14
                GridView1.Columns("aval").VisibleIndex = 15

            Else


                GridView1.Columns("direccion").Visible = False
                GridView1.Columns("Telefono1").Visible = False
                GridView1.Columns("Ciudad").Visible = False
                GridView1.Columns("colonia").Visible = False
                GridView1.Columns("aval").Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub


    Private Sub Chk_Direccion_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Direccion.CheckedChanged

        GridView1.BestFitColumns()
        GridView2.BestFitColumns()
        If Chk_Direccion.Checked = True Then
            GridView1.Columns("direccion").Visible = True
            GridView1.Columns("Telefono1").Visible = True
            GridView1.Columns("Ciudad").Visible = True
            GridView1.Columns("colonia").Visible = True
            GridView1.Columns("aval").Visible = True

            GridView1.Columns("direccion").VisibleIndex = 11
            GridView1.Columns("Ciudad").VisibleIndex = 12
            GridView1.Columns("colonia").VisibleIndex = 13
            GridView1.Columns("Telefono1").VisibleIndex = 14
            GridView1.Columns("aval").VisibleIndex = 15

        Else


            GridView1.Columns("direccion").Visible = False
            GridView1.Columns("Telefono1").Visible = False
            GridView1.Columns("Ciudad").Visible = False
            GridView1.Columns("colonia").Visible = False
            GridView1.Columns("aval").Visible = False
        End If
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

    Private Sub frmPpalVencidosDias_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub





    Private Sub Btn_Asignar_Click(sender As Object, e As EventArgs) Handles Btn_Asignar.Click
        Try
            Dim Idempleado As Integer = 0
            Dim Gestor As String = ""
            Dim myForm As New frmConsultaEmpleado

            myForm.Text = "Gestores"
            myForm.Estatus = "A"
            myForm.Pnl_Edicion.Visible = False
            myForm.Height = 400
            myForm.IdDepto = 5
            myForm.IdPuesto = 30
            GLB_RefrescarPedido = False

            myForm.ShowDialog()

            If GLB_RefrescarPedido = False Then Exit Sub

            Idempleado = Val(myForm.Campo)
            Gestor = Idempleado & "-" & myForm.Campo1



            Dim Distrib As String = ""


            ''''----
            'Dim Rows As New ArrayList()
            '' Add the selected rows to the list.
            'Dim I As Integer
            'For I = 0 To GridView1.SelectedRowsCount() - 1
            '    If (GridView1.GetSelectedRows()(I) >= 0) Then
            '        GridView1.SetRowCellValue(GridView1.GetSelectedRows()(I), "gestor", Gestor)
            '        Distrib = GridView1.GetRowCellValue(GridView1.GetSelectedRows()(I), "distrib").ToString.Trim



            '        'GridView1.SetRowCellValue(I, "Campo4", Gestor)
            '        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            '            If objTrasp.usp_Captura_VencidoAsignada(1, GLB_FechaHoy, Distrib, Idempleado, GLB_Idempleado) Then

            '            End If
            '        End Using



            '    End If
            'Next

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
                    ' Change the field value.
                    Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        If objTrasp.usp_Captura_VencidoAsignada(1, GLB_FechaHoy, Row("distrib"), Idempleado, 132) Then

                        End If
                    End Using
                Next




            '' Guardar el gestor asignado, por la fecha.
            GridView1.BestFitColumns()
            Call RellenaGrid()
            Call RellenaGrid1()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Refrescar_Click(sender As Object, e As EventArgs) Handles Btn_Refrescar.Click
        Call RellenaGrid()
    End Sub

    Private Sub DGrid1_Click_1(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim concepto As Integer = Mid((View.GetRowCellDisplayText(e.RowHandle, View.Columns("gestor"))), 1, 1)
                If concepto = 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.BackColor2 = Color.SeaShell
                    'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
                    e.Appearance.BorderColor = Color.Red

                Else
                    '0 no se ha asignado.
                    ' e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor = Color.Gold
                    e.Appearance.BackColor2 = Color.SeaShell
                    'e.Appearance.Font = New Font(Font.FontFamily, 2, FontStyle.Bold)
                    e.Appearance.BorderColor = Color.Red


                    'New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    ' e.Appearance.BackColor2 = Color.SeaShell
                End If

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_QuitarAsignacion_Click(sender As Object, e As EventArgs) Handles Btn_QuitarAsignacion.Click
        'mreyes 26/Noviembre/2017  10:07 a.m.

        Try
            Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                If objTrasp.usp_Captura_VencidoAsignada(2, GLB_FechaHoy, "", 0, GLB_Idempleado) Then
                    ' No se pudo 

                End If
            End Using

            Call RellenaGrid()
            Call RellenaGrid1()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class