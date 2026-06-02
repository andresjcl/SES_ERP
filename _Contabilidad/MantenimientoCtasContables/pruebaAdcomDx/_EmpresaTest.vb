Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports AdcDax



'''<summary>
'''Se trata de una clase de prueba para _EmpresaTest y se pretende que
'''contenga todas las pruebas unitarias _EmpresaTest.
'''</summary>
<TestClass()> _
Public Class _EmpresaTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Obtiene o establece el contexto de la prueba que proporciona
    '''la información y funcionalidad para la ejecución de pruebas actual.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Atributos de prueba adicionales"
    '
    'Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
    '
    'Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize para ejecutar código antes de ejecutar cada prueba
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    Friend Overridable Function Create_Empresa() As _Empresa
        'TODO: Crear instancia de una clase concreta apropiada.
        Dim target As _Empresa = Nothing
        Return target
    End Function

    '''<summary>
    '''Una prueba de Acf
    '''</summary>
    <TestMethod()> _
    Public Sub AcfTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim actual As Boolean
        actual = target.Acf
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de Autorizacion
    '''</summary>
    <TestMethod()> _
    Public Sub AutorizacionTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As String = String.Empty ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        target.Autorizacion = expected
        actual = target.Autorizacion
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de ConUltAnu
    '''</summary>
    <TestMethod()> _
    Public Sub ConUltAnuTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As DateTime = New DateTime() ' TODO: Inicializar en un valor adecuado
        Dim actual As DateTime
        target.ConUltAnu = expected
        actual = target.ConUltAnu
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de CtaNumDigNivel
    '''</summary>
    <TestMethod()> _
    Public Sub CtaNumDigNivelTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As String = String.Empty ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        target.CtaNumDigNivel = expected
        actual = target.CtaNumDigNivel
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de CtaNumNiveles
    '''</summary>
    <TestMethod()> _
    Public Sub CtaNumNivelesTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As Short = 0 ' TODO: Inicializar en un valor adecuado
        Dim actual As Short
        target.CtaNumNiveles = expected
        actual = target.CtaNumNiveles
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de Inv
    '''</summary>
    <TestMethod()> _
    Public Sub InvTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim actual As Boolean
        actual = target.Inv
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de InvUltAnu
    '''</summary>
    <TestMethod()> _
    Public Sub InvUltAnuTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As DateTime = New DateTime() ' TODO: Inicializar en un valor adecuado
        Dim actual As DateTime
        target.InvUltAnu = expected
        actual = target.InvUltAnu
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de NombreBaseAdcom
    '''</summary>
    <TestMethod()> _
    Public Sub NombreBaseAdcomTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As String = String.Empty ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        target.NombreBaseAdcom = expected
        actual = target.NombreBaseAdcom
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de NumeroDigitos
    '''</summary>
    <TestMethod()> _
    Public Sub NumeroDigitosTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As Short = 0 ' TODO: Inicializar en un valor adecuado
        Dim actual As Short
        target.NumeroDigitos = expected
        actual = target.NumeroDigitos
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de RolCodMay
    '''</summary>
    <TestMethod()> _
    Public Sub RolCodMayTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As String = String.Empty ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        target.RolCodMay = expected
        actual = target.RolCodMay
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de nombre
    '''</summary>
    <TestMethod()> _
    Public Sub nombreTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As String = String.Empty ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        target.nombre = expected
        actual = target.nombre
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de rol
    '''</summary>
    <TestMethod()> _
    Public Sub rolTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim actual As Boolean
        actual = target.rol
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub

    '''<summary>
    '''Una prueba de servidor
    '''</summary>
    <TestMethod()> _
    Public Sub servidorTest()
        Dim target As _Empresa = Create_Empresa() ' TODO: Inicializar en un valor adecuado
        Dim expected As String = String.Empty ' TODO: Inicializar en un valor adecuado
        Dim actual As String
        target.servidor = expected
        actual = target.servidor
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub
End Class
