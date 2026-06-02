using ClassFelec;
using DattCom;
using DaxDocElectronicos;
using GeneradorFacturaPDF;
using System;
using System.Data;

namespace SolicitudAutSRI
{

    public class generacionPdf
    {
        private enum TiposEmisión
        {
            NORMAL = 1,
            NODISPONIBLE = 2,
        }
        private enum TiposAmbiente
        {
            PRUEBA = 1,
            PRODUCCION = 2,
        }


        private string pathFile = "";
        public short TipoDeAmbiente = Convert.ToInt16(TiposAmbiente.PRODUCCION);
        public short tipoDeEmision = Convert.ToInt16(TiposEmisión.NORMAL);
        private string pathBmp = "";



        private Feutilidad util = new Feutilidad();
        public string RutaGenerada { get; private set; }

        public string generarPdf(string suc_comprobante, string tipo_comprobante, string numero_comprobante, double idclaveDoc, ref string PathCpbte, string claseDoc,string empRuc, short empDigitosPrecios, string empPathAppl, short EmisionTipo)
        {
            try
            {     

                // 1. Leer datos desde base
                string ssql = this.util.strLeerDocumento(suc_comprobante, tipo_comprobante, idclaveDoc.ToString(), claseDoc);
                DataTable dtra = SolicitarAutorizacionSRI.daxDatos.leerDatos(ssql, datosEmpresa.strConxAdcom);

                if (dtra.Rows.Count == 0)
                    return "ERROR: NO EXISTE EL DOCUMENTO";

                if (!this.iniciarVariablesExternas())
                    return "ERROR: NO SE HA CONFIGURADO LA EMISION DE COMPROBANTES ELECTRONICOS";

                this.tipoDeEmision = EmisionTipo;

                DataRow row = dtra.Rows[0];

                // 2. Generar clave de acceso
                string tipoDocAdc = row["Doc_TipoDoc"].ToString();
                DateTime fecha = Convert.ToDateTime(row["Doc_fecha"]);
                string tipoComprobanteSri = this.util.tipoComprobanteSri(tipoDocAdc);
                string numeroDoc = row["Doc_Numero"].ToString();
                string ciruc = row["Doc_ciruc"].ToString();
                string nroIdDoc = row["Doc_NroIdDoc"].ToString();
                string claveDocF = row["claveAcceso"].ToString();
              
                FacturaElectronica factura = new FacturaElectronica
                {
                    RazonSocial = datosEmpresa.nomEmpresa,
                    RucEmisor = empRuc,
                    NombreCliente = row["Doc_NombreImp"].ToString(),
                    IdentificacionCliente = row["Doc_CiRuc"].ToString(),
                    DireccionCliente = row["Doc_Direccion"].ToString(),
                    EmailCliente = row["CorreoElectrónico"].ToString(),
                    TelefonoCliente = row["Doc_Telefono1"].ToString(),
                    FechaEmision = fecha,
                    NumeroFactura = nroIdDoc+"-"+numeroDoc,
                    NumeroAutorizacion = row["NroAutorizacionSri"].ToString(),                    
                    FechaAutorizacion = Convert.ToDateTime(row["fechaAutorizacion"]), // o leer de base si ya está autorizada
                    Ambiente = (this.TipoDeAmbiente == 2) ? "Producción" : "Pruebas",
                    Emision = (this.tipoDeEmision == 2) ? "Contingencia" : "Normal",
                    ClaveAcceso = row["claveAcceso"].ToString(),
                    DireccionMatriz = datosEmpresa.Emp_Dirección,
                    DireccionSucursal = datosEmpresa.Emp_Dirección,
                    //Estudiantes = row["Doc_InfoAdicional"].ToString(),
                    Subtotal = Convert.ToDecimal(row["subtotal"]),
                    SubtotalNoIVA = 0,
                    SubtotalExentoIVA = 0,
                    SubtotalSinImpuestos = Convert.ToDecimal(row["subtotal"]),
                    Descuento = Convert.ToDecimal(row["totalDescuento"]),
                    ICE = 0,
                    Propina = 0,
                    ValorTotal = Convert.ToDecimal(row["Doc_valor"]),
					//ValorPagar = Convert.ToDecimal(row["Doc_ValorPagar"]),
					//    Detalles = new List<DetalleFactura>() // llena con otro SELECT si es necesario
				};

				//foreach (DataRow fila in dtra.Rows)
				//{
				//    factura.Detalles.Add(new DetalleFactura
				//    {
				//        CodigoPrincipal = fila["Tra_Codigo"].ToString(),
				//        CodigoAuxiliar = fila["codigoAuxiliar"].ToString(),
				//        Cantidad = Convert.ToInt32(fila["Tra_cantidad"]),
				//        Descripcion = fila["Tra_nombre"].ToString(),
				//        PrecioUnitario = Convert.ToDecimal(fila["Tra_precuni"]),
				//        Descuento = Convert.ToDecimal(fila["desctoUni"])
				//    });
				//}

				// (OPCIONAL) Llenar Detalles con otro query si no están en el mismo DataTable

				// 4. Ruta destino
				var fel = new ClassFelec.AdcFelec(datosEmpresa.strConxAdcom);
                fel = ClassFelec.AdcFelec.Buscar("");

                string rutaNombre = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + claveDocF + ".PDF";

                //string nombrePdf = claveGenerada + ".pdf";
                // string rutaPdf = Path.Combine(empPathAppl, nombrePdf);
                string rutaPdf = rutaNombre;
                PathCpbte = rutaPdf;

                // 5. Generar PDF
                FacturaPDFBuilder builder = new FacturaPDFBuilder();
                builder.GenerarPDF(rutaPdf, factura);

                return "OK";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }





        //public generacionPdf(string baseDatos, string conxAdcom, string conxIvaret, string conIniSis, string conxDaxpro, short codEmpresa, string pathServer)
        //{
        //    // 1. Obtener los datos de la factura desde la base de datos
        //    var datosFactura = ObtenerDatosFactura(conxAdcom);

        //    // 2. Crear ruta de destino
        //    string nombreArchivo = $"FA_{DateTime.Now:yyyyMMddHHmmss}.pdf";
        //    string rutaPdf = Path.Combine(pathServer, nombreArchivo);
        //    RutaGenerada = rutaPdf;

        //    // 3. Generar PDF
        //    var generador = new FacturaPDFBuilder();
        //    generador.GenerarPDF(rutaPdf, datosFactura);
        //}

        //     public string generarPdf(string suc_comprobante, string tipo_comprobante, string numero_comrpobante, double idclaveDoc, ref string PathCpbte, string empRuc, short empDigitosPrecios, string empPatAppl, short EmisionTipo)
        //     {
        //         string str1 = "";
        //         try
        //{
        //             string ssql = this.util.strLeerDocumento(suc_comprobante, tipo_comprobante, idclaveDoc.ToString());
        //             //SolicitarAutorizacionSRI.daxDatos daxDatos = new SolicitarAutorizacionSRI.daxDatos();
        //             //DataTable dtra = daxDatos.leerDatos(ssql, datosEmpresa.strConxAdcom);
        //             DataTable dtra = SolicitarAutorizacionSRI.daxDatos.leerDatos(ssql, datosEmpresa.strConxAdcom);
        //             if (dtra.Rows.Count == 0)
        //                 return "ERROR: NO EXISTE EL DOCUMENTO";
        //             if (!this.iniciarVariablesExternas())
        //                 return "ERROR: NO SE HA CONFIGURADO LA EMISION DE COMPROBANTES ELECTRONICOS";
        //             this.tipoDeEmision = EmisionTipo;
        //             DataRow row = dtra.Rows[0];
        //             string str2 = "";
        //             string tipoDocAdc = row["Doc_TipoDoc"].ToString();
        //             str1 = genearClaveDocumentoElct.generar_clave_FueraDeLinea(Convert.ToDateTime(row["Doc_fecha"]), this.util.tipoComprobanteSri(tipoDocAdc), this.tipoDeEmision.ToString(), row["Doc_Numero"].ToString(), this.TipoDeAmbiente.ToString(), row["Doc_ciruc"].ToString(), row["Doc_NroIdDoc"].ToString(), idclaveDoc, empRuc) : genearClaveDocumentoElct.generar_clave_accesoNormal(Convert.ToDateTime(row["Doc_fecha"]), this.util.tipoComprobanteSri(tipoDocAdc), empRuc, this.TipoDeAmbiente, row["Doc_NroIdDoc"].ToString(), numero_comrpobante, this.codigo_numerico, this.tipoDeEmision, this.strConxadcom);
        //             //enviarDocumentoS enviarDocumentoS = this;
        //             pathFile = pathFile + str1 + ".XML";

        //         }
        //catch (Exception)
        //{

        //	throw;
        //}
        //     }

        private bool iniciarVariablesExternas()
        {
            AdcFelec adcFelec1 = new AdcFelec(datosEmpresa.strConxAdcom);
            AdcFelec adcFelec2 = AdcFelec.Buscar("");
            if (adcFelec2 == null)
                return false;
            this.pathFile = adcFelec2.pathCpbGenerados;
            this.pathBmp = adcFelec2.pathCpbAutorizados;
            if (!adcFelec2.ambienteEnProduccion)
                this.TipoDeAmbiente = Convert.ToInt16((object)TiposAmbiente.PRUEBA);
            adcFelec1 = (AdcFelec)null;
            return true;
        }
        //private FacturaElectronica ObtenerDatosFactura(string conexion)
        //{
        //    // Aquí simulas o conectas a SQL Server para traer los datos de la factura
        //    // Este es un ejemplo con datos quemados (simulados)
        //    return new FacturaElectronica
        //    {
        //        RazonSocial = "CASA DE LA CULTURA ECUATORIANA BENJAMIN CARRION N°2",
        //        RucEmisor = "1705664017001",
        //        NombreCliente = "JOSÈ ANDRÈS CABEZAS LLIGUIN",
        //        IdentificacionCliente = "1721794616001",
        //        DireccionCliente = "CHEDIACK Y AV ELOY ALFARO LOTE 9",
        //        EmailCliente = "andresjcl@gmail.com",
        //        TelefonoCliente = "0991068007",
        //        FechaEmision = new DateTime(2025, 7, 15),
        //        NumeroFactura = "002-002-000002871",
        //        NumeroAutorizacion = "1507202501170566401700120020020000028719846951119",
        //        FechaAutorizacion = DateTime.Now,
        //        Ambiente = "Producción",
        //        Emision = "Normal",
        //        ClaveAcceso = "1507202501170566401700120020020000028719846951119",
        //        DireccionMatriz = "OE 6 LT4 S54B /GUAMANÍ / QUITO / PICHINCHA",
        //        DireccionSucursal = "CALLE TERCERA Y SABANILLA",
        //        Estudiantes = "ESTUDIANTE CRISTOPHER EMILIO CABEZAS GUAMÁN - CUARTO DE BÁSICA\nESTUDIANTE SEBASTIÁN ANDRÉS CABEZAS GUAMÁN - NOVENO DE BÁSICA",
        //        Detalles = new System.Collections.Generic.List<DetalleFactura>
        //        {
        //            new DetalleFactura
        //            {
        //                CodigoPrincipal = "P85210101",
        //                CodigoAuxiliar = "-",
        //                Cantidad = 1,
        //                Descripcion = "ACTIVIDADES DE SERVICIOS EDUCATIVOS SECCION SECUNDARIA",
        //                PrecioUnitario = 145.00M,
        //                Descuento = 0.00M
        //            }
        //        },
        //        Subtotal = 145.00M,
        //        SubtotalNoIVA = 0.00M,
        //        SubtotalExentoIVA = 0.00M,
        //        SubtotalSinImpuestos = 145.00M,
        //        Descuento = 0.00M,
        //        ICE = 0.00M,
        //        Propina = 0.00M,
        //        ValorTotal = 145.00M,
        //        ValorPagar = 145.00M
        //    };
        //}
    }
}
