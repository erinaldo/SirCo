Public Class frmPpalPreciosDet
    'mreyes 24/Octubre/2016 12:21 p.m.

    Private objDataSet As Data.DataSet
    Dim FechaInib As String
    Dim Sucursalb As String
    Dim FechaFinb As String
    Dim Sw_Load As Boolean = False
    Dim idcajacalzadoini As Integer = 0
    Dim idcajacalzadofin As Integer = 0

    Dim Sw_NoRegistros As Boolean = False

    Private Sub frmPpalEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

     
    End Sub

    Private Sub frmPpalEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Sw_Load = True
            Call LimpiarBusqueda()
            Call RellenaGrid()
            Call GenerarToolTip()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try


            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Registro Caja Calzado")

            ToolTip.SetToolTip(Btn_Consultar, "Consultar Registro Caja Calzado")



            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenaGrid()
        'mreyes
        Using objPedidoNuevo As New BCL.BCLAjustes(GLB_ConStringCipSis)
            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                If Sw_Load = True Then
                    Sw_Load = False

                End If



                objDataSet = objPedidoNuevo.usp_PpalPreciosDet()
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    DGrid.Visible = False
                    DGrid.Refresh()
                    Application.DoEvents()
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default
                    'LimpiarBusqueda()
                    Btn_Excel.Enabled = True

                    Btn_Consultar.Enabled = True

                    DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells


                    DGrid.Visible = True
                    DGrid.Refresh()
                    Application.DoEvents()


                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron Estilos que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")

                    Btn_Excel.Enabled = False

                    Btn_Consultar.Enabled = False

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub LimpiarBusqueda()

        FechaInib = Format(Now.Add(New TimeSpan(-7, 0, 0, 0)), "yyyyMMdd")
        FechaFinb = Format(Now.Date, "yyyyMMdd")
        idcajacalzadofin = 0
        idcajacalzadoini = 0
        Sucursalb = ""
    End Sub
    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Refrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        '' date(a.fum) fecha, A.sucursalact, s.descrip, idcajacalzado, a.idfoliosuc, proveedor, fecreci,       marcaanterior, estilonanterior, corridaanterior, medidaanterior,
        '' marcanuevo, estilonnuevo, corridanuevo, medidanuevo, observaciones, a.idusuario, a.fum

        'mreyes 02/Marzo/2016 07:09 p.m.
        Try
            DGrid.RowHeadersVisible = False
            DGrid.Columns(0).HeaderText = "Det Contado"
            DGrid.Columns(1).HeaderText = "Folio Contado"
            DGrid.Columns(2).HeaderText = "Det Crédito"
            DGrid.Columns(3).HeaderText = "Folio Crédito"
            DGrid.Columns(4).HeaderText = "Promoción"
            DGrid.Columns(5).HeaderText = "Fecha Inicio"
            DGrid.Columns(6).HeaderText = "Id Empleado"
            DGrid.Columns(7).HeaderText = "Fum"

            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ''  DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

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
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim myForm As New frmCatalogoPreciosDet

        myForm.Accion = 1
        myForm.ShowDialog()
        If myForm.Sw_Registro = True Then
            Call RellenaGrid()
        End If
    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick


    End Sub

    Private Sub DGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEnter

    End Sub


    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try

            If DGrid.Columns(DGrid.CurrentCell.ColumnIndex).Name = "Imagen" Then
                Btn_Foto_Click(sender, e)

            Else
                Call Btn_Consultar_Click(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            Call Btn_Consultar_Click(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If Sw_NoRegistros = False Then Exit Sub
        Dim myForm As New frmCatalogoCajaCalzado

        myForm.Accion = 4
        myForm.IdCajaCalzado = DGrid.Rows(DGrid.CurrentRow.Index).Cells("IdCajaCalzado").Value.ToString.Trim()
        myForm.Txt_Serie.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("SERIE").Value.ToString.Trim()
        myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("MARCAANTERIOR").Value.ToString.Trim()
        myForm.Txt_Modelo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ESTILONANTERIOR").Value.ToString.Trim().PadLeft(7)
        myForm.Txt_Corrida.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("CORRIDAANTERIOR").Value.ToString.Trim()
        myForm.Txt_Medida.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("MEDIDAANTERIOR").Value.ToString.Trim()


        myForm.Txt_IdFolioSuc.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("IDFOLIOSUC").Value.ToString.Trim()
        myForm.Txt_Proveedor.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("PROVEEDOR").Value.ToString.Trim()
        myForm.Txt_FechaRecibo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("FECRECI").Value

        myForm.Txt_MarcaNuevo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("MARCANUEVO").Value.ToString.Trim()
        myForm.Txt_ModeloNuevo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("ESTILONNUEVO").Value.ToString.Trim().PadLeft(7)
        myForm.Txt_CorridaNuevo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("CORRIDANUEVO").Value.ToString.Trim()
        myForm.Txt_MedidaNuevo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("MEDIDANUEVO").Value.ToString.Trim()

        myForm.Cbo_Motivo.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("OBSERVACIONES").Value.ToString.Trim()

        myForm.Txt_SucursalAct.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("SUCURSALACT").Value.ToString.Trim()
        myForm.Txt_SucursalOri.Text = Mid(DGrid.Rows(DGrid.CurrentRow.Index).Cells("IDFOLIOSUC").Value.ToString.Trim(), 1, 2)


        myForm.ShowDialog()

    End Sub





    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Btn_Foto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value.ToString
            myForm.Txt_Marca.Text = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value.ToString.Trim()
            myForm.Txt_NoFoto.Text = "1"
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenToolStripMenuItem.Click
        Call Btn_Foto_Click(sender, e)
    End Sub

    Private Sub NuevoEstiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoEstiloToolStripMenuItem.Click
        Call Btn_Nuevo_Click(sender, e)
    End Sub



    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Sw_NoRegistros = False Then Exit Sub
    End Sub




    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



End Class