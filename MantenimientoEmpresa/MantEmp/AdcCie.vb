Imports System.Data.SqlClient

Public Class AdcCie
    Public conectar As New SqlConnection()
    Public Cie_ConUltMen As DateTime = CDate("0:0")
    Public Cie_ConUltAnu As DateTime = CDate("0:0")
    Public Cie_ConUltAct As DateTime = CDate("0:0")
    Public Cie_InvUltMen As DateTime = CDate("0:0")
    Public Cie_InvUltAnu As DateTime = CDate("0:0")
    Public Cie_InvUltAct As DateTime = CDate("0:0")
    Public Cie_VenUltMen As DateTime = CDate("0:0")
    Public Cie_VenUltAnu As DateTime = CDate("0:0")
    Public Cie_VenUltAct As DateTime = CDate("0:0")
    Public Cie_ComUltMen As DateTime = CDate("0:0")
    Public Cie_ComUltAnu As DateTime = CDate("0:0")
    Public Cie_ComUltAct As DateTime = CDate("0:0")
    Public Cie_AcfIncDep As DateTime = CDate("0:0")
    Public Cie_AcfUltDep As DateTime = CDate("0:0")
    Public Cie_AcfIncRex As DateTime = CDate("0:0")
    Public Cie_AcfUltRex As DateTime = CDate("0:0")
    Public Cie_RolUlt As DateTime = CDate("0:0")
    Public Cie_RolUltAct As DateTime = CDate("0:0")
    Public Cie_TkMxI1 As Double = 0.0
    Public Cie_TkMxI2 As Double = 0.0
    Public Cie_TkMxI3 As Double = 0.0
    Public Cie_TkMxI4 As Double = 0.0
    Public Cie_TkMxI5 As Double = 0.0
    Public Cie_TkMxE1 As Double = 0.0
    Public Cie_TkMxE2 As Double = 0.0
    Public Cie_TkMxE3 As Double = 0.0
    Public Cie_TkMxE4 As Double = 0.0
    Public Cie_TkMxE5 As Double = 0.0
    Public Cie_TipAct As Double = 0.0
    Public Cie_FecAct As DateTime = CDate("0:0")
    Public Cie_TipRel As Double = 0.0
    Dim ssql As String = ""

    Public Sub Guardar()
        ssql = "insert into adcCie("
        ssql += "Cie_ConUltMen ,"
        ssql += "Cie_ConUltAnu ,"
        ssql += "Cie_ConUltAct ,"
        ssql += "Cie_InvUltMen ,"
        ssql += "Cie_InvUltAnu ,"
        ssql += "Cie_InvUltAct ,"
        ssql += "Cie_VenUltMen ,"
        ssql += "Cie_VenUltAnu ,"
        ssql += "Cie_VenUltAct ,"
        ssql += "Cie_ComUltMen ,"
        ssql += "Cie_ComUltAnu ,"
        ssql += "Cie_ComUltAct ,"
        ssql += "Cie_AcfIncDep ,"
        ssql += "Cie_AcfUltDep ,"
        ssql += "Cie_AcfIncRex ,"
        ssql += "Cie_AcfUltRex ,"
        ssql += "Cie_RolUlt ,"
        ssql += "Cie_RolUltAct,"
        ssql += "Cie_TkMxI1 ,"
        ssql += "Cie_TkMxI2 ,"
        ssql += "Cie_TkMxI3 ,"
        ssql += "Cie_TkMxI4 ,"
        ssql += "Cie_TkMxI5 ,"
        ssql += "Cie_TkMxE1 ,"
        ssql += "Cie_TkMxE2 ,"
        ssql += "Cie_TkMxE3 ,"
        ssql += "Cie_TkMxE4 ,"
        ssql += "Cie_TkMxE5 ,"
        ssql += "Cie_TipAct ,"
        ssql += "Cie_FecAct ,"
        ssql += "Cie_TipRel )"
        ssql += " values ("
        ssql += "'" & Cie_ConUltMen & "',"
        ssql += "'" & Cie_ConUltAnu & "',"
        ssql += "'" & Cie_ConUltAct & "',"
        ssql += "'" & Cie_InvUltMen & "',"
        ssql += "'" & Cie_InvUltAnu & "',"
        ssql += "'" & Cie_InvUltAct & "',"
        ssql += "'" & Cie_VenUltMen & "',"
        ssql += "'" & Cie_VenUltAnu & "',"
        ssql += "'" & Cie_VenUltAct & "',"
        ssql += "'" & Cie_ComUltMen & "',"
        ssql += "'" & Cie_ComUltAnu & "',"
        ssql += "'" & Cie_ComUltAct & "',"
        ssql += "'" & Cie_AcfIncDep & "',"
        ssql += "'" & Cie_AcfUltDep & "',"
        ssql += "'" & Cie_AcfIncRex & "',"
        ssql += "'" & Cie_AcfUltRex & "',"
        ssql += "'" & Cie_RolUlt & "',"
        ssql += "'" & Cie_RolUltAct & "',"
        ssql += "'" & Cie_TkMxI1 & "',"
        ssql += "'" & Cie_TkMxI2 & "',"
        ssql += "'" & Cie_TkMxI3 & "',"
        ssql += "'" & Cie_TkMxI4 & "',"
        ssql += "'" & Cie_TkMxI5 & "',"
        ssql += "'" & Cie_TkMxE1 & "',"
        ssql += "'" & Cie_TkMxE2 & "',"
        ssql += "'" & Cie_TkMxE3 & "',"
        ssql += "'" & Cie_TkMxE4 & "',"
        ssql += "'" & Cie_TkMxE5 & "',"
        ssql += "'" & Cie_TipAct & "',"
        ssql += "'" & Cie_FecAct & "',"
        ssql += "'" & Cie_TipRel & "')"
        Ejecutar(ssql)
    End Sub
    Public Sub Eliminar()
        ssql = "delete from Adccie "
        Ejecutar(ssql)
    End Sub
    Public Sub Consultar()
        ssql = "select * from adccie"
        'Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseAdcom(ssql)
        'conectar.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("Cie_ConUltMen")) Then Cie_ConUltMen = CDate(dat("Cie_ConUltMen"))
            If Not IsDBNull(dat("Cie_ConUltAnu")) Then Cie_ConUltAnu = CDate(dat("Cie_ConUltAnu"))
            If Not IsDBNull(dat("Cie_ConUltAct")) Then Cie_ConUltAct = CDate(dat("Cie_ConUltAct"))
            If Not IsDBNull(dat("Cie_InvUltMen")) Then Cie_InvUltMen = CDate(dat("Cie_InvUltMen"))
            If Not IsDBNull(dat("Cie_InvUltAnu")) Then Cie_InvUltAnu = CDate(dat("Cie_InvUltAnu"))
            If Not IsDBNull(dat("Cie_InvUltAct")) Then Cie_InvUltAct = CDate(dat("Cie_InvUltAct"))
            If Not IsDBNull(dat("Cie_VenUltMen")) Then Cie_VenUltMen = CDate(dat("Cie_VenUltMen"))
            If Not IsDBNull(dat("Cie_VenUltAnu")) Then Cie_VenUltAnu = CDate(dat("Cie_VenUltAnu"))
            If Not IsDBNull(dat("Cie_VenUltAct")) Then Cie_VenUltAct = CDate(dat("Cie_VenUltAct"))
            If Not IsDBNull(dat("Cie_ComUltMen")) Then Cie_ComUltMen = CDate(dat("Cie_ComUltMen"))
            If Not IsDBNull(dat("Cie_ComUltAnu")) Then Cie_ComUltAnu = CDate(dat("Cie_ComUltAnu"))
            If Not IsDBNull(dat("Cie_ComUltAct")) Then Cie_ComUltAct = CDate(dat("Cie_ComUltAct"))
            If Not IsDBNull(dat("Cie_AcfIncDep")) Then Cie_AcfIncDep = CDate(dat("Cie_AcfIncDep"))
            If Not IsDBNull(dat("Cie_AcfUltDep")) Then Cie_AcfUltDep = CDate(dat("Cie_AcfUltDep"))
            If Not IsDBNull(dat("Cie_AcfIncRex")) Then Cie_AcfIncRex = CDate(dat("Cie_AcfIncRex"))
            If Not IsDBNull(dat("Cie_AcfUltRex")) Then Cie_AcfUltRex = CDate(dat("Cie_AcfUltRex"))
            If Not IsDBNull(dat("Cie_RolUlt")) Then Cie_RolUlt = CDate(dat("Cie_RolUlt"))
            If Not IsDBNull(dat("Cie_RolUltAct")) Then Cie_RolUltAct = CDate(dat("Cie_RolUltAct"))
            If Not IsDBNull(dat("Cie_TkMxI1")) Then Cie_TkMxI1 = CDbl(dat("Cie_TkMxI1"))
            If Not IsDBNull(dat("Cie_TkMxI2")) Then Cie_TkMxI2 = CDbl(dat("Cie_TkMxI2"))
            If Not IsDBNull(dat("Cie_TkMxI3")) Then Cie_TkMxI3 = CDbl(dat("Cie_TkMxI3"))
            If Not IsDBNull(dat("Cie_TkMxI4")) Then Cie_TkMxI4 = CDbl(dat("Cie_TkMxI4"))
            If Not IsDBNull(dat("Cie_TkMxI5")) Then Cie_TkMxI5 = CDbl(dat("Cie_TkMxI5"))
            If Not IsDBNull(dat("Cie_TkMxE1")) Then Cie_TkMxE1 = CDbl(dat("Cie_TkMxE1"))
            If Not IsDBNull(dat("Cie_TkMxE2")) Then Cie_TkMxE2 = CDbl(dat("Cie_TkMxE2"))
            If Not IsDBNull(dat("Cie_TkMxE3")) Then Cie_TkMxE3 = CDbl(dat("Cie_TkMxE3"))
            If Not IsDBNull(dat("Cie_TkMxE4")) Then Cie_TkMxE4 = CDbl(dat("Cie_TkMxE4"))
            If Not IsDBNull(dat("Cie_TkMxE5")) Then Cie_TkMxE5 = CDbl(dat("Cie_TkMxE5"))
            If Not IsDBNull(dat("Cie_TipAct")) Then Cie_TipAct = CDbl(dat("Cie_TipAct"))
            If Not IsDBNull(dat("Cie_FecAct")) Then Cie_FecAct = CDate(dat("Cie_FecAct"))
            If Not IsDBNull(dat("Cie_TipRel")) Then Cie_TipRel = CDbl(dat("Cie_TipRel"))
        End If
        'conectar.Close()
    End Sub
    Friend Sub Ejecutar(ByVal comando As String)
        Dim cmd As New SqlCommand(comando, conectar)
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
    End Sub
End Class
