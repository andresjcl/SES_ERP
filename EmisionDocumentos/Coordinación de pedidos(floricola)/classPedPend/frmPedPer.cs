using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classPedPend
{
    public partial class frmPedPer : Form
    {
        public frmPedPer()
        {
            InitializeComponent();
            cargarDatos();
        }
        private void cargarDatos()
        {
            dtInicio.Value = periodoPedFijo.fechaInicia;
            dtFin.Value = periodoPedFijo.fechaFin;

            if (periodoPedFijo.tipo == 1) 
            {
                chkSemanal.Checked = true;
                cmbDiasemanal.Text = periodoPedFijo.diaSemana;
            }
            else if (periodoPedFijo.tipo == 2)
            {
                chkQuincenal.Checked = true;
                cmbDiaQuincena1.SelectedIndex = periodoPedFijo.diaQuincena1;
                cmbDiaQuincena2.SelectedIndex = periodoPedFijo.diaQuincena2;
            }
            if (periodoPedFijo.tipo == 3)
            {
                chkMensual.Checked = true;
                cmbDiaMes.SelectedIndex = periodoPedFijo.diaMes;
            }

        }
    }
}
