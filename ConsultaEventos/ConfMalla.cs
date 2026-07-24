using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace registraEvntos
{
    class ConfMalla
    {
        public static int estado = 0;
        public void pegar(DataGridView malla, DataGridViewCell cellCopia, Int32 tipo)
        {
            if (tipo == 1)
            {
                try
                {
                    malla.CurrentCell.Value = cellCopia.Value;
                    return;
                }
                catch { MessageBox.Show("No se puede efectuar esta acción"); return; }
            }                
            if (tipo == 2) { pegarLinea(malla, cellCopia.RowIndex); }
            if (tipo == 3) { pegarColumna(malla, cellCopia.ColumnIndex); }
        }
        private void pegarLinea(DataGridView malla,Int32 indCopia)
        {
            try
            {
                malla.Rows[indCopia].DefaultCellStyle.BackColor = Color.White;
                int ind = malla.CurrentCell.RowIndex;
                for (int i = 0; i < malla.Columns.Count; i++)
                {
                    try
                    {
                        malla.Rows[ind].Cells[i].Value = malla.Rows[indCopia].Cells[i].Value;
                        if (estado != 0) return;
                    }
                    catch { MessageBox.Show("No se puede efectuar esta acción"); return; }
                }
            }
            catch { return; }
        }
        private void pegarColumna(DataGridView malla, Int32 indCopia)
        {
            malla.Columns[indCopia].DefaultCellStyle.BackColor = Color.White;
            int ind = malla.CurrentCell.ColumnIndex;
            for (int i = 0; i < malla.Rows.Count; i++)
            {
                try
                {
                    malla.Rows[i].Cells[ind].Value = malla.Rows[i].Cells[indCopia].Value;
                    if (estado != 0) return;
                }
                catch 
                { 
                    MessageBox.Show("No se puede efectuar esta acción"); 
                    return;
                }
            }
        }
        public void ConfigurarMalla(DataGridView malla, Int32 tipoTra)
        {
            string formato = ("0.00;(0.00);\"\"");
            if (tipoTra == 1)
            {

                    malla.Columns["baseNoGraIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImponible"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpGrav"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpExe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["montoIce"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["montoIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetBien10"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetServ20"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valorRetBienes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valorRetServicios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetServ100"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpAir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["porcentajeAir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetAir"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["imRentaSoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["PrecCajBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["codRetAir1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpAir1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["porcentajeAir1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetAir1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["imRentaSoc1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["PrecCajBan1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["codRetAir2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpAir2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["porcentajeAir2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetAir2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["imRentaSoc2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["PrecCajBan2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpAir3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["porcentajeAir3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valRetAir3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["imRentaSoc3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["PrecCajBan3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                    malla.Columns["baseNoGraIva"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImponible"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpGrav"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpExe"].DefaultCellStyle.Format = formato;
                    malla.Columns["montoIce"].DefaultCellStyle.Format = formato;
                    malla.Columns["montoIva"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetBien10"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetServ20"].DefaultCellStyle.Format = formato;
                    malla.Columns["valorRetBienes"].DefaultCellStyle.Format = formato;
                    malla.Columns["valorRetServicios"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetServ100"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpAir"].DefaultCellStyle.Format = formato;
                    malla.Columns["porcentajeAir"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetAir"].DefaultCellStyle.Format = formato;
                    malla.Columns["imRentaSoc"].DefaultCellStyle.Format = formato;
                    malla.Columns["PrecCajBan"].DefaultCellStyle.Format = formato;
                    malla.Columns["codRetAir1"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpAir1"].DefaultCellStyle.Format = formato;
                    malla.Columns["porcentajeAir1"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetAir1"].DefaultCellStyle.Format = formato;
                    malla.Columns["imRentaSoc1"].DefaultCellStyle.Format = formato;
                    malla.Columns["PrecCajBan1"].DefaultCellStyle.Format = formato;
                    malla.Columns["codRetAir2"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpAir2"].DefaultCellStyle.Format = formato;
                    malla.Columns["porcentajeAir2"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetAir2"].DefaultCellStyle.Format = formato;
                    malla.Columns["imRentaSoc2"].DefaultCellStyle.Format = formato;
                    malla.Columns["PrecCajBan2"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpAir3"].DefaultCellStyle.Format = formato;
                    malla.Columns["porcentajeAir3"].DefaultCellStyle.Format = formato;
                    malla.Columns["valRetAir3"].DefaultCellStyle.Format = formato;
                    malla.Columns["imRentaSoc3"].DefaultCellStyle.Format = formato;
                    malla.Columns["PrecCajBan3"].DefaultCellStyle.Format = formato;
                                
                    malla.Columns["codSustento"].HeaderText = "Sus";
                    malla.Columns["tpIdProv"].HeaderText = "TI";
                    malla.Columns["tipoComprobante"].HeaderText = "Doc";
                    malla.Columns["establecimiento"].HeaderText = "Est";
                    malla.Columns["PuntoEmision"].HeaderText = "Emi";
                    malla.Columns["parterel"].HeaderText = "Rel";
                    malla.Columns["baseNoGraIva"].HeaderText = "basNoIva";
                    malla.Columns["baseImponible"].HeaderText = "basIva_0";
                    malla.Columns["baseImpGrav"].HeaderText = "basConIva";
                    malla.Columns["baseImpExe"].HeaderText = "basExIva";
                    malla.Columns["montoIce"].HeaderText = "valIce";
                    malla.Columns["montoIva"].HeaderText = "MontoIva";
                    malla.Columns["valRetBien10"].HeaderText = "RetB10";
                    malla.Columns["valRetServ20"].HeaderText = "RetS20";
                    malla.Columns["valorRetBienes"].HeaderText = "RetB30";
                    malla.Columns["valorRetServicios"].HeaderText = "RetS70";
                    malla.Columns["valRetServ100"].HeaderText = "RetS100";
                    malla.Columns["pagoLocExt"].HeaderText = "Pag";
                    malla.Columns["paisEfecPago"].HeaderText = "Pais";
                    malla.Columns["aplicConvDobTrib"].HeaderText = "DbT";
                    malla.Columns["pagExtSujRetNorLeg"].HeaderText = "ExS";
                    malla.Columns["formaPago"].HeaderText = "Fpg";
                    malla.Columns["pagoregfis"].HeaderText = "Prf";
                    malla.Columns["codretair"].HeaderText = "Ret";
                    malla.Columns["codretair1"].HeaderText = "Ret1";
                    malla.Columns["codretair2"].HeaderText = "Ret2";
                    malla.Columns["codretair3"].HeaderText = "Ret3";

                    malla.Columns["porcentajeAir"].HeaderText = "%Air";
                    malla.Columns["valRetAir"].HeaderText = "ValAir";
                    malla.Columns["fechaPagoDiv"].HeaderText = "FechaDiv";
                    malla.Columns["imRentaSoc"].HeaderText = "IrSocied";
                    malla.Columns["anioUtDiv"].HeaderText = "AñoUD";
                    malla.Columns["NumCajBan"].HeaderText = "CajBan";
                    malla.Columns["PrecCajBan"].HeaderText = "ValCajB";

                    malla.Columns["porcentajeAir1"].HeaderText = "%Air1";
                    malla.Columns["valRetAir1"].HeaderText = "ValAir1";
                    malla.Columns["fechaPagoDiv1"].HeaderText = "FechaDiv1";
                    malla.Columns["imRentaSoc1"].HeaderText = "IrSocied1";
                    malla.Columns["anioUtDiv1"].HeaderText = "AñoUD1";
                    malla.Columns["NumCajBan1"].HeaderText = "CajBan1";
                    malla.Columns["PrecCajBan1"].HeaderText = "ValCajB1";

                    malla.Columns["porcentajeAir2"].HeaderText = "%Air2";
                    malla.Columns["valRetAir2"].HeaderText = "ValAir2";
                    malla.Columns["fechaPagoDiv2"].HeaderText = "FechaDiv2";
                    malla.Columns["imRentaSoc2"].HeaderText = "IrSocied2";
                    malla.Columns["anioUtDiv2"].HeaderText = "AñoUD2";
                    malla.Columns["NumCajBan2"].HeaderText = "CajBan2";
                    malla.Columns["PrecCajBan2"].HeaderText = "ValCajB2";

                    malla.Columns["porcentajeAir3"].HeaderText = "%Air3";
                    malla.Columns["valRetAir3"].HeaderText = "ValAir3";
                    malla.Columns["fechaPagoDiv3"].HeaderText = "FechaDiv3";
                    malla.Columns["imRentaSoc3"].HeaderText = "IrSocied3";
                    malla.Columns["anioUtDiv3"].HeaderText = "AñoUD3";
                    malla.Columns["NumCajBan3"].HeaderText = "CajBan3";
                    malla.Columns["PrecCajBan3"].HeaderText = "ValCajB3";

                malla.Columns["codSustento"].DefaultCellStyle.BackColor = Color.LightYellow ;
                malla.Columns["tpIdProv"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["idProv"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["parteRel"].DefaultCellStyle.BackColor = Color.LightYellow;
                //malla.Columns["tipoComprobante"].DefaultCellStyle.BackColor = Color.Aqua;
                //malla.Columns["fechaRegistro"].DefaultCellStyle.BackColor = Color.Aqua;
                //malla.Columns["establecimiento"].DefaultCellStyle.BackColor = Color.Aqua;
                //malla.Columns["puntoEmision"].DefaultCellStyle.BackColor = Color.Aqua;
                //malla.Columns["secuencial"].DefaultCellStyle.BackColor = Color.Aqua;
                //malla.Columns["fechaEmision"].DefaultCellStyle.BackColor = Color.Aqua;
                //malla.Columns["autorizacion"].DefaultCellStyle.BackColor = Color.Aqua;
                malla.Columns["baseNoGraIva"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["baseImponible"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["baseImpGrav"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["baseImpExe"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["montoIce"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["montoIva"].DefaultCellStyle.BackColor = Color.LightYellow;
                //malla.Columns["valRetBien10"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //malla.Columns["valRetServ20"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //malla.Columns["valorRetBienes"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //malla.Columns["valorRetServicios"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                //malla.Columns["valRetServ100"].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                malla.Columns["pagoLocExt"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["paisEfecPago"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["aplicConvDobTrib"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["pagExtSujRetNorLeg"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["pagoRegFis"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["formaPago"].DefaultCellStyle.BackColor = Color.LightYellow;
                //malla.Columns["codRetAir"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["baseImpAir"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["porcentajeAir"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["valRetAir"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["fechaPagoDiv"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["imRentaSoc"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["anioUtDiv"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["NumCajBan"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["PrecCajBan"].DefaultCellStyle.BackColor = Color;
                malla.Columns["codRetAir1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["baseImpAir1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["porcentajeAir1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["valRetAir1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["fechaPagoDiv1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["imRentaSoc1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["anioUtDiv1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["NumCajBan1"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["PrecCajBan1"].DefaultCellStyle.BackColor = Color.LightYellow;
                //malla.Columns["codRetAir2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["baseImpAir2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["porcentajeAir2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["valRetAir2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["fechaPagoDiv2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["imRentaSoc2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["anioUtDiv2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["NumCajBan2"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["PrecCajBan2"].DefaultCellStyle.BackColor = Color;
                malla.Columns["codRetAir3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["baseImpAir3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["porcentajeAir3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["valRetAir3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["fechaPagoDiv3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["imRentaSoc3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["anioUtDiv3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["NumCajBan3"].DefaultCellStyle.BackColor = Color.LightYellow;
                malla.Columns["PrecCajBan3"].DefaultCellStyle.BackColor = Color.LightYellow;
                //malla.Columns["estabRetencion1"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["ptoEmiRetencion1"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["secRetencion1"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["autRetencion1"].DefaultCellStyle.BackColor = Color;
                //malla.Columns["fechaEmiRet1"].DefaultCellStyle.BackColor = Color;

                malla.Columns["codSustento"].Width = 40;
                malla.Columns["tpIdProv"].Width = 40;
                malla.Columns["idProv"].Width = 60;
                malla.Columns["parteRel"].Width = 40;
                malla.Columns["tipoComprobante"].Width = 40;
                malla.Columns["fechaRegistro"].Width = 80;
                malla.Columns["establecimiento"].Width = 50;
                malla.Columns["puntoEmision"].Width = 50;
                malla.Columns["secuencial"].Width = 90;
                malla.Columns["fechaEmision"].Width = 80;
                malla.Columns["autorizacion"].Width = 300;
                malla.Columns["baseNoGraIva"].Width = 90;
                malla.Columns["baseImponible"].Width = 90;
                malla.Columns["baseImpGrav"].Width = 90;
                malla.Columns["baseImpExe"].Width = 90;
                malla.Columns["montoIce"].Width = 90;
                malla.Columns["montoIva"].Width = 90;
                malla.Columns["valRetBien10"].Width = 90;
                malla.Columns["valRetServ20"].Width = 90;
                malla.Columns["valorRetBienes"].Width = 90;
                malla.Columns["valorRetServicios"].Width = 90;
                malla.Columns["valRetServ100"].Width = 90;
                malla.Columns["pagoLocExt"].Width = 40;
                malla.Columns["paisEfecPago"].Width = 40;
                malla.Columns["aplicConvDobTrib"].Width = 40;
                malla.Columns["pagExtSujRetNorLeg"].Width = 40;
                malla.Columns["pagoRegFis"].Width = 40;
                malla.Columns["formaPago"].Width = 40;
                malla.Columns["codRetAir"].Width = 40;
                malla.Columns["baseImpAir"].Width = 90;
                malla.Columns["porcentajeAir"].Width = 50;
                malla.Columns["valRetAir"].Width = 90;
                malla.Columns["fechaPagoDiv"].Width = 80;
                malla.Columns["imRentaSoc"].Width = 90;
                malla.Columns["anioUtDiv"].Width = 50;
                malla.Columns["NumCajBan"].Width = 50;
                malla.Columns["PrecCajBan"].Width = 60;
                malla.Columns["codRetAir1"].Width = 40;
                malla.Columns["baseImpAir1"].Width = 90;
                malla.Columns["porcentajeAir1"].Width = 50;
                malla.Columns["valRetAir1"].Width = 90;
                malla.Columns["fechaPagoDiv1"].Width = 80;
                malla.Columns["imRentaSoc1"].Width = 90;
                malla.Columns["anioUtDiv1"].Width = 50;
                malla.Columns["NumCajBan1"].Width = 50;
                malla.Columns["PrecCajBan1"].Width = 50;
                malla.Columns["codRetAir2"].Width = 40;
                malla.Columns["baseImpAir2"].Width = 90;
                malla.Columns["porcentajeAir2"].Width = 40;
                malla.Columns["valRetAir2"].Width = 90;
                malla.Columns["fechaPagoDiv2"].Width = 80;
                malla.Columns["imRentaSoc2"].Width = 90;
                malla.Columns["anioUtDiv2"].Width = 50;
                malla.Columns["NumCajBan2"].Width = 40;
                malla.Columns["PrecCajBan2"].Width = 50;
                malla.Columns["codRetAir3"].Width = 40;
                malla.Columns["baseImpAir3"].Width = 90;
                malla.Columns["porcentajeAir3"].Width = 40;
                malla.Columns["valRetAir3"].Width = 90;
                malla.Columns["fechaPagoDiv3"].Width = 80;
                malla.Columns["imRentaSoc3"].Width = 90;
                malla.Columns["anioUtDiv3"].Width = 50;
                malla.Columns["NumCajBan3"].Width = 50;
                malla.Columns["PrecCajBan3"].Width = 50;
                malla.Columns["estabRetencion1"].Width = 50;
                malla.Columns["ptoEmiRetencion1"].Width = 50;
                malla.Columns["secRetencion1"].Width = 90;
                malla.Columns["autRetencion1"].Width = 300;
                malla.Columns["fechaEmiRet1"].Width = 80;                                                         
            }
            else if (tipoTra == 2)
            {
                    malla.Columns["tpIdCliente"].HeaderText = "TI";
                    //malla.Columns["parteRelVtas"].HeaderText = "Rel";
                    malla.Columns["tipoComprobante"].HeaderText = "TC";

                    malla.Columns["baseNoGraIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImponible"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["baseImpGrav"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                   // malla.Columns["baseImpExe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["montoIce"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["montoIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valorRetIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    malla.Columns["valorRetRenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    malla.Columns["baseNoGraIva"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImponible"].DefaultCellStyle.Format = formato;
                    malla.Columns["baseImpGrav"].DefaultCellStyle.Format = formato;
                   // malla.Columns["baseImpExe"].DefaultCellStyle.Format = formato;
                    malla.Columns["montoIce"].DefaultCellStyle.Format = formato;
                    malla.Columns["montoIva"].DefaultCellStyle.Format = formato;
                    malla.Columns["valorRetIva"].DefaultCellStyle.Format = formato;
                    malla.Columns["valorRetRenta"].DefaultCellStyle.Format = formato;
            }
        }
    }
}
