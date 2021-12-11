Public Class frmPpalLiqAutomatica
    'mreyes 08/Septiembre/2016  12:59 p.m.

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
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim blnEntraDet As Boolean = False

    Dim IdProTrasB As Integer = 0
    Dim EstatusB As String = ""
    Private izquierda As Integer = 0
    Private alto As Integer = 0
    'Dim myFormFiltros As frmFiltrosAparadorReal
    Dim sw_liq As Boolean = False

    '-- filtros
    Public Division As String = ""
    Public Depto As String = ""
    Public Familia As String = ""
    Public Linea As String = ""
    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public Marca As String = ""
    Public Modelo As String = ""
    Public IdAgrupacion As Integer = 0


    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        DT_FecIni.Value = DateAdd("d", 1, GLB_FechaHoy)
        Call LimpiarBusqueda()
        Call RellenaGrid()


    End Sub

    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        ' InicializaGrid()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub

    Private Sub GenerarToolTip()
        Try

            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")

            ToolTip.SetToolTip(Btn_Salir, "Salir")
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

    Private Sub RellenaGrid()
        'mreyes 08/Septiembre/2016  01:21 p.m.
        DGrid.Visible = False
        'InicializaGrid()
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                DGrid.DataSource = Nothing

                objDataSet = objTrasp.usp_PpalLiqAutomatica(Marca, Division, Depto, Familia, Linea, L1, L2, L3, L4, L5, L6, IdAgrupacion)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    '
                    DGrid.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    'If Sw_Load = False Then
                    ''''
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    ''If DGrid.RowCount > 0 Then
                    ''    If OpcionSP = 1 Then
                    ''        Lbl_Trasp.Visible = True
                    ''        Lbl_Trasp.Text = "Número de Traspasos: " & DGrid.RowCount - 1
                    ''    Else
                    ''        ' Lbl_Trasp.Text = "Número de Estilos a Traspasar: " & DGrid.RowCount - 1
                    ''        Lbl_Trasp.Visible = False

                    ''    End If
                    ''End If
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                DGrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub AgregarColumna()
        Try
            Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()

            ' colImagen.Frozen = True
            colImagen.Name = "Liq"
            colImagen.HeaderText = "Liq"
            colImagen.DisplayIndex = 17
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImagen.CellTemplate = New DataGridViewCheckBoxCell()

            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.DGrid.Columns.Add(colImagen)


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Sub InicializaGrid()
        'mreyes 08/Septiembre/2016  04:53 p.m.

        Try



            DGrid.RowHeadersVisible = False

            DGrid.Columns(0).HeaderText = "Marca"
            DGrid.Columns(1).HeaderText = "Modelo"
            DGrid.Columns(2).HeaderText = "D.Ideal"
            DGrid.Columns(3).HeaderText = "D.Ap"
            DGrid.Columns(4).HeaderText = "Prs Rec"
            DGrid.Columns(5).HeaderText = "Prs Vta"
            DGrid.Columns(6).HeaderText = "Inv"
            DGrid.Columns(7).HeaderText = "Proy Tot D.Ap"
            DGrid.Columns(8).HeaderText = "Promo Actual"
            DGrid.Columns(9).HeaderText = "Fecha Promo"


            DGrid.Columns(10).HeaderText = "Con"
            DGrid.Columns(11).HeaderText = "Cré"

            DGrid.Columns(12).HeaderText = "Costo"


            DGrid.Columns(13).HeaderText = "Contado"
            DGrid.Columns(14).HeaderText = "Crédito"
            DGrid.Columns(15).HeaderText = "% Directo"
            DGrid.Columns(16).HeaderText = "% D.E."
            DGrid.Columns(17).HeaderText = "Fum"

            DGrid.Columns(10).DefaultCellStyle.Format = "#"
            DGrid.Columns(11).DefaultCellStyle.Format = "#"

            DGrid.Columns(12).DefaultCellStyle.Format = "c"
            ' DGrid.Columns(11).DefaultCellStyle.Format = "c"

            DGrid.Columns(17).Visible = False




            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


            DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(0).Frozen = True
            DGrid.Columns(1).Frozen = True

            DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            DGrid.Columns(1).DefaultCellStyle.BackColor = Color.PowderBlue
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(1).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


            DGrid.Columns(4).DefaultCellStyle.BackColor = Color.Bisque
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(5).DefaultCellStyle.BackColor = Color.Bisque
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(6).DefaultCellStyle.BackColor = Color.Bisque
            DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


           
            DGrid.Columns(10).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            DGrid.Columns(11).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            DGrid.Columns(8).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            DGrid.Columns(9).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
            'DGrid.ColumnHeadersDefaultCellStyle(10) = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)


            AgregarColumna()

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


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

    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmFiltrosTraspasosPendRecibo
            myForm.Opcion = Opcion
            myForm.Txt_SucurOri.Text = SucurOriB
            myForm.Txt_SucurDes.Text = SucurDesB

            If FechaInib <> "1900-01-01" Then
                myForm.Chk_FechaTraspaso.Checked = True
                myForm.DTPicker2.Value = FechaInib
                myForm.DTPicker3.Value = FechaFinb
            End If

            If OpcionSP = 3 Then
                myForm.Cbo_Tipo.Text = "PENDIENTES"
            ElseIf OpcionSP = 2 Then
                myForm.Cbo_Tipo.Text = "PARCIALES"
            ElseIf OpcionSP = 1 Then
                myForm.Cbo_Tipo.Text = "TODOS"
            End If

            myForm.ShowDialog()

            SucurOriB = myForm.Txt_SucurOri.Text
            SucurDesB = myForm.Txt_SucurDes.Text

            If myForm.Chk_FechaTraspaso.Checked = True Then
                FechaInib = Format(myForm.DTPicker2.Value, "yyyy-MM-dd")
                FechaFinb = Format(myForm.DTPicker3.Value, "yyyy-MM-dd")
            Else
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
            End If

            If myForm.Cbo_Tipo.Text = "PENDIENTES" Then
                OpcionSP = 3
            ElseIf myForm.Cbo_Tipo.Text = "PARCIALES" Then
                OpcionSP = 2
            ElseIf myForm.Cbo_Tipo.Text = "TODOS" Then
                OpcionSP = 1
            End If

            If myForm.Sw_Filtro = True Then
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosParciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 2
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_RecibosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            OpcionSP = 1
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGrid.CellBeginEdit

    End Sub

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            If e.RowIndex = DGrid.RowCount - 1 Then

                Exit Sub
            End If
            If Sw_Pintar = False Then Exit Sub
            If Me.DGrid.Columns(e.ColumnIndex).Name = "regaladn" Then
                If Val(DGrid.Rows(e.RowIndex).Cells("regaladn").Value) > 0 Then
                    DGrid.Rows(e.RowIndex).Cells("regaladn").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("regaladn").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If
            End If

            If Me.DGrid.Columns(e.ColumnIndex).Name = "contado" Then
                If Val(DGrid.Rows(e.RowIndex).Cells("contado").Value) > 0 Then
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.BackColor = Color.GreenYellow
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                    DGrid.Rows(e.RowIndex).Cells("credito").Style.BackColor = Color.Orange
                    DGrid.Rows(e.RowIndex).Cells("credito").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Else
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.BackColor = Color.White
                    DGrid.Rows(e.RowIndex).Cells("contado").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Regular)

                    DGrid.Rows(e.RowIndex).Cells("credito").Style.BackColor = Color.White
                    DGrid.Rows(e.RowIndex).Cells("credito").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Regular)
                End If
            End If


            If Me.DGrid.Columns(e.ColumnIndex).Name = "porc" Then
                If Val(DGrid.Rows(e.RowIndex).Cells("porc").Value) > 0 Then
                    DGrid.Rows(e.RowIndex).Cells("porc").Style.BackColor = Color.Pink
                    DGrid.Rows(e.RowIndex).Cells("porc").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                End If
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

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        Try
            DGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
            Else
                CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp

        If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
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



    Private Sub PBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                PBox.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myForm As New frmSeriesNoTraspaso

        myForm.ShowDialog()

        Call RellenaGrid()
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        If Sw_NoRegistros = False Then Exit Sub
        Call Selecciona()
    End Sub

    Private Sub Selecciona()
        'mreyes 09/Septiembre/2016  12:05 p.m.
        Me.Cursor = Cursors.AppStarting
        DGrid.Visible = False
        For Each row As DataGridViewRow In DGrid.Rows
            If row.Cells("Liq").Value = True Then
                row.Cells("Liq").Value = False
            Else
                row.Cells("Liq").Value = True
            End If
        Next
        DGrid.Visible = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Btn_NoPropuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NoPropuesta.Click
        Try
            Sw_Pintar = False
            If sw_liq = False Then
                If MessageBox.Show("Estas seguro de eliminar las filas seleccionadas de la liquidación. ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 0 To DGrid.RowCount - 2
                '' Eliminar de liquidación 
                If DGrid.Rows(i).Cells("Liq").Value = True Then
                    If usp_Elimina_LiqAutomatica(DGrid.Rows(i).Cells("marca").Value, DGrid.Rows(i).Cells("estilon").Value) Then
                        Sw_Pintar = False
                    End If
                End If
            Next
            DGrid.Columns.Remove("Liq")

            Call RellenaGrid()
            Sw_Pintar = True
            Me.Cursor = Cursors.Default


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 09/Septiembre/2016  01:55 p.m.
        Try
            Dim Renglon As Integer = 0
            Dim intposicion As Integer = 0
            Dim inttotalrows As Integer = 0
            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Leyenda As String = ""
            Dim objDataSetModelos As Data.DataSet

            If MsgBox("Esta seguro de confirmar la liquidación con fecha de aplicación '" & DT_FecIni.Value & "'.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Me.Cursor = Cursors.WaitCursor

            '' invertir.. 
            '' luego borrar..
            sw_liq = True
            Call Btn_InvertirSeleccion_Click(sender, e)
            Call Btn_NoPropuesta_Click(sender, e)

            If usp_GeneraLiquidacion() = False Then

            End If



            Me.Cursor = Cursors.Default

            ''' traer traspasos .. 
            ''' 

            Using objCatalogoEst As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

                If usp_GeneraProTraspArticulo() = True Then
                    '  MsgBox("No pudo generar propuesta", MsgBoxStyle.Critical, "Error")
                    '   Exit Sub
                    objDataSetModelos = objCatalogoEst.usp_TraerProTraspArticulo("", "       ", "0", "0", "", "", "", "", "", "", "", "", 100, 0)
                    If objDataSetModelos.Tables(0).Rows.Count > 0 Then
                        '' ya hay anteriores.. 
                        Renglon = objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                        intposicion = objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                        inttotalrows = objDataSetModelos.Tables(0).Rows.Count
                        Marca = objDataSetModelos.Tables(0).Rows(0).Item("marca")
                        Modelo = objDataSetModelos.Tables(0).Rows(0).Item("estilon")
                        Leyenda = "1" & " de " & inttotalrows
                    End If

                End If
            End Using


            Dim myForm As New frmAnalisisPropuestaTraspasos

            myForm.MdiParent = BitacoraMain
            myForm.Sw_Menu = True


            myForm.Txt_IdArticulo.Text = Renglon

            myForm.intPosicion = intposicion
            myForm.intTotalRows = inttotalrows
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_Modelo.Text = Modelo
            myForm.Lbl_Totales.Text = Leyenda
            'objDataSetOC = objDataSet.Clone
            myForm.objDataSetModelos = objDataSetModelos.Copy
            myForm.Marca = ""
            myForm.Estilon = ""
            myForm.Division = 0
            myForm.IdDepto = 0

            myForm.IdFamilia = ""
            myForm.IdLinea = ""
            myForm.IdL1 = ""
            myForm.IdL2 = ""
            myForm.IdL3 = ""
            myForm.IdL4 = ""
            myForm.IdL5 = ""
            myForm.IdL6 = ""

            myForm.IdAgrupacion = 100


            myForm.WindowState = FormWindowState.Maximized
            myForm.Accion = 2

            myForm.Show()


            Me.Close()


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function usp_GeneraProTraspArticulo() As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()




                usp_GeneraProTraspArticulo = objCalculo.usp_GeneraProTraspArticulo("0", "       ", "0", "0", "", "", "", "", "", "", "", "", 100, GLB_Idempleado, 1)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_Captura_LiqAutomatica(ByVal Marca As String, ByVal Estilon As String, ByVal Regaladn As Integer, ByVal Porc As Integer, ByVal Contado As Integer, ByVal Credito As Integer, ByVal Tipo As String) As Boolean
        'mreyes 12/Septiembre/2016  10:42 a.m.
        '@regaladn int, @porc int, @contado int, @credito int 

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_Captura_LiqAutomatica = objCalculo.usp_Captura_LiqAutomatica(2, Marca, Estilon, Regaladn, Porc, Contado, Credito, Tipo)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_Elimina_LiqAutomatica(ByVal Marca As String, ByVal Estilon As String) As Boolean
        'mreyes 12/Septiembre/2016  10:24 a.m.


        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_Elimina_LiqAutomatica = objCalculo.usp_Elimina_LiqAutomatica(Marca, Estilon)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_GeneraLiqAutomatica() As Boolean
        'mreyes 19/Septiembre/2016  04:15 p.m.

        '  Dim FechFin As Date = "12/09/2019"

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_GeneraLiqAutomatica = objCalculo.usp_GeneraLiqAutomatica(GLB_Idempleado)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_GeneraLiquidacion() As Boolean
        'mreyes 10/Septiembre/2016  12:40 p.m.
        Dim FechFin As Date = "12/09/2019"

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu

                Application.DoEvents()

                usp_GeneraLiquidacion = objCalculo.usp_GeneraLiquidacion(Format(DT_FecIni.Value, "dd/MM/yyyy"), FechFin, GLB_Idempleado, GLB_Usuario)




                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        'mreyes 12/Septiembre/2016  10:01 a.m.
        Try

            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim encabezado As String = DGrid.Columns(columna).HeaderText
            Dim Tipo As String = ""

            If columna < 12 Or columna > 17 Then Exit Sub
            Dim Valor As Integer

            Dim Marca As String
            Dim Estilon As String
            Dim Regaladn As Integer
            Dim Contado As Integer
            Dim Credito As Integer
            Dim Porc As Integer

            Marca = DGrid.Rows(renglon).Cells("marca").Value
            Estilon = DGrid.Rows(renglon).Cells("estilon").Value
            Regaladn = DGrid.Rows(renglon).Cells("regaladn").Value
            Contado = DGrid.Rows(renglon).Cells("Contado").Value
            Credito = DGrid.Rows(renglon).Cells("Credito").Value
            Porc = DGrid.Rows(renglon).Cells("porc").Value


            If encabezado = "% Directo" Then
                Tipo = "PORCENTAJE"
                ' Estamos hablando de descuento directo 
                Valor = DGrid.Rows(renglon).Cells(columna).Value
                If Valor > 0 Then
                    'DGrid.Rows(renglon).Cells("porc").Value = 0
                    'DGrid.Rows(renglon).Cells("contado").Value = 0
                    'DGrid.Rows(renglon).Cells("credito").Value = 0

                    'Porc = 0
                    'Contado = 0
                    'Credito = 0

                    DGrid.Rows(renglon).Cells("regaladn").Value = 0
                    DGrid.Rows(renglon).Cells("contado").Value = 0
                    DGrid.Rows(renglon).Cells("credito").Value = 0

                    Regaladn = 0
                    Contado = 0
                    Credito = 0

                End If
            End If

            If encabezado = "% D.E." Then
                ' Estamos hablando de dinero electrónico 
                Tipo = "DINERO"
                Valor = DGrid.Rows(renglon).Cells(columna).Value
                If Valor > 0 Then
                    DGrid.Rows(renglon).Cells("porc").Value = 0
                    DGrid.Rows(renglon).Cells("contado").Value = 0
                    DGrid.Rows(renglon).Cells("credito").Value = 0

                    Porc = 0
                    Contado = 0
                    Credito = 0

                End If
            End If


            If encabezado = "Contado" Or encabezado = "Crédito" Then
                ' Estamos de precio a precio 
                Tipo = "PRECIO"
                Valor = DGrid.Rows(renglon).Cells(columna).Value
                If Valor > 0 Then
                    DGrid.Rows(renglon).Cells("regaladn").Value = 0
                    DGrid.Rows(renglon).Cells("porc").Value = 0

                    Regaladn = 0
                    Porc = 0
                End If
            End If

            If usp_Captura_LiqAutomatica(Marca, Estilon, Regaladn, Porc, Contado, Credito, Tipo) Then

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   
            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 12/Septiembre/2016  10:18 a.m.

        Try
            ' obtener indice de la columna  
            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim caracter As Char = e.KeyChar
            Dim CaracterAnt As String = ""

            If columna >= 10 And columna <= 13 Then


                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    e.KeyChar = Chr(0)
                End If



            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_Propuesta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Propuesta.Click
        'mreyes 19/Septiembre/2016  04:40 p.m.
        Try
            If MsgBox("Esta seguro de GENERAR nuevamente la liquidación. ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            PBox.Visible = False

            If usp_GeneraLiqAutomatica() = False Then

            End If
            If Sw_NoRegistros = True Then
                DGrid.Columns.Remove("Liq")
            End If
            Sw_Pintar = False
            Call RellenaGrid()
            Sw_Pintar = True
            Me.Cursor = Cursors.Default

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DT_FecIni_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DT_FecIni.Validated
        If CDate(DT_FecIni.Value) < CDate(GLB_FechaHoy) Then
            DT_FecIni.Focus()
            MsgBox("Debe seleccionar una fecha menor al dia de hoy.", vbExclamation, "Validación")
            DT_FecIni.Value = GLB_FechaHoy

        End If
    End Sub

    Private Sub DT_FecIni_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DT_FecIni.Validating

    End Sub

    Private Sub DT_FecIni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_FecIni.ValueChanged

    End Sub

    Private Sub DGrid_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGrid.MouseDown

    End Sub

    Private Sub ToolStripMenuItemAnaModelo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAnaModelo.Click
        Try
            Dim myForm As New frmAnalisisModelo
            myForm.Txt_Marca.Text = DGrid.CurrentRow.Cells("Marca").Value
            myForm.Txt_Modelo.Text = DGrid.CurrentRow.Cells("estilon").Value
            myForm.Accion = 1
            myForm.WindowState = FormWindowState.Maximized
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Btn_Filtro_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            frmFiltrosLiqAutomatica.StartPosition = FormStartPosition.CenterParent
            frmFiltrosLiqAutomatica.Sw_Filtro = False





            If Division <> "" Then
                If Division = "CALZADO" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    frmFiltrosLiqAutomatica.Txt_Division.Text = "999"
                End If
                frmFiltrosLiqAutomatica.Txt_DescripDivision.Text = Division
            Else
                frmFiltrosLiqAutomatica.Txt_DescripDivision.Text = ""
                frmFiltrosLiqAutomatica.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                frmFiltrosLiqAutomatica.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    frmFiltrosLiqAutomatica.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    frmFiltrosLiqAutomatica.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    frmFiltrosLiqAutomatica.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                frmFiltrosLiqAutomatica.Txt_Marca.Text = Marca
            End If
            frmFiltrosLiqAutomatica.ShowDialog()
            If frmFiltrosLiqAutomatica.Sw_Filtro = True Then
                DGrid.DataSource = Nothing
                DGrid.Refresh()
                DGrid.Rows.Clear()




                Marca = frmFiltrosLiqAutomatica.Txt_Marca.Text
                'If Marca.Trim <> "" Then
                '    lbl_Marca.Text = Marca
                'End If

                If frmFiltrosLiqAutomatica.Txt_DescripDivision.Text.Trim = "" Then
                    Division = ""
                Else
                    Division = frmFiltrosLiqAutomatica.Txt_DescripDivision.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripDepto.Text.Trim = "" Then
                    Depto = ""
                Else
                    Depto = frmFiltrosLiqAutomatica.Txt_DescripDepto.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripFamilia.Text = "" Then
                    Familia = ""
                Else
                    Familia = frmFiltrosLiqAutomatica.Txt_DescripFamilia.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripLinea.Text = "" Then
                    Linea = ""
                Else
                    Linea = frmFiltrosLiqAutomatica.Txt_DescripLinea.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL1.Text = "" Then
                    L1 = ""
                Else
                    L1 = frmFiltrosLiqAutomatica.Txt_DescripL1.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL2.Text = "" Then
                    L2 = ""
                Else
                    L2 = frmFiltrosLiqAutomatica.Txt_DescripL2.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL3.Text = "" Then
                    L3 = ""
                Else
                    L3 = frmFiltrosLiqAutomatica.Txt_DescripL3.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL4.Text = "" Then
                    L4 = ""
                Else
                    L4 = frmFiltrosLiqAutomatica.Txt_DescripL4.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL5.Text = "" Then
                    L5 = ""
                Else
                    L5 = frmFiltrosLiqAutomatica.Txt_DescripL5.Text
                End If
                If frmFiltrosLiqAutomatica.Txt_DescripL6.Text = "" Then
                    L6 = ""
                Else
                    L6 = frmFiltrosLiqAutomatica.Txt_DescripL6.Text
                End If


                DGrid.Columns.Remove("Liq")
                Call RellenaGrid()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_LiberarBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LiberarBD.Click

    End Sub
End Class

