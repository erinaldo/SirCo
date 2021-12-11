Public Class frmCargaVentasNomina
    'mreyes 18/Agosto/2012 09:50 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Public Id_SegBit As Integer = 0
    Private objDataSet As Data.DataSet





    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 18/Agosto/2012 10:37 a.m.
        Try

            If MsgBox("Esta seguro actualizar las ventas reportadas en nómina?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            Call usp_TraerVentasNetas()

            MsgBox("Proceso de carga de Ventas Terminado", MsgBoxStyle.Information, "Confirmación")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerVentasNetas()
        Dim Vendedor As String = ""
        Dim Z As Integer = 0
        'mreyes 18/Agosto/2012 10:38 a.m.
        Try
            Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
                Try

                    objDataSet = objMySqlGral.usp_TraerVendedor(Val(Txt_IdEmpleado.Text))
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Vendedor = objDataSet.Tables(0).Rows(0).Item("vendedor").ToString
                    Else
                        Vendedor = ""
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using

            ' Borrar Ventas 
            Using objElimina As New BCL.BCLNomina(GLB_ConStringNomSis)
                Try
                    'Get the specific project selected in the ListView control
                    If objElimina.usp_EliminaVenta(Txt_Sucursal.Text, Val(Txt_IdEmpleado.Text), DTFecha.Value, DTFecha1.Value) = False Then
                       
                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetas(Txt_Sucursal.Text, Vendedor, DTFecha.Value, DTFecha1.Value)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using


            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetas(Txt_Sucursal.Text, "1", DTFecha.Value, DTFecha1.Value)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNomina(objDatasetE, Z)

                    Next
                End If
            End Using




            Using objMicrosipE As New BCL.BCLNomina(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet


                objDatasetE = objMicrosipE.usp_TraerVentasNetasCajero(Txt_Sucursal.Text, Vendedor, DTFecha.Value, DTFecha1.Value)
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Application.DoEvents()
                    PBar.Minimum = 0
                    PBar.Maximum = objDatasetE.Tables(0).Rows.Count
                    PBar.Value = 0
                    Dim Cont As Integer = objDatasetE.Tables(0).Rows.Count - 1
                    For Z = 0 To objDatasetE.Tables(0).Rows.Count - 1
                        ' Insertar en Empleados
                        PBar.Value = PBar.Value + 1
                        Txt_Porc.Text = Z & " de " & Cont
                        Application.DoEvents()
                        Call Inserta_VentaNominaCajero(objDatasetE, Z)

                    Next
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

   
    Private Sub frmCatalogoSegBit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Sw_Registro = False
                        Me.Dispose()
                        Me.Close()

                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub frmCatalogoSegBit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Accion = 1
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Pnl_Edicion.Enabled = False
                    Pnl_Edicion.Enabled = False

                    Call CambiaBackcolor()

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True

            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CambiaBackcolor()
        Try
            'mreyes 02/Marzo/2012 10:25 a.m.


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Accion = 2
        Call Edicion()
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                'If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                'Me.Dispose()
                Me.Close()
                Sw_Registro = False
                'End If
            Else
            Me.Close()
            Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        Call TraerEmpleado()
    End Sub
    Private Sub CargarFormaConsultaEmpleado()
        'mreyes 11/Junio/2012 06:04 p.m.

        Dim myForm As New frmConsultaEmpleado
        Txt_NombreEmpleado.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_IdEmpleado.Text = myForm.Campo
        Txt_NombreEmpleado.Text = myForm.Campo1
        If Txt_IdEmpleado.Text.Length = 0 Then
            Txt_IdEmpleado.Focus()
        End If
    End Sub
    Private Sub TraerEmpleado()

        If Txt_IdEmpleado.Text.Length = 0 Then Exit Sub

        Using objMySqlGral As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Val(Txt_IdEmpleado.Text) = 0 Then
                    CargarFormaConsultaEmpleado()
                Else
                    objDataSet = objMySqlGral.usp_TraerNomEmpleado(Val(Txt_IdEmpleado.Text), "", "", "", "", 0)
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_NombreEmpleado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString

                    Else
                        Call CargarFormaConsultaEmpleado()
                    End If

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Call TraerSucursal()
    End Sub
    Private Sub TraerSucursal()

        If Txt_Sucursal.Text.Length = 0 Then Exit Sub

        Try
            'Get the specific project selected in the ListView control
            If Txt_Sucursal.Text.Trim.Length < 2 Then
                Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
            End If

            Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try


                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.Sw_Nomina = True
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

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub
End Class