Public Class frmCatalogoPreciosDet
    'mreyes 24/Octubre/2016 10:18 a.m.

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


    Private Function ValidarDatos() As Boolean
        Try
            ValidarDatos = False
            If Txt_SucContado.Text = "" Then
                MsgBox("Debe especificar la sucursal del folio de contado", MsgBoxStyle.Critical, "Error")
                Txt_SucContado.Text = ""
                Txt_SucContado.Focus()


            End If

            If Txt_BloContado.Text = "" Then
                MsgBox("Debe especificar el folio de oferta de contado.", MsgBoxStyle.Critical, "Error")
                Txt_BloContado.Text = ""
                Txt_BloContado.Focus()

            End If

            If Txt_SucCredito.Text = "" Then
                MsgBox("Debe especificar la sucursal del folio de crédito", MsgBoxStyle.Critical, "Error")
                Txt_SucCredito.Text = ""
                Txt_SucCredito.Focus()


            End If

            If Txt_BloCredito.Text = "" Then
                MsgBox("Debe especificar el folio de oferta de crédito.", MsgBoxStyle.Critical, "Error")
                Txt_BloCredito.Text = ""
                Txt_BloCredito.Focus()

            End If

            If Txt_Promocion.Text = "" Then
                MsgBox("Debe especificar un nombre para promoción.", MsgBoxStyle.Critical, "Error")
                Txt_BloCredito.Text = ""
                Txt_BloCredito.Focus()

            End If




            ValidarDatos = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Aceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try
            'mreyes 24/Octubre/2016     10:57 a.m.
            Dim Guardo As Boolean = False
            If MsgBox("Esta seguro de querer realizar la operación Detalla de Precios", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            If ValidarDatos() = False Then Exit Sub


            Using objAjuste As New BCL.BCLAjustes(GLB_ConStringCipSis)
                Guardo = objAjuste.usp_Captura_PreciosDet(1, Txt_SucContado.Text, Txt_BloContado.Text, Txt_SucCredito.Text, Txt_BloCredito.Text, Txt_Promocion.Text, Format(DtFecha.Value, "yyyy-MM-dd"), GLB_Idempleado)
            End Using



            MsgBox("Asignación de Detalle en Precio, Guardada correctamente.", MsgBoxStyle.Information, "Confirmación")
            Sw_Registro = True
            Me.Close()
            Me.Dispose()

            '' Cambiar en factprov.
            '' Cambiar en serie.
            '' Hacer la salida y posterior entrada de la serie, 
            '' Guardar en Caja Calzado.




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub






    Private Sub Txt_Modelo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_CorridaNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmCatalogoCajaCalzado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Accion = 4 Then
            Pnl_Anterior.Enabled = False

            Btn_Aceptar.Enabled = False
     

        End If
    End Sub

    Private Sub Btn_Cancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Txt_MedidaNuevo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txt_SucContado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucContado.LostFocus
        Txt_SucContado.Text = pub_RellenarIzquierda(Txt_SucContado.Text, 2)
    End Sub

    Private Sub Txt_SucContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_SucContado.TextChanged

    End Sub

    Private Sub Txt_BloContado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_BloContado.LostFocus
        Txt_BloContado.Text = pub_RellenarIzquierda(Txt_BloContado.Text, 6)
    End Sub

    Private Sub Txt_BloContado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_BloContado.TextChanged

    End Sub

    Private Sub Txt_SucCredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_SucCredito.LostFocus
        Txt_SucCredito.Text = pub_RellenarIzquierda(Txt_SucCredito.Text, 2)
    End Sub

    Private Sub Txt_SucCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_SucCredito.TextChanged

    End Sub

    Private Sub Txt_BloCredito_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_BloCredito.LostFocus
        Txt_BloCredito.Text = pub_RellenarIzquierda(Txt_BloCredito.Text, 6)
    End Sub

    Private Sub Txt_BloCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_BloCredito.TextChanged

    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Txt_BloContado.Text = ""
        Txt_SucContado.Text = ""

        Txt_BloCredito.Text = ""
        Txt_SucCredito.Text = ""
        Txt_Promocion.Text = ""
    End Sub

    Private Sub Txt_Promocion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Promocion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub Txt_Promocion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Promocion.TextChanged

    End Sub
End Class