using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxMovCaja
{
    public partial class IngMovCaja : Form
    {
        string tipo = "I";  // Ingreso  Gasto 
        string PuntoVta = "";
        DaxAdcPto DataMovPto;       
        public IngMovCaja(string Tipo,string PtoVta, string StrConxAdcom)
        {
            InitializeComponent();
            PuntoVta = PtoVta;
            tipo = Tipo;
            if (Tipo=="G")
            {
                this.Text = "Registro de gastos de caja";
                label1.Text = "Entregado a:";
            }
            crearDatos(StrConxAdcom);
        }

        private void btnGuarda_Click(object sender, EventArgs e)
        {
            if (validar()==false) return;
            DataMovPto.Responsable = txtResponsable.Text;
            DataMovPto.Descripción = txtConcepto.Text;
            DataMovPto.Valor = Convert.ToDecimal(txtValor.Text);
            DataMovPto.PuntoVta = PuntoVta;
            DataMovPto.Actualizar();
            Close();
        }
        private void crearDatos(string StrConxAdcom)
        {
            DataMovPto = new DaxMovCaja.DaxAdcPto(StrConxAdcom);
            DataMovPto.FechaMov = dtFecha.Value;
            DataMovPto.PuntoVta = PuntoVta;
            DataMovPto.Sucursal = varbleComun.VarCom.suc;
            DataMovPto.TipoMov = tipo;
        }
        private Boolean validar()
        {
            decimal valor = 0;
            try { valor=Convert.ToDecimal(txtValor.Text); } catch { };
            if (txtConcepto.TextLength == 0 || txtResponsable.TextLength == 0 || valor == 0)
            {
                MessageBox.Show("Debe registrar todos los datos para guardar","", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            if (varbleComun.VarCom.usr.ToUpper() != "ADMINISTRADOR") return;
            DaxMovCaja.frmEdit prog = new DaxMovCaja.frmEdit();
            prog.ShowDialog();
        }
    }
}
