using System;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using SolicitudAutSRI;
using DattCom;

namespace SesFelec
{
    public partial class frmEnvioCorreo : Form
    {
        private string StrConxSysemp = "";
        private List<string> rutasAdjuntos = new List<string>();
        private string cliente;
        private string tipoDoc;
        private string numeroDoc;
        private string claveAcceso;
        private string fechaA;
        private ImageList imgAdjuntos = new ImageList();

       
        public frmEnvioCorreo(string strconxsys, string strTo, string strCC, string strAsunto, string strCliente, string strTipoDoc, string strNumero, string strClave, string fecha,string strAdjuntos)
        {
            InitializeComponent();

            StrConxSysemp = strconxsys;

            txtDestino.Text = strTo;
            txtConCopia.Text = strCC;
            txtAsunto.Text = strAsunto;

            cliente = strCliente;
            tipoDoc = strTipoDoc;
            numeroDoc = strNumero;
            claveAcceso = strClave;
            fechaA = fecha;

            string html = plantillaMail.GenerarPlantillaCorreo(datosEmpresa.Emp_Nombre,cliente, tipoDoc, numeroDoc, claveAcceso, fechaA, ConfiguracionCorreo.CorreoDesde);

            // SOLO visor HTML
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
                if (string.IsNullOrWhiteSpace(ConfiguracionCorreo.CorreoDesde) ||
                    string.IsNullOrWhiteSpace(ConfiguracionCorreo.Smtp) ||
                    string.IsNullOrWhiteSpace(ConfiguracionCorreo.Usuario) ||
                    string.IsNullOrWhiteSpace(ConfiguracionCorreo.Clave) ||
                    ConfiguracionCorreo.Puerto <= 0)
                {
                    MessageBox.Show("La configuración de correo está incompleta.");
                    return;
                }

                using (MailMessage mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(ConfiguracionCorreo.CorreoDesde,"Facturación Electrónica");

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


                    //mensaje.Body = txtDetalle.Text;
                    //mensaje.IsBodyHtml = false;

                    mensaje.Body = plantillaMail.GenerarPlantillaCorreo(datosEmpresa.Emp_Nombre,cliente,tipoDoc,numeroDoc,claveAcceso,fechaA, ConfiguracionCorreo.CorreoDesde);

                    mensaje.IsBodyHtml = true;

                    // ADJUNTOS
                    foreach (var ruta in rutasAdjuntos)
                    {
                        if (File.Exists(ruta))
                            mensaje.Attachments.Add(new Attachment(ruta));
                    }

                    using (var smtpClient = new SmtpClient(
                        ConfiguracionCorreo.Smtp,
                        ConfiguracionCorreo.Puerto))
                    {
                        smtpClient.Credentials = new NetworkCredential(
                            ConfiguracionCorreo.Usuario,
                            ConfiguracionCorreo.Clave);

                        smtpClient.EnableSsl = ConfiguracionCorreo.HabilitarSSL;

                        smtpClient.Send(mensaje);
                    }
                }

                MessageBox.Show("Correo enviado correctamente.","Correo",MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enviando correo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

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

            string icono = "xml";

            if (ext == ".pdf")
                icono = "pdf";

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
            //lstAdjuntos.View = View.List;            

            //imgAdjuntos.Images.Add("pdf", Properties.Resources.pdf);
            //imgAdjuntos.Images.Add("xml", Properties.Resources.xml);

            //lstAdjuntos.SmallImageList = imgAdjuntos;
            // Cambiar a View.Details para que los elementos se muestren verticalmente
            lstAdjuntos.View = View.Details;

            // IMPORTANTE: Agregar una columna para que los elementos se muestren
            // Si no agregas una columna, no se verá nada aunque tengas elementos
            lstAdjuntos.Columns.Add("Archivos adjuntos", 400); // Ajusta el ancho según necesites

            imgAdjuntos.Images.Add("pdf", Properties.Resources.pdf);
            imgAdjuntos.Images.Add("xml", Properties.Resources.xml);

            lstAdjuntos.SmallImageList = imgAdjuntos;
        }

        private void lstAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            if (lstAdjuntos.SelectedItems.Count == 0)
                return;

            int index = lstAdjuntos.SelectedItems[0].Index;
            string ruta = rutasAdjuntos[index];

            if (File.Exists(ruta))
                System.Diagnostics.Process.Start(ruta);
        }

        private void wbPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}