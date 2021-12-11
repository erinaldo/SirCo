
Public Class frmPpalDiarioVales
    'Tony García - 17/Enero/2013 09:30 a.m.

    Private objDataSet As Data.DataSet
    Private FechaInicio As String
    Private FechaFin As String

    Dim Sw_Load As Boolean = True
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False

    Dim SucursalB As String
    Dim NotaB As String
    Dim EstatusB As String
    Dim ValeB As String
    Dim DistribuidorB As String
    Dim NegocioB As String = ""
    Dim ClienteB As String

    Private Sub frmPpalNumValesPorNegocio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If GLB_CveSucursal = "98" Then GLB_CveSucursal = ""
        If GLB_CveSucursal <> "" Then
            Lbl_Sucursal.Visible = False
            Cbo_Sucursal.Visible = False
        Else
        End If
        dt_Inicio.MinDate = CDate("1995-01-01")
        dt_Fin.MinDate = CDate("1995-01-01")
        dt_Inicio.MaxDate = Now.Date
        dt_Fin.MaxDate = Now.Date
        '--------------------------------------------------GridView1.col
        'DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        GridView1.OptionsView.ColumnAutoWidth = True
        Cbo_Sucursal.Text = "00 - TODAS"
        Call LimpiarBusqueda()
        Call RellenaGrid()
        Sw_Pintar = True
        'Sw_Load = False 
    End Sub

    Private Sub frmPpalConceptoRep_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub LimpiarBusqueda()
        FechaInicio = Date.Now
        FechaFin = Date.Now
        SucursalB = ""
        NotaB = ""
        EstatusB = ""
        ValeB = ""
        DistribuidorB = ""
        ClienteB = ""
    End Sub

    Private Sub ObtenerSucursal()
        If Cbo_Sucursal.Text = "00 - TODAS" Then
            SucursalB = ""
        ElseIf Cbo_Sucursal.Text = "01 - JUAREZ" Then
            SucursalB = "01"
        ElseIf Cbo_Sucursal.Text = "02 - HIDALGO" Then
            SucursalB = "02"
        ElseIf Cbo_Sucursal.Text = "03 - VICTORIA" Then
            SucursalB = "03"
        ElseIf Cbo_Sucursal.Text = "04 - HAMBURGO" Then
            SucursalB = "04"
        ElseIf Cbo_Sucursal.Text = "05 - 4 CAMINOS" Then
            SucursalB = "05"
        ElseIf Cbo_Sucursal.Text = "06 - TRIANA" Then
            SucursalB = "06"
        ElseIf Cbo_Sucursal.Text = "07 - LERDO" Then
            SucursalB = "07"
        ElseIf Cbo_Sucursal.Text = "08 - MATRIZ" Then
            SucursalB = "08"
        ElseIf Cbo_Sucursal.Text = "33 - CAPA DE OZONO" Then
            SucursalB = "33"
        ElseIf Cbo_Sucursal.Text = "34 - OZONO 4 CAMINOS" Then
            SucursalB = "34"
        End If
    End Sub

    Private Sub AsignarSucursalCombo()
        If SucursalB = "" Then
            Cbo_Sucursal.Text = "00 - TODAS"
        ElseIf SucursalB = "01" Then
            Cbo_Sucursal.Text = "01 - JUAREZ"
        ElseIf SucursalB = "02" Then
            Cbo_Sucursal.Text = "02 - HIDALGO"
        ElseIf SucursalB = "03" Then
            Cbo_Sucursal.Text = "03 - VICTORIA"
        ElseIf SucursalB = "04" Then
            Cbo_Sucursal.Text = "04 - HAMBURGO"
        ElseIf SucursalB = "05" Then
            Cbo_Sucursal.Text = "05 - 4 CAMINOS"
        ElseIf SucursalB = "06" Then
            Cbo_Sucursal.Text = "06 - TRIANA"
        ElseIf SucursalB = "07" Then
            Cbo_Sucursal.Text = "07 - LERDO"
        ElseIf SucursalB = "08" Then
            Cbo_Sucursal.Text = "08 - MATRIZ"
        ElseIf SucursalB = "33" Then
            Cbo_Sucursal.Text = "33 - CAPA DE OZONO"
        ElseIf SucursalB = "34" Then
            Cbo_Sucursal.Text = "34 - OZONO 4 CAMINOS"
        End If
    End Sub

    Private Sub RellenaGrid()
        'Tony Garcia - 17/Enero/2013 
        Using objValesDiario As New BCL.BCLValesPorNegocio(GLB_ConStringCrvSis)

            Try

                Me.Cursor = Cursors.WaitCursor

                'DGrid.ReadOnly = True

                '-------------------------'              'DGrid.DataSource = Nothing
                Gridview.DataSource = Nothing
                If GLB_CveSucursal <> "" Then
                    objDataSet = objValesDiario.usp_PpalDiarioValesAdapter(GLB_CveSucursal, NotaB, EstatusB, ValeB, DistribuidorB, ClienteB, FechaInicio, FechaFin, NegocioB)
                Else
                    objDataSet = objValesDiario.usp_PpalDiarioValesAdapter(SucursalB, NotaB, EstatusB, ValeB, DistribuidorB, ClienteB, FechaInicio, FechaFin, NegocioB)
                End If

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    'DGrid.DataSource = objDataSet.Tables(0)
                    Gridview.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    'MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()

        Try

            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            Dim dt As DataTable = TryCast(Gridview.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()

            'row(2) = pub_SumaColumnaGrid(DGrid, 2, DGrid.RowCount - 1)
            'row(1) = "Total: "
            'row(10) = pub_SumaColumnaGrid(DGrid, 10, DGrid.RowCount - 1)
            'row(10) = pub_SumaColumnaGrid(Gridview, 10, GridView1.RowCount - 1)

            dt.Rows.InsertAt(row, 0)
            Gridview.DataSource = dt
            'DGrid.DataSource = dt


            'Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()

            'row(1) = "Total: "
            'row(10) = pub_SumaColumnaGrid(DGrid, 10, DGrid.RowCount - 1)

            'dt.Rows.Add(row)
            'DGrid.DataSource = dt


            'DGrid.RowHeadersVisible = False
            'GridView1.h

            GridView1.Columns("Nota").Caption = "Nota"
            GridView1.Columns("status").Caption = "Estatus"
            GridView1.Columns("vale").Caption = "N° Vale"
            GridView1.Columns("negocio").Caption = "Negocio"
            GridView1.Columns("descrip").Caption = "Descripción"
            GridView1.Columns("Distribuidor").Caption = "Distribuidor"
            GridView1.Columns("Nombre").Caption = "Nombre"
            GridView1.Columns("Cliente").Caption = "Cliente"
            GridView1.Columns("Nombre.").Caption = "Nombre"
            GridView1.Columns("fecha").Caption = "Fecha"
            GridView1.Columns("importe").Caption = "Importe"
            GridView1.Columns("pagos").Caption = "N° Pagos"

            GridView1.Columns("importe").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("importe").DisplayFormat.FormatString = "###,##0.00"





            For i As Integer = 0 To GridView1.Columns.Count - 1
                For j As Integer = 0 To GridView1.Columns.Count - 1

                    GridView1.Columns(j).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GridView1.Columns(j).AppearanceHeader.Font = New Font(GridView1.Columns(j).AppearanceCell.Font, FontStyle.Bold)
                    GridView1.Columns(j).OptionsColumn.ReadOnly = True
                Next
            Next
            GridView1.Columns("Nota").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("status").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("vale").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView1.Columns("negocio").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView1.Columns("descrip").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView1.Columns("Distribuidor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView1.Columns("Nombre").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView1.Columns("Cliente").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns("Nombre.").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            GridView1.Columns("fecha").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridView1.Columns("importe").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns("pagos").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center



            GridView1.Columns("importe").GroupFormat.FormatString = "c"

            GridView1.Columns("importe").SummaryItem.FieldName = "importe"
            GridView1.Columns("importe").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            GridView1.Columns("importe").SummaryItem.DisplayFormat = "{0:$###,###,##0}"



            'GridView1.Columns("Nota").AppearanceCell.BackColor = Color.PowderBlue
            'GridView1.Columns("Nota").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'GridView1.Columns("Nota").AppearanceCell.Font = New Font(GridView1.Columns("Nota").AppearanceCell.Font, FontStyle.Bold)

            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.BestFitColumns()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                GridView1.ExportToXls(sfdRuta.FileName)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Bot_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bot_Aceptar.Click
        Try
            Gridview.DataSource = Nothing
            Gridview.Refresh()
            GridView1.Columns.Clear()


            FechaInicio = dt_Inicio.Value
            FechaFin = dt_Fin.Value

            'If FechaFin > Now.Date.ToString("yyyy-MM-dd") Then
            '    MessageBox.Show("La fecha final no debe ser mayor al dia de hoy", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    dt_Fin.Focus()
            '    Exit Sub
            'End If
            If FechaInicio > FechaFin Then
                MessageBox.Show("La fecha de inicio debe ser menor a la fecha final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt_Inicio.Focus()
                Exit Sub
            End If
            'blnRefrescar = True
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cbo_Sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Sucursal.SelectedIndexChanged
        Try
            Call ObtenerSucursal()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cbo_Sucursal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Sucursal.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosDiarioVales

            If FechaInicio <> "1900-01-01" Then
                myForm.Chk_Fecha.Checked = True
                myForm.DTPicker2.Value = FechaInicio
                myForm.DTPicker3.Value = FechaFin
            End If

            If GLB_CveSucursal <> "" Then
                myForm.Txt_Sucursal.Text = GLB_CveSucursal
            Else
                myForm.Txt_Sucursal.Text = SucursalB
            End If

            myForm.Txt_NumCliente.Text = ClienteB
            myForm.Txt_NumDistrib.Text = DistribuidorB
            myForm.Txt_NumVale.Text = ValeB
            myForm.Txt_Nota.Text = NotaB

            myForm.ShowDialog()

            SucursalB = myForm.Txt_Sucursal.Text
            DistribuidorB = myForm.Txt_NumDistrib.Text
            ClienteB = myForm.Txt_NumCliente.Text
            ValeB = myForm.Txt_NumVale.Text
            NotaB = myForm.Txt_Nota.Text

            If myForm.Cbo_Estatus.Text = "APLICADO" Then
                EstatusB = "AP"
            ElseIf myForm.Cbo_Estatus.Text = "CANCELADO" Then
                EstatusB = "ZC"
            ElseIf myForm.Cbo_Estatus.Text = "GENERADO" Then
                EstatusB = "GE"
            End If

            If myForm.Chk_Fecha.Checked = True Then
                FechaInicio = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFin = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")

                'dt_Inicio.Value = myForm.DTPicker2.Value
                'dt_Fin.Value = myForm.DTPicker3.Value

                dt_Inicio.Value = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                dt_Fin.Value = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                'FechaInicio = "1900-01-01"
                'FechaFin = "1900-01-01"
            End If

            Call AsignarSucursalCombo()

            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Gridview_Click(sender As Object, e As EventArgs) Handles Gridview.Click

    End Sub
End Class