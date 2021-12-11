Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing.Imaging
Imports LibPrintTicketMatriz.Class1
''If(GLB_CveSucursal <> "", GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos)

Public Class frmPedidoBodega
    'mreyes 27/Diciembre/2016   09:46 a.m.
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

    Private Sub frmPedidoBodega_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If Sw_Load = True Then
            Txt_Vendedor.Focus()
        End If
    End Sub

    Private Sub frmAnalisisModelo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'FechaInib = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyyMMdd")
            'FechaFinb = Format(Now.Date, "yyyyMMdd")
            Sw_Load = True

            GLB_FormPedidoBodega = True


            Call GenerarToolTip()
            ' Txt_Vendedor.Focus()

            'blnEsPrimero = False
            Txt_Vendedor.Focus()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub







   

    Private Sub GenerarToolTip()
        Try

            'ToolTip.SetToolTip(Btn_Aceptar, "Consultar el rango de fechas seleccionadas")
            ToolTip.SetToolTip(Btn_Salir, "Salir")
            ToolTip.SetToolTip(Btn_Series, "Consultar Series Activas")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub frmCatalogoExistenciaEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then

                GLB_FormPedidoBodega = False
                Me.Dispose()
                Me.Close()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

           
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                System.GC.Collect()

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            Exit Sub
                        End If
                    End If
                Next

                PBox.Image = SIRCO.My.Resources.ZAPATERIA_TORREON
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Modelo.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus

        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
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

    Private Sub Txt_Modelo_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Modelo.LocationChanged

    End Sub

    Private Sub Txt_Modelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Modelo.LostFocus
        Try

            If Sw_Load = True Then
                Txt_IdArticulo.Text = ""
            End If




            If Txt_Modelo.Text.Length > 0 Then
                Txt_Modelo.Text = Txt_Modelo.Text.PadLeft(7)
            End If
            If Txt_Modelo.Text.Length = 0 And Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar un estilo a buscar.", MsgBoxStyle.Critical, "Error")
                Txt_Marca.Focus()
                Exit Sub
            End If
           




            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEst.usp_TraerModelo(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text, "", _
                                                               0, 0, 0, 0, 0, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdArticulo.Text = Val(objDataSet.Tables(0).Rows(0).Item("idarticulo") & "")

                    If Txt_IdArticulo.Text = "0" Then
                        GoTo NoHay
                    End If
                    Intervalo = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("modelo").ToString

                  
                    Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")

                    MedMax = objDataSet.Tables(0).Rows(0).Item("medmax")
                    MedMin = objDataSet.Tables(0).Rows(0).Item("medmin")

                    DesctoPP = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Dscto01 = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Dscto02 = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Dscto03 = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Dscto04 = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Dscto05 = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                    If objDataSet.Tables(0).Rows(0).Item("proveedor").ToString <> "191" Then
                        Iva = "16"
                    Else
                        Iva = "0"
                    End If

                    Division = ""
                    Depto = ""
                    Familia = ""
                    Linea = ""
                    L1 = ""
                    L2 = ""
                    L3 = ""
                    L4 = ""
                    L5 = ""
                    L6 = ""



                    Division = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                    Depto = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                    Familia = objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString
                    Linea = objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString
                    L1 = objDataSet.Tables(0).Rows(0).Item("descripl1").ToString
                    L2 = objDataSet.Tables(0).Rows(0).Item("descripl2").ToString
                    L3 = objDataSet.Tables(0).Rows(0).Item("descripl3").ToString
                    L4 = objDataSet.Tables(0).Rows(0).Item("descripl4").ToString
                    L5 = objDataSet.Tables(0).Rows(0).Item("descripl5").ToString
                    L6 = objDataSet.Tables(0).Rows(0).Item("descripl6").ToString

                    IdAgrupacion = Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion"))



                    If Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 103 Or Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 108 Or Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 109 Or Val(objDataSet.Tables(0).Rows(0).Item("idagrupacion")) = 110 Then
                        Lbl_Totales.Text = "PARES UNICOS"
                    Else
                        Lbl_Totales.Text = ""
                    End If


                    ''''Call usp_TraerFechaUltVenta()

                    ''''Call TraerCostoPrecio()

                    Call CargarFotoArticulo()
                    DGridExistencia.Visible = False
                    ''''Call TraerPedido(objDataSet.Tables(0).Rows.Count)
                    Call RellenaGrid(0)

                    DGridExistencia.Visible = True

                    Txt_Marca.Enabled = False
                    Txt_Modelo.Enabled = False


                    objDataSet = objCatalogoEst.usp_TraerIdArticulo(Txt_Marca.Text, Txt_Modelo.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_IdArticulo.Text = objDataSet.Tables(0).Rows(0).Item("idarticulo")
                    End If
                    'End Using

                    ''For i As Integer = 0 To objDataSetModelos.Tables(0).Rows.Count - 1
                    ''    If objDataSet.Tables(0).Rows(0).Item("idarticulo") = objDataSetModelos.Tables(0).Rows(i).Item("idarticulo") Then
                    ''        intPosicion = i
                    ''    End If
                    ''Next
                Else
NoHay:
                    MsgBox("El modelo ingresado no existe.", MsgBoxStyle.Exclamation, "Aviso")
                    Txt_Marca.Text = ""
                    Txt_Modelo.Text = ""
                    Txt_DescripMarca.Text = ""
                    Txt_Marca.Select()

                    'Lbl_Periodo.Text = ""
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Modelo.KeyPress
        pub_SoloNumeros(sender, e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If DGridExistencia.Rows.Count >= 1 Then
                DGridExistencia.DataSource = Nothing
                DGridExistencia.Columns.Clear()
                DGridExistencia.Rows.Clear()
                Sucursal = ""
            End If


            Txt_Marca.Text = ""
            Txt_Modelo.Text = ""
            Txt_IdArticulo.Text = ""

            Txt_DescripMarca.Text = ""


            'Lbl_Periodo.Text = ""


            Txt_Marca.Enabled = True
            Txt_Modelo.Enabled = True



            PBox.Image = Nothing



            If usp_BorrarAnaModArticulo() Then

            End If
            Txt_Marca.Select()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Series.Click
        'mreyes 28/Diciembre/2016
        Try
            Dim Nota As String = ""
            Dim Guardo As Boolean = False

            Dim Marca As String = ""
            Dim Modelo As String = ""
            Dim Medida As String = ""
            Dim Propuesta As Integer = 0


            Nota = fn_TraerFolioOrdeComp(11, GLB_CveSucursal, 1)
            Nota = pub_RellenarIzquierda(Nota, 6)

            If Actualiza_FolioOrdeComp(12, GLB_CveSucursal, 1) = False Then
                Exit Sub
            End If

            For I As Integer = 0 To DGridNegado.Rows.Count - 2
                Marca = DGridNegado.Rows(I).Cells(0).Value
                Modelo = DGridNegado.Rows(I).Cells(1).Value
                Medida = DGridNegado.Rows(I).Cells(2).Value

                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    Guardo = objBultos.usp_Captura_NegBodega(GLB_CveSucursal, Nota, GLB_FechaHoy, Marca, Modelo, Medida, GLB_Idempleado, Txt_Vendedor.Text)
                End Using
            Next


            For I As Integer = 0 To DgridPedido.Rows.Count - 2
                Marca = DgridPedido.Rows(I).Cells(0).Value
                Modelo = DgridPedido.Rows(I).Cells(1).Value
                Medida = DgridPedido.Rows(I).Cells(2).Value
                Propuesta = DgridPedido.Rows(I).Cells(3).Value

                Using objBultos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    Guardo = objBultos.usp_Captura_PedBodega(GLB_CveSucursal, Nota, GLB_FechaHoy, Marca, Modelo, Medida, GLB_Idempleado, Txt_Vendedor.Text, propuesta)
                End Using
            Next

            'imprimir..

            Call Imprimir(Nota)


            If Me.DGridExistencia.Rows.Count >= 1 Then
                DGridExistencia.DataSource = Nothing
                DGridExistencia.Columns.Clear()
                DGridExistencia.Rows.Clear()

            End If
            If DGridNegado.Rows.Count >= 1 Then
                DGridNegado.RowCount = 2
                DGridNegado.Rows.Clear()



            End If
            If DgridPedido.Rows.Count >= 1 Then
                DgridPedido.RowCount = 2
                DgridPedido.Rows.Clear()

            End If

            Me.Pnl_Img.Controls.Clear()
            PBar.Value = 0
            Txt_Porc.Text = ""
            ClearMemory()
            PBox.Image = Nothing
            Txt_Marca.Text = ""
            Txt_DescripMarca.Text = ""
            Txt_Modelo.Text = ""
            Txt_Modelo.Enabled = True
            Txt_Marca.Enabled = True
            Txt_Vendedor.Text = ""
            Txt_Nombre.Text = ""
            Lbl_Totales.Text = ""

            Txt_Vendedor.Focus()


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


   

   

    Public Function TraerMedida(ByVal NombreColumna As String) As String
        If NombreColumna.ToUpper = "M1" Then
            Return "01"
        ElseIf NombreColumna.ToUpper = "M1_" Then
            Return "01-"
        ElseIf NombreColumna.ToUpper = "M2" Then
            Return "02"
        ElseIf NombreColumna.ToUpper = "M2_" Then
            Return "02-"
        ElseIf NombreColumna.ToUpper = "M3" Then
            Return "03"
        ElseIf NombreColumna.ToUpper = "M3_" Then
            Return "03-"
        ElseIf NombreColumna.ToUpper = "M4" Then
            Return "04"
        ElseIf NombreColumna.ToUpper = "M4_" Then
            Return "04-"
        ElseIf NombreColumna.ToUpper = "M5" Then
            Return "05"
        ElseIf NombreColumna.ToUpper = "M5_" Then
            Return "05-"
        ElseIf NombreColumna.ToUpper = "M6" Then
            Return "06"
        ElseIf NombreColumna.ToUpper = "M6_" Then
            Return "06-"
        ElseIf NombreColumna.ToUpper = "M7" Then
            Return "07"
        ElseIf NombreColumna.ToUpper = "M7_" Then
            Return "07-"
        ElseIf NombreColumna.ToUpper = "M8" Then
            Return "08"
        ElseIf NombreColumna.ToUpper = "M8_" Then
            Return "08-"
        ElseIf NombreColumna.ToUpper = "M9" Then
            Return "09"
        ElseIf NombreColumna.ToUpper = "M9_" Then
            Return "09-"
        ElseIf NombreColumna.ToUpper = "M10" Then
            Return "10"
        ElseIf NombreColumna.ToUpper = "M10_" Then
            Return "10-"
        ElseIf NombreColumna.ToUpper = "M11" Then
            Return "11"
        ElseIf NombreColumna.ToUpper = "M11_" Then
            Return "11-"
        ElseIf NombreColumna.ToUpper = "M12" Then
            Return "12"
        ElseIf NombreColumna.ToUpper = "M12_" Then
            Return "12-"
        ElseIf NombreColumna.ToUpper = "M13" Then
            Return "13"
        ElseIf NombreColumna.ToUpper = "M13_" Then
            Return "13-"
        ElseIf NombreColumna.ToUpper = "M14" Then
            Return "14"
        ElseIf NombreColumna.ToUpper = "M14_" Then
            Return "14-"
        ElseIf NombreColumna.ToUpper = "M15" Then
            Return "15"
        ElseIf NombreColumna.ToUpper = "M15_" Then
            Return "15-"
        ElseIf NombreColumna.ToUpper = "M16" Then
            Return "16"
        ElseIf NombreColumna.ToUpper = "M16_" Then
            Return "16-"
        ElseIf NombreColumna.ToUpper = "M17" Then
            Return "17"
        ElseIf NombreColumna.ToUpper = "M17_" Then
            Return "17-"
        ElseIf NombreColumna.ToUpper = "M18" Then
            Return "18"
        ElseIf NombreColumna.ToUpper = "M18_" Then
            Return "18-"
        ElseIf NombreColumna.ToUpper = "M19" Then
            Return "19"
        ElseIf NombreColumna.ToUpper = "M19_" Then
            Return "19-"
        ElseIf NombreColumna.ToUpper = "M20" Then
            Return "20"
        ElseIf NombreColumna.ToUpper = "M20_" Then
            Return "20-"
        ElseIf NombreColumna.ToUpper = "M21" Then
            Return "21"
        ElseIf NombreColumna.ToUpper = "M21_" Then
            Return "21-"
        ElseIf NombreColumna.ToUpper = "M22" Then
            Return "22"
        ElseIf NombreColumna.ToUpper = "M22_" Then
            Return "22-"
        ElseIf NombreColumna.ToUpper = "M23" Then
            Return "23"
        ElseIf NombreColumna.ToUpper = "M23_" Then
            Return "23-"
        ElseIf NombreColumna.ToUpper = "M24" Then
            Return "24"
        ElseIf NombreColumna.ToUpper = "M24_" Then
            Return "24-"
        ElseIf NombreColumna.ToUpper = "M25" Then
            Return "25"
        ElseIf NombreColumna.ToUpper = "M25_" Then
            Return "25-"
        ElseIf NombreColumna.ToUpper = "M26" Then
            Return "26"
        ElseIf NombreColumna.ToUpper = "M26_" Then
            Return "26-"
        ElseIf NombreColumna.ToUpper = "M27" Then
            Return "27"
        ElseIf NombreColumna.ToUpper = "M27_" Then
            Return "27-"
        ElseIf NombreColumna.ToUpper = "M28" Then
            Return "28"
        ElseIf NombreColumna.ToUpper = "M28_" Then
            Return "28-"
        ElseIf NombreColumna.ToUpper = "M29" Then
            Return "29"
        ElseIf NombreColumna.ToUpper = "M29_" Then
            Return "29-"
        ElseIf NombreColumna.ToUpper = "M30" Then
            Return "30"
        ElseIf NombreColumna.ToUpper = "M30_" Then
            Return "30-"
        ElseIf NombreColumna.ToUpper = "M31" Then
            Return "31"
        ElseIf NombreColumna.ToUpper = "M31_" Then
            Return "31-"
        ElseIf NombreColumna.ToUpper = "M32" Then
            Return "32"
        ElseIf NombreColumna.ToUpper = "M32_" Then
            Return "32-"
        ElseIf NombreColumna.ToUpper = "M33" Then
            Return "33"
        ElseIf NombreColumna.ToUpper = "M33_" Then
            Return "33-"
        ElseIf NombreColumna.ToUpper = "M34" Then
            Return "34"
        ElseIf NombreColumna.ToUpper = "M34_" Then
            Return "34-"
        ElseIf NombreColumna.ToUpper = "M35" Then
            Return "35"
        ElseIf NombreColumna.ToUpper = "M35_" Then
            Return "35-"
        ElseIf NombreColumna.ToUpper = "M36" Then
            Return "36"
        ElseIf NombreColumna.ToUpper = "M36_" Then
            Return "36-"
        ElseIf NombreColumna.ToUpper = "M37" Then
            Return "37"
        ElseIf NombreColumna.ToUpper = "M37_" Then
            Return "37-"
        ElseIf NombreColumna.ToUpper = "M38" Then
            Return "38"
        ElseIf NombreColumna.ToUpper = "M38_" Then
            Return "38-"
        ElseIf NombreColumna.ToUpper = "M39" Then
            Return "39"
        ElseIf NombreColumna.ToUpper = "M39_" Then
            Return "39-"
        ElseIf NombreColumna.ToUpper = "M40" Then
            Return "40"
        ElseIf NombreColumna.ToUpper = "M40_" Then
            Return "40-"
        ElseIf NombreColumna.ToUpper = "M41" Then
            Return "41"
        ElseIf NombreColumna.ToUpper = "M41_" Then
            Return "41-"
        ElseIf NombreColumna.ToUpper = "M42" Then
            Return "42"
        ElseIf NombreColumna.ToUpper = "M42_" Then
            Return "42-"
        ElseIf NombreColumna.ToUpper = "M43" Then
            Return "43"
        ElseIf NombreColumna.ToUpper = "M43_" Then
            Return "43-"
        ElseIf NombreColumna.ToUpper = "M44" Then
            Return "44"
        ElseIf NombreColumna.ToUpper = "M44_" Then
            Return "44-"
        ElseIf NombreColumna.ToUpper = "M45" Then
            Return "45"
        ElseIf NombreColumna.ToUpper = "M45_" Then
            Return "45-"
        ElseIf NombreColumna.ToUpper = "M46" Then
            Return "46"
        ElseIf NombreColumna.ToUpper = "M46_" Then
            Return "46-"
        ElseIf NombreColumna.ToUpper = "M47" Then
            Return "47"
        ElseIf NombreColumna.ToUpper = "M47_" Then
            Return "47-"
        ElseIf NombreColumna.ToUpper = "M48" Then
            Return "48"
        ElseIf NombreColumna.ToUpper = "M48_" Then
            Return "48-"
        ElseIf NombreColumna.ToUpper = "M49" Then
            Return "49"
        ElseIf NombreColumna.ToUpper = "M49_" Then
            Return "49-"
        ElseIf NombreColumna.ToUpper = "M50" Then
            Return "50"
        ElseIf NombreColumna.ToUpper = "M50_" Then
            Return "50-"
        Else
            Return ""
        End If
    End Function

   

    Private Sub RellenaGrid(ByVal Sw_Generar As Integer)
        'mreyes 18/Julio/2016   04:22 p.m.
        Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                Sw_Entro = False
   
                ''''''''''''''''''
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"

                DGridExistencia.Visible = False

                objDataSet = objRegistro.usp_TraerExistenciaDirectaMySql(Txt_Marca.Text, Txt_Modelo.Text, GLB_CveSucursal)


                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section


                    DGridExistencia.DataSource = objDataSet.Tables(0)

                    InicializaGrid(DGridExistencia)
                    ColorearGrid(DGridExistencia)



                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    'Btn_Excel.Enabled = True

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron movimientos.", MsgBoxStyle.Critical, "Aviso")
                    'Btn_Excel.Enabled = False

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                'Call ColorearGrid()
              
                DGridExistencia.Visible = True

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub


    Private Sub InicializaGrid(ByVal DGridFormato As DataGridView)
        'mreyes 18/Julio/2016   04:27 p.m.
        Try


            Dim Sw_EmpiezaMedios As Boolean = False
            Dim Sw_TerminaMedios As Boolean = False

            'Dim dt As DataTable = TryCast(DGridFormato.DataSource, DataTable)
            'Dim row As DataRow = dt.NewRow()



            ' row(1) = "TOTAL: "

            DGridFormato.Columns(0).Visible = False
            DGridFormato.Columns(1).Visible = False
            DGridFormato.Columns(2).Visible = False
            DGridFormato.Columns(3).Visible = False



            DGridFormato.RowHeadersVisible = False
            'DGridFormato.Columns(2).Visible = False
            DGridFormato.Columns(4).HeaderText = "01"
            DGridFormato.Columns(5).HeaderText = "01-"
            DGridFormato.Columns(6).HeaderText = "02"
            DGridFormato.Columns(7).HeaderText = "02-"
            DGridFormato.Columns(8).HeaderText = "03"
            DGridFormato.Columns(9).HeaderText = "03-"
            DGridFormato.Columns(10).HeaderText = "04"
            DGridFormato.Columns(11).HeaderText = "04-"
            DGridFormato.Columns(12).HeaderText = "05"
            DGridFormato.Columns(13).HeaderText = "05-"
            DGridFormato.Columns(14).HeaderText = "06"
            DGridFormato.Columns(15).HeaderText = "06-"
            DGridFormato.Columns(16).HeaderText = "07"
            DGridFormato.Columns(17).HeaderText = "07-"
            DGridFormato.Columns(18).HeaderText = "08"
            DGridFormato.Columns(19).HeaderText = "08-"
            DGridFormato.Columns(20).HeaderText = "09"
            DGridFormato.Columns(21).HeaderText = "09-"
            DGridFormato.Columns(22).HeaderText = "10"
            DGridFormato.Columns(23).HeaderText = "10-"


            DGridFormato.Columns(24).HeaderText = "11"
            DGridFormato.Columns(25).HeaderText = "11-"
            DGridFormato.Columns(26).HeaderText = "12"
            DGridFormato.Columns(27).HeaderText = "12-"
            DGridFormato.Columns(28).HeaderText = "13"
            DGridFormato.Columns(29).HeaderText = "13-"
            DGridFormato.Columns(30).HeaderText = "14"
            DGridFormato.Columns(31).HeaderText = "14-"
            DGridFormato.Columns(32).HeaderText = "15"
            DGridFormato.Columns(33).HeaderText = "15-"
            DGridFormato.Columns(34).HeaderText = "16"
            DGridFormato.Columns(35).HeaderText = "16-"
            DGridFormato.Columns(36).HeaderText = "17"
            DGridFormato.Columns(37).HeaderText = "17-"
            DGridFormato.Columns(38).HeaderText = "18"
            DGridFormato.Columns(39).HeaderText = "18-"
            DGridFormato.Columns(40).HeaderText = "19"
            DGridFormato.Columns(41).HeaderText = "19-"
            DGridFormato.Columns(42).HeaderText = "20"
            DGridFormato.Columns(43).HeaderText = "20-"


            DGridFormato.Columns(44).HeaderText = "21"
            DGridFormato.Columns(45).HeaderText = "21-"
            DGridFormato.Columns(46).HeaderText = "22"
            DGridFormato.Columns(47).HeaderText = "22-"
            DGridFormato.Columns(48).HeaderText = "23"
            DGridFormato.Columns(49).HeaderText = "23-"
            DGridFormato.Columns(50).HeaderText = "24"
            DGridFormato.Columns(51).HeaderText = "24-"
            DGridFormato.Columns(52).HeaderText = "25"
            DGridFormato.Columns(53).HeaderText = "25-"
            DGridFormato.Columns(54).HeaderText = "26"
            DGridFormato.Columns(55).HeaderText = "26-"
            DGridFormato.Columns(56).HeaderText = "27"
            DGridFormato.Columns(57).HeaderText = "27-"
            DGridFormato.Columns(58).HeaderText = "28"
            DGridFormato.Columns(59).HeaderText = "28-"
            DGridFormato.Columns(60).HeaderText = "29"
            DGridFormato.Columns(61).HeaderText = "29-"
            DGridFormato.Columns(62).HeaderText = "30"
            DGridFormato.Columns(63).HeaderText = "30-"
            DGridFormato.Columns(64).HeaderText = "31"
            DGridFormato.Columns(65).HeaderText = "31-"


            Sw_EmpiezaMedios = False

            If InStr(MedMin, "-") > 0 Then
                ' empieza en medios.
                Sw_EmpiezaMedios = True
                Inicio = Mid(MedMin, 1, 2)
            Else
                Inicio = MedMin

            End If

            If InStr(MedMax, "-") > 0 Then
                Sw_TerminaMedios = True
                Fin = Mid(MedMax, 1, 2)
            Else
                Fin = MedMax
            End If


            Inicio = (Inicio + 2) * 2
            If Sw_EmpiezaMedios = True Then
                Inicio = Inicio - 2
            Else
                Inicio = Inicio - 2
            End If

            Fin = (Fin + 2) * 2

            'If Sw_TerminaMedios Then   'nueva programa
            Fin = Fin - 1
            'End If

            For i As Integer = 4 To DGridFormato.ColumnCount - 1 ''  eran primero 3 y luego eran dos
                DGridFormato.Columns(i).Visible = False

            Next
            ' Medida = DGridPropuesta.Columns(j).HeaderText
            '  row(3) = pub_SumarColumnaGrid(DGridFormato, 3, DGridFormato.RowCount - 1)
            DGridFormato.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i As Integer = Inicio To Fin
                ' sumar
                ''row(i) = pub_SumarColumnaGrid(DGridFormato, i, DGridFormato.RowCount - 1)

                DGridFormato.Columns(i).Visible = True
                If Intervalo = "1" Then
                    If InStr(DGridFormato.Columns(i).HeaderText, "-") > 0 Then
                        DGridFormato.Columns(i).Visible = False
                    End If
                End If
                DGridFormato.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
   
            Next

            'row("total") = pub_SumarColumnaGrid(DGridFormato, 3, DGridFormato.RowCount - 1)

            'dt.Rows.InsertAt(row, 0)
            'DGridFormato.DataSource = dt

            DGridFormato.Columns(DGridFormato.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridFormato.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            DGridFormato.Rows(0).DefaultCellStyle.BackColor = Color.PowderBlue
            DGridFormato.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGridFormato.Rows(0).DefaultCellStyle.Font = New Font(DGridFormato.DefaultCellStyle.Font.FontFamily, DGridFormato.DefaultCellStyle.Font.Size, FontStyle.Bold)




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub




    Public Sub ColorearGrid(ByVal DGridFormato As DataGridView)
        Try
            DGridFormato.Visible = False

            Dim Col1 As Color
            Col1 = Color.LimeGreen
            Dim Col2 As Color
            Col2 = Color.Gold
            Dim Col3 As Color
            Col3 = Color.SkyBlue
            Dim Col4 As Color
            Col4 = Color.Plum
            Dim Col5 As Color

            If DGridFormato.DataSource Is Nothing Then Exit Sub
            For i As Integer = 0 To DGridFormato.Rows.Count - 1
                For j As Integer = 5 To DGridFormato.Columns.Count - 1
                    If DGridFormato.Columns(j).Visible = True Then
                        If DGridFormato.Rows(i).Cells(j).Value = "0" Then

                            If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "VENTA" Then

                                Col5 = Col1
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "EXISTENCIA" Then
                                Col5 = Col2
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PROPUESTA" Then
                                Col5 = Col3
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
                                Col5 = Col4
                            ElseIf DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "NEGRO" Then
                                Col5 = Color.Black
                            Else
                                Col5 = Color.White
                            End If

                            DGridFormato.Rows(i).Cells(j).Style.ForeColor = Col5 ' DGrid.Rows(i).DefaultCellStyle.BackColor
                        Else
                            DGridFormato.Rows(i).Cells(j).Style.ForeColor = Col5 ' DGrid.Rows(i).DefaultCellStyle.BackColor
                        End If


                    End If

                Next
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "VENTA" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col1

                    Continue For
                End If
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "EXISTENCIA" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col2
                    Continue For
                End If
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PROPUESTA" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col3


                    Continue For
                End If
                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "PEDIDO PENDIENTE" Then
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Col4
                    Continue For
                End If

                If DGridFormato.Rows(i).Cells("Concepto").Value.ToString.Trim = "NEGRO" Then
                    DGridFormato.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    DGridFormato.Rows(i).DefaultCellStyle.BackColor = Color.Black

                    Continue For
                End If


            Next


            '' CHECAR PROPUESTA PARA COLOR

            DGridFormato.Visible = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub








    Private Function usp_BorrarAnaModArticulo() As Boolean
        'mreyes 16/Agosto/2016  04:57 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()



                usp_BorrarAnaModArticulo = objCalculo.usp_GeneraAnaModArticulo(2, Marca, "", "", "", "", "", "", "", "", "", "", "", GLB_Idempleado)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Sub Btn_Filtro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Filtro.Click
        If Me.DGridExistencia.Rows.Count >= 1 Then
            DGridExistencia.DataSource = Nothing
            DGridExistencia.Columns.Clear()
            DGridExistencia.Rows.Clear()

        End If
        ''If DGridNegado.Rows.Count >= 1 Then
        ''    DGridNegado.RowCount = 2
        ''    DGridNegado.Rows.Clear()



        ''End If
        ''If DgridPedido.Rows.Count >= 1 Then
        ''    DgridPedido.RowCount = 2
        ''    DgridPedido.Rows.Clear()

        ''End If

        Me.Pnl_Img.Controls.Clear()
        PBar.Value = 0
        Txt_Porc.Text = ""
        ClearMemory()
        PBox.Image = Nothing
        Txt_Marca.Text = ""
        Txt_DescripMarca.Text = ""
        Txt_Modelo.Text = ""
        Txt_Modelo.Enabled = True
        Txt_Marca.Enabled = True
        'Txt_Vendedor.Text = ""
        'Txt_Nombre.Text = ""
        Lbl_Totales.Text = ""
        Txt_Marca.Focus()


    End Sub
    Public Function RandomHoraCierre(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim rand As New System.Random(System.DateTime.Now.Millisecond)
        Return rand.Next(min, max)
    End Function
    Private Sub Imprimir(ByVal Nota As String)
        'mreyes 29/Diciembre/2016   12:44 p.m.

        Try
            '**********************************
            '// La clase "CreaTicket" tiene varios metodos para imprimir con diferentes formatos (izquierda, derecha, centrado, desripcion precio,etc), a
            '   // continuacion se muestra el metodo con ejemplo de parametro que acepta, longitud maxima y un ejemplo de como imprimira, esta clase esta 
            '   // basada en una impresora Epson de matriz de puntos con impresion maxima de 40 caracteres por renglon
            '   // METODO                                      MAX_LONG                        EJEMPLOS
            '   //--------------------------------------------------------------------------------------------------------------------------
            '   // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
            '   // TextoDerecha("Caja 1")                          40                                                        Caja 1
            '   // TextoCentro("Ticket")                           40                                         Ticket   
            '   // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
            '   // EncabezadoVenta()                                n/a                     Articulo        Can    P.Unit    Importe
            '   // LineasGuion()                                    n/a                     ----------------------------------------
            '   // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2    $45.25     $90.50
            '   // LineasTotales()                                  n/a                                                ----------
            '   // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                         $235.25
            '   // LineasAsterisco()                                n/a                     ****************************************
            '   // LineasIgual()                                    n/a                     ========================================
            '   // CortaTicket()
            '   // AbreCajon()

            'MessageBox.Show(Format(fecha, "dd/MM/yyyy"))

            Dim Cant As String = ""
            Dim Descp As String = ""
            Dim Totallinea As String = ""
            Dim Hora As String
            Dim Marca As String
            Dim Modelo As String
            Dim Medida As String
            Dim Linea As String = ""
            Dim L1 As String = ""


            Hora = DateTime.Now.ToString("HH:mm:ss")


            Dim Ticket1 As New CreaTicket()
            Dim nomsuc As String = ""


            nomsuc = GLB_Sucursal
            Ticket1.impresora = "LR2000" '<-- ---- cambia a nombre de la impresora por un puerto por default
            ' Ticket1.impresora = "Brother DCP-L2540DW series"
            Ticket1.AbreCajon()

            '''''''''''''''''''''''''''''''''''''



            Ticket1.TextoIzquierda("Sucursal: " & nomsuc)
            Ticket1.TextoIzquierda("Nota:     " & Nota)
            Ticket1.TextoIzquierda("Vendedor: " & Txt_Vendedor.Text & " " & Txt_Nombre.Text)
            Ticket1.TextoIzquierda("Fecha:    " & GLB_FechaHoy & "    " & Hora)

            'add_this(GLB_FechaHoy)
            Ticket1.TextoIzquierda("")

            Ticket1.TextoCentro("PEDIDO")
            Ticket1.TextoCentro("--------------------------")

            For I As Integer = 0 To DgridPedido.Rows.Count - 2
                Marca = DgridPedido.Rows(I).Cells(0).Value
                Modelo = DgridPedido.Rows(I).Cells(1).Value
                Medida = DgridPedido.Rows(I).Cells(2).Value
                Linea = DgridPedido.Rows(I).Cells(4).Value
                L1 = DgridPedido.Rows(I).Cells(5).Value


                Ticket1.TextoIzquierda("      " & Marca & "    " & Modelo & "    " & Medida)
                Ticket1.TextoIzquierda("      " & Replace(Linea, "Ñ", "N") & " \  " & L1)

            Next
            Ticket1.TextoCentro("--------------------------")

            'Ticket1.TextoCentro("")

            'Ticket1.TextoCentro("NEGADOS")
            'Ticket1.TextoCentro("------------------------------")

            'For I As Integer = 0 To DGridNegado.Rows.Count - 2
            '    Marca = DGridNegado.Rows(I).Cells(0).Value
            '    Modelo = DGridNegado.Rows(I).Cells(1).Value
            '    Medida = DGridNegado.Rows(I).Cells(2).Value

            '    Ticket1.TextoIzquierda("          " & Marca & "    " & Modelo & "    " & Medida)

            'Next



            Ticket1.CortaTicket()



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub


    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub DGridExistencia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGridExistencia.CellContentClick

    End Sub

    Private Sub Txt_Vendedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Vendedor.KeyPress
        If e.KeyChar = ChrW(13) Then
            Txt_Marca.Focus()
        End If
    End Sub

    Private Sub Txt_Vendedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Vendedor.LostFocus
        Try
            Dim ObjDataSet As Data.DataSet
           
            If Txt_Vendedor.Text.Length = 0 Then Exit Sub


            Using objCatalogoEst As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                ObjDataSet = objCatalogoEst.usp_TraerVendedor(Val(Txt_Vendedor.Text), GLB_CveSucursal)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Nombre.Text = ObjDataSet.Tables(0).Rows(0).Item("nombre").ToString

                Else
                    MsgBox("El Número de vendedor, no existe o no pertenece a la sucursal.", MsgBoxStyle.Exclamation, "Error")
                    Txt_Vendedor.Text = ""
                    Txt_Vendedor.Select()

                    'Lbl_Periodo.Text = ""
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGridExistencia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGridExistencia.DoubleClick
        'mreyes 27/Diciembre/2016   12:50 p.m.
        'mreyes 10/Abril/2017   10:51 a.m., se agrega que muestra medidas anteriores y siguientes.

        Try
            Dim columna As Integer = DGridExistencia.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGridExistencia.CurrentCell.RowIndex


            MedidaDC = ""
            MedidaDC = DGridExistencia.Columns(columna).HeaderText


            If DGridExistencia.Rows(0).Cells(columna).Value > 0 Then
                'encontro el producto.
                If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaDC) = True Then
                    DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaDC, 0, Linea, L1)
                End If

                '' buscar si existe el siuiente y anterior, según intervalo.

                'Call pub_TraerMedidas(MedidaDC)

                '' limpiar
                If Me.DGridExistencia.Rows.Count >= 1 Then
                        DGridExistencia.DataSource = Nothing
                        DGridExistencia.Columns.Clear()
                        DGridExistencia.Rows.Clear()

                    End If

                    Me.Pnl_Img.Controls.Clear()
                    PBar.Value = 0
                    Txt_Porc.Text = ""
                    ClearMemory()
                    PBox.Image = Nothing
                    Txt_Marca.Text = ""
                    Txt_DescripMarca.Text = ""
                    Txt_Modelo.Text = ""
                    Txt_Modelo.Enabled = True
                    Txt_Marca.Enabled = True


                    Lbl_Totales.Text = ""
                    Txt_Marca.Focus()



                Else
                    ' no encontro el producto y lo esta negando.

                    DGridNegado.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaDC)
                Call pub_TraerMedidas(MedidaDC)
                Call TraerArticulos(MedidaDC)





            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Function pub_BuscarGrid(Marca As String, Modelo As String, Medida As String) As Boolean
        'mreyes 11/Abril/2017   04:01 p.m.
        pub_BuscarGrid = False
        Try
            For j As Integer = 0 To DgridPedido.Rows.Count - 1
                If Marca = DgridPedido.Rows(j).Cells("Column1").Value And Modelo = DgridPedido.Rows(j).Cells("Column2").Value And Medida = DgridPedido.Rows(j).Cells("Column3").Value Then
                    pub_BuscarGrid = False
                    Exit Function
                End If
            Next
            pub_BuscarGrid = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub pub_TraerMedidas(MedidaDC As String)
        'mreyes 10/Abril/2017   12:12 p.m.
        'checar si existe la medida no insertarla. 


        Dim objDataSet As Data.DataSet
        Dim MedidaMientras As String = ""

        If Intervalo = "-" Then
            ' es medios
            If InStr(MedidaDC, "-") Then
                'ya contiene medios 
                MedidaMientras = Mid(MedidaDC, 1, 2)
                ' buscar si hay existencia.
                ' insertar en pedido. 
                Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    objDataSet = objRegistro.usp_TraerExistenciaDirectaMySqlporMedida(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, GLB_CveSucursal)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si encontro existencia.
                        If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras) = True Then
                            DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, 2, Linea, L1)
                        End If
                    End If
                End Using
                MedidaMientras = Val(Mid(MedidaDC, 1, 2)) + 1
                Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    objDataSet = objRegistro.usp_TraerExistenciaDirectaMySqlporMedida(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, GLB_CveSucursal)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si encontro existencia.
                        If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras) = True Then
                            DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, 2, Linea, L1)
                        End If
                    End If
                End Using
            Else
                ' es con medios 
                MedidaMientras = Mid(MedidaDC, 1, 2) & "-"
                Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    objDataSet = objRegistro.usp_TraerExistenciaDirectaMySqlporMedida(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, GLB_CveSucursal)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si encontro existencia.
                        If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras) = True Then
                            DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, 2, Linea, L1)
                        End If
                    End If
                End Using
                MedidaMientras = Val(Mid(MedidaDC, 1, 2)) - 1 & "-"
                Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                    objDataSet = objRegistro.usp_TraerExistenciaDirectaMySqlporMedida(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, GLB_CveSucursal)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si encontro existencia.
                        If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras) = True Then
                            DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, 2, Linea, L1)
                        End If
                    End If
                End Using
            End If


        Else
            ' son enteros
            MedidaMientras = Val(MedidaDC) - Intervalo
            Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                objDataSet = objRegistro.usp_TraerExistenciaDirectaMySqlporMedida(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, GLB_CveSucursal)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    ' si encontro existencia.
                    If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras) = True Then
                        DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, 2, Linea, L1)
                    End If
                End If
            End Using
            MedidaMientras = Val(MedidaDC) + Intervalo
            Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                objDataSet = objRegistro.usp_TraerExistenciaDirectaMySqlporMedida(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, GLB_CveSucursal)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    ' si encontro existencia.
                    If pub_BuscarGrid(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras) = True Then
                        DgridPedido.Rows.Add(Txt_Marca.Text, Txt_Modelo.Text, MedidaMientras, 2, Linea, L1)
                    End If
                End If
            End Using

        End If
    End Sub
    Public Sub ClearMemory()
        Try
            Dim Mem As Process

            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TraerArticulos(ByVal Medida As String)
        Using objArticulos As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try

                PBar.Visible = True
                Txt_Porc.Visible = True

                ClearMemory()
                Pnl_Img.AutoScroll = False



                Me.Cursor = Cursors.WaitCursor

                If Division = "" Then Division = "0"
                If Depto = "" Then Depto = "0"
                If Familia = "" Then Familia = "0"
                If Linea = "" Then Linea = "0"
                If L1 = "" Then L1 = "0"
                If L2 = "" Then L2 = "0"
                If L3 = "" Then L3 = "0"
                If L4 = "" Then L4 = "0"
                If L5 = "" Then L5 = "0"
                If L6 = "" Then L6 = "0"




                objDataSet = objArticulos.usp_TraerArticulosMismaEstructura(GLB_CveSucursal, Medida, Division, Depto, "0",
                                                                    Linea, L1, L2, L3, L4, L5, L6, IdAgrupacion)

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
                    ' yPB += 315
                    yPB += 170
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
                    cms.Items.Add("Ventas")
                    cms.Items(0).Visible = False
                    cms.Items(1).Visible = False
                    cms.Items(2).Visible = False

                    '''''cms.Show()
                    MarcaDC = ""
                    modelodc = ""

                    PBoxFoto.ContextMenuStrip = cms
                    cms.Items(0).Tag = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("modelo")
                    cms.Items(1).Tag = objDataSet.Tables(0).Rows(i).Item("marca") + "-" + objDataSet.Tables(0).Rows(i).Item("modelo")
                    cms.Items(0).Image = My.Resources.monitoreo
                    cms.Items(1).Image = My.Resources.pendiente
                    AddHandler cms.Items(0).Click, AddressOf AbrirExistencias_Click
                    AddHandler cms.Items(1).Click, AddressOf AbrirPedidosPend_Click
                    MarcaDC = objDataSet.Tables(0).Rows(i).Item("marca").ToString
                    Modelodc = objDataSet.Tables(0).Rows(i).Item("modelo").ToString
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
                    'yLb += 315
                    yLb += 170
                    ContadorAux = 0
                End If
                ContadorAux += 1



                LblArticulo.Text = objDataSet.Tables(0).Rows(i).Item("marca").ToString & " " & objDataSet.Tables(0).Rows(i).Item("modelo").ToString


                LblArticulo.BorderStyle = BorderStyle.FixedSingle
                LblArticulo.Width = 70
                LblArticulo.Height = 20
                ' LblArticulo.Width = 170
                'LblArticulo.Height = 160
                ''''
                LblArticulo.BorderStyle = BorderStyle.None
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
    Private Sub MandarFocusFLPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Pnl_Img.Focus()
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

    Private Sub AbrirFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim nombre As String = ""


            Dim PBox As PictureBox = sender

            If Not IsDBNull(Menu) Then
                If Not IsDBNull(PBox) Then
                    Dim nom As String = PBox.Name
                    nombre = nom
                End If
            End If

            MarcaDC = Mid(nombre, 1, 3)
            Modelodc = Mid(nombre, 5, 7)
            'es opcion 
            DgridPedido.Rows.Add(MarcaDC, Modelodc, MedidaDC, 1, Linea, L1)
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Pnl_Img_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Pnl_Img_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Img.Paint

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Txt_Vendedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Vendedor.TextChanged

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub DgridPedido_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgridPedido.CellContentClick

    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged

    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub frmPedidoBodega_Leave(sender As Object, e As EventArgs) Handles Me.Leave

    End Sub
End Class
