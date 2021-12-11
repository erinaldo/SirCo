Module ModCombo
    'mreyes 17/Febrero/2012 02:11 p.m.
    Public Function rellenalComboPerioricidad()
        ''
        Using objCatalogo As New BCL.BCLTipoCredito(GLB_ConStringSircoControlSQL)
            Dim ObjDataset As Data.DataSet
            ObjDataset = objCatalogo.usp_TraerPeriodicidad()
            Return ObjDataset
        End Using
    End Function
    Public Sub RellenaCombo(ByVal Combo As System.Windows.Forms.ComboBox, ByVal Sql As String, ByVal StringConexion As String, ByVal Sw_Limpiar As Boolean)
        'mreyes 17/Febrero/2012 01:38 p.m.
        Using objMySqlGral As New BCL.BCLMySqlGral(StringConexion)
            Try
                Dim ObjDataSet As Data.DataSet

                ObjDataSet = objMySqlGral.usp_TraerUnCampo(Sql)
                'Populate the Project Details section
                Combo.AutoCompleteMode = AutoCompleteMode.Suggest
                Combo.AutoCompleteSource = AutoCompleteSource.ListItems

                Combo.DataSource = Nothing

                Combo.DataSource = ObjDataSet.Tables(0)
                Combo.DisplayMember = ObjDataSet.Tables(0).Columns(0).Caption.ToString
                If Sw_Limpiar = True Then
                    Combo.Text = ""

                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Public Sub RellenaCombos(ByVal Combo As ComboBox, ByVal Opcion As String, ByVal SqlWhere As String, ByVal StringConexion As String, ByVal Sw_Limpiar As Boolean)
        Using objMySqlGral As New BCL.BCLMySqlGral(StringConexion)
            Try
                Dim ObjDataSet As Data.DataSet
                Dim SqlBuscar As String
                SqlBuscar = ""

                ObjDataSet = objMySqlGral.ufn_RellenaCombo(Opcion, SqlWhere)

                If ObjDataSet.Tables(0).Rows.Count > 0 Then
                    SqlBuscar = ObjDataSet.Tables(0).Rows(0).Item(0).ToString
                    Call RellenaCombo(Combo, SqlBuscar, StringConexion, Sw_Limpiar)

                End If



            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using



    End Sub


    Public Sub RellenaPeriodoNom(ByVal Combo As System.Windows.Forms.ComboBox, ByVal IdFrecPago As Integer, ByVal Sw_Limpiar As Boolean)
        'mreyes 05/Julio/2012 10:27 a.m.
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try
                Dim ObjDataSet As Data.DataSet

                ObjDataSet = objMySqlGral.usp_ComboPeriodo(IdFrecPago)
                'Populate the Project Details section
                Combo.AutoCompleteMode = AutoCompleteMode.Suggest
                Combo.AutoCompleteSource = AutoCompleteSource.ListItems

                Combo.DataSource = Nothing


                'Combo.DisplayMember = ObjDataSet.Tables(0).Rows(0).Item("periodo").ToString
                'Combo.ValueMember = ObjDataSet.Tables(0).Rows(0).Item("idperiodo").ToString
                Combo.DataSource = ObjDataSet.Tables(0)
                Combo.DisplayMember = "periodo" ' ObjDataSet.Tables(0).Columns(1).ColumnName ' .Caption.ToString
                Combo.ValueMember = "periodo" ' ObjDataSet.Tables(0).Columns(0).ColumnName


                If Sw_Limpiar = True Then
                    Combo.Text = ""
                    Using objMySqlGral1 As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
                        Try
                            Dim ObjDataSet1 As Data.DataSet

                            ObjDataSet1 = objMySqlGral1.usp_TraerUltimoPeriodo(IdFrecPago, "", 0)
                            If ObjDataSet1.Tables(0).Rows.Count > 0 Then
                                Combo.DisplayMember = ObjDataSet1.Tables(0).Rows(0).Item("periodo").ToString
                                Combo.ValueMember = ObjDataSet.Tables(0).Columns("idperiodo").Caption.ToString
                                Combo.Text = Combo.ValueMember = ObjDataSet.Tables(0).Columns("periodo").Caption.ToString
                            End If

                        Catch ExceptionErr As Exception
                            MessageBox.Show(ExceptionErr.Message.ToString)
                        End Try
                    End Using
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Public Function pub_TraerUltimoPeriodo(ByVal IdFrecPago As Integer, ByVal Estatus As String) As String
        'mreyes 05/Julio/2012 10:27 a.m.
        Using objMySqlGral As New BCL.BCLMySqlGral(GLB_ConStringNomSis)
            Try
                Dim ObjDataSet As Data.DataSet

                ObjDataSet = objMySqlGral.usp_TraerUltimoPeriodo(IdFrecPago, Estatus, 0)
                If ObjDataSet.Tables(0).Rows.Count > 0 Then
                    pub_TraerUltimoPeriodo = ObjDataSet.Tables(0).Rows(0).Item("idperiodo").ToString
                End If

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Function


    Public Sub usp_TraerCPEstadoCiudadColonia(Combo As ComboBox, Opcion As Integer, CodigoPostal As String, IdEstado As Integer, IdCiudad As Integer, IdColonia As Integer)
        'mreyes 09/Febrero/2018 04:54 p.m.

        Dim objDataSet As Data.DataSet
        Using objMySqlGral As New BCL.BCLCreditoNuevo(GLB_ConStringSircoControlSQL)
            Try
                objDataSet = objMySqlGral.usp_TraerCPEstadoCiudadColonia(Opcion, CodigoPostal, IdEstado, IdCiudad, IdColonia)

                Combo.DataSource = objDataSet.Tables(0)
                Combo.DisplayMember = objDataSet.Tables(0).Columns(1).Caption.ToString()
                Combo.ValueMember = objDataSet.Tables(0).Columns(0).Caption.ToString()

            Catch ExceptionErr As Exception
                'MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Public Sub usp_TraerColores(Combo As ComboBox, Opcion As Integer)
        'mreyes 20/Marzo/2018 05:25 p.m.

        Dim objDataSet As Data.DataSet
        Using objMySqlGral As New BCL.BCLVentaEnLinea(GLB_ConStringSircoControlSQL)
            Try
                objDataSet = objMySqlGral.usp_TraerColores(Opcion)

                Combo.DataSource = objDataSet.Tables(0)
                Combo.DisplayMember = objDataSet.Tables(0).Columns(1).Caption.ToString()
                Combo.ValueMember = objDataSet.Tables(0).Columns(0).Caption.ToString()

            Catch ExceptionErr As Exception
                'MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Public Sub usp_TraerColoresDevexpress(Combo As DevExpress.XtraEditors.ListBoxControl, Opcion As Integer)
        'mreyes 20/Marzo/2018 05:25 p.m.

        Dim objDataSet As Data.DataSet
        Using objMySqlGral As New BCL.BCLVentaEnLinea(GLB_ConStringSircoControlSQL)
            Try
                objDataSet = objMySqlGral.usp_TraerColores(Opcion)

                Combo.DataSource = objDataSet.Tables(0)
                Combo.DisplayMember = objDataSet.Tables(0).Columns(1).Caption.ToString()
                Combo.ValueMember = objDataSet.Tables(0).Columns(0).Caption.ToString()

            Catch ExceptionErr As Exception
                'MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

    Public Sub usp_TraerMaterialDevexpress(Combo As DevExpress.XtraEditors.ListBoxControl, Opcion As Integer)
        'mreyes 20/Marzo/2018 05:31 p.m.

        Dim objDataSet As Data.DataSet
        Using objMySqlGral As New BCL.BCLVentaEnLinea(GLB_ConStringSircoControlSQL)
            Try
                objDataSet = objMySqlGral.usp_TraerMaterial(Opcion)

                Combo.DataSource = objDataSet.Tables(0)
                Combo.DisplayMember = objDataSet.Tables(0).Columns(1).Caption.ToString()
                Combo.ValueMember = objDataSet.Tables(0).Columns(0).Caption.ToString()

            Catch ExceptionErr As Exception
                'MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub

End Module
