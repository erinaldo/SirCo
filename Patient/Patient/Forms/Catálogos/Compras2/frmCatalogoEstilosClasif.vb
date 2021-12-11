Public Class frmCatalogoEstilosClasif
    'mreyes 23/Febrero/2012 02:23 p.m. 

    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Registro As Boolean = False
    Private objDataSet As Data.DataSet
    Private objDataSetFiltro As Data.DataSet
    Dim Costo As Decimal = 0
    Public Sw_PedidoNuevo As Boolean = False


    Dim blnBasicos As Boolean = False
    Dim blnTemporada As Boolean = False
    Dim blnDescontinuados As Boolean = False
    Dim blnSinClasif As Boolean = False
    Dim ArtCatB As String = ""
    Dim FechaInib As String
    Dim FechaFinb As String

    Dim intPosicion As Integer = 0
    Dim intTotalRows As Integer = 0


    Private Sub Txt_Familia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.GotFocus
        Txt_Familia.SelectAll()
    End Sub

    Private Sub Txt_Familia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Familia.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    'Catálogo de Artículos
    'mreyes 07/Febrero/2012 05:37 p.m.

    Private Sub Txt_Familia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Familia.LostFocus
        Try
            If Txt_Familia.Text.Length = 0 Then Exit Sub
            If Txt_Familia.Text.Trim.Length < 3 Then
                Txt_Familia.Text = pub_RellenarIzquierda(Txt_Familia.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Familia, Txt_DescripFamilia, "F")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Marca_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.GotFocus
        Txt_Marca.SelectAll()
    End Sub

    Private Sub Txt_Marca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Marca.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Function Inserta_Articulo() As Boolean

        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoEstilos.Inserta_Articulo  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("estilof") = Trim(Txt_Estilof.Text)
                objDataRow.Item("descripc") = Trim(Txt_Descripc.Text)
                objDataRow.Item("familia") = Trim(Txt_Familia.Text)
                objDataRow.Item("linea") = Trim(Txt_Linea.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("tipoart") = Trim(Txt_TipoArt.Text)
                objDataRow.Item("categoria") = Trim(Txt_Categoria.Text)
                objDataRow.Item("descripl") = Trim(Txt_DescripL.Text)
                objDataRow.Item("medida") = Mid(Cbo_Medida.Text, 1, 1)
                objDataRow.Item("acepdevo") = Mid(Cbo_AcepDevo.Text, 1, 1)
                objDataRow.Item("fecha") = Format(Now, "yyyyMMdd") ' Ver
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                objDataRow.Item("resmin") = Val(Txt_Resmin.Text)

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_Articulo(Accion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_Articulo = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Function Inserta_Corrida() As Boolean
        Try
            'mreyes 10/Febrero/2012 10:04 a.m.
            Dim Sw_ExisteCorrida As Boolean
            Dim TipoCrr As String = ""
            Dim Margen As Decimal = 0
            Dim TipoCrrBus As String = ""
            Dim CambPrec As String = ""
            Dim PrecioValor As Decimal = 0
            For I As Integer = 0 To DGrid.Rows.Count - 2
                If DGrid.Rows(I).Cells(0).Value.ToString.Length = 0 Then Exit Function
                Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
                    'Get a new Project DataSet
                    Try
                        PrecioValor = (DGrid.Rows(I).Cells(5).Value)

                        If Accion = 2 Then
                            Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

                                objDataSet = objCorrida.usp_TraerCorrida(Txt_Marca.Text, Txt_Estilon.Text, DGrid.Rows(I).Cells(0).Value.ToString)

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Sw_ExisteCorrida = True

                                    ' checar los precios 
                                    ''If PrecioValor <> (DGrid.Rows(I).Cells(13).Value) Then 'cambio el precio
                                    ''    If MsgBox("El sistema ha detectado un cambio de precio para la corrida '" & DGrid.Rows(I).Cells(0).Value.ToString & ", Es correcto.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación Cambio de Precio") = MsgBoxResult.Yes Then

                                    ''        CambPrec = fn_TraerFolioCambPrec("99") 'sucursal de cambio de precio
                                    ''        CambPrec = pub_RellenarIzquierda(CambPrec, 6)

                                    ''        If Inserta_OrdeComp(OrdeComp) = False Then
                                    ''            Throw New Exception("Falló Inserción de Corrida")
                                    ''            Exit Function
                                    ''        End If

                                    ''        If Actualiza_FolioCambPrec("") = False Then
                                    ''            Throw New Exception("Falló Inserción de Corrida")
                                    ''            Exit Function
                                    ''        End If
                                    ''    Else
                                    ''        PrecioValor = (DGrid.Rows(I).Cells(13).Value)
                                    ''    End If
                                    ''End If
                                Else
                                    Sw_ExisteCorrida = False
                                End If
                            End Using
                        End If
                        Margen = DGrid.Rows(I).Cells(6).Value
                        TipoCrrBus = IIf(IsNothing(DGrid.Rows(I).Cells(12).Value), "", DGrid.Rows(I).Cells(12).Value)
                        TipoCrr = CalcularTipoCrr(DGrid.Rows(I).Cells(0).Value.ToString, TipoCrrBus, Margen)
                        objDataSet = objCatalogoEstilos.Inserta_Corrida  'INSERTA NUEVO DATASET
                        Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                        objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                        objDataRow.Item("estilon") = (Txt_Estilon.Text)
                        objDataRow.Item("corrida") = DGrid.Rows(I).Cells(0).Value.ToString
                        objDataRow.Item("intervalo") = DGrid.Rows(I).Cells(1).Value.ToString
                        objDataRow.Item("medini") = DGrid.Rows(I).Cells(2).Value.ToString
                        objDataRow.Item("medfin") = DGrid.Rows(I).Cells(3).Value.ToString
                        objDataRow.Item("costo") = (DGrid.Rows(I).Cells(4).Value)
                        '                        objDataRow.Item("precio") = (DGrid.Rows(I).Cells(5).Value)
                        objDataRow.Item("precio") = PrecioValor
                        ' NO SE GRABAN SI ES UNA MODIFICACIÓN
                        objDataRow.Item("ult_cmp") = "01-01-1900"
                        objDataRow.Item("ult_vta") = "01-01-1900"
                        objDataRow.Item("blofer") = ""
                        objDataRow.Item("tipocrr") = TipoCrr

                        '' objDataRow.Item("fechor") = Format(Now, "YYYY-MM-DD HH:MM:SS") ' Ver como se graba en la base de datos mysql

                        'Add the DataRow to the DataSet
                        objDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project
                        If Sw_ExisteCorrida = True Then
                            If Not objCatalogoEstilos.usp_Captura_Corrida(2, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Corrida")
                                End If
                            End If
                        Else
                            If Not objCatalogoEstilos.usp_Captura_Corrida(1, objDataSet) Then
                                If Accion <> 2 Then
                                    Throw New Exception("Falló Inserción de Corrida")
                                End If
                            End If
                        End If
                        objDataSet.Dispose()
                        objDataRow.Table.Dispose()


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
                If Accion = 2 Then
                    If Eliminar_Medida(Trim(Txt_Marca.Text), (Txt_Estilon.Text), DGrid.Rows(I).Cells(0).Value.ToString) = False Then
                        'pensar que poner
                    End If
                End If
                Call Genera_Medida(DGrid.Rows(I).Cells(2).Value.ToString, DGrid.Rows(I).Cells(3).Value.ToString, I)
            Next
            Inserta_Corrida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Inserta_CambPrec(ByVal CambPrec As String) As Boolean
        'mreyes 26/Abril/2012 06:13 p.m.
        Using objCambPrec As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objCambPrec.Inserta_CambPrec  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                'Set the values in the DataRow

                objDataRow.Item("sucursal") = "99"
                objDataRow.Item("cambprec") = Trim(CambPrec)
                objDataRow.Item("status") = "PA"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("nivel") = "A"
                objDataRow.Item("mlfp") = ""
                objDataRow.Item("porcent") = 0
                objDataRow.Item("observa") = ""
                objDataRow.Item("usuario") = GLB_Usuario
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                ''If Not objCambPrec.usp_Captura_OrdeComp(Accion, objDataSet) Then
                ''    '' Throw New Exception("Falló Inserción de OrdeComp")
                ''Else
                ''    Inserta_CambPrec = True
                ''End If
                Inserta_CambPrec = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function

    Function Inserta_Medida(ByVal Tipo As String, ByVal MedIni As String, ByVal Renglon As Integer) As Boolean
        'mreyes 23/Febrero/2012 01:01 p.m.


        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilos.Inserta_Medida  'INSERTA NUEVO DATASET
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow
                'If Tipo = "N" Then
                '    If Mi < 10 Then
                '        MedIni = pub_RellenarIzquierda(Mi, 2)
                '    End If
                'End If
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("medida") = MedIni
                objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells(0).Value.ToString
                objDataRow.Item("ctdcri") = 0
                objDataRow.Item("ctdide") = 0
                objDataRow.Item("ctdsol") = 0
                objDataRow.Item("orden") = "00"

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)





                If Not objCatalogoEstilos.usp_Captura_Medida(1, objDataSet) Then
                    If Accion <> 2 Then
                        Throw New Exception("Falló Inserción de Medida")
                    End If
                End If

            End Using
            Inserta_Medida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Genera_Medida(ByVal MedIni As String, ByVal MedFin As String, ByVal I As Integer) As Boolean
        'mreyes 23/Febrero/2012 12:42 p.m
        '' LA MEDIDA VA A CONSIDERACIÓN DEL INTERVALO... OJO PARA LOS NUMEROS 
        Try
            Dim MI As Integer = 0
            Dim MF As Integer = 0
            Dim Intervalo As String = ""
            Dim Inc As Integer = 0



            Select Case Mid(Cbo_Medida.Text, 1, 1)

                Case "N"
                    '' CASO DE NUMEROS 

                    MI = Val(DGrid.Rows(I).Cells(2).Value)
                    MF = Val(DGrid.Rows(I).Cells(3).Value)
                    Intervalo = DGrid.Rows(I).Cells(1).Value

                    For MI = Val(DGrid.Rows(I).Cells(2).Value) To MF
                        '' tomar en cuenta el intervalo para grabar el valor ...
                        If Intervalo <> "-" Then
                            Inc = Intervalo
                        Else
                            Inc = 1
                        End If
                        '' insertar medida 
                        Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2), I)
                        If Intervalo = "-" Then
                            Call Inserta_Medida("N", pub_RellenarIzquierda(MI, 2) + Intervalo, I)
                        End If
                        MI = MI + Inc - 1

                    Next

                Case Else
                    ' LETRS O SIN NADA 

                    Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
                        Try

                            Dim Medida As String = ""
                            Dim OrdeIni As String = DGrid.Rows(I).Cells("ordenini").Value
                            Dim OrdeFin As String = DGrid.Rows(I).Cells("ordenfin").Value

                            Dim objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin(OrdeIni, OrdeFin, Mid(Cbo_Medida.Text, 1, 1))

                            If objDataSet.Tables(0).Rows.Count > 0 Then
                                For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                                    Medida = objDataSet.Tables(0).rows(z).item("medida").ToString
                                    Call Inserta_Medida(Mid(Cbo_Medida.Text, 1, 1), Medida, I)
                                Next
                            End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using


            End Select
            Genera_Medida = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub usp_TraerCorrida(ByVal EstiloN As String)
        DGrid.Rows.Clear()
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Dim Margen As Decimal
                Dim PComp As Decimal
                Dim Precio As Decimal
                objDataSet = objCatalogoEstilos.usp_TraerCorrida(Txt_Marca.Text, EstiloN, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = pub_CalcularCostoPedido((objDataSet.Tables(0).Rows(I).Item(6)), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                        Precio = Val(objDataSet.Tables(0).Rows(I).Item("precio"))
                        PComp = Val(objDataSet.Tables(0).Rows(I).Item("costo"))
                        Margen = pub_CalcularMargenPedido(Precio, Costo)

                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item(2).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(3).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(4).ToString, _
                                         objDataSet.Tables(0).Rows(I).Item(5).ToString, _
                                         Val(objDataSet.Tables(0).Rows(I).Item(6)), _
                                         Val(objDataSet.Tables(0).Rows(I).Item(7)), _
                                         Margen, _
                                         objDataSet.Tables(0).Rows(I).Item(10).ToString, _
                                         "", "", _
                                        objDataSet.Tables(0).Rows(I).Item(12).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(13).ToString, _
                                        objDataSet.Tables(0).Rows(I).Item(11).ToString, _
                                        Val(objDataSet.Tables(0).Rows(I).Item("precio")))


                    Next

                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Function ValidarEdicion() As Boolean
        'mreyes 03/Marzo/2012 11:23 a.m. 
        ValidarEdicion = False
        Try
            If Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar una marca para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Marca.Focus()
                Exit Function
            End If

            If Txt_Estilof.Text.Length = 0 Then
                MsgBox("Debe especificar el estilo de fábrica para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Estilof.Focus()
                Exit Function
            End If

            If Txt_Descripc.Text.Length = 0 Then
                MsgBox("Debe especificar una descripción corta para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Descripc.Focus()
                Exit Function
            End If

            If Txt_Familia.Text.Length = 0 Then
                MsgBox("Debe especificar una Familia para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Familia.Focus()
                Exit Function
            End If

            If Txt_Linea.Text.Length = 0 Then
                MsgBox("Debe especificar una Línea para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Linea.Focus()
                Exit Function
            End If

            If Txt_Proveedor.Text.Length = 0 Then
                MsgBox("Debe especificar un Proveedor para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Proveedor.Focus()
                Exit Function
            End If

            If Txt_TipoArt.Text.Length = 0 Then
                MsgBox("Debe especificar un Tipo de Artículo para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_TipoArt.Focus()
                Exit Function
            End If

            If Txt_Categoria.Text.Length = 0 Then
                MsgBox("Debe especificar una Categoría para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Categoria.Focus()
                Exit Function
            End If

            If Cbo_Medida.Text.Length = 0 Then
                MsgBox("Debe especificar una medida para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Cbo_Medida.Focus()
                Exit Function
            End If

            If Cbo_AcepDevo.Text.Length = 0 Then
                MsgBox("Debe especificar si acepta o no devoluciones para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Cbo_AcepDevo.Focus()
                Exit Function
            End If

            If Txt_Resmin.Text.Length = 0 Then
                MsgBox("Debe especificar el ResMin para el Estilo.", MsgBoxStyle.Critical, "Validación")
                Txt_Resmin.Focus()
                Exit Function
            End If

            '' validar corrida 
            With DGrid
                If .Rows(0).Cells(0).Value = "" Then
                    MsgBox("Debe especificar almenos una corrida para el Estilo.", MsgBoxStyle.Critical, "Validación")
                    DGrid.Focus()
                    Exit Function
                End If
            End With

            ValidarEdicion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click

        Try
            If Accion = 1 Then '''' es un articulo nuevo
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Grabar el Artículo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Articulo() = True Then
                        If Inserta_Corrida() = True Then
                            MessageBox.Show("Exitosamente Grabado el estilo '" & Txt_Estilon.Text & "' para la marca '" & Txt_Marca.Text & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Sw_Registro = True
                            GLB_CatEsiloCancelado = False
                            Me.Close()
                            '' Me.Dispose()
                        Else
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            ElseIf Accion = 2 Then 'es una actualización
                If ValidarEdicion() = False Then Exit Sub
                If MsgBox("Estas Seguro de Actualizar el Artículo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    If Inserta_Articulo() = True Then
                        If Inserta_Corrida() = True Then
                            Sw_Registro = True
                            MessageBox.Show("Exitosamente Grabado el estilo '" & Txt_Estilon.Text & "' para la marca '" & Txt_Marca.Text & " !", "Agregando Arículo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                            ' Me.Dispose()
                        Else
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        GLB_RefrescarPedido = True
                    End If
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '' FUNCION PARA SOLO ESCRIBIR LETRAS EN UN DATAGRID 
        Try
            ' obtener indice de la columna  
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim caracter As Char = e.KeyChar
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   

            If columna = 0 Then ''columna de corrida

                ' Obtener caracter   


                ' comprobar si el caracter es un número o el retroceso   
                If Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar   
                    e.KeyChar = Chr(0)
                Else
                    If caracter = "A" Or caracter = "B" Or caracter = "C" Or caracter = "D" Or caracter = "E" Or caracter = "F" Then
                        e.KeyChar = UCase(caracter)
                    Else
                        e.KeyChar = Chr(0)
                    End If
                End If
            End If

            If columna = 1 Then '' columna de i
                If Mid(Cbo_Medida.Text, 1, 1) = "N" Then
                    If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not caracter = "-" Then
                        e.KeyChar = Chr(0)
                    End If


                End If
            End If

            ''If Accion <> 1 Then
            ''    If columna = 5 Then
            ''        e.KeyChar = Chr(0)
            ''    End If
            ''End If

            If columna >= 4 And columna <= 5 Then

                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (caracter = ".") Then
                    e.KeyChar = Chr(0)
                End If
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick

    End Sub

    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        'mreyes 23/Febrero/2012 11:40 a.m.
        Try
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            If columna = 1 Then
                If Mid(Cbo_Medida.Text, 1, 1) <> "N" Then
                    If DGrid.Rows(renglon).Cells(columna).Value <> "L" Then
                        MsgBox("El intervalo en la medida '" & Cbo_Medida.Text & "' es L.", MsgBoxStyle.Critical, "Validación")
                        DGrid.Rows(renglon).Cells(columna).Value = "L"
                    End If

                End If
            End If

            If columna = 2 Or columna = 3 Then
                '' VALIDAR LO QUE SE ESTA ESCRIBIENDO SI

                If Mid(Cbo_Medida.Text, 1, 1) = "N" Then
                    If Not IsNumeric(DGrid.Rows(renglon).Cells(columna).Value) Then
                        MsgBox("Debe especificar un número valido para la corrida.", MsgBoxStyle.Critical, "Validación")
                    End If
                    DGrid.Rows(renglon).Cells(columna).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(columna).Value, 2)
                End If

                If Mid(Cbo_Medida.Text, 1, 1) <> "N" Then
                    If IsNumeric(DGrid.Rows(renglon).Cells(columna).Value) And Mid(Cbo_Medida.Text, 1, 1) = "L" Then
                        MsgBox("Debe especificar una letra válido para la corrida.", MsgBoxStyle.Critical, "Validación")
                    Else
                        Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                        Txt_Campo1.Text = Mid(Cbo_Medida.Text, 1, 1)
                        Call TxtGrid(Txt_Campo, Txt_Campo1, "LT")
                        DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo1.Text
                        If columna = 2 Then
                            DGrid.Rows(renglon).Cells("ordenini").Value = Txt_Campo.Text
                        Else
                            DGrid.Rows(renglon).Cells("ordenfin").Value = Txt_Campo.Text
                        End If

                    End If
                End If
            End If

            If columna = 4 Then
                '' calcular el costo
                DGrid.Rows(renglon).Cells(5).Value = pub_CalcularPrecioVenta(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Factor.Text))
                Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))

                DGrid.Rows(renglon).Cells(6).Value = pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(5).Value), Costo)
            End If
            If columna = 5 Then
                Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))
                DGrid.Rows(renglon).Cells(6).Value = pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(5).Value), Costo)


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtGrid(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 23/Febrero/2012 11:50 a.m.
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text, Txt_Campo1.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Txt_Campo.Text = ""
                    If Tipo <> "E" Then
                        myForm.Campo1 = Txt_Campo1.Text
                        myForm.Tipo = Tipo
                        myForm.ShowDialog()
                        Txt_Campo.Text = myForm.Campo
                        Txt_Campo1.Text = myForm.Campo1
                        ''If Txt_Campo.Text.Length = 0 Then
                        ''    Txt_Campo.Focus()
                        ''End If

                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub DGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.CurrentCellDirtyStateChanged
        'mreyes 17/Febrero/2012 05:32 p.m.
        Try

            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Importe As Double

            If columna = 4 Or columna = 5 Then
                If DGrid.Rows(renglon).Cells(4).Value <> 0 And DGrid.Rows(renglon).Cells(5).Value <> 0 Then
                    Importe = DGrid.Rows(renglon).Cells(4).Value
                    DGrid.Rows(renglon).Cells(4).Value = Format(Importe, "#,##0.00")
                    Importe = DGrid.Rows(renglon).Cells(5).Value
                    DGrid.Rows(renglon).Cells(5).Value = Format(Importe, "#,##0.00")
                    Costo = pub_CalcularCostoPedido(DGrid.Rows(renglon).Cells(4).Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text))

                    DGrid.Rows(renglon).Cells(6).Value = Format(pub_CalcularMargenPedido((DGrid.Rows(renglon).Cells(5).Value), Costo), "#0.00")
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGrid.EditingControlShowing
        Dim validar As TextBox = CType(e.Control, TextBox)
        Try
            ' agregar el controlador de eventos para el KeyPress   

            AddHandler validar.KeyPress, AddressOf validar_Keypress
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'GLB_CatEsiloCancelado = True
    End Sub

    Private Sub frmCatalogoEstilos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' GLB_CatEsiloCancelado = True
    End Sub

    Private Sub frmCatalogoEstilos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        Me.Dispose()
                        Me.Close()
                        GLB_CatEsiloCancelado = True
                    End If
                Else
                    Me.Dispose()
                    Me.Close()
                    GLB_CatEsiloCancelado = True
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub frmCatalogoEstilos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Accion = 1
            Call RellenaCombos(Cbo_Medida, "MEDIDA", "", GLB_ConStringCipSis, False)

            If Accion = 1 Then
                ' LimpiarDatos()
                If Sw_PedidoNuevo = True Then
                    ' traer el estilo anterior, 
                    'If ya existe el estilo de fábrica

                    Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                        Try

                            If Txt_Estilof.Text.Length > 0 Then
                                objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, Txt_Estilof.Text)

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    Call usp_TraerCorrida(Txt_Estilon.Text)

                                    Call Txt_Familia_LostFocus(sender, e)
                                    Call Txt_Linea_LostFocus(sender, e)
                                    Call Txt_Proveedor_LostFocus(sender, e)
                                    Call Txt_TipoArt_LostFocus(sender, e)
                                    Call Txt_Categoria_LostFocus(sender, e)



                                    Txt_Descripc.Focus()
                                End If
                            End If
                            Call Txt_Marca_LostFocus(sender, e)
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using


                End If
            Else
                Call usp_TraerEstilo()
                Call usp_TraerCorrida(Txt_Estilon.Text)
            End If
            Call GenerarToolTip()
            Call CargarFotoArticulo()
            DGrid.RowHeadersVisible = False
            Call Edicion()

            Call usp_TraerClasificacionEst()

            Call RellendaGridsInfoArticulo()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellendaGridsInfoArticulo()
        Try


            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerComprasEstilos(Txt_Marca.Text, Txt_Estilon.Text, "")
            End Using

            'If objDataSet.Tables(0).Rows.Count > 0 Then
            'Else

            DGrid2.Rows.Add()
            DGrid2.Rows(0).Cells(0).Value = "COMPRAS"

            If objDataSet.Tables(0).Rows.Count > 0 Then
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(0).Cells(i - 1).Value = objDataSet.Tables(0).Rows(0).Item(i).ToString
                Next
            Else
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(0).Cells(i - 1).Value = 0
                Next
            End If

            DGrid2.Rows(0).DefaultCellStyle.BackColor = Color.Khaki

            'For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
            '    DGrid2.Rows(0).Cells(i - 1).Value = objDataSet.Tables(0).Rows(0).Item(i)
            'Next
            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerVentasEstilos(Txt_Marca.Text, Txt_Estilon.Text, "")
            End Using
            DGrid2.Rows.Add()
            DGrid2.Rows(1).Cells(0).Value = "VENTAS"
            DGrid2.Rows(1).DefaultCellStyle.BackColor = Color.PeachPuff
            If objDataSet.Tables(0).Rows.Count > 0 Then
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(1).Cells(i - 1).Value = objDataSet.Tables(0).Rows(0).Item(i).ToString
                Next
            Else
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(1).Cells(i - 1).Value = 0
                Next
            End If

            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerExistenciaEstilos(Txt_Marca.Text, Txt_Estilon.Text, "")
            End Using
            DGrid2.Rows.Add()
            DGrid2.Rows(2).Cells(0).Value = "EXISTENCIAS"
            DGrid2.Rows(2).DefaultCellStyle.BackColor = Color.Khaki
            If objDataSet.Tables(0).Rows.Count > 0 Then
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(2).Cells(i - 1).Value = objDataSet.Tables(0).Rows(0).Item(i).ToString
                Next
            Else
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(2).Cells(i - 1).Value = 0
                Next
            End If

            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerPPEstilos(Txt_Marca.Text, Txt_Estilon.Text, "")
            End Using
            DGrid2.Rows.Add()
            DGrid2.Rows(3).Cells(0).Value = "POR RECIBIR"
            DGrid2.Rows(3).DefaultCellStyle.BackColor = Color.PeachPuff
            If objDataSet.Tables(0).Rows.Count > 0 Then
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(3).Cells(i - 1).Value = objDataSet.Tables(0).Rows(0).Item(i).ToString
                Next
            Else
                For i As Integer = 2 To objDataSet.Tables(0).Columns.Count - 1
                    DGrid2.Rows(3).Cells(i - 1).Value = 0
                Next
            End If

            Dim colImagen As DataGridViewColumn = New DataGridViewColumn()
            colImagen.Name = "Total"
            colImagen.HeaderText = "Total"
            colImagen.DisplayIndex = 201
            colImagen.ReadOnly = True
            colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImagen.CellTemplate = New DataGridViewTextBoxCell
            colImagen.Visible = True
            ' añadir columna de imagen a la coleccion del grid 
            DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            Me.DGrid2.Columns.Add(colImagen)

            For i As Integer = 0 To DGrid2.Rows.Count - 2
                Dim Total As Integer = 0
                For j As Integer = 1 To 100
                    Total += CInt(DGrid2.Rows(i).Cells(j).Value)
                Next
                DGrid2.Rows(i).Cells("Total").Value = Total
            Next

            Call RellenarCorridas(0)
            'End If



            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerUltimasComprasEstilos(Txt_Marca.Text, Txt_Estilon.Text, "")
            End Using

            If objDataSet.Tables(0).Rows.Count > 0 Then
                DGrid3a.DataSource = objDataSet.Tables(0)
                For i As Integer = 1 To DGrid3a.Columns.Count - 1
                    DGrid3a.Columns(i).Visible = False
                Next

                Dim colImagen1 As DataGridViewColumn = New DataGridViewColumn()
                colImagen1.Name = "Total"
                colImagen1.HeaderText = "Total"
                colImagen1.DisplayIndex = 201
                colImagen1.ReadOnly = True
                colImagen1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                colImagen1.CellTemplate = New DataGridViewTextBoxCell
                colImagen1.Visible = True
                ' añadir columna de imagen a la coleccion del grid 
                DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
                Me.DGrid3a.Columns.Add(colImagen1)

                For i As Integer = 0 To DGrid3a.Rows.Count - 2
                    Dim Total As Integer = 0
                    If IsDBNull(DGrid3a.Rows(i)) Then
                        Continue For
                    End If

                    For j As Integer = 1 To 100
                        Total += CInt(DGrid3a.Rows(i).Cells(j).Value)
                    Next
                    DGrid3a.Rows(i).Cells("Total").Value = Total

                Next
                Call InicializaGridVtaCero()
                Call RellenarCorridas2(0)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub usp_TraerClasificacionEst()
        Dim objDSClasif As Data.DataSet
        Try
            If Txt_Estilon.Text = "" Then Exit Sub
            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDSClasif = objCatalogoEstilosC.usp_TraerClasificacionEst(Txt_Marca.Text, Txt_Estilon.Text)
                If objDSClasif.Tables(0).Rows.Count > 0 Then
                    Txt_ClasificacionDesc.Text = objDSClasif.Tables(0).Rows(0).Item("artcat").ToString
                Else
                    Txt_ClasificacionDesc.Text = "SIN CLASIFICAR"
                End If
            End Using

            If Txt_ClasificacionDesc.Text = "BASICOS" Then
                Txt_ClasificacionDesc.BackColor = Color.GreenYellow
            ElseIf Txt_ClasificacionDesc.Text = "TEMPORADA" Then
                Txt_ClasificacionDesc.BackColor = Color.Yellow
            ElseIf Txt_ClasificacionDesc.Text = "DESCONTINUADOS" Then
                Txt_ClasificacionDesc.BackColor = Color.Red
            ElseIf Txt_ClasificacionDesc.Text = "SIN CLASIFICAR" Then
                Txt_ClasificacionDesc.BackColor = Color.White
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Sub RellenarCorridas(ByVal Renglon As Integer)
        Dim Marca1 As String = Txt_Marca.Text.Trim
        Dim Estilon1 As String = Txt_Estilon.Text
        Dim MedIni As Integer = 0
        Dim MedFin As Integer = 0
        Dim Intervalo As String = ""
        Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            objDataSet = objCorrida.usp_TraerCorrida(Marca1, Estilon1, "")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                'If IsDBNull(objDataSet.Tables(0).Rows(i).Item("medini")) Then
                '    Continue For
                'End If
                If objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "CH" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "MED" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "GDE" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "XGE" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "XXG" Or _
                    objDataSet.Tables(0).Rows(i).Item("medfin").ToString.Trim = "27E" Then
                    Continue For
                End If
                MedIni = CInt(objDataSet.Tables(0).Rows(i).Item("medini").ToString)
                If MedIni < 0 Then
                    MedIni *= -1
                End If
                MedFin = CInt(objDataSet.Tables(0).Rows(i).Item("medfin").ToString)
                Intervalo = objDataSet.Tables(0).Rows(i).Item("intervalo").ToString
                For MedInicial As Integer = MedIni To MedFin
                    Dim NombreColumna As String
                    NombreColumna = TraerNombreColumna(MedInicial.ToString)
                    DGrid2.Columns(NombreColumna).Visible = True
                    If Intervalo = "-" Then
                        If MedInicial < MedFin Then
                            NombreColumna = TraerNombreColumna(MedInicial.ToString + "-")
                            DGrid2.Columns(NombreColumna).Visible = True
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Public Sub RellenarCorridas2(ByVal Renglon As Integer)
        Dim Marca1 As String = Txt_Marca.Text.Trim
        Dim Estilon1 As String = Txt_Estilon.Text
        Dim MedIni As Integer = 0
        Dim MedFin As Integer = 0
        Dim Intervalo As String = ""
        Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            objDataSet = objCorrida.usp_TraerCorrida(Marca1, Estilon1, "")
        End Using
        If objDataSet.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                'If IsDBNull(objDataSet.Tables(0).Rows(i).Item("medini")) Then
                '    Continue For
                'End If
                If objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "CH" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "MED" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "GDE" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "XGE" Or _
                    objDataSet.Tables(0).Rows(i).Item("medini").ToString.Trim = "XXG" Or _
                    objDataSet.Tables(0).Rows(i).Item("medfin").ToString.Trim = "27E" Then
                    Continue For
                End If
                MedIni = CInt(objDataSet.Tables(0).Rows(i).Item("medini").ToString)
                If MedIni < 0 Then
                    MedIni *= -1
                End If
                MedFin = CInt(objDataSet.Tables(0).Rows(i).Item("medfin").ToString)
                Intervalo = objDataSet.Tables(0).Rows(i).Item("intervalo").ToString
                For MedInicial As Integer = MedIni To MedFin
                    Dim NombreColumna As String
                    NombreColumna = TraerNombreColumna(MedInicial.ToString)
                    DGrid3a.Columns(NombreColumna).Visible = True
                    If Intervalo = "-" Then
                        If MedInicial < MedFin Then
                            NombreColumna = TraerNombreColumna(MedInicial.ToString + "-")
                            DGrid3a.Columns(NombreColumna).Visible = True
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Sub InicializaGridVtaCero()
        '' 
        Try

            DGrid3a.RowHeadersVisible = False

            DGrid3a.Columns(0).HeaderText = "Fechas"
            DGrid3a.Columns(1).HeaderText = "01"
            DGrid3a.Columns(2).HeaderText = "01-"
            DGrid3a.Columns(3).HeaderText = "02"
            DGrid3a.Columns(4).HeaderText = "02-"
            DGrid3a.Columns(5).HeaderText = "03"
            DGrid3a.Columns(6).HeaderText = "03-"
            DGrid3a.Columns(7).HeaderText = "04"
            DGrid3a.Columns(8).HeaderText = "04-"
            DGrid3a.Columns(9).HeaderText = "05"
            DGrid3a.Columns(10).HeaderText = "05-"
            DGrid3a.Columns(11).HeaderText = "06"
            DGrid3a.Columns(12).HeaderText = "06-"
            DGrid3a.Columns(13).HeaderText = "07"
            DGrid3a.Columns(14).HeaderText = "07-"
            DGrid3a.Columns(15).HeaderText = "08"
            DGrid3a.Columns(16).HeaderText = "08-"
            DGrid3a.Columns(17).HeaderText = "09"
            DGrid3a.Columns(18).HeaderText = "09-"
            DGrid3a.Columns(19).HeaderText = "10"
            DGrid3a.Columns(20).HeaderText = "10-"
            DGrid3a.Columns(21).HeaderText = "11"
            DGrid3a.Columns(22).HeaderText = "11-"
            DGrid3a.Columns(23).HeaderText = "12"
            DGrid3a.Columns(24).HeaderText = "12-"
            DGrid3a.Columns(25).HeaderText = "13"
            DGrid3a.Columns(26).HeaderText = "13-"
            DGrid3a.Columns(27).HeaderText = "14"
            DGrid3a.Columns(28).HeaderText = "14-"
            DGrid3a.Columns(29).HeaderText = "15"
            DGrid3a.Columns(30).HeaderText = "15-"
            DGrid3a.Columns(31).HeaderText = "16"
            DGrid3a.Columns(32).HeaderText = "16-"
            DGrid3a.Columns(33).HeaderText = "17"
            DGrid3a.Columns(34).HeaderText = "17-"
            DGrid3a.Columns(35).HeaderText = "18"
            DGrid3a.Columns(36).HeaderText = "18-"
            DGrid3a.Columns(37).HeaderText = "19"
            DGrid3a.Columns(38).HeaderText = "19-"
            DGrid3a.Columns(39).HeaderText = "20"
            DGrid3a.Columns(40).HeaderText = "20-"
            DGrid3a.Columns(41).HeaderText = "21"
            DGrid3a.Columns(42).HeaderText = "21-"
            DGrid3a.Columns(43).HeaderText = "22"
            DGrid3a.Columns(44).HeaderText = "22-"
            DGrid3a.Columns(45).HeaderText = "23"
            DGrid3a.Columns(46).HeaderText = "23-"
            DGrid3a.Columns(47).HeaderText = "24"
            DGrid3a.Columns(48).HeaderText = "24-"
            DGrid3a.Columns(49).HeaderText = "25"
            DGrid3a.Columns(50).HeaderText = "25-"
            DGrid3a.Columns(51).HeaderText = "26"
            DGrid3a.Columns(52).HeaderText = "26-"
            DGrid3a.Columns(53).HeaderText = "27"
            DGrid3a.Columns(54).HeaderText = "27-"
            DGrid3a.Columns(55).HeaderText = "28"
            DGrid3a.Columns(56).HeaderText = "28-"
            DGrid3a.Columns(57).HeaderText = "29"
            DGrid3a.Columns(58).HeaderText = "29-"
            DGrid3a.Columns(59).HeaderText = "30"
            DGrid3a.Columns(60).HeaderText = "30-"
            DGrid3a.Columns(61).HeaderText = "31"
            DGrid3a.Columns(62).HeaderText = "31-"
            DGrid3a.Columns(63).HeaderText = "32"
            DGrid3a.Columns(64).HeaderText = "32-"
            DGrid3a.Columns(65).HeaderText = "33"
            DGrid3a.Columns(66).HeaderText = "33-"
            DGrid3a.Columns(67).HeaderText = "34"
            DGrid3a.Columns(68).HeaderText = "34-"
            DGrid3a.Columns(69).HeaderText = "35"
            DGrid3a.Columns(70).HeaderText = "35-"
            DGrid3a.Columns(71).HeaderText = "36"
            DGrid3a.Columns(72).HeaderText = "36-"
            DGrid3a.Columns(73).HeaderText = "37"
            DGrid3a.Columns(74).HeaderText = "37-"
            DGrid3a.Columns(75).HeaderText = "38"
            DGrid3a.Columns(76).HeaderText = "38-"
            DGrid3a.Columns(77).HeaderText = "39"
            DGrid3a.Columns(78).HeaderText = "39-"
            DGrid3a.Columns(79).HeaderText = "40"
            DGrid3a.Columns(80).HeaderText = "40-"
            DGrid3a.Columns(81).HeaderText = "41"
            DGrid3a.Columns(82).HeaderText = "41-"
            DGrid3a.Columns(83).HeaderText = "42"
            DGrid3a.Columns(84).HeaderText = "42-"
            DGrid3a.Columns(85).HeaderText = "43"
            DGrid3a.Columns(86).HeaderText = "43-"
            DGrid3a.Columns(87).HeaderText = "44"
            DGrid3a.Columns(88).HeaderText = "44-"
            DGrid3a.Columns(89).HeaderText = "45"
            DGrid3a.Columns(90).HeaderText = "45-"
            DGrid3a.Columns(91).HeaderText = "46"
            DGrid3a.Columns(92).HeaderText = "46-"
            DGrid3a.Columns(93).HeaderText = "47"
            DGrid3a.Columns(94).HeaderText = "47-"
            DGrid3a.Columns(95).HeaderText = "48"
            DGrid3a.Columns(96).HeaderText = "48-"
            DGrid3a.Columns(97).HeaderText = "49"
            DGrid3a.Columns(98).HeaderText = "49-"
            DGrid3a.Columns(99).HeaderText = "50"
            DGrid3a.Columns(100).HeaderText = "50-"

            DGrid3a.Columns("Total").Visible = True


            DGrid3a.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid3a.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid3a.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Public Function TraerNombreColumna(ByVal Medida As String) As String
        If Medida = "1" Then
            Return "M1"
        ElseIf Medida = "1-" Then
            Return "M1_"
        ElseIf Medida = "2" Then
            Return "M2"
        ElseIf Medida = "2-" Then
            Return "M2_"
        ElseIf Medida = "3" Then
            Return "M3"
        ElseIf Medida = "3-" Then
            Return "M3_"
        ElseIf Medida = "4" Then
            Return "M4"
        ElseIf Medida = "4-" Then
            Return "M4_"
        ElseIf Medida = "5" Then
            Return "M5"
        ElseIf Medida = "5-" Then
            Return "M5_"
        ElseIf Medida = "6" Then
            Return "M6"
        ElseIf Medida = "6-" Then
            Return "M6_"
        ElseIf Medida = "7" Then
            Return "M7"
        ElseIf Medida = "7-" Then
            Return "M7_"
        ElseIf Medida = "8" Then
            Return "M8"
        ElseIf Medida = "8-" Then
            Return "M8_"
        ElseIf Medida = "9" Then
            Return "M9"
        ElseIf Medida = "9-" Then
            Return "M9_"
        ElseIf Medida = "10" Then
            Return "M10"
        ElseIf Medida = "10-" Then
            Return "M10_"
        ElseIf Medida = "11" Then
            Return "M11"
        ElseIf Medida = "11-" Then
            Return "M11_"
        ElseIf Medida = "12" Then
            Return "M12"
        ElseIf Medida = "12-" Then
            Return "M12_"
        ElseIf Medida = "13" Then
            Return "M13"
        ElseIf Medida = "13-" Then
            Return "M13_"
        ElseIf Medida = "14" Then
            Return "M14"
        ElseIf Medida = "14-" Then
            Return "M14_"
        ElseIf Medida = "15" Then
            Return "M15"
        ElseIf Medida = "15-" Then
            Return "M15_"
        ElseIf Medida = "16" Then
            Return "M16"
        ElseIf Medida = "16-" Then
            Return "M16_"
        ElseIf Medida = "17" Then
            Return "M17"
        ElseIf Medida = "17-" Then
            Return "M17_"
        ElseIf Medida = "18" Then
            Return "M18"
        ElseIf Medida = "18-" Then
            Return "M18_"
        ElseIf Medida = "19" Then
            Return "M19"
        ElseIf Medida = "19-" Then
            Return "M19_"
        ElseIf Medida = "20" Then
            Return "M20"
        ElseIf Medida = "20-" Then
            Return "M20_"
        ElseIf Medida = "21" Then
            Return "M21"
        ElseIf Medida = "21-" Then
            Return "M21_"
        ElseIf Medida = "22" Then
            Return "M22"
        ElseIf Medida = "22-" Then
            Return "M22_"
        ElseIf Medida = "23" Then
            Return "M23"
        ElseIf Medida = "23-" Then
            Return "M23_"
        ElseIf Medida = "24" Then
            Return "M24"
        ElseIf Medida = "24-" Then
            Return "M24_"
        ElseIf Medida = "25" Then
            Return "M25"
        ElseIf Medida = "25-" Then
            Return "M25_"
        ElseIf Medida = "26" Then
            Return "M26"
        ElseIf Medida = "26-" Then
            Return "M26_"
        ElseIf Medida = "27" Then
            Return "M27"
        ElseIf Medida = "27-" Then
            Return "M27_"
        ElseIf Medida = "28" Then
            Return "M28"
        ElseIf Medida = "28-" Then
            Return "M28_"
        ElseIf Medida = "29" Then
            Return "M29"
        ElseIf Medida = "29-" Then
            Return "M29_"
        ElseIf Medida = "30" Then
            Return "M30"
        ElseIf Medida = "30-" Then
            Return "M30_"
        ElseIf Medida = "31" Then
            Return "M31"
        ElseIf Medida = "31-" Then
            Return "M31_"
        ElseIf Medida = "32" Then
            Return "M32"
        ElseIf Medida = "32-" Then
            Return "M32_"
        ElseIf Medida = "33" Then
            Return "M33"
        ElseIf Medida = "33-" Then
            Return "M33_"
        ElseIf Medida = "34" Then
            Return "M34"
        ElseIf Medida = "34-" Then
            Return "M34_"
        ElseIf Medida = "35" Then
            Return "M35"
        ElseIf Medida = "35-" Then
            Return "M35_"
        ElseIf Medida = "36" Then
            Return "M36"
        ElseIf Medida = "36-" Then
            Return "M36_"
        ElseIf Medida = "37" Then
            Return "M37"
        ElseIf Medida = "37-" Then
            Return "M37_"
        ElseIf Medida = "38" Then
            Return "M38"
        ElseIf Medida = "38-" Then
            Return "M38_"
        ElseIf Medida = "39" Then
            Return "M39"
        ElseIf Medida = "39-" Then
            Return "M39_"
        ElseIf Medida = "40" Then
            Return "M40"
        ElseIf Medida = "40-" Then
            Return "M40_"
        ElseIf Medida = "41" Then
            Return "M41"
        ElseIf Medida = "41-" Then
            Return "M41_"
        ElseIf Medida = "42" Then
            Return "M42"
        ElseIf Medida = "42-" Then
            Return "M42_"
        ElseIf Medida = "43" Then
            Return "M43"
        ElseIf Medida = "43-" Then
            Return "M43_"
        ElseIf Medida = "44" Then
            Return "M44"
        ElseIf Medida = "44-" Then
            Return "M44_"
        ElseIf Medida = "45" Then
            Return "M45"
        ElseIf Medida = "45-" Then
            Return "M45_"
        ElseIf Medida = "46" Then
            Return "M46"
        ElseIf Medida = "46-" Then
            Return "M46_"
        ElseIf Medida = "47" Then
            Return "M47"
        ElseIf Medida = "47-" Then
            Return "M47_"
        ElseIf Medida = "48" Then
            Return "M48"
        ElseIf Medida = "48-" Then
            Return "M48_"
        ElseIf Medida = "49" Then
            Return "M49"
        ElseIf Medida = "49-" Then
            Return "M49_"
        ElseIf Medida = "50" Then
            Return "M50"
        ElseIf Medida = "50-" Then
            Return "M50_"
        Else
            Return "Tipo"
        End If
    End Function

    Private Sub usp_TraerEstilo()
        Dim objDataSetEstilo As Data.DataSet
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try

                objDataSetEstilo = Nothing
                objDataSetEstilo = objCatalogoEstilos.usp_TraerEstilo(Txt_Marca.Text, Txt_Estilon.Text, Txt_Estilof.Text, Txt_Familia.Text, Txt_Linea.Text, Txt_Categoria.Text, Txt_TipoArt.Text, Txt_Proveedor.Text, "")

                If objDataSetEstilo.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSetEstilo.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Estilon.Text = objDataSetEstilo.Tables(0).Rows(0).Item("estilon").ToString
                    Txt_Estilof.Text = objDataSetEstilo.Tables(0).Rows(0).Item("estilof").ToString
                    Txt_Descripc.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descripc").ToString
                    Txt_Familia.Text = objDataSetEstilo.Tables(0).Rows(0).Item("familia").ToString
                    Txt_DescripFamilia.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descripfamilia").ToString
                    Txt_Linea.Text = objDataSetEstilo.Tables(0).Rows(0).Item("linea").ToString
                    Txt_DescripLinea.Text = ""
                    Txt_DescripLinea.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descriplinea").ToString
                    Txt_Proveedor.Text = objDataSetEstilo.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSetEstilo.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_TipoArt.Text = objDataSetEstilo.Tables(0).Rows(0).Item("tipoart").ToString
                    Txt_DescripTipoArt.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descriptipoart").ToString
                    Txt_Categoria.Text = objDataSetEstilo.Tables(0).Rows(0).Item("categoria").ToString
                    Txt_DescripCategoria.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descripcategoria").ToString
                    Txt_DescripL.Text = objDataSetEstilo.Tables(0).Rows(0).Item("descripl").ToString
                    If Sw_PedidoNuevo = False Then
                        Txt_Dsctopp.Text = objDataSetEstilo.Tables(0).Rows(0).Item("dsctopp").ToString
                        Txt_Dscto01.Text = objDataSetEstilo.Tables(0).Rows(0).Item("dscto01").ToString
                        Txt_Dscto02.Text = objDataSetEstilo.Tables(0).Rows(0).Item("dscto02").ToString
                        Txt_Dscto03.Text = objDataSetEstilo.Tables(0).Rows(0).Item("dscto03").ToString
                        Txt_Dscto04.Text = objDataSetEstilo.Tables(0).Rows(0).Item("dscto04").ToString
                        Txt_Dscto05.Text = objDataSetEstilo.Tables(0).Rows(0).Item("dscto05").ToString
                        Txt_Iva.Text = "16"
                    End If
                    Txt_Factor.Text = objDataSetEstilo.Tables(0).Rows(0).Item("factor").ToString


                    If objDataSetEstilo.Tables(0).Rows(0).Item("medida").ToString = "N" Then
                        Cbo_Medida.Text = "NÚMEROS"
                    ElseIf objDataSetEstilo.Tables(0).Rows(0).Item("medida").ToString = "L" Then
                        Cbo_Medida.Text = "LETRAS"
                    Else
                        Cbo_Medida.Text = "SIN MEDIDA"
                    End If

                    If objDataSetEstilo.Tables(0).Rows(0).Item("acepdevo").ToString = "S" Then
                        Cbo_AcepDevo.Text = "SI"
                    Else
                        Cbo_AcepDevo.Text = "NO"
                    End If

                    Txt_Resmin.Text = objDataSetEstilo.Tables(0).Rows(0).Item("resmin").ToString

                    Btn_Basicos.Enabled = True
                    Btn_Descontinuados.Enabled = True
                    Btn_Temporada.Enabled = True
                Else
                    'MsgBox("Estilo no encontrado.", MsgBoxStyle.Critical, "Aviso")
                    PBox.Image = Nothing
                    Txt_Estilof.Text = ""
                    Txt_Estilon.Text = ""
                    Txt_Descripc.Text = ""
                    Txt_ClasificacionDesc.Text = ""
                    Btn_Basicos.Enabled = False
                    Btn_Descontinuados.Enabled = False
                    Btn_Temporada.Enabled = False

                    'DGrid2.DataSource = Nothing
                    'DGrid3.DataSource = Nothing

                    'For i As Integer = 0 To DGrid2.Rows.Count - 2
                    '    DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
                    'Next

                    'DGrid2.Columns.Remove(DGrid2.Columns("Total"))

                    'For i As Integer = 0 To DGrid3.Columns.Count - 1
                    '    DGrid3.Columns.Remove(DGrid3.Columns(0))
                    'Next

                    Txt_Estilon.Select()
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Artículo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Artículo")
            ToolTip.SetToolTip(DGrid, "Detallado de corridas del Artículo")
            ToolTip.SetToolTip(Btn_NuevoF, "Nueva Foto")
            ToolTip.SetToolTip(Btn_EliminarF, "Eliminar Foto")
            ToolTip.SetToolTip(Btn_Ant, "Foto Anterior")
            ToolTip.SetToolTip(Btn_Sig, "Foto Siguiente")
            ToolTip.SetToolTip(Btn_AceptarF, "Guardar Foto")
            ToolTip.SetToolTip(Btn_Anterior, "Anterior")
            ToolTip.SetToolTip(Btn_Basicos, "Basicos")
            ToolTip.SetToolTip(Btn_Temporada, "Temporada")
            ToolTip.SetToolTip(Btn_Descontinuados, "Descontinuados")

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_Marca.Text = ""
            Txt_Estilon.Text = ""
            Txt_Estilof.Text = ""
            Txt_Descripc.Text = ""
            Txt_Familia.Text = ""
            Txt_Linea.Text = ""
            Txt_Proveedor.Text = ""
            Txt_TipoArt.Text = ""
            Txt_Categoria.Text = ""
            Txt_DescripL.Text = ""
            Cbo_Medida.Text = ""
            Cbo_AcepDevo.Text = ""
            Txt_Resmin.Text = ""
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Descripc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Descripc.GotFocus
        ''  Me.Txt_Descripc.SelectionStart = 0
        '' Me.Txt_Descripc.SelectionLength = Len(Me.Txt_Descripc.Text.Length)
        Txt_Descripc.SelectAll()
    End Sub

    Private Sub Txt_Descripc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Descripc.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Sub Txt_Descripc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Descripc.LostFocus
        Txt_DescripL.Text = Txt_Descripc.Text
    End Sub

    Private Sub Txt_Descripc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Descripc.TextChanged
        ''If Txt_Descripc.Text.Length = 30 Then
        ''    Txt_Familia.Focus()
        ''End If
    End Sub

    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus

        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")
                If Accion = 1 Then
                    objDataSet = objMySqlGral.usp_TraerFolio("EN", Txt_Marca.Text)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Estilon.Text = Val(objDataSet.Tables(0).Rows(0).Item("campo").ToString) + 1
                        Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
                    Else
                        Txt_Estilon.Text = "      1"
                    End If
                End If
                Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                    Dim objDataSet As Data.DataSet

                    objDataSet = objMarca.usp_TraerMarca(Txt_Marca.Text, "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Factor.Text = objDataSet.Tables(0).Rows(0).Item("factor").ToString
                    Else
                        Txt_Factor.Text = "0"
                    End If
                End Using
                If Txt_Marca.Text = "OZO" Or Txt_Marca.Text = "OZA" Or Txt_Marca.Text = "FFF" Then
                    Txt_Resmin.Text = "1"
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using



    End Sub

    Private Sub Txt_Estilon_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.GotFocus
        Txt_Estilon.SelectAll()
    End Sub

    Private Sub Txt_Estilon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilon.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Estilof_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.GotFocus
        Txt_Estilof.SelectAll()
    End Sub

    Private Sub Txt_Estilof_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Estilof.KeyDown

    End Sub

    Private Sub Txt_Estilof_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estilof.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Estilof_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilof.LostFocus
        If Accion <> 2 Then
            If Sw_PedidoNuevo = False Then
                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    Try
                        Dim estilof As String = ""
                        estilof = Replace(Txt_Estilof.Text, "-", "")

                        If Txt_Estilof.Text.Length = 0 Then Exit Sub
                        objDataSet = objMySqlGral.usp_TraerDescripcion("EN", Txt_Marca.Text, estilof)

                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            MsgBox("El estilo de fábrica '" & estilof & "' para a marca '" & Txt_Marca.Text & "' ya se encuentra registrado con el estilo nuestro '" & objDataSet.Tables(0).Rows(0).Item("campo").ToString & "'. Con la descripción '" & objDataSet.Tables(0).Rows(0).Item("descripc").ToString & ".", MsgBoxStyle.Information, "Aviso")

                        End If


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        End If
    End Sub

    Private Sub Txt_Estilof_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilof.TextChanged
        If Accion <> 2 Then
            Txt_Descripc.Text = Txt_Estilof.Text
        End If
        If Txt_Estilof.Text.Length = 14 Then
            Txt_Descripc.Focus()
        End If
    End Sub

    Private Sub Txt_Linea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.GotFocus
        Txt_Linea.SelectAll()
    End Sub

    Private Sub Txt_Linea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Linea.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Linea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Linea.LostFocus
        Try
            If Txt_Linea.Text.Length = 0 Then Exit Sub
            If Txt_Linea.Text.Trim.Length < 3 Then
                Txt_Linea.Text = pub_RellenarIzquierda(Txt_Linea.Text.Trim, 3)
            End If

            Call TxtLostfocus(Txt_Linea, Txt_DescripLinea, "L")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Linea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Linea.TextChanged
        If Txt_Linea.Text.Length = 3 Then
            Txt_Proveedor.Focus()
        End If
    End Sub

    Private Sub Txt_Proveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.GotFocus
        Txt_Proveedor.SelectAll()
    End Sub

    Private Sub Txt_Proveedor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Proveedor.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Proveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.LostFocus
        ''Try
        ''    If Txt_Proveedor.Text.Length = 0 Then Exit Sub

        ''    If Txt_Proveedor.Text.Trim.Length < 3 Then
        ''        Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
        ''    End If
        ''    Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
        ''Catch ExceptionErr As Exception
        ''    MessageBox.Show(ExceptionErr.Message.ToString)
        ''End Try
        'mreyes 09/Marzo/2012 07:13 p.m.

        Try
BRINCO:
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If

            Using objProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                objDataSet = objProveedores.usp_TraerProveedor(Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                        If MsgBox("El proveedor se encuentra dado de BAJA.", MsgBoxStyle.Exclamation, "Datos Proveedor") Then
                            Txt_Proveedor.Clear()
                            Exit Sub
                        End If
                    End If

                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    If Sw_PedidoNuevo = False Then
                        Txt_Dsctopp.Text = Val(objDataSet.Tables(0).Rows(0).Item("dsctopp"))
                        Txt_Diaspp.Text = Val(objDataSet.Tables(0).Rows(0).Item("diaspp"))
                        Txt_Dscto01.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto01"))
                        Txt_Dscto02.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto02"))
                        Txt_Dscto03.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto03"))
                        Txt_Dscto04.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto04"))
                        Txt_Dscto05.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto05"))
                    End If

                Else
                    Dim myForm As New frmConsulta
                    myForm.Tipo = "P"
                    myForm.ShowDialog()
                    Txt_Proveedor.Text = myForm.Campo

                    Txt_Raz_Soc.Text = myForm.Campo1
                    If Txt_Proveedor.Text.Length = 0 Then
                        Txt_Proveedor.Focus()
                    Else
                        GoTo BRINCO
                    End If
                End If
            End Using


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_TipoArt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.GotFocus
        Txt_TipoArt.SelectAll()
    End Sub

    Private Sub Txt_TipoArt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TipoArt.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_TipoArt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.LostFocus
        'mreyes 23/Febrero/2012 12:07 p.m.
        Try
            If Txt_TipoArt.Text.Length = 0 Then Exit Sub
            Call TxtLostfocus(Txt_TipoArt, Txt_DescripTipoArt, "TA")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub Txt_Categoria_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.GotFocus
        Txt_Categoria.SelectAll()
    End Sub

    Private Sub Txt_Categoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Categoria.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_DescripL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_DescripL.GotFocus
        Txt_DescripL.SelectAll()
    End Sub

    Private Sub Txt_DescripL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_DescripL.KeyPress
        e.KeyChar = UCase(e.KeyChar)

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Categoria_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Categoria.LostFocus

        Try
            If Txt_Categoria.Text.Length = 0 Then Exit Sub

            If Txt_Categoria.Text.Trim.Length < 3 Then
                Txt_Categoria.Text = pub_RellenarIzquierda(Txt_Categoria.Text.Trim, 3)
            End If
            Call TxtLostfocus(Txt_Categoria, Txt_DescripCategoria, "C")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Resmin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Resmin.GotFocus
        Txt_Resmin.SelectAll()
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

    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged
        If Txt_Proveedor.Text.Length = 3 Then
            Txt_TipoArt.Focus()
        End If
    End Sub

    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
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
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True

                    Pnl_Edicion.Enabled = False

                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Marca.BackColor = TextboxBackColor
                    Txt_Estilon.BackColor = TextboxBackColor
                    Txt_Estilof.BackColor = TextboxBackColor
                    Txt_Descripc.BackColor = TextboxBackColor
                    Txt_Familia.BackColor = TextboxBackColor
                    Txt_Linea.BackColor = TextboxBackColor
                    Txt_Proveedor.BackColor = TextboxBackColor
                    Txt_TipoArt.BackColor = TextboxBackColor
                    Txt_Categoria.BackColor = TextboxBackColor
                    Txt_DescripL.BackColor = TextboxBackColor
                    Cbo_Medida.BackColor = TextboxBackColor
                    Cbo_AcepDevo.BackColor = TextboxBackColor
                    Txt_Resmin.BackColor = TextboxBackColor

                    ' no dar de alta fotos 

                    Btn_AceptarF.Enabled = False
                    Btn_EliminarF.Enabled = False
                    Btn_NuevoF.Enabled = False

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    Pnl_Grid.Enabled = True
                    Pnl_Grid.Enabled = True

                    Txt_Estilof.Enabled = False
                    Txt_Descripc.Enabled = False
                    Txt_Familia.Enabled = False
                    Txt_DescripFamilia.Enabled = False
                    Txt_Linea.Enabled = False
                    Txt_DescripLinea.Enabled = False
                    Txt_Proveedor.Enabled = False
                    Txt_Raz_Soc.Enabled = False
                    Txt_TipoArt.Enabled = False
                    Txt_DescripTipoArt.Enabled = False
                    Txt_Categoria.Enabled = False
                    Txt_DescripCategoria.Enabled = False
                    Txt_DescripL.Enabled = False

                    Txt_Dsctopp.Enabled = False
                    Txt_Dscto01.Enabled = False
                    Txt_Dscto02.Enabled = False
                    Txt_Dscto03.Enabled = False
                    Txt_Dscto04.Enabled = False
                    Txt_Dscto05.Enabled = False
                    Txt_Iva.Enabled = False
                    Txt_Factor.Enabled = False
                    Cbo_Medida.Enabled = False
                    Cbo_AcepDevo.Enabled = False
                    Txt_Resmin.Enabled = False

                    If Accion = 1 Then
                        If Sw_PedidoNuevo = True Then
                            Txt_Descripc.Focus()
                            'Txt_Estilon.Enabled = False
                            'Txt_Marca.Enabled = False
                            Txt_Estilon.BackColor = TextboxBackColor
                            Txt_Marca.BackColor = TextboxBackColor
                            Txt_Estilof.Enabled = True
                            Txt_Estilof.BackColor = TextboxBackColor

                        Else
                            Txt_Marca.Focus()
                        End If

                    ElseIf Accion = 2 Then
                        Txt_Descripc.Focus()
                        'Txt_Estilon.Enabled = False
                        'Txt_Marca.Enabled = False
                        Txt_Estilon.BackColor = TextboxBackColor
                        Txt_Marca.BackColor = TextboxBackColor
                        Txt_Estilof.Enabled = True
                        Txt_Estilof.BackColor = TextboxBackColor
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Accion = 2
        Call Edicion()
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    'Me.Dispose()
                    Me.Close()
                End If
            Else

                Me.Close()
                Me.Dispose()
            End If
            GLB_CATESILOCANCELADO = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress


        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Function Eliminar_Medida(ByVal Marca As String, ByVal Estilon As String, ByVal corrida As String) As Boolean
        'mreyes 23/Febrero/2012 03:47 p.m.
        'marca, estilo, medida, corrida
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                Eliminar_Medida = objCatalogoEstilos.usp_EliminarMedida(Marca, Estilon, corrida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Pnl_Foto_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Foto.Paint

    End Sub

    Private Sub CargarFotoArticulo()
        'mreyes 02/Marzo/2012 04:12 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"

            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
                Txt_NoFoto.Text = NoFoto
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                Else
                    PBox.Image = Nothing
                End If

                For i As Integer = 0 To 9
                    Txt_NoFoto.Text = i
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    End If
                Next

                Txt_NoFoto.Text = 1
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Sig.Click
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            If Val(Txt_NoFoto.Text) < 9 Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) + 1
            End If
            If TraerFoto(Txt_NoFoto.Text) = False Then
                Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function TraerFoto(ByVal NoFoto As String) As Boolean
        'mreyes 02/Marzo/2012 04:57 p.m.
        Try
            TraerFoto = False
            Dim Archivo As String = ""
            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, NoFoto)
                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    TraerFoto = True
                    Exit Function
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub Btn_Ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Ant.Click
        Try
            If Val(Txt_NoFoto.Text) <> 1 Then
                If Val(Txt_NoFoto.Text) <= 9 And Val(Txt_NoFoto.Text > 0) Then
                    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                End If
            End If
            If TraerFoto(Txt_NoFoto.Text) = False Then
                If Txt_NoFoto.Text <> 1 Then
                    Txt_NoFoto.Text = Val(Txt_NoFoto.Text) - 1
                End If

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_AceptarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AceptarF.Click
        'mreyes 02/Marzo/2012 05:32 p.m.
        Try
            Dim RutaOrigen As String = ""
            Dim RutaDestino As String = ""

            '' BUSCAR LA IMAGEN... SI LA ENCUENTRA PREGUNTAR PARA EDITARLA SINO DARLA DE ALTA CON UN NUMERO MAS 

            If MsgBox("Esta seguro de querer guardar la imagen para el estilo.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub


            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                RutaOrigen = Txt_Ruta.Text
                RutaDestino = ""
                RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, Txt_NoFoto.Text)

                If objIO.pub_ExisteArchivo(RutaDestino) = True Then
                    '' ya existe 
                    If MsgBox("Esta seguro de querer modificar la foto '" & Txt_NoFoto.Text & "' del estilo '" & Txt_Estilon.Text & " para la marca '" & Txt_Marca.Text & "'?. En caso contrario se registrará como nueva.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                        ''sobreescribir la que ya existe 
                        objIO.pub_RenombrarArchivo(RutaDestino, objIO.pub_NombreArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, "99")))
                        objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, "99"))
                        CambiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(2) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    Else
                        RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig)
                        CambiarArchivo(RutaOrigen, RutaDestino)
                        If Inserta_ArtFotos(1) = False Then
                            MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                        End If
                    End If
                Else
                    RutaDestino = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig)
                    CambiarArchivo(RutaOrigen, RutaDestino)
                    If Inserta_ArtFotos(1) = False Then
                        MsgBox("No se pudo grabar correctamente la imagen.", MsgBoxStyle.Critical, "Aviso")
                    End If
                End If
                RutaOrigen = Txt_Ruta.Text



                ' objIO.pub_CopiarArchivo(RutaOrigen, RutaDestino)
            End Using

            MsgBox("Archivo correctamente grabado en la ruta '" & RutaDestino & "'", MsgBoxStyle.Information, "Confirmación")
            ''  Btn_Aceptar.Enabled = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function BuscarImagenSig() As String
        'mreyes 02/Marzo/2012 06:04 p.m.
        Try
            Dim Archivo As String = ""
            BuscarImagenSig = Txt_NoFoto.Text
            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                For i As Integer = Val(Txt_NoFoto.Text) To 9

                    Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, i)
                    If objIO.pub_ExisteArchivo(Archivo) = False Then

                        BuscarImagenSig = i
                        Txt_NoFoto.Text = BuscarImagenSig
                        Exit Function
                    End If
                Next
            End Using
            BuscarImagenSig = 1
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Sub CambiarArchivo(ByVal RutaOrigen As String, ByVal RutaDestino As String)
        'mreyes 03/Marzo/2012 09:17 a.m.
        ' Extraer primero el tipo de extención para agrandar la imagen
        'InStrRev()
        Dim Extension As String = ""
        Try
            Dim g As GBITMAPLib.GBitmap
            Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                Extension = objIO.pub_ExtensionArchivo(RutaOrigen)
                g = New GBITMAPLib.GBitmap
                If UCase(Extension) = ".BMP" Then
                    g.LoadFileBmp(RutaOrigen)
                Else
                    g.LoadFileJpg(RutaOrigen, 360)
                End If
                'g.Resize(320, 240)
                g.SaveFileJpg(RutaDestino)
                g = Nothing
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_NuevoF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevoF.Click
        'mreyes 02/Marzo/2012 05:38 p.m.
        Try
            OpenFileDialog.Filter = "img files (*.jpg)|*.jpg|All files (*.*)|*.*"
            OpenFileDialog.FileName = ""
            OpenFileDialog.ShowDialog()
            If OpenFileDialog.FileName = "" Then Exit Sub
            PBox.Image = New System.Drawing.Bitmap(OpenFileDialog.FileName)
            Txt_Ruta.Text = OpenFileDialog.FileName
            If Txt_Ruta.Text.Length > 0 Then
                Btn_AceptarF.Enabled = True

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click

    End Sub

    Private Sub PBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PBox.DoubleClick
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = Txt_Estilon.Text
            myForm.Txt_Marca.Text = Txt_Marca.Text
            myForm.Txt_NoFoto.Text = Txt_NoFoto.Text
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Btn_EliminarF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EliminarF.Click
        Try
            If MsgBox("Esta seguro de querer eliminar la imagen.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.Yes Then
                Using objIO As New BCL.BCLio(Glb_ConStringCipSis)
                    PBox.Image = Nothing
                    objIO.pub_EliminarArchivo(objIO.pub_ArmarNombreFotoEstilo(Glb_RutaArchivoFotos, Txt_Marca.Text, Txt_Estilon.Text, BuscarImagenSig))
                End Using
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_ArtFotos(ByVal Opcion As Integer) As Boolean
        'mreyes 26/Marzo/2012 04:10 p.m.

        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogoEstilos.Inserta_ArtFotos  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = (Txt_Estilon.Text)
                objDataRow.Item("fotoart") = Txt_NoFoto.Text
                objDataRow.Item("fecha") = Format(Now.Date, "yyyyMMdd")
                objDataRow.Item("hora") = Format(Now, "hh:mm:ss")
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogoEstilos.usp_Captura_ArtFotos(Opcion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Artículo")
                Else
                    Inserta_ArtFotos = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Txt_Familia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Familia.TextChanged
        If Txt_Familia.Text.Length = 3 Then
            Txt_Linea.Focus()
        End If
    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        If Txt_Marca.Text.Length = 3 Then
            Txt_Estilof.Focus()
        End If
    End Sub

    Private Sub Txt_Estilon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Estilon.TextChanged

    End Sub

    Private Sub Txt_TipoArt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_TipoArt.TextChanged
        If Txt_TipoArt.Text.Length = 1 Then
            Txt_Categoria.Focus()
        End If
    End Sub

    Private Sub Txt_Categoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Categoria.TextChanged
        If Txt_Categoria.Text.Length = 3 Then
            Txt_DescripL.Focus()
        End If
    End Sub

    Private Function CalcularTipoCrr(ByVal Corrida As String, ByVal TipoCrr As String, ByVal Margen As Decimal) As String
        'mreyes 13/Abril/2012 11:47 a.m.
        Using objPedidos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet

                CalcularTipoCrr = ""

                Dim pTipo As String = ""
                Dim ptcr As String = ""
                objDataSet = objPedidos.usp_TraerClasifMargen
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If "7" <= TipoCrr And TipoCrr <= "9" Then
                            pTipo = "7"
                        ElseIf "4" <= TipoCrr And TipoCrr <= "6" Then
                            pTipo = "4"
                        ElseIf TipoCrr = "" Then
                            pTipo = "7"
                        Else
                            pTipo = "1"
                        End If
                        ptcr = Trim(Str(pTipo + (3 - Val(objDataSet.Tables(0).Rows(0).Item("orden")))))
                        If Margen >= objDataSet.Tables(0).Rows(0).Item("porcent") And ptcr <> TipoCrr Then
                            CalcularTipoCrr = ptcr
                            Exit Function
                        End If
                    Next
                End If




            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
                CalcularTipoCrr = ""
            End Try
        End Using
    End Function

    Private Sub CalcularMargen1(ByVal Corrida As String, ByVal PComp As Decimal, ByVal Precio As Decimal, ByVal TipoCrr As String)
        'mreyes 13/Abril/2012 09:48 a.m.
        Using objPedidos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Costo As Decimal = 0
                Dim Porcent As Decimal = 0
                Dim Fecha As Date = Format(Now.Date, "yyyy-MM-dd")
                Dim Pporce As Decimal = 0
                Dim pmgn As Decimal = 0
                objDataSet = objPedidos.usp_TraerCostosxMarca(Txt_Marca.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = Costo * (100 + objDataSet.Tables(0).Rows(0).Item("porcent")) / 100
                    Next
                End If

                objDataSet = objPedidos.usp_TraerCostosGrales(Txt_Marca.Text)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Costo = Costo * (100 + objDataSet.Tables(0).Rows(0).Item("porcent")) / 100
                    Next
                End If

                'CALCULO DEL PRECIO TOMANDO BOLETINES DE OFERTA VIGENTES'
                objDataSet = objPedidos.usp_TraerPorcenBoletin(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                '' POR TODOS LOS BOLETINES 

                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "M")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")

                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "F")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "L")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "P")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "T")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenBoletinNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "C")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                ''''CALCULO DEL PRECIO TOMANDO DINERO ELECTRONICO 

                objDataSet = objPedidos.usp_TraerPorcenDinero(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "M")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")

                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "F")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "L")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "P")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "T")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If
                objDataSet = objPedidos.usp_TraerPorcenDineroNivel(Txt_Marca.Text, Txt_Estilon.Text, Corrida, Fecha, "C")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("porcent") > Pporce Then
                        Pporce = objDataSet.Tables(0).Rows(0).Item("porcent")
                    End If
                End If

                PComp = Costo * PComp / 100


                If Pporce > 0 Then
                    Precio = (Precio * (1 - Pporce / 100))
                End If
                If Precio > 0 And Precio >= Costo Then

                    pmgn = (100 * (1 - Costo / Precio))
                Else
                    pmgn = 0
                End If
                Dim pTipo As String = ""
                Dim ptcr As String = ""
                objDataSet = objPedidos.usp_TraerClasifMargen
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        If "7" <= TipoCrr And TipoCrr <= "9" Then
                            pTipo = "7"
                        ElseIf "4" <= TipoCrr And TipoCrr <= "6" Then
                            pTipo = "4"
                        Else
                            pTipo = "1"
                        End If
                    Next
                End If

                ptcr = (Str(pTipo + (3 - Val(objDataSet.Tables(0).Rows(0).Item("orden")))))
                If pmgn >= objDataSet.Tables(0).Rows(0).Item("porcent") And ptcr <> TipoCrr Then

                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub usp_TraerEstiloN()
        Try
            Using objCatalogoEstilosC As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objCatalogoEstilosC.usp_TraerEstiloN(Txt_Marca.Text, Txt_Estilon.Text)
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Anterior.Click
        'Tony Garcia - 21/Diciembre/2012 - 9:40 a.m.
        Try
            If intPosicion <> 0 Then
                intPosicion -= 1
                If intPosicion = 0 Then
                    intPosicion = objDataSetFiltro.Tables(0).Rows.Count - 1
                End If
            ElseIf intPosicion = 0 Then
                intPosicion = objDataSetFiltro.Tables(0).Rows.Count - 1
            End If
           

            DGrid2.DataSource = Nothing
            DGrid3a.DataSource = Nothing

            For i As Integer = 0 To DGrid2.Rows.Count - 2
                DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
            Next

            DGrid2.Columns.Remove(DGrid2.Columns("Total"))

            For i As Integer = 0 To DGrid3a.Columns.Count - 1
                DGrid3a.Columns.Remove(DGrid3a.Columns(0))
            Next

            If blnBasicos = True Or blnDescontinuados = True Or blnSinClasif = True Or blnTemporada = False Then
                Txt_Marca.Text = objDataSetFiltro.Tables(0).Rows(intPosicion).Item("marca").ToString
                Txt_Estilon.Text = objDataSetFiltro.Tables(0).Rows(intPosicion).Item("estilon").ToString
            End If

            Call usp_TraerEstiloN()
            If Val(Txt_Estilon.Text) > 0 Then
                If blnBasicos = False AndAlso blnDescontinuados = False AndAlso blnSinClasif = False AndAlso blnTemporada = False Then
                    Txt_Estilon.Text = Val(Txt_Estilon.Text) - 1
                End If
                'Txt_Estilof.Text = ""
                'Txt_Estilof.Text = ""
                'Txt_Familia.Text = ""
                'Txt_Linea.Text = ""
                'Txt_Categoria.Text = ""
                'Txt_TipoArt.Text = ""
                'Txt_Proveedor.Text = ""
                'Txt_DescripLinea.Text = ""
                Call Txt_Estilon_LostFocus(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Siguiente.Click
        'Tony Garcia - 21/Diciembre/2012 - 9:45 a.m.

        Try

            'If intPosicion <> 0 Then
            '    intPosicion -= 1
            '    If intPosicion = 0 Then
            '        intPosicion = objDataSetFiltro.Tables(0).Rows.Count - 1
            '    End If
            'ElseIf intPosicion = 0 Then
            '    intPosicion = objDataSetFiltro.Tables(0).Rows.Count - 1
            'End If


            If intPosicion = intTotalRows Then
                intPosicion = 0
            Else
                intPosicion += 1
            End If

            DGrid2.DataSource = Nothing
            DGrid3a.DataSource = Nothing

            For i As Integer = 0 To DGrid2.Rows.Count - 2
                DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
            Next

            DGrid2.Columns.Remove(DGrid2.Columns("Total"))

            For i As Integer = 0 To DGrid3a.Columns.Count - 1
                DGrid3a.Columns.Remove(DGrid3a.Columns(0))
            Next


            If blnBasicos = True Or blnDescontinuados = True Or blnSinClasif = True Or blnTemporada = True Then
                Txt_Marca.Text = objDataSetFiltro.Tables(0).Rows(intPosicion).Item("marca").ToString
                Txt_Estilon.Text = objDataSetFiltro.Tables(0).Rows(intPosicion).Item("estilon").ToString
            End If

            Call usp_TraerEstiloN()
            If Val(Txt_Estilon.Text) > 0 Then
                If blnBasicos = False AndAlso blnDescontinuados = False AndAlso blnSinClasif = False AndAlso blnTemporada = False Then
                    Txt_Estilon.Text = Val(Txt_Estilon.Text) + 1
                End If

                Call LimpiaComponentes()
                'Txt_Estilof.Text = ""
                'Txt_Familia.Text = ""
                'Txt_Linea.Text = ""
                'Txt_Categoria.Text = ""
                'Txt_TipoArt.Text = ""
                'Txt_Proveedor.Text = ""
                'Txt_DescripLinea.Text = ""
                Call Txt_Estilon_LostFocus(sender, e)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiaComponentes()
        'Txt_Marca.Text = ""
        Txt_DescripMarca.Text = ""
        'Txt_Estilon.Text = ""
        Txt_Estilof.Text = ""
        Txt_Descripc.Text = ""
        Txt_Familia.Text = ""
        Txt_DescripFamilia.Text = ""
        Txt_Linea.Text = ""
        Txt_DescripLinea.Text = ""
        Txt_Proveedor.Text = ""
        Txt_Raz_Soc.Text = ""
        Txt_TipoArt.Text = ""
        Txt_DescripTipoArt.Text = ""
        Txt_Categoria.Text = ""
        Txt_DescripCategoria.Text = ""
        Txt_DescripL.Text = ""

        Txt_Dsctopp.Text = ""
        Txt_Dscto01.Text = ""
        Txt_Dscto02.Text = ""
        Txt_Dscto03.Text = ""
        Txt_Dscto04.Text = ""
        Txt_Dscto05.Text = ""
        Txt_Iva.Text = "16"

        Txt_Factor.Text = ""
        Cbo_Medida.Text = ""

     
        Cbo_AcepDevo.Text = ""


        Txt_Resmin.Text = ""
    End Sub

 

    Private Sub Btn_Basicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Basicos.Click
        'Tony Garcia - 21/Diciembre/2012 - 9:31 a.m.
        Try
            If MsgBox("Desea guardar este Articulo en la categoría de Basicos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim Marca As String = Txt_Marca.Text
            Dim Estilon As String = Txt_Estilon.Text
            Dim Opcion As Integer = 0

            Using objArtCategoria As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objArtCategoria.usp_TraerClasificacionEstiloUp(Marca, Estilon)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Opcion = 2
                Else
                    Opcion = 1
                End If
            End Using

            Using objArtCategoria As New BCL.BCLPedidos(GLB_ConStringCipSis)
                objArtCategoria.usp_CapturaClasifEstilos(Opcion, Marca, Estilon, "B", GLB_Usuario)
                MessageBox.Show("El registro se guardó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            Call usp_TraerClasificacionEst()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Temporada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Temporada.Click
        'Tony Garcia - 21/Diciembre/2012 - 9:31 a.m.
        Try
            If MsgBox("Desea guardar este Articulo en la categoría de Temporada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim Marca As String = Txt_Marca.Text
            Dim Estilon As String = Txt_Estilon.Text
            Dim Opcion As Integer = 0

            Using objArtCategoria As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objArtCategoria.usp_TraerClasificacionEstiloUp(Marca, Estilon)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Opcion = 2
                Else
                    Opcion = 1
                End If
            End Using

            Using objArtCategoria As New BCL.BCLPedidos(GLB_ConStringCipSis)
                objArtCategoria.usp_CapturaClasifEstilos(Opcion, Marca, Estilon, "T", GLB_Usuario)
                MessageBox.Show("El registro se guardó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            Call usp_TraerClasificacionEst()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Descontinuados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Descontinuados.Click
        'Tony Garcia - 21/Diciembre/2012 - 9:31 a.m.
        Try
            If MsgBox("Desea guardar este Articulo en la categoría de Descontinuados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim Marca As String = Txt_Marca.Text
            Dim Estilon As String = Txt_Estilon.Text
            Dim Opcion As Integer = 0

            Using objArtCategoria As New BCL.BCLCatalogoEstilosClasif(GLB_ConStringCipSis)
                objDataSet = objArtCategoria.usp_TraerClasificacionEstiloUp(Marca, Estilon)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Opcion = 2
                Else
                    Opcion = 1
                End If
            End Using

            Using objArtCategoria As New BCL.BCLPedidos(GLB_ConStringCipSis)
                objArtCategoria.usp_CapturaClasifEstilos(Opcion, Marca, Estilon, "D", GLB_Usuario)
                MessageBox.Show("El registro se guardó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            Call usp_TraerClasificacionEst()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Estilon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Estilon.LostFocus
        Call LimpiaComponentes()
        Txt_Estilon.Text = Txt_Estilon.Text.PadLeft(7)
        Call usp_TraerEstilo()
        Call usp_TraerCorrida(Txt_Estilon.Text)
        Call CargarFotoArticulo()
        Call usp_TraerClasificacionEst()
        Call RellendaGridsInfoArticulo()
        Txt_Estilof.Enabled = False

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Chk_Basicos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Basicos.CheckedChanged
        Try
            If Chk_Basicos.Checked = True Then
                ArtCatB = "B"
                Chk_Temporada.Checked = False
                Chk_Descontinuados.Checked = False
                Chk_SinClasif.Checked = False
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
                blnBasicos = True
                blnDescontinuados = False
                blnSinClasif = False
                blnTemporada = False
                'PBox.Image = Nothing
                'PBox.Visible = False

                DGrid2.DataSource = Nothing
                DGrid3a.DataSource = Nothing

                For i As Integer = 0 To DGrid2.Rows.Count - 2
                    DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
                Next

                DGrid2.Columns.Remove(DGrid2.Columns("Total"))

                For i As Integer = 0 To DGrid3a.Columns.Count - 1
                    DGrid3a.Columns.Remove(DGrid3a.Columns(0))
                Next

                Using objCatalogoEstilosC As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    objDataSetFiltro = objCatalogoEstilosC.usp_PpalClasificacionEstilos("", "", "", _
                                                                    "", "", "", "", "", ArtCatB, _
                                                                    FechaInib, FechaFinb)
                End Using

                If objDataSetFiltro.Tables(0).Rows.Count > 0 Then
                    intPosicion = 0
                    intTotalRows = objDataSetFiltro.Tables(0).Rows.Count - 1
                    Txt_Marca.Text = objDataSetFiltro.Tables(0).Rows(0).Item("marca").ToString
                    Txt_Estilon.Text = objDataSetFiltro.Tables(0).Rows(0).Item("estilon").ToString
                End If

                Call usp_TraerCorrida(Txt_Estilon.Text)
                Call CargarFotoArticulo()
                Call usp_TraerClasificacionEst()
                Call RellendaGridsInfoArticulo()
                Txt_Estilof.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        
    End Sub

    Private Sub Chk_Temporada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Temporada.CheckedChanged
        Try
            If Chk_Temporada.Checked = True Then
                ArtCatB = "T"
                Chk_Basicos.Checked = False
                Chk_Descontinuados.Checked = False
                Chk_SinClasif.Checked = False
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
                blnBasicos = False
                blnDescontinuados = False
                blnSinClasif = False
                blnTemporada = True
                'PBox.Image = Nothing
                'PBox.Visible = False

                DGrid2.DataSource = Nothing
                DGrid3a.DataSource = Nothing

                For i As Integer = 0 To DGrid2.Rows.Count - 2
                    DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
                Next

                DGrid2.Columns.Remove(DGrid2.Columns("Total"))

                For i As Integer = 0 To DGrid3a.Columns.Count - 1
                    DGrid3a.Columns.Remove(DGrid3a.Columns(0))
                Next

                Using objCatalogoEstilosC As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    objDataSetFiltro = objCatalogoEstilosC.usp_PpalClasificacionEstilos("", "", "", _
                                                                    "", "", "", "", "", ArtCatB, _
                                                                    FechaInib, FechaFinb)
                End Using


                If objDataSetFiltro.Tables(0).Rows.Count > 0 Then
                    intPosicion = 0
                    intTotalRows = objDataSetFiltro.Tables(0).Rows.Count - 1
                    Txt_Marca.Text = objDataSetFiltro.Tables(0).Rows(0).Item("marca").ToString
                    Txt_Estilon.Text = objDataSetFiltro.Tables(0).Rows(0).Item("estilon").ToString
                End If

                Call usp_TraerCorrida(Txt_Estilon.Text)
                Call CargarFotoArticulo()
                Call usp_TraerClasificacionEst()
                Call RellendaGridsInfoArticulo()
                Txt_Estilof.Enabled = False

            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        
    End Sub

    Private Sub Chk_Descontinuados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Descontinuados.CheckedChanged
        Try
            If Chk_Descontinuados.Checked = True Then
                ArtCatB = "D"
                Chk_Temporada.Checked = False
                Chk_Basicos.Checked = False
                Chk_SinClasif.Checked = False
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
                blnBasicos = False
                blnDescontinuados = True
                blnSinClasif = False
                blnTemporada = False
                'PBox.Image = Nothing
                'PBox.Visible = False

                DGrid2.DataSource = Nothing
                DGrid3a.DataSource = Nothing

                For i As Integer = 0 To DGrid2.Rows.Count - 2
                    DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
                Next

                DGrid2.Columns.Remove(DGrid2.Columns("Total"))

                For i As Integer = 0 To DGrid3a.Columns.Count - 1
                    DGrid3a.Columns.Remove(DGrid3a.Columns(0))
                Next

                Using objCatalogoEstilosC As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    objDataSetFiltro = objCatalogoEstilosC.usp_PpalClasificacionEstilos("", "", "", _
                                                                    "", "", "", "", "", ArtCatB, _
                                                                    FechaInib, FechaFinb)
                End Using

                If objDataSetFiltro.Tables(0).Rows.Count > 0 Then
                    intPosicion = 0
                    intTotalRows = objDataSetFiltro.Tables(0).Rows.Count - 1
                    Txt_Marca.Text = objDataSetFiltro.Tables(0).Rows(0).Item("marca").ToString
                    Txt_Estilon.Text = objDataSetFiltro.Tables(0).Rows(0).Item("estilon").ToString
                End If

                Call usp_TraerCorrida(Txt_Estilon.Text)
                Call CargarFotoArticulo()
                Call usp_TraerClasificacionEst()
                Call RellendaGridsInfoArticulo()
                Txt_Estilof.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
        
    End Sub

    Private Sub Chk_SinClasif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SinClasif.CheckedChanged
        Try
            If Chk_SinClasif.Checked = True Then
                ArtCatB = "S"
                Chk_Temporada.Checked = False
                Chk_Descontinuados.Checked = False
                Chk_Basicos.Checked = False
                FechaInib = "1900-01-01"
                FechaFinb = "1900-01-01"
                blnBasicos = False
                blnDescontinuados = False
                blnSinClasif = True
                blnTemporada = False
                'PBox.Image = Nothing
                'PBox.Visible = False

                DGrid2.DataSource = Nothing
                DGrid3a.DataSource = Nothing

                For i As Integer = 0 To DGrid2.Rows.Count - 2
                    DGrid2.Rows.Remove(DGrid2.Rows(DGrid2.Rows.Count - 2))
                Next

                DGrid2.Columns.Remove(DGrid2.Columns("Total"))

                For i As Integer = 0 To DGrid3a.Columns.Count - 1
                    DGrid3a.Columns.Remove(DGrid3a.Columns(0))
                Next

                Using objCatalogoEstilosC As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    objDataSetFiltro = objCatalogoEstilosC.usp_PpalClasificacionEstilos("", "", "", _
                                                                    "", "", "", "", "", ArtCatB, _
                                                                    FechaInib, FechaFinb)
                End Using

                If objDataSetFiltro.Tables(0).Rows.Count > 0 Then
                    intPosicion = 0
                    intTotalRows = objDataSetFiltro.Tables(0).Rows.Count - 1
                    Txt_Marca.Text = objDataSetFiltro.Tables(0).Rows(0).Item("marca").ToString
                    Txt_Estilon.Text = objDataSetFiltro.Tables(0).Rows(0).Item("estilon").ToString
                End If

                Call usp_TraerCorrida(Txt_Estilon.Text)
                Call CargarFotoArticulo()
                Call usp_TraerClasificacionEst()
                Call RellendaGridsInfoArticulo()
                Txt_Estilof.Enabled = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class
