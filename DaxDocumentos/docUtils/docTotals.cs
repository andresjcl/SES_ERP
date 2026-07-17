using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace DctosEmi
{
    public class docTotals
    {
        public Decimal ValorEfec = 0;
        public Decimal ValorCon = 0;
        public Decimal TotSiva = 0;
        public Decimal TotSerSIva = 0;
        public Decimal TotSerCIva = 0;
        public Decimal totdessiva = 0;
        public Decimal TotDesSer = 0;
        public Decimal TotDescuentos = 0;
        public Decimal totdesciva = 0;
        public Decimal TotDesArt = 0;
        public Decimal TotCiva = 0;
        public Decimal TotArtSIva = 0;
        public Decimal TotArtCIva = 0;
        public Decimal TotUnd=0;
        public Decimal TotPes=0;
        public Decimal TotDesu = 0;
        public Decimal TotDesCIva1=0;
        public Decimal TotDesSIva1=0;
        public Decimal TotSer=0;
        public Decimal TotCosArt=0;
        public Decimal TotAcf=0;
        public Decimal TotArt=0;
        public decimal TotIva = 0;
        public decimal TotIva5 = 0;
        public decimal TotIva15 = 0;
        public Decimal TotImp1 =0;
        public Decimal TotImp2 = 0;
        public Decimal TotImp3 = 0;
        public Decimal TotVta = 0;
        public Decimal TotVta5 = 0;
        public Decimal TotVta15 = 0;
        public Decimal SubTotalSIva = 0;
        public Decimal Subtotalciva = 0;
        public Decimal totalFinal = 0;
        public Decimal totalvalorDeIva = 0;
        public Decimal totalvalorDeIva5 = 0;
        public Decimal totalvalorDeIva15 = 0;
        public Decimal TotVta8 = 0;
        public Decimal TotIva8 = 0;
        public Decimal SubTotal = 0;
        //public Decimal totalvalorDeIva = 0;
        //public Decimal totalvalorDeIva = 0;


        public Decimal totalizar(DataGridView malla, decimal impstoDcmto, adcDescto.descDocumento descuentosDoc, DaxComercia.classPagosDoc pagosDoc, sesSys.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
        {            
            Decimal porDesctoUni = 0;
            Decimal valDesctoUni = 0;
            Decimal valUni = 0;
            Decimal cantidadUni = 0;
            Decimal ValorTotalUni = 0;
            Decimal ValorPorcIva = 0;

            Decimal ValorIvaUni = 0;
            Decimal ValorTotalFinal = 0;
            Decimal pagoCredito = 0;
            Decimal valorIngreso = 0;
            string Habitacion = "";
            Decimal total = 0;
            Decimal valorDeIva = 0;
            Decimal ivaValoresSuma = 0;


            Boolean documentoSinIva=false;


            decimal base5 = 0;
            decimal base15 = 0;
            decimal iva5 = 0;
            decimal iva15 = 0;
            decimal totalbase5 = 0;
            decimal totalbase15 = 0;
            decimal base8 = 0;
            decimal iva8 = 0;
            decimal totalbase8 = 0;


            try
            {
                foreach (DaxComercia .pagoDoc pago in pagosDoc.pagosDelDocumento )
                {
                    if (pago.PagoACredito == 2) {pagoCredito += Convert.ToDecimal(pago.Valor); } else { ValorCon += Convert.ToDecimal(pago.Valor); }
                    if (pago.GeneraIngreso  != 0) {valorIngreso += Convert.ToDecimal(pago.Valor); }
                    if (pago.TipoPag == "0") {ValorEfec += Convert.ToDecimal(pago.Valor);}
                    if (pago.Habitacion.Length > 0) { Habitacion = pago.Habitacion;}
                } 
            }
            catch { }
            try
            {
                foreach (DataGridViewRow row in malla.Rows)
                {                    
                    if (row.Cells["tra_Codigo"].Value != null && row.Cells["tra_Codigo"].Value.ToString().Length > 0)
                    {
                        if ( row.Cells["tra_Codigo"].Value.ToString() != ".") 
                        {
                            ValorPorcIva = Convert.ToDecimal("0" + row.Cells["Tra_porceniva"].Value);
                            documentoSinIva = ((propDoc.Impuestos + "0000").Substring(0, 1) != "1" || ValorPorcIva == 0);


                            if (documentoSinIva) row.Cells["tra_sniva"].Value = false;

                            Int32 tallRamo = 0;
                            try
                            {
                                if ((row.Cells["tra_medida"].Value + "    ").Substring(0, 3).ToUpper() == "RAM")
                                {
                                    row.Cells["tra_cantidad"].Value = Convert.ToDecimal(row.Cells["RamXCaja"].Value) * Convert.ToDecimal(row.Cells["CantCajas"].Value);
                                    tallRamo = Convert.ToInt32(row.Cells["TallXRamo"].Value);
                                    row.Cells["tallos"].Value = tallRamo * Convert.ToDecimal(row.Cells["tra_cantidad"].Value);
                                }
                            }
                            catch { }

                            porDesctoUni = Convert.ToDecimal("0" + row.Cells["tra_Porcendes"].Value);
                            valUni = Convert.ToDecimal("0" + row.Cells["tra_PrecUni"].Value);
                            cantidadUni = Convert.ToDecimal("0" + row.Cells["tra_Cantidad"].Value);
                            ValorTotalUni = Convert.ToDecimal("0" + row.Cells["tra_PrecTot"].Value);
                            ValorPorcIva = Convert.ToDecimal("0" + row.Cells["Tra_porceniva"].Value);
                            ValorIvaUni = Convert.ToDecimal("0" + row.Cells["Tra_valoriva"].Value);

                            decimal subtotalP = Math.Round(cantidadUni * valUni, 2);

                            if (porDesctoUni == 0)
                            {
                                try
                                {
                                    porDesctoUni = Convert.ToDecimal(row.Cells["tra_ValorDes"].Value) / Convert.ToDecimal("0" + row.Cells["tra_PrecTot"].Value);
                                }
                                catch { }
                            }


                            try
                            {
                                Decimal elPeso = 0;
                                elPeso = Convert.ToDecimal("0" + row.Cells["tra_Peso"].Value);
                                TotPes += elPeso;
                                row.Cells["totPeso"].Value = elPeso * cantidadUni;
                            }
                            catch { }
                            if (propDoc.PermiteCantidadCero != 0 && cantidadUni == 0)
                                {
                                    if (ValorTotalUni != 0) { valUni = ValorTotalUni; } else { ValorTotalUni = valUni; }
                                }
                            else
                                {                        
                                    ValorTotalUni = valUni * cantidadUni;
                                    ValorIvaUni = (ValorTotalUni * ValorPorcIva) / 100;
                                }
                            valDesctoUni =  Math.Round( ValorTotalUni * porDesctoUni / 100, 2);
                            ValorTotalUni -= valDesctoUni;
                            valorDeIva = Math.Round(ValorTotalUni * (ValorPorcIva / 100), 2);
                            ValorTotalFinal += Math.Round(ValorTotalUni +valorDeIva, 2);
                            ivaValoresSuma += Math.Round(valorDeIva, 2);

                            row.Cells["tra_PrecTot"].Value = ValorTotalUni;
                            row.Cells["Tra_valoriva"].Value = valorDeIva;
                            row.Cells["tra_ValorDes"].Value = valDesctoUni;

                            string tipoProducto = row.Cells["tra_queTipo"].Value.ToString();

                            if (cantidadUni != 0 && tipoProducto == "A") { TotUnd += cantidadUni; }
                            TotDesu += valDesctoUni;
                            if (tipoProducto == "S")
                                {
                                    TotDesCIva1 += valDesctoUni;
                                    TotSer += ValorTotalUni;
                                    if (Convert.ToBoolean(row.Cells["tra_sniva"].Value) == false && ValorPorcIva == 0)
                                        {
                                            TotSerSIva += ValorTotalUni;
                                        }
                                    else
                                        {
                                            TotSerCIva = TotSerCIva + ValorTotalUni;
                                            //totalFinal = totalFinal + ValorTotalFinal;
                                        }

                                }
                            else //if (tipoProducto == "A")

                                {
                                    TotDesSIva1 += valDesctoUni;
                                    if (row.Cells["tra_costtot"].Value != null) { TotCosArt += Convert.ToDecimal("0" + row.Cells["tra_costtot"].Value); }
                                    TotArt += ValorTotalUni;
                                    if (Convert.ToBoolean(row.Cells["tra_sniva"].Value) == false  && ValorPorcIva == 0)
                                    {
                                        TotArtSIva += ValorTotalUni;
                                    }
                                    else
                                    {
                                        TotArtCIva = TotArtCIva + ValorTotalUni;
                                    }
                                
                            }

                            if (ValorPorcIva == 5)
                            {
                                base5 += subtotalP - valDesctoUni;
                                iva5 += valorDeIva;
                            }
                            else if (ValorPorcIva == 15)
                            {
                                base15 += subtotalP - valDesctoUni;
                                iva15 += valorDeIva;
                            }
                            else if (ValorPorcIva == 15)
                            {
                                base8 += subtotalP - valDesctoUni;
                                iva8 += valorDeIva;
                            }

                            if (tipoProducto == "F") { TotAcf += ValorTotalUni; }

                            TotSiva = TotArtSIva + TotSerSIva;
                            TotCiva = TotArtCIva + TotSerCIva;
                            total += ValorTotalUni;
                            totalFinal = ValorTotalFinal;
                            totalvalorDeIva = ivaValoresSuma;
                            totalvalorDeIva5 = iva5;
                            totalvalorDeIva15 = iva15;
                            totalbase5 = base5;
                            totalbase15 = base15;
                            totalbase8 = base8;

                        }
                        else
                        {
                            row.Cells["tra_Porcendes"].Value=0;
                            row.Cells["tra_PrecUni"].Value = 0;
                            row.Cells["tra_Cantidad"].Value=0;
                            row.Cells["tra_PrecTot"].Value=0;
                        }
                    }
                }
            }
            catch { }
            totalesDocumento(totalbase5,totalvalorDeIva5, totalbase15, totalvalorDeIva15,ValorPorcIva, descuentosDoc, porDesctoUni, valDesctoUni, valUni, cantidadUni);

            return TotVta;

        }
        public Decimal totalizar(DataGridView malla, IvaRett.docImpuestos claseImpuestos, sesSys.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
        {
            Decimal cantidadUni = 0;
            Decimal ValorTotalUni = 0;
            Decimal valUni = 0;
            Decimal total = 0;
            try
            {
                foreach (DataGridViewRow row in malla.Rows)
                {
                    if (row.Cells["tra_Codigo"].Value != null && row.Cells["tra_Codigo"].Value.ToString().Length > 0)
                    {
                        if (row.Cells["tra_Codigo"].Value.ToString() != ".")
                        {
                            valUni = Convert.ToDecimal("0" + row.Cells["tra_PrecUni"].Value);
                            cantidadUni = Convert.ToDecimal("0" + row.Cells["tra_Cantidad"].Value);
                            ValorTotalUni = Convert.ToDecimal("0" + row.Cells["tra_PrecTot"].Value);
                            try
                            {
                                Decimal elPeso = 0;
                                elPeso = Convert.ToDecimal("0" + row.Cells["tra_Peso"].Value);
                                TotPes += elPeso;
                                row.Cells["totPeso"].Value = elPeso * cantidadUni;
                            }
                            catch { }
                            if (propDoc.PermiteCantidadCero != 0 && cantidadUni == 0)
                            {
                                if (ValorTotalUni != 0) { valUni = ValorTotalUni; } else { ValorTotalUni = valUni; }
                            }
                            else
                            {
                                ValorTotalUni = valUni * cantidadUni;
                            }

                            row.Cells["tra_PrecTot"].Value = ValorTotalUni;

                            TotUnd += cantidadUni; 
                            total += ValorTotalUni;
                        }
                        else
                        {
                            row.Cells["tra_PrecUni"].Value = 0;
                            row.Cells["tra_Cantidad"].Value = 0;
                            row.Cells["tra_PrecTot"].Value = 0;
                        }
                        row.Cells["tra_Porcendes"].Value = 0;
                    }
                }
            }
            catch { }
            return total;
        }

        public Decimal totalizar( DataTable malla, Decimal impstoDcmto, adcDescto.descDocumento descuentosDoc, DaxComercia.classPagosDoc pagosDoc, sesSys.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
        {
            Decimal porDesctoUni = 0;
            Decimal valDesctoUni = 0;
            Decimal valorUnitario = 0;
            Decimal cantidad = 0;
            Decimal subtotal = 0;
            Decimal pagoCredito = 0;
            Decimal valorIngreso = 0;
            string Habitacion = "";
            Decimal total = 0;
            Decimal ValorPorcIva = 0;
            Boolean documentoSinIva = ((propDoc.Impuestos + "0000").Substring(0, 1) != "1" || ValorPorcIva == 0);
            try
            {
                foreach (DaxComercia .pagoDoc pago in pagosDoc.pagosDelDocumento)
                {
                    if (pago.PagoACredito == 2) { pagoCredito += Convert.ToDecimal(pago.Valor); } else { ValorCon += Convert.ToDecimal(pago.Valor); }
                    if (pago.GeneraIngreso != 0) { valorIngreso += Convert.ToDecimal(pago.Valor); }
                    if (pago.TipoPag == "0") { ValorEfec += Convert.ToDecimal(pago.Valor); }
                    if (pago.Habitacion.Length > 0) { Habitacion = pago.Habitacion; }
                }
            }
            catch { }
            try
            {
                foreach (DataRow  row in malla.Rows)
                {
                    if (row["tra_Codigo"] != null)
                    {
                        if (row["tra_Codigo"].ToString().Length > 0)
                        {

                            Int32 tallRamo = 0;
                            try
                            {
                                if ((row["tra_medida"] + "    ").Substring(0, 3).ToUpper() == "RAM")
                                {
                                    row["tra_cantidad"] = Convert.ToDecimal(row["RamXCaja"]) * Convert.ToDecimal(row["CantCajas"]);
                                    tallRamo = Convert.ToInt32(row["TallXRamo"]);
                                    row["tallos"] = tallRamo * Convert.ToDecimal(row["tra_cantidad"]);
                                }
                            }
                            catch { }

                            porDesctoUni = Convert.ToDecimal("0" + row["tra_Porcendes"]);
                            valorUnitario = Convert.ToDecimal("0" + row["tra_PrecUni"]);
                            cantidad = Convert.ToDecimal("0" + row["tra_Cantidad"]);
                            subtotal = Convert.ToDecimal("0" + row["tra_PrecTot"]);

                            try
                            {
                                Decimal elPeso = 0;
                                elPeso = Convert.ToDecimal("0" + row["tra_Peso"]);
                                TotPes += elPeso;
                                row["totPeso"] = elPeso * cantidad;
                            }
                            catch { }



                            if (propDoc.PermiteCantidadCero != 0 && cantidad == 0)
                            {
                                if (subtotal != 0) { valorUnitario = subtotal; } else { subtotal = valorUnitario; }
                            }
                            else
                            {
                                subtotal = valorUnitario * cantidad;
                            }
                            valDesctoUni = Math.Round(subtotal * porDesctoUni / 100, digitosPrecios);

                            subtotal -= Math.Round(valDesctoUni);

                            row["tra_PrecTot"] = subtotal;
                            row["tra_ValorDes"] = valDesctoUni;

                            Decimal precioTotal = valorUnitario * cantidad;
                            string tipoProducto = row["tra_queTipo"].ToString();

                            if (cantidad != 0 && tipoProducto == "A") { TotUnd += cantidad; }
                            TotDesu += valDesctoUni;
                            if (tipoProducto == "S")
                            {
                                TotDesCIva1 += valDesctoUni;
                                TotSer += precioTotal;
                                if (Convert.ToBoolean(row["tra_sniva"]) == false)
                                {
                                    TotSerSIva += precioTotal;
                                }
                                else
                                {
                                    TotSerCIva = TotSerCIva + precioTotal;
                                }

                            }
                            else //if (tipoProducto == "A")

                            {
                                TotDesSIva1 += valDesctoUni;
                                if (row["tra_costtot"] != null) { TotCosArt += Convert.ToDecimal("0" + row["tra_costtot"]); }
                                TotArt += precioTotal;
                                if (Convert.ToBoolean(row["tra_sniva"]) == false)
                                {
                                    TotArtSIva += precioTotal;
                                }
                                else
                                {
                                    TotArtCIva = TotArtCIva + precioTotal;
                                }
                            }

                            if (tipoProducto == "F") { TotAcf += precioTotal; }

                            TotSiva = TotArtSIva + TotSerSIva;
                            TotCiva = TotArtCIva + TotSerCIva;
                            total += subtotal;
                        }
                    }
                }
            }
            catch { }
            totalesDocumento(0,0,0,0,impstoDcmto, descuentosDoc, porDesctoUni, valDesctoUni, valorUnitario, cantidad);

            return TotVta;
        }

        public Decimal totalizarFac(DataGridView malla, Decimal impstoDcmto, adcDescto.descDocumento descuentosDoc, DaxComercia.classPagosDoc pagosDoc, sesSys.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
        {
            Decimal porDesctoUni = 0;
            Decimal valDesctoUni = 0;
            Decimal valUni = 0;
            Decimal cantidadUni = 0;
            Decimal ValorTotalUni = 0;
            Decimal pagoCredito = 0;
            Decimal valorIngreso = 0;
            string Habitacion = "";
            Decimal total = 0;
            Boolean documentoSinIva = ((propDoc.Impuestos + "0000").Substring(0, 1) != "1" || impstoDcmto == 0);
            try
            {
                foreach (DaxComercia.pagoDoc pago in pagosDoc.pagosDelDocumento)
                {
                    if (pago.PagoACredito == 2) { pagoCredito += Convert.ToDecimal(pago.Valor); } else { ValorCon += Convert.ToDecimal(pago.Valor); }
                    if (pago.GeneraIngreso != 0) { valorIngreso += Convert.ToDecimal(pago.Valor); }
                    if (pago.TipoPag == "0") { ValorEfec += Convert.ToDecimal(pago.Valor); }
                    if (pago.Habitacion.Length > 0) { Habitacion = pago.Habitacion; }
                }
            }
            catch { }
            try
            {
                foreach (DataGridViewRow row in malla.Rows)
                {

                    if (row.Cells["tra_Codigo"].Value != null)
                    {
                        if (row.Cells["tra_Codigo"].Value.ToString().Length > 0 && row.Cells["tra_Codigo"].Value.ToString() != ".")
                        {

                            if (documentoSinIva) row.Cells["tra_sniva"].Value = false;

                            porDesctoUni = Convert.ToDecimal("0" + row.Cells["tra_Porcendes"].Value);
                            valUni = Convert.ToDecimal("0" + row.Cells["tra_PrecUni"].Value);
                            cantidadUni = Convert.ToDecimal("0" + row.Cells["tra_Cantidad"].Value);
                            ValorTotalUni = Convert.ToDecimal("0" + row.Cells["tra_PrecTot"].Value);

                            if (propDoc.PermiteCantidadCero != 0 && cantidadUni == 0)
                            {
                                if (ValorTotalUni != 0) { valUni = ValorTotalUni; } else { ValorTotalUni = valUni; }
                            }
                            else
                            {
                                ValorTotalUni = valUni * cantidadUni;
                            }
                            valDesctoUni = Math.Round(ValorTotalUni * porDesctoUni / 100, 2);

                            ValorTotalUni -= valDesctoUni;

                            row.Cells["tra_PrecTot"].Value = ValorTotalUni;
                            row.Cells["tra_ValorDes"].Value = valDesctoUni;

                            string tipoProducto = row.Cells["tra_queTipo"].Value.ToString();

                            if (cantidadUni != 0 && tipoProducto == "A") { TotUnd += cantidadUni; }
                            TotDesu += valDesctoUni;
                            if (tipoProducto == "S")
                            {
                                TotDesCIva1 += valDesctoUni;
                                TotSer += ValorTotalUni;
                                if (Convert.ToBoolean(row.Cells["tra_sniva"].Value) == false)
                                {
                                    TotSerSIva += ValorTotalUni;
                                }
                                else
                                {
                                    TotSerCIva = TotSerCIva + ValorTotalUni;
                                }

                            }
                            else //if (tipoProducto == "A")

                            {
                                TotDesSIva1 += valDesctoUni;
                                if (row.Cells["tra_costtot"].Value != null) { TotCosArt += Convert.ToDecimal("0" + row.Cells["tra_costtot"].Value); }
                                TotArt += ValorTotalUni;
                                if (Convert.ToBoolean(row.Cells["tra_sniva"].Value) == false)
                                {
                                    TotArtSIva += ValorTotalUni;
                                }
                                else
                                {
                                    TotArtCIva = TotArtCIva + ValorTotalUni;
                                }
                            }

                            if (tipoProducto == "F") { TotAcf += ValorTotalUni; }

                            TotSiva = TotArtSIva + TotSerSIva;
                            TotCiva = TotArtCIva + TotSerCIva;
                            total += ValorTotalUni;
                        }
                    }
                }
            }
            catch { }
            totalesDocumento(0,0,0,0,impstoDcmto, descuentosDoc, porDesctoUni, valDesctoUni, valUni, cantidadUni);
            return TotVta;

        }        
        private void totalesDocumento(Decimal Baseiva5,Decimal iva5, Decimal Baseiva15,Decimal iva15,Decimal impstoDcmto, adcDescto.descDocumento desctoDcmto, Decimal porDesctoUni, Decimal valDesctoUni, Decimal valUni, Decimal cantidad)
        {
            decimal Auxnum = 0;
            decimal  AuxTot = 0;

            double porcentajeDescuento = 0;
            double valorFijoDescuento = 0;
            if (!(desctoDcmto == null) )
            {
                for (int I = 0; I < 3; I++)
                {

                    porcentajeDescuento = desctoDcmto.porcentajeDes[I];
                    valorFijoDescuento = desctoDcmto.valorDes[I];

                    if (valorFijoDescuento != 0)
                    {
                        //' esta parte para viabilizar el ingreso de descuento por valor y no solo por porcentaje
                        if (valorFijoDescuento > Convert.ToDouble(TotCiva + TotSiva))
                        {
                            MessageBox.Show("El valor del descuento fijo aplicado es mayor que el valor de la venta \n no será tomado en cuenta", "Emisión de facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {

                            AuxTot = TotCiva + TotSiva;
                            Auxnum = Math.Round((TotArtCIva / AuxTot) * Convert.ToDecimal(valorFijoDescuento), 2);

                            TotDesArt = TotDesArt + Auxnum;
                            totdesciva = totdesciva + Auxnum;
                            Auxnum = Math.Round((TotSerCIva / AuxTot) * Convert.ToDecimal(valorFijoDescuento), 2);

                            TotDesSer = TotDesSer + Auxnum;
                            totdesciva = totdesciva + Auxnum;
                            Auxnum = Math.Round((TotArtSIva / AuxTot) * Convert.ToDecimal(valorFijoDescuento), 2);

                            TotDesArt = TotDesArt + Auxnum;
                            totdessiva = totdessiva + Auxnum;
                            Auxnum = Math.Round((TotSerSIva / AuxTot), 2);

                            TotDesSer = TotDesSer + Auxnum;
                            totdessiva = totdessiva + Auxnum;
                            desctoDcmto.porcentajeDes[I] = Math.Round((valorFijoDescuento / Convert.ToDouble(AuxTot)) * 100, 2);
                            desctoDcmto.descuentoTot[I] = valorFijoDescuento;
                        }
                        break;
                    }
                    else if (porcentajeDescuento != 0)
                    {
                        if (desctoDcmto.DesSnIva[I] == "C")
                        {
                            Auxnum = Math.Round(TotArtCIva * Convert.ToDecimal(desctoDcmto.porcentajeDes[I]) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesArt = TotDesArt + Auxnum;
                            totdesciva = totdesciva + Auxnum;
                            Auxnum = Math.Round(TotSerCIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesSer = TotDesSer + Auxnum;
                            totdesciva = totdesciva + Auxnum;
                        }
                        else if (desctoDcmto.DesSnIva[I] == "S")
                        {
                            //        Case "S"
                            Auxnum = Math.Round(TotArtSIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesArt = TotDesArt + Auxnum;
                            totdessiva = totdessiva + Auxnum;
                            Auxnum = Math.Round(TotSerSIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesSer = TotDesSer + Auxnum;
                            totdessiva = totdessiva + Auxnum;
                        }
                        else
                        {
                            // descuentos articulos con iva
                            Auxnum = Math.Round(TotArtCIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesArt = TotDesArt + Auxnum;      // descuento articulos 
                            totdesciva = totdesciva + Auxnum;    // descuentos con iva

                            Auxnum = Math.Round(TotSerCIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesSer = TotDesSer + Auxnum;      // descuento servicios
                            totdesciva = totdesciva + Auxnum;    // descuentos con iva

                            Auxnum = Math.Round(TotArtSIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesArt = TotDesArt + Auxnum;     // descuento articulos
                            totdessiva = totdessiva + Auxnum;   // descuentos sin iva

                            Auxnum = Math.Round(TotSerSIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                            desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                            TotDesSer = TotDesSer + Auxnum;         // descuento servicios
                            totdessiva = totdessiva + Auxnum;       // descuentos sin iva
                        }
                    }
                }
            }
            Subtotalciva = TotCiva - totdesciva;
            SubTotalSIva = TotSiva - totdessiva;
            TotDescuentos = totdesciva + totdessiva;
            TotVta = totalFinal;
            TotIva = totalvalorDeIva;

            TotVta5 = Baseiva5;
            TotIva5 = iva5;
            TotVta15 = Baseiva15;
            TotIva15 = iva15;


        }

        // ============================================================
        // MÉTODO ESPECÍFICO PARA DOCUMENTOS DE INVENTARIO (SIN IVA)
        // ============================================================
        public Decimal totalizarInventario(DataGridView malla, int digitosPrecios = 2)
        {
            Decimal total = 0;

            if (malla.Rows.Count < 1) return total;

            foreach (DataGridViewRow row in malla.Rows)
            {
                // Saltar fila nueva
                if (row.IsNewRow) continue;

                try
                {
                    // Verificar que la fila tenga código
                    if (row.Cells["tra_Codigo"].Value == null ||
                        row.Cells["tra_Codigo"].Value.ToString().Length == 0 ||
                        row.Cells["tra_Codigo"].Value.ToString() == ".")
                        continue;

                    // Obtener cantidad
                    decimal cantidad = 0;
                    if (row.Cells["tra_Cantidad"].Value != null)
                        decimal.TryParse(row.Cells["tra_Cantidad"].Value.ToString(), out cantidad);

                    // Obtener costo unitario
                    decimal costoUnitario = 0;
                    if (row.Cells["Tra_precuni"].Value != null)
                        decimal.TryParse(row.Cells["Tra_precuni"].Value.ToString(), out costoUnitario);

                    // Calcular total de línea
                    decimal totalLinea = cantidad * costoUnitario;
                    total += totalLinea;

                    // Actualizar columna de total
                    if (row.Cells["Tra_prectot"] != null)
                    {
                        row.Cells["Tra_prectot"].Value = Math.Round(totalLinea, digitosPrecios);
                    }

                    // Si existe columna de peso
                    if (row.Cells["tra_Peso"] != null && row.Cells["tra_Peso"].Value != null)
                    {
                        decimal peso = 0;
                        decimal.TryParse(row.Cells["tra_Peso"].Value.ToString(), out peso);
                        TotPes += peso * cantidad;
                    }

                    // Contar unidades (si existe la columna tra_queTipo)
                    if (row.Cells["tra_queTipo"] != null && row.Cells["tra_queTipo"].Value != null)
                    {
                        string tipoProducto = row.Cells["tra_queTipo"].Value.ToString();
                        if (cantidad != 0 && tipoProducto == "A")
                            TotUnd += cantidad;
                    }

                    // Acumular costos (si existe la columna tra_costtot)
                    if (row.Cells["tra_costtot"] != null && row.Cells["tra_costtot"].Value != null)
                    {
                        decimal costo = 0;
                        decimal.TryParse(row.Cells["tra_costtot"].Value.ToString(), out costo);
                        TotCosArt += costo;
                    }
                }
                catch
                {
                    // Ignorar errores en líneas individuales
                    continue;
                }
            }

            // Asignar totales (SIN IVA)
            TotVta = total;
            TotCiva = 0;
            TotSiva = 0;
            TotIva = 0;
            TotDescuentos = 0;
            totdesciva = 0;
            totdessiva = 0;
            TotDesArt = 0;
            TotDesSer = 0;
            SubTotal = total;
            Subtotalciva = 0;
            SubTotalSIva = 0;
            totalFinal = total;
            totalvalorDeIva = 0;
            totalvalorDeIva5 = 0;
            totalvalorDeIva15 = 0;

            return total;
        }

    }

}



