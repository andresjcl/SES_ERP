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
        private int totalDocumentos = 0;
        private int documentosProcesados = 0;
        private bool procesoCancelado = false;

        public FrmRecosteo()
        {
            InitializeComponent();
            ParametrosIniciales();
            // Inicializar barra de progreso
            InicializarProgreso();
        }

        private void InicializarProgreso()
        {
            if (progressBar1 != null)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
            }
            if (lblEstado != null) lblEstado.Text = "Estado: Listo";
            if (lblProgreso != null) lblProgreso.Text = "0%";
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
            if (backgroundWorker1 != null && backgroundWorker1.IsBusy)
            {
                if (MessageBox.Show("¿Está seguro que desea salir? El proceso está en ejecución.",
                    "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    backgroundWorker1.CancelAsync();
                    Close();
                    Dispose();
                }
            }
            else
            {
                Close();
                Dispose();
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1 != null && backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Ya hay un proceso en ejecución");
                return;
            }

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
                MessageBox.Show("Existe una lista de errores de un proceso anterior anterior sin justificar \n Si desea proseguir debe justificar o eliminar los errores existentes \nUtilice la opción [Analizar errores]");
                return;
            }

            if (classMenSistem.mensajesErrorDocumento.Respuesta("Confirma procesar recosteo de artículos en documentos ? ") == false) return;

            // Deshabilitar botones durante el proceso
            btnProcesar.Enabled = false;
            btnSalir.Enabled = false;
            if (btnErrores != null) btnErrores.Enabled = false;

            // Iniciar el proceso en segundo plano
            procesoCancelado = false;
            if (backgroundWorker1 != null)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        // ============ MÉTODOS DEL BACKGROUNDWORKER ============

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool sihayerror = false;

            try
            {
                SqlDatos.ejecutarComandoAdcom("DELETE FROM AdcTraErr");

                // Obtener los documentos a procesar
                DataTable RsDoc = SqlDatos.leerTablaAdcom("InvRcstLeeTra '" + labDesde.Text + "','" + dtFechaLimiteProceso.Text + "'");

                if (RsDoc.Rows.Count < 1)
                {
                    throw new Exception("No existen documentos para procesar en el período indicado");
                }

                totalDocumentos = RsDoc.Rows.Count;
                documentosProcesados = 0;

                string ArticuloAnterior = "";
                string elerror;
                SaldoArticulo saldoArticulo = new SaldoArticulo();
                double UltimoPromedioValido = 0;
                bool CostoHistorico = false;
                sesSys.OpcDoc opc = new sesSys.OpcDoc();
                string Opcdoc = "";
                string Tra_Codigo = "";

                worker.ReportProgress(0, "Iniciando procesamiento...");

                int indice = 0;
                foreach (DataRow row in RsDoc.Rows)
                {
                    // Verificar si se canceló el proceso
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    indice++;
                    int porcentaje = Math.Min((indice * 100) / totalDocumentos, 95);
                    worker.ReportProgress(porcentaje, $"Procesando {indice} de {totalDocumentos} - Art: {row["Tra_Codigo"]}");

                    elerror = "";
                    Tra_Codigo = row["Tra_Codigo"].ToString();

                    // ✅ Cambiar de artículo, reiniciar saldo
                    if (ArticuloAnterior != Tra_Codigo)
                    {
                        saldoArticulo = ultimosValor.SaldoFecha(datosEmpresa.strConxAdcom, Tra_Codigo, dtFechaLimiteProceso.Text);
                        ArticuloAnterior = Tra_Codigo;
                        CostoHistorico = false;
                        UltimoPromedioValido = saldoArticulo.CostoPromedio;
                    }

                    // ✅ Si no hay costo promedio, buscar histórico
                    if (saldoArticulo.CostoPromedio <= 0)
                    {
                        saldoArticulo.CostoPromedio = ultimosValor.CargarPromedioHistorico(ArticuloAnterior, Convert.ToDateTime(row["tra_fecha"]));
                        CostoHistorico = true;
                    }

                    // ✅ Obtener datos del movimiento
                    double traCanti = Convert.ToDouble(row["TRA_CANTIDAD"]);
                    double multiplo = Convert.ToDouble(row["tra_multiplo"]);
                    if (multiplo == 0) multiplo = 1;
                    double traCantidad = Math.Round(traCanti * multiplo, datosEmpresa.Par_DigitosCostos);
                    int signoInventario = Convert.ToInt16(row["Tra_Inventario"]);

                    // ✅ Obtener tipo de costeo del documento
                    if (Opcdoc != row["Opc_documento"].ToString())
                    {
                        Opcdoc = row["Opc_documento"].ToString();
                        string aux = "";
                        opc.Cargar(ref Opcdoc, ref aux);
                    }

                    // ✅ CALCULAR COSTO SEGÚN TIPO DE DOCUMENTO
                    if (signoInventario == 0)
                    {
                        // ✅ Documentos sin inventario (compras/ventas)
                        row["tra_costuni"] = saldoArticulo.CostoPromedio;
                        row["Tra_CostTot"] = Math.Round(saldoArticulo.CostoPromedio * traCantidad, datosEmpresa.Par_DigitosCostos);
                    }
                    else
                    {
                        // ✅ Documentos CON inventario (ingresos y egresos)
                        if (opc.TipoCosteo == "P" || opc.TipoCosteo == "U")
                        {
                            if (traCanti == 0)
                            {
                                elerror += " Cantidad = Cero";
                            }
                            else
                            {
                                // ✅ ASIGNAR COSTO PROMEDIO AL MOVIMIENTO
                                double costoMovimiento = Math.Round(saldoArticulo.CostoPromedio * traCantidad, datosEmpresa.Par_DigitosCostos);
                                row["tra_costuni"] = Math.Round(saldoArticulo.CostoPromedio, datosEmpresa.Par_DigitosCostos);
                                row["Tra_CostTot"] = costoMovimiento;

                                // ✅ ACTUALIZAR SALDO SEGÚN TIPO DE MOVIMIENTO
                                if (signoInventario > 0) // INGRESO
                                {
                                    saldoArticulo.CantidadTotal = Math.Round(saldoArticulo.CantidadTotal + traCantidad, datosEmpresa.Par_DigitosCostos);
                                    saldoArticulo.CostoTotal = Math.Round(saldoArticulo.CostoTotal + costoMovimiento, datosEmpresa.Par_DigitosCostos);
                                }
                                else if (signoInventario < 0) // EGRESO
                                {
                                    saldoArticulo.CantidadTotal = Math.Round(saldoArticulo.CantidadTotal - traCantidad, datosEmpresa.Par_DigitosCostos);
                                    saldoArticulo.CostoTotal = Math.Round(saldoArticulo.CostoTotal - costoMovimiento, datosEmpresa.Par_DigitosCostos);
                                }

                                // ✅ RECALCULAR COSTO PROMEDIO DESPUÉS DEL MOVIMIENTO
                                if (saldoArticulo.CantidadTotal > 0)
                                {
                                    saldoArticulo.CostoPromedio = Math.Round(saldoArticulo.CostoTotal / saldoArticulo.CantidadTotal, datosEmpresa.Par_DigitosCostos);

                                    // ✅ Guardar histórico si cambió el promedio
                                    if (CostoHistorico == false && saldoArticulo.CostoPromedio != UltimoPromedioValido)
                                    {
                                        GrabarPromedioHistorico(ArticuloAnterior, Convert.ToDateTime(row["tra_fecha"]), saldoArticulo.CostoPromedio);
                                        UltimoPromedioValido = saldoArticulo.CostoPromedio;
                                    }
                                    CostoHistorico = true;
                                }
                                else if (saldoArticulo.CantidadTotal == 0)
                                {
                                    // ✅ Si el saldo es cero, mantener el último promedio válido
                                    saldoArticulo.CostoPromedio = UltimoPromedioValido;
                                }
                                else if (saldoArticulo.CantidadTotal < 0)
                                {
                                    // ✅ Si el saldo es negativo, usar el último promedio válido
                                    elerror += " Saldo Negativo ";
                                    saldoArticulo.CostoPromedio = UltimoPromedioValido;
                                }
                            }

                            if (Convert.ToDouble(row["tra_costuni"]) == 0)
                            {
                                elerror += " costo prom = Cero";
                            }
                        }
                        else if (opc.TipoCosteo == "D" && Convert.ToInt16(row["TRa_Compras"]) != 0)
                        {
                            // ✅ Costeo directo (para compras)
                            row["Tra_CostTot"] = row["Tra_prectot"];
                            row["tra_costuni"] = row["Tra_precuni"];

                            if (row["tra_quetipo"].ToString() == "") row["tra_quetipo"] = "A";

                            if (Convert.ToDouble(row["tra_costuni"]) == 0) elerror += " costo dig = Cero";
                        }
                    }

                    // ✅ Guardar errores si existen
                    if (elerror.Length > 0)
                    {
                        GuardarError(row, elerror);
                        sihayerror = true;
                    }

                    documentosProcesados++;
                }

                // Procesar costos de artículos compuestos
                worker.ReportProgress(96, "Procesando costos de artículos compuestos...");
                procesarCostosArticulosCompuestos();

                // Actualizar valores de documentos
                worker.ReportProgress(98, "Actualizando valores de documentos...");
                ActualizarValoresDocumentos();

                // SIEMPRE REPORTAR 100% AL FINALIZAR
                worker.ReportProgress(100, "Finalizando proceso...");

                // Guardar resultado
                if (sihayerror)
                {
                    e.Result = "Proceso completado con errores";
                }
                else
                {
                    SqlDatos.ejecutarComandoAdcom("update adccie set Cie_InvUltAct = '" + dtFechaLimiteProceso.Text + "' ");
                    e.Result = "Proceso completado exitosamente";
                }
            }
            catch (Exception ex)
            {
                e.Result = $"Error: {ex.Message}";
                // Reportar 100% aunque haya error
                worker.ReportProgress(100, "Proceso finalizado con error");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // El ProgressChanged ya se ejecuta en el hilo UI, pero por seguridad usamos Invoke
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateProgress(e)));
            }
            else
            {
                UpdateProgress(e);
            }
        }

        private void UpdateProgress(ProgressChangedEventArgs e)
        {
            // Actualizar la barra de progreso
            if (progressBar1 != null)
            {
                progressBar1.Value = Math.Min(e.ProgressPercentage, 100);
            }

            // Actualizar el estado
            if (lblEstado != null)
            {
                lblEstado.Text = "Estado: " + (e.UserState?.ToString() ?? "Procesando...");
            }

            // Actualizar el porcentaje
            if (lblProgreso != null)
            {
                lblProgreso.Text = Math.Min(e.ProgressPercentage, 100) + "%";
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Habilitar botones
            btnProcesar.Enabled = true;
            btnSalir.Enabled = true;
            if (btnErrores != null) btnErrores.Enabled = true;

            if (e.Cancelled)
            {
                MessageBox.Show("Proceso cancelado por el usuario");
                if (lblEstado != null) lblEstado.Text = "Estado: Cancelado";
                if (progressBar1 != null) progressBar1.Value = 0;
                if (lblProgreso != null) lblProgreso.Text = "0%";
            }
            else if (e.Error != null)
            {
                MessageBox.Show($"Error en el proceso: {e.Error.Message}");
                if (lblEstado != null) lblEstado.Text = "Estado: Error";
            }
            else
            {
                string resultado = e.Result?.ToString() ?? "Proceso completado";
                MessageBox.Show(resultado);
                if (lblEstado != null) lblEstado.Text = "Estado: " + resultado;

                if (resultado.Contains("exitosamente") && progressBar1 != null)
                {
                    progressBar1.Value = 100;
                    if (lblProgreso != null) lblProgreso.Text = "100%";
                }
            }
        }

        // ============ FIN MÉTODOS DEL BACKGROUNDWORKER ============

        private void GrabarPromedioHistorico(string ArticuloAnt, DateTime tra_fecha, double CostoPromedio)
        {
            if (string.IsNullOrEmpty(ArticuloAnt) || CostoPromedio == 0) return;

            string ssql = "SELECT * ";
            ssql += " From AdcCstProm Where tra_codigo = '" + ArticuloAnt + "' ";
            ssql += " and (año * 100 + mes ) = " + (tra_fecha.Year * 100 + tra_fecha.Month);

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataTable rs = new DataTable();
                da.Fill(rs);

                if (rs.Rows.Count < 1)
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
            }
        }

        private void procesarCostosArticulosCompuestos()
        {
            SqlDatos.ejecutarComandoAdcom("ActCstComp '" + labDesde.Text + "','" + dtFechaLimiteProceso.Text + "'");
        }

        private void ActualizarValoresDocumentos()
        {
            string ssql = "InvActCstDoc '" + labDesde.Text + "','" + dtFechaLimiteProceso.Text + "'";
            SqlDatos.ejecutarComandoAdcom(ssql);
        }

        private void GuardarError(DataRow TraRow, string errores)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select top 1 * from AdcTraErr", datosEmpresa.strConxAdcom))
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
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
                da.Update(Dterr);
                Dterr.AcceptChanges();
            }
        }

        private void FrmRecosteo_Load(object sender, EventArgs e)
        {

        }

        private void btnErrores_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si existen errores
                string ssql = "SELECT COUNT(*) FROM AdcTraErr";
                DataTable dtCount = SqlDatos.leerTablaAdcom(ssql);
                int count = dtCount.Rows.Count > 0 ? Convert.ToInt32(dtCount.Rows[0][0]) : 0;

                if (count == 0)
                {
                    MessageBox.Show("No existen errores registrados.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Abrir el formulario de errores
                ArtInvent.FrmErrores frmErrores = new ArtInvent.FrmErrores();
                frmErrores.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los errores: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}