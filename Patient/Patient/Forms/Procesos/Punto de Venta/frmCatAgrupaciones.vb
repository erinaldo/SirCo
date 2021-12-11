Imports System.Data.OleDb

Public Class frmCatAgrupaciones

    Private Accion As Integer '1 NUEVO, 2 MODIFICAR, 3 CONSULTAR


#Region "Metodos"
    Private Sub RellenaGrid()
        Dim objDataSet As Data.DataSet
        Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                gc_Agrupaciones.DataSource = Nothing
                objDataSet = objAgrupaciones.usp_TraerAgrupaciones(0, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    gc_Agrupaciones.DataSource = objDataSet.Tables(0)
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

    Private Sub Limpiar()
        txt_Agrupacion.Text = ""
        txt_FUM.Text = ""
        txt_IdUsuario.Text = ""
        txt_NombreAgrupacion.Text = ""
        dt_Fecha.EditValue = GLB_FechaHoy
        gc_AgrupacionesDet.DataSource = Nothing
    End Sub

    Private Sub InicializaGrid()

        dgv_Agrupaciones.Columns("idagrupacion").Caption = "IdAgrupación"
        dgv_Agrupaciones.Columns("nombre").Caption = "Nombre"
        dgv_Agrupaciones.Columns("fecha").Caption = "Fecha"
        dgv_Agrupaciones.Columns("idusuario").Caption = "Usuario"
        dgv_Agrupaciones.Columns("fum").Caption = "FUM"

        dgv_Agrupaciones.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"

        dgv_Agrupaciones.BestFitColumns()
    End Sub

    Private Sub HabilitaControles()
        btn_Nuevo.Enabled = False
        btn_Modificar.Enabled = False
        btn_Consultar.Enabled = False
        btn_Regresar.Enabled = False
        If Accion = 1 Then
            txt_NombreAgrupacion.ReadOnly = False
            dt_Fecha.ReadOnly = True
            'PanelControl3.Enabled = False
            btn_Guardar.Enabled = True
            btn_AgregarDet.Enabled = False
            btn_ModificarDet.Enabled = False
            btn_ConsultarDet.Enabled = False
            btn_EliminarDet.Enabled = False
            btn_Regresar.Enabled = True
            btn_Excel.Enabled = False
            Limpiar()
        ElseIf Accion = 2 Then
            txt_NombreAgrupacion.ReadOnly = False
            dt_Fecha.ReadOnly = True
            PanelControl3.Enabled = True
            btn_Guardar.Enabled = True
            btn_AgregarDet.Enabled = True
            btn_ModificarDet.Enabled = True
            btn_ConsultarDet.Enabled = True
            btn_EliminarDet.Enabled = True
            btn_Regresar.Enabled = True
            btn_Excel.Enabled = True
        ElseIf Accion = 3 Then
            txt_NombreAgrupacion.ReadOnly = True
            dt_Fecha.ReadOnly = True
            'PanelControl3.Enabled = True
            btn_Guardar.Enabled = False
            btn_AgregarDet.Enabled = False
            btn_ModificarDet.Enabled = False
            btn_ConsultarDet.Enabled = True
            btn_EliminarDet.Enabled = False
            btn_Regresar.Enabled = True
            btn_Excel.Enabled = False
        End If
    End Sub

    Private Sub TraerAgrupacion(Agrupacion As Integer)
        Dim objDataSet As DataSet
        Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            objDataSet = objAgrupaciones.usp_TraerAgrupaciones(Agrupacion, "")
            If objDataSet Is Nothing Then
                MessageBox.Show("No se encontro información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            txt_Agrupacion.Text = objDataSet.Tables(0).Rows(0).Item("idagrupacion").ToString.Trim
            txt_NombreAgrupacion.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString.Trim
            dt_Fecha.EditValue = CDate(objDataSet.Tables(0).Rows(0).Item("fecha").ToString.Trim)
            txt_IdUsuario.Text = objDataSet.Tables(0).Rows(0).Item("idusuario").ToString.Trim
            txt_FUM.Text = objDataSet.Tables(0).Rows(0).Item("fum").ToString.Trim
            objDataSet = New DataSet
            objDataSet = objAgrupaciones.usp_TraerAgrupacionesDet(Agrupacion, 0)
            If objDataSet IsNot Nothing Then
                gc_AgrupacionesDet.DataSource = objDataSet.Tables(0)
                InicializaGridDet()
            End If
        End Using

    End Sub

    Private Sub InicializaGridDet()
        dgv_AgrupacionesDet.BestFitColumns()
        dgv_AgrupacionesDet.Columns("idagrupacion").Visible = False
        dgv_AgrupacionesDet.Columns("iddivisiones").Visible = False
        dgv_AgrupacionesDet.Columns("iddepto").Visible = False
        dgv_AgrupacionesDet.Columns("idfamilia").Visible = False
        dgv_AgrupacionesDet.Columns("idlinea").Visible = False
        dgv_AgrupacionesDet.Columns("idl1").Visible = False
        dgv_AgrupacionesDet.Columns("idl2").Visible = False
        dgv_AgrupacionesDet.Columns("idl3").Visible = False
        dgv_AgrupacionesDet.Columns("idl4").Visible = False
        dgv_AgrupacionesDet.Columns("idl5").Visible = False
        dgv_AgrupacionesDet.Columns("idl6").Visible = False
        dgv_AgrupacionesDet.Columns("renglon").Visible = False

        dgv_AgrupacionesDet.Columns("division").Caption = "División"
        dgv_AgrupacionesDet.Columns("departamento").Caption = "Departamento"
        dgv_AgrupacionesDet.Columns("familia").Caption = "Familia"
        dgv_AgrupacionesDet.Columns("linea").Caption = "Linea"
        dgv_AgrupacionesDet.Columns("l1").Caption = "L1"
        dgv_AgrupacionesDet.Columns("l2").Caption = "L2"
        dgv_AgrupacionesDet.Columns("l3").Caption = "L3"
        dgv_AgrupacionesDet.Columns("l4").Caption = "L4"
        dgv_AgrupacionesDet.Columns("l5").Caption = "L5"
        dgv_AgrupacionesDet.Columns("l6").Caption = "L6"
        dgv_AgrupacionesDet.Columns("nivel").Caption = "Nivel"
        dgv_AgrupacionesDet.Columns("marca").Caption = "Marca"
        dgv_AgrupacionesDet.Columns("estilon").Caption = "Modelo"
        dgv_AgrupacionesDet.Columns("idusuario").Caption = "Usuario"
        dgv_AgrupacionesDet.Columns("fum").Caption = "FUM"

        dgv_AgrupacionesDet.Columns("fum").DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
    End Sub


#End Region

#Region "Eventos"
    Private Sub frmCatAgrupaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Accion = 0
            RellenaGrid()
            tc_Agrupaciones.SelectedTabPageIndex = 0
            tc_Agrupaciones.TabPages(0).PageEnabled = True
            tc_Agrupaciones.TabPages(1).PageEnabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim blnTransaccion As Boolean
            Dim objDataSet As DataSet
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                If txt_NombreAgrupacion.Text.Trim = "" Then
                    MessageBox.Show("Debes ingresar un nombre", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txt_NombreAgrupacion.Focus()
                    Exit Sub
                End If
                If Accion = 1 Then
                    objDataSet = objAgrupaciones.usp_CapturaAgrupacion(txt_NombreAgrupacion.Text.Trim, CDate(dt_Fecha.EditValue).ToString("yyyy-MM-dd"), GLB_Usuario)
                    If objDataSet.Tables(0).Rows.Count < 0 Then
                        MessageBox.Show("No se pudo almacenar la agrupación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    txt_Agrupacion.Text = objDataSet.Tables(0).Rows(0).Item("idagrupacion").ToString.Trim
                    MessageBox.Show("Agrupación almacenada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Accion = 2
                    HabilitaControles()
                ElseIf Accion = 2 Then
                    blnTransaccion = objAgrupaciones.usp_ModificaAgrupacion(txt_Agrupacion.Text.Trim, txt_NombreAgrupacion.Text.Trim, GLB_Usuario)
                    If blnTransaccion = False Then
                        MessageBox.Show("No se pudo modificar la agrupación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    MessageBox.Show("Agrupación modificada correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            tc_Agrupaciones.SelectedTabPageIndex = 1
            tc_Agrupaciones.TabPages(0).PageEnabled = False
            tc_Agrupaciones.TabPages(1).PageEnabled = True
            txt_NombreAgrupacion.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            Dim objDataSet As DataSet
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                objDataSet = objAgrupaciones.usp_BuscaAgrupacionPromoActiva(CInt(dgv_Agrupaciones.GetRowCellValue(dgv_Agrupaciones.FocusedRowHandle, "idagrupacion")))
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Dim Promociones As String = ""
                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    Promociones = Promociones & objDataSet.Tables(0).Rows(i).Item("idpromocion").ToString.Trim & "-" & objDataSet.Tables(0).Rows(i).Item("nombre").ToString.Trim & vbCrLf
                Next
                MessageBox.Show("La agrupación que deseas modificar ya se encuentra en una o varias promociones activas, no se puede modificar " & vbCrLf & Promociones, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Accion = 2
            HabilitaControles()
            TraerAgrupacion(dgv_Agrupaciones.GetRowCellValue(dgv_Agrupaciones.FocusedRowHandle, "idagrupacion"))
            tc_Agrupaciones.SelectedTabPageIndex = 1
            tc_Agrupaciones.TabPages(0).PageEnabled = False
            tc_Agrupaciones.TabPages(1).PageEnabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Consultar_Click(sender As Object, e As EventArgs) Handles btn_Consultar.Click
        Try
            Accion = 3
            HabilitaControles()
            TraerAgrupacion(dgv_Agrupaciones.GetRowCellValue(dgv_Agrupaciones.FocusedRowHandle, "idagrupacion"))
            tc_Agrupaciones.SelectedTabPageIndex = 1
            tc_Agrupaciones.TabPages(0).PageEnabled = False
            tc_Agrupaciones.TabPages(1).PageEnabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_AgregarDet_Click(sender As Object, e As EventArgs) Handles btn_AgregarDet.Click
        Try
            Dim myFormAgrupDet As New frmCatAgrupacionesDet
            myFormAgrupDet.IdAgrupacion = CInt(txt_Agrupacion.Text.Trim)
            myFormAgrupDet.Accion = 1
            myFormAgrupDet.ShowDialog()
            TraerAgrupacion(CInt(txt_Agrupacion.Text.Trim))
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_ModificarDet_Click(sender As Object, e As EventArgs) Handles btn_ModificarDet.Click
        Try
            If dgv_AgrupacionesDet.RowCount = 0 Then
                MessageBox.Show("No hay registros para modificar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim myFormAgrupDet As New frmCatAgrupacionesDet
            myFormAgrupDet.IdAgrupacion = CInt(txt_Agrupacion.Text.Trim)
            myFormAgrupDet.Accion = 2
            myFormAgrupDet.Renglon = dgv_AgrupacionesDet.GetRowCellValue(dgv_AgrupacionesDet.FocusedRowHandle, "renglon")
            myFormAgrupDet.ShowDialog()
            TraerAgrupacion(CInt(txt_Agrupacion.Text.Trim))
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_ConsultarDet_Click(sender As Object, e As EventArgs) Handles btn_ConsultarDet.Click
        Try
            If dgv_AgrupacionesDet.RowCount = 0 Then
                MessageBox.Show("No hay registros para consultar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim myFormAgrupDet As New frmCatAgrupacionesDet
            myFormAgrupDet.IdAgrupacion = CInt(txt_Agrupacion.Text.Trim)
            myFormAgrupDet.Accion = 3
            myFormAgrupDet.Renglon = dgv_AgrupacionesDet.GetRowCellValue(dgv_AgrupacionesDet.FocusedRowHandle, "renglon")
            myFormAgrupDet.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_EliminarDet_Click(sender As Object, e As EventArgs) Handles btn_EliminarDet.Click
        Try
            If dgv_AgrupacionesDet.RowCount = 0 Then
                MessageBox.Show("No hay registros para eliminar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas eliminar el registro seleccionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim blnTransaccion As Boolean
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                blnTransaccion = objAgrupaciones.usp_EliminaAgrupacionDet(CInt(txt_Agrupacion.Text.Trim), CInt(dgv_AgrupacionesDet.GetRowCellValue(dgv_AgrupacionesDet.FocusedRowHandle, "renglon")))
            End Using
            MessageBox.Show("Registro eliminado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerAgrupacion(CInt(txt_Agrupacion.Text.Trim))
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Regresar_Click(sender As Object, e As EventArgs) Handles btn_Regresar.Click
        Try
            Accion = 0
            RellenaGrid()
            Limpiar()
            tc_Agrupaciones.SelectedTabPageIndex = 0
            tc_Agrupaciones.TabPages(0).PageEnabled = True
            tc_Agrupaciones.TabPages(1).PageEnabled = False
            btn_Nuevo.Enabled = True
            btn_Modificar.Enabled = True
            btn_Consultar.Enabled = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        Try
            If MessageBox.Show("Para cargar el excel, es necesario que la hoja contenga la Marca y el Modelo en las 2 primeras columnas y contenga datos a partir del segundo renglon, el primer renglon debe ir con la leyenda marca y modelo en la primer y segunda columna respectivamente, deseas continuar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim stRuta As String = ""
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Seleccionar archivos"
                .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx"
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    stRuta = .FileName
                End If
            End With
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            cnConex.Close()
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            Dim blnTransaccion As Boolean
            'VALIDA QUE NO SE REPITAN LOS MODELOS EN EL MISMO ARCHIVO
            For i As Integer = 0 To Dt.Rows.Count - 1
                For j As Integer = 0 To Dt.Rows.Count - 1
                    If i = j Then Continue For
                    If Dt.Rows(i).Item(0).ToString.Trim = Dt.Rows(j).Item(0).ToString.Trim And Dt.Rows(i).Item(1).ToString.Trim = Dt.Rows(j).Item(1).ToString.Trim Then
                        MessageBox.Show("El modelo " & Dt.Rows(i).Item(0).ToString.Trim & "-" & Dt.Rows(i).Item(1).ToString.Trim & " se encuentra dos o mas veces en el archivo excel, modificalo y vuelve a ingresar el Excel", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next
            Next
            'REVISA QUE NO SE ENCUENTRE ALMACENADO EN LA BD EL MODELO QUE SE ENCUENTRA EN EL EXCEL PARA ESA AGRUPACION
            Dim objDataSet As DataSet
            For i As Integer = 0 To Dt.Rows.Count - 1
                If Dt.Rows(i).Item(0).ToString.Trim = "" Or Dt.Rows(i).Item(1).ToString.Trim = "" Then
                    MessageBox.Show("En cada renglon del Excel debe contener datos en la Marca y Modelo, modifica el archivo y vuelve a ingresar el Excel", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                    objDataSet = objAgrupaciones.usp_BuscaAgrupacionDet(CInt(txt_Agrupacion.Text), "Modelo", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Dt.Rows(i).Item(0).ToString.Trim, Dt.Rows(i).Item(1).ToString)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    MessageBox.Show("El modelo " & Dt.Rows(i).Item(0).ToString.Trim & "-" & Dt.Rows(i).Item(1).ToString.Trim & " ya se encuentra almacenado para la agrupación seleccionada, modifica el archivo y vuelve a ingresar el Excel", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            'SI NO HAY REPETIDOS LOS INSERTA
            For i As Integer = 0 To Dt.Rows.Count - 1
                Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                    blnTransaccion = objAgrupaciones.usp_CapturaAgrupacionDet(CInt(txt_Agrupacion.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Dt.Rows(i).Item(0).ToString.Trim, pub_RellenarEspaciosIzquierda(Dt.Rows(i).Item(1).ToString.Trim, 7), "Modelo", GLB_Usuario)
                End Using
            Next
            MessageBox.Show("Archivo excel guardado correctamente en la agrupación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TraerAgrupacion(CInt(txt_Agrupacion.Text.Trim))
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub



#End Region



End Class