Imports System.IO

Public Class frmPpalArticulosSinFoto
    'mreyes 29/Octubre/2012 01:38 p.m.

    Dim Sql As String
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0
    Private objDataSet As Data.DataSet

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'miguel pérez 30/Octubre/2012 05:40 p.m.
        Try
            DGrid.DataSource = Nothing
            Label3.Text = ""
            Dim FechaIni As String
            Dim FechaFin As String
            If dt_FechaIni.Value > dt_FechaFin.Value Then
                MessageBox.Show("La fecha inicial debe ser menor a la fecha final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dt_FechaIni.Focus()
                Exit Sub
            End If

            FechaIni = CDate(dt_FechaIni.Value).ToString("yyyyMMdd")
            FechaFin = CDate(dt_FechaFin.Value).ToString("yyyyMMdd")

            Using objArticulos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                objDataSet = objArticulos.usp_TraerArticulosSinFoto(FechaIni, FechaFin)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid.DataSource = objDataSet.Tables(0)
                Label3.Text = "Artículos sin foto: " + objDataSet.Tables(0).Rows.Count.ToString
                InicializaGrid()
            Else
                Label3.Text = ""
                MessageBox.Show("No se encontraron artículos sin fotos en las fechas seleccionadas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Sub InicializaGrid()
        Try
            For i As Integer = 0 To DGrid.Columns.Count - 1
                DGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            DGrid.Columns(3).HeaderText = "Descripción"
            DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

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
            dt_FechaFin.MaxDate = CDate(GLB_FechaHoy)
            dt_FechaIni.MaxDate = CDate(GLB_FechaHoy)
            GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar")
            ToolTip.SetToolTip(Btn_Cancelar, "Salir")
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
End Class