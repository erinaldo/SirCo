Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmPpalPresupuesto

    Private Col As Color

#Region "Metodos"

    Private Sub RellenaGrid()
        Dim objDataSet As DataSet
        Using objPresupuesto As New BCL.BCLPresupuesto(GLB_ConStringDwhSQL)
            objDataSet = objPresupuesto.usp_TraerPresupuesto("ANUAL", cbo_Año.Text.Trim, "")
        End Using
        gc_Presupuesto.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Presupuesto.DataSource = objDataSet.Tables(0)
            dgv_Presupuesto.BestFitColumns()
        End If
    End Sub

    Private Sub RellenaAño(AñoActual As Integer)
        For i As Integer = 2017 To AñoActual + 1
            cbo_Año.Properties.Items.Add(i)
        Next
        cbo_Año.Text = AñoActual
    End Sub

    Private Sub TraerPresupuestoMensual(Año As String, Mes As String)
        Dim objDataSet As DataSet
        Using objPresupuesto As New BCL.BCLPresupuesto(GLB_ConStringDwhSQL)
            objDataSet = objPresupuesto.usp_TraerPresupuesto("MENSUAL", Año, Mes)
        End Using
        gc_PresupuestoMensual.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_PresupuestoMensual.DataSource = objDataSet.Tables(0)
            dgv_PresupuestoMensual.BestFitColumns()
        End If
    End Sub

#End Region

#Region "Eventos"
    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Try
            Dim myForm As New frmPeriodoPresupuesto
            myForm.ShowDialog()
            If myForm.Filtro = False Then
                RellenaGrid()
            Else
                TraerPresupuestoMensual(myForm.cbo_Año.Text.Trim, myForm.cbo_Mes.Text.Trim)
                gc_PresupuestoCol.OptionsColumn.AllowEdit = True
                btn_GuardarPresupuesto.Enabled = True
                tc_Presupuesto.SelectedTabPageIndex = 1
                tc_Presupuesto.TabPages(0).PageEnabled = False
                tc_Presupuesto.TabPages(1).PageEnabled = True
                cbo_Año.Enabled = False
                btn_Nuevo.Enabled = False
                btn_Modificar.Enabled = False
                btn_Consultar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RellenaAño(GLB_FechaHoy.Year)
            RellenaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            TraerPresupuestoMensual(dgv_Presupuesto.GetRowCellValue(dgv_Presupuesto.FocusedRowHandle, "año").ToString.Trim, dgv_Presupuesto.GetRowCellValue(dgv_Presupuesto.FocusedRowHandle, "mes").ToString.Trim)
            gc_PresupuestoCol.OptionsColumn.AllowEdit = True
            btn_GuardarPresupuesto.Enabled = True
            tc_Presupuesto.SelectedTabPageIndex = 1
            tc_Presupuesto.TabPages(0).PageEnabled = False
            tc_Presupuesto.TabPages(1).PageEnabled = True
            cbo_Año.Enabled = False
            btn_Nuevo.Enabled = False
            btn_Modificar.Enabled = False
            btn_Consultar.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub frmPpalPresupuesto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btn_GuardarPresupuesto_Click(sender As Object, e As EventArgs) Handles btn_GuardarPresupuesto.Click
        Try
            If gc_PresupuestoCol.OptionsColumn.AllowEdit = False Then
                btn_Regresar_Click(sender, e)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas modificar el presupuesto del mes seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            For i As Integer = 0 To dgv_PresupuestoMensual.RowCount - 1
                Using objPresupuesto As New BCL.BCLPresupuesto(GLB_ConStringDwhSQL)
                    objPresupuesto.usp_ModificaPresupuesto(dgv_PresupuestoMensual.GetRowCellValue(i, "idsucursal").ToString.Trim, dgv_PresupuestoMensual.GetRowCellValue(i, "año").ToString.Trim, dgv_PresupuestoMensual.GetRowCellValue(i, "mes").ToString.Trim, dgv_PresupuestoMensual.GetRowCellValue(i, "iddivision").ToString.Trim, CDec(dgv_PresupuestoMensual.GetRowCellValue(i, "presupuesto").ToString.Trim), GLB_Usuario)
                End Using
            Next
            MessageBox.Show("Presupuesto modificado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btn_Regresar_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Try
            RellenaGrid()
            tc_Presupuesto.SelectedTabPageIndex = 0
            tc_Presupuesto.TabPages(0).PageEnabled = True
            tc_Presupuesto.TabPages(1).PageEnabled = False
            cbo_Año.Enabled = True
            gc_PresupuestoMensual.DataSource = Nothing
            btn_Nuevo.Enabled = True
            btn_Modificar.Enabled = True
            btn_Consultar.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Consultar_Click(sender As Object, e As EventArgs) Handles btn_Consultar.Click
        Try
            TraerPresupuestoMensual(dgv_Presupuesto.GetRowCellValue(dgv_Presupuesto.FocusedRowHandle, "año").ToString.Trim, dgv_Presupuesto.GetRowCellValue(dgv_Presupuesto.FocusedRowHandle, "mes").ToString.Trim)
            gc_PresupuestoCol.OptionsColumn.AllowEdit = False
            btn_GuardarPresupuesto.Enabled = False
            tc_Presupuesto.SelectedTabPageIndex = 1
            tc_Presupuesto.TabPages(0).PageEnabled = False
            tc_Presupuesto.TabPages(1).PageEnabled = True
            cbo_Año.Enabled = False
            btn_Nuevo.Enabled = False
            btn_Modificar.Enabled = False
            btn_Consultar.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Año_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Año.SelectedIndexChanged
        Try
            RellenaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    'Private Sub dgv_PresupuestoMensual_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles dgv_PresupuestoMensual.RowStyle
    '    Try
    '        If e.RowHandle = 0 Then
    '            Col = Color.MediumAquamarine
    '            e.Appearance.BackColor = Color.MediumAquamarine
    '            e.Appearance.BackColor2 = Color.MediumAquamarine
    '        ElseIf e.RowHandle > 0 Then
    '            If dgv_PresupuestoMensual.GetRowCellValue(e.RowHandle, "sucursal").ToString.Trim <> dgv_PresupuestoMensual.GetRowCellValue(e.RowHandle - 1, "sucursal").ToString.Trim Then
    '                    If Col = Color.MediumAquamarine Then
    '                        Col = Color.Gold
    '                    Else
    '                        Col = Color.MediumAquamarine
    '                    End If
    '                End If
    '                e.Appearance.BackColor = Col
    '                e.Appearance.BackColor2 = Col
    '            End If
    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub dgv_PresupuestoMensual_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles dgv_PresupuestoMensual.ValidatingEditor
        Try
            Dim view As ColumnView = sender
            Dim column As GridColumn = If(TryCast(e, EditFormValidateEditorEventArgs)?.Column, view.FocusedColumn)
            If column.Name = "gc_PresupuestoCol" Then
                If e.Value Is Nothing Then
                    e.Value = 0
                    Exit Sub
                End If
                If e.Value.ToString.Trim = "" Then
                    e.Value = 0
                End If
                If (Convert.ToInt32(e.Value) < 0) Then
                    e.Valid = False
                    e.ErrorText = "El importe debe ser mayor que cero"
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
End Class