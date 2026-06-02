Imports System.Data
Public Module emp
    Friend InvUltAnu As DateTime = New DateTime(1900, 1, 1)
    Friend RolCodMay As DateTime = New DateTime(1900, 1, 1)
    Friend CtaNumDigNivel As String = "0000000"
    Friend CtaNumNiveles As Int32 = 0
    Friend NumeroDigitos As Int32 = 0
    Friend Acf As Boolean = False
    Friend inv As Boolean = False
    Friend rol As Boolean = False
    Friend autorizacion As String = ""
    Public Sub cargarParametrosEmpresa()
        Dim DatEmp As DataTable = DattCom.datosEmpresa.leeParametrosEmp(" DefCta_NumDigNivel,DefCta_NumNiveles,Par_Numerodigitos,RolCodMay")
        If DatEmp.Rows.Count > 0 Then
            'InvUltAnu = Convert.ToDateTime(DatEmp.Rows(0).Item("InvUltAnu"))
            RolCodMay = Convert.ToDateTime(DatEmp.Rows(0).Item("RolCodMay"))
            CtaNumDigNivel = DatEmp.Rows(0).Item("DefCta_NumDigNivel").ToString()
            CtaNumNiveles = Convert.ToInt32(DatEmp.Rows(0).Item("DefCta_NumNiveles"))
            NumeroDigitos = Convert.ToInt32(DatEmp.Rows(0).Item("Par_Numerodigitos"))
        End If
    End Sub
End Module
