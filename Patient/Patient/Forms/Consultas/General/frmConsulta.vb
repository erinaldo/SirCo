Public Class frmConsulta

    Public Tipo As String    'M = MARCA, F = FAMILIA, L = LINEA, P = PROVEEDOR , TA = TIPOARTICULO, C = CATEGORIA
    'E = ESTILO
    Public Campo As String = "" '' valor de regreso para el primer texto
    Public Campo1 As String = "" ''valor de regreso para el segundo texto
    Public Campo2 As String = "" ''valor de regreso para el tercer texto en departamentos.
    Public Sw_Tienda As String = "N"

    Public Sw_Nomina As Boolean = False
    Public idDepto As Integer = 0

    Dim IdDivision As Integer = 0
    Dim IdDepartamento As Integer = 0
    Dim IdFamilia As Integer = 0
    Dim IdLinea As Integer = 0
    Dim IdSubLinea As Integer = 0
    Dim IdSSubLinea As Integer = 0
    Dim IdSSSubLinea As Integer = 0
    Dim IdSSSSubLinea As Integer = 0
    Dim IdColor As Integer = 0
    Dim IdMaterial As Integer = 0

    Public IdSuperior1 As Integer = 0
    Public IdSuperior2 As Integer = 0
    Public IdSuperior3 As Integer = 0
    Public IdSuperior4 As Integer = 0
    Public IdSuperior5 As Integer = 0
    Public IdSuperior6 As Integer = 0
    Public IdSuperior7 As Integer = 0
    Public IdSuperior8 As Integer = 0
    Public IdSuperior9 As Integer = 0
    Public IdSuperior10 As Integer = 0
    Public Opcion As Integer
    Public blnConsultoDistrib As Boolean = False
    Public blnVacio As Boolean = False

    Public IdProveedorB As Integer = 0
    Dim SqlBuscar As String

    Private objDataSet As Data.DataSet
    Public DIASPP As Integer = 0
    Public Dscto As Integer = 0

    'mreyes 09/Febrero/2012 12:42 a.m.
    'Forma que busca en varias tablas, por lo general un id y descripción

    Private Sub TraerSucursales()
        'mreyes 15/Febrero/2012 05:16 p.m.
        Using objSucursal As New BCL.BCLPersis(IIf(Sw_Nomina = False, GLB_ConStringPerSis, GLB_ConStringNomSis))
            Try
                Me.Text = "Buscar Sucursal"

                objDataSet = objSucursal.usp_TraerSucursal("%" & Txt_Buscar.Text & "%")
                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TraerDepartamentos()
        'mreyes 05/Junio/2012 10:13 a.m.
        Using objDepto As New BCL.BCLCatalogoDeptos(GLB_ConStringNomSis)
            Try
                Me.Text = "Buscar Departamentos "

                If Txt_Buscar.Text.Length > 0 Then
                    objDataSet = objDepto.usp_PpalCatalogoDepto(0, "", "%" & Txt_Buscar.Text & "%")
                Else
                    objDataSet = objDepto.usp_PpalCatalogoDepto(0, "", "")
                End If

                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TraerPuestos()
        'mreyes 16/Junio/2012 11:07 a.m.
        Using objDepto As New BCL.BCLCatalogoPuestos(GLB_ConStringNomSis)
  
            Try
                Me.Text = "Buscar Puestos "

                If Txt_Buscar.Text.Length > 0 Then
                    objDataSet = objDepto.usp_PpalCatalogoPuesto(0, 0, "", "%" & Txt_Buscar.Text & "%")
                Else
                    objDataSet = objDepto.usp_PpalCatalogoPuesto(0, idDepto, "", "")
                End If

                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TraerFrecPago()
        'mreyes 16/Junio/2012 05:16 p.m.
        Using objDepto As New BCL.BCLCatalogoFrecPago(GLB_ConStringNomSis)
            Try
                Me.Text = "Buscar Frecuencia Pago "

                If Txt_Buscar.Text.Length > 0 Then
                    objDataSet = objDepto.usp_PpalCatalogoFrecPago("")
                Else
                    objDataSet = objDepto.usp_PpalCatalogoFrecPago("")
                End If

                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TraerPercDeduc()
        'mreyes 05/Junio/2012 10:13 a.m.
        Using objDepto As New BCL.BCLCatalogoPercDeduc(GLB_ConStringNomSis)
            Try
                Me.Text = "Buscar Percepciones/Deducciones "

                If Txt_Buscar.Text.Length > 0 Then
                    objDataSet = objDepto.usp_PpalCatalogoPercDeduc(0, "", "", "%" & Txt_Buscar.Text & "%", "", "", "", "", Sw_Tienda)
                Else
                    objDataSet = objDepto.usp_PpalCatalogoPercDeduc(0, "", "", "", "", "", "", "", Sw_Tienda)
                End If

                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub TraerDistribuidor()
        'mreyes 05/Junio/2012 10:13 a.m.
        Using objDepto As New BCL.BCLCreditoNuevo(GLB_ConStringCreditoSQL)
            Try
                Me.Text = "Buscar Distribuidor "

                If Txt_Buscar.Text.Length > 0 Then
                    objDataSet = objDepto.usp_TraerDistribuidorCredito(2, 0, Txt_Buscar.Text)
                Else
                    objDataSet = objDepto.usp_TraerDistribuidorCredito(1, 0, "")
                End If

                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Private Sub TraerAutorizacion()
        'mreyes 18/Agosto/2014  05:01 p.m.
        Using objDepto As New BCL.BCLMySqlGral(GLB_ConStringCredito)
            Try
                Me.Text = "Buscar Autorización "

                If Txt_Buscar.Text.Length > 0 Then
                    objDataSet = objDepto.usp_TraerAutorizacion(2, Txt_Buscar.Text, "")
                Else
                    objDataSet = objDepto.usp_TraerAutorizacion(2, "", "")
                End If

                'Populate the Project Details section
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Private Sub RellenaGrid()
        Dim SqlWhere As String = ""
        If Tipo = "DI" Then
            ' DEPARTAMENTOS 
            Call TraerDistribuidor()
            Exit Sub
        End If

        If Tipo = "S" Then
            Call TraerSucursales()
            Exit Sub
        End If

        If Tipo = "DE" Then
            ' DEPARTAMENTOS 
            Call TraerDepartamentos()
            Exit Sub
        End If

        If Tipo = "FP" Then
            ' DEPARTAMENTOS 
            Call TraerFrecPago()
            Exit Sub
        End If

        If Tipo = "PD" Then
            ' PERCDEDUC 
            Call TraerPercDeduc()
            Exit Sub
        End If

        If Tipo = "PU" Then
            ' PERCDEDUC 
            Call TraerPuestos()
            Exit Sub
        End If

        If Tipo = "AU" Then
            'AUTORIZACION
            Call TraerAutorizacion()
            Exit Sub
        End If

        Using objMySqlGral As New BCL.BCLMySqlGral(Glb_ConStringCipSis)
            Try

                If Txt_Buscar.Text.Length > 0 Then
                    SqlWhere = " WHERE     descrip LIKE '%" & Txt_Buscar.Text & "%'"
                End If

                If Tipo = "M" Then ''MARCA
                    If IdProveedorB <> 0 Then
                        SqlWhere = " WHERE idproveedor = " & IdProveedorB
                        SqlWhere = SqlWhere & " AND descrip LIKE '%" & Txt_Buscar.Text & "%'"
                        SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("MARCAP", SqlWhere)
                    Else
                        SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("MARCA", SqlWhere)
                    End If

                    Me.Text = "Buscar Marca"
                End If

                If Tipo = "F" Then ''FAMILIA
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("FAMILIA", SqlWhere)
                    Me.Text = "Buscar Familia"
                End If

                If Tipo = "L" Then ''LINEA
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("LINEA", SqlWhere)
                    Me.Text = "Buscar Línea"
                End If

                If Tipo = "TA" Then ''TIPO ARTICULO
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("TIPOART", SqlWhere)
                    Me.Text = "Buscar Tipo Artículo"
                End If

                If Tipo = "C" Then ''CATEGORIA
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("CATEGORIA", SqlWhere)
                    Me.Text = "Buscar Categoría"
                End If

                If Tipo = "E" Then ''ESTILO
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("ARTICULO", SqlWhere)
                    Me.Text = "Buscar Estilo"
                End If

                If Tipo = "P" Then ''PROVEEDOR
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = " WHERE     raz_soc LIKE '%" & Txt_Buscar.Text & "%'"
                    End If
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("PROVEEDOR", SqlWhere)
                    Me.Text = "Buscar Proveedor"
                End If

                If Tipo = "P1" Then ''PROVEEDOR
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = " WHERE     c.marca = '" & Txt_Buscar.Text & "'"
                    End If
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("PROVEEDOR1", SqlWhere)
                    Me.Text = "Buscar Proveedor"
                End If


                If Tipo = "LT" Then 'LETRAS 
                    SqlWhere = ""
                    SqlWhere = SqlWhere & " WHERE 1 = 1 "
                    If Campo1.Length > 0 Then
                        SqlWhere = SqlWhere & " AND  tipolet = '" & Campo1 & "'"
                    End If
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = SqlWhere & " AND     MEDIDA LIKE '%" & Txt_Buscar.Text & "%'"
                    End If
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("LETRAS ", SqlWhere)
                    Me.Text = "Buscar Letras"
                End If


                '' Nueva estructura

                If Tipo = "EDI" Then 'DIVISIONES
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = " WHERE     descrip LIKE '%" & Txt_Buscar.Text & "%'"
                    End If
                    SqlBuscar = objMySqlGral.ufn_TraeSqlBuscar("ESTDIVISIONES", SqlWhere)
                    Me.Text = "Buscar Division"
                End If


                If Tipo = "ED" Then 'DEPARTAMENTOS
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If

                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstDepto(0, IdSuperior1, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar Departamento"
                            GoTo continua
                        Else
                            Exit Sub
                        End If
                    End Using

                End If

                If Tipo = "EF" Then 'FAMILIA
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If

                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstFamilia(0, IdSuperior1, IdSuperior2, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar Familia"
                            GoTo continua
                        Else
                            Exit Sub
                        End If
                    End Using


                End If

                If Tipo = "EL" Then 'LINEA
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If

                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstLinea(0, IdSuperior1, IdSuperior2, IdSuperior3, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar Linea"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If

                    End Using
                End If

                If Tipo = "L1" Then 'L1
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If
                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstl1(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar L1"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "L2" Then 'L2
                    Opcion = 1
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If
                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstl2(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, _
                                                                        IdSuperior5, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar L2"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "L3" Then 'L3
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If
                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstl3(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, _
                                                                        IdSuperior5, IdSuperior6, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar L3"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "L4" Then 'L4
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If
                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstl4(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, _
                                                                        IdSuperior5, IdSuperior6, IdSuperior7, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar L4"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "L5" Then 'L5
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If
                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstl5(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, _
                                                                        IdSuperior5, IdSuperior6, IdSuperior7, IdSuperior8, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar L5"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "L6" Then 'L6
                    Opcion = 3
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                        Opcion = 3
                    End If
                    Using objEstilos As New BCL.BCLEstructura(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerEstl6(0, IdSuperior1, IdSuperior2, IdSuperior3, IdSuperior4, _
                                                                        IdSuperior5, IdSuperior6, IdSuperior7, IdSuperior8, IdSuperior9, "", Opcion, SqlWhere)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar L6"
                            GoTo continua
                        Else
                            blnVacio = True
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "ATM" Then 'MATERIALES
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                    End If
                    Using objEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerAtributos("M", Txt_Buscar.Text)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar Material"
                            GoTo continua
                        Else
                            Exit Sub
                        End If
                    End Using
                End If

                If Tipo = "ATC" Then 'COLORES
                    If Txt_Buscar.Text.Length > 0 Then
                        SqlWhere = Txt_Buscar.Text
                    End If
                    Using objEstilos As New BCL.BCLCatalogoModelos(GLB_ConStringCipSis)
                        objDataSet = objEstilos.usp_TraerAtributos("C", Txt_Buscar.Text)
                        If objDataSet.Tables(0).Rows.Count > 0 Then
                            Me.Text = "Buscar Color"
                            GoTo continua
                        Else
                            Exit Sub
                        End If
                    End Using
                End If

                objDataSet = objMySqlGral.usp_TraerUnCampo(SqlBuscar)
                'Populate the Project Details section
continua:
                DGrid.ReadOnly = True
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()


            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Sub InicializaGrid()
        DGrid.RowHeadersVisible = False
        ''DGrid.AllowUserToResizeColumns = True


        If Tipo = "AU" Then

            DGrid.Columns("idautorizacion").HeaderText = "idautorizacion"
            DGrid.Columns("Autorizacion").HeaderText = "Autorización"
  

        End If


        If Tipo = "DI" Then

            DGrid.Columns("iddistrib").HeaderText = "IdDistribuidor"
            DGrid.Columns("distrib").HeaderText = "Distrib"
            DGrid.Columns("nombrecompleto").HeaderText = "Nombre"
            'For i As Integer = 2 To DGrid.Columns.Count - 1
            '    DGrid.Columns(i).Visible = False
            'Next


        End If
        DGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        If Tipo = "PD" Then

            DGrid.Columns(0).HeaderText = "IdPercDeduc"
            DGrid.Columns(1).HeaderText = "Clave"
            DGrid.Columns(2).HeaderText = "Naturaleza"
            DGrid.Columns(3).HeaderText = "Descripción Corta "
            DGrid.Columns(4).HeaderText = "Descripción Larga"
            DGrid.Columns(5).HeaderText = "Activo"
            DGrid.Columns(0).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False

        End If

        If Tipo = "PU" Then

            DGrid.Columns(0).HeaderText = "IdPuesto"
            DGrid.Columns(1).HeaderText = "IdDepto"
            DGrid.Columns(2).HeaderText = "Clave Depto"
            DGrid.Columns(3).HeaderText = "Descripción Depto"
            DGrid.Columns(4).HeaderText = "Clave"
            DGrid.Columns(5).HeaderText = "Descripción"
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False


        End If

        If Tipo = "DE" Then
            DGrid.Columns(0).HeaderText = "IdDepto"
            DGrid.Columns(1).HeaderText = "Clave"
            DGrid.Columns(2).HeaderText = "Departamento"
            DGrid.Columns(0).Visible = False
        End If

        If Tipo = "FP" Then
            DGrid.Columns(0).HeaderText = "IdFrecPago"
            DGrid.Columns(1).HeaderText = "Clave"
            DGrid.Columns(2).HeaderText = "Descripción"
            DGrid.Columns(0).Visible = False
        End If


        '' NUEVA ESTRUCTURA

        If Tipo = "EDI" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).HeaderText = "Clave"
            DGrid.Columns(2).HeaderText = "Descripción"
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "ED" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).HeaderText = "Clave"
            DGrid.Columns(5).HeaderText = "Descripción"
            DGrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "EF" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).HeaderText = "Clave"
            DGrid.Columns(8).HeaderText = "Descripción"
            DGrid.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "EL" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).HeaderText = "Clave"
            DGrid.Columns(11).HeaderText = "Descripción"
            DGrid.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "L1" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).HeaderText = "Clave"
            DGrid.Columns(14).HeaderText = "Descripción"
            DGrid.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "L2" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).HeaderText = "Clave"
            DGrid.Columns(17).HeaderText = "Descripción"
            DGrid.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "L3" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False
            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).HeaderText = "Clave"
            DGrid.Columns(20).HeaderText = "Descripción"
            DGrid.Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "L4" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False
            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(20).Visible = False
            DGrid.Columns(21).Visible = False
            DGrid.Columns(22).HeaderText = "Clave"
            DGrid.Columns(23).HeaderText = "Descripción"
            DGrid.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "L5" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False
            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(20).Visible = False
            DGrid.Columns(21).Visible = False
            DGrid.Columns(22).Visible = False
            DGrid.Columns(23).Visible = False
            DGrid.Columns(24).Visible = False
            DGrid.Columns(25).HeaderText = "Clave"
            DGrid.Columns(26).HeaderText = "Descripción"
            DGrid.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(26).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "L6" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).Visible = False
            DGrid.Columns(2).Visible = False
            DGrid.Columns(3).Visible = False
            DGrid.Columns(4).Visible = False
            DGrid.Columns(5).Visible = False
            DGrid.Columns(6).Visible = False
            DGrid.Columns(7).Visible = False
            DGrid.Columns(8).Visible = False
            DGrid.Columns(9).Visible = False
            DGrid.Columns(10).Visible = False
            DGrid.Columns(11).Visible = False
            DGrid.Columns(12).Visible = False
            DGrid.Columns(13).Visible = False
            DGrid.Columns(14).Visible = False
            DGrid.Columns(15).Visible = False
            DGrid.Columns(16).Visible = False
            DGrid.Columns(17).Visible = False
            DGrid.Columns(18).Visible = False
            DGrid.Columns(19).Visible = False
            DGrid.Columns(20).Visible = False
            DGrid.Columns(21).Visible = False
            DGrid.Columns(22).Visible = False
            DGrid.Columns(23).Visible = False
            DGrid.Columns(24).Visible = False
            DGrid.Columns(25).Visible = False
            DGrid.Columns(26).Visible = False
            DGrid.Columns(27).Visible = False
            DGrid.Columns(28).HeaderText = "Clave"
            DGrid.Columns(29).HeaderText = "Descripción"
            DGrid.Columns(28).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGrid.Columns(29).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "ATM" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).HeaderText = "Descripción"
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If

        If Tipo = "ATC" Then
            DGrid.Columns(0).Visible = False
            DGrid.Columns(1).HeaderText = "Descripción"
            DGrid.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub frmConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GLB_FormConsulta = False
    End Sub

    Private Sub frmConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            GLB_FormConsulta = True
            Me.Close()
        End If
    End Sub

    Private Sub frmConsulta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            blnConsultoDistrib = False
            GLB_FormConsulta = True
            Call RellenaGrid()
            If blnVacio = True Then
                Me.Dispose()
                Me.Close()
            End If
            Call GenerarToolTip()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try

    End Sub

    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Excel, "Exportar a Excel")
            ToolTip.SetToolTip(Txt_Buscar, "Escriba lo que pretende buscar")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Txt_Buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Buscar.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_Buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Buscar.TextChanged
        Try
            Call RellenaGrid()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellDoubleClick


    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DGrid.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(0).Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(1).Value.ToString.Trim()
                If Tipo = "P1" Then
                    DIASPP = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Plazo").Value.ToString.Trim
                    Dscto = DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto").Value.ToString.Trim
                End If

                If Tipo = "DI" Then
                    ' Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("cobrador").Value.ToString.Trim
                    blnConsultoDistrib = True
                End If
                If Tipo = "DE" Or Tipo = "FP" Then
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells(2).Value.ToString.Trim()
                End If
                If Tipo = "PD" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descripc").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idpercdeduc").Value.ToString.Trim()
                End If
                If Tipo = "PU" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idpuesto").Value.ToString.Trim()
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clavepuesto").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descripPUESTO").Value.ToString.Trim()
                End If


                ''Nueva Estructura
                If Tipo = "EDI" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("iddivision").Value.ToString.Trim()
                    IdSuperior1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("iddivision").Value.ToString.Trim()
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "ED" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("iddepto").Value.ToString.Trim()
                    IdSuperior2 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "EF" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idfamilia").Value.ToString.Trim()
                    IdSuperior3 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "EL" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idlinea").Value.ToString.Trim()
                    IdSuperior4 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "L1" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl1").Value.ToString.Trim()
                    IdSuperior5 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "L2" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl2").Value.ToString.Trim()
                    IdSuperior6 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "L3" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl3").Value.ToString.Trim()
                    IdSuperior7 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "L4" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl4").Value.ToString.Trim()
                    IdSuperior8 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "L5" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl5").Value.ToString.Trim()
                    IdSuperior9 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "L6" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idl6").Value.ToString.Trim()
                    IdSuperior10 = Campo
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("clave").Value.ToString.Trim()
                    Campo2 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "ATM" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idatributo").Value.ToString.Trim()
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                If Tipo = "ATC" Then
                    Campo = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("idatributo").Value.ToString.Trim()
                    Campo1 = DGrid.Rows(DGrid.CurrentRow.Index - 1).Cells("descrip").Value.ToString.Trim()
                End If

                Me.Close()
                Me.Dispose()
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excel.Click
        Try
            If ExportarDGridAExcel(DGrid) = False Then
                MsgBox("Error al exportar a Excel. Intente nuevamente.", MsgBoxStyle.Critical, "Excel")
            End If
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGrid.DoubleClick
        Try
            Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells(0).Value.ToString.Trim()
            Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells(1).Value.ToString.Trim()

            If Tipo = "P1" Then
                DIASPP = DGrid.Rows(DGrid.CurrentRow.Index).Cells("Plazo").Value.ToString.Trim
                Dscto = DGrid.Rows(DGrid.CurrentRow.Index).Cells("dscto").Value.ToString.Trim
            End If
            If Tipo = "DI" Then
                '   Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("cobrador").Value.ToString.Trim
                blnConsultoDistrib = True
            End If
            If Tipo = "DE" Or Tipo = "FP" Then
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells(2).Value.ToString.Trim()
            End If
            If Tipo = "PD" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripc").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idpercdeduc").Value.ToString.Trim()
            End If
            If Tipo = "PU" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idpuesto").Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clavepuesto").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descripPUESTO").Value.ToString.Trim()
            End If


            ''Nueva Estructura
            If Tipo = "EDI" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("iddivision").Value.ToString.Trim()
                IdSuperior1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("iddivision").Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "ED" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("iddepto").Value.ToString.Trim()
                IdSuperior2 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "EF" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idfamilia").Value.ToString.Trim()
                IdSuperior3 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "EL" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idlinea").Value.ToString.Trim()
                IdSuperior4 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "L1" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl1").Value.ToString.Trim()
                IdSuperior5 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "L2" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl2").Value.ToString.Trim()
                IdSuperior6 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "L3" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl3").Value.ToString.Trim()
                IdSuperior7 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "L4" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl4").Value.ToString.Trim()
                IdSuperior8 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "L5" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl5").Value.ToString.Trim()
                IdSuperior9 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "L6" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idl6").Value.ToString.Trim()
                IdSuperior10 = Campo
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("clave").Value.ToString.Trim()
                Campo2 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "ATM" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idatributo").Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            If Tipo = "ATC" Then
                Campo = DGrid.Rows(DGrid.CurrentRow.Index).Cells("idatributo").Value.ToString.Trim()
                Campo1 = DGrid.Rows(DGrid.CurrentRow.Index).Cells("descrip").Value.ToString.Trim()
            End If

            Me.Close()
            Me.Dispose()

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid.CellContentClick

    End Sub

    Private Sub Pnl_Edicion_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl_Edicion.Paint

    End Sub
End Class