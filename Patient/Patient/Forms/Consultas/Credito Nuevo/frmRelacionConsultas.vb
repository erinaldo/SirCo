Public Class frmRelacionConsultas

    Dim objDataSet As Data.DataSet
    Public Tipo As String
    Public iddistrib As Integer
    Public Sw_Nomina As Boolean = False

    Private Sub frmRelacionConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        GLB_FormConsulta = True
        Call RellenaGrid()
    End Sub


    Private Sub TraerDistribuidor()
        'vgallegos 7-Febrero-2018
        Using objDistrib As New BCL.BCLRelacionSQL(GLB_ConStringCreditoSQL)
            Try
                Me.Text = "Buscar Distribuidor"

                objDataSet = objDistrib.usp_TraerDistrib("%" & TxtBuscar.Text & "%")
                DGrid.DataSource = Nothing
                DGrid.DataSource = objDataSet.Tables(0)

                InicializaGrid()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End Using
    End Sub


    Sub InicializaGrid()

        If Tipo = "D" Then
            Try
                GridView1.Columns("iddistrib").Caption = "idDistrib"
                GridView1.Columns("tipodistrib").Caption = "Tipo Distribuidor"
                GridView1.Columns("distrib").Caption = "Folio Distribuidor"
                GridView1.Columns("idpromotor").Caption = "idPromotor"
                GridView1.Columns("idcoordinador").Caption = "idCoordinador"
                GridView1.Columns("idtienda").Caption = "idTienda"
                GridView1.Columns("nombrecompleto").Caption = "Nombre Completo"
                GridView1.Columns("idtipocredito").Caption = "idTipoCredito"
                GridView1.Columns("tipocredito").Caption = "Tipo de Crédito"
                GridView1.Columns("idperiodicidad").Caption = "idPeriodicidad"
                GridView1.Columns("periodicidad").Caption = "Periodicidad"
                GridView1.Columns("nombre").Caption = "Nombre"
                GridView1.Columns("appaterno").Caption = "Apellido Paterno"
                GridView1.Columns("apmaterno").Caption = "Apellido Materno"
                GridView1.Columns("sexo").Caption = "Sexo"
                GridView1.Columns("fechanacim").Caption = "Fecha de Nacimiento"
                GridView1.Columns("idedocivil").Caption = "idEstadoCivil"
                GridView1.Columns("estadocivil").Caption = "Estado Cívil"
                GridView1.Columns("dependientes").Caption = "Dependientes"
                GridView1.Columns("idestado").Caption = "idEstado"
                GridView1.Columns("estado").Caption = "Estado"
                GridView1.Columns("idciudad").Caption = "idCiudad"
                GridView1.Columns("ciudad").Caption = "Ciudad"
                GridView1.Columns("idcolonia").Caption = "idColonia"
                GridView1.Columns("colonia").Caption = "Colonia"
                GridView1.Columns("codigopostal").Caption = "Código Postal"
                GridView1.Columns("calle").Caption = "Calle"
                GridView1.Columns("entrecalles").Caption = "Entre calles"
                GridView1.Columns("idtipovivienda").Caption = "idTipoVivienda"
                GridView1.Columns("tipovivienda").Caption = "Tipo de vivienda"
                GridView1.Columns("antiguedadvivienda").Caption = "Antiguedad de vivienda"
                GridView1.Columns("valorcasa").Caption = "Valor de Casa"
                GridView1.Columns("valorautos").Caption = "Valor de Autos"
                GridView1.Columns("telcasa").Caption = "Tel. Casa"
                GridView1.Columns("telotro").Caption = "Otro Teléfono"
                GridView1.Columns("celular1").Caption = "Celular 1"
                GridView1.Columns("celular2").Caption = "Celular 2"
                GridView1.Columns("email").Caption = "Email"
                GridView1.Columns("empresa").Caption = "Empresa"
                GridView1.Columns("direccionempresa").Caption = "Dirección de Empresa"
                GridView1.Columns("puesto").Caption = "Puesto"
                GridView1.Columns("antiguedadempresa").Caption = "Antiguedad de Empresa"
                GridView1.Columns("ingresomensual").Caption = "Ingreso Mensual"
                GridView1.Columns("otrosingresos").Caption = "Otros ingresos"
                GridView1.Columns("ingresototal").Caption = "Ingreso Total"
                GridView1.Columns("limitecredito").Caption = "Límite crédito"
                GridView1.Columns("saldo").Caption = "Slado"
                GridView1.Columns("disponible").Caption = "Disponible"
                GridView1.Columns("limitevale").Caption = "Limite Vale"
                GridView1.Columns("contravale").Caption = "Contravale"
                GridView1.Columns("negext").Caption = "NegExt"
                GridView1.Columns("promocion").Caption = "Promoción"
                GridView1.Columns("nombreconyuge").Caption = "Nombre Conyugue"
                GridView1.Columns("appaternoconyuge").Caption = "Apellido Paterno Conyugue"
                GridView1.Columns("apmaternoconyuge").Caption = "Apellido Materno Conyugue"


                GridView1.OptionsView.ColumnAutoWidth = False

                GridView1.Columns("iddistrib").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("distrib").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridView1.Columns("distribuidor").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                For I As Integer = 0 To GridView1.Columns.Count - 1

                    GridView1.Columns(I).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GridView1.Columns(I).AppearanceHeader.Font = New Font(GridView1.Columns(I).AppearanceCell.Font, FontStyle.Bold)
                    GridView1.Columns(I).OptionsColumn.ReadOnly = True

                Next

                GridView1.Columns("iddistrib").Visible = False
                GridView1.Columns("idpromotor").Visible = False
                GridView1.Columns("idcoordinador").Visible = False
                GridView1.Columns("idtienda").Visible = False
                GridView1.Columns("idtipocredito").Visible = False
                GridView1.Columns("idperiodicidad").Visible = False
                GridView1.Columns("periodicidad").Visible = False
                GridView1.Columns("nombre").Visible = False
                GridView1.Columns("appaterno").Visible = False
                GridView1.Columns("apmaterno").Visible = False
                GridView1.Columns("sexo").Visible = False
                GridView1.Columns("fechanacim").Visible = False
                GridView1.Columns("idedocivil").Visible = False
                GridView1.Columns("estadocivil").Visible = False
                GridView1.Columns("dependientes").Visible = False
                GridView1.Columns("idestado").Visible = False
                GridView1.Columns("idciudad").Visible = False
                GridView1.Columns("idcolonia").Visible = False
                GridView1.Columns("entrecalles").Visible = False
                GridView1.Columns("idtipovivienda").Visible = False
                GridView1.Columns("tipovivienda").Visible = False
                GridView1.Columns("antiguedadvivienda").Visible = False
                GridView1.Columns("valorcasa").Visible = False
                GridView1.Columns("valorautos").Visible = False
                GridView1.Columns("telcasa").Visible = False
                GridView1.Columns("telotro").Visible = False
                GridView1.Columns("celular1").Visible = False
                GridView1.Columns("celular2").Visible = False
                GridView1.Columns("email").Visible = False
                GridView1.Columns("empresa").Visible = False
                GridView1.Columns("direccionempresa").Visible = False
                GridView1.Columns("puesto").Visible = False
                GridView1.Columns("antiguedadempresa").Visible = False
                GridView1.Columns("ingresomensual").Visible = False
                GridView1.Columns("otrosingresos").Visible = False
                GridView1.Columns("ingresototal").Visible = False
                GridView1.Columns("limitecredito").Visible = False
                GridView1.Columns("saldo").Visible = False
                GridView1.Columns("disponible").Visible = False
                GridView1.Columns("limitevale").Visible = False
                GridView1.Columns("contravale").Visible = False
                GridView1.Columns("negext").Visible = False
                GridView1.Columns("promocion").Visible = False
                GridView1.Columns("nombreconyuge").Visible = False
                GridView1.Columns("appaternoconyuge").Visible = False
                GridView1.Columns("apmaternoconyuge").Visible = False


                GridView1.BestFitColumns()

            Catch ExceptionErr As Exception
                MessageBox.Show(ExceptionErr.Message.ToString)
            End Try
        End If

    End Sub

    Private Sub RellenaGrid()
        If Tipo = "D" Then

            Call TraerDistribuidor()
            Exit Sub

        End If
    End Sub
End Class