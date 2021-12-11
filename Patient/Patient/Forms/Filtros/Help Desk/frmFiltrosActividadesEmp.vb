Public Class frmFiltrosActividades
    'Tony Garcia 12/Sept/2012 12:29 p.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False
    Dim Sw_Load As Boolean = False
    Public Estatus As String

    Dim IdDepto As Integer
    Private objDataSet As Data.DataSet

    Private Sub frmFiltrosActividadesEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()

        Call AsignaID()
        Call CargaTipoAct()
        If Val(Txt_IdPuesto.Text) <> 0 Then
            Call TraerPuesto()
        End If
        If Txt_Sucursal.Text <> "" Then
            Call TraerSucursal()
        End If

        If GLB_CveSucursal <> "" Then
            Txt_Sucursal.Enabled = False
        End If
    End Sub

    Private Sub CargaTipoAct()
        If Estatus = "C" Then
            Cbo_Estatus.Text = "CAPTURA"
        ElseIf Estatus = "S" Then
            Cbo_Estatus.Text = "EN PROCESO"
        ElseIf Estatus = "R" Then
            Cbo_Estatus.Text = "REALIZADO"
        ElseIf Estatus = "P" Then
            Cbo_Estatus.Text = "PAUSADO"
        ElseIf Estatus = "E" Then
            Cbo_Estatus.Text = "EN ESPERA"
        ElseIf Estatus = "X" Then
            Cbo_Estatus.Text = "CANCELADO"
        ElseIf Estatus = "N" Then
            Cbo_Estatus.Text = "NO APLICA"
        End If
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            Sw_Filtro = True
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
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

    Private Sub Txt_Area_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Area.LostFocus
        Try
            Call usp_TraerNomDepto()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerNomDepto()
        'Tony Garcia - 23/Ocutbre/2012 - 5:25 p.m.
        Dim objDataSet As Data.DataSet
        If Txt_Area.Text = "" Then Exit Sub
        Using objCatalogoActividades As New BCL.BCLCatalogoActividades(GLB_ConStringNomSis)
            objDataSet = objCatalogoActividades.usp_TraerNomDepto(Txt_Area.Text)
            If objDataSet.Tables(0).Rows.Count = 1 Then
                Txt_AreaDescrip.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
            Else
                Dim myForm As New frmConsulta
                myForm.Tipo = "DE"
                myForm.ShowDialog()
                Txt_Area.Text = myForm.Campo1
                Txt_AreaDescrip.Text = myForm.Campo2
                Txt_IdDepto.Text = myForm.Campo
            End If

            If Txt_AreaDescrip.Text = "ADMINISTRACIÓN" Then
                Txt_AreaDescrip.Text = "ADMINISTRACION"
            End If

            If Txt_AreaDescrip.Text = "CRÉDITO" Then
                Txt_AreaDescrip.Text = "CREDITO"
            End If
        End Using
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub frmFiltrosFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub AsignaID()
        If Txt_IdReporta.Text = "9999" Then
            Txt_IdReporta.Text = "IF"
            Txt_NombreReporta.Text = "ING. FELIX B. GIACOMAN MOURRA"
        ElseIf Txt_IdReporta.Text = "9998" Then
            Txt_IdReporta.Text = "LF"
            Txt_NombreReporta.Text = "LIC. FELIX GIACOMAN"
        ElseIf Txt_IdReporta.Text = "9997" Then
            Txt_IdReporta.Text = "IG"
            Txt_NombreReporta.Text = "ING. JOSE LUIS GARCIA RAMIREZ"
        Else
            Call usp_TraerEmpleadoRep()
        End If


        If Txt_IdAsignado.Text = "9999" Then
            Txt_IdAsignado.Text = "IF"
            Txt_NombreAsignado.Text = "ING. FELIX B. GIACOMAN MOURRA"
        ElseIf Txt_IdAsignado.Text = "9998" Then
            Txt_IdAsignado.Text = "LF"
            Txt_NombreAsignado.Text = "LIC. FELIX GIACOMAN"
        ElseIf Txt_IdAsignado.Text = "9997" Then
            Txt_IdAsignado.Text = "IG"
            Txt_NombreAsignado.Text = "ING. JOSE LUIS GARCIA RAMIREZ"
        Else
            Call usp_TraerEmpleadoAsig()
        End If
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

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_Sucursal.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                Sql = ""
                Sql = Sql & "SELECT descrip as campo "
                Sql = Sql & " FROM sucursal "
                Sql = Sql & " WHERE sucursal = '" & Txt_Sucursal.Text.Trim & "';"

                Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        DTFecha1.Value = Now
        DTFecha2.Value = Now

        If GLB_CveSucursal <> "" Then
        Else
            Txt_Sucursal.Text = ""
            Txt_DescripSucursal.Text = ""
        End If

        Chk_Fecha.Checked = False
        DTFecha1.Enabled = False
        DTFecha2.Enabled = False
        Txt_Folio.Text = ""
        Txt_IdReporta.Text = ""
        Txt_IdAsignado.Text = ""
        Txt_NombreAsignado.Text = ""
        Txt_NombreReporta.Text = ""
        Txt_IdPuesto.Text = ""
        Txt_IdDepto.Text = ""
        Txt_ClavePuesto.Text = ""
        Txt_DescripPuesto.Text = ""
        Cbo_Estatus.Text = ""
        Txt_Area.Text = ""
        Txt_AreaDescrip.Text = ""
    End Sub

    Private Sub Chk_FechaOrden_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Fecha.CheckedChanged
        If Chk_Fecha.Checked = True Then
            DTFecha1.Enabled = True
            DTFecha2.Enabled = True
        Else
            DTFecha1.Enabled = False
            DTFecha2.Enabled = False
        End If
    End Sub

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Sucursal_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
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
        End Using
    End Sub

    Private Sub Cbo_Estatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdReporta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdReporta.LostFocus
        Try
            If Txt_IdReporta.Text = "IF" Then
                Txt_NombreReporta.Text = "ING. FELIX B. GIACOMAN MOURRA"
            ElseIf Txt_IdReporta.Text = "LF" Then
                Txt_NombreReporta.Text = "LIC. FELIX GIACOMAN"
            ElseIf Txt_IdReporta.Text = "IG" Then
                Txt_NombreReporta.Text = "ING. JOSE LUIS GARCIA RAMIREZ"
            Else
                Call usp_TraerEmpleadoRep()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdAsignado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdAsignado.LostFocus
        Try
            If Txt_IdAsignado.Text = "IF" Then
                Txt_NombreAsignado.Text = "ING. FELIX B. GIACOMAN MOURRA"
            ElseIf Txt_IdAsignado.Text = "LF" Then
                Txt_NombreAsignado.Text = "LIC. FELIX GIACOMAN"
            ElseIf Txt_IdAsignado.Text = "IG" Then
                Txt_NombreAsignado.Text = "ING. JOSE LUIS GARCIA RAMIREZ"
            Else
                Call usp_TraerEmpleadoAsig()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerEmpleadoRep()
        'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_IdReporta.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_IdReporta.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_NombreReporta.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoR()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerEmpleadoAsig()
        'Tony Gracia - 13/Octubre/2012 - 01:20 p.m.
        Dim objDataSet As Data.DataSet
        Using objEmpleado As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)
            Try
                If Txt_IdAsignado.Text.Length = 0 Then Exit Sub
                objDataSet = objEmpleado.usp_TraerNomEmpleado(Val(Txt_IdAsignado.Text), "", "", "", "", 0)
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Txt_NombreAsignado.Text = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                Else
                    Call CargarFormaConsultaEmpleadoA()
                    ''MessageBox.Show("El empleado no existe, ingrese un ID valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub CargarFormaConsultaEmpleadoA()
        Dim myForm As New frmConsultaEmpleado
        Txt_NombreAsignado.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_IdAsignado.Text = myForm.Campo
        Txt_NombreAsignado.Text = myForm.Campo1
        If Txt_IdAsignado.Text.Length = 0 Then
            Txt_IdAsignado.Focus()
        End If
    End Sub

    Private Sub CargarFormaConsultaEmpleadoR()
        Dim myForm As New frmConsultaEmpleado
        Txt_IdReporta.Text = ""
        myForm.Estatus = ""
        myForm.ShowDialog()
        Txt_IdReporta.Text = myForm.Campo
        Txt_NombreReporta.Text = myForm.Campo1
        If Txt_IdReporta.Text.Length = 0 Then
            Txt_IdReporta.Focus()
        End If
    End Sub

    Private Sub CargarFormaConsulta(ByVal TipoC As String, ByVal Opcion As Integer)
        'mreyes 26/Junio/2012 09:26 a.m.
        Try
            Dim myForm As New frmConsulta
            If Opcion = 1 Then 'depto
                Txt_IdDepto.Text = ""
            End If
            If Opcion = 2 Then
                Txt_IdPuesto.Text = ""
            End If


            'myForm.Tipo = TipoC
            'myForm.idDepto = IdDepto
            'myForm.ShowDialog()
            'If Opcion = 1 Then
            '    Txt_IdDepto.Text = Val(myForm.Campo)
            '    Txt_ClaveDepto.Text = myForm.Campo1
            '    Txt_DescripDepto.Text = myForm.Campo2
            '    If Txt_ClaveDepto.Text.Length = 0 Then
            '        Txt_ClaveDepto.Focus()
            '    End If
            'End If
            myForm.Tipo = TipoC
            myForm.ShowDialog()

            If Opcion = 2 Then
                Txt_IdPuesto.Text = Val(myForm.Campo)
                Txt_ClavePuesto.Text = myForm.Campo1
                Txt_DescripPuesto.Text = myForm.Campo2
                If Txt_ClavePuesto.Text.Length = 0 Then
                    Txt_ClavePuesto.Focus()
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub TraerPuesto()
        'mreyes 13/Junio/2012 07:03 p.m.
        Try

            If Txt_ClavePuesto.Text.Length = 0 And Sw_Load = False Then Txt_DescripPuesto.Text = "" : Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPuesto(Val(Txt_IdPuesto.Text), Val(Txt_IdDepto.Text), Txt_ClavePuesto.Text, "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdPuesto.Text = objDataSet.Tables(0).Rows(0).Item("idpuesto")
                        Txt_DescripPuesto.Text = objDataSet.Tables(0).Rows(0).Item("descrippuesto").ToString
                        Txt_ClavePuesto.Text = objDataSet.Tables(0).Rows(0).Item("clavepuesto").ToString
                    Else
                        Call CargarFormaConsulta("PU", 2)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub


    Private Sub Txt_ClavePuesto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClavePuesto.LostFocus
        If Txt_ClavePuesto.Text.Length = 0 Then Exit Sub
        Call TraerPuesto()
    End Sub

    Private Sub Txt_Folio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Folio.LostFocus
        Txt_Folio.Text = pub_RellenarIzquierda(Txt_Folio.Text, 4).ToString()
    End Sub

    Private Sub Txt_Sucursal_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus

        Call TraerSucursal()
    End Sub

    Private Sub TraerSucursal()
        If Txt_Sucursal.Text.Length = 0 Then Txt_DescripSucursal.Text = "" : Exit Sub

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

    Private Sub Txt_Folio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Folio.KeyPress
        pub_SoloNumeros(sender, e)
    End Sub
End Class