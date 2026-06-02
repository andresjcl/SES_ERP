using System;
using Microsoft.VisualBasic;

namespace MantCtb
{
    public partial class CtbValida
    {
        public CtbValida()
        {
            InitializeComponent();
            _BtnImprimir.Name = "BtnImprimir";
            _btnSalir.Name = "btnSalir";
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            var imp = new DataGridViewPrinterApplication1.frmMain();
            imp.imprimir(Malla, "Errores en configuración del plan de cuentas contables " + Strings.Format(DateTime.Now, "dd/MMM/yyyy"), Empresa: SysEmpDatt.datosEmpresa.Emp_Nombre);
            imp.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}