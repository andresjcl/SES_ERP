using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DattCom;
using ClassDoc;
using classMenSistem;
using DctosEmi;

namespace IvaRett
{
    public partial class MantRetencion : Form
    {
        public static string CodigoRetencionForzadoGlobal = "";

        public string CodigoRetencionForzado { get; set; } = "";
        public bool CerrarDespuesDeGrabar { get; set; } = false;

        private bool _vieneDeFactura = false;

        Boolean esSoloConsulta = false;
        int tipoTransaccion = 0; // 1 compras 2 ventas
        internal ClassDoc.AdcDoc DatosDocumento;
        internal idDocumento idDocumentoActual;
        internal DataTable dtDetalleDocumento;
        internal sesSys.OpcDoc propiedadesDoc;
        int operacionEnCurso = 0;
        directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
        internal string codCliente = "";
        string TipoDocumentoSoporte;
        daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();
        string UltTipoRetencion = "";
        Boolean esDeLiquidacion = false;
        daxContaDoc.AsientosContables mallaContable = new daxContaDoc.AsientosContables();
        string claseDocDefault = "RTP";
        string tipoDocDefault = "RTP";

        public MantRetencion(string clasdef, string tipdef, int tipoTra, ClassDoc.idDocumento idDocumento, bool esConsulta = false)
        {
            InitializeComponent();

            // ========================================================
            // INICIALIZAR VALORES POR DEFECTO
            // ========================================================
            _vieneDeFactura = false;
            CerrarDespuesDeGrabar = false;
            CodigoRetencionForzado = "";

            // ========================================================
            // 1. APLICAR CÓDIGO FORZADO PRIMERO (MÁXIMA PRIORIDAD)
            // ========================================================
            bool vieneConCodigoForzado = false;
            if (!string.IsNullOrEmpty(CodigoRetencionForzadoGlobal))
            {
                CodigoRetencionForzado = CodigoRetencionForzadoGlobal;
                CodigoRetencionForzadoGlobal = "";
                vieneConCodigoForzado = true;
                _vieneDeFactura = true;
                CerrarDespuesDeGrabar = true;
            }

            // ========================================================
            // 2. CONFIGURAR TIPO DE TRANSACCIÓN
            // ========================================================
            if (tipoTra == 1)
            {
                tipoTransaccion = tipoTra;
                esSoloConsulta = esConsulta;
                if (clasdef.Length > 0) claseDocDefault = clasdef;
                if (tipdef.Length > 0) tipoDocDefault = tipdef;
                groupBox1.Text = "DATOS PROVEEDOR";
            }
            else
            {
                groupBox1.Text = "DATOS CLIENTE";
            }

            // ========================================================
            // 3. INICIALIZAR CONTROLES
            // ========================================================
            txtfecha.Value = DateTime.Now.Date;
            llenarCombos();
            CargarValoresIniciales();

            // ========================================================
            // 4. PROCESAR DOCUMENTO
            // ========================================================
            if (idDocumento != null && idDocumento.idClave > 0)
            {
                // Obtener el tipo del documento desde ADCOPC
                string ssqlOpc = "SELECT Opc_tipo FROM ADCOPC WHERE Opc_documento = '" + idDocumento.Tipo + "'";
                DataTable dtOpc = SqlDatos.leerTablaAdcom(ssqlOpc);
                string opcTipo = "";
                if (dtOpc != null && dtOpc.Rows.Count > 0)
                {
                    opcTipo = dtOpc.Rows[0]["Opc_tipo"]?.ToString() ?? "";
                }

                // Obtener Doc_TipoDoc desde ADCDOC
                string ssqlVerificar = "SELECT Doc_TipoDoc FROM ADCDOC " +
                                       "WHERE Doc_sucursal = '" + idDocumento.Sucursal + "' " +
                                       "AND Opc_documento = '" + idDocumento.Tipo + "' " +
                                       "AND Doc_numero = " + idDocumento.numero.ToString() + " " +
                                       "AND IdClaveDoc = " + idDocumento.idClave.ToString();

                DataTable dtVerificar = SqlDatos.leerTablaAdcom(ssqlVerificar);
                string docTipoDoc = "";
                if (dtVerificar != null && dtVerificar.Rows.Count > 0)
                {
                    docTipoDoc = dtVerificar.Rows[0]["Doc_TipoDoc"]?.ToString() ?? "";
                }

                string tipoDocumento = docTipoDoc;
                if (string.IsNullOrEmpty(tipoDocumento))
                {
                    tipoDocumento = opcTipo;
                }

                // ========================================================
                // 4a. CASO 1: RETENCIÓN EXISTENTE
                // ========================================================
                if (tipoDocumento == "RTP")
                {
                    _vieneDeFactura = false;

                    // ✅ SI VIENE CON CÓDIGO FORZADO, MANTENER CERRAR DESPUÉS DE GRABAR
                    if (!vieneConCodigoForzado)
                    {
                        CerrarDespuesDeGrabar = false;
                    }
                    // Si viene con código forzado, CerrarDespuesDeGrabar ya es true

                    CargarDatosRetencion(idDocumento);
                    this.Text = "MANTENIMIENTO DE RETENCIONES - RETENCIÓN EXISTENTE (" + idDocumento.Tipo + " - " + idDocumento.numero.ToString() + ")";
                    return;
                }

                // ========================================================
                // 4b. CASO 2: FACTURA
                // ========================================================
                if (tipoDocumento == "FAP")
                {
                    _vieneDeFactura = true;
                    CerrarDespuesDeGrabar = true;
                }

                // ========================================================
                // 4c. BUSCAR RETENCIÓN EN ADCAPL
                // ========================================================
                if (_vieneDeFactura)
                {
                    string ssqlApl = "SELECT Doc_sucursal, Opc_documento, Doc_numero, IdClaveDoc " +
                                     "FROM ADCAPL " +
                                     "WHERE Doc_sucursal = '" + idDocumento.Sucursal + "' " +
                                     "AND Apl_sucapli = '" + idDocumento.Sucursal + "' " +
                                     "AND Apl_docapli = '" + idDocumento.Tipo + "' " +
                                     "AND Apl_numapli = " + idDocumento.numero.ToString() + " " +
                                     "AND IdClaveDocApl = " + idDocumento.idClave.ToString();

                    DataTable dtApl = SqlDatos.leerTablaAdcom(ssqlApl);

                    if (dtApl != null && dtApl.Rows.Count > 0)
                    {
                        DataRow row = dtApl.Rows[0];
                        string sucRetencion = row["Doc_sucursal"].ToString();
                        string tipRetencion = row["Opc_documento"].ToString();
                        double numRetencion = Convert.ToDouble(row["Doc_numero"]);
                        double idClaveRetencion = Convert.ToDouble(row["IdClaveDoc"]);

                        string ssqlRet = "SELECT Doc_fecha, Doc_NroIdDoc FROM ADCDOC " +
                                         "WHERE Doc_sucursal = '" + sucRetencion + "' " +
                                         "AND Opc_documento = '" + tipRetencion + "' " +
                                         "AND Doc_numero = " + numRetencion.ToString() + " " +
                                         "AND IdClaveDoc = " + idClaveRetencion.ToString();
                        DataTable dtRet = SqlDatos.leerTablaAdcom(ssqlRet);
                        DateTime fechaRetencion = DateTime.Now;
                        string serieRetencion = "";
                        if (dtRet != null && dtRet.Rows.Count > 0)
                        {
                            fechaRetencion = Convert.ToDateTime(dtRet.Rows[0]["Doc_fecha"]);
                            serieRetencion = dtRet.Rows[0]["Doc_NroIdDoc"]?.ToString() ?? "";
                        }

                        ClassDoc.idDocumento idDocRetencion = new ClassDoc.idDocumento();
                        idDocRetencion.idClave = idClaveRetencion;
                        idDocRetencion.numero = numRetencion;
                        idDocRetencion.Sucursal = sucRetencion;
                        idDocRetencion.Tipo = tipRetencion;
                        idDocRetencion.familia = tipRetencion;
                        idDocRetencion.fecha = fechaRetencion;
                        idDocRetencion.Serie = serieRetencion;

                        CargarDatosRetencion(idDocRetencion);
                        this.Text = "MANTENIMIENTO DE RETENCIONES - RETENCIÓN EXISTENTE (" + tipRetencion + " - " + numRetencion.ToString() + ")";
                        return;
                    }

                    // ========================================================
                    // 4d. NO EXISTE RETENCIÓN: CREAR NUEVA DESDE FACTURA
                    // ========================================================
                    CargarDatosDesdeDocumento(idDocumento);
                    this.Text = "MANTENIMIENTO DE RETENCIONES - NUEVA RETENCIÓN";
                }
            }
        }

        private void CargarDatosDesdeDocumento(idDocumento id)
        {
            if (id != null && id.idClave > 0)
            {
                string ssql = "Doc_sucursal = '" + id.Sucursal + "' " +
                              "AND Opc_documento = '" + id.Tipo + "' " +
                              "AND Doc_numero = " + id.numero.ToString() + " " +
                              "AND IdClaveDoc = " + id.idClave.ToString();

                DatosDocumento = new AdcDoc(datosEmpresa.strConxAdcom);
                DatosDocumento = AdcDoc.Buscar(ssql);

                if (DatosDocumento != null)
                {
                    string codigoCliente = DatosDocumento.Doc_codper;
                    if (!string.IsNullOrEmpty(codigoCliente))
                    {
                        CargarClienteDirecto(codigoCliente);
                    }

                    // ========================================================
                    // VERIFICAR SI EL DOCUMENTO ES UNA RETENCIÓN EXISTENTE
                    // ========================================================
                    if (DatosDocumento.Doc_TipoDoc == "RTP")
                    {
                        idDocumentoActual = id;

                        txtnumero.Text = DatosDocumento.Doc_numero.ToString();
                        txtfecha.Value = DatosDocumento.Doc_fecha;
                        txtNroAutorizacion.Text = DatosDocumento.NroAutorizacionSri;
                        txtNroID.Text = DatosDocumento.Doc_NroIdDoc;

                        CargarDetalleRetencion(id);

                        operacionEnCurso = 2;
                        prepararBotones();
                        return;
                    }

                    // ========================================================
                    // ES UNA FACTURA - CREAR NUEVA RETENCIÓN
                    // ========================================================
                    InicializarMalla(false);

                    txtnumero.Text = "";
                    txtfecha.Value = DateTime.Now;
                    txtNroAutorizacion.Text = "";

                    idDocumentoActual = new idDocumento();
                    idDocumentoActual.idClave = 0;
                    idDocumentoActual.numero = 0;
                    idDocumentoActual.Sucursal = datosEmpresa.suc;
                    idDocumentoActual.Tipo = claseDocDefault;
                    idDocumentoActual.fecha = DateTime.Now.Date;

                    valoresPredefinidosSucursal.cargarValores();
                    idDocumentoActual.Serie = valoresPredefinidosSucursal.idtributario;

                    ClassDoc.controlNumeracion cnum = new controlNumeracion();
                    txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString("F0");

                    // ✅ GENERAR LÍNEAS DE RETENCIÓN (AQUÍ SE USA EL CÓDIGO FORZADO)
                    GenerarLineasRetencionDesdeDocumento(id);

                    malla.Refresh();
                    malla.Update();

                    operacionEnCurso = 2;
                    prepararBotones();
                }
                else
                {
                    MessageBox.Show("No se encontró el documento: " + id.Sucursal + "/" + id.Tipo + "/" + id.numero.ToString());
                }
            }
        }

