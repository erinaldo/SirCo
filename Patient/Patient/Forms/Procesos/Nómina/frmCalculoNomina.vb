Public Class frmCalculoNomina
    'mreyes 24/Agosto/2012 07:37 p.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private objDataSet As Data.DataSet
    Public SucSelect(250) As String
    Public IntSelect As Integer
    Public Periodo As String = ""
    Public FechaIniB As Date
    Public Tipo As String = ""
    Dim IdPeriodoB As Integer = 0
    Dim FechaIni As Date
    Dim FechaFinB As Date


    Private Sub FechaUltimoPeriodo()
        'mreyes 23/Agosto/2012 06:43 p.m.
        Try
            Dim objDataSet1 As Data.DataSet
            Using objCantArti As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                objDataSet1 = objCantArti.usp_TraerUltimoPeriodo(2, "A", 0)

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    IdPeriodoB = objDataSet1.Tables(0).Rows(0).Item("idperiodo")
                    FechaIniB = Format(objDataSet1.Tables(0).Rows(0).Item("fechaini"), "yyyy-MM-dd")
                    FechaFinB = Format(objDataSet1.Tables(0).Rows(0).Item("fechafin"), "yyyy-MM-dd")

                End If


            End Using
            If Tipo = "AGUINALDO" Then
                IdPeriodoB = 453 '400 '346 '241 '186 '131 '78

                FechaIniB = "2020-01-01"
                FechaFinB = "2020-12-31"
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Function usp_CaculoNominaFiscal(ByVal TipoNomB As String) As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.

        Using objCalculo As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                'Get the specific project selected in the ListView controlsu
                Application.DoEvents()
                usp_CaculoNominaFiscal = objCalculo.usp_CaculoNominaFiscal(IdPeriodoB, TipoNomB, FechaIniB, FechaFinB, Txt_Sucursal.Text, Val(Txt_IdEmpleado.Text), GLB_Usuario, GLB_ComEmp)
                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_CaculoAguinaldo(ByVal TipoNomB As String) As Boolean
        'mreyes 10/Diciembre/2012 01:42 p.m.

        Using objCalculo As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                'Get the specific project selected in the ListView controlsu
                Application.DoEvents()
                usp_CaculoAguinaldo = objCalculo.usp_CaculoAguinaldo(IdPeriodoB, TipoNomB, Txt_Sucursal.Text, Val(Txt_IdEmpleado.Text), GLB_Usuario)
                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            If Tipo = "" Then
                If MsgBox("Esta seguro de querer ejecutar el cálculo de la nómina.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                Me.Cursor = Cursors.AppStarting
                Application.DoEvents()
                If Cbo_TipoNom.Text = "" Then
                    If usp_CaculoNominaFiscal("B") = False Then
                        Me.Cursor = Cursors.Default
                        ' MsgBox("No se pudo ejecutar el calculo. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                    End If
                    If usp_CaculoNominaFiscal("F") = False Then
                        Me.Cursor = Cursors.Default
                        ' MsgBox("No se pudo ejecutar el calculo. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                    End If
                Else
                    If usp_CaculoNominaFiscal(Mid(Cbo_TipoNom.Text, 1, 2)) = False Then
                        Me.Cursor = Cursors.Default
                        ' MsgBox("No se pudo ejecutar el calculo. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")

                    End If
                End If
            Else
                ' CALCULO DE AGUINALDO
                '
                If MsgBox("Esta seguro de querer ejecutar el Cálculo del AGUINALDO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                Me.Cursor = Cursors.AppStarting
                Application.DoEvents()
                If usp_CaculoAguinaldo("A") = False Then
                    Me.Cursor = Cursors.Default
                    MsgBox("No se pudo ejecutar el calculo. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                End If
            End If

            Me.Cursor = Cursors.Default
            MsgBox("Calculo Terminado.", MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try


            Txt_DescripSucursal.Text = ""
            Txt_Sucursal.Text = ""
            Txt_IdPuesto.Text = ""
            Txt_IdDepartamento.Text = ""
            Txt_IdEmpleado.Text = ""
            Txt_NombreEmpleado.Text = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Marca_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
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


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
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

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        If Val(Txt_IdEmpleado.Text) <> 0 Then
            Call TraerEmpleado()
        Else
            Txt_IdEmpleado.Text = ""
        End If
       
        If Txt_Sucursal.Text <> "" Then
            Call TraerSucursal()
        Else
            Txt_Sucursal.Text = ""
        End If
        Call FechaUltimoPeriodo()
        If Tipo = "AGUINALDO" Then
            Cbo_TipoNom.Text = "AGUINALDO"
            Cbo_TipoNom.Enabled = False


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
                    myForm.Sw_Nomina = True
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



    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click

        Call LimpiarDatos()


        Txt_Sucursal.Text = ""
        Txt_DescripSucursal.Text = ""

        Txt_IdEmpleado.Text = ""
        Txt_NombreEmpleado.Text = ""
        Txt_IdPuesto.Text = ""
        Txt_IdDepto.Text = ""
       
        Txt_DescripSucursal.Text = ""

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


    Private Sub Txt_IdEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdEmpleado.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Txt_IdDepartamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdDepartamento.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Txt_IdPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdPuesto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Txt_Sucursal_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Txt_ClaveDepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Txt_ClavePuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_IdEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.LostFocus
        'mreyes 11/Junio/2012 01:28 p.m.
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
        If Txt_IdEmpleado.Text.Length = 0 Then Txt_NombreEmpleado.Text = "" : Exit Sub


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


            myForm.Tipo = TipoC
            myForm.ShowDialog()
            If Opcion = 1 Then
                Txt_IdDepto.Text = Val(myForm.Campo)
               
            End If

            If Opcion = 2 Then
                Txt_IdPuesto.Text = Val(myForm.Campo)
                
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub


    Private Sub Txt_Sucursal_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
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

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class