using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DattCom;
namespace IvaRett 
{
    class DatosRetencion
    {

        internal string armarSqlLecturaRetencion(string suc, string tip, double idClave)
        {
            string ssql = "SELECT CodConcepto,DescripcionConcepto, Apl_valorapl,Apl_codbenef,nombreImpresion,Apl_sucapli, Apl_docapli, Apl_numapli,IdClaveDocApl,";
            ssql += "tra_Ventas, tra_Compras,tra_esanticipo,tra_escontable,tra_Banco,tra_CtasCobrar,tra_CtasPagar,";
            ssql += "tra_costo, tra_centroproduccion, tra_centrodistribucion, tra_empleado,Tra_Proyecto, tra_directorio, ";
            ssql += " Apl_fecha, Apl_docfecha, Idclaveapl, Idclaveaplapl, numLinApl, case when Apl_numapli > 0 then 1 else  0 end as TieneAplicacion, ";
            ssql += " convert(bit, case when isnull(espago,'C') <> 'E' then 1 else 0 end) as espago ";
            ssql += " FROM AdcApl left join identificacion on apl_codbenef = codigo";
            ssql += " where doc_sucursal = '" + suc + "' and opc_documento = '" + tip + "' and idclavedoc = " + idClave.ToString();

            return ssql;
        }


      
        static internal void GuardarDetalleDoc(ClassDoc.AdcDoc DatosDoc, DataGridView malla)
        {
            // 1. ELIMINAR registros anteriores de AdcSri9
            string sqlDelete = "DELETE FROM AdcSri9 WHERE SRI_SUCURSAL = @SUC AND SRI_DOCUMENTO = @DOC AND IdClaveDoc = @IDCLAVE";

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            using (SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn))
            {
                cmdDelete.Parameters.AddWithValue("@SUC", DatosDoc.Doc_sucursal);
                cmdDelete.Parameters.AddWithValue("@DOC", DatosDoc.Opc_documento);
                cmdDelete.Parameters.AddWithValue("@IDCLAVE", DatosDoc.IdClaveDoc);
                conn.Open();
                cmdDelete.ExecuteNonQuery();
            }

