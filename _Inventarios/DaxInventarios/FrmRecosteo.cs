using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;

namespace DaxInvent
{
    public partial class FrmRecosteo : Form
    {
        DateTime FecSaldoInicial;
        //ICollection<string> TipDoc;
        public FrmRecosteo()
        {
            InitializeComponent();
            ParametrosIniciales();
        }
        private void ParametrosIniciales()
        {
            actualizacionBase();
            try
            {
                labCierre.Text = datosEmpresa.UltimoCierreAnual.ToShortDateString();

                labFechaDoc.Text = datosEmpresa.FechaLimiteDocumentos.ToShortDateString();
                if (datosEmpresa.FechaLimiteDocumentos > datosEmpresa.UltimoCierreAnual)
                {
                    labDesde.Text = datosEmpresa.FechaLimiteDocumentos.ToShortDateString();
                    FecSaldoInicial = datosEmpresa.FechaLimiteDocumentos.AddDays(-1);
                }
                else
                {
                    labDesde.Text = datosEmpresa.UltimoCierreAnual.AddDays(1).ToShortDateString();
                    FecSaldoInicial = datosEmpresa.UltimoCierreAnual;
                }
            }
            catch { MessageBox.Show("Revise las fechas de último cierre, emisión de documentos, están erradas"); }
        }
        private void actualizacionBase()
        {
           string ssql = " IF NOT EXISTS(SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name = 'AdcTra' and col.name = 'ActCst')";
            ssql += " BEGIN ALTER TABLE AdcTra Add [ActCst] [bit] null End";
            SqlDatos.ejecutarComandoAdcom(ssql);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            procesar();
        }
        private void procesar()
        {
            Boolean existenErores = false;
            try
            {
                SqlDataReader rs = SqlDatos.leerBaseAdcom("Select top 1 *  from InvRecst");
                if (rs.Read()) existenErores = true;
            }
            catch { }
            if (existenErores)
            {
                MessageBox.Show("Existe una lista de errores de un proceso anterior anterior sin justificar \n Si desea proseguir debe justificar o eliminar los errores existentes \nUtilice la opcion [Analizar errores]");
                return;
            }

            if (classMenSistem.mensajesErrorDocumento.Respuesta("Confirma procesar recosteo de artículos en documentos ? ") == false) return;
            ProcesarRecosteo();
        }
        private void ProcesarRecosteo()
        {
            string ArticuloAnterior = "";
            string elerror;
            SaldoArticulo saldoArticulo = new SaldoArticulo();
            double UltimoPromedioValido = 0;
            bool CostoHistorico = false;
            sesSys.OpcDoc opc = new sesSys.OpcDoc();
            string Opcdoc = "";
            bool sihayerror = false;

            string Tra_Codigo = "";
            DataTable RsDoc = SqlDatos.leerTablaAdcom("InvRcstLeeTra '" + labDesde.Text + "','" + dtFechaLimiteProceso.Text + "'");
            if (RsDoc.Rows.Count < 1)
            {
                classMenSistem.mensajesErrorDocumento.neutro("No existen documentos para procesar en el período indicado ");
                return;
            }

            foreach (DataRow row in RsDoc.Rows)
            {
                elerror = "";
                Tra_Codigo = row["Tra_Codigo"].ToString();
                if (ArticuloAnterior != Tra_Codigo)
                {
                    saldoArticulo = ultimosValor.SaldoFecha(datosEmpresa.strConxAdcom, Tra_Codigo, dtFechaLimiteProceso.Text);
                    ArticuloAnterior = Tra_Codigo;
                    CostoHistorico = false;
                }
                if (saldoArticulo.CostoPromedio <= 0)
                {
                    saldoArticulo.CostoPromedio = ultimosValor.CargarPromedioHistorico(ArticuloAnterior, Convert.ToDateTime(row["tra_fecha"]));
                    CostoHistorico = true;
                }


                if (Convert.ToInt16(row["Tra_Inventario"]) == 0)
                {
                    row["tra_costuni"] = saldoArticulo.CostoPromedio;
                    row["Tra_CostTot"] = Math.Round(saldoArticulo.CostoPromedio * Convert.ToDouble(row["TRA_CANTIDAD"]), datosEmpresa.Par_DigitosCostos);
                    //     .Update
                }
                else
                {
                    if (Opcdoc != row["Opc_documento"].ToString())
                    {
                        Opcdoc = row["Opc_documento"].ToString();
                        string aux = "";
                        opc.Cargar(ref Opcdoc,ref aux);
                    }
                    double traCanti = Convert.ToDouble(row["TRA_CANTIDAD"]);
                    double multiplo = Convert.ToDouble(row["tra_multiplo"]);
                    if (multiplo == 0) multiplo = 1;
                    double traCantidad = Math.Round(traCanti * multiplo, datosEmpresa.Par_DigitosCostos);

                    //            ' verificar si debe poner el costo promedio

                    if (opc.TipoCosteo == "P" || opc.TipoCosteo == "U")
                    {
                        if (traCanti == 0)
                        {
                            elerror += " Cantidad = Cero";
                        }
                        else
                        {
                            row["Tra_CostTot"] = Math.Round(saldoArticulo.CostoPromedio * traCantidad, datosEmpresa.Par_DigitosCostos);
                            row["tra_costuni"] = saldoArticulo.CostoPromedio;
                            if (saldoArticulo.CantidadTotal + traCantidad * Convert.ToInt16(row["Tra_Inventario"]) == 0)
                            {
                                row["Tra_CostTot"] = saldoArticulo.CostoTotal;
                                row["tra_costuni"] = Math.Round(Convert.ToDouble(row["Tra_CostTot"]) / traCanti, datosEmpresa.Par_DigitosCostos);
                            }
                        }
                        //AumentarTipo(Opcdoc);
                        if (Convert.ToDouble(row["tra_costuni"]) == 0)
                        {
                            elerror += " costo prom = Cero";
                        }
                        else
                        { if (CostoHistorico == false) GrabarPromedioHistorico(ArticuloAnterior, Convert.ToDateTime(row["tra_fecha"]), saldoArticulo.CostoPromedio); }
                        //                End If
                        //                .Update

                    }
                    else if (opc.TipoCosteo == "D" && Convert.ToInt16(row["TRa_Compras"]) != 0)
                    {
                        row["Tra_CostTot"] = row["Tra_prectot"];

                        row["tra_costuni"] = row["Tra_precuni"];

                        if (row["tra_quetipo"].ToString() == "") row["tra_quetipo"] = "A";

                        if (Convert.ToDouble(row["tra_costuni"]) == 0) elerror += " costo dig = Cero";
    //                    .Update
                    }
                    if (row["tra_BodDestino"].ToString() == "")
                    {
                        saldoArticulo.CantidadTotal  = Math.Round(saldoArticulo.CantidadTotal + traCantidad * Convert.ToInt16(row["Tra_Inventario"]), datosEmpresa.Par_DigitosCostos);
                        saldoArticulo.CostoTotal = Math.Round(saldoArticulo.CostoTotal + Convert.ToDouble(row["Tra_CostTot"]) * Convert.ToInt16(row["Tra_Inventario"]), datosEmpresa.Par_DigitosCostos);
                        if (saldoArticulo.CantidadTotal < 0 && Convert.ToInt16(row["Tra_Inventario"]) < 0) elerror += " Saldo Negativo general ";
                        if (elerror == "" && saldoArticulo.CostoTotal < 0 && Convert.ToInt16(row["Tra_Inventario"]) < 0) elerror += " costo Negativo ";
                    }
                    if ((saldoArticulo.CantidadTotal > 0 && saldoArticulo.CostoTotal > 0) || (saldoArticulo.CantidadTotal < 0 && saldoArticulo.CostoTotal < 0))
                    {
                        saldoArticulo.CostoPromedio = Math.Round(saldoArticulo.CostoTotal / saldoArticulo.CantidadTotal, datosEmpresa.Par_DigitosCostos);
                        if (CostoHistorico == false && Convert.ToDouble(row["tra_costuni"]) > 0 && saldoArticulo.CostoPromedio != UltimoPromedioValido) GrabarPromedioHistorico(ArticuloAnterior, Convert.ToDateTime(row["tra_fecha"]), saldoArticulo.CostoPromedio);
                        UltimoPromedioValido = saldoArticulo.CostoPromedio;
                        CostoHistorico = true;
                    }
                }
                if (elerror.Length > 0)
                {
                    GuardarError(row, elerror);
                    sihayerror = true;
                }
            }
            procesarCostosArticulosCompuestos();
            ActualizarValoresDocumentos();

            if  (sihayerror)
            {
                MessageBox.Show("Existen errores en el proceso, debe justificarlos para tener reportes óptimos\nNo se registrará este proceso como correcto");
            }
            else
            {
                SqlDatos.ejecutarComandoAdcom("update adccie set Cie_InvUltAct = '" + dtFechaLimiteProceso.Text + "' ");
                MessageBox.Show("Se ha reactualzado los costos satisfactoriamente.");
            }
        }
        //private void AumentarTipo(string TDoc)
        //{
        //    int j = 0;
        //    foreach (string tip in TipDoc)
        //    {
        //        if (tip == TDoc) { j = 1; break; }
        //    }
        //    if (j == 0)
        //    {
        //        TipDoc.Add(TDoc);
        //    }
        //}
        private void GrabarPromedioHistorico(string ArticuloAnt , DateTime tra_fecha , double CostoPromedio)
        {
            if (ArticuloAnt == "" || CostoPromedio == 0) return;
            string ssql = "SELECT * ";
            ssql += " From AdcCstProm Where tra_codigo = '" + ArticuloAnt + "' ";
            ssql += " and (año * 100 + mes ) = " + tra_fecha.Year * 100 + tra_fecha.Month;
            SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            DataTable rs = new DataTable();
            da.Fill(rs);
            if (rs.Rows.Count  < 1)
            {
                DataRow row = rs.NewRow();
                row["Tra_Codigo"] = ArticuloAnt;
                row["Año"] = tra_fecha.Year;
                row["Mes"] = tra_fecha.Month;
                row["costoProm"] = CostoPromedio;
                rs.Rows.Add(row);
            }
            else
            {
                if (Convert.ToDouble(rs.Rows[0]["costoProm"]) != CostoPromedio)
                {
                    rs.Rows[0]["costoProm"] = CostoPromedio; 
                }
            }
            da.Update(rs);
            rs.AcceptChanges();
            da.Dispose();
            rs.Dispose();
        }
        private void procesarCostosArticulosCompuestos()
        {
            SqlDatos.ejecutarComandoAdcom("ActCstComp '" + labDesde.Text + "','" + dtFechaLimiteProceso.Text + "'");
        }
        private void ActualizarValoresDocumentos()
        {
            string ssql = "InvActCstDoc '" + labDesde.Text + "','" + dtFechaLimiteProceso + "'";
            SqlDatos.ejecutarComandoAdcom(ssql);
        }
        private void GuardarError(DataRow TraRow, string errores)
        {
            SqlDataAdapter da = new SqlDataAdapter("select top 1 * from AdcTraErr", datosEmpresa.strConxAdcom);
            DataTable Dterr = new DataTable();
            da.Fill(Dterr);
            DataRow row = Dterr.NewRow();
            row["Tra_fecha"] = TraRow["Tra_fecha"];
            row["Doc_sucursal"] = TraRow["Doc_sucursal"];
            row["Doc_Bodega"] = TraRow["Doc_Bodega"];
            row["Opc_documento"] = TraRow["Opc_documento"];
            row["IdclaveDoc"] = TraRow["IdclaveDoc"];
            row["Doc_numero"] = TraRow["Doc_numero"];
            row["Tra_Codigo"] = TraRow["Tra_Codigo"];
            row["Tra_nombre"] = TraRow["Tra_nombre"];
            row["Tra_cantidad"] = TraRow["Tra_cantidad"];
            row["Tra_costuni"] = TraRow["Tra_costuni"];
            row["Errores"] = errores;
            Dterr.Rows.Add(row);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(Dterr);
            Dterr.AcceptChanges();
        }
    }
}


