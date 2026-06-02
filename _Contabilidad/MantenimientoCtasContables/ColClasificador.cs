// Option Strict Off
// Option Explicit On
// Public Class ColClasificador
// Implements System.Collections.IEnumerable
// 'variable local para contener colección
// Private mCol As Collection

// Public Function Add(ByRef IDCLAVE As Integer, ByRef Status As Boolean, ByRef origenvalores As String, ByRef campodia As String, ByRef campotra As String, ByRef regPorConcepto As Boolean, ByRef Nombre As String, ByRef TipoDirect As String, ByRef GrupoDirect As String, Optional ByRef sKey As String = "") As clasificador
// 'crear un nuevo objeto
// Dim objNewMember As clasificador
// objNewMember = New clasificador

// 'establecer las propiedades que se transfieren al método
// objNewMember.IDCLAVE = IDCLAVE
// objNewMember.Status = Status
// objNewMember.origenvalores = origenvalores
// objNewMember.campodia = campodia
// objNewMember.campotra = campotra
// objNewMember.regPorConcepto = regPorConcepto
// objNewMember.Nombre = Nombre
// objNewMember.TipoDirectorio = TipoDirect
// objNewMember.GrupoDirectorio = GrupoDirect

// If Len(sKey) = 0 Then
// mCol.Add(objNewMember)
// Else
// mCol.Add(objNewMember, sKey)
// End If


// 'devolver el objeto creado
// Add = objNewMember
// objNewMember = Nothing


// End Function

// Default Public ReadOnly Property Item(ByVal vntIndexKey As String) As clasificador
// Get
// 'se usa al hacer referencia a un elemento de la colección
// 'vntIndexKey contiene el índice o la clave de la colección,
// 'por lo que se declara como un Variant
// 'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
// Dim I As Short
// Dim Aux As New clasificador
// Item = Aux
// For I = 1 To mCol.Count()
// Aux = mCol.Item(I)
// If UCase(Aux.Nombre) = UCase(Mid(vntIndexKey, 2)) Then
// Item = mCol.Item(I)
// Exit For
// End If
// Next I
// End Get
// End Property

// Public ReadOnly Property Count() As Integer
// Get
// 'se usa al obtener el número de elementos de la
// 'colección. Sintaxis: Debug.Print x.Count
// Count = mCol.Count()
// End Get
// End Property


// 'Public ReadOnly Property NewEnum() As stdole.IUnknown
// 'Get
// 'esta propiedad permite enumerar
// 'esta colección con la sintaxis For...Each
// 'NewEnum = mCol._NewEnum
// 'End Get
// 'End Property

// Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
// GetEnumerator = mCol.GetEnumerator
// End Function


// Public Sub Remove(ByRef vntIndexKey As String)
// 'se usa al quitar un elemento de la colección
// 'vntIndexKey contiene el índice o la clave, por lo que se
// 'declara como un Variant
// 'Sintaxis: x.Remove(xyz)


// mCol.Remove(vntIndexKey)
// End Sub


// Private Sub Class_Initialize_Renamed()
// 'crea la colección cuando se crea la clase
// mCol = New Collection
// End Sub
// Public Sub New()
// MyBase.New()
// Class_Initialize_Renamed()
// End Sub


// Private Sub Class_Terminate_Renamed()
// 'destruye la colección cuando se termina la clase
// mCol = Nothing
// End Sub
// Protected Overrides Sub Finalize()
// Class_Terminate_Renamed()
// MyBase.Finalize()
// End Sub
// End Class
// Option Strict Off
// Option Explicit On
// Public Class ColClasificador
// Implements System.Collections.IEnumerable
// 'variable local para contener colección
// Private mCol As Collection

// Public Function Add(ByRef IDCLAVE As Integer, ByRef Status As Boolean, ByRef origenvalores As String, ByRef campodia As String, ByRef campotra As String, ByRef regPorConcepto As Boolean, ByRef Nombre As String, ByRef TipoDirect As String, ByRef GrupoDirect As String, Optional ByRef sKey As String = "") As clasificador
// 'crear un nuevo objeto
// Dim objNewMember As clasificador
// objNewMember = New clasificador

// 'establecer las propiedades que se transfieren al método
// objNewMember.IDCLAVE = IDCLAVE
// objNewMember.Status = Status
// objNewMember.origenvalores = origenvalores
// objNewMember.campodia = campodia
// objNewMember.campotra = campotra
// objNewMember.regPorConcepto = regPorConcepto
// objNewMember.Nombre = Nombre
// objNewMember.TipoDirectorio = TipoDirect
// objNewMember.GrupoDirectorio = GrupoDirect

// If Len(sKey) = 0 Then
// mCol.Add(objNewMember)
// Else
// mCol.Add(objNewMember, sKey)
// End If


// 'devolver el objeto creado
// Add = objNewMember
// objNewMember = Nothing


// End Function

// Default Public ReadOnly Property Item(ByVal vntIndexKey As String) As clasificador
// Get
// 'se usa al hacer referencia a un elemento de la colección
// 'vntIndexKey contiene el índice o la clave de la colección,
// 'por lo que se declara como un Variant
// 'Syntax: Set foo = x.Item(xyz) or Set foo = x.Item(5)
// Dim I As Short
// Dim Aux As New clasificador
// Item = Aux
// For I = 1 To mCol.Count()
// Aux = mCol.Item(I)
// If UCase(Aux.Nombre) = UCase(Mid(vntIndexKey, 2)) Then
// Item = mCol.Item(I)
// Exit For
// End If
// Next I
// End Get
// End Property

// Public ReadOnly Property Count() As Integer
// Get
// 'se usa al obtener el número de elementos de la
// 'colección. Sintaxis: Debug.Print x.Count
// Count = mCol.Count()
// End Get
// End Property


// 'Public ReadOnly Property NewEnum() As stdole.IUnknown
// 'Get
// 'esta propiedad permite enumerar
// 'esta colección con la sintaxis For...Each
// 'NewEnum = mCol._NewEnum
// 'End Get
// 'End Property

// Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
// GetEnumerator = mCol.GetEnumerator
// End Function


// Public Sub Remove(ByRef vntIndexKey As String)
// 'se usa al quitar un elemento de la colección
// 'vntIndexKey contiene el índice o la clave, por lo que se
// 'declara como un Variant
// 'Sintaxis: x.Remove(xyz)


// mCol.Remove(vntIndexKey)
// End Sub


// Private Sub Class_Initialize_Renamed()
// 'crea la colección cuando se crea la clase
// mCol = New Collection
// End Sub
// Public Sub New()
// MyBase.New()
// Class_Initialize_Renamed()
// End Sub


// Private Sub Class_Terminate_Renamed()
// 'destruye la colección cuando se termina la clase
// mCol = Nothing
// End Sub
// Protected Overrides Sub Finalize()
// Class_Terminate_Renamed()
// MyBase.Finalize()
// End Sub
// End Class