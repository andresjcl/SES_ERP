using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SysEmpDatt;
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

            string codsql = " FROM DaxSriRet WHERE SRI_sucursal='" + DatosDoc.Doc_sucursal + "' and SRI_documento='" + DatosDoc.Opc_documento + "' and sri_idclavedoc=" + DatosDoc.IdClaveDoc;
            DataTable dataTab = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter("select * " + codsql, datosEmpresa.strConxAdcom))
            {
                da.Fill(dataTab);
                foreach (DataRow row in dataTab.Rows )
                {
                    row.Delete();
                }
                int I = 0;
                foreach (DataGridViewRow DgvRow in malla.Rows)
                {
                    if (DgvRow.Cells["CodigoRetencion"] != null && DgvRow.Cells["CodigoRetencion"].Value.ToString().Length > 0)
                    {                      
                        DataRow dtRow = dataTab.NewRow();
                        dtRow["SRI_sucursal"] = DatosDoc.Doc_sucursal;
                        dtRow["SRI_Documento"] = DatosDoc.Opc_documento;
                        dtRow["SRI_IdClaveDoc"] = DatosDoc.IdClaveDoc;
                        dtRow["SRI_numeroretencion"] = DatosDoc.Doc_numero;
                        dtRow["Doc_Sucursal"] = DgvRow.Cells["Doc_Sucursal"].Value ;
                        dtRow["DOC_OpcDocumento"] = DgvRow.Cells["DOC_OpcDocumento"].Value;
                        dtRow["DOc_Numero"] = DgvRow.Cells["DOc_Numero"].Value;
                        dtRow["Doc_idclave"] = DgvRow.Cells["Doc_idclave"].Value ;
                        dtRow["Doc_Codsri"] = DgvRow.Cells["Doc_Codsri"].Value;
                        dtRow["TipoRetencion"] = DgvRow.Cells["TipoRetencion"].Value;
                        dtRow["CodigoRetencion"] = DgvRow.Cells["CodigoRetencion"].Value;
                        dtRow["BaseRetencion"] = DgvRow.Cells["BaseRetencion"].Value;
                        dtRow["PorcRetencion"] = DgvRow.Cells["PorcRetencion"].Value ;
                        dtRow["ValorRetencion"] = DgvRow.Cells["ValorRetencion"].Value;
                        dtRow["BaseConIva"] = DgvRow.Cells["BaseConIva"].Value;
                        dtRow["BaseExcentaIva"] = DgvRow.Cells["BaseExcentaIva"].Value;
                        dtRow["BaseIvaCero"] = DgvRow.Cells["BaseIvaCero"].Value;
                        I++;
                        dtRow["Doc_linea"] = I;
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
        internal static void moverDatosAclase(MantRetencion formulario)
        {
            formulario.DatosDocumento.IdClaveDoc = Convert.ToDecimal(formulario.idDocumentoActual.idClave);
            formulario.DatosDocumento.Doc_sucursal = SysEmpDatt.datosEmpresa.sucursal;
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

            formulario.DatosDocumento.Doc_DocSop = "";
            formulario.DatosDocumento.Doc_NumSop = 0;
            formulario.DatosDocumento.IdClaveDocSop = 0;

            formulario.DatosDocumento.Doc_valor = Convert.ToDecimal(formulario.edTotal.Text);
            formulario.DatosDocumento.AuxVar9 = "";
            formulario.DatosDocumento.Doc_Hora = DateTime.Now;

            formulario.DatosDocumento.Doc_NroLoteDoc = "";
            //formulario.DatosDocumento.Doc_NroIdDoc = txtNroID.Text;
            formulario.DatosDocumento.Adi_TipoDocSri = formulario.propiedadesDoc.TipoSri;
            //formulario.DatosDocumento.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
            //formulario.DatosDocumento.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
            //formulario.DatosDocumento.Adi_SustTrib = DatSustento.BoundText
            //formulario.DatosDocumento'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
            //formulario.DatosDocumento.Doc_docnombre = "";
            formulario.DatosDocumento.Doc_TipoDoc = formulario.idDocumentoActual.familia;
            formulario.DatosDocumento.Doc_FechaEfe = formulario.DatosDocumento.Doc_fecha;
            formulario.DatosDocumento.Doc_Hora = DateTime.Now;
            formulario.DatosDocumento.Doc_extension = "";
            formulario.DatosDocumento.Doc_codusu = DatosUsuario.codigo;
            //formulario.DatosDocumento.Doc_valoriva = totalesDocumento.TotIva;
            //formulario.DatosDocumento.Doc_totciva = totalesDocumento.TotCiva;
            //formulario.DatosDocumento.Doc_totsiva = totalesDocumento.TotSiva;
            //formulario.DatosDocumento.doc_TotDesSiva = totalesDocumento.totdessiva;
            //formulario.DatosDocumento.doc_TotDesCIva = totalesDocumento.totdesciva;            //formulario.DatosDocumento.Doc_valorabon = totalesDocumento.ValorCon;
            //formulario.DatosDocumento.Doc_DepDes = "";
            //formulario.DatosDocumento.Doc_TotDesArt = totalesDocumento.TotDesArt;
            //formulario.DatosDocumento.Doc_TotDesSer = totalesDocumento.TotDesSer;
            //formulario.DatosDocumento.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
            //formulario.DatosDocumento.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
            //formulario.DatosDocumento.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
            //formulario.DatosDocumento.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
            //formulario.DatosDocumento.Doc_TotAcf = totalesDocumento.TotAcf;
            //formulario.DatosDocumento.Doc_Contado = totalesDocumento.ValorEfec;
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
            formulario.DatosDocumento.doc_BancoOrigen = "";
            formulario.DatosDocumento.doc_BancoOrigen = "";
            formulario.DatosDocumento.doc_Anticipo = false;
            formulario.DatosDocumento.doc_BancoDestino = "";
        }
    }
}
