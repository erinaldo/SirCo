Public Class frmFiltrosNomina
    'mreyes 30/Junio/2012 12:48 p.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private objDataSet As Data.DataSet
    Public SucSelect(250) As String
    Public IntSelect As Integer
    Public Periodo As String = ""
    Public FechaIniB As String = ""
    Public sw As Boolean = False
    Public sw2 As Boolean = False



    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            Dim I As Integer = 0
            Periodo = "0"
            FechaIniB = ""
            For Each row As DataGridViewRow In DGrid.Rows
                If row.Cells("Selec").Value = True Then
                    SucSelect(I) = row.Cells("idperiodo").Value
                    Periodo = Periodo & ",(" & row.Cells("idperiodo").Value & ")"


                    I = I + 1
                End If
            Next

            IntSelect = I

            Periodo = Mid(Periodo, 3)

            If Periodo = "" Then
                MessageBox.Show("Debe seleccionar un periodo.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Close()

            Sw_Filtro = True
            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try

            Txt_ClaveDepto.Text = ""
            Txt_ClavePuesto.Text = ""
            Txt_DescripPuesto.Text = ""
            Txt_DescripDepto.Text = ""
            Txt_DescripSucursal.Text = ""
            Txt_Sucursal.Text = ""
            Txt_IdPuesto.Text = ""
            Txt_IdDepartamento.Text = ""
            Txt_IdEmpleado.Text = ""
            Txt_NombreEmpleado.Text = ""
            Txt_IdConcepto.Text = ""
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
        If Val(Txt_IdDepto.Text) <> 0 Then
            Call TraerDepto()
        Else
            Txt_IdDepto.Text = ""
        End If
        If Val(Txt_IdPuesto.Text) <> 0 Then
            Call TraerPuesto()
        Else
            Txt_IdPuesto.Text = ""
        End If
        If Txt_Sucursal.Text <> "" Then
            Call TraerSucursal()
        Else
            Txt_Sucursal.Text = ""
        End If
        If Txt_IdConcepto.Text <> "" Then
            Call TraerConcepto()
        Else
            Txt_IdConcepto.Text = ""
        End If

        Call RellenaGrid()
        If sw = False Then
            Label5.Visible = False
            Txt_IdConcepto.Visible = False
            Txt_DescriConcepto.Visible = False
            DGrid.ReadOnly = False
        Else
            Label5.Visible = True
            Txt_IdConcepto.Visible = True
            Txt_DescriConcepto.Visible = True
            DGrid.ReadOnly = True
            DGrid.Rows(0).Cells(4).Value = True
        End If
        If sw2 = True Then
            Label5.Visible = True
            Txt_IdConcepto.Visible = True
            Txt_DescriConcepto.Visible = True
            sw2 = False
        End If
        Call BuscarPeriodos()
    End Sub

    Private Sub AgregarColumna()
        'mreyes 21/Marzo/2012 09:52 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Selec"
        colImagen.HeaderText = "Selec"
        colImagen.DisplayIndex = 4

        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)


    End Sub
    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLMySqlGral(GLB_ConStringNomSis)

            Try
                Me.Cursor = Cursors.WaitCursor
                ' DGrid.ReadOnly = True
                DGrid.DataSource = Nothing



                objDataSet = objRegistro.usp_TraerPeriodoNomina(2)
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid.DataSource = objDataSet.Tables(0)
                    'If Sw_Load = False Then
                    InicializaGrid()
                    'End If
                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    
                Else

                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron empleados que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                    
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub

    Private Sub BuscarPeriodos()


        'SucSelect(250)
        For Each row As DataGridViewRow In DGrid.Rows
            For i As Integer = 0 To IntSelect - 1
                If InStr(row.Cells("idperiodo").Value, SucSelect(i)) Then
                    row.Cells("Selec").Value = True
                    Exit For
                End If
            Next
        Next

    End Sub
    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.
        Try

            DGrid.RowHeadersVisible = False
            ' DGrid.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Regular)
            DGrid.Columns(0).HeaderText = "IdPeriodo"
            DGrid.Columns(1).HeaderText = "Periodo"
            DGrid.Columns(2).HeaderText = "FechaIni"
            DGrid.Columns(3).HeaderText = "FechaFin"
            DGrid.Columns(0).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False

            DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



            Call AgregarColumna()

            DGrid.Columns(4).ReadOnly = False
            DGrid.Columns(0).ReadOnly = True
            DGrid.Columns(1).ReadOnly = True
        
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
        Txt_ClaveDepto.Text = ""
        Txt_ClavePuesto.Text = ""
        Txt_DescripDepto.Text = ""
        Txt_DescripPuesto.Text = ""
        Txt_DescripSucursal.Text = ""
        Txt_IdConcepto.Text = ""
        Txt_DescriConcepto.Text = ""
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



    Private Sub Txt_ClaveDepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClaveDepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Txt_ClavePuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ClavePuesto.KeyPress
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
                Txt_ClaveDepto.Text = myForm.Campo1
                Txt_DescripDepto.Text = myForm.Campo2
                If Txt_ClaveDepto.Text.Length = 0 Then
                    Txt_ClaveDepto.Focus()
                End If
            End If

            If Opcion = 2 Then
                Txt_IdPuesto.Text = Val(myForm.Campo)
                Txt_ClavePuesto.Text = myForm.Campo1
                Txt_DescripPuesto.Text = myForm.Campo2
                If Txt_ClavePuesto.Text.Length = 0 Then
                    Txt_ClavePuesto.Focus()
                End If
            End If

            If Opcion = 3 Then
                Txt_IdConcepto.Text = myForm.Campo
                Txt_DescriConcepto.Text = myForm.Campo1
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub
    Private Sub Txt_ClaveDepto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.LostFocus
        Call traerDepto()
    End Sub

    Private Sub TraerDepto()

        'mreyes 26/Junio/2012 09:27 a.m.
        Try
            If Txt_ClaveDepto.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoDepto(0, Txt_ClaveDepto.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto")
                        Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                        Txt_ClaveDepto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Else
                        Call CargarFormaConsulta("DE", 1)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub TraerConcepto()

        'miguel pérez 05/Septiembre/2012 04:27 p.m.
        Try
            If Txt_IdConcepto.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPercDeduc(0, Txt_IdConcepto.Text, "", "", "", "", "", "", "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
                        Txt_IdConcepto.Text = objDataSet.Tables(0).Rows(0).Item("clave")
                        Txt_DescriConcepto.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Else
                        Call CargarFormaConsulta("PD", 3)
                    End If


                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)

        End Try
    End Sub

    Private Sub Txt_ClaveDepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClaveDepto.TextChanged

    End Sub
    Private Sub TraerPuesto()
        'mreyes 13/Junio/2012 07:03 p.m.
        Try
            If Txt_ClavePuesto.Text.Length = 0 Then Exit Sub
            Using objMySqlGral As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
                Try
                    objDataSet = objMySqlGral.usp_PpalCatalogoPuesto(0, 0, Txt_ClavePuesto.Text, "")
                    If objDataSet.Tables(0).Rows.Count = 1 Then
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
        Call TraerPuesto()
    End Sub

    Private Sub Txt_ClavePuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ClavePuesto.TextChanged

    End Sub

    Private Sub Txt_Sucursal_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Call TraerSucursal()
    End Sub

    Private Sub Txt_IdConcepto_LostFocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_IdConcepto.LostFocus
        Call TraerConcepto()
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


    Private Sub Txt_IdConcepto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_IdConcepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_NombreEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NombreEmpleado.TextChanged

    End Sub

    Private Sub Empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Empleado.Click

    End Sub

    Private Sub Txt_IdEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdEmpleado.TextChanged

    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub
End Class