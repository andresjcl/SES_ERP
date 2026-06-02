using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SysEmpDatt;

namespace MantCtb
{
    internal partial class CTBP01 : Form
    {
        private int NivAct, GrupAct;
        private string CtaAct;

        private void Command2_Click()
        {
            var prog = new CTBP21();
            prog.ShowDialog();
            prog.Close();
            prog.Dispose();
        }

        private void CuentaNueva_Click()
        {
            var prog = new CTBP01_1();
            short argNivelCta = (short)NivAct;
            short argGrupo = (short)GrupAct;
            string argAccion = "N";
            var argArbol = trArbol;
            prog.CrearCuenta(ref CtaAct, ref argNivelCta, ref argGrupo, ref argAccion, ref argArbol);
            trArbol = argArbol;
            prog.Dispose();
        }

        private void CTBP01_Resize(object eventSender, EventArgs eventArgs)
        {
            short Separacion;
            Separacion = (short)100;
            {
                var withBlock = this;
                // Frame1.Left = Me.Width - Frame1.Width - Separacion * 2
                trArbol.Left = Separacion;
                trArbol.Width = withBlock.Width - Separacion * 4;
                trArbol.Height = withBlock.Height - Toolbar1.Height - Separacion * 8;
            }
        }

        private void InsertarCuenta_Click()
        {
            var prog = new CTBP01_1();
            short argNivelCta = (short)NivAct;
            short argGrupo = (short)GrupAct;
            string argAccion = "I";
            var argArbol = trArbol;
            prog.CrearCuenta(ref CtaAct, ref argNivelCta, ref argGrupo, ref argAccion, ref argArbol);
            trArbol = argArbol;
            prog = null;
            trArbol.Refresh();
        }

        private void ModificarCuenta_Click()
        {
            var prog = new CTBP01_1();
            short argNivelCta = (short)NivAct;
            short argGrupo = (short)GrupAct;
            string argAccion = "M";
            var argArbol = trArbol;
            prog.CrearCuenta(ref CtaAct, ref argNivelCta, ref argGrupo, ref argAccion, ref argArbol);
            trArbol = argArbol;
            prog = null;
            PonerDatosRapidos();
            trArbol.Refresh();
        }

        private void EliminarCuenta_Click()
        {
            var Ctaaux = new Cuenta();
            CtaAct = trArbol.SelectedNode.Name.Substring( 2);
            if (Ctaaux.Eliminar(ref CtaAct) == true)
            {
                trArbol.Nodes.Remove(trArbol.SelectedNode);
            }

            Ctaaux = null;
        }

        private void CTBP01_Load(object eventSender, EventArgs eventArgs)
        {
            CargaCtas();
            EstaEnDefinicion();
        }

        private void CargaTipoCta()
        {
            trArbol.ShowRootLines = true;
            {
                var withBlock = trArbol.Nodes;
                withBlock.Clear();
                withBlock.Add("M1", "Ctas. de Activo", 1);
                withBlock.Add("M2", "Ctas. de Pasivo", 1);
                withBlock.Add("M3", "Ctas. de Patrimonio", 1);
                withBlock.Add("M4", "Ctas. de Resultados", 1);
                withBlock.Add("M5", "Ctas. de Orden", 1);
            }
        }

