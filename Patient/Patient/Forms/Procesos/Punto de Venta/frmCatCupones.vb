Public Class frmCatCupones

    Dim Accion As Integer

#Region "METODOS"
    Private Sub RellenaGrid()
        Dim objDataSet As Data.DataSet
        Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                gc_Cupones.DataSource = Nothing
                objDataSet = objCupones.usp_TraerCupones(0, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    gc_Cupones.DataSource = objDataSet.Tables(0)
                    Call InicializaGrid()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                Me.Cursor = Cursors.Default
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub InicializaGrid()
        dgv_Cupones.BestFitColumns()
        dgv_Cupones.Columns("descripcion").Visible = False
        dgv_Cupones.Columns("restricciones").Visible = False
        dgv_Cupones.Columns("imagen").Visible = False

        dgv_Cupones.Columns("idcupon").Caption = "IdCupon"
        dgv_Cupones.Columns("nombre").Caption = "Nombre"
        dgv_Cupones.Columns("fecha").Caption = "Fecha"
        dgv_Cupones.Columns("estatus").Caption = "Estatus"
        dgv_Cupones.Columns("tipo").Caption = "Tipo"
        dgv_Cupones.Columns("fecini").Caption = "FecIni"
        dgv_Cupones.Columns("fecfin").Caption = "FecFin"
        dgv_Cupones.Columns("idusuariocaptura").Caption = "Captura"
        dgv_Cupones.Columns("fumcaptura").Caption = "FumCap"
        dgv_Cupones.Columns("idusuarioactiva").Caption = "Activa"
        dgv_Cupones.Columns("fumactiva").Caption = "FumAct"
        dgv_Cupones.Columns("idusuariocancela").Caption = "Cancela"
        dgv_Cupones.Columns("fumcancela").Caption = "FumCan"
        dgv_Cupones.Columns("idusuario").Caption = "Usuario"
        dgv_Cupones.Columns("fum").Caption = "FUM"

        dgv_Cupones.Columns("fumcaptura").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Cupones.Columns("fumactiva").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Cupones.Columns("fumcancela").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Cupones.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
    End Sub

    Private Sub RellenaGridDet()
        Dim objDataSet As DataSet
        Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
            objDataSet = objCupones.usp_TraerFolioCupon(CInt(txt_IdCupon.Text.Trim), "", "")
        End Using
        If objDataSet IsNot Nothing Then
            gc_CuponesDet.DataSource = objDataSet.Tables(0)
            InicializaGridDet()
        End If
    End Sub
    Private Sub InicializaGridDet()
        dgv_CuponesDet.Columns("idcupon").Visible = False
        dgv_CuponesDet.Columns("folio").Caption = "Folio"
        dgv_CuponesDet.Columns("estatus").Caption = "Estatus"
        dgv_CuponesDet.Columns("idusuario").Caption = "Usuario"
        dgv_CuponesDet.Columns("fum").Caption = "FUM"

        dgv_CuponesDet.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"

    End Sub

    Private Sub HabilitaControles()
        btn_Nuevo.Enabled = False
        btn_Modificar.Enabled = False
        btn_Consultar.Enabled = False
        btn_Regresar.Enabled = False
        btn_Activar.Enabled = False
        btn_Cancelar.Enabled = False
        If Accion = 1 Then
            txt_Nombre.ReadOnly = False
            dt_FecIni.ReadOnly = False
            dt_FecFin.ReadOnly = False
            txt_Descripcion.ReadOnly = False
            txt_Restricciones.ReadOnly = False
            cbo_Tipo.Enabled = True
            'PanelControl3.Enabled = False
            btn_Guardar.Enabled = True
            btn_AgregarDet.Enabled = False
            btn_EliminarDet.Enabled = False
            btn_Regresar.Enabled = True
            Limpiar()
            txt_Nombre.Focus()
            btn_AgregarRestriccion.Enabled = True
            btn_EliminarRestriccion.Enabled = True
            btn_AumentaPrioridad.Enabled = True
            btn_DisminuyePrioridad.Enabled = True
        ElseIf Accion = 2 Then
            txt_Nombre.ReadOnly = False
            dt_FecIni.ReadOnly = False
            dt_FecFin.ReadOnly = False
            txt_Descripcion.ReadOnly = False
            txt_Restricciones.ReadOnly = False
            cbo_Tipo.Enabled = True
            PanelControl3.Enabled = True
            btn_Guardar.Enabled = True
            btn_AgregarDet.Enabled = True
            btn_EliminarDet.Enabled = True
            btn_Regresar.Enabled = True
            btn_AgregarRestriccion.Enabled = True
            btn_EliminarRestriccion.Enabled = True
            btn_AumentaPrioridad.Enabled = True
            btn_DisminuyePrioridad.Enabled = True
        ElseIf Accion = 3 Then
            txt_Nombre.ReadOnly = True
            dt_FecIni.ReadOnly = True
            dt_FecFin.ReadOnly = True
            txt_Descripcion.ReadOnly = True
            txt_Restricciones.ReadOnly = True
            cbo_Tipo.Enabled = False
            'PanelControl3.Enabled = True
            btn_Guardar.Enabled = False
            btn_AgregarDet.Enabled = False
            btn_EliminarDet.Enabled = False
            btn_Regresar.Enabled = True
            btn_AgregarRestriccion.Enabled = False
            btn_EliminarRestriccion.Enabled = False
            btn_AumentaPrioridad.Enabled = False
            btn_DisminuyePrioridad.Enabled = False
        End If
    End Sub

    Private Sub Limpiar()
        txt_IdCupon.Text = ""
        txt_Descripcion.Text = ""
        txt_FUM.Text = ""
        txt_IdUsuario.Text = ""
        txt_Nombre.Text = ""
        txt_Restricciones.Text = ""
        gc_CuponesDet.DataSource = Nothing
        gc_Restriccion.DataSource = Nothing
        dt_FecIni.EditValue = GLB_FechaHoy
        dt_FecFin.EditValue = GLB_FechaHoy
        cbo_Tipo.Text = "UNICO"
        pb_Imagen.EditValue = Nothing
    End Sub

    Private Sub TraerCupon(Cupon As Integer)
        Dim objDataSet As DataSet
        Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
            objDataSet = objCupones.usp_TraerCupones(Cupon, "")
            If objDataSet Is Nothing Then
                MessageBox.Show("No se encontro información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            txt_IdCupon.Text = objDataSet.Tables(0).Rows(0).Item("idcupon").ToString.Trim
            txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString.Trim
            dt_FecIni.EditValue = CDate(objDataSet.Tables(0).Rows(0).Item("fecini").ToString.Trim)
            dt_FecFin.EditValue = CDate(objDataSet.Tables(0).Rows(0).Item("fecfin").ToString.Trim)
            txt_Descripcion.Text = objDataSet.Tables(0).Rows(0).Item("descripcion").ToString.Trim
            txt_Restricciones.Text = objDataSet.Tables(0).Rows(0).Item("restricciones").ToString.Trim
            cbo_Tipo.Text = objDataSet.Tables(0).Rows(0).Item("tipo").ToString.Trim
            If IsDBNull(objDataSet.Tables(0).Rows(0).Item("imagen")) Then
                pb_Imagen.EditValue = Nothing
            Else
                pb_Imagen.EditValue = objDataSet.Tables(0).Rows(0).Item("imagen")
            End If
            txt_IdUsuario.Text = objDataSet.Tables(0).Rows(0).Item("idusuario").ToString.Trim
            txt_FUM.Text = objDataSet.Tables(0).Rows(0).Item("fum").ToString.Trim
            RellenaGridDet()
            TraerCuponRestricciones()
        End Using

    End Sub

    Private Sub TraerCuponRestricciones()
        Dim objDataSet As New DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionesRestricciones(CInt(txt_IdCupon.Text), "Cupon")
        End Using
        gc_Restriccion.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Restriccion.DataSource = objDataSet.Tables(0)
            dgv_Restriccion.BestFitColumns()
        End If
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmCatCupones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tc_Cupones.SelectedTabPageIndex = 0
            tc_Cupones.TabPages(0).PageEnabled = True
            tc_Cupones.TabPages(1).PageEnabled = False
            Accion = 0
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim blnTransaccion As Boolean
            Dim objDataSet As DataSet
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                If txt_Nombre.Text.Trim = "" Then
                    MessageBox.Show("Debes ingresar un nombre", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_Nombre.Focus()
                    Exit Sub
                End If
                If CDate(dt_FecIni.EditValue) < CDate(GLB_FechaHoy) Then
                    MessageBox.Show("La fecha inicial debe ser superior o igual al día actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt_FecIni.Focus()
                    Exit Sub
                End If
                If CDate(dt_FecFin.EditValue) < CDate(dt_FecIni.EditValue) Then
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt_FecFin.Focus()
                    Exit Sub
                End If
                If txt_Descripcion.Text.Trim = "" Then
                    MessageBox.Show("Debes ingresar una descripción", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_Descripcion.Focus()
                    Exit Sub
                End If
                If txt_Restricciones.Text.Trim = "" Then
                    MessageBox.Show("Debes ingresar una restricción", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_Restricciones.Focus()
                    Exit Sub
                End If
                If Accion = 1 Then
                    objDataSet = objCupones.usp_CapturaCupon(txt_Nombre.Text.Trim, txt_Descripcion.Text.Trim, txt_Restricciones.Text.Trim, cbo_Tipo.Text.Trim, GLB_Usuario, CDate(dt_FecIni.EditValue).ToString("yyyy-MM-dd"), CDate(dt_FecFin.EditValue).ToString("yyyy-MM-dd"), pb_Imagen.EditValue)
                    If objDataSet.Tables(0).Rows.Count < 0 Then
                        MessageBox.Show("No se pudo almacenar la agrupación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    txt_IdCupon.Text = objDataSet.Tables(0).Rows(0).Item("idcupon").ToString.Trim
                    MessageBox.Show("Cupon almacenado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Accion = 2
                    HabilitaControles()
                ElseIf Accion = 2 Then
                    blnTransaccion = objCupones.usp_ModificaCupon(CInt(txt_IdCupon.Text.Trim), txt_Nombre.Text.Trim, txt_Descripcion.Text.Trim, txt_Restricciones.Text.Trim, "", cbo_Tipo.Text.Trim, GLB_Usuario, CDate(dt_FecIni.EditValue).ToString("yyyy-MM-dd"), CDate(dt_FecFin.EditValue).ToString("yyyy-MM-dd"), pb_Imagen.EditValue)
                    If blnTransaccion = False Then
                        MessageBox.Show("No se pudo modificar el cupón", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    MessageBox.Show("Cupon modificado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        Try
            Accion = 1
            HabilitaControles()
            tc_Cupones.SelectedTabPageIndex = 1
            tc_Cupones.TabPages(0).PageEnabled = False
            tc_Cupones.TabPages(1).PageEnabled = True
            txt_Nombre.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            If dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "estatus").ToString.Trim <> "CAPTURA" Then
                MessageBox.Show("Solo se pueden modificar cupones en estatus CAPTURA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Accion = 2
            HabilitaControles()
            TraerCupon(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "idcupon"))
            tc_Cupones.SelectedTabPageIndex = 1
            tc_Cupones.TabPages(0).PageEnabled = False
            tc_Cupones.TabPages(1).PageEnabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Consultar_Click(sender As Object, e As EventArgs) Handles btn_Consultar.Click
        Try
            Accion = 3
            HabilitaControles()
            TraerCupon(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "idcupon"))
            tc_Cupones.SelectedTabPageIndex = 1
            tc_Cupones.TabPages(0).PageEnabled = False
            tc_Cupones.TabPages(1).PageEnabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Try
            Accion = 0
            RellenaGrid()
            tc_Cupones.SelectedTabPageIndex = 0
            tc_Cupones.TabPages(0).PageEnabled = True
            tc_Cupones.TabPages(1).PageEnabled = False
            Limpiar()
            btn_Nuevo.Enabled = True
            btn_Modificar.Enabled = True
            btn_Consultar.Enabled = True
            btn_Activar.Enabled = True
            btn_Cancelar.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub btn_Activar_Click(sender As Object, e As EventArgs) Handles btn_Activar.Click
        Try
            If dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "estatus").ToString.Trim <> "CAPTURA" Then
                MessageBox.Show("Solo se pueden activar cupones en estatus CAPTURA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CDate(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "fecfin").ToString.Trim) < GLB_FechaHoy Then
                MessageBox.Show("No puedes activar un cupon que ya expiro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim objDataSet As DataSet
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                objDataSet = objCupones.usp_TraerFolioCupon(CInt(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "idcupon").ToString.Trim), "", "")
            End Using
            If objDataSet.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("No puedes activar un cupon que no tiene folios agregados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If MessageBox.Show("Estas seguro que deseas activar el cupón seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim blnTransaccion As Boolean
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objCupones.usp_ModificaCupon(CInt(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "idcupon").ToString.Trim), "", "", "", "ACTIVO", "", GLB_Usuario, "1900-01-01", "1900-01-01", Nothing)
            End Using
            MessageBox.Show("Cupón activado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            If dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "estatus").ToString.Trim = "CANCELADO" Then
                MessageBox.Show("El cupon ya fue cancelado con anterioridad", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CDate(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "fecfin").ToString.Trim) < GLB_FechaHoy Then
                MessageBox.Show("No puedes cancelar un cupon que ya expiro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim objDataSet As DataSet
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                objDataSet = objCupones.usp_BuscaCuponPromoActiva(CInt(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "idcupon")))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Dim Promociones As String = ""
                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    Promociones = Promociones & objDataSet.Tables(0).Rows(i).Item("idpromocion").ToString.Trim & "-" & objDataSet.Tables(0).Rows(i).Item("nombre").ToString.Trim & vbCrLf
                Next
                MessageBox.Show("El cupon que deseas cancelar ya se encuentra en una o varias promociones activas, no se puede cancelar " & vbCrLf & Promociones, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas cancelar el cupón seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim blnTransaccion As Boolean
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objCupones.usp_ModificaCupon(CInt(dgv_Cupones.GetRowCellValue(dgv_Cupones.FocusedRowHandle, "idcupon").ToString.Trim), "", "", "", "CANCELADO", "", GLB_Usuario, "1900-01-01", "1900-01-01", Nothing)
            End Using
            MessageBox.Show("Cupón cancelado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarDet_Click(sender As Object, e As EventArgs) Handles btn_AgregarDet.Click
        Try
            Dim myForm As New frmCuponesDet
            myForm.Tipo = cbo_Tipo.Text.Trim
            myForm.IdCupon = CInt(txt_IdCupon.Text.Trim)
            myForm.NombreCuponera = txt_Nombre.Text.Trim
            myForm.Accion = 1
            myForm.ShowDialog()
            RellenaGridDet()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_EliminarDet_Click(sender As Object, e As EventArgs) Handles btn_EliminarDet.Click
        Try
            If dgv_CuponesDet.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas eliminar el registro seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objCupones.usp_EliminaCuponesDet(CInt(txt_IdCupon.Text), dgv_CuponesDet.GetRowCellValue(dgv_CuponesDet.FocusedRowHandle, "folio").ToString.Trim)
            End Using
            MessageBox.Show("Folio eliminado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGridDet()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarRestriccion_Click(sender As Object, e As EventArgs) Handles btn_AgregarRestriccion.Click
        Try
            Dim myForm As New frmRestricciones
            myForm.Tipo = "Cupon"
            myForm.Id = CInt(txt_IdCupon.Text)
            myForm.Prioridad = IIf(dgv_Restriccion.RowCount = 0, 1, CInt(dgv_Restriccion.GetRowCellValue(dgv_Restriccion.RowCount - 1, "prioridad")) + 1)
            myForm.ShowDialog()
            TraerCuponRestricciones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AumentaPrioridad_Click(sender As Object, e As EventArgs) Handles btn_AumentaPrioridad.Click
        Try
            If dgv_Restriccion.RowCount = 0 Then
                MessageBox.Show("No existen registros para modificar la prioridad", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If dgv_Restriccion.SelectedRowsCount > 1 Then
                MessageBox.Show("Solo puedes modificar una restriccion a la vez", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim RenglonActual As Integer
            Dim Orden As Integer
            RenglonActual = dgv_Restriccion.FocusedRowHandle
            Orden = dgv_Restriccion.GetRowCellValue(RenglonActual, "prioridad")
            Orden = Orden - 1
            If Orden = 0 Then
                MessageBox.Show("La restricción ya es la prioridad maxima", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_ModificaPrioridad(CInt(txt_IdCupon.Text), "Cupon", Orden, "AUMENTA", GLB_Usuario)
            End Using
            TraerCuponRestricciones()
            dgv_Restriccion.FocusedRowHandle = RenglonActual - 1
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_DisminuyePrioridad_Click(sender As Object, e As EventArgs) Handles btn_DisminuyePrioridad.Click
        Try
            If dgv_Restriccion.RowCount = 0 Then
                MessageBox.Show("No existen registros para modificar la prioridad", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If dgv_Restriccion.SelectedRowsCount > 1 Then
                MessageBox.Show("Solo puedes modificar una restriccion a la vez", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim RenglonActual As Integer
            Dim Orden As Integer
            RenglonActual = dgv_Restriccion.FocusedRowHandle
            Orden = dgv_Restriccion.GetRowCellValue(RenglonActual, "prioridad")
            Orden = Orden + 1
            If Orden = dgv_Restriccion.GetRowCellValue(dgv_Restriccion.RowCount, "prioridad") Then
                MessageBox.Show("La restricción ya es la prioridad minima, no puedes disminuir mas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_ModificaPrioridad(CInt(txt_IdCupon.Text), "Cupon", Orden, "DISMINUYE", GLB_Usuario)
            End Using
            TraerCuponRestricciones()
            dgv_Restriccion.FocusedRowHandle = RenglonActual + 1
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_EliminarRestriccion_Click(sender As Object, e As EventArgs) Handles btn_EliminarRestriccion.Click
        Try
            If dgv_Restriccion.RowCount = 0 Then
                MessageBox.Show("No existen registros para eliminar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If dgv_Restriccion.SelectedRowsCount = 0 Then
                MessageBox.Show("Selecciona el registro a eliminar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim Orden As Integer
            Orden = dgv_Restriccion.GetRowCellValue(dgv_Restriccion.FocusedRowHandle, "prioridad")
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_EliminaRestricciones(CInt(txt_IdCupon.Text), "Cupon", Orden)
            End Using
            TraerCuponRestricciones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region
End Class