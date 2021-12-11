Public Class frmFiltrosPedBodega
    Dim Sql As String

      

    Dim blnEntroSucu As Boolean = False
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
        'Txt_SucurOri.Text = ""
        'Txt_DescripSucurOri.Text = ""
        DTPicker2.Value = Now
        DTPicker3.Value = Now
        Chk_FechaTraspaso.Checked = False
        DTPicker2.Enabled = False
        DTPicker3.Enabled = False
        Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_FechaTraspaso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_FechaTraspaso.CheckedChanged
        If Chk_FechaTraspaso.Checked = True Then
            DTPicker2.Enabled = True
            DTPicker3.Enabled = True
        Else
            DTPicker2.Enabled = False
            DTPicker3.Enabled = False
        End If
    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
        'Dim myForm As New frmConsulta


        'If Txt_Campo.Text.Length = 0 Then Exit Sub
        'Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
        '    Try
        '        objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")
        '        If objDataSet.Tables(0).Rows.Count > 0 Then
        '            Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
        '        Else
        '            Txt_Campo.Text = ""
        '            myForm.Tipo = Tipo
        '            myForm.ShowDialog()
        '            Txt_Campo.Text = myForm.Campo
        '            Txt_Campo1.Text = myForm.Campo1
        '            If Txt_Campo.Text.Length = 0 Then
        '                Txt_Campo.Focus()
        '            End If
        '        End If

        '    Catch ExceptionErr As Exception
        '        MessageBox.Show(ExceptionErr.Message.ToString)
        '    End Try
        'End Using
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

    End Sub
    Private Sub Txt_SucurOri_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

   


    'Private Sub Txt_SucurDes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    e.KeyChar = UCase(e.KeyChar)

    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub





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

    Private Sub Txt_SucurOri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DTPicker2_ValueChanged(sender As Object, e As EventArgs) Handles DTPicker2.ValueChanged
        
    End Sub

    Private Sub Pnl_Edicion_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
End Class