using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDoc;
using DattCom;
using DctosEmi;

namespace leeDocXml
{
    public partial class frmLeDocxml : Form
    {
        AdcDoc class_AdcDoc = new AdcDoc();
        AdcTra class_AdcTra = new AdcTra();
        AdcSri class_AdcSri = new AdcSri();
        XmlDocument xmlDocAutorizado = new XmlDocument();
        XmlDocument docDocumento = new XmlDocument();
        Boolean crearProveedor = false;
        Boolean cambioTipoIva = false;
        Int16 proceso = 0;  // 0 sin importación    1 importando  
        Int16 tipoDocumento = 0; // 0 importando factura     1 importando retencion
        string tipoIdentificacion = "";
        string tipDocXml = "FAP";
        string tipoDocEnAdcom = "FAP";
        public frmLeDocxml()
        {
            InitializeComponent();
            llenarBodegaLocal();
            llenarComboDocumentos("FAP"); 
            Botones();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            crearProveedor = false;
            buscaArchivos.ShowDialog();
            string archivo = buscaArchivos.FileName;
            if (archivo.Length > 0)
            {
                mallaReferencia.Columns.Clear();
                class_AdcDoc = new AdcDoc(datosEmpresa.strConxAdcom);
                class_AdcTra = new AdcTra(datosEmpresa.strConxAdcom);
                class_AdcSri = new AdcSri(datosEmpresa.strConxAdcom);
                string comprobante = leerDocumentoXML(archivo, xmlDocAutorizado, class_AdcDoc);
                if (comprobante.Length > 20)
                {
                    docDocumento.LoadXml(comprobante);
                    XmlNode child=null;
                    tipDocXml = TipoDocumento(docDocumento, ref child);

                    if (tipDocXml == "FAP") importarFactura(child);
                    else if (tipDocXml == "RTC") importarRetencionCliente(child);
                }
            }}


        private void importarFactura(XmlNode child)
        {
            cmbBodegaAdcom.Visible = true;
            if (tipoDocEnAdcom != tipDocXml) llenarComboDocumentos("FAP");

            impFac.importaInfTributariaFactura(child, class_AdcDoc, ref tipoIdentificacion);
            if (existeDocumento(class_AdcDoc)) { return; }

            proceso = 1;
            Botones();

            impFac.importaInfFactura(docDocumento, class_AdcDoc, mallaReferencia);
            impFac.ImportarEmailAdicional(docDocumento, class_AdcDoc);

            diseñaMalla.construirMalla(mallaReferencia);
            visualizarCabezeraDocumento(class_AdcDoc);
            impFac.importaDetallesFactura(docDocumento, class_AdcTra, class_AdcDoc, mallaReferencia);

            // ✅ CALCULAR TOTALES POR TIPO DESPUÉS DE IMPORTAR DETALLES
            impFac.CalcularTotalesPorTipo(class_AdcDoc, mallaReferencia);

            // ✅ RECALCULAR TOTALES GENERALES
            CalcularTotalesGenerales(class_AdcDoc);

            validacion val = new validacion();
            DaxDocProov docprov = new DaxDocProov(datosEmpresa.strConxAdcom);
            docprov = DaxDocProov.Buscar(" idProveedor = '" + class_AdcDoc.Doc_codper.ToString() + "' and idDocProveedor = '" + class_AdcDoc.Adi_TipoDocSri + "'");
            val.validarFactura(mallaReferencia, docprov);
        }

        private void CalcularTotalesGenerales(AdcDoc class_AdcDoc)
        {            

            // ✅ REDONDEAR TODOS LOS CAMPOS A 2 DECIMALES
            class_AdcDoc.Doc_totciva = Math.Round(class_AdcDoc.Doc_totciva, 2);
            class_AdcDoc.Doc_totsiva = Math.Round(class_AdcDoc.Doc_totsiva, 2);
            class_AdcDoc.Doc_valoriva = Math.Round(class_AdcDoc.Doc_valoriva, 2);
            class_AdcDoc.Doc_valor = Math.Round(class_AdcDoc.Doc_valor, 2);
            class_AdcDoc.Doc_TotArtCIva = Math.Round(class_AdcDoc.Doc_TotArtCIva, 2);
            class_AdcDoc.Doc_TotArtSIva = Math.Round(class_AdcDoc.Doc_TotArtSIva, 2);
            class_AdcDoc.Doc_TotSerCIva = Math.Round(class_AdcDoc.Doc_TotSerCIva, 2);
            class_AdcDoc.Doc_TotSerSIva = Math.Round(class_AdcDoc.Doc_TotSerSIva, 2);
            class_AdcDoc.Doc_valorabon = class_AdcDoc.Doc_valor; // ✅ Sincronizar

            // ✅ BaseImp1 = Doc_totciva (BASE IMPONIBLE)
            class_AdcDoc.BaseImp1 = class_AdcDoc.Doc_totciva;

            Console.WriteLine($"Totales generales (desde XML):");
            Console.WriteLine($"  Doc_totciva (base): {class_AdcDoc.Doc_totciva}");
            Console.WriteLine($"  Doc_valoriva (IVA): {class_AdcDoc.Doc_valoriva}");
            Console.WriteLine($"  Doc_valor (total): {class_AdcDoc.Doc_valor}");
            Console.WriteLine($"  BaseImp1: {class_AdcDoc.BaseImp1}"); // DEBE SER 25.62
        }

