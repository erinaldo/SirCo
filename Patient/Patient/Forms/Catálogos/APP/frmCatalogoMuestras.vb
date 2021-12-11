Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging
Imports LibPrintTicketMatriz.Class1
Public Class frmCatalogoMuestras
    'mreyes 09/Agosto/2017  01:15 p.m.

    Dim Ruta As String = ""
    Dim idmuestrab As Integer = 0
    Dim intCantArticulos As Integer = 0

    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Private mousePath As System.Drawing.Drawing2D.GraphicsPath
    Dim blnAbortar As Boolean = False

    Dim Inicio As Integer
    Dim Fin As Integer
    Dim Agrupacionb As Integer = 0
    Dim Sw_Entro As Boolean = False

    Public Marca As String = ""

    Public IdDivisiones As Integer
    Public Division As String = ""
    Public IdDepto As Integer
    Public Depto As String = ""
    Public Linea As String = ""
    Public Familia As String = ""

    Public L1 As String = ""
    Public L2 As String = ""
    Public L3 As String = ""
    Public L4 As String = ""
    Public L5 As String = ""
    Public L6 As String = ""
    Public IdAgrupacion As Integer

    Dim Intervalo As String = "1"
    Dim Sw_Consulta As Boolean = False
    Dim Sql As String
    Public Accion As Integer  ' 1 = Administración , 2 = Tiendas 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetFiltro As Data.DataSet
    Private objDataSetModelos As Data.DataSet
    Private objDataSetCorrida As Data.DataSet
    Private objDataSetAuxiliarMod As New Data.DataSet
    Dim objDataSetResmin As New Data.DataSet
    Dim objDataSetVtasCero As DataSet
    Dim objDataSetPruebas As DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False
    'Dim blnEsPrimero As Boolean = True

    Public FechaInib As String
    Public FechaFinb As String

    Dim PeriodoIni As Date
    Dim PeriodoFin As Date

    Dim intPosicion As Integer = 0
    Dim intTotalRows As Integer = 0

    Dim DesctoPP As String = ""
    Dim Dscto01 As String = ""
    Dim Dscto02 As String = ""
    Dim Dscto03 As String = ""
    Dim Dscto04 As String = ""
    Dim Dscto05 As String = ""
    Dim Iva As String = ""
    Dim MedMax As String = ""
    Dim MedMin As String = ""

    Public Sucursal As String = ""

    Public Estilon As String = ""
    Public OrdeComp As String = ""
    Public Proveedor As String = ""
    Dim Clasif As String = ""
    Public Fecha As Date = "1900-01-01"
    Dim Sw_Load As Boolean = False
    Public Sw_Menu As Boolean = False

    Dim MarcaDC As String = ""
    Dim Modelodc As String = ""
    Dim MedidaDC As String = ""
    Dim IdMuestraDC As Integer = 0



    Private Sub Btn_AceptarF_Click(sender As Object, e As EventArgs) Handles Btn_AceptarF.Click
        'GridView1.Rows.Add(imgtoarr(Ruta))
        Try
            Pnl_Principal.Visible = False

            Call RellenaArticulos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function imgtoarr(ByVal URLimagen As String) As Byte()
        Try
            Dim img As Image = Image.FromFile(URLimagen)
            Dim ms As New System.IO.MemoryStream
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Return ms.ToArray()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Public Sub ClearMemory()
        Try
            Dim Mem As Process

            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

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


            myForm.Accion = 1

            myForm.ShowDialog()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub SeleccionaCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim nombre As String = ""
            Dim Marca As String = ""
            Dim Estilon As String = ""
            Dim Guardo As Boolean = False
            Dim Opcion As Integer = 0
            Dim Check As CheckBox = sender
            Dim objDataSet As Data.DataSet


            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Check) Then
                    Dim nom As String = Check.Name
                    nombre = nom
                End If
            End If

            MarcaDC = Mid(nombre, 1, 3)
            Modelodc = Mid(nombre, 5)
            'es opcion 
            'guardar en tabla temporal. 
            'DgridPedido.Rows.Add(MarcaDC, Modelodc, MedidaDC, 1)

            If Check.Checked = True Then
                Opcion = 1
            Else
                Opcion = 3

            End If

            '' Antes de capturar la muestra guardar el proveedor si detecta que no existe ...
            'IR A BUSCAR EN MUESTRASMARCAS DONDE EL ETATUS  = 'CA'
            '' ir a buscar el proveedor, 
            Using objArticulos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                objDataSet = objArticulos.usp_TraerProveedorMuestras(MarcaDC, Modelodc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("proveedor") = "" Then
                        'mandar llamar forma de proveedores.
                        Dim myForm As New frmCatalogoProveedoresN
                        myForm.Accion = 1
                        'myForm.MdiParent = BitacoraMain
                        myForm.Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc") & ""

                        myForm.Show()



                        'guardar el proveedor en muestras.


                        Exit Sub
                    End If
                End If
            End Using

            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                Guardo = objBultos.usp_Captura_TmpMuestrasDet(Opcion, MarcaDC, Modelodc, GLB_Idempleado)
            End Using





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
            Estilon = Mid(nombre, 5)

            myForm.Text = Marca & "-" & Estilon
            myForm.Txt_Estilon.Text = Estilon
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_NoFoto.Text = "1"
            myForm.Sw_Pbox = True
            myForm.PBox.Image = PBox.Image
            myForm.ShowDialog()
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
    Private Sub GeneraComponentesDinamicos()

        Dim Archivo As String = ""
        Dim NoFoto As String = "1"
        Dim intSig As Integer
        'Dim intMenorPBox As Integer
        'Dim intMenorLbl As Integer
        Dim Sw_NoEncontro As Boolean = False
        Dim xPB As Integer = 2
        Dim yPB As Integer = 2
        Dim xLb As Integer = 25
        Dim yLb As Integer = 150

        Dim xCK As Integer = 2
        Dim yCK As Integer = 150

        Try
            Me.Pnl_Img.Controls.Clear()

            Application.DoEvents()
            PBar.Minimum = 0
            PBar.Maximum = intCantArticulos
            PBar.Value = 0
            Dim Cont As Integer = intCantArticulos
            Dim contador As Integer = 0
            Dim ContadorAux As Integer = 0
            Dim ContadorAux1 As Integer = 0

            For i As Integer = 0 To intCantArticulos - 1
                If blnAbortar = True Then Exit Sub
                System.GC.Collect()

                'intMenorPBox = i + 5
                'If intCantArticulos - 1 < intMenorPBox Then
                '    intMenorPBox = intCantArticulos - 1
                'End If

                'For j As Integer = i To intMenorPBox

                If contador = 7 Then
                    xPB = 2
                    ' yPB += 315
                    yPB += 170
                    contador = 0
                End If
                contador += 1
                PBar.Value = PBar.Value + 1
                Application.DoEvents()


                Dim PBoxFoto As New PictureBox

                    PBoxFoto.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")
                'Dim Imagen As Image

                Dim cms As New ContextMenuStrip

                    cms.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")
                    cms.Items.Add("Análisis")
                    cms.Items.Add("Pedidos Pendientes")
                    cms.Items.Add("Ventas")
                    cms.Items(0).Visible = False
                    cms.Items(1).Visible = False
                    cms.Items(2).Visible = False

                    '''''cms.Show()
                    MarcaDC = ""
                    Modelodc = ""

                    PBoxFoto.ContextMenuStrip = cms
                    cms.Items(0).Tag = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")
                    cms.Items(1).Tag = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")
                    cms.Items(0).Image = My.Resources.monitoreo
                    cms.Items(1).Image = My.Resources.pendiente
                    AddHandler cms.Items(0).Click, AddressOf AbrirExistencias_Click
                    AddHandler cms.Items(1).Click, AddressOf AbrirPedidosPend_Click
                    MarcaDC = objDataSet.Tables(0).Rows(i).Item("marca").ToString
                    Modelodc = objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                    IdMuestraDC = objDataSet.Tables(0).Rows(i).Item("idmuestra")

                    AddHandler PBoxFoto.DoubleClick, AddressOf AbrirFoto_Click


                    'AddHandler PBoxFoto.Click, AddressOf MandarFocusFLPanel_Click


                    intSig = i
                    PBoxFoto.Size = New Size(170, 140)
                    PBoxFoto.BorderStyle = BorderStyle.FixedSingle
                    Me.Pnl_Img.Controls.Add(PBoxFoto)
                    PBoxFoto.Location = New System.Drawing.Point(xPB, yPB)
                    xPB += 175


                    ClearMemory()
                    System.GC.Collect()




                    Sw_NoEncontro = True

                    'Imagen = objDataSet.Tables(0).Rows(i).Item("imagen")


                    ClearMemory()
                    System.GC.Collect()

                    'If Imagen.Width > 1500 Or Imagen.Height > 1000 Then
                    '    PBoxFoto.Image = nuevaResolucion(Archivo, 800)
                    'Else
                    '    PBoxFoto.Image = New System.Drawing.Bitmap(Archivo)
                    'End If
                    'PBoxFoto.Image = Imagen
                    Dim bytBLOBData() As Byte = objDataSet.Tables(0).Rows(i).Item("imagen")
                    Dim stmBLOBData As New MemoryStream(bytBLOBData)
                    PBoxFoto.Image = Image.FromStream(stmBLOBData)

                    PBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage

                    ClearMemory()
                    System.GC.Collect()

                    If Sw_NoEncontro = False Then
                        NoFoto = "1"
                    End If

                    PBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage
                    PBoxFoto.Enabled = True



                'For l As Integer = intSig + 1 To intMenorLbl
                ' COMIENZA LABEL
                Dim LblArticulo As New RichTextBox
                Dim strPrecioDesc As String = "Precio Desc: "
                Dim strClasif As String = ""

                If ContadorAux = 7 Then
                    xLb = 25
                    'yLb += 315
                    yLb += 170
                    ContadorAux = 0
                End If
                ContadorAux += 1
                LblArticulo.Text = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                LblArticulo.BorderStyle = BorderStyle.FixedSingle
                LblArticulo.Width = 100
                LblArticulo.Height = 20
                LblArticulo.BorderStyle = BorderStyle.None
                LblArticulo.ReadOnly = True
                LblArticulo.Select(LblArticulo.TextLength, 0)
                LblArticulo.SelectionBackColor = Color.Yellow
                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.Select(LblArticulo.TextLength, 0)
                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.AppendText(strClasif)
                Me.Pnl_Img.Controls.Add(LblArticulo)
                LblArticulo.Location = New System.Drawing.Point(xLb, yLb)
                xLb += 175
                AddHandler LblArticulo.Click, AddressOf MandarFocusFLPanel_Click


                'TERMINA LABEL
                ClearMemory()
                System.GC.Collect()
                '' INICIO CHECK

                Dim Chek As New CheckBox
                Chek.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")

                If ContadorAux1 = 7 Then
                    xCK = 2
                    'yLb += 315
                    yCK += 170
                    ContadorAux1 = 0
                End If
                ContadorAux1 += 1
                Chek.Text = ""

                Chek.Width = 15
                Chek.Height = 14


                Me.Pnl_Img.Controls.Add(Chek)
                Chek.Location = New System.Drawing.Point(xCK, yCK)
                xCK += 175
                'AddHandler Chek.Click, AddressOf MandarFocusFLPanel_Click
                AddHandler Chek.Click, AddressOf SeleccionaCheck_Click

                '' TERMINO CHECK


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


    Private Sub MandarFocusFLPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Pnl_Img.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
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
    Private Sub RellenaArticulos()
        Dim iddivisiones As Integer = 0
        Dim division As String = ""
        Dim iddepto As Integer = 0
        Dim depto As String = ""
        Dim idfamilia As Integer = 0
        Dim familia As String = ""
        Dim idlinea As Integer = 0
        Dim linea As String = ""
        Dim idl1 As Integer = 0
        Dim l1 As String = ""
        Dim idl2 As Integer = 0
        Dim l2 As String = ""
        Dim idl3 As Integer = 0
        Dim l3 As String = ""
        Dim idl4 As Integer = 0
        Dim l4 As String = ""
        Dim idl5 As Integer = 0
        Dim l5 As String = ""
        Dim idl6 As Integer = 0
        Dim l6 As String = ""




        Dim arrFilename() As String = Split(Text, "\")
        Array.Reverse(arrFilename)
        Dim ms As New MemoryStream
        PBox.Image.Save(ms, PBox.Image.RawFormat)
        Dim arrImage() As Byte = ms.GetBuffer

        Using objArticulos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
            Try

                PBar.Visible = True
                Txt_Porc.Visible = True

                ClearMemory()
                Pnl_Img.AutoScroll = False


                objDataSet = objArticulos.usp_PpalMuestrasdet(5, idmuestrab, "CA", Txt_Marca.Text, "", "", iddivisiones, division, iddepto, depto, idfamilia, familia, idlinea, linea, idl1, l1, idl2, l2, idl3, l3, idl4, l4, idl5, l5, idl6, l6)


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
                    MessageBox.Show("No se encontraron artículos relacionados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                PBar.Visible = False
                Txt_Porc.Visible = False

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Txt_Marca_TextChanged(sender As Object, e As EventArgs) Handles Txt_Marca.TextChanged

    End Sub

    Private Sub PBox_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Pnl_Img_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Img.Paint

    End Sub

    Private Sub frmCatalogoMuestras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Guardo As Boolean = False
        Try
            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                Guardo = objBultos.usp_Captura_TmpMuestrasDet(2, "", "", GLB_Idempleado)
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoMuestras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If

        If e.KeyCode = Windows.Forms.Keys.F4 Then
            '' 
            If Pnl_Principal.Visible = True Then
                Pnl_Principal.Visible = False
            Else
                Pnl_Principal.Visible = True
            End If

        End If

        If e.KeyCode = Windows.Forms.Keys.F6 Then
            '' 

            '' si detecta que no existe la marca ni el proveedor, va por los datos completos.



            Dim myForm As New frmFiltrosSelecEstruc

            myForm.Lbl_Marca.Visible = False
            myForm.Txt_Marca.Visible = False
            myForm.txt_DescripMarca.Visible = False

            myForm.WindowState = FormWindowState.Normal

            myForm.StartPosition = FormStartPosition.CenterScreen

            GLB_RefrescarPedido = False
            myForm.ShowDialog()

            If GLB_RefrescarPedido = True Then
                Call RellenaArticulos()
            End If
        End If
    End Sub

    Private Sub PBox_EditValueChanged_1(sender As Object, e As EventArgs) Handles PBox.EditValueChanged

    End Sub
End Class