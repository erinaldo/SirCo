Public Class frmCatalogoCorrida
    Private objDataSetSuc As Data.DataSet
    Private objDataSet As Data.DataSet
    Private objDataSet2 As Data.DataSet
    Public Marca As String
    Public Modelo As String
    Public Corrida As String

    Public Estilof As String
    Public Color As String
    Public Talla As Decimal
    Public Archivo As Image
    Dim peso As Decimal
    Dim alto As Decimal
    Dim frente As Decimal
    Dim fondo As Decimal
    Dim mat As String = ""
    Dim idmatsuela As Integer
    Dim idmatcalzado As Integer
    ''Dim corrida As String
    Public Function Capturar(ByVal marca As String, ByVal estilon As Integer, ByVal corrida As String, ByVal peso As Decimal, ByVal alto As Decimal,
                               ByVal frente As Decimal, ByVal fondo As Decimal, ByVal matsuela As Integer, ByVal matcal As Integer)
        Try
            Using objeto As New BCL.BCLCatalogoCorrida(GLB_ConStringSirCoSQL)
                Capturar = objeto.usp_Captura_Corrida(marca, estilon, corrida, peso, alto, frente, fondo, matsuela, matcal)
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Function Capturar2(ByVal marca As String, ByVal estilon As String, ByVal corrida As String, ByVal peso As Decimal, ByVal alto As Decimal,
                               ByVal frente As Decimal, ByVal fondo As Decimal, ByVal matsuela As Integer, ByVal matcal As Integer)
        Try
            Using objeto As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                Capturar2 = objeto.usp_Captura_CorridaMedidas(1, marca, estilon, corrida, peso, alto, frente, fondo, matsuela, matcal, GLB_Idempleado)
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub frmRegistrarCorrida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label1.Text = "Marca: " & Marca
            Label2.Text = "Modelo: " & Modelo
            Label3.Text = "Estilo F: " & Estilof
            Label4.Text = "Descripcion: " & Color
            Label5.Text = "Talla: " & Talla
            PictureBox1.Image = Archivo
            Call usp_TraerMaterial()
            Call usp_TraerCorrida(Marca, Modelo, Corrida)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerMaterial()
        Try
            Using objCatalogoEst As New BCL.BCLCatalogoCorrida(GLB_ConStringSircoControlSQL)
                objDataSet = objCatalogoEst.usp_TraerMaterial(mat)
                For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                    cb_mcalzado.Items.Add(objDataSet.Tables(0).Rows(i).Item("material"))
                    cb_Msuela.Items.Add(objDataSet.Tables(0).Rows(i).Item("material"))
                Next
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub usp_TraerCorrida(ByVal Marca As String, ByVal Estilon As String, Corrida As String)
        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilos.usp_TraerCorrida(Marca, Estilon, Corrida, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    txt_Peso.Text = objDataSet.Tables(0).Rows(0).Item("pesocaja")
                    txt_Alto.Text = objDataSet.Tables(0).Rows(0).Item("alto")
                    txt_Fondo.Text = objDataSet.Tables(0).Rows(0).Item("fondo")
                    txt_Frente.Text = objDataSet.Tables(0).Rows(0).Item("frente")
                    cb_Msuela.Text = objDataSet.Tables(0).Rows(0).Item("materialsuela")
                    cb_mcalzado.Text = objDataSet.Tables(0).Rows(0).Item("materialcalzado")
                    txt_Corrida.Text = objDataSet.Tables(0).Rows(0).Item("corrida")


                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click 'GLB_ConStringCipSis
        Try
            If txt_Peso.Text = "" Or txt_Frente.Text = "" Or txt_Corrida.Text = "" Or txt_Fondo.Text = "" Or txt_Alto.Text = "" Or cb_Msuela.Text = "" Or cb_mcalzado.Text = "" Then
                MsgBox("Todos los campos son obligatorios", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "ERROR")
            Else
                If MsgBox("Esta seguro de que desea guardar esta corrida?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    Using objCatalogoEst As New BCL.BCLCatalogoCorrida(GLB_ConStringSircoControlSQL)
                        objDataSet = objCatalogoEst.usp_TraerMaterial(cb_mcalzado.Text)
                        idmatcalzado = objDataSet.Tables(0).Rows(0).Item("idmaterial")
                        objDataSet2 = objCatalogoEst.usp_TraerMaterial(cb_Msuela.Text)
                        idmatsuela = objDataSet2.Tables(0).Rows(0).Item("idmaterial")
                    End Using
                    corrida = txt_Corrida.Text
                    peso = txt_Peso.Text
                    alto = txt_Alto.Text
                    frente = txt_Frente.Text
                    fondo = txt_Fondo.Text
                    Capturar(Marca, Modelo, corrida, peso, alto, frente, fondo, idmatsuela, idmatcalzado)
                    Capturar2(Marca, Modelo, corrida, peso, alto, frente, fondo, idmatsuela, idmatcalzado)
                    Me.Close()
                Else
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub cb_Msuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Msuela.SelectedIndexChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Modelo
            myForm.Txt_Marca.Text = Marca
            myForm.PBox.Image = PictureBox1.Image
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub txt_Corrida_TextChanged(sender As Object, e As EventArgs) Handles txt_Corrida.TextChanged
        txt_Corrida.Text = StrConv(Me.txt_Corrida.Text, vbUpperCase)
    End Sub

    Private Sub txt_Peso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Peso.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub txt_Alto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Alto.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub txt_Frente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Frente.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub txt_Fondo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Fondo.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
            If Asc(e.KeyChar) = 46 Then
                e.Handled = False   ' <<< Para que admita el punto.
            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cb_Msuela_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_Msuela.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_mcalzado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_mcalzado.KeyPress
        If Not Char.IsLetter(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmCatalogoCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class