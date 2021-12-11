Public Class frmModificarDescuentoCaja

#Region "VARIABLES"
    Dim objDataSet As New DataSet
    Public Distribuidor As String = ""
    Public NombreDistrib As String = ""
    Public Motivo As String = ""
    Public Descuento As Double = 0
    Public blnDescto As Boolean = False
#End Region

#Region "EVENTOS"

#Region "FORMA"

    Private Sub frmModificarDescuentoCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCajaCredito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "BOTON"

    Private Sub btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancelar.Click
        Try
            blnDescto = True
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Aceptar.Click
        Try
            If MessageBox.Show("Estas seguro que deseas generar este descuento especial?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
            If txt_Distrib.Text.Trim = "" Then
                MessageBox.Show("Debes llenar todos los campos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_Distrib.Focus()
            End If
            If txt_Distrib2.Text.Trim = "" Then
                MessageBox.Show("Debes llenar todos los campos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_Distrib2.Focus()
            End If
            ' If DT_FechaFin.Value < DT_FechaIni.Value Then
            'MessageBox.Show("La fecha final debe ser superior a la fecha inicial", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'DT_FechaFin.Focus()
            'End If
            If DT_FechaFin.Value < GLB_FechaHoy Then
                MessageBox.Show("La fecha final debe ser superior al dia de hoy", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DT_FechaFin.Focus()
            End If
            If txt_Descuento.Text.Trim = "" Then
                MessageBox.Show("Debes ingresar el descuento adicional a aplicar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_Descuento.Focus()
            End If
            If txt_Motivo.Text.Trim = "" Then
                MessageBox.Show("Debes ingresar un motivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txt_Motivo.Focus()
            End If
            Dim DistribIni As String = ""
            Dim DistribFin As String = ""
            Dim FecIni As Date
            Dim FecFin As Date
            Dim Descto As Double = 0
            Dim Motivo As String = ""
            Dim blnGuardo As Boolean = False
            DistribIni = txt_Distrib.Text
            DistribFin = txt_Distrib2.Text
            FecIni = DT_FechaIni.Value
            FecFin = DT_FechaFin.Value
            Descto = txt_Descuento.Text
            Motivo = txt_Motivo.Text
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                blnGuardo = objCajaCredito.usp_CapturaDescuentoAdicional(1, FecIni, FecFin, DistribIni, DistribFin, "00", "", "AP", Descto,
                                                                          Motivo, GLB_Idempleado, 0)
            End Using
            If blnGuardo = True Then
                MessageBox.Show("Descuento guardado correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Exit Sub
            Else
                MessageBox.Show("Error al guardar el descuento", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

#End Region

#Region "TEXTBOX"

    Private Sub txt_Distrib_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Distrib.LostFocus
        Try
            If txt_Distrib.Text.Trim = "" Then Exit Sub
            txt_Distrib.Text = pub_RellenarIzquierda(txt_Distrib.Text, 6)
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_Distrib.Text, "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_NombreDistrib.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
                txt_Distrib2.Text = txt_Distrib.Text
                txt_NombreDistrib2.Text = txt_NombreDistrib.Text
                txt_Distrib2.Focus()
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DI"
                myForm.ShowDialog()
                If myForm.blnConsultoDistrib = False Then
                    txt_Distrib.Text = ""
                    txt_NombreDistrib.Text = ""
                    txt_Distrib.Focus()
                    Exit Sub
                End If
                txt_Distrib.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                txt_NombreDistrib.Text = myForm.Campo1
                txt_Distrib2.Text = txt_Distrib.Text
                txt_NombreDistrib2.Text = txt_NombreDistrib.Text
                txt_Distrib2.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Distrib2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Distrib2.LostFocus
        Try
            If txt_Distrib.Text.Trim = "" Then Exit Sub
            txt_Distrib2.Text = pub_RellenarIzquierda(txt_Distrib2.Text, 6)
            Using objCajaCredito As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                objDataSet = objCajaCredito.usp_TraerDistribuidorCredito(1, txt_Distrib2.Text, "")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                txt_NombreDistrib2.Text = objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DI"
                myForm.ShowDialog()
                If myForm.blnConsultoDistrib = False Then
                    txt_Distrib2.Text = ""
                    txt_NombreDistrib2.Text = ""
                    txt_Distrib2.Focus()
                    Exit Sub
                End If
                txt_Distrib2.Text = pub_RellenarIzquierda(myForm.Campo, 6)
                txt_NombreDistrib2.Text = myForm.Campo1
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Distrib_TextChanged(sender As Object, e As EventArgs) Handles txt_Distrib.TextChanged

    End Sub

    Private Sub txt_Distrib_MouseWheel(sender As Object, e As MouseEventArgs) Handles txt_Distrib.MouseWheel

    End Sub

    Private Sub DT_FechaFin_ValueChanged(sender As Object, e As EventArgs) Handles DT_FechaFin.ValueChanged

    End Sub

    Private Sub DT_FechaFin_LostFocus(sender As Object, e As EventArgs) Handles DT_FechaFin.LostFocus
        txt_Descuento.Focus()
    End Sub

    Private Sub txt_Motivo_TextChanged(sender As Object, e As EventArgs) Handles txt_Motivo.TextChanged

    End Sub

    Private Sub txt_Motivo_LostFocus(sender As Object, e As EventArgs) Handles txt_Motivo.LostFocus
        btn_Aceptar.Focus()
    End Sub

#End Region

#End Region

End Class