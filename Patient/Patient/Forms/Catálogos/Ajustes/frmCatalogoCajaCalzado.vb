Public Class frmCatalogoCajaCalzado
    'mreyes 19/Febrero/2016 11:25 a.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Public IdCajaCalzado As Integer = 0
    Private objDataSet As Data.DataSet
    Private objDataSet1 As Data.DataSet
    Dim MedidaIni As String = ""
    Dim MedidaFin As String = ""
    Dim Intervalo As String = ""




    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'mreyes 18/Agosto/2012 10:37 a.m.
        Try

            If MsgBox("Esta seguro actualizar las ventas reportadas en nómina?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            MsgBox("Proceso de carga de Ventas Terminado", MsgBoxStyle.Information, "Confirmación")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub




    Private Sub frmCatalogoSegBit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Sw_Registro = False
                        Me.Dispose()
                        Me.Close()

                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub





    Private Sub CambiaBackcolor()
        Try
            'mreyes 02/Marzo/2012 10:25 a.m.


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try





        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub










    Private Sub Txt_Serie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Serie.LostFocus
        'mreyes 19/Febrero/2016 11:51 a.m.
        Try

            If Txt_Serie.Text = "" Then Exit Sub
            Txt_Serie.Text = pub_RellenarIzquierda(Txt_Serie.Text, 13)

            Using objMySqlGral As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Try



                    objDataSet = objMySqlGral.usp_TraerSeries("C", "", "", 0, Txt_Serie.Text, Txt_Serie.Text, "", "", "", "", "", "", "", "", "", "")


                    'Populate the Project Details section

                    If objDataSet.Tables(0).Rows.Count > 0 Then

                        If (objDataSet.Tables(0).Rows(0).Item("fums").ToString < GLB_FechaHoy) Then
                            If GLB_Idempleado <> 132 Then
                                MsgBox("No se encuentra autorizado para generar esta acción. Caja Calzado de días anteriores es un proceso que conlleva cambiar series y por el momento lo realizará sistemas.", MsgBoxStyle.Critical, "Caja Calzado")
                                Txt_Serie.Text = ""
                                Txt_Serie.Focus()
                                Exit Sub
                            End If
                        End If
                        Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                        Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString

                        Txt_MarcaNuevo.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString()
                        Txt_DescripMarcaNuevo.Text = objDataSet.Tables(0).Rows(0).Item("descrip").ToString

                        Txt_Modelo.Text = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                        Txt_Corrida.Text = objDataSet.Tables(0).Rows(0).Item("corrida").ToString
                        Txt_Medida.Text = objDataSet.Tables(0).Rows(0).Item("medida").ToString
                        'Format(Now.Date, "yyyy-MM-dd")
                        Txt_FechaRecibo.Text = Format(objDataSet.Tables(0).Rows(0).Item("fecreci"), "yyyy-MM-dd")
                        Txt_IdFolioSuc.Text = objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString
                        Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString

                        Txt_SucursalAct.Text = objDataSet.Tables(0).Rows(0).Item("sucact").ToString
                        Txt_SucursalOri.Text = objDataSet.Tables(0).Rows(0).Item("sucori").ToString


                        CargarFotoAnterior()


                    Else
                        MsgBox("La serie no existe, verifique e intente nuevamente", MsgBoxStyle.Critical, "Aviso")
                        Txt_Serie.Text = ""
                        Txt_Serie.Focus()

                    End If
                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Serie.TextChanged

    End Sub

    Private Sub Txt_ModeloNuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ModeloNuevo.LostFocus
        ' Ir a buscar que si exista el modelo con la marca.
        'mreyes 19/Febrero/2016 12:19 p.m.
        Txt_ModeloNuevo.Text = Txt_ModeloNuevo.Text.PadLeft(7)
        If Txt_Modelo.Text = "" Then Exit Sub

        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try


                objDataSet = objCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, Txt_Modelo.Text, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    ' Si lo encontro

                Else
                    MsgBox("Estilo no encontrado, No pertenece a la marca.", MsgBoxStyle.Critical, "Aviso")
                    Txt_ModeloNuevo.Text = ""
                    Txt_ModeloNuevo.Focus()
                End If
                Call CargarFotoNueva()
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using


    End Sub
    Private Sub CargarFotoAnterior()
        'mreyes 19/Febrero/2016 12:28 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBoxAnterior.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True
                        PBoxAnterior.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next



            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub CargarFotoNueva()
        'mreyes 19/Febrero/2016 12:29 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"
            Dim Sw_NoEncontro As Boolean = False
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    Sw_NoEncontro = True
                    PBoxNuevo.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Modelo.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        Sw_NoEncontro = True
                        PBoxNuevo.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next



            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_ModeloNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ModeloNuevo.TextChanged

    End Sub

    Private Sub Txt_CorridaNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CorridaNuevo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CorridaNuevo.LostFocus
        'mreyes 19/Febrero/2016 12:33 p.m.
        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim OrdenIni As String = ""
                Dim OrdenFin As String = ""

                Dim objDataSet As Data.DataSet




                objDataSet = objCatalogoEstilos.usp_TraerCorrida(Txt_SucursalAct.Text, Txt_Marca.Text, Txt_ModeloNuevo.Text, Txt_CorridaNuevo.Text, Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    MedidaIni = objDataSet.Tables(0).Rows(0).Item("medini").ToString
                    MedidaFin = objDataSet.Tables(0).Rows(0).Item("medfin").ToString
                    Intervalo = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function ValidarDatos() As Boolean
        ValidarDatos = False
        If Txt_ModeloNuevo.Text = "" Then
            MsgBox("Debe especificar el modelo nuevo.", MsgBoxStyle.Critical, "Error")
            Txt_ModeloNuevo.Text = ""
            Txt_ModeloNuevo.Focus()


        End If

        If Txt_CorridaNuevo.Text = "" Then
            MsgBox("Debe especificar la corrida nueva.", MsgBoxStyle.Critical, "Error")
            Txt_CorridaNuevo.Text = ""
            Txt_CorridaNuevo.Focus()

        End If

        If Txt_MedidaNuevo.Text = "" Then
            MsgBox("Debe especificar la corrida nueva.", MsgBoxStyle.Critical, "Error")
            Txt_MedidaNuevo.Text = ""
            Txt_MedidaNuevo.Focus()

        End If

        If Cbo_Motivo.Text = "" Then
            MsgBox("Debe especificar un motivo.", MsgBoxStyle.Critical, "Error")
            Cbo_Motivo.Text = ""
            Cbo_Motivo.Focus()
        End If

        ValidarDatos = True
    End Function

    Private Sub Btn_Aceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 19/Febrero/2016 12:51 p.m.
        Dim Guardo As Boolean = False
        If MsgBox("Esta seguro de querer realizar la operación Caja Calzado", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

        If ValidarDatos() = False Then Exit Sub


        Using objAjuste As New BCL.BCLAjustes(GLB_ConStringCipSis)
            Guardo = objAjuste.usp_Captura_CajaCalzado(1, Txt_SucursalOri.Text, Txt_IdFolioSuc.Text, Txt_Proveedor.Text, Txt_SucursalAct.Text, Txt_Serie.Text, Txt_FechaRecibo.Text, Txt_Marca.Text, Txt_Modelo.Text, Txt_Corrida.Text, Txt_Medida.Text, Txt_MarcaNuevo.Text, Txt_ModeloNuevo.Text, Txt_CorridaNuevo.Text, Txt_MedidaNuevo.Text, Cbo_Motivo.Text, GLB_Idempleado)
        End Using

        If Guardo = True Then
            ' Cambiar en Factprov.
            Using objAjuste As New BCL.BCLAjustes(GLB_ConStringCipSis)
                Guardo = objAjuste.usp_Captura_CajaCalzado(2, Txt_SucursalOri.Text, Txt_IdFolioSuc.Text, Txt_Proveedor.Text, Txt_SucursalAct.Text, Txt_Serie.Text, Txt_FechaRecibo.Text, Txt_Marca.Text, Txt_Modelo.Text, Txt_Corrida.Text, Txt_Medida.Text, Txt_MarcaNuevo.Text, Txt_ModeloNuevo.Text, Txt_CorridaNuevo.Text, Txt_MedidaNuevo.Text, Cbo_Motivo.Text, GLB_Idempleado)
            End Using


        Else

            MsgBox("No se registro el Caja Calzado, intente nuevamente. ")
        End If



        MsgBox("Serie '" & Txt_Serie.Text & "', cambiada correctamente.", MsgBoxStyle.Information, "Confirmación")
        Sw_Registro = True
        Me.Close()
        Me.Dispose()

        '' Cambiar en factprov.
        '' Cambiar en serie.
        '' Hacer la salida y posterior entrada de la serie, 
        '' Guardar en Caja Calzado.






    End Sub

    Private Sub Txt_MedidaNuevo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_MedidaNuevo.LostFocus

        If Intervalo <> "-" Then
            If InStr(Txt_MedidaNuevo.Text, "-") > 0 Then
                ' si tiene medios
                MsgBox("La corrida no acepta medios.", MsgBoxStyle.Critical, "Error")
                Txt_MedidaNuevo.Text = ""
                Txt_MedidaNuevo.Focus()

                Exit Sub
            End If
        End If

        If Mid(Txt_MedidaNuevo.Text, 1, 2) < MedidaIni Or Mid(Txt_MedidaNuevo.Text, 1, 2) > MedidaFin Then
            MsgBox("La medida no corresponde a la corrida.", MsgBoxStyle.Critical, "Error")
            Txt_MedidaNuevo.Text = ""
            Txt_MedidaNuevo.Text = ""
        End If

    End Sub


    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Txt_Serie.Text = ""
        Txt_Marca.Text = ""
        Txt_DescripMarca.Text = ""
        Txt_Medida.Text = ""
        Txt_Corrida.Text = ""
        Txt_FechaRecibo.Text = ""
        Txt_Proveedor.Text = ""

        Txt_MarcaNuevo.Text = ""
        Txt_MedidaNuevo.Text = ""
        Txt_ModeloNuevo.Text = ""
        Txt_CorridaNuevo.Text = ""

        PBoxAnterior.Image = Nothing
        PBoxNuevo.Image = Nothing

    End Sub

    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Modelo.TextChanged

    End Sub

    Private Sub Txt_CorridaNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CorridaNuevo.TextChanged

    End Sub

    Private Sub frmCatalogoCajaCalzado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Accion = 4 Then
            Pnl_Anterior.Enabled = False
            Panel1.Enabled = False
            Btn_Aceptar.Enabled = False
            Call CargarFotoAnterior()
            Call CargarFotoNueva()

        End If
    End Sub

    Private Sub Btn_Cancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Txt_MedidaNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_MedidaNuevo.TextChanged

    End Sub
End Class