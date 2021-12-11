Public Class frmPromocionesRecurrencia

    Public IdPromocion As Integer

#Region "Metodos"
    Private Sub TraerPromocionesRecurrencia(Dia As String, HoraIni As String, HoraFin As String)
        Dim objdataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objdataSet = objPromociones.usp_TraerPromocionRecurrencia(IdPromocion, Dia, HoraIni, HoraFin)
        End Using
        gc_Recurrencia.DataSource = Nothing
        If objdataSet.Tables(0).Rows.Count > 0 Then
            gc_Recurrencia.DataSource = objdataSet.Tables(0)
            InicializaGridRecurrencia()
        End If
    End Sub

    Private Sub InicializaGridRecurrencia()
        dgv_Recurrencia.BestFitColumns()
        dgv_Recurrencia.Columns("idpromocion").Visible = False

        dgv_Recurrencia.Columns("dia").Caption = "Día"
        dgv_Recurrencia.Columns("horainicio").Caption = "Inicio"
        dgv_Recurrencia.Columns("horafin").Caption = "Fin"
        dgv_Recurrencia.Columns("idusuario").Caption = "Usuario"
        dgv_Recurrencia.Columns("fum").Caption = "FUM"

        dgv_Recurrencia.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
    End Sub
#End Region

#Region "Eventos"
    Private Sub frmPromocionesRecurrencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TraerPromocionesRecurrencia("", "", "")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            If cbo_Dia.Text.Trim = "SELECCIONE" Then
                MessageBox.Show("Favor de seleccionar un dia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cbo_Dia.Focus()
                Exit Sub
            End If
            If txt_HInicio.Text.Trim > txt_HFin.Text.Trim Then
                MessageBox.Show("La hora de inicio debe ser menos a la hora final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim objdataSet As DataSet
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                objdataSet = objPromociones.usp_TraerPromocionRecurrencia(IdPromocion, cbo_Dia.Text.Trim, IIf(txt_HInicio.Text.Trim = "", "00:00", txt_HInicio.Text.Trim), IIf(txt_HFin.Text.Trim = "", "23:59", txt_HFin.Text.Trim))
            End Using
            If objdataSet.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("La recurrencia ingresada ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_CapturaPromocionRecurrencia(IdPromocion, cbo_Dia.Text.Trim, IIf(txt_HInicio.Text.Trim = "", "00:00", txt_HInicio.Text.Trim), IIf(txt_HFin.Text.Trim = "", "23:59", txt_HFin.Text.Trim), GLB_Usuario)
            End Using
            MessageBox.Show("Se almaceno la recurrencia correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbo_Dia.Text = "SELECCIONE"
            txt_HInicio.Text = "00:00"
            txt_HFin.Text = "23:59"
            TraerPromocionesRecurrencia("", "", "")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        Try
            If dgv_Recurrencia.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas eliminar la recurrencia seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_EliminaPromocionRecurrencia(IdPromocion, dgv_Recurrencia.GetRowCellValue(dgv_Recurrencia.FocusedRowHandle, "dia"), dgv_Recurrencia.GetRowCellValue(dgv_Recurrencia.FocusedRowHandle, "horainicio"))
            End Using
            MessageBox.Show("Se elimino la recurrencia correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerPromocionesRecurrencia("", "", "")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region
End Class