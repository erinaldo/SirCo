

Imports DevExpress.XtraEditors
Imports System.Drawing

Public Class frmProducts
    'mreyes 20/Marzo/2018   05:23 p.m.
    Public Accion As Integer = 2
    Public Cliente_Id As String

    Private Sub frmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Call usp_TraerColoresDevexpress(Cbo_Color1, 1)
            Call usp_TraerColoresDevexpress(Cbo_Color2, 1)
            Call usp_TraerMaterialDevexpress(Cbo_Material, 1)

            Call CargarFotoArticulo(Txt_Marca.Text, Txt_Modelo.Text)

            Call usp_TraerProductsTemp()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub usp_TraerProductsTemp()
        'mreyes 06/Abril/2020   12:22 p.m.


        Dim objDataSet As Data.DataSet
        Dim Image_1 As String = ""
        Dim Image_2 As String = ""
        Dim Image_3 As String = ""
        Dim Image_4 As String = ""
        Dim Image_5 As String = ""
        Dim Image_6 As String = ""
        Dim Image_7 As String = ""
        Dim Image_8 As String = ""
        Dim Image_9 As String = ""
        Dim Image_10 As String = ""

        Try

            Using objMySqlGral As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                objDataSet = objMySqlGral.usp_TraerProductsTemp(1, Cliente_Id)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Mem_Descripcion.Text = objDataSet.Tables(0).Rows(0).Item("descripcion").ToString
                    Cbo_Material.Text = objDataSet.Tables(0).Rows(0).Item("material").ToString
                    Cbo_Color1.Text = objDataSet.Tables(0).Rows(0).Item("color").ToString
                    Cbo_Color2.Text = objDataSet.Tables(0).Rows(0).Item("secondary_color").ToString

                    If objDataSet.Tables(0).Rows(0).Item("image_1").ToString <> "" Then
                        Image_1 = Glb_FTP & Cliente_Id & "F1" & ".png"
                        Image_2 = Glb_FTP & Cliente_Id & "F2" & ".png"
                        Image_3 = Glb_FTP & Cliente_Id & "F3" & ".png"
                        Image_4 = Glb_FTP & Cliente_Id & "F4" & ".png"
                        Image_5 = Glb_FTP & Cliente_Id & "F5" & ".png"
                        Image_6 = Glb_FTP & Cliente_Id & "F6" & ".png"
                        Image_7 = Glb_FTP & Cliente_Id & "F7" & ".png"
                        Image_8 = Glb_FTP & Cliente_Id & "F8" & ".png"
                        Image_9 = Glb_FTP & Cliente_Id & "F9" & ".png"
                        Image_10 = Glb_FTP & Cliente_Id & "F10" & ".png"


                        'PBox1.Image.Save(Image_1)
                        'PBox2.Image.Save(Image_2)
                        'PBox3.Image.Save(Image_3)
                        'PBox4.Image.Save(Image_4)
                        'PBox5.Image.Save(Image_5)
                        'PBox6.Image.Save(Image_6)

                        PBox1.Image = New System.Drawing.Bitmap(Image_1)
                        PBox2.Image = New System.Drawing.Bitmap(Image_2)
                        PBox3.Image = New System.Drawing.Bitmap(Image_3)
                        PBox4.Image = New System.Drawing.Bitmap(Image_4)
                        PBox5.Image = New System.Drawing.Bitmap(Image_5)
                        PBox6.Image = New System.Drawing.Bitmap(Image_6)

                        PBox7.Image = New System.Drawing.Bitmap(Image_7)
                        PBox8.Image = New System.Drawing.Bitmap(Image_8)
                        PBox9.Image = New System.Drawing.Bitmap(Image_9)
                        PBox10.Image = New System.Drawing.Bitmap(Image_10)






                    End If

                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"


            PBox.Visible = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    PBox.Visible = True
                    Exit Sub


                End If

                For i As Integer = 1 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        PBox.Visible = True
                        Exit Sub

                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            PBox.Visible = True
                            Exit Sub
                        End If

                    End If
                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_EditValueChanged(sender As Object, e As EventArgs) Handles PBox.EditValueChanged

    End Sub

    Private Sub PBox_DoubleClick(sender As Object, e As EventArgs) Handles PBox.DoubleClick
        'mreyes 20/Marzo/2018 06:07 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Modelo.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_EstiloF_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_EstiloF.EditValueChanged

    End Sub
    Private Function ValidarEdicion()
        Try
            ValidarEdicion = False

            If Mem_Descripcion.Text = "" Then
                MsgBox("No se puede Actualizar el Modelo, Verifique los datos", MsgBoxStyle.Critical, "Error")
                Mem_Descripcion.Focus()
                Exit Function
            End If

            If Cbo_Material.Text = "" Then
                MsgBox("No se puede Actualizar el Modelo, Verifique los datos", MsgBoxStyle.Critical, "Error")
                Cbo_Material.Focus()
                Exit Function
            End If

            If Cbo_Color1.Text = "" Then
                MsgBox("No se puede Actualizar el Modelo, Verifique los datos", MsgBoxStyle.Critical, "Error")
                Cbo_Color1.Focus()
                Exit Function
            End If

            If Cbo_Color2.Text = "" Then
                MsgBox("No se puede Actualizar el Modelo, Verifique los datos", MsgBoxStyle.Critical, "Error")
                Cbo_Color2.Focus()
                Exit Function
            End If


            ValidarEdicion = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub Btn_Aceptar_Click(sender As Object, e As EventArgs) Handles Btn_Aceptar.Click

        'mreyes 21/Marzo/2018   09:56 a.m.
        Try
            Dim Sw_Guardo As Boolean = False
            Dim Image_1 As String = ""
            Dim Image_2 As String = ""
            Dim Image_3 As String = ""
            Dim Image_4 As String = ""
            Dim Image_5 As String = ""
            Dim Image_6 As String = ""
            Dim Image_7 As String = ""
            Dim Image_8 As String = ""
            Dim Image_9 As String = ""
            Dim Image_10 As String = ""


            If Cbo_Color1.Text = "agua" Then

                If MsgBox("Esta seguro de que el color principal es AGUA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            End If


            If Cbo_Color2.Text = "agua" Then

                If MsgBox("Esta seguro de que el color secundario es AGUA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            End If

            If Chk_Fotos.Checked = True Then

                Image_1 = Glb_FTP & Cliente_Id & "F1" & ".png"
                Image_2 = Glb_FTP & Cliente_Id & "F2" & ".png"
                Image_3 = Glb_FTP & Cliente_Id & "F3" & ".png"
                Image_4 = Glb_FTP & Cliente_Id & "F4" & ".png"
                Image_5 = Glb_FTP & Cliente_Id & "F5" & ".png"
                Image_6 = Glb_FTP & Cliente_Id & "F6" & ".png"
                Image_7 = Glb_FTP & Cliente_Id & "F7" & ".png"
                Image_8 = Glb_FTP & Cliente_Id & "F8" & ".png"
                Image_9 = Glb_FTP & Cliente_Id & "F9" & ".png"
                Image_10 = Glb_FTP & Cliente_Id & "F10" & ".png"


                PBox1.Image.Save(Image_1)
                PBox2.Image.Save(Image_2)
                PBox3.Image.Save(Image_3)
                PBox4.Image.Save(Image_4)
                PBox5.Image.Save(Image_5)
                PBox6.Image.Save(Image_6)

                PBox7.Image.Save(Image_7)
                PBox8.Image.Save(Image_8)
                PBox9.Image.Save(Image_9)
                PBox10.Image.Save(Image_10)



            End If
            '  PBox7.Image.Save(Image_7)



            'PBox1.Image.Save("c:\windows\fotos\" & Cliente_Id & "F1" & ".jpg")
            'PBox2.Image.Save(("c:\windows\fotos\" & Cliente_Id & "F2" & ".jpg"))
            'PBox3.Image.Save(("c:\windows\fotos\" & Cliente_Id & "F3" & ".jpg"))
            'PBox4.Image.Save(("c:\windows\fotos\" & Cliente_Id & "F4" & ".jpg"))
            'PBox5.Image.Save(("c:\windows\fotos\" & Cliente_Id & "F5" & ".jpg"))
            'PBox6.Image.Save(("c:\windows\fotos\" & Cliente_Id & "F6" & ".jpg"))
            'PBox7.Image.Save(("c:\windows\fotos\" & Cliente_Id & "F7" & ".jpg"))

            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F1" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")
            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F2" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")
            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F3" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")
            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F4" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")
            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F5" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")
            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F6" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")
            'My.Computer.Network.UploadFile("c:\windows\fotos\" & Cliente_Id & "F7" & ".jpg", Image_1, "u81839252-credito", "ZT_Sirco33")

            If Accion = 2 Then ' es una actualización
                If ValidarEdicion() = False Then Exit Sub
                ' If MsgBox("Estas Seguro de Actualizar los Permisos?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Using objUsuario As New BCL.BCLVentaEnLinea(GLB_ConStringSirCoVentaEnLineaSQL)
                    Sw_Guardo = objUsuario.usp_Captura_Products(Accion, Cliente_Id, Txt_Titulo.Text, Mem_Descripcion.Text, Cbo_Color1.Text, Cbo_Color2.Text, Cbo_Material.Text, Image_1, Image_2, Image_3, Image_4, Image_5, Image_6, Image_7, Image_8, Image_9, Image_10, GLB_Idempleado)
                End Using

                Sw_Guardo = True
                GLB_RefrescarPedido = True
                MsgBox("Modelo Actualizado Correctamente", MsgBoxStyle.Information, "Confirmación")
                Me.Close()
                Me.Dispose()
                'End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox1_EditValueChanged(sender As Object, e As EventArgs) Handles PBox1.EditValueChanged

    End Sub

    Private Sub Mem_Descripcion_EditValueChanged(sender As Object, e As EventArgs) Handles Mem_Descripcion.EditValueChanged

    End Sub

    Private Sub Cbo_Color2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_Color2.SelectedIndexChanged

    End Sub

    Private Sub Pnl_Editar_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Editar.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class