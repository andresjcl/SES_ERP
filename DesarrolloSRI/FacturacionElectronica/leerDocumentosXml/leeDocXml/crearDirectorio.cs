using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
using sesDocElectronicos;

namespace leeDocXml
{
    internal static class crearDirectorio
    {
        internal static void grabarRegistro(string Ruc, string nombre, string codigo, string direccion, string email, int tipoDoc, string tipoId)
        {
            try
            {
                Identificacion adc = new Identificacion(datosEmpresa.strConxAdcom);

                // ✅ 1. TIPO IDENTIFICACION: R, C o P (según el tipoId)
                adc.TipoIdentificacion = impFac.ObtenerPrefijoSegunTipo(tipoId);

                // ✅ 2. CEDULA IDENTIDAD RUC: el número completo
                adc.CedulaIdentidadRuc = Ruc;

                // ✅ 3. NOMBRES Y NOMBRE IMPRESION: en MAYÚSCULAS
                adc.Nombres = nombre.ToUpper();
                adc.NombreImpresion = nombre.ToUpper();

                // ✅ 4. DOMICILIO
                adc.Domicilio = direccion;

                // ✅ 5. CORREO ELECTRÓNICO
                adc.CorreoElectrónico = email;

                // ✅ 6. TIPO PERSONA: J (Jurídica) o N (Natural)
                adc.TipoPersona = "J";

                // ✅ 7. ES PROVEEDOR
                adc.EsProveedor = true;

                if (tipoDoc == 1)
                    adc.EsCliente = true;

                // ✅ 8. GENERAR EL CÓDIGO CORRECTO (máximo 11 caracteres)
                string codigoCorrecto = impFac.GenerarCodigoIdentificacion(Ruc, tipoId);

                // ✅ SI EL CÓDIGO QUE VIENE ES INCORRECTO, CORREGIRLO
                if (codigo != codigoCorrecto)
                {
                    Console.WriteLine($"Corrigiendo código: {codigo} -> {codigoCorrecto}");
                    codigo = codigoCorrecto;
                }

                // ✅ VERIFICAR SI EL CÓDIGO YA EXISTE
                if (ExisteCodigoEnDirectorio(codigo))
                {
                    int contador = 1;
                    string codigoUnico = codigo;
                    while (ExisteCodigoEnDirectorio(codigoUnico))
                    {
                        codigoUnico = codigo + contador.ToString();
                        contador++;
                        if (contador > 99) break;
                    }
                    codigo = codigoUnico;
                    Console.WriteLine($"Código duplicado, usando: {codigo}");
                }

                adc.Codigo = codigo;

                // ✅ 9. COD GRABO: usuario "impXML"
                adc.CodGrabo = "impXML";

                // ✅ 10. CREAR EL REGISTRO
                adc.Crear();

                // ✅ CREAR REGISTRO EN DaxDocProov
                CrearDaxDocProov(codigo);

                Console.WriteLine($"Proveedor creado: {codigo} para ID: {Ruc}, Tipo: {tipoId}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al grabar registro en directorio: {ex.Message}", ex);
            }
        }

        private static bool ExisteCodigoEnDirectorio(string codigo)
        {
            try
            {
                string ssql = "SELECT COUNT(*) FROM Identificacion WHERE Codigo = '" + codigo + "'";
                using (SqlCommand cmd = new SqlCommand(ssql, new SqlConnection(datosEmpresa.strConxAdcom)))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private static void CrearDaxDocProov(string idProveedor)
        {
            try
            {
                DaxDocProov docProov = new DaxDocProov(datosEmpresa.strConxAdcom);
                docProov.idProveedor = idProveedor;
                docProov.idDocProveedor = "01";
                docProov.opcDocAdcom = "FAP";
                docProov.AgruparIguales = "N";
                docProov.unCodigo = "N";
                docProov.Crear();

                Console.WriteLine($"DaxDocProov creado para: {idProveedor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creando DaxDocProov: {ex.Message}");
            }
        }
    }
}