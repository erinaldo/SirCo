Imports System.IO

Public Class frmPpalBitProcesos
    Dim Sw_NoRegistros As Boolean = False
    Dim Sw_Pintar As Boolean = False
    Private objDataSet As Data.DataSet
    Dim Fecha As Date
    Dim FechaAntiinvent As Date
    Public Opcion As Integer = 0

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If dt_Fecha.Value = Fecha Then Exit Sub

            Fecha = dt_Fecha.Value
            FechaAntiinvent = DateAdd(DateInterval.Day, 1, Fecha)
            Opcion = 2
            RellenaGrid()
           
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()

        Using objBitProc As New BCL.BCLBitProcesos(GLB_ConStringCipSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing


                objDataSet = objBitProc.usp_PpalBitProcesos(Opcion, Fecha, FechaAntiinvent)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 

                    DGrid.DataSource = objDataSet.Tables(0)
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
                    MsgBox("No se encontrarón registros de ejecucuión de procesos. Verificar con Desarrollo.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False
                    'Txt_Ejercicio.Text = ""
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

            DGrid.Columns(0).HeaderText = "Proceso"
            DGrid.Columns(1).HeaderText = "Fecha"
            DGrid.Columns(2).HeaderText = "Inicio"
            DGrid.Columns(3).HeaderText = "Fin"
            DGrid.Columns(4).HeaderText = "Duración"


            DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGrid.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt"
            DGrid.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt"
            '"dd'/'MM'/'yyyy hh:mm:ss tt";


            DGrid.Columns(1).Visible = False
            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmCatalogoSegBit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmCatalogoSegBit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            dt_Fecha.MaxDate = CDate(GLB_FechaHoy)
            dt_Fecha.Value = DateAdd(DateInterval.Day, -1, GLB_FechaHoy)


            Fecha = DateAdd(DateInterval.Day, -1, GLB_FechaHoy)
            FechaAntiinvent = GLB_FechaHoy

            RellenaGrid()

            GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar")
            ToolTip.SetToolTip(Btn_Cancelar, "Salir")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            Me.Close()
            Me.Dispose()
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

    Private Sub DGrid_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGrid.CellFormatting
        Try
            ' If OpcionSP <> 2 Then Exit Sub
            If e.RowIndex = DGrid.RowCount - 1 Then

                Exit Sub
            End If

            If Me.DGrid.Columns(e.ColumnIndex).Name = "tipo" Then




                If Mid((DGrid.Rows(e.RowIndex).Cells("tipo").Value), 1, 3) = "SQL" Then
                    DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.PowderBlue
                    DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                Else
                    DGrid.Rows(e.RowIndex).Cells("tipo").Style.BackColor = Color.SeaShell
                    DGrid.Rows(e.RowIndex).Cells("tipo").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                End If
            End If

            If Me.DGrid.Columns(e.ColumnIndex).Name = "duracion" Then


                If Len((DGrid.Rows(e.RowIndex).Cells("duracion").Value.ToString)) = 10 Then
                    DGrid.Rows(e.RowIndex).Cells("duracion").Style.BackColor = Color.Red
                    DGrid.Rows(e.RowIndex).Cells("duracion").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                ElseIf DGrid.Rows(e.RowIndex).Cells("duracion").Value.ToString > "00:20:00" Then
                    DGrid.Rows(e.RowIndex).Cells("duracion").Style.BackColor = Color.Yellow
                    DGrid.Rows(e.RowIndex).Cells("duracion").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                Else


                    DGrid.Rows(e.RowIndex).Cells("duracion").Style.BackColor = Color.GreenYellow
                    DGrid.Rows(e.RowIndex).Cells("duracion").Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)


                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class