using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassDoc;
using DaxDocElectronicos;
using DattCom;
using ClassDaxMail;
using documentosPdf;
using leeDocXml;
using ImpresionDocumentosDax;
using sesSys;
using SolicitudAutSRI;
using DctosEmi;
using System.Net.Mail;
using System.Net;
using SesFelec;

namespace DaxCelec
{
    public partial class FrmDaxCelec : Form
    {
        public FrmDaxCelec()
        {
            InitializeComponent();
        }
        private idDocumento IdDocumento = new idDocumento();
        private string queClaveSRI = "";
        private string queCodigoCliente = "";
        private DateTime queFecha = DateTime.Now;
        private string queClase;
        //private string String3 = "";
        private string PathFile = "";
        private string strConxadcom = "";
        private string strConxIvaret = "";
        private string strConxDaxsys = "";
        private string strConxDaxpro = "";
        private string correoElectronico = "";
        private string correoElectronico2 = "";
        private string nombreCliente = "";
        private string correoElectronicoDefecto = "";
        private short tipoEmision = 0;
        private string Errores = "";
        private string idTributario = "";
        private List<string> colecError = new List<string>();
        //private bool EsOnLine = false;
        private AdcFelec fel;
        public string urlE = "";
        Auxiliares aux = new Auxiliares();

        private string getXML()
        {
            string getXMLRet = "";
            var open = new OpenFileDialog();
            string retVal = string.Empty;
            // --------------------------------------------------------------------------------------------
            open.Filter = "Archivos XML(*.xml)|*.xml";
            // --------------------------------------------------------------------------------------------
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                PathFile = open.FileName;
                retVal = open.SafeFileName;
            }
            // --------------------------------------------------------------------------------------------
            getXMLRet = retVal;
            // --------------------------------------------------------------------------------------------
            open = null;
            return getXMLRet;
        }

       

        private void btnAbre_Click(object sender, EventArgs e)
        {
            var progBus = new BuscadorDocumentos.buscadorDoc();
            // MsgBox(Application.StartupPath())        
            progBus.IniciaBusqueda("ELE", "", "", queFecha, ref IdDocumento.Sucursal, ref IdDocumento.Tipo, ref IdDocumento.numero, ref IdDocumento.idClave, false, "", "", "", "ADCDOC");
            mensaje.Text = "";
            leerDocumentoAdcom();
        }

        private void leerDocumentoAdcom()
        {
            var progdoc = new AdcDoc(datosEmpresa.strConxAdcom);
            var dt = new DataTable();
            string ssql = "SELECT AdcDoc.*, Identificacion.CorreoElectrónico as correo1, Identificacion.Paginaweb as correo2 FROM Adcdoc ";
            ssql += " LEFT OUTER JOIN Identificacion ON AdcDoc.Doc_codper = Identificacion.Codigo ";
            if (IdDocumento.idClave == 0d && queClaveSRI.Length > 0)
            {
                ssql += " WHERE clavesri = '" + queClaveSRI + "' ";
            }
            else
            {
                ssql += " WHERE doc_sucursal = '" + IdDocumento.Sucursal + "' and opc_documento = '" + IdDocumento.Tipo + "' and idclavedoc = " + IdDocumento.idClave.ToString();
            }

            dt = SqlDatos.leerTablaAdcom(ssql);
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("No existe el documento seleccionado");
                return;
            }

