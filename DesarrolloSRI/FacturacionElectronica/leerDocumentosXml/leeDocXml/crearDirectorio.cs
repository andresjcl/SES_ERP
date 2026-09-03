using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
using sesDocElectronicos;
using utilBasDatos;

namespace leeDocXml
{
    internal static class crearDirectorio
    {
        internal static void grabarRegistro(string Ruc, string nombre, string codigo, string direccion, string email, int tipoDoc, string tipoId)
        {
            try
            {
                // ✅ 1. VERIFICAR SI EL PROVEEDOR YA EXISTE POR RUC
                string sqlBuscar = "SELECT Codigo FROM Identificacion WHERE CedulaIdentidadRuc = '" + Ruc + "'";
                DataTable dtExistente = utilBasDatos.utilBasDatos.leerTablas(sqlBuscar, datosEmpresa.strConxAdcom);

                if (dtExistente != null && dtExistente.Rows.Count > 0)
                {
                    string codigoExistente = dtExistente.Rows[0]["Codigo"].ToString();
                    Console.WriteLine($"✅ El proveedor ya existe con código: {codigoExistente}");

                    // ✅ ACTUALIZAR DATOS DEL PROVEEDOR EXISTENTE
                    ActualizarProveedor(codigoExistente, Ruc, nombre, direccion, email);

                    // ✅ SI EL CÓDIGO EN LA BD ES DIFERENTE, ACTUALIZAR txtCodDirectorioAdcom
                    if (codigo != codigoExistente)
                    {
                        // El código se actualizará en el formulario después
                        Console.WriteLine($"⚠️ Código en formulario ({codigo}) vs BD ({codigoExistente})");
                    }
                    return; // Salir, ya existe
                }

                // ✅ 2. GENERAR EL CÓDIGO CORRECTO
                string codigoCorrecto = impFac.GenerarCodigoIdentificacion(Ruc, tipoId);

                // ✅ SI EL CÓDIGO QUE VIENE ES INCORRECTO, CORREGIRLO
                if (codigo != codigoCorrecto)
                {
                    Console.WriteLine($"Corrigiendo código: {codigo} -> {codigoCorrecto}");
                    codigo = codigoCorrecto;
                }

                // ✅ 3. VERIFICAR SI EL CÓDIGO YA EXISTE (por si acaso)
                if (ExisteCodigoEnDirectorio(codigo))
                {
                    // Si el código ya existe, buscar el código existente por RUC
                    string sqlBuscarPorRuc = "SELECT Codigo FROM Identificacion WHERE CedulaIdentidadRuc = '" + Ruc + "'";
                    DataTable dtRuc = utilBasDatos.utilBasDatos.leerTablas(sqlBuscarPorRuc, datosEmpresa.strConxAdcom);
                    if (dtRuc != null && dtRuc.Rows.Count > 0)
                    {
                        string codigoExistente = dtRuc.Rows[0]["Codigo"].ToString();
                        Console.WriteLine($"✅ El proveedor ya existe con código: {codigoExistente}");
                        ActualizarProveedor(codigoExistente, Ruc, nombre, direccion, email);
                        return;
                    }

                    // Si no existe por RUC pero sí por código, generar código único
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

                // ✅ 4. CREAR NUEVO REGISTRO
                Identificacion adc = new Identificacion(datosEmpresa.strConxAdcom);

                adc.TipoIdentificacion = impFac.ObtenerPrefijoSegunTipo(tipoId);
                adc.CedulaIdentidadRuc = Ruc;
                adc.Nombres = nombre.ToUpper();
                adc.NombreImpresion = nombre.ToUpper();
                adc.Domicilio = direccion;
                adc.CorreoElectrónico = email;
                adc.TipoPersona = "J";
                adc.EsProveedor = true;
                if (tipoDoc == 1)
                    adc.EsCliente = true;
                adc.Codigo = codigo;
                adc.CodGrabo = "impXML";

                adc.Crear();

                // ✅ 5. CREAR REGISTRO EN DaxDocProov
                CrearDaxDocProov(codigo);

                Console.WriteLine($"✅ Proveedor creado: {codigo} para ID: {Ruc}, Tipo: {tipoId}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al grabar registro en directorio: {ex.Message}", ex);
            }
        }
        /// <summary>
        /// Actualiza los datos de un proveedor existente
        /// </summary>
        private static void ActualizarProveedor(string codigo, string Ruc, string nombre, string direccion, string email)
        {
            try
            {
                string sqlUpdate = $@"
                    UPDATE Identificacion SET 
                        Nombres = '{nombre.ToUpper()}',
                        NombreImpresion = '{nombre.ToUpper()}',
                        Domicilio = '{direccion}',
                        CorreoElectrónico = '{email}'
                    WHERE Codigo = '{codigo}'";

                utilBasDatos.utilBasDatos.ejecutarComandoSql(sqlUpdate, datosEmpresa.strConxAdcom);
                Console.WriteLine($"✅ Proveedor actualizado: {codigo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error al actualizar proveedor: {ex.Message}");
            }
        }

        private static bool ExisteCodigoEnDirectorio(string codigo)
        {
            try
            {
                string ssql = "SELECT COUNT(*) FROM Identificacion WHERE Codigo = '" + codigo + "'";
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ssql, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
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
                // Verificar si ya existe en DaxDocProov
                string sqlVerificar = "SELECT COUNT(*) FROM DaxDocProov WHERE idProveedor = '" + idProveedor + "'";
                DataTable dt = utilBasDatos.utilBasDatos.leerTablas(sqlVerificar, datosEmpresa.strConxAdcom);

                if (dt != null && dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    Console.WriteLine($"✅ DaxDocProov ya existe para: {idProveedor}");
                    return;
                }

                DaxDocProov docProov = new DaxDocProov(datosEmpresa.strConxAdcom);
                docProov.idProveedor = idProveedor;
                docProov.idDocProveedor = "01";
                docProov.opcDocAdcom = "FAP";
                docProov.AgruparIguales = "N";
                docProov.unCodigo = "N";
                docProov.Crear();

                Console.WriteLine($"✅ DaxDocProov creado para: {idProveedor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error creando DaxDocProov: {ex.Message}");
            }
        }
    }
}