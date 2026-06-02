using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DattCom;
namespace DctosEmi
{
    public class ConceptoBco
    {
        public string TipoConcepto = "";
        public string Descrición = "";
        public double valor = 0;
    }
    public class ListaConceptosBco
    {
        public List<ConceptoBco> conceptoBcos = new  List<ConceptoBco>();
    }
    internal class DatosDocBancos
    {
        internal string armarSqlLecturaEgreBco(string suc, string tip, double idClave)
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

        internal Boolean CargarConceptoDoc(string dato,  DataGridViewRow row, sesSys.OpcDoc opcDoc,string QueBeneficiario,string BancoFin)
        {
            if (row == null) return false;
            if (dato == "") return false;

            daxConta.reglCtb dxCtb = new daxConta.reglCtb();
            ClassDoc.Servicios OpServicio = new ClassDoc.Servicios(DattCom.datosEmpresa.strConxAdcom);
            OpServicio = ClassDoc.Servicios.Buscar(" sev_codigo = '" + dato + "'");
            if (OpServicio == null) return false;

            row.Cells["CodConcepto"].Value = dato;
            row.Cells["DescripcionConcepto"].Value = OpServicio.Sev_nombre;
            row.Cells["tra_EsContable"].Value = OpServicio.sev_escontable;
            row.Cells["EsPago"].Value = 1;
            dxCtb.VerificarClasificadoresContablesServicios("T", dato,  row, OpServicio,  opcDoc,QueBeneficiario,BancoFin);
            return true;

            //row.Cells["tra_QueTipo"].Value = "S";
            //row.Cells["tra_Individual"].Value = "";
            //if (OpServicio.sev_escontable) { row.Cells["tra_EsContable"].Value = true; } else { row.Cells["tra_EsContable"].Value = false; }
            //row.Cells["tra_Ventas"].Value = OpServicio.sev_ventas;
            ////row.Cells["tra_esanticipo"].Value = OpServicio.sev_;
            //row.Cells["tra_QueTipo"].Value = "S";
            //row.Cells["tra_QueTipo"].Value = "S";
            //row.Cells["tra_QueTipo"].Value = "S";
            //row.Cells["tra_QueTipo"].Value = "S";
            //row.Cells["tra_QueTipo"].Value = "S";
            //ssql += "tra_costo, tra_centroproduccion, tra_centrodistribucion, tra_empleado,Tra_Proyecto, tra_directorio, ";
            //dxCtb.VerificarClasificadoresContablesServicios("T", dato, malla, OpServicio, opcDoc, "", "");

        }
        public void GuardarDetalleDoc(ClassDoc.AdcDoc DatosDoc, DataGridView malla, string TipoPago = "")
        {

            string codsql = " FROM AdcApl WHERE doc_sucursal='" + DatosDoc.Doc_sucursal   + "' and opc_documento='" + DatosDoc.Opc_documento  + "' and idclavedoc=" + DatosDoc.IdClaveDoc;
            //SqlDatos.ejecutarComandoAdcom(" delete " + codsql);
            DataTable dataTab = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter("select * " + codsql , datosEmpresa.strConxAdcom))
            {
                da.Fill(dataTab);
                foreach(DataRow row in dataTab.Rows )
                {
                    row.Delete();
                }
                int I = 0;
                foreach (DataGridViewRow DgvRow in malla.Rows)
                {
                    if (DgvRow.Cells["CodConcepto"] != null && DgvRow.Cells["CodConcepto"].Value.ToString() != "" && Convert.ToDouble(DgvRow.Cells["apl_ValorApl"].Value) != 0)
                    {
                        DataRow dtRow = dataTab.NewRow();
                        dtRow["Doc_sucursal"] = DatosDoc.Doc_sucursal;
                        dtRow["Doc_numero"]= DatosDoc.Doc_numero ;
                        dtRow["Opc_documento"]= DatosDoc.Opc_documento;
                        dtRow["IdClaveDoc"] = DatosDoc.IdClaveDoc;

                        dtRow["apl_docapli"]= DgvRow.Cells["apl_docapli"].Value;
                        dtRow["APL_NUMAPLI"]= Convert.ToDouble("0"+DgvRow.Cells["APL_NUMAPLI"].Value);
                        dtRow["apl_sucapli"]= DgvRow.Cells["apl_sucapli"].Value.ToString();
                        dtRow["idClaveDocapl"]= Convert.ToDouble("0" + DgvRow.Cells["idClaveDocapl"].Value);
                        dtRow["Apl_fecha"]= DatosDoc.Doc_fecha;
                        try
                        {
                            dtRow["Apl_docfecha"] = Convert.ToDateTime(DgvRow.Cells["Apl_docfecha"].Value);
                        }catch{ dtRow["Apl_docfecha"] = DatosDoc.Doc_fecha; }
                        dtRow["Apl_valorapl"] = Convert.ToDouble(DgvRow.Cells["Apl_valorapl"].Value);
                        dtRow["Apl_codbenef"] = DgvRow.Cells["Apl_codbenef"].Value.ToString();
                        if (DgvRow.Cells["Apl_codbenef"].Value.ToString() == "") dtRow["Apl_codbenef"] = DatosDoc.Doc_codper;
                        dtRow["Apl_SNContado"]= 0;
                        dtRow["CodConcepto"]= DgvRow.Cells["CodConcepto"].Value.ToString();
                        dtRow["descripcionconcepto"]= DgvRow.Cells["descripcionconcepto"].Value.ToString();
                        dtRow["TRa_Ventas"]= Val(DgvRow.Cells["TRa_Ventas"].Value);
                        dtRow["TRa_Compras"]= Val(DgvRow.Cells["TRa_Compras"].Value);
                        dtRow["tra_esanticipo"] = Val(DgvRow.Cells["tra_esanticipo"].Value);
                        //dtRow["tra_Banco"]= Convert.ToDouble(DgvRow.Cells[ "tra_Banco"].Value);
                        dtRow["tra_Banco"] = Val(DgvRow.Cells["tra_Banco"].Value);
                        dtRow["tra_escontable"]= Val(DgvRow.Cells["tra_escontable"].Value);
                        dtRow["tra_CtasCobrar"]= Val( DgvRow.Cells["tra_CtasCobrar"].Value);
                        dtRow["tra_CtasPagar"]= Val( DgvRow.Cells["tra_CtasPagar"].Value);

                        if (DatosDoc.Doc_TipoDoc == "ING")
                        {
                            if (Convert.ToInt16(DgvRow.Cells["espago"].Value) == 0) dtRow["ESPAGO"] = "E"; else dtRow["ESPAGO"] = "C";
                        }
                        else
                        {
                            dtRow["ESPAGO"] = "";
                        }
                        dtRow["idclaveapl"] = Convert.ToDouble("0"+DgvRow.Cells["idclaveapl"].Value);
                        
                        if (Val(DgvRow.Cells["idclaveapl"].Value) != 0)
                        { dtRow["idclaveaplapl"] = Val(DgvRow.Cells["idclaveapl"].Value); }
                        else { Val(dtRow["idclaveapl"] = 0); }

                        dtRow["tra_costo"] = DgvRow.Cells["tra_costo"].Value.ToString();
                        dtRow["tra_centroproduccion"] = DgvRow.Cells["tra_centroproduccion"].Value.ToString();
                        dtRow["tra_centrodistribucion"] = DgvRow.Cells["tra_centrodistribucion"].Value.ToString();
                        dtRow["tra_empleado"] = DgvRow.Cells["tra_empleado"].Value.ToString();
                        dtRow["Tra_Proyecto"] = DgvRow.Cells["Tra_Proyecto"].Value.ToString();

                        I++;
                        dtRow["numLinApl"] = I;

                        dataTab.Rows.Add(dtRow);
                    }
                }
                SqlCommandBuilder CB = new SqlCommandBuilder(da);
                da.Update(dataTab);
                dataTab.AcceptChanges();
                CB.Dispose();
                dataTab.Dispose();
            }                                                   
        }

