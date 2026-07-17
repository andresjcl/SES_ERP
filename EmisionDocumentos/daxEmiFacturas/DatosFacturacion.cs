using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DattCom;
using ClassDoc;

namespace DctosEmi
{
    internal class DatosDocFacturacion
    {
        public string armarSqlLecturaTransFacturas(string TablaTra, string suc, string tip, double idClave)
        {
            string ssqlTra = "Select TRA_NUMLINEA,tra_codigo,tra_nombre,tra_cantidad,tra_medida,Tra_precuni";
            ssqlTra += ",tra_porcendes ,tra_valordes,Tra_prectot,Tra_porceniva,Tra_valoriva,TRA_SNIVA,tra_piezas,tra_peso,Doc_Bodega";
            ssqlTra += ",tra_nrolote,Tra_vence,FacDesde,FacHasta,despacho";
            ssqlTra += ",tra_costo,tra_empleado,tra_centroProduccion,tra_centroDistribucion,tra_Proyecto";

            ssqlTra += ",tra_quetipo,tra_esCuenta,Tra_individual,tra_costuni,Tra_CostTot,tra_multiplo";
            ssqlTra += ",tra_numprecio,0.0000 as Existencia,0.0000 as limiteDescuento,0.0000 as descuentoArticulo";
            ssqlTra += ",0.0000 as precioArticulo,'' as medidaArticulo,'S' as Serv,'' as Cmb,TRA_SNIVA,AuxVar3";

            ssqlTra += " from " + TablaTra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            ssqlTra += " order by opc_documento,idclavedoc,tra_numlinea";

            return ssqlTra;
        }

        public string armarSqlLecturaTransDevoluciones(string TablaTra, string suc, string tip, double idClave)
        {
            string ssqlTra = "Select TRA_NUMLINEA,tra_codigo,tra_nombre,tra_cantidad,tra_medida,Tra_precuni";
            ssqlTra += ",tra_porcendes ,tra_valordes,Tra_prectot,Tra_porceniva,Tra_valoriva,TRA_SNIVA,tra_piezas,tra_peso,Doc_Bodega";
            ssqlTra += ",tra_nrolote,Tra_vence,FacDesde,FacHasta,despacho";
            ssqlTra += ",tra_costo,tra_empleado,tra_centroProduccion,tra_centroDistribucion,tra_Proyecto";

            ssqlTra += ",tra_quetipo,tra_esCuenta,Tra_individual,tra_costuni,Tra_CostTot,tra_multiplo";
            ssqlTra += ",tra_numprecio,0.0000 as Existencia,0.0000 as limiteDescuento,0.0000 as descuentoArticulo";
            ssqlTra += ",0.0000 as precioArticulo,'' as medidaArticulo,'S' as Serv,'' as Cmb,TRA_SNIVA,AuxVar3";

            ssqlTra += " from " + TablaTra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            ssqlTra += " order by opc_documento,idclavedoc,tra_numlinea";

            return ssqlTra;
        }

