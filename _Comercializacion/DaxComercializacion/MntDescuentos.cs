using System;
using DattCom;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxComercia
{
    public partial class MntDescuentos : Form
    {
        int proceso = 0;  // 0 ninguno 1 nuevo  2 modificando
        ClassDoc.DescPromo DatosDescuentos;
        public MntDescuentos()
        {
            InitializeComponent();
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Buscar.frmBuscar prog = new Buscar.frmBuscar();
            string descuento = prog.Buscar(datosEmpresa.strConxAdcom, "select  Desc_ClaveId as Nro,  DES_NOMBRE as NombreDescuento  from descpromo order by DES_NOMBRE ", "Nro", "NombreDescuento", "", "DESCUENTOS COMERCIALES");
            if (descuento.Length > 0) CargarDatos(descuento);
        }
        private void CargarDatos(string codigo)
        {
            DatosDescuentos = new ClassDoc.DescPromo(datosEmpresa.strConxAdcom);
            DatosDescuentos =  ClassDoc.DescPromo.Buscar(" desc_Claveid = " + codigo);
            if (DatosDescuentos == null)
            {
                MessageBox.Show("No existe el descuento solicitado");
                DatosDescuentos = new ClassDoc.DescPromo(datosEmpresa.strConxAdcom);
                proceso = 0;
                arreglarBotones();
                return;
            }
            txtDescripcion.Text = DatosDescuentos.DES_NOMBRE;
            txtIdCtb1.Text = DatosDescuentos.Des_IdCta;
            txtIdCtb2.Text = DatosDescuentos.Des_IdCta2;
            txtPorcentaje.Text  = DatosDescuentos.DES_PORCEN.ToString();
            txtValorFijo.Text = DatosDescuentos.DES_Valor.ToString();
            chkAplicaConIva.Checked = (DatosDescuentos.DES_SNIVA == "T" || DatosDescuentos.DES_SNIVA == "C"); ;
            chkAplicaSinIva.Checked = (DatosDescuentos.DES_SNIVA == "T" || DatosDescuentos.DES_SNIVA == "S");
        }       

        private void limpiar()
        {
            txtDescripcion.Text  = "";
            txtPorcentaje.Text = "0";
            txtValorFijo.Text = "0";
            chkAplicaConIva.Checked = false;
            chkAplicaSinIva.Checked = false;
            txtIdCtb1.Text = "";
            txtIdCtb2.Text = "";
            labIdCtb1.Text = "";
            labIdctb2.Text = "";
            DatosDescuentos = new ClassDoc.DescPromo();
            proceso = 1;
            arreglarBotones();
        }
        private void arreglarBotones()
        {
            btnAbrir.Enabled = (proceso == 0);
            BtnNuevo.Enabled = btnAbrir.Enabled;
            btnCancelar.Enabled = (proceso != 0);
            btnEliminar.Enabled = (proceso == 2);
            btnGuardar.Enabled = btnCancelar.Enabled;
            txtDescripcion.Enabled = (proceso != 2);
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DatosDescuentos.DES_NOMBRE = txtDescripcion.Text;
            DatosDescuentos.Des_IdCta = txtIdCtb1.Text;
            DatosDescuentos.Des_IdCta2 = txtIdCtb2.Text;
            DatosDescuentos.DES_PORCEN = Convert.ToDecimal( "0" + txtPorcentaje.Text);
            DatosDescuentos.DES_Valor = Convert.ToDecimal("0" + txtValorFijo.Text);
            DatosDescuentos.DES_SNIVA = "C";
            if (chkAplicaConIva.Checked && chkAplicaSinIva.Checked) DatosDescuentos.DES_SNIVA = "T";
            else if (chkAplicaConIva.Checked) DatosDescuentos.DES_SNIVA = "C";
            else if (chkAplicaSinIva.Checked) DatosDescuentos.DES_SNIVA = "S";
            if (DatosDescuentos.Desc_ClaveId == 0) DatosDescuentos.Crear();
            else DatosDescuentos.Actualizar();
            limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           if ( MessageBox.Show("Confirma cerrar el registro actual ?","Mantenimiento de descuentos comerciales",  MessageBoxButtons.YesNo, MessageBoxIcon.Question )== DialogResult.No ) return;
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (proceso == 2)
            { 
                if (MessageBox.Show("Confirma eliminarr el registro actual ?", "Mantenimiento de descuentos comerciales", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                DatosDescuentos.Borrar();
            }
            limpiar();
        }

        private void btnBuscarCta1_Click(object sender, EventArgs e)
        {
            
        }
    }

}
