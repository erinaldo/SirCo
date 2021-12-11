Imports DevExpress.XtraEditors

Public Class frmCatAgrupacionesDet

    Public IdAgrupacion As Integer
    Public Renglon As Integer
    Public Accion As Integer '1 NUEVO, 2 MODIFICAR, 3 CONSULTAR

#Region "METODOS"

    Private Sub HabilitaControles()
        Dim blnEnable As Boolean
        blnEnable = IIf(Accion = 3, False, True)
        For Each c As Control In Me.Controls
            If TypeOf c Is DevExpress.XtraEditors.LookUpEdit Then
                c.Enabled = blnEnable
            End If
        Next
        cbo_Nivel.Enabled = blnEnable
        txt_Marca.Enabled = blnEnable
        txt_Estilon.Enabled = blnEnable
    End Sub

    Private Sub TraerEstructura(ByRef ComboBox As DevExpress.XtraEditors.LookUpEdit, Tipo As String)
        Dim objDataSet As DataSet
        Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            If Tipo = "División" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "iddivisiones"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                End If
            ElseIf Tipo = "Departamento" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "iddepto"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                End If
            ElseIf Tipo = "Familia" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idfamilia"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                End If
            ElseIf Tipo = "Linea" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idlinea"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                End If
            ElseIf Tipo = "L1" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idl1"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                    ComboBox.Properties.Columns("idl1").Visible = False
                End If
            ElseIf Tipo = "L2" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue, cbo_L1.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idl2"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                    ComboBox.Properties.Columns("idl1").Visible = False
                    ComboBox.Properties.Columns("idl2").Visible = False
                End If
            ElseIf Tipo = "L3" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue, cbo_L1.EditValue, cbo_L2.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idl3"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                    ComboBox.Properties.Columns("idl1").Visible = False
                    ComboBox.Properties.Columns("idl2").Visible = False
                    ComboBox.Properties.Columns("idl3").Visible = False
                End If
            ElseIf Tipo = "L4" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue, cbo_L1.EditValue, cbo_L2.EditValue, cbo_L3.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idl4"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                    ComboBox.Properties.Columns("idl1").Visible = False
                    ComboBox.Properties.Columns("idl2").Visible = False
                    ComboBox.Properties.Columns("idl3").Visible = False
                    ComboBox.Properties.Columns("idl4").Visible = False
                End If
            ElseIf Tipo = "L5" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue, cbo_L1.EditValue, cbo_L2.EditValue, cbo_L3.EditValue, cbo_L4.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idl5"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                    ComboBox.Properties.Columns("idl1").Visible = False
                    ComboBox.Properties.Columns("idl2").Visible = False
                    ComboBox.Properties.Columns("idl3").Visible = False
                    ComboBox.Properties.Columns("idl4").Visible = False
                    ComboBox.Properties.Columns("idl5").Visible = False
                End If
            ElseIf Tipo = "L6" Then
                objDataSet = objAgrupaciones.usp_TraerEstructura(Tipo.ToUpper, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue, cbo_L1.EditValue, cbo_L2.EditValue, cbo_L3.EditValue, cbo_L4.EditValue, cbo_L5.EditValue)
                ComboBox.Properties.DataSource = Nothing
                If objDataSet IsNot Nothing Then
                    ComboBox.Properties.DataSource = objDataSet.Tables(0)
                    ComboBox.Properties.DisplayMember = "descrip"
                    ComboBox.Properties.ValueMember = "idl6"
                    ComboBox.Properties.PopulateColumns()
                    ComboBox.Properties.Columns("iddivisiones").Visible = False
                    ComboBox.Properties.Columns("iddepto").Visible = False
                    ComboBox.Properties.Columns("idfamilia").Visible = False
                    ComboBox.Properties.Columns("idlinea").Visible = False
                    ComboBox.Properties.Columns("idl1").Visible = False
                    ComboBox.Properties.Columns("idl2").Visible = False
                    ComboBox.Properties.Columns("idl3").Visible = False
                    ComboBox.Properties.Columns("idl4").Visible = False
                    ComboBox.Properties.Columns("idl5").Visible = False
                    ComboBox.Properties.Columns("idl6").Visible = False
                End If
            End If
        End Using
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextEdit, ByVal Txt_Campo1 As TextEdit, ByVal Tipo As String)
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                Dim objDataSet As DataSet
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

    Private Function ExisteAgrupacion() As Boolean
        ExisteAgrupacion = False
        Dim objDataSet As DataSet
        Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            objDataSet = objAgrupaciones.usp_BuscaAgrupacionDet(IdAgrupacion, cbo_Nivel.Text.Trim, cbo_Division.EditValue, cbo_Departamento.EditValue, cbo_Familia.EditValue, cbo_Linea.EditValue, cbo_L1.EditValue, cbo_L2.EditValue, cbo_L3.EditValue, cbo_L4.EditValue, cbo_L5.EditValue, cbo_L6.EditValue, txt_Marca.Text.Trim, txt_Estilon.Text)
            If objDataSet.Tables(0).Rows.Count > 0 Then
                ExisteAgrupacion = True
            End If
        End Using

    End Function

    Private Function ValidaDatos() As Boolean
        ValidaDatos = False
        If cbo_Nivel.Text.Trim = "Seleccione" Then
            Exit Function
        End If
        If cbo_Division.Visible = True And (cbo_Division.EditValue Is Nothing Or cbo_Division.EditValue = 0) Then
            Exit Function
        End If
        If cbo_Departamento.Visible = True And (cbo_Departamento.EditValue Is Nothing Or cbo_Departamento.EditValue = 0) Then
            Exit Function
        End If
        If cbo_Familia.Visible = True And (cbo_Familia.EditValue Is Nothing Or cbo_Familia.EditValue = 0) Then
            Exit Function
        End If
        If cbo_Linea.Visible = True And (cbo_Linea.EditValue Is Nothing Or cbo_Linea.EditValue = 0) Then
            Exit Function
        End If
        If cbo_L1.Visible = True And (cbo_L1.EditValue Is Nothing Or cbo_L1.EditValue = 0) Then
            Exit Function
        End If
        If cbo_L2.Visible = True And (cbo_L2.EditValue Is Nothing Or cbo_L2.EditValue = 0) Then
            Exit Function
        End If
        If cbo_L3.Visible = True And (cbo_L3.EditValue Is Nothing Or cbo_L3.EditValue = 0) Then
            Exit Function
        End If
        If cbo_L4.Visible = True And (cbo_L4.EditValue Is Nothing Or cbo_L4.EditValue = 0) Then
            Exit Function
        End If
        If cbo_L5.Visible = True And (cbo_L5.EditValue Is Nothing Or cbo_L5.EditValue = 0) Then
            Exit Function
        End If
        If cbo_L6.Visible = True And (cbo_L6.EditValue Is Nothing Or cbo_L6.EditValue = 0) Then
            Exit Function
        End If
        If cbo_Nivel.Text.Trim = "Marca" And txt_Marca.Text.Trim = "" Then
            Exit Function
        End If
        If cbo_Nivel.Text.Trim = "Modelo" And (txt_Marca.Text.Trim = "" Or txt_Estilon.Text.Trim = "") Then
            Exit Function
        End If
        ValidaDatos = True
    End Function

    Private Function ValidaModificacion() As Boolean
        ValidaModificacion = False
        Dim objDataSet As DataSet
        Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
            objDataSet = objAgrupaciones.usp_TraerAgrupacionesDet(IdAgrupacion, Renglon)
            If objDataSet.Tables(0).Rows.Count > 0 Then
                If cbo_Nivel.Text.Trim <> objDataSet.Tables(0).Rows(0).Item("nivel").ToString.Trim Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_Division.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_Departamento.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("iddepto").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_Familia.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_Linea.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idlinea").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_L1.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idl1").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_L2.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idl2").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_L3.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idl3").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_L4.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idl4").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_L5.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idl5").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If cbo_L6.EditValue <> CInt(objDataSet.Tables(0).Rows(0).Item("idl6").ToString.Trim) Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If txt_Marca.Text <> objDataSet.Tables(0).Rows(0).Item("marca").ToString.Trim Then
                    ValidaModificacion = True
                    Exit Function
                End If
                If txt_Estilon.Text.Trim <> objDataSet.Tables(0).Rows(0).Item("estilon").ToString.Trim Then
                    ValidaModificacion = True
                    Exit Function
                End If
            End If
        End Using
    End Function