        public string armarSqlLecturaTransInventario(string TablaTra, string suc, string tip, double idClave)
        {
            string ssqlTra = "SELECT TRA_NUMLINEA, tra_codigo, tra_nombre, tra_cantidad, tra_medida, Tra_precuni";
            ssqlTra += ", Tra_prectot";
            ssqlTra += ", tra_piezas, tra_peso, Doc_Bodega";
            ssqlTra += ", tra_nrolote, Tra_vence";
            ssqlTra += ", tra_costo, tra_empleado, tra_centroProduccion, tra_centroDistribucion, tra_Proyecto";
            ssqlTra += ", tra_quetipo, tra_esCuenta, Tra_individual, tra_costuni, Tra_CostTot, tra_multiplo";
            ssqlTra += ", tra_numprecio";
            ssqlTra += ", 0.0000 as Existencia";
            ssqlTra += ", '' as medidaArticulo";
            ssqlTra += ", '' as Cmb";
            ssqlTra += ", AuxVar3";
            ssqlTra += " FROM " + TablaTra;
            ssqlTra += " WHERE doc_sucursal = '" + suc + "'";
            ssqlTra += " AND opc_documento = '" + tip + "'";
            ssqlTra += " AND idclavedoc = " + idClave.ToString();
            ssqlTra += " ORDER BY opc_documento, idclavedoc, tra_numlinea";

            return ssqlTra;
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
                        dtRow["tra_Banco"]= Convert.ToDouble(DgvRow.Cells[ "tra_Banco"].Value);
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
        
        internal void MoverDatosAcontroles(FormProforma formulario, ClassDoc.AdcDocPro datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
        }

        internal void MoverDatosAcontroles(FormPedCliente formulario, ClassDoc.AdcDocPro datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
        }

        internal void MoverDatosAcontroles(FormFactCliente formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
        }
        internal void MoverDatosAcontroles(FormFactProveedor formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codProveedor = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
            formulario.dtFechaContabiliza.Value=datADCDOC.Adi_FechContab;
            formulario.TextNroAutSri.Text  = datADCDOC.NroAutorizacionSri;
            formulario.txtCodigoRet.Text = datADCDOC.Adi_CodigoNSR;

            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            try
            {
                formulario.cmbSustentoTributario.SelectedValue = datADCDOC.Adi_SustTrib;
            }
            catch { }

        }
        internal void MoverDatosAcontroles(FormDevolucion formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            //            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
        }

        /*AQUI AGREGO ESTE NUEVO METODO HASTA VER QUE MISMO SE DEBE PONER OJO HAY QUE REVISASR*/
         internal void MoverDatosAcontroles(FormDevProveedor formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            //            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
        }
        internal void MoverDatosAcontroles(FormIngImportacion formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codProveedor = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
            formulario.cmbVendedor.SelectedValue = datADCDOC.Doc_venabre;
            formulario.claseDescuentos = new adcDescto.descDocumento();
            formulario.claseImpuestos = new IvaRett.docImpuestos();
            formulario.claseDescuentos.nombreDes[0] = datADCDOC.Doc_nombredes1;
            formulario.claseDescuentos.nombreDes[1] = datADCDOC.Doc_nombredes2;
            formulario.claseDescuentos.nombreDes[2] = datADCDOC.Doc_nombredes3;

            formulario.claseDescuentos.porcentajeDes[0] = Convert.ToDouble(datADCDOC.Doc_porcendes1);
            formulario.claseDescuentos.porcentajeDes[1] = Convert.ToDouble(datADCDOC.Doc_porcendes2);
            formulario.claseDescuentos.porcentajeDes[2] = Convert.ToDouble(datADCDOC.Doc_porcendes3);

            formulario.claseDescuentos.valorDes[0] = Convert.ToDouble(datADCDOC.Doc_valordes1);
            formulario.claseDescuentos.valorDes[1] = Convert.ToDouble(datADCDOC.Doc_valordes2);
            formulario.claseDescuentos.valorDes[2] = Convert.ToDouble(datADCDOC.Doc_valordes3);

            formulario.claseImpuestos.impstoPorcentaje1 = Convert.ToDouble(datADCDOC.Doc_porceniva);
            formulario.claseImpuestos.impstoNombre1 = "IVA";
            formulario.dtFechaContabiliza.Value = datADCDOC.Adi_FechContab;
            formulario.TextNroAutSri.Text = datADCDOC.NroAutorizacionSri;
            formulario.txtCodigoRet.Text = datADCDOC.Adi_CodigoNSR;

            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            try
            {
                formulario.cmbSustentoTributario.SelectedValue = datADCDOC.Adi_SustTrib;
            }
            catch { }

        }


        /*-+----------------------------------------*/
        internal void MoverDatosAcontroles(FormDocInventario formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
            formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
            formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            //            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
        }
        internal void MoverDatosAcontroles(FormTransferenciaInv formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            formulario.idDocumentoActual.idClave = Convert.ToDouble(datADCDOC.IdClaveDoc);
            formulario.codCliente = datADCDOC.Doc_codper;

            formulario.txtnumero.Text = datADCDOC.Doc_numero.ToString();
            if (datADCDOC.Doc_NroIdDoc.ToString() != "") formulario.txtNroID.Text = datADCDOC.Doc_NroIdDoc.ToString();
            formulario.txtfecha.Text = datADCDOC.Doc_fecha.ToShortDateString();
           // formulario.txtcedula.Text = datADCDOC.Doc_CiRuc;
           // formulario.txtnombrecliente.Text = datADCDOC.Doc_NombreImp;
            //            formulario.txtdireccion.Text = datADCDOC.Doc_Direccion;

            formulario.txtDetalle.Text = datADCDOC.Doc_detalle;
        }

        internal void moverDatosAclase(FormFactCliente formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codCliente;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        internal void moverDatosAclase(FormProforma formulario, ClassDoc.AdcDocPro datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codCliente;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        internal void moverDatosAclase(FormPedCliente formulario, ClassDoc.AdcDocPro datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codCliente;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        internal void moverDatosAclase(FormDevolucion formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codCliente;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            //datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            //datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            //datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        /*AQUI AGREGO ESTE NUEVO METODO HASTA VER QUE MISMO SE DEBE PONER OJO HAY QUE REVISASR*/
        internal void moverDatosAclase(FormDevProveedor formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            //datADCDOC.Doc_codper = formulario.codProveedor;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            //datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = formulario.cmbDocumentoSustento.SelectedValue.ToString();
            datADCDOC.Doc_NumSop = Convert.ToDecimal(formulario.nroDocSoporte.Text);
            //decimal numero;
            //if (decimal.TryParse(formulario.nroDocSoporte.Text, out numero))
            //{
            //    datADCDOC.Doc_NumSop = numero;
            //}
            //else
            //{
            //    MessageBox.Show("Número de documento de soporte no válido","Número de Soporte",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    return;
                
            //}

            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
			if (formulario.dtFechaContabiliza.Value <= formulario.txtfecha.Value)
				datADCDOC.Adi_FechContab = formulario.txtfecha.Value;
			//datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text

			try
            {
                datADCDOC.Adi_SustTrib = formulario.cmbSustentoTributario.SelectedValue.ToString();
            }
            catch { }
            datADCDOC.Adi_NroAutSri = formulario.TextNroAutSri.Text;                   //TextNroAutSri
            datADCDOC.NroAutorizacionSri = formulario.TextNroAutSri.Text;

            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.BaseImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        /*-+----------------------------------------*/

        internal void moverDatosAclase(FormDocInventario formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codCliente;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            //datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            //datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            //if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            //datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            //if (formulario.operacionEnCurso == 1)
            //{
            //    datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
            //    datADCDOC.Doc_Hora = docUtils.DaxNow();
            //    datADCDOC.Doc_Estado = 1;
            //}

            //datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            //datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            //datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            //datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            //datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            //datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            //datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            //datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            //datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            //datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            //datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            //datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            //datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            //datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            //datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            //datADCDOC.Doc_DepDes = "";
            //datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            //datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            //datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            //datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            //datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            //datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            //datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            //datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            //datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            //datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            //datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            //datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            //datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }
        internal void moverDatosAclase(FormTransferenciaInv formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codCliente;
            datADCDOC.doc_BodDestino = formulario.CmbBodDestino.SelectedValue.ToString();
            datADCDOC.doc_SucDestino = formulario.CmbSucDestino.SelectedValue.ToString();
            // datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
           // datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            //datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            //datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;
            //if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            //datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            //datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            //datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            //datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            //datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            //datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            //datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            //datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            //datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            //datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            //datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //datADCDOC.Adi_SustTrib = DatSustento.BoundText
            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            //datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            //datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            //datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            //datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            //datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            //datADCDOC.Doc_DepDes = "";
            //datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            //datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            //datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            //datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            //datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            //datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            //datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            //datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;
            //datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            //datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            //datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            //datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            //datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            //datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }
        internal void moverDatosAclase(FormFactProveedor formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codProveedor;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;

            //(formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();

            //if (formulario.cmbVendedor.SelectedValue != null && !string.IsNullOrEmpty(formulario.cmbVendedor.SelectedValue.ToString()))
            //{
            //    datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            //}
            //else
            //{
            //    // Asignar un valor por defecto o manejar el caso nulo
            //    datADCDOC.Doc_venabre = string.Empty; // o el valor por defecto que necesites
            //}

            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            datADCDOC.Adi_FechContab = formulario.dtFechaContabiliza.Value;
            if (formulario.dtFechaContabiliza.Value < formulario.txtfecha.Value)
                    datADCDOC.Adi_FechContab = formulario.txtfecha.Value;
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text

            datADCDOC.Adi_CodigoNSR = formulario.txtCodigoRet.Text;
            //try
            //{
            //    //datADCDOC.Adi_SustTrib = formulario.cmbSustentoTributario.SelectedValue.ToString();
            //    datADCDOC.Adi_SustTrib = FormatearSustentoTributario(formulario.cmbSustentoTributario.SelectedValue.ToString());
            //}
            //catch { }

            if (formulario.cmbSustentoTributario.SelectedValue != null)
            {
                datADCDOC.Adi_SustTrib = FormatearSustentoTributario(
                    formulario.cmbSustentoTributario.SelectedValue.ToString()
                );
            }
            else
            {
                datADCDOC.Adi_SustTrib = "";
            }
            datADCDOC.Adi_NroAutSri = formulario.TextNroAutSri.Text;                   //TextNroAutSri
            datADCDOC.NroAutorizacionSri = formulario.TextNroAutSri.Text;

            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")

            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;

            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        private string FormatearSustentoTributario(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return "";

            // Asegurar que tenga 2 dígitos
            return valor.PadLeft(2, '0');
        }

        internal void moverDatosAclase(FormIngImportacion formulario, ClassDoc.AdcDoc datADCDOC)
        {
            if (datADCDOC == null) return;
            datADCDOC.Doc_sucursal = datosEmpresa.suc;
            datADCDOC.Doc_Bodega = formulario.cmbBodega.SelectedValue.ToString();
            datADCDOC.Opc_documento = formulario.cmbDocumento.SelectedValue.ToString();
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_numero = Convert.ToDecimal(formulario.txtnumero.Text);
            datADCDOC.Doc_fecha = Convert.ToDateTime(formulario.txtfecha.Text);
            datADCDOC.Doc_codper = formulario.codProveedor;
            datADCDOC.Doc_CiRuc = formulario.txtcedula.Text;
            datADCDOC.Doc_NombreImp = formulario.txtnombrecliente.Text;
            datADCDOC.Doc_Direccion = formulario.txtdireccion.Text;
            datADCDOC.Doc_Telefono1 = formulario.txttelefono.Text;
            datADCDOC.Doc_detalle = formulario.txtDetalle.Text;

            //(formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            if (formulario.cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();

            //if (formulario.cmbVendedor.SelectedValue != null && !string.IsNullOrEmpty(formulario.cmbVendedor.SelectedValue.ToString()))
            //{
            //    datADCDOC.Doc_venabre = formulario.cmbVendedor.SelectedValue.ToString();
            //}
            //else
            //{
            //    // Asignar un valor por defecto o manejar el caso nulo
            //    datADCDOC.Doc_venabre = string.Empty; // o el valor por defecto que necesites
            //}

            datADCDOC.Doc_DocSop = "";
            datADCDOC.Doc_NumSop = 0;
            datADCDOC.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            datADCDOC.AuxVar9 = formulario.txtCorreElectronico.Text;

            if (formulario.operacionEnCurso == 1)
            {
                datADCDOC.PuntoVta = valoresPredefinidosSucursal.nomPuntoVta;
                datADCDOC.Doc_Hora = docUtils.DaxNow();
                datADCDOC.Doc_Estado = 1;
            }

            datADCDOC.Doc_nombredes1 = formulario.claseDescuentos.nombreDes[0];
            datADCDOC.Doc_nombredes2 = formulario.claseDescuentos.nombreDes[1];
            datADCDOC.Doc_nombredes3 = formulario.claseDescuentos.nombreDes[2];

            datADCDOC.Doc_porcendes1 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[0]);
            datADCDOC.Doc_porcendes2 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[1]);
            datADCDOC.Doc_porcendes3 = Convert.ToDecimal(formulario.claseDescuentos.porcentajeDes[2]);

            datADCDOC.Doc_valordes1 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[0]); ;
            datADCDOC.Doc_valordes2 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[1]);
            datADCDOC.Doc_valordes3 = Convert.ToDecimal(formulario.claseDescuentos.valorDes[2]);

            datADCDOC.Doc_porceniva = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            datADCDOC.Doc_NroLoteDoc = formulario.txtNroLote.Text;
            datADCDOC.Doc_NroIdDoc = formulario.txtNroID.Text;
            datADCDOC.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            datADCDOC.Adi_FechContab = formulario.dtFechaContabiliza.Value;
            if (formulario.dtFechaContabiliza.Value < formulario.txtfecha.Value)
                datADCDOC.Adi_FechContab = formulario.txtfecha.Value;
            //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text

            datADCDOC.Adi_CodigoNSR = formulario.txtCodigoRet.Text;
            try
            {
                datADCDOC.Adi_SustTrib = formulario.cmbSustentoTributario.SelectedValue.ToString();
            }
            catch { }
            datADCDOC.Adi_NroAutSri = formulario.TextNroAutSri.Text;                   //TextNroAutSri
            datADCDOC.NroAutorizacionSri = formulario.TextNroAutSri.Text;

            //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")

            datADCDOC.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            datADCDOC.IdClaveDocSop = 0;
            datADCDOC.Doc_docnombre = formulario.cmbDocumento.Text;
            datADCDOC.Doc_TipoDoc = formulario.propiedadesDoc.TipoDoc;
            datADCDOC.Doc_FechaEfe = Convert.ToDateTime(formulario.txtfecha.Text);     //FechaVence.Value
            datADCDOC.Doc_extension = "";
            datADCDOC.Doc_codusu = datosEmpresa.usr;
            datADCDOC.Doc_valoriva = formulario.totalesDocumento.TotIva;
            datADCDOC.Doc_totciva = formulario.totalesDocumento.TotCiva;
            datADCDOC.Doc_totsiva = formulario.totalesDocumento.TotSiva;
            datADCDOC.Doc_valorabon = Convert.ToDecimal(formulario.clasePagos.totalContado);
            datADCDOC.Doc_DepDes = "";
            datADCDOC.Doc_TotDesArt = formulario.totalesDocumento.TotDesArt;
            datADCDOC.Doc_TotDesSer = formulario.totalesDocumento.TotDesSer;
            datADCDOC.Doc_TotArtCIva = formulario.totalesDocumento.TotArtCIva;
            datADCDOC.Doc_TotArtSIva = formulario.totalesDocumento.TotArtSIva;
            datADCDOC.Doc_TotSerCIva = formulario.totalesDocumento.TotSerCIva;
            datADCDOC.Doc_TotSerSIva = formulario.totalesDocumento.TotSerSIva;
            datADCDOC.Doc_TotAcf = formulario.totalesDocumento.TotAcf;
            datADCDOC.Doc_Contado = formulario.totalesDocumento.ValorEfec;
            datADCDOC.Doc_Oculto = formulario.propiedadesDoc.ClaveOculto;
            datADCDOC.Doc_Contabilidad = formulario.propiedadesDoc.ClaveContable;
            datADCDOC.Doc_Banco = Convert.ToInt16(formulario.propiedadesDoc.ClaveBanco);
            datADCDOC.Doc_Inventario = Convert.ToInt16(formulario.propiedadesDoc.ClaveInventario);
            datADCDOC.Doc_Ventas = Convert.ToInt16(formulario.propiedadesDoc.ClaveVentas);
            datADCDOC.Doc_Compras = Convert.ToInt16(formulario.propiedadesDoc.ClaveCompras);
            datADCDOC.Doc_Activo = Convert.ToInt16(formulario.propiedadesDoc.ClaveActivo);
            datADCDOC.Doc_Adicional2 = 0;
            datADCDOC.Doc_NumeroExterno = 0;
            datADCDOC.IdClaveDocSop = Convert.ToDecimal(formulario.idDocumentoSoporte.idClave);
            datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
            datADCDOC.doc_TotDesSiva = formulario.totalesDocumento.totdessiva;
            datADCDOC.doc_TotDesCIva = formulario.totalesDocumento.totdesciva;

            datADCDOC.ProductoProduccion = "";            // ProductoProduccion.Text
            datADCDOC.BaseImp1 = formulario.totalesDocumento.Subtotalciva;
            datADCDOC.ValorImp1 = formulario.totalesDocumento.TotImp1;
            datADCDOC.PorcImp1 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje1);

            //datADCDOC.BaseImp2 = totalesDocumento.Subtotalciva2;
            datADCDOC.ValorImp2 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp2 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.BaseImp3 = totalesDocumento.Subtotalciva3;
            datADCDOC.ValorImp3 = formulario.totalesDocumento.TotImp2;
            datADCDOC.PorcImp3 = Convert.ToDecimal(formulario.claseImpuestos.impstoPorcentaje2);

            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacDesde = FDesde.Value;
            //datADCDOC.FacHasta = FHasta.Value;
            //datADCDOC.TipoPeriodo = "";
        }

        internal string origenClasificador(string NomClasificador)
        {
            string ssql = "Select origenValores from AdcClasfctb where nombre = '" + NomClasificador + "'";
            SqlDataReader dr = SqlDatos.leerBaseAdcom(ssql);
            ssql = "";
            if (dr.Read()) ssql = dr["origenValores"].ToString();
            return ssql;
        }
    }
}