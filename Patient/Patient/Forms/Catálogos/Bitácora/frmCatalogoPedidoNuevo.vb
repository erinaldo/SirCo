Public Class frmCatalogoPedidoNuevo

    'mreyes 12/Febrero/2012 07:17 p.m.
    'Forma para dar de alta un pedido nuevo, resurtido o una factura.
    Dim Entregavence As Date = "1900-01-01"
    Dim Sw_FechaVenceFactura As Boolean = False

    Dim FechaEntregaMax As Date = "1900-01-01"
    Dim Colores As Integer = 0
    Dim Sw_NoArchivo As Boolean = True
    Dim Sql As String
    Public Accion As Integer  '' 1  = nuevo, 2 = edicion , 3 = eliminar , 4 = consultar 
    Public Sw_Bitacora As Boolean = False
    Public Sw_Registro As Boolean = False
    Public Sw_PedidoNuevo As Boolean = True
    Public Sw_Factura As Boolean = False
    Public Sw_Devolucion As Boolean = False
    Public Sw_Cancelaciones As Boolean = False
    Public Sw_SoloPasoPDF As Boolean = False
    Public Sw_SoloPasoIMPRIMECEDIS As Boolean = False
    Public Sw_Serie As Boolean
    Public Sw_SoloPasoAUT As Boolean = False
    Public Sw_FacturaNueva As Boolean = False '' CUANO SE VA A REGISTRAR UNA FACTURA NUEVA, O EDITAR O ASI.
    Public Sw_EditarEstilo As Boolean = False
    Public Sw_Remision As Boolean = False

    Dim sw_cambioceros As Boolean = False

    Private Sw_PedidoMano As Boolean = False

    Private objDataSet As Data.DataSet

    Dim DescripMarca As String
    Dim DescripDivision As String
    Dim DescripDepto As String

    Dim DescripFamilia As String
    Dim DescripLinea As String

    Dim DescripLinea1 As String
    Dim DescripLinea2 As String
    Dim DescripLinea3 As String
    Dim DescripLinea4 As String
    Dim DescripLinea5 As String
    Dim DescripLinea6 As String


    '' Variables de grid 
    Dim CorridaAnterior As String
    Dim IntervaloAnterior As String
    Dim MedIniAnterior As Integer
    Dim MedFinAnterior As Integer

    Dim Cont As Integer = 0
    Dim TextoColumna(14) As String
    Dim ImpOrdeComp(50) As String
    Dim SucOrdeComp(50) As String
    Dim MedidaEstilo As String = ""
    Dim Sw_EnviarCorreo As Boolean = False
    Dim Sw_ImprimeMas14 As Boolean = False
    Dim RutaArchivoCorreo As String = ""

    Dim ResurtSN As String = "N"
    Dim ColumnaRM As Integer = 23
    Dim MarcaFOTO As String = ""
    Dim EstiloNFOTO As String = ""
    Dim Sw_Validar As Boolean = False

    Dim CEscritoAnt As Integer = 0
    Dim CEscrito As Integer
    Dim Sw_ProvDif As Boolean = False

    Dim SucSelect(50) As String
    Dim IntSelect As Integer = 0


    Dim SucSelectPed(50) As String
    Dim PedSelectPed(50) As String
    Dim IntSelectPed As Integer = 0


    Dim Sw_Costos As Boolean = True
    'Bultos
    Dim NoBultos As Integer = 0

    Public IdDivision As Integer = 0
    Public IdDepto As Integer = 0
    Public IdFamilia As Integer = 0
    Public IdLinea As Integer = 0
    Public IdL1 As Integer = 0
    Public IdL2 As Integer = 0
    Public IdL3 As Integer = 0
    Public IdL4 As Integer = 0
    Public IdL5 As Integer = 0
    Public IdL6 As Integer = 0
    Public FolioB As String = ""
    'Devoluciones
    Dim IdFolioNotaC As Integer = 0
    Dim ImpNotaC As Decimal = 0.0
    Dim IVANotaC As Decimal = 0.0
    Dim ImpTotalNotaC As Decimal = 0.0
    Dim DevoProvC As String = ""


    Private izquierda As Integer = 0
    Private alto As Integer = 0
    Private IdProveedorB As Integer = 0

    Dim Sw_Load As Boolean = False

    Private Sub CalculaImportesIVA()
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerDevProvImporte(Txt_Sucursal.Text, Txt_NoBulto.Text, DevoProvC)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    ImpNotaC = objDataSet.Tables(0).Rows(0).Item("subtotal")
                    IVANotaC = objDataSet.Tables(0).Rows(0).Item("impuesto")
                    ImpTotalNotaC = objDataSet.Tables(0).Rows(0).Item("importe")
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerUltFolioNotaCC(ByVal Tipo As String)
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            Try
                objDataSet = objNotas.usp_TraerUltFolioNotaCC("CA")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("folio").ToString.Trim = "" Then
                        IdFolioNotaC = 1
                    Else
                        IdFolioNotaC = objDataSet.Tables(0).Rows(0).Item("folio") + 1
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Function Inserta_Nota() As Boolean
        Dim objDataSet As Data.DataSet
        Dim Estatus As String = ""
        Dim Opcion As Integer = 1
        Using objNotas As New BCL.BCLNotasCC(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objNotas.Inserta_Nota  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("folio") = IdFolioNotaC
                objDataRow.Item("idfoliosuc") = Txt_NoBulto.Text

                If GLB_CveSucursal = "95" Or GLB_CveSucursal = "" Then
                    objDataRow.Item("cvesuc") = "00"
                Else
                    objDataRow.Item("cvesuc") = GLB_CveSucursal
                End If

                objDataRow.Item("fecha") = GLB_FechaHoy
                objDataRow.Item("tipo") = "CA"
                objDataRow.Item("status") = "CA"

                objDataRow.Item("aplicada") = CDate("1900-01-01")

                objDataRow.Item("idmotivo") = 4
                objDataRow.Item("importe") = ImpNotaC
                objDataRow.Item("iva") = IVANotaC
                objDataRow.Item("imptotal") = ImpTotalNotaC
                objDataRow.Item("descrip") = Txt_Observa.Text
                objDataRow.Item("idusuario") = GLB_Idempleado

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                ''Add the Project
                If Not objNotas.usp_Captura_NotaCC(Accion, objDataSet) Then
                    Throw New Exception("Falló Inserción de Nota de Cargo")
                Else
                    Inserta_Nota = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


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

    Function Genera_OrdeComp() As Boolean
        'mreyes 14/Febrero/2012 01:44 p.m.
        Dim FechaEntrega As Date
        Dim CSuc As String = ""
        Dim OrdeComp As String = ""
        Dim Sw_Entro As Boolean = False
        '' Dim Cont As Integer = 0
        Try
            FechaEntrega = "01-01-1900"
            CSuc = ""
            For I As Integer = 0 To DGrid.Rows.Count - 2
                If DGrid.Rows(I).Cells("ta").Value <> "" Then
                    Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        'Get a new Project DataSet
                        Try

                            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
                            Dim renglon As Integer = DGrid.CurrentCell.RowIndex

                            ' GLB_VariasOC
                            ' SE ELIMINO PUEDA GENERAR VARIAS ORDENES DE COMPRA 

                            'If GLB_VariasOC = True Then
                            If IntSelect > 1 Then
                                'If (FechaEntrega <> Format(DGrid.Rows(I).Cells(125).Value, "Short Date") Or FechaEntrega = "01-01-1900") Then
                                If (CSuc <> DGrid.Rows(I).Cells("csuc").Value Or CSuc = "") Then
                                    ' Generar otra orden de compra 
                                    Cont = Cont + 1
                                    Txt_Sucursal.Text = DGrid.Rows(I).Cells("csuc").Value

                                    OrdeComp = fn_TraerFolioOrdeComp(1, Txt_Sucursal.Text, 1)
                                    OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)

                                    ' generar folio de orden de compra 
                                    If Inserta_OrdeComp(OrdeComp) = False Then
                                        Genera_OrdeComp = False
                                        Exit Function
                                    End If
                                    ImpOrdeComp(Cont) = OrdeComp
                                    SucOrdeComp(Cont) = Txt_Sucursal.Text
                                    ' actualizar folio ordecomp
                                    If Actualiza_FolioOrdeComp(2, Txt_Sucursal.Text, 1) = False Then
                                        Genera_OrdeComp = False
                                        Exit Function
                                    End If
                                End If
                            Else
                                ' Generar otra orden de compra 
                                If Sw_Entro = False Then
                                    Sw_Entro = True
                                    Cont = Cont + 1
                                    OrdeComp = fn_TraerFolioOrdeComp(1, Txt_Sucursal.Text, 1)
                                    OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)

                                    ' generar folio de orden de compra 
                                    If Inserta_OrdeComp(OrdeComp) = False Then
                                        Genera_OrdeComp = False
                                        Exit Function
                                    End If
                                    ImpOrdeComp(Cont) = OrdeComp
                                    SucOrdeComp(Cont) = Txt_Sucursal.Text
                                    ' actualizar folio ordecomp
                                    If Actualiza_FolioOrdeComp(2, Txt_Sucursal.Text, 1) = False Then
                                        Genera_OrdeComp = False
                                        Exit Function
                                    End If
                                End If
                            End If
                            ' grabar detallado en base a ordecomp

                            If Inserta_Det_oc(OrdeComp, I) = False Then
                                Genera_OrdeComp = False
                                Exit Function
                            End If
                            If Format(DGrid.Rows(I).Cells(125).Value, "Short Date").Length > 0 Then
                                FechaEntrega = Format(DGrid.Rows(I).Cells(125).Value, "Short Date")
                            Else
                                FechaEntrega = "1900-01-01"
                            End If
                            CSuc = DGrid.Rows(I).Cells("csuc").Value
                            '''' PONER EN CEROS LA CANTIDAD SOLICITADA SI SE TRATA DE UN RESURTIDO. 

                            ' imprimir orden de compra 




                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If
            Next

            '' imprimir última orden de compra 
            Dim IdEmpleadoB As Integer = 0
            Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet

                objDatasetE = objMarca.usp_TraerMarca(Txt_Marca.Text, "")
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    IdEmpleadoB = (objDatasetE.Tables(0).Rows(0).Item("idempleado").ToString)

                End If
            End Using

            Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

                Try
                    'Get the specific project selected in the ListView control
                    objDataSet = objPersis.usp_TraerCorreoNomina(IdEmpleadoB)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_CorreoCompras = objDataSet.Tables(0).Rows(0).Item("email").ToString
                        GLB_PassCorreoCompras = objDataSet.Tables(0).Rows(0).Item("passemail").ToString

                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using



            If Cont > 1 Then
                For j As Integer = 1 To Cont
                    If ImpOrdeComp(j) <> "" Then
                        Txt_OrdeComp.Text = ImpOrdeComp(j)
                        Txt_Sucursal.Text = SucOrdeComp(j)

                        DGrid.RowCount = 1
                        RellenaOrdeComp()
                        DGrid.Sort(DGrid.Columns("C"), System.ComponentModel.ListSortDirection.Ascending)
                        DGrid.Sort(DGrid.Columns("I"), System.ComponentModel.ListSortDirection.Ascending)
                        Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(j), 0)
                        Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(j), 1)
                        If Sw_EnviarCorreo = True Then
                            If EnviarCorreo(ImpOrdeComp(j), False) = False Then
                                MsgBox("Error al enviar correo. Intente de nuevo mas tarde.", MsgBoxStyle.Critical, "Aviso")
                            Else
                                If Inserta_SigBit("1900-01-01", "1900-01-01", ImpOrdeComp(j)) = False Then

                                End If
                                '' Enviar correo a Mary
                                If EnviarCorreo(ImpOrdeComp(j), True) = False Then

                                End If
                            End If
                        End If
                        If Sw_PedidoMano = True Then
                            If Inserta_SigBit("1900-01-01", "1900-01-01", ImpOrdeComp(j)) = False Then

                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
            Else
                ImpOrdeComp(0) = OrdeComp
                SucOrdeComp(0) = Txt_Sucursal.Text

                DGrid.Sort(DGrid.Columns("C"), System.ComponentModel.ListSortDirection.Ascending)
                DGrid.Sort(DGrid.Columns("I"), System.ComponentModel.ListSortDirection.Ascending)
                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, OrdeComp, 0)
                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, OrdeComp, 1)
                If Sw_EnviarCorreo = True Then
                    If EnviarCorreo(OrdeComp, False) = False Then
                        MsgBox("Error al enviar correo. Intente de nuevo mas tarde.", MsgBoxStyle.Critical, "Aviso")
                    Else
                        If Inserta_SigBit("1900-01-01", "1900-01-01", OrdeComp) = False Then

                        End If
                        '' Enviar correo a Mary
                        If EnviarCorreo(OrdeComp, True) = False Then

                        End If
                    End If
                End If
                If Sw_PedidoMano = True Then
                    If Inserta_SigBit("1900-01-01", "1900-01-01", OrdeComp) = False Then

                    End If
                End If
            End If

            Genera_OrdeComp = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function





    Function Genera_BorradorOC() As Boolean
        'mreyes 05/Marzo/2015 10:34 a.m.
        Dim FechaEntrega As Date
        Dim CSuc As String = ""
        Dim OrdeComp As String = ""
        Dim Sw_Entro As Boolean = False
        '' Dim Cont As Integer = 0
        Try
            FechaEntrega = "01-01-1900"
            CSuc = ""
            For I As Integer = 0 To DGrid.Rows.Count - 2
                If DGrid.Rows(I).Cells("ta").Value <> "" Then
                    Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        'Get a new Project DataSet
                        Try

                            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
                            Dim renglon As Integer = DGrid.CurrentCell.RowIndex

                            ' GLB_VariasOC
                            ' SE ELIMINO PUEDA GENERAR VARIAS ORDENES DE COMPRA 

                            'If GLB_VariasOC = True Then
                            If IntSelect > 1 Then
                                'If (FechaEntrega <> Format(DGrid.Rows(I).Cells(125).Value, "Short Date") Or FechaEntrega = "01-01-1900") Then
                                If (CSuc <> DGrid.Rows(I).Cells("csuc").Value Or CSuc = "") Then
                                    ' Generar otra orden de compra 
                                    Cont = Cont + 1
                                    Txt_Sucursal.Text = DGrid.Rows(I).Cells("csuc").Value

                                    OrdeComp = fn_TraerFolioOrdeComp(1, Txt_Sucursal.Text, 1)
                                    OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)

                                    ' generar folio de orden de compra 
                                    If Inserta_OrdeComp(OrdeComp) = False Then
                                        Genera_BorradorOC = False
                                        Exit Function
                                    End If
                                    ImpOrdeComp(Cont) = OrdeComp
                                    SucOrdeComp(Cont) = Txt_Sucursal.Text
                                    ' actualizar folio ordecomp
                                    If Actualiza_FolioOrdeComp(2, Txt_Sucursal.Text, 1) = False Then
                                        Genera_BorradorOC = False
                                        Exit Function
                                    End If
                                End If
                            Else
                                ' Generar otra orden de compra 
                                If Sw_Entro = False Then
                                    Sw_Entro = True
                                    Cont = Cont + 1
                                    OrdeComp = fn_TraerFolioOrdeComp(1, Txt_Sucursal.Text, 1)
                                    OrdeComp = pub_RellenarIzquierda(OrdeComp, 6)

                                    ' generar folio de orden de compra 
                                    If Inserta_OrdeComp(OrdeComp) = False Then
                                        Genera_BorradorOC = False
                                        Exit Function
                                    End If
                                    ImpOrdeComp(Cont) = OrdeComp
                                    SucOrdeComp(Cont) = Txt_Sucursal.Text
                                    ' actualizar folio ordecomp
                                    If Actualiza_FolioOrdeComp(2, Txt_Sucursal.Text, 1) = False Then
                                        Genera_BorradorOC = False
                                        Exit Function
                                    End If
                                End If
                            End If
                            ' grabar detallado en base a ordecomp

                            If Inserta_Det_oc(OrdeComp, I) = False Then
                                Genera_BorradorOC = False
                                Exit Function
                            End If
                            If Format(DGrid.Rows(I).Cells(125).Value, "Short Date").Length > 0 Then
                                FechaEntrega = Format(DGrid.Rows(I).Cells(125).Value, "Short Date")
                            Else
                                FechaEntrega = "1900-01-01"
                            End If
                            CSuc = DGrid.Rows(I).Cells("csuc").Value
                            '''' PONER EN CEROS LA CANTIDAD SOLICITADA SI SE TRATA DE UN RESURTIDO. 

                            ' imprimir orden de compra 




                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If
            Next

            '' imprimir última orden de compra 
            Dim IdEmpleadoB As Integer = 0
            Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet

                objDatasetE = objMarca.usp_TraerMarca(Txt_Marca.Text, "")
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    IdEmpleadoB = (objDatasetE.Tables(0).Rows(0).Item("idempleado").ToString)

                End If
            End Using

            Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

                Try
                    'Get the specific project selected in the ListView control
                    objDataSet = objPersis.usp_TraerCorreoNomina(IdEmpleadoB)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_CorreoCompras = objDataSet.Tables(0).Rows(0).Item("email").ToString
                        GLB_PassCorreoCompras = objDataSet.Tables(0).Rows(0).Item("passemail").ToString

                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using



            If Cont > 1 Then
                For j As Integer = 1 To Cont
                    If ImpOrdeComp(j) <> "" Then
                        Txt_OrdeComp.Text = ImpOrdeComp(j)
                        Txt_Sucursal.Text = SucOrdeComp(j)

                        DGrid.RowCount = 1
                        RellenaOrdeComp()
                        DGrid.Sort(DGrid.Columns("C"), System.ComponentModel.ListSortDirection.Ascending)
                        DGrid.Sort(DGrid.Columns("I"), System.ComponentModel.ListSortDirection.Ascending)
                        Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(j), 0)
                        Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(j), 1)
                        If Sw_EnviarCorreo = True Then
                            If EnviarCorreo(ImpOrdeComp(j), False) = False Then
                                MsgBox("Error al enviar correo. Intente de nuevo mas tarde.", MsgBoxStyle.Critical, "Aviso")
                            Else
                                If Inserta_SigBit("1900-01-01", "1900-01-01", ImpOrdeComp(j)) = False Then

                                End If
                                '' Enviar correo a Mary
                                If EnviarCorreo(ImpOrdeComp(j), True) = False Then

                                End If
                            End If
                        End If
                        If Sw_PedidoMano = True Then
                            If Inserta_SigBit("1900-01-01", "1900-01-01", ImpOrdeComp(j)) = False Then

                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
            Else
                ImpOrdeComp(0) = OrdeComp
                SucOrdeComp(0) = Txt_Sucursal.Text

                DGrid.Sort(DGrid.Columns("C"), System.ComponentModel.ListSortDirection.Ascending)
                DGrid.Sort(DGrid.Columns("I"), System.ComponentModel.ListSortDirection.Ascending)
                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, OrdeComp, 0)
                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, OrdeComp, 1)
                If Sw_EnviarCorreo = True Then
                    If EnviarCorreo(OrdeComp, False) = False Then
                        MsgBox("Error al enviar correo. Intente de nuevo mas tarde.", MsgBoxStyle.Critical, "Aviso")
                    Else
                        If Inserta_SigBit("1900-01-01", "1900-01-01", OrdeComp) = False Then

                        End If
                        '' Enviar correo a Mary
                        If EnviarCorreo(OrdeComp, True) = False Then

                        End If
                    End If
                End If
                If Sw_PedidoMano = True Then
                    If Inserta_SigBit("1900-01-01", "1900-01-01", OrdeComp) = False Then

                    End If
                End If
            End If

            Genera_BorradorOC = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function





    Function ActualizarBulto() As Boolean
        'mreyes 17/Febrero/2013 12:50 p.m. 
        Try
            ActualizarBulto = False
            Using objBultos As New BCL.BCLBulto(GLB_ConStringCipSis)

                If objBultos.usp_Captura_Bulto(3, Val(FolioB), 0, "", "", "", 0, 0, "", 0, "1900-01-01", 0, "1900-01-01", GLB_Usuario, "1900-01-01 00:00:00", "", "1900-01-01 00:00:00", GLB_Idempleado, "1900-01-01 00:00:00", GLB_Idempleado, GLB_Idempleado, 0, 0, GLB_CveSucursal, "AP", "R", 0, "") = True Then
                    ActualizarBulto = True
                Else
                    ActualizarBulto = False
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Genera_BultosCodigos() As Boolean
        'mreyes 17/Febrero/2013 12:50 p.m.
        Try
            Dim Serie As String = ""
            Dim ObjDataSet1 As Data.DataSet
            Dim Codigo As String = ""

            For I As Integer = 1 To Val(NoBultos)
                ' INSERTAR EN SERIES
                Using objBulto As New BCL.BCLBulto(GLB_ConStringCipSis)
                    ObjDataSet1 = objBulto.Inserta_DetCodigo  'INSERTA NUEVO DATASET
                    Dim objDataRow1 As Data.DataRow = ObjDataSet1.Tables(0).NewRow

                    Codigo = pub_RellenarIzquierda(Txt_NoBulto.Text & "0" & I, 13)
                    objDataRow1.Item("idfolio") = Val(FolioB)
                    objDataRow1.Item("codigo") = Codigo
                    objDataRow1.Item("impreso") = 1
                    objDataRow1.Item("usuario") = GLB_Usuario
                    objDataRow1.Item("usuarioimprime") = ""


                    'Add the DataRow to the DataSet
                    ObjDataSet1.Tables(0).Rows.Add(objDataRow1)

                    If Not objBulto.usp_Captura_DetCodigo(1, ObjDataSet1) Then
                        Throw New Exception("Falló Inserción DET_CODIGO ")
                    End If
                End Using

            Next
            Genera_BultosCodigos = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Genera_FactProv() As Boolean
        'mreyes 24/Mayo/2012 04:05 p.m.

        Dim FactProv As String = ""
        Dim Sw_Entro As Boolean = False
        '' Dim Cont As Integer = 0
        Try

            For I As Integer = 0 To DGrid.Rows.Count - 2
                Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    'Get a new Project DataSet
                    Try

                        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
                        Dim renglon As Integer = DGrid.CurrentCell.RowIndex

                        ' GLB_VariasOC
                        ' SE ELIMINO PUEDA GENERAR VARIAS ORDENES DE COMPRA 

                        ' Generar otra orden de compra 
                        If Sw_Entro = False Then
                            Sw_Entro = True
                            Cont = Cont + 1
                            FactProv = fn_TraerFolioOrdeComp(3, Txt_Sucursal.Text, 1)
                            FactProv = pub_RellenarIzquierda(FactProv, 6)

                            ' generar folio de orden de compra 
                            If Inserta_FactProv(FactProv) = False Then
                                Genera_FactProv = False
                                Exit Function
                            End If
                            ImpOrdeComp(Cont) = FactProv
                            ' actualizar folio ordecomp
                            If Actualiza_FolioOrdeComp(4, Txt_Sucursal.Text, 1) = False Then
                                Genera_FactProv = False
                                Exit Function
                            End If
                        End If

                        ' grabar detallado en base a ordecomp

                        If Inserta_Det_fp(FactProv, I) = False Then
                            Genera_FactProv = False
                            Exit Function
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            Next

            '' imprimir última orden de compra 
            'If Cont > 1 Then
            '    For j As Integer = 1 To Cont
            '        If ImpOrdeComp(j) <> "" Then
            '            Txt_OrdeComp.Text = ImpOrdeComp(j)
            '            DGrid.RowCount = 1
            '            RellenaOrdeComp()
            '            DGrid.Sort(DGrid.Columns("C"), System.ComponentModel.ListSortDirection.Ascending)
            '            DGrid.Sort(DGrid.Columns("I"), System.ComponentModel.ListSortDirection.Ascending)
            '            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(j), 0)
            '            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(j), 1)

            '        Else
            '            Exit For
            '        End If
            '    Next

            'End If   '


            'CREAR SERIES, EN SQL
            'mreyes 22/Julio/2021   12:02 p.m.
            Dim Sw_Guardo As Boolean = False

            Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoSQL)
                Sw_Guardo = objUsuario.usp_GeneraSeriesReciboMYSQL(Trim(Txt_Sucursal.Text), FactProv)
            End Using

            'CREAR SERIES, EN SQL


            Genera_FactProv = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Genera_DevoProv() As Boolean
        'mreyes 11/Junio/2013 10:44 a.m.

        Dim DevoProv As String = ""
        Dim Sw_Entro As Boolean = False
        '' Dim Cont As Integer = 0
        Try

            For I As Integer = 0 To DGrid.Rows.Count - 2
                Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    'Get a new Project DataSet
                    Try



                        ' GLB_VariasOC
                        ' SE ELIMINO PUEDA GENERAR VARIAS ORDENES DE COMPRA 

                        ' Generar otra orden de compra 
                        If Sw_Entro = False Then
                            Sw_Entro = True
                            Cont = Cont + 1
                            DevoProv = fn_TraerFolioOrdeComp(7, Txt_Sucursal.Text, 1) 'EL 7 ES DEVOLUCION 
                            DevoProv = pub_RellenarIzquierda(DevoProv, 6)
                            DevoProvC = DevoProv
                            ' generar folio de orden de compra 
                            If Inserta_DevoProv(DevoProv) = False Then
                                Genera_DevoProv = False
                                Exit Function
                            End If
                            ImpOrdeComp(Cont) = DevoProv
                            ' actualizar folio ordecomp
                            If Actualiza_FolioOrdeComp(8, Txt_Sucursal.Text, 1) = False Then
                                Genera_DevoProv = False
                                Exit Function
                            End If
                        End If

                        ' grabar detallado en base a ordecomp

                        If Inserta_Det_Dp(DevoProv, I, DGrid.Rows(I).Cells(23).Value) = False Then
                            Genera_DevoProv = False
                            Exit Function
                        End If

                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            Next



            Genera_DevoProv = True
            Txt_OrdeComp.Text = DevoProv
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function EnviarCorreo(ByVal OrdeComp As String, ByVal Sw_Compras As Boolean) As Boolean
        Try
            'mreyes 28/Febrero/2012 04:45 p.m.
            Dim Correos As String
            Dim Asunto As String
            Dim Mensaje As String
            If Sw_NoArchivo = False Then Exit Function '''' NO PUDO GENERAR EL ARCHIVO PDF.

            If Txt_Email01.Text.Length = 0 Then
                EnviarCorreo = False
                MsgBox("El proveedor no cuenta con datos para enviar correo.", MsgBoxStyle.Critical, "Correo no enviado")
                Exit Function
            End If

            If (Txt_Total.Text) = 0 Then
                Exit Function
            End If
            Correos = Txt_Email01.Text
            If Txt_Email02.Text.Length > 0 Then
                Correos = Correos & "," & Txt_Email02.Text
            End If
            Asunto = "Zapaterías Torreón, Orden de Compra '" & Txt_Sucursal.Text & "-" & OrdeComp & "'"
            If Sw_Compras = False Then
                Mensaje = "SE ADJUNTA ARCHIVO CON INFORMACIÓN DE ORDEN DE COMPRA '" & Txt_Sucursal.Text & "-" & OrdeComp & "' CUALQUIER DUDA O ACLARACIÓN, ESTAMOS A SUS ORDENES."
            Else
                Mensaje = "SE HA ENVIADO LA ORDEN DE COMPRA '" & Txt_Sucursal.Text & "-" & OrdeComp & "' AL CORREO '" & Txt_Email01.Text & "' PARA EL PROVEEDOR '" & Txt_Raz_Soc.Text & "'."
                Correos = GLB_CorreoCompras
            End If

            If Txt_CorreoCancela.Text <> "" Then
                Mensaje = Txt_CorreoCancela.Text
            End If

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                If Sw_Compras = True Then
                    objIO.pub_EnviarCorreo(GLB_SmtpClient, GLB_CorreoCompras, GLB_PassCorreoCompras, Correos, Asunto, Mensaje, "")
                Else
                    objIO.pub_EnviarCorreo(GLB_SmtpClient, GLB_CorreoCompras, GLB_PassCorreoCompras, Correos, Asunto, Mensaje, RutaArchivoCorreo)
                End If
            End Using


            '' volver a enviar correo como copia
            If Sw_Compras = False Then
                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)
                    Asunto = "COPIA PEDIDO, Zapaterías Torreón, Orden de Compra '" & Txt_Sucursal.Text & "-" & OrdeComp & "'"
                    objIO.pub_EnviarCorreo(GLB_SmtpClient, GLB_CorreoCompras, GLB_PassCorreoCompras, Correos, Asunto, Mensaje, RutaArchivoCorreo)
                End Using
            End If

            EnviarCorreo = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Function Inserta_OrdeComp(ByVal OrdeComp As String) As Boolean
        'mreyes 14/Febrero/2012 01:44 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objPedidos.Inserta_OrdeComp  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                'Set the values in the DataRow

                objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                objDataRow.Item("ordecomp") = Trim(OrdeComp)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = Now.Date
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("observa") = Trim(Txt_Observa.Text)
                objDataRow.Item("usuario") = GLB_Usuario
                objDataRow.Item("resurtsn") = IIf(Sw_PedidoNuevo = True, "N", "S")
                objDataRow.Item("dsctopp") = Val(Txt_Dsctopp.Text)
                objDataRow.Item("diaspp") = Val(Txt_Diaspp.Text)
                objDataRow.Item("dscto01") = Val(Txt_Dscto01.Text)
                objDataRow.Item("dscto02") = Val(Txt_Dscto02.Text)
                objDataRow.Item("dscto03") = Val(Txt_Dscto03.Text)
                objDataRow.Item("dscto04") = Val(Txt_Dscto04.Text)
                objDataRow.Item("dscto05") = Val(Txt_Dscto05.Text)
                objDataRow.Item("iva") = Val(Txt_Iva.Text)

                If Opt_PedidoCatalogo.Checked = True Then
                    objDataRow.Item("tipopedido") = "CATALOGO"
                Else
                    objDataRow.Item("tipopedido") = "UNICO"
                End If


                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_Captura_OrdeComp(Accion, objDataSet) Then
                    '' Throw New Exception("Falló Inserción de OrdeComp")
                Else
                    Inserta_OrdeComp = True
                End If
                Inserta_OrdeComp = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function

    Function Inserta_FactProv(ByVal FactProv As String) As Boolean
        'mreyes 24/Mayo/2012 04:23 p.m.
        Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objPedidos.Inserta_FactProv  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                'Set the values in the DataRow




                objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                objDataRow.Item("factprov") = Trim(FactProv)
                objDataRow.Item("idfolio") = Val(FolioB)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = Txt_FechaFactura.Text
                objDataRow.Item("hora") = pub_RellenarIzquierda(CStr(Now.Hour), 2) & ":" & pub_RellenarIzquierda(CStr(Now.Minute), 2) & ":" & pub_RellenarIzquierda(CStr(Now.Second), 2)
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("fecreci") = Now.Date
                objDataRow.Item("fecvenc") = Txt_FechaVence.Text

                objDataRow.Item("referenc") = Txt_Referenc.Text
                objDataRow.Item("gastos") = CDbl(Txt_Gastos.Text)
                objDataRow.Item("descuento") = CDbl(Txt_Descuento.Text)
                objDataRow.Item("observa") = Trim(Txt_Observa.Text)
                objDataRow.Item("usuario") = GLB_Usuario
                'objDataRow.Item("iva") = Val(Txt_Iva.Text)
                objDataRow.Item("dsctopp") = Val(Txt_Dsctopp.Text)
                objDataRow.Item("diaspp") = Val(Txt_Diaspp.Text)
                objDataRow.Item("dscto01") = Val(Txt_Dscto01.Text)
                objDataRow.Item("dscto02") = Val(Txt_Dscto02.Text)
                objDataRow.Item("dscto03") = Val(Txt_Dscto03.Text)
                objDataRow.Item("dscto04") = Val(Txt_Dscto04.Text)
                objDataRow.Item("dscto05") = Val(Txt_Dscto05.Text)
                objDataRow.Item("iva") = Val(Txt_Iva.Text)
                objDataRow.Item("subtotal") = CDbl(Txt_Subtotal.Text)
                objDataRow.Item("impuesto") = CDbl(Txt_TotalIVA.Text)
                objDataRow.Item("total") = CDbl(Txt_Total.Text)
                objDataRow.Item("apagar") = CDbl(Txt_Total.Text)
                objDataRow.Item("pares") = CDbl(Txt_Pares.Text)
                objDataRow.Item("idusuario") = GLB_Idempleado

                objDataRow.Item("idusuariomodif") = GLB_Idempleado
                objDataRow.Item("idusuariocancela") = GLB_Idempleado

                'EntregaVence mreyes 21/Julio/2015  09:59 a.m.

                objDataRow.Item("entregavence") = Entregavence

                objDataRow.Item("Improcedente") = CDbl(Txt_Improcedente.Text)

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_Captura_FactProv(Accion, objDataSet) Then
                    '' Throw New Exception("Falló Inserción de OrdeComp")
                Else
                    Inserta_FactProv = True
                End If
                Inserta_FactProv = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function

    Function Inserta_DevoProv(ByVal DevoProv As String) As Boolean
        'mreyes 11/Junio/2013 10:44 a.m.
        Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try

                objDataSet = objPedidos.Inserta_DevoProv  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                If Val(FolioB) = 0 Then
                    'IR A BUSCAR EL FOLIO DE LA ENTRADA.

                End If
                'Set the values in the DataRow

                objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                objDataRow.Item("devoprov") = Trim(DevoProv)
                objDataRow.Item("idfolio") = Val(FolioB)
                objDataRow.Item("status") = "AP"
                objDataRow.Item("fecha") = GLB_FechaHoy.Date
                objDataRow.Item("hora") = pub_RellenarIzquierda(CStr(Now.Hour), 2) & ":" & pub_RellenarIzquierda(CStr(Now.Minute), 2) & ":" & pub_RellenarIzquierda(CStr(Now.Second), 2)
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("proveedor") = Trim(Txt_Proveedor.Text)
                objDataRow.Item("referenc") = Txt_Referenc.Text
                objDataRow.Item("gastos") = Val(Txt_Gastos.Text)
                objDataRow.Item("sucurfpr") = Txt_Sucursal.Text
                If Len(Txt_FactProv.Text) > 6 Then
                    objDataRow.Item("factprov") = Mid(Txt_FactProv.Text, 3)
                Else
                    objDataRow.Item("factprov") = Txt_FactProv.Text
                End If
                objDataRow.Item("observa") = Trim(Txt_Observa.Text)
                objDataRow.Item("usuario") = GLB_Usuario
                'IR A CHECAR EL RPROV.
                objDataRow.Item("iva") = Val(Txt_Iva.Text)


                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_Captura_DevoProv(Accion, objDataSet) Then
                    '' Throw New Exception("Falló Inserción de OrdeComp")
                Else
                    Inserta_DevoProv = True
                End If
                Inserta_DevoProv = True
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Function

    Function Inserta_Det_fp(ByVal FactProv As String, ByVal Renglon As Integer) As Boolean
        'mreyes 24/Mayo/2012 05:15 p.m.
        Try
            Dim Serie As String = ""
            Dim ObjDataSet1 As Data.DataSet
            Dim ObjDataSet As Data.DataSet


            Dim J As Integer = 0
            Dim ordecomp1 As String = ""
            Dim sucurorc1 As String = ""
            Dim medida1 As String = ""
            Dim estilon1 As String = ""
            Dim Entrega As Date = "1900-01-01"
            Dim Sw_PrimeraVez As Boolean = True


            If CDbl(DGrid.Rows(Renglon).Cells(23).Value) > 0 Then
                Serie = fn_TraerFolioOrdeComp(5, Txt_Sucursal.Text, 1)
                Serie = pub_RellenarIzquierda(Serie, 13)
                'agregar mas de uno al folio.
                If Actualiza_FolioOrdeComp(6, Txt_Sucursal.Text, CDbl(DGrid.Rows(Renglon).Cells(23).Value)) = False Then
                    Inserta_Det_fp = False
                    Exit Function
                End If
            End If
            For I As Integer = 24 To 123
                If DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow Then

                    'Get a new Project DataSet
                    Try
                        'BIZARRO
                        If CDbl(DGrid.Rows(Renglon).Cells(I).Value) <> 0 Then


                            'agregar mas de uno al folio.
                            ''If Actualiza_FolioOrdeComp(6, Txt_Sucursal.Text, Val(DGrid.Rows(Renglon).Cells(I).Value)) = False Then
                            ''    Inserta_Det_fp = False
                            ''    Exit Function
                            ''End If

                            ''If Actualiza_FolioOrdeComp(6, Txt_Sucursal.Text, IIf(Val(Txt_Pares.Text) > 0, Val(Txt_Pares.Text), Val(DGrid.Rows(Renglon).Cells(I).Value))) = False Then
                            ''    Inserta_Det_fp = False
                            ''    Exit Function
                            ''End If

                            'INSERTAR CON CANTIDAD EN UNO POR CADA RECIBO... 
                            For J = 1 To CDbl(DGrid.Rows(Renglon).Cells(I).Value)
                                Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                                    ObjDataSet = objPedidos.Inserta_Det_fp  'INSERTA NUEVO DATASET
                                    Dim objDataRow As Data.DataRow = ObjDataSet.Tables(0).NewRow

                                    If J <> 1 Then
                                        Serie = pub_RellenarIzquierda(Val(Serie) + 1, 13)
                                    Else
                                        If Sw_PrimeraVez = False Then
                                            Serie = pub_RellenarIzquierda(Val(Serie) + 1, 13)
                                        Else
                                            Sw_PrimeraVez = False
                                        End If
                                    End If

                                    objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                                    objDataRow.Item("factprov") = FactProv
                                    objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                                    objDataRow.Item("estilon") = DGrid.Rows(Renglon).Cells(11).Value.ToString '' 'ESTILON
                                    objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells("c").Value.ToString
                                    Entrega = Format(DGrid.Rows(Renglon).Cells("FechaEntrega").Value, "dd-MM-yyyy")


                                    If DGrid.Columns(I).HeaderText = "*" Then
                                        objDataRow.Item("medida") = DGrid.Columns(I - 1).HeaderText & "-"
                                        medida1 = DGrid.Columns(I - 1).HeaderText & "-"
                                    Else
                                        objDataRow.Item("medida") = DGrid.Columns(I).HeaderText
                                        medida1 = DGrid.Columns(I).HeaderText
                                    End If
                                    objDataRow.Item("serie") = Serie
                                    objDataRow.Item("ctd") = 1
                                    objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("costo").Value
                                    objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("pcomp").Value
                                    objDataRow.Item("precio") = DGrid.Rows(Renglon).Cells("precio").Value
                                    sucurorc1 = DGrid.Rows(Renglon).Cells("sucursal").Value
                                    ordecomp1 = DGrid.Rows(Renglon).Cells("ordecomp").Value
                                    estilon1 = DGrid.Rows(Renglon).Cells(11).Value.ToString

                                    objDataRow.Item("sucurorc") = DGrid.Rows(Renglon).Cells("sucursal").Value
                                    objDataRow.Item("ordecomp") = DGrid.Rows(Renglon).Cells("ordecomp").Value

                                    'Add the DataRow to the DataSet
                                    ObjDataSet.Tables(0).Rows.Add(objDataRow)

                                    'Add the Project

                                    If Not objPedidos.usp_Captura_Det_fp(1, ObjDataSet) Then
                                        Throw New Exception("Falló Inserción de Det_FP ")
                                    End If
                                    ObjDataSet.Dispose()
                                    objDataRow.Table.Dispose()

                                End Using
                                ' INSERTAR EN SERIES



                                Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                                    ObjDataSet1 = objPedidos.Inserta_Serie  'INSERTA NUEVO DATASET
                                    Dim objDataRow1 As Data.DataRow = ObjDataSet1.Tables(0).NewRow

                                    objDataRow1.Item("serie") = Serie
                                    objDataRow1.Item("sucursal") = Trim(Txt_Sucursal.Text)
                                    objDataRow1.Item("status") = "AC"
                                    objDataRow1.Item("marca") = Trim(Txt_Marca.Text)
                                    objDataRow1.Item("estilon") = DGrid.Rows(Renglon).Cells(11).Value.ToString '' 'ESTILON
                                    If DGrid.Columns(I).HeaderText = "*" Then
                                        objDataRow1.Item("medida") = DGrid.Columns(I - 1).HeaderText & "-"
                                    Else
                                        objDataRow1.Item("medida") = DGrid.Columns(I).HeaderText
                                    End If
                                    objDataRow1.Item("sucurdes") = Trim(Txt_Sucursal.Text)
                                    objDataRow1.Item("idfolio") = Val(FolioB)

                                    objDataRow1.Item("idarticulo") = DGrid.Rows(Renglon).Cells("idarticulo").Value
                                    objDataRow1.Item("precioini") = DGrid.Rows(Renglon).Cells("precio").Value
                                    objDataRow1.Item("costoini") = DGrid.Rows(Renglon).Cells("pcomp").Value
                                    objDataRow1.Item("preciovta") = DGrid.Rows(Renglon).Cells("precio").Value
                                    objDataRow1.Item("ultcosto") = DGrid.Rows(Renglon).Cells("pcomp").Value
                                    objDataRow1.Item("proveedors") = Txt_Proveedor.Text


                                    'Add the DataRow to the DataSet
                                    ObjDataSet1.Tables(0).Rows.Add(objDataRow1)

                                    If Not objPedidos.usp_Captura_Serie(1, ObjDataSet1) Then
                                        Throw New Exception("Falló Inserción de Serie ")
                                    End If
                                End Using
                            Next



                            '' Guardar en detalle de pedido lo recibido... 
                            Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                objCantArti.usp_ActualizarDetOCPedida(CDbl(DGrid.Rows(Renglon).Cells(I).Value), sucurorc1, ordecomp1, Trim(Txt_Marca.Text), estilon1, medida1, Entrega)
                            End Using
                            'Actualizar fecha ultimo recibo en estarticulo y corrida.
                            Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                objCantArti.usp_ActualizarFecReci(Now.Date, Trim(Txt_Proveedor.Text), Trim(Txt_Marca.Text), estilon1)
                            End Using
                        End If
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try

                End If
            Next

            'CREAR SERIES, EN SQL
            'mreyes 22/Julio/2021   12:02 p.m.
            'Dim Sw_Guardo As Boolean = False

            'Using objUsuario As New BCL.BCLPasivo(GLB_ConStringSirCoSQL)
            '    Sw_Guardo = objUsuario.usp_GeneraSeriesReciboMYSQL(Trim(Txt_Sucursal.Text), FactProv)
            'End Using

            ''CREAR SERIES, EN SQL


            Inserta_Det_fp = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Modificar_Det_fp(FactProv As String) As Boolean
        'mreyes 22/Mayo/2017    05:57 p.m.
        Try
            Dim Serie As String = ""

            Dim ObjDataSet As Data.DataSet


            Dim J As Integer = 0
            Dim ordecomp1 As String = ""
            Dim sucurorc1 As String = ""
            Dim medida1 As String = ""
            Dim estilon1 As String = ""
            Dim Entrega As Date = "1900-01-01"
            Dim Sw_PrimeraVez As Boolean = True




            'BIZARRO





            'INSERTAR CON CANTIDAD EN UNO POR CADA RECIBO... 
            For renglon As Integer = 0 To DGrid.RowCount - 2
                Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                    ObjDataSet = objPedidos.Inserta_Det_fp  'INSERTA NUEVO DATASET
                    Dim objDataRow As Data.DataRow = ObjDataSet.Tables(0).NewRow


                    objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                    objDataRow.Item("factprov") = FactProv
                    objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                    objDataRow.Item("estilon") = DGrid.Rows(renglon).Cells(11).Value.ToString '' 'ESTILON
                    objDataRow.Item("corrida") = DGrid.Rows(renglon).Cells("c").Value.ToString
                    Entrega = Format(DGrid.Rows(renglon).Cells("FechaEntrega").Value, "dd-MM-yyyy")



                    objDataRow.Item("costo") = DGrid.Rows(renglon).Cells("pcomp").Value
                    objDataRow.Item("costdesc") = DGrid.Rows(renglon).Cells("costo").Value
                    objDataRow.Item("precio") = DGrid.Rows(renglon).Cells("precio").Value


                    'Add the DataRow to the DataSet
                    ObjDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project

                    If Not objPedidos.usp_Captura_Det_fp(5, ObjDataSet) Then
                        ' Throw New Exception("Falló Inserción de Det_FP Cuando cambia iva ")
                    End If
                    ObjDataSet.Dispose()
                    objDataRow.Table.Dispose()

                End Using
                ' INSERTAR EN SERIES


            Next



            Modificar_Det_fp = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Function Inserta_PedidoTemp(ByVal FactProv As String, ByVal Renglon As Integer) As Boolean
        'mreyes 24/Marzo/2014   11:53 a.m.
        Try
            Dim Serie As String = ""

            Dim ObjDataSet As Data.DataSet

            Dim J As Integer = 0
            Dim ordecomp1 As String = ""
            Dim sucurorc1 As String = ""
            Dim medida1 As String = ""
            Dim estilon1 As String = ""
            Dim Entrega As Date = "1900-01-01"

            'Get a new Project DataSet
            Try
                'BIZARRO


                'INSERTAR CON CANTIDAD EN UNO POR CADA RECIBO... 
                For J = 1 To DGrid.RowCount - 1
                    Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                        ObjDataSet = objPedidos.Inserta_PedidoTemp  'INSERTA NUEVO DATASET
                        Dim objDataRow As Data.DataRow = ObjDataSet.Tables(0).NewRow


                        objDataRow.Item("sucursal") = DGrid.Rows(Renglon).Cells("sucursal").Value.ToString
                        objDataRow.Item("ordeomp") = DGrid.Rows(Renglon).Cells("ordeomp").Value.ToString
                        objDataRow.Item("estatus") = DGrid.Rows(Renglon).Cells("estatus").Value.ToString
                        objDataRow.Item("fecha") = DGrid.Rows(Renglon).Cells("fecha").Value.ToString
                        objDataRow.Item("marca") = DGrid.Rows(Renglon).Cells("marca").Value.ToString
                        objDataRow.Item("proveedor") = DGrid.Rows(Renglon).Cells("proveedor").Value.ToString
                        objDataRow.Item("ta") = DGrid.Rows(Renglon).Cells("ta").Value.ToString
                        objDataRow.Item("fam") = DGrid.Rows(Renglon).Cells("fam").Value.ToString
                        objDataRow.Item("lin") = DGrid.Rows(Renglon).Cells("lin").Value.ToString
                        objDataRow.Item("cat") = DGrid.Rows(Renglon).Cells("cat").Value.ToString
                        objDataRow.Item("estilofabrica") = DGrid.Rows(Renglon).Cells("estilofabrica").Value.ToString
                        objDataRow.Item("estilonuestro") = DGrid.Rows(Renglon).Cells("estilonuestro").Value.ToString
                        objDataRow.Item("descripcion") = DGrid.Rows(Renglon).Cells("descripcion").Value.ToString
                        objDataRow.Item("c") = DGrid.Rows(Renglon).Cells("c").Value.ToString
                        objDataRow.Item("i") = DGrid.Rows(Renglon).Cells("i").Value.ToString
                        objDataRow.Item("de") = DGrid.Rows(Renglon).Cells("de").Value.ToString
                        objDataRow.Item("a") = DGrid.Rows(Renglon).Cells("a").Value.ToString
                        objDataRow.Item("pcomp") = DGrid.Rows(Renglon).Cells("pcomp").Value.ToString
                        objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("costo").Value.ToString
                        objDataRow.Item("porc") = DGrid.Rows(Renglon).Cells("porc").Value.ToString
                        objDataRow.Item("csuc") = DGrid.Rows(Renglon).Cells("csuc").Value.ToString
                        objDataRow.Item("sucdescrip") = DGrid.Rows(Renglon).Cells("sucdescrip").Value.ToString
                        objDataRow.Item("prs") = Val(DGrid.Rows(Renglon).Cells("prs").Value.ToString)
                        objDataRow.Item("M1") = Val(DGrid.Rows(Renglon).Cells("M1").Value.ToString)
                        objDataRow.Item("M1_") = Val(DGrid.Rows(Renglon).Cells("M1_").Value.ToString)

                        objDataRow.Item("M1") = Val(DGrid.Rows(Renglon).Cells("M1").Value.ToString)
                        objDataRow.Item("M1_") = Val(DGrid.Rows(Renglon).Cells("M1_").Value.ToString)

                        objDataRow.Item("M2") = Val(DGrid.Rows(Renglon).Cells("M2").Value.ToString)
                        objDataRow.Item("M2_") = Val(DGrid.Rows(Renglon).Cells("M2_").Value.ToString)

                        objDataRow.Item("M3") = Val(DGrid.Rows(Renglon).Cells("M3").Value.ToString)
                        objDataRow.Item("M3_") = Val(DGrid.Rows(Renglon).Cells("M3_").Value.ToString)

                        objDataRow.Item("M4") = Val(DGrid.Rows(Renglon).Cells("M4").Value.ToString)
                        objDataRow.Item("M4_") = Val(DGrid.Rows(Renglon).Cells("M4_").Value.ToString)

                        objDataRow.Item("M5") = Val(DGrid.Rows(Renglon).Cells("M5").Value.ToString)
                        objDataRow.Item("M5_") = Val(DGrid.Rows(Renglon).Cells("M5_").Value.ToString)

                        objDataRow.Item("M6") = Val(DGrid.Rows(Renglon).Cells("M6").Value.ToString)
                        objDataRow.Item("M6_") = Val(DGrid.Rows(Renglon).Cells("M6_").Value.ToString)

                        objDataRow.Item("M7") = Val(DGrid.Rows(Renglon).Cells("M7").Value.ToString)
                        objDataRow.Item("M7_") = Val(DGrid.Rows(Renglon).Cells("M7_").Value.ToString)

                        objDataRow.Item("M8") = Val(DGrid.Rows(Renglon).Cells("M8").Value.ToString)
                        objDataRow.Item("M8_") = Val(DGrid.Rows(Renglon).Cells("M8_").Value.ToString)

                        objDataRow.Item("M9") = Val(DGrid.Rows(Renglon).Cells("M9").Value.ToString)
                        objDataRow.Item("M9_") = Val(DGrid.Rows(Renglon).Cells("M9_").Value.ToString)

                        objDataRow.Item("M10") = Val(DGrid.Rows(Renglon).Cells("M10").Value.ToString)
                        objDataRow.Item("M10_") = Val(DGrid.Rows(Renglon).Cells("M10_").Value.ToString)

                        objDataRow.Item("M11") = Val(DGrid.Rows(Renglon).Cells("M11").Value.ToString)
                        objDataRow.Item("M11_") = Val(DGrid.Rows(Renglon).Cells("M11_").Value.ToString)


                        objDataRow.Item("M12") = Val(DGrid.Rows(Renglon).Cells("M12").Value.ToString)
                        objDataRow.Item("M12_") = Val(DGrid.Rows(Renglon).Cells("M12_").Value.ToString)


                        objDataRow.Item("M13") = Val(DGrid.Rows(Renglon).Cells("M13").Value.ToString)
                        objDataRow.Item("M13_") = Val(DGrid.Rows(Renglon).Cells("M13_").Value.ToString)


                        objDataRow.Item("M14") = Val(DGrid.Rows(Renglon).Cells("M14").Value.ToString)
                        objDataRow.Item("M14_") = Val(DGrid.Rows(Renglon).Cells("M14_").Value.ToString)


                        objDataRow.Item("M15") = Val(DGrid.Rows(Renglon).Cells("M15").Value.ToString)
                        objDataRow.Item("M15_") = Val(DGrid.Rows(Renglon).Cells("M15_").Value.ToString)


                        objDataRow.Item("M16") = Val(DGrid.Rows(Renglon).Cells("M16").Value.ToString)
                        objDataRow.Item("M16_") = Val(DGrid.Rows(Renglon).Cells("M16_").Value.ToString)


                        objDataRow.Item("M17") = Val(DGrid.Rows(Renglon).Cells("M17").Value.ToString)
                        objDataRow.Item("M17_") = Val(DGrid.Rows(Renglon).Cells("M17_").Value.ToString)


                        objDataRow.Item("M18") = Val(DGrid.Rows(Renglon).Cells("M18").Value.ToString)
                        objDataRow.Item("M18_") = Val(DGrid.Rows(Renglon).Cells("M18_").Value.ToString)


                        objDataRow.Item("M19") = Val(DGrid.Rows(Renglon).Cells("M19").Value.ToString)
                        objDataRow.Item("M19_") = Val(DGrid.Rows(Renglon).Cells("M19_").Value.ToString)


                        objDataRow.Item("M20") = Val(DGrid.Rows(Renglon).Cells("M20").Value.ToString)
                        objDataRow.Item("M20_") = Val(DGrid.Rows(Renglon).Cells("M20_").Value.ToString)


                        objDataRow.Item("M21") = Val(DGrid.Rows(Renglon).Cells("M21").Value.ToString)
                        objDataRow.Item("M21_") = Val(DGrid.Rows(Renglon).Cells("M21_").Value.ToString)


                        objDataRow.Item("M22") = Val(DGrid.Rows(Renglon).Cells("M22").Value.ToString)
                        objDataRow.Item("M22_") = Val(DGrid.Rows(Renglon).Cells("M22_").Value.ToString)

                        objDataRow.Item("M23") = Val(DGrid.Rows(Renglon).Cells("M23").Value.ToString)
                        objDataRow.Item("M23_") = Val(DGrid.Rows(Renglon).Cells("M23_").Value.ToString)

                        objDataRow.Item("M24") = Val(DGrid.Rows(Renglon).Cells("M24").Value.ToString)
                        objDataRow.Item("M24_") = Val(DGrid.Rows(Renglon).Cells("M24_").Value.ToString)

                        objDataRow.Item("M25") = Val(DGrid.Rows(Renglon).Cells("M25").Value.ToString)
                        objDataRow.Item("M25_") = Val(DGrid.Rows(Renglon).Cells("M25_").Value.ToString)

                        objDataRow.Item("M26") = Val(DGrid.Rows(Renglon).Cells("M26").Value.ToString)
                        objDataRow.Item("M26_") = Val(DGrid.Rows(Renglon).Cells("M26_").Value.ToString)

                        objDataRow.Item("M27") = Val(DGrid.Rows(Renglon).Cells("M27").Value.ToString)
                        objDataRow.Item("M27_") = Val(DGrid.Rows(Renglon).Cells("M27_").Value.ToString)

                        objDataRow.Item("M28") = Val(DGrid.Rows(Renglon).Cells("M28").Value.ToString)
                        objDataRow.Item("M28_") = Val(DGrid.Rows(Renglon).Cells("M28_").Value.ToString)

                        objDataRow.Item("M29") = Val(DGrid.Rows(Renglon).Cells("M29").Value.ToString)
                        objDataRow.Item("M29_") = Val(DGrid.Rows(Renglon).Cells("M29_").Value.ToString)

                        objDataRow.Item("M30") = Val(DGrid.Rows(Renglon).Cells("M30").Value.ToString)
                        objDataRow.Item("M30_") = Val(DGrid.Rows(Renglon).Cells("M30_").Value.ToString)

                        objDataRow.Item("M31") = Val(DGrid.Rows(Renglon).Cells("M31").Value.ToString)
                        objDataRow.Item("M31_") = Val(DGrid.Rows(Renglon).Cells("M31_").Value.ToString)

                        objDataRow.Item("M32") = Val(DGrid.Rows(Renglon).Cells("M32").Value.ToString)
                        objDataRow.Item("M32_") = Val(DGrid.Rows(Renglon).Cells("M32_").Value.ToString)

                        objDataRow.Item("M33") = Val(DGrid.Rows(Renglon).Cells("M33").Value.ToString)
                        objDataRow.Item("M33_") = Val(DGrid.Rows(Renglon).Cells("M33_").Value.ToString)

                        objDataRow.Item("M34") = Val(DGrid.Rows(Renglon).Cells("M34").Value.ToString)
                        objDataRow.Item("M34_") = Val(DGrid.Rows(Renglon).Cells("M34_").Value.ToString)

                        objDataRow.Item("M35") = Val(DGrid.Rows(Renglon).Cells("M35").Value.ToString)
                        objDataRow.Item("M35_") = Val(DGrid.Rows(Renglon).Cells("M35_").Value.ToString)

                        objDataRow.Item("M36") = Val(DGrid.Rows(Renglon).Cells("M36").Value.ToString)
                        objDataRow.Item("M36_") = Val(DGrid.Rows(Renglon).Cells("M36_").Value.ToString)

                        objDataRow.Item("M37") = Val(DGrid.Rows(Renglon).Cells("M37").Value.ToString)
                        objDataRow.Item("M37_") = Val(DGrid.Rows(Renglon).Cells("M37_").Value.ToString)

                        objDataRow.Item("M38") = Val(DGrid.Rows(Renglon).Cells("M38").Value.ToString)
                        objDataRow.Item("M38_") = Val(DGrid.Rows(Renglon).Cells("M38_").Value.ToString)

                        objDataRow.Item("M39") = Val(DGrid.Rows(Renglon).Cells("M39").Value.ToString)
                        objDataRow.Item("M39_") = Val(DGrid.Rows(Renglon).Cells("M39_").Value.ToString)

                        objDataRow.Item("M40") = Val(DGrid.Rows(Renglon).Cells("M40").Value.ToString)
                        objDataRow.Item("M40_") = Val(DGrid.Rows(Renglon).Cells("M40_").Value.ToString)

                        objDataRow.Item("M41") = Val(DGrid.Rows(Renglon).Cells("M41").Value.ToString)
                        objDataRow.Item("M41_") = Val(DGrid.Rows(Renglon).Cells("M41_").Value.ToString)

                        objDataRow.Item("M42") = Val(DGrid.Rows(Renglon).Cells("M42").Value.ToString)
                        objDataRow.Item("M42_") = Val(DGrid.Rows(Renglon).Cells("M42_").Value.ToString)

                        objDataRow.Item("M43") = Val(DGrid.Rows(Renglon).Cells("M43").Value.ToString)
                        objDataRow.Item("M43_") = Val(DGrid.Rows(Renglon).Cells("M43_").Value.ToString)

                        objDataRow.Item("M44") = Val(DGrid.Rows(Renglon).Cells("M44").Value.ToString)
                        objDataRow.Item("M44_") = Val(DGrid.Rows(Renglon).Cells("M44_").Value.ToString)

                        objDataRow.Item("M45") = Val(DGrid.Rows(Renglon).Cells("M45").Value.ToString)
                        objDataRow.Item("M45_") = Val(DGrid.Rows(Renglon).Cells("M45_").Value.ToString)

                        objDataRow.Item("M46") = Val(DGrid.Rows(Renglon).Cells("M46").Value.ToString)
                        objDataRow.Item("M46_") = Val(DGrid.Rows(Renglon).Cells("M46_").Value.ToString)

                        objDataRow.Item("M47") = Val(DGrid.Rows(Renglon).Cells("M47").Value.ToString)
                        objDataRow.Item("M47_") = Val(DGrid.Rows(Renglon).Cells("M47_").Value.ToString)

                        objDataRow.Item("M48") = Val(DGrid.Rows(Renglon).Cells("M48").Value.ToString)
                        objDataRow.Item("M48_") = Val(DGrid.Rows(Renglon).Cells("M48_").Value.ToString)

                        objDataRow.Item("M49") = Val(DGrid.Rows(Renglon).Cells("M49").Value.ToString)
                        objDataRow.Item("M49_") = Val(DGrid.Rows(Renglon).Cells("M49_").Value.ToString)

                        objDataRow.Item("M50") = Val(DGrid.Rows(Renglon).Cells("M50").Value.ToString)
                        objDataRow.Item("M50_") = Val(DGrid.Rows(Renglon).Cells("M50_").Value.ToString)

                        objDataRow.Item("importe") = DGrid.Rows(Renglon).Cells("importe").Value.ToString
                        objDataRow.Item("fechaentrega") = DGrid.Rows(Renglon).Cells("fechaentrega").Value.ToString
                        objDataRow.Item("fechacancela") = DGrid.Rows(Renglon).Cells("fechacancela").Value.ToString
                        objDataRow.Item("l1") = DGrid.Rows(Renglon).Cells("l1").Value.ToString
                        objDataRow.Item("l2") = DGrid.Rows(Renglon).Cells("l2").Value.ToString
                        objDataRow.Item("l3") = DGrid.Rows(Renglon).Cells("l3").Value.ToString
                        objDataRow.Item("l4") = DGrid.Rows(Renglon).Cells("l4").Value.ToString
                        objDataRow.Item("l5") = DGrid.Rows(Renglon).Cells("l5").Value.ToString
                        objDataRow.Item("l6") = DGrid.Rows(Renglon).Cells("16").Value.ToString
                        objDataRow.Item("estructura") = DGrid.Rows(Renglon).Cells("estructura").Value.ToString
                        objDataRow.Item("serie") = DGrid.Rows(Renglon).Cells("serie").Value.ToString
                        objDataRow.Item("idarticulo") = DGrid.Rows(Renglon).Cells("idarticulo").Value.ToString

                        'Add the DataRow to the DataSet
                        ObjDataSet.Tables(0).Rows.Add(objDataRow)

                        'Add the Project

                        If Not objPedidos.usp_Captura_PedidoTemp(1, ObjDataSet) Then
                            Throw New Exception("Falló Inserción de PedidoTemp ")
                        End If
                        ObjDataSet.Dispose()
                        objDataRow.Table.Dispose()

                    End Using

                Next


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try


            Inserta_PedidoTemp = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    'Function Inserta_Det_Dp(ByVal DevoProv As String, ByVal Renglon As Integer, ByVal Cantidad As Integer) As Boolean
    '    'mreyes 13/Junio/2013 10:32 a.m.
    '    Try
    '        Dim Serie As String = ""
    '        Dim ObjDataSet1 As Data.DataSet
    '        Dim ObjDataSet As Data.DataSet
    '        Dim J As Integer = 0
    '        Dim ordecomp1 As String = ""
    '        Dim sucurorc1 As String = ""
    '        Dim medida1 As String = ""
    '        Dim estilon1 As String = ""


    '        'INSERTAR CON CANTIDAD EN UNO POR CADA RECIBO... 

    '        For I As Integer = 24 To 123
    '            If DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow Then
    '                Cantidad = Val(DGrid.Rows(Renglon).Cells(I).Value)
    '                If Cantidad > 0 Then

    '                    If DGrid.Columns(I).HeaderText = "*" Then
    '                        medida1 = DGrid.Columns(I - 1).HeaderText & "-"
    '                    Else
    '                        medida1 = DGrid.Columns(I).HeaderText
    '                    End If

    '                    Using objPedidos1 As New BCL.BCLPedidos(GLB_ConStringCipSis)
    '                        ObjDataSet1 = objPedidos1.usp_TraerDet_FPDevoProv(Val(FolioB), DGrid.Rows(Renglon).Cells(11).Value.ToString, medida1)

    '                        If ObjDataSet1.Tables(0).Rows.Count > 0 Then
    '                            If J <= Cantidad And Cantidad > 0 Then
    '                                For x As Integer = 0 To ObjDataSet1.Tables(0).Rows.Count - 1
    '                                    Serie = ObjDataSet1.Tables(0).Rows(x).Item("serie").ToString

    '                                    Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
    '                                        ObjDataSet = objPedidos.Inserta_Det_dp  'INSERTA NUEVO DATASET
    '                                        Dim objDataRow As Data.DataRow = ObjDataSet.Tables(0).NewRow


    '                                        objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
    '                                        objDataRow.Item("devoprov") = DevoProv
    '                                        objDataRow.Item("marca") = Trim(Txt_Marca.Text)
    '                                        objDataRow.Item("estilon") = DGrid.Rows(Renglon).Cells(11).Value.ToString '' 'ESTILON
    '                                        objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells("c").Value.ToString
    '                                        objDataRow.Item("medida") = ObjDataSet1.Tables(0).Rows(0).Item("medida").ToString
    '                                        objDataRow.Item("serie") = Serie
    '                                        objDataRow.Item("ctd") = 1
    '                                        objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("costo").Value
    '                                        objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("pcomp").Value
    '                                        'Add the DataRow to the DataSet
    '                                        ObjDataSet.Tables(0).Rows.Add(objDataRow)

    '                                        'Add the Project

    '                                        If Not objPedidos.usp_Captura_Det_dp(1, ObjDataSet) Then
    '                                            Throw New Exception("Falló Inserción de Detalle ")
    '                                        End If
    '                                        ObjDataSet.Dispose()
    '                                        objDataRow.Table.Dispose()
    '                                        J = J + 1

    '                                        Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
    '                                            objCantArti.usp_ActualizarSerieDEVOPROV(Serie)
    '                                        End Using


    '                                    End Using
    '                                Next
    '                            End If
    '                        End If

    '                    End Using
    '                End If

    '            End If
    '        Next




    '        Inserta_Det_Dp = True

    '    Catch ExceptionErr As Exception
    '        MessageBox.Show(ExceptionErr.Message.ToString)
    '    End Try
    'End Function
    Function Inserta_Det_Dp(ByVal DevoProv As String, ByVal Renglon As Integer, ByVal Cantidad As Integer) As Boolean
        'mreyes 13/Junio/2013 10:32 a.m.
        Try
            Dim Serie As String = ""
            Dim ObjDataSet1 As Data.DataSet
            Dim ObjDataSet As Data.DataSet
            'Dim J As Integer = 0
            Dim ordecomp1 As String = ""
            Dim sucurorc1 As String = ""
            Dim medida1 As String = ""
            Dim estilon1 As String = ""


            'INSERTAR CON CANTIDAD EN UNO POR CADA RECIBO... 
            If Sw_Serie = False Then
                For I As Integer = 24 To 123
                    If DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow Then
                        Cantidad = Val(DGrid.Rows(Renglon).Cells(I).Value)
                        If Cantidad > 0 Then

                            If DGrid.Columns(I).HeaderText = "*" Then
                                medida1 = DGrid.Columns(I - 1).HeaderText & "-"
                            Else
                                medida1 = DGrid.Columns(I).HeaderText
                            End If

                            Using objPedidos1 As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                ObjDataSet1 = objPedidos1.usp_TraerDet_FPDevoProv(Val(FolioB), DGrid.Rows(Renglon).Cells(11).Value.ToString, medida1)

                                If ObjDataSet1.Tables(0).Rows.Count > 0 Then
                                    If Cantidad > 0 Then
                                        Dim CONTADORAUX As Integer = 0
                                        For x As Integer = 0 To ObjDataSet1.Tables(0).Rows.Count - 1
                                            If CONTADORAUX < Cantidad Then


                                                Serie = ObjDataSet1.Tables(0).Rows(x).Item("serie").ToString

                                                Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                                                    ObjDataSet = objPedidos.Inserta_Det_dp  'INSERTA NUEVO DATASET
                                                    Dim objDataRow As Data.DataRow = ObjDataSet.Tables(0).NewRow


                                                    objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                                                    objDataRow.Item("devoprov") = DevoProv
                                                    objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                                                    objDataRow.Item("estilon") = DGrid.Rows(Renglon).Cells(11).Value.ToString '' 'ESTILON
                                                    objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells("c").Value.ToString
                                                    objDataRow.Item("medida") = ObjDataSet1.Tables(0).Rows(0).Item("medida").ToString
                                                    objDataRow.Item("serie") = Serie
                                                    objDataRow.Item("ctd") = 1
                                                    'objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("costo").Value
                                                    'objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("pcomp").Value
                                                    objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("pcomp").Value
                                                    objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("costo").Value
                                                    'Add the DataRow to the DataSet
                                                    ObjDataSet.Tables(0).Rows.Add(objDataRow)

                                                    'Add the Project

                                                    If Not objPedidos.usp_Captura_Det_dp(1, ObjDataSet) Then
                                                        Throw New Exception("Falló Inserción de Det_DP ")
                                                    End If
                                                    ObjDataSet.Dispose()
                                                    objDataRow.Table.Dispose()
                                                    'J = J + 1

                                                    Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                                        objCantArti.usp_ActualizarSerieDEVOPROV(Serie)
                                                    End Using


                                                End Using
                                                CONTADORAUX += 1
                                            End If
                                        Next
                                    End If
                                End If

                            End Using
                        End If

                    End If
                Next
            Else '' 'es serie por serie

                'For I As Integer = 1 To DGrid.RowCount - 1
                Using objPedidos As New BCL.BCLFacturas(GLB_ConStringCipSis)
                    ObjDataSet = objPedidos.Inserta_Det_dp  'INSERTA NUEVO DATASET
                    Dim objDataRow As Data.DataRow = ObjDataSet.Tables(0).NewRow

                    Serie = DGrid.Rows(Renglon).Cells("serie").Value.ToString

                    objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                    objDataRow.Item("devoprov") = DevoProv
                    objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                    objDataRow.Item("estilon") = DGrid.Rows(Renglon).Cells(11).Value.ToString '' 'ESTILON
                    objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells("c").Value.ToString
                    objDataRow.Item("medida") = DGrid.Rows(Renglon).Cells("de").Value.ToString
                    objDataRow.Item("serie") = DGrid.Rows(Renglon).Cells("serie").Value.ToString
                    objDataRow.Item("ctd") = 1
                    objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("costo").Value
                    objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("pcomp").Value
                    'Add the DataRow to the DataSet
                    ObjDataSet.Tables(0).Rows.Add(objDataRow)

                    'Add the Project

                    If Not objPedidos.usp_Captura_Det_dp(1, ObjDataSet) Then
                        Throw New Exception("Falló Inserción de Det_DP ")
                    End If
                    ObjDataSet.Dispose()
                    objDataRow.Table.Dispose()
                    'J = J + 1

                    Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        objCantArti.usp_ActualizarSerieDEVOPROV(Serie)
                    End Using


                End Using

                ' Next
            End If '' del sw_serie 


            Inserta_Det_Dp = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Function Inserta_Det_oc(ByVal OrdeComp As String, ByVal Renglon As Integer) As Boolean
        Try

            'mreyes 15/Febrero/2012 01:31 p.m.
            If DGrid.Rows(Renglon).Cells("ta").Value = "" Then Inserta_Det_oc = True : Exit Function
            If Val(DGrid.Rows(Renglon).Cells("prs").Value) = 0 Then Inserta_Det_oc = True : Exit Function

            For I As Integer = 24 To 123
                If DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow Then
                    Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        'Get a new Project DataSet
                        Try
                            'BIZARRO
                            'If Val(DGrid.Rows(Renglon).Cells(I).Value) <> 0 Then
                            objDataSet = objPedidos.Inserta_Det_oc  'INSERTA NUEVO DATASET
                            Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow


                            objDataRow.Item("sucursal") = Trim(Txt_Sucursal.Text)
                            objDataRow.Item("ordecomp") = OrdeComp
                            objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                            objDataRow.Item("estilon") = DGrid.Rows(Renglon).Cells(11).Value.ToString '' 'ESTILON
                            objDataRow.Item("corrida") = DGrid.Rows(Renglon).Cells("c").Value.ToString
                            If DGrid.Columns(I).HeaderText = "*" Then
                                objDataRow.Item("medida") = DGrid.Columns(I - 1).HeaderText & "-"
                            Else
                                objDataRow.Item("medida") = DGrid.Columns(I).HeaderText
                            End If
                            objDataRow.Item("ctd") = Val(DGrid.Rows(Renglon).Cells(I).Value)
                            ' objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("pcomp").Value
                            'objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("costo").Value
                            objDataRow.Item("costo") = DGrid.Rows(Renglon).Cells("costo").Value
                            objDataRow.Item("costdesc") = DGrid.Rows(Renglon).Cells("pcomp").Value
                            objDataRow.Item("precio") = DGrid.Rows(Renglon).Cells("precio").Value

                            objDataRow.Item("entrega") = DGrid.Rows(Renglon).Cells("fechaentrega").Value
                            objDataRow.Item("cancela") = DGrid.Rows(Renglon).Cells("fechacancela").Value

                            'Add the DataRow to the DataSet
                            objDataSet.Tables(0).Rows.Add(objDataRow)

                            'Add the Project

                            If Not objPedidos.usp_Captura_Det_oc(1, objDataSet) Then
                                Throw New Exception("Falló Inserción de Det_OC ")
                            End If



                            If Sw_PedidoNuevo = False And Btn_Transferir.Enabled = False Then
                                Dim Medida As String
                                If DGrid.Columns(I).HeaderText = "*" Then
                                    Medida = DGrid.Columns(I - 1).HeaderText & "-"
                                Else
                                    Medida = DGrid.Columns(I).HeaderText
                                End If

                                If ActualizarCantSolMedida(Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value.ToString, DGrid.Rows(Renglon).Cells("c").Value.ToString, Medida) = False Then

                                    ' Throw New Exception("Fallo actualización de cantidad solicitada")
                                End If

                            End If
                            objDataSet.Dispose()
                            objDataRow.Table.Dispose()
                            ' End If
                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If
            Next
            Inserta_Det_oc = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Public Sub pub_PonerFecha()
        'mreyes 24/Febrero/2012 12:03 p.m.
        Try
            Dim Fecha As Date = GLB_FechaHoy
            Dim Fecha1 As Date = GLB_FechaHoy
            For renglon As Integer = 0 To DGrid.RowCount - 2

                If DGrid.Rows(renglon).Cells(125).Value = Nothing Then

                    DGrid.Rows(renglon).Cells(125).Value = Format(Fecha, "yyyy-MM-dd")

                ElseIf DGrid.Rows(renglon).Cells(125).Value.ToString.Length = 0 Then
                    DGrid.Rows(renglon).Cells(125).Value = Format(Fecha, "yyyy-MM-dd")
                ElseIf IsDBNull(DGrid.Rows(renglon).Cells(125).Value) = True Then
                    DGrid.Rows(renglon).Cells(125).Value = Format(Fecha, "yyyy-MM-dd")

                ElseIf DGrid.Rows(renglon).Cells(125).ToString.Length = 0 Then
                    DGrid.Rows(renglon).Cells(125).Value = Format(Fecha, "yyyy-MM-dd")

                ElseIf DGrid.Rows(renglon).Cells(125).Value = Nothing Then
                    DGrid.Rows(renglon).Cells(125).Value = Format(Fecha, "yyyy-MM-dd")
                Else
                    Fecha = DGrid.Rows(renglon).Cells(125).Value
                End If

                If DGrid.Rows(renglon).Cells(126).Value = Nothing Then
                    DGrid.Rows(renglon).Cells(126).Value = Format(Fecha1, "yyyy-MM-dd")
                ElseIf DGrid.Rows(renglon).Cells(126).Value.ToString.Length = 0 Then
                    DGrid.Rows(renglon).Cells(126).Value = Format(Fecha1, "yyyy-MM-dd")
                ElseIf IsDBNull(DGrid.Rows(renglon).Cells(126).Value) = True Then
                    DGrid.Rows(renglon).Cells(126).Value = Format(Fecha1, "yyyy-MM-dd")
                ElseIf DGrid.Rows(renglon).Cells(126).ToString.Length = 0 Then
                    DGrid.Rows(renglon).Cells(126).Value = Format(Fecha1, "yyyy-MM-dd")
                ElseIf DGrid.Rows(renglon).Cells(126).Value = Nothing Then
                    DGrid.Rows(renglon).Cells(126).Value = Format(Fecha1, "yyyy-MM-dd")
                Else
                    Fecha1 = DGrid.Rows(renglon).Cells(126).Value
                End If

            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try


    End Sub
    Private Function ValidarOrdeComp() As Boolean
        'mreyes 23/Febrero/2012 11:40 a.m.
        ValidarOrdeComp = False

        Call pub_PonerFecha()
        ''If pub_BuscarNoFechaGrid(DGrid, 125, "#12:00:00 AM#") = True Then
        ''    MsgBox("Debe especificar la Fecha de Entrega para cada uno de los estilos a solicitar", MsgBoxStyle.Critical, "Validación")
        ''    Exit Function
        ''End If

        ''If pub_BuscarNoFechaGrid(DGrid, 126, "#12:00:00 AM#") = True Then
        ''    MsgBox("Debe especificar la Fecha de Cancelación para cada uno de los estilos a solicitar", MsgBoxStyle.Critical, "Validación")
        ''    Exit Function
        ''End If
        ' validar que tenga la sucursal TODOS LOS ESTILOS.

        For I As Integer = 0 To DGrid.Rows.Count - 2
            If DGrid.Rows(I).Cells("ta").Value <> "" Then
                If DGrid.Rows(I).Cells("csuc").Value = "" Then
                    MsgBox("Debe especificar sucursal para la cual se pedirá el estilo", MsgBoxStyle.Critical, "Validación")

                    Exit Function
                End If
            End If

        Next


        ValidarOrdeComp = True
    End Function




    Private Function ValidarDETOrdeComp() As Boolean
        'mreyes 03/Abril/2012 04:35 p.m.
        ValidarDETOrdeComp = False

        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid.CurrentCell.RowIndex

        If DGrid.Rows(renglon).Cells("ta").Value = "" Then
            MsgBox("Debe especificar el Tipo de Artículo para el estilo", MsgBoxStyle.Critical, "Validación")
            Exit Function
        End If

        If DGrid.Rows(renglon).Cells("fam").Value = "" Then
            MsgBox("Debe especificar la Familia para el estilo", MsgBoxStyle.Critical, "Validación")
            Exit Function
        End If

        If DGrid.Rows(renglon).Cells("lin").Value = "" Then
            MsgBox("Debe especificar la línea para el estilo", MsgBoxStyle.Critical, "Validación")
            Exit Function
        End If


        If DGrid.Rows(renglon).Cells("cat").Value = "" Then
            MsgBox("Debe especificar la categoría para el estilo", MsgBoxStyle.Critical, "Validación")
            Exit Function
        End If

        If DGrid.Rows(renglon).Cells("estilofabrica").Value = "" Then
            MsgBox("Debe especificar el estilo de fabrica para el estilo", MsgBoxStyle.Critical, "Validación")
            Exit Function
        End If
        ValidarDETOrdeComp = True
    End Function
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        'mreyes 16/Febrero/2012 09:42 a.m.
        Try
            Dim Letrero As String = ""

            If Sw_FacturaNueva = False Then
                Letrero = "Orden de Compra"
            Else
                Letrero = "Recibo a Detalle"
            End If

            If Sw_Devolucion = True Then
                Letrero = "Cargo por Devolución"
            End If

            If ValidarOrdeComp() = False Then Exit Sub
            If Val(Txt_Pares.Text) = 0 Then
                MsgBox("No puede grabar una '" & Letrero & "' sin valores en pares.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If Accion = 1 Then '''' es un articulo nuevo
                If Sw_FacturaNueva = False And Sw_Devolucion = False Then

                    If MsgBox("Estas Seguro de Generar la '" & Letrero & "'", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        If MsgBox("Desea enviar el archivo de orden de compra al proveedor.?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Yes Then
                            Sw_EnviarCorreo = True
                        Else
                            Sw_EnviarCorreo = False
                            Sw_PedidoMano = False
                            If MsgBox("Entregará el pedido en mano del proveedor?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                                Sw_PedidoMano = True
                            End If

                        End If
                        ' ORDENAR COLUMNAS POR FECHA DE ENTREGA 
                        ' DGrid.Columns("fechaentrega").SortMode = DataGridViewColumnSortMode.Automatic
                        Me.Cursor = Cursors.WaitCursor
                        If GLB_PedidoExcel = True Then
                            '    If MsgBox("Desea enviar el pedido a un archivo de Excel.?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar") Then
                            If ExportarDGridAExcel(DGrid, False, True) = False Then
                                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
                            End If
                            'End If
                        End If
                        'DGrid.Sort(DGrid.Columns("fechaentrega"), System.ComponentModel.ListSortDirection.Ascending)
                        DGrid.Sort(DGrid.Columns("csuc"), System.ComponentModel.ListSortDirection.Ascending)
                        If Genera_OrdeComp() = True Then
                            Me.Cursor = Cursors.Default
                            Sw_Registro = True
                            GLB_RefrescarPedido = True
                            If Cont = 1 Then
                                MessageBox.Show("Se ha generado la orden de compra '" & ImpOrdeComp(0) & "'.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Else
                                MessageBox.Show("Se han generado '" & Cont & "' Ordenes de Compra.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            Cont = 0
                            '' checar porque no lo puedo cerrar 
                            Me.Dispose()
                            Me.Close()

                        Else
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else 'dela factura
                    If Sw_Devolucion = True Then

                        'EMPIEZA DEVO
                        If MsgBox("Estas Seguro de Generar la '" & Letrero & "'", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then

                            Me.Cursor = Cursors.WaitCursor

                            If Genera_DevoProv() = True Then
                                Me.Cursor = Cursors.Default
                                Sw_Registro = True
                                GLB_RefrescarPedido = True
                                MessageBox.Show("Se ha generado el Cargo por Devolución '" & ImpOrdeComp(1) & "'.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Cont = 0
                                'imprimir DEVO
                                'Genera Nota de Cargo por Devolucion
                                Call usp_TraerUltFolioNotaCC("CA")
                                Call CalculaImportesIVA()
                                If Inserta_Nota() = True Then
                                    ' MessageBox.Show("Se ha generado la Nota de Cargo por Devolución con el Folio '" & IdFolioNotaC.ToString & "'.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If

                                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, ImpOrdeComp(1), IIf(Sw_Serie = True, 34, 33))
                                'mOSTRAR LAS SERIES 
                                Txt_OrdeComp.Text = ImpOrdeComp(1)
                                If Sw_Serie = False Then
                                    Call Btn_Series_Click(sender, e)
                                End If
                                Me.Dispose()
                                Me.Close()
                            Else
                                Me.Cursor = Cursors.Default
                                MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            'TERMINA DEVO

                        End If
                    Else
                        If ValidarDatos() = False Then Exit Sub
                        ''PRUEBA
                        'Sw_FacturaNueva = True
                        If Accion = 1 Then Call TotalizadosFactura(False, 0)
                        Call CalculaFechaVence()
                        If MsgBox("Estas Seguro de Generar la '" & Letrero & "'", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                            Btn_Aceptar.Enabled = False
                            Me.Cursor = Cursors.WaitCursor

                            If Genera_FactProv() = True Then
                                Me.Cursor = Cursors.Default
                                Sw_Registro = True
                                GLB_RefrescarPedido = True
                                MessageBox.Show("Se ha generado la Entrada '" & ImpOrdeComp(1) & "'.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Cont = 0
                                'imprimir factura
                                If ActualizarBulto() = False Then
                                    Me.Cursor = Cursors.Default
                                    MessageBox.Show("Error Actualizando Bulto, el proceso continuará. !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    'Exit Sub
                                End If
                                If Genera_BultosCodigos() = False Then
                                    Me.Cursor = Cursors.Default
                                    MessageBox.Show("Error Actualizando Códigos de Bulto, el proceso continuará. !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    'Exi
                                End If

                                'traer folio de bulto apra poderlo imprimir
                                'x()
                                ' pub_TraerIdFolioBulto(FolioB)
                                If Txt_NoBulto.Text = "" Then
                                    Txt_NoBulto.Text = usp_TraerIdFolioSucBulto(FolioB)
                                End If
                                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 13)
                                ' Quitar provisional 
                                Btn_Aceptar.Enabled = True
                                'If Sw_ProvDif = True Then
                                '    Dim myForm1 As New frmCatalogoPagosTarjetas

                                '    myForm1.Txt_Total.Text = Txt_Total.Text
                                '    myForm1.ShowDialog()
                                'End If
                                ' Generar la información de recibo de bultos..



                                '                MsgBox("No se pudo realizar la impresión de etiquetas para calzado.", MsgBoxStyle.Critical, "Error")
                                '               MsgBox("No se pudo realizar la impresión de etiquetas para bultos.", MsgBoxStyle.Critical, "Error")

                                Me.Dispose()
                                Me.Close()
                            Else
                                Me.Cursor = Cursors.Default
                                MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If ' DEL DEVOLUCION
                    End If
                End If
            ElseIf Accion = 2 Then ' es una actualización
                If Sw_FacturaNueva = False And Sw_Factura = False Then
                    If MsgBox("Estas Seguro de Actualizar la Orden de Compra?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        Me.Cursor = Cursors.WaitCursor
                        If Inserta_OrdeComp(Txt_OrdeComp.Text) = True Then
                            If Eliminar_Det_Oc() = True Then
                                If Editar_Det_Oc() = True Then
                                    Me.Cursor = Cursors.Default
                                    ' SI VIENE DE BITACORA GENERAR UN SEGUIMIENTO POR CAMBIO DE FECHA 

                                    If Sw_Bitacora = True Then
                                        If Inserta_SigBit(Txt_FechaEntrega.Text, DGrid.Rows(0).Cells("fechaentrega").Value, Txt_OrdeComp.Text) = False Then

                                        End If
                                    End If

                                    GLB_RefrescarPedido = True
                                    MessageBox.Show("Exitosamente grabada la Ordenes de Compra '" & Txt_OrdeComp.Text & "'", "Actualizando Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Sw_Registro = True
                                    If Sw_Bitacora = False Then
                                        If MsgBox("Desea enviar el archivo de orden de compra al proveedor.?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Yes Then
                                            Sw_EnviarCorreo = True
                                            Sw_SoloPasoPDF = True
                                            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 0)
                                            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 1)
                                            If Sw_EnviarCorreo = True Then
                                                If EnviarCorreo(Txt_OrdeComp.Text, False) = False Then
                                                    MsgBox("Error al enviar correo. Intente de nuevo mas tarde.", MsgBoxStyle.Critical, "Aviso")
                                                Else
                                                    If Inserta_SigBit("1900-01-01", "1900-01-01", Txt_OrdeComp.Text) = False Then

                                                    End If
                                                    '' Enviar correo a Mary
                                                    If EnviarCorreo(Txt_OrdeComp.Text, True) = False Then

                                                    End If
                                                End If
                                            End If
                                        Else
                                            Sw_EnviarCorreo = False
                                            Sw_EnviarCorreo = False
                                            Sw_PedidoMano = False
                                            If MsgBox("Entregará el pedido en mano del proveedor?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                                                Sw_PedidoMano = True
                                            End If
                                        End If
                                    End If '' del bitácora
                                    Me.Dispose()
                                    Me.Close()

                                Else
                                    Me.Cursor = Cursors.Default
                                    MessageBox.Show("Error Grabando !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        End If

                    End If
                ElseIf Sw_Devolucion = False Then
                    If MsgBox("Estas Seguro de Actualizar la Entrada?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                        Me.Cursor = Cursors.WaitCursor
                        'mreyes 10/Mayo/2016    11:10 a.m.
                        ' Se agrega se actualice el detallado .. 

                        If Inserta_FactProv(Txt_FactProv.Text) = True Then

                        End If

                        If Modificar_Det_fp(Txt_FactProv.Text) = False Then

                        End If

                        GLB_RefrescarPedido = True
                    End If
                    Me.Dispose()
                    Me.Close()
                Else
                    ''If MsgBox("Estas Seguro de Actualizar la Devolución?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                    ''    Me.Cursor = Cursors.WaitCursor
                    ''    If Inserta_DevoProv(Txt_OrdeComp.Text) = True Then

                    ''    End If
                    ''    Call CalculaImportesIVA()
                    ''    If Inserta_Nota() = True Then
                    ''        ' MessageBox.Show("Se ha generado la Nota de Cargo por Devolución con el Folio '" & IdFolioNotaC.ToString & "'.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ''    End If
                    ''    GLB_RefrescarPedido = True
                    ''End If
                    ''Me.Dispose()
                    ''Me.Close()
                End If
            ElseIf Accion = 4 Then
                Me.Close()
                Me.Dispose()
            End If '' del if de accion = 1 


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Private Function Editar_Det_Oc() As Boolean
        'mreyes 18/Febrero/2012 01:59 p.m.
        Try
            For I As Integer = 0 To DGrid.Rows.Count - 2
                If Inserta_Det_oc(Txt_OrdeComp.Text, I) = False Then
                    Editar_Det_Oc = False
                End If
            Next
            Editar_Det_Oc = True
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Function Eliminar_Det_Oc() As Boolean
        'mreyes 18/Febrero/2012 01:47 p.m.

        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                Eliminar_Det_Oc = objPedidos.usp_EliminarDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Private Function ActualizarCantSolMedida(ByVal Marca As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Medida As String) As Boolean
        'mreyes 23/Marzo/2012 07:19 p.m.

        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                'Get the specific project selected in the ListView control
                ActualizarCantSolMedida = objPedidos.usp_ActualizarCantSolMedida(Marca, Estilon, Corrida, Medida)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function



    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'mreyes 13/Febrero/2011 11:25 a.m.
        'Función para validar la escritura en cada una de las columnas del detalle de pedido
        Try
            ' obtener indice de la columna  
            If ValidarDatos() = False Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If
            If Accion = 3 Or Accion = 4 Then
                e.KeyChar = Chr(0)
                Exit Sub
            End If



            e.KeyChar = UCase(e.KeyChar)
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim caracter As Char = e.KeyChar
            Dim CaracterAnt As String = ""
            Dim FechaEntregaMaxAnterior As Date
            ' comprobar si la celda en edición corresponde a la columna 1 o 3   





            '' ''If columna = 6 Then ''columna de tipo de articulo

            '' ''    ' comprobar si el caracter es un número o el retroceso   
            '' ''    If Not (Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False) Then
            '' ''        'Me.Text = e.KeyChar   
            '' ''        e.KeyChar = Chr(0)
            '' ''        ' validar tipo de articulo

            '' ''    End If
            '' ''End If
            ' COLUMNA DE FAMILIA

            ' columnas donde se especifica la medida por corrida
            ' COLUMNA 24 ES 9 , A LA 65, EN CORRIDA 
            If columna >= 24 And columna <= 123 Then

                If DGrid.Rows(renglon).Cells(columna).Style.BackColor <> Color.Yellow Then
                    e.KeyChar = Chr(0)
                End If
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    e.KeyChar = Chr(0)
                End If

                If Sw_Factura = True Or Sw_FacturaNueva = True Then
                    FechaEntregaMaxAnterior = DGrid.Rows(renglon).Cells("fechaentrega").Value
                    If FechaEntregaMaxAnterior > FechaEntregaMax Then
                        FechaEntregaMax = FechaEntregaMaxAnterior
                    End If
                End If

                If Txt_FechaFactura.Text.Length > 0 And Txt_Diaspp.Text.Length > 0 Then
                    Txt_FechaVence.Text = Format(pub_FechaVence(Txt_FechaFactura.Text, Txt_Diaspp.Text), "yyyy-MM-dd")
                    Txt_FechaVence.Text = Format(pub_FechaVence(Txt_Fecha.Text, Txt_Diaspp.Text), "yyyy-MM-dd")

                    If FechaEntregaMax <> "1900-01-01" Then
                        If CDate(FechaEntregaMax) > CDate(Txt_Fecha.Text) Then
                            Txt_FechaVence.Text = Format(pub_FechaVence(FechaEntregaMax, Txt_Diaspp.Text), "yyyy-MM-dd")
                        End If

                    End If

                End If
                If Txt_FechaFactura.Text.Length > 0 Then
                    Txt_FechaFactura.Text = Format(CDate(Txt_FechaFactura.Text), "yyyy-MM-dd")
                End If



            End If


            ' termina columnas donde se especifica la medida por corrida 


            '' columna de orden de compra... 

            If columna = 1 Or columna = 0 Then '' columna de i
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    e.KeyChar = Chr(0)
                End If
            End If

            '' COLULUMNA DE CORRIDA 
            'If columna = 0 Then ''columna de corrida

            '    ' Obtener caracter   


            '    ' comprobar si el caracter es un número o el retroceso   
            '    If Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            '        'Me.Text = e.KeyChar   
            '        e.KeyChar = Chr(0)
            '    Else
            '        If caracter = "A" Or caracter = "B" Or caracter = "C" Or caracter = "D" Or caracter = "E" Or caracter = "F" Then
            '            e.KeyChar = UCase(caracter)
            '        Else
            '            e.KeyChar = Chr(0)
            '        End If
            '    End If
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TxtGrid(ByVal txt_campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:23 p.m.
        Dim myForm As New frmConsulta
        '  Dim myFormEstilos As New frmCatalogoModelos

        If txt_campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            Try
                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, txt_campo.Text, "")
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Campo1.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    'tRAER LOS IDSUPERIOR.
                    If Tipo = "EDI" Then IdDivision = objDataSet.Tables(0).Rows(0).Item("iddivisiones")
                    If Tipo = "ED" Then IdDepto = objDataSet.Tables(0).Rows(0).Item("iddepto")
                    If Tipo = "EF" Then IdFamilia = objDataSet.Tables(0).Rows(0).Item("idfamilia")
                    If Tipo = "EL" Then IdLinea = objDataSet.Tables(0).Rows(0).Item("idlinea")
                    If Tipo = "L1" Then IdL1 = objDataSet.Tables(0).Rows(0).Item("idl1")
                    If Tipo = "L2" Then IdL2 = objDataSet.Tables(0).Rows(0).Item("idl2")
                    If Tipo = "L3" Then IdL3 = objDataSet.Tables(0).Rows(0).Item("idl3")
                    If Tipo = "L4" Then IdL4 = objDataSet.Tables(0).Rows(0).Item("idl4")
                    If Tipo = "L5" Then IdL5 = objDataSet.Tables(0).Rows(0).Item("idl5")
                    If Tipo = "L6" Then IdL6 = objDataSet.Tables(0).Rows(0).Item("idl6")


                Else
                    txt_campo.Text = ""
                    If Tipo <> "E" Then
                        myForm.Tipo = Tipo
                        If Tipo = "ED" Then
                            myForm.IdSuperior1 = IdDivision
                        End If
                        If Tipo = "EF" Then
                            myForm.IdSuperior1 = IdDepto
                            myForm.IdSuperior2 = IdDivision
                        End If
                        If Tipo = "EL" Then
                            myForm.IdSuperior1 = IdFamilia
                            myForm.IdSuperior2 = IdDepto
                            myForm.IdSuperior3 = IdDivision

                        End If
                        If Tipo = "L1" Then
                            myForm.IdSuperior1 = IdLinea
                            myForm.IdSuperior2 = IdFamilia
                            myForm.IdSuperior3 = IdDepto
                            myForm.IdSuperior4 = IdDivision

                        End If
                        If Tipo = "L2" Then
                            myForm.IdSuperior1 = IdL1
                            myForm.IdSuperior2 = IdLinea
                            myForm.IdSuperior3 = IdFamilia
                            myForm.IdSuperior4 = IdDepto
                            myForm.IdSuperior5 = IdDivision
                        End If

                        If Tipo = "L3" Then
                            myForm.IdSuperior1 = IdL2
                            myForm.IdSuperior2 = IdL1
                            myForm.IdSuperior3 = IdLinea
                            myForm.IdSuperior4 = IdFamilia
                            myForm.IdSuperior5 = IdDepto
                            myForm.IdSuperior6 = IdDivision
                        End If

                        If Tipo = "L4" Then
                            myForm.IdSuperior1 = IdL3
                            myForm.IdSuperior2 = IdL2
                            myForm.IdSuperior3 = IdL1
                            myForm.IdSuperior4 = IdLinea
                            myForm.IdSuperior5 = IdFamilia
                            myForm.IdSuperior6 = IdDepto
                            myForm.IdSuperior7 = IdDivision
                        End If

                        If Tipo = "L5" Then
                            myForm.IdSuperior1 = IdL4
                            myForm.IdSuperior2 = IdL3
                            myForm.IdSuperior3 = IdL2
                            myForm.IdSuperior4 = IdL1
                            myForm.IdSuperior5 = IdLinea
                            myForm.IdSuperior6 = IdFamilia
                            myForm.IdSuperior7 = IdDepto
                            myForm.IdSuperior8 = IdDivision
                        End If

                        If Tipo = "L6" Then
                            myForm.IdSuperior1 = IdL5
                            myForm.IdSuperior2 = IdL4
                            myForm.IdSuperior3 = IdL3
                            myForm.IdSuperior4 = IdL2
                            myForm.IdSuperior5 = IdL1
                            myForm.IdSuperior6 = IdLinea
                            myForm.IdSuperior7 = IdFamilia
                            myForm.IdSuperior8 = IdDepto
                            myForm.IdSuperior9 = IdDivision
                        End If

                        ''''myForm.IdSuperior2 = IdSuperior2
                        ''''myForm.IdSuperior3 = IdSuperior3
                        ''''myForm.IdSuperior4 = IdSuperior4
                        ''''myForm.IdSuperior5 = IdSuperior5
                        ''''myForm.IdSuperior6 = IdSuperior6
                        ''''myForm.IdSuperior7 = IdSuperior7
                        ''''myForm.IdSuperior8 = IdSuperior8
                        ''''myForm.IdSuperior9 = IdSuperior9
                        ''''myForm.idsuperior10 = idsuperior10

                        myForm.ShowDialog()
                        txt_campo.Text = myForm.Campo1
                        Txt_Campo1.Text = myForm.Campo2

                        ''If Txt_Campo.Text.Length = 0 Then
                        ''    Txt_Campo.Focus()
                        ''End If
                        If IdDivision = 0 Then IdDivision = myForm.IdSuperior1
                        If IdDepto = 0 Then IdDepto = myForm.IdSuperior2
                        If IdFamilia = 0 Then IdFamilia = myForm.IdSuperior3
                        If IdLinea = 0 Then IdLinea = myForm.IdSuperior4
                        If IdL1 = 0 Then IdL1 = myForm.IdSuperior5
                        If IdL2 = 0 Then IdL2 = myForm.IdSuperior6
                        If IdL3 = 0 Then IdL3 = myForm.IdSuperior7
                        If IdL4 = 0 Then IdL4 = myForm.IdSuperior8
                        If IdL5 = 0 Then IdL5 = myForm.IdSuperior9
                        If IdL6 = 0 Then IdL6 = myForm.IdSuperior10

                        If txt_campo.Text.Trim.Length < 3 Then
                            txt_campo.Text = pub_RellenarIzquierda(txt_campo.Text.Trim, 3)
                        End If
                    End If
                End If


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub DGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DGrid.CellBeginEdit
        'mreyes 24/Mayo/2012 01:35 p.m.
        Try
            If Sw_FacturaNueva = True Or Sw_Factura = True Then
                If Sw_Validar = False Then Exit Sub
                Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
                Dim renglon As Integer = DGrid.CurrentCell.RowIndex
                If columna >= 24 And columna <= 123 Then
                    CEscritoAnt = DGrid.Rows(renglon).Cells(columna).Value

                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub TraerSucursalesSelect(ByVal Renglon As Integer)
        'mreyes 03/Julio/2012 07:15 p.m.
        Dim objDataSetCos As Data.DataSet

        If IntSelect = 1 Then Exit Sub
        Using objPedidos As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try

                Dim i As Integer = 0
                Dim Cont As Integer = 1
                Dim Residuo
                Dim Renglon1 As Integer = 0
                Colores = Colores + 1

                Residuo = Colores Mod 2

                DGrid.Rows(Renglon).Cells("csuc").Value = SucSelect(0)
                DGrid.Rows(Renglon).Cells("sucdescrip").Value = pub_TraerNomSucursal(SucSelect(0))
                Renglon1 = Renglon
                For i = 1 To IntSelect - 1

                    If i = 1 And Renglon <> 0 Then
                        'agregar renglon 
                        'copiar el renglon al siguiente... 
                        DGrid.Rows.Add()

                        DGrid.Rows(Renglon).ReadOnly = False
                        DGrid.Rows(Renglon).DefaultCellStyle.BackColor = Color.PowderBlue
                        Renglon = Renglon + 1
                        ' copiar 
                        DGrid.Rows(Renglon).Cells("ta").Value = DGrid.Rows(Renglon - 1).Cells("ta").Value
                        DGrid.Rows(Renglon).Cells("fam").Value = DGrid.Rows(Renglon - 1).Cells("fam").Value
                        DGrid.Rows(Renglon).Cells("cat").Value = DGrid.Rows(Renglon - 1).Cells("cat").Value
                        DGrid.Rows(Renglon).Cells("lin").Value = DGrid.Rows(Renglon - 1).Cells("lin").Value
                        DGrid.Rows(Renglon).Cells("estructura").Value = DGrid.Rows(Renglon - 1).Cells("estructura").Value
                        DGrid.Rows(Renglon).Cells("l1").Value = DGrid.Rows(Renglon - 1).Cells("l1").Value
                        DGrid.Rows(Renglon).Cells("l2").Value = DGrid.Rows(Renglon - 1).Cells("l2").Value
                        DGrid.Rows(Renglon).Cells("l3").Value = DGrid.Rows(Renglon - 1).Cells("l3").Value
                        DGrid.Rows(Renglon).Cells("l4").Value = DGrid.Rows(Renglon - 1).Cells("l4").Value
                        DGrid.Rows(Renglon).Cells("l5").Value = DGrid.Rows(Renglon - 1).Cells("l5").Value
                        DGrid.Rows(Renglon).Cells("l6").Value = DGrid.Rows(Renglon - 1).Cells("l6").Value



                        DGrid.Rows(Renglon).Cells("descripcion").Value = DGrid.Rows(Renglon - 1).Cells("descripcion").Value
                        DGrid.Rows(Renglon).Cells("estilonuestro").Value = DGrid.Rows(Renglon - 1).Cells("estilonuestro").Value
                        DGrid.Rows(Renglon).Cells("estilofabrica").Value = DGrid.Rows(Renglon - 1).Cells("estilofabrica").Value
                        DGrid.Rows(Renglon).Cells("csuc").Value = SucSelect(i - 1)
                        DGrid.Rows(Renglon).Cells("sucdescrip").Value = pub_TraerNomSucursal(SucSelect(i - 1))
                        DGrid.Rows(Renglon).Cells("c").Value = DGrid.Rows(Renglon - 1).Cells("c").Value
                        DGrid.Rows(Renglon).Cells("i").Value = DGrid.Rows(Renglon - 1).Cells("i").Value
                        DGrid.Rows(Renglon).Cells("de").Value = DGrid.Rows(Renglon - 1).Cells("de").Value
                        DGrid.Rows(Renglon).Cells("a").Value = DGrid.Rows(Renglon - 1).Cells("a").Value

                        DGrid.Rows(Renglon).Cells("pcomp").Value = DGrid.Rows(Renglon - 1).Cells("pcomp").Value
                        DGrid.Rows(Renglon).Cells("precio").Value = DGrid.Rows(Renglon - 1).Cells("precio").Value
                        DGrid.Rows(Renglon).Cells("costo").Value = DGrid.Rows(Renglon - 1).Cells("costo").Value
                        DGrid.Rows(Renglon).Cells("porc").Value = DGrid.Rows(Renglon - 1).Cells("porc").Value


                        'ir por la corrida para precios y costos
                        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                            objDataSetCos = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(Renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, DGrid.Rows(Renglon - 1).Cells("c").Value, Txt_Proveedor.Text)

                            If objDataSetCos.Tables(0).Rows.Count > 0 Then
                                '' si existe estilo, traerlo.
                                ' 13 corrida, 14 intervalo, 15 medini, 16 medfin

                                DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(objDataSetCos.Tables(0).Rows(0).Item("costo").ToString), "#,##0.00")
                                DGrid.Rows(Renglon).Cells("precio").Value = Format(Val(objDataSetCos.Tables(0).Rows(0).Item("precio").ToString), "#,##0.00")
                                DGrid.Rows(Renglon).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(objDataSetCos.Tables(0).Rows(0).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
                                DGrid.Rows(Renglon).Cells("porc").Value = Format(pub_CalcularMargenPedido(Val(objDataSetCos.Tables(0).Rows(0).Item("precio")), DGrid.Rows(Renglon).Cells("costo").Value), "#0.00")


                            End If
                        End Using



                        For j As Integer = 24 To 123
                            DGrid.Rows(Renglon).Cells(j).Style.BackColor = DGrid.Rows(Renglon - 1).Cells(j).Style.BackColor
                            DGrid.Rows(Renglon - 1).Cells(j).Style.BackColor = Color.PowderBlue
                        Next

                        DGrid.Rows(Renglon - 1).Cells("ta").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("fam").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("cat").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("lin").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("estructura").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("l1").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("l2").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("l3").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("l4").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("l5").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("l6").Value = ""


                        DGrid.Rows(Renglon - 1).Cells("descripcion").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("estilonuestro").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("estilofabrica").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("csuc").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("sucdescrip").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("c").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("i").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("de").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("a").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("pcomp").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("precio").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("costo").Value = ""
                        DGrid.Rows(Renglon - 1).Cells("porc").Value = ""
                        DGrid.Rows(Renglon - 1).ReadOnly = False
                        DGrid.Rows(Renglon - 1).DefaultCellStyle.BackColor = Color.PowderBlue
                    End If
                    DGrid.Rows.Add()
                    DGrid.Rows(Renglon + Cont).Cells("ta").Value = DGrid.Rows(Renglon).Cells("ta").Value
                    DGrid.Rows(Renglon + Cont).Cells("fam").Value = DGrid.Rows(Renglon).Cells("fam").Value
                    DGrid.Rows(Renglon + Cont).Cells("cat").Value = DGrid.Rows(Renglon).Cells("cat").Value
                    DGrid.Rows(Renglon + Cont).Cells("lin").Value = DGrid.Rows(Renglon).Cells("lin").Value

                    DGrid.Rows(Renglon + Cont).Cells("estructura").Value = DGrid.Rows(Renglon).Cells("estructura").Value
                    DGrid.Rows(Renglon + Cont).Cells("l1").Value = DGrid.Rows(Renglon).Cells("l1").Value
                    DGrid.Rows(Renglon + Cont).Cells("l2").Value = DGrid.Rows(Renglon).Cells("l2").Value
                    DGrid.Rows(Renglon + Cont).Cells("l3").Value = DGrid.Rows(Renglon).Cells("l3").Value
                    DGrid.Rows(Renglon + Cont).Cells("l4").Value = DGrid.Rows(Renglon).Cells("l4").Value
                    DGrid.Rows(Renglon + Cont).Cells("l5").Value = DGrid.Rows(Renglon).Cells("l5").Value
                    DGrid.Rows(Renglon + Cont).Cells("l6").Value = DGrid.Rows(Renglon).Cells("l6").Value


                    DGrid.Rows(Renglon + Cont).Cells("descripcion").Value = DGrid.Rows(Renglon).Cells("descripcion").Value
                    DGrid.Rows(Renglon + Cont).Cells("estilonuestro").Value = DGrid.Rows(Renglon).Cells("estilonuestro").Value
                    DGrid.Rows(Renglon + Cont).Cells("estilofabrica").Value = DGrid.Rows(Renglon).Cells("estilofabrica").Value
                    DGrid.Rows(Renglon + Cont).Cells("csuc").Value = SucSelect(i)
                    DGrid.Rows(Renglon + Cont).Cells("sucdescrip").Value = pub_TraerNomSucursal(SucSelect(i))
                    DGrid.Rows(Renglon + Cont).Cells("c").Value = DGrid.Rows(Renglon).Cells("c").Value
                    DGrid.Rows(Renglon + Cont).Cells("i").Value = DGrid.Rows(Renglon).Cells("i").Value
                    DGrid.Rows(Renglon + Cont).Cells("de").Value = DGrid.Rows(Renglon).Cells("de").Value
                    DGrid.Rows(Renglon + Cont).Cells("a").Value = DGrid.Rows(Renglon).Cells("a").Value
                    DGrid.Rows(Renglon + Cont).Cells("pcomp").Value = DGrid.Rows(Renglon).Cells("pcomp").Value
                    DGrid.Rows(Renglon + Cont).Cells("precio").Value = DGrid.Rows(Renglon).Cells("precio").Value
                    DGrid.Rows(Renglon + Cont).Cells("costo").Value = DGrid.Rows(Renglon).Cells("costo").Value
                    DGrid.Rows(Renglon + Cont).Cells("porc").Value = DGrid.Rows(Renglon).Cells("porc").Value

                    'ir por la corrida para precios y costos
                    Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                        objDataSetCos = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(Renglon + Cont).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(Renglon + Cont).Cells(11).Value, DGrid.Rows(Renglon + Cont).Cells("c").Value, Txt_Proveedor.Text)

                        If objDataSetCos.Tables(0).Rows.Count > 0 Then
                            '' si existe estilo, traerlo.
                            ' 13 corrida, 14 intervalo, 15 medini, 16 medfin

                            DGrid.Rows(Renglon + Cont).Cells("pcomp").Value = Format(Val(objDataSetCos.Tables(0).Rows(0).Item("costo").ToString), "#,##0.00")
                            DGrid.Rows(Renglon + Cont).Cells("precio").Value = Format(Val(objDataSetCos.Tables(0).Rows(0).Item("precio").ToString), "#,##0.00")
                            DGrid.Rows(Renglon + Cont).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(objDataSetCos.Tables(0).Rows(0).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
                            DGrid.Rows(Renglon + Cont).Cells("porc").Value = Format(pub_CalcularMargenPedido(Val(objDataSetCos.Tables(0).Rows(0).Item("precio")), DGrid.Rows(Renglon + Cont).Cells("costo").Value), "#0.00")


                        End If
                    End Using


                    For j As Integer = 24 To 123
                        DGrid.Rows(Renglon + Cont).Cells(j).Style.BackColor = DGrid.Rows(Renglon).Cells(j).Style.BackColor
                    Next


                    ' si residuo es 1 es impar sino es par 
                    For J As Integer = 0 To 20
                        ' Color.Bisque  Color.Beige
                        DGrid.Rows(Renglon).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                        DGrid.Rows(Renglon + Cont).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                    Next
                    For J As Integer = 125 To 126
                        DGrid.Rows(Renglon).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                        DGrid.Rows(Renglon + Cont).Cells(J).Style.BackColor = IIf(Residuo = 1, Color.Salmon, Color.SandyBrown)
                    Next

                    Cont = Cont + 1
                Next

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub
    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick

        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid.CurrentCell.RowIndex

        If columna = 125 Or columna = 126 Then  '' columnas de fechas 
            For I As Integer = renglon + 1 To DGrid.RowCount - 2
                If DGrid.Rows(I).Cells("ta").Value <> "" Then
                    DGrid.Rows(I).Cells(125).Value = DGrid.Rows(renglon).Cells(125).Value
                    DGrid.Rows(I).Cells(126).Value = DGrid.Rows(renglon).Cells(126).Value
                End If
            Next
        End If
        If columna >= 24 And columna <= 123 Then  '' columnas de fechas 
            For I As Integer = renglon + 1 To DGrid.RowCount - 2
                If DGrid.Rows(I).Cells(columna).Style.BackColor = Color.Yellow Then
                    If DGrid.Rows(I).Cells("ta").Value <> "" Then
                        DGrid.Rows(I).Cells(columna).Value = DGrid.Rows(renglon).Cells(columna).Value
                        Call Totalizados(True, I)
                    End If
                End If

            Next


        End If
        ' si da doble click cambiar la fecha a todos los registros... 
        '' agregar un nuevo renglon en base a estilo...

        If columna >= 6 And columna <= 12 Then
            If DGrid.Rows(renglon).Cells("ta").Value <> "" Then
                DGrid.Rows.Add()
                DGrid.Rows(renglon + 1).Cells("ta").Value = DGrid.Rows(renglon).Cells("ta").Value
                DGrid.Rows(renglon + 1).Cells("fam").Value = DGrid.Rows(renglon).Cells("fam").Value
                DGrid.Rows(renglon + 1).Cells("cat").Value = DGrid.Rows(renglon).Cells("cat").Value
                DGrid.Rows(renglon + 1).Cells("lin").Value = DGrid.Rows(renglon).Cells("lin").Value

                DGrid.Rows(renglon + 1).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value
                DGrid.Rows(renglon + 1).Cells("l1").Value = DGrid.Rows(renglon).Cells("l1").Value
                DGrid.Rows(renglon + 1).Cells("l2").Value = DGrid.Rows(renglon).Cells("l2").Value
                DGrid.Rows(renglon + 1).Cells("l3").Value = DGrid.Rows(renglon).Cells("l3").Value
                DGrid.Rows(renglon + 1).Cells("l4").Value = DGrid.Rows(renglon).Cells("l4").Value
                DGrid.Rows(renglon + 1).Cells("l5").Value = DGrid.Rows(renglon).Cells("l5").Value
                DGrid.Rows(renglon + 1).Cells("l6").Value = DGrid.Rows(renglon).Cells("l6").Value


                DGrid.Rows(renglon + 1).Cells("descripcion").Value = DGrid.Rows(renglon).Cells("descripcion").Value
                DGrid.Rows(renglon + 1).Cells("estilonuestro").Value = DGrid.Rows(renglon).Cells("estilonuestro").Value
                DGrid.Rows(renglon + 1).Cells("estilofabrica").Value = DGrid.Rows(renglon).Cells("estilofabrica").Value
            End If

        End If

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

    Private Sub frmCatalogoPedidoNuevo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then
                If Accion = 1 Or Accion = 2 Then
                    If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

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
    Private Sub RellenaOrdeComp()
        'mreyes 24/Febrero/2012 05:57 p.m.
        Try
            Call usp_TraerOrdeComp()
            Call usp_TraerDet_Oc()
            For I As Integer = 0 To DGrid.RowCount - 2
                Call Totalizados(False, I)
            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenaFactura()
        'mreyes 24/Marzo/2012 01:24 p.m.
        Try
            Dim Descuento1 As Decimal = 0
            Dim Descuento2 As Decimal = 0
            Dim Total1 As Decimal = 0
            If Sw_Devolucion = True Then Lbl_Tipo.Text = "DEVOLUCIÓN" Else Lbl_Tipo.Text = "ENTRADA"
            Call usp_TraerFactProv()
            Call usp_TraerDet_FP()
            For I As Integer = 0 To DGrid.RowCount - 2
                Call Totalizados(False, I)
            Next

            If Val(Txt_Dscto01.Text) > 0 Then

                Total1 = (CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_NotaCargo.Text)) + CDbl(Txt_NotaCredito.Text)
                Descuento1 = Total1 * (Val(Txt_Dsctopp.Text) / 100)
                Descuento2 = (Total1 - Descuento1) * (Val(Txt_Dscto01.Text) / 100)
                Txt_Descuento.Text = Descuento1 + Descuento2
                Txt_TotalDescto.Text = Format(CDbl(Txt_Descuento.Text), "$#,##0.00")

                Txt_Total.Text = Format((Total1) - (Descuento1 + Descuento2), "$#,##0.00")


            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub RellenaDevolucion()
        'mreyes 29/Marzo/2012 11:02 a.m.
        Lbl_Tipo.Text = "DevProv"
        Call usp_TraerDevProv()
        Call usp_TraerDet_DP()
        For I As Integer = 0 To DGrid.RowCount - 2
            Call Totalizados(True, I)
        Next

    End Sub

    Private Sub frmCatalogoPedidoNuevo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'mreyes 28/Febrero/2012 01:58 p.m.
            Sw_Load = True
            If Sw_Costos = True Then
                Btn_Condiciones.Visible = True
            End If
            Txt_NotaCargo.Text = "0"
            Txt_NotaCredito.Text = "0"
            DGrid.Columns("l1").DisplayIndex = 10
            DGrid.Columns("l2").DisplayIndex = 11
            DGrid.Columns("l3").DisplayIndex = 12
            DGrid.Columns("l4").DisplayIndex = 13
            DGrid.Columns("l5").DisplayIndex = 14
            DGrid.Columns("l6").DisplayIndex = 15
            DGrid.Columns("estructura").DisplayIndex = 16

            Txt_Fecha.Text = Format(Now.Date, "yyyy-MM-dd")
            If GLB_Usuario = "ALMACEN" Then Chk_VerPendientexRecibir.Visible = False : Chk_VerPendientexRecibir.Checked = True
            If Accion = 1 Then
                Chk_VerPendientexRecibir.Visible = False
                '' Programación para resurtido

                'If Sw_PedidoNuevo = True And Sw_FacturaNueva = False Then
                LimpiarDatos()
                If Sw_FacturaNueva = False And Sw_Devolucion = False Then
                    If GLB_OcXSuc = True Then
                        TraerListadoSucursales()
                        If IntSelect = 1 Then
                            Txt_Sucursal.Text = SucSelect(0)
                            Chk_ReplicarSuc.Checked = True
                            DGrid.Columns("csuc").Visible = False
                            DGrid.Columns("sucdescrip").Visible = False
                            Chk_ReplicarSuc.Visible = False
                        ElseIf IntSelect > 1 Then
                            ' no pedir txt_sucursal.text 
                            Txt_Sucursal.Visible = False
                            Txt_DescripSucursal.Visible = False
                            Label16.Visible = False
                            Chk_ReplicarSuc.Checked = True

                        End If
                    Else
                        Chk_ReplicarSuc.Visible = False
                        DGrid.Columns("csuc").Visible = False
                        DGrid.Columns("sucdescrip").Visible = False
                    End If
                Else
                    Chk_ReplicarSuc.Visible = False
                    DGrid.Columns("csuc").Visible = False
                    DGrid.Columns("sucdescrip").Visible = False
                End If
                'LimpiarDatos() quito martha 22/Junio/2015    06:07 p.m.
                Btn_Correo.Enabled = False
                Btn_Pdf.Enabled = False
                DGrid.Columns(124).Visible = True
                DGrid.Columns(125).Visible = True
                Using objIVA As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                    objDataSet = objIVA.usp_TraerIVA
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_Iva.Text = objDataSet.Tables(0).Rows(0).Item("iva").ToString
                    End If

                End Using
                If Sw_Remision = True Then
                    Txt_Iva.Text = "0"
                End If

                If Sw_PedidoNuevo = True Then
                    Lbl_ResurtSN.Text = "PEDIDO NUEVO"
                    ResurtSN = "N"
                    Btn_Transferir.Visible = False
                    Lbl_NoBulto.Visible = False
                    Txt_NoBulto.Visible = False
                    'Btn_Bulto.Visible = False
                    Opt_PedidoCatalogo.Visible = True
                    Opt_PedidoCatalogo.Checked = True
                    Opt_PedidoUnico.Visible = True
                    Opt_PedidoCatalogo.Checked = False

                Else
                    ResurtSN = "S"  '' resurtido
                    Lbl_ResurtSN.Text = "RESURTIDO"
                    Me.Text = "Pedido Resurtido"
                    Btn_Transferir.Visible = True
                    Lbl_NoBulto.Visible = False
                    Txt_NoBulto.Visible = False
                    'Btn_Bulto.Visible = False

                    Opt_PedidoCatalogo.Visible = True
                    Opt_PedidoCatalogo.Checked = True
                    Opt_PedidoUnico.Visible = True
                    Opt_PedidoCatalogo.Checked = False


                End If
                If Sw_FacturaNueva = True Then
                    Btn_Series.Visible = True
                    Lbl_NoBulto.Visible = True
                    Txt_NoBulto.Visible = True
                    Call InicializaFactura()
                    Lbl_ResurtSN.Text = "RECIBO A DETALLE"
                    Txt_Referenc.Visible = True
                    DGrid.Columns("pcomp").HeaderText = "Costo"
                    DGrid.Columns("costo").HeaderText = "Precio Lista"

                    Opt_PedidoCatalogo.Visible = False
                    Opt_PedidoCatalogo.Checked = False
                    Opt_PedidoUnico.Visible = False
                    Opt_PedidoCatalogo.Checked = False

                    Call Txt_Proveedor_LostFocus(sender, e)
                    Txt_NoBulto.Focus()
                Else
                    If Sw_Factura = True Then
                        Txt_Referenc.Visible = True
                        Txt_NoBulto.ReadOnly = True
                        DGrid.Columns("pcomp").HeaderText = "Costo"
                        DGrid.Columns("costo").HeaderText = "Precio Lista"
                        Btn_Series.Visible = True

                    End If
                    If Sw_Devolucion = True Then
                        Btn_Series.Visible = True
                        Lbl_NoBulto.Visible = True
                        Txt_NoBulto.Visible = True
                        Lbl_ResurtSN.Text = "CARGO POR DEVOLUCIÓN"
                        Txt_Referenc.Visible = True
                        Txt_NoBulto.Focus()
                    End If
                End If
            Else
                DGrid.Columns("csuc").Visible = False
                DGrid.Columns("sucdescrip").Visible = False

                If Sw_Factura = True Or Sw_FacturaNueva = True Then
                    RellenaFactura()
                    Btn_Correo.Enabled = False
                    Btn_Transferir.Visible = False
                    Btn_Pdf.Enabled = False
                    Chk_Fechas.Visible = False
                    Call InicializaFactura()
                    Opt_Factura.Enabled = True
                    Opt_Remision.Enabled = True
                    Txt_Sucursal.Enabled = False
                    DGrid.Columns("pcomp").HeaderText = "Costo"
                    DGrid.Columns("costo").HeaderText = "Precio Lista"
                    Btn_Series.Visible = True
                ElseIf Sw_Devolucion = True Then
                    RellenaDevolucion()
                    Btn_Correo.Enabled = False
                    Btn_Transferir.Visible = False
                    Btn_Pdf.Enabled = False
                    Chk_Fechas.Visible = False
                    Btn_Series.Visible = True
                Else
                    RellenaOrdeComp()
                End If
                If Accion <> 2 Then
                    CMenu.Enabled = False
                    CMenu1.Enabled = False
                    Btn_Aceptar.Enabled = False
                End If
                CargarFotoArticulo(Txt_Marca.Text, DGrid.Rows(0).Cells("EstiloNuestro").Value)

            End If
            Call GenerarToolTip()
            DGrid.RowHeadersVisible = False
            Call Edicion()
            If Sw_Cancelaciones = True Then
                DGrid.Columns(23).ReadOnly = False

            End If
            If Txt_DescripSucursal.Text.Length = 0 Then
                Using objIVA As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                    objDataSet = objIVA.usp_TraerDescripcion("S", Txt_Sucursal.Text, "")
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                    End If

                End Using
            End If
            If Sw_SoloPasoPDF = True Then
                '' dependiendo si es pdf o q    ue
                Call Btn_Pdf_Click(sender, e)


            End If
            If Sw_SoloPasoIMPRIMECEDIS = True Then
                Call Btn_Imprimir_Click(sender, e)
            End If
            'If Accion = 2 Then
            ' DGrid.Columns("c").ReadOnly = True
            'End If

            '' CHECAR SI PUEDE VER COSTOS.. LOS COSTOS NO SE PODRAN VER SI EN PUERTO EL PUERTO DICE 01... 
            'mreyes 17/Julio/2012 09:26 a.m.
            If Sw_FacturaNueva = True Then
                Opt_Remision.Enabled = False
                Opt_Factura.Enabled = False
                Txt_FechaVence.Enabled = False
                CMenu.Enabled = False
                CMenu1.Enabled = False

            End If
            If Sw_Devolucion = True Then
                InicializaDevolucion()
                CMenu.Enabled = False
                CMenu1.Enabled = False
            End If
            If GLB_Usuario <> "SISTEMAS" And GLB_Usuario <> "RESM1979" And GLB_Usuario <> "FELIX" And GLB_Usuario <> "FELIXJ" And GLB_Usuario <> "LORIS" Then
                If pub_TienePermisoProceso("COSBIT", "01", "", False) = False Then
                    Exit Sub
                Else
                    DGrid.Columns("costo").Visible = False
                    DGrid.Columns("pcomp").Visible = False
                    DGrid.Columns("precio").Visible = False
                    DGrid.Columns("porc").Visible = False
                    DGrid.Columns("importe").Visible = False
                    Label13.Visible = False
                    Txt_Subtotal.Visible = False
                    Label14.Visible = False
                    Txt_TotalIVA.Visible = False
                    Label15.Visible = False
                    Txt_TotalDescto.Visible = False
                    Label11.Visible = False
                    Txt_Total.Visible = False
                    Label4.Visible = False
                    Label3.Visible = False
                    Txt_Diaspp.Visible = False
                    Txt_Dsctopp.Visible = False
                    Txt_Dscto01.Visible = False
                    Txt_Dscto02.Visible = False
                    Txt_Dscto03.Visible = False
                    Txt_Dscto04.Visible = False
                    Txt_Dscto05.Visible = False
                    Sw_Costos = False

                    Txt_NotaCargo.Visible = False
                    Txt_NotaCredito.Visible = False
                    Label17.Visible = False
                    Label22.Visible = False

                End If
            End If

            Sw_Load = False
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function Permiso() As Boolean
        If Sw_Costos = False Then
            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
            Exit Function
        End If
        Permiso = True
    End Function

    Private Sub InicializaDevolucion()
        'mreyes 23/Mayo/2012 01:23 p.m.
        'Pnl_Edicion.Visible = False

        Lbl_ResurtSN.Text = "Cargo por Devolución"
        Me.Text = "Cargo por Devolución"
        Btn_Transferir.Visible = False
        Btn_Correo.Visible = False
        'Btn_Pdf.Visible = False
        Btn_Pdf.Enabled = True
        DGrid.ReadOnly = False
        Lbl_Tipo.Text = "DEVOLUCIÓN"
        DGrid.Columns("sucursal").Visible = False
        DGrid.Columns("ordecomp").Visible = False
        DGrid.Columns("sucursal").ReadOnly = False
        DGrid.Columns("ordecomp").ReadOnly = False
        Txt_Proveedor.ReadOnly = True
        Txt_Marca.ReadOnly = True
        If GLB_Sw_Costos = False Then
            Label18.Visible = False
            Label4.Visible = False
            Label3.Visible = False
            Txt_Iva.Visible = False
            Txt_Diaspp.Visible = False
            Txt_Dscto01.Visible = False
            Txt_Dscto02.Visible = False
            Txt_Dscto03.Visible = False
            Txt_Dscto04.Visible = False
            Txt_Dscto05.Visible = False
            Txt_Dsctopp.Visible = False
            'Pnl_Totales.Visible = False
            Txt_Subtotal.Visible = False
            Txt_TotalDescto.Visible = False
            Txt_TotalIVA.Visible = False
            Txt_Total.Visible = False
            Label11.Visible = False
            Label15.Visible = False
            Label14.Visible = False
            Label13.Visible = False
            DGrid.Columns("pcomp").Visible = False
            DGrid.Columns("costo").Visible = False
            DGrid.Columns("precio").Visible = False
            DGrid.Columns("importe").Visible = False
            Txt_NotaCargo.Visible = False
            Txt_NotaCredito.Visible = False
            Label17.Visible = False
            Label22.Visible = False

            Btn_Pdf.Enabled = False
            Btn_Excel.Enabled = False
            Chk_Estructura.Visible = False
        End If
        Chk_ReplicarSuc.Visible = False
        Chk_VerPendientexRecibir.Visible = False



        ' DGrid.Columns(125).Visible = False
        DGrid.Columns(126).Visible = False
        DGrid.Columns("ta").Visible = False
        DGrid.Columns("fam").Visible = False
        DGrid.Columns("lin").Visible = False
        DGrid.Columns("cat").Visible = False

        DGrid.Columns("estructura").Visible = False
        DGrid.Columns("l1").Visible = False
        DGrid.Columns("l2").Visible = False
        DGrid.Columns("l3").Visible = False
        DGrid.Columns("l4").Visible = False
        DGrid.Columns("l5").Visible = False
        DGrid.Columns("l6").Visible = False



        If Sw_Costos = True Then
            DGrid.Columns("pcomp").Visible = True
            DGrid.Columns("costo").Visible = True
            DGrid.Columns("precio").Visible = True
            DGrid.Columns("importe").Visible = True
        Else
            DGrid.Columns("pcomp").Visible = False
            DGrid.Columns("costo").Visible = False
            DGrid.Columns("precio").Visible = False
            DGrid.Columns("importe").Visible = False
        End If
        ''DGrid.Columns("pcomp").Visible = False
        ''DGrid.Columns("costo").Visible = False
        ''DGrid.Columns("precio").Visible = False
        ''DGrid.Columns("importe").Visible = False

        DGrid.Columns("pcomp").ReadOnly = False
        ' DGrid.Columns("costo").ReadOnly = False


        Chk_Fechas.Visible = False
        Lbl_FechaFactura.Visible = True
        Txt_FechaFactura.Visible = True
        Lbl_FechaVenc.Visible = True
        Txt_FechaVence.Visible = True
        Opt_Factura.Visible = True
        Opt_Remision.Visible = True
        Txt_Gastos.Visible = True
        Lbl_Gastos.Visible = True
        'Txt_Descuento.Visible = True
        'Lbl_Descuento.Visible = True

        If Sw_Serie = True Then
            DGrid.Columns("sucursal").Visible = False
            DGrid.Columns("ordecomp").Visible = False
            DGrid.Columns("fechaentrega").Visible = False
            DGrid.Columns("porc").Visible = False
            DGrid.Columns("a").Visible = False
            DGrid.Columns("c").Visible = False
            DGrid.Columns("i").Visible = False
            If GLB_CveSucursal <> "96" And GLB_CveSucursal <> "15" Then
                Txt_Sucursal.Text = GLB_CveSucursal
            Else
                Txt_Sucursal.Text = ""
            End If
            Txt_Sucursal.ReadOnly = True
            Opt_Factura.Visible = False
            Opt_Remision.Visible = False
            Txt_Referenc.Visible = False
            Lbl_FechaFactura.Visible = False
            Txt_FechaFactura.Visible = False
            Lbl_FechaVenc.Visible = False

            Txt_FechaVence.Visible = False
            DGrid.Columns("serie").DisplayIndex = 0
            DGrid.Columns("serie").Visible = True
            Lbl_NoBulto.Visible = False
            Txt_NoBulto.Visible = False
            Txt_Proveedor.ReadOnly = False
            Txt_Marca.ReadOnly = False
            Txt_Marca.TabIndex = 0
            Txt_Marca.Focus()

        Else
            Txt_NoBulto.TabIndex = 0
            Txt_NoBulto.Focus()

        End If
        If Txt_Sucursal.Text = "" Then
            Txt_Sucursal.Text = "91"
        End If
        Opt_PedidoCatalogo.Visible = False
        Opt_PedidoUnico.Visible = False
        Txt_BaseVence.Visible = False
        Label23.Visible = False
        Btn_Pdf.Visible = False

    End Sub
    Private Sub InicializaFactura()
        'mreyes 23/Mayo/2012 01:23 p.m.

        Lbl_ResurtSN.Text = "Recibo a Detalle de Bultos"
        Me.Text = "Recibo A Detalle de Bultos"
        Btn_Transferir.Visible = False
        Btn_Correo.Visible = False
        'Btn_Pdf.Visible = False
        Btn_Pdf.Enabled = True
        Lbl_Tipo.Text = "ENTRADA"
        DGrid.Columns("sucursal").Visible = True
        DGrid.Columns("ordecomp").Visible = True
        DGrid.Columns("sucursal").ReadOnly = False
        DGrid.Columns("ordecomp").ReadOnly = False
        Txt_Proveedor.ReadOnly = True
        Txt_Marca.ReadOnly = True
        If GLB_Sw_Costos = False Then
            Label18.Visible = False
            Label4.Visible = False
            Label3.Visible = False
            Txt_Iva.Visible = False
            Txt_Diaspp.Visible = False
            Txt_Dscto01.Visible = False
            Txt_Dscto02.Visible = False
            Txt_Dscto03.Visible = False
            Txt_Dscto04.Visible = False
            Txt_Dscto05.Visible = False
            Txt_Dsctopp.Visible = False
            'Pnl_Totales.Visible = False
            Txt_Subtotal.Visible = False
            Txt_TotalDescto.Visible = False
            Txt_TotalIVA.Visible = False
            Txt_Total.Visible = False
            Label11.Visible = False
            Label15.Visible = False
            Label14.Visible = False
            Label13.Visible = False
            DGrid.Columns("pcomp").Visible = False
            DGrid.Columns("costo").Visible = False
            DGrid.Columns("precio").Visible = False
            DGrid.Columns("importe").Visible = False
            Btn_Pdf.Enabled = False
            Btn_Excel.Enabled = False
            Chk_Estructura.Visible = False
            Txt_Diaspp.ReadOnly = True
            Txt_Dsctopp.ReadOnly = True
            Txt_Dscto01.ReadOnly = True
            Txt_Dscto02.ReadOnly = True
            Txt_Dscto03.ReadOnly = True
            Txt_Dscto04.ReadOnly = True
            Txt_Dscto05.ReadOnly = True
            Txt_Iva.ReadOnly = True
            Txt_NotaCargo.Visible = False
            Txt_NotaCredito.Visible = False
            Label17.Visible = False
            Label22.Visible = False

        End If
        Chk_ReplicarSuc.Visible = False
        Chk_VerPendientexRecibir.Visible = False


        'Txt_Iva.Enabled = True
        'Txt_Diaspp.Enabled = True
        'Txt_Dscto01.Enabled = True
        'Txt_Dscto02.Enabled = True
        'Txt_Dscto03.Enabled = True
        'Txt_Dscto04.Enabled = True
        'Txt_Dscto05.Enabled = True
        'Txt_Dsctopp.Enabled = True




        ' DGrid.Columns(125).Visible = False
        DGrid.Columns(126).Visible = False
        DGrid.Columns("ta").Visible = False
        DGrid.Columns("fam").Visible = False
        DGrid.Columns("lin").Visible = False
        DGrid.Columns("cat").Visible = False

        DGrid.Columns("estructura").Visible = False
        DGrid.Columns("l1").Visible = False
        DGrid.Columns("l2").Visible = False
        DGrid.Columns("l3").Visible = False
        DGrid.Columns("l4").Visible = False
        DGrid.Columns("l5").Visible = False
        DGrid.Columns("l6").Visible = False



        If Sw_FacturaNueva = True Then
            DGrid.Columns("pcomp").Visible = False
            DGrid.Columns("costo").Visible = False
            DGrid.Columns("precio").Visible = False
            DGrid.Columns("importe").Visible = False
        Else
            If Sw_Factura = True Then
                Txt_Referenc.Visible = True
                Txt_NoBulto.ReadOnly = True
            End If
        End If

        Chk_Fechas.Visible = False
        Lbl_FechaFactura.Visible = True
        Txt_FechaFactura.Visible = True
        Lbl_FechaVenc.Visible = True
        Txt_FechaVence.Visible = True
        Opt_Factura.Visible = True
        Opt_Remision.Visible = True
        Txt_Gastos.Visible = True
        Lbl_Gastos.Visible = True
        'Txt_Descuento.Visible = True
        'Lbl_Descuento.Visible = True
        Txt_NoBulto.TabIndex = 0
        Txt_NoBulto.Focus()
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_CorreoCancela, "Cancelar pedido según selección.")
            ToolTip.SetToolTip(Btn_CancelarPedido, "Cancelar pedido según selección.")
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Nuevo, "Nuevo Artículo")
            ToolTip.SetToolTip(Btn_Editar, "Editar Artículo")
            ToolTip.SetToolTip(DGrid, "Detallado de corridas del Artículo")
            ToolTip.SetToolTip(Btn_Transferir, "Traer Estilos Socilitados para la Marca-Proveedor")
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Pedido para CEDIS")

            ToolTip.SetToolTip(Btn_InvertirSeleccion, "Invertir selección de cancelación")

            If Sw_Devolucion = True Then
                ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Cargo por Devolución")
            End If
            If Sw_Factura Or Sw_FacturaNueva Then
                ToolTip.SetToolTip(Btn_Imprimir, "Imprimir Entrada")
            End If
            ToolTip.SetToolTip(Btn_Bulto, "Información de Folio de bultos")
            ToolTip.SetToolTip(Btn_Series, "Información Detallada de Series")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        Try
            Txt_Sucursal.Focus()
            Txt_Proveedor.Text = ""
            Txt_Gastos.Text = "0.0"
            Txt_Descuento.Text = "0.0"
            Txt_TotalDescto.Text = "0.0"
            Txt_Sucursal.Text = "0.0"
            Txt_Total.Text = "0.0"
            Txt_Improcedente.Text = "0.0"
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub



    Private Sub Txt_Marca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Marca.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
            If Txt_Marca.Text.Length = 0 Then Exit Sub

            Try
                'Get the specific project selected in the ListView control
                Call TxtLostfocus(Txt_Marca, Txt_DescripMarca, "M")

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

        If Len(Txt_Marca.Text) > 0 And Len(Txt_Proveedor.Text) > 0 Then
            ValidarMarcaProv()
            ValidarDevoMarcaProv()

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
        Try
            If Sw_FacturaNueva = True Then Exit Sub
BRINCO:
            If Txt_Proveedor.Text.Length = 0 Then Exit Sub
            If Txt_Proveedor.Text.Trim.Length < 3 Then
                Txt_Proveedor.Text = pub_RellenarIzquierda(Txt_Proveedor.Text.Trim, 3)
            End If

            If Txt_Marca.Text.Length = 0 Then Exit Sub


            Using objProveedores As New BCL.BCLCatalogoProveedores(GLB_ConStringCipSis)
                objDataSet = objProveedores.usp_TraerProveedor(Txt_Proveedor.Text, Txt_Marca.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    If Sw_Remision = False Then
                        If Val(objDataSet.Tables(0).Rows(0).Item("rprov").ToString) = 1 Then
                            If Val(objDataSet.Tables(0).Rows(0).Item("factrem").ToString) = 1 Then
                                Dim myForm As New frmFactRem



                                myForm.ShowDialog()
                                If myForm.Opt_Factura.Checked = True Then
                                    Txt_Iva.Enabled = True
                                Else
                                    Txt_Iva.Text = "0"
                                    Txt_Iva.Enabled = False

                                End If
                            Else

                                Txt_Iva.Text = "0"
                                Txt_Iva.Enabled = False
                            End If
                        Else

                            ' Txt_Iva.Enabled = True
                            If Val(objDataSet.Tables(0).Rows(0).Item("factrem").ToString) = 1 Then
                                Dim myForm As New frmFactRem



                                myForm.ShowDialog()
                                If myForm.Opt_Factura.Checked = True Then
                                    Txt_Iva.Enabled = True
                                Else
                                    Txt_Iva.Text = "0"
                                    Txt_Iva.Enabled = False

                                End If
                            Else

                                'Txt_Iva.Text = "0"
                                Txt_Iva.Enabled = True
                            End If

                        End If
                    Else
                        Txt_Iva.Text = "0"


                    End If




                    IdProveedorB = Val(objDataSet.Tables(0).Rows(0).Item("idproveedor"))
                    Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("agente").ToString
                    Txt_Transporte.Text = objDataSet.Tables(0).Rows(0).Item("transp").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Diaspp.Text = Val(objDataSet.Tables(0).Rows(0).Item("diaspp"))
                    If Sw_FacturaNueva = False Then
                        Txt_Dsctopp.Text = Val(objDataSet.Tables(0).Rows(0).Item("dsctopp"))

                        Txt_Dscto01.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto01"))
                        Txt_Dscto02.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto02"))
                        Txt_Dscto03.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto03"))
                        Txt_Dscto04.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto04"))
                        Txt_Dscto05.Text = Val(objDataSet.Tables(0).Rows(0).Item("dscto05"))
                    Else
                        If Txt_FechaFactura.Text.Length > 0 And Txt_Diaspp.Text.Length > 0 Then
                            Txt_FechaVence.Text = Format(pub_FechaVence(Txt_FechaFactura.Text, Txt_Diaspp.Text), "yyyy-MM-dd")
                        Else
                            Txt_FechaVence.Text = Txt_FechaFactura.Text
                        End If
                    End If
                    Txt_Email01.Text = objDataSet.Tables(0).Rows(0).Item("email01")
                    Txt_Email02.Text = objDataSet.Tables(0).Rows(0).Item("email02")

                    If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                        If MsgBox("El proveedor se encuentra dado de BAJA.", MsgBoxStyle.Exclamation, "Datos Proveedor") Then Exit Sub
                    End If

                    If Txt_Email01.Text.Length = 0 Then
                        If MsgBox("El proveedor no cuenta con un correo electrónico al que podamos enviar la orden de compra", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Datos Proveedor") = MsgBoxResult.Yes Then

                            Exit Sub
                        End If
                    End If



                    'If Val(objDataSet.Tables(0).Rows(0).Item("rprov").ToString) = 1 Then
                    '    Txt_Iva.Text = "0"
                    '    Txt_Iva.Enabled = False
                    '    Opt_Remision.Checked = True
                    '    Opt_Remision.Checked = False
                    'Else
                    '    Txt_Iva.Enabled = True
                    '    Opt_Remision.Checked = False
                    '    Opt_Factura.Checked = True
                    'End If

                    If objDataSet.Tables(0).Rows(0).Item("BASEVENC").ToString = "F" Then
                        Sw_FechaVenceFactura = True
                    Else
                        Sw_FechaVenceFactura = False
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


            Sw_ProvDif = False
            If Sw_FacturaNueva = True Then
                If usp_ExisteFactProv() = True Then
                    'ya existe la factura para el proveedor.
                    MsgBox("Ya existe la relación Factura-Proveedor, verifique por favor el folio.", MsgBoxStyle.Critical, "Validación")
                    Txt_Referenc.Text = ""
                    Txt_Referenc.Enabled = True
                    Txt_Referenc.ReadOnly = False
                    Txt_Referenc.Focus()
                End If
                ' Buscar si el proveedor pertenece al glb_difprov 

                Dim Pos As Integer = 0
                Pos = InStr(Txt_Proveedor.Text, GLB_ProvDif)

                If Pos > 0 Then
                    Sw_ProvDif = True
                End If
            End If


            If Len(Txt_Marca.Text) > 0 And Len(Txt_Proveedor.Text) > 0 Then
                ValidarMarcaProv()
                ValidarDevoMarcaProv()

            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TxtLostfocus(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:20 p.m.
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

    Private Sub TxtLostfocusPersis(ByVal Txt_Campo As TextBox, ByVal Txt_Campo1 As TextBox, ByVal Tipo As String)
        'mreyes 28/Febrero/2012 01:30
        Dim myForm As New frmConsulta
        If Txt_Campo.Text.Length = 0 Then Exit Sub
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion(Tipo, Txt_Campo.Text.Trim, "")

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

    Private Sub TraerListadopEDIDOS()
        Dim myForm As New frmReciboPedSel

        myForm.IdFolio = Txt_NoBulto.Text
        myForm.ShowDialog()
        PedSelectPed = myForm.PedSelectPed
        SucSelectPed = myForm.SucSelectPed
        IntSelectPed = myForm.IntSelectPed
    End Sub
    Private Sub TraerListadoSucursales()
        Dim myForm As New frmSucursal

        myForm.ShowDialog()
        SucSelect = myForm.SucSelect
        IntSelect = myForm.IntSelect
    End Sub
    Private Sub TraerSucursal(ByVal Sucursal As String, ByVal Renglon As Integer, ByVal Columna As Integer)
        'mreyes 28/Febrero/2012 01:30

        Dim objDataSet As Data.DataSet
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            Try

                objDataSet = objMySqlGral.usp_TraerDescripcion("S", Sucursal, "")

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    DGrid.Rows(Renglon).Cells(Columna + 1).Value = objDataSet.Tables(0).Rows(0).Item("campo").ToString
                Else
                    Dim myForm As New frmConsulta
                    Txt_Campo.Text = ""
                    myForm.Tipo = "S"
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

    Private Sub Txt_Proveedor_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.MarginChanged

    End Sub
    Private Sub Txt_Proveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Proveedor.TextChanged
        If Txt_Proveedor.Text.Length = 3 Then
            SendKeys.Send("{TAB}")
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
                    If Accion = 4 Then Btn_Aceptar.Enabled = False Else Btn_Aceptar.Enabled = True

                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = True
                    Btn_Editar.Enabled = True
                    Pnl_Edicion.Enabled = False
                    ''Pnl_Grid.Enabled = False
                    'Txt_Sucursal2.Enabled = False

                    Call ColorTextos()

                Case 1, 2
                    Btn_Aceptar.Enabled = True
                    Btn_Cancelar.Enabled = True
                    Btn_Nuevo.Enabled = False
                    Btn_Editar.Enabled = False

                    Pnl_Grid.Enabled = True
                    Pnl_Grid.Enabled = True
                    If Accion = 1 Then
                        Txt_Sucursal.Focus()
                    ElseIf Accion = 2 Then
                        Txt_Marca.Enabled = False
                        Txt_Sucursal.Enabled = False
                        Txt_Proveedor.Enabled = False
                        Txt_Sucursal.ReadOnly = True
                        Txt_Proveedor.ReadOnly = True
                        Txt_Marca.ReadOnly = True
                        Txt_Iva.Enabled = False
                        Txt_Iva.BackColor = TextboxBackColor
                        Call ColorTextos()

                    End If
                    If Sw_Bitacora = True Then
                        Pnl_Edicion.Enabled = False
                        For I As Integer = 0 To DGrid.ColumnCount - 3
                            DGrid.Columns(I).ReadOnly = True
                        Next
                        CMenu.Enabled = False
                    End If
            End Select
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub ColorTextos()
        Txt_Marca.BackColor = TextboxBackColor
        Txt_Sucursal.BackColor = TextboxBackColor
        Txt_Proveedor.BackColor = TextboxBackColor
        Txt_Raz_Soc.BackColor = TextboxBackColor
        Txt_Vendedor.BackColor = TextboxBackColor
        Txt_Transporte.BackColor = TextboxBackColor
        Txt_Observa.BackColor = TextboxBackColor
        Txt_Iva.BackColor = TextboxBackColor
        Txt_Dsctopp.BackColor = TextboxBackColor
        Txt_Diaspp.BackColor = TextboxBackColor
        Txt_Fecha.BackColor = TextboxBackColor
        Txt_Dscto01.BackColor = TextboxBackColor
        Txt_Dscto02.BackColor = TextboxBackColor
        Txt_Dscto03.BackColor = TextboxBackColor
        Txt_Dscto04.BackColor = TextboxBackColor
        Txt_Dscto05.BackColor = TextboxBackColor
        Txt_Diaspp.BackColor = TextboxBackColor
        Txt_Dsctopp.BackColor = TextboxBackColor
    End Sub

    Private Sub Btn_Editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Editar.Click
        Accion = 2
        Call Edicion()
    End Sub

    Private Sub Txt_Marca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Marca.TextChanged
        If Txt_Marca.Text.Length = 3 Then
            Txt_Proveedor.Focus()
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try

            If Accion = 1 Or Accion = 2 Then
                If MessageBox.Show("Estas seguro de cancelar el registro ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    Me.Dispose()
                    Me.Close()

                End If
            Else
                Me.Close()
                Me.Dispose()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress


        e.KeyChar = UCase(e.KeyChar)
    End Sub


    Private Sub NuevoEstilo(ByVal Renglon As Integer)
        Try
            Dim myFormEstilos As New frmCatalogoModelos

            GLB_CatEsiloCancelado = False
            '' mandar datos que ya registro el usuario en el grid 
            myFormEstilos.Accion = 1
            myFormEstilos.Txt_Marca.Text = Txt_Marca.Text
            myFormEstilos.Txt_DescripMarca.Text = Txt_DescripMarca.Text
            myFormEstilos.Txt_Proveedor.Text = Txt_Proveedor.Text
            myFormEstilos.Txt_Raz_Soc.Text = Txt_Raz_Soc.Text

            '' ''myFormEstilos.Txt_Division.Text = DGrid.Rows(Renglon).Cells(6).Value
            '' ''myFormEstilos.Txt_DescripDivision.Text = DescripDivision
            '' ''myFormEstilos.Txt_Familia.Text = DGrid.Rows(Renglon).Cells(7).Value
            '' ''myFormEstilos.Txt_DescripFamilia.Text = DescripDepto
            '' ''myFormEstilos.Txt_Linea.Text = DGrid.Rows(Renglon).Cells(8).Value
            '' ''myFormEstilos.Txt_DescripLinea.Text = DescripFamilia
            '' '' '' ''myFormEstilos.Txt_Categoria.Text = DGrid.Rows(Renglon).Cells(9).Value
            '' '' '' ''myFormEstilos.Txt_DescripCategoria.Text = DescripCategoria

            myFormEstilos.Txt_Estilof.Text = DGrid.Rows(Renglon).Cells(10).Value
            'myFormEstilos.Txt_Estilon.Text = DGrid.Rows(Renglon).Cells(11).Value

            myFormEstilos.Txt_Marca.Text = Txt_Marca.Text
            myFormEstilos.Txt_DescripMarca.Text = Txt_DescripMarca.Text
            myFormEstilos.Txt_Proveedor.Text = Txt_Proveedor.Text
            myFormEstilos.Txt_Raz_Soc.Text = Txt_Raz_Soc.Text

            myFormEstilos.Txt_IdDivision.Text = IdDivision
            myFormEstilos.Txt_Division.Text = DGrid.Rows(Renglon).Cells(6).Value
            myFormEstilos.Txt_DescripDivision.Text = DescripDivision

            myFormEstilos.Txt_IdDepto.Text = IdDepto
            myFormEstilos.Txt_Depto.Text = DGrid.Rows(Renglon).Cells(7).Value
            myFormEstilos.Txt_DescripDepto.Text = DescripDepto

            myFormEstilos.Txt_IdFamilia.Text = IdFamilia
            myFormEstilos.Txt_Familia.Text = DGrid.Rows(Renglon).Cells(8).Value
            myFormEstilos.Txt_DescripFamilia.Text = DescripFamilia

            myFormEstilos.Txt_IdLinea.Text = IdLinea
            myFormEstilos.Txt_Linea.Text = DGrid.Rows(Renglon).Cells(9).Value
            myFormEstilos.Txt_DescripLinea.Text = DescripLinea


            If IdL1 > 0 Then
                myFormEstilos.Txt_IdL1.Text = IdL1
                myFormEstilos.Txt_L1.Text = DGrid.Rows(Renglon).Cells(127).Value
                myFormEstilos.Txt_DescripL1.Text = DescripLinea1
            End If

            If IdL2 > 0 Then
                myFormEstilos.Txt_IdL2.Text = IdL2
                myFormEstilos.Txt_L2.Text = DGrid.Rows(Renglon).Cells(128).Value
                myFormEstilos.Txt_DescripL2.Text = DescripLinea2
            End If

            If IdL3 > 0 Then
                myFormEstilos.Txt_IdL3.Text = IdL3
                myFormEstilos.Txt_L3.Text = DGrid.Rows(Renglon).Cells(129).Value
                myFormEstilos.Txt_DescripL3.Text = DescripLinea3
            End If

            If IdL4 > 0 Then
                myFormEstilos.Txt_IdL4.Text = IdL4
                myFormEstilos.Txt_L4.Text = DGrid.Rows(Renglon).Cells(130).Value
                myFormEstilos.Txt_DescripL4.Text = DescripLinea4
            End If

            If IdL5 > 0 Then
                myFormEstilos.Txt_IdL5.Text = IdL5
                myFormEstilos.Txt_L5.Text = DGrid.Rows(Renglon).Cells(131).Value
                myFormEstilos.Txt_DescripL5.Text = DescripLinea5
            End If

            If IdL6 > 0 Then
                myFormEstilos.Txt_IdL6.Text = IdL6
                myFormEstilos.Txt_L6.Text = DGrid.Rows(Renglon).Cells(132).Value
                myFormEstilos.Txt_DescripL6.Text = DescripLinea6
            End If

            myFormEstilos.Txt_Estilof.Text = DGrid.Rows(Renglon).Cells(10).Value
            myFormEstilos.Txt_Modelo.Text = DGrid.Rows(Renglon).Cells(11).Value
            DGrid.Rows(Renglon).Cells(11).ReadOnly = False

            '' agregar datos de descuento
            myFormEstilos.Sw_PedidoNuevo = True
            myFormEstilos.Txt_Dsctopp.Text = Txt_Dsctopp.Text
            myFormEstilos.Txt_Dscto01.Text = Txt_Dscto01.Text
            myFormEstilos.Txt_Dscto02.Text = Txt_Dscto02.Text
            myFormEstilos.Txt_Dscto03.Text = Txt_Dscto03.Text
            myFormEstilos.Txt_Dscto04.Text = Txt_Dscto04.Text
            myFormEstilos.Txt_Dscto05.Text = Txt_Dscto05.Text

            '' si es un estilo nuevo buscado por fábrica entonces, ....
            myFormEstilos.ShowDialog()
            If GLB_CatEsiloCancelado = False Then
                DGrid.Rows(Renglon).Cells(11).Value = myFormEstilos.Txt_Modelo.Text
                DGrid.Rows(Renglon).Cells(12).Value = myFormEstilos.Txt_Descripc.Text
                DGrid.Rows(Renglon).Cells(10).Value = myFormEstilos.Txt_Estilof.Text

                DGrid.Rows(Renglon).Cells(6).Value = myFormEstilos.Txt_Division.Text

                DGrid.Rows(Renglon).Cells(7).Value = myFormEstilos.Txt_Familia.Text

                DGrid.Rows(Renglon).Cells(8).Value = myFormEstilos.Txt_Linea.Text
                ''''DGrid.Rows(Renglon).Cells(9).Value = myFormEstilos.Txt_Categoria.Text


                MedidaEstilo = Mid(myFormEstilos.Cbo_Medida.Text, 1, 1)
            End If
            ''

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Rellena_OrdeCompFact(ByVal Renglon As Integer)
        'mreyes 23/Mayo/2012 01:36 p.m.

        Try
            Dim myForm As New frmConsultaOrdeComp
            Dim I As Integer
            Dim Corrida As String
            Dim Entrega As Date
            Dim Cancela As Date
            Dim margen As Decimal
            Dim Sucursal As String = ""
            Dim OrdeComp As String = ""
            Dim Cont As Integer = 0

            '' mandar el valor del estilo de fábrica y marca 
            DGrid.Rows(Renglon).Cells("ordecomp").Value = pub_RellenarIzquierda(DGrid.Rows(Renglon).Cells("ordecomp").Value, 6)
            DGrid.Rows(Renglon).Cells("Sucursal").Value = pub_RellenarIzquierda(DGrid.Rows(Renglon).Cells("Sucursal").Value, 2)
            myForm.Marca = Txt_Marca.Text
            myForm.Sucursal = DGrid.Rows(Renglon).Cells("Sucursal").Value
            myForm.OrdeComp = DGrid.Rows(Renglon).Cells("ordecomp").Value
            Sucursal = DGrid.Rows(Renglon).Cells("Sucursal").Value
            OrdeComp = DGrid.Rows(Renglon).Cells("ordecomp").Value

            myForm.ShowDialog()

            ' quitar el renglon de la orden de compra...
            ' 
            DGrid.Rows.RemoveAt(Renglon)
            Cont = Renglon
            ' todo lo que se selecciono
            For I = 0 To myForm.DGrid.Rows.Count - 1
                If myForm.DGrid.Rows(I).Cells("Selec").Value = True Then
                    Corrida = myForm.DGrid.Rows(I).Cells("corrida").Value
                    Entrega = myForm.DGrid.Rows(I).Cells("entrega").Value
                    Txt_FechaEntrega.Text = Entrega
                    Cancela = Format(myForm.DGrid.Rows(I).Cells("cancela").Value, "Short Date")
                    margen = Format(pub_CalcularMargenPedido(Val(myForm.DGrid.Rows(I).Cells("precio").Value), Val(myForm.DGrid.Rows(I).Cells("pcomp").Value)), "#0.00")
                    margen = Format(pub_CalcularMargenPedido(Val(myForm.DGrid.Rows(I).Cells("precio").Value), Val(myForm.DGrid.Rows(I).Cells("costo").Value)), "#0.00")

                    MedidaEstilo = myForm.DGrid.Rows(I).Cells("medida").Value

                    DGrid.Rows.Add(Sucursal, OrdeComp, "", "", "", "", myForm.DGrid.Rows(I).Cells("tipoart").Value,
                                    myForm.DGrid.Rows(I).Cells("familia").Value,
                                    myForm.DGrid.Rows(I).Cells("linea").Value,
                                    myForm.DGrid.Rows(I).Cells("categoria").Value,
                                    myForm.DGrid.Rows(I).Cells("estilof").Value,
                                    myForm.DGrid.Rows(I).Cells("estilon").Value,
                                    myForm.DGrid.Rows(I).Cells("descripc").Value,
                                    myForm.DGrid.Rows(I).Cells("corrida").Value,
                                    myForm.DGrid.Rows(I).Cells("intervalo").Value,
                                    myForm.DGrid.Rows(I).Cells("medini").Value,
                                    myForm.DGrid.Rows(I).Cells("medfin").Value,
                                    Format(Val(myForm.DGrid.Rows(I).Cells("pcomp").Value), "#,##0.00"), Format(Val(myForm.DGrid.Rows(I).Cells("costo").Value), "#,##0.00"),
                                     Format(Val(myForm.DGrid.Rows(I).Cells("precio").Value), "#,##0.00"), Format(margen, "#0.00"), "", "", "",
                                     "", "", "", "", "", "", "", "", "", "",
                                     "", "", "", "", "", "", "", "", "", "",
                                     "", "", "", "", "", "", "", "", "", "",
                                    "", "", "", "", "", "", "", "", "", "",
                                    "", "", "",
                                    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                     "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Entrega, Cancela)


                    If myForm.DGrid.Rows(I).Cells("tipoart").Value = "001" Or myForm.DGrid.Rows(I).Cells("tipoart").Value = "C" Then
                        Call TraerCorridaEdicion(Cont, Sucursal, OrdeComp, Corrida)
                    Else
                        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                            Dim objDataSet1 As Data.DataSet

                            objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(I).Cells("csuc").Value, Txt_Marca.Text, myForm.DGrid.Rows(I).Cells("estilon").Value, myForm.DGrid.Rows(I).Cells("corrida").Value, Txt_Proveedor.Text)

                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                '' si existe estilo, traerlo.
                                Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                If M1 = "" Then
                                    M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                End If
                                If M2 = "" Then
                                    M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                End If
                                Call RellenarMedidas(Cont, M1, M2, myForm.DGrid.Rows(I).Cells("estilon").Value, myForm.DGrid.Rows(I).Cells("corrida").Value, myForm.DGrid.Rows(I).Cells("intervalo").Value, False, "", "")
                            End If
                        End Using


                    End If
                    Call Totalizados(True, Cont)
                    Cont = Cont + 1

                End If
            Next


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub DGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellEndEdit
        'mreyes 13/Febrero/2011 12:16 p.m.
        If Sw_Validar = False Then Exit Sub
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        Dim renglon As Integer = DGrid.CurrentCell.RowIndex
        Try
            ' Pnl_Presupuesto.Visible = True
            ' Columna Tipo Artículo
            If renglon <> 0 Then
                If Chk_Fechas.Checked = True Then
                    DGrid.Rows(renglon).Cells(125).Value = DGrid.Rows(0).Cells(125).Value
                    DGrid.Rows(renglon).Cells(126).Value = DGrid.Rows(0).Cells(126).Value
                End If
            End If

            If columna = 1 Then
                '' ESTAMOS HABLANDO DE FACTURAS Y SE ESTA ESCOGIENDO LA ORDEN DE COMPRA.
                Call Rellena_OrdeCompFact(renglon)
            End If

            If Sw_FacturaNueva = True Then
                If Month(DGrid.Rows(renglon).Cells("fechaentrega").Value) > Month(GLB_FechaHoy) Then
                    MsgBox("No puede recibir una fecha de entrega mayor a la fecha de recibo. Verifique con compras", MsgBoxStyle.Critical, "Aviso")
                    If pub_TienePermisoProceso("RECDET", "00", "1320", True) = False Then
                        DGrid.Rows(renglon).Cells(columna).Value = CEscritoAnt
                        Exit Sub
                    End If

                    If GLB_Usuario <> "SISTEMAS" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                        Dim myFpermiso As New frmPermisoProceso
                        myFpermiso.ShowDialog()
                        If GLB_PermisoProceso = False Then
                            DGrid.Rows(renglon).Cells(columna).Value = CEscritoAnt
                            'ELIMINAR REGISTRO
                            If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then
                                DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                                For I As Integer = 0 To DGrid.RowCount - 2
                                    Call Totalizados(True, I)
                                Next
                                'End If
                            End If
                            Exit Sub
                        End If

                    End If
                End If



            End If

            If columna = 6 Then
                IdDivision = 0
                IdDepto = 0
                IdFamilia = 0
                IdFamilia = 0
                IdL1 = 0
                IdL2 = 0
                IdL3 = 0
                IdL4 = 0
                IdL5 = 0
                IdL6 = 0

                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "EDI")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripDivision = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DescripDivision
                columna = 7
            End If

            ' columna FAMILIA AHORA ES DEPTO 
            If columna = 7 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "ED")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripDepto = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripDepto
                columna = 8
            End If

            '' COLUMNA LINEA AHORA ES FAMILIA
            If columna = 8 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If

                Call TxtGrid(Txt_Campo, Txt_Campo1, "EF")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripFamilia = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripFamilia
                columna = 9
            End If

            '' categoria AHORA ES LINEA
            If columna = 9 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "EL")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea
                columna = 127
            End If


            '' Comienzan columnas de líneas

            If columna = 127 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "L1")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea1 = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea1
                columna = 128
            End If

            If columna = 128 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "L2")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea2 = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea2
                columna = 129
            End If


            If columna = 129 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "L3")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea3 = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea3
                columna = 130
            End If

            If columna = 130 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "L4")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea4 = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea4
                columna = 131
            End If


            If columna = 131 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "L5")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea5 = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea5
                columna = 132
            End If

            If columna = 132 Then
                Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                If Txt_Campo.Text.Trim.Length < 3 Then
                    Txt_Campo.Text = pub_RellenarIzquierda(Txt_Campo.Text.Trim, 3)
                End If
                Call TxtGrid(Txt_Campo, Txt_Campo1, "L6")
                '' DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DGrid.Rows(renglon).Cells(columna).Value = Txt_Campo.Text
                DescripLinea6 = Txt_Campo1.Text
                DGrid.Rows(renglon).Cells("estructura").Value = DGrid.Rows(renglon).Cells("estructura").Value & "\" & DescripLinea6
            End If

            If columna = 134 Then 'ES DEVOLUCION Y ES SERIE 




                For I As Integer = 0 To DGrid.RowCount - 1 'objDataSet.Tables(0).Rows.Count - 1
                    If I <> renglon Then
                        If DGrid.Rows(I).Cells(134).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(134).Value, 13) Then
                            MsgBox("La serie ya existe en el listado.", MsgBoxStyle.Critical, "Error")
                            DGrid.Rows(renglon).Cells(134).Value = ""
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                            Exit Sub
                        End If
                    End If
                Next


                Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

                    DGrid.Rows(renglon).Cells(11).Value = ""
                    DGrid.Rows(renglon).Cells("csuc").Value = Txt_Sucursal.Text
                    DGrid.Rows(renglon).Cells(134).Value = pub_RellenarIzquierda(DGrid.Rows(renglon).Cells(134).Value, 13)
                    Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                    objDataSet = ObjCatalogoEstilos.usp_TraerDatosSerie(DGrid.Rows(renglon).Cells(134).Value, Txt_Sucursal.Text, Txt_Marca.Text)

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si existe estilo, traerlo.
                        If Txt_Sucursal.Text = "" Then
                            'damos por hecho que es un usuario como 
                            ' checar si el usuario es 
                            ' sistemas depto = 1 
                            ' jefe administracíón depto = 2 puesto = 1
                            ' compras depto = 8 depto = 15,50
                            ' coordinador de recibo depto = 2 puesto = 49
                            If GLB_IdDeptoEmpleado = 1 Or GLB_IdDeptoEmpleado = 2 Or GLB_IdDeptoEmpleado = 8 Then
                                If GLB_IdDeptoEmpleado = 2 And (GLB_IdPuestoEmpleado = 1 Or GLB_IdPuestoEmpleado = 49) Then
                                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                                End If
                                If GLB_IdDeptoEmpleado = 8 And (GLB_IdPuestoEmpleado = 15 Or GLB_IdPuestoEmpleado = 50) Then
                                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                                End If
                            End If

                            Txt_DescripSucursal.Text = pub_TraerNomSucursal(Txt_Sucursal.Text)
                            DGrid.Rows(renglon).Cells("csuc").Value = Txt_Sucursal.Text
                        End If



                        ' si es uno que lo traiga y sino que lo busque en base a los estilos de fabrica 
                        ' DATOS PRINCIPALES
                        'Traer nueva estructura 
                        'mreyes 28/Mayo/2013 10:23 a.m. 

                        If Txt_Proveedor.Text <> "" Then
                            Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor")

                            If objDataSet.Tables(0).Rows(0).Item("proveedor") <> Txt_Proveedor.Text Then
                                MsgBox("La serie no pertenece al grupo de devolución, es decir, al mismo proveedor, Haga otro folio con dicha serie.", MsgBoxStyle.Critical, "Aviso")
                                DGrid.Rows(renglon).Cells(134).Value = ""
                                Exit Sub
                            End If
                        Else
                            Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor")
                        End If

                            If objDataSet.Tables(0).Rows(0).Item("status").ToString = "BA" Then
                                MsgBox("La serie ya se encuentra dada de baja.", MsgBoxStyle.Critical, "Aviso")
                                DGrid.Rows(renglon).Cells(134).Value = ""
                                Exit Sub
                            End If

                            If objDataSet.Tables(0).Rows(0).Item("status").ToString = "TR" Then
                                MsgBox("La serie se encuentra en traspaso.", MsgBoxStyle.Critical, "Aviso")
                                DGrid.Rows(renglon).Cells(134).Value = ""
                                Exit Sub
                            End If
                            If objDataSet.Tables(0).Rows(0).Item("idfolio") <> Val(FolioB) And Val(FolioB) > 0 Then
                                MsgBox("La serie no pertenece al folio de bulto, tiene que generar otra devolución.", MsgBoxStyle.Critical, "Error")
                                DGrid.Rows(renglon).Cells(134).Value = ""
                                DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                                Exit Sub
                            End If
                            'If objDataSet.Tables(0).Rows(0).Item("pagado") = 1 Then

                            'End If
                            FolioB = objDataSet.Tables(0).Rows(0).Item("idfolio")
                            Txt_NoBulto.Text = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString, 6)
                            'Txt_FactProv.Text = objDataSet.Tables(0).Rows(0).Item("factprov").ToString
                            Txt_Referenc.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString

                            If Txt_FactProv.Text = "" Then
                                Txt_FactProv.Text = objDataSet.Tables(0).Rows(0).Item("factprov").ToString

                            Else
                                If Txt_FactProv.Text <> objDataSet.Tables(0).Rows(0).Item("factprov").ToString Then
                                    MsgBox("La serie no pertenece al folio de factura, tiene que generar otra devolución.", MsgBoxStyle.Critical, "Error")
                                    DGrid.Rows(renglon).Cells(134).Value = ""
                                    DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                                    Exit Sub
                                End If
                            End If




                            DGrid.Rows(renglon).Cells("ta").Value = objDataSet.Tables(0).Rows(0).Item("claveedi").ToString
                            DGrid.Rows(renglon).Cells("fam").Value = objDataSet.Tables(0).Rows(0).Item("claveed").ToString
                            DGrid.Rows(renglon).Cells("lin").Value = objDataSet.Tables(0).Rows(0).Item("claveff").ToString
                            DGrid.Rows(renglon).Cells("cat").Value = objDataSet.Tables(0).Rows(0).Item("claveel").ToString
                            DGrid.Rows(renglon).Cells("l1").Value = objDataSet.Tables(0).Rows(0).Item("clavel1").ToString
                            DGrid.Rows(renglon).Cells("l2").Value = objDataSet.Tables(0).Rows(0).Item("clavel2").ToString
                            DGrid.Rows(renglon).Cells("l3").Value = objDataSet.Tables(0).Rows(0).Item("clavel3").ToString
                            DGrid.Rows(renglon).Cells("l4").Value = objDataSet.Tables(0).Rows(0).Item("clavel4").ToString
                            DGrid.Rows(renglon).Cells("l5").Value = objDataSet.Tables(0).Rows(0).Item("clavel5").ToString
                            DGrid.Rows(renglon).Cells("l6").Value = objDataSet.Tables(0).Rows(0).Item("clavel6").ToString
                            DGrid.Rows(renglon).Cells("estructura").Value = objDataSet.Tables(0).Rows(0).Item("descripdivision") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripdepto") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripfamilia") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descriplinea") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripl1") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripl2") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripl3") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripl4") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripl5") & "\" &
                                                                        objDataSet.Tables(0).Rows(0).Item("descripl6")


                            DGrid.Rows(renglon).Cells(10).Value = objDataSet.Tables(0).Rows(0).Item("ESTILOF").ToString
                            DGrid.Rows(renglon).Cells(11).Value = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                            DGrid.Rows(renglon).Cells(12).Value = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                            DGrid.Rows(renglon).Cells("prs").Value = "1"
                            DGrid.Rows(renglon).Cells("de").Value = objDataSet.Tables(0).Rows(0).Item("MEDIDA").ToString
                            DGrid.Rows(renglon).Cells("C").Value = objDataSet.Tables(0).Rows(0).Item("CORRIDA").ToString
                            DGrid.Rows(renglon).Cells("COSTO").Value = objDataSet.Tables(0).Rows(0).Item("COSTO").ToString
                            DGrid.Rows(renglon).Cells("PCOMP").Value = objDataSet.Tables(0).Rows(0).Item("COSTO").ToString
                            MedidaEstilo = objDataSet.Tables(0).Rows(0).Item("medida").ToString

                            Txt_Pares.Text = Val(Txt_Pares.Text) + 1
                        Else
                            MsgBox("La serie no existe o no se encuentra asignada a la sucursal.", MsgBoxStyle.Critical, "Aviso")
                        DGrid.Rows(renglon).Cells(134).Value = ""
                        Exit Sub

                    End If
                End Using
            End If
            ''

            ' COLUMNA ESTILO fabrica
            If columna = 10 Then
                ' SI ENCUENTRA EL ESTILO FABRICA, ENTONCES TIENE QUE TRAER EL ESTILO NUESTRO Y LA DESCRIPCIÓN
                ' SI ES DE FACTURA NUEVA... CHECAR SI EXISTE EL ESTILO DE FÁBRICA EN LA FACTURA.
                '

                Using ObjCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

                    DGrid.Rows(renglon).Cells(11).Value = ""

                    Txt_Campo.Text = DGrid.Rows(renglon).Cells(columna).Value
                    objDataSet = ObjCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, DGrid.Rows(renglon).Cells(11).Value, DGrid.Rows(renglon).Cells(10).Value, IdDivision, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Txt_Proveedor.Text, "")

                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        ' si existe estilo, traerlo.
                        If objDataSet.Tables(0).Rows.Count = 1 Then
                            ' si es uno que lo traiga y sino que lo busque en base a los estilos de fabrica 
                            ' DATOS PRINCIPALES
                            'Traer nueva estructura 
                            'mreyes 28/Mayo/2013 10:23 a.m. 
                            If CDate(objDataSet.Tables(0).Rows(0).Item("fecreci")) = "1900-01-01" Then
                                If Sw_PedidoNuevo = False Then ' ES RESURTIDO resurtido
                                    MsgBox("No puede registrar un pedido de resurtido con un estilo nuevo.", MsgBoxStyle.Critical, "Error")
                                    Exit Sub
                                End If
                            Else
                                If Sw_PedidoNuevo = True Then
                                    MsgBox("No puede registrar un pedido de nuevo con un estilo ya resurtido.", MsgBoxStyle.Critical, "Error")
                                    Exit Sub
                                End If
                            End If
                            If Txt_Sucursal.Text <> "" Then
                                DGrid.Rows(renglon).Cells("csuc").Value = Txt_Sucursal.Text
                            End If
                            DGrid.Rows(renglon).Cells("ta").Value = objDataSet.Tables(0).Rows(0).Item("claveedi").ToString
                            DGrid.Rows(renglon).Cells("fam").Value = objDataSet.Tables(0).Rows(0).Item("claveed").ToString
                            DGrid.Rows(renglon).Cells("lin").Value = objDataSet.Tables(0).Rows(0).Item("claveff").ToString
                            DGrid.Rows(renglon).Cells("cat").Value = objDataSet.Tables(0).Rows(0).Item("claveel").ToString
                            DGrid.Rows(renglon).Cells("l1").Value = objDataSet.Tables(0).Rows(0).Item("clavel1").ToString
                            DGrid.Rows(renglon).Cells("l2").Value = objDataSet.Tables(0).Rows(0).Item("clavel2").ToString
                            DGrid.Rows(renglon).Cells("l3").Value = objDataSet.Tables(0).Rows(0).Item("clavel3").ToString
                            DGrid.Rows(renglon).Cells("l4").Value = objDataSet.Tables(0).Rows(0).Item("clavel4").ToString
                            DGrid.Rows(renglon).Cells("l5").Value = objDataSet.Tables(0).Rows(0).Item("clavel5").ToString
                            DGrid.Rows(renglon).Cells("l6").Value = objDataSet.Tables(0).Rows(0).Item("clavel6").ToString
                            DGrid.Rows(renglon).Cells("estructura").Value = objDataSet.Tables(0).Rows(0).Item("descripdivision") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripdepto") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripfamilia") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descriplinea") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripl1") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripl2") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripl3") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripl4") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripl5") & "\" &
                                                                            objDataSet.Tables(0).Rows(0).Item("descripl6")



                            DGrid.Rows(renglon).Cells(columna + 1).Value = objDataSet.Tables(0).Rows(0).Item("estilon").ToString
                            DGrid.Rows(renglon).Cells(columna + 2).Value = objDataSet.Tables(0).Rows(0).Item("descripc").ToString
                            MedidaEstilo = objDataSet.Tables(0).Rows(0).Item("medida").ToString
                            ' If SOLO TIENE UNA CORRIDA 
                            Using ObjCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                objDataSet = ObjCorrida.usp_TraerCorrida(DGrid.Rows(renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(renglon).Cells("estilonuestro").Value, "", Txt_Proveedor.Text)

                                If objDataSet.Tables(0).Rows.Count = 1 Then
                                    Call TraerCorrida(renglon, columna, objDataSet.Tables(0).Rows(0).Item("corrida").ToString)
                                End If
                            End Using
                        Else
                            Dim myForm As New frmConsultaEstilo
                            '' mandar el valor del estilo de fábrica y marca 
                            myForm.Marcab = Txt_Marca.Text
                            myForm.EstiloFb = Txt_Campo.Text
                            myForm.ShowDialog()
                            ' Regresa el valor del estilo nuestro
                            DGrid.Rows(renglon).Cells(columna + 1).Value = pub_RellenarEspaciosIzquierda(myForm.Campo, 7)
                            DGrid.Rows(renglon).Cells(columna + 2).Value = myForm.Campo1
                            MedidaEstilo = myForm.Campo2

                            'objDataSet = ObjCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, DGrid.Rows(renglon).Cells(11).Value, DGrid.Rows(renglon).Cells(10).Value, IdDivision, IdDepto, IdFamilia, IdLinea, IdL1, IdL2, IdL3, IdL4, IdL5, IdL6, Txt_Proveedor.Text, "")
                            objDataSet = ObjCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, DGrid.Rows(renglon).Cells(11).Value, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                            If objDataSet.Tables(0).Rows.Count > 0 Then

                                If Txt_Sucursal.Text <> "" Then
                                    DGrid.Rows(renglon).Cells("csuc").Value = Txt_Sucursal.Text
                                End If

                                DGrid.Rows(renglon).Cells("ta").Value = objDataSet.Tables(0).Rows(0).Item("claveedi").ToString
                                DGrid.Rows(renglon).Cells("fam").Value = objDataSet.Tables(0).Rows(0).Item("claveed").ToString
                                DGrid.Rows(renglon).Cells("lin").Value = objDataSet.Tables(0).Rows(0).Item("claveff").ToString
                                DGrid.Rows(renglon).Cells("cat").Value = objDataSet.Tables(0).Rows(0).Item("claveel").ToString
                                DGrid.Rows(renglon).Cells("l1").Value = objDataSet.Tables(0).Rows(0).Item("clavel1").ToString
                                DGrid.Rows(renglon).Cells("l2").Value = objDataSet.Tables(0).Rows(0).Item("clavel2").ToString
                                DGrid.Rows(renglon).Cells("l3").Value = objDataSet.Tables(0).Rows(0).Item("clavel3").ToString
                                DGrid.Rows(renglon).Cells("l4").Value = objDataSet.Tables(0).Rows(0).Item("clavel4").ToString
                                DGrid.Rows(renglon).Cells("l5").Value = objDataSet.Tables(0).Rows(0).Item("clavel5").ToString
                                DGrid.Rows(renglon).Cells("l6").Value = objDataSet.Tables(0).Rows(0).Item("clavel6").ToString
                                DGrid.Rows(renglon).Cells("estructura").Value = objDataSet.Tables(0).Rows(0).Item("descripdivision") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripdepto") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripfamilia") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descriplinea") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl1") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl2") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl3") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl4") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl5") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl6")

                            End If

                            Using ObjCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                objDataSet = ObjCorrida.usp_TraerCorrida(DGrid.Rows(renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(renglon).Cells("estilonuestro").Value, "", Txt_Proveedor.Text)

                                If objDataSet.Tables(0).Rows.Count = 1 Then
                                    Call TraerCorrida(renglon, columna, objDataSet.Tables(0).Rows(0).Item("corrida").ToString)
                                End If
                            End Using
                        End If
                    Else
                        ' SOLO IR POR ESTILO NUEVO SI ES PEDIDO NUEVO
                        ' 
                        If Sw_PedidoNuevo = True Then
                            Call NuevoEstilo(renglon)

                            objDataSet = ObjCatalogoEstilos.usp_TraerEstilo(0, Txt_Marca.Text, DGrid.Rows(renglon).Cells(11).Value, DGrid.Rows(renglon).Cells(12).Value, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                            If objDataSet.Tables(0).Rows.Count > 0 Then



                                DGrid.Rows(renglon).Cells("ta").Value = objDataSet.Tables(0).Rows(0).Item("claveedi").ToString
                                DGrid.Rows(renglon).Cells("fam").Value = objDataSet.Tables(0).Rows(0).Item("claveed").ToString
                                DGrid.Rows(renglon).Cells("lin").Value = objDataSet.Tables(0).Rows(0).Item("claveff").ToString
                                DGrid.Rows(renglon).Cells("cat").Value = objDataSet.Tables(0).Rows(0).Item("claveel").ToString
                                DGrid.Rows(renglon).Cells("l1").Value = objDataSet.Tables(0).Rows(0).Item("clavel1").ToString
                                DGrid.Rows(renglon).Cells("l2").Value = objDataSet.Tables(0).Rows(0).Item("clavel2").ToString
                                DGrid.Rows(renglon).Cells("l3").Value = objDataSet.Tables(0).Rows(0).Item("clavel3").ToString
                                DGrid.Rows(renglon).Cells("l4").Value = objDataSet.Tables(0).Rows(0).Item("clavel4").ToString
                                DGrid.Rows(renglon).Cells("l5").Value = objDataSet.Tables(0).Rows(0).Item("clavel5").ToString
                                DGrid.Rows(renglon).Cells("l6").Value = objDataSet.Tables(0).Rows(0).Item("clavel6").ToString
                                DGrid.Rows(renglon).Cells("estructura").Value = objDataSet.Tables(0).Rows(0).Item("descripdivision") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripdepto") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripfamilia") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descriplinea") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl1") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl2") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl3") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl4") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl5") & "\" &
                                                                                objDataSet.Tables(0).Rows(0).Item("descripl6")

                            End If
                            'BUSCAR CORRIDA NUEVAMENTE 

                            Using ObjCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                objDataSet = ObjCorrida.usp_TraerCorrida(DGrid.Rows(renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(renglon).Cells("estilonuestro").Value, "", Txt_Proveedor.Text)

                                If objDataSet.Tables(0).Rows.Count = 1 Then

                                    Call TraerCorrida(renglon, columna, objDataSet.Tables(0).Rows(0).Item("corrida").ToString)
                                End If
                            End Using
                        Else
                            MsgBox("No se encontro el Estilo. Verifique por favor.", MsgBoxStyle.Critical, "Error")
                            Exit Sub
                        End If
                    End If
                End Using

                ' aqui ya tengo el estilo... 
                ' 
                Call CargarFotoArticulo(Txt_Marca.Text, DGrid.Rows(renglon).Cells("EstiloNuestro").Value)
            End If

            'COLUMNA ES CORRIDA
            If columna = 13 Then

                Call TraerCorrida(renglon, columna, DGrid.Rows(renglon).Cells(13).Value)
            End If

            'Columna de sucursal
            If columna = 21 Then
                Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                    Dim Sucursal As String = DGrid.Rows(renglon).Cells(columna).Value

                    Try
                        'Get the specific project selected in the ListView control
                        If Sucursal.Length < 2 Then
                            Sucursal = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                        End If

                        Call TraerSucursal(Sucursal, renglon, columna)


                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If




            If columna = 125 Or columna = 126 Then
                If IsDate(DGrid.Rows(renglon).Cells(columna).Value) Then
                    If IsDate(DGrid.Rows(renglon).Cells(columna).Value) = True Then
                        ' validar formato
                        DGrid.Rows(renglon).Cells(columna).Value = Format(CDate(DGrid.Rows(renglon).Cells(columna).Value), "Short Date")
                    Else
                        MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
                        DGrid.Rows(renglon).Cells(columna).Value = "1900-01-01"

                        sender.Focus()
                        Exit Sub
                    End If
                Else
                    MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
                    DGrid.Rows(renglon).Cells(columna).Value = "1900-01-01"
                    sender.Focus()
                    Exit Sub
                End If

                If CDate(DGrid.Rows(renglon).Cells(columna).Value) < Now Then
                    MsgBox("Fecha invalida", vbOKOnly + vbCritical, "Validación")
                    DGrid.Rows(renglon).Cells(columna).Value = "1900-01-01"
                    sender.Focus()
                    Exit Sub
                End If

                If columna = 125 Then
                    DGrid.Rows(renglon).Cells(126).Value = Format(CDate(DGrid.Rows(renglon).Cells(columna).Value).Add(New TimeSpan(10, 0, 0, 0)), "yyyy-MM-dd")
                End If

            End If

            '' checar toda la corrida cuando ya termino de escribir...
            'If Sw_FacturaNueva = True Then
            '    If columna >= 24 And columna <= 123 Then
            '        CEscrito = DGrid.Rows(renglon).Cells(columna).Value
            '        'prueba

            '        If CEscritoAnt = 0 And CEscrito > 0 Then
            '            '' ir a traer pantalla para pedir autorización.
            '            If pub_TienePermisoProceso("FACTURAS", "00", "", True) = False Then Exit Sub
            '            If GLB_Usuario <> "SISTEMAS" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Then
            '                Dim myFpermiso As New frmPermisoProceso
            '                myFpermiso.ShowDialog()
            '                If GLB_PermisoProceso = False Then
            '                    DGrid.Rows(renglon).Cells(columna).Value = CEscritoAnt
            '                    Exit Sub
            '                End If

            '            End If
            '        End If

            '        If CEscritoAnt + (CEscritoAnt * 0.3) < CEscrito Then
            '            '' ir a traer pantalla para pedir autorización.
            '            If pub_TienePermisoProceso("FACTURAS", "00", "", True) = False Then Exit Sub
            '            If GLB_Usuario <> "SISTEMAS" Or GLB_Usuario <> "FELIX" Or GLB_Usuario <> "FELIXJ" Then
            '                Dim myFpermiso As New frmPermisoProceso
            '                myFpermiso.ShowDialog()
            '                If GLB_PermisoProceso = False Then
            '                    DGrid.Rows(renglon).Cells(columna).Value = CEscritoAnt
            '                    Exit Sub
            '                End If

            '            End If

            '        End If

            '    End If
            'End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub CargarFotoArticulo(ByVal Marca, ByVal Estilon)
        'mreyes 14/Marzo/2012 07:06 p.m.
        'Glb_RutaArchivoFotos
        Try
            Dim Archivo As String = ""
            Dim NoFoto As String = "1"



            MarcaFOTO = Marca
            EstiloNFOTO = Estilon

            Using objIO As New BCL.BCLio(GLB_ConStringCipSis)

                Archivo = objIO.pub_ArmarNombreFotoEstilo(If(Sw_Factura = True Or Sw_FacturaNueva = True, GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, NoFoto)

                If objIO.pub_ExisteArchivo(Archivo) = True Then
                    PBox.Image = New System.Drawing.Bitmap(Archivo)
                    Exit Sub
                End If

                For i As Integer = 0 To 9
                    Archivo = objIO.pub_ArmarNombreFotoEstilo(If(Sw_Factura = True Or Sw_FacturaNueva = True, GLB_RutaArchivoFotosLocal, GLB_RutaArchivoFotos), Marca, Estilon, i)
                    If objIO.pub_ExisteArchivo(Archivo) = True Then
                        PBox.Image = New System.Drawing.Bitmap(Archivo)
                        Exit Sub
                    Else
                        Archivo = objIO.pub_ArmarNombreFotoEstilo(GLB_RutaArchivoFotos, Marca, Estilon, i)
                        If objIO.pub_ExisteArchivo(Archivo) = True Then
                            PBox.Image = New System.Drawing.Bitmap(Archivo)
                            Exit Sub
                        End If
                    End If

                Next

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function ValidarDatos() As Boolean
        Try
            'mreyes 14/Febrero/2012 10:14 a.m.
            ValidarDatos = False
            Sw_Validar = False
            If Sw_Devolucion = False Then
                If IntSelect = 0 Then
                    If Txt_Sucursal.Text.Length = 0 Then
                        MsgBox("Debe especificar la sucursal para el Pedido Nuevo.", MsgBoxStyle.Critical, "Validación")
                        Txt_Sucursal.Focus()
                        Exit Function
                    End If
                End If
            End If
            If Txt_Marca.Text.Length = 0 Then
                MsgBox("Debe especificar la marca para el Pedido Nuevo.", MsgBoxStyle.Critical, "Validación")
                Txt_Marca.Focus()
                Exit Function
            End If

            If Sw_Serie = False Then
                If Txt_Proveedor.Text.Length = 0 Then
                    MsgBox("Debe especificar el proveedor para el Pedido Nuevo.", MsgBoxStyle.Critical, "Validación")
                    Txt_Proveedor.Focus()
                    Exit Function
                End If
            End If




            Txt_Sucursal.Enabled = False
            Txt_Marca.Enabled = False
            Txt_Proveedor.Enabled = False

            If Sw_FacturaNueva = True Then
                If Txt_Referenc.Text.Length = 0 Then
                    MsgBox("Debe especificar el número de factura o remisión.", MsgBoxStyle.Critical, "Validación")
                    Txt_Referenc.Focus()
                    Exit Function
                End If

                If Txt_FechaFactura.Text.Length = 0 Then
                    MsgBox("Debe especificar la Fecha de la Factura.", MsgBoxStyle.Critical, "Validación")
                    Txt_FechaFactura.Focus()
                    Exit Function
                End If

                If Txt_FechaVence.Text.Length = 0 Then
                    MsgBox("Debe especificar la Fecha de Vencimiento.", MsgBoxStyle.Critical, "Validación")
                    Txt_FechaVence.Focus()
                    Exit Function
                End If

                If Txt_Referenc.Text.Length <> 10 Then
                    If Opt_Factura.Checked = True Then
                        Txt_Referenc.Text = "F-" & pub_RellenarIzquierda(Txt_Referenc.Text, 8)
                    Else
                        Txt_Referenc.Text = "R-" & pub_RellenarIzquierda(Txt_Referenc.Text, 8)
                    End If
                End If
                Txt_Referenc.Enabled = False

            End If



            Sw_Validar = True
            ValidarDatos = True

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function



    Private Sub DGrid_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.CurrentCellDirtyStateChanged
        'mreyes 14/Febrero/2012 12:01 p.m.
        Try
            Call Totalizados(False, DGrid.CurrentCell.RowIndex)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub CalculaFechaVence()
        'mreyes 21/Julio/2015   10:13


        Try
            If Sw_FechaVenceFactura = True Then
                Txt_FechaVence.Text = Format(pub_FechaVence(Txt_FechaFactura.Text, Txt_Diaspp.Text), "yyyy-MM-dd")
                Entregavence = CDate(Txt_FechaFactura.Text)
            Else
                Dim FechaMax As Date = "1900-01-01"
                For I As Integer = 0 To DGrid.RowCount - 1
                    If DGrid.Rows(I).Cells(23).Value > 0 Then
                        If FechaMax = "1900-01-01" Then
                            FechaMax = DGrid.Rows(I).Cells("fechaentrega").Value
                        End If

                        If CDate(DGrid.Rows(I).Cells("fechaentrega").Value) > FechaMax Then
                            FechaMax = DGrid.Rows(I).Cells("fechaentrega").Value
                        End If



                    End If
                Next

                If CDate(FechaMax) > CDate(Txt_Fecha.Text) Then
                    Txt_FechaVence.Text = Format(pub_FechaVence(FechaMax, Txt_Diaspp.Text), "yyyy-MM-dd")
                Else
                    Txt_FechaVence.Text = Format(pub_FechaVence(Txt_Fecha.Text, Txt_Diaspp.Text), "yyyy-MM-dd")
                End If
                Entregavence = FechaMax
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Totalizados(ByVal Sw_Total As Boolean, ByVal Renglon As Integer, Optional ByVal HastaRenglon As Integer = 0, Optional ByVal DesctoCero As Integer = 0)
        'mreyes 18/Febrero/2012 02:32 p.m.
        Try
            Dim Total191 As Double = 0

            If sw_cambioceros = True Then Exit Sub
            'Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim columna As Integer = 0


            If DesctoCero = 1 Or Sw_Remision = True Then
                columna = 0
            Else


                columna = DGrid.CurrentCell.ColumnIndex

            End If

            If Accion = 1 And Sw_FacturaNueva = True Then

                If CDate(DGrid.Rows(Renglon).Cells("fechaentrega").Value) > CDate(Txt_Fecha.Text) Then
                    Txt_FechaVence.Text = Format(pub_FechaVence(DGrid.Rows(Renglon).Cells("fechaentrega").Value, Txt_Diaspp.Text), "yyyy-MM-dd")
                End If


            End If


            Dim total As Double = 0
            Dim Importe As Double = 0
            Dim Cont As Integer = 0

            If (DGrid.Rows(Renglon).Cells("idusuariocancela").Value) <> 0 Then Exit Sub
            If (DGrid.Rows(Renglon).Cells("ta").Value) = "" Then Exit Sub


            If Sw_Total = False Then
                If columna < 23 And Accion < 2 Then Exit Sub
            End If

            For I As Integer = 24 To 123
                If IsNumeric(DGrid.Rows(Renglon).Cells(I).Value) Then
                    'total += Val(Convert.ToDouble(Val(DGrid.Rows(Renglon).Cells(I).Value)))
                    total += Val(Convert.ToDouble((DGrid.Rows(Renglon).Cells(I).Value)))

                End If
                If DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow Then
                    Cont = Cont + 1
                End If
            Next
            If Cont > 14 Then
                Sw_ImprimeMas14 = True
            Else
                Sw_ImprimeMas14 = False
            End If

            DGrid.Rows(Renglon).Cells(23).Value = Format(Val(total), "#,##0")

            If Sw_Factura = True Or Sw_FacturaNueva = True Then
                DGrid.Rows(Renglon).Cells(124).Value = Format(Val(total * CDbl(DGrid.Rows(Renglon).Cells("costo").Value)), "$#,##0.00")

            Else
                DGrid.Rows(Renglon).Cells(124).Value = Format(Val(total * CDbl(DGrid.Rows(Renglon).Cells("pcomp").Value)), "$#,##0.00")

            End If

            ' DGrid.Rows(Renglon).Cells(124).Value = Format(Val(total * CDbl(DGrid.Rows(Renglon).Cells("pcomp").Value)), "$#,##0.00")

            ' ACTUALIZAR LOS TEXTOS
            ' 
            ' COLUMNA DE PARES ES LA 23
            If DesctoCero = 0 Then
                Txt_Pares.Text = Format(Val(pub_SumarColumnaGrid(DGrid, 23, HastaRenglon)), "#,##0")
            End If
            'SUMA SUBTOTAL
            ' If Sw_Factura = True Or Sw_FacturaNueva = True Then
            ' Importe = pub_SumarColumnaGrid(DGrid, 123, HastaRenglon)
            ' Else
            Importe = pub_SumarColumnaGrid(DGrid, 124, HastaRenglon)
            'End If
            'mientras martha
            ' If Sw_Factura = True Or Sw_FacturaNueva = True Then
            Txt_Subtotal.Text = Format(Importe, "$#,##0.00")
            Txt_TotalIVA.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)), "$#,##0.00")
            '  Else
            '  Txt_Subtotal.Text = Format(Importe / ((1 + Val(Txt_Iva.Text) / 100) * (1 - Val(Txt_Dsctopp.Text) / 100)), "$#,##0.00")
            '  Txt_TotalIVA.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)), "$#,##0.00")
            '  End If


            '   Txt_TotalIVA.Text = Format(Importe * (Txt_Iva.Text / 100), "$#,##0.00")
            '  Txt_Subtotal.Text = Format(Val(Importe) - Val(Txt_TotalIVA.Text), "$#,##0.00")

            'Txt_TotalDescto.Text = Format((Txt_Subtotal.Text) * IIf(Val(Txt_Dsctopp.Text) = 0, 0, (1 / Val(Txt_Dsctopp.Text))), "$#,##0.00")
            Txt_TotalDescto.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_NotaCredito.Text) - CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text)) * IIf(Val(Txt_Dsctopp.Text) = 0, 0, (Val(Txt_Dsctopp.Text) / 100)), "$#,##0.00")
            'prueba
            Txt_Descuento.Text = Txt_TotalDescto.Text

            'mreyes 14/Febrero/2019 10:36 a.m. se quito

            If Val(Txt_Dscto01.Text) > 0 Then
                Txt_Descuento.Text = CDbl(Txt_TotalDescto.Text) + Format((CDbl(Txt_NotaCredito.Text) + CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_TotalDescto.Text)) * IIf(Val(Txt_Dscto01.Text) = 0, 0, (Val(Txt_Dscto01.Text) / 100)), "$#,##0.00")
                Txt_TotalDescto.Text = Format(CDbl(Txt_Descuento.Text), "$#,##0.00")
            End If

            'If Val(Txt_Dscto01.Text) > 0 Then
            '    Txt_Descuento.Text = CDbl(Txt_TotalDescto.Text) + Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_NotaCredito.Text) - CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text)) * IIf(Val(Txt_Dscto01.Text) = 0, 0, (Val(Txt_Dscto01.Text) / 100)), "$#,##0.00")
            '    Txt_TotalDescto.Text = Format(CDbl(Txt_Descuento.Text), "$#,##0.00")
            'End If




            Txt_Total.Text = Format(Importe, "$#,##0.00")
            'quitar mientras 
            ' If Sw_Factura = True Or Sw_FacturaNueva = True Then
            Txt_Total.Text = Format(CDbl(Txt_Subtotal.Text) + (CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)) - CDbl(Txt_Descuento.Text), "$#,##0.00")
            Txt_Total.Text = Format(CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_Descuento.Text), "$#,##0.00")
            'End If

            If CDbl(Txt_NotaCargo.Text) > 0 Then
                'mreyes 17/Octubre/2016 04:27 p.m.
                'se toma en cuenta si es del 191 y es de fecha 2016, para el 1.5
                'If Txt_Proveedor.Text = "191" And CDate(Txt_Fecha.Text) >= "2016-05-01" Then
                '    Total191 = 0.015 * (CDbl(Txt_Total.Text) - CDbl(Txt_NotaCargo.Text))
                '    Txt_Total.Text = Format((CDbl(Txt_Total.Text) - CDbl(Txt_NotaCargo.Text)) - Total191, "$#,##0.00")
                'Else
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) - CDbl(Txt_NotaCargo.Text), "$#,##0.00")
                ' End If


            End If


            If CDbl(Txt_NotaCredito.Text) > 0 Then
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) + CDbl(Txt_NotaCredito.Text), "$#,##0.00")

            End If


            Txt_NotaCredito.Text = Format(CDbl(Txt_NotaCredito.Text), "$#,##0.00")
            Txt_NotaCargo.Text = Format(CDbl(Txt_NotaCargo.Text), "$#,##0.00")




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub TotalizadosFactura(ByVal Sw_Total As Boolean, ByVal Renglon As Integer, Optional ByVal HastaRenglon As Integer = 0, Optional ByVal DesctoCero As Integer = 0)
        'mreyes 10/Julio/2015   12:39 p.m.
        Try
            Dim Importe As Double = 0
            For I As Integer = 0 To DGrid.RowCount - 1
                DGrid.Rows(I).Cells(124).Value = Format(Val(DGrid.Rows(I).Cells(23).Value) * CDbl(DGrid.Rows(I).Cells("pcomp").Value), "$#,##0.00")

            Next

            Txt_Pares.Text = Format(Val(pub_SumarColumnaGrid(DGrid, 23, HastaRenglon)), "#,##0")


            Importe = pub_SumarColumnaGrid(DGrid, 124, HastaRenglon)

            Txt_Subtotal.Text = Format(Importe, "$#,##0.00")
            Txt_TotalIVA.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)), "$#,##0.00")
            Txt_TotalDescto.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_NotaCredito.Text) + CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text)) * IIf(Val(Txt_Dsctopp.Text) = 0, 0, (Val(Txt_Dsctopp.Text) / 100)), "$#,##0.00")

            Txt_Descuento.Text = Txt_TotalDescto.Text

            If Val(Txt_Dscto01.Text) > 0 Then
                Txt_Descuento.Text = CDbl(Txt_TotalDescto.Text) + Format((CDbl(Txt_NotaCredito.Text) + CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_TotalDescto.Text)) * IIf(Val(Txt_Dscto01.Text) = 0, 0, (Val(Txt_Dscto01.Text) / 100)), "$#,##0.00")
                Txt_TotalDescto.Text = Format(CDbl(Txt_Descuento.Text), "$#,##0.00")
            End If

            Txt_Total.Text = Format(Importe, "$#,##0.00")

            Txt_Total.Text = Format(CDbl(Txt_Subtotal.Text) + (CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)) - CDbl(Txt_Descuento.Text), "$#,##0.00")
            Txt_Total.Text = Format(CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_Descuento.Text), "$#,##0.00")
            'End If

            If CDbl(Txt_NotaCargo.Text) > 0 Then
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) - CDbl(Txt_NotaCargo.Text), "$#,##0.00")

            End If


            If CDbl(Txt_NotaCredito.Text) > 0 Then
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) + CDbl(Txt_NotaCredito.Text), "$#,##0.00")

            End If


            Txt_NotaCredito.Text = Format(CDbl(Txt_NotaCredito.Text), "$#,##0.00")
            Txt_NotaCargo.Text = Format(CDbl(Txt_NotaCargo.Text), "$#,##0.00")




        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub DGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyDown
        'mreyes 14/Febrero/2012 04:20 p.m.
        Try
            If (e.KeyCode = 46) Then
                If Accion = 1 Or Accion = 2 Then
                    Dim Letrero As String = "la orden de compra"
                    If Sw_Devolucion = True Then
                        Letrero = "la devolución"

                    End If
                    If Sw_Factura Or Sw_FacturaNueva Then
                        Letrero = "la factura"
                    End If

                    If MessageBox.Show("Estas seguro de eliminar el estilo de " & Letrero & " ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then


                        If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then
                            DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                            'End If
                        End If
                        For I As Integer = 0 To DGrid.RowCount - 2
                            Call Totalizados(True, I)
                        Next

                    End If
                End If
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub EliminarFilaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        'mreyes 14/Febrero/2012 04:47 p.m.
        Try
            If MessageBox.Show("Estas seguro de eliminar el estilo de la orden de compra ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub


            If (DGrid.CurrentCell.RowIndex) <> DGrid.Rows.Count - 1 Then
                DGrid.Rows.RemoveAt(DGrid.CurrentCell.RowIndex)
                For I As Integer = 0 To DGrid.RowCount - 2
                    Call Totalizados(True, I)
                Next
                'End If


            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub VerAnaliticoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerAnaliticoToolStripMenuItem.Click
        'mreyes 14/Febrero/2012 04:47 p.m.
        'Try
        '    Dim MyForm As New frmPpalResurtidoAut
        '    MyForm.Sucursal = Txt_Sucursal.Text
        '    MyForm.Marca = Txt_Marca.Text
        '    MyForm.OrdeComp = Txt_OrdeComp.Text
        '    MyForm.Proveedor = Txt_Proveedor.Text
        '    MyForm.Estilon = DGrid.CurrentRow.Cells("Estilonuestro").Value.ToString
        '    MyForm.Opcion = 2
        '    MyForm.WindowState = FormWindowState.Maximized
        '    '  MyForm.MdiParent = Me
        '    MyForm.Show()
        'Catch ExceptionErr As Exception
        '    MessageBox.Show(ExceptionErr.Message.ToString)
        'End Try

        Try
            Dim MyForm As New frmPpalPedidoNuevo
            MyForm.Sucursalb = DGrid.CurrentRow.Cells("sucursal").Value.ToString
            'MyForm.Marcab = Txt_Marca.Text
            MyForm.OrdeCompb = DGrid.CurrentRow.Cells("ordecomp").Value.ToString
            'MyForm.Proveedor = Txt_Proveedor.Text

            'MyForm.Opcion = 2
            MyForm.WindowState = FormWindowState.Maximized
            '  MyForm.MdiParent = Me
            MyForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try



    End Sub

    Private Sub Pnl_Botones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Botones.Paint

    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
            Me.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub NuevoEstiloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoEstiloToolStripMenuItem.Click
        If ValidarDETOrdeComp() = False Then Exit Sub
        Call NuevoEstilo(DGrid.CurrentCell.RowIndex)
    End Sub

    Private Sub TraerCorrida(ByVal Renglon As Integer, ByVal Columna As Integer, ByVal Corrida As String)
        'mreyes 15/Febrero/2012 11:04 a.m.
        Try
            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim OrdenIni As String = ""
                Dim OrdenFin As String = ""

                Dim objDataSet As Data.DataSet
                Dim MedidaNeg As Integer = 0
                Dim MEDIDAMAXNEG As Integer = 0
                Dim MedidaUltNeg As String = ""
                Dim MedidaIniNeg As String = ""
                Txt_Campo.Text = DGrid.Rows(Renglon).Cells(Columna).Value

                objDataSet = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(Renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    '' si existe estilo, traerlo.
                    ' 13 corrida, 14 intervalo, 15 medini, 16 medfin
                    DGrid.Rows(Renglon).Cells("c").Value = objDataSet.Tables(0).Rows(0).Item("corrida").ToString
                    DGrid.Rows(Renglon).Cells("i").Value = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    DGrid.Rows(Renglon).Cells("de").Value = objDataSet.Tables(0).Rows(0).Item("medini").ToString
                    DGrid.Rows(Renglon).Cells("a").Value = objDataSet.Tables(0).Rows(0).Item("medfin").ToString
                    DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(objDataSet.Tables(0).Rows(0).Item("costo").ToString), "#,##0.00")
                    DGrid.Rows(Renglon).Cells("precio").Value = Format(Val(objDataSet.Tables(0).Rows(0).Item("precio").ToString), "#,##0.00")
                    ' calcular costo
                    DGrid.Rows(Renglon).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(objDataSet.Tables(0).Rows(0).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
                    DGrid.Rows(Renglon).Cells("porc").Value = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(0).Item("precio")), DGrid.Rows(Renglon).Cells("costo").Value), "#0.00")
                    CorridaAnterior = Txt_Campo.Text
                    IntervaloAnterior = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    MedIniAnterior = Val(objDataSet.Tables(0).Rows(0).Item("medini"))
                    MedFinAnterior = Val(objDataSet.Tables(0).Rows(0).Item("medfin"))
                    ' HACER VISIBLES LAS COLUMNAS SEGÚN LOS INTERVALOS

                    ' aqui es cuando son números y trabaja yigual... CHECAR EL TIPO ARTICULO Y LA MEDIDA MAS BIEN 
                    If MedidaEstilo <> "N" Then
                        Call RellenarMedidas(Renglon, objDataSet.Tables(0).Rows(0).Item("ordenini").ToString, objDataSet.Tables(0).Rows(0).Item("ordenfin").ToString, objDataSet.Tables(0).Rows(0).Item("estilon").ToString, objDataSet.Tables(0).Rows(0).Item("corrida").ToString, IntervaloAnterior, False, "", "")
                    Else
                        ' if el tipo de articulo es igual a calzado entonces es rellena medidas sino corrida 
                        If DGrid.Rows(Renglon).Cells("ta").Value <> "001" And DGrid.Rows(Renglon).Cells("ta").Value <> "999" Then
                            'Call RellenarMedidas(Renglon, objDataSet.Tables(0).Rows(0).Item("ordenini").ToString, objDataSet.Tables(0).Rows(0).Item("ordenfin").ToString, objDataSet.Tables(0).Rows(0).Item("estilon").ToString, objDataSet.Tables(0).Rows(0).Item("corrida").ToString)
                            Dim M1 As String = objDataSet.Tables(0).Rows(0).Item("ordenini").ToString
                            Dim M2 As String = objDataSet.Tables(0).Rows(0).Item("ordenfin").ToString
                            If M1 = "" Then
                                M1 = objDataSet.Tables(0).Rows(0).Item("medini").ToString
                            End If
                            If M2 = "" Then
                                M2 = objDataSet.Tables(0).Rows(0).Item("medfin").ToString
                            End If
                            Call RellenarMedidas(Renglon, M1, M2, DGrid.Rows(Renglon).Cells(11).Value, Corrida, IntervaloAnterior, False, "", "")

                        Else
                            ' ir a buscar si comienza en medio...
                            Using objCatalogoMedida As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                objDataSet = objCatalogoMedida.usp_TraerMedidaMinima(1, Txt_Marca.Text, Txt_Proveedor.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida)

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    MedidaNeg = InStr(objDataSet.Tables(0).Rows(0).Item("medidaMIN").ToString, "-")
                                    ' MEDIDAMAXNEG = InStr(objDataSet.Tables(0).Rows(0).Item("medidaMAX").ToString, "-")
                                    MedidaIniNeg = objDataSet.Tables(0).Rows(0).Item("medidaMIN").ToString
                                End If

                            End Using

                            Using objCatalogoMedida As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                objDataSet = objCatalogoMedida.usp_TraerMedidaMinima(2, Txt_Marca.Text, Txt_Proveedor.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida)

                                If objDataSet.Tables(0).Rows.Count > 0 Then
                                    MEDIDAMAXNEG = InStr(objDataSet.Tables(0).Rows(0).Item("medidaMAX").ToString, "-")
                                    MedidaUltNeg = objDataSet.Tables(0).Rows(0).Item("medidaMAX").ToString
                                End If

                            End Using


                            Call RellenarCorrida(Renglon, MedIniAnterior, IIf(IntervaloAnterior = "-" Or IntervaloAnterior = "L", 1, IntervaloAnterior), 0, IIf(MedidaNeg > 0, 1, 0), IIf(MEDIDAMAXNEG > 0, 1, 0), MedidaUltNeg, MedidaIniNeg)
                        End If
                    End If
                    '' traer medidas 

                    DGrid.Rows(Renglon).Cells("c").ReadOnly = True
                    If Txt_Sucursal.Visible = True Then
                        DGrid.Rows(Renglon).Cells("csuc").Value = Txt_Sucursal.Text
                        DGrid.Rows(Renglon).Cells("sucdescrip").Value = Txt_DescripSucursal.Text
                        DGrid.Columns("csuc").Visible = False
                        DGrid.Columns("sucdescrip").Visible = False

                    End If
                    'CHECAR  TRAER VARIAS SUCURSALES
                    If Chk_ReplicarSuc.Checked = True And IntSelect > 0 And Sw_EditarEstilo = False Then
                        Call TraerSucursalesSelect(Renglon)
                    End If
                Else
                    MsgBox("La corrida '" & Txt_Campo.Text & "' no se encuentra registrada para el estilo.", MsgBoxStyle.Critical, "Aviso")
                    DGrid.Rows(Renglon).Cells(Columna).Value = ""
                    ''DGrid.CurrentCell = DGrid.Rows(renglon).Cells(columna)
                    ''SendKeys.Send("{UP}")
                    DGrid.Rows(Renglon).Selected = True
                    DGrid.Columns(Columna).Selected = True
                    DGrid.CurrentCell = DGrid.Rows(Renglon).Cells(Columna)

                    DGrid.CurrentCell = DGrid.Item(Columna, Renglon)
                    DGrid.Rows(Renglon).Selected = True
                    DGrid.Columns(Columna).Selected = True

                    DGrid.CurrentCell = DGrid.Rows(Renglon).Cells(Columna)

                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenarCorrida(ByVal Renglon As Integer, ByVal MedIni As Integer, ByVal Intervalo As Integer, Optional ByVal Cantidad As Double = 0, Optional ByVal EmpNeg As Integer = 0, Optional ByVal FinNeg As Integer = 0, Optional ByVal MedUltNeg As String = "", Optional ByVal MedIniNeg As String = "")
        'mreyes 18/Febrero/2012 10:18 a.m.
        Try
            For MedIniAnterior = Val(MedIni) To MedFinAnterior

                Call RellenarColumnasCorrida(Renglon, MedIniAnterior, Cantidad, EmpNeg, FinNeg, MedUltNeg, MedIniNeg)
                EmpNeg = 0
                FinNeg = 0
                MedIniAnterior = MedIniAnterior + IIf(IntervaloAnterior = "-" Or IntervaloAnterior = "L", 1, IntervaloAnterior) - 1
            Next

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenarMedidas(ByVal Renglon As Integer, ByVal OrdeIni As String, ByVal OrdeFin As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Intervalo As String, ByVal Sw_Traspaso As Boolean, ByVal SucOrde As String, ByVal OC As String)
        'mreyes 23/Febrero/2012 06:13 a.m.
        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

            Try
                Dim Sw_Encontro As Boolean = False
                Dim Medida As String = ""

                Dim objDataSet As Data.DataSet

                objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin("01", "99", MedidaEstilo)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Medida = objDataSet.Tables(0).Rows(z).Item("medida").ToString
                        With DGrid
                            ' buscar la medida en el grid 

                            For k As Integer = 24 To 123
                                With DGrid
                                    If .Columns(k).HeaderText = pub_RellenarIzquierda(Medida, 2) Then
                                        Sw_Encontro = True
                                        ' probar
                                        ColumnaRM = ColumnaRM + 1

                                        Exit For
                                    Else
                                        Sw_Encontro = False
                                    End If

                                End With

                            Next
                            If Sw_Encontro = False Then
                                With DGrid
                                    ColumnaRM = ColumnaRM + 1
                                    .Columns(ColumnaRM).HeaderText = Medida
                                    z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1
                                End With
                            Else
                                If Intervalo <> "L" Then
                                    z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1

                                End If

                            End If

                            ''ColumnaRM = ColumnaRM + 1
                            ''.Columns(ColumnaRM).HeaderText = Medida

                        End With

                    Next
                    'if a buscar la cantidad a det_oc por cada medida 

                    Call GeneraColumnasMedida(Renglon, OrdeIni, OrdeFin, Estilon, Corrida, Sw_Traspaso, SucOrde, OC)
                Else
                    '' checar es NUMERICO
                    If MedidaEstilo = "N" Then
                        '' el ordefin necesito saber exactamente 

                        '' checar si ya existe la medida en el grid



                        For z As Integer = OrdeIni To OrdeFin
                            For k As Integer = 24 To 123
                                Medida = z

                                With DGrid
                                    If .Columns(k).HeaderText = pub_RellenarIzquierda(Medida, 2) Then
                                        Sw_Encontro = True
                                        Exit For
                                    Else
                                        Sw_Encontro = False
                                    End If

                                End With

                            Next
                            If Sw_Encontro = False Then
                                With DGrid
                                    ColumnaRM = ColumnaRM + 1
                                    .Columns(ColumnaRM).HeaderText = Medida
                                    z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1
                                End With
                            Else
                                'z = z + IIf(Intervalo = "-", 1, Intervalo) - 1
                                z = z + IIf(Intervalo = "-" Or Intervalo = "L", 1, Intervalo) - 1

                            End If
                        Next
                        'if a buscar la cantidad a det_oc por cada medida 

                        Call GeneraColumnasMedidaNumeros(Renglon, OrdeIni, OrdeFin, Estilon, Corrida, SucOrde, OC)

                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub GeneraColumnasMedida(ByVal Renglon As Integer, ByVal OrdeIni As String, ByVal OrdeFin As String, ByVal Estilon As String, ByVal Corrida As String, ByVal Sw_Traspaso As Boolean, ByVal SucurOc As String, ByVal OC As String) ' en el 24 comienza la medida 
        'mreyes 23/Febrero/2012 06:13 a.m.
        Try
            Dim Medida As String = ""
            Dim Cantidad As Integer = 0
            Dim objDataSet As Data.DataSet
            Dim objDataSet1 As Data.DataSet
            Dim Pcomp As Decimal
            Dim Costo As Decimal
            Dim Entrega As Date

            'primero generar todas las columnas según la corrida que podria ser ... 

            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)

                objDataSet = objCatalogoEstilos.usp_TraerLetrasIniFin(OrdeIni, OrdeFin, MedidaEstilo)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 24 To 123
                        For z As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                            Medida = objDataSet.Tables(0).Rows(z).Item("medida").ToString
                            'Entrega = "1900-01-01"
                            Entrega = DGrid.Rows(Renglon).Cells("FechaEntrega").Value
                            With DGrid

                                If DGrid.Columns(I).HeaderText = Medida Then
                                    .Columns(I).Visible = True
                                    DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow
                                    If Accion <> 1 Then
                                        ' ir por cantidad usp_TraerCantidadesDet_Oc


                                        Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                            If Chk_VerPendientexRecibir.Checked = False Then
                                                If Sw_Factura = True Or Sw_FacturaNueva = True Then
                                                    objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_FP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Val(FolioB))
                                                Else
                                                    If Sw_Devolucion = True Then
                                                        objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_DP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida)
                                                    Else
                                                        objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                                    End If
                                                End If
                                            Else
                                                objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                            End If
                                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                            Else
                                                Pcomp = 0
                                                Costo = 0

                                                Cantidad = 0

                                            End If
                                            'checar
                                            ' DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                            ' DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")
                                            ''''
                                            DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")

                                        End Using
                                    Else
                                        ' ES ALTA PERO HAY QUE CHECAR SI ES SW_TRASPASO = TRUE 
                                        If Sw_Traspaso = True Then

                                            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                                objDataSet1 = objCantidadesDet_Oc.usp_TraerCantArtSolicitados(Txt_Marca.Text, Txt_Proveedor.Text, Estilon, Corrida, Medida)
                                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                    Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                    Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                    Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                                Else
                                                    Pcomp = 0
                                                    Costo = 0

                                                    Cantidad = 0
                                                End If
                                                '    DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                                '   DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")

                                                DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")
                                            End Using
                                        Else
                                            If Sw_Factura = True Or Sw_FacturaNueva = True Then
                                                Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                                    If Chk_VerPendientexRecibir.Checked = False Then
                                                        objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(SucurOc, OC, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                                    Else
                                                        objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(SucurOc, OC, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                                    End If
                                                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                        Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                        Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                        Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                                    Else
                                                        Pcomp = 0
                                                        Costo = 0

                                                        Cantidad = 0

                                                    End If
                                                    'checar
                                                    ' DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                                    ' DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")
                                                    ''''
                                                    DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")

                                                End Using
                                            Else
                                                Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                                    objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_FP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Val(FolioB))
                                                    ' objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_FP(SucurOc, OC, Txt_Marca.Text, Estilon, Corrida, Medida)
                                                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                                                        Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                                        Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                                        Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                                    Else
                                                        Pcomp = 0
                                                        Costo = 0

                                                        Cantidad = 0
                                                    End If
                                                    '  DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                                    ' DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")

                                                    DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")
                                                End Using
                                            End If
                                        End If
                                    End If
                                End If


                            End With
                        Next
                    Next
                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GeneraColumnasMedidaNumeros(ByVal Renglon As Integer, ByVal OrdeIni As String, ByVal OrdeFin As String, ByVal Estilon As String, ByVal Corrida As String, ByVal SucurOc As String, ByVal OC As String) ' en el 24 comienza la medida 
        'mreyes 08/Marzo/2012 03:36 a.m.
        Try
            Dim Medida As String = ""
            Dim Cantidad As Integer = 0

            Dim objDataSet1 As Data.DataSet
            Dim Pcomp As Decimal
            Dim Costo As Decimal
            Dim Entrega As Date


            'primero generar todas las columnas según la corrida que podria ser ... 



            For I As Integer = 24 To 123
                For z As Integer = OrdeIni To OrdeFin
                    Medida = pub_RellenarIzquierda(z, 2)
                    Entrega = DGrid.Rows(Renglon).Cells("FechaEntrega").Value
                    With DGrid

                        If DGrid.Columns(I).HeaderText = Medida Then
                            .Columns(I).Visible = True
                            DGrid.Rows(Renglon).Cells(I).Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                ' ir por cantidad usp_TraerCantidadesDet_Oc

                                Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                    'If Chk_VerPendientexRecibir.Checked = False Then
                                    '    objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                    'Else
                                    '    objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                    'End If

                                    If Chk_VerPendientexRecibir.Checked = False Then
                                        If Sw_Factura = True Or Sw_FacturaNueva = True Then
                                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_FP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Val(FolioB))
                                        ElseIf Sw_Devolucion = False Then
                                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                        Else
                                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_DP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida)
                                        End If
                                    Else
                                        objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                    End If

                                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                                        Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                        Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                        Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                    Else
                                        Pcomp = 0
                                        Costo = 0

                                        Cantidad = 0

                                    End If
                                    'DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                    'DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")

                                    DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")

                                End Using
                            Else
                                'prueba
                                If Sw_Factura = True Or Sw_FacturaNueva = True Then
                                    Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                                        If Chk_VerPendientexRecibir.Checked = False Then
                                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(SucurOc, OC, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                        Else
                                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(SucurOc, OC, Txt_Marca.Text, Estilon, Corrida, Medida, Entrega)
                                        End If
                                        If objDataSet1.Tables(0).Rows.Count > 0 Then
                                            Cantidad = Val(objDataSet1.Tables(0).Rows(0).Item("ctd"))
                                            Costo = Val(objDataSet1.Tables(0).Rows(0).Item("costo"))
                                            Pcomp = Val(objDataSet1.Tables(0).Rows(0).Item("costdesc"))


                                        Else
                                            Pcomp = 0
                                            Costo = 0

                                            Cantidad = 0

                                        End If
                                        'DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(Pcomp), "#,##0.00")
                                        'DGrid.Rows(Renglon).Cells("costo").Value = Format(Val(Costo), "#,##0.00")
                                        'CHECAR AQUI

                                        'If IntSelectPed > 0 Then
                                        '    DGrid.Rows(DGrid.RowCount - 1).Cells(I).Value = Format(Val(Cantidad), "#,##0")
                                        'Else
                                        DGrid.Rows(Renglon).Cells(I).Value = Format(Val(Cantidad), "#,##0")
                                        'End If

                                    End Using
                                End If
                                'prueba
                            End If
                        End If

                    End With
                Next
            Next



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub
    Private Sub EditarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditarToolStripMenuItem.Click
        If ValidarDETOrdeComp() = False Then Exit Sub
        Call EditarEstilo(DGrid.CurrentCell.RowIndex)
    End Sub
    Private Sub EditarEstilo(ByVal Renglon As Integer)
        'mreyes 15/Febrero/2012 11:58 a.m.

        Try
            Dim myFormEstilos As New frmCatalogoModelos

            GLB_CatEsiloCancelado = False
            '' mandar datos que ya registro el usuario en el grid 
            myFormEstilos.Accion = 2
            myFormEstilos.Txt_Marca.Text = Txt_Marca.Text
            myFormEstilos.Txt_DescripMarca.Text = Txt_DescripMarca.Text
            myFormEstilos.Txt_Proveedor.Text = Txt_Proveedor.Text
            myFormEstilos.Txt_Raz_Soc.Text = Txt_Raz_Soc.Text

            myFormEstilos.Txt_IdDivision.Text = IdDivision
            myFormEstilos.Txt_Division.Text = DGrid.Rows(Renglon).Cells(6).Value
            myFormEstilos.Txt_DescripDivision.Text = DescripDivision

            myFormEstilos.Txt_IdDepto.Text = IdDepto
            myFormEstilos.Txt_Depto.Text = DGrid.Rows(Renglon).Cells(7).Value
            myFormEstilos.Txt_DescripDepto.Text = DescripDepto

            myFormEstilos.Txt_IdFamilia.Text = IdFamilia
            myFormEstilos.Txt_Familia.Text = DGrid.Rows(Renglon).Cells(8).Value
            myFormEstilos.Txt_DescripFamilia.Text = DescripFamilia

            myFormEstilos.Txt_IdLinea.Text = IdLinea
            myFormEstilos.Txt_Linea.Text = DGrid.Rows(Renglon).Cells(9).Value
            myFormEstilos.Txt_DescripLinea.Text = DescripLinea


            If IdL1 > 0 Then
                myFormEstilos.Txt_IdL1.Text = IdL1
                myFormEstilos.Txt_L1.Text = DGrid.Rows(Renglon).Cells(127).Value
                myFormEstilos.Txt_DescripL1.Text = DescripLinea1
            End If

            If IdL2 > 0 Then
                myFormEstilos.Txt_IdL2.Text = IdL2
                myFormEstilos.Txt_L2.Text = DGrid.Rows(Renglon).Cells(128).Value
                myFormEstilos.Txt_DescripL2.Text = DescripLinea2
            End If

            If IdL3 > 0 Then
                myFormEstilos.Txt_IdL3.Text = IdL3
                myFormEstilos.Txt_L3.Text = DGrid.Rows(Renglon).Cells(129).Value
                myFormEstilos.Txt_DescripL3.Text = DescripLinea3
            End If

            If IdL4 > 0 Then
                myFormEstilos.Txt_IdL4.Text = IdL4
                myFormEstilos.Txt_L4.Text = DGrid.Rows(Renglon).Cells(130).Value
                myFormEstilos.Txt_DescripL4.Text = DescripLinea4
            End If

            If IdL5 > 0 Then
                myFormEstilos.Txt_IdL5.Text = IdL5
                myFormEstilos.Txt_L5.Text = DGrid.Rows(Renglon).Cells(131).Value
                myFormEstilos.Txt_DescripL5.Text = DescripLinea5
            End If

            If IdL6 > 0 Then
                myFormEstilos.Txt_IdL6.Text = IdL6
                myFormEstilos.Txt_L6.Text = DGrid.Rows(Renglon).Cells(132).Value
                myFormEstilos.Txt_DescripL6.Text = DescripLinea6
            End If

            myFormEstilos.Txt_Estilof.Text = DGrid.Rows(Renglon).Cells(10).Value
            myFormEstilos.Txt_Modelo.Text = DGrid.Rows(Renglon).Cells(11).Value
            DGrid.Rows(Renglon).Cells(11).ReadOnly = False

            '' agregar datos de descuento
            myFormEstilos.Sw_PedidoNuevo = True
            myFormEstilos.Txt_Dsctopp.Text = Txt_Dsctopp.Text
            myFormEstilos.Txt_Dscto01.Text = Txt_Dscto01.Text
            myFormEstilos.Txt_Dscto02.Text = Txt_Dscto02.Text
            myFormEstilos.Txt_Dscto03.Text = Txt_Dscto03.Text
            myFormEstilos.Txt_Dscto04.Text = Txt_Dscto04.Text
            myFormEstilos.Txt_Dscto05.Text = Txt_Dscto05.Text
            myFormEstilos.Txt_Iva.Text = Txt_Iva.Text

            myFormEstilos.ShowDialog()
            Sw_EditarEstilo = False
            If GLB_CatEsiloCancelado = False Then
                Sw_EditarEstilo = True
                ' DGrid.Rows(Renglon).Cells(11).Value = myFormEstilos.Txt_Modelo.Text
                ' DGrid.Rows(Renglon).Cells(12).Value = myFormEstilos.Txt_Descripc.Text
                'DGrid.Rows(Renglon).Cells(10).Value = myFormEstilos.Txt_Estilof.Text

                ' traer corrida
                'If Accion <> 2 Then
                '    If DGrid.Rows(Renglon).Cells(13).Value <> "" Then
                '        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                '            objDataSet = objCatalogoEstilos.usp_TraerCorrida(Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, DGrid.Rows(Renglon).Cells(13).Value)
                '            If objDataSet.Tables(0).Rows.Count = 1 Then
                '                Call TraerCorrida(Renglon, 13, DGrid.Rows(Renglon).Cells(13).Value)
                '            End If

                '        End Using
                '    End If
                'End If

                If Accion <> 2 Then
                    If DGrid.Rows(Renglon).Cells(13).Value <> "" Then
                        For z As Integer = 0 To DGrid.RowCount - 1
                            If DGrid.Rows(Renglon).Cells(11).Value = DGrid.Rows(z).Cells(11).Value Then
                                DGrid.Rows(z).Cells(11).Value = DGrid.Rows(Renglon).Cells(11).Value
                                DGrid.Rows(z).Cells(12).Value = DGrid.Rows(Renglon).Cells(12).Value
                                DGrid.Rows(z).Cells(10).Value = DGrid.Rows(Renglon).Cells(10).Value
                                Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                    objDataSet = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(Renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(z).Cells(11).Value, DGrid.Rows(z).Cells(13).Value, Txt_Proveedor.Text)
                                    If objDataSet.Tables(0).Rows.Count = 1 Then
                                        Call TraerCorrida(z, 13, DGrid.Rows(z).Cells(13).Value)
                                    End If

                                End Using
                            End If
                        Next

                    End If
                Else
                    If DGrid.Rows(Renglon).Cells(6).Value = "001" Then
                        Call TraerCorridaEdicion(Renglon, Txt_Sucursal.Text, Txt_OrdeComp.Text, DGrid.Rows(Renglon).Cells("c").Value)
                    Else
                        Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                            Dim objDataSet1 As Data.DataSet

                            objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(Renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, DGrid.Rows(Renglon).Cells("c").Value, Txt_Proveedor.Text)

                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                '' si existe estilo, traerlo.
                                Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                If M1 = "" Then
                                    M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                End If
                                If M2 = "" Then
                                    M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                End If
                                Call RellenarMedidas(Renglon, M1, M2, objDataSet.Tables(0).Rows(Renglon).Item("estilon").ToString, DGrid.Rows(Renglon).Cells("c").Value, DGrid.Rows(Renglon).Cells("i").Value, False, "", "")
                            End If
                        End Using


                    End If

                End If
                Sw_EditarEstilo = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Sucursal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Sucursal.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.LostFocus
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
            If Txt_Sucursal.Text.Length = 0 Then Exit Sub
            '  If Sw_FacturaNueva = True Then Exit Sub
            Try
                'Get the specific project selected in the ListView control
                If Txt_Sucursal.Text.Trim.Length < 2 Then
                    Txt_Sucursal.Text = pub_RellenarIzquierda(Txt_Sucursal.Text.Trim, 2)
                End If

                Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerOrdeComp()
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Dim objDataSet1 As Data.DataSet
            Try
                objDataSet = objPedidos.usp_TraerOrdeComp(Txt_Sucursal.Text, Txt_OrdeComp.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("descripsucursal").ToString
                    If Txt_DescripSucursal.Text.Length = 0 Then
                        Using objIVA As New BCL.BCLMySqlGral(GLB_ConStringPerSis)
                            objDataSet1 = objIVA.usp_TraerDescripcion("S", Txt_Sucursal.Text, "")
                            If objDataSet1.Tables(0).Rows.Count > 0 Then
                                Txt_DescripSucursal.Text = objDataSet1.Tables(0).Rows(0).Item("campo").ToString
                            End If

                        End Using
                    End If
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("contact1").ToString
                    Txt_Transporte.Text = objDataSet.Tables(0).Rows(0).Item("transp").ToString
                    Txt_Observa.Text = objDataSet.Tables(0).Rows(0).Item("observa").ToString
                    Txt_Fecha.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("fecha").ToString), "yyyy-MM-dd")
                    Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Txt_Diaspp.Text = objDataSet.Tables(0).Rows(0).Item("diaspp").ToString
                    Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                    Txt_Iva.Text = objDataSet.Tables(0).Rows(0).Item("iva").ToString
                    Txt_Email01.Text = objDataSet.Tables(0).Rows(0).Item("email01").ToString
                    Txt_Email02.Text = objDataSet.Tables(0).Rows(0).Item("email02").ToString
                    Txt_Gastos.Text = "0.0"

                    If objDataSet.Tables(0).Rows(0).Item("resurtsn").ToString = "N" Then
                        Lbl_ResurtSN.Text = "PEDIDO NUEVO"
                        ResurtSN = "N"
                    Else
                        ResurtSN = "S"  '' resurtido
                        Lbl_ResurtSN.Text = "RESURTIDO"
                        Me.Text = "Pedido Resurtido"
                    End If


                    If objDataSet.Tables(0).Rows(0).Item("tipopedido").ToString = "CATALOGO" Then
                        Opt_PedidoCatalogo.Checked = True
                        Opt_PedidoUnico.Checked = False
                    Else
                        Opt_PedidoUnico.Checked = True

                        Opt_PedidoCatalogo.Checked = False
                    End If
                    If Accion = 2 Then
                        Opt_PedidoCatalogo.Visible = True
                        Opt_PedidoUnico.Visible = True
                    End If

                End If




                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerFactProv()
        'mreyes 24/Marzo/2012 01:26 p.m. 
        Dim objDataSet As Data.DataSet
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                objDataSet = objPedidos.usp_TraerFactProv(Txt_Sucursal.Text, Txt_OrdeComp.Text, Val(FolioB), Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If Sw_Devolucion = True Then
                        If objDataSet.Tables(0).Rows(0).Item("pagado") = 1 Then
                            MsgBox("La factura ya se encuentra pagada, no puede generar una devolución. Avise a su Coordinador de Recibo.", MsgBoxStyle.Critical, "Aviso")
                            Me.Close()
                            Me.Dispose()
                            Exit Sub
                        End If
                    End If

                    If Val(FolioB) > 0 Then
                        Txt_Referenc.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString
                        Txt_OrdeComp.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString

                    End If
                    If Mid(Txt_Referenc.Text, 1, 1) = "R" Then
                        Opt_Factura.Checked = False
                        Opt_Remision.Checked = True
                    End If
                    Txt_NoBulto.Text = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString, 6)
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("descripsucursal").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    IdProveedorB = objDataSet.Tables(0).Rows(0).Item("idproveedor")
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("contact1").ToString
                    Txt_Transporte.Text = objDataSet.Tables(0).Rows(0).Item("transp").ToString
                    Txt_Observa.Text = objDataSet.Tables(0).Rows(0).Item("observa").ToString

                    Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Txt_Diaspp.Text = objDataSet.Tables(0).Rows(0).Item("diaspp").ToString
                    Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                    If Sw_Remision = True Then
                        Txt_Iva.Text = "0"
                    Else
                        Txt_Iva.Text = objDataSet.Tables(0).Rows(0).Item("iva").ToString
                    End If
                    Txt_Email01.Text = objDataSet.Tables(0).Rows(0).Item("email01").ToString
                    Txt_Email02.Text = objDataSet.Tables(0).Rows(0).Item("email02").ToString
                    Txt_Gastos.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("gastos")), "$#,##0.00")
                    Txt_Descuento.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("descuento")), "$#,##0.00")
                    Txt_Fecha.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("fecreci").ToString), "yyyy-MM-dd")
                    Txt_FechaFactura.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("fecha").ToString), "yyyy-MM-dd")
                    Txt_FechaVence.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("fecvenc").ToString), "yyyy-MM-dd")

                    Txt_BaseVence.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("entregavence").ToString), "yyyy-MM-dd")


                    Txt_FactProv.Text = objDataSet.Tables(0).Rows(0).Item("factprov").ToString

                    Lbl_ResurtSN.Text = "FACTURA"
                    ResurtSN = "N"

                    Me.Text = "Detalle Factura"
                    Txt_NotaCargo.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("cargo")), "$#,##0.00")
                    Txt_NotaCredito.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("credito")), "$#,##0.00")

                    Txt_Improcedente.Text = Format(Val(objDataSet.Tables(0).Rows(0).Item("improcedente")), "$#,##0.00")

                End If




                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Function usp_ExisteFactProv() As Boolean
        'mreyes 23/Mayo/2012 05:07 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                Dim Referenc As String = ""
                If Txt_Referenc.Text.Length <> 10 Then
                    If Opt_Factura.Checked = True Then
                        Referenc = "F-" & pub_RellenarIzquierda(Txt_Referenc.Text, 8)
                    Else
                        Referenc = "R-" & pub_RellenarIzquierda(Txt_Referenc.Text, 8)
                    End If
                End If

                objDataSet = objPedidos.usp_ExisteFactProv(Txt_Sucursal.Text, Referenc)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If objDataSet.Tables(0).Rows(0).Item("factprov").ToString.Length = 0 Then
                        usp_ExisteFactProv = False
                    Else
                        usp_ExisteFactProv = True
                    End If
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub usp_TraerDevProv()
        'mreyes 29/Marzo/2012 11:03 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                objDataSet = objPedidos.usp_TraerDevProv(Txt_Sucursal.Text, Txt_OrdeComp.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Txt_Marca.Text = objDataSet.Tables(0).Rows(0).Item("marca").ToString
                    Txt_DescripMarca.Text = objDataSet.Tables(0).Rows(0).Item("descripmarca").ToString
                    Txt_Sucursal.Text = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                    Txt_DescripSucursal.Text = objDataSet.Tables(0).Rows(0).Item("descripsucursal").ToString
                    Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
                    Txt_Raz_Soc.Text = objDataSet.Tables(0).Rows(0).Item("raz_soc").ToString
                    Txt_Vendedor.Text = objDataSet.Tables(0).Rows(0).Item("contact1").ToString
                    Txt_Transporte.Text = objDataSet.Tables(0).Rows(0).Item("transp").ToString
                    Txt_Observa.Text = objDataSet.Tables(0).Rows(0).Item("observa").ToString
                    Txt_Fecha.Text = Format(CDate(objDataSet.Tables(0).Rows(0).Item("fecha").ToString), "yyyy-MM-dd")
                    Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Txt_Diaspp.Text = objDataSet.Tables(0).Rows(0).Item("diaspp").ToString
                    Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                    Txt_Iva.Text = objDataSet.Tables(0).Rows(0).Item("iva").ToString
                    Txt_Email01.Text = objDataSet.Tables(0).Rows(0).Item("email01").ToString
                    Txt_Email02.Text = objDataSet.Tables(0).Rows(0).Item("email02").ToString

                    Txt_Referenc.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString
                    Txt_FactProv.Text = objDataSet.Tables(0).Rows(0).Item("referenc").ToString
                    Txt_NoBulto.Text = objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString
                    Txt_Gastos.Text = "0.0"

                    Lbl_ResurtSN.Text = "DEVOLUCIÓN"
                    ResurtSN = "N"

                    Me.Text = "Detalle Devolución a Proveedor"


                End If




                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub usp_TraerDet_Oc()
        'mreyes 18/Febrero/2012 10:02 a.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Corrida As String
                Dim Entrega As Date
                Dim Cancela As Date
                Dim margen As Double
                Dim Sucursal As String = ""
                Dim sw_columna As Boolean = False


                objDataSet = objPedidos.usp_TraerDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text)
                DGrid.Visible = False
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1

                        'If objDataSet.Tables(0).Rows(I).Item("estilon").ToString = "    471" Then
                        '    MsgBox("parar")
                        'End If

                        Corrida = objDataSet.Tables(0).Rows(I).Item("corrida").ToString
                        Entrega = Format(objDataSet.Tables(0).Rows(I).Item("entrega"), "dd-MM-yyyy")
                        Txt_FechaEntrega.Text = Entrega
                        Cancela = Format(objDataSet.Tables(0).Rows(I).Item("cancela"), "dd-MM-yyyy")

                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("pcomp"))), "#0.00")
                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("costo"))), "#0.00")
                        MedidaEstilo = objDataSet.Tables(0).Rows(I).Item("medida")
                        DGrid.Rows.Add("", "", "", "", "", "", objDataSet.Tables(0).Rows(I).Item("claveedi").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveed").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveff").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveel").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilof").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilon"),
                                         objDataSet.Tables(0).Rows(I).Item("descripc"),
                                         objDataSet.Tables(0).Rows(I).Item("corrida").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("intervalo").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medini").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medfin").ToString,
                                          Format(Val(objDataSet.Tables(0).Rows(I).Item("pcomp").ToString), "#,##0.00"), Format(Val(objDataSet.Tables(0).Rows(I).Item("costo").ToString), "#,##0.00"),
                                         Format(Val(objDataSet.Tables(0).Rows(I).Item("precio").ToString), "#,##0.00"), Format(margen, "#0.00"),
                                         Txt_Sucursal.Text, Txt_DescripSucursal.Text, "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Entrega, Cancela,
                                         objDataSet.Tables(0).Rows(I).Item("clavel1").ToString, objDataSet.Tables(0).Rows(I).Item("clavel2").ToString,
                                          objDataSet.Tables(0).Rows(I).Item("clavel3").ToString, objDataSet.Tables(0).Rows(I).Item("clavel4").ToString,
                                        objDataSet.Tables(0).Rows(I).Item("clavel5").ToString, objDataSet.Tables(0).Rows(I).Item("clavel6").ToString,
                                        objDataSet.Tables(0).Rows(I).Item("descripdivision") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripdepto") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripfamilia") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descriplinea") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl1") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl2") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl3") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl4") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl5") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl6"), "",
                                                                        objDataSet.Tables(0).Rows(I).Item("idarticulo"),
                                                                        objDataSet.Tables(0).Rows(I).Item("idusuariocancela"),
                                                                        objDataSet.Tables(0).Rows(I).Item("fumcancela"))

                        '' ''If objDataSet.Tables(0).Rows(I).Item("tipoart").ToString = "C" Then
                        '' ''    Call TraerCorridaEdicion(I, Corrida)
                        '' ''Else
                        '' ''    Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
                        '' ''        Dim objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(Txt_Marca.Text, DGrid.Rows(I).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString)

                        '' ''        If objDataSet.Tables(0).Rows.Count > 0 Then
                        '' ''            '' si existe estilo, traerlo.

                        '' ''            Call RellenarMedidas(I, objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString, objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString)
                        '' ''        End If
                        '' ''    End Using


                        '' ''End If

                        If objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "001" Or objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "C" Then
                            Call TraerCorridaEdicion(I, Txt_Sucursal.Text, Txt_OrdeComp.Text, Corrida)
                        Else
                            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                Dim objDataSet1 As Data.DataSet

                                objDataSet1 = objCatalogoEstilos.usp_TraerCorrida("", Txt_Marca.Text, DGrid.Rows(I).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, Txt_Proveedor.Text)

                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                    '' si existe estilo, traerlo.
                                    Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                    Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                    If M1 = "" Then
                                        M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                    End If
                                    If M2 = "" Then
                                        M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                    End If
                                    Call RellenarMedidas(I, M1, M2, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, False, "", "")
                                End If
                            End Using


                        End If
                        'cHECAR SI ESTA CANCELADO
                        If objDataSet.Tables(0).Rows(I).Item("idusuariocancela") > 0 Then
                            For x As Integer = 0 To DGrid.ColumnCount - 1
                                DGrid.Rows(I).Cells(x).Style.BackColor = Color.Red
                                DGrid.Rows(I).Cells(x).Style.Font = New Font(DGrid.DefaultCellStyle.Font.FontFamily, DGrid.DefaultCellStyle.Font.Size, FontStyle.Bold)

                            Next

                        End If
                    Next

                End If

                DGrid.Columns("idusuariocancela").Visible = True
                DGrid.Columns("fumcancela").Visible = True

                DGrid.Visible = True

                If Accion = 2 And sw_columna = False Then 'EDITAR
                    sw_columna = True
                    AgregarColumna()
                    Btn_CancelarPedido.Visible = True
                    Btn_InvertirSeleccion.Visible = True
                End If

                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerOrdeCompBulto(ByVal Sucursal As String, ByVal OrdeComp As String)
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Dim objDataSet As Data.DataSet
            Try
                objDataSet = objPedidos.usp_TraerOrdeComp(Sucursal, OrdeComp)

                If objDataSet.Tables(0).Rows.Count > 0 Then


                    Txt_Dsctopp.Text = objDataSet.Tables(0).Rows(0).Item("dsctopp").ToString
                    Txt_Diaspp.Text = objDataSet.Tables(0).Rows(0).Item("diaspp").ToString
                    Txt_Dscto01.Text = objDataSet.Tables(0).Rows(0).Item("dscto01").ToString
                    Txt_Dscto02.Text = objDataSet.Tables(0).Rows(0).Item("dscto02").ToString
                    Txt_Dscto03.Text = objDataSet.Tables(0).Rows(0).Item("dscto03").ToString
                    Txt_Dscto04.Text = objDataSet.Tables(0).Rows(0).Item("dscto04").ToString
                    Txt_Dscto05.Text = objDataSet.Tables(0).Rows(0).Item("dscto05").ToString
                    Txt_Iva.Text = objDataSet.Tables(0).Rows(0).Item("iva").ToString

                    If Val(Txt_Iva.Text) > 0 Then
                        Opt_Factura.Checked = True
                        Opt_Remision.Checked = False
                    Else
                        Opt_Remision.Checked = True
                        Opt_Factura.Checked = False

                    End If

                    If objDataSet.Tables(0).Rows(0).Item("BASEVENC").ToString = "F" Then
                        Sw_FechaVenceFactura = True
                    Else
                        Sw_FechaVenceFactura = False
                    End If


                End If
                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Function usp_TraerOrdeCompMaxEntrega(ByVal Sucursal As String, ByVal OrdeComp As String) As Date
        'mreyes 22/Enero/2014 06:22 p.m.
        usp_TraerOrdeCompMaxEntrega = "1900-01-01"
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Dim objDataSet As Data.DataSet
            Try
                objDataSet = objPedidos.usp_TraerOrdeCompMaxEntrega(Sucursal, OrdeComp)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    usp_TraerOrdeCompMaxEntrega = objDataSet.Tables(0).Rows(0).Item("entrega").ToString
                End If
                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub usp_TraerDet_OcBultos(ByVal SucOrdeComp As String, ByVal OrdeComp As String, ByVal Renglones As Integer)
        'mreyes 31/Enero/2013 01:56 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Corrida As String
                Dim Entrega As Date
                Dim Cancela As Date
                Dim margen As Decimal
                Dim Sucursal As String = ""

                'x()
                ' Renglones = Renglones + 1
                objDataSet = objPedidos.usp_TraerDet_Oc(SucOrdeComp, OrdeComp)
                DGrid.Visible = False
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Txt_Marca.Text = objDataSet.Tables(0).Rows(I).Item("marca").ToString
                        Corrida = objDataSet.Tables(0).Rows(I).Item("corrida").ToString
                        Entrega = Format(objDataSet.Tables(0).Rows(I).Item("entrega"), "dd-MM-yyyy")
                        Txt_FechaEntrega.Text = Entrega
                        Cancela = Format(objDataSet.Tables(0).Rows(I).Item("cancela"), "dd-MM-yyyy")

                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("pcomp"))), "#0.00")
                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("costo"))), "#0.00")
                        MedidaEstilo = objDataSet.Tables(0).Rows(I).Item("medida")
                        DGrid.Rows.Add(SucOrdeComp, OrdeComp, "", "", "", "", objDataSet.Tables(0).Rows(I).Item("claveedi").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveed").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveff").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveel").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilof").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilon"),
                                         objDataSet.Tables(0).Rows(I).Item("descripc"),
                                         objDataSet.Tables(0).Rows(I).Item("corrida").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("intervalo").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medini").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medfin").ToString,
                                          Format(Val(objDataSet.Tables(0).Rows(I).Item("pcomp").ToString), "#,##0.00"), Format(Val(objDataSet.Tables(0).Rows(I).Item("costo").ToString), "#,##0.00"),
                                         Format(Val(objDataSet.Tables(0).Rows(I).Item("precio").ToString), "#,##0.00"), Format(margen, "#0.00"),
                                         SucOrdeComp, Txt_DescripSucursal.Text, "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Entrega, Cancela,
                                         objDataSet.Tables(0).Rows(I).Item("clavel1").ToString, objDataSet.Tables(0).Rows(I).Item("clavel2").ToString,
                                          objDataSet.Tables(0).Rows(I).Item("clavel3").ToString, objDataSet.Tables(0).Rows(I).Item("clavel4").ToString,
                                        objDataSet.Tables(0).Rows(I).Item("clavel5").ToString, objDataSet.Tables(0).Rows(I).Item("clavel6").ToString,
                                        objDataSet.Tables(0).Rows(I).Item("descripdivision") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripdepto") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripfamilia") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descriplinea") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl1") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl2") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl3") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl4") & "\" &
                                                                        objDataSet.Tables(0).Rows(I).Item("descripl5") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl6"), "", objDataSet.Tables(0).Rows(I).Item("IDARTICULO"))




                        '' ''If objDataSet.Tables(0).Rows(I).Item("tipoart").ToString = "C" Then
                        '' ''    Call TraerCorridaEdicion(I, Corrida)
                        '' ''Else
                        '' ''    Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(Glb_ConStringCipSis)
                        '' ''        Dim objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(Txt_Marca.Text, DGrid.Rows(I).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString)

                        '' ''        If objDataSet.Tables(0).Rows.Count > 0 Then
                        '' ''            '' si existe estilo, traerlo.

                        '' ''            Call RellenarMedidas(I, objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString, objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString)
                        '' ''        End If
                        '' ''    End Using


                        '' ''End If
                        If objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "999" Then
                            MsgBox("Estilo " & objDataSet.Tables(0).Rows(I).Item("estilon").ToString & " NO TIENE ESTRUCTURA ASIGNADA, REPORTELO A COMPRAS", MsgBoxStyle.Critical, "AVISO")
                        End If

                        If objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "001" Or objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "C" Then
                            ' AQUI SERIA EL RENGLON MENOS UNO 
                            Dim X As Integer = DGrid.RowCount - 2
                            'Call TraerCorridaEdicion(I, SucOrdeComp, OrdeComp, Corrida)
                            Call TraerCorridaEdicion(X, SucOrdeComp, OrdeComp, Corrida)
                        Else
                            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                Dim objDataSet1 As Data.DataSet

                                'If DGrid.Rows(DGrid.RowCount - 2).Cells(11).Value = "   1373" Then
                                ' MsgBox("PARAR")
                                ' End If
                                objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(SucOrdeComp, Txt_Marca.Text, DGrid.Rows(DGrid.RowCount - 2).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, Txt_Proveedor.Text)

                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                    '' si existe estilo, traerlo.
                                    Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                    Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                    If M1 = "" Then
                                        M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                    End If
                                    If M2 = "" Then
                                        M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                    End If
                                    Dim X As Integer = DGrid.RowCount - 2
                                    Call RellenarMedidas(X, M1, M2, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, False, SucOrdeComp, OrdeComp)
                                    ' Call RellenarMedidas(Renglones, M1, M2, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, False, SucOrdeComp, OrdeComp)
                                End If
                            End Using


                        End If
                    Next

                End If

                DGrid.Visible = True


                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using

    End Sub
    Private Sub usp_TraerPedidosBultos()
        'mreyes 31/Enero/2013 01:14 p.m.
        Using objPedidos As New BCL.BCLBulto(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Pedido As String = ""
                Dim Sucursal As String = ""
                Dim FechaEntregaMaxAnterior As Date = "1900-01-01"
                Dim Renglones As Integer = 0


                objDataSet = objPedidos.usp_TraerDetBulto(Val(FolioB), "", "")
                DGrid.Visible = False
                Renglones = 0
                If objDataSet.Tables(0).Rows.Count > 0 Then

                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Sucursal = Mid(objDataSet.Tables(0).Rows(0).Item("pedido").ToString, 1, 2)
                        Pedido = Mid(objDataSet.Tables(0).Rows(0).Item("pedido").ToString, 3, 6)
                        If Pedido = "" Or Pedido = "000000" Then
                            MsgBox("El folio de bulto '" & Txt_NoBulto.Text & "' fue solo recibo, hay que editarlo con el pedido correcto", MsgBoxStyle.Critical, "Validación")
                            Exit Sub
                        End If


                        'Txt_Sucursal.Text = Sucursal
                        'Txt_OrdeComp.Text = Pedido

                        Call usp_TraerDet_OcBultos(Sucursal, Pedido, Renglones)
                        Renglones = Renglones + 1
                        Call usp_TraerOrdeCompBulto(Sucursal, Pedido)
                        FechaEntregaMaxAnterior = usp_TraerOrdeCompMaxEntrega(Sucursal, Pedido)
                        If FechaEntregaMaxAnterior > FechaEntregaMax Then
                            FechaEntregaMax = FechaEntregaMaxAnterior
                        End If
                    Next

                End If

                DGrid.Visible = True


                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerDet_FP()
        'mreyes 24/Marzo/2012 01:44 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Corrida As String
                Dim Entrega As Date
                Dim Cancela As Date
                Dim margen As Decimal
                objDataSet = objPedidos.usp_TraerDet_FP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Val(FolioB))
                DGrid.Visible = False
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Corrida = objDataSet.Tables(0).Rows(I).Item("corrida").ToString
                        Entrega = "01-01-1900"

                        Cancela = "01-01-1900"
                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(0).Item("PCOMP"))), "#0.00")
                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("pcomp"))), "#0.00")
                        MedidaEstilo = objDataSet.Tables(0).Rows(I).Item("medida")
                        DGrid.Rows.Add(objDataSet.Tables(0).Rows(I).Item("sucurorc").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("ordecomp").ToString,
                                       "", "", "", "", objDataSet.Tables(0).Rows(I).Item("claveedi").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveed").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveff").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveel").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilof").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilon"),
                                         objDataSet.Tables(0).Rows(I).Item("descripc"),
                                         objDataSet.Tables(0).Rows(I).Item("corrida").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("intervalo").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medini").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medfin").ToString,
                                          Format(Val(objDataSet.Tables(0).Rows(I).Item("pcomp").ToString), "#,##0.00"), Format(Val(objDataSet.Tables(0).Rows(I).Item("costo").ToString), "#,##0.00"),
                                         Format(Val(objDataSet.Tables(0).Rows(I).Item("precio").ToString), "#,##0.00"), Format(margen, "#0.00"),
                                        Txt_Sucursal.Text, Txt_DescripSucursal.Text,
                                        "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Entrega, Cancela,
                                        objDataSet.Tables(0).Rows(I).Item("clavel1").ToString, objDataSet.Tables(0).Rows(I).Item("clavel2").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("clavel3").ToString, objDataSet.Tables(0).Rows(I).Item("clavel4").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("clavel5").ToString, objDataSet.Tables(0).Rows(I).Item("clavel6").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("descripdivision") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripdepto") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripfamilia") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descriplinea") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl1") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl2") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl3") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl4") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl5") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl6"))







                        DGrid.Columns(125).Visible = False
                        DGrid.Columns(126).Visible = False



                        If objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "001" Or objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "C" Then
                            Call TraerCorridaEdicionFactProv(I, Corrida)
                        Else
                            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                Dim objDataSet1 As Data.DataSet

                                objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(objDataSet.Tables(0).Rows(I).Item("sucurorc").ToString, Txt_Marca.Text, DGrid.Rows(I).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, Txt_Proveedor.Text)

                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                    '' si existe estilo, traerlo.
                                    Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                    Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                    If M1 = "" Then
                                        M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                    End If
                                    If M2 = "" Then
                                        M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                    End If
                                    Call RellenarMedidas(I, M1, M2, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, False, "", "")
                                End If
                            End Using


                        End If
                    Next

                End If

                DGrid.Visible = True


                '''' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub usp_TraerDet_DP()
        'mreyes 29/Marzo/2012 11:08 a.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringCipSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Corrida As String
                Dim Entrega As Date
                Dim Cancela As Date
                Dim margen As Decimal
                FolioB = 0

                objDataSet = objPedidos.usp_TraerDet_DP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Val(FolioB))
                DGrid.Visible = False
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        Corrida = objDataSet.Tables(0).Rows(I).Item("corrida").ToString
                        Entrega = "01-01-1900"

                        Cancela = "01-01-1900"
                        margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Val(objDataSet.Tables(0).Rows(I).Item("costo"))), "#0.00")
                        MedidaEstilo = objDataSet.Tables(0).Rows(I).Item("medida")
                        DGrid.Rows.Add("",
                                       "",
                                       "", "", "", "", objDataSet.Tables(0).Rows(I).Item("claveedi").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveed").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveff").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("claveel").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilof").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("estilon"),
                                         objDataSet.Tables(0).Rows(I).Item("descripc"),
                                         objDataSet.Tables(0).Rows(I).Item("corrida").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("intervalo").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medini").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("medfin").ToString,
                                          Format(Val(objDataSet.Tables(0).Rows(I).Item("pcomp").ToString), "#,##0.00"), Format(Val(objDataSet.Tables(0).Rows(I).Item("costo").ToString), "#,##0.00"),
                                         Format(Val(objDataSet.Tables(0).Rows(I).Item("precio").ToString), "#,##0.00"), Format(margen, "#0.00"),
                                        Txt_Sucursal.Text, Txt_DescripSucursal.Text,
                                        "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                         "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Entrega, Cancela,
                                        objDataSet.Tables(0).Rows(I).Item("clavel1").ToString, objDataSet.Tables(0).Rows(I).Item("clavel2").ToString,
                                         objDataSet.Tables(0).Rows(I).Item("clavel3").ToString, objDataSet.Tables(0).Rows(I).Item("clavel4").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("clavel5").ToString, objDataSet.Tables(0).Rows(I).Item("clavel6").ToString,
                                       objDataSet.Tables(0).Rows(I).Item("descripdivision") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripdepto") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripfamilia") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descriplinea") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl1") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl2") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl3") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl4") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl5") & "\" &
                                                                       objDataSet.Tables(0).Rows(I).Item("descripl6"))


                        DGrid.Columns(125).Visible = False
                        DGrid.Columns(126).Visible = False
                        DGrid.Columns(0).Visible = False
                        DGrid.Columns(1).Visible = False


                        If objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "001" Or objDataSet.Tables(0).Rows(I).Item("claveedi").ToString = "C" Then
                            Call TraerCorridaEdicionDevProv(I, Corrida)
                        Else
                            Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                Dim objDataSet1 As Data.DataSet

                                objDataSet1 = objCatalogoEstilos.usp_TraerCorrida("", Txt_Marca.Text, DGrid.Rows(I).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, Txt_Proveedor.Text)

                                If objDataSet1.Tables(0).Rows.Count > 0 Then
                                    '' si existe estilo, traerlo.
                                    Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                    Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                    If M1 = "" Then
                                        M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                    End If
                                    If M2 = "" Then
                                        M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                    End If
                                    Call RellenarMedidas(I, M1, M2, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, False, "", "")
                                End If
                            End Using


                        End If





                    Next

                End If

                DGrid.Visible = True


                ' LLENAR DETALLADO DE ORDE COMP
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub



    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Sucursal.TextChanged
        If Txt_Sucursal.Text.Length = 2 Then
            Txt_Marca.Focus()
        End If
    End Sub





    Private Sub TraerCorridaEdicion(ByVal Renglon As Integer, ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Corrida As String)
        'mreyes 18/Febrero/2012 10:20 a.m.
        Try

            Dim Cantidad As Double


            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Dim objDataSet1 As Data.DataSet
                Dim Medida As String
                Dim Entrega As Date

                Entrega = Format(DGrid.Rows(Renglon).Cells("FechaEntrega").Value, "yyyy-MM-dd")
                If Chk_VerPendientexRecibir.Checked = False Then
                    objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Sucursal, OrdeComp, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "", Entrega)
                Else
                    objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Sucursal, OrdeComp, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "", Entrega)
                End If

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                        Cantidad = Val(objDataSet1.Tables(0).Rows(I).Item("ctd"))
                        Medida = objDataSet1.Tables(0).Rows(I).Item("medida")
                        Call RellenarCorridaEdicion(Renglon, Medida, Cantidad)
                        '  DGrid.Rows(Renglon).Cells("c").ReadOnly = True
                    Next
                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TraerCorridaEdicionArticulosSolicitados(ByVal Renglon As Integer, ByVal Corrida As String)
        'mreyes 23/Marzo/2012 10:20 a.m.
        Try

            Dim Cantidad As Double


            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Dim objDataSet1 As Data.DataSet
                Dim Medida As String
                ' AQUI ES EL ERROR
                objDataSet1 = objCantidadesDet_Oc.usp_TraerCantArtSolicitados(Txt_Marca.Text, Txt_Proveedor.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "")

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                        Cantidad = Val(objDataSet1.Tables(0).Rows(I).Item("ctd"))
                        Medida = objDataSet1.Tables(0).Rows(I).Item("medida")
                        Call RellenarCorridaEdicion(Renglon, Medida, Cantidad)
                        '  DGrid.Rows(Renglon).Cells("c").ReadOnly = True

                    Next
                End If
                If Txt_Sucursal.Visible = True Then
                    DGrid.Rows(Renglon).Cells("csuc").Value = Txt_Sucursal.Text
                    DGrid.Rows(Renglon).Cells("sucdescrip").Value = Txt_DescripSucursal.Text
                    DGrid.Columns("csuc").Visible = False
                    DGrid.Columns("sucdescrip").Visible = False

                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TraerCorridaEdicionFactProv(ByVal Renglon As Integer, ByVal Corrida As String)
        'mreyes 24/Marzo/2012 02:08 p.m.
        Try

            Dim Cantidad As Double


            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Dim objDataSet1 As Data.DataSet
                Dim Medida As String

                objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_FP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "", Val(FolioB))

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                        Cantidad = Val(objDataSet1.Tables(0).Rows(I).Item("ctd"))
                        Medida = objDataSet1.Tables(0).Rows(I).Item("medida")
                        Call RellenarCorridaEdicion(Renglon, Medida, Cantidad)
                        '  DGrid.Rows(Renglon).Cells("c").ReadOnly = True
                    Next
                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub TraerCorridaEdicionDevProv(ByVal Renglon As Integer, ByVal Corrida As String)
        'mreyes 29/Marzo/2012 11:23 p.m.
        Try

            Dim Cantidad As Double


            Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Dim objDataSet1 As Data.DataSet
                Dim Medida As String

                objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_DP(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "")

                If objDataSet1.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                        Cantidad = Val(objDataSet1.Tables(0).Rows(I).Item("ctd"))
                        Medida = objDataSet1.Tables(0).Rows(I).Item("medida")

                        Call RellenarCorridaEdicion(Renglon, Medida, Cantidad)

                        '  DGrid.Rows(Renglon).Cells("c").ReadOnly = True
                    Next
                End If
            End Using

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub TraerCorridaMedidasEdicion(ByVal Renglon As Integer, ByVal Corrida As String)
        'mreyes 23/Febrero/2012 07:36 p.m.
        Try
            Using objCorrida As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim Cantidad As Double
                Dim Entrega As Date
                objDataSet = objCorrida.usp_TraerCorrida(DGrid.Rows(Renglon).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, Txt_Proveedor.Text)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    '' si existe estilo, traerlo.
                    ' 13 corrida, 14 intervalo, 15 medini, 16 medfin
                    DGrid.Rows(Renglon).Cells("c").Value = objDataSet.Tables(0).Rows(0).Item("corrida").ToString
                    DGrid.Rows(Renglon).Cells("i").Value = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    DGrid.Rows(Renglon).Cells("de").Value = objDataSet.Tables(0).Rows(0).Item("medini").ToString
                    DGrid.Rows(Renglon).Cells("a").Value = objDataSet.Tables(0).Rows(0).Item("medfin").ToString


                    DGrid.Rows(Renglon).Cells("pcomp").Value = Format(Val(objDataSet.Tables(0).Rows(0).Item("costo").ToString), "#,##0.00")
                    DGrid.Rows(Renglon).Cells("precio").Value = Format(Val(objDataSet.Tables(0).Rows(0).Item("precio").ToString), "#,##0.00")
                    ' calcular costo
                    DGrid.Rows(Renglon).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(objDataSet.Tables(0).Rows(0).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
                    DGrid.Rows(Renglon).Cells("porc").Value = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(0).Item("precio")), DGrid.Rows(Renglon).Cells("costo").Value), "#0.00")
                    CorridaAnterior = Corrida
                    IntervaloAnterior = objDataSet.Tables(0).Rows(0).Item("intervalo").ToString
                    MedIniAnterior = Val(objDataSet.Tables(0).Rows(0).Item("medini"))
                    MedFinAnterior = Val(objDataSet.Tables(0).Rows(0).Item("medfin"))
                    ' HACER VISIBLES LAS COLUMNAS SEGÚN LOS INTERVALOS
                    Entrega = DGrid.Rows(Renglon).Cells("FechaEntrega").Value
                    ' traer valores en base a la medida ,
                    Using objCantidadesDet_Oc As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        Dim objDataSet1 As Data.DataSet
                        Dim Medida As String
                        If Chk_VerPendientexRecibir.Checked = False Then
                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "", Entrega)
                        Else
                            objDataSet1 = objCantidadesDet_Oc.usp_TraerCantidadesSXRecDet_Oc(Txt_Sucursal.Text, Txt_OrdeComp.Text, Txt_Marca.Text, DGrid.Rows(Renglon).Cells(11).Value, Corrida, "", Entrega)
                        End If


                        If objDataSet1.Tables(0).Rows.Count > 0 Then
                            For I As Integer = 0 To objDataSet1.Tables(0).Rows.Count - 1
                                Cantidad = Val(objDataSet1.Tables(0).Rows(I).Item("ctd"))
                                Medida = objDataSet1.Tables(0).Rows(I).Item("medida")
                                Call RellenarCorridaEdicion(Renglon, Medida, Cantidad)

                                '  DGrid.Rows(Renglon).Cells("c").ReadOnly = True
                            Next
                        End If
                    End Using
                End If
            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub RellenarCorridaEdicion(ByVal Renglon As Integer, ByVal Medida As String, ByVal Cantidad As Integer)
        'mreyes 18/Febrero/2012 11:09 a.m.
        Try

            Call RellenarColumnasCorridaEdicion(Renglon, Medida, Cantidad)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub RellenarColumnasCorrida(ByVal Renglon As Integer, ByVal Medida As Integer, Optional ByVal Cantidad As Integer = 0, Optional ByVal EmpNeg As Integer = 0, Optional ByVal FinNeg As Integer = 0, Optional ByVal MedUltNeg As String = "", Optional ByVal MedIniNeg As String = "")
        'mreyes 24/Febrero/2012 04:58 p.m.
        Try

            If Medida = 1 Then

                If EmpNeg = 0 Then
                    DGrid.Columns("M1").Visible = True
                    DGrid.Rows(Renglon).Cells("M1").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M1").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M1_").Visible = True
                        DGrid.Rows(Renglon).Cells("M1_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M1_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M1_").Visible = True
                            DGrid.Rows(Renglon).Cells("M1_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M1_").Value = Cantidad
                            End If
                        End If
                    End If
                End If

            End If

            If Medida = 2 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M2").Visible = True
                    DGrid.Rows(Renglon).Cells("M2").Style.BackColor = Color.Yellow
                    If Accion <> 2 Then
                        DGrid.Rows(Renglon).Cells("M2").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M2_").Visible = True
                        DGrid.Rows(Renglon).Cells("M2_").Style.BackColor = Color.Yellow
                        If Accion <> 2 Then
                            DGrid.Rows(Renglon).Cells("M2_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M2_").Visible = True
                            DGrid.Rows(Renglon).Cells("M2_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M2_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If


            If Medida = 3 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M3").Visible = True
                    DGrid.Rows(Renglon).Cells("M3").Style.BackColor = Color.Yellow
                    If Accion <> 3 Then
                        DGrid.Rows(Renglon).Cells("M3").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M3_").Visible = True
                        DGrid.Rows(Renglon).Cells("M3_").Style.BackColor = Color.Yellow
                        If Accion <> 3 Then
                            DGrid.Rows(Renglon).Cells("M3_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M3_").Visible = True
                            DGrid.Rows(Renglon).Cells("M3_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M3_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If


            If Medida = 4 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M4").Visible = True
                    DGrid.Rows(Renglon).Cells("M4").Style.BackColor = Color.Yellow
                    If Accion <> 4 Then
                        DGrid.Rows(Renglon).Cells("M4").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M4_").Visible = True
                        DGrid.Rows(Renglon).Cells("M4_").Style.BackColor = Color.Yellow
                        If Accion <> 4 Then
                            DGrid.Rows(Renglon).Cells("M4_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M4_").Visible = True
                            DGrid.Rows(Renglon).Cells("M4_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M4_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 5 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M5").Visible = True
                    DGrid.Rows(Renglon).Cells("M5").Style.BackColor = Color.Yellow
                    If Accion <> 5 Then
                        DGrid.Rows(Renglon).Cells("M5").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M5_").Visible = True
                        DGrid.Rows(Renglon).Cells("M5_").Style.BackColor = Color.Yellow
                        If Accion <> 5 Then
                            DGrid.Rows(Renglon).Cells("M5_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M5_").Visible = True
                            DGrid.Rows(Renglon).Cells("M5_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M5_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 6 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M6").Visible = True
                    DGrid.Rows(Renglon).Cells("M6").Style.BackColor = Color.Yellow
                    If Accion <> 6 Then
                        DGrid.Rows(Renglon).Cells("M6").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M6_").Visible = True
                        DGrid.Rows(Renglon).Cells("M6_").Style.BackColor = Color.Yellow
                        If Accion <> 6 Then
                            DGrid.Rows(Renglon).Cells("M6_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M6_").Visible = True
                            DGrid.Rows(Renglon).Cells("M6_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M6_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 7 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M7").Visible = True
                    DGrid.Rows(Renglon).Cells("M7").Style.BackColor = Color.Yellow
                    If Accion <> 7 Then
                        DGrid.Rows(Renglon).Cells("M7").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M7_").Visible = True
                        DGrid.Rows(Renglon).Cells("M7_").Style.BackColor = Color.Yellow
                        If Accion <> 7 Then
                            DGrid.Rows(Renglon).Cells("M7_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M7_").Visible = True
                            DGrid.Rows(Renglon).Cells("M7_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M7_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 8 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M8").Visible = True
                    DGrid.Rows(Renglon).Cells("M8").Style.BackColor = Color.Yellow
                    If Accion <> 8 Then
                        DGrid.Rows(Renglon).Cells("M8").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M8_").Visible = True
                        DGrid.Rows(Renglon).Cells("M8_").Style.BackColor = Color.Yellow
                        If Accion <> 8 Then
                            DGrid.Rows(Renglon).Cells("M8_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M8_").Visible = True
                            DGrid.Rows(Renglon).Cells("M8_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M8_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 9 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M9").Visible = True
                    DGrid.Rows(Renglon).Cells("M9").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M9").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M9_").Visible = True
                        DGrid.Rows(Renglon).Cells("M9_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M9_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M9_").Visible = True
                            DGrid.Rows(Renglon).Cells("M9_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M9_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 10 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M10").Visible = True
                    DGrid.Rows(Renglon).Cells("M10").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M10").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M10_").Visible = True
                        DGrid.Rows(Renglon).Cells("M10_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M10_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M10_").Visible = True
                            DGrid.Rows(Renglon).Cells("M10_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M10_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 11 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M11").Visible = True
                    DGrid.Rows(Renglon).Cells("M11").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M11").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M11_").Visible = True
                        DGrid.Rows(Renglon).Cells("M11_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M11_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M11_").Visible = True
                            DGrid.Rows(Renglon).Cells("M11_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M11_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 12 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M12").Visible = True
                    DGrid.Rows(Renglon).Cells("M12").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M12").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M12_").Visible = True
                        DGrid.Rows(Renglon).Cells("M12_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M12_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M12_").Visible = True
                            DGrid.Rows(Renglon).Cells("M12_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M12_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If


            If Medida = 13 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M13").Visible = True
                    DGrid.Rows(Renglon).Cells("M13").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M13").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M13_").Visible = True
                        DGrid.Rows(Renglon).Cells("M13_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M13_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M14_").Visible = True
                            DGrid.Rows(Renglon).Cells("M14_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M14_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 14 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M14").Visible = True
                    DGrid.Rows(Renglon).Cells("M14").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M14").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M14_").Visible = True
                        DGrid.Rows(Renglon).Cells("M14_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M14_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M14_").Visible = True
                            DGrid.Rows(Renglon).Cells("M14_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M14_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 15 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M15").Visible = True
                    DGrid.Rows(Renglon).Cells("M15").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M15").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M15_").Visible = True
                        DGrid.Rows(Renglon).Cells("M15_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M15_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M15_").Visible = True
                            DGrid.Rows(Renglon).Cells("M15_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M15_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 16 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M16").Visible = True
                    DGrid.Rows(Renglon).Cells("M16").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M16").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M16_").Visible = True
                        DGrid.Rows(Renglon).Cells("M16_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M16_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M16_").Visible = True
                            DGrid.Rows(Renglon).Cells("M16_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M16_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 17 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M17").Visible = True
                    DGrid.Rows(Renglon).Cells("M17").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M17").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M17_").Visible = True
                        DGrid.Rows(Renglon).Cells("M17_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M17_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M17_").Visible = True
                            DGrid.Rows(Renglon).Cells("M17_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M17_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 18 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M18").Visible = True
                    DGrid.Rows(Renglon).Cells("M18").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M18").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M18_").Visible = True
                        DGrid.Rows(Renglon).Cells("M18_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M18_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M18_").Visible = True
                            DGrid.Rows(Renglon).Cells("M18_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M18_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 19 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M19").Visible = True
                    DGrid.Rows(Renglon).Cells("M19").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M19").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M19_").Visible = True
                        DGrid.Rows(Renglon).Cells("M19_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M19_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M19_").Visible = True
                            DGrid.Rows(Renglon).Cells("M19_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M19_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 20 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M20").Visible = True
                    DGrid.Rows(Renglon).Cells("M20").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M20").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M20_").Visible = True
                        DGrid.Rows(Renglon).Cells("M20_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M20_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M20_").Visible = True
                            DGrid.Rows(Renglon).Cells("M20_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M20_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 21 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M21").Visible = True
                    DGrid.Rows(Renglon).Cells("M21").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M21").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M21_").Visible = True
                        DGrid.Rows(Renglon).Cells("M21_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M21_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M21_").Visible = True
                            DGrid.Rows(Renglon).Cells("M21_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M21_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If


            If Medida = 22 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M22").Visible = True
                    DGrid.Rows(Renglon).Cells("M22").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M22").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M22_").Visible = True
                        DGrid.Rows(Renglon).Cells("M22_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M22_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M22_").Visible = True
                            DGrid.Rows(Renglon).Cells("M22_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M22_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If



            If Medida = 23 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M23").Visible = True
                    DGrid.Rows(Renglon).Cells("M23").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M23").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M23_").Visible = True
                        DGrid.Rows(Renglon).Cells("M23_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M23_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M23_").Visible = True
                            DGrid.Rows(Renglon).Cells("M23_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M23_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 24 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M24").Visible = True
                    DGrid.Rows(Renglon).Cells("M24").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M24").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M24_").Visible = True
                        DGrid.Rows(Renglon).Cells("M24_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M24_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M24_").Visible = True
                            DGrid.Rows(Renglon).Cells("M24_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M24_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If


            If Medida = 25 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M25").Visible = True
                    DGrid.Rows(Renglon).Cells("M25").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M25").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M25_").Visible = True
                        DGrid.Rows(Renglon).Cells("M25_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M25_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M25_").Visible = True
                            DGrid.Rows(Renglon).Cells("M25_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M25_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 26 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M26").Visible = True
                    DGrid.Rows(Renglon).Cells("M26").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M26").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M26_").Visible = True
                        DGrid.Rows(Renglon).Cells("M26_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M26_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M26_").Visible = True
                            DGrid.Rows(Renglon).Cells("M26_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M26_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 27 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M27").Visible = True
                    DGrid.Rows(Renglon).Cells("M27").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M27").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M27_").Visible = True
                        DGrid.Rows(Renglon).Cells("M27_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M27_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M27_").Visible = True
                            DGrid.Rows(Renglon).Cells("M27_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M27_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 28 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M28").Visible = True
                    DGrid.Rows(Renglon).Cells("M28").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M28").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M28_").Visible = True
                        DGrid.Rows(Renglon).Cells("M28_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M28_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M28_").Visible = True
                            DGrid.Rows(Renglon).Cells("M28_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M28_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If
            If Medida = 29 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M29").Visible = True
                    DGrid.Rows(Renglon).Cells("M29").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M29").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M29_").Visible = True
                        DGrid.Rows(Renglon).Cells("M29_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M29_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M29_").Visible = True
                            DGrid.Rows(Renglon).Cells("M29_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M29_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 30 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M30").Visible = True
                    DGrid.Rows(Renglon).Cells("M30").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M30").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M30_").Visible = True
                        DGrid.Rows(Renglon).Cells("M30_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M30_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M30_").Visible = True
                            DGrid.Rows(Renglon).Cells("M30_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M30_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 31 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M31").Visible = True
                    DGrid.Rows(Renglon).Cells("M31").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M31").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M31_").Visible = True
                        DGrid.Rows(Renglon).Cells("M31_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M31_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M31_").Visible = True
                            DGrid.Rows(Renglon).Cells("M31_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M31_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 32 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M32").Visible = True
                    DGrid.Rows(Renglon).Cells("M32").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M32").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M32_").Visible = True
                        DGrid.Rows(Renglon).Cells("M32_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M32_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M32_").Visible = True
                            DGrid.Rows(Renglon).Cells("M32_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M32_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 33 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M33").Visible = True
                    DGrid.Rows(Renglon).Cells("M33").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M33").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M33_").Visible = True
                        DGrid.Rows(Renglon).Cells("M33_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M33_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M33_").Visible = True
                            DGrid.Rows(Renglon).Cells("M33_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M33_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 34 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M34").Visible = True
                    DGrid.Rows(Renglon).Cells("M34").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M34").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M34_").Visible = True
                        DGrid.Rows(Renglon).Cells("M34_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M34_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M34_").Visible = True
                            DGrid.Rows(Renglon).Cells("M34_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M34_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If
            If Medida = 35 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M35").Visible = True
                    DGrid.Rows(Renglon).Cells("M35").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M35").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then
                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M35_").Visible = True
                        DGrid.Rows(Renglon).Cells("M35_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M35_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M35_").Visible = True
                            DGrid.Rows(Renglon).Cells("M35_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M35_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 36 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M36").Visible = True
                    DGrid.Rows(Renglon).Cells("M36").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M36").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M36_").Visible = True
                        DGrid.Rows(Renglon).Cells("M36_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M36_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M36_").Visible = True
                            DGrid.Rows(Renglon).Cells("M36_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M36_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 37 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M37").Visible = True
                    DGrid.Rows(Renglon).Cells("M37").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M37").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M37_").Visible = True
                        DGrid.Rows(Renglon).Cells("M37_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M37_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M37_").Visible = True
                            DGrid.Rows(Renglon).Cells("M37_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M37_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If
            If Medida = 38 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M38").Visible = True
                    DGrid.Rows(Renglon).Cells("M38").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M38").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M38_").Visible = True
                        DGrid.Rows(Renglon).Cells("M38_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M38_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M38_").Visible = True
                            DGrid.Rows(Renglon).Cells("M38_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M38_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 39 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M39").Visible = True
                    DGrid.Rows(Renglon).Cells("M39").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M39").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M39_").Visible = True
                        DGrid.Rows(Renglon).Cells("M39_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M39_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M39_").Visible = True
                            DGrid.Rows(Renglon).Cells("M39_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M39_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 40 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M40").Visible = True
                    DGrid.Rows(Renglon).Cells("M40").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M40").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M40_").Visible = True
                        DGrid.Rows(Renglon).Cells("M40_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M40_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M40_").Visible = True
                            DGrid.Rows(Renglon).Cells("M40_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M40_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 41 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M41").Visible = True
                    DGrid.Rows(Renglon).Cells("M41").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M41").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M41_").Visible = True
                        DGrid.Rows(Renglon).Cells("M41_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M41_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M41_").Visible = True
                            DGrid.Rows(Renglon).Cells("M41_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M41_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 42 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M42").Visible = True
                    DGrid.Rows(Renglon).Cells("M42").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M42").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M42_").Visible = True
                        DGrid.Rows(Renglon).Cells("M42_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M42_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M42_").Visible = True
                            DGrid.Rows(Renglon).Cells("M42_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M42_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If
            If Medida = 43 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M43").Visible = True
                    DGrid.Rows(Renglon).Cells("M43").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M43").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M43_").Visible = True
                        DGrid.Rows(Renglon).Cells("M43_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M43_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M43_").Visible = True
                            DGrid.Rows(Renglon).Cells("M43_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M43_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 44 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M44").Visible = True
                    DGrid.Rows(Renglon).Cells("M44").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M44").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M44_").Visible = True
                        DGrid.Rows(Renglon).Cells("M44_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M44_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M44_").Visible = True
                            DGrid.Rows(Renglon).Cells("M44_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M44_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If
            If Medida = 45 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M45").Visible = True
                    DGrid.Rows(Renglon).Cells("M45").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M45").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M45_").Visible = True
                        DGrid.Rows(Renglon).Cells("M45_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M45_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M45_").Visible = True
                            DGrid.Rows(Renglon).Cells("M45_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M45_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 46 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M46").Visible = True
                    DGrid.Rows(Renglon).Cells("M46").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M46").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M46_").Visible = True
                        DGrid.Rows(Renglon).Cells("M46_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M46_").Value = Cantidad
                        End If
                    Else
                        If EmpNeg = 0 Then
                            If IntervaloAnterior = "-" Then
                                DGrid.Columns("M46_").Visible = True
                                DGrid.Rows(Renglon).Cells("M46_").Style.BackColor = Color.Yellow
                                If Accion <> 1 Then
                                    DGrid.Rows(Renglon).Cells("M46_").Value = Cantidad
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 47 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M47").Visible = True
                    DGrid.Rows(Renglon).Cells("M47").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M47").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M47_").Visible = True
                        DGrid.Rows(Renglon).Cells("M47_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M47_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M47_").Visible = True
                            DGrid.Rows(Renglon).Cells("M47_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M47_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 48 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M48").Visible = True
                    DGrid.Rows(Renglon).Cells("M48").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M48").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M48_").Visible = True
                        DGrid.Rows(Renglon).Cells("M48_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M48_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M48_").Visible = True
                            DGrid.Rows(Renglon).Cells("M48_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M48_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 49 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M49").Visible = True
                    DGrid.Rows(Renglon).Cells("M49").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M49").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M49_").Visible = True
                        DGrid.Rows(Renglon).Cells("M49_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M49_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M49_").Visible = True
                            DGrid.Rows(Renglon).Cells("M49_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M49_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If

            If Medida = 50 Then
                If EmpNeg = 0 Then
                    DGrid.Columns("M50").Visible = True
                    DGrid.Rows(Renglon).Cells("M50").Style.BackColor = Color.Yellow
                    If Accion <> 1 Then
                        DGrid.Rows(Renglon).Cells("M50").Value = Cantidad
                    End If
                End If
                If (FinNeg = 0 And Mid(Medida, 1, 2) <> MedUltNeg) Or Medida & "-" = MedIniNeg Then

                    If IntervaloAnterior = "-" Then
                        DGrid.Columns("M50_").Visible = True
                        DGrid.Rows(Renglon).Cells("M50_").Style.BackColor = Color.Yellow
                        If Accion <> 1 Then
                            DGrid.Rows(Renglon).Cells("M50_").Value = Cantidad
                        End If
                    End If
                Else
                    If EmpNeg = 0 Then
                        If IntervaloAnterior = "-" Then
                            DGrid.Columns("M50_").Visible = True
                            DGrid.Rows(Renglon).Cells("M50_").Style.BackColor = Color.Yellow
                            If Accion <> 1 Then
                                DGrid.Rows(Renglon).Cells("M50_").Value = Cantidad
                            End If
                        End If
                    End If
                End If
            End If


        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub RellenarColumnasCorridaEdicion(ByVal Renglon As Integer, ByVal Medida As String, Optional ByVal Cantidad As Integer = 0)
        'mreyes 18/Febrero/2012 11:49 a.mm.
        Try

            If pub_RellenarIzquierda(Medida, 2) = "01" Then
                DGrid.Columns("M1").Visible = True
                DGrid.Rows(Renglon).Cells("M1").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M1").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "02" Then
                DGrid.Columns("M2").Visible = True
                DGrid.Rows(Renglon).Cells("M2").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M2").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "03" Then
                DGrid.Columns("M3").Visible = True
                DGrid.Rows(Renglon).Cells("M3").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M3").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "04" Then
                DGrid.Columns("M4").Visible = True
                DGrid.Rows(Renglon).Cells("M4").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M4").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "05" Then
                DGrid.Columns("M5").Visible = True
                DGrid.Rows(Renglon).Cells("M5").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M5").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "06" Then
                DGrid.Columns("M6").Visible = True
                DGrid.Rows(Renglon).Cells("M6").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M6").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "07" Then
                DGrid.Columns("M7").Visible = True
                DGrid.Rows(Renglon).Cells("M7").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M7").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "08" Then
                DGrid.Columns("M8").Visible = True
                DGrid.Rows(Renglon).Cells("M8").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M8").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 2) = "09" Then
                DGrid.Columns("M9").Visible = True
                DGrid.Rows(Renglon).Cells("M9").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M9").Value = Cantidad
            End If

            If pub_RellenarIzquierda(Medida, 3) = "09-" Then
                DGrid.Columns("M9_").Visible = True
                DGrid.Rows(Renglon).Cells("M9_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M9_").Value = Cantidad
            End If
            ''''
            If Medida = "10" Then
                DGrid.Columns("M10").Visible = True
                DGrid.Rows(Renglon).Cells("M10").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M10").Value = Cantidad
            End If

            If Medida = "10-" Then
                DGrid.Columns("M10_").Visible = True
                DGrid.Rows(Renglon).Cells("M10_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M10_").Value = Cantidad
            End If

            If Medida = "11" Then
                DGrid.Columns("M11").Visible = True
                DGrid.Rows(Renglon).Cells("M11").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M11").Value = Cantidad
            End If

            If Medida = "11-" Then
                DGrid.Columns("M11_").Visible = True
                DGrid.Rows(Renglon).Cells("M11_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M11_").Value = Cantidad
            End If

            If Medida = "12" Then
                DGrid.Columns("M12").Visible = True
                DGrid.Rows(Renglon).Cells("M12").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M12").Value = Cantidad
            End If

            If Medida = "12-" Then
                DGrid.Columns("M12_").Visible = True
                DGrid.Rows(Renglon).Cells("M12_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M12_").Value = Cantidad
            End If

            If Medida = "13" Then
                DGrid.Columns("M13").Visible = True
                DGrid.Rows(Renglon).Cells("M13").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M13").Value = Cantidad
            End If

            If Medida = "13-" Then
                DGrid.Columns("M13_").Visible = True
                DGrid.Rows(Renglon).Cells("M13_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M13_").Value = Cantidad
            End If

            If Medida = "14" Then
                DGrid.Columns("M14").Visible = True
                DGrid.Rows(Renglon).Cells("M14").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M14").Value = Cantidad
            End If

            If Medida = "14-" Then
                DGrid.Columns("M14_").Visible = True
                DGrid.Rows(Renglon).Cells("M14_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M14_").Value = Cantidad
            End If

            If Medida = "15" Then
                DGrid.Columns("M15").Visible = True
                DGrid.Rows(Renglon).Cells("M15").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M15").Value = Cantidad
            End If

            If Medida = "15-" Then
                DGrid.Columns("M15_").Visible = True
                DGrid.Rows(Renglon).Cells("M15_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M15_").Value = Cantidad
            End If

            If Medida = "16" Then
                DGrid.Columns("M16").Visible = True
                DGrid.Rows(Renglon).Cells("M16").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M16").Value = Cantidad
            End If

            If Medida = "16-" Then
                DGrid.Columns("M16_").Visible = True
                DGrid.Rows(Renglon).Cells("M16_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M16_").Value = Cantidad
            End If

            If Medida = "17" Then
                DGrid.Columns("M17").Visible = True
                DGrid.Rows(Renglon).Cells("M17").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M17").Value = Cantidad
            End If

            If Medida = "17-" Then
                DGrid.Columns("M17_").Visible = True
                DGrid.Rows(Renglon).Cells("M17_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M17_").Value = Cantidad
            End If

            If Medida = "18" Then
                DGrid.Columns("M18").Visible = True
                DGrid.Rows(Renglon).Cells("M18").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M18").Value = Cantidad
            End If

            If Medida = "18-" Then
                DGrid.Columns("M18_").Visible = True
                DGrid.Rows(Renglon).Cells("M18_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M18_").Value = Cantidad
            End If

            If Medida = "19" Then
                DGrid.Columns("M19").Visible = True
                DGrid.Rows(Renglon).Cells("M19").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M19").Value = Cantidad
            End If

            If Medida = "19-" Then
                DGrid.Columns("M19_").Visible = True
                DGrid.Rows(Renglon).Cells("M19_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M19_").Value = Cantidad
            End If

            If Medida = "20" Then
                DGrid.Columns("M20").Visible = True
                DGrid.Rows(Renglon).Cells("M20").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M20").Value = Cantidad
            End If

            If Medida = "20-" Then
                DGrid.Columns("M20_").Visible = True
                DGrid.Rows(Renglon).Cells("M20_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M20_").Value = Cantidad
            End If



            If Medida = "21" Then
                DGrid.Columns("M21").Visible = True
                DGrid.Rows(Renglon).Cells("M21").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M21").Value = Cantidad
            End If

            If Medida = "21-" Then
                DGrid.Columns("M21_").Visible = True
                DGrid.Rows(Renglon).Cells("M21_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M21_").Value = Cantidad
            End If

            If Medida = "22" Then
                DGrid.Columns("M22").Visible = True
                DGrid.Rows(Renglon).Cells("M22").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M22").Value = Cantidad
            End If

            If Medida = "22-" Then
                DGrid.Columns("M22_").Visible = True
                DGrid.Rows(Renglon).Cells("M22_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M22_").Value = Cantidad
            End If

            If Medida = "23" Then
                DGrid.Columns("M23").Visible = True
                DGrid.Rows(Renglon).Cells("M23").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M23").Value = Cantidad
            End If

            If Medida = "23-" Then
                DGrid.Columns("M23_").Visible = True
                DGrid.Rows(Renglon).Cells("M23_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M23_").Value = Cantidad
            End If

            If Medida = "24" Then
                DGrid.Columns("M24").Visible = True
                DGrid.Rows(Renglon).Cells("M24").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M24").Value = Cantidad
            End If

            If Medida = "24-" Then
                DGrid.Columns("M24_").Visible = True
                DGrid.Rows(Renglon).Cells("M24_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M24_").Value = Cantidad
            End If

            If Medida = "25" Then
                DGrid.Columns("M25").Visible = True
                DGrid.Rows(Renglon).Cells("M25").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M25").Value = Cantidad
            End If

            If Medida = "25-" Then
                DGrid.Columns("M25_").Visible = True
                DGrid.Rows(Renglon).Cells("M25_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M25_").Value = Cantidad
            End If

            If Medida = "26" Then
                DGrid.Columns("M26").Visible = True
                DGrid.Rows(Renglon).Cells("M26").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M26").Value = Cantidad
            End If

            If Medida = "26-" Then
                DGrid.Columns("M26_").Visible = True
                DGrid.Rows(Renglon).Cells("M26_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M26_").Value = Cantidad
            End If

            If Medida = "27" Then
                DGrid.Columns("M27").Visible = True
                DGrid.Rows(Renglon).Cells("M27").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M27").Value = Cantidad
            End If

            If Medida = "27-" Then
                DGrid.Columns("M27_").Visible = True
                DGrid.Rows(Renglon).Cells("M27_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M27_").Value = Cantidad
            End If

            If Medida = "28" Then
                DGrid.Columns("M28").Visible = True
                DGrid.Rows(Renglon).Cells("M28").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M28").Value = Cantidad
            End If

            If Medida = "28-" Then
                DGrid.Columns("M28_").Visible = True
                DGrid.Rows(Renglon).Cells("M28_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M28_").Value = Cantidad
            End If

            If Medida = "29" Then
                DGrid.Columns("M29").Visible = True
                DGrid.Rows(Renglon).Cells("M29").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M29").Value = Cantidad
            End If

            If Medida = "29-" Then
                DGrid.Columns("M29_").Visible = True
                DGrid.Rows(Renglon).Cells("M29_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M29_").Value = Cantidad
            End If

            If Medida = "30" Then
                DGrid.Columns("M30").Visible = True
                DGrid.Rows(Renglon).Cells("M30").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M30").Value = Cantidad
            End If

            If Medida = "30-" Then
                DGrid.Columns("M30_").Visible = True
                DGrid.Rows(Renglon).Cells("M30_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M30_").Value = Cantidad
            End If

            ' MAS DE 30

            If Medida = "31" Then
                DGrid.Columns("M31").Visible = True
                DGrid.Rows(Renglon).Cells("M31").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M31").Value = Cantidad
            End If

            If Medida = "31-" Then
                DGrid.Columns("M31_").Visible = True
                DGrid.Rows(Renglon).Cells("M31_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M31_").Value = Cantidad
            End If

            If Medida = "32" Then
                DGrid.Columns("M32").Visible = True
                DGrid.Rows(Renglon).Cells("M32").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M32").Value = Cantidad
            End If

            If Medida = "32-" Then
                DGrid.Columns("M32_").Visible = True
                DGrid.Rows(Renglon).Cells("M32_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M32_").Value = Cantidad
            End If

            If Medida = "33" Then
                DGrid.Columns("M33").Visible = True
                DGrid.Rows(Renglon).Cells("M33").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M33").Value = Cantidad
            End If

            If Medida = "33-" Then
                DGrid.Columns("M33_").Visible = True
                DGrid.Rows(Renglon).Cells("M33_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M33_").Value = Cantidad
            End If

            If Medida = "34" Then
                DGrid.Columns("M34").Visible = True
                DGrid.Rows(Renglon).Cells("M34").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M34").Value = Cantidad
            End If

            If Medida = "34-" Then
                DGrid.Columns("M34_").Visible = True
                DGrid.Rows(Renglon).Cells("M34_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M34_").Value = Cantidad
            End If

            If Medida = "35" Then
                DGrid.Columns("M35").Visible = True
                DGrid.Rows(Renglon).Cells("M35").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M35").Value = Cantidad
            End If

            If Medida = "35-" Then
                DGrid.Columns("M35_").Visible = True
                DGrid.Rows(Renglon).Cells("M35_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M35_").Value = Cantidad
            End If

            If Medida = "36" Then
                DGrid.Columns("M36").Visible = True
                DGrid.Rows(Renglon).Cells("M36").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M36").Value = Cantidad
            End If

            If Medida = "36-" Then
                DGrid.Columns("M36_").Visible = True
                DGrid.Rows(Renglon).Cells("M36_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M36_").Value = Cantidad
            End If

            If Medida = "37" Then
                DGrid.Columns("M37").Visible = True
                DGrid.Rows(Renglon).Cells("M37").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M37").Value = Cantidad
            End If

            If Medida = "37-" Then
                DGrid.Columns("M37_").Visible = True
                DGrid.Rows(Renglon).Cells("M37_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M37_").Value = Cantidad
            End If

            If Medida = "38" Then
                DGrid.Columns("M38").Visible = True
                DGrid.Rows(Renglon).Cells("M38").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M38").Value = Cantidad
            End If

            If Medida = "38-" Then
                DGrid.Columns("M38_").Visible = True
                DGrid.Rows(Renglon).Cells("M38_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M38_").Value = Cantidad
            End If

            If Medida = "39" Then
                DGrid.Columns("M39").Visible = True
                DGrid.Rows(Renglon).Cells("M39").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M39").Value = Cantidad
            End If

            If Medida = "39-" Then
                DGrid.Columns("M39_").Visible = True
                DGrid.Rows(Renglon).Cells("M39_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M39_").Value = Cantidad
            End If

            If Medida = "40" Then
                DGrid.Columns("M40").Visible = True
                DGrid.Rows(Renglon).Cells("M40").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M40").Value = Cantidad
            End If

            If Medida = "40-" Then
                DGrid.Columns("M40_").Visible = True
                DGrid.Rows(Renglon).Cells("M40_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M40_").Value = Cantidad
            End If


            If Medida = "41" Then
                DGrid.Columns("M41").Visible = True
                DGrid.Rows(Renglon).Cells("M41").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M41").Value = Cantidad
            End If

            If Medida = "41-" Then
                DGrid.Columns("M41_").Visible = True
                DGrid.Rows(Renglon).Cells("M41_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M41_").Value = Cantidad
            End If

            If Medida = "42" Then
                DGrid.Columns("M42").Visible = True
                DGrid.Rows(Renglon).Cells("M42").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M42").Value = Cantidad
            End If

            If Medida = "42-" Then
                DGrid.Columns("M42_").Visible = True
                DGrid.Rows(Renglon).Cells("M42_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M42_").Value = Cantidad
            End If

            If Medida = "43" Then
                DGrid.Columns("M43").Visible = True
                DGrid.Rows(Renglon).Cells("M43").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M43").Value = Cantidad
            End If

            If Medida = "43-" Then
                DGrid.Columns("M43_").Visible = True
                DGrid.Rows(Renglon).Cells("M43_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M43_").Value = Cantidad
            End If

            If Medida = "44" Then
                DGrid.Columns("M44").Visible = True
                DGrid.Rows(Renglon).Cells("M44").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M44").Value = Cantidad
            End If

            If Medida = "44-" Then
                DGrid.Columns("M44_").Visible = True
                DGrid.Rows(Renglon).Cells("M44_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M44_").Value = Cantidad
            End If

            If Medida = "45" Then
                DGrid.Columns("M45").Visible = True
                DGrid.Rows(Renglon).Cells("M45").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M45").Value = Cantidad
            End If

            If Medida = "45-" Then
                DGrid.Columns("M45_").Visible = True
                DGrid.Rows(Renglon).Cells("M45_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M45_").Value = Cantidad
            End If

            If Medida = "46" Then
                DGrid.Columns("M46").Visible = True
                DGrid.Rows(Renglon).Cells("M46").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M46").Value = Cantidad
            End If

            If Medida = "46-" Then
                DGrid.Columns("M46_").Visible = True
                DGrid.Rows(Renglon).Cells("M46_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M46_").Value = Cantidad
            End If

            If Medida = "47" Then
                DGrid.Columns("M47").Visible = True
                DGrid.Rows(Renglon).Cells("M47").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M47").Value = Cantidad
            End If

            If Medida = "47-" Then
                DGrid.Columns("M47_").Visible = True
                DGrid.Rows(Renglon).Cells("M47_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M47_").Value = Cantidad
            End If

            If Medida = "48" Then
                DGrid.Columns("M48").Visible = True
                DGrid.Rows(Renglon).Cells("M48").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M48").Value = Cantidad
            End If

            If Medida = "48-" Then
                DGrid.Columns("M48_").Visible = True
                DGrid.Rows(Renglon).Cells("M48_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M48_").Value = Cantidad
            End If

            If Medida = "49" Then
                DGrid.Columns("M49").Visible = True
                DGrid.Rows(Renglon).Cells("M49").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M49").Value = Cantidad
            End If

            If Medida = "49-" Then
                DGrid.Columns("M49_").Visible = True
                DGrid.Rows(Renglon).Cells("M49_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M49_").Value = Cantidad
            End If

            If Medida = "50" Then
                DGrid.Columns("M50").Visible = True
                DGrid.Rows(Renglon).Cells("M50").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M50").Value = Cantidad
            End If

            If Medida = "50-" Then
                DGrid.Columns("M50_").Visible = True
                DGrid.Rows(Renglon).Cells("M50_").Style.BackColor = Color.Yellow
                DGrid.Rows(Renglon).Cells("M50_").Value = Cantidad
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Function GenerarDSPedidoNuevoMas14(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Sw_Blanco As Boolean) As DtPedidoNuevo
        'mreyes 20/Febrero/2012 10:57 a.m.
        Try
            '' Dim objDataSet As New DtPedidoNuevo
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0
            Dim Cont1 As Integer = 0
            Dim Sw_Mas14 As Boolean = True
            Dim Sw_18 As Boolean = False
            Dim PrimerRegistro As String = ""
            Dim Sw_MediosPrimero As Boolean = False
            Dim PrimerColumna As Integer = 0
            Dim Sw_Medios As Boolean = False
            Dim Sw_YaEntroMedios As Boolean = False

            GenerarDSPedidoNuevoMas14 = New DtPedidoNuevo

            Dim ColumnDe As String = ""
            Dim ColumnAA As String = ""
            Dim ColumnI As String = ""

            With DGrid
                '' ir a buscar si el renglón tiene mas de 14 en medida... 
                Cont = 0

                For I As Integer = 0 To .RowCount - 2

                    '  If .Rows(I).Cells(C).Visible = True And DGrid.Rows(I).Cells(C).Style.BackColor = Color.Yellow Then
                    If .Rows(I).Cells("de").Value <> ColumnDe Or .Rows(I).Cells("a").Value <> ColumnAA Or .Rows(I).Cells("i").Value <> ColumnI Then
                        Dim objDataRow1 As Data.DataRow = GenerarDSPedidoNuevoMas14.Tables("Tlb_Encabezado").NewRow
                        ColumnDe = .Rows(I).Cells("De").Value
                        ColumnAA = .Rows(I).Cells("a").Value
                        ColumnI = .Rows(I).Cells("i").Value
                        Cont = Cont + 1

                        '  objDataRow1.Item("idfolio") = Txt_NoBulto.Text
                        objDataRow1.Item("Sucursal") = Sucursal
                        objDataRow1.Item("ordecomp") = Cont
                        'objDataRow1.Item("tipoart") = "TA"
                        'objDataRow1.Item("familia") = "Fam"
                        'objDataRow1.Item("linea") = "Lin"
                        'objDataRow1.Item("categoria") = "Cat"
                        objDataRow1.Item("estilof") = "Estilo Fábrica"
                        objDataRow1.Item("estilon") = "Est."
                        objDataRow1.Item("descripc") = "Descripción"
                        objDataRow1.Item("c") = .Rows(I).Cells(13).Value
                        objDataRow1.Item("i") = .Rows(I).Cells(14).Value
                        objDataRow1.Item("De") = .Rows(I).Cells(15).Value
                        objDataRow1.Item("a") = .Rows(I).Cells(16).Value

                        If Sw_Factura = True Then
                            objDataRow1.Item("pcomp") = "Costo"  ' pedido nuevo proveedor.
                            objDataRow1.Item("costo") = "P.Lista"
                        Else

                            objDataRow1.Item("pcomp") = "P.Lista"  ' pedido nuevo proveedor.
                            objDataRow1.Item("costo") = "Costo"
                        End If
                        objDataRow1.Item("precio") = "Precio"
                        objDataRow1.Item("porc") = "%"
                        objDataRow1.Item("prs") = "Pares"

                        objDataRow1.Item("importe") = ""
                        objDataRow1.Item("fechaentrega") = "FEntrega"
                        objDataRow1.Item("fechacancela") = "FCancela"
                        objDataRow1.Item("cancelado") = "Canc"


                        Cont1 = 18
                        'For m As Integer = Val(.Rows(I).Cells(15).Value) To Val(.Rows(I).Cells(16).Value)
                        '    objDataRow1.Item(Cont1) = m
                        '    If .Rows(I).Cells(14).Value = "-" Then
                        '        Cont1 = Cont1 + 1
                        '        objDataRow1.Item(Cont1) = "*"
                        '    End If
                        '    Cont1 = Cont1 + 1
                        'Next
                        Dim Sw_Entro As Boolean = False
                        For m As Integer = Val(ColumnDe) To Val(ColumnAA)

                            If ColumnI = "-" Then
                                If InStr(ColumnDe, "-") > 0 And Sw_Entro = False Then
                                    ' el primer medida es medios 
                                    objDataRow1.Item(Cont1) = "*"
                                    'Cont1 = Cont1 + 1
                                    'objDataRow1.Item(Cont1) = m + 1
                                    Sw_Entro = True
                                Else
                                    If m = ColumnAA Then ' es el ultimo valor 
                                        If InStr(ColumnAA, "-") > 0 Then
                                            Cont1 = Cont1 + 1
                                            objDataRow1.Item(Cont1) = "*"
                                        Else
                                            objDataRow1.Item(Cont1) = m
                                            If .Rows(I).Cells("i").Value = "-" Then
                                                Cont1 = Cont1 + 1
                                                objDataRow1.Item(Cont1) = "*"

                                            End If
                                        End If
                                    Else
                                        objDataRow1.Item(Cont1) = m
                                        Cont1 = Cont1 + 1
                                        objDataRow1.Item(Cont1) = "*"

                                    End If



                                End If

                            Else

                                objDataRow1.Item(Cont1) = m
                                If Val(ColumnI) > 1 Then
                                    m = m + Val(ColumnI) - 1
                                End If
                            End If
                            Cont1 = Cont1 + 1

                        Next

                        GenerarDSPedidoNuevoMas14.Tables("Tlb_Encabezado").Rows.Add(objDataRow1)
                    End If
                    If Val(.Rows(I).Cells(23).Value) <> 0 Then
                        Dim objDataRow As Data.DataRow = GenerarDSPedidoNuevoMas14.Tables("Tlb_PedidoNuevo").NewRow
                        ' objDataRow.Item("idfolio") = Txt_NoBulto.Text
                        objDataRow.Item("Sucursal") = Sucursal
                        objDataRow.Item("ordecomp") = Cont
                        '  objDataRow.Item("tipoart") = .Rows(I).Cells(6).Value
                        '  objDataRow.Item("familia") = .Rows(I).Cells(7).Value
                        '  objDataRow.Item("linea") = .Rows(I).Cells(8).Value
                        '  objDataRow.Item("categoria") = .Rows(I).Cells(9).Value
                        objDataRow.Item("estilof") = .Rows(I).Cells(10).Value
                        objDataRow.Item("estilon") = .Rows(I).Cells(11).Value
                        objDataRow.Item("descripc") = .Rows(I).Cells(12).Value
                        objDataRow.Item("c") = .Rows(I).Cells(13).Value
                        objDataRow.Item("i") = .Rows(I).Cells(14).Value
                        objDataRow.Item("de") = .Rows(I).Cells(15).Value
                        objDataRow.Item("a") = .Rows(I).Cells(16).Value
                        objDataRow.Item("pcomp") = (.Rows(I).Cells(17).Value)
                        objDataRow.Item("costo") = (.Rows(I).Cells(18).Value)
                        objDataRow.Item("precio") = (.Rows(I).Cells(19).Value)
                        objDataRow.Item("porc") = .Rows(I).Cells(20).Value
                        objDataRow.Item("prs") = .Rows(I).Cells(23).Value
                        If Sw_Serie = True Then
                            objDataRow.Item("serie") = .Rows(I).Cells("serie").Value
                        End If

                        Cont1 = 18

                        'For K As Integer = 18 To 31
                        Cont1 = 18
                        For J As Integer = Columna To 123
                            If Sw_Mas14 = False Then
                                If .Rows(I).Cells(J).Visible = True Then
                                    objDataRow.Item(Cont1) = (.Rows(I).Cells(J).Value)
                                    Cont1 = Cont1 + 1

                                End If
                            Else
                                If Sw_18 = False Then
                                    If .Rows(I).Cells(J).Visible = True And DGrid.Rows(I).Cells(J).Style.BackColor = Color.Yellow Then
                                        objDataRow.Item(Cont1) = (.Rows(I).Cells(J).Value)
                                        Cont1 = Cont1 + 1

                                    End If
                                Else
                                    'Sw_18 = False
                                    If .Rows(I).Cells(J).Visible And DGrid.Rows(I).Cells(J).Style.BackColor = Color.Yellow = True And Cont1 = 18 Then
                                        objDataRow.Item(Cont1) = "0"
                                        objDataRow.Item(Cont1 + 1) = (.Rows(I).Cells(J).Value)
                                        Cont1 = Cont1 + 2
                                        Sw_18 = False
                                    End If
                                End If
                            End If
                        Next  '' DE I
                        ' Next  '' DE J
                        objDataRow.Item("importe") = (.Rows(I).Cells("importe").Value)
                        objDataRow.Item("fechaentrega") = Format(.Rows(I).Cells("FechaEntrega").Value, "Short Date")
                        objDataRow.Item("fechacancela") = Format(.Rows(I).Cells("FechaCancela").Value, "Short Date")
                        objDataRow.Item("cancelado") = IIf(.Rows(I).Cells("idusuariocancela").Value > 0, "SI", "NO")
                        GenerarDSPedidoNuevoMas14.Tables("Tlb_PedidoNuevo").Rows.Add(objDataRow)

                    End If
                    If Sw_Blanco = True And Val(.Rows(I).Cells(23).Value) <> 0 Then


                        Dim objDataRowB As Data.DataRow = GenerarDSPedidoNuevoMas14.Tables("Tlb_PedidoNuevo").NewRow
                        objDataRowB.Item("Sucursal") = Sucursal
                        objDataRowB.Item("ordecomp") = Cont
                        'objDataRowB.Item("tipoart") = .Rows(I).Cells(6).Value
                        'objDataRowB.Item("familia") = .Rows(I).Cells(7).Value
                        'objDataRowB.Item("linea") = .Rows(I).Cells(8).Value
                        'objDataRowB.Item("categoria") = .Rows(I).Cells(9).Value
                        objDataRowB.Item("estilof") = .Rows(I).Cells(10).Value
                        objDataRowB.Item("estilon") = .Rows(I).Cells(11).Value
                        objDataRowB.Item("descripc") = .Rows(I).Cells(12).Value
                        objDataRowB.Item("c") = .Rows(I).Cells(13).Value
                        objDataRowB.Item("i") = .Rows(I).Cells(14).Value
                        objDataRowB.Item("de") = .Rows(I).Cells(15).Value
                        objDataRowB.Item("a") = .Rows(I).Cells(16).Value
                        objDataRowB.Item("pcomp") = (.Rows(I).Cells(17).Value)
                        objDataRowB.Item("costo") = (.Rows(I).Cells(18).Value)
                        objDataRowB.Item("precio") = (.Rows(I).Cells(19).Value)
                        objDataRowB.Item("porc") = .Rows(I).Cells(20).Value
                        objDataRowB.Item("prs") = ""
                        objDataRowB.Item(18) = ""
                        objDataRowB.Item(19) = ""
                        objDataRowB.Item(20) = ""
                        objDataRowB.Item(21) = ""
                        objDataRowB.Item(22) = ""
                        objDataRowB.Item(23) = ""
                        objDataRowB.Item(24) = ""
                        objDataRowB.Item(25) = ""
                        objDataRowB.Item(26) = ""
                        objDataRowB.Item(27) = ""
                        objDataRowB.Item(28) = ""
                        objDataRowB.Item(29) = ""
                        objDataRowB.Item(30) = ""
                        objDataRowB.Item(31) = ""
                        objDataRowB.Item("cancelado") = IIf(.Rows(I).Cells("idusuariocancela").Value > 0, "SI", "NO")
                        objDataRowB.Item("importe") = ""
                        objDataRowB.Item("fechaentrega") = ""
                        objDataRowB.Item("fechacancela") = ""
                        GenerarDSPedidoNuevoMas14.Tables("Tlb_PedidoNuevo").Rows.Add(objDataRowB)

                        Cont1 = 18


                    End If
                    'If Val(GenerarDSPedidoNuevoMas14.Tables("Tbl_PedidoNuevo").Rows.Count) <= 0 Then
                    '    MsgBox("No se pudo generar el archivo de pedido *.PDF, Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                    '    Sw_NoArchivo = False
                    'End If
                Next
            End With

            If DGrid.RowCount - 2 < 0 Then
                'MsgBox("No se pudo generar el archivo de pedido *.PDF, Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                Sw_NoArchivo = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function





    Private Function GenerarDSDevolucionSerie(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Sw_Blanco As Boolean) As DtPedidoNuevo
        'mreyes 11/Oct/2013 04:19 p.m.
        Try
            '' Dim objDataSet As New DtPedidoNuevo
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0
            Dim Cont1 As Integer = 0
            Dim Sw_Mas14 As Boolean = True
            Dim Sw_18 As Boolean = False
            Dim PrimerRegistro As String = ""
            Dim Sw_MediosPrimero As Boolean = False
            Dim PrimerColumna As Integer = 0
            Dim Sw_Medios As Boolean = False
            Dim Sw_YaEntroMedios As Boolean = False

            GenerarDSDevolucionSerie = New DtPedidoNuevo

            Dim ColumnDe As String = ""
            Dim ColumnAA As String = ""
            Dim ColumnI As String = ""

            With DGrid
                '' ir a buscar si el renglón tiene mas de 14 en medida... 
                Cont = 0

                For I As Integer = 0 To .RowCount - 2

                    '  If .Rows(I).Cells(C).Visible = True And DGrid.Rows(I).Cells(C).Style.BackColor = Color.Yellow Then
                    If .Rows(I).Cells("de").Value <> ColumnDe Or .Rows(I).Cells("a").Value <> ColumnAA Or .Rows(I).Cells("i").Value <> ColumnI Then
                        Dim objDataRow1 As Data.DataRow = GenerarDSDevolucionSerie.Tables("Tlb_Encabezado").NewRow
                        ColumnDe = .Rows(I).Cells("De").Value
                        ColumnAA = .Rows(I).Cells("a").Value
                        ColumnI = .Rows(I).Cells("i").Value
                        Cont = Cont + 1

                        '  objDataRow1.Item("idfolio") = Txt_NoBulto.Text
                        objDataRow1.Item("Sucursal") = Sucursal
                        objDataRow1.Item("ordecomp") = Cont
                        'objDataRow1.Item("tipoart") = "TA"
                        'objDataRow1.Item("familia") = "Fam"
                        'objDataRow1.Item("linea") = "Lin"
                        'objDataRow1.Item("categoria") = "Cat"
                        objDataRow1.Item("estilof") = "Estilo Fábrica"
                        objDataRow1.Item("estilon") = "Est."
                        objDataRow1.Item("descripc") = "Descripción"
                        objDataRow1.Item("c") = .Rows(I).Cells(13).Value
                        objDataRow1.Item("i") = .Rows(I).Cells(14).Value
                        objDataRow1.Item("De") = "Medida"
                        objDataRow1.Item("a") = .Rows(I).Cells(16).Value

                        If Sw_Factura = True Then
                            objDataRow1.Item("pcomp") = "Costo"  ' pedido nuevo proveedor.
                            objDataRow1.Item("costo") = "P.Lista"
                        Else

                            objDataRow1.Item("pcomp") = "P.Lista"  ' pedido nuevo proveedor.
                            objDataRow1.Item("costo") = "Costo"
                        End If
                        objDataRow1.Item("precio") = "Precio"
                        objDataRow1.Item("porc") = "%"
                        objDataRow1.Item("prs") = "Pares"

                        objDataRow1.Item("importe") = ""
                        objDataRow1.Item("fechaentrega") = "FEntrega"
                        objDataRow1.Item("fechacancela") = "FCancela"
                        objDataRow1.Item("cancelado") = "SI"
                        GenerarDSDevolucionSerie.Tables("Tlb_Encabezado").Rows.Add(objDataRow1)
                    End If


                    If .Rows(I).Cells(23).Value <> 0 Then
                        Dim objDataRow As Data.DataRow = GenerarDSDevolucionSerie.Tables("Tlb_PedidoNuevo").NewRow
                        ' objDataRow.Item("idfolio") = Txt_NoBulto.Text
                        objDataRow.Item("Sucursal") = Sucursal
                        objDataRow.Item("ordecomp") = Cont

                        objDataRow.Item("estilof") = .Rows(I).Cells(10).Value
                        objDataRow.Item("estilon") = .Rows(I).Cells(11).Value
                        objDataRow.Item("descripc") = .Rows(I).Cells(12).Value
                        objDataRow.Item("c") = .Rows(I).Cells(13).Value
                        objDataRow.Item("i") = .Rows(I).Cells(14).Value
                        objDataRow.Item("de") = .Rows(I).Cells(15).Value
                        objDataRow.Item("a") = .Rows(I).Cells(16).Value
                        objDataRow.Item("pcomp") = (.Rows(I).Cells(17).Value)
                        objDataRow.Item("costo") = (.Rows(I).Cells(18).Value)
                        objDataRow.Item("precio") = (.Rows(I).Cells(19).Value)
                        objDataRow.Item("porc") = .Rows(I).Cells(20).Value
                        objDataRow.Item("prs") = .Rows(I).Cells(23).Value
                        If Sw_Serie = True Then
                            objDataRow.Item("serie") = .Rows(I).Cells("serie").Value
                        End If



                        ' Next  '' DE J
                        objDataRow.Item("importe") = (.Rows(I).Cells("importe").Value)
                        objDataRow.Item("fechaentrega") = Format(.Rows(I).Cells("FechaEntrega").Value, "Short Date")
                        objDataRow.Item("fechacancela") = Format(.Rows(I).Cells("FechaCancela").Value, "Short Date")
                        objDataRow.Item("cancelado") = "NO"
                        GenerarDSDevolucionSerie.Tables("Tlb_PedidoNuevo").Rows.Add(objDataRow)

                    End If

                Next
            End With

            If DGrid.RowCount - 2 < 0 Then
                'MsgBox("No se pudo generar el archivo de pedido *.PDF, Intente nuevamente mas tarde.", MsgBoxStyle.Critical, "Aviso")
                Sw_NoArchivo = False
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Private Function GenerarDSPedidoNuevo(ByVal Sucursal As String, ByVal OrdeComp As String) As DtPedidoNuevo
        'mreyes 20/Febrero/2012 10:57 a.m.
        Try
            '' Dim objDataSet As New DtPedidoNuevo
            Dim Columna As Integer = 0
            Dim Cont As Integer = 0
            GenerarDSPedidoNuevo = New DtPedidoNuevo

            With DGrid

                For I As Integer = 0 To .RowCount - 2
                    Dim objDataRow As Data.DataRow = GenerarDSPedidoNuevo.Tables(0).NewRow
                    objDataRow.Item("Sucursal") = Sucursal
                    objDataRow.Item("ordecomp") = OrdeComp
                    ' objDataRow.Item("tipoart") = .Rows(I).Cells(6).Value
                    ' objDataRow.Item("familia") = .Rows(I).Cells(7).Value
                    ' objDataRow.Item("linea") = .Rows(I).Cells(8).Value
                    ' objDataRow.Item("categoria") = .Rows(I).Cells(9).Value
                    objDataRow.Item("estilof") = .Rows(I).Cells(10).Value
                    objDataRow.Item("estilon") = .Rows(I).Cells(11).Value
                    objDataRow.Item("descripc") = .Rows(I).Cells(12).Value
                    objDataRow.Item("c") = .Rows(I).Cells(13).Value
                    objDataRow.Item("i") = .Rows(I).Cells(14).Value
                    objDataRow.Item("de") = .Rows(I).Cells(15).Value
                    objDataRow.Item("a") = .Rows(I).Cells(16).Value
                    objDataRow.Item("pcomp") = (.Rows(I).Cells(17).Value)
                    objDataRow.Item("costo") = (.Rows(I).Cells(18).Value)
                    objDataRow.Item("precio") = (.Rows(I).Cells(19).Value)
                    objDataRow.Item("porc") = .Rows(I).Cells(20).Value
                    objDataRow.Item("prs") = .Rows(I).Cells(23).Value
                    If Columna = 0 Then

                        For C As Integer = 24 To 123
                            If .Rows(I).Cells(C).Visible = True Then
                                If Columna = 0 Then
                                    Columna = C
                                End If
                                TextoColumna(Cont) = DGrid.Columns(C).HeaderText
                                Cont = Cont + 1
                                ' checar el exit for del if en contador 14 para corridas
                                If Cont = 14 Then Exit For
                            End If
                        Next
                    End If
                    'objDataRow.Item("m1") = .Rows(I).Cells(Columna).Value
                    Cont = 18

                    For K As Integer = 18 To 31
                        Cont = 18
                        For J As Integer = Columna To 123
                            If .Rows(I).Cells(J).Visible = True Then
                                objDataRow.Item(Cont) = (.Rows(I).Cells(J).Value)
                                Cont = Cont + 1
                            End If
                        Next  '' DE I
                    Next  '' DE J
                    objDataRow.Item("importe") = (.Rows(I).Cells("importe").Value)
                    objDataRow.Item("fechaentrega") = Format(.Rows(I).Cells("FechaEntrega").Value, "Short Date")
                    objDataRow.Item("fechacancela") = Format(.Rows(I).Cells("FechaCancela").Value, "Short Date")


                    GenerarDSPedidoNuevo.Tables(0).Rows.Add(objDataRow)

                Next
            End With
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function
    Private Sub ImprimirPedidoNuevo(ByVal Sucursal As String, ByVal OrdeComp As String, ByVal Opcion As Integer)
        'mreyes 20/Febrero/2012 11:07 a.m.


        Try
            Dim myForm As New frmReportsBrowser
            Dim Sw_Mas14 As Boolean = False
            Dim Cont As Integer = 0

            If Sw_ImprimeMas14 = False Then
                For C As Integer = 24 To 123
                    If DGrid.Rows(0).Cells(C).Visible = True Then '' And DGrid.Rows(0).Cells(C).Style.BackColor = Color.Yellow Then
                        Cont = Cont + 1
                    End If
                    If Cont > 14 Then
                        Sw_Mas14 = True
                        Exit For
                    End If

                Next
            Else
                Sw_Mas14 = True
            End If
            Dim Sw_Imprimir As Boolean = False

            If Chk_VerPendientexRecibir.Checked = True Then
                Sw_Imprimir = True
            Else
                Sw_Imprimir = False
            End If

            If Sw_Mas14 = False Then
                myForm.objDataSetPedidoNuevo = GenerarDSPedidoNuevoMas14(Sucursal, OrdeComp, Sw_Imprimir)
            Else
                myForm.objDataSetPedidoNuevo = GenerarDSPedidoNuevoMas14(Sucursal, OrdeComp, Sw_Imprimir)
            End If
            myForm.TextoColumna(0) = TextoColumna(0)
            myForm.TextoColumna(1) = TextoColumna(1)
            myForm.TextoColumna(2) = TextoColumna(2)
            myForm.TextoColumna(3) = TextoColumna(3)
            myForm.TextoColumna(4) = TextoColumna(4)
            myForm.TextoColumna(5) = TextoColumna(5)
            myForm.TextoColumna(6) = TextoColumna(6)
            myForm.TextoColumna(7) = TextoColumna(7)
            myForm.TextoColumna(8) = TextoColumna(8)
            myForm.TextoColumna(9) = TextoColumna(9)
            myForm.TextoColumna(10) = TextoColumna(10)
            myForm.TextoColumna(11) = TextoColumna(11)
            myForm.TextoColumna(12) = TextoColumna(12)
            myForm.TextoColumna(13) = TextoColumna(13)
            myForm.TextoColumna(14) = TextoColumna(14)
            myForm.Marca = Txt_Marca.Text
            'Validación por mientras para parar el pdf.

            myForm.Raz_Social = Txt_Raz_Soc.Text.Replace("'", " ")
            myForm.Vendedor = Txt_Vendedor.Text
            myForm.Transporte = Txt_Transporte.Text
            myForm.Dsctopp = Txt_Dsctopp.Text
            myForm.Plazopp = Txt_Diaspp.Text
            myForm.FechaPedido = Txt_Fecha.Text
            myForm.Observaciones = Txt_Observa.Text
            '' calcular por orden de compra 
            myForm.prs = Txt_Pares.Text
            myForm.Subt = Txt_Subtotal.Text
            myForm.TIva = Txt_TotalIVA.Text
            myForm.Iva = Txt_Iva.Text
            myForm.TDscto = Txt_TotalDescto.Text
            myForm.Total = Txt_Total.Text
            ' termina calcular por orden de compra 
            myForm.OrdeComp = Sucursal & "-" & OrdeComp
            If Sw_Factura Or Sw_FacturaNueva Then
                If Txt_FactProv.Text = "" Then
                    Txt_FactProv.Text = usp_TraerFolioEntrada(FolioB)
                End If
                myForm.FolioEntrada = Txt_FactProv.Text
                myForm.FolioFactura = Txt_Referenc.Text
                'If OrdeComp = "" Then myForm.FolioFactura = Txt_FactProv.Text Else myForm.FolioFactura = OrdeComp
                'myForm.FolioFactura = OrdeComp
                myForm.FechaFactura = Txt_FechaFactura.Text
            ElseIf Sw_Devolucion = True Then
                myForm.FolioEntrada = OrdeComp
                If Txt_FactProv.Text = "" Then
                    myForm.FolioFactura = usp_TraerFolioDevoProv(FolioB)

                Else
                    myForm.FolioFactura = Txt_FactProv.Text
                End If




                If Sw_Serie = True Then myForm.FolioFactura = Txt_Referenc.Text
                ' myForm.FechaFactura = Txt_FechaFactura.Text
            End If

            If Txt_FechaVence.Text = "" Then
                myForm.FechaVence = "1900-01-01"
            Else



                myForm.FechaVence = Txt_FechaVence.Text
            End If

            If Txt_BaseVence.Text = "" Then
                myForm.BaseVence = "1900-01-01"
            Else

                myForm.BaseVence = Txt_BaseVence.Text
            End If


            If Txt_Fecha.Text = "" Then
                myForm.FechaRecibo = "1900-01-01"
            Else
                myForm.FechaRecibo = Txt_Fecha.Text
            End If

            myForm.Dscto01 = Txt_Dscto01.Text
            myForm.Dscto02 = Txt_Dscto02.Text
            myForm.Dscto03 = Txt_Dscto03.Text
            myForm.Dscto04 = Txt_Dscto04.Text
            myForm.Dscto05 = Txt_Dscto05.Text
            'Traer no de bulto sino lo tengo
            If Sw_Remision = True Then
                myForm.r_Titulo = "Ficha de Entrada CONSIGNACIÓN"
            Else

                myForm.r_Titulo = "Ficha de Entrada FACTURA"
            End If

            myForm.Observa = Txt_Observa.Text

            If Txt_NoBulto.Text = "" And FolioB <> "" Then
                Txt_NoBulto.Text = usp_TraerIdFolioSucBulto(FolioB)
            End If

            myForm.IdFolioSuc = Txt_NoBulto.Text
            myForm.ReportIndex = Opcion   'CUANDO SE GENERA LA PRIMERA VEZ nosotros .. el 1 es el proveedor , EL 3 ES EL DE CEDI , 4 es factura


            If Opcion < 3 Then
                Dim Anio As String
                Dim Mes As String
                Dim NombrePedido As String = Txt_Marca.Text & "_" & Sucursal & OrdeComp & IIf(Opcion = 0, "_Completo.pdf", "_Prov.pdf")
                Dim Tipo As String = IIf(Opcion = 0, "Completo", "Proveedor")
                Using objIO As New BCL.BCLio(GLB_ConStringCipSis)


                    Anio = Format(CDate(Txt_Fecha.Text), "yyyy")
                    Mes = Format(CDate(Txt_Fecha.Text), "MMMM").ToUpper
                    If objIO.pub_CrearDirectorioMarca(GLB_RutaArchivoDigitalPedidos, ResurtSN, Txt_Marca.Text, Anio, Mes, Tipo) = False Then
                        MsgBox("No se pudo generar la carpeta '" & Txt_Marca.Text & "'", MsgBoxStyle.Critical, "Error")

                    End If
                End Using
                If Opcion = 1 Then '' proveedor 
                    RutaArchivoCorreo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Txt_Marca.Text & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
                End If
                If Val(Txt_Iva.Text) = 0 And Opcion = 1 Then

                    Opcion = 8457
                    myForm.ReportIndex = Opcion
                End If
                myForm.RutaGuardarPedidoNuevo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Txt_Marca.Text & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
                myForm.Sw_Bitacora = Sw_Bitacora

                If IntSelect > 1 Then
                    Sw_SoloPasoPDF = True
                End If
                If Sw_SoloPasoPDF = True Then
                    myForm.Sw_Bitacora = True
                End If

            End If
            myForm.Show()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub Btn_Pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Pdf.Click
        Try
            If Sw_Costos = True Then
                Dim Sw_Permiso As Boolean = True

                ' checar permiso
                If Sw_Factura = True Or Sw_FacturaNueva = True Then
                    Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, -1)
                Else

                    If GLB_Usuario <> "MREYES" And GLB_Usuario <> "FELIX" And GLB_Usuario <> "FELIXJ" And GLB_Usuario <> "RESM1979" And GLB_Usuario <> "LORIS" Then
                        If pub_TienePermisoProceso("PEDNUEVO", "02", "", True) = False Then Exit Sub

                        Sw_Permiso = False

                    End If



                    If Accion = 1 Then
                        DGrid.Sort(DGrid.Columns("C"), System.ComponentModel.ListSortDirection.Ascending)
                        DGrid.Sort(DGrid.Columns("I"), System.ComponentModel.ListSortDirection.Ascending)
                        'DGrid.Sort(DGrid.Columns("DE"), System.ComponentModel.ListSortDirection.Ascending)
                    End If


                    If Sw_Permiso = True Then
                        Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 0)
                    End If
                    Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 1)
                End If
            Else
                ' no vera costos y será el reporte de cedis.
                Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 3)
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Dsctopp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dsctopp.GotFocus
        Txt_Dsctopp.SelectAll()
    End Sub

    Private Sub Txt_Dsctopp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dsctopp.KeyPress
        'Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Dsctopp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dsctopp.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub

        If CDbl(Txt_Dsctopp.Text) > 0 Then

            For I As Integer = 0 To DGrid.RowCount - 2
                DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(DGrid.Rows(I).Cells("pcomp").Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
                DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(DGrid.Rows(I).Cells("precio").Value, DGrid.Rows(I).Cells("costo").Value), "#0.00")
                'If Accion <> 1 Then
                '    Call Totalizados(True, 0, 0, 1)
                'Else
                '    Call Totalizados(True, 0)

                'End If

                If Accion <> 1 Then
                    Call Totalizados(True, 0)
                Else
                    Call Totalizados(True, 0)

                End If

            Next
        End If
        If CDbl(Txt_Dsctopp.Text) = 0 Then
            If Sw_Factura = True Or Sw_FacturaNueva = True Then
                sw_cambioceros = True
            End If
            'Call Totalizados(True, 0, 0, 1)

            If CDbl(Txt_NotaCargo.Text) > 0 Then
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) + CDbl(Txt_Descuento.Text), "$#,##0.00")

            End If


            If CDbl(Txt_NotaCredito.Text) > 0 Then
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) + CDbl(Txt_Descuento.Text), "$#,##0.00")

            End If

            Txt_Descuento.Text = "$0.00"
            Txt_TotalDescto.Text = "$0.00"

        End If
    End Sub



    Private Sub Txt_Dscto01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto01.GotFocus
        Txt_Dscto01.SelectAll()
    End Sub

    Private Sub Txt_Dscto01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto01.KeyPress
        'Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Dscto01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto01.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub
        If Val(Txt_Dscto01.Text = 0) Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            If DGrid.Rows(I).Cells("costo").Value = "" Then Continue For
            DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(DGrid.Rows(I).Cells("pcomp").Value), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(Val(DGrid.Rows(I).Cells("precio").Value), DGrid.Rows(I).Cells("costo").Value), "#0.00")
            Call Totalizados(True, I)
        Next
    End Sub


    Private Sub Txt_Diaspp_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Diaspp.GotFocus
        Txt_Diaspp.SelectAll()
    End Sub

    Private Sub Txt_Diaspp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Diaspp.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Diaspp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Diaspp.LostFocus
        If Txt_FechaFactura.Text.Length > 0 And Txt_Diaspp.Text.Length > 0 Then
            Txt_FechaVence.Text = Format(pub_FechaVence(Txt_FechaFactura.Text, Txt_Diaspp.Text), "yyyy-MM-dd")

            If FechaEntregaMax <> "1900-01-01" Then
                If CDate(FechaEntregaMax) > CDate(Txt_Fecha.Text) Then
                    Txt_FechaVence.Text = Format(pub_FechaVence(FechaEntregaMax, Txt_Diaspp.Text), "yyyy-MM-dd")
                End If

            End If

        End If


    End Sub



    Private Sub Txt_Dscto02_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto02.GotFocus
        Txt_Dscto01.SelectAll()
    End Sub

    Private Sub Txt_Dscto02_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto02.KeyPress
        ' Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Dscto02_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto02.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub
        If Val(Txt_Dscto02.Text) = 0 Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            If DGrid.Rows(I).Cells("costo").Value = "" Then Continue For
            DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(DGrid.Rows(I).Cells("pcomp").Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(DGrid.Rows(I).Cells("precio").Value, DGrid.Rows(I).Cells("costo").Value), "#0.00")
            Call Totalizados(True, I)
        Next
    End Sub



    Private Sub Txt_Dscto03_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto03.GotFocus
        Txt_Dscto03.SelectAll()
    End Sub

    Private Sub Txt_Dscto03_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto03.KeyPress
        ' Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Dscto03_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto03.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub
        If Val(Txt_Dscto03.Text) = 0 Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            If DGrid.Rows(I).Cells("costo").Value = "" Then Continue For
            DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(DGrid.Rows(I).Cells("pcomp").Value), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(Val(DGrid.Rows(I).Cells("precio").Value), DGrid.Rows(I).Cells("costo").Value), "#0.00")
            Call Totalizados(True, I)
        Next
    End Sub


    Private Sub Txt_Dscto04_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto04.GotFocus
        Txt_Dscto04.SelectAll()
    End Sub

    Private Sub Txt_Dscto04_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto04.KeyPress
        'Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Dscto04_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto04.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub
        If Val(Txt_Dscto04.Text) > 0 Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            If DGrid.Rows(I).Cells("costo").Value = "" Then Continue For
            DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(DGrid.Rows(I).Cells("pcomp").Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(DGrid.Rows(I).Cells("precio").Value, DGrid.Rows(I).Cells("costo").Value), "#0.00")
            Call Totalizados(True, I)
        Next
    End Sub



    Private Sub Txt_Dscto05_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto05.GotFocus
        Txt_Dscto05.SelectAll()
    End Sub

    Private Sub Txt_Dscto05_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Dscto05.KeyPress
        'Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Observa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Observa.GotFocus
        Txt_Observa.SelectAll()
    End Sub



    Private Sub Txt_Observa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Observa.KeyPress
        Txt_Observa.CharacterCasing = CharacterCasing.Upper
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DGrid.RowCount = 1
    End Sub




    Private Sub Btn_Correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Correo.Click


        'mreyes 28/Febrero/2012 05:13 p.m.
        If Permiso() = False Then Exit Sub
        Call Btn_Pdf_Click(sender, e)

        Try
            If MsgBox("Esta seguro de querer enviar la Orden de Compra por correo al proveedor.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            ' checar permiso
            If GLB_Usuario <> "RESM1979" And GLB_Usuario <> "FELIX" And GLB_Usuario <> "FELIXJ" Or GLB_Usuario <> "LORIS" Then
                If pub_TienePermisoProceso("COSBIT", "00", "", True) = False Then Exit Sub


                Dim myFpermiso As New frmPermisoProceso
                myFpermiso.ShowDialog()
                If GLB_PermisoProceso = False Then Exit Sub
            End If


            Dim Anio As String = Format(CDate(Txt_Fecha.Text), "yyyy")
            Dim Mes As String = Format(CDate(Txt_Fecha.Text), "MMMM").ToUpper
            Dim Tipo As String = "Proveedor"
            Dim NombrePedido As String = Txt_Marca.Text & "_" & Txt_Sucursal.Text & Txt_OrdeComp.Text & "_Prov.pdf"
            Dim Idempleadob As Integer = 0

            Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet

                objDatasetE = objMarca.usp_TraerMarca(Txt_Marca.Text, "")
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Idempleadob = (objDatasetE.Tables(0).Rows(0).Item("idempleado").ToString)

                End If
            End Using

            Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)

                Try
                    'Get the specific project selected in the ListView control
                    objDataSet = objPersis.usp_TraerCorreoNomina(Idempleadob)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_CorreoCompras = objDataSet.Tables(0).Rows(0).Item("email").ToString
                        GLB_PassCorreoCompras = objDataSet.Tables(0).Rows(0).Item("passemail").ToString

                    End If

                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


            RutaArchivoCorreo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Txt_Marca.Text & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
            If EnviarCorreo(Txt_OrdeComp.Text, False) = False Then
                MsgBox("Correo no enviado.", MsgBoxStyle.Critical, "Error al enviar")
            Else
                If Inserta_SigBit("1900-01-01", "1900-01-01", Txt_OrdeComp.Text) = False Then

                End If
                '' Enviar correo a compras
                If EnviarCorreo(Txt_OrdeComp.Text, True) = False Then

                End If

                MsgBox("Correo enviado con éxito.", MsgBoxStyle.Information, "Confirmación")
            End If



        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub CMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMenu.Opening
        If Sw_PedidoNuevo = True Then
            NuevoEstiloToolStripMenuItem.Enabled = True
        Else
            NuevoEstiloToolStripMenuItem.Enabled = False
        End If
    End Sub


    Private Sub PBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBox.Click
        'mreyes 03/Marzo/2012 10:01 a.m.
        Try
            Dim myForm As New frmConsultaImagen
            myForm.Txt_Estilon.Text = EstiloNFOTO
            myForm.Txt_Marca.Text = MarcaFOTO
            myForm.Txt_NoFoto.Text = 1
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGrid.KeyUp
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("EstiloNuestro").Value = "" Then Exit Sub
        CargarFotoArticulo(Txt_Marca.Text, DGrid.Rows(DGrid.CurrentRow.Index).Cells("EstiloNuestro").Value)
        Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
        DGrid.FirstDisplayedScrollingColumnIndex = columna

        '' Traer el presupuesto
        'Pnl_Presupuesto.Visible = True

    End Sub

    Private Sub DGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.Click
        If sw_cambioceros Then Exit Sub
        If DGrid.Rows(DGrid.CurrentRow.Index).Cells("EstiloNuestro").Value = "" Then Exit Sub
        CargarFotoArticulo(Txt_Marca.Text, DGrid.Rows(DGrid.CurrentRow.Index).Cells("EstiloNuestro").Value)

    End Sub


    Private Sub Btn_Transferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Transferir.Click
        'mreyes 23/Marzo/2012 01:52 p.m.
        Try
            Dim Track As Integer = 0
            If ValidarDatos() = False Then Exit Sub

            If MsgBox("Esta seguro de generar una orden de compra con las cantidades solicitadas?.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub

            If Txt_Marca.Text = "CTA" Then
                If MsgBox("Quiere realizar un resurtido automático con artículos del Track?. En caso contrario se generará un pedido con artículos que no pertenecen al Track.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación a Coqueta") = MsgBoxResult.Yes Then
                    Track = 1
                    Txt_Diaspp.Text = "8"
                    Txt_Dsctopp.Text = "0"
                    Txt_Dscto01.Text = "0"
                    Txt_Dscto02.Text = "0"
                    Txt_Dscto03.Text = "0"
                    Txt_Dscto04.Text = "0"
                    Txt_Dscto05.Text = "0"
                Else
                    Track = 0
                End If
            End If



            Btn_Transferir.Enabled = False
            Dim Cantidad As Double = 0


            Using objArticulosSolicitados As New BCL.BCLPedidos(GLB_ConStringCipSis)
                Dim objDataSet As Data.DataSet
                Dim Medida As String = ""
                Dim Corrida As String = ""
                Dim margen As Decimal
                Dim Pcomp As Decimal = 0
                Dim Costo As Decimal = 0
                Dim cont As Integer = 0
                objDataSet = objArticulosSolicitados.usp_TraerArticulosSolicitados(Txt_Marca.Text, Txt_Proveedor.Text, Track)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    For I As Integer = 0 To objDataSet.Tables(0).Rows.Count - 1
                        ' AQUI QUITAR EL I Y USAR OTRO CONT. 

                        If Val(objDataSet.Tables(0).Rows(I).Item("ctd")) >= Val(objDataSet.Tables(0).Rows(I).Item("resmin")) Then
                            Corrida = objDataSet.Tables(0).Rows(I).Item("corrida").ToString

                            Format(pub_CalcularCostoPedido(Val(objDataSet.Tables(0).Rows(I).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")

                            Pcomp = Format(Val(objDataSet.Tables(0).Rows(I).Item("costo").ToString), "#,##0.00")
                            Costo = Format(pub_CalcularCostoPedido(Val(objDataSet.Tables(0).Rows(I).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
                            margen = Format(pub_CalcularMargenPedido(Val(objDataSet.Tables(0).Rows(I).Item("precio")), Costo), "#0.00")



                            MedidaEstilo = objDataSet.Tables(0).Rows(I).Item("medida")
                            DGrid.Rows.Add("", "", "", "", "", "", objDataSet.Tables(0).Rows(I).Item("tipoart").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("familia").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("linea").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("categoria").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("estilof").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("estilon"),
                                             objDataSet.Tables(0).Rows(I).Item("descripc"),
                                             objDataSet.Tables(0).Rows(I).Item("corrida").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("intervalo").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("medini").ToString,
                                             objDataSet.Tables(0).Rows(I).Item("medfin").ToString,
                                              Format(Pcomp, "#,##0.00"), Format(Costo, "#,##0.00"),
                                             Format(Val(objDataSet.Tables(0).Rows(I).Item("precio").ToString), "#,##0.00"), Format(margen, "#0.00"),
                                             Txt_Sucursal.Text, Txt_DescripSucursal.Text,
                                             "", "", "",
                                             "", "", "", "", "", "", "", "", "", "",
                                             "", "", "", "", "", "", "", "", "", "",
                                             "", "", "", "", "", "", "", "", "", "",
                                            "", "", "", "", "", "", "", "", "", "",
                                            "", "", "",
                                            "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Nothing, Nothing)

                            If objDataSet.Tables(0).Rows(I).Item("tipoart").ToString = "001" Or MedidaEstilo = "N" Then
                                Call TraerCorridaEdicionArticulosSolicitados(cont, Corrida)
                            Else
                                Using objCatalogoEstilos As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                                    Dim objDataSet1 As Data.DataSet

                                    objDataSet1 = objCatalogoEstilos.usp_TraerCorrida(DGrid.Rows(I).Cells("csuc").Value, Txt_Marca.Text, DGrid.Rows(cont).Cells(11).Value, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, Txt_Proveedor.Text)

                                    If objDataSet1.Tables(0).Rows.Count > 0 Then
                                        '' si existe estilo, traerlo.
                                        Dim M1 As String = objDataSet1.Tables(0).Rows(0).Item("ordenini").ToString
                                        Dim M2 As String = objDataSet1.Tables(0).Rows(0).Item("ordenfin").ToString
                                        If M1 = "" Then
                                            M1 = objDataSet1.Tables(0).Rows(0).Item("medini").ToString
                                        End If
                                        If M2 = "" Then
                                            M2 = objDataSet1.Tables(0).Rows(0).Item("medfin").ToString
                                        End If
                                        Call RellenarMedidas(cont, M1, M2, objDataSet.Tables(0).Rows(I).Item("estilon").ToString, objDataSet.Tables(0).Rows(I).Item("corrida").ToString, objDataSet.Tables(0).Rows(I).Item("intervalo").ToString, True, "", "")
                                    End If
                                End Using


                            End If

                            cont = cont + 1
                        End If
                    Next
                    If cont = 0 Then
                        MsgBox("No existen cantidades solicitadas para la marca '" & Txt_Marca.Text & "' y el proveedor '" & Txt_Proveedor.Text & "'.", MsgBoxStyle.Information, "Aviso")
                    End If
                Else
                    MsgBox("No existen cantidades solicitadas para la marca '" & Txt_Marca.Text & "' y el proveedor '" & Txt_Proveedor.Text & "'.", MsgBoxStyle.Information, "Aviso")
                End If
            End Using

            DGrid.Columns(24).Selected = True
            For I As Integer = 0 To DGrid.RowCount - 2
                Call Totalizados(True, I)
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Function Inserta_SigBit(ByVal FechaEntrega As Date, ByVal FechaEntregaNew As Date, ByVal OrdeComp As String) As Boolean
        'mreyes 24/Marzo/2012 11:24 a.m.

        Using objSigBit As New BCL.BCLBitacora(GLB_ConStringCipSis)
            'Get a new Project DataSet
            Try
                objDataSet = objSigBit.Inserta_SigBit
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("sucursal") = Txt_Sucursal.Text.ToString.Trim
                objDataRow.Item("ordecomp") = OrdeComp
                objDataRow.Item("marca") = Trim(Txt_Marca.Text)
                objDataRow.Item("estilon") = ""
                objDataRow.Item("fecha") = Format(Now.Date, "dd-MM-yyyy")
                If FechaEntrega <> "1900-01-01" Then
                    objDataRow.Item("atiende") = ""
                Else
                    objDataRow.Item("atiende") = Mid(Txt_Email01.Text, 1, 100)
                End If
                objDataRow.Item("realiza") = GLB_NomUsuario
                If FechaEntrega <> "1900-01-01" Then
                    objDataRow.Item("motivo") = UCase("Cambio de Fechas de Entrega")
                    objDataRow.Item("comentarios") = UCase("Se modifico Fecha de Entrega ") & FechaEntrega & " a " & FechaEntregaNew
                Else
                    If Sw_PedidoMano = True Then
                        objDataRow.Item("motivo") = UCase("Entrega en mano.")
                    Else
                        objDataRow.Item("motivo") = UCase("Envío de orden de compra vía email")
                    End If

                    objDataRow.Item("comentarios") = UCase("Orden enviada ") & " " & Date.Now '& " " & DateTime.Now.ToLongTimeString
                End If

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objSigBit.usp_Captura_SegBit(1, objDataSet) Then
                    Throw New Exception("Falló Inserción de SegBit")
                Else
                    Inserta_SigBit = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Private Sub Txt_Iva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Iva.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub

    Private Sub Txt_Iva_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Iva.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(DGrid.Rows(I).Cells("pcomp").Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(DGrid.Rows(I).Cells("precio").Value, DGrid.Rows(I).Cells("costo").Value), "#0.00")
            Call Totalizados(True, I)
        Next
    End Sub



    Private Sub Txt_Dscto05_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Dscto05.LostFocus
        If DGrid.RowCount <= 1 Then Exit Sub
        If Val(Txt_Dscto05.Text) > 0 Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(DGrid.Rows(I).Cells("pcomp").Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            DGrid.Rows(I).Cells("porc").Value = Format(pub_CalcularMargenPedido(DGrid.Rows(I).Cells("precio").Value, DGrid.Rows(I).Cells("costo").Value), "#0.00")
            Call Totalizados(True, I)
        Next
    End Sub



    Private Sub Txt_FechaFactura_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_FechaFactura.LostFocus

        If Txt_FechaFactura.Text.Length > 0 And Txt_Diaspp.Text.Length > 0 Then
            Txt_FechaVence.Text = Format(pub_FechaVence(Txt_FechaFactura.Text, Txt_Diaspp.Text), "yyyy-MM-dd")
            Txt_FechaVence.Text = Format(pub_FechaVence(Txt_Fecha.Text, Txt_Diaspp.Text), "yyyy-MM-dd")

            If FechaEntregaMax <> "1900-01-01" Then
                If CDate(FechaEntregaMax) > CDate(Txt_Fecha.Text) Then
                    Txt_FechaVence.Text = Format(pub_FechaVence(FechaEntregaMax, Txt_Diaspp.Text), "yyyy-MM-dd")
                End If

            End If

        End If
        If Txt_FechaFactura.Text.Length > 0 Then
            Txt_FechaFactura.Text = Format(CDate(Txt_FechaFactura.Text), "yyyy-MM-dd")
        End If
        FechaEntregaMax = "1900-01-01"
    End Sub



    Private Sub Txt_Referenc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Referenc.LostFocus
        'mreyes 23/Mayo/2012 05:40 p.m.
        Try
            'If usp_ExisteFactProv() = True Then
            '    'ya existe la factura para el proveedor.
            '    MsgBox("Ya existe la relación Factura-Proveedor, verifique por favor el folio, En caso contario proceda.", MsgBoxStyle.Critical, "Validación")
            '    'Txt_Referenc.Text = ""
            '    'Txt_Referenc.Enabled = True
            '    'Txt_Referenc.ReadOnly = False
            '    'Txt_Referenc.Focus()
            'End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Sw_ProvDif = True Then
        '    Dim myForm1 As New frmCatalogoPagosTarjetas

        '    myForm1.Txt_Total.Text = Txt_Total.Text
        '    myForm1.ShowDialog()
        'End If

        DGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        'Me.DGrid.AllowUserToAddRows = False
        'Me.DGrid.Dock = DockStyle.Fill
        'Me.Controls.Add(Me.DGrid)

        If Me.DGrid.GetCellCount(DataGridViewElementStates.Selected) > 0 Then

            Try

                ' Add the selection to the clipboard.
                Clipboard.SetDataObject(
                    Me.DGrid.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                ' Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException

            End Try

        End If





    End Sub


    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        ' If Val(Txt_OrdeComp.Text) = 0 Then Exit Sub
        If Txt_OrdeComp.Text = "" Then
            MsgBox("No puede realizar una impresión de un documento sin terminar.", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        If Sw_FacturaNueva = True Or Sw_Factura = True Then
            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 13)
        ElseIf Sw_Devolucion = True Then
            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, IIf(Sw_Serie = True, 34, 33))
        Else
            Call ImprimirPedidoNuevo(Txt_Sucursal.Text, Txt_OrdeComp.Text, 3)
        End If
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim data As IDataObject = Clipboard.GetDataObject
        Dim i As Integer = 0
        Dim j As Integer = 0

        If Not data.GetDataPresent("CSV", False) Then Return

        Try
            'Obtenemos el texto almacenado en el portapapales 
            Dim s As String = Clipboard.GetText

            'hacemos un split para organizar la informacion por lineas 
            'Dim lines As String() = s.Split(New Char(1) {ControlChars.Cr, _ ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries) 
            Dim lines As String() = s.Split(New Char(1) {ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)


            Clipboard.GetText()
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Renglon1 As Integer = renglon

            DGrid.Rows(renglon).Cells(columna).Value = Clipboard.GetText()

            For Each line As String In lines
                'Creamos una fila referenciando a la tabla datasource del DataGridView 

                'Obtenemos las celdas que el usuario copia 
                Dim cells As String() = line.Split(ControlChars.Tab)

                j = columna
                'Burbuja para asignar cada uno de los datos de cada columna copia 
                For Each cell As String In cells
                    DGrid.Rows(Renglon1).Cells(j).Value = cell
                    j = j + 1
                Next
                i = i + 1
                j = 0
                'Agregamos la fila a la tabla 
                Renglon1 = Renglon1 + 1
            Next



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CopiarSelecciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarSelecciónToolStripMenuItem.Click
        DGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        'Me.DGrid.AllowUserToAddRows = False
        'Me.DGrid.Dock = DockStyle.Fill
        'Me.Controls.Add(Me.DGrid)

        If Me.DGrid.GetCellCount(DataGridViewElementStates.Selected) > 0 Then

            Try

                ' Add the selection to the clipboard.
                Clipboard.SetDataObject(
                    Me.DGrid.GetClipboardContent())

                ' Replace the text box contents with the clipboard text.
                ' Me.TextBox1.Text = Clipboard.GetText()

            Catch ex As System.Runtime.InteropServices.ExternalException

            End Try

        End If
    End Sub

    Private Sub PegarSelecciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarSelecciónToolStripMenuItem.Click
        Dim data As IDataObject = Clipboard.GetDataObject
        Dim i As Integer = 0
        Dim j As Integer = 0

        If Not data.GetDataPresent("CSV", False) Then Return

        Try
            'Obtenemos el texto almacenado en el portapapales 
            Dim s As String = Clipboard.GetText

            'hacemos un split para organizar la informacion por lineas 
            'Dim lines As String() = s.Split(New Char(1) {ControlChars.Cr, _ ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries) 
            Dim lines As String() = s.Split(New Char(1) {ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)


            Clipboard.GetText()
            Dim columna As Integer = DGrid.CurrentCell.ColumnIndex
            Dim renglon As Integer = DGrid.CurrentCell.RowIndex
            Dim Renglon1 As Integer = renglon
            Dim Tot As Integer = 0
            'If DGrid.Rows(renglon).Cells(columna).Visible = True And DGrid.Rows(renglon).Cells(columna).Style.BackColor = Color.Yellow Then
            DGrid.Rows(renglon).Cells(columna).Value = Clipboard.GetText()
            ' End If

            For Each line As String In lines
                'Creamos una fila referenciando a la tabla datasource del DataGridView 

                'Obtenemos las celdas que el usuario copia 
                Dim cells As String() = line.Split(ControlChars.Tab)

                j = columna
                'Burbuja para asignar cada uno de los datos de cada columna copia 
                For Each cell As String In cells
                    'If DGrid.Rows(Renglon1).Cells(j).Visible = True And DGrid.Rows(Renglon1).Cells(j).Style.BackColor = Color.Yellow Then
                    If DGrid.Rows(Renglon1).Cells(j).Visible = True And DGrid.Rows(Renglon1).Cells(j).Style.BackColor = Color.Yellow Then
                        DGrid.Rows(Renglon1).Cells(j).Value = cell
                        Call Totalizados(True, Renglon1)
                        j = j + 1
                        Tot = Tot + 1
                    Else
                        j = j + 1
                        If Tot = 0 Then
                            DGrid.Rows(renglon).Cells(columna).Value = ""
                            GoTo No
                        End If
                        For X As Integer = j To 123
                            ' j = j + 1
                            If DGrid.Rows(Renglon1).Cells(X).Visible = True And DGrid.Rows(Renglon1).Cells(X).Style.BackColor = Color.Yellow Then
                                DGrid.Rows(Renglon1).Cells(X).Value = cell
                                Tot = Tot + 1
                                Call Totalizados(True, Renglon1)
                                j = j + 1
                                Exit For
                            End If
                        Next
                    End If
                Next
                i = i + 1
                j = 0
                'Agregamos la fila a la tabla 
                Renglon1 = Renglon1 + 1
            Next
No:


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Chk_VerPendientexRecibir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_VerPendientexRecibir.CheckedChanged
        If Accion = 4 Then

            DGrid.RowCount = 1

            RellenaOrdeComp()
            CargarFotoArticulo(Txt_Marca.Text, DGrid.Rows(0).Cells("EstiloNuestro").Value)
        End If
    End Sub


    Private Sub Txt_NoBulto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NoBulto.LostFocus

        Dim FechaEntregaMaxAnterior As Date = "1900-01-01"
        Try
            If Txt_NoBulto.Text.Length = 0 Or Accion <> 1 Then Exit Sub

            If GLB_CveSucursal <> "" Then
                Txt_Sucursal.Text = GLB_CveSucursal
                If GLB_CveSucursal = "99" Then Txt_Sucursal.Text = "15"
                Txt_FechaVence.ReadOnly = True

            Else
                Txt_Sucursal.Text = "   15"
            End If

            If GLB_Idempleado = 1505 Or GLB_Idempleado = 132 Or GLB_Idempleado = 1032 Or GLB_IdDeptoEmpleado = 4 Then
                Txt_Sucursal.Text = Mid(Txt_NoBulto.Text, 1, 2)
            End If


            Txt_Sucursal.ReadOnly = True

            Dim objDataSet As Data.DataSet
            Using objEmpleado As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objEmpleado.usp_TraerBulto("", Txt_NoBulto.Text)
                If objDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No se encuentra el folio de bultos dado de alta. Verifique por favor.", MsgBoxStyle.Critical, "Error")
                    Txt_NoBulto.Text = ""
                    Txt_NoBulto.Focus()
                    Exit Sub
                End If
                If objDataSet.Tables(0).Rows(0).Item("status").ToString = "ZC" Then
                    MsgBox("El folio se encuentra CANCELADO no se puede recibir.", MsgBoxStyle.Critical, "Aviso")
                    Txt_NoBulto.Text = ""
                    Txt_NoBulto.Focus()
                    Exit Sub

                End If

                If objDataSet.Tables(0).Rows(0).Item("sf") = 1 Then
                    'no tiene factura.
                    Txt_Referenc.Text = "SINFACT"
                    Txt_Referenc.ReadOnly = True
                End If


            End Using


            FolioB = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idfolio").ToString, 6)
            If Val(objDataSet.Tables(0).Rows(0).Item("detalle").ToString) > 0 And Sw_Devolucion = False Then

                MsgBox("El folio de bultos '" & Txt_NoBulto.Text & "', ya ha sido recibido.", MsgBoxStyle.Critical, "VALIDACIÓN")
                Txt_NoBulto.Text = ""
                Txt_NoBulto.Focus()
                Exit Sub

            End If

            Txt_NoBulto.Enabled = False
            'Call TxtLostfocusPersis(Txt_Sucursal, Txt_DescripSucursal, "S")
            Txt_Proveedor.Text = objDataSet.Tables(0).Rows(0).Item("proveedor").ToString
            NoBultos = objDataSet.Tables(0).Rows(0).Item("nobultos").ToString
            Call TxtLostfocus(Txt_Proveedor, Txt_Raz_Soc, "P")
            ' Txt_NoGuia.Text = objDataSet.Tables(0).Rows(0).Item("noguia").ToString
            Txt_Transporte.Text = objDataSet.Tables(0).Rows(0).Item("transporta").ToString
            ' Txt_NoBultos.Text = objDataSet.Tables(0).Rows(0).Item("nobultos").ToString
            'Txt_Recibe.Text = objDataSet.Tables(0).Rows(0).Item("recibe").ToString
            'Txt_DescripRecibe.Text = usp_TraerNomEmpleado(objDataSet.Tables(0).Rows(0).Item("recibe"))

            'Txt_Comentarios.Text = objDataSet.Tables(0).Rows(0).Item("comentarios").ToString
            'DateTimePicker1.Value = CDate(objDataSet.Tables(0).Rows(0).Item("fecrecibe").ToString)

            '' Traer datos del pedido para rellenar .. 

            ' Ir a buscar las ordenes de compra de bultos.. 
            ' desde aqui '
            FechaEntregaMax = "1900-01-01"
            If Sw_Devolucion = False Then

                Dim objDataSet1 As Data.DataSet
                Using objSucursal As New BCL.BCLPedidos(GLB_ConStringCipSis)
                    Try

                        objDataSet1 = objSucursal.usp_PpalTraerPedidos(Val(FolioB))
                        If objDataSet1.Tables(0).Rows.Count = 1 Then
                            Call usp_TraerPedidosBultos()

                        Else

                            Call TraerListadopEDIDOS()
                            If IntSelectPed > 0 Then
                                Call usp_TraerOrdeCompBulto(SucSelectPed(0), PedSelectPed(0))
                                FechaEntregaMaxAnterior = usp_TraerOrdeCompMaxEntrega(SucSelectPed(0), PedSelectPed(0))
                                If FechaEntregaMaxAnterior > FechaEntregaMax Then
                                    FechaEntregaMax = FechaEntregaMaxAnterior
                                End If
                                Dim Renglones As Integer = 0
                                For I As Integer = 0 To IntSelectPed - 1
                                    'If PedSelectPed(I) = "000379" Then MsgBox("HOLA")


                                    Call usp_TraerDet_OcBultos(SucSelectPed(I), PedSelectPed(I), I)
                                    Renglones = Renglones + 1
                                Next
                                ' hasta aca
                            Else
                                Call usp_TraerPedidosBultos()
                            End If

                        End If
                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using

                'Call TraerListadopEDIDOS()
                'If IntSelectPed > 0 Then
                '    For I As Integer = 0 To IntSelectPed - 1
                '        Call usp_TraerDet_OcBultos(SucSelectPed(I), PedSelectPed(I))

                '    Next
                '    ' hasta aca
                'Else
                '    Call usp_TraerPedidosBultos()
                'End If


                For I As Integer = 0 To DGrid.RowCount - 2
                    Call Totalizados(True, I)
                Next

                DGrid.Columns("i").Visible = False
                DGrid.Columns("c").Visible = False
                DGrid.Columns("porc").Visible = False




                Btn_Pdf.Enabled = False
                Btn_Excel.Enabled = False
                Btn_Imprimir.Enabled = False
            Else
                '' SI ES DEVOLUCIÓN.
                Txt_Sucursal.Text = Mid(Txt_NoBulto.Text, 1, 2)

                Call RellenaFactura()
                For I As Integer = 0 To DGrid.RowCount - 2
                    Call Totalizados(True, I)
                Next
                DGrid.Columns("i").Visible = False
                DGrid.Columns("c").Visible = False
                DGrid.Columns("porc").Visible = False

                Call InicializaDevolucion()


                Btn_Pdf.Enabled = False
                Btn_Excel.Enabled = False
                Btn_Imprimir.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Private Sub Btn_Bulto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Bulto.Click
        Try
            If Sw_FacturaNueva = True Or Sw_Factura = True Or Sw_Devolucion = True Then
                If Val(FolioB) > 0 Then
                    Dim myForm As New frmCatalogoReciboBultos
                    myForm.Accion = 3
                    myForm.Folio = FolioB
                    myForm.FolioB = FolioB
                    myForm.ShowDialog()
                    'If myForm.Guardo = True Then
                    '    frmPpalActividadesEmp_Load(sender, e)
                    'End If
                Else
                    MsgBox("No cuenta con datos suficientes para revisar el recibo de bultos.", MsgBoxStyle.Critical, "Aviso")
                    Exit Sub
                End If


                'ElseIf Sw_PedidoNuevo = True Then
                '    Dim myForm As New frmPpalResurtidoAut
                '    myForm.Opcion = 3
                '    myForm.OrdeComp = Txt_OrdeComp.Text
                '    myForm.Sucursal = Txt_Sucursal.Text

                '    myForm.ShowDialog()
                'If myForm.Guardo = True Then
                '    frmPpalActividadesEmp_Load(sender, e)
                'End If
            Else
                MsgBox("Opción no valida.", MsgBoxStyle.Critical, "Aviso")
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Chk_Estructura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_Estructura.CheckedChanged
        If Chk_Estructura.Checked = True Then
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(127).Visible = False
            DGrid.Columns(128).Visible = False
            DGrid.Columns(129).Visible = False
            DGrid.Columns(130).Visible = False
            DGrid.Columns(131).Visible = False
            DGrid.Columns(132).Visible = False
        Else
            DGrid.Columns(6).Visible = True
            DGrid.Columns(7).Visible = True
            DGrid.Columns(8).Visible = True
            DGrid.Columns(9).Visible = True
            DGrid.Columns(127).Visible = True
            DGrid.Columns(128).Visible = True
            DGrid.Columns(129).Visible = True
            DGrid.Columns(130).Visible = True
            DGrid.Columns(131).Visible = True
            DGrid.Columns(132).Visible = True
        End If
    End Sub


    Private Sub Opt_Remision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opt_Remision.CheckedChanged

        If Accion = 4 Then Exit Sub
        If Opt_Remision.Checked = True Then
            Txt_Iva.Enabled = False
            Txt_Iva.Text = "0.0"

            '   Txt_Referenc.Text = "R" & Mid(Txt_Referenc.Text, 2)
            DGrid.Focus()
            Call Totalizados(True, 0)
        Else
            Txt_Iva.Enabled = True
            Txt_Iva.Text = "16"
            '  Txt_Referenc.Text = "F" & Mid(Txt_Referenc.Text, 2)
            DGrid.Focus()
            Call CambioIva()
            Call Totalizados(True, 0)
        End If
    End Sub

    Private Sub CambioIva()
        If DGrid.RowCount <= 1 Then Exit Sub
        For I As Integer = 0 To DGrid.RowCount - 2
            DGrid.Rows(I).Cells("pcomp").Value = Format(pub_CalcularCostoPedido(DGrid.Rows(I).Cells("pcomp").Value, Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")
            ' DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularCostoPedido(Val(objDataSet.Tables(0).Rows(0).Item("COSTO")), Val(Txt_Dsctopp.Text), Val(Txt_Dscto01.Text), Val(Txt_Dscto02.Text), Val(Txt_Dscto03.Text), Val(Txt_Dscto04.Text), Val(Txt_Dscto05.Text), Val(Txt_Iva.Text)), "#,##0.00")

            'DGrid.Rows(I).Cells("costo").Value = Format(pub_CalcularMargenPedido(DGrid.Rows(I).Cells("precio").Value, DGrid.Rows(I).Cells("costo").Value), "#0.00")


        Next
    End Sub


    Private Sub Txt_Gastos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Gastos.LostFocus
        Try

            If Val(Txt_Gastos.Text) = 0 Then Exit Sub

            Txt_TotalIVA.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)), "$#,##0.00")

            Txt_TotalDescto.Text = Format((CDbl(Txt_Subtotal.Text) + CDbl(Txt_NotaCredito.Text) - CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text)) * IIf(Val(Txt_Dsctopp.Text) = 0, 0, (Val(Txt_Dsctopp.Text) / 100)), "$#,##0.00")

            Txt_Descuento.Text = Txt_TotalDescto.Text



            If Val(Txt_Dscto01.Text) > 0 Then
                Txt_Descuento.Text = CDbl(Txt_TotalDescto.Text) + Format((CDbl(Txt_NotaCredito.Text) + CDbl(Txt_NotaCargo.Text) + CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_TotalDescto.Text)) * IIf(Val(Txt_Dscto01.Text) = 0, 0, (Val(Txt_Dscto01.Text) / 100)), "$#,##0.00")
                Txt_TotalDescto.Text = Format(CDbl(Txt_Descuento.Text), "$#,##0.00")
            End If




            '           Txt_Total.Text = Format(Importe, "$#,##0.00")
            '
            Txt_Total.Text = Format(CDbl(Txt_Subtotal.Text) + (CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text)) * IIf(Val(Txt_Iva.Text) = 0, 0, (Val(Txt_Iva.Text) / 100)) - CDbl(Txt_Descuento.Text), "$#,##0.00")





            'hasta aqui--- 
            Txt_Total.Text = Format(CDbl(Txt_Subtotal.Text) + CDbl(Txt_Gastos.Text) + CDbl(Txt_TotalIVA.Text) - CDbl(Txt_Descuento.Text), "$#,##0.00")
            'End If

            If CDbl(Txt_NotaCargo.Text) > 0 Then

                Txt_Total.Text = Format(CDbl(Txt_Total.Text) - CDbl(Txt_NotaCargo.Text), "$#,##0.00")



            End If


            If CDbl(Txt_NotaCredito.Text) > 0 Then
                Txt_Total.Text = Format(CDbl(Txt_Total.Text) + CDbl(Txt_NotaCredito.Text), "$#,##0.00")

            End If


            Txt_NotaCredito.Text = Format(CDbl(Txt_NotaCredito.Text), "$#,##0.00")
            Txt_NotaCargo.Text = Format(CDbl(Txt_NotaCargo.Text), "$#,##0.00")


            'Call Totalizados(True, 0)

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub



    Private Sub Btn_Series_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Series.Click
        Try
            Dim myForm As New frmConsultaSeries
            If Sw_Factura = True Then
                myForm.Tipo = "F"
            Else
                myForm.Tipo = "D"
            End If
            myForm.Btn_Series.Visible = True
            myForm.Sucursal = Txt_Sucursal.Text
            myForm.Folio = Txt_OrdeComp.Text
            myForm.IdFolio = FolioB
            myForm.ShowDialog()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub




    Private Sub Pnl_Presupuesto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_Presupuesto.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                izquierda = e.X
                alto = e.Y
                Pnl_Presupuesto.Cursor = Cursors.SizeAll
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Presupuesto_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_Presupuesto.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Pnl_Presupuesto.Location = New Point(Pnl_Presupuesto.Left + e.X - izquierda, Pnl_Presupuesto.Top + e.Y - alto)
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Pnl_Presupuesto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl_Presupuesto.MouseUp
        Try
            Pnl_Presupuesto.Cursor = Cursors.Default
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub ValidarMarcaProv()
        'mreyes 11/03/2014 12:01 p.m.
        If IdProveedorB <> 0 Then
            Using objMySqlGral As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                Try
                    objDataSet = objMySqlGral.usp_TraerCondicionesProv(IdProveedorB, Txt_Marca.Text)
                    If objDataSet.Tables(0).Rows.Count = 0 Then

                        MsgBox("No existe la asignación de la marcar para el proveedor, Verifique con compras.", MsgBoxStyle.Critical, "Validación")
                        Txt_Marca.Text = ""
                        IdProveedorB = 0
                        Txt_Proveedor.Text = ""
                        Txt_Marca.Focus()
                    End If



                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


        End If
    End Sub
    Private Sub AgregarColumna()
        'mreyes 02/Abril/2014   11:42 a.m.

        Dim colImagen As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        colImagen.Name = "Canc"
        colImagen.HeaderText = "Canc"
        colImagen.DisplayIndex = 100
        colImagen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        colImagen.CellTemplate = New DataGridViewCheckBoxCell()
        ' añadir columna de imagen a la coleccion del grid 
        DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        ''DGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGrid.Columns.Add(colImagen)
        DGrid.Columns("Canc").ReadOnly = False

    End Sub
    Private Sub ValidarDevoMarcaProv()
        'mreyes 11/03/2014 12:01 p.m.
        If IdProveedorB <> 0 Then


            If Sw_Devolucion = True Then
                Using objMySqlGral As New BCL.BCLCatalogoProveedoresN(GLB_ConStringCipSis)
                    Try
                        objDataSet = objMySqlGral.usp_TraerDevolucionesProv(IdProveedorB, Txt_Marca.Text)
                        If objDataSet.Tables(0).Rows.Count = 0 Then

                            MsgBox("No se puede generar una devolución, ya que las condiciones del proveedor no lo permiten.", MsgBoxStyle.Critical, "Validación")
                            Txt_Marca.Text = ""
                            Txt_Marca.Focus()

                        End If



                    Catch ExceptionErr As Exception
                        MessageBox.Show(ExceptionErr.Message.ToString)
                    End Try
                End Using
            End If
        End If
    End Sub


    Private Sub Txt_Observa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Observa.TextChanged

    End Sub

    Private Sub Txt_CorreoCancela_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CorreoCancela.KeyPress
        Txt_CorreoCancela.CharacterCasing = CharacterCasing.Upper
    End Sub


    Private Sub Txt_CorreoCancela_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_CorreoCancela.TextChanged


    End Sub

    Private Sub Btn_CorreoCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CorreoCancela.Click
        'mreyes 28/Febrero/2012 05:13 p.m.

        Try
            Dim Cancelados As Integer = 0
            Dim Estilon As String = ""
            Dim FechaEntrega As Date = "1900-01-01"
            Dim corrida As String = ""

            If MsgBox("Esta seguro de cancelar los estilos seleccionados y  enviar la Orden de Compra por correo al proveedor.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmación") = MsgBoxResult.No Then Exit Sub
            ' checar permiso
            ' If Permiso() = False Then Exit Sub
            'CANCELAR PEDIDOS SELECCIONADOS




            'CHECAR CADA COLUMNA 
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("CANC").Value = True Then
                    Estilon = DGrid.Rows(i).Cells("estilonuestro").Value()
                    FechaEntrega = DGrid.Rows(i).Cells("fechaentrega").Value()
                    corrida = DGrid.Rows(i).Cells("c").Value()
                    Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        objCantArti.usp_ActualizarModeloCancelado(GLB_Idempleado, Txt_Sucursal.Text, Txt_OrdeComp.Text, Trim(Txt_Marca.Text), Estilon, FechaEntrega, corrida)
                    End Using
                    Cancelados += 1
                End If
            Next


            Call Btn_Pdf_Click(sender, e)

            'If GLB_Usuario <> "MREYES" And GLB_Usuario <> "FELIX" And GLB_Usuario <> "FELIXJ" Then
            '    If pub_TienePermisoProceso("COSBIT", "00", "", True) = False Then Exit Sub


            '    Dim myFpermiso As New frmPermisoProceso
            '    myFpermiso.ShowDialog()
            '    If GLB_PermisoProceso = False Then Exit Sub
            'End If


            Dim Anio As String = Format(CDate(Txt_Fecha.Text), "yyyy")
            Dim Mes As String = Format(CDate(Txt_Fecha.Text), "MMMM").ToUpper
            Dim Tipo As String = "Proveedor"
            Dim NombrePedido As String = Txt_Marca.Text & "_" & Txt_Sucursal.Text & Txt_OrdeComp.Text & "_Prov.pdf"
            Dim Idempleadob As Integer = 0

            Using objMarca As New BCL.BCLCatalogoEstilos(GLB_ConStringCipSis)
                Dim objDatasetE As Data.DataSet

                objDatasetE = objMarca.usp_TraerMarca(Txt_Marca.Text, "")
                If objDatasetE.Tables(0).Rows.Count > 0 Then
                    Idempleadob = (objDatasetE.Tables(0).Rows(0).Item("idempleado").ToString)

                End If
            End Using

            Using objPersis As New BCL.BCLCatalogoEmpleado(GLB_ConStringNomSis)




                Try
                    'Get the specific project selected in the ListView control
                    objDataSet = objPersis.usp_TraerCorreoNomina(Idempleadob)
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        GLB_CorreoCompras = objDataSet.Tables(0).Rows(0).Item("email").ToString
                        GLB_PassCorreoCompras = objDataSet.Tables(0).Rows(0).Item("passemail").ToString

                    End If



                Catch ExceptionErr As Exception
                    MessageBox.Show(ExceptionErr.Message.ToString)
                End Try
            End Using


            RutaArchivoCorreo = GLB_RutaArchivoDigitalPedidos & "\" & IIf(ResurtSN = "N", "Nuevos", "Resurtido") & "\" & Txt_Marca.Text & "\" & Anio & "\" & Mes & "\" & Tipo & "\" & NombrePedido
            If EnviarCorreo(Txt_OrdeComp.Text, False) = False Then
                MsgBox("Correo no enviado.", MsgBoxStyle.Critical, "Error al enviar")
            Else
                If Inserta_SigBit("1900-01-01", "1900-01-01", Txt_OrdeComp.Text) = False Then

                End If
                '' Enviar correo a compras
                If EnviarCorreo(Txt_OrdeComp.Text, True) = False Then

                End If

                MsgBox("Correo enviado con éxito. Se cancelaron '" & Cancelados & "' modelos.", MsgBoxStyle.Information, "Confirmación")
            End If


            Pnl_CorreoCancela.Visible = False
            GLB_RefrescarPedido = True

            Me.Dispose()
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_CancelarPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CancelarPedido.Click
        Dim Cancelados As Integer = 0
        Dim Estilon As String = ""
        Dim FechaEntrega As Date = "1900-01-01"
        Dim corrida As String = ""
        If MsgBox("Desea enviar correo a proveedor de la cancelación?, En caso contrario solo se cancelaran los estilos seleccionados.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then
            For i As Integer = 0 To DGrid.Rows.Count - 1
                If DGrid.Rows(i).Cells("CANC").Value = True Then
                    Estilon = DGrid.Rows(i).Cells("estilonuestro").Value()
                    FechaEntrega = DGrid.Rows(i).Cells("fechaentrega").Value()
                    corrida = DGrid.Rows(i).Cells("c").Value()
                    Using objCantArti As New BCL.BCLPedidos(GLB_ConStringCipSis)
                        objCantArti.usp_ActualizarModeloCancelado(GLB_Idempleado, Txt_Sucursal.Text, Txt_OrdeComp.Text, Trim(Txt_Marca.Text), Estilon, FechaEntrega, corrida)
                    End Using
                    Cancelados += 1
                End If
            Next

            MsgBox("Se cancelaron '" & Cancelados & "' modelos.", MsgBoxStyle.Information, "Confirmación")
            GLB_RefrescarPedido = True

            Me.Dispose()
            Me.Close()

        Else
            Pnl_CorreoCancela.Visible = True
            Txt_CorreoCancela.Focus()
        End If

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub

    Private Sub Btn_InvertirSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_InvertirSeleccion.Click
        For Each row As DataGridViewRow In DGrid.Rows


            If row.Cells("Canc").Value = True Then
                row.Cells("Canc").Value = False
            Else
                row.Cells("Canc").Value = True
            End If


        Next
    End Sub




    Private Sub Btn_Condiciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Condiciones.Click
        Dim myForm As New frmCatalogoProveedoresN

        myForm.Accion = 4
        myForm.Txt_IdProveedor.Text = IdProveedorB
        myForm.Txt_Proveedor.Text = Txt_Proveedor.Text

        myForm.MdiParent = BitacoraMain
        myForm.Show()
    End Sub

    Private Sub Txt_NoBulto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NoBulto.TextChanged

    End Sub

    Private Sub Txt_FechaFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_FechaFactura.TextChanged

    End Sub

    Private Sub Txt_Diaspp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Diaspp.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If Timer1.Interval = 1000 Then
        '    Timer1.Interval = 0
        '    ExportarDGridAExcel(DGrid)
        'End If
    End Sub

    Private Sub Txt_Referenc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Referenc.TextChanged

    End Sub

    Private Sub Opt_Factura_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opt_Factura.CheckedChanged
        If Accion = 4 Then Exit Sub
        'If Opt_Remision.Checked = True Then
        '    Txt_Iva.Enabled = False
        '    Txt_Iva.Text = "0.0"
        '    Txt_Referenc.Text = "R" & Mid(Txt_Referenc.Text, 2)
        '    DGrid.Focus()
        '    Call Totalizados(True, 0)
        'Else
        '    Txt_Iva.Enabled = True
        '    Txt_Iva.Text = "16"
        '    Txt_Referenc.Text = "F" & Mid(Txt_Referenc.Text, 2)
        '    DGrid.Focus()
        '    Call Totalizados(True, 0)
        'End If
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub CopiarAFolioBultoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarAFolioBultoToolStripMenuItem.Click
        Try
            Dim FolioNuevoB As Integer
            Dim FactProv As String = ""
            Dim myFormEstilos As New frmCopiarFolioBulto

            '' si es un estilo nuevo buscado por fábrica entonces, ...
            myFormEstilos.ShowDialog()
            'Eliminar del det_fp original

            FolioNuevoB = myFormEstilos.FolioB

            FactProv = fn_TraerFolioOrdeComp(3, Txt_Sucursal.Text, 1)
            FactProv = pub_RellenarIzquierda(FactProv, 6)

            ' generar folio de orden de compra 
            If Inserta_FactProv(FactProv) = False Then
                'Genera_FactProv = False
                Exit Sub
            End If
            ImpOrdeComp(Cont) = FactProv
            ' actualizar folio ordecomp
            If Actualiza_FolioOrdeComp(4, Txt_Sucursal.Text, 1) = False Then
                '
            End If



            'insetar en el det_fp nuevo.
            'cambiar las series


            ''

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Gastos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Gastos.TextChanged

    End Sub

    Private Sub Txt_NotaCargo_TextChanged(sender As Object, e As EventArgs) Handles Txt_NotaCargo.TextChanged

    End Sub

    Private Sub Txt_Subtotal_TextChanged(sender As Object, e As EventArgs) Handles Txt_Subtotal.TextChanged

    End Sub

    Private Sub Txt_Improcedente_TextChanged(sender As Object, e As EventArgs) Handles Txt_Improcedente.TextChanged

    End Sub

    Private Sub Txt_Improcedente_LostFocus(sender As Object, e As EventArgs) Handles Txt_Improcedente.LostFocus
        Txt_Total.Text = Format(CDbl(Txt_Total.Text) + CDbl(Txt_Improcedente.Text), "$#,##0.00")
    End Sub

    Private Sub Txt_Dsctopp_TextChanged(sender As Object, e As EventArgs) Handles Txt_Dsctopp.TextChanged

    End Sub

    Private Sub Txt_Referenc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Referenc.KeyPress
        Call pub_SoloNumeros(sender, e)
    End Sub
End Class