#End Region

#Region "EVENTOS"

    Private Sub frmCatAgrupacionesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lbl_Division.Visible = False
            cbo_Division.Visible = False
            lbl_Departamento.Visible = False
            cbo_Departamento.Visible = False
            lbl_Familia.Visible = False
            cbo_Familia.Visible = False
            lbl_Linea.Visible = False
            cbo_Linea.Visible = False
            lbl_L1.Visible = False
            cbo_L1.Visible = False
            lbl_L2.Visible = False
            cbo_L2.Visible = False
            lbl_L3.Visible = False
            cbo_L3.Visible = False
            lbl_L4.Visible = False
            cbo_L4.Visible = False
            lbl_L5.Visible = False
            cbo_L5.Visible = False
            lbl_L6.Visible = False
            cbo_L6.Visible = False
            txt_Estilon.Visible = False
            HabilitaControles()
            If Accion = 1 Then Exit Sub
            Dim objDataSet As DataSet
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                objDataSet = objAgrupaciones.usp_TraerAgrupacionesDet(IdAgrupacion, Renglon)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    cbo_Nivel.Text = objDataSet.Tables(0).Rows(0).Item("nivel").ToString.Trim
                    cbo_Division.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString.Trim)
                    cbo_Departamento.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("iddepto").ToString.Trim)
                    cbo_Familia.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString.Trim)
                    cbo_Linea.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idlinea").ToString.Trim)
                    cbo_L1.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idl1").ToString.Trim)
                    cbo_L2.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idl2").ToString.Trim)
                    cbo_L3.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idl3").ToString.Trim)
                    cbo_L4.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idl4").ToString.Trim)
                    cbo_L5.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idl5").ToString.Trim)
                    cbo_L6.EditValue = CInt(objDataSet.Tables(0).Rows(0).Item("idl6").ToString.Trim)
                    txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString.Trim
                    Call TxtLostfocus(txt_Marca, txt_NomMarca, "M")
                    txt_Estilon.Text = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                    txt_IdUsuario.Text = objDataSet.Tables(0).Rows(0).Item("idusuario").ToString.Trim
                    txt_FUM.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("fum").ToString.Trim), "yyyy-MM-dd HH:mm")
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Nivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Nivel.SelectedIndexChanged
        Try
            txt_Marca.Text = ""
            txt_NomMarca.Text = ""
            If cbo_Nivel.Text.Trim = "División" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = False
                cbo_Departamento.Visible = False
                lbl_Familia.Visible = False
                cbo_Familia.Visible = False
                lbl_Linea.Visible = False
                cbo_Linea.Visible = False
                lbl_L1.Visible = False
                cbo_L1.Visible = False
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_Departamento.EditValue = 0
                cbo_Familia.EditValue = 0
                cbo_Linea.EditValue = 0
                cbo_L1.EditValue = 0
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_Departamento.Properties.DataSource = Nothing
                cbo_Familia.Properties.DataSource = Nothing
                cbo_Linea.Properties.DataSource = Nothing
                cbo_L1.Properties.DataSource = Nothing
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "Departamento" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = False
                cbo_Familia.Visible = False
                lbl_Linea.Visible = False
                cbo_Linea.Visible = False
                lbl_L1.Visible = False
                cbo_L1.Visible = False
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_Familia.EditValue = 0
                cbo_Linea.EditValue = 0
                cbo_L1.EditValue = 0
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_Familia.Properties.DataSource = Nothing
                cbo_Linea.Properties.DataSource = Nothing
                cbo_L1.Properties.DataSource = Nothing
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "Familia" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = False
                cbo_Linea.Visible = False
                lbl_L1.Visible = False
                cbo_L1.Visible = False
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_Linea.EditValue = 0
                cbo_L1.EditValue = 0
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_Linea.Properties.DataSource = Nothing
                cbo_L1.Properties.DataSource = Nothing
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "Linea" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = False
                cbo_L1.Visible = False
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_L1.EditValue = 0
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_L1.Properties.DataSource = Nothing
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "L1" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = True
                cbo_L1.Visible = True
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "L2" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = True
                cbo_L1.Visible = True
                lbl_L2.Visible = True
                cbo_L2.Visible = True
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "L3" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = True
                cbo_L1.Visible = True
                lbl_L2.Visible = True
                cbo_L2.Visible = True
                lbl_L3.Visible = True
                cbo_L3.Visible = True
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "L4" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = True
                cbo_L1.Visible = True
                lbl_L2.Visible = True
                cbo_L2.Visible = True
                lbl_L3.Visible = True
                cbo_L3.Visible = True
                lbl_L4.Visible = True
                cbo_L4.Visible = True
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "L5" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = True
                cbo_L1.Visible = True
                lbl_L2.Visible = True
                cbo_L2.Visible = True
                lbl_L3.Visible = True
                cbo_L3.Visible = True
                lbl_L4.Visible = True
                cbo_L4.Visible = True
                lbl_L5.Visible = True
                cbo_L5.Visible = True
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_L6.EditValue = 0
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "L6" Then
                lbl_Division.Visible = True
                cbo_Division.Visible = True
                lbl_Departamento.Visible = True
                cbo_Departamento.Visible = True
                lbl_Familia.Visible = True
                cbo_Familia.Visible = True
                lbl_Linea.Visible = True
                cbo_Linea.Visible = True
                lbl_L1.Visible = True
                cbo_L1.Visible = True
                lbl_L2.Visible = True
                cbo_L2.Visible = True
                lbl_L3.Visible = True
                cbo_L3.Visible = True
                lbl_L4.Visible = True
                cbo_L4.Visible = True
                lbl_L5.Visible = True
                cbo_L5.Visible = True
                lbl_L6.Visible = True
                cbo_L6.Visible = True
                txt_Estilon.Visible = False
            ElseIf cbo_Nivel.Text.Trim = "Marca" Then
                lbl_Division.Visible = False
                cbo_Division.Visible = False
                lbl_Departamento.Visible = False
                cbo_Departamento.Visible = False
                lbl_Familia.Visible = False
                cbo_Familia.Visible = False
                lbl_Linea.Visible = False
                cbo_Linea.Visible = False
                lbl_L1.Visible = False
                cbo_L1.Visible = False
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = False
                cbo_Division.EditValue = 0
                cbo_Departamento.EditValue = 0
                cbo_Familia.EditValue = 0
                cbo_Linea.EditValue = 0
                cbo_L1.EditValue = 0
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_Division.Properties.DataSource = Nothing
                cbo_Departamento.Properties.DataSource = Nothing
                cbo_Familia.Properties.DataSource = Nothing
                cbo_Linea.Properties.DataSource = Nothing
                cbo_L1.Properties.DataSource = Nothing
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            ElseIf cbo_Nivel.Text.Trim = "Modelo" Then
                lbl_Division.Visible = False
                cbo_Division.Visible = False
                lbl_Departamento.Visible = False
                cbo_Departamento.Visible = False
                lbl_Familia.Visible = False
                cbo_Familia.Visible = False
                lbl_Linea.Visible = False
                cbo_Linea.Visible = False
                lbl_L1.Visible = False
                cbo_L1.Visible = False
                lbl_L2.Visible = False
                cbo_L2.Visible = False
                lbl_L3.Visible = False
                cbo_L3.Visible = False
                lbl_L4.Visible = False
                cbo_L4.Visible = False
                lbl_L5.Visible = False
                cbo_L5.Visible = False
                lbl_L6.Visible = False
                cbo_L6.Visible = False
                txt_Estilon.Visible = True
                cbo_Division.EditValue = 0
                cbo_Departamento.EditValue = 0
                cbo_Familia.EditValue = 0
                cbo_Linea.EditValue = 0
                cbo_L1.EditValue = 0
                cbo_L2.EditValue = 0
                cbo_L3.EditValue = 0
                cbo_L4.EditValue = 0
                cbo_L5.EditValue = 0
                cbo_L6.EditValue = 0
                cbo_Division.Properties.DataSource = Nothing
                cbo_Departamento.Properties.DataSource = Nothing
                cbo_Familia.Properties.DataSource = Nothing
                cbo_Linea.Properties.DataSource = Nothing
                cbo_L1.Properties.DataSource = Nothing
                cbo_L2.Properties.DataSource = Nothing
                cbo_L3.Properties.DataSource = Nothing
                cbo_L4.Properties.DataSource = Nothing
                cbo_L5.Properties.DataSource = Nothing
                cbo_L6.Properties.DataSource = Nothing
            End If
            TraerEstructura(cbo_Division, "División")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Division_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_Division.EditValueChanged
        Try
            TraerEstructura(cbo_Departamento, "Departamento")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Departamento_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_Departamento.EditValueChanged
        Try
            TraerEstructura(cbo_Familia, "Familia")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Familia_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_Familia.EditValueChanged
        Try
            TraerEstructura(cbo_Linea, "Linea")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_Linea_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_Linea.EditValueChanged
        Try
            TraerEstructura(cbo_L1, "L1")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_L1_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_L1.EditValueChanged
        Try
            TraerEstructura(cbo_L2, "L2")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_L2_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_L2.EditValueChanged
        Try
            TraerEstructura(cbo_L3, "L3")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_L3_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_L3.EditValueChanged
        Try
            TraerEstructura(cbo_L4, "L4")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_L4_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_L4.EditValueChanged
        Try
            TraerEstructura(cbo_L5, "L5")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cbo_L5_EditValueChanged(sender As Object, e As EventArgs) Handles cbo_L5.EditValueChanged
        Try
            TraerEstructura(cbo_L6, "L6")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim blnTransaccion As Boolean
            Using objAgrupaciones As New BCL.BCLAgrupaciones(GLB_ConStringSirCoPVSQL)
                If Accion = 1 Then
                    If ValidaDatos() = False Then
                        MessageBox.Show("Favor de llenar todos los datos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    If ExisteAgrupacion = True Then
                        MessageBox.Show("La agrupación seleccionada ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    blnTransaccion = objAgrupaciones.usp_CapturaAgrupacionDet(IdAgrupacion, IIf(cbo_Division.EditValue IsNot Nothing, cbo_Division.EditValue, 0), IIf(cbo_Departamento.EditValue IsNot Nothing, cbo_Departamento.EditValue, 0), IIf(cbo_Familia.EditValue IsNot Nothing, cbo_Familia.EditValue, 0), IIf(cbo_Linea.EditValue IsNot Nothing, cbo_Linea.EditValue, 0), IIf(cbo_L1.EditValue IsNot Nothing, cbo_L1.EditValue, 0), IIf(cbo_L2.EditValue IsNot Nothing, cbo_L2.EditValue, 0), IIf(cbo_L3.EditValue IsNot Nothing, cbo_L3.EditValue, 0), IIf(cbo_L4.EditValue IsNot Nothing, cbo_L4.EditValue, 0), IIf(cbo_L5.EditValue IsNot Nothing, cbo_L5.EditValue, 0), IIf(cbo_L6.EditValue IsNot Nothing, cbo_L6.EditValue, 0), txt_Marca.Text.Trim, txt_Estilon.Text, cbo_Nivel.Text.Trim, GLB_Usuario)
                    If blnTransaccion = False Then
                        MessageBox.Show("No se pudo almacenar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    MessageBox.Show("Detalle guardado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                ElseIf Accion = 2 Then
                    If ValidaDatos() = False Then
                        MessageBox.Show("Favor de llenar todos los datos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    If ValidaModificacion() = False Then
                        MessageBox.Show("No se realizo ninguna modificación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    If ExisteAgrupacion() = True Then
                        MessageBox.Show("La agrupación seleccionada ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    blnTransaccion = objAgrupaciones.usp_ModificaAgrupacionDet(IdAgrupacion, IIf(cbo_Division.EditValue IsNot Nothing, cbo_Division.EditValue, 0), IIf(cbo_Departamento.EditValue IsNot Nothing, cbo_Departamento.EditValue, 0), IIf(cbo_Familia.EditValue IsNot Nothing, cbo_Familia.EditValue, 0), IIf(cbo_Linea.EditValue IsNot Nothing, cbo_Linea.EditValue, 0), IIf(cbo_L1.EditValue IsNot Nothing, cbo_L1.EditValue, 0), IIf(cbo_L2.EditValue IsNot Nothing, cbo_L2.EditValue, 0), IIf(cbo_L3.EditValue IsNot Nothing, cbo_L3.EditValue, 0), IIf(cbo_L4.EditValue IsNot Nothing, cbo_L4.EditValue, 0), IIf(cbo_L5.EditValue IsNot Nothing, cbo_L5.EditValue, 0), IIf(cbo_L6.EditValue IsNot Nothing, cbo_L6.EditValue, 0), txt_Marca.Text.Trim, txt_Estilon.Text, cbo_Nivel.Text.Trim, Renglon, GLB_Usuario)
                    If blnTransaccion = False Then
                        MessageBox.Show("No se pudo modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                    MessageBox.Show("Detalle modificado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                ElseIf Accion = 3 Then
                    Me.Close()
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub txt_Estilon_LostFocus(sender As Object, e As EventArgs) Handles txt_Estilon.LostFocus
        Try
            If txt_Estilon.Text.Trim = "" Then Exit Sub
            txt_Estilon.Text = pub_RellenarEspaciosIzquierda(txt_Estilon.Text.Trim, 7)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Marca_LostFocus(sender As Object, e As EventArgs) Handles txt_Marca.LostFocus
        If txt_Marca.Text.Trim = "" Then
            txt_NomMarca.Text = ""
            Exit Sub
        End If
        Try
            Call TxtLostfocus(txt_Marca, txt_NomMarca, "M")
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