            // 2. INSERTAR en AdcSri9
            string sqlInsert = @"
        INSERT INTO AdcSri9 (
            SRI_SUCURSAL, SRI_DOCUMENTO, IdClaveDoc, SRI_NUMERORET,
            BaseIvaBienes, PorRetIvaBienes, ValorRetIvaBienes, CodigoRetIvaBienes,
            BaseIvaServicios, PorRetIvaServicios, ValorRetIvaServicios, CodigoRetIvaServicios,
            BaseRetFuente, PorRetFuente, ValorRetFuente, CodigoRetFuente,
            BaseRetFuente1, PorRetFuente1, ValorRetFuente1, CodigoRetFuente1,
            BasIvaExc, BasIvaCon, BasIvaCer,
            BasIvaExc1, BasIvaCer1, BasIvaCon1,
            Sri_tipoDoc,
            codDocSustento, numDocSustento, IdClaveDocSustento
        ) VALUES (
            @SUC, @DOC, @IDCLAVE, @NUMRET,
            @BIB, @PRIB, @VRIB, @CIB,
            @BIS, @PRIS, @VRIS, @CIS,
            @BRF, @PRF, @VRF, @CRF,
            @BRF1, @PRF1, @VRF1, @CRF1,
            @BIE, @BIC, @BIZ,
            @BIE1, @BIZ1, @BIC1,
            @TIPODOC,
            @DOCSOP, @NUMSOP, @IDCLAVESOP
        )";

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
            {
                // Inicializar valores - PRIMER CONCEPTO (312)
                decimal baseIvaBienes = 0;
                decimal porRetIvaBienes = 0;
                decimal valorRetIvaBienes = 0;
                string codRetIvaBienes = "";

                // IVA SERVICIOS
                decimal baseIvaServicios = 0;
                decimal porRetIvaServicios = 0;
                decimal valorRetIvaServicios = 0;
                string codRetIvaServicios = "";

                decimal baseRetFuente = 0;
                decimal porRetFuente = 0;
                decimal valorRetFuente = 0;
                string codRetFuente = "";

                // Inicializar valores - SEGUNDO CONCEPTO (303)
                decimal baseRetFuente1 = 0;
                decimal porRetFuente1 = 0;
                decimal valorRetFuente1 = 0;
                string codRetFuente1 = "";

                // Bases de IVA
                decimal baseIvaExcenta = 0;
                decimal baseIvaCon = 0;
                decimal baseIvaCero = 0;

                // Bases de IVA para segundo concepto
                decimal baseIvaExcenta1 = 0;
                decimal baseIvaCero1 = 0;
                decimal baseIvaCon1 = 0;

                // Datos del documento de soporte
                decimal idClaveSop = 0;
                string docSop = "";
                string numSop = "";

                // Contador para saber cuántos conceptos de RetFuente hay
                int contadorRetFuente = 0;

                // ========================================================
                // FLAG PARA SABER SI YA SE ASIGNÓ IVA SERVICIOS
                // ========================================================
                bool ivaServiciosAsignado = false;
                // ========================================================

                // Recorrer las filas de la malla
                foreach (DataGridViewRow row in malla.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tipoRet = row.Cells["TipoRetencion"].Value?.ToString() ?? "";
                    decimal baseRet = Convert.ToDecimal(row.Cells["BaseRetencion"].Value ?? 0);
                    decimal porcRet = Convert.ToDecimal(row.Cells["PorcRetencion"].Value ?? 0);
                    decimal valRet = Convert.ToDecimal(row.Cells["ValorRetencion"].Value ?? 0);
                    string codRet = row.Cells["CodigoRetencion"].Value?.ToString() ?? "";

                    // Obtener datos del documento de soporte
                    if (row.Cells["Doc_OpcDocumento"].Value != null &&
                        !string.IsNullOrEmpty(row.Cells["Doc_OpcDocumento"].Value.ToString()))
                    {
                        docSop = row.Cells["Doc_OpcDocumento"].Value.ToString();
                        numSop = row.Cells["Doc_Numero"].Value?.ToString() ?? "";

                        if (row.Cells["SRI_IdClaveDoc"].Value != null)
                        {
                            decimal.TryParse(row.Cells["SRI_IdClaveDoc"].Value.ToString(), out idClaveSop);
                        }
                    }

                    // Clasificar por tipo de retención
                    switch (tipoRet)
                    {
                        case "RetFuente":
                            contadorRetFuente++;

                            if (contadorRetFuente == 1)
                            {
                                // PRIMER CONCEPTO (312)
                                baseRetFuente = baseRet;
                                porRetFuente = porcRet;
                                valorRetFuente = Math.Round(valRet, 2);
                                codRetFuente = codRet;

                                if (row.Cells["BaseConIva"].Value != null)
                                    baseIvaCon = Convert.ToDecimal(row.Cells["BaseConIva"].Value);

                                if (row.Cells["BaseExcentaIva"].Value != null)
                                    baseIvaCero = Convert.ToDecimal(row.Cells["BaseExcentaIva"].Value);

                                baseIvaExcenta = 0;
                            }
                            else if (contadorRetFuente == 2)
                            {
                                // SEGUNDO CONCEPTO (303)
                                baseRetFuente1 = baseRet;
                                porRetFuente1 = porcRet;
                                valorRetFuente1 = Math.Round(valRet, 2);
                                codRetFuente1 = codRet;

                                if (row.Cells["BaseConIva"].Value != null)
                                    baseIvaCon1 = Convert.ToDecimal(row.Cells["BaseConIva"].Value);

                                if (row.Cells["BaseExcentaIva"].Value != null)
                                    baseIvaCero1 = Convert.ToDecimal(row.Cells["BaseExcentaIva"].Value);

                                baseIvaExcenta1 = 0;
                            }
                            break;

                        case "IvaBienes":
                            baseIvaBienes = baseRet;
                            porRetIvaBienes = porcRet;
                            valorRetIvaBienes = Math.Round(valRet, 2);
                            codRetIvaBienes = codRet;
                            break;

                        case "IvaServicios":
                            // ========================================================
                            // SOLO TOMAR EL PRIMER IvaServicios QUE TENGA CÓDIGO
                            // ========================================================
                            if (!ivaServiciosAsignado && !string.IsNullOrEmpty(codRet))
                            {
                                baseIvaServicios = baseRet;
                                porRetIvaServicios = porcRet;
                                valorRetIvaServicios = Math.Round(valRet, 2);
                                codRetIvaServicios = codRet;
                                ivaServiciosAsignado = true;

                                System.Diagnostics.Debug.WriteLine($"=== IVA SERVICIOS ASIGNADO ===");
                                System.Diagnostics.Debug.WriteLine($"Base: {baseIvaServicios}, Porc: {porRetIvaServicios}, Valor: {valorRetIvaServicios}, Cod: {codRetIvaServicios}");
                            }
                            // ========================================================
                            break;
                    }
                }

                // Si no hay código de retención, asignar vacío
                if (string.IsNullOrEmpty(codRetIvaBienes)) codRetIvaBienes = "";
                if (string.IsNullOrEmpty(codRetIvaServicios)) codRetIvaServicios = "";
                if (string.IsNullOrEmpty(codRetFuente)) codRetFuente = "";
                if (string.IsNullOrEmpty(codRetFuente1)) codRetFuente1 = "";

                // Ejecutar el INSERT
                cmdInsert.Parameters.AddWithValue("@SUC", DatosDoc.Doc_sucursal);
                cmdInsert.Parameters.AddWithValue("@DOC", DatosDoc.Opc_documento);
                cmdInsert.Parameters.AddWithValue("@IDCLAVE", DatosDoc.IdClaveDoc);
                cmdInsert.Parameters.AddWithValue("@NUMRET", DatosDoc.Doc_numero);

                // IVA BIENES
                cmdInsert.Parameters.AddWithValue("@BIB", baseIvaBienes);
                cmdInsert.Parameters.AddWithValue("@PRIB", porRetIvaBienes);
                cmdInsert.Parameters.AddWithValue("@VRIB", valorRetIvaBienes);
                cmdInsert.Parameters.AddWithValue("@CIB", codRetIvaBienes);

                // IVA SERVICIOS
                cmdInsert.Parameters.AddWithValue("@BIS", baseIvaServicios);
                cmdInsert.Parameters.AddWithValue("@PRIS", porRetIvaServicios);
                cmdInsert.Parameters.AddWithValue("@VRIS", valorRetIvaServicios);
                cmdInsert.Parameters.AddWithValue("@CIS", codRetIvaServicios);

                // RETENCIÓN FUENTE (PRIMER CONCEPTO)
                cmdInsert.Parameters.AddWithValue("@BRF", baseRetFuente);
                cmdInsert.Parameters.AddWithValue("@PRF", porRetFuente);
                cmdInsert.Parameters.AddWithValue("@VRF", valorRetFuente);
                cmdInsert.Parameters.AddWithValue("@CRF", codRetFuente);

                // RETENCIÓN FUENTE (SEGUNDO CONCEPTO)
                cmdInsert.Parameters.AddWithValue("@BRF1", baseRetFuente1);
                cmdInsert.Parameters.AddWithValue("@PRF1", porRetFuente1);
                cmdInsert.Parameters.AddWithValue("@VRF1", valorRetFuente1);
                cmdInsert.Parameters.AddWithValue("@CRF1", codRetFuente1);

                // BASES DE IVA
                cmdInsert.Parameters.AddWithValue("@BIE", baseIvaExcenta);
                cmdInsert.Parameters.AddWithValue("@BIC", baseIvaCon);
                cmdInsert.Parameters.AddWithValue("@BIZ", baseIvaCero);

                // BASES DE IVA 1
                cmdInsert.Parameters.AddWithValue("@BIE1", baseIvaExcenta1);
                cmdInsert.Parameters.AddWithValue("@BIZ1", baseIvaCero1);
                cmdInsert.Parameters.AddWithValue("@BIC1", baseIvaCon1);

                cmdInsert.Parameters.AddWithValue("@TIPODOC", DatosDoc.Doc_TipoDoc);
                cmdInsert.Parameters.AddWithValue("@DOCSOP", docSop);
                cmdInsert.Parameters.AddWithValue("@NUMSOP", numSop);
                cmdInsert.Parameters.AddWithValue("@IDCLAVESOP", idClaveSop);

                conn.Open();
                cmdInsert.ExecuteNonQuery();
            }

