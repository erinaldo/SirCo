Public Class frmPromocionesPlazas

    Public IdPromocion As Integer

#Region "Metodos"
    Private Sub TraerPlazas()
        Dim objDataSet As New DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPlazasSucursales("PLAZA", 0)
        End Using
        cbo_Plaza.Properties.DataSource = Nothing
        If objDataSet IsNot Nothing Then
            cbo_Plaza.Properties.DataSource = objDataSet.Tables(0)
            cbo_Plaza.Properties.DisplayMember = "plaza"
            cbo_Plaza.Properties.ValueMember = "idplaza"
            cbo_Plaza.Properties.PopulateColumns()
            cbo_Plaza.Properties.Columns("idplaza").Visible = False
        End If

        cbo_Sucursal.Properties.DataSource = Nothing
    End Sub

    Private Sub TraerPromocionesPlazas()
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionesPlazas(IdPromocion, "", "")
        End Using
        gc_Plazas.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Plazas.DataSource = objDataSet.Tables(0)
            InicializaGridPlazas
        End If
    End Sub

    Private Sub InicializaGridPlazas()
        dgv_Plazas.BestFitColumns()
        dgv_Plazas.Columns("idpromocion").Visible = False
        dgv_Plazas.Columns("plaza").Visible = False
        dgv_Plazas.Columns("sucursal").Visible = False

        dgv_Plazas.Columns("nomplaza").Caption = "Plaza"
        dgv_Plazas.Columns("nomsucursal").Caption = "Sucursal"
        dgv_Plazas.Columns("idusuario").Caption = "Usuario"
        dgv_Plazas.Columns("fum").Caption = "FUM"

        dgv_Plazas.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
    End Sub

#End Region

#Region "Eventos"
    Private Sub frmPromocionesPlazas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TraerPlazas()
            TraerPromocionesPlazas()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Plaza_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_Plaza.EditValueChanged
        Try
            If cbo_Plaza.EditValue.ToString = "" Then
                cbo_Sucursal.Properties.DataSource = Nothing
                cbo_Sucursal.EditValue = ""
                Exit Sub
            End If
            Dim objDataSet As New DataSet
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                objDataSet = objPromociones.usp_TraerPlazasSucursales("SUCURSAL", cbo_Plaza.EditValue)
            End Using
            cbo_Sucursal.EditValue = ""
            cbo_Sucursal.Properties.DataSource = Nothing
            If objDataSet IsNot Nothing Then
                cbo_Sucursal.Properties.DataSource = objDataSet.Tables(0)
                cbo_Sucursal.Properties.DisplayMember = "nomsucursal"
                cbo_Sucursal.Properties.ValueMember = "sucursal"
                cbo_Sucursal.Properties.PopulateColumns()
                cbo_Sucursal.Properties.Columns("plaza").Visible = False
                cbo_Sucursal.Properties.Columns("sucursal").Visible = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim blnTransaccion As Boolean
            Dim Plaza As String
            Dim Sucursal As String
            If cbo_Plaza.Text = "Seleccione" Or cbo_Plaza.Text.Trim = "" Then
                MessageBox.Show("Por favor selecciona una plaza", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cbo_Plaza.Focus()
                Exit Sub
            End If
            Plaza = cbo_Plaza.Text.Trim.Substring(0, 2)
            If cbo_Sucursal.Text.Trim = "Seleccione" Then
                Sucursal = ""
            Else
                Sucursal = cbo_Sucursal.EditValue
            End If
            If Sucursal.Trim = "" Then
                For i As Integer = 0 To dgv_Plazas.RowCount - 1
                    If Plaza = dgv_Plazas.GetRowCellValue(i, "plaza").ToString.Trim Then
                        MessageBox.Show("La plaza ya se encuentra almacenada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next
            Else
                For i As Integer = 0 To dgv_Plazas.RowCount - 1
                    If Plaza = dgv_Plazas.GetRowCellValue(i, "plaza").ToString.Trim And dgv_Plazas.GetRowCellValue(i, "sucursal").ToString.Trim = "" Then
                        MessageBox.Show("La plaza ya se encuentra almacenada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    If Plaza = dgv_Plazas.GetRowCellValue(i, "plaza").ToString.Trim And dgv_Plazas.GetRowCellValue(i, "sucursal").ToString.Trim = Sucursal.Trim Then
                        MessageBox.Show("La plaza y sucursal ya se encuentra almacenada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next
            End If
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_CapturaPromocionesPlazas(IdPromocion, Plaza, Sucursal, GLB_Usuario)
            End Using
            MessageBox.Show("Se almaceno la plaza y/o la sucursal correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)

            TraerPromocionesPlazas()
            cbo_Plaza.Properties.DataSource = Nothing
            cbo_Sucursal.Properties.DataSource = Nothing
            cbo_Plaza.EditValue = ""
            cbo_Sucursal.EditValue = ""
            TraerPlazas()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        Try
            If dgv_Plazas.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas eliminar la plaza/sucursal seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_EliminaPromocionesPlaza(IdPromocion, dgv_Plazas.GetRowCellValue(dgv_Plazas.FocusedRowHandle, "plaza"), dgv_Plazas.GetRowCellValue(dgv_Plazas.FocusedRowHandle, "sucursal"))
            End Using
            MessageBox.Show("Se elimino la plaza/sucursal correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerPromocionesPlazas()
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