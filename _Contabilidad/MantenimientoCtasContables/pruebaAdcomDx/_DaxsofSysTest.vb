Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports AdcDax



'''<summary>
'''Se trata de una clase de prueba para _DaxsofSysTest y se pretende que
'''contenga todas las pruebas unitarias _DaxsofSysTest.
'''</summary>
<TestClass()> _
Public Class _DaxsofSysTest


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


    Friend Overridable Function Create_DaxsofSys() As _DaxsofSys
        'TODO: Crear instancia de una clase concreta apropiada.
        Dim target As _DaxsofSys = Nothing
        Return target
    End Function

    '''<summary>
    '''Una prueba de EmpresaAct
    '''</summary>
    <TestMethod()> _
    Public Sub EmpresaActTest()
        Dim target As _DaxsofSys = Create_DaxsofSys() ' TODO: Inicializar en un valor adecuado
        Dim actual As Empresa
        actual = target.EmpresaAct
        Assert.Inconclusive("Compruebe la exactitud de este método de prueba.")
    End Sub
End Class
