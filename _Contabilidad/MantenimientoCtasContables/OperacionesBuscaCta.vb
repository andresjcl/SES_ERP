Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DattCom

Module OperacionesBuscaCta
	'Public ConxAdcom As New ADODB.Connection
	'Public ConxSysemp As New ADODB.Connection
	Public con As String
    'Public CONEMP As New AdcDax.DaxsofSys
    'Public Emp As AdcDax.Empresa
    'Public CONUSR As New DaxUsr.DaxsofUsr
    'Public ControlUsuario As DaxUsr.CtrlUsuario
    'Public libdat As New DaxLib.DaxLibDigDato
    'Public libbas As New DaxLib.DaxLibBases
    'Public libmens As New DaxLib.Mensajes
    Public sSql As String
    Public Resultado As String
    Public NombreCta As String
	Public CodigoCta As String
	Public EsNuevo As Short
    Dim conectar As New SqlConnection()

    Public Function NombreCuentaContable(ByRef codigo As String) As String
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBase("SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" & Trim(codigo) & "'", datosEmpresa.strConxAdcom)
        If dat.Read Then
            NombreCuentaContable = dat("CTA_NOMBRE")
        Else
            NombreCuentaContable = ""
        End If
        '    If RsAux.State = 1 Then RsAux.Close
        dat = Nothing
    End Function

    Public Function QuePadreDeCta(ByRef CodCta As String, ByRef CtaNivel As Short) As String
        Dim Lim As Single
        Dim i As Short
        If CtaNivel = 1 Then QuePadreDeCta = "" : Exit Function
        Lim = 0
        For i = 1 To CtaNivel - 1
            Lim = Lim + Val(Mid(emp.CtaNumDigNivel, i, 1))
        Next
        QuePadreDeCta = Mid(CodCta, 1, Lim)
    End Function

    Public Function PonerPtosCtas(ByRef cta As String) As String
		Dim i As Integer
		Dim OrgNiv() As Short
		Dim cont As Short
		Emp.CtaNumNiveles = 6
		ReDim OrgNiv(Emp.CtaNumNiveles)
		
		For i = 1 To Emp.CtaNumNiveles
			OrgNiv(i) = Val(Mid(Emp.CtaNumDigNivel, i, 1))
		Next 
		'pongo los valores para saber de que largo debe ser la cadena para cambiar de nivel
		OrgNiv(2) = OrgNiv(1) + OrgNiv(2)
		OrgNiv(3) = OrgNiv(2) + OrgNiv(3)
		OrgNiv(4) = OrgNiv(3) + OrgNiv(4)
		OrgNiv(5) = OrgNiv(4) + OrgNiv(5)
		OrgNiv(6) = OrgNiv(5) + OrgNiv(6)
		cont = 0
		For i = 3 To Emp.CtaNumNiveles
			If Len(cta) - cont > OrgNiv(i) Then
				cta = Mid(cta, 1, OrgNiv(i) + cont) & "." & Mid(cta, OrgNiv(i) + cont + 1)
				cont = cont + 1
				
			End If
		Next 
		PonerPtosCtas = cta
	End Function
End Module