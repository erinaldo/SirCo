Public Class frmCopiarFolioBulto
    'mreyes 21/Mayo/2016    11:09 .am.

    Public FolioB As Integer = 0


    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        ' si existe el foliio


    End Sub

    Private Sub Txt_Sucursal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_NoBulto.LostFocus

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
                MsgBox("El folio se encuentra CANCELADO no se puede copiar en el.", MsgBoxStyle.Critical, "Aviso")
                Txt_NoBulto.Text = ""
                Txt_NoBulto.Focus()
                Exit Sub

            End If

            


        End Using


        FolioB = pub_RellenarIzquierda(objDataSet.Tables(0).Rows(0).Item("idfolio").ToString, 6)





    End Sub

    Private Sub Txt_Sucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_NoBulto.TextChanged

    End Sub
End Class