        private void importarRetencionCliente(XmlNode child)
        {
            cmbBodegaAdcom.Visible = false;
            if (tipoDocEnAdcom != tipDocXml) llenarComboDocumentos("RTC");
            impRtc.importaInfRetencion(docDocumento, class_AdcDoc, mallaReferencia);
            impRtc.importaInfTributariaRetencion(child, class_AdcDoc, ref tipoIdentificacion);
            diseñaMalla.construirMallaRtc(mallaReferencia);
            visualizarCabezeraDocumento(class_AdcDoc);
            if (existeDocumento(class_AdcDoc)) { return; }
            proceso = 1;
            Botones();
            //inicializarMallaDeDetalleRtc();
            impRtc.importaDetallesRetencion(docDocumento, class_AdcSri, class_AdcDoc, mallaReferencia);
            txtValorDocOrigen.Text = class_AdcDoc.Doc_valor.ToString();
            validacion val = new validacion();
            DaxDocProov docprov = new DaxDocProov(datosEmpresa.strConxAdcom);
            docprov = DaxDocProov.Buscar(" idProveedor = '" + class_AdcDoc.Doc_codper.ToString() + "' and idDocProveedor = '" + class_AdcDoc.Adi_TipoDocSri + "'");
            val.validarRetencion (mallaReferencia, docprov);
        }
        private void llenarComboDocumentos(string tipoDoc)
        {
            tipoDocEnAdcom = tipoDoc;
            string ssql = "select OPC_DOCUMENTO, OPC_DOCUMENTO + ' - ' + OPC_NOMBRE AS Detalle from ADCOPC WHERE OPC_TIPO = '" + tipoDoc + "' ORDER BY opc_documento";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDocumentosAdcom.DataSource = dt;
                cmbDocumentosAdcom.DisplayMember = "Detalle";
                cmbDocumentosAdcom.ValueMember = "opc_documento";
                cmbDocumentosAdcom.SelectedValue = tipoDoc;
            }
        }
        private void llenarBodegaLocal()
        {
            DaxCombobx.CargCmbBox combBod = new DaxCombobx.CargCmbBox();
            combBod.DaxCombosBods(datosEmpresa.suc, false, datosEmpresa.strConxSyscod, ref cmbBodegaAdcom);
            combBod = null;
        }
        private Boolean existeDocumento(AdcDoc docmto)        {
            Boolean resp = false;
            string ssql = "select doc_numero from adcdoc where doc_sucursal ='" + datosEmpresa.suc  + "' and opc_documento ='" + cmbDocumentosAdcom.SelectedValue  + "' and doc_numero = " + docmto.Doc_numero.ToString();
            ssql += " and  Doc_NroIdDoc = '" + docmto.Doc_NroIdDoc + "' and Doc_ciruc = '" + docmto.Doc_CiRuc + "' ";
            DataTable dt = AdcDoc.Tabla(ssql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("El documento a importar ya existe ","Importación de documentos XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                docmto=new AdcDoc();
                limpiar();
                resp=true;
            }
            return resp;
        }
        private string leerDocumentoXML(string nomArchivo, XmlDocument xmlDocAutorizado, AdcDoc class_AdcDoc)
        {      
            string strComprobante = "";
            try
            {
                xmlDocAutorizado.Load(nomArchivo);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("El archivo inportado no es válido " + ex.Message, "Importar Documentos XML"); 
                return ""; 
            }
            XmlNode child = xmlDocAutorizado.SelectSingleNode("/autorizacion");
            if (child == null) child = xmlDocAutorizado.ChildNodes.Item(1);
            if (child != null)
            {
                for (int i=0;i<child.ChildNodes.Count;i++)
                {
                    try
                    {
                        string mNombre = child.ChildNodes.Item(i).Name;
                        string mValor = child.ChildNodes.Item(i).InnerText;

                        switch (mNombre)
                        {
                            case "estado":
                                class_AdcDoc.estadoSri = mValor;
                                break;
                            case "numeroAutorizacion":
                                class_AdcDoc.NroAutorizacionSri = mValor;
                                class_AdcDoc.Adi_NroAutSri = mValor;
                                break;
                            case "fechaAutorizacion":
                                class_AdcDoc.fechaAutorizacion = mValor;
                                break;
                            case "comprobante":
                                strComprobante = mValor;
                                break;
                        }
                    }
                    catch { break;}
                }
            }
            return strComprobante;
        }
        private string TipoDocumento(XmlDocument xmlDocFactura, ref XmlNode child)
        {          
            child = xmlDocFactura.SelectSingleNode("/factura/infoTributaria");
            if (child != null) return "FAP";

            child = xmlDocFactura.SelectSingleNode("/comprobanteRetencion/infoTributaria");
            if (child != null) return "RTC";
            return "";
        }
        private void visualizarCabezeraDocumento(AdcDoc class_AdcDoc)
        {
            txtRuc.Text = class_AdcDoc.Doc_CiRuc;
            txtNombre.Text = class_AdcDoc.Doc_NombreImp;
            txtDocTipOrigen.Text = class_AdcDoc.Adi_TipoDocSri;
            txtDocNumeroOrigen.Text = class_AdcDoc.Doc_numero.ToString();
            txtIdRucOrigen.Text = class_AdcDoc.Doc_NroIdDoc;
            txtFechaDocOrigen.Text = class_AdcDoc.Doc_fecha.ToString("dd/MMM/yyyy");
            txtAutorizacionSriOrigen.Text = class_AdcDoc.NroAutorizacionSri;
            txtFechaAutorizacionOrigen.Text = class_AdcDoc.fechaAutorizacion;
            txtValorDocOrigen.Text = class_AdcDoc.Doc_valor.ToString("0.00");
            verificarProveedor();
            class_AdcDoc.Doc_codper = txtCodDirectorioAdcom.Text;
            class_AdcDoc.Opc_documento = cmbDocumentosAdcom.SelectedValue.ToString();
            class_AdcDoc.Doc_sucursal = datosEmpresa.suc;
            try
            {
                class_AdcDoc.Doc_Bodega = cmbBodegaAdcom.SelectedValue.ToString();
            }
            catch { }
            Botones();
        }

        //private void verificarProveedor()
        //{
        //    directMnt.DirectorioAlex dirlis = new directMnt.DirectorioAlex();
        //    string codproov = txtRuc.Text;
        //    bool CliPro = false;
        //    string SoloCodigo = "";
        //    dirlis.CargarAlex(ref codproov, ref CliPro, ref SoloCodigo);

        //    if (dirlis.codigo != null && dirlis.codigo.Length != 0)
        //    {
        //        txtCodDirectorioAdcom.Text = dirlis.codigo;
        //        txtEmail.Text = dirlis.correoElectronico;
        //        txtEmail.Enabled = false;
        //        crearProveedor = false;
        //        Console.WriteLine($"Proveedor existe: {dirlis.codigo}");
        //    }
        //    else
        //    {
        //        // ✅ GENERAR CÓDIGO SEGÚN EL TIPO DE IDENTIFICACIÓN
        //        string codigoGenerado = impFac.GenerarCodigoIdentificacion(txtRuc.Text, tipoIdentificacion);

        //        // ✅ VERIFICAR SI EL CÓDIGO GENERADO YA EXISTE
        //        if (ExisteCodigoEnDirectorio(codigoGenerado))
        //        {
        //            int contador = 1;
        //            string codigoUnico = codigoGenerado;
        //            while (ExisteCodigoEnDirectorio(codigoUnico))
        //            {
        //                codigoUnico = codigoGenerado + contador.ToString();
        //                contador++;
        //                if (contador > 99) break;
        //            }
        //            txtCodDirectorioAdcom.Text = codigoUnico;
        //            Console.WriteLine($"Código {codigoGenerado} ya existe, usando {codigoUnico}");
        //        }
        //        else
        //        {
        //            txtCodDirectorioAdcom.Text = codigoGenerado;
        //        }

        //        txtEmail.Enabled = true;
        //        crearProveedor = true;

        //        Console.WriteLine($"Nuevo proveedor: Código={txtCodDirectorioAdcom.Text}, ID={txtRuc.Text}, Tipo={tipoIdentificacion}");
        //    }
        //}

        private void verificarProveedor()
        {
            directMnt.DirectorioAlex dirlis = new directMnt.DirectorioAlex();
            string codproov = txtRuc.Text;
            bool CliPro = false;
            string SoloCodigo = "";
            dirlis.CargarAlex(ref codproov, ref CliPro, ref SoloCodigo);

            if (dirlis.codigo != null && dirlis.codigo.Length != 0)
            {
                txtCodDirectorioAdcom.Text = dirlis.codigo;
                txtEmail.Text = dirlis.correoElectronico;
                txtEmail.Enabled = false;
                crearProveedor = false;
                Console.WriteLine($"✅ Proveedor existe: {dirlis.codigo}");
            }
            else
            {
                // ✅ GENERAR CÓDIGO SEGÚN EL TIPO DE IDENTIFICACIÓN
                string codigoGenerado = impFac.GenerarCodigoIdentificacion(txtRuc.Text, tipoIdentificacion);

                // ✅ VERIFICAR SI EL CÓDIGO GENERADO YA EXISTE (por si acaso)
                if (ExisteCodigoEnDirectorio(codigoGenerado))
                {
                    // ✅ EL CÓDIGO YA EXISTE - USARLO (no crear nuevo)
                    txtCodDirectorioAdcom.Text = codigoGenerado;
                    txtEmail.Enabled = false;
                    crearProveedor = false;  // ✅ NO CREAR NUEVO
                    Console.WriteLine($"✅ Código ya existe, usando: {codigoGenerado}");
                }
                else
                {
                    txtCodDirectorioAdcom.Text = codigoGenerado;
                    txtEmail.Enabled = true;
                    crearProveedor = true;
                    Console.WriteLine($"📌 Nuevo proveedor: Código={txtCodDirectorioAdcom.Text}, ID={txtRuc.Text}, Tipo={tipoIdentificacion}");
                }
            }
        }

        private bool ExisteCodigoEnDirectorio(string codigo)
        {
            try
            {
                string ssql = "SELECT COUNT(*) FROM Identificacion WHERE Codigo = '" + codigo + "'";
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(ssql, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

      
        public static string ObtenerPrefijoSegunTipo(string tipoId)
        {
            switch (tipoId)
            {
                case "04": return "R";  // RUC
                case "05": return "C";  // Cédula
                case "06": return "P";  // Pasaporte
                default: return "R";    // Por defecto RUC
            }
        }
        private void mallaReferencia_KeyDown(object sender, KeyEventArgs e)
          {
              if (mallaReferencia.CurrentCell == null) return;
              string colName = mallaReferencia.Columns[mallaReferencia.CurrentCell.ColumnIndex].Name;
              if (colName == "codProductoPropio")
              {
                  if (e.KeyCode == Keys.F2)
                  {
                      mallaReferencia.CurrentCell.Value = buscaArticulo();
                      cargarDatosArticulo(mallaReferencia.CurrentCell);
                  }
                  else if (e.KeyCode == Keys.F3)
                  {
                      mallaReferencia.CurrentCell.Value = buscaConcepto();
                      cargarDatosConcepto(mallaReferencia.CurrentCell);
                  }
                  else if (e.KeyCode == Keys.F5)
                  {
                      copiarValoresAitems();
                  }
              }
              else if (colName == "tipoRetencion")
              {
                  if (e.KeyCode == Keys.F2)
                  {
                      if ( mallaReferencia.CurrentCell.Value.ToString().Substring(0,6) == "Fuente") return;
                      else if (mallaReferencia.CurrentCell.Value.ToString() == "IvaBienes") mallaReferencia.CurrentCell.Value = "IvaServicios";
                      else mallaReferencia.CurrentCell.Value = "IvaBienes";
                      cambioTipoIva = true;
                  }
              }
              else if (colName == "ConceptoProducto")
              {
                  if (e.KeyCode == Keys.F2)
                  {
                      if (mallaReferencia.CurrentCell.Value == null) mallaReferencia.CurrentCell.Value = "Producto";
                      else if (mallaReferencia.CurrentCell.Value.ToString() == "Concepto") mallaReferencia.CurrentCell.Value = "Producto";
                      else mallaReferencia.CurrentCell.Value = "Concepto";
                  }
              }
              else if (colName == "usarDetalle")
              {
                  if (e.KeyCode == Keys.F2)
                  {
                      if (mallaReferencia.CurrentCell.Value == null) mallaReferencia.CurrentCell.Value = "Catálogo";
                      else if (mallaReferencia.CurrentCell.Value.ToString() == "Proveedor") cambiarDetalle("Catálogo",mallaReferencia.CurrentCell);
                      else if (mallaReferencia.CurrentCell.Value.ToString() == "Catálogo") cambiarDetalle("Otro", mallaReferencia.CurrentCell);
                      else cambiarDetalle("Proveedor", mallaReferencia.CurrentCell);
                  }
                  else if (e.KeyCode == Keys.F5)
                  {
                      copiarValoresAitems();
                  }
              }
          }
          private string buscaArticulo()
          {
              string ssql = "select art_codigo,art_nombre from adcart order by art_nombre";
              Buscar.frmBuscar busca = new Buscar.frmBuscar();
              string codigo = "";
              try{
              codigo = busca.Buscar(datosEmpresa.strConxAdcom, ssql, "art_codigo", "art_nombre", "", "Buscar artículos propios", "");}
              catch{}
              return codigo;
          }
        private void copiarValoresAitems()
          {
            if (mallaReferencia.Rows.Count < 1)    return;
            DataGridViewRow rowo = mallaReferencia.Rows[0];
            DataGridViewRow rowd;
            for (int i = 1; i < mallaReferencia.Rows.Count;i++)
            {
                rowd = mallaReferencia.Rows[i];
                rowd.Cells["codProductoPropio"].Value = rowo.Cells["codProductoPropio"].Value;
                rowd.Cells["ConceptoProducto"].Value = rowo.Cells["ConceptoProducto"].Value;
                rowd.Cells["usarDetalle"].Value = rowo.Cells["usarDetalle"].Value;
            }
          }
        private void cargarDatosArticulo(DataGridViewCell celda)
          {
              EmpNomR.AdcNomb nom = new EmpNomR.AdcNomb();
              string nombre = nom.RetornaNombreArticulo(celda.Value.ToString(), datosEmpresa.strConxAdcom);
              mallaReferencia.Rows[celda.RowIndex].Cells["DetalleCatalogo"].Value=nombre;
              mallaReferencia.Rows[celda.RowIndex].Cells["ConceptoProducto"].Value = "Producto";
              mallaReferencia.Rows[celda.RowIndex].Cells["usarDetalle"].Value = "Catálogo";
              mallaReferencia.Rows[celda.RowIndex].Cells["DetalleAutilizar"].Value = nombre;
        }

        private string buscaConcepto()
          {
              string ssql = "select sev_codigo,sev_nombre from adcserv where sev_compras = 1";
              Buscar.frmBuscar busca = new Buscar.frmBuscar();
              string codigo = "";
              try
              {
                  codigo = busca.Buscar(datosEmpresa.strConxAdcom, ssql, "sev_codigo", "sev_nombre", "", "Buscar Conceptos propios", "");
              }
              catch { }
              return codigo;
          }
          private void cargarDatosConcepto(DataGridViewCell celda)
          {
              EmpNomR.AdcNomb nom = new EmpNomR.AdcNomb();
              string nombre = nom.RetornaNombreServicio(celda.Value.ToString(), datosEmpresa.strConxAdcom);
              mallaReferencia.Rows[celda.RowIndex].Cells["DetalleCatalogo"].Value = nombre;
              mallaReferencia.Rows[celda.RowIndex].Cells["ConceptoProducto"].Value = "Concepto";
              mallaReferencia.Rows[celda.RowIndex].Cells["usarDetalle"].Value = "Catálogo";
              mallaReferencia.Rows[celda.RowIndex].Cells["DetalleAutilizar"].Value = nombre;
        }

          private void mallaReferencia_CellEndEdit(object sender, DataGridViewCellEventArgs e)
          {
              if (mallaReferencia.Columns[e.ColumnIndex].Name == "DetalleAutilizar")
              {
                  mallaReferencia.Rows[e.RowIndex].Cells["usarDetalle"].Value = "Otro";
                  mallaReferencia.Rows[e.RowIndex].Cells["detalleOtro"].Value = mallaReferencia.Rows[e.RowIndex].Cells["DetalleAutilizar"].Value;
              }
          }
            private void cambiarDetalle(string uso, DataGridViewCell celda)
          {
              if (uso == "Otro") 
              { 
              mallaReferencia.Rows[celda.RowIndex].Cells["DetalleAutilizar"].Value = mallaReferencia.Rows[celda.RowIndex].Cells["detalleOtro"].Value;}
              else if (uso == "Catálogo") mallaReferencia.Rows[celda.RowIndex].Cells["DetalleAutilizar"].Value = mallaReferencia.Rows[celda.RowIndex].Cells["DetalleCatalogo"].Value;
              else if (uso == "Proveedor") mallaReferencia.Rows[celda.RowIndex].Cells["DetalleAutilizar"].Value = mallaReferencia.Rows[celda.RowIndex].Cells["DetalleProveedor"].Value;
              mallaReferencia.Rows[celda.RowIndex].Cells["usarDetalle"].Value = uso;
          }
            private void btnCancela_Click(object sender, EventArgs e)
            {
                limpiar();
            }
            private void limpiar()
            {
                mallaReferencia.Rows.Clear();
                txtAutorizacionSriOrigen.Text = "";
                txtCodDirectorioAdcom.Text = "";
                txtDocNumeroOrigen.Text = "";
                txtDocTipOrigen.Text = "";
                txtFechaAutorizacionOrigen.Text = "";
                txtFechaDocOrigen.Text = "";
                txtIdRucOrigen.Text = "";
                txtNombre.Text = "";
                txtRuc.Text = "";
                txtValorDocOrigen.Text = "";                
                proceso = 0;
                cambioTipoIva = false;
                Botones();
            }

            private void btnProcesar_Click(object sender, EventArgs e)
            {
            if (crearProveedor)
            {
                if (txtCodDirectorioAdcom.Text.Length == 0)
                {
                    MessageBox.Show("Error: No se ha definido el código del Directorio",
                                    "Creación de registro en directorio",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    crearDirectorio.grabarRegistro(txtRuc.Text, txtNombre.Text, txtCodDirectorioAdcom.Text,
                                                    class_AdcDoc.Doc_Direccion, txtEmail.Text,
                                                    tipoDocumento, tipoIdentificacion);
                    crearProveedor = false;

                    // ✅ RECARGAR EL CÓDIGO DEL PROVEEDOR DESPUÉS DE CREAR/ACTUALIZAR
                    verificarProveedor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear/actualizar proveedor: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // RECALCULAR TOTALES ANTES DE GUARDAR
            CalcularTotalesPorTipo(class_AdcDoc, mallaReferencia);

            if (tipDocXml == "FAP")
                {
                    if (chkTodosCodigoIgual.Checked) AgruparCodigosIguales();
                    guardarReglas.guardarFap(chkAgruparItems.Checked, txtDocTipOrigen.Text, txtCodDirectorioAdcom.Text, cmbDocumentosAdcom.SelectedValue.ToString(), mallaReferencia, chkTodosCodigoIgual.Checked);
                    guardarDocumento.guardarAdcDOc(class_AdcDoc);
                    guardarDocumento.guardarAdcTra(class_AdcDoc, class_AdcTra, mallaReferencia, datosEmpresa.strConxAdcom);

                // ✅ ABRIR LA FACTURA EN EL FORMULARIO DE FACTURA DE PROVEEDOR
                try
                {
                    // Crear un objeto idDocumento con los datos de la factura recién guardada
                    idDocumento idDoc = new idDocumento
                    {
                        Sucursal = class_AdcDoc.Doc_sucursal,
                        Tipo = class_AdcDoc.Opc_documento,
                        idClave = Convert.ToDouble(class_AdcDoc.IdClaveDoc),
                        numero = Convert.ToDouble(class_AdcDoc.Doc_numero),
                        fecha = class_AdcDoc.Doc_fecha
                    };

                    string tipdef = cmbDocumentosAdcom.SelectedValue?.ToString();
                    if (string.IsNullOrEmpty(tipdef))
                    {
                        tipdef = "FAP"; // Valor por defecto
                    }

                    // Abrir el formulario FormFactProveedor en modo CONSULTA
                    // ✅ CORRECTO: usa los nombres correctos de parámetro
                    FormFactProveedor frmFactura = new FormFactProveedor(clasdef: "FAP", tipdef,  nuevo: false, esConsulta: true, idDocViene: idDoc,sisMedico: "", desdeImportadorXml: true);

                    frmFactura.Show(); // o ShowDialog() si quieres modal
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir la factura: " + ex.Message,
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }

            else if (tipDocXml == "RTC")
                {
                    string msg = validarTipoRetencion(class_AdcSri);
                    if (msg!="")
                    {
                        MessageBox.Show("Existen errores en la Retención no se puede guardar \n"  + msg);
                        return;
                    }
                    guardarReglas.guardarRtc(chkAgruparItems.Checked, txtDocTipOrigen.Text, txtCodDirectorioAdcom.Text, cmbDocumentosAdcom.SelectedValue.ToString(), mallaReferencia, chkTodosCodigoIgual.Checked);

                    class_AdcDoc.Doc_DocSop = class_AdcSri.codDocSustentoAdcom;
                    class_AdcDoc.Doc_NumSop = Convert.ToDecimal(class_AdcSri.numDocSustento);
                    class_AdcDoc.IdClaveDocSop = class_AdcSri.IdClaveDocSustento;
                    
                    guardarDocumento.guardarAdcDOc(class_AdcDoc);
                    if (cambioTipoIva) { ReorganizaRegistroRetencion();}
                    guardarDocumento.guardarAdcSri(class_AdcSri, class_AdcDoc);
                    if (class_AdcSri.IdClaveDoc > 0)
                    {

                    }                    
                   
                }
                limpiar();
                
            }
            
            

            private void AgruparCodigosIguales()
            {
                decimal unidades = 0;
                decimal valores = 0;

                foreach (DataGridViewRow row in  mallaReferencia.Rows)
                {
                    unidades += Convert.ToDecimal(row.Cells["cantidad"].Value);
                    valores += Convert.ToDecimal(row.Cells["PvUni"].Value) * Convert.ToDecimal(row.Cells["cantidad"].Value);
                }
                foreach (DataGridViewRow row in mallaReferencia.Rows)
                {
                    if (row.Index == 0)
                    {
                        if (!chkSumarItems.Checked) unidades = 1;
                        if (unidades == 0) unidades = 1;
                        row.Cells["PvUni"].Value = valores/unidades;
                    }
                    else
                    {
                        mallaReferencia.Rows.Remove(row);
                    }
                }
            }

            private void ReorganizaRegistroRetencion()
            {
                        class_AdcSri.BaseIvaBienes = 0;
                        class_AdcSri.CodigoRetIvaBienes = "";
                        class_AdcSri.PorRetIvaBienes = 0;
                        class_AdcSri.ValorRetIvaBienes = 0;
                        class_AdcSri.BaseIvaServicios  = 0;
                        class_AdcSri.CodigoRetIvaServicios = "";
                        class_AdcSri.PorRetIvaServicios = 0;
                        class_AdcSri.ValorRetIvaServicios = 0;
                foreach (DataGridViewRow row in mallaReferencia.Rows)
                {
                    if (row.Cells["tipoRetencion"].Value.ToString()=="IvaBienes")
                    {
                        class_AdcSri.BaseIvaBienes = Convert.ToDecimal("0" + row.Cells["baseImponible"].Value);
                        class_AdcSri.CodigoRetIvaBienes = row.Cells["codigoRetencion"].Value.ToString();
                        class_AdcSri.PorRetIvaBienes = Convert.ToDecimal("0" + row.Cells["PorcentajeRetener"].Value.ToString());
                        class_AdcSri.ValorRetIvaBienes = Convert.ToDecimal("0" + row.Cells["ValRetenido"].Value);
                    }
                    else if (row.Cells["tipoRetencion"].Value.ToString() == "IvaServicios")
                    {
                        class_AdcSri.BaseIvaServicios  = Convert.ToDecimal("0" + row.Cells["baseImponible"].Value);
                        class_AdcSri.CodigoRetIvaServicios = row.Cells["codigoRetencion"].Value.ToString();
                        class_AdcSri.PorRetIvaServicios = Convert.ToDecimal("0" + row.Cells["PorcentajeRetener"].Value.ToString());
                        class_AdcSri.ValorRetIvaServicios = Convert.ToDecimal("0" + row.Cells["ValRetenido"].Value);
                    }
                }
            }


            //malla.Columns.Add("tipoRetencion", "tipRetencion");
            //malla.Columns.Add("codigoRetencion", "codRet");
            //malla.Columns.Add("baseImponible", "baseImponible");
            //malla.Columns.Add("PorcentajeRetener", "%");
            //malla.Columns.Add("valorRetenido", "ValRetenido");
            //malla.Columns.Add("codDocSustento", "TipDocRetSri");
            //malla.Columns.Add("tipoDocumentAdcom", "TipDocRetAdcom");
            //malla.Columns.Add("numDocSustento", "NroDocmtoRet");
            //malla.Columns.Add("fechaEmisionDocSustento", "FechaDocRet");

            private string validarTipoRetencion(AdcSri class_AdcSri)
            {

                if (class_AdcSri.BaseIvaBienes == 0 && class_AdcSri.BaseIvaServicios == 0 && class_AdcSri.BaseRetFuente == 0 && class_AdcSri.BaseRetFuente1 == 0) return " NO hay valores retenidos ";
                foreach (DataGridViewRow row in mallaReferencia.Rows)
                {
                    if (row.Cells["tipoDocumentAdcom"].Value.ToString().Length > 5) return " Tipo de documento en Sistema Adcom errado \n" + row.Cells["tipoDocumentAdcom"].Value .ToString();
                }

                return "";
            }
            private void btnDirectorioExpress_Click(object sender, EventArgs e)
            {
            directMnt.CreaCliAlex calex = new directMnt.CreaCliAlex();
                string tipo = "P";
                string codIni =txtCodDirectorioAdcom.Text;
                calex.codigo.Text = txtCodDirectorioAdcom.Text;
                calex.ruc.Text =
                calex.IniCrearAlex(ref tipo, ref codIni);
                verificarProveedor();
                Botones();
            }
            private void Botones()
            {
                btnDirectorio.Enabled = (proceso == 1 & crearProveedor);
                btnDirectorioExpress.Enabled = btnDirectorio.Enabled;
                txtCodDirectorioAdcom.Enabled = btnDirectorio.Enabled;
                btnImportar.Enabled = (proceso == 0);
                btnProcesar.Enabled = (proceso == 1);
                btnCancela.Enabled = (proceso == 1);
                btnSalir.Enabled = true;                
            }

            private void btnDirectorio_Click(object sender, EventArgs e)
            {
            directMnt.DEEP01  mandir = new directMnt.DEEP01();
                string codIni = txtCodDirectorioAdcom.Text;
                mandir.QUECODIGO = codIni;
                mandir.IniciaNuevo();
                verificarProveedor();
                Botones();
            }

            private void btnDocumento_Click(object sender, EventArgs e)
            {
                conexionDocumentos.presentarDocumentoFactura("QUI", cmbDocumentosAdcom.SelectedValue.ToString(), "2653", 671);
            }

            private void btnSalir_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnMantProducto_Click(object sender, EventArgs e)
            {
                DaxInvent.DaxInventarios.MantenimientoArticulos();
            }

            private void cmbDocumentos_SelectedIndexChanged(object sender, EventArgs e)
            {
                class_AdcDoc.Opc_documento = cmbDocumentosAdcom.SelectedValue.ToString();
                class_AdcTra.Opc_documento = cmbDocumentosAdcom.SelectedValue.ToString();
            }

            private void chkSumarItems_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void chkTodosCodigoIgual_CheckedChanged(object sender, EventArgs e)
            {
                chkAgruparItems.Visible = chkTodosCodigoIgual.Checked;
                chkSumarItems.Visible = chkTodosCodigoIgual.Checked;
            }

        public static void CalcularTotalesPorTipo(AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            try
            {
                decimal totArtCIva = 0;
                decimal totArtSIva = 0;
                decimal totSerCIva = 0;
                decimal totSerSIva = 0;

                // 📋 PRIMERA PASADA: Calcular subtotales redondeados
                foreach (DataGridViewRow row in mallaReferencia.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Cantidad"].Value == null || row.Cells["PvUni"].Value == null) continue;

                    decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["PvUni"].Value);

                    // ✅ SUBTOTAL REDONDEADO A 2 DECIMALES
                    decimal subtotal = Math.Round(cantidad * precioUnitario, 2);

                    bool tieneIva = false;
                    if (row.Cells["iva"].Value != null)
                    {
                        if (row.Cells["iva"].Value is bool)
                            tieneIva = (bool)row.Cells["iva"].Value;
                        else
                            bool.TryParse(row.Cells["iva"].Value.ToString(), out tieneIva);
                    }

                    string tipoProducto = row.Cells["ConceptoProducto"]?.Value?.ToString() ?? "Producto";
                    bool esArticulo = (tipoProducto.ToUpper() == "PRODUCTO" || tipoProducto.ToUpper() == "A");

                    if (esArticulo)
                    {
                        if (tieneIva) totArtCIva += subtotal;
                        else totArtSIva += subtotal;
                    }
                    else
                    {
                        if (tieneIva) totSerCIva += subtotal;
                        else totSerSIva += subtotal;
                    }
                }

                // ✅ REDONDEAR A 2 DECIMALES
                class_AdcDoc.Doc_TotArtCIva = Math.Round(totArtCIva, 2);
                class_AdcDoc.Doc_TotArtSIva = Math.Round(totArtSIva, 2);
                class_AdcDoc.Doc_TotSerCIva = Math.Round(totSerCIva, 2);
                class_AdcDoc.Doc_TotSerSIva = Math.Round(totSerSIva, 2);

                Console.WriteLine("\n=== TOTALES POR TIPO DE PRODUCTO ===");
                Console.WriteLine($"  Artículos CON IVA: {class_AdcDoc.Doc_TotArtCIva:F2}");
                Console.WriteLine($"  Artículos SIN IVA: {class_AdcDoc.Doc_TotArtSIva:F2}");
                Console.WriteLine($"  Servicios CON IVA: {class_AdcDoc.Doc_TotSerCIva:F2}");
                Console.WriteLine($"  Servicios SIN IVA: {class_AdcDoc.Doc_TotSerSIva:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en CalcularTotalesPorTipo: {ex.Message}");
            }
        }

        private void mallaReferencia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && proceso == 1)
            {
                string colName = mallaReferencia.Columns[e.ColumnIndex].Name;

                // Si cambian campos que afectan totales
                if (colName == "Cantidad" || colName == "PvUni" || colName == "iva" ||
                    colName == "ConceptoProducto")
                {
                    // Recalcular totales por tipo
                    CalcularTotalesPorTipo(class_AdcDoc, mallaReferencia);

                    // Actualizar visualización si es necesario
                    txtValorDocOrigen.Text = class_AdcDoc.Doc_valor.ToString("0.00");
                }
            }
        }

		private void frmLeDocxml_Load(object sender, EventArgs e)
		{

		}
	}
}

