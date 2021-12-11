Module ModDomicilioPart

    Public Function usp_TraerInformacionCodigosP(ByVal opcion As Integer, ByVal CP As String, ByVal estado As Integer, ByVal ciudad As Integer, ByVal colonia As Integer) As DataSet


        Using objCatalogo As New BCL.BCLLayoutDomicilioP(GLB_ConStringSircoControlSQL)

            Dim ObjDataSet As Data.DataSet
            ObjDataSet = objCatalogo.usp_TraerDomicilioParticular(opcion, CP, estado, ciudad, colonia)
            Return ObjDataSet


        End Using

    End Function


End Module
