using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace adcDocumentos
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
        public Decimal TotImp1 =0;
        public Decimal TotImp2 = 0;
        public Decimal TotImp3 = 0;
        public Decimal TotVta = 0;
        public Decimal SubTotalSIva = 0;
        public Decimal Subtotalciva = 0;


        public Decimal totalizar(DataGridView malla, TablasSRI.docImpuestos impstoDcmto, adcDescto.descDocumento descuentosDoc, pagosDocumento.classPagosDoc pagosDoc, PrySysp13.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
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
            Boolean documentoSinIva = ((propDoc.Impuestos + "0000").Substring(0, 1) != "1" || impstoDcmto.impstoPorcentaje1 == 0) ;
            try
            {
                foreach (pagosDocumento.pagoDoc pago in pagosDoc.pagosDelDocumento )
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
                    
                    if (row.Cells["tra_Codigo"].Value != null)
                    {
                        if (row.Cells["tra_Codigo"].Value.ToString().Length > 0 && row.Cells["tra_Codigo"].Value.ToString() != ".") 
                        {

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
                            valDesctoUni =  Math.Round( ValorTotalUni * porDesctoUni / 100, 2);

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
            totalesDocumento( impstoDcmto, descuentosDoc, porDesctoUni, valDesctoUni, valUni, cantidadUni);

            return TotVta;

        }

        public Decimal totalizar( DataTable malla, TablasSRI.docImpuestos impstoDcmto, adcDescto.descDocumento descuentosDoc, pagosDocumento.classPagosDoc pagosDoc, PrySysp13.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
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
            Boolean documentoSinIva = ((propDoc.Impuestos + "0000").Substring(0, 1) != "1" || impstoDcmto.impstoPorcentaje1 == 0);
            try
            {
                foreach (pagosDocumento.pagoDoc pago in pagosDoc.pagosDelDocumento)
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
            totalesDocumento(impstoDcmto, descuentosDoc, porDesctoUni, valDesctoUni, valorUnitario, cantidad);

            return TotVta;
        }

        public Decimal totalizarFac(DataGridView malla, TablasSRI.docImpuestos impstoDcmto, adcDescto.descDocumento descuentosDoc, pagosDocumento.classPagosDoc pagosDoc, PrySysp13.OpcDoc propDoc, int digitosPrecios = 2, int digitosCostos = 2)
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
            Boolean documentoSinIva = ((propDoc.Impuestos + "0000").Substring(0, 1) != "1" || impstoDcmto.impstoPorcentaje1 == 0);
            try
            {
                foreach (pagosDocumento.pagoDoc pago in pagosDoc.pagosDelDocumento)
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
            totalesDocumento(impstoDcmto, descuentosDoc, porDesctoUni, valDesctoUni, valUni, cantidadUni);
            return TotVta;

        }

        private void totalesDocumento(TablasSRI.docImpuestos impstoDcmto, adcDescto.descDocumento desctoDcmto, Decimal porDesctoUni, Decimal valDesctoUni, Decimal valUni, Decimal cantidad)
        {
            decimal Auxnum = 0;
            decimal  AuxTot = 0;

            double porcentajeDescuento = 0;
            double valorFijoDescuento = 0;
            for (int I = 0; I < 3; I++)
            {

                porcentajeDescuento = desctoDcmto.porcentajeDes[I];
                valorFijoDescuento = desctoDcmto.valorDes[I];

                if (valorFijoDescuento != 0)
                {
                    //' esta parte para viabilizar el ingreso de descuento por valor y no solo por porcentaje
                            if (valorFijoDescuento > Convert.ToDouble (TotCiva + TotSiva) )
                    {
                                MessageBox.Show ( "El valor del descuento fijo aplicado es mayor que el valor de la venta \n no será tomado en cuenta","Emisión de facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                        else
                            { 

                                AuxTot =  TotCiva + TotSiva;
                                Auxnum = Math.Round ((TotArtCIva / AuxTot) * Convert.ToDecimal( valorFijoDescuento), 2);
                            
                                TotDesArt = TotDesArt + Auxnum;
                                totdesciva = totdesciva + Auxnum;
                                Auxnum = Math.Round((TotSerCIva / AuxTot) * Convert.ToDecimal( valorFijoDescuento), 2);
                            
                                TotDesSer = TotDesSer + Auxnum;
                                totdesciva = totdesciva + Auxnum;
                                Auxnum = Math.Round((TotArtSIva / AuxTot) * Convert.ToDecimal( valorFijoDescuento), 2);
                            
                                TotDesArt = TotDesArt + Auxnum;
                                totdessiva = totdessiva + Auxnum;
                                Auxnum = Math.Round((TotSerSIva / AuxTot), 2);
                            
                                TotDesSer = TotDesSer + Auxnum;
                                totdessiva = totdessiva + Auxnum;
                                desctoDcmto.porcentajeDes [I] = Math.Round(( valorFijoDescuento / Convert.ToDouble (AuxTot)) * 100, 2);
                                desctoDcmto.descuentoTot [I] =  valorFijoDescuento;
                            }
                            break;
                }
                else if (porcentajeDescuento != 0)
                {
                    if (desctoDcmto.DesSnIva[I] == "C")
                    {
                        Auxnum = Math.Round(TotArtCIva * Convert.ToDecimal(desctoDcmto.porcentajeDes [I]) / 100, 2);
                        desctoDcmto.descuentoTot [I] +=  Convert.ToDouble(Auxnum);
                        TotDesArt = TotDesArt + Auxnum;
                        totdesciva = totdesciva + Auxnum;
                        Auxnum = Math.Round(TotSerCIva * Convert.ToDecimal(porcentajeDescuento) / 100, 2);
                        desctoDcmto.descuentoTot [I] += Convert.ToDouble(Auxnum);
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

                        Auxnum = Math.Round(TotSerSIva * Convert.ToDecimal(porcentajeDescuento ) / 100, 2);
                        desctoDcmto.descuentoTot[I] += Convert.ToDouble(Auxnum);
                        TotDesSer = TotDesSer + Auxnum;         // descuento servicios
                        totdessiva = totdessiva + Auxnum;       // descuentos sin iva
                    }
                }
            }

            Subtotalciva = TotCiva - totdesciva;
            SubTotalSIva = TotSiva - totdessiva;
            TotDescuentos = totdesciva + totdessiva;

            TotIva = Math.Round((Subtotalciva * Convert.ToDecimal(impstoDcmto.impstoPorcentaje1/100) ), 2);

            TotImp1 = Math.Round((Subtotalciva * Convert.ToDecimal(impstoDcmto.impstoPorcentaje2/100) ), 2);

            TotImp2 = Math.Round((Subtotalciva * Convert.ToDecimal(impstoDcmto.impstoPorcentaje3/100) ), 2);
            
            TotImp3 = Math.Round((Subtotalciva * Convert.ToDecimal(impstoDcmto.impstoPorcentaje4/100) ), 2);

            TotVta = Math.Round(Subtotalciva + SubTotalSIva + TotIva + TotImp1 + TotImp2 + TotImp3, 2);
        }

    }

}


//Private Sub totalizar()
//Dim I As Integer, S As Double, Auxnum As Double, AuxTot As Double
//On Error Resume Next

//TotUnd = 0
//TotArt = 0
//TotCosArt = 0
//TotSer = 0
//TotCiva = 0
//TotSiva = 0
//TotIva = 0
//TotImp1 = 0
//PorImp1 = 0

//TotImp2 = 0
//PorImp2 = 0

//TotImp3 = 0
//PorImp3 = 0


//SubTotalSIva = 0
//Subtotalciva = 0
//SubTotalSIva1 = 0
//'Subtotalciva1 = 0
//TotDesCIva1 = 0
//TotDesCIva2 = 0
//TotDesCIva3 = 0
//TotDesCIva4 = 0
//TotDesSIva1 = 0
//TotDesSIva2 = 0
//TotDesSIva3 = 0
//TotDesSIva4 = 0
//TotDesu = 0
//TotDesg = 0
//TotDesg2 = 0
//TotDesg3 = 0
//TotDesg4 = 0
//totdesciva = 0
//totdessiva = 0
//TotVta = 0
//TotPes = 0
//'*********************
//TotDesArt = 0
//TotDesSer = 0
//TotArtCIva = 0
//TotArtSIva = 0
//TotSerCIva = 0
//TotSerSIva = 0
//TotAcf = 0
//For I = 0 To 4
//totaldes(I) = 0
//Next I

//For I = Malla.FixedRows To (Malla.Rows - 1)
//   If Malla.TextMatrix(I, 1) <> "" Then
//            calculartotales I
//            If Malla.TextMatrix(I, 3) <> "" And Malla.TextMatrix(I, 8) = "A" Then TotUnd = TotUnd + val(Malla.TextMatrix(I, 3))
//            If Malla.TextMatrix(I, 16) <> "" Then TotPes = val(TotPes) + val(Malla.TextMatrix(I, 16))
//            If val(Malla.TextMatrix(I, 11)) <> 0 Then
//                TotDesu = TotDesu + val(Malla.TextMatrix(I, 11))
//                If Malla.TextMatrix(I, 8) = "S" Then TotDesCIva1 = TotDesCIva1 + val(Malla.TextMatrix(I, 11)) Else TotDesSIva1 = TotDesSIva1 + val(Malla.TextMatrix(I, 11))
//            End If
//            '********************************************************************
//            If Malla.TextMatrix(I, 8) = "S" Then TotSer = TotSer + val(Malla.TextMatrix(I, 7))
//            If Malla.TextMatrix(I, 8) = "A" Then
//                If Malla.TextMatrix(I, 13) <> "" Then TotCosArt = TotCosArt + val(Malla.TextMatrix(I, 13))
//                If Malla.TextMatrix(I, 7) <> "" Then TotArt = TotArt + val(Malla.TextMatrix(I, 7))
//            End If
//            If Malla.TextMatrix(I, 8) = "F" And Malla.TextMatrix(I, 7) <> "" Then TotAcf = TotAcf + val(Malla.TextMatrix(I, 7))
//            If DocumentoSinIva Then
//                Malla.TextMatrix(I, 10) = "No"
//            Else
//                If Malla.TextMatrix(I, 10) = "" Then Malla.TextMatrix(I, 10) = "No"
//            End If
//            If Malla.TextMatrix(I, 10) = "No" Then
//                    '**************************************************************
//                   If Malla.TextMatrix(I, 8) <> "S" Then
//                            TotArtSIva = TotArtSIva + val(Malla.TextMatrix(I, 7))
//                   Else
//                            TotSerSIva = TotSerSIva + val(Malla.TextMatrix(I, 7))
//                   End If
//            Else
//                    If Malla.TextMatrix(I, 8) <> "S" Then
//                            TotArtCIva = TotArtCIva + val(Malla.TextMatrix(I, 7))
//                    Else
//                            TotSerCIva = TotSerCIva + val(Malla.TextMatrix(I, 7))
//                    End If
//            End If
//End If
//    Next I


//' NUEVO CALCULO DE TOTALES DESDE AQUI
//'

//TotSiva = TotArtSIva + TotSerSIva
//TotCiva = TotArtCIva + TotSerCIva

//For I = 1 To 4
//If Desvalor(I) <> 0 Then
//' esta parte para viabilizar el ingreso de descuento por valor y no solo por porcentaje
//        If Desvalor(I) > (TotCiva + TotSiva) Then
//            MsgBox "El valor del descuento fijo aplicado es mayor que el valor de la venta " & vbCr & "no será tomado en cuenta", vbCritical
//        Else
//             AuxTot = TotCiva + TotSiva
//             Auxnum = Round((TotArtCIva / AuxTot) * Desvalor(I), 2)
//          '   totaldes(i) = totaldes(i) + Auxnum
//             TotDesArt = TotDesArt + Auxnum
//             totdesciva = totdesciva + Auxnum
//             Auxnum = Round((TotSerCIva / AuxTot) * Desvalor(I), 2)
//          '  totaldes(i) = totaldes(i) + Auxnum
//             TotDesSer = TotDesSer + Auxnum
//             totdesciva = totdesciva + Auxnum
//             Auxnum = Round((TotArtSIva / AuxTot) * Desvalor(I), 2)
//          '  totaldes(i) = totaldes(i) + Auxnum
//             TotDesArt = TotDesArt + Auxnum
//             totdessiva = totdessiva + Auxnum
//             Auxnum = Round((TotSerSIva / AuxTot), 2)
//          '  totaldes(i) = totaldes(i) + Auxnum
//             TotDesSer = TotDesSer + Auxnum
//             totdessiva = totdessiva + Auxnum
//             DesPorcentaje(I) = Round((Desvalor(I) / AuxTot) * 100, 2)
//             totaldes(I) = Desvalor(I)
//        End If
//        Exit For
//Else
//    Select Case DesSnIva(I)
//        Case "C"
//             Auxnum = Round(TotArtCIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesArt = TotDesArt + Auxnum
//             totdesciva = totdesciva + Auxnum
//             Auxnum = Round(TotSerCIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesSer = TotDesSer + Auxnum
//             totdesciva = totdesciva + Auxnum
//        Case "S"
//             Auxnum = Round(TotArtSIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesArt = TotDesArt + Auxnum
//             totdessiva = totdessiva + Auxnum
//             Auxnum = Round(TotSerSIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesSer = TotDesSer + Auxnum
//             totdessiva = totdessiva + Auxnum
//        Case Else
//             Auxnum = Round(TotArtCIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesArt = TotDesArt + Auxnum
//             totdesciva = totdesciva + Auxnum
//             Auxnum = Round(TotSerCIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesSer = TotDesSer + Auxnum
//             totdesciva = totdesciva + Auxnum
//             Auxnum = Round(TotArtSIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesArt = TotDesArt + Auxnum
//             totdessiva = totdessiva + Auxnum
//             Auxnum = Round(TotSerSIva * DesPorcentaje(I) / 100, 2)
//             totaldes(I) = totaldes(I) + Auxnum
//             TotDesSer = TotDesSer + Auxnum
//             totdessiva = totdessiva + Auxnum
//    End Select
//End If
//Next I
//TotDesg = totaldes(1)
//TotDesg2 = totaldes(2)
//TotDesg3 = totaldes(3)
//TotDesg4 = totaldes(4)

//Subtotalciva = TotCiva - totdesciva
//SubTotalSIva = TotSiva - totdessiva

//TotIva = Round((Subtotalciva * ImpPorcentaje(0) / 100), 2)

//PorImp1 = ImpPorcentaje(1)
//TotImp1 = Round((Subtotalciva * PorImp1 / 100), 2)

//PorImp2 = ImpPorcentaje(2)
//TotImp2 = Round((Subtotalciva * PorImp2 / 100), 2)

//PorImp3 = ImpPorcentaje(3)
//TotImp3 = Round((Subtotalciva * PorImp3 / 100), 2)

//TotVta = Round(Subtotalciva + SubTotalSIva + TotIva + TotImp1 + TotImp2 + TotImp3, 2)

//Edit.Text = Format(TotVta, Tforma)    'precio venta
//txtconiva.Caption = Format(Subtotalciva, Tforma)
//txtsiniva.Caption = Format(SubTotalSIva, Tforma)
//txtdescuento.Caption = Format(TotDesg + TotDesg2 + TotDesg3 + TotDesg4, Tforma)
//txtporiva.Caption = ImpPorcentaje(0)
//txtvaloriva.Caption = Format(TotIva, Tforma)

//End Sub
