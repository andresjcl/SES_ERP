using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace DctosEmi
{
    public class ValidarDatos
    {
        public static bool ValidarDatosVentas(string NomDato,DataGridViewRow fila,daxAccs.propiedadesDaxAuto AutLocalizadas)
        {
            string strValor = fila.Cells[NomDato].ToString();
            Decimal numValor = 0;
            Decimal.TryParse(strValor, out numValor);
            Boolean resp = true;            
            switch (NomDato.ToUpper())
            {
                case "TRA_MEDIDA":
                    double auxn = 0;
                    if (fila.Cells["medidaArticulo"].Value.ToString() != strValor)
                    {
                        auxn = DaxInvent.MultMedida.MulMedida(strValor, fila.Cells["medidaArticulo"].Value.ToString());
                    }
                    if (auxn == 0) auxn = 1;
                    fila.Cells["tra_multiplo"].Value = auxn;
                    break;
                case "TRA_PORCENDES":
                    Decimal limiteDesc = 0;
                    if (AutLocalizadas.sinRegistro == false)
                    {
                        if (AutLocalizadas.DescuentoDocumentoPorcFijo > 0)
                        {
                            fila.Cells[NomDato].Value = AutLocalizadas.DescuentoDocumentoPorcFijo;
                        }
                        else
                        {
                            limiteDesc = AutLocalizadas.DescuentoUnitarioPorcMaximo;
                            if (numValor > limiteDesc && limiteDesc > 0)
                            {
                                fila.Cells[NomDato].Value = limiteDesc;
                            }
                        }
                    }
                    else
                    {
                        Decimal.TryParse(fila.Cells["LimiteDescuento"].Value.ToString(), out limiteDesc);
                        if (numValor > limiteDesc && limiteDesc > 0)  fila.Cells[NomDato].Value = limiteDesc;                        
                    }
                    break;
                case "DESPACHO":
                    decimal cantidad = 0;
                    Decimal.TryParse(fila.Cells[NomDato].Value.ToString(), out cantidad);
                    if (numValor > cantidad && cantidad > 0)
                    {
                        MessageBox.Show("No se puede despachar una cantidad mayor a la del documento");
                        resp = false;
                    }
                    break;
            }
            return resp;
        }

    }
}
