using System;
using DattCom;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DctosEmi
{
    internal class AutorizacionesDoc
    {
        internal static void HabilitarOpcionesDocumento(frmEgrBcoCaj formulario)
        {

            formulario.cmbVendedor.Visible = (DctosEmi.datosAuxiliares.tieneDatoDocumento("Vendedor", formulario.propiedadesDoc));
            formulario.lbVendedor.Visible = formulario.cmbVendedor.Visible;

            formulario.labNroLote.Visible = (DctosEmi.datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;
            formulario.btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && formulario.propiedadesDoc.noCtbLinea != "X" && formulario.propiedadesDoc.SNContabilizar != 0);
            if (!formulario.accesosLocalizados.sinRegistro) AutorizacionesDoc.registrarAccesosLocalizadosDocumento(formulario);
            formulario.EsIngreso = false;
            formulario.EsCliente = false;
            formulario.EsProveedor = false;
            formulario.Estransferencia = false;
            formulario.txtFechaVence.Visible = false;
            formulario.labNrocheque.Visible = false;
            formulario.TxtNroCheque.Visible = false;
            formulario.labFechaVence.Visible = false;
            formulario.BtnImprimeCheque.Visible = false;

            switch (formulario.idDocumentoActual.familia)
            {
                case "ING":
                    formulario.Text = "MANTENIMIENTO INGRESOS A BANCOS";
                    formulario.EsIngreso = true;
                    formulario.labNrocheque.Visible = true;
                    formulario.TxtNroCheque.Visible = true;
                    formulario.labNrocheque.Text = "Nro.Depósito";
                    formulario.labNombreBanco.Text = "Banco";
                    formulario.TipoConcptoBusca = "I";
                    break;
                case "EGR":
                    formulario.Text = "MANTENIMIENTO EGRESOS DE BANCOS";
                    formulario.labNrocheque.Visible = true;
                    formulario.TxtNroCheque.Visible = true;
                    formulario.labNrocheque.Text = "Nro.Cheque";
                    formulario.labNombreBanco.Text = "Banco";
                    formulario.TipoConcptoBusca = "E";
                    formulario.BtnImprimeCheque.Visible = true;
                    break;
                case "VIC":
                    formulario.Text = "MANTENIMIENTO VALES DE INGRESO A CAJA";
                    formulario.labNombreBanco.Text = "Caja";
                    formulario.EsIngreso = true;
                    formulario.TipoConcptoBusca = "I";
                    break;
                case "VEC":
                    formulario.Text = "MANTENIMIENTO VALES DE EGRESO DE CAJA";
                    formulario.labNombreBanco.Text = "Caja";
                    formulario.TipoConcptoBusca = "E";
                    break;
                case "NCB":
                    formulario.Text = "MANTENIMIENTO NOTAS DE CREDITO BANCARIAS";
                    formulario.EsIngreso = true;
                    formulario.labNombreBanco.Text = "Banco";
                    formulario.TipoConcptoBusca = "I";
                    break;
                case "NDB":
                    formulario.labNombreBanco.Text = "Banco";
                    formulario.Text = "MANTENIMIENTO NOTAS DE DEBITO BANCARIAS";
                    formulario.TipoConcptoBusca = "E";
                    break;
            }

            if (formulario.EsIngreso) { formulario.label2.Text = "Origen"; } else { formulario.label2.Text = "Beneficiario"; }
        }
        internal static void prepararBotones( frmEgrBcoCaj formulario)
        {
            Boolean inicio = (formulario.operacionEnCurso == formulario.sinOperacion);
            Boolean nuevo = (formulario.operacionEnCurso == formulario.nuevoRegistro);
            Boolean modificando = (formulario.operacionEnCurso == formulario.modificandoRegistro);
            Boolean docAnulado = false;
            try
            {
                docAnulado = (formulario.datADCDOC.Doc_Estado == 0 && modificando);
            }
            catch { }

            formulario.BtnAbre.Enabled = inicio;
            formulario.btnNuevo.Enabled = inicio;

            //btnCopia.Enabled = nuevo;

            formulario.btnAnula.Enabled = (modificando && !docAnulado);
            formulario.btnElimina.Enabled = modificando;
            formulario.btnEnviar.Enabled = modificando;
            formulario.btnGraba.Enabled = (!inicio && !docAnulado);
            formulario.btnRegistra.Enabled = formulario.btnGraba.Enabled;
            formulario.btnEnviar.Enabled = (modificando && !docAnulado);
            formulario.btnCierra.Enabled = !inicio;
            //btnContabiliza.Enabled = btnGraba.Enabled;
            formulario.panel1.Enabled = (!inicio);
            formulario.malla.Enabled = (!inicio);
            formulario.cmbDocumento.Enabled = (inicio);
            formulario.txtCodper.Enabled = (!docAnulado);

            if (DatosUsuario.codigo.ToUpper() == "ADMINISTRADOR") return;
            if (formulario.accesosLocalizados.sinRegistro == false)
            {
                if (nuevo)
                {
                    formulario.btnGraba.Enabled = (formulario.btnGraba.Enabled && (formulario.accesosLocalizados.Crear)); //|| (formulario.accesosLocalizados.Modificar && modificando));
                    formulario.btnRegistra.Enabled = (formulario.btnRegistra.Enabled && (formulario.btnGraba.Enabled && formulario.accesosLocalizados.Imprimir));
                }
                else if (modificando)
                {
                    formulario.btnGraba.Enabled = (formulario.btnGraba.Enabled && (formulario.accesosLocalizados.Modificar)); //|| (formulario.accesosLocalizados.Modificar && modificando));
                    formulario.btnRegistra.Enabled = (formulario.btnRegistra.Enabled && (formulario.btnGraba.Enabled && formulario.accesosLocalizados.Modificar && formulario.accesosLocalizados.Imprimir));
                }
                formulario.BtnAbre.Enabled = (formulario.BtnAbre.Enabled && (formulario.accesosLocalizados.Modificar || formulario.accesosLocalizados.Consultar));
                formulario.btnEnviar.Enabled = (formulario.btnEnviar.Enabled && formulario.accesosLocalizados.Imprimir); //(formulario.accesosLocalizados.Imprimir && !inicio);
                formulario.btnNuevo.Enabled = (formulario.accesosLocalizados.Crear && formulario.btnNuevo.Enabled);
                formulario.btnElimina.Enabled = (formulario.accesosLocalizados.Eliminar && formulario.btnElimina.Enabled);
                formulario.btnAnula.Enabled = (formulario.accesosLocalizados.Anular && formulario.btnAnula.Enabled);


                //btnCopia.Enabled = (formulario.accesosLocalizados.Crear && btnCopia.Enabled);

            }
            registrarAccesosLocalizadosDocumento(formulario);

            if (formulario.esSoloConsulta == true || docAnulado)
            {
                formulario.btnGraba.Enabled = false;
                formulario.btnRegistra.Enabled = false;
                formulario.btnElimina.Enabled = false;
                formulario.btnAnula.Enabled = false;
                if (formulario.datADCDOC.Doc_Estado == 1) formulario.btnElimina.Enabled = (DatosUsuario.codigo.ToUpper() == "ADMINISTRADOR");
            }
        }

        static void registrarAccesosLocalizadosDocumento(frmEgrBcoCaj formulario)
        {
            if (formulario.accesosLocalizados.sinRegistro) return;

            formulario.txtnumero.Enabled = formulario.accesosLocalizados.NúmeroDocumento;
            formulario.txtfecha.Enabled = formulario.accesosLocalizados.FechaDocumento;

            formulario.cmbVendedor.Enabled = formulario.accesosLocalizados.Vendedor;
            if (formulario.accesosLocalizados.VendedorFijo.Length > 0)
            {
                formulario.cmbVendedor.SelectedValue = formulario.accesosLocalizados.VendedorFijo;
                formulario.cmbVendedor.Enabled = false;
            }
        }

    }
}