        private void CargaCtas()
        {
            SqlDataReader RsCta;
            string Aux;
            short Indice;
            var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom);
            trArbol.Nodes.Clear();
            CargaTipoCta();
            Indice = 0;
            Aux = "select * from adccta order by cta_codigo";
            RsCta = SqlDatos.leerBase(Aux, datosEmpresa.strConxAdcom);
            Indice = 0;
            int CtaNivel = 1;
            string ctaCodigo;
            {
                while (RsCta.Read() != false)
                {
                    Indice = (short)(Indice + 1);
                    if (!(RsCta["Cta_Nivel"] == null ))
                        CtaNivel = Convert.ToInt32(RsCta["Cta_Nivel"]);
                    if (CtaNivel == 0)
                        CtaNivel = 1;
                    ctaCodigo = RsCta["CTA_CODIGO"].ToString();
                    short argCtaNivel = (short)CtaNivel;
                    Aux = OperacionesBuscaCta.QuePadreDeCta(ref ctaCodigo, ref argCtaNivel);
                    if (string.IsNullOrEmpty(Aux))
                    {
                        trArbol.Nodes.Find("M" + RsCta["cta_grupo"].ToString().Trim(), true)[0].Nodes.Add("C" + ctaCodigo.Trim(), ctaCodigo + "  " + RsCta["CTA_NOMBRE"], 2, 3);
                    }
                    else if (Convert.ToBoolean( RsCta["cta_agrupacion"]))
                    {
                        trArbol.Nodes.Find("C" + Aux, true)[0].Nodes.Add("C" + ctaCodigo.Trim(), ctaCodigo + "  " + RsCta["CTA_NOMBRE"].ToString(), 2, 3);
                    }
                    else
                    {
                        trArbol.Nodes.Find("C" + Aux, true)[0].Nodes.Add("C" + ctaCodigo.Trim(), ctaCodigo + "  " + RsCta["CTA_NOMBRE"].ToString(), 4, 5);
                    }
                }

            Final:
                ;
                RsCta.Close();
            }

            RsCta = null;
            return;
        CTAMALA:
            trArbol.Nodes.Add("B" + RsCta["CTA_CODIGO"].ToString().Trim(), RsCta["CTA_CODIGO"].ToString()+ "  " + RsCta["CTA_NOMBRE"].ToString(), 4);
        }

        private void Toolbar1_ButtonClick(object eventSender, EventArgs eventArgs)
        {
            ToolStripItem Button = (ToolStripItem)eventSender;
            switch (Button.Name ?? "")
            {
                case "nueva":
                    {
                        CuentaNueva_Click();
                        break;
                    }

                case "insertar":
                    {
                        InsertarCuenta_Click();
                        break;
                    }

                case "modificar":
                    {
                        ModificarCuenta_Click();
                        break;
                    }

                case "eliminar":
                    {
                        EliminarCuenta_Click();
                        break;
                    }

                case "listado":
                    {
                        Command2_Click();
                        break;
                    }

                case "salir":
                    {
                        Close();
                        break;
                    }
            }
        }

        private void Salida()
        {
            SqlDatos.ejecutarComando("Adc_CtaForma " + datosEmpresa.Emp_codigo, datosEmpresa.strConxAdcom);
        }

        private void PonerDatosRapidos()
        {
            string Qcodigo;
            var Ctaaux = new Cuenta();
            Qcodigo = trArbol.SelectedNode.Name.Substring(2);
            Ctaaux.Cargar(ref Qcodigo);
            if (string.IsNullOrEmpty(Ctaaux.codigo))
                return;
            {
                NivAct = Ctaaux.Nivel;
                CtaAct = Ctaaux.codigo;
                GrupAct = Convert.ToInt16(Ctaaux.Grupo);
                Toolbar1.Items["insertar"].Enabled = Ctaaux.Agrupacion;
                Toolbar1.Items["nueva"].Enabled = true;
                Toolbar1.Items["modificar"].Enabled = true;
                Toolbar1.Items["eliminar"].Enabled = true;
            }

            Ctaaux = null;
        }

        private void EstaEnDefinicion()
        {
            string Qcodigo;
            if (trArbol.SelectedNode is null)
            {
                Qcodigo = "1";
            }
            else
            {
                Qcodigo = trArbol.SelectedNode.Name.Substring( 2);
            }

            if (string.IsNullOrEmpty(Qcodigo))
                Qcodigo = "1";
            Toolbar1.Items["insertar"].Enabled = true;
            Toolbar1.Items["nueva"].Enabled = false;
            Toolbar1.Items["modificar"].Enabled = false;
            Toolbar1.Items["eliminar"].Enabled = false;
            NivAct = 0;
            CtaAct = "";
            GrupAct = Convert.ToInt16(Qcodigo);
        }

