Public Class frmCatalogoMetas
    'mreyes 31/Agosto/2012 05:15 p.m.

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Dim IdMetaB As Integer = 0
    Dim AnioB As Integer = 0
    Dim SucursalB As String = ""
    Public GrupoB As String = ""
    Dim ParesB As Decimal = 0
    Dim MesB As Integer = 0

    Private objDataSet As Data.DataSet
    Public Sw_CorrerCalculo As Boolean = False

    Private Function usp_CalculaMetaVentasNetas(ByVal Sucursal As String, ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal Porc As Integer) As Boolean


        Using objRegistro As New BCL.BCLMeta(GLB_ConStringNomSis)
            Try
                'Generar la fecha del añol pasado para correr
                'call usp_CalculaMetaVentasNetas("33","2011-08-01","2011-08-31","MREYES");
                'Get the specific project selected in the ListView control
                usp_CalculaMetaVentasNetas = objRegistro.usp_CalculaMetaVentasNetas(Sucursal, FechaIni, FechaFin, GLB_Usuario, Porc)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Private Function usp_Captura_Meta() As Boolean
        'mreyes 05/Septiembre/2012 01:43 p.m.

        Using objRegistro As New BCL.BCLMeta(GLB_ConStringNomSis)
            Try
                usp_Captura_Meta = objRegistro.usp_Captura_Meta(1, IdMetaB, AnioB, MesB, SucursalB, GrupoB, ParesB, GLB_Usuario)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 05/Septiembre/2012 01:38 p.m.
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim Fecha As Date = "1900-01-01"

        Try
            If Validar() = False Then Exit Sub
            If Sw_CorrerCalculo = False Then
                If MsgBox("Esta seguro actualizar la meta del mes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
                'Mandar llamar a actualización
                If Accion = 1 Then
                    AnioB = Val(Txt_Anio.Text)
                    MesB = pub_TraerMes(Cbo_Mes.Text)
                    SucursalB = Txt_Sucursal.Text
                    GrupoB = "C"
                    ParesB = Val(Txt_Meta.Text)

                    If usp_Captura_Meta() = False Then
                        MsgBox("No se pudo registrar la meta. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If

                    AnioB = Val(Txt_Anio.Text)
                    MesB = pub_TraerMes(Cbo_Mes.Text)
                    SucursalB = Txt_Sucursal.Text
                    GrupoB = "A"
                    ParesB = Val(Txt_MetaA.Text)
                    If usp_Captura_Meta() = False Then
                        MsgBox("No se pudo registrar la meta. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                    GLB_RefrescarPedido = True
                    Me.Close()
                    Me.Dispose()
                Else
                    AnioB = Val(Txt_Anio.Text)
                    MesB = pub_TraerMes(Cbo_Mes.Text)
                    SucursalB = Txt_Sucursal.Text

                    If GrupoB = "C" Then
                        ParesB = Val(Txt_Meta.Text)
                    Else
                        ParesB = Val(Txt_MetaA.Text)
                    End If

                    If usp_Captura_Meta() = False Then
                        MsgBox("No se pudo registrar la meta. Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                        Exit Sub
                    End If
                End If


            Else
                If MsgBox("Esta seguro de generar la metas, según el filtro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

                If Cbo_Mes.Text.Length > 0 Then
                    Fecha = Val(Txt_Anio.Text) - 1 & "-" & pub_TraerMes(Cbo_Mes.Text) & "-01"
                    FechaIni = pub_TraerUltoPrimDiaMes(1, Fecha)
                    FechaFin = pub_TraerUltoPrimDiaMes(2, Fecha)
                End If

                If usp_CalculaMetaVentasNetas(Txt_Sucursal.Text, FechaIni, FechaFin, Val(Txt_Porcinc.Text)) = False Then
                    MsgBox("No se pudieron generar las metas.", MsgBoxStyle.Critical, "Aviso")
                    Me.Close()
                    Me.Dispose()
                    Exit Sub
                End If
            End If
            GLB_RefrescarPedido = True
            MsgBox("Proceso de Metas Terminado", MsgBoxStyle.Information, "Confirmación")
            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Function Validar() As Boolean
        Try
            Validar = False
            If Txt_Anio.Text.Length = 0 Or Val(Txt_Anio.Text) < Year(GLB_FechaHoy) Then
                MsgBox("Debe especificar un AÑO valido.", MsgBoxStyle.Critical, "Error de Validación")
                Txt_Anio.Text = ""
                Txt_Anio.Focus()
                Exit Function
            End If

            Validar = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

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


    Private Sub frmCatalogoSegBit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Txt_Porcinc.Text = "6"
            If GrupoB = "C" Then
                Txt_MetaA.Enabled = False
            Else
                Txt_Meta.Enabled = False
            End If
            If Accion = 3 Then
                'cvonsulta
                Pnl_Edicion.Enabled = False
            End If
            If Accion = 1 Or Sw_CorrerCalculo = True Then
                Txt_MetaA.Enabled = True
                Txt_Meta.Enabled = True
                GrupoB = ""
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Accion = 1
            Call Edicion()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub Edicion()
        Try
            Select Case Accion
                Case 3, 4
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Pnl_Edicion.Enabled = False
                    Pnl_Edicion.Enabled = False

                    Call CambiaBackcolor()

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True

            End Select
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
    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Accion = 2
        Call Edicion()
    End Sub


    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                'If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                'Me.Dispose()
                Me.Close()
                Sw_Registro = False
                'End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Call TraerSucursal()
    End Sub
    Private Sub TraerSucursal()

        If Txt_Sucursal.Text.Length = 0 Then Exit Sub

        Try
            'Get the specific project selected in the ListView control
            If Txt_Sucursal.Text.Trim.Length < 2 Then
                Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
            End If

            Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        Dim myForm As New frmConsulta


        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try


                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    myForm.Tipo = Tipo
                    myForm.Sw_Nomina = True
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



    Private Sub Txt_Anio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Anio.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Meta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Meta.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

 
    Private Sub Txt_Meta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Meta.TextChanged

    End Sub

    Private Sub Txt_Anio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Anio.TextChanged

    End Sub

    Private Sub Txt_Porcinc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Porcinc.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Porcinc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Porcinc.LostFocus
        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim Fecha As Date = "1900-01-01"

        If Txt_Porcinc.Text.Length = 0 Then Exit Sub
        If Cbo_Mes.Text.Length > 0 Then
            Fecha = Val(Txt_Anio.Text) - 1 & "-" & pub_TraerMes(Cbo_Mes.Text) & "-01"
            FechaIni = pub_TraerUltoPrimDiaMes(1, Fecha)
            FechaFin = pub_TraerUltoPrimDiaMes(2, Fecha)
        End If

        If usp_CalculaMetaVentasNetas(Txt_Sucursal.Text, FechaIni, FechaFin, Val(Txt_Porcinc.Text)) = False Then
            MsgBox("No se pudieron generar las metas.", MsgBoxStyle.Critical, "Aviso")
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If
        If Cbo_Mes.Text <> "" And Txt_Sucursal.Text <> "" Then
            Call usp_TraerMeta(Txt_Anio.Text, pub_TraerMes(Cbo_Mes.Text), Txt_Sucursal.Text, "C")
            Call usp_TraerMeta(Txt_Anio.Text, pub_TraerMes(Cbo_Mes.Text), Txt_Sucursal.Text, "A")
        End If

    End Sub

    Private Sub usp_TraerMeta(ByVal aniob As Integer, ByVal mesb As Integer, ByVal sucursalb As String, ByVal grupoartb As String)
        'mreyes 19/Junio/2012 04;57 p.m.
        Dim objDataSet As Data.DataSet
        Using objCatalogo As New BCL.BCLMeta(GLB_ConStringNomSis)
            Try

                objDataSet = objCatalogo.usp_PpalMeta(aniob, mesb, sucursalb, grupoartb)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If grupoartb = "C" Then
                        Txt_Meta.Text = objDataSet.Tables(0).Rows(0).Item("pares").ToString
                    Else
                        Txt_MetaA.Text = objDataSet.Tables(0).Rows(0).Item("pares").ToString

                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Cbo_Mes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_Mes.KeyPress

    End Sub

    Private Sub Cbo_Mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Mes.SelectedIndexChanged

    End Sub

    Private Sub Txt_Porcinc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Porcinc.TextChanged

    End Sub
End Class