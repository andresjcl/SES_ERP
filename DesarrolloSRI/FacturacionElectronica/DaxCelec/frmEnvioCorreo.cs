using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using SolicitudAutSRI;
using DattCom;
using System.Drawing;

namespace SesFelec
{
    public partial class frmEnvioCorreo : Form
    {
        private string StrConxSysemp = "";
        private string CodEmpresa = "";
        private string strSESERP = "";
        private List<string> rutasAdjuntos = new List<string>();
        private string cliente;
        private string tipoDoc;
        private string numeroDoc;
        private string claveAcceso;
        private string fechaA;
        private ImageList imgAdjuntos = new ImageList();

        public frmEnvioCorreo(string strconxsys,string strerpses,string codEmpresa, string strTo, string strCC, string strAsunto,string strCliente, string strTipoDoc, string strNumero, string strClave,string fecha, string strAdjuntos)
        {
            InitializeComponent();

            StrConxSysemp = strconxsys;
            CodEmpresa = codEmpresa;
            strSESERP = strerpses;

            // Cargar configuración de correo desde CorreoConfig
            if (!ConfiguracionCorreo.CargarConfiguracion(strSESERP, CodEmpresa))
            {
                // Intentar crear la tabla si no existe
                if (ConfiguracionCorreo.CrearTablaCorreoConfig(strSESERP))
                {
                    MessageBox.Show("Se ha creado la tabla CorreoConfig.\n" +
                                   "Por favor, configure los datos de correo en el formulario de registro.",
                                   "Tabla Creada",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo cargar la configuración de correo.\n" +
                                   "Verifique que la tabla CorreoConfig exista y tenga datos configurados.",
                                   "Error de Configuración",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                }
                return;
            }

            txtDestino.Text = strTo;
            txtConCopia.Text = strCC;
            txtAsunto.Text = strAsunto;

            cliente = strCliente;
            tipoDoc = strTipoDoc;
            numeroDoc = strNumero;
            claveAcceso = strClave;
            fechaA = fecha;

            string html = plantillaMail.GenerarPlantillaCorreo(datosEmpresa.Emp_Nombre,cliente,tipoDoc,numeroDoc,claveAcceso,fechaA,ConfiguracionCorreo.CorreoDesde);

            wbPreview.DocumentText = html;

            if (!string.IsNullOrEmpty(strAdjuntos))
            {
                var archivos = strAdjuntos.Split(';');

                foreach (var archivo in archivos)
                {
                    if (File.Exists(archivo))
                        AgregarAdjunto(archivo);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar configuración
                if (string.IsNullOrWhiteSpace(ConfiguracionCorreo.CorreoDesde) ||
                    string.IsNullOrWhiteSpace(ConfiguracionCorreo.Smtp) ||
                    string.IsNullOrWhiteSpace(ConfiguracionCorreo.Usuario) ||
                    string.IsNullOrWhiteSpace(ConfiguracionCorreo.Clave) ||
                    ConfiguracionCorreo.Puerto <= 0)
                {
                    MessageBox.Show("La configuración de correo está incompleta.\n" +
                                   "Por favor, configure la cuenta de correo en el formulario de registro.",
                                   "Configuración Incompleta",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    return;
                }

                using (MailMessage mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(ConfiguracionCorreo.CorreoDesde, "Facturación Electrónica");

                    // DESTINATARIOS
                    foreach (var correo in txtDestino.Text.Split(';'))
                    {
                        if (!string.IsNullOrWhiteSpace(correo))
                            mensaje.To.Add(correo.Trim());
                    }

                    // CC
                    foreach (var correo in txtConCopia.Text.Split(';'))
                    {
                        if (!string.IsNullOrWhiteSpace(correo))
                            mensaje.CC.Add(correo.Trim());
                    }

                    mensaje.Subject = txtAsunto.Text;
                    mensaje.Body = plantillaMail.GenerarPlantillaCorreo(datosEmpresa.Emp_Nombre,cliente,tipoDoc,numeroDoc,claveAcceso,fechaA,ConfiguracionCorreo.CorreoDesde);
                    mensaje.IsBodyHtml = true;

                    // ADJUNTOS
                    foreach (var ruta in rutasAdjuntos)
                    {
                        if (File.Exists(ruta))
                            mensaje.Attachments.Add(new Attachment(ruta));
                    }

                    using (var smtpClient = new SmtpClient(ConfiguracionCorreo.Smtp,ConfiguracionCorreo.Puerto))
                    {
                        smtpClient.Credentials = new NetworkCredential(ConfiguracionCorreo.Usuario,ConfiguracionCorreo.Clave);

                        smtpClient.EnableSsl = ConfiguracionCorreo.HabilitarSSL;
                        smtpClient.Timeout = 30000;

                        smtpClient.Send(mensaje);
                    }
                }

                MessageBox.Show("Correo enviado correctamente.",
                    "Correo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (SmtpException ex)
            {
                string mensajeError = "Error al enviar correo:\n\n";

                switch (ex.StatusCode)
                {
                    case SmtpStatusCode.GeneralFailure:
                        mensajeError += "Error general. Verifique la conexión a internet y la configuración.";
                        break;
                    case SmtpStatusCode.ServiceNotAvailable:
                        mensajeError += "El servidor SMTP no está disponible.";
                        break;
                    case SmtpStatusCode.MailboxNameNotAllowed:
                        mensajeError += "La dirección de correo no es válida.";
                        break;
                    case SmtpStatusCode.TransactionFailed:
                        mensajeError += "Falló la transacción. Verifique los datos de configuración.";
                        break;
                    default:
                        mensajeError += ex.Message;
                        break;
                }

                MessageBox.Show(mensajeError,"Error SMTP",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando correo:\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Archivos PDF|*.pdf|Archivos XML|*.xml|Todos los archivos|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string archivo in dialog.FileNames)
                {
                    AgregarAdjunto(archivo);
                }
            }
        }

        private void AgregarAdjunto(string ruta)
        {
            if (!File.Exists(ruta))
                return;

            rutasAdjuntos.Add(ruta);

            string nombre = Path.GetFileName(ruta);
            string ext = Path.GetExtension(ruta).ToLower();

            string icono = ext == ".pdf" ? "pdf" : "xml";

            ListViewItem item = new ListViewItem(nombre);
            item.ImageKey = icono;
            item.Tag = ruta;

            lstAdjuntos.Items.Add(item);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEnvioCorreo_Load(object sender, EventArgs e)
        {
            lstAdjuntos.View = View.Details;
            lstAdjuntos.Columns.Add("Archivos adjuntos", 400);

            try
            {
                imgAdjuntos.Images.Add("pdf", Properties.Resources.pdf);
                imgAdjuntos.Images.Add("xml", Properties.Resources.xml);
            }
            catch
            {
                imgAdjuntos.Images.Add("pdf", SystemIcons.Application.ToBitmap());
                imgAdjuntos.Images.Add("xml", SystemIcons.Application.ToBitmap());
            }

            lstAdjuntos.SmallImageList = imgAdjuntos;
        }

        private void lstAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            if (lstAdjuntos.SelectedItems.Count == 0)
                return;

            int index = lstAdjuntos.SelectedItems[0].Index;
            if (index < rutasAdjuntos.Count)
            {
                string ruta = rutasAdjuntos[index];

                if (File.Exists(ruta))
                    System.Diagnostics.Process.Start(ruta);
            }
        }

        private void wbPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}