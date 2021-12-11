Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging
Imports LibPrintTicketMatriz.Class1
Public Class frmCatalogoMuestrasCompleto
    'mreyes 30/Septiembre/2017  11:58 p.m.

    Public EstatusB As String = ""
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





    Dim idfamilia As Integer = 0

    Dim idlinea As Integer = 0

    Dim idl1 As Integer = 0

    Dim idl2 As Integer = 0

    Dim idl3 As Integer = 0

    Dim idl4 As Integer = 0

    Dim idl5 As Integer = 0

    Dim idl6 As Integer = 0






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
        Try
            Dim myFormFiltros As New frmFiltrosSelecEstruc

            myFormFiltros.Opcion = 2
            myFormFiltros.StartPosition = FormStartPosition.CenterParent
            myFormFiltros.Sw_Filtro = False


            'myFormFiltros.CB_Sucursal.Visible = False
            myFormFiltros.Suc = Sucursal
            'myFormFiltros.Label4.Visible = False


            If Division <> "" Then
                If Division = "CALZADO" Then
                    myFormFiltros.Txt_Division.Text = "001"
                ElseIf Division = "ACCESORIOS" Then
                    myFormFiltros.Txt_Division.Text = "002"
                ElseIf Division = "ELECTRONICA" Then
                    myFormFiltros.Txt_Division.Text = "003"
                ElseIf Division = "GENERAL" Then
                    myFormFiltros.Txt_Division.Text = "999"
                End If
                myFormFiltros.Txt_DescripDivision.Text = Division
            Else
                myFormFiltros.Txt_DescripDivision.Text = ""
                myFormFiltros.Txt_Division.Text = ""
            End If
            If Depto <> "" Then
                myFormFiltros.Txt_IdDepto.Text = Depto
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstDepto(0, 0, "", 0, Depto)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    myFormFiltros.Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                End If
            End If
            If Familia <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(0, 0, 0, "", 3, Familia)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Linea <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstLinea(0, 0, 0, 0, "", 3, Linea)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L1 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl1(0, 0, 0, 0, 0, "", 3, L1)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L2 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl2(0, 0, 0, 0, 0, 0, "", 3, L2)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L3 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl3(0, 0, 0, 0, 0, 0, 0, "", 3, L3)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L4 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl4(0, 0, 0, 0, 0, 0, 0, 0, "", 3, L4)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L5 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl5(0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L5)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If L6 <> "" Then
                Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                    objDataSet = objCatalogoDeptos.usp_TraerEstl6(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 3, L6)
                End Using
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    myFormFiltros.Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    myFormFiltros.Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                End If
            End If
            If Marca <> "" Then
                myFormFiltros.Txt_Marca.Text = Marca
            End If


            myFormFiltros.ShowDialog()

            If myFormFiltros.Sw_Filtro = True Then



                If myFormFiltros.Txt_Marca.Text.Trim = "" Then
                    Marca = ""
                Else
                    Marca = myFormFiltros.Txt_Marca.Text
                End If

                If myFormFiltros.Txt_DescripDivision.Text.Trim = "" Then
                        Division = ""
                    Else
                        Division = myFormFiltros.Txt_DescripDivision.Text
                    End If
                    If myFormFiltros.Txt_DescripDepto.Text.Trim = "" Then
                        Depto = ""
                    Else
                        Depto = myFormFiltros.Txt_DescripDepto.Text
                    End If
                    If myFormFiltros.Txt_DescripFamilia.Text = "" Then
                        Familia = ""
                    Else
                        Familia = myFormFiltros.Txt_DescripFamilia.Text
                    End If
                    If myFormFiltros.Txt_DescripLinea.Text = "" Then
                        Linea = ""
                    Else
                        Linea = myFormFiltros.Txt_DescripLinea.Text
                    End If
                    If myFormFiltros.Txt_DescripL1.Text = "" Then
                        L1 = ""
                    Else
                        L1 = myFormFiltros.Txt_DescripL1.Text
                    End If
                    If myFormFiltros.Txt_DescripL2.Text = "" Then
                        L2 = ""
                    Else
                        L2 = myFormFiltros.Txt_DescripL2.Text
                    End If
                    If myFormFiltros.Txt_DescripL3.Text = "" Then
                        L3 = ""
                    Else
                        L3 = myFormFiltros.Txt_DescripL3.Text
                    End If
                    If myFormFiltros.Txt_DescripL4.Text = "" Then
                        L4 = ""
                    Else
                        L4 = myFormFiltros.Txt_DescripL4.Text
                    End If
                    If myFormFiltros.Txt_DescripL5.Text = "" Then
                        L5 = ""
                    Else
                        L5 = myFormFiltros.Txt_DescripL5.Text
                    End If
                    If myFormFiltros.Txt_DescripL6.Text = "" Then
                        L6 = ""
                    Else
                        L6 = myFormFiltros.Txt_DescripL6.Text
                    End If


                    Lbl_Leyenda.Text = Division & "\" & Depto & "\" & Familia & "\" & Linea & "\" & L1 & "\" & L2 & "\" & L3 & "\" & L4 & "\" & L5 & "\" & L6


                    Call RellenaArticulos()
                End If
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

        Dim xLb As Integer = 180 '2
        Dim yLb As Integer = 2 '150

        Dim xDG As Integer = 2
        Dim yDG As Integer = 180 '150

        Dim xPN As Integer = 2
        Dim yPN As Integer = 2 '150

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


                If contador = 3 Then
                    xPB = 2
                    yPB += 290
                    'yPB += 170  'QUITO
                    contador = 0
                End If
                contador += 1
                PBar.Value = PBar.Value + 1
                Application.DoEvents()

                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    Dim PBoxFoto As New PictureBox

                    PBoxFoto.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")
                    Dim Imagen As Image

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
                    AddHandler PBoxFoto.DoubleClick, AddressOf AbrirFoto_Click

                    'AddHandler PBoxFoto.Click, AddressOf MandarFocusFLPanel_Click


                    intSig = i
                    PBoxFoto.Size = New Size(170, 170)
                    PBoxFoto.BorderStyle = BorderStyle.Fixed3D
                    Me.Pnl_Img.Controls.Add(PBoxFoto)
                    PBoxFoto.Location = New System.Drawing.Point(xPB, yPB)
                    xPB += 410   ''QUITO 175   'ESPACIO ENTRE PBOX Y PBOX


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

                End Using

                'For l As Integer = intSig + 1 To intMenorLbl
                Dim LblArticulo As New RichTextBox
                Dim DGrid As New DataGridView
                Dim strPrecioDesc As String = "Precio Desc: "
                Dim strClasif As String = ""

                If ContadorAux = 3 Then  'eran 6
                    xLb = 180   '2
                    yLb += 290   '190
                    'yLb += 170 'QUITO

                    xDG = 2
                    yDG += 290 ' 300

                    xPN = 2
                    yPN += 290
                    ContadorAux = 0
                End If
                ContadorAux += 1



                LblArticulo.Text = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                LblArticulo.Text = LblArticulo.Text & vbNewLine & "Proveedor : " & objDataSet.Tables(0).Rows(i).Item("proveedor").ToString & ""
                LblArticulo.Text = LblArticulo.Text & vbNewLine & "Dscto : " & objDataSet.Tables(0).Rows(i).Item("dscto").ToString & ""
                LblArticulo.Text = LblArticulo.Text & vbNewLine & "Plazo : " & objDataSet.Tables(0).Rows(i).Item("plazo").ToString & ""
                LblArticulo.Text = LblArticulo.Text & vbNewLine & "Remision : " & objDataSet.Tables(0).Rows(i).Item("remision").ToString & ""

                If EstatusB = "ZC" Then
                    LblArticulo.Text = LblArticulo.Text & vbNewLine & "Motivo Cancelación : " & objDataSet.Tables(0).Rows(i).Item("observaciones").ToString & ""
                End If

                LblArticulo.Multiline = True
                LblArticulo.Font = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.BorderStyle = BorderStyle.Fixed3D
                LblArticulo.Width = 180   '70
                If EstatusB <> "ZC" Then
                    LblArticulo.Height = 85
                Else
                    LblArticulo.Height = 160
                End If
                LblArticulo.Enabled = False


                ' LblArticulo.Width = 170
                ' LblArticulo.Height = 160
                LblArticulo.SelectionAlignment = HorizontalAlignment.Center
                LblArticulo.BorderStyle = BorderStyle.Fixed3D
                LblArticulo.ReadOnly = True

                LblArticulo.Select(LblArticulo.TextLength, 0)
                LblArticulo.SelectionBackColor = Color.Yellow
                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                ' LblArticulo.AppendText(strPrecioDesc)
                LblArticulo.Select(LblArticulo.TextLength, 0)

                LblArticulo.SelectionFont = New Font(LblArticulo.Font, FontStyle.Bold)
                LblArticulo.AppendText(strClasif)


                Me.Pnl_Img.Controls.Add(LblArticulo)
                LblArticulo.Location = New System.Drawing.Point(xLb, yLb)

                'AGREGAR BOTONES
                If EstatusB <> "ZC" Then
                    Dim Btn_Borrar As New Button
                    Btn_Borrar.Name = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                    Btn_Borrar.Image = My.Resources.basura
                    Btn_Borrar.Width = 50   '70
                    Btn_Borrar.Height = 50
                    Me.Pnl_Img.Controls.Add(Btn_Borrar)
                    Btn_Borrar.Location = New System.Drawing.Point(xLb, yLb + 95)

                    AddHandler Btn_Borrar.Click, AddressOf CancelaMuestra


                    Dim Btn_Pedir As New Button
                    Btn_Pedir.Name = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                    Btn_Pedir.Image = My.Resources.carrito
                    Btn_Pedir.Width = 50   '70
                    Btn_Pedir.Height = 50
                    Me.Pnl_Img.Controls.Add(Btn_Pedir)
                    Btn_Pedir.Location = New System.Drawing.Point(xLb + 50, yLb + 95)

                    AddHandler Btn_Pedir.Click, AddressOf PedidoMuestra
                End If

                'Dim Btn_Guardar As New Button
                'Btn_Guardar.Name = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                'Btn_Guardar.Image = My.Resources.bloqueado
                'Btn_Guardar.Width = 50   '70
                'Btn_Guardar.Height = 50
                'Me.Pnl_Img.Controls.Add(Btn_Guardar)
                'Btn_Guardar.Location = New System.Drawing.Point(xLb + 100, yLb + 95)

                'AddHandler Btn_Guardar.Click, AddressOf GuardarDatos

                'If EstatusB = "RE" Then
                '    Btn_Guardar.Visible = False
                'End If

                'TERMINA AGREGAR BOTONES

                xLb += 410 '190
                AddHandler LblArticulo.Click, AddressOf MandarFocusFLPanel_Click



                'Agregar panel

                Dim Pnl_Cuadro As New Panel


                    Pnl_Cuadro.Name = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("estilof").ToString
                    Pnl_Cuadro.BorderStyle = BorderStyle.FixedSingle
                    Pnl_Cuadro.Width = 400   '70
                    Pnl_Cuadro.Height = 170




                    Me.Pnl_Img.Controls.Add(Pnl_Cuadro)
                    Pnl_Cuadro.Location = New System.Drawing.Point(xPN, YPN)
                xPN += 410 '190
                If EstatusB <> "ZC" Then
                    AddHandler Pnl_Cuadro.Click, AddressOf PintarPanel

                End If

                ''termina agregar panel



                DGrid.Name = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("estilof")
                '' AGREGAR TEXTO... 
                DGrid.Width = 400
                DGrid.Height = 100
                DGrid.ReadOnly = False
                ' DGrid.ColumnCount = 6
                ' DGrid.RowCount = 5

                '  DGrid.ScrollBars = True
                RellenaGrid(DGrid, objDataSet.Tables(0).Rows(i).Item("marca"), objDataSet.Tables(0).Rows(i).Item("estilof"))

                Me.Pnl_Img.Controls.Add(DGrid)

                DGrid.Columns(0).HeaderText = "I"
                DGrid.Columns(1).HeaderText = "Ini"
                DGrid.Columns(2).HeaderText = "Fin"
                DGrid.Columns(3).HeaderText = "PLista"
                DGrid.Columns(4).HeaderText = "Costo"
                DGrid.Columns(5).HeaderText = "Precio"
                DGrid.Columns(6).HeaderText = "Margen"

                DGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.PowderBlue
                DGrid.ColumnHeadersDefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
                DGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGrid.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DGrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGrid.Columns(6).DefaultCellStyle.Format = "#0.00"

                'DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ' DGrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
                ' DGrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ' DGrid.Columns(0).DefaultCellStyle.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                '' rellena grid 

                DGrid.RowHeadersVisible = False

                DGrid.Location = New System.Drawing.Point(xDG, yDG)
                xDG += 410
                AddHandler DGrid.Click, AddressOf MandarFocusFLPanel_Click
                AddHandler DGrid.CellEndEdit, AddressOf GuardarDatos
                'GuardarDatos
                'Next

                i = intSig

                Txt_Porc.Text = i + 1 & " de " & Cont

                ClearMemory()
                System.GC.Collect()
            Next

            Pnl_Img.AutoScroll = True
            Pnl_Principal.Visible = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CancelaMuestra(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 07/Octubre/2017 10:35 a.m.

        Try
            Dim Boton As Button = sender
            Dim nombre As String = ""
            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Boton) Then
                    Dim nom As String = Boton.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5)




            Dim myFormFiltros As New frmCancelaMuestra

            myFormFiltros.Text = myFormFiltros.Text & " " & Marca & "-" & Estilon
            myFormFiltros.Marca = Marca
            myFormFiltros.Modelo = Estilon
            myFormFiltros.ShowDialog()

            If myFormFiltros.Sw_Guardo = True Then


                Call RellenaArticulos()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub PintarPanel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 10/Octubre/2017 10:54 a.m.

        Try
            Dim Opcion As Integer
            Dim Panel As Panel = sender
            Dim nombre As String = ""
            Dim Guardo As Boolean = False
            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Panel) Then
                    Dim nom As String = Panel.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5)

            If Panel.BackColor = Color.PowderBlue Then
                Panel.BackColor = Color.WhiteSmoke
                Opcion = 3
            Else
                Panel.BackColor = Color.PowderBlue
                Opcion = 1
            End If


            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                Guardo = objBultos.usp_Captura_TmpMuestrasDet(Opcion, Marca, Estilon, GLB_Idempleado)
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GuardarDatos(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 10/Octubre/2017 12:15 p.m.

        Try

            Dim Dgrid As DataGridView = sender
            Dim nombre As String = ""
            Dim Guardo As Boolean = False
            Dim MedIni As String = ""
            Dim MedFin As String = ""
            Dim Intervalo As String = ""
            Dim PrecioLista As Double = 0.0
            Dim Precio As Double = 0.0
            Dim Margen As Double = 0.0

            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Dgrid) Then
                    Dim nom As String = Dgrid.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5)

            'Guardar en el detallado de la muestra 

            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex

            Dim ms As New MemoryStream
            PBox.Image.Save(ms, PBox.Image.RawFormat)
            Dim arrImage() As Byte = ms.GetBuffer
            Dim Costo As Double = 0.0
            MedIni = Dgrid.Rows(renglon).Cells("medini").Value & ""
            MedFin = Dgrid.Rows(renglon).Cells("medfin").Value & ""
            Intervalo = Dgrid.Rows(renglon).Cells("intervalo").Value & ""
            PrecioLista = Val(Dgrid.Rows(renglon).Cells("preciolista").Value)
            Precio = Val(Dgrid.Rows(renglon).Cells("precio").Value)

            Margen = (Precio - Costo) / Precio
            Dgrid.Rows(renglon).Cells("margen").Value = Margen
            Lbl_Leyenda.Visible = True
            Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                Guardo = objBultos.usp_Captura_Muestrasdet(7, 0, Marca, Estilon, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, "", Intervalo, medini, medfin, preciolista, 0, precio, arrImage, GLB_Idempleado)
            End Using


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


                objDataSet = objArticulos.usp_PpalMuestrasdet(6, idmuestrab, EstatusB, Marca, "", "", IdDivisiones, Division, IdDepto, Depto, idfamilia, Familia, idlinea, Linea, idl1, L1, idl2, L2, idl3, L3, idl4, L4, idl5, L5, idl6, L6)


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
        Try
            Dim Guardo As Boolean = False

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
            If e.KeyCode = Windows.Forms.Keys.F7 Then
                '' CAMBIAR ESTATUS A REVISADO
                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)
                    Guardo = objBultos.usp_Captura_TmpMuestrasDet(4, "", "", GLB_Idempleado)
                End Using
                Call RellenaArticulos()

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid(Dgrid As DataGridView, Marca As String, Estilof As String)
        'mreyes 03/Octubre/2017 11:46 p.m.
        Dim objDataSet As DataSet
        Using objTrasp As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoAppSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Dgrid.DataSource = Nothing
                Dgrid.Visible = False
                objDataSet = objTrasp.usp_TraerCostosPreciosMuestrasDet(1, Marca, Estilof)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Dgrid.DataSource = objDataSet.Tables(0)
                    ' InicializaGrid(Dgrid)



                    Me.Cursor = Cursors.Default



                End If


                Me.Cursor = Cursors.Default
                Dgrid.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid(Dgrid As DataGridView)
        Try

            Dgrid.Columns(0).HeaderText = "I"
            Dgrid.Columns(1).HeaderText = "Ini"
            Dgrid.Columns(2).HeaderText = "Fin"
            Dgrid.Columns(3).HeaderText = "Costo"
            Dgrid.Columns(4).HeaderText = "Precio"
            Dgrid.Columns(5).HeaderText = "Margen"
            'DGrid.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dgrid.Columns(0).DefaultCellStyle.BackColor = Color.PowderBlue
            Dgrid.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dgrid.Columns(0).DefaultCellStyle.Font = New Font(Dgrid.DefaultCellStyle.Font.FontFamily, Dgrid.DefaultCellStyle.Font.Size, FontStyle.Bold)
            Dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            '' rellena grid 

            Dgrid.RowHeadersVisible = False

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PedidoMuestra(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 13/Octubre/2017 11:17 a.m.

        Try
            Dim Boton As Button = sender
            Dim nombre As String = ""
            If Not IsDBNull(Menu) Then
                If Not IsDBNull(Boton) Then
                    Dim nom As String = Boton.Name
                    nombre = nom
                End If
            End If

            Marca = Mid(nombre, 1, 3)
            Estilon = Mid(nombre, 5)




            Dim myFormFiltros As New frmCatalogoPedidoMuestra

            myFormFiltros.Text = myFormFiltros.Text & " " & Marca & "-" & Estilon
            myFormFiltros.Marca = Marca
            myFormFiltros.Modelo = Estilon
            myFormFiltros.Txt_Marca.Text = Marca
            myFormFiltros.Txt_Estilof.Text = Estilon
            myFormFiltros.ShowDialog()

            If myFormFiltros.Sw_Guardo = True Then


                Call RellenaArticulos()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Img_Paint(sender As Object, e As PaintEventArgs) Handles Pnl_Img.Paint

    End Sub
End Class