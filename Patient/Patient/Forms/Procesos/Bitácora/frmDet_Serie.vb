Imports System.Text.RegularExpressions

Public Class frmDet_Serie
    'mreyes cambio a SQL, el 8/Febrero/2019 09:33 a.m.

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

    Public Sucursal As String = ""
    Public Marca As String = ""
    Public Estilon As String = ""
    Public OrdeComp As String = ""
    Public Proveedor As String = ""
    Dim Clasif As String = ""
    Public Fecha As Date = "1900-01-01"

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'FechaInib = Format(Now.Add(New TimeSpan(-90, 0, 0, 0)), "yyyyMMdd")
            'FechaFinb = Format(Now.Date, "yyyyMMdd")

            
            Call GenerarToolTip()
            Txt_Serie.Focus()

            'blnEsPrimero = False

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    






    Private Sub usp_TraerEstructura()
        Using objCatalogoEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
            Try
                objDataSet = objCatalogoEstilos.usp_TraerEstructura(Val(Txt_IdArticulo.Text), Txt_Marca.Text, Txt_Modelo.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then


                    Lbl_Estructura.Text = objDataSet.Tables(0).Rows(0).Item("descripdivision").ToString & " \ " & _
                    objDataSet.Tables(0).Rows(0).Item("descripdepto").ToString & " \ " & _
                    objDataSet.Tables(0).Rows(0).Item("descripfamilia").ToString & " \ " & _
                    objDataSet.Tables(0).Rows(0).Item("descriplinea").ToString '& " \ " & _


                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl1")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl1").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl2")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl2").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl3")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl3").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl4")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl4").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl5")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl5").ToString
                    End If

                    If Not IsDBNull(objDataSet.Tables(0).Rows(0).Item("descripl6")) Then
                        Lbl_Estructura.Text = Lbl_Estructura.Text & " \ " & objDataSet.Tables(0).Rows(0).Item("descripl6").ToString
                    End If


                Else

                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(DGrid1, "Detallado de existencias del Artículo")

            ToolTip.SetToolTip(Btn_Salir, "Salir")

            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Datos")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub frmCatalogoExistenciaEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                Me.Dispose()
                Me.Close()
            End If
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

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Try

            DGrid1.DataSource = Nothing

            Sucursal = ""



            DGrid2.DataSource = Nothing

            Lbl_Status.Text = ""
            Txt_Marca.Text = ""
            Txt_Modelo.Text = ""
            Txt_IdArticulo.Text = ""
            Txt_Estilof.Text = ""
            Txt_Proveedor.Text = ""
            Txt_DescripMarca.Text = ""
            Txt_Raz_Soc.Text = ""
            Txt_Descripc.Text = ""
            'Lbl_Periodo.Text = ""
            Lbl_Estructura.Text = ""
            Lbl_FechaUltVta.Text = ""
            Lbl_UltEntrada.Text = ""
            'Lbl_TotalS.Text = ""

            Txt_Marca.Enabled = True
            Txt_Modelo.Enabled = True


            PBox.Image = Nothing

            Txt_Serie.Text = ""
            Txt_Serie.Focus()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim myForm As New frmConsultaSeries
            'If Sw_Factura = True Then
            '    myForm.Tipo = "F"
            'Else
            '    myForm.Tipo = "D"
            'End If
            myForm.Tipo = "M"
            myForm.Marca = Txt_Marca.Text
            myForm.Modelo = Txt_Modelo.Text
            If GLB_CveSucursal = "01" Or GLB_CveSucursal = "02" Or GLB_CveSucursal = "06" Or GLB_CveSucursal = "07" Or GLB_CveSucursal = "08" Or GLB_CveSucursal = "11" Then
                myForm.Sucursal = GLB_CveSucursal
            End If

            myForm.ShowDialog()

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




    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Dim fecha, archivo As String

        Try
            If (GridView1.RowCount > 0) Then
                If sfdRuta.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    fecha = Date.Today.ToString("dd-MM-yyyy")
                    archivo = sfdRuta.FileName.Replace(".xls", "")


                    DGrid1.ExportToXls(archivo + "__" + fecha + ".xls")

                    System.Diagnostics.Process.Start(archivo + "__" + fecha + ".xls")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Chk_Lerdo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus
        Try

            'Obtiene el id del articulo 
            Lbl_Aparador.Text = ""

            If Txt_Serie.Text = "" Then
                Txt_Serie.Focus()
                Exit Sub
            End If

            Txt_Serie.Text = pub_RellenarIzquierda(Txt_Serie.Text, 13)
            Using objCatalogoEst As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEst.usp_TraerModeloSerie(Txt_serie.Text )
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("modelo").ToString
                    Txt_Estilof.Text = objDataSet.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Medida.Text = objDataSet.Tables(0).Rows(0).Item("medida").ToString

                    If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                        Lbl_Status.Text = "BAJA"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString = "AC" Then
                        Lbl_Status.Text = "ACTIVO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString = "TR" Then
                        Lbl_Status.Text = "TRASPASO"
                    ElseIf objDataSet.Tables(0).Rows(0).Item("status").ToString = "IF" Then
                        Lbl_Status.Text = "INVENTARIO"
                    Else
                        Lbl_Status.Text = objDataSet.Tables(0).Rows(0).Item("status").ToString
                    End If


                    If objDataSet.Tables(0).Rows(0).Item("apa").ToString <> "" Then
                        Lbl_Aparador.Text = "EN APARADOR"
                    End If

                    Call CargarFotoArticulo()
                    Call usp_TraerEstructura()
                    Call RellenaGrid()
                    Call TraerCostoPrecio()
                    Txt_Marca.Enabled = False
                    Txt_Modelo.Enabled = False


                Else
                    MsgBox("La serie ingresada no existe.", MsgBoxStyle.Exclamation, "Aviso")
                    Txt_Marca.Text = ""
                    Txt_Modelo.Text = ""
                    Txt_DescripMarca.Text = ""
                    Txt_Marca.Select()
                    Lbl_Estructura.Text = ""
                    Txt_Serie.Text = ""
                    'Lbl_Periodo.Text = ""
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaGrid()
        'mreyes 30/Junio/2012   10:34 a.m.
        Using objRegistro As New BCL.BCLTraspasosAutomaticos(GLB_ConStringDwhSQL)

            Try
                Me.Cursor = Cursors.WaitCursor
                ' DGrid1.ReadOnly = False
                DGrid1.DataSource = Nothing

                ''''''''''''''''''

                objDataSet = objRegistro.usp_PpalDet_Serie(Txt_Serie.Text)

                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section

                    DGrid1.DataSource = objDataSet.Tables(0)

                    InicializaGrid()

                    'LimpiarBusqueda()
                    Me.Cursor = Cursors.Default
                    Btn_Excel.Enabled = True

                Else


                    Me.Cursor = Cursors.Default
                    MsgBox("No se encontraron movimientos.", MsgBoxStyle.Critical, "Aviso")
                    Btn_Excel.Enabled = False

                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub


    Sub InicializaGrid()
        'mreyes 30/Junio/2012 10:47 a.m.



        Dim i As Integer

            Try
                GridView1.Columns(0).Caption = "Tipo"
                GridView1.Columns(1).Caption = "Sucursal"
                GridView1.Columns(2).Caption = "Folio"
                GridView1.Columns(3).Caption = "Fum"
                GridView1.Columns(4).Caption = "Estatus"
                GridView1.Columns(5).Caption = "Usuario"

                For i = 0 To 5 Step 1
                    GridView1.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GridView1.Columns(i).AppearanceHeader.Font = New Font(GridView1.Columns(i).AppearanceCell.Font, FontStyle.Bold)
                    GridView1.Columns(i).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GridView1.Columns(i).OptionsColumn.ReadOnly = True
                Next


                GridView1.OptionsView.ColumnAutoWidth = False


                GridView1.BestFitColumns()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
    End Sub

    Private Sub TraerCostoPrecio()
        Try
            Dim objDataSetAux As DataSet
            Dim Dsctos As Integer = 0
            Dim precdesc As String = ""



            'trae las diferentes corridas del modelo
            Using objCorrida As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                objDataSetAux = objCorrida.usp_TraerPrecios(1, IIf(GLB_CveSucursal = "11", "11", "99"), Txt_Marca.Text, Txt_Modelo.Text)
            End Using
            Dim Corridas As String = ""


            'Puede ver los costos de modelo
            'If GLB_Sw_Costos = True Then

            If objDataSetAux.Tables(0).Rows.Count > 0 Then
                'Populate the Project Details section 

                DGrid2.DataSource = objDataSetAux.Tables(0)
                'If Sw_Load = False Then
                InicializaGrid2()
                'End If
                'LimpiarBusqueda()
                Me.Cursor = Cursors.Default

            Else

                Me.Cursor = Cursors.Default
                MsgBox("No se encontraron PRECIOS que cumplan con los requisitos del filtro. Intente nuevamente.", MsgBoxStyle.Critical, "Aviso")
                Btn_Excel.Enabled = False
            End If
            Me.Cursor = Cursors.Default



            'For i As Integer = 0 To DGrid2.RowCount - 1
            '    If DGrid2.Rows(i).Cells(0).Value = "TORREÓN" Then
            '        DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
            '    Else
            '        DGrid2.Rows(i).DefaultCellStyle.BackColor = Color.Beige
            '    End If

            'Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub InicializaGrid2()


        Dim i As Integer

            Try
            GridView2.Columns(0).Caption = "Plaza"
            GridView2.Columns(1).Visible = False
            GridView2.Columns(2).Visible = False
            GridView2.Columns(3).Caption = "De"
            GridView2.Columns(4).Caption = "A"
            GridView2.Columns(5).Visible = False
            GridView2.Columns(6).Visible = False
            GridView2.Columns(7).Caption = "Normal"

            GridView2.Columns(8).Caption = "Perciero"
            GridView2.Columns(9).Caption = "Contado"
            GridView2.Columns(10).Caption = "Crédito"
            GridView2.Columns(11).Caption = "Promoción"
            GridView2.Columns(12).Visible = False
            GridView2.Columns(13).Caption = "Tipo Perciero"
            GridView2.Columns(14).Visible = False

            GridView2.Columns(15).Visible = False


            For i = 0 To 13 Step 1
                GridView2.Columns(i).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView2.Columns(i).AppearanceHeader.Font = New Font(GridView2.Columns(i).AppearanceCell.Font, FontStyle.Bold)
                GridView2.Columns(i).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView2.Columns(i).OptionsColumn.ReadOnly = True
            Next


            GridView2.OptionsView.ColumnAutoWidth = False


            GridView2.BestFitColumns()




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DGrid1_Click(sender As Object, e As EventArgs) Handles DGrid1.Click

    End Sub

    Private Sub Txt_Serie_TextChanged(sender As Object, e As EventArgs) Handles Txt_Serie.TextChanged

    End Sub

    Private Sub Txt_Serie_MouseLeave(sender As Object, e As EventArgs) Handles Txt_Serie.MouseLeave

    End Sub
End Class
