Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D

Imports System.Drawing.Imaging
Imports LibPrintTicketMatriz.Class1

Public Class frmCatalogoTH

    Public IdDistrib As Integer = 0
    Public Accion As Integer = 0
    Dim RenglonB As Integer = 0
    Dim ColumnaB As String = ""
    Dim numfirma As Integer = 0
    Dim numerofirma As Integer = 1
    Dim numdocumento As Integer = 0
    Dim numerodocumento As Integer = 1
    Dim flag_comerciales As Integer = 0
    Dim flag_documentos As Integer = 0
    'Esta variable almacena la ruta en la que se guardarán las imágenes de los ditribuidores
    Dim Ruta As String = "\\10.10.1.1\Sistema\ZT\Imagenes\"

    Private Sub usp_TraerDistrib()
        'mreyes 07/Febrero/2018 12:43 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                objDataSet = objCatalogo.usp_TraerDistrib(IdDistrib)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'cargar combos de ciudades colonias etc,.

                    Txt_NombreCompleto.Text = NombreDistrib(objDataSet.Tables(0).Rows(0).Item("nombrecompleto").ToString)
                    Txt_IdDistrib.Text = objDataSet.Tables(0).Rows(0).Item("distrib").ToString
                    'Txt_IdPromotor.Text = objDataSet.Tables(0).Rows(0).Item("idpromotor").ToString
                    'Txt_IdCoordinador.Text = objDataSet.Tables(0).Rows(0).Item("idcoordinador").ToString
                    'Txt_IdTienda.Text = objDataSet.Tables(0).Rows(0).Item("idtienda").ToString

                    If Txt_Nombre.Text = "" Then
                        Txt_Nombre.Text = objDataSet.Tables(0).Rows(0).Item("nombre").ToString
                    End If

                    If Txt_Appaterno.Text = "" Then
                        Txt_Appaterno.Text = objDataSet.Tables(0).Rows(0).Item("appaterno").ToString
                    End If

                    If Txt_Apmaterno.Text = "" Then
                        Txt_Apmaterno.Text = objDataSet.Tables(0).Rows(0).Item("apmaterno").ToString
                    End If

                    Cbo_EstadoCivil.Text = objDataSet.Tables(0).Rows(0).Item("estadocivil").ToString
                    Txt_Dependientes.Text = objDataSet.Tables(0).Rows(0).Item("dependientes").ToString
                    Cbo_Sexo.Text = objDataSet.Tables(0).Rows(0).Item("sexo").ToString
                    Dt_FechaNacim.Text = objDataSet.Tables(0).Rows(0).Item("fechanacim").ToString

                    Cbo_CodigoPostal.Text = objDataSet.Tables(0).Rows(0).Item("codigopostal").ToString()
                    Cbo_Estado.Text = objDataSet.Tables(0).Rows(0).Item("estado").ToString
                    ' Cbo_Estado.ValueMember = objDataSet.Tables(0).Rows(0).Item("estado").ToString
                    Cbo_Colonia.Text = objDataSet.Tables(0).Rows(0).Item("colonia").ToString()
                    Cbo_Ciudad.Text = objDataSet.Tables(0).Rows(0).Item("ciudad").ToString()
                    Txt_Numero.Text = objDataSet.Tables(0).Rows(0).Item("numero").ToString()
                    Txt_EntreCalles.Text = objDataSet.Tables(0).Rows(0).Item("entrecalles").ToString()
                    Txt_Calle.Text = objDataSet.Tables(0).Rows(0).Item("calle").ToString

                    Cbo_TipoVivienda.Text = objDataSet.Tables(0).Rows(0).Item("tipovivienda").ToString()
                    Txt_AntiguedadVivienda.Text = objDataSet.Tables(0).Rows(0).Item("antiguedadvivienda").ToString()
                    Txt_ValorCasa.Text = objDataSet.Tables(0).Rows(0).Item("valorcasa").ToString()
                    Txt_ValorAutos.Text = objDataSet.Tables(0).Rows(0).Item("valorautos").ToString()

                    Txt_TelCasa.Text = objDataSet.Tables(0).Rows(0).Item("telcasa").ToString()
                    Txt_TelOtro.Text = objDataSet.Tables(0).Rows(0).Item("telotro").ToString()
                    Txt_Celular1.Text = objDataSet.Tables(0).Rows(0).Item("celular1").ToString()

                    Txt_Celular2.Text = objDataSet.Tables(0).Rows(0).Item("celular2").ToString()
                    Txt_Email.Text = objDataSet.Tables(0).Rows(0).Item("email").ToString()

                    Txt_Empresa.Text = objDataSet.Tables(0).Rows(0).Item("empresa").ToString()
                    Txt_DireccionEmpresa.Text = objDataSet.Tables(0).Rows(0).Item("direccionempresa").ToString()
                    Txt_Puesto.Text = objDataSet.Tables(0).Rows(0).Item("puesto").ToString()
                    Txt_AntiguedadEmpresa.Text = objDataSet.Tables(0).Rows(0).Item("AntiguedadEmpresa").ToString()

                    Txt_IngresoMensual.Text = objDataSet.Tables(0).Rows(0).Item("ingresomensual").ToString()
                    Txt_OtrosIngresos.Text = objDataSet.Tables(0).Rows(0).Item("otrosingresos").ToString()
                    Txt_IngresoTotal.Text = objDataSet.Tables(0).Rows(0).Item("ingresototal").ToString()

                    Cbo_TipoCredito.Text = objDataSet.Tables(0).Rows(0).Item("tipocredito").ToString()
                    Cbo_Periodicidad.Text = objDataSet.Tables(0).Rows(0).Item("periodicidad").ToString()

                    If objDataSet.Tables(0).Rows(0).Item("tipocredito").ToString() = "" Then
                        Cbo_TipoCredito.Text = "TARJETAHABIENTE"
                    End If
                    If objDataSet.Tables(0).Rows(0).Item("periodicidad").ToString() = "" Then
                        Cbo_Periodicidad.Text = "MENSUAL"
                    End If

                    Txt_LimiteCredito.Text = objDataSet.Tables(0).Rows(0).Item("limitecredito").ToString()
                    Txt_Saldo.Text = objDataSet.Tables(0).Rows(0).Item("saldo").ToString()
                    Txt_Disponible.Text = objDataSet.Tables(0).Rows(0).Item("disponible").ToString()

                    Txt_LimiteCredito.Text = objDataSet.Tables(0).Rows(0).Item("limitevale").ToString()
                    Cbo_ContraVale.Text = objDataSet.Tables(0).Rows(0).Item("contravale").ToString()
                    Cbo_NegExt.Text = objDataSet.Tables(0).Rows(0).Item("negext").ToString()
                    Cbo_Promocion.Text = objDataSet.Tables(0).Rows(0).Item("promocion").ToString()

                    ' tabsheet 2
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub frmCatalogoDistrib_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Accion = 1
            'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
            'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
            'txt_pertenece.Enabled = False
            'txt_numFoto.Enabled = False
            'Panel7.Visible = False
            If Accion = 1 Then
                'Call usp_TraerCPEstadoCiudadColonia(Cbo_CodigoPostal, 1, "", 0, 0, 0)

            End If

            If Accion = 3 Then
                PanelControl3.Enabled = False
                PanelControl4.Enabled = False
                PanelControl2.Enabled = False
                Pnl_Nombre.Enabled = False
                PanelControl1.Enabled = False
                PanelControl12.Enabled = False
                PanelControl13.Enabled = False
                PanelControl14.Enabled = False
                Pnl_Edicion.Enabled = False
                PanelControl5.Enabled = False
                PanelControl11.Enabled = False
                GridReferencias.Enabled = False
                GridControl3.Enabled = False

            End If

            If Accion = 4 Or Accion = 2 Or Accion = 3 Then
                Call usp_TraerDistrib()
                Call usp_TraerDistribComerciales1()
                Call usp_TraerDistribDocumentos1()
            End If

            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                   'frames enabled

                Case 1, 2
                    'Btn_Aceptar.Enabled = True
                    'Btn_Cancelar.Enabled = True
                    'Btn_Nuevo.Enabled = False
                    'Btn_Editar.Enabled = False

                    If Accion = 1 Then

                    ElseIf Accion = 2 Then
                        Txt_IdDistrib.Enabled = False
                        Txt_Nombre.Focus()
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Cbo_CodigoPostal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cbo_CodigoPostal.SelectedIndexChanged

    End Sub

    Private Sub Cbo_CodigoPostal_LostFocus(sender As Object, e As EventArgs) Handles Cbo_CodigoPostal.LostFocus
        Try
            Call usp_TraerCPEstadoCiudadColonia(Cbo_Estado, 2, Cbo_CodigoPostal.Text, 0, 0, 0)
            Call usp_TraerCPEstadoCiudadColonia(Cbo_Ciudad, 3, Cbo_CodigoPostal.Text, 0, 0, 0)
            Call usp_TraerCPEstadoCiudadColonia(Cbo_Colonia, 4, Cbo_CodigoPostal.Text, 0, 0, 0)
            Cbo_Ciudad.Enabled = False
            'Cbo_Colonia.Enabled = False
            Cbo_Estado.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub PanelControl5_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl5.Paint

    End Sub

    Private Function ValidarEdicion() As Boolean
        'mreyes 11/Julio/2018   06:15 p.m.
        Try
            ValidarEdicion = False

            If Txt_Nombre.Text = "" Then
                ValidarEdicion = False
                Txt_Nombre.Focus()
            Else
                ValidarEdicion = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function
    '======================================================================================================================================
    Private Sub Btn_Guardar_Click(sender As Object, e As EventArgs) Handles Btn_Guardar.Click
        'mreyes 11/Julio/2018   04:47 p.m.
        Try
            Dim Sw_Registro As Boolean
            Dim ObjControl As Control

            If ValidarLlenado() Then
                '*****************************************************************************************************************************
                If Accion = 1 Then 'es un tarjetahabiente nuevo
                    If ValidarEdicion() = False Then Exit Sub

                    If usp_Captura_Distrib() = True Then
                        Sw_Registro = True
                        Me.Close()
                        'me.dispose()
                    End If
                    'CAPTURAR tipos de documentos 08/septiembre/2018
                    For i As Integer = 0 To GridView1.DataRowCount - 1

                        If GridView1.GetRowCellValue(i, "documento").ToString() = "FIRMA" Then
                            'Esta condición verifica que el campo "imagen" no esté vacio
                            'Si este campo tiene  algun valor guarda la imágen en la ruta especificada tomando como nombre el número de imagen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                numfirma += 3
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                Dim descripcion As String
                                If GridView1.GetRowCellValue(i, "descrip") <> "" Then
                                    descripcion = GridView1.GetRowCellValue(i, "descrip").ToString()
                                Else
                                    descripcion = "1"
                                End If
                                usp_Captura_DistribFirmas(descripcion, GridView1.GetRowCellValue(i, "imagen"), numerodocumento)
                            End If
                            'Esta condición verifica que el campo "imagen1" no esté vacio
                            'Si este campo contiene algun valor guarda la imágen en la ruta especificada tomando como nombre el número de imagen
                            'Como esta es la imagen #2 para evitar un conflicto en los nombres se le agrega "-1" al nombre de esta imágen

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                numfirma += 1
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                Dim descripcion As String
                                If GridView1.GetRowCellValue(i, "descrip") <> "" Then
                                    descripcion = GridView1.GetRowCellValue(i, "descrip").ToString()
                                Else
                                    descripcion = "1"
                                End If
                                usp_Captura_DistribFirmas(descripcion, GridView1.GetRowCellValue(i, "imagen"), numerodocumento)
                            End If
                            numfirma += 1
                            'img.Save("C:\Users\ZTMTPC01\Desktop\imagen.jpg", ImageFormat.Jpeg)
                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "CASA" Then
                            'Aquí va el método de guardado de la imágen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "CASA", numerodocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "CASA", numerodocumento)
                            End If

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "EDO. DE CUENTA" Then
                            'Aquí va el método de guardado de la imágen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "ESTADOS DE CUENTA", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "ESTADOS DE CUENTA", numdocumento)
                            End If

                            numdocumento += 1

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "INE" Then
                            'Aquí va el método de guardado de la imágen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "INE", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "INE", numdocumento)
                            End If

                            numdocumento += 1

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "INGRESOS" Then
                            'Aquí va el método de guardado de la imágen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "INGRESOS", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "INGRESOS", numdocumento)
                            End If

                            numdocumento += 1

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "COMPROBANTE" Then
                            'Aquí va el método de guardado de la imágen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "COMPROBANTE", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "COMPROBANTE", numdocumento)
                            End If

                            numdocumento += 1

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "PAGARE" Then
                            'Aquí va el método de guardado de la imágen
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "PAGARE", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "PAGARE", numdocumento)
                            End If

                            numdocumento += 1

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "DISTRIBUIDOR" Then
                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "DISTRIBUIDOR", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "DISTRIBUIDOR", numdocumento)
                            End If

                            numdocumento += 1

                        ElseIf GridView1.GetRowCellValue(i, "documento").ToString() = "CROQUIS" Then

                            If GridView1.GetRowCellValue(i, "imagen") IsNot DBNull.Value Then
                                Dim bm1 As Bitmap = Nothing
                                Dim imagen1 As Byte() = GridView1.GetRowCellValue(i, "imagen")
                                Dim ms1 As New MemoryStream(imagen1)
                                bm1 = New Bitmap(ms1)

                                Dim img1 As Image = bm1
                                img1.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "CROQUIS", numdocumento)
                            End If

                            If GridView1.GetRowCellValue(i, "imagen1") IsNot DBNull.Value Then
                                Dim bm2 As Bitmap = Nothing
                                Dim imagen2 As Byte() = GridView1.GetRowCellValue(i, "imagen1")
                                Dim ms2 As New MemoryStream(imagen2)
                                bm2 = New Bitmap(ms2)

                                Dim img2 As Image = bm2
                                img2.Save(Ruta + Txt_IdDistrib.Text + "F" + numerodocumento.ToString + ".jpg", ImageFormat.Jpeg)
                                numerodocumento += 1
                                usp_Captura_DistribDocumentos(GridView1.GetRowCellValue(i, "imagen"), "CROQUIS", numdocumento)
                            End If

                            numdocumento += 1

                        End If
                    Next i

                    'CAPTURAR REFERENCIAS COMERCIALES 15/AGOSTO/2018

                    'If usp_Captura_DistribComerciales() Then
                    '    Sw_Registro = True
                    '    Me.Close()
                    'End If
                    Sw_Registro = True
                    Me.Close()


                    '*****************************************************************************************************************************
                ElseIf Accion = 2 Then 'es una actualización
                    If ValidarEdicion() = False Then Exit Sub
                    If usp_Captura_Distrib() = True Then
                        Sw_Registro = True
                        Me.Close()
                        'Me.Dispose()
                    End If
                ElseIf Accion = 4 Then
                    Me.Close()
                    Me.Dispose()
                End If ' del if de accion = 1
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    '======================================================================================================================================

    Private Function ValidarLlenado() As Boolean
        If Txt_IdDistrib.Text = "" Then
            MessageBox.Show("Por favor ingrese un iddistrib.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_IdDistrib.Select()
            Return False
        ElseIf Txt_Nombre.Text = "" Then
            MessageBox.Show("Por favor ingrese un nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Nombre.Select()
            Return False
        ElseIf Txt_Appaterno.Text = "" Then
            MessageBox.Show("Por favor ingrese un apellido paterno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Appaterno.Select()
            Return False
        ElseIf Txt_Apmaterno.Text = "" Then
            MessageBox.Show("Por favor ingrese un apellido materno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Apmaterno.Select()
            Return False
        ElseIf Cbo_Sexo.Text = "" Then
            MessageBox.Show("Por favor ingrese un sexo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cbo_Sexo.Select()
            Return False
        ElseIf Cbo_EstadoCivil.Text = "" Then
            MessageBox.Show("Por favor ingrese un estado civil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cbo_EstadoCivil.Select()
            Return False
        ElseIf Txt_Dependientes.Text = "" Then
            MessageBox.Show("Por favor ingrese el número de dependientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Dependientes.Select()
            Return False
        ElseIf Txt_Calle.Text = "" Then
            MessageBox.Show("Por favor ingrese el nombre de la calle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Calle.Select()
            Return False
        ElseIf Txt_Numero.Text = "" Then
            MessageBox.Show("Por favor ingrese el número de vivienda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Numero.Select()
            Return False
        ElseIf Cbo_CodigoPostal.Text = "" Then
            MessageBox.Show("Por favor ingrese un código postal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cbo_CodigoPostal.Select()
            Return False
        ElseIf Cbo_Colonia.Text = "" Then
            MessageBox.Show("Por favor ingrese una colonia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cbo_Colonia.Select()
            Return False
        ElseIf Txt_EntreCalles.Text = "" Then
            MessageBox.Show("Por favor ingrese entre que calles se encuentra la vivienda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_EntreCalles.Select()
            Return False
        ElseIf Cbo_TipoVivienda.Text = "" Then
            MessageBox.Show("Por favor ingrese el tipo de vivienda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cbo_TipoVivienda.Select()
            Return False
        ElseIf Txt_AntiguedadVivienda.Text = "" Then
            MessageBox.Show("Por favor ingrese la antiguedad de la vivienda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_AntiguedadVivienda.Select()
            Return False
        ElseIf Txt_TelCasa.Text = "" Then
            MessageBox.Show("Por favor ingrese un número de telefono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_TelCasa.Select()
            Return False
        ElseIf Txt_TelOtro.Text = "" Then
            MessageBox.Show("Por favor ingrese un segundo número de telefono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_TelOtro.Select()
            Return False
        ElseIf Txt_Celular1.Text = "" Then
            MessageBox.Show("Por favor ingrese un número de celular.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Celular1.Select()
            Return False
        ElseIf Txt_Celular2.Text = "" Then
            MessageBox.Show("Por favor ingrese un segundo número de celular.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Celular2.Select()
            Return False
        ElseIf Txt_Empresa.Text = "" Then
            MessageBox.Show("Por favor ingrese el nombre de la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Empresa.Select()
            Return False
        ElseIf Txt_DireccionEmpresa.Text = "" Then
            MessageBox.Show("Por favor ingrese la direccion de la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_DireccionEmpresa.Select()
            Return False
        ElseIf Txt_Puesto.Text = "" Then
            MessageBox.Show("Por favor ingrese el puesto que ocupa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_Puesto.Select()
            Return False
        ElseIf Txt_AntiguedadEmpresa.Text = "" Then
            MessageBox.Show("Por favor ingrese la antiguedad en la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_AntiguedadEmpresa.Select()
            Return False
        ElseIf Txt_IngresoMensual.Text = "" Then
            MessageBox.Show("Por favor ingrese el valor del ingreso mensual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_IngresoMensual.Select()
            Return False
        ElseIf Txt_OtrosIngresos.Text = "" Then
            MessageBox.Show("Por favor ingrese el valor de los otros ingresos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_OtrosIngresos.Select()
            Return False
        ElseIf Txt_IngresoTotal.Text = "" Then
            MessageBox.Show("Por favor ingrese a suma de todos los ingresos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_IngresoTotal.Select()
            Return False
        ElseIf Txt_LimiteCredito.Text = "" Then
            MessageBox.Show("Por favor ingrese un limite de credito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Txt_LimiteCredito.Select()
            Return False
        End If
        Return True
    End Function


    Private Function NombreDistrib(ByVal nombrecompleto As String) As String
        Dim cnomb As String
        Dim cappa As String
        Dim capma As String

        Dim nom = nombrecompleto.Trim()
        nom = nom.replace("¥", "Ñ")
        Dim nomb = nom.split(" ")
        Dim nombres As New List(Of String)

        Dim esp As String() = {"DA", "DE", "DEL", "LA", "LAS", "LOS", "MAC", "MC", "VAN", "VON", "Y", "I", "SAN", "SANTA"}
        Dim com As String = ""
        Dim pos As Integer = 0

        For Each nm As String In nomb
            Dim verif = Array.IndexOf(esp, nm)

            If verif > -1 Then

                If com <> "" Then
                    com = com + " " + nm + " "
                Else
                    com = nm + " "
                End If

            Else
                nombres.Add(com + nm)
                com = ""
            End If
        Next

        Dim nombs As String() = nombres.ToArray()

        Select Case nombres.Count()
            Case 3
                cnomb = nombs(0)
                cappa = nombs(1)
                capma = nombs(2)

                Txt_Nombre.Text = cnomb
                Txt_Appaterno.Text = cappa
                Txt_Apmaterno.Text = capma

            Case 4
                cnomb = nombs(0) + " " + nombs(1)
                cappa = nombs(2)
                capma = nombs(3)

                Txt_Nombre.Text = cnomb
                Txt_Appaterno.Text = cappa
                Txt_Apmaterno.Text = capma
            Case 5
                cnomb = nombs(0) + " " + nombs(1) + " " + nombs(2)
                cappa = nombs(3)
                capma = nombs(4)

                Txt_Nombre.Text = cnomb
                Txt_Appaterno.Text = cappa
                Txt_Apmaterno.Text = capma
        End Select

        Return cnomb + " " + cappa + " " + capma
    End Function

    Private Function usp_Captura_Distrib() As Boolean
        'mreyes 11/Julio/2018   04:51 p.m.
        Dim NombreCompleto As String = ""
        Dim Sexo As String = ""
        Dim IdEdoCivil As Integer = 0
        Dim Contravale As Integer = 0
        Dim NegExt As Integer = 0
        Dim TipoViv As Integer = 0
        Dim Promocion As Integer = 0

        If Cbo_ContraVale.Text = "SI" Then
            Contravale = 1
        Else
            Contravale = 0
        End If

        If Cbo_NegExt.Text = "SI" Then
            NegExt = 1
        Else
            NegExt = 0
        End If

        If Cbo_Promocion.Text = "SI" Then
            Promocion = 1
        Else
            Promocion = 0
        End If

        If Cbo_EstadoCivil.Text = "CASADO" Then
            IdEdoCivil = 1
        ElseIf Cbo_EstadoCivil.Text = "SOLTERO" Then
            IdEdoCivil = 2
        ElseIf Cbo_EstadoCivil.Text = "VIUDO" Then
            IdEdoCivil = 3
        ElseIf Cbo_EstadoCivil.Text = "UNION LIBRE" Then
            IdEdoCivil = 4
        End If

        If Cbo_TipoVivienda.Text = "CASA" Then
            TipoViv = 1
        ElseIf Cbo_TipoVivienda.Text = "DEPARTAMENTO" Then
            TipoViv = 2
        End If

        Sexo = Mid(Cbo_Sexo.Text, 1, 1)
        NombreCompleto = Txt_Nombre.Text & " " & Txt_Appaterno.Text & " " & Txt_Apmaterno.Text

        Using objCalculo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Application.DoEvents()
                usp_Captura_Distrib = objCalculo.usp_Captura_Distrib(Accion, 0, 0, 99, Txt_IdDistrib.Text, "TH", 0, 0, 1, 0, NombreCompleto, Txt_Nombre.Text, Txt_Appaterno.Text,
                                      Txt_Apmaterno.Text, Sexo, Dt_FechaNacim.Text, IdEdoCivil, Val(Txt_Dependientes.Text), Cbo_Estado.SelectedValue, Cbo_Ciudad.SelectedValue,
                                      Cbo_Colonia.SelectedValue, Cbo_CodigoPostal.Text, Txt_Calle.Text, Val(Txt_Numero.Text), Txt_EntreCalles.Text, TipoViv,
                                      Val(Txt_AntiguedadVivienda.Text), Val(Txt_ValorCasa.Text), Val(Txt_ValorAutos.Text), Txt_TelCasa.Text, Txt_TelOtro.Text,
                                      Txt_Celular1.Text, Txt_Celular2.Text, Txt_Email.Text, Txt_Empresa.Text, Txt_DireccionEmpresa.Text, Txt_Puesto.Text,
                                      Val(Txt_AntiguedadEmpresa.Text), Val(Txt_IngresoMensual.Text), Val(Txt_OtrosIngresos.Text), Val(Txt_IngresoTotal.Text),
                                      Val(Txt_LimiteCredito.Text), Val(Txt_Saldo.Text), Val(Txt_Disponible.Text), Val(Txt_LimiteVale.Text), Contravale,
                                      NegExt, Promocion, Txt_NombreConyuge.Text, Txt_ApPaternoConyuge.Text, Txt_ApMaternoConyuge.Text,
                                      Txt_EmpresaConyuge.Text, Txt_PuestoConyuge.Text, Val(Txt_AntiguedadConyuge.Text),
                                      Txt_TelConyuge.Text, Txt_CelConyuge.Text, Val(Txt_IngresoConyuge.Text), Txt_NombreMadre.Text,
                                      Txt_NombrePadre.Text, Txt_DireccionPadres.Text, Txt_TelPadres.Text, Txt_CelPadres.Text,
                                      Txt_TelPadres1.Text, Txt_TelPadres2.Text,
                                      Txt_NombreAmigo.Text, Txt_DireccionAmigo.Text, Txt_TelAmigo.Text, Txt_CelAmigo.Text,
                                      GLB_Idempleado, GLB_Idempleado)
                Application.DoEvents()
                MessageBox.Show("Se ha registrado el distribuidor exitosamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_Captura_DistribFirmas(pertenece As String, imagen As Byte(), numfirma As Integer) As Boolean
        'mreyes 12/Julio/2018   12:31 p.m.
        'firma
        Using objCalculo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Application.DoEvents()
                usp_Captura_DistribFirmas = objCalculo.usp_Captura_DistribFirmas(Accion, IdDistrib, 1, pertenece, Txt_Calle.Text, numfirma, imagen, imagen, GLB_Idempleado, GLB_Idempleado)
                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_Captura_DistribDocumentos(imagen As Byte(), Documento As String, numdocumento As Integer) As Boolean
        'mreyes 12/Julio/2018   01:04 p.m.
        'fotos de casa
        Using objCalculo As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                'Get the specific project selected in the ListView controlsu
                Application.DoEvents()
                usp_Captura_DistribDocumentos = objCalculo.usp_Captura_DistribDocumentos(Accion, IdDistrib, Documento, numdocumento, imagen, GLB_Idempleado, GLB_Idempleado)
                Application.DoEvents()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Function usp_Captura_DistribComerciales() As Boolean
        Try
            Dim Limite As Decimal = 0
            Dim Comercial As String = ""
            Dim NoCuenta As String = ""
            Dim Guardo As Boolean = False
            'mreyes 15/Agosto/2018  10:04 a.m.
            For renglon As Integer = 0 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(renglon, "medini").ToString() = "0" Then
                    Comercial = GridView3.GetRowCellValue(renglon, "documento")
                    NoCuenta = GridView3.GetRowCellValue(renglon, "descrip")

                    Limite = GridView3.GetRowCellValue(renglon, "preciolista")

                    Using objBultos As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
                        Guardo = objBultos.usp_Captura_DistribComerciales(1, IdDistrib, 0, Comercial, NoCuenta, Limite, GridView3.GetRowCellValue(renglon, "imagen"), GridView3.GetRowCellValue(renglon, "imagen1"), GLB_Idempleado)
                    End Using
                    'guardar la siguiente imagen
                End If
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_GuardarF_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt_IngresoMensual_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_IngresoMensual.EditValueChanged

    End Sub

    Private Sub Txt_IngresoMensual_LostFocus(sender As Object, e As EventArgs) Handles Txt_IngresoMensual.LostFocus
        Txt_IngresoMensual.Text = Format(Val(Txt_IngresoMensual.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_OtrosIngresos_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_OtrosIngresos.EditValueChanged

    End Sub

    Private Sub Txt_OtrosIngresos_LostFocus(sender As Object, e As EventArgs) Handles Txt_OtrosIngresos.LostFocus
        Txt_OtrosIngresos.Text = Format(Val(Txt_OtrosIngresos.Text), "$#,###,##0.00")
    End Sub

    Private Sub frmCatalogoTH_DockChanged(sender As Object, e As EventArgs) Handles MyBase.DockChanged

    End Sub

    Private Sub Txt_IngresoTotal_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_IngresoTotal.EditValueChanged

    End Sub

    Private Sub Txt_IngresoTotal_LostFocus(sender As Object, e As EventArgs) Handles Txt_IngresoTotal.LostFocus
        Txt_IngresoTotal.Text = Format(Val(Txt_IngresoTotal.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_LimiteVale_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_LimiteVale.EditValueChanged

    End Sub

    Private Sub Txt_LimiteVale_LostFocus(sender As Object, e As EventArgs) Handles Txt_LimiteVale.LostFocus
        Txt_LimiteVale.Text = Format(Val(Txt_LimiteVale.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_LimiteCredito_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_LimiteCredito.EditValueChanged

    End Sub

    Private Sub Txt_LimiteCredito_LostFocus(sender As Object, e As EventArgs) Handles Txt_LimiteCredito.LostFocus
        Txt_LimiteCredito.Text = Format(Val(Txt_LimiteCredito.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_Saldo_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Saldo.EditValueChanged

    End Sub

    Private Sub Txt_Disponible_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_Disponible.EditValueChanged

    End Sub

    Private Sub Txt_Disponible_LostFocus(sender As Object, e As EventArgs) Handles Txt_Disponible.LostFocus
        Txt_Disponible.Text = Format(Val(Txt_Disponible.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_IngresoConyuge_EditValueChanged(sender As Object, e As EventArgs) Handles Txt_IngresoConyuge.EditValueChanged

    End Sub

    Private Sub Txt_IngresoConyuge_LostFocus(sender As Object, e As EventArgs) Handles Txt_IngresoConyuge.LostFocus
        Txt_IngresoConyuge.Text = Format(Val(Txt_IngresoConyuge.Text), "$#,###,##0.00")
    End Sub

    Private Sub Txt_Saldo_LostFocus(sender As Object, e As EventArgs) Handles Txt_Saldo.LostFocus
        Txt_Saldo.Text = Format(Val(Txt_Saldo.Text), "$#,###,##0.00")
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub GridView3_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Try
            Dim Renglon As Integer = 0
            Dim Columna As String = ""
            Columna = e.Column.Name
            Renglon = e.RowHandle

            If e.Column.Caption = "Negocio" Then
                GridView3.SetRowCellValue(Renglon, "medini", "0")
                Return
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim Renglon As Integer = 0
        Dim Columna As String = ""
        Columna = e.Column.Name
        Renglon = e.RowHandle

        If e.Column.Caption = "Tipo Documento" Then
            GridView1.SetRowCellValue(Renglon, "medini", "1")
            Return
        End If
    End Sub

    Private Sub GridView1_CustomRowFilter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles GridView1.CustomRowFilter
        'For renglon As Integer = 0 To GridView1.RowCount - 1
        '    If (GridView1.GetRowCellValue(renglon, "medini").ToString() = "1") Then
        '        e.Visible = True
        '        e.Handled = False
        '    Else
        '        e.Visible = False
        '        e.Handled = True
        '    End If
        'Next
    End Sub

    Sub InicializaGrid()
        'GridView1
        Try
            GridView3.BestFitColumns()
            '' Call Colorear()
            'GridView1.FixedLineWidth = 4
            'GridView1.Columns(0).Fixed = 1
            'GridView1.Columns(1).Fixed = 1
            'GridView1.Columns(2).Fixed = 1
            'GridView1.Columns(3).Fixed = 1

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub

    Sub InicializaGrid1()
        'GridView1
        Try
            GridView1.BestFitColumns()
            '' Call Colorear()
            'GridView1.FixedLineWidth = 4
            'GridView1.Columns(0).Fixed = 1
            'GridView1.Columns(1).Fixed = 1
            'GridView1.Columns(2).Fixed = 1
            'GridView1.Columns(3).Fixed = 1

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        'GridView.BestFitColumns or GridColumn.BestFit 
    End Sub
    Private Sub usp_TraerDistribComerciales1()
        'mreyes 19/Septiembre/2018  12:06 p.m.
        Dim objDataSet As Data.DataSet
        InicializaGrid()
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                objDataSet = objTrasp.usp_TraerDistribComerciales(Val(Txt_IdDistrib.Text))
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    GridReferencias.DataSource = objDataSet.Tables(0)
                    InicializaGrid()
                    Me.Cursor = Cursors.Default
                End If
                Me.Cursor = Cursors.Default
                ' LimpiarBusqueda()
                GridReferencias.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerDistribDocumentos1()
        'mreyes 19/Septiembre/2018  12:14 p.m.
        Dim objDataSet As Data.DataSet
        Using objTrasp As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                Me.Cursor = Cursors.WaitCursor
                objDataSet = objTrasp.usp_TraerDistribDocumentos(Val(Txt_IdDistrib.Text))
                'Populate the Project Details section
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    'Populate the Project Details section 
                    'DGrid.ColumnCount = objDataSet.Tables(0).Columns.Count
                    GridControl3.DataSource = objDataSet.Tables(0)
                    InicializaGrid1()
                    Me.Cursor = Cursors.Default
                End If
                Me.Cursor = Cursors.Default
                'LimpiarBusqueda()
                GridControl3.Visible = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TFirmasDocumentos_Click(sender As Object, e As EventArgs) Handles TFirmasDocumentos.Click

    End Sub

    Private Sub GridControl3_Click(sender As Object, e As EventArgs) Handles GridControl3.Click

    End Sub
End Class