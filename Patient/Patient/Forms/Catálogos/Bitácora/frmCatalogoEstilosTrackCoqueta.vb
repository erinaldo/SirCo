Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing.Imaging

Public Class frmCatalogoEstilosTrackCoqueta
    'Tony Garcia - 16/Febrero/2013 - 12:10 p.m. 

    Dim Sql As String
    Dim intCantArticulos As Integer = 0

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Private mousePath As System.Drawing.Drawing2D.GraphicsPath

    Dim MarcaB As String
    Dim FamiliaB As String
    Dim LineaB As String
    Dim ProveedorB As String
    Dim CategoriaB As String
    Dim TipoArtB As String
    Dim ClasifB As String
    Dim EstilonB As String
    Dim EstilofB As String
    Dim blnAbortar As Boolean = False
    Dim Opcion As String  '1 = Track   2 = Sin track  "" = Todos

    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim myForm As New frmCatalogoTrackCoqueta


    Private Sub frmCatalogoFotos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LimpiarDatos()
            ClearMemory()
            ClasifB = "INSERT INTO clasificacion (clasifica) VALUES ('B'),('T'),('D'),('P');"
            Call GeneraLabelFiltros()
            Call TraerArticulos()

            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Opcion = "1"
            MarcaB = "CTA"
            EstilonB = ""
            EstilofB = ""
            FamiliaB = ""
            LineaB = ""
            ProveedorB = ""
            CategoriaB = ""
            TipoArtB = ""
            ClasifB = ""

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TraerArticulos()
        Using objArticulos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Panel1.AutoScroll = False
                PBar.Visible = True
                Txt_Porc.Visible = True

                ClearMemory()

                objDataSet = objArticulos.usp_TraerEstilosTrackCoqueta(MarcaB, EstilonB, EstilofB, FamiliaB, LineaB, ProveedorB, CategoriaB, _
                                                                     TipoArtB, ClasifB, Opcion)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    intCantArticulos = objDataSet.Tables(0).Rows.Count
                    blnAbortar = False
                    Call GeneraComponentesDinamicos()
                    'Me.Pnl_Imagenes.HorizontalScroll.Visible = True
                    Panel1.AutoScroll = True
                Else
                    MessageBox.Show("No se encontro información con los filtros deseados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Panel1.Controls.Clear()
                    PBar.Value = 0
                    Txt_Porc.Text = ""
                End If

                PBar.Visible = False
                Txt_Porc.Visible = False

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Public Function nuevaResolucion(ByVal RutaImg As String, ByVal resolucion As Integer) As Image
        Dim Imagen As New System.Drawing.Bitmap(RutaImg)

        Dim reduction As Double = 320
        Dim reduction2 As Double = 300
        Dim ImageFinal As New Bitmap(Imagen, reduction, reduction2)

        Using nuevaImage As New Bitmap(Imagen.Width, Imagen.Height, Imagen.PixelFormat)

            Try
                nuevaImage.SetResolution(resolucion, resolucion)

                Using g As Graphics = Graphics.FromImage(nuevaImage)
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic
                    g.DrawImage(ImageFinal, 0, 0)
                End Using

                ClearMemory()
                System.GC.Collect()


                ''''''''''''''''''''''''''''''
                Dim imageArray As Byte()
                Dim originalImage As Image = ImageFinal

                Using stream As MemoryStream = New MemoryStream()
                    originalImage.Save(stream, ImageFormat.Jpeg)
                    imageArray = stream.ToArray
                End Using
                '''''''''''''''''''''''''''''

                '''''''
                Dim imageArray1 As Byte() = imageArray
                Dim reconstitutedImage As Image

                Using stream As MemoryStream = New MemoryStream(imageArray, 0, imageArray.Length)
                    stream.Write(imageArray, 0, imageArray.Length)
                    reconstitutedImage = Image.FromStream(stream)
                End Using
                ''''''''

                ClearMemory()
                System.GC.Collect()
                ''''''
                Return reconstitutedImage
                '''''''

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    'Funcion de liberacion de memoria
    Public Sub ClearMemory()
        Try
            Dim Mem As Process

            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch ex As Exception
            'Control de errores
        End Try
    End Sub

    ''Método para crear PictureBox y Labels con imagen y descripción del articulo
    Private Sub GeneraComponentesDinamicos()

        Dim Archivo As String = ""
        Dim NoFoto As String = "1"
        Dim intSig As Integer
        Dim Sw_NoEncontro As Boolean = False
        Dim xPB As Integer = 2
        Dim yPB As Integer = 2
        Dim xLb As Integer = 2
        Dim yLb As Integer = 150
        Try
            Me.Panel1.Controls.Clear()

            Application.DoEvents()
            PBar.Minimum = 0
            PBar.Maximum = intCantArticulos
            PBar.Value = 0
            Dim Cont As Integer = intCantArticulos
            Dim contador As Integer = 0
            Dim ContadorAux As Integer = 0
            For i As Integer = 0 To intCantArticulos - 1
                If blnAbortar = True Then Exit Sub
                
                System.GC.Collect()

                

                'For j As Integer = i To intMenorPBox

                If contador = 6 Then
                    xPB = 2
                    yPB += 315
                    contador = 0
                End If
                contador += 1
                PBar.Value = PBar.Value + 1
                Application.DoEvents()

                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    Dim PBoxFoto As New PictureBox
                    PBoxFoto.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilon")
                    Dim Imagen As Image
                    'If objDataSet.Tables(0).Rows(i).Item("estilon") = "    559" Then
                    '    MsgBox("hola")
                    'End If
                    Dim cms As New ContextMenuStrip
                    cms.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilon")
                    'cms.Items.Add("Trac")
                    'cms.Show()

                    PBoxFoto.ContextMenuStrip = cms
                    If Opcion = "1" Then
                        cms.Items.Add("Trac")
                        AddHandler cms.Click, AddressOf AbrirExistencias_Click
                    ElseIf Opcion = "2" Then
                        cms.Items.Add("Agregar Trac")
                        AddHandler cms.Click, AddressOf NuevoTrac_Click
                    ElseIf Opcion = "" And objDataSet.Tables(0).Rows(i).Item("estatus").ToString.Trim <> "" Then
                        cms.Items.Add("Trac")
                        AddHandler cms.Click, AddressOf AbrirExistencias_Click
                    ElseIf Opcion = "" And objDataSet.Tables(0).Rows(i).Item("estatus").ToString.Trim = "" Then
                        cms.Items.Add("Agregar Trac")
                        AddHandler cms.Click, AddressOf NuevoTrac_Click
                   
                    End If
                    cms.Items(0).Image = My.Resources.alcance_de_metas
                    AddHandler PBoxFoto.DoubleClick, AddressOf AbrirFoto_Click
                    AddHandler PBoxFoto.Click, AddressOf MandarFocusFLPanel_Click

                    intSig = i
                    PBoxFoto.Size = New Size(170, 140)
                    PBoxFoto.BorderStyle = BorderStyle.FixedSingle
                    Me.Panel1.Controls.Add(PBoxFoto)
                    PBoxFoto.Location = New System.Drawing.Point(xPB, yPB)
                    xPB += 175
                    ClearMemory()
                    System.GC.Collect()

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, objDataSet.Tables(0).Rows(i).Item("marca"), objDataSet.Tables(0).Rows(i).Item("estilon"), NoFoto)
                    'Txt_NoFoto.Text = NoFoto
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True

                        Imagen = New System.Drawing.Bitmap(Archivo)

                        ClearMemory()
                        System.GC.Collect()

                        If Imagen.Width > 1500 Or Imagen.Height > 1000 Then
                            PBoxFoto.Image = nuevaResolucion(Archivo, 800)
                        Else
                            PBoxFoto.Image = New System.Drawing.Bitmap(Archivo)
                        End If

                        PBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage

                        'Continue For
                    Else
                        Archivo = GLB_RutaArchivoFotos & "\no_disponible.jpg"

                        Imagen = New System.Drawing.Bitmap(Archivo)

                        ClearMemory()
                        System.GC.Collect()

                        If Imagen.Width > 1500 Or Imagen.Height > 1000 Then
                            PBoxFoto.Image = nuevaResolucion(Archivo, 800)
                        Else
                            PBoxFoto.Image = New System.Drawing.Bitmap(Archivo)
                        End If

                        PBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage

                    End If

                    ClearMemory()
                    System.GC.Collect()

                    If Sw_NoEncontro = False Then
                        NoFoto = "1"
                    End If

                    PBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage
                    PBoxFoto.Enabled = True

                End Using
                'Next


                Dim LblArticulo As New RichTextBox
                Dim strClasif As String = ""
                Dim strTrack As String = "               TRAC                   " & vbCrLf
                If ContadorAux = 6 Then
                    xLb = 2
                    yLb += 315
                    ContadorAux = 0
                End If
                ContadorAux += 1
                
                If Opcion = "1" Then
                    strTrack = "               TRAC                   " & vbCrLf

                ElseIf Opcion = "2" Then
                    strTrack = ""

                ElseIf Opcion = "" Then
                    If IsDBNull(objDataSet.Tables(0).Rows(i).Item("estatus")) Then
                        strTrack = ""
                    Else
                        strTrack = "               TRAC                   " & vbCrLf
                    End If
                End If

                If objDataSet.Tables(0).Rows(i).Item("artcat").ToString = "B" Then
                    strClasif = "               BASICOS              "
                ElseIf objDataSet.Tables(0).Rows(i).Item("artcat").ToString = "T" Then
                    strClasif = "            TEMPORADA          "
                ElseIf objDataSet.Tables(0).Rows(i).Item("artcat").ToString = "D" Then
                    strClasif = "       DESCONTINUADOS       "
                End If

                Dim objDataSetAux As DataSet
                Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                    objDataSetAux = objCorrida.usp_TraerCorrida("", objDataSet.Tables(0).Rows(i).Item("marca").ToString, objDataSet.Tables(0).Rows(i).Item("estilon").ToString, "", "")
                End Using
                Dim Corridas As String = ""

                If objDataSetAux.Tables(0).Rows.Count > 0 Then
                    For m As Integer = 0 To objDataSetAux.Tables(0).Rows.Count - 1
                        If m > 0 Then
                            Corridas += "               "
                        End If
                        If m = objDataSetAux.Tables(0).Rows.Count - 1 Then
                            Corridas += objDataSetAux.Tables(0).Rows(m).Item("medini").ToString & " / " & objDataSetAux.Tables(0).Rows(m).Item("medfin").ToString
                        Else
                            Corridas += objDataSetAux.Tables(0).Rows(m).Item("medini").ToString & " / " & objDataSetAux.Tables(0).Rows(m).Item("medfin").ToString & vbCrLf
                        End If
                    Next
                End If

                LblArticulo.Text = "Marca: " + objDataSet.Tables(0).Rows(i).Item("marca").ToString & vbCrLf _
                 + "Modelo: " + objDataSet.Tables(0).Rows(i).Item("estilon").ToString.Trim & vbCrLf _
                 + "Estilo: " + objDataSet.Tables(0).Rows(i).Item("estilof").ToString.Trim & vbCrLf _
                 + "Descripción : " + objDataSet.Tables(0).Rows(i).Item("descripc").ToString & vbCrLf _
                 + "Corridas: " + Corridas & vbCrLf _
                 + "Costo: " & Format(Val(objDataSet.Tables(0).Rows(i).Item("costo").ToString), "$###,##0.00") & vbCrLf _
                 + "Precio: " & Format(Val(objDataSet.Tables(0).Rows(i).Item("precio").ToString), "$###,##0.00") & vbCrLf _
                 + ""
                'End If

                LblArticulo.BorderStyle = BorderStyle.FixedSingle
                LblArticulo.Width = 170
                LblArticulo.Height = 160
                ''''
                LblArticulo.BorderStyle = BorderStyle.None
                LblArticulo.ReadOnly = True

                LblArticulo.Select(LblArticulo.TextLength, 0)
                LblArticulo.SelectionBackColor = Color.Aqua
                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.AppendText(strTrack)

                LblArticulo.Select(LblArticulo.TextLength, 0)
                If strClasif = "               BASICOS              " Then
                    LblArticulo.SelectionBackColor = Color.YellowGreen
                ElseIf strClasif = "            TEMPORADA          " Then
                    LblArticulo.SelectionBackColor = Color.Yellow
                ElseIf strClasif = "       DESCONTINUADOS       " Then
                    LblArticulo.SelectionBackColor = Color.Red
                End If

                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.AppendText(strClasif)


                Me.Panel1.Controls.Add(LblArticulo)
                LblArticulo.Location = New System.Drawing.Point(xLb, yLb)
                xLb += 175
                AddHandler LblArticulo.Click, AddressOf MandarFocusFLPanel_Click
                'Next

                i = intSig

                Txt_Porc.Text = i + 1 & " de " & Cont

                ClearMemory()
                System.GC.Collect()
            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub AbrirExistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            myForm = New frmCatalogoTrackCoqueta
            Dim nombre As String = ""
            Dim Marca As String
            Dim Estilon As String
            myForm.DGrid.Visible = False
            Dim Menu As ContextMenuStrip = sender

            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Menu.SourceControl) Then
                    Dim nom As String = Menu.SourceControl.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5, 7)
            myForm.Opcion = 1
            myForm.Accion = 1
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_Estilon.Text = Estilon

            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub NuevoTrac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            myForm = New frmCatalogoTrackCoqueta
            Dim nombre As String = ""
            Dim Marca As String
            Dim Estilon As String

            Dim Menu As ContextMenuStrip = sender

            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Menu.SourceControl) Then
                    Dim nom As String = Menu.SourceControl.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5, 7)
            Using objCorrida As New BCL.BCLTrackCoqueta(GLB_ConStringCipSis)
                objDataSet = objCorrida.usp_TraerTrackCta(Marca, Estilon, "")
            End Using
            If objDataSet.Tables(0).Rows.Count = 0 Then
                myForm.Opcion = 2
                myForm.Accion = 2
                myForm.DGrid.Visible = True
            Else
                myForm.Opcion = 1
                myForm.Accion = 1
                myForm.DGrid.Visible = False
            End If
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_Estilon.Text = Estilon

            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub AbrirFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmConsultaImagen
            Dim nombre As String = ""
            Dim Marca As String
            Dim Estilon As String

            Dim PBox As PictureBox = sender

            If Not IsDBNull(Menu) Then
                If Not IsDBNull(PBox) Then
                    Dim nom As String = PBox.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5, 7)

            myForm.Txt_Estilon.Text = Estilon
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_NoFoto.Text = "1"

            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub MandarFocusFLPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Panel1.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoFotos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then

                If MessageBox.Show("Desea salir del Catálogo de Estilos Coqueta(Trac)?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Abortar, "Detener la carga de las imagenes")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Filtro, "Seleccionar Filtros")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Try
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        Try
            Dim myForm As New frmFiltrosEstilosTrackCoqueta

            myForm.Txt_Marca.Text = MarcaB
            myForm.Txt_Estilon.Text = EstilonB
            myForm.Txt_Estilof.Text = EstilofB
            myForm.Txt_Familia.Text = FamiliaB
            myForm.Txt_Linea.Text = LineaB
            myForm.Txt_Proveedor.Text = ProveedorB
            myForm.Txt_Categoria.Text = CategoriaB
            myForm.Txt_TipoArt.Text = TipoArtB


            'If ClasifB <> "" Then
            '    If ClasifB = "B" Then
            '        myForm.cbo_Clasificacion.Text = "BASICOS"
            '    ElseIf ClasifB = "T" Then
            '        myForm.cbo_Clasificacion.Text = "TEMPORADA"
            '    ElseIf ClasifB = "D" Then
            '        myForm.cbo_Clasificacion.Text = "DESCONTINUADOS"
            '    ElseIf ClasifB = "P" Then
            '        myForm.cbo_Clasificacion.Text = "PRUEBA"
            '    End If
            'End If

            If Opcion <> "" Then
                If Opcion = "1" Then
                    myForm.Chk_Track.Checked = True
                    myForm.Chk_SinTrack.Checked = False
                    myForm.Chk_Todo.Checked = False
                ElseIf Opcion = "2" Then
                    myForm.Chk_SinTrack.Checked = True
                    myForm.Chk_Track.Checked = False
                    myForm.Chk_Todo.Checked = False
                ElseIf Opcion = "" Then
                    myForm.Chk_SinTrack.Checked = False
                    myForm.Chk_Track.Checked = False
                    myForm.Chk_Todo.Checked = True
                End If
            End If


            myForm.ShowDialog()

            MarcaB = myForm.Txt_Marca.Text
            EstilonB = myForm.Txt_Estilon.Text
            EstilofB = myForm.Txt_Estilof.Text
            FamiliaB = myForm.Txt_Familia.Text
            LineaB = myForm.Txt_Linea.Text
            ProveedorB = myForm.Txt_Proveedor.Text
            CategoriaB = myForm.Txt_Categoria.Text
            TipoArtB = myForm.Txt_TipoArt.Text

            ClasifB = ""
            If myForm.Chk_Basicos.Checked = True Then
                ClasifB += "('B'),"
            End If
            If myForm.Chk_Temporada.Checked = True Then
                ClasifB += "('T'),"
            End If
            If myForm.Chk_Descontinuados.Checked = True Then
                ClasifB += "('D'),"
            End If
            If myForm.Chk_Prueba.Checked = True Then
                ClasifB += "('P'),"
            End If
            If ClasifB = "" Then
                ClasifB = "INSERT INTO clasificacion (clasifica) VALUES ('B'),('T'),('D'),('P');"
            Else
                ClasifB = ClasifB.Substring(0, ClasifB.Length - 1)
                ClasifB = "INSERT INTO clasificacion (clasifica) VALUES " + ClasifB + ";"
            End If
            Opcion = myForm.strOpcion

            If myForm.Sw_Filtro = True Then
                Call GeneraLabelFiltros()
                Call TraerArticulos()
            Else
                'Me.FLPanel_Img.Controls.Clear()
                'PBar.Value = 0
                'Txt_Porc.Text = ""
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub FLPanel_Img_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Panel1.Focus()
    End Sub

    Private Sub FLPanel_Img_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Panel1.Focus()
    End Sub

    Private Sub GeneraLabelFiltros()
        'Dim strFiltros As String = ""
        Lbl_Filtros.Text = "Filtros: "
        Try
            If MarcaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Marca: " + MarcaB + ", "
            End If

            If EstilonB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Modelo: " + EstilonB + ", "
            End If

            If EstilofB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Estilo: " + EstilofB + ", "
            End If

            If FamiliaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Familia: " + FamiliaB + ", "
            End If

            If LineaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Linea: " + LineaB + ", "
            End If

            If ProveedorB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Proveedor: " + ProveedorB + ", "
            End If

            If CategoriaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Categoría: " + CategoriaB + ", "
            End If

            If TipoArtB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " TipoArt: " + TipoArtB + ", "
            End If

            If ClasifB <> "" Then
                If ClasifB = "B" Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " Clasif: " + "BASICOS" + ", "
                ElseIf ClasifB = "T" Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " Clasif: " + "TEMPORADA" + ", "
                ElseIf ClasifB = "D" Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " Clasif: " + "DESCONTINUADOS" + ", "
                ElseIf ClasifB = "P" Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " Clasif: " + "PRUEBA" + ", "
                End If
            End If

            If Opcion <> "" Then
                If Opcion = 1 Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " CON TRAC" + ", "
                ElseIf Opcion = 2 Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " SIN TRAC" + ", "
                ElseIf Opcion = 3 Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " TODOS" + ", "
                End If

            End If

            If Lbl_Filtros.Text <> "" Then
                Lbl_Filtros.Text = Mid(Lbl_Filtros.Text, 1, Lbl_Filtros.Text.Length - 2)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Abortar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Abortar.Click
        Try
            blnAbortar = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilosTrackCoqueta_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            If myForm.Guardo = True Then
                Call TraerArticulos()
                myForm = New frmCatalogoTrackCoqueta
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class
