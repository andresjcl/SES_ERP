Option Strict On
Option Explicit On

Imports System.Collections.Generic

Public Class ColClasificador
    Inherits List(Of Clasificador)

    Public Sub New()
        MyBase.New()
    End Sub

    Public Shadows Sub Add(ByVal item As Clasificador)
        MyBase.Add(item)
    End Sub

    Public Function FindByIDCLAVE(ByVal idClave As Integer) As Clasificador
        For Each cl As Clasificador In Me
            If cl.IDCLAVE = idClave Then
                Return cl
            End If
        Next
        Return Nothing
    End Function

    Public Function FindByNombre(ByVal nombre As String) As Clasificador
        For Each cl As Clasificador In Me
            If cl.Nombre.ToLower() = nombre.ToLower() Then
                Return cl
            End If
        Next
        Return Nothing
    End Function

    Public Function GetNombres() As List(Of String)
        Dim nombres As New List(Of String)()
        For Each cl As Clasificador In Me
            nombres.Add(cl.Nombre)
        Next
        Return nombres
    End Function
End Class