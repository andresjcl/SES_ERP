using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DattCom;

namespace DctosEmi
{
    public class GenerarIngBancos
    {
        ListaConceptosBco conceptosBco = new ListaConceptosBco();
        sesSys.OpcDoc propiedadesDoc = new sesSys.OpcDoc();
        ClassDoc.idDocumento idDocumentoActual = new ClassDoc.idDocumento();
        string CodBanco = "";
        public bool existenEgresos = false;

        public void GenerarIngresoSimple(string DocTipo, double DocNumero, DateTime DocFecha, string BancoCta,ListaConceptosBco listaConceptos)
        {

            idDocumentoActual = new ClassDoc.idDocumento()
            {
                fecha = DocFecha,
                numero = DocNumero, 
                Sucursal = datosEmpresa.sucursal,
                Tipo = DocTipo,
                idClave = 0
            };
            propiedadesDoc.Cargar(DocTipo);
            idDocumentoActual.familia = propiedadesDoc.TipoDoc;            
            conceptosBco = listaConceptos;
            CodBanco = BancoCta;
            if (DocNumero == 0)
            {
                ClassDoc.controlNumeracion cnum = new ClassDoc.controlNumeracion();
                DocNumero = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom);
                idDocumentoActual.numero = DocNumero;
            }
            GrabarDocumento();
         }
        internal void GrabarDocumento()
        {
            double totalDocumento = 0;
            foreach (ConceptoBco conceptoBco in conceptosBco.conceptoBcos)
            {
                totalDocumento += conceptoBco.valor;
            }
            directMnt.DirectorioAlex alx = new directMnt.DirectorioAlex();
            string ruc = datosEmpresa.Emp_RUC;
            bool clipro = true;
            string solocod = "";
            alx.CargarAlex(ref ruc,ref clipro , ref solocod);
            ClassDoc.AdcDoc datADCDOC = new ClassDoc.AdcDoc(datosEmpresa.strConxAdcom)
            {
                //datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
                Doc_sucursal = idDocumentoActual.Sucursal,
                Doc_Bodega = "",
                //datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;
                Opc_documento = idDocumentoActual.Tipo,
                Doc_docnombre = propiedadesDoc.nombre,
                Doc_numero = Convert.ToDecimal(idDocumentoActual.numero),
                Doc_fecha = Convert.ToDateTime (idDocumentoActual.fecha.ToShortDateString ()),
                Doc_codper = alx.codigo,
                Doc_CiRuc = datosEmpresa.Emp_RUC,
                Doc_NombreImp = alx.NombreImpresion,
                Doc_Direccion = "",
                Doc_Telefono1 = "",
                Doc_detalle = "Depósito general de cajas " + idDocumentoActual.fecha.ToShortDateString(),
                //if (cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = "" + cmbVendedor.SelectedValue.ToString();

                Doc_DocSop = "",
                Doc_NumSop = 0,
                IdClaveDocSop = 0,

                Doc_valor = Convert.ToDecimal(totalDocumento),
                AuxVar9 = "",
                Doc_Hora = DateTime.Now,

                //Doc_NroLoteDoc = RolPeriodo.ToString(),
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
                doc_BancoOrigen = CodBanco,
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
            //string codigo = "";
            //bool clipro = true;
            //string solocodigo = "";

            string codsql = " select * FROM AdcApl WHERE doc_sucursal='" + DatosDoc.Doc_sucursal + "' and opc_documento='" + DatosDoc.Opc_documento + "' and idclavedoc=" + DatosDoc.IdClaveDoc;
            SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom);
            DataTable DocAdcApl = new DataTable();
            da.Fill(DocAdcApl);

            foreach (DataRow rowDocAdcApl in DocAdcApl.Rows) { rowDocAdcApl.Delete(); }

            int I = 0;

            foreach (ConceptoBco conceptoBco in conceptosBco.conceptoBcos)
            {
                directMnt.DirectorioAlex alx = new directMnt.DirectorioAlex();
                //codigo = rowAplRol["IdEmpleado"].ToString();
              //  alx.CargarAlex(ref codigo, ref clipro, ref solocodigo);
                //                using (SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom))
                {
                    {
                        DataRow NewRowAdcApl = DocAdcApl.NewRow();
                        NewRowAdcApl["Doc_sucursal"] = DatosDoc.Doc_sucursal;
                        NewRowAdcApl["Opc_documento"] = DatosDoc.Opc_documento;
                        NewRowAdcApl["IdClaveDoc"] = DatosDoc.IdClaveDoc;
                        NewRowAdcApl["Doc_numero"] = DatosDoc.Doc_numero;
                        NewRowAdcApl["Apl_fecha"] = DatosDoc.Doc_fecha;

                        NewRowAdcApl["apl_docapli"] = "";
                        NewRowAdcApl["apl_sucapli"] = "";
                        NewRowAdcApl["Apl_numapli"] = 0;
                        NewRowAdcApl["idClaveDocapl"] = 0;
                        NewRowAdcApl["Apl_docfecha"] = DatosDoc.Doc_fecha;
                        NewRowAdcApl["Apl_valorapl"] = conceptoBco.valor; // Convert.ToDouble(rowAplRol["valorAbono"]);
                        NewRowAdcApl["Apl_codbenef"] = DatosDoc.Doc_codper;
                        //if (DgvRow.Cells["Apl_codbenef"].Value.ToString() == "") dtRow["Apl_codbenef"] = DatosDoc.Doc_codper;
                        NewRowAdcApl["Apl_SNContado"] = 0;
                        NewRowAdcApl["CodConcepto"] = conceptoBco.TipoConcepto;
                        NewRowAdcApl["descripcionconcepto"] = conceptoBco.Descrición;
                        NewRowAdcApl["TRa_Ventas"] = 0;
                        NewRowAdcApl["TRa_Compras"] = 0;
                        NewRowAdcApl["tra_esanticipo"] = 0;
                        NewRowAdcApl["tra_Banco"] = 0;
                        NewRowAdcApl["tra_escontable"] = 0;
                        NewRowAdcApl["tra_CtasCobrar"] = 0;
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


    }
}