        private Int32 Val(Object valor)
        {
            try
            {
                return Convert.ToInt16(valor);
            }
            catch { return 0; }
        }
        internal void MoverDatosAcontroles(frmEgrBcoCaj formulario)
        {
            formulario.idDocumentoActual.idClave = Convert.ToDouble(formulario.datADCDOC.IdClaveDoc);
            formulario.idDocumentoActual.numero  = Convert.ToDouble(formulario.datADCDOC.Doc_numero);
            formulario.txtnumero.Text = formulario.datADCDOC.Doc_numero.ToString();
            formulario.txtfecha.Value = formulario.datADCDOC.Doc_fecha;
            formulario.txtFechaVence.Value = formulario.datADCDOC.Doc_FechaEfe;
            formulario.txtCodper.Text = formulario.datADCDOC.Doc_codper;
            formulario.txtnombrecliente.Text = formulario.datADCDOC.Doc_NombreImp;
            formulario.txtDetalle.Text = formulario.datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = formulario.datADCDOC.Doc_venabre;
            formulario.edTotal.Text = formulario.datADCDOC.Doc_valor.ToString();
            formulario.TxtNroCheque.Text = formulario.datADCDOC.doc_NumeroCheque;
            formulario.txtNroLote.Text = formulario.datADCDOC.Doc_NroLoteDoc;
            formulario.EsCliente = (formulario.datADCDOC.Doc_Ventas != 0);
            formulario.EsProveedor = (formulario.datADCDOC.Doc_Compras != 0);
            formulario.CambiaAbancos = (formulario.datADCDOC.doc_BancoDestino.Length > 0);
            formulario.txtCodBanco.Text = (formulario.datADCDOC.doc_BancoOrigen);
        }
        internal void moverDatosAclase(frmEgrBcoCaj formulario)
        {
            formulario.datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            formulario.datADCDOC.Doc_sucursal = DattCom.datosEmpresa.sucursal;
            formulario.datADCDOC.Doc_Bodega = "";
            formulario.datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;
            formulario.datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            formulario.datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            formulario.datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            formulario.datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            formulario.datADCDOC.Doc_codper = formulario.txtCodper.Text;
            formulario.datADCDOC.Doc_CiRuc = "";
            formulario.datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            formulario.datADCDOC.Doc_Direccion = "";
            formulario.datADCDOC.Doc_Telefono1 = "";
            formulario.datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            if (formulario.cmbVendedor.SelectedValue != null) formulario.datADCDOC.Doc_venabre = "" + formulario.cmbVendedor.SelectedValue.ToString();

            formulario.datADCDOC.Doc_DocSop = "";
            formulario.datADCDOC.Doc_NumSop = 0;
            formulario.datADCDOC.IdClaveDocSop = 0;

            formulario.datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            formulario.datADCDOC.AuxVar9 = "";
            formulario.datADCDOC.Doc_Hora = DateTime.Now;

            formulario.datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            //formulario.datADCDOC.Doc_NroIdDoc = txtNroID.Text;
            //formulario.datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
            //formulario.datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //formulario.datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //formulario.datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //formulario.datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            //formulario.datADCDOC.Doc_docnombre = "";
            formulario.datADCDOC.Doc_TipoDoc = formulario.idDocumentoActual.familia;
            formulario.datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtFechaVence.Value);  
            formulario.datADCDOC.Doc_Hora = DateTime.Now;
            formulario.datADCDOC.Doc_extension = "";
            formulario.datADCDOC.Doc_codusu = DatosUsuario.codigo;
            //formulario.datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
            //formulario.datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
            //formulario.datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
            //formulario.datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
            //formulario.datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;            //formulario.datADCDOC.Doc_valorabon = totalesDocumento.ValorCon;
            //formulario.datADCDOC.Doc_DepDes = "";
            //formulario.datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
            //formulario.datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
            //formulario.datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
            //formulario.datADCDOC.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
            //formulario.datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
            //formulario.datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
            //formulario.datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
            //formulario.datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
            formulario.datADCDOC.Doc_Estado = 1;
            formulario.datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            formulario.datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            formulario.datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            formulario.datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            formulario.datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            formulario.datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            formulario.datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            formulario.datADCDOC.Doc_Adicional2 = 0;
            formulario.datADCDOC.Doc_NumeroExterno = 0;
            formulario.datADCDOC.Doc_FechaModifica = DateTime.Now;
            formulario.datADCDOC.Cobranza = formulario.TxtNroCobranza.Text;
            formulario.datADCDOC.doc_NumeroCheque = formulario.TxtNroCheque.Text;
            formulario.datADCDOC.doc_BancoOrigen = formulario.txtCodBanco.Text;
            formulario.datADCDOC.doc_Anticipo = false;

