Imports System.Xml

Public Class Comprobante

#Region "VARIABLES"

    Private estadoValue As String = String.Empty
    Private numeroAutorizacionValue As String = String.Empty
    Private ambienteValue As String = String.Empty
    Private comprobanteValue As String = String.Empty
    Private mensajesValue As New ArrayList
    Private soapStringValue As String = String.Empty
    Private estadoSRIValue As RespuestaSRYType = RespuestaSRYType.NOAUTORIZADO
    Private claveAccesoValue As String = String.Empty
    Private fechaAutorizacionStringValue As String = String.Empty
    Private messageSoapValue As String = String.Empty

#End Region

#Region "PROPERTIES"

    Public Property ClaveAcceso() As String
        Get
            Return claveAccesoValue
        End Get
        Friend Set(ByVal value As String)
            claveAccesoValue = value
        End Set
    End Property

    Friend Property EstadoSRI() As RespuestaSRYType
        Get
            Return estadoSRIValue
        End Get
        Set(ByVal value As RespuestaSRYType)
            estadoSRIValue = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return estadoValue
        End Get
        Friend Set(ByVal value As String)
            estadoValue = value
        End Set
    End Property

    Public Property FechaAutorizacion() As String
        Get
            Return fechaAutorizacionStringValue
        End Get
        Friend Set(ByVal value As String)
            fechaAutorizacionStringValue = value
        End Set
    End Property

    Public Property NumeroAutorizacion() As String
        Get
            Return numeroAutorizacionValue
        End Get
        Friend Set(ByVal value As String)
            numeroAutorizacionValue = value
        End Set
    End Property

    Public Property Ambiente() As String
        Get
            Return ambienteValue
        End Get
        Friend Set(ByVal value As String)
            ambienteValue = value
        End Set
    End Property

    Public Property Mensajes() As ArrayList
        Get
            Return mensajesValue
        End Get
        Friend Set(ByVal value As ArrayList)
            mensajesValue = value
        End Set
    End Property

    Public Property Comprobante() As String
        Get
            Return comprobanteValue
        End Get
        Friend Set(ByVal value As String)
            comprobanteValue = value
        End Set
    End Property

    Public Property SoapString() As String
        Get
            Return soapStringValue
        End Get
        Friend Set(ByVal value As String)
            soapStringValue = value
        End Set
    End Property

#End Region

#Region "CONSTRUCTOR"

    Friend Sub New()
    End Sub

    Friend Sub New(ByVal ClaveAcceso As String, ByVal MessageSoap As String)
        MyBase.New()
        claveAccesoValue = ClaveAcceso
        messageSoapValue = MessageSoap
    End Sub

#End Region

#Region "METODOS"

    Public Function getMensajes() As String
        Dim str As New System.Text.StringBuilder
        '----------------------------------------------------------------------------------------------
        If mensajesValue.Count > 0 Then
            For Each mensaje As Mensaje In mensajesValue
                If str.Length > 0 Then
                    str.AppendLine()
                End If
                '-----------------------------------------------------------------------------------------
                str.AppendFormat("Tipo:{0}{1}", mensaje.Tipo, vbCrLf)
                str.AppendFormat("Identificador N°:{0}{1}", mensaje.Identificador, vbCrLf)
                str.AppendFormat("Mensaje :{0}{1}", mensaje.Mensaje, vbCrLf)
                '-----------------------------------------------------------------------------------------
                If mensaje.InformacionAdicional <> String.Empty Then
                    str.AppendFormat("Informacion adicional: {0}{1}", mensaje.InformacionAdicional, vbCrLf)
                End If
            Next
        Else
            str.Append(messageSoapValue)
        End If
        '----------------------------------------------------------------------------------------------
        Return str.ToString
    End Function

#End Region

End Class