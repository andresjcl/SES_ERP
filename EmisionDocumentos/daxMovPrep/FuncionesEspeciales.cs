using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace adcDocumentos
{
	public class FuncionesEspeciales
    {
		public string CtaPresupuestos(Keys keyData, DataGridView malla)
		{
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            {
                string nombre = "";
                string tipo = "S";
                if (keyData == Keys.F2)
                {
                    Presupuestos.MantPrespto busCta = new Presupuestos.MantPrespto();
                    dato = busCta.BuscaCta (ref nombre,ref tipo);
                    if (dato != "") { cell.Value = dato; }
                }
                else if (keyData == Keys.Return && dato.Length > 0)
                {
                    nombre = Presupuestos.OperacionesBuscaCta.NombreCuentaContable(ref dato);
                    if (nombre == "")
                    {
                        keyData = Keys.Cancel;
                        classMenSistem.mensajesErrorDocumento.ElCodigoNoExiste(dato);
                        cell.Value="";
                        return ""; 
                    }

                }
                malla.Rows[cell.RowIndex].Cells["Dia_ctanombrE"].Value = nombre;

            }

            return dato;

        }    //        VerificarClasificadoresContablesArticulo dato

            //if (cell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;
            //saltaEventosMalla = false;
            //totalizar();
            //mallaArticulo = null;
            //return resp;
        }
    }