            IdDocumento.Sucursal = dt.Rows[0]["Doc_sucursal"].ToString();
            IdDocumento.Tipo = dt.Rows[0]["opc_documento"].ToString();
            IdDocumento.idClave = Convert.ToDouble(dt.Rows[0]["IdclaveDoc"]);
            IdDocumento.numero = Convert.ToDouble(dt.Rows[0]["Doc_numero"].ToString());
            queClase = dt.Rows[0]["doc_tipodoc"].ToString();
            queClaveSRI = dt.Rows[0]["claveSri"].ToString();
            LabCiRuc.Text = dt.Rows[0]["Doc_CiRuc"].ToString();
            LabClave.Text = dt.Rows[0]["claveSri"].ToString();
            LabEstado.Text = dt.Rows[0]["estadoSri"].ToString();
            LabFechaAutoriza.Text = dt.Rows[0]["fechaAutorizacion"].ToString();
            LabId.Text = dt.Rows[0]["Doc_nroiddoc"].ToString();
            LabNombre.Text = dt.Rows[0]["Doc_nombreImp"].ToString();
            LabNumero.Text = dt.Rows[0]["Doc_numero"].ToString();
            LabNumeroAutoriza.Text = dt.Rows[0]["nroAutorizacionSri"].ToString();
            LabTipo.Text = dt.Rows[0]["opc_documento"].ToString();
            queCodigoCliente = dt.Rows[0]["Doc_codper"].ToString();
            nombreCliente = dt.Rows[0]["Doc_NombreImp"].ToString();
            correoElectronico = dt.Rows[0]["Correo1"].ToString();
            correoElectronico2 = dt.Rows[0]["Correo2"].ToString();
            idTributario = dt.Rows[0]["Doc_NroIdDoc"].ToString();
            dt.Dispose();
            progdoc = null;
            configurarBotones();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            strConxadcom = datosEmpresa.strConxAdcom;
            strConxIvaret = datosEmpresa.strConxIvaret;
            strConxDaxsys = datosEmpresa.strConIniSis;
            strConxDaxpro = datosEmpresa.strConxDaxpro;
            if (datosEmpresa.Emp_codigo == 0)
                Close();
            fel = new AdcFelec(strConxadcom);
            fel = AdcFelec.Buscar("");
            IdDocumento.Sucursal = datosEmpresa.suc;
            revisarFacturas(strConxadcom);
            configurarBotones();
            ConfiguracionCorreo.CargarConfiguracion(datosEmpresa.strConIniSis);
            ConfiguracionCorreo.CargarParametroSRI(datosEmpresa.strConIniSis, datosEmpresa.Emp_codigo);
        }

        private void revisarFacturas(string strAdcom)
        {
            using (var conn = new SqlConnection(strAdcom))
            {
                conn.Open();
                using (var comm = new SqlCommand("dax_setIdSri " + datosEmpresa.Emp_codigo.ToString() + ",'" + datosEmpresa.suc + "'", conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }

        private void activarContingencia()
        {
            var rs = new DataTable();
            string ssql = "select top(1) clavecontigencia from adcclavcontg where utidoctipo = '' and clavecontigencia > '' ";
            var da = new SqlDataAdapter(ssql, strConxadcom);
            da.Fill(rs);
            if (rs.Rows.Count == 0)
                chkOnLine.Visible = false;
            else
                chkOnLine.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void firmarDocumento()
        {
            // firmar comprobante
            if (string.IsNullOrEmpty(queClaveSRI))
            {
                queClaveSRI = getXML().ToUpper();
                queClaveSRI = queClaveSRI.Replace(".XML", "");
            }

            if (string.IsNullOrEmpty(queClaveSRI)) return;
            mensaje.Text = "";
            //leerDocumentoAdcom();
            var FM = new Firma();
            FM.strFileXml = queClaveSRI;
            string resp = FM.FirmarArchivoXML(strConxadcom);
            MessageBox.Show(resp);
            FM=null;
            leerDocumentoAdcom();
        }
       

        private bool valida()
        {
            bool resp = true;
            if (IdDocumento.idClave == 0d | string.IsNullOrEmpty(IdDocumento.Tipo))
            {
                MessageBox.Show("Debe abrir un documento para utilizar esta opción", "Operación con factura electronica");
                resp = false;
            }

            return resp;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            classDatEmp.cargarDatosDeNuestraEmpresa(datosEmpresa.Emp_RUC,datosEmpresa.strConxAdcom);
            if (!valida())
                return;
            var genxml = new GenerarDocumentoXML();
            tipoEmision = 1;
            //if (chkOnLine.Checked == true) EsOnLine = true;
            string queClave = genxml.documentoAenviar(IdDocumento.Sucursal, IdDocumento.Tipo, IdDocumento.numero.ToString(), IdDocumento.idClave, ref PathFile, queClase, datosEmpresa.Emp_RUC, datosEmpresa.Par_DigitosPrecios, datosEmpresa.pathAppl, tipoEmision, chkOnLine.Checked);

            if (queClave.Substring(0, 5).ToUpper() == "ERROR")
            {
                MessageBox.Show("EXISTEN ERRORES EN EL DOCUMENTO: " + queClave.Substring(5));
                publicarMensaje(PathFile.Replace("XML", "ERR"));
            }
            else
            {
                queClaveSRI = queClave;
                firmarDocumento();
                //PrepararEnvios(queClase);
            }
            mensaje.Text = "";
            leerDocumentoAdcom();
        }

        private void PrepararEnvios(string TipoDoc)
        {
            string nombrePdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";
            string FormaImpresionDocumento = "FEL" + TipoDoc;
            var PROG = new documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret,datosEmpresa.strConxAdcom ,datosEmpresa.strConxIvaret,datosEmpresa.strConIniSis ,datosEmpresa.strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
            PROG.GeneraDocPdf(IdDocumento, nombrePdf, "", FormaImpresionDocumento);
            PROG = null;
        }

        
        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(queClaveSRI))
            {
                queClaveSRI = getXML().ToUpper();
                queClaveSRI = queClaveSRI.Replace(".XML", "");
            }
            urlE = ConfiguracionCorreo.UrlSRI;

            AutorizarDocumento(urlE);           
        }

        private void GenerarRide(string urlEs)
        {
            string imageBase64 = Convert.ToBase64String(File.ReadAllBytes(datosEmpresa.Emp_PathImagenes + "logoempresa.jpg"));

            //string imageBase64 = "";

            try
            {
                string ruta = Path.Combine(datosEmpresa.Emp_PathImagenes, "logoempresa.jpg");

                if (File.Exists(ruta))
                {
                    imageBase64 = Convert.ToBase64String(File.ReadAllBytes(ruta));
                }
            }
            catch
            {
                imageBase64 = ""; // Si falla por red o permisos
            }

            // 1. Ejecutar el procedimiento para obtener los datos
            var resultado = aux.EjecutarProcedimientoCabeceraYDetalle((int)IdDocumento.idClave, IdDocumento.Sucursal, IdDocumento.Tipo, (decimal)IdDocumento.numero);
            try
            {
                int codigoPag;
                bool parseado = int.TryParse(resultado._Pag_Autoriza, out codigoPag);
                string formaPagoDescripcion = aux.formasDePago.FirstOrDefault(f => f.Codigo == codigoPag)?.Descripcion ?? "SIN UTILIZACION DEL SISTEMA FINANCIERO";

                //Mapeo a FacturaRequest
                var facturaRequest = new DctosEmi.FacturaRequest
                {
                    RucEmisor = datosEmpresa.Emp_RUC,
                    RazonSocialEmisor = datosEmpresa.Emp_Nombre,
                    DireccionMatriz = datosEmpresa.Emp_Dirección,
                    DireccionSucursal = datosEmpresa.Emp_Dirección,
                    EmailEmisor = datosEmpresa.Emp_Email,
                    TelefonoEmisor = datosEmpresa.Emp_Telefono_1,
                    ObligadoContabilidad = Convert.ToBoolean(resultado._ObligLlevarConta),
                    NumeroFactura = $"{resultado._Doc_NroIdDoc}-{resultado._Doc_numero}",
                    NumeroAutorizacion = resultado._NroAutorizacionSri,
                    //FechaAutorizacion = resultado._fechaAutorizacion.ToString("yyyy-MM-ddTHH:mm:ss"),
                    FechaAutorizacion = resultado._fechaAutorizacion.HasValue ? resultado._fechaAutorizacion.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                    Ambiente = resultado._tipAmbiente,
                    TipoEmision = resultado._tipEmision,
                    ClaveAcceso = resultado._claveAcceso,
                    NombreCliente = resultado._Doc_NombreImp,
                    IdentificacionCliente = resultado._Doc_CiRuc,
                    FechaEmision = resultado._Doc_fecha.ToString("yyyy-MM-dd"),
                    DireccionCliente = resultado._Doc_Direccion,
                    TelefonoCliente = resultado._Doc_Telefono1,
                    EmailCliente = resultado._CorreoElectrónico,

                    // Aquí va la descripción buscada
                    FormaPago = formaPagoDescripcion,


                    Detalles = resultado.Detalles.Select(d => new DctosEmi.DetalleFactura
                    {
                        CodigoPrincipal = d._Tra_Codigo,
                        Cantidad = d._Tra_cantidad,
                        Descripcion = d._Tra_nombre,
                        PrecioUnitario = d._Tra_precuni,
                        Descuento = d._Tra_porcendes,
                        PrecioTotal = d._Tra_prectot
                    }).ToList(),
                    InformacionAdicional = "-",
                    Subtotal0 = resultado._Doc_totsiva,
                    Subtotal15 = resultado._Base15,
                    Subtotal5 = resultado._Base5,
                    SubtotalNoIva = resultado._Doc_totsiva,
                    Descuento = resultado._totalDescuento,
                    Ice = 0,
                    Iva15 = resultado._Iva15,
                    Iva5 = resultado._Iva5,
                    ValorTotal = resultado._Doc_valor,
                    LogoBase64 = imageBase64,
                };
                ////MessageBox.Show("ingreso a la api");
                var apiClient = new DctosEmi.ApiClient();
                string pdfPath = apiClient.GenerarFactura(facturaRequest, fel.pathCpbGenerados, queClaveSRI, urlEs); // Llamada síncrona 


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}");
            }
        }


        private void AutorizarDocumento(string urlsri)
        {
            if (string.IsNullOrEmpty(queClaveSRI))
                return;
            mensaje.Text = "";
            leerDocumentoAdcom();
            string pathAutorizados = fel.pathCpbAutorizados + queClaveSRI + ".xml";
            string pathNoAutorizados = fel.pathpbNoAutorizados + queClaveSRI + ".xml";
            string pathFirmados = fel.pathCpbFirmados + queClaveSRI + ".xml";
            string pathErrores = pathNoAutorizados.Replace("xml", "ERR");
            correoElectronicoDefecto = fel.correoDefecto;
            string ambiente = "2";
            if (fel.ambienteEnProduccion == false)
                ambiente = "1";

            var prog = new EnviarComprobanteSri();
            var rut= PathFile;            
            if (prog.sendComprobanteSRI(pathFirmados, queClaveSRI, pathAutorizados, pathNoAutorizados, false, ambiente, datosEmpresa.strConxAdcom))
            {
                string archivoXML = pathAutorizados;
                string nombrePdf = archivoXML.Replace("xml", "PDF");
                string rutaNombre = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";

                int IDCLAV = Convert.ToInt32((int)IdDocumento.idClave);
                // Convertir imagen a Base64                
                string imageBase64 = Convert.ToBase64String(File.ReadAllBytes(datosEmpresa.Emp_PathImagenes + "logoempresa.jpg"));
                // 1. Ejecutar el procedimiento para obtener los datos
                var resultado = aux.EjecutarProcedimientoCabeceraYDetalle(IDCLAV, IdDocumento.Sucursal, IdDocumento.Tipo, (decimal)IdDocumento.numero);
                try
                {
                    int codigoPag;
                    bool parseado = int.TryParse(resultado._Pag_Autoriza, out codigoPag);
                    string formaPagoDescripcion = aux.formasDePago.FirstOrDefault(f => f.Codigo == codigoPag)?.Descripcion ?? "SIN UTILIZACION DEL SISTEMA FINANCIERO";

                    //Mapeo a FacturaRequest
                    var facturaRequest = new FacturaRequest
                    {
                        RucEmisor = datosEmpresa.Emp_RUC,
                        RazonSocialEmisor = datosEmpresa.Emp_Nombre,
                        DireccionMatriz = datosEmpresa.Emp_Dirección,
                        DireccionSucursal = datosEmpresa.Emp_Dirección,
                        EmailEmisor = datosEmpresa.Emp_Email,
                        TelefonoEmisor = datosEmpresa.Emp_Telefono_1,
                        ObligadoContabilidad = Convert.ToBoolean(resultado._ObligLlevarConta),
                        NumeroFactura = $"{resultado._Doc_NroIdDoc}-{resultado._Doc_numero}",
                        NumeroAutorizacion = resultado._NroAutorizacionSri,
                        //FechaAutorizacion = resultado._fechaAutorizacion.ToString("yyyy-MM-ddTHH:mm:ss"),
                        FechaAutorizacion = resultado._fechaAutorizacion.HasValue ? resultado._fechaAutorizacion.Value.ToString("yyyy-MM-ddTHH:mm:ss") : null,
                        Ambiente = resultado._tipAmbiente,
                        TipoEmision = resultado._tipEmision,
                        ClaveAcceso = resultado._claveAcceso,
                        NombreCliente = resultado._Doc_NombreImp,
                        IdentificacionCliente = resultado._Doc_CiRuc,
                        FechaEmision = resultado._Doc_fecha.ToString("yyyy-MM-dd"),
                        DireccionCliente = resultado._Doc_Direccion,
                        TelefonoCliente = resultado._Doc_Telefono1,
                        EmailCliente = resultado._CorreoElectrónico,

                        // Aquí va la descripción buscada
                        FormaPago = formaPagoDescripcion,


                        Detalles = resultado.Detalles.Select(d => new DetalleFactura
                        {
                            CodigoPrincipal = d._Tra_Codigo,
                            Cantidad = d._Tra_cantidad,
                            Descripcion = d._Tra_nombre,
                            PrecioUnitario = d._Tra_precuni,
                            Descuento = d._Tra_porcendes,
                            PrecioTotal = d._Tra_prectot
                        }).ToList(),
                        InformacionAdicional = "-",
                        Subtotal0 = resultado._Doc_totsiva,
                        Subtotal15 = resultado._Base15,
                        Subtotal5 = resultado._Base5,
                        SubtotalNoIva = resultado._Doc_totsiva,
                        Descuento = resultado._totalDescuento,
                        Ice = 0,
                        Iva15 = resultado._Iva15,
                        Iva5 = resultado._Iva5,
                        ValorTotal = resultado._Doc_valor,
                        LogoBase64 = imageBase64,
                    };
                    ////MessageBox.Show("ingreso a la api");
                    var apiClient = new ApiClient();

                    string pdfPath = apiClient.GenerarFactura(facturaRequest, fel.pathCpbGenerados, queClaveSRI, urlsri); // Llamada síncrona                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar PDF: {ex.Message}");
                    // Almacenar errores si es necesario
                    Console.WriteLine("Error al generar PDF: {ex.Message}");
                    //almacenarErrores(ErroresE);
                }
            }


            else
            {
                MessageBox.Show("documento no autorizado");
                mensaje.Text = publicarMensaje(pathErrores);
            }

            leerDocumentoAdcom();            
        }


        private void PrepararEnvioCorreo()
        {
            if (IdDocumento.idClave == 0)
            {
                MessageBox.Show("Debe escoger un documento");
                return;
            }

            // Solo permitir si está AUTORIZADO
            if (LabEstado.Text.Trim().ToUpper() != "AUTORIZADO")
            {
                MessageBox.Show("El documento debe estar AUTORIZADO para enviarlo");
                return;
            }

            // 📂 Rutas
            string pathXml = fel.pathCpbAutorizados + queClaveSRI + ".XML";
            string pathPdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";

            if (!File.Exists(pathXml))
            {
                MessageBox.Show("No existe el XML autorizado");
                return;
            }

            // Si no existe el PDF lo genera
            if (!File.Exists(pathPdf))
            {
                urlE = ConfiguracionCorreo.UrlSRI;
                GenerarRide(urlE);
            }

            // 📧 Correo destino
            string correoDestino = correoElectronico;

            if (!verificaCorreoElectronico(ref correoDestino))
            {
                MessageBox.Show("Correo inválido");
                return;
            }

            //// 🚀 Envío
            //string resultado = EnviarCorreoElectornico.EnviandoCorreo(datosEmpresa.strConIniSis,(int)datosEmpresa.codEmpresa,correoDestino,"","Envío de comprobante electrónico", "Adjunto encontrará nuevamente su comprobante electrónico.",pathXml + ";" + pathPdf);

            //if (!string.IsNullOrEmpty(resultado))
            //    MessageBox.Show(resultado);
            //else
            //    MessageBox.Show("Correo enviado correctamente");


        }


        public void ImpDoc(double IdClaveDocC, string Sucursal, string TipoDocumento, double NumeroDocumento, string QueSystema = "A", string FacturaProforma = "F", string AuxManual = "", string otraimp = "", string ImpCtb = "")
        {
            // Try
            // Dim pasar As String = ""
            // Dim prog As New ImprDoct.ImprimirDoc
            // prog.CorreoElectronico = correoElectronico
            // prog.claveSri = queClaveSRI
            // pasar = QueSystema & "," & FacturaProforma & "," & AuxManual & "," & otraimp & "," & ImpCtb
            // prog.ImprimeDocMail(IdClaveDocC, Sucursal, TipoDocumento, NumeroDocumento, pasar)
            // prog = Nothing
            // Catch
            // End Try
        }

        private string publicarMensaje(string file)
        {
            string STR = "";
            try
            {
                var Rfile = new StreamReader(file);
                STR = Rfile.ReadToEnd();
            }
            catch
            {
            }

            return STR;
        }

        private void btnContingencia_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            string retVal = string.Empty;
            // --------------------------------------------------------------------------------------------
            open.Filter = "Archivos TXT(*.TXT)|*.TXT";
            // --------------------------------------------------------------------------------------------
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                PathFile = open.FileName;
                retVal = open.SafeFileName;
            }

            open = null;
            if (PathFile.Length > 0)
            {
                if (MessageBox.Show("Confirma cargar las claves de contingencia registradas en \n" + PathFile, "CARGA DE CLAVES DE CONTINGENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Desea eliminar TODAS las claves registradas actualmente ?", "CARGA DE CLAVES DE CONTINGENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        eliminarClavesContingencia();
                    var file = new StreamReader(PathFile);
                    string strClave = file.ReadToEnd();
                    if (strClave.Length > 20)
                    {
                        guardarClavesContingencia(ref strClave);
                        strClave = null;
                    }
                }
            }
        }

        private void cargarClavesContingencia(string PathFile)
        {
            var sr = new StreamReader(PathFile);
            var linee = new char[39];
            int i = 0;
            int j = 37;
            while (sr.ReadBlock(linee, i, j) > 0)
            {
                MessageBox.Show(Convert.ToString(linee));
                i = +37;
            }
        }

        private void guardarClavesContingencia(ref string clave)
        {
            var conn = new SqlConnection(datosEmpresa.strConxAdcom);
            var comm = new SqlCommand();
            string ssql = "";
            int contador = 0;
            conn.Open();
            for (int i = 0, loopTo = clave.Length - 1; i <= loopTo; i += 38)
            {
                contador += 1;
                ssql = "INSERT INTO [AdcClavContg] ([ClaveContigencia],[UtiDocSucursal],[UtiDocTipo],[UtiDocNumero])";
                ssql += " VALUES";
                ssql += " ('" + clave.Substring(i, 38) + "'";
                ssql += " ,''";
                ssql += " ,''";
                ssql += " ,'')";
                comm = new SqlCommand(ssql, conn);
                comm.ExecuteNonQuery();
            }

            MessageBox.Show("Se almacenaron " + contador.ToString() + " claves de contingencia ");
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }

        private void eliminarClavesContingencia()
        {
            var conn = new SqlConnection(datosEmpresa.strConxAdcom );
            var comm = new SqlCommand();
            string ssql = "";
            int contador = 0;
            conn.Open();
            ssql = "Delete from [AdcClavContg] ";
            comm = new SqlCommand(ssql, conn);
            contador = comm.ExecuteNonQuery();
            MessageBox.Show("Se eliminaron " + contador.ToString() + " claves de contingencia ");
            conn.Close();
            conn.Dispose();
            comm.Dispose();
        }

        //private void btnCorreoXml_Click(object sender, EventArgs e)
        //{
        //    if (IdDocumento.idClave == 0d)
        //    {
        //        MessageBox.Show("Debe escojer un documento para enviar");
        //        return;
        //    }

        //    // Dim fel = New ClassFelec.AdcFelec(strConxadcom)
        //    string estadoDocElectronico = LabEstado.Text.Trim();
        //    // fel = ClassFelec.AdcFelec.Buscar("")

        //    string pathDocXml = "";
        //    if (estadoDocElectronico.ToUpper() == "GENERADO")
        //    {
        //        pathDocXml = fel.pathCpbGenerados;
        //    }
        //    else if (estadoDocElectronico.ToUpper() == "FIRMADO")
        //    {
        //        pathDocXml = fel.pathCpbFirmados;
        //    }
        //    else if (estadoDocElectronico.ToUpper() == "AUTORIZADO")
        //    {
        //        pathDocXml = fel.pathCpbAutorizados;
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se ha generado el archivo XML del documento ");
        //        return;
        //    }

        //    string pathDocPdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";
        //    pathDocXml += queClaveSRI + ".XML";
        //    if (!File.Exists(pathDocXml))
        //    {
        //        MessageBox.Show("No se ha generado el archivo XML del documento ");
        //        return;
        //    }

        //    if (!File.Exists(pathDocPdf))
        //    {
        //        var PROGP = new documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret,datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis, datosEmpresa.strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
        //        PROGP.GeneraDocPdf(IdDocumento, pathDocPdf, "", "FEL" + queClase);
        //    }

        //    correoElectronicoDefecto = fel.correoDefecto;
        //    if (string.IsNullOrEmpty(correoElectronico))
        //    {
        //        if (string.IsNullOrEmpty(correoElectronico2))
        //        {
        //            correoElectronico = correoElectronicoDefecto;
        //        }
        //        else
        //        {
        //            correoElectronico = correoElectronico2;
        //        }
        //    }

        //    if (verificaCorreoElectronico(ref correoElectronico) == false)
        //    {
        //        MessageBox.Show("No existe una dirección de correo electrónico o la dirección está errada ");
        //        return;
        //    }

        //    // Dim PROG As ImprDoct.classEmail = New ImprDoct.classEmail()
        //    // PROG.enviarMailDoc("", pathDocXml, "", correoElectronico, strConxDaxsys, queClaveSRI, "", pathDocPdf)
        //    string adjuntos = pathDocXml + ";" + pathDocPdf;

        //    // Dim PROG As ImprDoct.frmEnvioCorreo = New ImprDoct.frmEnvioCorreo(strConxDaxsys, correoElectronico, correoElectronico2, "Envio documentos electronicos", "Documento: " + queClase + " - " + IdDocumento.numero.ToString() + " ", adjuntos)
        //    // PROG.ShowDialog()
        //    // PROG.Dispose()



        //}

        private void btnCorreoXml_Click(object sender, EventArgs e)
        {
            if (IdDocumento.idClave == 0d)
            {
                MessageBox.Show("Debe escojer un documento para enviar");
                return;
            }
            else
            {
                string pathXml = fel.pathCpbAutorizados + queClaveSRI + ".XML";
                string pathPdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados) + queClaveSRI + ".PDF";

                if (!File.Exists(pathXml))
                {
                    MessageBox.Show("No existe el XML autorizado");
                    return;
                }

                // Si no existe el PDF lo genera
                if (!File.Exists(pathPdf))
                {
                    urlE = ConfiguracionCorreo.UrlSRI;
                    GenerarRide(urlE);
                }

                string numeroFormateado = IdDocumento.numero.ToString().PadLeft(9, '0');

                string numeroCompleto = $"{IdDocumento.Tipo}-{idTributario}-{numeroFormateado}";

                frmEnvioCorreo frm = new frmEnvioCorreo(datosEmpresa.strConIniSis, correoElectronico, "", $"Ha recibido su documento electrónico: {numeroCompleto}", nombreCliente, IdDocumento.Tipo, idTributario + "-" + numeroFormateado, queClaveSRI, LabFechaAutoriza.Text, pathXml + ";" + pathPdf);


                frm.ShowDialog();
            }
            
        }


        private void chkCotingencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnLine.Checked == true)
                chkOnLine.BackColor = System.Drawing.Color.Red;
            else
                chkOnLine.BackColor = System.Drawing.Color.White;
        }

      
        private void btnGenerarGrupo_Click(object sender, EventArgs e)
        {
            var progsel = new BuscadorDocumentos.frmSeleccDoc("ELE");

            colecError.Clear();

            var listaDeDocumentos = progsel.EscojerVariosDocumentos();
            progsel.Dispose();

            if (listaDeDocumentos.IdDocs.Count == 0)
                return;

            if (MessageBox.Show(
                $"Se procesarán {listaDeDocumentos.IdDocs.Count} documentos\nCONFIRMA CONTINUAR ?",
                "Autorización de documentos electrónicos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;

            string ambiente = fel.ambienteEnProduccion ? "2" : "1";

            for (int i = 0; i < listaDeDocumentos.IdDocs.Count; i++)
            {
                string Errores = "";
                var iddoc = listaDeDocumentos.IdDocs[i];
                IdDocumento = iddoc;

                try
                {
                    // =========================
                    // 1️⃣ GENERAR XML
                    // =========================
                    var genxml = new GenerarDocumentoXML();
                    string queClave = genxml.documentoAenviar(
                        iddoc.Sucursal,
                        iddoc.Tipo,
                        iddoc.numero.ToString(),
                        iddoc.idClave,
                        ref PathFile,
                        iddoc.familia,
                        datosEmpresa.Emp_RUC,
                        datosEmpresa.Par_DigitosPrecios,
                        datosEmpresa.pathAppl,
                        1,
                        chkOnLine.Checked
                    );

                    if (queClave.StartsWith("ERROR"))
                        throw new Exception("Error generando XML");

                    queClaveSRI = queClave.ToUpper();

                    // =========================
                    // 2️⃣ FIRMAR
                    // =========================
                    var FM = new Firma();
                    FM.strFileXml = queClaveSRI;
                    string respFirma = FM.FirmarArchivoXML(datosEmpresa.strConxAdcom);

                    if (respFirma.StartsWith("ERROR"))
                        throw new Exception("Error firmando XML");

                    // =========================
                    // 3️⃣ AUTORIZAR
                    // =========================
                    string pathFirmado = fel.pathCpbFirmados + queClaveSRI + ".xml";
                    string pathAutorizados = fel.pathCpbAutorizados + queClaveSRI + ".xml";
                    string pathNoAutorizados = fel.pathpbNoAutorizados + queClaveSRI + ".xml";
                    string pathErrores = pathNoAutorizados.Replace("xml", "ERR");

                    var prog = new EnviarComprobanteSri();

                    if (!prog.sendComprobanteSRI(
                        pathFirmado,
                        queClaveSRI,
                        pathAutorizados,
                        pathNoAutorizados,
                        chkOnLine.Checked,
                        ambiente,
                        datosEmpresa.strConxAdcom))
                    {
                        throw new Exception("Error autorizando\n" + publicarMensaje(pathErrores));
                    }

                    // =========================
                    // 4️⃣ GENERAR PDF DESDE API
                    // =========================

                    var resultado = aux.EjecutarProcedimientoCabeceraYDetalle((int)iddoc.idClave, iddoc.Sucursal, iddoc.Tipo,(decimal)iddoc.numero);

                    string imageBase64 = "";

                    try
                    {
                        string rutaLogo = Path.Combine(datosEmpresa.Emp_PathImagenes, "logoempresa.jpg");
                        if (File.Exists(rutaLogo))
                            imageBase64 = Convert.ToBase64String(File.ReadAllBytes(rutaLogo));
                    }
                    catch { }

                    var facturaRequest = new DctosEmi.FacturaRequest
                    {
                        RucEmisor = datosEmpresa.Emp_RUC,
                        RazonSocialEmisor = datosEmpresa.Emp_Nombre,
                        DireccionMatriz = datosEmpresa.Emp_Dirección,
                        DireccionSucursal = datosEmpresa.Emp_Dirección,
                        EmailEmisor = datosEmpresa.Emp_Email,
                        TelefonoEmisor = datosEmpresa.Emp_Telefono_1,
                        ObligadoContabilidad = Convert.ToBoolean(resultado._ObligLlevarConta),
                        NumeroFactura = $"{resultado._Doc_NroIdDoc}-{resultado._Doc_numero}",
                        NumeroAutorizacion = resultado._NroAutorizacionSri,
                        FechaAutorizacion = resultado._fechaAutorizacion?.ToString("yyyy-MM-ddTHH:mm:ss"),
                        Ambiente = resultado._tipAmbiente,
                        TipoEmision = resultado._tipEmision,
                        ClaveAcceso = resultado._claveAcceso,
                        NombreCliente = resultado._Doc_NombreImp,
                        IdentificacionCliente = resultado._Doc_CiRuc,
                        FechaEmision = resultado._Doc_fecha.ToString("yyyy-MM-dd"),
                        DireccionCliente = resultado._Doc_Direccion,
                        TelefonoCliente = resultado._Doc_Telefono1,
                        EmailCliente = resultado._CorreoElectrónico,
                        ValorTotal = resultado._Doc_valor,
                        LogoBase64 = imageBase64
                    };

                    var apiClient = new DctosEmi.ApiClient();
                    string urlsri = ConfiguracionCorreo.UrlSRI;
                    string resultadoPdf = apiClient.GenerarFactura(
                        facturaRequest,
                        fel.pathCpbGenerados,   // Ruta base
                        queClaveSRI,            // 🔥 NOMBRE CORRECTO DEL PDF
                        urlsri
                    );

                    if (resultadoPdf != "GENERADO")
                        throw new Exception("Error generando PDF API");

                    // Construir ruta final del PDF (como lo hace ApiClient)
                    string rutaPadre = Path.GetDirectoryName(fel.pathCpbGenerados.TrimEnd('\\'));
                    string rutaPdfFinal = Path.Combine(rutaPadre, "GeneradosPDF", queClaveSRI + ".pdf");
                    // =========================
                    // 5️⃣ ENVIAR CORREO
                    // =========================
                    string correoDestino = resultado._CorreoElectrónico;

                    if (!verificaCorreoElectronico(ref correoDestino))
                        throw new Exception("Correo inválido");

                    var eMail = new ClassDaxMail.EnvCorreoSmtp(
                        datosEmpresa.strConIniSis,
                        datosEmpresa.codEmpresa);

                    string asunto = $"Envío documento electrónico {iddoc.Tipo}-{iddoc.numero}";
                    string mensajeCorreo = "Enviamos su comprobante electrónico.\nFavor confirmar recepción.";

                    eMail.EnviarCorreoSmpt(
                        "",
                        correoDestino,
                        asunto,
                        mensajeCorreo,
                        pathAutorizados + ";" + rutaPdfFinal
                    );
                }
                catch (Exception ex)
                {
                    Errores = $"{iddoc.Sucursal}-{iddoc.Tipo}-{iddoc.numero} - {ex.Message}";
                    almacenarErrores(Errores);
                }
            }

            Cursor = Cursors.Default;

            if (colecError.Count > 0)
            {
                MessageBox.Show("Proceso terminado con errores");
                var visor = new DaxValDocElec.frmVisor(colecError, "Errores en autorización");
                visor.Show();
            }
            else
            {
                MessageBox.Show("Proceso terminado exitosamente");
            }
        }


        private bool verificaCorreoElectronico(ref string correoElectronico)
        {
            if (correoElectronico.Length == 0)
                correoElectronico = correoElectronicoDefecto;
            if (correoElectronico.Length == 0)
                return false;
            return DaxValDocElec.ValidacionesDocElectronicos.ValidarEmail(correoElectronico);
        }

        private void almacenarErrores(string err)
        {
            colecError.Add(err);
        }

        private void configurarBotones()
        {
            Boolean Estado = (IdDocumento.idClave  > 0);
            btnAbre.Enabled = !Estado;
            btnGenerarGrupo.Enabled = !Estado;
            btnAutorizar.Enabled = Estado;
            btnCorreoXml.Enabled = Estado;
            //btnEnviar.Enabled = Estado;
            btnGenerar.Enabled = Estado;
        }

        private void LabNumeroAutoriza_Click(object sender, EventArgs e)
        {

        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            frmConfiguracion frmconf = new frmConfiguracion(DattCom.datosEmpresa.strConIniSis, DattCom.datosEmpresa.strConxAdcom);
            frmconf.ShowDialog();
        }

		private void btnXML_Click(object sender, EventArgs e)
		{
            frmLeDocxml frmLeDocxml = new frmLeDocxml();
            int num = (int)frmLeDocxml.ShowDialog();
            frmLeDocxml.Dispose();
        }

		private void btnCerrar_Click(object sender, EventArgs e) => this.LimpiarDocumento();

        private void LimpiarDocumento()
        {
            this.IdDocumento.Sucursal = "";
            this.IdDocumento.Tipo = "";
            this.IdDocumento.idClave = 0.0;
            this.IdDocumento.numero = 0.0;
            this.queClase = "";
            this.queClaveSRI = "";
            this.LabCiRuc.Text = "";
            this.LabClave.Text = "";
            this.LabEstado.Text = "";
            this.LabFechaAutoriza.Text = "";
            this.LabId.Text = "";
            this.LabNombre.Text = "";
            this.LabNumero.Text = "";
            this.LabNumeroAutoriza.Text = "";
            this.LabTipo.Text = "";
            this.queCodigoCliente = "";
            this.correoElectronico = "";
            this.correoElectronico2 = "";
            this.OrganizarBotones();
        }
        private void OrganizarBotones()
        {
            bool flag = this.IdDocumento.idClave > 0.0;
            this.btnAbre.Enabled = !flag;
            this.btnGenerarGrupo.Enabled = !flag;
            this.btnXML.Enabled = !flag;
            this.btnAutorizar.Enabled = flag;
            this.btnGenerar.Enabled = flag;
        }

        //private void btnImprimir_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (IdDocumento.idClave == 0)
        //        {
        //            MessageBox.Show("Debe escoger un documento para imprimir");
        //            return;
        //        }

        //        string pathPdf = Path.Combine(
        //            Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados),
        //            queClaveSRI + ".PDF"
        //        );

        //        // Si no existe el PDF lo genera
        //        if (!File.Exists(pathPdf))
        //        {
        //            urlE = ConfiguracionCorreo.UrlSRI;
        //            GenerarRide(urlE);
        //        }

        //        // Verificar nuevamente
        //        if (!File.Exists(pathPdf))
        //        {
        //            MessageBox.Show("No se pudo generar el PDF.");
        //            return;
        //        }

        //        // Abrir visor
        //        frmPreviewPdf frm = new frmPreviewPdf(pathPdf);
        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al abrir el documento:\n" + ex.Message);
        //    }
        //}

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (IdDocumento.idClave == 0)
            {
                MessageBox.Show("Debe escoger un documento para imprimir");
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string carpetaPdf = Feutilidad.PathDocumntosPdf(fel.pathCpbGenerados);

                string pathPdf = Path.Combine(carpetaPdf, queClaveSRI + ".PDF");

                // Generar solo si no existe
                if (!File.Exists(pathPdf))
                {
                    urlE = ConfiguracionCorreo.UrlSRI;

                    GenerarRide(urlE);

                    // verificar nuevamente
                    if (!File.Exists(pathPdf))
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("No se pudo generar el PDF.");
                        return;
                    }
                }

                Cursor.Current = Cursors.Default;

                // abrir visor
                using (frmPreviewPdf frm = new frmPreviewPdf(pathPdf))
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error al abrir el documento:\n" + ex.Message);
            }
        }





    }

}



