using System;
using DattCom;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DctosEmi
{
    internal class AutorizacionesFac
    {
        internal static void HabilitarOpcionesDocumento(FormFactCliente formulario)
        {
            HabilitarSoporte(formulario,(formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", formulario.propiedadesDoc));
            //OJO
            //formulario.btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", formulario.propiedadesDoc));

            //OJO
            //formulario.btnPendientes.Visible = true;

            //OJO
            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }
        internal static void HabilitarOpcionesDocumento(FormProforma formulario)
        {
            HabilitarSoporte(formulario, (formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", formulario.propiedadesDoc));

            //formulario.btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", formulario.propiedadesDoc));

            //formulario.btnPendientes.Visible = true;
            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }

        internal static void HabilitarOpcionesDocumento(FormPedCliente formulario)
        {
            HabilitarSoporte(formulario, (formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", formulario.propiedadesDoc));

            //formulario.btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", formulario.propiedadesDoc));

            //formulario.btnPendientes.Visible = true;
            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }
        internal static void HabilitarOpcionesDocumento(FormDevolucion formulario)
        {
            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", formulario.propiedadesDoc));

            //formulario.btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", formulario.propiedadesDoc));

            //formulario.btnPendientes.Visible = true;
            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }
        internal static void HabilitarOpcionesDocumento(FormFactProveedor formulario)
        {
            HabilitarSoporte(formulario, (formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", formulario.propiedadesDoc));

            //formulario.btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", formulario.propiedadesDoc));



            ///PENDIENTE JO
            //formulario.btnPendientes.Visible = true;

            //OJO

            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            
            //andres permisos de bodega

            //formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            //formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }
        internal static void HabilitarOpcionesDocumento(FormDocInventario formulario)
        {
            HabilitarSoporte(formulario, (formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnPendientes.Visible = true;
            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }

        internal static void HabilitarOpcionesDocumento(FormTransferenciaInv formulario)
        {
           // HabilitarSoporte(formulario, (formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            //formulario.btnPendientes.Visible = true;
            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);
            formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }

        internal static void HabilitarOpcionesDocumento(FormIngImportacion formulario)
        {
            HabilitarSoporte(formulario, (formulario.propiedadesDoc.TipoSoporteObligatorio.Length > 0 && formulario.propiedadesDoc.TipoSoporteObligatorio != "ORP") || datosAuxiliares.tieneDatoDocumento("DocumentoReferencia", formulario.propiedadesDoc));

            formulario.labNroLote.Visible = (datosAuxiliares.tieneDatoDocumento("NúmeroLote", formulario.propiedadesDoc));
            formulario.txtNroLote.Visible = formulario.labNroLote.Visible;

            formulario.btnDescuentos.Visible = (datosAuxiliares.tieneDatoDocumento("DescuentoDocumento", formulario.propiedadesDoc));

            //formulario.btnExportacion.Visible = (datosAuxiliares.tieneDatoDocumento("Transporte", formulario.propiedadesDoc));



            ///PENDIENTE JO
            //formulario.btnPendientes.Visible = true;

            //OJO

            // chequear lectura de parametros en varbl
            //btnContabiliza.Visible = (datosEmpresa.auto.Substring(3, 1) == "1" && propiedadesDoc.noCtbLinea != "X" && propiedadesDoc.SNContabilizar != 0);

            //andres permisos de bodega

            //formulario.cmbBodega.Visible = (datosAuxiliares.tieneDatoDocumento("Bodega", formulario.propiedadesDoc));
            //formulario.lbBodega.Visible = formulario.cmbBodega.Visible;
            if (formulario.accesosLocalizados.sinRegistro == false) registrarAccesosLocalizadosDocumento(formulario);
        }

        internal static void prepararBotones( FormDocInventario formulario)
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

            formulario.btnAbre.Enabled = inicio;
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
            formulario.txtcedula.Enabled = (!docAnulado);

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
                formulario.btnAbre.Enabled = (formulario.btnAbre.Enabled && (formulario.accesosLocalizados.Modificar || formulario.accesosLocalizados.Consultar));
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

        static void registrarAccesosLocalizadosDocumento(FormFactCliente formulario)
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
        static void registrarAccesosLocalizadosDocumento(FormProforma formulario)
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

        static void registrarAccesosLocalizadosDocumento(FormPedCliente formulario)
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
        static void registrarAccesosLocalizadosDocumento(FormDevolucion formulario)
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
        static void registrarAccesosLocalizadosDocumento(FormFactProveedor formulario)
        {
            if (formulario.accesosLocalizados.sinRegistro) return;

            formulario.txtnumero.Enabled = formulario.accesosLocalizados.NúmeroDocumento;
            formulario.txtfecha.Enabled = formulario.accesosLocalizados.FechaDocumento;

            //formulario.cmbVendedor.Enabled = formulario.accesosLocalizados.Vendedor;
            //if (formulario.accesosLocalizados.VendedorFijo.Length > 0)
            //{
            //    formulario.cmbVendedor.SelectedValue = formulario.accesosLocalizados.VendedorFijo;
            //    formulario.cmbVendedor.Enabled = false;
            //}
        }
        static void registrarAccesosLocalizadosDocumento(FormDocInventario formulario)
        {
            if (formulario.accesosLocalizados.sinRegistro) return;

            formulario.txtnumero.Enabled = formulario.accesosLocalizados.NúmeroDocumento;
            formulario.txtfecha.Enabled = formulario.accesosLocalizados.FechaDocumento;

            //formulario.cmbVendedor.Enabled = formulario.accesosLocalizados.Vendedor;
            //if (formulario.accesosLocalizados.VendedorFijo.Length > 0)
            //{
            //    formulario.cmbVendedor.SelectedValue = formulario.accesosLocalizados.VendedorFijo;
            //    formulario.cmbVendedor.Enabled = false;
            //}
        }
        static void registrarAccesosLocalizadosDocumento(FormTransferenciaInv formulario)
        {
            if (formulario.accesosLocalizados.sinRegistro) return;

            formulario.txtnumero.Enabled = formulario.accesosLocalizados.NúmeroDocumento;
            formulario.txtfecha.Enabled = formulario.accesosLocalizados.FechaDocumento;

            //formulario.cmbVendedor.Enabled = formulario.accesosLocalizados.Vendedor;
            //if (formulario.accesosLocalizados.VendedorFijo.Length > 0)
            //{
            //    formulario.cmbVendedor.SelectedValue = formulario.accesosLocalizados.VendedorFijo;
            //    formulario.cmbVendedor.Enabled = false;
            //}
        }

        static void registrarAccesosLocalizadosDocumento(FormIngImportacion formulario)
        {
            if (formulario.accesosLocalizados.sinRegistro) return;

            formulario.txtnumero.Enabled = formulario.accesosLocalizados.NúmeroDocumento;
            formulario.txtfecha.Enabled = formulario.accesosLocalizados.FechaDocumento;

            //formulario.cmbVendedor.Enabled = formulario.accesosLocalizados.Vendedor;
            //if (formulario.accesosLocalizados.VendedorFijo.Length > 0)
            //{
            //    formulario.cmbVendedor.SelectedValue = formulario.accesosLocalizados.VendedorFijo;
            //    formulario.cmbVendedor.Enabled = false;
            //}
        }

        static void HabilitarSoporte(FormFactCliente formulario, bool tieneSoporte)
        {
            formulario.cmbDocumentoSustento.Visible = tieneSoporte;
            formulario.labSoporteNumero.Visible = tieneSoporte;
            formulario.labSoporteTipo.Visible = tieneSoporte;
            formulario.nroDocSoporte.Visible = tieneSoporte;
            formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
            //if (tieneSoporte) LlenarComboDocReferencia();
            //if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
            //{
            //	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
            //	cmbDocumentoSustento.Enabled = false;
            //}
        }
        static void HabilitarSoporte(FormProforma formulario, bool tieneSoporte)
        {
            formulario.cmbDocumentoSustento.Visible = tieneSoporte;
            formulario.labSoporteNumero.Visible = tieneSoporte;
            formulario.labSoporteTipo.Visible = tieneSoporte;
            formulario.nroDocSoporte.Visible = tieneSoporte;
            formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
            //if (tieneSoporte) LlenarComboDocReferencia();
            //if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
            //{
            //	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
            //	cmbDocumentoSustento.Enabled = false;
            //}
        }

        static void HabilitarSoporte(FormPedCliente formulario, bool tieneSoporte)
        {
            formulario.cmbDocumentoSustento.Visible = tieneSoporte;
            formulario.labSoporteNumero.Visible = tieneSoporte;
            formulario.labSoporteTipo.Visible = tieneSoporte;
            formulario.nroDocSoporte.Visible = tieneSoporte;
            formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
            //if (tieneSoporte) LlenarComboDocReferencia();
            //if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
            //{
            //	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
            //	cmbDocumentoSustento.Enabled = false;
            //}
        }

        //static void HabilitarSoporte(FormDevolucion formulario, bool tieneSoporte)
        //{
        //    formulario.cmbDocumentoSustento.Visible = tieneSoporte;
        //    formulario.labSoporteNumero.Visible = tieneSoporte;
        //    formulario.labSoporteTipo.Visible = tieneSoporte;
        //    formulario.nroDocSoporte.Visible = tieneSoporte;
        //    formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
        //    //if (tieneSoporte) LlenarComboDocReferencia();
        //    //if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
        //    //{
        //    //	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
        //    //	cmbDocumentoSustento.Enabled = false;
        //    //}
        //}
        static void HabilitarSoporte(FormFactProveedor formulario, bool tieneSoporte)
        {
            formulario.cmbDocumentoSustento.Visible = tieneSoporte;
            formulario.labSoporteNumero.Visible = tieneSoporte;
            formulario.labSoporteTipo.Visible = tieneSoporte;
            formulario.nroDocSoporte.Visible = tieneSoporte;
            formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
            //if (tieneSoporte) LlenarComboDocReferencia();
            //if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
            //{
            //	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
            //	cmbDocumentoSustento.Enabled = false;
            //}

        }
        static void HabilitarSoporte(FormDocInventario formulario, bool tieneSoporte)
        {
            formulario.cmbDocumentoSustento.Visible = tieneSoporte;
            formulario.labSoporteNumero.Visible = tieneSoporte;
            formulario.labSoporteTipo.Visible = tieneSoporte;
            formulario.nroDocSoporte.Visible = tieneSoporte;
            formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
        }

        static void HabilitarSoporte(FormIngImportacion formulario, bool tieneSoporte)
        {
            formulario.cmbDocumentoSustento.Visible = tieneSoporte;
            formulario.labSoporteNumero.Visible = tieneSoporte;
            formulario.labSoporteTipo.Visible = tieneSoporte;
            formulario.nroDocSoporte.Visible = tieneSoporte;
            formulario.btnBuscaDocumentoSoporte.Visible = tieneSoporte;
            //if (tieneSoporte) LlenarComboDocReferencia();
            //if (propiedadesDoc.TipoSoporteObligatorio.Length > 0)
            //{
            //	cmbDocumentoSustento.SelectedValue = propiedadesDoc.TipoSoporteObligatorio;
            //	cmbDocumentoSustento.Enabled = false;
            //}

        }

    }
}
