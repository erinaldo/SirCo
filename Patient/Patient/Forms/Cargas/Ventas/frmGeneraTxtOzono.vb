Public Class frmGeneraTxtOzono
    'Tony Garcia - 21/Enero/2014 09:37 a.m.
    Dim Sql As String
    Public Sw_Filtro As Boolean = False
    Public Sw_Cancelar As Boolean = False

    Private objDataSet As Data.DataSet
    Public FechaIniB As Date
    Public Tipo As String = ""
    Dim FechaFinB As Date



    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Try

            'If Opcion <> 3 Then
            '    MsgBox("No puede generar el layout, sino se encuentra en indicador por empleado.", MsgBoxStyle.Information, "Aviso")
            '    Exit Sub
            'End If
            'If TipoNomB = "B" Then
            '    MsgBox("No puede generar el layout, sino se encuentra en Nómina Fiscal o de Aguinaldo.", MsgBoxStyle.Information, "Aviso")

            '    Exit Sub
            'End If

            FechaIniB = DT_FechaIni.Value
            FechaFinB = DT_FechaFin.Value

            If MsgBox("Esta seguro de querer generar el archivo .txt?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmación") = MsgBoxResult.No Then Exit Sub

            Dim NomArchivo As String = ""

            Dim Linea As String = ""
            Dim Archivo As String = "" '"c:\Prueba\Banamex" & Replace(Replace(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), "-", ""), ":", "") & ".txt"

            Dim Empresa As String = ""
            Dim Marca As String = ""
            Dim Estilof As String = ""
            Dim Medida As String = ""
            Dim Ctd As String = ""
            Dim Fecha As String = ""
            Dim Precio As String = ""
            Dim Costo As String = ""


            NomArchivo = DT_FechaFin.Value.ToString("yyyyMMdd")

            Using objVtas As New BCL.BCLVentas(GLB_ConStringDWH)
                objDataSet = objVtas.usp_GeneraTxtOzono(FechaIniB, FechaFinB)
            End Using
            If objDataSet.Tables(0).Rows.Count > 0 Then
                Archivo = GLB_RutaTxtOzono & "T0101" & NomArchivo & ".txt"
                Dim sw As New System.IO.StreamWriter(Archivo)
                For i As Integer = 1 To objDataSet.Tables(0).Rows.Count

                    Empresa = objDataSet.Tables(0).Rows(i - 1).Item("empresa").ToString & ","
                    Marca = pub_RellenarEspaciosDerecha(objDataSet.Tables(0).Rows(i - 1).Item("marca").ToString, 30) & ","
                    Estilof = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(i - 1).Item("estilof").ToString, 12) & ","

                    Medida = objDataSet.Tables(0).Rows(i - 1).Item("medida").ToString & ","
                    Ctd = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(i - 1).Item("ctd").ToString, 12) & ","
                    Fecha = Format(CDate(objDataSet.Tables(0).Rows(i - 1).Item("fecha")), "dd/MM/yyyy") & ","
                    Precio = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(i - 1).Item("imp").ToString, 9) & ","
                    Costo = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(i - 1).Item("costo").ToString, 9)

                    Linea = Empresa & Marca & Estilof & Medida + Ctd + Fecha + Precio + Costo
                    sw.WriteLine(Linea)
                Next
                sw.Close()
            End If

            MsgBox("Archivo creado en '" & Archivo, MsgBoxStyle.Information, "Confirmación")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
   

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Try
            '' Me.Dispose()
            Sw_Cancelar = True
            Sw_Filtro = False
            Me.Close()
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip.SetToolTip(Btn_Aceptar, "Aceptar la acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Cancelar, "Cancelar cualquier acción requerida por el usuario")
            ToolTip.SetToolTip(Btn_Limpiar, "Limpiar Filtros")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub

    Private Sub DGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub frmFiltrosFacturas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Sw_Filtro = False
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmConsultaEstilo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call GenerarToolTip()
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
    End Sub

  

End Class