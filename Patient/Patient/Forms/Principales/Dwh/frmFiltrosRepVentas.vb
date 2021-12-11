Imports System.ComponentModel
Imports DevExpress.XtraEditors

Public Class frmFiltrosRepVentas

    Public Sw_Cancelar As Boolean
    Public Sw_Filtro As Boolean
    Private objDataSet As DataSet
    Public IdPlaza As Integer
    Public IdSucursal As Integer

#Region "Metodos"

    Private Sub TraerDatosEstructura(ByVal Tipo As String, ByRef Clave As String, ByRef Id As Integer, ByRef Descrip As String)
        Dim objDataSet As DataSet
        Using objEstadistica As New BCL.BCLEstadisticaVentas(GLB_ConStringDwhSQL)
            objDataSet = objEstadistica.usp_TraerEstructuraClave(Tipo, Clave, Id)
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            Clave = objDataSet.Tables(0).Rows(0).Item("clave").ToString.Trim
            Id = objDataSet.Tables(0).Rows(0).Item("id").ToString.Trim
            Descrip = objDataSet.Tables(0).Rows(0).Item("descrip").ToString.Trim
        Else
            Dim myForm As New frmConsultaNivelEstructura
            myForm.Tipo = Tipo
            myForm.ShowDialog()
            If myForm.Filtro = True Then
                Clave = myForm.Clave
                Id = myForm.Id
                Descrip = myForm.Descrip
            Else
                Clave = ""
                Id = 0
                Descrip = ""
            End If
        End If
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextEdit, ByVal Txt_Campo1 As TextEdit, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:25 a.m.
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.ShowDialog()
                    Txt_Campo.Text = myForm.Campo
                    Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Public Sub TraerPlazas()
        Dim objDataSet As New DataSet
        Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
            objDataSet = objPromociones.usp_TraerPlazasSucursales("PLAZA", 0)
        End Using
        cbo_Plaza.Properties.DataSource = Nothing
        If objDataSet IsNot Nothing Then
            Dim Renglon As DataRow
            Renglon = objDataSet.Tables(0).NewRow
            Renglon.Item("idplaza") = 0
            Renglon.Item("plaza") = "00-TODAS"
            objDataSet.Tables(0).Rows.InsertAt(Renglon, 0)
            cbo_Plaza.Properties.DataSource = objDataSet.Tables(0)
            cbo_Plaza.Properties.DisplayMember = "plaza"
            cbo_Plaza.Properties.ValueMember = "idplaza"
            cbo_Plaza.Properties.PopulateColumns()
            cbo_Plaza.Properties.Columns("idplaza").Visible = False
            If IdPlaza <> 0 Then
                cbo_Plaza.EditValue = 0
                cbo_Plaza.EditValue = IdPlaza
            End If
        End If

        'cbo_Sucursal.Properties.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos"
    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        Try
            txt_Marca.Text = ""
            txt_Modelo.Text = ""
            txt_Agrupacion.Text = ""
            txt_descripAgru.Text = ""
            txt_DescripMarca.Text = ""
            txt_IdDivision.Text = ""
            txt_Division.Text = ""
            txt_DescripDivision.Text = ""
            txt_IdDepto.Text = ""
            txt_Depto.Text = ""
            txt_DescripDepto.Text = ""
            txt_IdFamilia.Text = ""
            txt_Familia.Text = ""
            txt_DescripFamilia.Text = ""
            txt_IdLinea.Text = ""
            txt_Linea.Text = ""
            txt_DescripLinea.Text = ""
            txt_IdL1.Text = ""
            txt_L1.Text = ""
            txt_DescripL1.Text = ""
            txt_IdL2.Text = ""
            txt_L2.Text = ""
            txt_DescripL2.Text = ""
            txt_IdL3.Text = ""
            txt_L3.Text = ""
            txt_DescripL3.Text = ""
            txt_IdL4.Text = ""
            txt_L4.Text = ""
            txt_DescripL4.Text = ""
            txt_IdL5.Text = ""
            txt_L5.Text = ""
            txt_DescripL5.Text = ""
            txt_IdL6.Text = ""
            txt_L6.Text = ""
            txt_DescripL6.Text = ""
            txt_IdAgrupacion.Text = ""
            txt_Agrupacion.Text = ""
            txt_descripAgru.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Try
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Try
            Sw_Filtro = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Marca_TextChanged(sender As Object, e As EventArgs) Handles txt_Marca.TextChanged
        Try
            If txt_Marca.Text.Length = 3 Then
                txt_Modelo.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Division_TextChanged(sender As Object, e As EventArgs) Handles txt_Division.TextChanged
        Try
            If txt_Division.Text.Length = 3 Then
                txt_Depto.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Depto_TextChanged(sender As Object, e As EventArgs) Handles txt_Depto.TextChanged
        Try
            If txt_Depto.Text.Length = 0 Then Exit Sub
            If txt_Depto.Text.Length = 3 Then
                txt_Familia.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Familia_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Familia.TextChanged
        Try
            If txt_Familia.Text.Length = 3 Then
                txt_Linea.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Linea.TextChanged
        Try
            If txt_Linea.Text.Length = 3 Then
                txt_L1.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L1.TextChanged
        Try
            If txt_L1.Text.Length = 3 Then
                txt_L2.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L2.TextChanged
        Try
            If txt_L2.Text.Length = 3 Then
                txt_L3.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L3.TextChanged
        Try
            If txt_L3.Text.Length = 3 Then
                txt_L4.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L4.TextChanged
        Try
            If txt_L4.Text.Length = 3 Then
                txt_L5.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L5.TextChanged
        Try
            If txt_L5.Text.Length = 3 Then
                txt_L6.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L6_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L6.TextChanged
        Try
            If txt_L6.Text.Length = 3 Then
                txt_Agrupacion.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Agrupacion_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Agrupacion.TextChanged
        Try
            If txt_Agrupacion.Text.Length = 3 Then
                btn_Aceptar.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Modelo_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Modelo.LostFocus
        Try
            If txt_Modelo.Text.Trim = "" Then Exit Sub
            txt_Modelo.Text = pub_RellenarEspaciosIzquierda(txt_Modelo.Text, 7)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Modelo.TextChanged
        Try
            If txt_Modelo.Text.Length = 7 Then
                txt_Division.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Division_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Division.LostFocus
        Try
            If txt_Division.Text.Trim = "" Then
                txt_DescripDivision.Text = ""
                txt_IdDivision.Text = ""
                Exit Sub
            End If
            If txt_Division.Text.Length < 3 Then
                txt_Division.Text = pub_RellenarIzquierda(txt_Division.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_Division.Text.Trim
            txt_Division.Text = ""
            TraerDatosEstructura("Division", Clave, Id, Descrip)
            txt_Division.Text = Clave
            txt_IdDivision.Text = Id
            txt_DescripDivision.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Depto_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Depto.LostFocus
        Try
            If txt_Depto.Text.Trim = "" Then
                txt_DescripDepto.Text = ""
                txt_IdDepto.Text = ""
                Exit Sub
            End If
            If txt_Depto.Text.Length < 3 Then
                txt_Depto.Text = pub_RellenarIzquierda(txt_Depto.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_Depto.Text.Trim
            txt_Depto.Text = ""
            TraerDatosEstructura("Depto", Clave, Id, Descrip)
            txt_Depto.Text = Clave
            txt_IdDepto.Text = Id
            txt_DescripDepto.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Familia_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Familia.LostFocus
        Try
            If txt_Familia.Text.Trim = "" Then
                txt_DescripFamilia.Text = ""
                txt_IdFamilia.Text = ""
                Exit Sub
            End If
            If txt_Familia.Text.Length < 3 Then
                txt_Familia.Text = pub_RellenarIzquierda(txt_Familia.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_Familia.Text.Trim
            txt_Familia.Text = ""
            TraerDatosEstructura("Familia", Clave, Id, Descrip)
            txt_Familia.Text = Clave
            txt_IdFamilia.Text = Id
            txt_DescripFamilia.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Linea.LostFocus
        Try
            If txt_Linea.Text.Trim = "" Then
                txt_DescripLinea.Text = ""
                txt_IdLinea.Text = ""
                Exit Sub
            End If
            If txt_Linea.Text.Length < 3 Then
                txt_Linea.Text = pub_RellenarIzquierda(txt_Linea.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_Linea.Text.Trim
            txt_Linea.Text = ""
            TraerDatosEstructura("Linea", Clave, Id, Descrip)
            txt_Linea.Text = Clave
            txt_IdLinea.Text = Id
            txt_DescripLinea.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L1.LostFocus
        Try
            If txt_L1.Text.Trim = "" Then
                txt_DescripL1.Text = ""
                txt_IdL1.Text = ""
                Exit Sub
            End If
            If txt_L1.Text.Length < 3 Then
                txt_L1.Text = pub_RellenarIzquierda(txt_L1.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_L1.Text.Trim
            txt_L1.Text = ""
            TraerDatosEstructura("L1", Clave, Id, Descrip)
            txt_L1.Text = Clave
            txt_IdL1.Text = Id
            txt_DescripL1.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L2.LostFocus
        Try
            If txt_L2.Text.Trim = "" Then
                txt_DescripL2.Text = ""
                txt_IdL2.Text = ""
                Exit Sub
            End If
            If txt_L2.Text.Length < 3 Then
                txt_L2.Text = pub_RellenarIzquierda(txt_L2.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_L2.Text.Trim
            txt_L2.Text = ""
            TraerDatosEstructura("L2", Clave, Id, Descrip)
            txt_L2.Text = Clave
            txt_IdL2.Text = Id
            txt_DescripL2.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L3_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L3.LostFocus
        Try
            If txt_L3.Text.Trim = "" Then
                txt_DescripL3.Text = ""
                txt_IdL3.Text = ""
                Exit Sub
            End If
            If txt_L3.Text.Length < 3 Then
                txt_L3.Text = pub_RellenarIzquierda(txt_L3.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_L3.Text.Trim
            txt_L3.Text = ""
            TraerDatosEstructura("L3", Clave, Id, Descrip)
            txt_L3.Text = Clave
            txt_IdL3.Text = Id
            txt_DescripL3.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L4.LostFocus
        Try
            If txt_L4.Text.Trim = "" Then
                txt_DescripL4.Text = ""
                txt_IdL4.Text = ""
                Exit Sub
            End If
            If txt_L4.Text.Length < 3 Then
                txt_L4.Text = pub_RellenarIzquierda(txt_L4.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_L4.Text.Trim
            txt_L4.Text = ""
            TraerDatosEstructura("L4", Clave, Id, Descrip)
            txt_L4.Text = Clave
            txt_IdL4.Text = Id
            txt_DescripL4.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L5_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L5.LostFocus
        Try
            If txt_L5.Text.Trim = "" Then
                txt_DescripL5.Text = ""
                txt_IdL5.Text = ""
                Exit Sub
            End If
            If txt_L5.Text.Length < 3 Then
                txt_L5.Text = pub_RellenarIzquierda(txt_L5.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_L5.Text.Trim
            txt_L5.Text = ""
            TraerDatosEstructura("L5", Clave, Id, Descrip)
            txt_L5.Text = Clave
            txt_IdL5.Text = Id
            txt_DescripL5.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L6_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_L6.LostFocus
        Try
            If txt_L6.Text.Trim = "" Then
                txt_DescripL6.Text = ""
                txt_IdL6.Text = ""
                Exit Sub
            End If
            If txt_L6.Text.Length < 3 Then
                txt_L6.Text = pub_RellenarIzquierda(txt_L6.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_L6.Text.Trim
            txt_L6.Text = ""
            TraerDatosEstructura("L6", Clave, Id, Descrip)
            txt_L6.Text = Clave
            txt_IdL6.Text = Id
            txt_DescripL6.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Agrupacion_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_Agrupacion.LostFocus
        Try
            If txt_Agrupacion.Text.Trim = "" Then
                txt_descripAgru.Text = ""
                txt_IdAgrupacion.Text = ""
                Exit Sub
            End If
            If txt_Agrupacion.Text.Length < 3 Then
                txt_Agrupacion.Text = pub_RellenarIzquierda(txt_Agrupacion.Text, 3)
            End If
            Dim Id As Integer
            Dim Descrip As String
            Dim Clave As String
            Id = 0
            Descrip = ""
            Clave = txt_Agrupacion.Text.Trim
            txt_Agrupacion.Text = ""
            TraerDatosEstructura("Agrupacion", Clave, Id, Descrip)
            txt_Agrupacion.Text = Clave
            txt_IdAgrupacion.Text = Id
            txt_descripAgru.Text = Descrip.Trim
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Plaza_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_Plaza.EditValueChanged
        Try
            If cbo_Plaza.EditValue.ToString = "" Or cbo_Plaza.EditValue.ToString = "0" Then
                cbo_Sucursal.Properties.DataSource = Nothing
                cbo_Sucursal.EditValue = ""
                Exit Sub
            End If
            Dim objDataSet As New DataSet
            Using objPromociones As New BCL.BCLPromociones(GLB_ConStringSirCoPVSQL)
                objDataSet = objPromociones.usp_TraerPlazasSucursales("SUCURSAL2", cbo_Plaza.EditValue)
            End Using
            cbo_Sucursal.EditValue = Nothing
            cbo_Sucursal.Properties.DataSource = Nothing
            If objDataSet IsNot Nothing Then
                Dim Renglon As DataRow
                Renglon = objDataSet.Tables(0).NewRow
                Renglon.Item("plaza") = cbo_Plaza.EditValue
                Renglon.Item("idsucursal") = 0
                Renglon.Item("sucursal") = "00"
                Renglon.Item("nomsucursal") = "00-TODAS"
                objDataSet.Tables(0).Rows.InsertAt(Renglon, 0)
                cbo_Sucursal.Properties.DataSource = objDataSet.Tables(0)
                cbo_Sucursal.Properties.DisplayMember = "nomsucursal"
                cbo_Sucursal.Properties.ValueMember = "idsucursal"
                cbo_Sucursal.Properties.PopulateColumns()
                cbo_Sucursal.Properties.Columns("plaza").Visible = False
                cbo_Sucursal.Properties.Columns("sucursal").Visible = False
                cbo_Sucursal.Properties.Columns("idsucursal").Visible = False

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmFiltrosRepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            TraerPlazas()
            If IdSucursal <> 0 Then
                cbo_Sucursal.EditValue = IdSucursal
            Else
                cbo_Sucursal.EditValue = 0
            End If
            If txt_IdDivision.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdDivision.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("Division", Clave, Id, Descrip)
                txt_Division.Text = Clave
                txt_IdDivision.Text = Id
                txt_DescripDivision.Text = Descrip.Trim
            End If
            If txt_IdDepto.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdDepto.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("Depto", Clave, Id, Descrip)
                txt_Depto.Text = Clave
                txt_IdDepto.Text = Id
                txt_DescripDepto.Text = Descrip.Trim
            End If
            If txt_IdFamilia.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdFamilia.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("Familia", Clave, Id, Descrip)
                txt_Familia.Text = Clave
                txt_IdFamilia.Text = Id
                txt_DescripFamilia.Text = Descrip.Trim
            End If
            If txt_IdLinea.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdLinea.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("Linea", Clave, Id, Descrip)
                txt_Linea.Text = Clave
                txt_IdLinea.Text = Id
                txt_DescripLinea.Text = Descrip.Trim
            End If
            If txt_IdL1.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdL1.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("L1", Clave, Id, Descrip)
                txt_L1.Text = Clave
                txt_IdL1.Text = Id
                txt_DescripL1.Text = Descrip.Trim
            End If
            If txt_IdL2.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdL2.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("L2", Clave, Id, Descrip)
                txt_L2.Text = Clave
                txt_IdL2.Text = Id
                txt_DescripL2.Text = Descrip.Trim
            End If
            If txt_IdL3.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdL3.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("L3", Clave, Id, Descrip)
                txt_L3.Text = Clave
                txt_IdL3.Text = Id
                txt_DescripL3.Text = Descrip.Trim
            End If
            If txt_IdL4.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdL4.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("L4", Clave, Id, Descrip)
                txt_L4.Text = Clave
                txt_IdL4.Text = Id
                txt_DescripL4.Text = Descrip.Trim
            End If
            If txt_IdL5.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdL5.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("L5", Clave, Id, Descrip)
                txt_L5.Text = Clave
                txt_IdL5.Text = Id
                txt_DescripL5.Text = Descrip.Trim
            End If
            If txt_IdL6.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdL6.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("L6", Clave, Id, Descrip)
                txt_L6.Text = Clave
                txt_IdL6.Text = Id
                txt_DescripL6.Text = Descrip.Trim
            End If
            If txt_IdAgrupacion.Text.Trim <> 0 Then
                Dim Id As Integer
                Dim Descrip As String
                Dim Clave As String
                Id = txt_IdAgrupacion.Text.Trim
                Descrip = ""
                Clave = ""
                TraerDatosEstructura("Agrupacion", Clave, Id, Descrip)
                txt_Agrupacion.Text = Clave
                txt_IdAgrupacion.Text = Id
                txt_descripAgru.Text = Descrip.Trim
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub txt_Marca_LostFocus(sender As Object, e As EventArgs) Handles txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If txt_Marca.Text.Length = 0 Then
                txt_DescripMarca.Text = ""
                Exit Sub
            End If
            Try
                'Get the specific project selected in the ListView control
                If txt_Marca.Text.Trim.Length < 3 Then
                    txt_Marca.Text = pub_RellenarIzquierda(txt_Marca.Text.Trim, 3)
                End If
                Call TxtLostfocus(txt_Marca, txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub frmFiltrosRepVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub dt_FecIni_Validating(sender As Object, e As CancelEventArgs) Handles dt_FecIni.Validating
        Try
            If dt_FecIni.EditValue > dt_FecFin.EditValue Then
                MessageBox.Show("La fecha inicial debe ser menor o igual que la fecha final", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub dt_FecFin_Validating(sender As Object, e As CancelEventArgs) Handles dt_FecFin.Validating
        Try
            If dt_FecIni.EditValue > dt_FecFin.EditValue Then
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha inicial", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
            If dt_FecFin.EditValue > GLB_FechaHoy Then
                MessageBox.Show("La fecha final debe ser menor o igual a la fecha actual", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


#End Region
End Class