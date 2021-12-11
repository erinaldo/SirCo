Public Class frmFiltrosEstructura
    'mreyes 10/Febrero/2012 06:43 p.m.
    Dim Sql As String


    Private objDataSet As Data.DataSet
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False
    Dim blnEntroDivisiones As Boolean = False
    Dim blnEntroDepto As Boolean = False
    Dim blnEntroFamilia As Boolean = False
    Dim blnEntroLinea As Boolean = False
    Dim blnEntroSubLinea As Boolean = False
    Dim blnEntroSubSubLinea As Boolean = False
    Dim blnEntroSubSubSubLinea As Boolean = False



    Private Sub Txt_Familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CveDepto.GotFocus
        Txt_CveDepto.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CveDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            Sw_Filtro = True
            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub







    Private Sub LimpiarDatos()
        Try
            Txt_CveDepto.Text = ""
            Txt_CveFamilia.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    'Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CveDepto.LostFocus
    '    Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
    '        If Txt_CveDepto.Text.Length = 0 Then Exit Sub

    '        Try
    '            'Get the specific project selected in the ListView control
    '            If Txt_CveDepto.Text.Trim.Length < 3 Then
    '                Txt_CveDepto.Text = pub_RellenarIzquierda(Txt_CveDepto.Text.Trim, 3)
    '            End If
    '            Call TxtLostfocus(Txt_CveDepto, Txt_DescripDepto, "M")

    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
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


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            Sw_Cancelar = True
            Sw_Filtro = False
            ' Me.Dispose()
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub



    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Me.Txt_DescripDepto.Text = ""
        Me.Txt_CveDepto.Text = ""
        Me.Txt_CveFamilia.Text = ""
    End Sub

    Private Sub frmFiltrosEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

    End Sub

    Private Sub frmFiltrosEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Divisiones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveDivisiones.TextChanged
        Try
            blnEntroDivisiones = False
            If Txt_CveDivisiones.Text.Length = 3 Then
                Txt_CveDepto.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Depto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveDepto.TextChanged
        Try
            blnEntroDepto = False
            If Txt_CveDepto.Text.Length = 3 Then
                Txt_CveFamilia.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveFamilia.TextChanged
        Try
            blnEntroFamilia = False
            If Txt_CveFamilia.Text.Length = 3 Then
                Txt_CveLinea.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveLinea.TextChanged
        Try
            blnEntroLinea = False
            If Txt_CveLinea.Text.Length = 3 Then
                Txt_CveSubLinea.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_SubLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveSubLinea.TextChanged
        Try
            blnEntroSubLinea = False
            If Txt_CveSubLinea.Text.Length = 3 Then
                Txt_CveSubSubLinea.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_SubSubLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveSubSubLinea.TextChanged
        Try
            blnEntroSubSubLinea = False
            If Txt_CveSubSubLinea.Text.Length = 3 Then
                Btn_Aceptar.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    'Private Sub Txt_Sucursal_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CveFamilia.LostFocus
    '    Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringPerSis)
    '        If Txt_CveFamilia.Text.Length = 0 Then Exit Sub

    '        Try
    '            'Get the specific project selected in the ListView control
    '            If Txt_CveFamilia.Text.Trim.Length < 2 Then
    '                Txt_CveFamilia.Text = pub_RellenarIzquierda(Txt_CveFamilia.Text.Trim, 2)
    '            End If

    '            Call TxtLostfocusPersis(Txt_CveFamilia, Txt_DescripFamilia, "S")


    '        Catch ExceptionErr As Exception
    '            MessageBox.Show(ExceptionErr.Message.ToString)
    '        End Try
    '    End Using
    'End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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

    Private Sub Txt_ClaveDivisiones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveDivisiones.LostFocus
        Try
            If blnEntroDivisiones = True Then Exit Sub
            If Txt_CveDivisiones.Text.Trim = "" Then Exit Sub
            blnEntroDivisiones = True
            usp_TraerDivisiones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveDpto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveDepto.LostFocus
        Try
            If blnEntroDepto = True Then Exit Sub
            If Txt_CveDepto.Text.Trim = "" Then Exit Sub
            blnEntroDepto = True
            usp_TraerDeptos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveFamilia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveFamilia.LostFocus
        Try
            If blnEntroFamilia = True Then Exit Sub
            If Txt_CveFamilia.Text.Trim = "" Then Exit Sub
            blnEntroFamilia = True
            usp_TraerFamilia()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveLinea.LostFocus
        Try
            If blnEntroLinea = True Then Exit Sub
            If Txt_CveLinea.Text.Trim = "" Then Exit Sub
            blnEntroLinea = True
            usp_TraerLinea()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveSubLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveSubLinea.LostFocus
        Try
            If blnEntroSubLinea = True Then Exit Sub
            If Txt_CveSubLinea.Text.Trim = "" Then Exit Sub
            blnEntroSubLinea = True
            usp_TraerSubLinea()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_ClaveSubSubLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CveSubSubLinea.LostFocus
        Try
            If blnEntroSubSubLinea = True Then Exit Sub
            If Txt_CveSubSubLinea.Text.Trim = "" Then Exit Sub
            blnEntroSubSubLinea = True
            usp_TraerSubSubLinea()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerDivisiones()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(CInt(Txt_IdDivisiones.Text), Txt_CveDivisiones.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDivisiones.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "DI"
                    myForm.ShowDialog()
                    Txt_IdDivisiones.Text = myForm.IdCampo
                    Txt_CveDivisiones.Text = myForm.ClaveCampo
                    Txt_DescripDivisiones.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerDeptos()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDepto(CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_CveDepto.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "D"
                    myForm.IdSuperior1 = CInt(Txt_IdDivisiones.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdDepto.Text = myForm.IdCampo
                    Txt_CveDepto.Text = myForm.ClaveCampo
                    Txt_DescripDepto.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerFamilia()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_CveFamilia.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    'Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("depto").ToString
                    'Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("cvedepto").ToString
                    Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString
                    Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveFamilia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripFamilia.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "F"
                    myForm.IdSuperior1 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdDivisiones.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdFamilia.Text = myForm.IdCampo
                    Txt_CveFamilia.Text = myForm.ClaveCampo
                    Txt_DescripFamilia.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerLinea()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstLinea(CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_CveLinea.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    'Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("depto").ToString
                    'Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("cvedepto").ToString
                    'Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia")
                    'Txt_DescripFam.Text = objDataSet.Tables(0).Rows(0).Item("familia").ToString
                    'Txt_CveFam.Text = objDataSet.Tables(0).Rows(0).Item("cveFamilia").ToString
                    Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idlinea").ToString
                    Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveLinea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "L"
                    myForm.IdSuperior1 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdDivisiones.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdLinea.Text = myForm.IdCampo
                    Txt_CveLinea.Text = myForm.ClaveCampo
                    Txt_DescripLinea.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerSubLinea()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdSubLinea.Text.Trim = "" Then
                    Txt_IdSubLinea.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl1(CInt(Txt_IdSubLinea.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_CveSubLinea.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    'Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("depto").ToString
                    'Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("cvedepto").ToString
                    'Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia")
                    'Txt_DescripFam.Text = objDataSet.Tables(0).Rows(0).Item("familia").ToString
                    'Txt_CveFam.Text = objDataSet.Tables(0).Rows(0).Item("cveFamilia").ToString
                    'Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idLinea").ToString
                    'Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("Linea").ToString
                    'Txt_CveLinea.Text = objDataSet.Tables(0).Rows(0).Item("cveLinea").ToString
                    Txt_IdSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("idsublinea").ToString
                    Txt_DescripSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "S"
                    myForm.IdSuperior1 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdDivisiones.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdSubLinea.Text = myForm.IdCampo
                    Txt_CveSubLinea.Text = myForm.ClaveCampo
                    Txt_DescripSubLinea.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerSubSubLinea()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivisiones.Text.Trim = "" Then
                    Txt_IdDivisiones.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdSubLinea.Text.Trim = "" Then
                    Txt_IdSubLinea.Text = 0
                End If
                If Txt_IdSubSubLinea.Text.Trim = "" Then
                    Txt_IdSubSubLinea.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl2(CInt(Txt_IdSubSubLinea.Text), CInt(Txt_IdSubLinea.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivisiones.Text), Txt_CveSubSubLinea.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    'Txt_Clave.Text = objDataSet.Tables(0).Rows(0).Item("cvedepto").ToString
                    'Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("depto").ToString
                    'Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia")
                    'Txt_CveFam.Text = objDataSet.Tables(0).Rows(0).Item("cveFamilia").ToString
                    'Txt_DescripFam.Text = objDataSet.Tables(0).Rows(0).Item("familia").ToString
                    'Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idLinea").ToString
                    'Txt_CveLinea.Text = objDataSet.Tables(0).Rows(0).Item("cveLinea").ToString
                    'Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("Linea").ToString
                    'Txt_IdSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("idSubLinea").ToString
                    'Txt_CveSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("cveSubLinea").ToString
                    'Txt_DescripSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("SubLinea").ToString
                    Txt_IdSubSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("idsubsublinea").ToString
                    Txt_DescripSubSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_CveSubSubLinea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    'Txt_DescripSubSubLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "SS"
                    myForm.IdSuperior1 = CInt(Txt_IdSubLinea.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior5 = CInt(Txt_IdDivisiones.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdSubSubLinea.Text = myForm.IdCampo
                    Txt_CveSubSubLinea.Text = myForm.ClaveCampo
                    Txt_DescripSubSubLinea.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

End Class