            if (formulario.Estransferencia)
            {
                formulario.datADCDOC.doc_BancoDestino = formulario.cmbCtasBacoDestino.SelectedValue.ToString();
            }
            else
            {
                formulario.datADCDOC.doc_BancoDestino = "";
            }
        }

        internal string origenClasificador(string NomClasificador)
        {
            string ssql = "Select origenValores from AdcClasfctb where nombre = '" + NomClasificador + "'";
            SqlDataReader dr = SqlDatos.leerBaseAdcom(ssql);
            ssql = "";
            if (dr.Read()) ssql = dr["origenValores"].ToString();
            return ssql;
        }
        internal void GuardarNumeroCheque(string TipDocBan, string txtCodBco, string txtNroCheque)
        {
            if (TipDocBan == "" | txtCodBco == "") return;
            string cod = "select * from AdcDocNUM where ID_LUGAR ='" + txtCodBco + "' and ID_DOCUMENTO='" + TipDocBan + "'";
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cod, datosEmpresa.strConxAdcom))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        DataRow nrow = dt.NewRow();
                        nrow["id_lugar"] = txtCodBco;
                        nrow["id_documento"] = TipDocBan;
                        nrow["ultimonumero"] = Convert.ToDouble("0" + txtNroCheque);
                        nrow["UltimaFecha"] = DateTime.Now;
                        dt.Rows.Add(nrow);
                    }
                    else
                    {
                        dt.Rows[0]["ultimonumero"] = Convert.ToDouble("0" + txtNroCheque);
                        dt.Rows[0]["UltimaFecha"] = DateTime.Now;
                    }
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(dt);
                    cb.Dispose();
                    dt.Dispose();
                }
            }
        }
    }
}