        private string PuntosCta(ref string Cuenta, ref short Nivel)
        {
            string PuntosCtaRet = default;
            short i, Lim = default;
            string Aux;
            Aux = Cuenta.Substring( 0, Convert.ToInt32 (emp.CtaNumDigNivel.Substring(1, 1)));
            var loopTo = (short)(Nivel - 1);
            for (i = 0; i < Nivel ; i++)
            {
                if (i > 1)
                    Aux = Aux + ".";
                Lim = (short)Math.Round(Lim + Conversion.Val(Strings.Mid(emp.CtaNumDigNivel, i, 1)));
                Aux = Aux + Strings.Mid(Cuenta, Lim + 1, (int)Math.Round(Conversion.Val(Strings.Mid(emp.CtaNumDigNivel.ToString(), i + 1, 1))));
            }

            PuntosCtaRet = Aux;
            return PuntosCtaRet;
        }

        private bool SiElimina(ref string Cuenta)
        {
            bool SiEliminaRet = default;
            if (trArbol.Nodes[trArbol.SelectedNode.Name].GetNodeCount(false) > 0)
            {
                SiEliminaRet = false;
                MessageBox.Show ("No se puede eliminar cuenta con auxiliares", "eliminar cuenta contable " + Cuenta);
                return SiEliminaRet;
            }

            SiEliminaRet = CtaUsada(ref Cuenta);
            return SiEliminaRet;
        }

        private bool CtaUsada(ref string cta)
        {
            bool CtaUsadaRet = default;
            SqlDataReader rstemp;
            string cod;
            cod = " select top 1 cta_codigo from AdcDia WHERE Cta_Codigo = '" + cta + "'";
            rstemp = SqlDatos.leerBase(cod, datosEmpresa.strConxAdcom);
            if (rstemp.Read())
            {
                MessageBox.Show("Imposible borrar esta Cuenta, esta registrada en otros documentos", "Eliminar cuenta contable " + cta);
                CtaUsadaRet = false;
            }
            else
            {
                CtaUsadaRet = true;
            }

            rstemp.Close();
            rstemp = null;
            return CtaUsadaRet;
        }

        private void trArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var Node = e.Node;
            switch (Strings.Mid(trArbol.SelectedNode.Name, 1, 1) ?? "")
            {
                case "C":
                case "B":
                    {
                        PonerDatosRapidos();
                        break;
                    }

                case "M":
                    {
                        EstaEnDefinicion();
                        break;
                    }
            }
        }

        private void Validar_Click(object sender, EventArgs e)
        {
            var prog = new CtbValida();
            string Sstr;
            Sstr = "";
            Sstr = Sstr + " select cta1.Cta_codigo,'ERROR: La cuenta de Mayor no existe' as mensaje from adccta cta1";
            Sstr = Sstr + " left join adccta cta2";
            Sstr = Sstr + " on substring(cta1.cta_codigo,1,len(cta2.cta_codigo)) = cta2 .cta_codigo";
            Sstr = Sstr + " and cta1.Cta_Nivel = cta2.cta_nivel +1";
            Sstr = Sstr + " Where cta1.Cta_Nivel > 1 And IsNull(cta2.Cta_Nivel, 9) = 9";
            Sstr = Sstr + " union All";
            Sstr = Sstr + " select cta1.Cta_codigo,'ERROR: La cuenta de Agrupación ' + cta2.cta_codigo + ' - ' + cta2.Cta_nombre  + ' está definida como de movimiento'  as mensaje from adccta cta1";
            Sstr = Sstr + " left join adccta cta2";
            Sstr = Sstr + " on substring(cta1.cta_codigo,1,len(cta2.cta_codigo)) = cta2 .cta_codigo";
            Sstr = Sstr + " and cta1.Cta_Nivel = cta2.cta_nivel +1";
            Sstr = Sstr + " where cta1.Cta_Nivel > 1 and isnull(cta2.cta_agrupacion,0)=0 and isnull(cta2.Cta_codigo,'') > ''";
            var con = new SqlConnection();
            var datS = new DataTable();
            var datA = new SqlDataAdapter(Sstr, con);
            datA.Fill(datS);
            prog.Malla.DataSource = datS;
            con.Close();
            prog.ShowDialog();
            prog.Dispose();
        }

        private void CTBP01_FormClosing(object sender, FormClosingEventArgs e)
        {
            Salida();
        }
    }
}