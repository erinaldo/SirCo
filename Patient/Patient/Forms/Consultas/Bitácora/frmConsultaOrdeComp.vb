Public Class frmConsultaOrdeComp
    'mreyes 21/Mayo/2012 01:17 p.m.


    Public Tipo As String    'M = MARCA, F = FAMILIA, L = LINEA, P = PROVEEDOR , TA = TIPOARTICULO, C = CATEGORIA
    'E = ESTILO
    Public Campo As String = "" '' valor de regreso para el primer texto
    Public Campo1 As String = "" ''valor de regreso para el segundo texto
    Dim Sw_NoRegistros As Boolean = False
    Public Marca As String = ""
    Public OrdeComp As String = ""
    Public Sucursal As String = ""

    Dim Sw_Load As Boolean = True
    Dim SqlBuscar As String
    Private objDataSet As Data.DataSet


    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        Dim Buscar As String = ""

        Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                If Sw_Load = True Then
                    Sw_Load = False

                Else

                    If Sw_NoRegistros = True Then
                        DGrid.Columns.Remove("Selec")

                    End If
                End If

                If Txt_Buscar.Text.Length > 0 Then
                    Buscar = "%" & Txt_Buscar.Text & "%"

                End If
                objDataSet = objMySqlGral.usp_TraerDet_OcEstilo(Marca, "", Sucursal, OrdeComp, Buscar)
                'Populate the Project Details section

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section
                    Sw_NoRegistros = True
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("La orden de compra no existe, verifique por favor. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    Close()
                    Dispose()


                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        'mreyes 12/Febrero/2011 05:37 p.m.
        Try

            DGrid.Columns(0).HeaderText = "TA"
            DGrid.Columns(1).HeaderText = "Fam"
            DGrid.Columns(2).HeaderText = "Lin"
            DGrid.Columns(3).HeaderText = "Cat"
            DGrid.Columns(4).HeaderText = "EstiloF"
            DGrid.Columns(5).HeaderText = "EstiloN"
            DGrid.Columns(6).HeaderText = "Descripción"
            DGrid.Columns(7).HeaderText = "C"
            DGrid.Columns(8).HeaderText = "I"
            DGrid.Columns(9).HeaderText = "De"
            DGrid.Columns(10).HeaderText = "A"
            DGrid.Columns(11).HeaderText = "Entrega"
            DGrid.Columns(12).HeaderText = "Cancela"


            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
            DGrid.Columns(2).ReadOnly = True
            DGrid.Columns(3).ReadOnly = True
            DGrid.Columns(4).ReadOnly = True
            DGrid.Columns(5).ReadOnly = True
            DGrid.Columns(6).ReadOnly = True
            DGrid.Columns(7).ReadOnly = True
            DGrid.Columns(8).ReadOnly = True
            DGrid.Columns(9).ReadOnly = True
            DGrid.Columns(10).ReadOnly = True
            DGrid.Columns(11).ReadOnly = True
            DGrid.Columns(12).ReadOnly = True
            DGrid.Columns(13).ReadOnly = True
            DGrid.Columns(14).ReadOnly = True
            DGrid.Columns(15).ReadOnly = True
            DGrid.Columns(16).ReadOnly = True
            DGrid.Columns(17).ReadOnly = True
            DGrid.Columns(18).ReadOnly = True
            DGrid.Columns(19).ReadOnly = True


            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False
            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).Visible = False



            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            AgregarColumna()
            DGrid.Columns(20).ReadOnly = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub
    Private Sub AgregarColumna()
        'mreyes 21/Mayo/2012 04:42 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 20
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub
    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        glb_formconsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            glb_formconsulta = True
            Me.Close()
        End If

    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Sw_Load = True
            GLB_FormConsulta = True
            Call RellenaGrid()
            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_Buscar, "Escriba lo que pretende buscar")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Buscar.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

    Private Sub Factura_Microsip()
        'mreyes 21/Mayo/2012 07:03 p.m.
        Dim i As Integer = 0
        For i = 0 To DGrid.RowCount - 2
            If DGrid.Rows(i).Cells("Selec").Value = True Then
                DGrid.Rows(i).Cells("Selec").Value = False
            Else
                DGrid.Rows(i).Cells("Selec").Value = True
            End If


        Next
    End Sub
    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
            Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString.Trim()

            Me.Close()
            Me.Dispose()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Factura_Microsip()
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 21/Mayo/2012 07:29 p.m.
        'Dim i As Integer
        'For i = 0 To DGrid.Rows.Count - 1

        'Next
        If MsgBox("Esta seguro de recibir la mercancía solicitada para la orden de compra?.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
            Me.Hide()
        End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub
End Class