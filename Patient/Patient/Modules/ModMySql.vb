Module ModMySql
    'mreyes 15/Febrero/2012 04:46 p.m.
    Private objDataSet As Data.DataSet

    Public Function fn_TraerFolioOrdeComp(ByVal Opcion As Integer, ByVal Sucursal As String, ByVal MasSerie As Integer) As Integer
        'mreyes 15/Febrero/2012 04:49 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringPerSis)
            Try


                objDataSet = objPedidos.fn_FolioOrdeComp(Opcion, Trim(Sucursal), MasSerie)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    If Opcion = 1 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("ordecomp").ToString + 1
                    ElseIf Opcion = -1 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("ordecompresaut").ToString + 1
                    ElseIf Opcion = 3 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("factprov").ToString + 1
                    ElseIf Opcion = 5 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("serie").ToString + 1
                    ElseIf Opcion = 7 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("devoprov").ToString + 1
                    ElseIf Opcion = 10 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("invfis").ToString + 1
                    ElseIf Opcion = 11 Then
                        fn_TraerFolioOrdeComp = objDataSet.Tables(0).Rows(0).Item("bodega").ToString + 1
                    End If
                Else
                    fn_TraerFolioOrdeComp = 1
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function pub_TraerNomSucursal(ByVal Sucursal As String) As String
        'mreyes 21/Junio/2012 12:27 p.m.
        Using objPedidos As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try


                objDataSet = objPedidos.usp_TraerNomSucursal(Sucursal)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    pub_TraerNomSucursal = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                Else
                    pub_TraerNomSucursal = ""
                End If
            Catch ExceptionErr As Exception
                pub_TraerNomSucursal = ""
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function usp_TraerTotalPercDeduc(ByVal IdPeriodo As Integer, ByVal TipoNom As String, _
                 ByVal IdEmpleado As Integer, ByRef Deduccion As Decimal, ByRef Percepcion As Decimal) As Boolean
        'mreyes 11/Septiembre/2012 04:08 p.m.
        Using obj As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim Entro As Boolean = False
                objDataSet = obj.usp_TraerTotalPercDeduc(IdPeriodo, TipoNom, IdEmpleado)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    Entro = True
                    Deduccion = Val(objDataSet.Tables(0).Rows(0).Item("deduccion").ToString)
                    Percepcion = Val(objDataSet.Tables(0).Rows(0).Item("percepcion").ToString)
                Else
                    usp_TraerTotalPercDeduc = 0.0
                End If
                usp_TraerTotalPercDeduc = True
            Catch ExceptionErr As Exception
                usp_TraerTotalPercDeduc = 0
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    
    Public Function pub_TraerFechaHoy() As Date
        'mreye s09/Septiembre/2012 12:32 p.m.
        Using objPedidos As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try

                Dim Fecha As Date = "1900-01-01"

                objDataSet = objPedidos.usp_TraerFechaHoy()

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Fecha = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                Else
                    Fecha = "1900-01-01"
                End If
                pub_TraerFechaHoy = Fecha
            Catch ExceptionErr As Exception
                pub_TraerFechaHoy = "1900-01-01"
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Public Function pub_TraerUltoPrimDiaMes(ByVal Opcion As Integer, ByVal FechaB As Date) As Date
        'mreyes 09/Septiembre/2012 01:55 p.m.
        Using obj As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try

                Dim Fecha As Date = "1900-01-01"

                objDataSet = obj.pub_TraerUltoPrimDiaMes(Opcion, FechaB)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Fecha = objDataSet.Tables(0).Rows(0).Item("fecha").ToString
                Else
                    Fecha = "1900-01-01"
                End If
                pub_TraerUltoPrimDiaMes = Fecha
            Catch ExceptionErr As Exception
                pub_TraerUltoPrimDiaMes = "1900-01-01"
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Public Function pub_TraerNomSucursalNOMINA(ByVal Sucursal As String) As String
        'mreyes 09/Septiembre/2012 10:31 a.m.
        Using obj As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try


                objDataSet = obj.usp_TraerNomSucursal(Sucursal)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    pub_TraerNomSucursalNOMINA = objDataSet.Tables(0).Rows(0).Item("descrip").ToString
                Else
                    pub_TraerNomSucursalNOMINA = ""
                End If
            Catch ExceptionErr As Exception
                pub_TraerNomSucursalNOMINA = ""
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function pub_TraerClaveSucursal(ByVal DescripSucursal As String) As String
        'mreyes 22/Julio/2012 12:39 p.m.
        Using objPedidos As New BCL.BCLPersis(GLB_ConStringPerSis)
            Try


                objDataSet = objPedidos.usp_TraerSucursal(DescripSucursal)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    pub_TraerClaveSucursal = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                Else
                    pub_TraerClaveSucursal = ""
                End If
            Catch ExceptionErr As Exception
                pub_TraerClaveSucursal = ""
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function pub_TraerClaveSucursalNomina(ByVal DescripSucursal As String) As String
        'mreyes 22/Julio/2012 12:39 p.m.
        Using objPedidos As New BCL.BCLPersis(GLB_ConStringNomSis)
            Try


                objDataSet = objPedidos.usp_TraerSucursal(DescripSucursal)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    pub_TraerClaveSucursalNomina = objDataSet.Tables(0).Rows(0).Item("sucursal").ToString
                Else
                    pub_TraerClaveSucursalNomina = ""
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
                pub_TraerClaveSucursalNomina = ""
            End Try
        End Using
    End Function
    Public Function pub_TraerConsecutivoEmp(ByVal Sucursal As String) As String
        'mreyes 22/Julio/2012 01:00 p.m.
        Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Consecutivo As String = ""
                objDataSet = objPedidos.usp_ConsecutivoEmp(Sucursal)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Consecutivo = objDataSet.Tables(0).Rows(0).Item("consecutivo").ToString
                Else
                    Consecutivo = "1"
                End If
                If Consecutivo = "" Then
                    Consecutivo = "1"
                End If
                pub_TraerConsecutivoEmp = pub_RellenarIzquierda(Consecutivo, 4)
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function pub_TraerIdEmpleado(ByVal Sucursal As String, ByVal Vendedor As String) As Integer
        'mreyes 18/AGosto/2012 02:23 p.m.
        Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Consecutivo As Integer = 0
                objDataSet = objPedidos.usp_TraerIDEmpleado(Sucursal, Vendedor)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Consecutivo = objDataSet.Tables(0).Rows(0).Item("idempleado").ToString
                End If
                pub_TraerIdEmpleado = Consecutivo
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function pub_TraerCajero(Cajero As String) As Integer
        'mreyes 14/Junio/2018 04:12 p.m.
        Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Consecutivo As Integer = 0
                objDataSet = objPedidos.usp_TraerCajero(Cajero)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Consecutivo = objDataSet.Tables(0).Rows(0).Item("idempleado").ToString
                End If
                pub_TraerCajero = Consecutivo
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function usp_TraerNomEmpleado(ByVal IdEmpleado As Integer, ByVal IdDepto As Integer) As String
        'mreyes 18/AGosto/2012 02:23 p.m.
        Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Consecutivo As String = ""
                objDataSet = objPedidos.usp_TraerNomEmpleado(IdEmpleado, "", "", "", "", IdDepto)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Consecutivo = objDataSet.Tables(0).Rows(0).Item("nomcompleto").ToString
                End If
                usp_TraerNomEmpleado = Consecutivo
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
                usp_TraerNomEmpleado = ""
            End Try
        End Using
    End Function

    Public Function pub_TraerEncargadoTienda(ByVal Sucursal As String) As Integer
        'mreyes 30/Agosto/2012 06:16 p.m.
        Using objPedidos As New BCL.BCLNomina(GLB_ConStringNomSis)
            Try
                Dim objDataSet As Data.DataSet
                Dim Consecutivo As Integer = 0
                objDataSet = objPedidos.usp_TraerEncargadoTienda(Sucursal)

                If objDataSet.Tables(0).Rows.Count > 0 Then

                    Consecutivo = objDataSet.Tables(0).Rows(0).Item("idempleado").ToString
                End If
                pub_TraerEncargadoTienda = Consecutivo
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function fn_TraerFolioFactProv(ByVal Sucursal) As Integer
        'mreyes 22/Mayo/2012 04:15 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringPerSis)
            Try
                'El valor de 3 y 4 es para facturas

                objDataSet = objPedidos.fn_FolioOrdeComp(3, Sucursal, 1)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    fn_TraerFolioFactProv = objDataSet.Tables(0).Rows(0).Item("factprov").ToString + 1
                Else
                    fn_TraerFolioFactProv = 1
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Public Function fn_TraerFolioCambPrec(ByVal Sucursal) As Integer
        'mreyes 15/Febrero/2012 04:49 p.m.
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringPerSis)
            Try


                objDataSet = objPedidos.fn_FolioOrdeComp(1, Sucursal, 1)

                If objDataSet.Tables(0).Rows.Count > 0 Then
                    fn_TraerFolioCambPrec = objDataSet.Tables(0).Rows(0).Item("cambprec").ToString + 1
                Else
                    fn_TraerFolioCambPrec = 1
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Public Function Actualiza_FolioOrdeComp(ByVal Opcion As Integer, ByVal sucursal As String, ByVal MasSerie As Integer) As Boolean
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringPerSis)
            'Get a new Project DataSet
            Try
                objDataSet = objPedidos.Actualiza_FolioOrdeComp  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow

                objDataRow.Item("sucursal") = Trim(sucursal)

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_FolioOrdeComp(Opcion, objDataSet, MasSerie) Then
                    Throw New Exception("Falló Actualizar folio de orden de compra")
                Else
                    Actualiza_FolioOrdeComp = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Public Function Actualiza_FolioCambPrec(ByVal sucursal As String) As Boolean
        Using objPedidos As New BCL.BCLPedidos(GLB_ConStringPerSis)
            'Get a new Project DataSet
            Try
                objDataSet = objPedidos.Actualiza_FolioCambPrec  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Set the values in the DataRow
                objDataRow.Item("sucursal") = Trim(sucursal)
                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objPedidos.usp_Foliocambprec(2, objDataSet) Then
                    Throw New Exception("Falló Actualizar folio de orden de compra")
                Else
                    Actualiza_FolioCambPrec = True
                End If
            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function

    Public Function pub_TienePermiso(ByVal Programa As String, Optional ByVal Sw_Mensaje As Boolean = True) As Boolean
        'mreyes 13/Marzo/2012 04:45 p.m.
        Try
            Dim FechaPc As Date = "1900-01-01"
            Dim usp_capturaTipoVivienda As Boolean
            'pub_TienePermiso = True
            'Exit Function

            Using objCaptura As New BCL.BCLTipoVivienda(GLB_ConStringSircoControlSQL)

                Try

                    usp_capturaTipoVivienda = objCaptura.usp_CapturaAccesos(GLB_Idempleado, GLB_Usuario, Programa, GLB_Ip)


                Catch ExceptionErr As Exception

                End Try

            End Using




            GLB_FechaHoy = pub_TraerFechaHoy()
            FechaPc = Date.Today
            If GLB_FechaHoy = "1900-01-01" Then
                MsgBox("Error al validar Fecha del Servidor. Reporte a Sistemas.", MsgBoxStyle.Critical, "Aviso")
                End
            End If
            If FechaPc <> GLB_FechaHoy Then
                MsgBox("La fecha de su PC no coincide con la fecha del servidor, no puede acceder al sistema.", MsgBoxStyle.Critical, "Aviso")
                End
            End If

            If GLB_Usuario = "SISTEMAS" Or GLB_Usuario = "RESM1979" Or GLB_Usuario = "MREYES" Or GLB_Usuario = "FELIX" Or GLB_Usuario = "FELIXJ" Or GLB_Usuario = "MEOR1955" Or GLB_Usuario = "LORIS" Then pub_TienePermiso = True : Exit Function
            Dim ObjDataset As Data.DataSet
            Using objPermisos As New BCL.BCLPersis(GLB_ConStringPerSis)
                ObjDataset = objPermisos.usp_TraerPermiso(GLB_Usuario, Programa)
                If ObjDataset.Tables(0).Rows.Count > 0 Then
                    If ObjDataset.Tables(0).Rows(0).Item(0) = "" Then
                        pub_TienePermiso = False
                        If Sw_Mensaje = True Then
                            MsgBox("No tiene permiso para entrar a la opción.", MsgBoxStyle.Critical, "Permisos")
                        End If
                        Exit Function
                    End If
                Else
                    pub_TienePermiso = False
                    If Sw_Mensaje = True Then
                        MsgBox("No tiene permiso para entrar a la opción.", MsgBoxStyle.Critical, "Permisos")
                    End If
                    Exit Function
                End If
                pub_TienePermiso = True

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function

    Public Function pub_TienePermisoProceso(ByVal Programa As String, ByVal Proceso As String, ByVal Password As String, ByVal Sw_Mensaje As Boolean) As Boolean
        'mreyes 13/Marzo/2012 05:20 p.m.
        Try
            GLB_Programa = Programa
            GLB_Proceso = Proceso
            If GLB_Usuario = "RESM1979" Then pub_TienePermisoProceso = True : Exit Function

            Dim ObjDataset As Data.DataSet
            Using objPermisos As New BCL.BCLPersis(GLB_ConStringPerSis)
                ObjDataset = objPermisos.usp_TraerPermisoProceso(GLB_Usuario, Programa, Proceso, Password)
                If ObjDataset.Tables(0).Rows.Count > 0 Then
                    If ObjDataset.Tables(0).Rows(0).Item(0) = "" Then
                        pub_TienePermisoProceso = False
                        If Sw_Mensaje = True Then
                            MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
                        End If
                        Exit Function
                    End If
                Else
                    pub_TienePermisoProceso = False
                    If Sw_Mensaje = True Then
                        MsgBox("No tiene permiso para realizar este proceso.", MsgBoxStyle.Critical, "Permisos")
                    End If
                    Exit Function
                End If
                    pub_TienePermisoProceso = True

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Function


    Public Function pub_TraerParame_Det(ByVal Clave) As String
        'mreyes 23/Marzo/2012 10:14 p.m.
        Try
            Dim objDataSet As Data.DataSet
            pub_TraerParame_Det = ""
            Using objParame_Det As New BCL.BCLMySqlGral(GLB_ConStringCipSis)
                objDataSet = objParame_Det.usp_TraerParame_Det(Clave)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    pub_TraerParame_Det = objDataSet.Tables(0).Rows(0).Item("valor").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            pub_TraerParame_Det = ""
        End Try
    End Function


    Public Function Inserta_VentaNomina(ByVal objDataSetE As Data.DataSet, ByVal I As Integer) As Boolean
        'mreyes 18/Agosto/2012 01:10 p.m.

        Dim Clave As String = ""
        Dim objDataSet As Data.DataSet
        Dim ClaveSuc As String = ""
        Dim IdEmpleado As Integer
        Using objCatalogo As New BCL.BCLNomina(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogo.Inserta_Venta  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                IdEmpleado = pub_TraerIdEmpleado(objDataSetE.Tables(0).Rows(I).Item("sucursal"), objDataSetE.Tables(0).Rows(I).Item("vendedor"))
                If IdEmpleado = 0 Then
                    '' pueden ser prestamos 
                    IdEmpleado = pub_TraerIdEmpleado("", objDataSetE.Tables(0).Rows(I).Item("vendedor"))

                    If IdEmpleado = 0 Then
                        IdEmpleado = pub_TraerEncargadoTienda(objDataSetE.Tables(0).Rows(I).Item("sucursal"))
                        If IdEmpleado = 0 Then
                            IdEmpleado = 132
                        End If
                    End If
                End If
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Falta definir extras en base a departamento

                objDataRow.Item("fecha") = objDataSetE.Tables(0).Rows(I).Item("fecha")
                objDataRow.Item("sucursal") = objDataSetE.Tables(0).Rows(I).Item("sucursal")
                objDataRow.Item("idempleado") = IdEmpleado
                objDataRow.Item("vendedor") = objDataSetE.Tables(0).Rows(I).Item("vendedor")
                objDataRow.Item("tipoart") = objDataSetE.Tables(0).Rows(I).Item("tipoart")
                objDataRow.Item("pares") = objDataSetE.Tables(0).Rows(I).Item("pares")
                objDataRow.Item("impvta") = objDataSetE.Tables(0).Rows(I).Item("impvta")
                objDataRow.Item("usuario") = GLB_Usuario

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogo.usp_Captura_Venta(objDataSet) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_VentaNomina = True
                End If



            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Public Function Inserta_VentaNominaCajero(ByVal objDataSetE As Data.DataSet, ByVal I As Integer) As Boolean
        'mreyes 14/Junio/2018  04:09 p.m.

        Dim Clave As String = ""
        Dim objDataSet As Data.DataSet
        Dim ClaveSuc As String = ""
        Dim IdEmpleado As Integer
        Using objCatalogo As New BCL.BCLNomina(GLB_ConStringNomSis)
            'Get a new Project DataSet
            Try
                objDataSet = objCatalogo.Inserta_VentaCajero  'INSERTA NUEVO DATASET
                'Initialize a datarow object from the Project DataSet
                IdEmpleado = pub_TraerCajero(objDataSetE.Tables(0).Rows(I).Item("cajero"))
                If IdEmpleado = 0 Then

                    IdEmpleado = 132

                End If
                Dim objDataRow As Data.DataRow = objDataSet.Tables(0).NewRow

                'Falta definir extras en base a departamento

                objDataRow.Item("fecha") = objDataSetE.Tables(0).Rows(I).Item("fecha")
                objDataRow.Item("sucursal") = objDataSetE.Tables(0).Rows(I).Item("sucursal")
                objDataRow.Item("idempleado") = IdEmpleado
                objDataRow.Item("cajero") = objDataSetE.Tables(0).Rows(I).Item("cajero")
                objDataRow.Item("tipoart") = objDataSetE.Tables(0).Rows(I).Item("tipoart")
                objDataRow.Item("pares") = objDataSetE.Tables(0).Rows(I).Item("pares")
                objDataRow.Item("impvta") = objDataSetE.Tables(0).Rows(I).Item("impvta")
                objDataRow.Item("usuario") = GLB_Usuario

                'Add the DataRow to the DataSet
                objDataSet.Tables(0).Rows.Add(objDataRow)

                'Add the Project
                If Not objCatalogo.usp_Captura_VentaCajero(objDataSet) Then
                    'Throw New Exception("Falló Inserción de Proveedor")
                Else
                    Inserta_VentaNominaCajero = True
                End If



            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function
    Public Function usp_TraerFolioEntrada(ByVal IdFolioSuc As String) As String
        'mreyes 28/Julio/2015   10:27 a.m.
        Try
            Dim objDataSet As Data.DataSet
            usp_TraerFolioEntrada = ""
            Using objParame_Det As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objParame_Det.usp_TraerFolioEntrada(IdFolioSuc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    usp_TraerFolioEntrada = objDataSet.Tables(0).Rows(0).Item("factprov").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            usp_TraerFolioEntrada = 0
        End Try
    End Function


    Public Function usp_TraerFolioDevoProv(ByVal IdFolioSuc As String) As String
        'mreyes 28/Julio/2015   10:27 a.m.
        Try
            Dim objDataSet As Data.DataSet
            usp_TraerFolioDevoProv = ""
            Using objParame_Det As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objParame_Det.usp_TraerFolioDevoProv(IdFolioSuc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    usp_TraerFolioDevoProv = objDataSet.Tables(0).Rows(0).Item("devoprov").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            usp_TraerFolioDevoProv = 0
        End Try
    End Function


    Public Function usp_TraerIdFolioSucBulto(ByVal IdFolioSuc As String) As String
        'mreyes 25/Junio/2013 01:03 p.m.
        Try
            Dim objDataSet As Data.DataSet
            usp_TraerIdFolioSucBulto = ""
            Using objParame_Det As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objParame_Det.usp_TraerIdFolioSucBulto(IdFolioSuc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    usp_TraerIdFolioSucBulto = objDataSet.Tables(0).Rows(0).Item("idfoliosuc").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            usp_TraerIdFolioSucBulto = 0
        End Try
    End Function

    Public Function pub_TraerIdFolioBulto(ByVal IdFolioSuc As String) As Integer
        'mreyes 25/Junio/2013 01:03 p.m.
        Try
            Dim objDataSet As Data.DataSet
            pub_TraerIdFolioBulto = 0
            Using objParame_Det As New BCL.BCLBulto(GLB_ConStringCipSis)
                objDataSet = objParame_Det.pub_TraerIdFolioBulto(IdFolioSuc)
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    pub_TraerIdFolioBulto = objDataSet.Tables(0).Rows(0).Item("idfolio").ToString
                End If

            End Using
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
            pub_TraerIdFolioBulto = 0
        End Try
    End Function

End Module
