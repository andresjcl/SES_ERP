//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace adcDocumentos
//{
//    public class armaItemsMed
//    {

//        internal void FacturarAtencionMedicaExterna(string[] infoCitasMedicas)
//        {
//            decimal IdClaveCita = 0;
//            string FacturarConceptos = "";
//            int TurnoMedico = 0;
//            string[] SistemaMedico = (infoCitasMedicas[0] + ";;;;;;;;").Split(Convert.ToChar(";"));
//            if (infoCitasMedicas.Length > 1) FacturarConceptos = infoCitasMedicas[1];

//            if (SistemaMedico[0] == "CITMED")
//            {
//                cmbDocumento.SelectedValue = SistemaMedico[1];
//                txtcedula.Text = SistemaMedico[2];
//                IdClaveCita = Convert.ToDecimal(SistemaMedico[8]);
//                TurnoMedico = Convert.ToInt16(SistemaMedico[9]);
//                cmbVendedor.SelectedValue = SistemaMedico[10];
//                if (txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
//                FacturarCitasMedicas(SistemaMedico[3], SistemaMedico[4], SistemaMedico[5], Convert.ToInt16(SistemaMedico[6]), Convert.ToDouble(SistemaMedico[7]), FacturarConceptos);
//            }
//            else if (SistemaMedico[0] == "CONMED")
//            {
//                cmbDocumento.SelectedValue = SistemaMedico[1];
//                txtcedula.Text = SistemaMedico[2];
//                cmbVendedor.SelectedValue = SistemaMedico[3];
//                if (txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
//                FacturarConceptosMedicos(SistemaMedico, 0, 4);
//                dtDetalleDocumento.Rows.Add();
//                malla.Refresh();

//            }
//        }
//        private void FacturarCitasMedicas(string TipoConcepto, string NombreConcepto, string NombreConcepto2, int Cantidad, Double PrecioUnitario, string Conceptos)
//        {
//            int ind = 0;
//            dtDetalleDocumento.Rows.Add();
//            malla.Refresh();
//            DataGridViewRow row = malla.Rows[ind];
//            row.Cells["TRA_NUMLINEA"].Value = ind + 1;
//            row.Cells["tra_codigo"].Value = TipoConcepto;
//            daxMallaDatos.docMallaArticulo mallaArticulo = new docMallaArticulo();
//            mallaArticulo.CargarServicios(TipoConcepto, ref malla, claseImpuestos.impstoPorcentaje1, nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
//            mallaArticulo = null;
//            row.Cells["tra_nombre"].Value = NombreConcepto;
//            row.Cells["tra_cantidad"].Value = Cantidad;
//            row.Cells["tra_medida"].Value = "";
//            row.Cells["Tra_precuni"].Value = PrecioUnitario;
//            row.Cells["tra_porcendes"].Value = 0;
//            row.Cells["tra_valordes"].Value = 0;
//            row.Cells["Tra_prectot"].Value = Cantidad * PrecioUnitario;
//            row.Cells["TRA_SNIVA"].Value = false;

//            row.Cells["tra_quetipo"].Value = "S";
//            row.Cells["tra_esCuenta"].Value = 0;
//            row.Cells["Tra_individual"].Value = "N";
//            row.Cells["tra_costuni"].Value = 0;
//            row.Cells["Tra_CostTot"].Value = 0;
//            row.Cells["tra_multiplo"].Value = 1;
//            row.Cells["Despacho"].Value = 0;
//            row.Cells["tra_numprecio"].Value = 1;

//            if (NombreConcepto2.Length > 0)
//            {
//                dtDetalleDocumento.Rows.Add();
//                malla.Refresh();
//                ind++;
//                row = malla.Rows[ind];
//                row.Cells["TRA_NUMLINEA"].Value = ind + 1;
//                row.Cells["tra_codigo"].Value = ".";
//                row.Cells["tra_nombre"].Value = NombreConcepto2;
//                row.Cells["tra_cantidad"].Value = 0;
//                row.Cells["tra_medida"].Value = "";
//                row.Cells["Tra_precuni"].Value = 0;
//                row.Cells["tra_porcendes"].Value = 0;
//                row.Cells["tra_valordes"].Value = 0;
//                row.Cells["Tra_prectot"].Value = 0;
//                row.Cells["TRA_SNIVA"].Value = false;

//                row.Cells["tra_quetipo"].Value = "";
//                row.Cells["tra_esCuenta"].Value = 0;
//                row.Cells["Tra_individual"].Value = "";
//                row.Cells["tra_costuni"].Value = 0;
//                row.Cells["Tra_CostTot"].Value = 0;
//                row.Cells["tra_multiplo"].Value = 0;
//                row.Cells["Despacho"].Value = 0;
//                row.Cells["tra_numprecio"].Value = 0;
//            }
//            if (Conceptos.Length > 0) FacturarConceptosMedicos(Conceptos.Split(Convert.ToChar(";")), ind, 3);
//            dtDetalleDocumento.Rows.Add();
//            malla.Refresh();
//        }

//        private void FacturarConceptosMedicos(string[] Conceptos, int Linea, int indice)
//        {
//            string TipoConcepto = "";
//            for (int l = indice; l < Conceptos.Length; l = l + 4)
//            {
//                TipoConcepto = Conceptos[l];
//                if (TipoConcepto.Length > 0)
//                {
//                    dtDetalleDocumento.Rows.Add();
//                    malla.Refresh();
//                    Linea++;
//                    DataGridViewRow row = malla.Rows[Linea];
//                    row.Cells["TRA_NUMLINEA"].Value = Linea + 1;
//                    row.Cells["tra_codigo"].Value = TipoConcepto;
//                    daxMallaDatos.docMallaArticulo mallaArticulo = new docMallaArticulo();
//                    mallaArticulo.CargarServicios(TipoConcepto, ref malla, claseImpuestos.impstoPorcentaje1, nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
//                    mallaArticulo = null;
//                    row.Cells["tra_nombre"].Value = Conceptos[l + 1];
//                    row.Cells["tra_cantidad"].Value = Conceptos[l + 2];
//                    row.Cells["tra_medida"].Value = "";
//                    row.Cells["Tra_precuni"].Value = Conceptos[l + 3];
//                    row.Cells["tra_porcendes"].Value = 0;
//                    row.Cells["tra_valordes"].Value = 0;
//                    row.Cells["Tra_prectot"].Value = Convert.ToDouble(row.Cells["tra_cantidad"].Value) * Convert.ToDouble(row.Cells["Tra_precuni"].Value);
//                    row.Cells["TRA_SNIVA"].Value = false;

//                    row.Cells["tra_quetipo"].Value = "S";
//                    row.Cells["tra_esCuenta"].Value = 0;
//                    row.Cells["Tra_individual"].Value = "N";
//                    row.Cells["tra_costuni"].Value = 0;
//                    row.Cells["Tra_CostTot"].Value = 0;
//                    row.Cells["tra_multiplo"].Value = 1;
//                    row.Cells["Despacho"].Value = 0;
//                    row.Cells["tra_numprecio"].Value = 1;
//                }
//            }
//        }


//    }
//}
