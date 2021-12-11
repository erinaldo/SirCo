Imports DevExpress.DashboardCommon
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns.GridColumn
Public Class frmPpalTrasPendRecibo
    Private objDataSet As DataSet
    Private objDataSet1 As DataSet 'Segundo Nivel
    Public SucurOriB As String = ""
    Dim SucurDesB As String = ""
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


    Private izquierda As Integer = 0
    Private alto As Integer = 0



    Private Sub frmPpalPpalDetFactProv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call GenerarToolTip()
        Sw_Pintar = True
        Sw_Load = True
        Call LimpiarBusqueda()
        Call RellenarGrido()
        'If GLB_AccesoEmpleado = True Then
        '    Btn_Excel.Enabled = False
        '    Btn_Filtro.Enabled = False
        'End If
        GridView1.OptionsBehavior.Editable = True
        If Opcion = 1 Then
            Me.Text = "Traspasos Pendientes por Recibir"
        ElseIf Opcion = 2 Then
            Me.Text = "Traspasos Pendientes que me Reciban"
        End If
    End Sub
    Private Sub frmPpalPpalDetFactProv_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        Temporizador.Start()
        If Sw_NoRegistros = False Then Exit Sub
        'If Sw_Load = True Then
        '    Sw_Load = False
        'blnPrimero = True
        InicializarGrido()
        'AgregarColumna()
        '    Call BarrerGrid()
        'End If
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Filtro, "Búsqueda Avanzada")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Pendientes, "Traspasos Pendientes")
            ToolTip.SetToolTip(Btn_RecibosParciales, "Traspasos Parciales")
            ToolTip.SetToolTip(Btn_RecibosTodos, "Todos los Traspasos")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarBusqueda()
        If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
            If Opcion = 1 Then
                SucurDesB = GLB_CveSucursal
            ElseIf Opcion = 2 Then
                SucurOriB = GLB_CveSucursal
            End If
        Else
            If SucurOriB <> "16" And SucurOriB <> "17" Then
                SucurOriB = ""
            Else
                Btn_Pendientes.Visible = False
                Btn_RecibosTodos.Visible = False
                Btn_RecibosParciales.Visible = False

            End If
            SucurDesB = ""
        End If
            FechaInib = "1900-01-01"
        FechaFinb = "1900-01-01"
        'FechaInib = Format(DateSerial(Now.Year, Now.Month, 1), "yyyy-MM-dd")
        'Dim fecha1 As Date = DateAdd(DateInterval.Month, 1, Now.Date)
        'FechaFinb = Format(DateAdd(DateInterval.Day, -1, DateSerial(fecha1.Year, fecha1.Month, 1)), "yyyy-MM-dd")
        'FechaInib = Format(Now.Add(New TimeSpan(-30, 0, 0, 0)), "yyyy-MM-dd")
        'FechaFinb = Format(Now.Date, "yyyy-MM-dd")
    End Sub
    Private Sub RellenarGrido()
        'Tony Garcia - 04/Diciembre/2012 - 5:15 p.m.
        Using objTrasp As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                'DGrid.ReadOnly = True
                Grido.DataSource = Nothing
                objDataSet = objTrasp.usp_TraerTrasPendRecibo(OpcionSP, SucurOriB, SucurDesB, FechaInib, FechaFinb)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    Grido.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializarGrido()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True
                    Sw_NoRegistros = True
                    Sw_Pintar = True
                    If GridView1.DataRowCount > 0 Then
                        Lbl_Trasp.Text = "Numero de Traspasos:" & GridView1.DataRowCount - 1
                    End If
                    '    'If Dgrid1.RowCount > 0 Then
                    '    Lbl_Trasp.Text = "Número de Traspasos: " & Dgrid1.RowCount - 1
                    'End If
                    'Call Colores()
                Else
                    Sw_NoRegistros = False
                    Me.Cursor = Cursors.Default
                    ' MsgBox("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub frmPpalPpalDetFactProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
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
                Call RellenarGrido()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_RecibosParciales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecibosParciales.Click
        Try
            OpcionSP = 2
            Call RellenarGrido()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_RecibosTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RecibosTodos.Click
        Try
            OpcionSP = 1
            Call RellenarGrido()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Regresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Try
            If Btn_Regresar.Enabled = True Then
                'DGrid1.DataSource = Nothing
                'DGrid1.DataSource = objDataSet.Tables(0)
                'InicializaGrid1()
                GridView1.Columns.Clear()
                RellenarGrido()
                PBox.Image = Nothing
                PBox.Visible = False
                Btn_Regresar.Enabled = False
                blnEntraDet = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pendientes.Click
        Try
            OpcionSP = 3
            Call RellenarGrido()
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
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
        If info.InRow OrElse info.InRowCell Then
            Grid_DoubleClick()
        End If
    End Sub
    Private Sub Btn_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Excel.Click
        Try
            If SFdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Grido.ExportToXls(SFdRuta.FileName)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid1_KeyUp(sender As Object, e As KeyEventArgs) Handles Grido.KeyUp
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString()) Then
            'If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString(), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString())
        End If
    End Sub
    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles Grido.Click
        If blnEntraDet = False Then Exit Sub
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString()) Then
            'If IsDBNull(DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value) Then
        Else
            'CargarFotoArticulo(DGrid.Rows(DGrid.CurrentRow.Index).Cells("Marca").Value, DGrid.Rows(DGrid.CurrentRow.Index).Cells("Estilon").Value)
            CargarFotoArticulo(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "marca").ToString(), GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "estilon").ToString())
        End If
    End Sub
    Private Sub InicializarGrido()
        Try
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.Columns(0).Caption = " SucurOri "
            GridView1.Columns(1).Caption = " Origen "
            GridView1.Columns(2).Caption = " Traspaso Envio "
            GridView1.Columns(3).Caption = " Fecha Envio "
            GridView1.Columns(4).Caption = " Hora "
            GridView1.Columns(5).Caption = " Pares Envio "
            GridView1.Columns(6).Caption = " Usuario Envia "
            GridView1.Columns(7).Caption = " SucurDes "
            GridView1.Columns(8).Caption = " Destino "
            GridView1.Columns(9).Caption = " Traspaso Recibo "
            GridView1.Columns(10).Caption = " Referenc "
            GridView1.Columns(11).Caption = " Fecha Recibo "
            GridView1.Columns(12).Caption = " Hora "
            GridView1.Columns(13).Caption = " Pares Recibidos "
            GridView1.Columns(14).Caption = " Traspasos "
            GridView1.Columns(15).Caption = " Usuario Recibe "
            GridView1.Columns(0).Visible = False
            GridView1.Columns(7).Visible = False
            GridView1.Columns(10).Visible = False
            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(10).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(11).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(12).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(13).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(14).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(15).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            GridView1.Columns(16).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            '    GridView1.Columns(16).Visible = False

            GridView1.Columns(2).BestFit()
            GridView1.BestFitColumns()

            If OpcionSP = 3 Then
                GridView1.Columns(10).Visible = False
            Else
                GridView1.Columns(10).Visible = True
            End If
            For I As Integer = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub InicializarGrido2()
        Try
            GridView1.OptionsView.ColumnAutoWidth = False
            GridView1.Columns(0).Caption = " Sucursal "
            GridView1.Columns(1).Caption = " Traspaso "
            GridView1.Columns(2).Caption = " Marca "
            GridView1.Columns(3).Caption = " Estilo "
            GridView1.Columns(4).Caption = " Medida "
            GridView1.Columns(5).Caption = " Corrida "
            GridView1.Columns(6).Caption = " Series "
            GridView1.Columns(7).Caption = " Pares "
            GridView1.Columns(8).Caption = " Costo "
            GridView1.Columns(9).Caption = " Precio "
            GridView1.BestFitColumns()
            GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(2).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(3).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(4).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(5).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(6).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(7).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(8).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            GridView1.Columns(9).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
            For I As Integer = 0 To GridView1.Columns.Count - 1
                GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                GridView1.Columns(I).OptionsColumn.ReadOnly = True
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Grid_DoubleClick()
        Dim Sucursal As String = ""
        Dim Traspaso As String = ""
        Try
            Sucursal = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "sucursal").ToString()
            Traspaso = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "traspaso").ToString()
            GridView1.Columns.Clear()
            Using ObjTrasp As New BCL.BCLTraspasosSQL(GLB_ConStringSirCoSQL)
                objDataSet1 = ObjTrasp.usp_TraerTraspasosDet(Sucursal, Traspaso)
            End Using
            If objDataSet1.Tables(0).Rows.Count > 0 Then
                Grido.DataSource = Nothing
                Grido.DataSource = objDataSet1.Tables(0)
                InicializarGrido2()
                blnEntraDet = True
                Btn_Regresar.Enabled = True
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_Click(sender As Object, e As EventArgs) Handles PBox.Click

    End Sub

    Private Sub Pnl_Botones_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub



    Public Sub ver(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            If e.Column.FieldName = "Salida" Then
                If e.CellValue = 0 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)


                Else
                    e.Appearance.BackColor = Color.PowderBlue
                    e.Appearance.Font = New Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)

                End If

            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Temporizador_Tick(sender As Object, e As EventArgs) Handles Temporizador.Tick
        'If SucurOriB = "16" Or SucurOriB = "17" Then

        'End If
        If blnEntraDet = False Then
            GridView1.Columns.Clear()
            RellenarGrido()
        End If




    End Sub

    Private Sub PBox_MouseDown(sender As Object, e As MouseEventArgs) Handles PBox.MouseDown
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

    Private Sub PBox_MouseMove(sender As Object, e As MouseEventArgs) Handles PBox.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PBox.Location = New Point(PBox.Left + e.X - izquierda, PBox.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_MouseUp(sender As Object, e As MouseEventArgs) Handles PBox.MouseUp
        Try
            PBox.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Grid_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Grid.Paint

    End Sub

    'Sub InicializaGrid()
    '    Try

    '        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)

    '        DGrid.DataSource = dt

    '        DGrid.RowHeadersVisible = False
    '        DGrid.Columns(0).HeaderText = "SucurOri"
    '        DGrid.Columns(1).HeaderText = "Origen"
    '        DGrid.Columns(2).HeaderText = "Traspaso Envio"
    '        DGrid.Columns(3).HeaderText = "Fecha Envio"
    '        DGrid.Columns(4).HeaderText = "Hora"
    '        DGrid.Columns(5).HeaderText = "Pares Envio"
    '        DGrid.Columns(6).HeaderText = "Usuario Envia"
    '        DGrid.Columns(7).HeaderText = "SucurDes"
    '        DGrid.Columns(8).HeaderText = "Destino"
    '        DGrid.Columns(9).HeaderText = "Traspaso Recibo"
    '        DGrid.Columns(10).HeaderText = "Referenc"
    '        DGrid.Columns(11).HeaderText = "Fecha Recibo"
    '        DGrid.Columns(12).HeaderText = "Hora"
    '        DGrid.Columns(13).HeaderText = "Pares Recibidos"
    '        DGrid.Columns(14).HeaderText = "Traspasos"
    '        DGrid.Columns(15).HeaderText = "Usuario Recibe"

    '        DGrid.Columns(0).Visible = False
    '        DGrid.Columns(7).Visible = False
    '        DGrid.Columns(10).Visible = False
    '        If OpcionSP = 3 Then
    '            DGrid.Columns(10).Visible = False
    '        Else
    '            DGrid.Columns(10).Visible = True
    '        End If


    '        DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    'Sub InicializaGrid2()
    '    Try
    '        Dim dt As DataTable = TryCast(DGrid.DataSource, DataTable)
    '        Dim row As DataRow = dt.NewRow()

    '        row(6) = "Total Pares"
    '        row(7) = pub_SumarColumnaGrid(DGrid, 7, DGrid.RowCount - 1)

    '        dt.Rows.InsertAt(row, 0)

    '        DGrid.DataSource = dt

    '        DGrid.RowHeadersVisible = False
    '        DGrid.Columns(0).HeaderText = "Sucursal"
    '        DGrid.Columns(1).HeaderText = "Traspaso"
    '        DGrid.Columns(2).HeaderText = "Marca"
    '        DGrid.Columns(3).HeaderText = "Estilo"
    '        DGrid.Columns(4).HeaderText = "Medida"
    '        DGrid.Columns(5).HeaderText = "Corrida"
    '        DGrid.Columns(6).HeaderText = "Serie"
    '        DGrid.Columns(7).HeaderText = "Pares"
    '        DGrid.Columns(8).HeaderText = "Costo"

    '        DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

    '        DGrid.Columns(8).DefaultCellStyle.Format = "c"

    '        DGrid.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
    '        DGrid.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DGrid.Rows(0).Cells(7).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    '        DGrid.Rows(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

    '        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

End Class