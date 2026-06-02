using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace daxSri104
{
    static class formaMalls
    {
        internal static void armarmalla400(System.Windows.Forms.DataGridView malla400)
        {
            int dif = 0;
            int salta = 0;
            malla400.RowCount = 14;
            malla400.ColumnCount = 7;

            for (int i = 0; i < 14; i++)
            {
                if (i > 9) { dif = 22; } else { dif = 1; }
                if (i > 2) { salta = -1; } else { salta = 0; }
                if (i != 2)
                {
                    malla400.Rows[i].Cells[1].Value = (i + 400 + dif + salta).ToString();
                    malla400.Rows[i].Cells[3].Value = (i + 410 + dif + salta).ToString();
                }
                if (i < 3 || i == 9 || i > 11) malla400.Rows[i].Cells[5].Value = (i + 420 + dif).ToString();
                if (i == 9 || i > 11) malla400.Rows[i].Cells[5].Value = (i + 420 + dif + salta).ToString();

            }

            malla400.Columns[1].DefaultCellStyle.BackColor = Color.SteelBlue;
            malla400.Columns[3].DefaultCellStyle.BackColor = Color.SteelBlue;
            malla400.Columns[5].DefaultCellStyle.BackColor = Color.SteelBlue;

            malla400.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            malla400.Columns[3].DefaultCellStyle.ForeColor = Color.White;
            malla400.Columns[5].DefaultCellStyle.ForeColor = Color.White;

            malla400.Columns[0].ReadOnly = true;
            malla400.Columns[1].ReadOnly = true;
            malla400.Columns[3].ReadOnly = true;
            malla400.Columns[5].ReadOnly = true;

            malla400.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla400.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla400.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            malla400.Columns[0].Width = 450;
            malla400.Columns[1].Width = 30;
            malla400.Columns[2].Width = 100;
            malla400.Columns[3].Width = 30;
            malla400.Columns[4].Width = 100;
            malla400.Columns[5].Width = 30;
            malla400.Columns[6].Width = 100;

            AtenuarCeldas(2, 2, 1, 4, (malla400), true);
            AtenuarCeldas(3, 8, 5, 6, (malla400), true);
            AtenuarCeldas(10, 11, 5, 6, (malla400), true);
            AtenuarCeldas(11, 12, 1, 2, malla400, true);

            malla400.Columns[0].HeaderText = "Resumen de ventas y otras operaciones del período que declara";
            malla400.Columns[2].HeaderText = "ValorBruto";
            malla400.Columns[4].HeaderText = "ValorNeto";
            malla400.Columns[6].HeaderText = "ImpuestoGenerado";

            malla400.Rows[0].Cells[0].Value = "VENTAS LOCALES (EXCLUYE ACTIVOS FIJOS) GRAVADAS TARIFA DIFERENTE DE CERO";
            malla400.Rows[1].Cells[0].Value = "VENTAS DE ACTIVOS FIJOS GRAVADAS TARIFA DIFERENTE DE CERO";
            malla400.Rows[2].Cells[0].Value = "IVA GENERADO EN LA DIFERENCIA ENTRE VENTAS Y NOTAS DE CREDITO CON DISTINTA TARIFA";
            malla400.Rows[3].Cells[0].Value = "VENTAS LOCALES (EXCLUYE ACTIVOS FIJOS) GRAVADAS TARIFA 0% QUE NO DAN DERECHO A CREDITO TRIBUTARIO)";
            malla400.Rows[4].Cells[0].Value = "VENTAS DE ACTIVOS FIJOS GRAVADAS TARIFA 0% QUE NO DAN DERECHO A CREDITO TRIBUTARIO";
            malla400.Rows[5].Cells[0].Value = "VENTAS LOCALES (EXCLUYE ACTIVOS FIJOS) GRAVADAS TARIFA 0% QUE DAN DERECHO A CREDITO TRIBUTARIO";
            malla400.Rows[6].Cells[0].Value = "VENTAS DE ACTIVOS FIJOS GRAVADAS TARIFA 0% QUE DAN DERECHO A CREDITO TRIBUTARIO";
            malla400.Rows[7].Cells[0].Value = "EXPORTACIONES DE BIENES";
            malla400.Rows[8].Cells[0].Value = "EXPORTACIONES DE SERVICIOS";
            malla400.Rows[9].Cells[0].Value = "TOTAL VENTAS Y OTRAS OPERACIONES";
            malla400.Rows[10].Cells[0].Value = "TRANSFERENCIAS NO OBJETO DE IVA";
            malla400.Rows[11].Cells[0].Value = "NOTAS DE CRÉDITO TARIFA 0% POR COMPENSAR PRÓXIMO MES (INFORMATIVO)";
            malla400.Rows[12].Cells[0].Value = "NOTAS DE CRÉDITO TARIFA DIFERENTE DE CERO POR COMPENSAR PRÓXIMO MES (INFORMATIVO)";
            malla400.Rows[13].Cells[0].Value = "INGRESOS POR REEMBOLSO COMO INTERMEDIARIO ";
            //malla400.Rows[i].HeaderCell = "Not.Créd.por transferencias netas objeto iva por compensar próximo mes";
            //malla400.Rows[i].HeaderCell = "Ingreso neto por concepto reembolso de gastos del intermediario";
            //malla400.Rows[i].HeaderCell = "Presuntivo Salas de Juego (Bingo - Mecánicos) y otros juegos de Azar ";

        }
        internal static void armarmalla500(System.Windows.Forms.DataGridView malla500)
        {
            int dif = 0;
            int salta = 0;
            malla500.RowCount = 18;
            malla500.ColumnCount = 7;

            for (int i = 0; i < 18; i++)
            {
                if (i > 10) { dif = 21; } else { dif = 0; }
                if (i > 5) { salta = -1; } else { salta = 0; }
                if (i != 6)
                {
                    malla500.Rows[i].Cells[1].Value = (i + 500 + dif + salta).ToString();
                    malla500.Rows[i].Cells[3].Value = (i + 510 + dif + salta).ToString();
                }
                if (i < 7 || i == 10 ) malla500.Rows[i].Cells[5].Value = (i + 520 + dif).ToString();
                if (i == 10 || i > 13) malla500.Rows[i].Cells[5].Value = (i + 520 + dif + salta).ToString();

            }
            malla500.Rows[16].Cells[5].Value = "563";
            malla500.Rows[17].Cells[5].Value = "564";

            malla500.Columns[1].DefaultCellStyle.BackColor = Color.SteelBlue;
            malla500.Columns[3].DefaultCellStyle.BackColor = Color.SteelBlue;
            malla500.Columns[5].DefaultCellStyle.BackColor = Color.SteelBlue;

            malla500.Columns[1].DefaultCellStyle.ForeColor = Color.White;
            malla500.Columns[3].DefaultCellStyle.ForeColor = Color.White;
            malla500.Columns[5].DefaultCellStyle.ForeColor = Color.White;

            malla500.Columns[0].ReadOnly = true;
            malla500.Columns[1].ReadOnly = true;
            malla500.Columns[3].ReadOnly = true;
            malla500.Columns[5].ReadOnly = true;

            malla500.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla500.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla500.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            malla500.Columns[0].Width = 450;
            malla500.Columns[1].Width = 30;
            malla500.Columns[2].Width = 100;
            malla500.Columns[3].Width = 30;
            malla500.Columns[4].Width = 100;
            malla500.Columns[5].Width = 30;
            malla500.Columns[6].Width = 100;

            AtenuarCeldas(6, 6, 1, 4, (malla500), true);
            AtenuarCeldas(7, 9, 5, 6, (malla500), true);
            AtenuarCeldas(11, 13, 5, 6, (malla500), true);
            AtenuarCeldas(13, 14, 1, 2, malla500, true);
            AtenuarCeldas(16, 17, 1, 2, malla500, true);

            malla500.Columns[0].HeaderText = "Resumen de adquisiciones y pagos del período que declara";
            malla500.Columns[2].HeaderText = "ValorBruto";
            malla500.Columns[4].HeaderText = "ValorNeto";
            malla500.Columns[6].HeaderText = "ImpuestoGenerado";


   			malla500.Rows[0].Cells[0].Value ="ADQUISICIONES Y PAGOS (EXCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA DIFERENTE DE CERO (CON DERECHO A CRÉDITO TRIBUTARIO)";
			malla500.Rows[1].Cells[0].Value ="ADQUISICIONES LOCALES DE ACTIVOS FIJOS GRAVADOS TARIFA DIFERENTE DE CERO (CON DERECHO A CRÉDITO TRIBUTARIO)";
			malla500.Rows[2].Cells[0].Value ="OTRAS ADQUISICIONES Y PAGOS GRAVADOS TARIFA DIFERENTE DE CERO (SIN DERECHO A CRÉDITO TRIBUTARIO)";
			malla500.Rows[3].Cells[0].Value ="IMPORTACIONES DE SERVICIOS GRAVADOS TARIFA DIFERENTE DE CERO (SIN DERECHO A CRÉDITO TRIBUTARIO)";
			malla500.Rows[4].Cells[0].Value ="IMPORTACIONES DE BIENES (EXCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA DIFERENTE DE CERO";
			malla500.Rows[5].Cells[0].Value ="IMPORTACIONES DE ACTIVOS FIJOS GRAVADOS TARIFA DIFERENTE DE CERO";
			malla500.Rows[6].Cells[0].Value ="IVA GENERADO EN LA DIFERENCIA ENTRE ADQUISICIONES Y NOTAS DE CREDITO CON DISTINTA TARIFA";
			malla500.Rows[7].Cells[0].Value ="IMPORTACIONES DE BIENES (INCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA 0%";
			malla500.Rows[8].Cells[0].Value ="ADQUISICIONES Y PAGOS (INCLUYE ACTIVOS FIJOS) GRAVADOS TARIFA 0%";
			malla500.Rows[9].Cells[0].Value ="ADQUISICIONES REALIZADAS A CONTRIBUYENTES RISE ";
			malla500.Rows[10].Cells[0].Value ="TOTAL ADQUISICIONES Y PAGOS ";
			malla500.Rows[11].Cells[0].Value ="ADQUISICIONES NO OBJETO DE IVA";
			malla500.Rows[12].Cells[0].Value ="ADQUISICIONES EXCENTAS DEL PAGO DE IVA";
			malla500.Rows[13].Cells[0].Value ="NOTAS DE CRÉDITO TARIFA 0% POR COMPENSAR PRÓXIMO MES";
			malla500.Rows[14].Cells[0].Value ="NOTAS DE CRÉDITO TARIFA DIFERENTE DE CERO POR COMPENSAR PRÓXIMO MES";
			malla500.Rows[15].Cells[0].Value ="PAGOS NETOS POR REEMBOLSO COMO INTERMEDIARIO";
			malla500.Rows[16].Cells[0].Value ="FACTOR DE PROPORCIONALIDAD PARA CRÉDITO TRIBUTARIO";
			malla500.Rows[17].Cells[0].Value ="CREDITO TRIBUTARIO APLICACBLE EN ESTE PERÍODO(DE ACUERDO AL FACTOR DE PROPORCIONALIDAD O A SU CONTABILIDAD)";

            AtenuarCeldas(16, 17, 1, 4,malla500,true);

        }
        internal static void armarmalla600(System.Windows.Forms.DataGridView malla600)
        {
            malla600.RowCount = 21;
            malla600.ColumnCount = 3;

            malla600.Columns[1].DefaultCellStyle.BackColor = Color.SteelBlue;

            malla600.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            malla600.Columns[0].ReadOnly = true;
            malla600.Columns[1].ReadOnly = true;

            malla600.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            malla600.Columns[0].Width = 650;
            malla600.Columns[1].Width = 30;
            malla600.Columns[2].Width = 100;

            malla600.Columns[0].HeaderText = "RESUMEN IMPOSITIVO: AGENTE DE PERCEPCIÓN DELIMPUESTO AL VALOR AGREGADO";

            malla600.Rows[0].Cells[0].Value = "IMPUESTO CAUSADO (Si diferencia campo 499-564 es mayor que cero)";
            malla600.Rows[1].Cells[0].Value = "CRÉDITO TRIBUTARIO APLICABLE EN ESTE PERÍODO (Si diferencia campo 499-564 es menor que cero)";
            malla600.Rows[2].Cells[0].Value = "(-) COMPENSACIÓN DE IVA POR VENTAS EFECTUADAS EN SU TOTALIDAD CON MEDIO ELECTRÓNICO ";
            malla600.Rows[3].Cells[0].Value = "(-) COMPENSACIÓN DE IVA POR VENTAS  EFECTUADAS EN  ZONAS AFECTADAS LEY DE SOLIDARIDAD";
            malla600.Rows[4].Cells[0].Value = "POR ADQUISICIONES E IMPORTACIONES (Traslada el campo 615 de la declaración del período anterior) ";
            malla600.Rows[5].Cells[0].Value = "POR RETENCIONES EN LA FUENTE DE IVA QUE LE HAN SIDO EFECTUADAS (Traslada el campo 617 de la declaración del período anterior)";
            malla600.Rows[6].Cells[0].Value = "POR COMPENSACIÓN DE IVA POR VENTAS EFECTUADAS CON MEDIO  ELECTRÓNICO  (Traslada el campo 618 de la declaración del período anterior)";
            malla600.Rows[7].Cells[0].Value = "POR COMPENSACIÓN DE IVA POR VENTAS EFECTUADAS EN ZONAS AFECTADAS  LEY DE SOLIDARIDAD  (Traslada el campo 619 de la declaración del período anterior)";
            malla600.Rows[8].Cells[0].Value = "(- )RETENCIONES EN LA FUENTE DE IVA QUE LE HAN SIDO EFECTUADAS EN ESTE PERÍODO";
            malla600.Rows[9].Cells[0].Value = "(+) AJUSTE POR IVA DEVUELTO O DESCONTADO POR ADQUISICIONES EFECTUADAS CON MEDIO ELECTRÓNICO ";
            malla600.Rows[10].Cells[0].Value = "(+) AJUSTE POR IVA DEVUELTO O DESCONTADO EN ADQUISICIONES EFECTUADAS EN ZONAS AFECTADAS - LEY DE SOLIDARIDAD";
            malla600.Rows[11].Cells[0].Value = "(+) AJUSTE POR IVA DEVUELTO E IVA RECHAZADO IMPUTABLE AL CRÉDITO TRIBUTARIO EN EL MES (Por concepto de devoluciones de IVA)";
            malla600.Rows[12].Cells[0].Value = "(+) AJUSTE POR IVA DEVUELTO E IVA RECHAZADO IMPUTABLE AL CRÉDITO TRIBUTARIO EN EL MES (Por concepto de retenciones en la fuente de IVA)";
            malla600.Rows[13].Cells[0].Value = "(+) AJUSTE POR IVA DEVUELTO POR OTRAS INSTITUCIONES DEL SECTOR PÚBLICO IMPUTABLE AL CRÉDITO TRIBUTARIO EN EL MES";
            malla600.Rows[14].Cells[0].Value = "POR ADQUISICIONES E IMPORTACIONES";
            malla600.Rows[15].Cells[0].Value = "POR RETENCIONES EN LA FUENTE DE IVA QUE LE HAN SIDO EFECTUADAS";
            malla600.Rows[16].Cells[0].Value = "POR COMPENSACIÓN DE IVA POR VENTAS EFECTUADAS CON MEDIO ELECTRÓNICO ";
            malla600.Rows[17].Cells[0].Value = "POR COMPENSACIÓN DE IVA POR VENTAS EFECTUADAS EN ZONAS AFECTADAS  LEY DE SOLIDARIDAD";
            malla600.Rows[18].Cells[0].Value = "SUBTOTAL A PAGAR Si 601-602-603-604-605-606-607-608-609+610+611+612+613+614 > 0";
            malla600.Rows[19].Cells[0].Value = "IVA PRESUNTIVO DE SALAS DE JUEGO (BINGO MECÁNICOS) Y OTROS JUEGOS DE AZAR (Aplica para Ejercicios Anteriores al 2013)";
            malla600.Rows[20].Cells[0].Value = "TOTAL IMPUESTO A PAGAR POR PERCEPCION (620 + 621) ";

            malla600.Rows[0].Cells[1].Value = "601";
            malla600.Rows[1].Cells[1].Value = "602";
            malla600.Rows[2].Cells[1].Value = "603";
            malla600.Rows[3].Cells[1].Value = "604";
            malla600.Rows[4].Cells[1].Value = "605";
            malla600.Rows[5].Cells[1].Value = "606";
            malla600.Rows[6].Cells[1].Value = "607";
            malla600.Rows[7].Cells[1].Value = "608";
            malla600.Rows[8].Cells[1].Value = "609";
            malla600.Rows[9].Cells[1].Value = "610";
            malla600.Rows[10].Cells[1].Value = "611";
            malla600.Rows[11].Cells[1].Value = "612";
            malla600.Rows[12].Cells[1].Value = "613";
            malla600.Rows[13].Cells[1].Value = "614";
            malla600.Rows[14].Cells[1].Value = "615";
            malla600.Rows[15].Cells[1].Value = "617";
            malla600.Rows[16].Cells[1].Value = "618";
            malla600.Rows[17].Cells[1].Value = "619";
            malla600.Rows[18].Cells[1].Value = "620";
            malla600.Rows[19].Cells[1].Value = "621";
            malla600.Rows[20].Cells[1].Value = "699";
        }
        internal static void armarmalla700(System.Windows.Forms.DataGridView malla700)
        {
            malla700.RowCount = 11;
            malla700.ColumnCount = 3;

            malla700.Columns[1].DefaultCellStyle.BackColor = Color.SteelBlue;

            malla700.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            malla700.Columns[0].ReadOnly = true;
            malla700.Columns[1].ReadOnly = true;

            malla700.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            malla700.Columns[0].Width = 650;
            malla700.Columns[1].Width = 30;
            malla700.Columns[2].Width = 100;

            malla700.Columns[0].HeaderText = "RESUMEN IMPOSITIVO: AGENTE DE PERCEPCIÓN DELIMPUESTO AL VALOR AGREGADO";

            malla700.Rows[0].Cells[0].Value = "RETENCIÓN DEL 10%";
            malla700.Rows[1].Cells[0].Value = "RETENCIÓN DEL 20%";
            malla700.Rows[2].Cells[0].Value = "RETENCIÓN DEL 30%";
            malla700.Rows[3].Cells[0].Value = "RETENCIÓN DEL 50%";
            malla700.Rows[4].Cells[0].Value = "RETENCIÓN DEL 70%";
            malla700.Rows[5].Cells[0].Value = "RETENCIÓN DEL 100%";
            malla700.Rows[6].Cells[0].Value = "TOTAL IMPUESTO RETENIDO  (721+723+725+727+729+731)";
            malla700.Rows[7].Cells[0].Value = "DEVOLUCIÓN PROVISIONAL DE IVA MEDIANTE COMPENSACIÓN CON RETENCIONES EFECTUADAS ";
            malla700.Rows[8].Cells[0].Value = "TOTAL IMPUESTO A PAGAR POR RETENCIÓN   (799-800)";
            malla700.Rows[9].Cells[0].Value = "TOTAL CONSOLIDADO DE IMPUESTO AL VALOR AGREGADO (699+ 801)";
            malla700.Rows[10].Cells[0].Value = "PAGO PREVIO";

            malla700.Rows[0].Cells[1].Value = "721";
            malla700.Rows[1].Cells[1].Value = "723";
            malla700.Rows[2].Cells[1].Value = "725";
            malla700.Rows[3].Cells[1].Value = "727";
            malla700.Rows[4].Cells[1].Value = "729";
            malla700.Rows[5].Cells[1].Value = "731";
            malla700.Rows[6].Cells[1].Value = "799";
            malla700.Rows[7].Cells[1].Value = "800";
            malla700.Rows[8].Cells[1].Value = "801";
            malla700.Rows[9].Cells[1].Value = "859";
            malla700.Rows[10].Cells[1].Value = "890";
        }
        private static void AtenuarCeldas(int R1, int R2, int c1, int c2, DataGridView Malla, Boolean borra = false)
        {

            for (int I = R1; I <= R2; I++)
            {
                for (int j = c1; j <= c2; j++)
                {
                    Malla.Rows[I].Cells[j].Style.BackColor = Color.SteelBlue;
                    if (borra) { Malla.Rows[I].Cells[j].Value = ""; }
                    Malla.Rows[I].Cells[j].ReadOnly = true;
                }
            }
        }

    }
}
