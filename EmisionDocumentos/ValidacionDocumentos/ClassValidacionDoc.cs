using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using DaxInvent;
using classMenSistem;
using DattCom;


namespace ValidacionDocumentos
{
	public class ValidacionGeneral
    {
        public static bool ValidarFacturaPtoVta(DataGridView malla,ClassDoc.AdcDoc  DatosDocmto,string nombreDatoCodigo, string usuario)
        {
            if ( DatosDocmto.Doc_numero  == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); return false; }
            if (validarFecha(DatosDocmto.Doc_fecha.ToShortDateString(), usuario) == false) return false;
            if (validarIngresoDetalle(malla,nombreDatoCodigo) == false) return false;
            if (DatosDocmto.Doc_codper == "" || DatosDocmto.Doc_CiRuc == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }
            if (DatosDocmto.Doc_NombreImp.Length == 0 || DatosDocmto.Doc_NombreImp.Length == 0 || DatosDocmto.Doc_Telefono1.Length == 0) { mensajesErrorDocumento.InfDeContactoNoCorrecta(); return false; }
            return true;
        }
        public static bool verificarFormaDePago(ClassDoc.idDocumento idDoc, DaxComercia.classPagosDoc clasePagos,string pagoPredefinido,string totVta ,string txtCambio,string txtRecibido,string txtCheque,string txtTarjeta,string txtTarjeta2,string CodCliente,double limitecredito)
        {
            bool tieneLiq = false;

            double cambio = 0;
            if (txtCambio.Length > 0)
            {
                cambio = Convert.ToDouble(txtCambio);
                if (cambio < 0)
                {
                    MessageBox.Show("Error: El pago registrado no está completo", "Control pagos documentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            double valorEfectivo = Convert.ToDouble("0" + txtRecibido) - cambio;
            double valorCheque = Convert.ToDouble("0" + txtCheque);
            double valorTarjeta = Convert.ToDouble("0" + txtTarjeta);
            double valorTarjeta2 = Convert.ToDouble("0" + txtTarjeta2);
            double totPagos = valorEfectivo + valorCheque + valorTarjeta + valorTarjeta2;


            if (clasePagos.pagosDelDocumento.Count == 0)
            {
                if (totPagos == 0) { crearPagoPredefinido(idDoc,clasePagos, pagoPredefinido, Convert.ToDouble(totVta)); }
                else
                {
                    if (valorEfectivo > 0) crearPagoPredefinido(idDoc,clasePagos,"EFE", valorEfectivo);
                    if (valorCheque > 0) crearPagoPredefinido(idDoc, clasePagos, "CHE", valorCheque);
                    if (valorTarjeta > 0) crearPagoPredefinido(idDoc, clasePagos, "TRJ", valorTarjeta);
                    if (valorTarjeta2 > 0) crearPagoPredefinido(idDoc, clasePagos, "TR2", valorTarjeta2);
                }
            }

//            MntPago dp = new MntPago();
            tieneLiq = false;
            double TotalPago = 0;
            double valorCredito = 0;
            double valorContado = 0;

            foreach (DaxComercia.pagoDoc elPago in clasePagos.pagosDelDocumento)
            {
                TotalPago += elPago.Valor;
                if (!tieneLiq) tieneLiq = (elPago.Descripcion.Contains("RETENCI"));
                if (elPago.PagoACredito == 2) { valorCredito += elPago.Valor; }
                else { valorContado += elPago.Valor; }
                if (elPago.TipoPag == "0") { valorEfectivo += elPago.Valor; }
            }
            if (Math.Round(TotalPago, 2) != Math.Round(Convert.ToDouble(totVta), 2))
            {
                mensajesErrorDocumento.pagoDifiereTotalDoc();
                clasePagos = new DaxComercia.classPagosDoc();
                return false;
            }

            if (limitecredito > 0)
            {
                double saldoCliente = 0;
                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    string cod = "exec ADC_CCINDU '" + CodCliente + "','" + "01/01/1901" + "','" + idDoc.fecha + "'," + 0 + ",0,0,'C','',0,'" + datosEmpresa.suc + "','" + idDoc.Tipo + "'," + idDoc.idClave;
                    SqlCommand comm = new SqlCommand(cod, conn);
                    SqlDataReader dr = comm.ExecuteReader();
                                        
                    if (dr.Read()) saldoCliente = Convert.ToDouble(dr["Saldo"]);
                    dr.Close();
                    if (saldoCliente + valorCredito > limitecredito)
                    {
                        mensajesErrorDocumento.ventaExcedeCredito();
                        return false;
                    }
                }
            }
            clasePagos.totalContado = valorContado;
            return true;
        }

        public static void crearPagoPredefinido(ClassDoc.idDocumento idDoc, DaxComercia.classPagosDoc clasePagos, string IdPago, double valor = 0)
        {
            if (IdPago == "") IdPago = "EFE";
//            if (valor == 0) Convert.ToDouble(edTotal.Text);
            clasePagos.DocValor = valor;
            clasePagos.DocFecha = idDoc.fecha ;
            clasePagos.DocNumero = idDoc.numero;
            clasePagos.DocSucursal = datosEmpresa.suc;
            clasePagos.Doctipo = idDoc.Tipo;
            clasePagos.pagosDelDocumento.Add(DaxComercia.utility.CrearPagoDocumento(IdPago, clasePagos.DocValor));
        }

        static public Boolean validarFecha(string fechaDoc, string Usuario)
        {
            if (Usuario.ToUpper() == "ADMINISTRADOR") return true;
            DateTime ff;
            Boolean falso = false;

            try { ff = Convert.ToDateTime(fechaDoc); }
            catch { mensajesErrorDocumento.MensajeFechaErrada(); return falso; }
            CtaMtn.ContrlPeriodo prog = new CtaMtn.ContrlPeriodo();
            string error = prog.valPeriodo(ref Usuario, ref ff, ref falso);
            if (error != "") { mensajesErrorDocumento.MensajeFechaErrada(error); return false; }
            return true;
        }

        public static Boolean ValidarCorreoElectronicoVtas(string correo)
        {
            if (correo.Length == 0) return false;
            if (correo.IndexOf("@") < 0) return false;
            if (correo.IndexOf(".") < 0) return false;
            return true;
        }
        static public Boolean validarIngresoDetalle(DataGridView malla, string campo)
        {
            Boolean ret = false;
            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.Cells[campo].Value.ToString() != "") return true;
            }
            return ret;
        }
        static public Boolean ControlValidacionFacCli(ref DataGridView malla, ref sesSys.OpcDoc opcDoc, ctrlReferencia.controlReferencial classReferencia, string fechaFin, string sucursal, string strConxAdcom, string strConxDaxsys, double idClaveDoc, string bodega, string numeroDoc, Boolean esEntregasPendientes, string sucDocSoporte, string tipDocSoporte, string numDocSoporte)
        { 

            string codArticulo = "";
            SaldoArticulo saldoArt = new SaldoArticulo();
            ultimosValor ult = new ultimosValor();
            int multiplo = 1;

            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.Cells["TRA_QUEtipo"].Value.ToString() == "A")
                {
                    codArticulo = row.Cells["TRA_Codigo"].Value.ToString();
                    multiplo = 1;
                    try { multiplo = Convert.ToInt32(row.Cells["tra_multiplo"].Value); }
                    catch { multiplo = 1; };
                    if (multiplo == 0) multiplo = 1;

                    if (Convert.ToDouble(row.Cells["tra_Cantidad"].Value.ToString()) == 0 && opcDoc.PermiteCantidadCero != 1)
                    {
                        mensajesErrorDocumento.articuloCantidadNocero(codArticulo);
                        return false;
                    }

                    if (Convert.ToDouble(row.Cells["tra_Cantidad"].Value.ToString()) < 0)
                    {
                        mensajesErrorDocumento.articuloCantidadNoNegativa(codArticulo);
                        return false;
                    }
                    if (opcDoc.ClaveInventario == -1)
                    {
                        double SalMalla = SaldoMalla(codArticulo, ref malla, row.Index) * opcDoc.ClaveInventario;
                        if (opcDoc.TipoSoporteObligatorio != "")
                        {
                            if (classReferencia.traSoporte.Rows.Count > 0)
                            {
                                DataRow[] dtr = classReferencia.traSoporte.Select(" tra_codigo like ('%" + codArticulo + "%')");
                                if (dtr.Length > 0)
                                {
                                    if (Convert.ToDouble("0" + classReferencia.traSoporte.Rows[0]["Pendiente"].ToString()) + SalMalla < Convert.ToDouble(row.Cells["cantidad"]) * multiplo)
                                    {
                                        string ssql = "La cantidad (" + row.Cells["cantidad"].Value.ToString() + ") del artículo (" + codArticulo + ") \n excede el pendiente a entregar : " + classReferencia.traSoporte.Rows[0]["Pendiente"].ToString();
                                        if (SalMalla > 0) ssql = ssql + " más otra entrega en documento actual " + SalMalla.ToString();
                                        MessageBox.Show(ssql, "Control entregas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    mensajesErrorDocumento.articuloNoEnSoporte(codArticulo);
                                    return false;
                                }
                            }
                            else
                            {
                                mensajesErrorDocumento.articuloNoEnSoporte(codArticulo);
                                return false;
                            }
                        }
                        if (Convert.ToBoolean(opcDoc.SNSinExist) == false)
                        {
                            saldoArt = ultimosValor.SaldoFecha(strConxAdcom, codArticulo, fechaFin, "", sucursal, opcDoc.Documento, idClaveDoc, bodega);
                            double SalActual = saldoArt.CantidadBodega; 
                            if ((SalActual + SalMalla) < Convert.ToDouble("0" + row.Cells["tra_cantidad"].Value.ToString()) * multiplo)
                            {
                                mensajesErrorDocumento.articuloSinSaldo(codArticulo);
                                return false;
                            }
                        }
                    }

                }
                if (opcDoc.TipoDoc  == "FAC")
                {
                    if (Convert.ToBoolean(opcDoc.NoPVPbajoCosto))
                    {
                        double UltCosto = ultimosValor.UltimoCostoCompra("", "", codArticulo, false, "", opcDoc.Documento, Convert.ToDateTime(fechaFin), strConxAdcom, strConxDaxsys);
                        if (Convert.ToDouble(row.Cells["PrecioVenta"]) <= UltCosto)
                        {
                            mensajesErrorDocumento.precioMasBajoCosto(codArticulo);
                            return false;
                        }
                    }
                }

                if (esEntregasPendientes)
                {
                    if (ultimosValor.SaldoPorEntregar(fechaFin, codArticulo, sucursal, tipDocSoporte, numDocSoporte, sucursal, opcDoc.Documento, numeroDoc, strConxAdcom) < Convert.ToDouble((row.Cells["Cantidad"].Value.ToString())) * multiplo)
                    {
                        mensajesErrorDocumento.articuloExcedeEntrega(codArticulo);
                        return false;
                    }
                }

                //  if .ColWidth(51) > 0 And val(row.Cells["51)) > 0 Then
                //        If val(row.Cells["51)) > val(row.Cells["Cantidad"].Value.ToString()) Then
                //          MsgBox "No puede despachar cantidad mayor a la del documento", vbCritical
                //                Validacion = False
                //              .Col = 51
                //              .Row = I
                //              Exit For
                //        End If
                //    End If
            }
            return true;
        }
        public static  Boolean validarIngresoDetalle(DataGridView malla)
        {
            ////ANDRES
            Boolean ret = false;
            foreach (DataGridViewRow row in malla.Rows)
            {
                if (row.Cells["Tra_Codigo"].Value.ToString() != "") return true;
            }
            return ret;
        }
        public static double SaldoMalla(string codigo, ref DataGridView Malla, int lineaActual)
        {
            double Saldo = 0;
            //Int32 lineaActual = Malla.CurrentRow.Index;
            foreach (DataGridViewRow row in Malla.Rows)
            {
                if (row.Cells["TRA_CODIGO"].Value.ToString() == codigo && lineaActual != row.Index)
                {
                    Saldo += Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) * Convert.ToDouble("0" + row.Cells["tra_Multiplo"].Value);
                }
            }
            return Saldo;
        }

    }

}