        private void CargarDetalleRetencion(idDocumento id)
        {
            // ========================================================
            // LEER DE AdcSri9
            // ========================================================
            string ssql = "SELECT * FROM AdcSri9 WHERE SRI_SUCURSAL = '" + id.Sucursal +
                          "' AND SRI_DOCUMENTO = '" + id.Tipo +
                          "' AND IdClaveDoc = " + id.idClave.ToString();

            DataTable dtSri9 = SqlDatos.leerTablaAdcom(ssql);
            // ========================================================

            // ========================================================
            // CREAR DataTable PARA LA MALLA
            // ========================================================
            dtDetalleDocumento = EstructuraMallaRetencion.CrearDataTable();
            // ========================================================

            int linea = 0;

            if (dtSri9 != null && dtSri9.Rows.Count > 0)
            {
                DataRow rowSri = dtSri9.Rows[0];

                // 1. RETENCIÓN FUENTE (PRIMER CONCEPTO)
                decimal baseRetFuente = Convert.ToDecimal(rowSri["BaseRetFuente"]);
                decimal porRetFuente = Convert.ToDecimal(rowSri["PorRetFuente"]);
                decimal valorRetFuente = Convert.ToDecimal(rowSri["ValorRetFuente"]);
                string codRetFuente = rowSri["CodigoRetFuente"]?.ToString() ?? "";

                if (baseRetFuente > 0 || porRetFuente > 0)
                {
                    linea++;
                    DataRow rowRF = dtDetalleDocumento.NewRow();

                    rowRF["SRI_Sucursal"] = rowSri["SRI_SUCURSAL"].ToString();
                    rowRF["SRI_Documento"] = rowSri["SRI_DOCUMENTO"].ToString();
                    rowRF["SRI_IdClaveDoc"] = Convert.ToDecimal(rowSri["IdClaveDoc"]);
                    rowRF["SRI_NumeroRetencion"] = Convert.ToDecimal(rowSri["SRI_NUMERORET"]);

                    rowRF["Doc_Sucursal"] = DatosDocumento.Doc_sucursal;
                    rowRF["Doc_OpcDocumento"] = DatosDocumento.Opc_documento;
                    rowRF["Doc_Numero"] = DatosDocumento.Doc_numero.ToString("F0");
                    rowRF["Doc_IdClave"] = DatosDocumento.IdClaveDoc;
                    rowRF["Doc_Linea"] = linea;
                    rowRF["Doc_CodSri"] = DBNull.Value;
                    rowRF["TipoRetencion"] = "RetFuente";
                    rowRF["CodigoRetencion"] = codRetFuente;
                    rowRF["BaseRetencion"] = baseRetFuente;
                    rowRF["PorcRetencion"] = porRetFuente;
                    rowRF["ValorRetencion"] = valorRetFuente;
                    rowRF["BaseConIva"] = Convert.ToDecimal(rowSri["BasIvaCon"]);
                    rowRF["BaseExcentaIva"] = Convert.ToDecimal(rowSri["BasIvaCer"]);
                    rowRF["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowRF);
                }

                // 2. RETENCIÓN FUENTE (SEGUNDO CONCEPTO)
                decimal baseRetFuente1 = Convert.ToDecimal(rowSri["BaseRetFuente1"]);
                decimal porRetFuente1 = Convert.ToDecimal(rowSri["PorRetFuente1"]);
                decimal valorRetFuente1 = Convert.ToDecimal(rowSri["ValorRetFuente1"]);
                string codRetFuente1 = rowSri["CodigoRetFuente1"]?.ToString() ?? "";

                if (baseRetFuente1 > 0 || porRetFuente1 > 0)
                {
                    linea++;
                    DataRow rowRF1 = dtDetalleDocumento.NewRow();
                    // ... similar a la fila anterior usando los campos ...1
                }

                // 3. IVA BIENES
                decimal baseIvaBienes = Convert.ToDecimal(rowSri["BaseIvaBienes"]);
                decimal porRetIvaBienes = Convert.ToDecimal(rowSri["PorRetIvaBienes"]);
                decimal valorRetIvaBienes = Convert.ToDecimal(rowSri["ValorRetIvaBienes"]);
                string codRetIvaBienes = rowSri["CodigoRetIvaBienes"]?.ToString() ?? "";

                if (baseIvaBienes > 0 || porRetIvaBienes > 0)
                {
                    linea++;
                    DataRow rowIB = dtDetalleDocumento.NewRow();
                    // ... llenar datos de IVA BIENES
                }

                // 4. IVA SERVICIOS
                decimal baseIvaServicios = Convert.ToDecimal(rowSri["BaseIvaServicios"]);
                decimal porRetIvaServicios = Convert.ToDecimal(rowSri["PorRetIvaServicios"]);
                decimal valorRetIvaServicios = Convert.ToDecimal(rowSri["ValorRetIvaServicios"]);
                string codRetIvaServicios = rowSri["CodigoRetIvaServicios"]?.ToString() ?? "";

                if (baseIvaServicios > 0 || porRetIvaServicios > 0)
                {
                    linea++;
                    DataRow rowIS = dtDetalleDocumento.NewRow();

                    rowIS["SRI_Sucursal"] = rowSri["SRI_SUCURSAL"].ToString();
                    rowIS["SRI_Documento"] = rowSri["SRI_DOCUMENTO"].ToString();
                    rowIS["SRI_IdClaveDoc"] = Convert.ToDecimal(rowSri["IdClaveDoc"]);
                    rowIS["SRI_NumeroRetencion"] = Convert.ToDecimal(rowSri["SRI_NUMERORET"]);

                    rowIS["Doc_Sucursal"] = DatosDocumento.Doc_sucursal;
                    rowIS["Doc_OpcDocumento"] = DatosDocumento.Opc_documento;
                    rowIS["Doc_Numero"] = DatosDocumento.Doc_numero.ToString("F0");
                    rowIS["Doc_IdClave"] = DatosDocumento.IdClaveDoc;
                    rowIS["Doc_Linea"] = linea;
                    rowIS["Doc_CodSri"] = DBNull.Value;
                    rowIS["TipoRetencion"] = "IvaServicios";
                    rowIS["CodigoRetencion"] = codRetIvaServicios;
                    rowIS["BaseRetencion"] = baseIvaServicios;
                    rowIS["PorcRetencion"] = porRetIvaServicios;
                    rowIS["ValorRetencion"] = valorRetIvaServicios;
                    rowIS["BaseConIva"] = 0;
                    rowIS["BaseExcentaIva"] = 0;
                    rowIS["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowIS);
                }
            }

            malla.DataSource = null;
            malla.DataSource = dtDetalleDocumento;
            EstructuraMallaRetencion.DiseñarMalla(malla);
            totalizar();
        }

        private void GenerarLineasRetencionDesdeDocumento(idDocumento id)
        {
            try
            {
                decimal BaseConIva = 0;
                decimal BaseSinIva = 0;
                decimal ValorIva = 0;
                string sucursalSoporte = "";
                string tipoSoporte = "";
                double numeroSoporte = 0;
                double idClaveSoporte = 0;

                // ✅ OBTENER DATOS DE LA FACTURA SOPORTE
                string queryFactura = @"
            SELECT 
                Doc_sucursal,
                Opc_documento,
                Doc_numero,
                IdClaveDoc,
                ISNULL(BaseImp1, 0) AS BaseConIva,
                ISNULL(Doc_totsiva, 0) AS BaseSinIva,
                ISNULL(Doc_valoriva, 0) AS ValorIva
            FROM ADCDOC
            WHERE Doc_sucursal = @SUC 
                AND Opc_documento = @OPC 
                AND Doc_numero = @NUMERO
                AND IdClaveDoc = @IDCLAVEDOC";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                using (SqlCommand comm = new SqlCommand(queryFactura, conn))
                {
                    comm.Parameters.AddWithValue("@SUC", id.Sucursal);
                    comm.Parameters.AddWithValue("@OPC", id.Tipo);
                    comm.Parameters.AddWithValue("@NUMERO", id.numero);
                    comm.Parameters.AddWithValue("@IDCLAVEDOC", id.idClave);

                    conn.Open();
                    using (SqlDataReader rs = comm.ExecuteReader())
                    {
                        if (rs.Read())
                        {
                            // ✅ DATOS DE LA FACTURA SOPORTE
                            sucursalSoporte = rs["Doc_sucursal"].ToString();
                            tipoSoporte = rs["Opc_documento"].ToString();
                            numeroSoporte = Convert.ToDouble(rs["Doc_numero"]);
                            idClaveSoporte = Convert.ToDouble(rs["IdClaveDoc"]);
                            BaseConIva = Convert.ToDecimal(rs["BaseConIva"]);
                            BaseSinIva = Convert.ToDecimal(rs["BaseSinIva"]);
                            ValorIva = Convert.ToDecimal(rs["ValorIva"]);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para el documento especificado.");
                            return;
                        }
                    }
                }

                // Crear DataTable con la estructura correcta
                dtDetalleDocumento = EstructuraMallaRetencion.CrearDataTable();

                // Obtener el número de retención (DE LA RETENCIÓN NUEVA)
                decimal numeroRetencion = 0;
                if (!string.IsNullOrEmpty(txtnumero.Text))
                {
                    decimal.TryParse(txtnumero.Text, out numeroRetencion);
                }

                int linea = 0;

                // ============================================================
                // 1. RETENCIÓN FUENTE
                // ============================================================
                if (BaseConIva > 0 || BaseSinIva > 0)
                {
                    linea++;
                    DataRow rowRF = dtDetalleDocumento.NewRow();

                    // ✅ CAMPOS SRI: DATOS DE LA RETENCIÓN (NUEVO DOCUMENTO RTP)
                    rowRF["SRI_Sucursal"] = datosEmpresa.suc;                    // Sucursal de la retención
                    rowRF["SRI_Documento"] = "RTP";                              // Tipo de la retención
                    rowRF["SRI_IdClaveDoc"] = 0;                                 // 0 (nueva retención)
                    rowRF["SRI_NumeroRetencion"] = numeroRetencion;              // Número de la retención

                    // ✅ CAMPOS DOC: DATOS DE LA FACTURA SOPORTE (FAP #6909)
                    rowRF["Doc_Sucursal"] = sucursalSoporte;                     // AV6 (de la factura)
                    rowRF["Doc_OpcDocumento"] = tipoSoporte;                     // FAP (de la factura)
                    rowRF["Doc_Numero"] = numeroSoporte.ToString("F0");          // 6909 (de la factura)
                    rowRF["Doc_IdClave"] = Convert.ToDecimal(idClaveSoporte);    // 2 (de la factura)

                    rowRF["Doc_Linea"] = linea;
                    rowRF["Doc_CodSri"] = DBNull.Value;
                    rowRF["TipoRetencion"] = "RetFuente";
                    rowRF["BaseRetencion"] = BaseConIva + BaseSinIva;
                    rowRF["PorcRetencion"] = 0;
                    rowRF["ValorRetencion"] = 0;
                    rowRF["BaseConIva"] = BaseConIva;
                    rowRF["BaseExcentaIva"] = BaseSinIva;
                    rowRF["BaseIvaCero"] = 0;

                    // ========================================================
                    // ✅ ASIGNAR CÓDIGO FORZADO (332)
                    // ========================================================
                    if (!string.IsNullOrEmpty(CodigoRetencionForzado))
                    {
                        rowRF["CodigoRetencion"] = CodigoRetencionForzado;

                        if (CodigoRetencionForzado == "332")
                        {
                            rowRF["PorcRetencion"] = 0.00m;
                        }
                        else
                        {
                            decimal porcentaje = BuscarPorcentajeRetencion(CodigoRetencionForzado);
                            rowRF["PorcRetencion"] = porcentaje;
                        }

                        decimal baseRet = Convert.ToDecimal(rowRF["BaseRetencion"]);
                        decimal porcRet = Convert.ToDecimal(rowRF["PorcRetencion"]);
                        rowRF["ValorRetencion"] = Math.Round(baseRet * porcRet / 100, 2);
                    }
                    else
                    {
                        rowRF["CodigoRetencion"] = "";
                    }

                    dtDetalleDocumento.Rows.Add(rowRF);
                }

                // ============================================================
                // 2. IVA SERVICIOS (si hay IVA)
                // ============================================================
                if (ValorIva > 0)
                {
                    linea++;
                    DataRow rowIS = dtDetalleDocumento.NewRow();

                    // ✅ CAMPOS SRI: DATOS DE LA RETENCIÓN
                    rowIS["SRI_Sucursal"] = datosEmpresa.suc;
                    rowIS["SRI_Documento"] = "RTP";
                    rowIS["SRI_IdClaveDoc"] = 0;
                    rowIS["SRI_NumeroRetencion"] = numeroRetencion;

                    // ✅ CAMPOS DOC: DATOS DE LA FACTURA SOPORTE
                    rowIS["Doc_Sucursal"] = sucursalSoporte;
                    rowIS["Doc_OpcDocumento"] = tipoSoporte;
                    rowIS["Doc_Numero"] = numeroSoporte.ToString("F0");
                    rowIS["Doc_IdClave"] = Convert.ToDecimal(idClaveSoporte);

                    rowIS["Doc_Linea"] = linea;
                    rowIS["Doc_CodSri"] = DBNull.Value;
                    rowIS["TipoRetencion"] = "IvaServicios";
                    rowIS["CodigoRetencion"] = "";
                    rowIS["BaseRetencion"] = ValorIva;
                    rowIS["PorcRetencion"] = 0;
                    rowIS["ValorRetencion"] = 0;
                    rowIS["BaseConIva"] = ValorIva;
                    rowIS["BaseExcentaIva"] = 0;
                    rowIS["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowIS);
                }

                // Si no se generó ninguna línea, agregar una fila vacía
                if (dtDetalleDocumento.Rows.Count == 0)
                {
                    DataRow emptyRow = dtDetalleDocumento.NewRow();
                    dtDetalleDocumento.Rows.Add(emptyRow);
                }

                // Asignar el DataTable al DataGridView
                malla.DataSource = null;
                malla.DataSource = dtDetalleDocumento;
                EstructuraMallaRetencion.DiseñarMalla(malla);

                totalizar();

                malla.Refresh();
                malla.Update();

                operacionEnCurso = 1;
                prepararBotones();

                if (!string.IsNullOrEmpty(CodigoRetencionForzado))
                {
                    MessageBox.Show("Se ha asignado automáticamente el código de retención: " + CodigoRetencionForzado +
                                    "\nPorcentaje: " + (CodigoRetencionForzado == "332" ? "0%" : "Buscado en tabla"),
                        "Código asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar líneas de retención: " + ex.Message + "\n" + ex.StackTrace);
                InicializarMalla();
            }
        }

        private decimal BuscarPorcentajeRetencion(string codigoRetencion)
        {
            try
            {
                string ssql = "SELECT Porcentaje FROM ConceptosRetencion WHERE Código = '" + codigoRetencion + "'";
                DataTable dt = SqlDatos.leerTablaIvaret(ssql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["Porcentaje"]);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void CargarClienteDirecto(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return;

            try
            {
                codCliente = "";
                txtcedula.Text = "";
                txtnombrecliente.Text = "";
                txtdireccion.Text = "";
                txtCorreElectronico.Text = "";
                txttelefono.Text = "";

                directMnt.DirectorioAlex nuevoCliente = new directMnt.DirectorioAlex();
                string codigoTemp = codigo;
                string solocodigo = "";
                bool x = false;

                nuevoCliente.CargarAlex(ref codigoTemp, ref x, ref solocodigo);

                if (nuevoCliente.codigo != null && nuevoCliente.codigo.Length > 0)
                {
                    codCliente = nuevoCliente.codigo;
                    txtcedula.Text = nuevoCliente.CiRuc ?? "";
                    txtnombrecliente.Text = nuevoCliente.NombreImpresion ?? "";
                    txtdireccion.Text = nuevoCliente.direccion ?? "";
                    txtCorreElectronico.Text = nuevoCliente.correoElectronico ?? "";
                    txttelefono.Text = nuevoCliente.telefono1 ?? "";

                    opalex = nuevoCliente;
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente con código: " + codigo, "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el cliente: " + ex.Message);
            }
        }

        private void CargarValoresIniciales()
        {
            txtfecha.Value = DateTime.Now.Date;
            propiedadesDoc = new sesSys.OpcDoc();
            idDocumentoActual = new idDocumento();
            idDocumentoActual.Tipo = cmbDocumento.SelectedValue.ToString();
            idDocumentoActual.Sucursal = datosEmpresa.suc;
            propiedadesDoc.Cargar(ref idDocumentoActual.Tipo, ref idDocumentoActual.Sucursal);
            idDocumentoActual.familia = propiedadesDoc.TipoDoc;

            valoresPredefinidosSucursal.cargarValores();

            txtNroID.Text = valoresPredefinidosSucursal.idtributario;
            esDeLiquidacion = Convert.ToBoolean(propiedadesDoc.SNLiquidacionGas);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            iniciarNuevoDocumento();
        }

        private void iniciarNuevoDocumento()
        {
            InicializarMalla(true);
            idDocumentoActual = new idDocumento()
            {
                familia = propiedadesDoc.TipoDoc,
                fecha = txtfecha.Value,
                numero = Convert.ToDouble("0" + txtnumero.Text),
                Serie = txtNroID.Text,
                Sucursal = datosEmpresa.suc,
                Tipo = cmbDocumento.SelectedValue.ToString()
            };
            DatosDocumento = new AdcDoc(datosEmpresa.strConxAdcom);
            ClassDoc.controlNumeracion cnum = new controlNumeracion();
            txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
            operacionEnCurso = 1;
            prepararBotones();

            if (!CerrarDespuesDeGrabar)
            {
                txtcedula.Enabled = true;
                cmbDocumento.Enabled = true;
                malla.Enabled = true;
                panel1.Enabled = true;
            }
        }

        private void InicializarMalla(bool agregarFilaVacia = false)
        {
            dtDetalleDocumento = EstructuraMallaRetencion.CrearDataTable();

            if (agregarFilaVacia)
            {
                DataRow newRow = dtDetalleDocumento.NewRow();
                dtDetalleDocumento.Rows.Add(newRow);
            }

            malla.DataSource = dtDetalleDocumento;
            EstructuraMallaRetencion.DiseñarMalla(malla);
            UltTipoRetencion = "";
        }

        private void CrearEstructuraManual()
        {
            dtDetalleDocumento = new DataTable();

            dtDetalleDocumento.Columns.Add("SRI_Sucursal", typeof(string));
            dtDetalleDocumento.Columns.Add("SRI_Documento", typeof(string));
            dtDetalleDocumento.Columns.Add("SRI_IdClaveDoc", typeof(decimal));
            dtDetalleDocumento.Columns.Add("SRI_NumeroRetencion", typeof(decimal));
            dtDetalleDocumento.Columns.Add("Doc_Sucursal", typeof(string));
            dtDetalleDocumento.Columns.Add("Doc_OpcDocumento", typeof(string));
            dtDetalleDocumento.Columns.Add("Doc_Numero", typeof(string));
            dtDetalleDocumento.Columns.Add("Doc_IdClave", typeof(decimal));
            dtDetalleDocumento.Columns.Add("Doc_Linea", typeof(int));
            dtDetalleDocumento.Columns.Add("Doc_CodSri", typeof(string));
            dtDetalleDocumento.Columns.Add("TipoRetencion", typeof(string));
            dtDetalleDocumento.Columns.Add("CodigoRetencion", typeof(string));
            dtDetalleDocumento.Columns.Add("BaseRetencion", typeof(decimal));
            dtDetalleDocumento.Columns.Add("PorcRetencion", typeof(decimal));
            dtDetalleDocumento.Columns.Add("ValorRetencion", typeof(decimal));
            dtDetalleDocumento.Columns.Add("BaseConIva", typeof(decimal));
            dtDetalleDocumento.Columns.Add("BaseExcentaIva", typeof(decimal));
            dtDetalleDocumento.Columns.Add("BaseIvaCero", typeof(decimal));
        }

        private void limpiarDatos()
        {
            codCliente = "";
            txtnumero.Enabled = true;
            txtcedula.Text = "";
            txtCorreElectronico.Text = "";
            txtDetalle.Text = "";
            txtdireccion.Text = "";
            txtnombrecliente.Text = "";
            txtnumero.Text = "";
            txttelefono.Text = "";
            mensajesDocumento.Text = "";
            idDocumentoActual = new idDocumento();
            ActualizarIdDocumento();
            dtDetalleDocumento = new DataTable();
            malla.DataSource = null;
            edTotal.Text = "0.00";
            operacionEnCurso = 0;
            prepararBotones();

            // ✅ GENERAR NUEVO NÚMERO PARA RETENCIÓN MANUAL
            if (!CerrarDespuesDeGrabar)
            {
                ClassDoc.controlNumeracion cnum = new controlNumeracion();
                idDocumentoActual.Sucursal = datosEmpresa.suc;
                idDocumentoActual.Tipo = claseDocDefault;
                idDocumentoActual.Serie = txtNroID.Text;
                txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
                operacionEnCurso = 1;
                prepararBotones();
            }
        }

        private void ActualizarIdDocumento()
        {
            try
            {
                if (idDocumentoActual == null) idDocumentoActual = new idDocumento();
                idDocumentoActual.fecha = txtfecha.Value;
                idDocumentoActual.Sucursal = datosEmpresa.suc;
                idDocumentoActual.Tipo = claseDocDefault;
                idDocumentoActual.Serie = txtNroID.Text;
                idDocumentoActual.familia = tipoDocDefault;
            }
            catch { }
        }

        private void prepararBotones()
        {
            Boolean inicio = (operacionEnCurso == 0);
            Boolean nuevo = (operacionEnCurso == 1);
            Boolean modificando = (operacionEnCurso == 2);
            Boolean docAnulado = false;

            try
            {
                docAnulado = (DatosDocumento.Doc_Estado == 0 && modificando);
            }
            catch { }

            btnAbre.Enabled = inicio;
            btnNuevo.Enabled = inicio;

            btnAnula.Enabled = (modificando && !docAnulado);
            btnElimina.Enabled = modificando;
            btnEnviar.Enabled = modificando;
            btnGraba.Enabled = (!inicio && !docAnulado);
            btnRegistra.Enabled = btnGraba.Enabled;
            btnEnviar.Enabled = (modificando && !docAnulado);
            btnCierra.Enabled = !inicio;
            btnContabiliza.Enabled = btnGraba.Enabled;
            panel1.Enabled = (!inicio);
            malla.Enabled = (!inicio);

            cmbDocumento.Enabled = (inicio);
            txtcedula.Enabled = (!docAnulado);

            if (DatosUsuario.Identifica.ToUpper() == "ADMINISTRADOR") return;
            if (accesosLocalizados.sinRegistro == false)
            {
                if (nuevo)
                {
                    btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Crear));
                    btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Imprimir));
                }
                else if (modificando)
                {
                    btnGraba.Enabled = (btnGraba.Enabled && (accesosLocalizados.Modificar));
                    btnRegistra.Enabled = (btnRegistra.Enabled && (btnGraba.Enabled && accesosLocalizados.Modificar && accesosLocalizados.Imprimir));
                }
                btnAbre.Enabled = (btnAbre.Enabled && (accesosLocalizados.Modificar || accesosLocalizados.Consultar));
                btnEnviar.Enabled = (btnEnviar.Enabled && accesosLocalizados.Imprimir);
                btnNuevo.Enabled = (accesosLocalizados.Crear && btnNuevo.Enabled);
                btnElimina.Enabled = (accesosLocalizados.Eliminar && btnElimina.Enabled);
                btnAnula.Enabled = (accesosLocalizados.Anular && btnAnula.Enabled);
            }
            registrarAccesosLocalizadosDocumento();

            if (esSoloConsulta == true || docAnulado)
            {
                btnGraba.Enabled = false;
                btnRegistra.Enabled = false;
                btnElimina.Enabled = false;
                btnAnula.Enabled = false;
                if (DatosDocumento.Doc_Estado == 1) btnElimina.Enabled = (DatosUsuario.Identifica.ToUpper() == "ADMINISTRADOR");
            }

            if (CerrarDespuesDeGrabar)
            {
                cmbDocumento.Enabled = false;
                txtnumero.Enabled = false;
                txtNroID.Enabled = false;
            }
            else
            {
                cmbDocumento.Enabled = true;
                txtnumero.Enabled = true;
                txtNroID.Enabled = true;
            }
        }

        private void registrarAccesosLocalizadosDocumento()
        {
            if (accesosLocalizados.sinRegistro) return;

            txtnumero.Enabled = accesosLocalizados.NúmeroDocumento;
            txtNroID.Enabled = txtnumero.Enabled;
            txtfecha.Enabled = accesosLocalizados.FechaDocumento;
        }

        private void llenarCombos()
        {
            string tipoRetencion = "RTP";
            TipoDocumentoSoporte = "FAPNCPNDP";
            if (tipoTransaccion == 2) { tipoRetencion = "RTC"; TipoDocumentoSoporte = "FACNCCNDC"; }
            DaxCombobx.CargCmbBox dcombo = new DaxCombobx.CargCmbBox();
            dcombo.DaxCombosDoc(tipoRetencion, "", false, datosEmpresa.strConxAdcom, ref cmbDocumento);
            cmbDocumento.SelectedIndex = 0;
        }

        private void btnBuscaCliente_Click(object sender, EventArgs e)
        {
            BuscaCliente(txtnombrecliente.Text);
        }

        private void BuscaCliente(string buscador)
        {
            directMnt.BusDirectorio directorio = new directMnt.BusDirectorio();
            string cliente = "C";
            if (tipoTransaccion == 1) cliente = "P";
            string nombre = "";
            string codigo = directorio.BusDirect("", "", ref nombre, "", cliente);
            if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
        }

        private void cargarDatosCliente(string codigo = "")
        {
            if (codigo != "")
            {
                string solocodigo = "";
                Boolean x = false;
                opalex = new directMnt.DirectorioAlex();
                opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
                if (opalex.codigo == null) codigo = ""; else codigo = opalex.codigo;
                if (codigo.Length > 0)
                {
                    codCliente = opalex.codigo;
                    txtcedula.Text = opalex.CiRuc;
                    txtnombrecliente.Text = opalex.NombreImpresion;
                    txtdireccion.Text = opalex.direccion;
                    txtCorreElectronico.Text = opalex.correoElectronico;
                    txttelefono.Text = opalex.telefono1;
                }
            }
            if (codigo == "")
            {
                codCliente = "";
                txtcedula.Text = "";
                txtnombrecliente.Text = "";
                txtdireccion.Text = "";
                txtCorreElectronico.Text = "";
                txttelefono.Text = "";
                opalex = null;
            }
        }

        #region manejo malla
        private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow rr in malla.Rows)
            {
                rr.HeaderCell.Value = (rr.Index + 1).ToString();
            }
        }

        private String TipoRetencion()
        {
            if (UltTipoRetencion == NomTipoRetencion.RetFuente || string.IsNullOrEmpty(UltTipoRetencion))
            {
                UltTipoRetencion = NomTipoRetencion.IvaBienes;
            }
            else if (UltTipoRetencion == NomTipoRetencion.IvaBienes)
            {
                UltTipoRetencion = NomTipoRetencion.IvaServicios;
            }
            else
            {
                UltTipoRetencion = NomTipoRetencion.RetFuente;
            }
            return UltTipoRetencion;
        }

        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Left))
            { keyData = Keys.Return; }

