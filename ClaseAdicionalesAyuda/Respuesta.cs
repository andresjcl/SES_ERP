// Clases para resultados (las mismas que antes)
public class ResultadoConsulta
{
    public bool Exitoso { get; set; }
    public DatosCiudadano Datos { get; set; }
    public string Error { get; set; }

    public ResultadoConsulta()
    {
        Datos = new DatosCiudadano();
    }
}

public class DatosCiudadano
{
    public string Cedula { get; set; }
    public string NombresCompletos { get; set; }
    public string CondicionCiudadano { get; set; }
    public string Sexo { get; set; }
    public string FechaNacimiento { get; set; }
    public string LugarNacimiento { get; set; }
    public string Nacionalidad { get; set; }
    public string EstadoCivil { get; set; }
    public string Conyuge { get; set; }
    public string Domicilio { get; set; }
    public string Provincia { get; set; }
    public string Canton { get; set; }
    public int Edad { get; set; }
    public string Profesion { get; set; }
}

// Clases para deserialización JSON
public class RespuestaApi
{
    public bool ok { get; set; }
    public Data data { get; set; }
}

public class Data
{
    public string identificacion { get; set; }
    public string nombres { get; set; }
    public string apellidos { get; set; }
    public string condicionCiudadano { get; set; }
    public string fechaNacimiento { get; set; }
    public string direccion { get; set; }
    public string estadoCivil { get; set; }
    public string nombreConyuge { get; set; }
    public string apellidoConyuge { get; set; }
    public Canton canton { get; set; }
    public Provincia provincia { get; set; }
    public int edad { get; set; }
    public string profesion { get; set; }
}

public class Canton
{
    public string nombre { get; set; }
}

public class Provincia
{
    public string nombre { get; set; }
}