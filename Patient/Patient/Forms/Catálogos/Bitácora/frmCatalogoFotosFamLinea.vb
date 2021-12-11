Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing.Imaging

Public Class frmCatalogoFotosFamLinea
    'Tony Garcia - 30/Enero/2013 - 12:10 p.m. 

    Dim Sql As String
    Dim intCantArticulos As Integer = 0

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Private mousePath As System.Drawing.Drawing2D.GraphicsPath

    Dim SucursalB As String
    Dim MarcaB As String
    Dim ModeloB As String
    Dim EstilofB As String
    'Dim DivisionB As Integer
    'Dim DeptoB As Integer
    'Dim FamiliaB As Integer
    'Dim LineaB As Integer
    'Dim IdL1B As Integer
    'Dim IdL2B As Integer
    'Dim IdL3B As Integer 
    'Dim IdL4B As Integer
    'Dim IdL5B As Integer
    'Dim IdL6B As Integer
    Dim DivisionB As String
    Dim DeptoB As String
    Dim FamiliaB As String
    Dim LineaB As String
    Dim IdL1b As String
    Dim IdL2b As String
    Dim IdL3b As String
    Dim IdL4b As String
    Dim IdL5b As String
    Dim IdL6b As String
    Dim ProveedorB As String
    Dim CostoIniB As Decimal
    Dim CostoFinB As Decimal
    Dim PrecioIniB As Decimal
    Dim PrecioFinB As Decimal
    Dim MedidaIniB As String
    Dim MedidaFinB As String
    Dim EstatusB As String
    Dim RecibidoB As String = "1"

    Dim cveDivisionb As String = ""
    Dim cveDepartamentob As String = ""
    Dim cveFamiliab As String = ""
    Dim cveLineab As String = ""
    Dim cveL1b As String = ""
    Dim cveL2b As String = ""
    Dim cveL3b As String = ""
    Dim cveL4b As String = ""
    Dim cveL5b As String = ""
    Dim cveL6b As String = ""

    Dim FecRecA As String = ""
    Dim FecRecB As String = ""

    Dim FecEntA As String = ""
    Dim FecEntB As String = ""

    Dim Opcion As String
    Dim OpcionC As String

    Dim blnAbortar As Boolean = False
    Dim SucSelect(50) As String
    Dim IntSelect As Integer = 0
    Dim strSucursales As String
    Dim strClasificacion As String

    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Dim AgrupacionB As Integer = 0



    Private Sub frmCatalogoFotos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            LimpiarDatos()
            ClearMemory()

            Call GeneraLabelFiltros()
            'Call TraerArticulos()

            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub LimpiarDatos()
        Try
            Opcion = 1
            strSucursales = ""
            SucursalB = ""
            MarcaB = ""
            ModeloB = ""
            EstilofB = ""
            DivisionB = ""
            DeptoB = ""
            FamiliaB = ""
            LineaB = ""
            IdL1b = ""
            IdL2b = ""
            IdL3b = ""
            IdL4b = ""
            IdL5b = ""
            IdL6b = ""
            ProveedorB = ""
            CostoIniB = 0.0
            CostoFinB = 0.0
            PrecioIniB = 0.0
            PrecioFinB = 0.0
            MedidaIniB = ""
            MedidaFinB = ""
            EstatusB = ""
            strSucursales = ""
            RecibidoB = ""



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TraerArticulos()
        Using objArticulos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try

                PBar.Visible = True
                Txt_Porc.Visible = True

                ClearMemory()
                Pnl_Img.AutoScroll = False

                If strSucursales <> "" Then
                    Opcion = 2
                Else
                    Opcion = 1
                End If

                If RecibidoB = "0" Then
                    FecRecA = "1900-01-01"
                    FecRecB = "1900-01-01"
                End If

                Me.Cursor = Cursors.WaitCursor

                objDataSet = objArticulos.usp_TraerArticulosEstructura(Opcion, strSucursales, SucursalB, MarcaB, ModeloB, EstilofB, DivisionB, DeptoB, FamiliaB, _
                                                                       LineaB, IdL1b, IdL2b, IdL3b, IdL4b, IdL5b, IdL6b, ProveedorB, CostoIniB, CostoFinB, PrecioIniB, PrecioFinB, _
                                                                       MedidaIniB, MedidaFinB, EstatusB, FecRecA, FecRecB, RecibidoB, FecEntA, FecEntB, AgrupacionB)

                Me.Cursor = Cursors.Default

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    intCantArticulos = objDataSet.Tables(0).Rows.Count
                    blnAbortar = False
                    Call GeneraComponentesDinamicos()
                    'Me.Pnl_Imagenes.HorizontalScroll.Visible = True
                Else
                    Me.Pnl_Img.Controls.Clear()
                    PBar.Value = 0
                    Txt_Porc.Text = ""
                    MessageBox.Show("No se encontraron artículos.", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub AbrirPedidosPend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim myForm As New frmPpalResurtidoAut

            'myForm.MdiParent = BitacoraMain
            'myForm.WindowState = FormWindowState.Maximized
            'myForm.Show()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    ''Método para crear PictureBox y Labels con imagen y descripción del articulo
    Private Sub GeneraComponentesDinamicos()

        Dim Archivo As String = ""
        Dim NoFoto As String = "1"
        Dim intSig As Integer
        'Dim intMenorPBox As Integer
        'Dim intMenorLbl As Integer
        Dim Sw_NoEncontro As Boolean = False
        Dim xPB As Integer = 2
        Dim yPB As Integer = 2
        Dim xLb As Integer = 2
        Dim yLb As Integer = 150

        Try
            Me.Pnl_Img.Controls.Clear()

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

                'intMenorPBox = i + 5
                'If intCantArticulos - 1 < intMenorPBox Then
                '    intMenorPBox = intCantArticulos - 1
                'End If

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
                    PBoxFoto.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("modelo")
                    Dim Imagen As Image

                    Dim cms As New ContextMenuStrip

                    cms.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("modelo")
                    cms.Items.Add("Análisis")
                    cms.Items.Add("Pedidos Pendientes")
                    'cms.Items.Add("Ventas")
                    '''''cms.Show()

                    PBoxFoto.ContextMenuStrip = cms
                    cms.Items(0).Tag = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("modelo")
                    'cms.Items(1).Tag = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("modelo")
                    cms.Items(0).Image = My.Resources.monitoreo
                    cms.Items(1).Image = My.Resources.pendiente
                    AddHandler cms.Items(0).Click, AddressOf AbrirExistencias_Click
                    AddHandler cms.Items(1).Click, AddressOf AbrirPedidosPend_Click
                   
                    AddHandler PBoxFoto.DoubleClick, AddressOf AbrirFoto_Click
                    AddHandler PBoxFoto.Click, AddressOf MandarFocusFLPanel_Click

                    intSig = i
                    PBoxFoto.Size = New Size(170, 140)
                    PBoxFoto.BorderStyle = BorderStyle.FixedSingle
                    Me.Pnl_Img.Controls.Add(PBoxFoto)
                    PBoxFoto.Location = New System.Drawing.Point(xPB, yPB)
                    xPB += 175

                    ClearMemory()
                    System.GC.Collect()

                    For pic As Integer = 0 To 9
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, objDataSet.Tables(0).Rows(i).Item("marca"), objDataSet.Tables(0).Rows(i).Item("modelo"), pic)
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

                            Exit For

                        Else

                            Archivo = GLB_RutaArchivoFotos + "\no_disponible.jpg"

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
                    Next


                    'End If

                    ClearMemory()
                    System.GC.Collect()

                    If Sw_NoEncontro = False Then
                        NoFoto = "1"
                    End If

                    PBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage
                    PBoxFoto.Enabled = True

                End Using

                'For l As Integer = intSig + 1 To intMenorLbl
                Dim LblArticulo As New RichTextBox
                Dim strPrecioDesc As String = "Precio Desc: "
                Dim strClasif As String = ""

                If ContadorAux = 6 Then
                    xLb = 2
                    yLb += 315
                    ContadorAux = 0
                End If
                ContadorAux += 1

                If IsDBNull(objDataSet.Tables(0).Rows(i).Item("precdesc")) Then
                    strPrecioDesc = ""
                Else
                    strPrecioDesc = strPrecioDesc + Format(Val(objDataSet.Tables(0).Rows(i).Item("precdesc").ToString), "$###,##0.00") + vbCrLf
                End If

                'If objDataSet.Tables(0).Rows(i).Item("artcat").ToString = "B" Then
                '    strClasif = "               BASICOS              "
                'ElseIf objDataSet.Tables(0).Rows(i).Item("artcat").ToString = "T" Then
                '    strClasif = "            TEMPORADA          "
                'ElseIf objDataSet.Tables(0).Rows(i).Item("artcat").ToString = "D" Then
                '    strClasif = "      DESCONTINUADOS      "
                'End If


                Dim objDataSetAux As DataSet
                Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                    objDataSetAux = objCorrida.usp_TraerCorrida2(objDataSet.Tables(0).Rows(i).Item("marca").ToString, objDataSet.Tables(0).Rows(i).Item("modelo").ToString, "", "")
                End Using
                Dim Corridas As String = ""


                If GLB_Sw_Costos = True Then
                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                        For m As Integer = 0 To objDataSetAux.Tables(0).Rows.Count - 1
                            If m > 0 Then
                                Corridas += ""
                            End If
                            If m = objDataSetAux.Tables(0).Rows.Count - 1 Then
                                Corridas += objDataSetAux.Tables(0).Rows(m).Item("medini").ToString & " / " & objDataSetAux.Tables(0).Rows(m).Item("medfin").ToString _
                                & "  |  " & Format(Val(objDataSetAux.Tables(0).Rows(m).Item("costo").ToString), "$###,##0.00") _
                                & "  |  " & Format(Val(objDataSetAux.Tables(0).Rows(m).Item("precio").ToString), "$###,##0.00")
                            Else
                                Corridas += objDataSetAux.Tables(0).Rows(m).Item("medini").ToString & " / " & objDataSetAux.Tables(0).Rows(m).Item("medfin").ToString _
                                & "  |  " & Format(Val(objDataSetAux.Tables(0).Rows(m).Item("costo").ToString), "$###,##0.00") _
                                & "  |  " & Format(Val(objDataSetAux.Tables(0).Rows(m).Item("precio").ToString), "$###,##0.00") & vbCrLf
                            End If
                        Next
                    End If

                    LblArticulo.Text = "Marca: " + objDataSet.Tables(0).Rows(i).Item("marca").ToString & vbCrLf _
                     + "Modelo: " + objDataSet.Tables(0).Rows(i).Item("modelo").ToString.Trim & vbCrLf _
                     + "EstiloF: " + objDataSet.Tables(0).Rows(i).Item("estilof").ToString.Trim & vbCrLf _
                     + "Descripción : " + objDataSet.Tables(0).Rows(i).Item("descripc").ToString & vbCrLf _
                     + "Corridas:  |  Costo:   |   Precio: " & vbCrLf _
                     + Corridas & vbCrLf _
                    ' + "Costo: " & Format(Val(objDataSet.Tables(0).Rows(i).Item("costo").ToString), "$###,##0.00") & vbCrLf _
                    '  + "Precio: " & Format(Val(objDataSet.Tables(0).Rows(i).Item("precio").ToString), "$###,##0.00") & vbCrLf _
                    '  + ""


                Else

                    If objDataSetAux.Tables(0).Rows.Count > 0 Then
                        For m As Integer = 0 To objDataSetAux.Tables(0).Rows.Count - 1
                            If m > 0 Then
                                Corridas += ""
                            End If
                            If m = objDataSetAux.Tables(0).Rows.Count - 1 Then
                                Corridas += objDataSetAux.Tables(0).Rows(m).Item("medini").ToString & " / " & objDataSetAux.Tables(0).Rows(m).Item("medfin").ToString _
                                & "     |    " & Format(Val(objDataSetAux.Tables(0).Rows(m).Item("precio").ToString), "$###,##0.00")
                            Else
                                Corridas += objDataSetAux.Tables(0).Rows(m).Item("medini").ToString & " / " & objDataSetAux.Tables(0).Rows(m).Item("medfin").ToString _
                                & "     |    " & Format(Val(objDataSetAux.Tables(0).Rows(m).Item("precio").ToString), "$###,##0.00") & vbCrLf
                            End If
                        Next
                    End If

                    LblArticulo.Text = "Marca: " + objDataSet.Tables(0).Rows(i).Item("marca").ToString & vbCrLf _
                     + "Modelo: " + objDataSet.Tables(0).Rows(i).Item("modelo").ToString.Trim & vbCrLf _
                     + "EstiloF: " + objDataSet.Tables(0).Rows(i).Item("estilof").ToString.Trim & vbCrLf _
                     + "Descripción : " + objDataSet.Tables(0).Rows(i).Item("descripc").ToString & vbCrLf _
                     + "Corridas:    |    Precio: " & vbCrLf _
                     + Corridas & vbCrLf _
                    ' + "Costo: " & Format(Val(objDataSet.Tables(0).Rows(i).Item("costo").ToString), "$###,##0.00") & vbCrLf _
                    '  + "Precio: " & Format(Val(objDataSet.Tables(0).Rows(i).Item("precio").ToString), "$###,##0.00") & vbCrLf _
                    '  + ""

                End If



                LblArticulo.BorderStyle = BorderStyle.FixedSingle
                LblArticulo.Width = 170
                LblArticulo.Height = 160
                ''''
                LblArticulo.BorderStyle = BorderStyle.None
                LblArticulo.ReadOnly = True

                LblArticulo.Select(LblArticulo.TextLength, 0)
                LblArticulo.SelectionBackColor = Color.Yellow
                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.AppendText(strPrecioDesc)


                LblArticulo.Select(LblArticulo.TextLength, 0)
                'If strClasif = "               BASICOS              " Then
                '    LblArticulo.SelectionBackColor = Color.YellowGreen
                'ElseIf strClasif = "            TEMPORADA          " Then
                '    LblArticulo.SelectionBackColor = Color.Yellow
                'ElseIf strClasif = "      DESCONTINUADOS      " Then
                '    LblArticulo.SelectionBackColor = Color.Red
                'End If

                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.AppendText(strClasif)


                Me.Pnl_Img.Controls.Add(LblArticulo)
                LblArticulo.Location = New System.Drawing.Point(xLb, yLb)
                xLb += 175
                AddHandler LblArticulo.Click, AddressOf MandarFocusFLPanel_Click
                'Next

                i = intSig

                Txt_Porc.Text = i + 1 & " de " & Cont

                ClearMemory()
                System.GC.Collect()
            Next

            Pnl_Img.AutoScroll = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub AbrirExistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmAnalisisModelo
            Dim nombre As String = ""
            Dim Marca As String
            Dim Modelo As String

            'Dim Menu As ContextMenuStrip = sender

            Dim Menu As ToolStripMenuItem = sender

            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Menu.Tag) Then
                    Dim nom As String = Menu.Tag
                    nombre = nom
                End If
            End If

            'If Not IsDBNull(Menu) Then
            '    If Not IsDBNull(Menu.) Then
            '        Dim nom As String = Menu.SourceControl.Name
            '        nombre = nom
            '    End If
            'End If 

            Marca = Mid(nombre, 1, 3)
            Modelo = Mid(nombre, 5, 7)

            'myForm.Accion = 3
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_Modelo.Text = Modelo
            myForm.Marca = Marca
            myForm.Estilon = Modelo

            If FecEntA <> "" Then
                myForm.FechaInib = FecEntA
                myForm.FechaFinb = FecEntB
            End If
            myForm.Accion = 1

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
            Pnl_Img.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub frmCatalogoFotos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then

                If MessageBox.Show("Desea salir del Catálogo de Estilos por Estructura?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
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
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Filtro, "Seleccionar Filtros")
            ToolTip.SetToolTip(Btn_Abortar, "Detener la carga de las imagenes")
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
            Dim myForm As New frmFiltrosArticulosEstructura

            myForm.Txt_Marca.Text = MarcaB
            myForm.Txt_Modelo.Text = ModeloB
            myForm.Txt_Estilof.Text = EstilofB
            myForm.Txt_DescripDivision.Text = DivisionB
            myForm.Txt_DescripDepto.Text = DeptoB
            myForm.Txt_DescripFamilia.Text = FamiliaB
            myForm.Txt_DescripLinea.Text = LineaB
            myForm.Txt_DescripL1.Text = IdL1b
            myForm.Txt_DescripL2.Text = IdL2b
            myForm.Txt_DescripL3.Text = IdL3b
            myForm.Txt_DescripL4.Text = IdL4b
            myForm.Txt_DescripL5.Text = IdL5b
            myForm.Txt_DescripL6.Text = IdL6b
            myForm.Txt_Proveedor.Text = ProveedorB


            myForm.Txt_Division.Text = cveDivisionb
            myForm.Txt_Depto.Text = cveDepartamentob
            myForm.Txt_Familia.Text = cveFamiliab
            myForm.Txt_Linea.Text = cveLineab
            myForm.Txt_L1.Text = cveL1b
            myForm.Txt_L2.Text = cveL2b
            myForm.Txt_L3.Text = cveL3b
            myForm.Txt_L4.Text = cveL4b
            myForm.Txt_L5.Text = cveL5b
            myForm.Txt_L6.Text = cveL6b

            myForm.Txt_Agrupacion.Text = agrupacionb

            If strSucursales <> "" Then
                myForm.strSucursales = strSucursales
                myForm.Lbl_Sucursales.Text = Lbl_Sucursales.Text
            End If

            If CostoIniB <> 0 Then
                myForm.Txt_CostoIni.Text = CostoIniB.ToString
            End If
            If CostoFinB <> 0 Then
                myForm.Txt_CostoFin.Text = CostoFinB.ToString
            End If
            If PrecioIniB <> 0 Then
                myForm.Txt_PrecioIni.Text = PrecioIniB.ToString
            End If
            If PrecioFinB <> 0 Then
                myForm.Txt_PrecioFin.Text = PrecioFinB
            End If

            myForm.Txt_MedidaIni.Text = MedidaIniB
            myForm.Txt_MedidaFin.Text = MedidaFinB

            If EstatusB <> "" Then
                If EstatusB = "1" Then
                    myForm.Chk_Existencia.Checked = True
                    myForm.Chk_SinExist.Checked = False
                ElseIf EstatusB = "2" Then
                    myForm.Chk_Existencia.Checked = False
                    myForm.Chk_SinExist.Checked = True
                End If
            End If

            If RecibidoB = "0" Then
                myForm.Rb_Nuevos.Checked = True
            Else
                'myForm.Chk_SinRecibir.Checked = False
            End If


            If FecRecA <> "" AndAlso FecRecA <> "1900-01-01" Then
                myForm.Chk_UltRecibo.Checked = True

                myForm.DT_RecIni.Value = Mid(FecRecA, 9, 2) & "/" & Mid(FecRecA, 6, 2) & "/" & Mid(FecRecA, 1, 4)
                myForm.DT_RecFin.Value = Mid(FecRecB, 9, 2) & "/" & Mid(FecRecB, 6, 2) & "/" & Mid(FecRecB, 1, 4)
            End If

            If FecEntA <> "" Then
                myForm.Chk_Entrega.Checked = True
                If RecibidoB = "" Then
                    myForm.Rb_Todos.Checked = True
                End If
                myForm.DT_FecEntIni.Value = Mid(FecEntA, 9, 2) & "/" & Mid(FecEntA, 6, 2) & "/" & Mid(FecEntA, 1, 4)
                myForm.DT_FecEntFin.Value = Mid(FecEntB, 9, 2) & "/" & Mid(FecEntB, 6, 2) & "/" & Mid(FecEntB, 1, 4)
            End If

            myForm.ShowDialog()

            If myForm.strSucursales.Length = 2 Then
                SucursalB = myForm.strSucursales
            End If

            If myForm.strSucursales.Length > 2 Then
                Lbl_Sucursales.Text = myForm.Lbl_Sucursales.Text
                strSucursales = myForm.strSucursales
            Else
            End If

            MarcaB = myForm.Txt_Marca.Text
            ModeloB = myForm.Txt_Modelo.Text
            EstilofB = myForm.Txt_Estilof.Text


            DivisionB = myForm.Txt_DescripDivision.Text
            DeptoB = myForm.Txt_DescripDepto.Text
            FamiliaB = myForm.Txt_DescripFamilia.Text
            LineaB = myForm.Txt_DescripLinea.Text
            IdL1b = myForm.Txt_DescripL1.Text
            IdL2b = myForm.Txt_DescripL2.Text
            IdL3b = myForm.Txt_DescripL3.Text
            IdL4b = myForm.Txt_DescripL4.Text
            IdL5b = myForm.Txt_DescripL5.Text
            IdL6b = myForm.Txt_DescripL6.Text


            cveDivisionb = myForm.Txt_Division.Text
            cveDepartamentob = myForm.Txt_Depto.Text
            cveFamiliab = myForm.Txt_Familia.Text
            cveLineab = myForm.Txt_Linea.Text
            cveL1b = myForm.Txt_L1.Text
            cveL2b = myForm.Txt_L2.Text
            cveL3b = myForm.Txt_L3.Text
            cveL4b = myForm.Txt_L4.Text
            cveL5b = myForm.Txt_L5.Text
            cveL6b = myForm.Txt_L6.Text


            ProveedorB = myForm.Txt_Proveedor.Text

            If myForm.Txt_CostoIni.Text <> "" Then
                CostoIniB = myForm.Txt_CostoIni.Text
            Else
                CostoIniB = 0.0
            End If
            If myForm.Txt_CostoFin.Text <> "" Then
                CostoFinB = myForm.Txt_CostoFin.Text
            Else
                CostoFinB = 0.0
            End If
            If myForm.Txt_PrecioIni.Text <> "" Then
                PrecioIniB = myForm.Txt_PrecioIni.Text
            Else
                PrecioIniB = 0.0
            End If
            If myForm.Txt_PrecioFin.Text <> "" Then
                PrecioFinB = myForm.Txt_PrecioFin.Text
            Else
                PrecioFinB = 0.0
            End If

            MedidaIniB = myForm.Txt_MedidaIni.Text
            MedidaFinB = myForm.Txt_MedidaFin.Text

            If myForm.Txt_Agrupacion.Text <> "" Then
                agrupacionb = myForm.Txt_Agrupacion.Text
            End If

            If myForm.strSucursales <> "" Then
                Lbl_Sucursales.Text = myForm.Lbl_Sucursales.Text
            End If

            If myForm.Chk_UltRecibo.Checked Then
                FecRecA = myForm.DT_RecIni.Value.ToString("yyyy-MM-dd")
                FecRecB = myForm.DT_RecFin.Value.ToString("yyyy-MM-dd")
            Else
                FecRecA = ""
                FecRecB = ""
            End If

            If myForm.Chk_Entrega.Checked Then
                FecEntA = myForm.DT_FecEntIni.Value.ToString("yyyy-MM-dd")
                FecEntB = myForm.DT_FecEntFin.Value.ToString("yyyy-MM-dd")
            Else
                FecEntA = ""
                FecEntB = ""
            End If

            EstatusB = myForm.strExist

            RecibidoB = myForm.strSinRecibir

            If myForm.Sw_Filtro = True Then
                Call GeneraLabelFiltros()
                Call TraerArticulos()
            Else
                'Me.FLPanel_Img.Controls.Clear()
                PBar.Value = 0
                Txt_Porc.Text = ""
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub FLPanel_Img_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Pnl_Img.Focus()
    End Sub
    Private Sub FLPanel_Img_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Pnl_Img.Focus()
    End Sub
    Private Sub Btn_Sucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call TraerListadoSucursales()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TraerListadoSucursales()
        Dim myForm As New frmSucursal

        myForm.ShowDialog()
        SucSelect = myForm.SucSelect
        IntSelect = myForm.IntSelect

        strSucursales = ""

        Dim blnVacio As Boolean = True

        For i As Integer = 0 To SucSelect.Length - 1
            If SucSelect(i) <> "" Then
                blnVacio = False
                strSucursales = strSucursales + """" + SucSelect(i) + ""","
            End If
        Next

        If strSucursales <> "" Then
            strSucursales = Mid(strSucursales, 2, strSucursales.Length - 3)
            Call LabelSucursales()
        Else
            Lbl_Sucursales.Text = "Sucursales:"
        End If
    End Sub
    Private Sub LabelSucursales()

        Dim strSucursal As String = ""
        Lbl_Sucursales.Text = "Sucursales: "

        If strSucursales <> "" Then
            For i As Integer = 0 To SucSelect.Length - 1
                If SucSelect(i) <> "" Then
                    If SucSelect(i) = "01" Then
                        strSucursal = "JUAREZ"
                    ElseIf SucSelect(i) = "02" Then
                        strSucursal = "HIDALGO"
                    ElseIf SucSelect(i) = "03" Then
                        strSucursal = "VICTORIA"
                    ElseIf SucSelect(i) = "04" Then
                        strSucursal = "HAMBURGO"
                    ElseIf SucSelect(i) = "05" Then
                        strSucursal = "4 CAMINOS"
                    ElseIf SucSelect(i) = "06" Then
                        strSucursal = "TRIANA"
                    ElseIf SucSelect(i) = "07" Then
                        strSucursal = "LERDO"
                    ElseIf SucSelect(i) = "08" Then
                        strSucursal = "MATRIZ"
                    ElseIf SucSelect(i) = "33" Then
                        strSucursal = "CAPA DE OZONO"
                    End If

                    Lbl_Sucursales.Text = Lbl_Sucursales.Text + " " + strSucursal + ", "

                End If
            Next

            If Lbl_Sucursales.Text <> "" Then
                Lbl_Sucursales.Text = Mid(Lbl_Sucursales.Text, 1, Lbl_Sucursales.Text.Length - 2)
            End If
        End If
    End Sub
    Private Sub GeneraLabelFiltros()
        'Dim strFiltros As String = ""
        Lbl_Filtros.Text = "Filtros: "
        Try
            If MarcaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Marca: " + MarcaB + "\ "
            End If

            If ModeloB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Modelo: " + ModeloB + "\ "
            End If

            If EstilofB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + " Estilo: " + EstilofB + "\ "
            End If


            If DivisionB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + DivisionB + "\ "
            End If

            If DeptoB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + DeptoB + "\ "
            End If

            If FamiliaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + FamiliaB + "\ "
            End If

            If LineaB <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + LineaB + "\ "
            End If

            If IdL1b <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + IdL1b + "\ "
            End If

            If IdL2b <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + IdL2b + "\ "
            End If

            If IdL3b <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + IdL3b + "\ "
            End If

            If IdL4b <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + IdL4b + "\ "
            End If

            If IdL5b <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + IdL5b + "\ "
            End If

            If IdL6b <> "" Then
                Lbl_Filtros.Text = Lbl_Filtros.Text + IdL6b + "\ "
            End If

            If EstatusB <> "" Then
                If EstatusB = 1 Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " Estatus: " + "En Exist." + "\ "
                ElseIf EstatusB = 2 Then
                    Lbl_Filtros.Text = Lbl_Filtros.Text + " Estatus: " + "Sin Exist." + "\ "
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
            Pnl_Img.AutoScroll = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Img_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Img.Paint

    End Sub
End Class



