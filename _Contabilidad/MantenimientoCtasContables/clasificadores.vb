Option Strict On
Option Explicit On

Public Class Clasificador
    Private _IDCLAVE As Integer
    Private _Nombre As String
    Private _Descripcion As String
    Private _Status As Boolean
    Private _OrigenValores As String
    Private _CampoDia As String
    Private _CampoTra As String
    Private _RegPorConcepto As Boolean
    Private _TipoDirectorio As String
    Private _GrupoDirectorio As String
    Private _Clave As String

    Public Property IDCLAVE() As Integer
        Get
            Return _IDCLAVE
        End Get
        Set(ByVal value As Integer)
            _IDCLAVE = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Status() As Boolean
        Get
            Return _Status
        End Get
        Set(ByVal value As Boolean)
            _Status = value
        End Set
    End Property

    Public Property OrigenValores() As String
        Get
            Return _OrigenValores
        End Get
        Set(ByVal value As String)
            _OrigenValores = value
        End Set
    End Property

    Public Property CampoDia() As String
        Get
            Return _CampoDia
        End Get
        Set(ByVal value As String)
            _CampoDia = value
        End Set
    End Property

    Public Property CampoTra() As String
        Get
            Return _CampoTra
        End Get
        Set(ByVal value As String)
            _CampoTra = value
        End Set
    End Property

    Public Property RegPorConcepto() As Boolean
        Get
            Return _RegPorConcepto
        End Get
        Set(ByVal value As Boolean)
            _RegPorConcepto = value
        End Set
    End Property

    Public Property TipoDirectorio() As String
        Get
            Return _TipoDirectorio
        End Get
        Set(ByVal value As String)
            _TipoDirectorio = value
        End Set
    End Property

    Public Property GrupoDirectorio() As String
        Get
            Return _GrupoDirectorio
        End Get
        Set(ByVal value As String)
            _GrupoDirectorio = value
        End Set
    End Property

    Public Property Clave() As String
        Get
            Return _Clave
        End Get
        Set(ByVal value As String)
            _Clave = value
        End Set
    End Property

    Public Sub New()
        _IDCLAVE = 0
        _Nombre = ""
        _Descripcion = ""
        _Status = False
        _OrigenValores = ""
        _CampoDia = ""
        _CampoTra = ""
        _RegPorConcepto = False
        _TipoDirectorio = ""
        _GrupoDirectorio = ""
        _Clave = ""
    End Sub
End Class