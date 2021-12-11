Public Class frmCuponesDet

    Public Tipo As String
    Public IdCupon As Integer
    Public NombreCuponera As String
    Public Accion As Integer

#Region "Metodos"

    Private Function ValidaCupon(Folio As String) As Boolean
        ValidaCupon = False
        Dim objDataSet As DataSet
        Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
            objDataSet = objCupones.usp_TraerFolioCupon(0, Folio, "")
            If objDataSet.Tables(0).Rows.Count = 0 Then
                For i As Integer = 0 To lv_Cupones.ItemCount - 1
                    If Folio = lv_Cupones.Items(i).ToString.Trim Then
                        ValidaCupon = False
                        Exit Function
                    End If
                Next
                ValidaCupon = True
            Else
                ValidaCupon = False
            End If
        End Using
    End Function

#End Region

#Region "Eventos"
    Private Sub frmCuponesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Accion = 1 Then
                lbl_Nombre.Text = NombreCuponera
                lbl_Tipo.Text = "Tipo: " & Tipo
                If Tipo = "UNICO" Then
                    lbl_Cuantos.Visible = False
                    txt_Cuantos.Visible = False
                    txt_Cuantos.Text = 1
                End If
                If Tipo = "MULTIPLE" Then
                    lbl_Cuantos.Visible = True
                    txt_Cuantos.Visible = True
                    txt_Cuantos.Text = ""
                    txt_Cuantos.Focus()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        Try
            If txt_Cuantos.Text.Trim = "" Then
                MessageBox.Show("Por favor indica cuantos registros vas a generar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_Cuantos.Focus()
                Exit Sub
            End If
            If lv_Cupones.Items.Count >= CInt(txt_Cuantos.Text) Then
                MessageBox.Show("Ya generaste " & txt_Cuantos.Text.Trim & " cupones", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_Cuantos.Text = ""
                Exit Sub
            End If
            If txt_Folio.Text.Trim = "" Then
                MessageBox.Show("Debes ingresar un folio de cupón", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            lv_Cupones.Items.Add(txt_Folio.Text.Trim)
            txt_Folio.Text = ""
            If lv_Cupones.Items.Count = CInt(txt_Cuantos.Text) Then
                MessageBox.Show("Ya generaste todos los folios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            txt_Cuantos.Enabled = False
            txt_Folio.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Aleatorio_Click(sender As Object, e As EventArgs) Handles btn_Aleatorio.Click
        Try
            If txt_Cuantos.Text.Trim = "" Then
                MessageBox.Show("Por favor indica cuantos registros vas a generar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_Cuantos.Focus()
                Exit Sub
            End If
            Dim objDataset As DataSet
            Dim FolioCupon As Integer
            Dim Cuantos As Integer
            If lv_Cupones.Items.Count = CInt(txt_Cuantos.Text) Then
                MessageBox.Show("Ya generaste todos los folios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                objDataset = objCupones.usp_TraerFolioOperacion("FOLIOCUPON", "", GLB_Usuario, "CONSULTA")
                If objDataset.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show("No se encontro registros de folios de cupon", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                FolioCupon = CInt(objDataset.Tables(0).Rows(0).Item("folio").ToString.Trim)
                Cuantos = CInt(txt_Cuantos.Text.Trim)
                While Cuantos > 0
                    If ValidaCupon(FolioCupon) = True Then
                        txt_Folio.Text = pub_RellenarIzquierda(FolioCupon, 10)
                        btn_Agregar_Click(sender, e)
                        Cuantos = Cuantos - 1
                    End If
                    FolioCupon = FolioCupon + 1
                End While
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Folio_LostFocus(sender As Object, e As EventArgs) Handles txt_Folio.LostFocus
        Try
            If txt_Folio.Text.Trim = "" Then Exit Sub
            If IsNumeric(txt_Folio.Text) Then
                txt_Folio.Text = pub_RellenarIzquierda(txt_Folio.Text, 10)
            End If
            If ValidaCupon(txt_Folio.Text.Trim) = False Then
                MessageBox.Show("El folio de cupon ingresado ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt_Folio.Text = ""
                txt_Folio.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Generar_Click(sender As Object, e As EventArgs) Handles btn_Generar.Click
        Try
            If lv_Cupones.Items.Count < CInt(txt_Cuantos.Text) Then
                MessageBox.Show("Aún no has generado todos los codigos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If MessageBox.Show("Estas seguro que deseas generar los folios de cupones?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Using objCupones As New BCL.BCLCupones(GLB_ConStringSirCoPVSQL)
                For i As Integer = 0 To lv_Cupones.ItemCount - 1
                    objCupones.usp_CapturaCuponDet(IdCupon, lv_Cupones.Items(i).ToString.Trim, "ACTIVO", GLB_Usuario)
                Next
            End Using
            MessageBox.Show("Se generaron " & txt_Cuantos.Text.Trim & " folios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub btn_Salir_Click(sender As Object, e As EventArgs) Handles btn_Salir.Click
        Me.Close()
    End Sub

    Private Sub txt_Cuantos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Cuantos.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

#End Region

End Class