            // 3. Guardar en AdcApl
            GuardarAplicacion(DatosDoc, malla);
        }


        private Int32 Val(Object valor)
        {
            try
            {
                return Convert.ToInt16(valor);
            }
            catch { return 0; }
        }
        private static void GuardarAplicacion(ClassDoc.AdcDoc DatosDoc, DataGridView malla)
        {
            // Obtener el documento de soporte desde la malla
            string docSop = "";
            decimal numSop = 0;
            decimal idClaveSop = 0;

            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Doc_OpcDocumento"].Value != null &&
                    !string.IsNullOrEmpty(row.Cells["Doc_OpcDocumento"].Value.ToString()))
                {
                    docSop = row.Cells["Doc_OpcDocumento"].Value.ToString();

                    if (row.Cells["Doc_Numero"].Value != null)
                    {
                        decimal.TryParse(row.Cells["Doc_Numero"].Value.ToString(), out numSop);
                    }

                    if (row.Cells["SRI_IdClaveDoc"].Value != null)
                    {
                        decimal.TryParse(row.Cells["SRI_IdClaveDoc"].Value.ToString(), out idClaveSop);
                    }

                    break;
                }
            }

            // Si no hay documento de soporte, no guardar aplicación
            if (string.IsNullOrEmpty(docSop) || idClaveSop == 0)
                return;

            // 1. ELIMINAR aplicaciones anteriores
            string sqlDeleteApl = @"
        DELETE FROM AdcApl 
        WHERE Doc_sucursal = @SUC 
          AND Opc_documento = @DOC 
          AND Doc_numero = @NUM";

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            using (SqlCommand cmdDelete = new SqlCommand(sqlDeleteApl, conn))
            {
                cmdDelete.Parameters.AddWithValue("@SUC", DatosDoc.Doc_sucursal);
                cmdDelete.Parameters.AddWithValue("@DOC", DatosDoc.Opc_documento);
                cmdDelete.Parameters.AddWithValue("@NUM", DatosDoc.Doc_numero);
                conn.Open();
                cmdDelete.ExecuteNonQuery();
            }

            // 2. INSERTAR nueva aplicación
            string sqlInsertApl = @"
        INSERT INTO AdcApl (
            Doc_sucursal, Opc_documento, Doc_numero,
            Apl_sucapli, Apl_docapli, Apl_numapli,
            Apl_docfecha, Apl_fecha, Apl_valorapl, Apl_codbenef,
            IdClaveDoc, IdClaveDocApl,
            CodConcepto, DescripcionConcepto,
            tra_Ventas, tra_Compras, tra_CtasPagar,
            Idclaveapl, numLinApl
        ) VALUES (
            @SUC, @DOC, @NUM,
            @APL_SUC, @APL_DOC, @APL_NUM,
            @APL_DOCFECHA, @APL_FECHA, @APL_VALOR, @APL_CODBENEF,
            @IDCLAVE, @IDCLAVEAPL,
            @CODCONCEPTO, @DESCCONCEPTO,
            @TRAVENTAS, @TRACOMPRAS, @TRACTPAGAR,
            @IDCLAVEAPL2, @NUMLINAPL
        )";

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            using (SqlCommand cmdInsert = new SqlCommand(sqlInsertApl, conn))
            {
                decimal totalRetencion = Convert.ToDecimal(DatosDoc.Doc_valor);
                string codBenef = DatosDoc.Doc_codper;

                cmdInsert.Parameters.AddWithValue("@SUC", DatosDoc.Doc_sucursal);
                cmdInsert.Parameters.AddWithValue("@DOC", DatosDoc.Opc_documento);
                cmdInsert.Parameters.AddWithValue("@NUM", DatosDoc.Doc_numero);

                cmdInsert.Parameters.AddWithValue("@APL_SUC", DatosDoc.Doc_sucursal);
                cmdInsert.Parameters.AddWithValue("@APL_DOC", docSop);
                cmdInsert.Parameters.AddWithValue("@APL_NUM", numSop);

                cmdInsert.Parameters.AddWithValue("@APL_DOCFECHA", DatosDoc.Doc_fecha);
                cmdInsert.Parameters.AddWithValue("@APL_FECHA", DatosDoc.Doc_fecha);
                cmdInsert.Parameters.AddWithValue("@APL_VALOR", totalRetencion);
                cmdInsert.Parameters.AddWithValue("@APL_CODBENEF", codBenef);

                cmdInsert.Parameters.AddWithValue("@IDCLAVE", DatosDoc.IdClaveDoc);
                cmdInsert.Parameters.AddWithValue("@IDCLAVEAPL", idClaveSop);

                cmdInsert.Parameters.AddWithValue("@CODCONCEPTO", "");
                cmdInsert.Parameters.AddWithValue("@DESCCONCEPTO", "RETENCION");

                // ========================================================
                // tra_Compras = 1, tra_CtasPagar = 1 (para proveedores)
                // ========================================================
                cmdInsert.Parameters.AddWithValue("@TRAVENTAS", 0);
                cmdInsert.Parameters.AddWithValue("@TRACOMPRAS", 0);
                cmdInsert.Parameters.AddWithValue("@TRACTPAGAR", 0);

                cmdInsert.Parameters.AddWithValue("@IDCLAVEAPL2", idClaveSop);
                cmdInsert.Parameters.AddWithValue("@NUMLINAPL", 1);

                conn.Open();
                cmdInsert.ExecuteNonQuery();
            }
        }

        internal static void moverDatosAclase(MantRetencion formulario)
        {
            formulario.DatosDocumento.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            formulario.DatosDocumento.Doc_sucursal = DattCom.datosEmpresa.sucursal;
            formulario.DatosDocumento.Doc_Bodega = "";
            formulario.DatosDocumento.PuntoVta = "";
            formulario.DatosDocumento.Doc_NroIdDoc = formulario.txtNroID.Text;
            formulario.DatosDocumento.Opc_documento = formulario.idDocumentoActual.Tipo;
            formulario.DatosDocumento.Doc_docnombre = formulario.cmbDocumento.Text;
            formulario.DatosDocumento.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            formulario.DatosDocumento.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            formulario.DatosDocumento.Doc_codper = formulario.codCliente;
            formulario.DatosDocumento.Doc_CiRuc = formulario.txtcedula.Text;
            formulario.DatosDocumento.Doc_NombreImp = formulario.txtnombrecliente.Text;
            formulario.DatosDocumento.Doc_Direccion = formulario.txtdireccion.Text;
            formulario.DatosDocumento.Doc_Telefono1 = formulario.txttelefono.Text;
            formulario.DatosDocumento.Doc_detalle = formulario.txtDetalle.Text;
            formulario.DatosDocumento.Doc_venabre = "";

            // ========================================================
            // OBTENER DOCUMENTO DE SOPORTE DESDE LA MALLA
            // ========================================================
            string docSop = "";
            decimal numSop = 0;
            decimal idClaveSop = 0;

            if (formulario.malla.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in formulario.malla.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["Doc_OpcDocumento"].Value != null &&
                        !string.IsNullOrEmpty(row.Cells["Doc_OpcDocumento"].Value.ToString()))
                    {
                        docSop = row.Cells["Doc_OpcDocumento"].Value.ToString();

                        if (row.Cells["Doc_Numero"].Value != null)
                        {
                            decimal.TryParse(row.Cells["Doc_Numero"].Value.ToString(), out numSop);
                        }

                        if (row.Cells["SRI_IdClaveDoc"].Value != null)
                        {
                            decimal.TryParse(row.Cells["SRI_IdClaveDoc"].Value.ToString(), out idClaveSop);
                        }

                        if (!string.IsNullOrEmpty(docSop) && idClaveSop > 0)
                            break;
                    }
                }
            }

            formulario.DatosDocumento.Doc_DocSop = docSop;
            formulario.DatosDocumento.Doc_NumSop = numSop;
            formulario.DatosDocumento.IdClaveDocSop = idClaveSop;
            // ========================================================

            // ========================================================
            // VALORES DE LA RETENCIÓN (NO de la factura)
            // ========================================================
            formulario.DatosDocumento.Doc_porceniva = 0;      // No toma de factura
            formulario.DatosDocumento.Doc_valoriva = 0;       // No toma de factura
            formulario.DatosDocumento.Doc_totciva = 0;        // No toma de factura
            formulario.DatosDocumento.Doc_totsiva = 0;        // No toma de factura
            formulario.DatosDocumento.Doc_TotSerCIva = 0;     // No toma de factura
            formulario.DatosDocumento.Doc_TotSerSIva = 0;     // No toma de factura
            formulario.DatosDocumento.BaseImp1 = 0;           // No toma de factura
            formulario.DatosDocumento.PorcImp1 = 0;           // No toma de factura
            formulario.DatosDocumento.BaseImp2 = 0;
            formulario.DatosDocumento.BaseImp3 = 0;
            formulario.DatosDocumento.PorcImp2 = 0;
            formulario.DatosDocumento.PorcImp3 = 0;
            formulario.DatosDocumento.ValorImp1 = 0;
            formulario.DatosDocumento.ValorImp2 = 0;
            formulario.DatosDocumento.ValorImp3 = 0;
            // ========================================================

            // Total del documento (valor de la retención)
            formulario.DatosDocumento.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            formulario.DatosDocumento.Doc_valorabon = 0;
            formulario.DatosDocumento.Doc_Contado = 0;

            formulario.DatosDocumento.AuxVar9 = formulario.txtCorreElectronico.Text;
            formulario.DatosDocumento.Doc_Hora = DateTime.Now;
            formulario.DatosDocumento.Doc_NroLoteDoc = "";
            formulario.DatosDocumento.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;

            // ========================================================
            // NO debe tener autorización de la FAP
            // ========================================================
            formulario.DatosDocumento.NroAutorizacionSri = "";
            formulario.DatosDocumento.Adi_NroAutSri = "";
            formulario.DatosDocumento.Adi_SustTrib = "";
            formulario.DatosDocumento.Adi_CodigoNSR = "";
            // ========================================================

            formulario.DatosDocumento.Doc_TipoDoc = formulario.idDocumentoActual.familia;
            formulario.DatosDocumento.Doc_FechaEfe = formulario.DatosDocumento.Doc_fecha;
            formulario.DatosDocumento.Doc_extension = "";
            formulario.DatosDocumento.Doc_codusu = DatosUsuario.codigo;
            formulario.DatosDocumento.Doc_Estado = 1;
            formulario.DatosDocumento.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            formulario.DatosDocumento.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            formulario.DatosDocumento.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            formulario.DatosDocumento.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            formulario.DatosDocumento.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            formulario.DatosDocumento.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            formulario.DatosDocumento.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            formulario.DatosDocumento.Doc_Adicional2 = 0;
            formulario.DatosDocumento.Doc_NumeroExterno = 0;
            formulario.DatosDocumento.Doc_FechaModifica = DateTime.Now;
            formulario.DatosDocumento.Cobranza = "";
            formulario.DatosDocumento.doc_BancoOrigen = "";
            formulario.DatosDocumento.doc_NumeroCheque = "";
            formulario.DatosDocumento.doc_Anticipo = false;
            formulario.DatosDocumento.doc_BancoDestino = "";
        }


    }
}
