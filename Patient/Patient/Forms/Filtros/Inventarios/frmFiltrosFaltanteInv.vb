Public Class frmFiltrosFaltanteInv
    Dim Sql As String

    Dim blnEntroDivisiones As Boolean = False
    Private objDataSet As Data.DataSet

    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False
    Public Opcion As Integer = 0

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
            
            Txt_SucurOri.Text = ""
            Txt_DescripSucurOri.Text = ""
            Me.Txt_IdDivision.Text = 0
            Me.Txt_Division.Text = ""
            Me.Txt_DescripDivision.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


#Region "METODOS"
    Private Sub usp_TraerDivisiones()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(CInt(Txt_IdDivision.Text), Txt_Division.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Division.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDivision.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "DI"
                    myForm.ShowDialog()
                    Txt_IdDivision.Text = myForm.IdCampo
                    Txt_Division.Text = myForm.ClaveCampo
                    Txt_DescripDivision.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

#End Region

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
        'Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    'myForm.Tipo = Tipo
                    'myForm.ShowDialog()
                    'Txt_Campo.Text = myForm.Campo
                    'Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Division_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Division.LostFocus
        'Try
        '    If blnEntroDivisiones = True Then Exit Sub
        '    If Txt_Division.Text.Trim = "" Then
        '        Txt_DescripDivision.Text = ""
        '        Txt_IdDivision.Text = ""
        '        Exit Sub
        '    End If
        '    If Txt_Division.Text.Length < 3 Then
        '        Txt_Division.Text = pub_RellenarIzquierda(Txt_Division.Text, 3)
        '    End If
        '    blnEntroDivisiones = True
        '    usp_TraerDivisiones()
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try

        Try
            If Txt_Division.Text.Length = 0 Then Exit Sub
            If Txt_Division.Text.Trim.Length < 3 Then
                Txt_Division.Text = pub_RellenarIzquierda(Txt_Division.Text.Trim, 3)
            End If


            Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objMySqlGral.usp_TraerDescripcion("EDI", Txt_Division.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    Txt_IdDivision.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                    'Else
                    '    Call CargarFormaConsulta("EDI", 1)
                End If
            End Using

            'Call TxtLostfocus(Txt_Depto, Txt_DescripDepto, "ED")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
        Call LimpiarDatos()
    End Sub

    Private Sub frmFiltrosEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmFiltrosEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()

        If Txt_SucurOri.Text <> "" Then
            Txt_SucurOri_LostFocus(sender, e)
        End If


    End Sub
    Private Sub Txt_SucurOri_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SucurOri.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    e.Handled = True
        '    SendKeys.Send("{TAB}")
        'End If
    End Sub

    Private Sub Txt_SucurOri_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucurOri.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_SucurOri.Text.Length = 0 Then Exit Sub

            Try


                Call TxtLostfocusPersis(Txt_SucurOri, Txt_DescripSucurOri, "S")
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_SucurDes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub





    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    'myForm.Tipo = Tipo
                    'myForm.Sw_Nomina = False
                    'myForm.ShowDialog()
                    'Txt_Campo.Text = myForm.Campo
                    'Txt_Campo1.Text = myForm.Campo1
                    If Txt_Campo.Text.Length = 0 Then
                        Txt_Campo.Focus()
                    End If
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Cbo_Tipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_SucurOri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_SucurOri.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Txt_DescripSucurOri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DescripSucurOri.TextChanged

    End Sub

    Private Sub Txt_Division_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Division.TextChanged
        Try
            blnEntroDivisiones = False
            If Txt_Division.Text.Length = 3 Then
                Txt_Division.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_DescripDivision_TextChanged(sender As Object, e As EventArgs) Handles Txt_DescripDivision.TextChanged

    End Sub

    Private Sub Txt_IdDivision_TextChanged(sender As Object, e As EventArgs) Handles Txt_IdDivision.TextChanged

    End Sub

    Private Sub Txt_Division_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Division.GotFocus
        Txt_Division.SelectAll()
    End Sub

    Private Sub Txt_Division_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Division.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class