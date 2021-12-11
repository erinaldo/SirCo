Imports System.Drawing.Imaging
Imports System.IO

Public Class frmCatPromociones

    Public Accion As Integer

#Region "Metodos"

    Private Sub Limpiar()
        rb_Directa.Checked = True
        txt_IdPromocion.Text = ""
        txt_Nombre.Text = ""
        cbo_Estatus.Text = "CAPTURA"
        cbo_Clasificacion.Text = "REBAJA"
        dt_VigenciaIni.EditValue = GLB_FechaHoy
        dt_VigenciaFin.EditValue = GLB_FechaHoy
        txt_UniPromo.Text = 0
        txt_UniMin.Text = 0
        txt_ImpMinimo.Text = 0
        chk_Acumulable.Checked = False
        chk_ClientesNoRegistrados.Checked = False
        chk_ParesUnicos.Checked = False
        pb_Imagen.EditValue = Nothing
        gc_Agrupaciones.DataSource = Nothing
        gc_Unidades.DataSource = Nothing
        gc_Restriccion.DataSource = Nothing
        lv_Cupones.Items.Clear()
        lv_Exclusiones.Items.Clear()
        lv_Plazas.Items.Clear()
        lv_Recurrencia.Items.Clear()
    End Sub

    Private Sub HabilitaControles()
        btn_Nuevo.Enabled = False
        btn_Modificar.Enabled = False
        btn_Consultar.Enabled = False
        btn_Activar.Enabled = False
        btn_Cancelar.Enabled = False
        btn_Pausar.Enabled = False
        If Accion = 1 Then
            gb_TipoPromocion.Enabled = True
            txt_Nombre.ReadOnly = False
            cbo_Clasificacion.ReadOnly = False
            cbo_Señalizador.ReadOnly = False
            cbo_Preciero.ReadOnly = False
            dt_VigenciaIni.ReadOnly = False
            dt_VigenciaFin.ReadOnly = False
            txt_UniPromo.ReadOnly = False
            txt_UniMin.ReadOnly = False
            txt_ImpMinimo.ReadOnly = False
            gb_Cupones.Enabled = False
            gb_Exclusiones.Enabled = False
            gb_Recurrencia.Enabled = False
            gb_Plazas.Enabled = False
            gb_Agrupaciones.Enabled = False
            btn_Configurar.Enabled = False
            btn_Guardar.Enabled = True
            chk_Acumulable.Enabled = True
            chk_ClientesNoRegistrados.Enabled = True
            chk_ParesUnicos.Enabled = True
            btn_AgregarRestriccion.Enabled = True
            btn_EliminarRestriccion.Enabled = True
            btn_AumentaPrioridad.Enabled = True
            btn_DisminuyePrioridad.Enabled = True
        End If
        If Accion = 2 Then
            gb_TipoPromocion.Enabled = False
            txt_Nombre.ReadOnly = False
            cbo_Clasificacion.ReadOnly = False
            cbo_Señalizador.ReadOnly = False
            cbo_Preciero.ReadOnly = False
            dt_VigenciaIni.ReadOnly = False
            dt_VigenciaFin.ReadOnly = False
            txt_UniPromo.ReadOnly = True
            txt_UniMin.ReadOnly = True
            txt_ImpMinimo.ReadOnly = True
            gb_Cupones.Enabled = True
            gb_Exclusiones.Enabled = True
            gb_Recurrencia.Enabled = True
            gb_Plazas.Enabled = True
            gb_Agrupaciones.Enabled = True
            btn_Configurar.Enabled = True
            btn_Guardar.Enabled = True
            chk_Acumulable.Enabled = True
            chk_ClientesNoRegistrados.Enabled = True
            chk_ParesUnicos.Enabled = True
            btn_AgregarRestriccion.Enabled = True
            btn_EliminarRestriccion.Enabled = True
            btn_AumentaPrioridad.Enabled = True
            btn_DisminuyePrioridad.Enabled = True
        End If
        If Accion = 3 Then
            gb_TipoPromocion.Enabled = False
            txt_Nombre.ReadOnly = True
            cbo_Clasificacion.ReadOnly = True
            cbo_Señalizador.ReadOnly = True
            cbo_Preciero.ReadOnly = True
            dt_VigenciaIni.ReadOnly = True
            dt_VigenciaFin.ReadOnly = True
            txt_UniPromo.ReadOnly = True
            txt_UniMin.ReadOnly = True
            txt_ImpMinimo.ReadOnly = True
            gb_Cupones.Enabled = False
            gb_Exclusiones.Enabled = False
            gb_Recurrencia.Enabled = False
            gb_Plazas.Enabled = False
            gb_Agrupaciones.Enabled = False
            btn_Configurar.Enabled = True
            btn_Guardar.Enabled = False
            chk_Acumulable.Enabled = False
            chk_ClientesNoRegistrados.Enabled = False
            chk_ParesUnicos.Enabled = False
            btn_AgregarRestriccion.Enabled = False
            btn_EliminarRestriccion.Enabled = False
            btn_AumentaPrioridad.Enabled = False
            btn_DisminuyePrioridad.Enabled = False
        End If
    End Sub

    Private Sub TraerPromocion(ByVal IdPromocion As Integer)
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocion(IdPromocion, "")
            If objDataSet Is Nothing Then
                MessageBox.Show("No se encontro información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            txt_IdPromocion.Text = objDataSet.Tables(0).Rows(0).Item("idpromocion").ToString.Trim
            txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString.Trim
            rb_AxB.Checked = IIf(objDataSet.Tables(0).Rows(0).Item("tipo").ToString.Trim = "AxB", True, False)
            rb_Directa.Checked = IIf(objDataSet.Tables(0).Rows(0).Item("tipo").ToString.Trim = "DIRECTA", True, False)
            cbo_Estatus.Text = objDataSet.Tables(0).Rows(0).Item("estatus").ToString.Trim
            cbo_Clasificacion.Text = objDataSet.Tables(0).Rows(0).Item("clasificacion").ToString.Trim
            txt_UniMin.Text = objDataSet.Tables(0).Rows(0).Item("minunicompra").ToString.Trim
            txt_ImpMinimo.Text = objDataSet.Tables(0).Rows(0).Item("minimpcompra").ToString.Trim
            txt_UniPromo.Text = objDataSet.Tables(0).Rows(0).Item("unipromo").ToString.Trim
            cbo_Preciero.EditValue = objDataSet.Tables(0).Rows(0).Item("preciero").ToString.Trim
            cbo_Señalizador.EditValue = objDataSet.Tables(0).Rows(0).Item("senalizador").ToString.Trim
            If IsDBNull(objDataSet.Tables(0).Rows(0).Item("imagen")) Then
                pb_Imagen.EditValue = Nothing
            Else
                pb_Imagen.EditValue = objDataSet.Tables(0).Rows(0).Item("imagen")
            End If
            dt_VigenciaIni.EditValue = CDate(objDataSet.Tables(0).Rows(0).Item("iniciopromo").ToString.Trim)
            dt_VigenciaFin.EditValue = CDate(objDataSet.Tables(0).Rows(0).Item("finpromo").ToString.Trim)
            chk_Acumulable.Checked = IIf(objDataSet.Tables(0).Rows(0).Item("acumulable").ToString.Trim = "SI", True, False)
            chk_ParesUnicos.Checked = IIf(objDataSet.Tables(0).Rows(0).Item("paresunicos").ToString.Trim = "SI", True, False)
            chk_ClientesNoRegistrados.Checked = IIf(objDataSet.Tables(0).Rows(0).Item("clinoregis").ToString.Trim = "SI", True, False)
            RellenaGridAgrupacion(IdPromocion)
            RellenaGridUnidades()
            TraerCuponesPromocion()
            TraerPromocionesRecurrencia()
            TraerPromocionesExclusiones()
            TraerPromocionesPlazas()
            TraerPromocionesRestricciones()
        End Using
    End Sub

    Private Sub RellenaGrid()
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocion(0, "")
        End Using
        gc_Promociones.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Promociones.DataSource = objDataSet.Tables(0)
            InicializaGridPromociones()
        Else
            MessageBox.Show("No se encontraron registros que cumplan con los requisitos del filtro. Intente nuevamente.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub InicializaGridPromociones()
        dgv_Promociones.BestFitColumns()
        dgv_Promociones.Columns("idpromocion").Visible = False
        dgv_Promociones.Columns("imagen").Visible = False
        dgv_Promociones.Columns("minunicompra").Visible = False
        dgv_Promociones.Columns("minimpcompra").Visible = False
        dgv_Promociones.Columns("unipromo").Visible = False
        dgv_Promociones.Columns("preciero").Visible = False
        dgv_Promociones.Columns("senalizador").Visible = False
        dgv_Promociones.Columns("clasificacion").Visible = False
        dgv_Promociones.Columns("acumulable").Visible = False
        dgv_Promociones.Columns("paresunicos").Visible = False
        dgv_Promociones.Columns("clinoregis").Visible = False

        dgv_Promociones.Columns("nombre").Caption = "Nombre"
        dgv_Promociones.Columns("fecha").Caption = "Fecha"
        dgv_Promociones.Columns("tipo").Caption = "Tipo"
        dgv_Promociones.Columns("estatus").Caption = "Estatus"
        dgv_Promociones.Columns("iniciopromo").Caption = "Inicio"
        dgv_Promociones.Columns("finpromo").Caption = "Fin"
        dgv_Promociones.Columns("idusuariocaptura").Caption = "Captura"
        dgv_Promociones.Columns("fumcaptura").Caption = "FumCap"
        dgv_Promociones.Columns("idusuarioaplica").Caption = "Aplica"
        dgv_Promociones.Columns("fumaplica").Caption = "FumApl"
        dgv_Promociones.Columns("idusuariopausa").Caption = "Pausa"
        dgv_Promociones.Columns("fumpausa").Caption = "FumPau"
        dgv_Promociones.Columns("idusuariocancela").Caption = "Cancela"
        dgv_Promociones.Columns("fumcancela").Caption = "FumCan"
        dgv_Promociones.Columns("idusuario").Caption = "Usuario"
        dgv_Promociones.Columns("fum").Caption = "FUM"

        dgv_Promociones.Columns("iniciopromo").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Promociones.Columns("finpromo").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Promociones.Columns("fumcaptura").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Promociones.Columns("fumaplica").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Promociones.Columns("fumpausa").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Promociones.Columns("fumcancela").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        dgv_Promociones.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"

    End Sub

    Private Sub RellenaGridAgrupacion(IdPromocion As Integer)
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionAgrupacion(IdPromocion)
        End Using
        gc_Agrupaciones.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Agrupaciones.DataSource = objDataSet.Tables(0)
        End If
    End Sub

    Private Sub RellenaGridUnidades()
        Dim objDataSet As DataSet
        Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromocion.usp_TraerPromocionDet(CInt(txt_IdPromocion.Text.Trim), 0, "AGRUPADO", "")
        End Using
        gc_Unidades.DataSource = objDataSet.Tables(0)
        InicializaGridAgrupaciones()
    End Sub

    Private Sub InicializaGridAgrupaciones()
        dgv_Unidades.Columns("idpromocion").Visible = False

        dgv_Unidades.Columns("numunidad").Caption = "Num Unidad"
        dgv_Unidades.Columns("tipo").Caption = "Tipo"
    End Sub

    Private Function ValidaDatos() As Boolean
        ValidaDatos = False
        If rb_Directa.Checked = True Then
            If CInt(txt_UniPromo.Text) <> 0 Then
                MessageBox.Show("Las unidades de promoción debe ser 0, ya que incluye a todas las unidades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If
        ElseIf rb_AxB.Checked = True Then
            If CInt(txt_UniMin.Text) = 0 Or CInt(txt_UniPromo.Text) = 0 Then
                MessageBox.Show("Debes indicar un minimo de unidades de compra y un numero de unidades de promoción", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Function
            End If
        End If
        ValidaDatos = True
    End Function

    Private Sub GuardaPromocionesDet()
        Dim blnTransaccion As Boolean
        If rb_Directa.Checked = True Then
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_CapturaPromocionDet(CInt(txt_IdPromocion.Text), "TO", 0, "PROMO", 0, 0, 0, 0, GLB_Usuario)
            End Using
        ElseIf rb_AxB.Checked = True Then
            For i As Integer = 1 To CInt(txt_UniMin.Text)
                Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                    blnTransaccion = objPromociones.usp_CapturaPromocionDet(CInt(txt_IdPromocion.Text), "TO", i, "COMPRA", 0, 0, 0, 0, GLB_Usuario)
                End Using
            Next
            For i As Integer = CInt(txt_UniMin.Text) + 1 To CInt(txt_UniMin.Text) + CInt(txt_UniPromo.Text)
                Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                    blnTransaccion = objPromociones.usp_CapturaPromocionDet(CInt(txt_IdPromocion.Text), "TO", i, "PROMO", 0, 0, 0, 0, GLB_Usuario)
                End Using
            Next
        End If
    End Sub

    Private Sub TraerSeñalizador(ByRef ComboBox As DevExpress.XtraEditors.LookUpEdit)
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerSeñalizador(0, "")
            ComboBox.Properties.DataSource = Nothing
            If objDataSet.Tables(0).Rows.Count > 0 Then
                ComboBox.Properties.DataSource = objDataSet.Tables(0)
                ComboBox.Properties.DisplayMember = "senalizador"
                ComboBox.Properties.ValueMember = "senalizador"
                ComboBox.Properties.PopulateColumns()
            End If
        End Using
    End Sub

    Private Sub TraerTipoPreciero(ByRef ComboBox As DevExpress.XtraEditors.LookUpEdit)
        Dim objDataSet As DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerTipoPerciero(0, "")
            ComboBox.Properties.DataSource = Nothing
            If objDataSet.Tables(0).Rows.Count > 0 Then
                ComboBox.Properties.DataSource = objDataSet.Tables(0)
                ComboBox.Properties.DisplayMember = "tipopreciero"
                ComboBox.Properties.ValueMember = "tipopreciero"
                ComboBox.Properties.PopulateColumns()
            End If
        End Using
    End Sub

    Private Sub TraerCuponesPromocion()
        Dim objDataSet As New DataSet
        lv_Cupones.Items.Clear()
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerCuponesPromocion(CInt(txt_IdPromocion.Text), "AGREGADOS")
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                lv_Cupones.Items.Add(objDataSet.Tables(0).Rows(i).Item("nombre").ToString.Trim)
            Next
        End Using
    End Sub

    Private Sub TraerPromocionesRecurrencia()
        Dim objDataSet As New DataSet
        lv_Recurrencia.Items.Clear()
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionRecurrencia(CInt(txt_IdPromocion.Text), "", "", "")
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                lv_Recurrencia.Items.Add(objDataSet.Tables(0).Rows(i).Item("dia").ToString.Trim & ":" & objDataSet.Tables(0).Rows(i).Item("horainicio").ToString.Trim & "-" & objDataSet.Tables(0).Rows(i).Item("horafin").ToString.Trim)
            Next
        End Using
    End Sub

    Private Sub TraerPromocionesExclusiones()
        Dim objDataSet As New DataSet
        lv_Exclusiones.Items.Clear()
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionesExclusiones(CInt(txt_IdPromocion.Text))
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                lv_Exclusiones.Items.Add(objDataSet.Tables(0).Rows(i).Item("marca").ToString.Trim & "-" & objDataSet.Tables(0).Rows(i).Item("estilon").ToString.Trim)
            Next
        End Using
    End Sub

    Private Sub TraerPromocionesPlazas()
        Dim objDataSet As New DataSet
        lv_Plazas.Items.Clear()
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionesPlazas(CInt(txt_IdPromocion.Text), "", "")
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                lv_Plazas.Items.Add(objDataSet.Tables(0).Rows(i).Item("nomplaza").ToString.Trim & "-" & objDataSet.Tables(0).Rows(i).Item("nomsucursal").ToString.Trim)
            Next
        End Using
    End Sub

    Private Sub TraerPromocionesRestricciones()
        Dim objDataSet As New DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPromocionesRestricciones(CInt(txt_IdPromocion.Text), "Promocion")
        End Using
        gc_Restriccion.DataSource = Nothing
        If objDataSet.Tables(0).Rows.Count > 0 Then
            gc_Restriccion.DataSource = objDataSet.Tables(0)
            dgv_Restriccion.BestFitColumns()
        End If
    End Sub
#End Region


#Region "Eventos"
    Private Sub frmCatPromociones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tc_Promociones.SelectedTabPageIndex = 0
            tc_Promociones.TabPages(0).PageEnabled = True
            tc_Promociones.TabPages(1).PageEnabled = False
            Accion = 0
            RellenaGrid()
            TraerSeñalizador(cbo_Señalizador)
            TraerTipoPreciero(cbo_Preciero)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim blnTransaccion As Boolean
            Dim objDataSet As DataSet
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                If txt_Nombre.Text.Trim = "" Then
                    MessageBox.Show("Debes ingresar un nombre", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_Nombre.Focus()
                    Exit Sub
                End If
                If CDate(dt_VigenciaIni.EditValue) < CDate(GLB_FechaHoy) Then
                    MessageBox.Show("La fecha inicial debe ser superior o igual al día actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt_VigenciaIni.Focus()
                    Exit Sub
                End If
                If CDate(dt_VigenciaFin.EditValue) < CDate(dt_VigenciaIni.EditValue) Then
                    MessageBox.Show("La fecha final debe ser mayor a la fecha inicial", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt_VigenciaFin.Focus()
                    Exit Sub
                End If
                If cbo_Preciero.Text.Trim = "Seleccione" Then
                    MessageBox.Show("Debes ingresar un preciero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cbo_Preciero.Focus()
                    Exit Sub
                End If
                If cbo_Señalizador.Text.Trim = "Seleccione" Then
                    MessageBox.Show("Debes ingresar un señalizador", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cbo_Señalizador.Focus()
                    Exit Sub
                End If
                If Accion = 1 Then
                    If ValidaDatos() = False Then Exit Sub
                    objDataSet = objPromociones.usp_CapturaPromocion(txt_Nombre.Text.Trim, IIf(rb_Directa.Checked = True, "DIRECTA", "AxB"), CDate(dt_VigenciaIni.EditValue), CDate(dt_VigenciaFin.EditValue), cbo_Preciero.EditValue, cbo_Señalizador.EditValue, cbo_Clasificacion.Text.Trim, CInt(txt_UniMin.Text), CDec(txt_ImpMinimo.Text), CInt(txt_UniPromo.Text), IIf(chk_Acumulable.Checked = True, "SI", "NO"), IIf(chk_ParesUnicos.Checked = True, "SI", "NO"), IIf(chk_ClientesNoRegistrados.Checked = True, "SI", "NO"), GLB_Usuario, pb_Imagen.EditValue)
                    If objDataSet.Tables(0).Rows.Count < 0 Then
                        MessageBox.Show("No se pudo almacenar la promoción", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    txt_IdPromocion.Text = objDataSet.Tables(0).Rows(0).Item("idpromocion").ToString.Trim
                    GuardaPromocionesDet()
                    MessageBox.Show("Promoción almacenada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Accion = 2
                    HabilitaControles()
                    RellenaGridUnidades()
                ElseIf Accion = 2 Then
                    blnTransaccion = objPromociones.usp_ModificaPromocion(CInt(txt_IdPromocion.Text), txt_Nombre.Text.Trim, "", dt_VigenciaIni.EditValue, dt_VigenciaFin.EditValue, cbo_Preciero.EditValue, cbo_Señalizador.EditValue, cbo_Clasificacion.Text.Trim, CInt(txt_UniMin.Text), CDec(txt_ImpMinimo.Text), CInt(txt_UniPromo.Text), IIf(chk_Acumulable.Checked = True, "SI", "NO"), IIf(chk_ParesUnicos.Checked = True, "SI", "NO"), IIf(chk_ClientesNoRegistrados.Checked = True, "SI", "NO"), GLB_Usuario, pb_Imagen.EditValue)
                    If blnTransaccion = False Then
                        MessageBox.Show("No se pudo modificar la agrupación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    MessageBox.Show("Promoción modificada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Limpiar()
            tc_Promociones.SelectedTabPageIndex = 1
            tc_Promociones.TabPages(0).PageEnabled = False
            tc_Promociones.TabPages(1).PageEnabled = True
            txt_Nombre.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            If dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "estatus").ToString.Trim <> "CAPTURA" Then
                MessageBox.Show("Solo se pueden modificar cupones en estatus CAPTURA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Accion = 2
            TraerPromocion(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion"))
            HabilitaControles()
            tc_Promociones.SelectedTabPageIndex = 1
            tc_Promociones.TabPages(0).PageEnabled = False
            tc_Promociones.TabPages(1).PageEnabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Consultar_Click(sender As Object, e As EventArgs) Handles btn_Consultar.Click
        Try
            Accion = 3
            TraerPromocion(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion"))
            HabilitaControles()
            tc_Promociones.SelectedTabPageIndex = 1
            tc_Promociones.TabPages(0).PageEnabled = False
            tc_Promociones.TabPages(1).PageEnabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Activar_Click(sender As Object, e As EventArgs) Handles btn_Activar.Click
        Try
            If Not (dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "estatus").ToString.Trim = "CAPTURA" Or dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "estatus").ToString.Trim = "EN PAUSA") Then
                MessageBox.Show("Solo se pueden activar promociones en estatus CAPTURA o EN PAUSA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CDate(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "finpromo").ToString.Trim) < CDate(GLB_FechaHoy) Then
                MessageBox.Show("No puedes activar una promoción cuya vigencia termino", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim objDataSet As DataSet
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                objDataSet = objPromociones.usp_TraerPromocionAgrupacion(CInt(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion").ToString.Trim))
            End Using
            If objDataSet.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("La promoción seleccionada no tiene agrupaciones agregadas, no se puede activar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                objDataSet = objPromociones.usp_TraerPromocionesPlazas(CInt(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion").ToString.Trim), "", "")
            End Using
            If objDataSet.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("La promoción selecionada no tiene plazas o sucursales agreagadas, no se puede activar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If MessageBox.Show("Estas seguro que deseas ACTIVAR la promoción seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim blnTransaccion As Boolean
            Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromocion.usp_ModificaPromocion(CInt(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion").ToString.Trim), "", "ACTIVO", "1900-01-01", "1900-01-01", "", "", "", 0, 0, 0, "", "", "", GLB_Usuario, Nothing)
            End Using
            MessageBox.Show("Promoción activada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            If dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "estatus").ToString.Trim = "CANCELADO" Then
                MessageBox.Show("La promoción ya se encuentra cancelada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CDate(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "finpromo").ToString.Trim) < CDate(GLB_FechaHoy) Then
                MessageBox.Show("No puedes cancelar una promoción cuya vigencia termino", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas CANCELAR la promoción seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromocion.usp_ModificaPromocion(CInt(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion").ToString.Trim), "", "CANCELADO", "1900-01-01", "1900-01-01", "", "", "", 0, 0, 0, "", "", "", GLB_Usuario, Nothing)
            End Using
            MessageBox.Show("Promoción CANCELADA correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Pausar_Click(sender As Object, e As EventArgs) Handles btn_Pausar.Click
        Try
            If Not (dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "estatus").ToString.Trim = "ACTIVO") Then
                MessageBox.Show("Solo se pueden pausar promociones en estatus ACTIVO", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CDate(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "finpromo").ToString.Trim) < CDate(GLB_FechaHoy) Then
                MessageBox.Show("No puedes pausar una promoción cuya vigencia termino", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas PAUSAR la promoción seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim blnTransaccion As Boolean
            Using objPromocion As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromocion.usp_ModificaPromocion(CInt(dgv_Promociones.GetRowCellValue(dgv_Promociones.FocusedRowHandle, "idpromocion").ToString.Trim), "", "EN PAUSA", "1900-01-01", "1900-01-01", "", "", "", 0, 0, 0, "", "", "", GLB_Usuario, Nothing)
            End Using
            MessageBox.Show("La promoción se ha puesto EN PAUSA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarAgrupacion_Click(sender As Object, e As EventArgs) Handles btn_AgregarAgrupacion.Click
        Try
            Dim myForm As New frmPromocionesAgrupaciones
            myForm.IdPromocion = CInt(txt_IdPromocion.Text)
            myForm.TipoPromo = IIf(rb_Directa.Checked = True, "DIRECTA", "AxB")
            myForm.ShowDialog()
            RellenaGridAgrupacion(CInt(txt_IdPromocion.Text))
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_EliminarAgrupacion_Click(sender As Object, e As EventArgs) Handles btn_EliminarAgrupacion.Click
        Try
            If dgv_Agrupaciones.RowCount = 0 Then
                MessageBox.Show("Debes seleccionar un registro para eliminarlo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas eliminar el renglon seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objPromociones.usp_EliminaPromocionAgrupacion(CInt(txt_IdPromocion.Text), CInt(dgv_Agrupaciones.GetRowCellValue(dgv_Agrupaciones.FocusedRowHandle, "renglon")))
            End Using
            MessageBox.Show("Se elimino el renglon correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            RellenaGridAgrupacion(CInt(txt_IdPromocion.Text))
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Try
            Accion = 0
            RellenaGrid()
            tc_Promociones.SelectedTabPageIndex = 0
            tc_Promociones.TabPages(0).PageEnabled = True
            tc_Promociones.TabPages(1).PageEnabled = False
            Limpiar()
            btn_Nuevo.Enabled = True
            btn_Modificar.Enabled = True
            btn_Consultar.Enabled = True
            btn_Activar.Enabled = True
            btn_Cancelar.Enabled = True
            btn_Pausar.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Configurar_Click(sender As Object, e As EventArgs) Handles btn_Configurar.Click
        Try
            If dgv_Promociones.RowCount = 0 Then
                MessageBox.Show("No se encontraron registros para configurar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim myFormProDet As New frmPromocionesDet
            myFormProDet.IdPromocion = CInt(txt_IdPromocion.Text.Trim)
            myFormProDet.NomPromocion = txt_Nombre.Text.Trim
            myFormProDet.TipoPromo = IIf(rb_Directa.Checked = True, "DIRECTA", "AxB")
            myFormProDet.NumUnidad = CInt(dgv_Unidades.GetRowCellValue(dgv_Unidades.FocusedRowHandle, "numunidad").ToString.Trim)
            myFormProDet.Tipo = dgv_Unidades.GetRowCellValue(dgv_Unidades.FocusedRowHandle, "tipo").ToString.Trim
            If Accion = 3 Then
                myFormProDet.Accion = 3
            Else
                myFormProDet.Accion = 0
            End If
            myFormProDet.ShowDialog()
            RellenaGridUnidades()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarCupon_Click(sender As Object, e As EventArgs) Handles btn_AgregarCupon.Click
        Try
            Dim myForm As New frmPromocionesCupones
            myForm.IdPromocion = CInt(txt_IdPromocion.Text.Trim)
            myForm.ShowDialog()
            TraerCuponesPromocion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarRecurrencia_Click(sender As Object, e As EventArgs) Handles btn_AgregarRecurrencia.Click
        Try
            Dim myForm As New frmPromocionesRecurrencia
            myForm.IdPromocion = CInt(txt_IdPromocion.Text.Trim)
            myForm.ShowDialog()
            TraerPromocionesRecurrencia()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarExclusiones_Click(sender As Object, e As EventArgs) Handles btn_AgregarExclusiones.Click
        Try
            Dim myForm As New frmPromocionesExclusiones
            myForm.IdPromocion = CInt(txt_IdPromocion.Text.Trim)
            myForm.ShowDialog()
            TraerPromocionesExclusiones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarPlazas_Click(sender As Object, e As EventArgs) Handles btn_AgregarPlazas.Click
        Try
            Dim myForm As New frmPromocionesPlazas
            myForm.IdPromocion = CInt(txt_IdPromocion.Text.Trim)
            myForm.ShowDialog()
            TraerPromocionesPlazas()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub rb_Directa_CheckedChanged(sender As Object, e As EventArgs) Handles rb_Directa.CheckedChanged
        Try
            If rb_Directa.Checked = True Then
                txt_UniPromo.Text = 0
                txt_UniPromo.ReadOnly = True
            Else
                txt_UniPromo.ReadOnly = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_UniMin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_UniMin.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_ImpMinimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ImpMinimo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txt_UniPromo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_UniPromo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btn_AgregarRestriccion_Click(sender As Object, e As EventArgs) Handles btn_AgregarRestriccion.Click
        Try
            Dim myForm As New frmRestricciones
            myForm.Tipo = "Promocion"
            myForm.Id = CInt(txt_IdPromocion.Text)
            myForm.Prioridad = IIf(dgv_Restriccion.RowCount = 0, 1, CInt(dgv_Restriccion.GetRowCellValue(dgv_Restriccion.RowCount - 1, "prioridad")) + 1)
            myForm.ShowDialog()
            TraerPromocionesRestricciones()
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
                blnTransaccion = objPromociones.usp_ModificaPrioridad(CInt(txt_IdPromocion.Text), "Promocion", Orden, "AUMENTA", GLB_Usuario)
            End Using
            TraerPromocionesRestricciones()
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
                blnTransaccion = objPromociones.usp_ModificaPrioridad(CInt(txt_IdPromocion.Text), "Promocion", Orden, "DISMINUYE", GLB_Usuario)
            End Using
            TraerPromocionesRestricciones()
            dgv_Restriccion.FocusedRowHandle = RenglonActual + 1
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_EliminarRestriccion.Click
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
                blnTransaccion = objPromociones.usp_EliminaRestricciones(CInt(txt_IdPromocion.Text), "Promocion", Orden)
            End Using
            TraerPromocionesRestricciones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
#End Region
End Class