            if (keyData == Keys.Return || (keyData >= Keys.F1 && keyData < Keys.F13))
            {
                DataGridViewCell cell = malla.CurrentCell;
                if (!(malla.IsCurrentCellInEditMode == false && keyData == Keys.Return)) funcionesEspeciales(ref keyData, malla);
                if (keyData != Keys.Return) return true;
                moverCeldaMalla(cell);
                return true;
            }
            if (keyData == Keys.Delete && malla.Focused) { EliminarLinea(); return true; };
            return false;
        }

        private void EliminarLinea()
        {
            malla.Rows.Remove(malla.CurrentRow);
            totalizar();
        }

        private void moverCeldaMalla(DataGridViewCell cell)
        {
            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;
            Int32 colOk = -1;

            if (col < malla.Columns.Count)
            {
                for (int i = col + 1; i < malla.Columns.Count - 1; i++)
                {
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false && malla.Columns[i].Name.ToUpper() != "DESCRIPCIÓN") { colOk = i; break; }
                }
            }

            if (colOk == -1)
            {
                for (int i = 0 + 1; i < malla.Columns.Count - 1; i++)
                {
                    if (malla.Columns[i].Visible == true && malla.Columns[i].ReadOnly == false) { colOk = i; break; }
                }

                if (row == malla.Rows.Count - 1)
                {
                    dtDetalleDocumento.Rows.InsertAt(dtDetalleDocumento.NewRow(), malla.Rows.Count);
                    row = malla.Rows.Count - 1;
                }
                else
                {
                    row++;
                }
            }
            col = colOk;
            malla.CurrentCell = malla.Rows[row].Cells[col];
        }
        #endregion manejo malla

        private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
        {
            Boolean resp = true;
            malla.EndEdit();

            if (malla.CurrentCell == null || malla.CurrentRow == null)
            {
                keyData = Keys.Cancel;
                return resp;
            }

            DataGridViewCell cell = malla.CurrentCell;
            DataGridViewRow row = malla.CurrentRow;

            string dato = "";
            if (cell.Value != null && cell.Value != DBNull.Value)
            {
                dato = cell.Value.ToString();
            }

            string nombreCelda = cell.OwningColumn.Name;

            string TipoDeRetencion = "";
            if (row.Cells["TipoRetencion"].Value != null &&
                row.Cells["TipoRetencion"].Value != DBNull.Value)
            {
                TipoDeRetencion = row.Cells["TipoRetencion"].Value.ToString();
            }

            if (nombreCelda.ToUpper() == "DOC_OPCDOCUMENTO" || nombreCelda.ToUpper() == "DOC_NUMERO")
            {
                if (keyData == Keys.F2)
                {
                    BuscadorDocumentos.BuscDocSoporte buscDoc = new BuscadorDocumentos.BuscDocSoporte(TipoDocumentoSoporte, codCliente);
                    idDocumento idclavsop = buscDoc.BuscarDocParaRetencion();
                    keyData = Keys.Return;
                    if (idclavsop != null && idclavsop.numero > 0)
                    {
                        SubirDatosDocumentoSustento(idclavsop);
                        if (cell.Value != null && cell.Value != DBNull.Value)
                        {
                            dato = cell.Value.ToString();
                        }
                    }
                }
            }
            else if (nombreCelda == "TipoRetencion")
            {
                if (keyData == Keys.F2)
                {
                    dato = TipoRetencion();
                    row.Cells["TipoRetencion"].Value = dato;
                }
            }
            else if (nombreCelda == "CodigoRetencion" || nombreCelda == "PorcRetencion")
            {
                if (keyData == Keys.F2)
                {
                    if (TipoDeRetencion == "RetFuente")
                    {
                        dato = buscarCodigoRetencion(row, nombreTablas.ConceptosRetencion);
                    }
                    else if (TipoDeRetencion == "IvaBienes")
                    {
                        dato = buscarCodigoRetencion(row, nombreTablas.RetencionIvaBienes);
                    }
                    else if (TipoDeRetencion == "IvaServicios")
                    {
                        dato = buscarCodigoRetencion(row, nombreTablas.RetencionIvaServicios);
                    }
                }
            }

            if (malla.CurrentCell != null)
            {
                object valorActual = malla.CurrentCell.Value;
                string valorStr = "";
                if (valorActual != null && valorActual != DBNull.Value)
                {
                    valorStr = valorActual.ToString();
                }

                if (!string.IsNullOrEmpty(valorStr))
                {
                    keyData = Keys.Return;
                }
                else
                {
                    keyData = Keys.Cancel;
                }
            }
            else
            {
                keyData = Keys.Cancel;
            }

            totalizar();
            return resp;
        }

        private string buscarCodigoRetencion(DataGridViewRow row, string nombreTabla)
        {
            string dato = "";
            double valor = 0;
            FrmBuscar tabSri = new FrmBuscar();
            string nombre = "";
            dato = tabSri.Buscar(Convert.ToInt16(tipoTransaccion), nombreTabla, ref nombre, ref valor);
            tabSri.Dispose();

            if (!string.IsNullOrEmpty(dato))
            {
                row.Cells["CodigoRetencion"].Value = dato;
                row.Cells["PorcRetencion"].Value = valor;

                double baseRet = 0;
                double.TryParse(row.Cells["BaseRetencion"].Value?.ToString(), out baseRet);
                double valRet = baseRet * valor / 100;
                row.Cells["ValorRetencion"].Value = Math.Round(valRet, 2);
            }

            totalizar();
            return dato ?? "";
        }

        private void SubirDatosDocumentoSustento(idDocumento IdDocSustento)
        {
            // ========================================================
            // 1. VERIFICAR SI LA FACTURA YA TIENE UNA RETENCIÓN ASOCIADA
            // ========================================================
            string ssql = "SELECT IdClaveDoc, Doc_sucursal, Opc_documento, Doc_numero, Doc_NroIdDoc, Doc_fecha " +
                   "FROM ADCDOC " +
                   "WHERE Opc_documento = 'RTP' " +
                   "AND Doc_DocSop = '" + IdDocSustento.Tipo + "' " +
                   "AND Doc_NumSop = " + IdDocSustento.numero.ToString() + " " +
                   "AND Doc_Estado = 1";

            DataTable dtRetencion = SqlDatos.leerTablaAdcom(ssql);

            if (dtRetencion != null && dtRetencion.Rows.Count > 0)
            {
                DataRow row = dtRetencion.Rows[0];
                double idClaveRetencion = Convert.ToDouble(row["IdClaveDoc"]);
                string sucRetencion = row["Doc_sucursal"].ToString();
                string tipRetencion = row["Opc_documento"].ToString();
                double numRetencion = Convert.ToDouble(row["Doc_numero"]);
                string serieRetencion = row["Doc_NroIdDoc"].ToString();
                DateTime fechaRetencion = Convert.ToDateTime(row["Doc_fecha"]);

                DialogResult result = MessageBox.Show(
                    "Este documento de soporte ya tiene una retención asociada.\n" +
                    "Número de retención: " + numRetencion.ToString() + "\n" +
                    "Tipo: " + tipRetencion + "\n" +
                    "Fecha: " + fechaRetencion.ToShortDateString() + "\n\n" +
                    "¿Desea abrir la retención existente?",
                    "Retención existente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClassDoc.idDocumento idDocRetencion = new ClassDoc.idDocumento();
                    idDocRetencion.idClave = idClaveRetencion;
                    idDocRetencion.numero = numRetencion;
                    idDocRetencion.Sucursal = sucRetencion;
                    idDocRetencion.Tipo = tipRetencion;
                    idDocRetencion.familia = tipRetencion;
                    idDocRetencion.fecha = fechaRetencion;
                    idDocRetencion.Serie = serieRetencion;

                    CargarDatosDesdeDocumento(idDocRetencion);
                    this.Text = "MANTENIMIENTO DE RETENCIONES - RETENCIÓN EXISTENTE (" + tipRetencion + " - " + numRetencion.ToString() + ")";
                }
                return;
            }

            // ========================================================
            // 2. SI NO EXISTE RETENCIÓN, CONTINUAR CON EL FLUJO NORMAL
            // ========================================================
            decimal MontoIvaBienes = 0;
            decimal MontoIvaServicios = 0;
            decimal MontoBienesIva = 0;
            decimal MontoServiciosIva = 0;
            decimal MontoBienesIvaCero = 0;
            decimal MontoServiciosIvaCero = 0;

            decimal numeroRetencion = 0;
            if (!string.IsNullOrEmpty(txtnumero.Text))
            {
                decimal.TryParse(txtnumero.Text, out numeroRetencion);
            }

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                using (SqlCommand comm = new SqlCommand("SP_BASES_SRI_DOCUMENTO", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@SUC", IdDocSustento.Sucursal);
                    comm.Parameters.AddWithValue("@OPC", IdDocSustento.Tipo);
                    comm.Parameters.AddWithValue("@NUMERO", IdDocSustento.numero);
                    comm.Parameters.AddWithValue("@IDCLAVEDOC", IdDocSustento.idClave);

                    conn.Open();

                    using (SqlDataReader rs = comm.ExecuteReader())
                    {
                        if (rs.Read())
                        {
                            MontoBienesIva = Convert.ToDecimal(rs["BaseBienesIva"]);
                            MontoServiciosIva = Convert.ToDecimal(rs["BaseServiciosIva"]);
                            MontoBienesIvaCero = Convert.ToDecimal(rs["BaseBienes0"]);
                            MontoServiciosIvaCero = Convert.ToDecimal(rs["BaseServicios0"]);
                            MontoIvaBienes = Convert.ToDecimal(rs["IvaBienes"]);
                            MontoIvaServicios = Convert.ToDecimal(rs["IvaServicios"]);
                        }
                    }
                }
            }

            decimal baseConIva = MontoBienesIva + MontoServiciosIva;
            decimal baseSinIva = MontoBienesIvaCero + MontoServiciosIvaCero;
            decimal totalBase = baseConIva + baseSinIva;

            // ELIMINAR FILAS VACÍAS
            for (int i = dtDetalleDocumento.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dtDetalleDocumento.Rows[i];
                bool esVacia = true;
                foreach (DataColumn col in dtDetalleDocumento.Columns)
                {
                    if (row[col] != null && row[col] != DBNull.Value)
                    {
                        string valor = row[col].ToString();
                        if (!string.IsNullOrEmpty(valor))
                        {
                            esVacia = false;
                            break;
                        }
                    }
                }
                if (esVacia)
                {
                    dtDetalleDocumento.Rows.RemoveAt(i);
                }
            }

            // CONTAR LÍNEAS DE RETENCIÓN FUENTE
            int contadorRetFuente = 0;
            bool existeIvaServicios = false;
            bool existeIvaBienes = false;

            foreach (DataRow row in dtDetalleDocumento.Rows)
            {
                if (row["SRI_IdClaveDoc"] != null && row["SRI_IdClaveDoc"] != DBNull.Value)
                {
                    decimal idClave = Convert.ToDecimal(row["SRI_IdClaveDoc"]);
                    if (idClave == Convert.ToDecimal(IdDocSustento.idClave))
                    {
                        string tipoRet = row["TipoRetencion"]?.ToString() ?? "";
                        if (tipoRet == "RetFuente")
                        {
                            contadorRetFuente++;
                        }
                        else if (tipoRet == "IvaServicios")
                        {
                            existeIvaServicios = true;
                        }
                        else if (tipoRet == "IvaBienes")
                        {
                            existeIvaBienes = true;
                        }
                    }
                }
            }

            if (contadorRetFuente >= 2)
            {
                MessageBox.Show("Ya existen 2 líneas de Retención Fuente para este documento.\n" +
                                "No se pueden agregar más conceptos (máximo 2).",
                                "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // CREAR NUEVA LÍNEA DE RETENCIÓN FUENTE
            int linea = dtDetalleDocumento.Rows.Count + 1;

            DataRow rowRF = dtDetalleDocumento.NewRow();

            rowRF["SRI_Sucursal"] = IdDocSustento.Sucursal;
            rowRF["SRI_Documento"] = IdDocSustento.Tipo;
            rowRF["SRI_IdClaveDoc"] = Convert.ToDecimal(IdDocSustento.idClave);
            rowRF["SRI_NumeroRetencion"] = numeroRetencion;

            rowRF["Doc_Sucursal"] = IdDocSustento.Sucursal;
            rowRF["Doc_OpcDocumento"] = IdDocSustento.Tipo;
            rowRF["Doc_Numero"] = IdDocSustento.numero.ToString("F0");
            rowRF["Doc_IdClave"] = Convert.ToDecimal(IdDocSustento.idClave);

            rowRF["Doc_Linea"] = linea;
            rowRF["Doc_CodSri"] = DBNull.Value;
            rowRF["TipoRetencion"] = "RetFuente";
            rowRF["BaseRetencion"] = totalBase;
            rowRF["PorcRetencion"] = 0;
            rowRF["ValorRetencion"] = 0;
            rowRF["BaseConIva"] = baseConIva;
            rowRF["BaseExcentaIva"] = baseSinIva;
            rowRF["BaseIvaCero"] = 0;

            // ========================================================
            // SI VIENE CON CÓDIGO FORZADO (332) ASIGNARLO A LA NUEVA LÍNEA
            // ========================================================
            if (!string.IsNullOrEmpty(CodigoRetencionForzado))
            {
                rowRF["CodigoRetencion"] = CodigoRetencionForzado;

                if (CodigoRetencionForzado == "332")
                {
                    rowRF["PorcRetencion"] = 0.00m;
                }
                else
                {
                    decimal porcentaje = BuscarPorcentajeRetencion(CodigoRetencionForzado);
                    rowRF["PorcRetencion"] = porcentaje;
                }

                decimal baseRet = Convert.ToDecimal(rowRF["BaseRetencion"]);
                decimal porcRet = Convert.ToDecimal(rowRF["PorcRetencion"]);
                rowRF["ValorRetencion"] = Math.Round(baseRet * porcRet / 100, 2);
            }
            else
            {
                rowRF["CodigoRetencion"] = "";
            }
            // ========================================================

            dtDetalleDocumento.Rows.Add(rowRF);

            // ========================================================
            // CREAR LÍNEA DE IVA SERVICIOS (SOLO SI NO EXISTE Y HAY IVA)
            // ========================================================
            if (MontoIvaServicios > 0 && !existeIvaServicios)
            {
                linea++;
                DataRow rowIS = dtDetalleDocumento.NewRow();

                rowIS["SRI_Sucursal"] = IdDocSustento.Sucursal;
                rowIS["SRI_Documento"] = IdDocSustento.Tipo;
                rowIS["SRI_IdClaveDoc"] = Convert.ToDecimal(IdDocSustento.idClave);
                rowIS["SRI_NumeroRetencion"] = numeroRetencion;

                rowIS["Doc_Sucursal"] = IdDocSustento.Sucursal;
                rowIS["Doc_OpcDocumento"] = IdDocSustento.Tipo;
                rowIS["Doc_Numero"] = IdDocSustento.numero.ToString("F0");
                rowIS["Doc_IdClave"] = Convert.ToDecimal(IdDocSustento.idClave);

                rowIS["Doc_Linea"] = linea;
                rowIS["Doc_CodSri"] = DBNull.Value;
                rowIS["TipoRetencion"] = "IvaServicios";
                rowIS["CodigoRetencion"] = "";
                rowIS["BaseRetencion"] = MontoIvaServicios;
                rowIS["PorcRetencion"] = 0;
                rowIS["ValorRetencion"] = 0;
                rowIS["BaseConIva"] = 0;
                rowIS["BaseExcentaIva"] = 0;
                rowIS["BaseIvaCero"] = 0;

                dtDetalleDocumento.Rows.Add(rowIS);
            }

            // ========================================================
            // CREAR LÍNEA DE IVA BIENES (SOLO SI NO EXISTE Y HAY IVA BIENES)
            // ========================================================
            if (MontoIvaBienes > 0 && !existeIvaBienes)
            {
                linea++;
                DataRow rowIB = dtDetalleDocumento.NewRow();

                rowIB["SRI_Sucursal"] = IdDocSustento.Sucursal;
                rowIB["SRI_Documento"] = IdDocSustento.Tipo;
                rowIB["SRI_IdClaveDoc"] = Convert.ToDecimal(IdDocSustento.idClave);
                rowIB["SRI_NumeroRetencion"] = numeroRetencion;

                rowIB["Doc_Sucursal"] = IdDocSustento.Sucursal;
                rowIB["Doc_OpcDocumento"] = IdDocSustento.Tipo;
                rowIB["Doc_Numero"] = IdDocSustento.numero.ToString("F0");
                rowIB["Doc_IdClave"] = Convert.ToDecimal(IdDocSustento.idClave);

                rowIB["Doc_Linea"] = linea;
                rowIB["Doc_CodSri"] = DBNull.Value;
                rowIB["TipoRetencion"] = "IvaBienes";
                rowIB["CodigoRetencion"] = "";
                rowIB["BaseRetencion"] = MontoIvaBienes;
                rowIB["PorcRetencion"] = 0;
                rowIB["ValorRetencion"] = 0;
                rowIB["BaseConIva"] = 0;
                rowIB["BaseExcentaIva"] = 0;
                rowIB["BaseIvaCero"] = 0;

                dtDetalleDocumento.Rows.Add(rowIB);
            }

            // Refrescar el DataGridView
            malla.DataSource = null;
            malla.DataSource = dtDetalleDocumento;
            EstructuraMallaRetencion.DiseñarMalla(malla);
            totalizar();

            malla.Refresh();
            malla.Update();
        }

        private void ponerDatosRtencionFuente(string codRetencion, DataGridViewRow row, string strConxIvaret)
        {
            malla.EndEdit();
            if (codRetencion.Length == 0) return;
            nombreTablas tabNom = new nombreTablas();
            string ssql = tabNom.armarConsulta(nombreTablas.ConceptosRetencion, txtfecha.Value.ToShortDateString(), 0, 0, 0);
            ssql += " and Código = '" + codRetencion + "'";
            DataTable dt = SqlDatos.leerTablaIvaret(ssql);
            if (dt.Rows.Count > 0)
            {
                row.Cells["Descripción"].Value = dt.Rows[0]["Descripción"].ToString();
                row.Cells["Porcentaje"].Value = dt.Rows[0]["Porcentaje"].ToString();
            }
            else
            {
                MessageBox.Show("El código digitado no existe", "Valida codigo retención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabNom = null;
            dt.Dispose();
        }

        private void totalizar()
        {
            Double totalizar = 0;
            double retenido = 0;
            if (malla.CurrentCell != null)
            {
                double ValReten = 0;
                DataGridViewRow row = malla.Rows[malla.CurrentCell.RowIndex];
                if (row.Cells["BaseRetencion"].Value != null && row.Cells["PorcRetencion"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["PorcRetencion"].Value.ToString()))
                {
                    double baseRet = Convert.ToDouble(row.Cells["BaseRetencion"].Value);
                    double porcRet = Convert.ToDouble(row.Cells["PorcRetencion"].Value);
                    ValReten = Math.Round(baseRet * porcRet / 100, 2);
                }
                else
                {
                    ValReten = 0;
                }
                row.Cells["ValorRetencion"].Value = ValReten;
            }
            foreach (DataGridViewRow row in malla.Rows)
            {
                retenido = Convert.ToDouble("0" + row.Cells["ValorRetencion"].Value);
                totalizar += retenido;
            }
            edTotal.Text = Math.Round(totalizar, 2).ToString("0.00");
        }

        private void btnAbre_Click(object sender, EventArgs e)
        {
            BuscadorDocumentos.buscadorDoc progBus = new BuscadorDocumentos.buscadorDoc();
            progBus.IniciaBusqueda(propiedadesDoc.TipoDoc, "", cmbDocumento.SelectedValue.ToString(), DateTime.Now, ref idDocumentoActual.Sucursal, ref idDocumentoActual.Tipo, ref idDocumentoActual.numero, ref idDocumentoActual.idClave, false, cmbDocumento.SelectedValue.ToString(), "", "", "ADCDOC");
            if (idDocumentoActual.idClave == 0) { ActualizarIdDocumento(); return; }
            if (idDocumentoActual.Sucursal.ToUpper() != datosEmpresa.suc.ToUpper()) { mensajesErrorDocumento.documentosNoDeOtraSucursal(datosEmpresa.sucNom); return; }
            if (idDocumentoActual.idClave != 0) CargarDatosRetencion(idDocumentoActual);
        }

        private bool CargarDatosRetencion(idDocumento id)
        {
            // ========================================================
            // 1. CONSTRUIR LA CONSULTA USANDO EL PARÁMETRO id
            // ========================================================
            string ssql = "Doc_Sucursal = '" + id.Sucursal + "' AND Opc_documento = '" + id.Tipo + "' ";

            if (id.idClave == 0)
            {
                ssql += " AND Doc_NroIdDoc = '" + id.Serie + "' AND Doc_numero = " + id.numero.ToString();
            }
            else
            {
                ssql += " AND IdClaveDoc = " + id.idClave.ToString();
            }

            // ========================================================
            // 2. CARGAR EL DOCUMENTO DESDE ADCDOC (LA RETENCIÓN)
            // ========================================================
            DatosDocumento = new AdcDoc(datosEmpresa.strConxAdcom);
            DatosDocumento = AdcDoc.Buscar(ssql);

            if (DatosDocumento == null)
            {
                MessageBox.Show("El documento " + id.Sucursal + "/" + id.Tipo + "/" + id.Serie + "/" + id.numero.ToString() + " no existe");
                return false;
            }

            idDocumentoActual.idClave = Convert.ToDouble(DatosDocumento.IdClaveDoc);
            idDocumentoActual.numero = Convert.ToDouble(DatosDocumento.Doc_numero);
            idDocumentoActual.Sucursal = DatosDocumento.Doc_sucursal;
            idDocumentoActual.Tipo = DatosDocumento.Opc_documento;
            idDocumentoActual.Serie = DatosDocumento.Doc_NroIdDoc;
            idDocumentoActual.fecha = DatosDocumento.Doc_fecha;
            idDocumentoActual.familia = DatosDocumento.Doc_TipoDoc;

            txtNroID.Text = DatosDocumento.Doc_NroIdDoc;
            txtnumero.Text = DatosDocumento.Doc_numero.ToString();
            txtNroAutorizacion.Text = DatosDocumento.NroAutorizacionSri;
            txtfecha.Value = DatosDocumento.Doc_fecha;
            txtDetalle.Text = DatosDocumento.Doc_detalle;

            cargarDatosCliente(DatosDocumento.Doc_codper);

            // ========================================================
            // 3. OBTENER DATOS DE LA FACTURA SOPORTE DESDE ADCDOC
            // ========================================================
            string tipoFactura = "";
            string numeroFactura = "";
            double idClaveFactura = 0;

            if (!string.IsNullOrEmpty(DatosDocumento.Doc_DocSop) && DatosDocumento.Doc_NumSop > 0)
            {
                string ssqlFactura = "SELECT Opc_documento, Doc_numero, IdClaveDoc FROM ADCDOC " +
                                     "WHERE Doc_sucursal = '" + DatosDocumento.Doc_sucursal + "' " +
                                     "AND Opc_documento = '" + DatosDocumento.Doc_DocSop + "' " +
                                     "AND Doc_numero = " + DatosDocumento.Doc_NumSop.ToString();

                DataTable dtFactura = SqlDatos.leerTablaAdcom(ssqlFactura);
                if (dtFactura != null && dtFactura.Rows.Count > 0)
                {
                    tipoFactura = dtFactura.Rows[0]["Opc_documento"].ToString();  // FAP
                    numeroFactura = dtFactura.Rows[0]["Doc_numero"].ToString();   // 6909
                    idClaveFactura = Convert.ToDouble(dtFactura.Rows[0]["IdClaveDoc"]); // 2
                }
            }

            // Si no se encontró la factura, usar los datos de la retención
            if (string.IsNullOrEmpty(tipoFactura))
            {
                tipoFactura = idDocumentoActual.Tipo;
                numeroFactura = idDocumentoActual.numero.ToString();
                idClaveFactura = idDocumentoActual.idClave;
            }

            // ========================================================
            // 4. CARGAR DETALLE DE RETENCIÓN DESDE AdcSri9
            // ========================================================
            ssql = "SELECT * FROM AdcSri9 WHERE SRI_SUCURSAL = '" + idDocumentoActual.Sucursal +
                   "' AND SRI_DOCUMENTO = '" + idDocumentoActual.Tipo +
                   "' AND IdClaveDoc = " + idDocumentoActual.idClave.ToString();

            DataTable dtSri9 = SqlDatos.leerTablaAdcom(ssql);

            dtDetalleDocumento = EstructuraMallaRetencion.CrearDataTable();

            int linea = 0;

            if (dtSri9 != null && dtSri9.Rows.Count > 0)
            {
                DataRow rowSri = dtSri9.Rows[0];

                // ========================================================
                // 1. RETENCIÓN FUENTE (PRIMER CONCEPTO)
                // ========================================================
                decimal baseRetFuente = Convert.ToDecimal(rowSri["BaseRetFuente"]);
                decimal porRetFuente = Convert.ToDecimal(rowSri["PorRetFuente"]);
                decimal valorRetFuente = Convert.ToDecimal(rowSri["ValorRetFuente"]);
                string codRetFuente = rowSri["CodigoRetFuente"]?.ToString() ?? "";

                if (baseRetFuente > 0 || porRetFuente > 0)
                {
                    linea++;
                    DataRow rowRF = dtDetalleDocumento.NewRow();

                    // ✅ CAMPOS SRI: DATOS DE LA RETENCIÓN
                    rowRF["SRI_Sucursal"] = rowSri["SRI_SUCURSAL"].ToString();
                    rowRF["SRI_Documento"] = rowSri["SRI_DOCUMENTO"].ToString();
                    rowRF["SRI_IdClaveDoc"] = Convert.ToDecimal(rowSri["IdClaveDoc"]);
                    rowRF["SRI_NumeroRetencion"] = Convert.ToDecimal(rowSri["SRI_NUMERORET"]);

                    // ✅ CAMPOS DOC: DATOS DE LA FACTURA SOPORTE (DESDE ADCDOC)
                    rowRF["Doc_Sucursal"] = idDocumentoActual.Sucursal;  // AV6
                    rowRF["Doc_OpcDocumento"] = tipoFactura;             // FAP
                    rowRF["Doc_Numero"] = numeroFactura;                 // 6909
                    rowRF["Doc_IdClave"] = Convert.ToDecimal(idClaveFactura); // 2

                    rowRF["Doc_Linea"] = linea;
                    rowRF["Doc_CodSri"] = DBNull.Value;
                    rowRF["TipoRetencion"] = "RetFuente";
                    rowRF["CodigoRetencion"] = codRetFuente;
                    rowRF["BaseRetencion"] = baseRetFuente;
                    rowRF["PorcRetencion"] = porRetFuente;
                    rowRF["ValorRetencion"] = valorRetFuente;
                    rowRF["BaseConIva"] = Convert.ToDecimal(rowSri["BasIvaCon"]);
                    rowRF["BaseExcentaIva"] = Convert.ToDecimal(rowSri["BasIvaCer"]);
                    rowRF["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowRF);
                }

                // ========================================================
                // 2. RETENCIÓN FUENTE (SEGUNDO CONCEPTO)
                // ========================================================
                decimal baseRetFuente1 = Convert.ToDecimal(rowSri["BaseRetFuente1"]);
                decimal porRetFuente1 = Convert.ToDecimal(rowSri["PorRetFuente1"]);
                decimal valorRetFuente1 = Convert.ToDecimal(rowSri["ValorRetFuente1"]);
                string codRetFuente1 = rowSri["CodigoRetFuente1"]?.ToString() ?? "";

                if (baseRetFuente1 > 0 || porRetFuente1 > 0)
                {
                    linea++;
                    DataRow rowRF1 = dtDetalleDocumento.NewRow();

                    rowRF1["SRI_Sucursal"] = rowSri["SRI_SUCURSAL"].ToString();
                    rowRF1["SRI_Documento"] = rowSri["SRI_DOCUMENTO"].ToString();
                    rowRF1["SRI_IdClaveDoc"] = Convert.ToDecimal(rowSri["IdClaveDoc"]);
                    rowRF1["SRI_NumeroRetencion"] = Convert.ToDecimal(rowSri["SRI_NUMERORET"]);

                    rowRF1["Doc_Sucursal"] = idDocumentoActual.Sucursal;
                    rowRF1["Doc_OpcDocumento"] = tipoFactura;
                    rowRF1["Doc_Numero"] = numeroFactura;
                    rowRF1["Doc_IdClave"] = Convert.ToDecimal(idClaveFactura);

                    rowRF1["Doc_Linea"] = linea;
                    rowRF1["Doc_CodSri"] = DBNull.Value;
                    rowRF1["TipoRetencion"] = "RetFuente";
                    rowRF1["CodigoRetencion"] = codRetFuente1;
                    rowRF1["BaseRetencion"] = baseRetFuente1;
                    rowRF1["PorcRetencion"] = porRetFuente1;
                    rowRF1["ValorRetencion"] = valorRetFuente1;
                    rowRF1["BaseConIva"] = Convert.ToDecimal(rowSri["BasIvaCon1"]);
                    rowRF1["BaseExcentaIva"] = Convert.ToDecimal(rowSri["BasIvaCer1"]);
                    rowRF1["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowRF1);
                }

                // ========================================================
                // 3. IVA BIENES
                // ========================================================
                decimal baseIvaBienes = Convert.ToDecimal(rowSri["BaseIvaBienes"]);
                decimal porRetIvaBienes = Convert.ToDecimal(rowSri["PorRetIvaBienes"]);
                decimal valorRetIvaBienes = Convert.ToDecimal(rowSri["ValorRetIvaBienes"]);
                string codRetIvaBienes = rowSri["CodigoRetIvaBienes"]?.ToString() ?? "";

                if (baseIvaBienes > 0 || porRetIvaBienes > 0)
                {
                    linea++;
                    DataRow rowIB = dtDetalleDocumento.NewRow();

                    rowIB["SRI_Sucursal"] = rowSri["SRI_SUCURSAL"].ToString();
                    rowIB["SRI_Documento"] = rowSri["SRI_DOCUMENTO"].ToString();
                    rowIB["SRI_IdClaveDoc"] = Convert.ToDecimal(rowSri["IdClaveDoc"]);
                    rowIB["SRI_NumeroRetencion"] = Convert.ToDecimal(rowSri["SRI_NUMERORET"]);

                    rowIB["Doc_Sucursal"] = idDocumentoActual.Sucursal;
                    rowIB["Doc_OpcDocumento"] = tipoFactura;
                    rowIB["Doc_Numero"] = numeroFactura;
                    rowIB["Doc_IdClave"] = Convert.ToDecimal(idClaveFactura);

                    rowIB["Doc_Linea"] = linea;
                    rowIB["Doc_CodSri"] = DBNull.Value;
                    rowIB["TipoRetencion"] = "IvaBienes";
                    rowIB["CodigoRetencion"] = codRetIvaBienes;
                    rowIB["BaseRetencion"] = baseIvaBienes;
                    rowIB["PorcRetencion"] = porRetIvaBienes;
                    rowIB["ValorRetencion"] = valorRetIvaBienes;
                    rowIB["BaseConIva"] = 0;
                    rowIB["BaseExcentaIva"] = 0;
                    rowIB["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowIB);
                }

                // ========================================================
                // 4. IVA SERVICIOS
                // ========================================================
                decimal baseIvaServicios = Convert.ToDecimal(rowSri["BaseIvaServicios"]);
                decimal porRetIvaServicios = Convert.ToDecimal(rowSri["PorRetIvaServicios"]);
                decimal valorRetIvaServicios = Convert.ToDecimal(rowSri["ValorRetIvaServicios"]);
                string codRetIvaServicios = rowSri["CodigoRetIvaServicios"]?.ToString() ?? "";

                if (baseIvaServicios > 0 || porRetIvaServicios > 0)
                {
                    linea++;
                    DataRow rowIS = dtDetalleDocumento.NewRow();

                    rowIS["SRI_Sucursal"] = rowSri["SRI_SUCURSAL"].ToString();
                    rowIS["SRI_Documento"] = rowSri["SRI_DOCUMENTO"].ToString();
                    rowIS["SRI_IdClaveDoc"] = Convert.ToDecimal(rowSri["IdClaveDoc"]);
                    rowIS["SRI_NumeroRetencion"] = Convert.ToDecimal(rowSri["SRI_NUMERORET"]);

                    rowIS["Doc_Sucursal"] = idDocumentoActual.Sucursal;
                    rowIS["Doc_OpcDocumento"] = tipoFactura;
                    rowIS["Doc_Numero"] = numeroFactura;
                    rowIS["Doc_IdClave"] = Convert.ToDecimal(idClaveFactura);

                    rowIS["Doc_Linea"] = linea;
                    rowIS["Doc_CodSri"] = DBNull.Value;
                    rowIS["TipoRetencion"] = "IvaServicios";
                    rowIS["CodigoRetencion"] = codRetIvaServicios;
                    rowIS["BaseRetencion"] = baseIvaServicios;
                    rowIS["PorcRetencion"] = porRetIvaServicios;
                    rowIS["ValorRetencion"] = valorRetIvaServicios;
                    rowIS["BaseConIva"] = 0;
                    rowIS["BaseExcentaIva"] = 0;
                    rowIS["BaseIvaCero"] = 0;

                    dtDetalleDocumento.Rows.Add(rowIS);
                }
            }
            else
            {
                InicializarMalla(true);
            }

            malla.DataSource = null;
            malla.DataSource = dtDetalleDocumento;
            EstructuraMallaRetencion.DiseñarMalla(malla);
            totalizar();

            operacionEnCurso = 2;
            prepararBotones();

            return true;
        }


        private void malla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (malla.Columns[e.ColumnIndex].Name == "TipoRetencion") malla.CurrentCell.Value = TipoRetencion();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.eliminarDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConIniSis, idDocumentoActual, DatosUsuario.Identifica, esDeLiquidacion, datosEmpresa.Emp_Nombre, datosEmpresa.Emp_codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;

            if (CerrarDespuesDeGrabar)
            {
                this.Close();
                this.Dispose();
            }
            else
            {
                limpiarDatos();
            }
        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            DctosEmi.anulaElimina classAnular = new DctosEmi.anulaElimina();
            if (classAnular.anularDocumento(datosEmpresa.strConxAdcom, datosEmpresa.strConIniSis, idDocumentoActual, DatosUsuario.Identifica, esDeLiquidacion, datosEmpresa.Emp_Nombre, datosEmpresa.Emp_codigo.ToString(), edTotal.Text, "ADCDOC", propiedadesDoc.ComandoExterno)) limpiarDatos();
            classAnular = null;
            if (CerrarDespuesDeGrabar)
            {
                this.Close();
                this.Dispose();
            }
            else
            {
                limpiarDatos();
            }
        }

        private void btnCierra_Click(object sender, EventArgs e)
        {
            // ✅ SIEMPRE CERRAR EL FORMULARIO
            this.Close();
            this.Dispose();
        }

        private void btnContabiliza_Click(object sender, EventArgs e)
        {
            DatosRetencion.moverDatosAclase(this);
            daxContaDoc.frmVisContab progCtb = new daxContaDoc.frmVisContab(mallaContable, DatosDocumento, (DataTable)malla.DataSource, propiedadesDoc);
            mallaContable = progCtb.IniciarRevisionContable();
            progCtb.Dispose();
        }

        private void btnGraba_Click(object sender, EventArgs e)
        {
            if (!ValidarMalla())
            {
                return;
            }
            DatosRetencion.moverDatosAclase(this);
            {
                if (grabarDocumento() == true)
                {
                    if (CerrarDespuesDeGrabar)
                    {
                        this.Close();
                        this.Dispose();
                    }
                    else
                    {
                        limpiarDatos();
                    }
                }
            }
        }

        private Boolean grabarDocumento()
        {
            malla.EndEdit();
            Boolean RESP = true;
            string res = "";

            // ========================================================
            // VALIDAR QUE EXISTA AL MENOS UNA LÍNEA CON CÓDIGO DE RETENCIÓN
            // ========================================================
            bool tieneCodigo = false;
            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.IsNewRow) continue;

                string codigo = row.Cells["CodigoRetencion"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(codigo))
                {
                    tieneCodigo = true;
                    break;
                }
            }

            if (!tieneCodigo)
            {
                DialogResult result = MessageBox.Show(
                    "No ha seleccionado ningún concepto de retención.\n" +
                    "El documento se grabará con Valor cero y con el código 332 (0%).\n\n" +
                    "¿Desea continuar?",
                    "Advertencia - Sin concepto de retención",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return false;
                }

                bool asignado = false;
                foreach (DataGridViewRow row in malla.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tipoRet = row.Cells["TipoRetencion"].Value?.ToString() ?? "";
                    if (tipoRet == "RetFuente")
                    {
                        row.Cells["CodigoRetencion"].Value = "332";
                        row.Cells["PorcRetencion"].Value = 0.00m;
                        row.Cells["ValorRetencion"].Value = 0.00m;
                        asignado = true;
                        break;
                    }
                }

                if (!asignado)
                {
                    DataRow newRow = dtDetalleDocumento.NewRow();
                    newRow["TipoRetencion"] = "RetFuente";
                    newRow["CodigoRetencion"] = "332";
                    newRow["PorcRetencion"] = 0.00m;
                    newRow["ValorRetencion"] = 0.00m;
                    dtDetalleDocumento.Rows.Add(newRow);

                    malla.DataSource = null;
                    malla.DataSource = dtDetalleDocumento;
                    EstructuraMallaRetencion.DiseñarMalla(malla);
                }

                totalizar();
            }

            try
            {
                if (idDocumentoActual.idClave == 0)
                {
                    if (DatosDocumento.Doc_numero == 0) return false;
                    res = DatosDocumento.Crear();
                    if (res.Substring(0, 3) != "ERR")
                    {
                        txtnumero.Text = DatosDocumento.Doc_numero.ToString();
                        idDocumentoActual.idClave = Convert.ToDouble(DatosDocumento.IdClaveDoc);
                        idDocumentoActual.numero = Convert.ToDouble(DatosDocumento.Doc_numero);
                        DatosRetencion.GuardarDetalleDoc(DatosDocumento, malla);
                        if (propiedadesDoc.SNContabilizar > 0)
                        {
                            if (mallaContable.ListDetalleContab.Count > 0)
                            {
                                mallaContable.GrabarDetalleContable(malla, idDocumentoActual);
                            }
                            else
                            {
                                daxContaDoc.contabilizaDocumento ctb = new daxContaDoc.contabilizaDocumento();
                                mallaContable = ctb.GenerarContabilidadDocumento(DatosDocumento, (DataTable)malla.DataSource, propiedadesDoc, null, "");
                                mallaContable.GrabarDetalleContable(idDocumentoActual);
                            }
                        }
                        AuditSis.registrar.registraEventoDoc(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntCrear, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), DatosDocumento.Doc_valor.ToString());
                    }
                    else { DatosDocumento.Borrar(); }
                }
                else
                {
                    res = DatosDocumento.Actualizar();
                    if (res.Substring(0, 3) != "ERR")
                    {
                        DatosRetencion.GuardarDetalleDoc(DatosDocumento, malla);
                        AuditSis.registrar.registraEventoDoc(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "MDD", Environment.MachineName, AuditSis.registrar.EvntModifica, idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.numero.ToString(), DatosDocumento.Doc_valor.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                res = "ERR " + ee.Message;
            }
            if ((res + "   ").Substring(0, 3) == "ERR")
            {
                MessageBox.Show("EL DOCUMENTO NO FUE GRABADO CORRECTAMENTE \n" + res);
                RESP = false;
            }
            return RESP;
        }

        private void btnRegistra_Click(object sender, EventArgs e)
        {
            if (!ValidarMalla())
            {
                return;
            }
            DatosRetencion.moverDatosAclase(this);

            if (grabarDocumento() == true)
            {
                ImpresionesDeldocumento("", true);
                if (CerrarDespuesDeGrabar)
                {
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    limpiarDatos();
                }
            }
        }

        private bool ValidarMalla()
        {
            bool tieneDatos = false;

            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.IsNewRow) continue;

                string codigoRetencion = row.Cells["CodigoRetencion"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(codigoRetencion))
                {
                    tieneDatos = true;
                    break;
                }

                string docOpc = row.Cells["Doc_OpcDocumento"].Value?.ToString() ?? "";
                string docNum = row.Cells["Doc_Numero"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(docOpc) && !string.IsNullOrEmpty(docNum))
                {
                    tieneDatos = true;
                    break;
                }

                decimal baseRet = 0;
                if (row.Cells["BaseRetencion"].Value != null && row.Cells["BaseRetencion"].Value != DBNull.Value)
                {
                    decimal.TryParse(row.Cells["BaseRetencion"].Value.ToString(), out baseRet);
                    if (baseRet > 0)
                    {
                        tieneDatos = true;
                        break;
                    }
                }
            }

            if (!tieneDatos)
            {
                MessageBox.Show("No hay datos para grabar la retención.\n" +
                                "Debe agregar al menos una línea con un concepto de retención.\n" +
                                "Presione F2 en la columna 'Doc' para seleccionar una factura.",
                                "Sin datos para grabar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ImpresionesDeldocumento(string OtroFormato = "", bool ImpresionDirecta = false)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= DatosDocumento.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
            int imp = 0;
            if (ImpresionDirecta)
            {
                imp = impProg.ImpDocFast(idDocumentoActual, "A", OtroFormato, false, true);
            }
            else
            {
                imp = impProg.ImpDoc(idDocumentoActual, "A", OtroFormato, false, false);
            }
            DatosDocumento.Doc_Adicional1 = imp;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            ImpresionesDeldocumento("");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtnumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && txtnumero.TextLength > 0)
            {
                idDocumentoActual.numero = Convert.ToDouble(txtnumero.Text);
                idDocumentoActual.Serie = txtNroID.Text;
                CargarDatosRetencion(idDocumentoActual);
            }
        }

        private void cmbDocumento_SelectedValueChanged(object sender, EventArgs e)
        {
            ActualizarIdDocumento();
        }

        private void txtcedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
        }

        private void ingresaCodigoClienteDirecto()
        {
            string codigo = txtcedula.Text;
            string tipo = "C";
            cargarDatosCliente(codigo);
            if (txtcedula.Text == "")
            {
                if (MessageBox.Show("El cliente no existe desea registarlo ? ", "Creacion de cliente nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    directMnt.CreaCliAlex express = new directMnt.CreaCliAlex();
                    express.IniCrearAlex(ref tipo, ref codigo);
                }
            }
            if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
        }

        private void txtcedula_Leave(object sender, EventArgs e)
        {
            KeyEventArgs ee = new KeyEventArgs(Keys.Return);
            txtcedula_KeyDown(sender, ee);
        }
    }
}