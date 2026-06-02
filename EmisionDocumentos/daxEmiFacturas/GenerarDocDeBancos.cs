using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using DattCom;
namespace DctosEmi
{
   public class GeneraEgrCtasCorrientes
    {
        string RubrolRol = "";
        string Concepto = "";
        string tipoDocumento = "";
        string NombreConcepto = "";
        Int32 RolPeriodo = 0;
        double totalDocumento = 0;
        DateTime FechaDelDocumento;
        sesSys.OpcDoc propiedadesDoc = new sesSys.OpcDoc();
        ClassDoc.idDocumento idDocumentoActual = new ClassDoc.idDocumento();

        public bool existenEgresos = false;

        public bool existenCtasCorrientes(Int32 periodoRol)
        {
            RolPeriodo = periodoRol;
            obtenerPreferencias();
            try 
            {
                if (Convert.ToInt32(RubrolRol) == 0) return false;
            }
            catch { return false; }
            if (Concepto.Length == 0 || tipoDocumento.Length == 0) return false;

            SqlDataReader drr = SqlDatos.leerBaseAdcom("select Opc_nombre from adcopc where Opc_documento ='" +Concepto+"'");
            if (drr.Read()) NombreConcepto = drr["opc_nombre"].ToString();
            drr.Close();

            SqlDataReader dr = SqlDatos.leerBaseAdcom("select sum( liq_valor) as total from rolliq where Liq_Valor > 0 and  Liq_Periodo = " + periodoRol + " and Liq_CodigoConcepto = " + RubrolRol);
            if (dr.Read()==false) { dr.Close(); return false; }
            else { totalDocumento = Convert.ToDouble(dr["total"]);}
            dr.Close();
            string ssql = "select top 1 doc_valor from adcdoc where Doc_NroLoteDoc = '" + RolPeriodo.ToString() + "' and Doc_codper = '0'";
            SqlDataReader dr2 = SqlDatos.leerBaseAdcom(ssql);
            existenEgresos = dr2.HasRows;
            dr2.Close();
            return true;
        }
        public void GenerarEgresoCtaCteRol(DateTime fechaDocumento)
        {
            FechaDelDocumento = fechaDocumento;
            string lugar = "";
            propiedadesDoc.Cargar(ref tipoDocumento, ref lugar);
            ClassDoc.controlNumeracion cnum = new ClassDoc.controlNumeracion();
            idDocumentoActual = new ClassDoc.idDocumento
            {
                familia = propiedadesDoc.TipoDoc,
                fecha = FechaDelDocumento,
                numero = 0,
                Serie = "",
                Sucursal = datosEmpresa.suc,
                Tipo = tipoDocumento
            };
            idDocumentoActual.numero = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom);
            GrabarDocumento();
        }
        internal void GrabarDocumento()
        {
            ClassDoc.AdcDoc datADCDOC = new ClassDoc.AdcDoc(datosEmpresa.strConxAdcom)
            {
                //datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
                Doc_sucursal = idDocumentoActual.Sucursal,
                Doc_Bodega = "",
                //datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;
                Opc_documento = idDocumentoActual.Tipo,
                Doc_docnombre = propiedadesDoc.nombre,
                Doc_numero = Convert.ToDecimal(idDocumentoActual.numero),
                Doc_fecha = idDocumentoActual.fecha,
                Doc_codper = "0",
                Doc_CiRuc = "0",
                Doc_NombreImp = "Pagos múltiples nómina",
                Doc_Direccion = "",
                Doc_Telefono1 = "",
                Doc_detalle = "Pago ctas. corrientes nómina período " + RolPeriodo,
                //if (cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = "" + cmbVendedor.SelectedValue.ToString();

                Doc_DocSop = "",
                Doc_NumSop = 0,
                IdClaveDocSop = 0,

                Doc_valor = Convert.ToDecimal(totalDocumento),
                AuxVar9 = "",
                Doc_Hora = DateTime.Now,

                Doc_NroLoteDoc = RolPeriodo.ToString(),
                //datADCDOC.Doc_NroIdDoc = txtNroID.Text;
                //datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
                //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
                //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
                //datADCDOC.Adi_SustTrib = DatSustento.BoundText
                //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
                //datADCDOC.Doc_docnombre = "";
                Doc_TipoDoc = idDocumentoActual.familia,
                Doc_FechaEfe = idDocumentoActual.fecha,
                Doc_extension = "",
                Doc_codusu = DatosUsuario.codigo,
                //datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
                //datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
                //datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
                //datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
                //datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;            //datADCDOC.Doc_valorabon = totalesDocumento.ValorCon;
                //datADCDOC.Doc_DepDes = "";
                //datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
                //datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
                //datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
                Doc_TotArtSIva = Convert.ToDecimal(totalDocumento),
                //datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
                //datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
                //datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
                //datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
                Doc_Estado = 1,
                Doc_Oculto = propiedadesDoc.ClaveOculto,
                Doc_Contabilidad = propiedadesDoc.ClaveContable,
                Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco),
                Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario),
                Doc_Ventas = 0,
                Doc_Compras = 0,
                Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo),
                Doc_Adicional2 = 0,
                Doc_NumeroExterno = 0,
                Doc_FechaModifica = DateTime.Now,
                Cobranza = "",
                doc_BancoOrigen = "",
                doc_NumeroCheque = "",
                doc_Anticipo = false,

                //if (Estransferencia)
                //{
                //    datADCDOC.doc_BancoDestino = cmbCtasBacoDestino.SelectedValue.ToString();
                //}
                //else
                doc_BancoDestino = ""
            };
            string resp = datADCDOC.Crear();
            if (resp.Substring(0, 3) != "ERR")
            {
                GuardarDetalleDoc(datADCDOC);
            }
        }
        public void GuardarDetalleDoc(ClassDoc.AdcDoc DatosDoc)
        {
            string codigo = "";
            bool clipro = true;
            string solocodigo = "";
            string ssql = "select * from adcaplrol where ValorAbono > 0 and  Liq_Periodo = " + RolPeriodo + " and Liq_CodigoConcepto = '" + RubrolRol + "'";
            DataTable DatosAplRol = SqlDatos.leerTablaAdcom(ssql);

            string codsql = " select * FROM AdcApl WHERE doc_sucursal='" + DatosDoc.Doc_sucursal + "' and opc_documento='" + DatosDoc.Opc_documento + "' and idclavedoc=" + DatosDoc.IdClaveDoc;
            SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom);
            DataTable DocAdcApl = new DataTable();
            da.Fill(DocAdcApl);

            foreach (DataRow rowDocAdcApl in DocAdcApl.Rows) { rowDocAdcApl.Delete(); }

            int I = 0;

            foreach (DataRow rowAplRol in DatosAplRol.Rows)
            {
                directMnt.DirectorioAlex alx = new directMnt.DirectorioAlex();
                codigo = rowAplRol["IdEmpleado"].ToString();
                alx.CargarAlex(ref codigo, ref clipro, ref solocodigo);
                //                using (SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom))
                {
                    {
                        DataRow NewRowAdcApl = DocAdcApl.NewRow();
                        NewRowAdcApl["Doc_sucursal"] = DatosDoc.Doc_sucursal;
                        NewRowAdcApl["Opc_documento"] = DatosDoc.Opc_documento;
                        NewRowAdcApl["IdClaveDoc"] = DatosDoc.IdClaveDoc;
                        NewRowAdcApl["Doc_numero"] = DatosDoc.Doc_numero;
                        NewRowAdcApl["Apl_fecha"] = DatosDoc.Doc_fecha;

                        string cmd = "select doc_numero,doc_fecha from adcdoc where ";
                        cmd += " doc_sucursal = '" + rowAplRol["Doc_Sucursal"].ToString() + "'";
                        cmd += " and opc_documento = '" + rowAplRol["opc_documento"] + "'";
                        cmd += " and idclavedoc = " + rowAplRol["IdclaveDoc"].ToString();

                        SqlDataReader dr = SqlDatos.leerBaseAdcom(cmd);
                        if (dr.Read())
                        {
                            NewRowAdcApl["Apl_docfecha"] =Convert.ToDateTime( dr["doc_fecha"]);
                            NewRowAdcApl["APL_NUMAPLI"] = Convert.ToDouble(dr["Doc_numero"].ToString());
                        }
                        dr.Close();

                        NewRowAdcApl["apl_docapli"] = rowAplRol["opc_documento"].ToString();
                        NewRowAdcApl["apl_sucapli"] = rowAplRol["Doc_Sucursal"].ToString();
                        NewRowAdcApl["idClaveDocapl"] = Convert.ToDouble(rowAplRol["IdclaveDoc"]);
                        //try
                        {
                        }
                        //catch { dtRow["Apl_docfecha"] = DatosDoc.Doc_fecha; }
                        NewRowAdcApl["Apl_valorapl"] = Convert.ToDouble(rowAplRol["valorAbono"]);
                        NewRowAdcApl["Apl_codbenef"] = rowAplRol["IdEmpleado"].ToString();
                        //if (DgvRow.Cells["Apl_codbenef"].Value.ToString() == "") dtRow["Apl_codbenef"] = DatosDoc.Doc_codper;
                        NewRowAdcApl["Apl_SNContado"] = 0;
                        NewRowAdcApl["CodConcepto"] = Concepto;
                        NewRowAdcApl["descripcionconcepto"] = NombreConcepto;
                        NewRowAdcApl["TRa_Ventas"] = 0;
                        NewRowAdcApl["TRa_Compras"] = 0;
                        NewRowAdcApl["tra_esanticipo"] = 0;
                        NewRowAdcApl["tra_Banco"] = 0;
                        NewRowAdcApl["tra_escontable"] = 0;
                        NewRowAdcApl["tra_CtasCobrar"] = -1;
                        NewRowAdcApl["tra_CtasPagar"] = 0;
                        NewRowAdcApl["ESPAGO"] = "C";

                        //if (DatosDoc.Doc_TipoDoc == "ING")
                        //{
                        //    if (Convert.ToInt16(DgvRow.Cells["espago"].Value) == 0) dtRow["ESPAGO"] = "E"; else dtRow["ESPAGO"] = "C";
                        //}
                        //else
                        //{
                        //    NewRowAdcApl["ESPAGO"] = "C";
                        //}
                        I++;
                        NewRowAdcApl["idclaveapl"] = I;

                        //if (Val(DgvRow.Cells["idclaveapl"].Value) != 0)
                        //{ dtRow["idclaveaplapl"] = Val(DgvRow.Cells["idclaveapl"].Value); }
                        //else { Val(dtRow["idclaveapl"] = 0); }

                        NewRowAdcApl["tra_costo"] = ""; // DgvRow.Cells["tra_costo"].Value.ToString();
                        NewRowAdcApl["tra_centroproduccion"] = ""; // DgvRow.Cells["tra_centroproduccion"].Value.ToString();
                        NewRowAdcApl["tra_centrodistribucion"] = ""; // DgvRow.Cells["tra_centrodistribucion"].Value.ToString();
                        NewRowAdcApl["tra_empleado"] = ""; // DgvRow.Cells["tra_empleado"].Value.ToString();
                        NewRowAdcApl["Tra_Proyecto"] = ""; // DgvRow.Cells["Tra_Proyecto"].Value.ToString();

                        NewRowAdcApl["numLinApl"] = I;

                        DocAdcApl.Rows.Add(NewRowAdcApl);
                    }
                }
            }
            SqlCommandBuilder CB = new SqlCommandBuilder(da);
            da.Update(DocAdcApl);
            DocAdcApl.AcceptChanges();
        }
        private void obtenerPreferencias()
        {
            RubrolRol = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo.ToString(), DatosUsuario.Identifica, "BEE", datosEmpresa.suc, "PARCTACOBEMP", "RUBROROL");
            Concepto = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo.ToString(), DatosUsuario.Identifica, "BEE", datosEmpresa.suc, "PARCTACOBEMP", "CONCEPTODOC");
            tipoDocumento = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo.ToString(), DatosUsuario.Identifica, "BEE", datosEmpresa.suc, "PARCTACOBEMP", "DOCUMENTO");
        }
    }
}
