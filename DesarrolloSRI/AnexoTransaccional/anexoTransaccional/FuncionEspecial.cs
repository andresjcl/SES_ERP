using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anexoTransaccional
{
    class FuncionEspecial
    {
        public void funcionesCompras(ref Keys keyData, ref DataGridViewCell cell,ref string dato, string nombreColumna, string strConxIvaret, string strConxAdcom)
        {
            IvaRett.FrmBuscar tabSri = new IvaRett.FrmBuscar();
            string nombre = "";
            double porcentaje = 0;
            //DaxLib.DaxLibBases dlib = new DaxLib.DaxLibBases();
            //dlib.TipoBase = "10";
            //strConxIvaret = dlib.StrIvaret();
            //strConxAdcom = dlib.StrAdcom();
            if (keyData == Keys.F2)
            {
                if (nombreColumna == "codSustento")
                {
                    dato = tabSri.Buscar( 1,IvaRett.nombreTablas.SustentoComprobante ,ref nombre, ref porcentaje );
                }
                else if (nombreColumna == "idProv")
                {
                    string cliOprov = "P";
                    string ConAlias = "";
                    string ConNuevo = "";
                    DaxMantDirectorio.BuscaClien prog = new DaxMantDirectorio.BuscaClien();
                    dato = prog.IniBuscaCliOPro(ref cliOprov, ref nombre, ref ConAlias, ref ConNuevo);
                    prog.Dispose();
                }
                else if (nombreColumna == "tpIdProv")
                {
                    dato = tabSri.Buscar(1, IvaRett.nombreTablas.TipoDeIdentificacion, ref nombre,ref porcentaje );
                    tabSri.Dispose();
                }
                else if (nombreColumna == "parteRel")
                {
                    if (cell.Value.ToString() != "NO") dato = "NO"; else dato = "SI";
                }
                else if (nombreColumna == "tipoComprobante")
                {
                    dato = tabSri.Buscar(1,IvaRett.nombreTablas.ComprobantesAutorizados , ref nombre,ref porcentaje);
                }
                else if (nombreColumna == "fechaRegistro" || nombreColumna == "fechaPagoDiv" || nombreColumna == "fechaPagoDiv1" || nombreColumna == "fechaPagoDiv2" || nombreColumna == "fechaPagoDiv3" || nombreColumna == "fechaEmision") 
                {
                    DaxFechas.DaxFechas fec = new DaxFechas.DaxFechas();
                    string laFecha = "";
                    dato = fec.DaxFecha (laFecha);
                }
                else if (nombreColumna == "pagoLocExt")
                {
                    dato = tabSri.Buscar(0,  IvaRett.nombreTablas.TiposPago,  ref nombre, ref porcentaje);
                }
                else if (nombreColumna == "paisEfecPago")
                {
                    dato = tabSri.Buscar(0,  IvaRett.nombreTablas.Paises,  ref nombre, ref porcentaje);
                }
                else if (nombreColumna == "pagExtSujRetNorLeg")
                {
                    if (cell.Value.ToString() != "NO") dato = "NO"; else dato = "SI";
                }
                else if (nombreColumna == "aplicConvDobTrib")
                {
                    if (cell.Value.ToString() != "NO") dato = "NO"; else dato = "SI";
                }
                else if (nombreColumna == "pagoRegFis")
                {
                    if (cell.Value.ToString() != "NO") dato = "NO"; else dato = "SI";
                }
                else if (nombreColumna == "codRetAir" || nombreColumna == "codRetAir1" || nombreColumna == "codRetAir2" || nombreColumna == "codRetAir3")
                {
                    dato = tabSri.Buscar(0,IvaRett.nombreTablas.ConceptosRetencion,  ref nombre,ref porcentaje);
                }
                else if (nombreColumna == "formaPago")
                {
                    dato = tabSri.Buscar(0, IvaRett.nombreTablas.FormasDePago,  ref nombre, ref porcentaje);
                }
            }
            if (dato != "") cell.Value = dato;
            tabSri.Dispose();

        }
        public void funcionesExportacion(ref Keys keyData, ref DataGridViewCell cell, ref string dato, string nombreColumna)
        {
            
        }
    }
}
