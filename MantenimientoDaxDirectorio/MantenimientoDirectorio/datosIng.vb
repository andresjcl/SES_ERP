Imports DattCom
Imports System.Windows.Forms
Public Class datosIng
    Public Class AutorizarLlamadas
        Public Shared Function VerificaAutorización(idOpcion As String, Optional SuprimeMensaje As Boolean = False) As Boolean
            Dim resp As String = DatosUsuario.AutorizaIngreso(idOpcion)

            If resp = "" Then
                If SuprimeMensaje = False Then
                    MessageBox.Show("No tiene acceso a esta función" & vbCrLf &
                                    "Consulte con el Administrador del sistema",
                                    "Acceso Denegado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.[Error])
                End If
                Return False
            End If

            Return True
        End Function
    End Class

End Class
