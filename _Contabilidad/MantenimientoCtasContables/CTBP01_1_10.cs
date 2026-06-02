using System;
using System.Data;
using System.Windows.Forms;
using DaxClasificadores;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    internal partial class CTBP01_1 : Form
    {
        private string CodigoCta;
        private Cuenta ctaActual = new Cuenta();
        private bool Sw;
        private short ctr;
        private DataTable RsCta;
        private string CtaIni, Qaccion;
        private short NivelIni, GrupoIni;
        private string txtCta;
        private TreeView Arbolito;
        private string CtaPadre;
        // Dim Txtcc() As Windows.Forms.TextBox
        private const string Nombre = "Maestro de Cuentas contables";
        private bool TeniaConcepto;
        private Collection TxtCtrl = new Collection();
        private TextBox[] txtCodCta = new TextBox[10];
        private System.Data.SqlClient.SqlConnection ConxAdcom = new System.Data.SqlClient.SqlConnection();

        public void CrearCuenta(ref string codigo, ref short NivelCta, ref short Grupo, ref string Accion, ref TreeView Arbol)
        {
            var CtaMayor = new Cuenta();
            // Dim prog As New DaxLib.DaxLibMalla
            // prog.ColorF(Me)
            // prog = Nothing

            Arbolito = Arbol;
            CtaIni = codigo;
            NivelIni = NivelCta;
            GrupoIni = Grupo;
            OperacionesBuscaCta.EsNuevo = Conversions.ToShort(true);
            Qaccion = Accion;
            var CtaPapa = new Cuenta();
            string[] Aux;
            int I;
            int j;
            int gg;
            switch (Qaccion ?? "")
            {
                case "N":
                    {
                        CtaPadre = OperacionesBuscaCta.QuePadreDeCta(ref CtaIni, ref NivelIni);
                        txtCta = CtaPadre;
                        CtaPapa.Cargar(ref CtaPadre);
                        {
                            var withBlock = CtaPapa;
                            gg = (int)Math.Round(Conversion.Val(withBlock.Grupo));
                            if (gg == 0)
                                gg = 1;
                            dcGruCon.SelectedIndex = gg - 1;
                            dcGruCon.Enabled = false;
                            if (Operators.CompareString(withBlock.ModuloAuxiliar, "", false) > 0)
                            {
                                DcModulo.Text = withBlock.ModuloAuxiliar;
                                DcModulo.Enabled = false;
                            }

                            switch (withBlock.TipoPresu ?? "")
                            {
                                case "F":
                                    {
                                        opMenFij.Checked = true;
                                        break;
                                    }

                                case "V":
                                    {
                                        opMenVar.Checked = true;
                                        break;
                                    }

                                default:
                                    {
                                        opSinPre.Checked = true;
                                        break;
                                    }
                            }

                            // If Not IsNull(!cta_claveseg) Then txtCla = !cta_claveseg
                            if (Operators.CompareString(withBlock.ClaveAux1, "", false) > 0)
                            {
                                txtC1.Text = withBlock.ClaveAux1;
                                txtC1.Enabled = false;
                            }

                            if (Operators.CompareString(withBlock.ClaveAux2, "", false) > 0)
                            {
                                txtC2.Text = withBlock.ClaveAux2;
                                txtC2.Enabled = false;
                            }

                            if (Operators.CompareString(withBlock.ClaveAux3, "", false) > 0)
                            {
                                txtC3.Text = withBlock.ClaveAux3;
                                txtC3.Enabled = false;
                            }

                            if (Operators.CompareString(withBlock.ClaveAux4, "", false) > 0)
                            {
                                txtC4.Text = withBlock.ClaveAux4;
                                txtC4.Enabled = false;
                            }

                            Aux = Strings.Split(withBlock.Clasificadores, ";");
                            if (Information.UBound(Aux) > 0)
                            {
                                var loopTo = Information.UBound(Aux);
                                for (I = 0; I <= loopTo; I++)
                                {
                                    var loopTo1 = Clasificadores.Items.Count - 1;
                                    for (j = 0; j <= loopTo1; j++)
                                    {
                                        if (Convert.ToBoolean(Operators.ConditionalCompareObjectEqual(Aux[I], Clasificadores.Items[j], false)))
                                        {
                                            Clasificadores.SetItemChecked(j, true);
                                        }
                                    }
                                }
                            }
                        }

                        CtaPapa = null;
                        break;
                    }

                case "I":
                    {
                        txtCta = CtaIni;
                        NivelIni = (short)(NivelIni + 1);
                        CtaPadre = OperacionesBuscaCta.QuePadreDeCta(ref CtaIni, ref NivelIni);
                        break;
                    }

                case "M":
                    {
                        txtCta = CtaIni;
                        OperacionesBuscaCta.EsNuevo = Conversions.ToShort(false);
                        CtaPadre = OperacionesBuscaCta.QuePadreDeCta(ref CtaIni, ref NivelIni);
                        break;
                    }
            }

            // If NivelIni > 6 Or NivelIni = 0 Then Unload Me: Exit Sub
            ShowDialog();
        }

        private void btnsalir_Click()
        {
            if (Interaction.MsgBox("Esta seguro que desea cancelar, se perdera toda la información", (MsgBoxStyle)36) == MsgBoxResult.Yes)
                Close();
        }

        private void Chkcompras_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void chkDeAgrupacion_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void chkegresobanco_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void chkfacturacion_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void Chkingresobanco_CheckStateChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void dcGruCon_SelectedIndexChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void DcModulo_SelectedIndexChanged(object eventSender, EventArgs eventArgs)
        {
            FuncionCuenta();
        }

        private void FuncionCuenta()
        {
            if (chkDeAgrupacion.CheckState == 0)
            {
                Frconceptos.Enabled = true;
                if (Chkingresobanco.CheckState != 0)
                {
                    chkegresobanco.CheckState = CheckState.Unchecked;
                    Chkcompras.CheckState = CheckState.Unchecked;
                    chkfacturacion.CheckState = CheckState.Unchecked;
                }
                else if (chkegresobanco.CheckState != 0)
                {
                    Chkingresobanco.CheckState = CheckState.Unchecked;
                    Chkcompras.CheckState = CheckState.Unchecked;
                    chkfacturacion.CheckState = CheckState.Unchecked;
                }
                else if (Chkcompras.CheckState != 0)
                {
                    Chkingresobanco.CheckState = CheckState.Unchecked;
                    chkfacturacion.CheckState = CheckState.Unchecked;
                    chkegresobanco.CheckState = CheckState.Unchecked;
                }
                else if (chkfacturacion.CheckState != 0)
                {
                    Chkingresobanco.CheckState = CheckState.Unchecked;
                    chkegresobanco.CheckState = CheckState.Unchecked;
                    Chkcompras.CheckState = CheckState.Unchecked;
                }
            }
            else
            {
                Frconceptos.Enabled = false;
                Chkingresobanco.CheckState = CheckState.Unchecked;
                chkegresobanco.CheckState = CheckState.Unchecked;
                Chkcompras.CheckState = CheckState.Unchecked;
                chkfacturacion.CheckState = CheckState.Unchecked;
            }
        }

        private void OrganizarNiveles()
        {
            short Temp = 0;
            short I = 0;
            var Niv = default(short);
            short CtaNumNiveles;
            string CtaNumDigNivel;
            // Dim linkdat As New DaxData.DaxLibDatos
            // Creo la clase Cuenta

            Button1.Visible = false;
            ctaActual = new Cuenta();
            limpiar();
            Temp = 1;
            CtaNumNiveles = (short)emp.CtaNumNiveles;
            CtaNumDigNivel = emp.CtaNumDigNivel.ToString();
            var loopTo = NivelIni;
            for (I = 1; I <= loopTo; I++)
            {
                {
                    var withBlock = txtCodCta[I];
                    if (I > CtaNumNiveles)
                    {
                        withBlock.Visible = false;
                    }
                    else
                    {
                        withBlock.Visible = true;
                        withBlock.MaxLength = Convert.ToInt32(Strings.Mid(CtaNumDigNivel, I, 1));
                        withBlock.Text = Strings.Mid(txtCta, Temp, txtCodCta[I].MaxLength);
                        withBlock.Width = 14 + (withBlock.MaxLength - 1) * 10;
                        ToolTip1.SetToolTip(txtCodCta[I], Conversions.ToString(Operators.ConcatenateObject(withBlock.MaxLength, Interaction.IIf(withBlock.MaxLength == 1, " Dígito", " Dígitos"))));
                        if (I > 1)
                            withBlock.Left = txtCodCta[I - 1].Left + 2 + txtCodCta[I - 1].Width;
                        Temp = (short)(Temp + withBlock.MaxLength);
                        withBlock.ReadOnly = true;
                    }
                }
            }

            if (Convert.ToBoolean(OperacionesBuscaCta.EsNuevo))
            {
                dcGruCon.SelectedIndex = GrupoIni - 1;
                txtCodCta[NivelIni].ReadOnly = false;
                Button1.Left = txtCodCta[NivelIni].Left;
                Button1.Width = txtCodCta[NivelIni].Width;
                Button1.Visible = true;
                Button1.Top = txtCodCta[NivelIni].Top + txtCodCta[NivelIni].Height + 1;
                Button1.Text = NivelIni.ToString();
                if (Niv != 0)
                    txtCodCta[Niv + 1].Focus();
            }
            else
            {
                ctaActual.Cargar(ref CtaIni);
                CargarDatos();
            }
        }

        private void existenregistros()
        {
            // On Error GoTo HayErrores
            // ********** Controlar los botones, hacer visibles e invisibles ********
            if (RsCta.Rows.Count > 0)
            {
                CargarDatos();
            }

            return;
            // HayErrores:
            // controlaerrores
        }

        public void CargarDatos()
        {
            string[] Aux;
            limpiar();
            short Temp, I, j;
            if (Operators.CompareString(ctaActual.codigo, "", false) > 0)
            {
                {
                    var withBlock = ctaActual;
                    Temp = 1;
                    txtCta = withBlock.codigo;
                    CodigoCta = txtCta;
                    txtNomCta.Text = withBlock.Nombre;
                    CtaAlterna.Text = withBlock.CodigoAlterno;
                    var loopTo = (short)Strings.Len(txtCta);
                    for (I = 1; I <= loopTo; I++)
                    {
                        txtCodCta[Temp].Text = Strings.Mid(txtCta, I, txtCodCta[Temp].MaxLength);
                        I = (short)(I + txtCodCta[Temp].MaxLength - 1);
                        Temp = (short)(Temp + 1);
                    }

                    chkDeAgrupacion.CheckState = (CheckState)Interaction.IIf(withBlock.Agrupacion, 1, 0);
                    dcGruCon.SelectedIndex = (int)Math.Round(Conversions.ToDouble(withBlock.Grupo) - 1d); // ValidarCuentaContable (Mid$(.codigo, 1, 1)) - 1
                    DcModulo.Text = withBlock.ModuloAuxiliar;
                    Chkcompras.CheckState = (CheckState)Interaction.IIf(Convert.ToBoolean(withBlock.ConceptoCompras), 1, 0);
                    chkfacturacion.CheckState = (CheckState)Interaction.IIf(Convert.ToBoolean(withBlock.ConceptoVentas), 1, 0);
                    chkegresobanco.CheckState = (CheckState)Interaction.IIf(Convert.ToBoolean(withBlock.ConceptoBcoEgreso), 1, 0);
                    Chkingresobanco.CheckState = (CheckState)Interaction.IIf(Convert.ToBoolean(withBlock.ConceptoBcoIngreso), 1, 0);
                    switch (withBlock.TipoPresu ?? "")
                    {
                        case "F":
                            {
                                opMenFij.Checked = true;
                                break;
                            }

                        case "V":
                            {
                                opMenVar.Checked = true;
                                break;
                            }

                        default:
                            {
                                opSinPre.Checked = true;
                                break;
                            }
                    }
                    // If Not IsNull(!cta_claveseg) Then txtCla = !cta_claveseg
                    txtC1.Text = withBlock.ClaveAux1;
                    txtC2.Text = withBlock.ClaveAux2;
                    txtC3.Text = withBlock.ClaveAux3;
                    txtC4.Text = withBlock.ClaveAux4;
                    Aux = Strings.Split(withBlock.Clasificadores, ";");
                    if (Information.UBound(Aux) > 0)
                    {
                        var loopTo1 = (short)Information.UBound(Aux);
                        for (I = 0; I <= loopTo1; I++)
                        {
                            var loopTo2 = (short)(Clasificadores.Items.Count - 1);
                            for (j = 0; j <= loopTo2; j++)
                            {
                                if ((Aux[I] ?? "") == (Clasificadores.Items[j].ToString() ?? ""))
                                {
                                    Clasificadores.SetItemChecked(j, true);
                                }
                            }
                        }
                    }

                    Formatodetalle.Text = withBlock.Detalle;
                    DcModulo.Text = withBlock.ModuloAuxiliar;
                    Text = Nombre + "-" + withBlock.usuario;

                    // If Not IsNull(!Cta_CCosto) Then Check1.Value = IIf(!Cta_CCosto = "S", 1, 0)

                    // OpcCostos = !Cta_CostosDir
                    // OpCostoIndirecto = !Cta_CostosInDir
                    // OpcGasto = !Cta_Gasto
                    btnNoProduccion.Checked = false;
                    if (withBlock.tipoCosto == "MO")
                        btnMO.Checked = true;
                    if (withBlock.tipoCosto == "CD")
                        btnCD.Checked = true;
                    if (withBlock.tipoCosto == "CI")
                        btnCI.Checked = true;
                }
            }

            TeniaConcepto = false;
            if (Chkcompras.CheckState != 0 | chkfacturacion.CheckState != 0 | chkegresobanco.CheckState != 0 | Chkingresobanco.CheckState != 0)
            {
                CargarConcepto();
            }
        }

        private void btnGuardar_Click()
        {
            short Lon;
            short j;
            string cod;
            string Classi;
            string TTIPOCOS;
            // Dim linkdat As New DaxData.DaxLibDatos
            CodigoCta = CodCta();
            Lon = (short)Strings.Len(CodigoCta);
            if (ValidarCta())
            {
                {
                    var withBlock = ctaActual;
                    withBlock.codigo = CodigoCta;
                    withBlock.Nombre = txtNomCta.Text;
                    withBlock.Grupo = (dcGruCon.SelectedIndex + 1).ToString();
                    withBlock.CodigoAlterno = CtaAlterna.Text;
                    withBlock.Agrupacion = (int)chkDeAgrupacion.CheckState > 0;
                    if (opMenFij.Checked)
                    {
                        withBlock.TipoPresu = "F";
                    }
                    else if (opMenVar.Checked)
                    {
                        withBlock.TipoPresu = "V";
                    }
                    else
                    {
                        withBlock.TipoPresu = "";
                    }

                    withBlock.ClaveAux1 = txtC1.Text;
                    withBlock.ClaveAux2 = txtC2.Text;
                    withBlock.ClaveAux3 = txtC3.Text;
                    withBlock.ClaveAux4 = txtC4.Text;
                    cod = "";
                    var loopTo = (short)(Clasificadores.Items.Count - 1);
                    for (j = 0; j <= loopTo; j++)
                    {
                        if (Clasificadores.GetItemChecked(j) == true)
                        {
                            cod = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(cod, Clasificadores.Items[j]), ";"));
                        }
                    }

                    withBlock.Clasificadores = cod;
                    Classi = cod;
                    withBlock.Nivel = Nivel(ref CodigoCta);
                    withBlock.usuario = DatosUsuario.Identifica;
                    // .Gasto = OpcGasto
                    // .cosDirecto = OpcCostos
                    // .CosIndirecto = OpCostoIndirecto
                    // .Ccosto = IIf(Check1.Value = 0, "", "S")
                    withBlock.ConceptoCompras = (short)Chkcompras.CheckState;
                    withBlock.ConceptoVentas = (short)chkfacturacion.CheckState;
                    withBlock.ConceptoBcoEgreso = (short)chkegresobanco.CheckState;
                    withBlock.ConceptoBcoIngreso = (short)Chkingresobanco.CheckState;
                    // If Not IsNull(!cta_claveseg) Then txtCla = !cta_claveseg
                    withBlock.Detalle = Formatodetalle.Text;
                    withBlock.ModuloAuxiliar = DcModulo.Text;
                    withBlock.CuentaPadre = CtaPadre;
                    withBlock.tipoCosto = "";
                    if (btnMO.Checked)
                        withBlock.tipoCosto = "MO";
                    if (btnCD.Checked)
                        withBlock.tipoCosto = "CD";
                    if (btnCI.Checked)
                        withBlock.tipoCosto = "CI";
                    TTIPOCOS = withBlock.tipoCosto;
                }

                ctaActual.Guardar();
                if (Chkcompras.CheckState != 0 | chkfacturacion.CheckState != 0 | chkegresobanco.CheckState != 0 | Chkingresobanco.CheckState != 0)
                {
                    GrabarConcepto();
                }

                if ((int)chkDeAgrupacion.CheckState > 0)
                {
                    // If MsgBox("CONFIRMA REGISTRAR LAS PROPIEDADES DE ESTA CUENTA A TODAS LAS SUBCUENTAS DE NIVEL INFERIOR ?", vbYesNo + vbQuestion) = vbYes Then

                    cod = "UPDATE AdcCta SET ";
                    cod = cod + " Cta_tipopresu = '" + Strings.Trim(TipoPre()) + "' ";
                    // cod = cod & ", Cta_claveseg ='" & Trim$(txtCla) & "'"
                    cod = cod + ", Cta_claveaux1 ='" + Strings.Trim(txtC1.Text) + "' ";
                    cod = cod + ", Cta_claveaux2 ='" + Strings.Trim(txtC2.Text) + "' ";
                    cod = cod + ", Cta_claveaux3 ='" + Strings.Trim(txtC3.Text) + "' ";
                    cod = cod + ", Cta_claveaux4 ='" + Strings.Trim(txtC4.Text) + "' ";
                    cod = cod + ", clasificadores ='" + Strings.Trim(Classi) + "' ";
                    cod = cod + ", moduloauxiliar ='" + Strings.Trim(DcModulo.Text) + "' ";
                    cod = cod + ", tipoCosto ='" + Strings.Trim(TTIPOCOS) + "' ";
                    cod = cod + " where substring(cta_codigo,1," + Lon + ") = '" + CodigoCta + "'";
                    SqlDatos.ejecutarComando(cod, datosEmpresa.strConxAdcom);

                    // cod = "delete from AdcServ where AdcServ.Sev_codigo in"
                    // cod = cod & "("
                    // cod = cod & " Select AdcServ.Sev_codigo"
                    // cod = cod & " FROM         AdcServ LEFT OUTER JOIN"
                    // cod = cod & " AdcCta ON AdcServ.Sev_codigo = AdcCta.Cta_codigo"
                    // cod = cod & " where ISNULL(cta_nombre,'') > ''  and ISNULL(conceptocompras,0) = 0 and ISNULL(ConceptoVentas ,0) = 0"
                    // cod = cod & " and ISNULL(ConceptoBcoEgreso ,0) = 0 and ISNULL(ConceptoBcoIngreso ,0) = 0"
                    // cod = cod & ")"
                    // linkdat.DaxData("", cod)
                }
                // End If

            }

            // linkdat = Nothing
            if (chkDeAgrupacion.CheckState == 0)
            {
                if (Qaccion == "N" | Qaccion == "I")
                    InsertarEnArbol();
                if (Qaccion == "M")
                    ArreglarArbol();
            }

            Close();
        }

        private void GrabarConcepto()
        {
            var serv = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            serv = ClassDoc.Servicios.Buscar(" sev_codigo = '" + CodigoCta + "'");
            {
                var withBlock = serv;
                withBlock.Sev_codigo = CodigoCta;
                withBlock.Sev_nombre = txtNomCta.Text;
                withBlock.Sev_unimed = "UND";
                withBlock.Sev_precvta = 0m;
                withBlock.Sev_descuen = 0m;
                withBlock.Sev_fecfindes = Conversions.ToDate("00:00");
                withBlock.Sev_fecinides = Conversions.ToDate("00:00");
                withBlock.Sev_idcta = CodigoCta;
                withBlock.Sev_idcta2 = "";
                withBlock.Sev_idcta3 = "";
                withBlock.Sev_idcta4 = "";
                withBlock.Sev_SriBien = Conversions.ToShort(opbienes.Checked);
                withBlock.Sev_sniva = Convert.ToBoolean(chiva.CheckState);
                withBlock.Sev_TipoCos = "";
                withBlock.Sev_TipoSerSri = "";
                withBlock.sev_compras = Convert.ToBoolean(Chkcompras.CheckState);
                withBlock.sev_ventas = Convert.ToBoolean(chkfacturacion.CheckState);
                withBlock.sev_ingbanco = Convert.ToBoolean(Chkingresobanco.CheckState);
                withBlock.sev_egrbanco = Convert.ToBoolean(chkegresobanco.CheckState);
                withBlock.Sev_Hotel = false;
                withBlock.sev_escontable = true;
                withBlock.Actualizar();
            }

            serv = null;
        }

        private void CargarConcepto()
        {
            var serv = new ClassDoc.Servicios(datosEmpresa.strConxAdcom);
            serv = ClassDoc.Servicios.Buscar(" Sev_codigo = '" + CodigoCta + "'");
            opbienes.Checked = Convert.ToBoolean(serv.Sev_SriBien);
            if (serv.Sev_sniva == true)
            {
                chiva.CheckState = CheckState.Checked;
            }
            else
            {
                chiva.CheckState = CheckState.Unchecked;
            }

            Chkcompras.CheckState = (CheckState)Convert.ToInt32(serv.sev_compras);
            chkfacturacion.CheckState = (CheckState)Convert.ToInt32(serv.sev_ventas);
            Chkingresobanco.CheckState = (CheckState)Convert.ToInt32(serv.sev_ingbanco);
            chkegresobanco.CheckState = (CheckState)Convert.ToInt32(serv.sev_egrbanco);
            TeniaConcepto = true;
        }
        // Dim Aux As String
        private void ArreglarArbol()
        {
            Arbolito.Nodes.Remove(Arbolito.SelectedNode);
            InsertarEnArbol();
            Arbolito.Update();
            Arbolito.Sort();
        }

        private void InsertarEnArbol()
        {
            string Aux;
            {
                short argCtaNivel = Nivel(ref CodigoCta);
                Aux = OperacionesBuscaCta.QuePadreDeCta(ref CodigoCta, ref argCtaNivel);
                if (string.IsNullOrEmpty(Aux))
                {
                    Arbolito.Nodes.Find("M" + Strings.Trim(GrupoIni.ToString()), true)[0].Nodes.Add("C" + Strings.Trim(CodigoCta), CodigoCta + "  " + txtNomCta.Text, 2, 3);
                }
                else if ((int)chkDeAgrupacion.CheckState > 0)
                {
                    Arbolito.Nodes.Find("C" + Aux, true)[0].Nodes.Add("C" + Strings.Trim(CodigoCta), CodigoCta + "  " + txtNomCta.Text, 2, 3);
                }
                else
                {
                    Arbolito.Nodes.Find("C" + Aux, true)[0].Nodes.Add("C" + Strings.Trim(CodigoCta), CodigoCta + "  " + txtNomCta.Text, 4, 5);
                }
            }
        }

        private bool ValidarCta()
        {
            bool ValidarCtaRet = default;
            short I;
            ValidarCtaRet = true;
            var loopTo = (short)emp.CtaNumNiveles;
            for (I = 1; I <= loopTo; I++)
            {
                if (Strings.Len(txtCodCta[I].Text) < Conversions.ToDouble(Strings.Mid(emp.CtaNumDigNivel.ToString(), I, 1)) & txtCodCta[I].Visible == true)
                {
                    ValidarCtaRet = false;
                    Interaction.MsgBox("Los dígitos de la cuenta están mal registrados", MsgBoxStyle.Critical, Nombre);
                    return ValidarCtaRet;
                }
            }

            if (Convert.ToBoolean(OperacionesBuscaCta.EsNuevo & Conversions.ToShort(LeerCuenta(ref CodigoCta) == true)))
            {
                Interaction.MsgBox("La cuenta ha registrar ya existe", MsgBoxStyle.Critical, Nombre);
                ValidarCtaRet = false;
            }

            if (string.IsNullOrEmpty(txtNomCta.Text))
            {
                Interaction.MsgBox("Debe dar un nombre a la cuenta", MsgBoxStyle.Critical, Nombre);
                ValidarCtaRet = false;
            }

            var serv = new ClassDoc.Servicios();
            if (!(Chkcompras.CheckState != 0 | chkfacturacion.CheckState != 0 | chkegresobanco.CheckState != 0 | Chkingresobanco.CheckState != 0) & TeniaConcepto)
            {
                if (serv.ServUsado(CodigoCta) == true)
                {
                    Interaction.MsgBox("No se puede eliminar el Concepto creado por la cuenta" + Constants.vbCr + "Existen documentos que utilizan este concepto", MsgBoxStyle.Critical);
                    ValidarCtaRet = false;
                }
            }
            // If Nivel(CodigoCta) = Emp.CtaNumNiveles Then opCtaMov = True
            serv = null;
            return ValidarCtaRet;
        }


        // Private Function GetCta(cta As String)
        // Dim I As Integer
        // Dim Temp As Integer
        // Temp = Len(cta)
        // For I = 1 To Temp
        // If  Mid$(cta, I, 1) = " " Then
        // cta = Mid$(cta, 1, I - 1)
        // I = Temp
        // End If
        // Next
        // GetCta = cta
        // End Function

        private string CodCta()
        {
            string CodCtaRet = default;
            string Temp = "";
            short I;
            var loopTo = (short)emp.CtaNumNiveles;
            for (I = 1; I <= loopTo; I++)
                Temp = Temp + txtCodCta[I].Text;
            CodCtaRet = Temp;
            return CodCtaRet;
        }

        public void limpiar()
        {
            short I;
            var loopTo = (short)emp.CtaNumNiveles;
            for (I = 1; I <= loopTo; I++)
                txtCodCta[I].Text = "";
            txtNomCta.Text = "";
            // txtCla = ""
            txtC1.Text = "";
            txtC2.Text = "";
            txtC3.Text = "";
            txtC4.Text = "";
            TeniaConcepto = false;
            chkegresobanco.CheckState = CheckState.Unchecked;
            Chkcompras.CheckState = CheckState.Unchecked;
            chkfacturacion.CheckState = CheckState.Unchecked;
            Chkingresobanco.CheckState = CheckState.Unchecked;
            chiva.CheckState = CheckState.Checked;
            Option1.Checked = true;
            opSinPre.Checked = true;
            DcModulo.Text = "";
            Formatodetalle.Text = "";
        }

        public bool Agrupa()
        {
            return default;
            // If opCtaAgr = True Then
            // Agrupa = True
            // Else
            // Agrupa = False
            // End If
        }

        public void Agrupa2(ref bool op)
        {
            if (op == true)
            {
            }
            // Me.opCtaAgr = True
            else
            {
                // opCtaMov = True
            }
        }

        public string TipoPre()
        {
            string TipoPreRet = default;
            if (opSinPre.Checked == true)
            {
                TipoPreRet = "1";
            }
            else if (opMenVar.Checked == true)
            {
                TipoPreRet = "2";
            }
            else
            {
                TipoPreRet = "3";
            }

            return TipoPreRet;
        }

        public void TipoPre2(ref string op)
        {
            if (op == "1")
            {
                opSinPre.Checked = true;
            }
            else if (op == "2")
            {
                opMenVar.Checked = true;
            }
            else
            {
                opMenFij.Checked = true;
            }
        }

        private short Nivel(ref string cta)
        {
            short NivelRet = default;
            short I;
            string NumNiv;
            NumNiv = emp.CtaNumDigNivel.ToString();
            short[] OrgNiv;
            OrgNiv = new short[emp.CtaNumNiveles + 1];
            var loopTo = (short)emp.CtaNumNiveles;
            for (I = 1; I <= loopTo; I++)
                OrgNiv[I] = Conversions.ToShort(Strings.Mid(emp.CtaNumDigNivel.ToString(), I, 1));
            if (emp.CtaNumNiveles > 1)
                OrgNiv[2] = (short)(OrgNiv[1] + OrgNiv[2]);
            if (emp.CtaNumNiveles > 2)
                OrgNiv[3] = (short)(OrgNiv[2] + OrgNiv[3]);
            if (emp.CtaNumNiveles > 3)
                OrgNiv[4] = (short)(OrgNiv[3] + OrgNiv[4]);
            if (emp.CtaNumNiveles > 4)
                OrgNiv[5] = (short)(OrgNiv[4] + OrgNiv[5]);
            if (emp.CtaNumNiveles > 5)
                OrgNiv[6] = (short)(OrgNiv[5] + OrgNiv[6]);
            var loopTo1 = (short)emp.CtaNumNiveles;
            for (I = 1; I <= loopTo1; I++)
            {
                if (Strings.Len(cta) == OrgNiv[I])
                {
                    NivelRet = I;
                    I = (short)emp.CtaNumNiveles;
                }
            }

            return NivelRet;
        }

        private bool LeerCuenta(ref string QueCuenta)
        {
            bool LeerCuentaRet = default;
            var RsCta = SqlDatos.leerBase("SELECT cta_codigo FROM AdcCta WHERE Cta_Codigo='" + QueCuenta + "'", datosEmpresa.strConxAdcom);
            LeerCuentaRet = RsCta.Read();
            RsCta.Close();
            RsCta = null;
            return LeerCuentaRet;
        }

        private void CTBP01_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConxAdcom.Close();
            ConxAdcom.Dispose();
        }

        private void CTBP01_1_Load(object eventSender, EventArgs eventArgs)
        {
            // Dim cca As New ClasificadorCtb()
            var colClasificadores = new ClasificadoresCtb();

            // Dim Clasif As New ClasificadorCtb
            short I;
            // Dim libb As New DaxLib.DaxLibMalla
            // Dim libsql As New DaxLib.DaxLibBases
            // libsql.TipoBase = "10"
            // ConxAdcom.ConnectionString = libsql.StrAdcom
            // ConxAdcom.Open()
            // actualizarBase()

            for (I = 1; I <= 8; I++)
            {
                txtCodCta[I] = new TextBox();
                Controls.Add(txtCodCta[I]);
                txtCodCta[I].Height = 27;
                txtCodCta[I].Width = 25;
                txtCodCta[I].Left = 30 * I + 54; // + TextCodCta.Left
                txtCodCta[I].Top = 55;
                txtCodCta[I].Visible = false;
            }
            // cca.Cargar("")
            Clasificadores.Items.Clear();
            foreach (var Clasif in colClasificadores.ColClasificadoresCtb)
                Clasificadores.Items.Add(Clasif.Nombre);
            var BCTB = new Cuenta();
            string[] Aux;
            Aux = Strings.Split(BCTB.ModulosAuxiliares(), ";");
            {
                var withBlock = DcModulo;
                withBlock.Items.Clear();
                var loopTo = (short)Information.UBound(Aux);
                for (I = 0; I <= loopTo; I++)
                    withBlock.Items.Add(Aux[I]);
            }

            colClasificadores = null;
            // cca = Nothing
            OrganizarNiveles();
        }

        private void Toolbar1_ButtonClick(object eventSender, EventArgs eventArgs)
        {
            ToolStripItem Button = (ToolStripItem)eventSender;
            switch (Button.Name ?? "")
            {
                case "guardar":
                    {
                        btnGuardar_Click();
                        break;
                    }

                case "salir":
                    {
                        Close();
                        break;
                    }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtCodCta_KeyDown();
        }

        private void txtCodCta_KeyDown() // ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtCodCta.KeyDown
        {
            short Index; // = txtCodCta.GetIndex(eventSender)
            System.Data.SqlClient.SqlDataReader rs;
            short L;
            string sSql;
            Index = (short)Math.Round(Conversion.Val(Button1.Text));
            L = (short)Strings.Len(CtaPadre);
            if (L < 1)
                L = 1;
            sSql = "SELECT MAX(Cta_codigo) AS CtaM From dbo.AdcCta " + "WHERE Cta_Nivel = " + NivelIni + " AND (SUBSTRING(Cta_codigo, 1," + L + ") = '" + CtaPadre + "')";
            var linkdat = new System.Data.SqlClient.SqlCommand(sSql, ConxAdcom);
            rs = linkdat.ExecuteReader();
            if (rs.Read())
            {
                try
                {
                    if (!Information.IsDBNull(rs["ctam"]))
                    {
                        txtCodCta[Index].Text = (Conversion.Val(Strings.Mid(Conversions.ToString(rs["ctam"]), L + 1)) + 1d).ToString();
                        txtCodCta[Index].Text = Strings.Right("00000000" + txtCodCta[Index].Text, txtCodCta[Index].MaxLength);
                    }
                    else
                    {
                        txtCodCta[Index].Text = "0";
                    }
                }
                catch
                {
                }
            }
            else
            {
                txtCodCta[Index].Text = "1";
            }

            rs.Close();
            rs = null;
            linkdat = null;
        }

        private void actualizarBase()
        {
            string sSQL = "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name = 'adccta' and col.name='tipoCosto')";
            sSQL += " BEGIN ALTER TABLE AdcCta Add [tipoCosto] [varchar](3) null End";
            var linkdat = new System.Data.SqlClient.SqlCommand(sSQL, ConxAdcom);
            linkdat.ExecuteNonQuery();
        }

        private void chkDeAgrupacion_CheckedChanged(object sender, EventArgs e)
        {
            // //If (chkDeAgrupacion.Checked) Th
        }
    }
}