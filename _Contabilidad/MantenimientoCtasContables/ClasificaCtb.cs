

// Public Class ClasificaCtb
// Public Function Cargar() As ColClasificador
// Dim RsAux As SqlDataReader
// Dim ConxAdcom As New SqlConnection(datosEmpresa.strConxAdcom)
// Dim Elclasificador As New clasificador
// Dim CargarAux As New ColClasificador
// ConxAdcom.Open()
// Dim comm As New SqlCommand("select * from AdcClasfctb where status <> 0 AND EsClasificador = 1 ", ConxAdcom)
// RsAux = comm.ExecuteReader()
// With RsAux
// Do Until RsAux.Read = False
// Elclasificador = New clasificador
// CargarAux.Add(Convert.ToInt32(.Item("IDCLAVE")), Convert.ToBoolean(.Item("Status")), .Item("origenvalores").ToString(), .Item("campodia").ToString(), .Item("campotra").ToString(), Convert.ToBoolean(.Item("regPorConcepto")), .Item("Nombre").ToString(), .Item("TipoDirectorio").ToString(), .Item("GrupoDirectorio").ToString(), "C" + .Item("Nombre").ToString())
// Loop
// End With
// Cargar = CargarAux
// RsAux.Close()
// ConxAdcom.Close()
// RsAux = Nothing
// ConxAdcom.Dispose()
// End Function
// End Class