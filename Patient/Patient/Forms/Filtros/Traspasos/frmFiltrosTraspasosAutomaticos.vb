Public Class frmFiltrosTraspasosAutomaticos
    'mreyes 19/Julio/2016   11:08 a.m.

    Dim Sql As String

    Public Sw_Consulta As Boolean = False
    Private objDataSet As Data.DataSet
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Dim blnEntroDivisiones As Boolean = False
    Dim blnEntroDepto As Boolean = False
    Dim blnEntroFamilia As Boolean = False
    Dim blnEntroLinea As Boolean = False
    Dim blnEntroL1 As Boolean = False
    Dim blnEntroL2 As Boolean = False
    Dim blnEntroL3 As Boolean = False
    Dim blnEntroL4 As Boolean = False
    Dim blnEntroL5 As Boolean = False
    Dim blnEntroL6 As Boolean = False
    Public Suc As String = ""
    Public Plaza As String = ""

    Public objDataSetModelos1 As Data.DataSet

    Public Renglon As Integer = 0
    Public intposicion As Integer = 0
    Public inttotalrows As Integer = 0
    Public Marca As String = ""
    Public Modelo As String = ""
    Public Leyenda As String = ""

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        'mreyes 19/Julio/2016   11:32 a.m.
        Dim objDataSetModelos As Data.DataSet
  
        Dim Plaza As String = ""

        Try

            If Sw_Consulta = True Then
                If usp_GeneraAnaModArticulo() = True Then
                   
                    Using objCatalogoEst As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                        objDataSetModelos1 = objCatalogoEst.usp_TraerAnaModArticulo(Txt_Marca.Text, IIf(Txt_IdDivision.Text = "", 0, Txt_IdDivision.Text), IIf(Txt_IdDepto.Text = "", 0, Txt_IdDepto.Text), Txt_DescripFamilia.Text, Txt_DescripLinea.Text, Txt_DescripL1.Text, Txt_DescripL2.Text, Txt_DescripL3.Text, Txt_DescripL4.Text, Txt_DescripL5.Text, Txt_DescripL6.Text, IIf(Txt_Agrupacion.Text = "", 0, Txt_Agrupacion.Text), GLB_Idempleado)
                        If objDataSetModelos1.Tables(0).Rows.Count > 0 Then
                            '' ya hay anteriores.. 
                            Renglon = objDataSetModelos1.Tables(0).Rows(0).Item("renglon")
                            intposicion = objDataSetModelos1.Tables(0).Rows(0).Item("renglon")
                            inttotalrows = objDataSetModelos1.Tables(0).Rows.Count
                            Marca = objDataSetModelos1.Tables(0).Rows(0).Item("marca")
                            Modelo = objDataSetModelos1.Tables(0).Rows(0).Item("estilon")
                            Leyenda = intposicion & " de " & inttotalrows
                        End If
                    End Using
                    Me.Close()


                End If

                Exit Sub
            End If

            Sw_Filtro = True
            Lbl_Leyenda.Visible = True
            ' If MsgBox("Esta seguro de generar las propuestas de traspasos para la selección.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Plaza = Cbo_Plaza.SelectedValue

            '' ir a buscar si tiene ya registros 
            Using objCatalogoEst As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
                objDataSetModelos = objCatalogoEst.usp_TraerProTraspArticulo(Txt_Marca.Text, Txt_Modelo.Text, IIf(Txt_IdDivision.Text = "", 0, Txt_IdDivision.Text), IIf(Txt_IdDepto.Text = "", 0, Txt_IdDepto.Text), Txt_DescripFamilia.Text, Txt_DescripLinea.Text, Txt_DescripL1.Text, Txt_DescripL2.Text, Txt_DescripL3.Text, Txt_DescripL4.Text, Txt_DescripL5.Text, Txt_DescripL6.Text, IIf(Txt_Agrupacion.Text = "", 0, Txt_Agrupacion.Text), 0)
                If objDataSetModelos.Tables(0).Rows.Count > 0 Then
                    '' ya hay anteriores.. 
                    Renglon = objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                    intposicion = objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                    inttotalrows = objDataSetModelos.Tables(0).Rows.Count - 1 '+ objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                    Marca = objDataSetModelos.Tables(0).Rows(0).Item("marca")
                    Modelo = objDataSetModelos.Tables(0).Rows(0).Item("estilon")
                    Leyenda = intposicion & " de " & inttotalrows
                Else
                    If usp_GeneraProTraspArticulo() = True Then
                        '  MsgBox("No pudo generar propuesta", MsgBoxStyle.Critical, "Error")
                        '   Exit Sub
                        objDataSetModelos = objCatalogoEst.usp_TraerProTraspArticulo(Txt_Marca.Text, Txt_Modelo.Text, IIf(Txt_IdDivision.Text = "", 0, Txt_IdDivision.Text), IIf(Txt_IdDepto.Text = "", 0, Txt_IdDepto.Text), Txt_DescripFamilia.Text, Txt_DescripLinea.Text, Txt_DescripL1.Text, Txt_DescripL2.Text, Txt_DescripL3.Text, Txt_DescripL4.Text, Txt_DescripL5.Text, Txt_DescripL6.Text, IIf(Txt_Agrupacion.Text = "", 0, Txt_Agrupacion.Text), 0)
                        If objDataSetModelos.Tables(0).Rows.Count > 0 Then
                            '' ya hay anteriores.. 
                            Renglon = objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                            intposicion = objDataSetModelos.Tables(0).Rows(0).Item("renglon")
                            inttotalrows = objDataSetModelos.Tables(0).Rows.Count - 1
                            Marca = objDataSetModelos.Tables(0).Rows(0).Item("marca")
                            Modelo = objDataSetModelos.Tables(0).Rows(0).Item("estilon")
                            Leyenda = intposicion & " de " & inttotalrows
                        End If

                    End If
                End If
            End Using




            Lbl_Leyenda.Visible = False
            Dim myForm As New frmAnalisisPropuestaTraspasos

            myForm.MdiParent = BitacoraMain
            myForm.Sw_Menu = True


            myForm.Txt_IdArticulo.Text = Renglon

            myForm.intPosicion = intposicion
            myForm.intTotalRows = inttotalrows
            myForm.Txt_Marca.Text = Marca
            myForm.Txt_Modelo.Text = Modelo
            myForm.Lbl_Totales.Text = Leyenda
            'objDataSetOC = objDataSet.Clone
            myForm.objDataSetModelos = objDataSetModelos.Copy
            myForm.Marca = Txt_Marca.Text
            myForm.Estilon = Txt_Modelo.Text
            myForm.IdDivisiones = IIf(Txt_IdDivision.Text = "", 0, Txt_IdDivision.Text)
            myForm.IdDepto = IIf(Txt_IdDepto.Text = "", 0, Txt_IdDepto.Text)

            myForm.IdFamilia = Txt_DescripFamilia.Text
            myForm.IdLinea = Txt_DescripLinea.Text
            myForm.IdL1 = Txt_DescripL1.Text
            myForm.IdL2 = Txt_DescripL2.Text
            myForm.IdL3 = Txt_DescripL3.Text
            myForm.IdL4 = Txt_DescripL4.Text
            myForm.IdL5 = Txt_DescripL5.Text
            myForm.IdL6 = Txt_DescripL6.Text

            myForm.IdAgrupacion = IIf(Txt_Agrupacion.Text = "", 0, Txt_Agrupacion.Text)


            myForm.WindowState = FormWindowState.Maximized
            myForm.Accion = 2

            myForm.Show()


            Me.Close()
            '' Guardar filtro 


            '' Termina guardar filtro




            '' Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function usp_GeneraAnaModArticulo() As Boolean
        'mreyes 16/Agosto/2016  04:24 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()

                Marca = IIf(Txt_Marca.Text = "", "0", Txt_Marca.Text)
                Txt_IdDivision.Text = IIf(Txt_IdDivision.Text = "", "0", Txt_IdDivision.Text)
                Txt_IdDepto.Text = IIf(Txt_IdDepto.Text = "", "0", Txt_IdDepto.Text)
                Txt_IdFamilia.Text = IIf(Txt_IdFamilia.Text = "", "0", Txt_IdFamilia.Text)
                Txt_IdLinea.Text = IIf(Txt_IdLinea.Text = "", "0", Txt_IdLinea.Text)
                Txt_IdL1.Text = IIf(Txt_IdL1.Text = "", "0", Txt_IdL1.Text)
                Txt_IdL2.Text = IIf(Txt_IdL2.Text = "", "0", Txt_IdL2.Text)
                Txt_IdL3.Text = IIf(Txt_IdL3.Text = "", "0", Txt_IdL3.Text)
                Txt_IdL4.Text = IIf(Txt_IdL4.Text = "", "0", Txt_IdL4.Text)
                Txt_IdL5.Text = IIf(Txt_IdL5.Text = "", "0", Txt_IdL5.Text)
                Txt_IdL6.Text = IIf(Txt_IdL6.Text = "", "0", Txt_IdL6.Text)
                Txt_Agrupacion.Text = IIf(Txt_Agrupacion.Text = "", "0", Txt_Agrupacion.Text)



                usp_GeneraAnaModArticulo = objCalculo.usp_GeneraAnaModArticulo(1, Marca, Txt_IdDivision.Text, Txt_IdDepto.Text, Txt_DescripFamilia.Text, Txt_DescripLinea.Text, Txt_DescripL1.Text, Txt_DescripL2.Text, Txt_DescripL3.Text, Txt_DescripL4.Text, Txt_DescripL5.Text, Txt_DescripL6.Text, Txt_Agrupacion.Text, GLB_Idempleado)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function usp_GeneraProTraspArticulo() As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.

        Using objCalculo As New BCL.BCLTraspasosAutomaticos(GLB_ConStringSirCoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Dim Marca As String = ""
                Application.DoEvents()

                Marca = IIf(Txt_Marca.Text = "", "0", Txt_Marca.Text)
                Txt_IdDivision.Text = IIf(Txt_IdDivision.Text = "", "0", Txt_IdDivision.Text)
                Txt_IdDepto.Text = IIf(Txt_IdDepto.Text = "", "0", Txt_IdDepto.Text)
                Txt_IdFamilia.Text = IIf(Txt_IdFamilia.Text = "", "0", Txt_IdFamilia.Text)
                Txt_IdLinea.Text = IIf(Txt_IdLinea.Text = "", "0", Txt_IdLinea.Text)
                Txt_IdL1.Text = IIf(Txt_IdL1.Text = "", "0", Txt_IdL1.Text)
                Txt_IdL2.Text = IIf(Txt_IdL2.Text = "", "0", Txt_IdL2.Text)
                Txt_IdL3.Text = IIf(Txt_IdL3.Text = "", "0", Txt_IdL3.Text)
                Txt_IdL4.Text = IIf(Txt_IdL4.Text = "", "0", Txt_IdL4.Text)
                Txt_IdL5.Text = IIf(Txt_IdL5.Text = "", "0", Txt_IdL5.Text)
                Txt_IdL6.Text = IIf(Txt_IdL6.Text = "", "0", Txt_IdL6.Text)
                Txt_Agrupacion.Text = IIf(Txt_Agrupacion.Text = "", "0", Txt_Agrupacion.Text)



                usp_GeneraProTraspArticulo = objCalculo.usp_GeneraProTraspArticulo(Marca, Txt_Modelo.Text, Txt_IdDivision.Text, Txt_IdDepto.Text, Txt_DescripFamilia.Text, Txt_DescripLinea.Text, Txt_DescripL1.Text, Txt_DescripL2.Text, Txt_DescripL3.Text, Txt_DescripL4.Text, Txt_DescripL5.Text, Txt_DescripL6.Text, Txt_Agrupacion.Text, GLB_Idempleado, 0)

                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub LimpiarDatos()
        Try
            Txt_Marca.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

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

            RellenaComboPlaza()
            RellenaComboSucursal()




  
            Me.Txt_Marca.Text = ""
            Txt_Modelo.Text = ""
            Txt_Agrupacion.Text = ""
            Txt_DescripAgrup.Text = ""

            txt_DescripMarca.Text = ""
            Txt_IdDivision.Text = ""
            Txt_Division.Text = ""
            Txt_DescripDivision.Text = ""
            Txt_IdDepto.Text = ""
            Txt_Depto.Text = ""
            Txt_DescripDepto.Text = ""
            Txt_IdFamilia.Text = ""
            Txt_Familia.Text = ""
            Txt_DescripFamilia.Text = ""
            Txt_IdLinea.Text = ""
            Txt_Linea.Text = ""
            Txt_DescripLinea.Text = ""
            Txt_IdL1.Text = ""
            Txt_L1.Text = ""
            Txt_DescripL1.Text = ""
            Txt_IdL2.Text = ""
            Txt_L2.Text = ""
            Txt_DescripL2.Text = ""
            Txt_IdL3.Text = ""
            Txt_L3.Text = ""
            Txt_DescripL3.Text = ""
            Txt_IdL4.Text = ""
            Txt_L4.Text = ""
            Txt_DescripL4.Text = ""
            Txt_IdL5.Text = ""
            Txt_L5.Text = ""
            Txt_DescripL5.Text = ""
            Txt_IdL6.Text = ""
            Txt_L6.Text = ""
            Txt_DescripL6.Text = ""
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

    Private Sub frmFiltrosEstilos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
        RellenaComboSucursal()
        RellenaComboPlaza()

    End Sub


#Region "METODOS"

    Private Sub usp_TraerDivisiones()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDivisiones(CInt(Txt_IdDivision.Text), Txt_Division.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDivision.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Division.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDivision.Text = objDataSet.Tables(0).Rows(0).Item("iddivisiones").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "DI"
                    myForm.ShowDialog()
                    Txt_IdDivision.Text = myForm.IdCampo
                    Txt_Division.Text = myForm.ClaveCampo
                    Txt_DescripDivision.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerDeptos()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstDepto(CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_Depto.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_DescripDepto.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Depto.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_IdDepto.Text = objDataSet.Tables(0).Rows(0).Item("iddepto").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "D"
                    myForm.IdSuperior1 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdDepto.Text = myForm.IdCampo
                    Txt_Depto.Text = myForm.ClaveCampo
                    Txt_DescripDepto.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerFamilia()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstFamilia(CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_Familia.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdFamilia.Text = objDataSet.Tables(0).Rows(0).Item("idfamilia").ToString
                    Txt_DescripFamilia.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Familia.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripFamilia.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "F"
                    myForm.IdSuperior1 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdFamilia.Text = myForm.IdCampo
                    Txt_Familia.Text = myForm.ClaveCampo
                    Txt_DescripFamilia.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerLinea()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstLinea(CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_Linea.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdLinea.Text = objDataSet.Tables(0).Rows(0).Item("idlinea").ToString
                    Txt_DescripLinea.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_Linea.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    Txt_DescripLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "L"
                    myForm.IdSuperior1 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdLinea.Text = myForm.IdCampo
                    Txt_Linea.Text = myForm.ClaveCampo
                    Txt_DescripLinea.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerL1()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdL1.Text.Trim = "" Then
                    Txt_IdL1.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl1(CInt(Txt_IdL1.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_L1.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdL1.Text = objDataSet.Tables(0).Rows(0).Item("idl1").ToString
                    Txt_DescripL1.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_L1.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "S"
                    myForm.IdSuperior1 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdL1.Text = myForm.IdCampo
                    Txt_L1.Text = myForm.ClaveCampo
                    Txt_DescripL1.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerL2()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdL1.Text.Trim = "" Then
                    Txt_IdL1.Text = 0
                End If
                If Txt_IdL2.Text.Trim = "" Then
                    Txt_IdL2.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl2(CInt(Txt_IdL2.Text), CInt(Txt_IdL1.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_L2.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdL2.Text = objDataSet.Tables(0).Rows(0).Item("idl2").ToString
                    Txt_DescripL2.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_L2.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    'Txt_DescripSubSubLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "SS"
                    myForm.IdSuperior1 = CInt(Txt_IdL1.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior5 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdL2.Text = myForm.IdCampo
                    Txt_L2.Text = myForm.ClaveCampo
                    Txt_DescripL2.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerL3()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdL1.Text.Trim = "" Then
                    Txt_IdL1.Text = 0
                End If
                If Txt_IdL2.Text.Trim = "" Then
                    Txt_IdL2.Text = 0
                End If
                If Txt_IdL3.Text.Trim = "" Then
                    Txt_IdL3.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl3(CInt(Txt_IdL3.Text), CInt(Txt_IdL2.Text), CInt(Txt_IdL1.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_L3.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdL3.Text = objDataSet.Tables(0).Rows(0).Item("idl3").ToString
                    Txt_DescripL3.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_L3.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    'Txt_DescripSubSubLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "SSS"
                    myForm.IdSuperior1 = CInt(Txt_IdL2.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdL1.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior5 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior6 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdL3.Text = myForm.IdCampo
                    Txt_L3.Text = myForm.ClaveCampo
                    Txt_DescripL3.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerL4()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdL1.Text.Trim = "" Then
                    Txt_IdL1.Text = 0
                End If
                If Txt_IdL2.Text.Trim = "" Then
                    Txt_IdL2.Text = 0
                End If
                If Txt_IdL3.Text.Trim = "" Then
                    Txt_IdL3.Text = 0
                End If
                If Txt_IdL4.Text.Trim = "" Then
                    Txt_IdL4.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl4(CInt(Txt_IdL4.Text), CInt(Txt_IdL3.Text), CInt(Txt_IdL2.Text), CInt(Txt_IdL1.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_L4.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdL4.Text = objDataSet.Tables(0).Rows(0).Item("idl4").ToString
                    Txt_DescripL4.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_L4.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    'Txt_DescripSubSubLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "SSSS"
                    myForm.IdSuperior1 = CInt(Txt_IdL3.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdL2.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdL1.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior5 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior6 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior7 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdL4.Text = myForm.IdCampo
                    Txt_L4.Text = myForm.ClaveCampo
                    Txt_DescripL4.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerL5()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdL1.Text.Trim = "" Then
                    Txt_IdL1.Text = 0
                End If
                If Txt_IdL2.Text.Trim = "" Then
                    Txt_IdL2.Text = 0
                End If
                If Txt_IdL3.Text.Trim = "" Then
                    Txt_IdL3.Text = 0
                End If
                If Txt_IdL4.Text.Trim = "" Then
                    Txt_IdL4.Text = 0
                End If
                If Txt_IdL5.Text.Trim = "" Then
                    Txt_IdL5.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl5(CInt(Txt_IdL5.Text), CInt(Txt_IdL4.Text), CInt(Txt_IdL3.Text), CInt(Txt_IdL2.Text), CInt(Txt_IdL1.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_L5.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdL5.Text = objDataSet.Tables(0).Rows(0).Item("idl5").ToString
                    Txt_DescripL5.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_L5.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    'Txt_DescripSubSubLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "SSSSS"
                    myForm.IdSuperior1 = CInt(Txt_IdL4.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdL3.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdL2.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdL1.Text)
                    myForm.IdSuperior5 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior6 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior7 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior8 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdL5.Text = myForm.IdCampo
                    Txt_L5.Text = myForm.ClaveCampo
                    Txt_DescripL5.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerL6()
        'mreyes 04/Junio/2012 12:04 p.m.

        Using objCatalogoDeptos As New BCL.BCLEstructura(GLB_ConStringCipSis)
            Try
                If Txt_IdDivision.Text.Trim = "" Then
                    Txt_IdDivision.Text = 0
                End If
                If Txt_IdDepto.Text.Trim = "" Then
                    Txt_IdDepto.Text = 0
                End If
                If Txt_IdFamilia.Text.Trim = "" Then
                    Txt_IdFamilia.Text = 0
                End If
                If Txt_IdLinea.Text.Trim = "" Then
                    Txt_IdLinea.Text = 0
                End If
                If Txt_IdL1.Text.Trim = "" Then
                    Txt_IdL1.Text = 0
                End If
                If Txt_IdL2.Text.Trim = "" Then
                    Txt_IdL2.Text = 0
                End If
                If Txt_IdL3.Text.Trim = "" Then
                    Txt_IdL3.Text = 0
                End If
                If Txt_IdL4.Text.Trim = "" Then
                    Txt_IdL4.Text = 0
                End If
                If Txt_IdL5.Text.Trim = "" Then
                    Txt_IdL5.Text = 0
                End If
                If Txt_IdL6.Text.Trim = "" Then
                    Txt_IdL6.Text = 0
                End If
                objDataSet = objCatalogoDeptos.usp_TraerEstl6(CInt(Txt_IdL6.Text), CInt(Txt_IdL5.Text), CInt(Txt_IdL4.Text), CInt(Txt_IdL3.Text), CInt(Txt_IdL2.Text), CInt(Txt_IdL1.Text), CInt(Txt_IdLinea.Text), CInt(Txt_IdFamilia.Text), CInt(Txt_IdDepto.Text), CInt(Txt_IdDivision.Text), Txt_L5.Text, 1, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_IdL6.Text = objDataSet.Tables(0).Rows(0).Item("idl6").ToString
                    Txt_DescripL6.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                    Txt_L6.Text = objDataSet.Tables(0).Rows(0).Item("clave").ToString
                    'Txt_DescripSubSubLinea.Enabled = False
                Else
                    Dim myForm As New frmConsultaEstructura
                    myForm.Tipo = "SSSSSS"
                    myForm.IdSuperior1 = CInt(Txt_IdL5.Text)
                    myForm.IdSuperior2 = CInt(Txt_IdL4.Text)
                    myForm.IdSuperior3 = CInt(Txt_IdL3.Text)
                    myForm.IdSuperior4 = CInt(Txt_IdL2.Text)
                    myForm.IdSuperior5 = CInt(Txt_IdL1.Text)
                    myForm.IdSuperior6 = CInt(Txt_IdLinea.Text)
                    myForm.IdSuperior7 = CInt(Txt_IdFamilia.Text)
                    myForm.IdSuperior8 = CInt(Txt_IdDepto.Text)
                    myForm.IdSuperior9 = CInt(Txt_IdDivision.Text)
                    myForm.Opcion = 1
                    myForm.ShowDialog()
                    Txt_IdL6.Text = myForm.IdCampo
                    Txt_L6.Text = myForm.ClaveCampo
                    Txt_DescripL6.Text = myForm.DescripCampo
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaComboPlaza()
        Try
            Using objCuentas As New BCL.BCLVentas(GLB_ConStringDWH)
                objDataSet = objCuentas.usp_TraerPlaza("")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Dim renglon As DataRow = objDataSet.Tables(0).NewRow
                renglon.Item("descrip") = "TODAS LAS PLAZAS"
                renglon.Item("idplaza") = 0
                objDataSet.Tables(0).Rows.InsertAt(renglon, 0)
                Cbo_Plaza.DataSource = objDataSet.Tables(0)
                Cbo_Plaza.ValueMember = "idplaza"
                Cbo_Plaza.DisplayMember = "descrip"
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub RellenaComboSucursal()
        Try
            Using objCuentas As New BCL.BCLVentas(GLB_ConStringDWH)
                objDataSet = objCuentas.usp_TraerSucursal("")
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Dim renglon As DataRow = objDataSet.Tables(0).NewRow
                renglon.Item("descrip") = "TODAS LAS SUCURSALES"
                renglon.Item("idsucursal") = 0
                objDataSet.Tables(0).Rows.InsertAt(renglon, 0)
           
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 10:25 a.m.
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

#End Region

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then
                txt_DescripMarca.Text = ""
                Exit Sub
            End If
            Try
                'Get the specific project selected in the ListView control
                If Txt_Marca.Text.Trim.Length < 3 Then
                    Txt_Marca.Text = pub_RellenarIzquierda(Txt_Marca.Text.Trim, 3)
                End If
                Call TxtLostfocus(Txt_Marca, txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub Txt_Division_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Division.LostFocus
        Try
            If blnEntroDivisiones = True Then Exit Sub
            If Txt_Division.Text.Trim = "" Then
                Txt_DescripDivision.Text = ""
                Txt_IdDivision.Text = ""
                Exit Sub
            End If
            If Txt_Division.Text.Length < 3 Then
                Txt_Division.Text = pub_RellenarIzquierda(Txt_Division.Text, 3)
            End If
            blnEntroDivisiones = True
            usp_TraerDivisiones()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Depto_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Depto.LostFocus
        Try
            If blnEntroDepto = True Then Exit Sub
            If Txt_Depto.Text.Trim = "" Then
                Txt_DescripDepto.Text = ""
                Txt_IdDepto.Text = ""
                Exit Sub
            End If
            If Txt_Depto.Text.Length < 3 Then
                Txt_Depto.Text = pub_RellenarIzquierda(Txt_Depto.Text, 3)
            End If
            blnEntroDepto = True
            usp_TraerDeptos()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Familia_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Familia.LostFocus
        Try
            If blnEntroFamilia = True Then Exit Sub
            If Txt_Familia.Text.Trim = "" Then
                Txt_DescripFamilia.Text = ""
                Txt_IdFamilia.Text = ""
                Exit Sub
            End If
            If Txt_Familia.Text.Length < 3 Then
                Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text, 3)
            End If
            blnEntroFamilia = True
            usp_TraerFamilia()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea.LostFocus
        Try
            If blnEntroLinea = True Then Exit Sub
            If Txt_Linea.Text.Trim = "" Then
                Txt_DescripLinea.Text = ""
                Txt_IdLinea.Text = ""
                Exit Sub
            End If
            If Txt_Linea.Text.Length < 3 Then
                Txt_Linea.Text = pub_RellenarIzquierda(Txt_Linea.Text, 3)
            End If
            blnEntroLinea = True
            usp_TraerLinea()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L1.LostFocus
        Try
            If blnEntroL1 = True Then Exit Sub
            If Txt_L1.Text.Trim = "" Then
                Txt_DescripL1.Text = ""
                Txt_IdL1.Text = ""
                Exit Sub
            End If
            If Txt_L1.Text.Length < 3 Then
                Txt_L1.Text = pub_RellenarIzquierda(Txt_L1.Text, 3)
            End If
            blnEntroL1 = True
            usp_TraerL1()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L2.LostFocus
        Try
            If blnEntroL2 = True Then Exit Sub
            If Txt_L2.Text.Trim = "" Then
                Txt_DescripL2.Text = ""
                Txt_IdL2.Text = ""
                Exit Sub
            End If
            If Txt_L2.Text.Length < 3 Then
                Txt_L2.Text = pub_RellenarIzquierda(Txt_L2.Text, 3)
            End If
            blnEntroL2 = True
            usp_TraerL2()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L3.LostFocus
        Try
            If blnEntroL3 = True Then Exit Sub
            If Txt_L3.Text.Trim = "" Then
                Txt_DescripL3.Text = ""
                Txt_IdL3.Text = ""
                Exit Sub
            End If
            If Txt_L3.Text.Length < 3 Then
                Txt_L3.Text = pub_RellenarIzquierda(Txt_L3.Text, 3)
            End If
            blnEntroL3 = True
            usp_TraerL3()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L4.LostFocus
        Try
            If blnEntroL4 = True Then Exit Sub
            If Txt_L4.Text.Trim = "" Then
                Txt_DescripL4.Text = ""
                Txt_IdL4.Text = ""
                Exit Sub
            End If
            If Txt_L4.Text.Length < 3 Then
                Txt_L4.Text = pub_RellenarIzquierda(Txt_L4.Text, 3)
            End If
            blnEntroL4 = True
            usp_TraerL4()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L5.LostFocus
        Try
            If blnEntroL5 = True Then Exit Sub
            If Txt_L5.Text.Trim = "" Then
                Txt_DescripL5.Text = ""
                Txt_IdL5.Text = ""
                Exit Sub
            End If
            If Txt_L5.Text.Length < 3 Then
                Txt_L5.Text = pub_RellenarIzquierda(Txt_L5.Text, 3)
            End If
            blnEntroL5 = True
            usp_TraerL5()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L6_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L6.LostFocus
        Try
            If blnEntroL6 = True Then Exit Sub
            If Txt_L6.Text.Trim = "" Then
                Txt_DescripL6.Text = ""
                Txt_IdL6.Text = ""
                Exit Sub
            End If
            If Txt_L6.Text.Length < 3 Then
                Txt_L6.Text = pub_RellenarIzquierda(Txt_L6.Text, 3)
            End If
            blnEntroL6 = True
            usp_TraerL6()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        Try
            If Txt_Marca.Text.Length = 3 Then
                Txt_Modelo.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Division_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Division.TextChanged
        Try
            blnEntroDivisiones = False
            If Txt_Division.Text.Length = 3 Then
                Txt_Depto.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Depto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Depto.TextChanged
        Try
            blnEntroDepto = False
            If Txt_Depto.Text.Length = 3 Then
                Txt_Familia.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Familia.TextChanged
        Try
            blnEntroFamilia = False
            If Txt_Familia.Text.Length = 3 Then
                Txt_Linea.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea.TextChanged
        Try
            blnEntroLinea = False
            If Txt_Linea.Text.Length = 3 Then
                Txt_L1.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L1.TextChanged
        Try
            blnEntroL1 = False
            If Txt_L1.Text.Length = 3 Then
                Txt_L2.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L2.TextChanged
        Try
            blnEntroL2 = False
            If Txt_L2.Text.Length = 3 Then
                Txt_L3.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L3.TextChanged
        Try
            blnEntroL3 = False
            If Txt_L3.Text.Length = 3 Then
                Txt_L4.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L4.TextChanged
        Try
            blnEntroL4 = False
            If Txt_L4.Text.Length = 3 Then
                Txt_L5.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L5.TextChanged
        Try
            blnEntroL5 = False
            If Txt_L5.Text.Length = 3 Then
                Txt_L6.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_L6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_L6.TextChanged
        Try
            blnEntroL6 = False
            If Txt_L6.Text.Length = 3 Then
                Btn_Aceptar.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Txt_Modelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Modelo.LostFocus
        Txt_Modelo.Text = pub_RellenarEspaciosIzquierda(Txt_Modelo.Text, 7)
    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged
        Try
            If Txt_Modelo.Text.Length = 7 Then
                Txt_Division.Focus()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_IdLinea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_IdLinea.TextChanged

    End Sub
End Class