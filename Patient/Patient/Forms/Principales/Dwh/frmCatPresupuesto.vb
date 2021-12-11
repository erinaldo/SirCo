Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class frmCatPresupuesto


#Region "Metodos"

    Private NivelAct As String
    Private DT As New DataTable
    Private blnBtnRegresar As Boolean
    Private Sub CreaDTEstado()
        DT.Columns.Add("Nivel")
        DT.Columns.Add("Año")
        DT.Columns.Add("Mes")
        DT.Columns.Add("IdPlaza")
        DT.Columns.Add("IdSucursal")
        DT.Columns.Add("IdDivision")
        NivelAct = "DIVISION"
        AgregaRegistroDTEstado(NivelAct, cbo_Año.Text.Trim, cbo_Mes.Text.Trim.Substring(0, 2), 0, 0, 0)
    End Sub

    Private Sub AgregaRegistroDTEstado(Nivel As String, Año As String, Mes As String, IdPlaza As String, IdSucursal As String, IdDivision As String)
        DT.Rows.Add(Nivel, Año, Mes, IdPlaza, IdSucursal, IdDivision)
    End Sub
    Private Sub RellenaGrid()
        Dim objDataSet As DataSet
        If DT.Rows(DT.Rows.Count - 1).Item("año").ToString.Trim = GLB_FechaHoy.Year And CInt(DT.Rows(DT.Rows.Count - 1).Item("mes").ToString) = GLB_FechaHoy.Month Then
            If GLB_FechaHoy.Day < 5 Then
                gc_CatPresupuesto.DataSource = Nothing
                MessageBox.Show("Se requiere un minimo de 5 días de venta para ver el reporte", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        Using objPresupuesto As New BCL.BCLPresupuesto(GLB_ConStringDwhSQL)
            objDataSet = objPresupuesto.usp_TraerCatPresupuesto(DT.Rows(DT.Rows.Count - 1).Item("Nivel").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Año").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("Mes").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("IdPlaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("IdSucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("IdDivision").ToString.Trim)
        End Using
        gc_CatPresupuesto.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_CatPresupuesto.DataSource = objDataSet.Tables(0)
            dgv_CatPresupuesto.BestFitColumns()
            InicializaGrid()
        End If
    End Sub

    Private Sub TraerTexto()
        lbl_Texto.Text = ""
        lbl_TextoFecha.Text = ""
        lbl_Texto.Text = "NIVEL: " & NivelAct
        lbl_TextoFecha.Text = lbl_TextoFecha.Text & "MES: " & DT.Rows(DT.Rows.Count - 1).Item("mes").ToString.Trim & " - " & DT.Rows(DT.Rows.Count - 1).Item("año").ToString.Trim

    End Sub

    Private Sub InicializaGrid()
        TraerTexto()

        If NivelAct = "DIVISION" Then
            gc_Plaza.Visible = False
            gc_Sucursal.Visible = False
            gc_Division.Visible = True
        ElseIf NivelAct = "PLAZA" Then
            gc_Plaza.Visible = True
            gc_Sucursal.Visible = False
            gc_Division.Visible = True
        ElseIf NivelAct = "SUCURSAL" Then
            gc_Plaza.Visible = True
            gc_Sucursal.Visible = True
            gc_Division.Visible = True
        End If
    End Sub

    Private Function TraerSigNivel(ByVal NivelActual As String) As String
        TraerSigNivel = ""
        If NivelActual = "DIVISION" Then
            TraerSigNivel = "PLAZA"
        ElseIf NivelActual = "PLAZA" Then
            TraerSigNivel = "SUCURSAL"
        ElseIf NivelActual = "SUCURSAL" Then
            TraerSigNivel = ""

        Else
            TraerSigNivel = ""
        End If
    End Function

    Private Sub RellenaAño(AñoActual As Integer)
        For i As Integer = AñoActual - 1 To AñoActual + 1
            cbo_Año.Properties.Items.Add(i)
        Next
        cbo_Año.Text = AñoActual
    End Sub

    Private Function TraerMes(Mes As String) As String
        TraerMes = ""
        If Mes = "01" Then
            TraerMes = "01-Enero"
        ElseIf Mes = "02" Then
            TraerMes = "02-Febrero"
        ElseIf Mes = "03" Then
            TraerMes = "03-Marzo"
        ElseIf Mes = "04" Then
            TraerMes = "04-Abril"
        ElseIf Mes = "05" Then
            TraerMes = "05-Mayo"
        ElseIf Mes = "06" Then
            TraerMes = "06-Junio"
        ElseIf Mes = "07" Then
            TraerMes = "07-Julio"
        ElseIf Mes = "08" Then
            TraerMes = "08-Agosto"
        ElseIf Mes = "09" Then
            TraerMes = "09-Septiembre"
        ElseIf Mes = "10" Then
            TraerMes = "10-Octubre"
        ElseIf Mes = "11" Then
            TraerMes = "11-Noviembre"
        ElseIf Mes = "12" Then
            TraerMes = "12-Diciembre"
        End If
    End Function
#End Region

#Region "Eventos"
    Private Sub frmCatPresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbo_Mes.Text = pub_RellenarIzquierda(GLB_FechaHoy.Month, 2) & "-" & MonthName(GLB_FechaHoy.Month)
            RellenaAño(GLB_FechaHoy.Year)
            CreaDTEstado()
            RellenaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatPresupuesto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub dgv_CatPresupuesto_DoubleClick(sender As Object, e As EventArgs) Handles dgv_CatPresupuesto.DoubleClick
        Try
            If NivelAct = "SUCURSAL" Then Exit Sub
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                'MessageBox.Show(dgv_Reporte.GetRowCellValue(info.RowHandle, "estructura"))
                Dim IdDivision As String
                Dim IdPlaza As String
                Dim IdSucursal As String
                IdDivision = dgv_CatPresupuesto.GetRowCellValue(info.RowHandle, "iddivision").ToString.Trim
                IdPlaza = dgv_CatPresupuesto.GetRowCellValue(info.RowHandle, "idplaza").ToString.Trim
                IdSucursal = dgv_CatPresupuesto.GetRowCellValue(info.RowHandle, "idsucursal").ToString.Trim
                If NivelAct = "DIVISION" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("año").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("mes").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, IdDivision)
                ElseIf NivelAct = "PLAZA" Then
                    NivelAct = TraerSigNivel(NivelAct)
                    AgregaRegistroDTEstado(NivelAct, DT.Rows(DT.Rows.Count - 1).Item("año").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("mes").ToString.Trim, IdPlaza, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, IdDivision)
                End If
            End If
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Try
            If DT.Rows.Count = 1 Then
                MessageBox.Show("No puedes regresar, estas en el inicio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            blnBtnRegresar = True
            DT.Rows.Remove(DT.Rows(DT.Rows.Count - 1))
            NivelAct = DT.Rows(DT.Rows.Count - 1).Item("Nivel").ToString.Trim
            cbo_Año.Text = DT.Rows(DT.Rows.Count - 1).Item("año").ToString.Trim
            cbo_Mes.Text = TraerMes(DT.Rows(DT.Rows.Count - 1).Item("mes").ToString.Trim)
            RellenaGrid()
            blnBtnRegresar = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub cbo_Año_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Año.SelectedIndexChanged
        Try
            If blnBtnRegresar = True Then Exit Sub
            AgregaRegistroDTEstado(DT.Rows(DT.Rows.Count - 1).Item("nivel").ToString.Trim, cbo_Año.Text.Trim, DT.Rows(DT.Rows.Count - 1).Item("mes").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Mes.SelectedIndexChanged
        Try
            If blnBtnRegresar = True Then Exit Sub
            AgregaRegistroDTEstado(DT.Rows(DT.Rows.Count - 1).Item("nivel").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("año").ToString.Trim, cbo_Mes.Text.Trim.Substring(0, 2), DT.Rows(DT.Rows.Count - 1).Item("idplaza").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("idsucursal").ToString.Trim, DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dgv_CatPresupuesto_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles dgv_CatPresupuesto.RowCellStyle
        Try
            If e.RowHandle < 0 Then Exit Sub
            If dgv_CatPresupuesto.GetRowCellValue(e.RowHandle, "division").ToString.Trim = "TOTAL" Then
                e.Appearance.BackColor = Color.MediumAquamarine
                e.Appearance.BackColor2 = Color.MediumAquamarine
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dgv_CatPresupuesto_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles dgv_CatPresupuesto.CustomRowFilter
        Try
            If DT.Rows(DT.Rows.Count - 1).Item("iddivision").ToString.Trim = "0" Then Exit Sub
            Dim View As GridView = sender
            Dim dv As DataView = View.DataSource
            If dv(e.ListSourceRow).Item("division").ToString.Trim = "TOTAL" Then
                e.Visible = False
                e.Handled = True
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

End Class