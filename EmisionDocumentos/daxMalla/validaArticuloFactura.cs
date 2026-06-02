using System;
using System.Data;
using System.Windows.Forms;
using classMenSistem;

namespace daxMallaDatos
{
    public class validaArticuloFactura
    {
        //mensajesErrorDocumento mensajesErrorDocumento = new mensajesErrorDocumento();
        public Boolean validarArticulo(ref adcArticulo.AdcArt opArt,ref sesSys.OpcDoc opcDoc,ref DataGridView malla,string sucursal,string bodega, string aFecha, string tipoDoc,string numDoc)
        {
            if (opArt == null || opArt.Art_codigo == "") { mensajesErrorDocumento.articuloNoExiste(opArt.Art_codigo); return false; }
            if (opArt.ArticuloSuspendido) {mensajesErrorDocumento.articuloSuspendido(opArt.Art_codigo); return false; }
            if (Convert.ToBoolean(opArt.Art_snmed)) { mensajesErrorDocumento.articuloNoVenta(opArt.Art_codigo); return false; }

            if (opcDoc.SNRepetir == 1) { if (SNRepetirCodigoFila(ref malla) == false) mensajesErrorDocumento.articuloNoPuedeRepetirse(opArt.Art_codigo); return false; } 

              //adcArticulosValores.ultimosValor saldoCosto = new adcArticulosValores.ultimosValor();
              //if (opcDoc.ClaveInventario == -1 && Convert.ToBoolean(opcDoc.SNSinExist) == false)
              //{
              //    saldosMalla salma = new saldosMalla();
              //    double SalMalla = salma.SaldoMalla(opArt.Art_codigo, malla) * opcDoc.ClaveInventario;
              //    double SalActual = saldoCosto.SaldoFecha(strConxAdcom, sucursal, bodega, aFecha, tipoDoc, numDoc);
              //    if ((SalActual + SalMalla) < Convert.ToDouble("0" + malla.CurrentRow.Cells["precioUni"].Value.ToString()) * Convert.ToDouble("0" + malla.CurrentRow.Cells["multiplo"].Value.ToString()))
              //    {
              //        return "No existe el saldo suficiente del artículo  " + opArt.Art_codigo + " en la bodega ";
              //    }
              //}
             //if (Convert.ToBoolean(opcDoc.NoPVPbajoCosto) == false)
             //{
             //      double UltCosto = saldoCosto.UltimoCostoCompra ("","",opArt.Art_codigo,false,"",tipoDoc,Convert.ToDateTime(aFecha),strConxAdcom,strConxDaxsys);
             //                  if (Convert.ToDouble("0" + malla.CurrentRow.Cells["precioUni"].Value.ToString()) <= UltCosto)
             //                       if (MessageBox.Show  ("El precio es menor al ultimo costo del producto Confirma Facturar " + opArt.Art_codigo,"Validación de artículos en documentos ", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
             //                       {return "Precio menor a último costo de adquisición";}
             //}

            return true;
        }
        
        private Boolean SNRepetirCodigoFila(ref DataGridView malla) 
        {
			DataGridViewCell cell = malla.CurrentCell;
			Int32 actPosicion = cell.RowIndex;
			string dato = cell.Value.ToString();
			foreach (DataGridViewRow row in malla.Rows)
			{
				if (row.Cells["codigo"].Value.ToString().ToUpper() == dato && row.Index != actPosicion)
				{                        
					return false;
				}
			}
            return true;
        }

    }
}
