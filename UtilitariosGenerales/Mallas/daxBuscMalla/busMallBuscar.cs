using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace DaxMallaLib
{
    
    static internal class busMallBuscar
    {
        static int estado = 0;
        static public string txtBuscar;
        static DateTime fechaBuscar = new DateTime(1900,1,1);
//        static Boolean esFecha = false;
//        static Boolean esValor = false;
        static Int32 ultCeldaSeleccionada = 0;
        internal static Int32 ultColumnaSeleccionada = 0;
        internal static Int32 ultLineaSeleccionada = 0;
        //static DateTime fechaAbuscar;
        internal static void inicializar()
        {
            ultCeldaSeleccionada = 0;
            ultColumnaSeleccionada = 0;
            ultLineaSeleccionada = 0;
        }
        static internal void prepararValores()
        {
            string straBuscar = txtBuscar;
            //esFecha = false;
            //esValor = false;
            //try
            //{
            //    fechaAbuscar = Convert.ToDateTime(txtBuscar);
            //    esFecha = true;
            //}
            //catch { };
            //try
            //{
            //    double valoraBuscar = Convert.ToDouble(txtBuscar);
            //    esValor = true;
            //    straBuscar = valoraBuscar.ToString();
            //}
            //catch { };

        }
        static internal int buscarEnColumna(DataGridView malla, string valorBuscar, int tipo)
        {         
            if (valorBuscar.Length == 0) return 0;
            estado = 0;
            txtBuscar = valorBuscar;
            prepararValores();
            Int32 columna = malla.CurrentCell.ColumnIndex;
            for (Int32 i = ultLineaSeleccionada; i < malla.Rows.Count; i++)
            {
                estado=BuscarCelda(malla,malla.Rows[i].Cells[columna], valorBuscar, tipo, fechaBuscar);
                if (estado == 1) break;
            }
            encontrado();
            return estado;
        }

        static internal int buscarEnLinea(DataGridView malla, string valorBuscar, int tipo)
        {
            if (valorBuscar.Length == 0) return 0;
            estado = 0;
            txtBuscar = valorBuscar;
            prepararValores();
            Int32 linea = malla.CurrentCell.RowIndex;
            for (Int32 i = ultColumnaSeleccionada; i < malla.Columns.Count; i++)
            {
                try
                {
                  estado= BuscarCelda(malla,malla.Rows[linea].Cells[i], valorBuscar, tipo, fechaBuscar);
                    if (estado == 1) break;
                }
                catch { }
            }
            encontrado();
            return estado;
        }

        static internal int buscarCeldasSeleccionadas(DataGridView malla, string valorBuscar, int tipo)
        {
            if (valorBuscar.Length == 0) return 0;
            txtBuscar = valorBuscar;
            prepararValores();
            estado = 0;
            if (ultCeldaSeleccionada != malla.SelectedCells.Count)
            {
                for (int i = ultCeldaSeleccionada; i < malla.SelectedCells.Count; i++)
                {
                    DataGridViewCell cell = malla.SelectedCells[i];
                    estado = BuscarCelda(malla,cell, valorBuscar, tipo, fechaBuscar);
                    if (estado == 1)
                    {
                        ultCeldaSeleccionada = i + 1;
                        malla.CurrentCell = cell;
                        break;
                    }
                }
            }
            encontrado();
            return estado;
        }
        static internal int buscarEnMalla(DataGridView malla, string valorBuscar, DateTime fechaBuscar, int tipo)
        {
            if (valorBuscar.Length == 0) return 0;
            estado = 0;
            txtBuscar = valorBuscar;
            prepararValores();
            for (Int32 i = ultLineaSeleccionada; i < malla.Rows.Count; i++)
            {
                for (Int32 j = ultColumnaSeleccionada; j < malla.Columns.Count; j++)
                {
                    try
                    {
                        estado = BuscarCelda(malla,malla.Rows[i].Cells[j], valorBuscar, tipo, fechaBuscar);
                        if (estado == 1) break;
                    }
                    catch { }
                }
                if (estado == 1) break;
                ultColumnaSeleccionada = 0;
            }
            encontrado ();
            return estado;
        }

        static private int BuscarCelda(DataGridView malla,DataGridViewCell cell, string valorBuscar, int tipo, DateTime fechaBuscar)
        {
            if (cell.Value == null) return 0;
            int estado = 0;

            //if (esFecha)
            //{
            //    try
            //    {
            //        DateTime fechaCel = Convert.ToDateTime(cell.Value);
            //        if (classBuscMalla.compararFecha(fechaCel, fechaBuscar, tipo)) return 1;
            //        return 0;
            //    }
            //    catch { }
            //}
            string strCell = cell.Value.ToString();
            //try
            //{
            //    double valCel = Convert.ToDouble(strCell);
            //    strCell = valCel.ToString();
            //}
            //catch { };
            if (classBuscMalla.compararString(strCell, valorBuscar, tipo)) estado = 1;

            if (estado == 1)
            {
                malla.CurrentCell = cell;            
            }
            return estado;
        }
        static private void encontrado()
        {
            if (estado == 0) { MessageBox.Show("No se encontró ninguna coincidencia", "Buscar valores en malla de datos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
        }
    }
}
