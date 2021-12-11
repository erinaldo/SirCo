Public Class frmFiltrosEstilosTrackCoqueta
    'mreyes 10/Febrero/2012 06:43 p.m.
    Dim Sql As String
    Public strOpcion As String = "" ''1 = CON EXISTENCIA  2= SIN EXISTENCIA 

    Private objDataSet As Data.DataSet
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False


    Private Sub frmFiltrosEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call GenerarToolTip()
            Call CargaDescripcion(sender, e)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargaDescripcion(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Txt_Marca.Text <> "" Then
                Call Txt_Marca_LostFocus(sender, e)
            End If

            If Txt_Familia.Text <> "" Then
                Call Txt_Familia_LostFocus(sender, e)
            End If

            If Txt_Linea.Text <> "" Then
                Call Txt_Linea_LostFocus(sender, e)
            End If

            If Txt_Proveedor.Text <> "" Then
                Call Txt_Proveedor_LostFocus(sender, e)
            End If

            If Txt_TipoArt.Text <> "" Then
                Call Txt_TipoArt_LostFocus(sender, e)
            End If

            If Txt_Categoria.Text <> "" Then
                Call Txt_Categoria_LostFocus(sender, e)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.GotFocus
        Txt_Familia.SelectAll()
    End Sub

    Private Sub Txt_Familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Familia.KeyPress
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

    Private Sub Txt_Familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.LostFocus
        Try
            If Txt_Familia.Text.Length = 0 Then Exit Sub

            If Txt_Familia.Text.Trim.Length < 3 Then
                Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Familia, Txt_DescripFamilia, "F")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.GotFocus
        Txt_Marca.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            Sw_Filtro = True

            If ValidaFiltros() = True Then
                Sw_Filtro = False
            End If

            Me.Close()
            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_DescripMarca.Text = ""
            Txt_Estilon.Text = ""
            Txt_Estilof.Text = ""

            Txt_Familia.Text = ""
            Txt_DescripFamilia.Text = ""
            Txt_Linea.Text = ""
            Txt_DescripLinea.Text = ""
            Txt_Proveedor.Text = ""
            Txt_Raz_Soc.Text = ""
            Txt_TipoArt.Text = ""
            Txt_DescripTipoArt.Text = ""
            Txt_Categoria.Text = ""
            Txt_DescripCategoria.Text = ""

            'cbo_Clasificacion.Text = ""
            Chk_Track.Checked = True
            Chk_SinTrack.Checked = False
            Chk_Todo.Checked = False

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                If Txt_Marca.Text.Trim.Length < 3 Then
                    Txt_Marca.Text = pub_RellenarIzquierda(Txt_Marca.Text.Trim, 3)
                End If
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Sub


    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.GotFocus
        Txt_Estilon.SelectAll()
    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilon.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub Txt_Estilof_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.GotFocus
        Txt_Estilof.SelectAll()
    End Sub

    Private Sub Txt_Estilof_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Estilof.KeyDown

    End Sub

    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged
        If Txt_Estilof.Text.Length = 14 Then
            Txt_Familia.Focus()
        End If
    End Sub

    Private Sub Txt_Linea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.GotFocus
        Txt_Linea.SelectAll()
    End Sub

    Private Sub Txt_Linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Linea.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Linea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.LostFocus
        Try
            If Txt_Linea.Text.Length = 0 Then Exit Sub
            If Txt_Linea.Text.Trim.Length < 3 Then
                Txt_Linea.Text = pub_RellenarIzquierda(Txt_Linea.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Linea, Txt_DescripLinea, "L")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea.TextChanged
        If Txt_Linea.Text.Length = 3 Then
            Txt_Proveedor.Focus()
        End If
    End Sub

    Private Sub Txt_Proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.GotFocus
        Txt_Proveedor.SelectAll()
    End Sub

    Private Sub Txt_Proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.LostFocus
        Try
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Txt_TipoArt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.GotFocus
        Txt_TipoArt.SelectAll()
    End Sub

    Private Sub Txt_TipoArt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TipoArt.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_TipoArt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.LostFocus
        Try
            If Txt_TipoArt.Text.Length = 0 Then Exit Sub
            Call TxtLostfocus(Txt_TipoArt, Txt_DescripTipoArt, "TA")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Sub Txt_Categoria_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.GotFocus
        Txt_Categoria.SelectAll()
    End Sub

    Private Sub Txt_Categoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Categoria.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub Txt_DescripL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Categoria_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.LostFocus

        Try
            If Txt_Categoria.Text.Length = 0 Then Exit Sub
            If Txt_Categoria.Text.Trim.Length < 3 Then
                Txt_Categoria.Text = pub_RellenarIzquierda(Txt_Categoria.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Categoria, Txt_DescripCategoria, "C")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:49 a.m.
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
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
        Try
            Call LimpiarDatos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmFiltrosArticulosEstructura_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If ValidaFiltros() = True Then
                Sw_Filtro = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub frmFiltrosEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

    End Sub


    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Txt_Estilon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.LostFocus
        If Txt_Estilon.Text.Length > 0 Then
            Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
        End If
    End Sub

    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilon.TextChanged

    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        If Txt_Marca.Text.Length = 3 Then
            Txt_Estilon.Focus()
        End If
    End Sub

    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Familia.TextChanged
        If Txt_Familia.Text.Length = 3 Then
            Txt_Linea.Focus()
        End If
    End Sub

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged
        If Txt_Proveedor.Text.Length = 3 Then
            Txt_TipoArt.Focus()
        End If
    End Sub

    Private Sub Txt_TipoArt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.TextChanged
        If Txt_TipoArt.Text.Length = 1 Then
            Txt_Categoria.Focus()
        End If
    End Sub

    Private Sub Txt_Categoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Categoria.TextChanged

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

    Private Sub Chk_Track_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Track.CheckedChanged
        If Chk_Track.Checked = True Then
            Chk_SinTrack.Checked = False
            Chk_Todo.Checked = False
            strOpcion = "1"
        Else
            strOpcion = ""
        End If
    End Sub

    Private Sub Chk_SinTrack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SinTrack.CheckedChanged
        If Chk_SinTrack.Checked = True Then
            Chk_Track.Checked = False
            Chk_Todo.Checked = False
            strOpcion = "2"
        Else
            strOpcion = ""
        End If
    End Sub

    Private Sub Chk_Todo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_Todo.CheckedChanged
        If Chk_Todo.Checked = True Then
            Chk_Track.Checked = False
            Chk_SinTrack.Checked = False
            strOpcion = ""
        Else
            strOpcion = ""
        End If
    End Sub

    Private Function ValidaFiltros() As Boolean
        ValidaFiltros = True

        If Txt_Marca.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        If Txt_Estilon.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        If Txt_Familia.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        If Txt_Linea.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        If Txt_Proveedor.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        If Txt_TipoArt.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        If Txt_Categoria.Text <> "" Then
            ValidaFiltros = False
            Exit Function
        End If

        'If cbo_Clasificacion.Text <> "" Then
        '    ValidaFiltros = False
        '    Exit Function
        'End If

        If Chk_Track.Checked = True Then
            ValidaFiltros = False
            Exit Function
        End If

        If Chk_SinTrack.Checked = True Then
            ValidaFiltros = False
            Exit Function
        End If

    End Function

    
End Class