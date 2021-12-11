Imports System.IO

'vgallegos 26/Enero/2018 3:20 pm
Public Class frmLayoutCP
    Dim idusuario As Integer = GLB_Idempleado
    Dim fum As String = Date.Now
    Dim d_codigo As String = ""
    Dim d_asenta As String = ""
    Dim d_tipo_asenta As String = ""
    Dim D_mnpio As String = ""
    Dim d_estado As String = ""
    Dim d_ciudad As String = ""
    Dim d_CP As String = ""
    Dim c_estado As String = ""
    Dim c_oficina As String = ""
    Dim c_CP As String = ""
    Dim c_tipo_asenta As String = ""
    Dim c_mnpio As String = ""
    Dim id_asenta_cpcons As String = ""
    Dim d_zona As String = ""
    Dim c_cve_ciudad As String = ""

    Private Sub Layout_CodigosPostales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(Btn_Layout, "Cargar Layout")
    End Sub


    Private Sub Btn_Layout_Click_1(sender As Object, e As EventArgs) Handles Btn_Layout.Click
        Try

            '--Manda llamar a la funcion de lectura del archivo

            If MsgBox("Estas Seguro de Grabar el Archivo?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmar") = MsgBoxResult.Ok Then
                Call usp_LeerArchivo()
            End If

        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub


    Private Sub usp_LeerArchivo()
        Try
            Dim TodoTexto As String = "", LineaDeTexto As String = ""
            Dim x As Integer = 1

            OpenFileDialog1.Filter = "Formato de archivo (*.TXT)|*.TXT" 'Formatos permitidos en objeto 
            OpenFileDialog1.ShowDialog() 'abre el cuadro de diálogo Abrir 
            Dim Sw_Inv As Boolean
            ''vgallegos 26/Enero/2018 04:25 pm codigo de lectura de archivo---------
            Dim myStream As StreamReader = Nothing
            Dim NomArch As String
            Dim ContHeader As Integer = 0
            Dim Archivo As String = ""
            P_Bar.Minimum = 0


            Archivo = String.Concat(OpenFileDialog1.FileName) 'ruta del archivo
            Dim myStream2 As New IO.StreamReader(OpenFileDialog1.FileName, System.Text.Encoding.Default) 'codifica la lectura del archivo a Español para poder leer acentos
            NomArch = myStream2.ReadToEnd()
            Dim Lineas() As String = Split(NomArch, vbNewLine)

            ' maximo y minimos de la barra----
            P_Bar.Minimum = 0
            P_Bar.Maximum = Lineas.Length
            P_Bar.Value = 0
            '------------------------------------------------------------------
            '----
            For i As Integer = 0 To Lineas.Length - 1
                Dim Linea As String = Lineas(i).Trim 'separa la linea entera ejemplo 01000|San Ángel|Colonia|Álvaro Obregón|
                Dim Codigos() As String = Split(Lineas(i).Trim, "|") 'separa la columna de la linea ejemplo 01000
                Lbl_Leyenda.Text = Archivo & "-" & Linea
                If Codigos.Length > 2 Then
                    ContHeader = ContHeader + 1
                    d_codigo = Codigos(0).Trim
                    d_asenta = Codigos(1).Trim
                    'd_tipo_asenta = Codigos(2).Trim
                    ' D_mnpio = Codigos(3).Trim
                    d_estado = Codigos(4).Trim
                    d_ciudad = Codigos(3).Trim
                    'd_CP = Codigos(6).Trim
                    'c_estado = Codigos(7).Trim
                    'c_oficina = Codigos(8).Trim
                    ' c_CP = Codigos(9).Trim
                    'c_tipo_asenta = Codigos(10).Trim
                    ' c_mnpio = Codigos(11).Trim
                    'id_asenta_cpcons = Codigos(12).Trim
                    'd_zona = Codigos(13).Trim
                    'c_cve_ciudad = Codigos(14).Trim

                    If ContHeader > 1 Then
                        Using objCatalogo As New BCL.BCLLayoutDomicilioP(GLB_ConStringSircoControlSQL)
                            Sw_Inv = objCatalogo.usp_CapturaLeerArchivoCodigos(d_codigo, d_asenta, d_estado,
                                                                               d_ciudad, idusuario)
                        End Using
                    End If
                    If i = Lineas.Length - 1 Then
                        LabelTerminado.Text = "Los datos del archivo han sido grabados exitosamente"
                    End If
                End If
                P_Bar.Value = P_Bar.Value + 1
                Application.DoEvents()
            Next
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
    Private Sub GenerarToolTip()
        Try
            ToolTip1.SetToolTip(Btn_Layout, "Cargar Layout")
        Catch ExceptionErr As Exception
            MessageBox.Show(ExceptionErr.Message.ToString)
        End Try
    End Sub
End Class