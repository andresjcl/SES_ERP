using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ClassAts
{
    public class grabaDatos
    {
        public void grabarAts(int tipo, System.Windows.Forms.DataGridView malla, string strConxIvaret, DateTime fechaini, DateTime fechafin)
        {            
            string sel;
            string campoControl = "";
            string campoControl2 = "";
            string mensaje;

            string fechas = "";

            if (tipo == 0) //compras
            {
                mensaje = "compras";
                sel = "select * from compras " + fechas;
                campoControl = "codSustento";
                campoControl2 = "idProv";
                fechas = " where Cl_FechaRegContable >= '" + fechaini.ToShortDateString() + "' and Cl_FechaRegContable <= '" + fechafin.ToShortDateString() + "' ";
            }
            else if (tipo == 1) //ventas
            {
                mensaje = "ventas";
                sel = "select * from ventas " + fechas;
                campoControl = "idCliente";
                campoControl2 = "tipoComprobante";
                fechas = " where cl_anio = "+ (fechafin.Year).ToString() +" and cl_mes <= " + fechafin.Month.ToString() + " and cl_mes >= " + fechaini.Month.ToString();
            }
            else if (tipo == 2) //exportaciones
            {
                mensaje = "exportacion";
                sel = "select * from exportacion " + fechas;
                campoControl = "exportacionDe";
                campoControl2 = "tipoComprobante";
            }
            else if (tipo == 3) //anulaciones
            {
                mensaje = "anulaciones";
                sel = "select * from anulados " + fechas;
                campoControl = "tipoComprobante";
                campoControl2 = "establecimiento";
            }
            else return;
            using (var datAdapt = new SqlDataAdapter(sel, strConxIvaret))
            using (new SqlCommandBuilder(datAdapt))
            {
            DataTable dataTbl = new DataTable();
            datAdapt.Fill(dataTbl);
            DataRow datRow = dataTbl.NewRow();
            foreach (DataRow row in dataTbl.Rows)
            {
                    row.Delete();
            }
             //Int32 i = 0;
            try
            {
                foreach (DataGridViewRow row in malla.Rows)
                {
                    if (row.Cells[campoControl].Value != null && row.Cells[campoControl2].Value != null)
                    {
                            //if (i <= dataTbl.Rows.Count - 1) { datRow = dataTbl.Rows[i]; } else { datRow = dataTbl.NewRow(); }
                            datRow = dataTbl.NewRow();
                            if (tipo == 0) moverMallaCompras(datRow, row);
                            else if (tipo == 1) moverMallaVentas(datRow, row);
                            else if (tipo == 2) moverMallaExportaciones(datRow, row);
                            else if (tipo == 3) moverMallaAnulaciones(datRow, row);
                            else return;
                            dataTbl.Rows.Add(datRow);
                            //if (i > dataTbl.Rows.Count - 1) dataTbl.Rows.Add(datRow);
                            //i++;
                        }
                }                    
            
            datAdapt.Update(dataTbl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("excepcion: datos de " + mensaje + " \n" + ex.Message);
            }                       
          }            
        }

        private void moverMallaCompras(DataRow r, DataGridViewRow row)
        {
            r["CL_SusTributario"] = row.Cells["codSustento"].Value;
            r["CL_TipoIdProveedor"] = row.Cells["tpIdProv"].Value;
            r["CL_TipoProveedor"] = row.Cells["tipoProv"].Value;
            r["CL_CodigoProveedor"] = row.Cells["idProv"].Value;
            r["CL_NombreProveedor"] = row.Cells["nombre"].Value;
            r["CL_ParteRelacionada"] = row.Cells["parteRel"].Value;
            r["Cl_TipoComprobante"] = row.Cells["tipoComprobante"].Value;
            r["CL_FechaRegContable"] = row.Cells["fechaRegistro"].Value;
            r["CL_NroSerieEstablec"] = row.Cells["establecimiento"].Value;
            r["CL_NroSeriePtoEmision"] = row.Cells["puntoEmision"].Value;
            r["CL_NroSecuencial"] = row.Cells["secuencial"].Value;
            r["CL_FechaComprobante"] = row.Cells["fechaEmision"].Value;
            r["CL_NroAutorizacion"] = row.Cells["autorizacion"].Value;
            r["CL_BaseNoGrabaIva"] = row.Cells["baseNoGraIva"].Value;
            r["CL_BaseImpTarCero"] = row.Cells["baseImponible"].Value;
            r["CL_BaseImpGravadaIva"] = row.Cells["baseImpGrav"].Value;
            r["baseImpExe"] = row.Cells["baseImpExe"].Value;
            r["CL_MontoICE"] = row.Cells["montoIce"].Value;
            r["CL_MontoIva"] = row.Cells["montoIva"].Value;
            r["valRetBien10"] = row.Cells["valRetBien10"].Value;
            r["valRetServ20"] = row.Cells["valRetServ20"].Value;
            r["CL_MontoRetIvaBienes"] = row.Cells["valorRetBienes"].Value;
            r["CL_MontoRetIvaServicios"] = row.Cells["valorRetServicios"].Value;
            r["CL_MontoRetIva100"] = row.Cells["valRetServ100"].Value;
            r["CL_pagoLocExt"] = row.Cells["pagoLocExt"].Value;
            
            r["CL_pagoPais"] = row.Cells["paisEfecPago"].Value;
            r["CL_dobleTributacion"] = row.Cells["aplicConvDobTrib"].Value;
            r["CL_pagoSujetoRetencion"] = row.Cells["pagExtSujRetNorLeg"].Value;
            r["pagoRegFis"] = row.Cells["pagoRegFis"].Value;
            r["CL_formaDePago"] = row.Cells["formaPago"].Value;
            r["CL_CodRetFteImpRenta0"] = row.Cells["codRetAir"].Value;
            r["CL_BaseImponibleIR0"] = row.Cells["baseImpAir"].Value;
            r["CL_CodPorcRetIR0"] = row.Cells["porcentajeAir"].Value;
            r["CL_MontoRetIR0"] = row.Cells["valRetAir"].Value;
            try
            {
                r["fechaPagoDiv"] = row.Cells["fechaPagoDiv"].Value;
            }
            catch { }
            r["imRentaSoc"] = row.Cells["imRentaSoc"].Value;
            r["anioUtDiv"] = row.Cells["anioUtDiv"].Value;
            r["NumCajBan"] = row.Cells["NumCajBan"].Value;
            r["PrecCajBan"] = row.Cells["PrecCajBan"].Value;
            r["CL_CodRetFteImpRenta1"] = row.Cells["codRetAir1"].Value;
            r["CL_BaseImponibleIR1"] = row.Cells["baseImpAir1"].Value;
            r["CL_CodPorcRetIR1"] = row.Cells["porcentajeAir1"].Value;
            r["CL_MontoRetIR1"] = row.Cells["valRetAir1"].Value;
            r["fechaPagoDiv1"] = row.Cells["fechaPagoDiv1"].Value;
            r["imRentaSoc1"] = row.Cells["imRentaSoc1"].Value;
            r["anioUtDiv1"] = row.Cells["anioUtDiv1"].Value;
            r["NumCajBan1"] = row.Cells["NumCajBan1"].Value;
            r["PrecCajBan1"] = row.Cells["PrecCajBan1"].Value;
            r["codRetAir2"] = row.Cells["codRetAir2"].Value;
            r["baseImpAir2"] = row.Cells["baseImpAir2"].Value;
            r["porcentajeAir2"] = row.Cells["porcentajeAir2"].Value;
            r["valRetAir2"] = row.Cells["valRetAir2"].Value;
            r["fechaPagoDiv2"] = row.Cells["fechaPagoDiv2"].Value;
            r["imRentaSoc2"] = row.Cells["imRentaSoc2"].Value;
            r["anioUtDiv2"] = row.Cells["anioUtDiv2"].Value;
            r["NumCajBan2"] = row.Cells["NumCajBan2"].Value;
            r["PrecCajBan2"] = row.Cells["PrecCajBan2"].Value;
            r["codRetAir3"] = row.Cells["codRetAir3"].Value;
            r["baseImpAir3"] = row.Cells["baseImpAir3"].Value;
            r["porcentajeAir3"] = row.Cells["porcentajeAir3"].Value;
            r["valRetAir3"] = row.Cells["valRetAir3"].Value;
            r["fechaPagoDiv3"] = row.Cells["fechaPagoDiv3"].Value;
            r["imRentaSoc3"] = row.Cells["imRentaSoc3"].Value;
            r["anioUtDiv3"] = row.Cells["anioUtDiv3"].Value;
            r["NumCajBan3"] = row.Cells["NumCajBan3"].Value;
            r["PrecCajBan3"] = row.Cells["PrecCajBan3"].Value;
            r["CL_NroSerieCpbteRetEstable"] = row.Cells["estabRetencion1"].Value;
            r["CL_NroSerieCpbteRetEmision"] = row.Cells["ptoEmiRetencion1"].Value;
            r["CL_NroSecuencialCpbteRet"] = row.Cells["secRetencion1"].Value;
            r["CL_NroAutorizaCpbteRete"] = row.Cells["autRetencion1"].Value;
            r["CL_FechaEmisionCpbteRete"] = row.Cells["fechaEmiRet1"].Value;
            r["Clave"] = row.Cells["Clave"].Value;
            r["doc_sucursal"] = row.Cells["SUC"].Value;
            r["opc_documento"] = row.Cells["DOC"].Value;
            r["idclavedoc"] = row.Cells["idclavedoc"].Value;
            r["opc_documento"] = row.Cells["DOC"].Value;
            r["tipoEmision"] = row.Cells["tipoEmision"].Value;
            r["Cl_Anio"] = row.Cells["Cl_anio"].Value;
            r["Cl_Mes"] = row.Cells["Cl_Mes"].Value;
            r["tipoRegi"] = row.Cells["tipoRegi"].Value;
            //r["doc_fecha"] = row.Cells["doc_fecha"].Value;

        }
        private void moverMallaVentas(DataRow r, DataGridViewRow row)
        {
            r["Cl_TipoId"] = row.Cells["tpIdCliente"].Value;
            r["Cl_CodigoCliente"] = row.Cells["idCliente"].Value;
            r["Cl_NombreCliente"] = row.Cells["Nombre"].Value;
            r["parteRelVtas"] = row.Cells["parteRelVtas"].Value;
            r["Cl_TipoComprobante"] = row.Cells["tipoComprobante"].Value;
            r["CL_NroDeComprobantes"] = row.Cells["numeroComprobantes"].Value;
            r["CL_BaseNoGrabaIva"] = row.Cells["baseNoGraIva"].Value;
            r["CL_BaseImpTarCero"] = row.Cells["baseImponible"].Value;
            r["CL_BaseImpGravadaIva"] = row.Cells["baseImpGrav"].Value;
            r["CL_MontoIva"] = row.Cells["montoIva"].Value;
            r["montoIce"] = row.Cells["montoIce"].Value;
            r["tipoEmision"] = row.Cells["tipoEmision"].Value;
            r["CL_ValorRetIva"] = row.Cells["valorRetIva"].Value;
            r["CL_ValorRetRenta"] = row.Cells["valorRetRenta"].Value;
            r["Clave"] = row.Cells["Clave"].Value;
            r["CL_Anio"] = row.Cells["CL_Anio"].Value;
            r["CL_Mes"] = row.Cells["CL_Mes"].Value;
            r["tipoEmision"] = row.Cells["tipoEmision"].Value;
            r["tipoPersona"] = row.Cells["tipoPersona"].Value;
        }
        private void moverMallaExportaciones(DataRow r, DataGridViewRow row)
        {        

            r["tpIdClienteEx"] = row.Cells["tpIdClienteEx"].Value;                 
            r["idClienteEx"] = row.Cells["idClienteEx"].Value; 
            r["parteRel"] = row.Cells["parteRel"].Value; 
            r["paisEfecExp"] = row.Cells["paisEfecExp"].Value;
            r["CL_ExportaciónDe"] = row.Cells["exportacionDe"].Value;
            r["Cl_TipoComprobante"] = row.Cells["tipoComprobante"].Value;
            r["CL_ReferendoDistrito"] = row.Cells["distAduanero"].Value;
            r["CL_ReferendoAño"] = row.Cells["anio"].Value;
            r["CL_ReferendoRegimen"] = row.Cells["regimen"].Value;
            r["CL_ReferendoCorrelativo"] = row.Cells["correlativo"].Value;
            r["CL_NroDocTransporte"] = row.Cells["docTransp"].Value;
            try
            {
                r["CL_FechaTransaccion"] = row.Cells["fechaEmbarque"].Value;
            }
            catch { r["CL_FechaTransaccion"] = DateTime.Now; }
            r["CL_ValorFOB"] = row.Cells["valorFOB"].Value;
            r["CL_ValorComprobante"] = row.Cells["valorFOBComprobante"].Value;
            r["CL_NroSerieCpbteEstablec"] = row.Cells["establecimiento"].Value;
            r["CL_NroSerieCpbteEmision"] = row.Cells["puntoEmision"].Value;
            r["CL_NroSecuencialCpbte"] = row.Cells["secuencial"].Value;
            r["CL_NroAutorizacion"] = row.Cells["autorizacion"].Value;
            r["CL_FechaEmision"] = row.Cells["fechaEmision"].Value;
            r["doc"] = row.Cells["doc"].Value;
            r["suc"] = row.Cells["suc"].Value;

            r["Clave"] = row.Cells["Clave"].Value;
            r["CL_mes"] = row.Cells["CL_mes"].Value;
            r["CL_anio"] = row.Cells["CL_anio"].Value;      
            r["tipoCli"] = row.Cells["tipoCli"].Value;
            r["tipoRegi"] = row.Cells["tipoRegi"].Value;
            r["paisEfecPagoGen"] = row.Cells["paisEfecPagoGen"].Value;
            r["paisEfecPagoParFi"] = row.Cells["paisEfecPagoParFi"].Value;
            r["denopagoRegFis"] = row.Cells["denopagoRegFis"].Value;
            r["denoExpCli"] = row.Cells["denoExpCli"].Value;
            r["pagoRegFis"] = row.Cells["pagoRegFis"].Value;
        }
        private void moverMallaAnulaciones(DataRow r, DataGridViewRow row)
        {
            r["Cl_TipoComprobante"] = row.Cells["tipoComprobante"].Value;
            r["CL_NroSerieEstableci"] = row.Cells["establecimiento"].Value;
            r["CL_NroSerieEmision"] = row.Cells["emision"].Value;
            r["CL_NroSecuencialDesde"] = row.Cells["secuencialInicio"].Value;
            r["CL_NroSecuencialHasta"] = row.Cells["secuencialFin"].Value;
            r["CL_NroAutorizacion"] = row.Cells["autorizacion"].Value;
            r["Clave"] = row.Cells["Clave"].Value;
            r["cl_anio"] = row.Cells["Cl_Anio"].Value;
            r["cl_Mes"] = row.Cells["Cl_Mes"].Value;
            r["doc"] = row.Cells["doc"].Value;
            r["suc"] = row.Cells["suc"].Value;
            r["idclavedoc"] = row.Cells["idclavedoc"].Value;
        }
    }
}
