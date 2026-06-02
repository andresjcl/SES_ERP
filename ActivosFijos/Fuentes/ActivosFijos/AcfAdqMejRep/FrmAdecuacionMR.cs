//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Security;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AcfAdqMejRep
{
    public partial class FrmAdecuacionMR : Form
    {
        // VARIABLES PARA LA CONEXION CON LA BASE DE DATOS
        private SqlConnection conectarBDD = new SqlConnection();

        // VARIABLES DE ACTIVOS FIJOS
        private string actprincod, actprin;
        private int cambios;
        private string op, existeCod;
        private Int16 actualizar = 0;
        public string act;
        private int verif;
        private string opcion, ssql, acc, aseguradora; // , moneda As String
        private bool modCosto = false;
        private string StrConxadcom = "";
        private AdcAcf dataAcf = new AdcAcf();
        private string txtImagen = "";
        private string codigoExterno;
        private string accionExterna;
        private Int16 proceso = 0; // 1 nuevo   2 consultando  0 ninguna
        public FrmAdecuacionMR()
        {
            InitializeComponent();
        }
        private void MantAF_Load(System.Object sender, System.EventArgs e)
        {
            DaxLib.DaxLibBases conector = new DaxLib.DaxLibBases();
            TabControl.TabPages(2).Dispose();
            dataAcf = new AdcAcf(varbleComun.VarCom.strConxAdcom);
            conector.TipoBase = "10";
            StrConxadcom = conector.StrAdcom;
            conectarBDD.ConnectionString = StrConxadcom;
            llenarComboCat(1); // Categori
            llenarMoneda();
            if (codigoExterno > "")
                AbrirActivo(codigoExterno);
        }

        private void btnGuardar_Click(System.Object sender, System.EventArgs e)
        {

        }
        private bool ConsultaDep(string codAcf)
        {
            bool bandera = false;
            string ssql = "Select codigo from adcacfdep where codigo='" + codAcf + "'";
            SqlCommand cmd = new SqlCommand(ssql, conectarBDD);
            if (conectarBDD.State == ConnectionState.Open)
                conectarBDD.Close();
            conectarBDD.Open();
            SqlDataReader dat = cmd.ExecuteReader();
            if (dat.Read())
            {
                if (dat[0] != null )
                    bandera = true;
            }
            conectarBDD.Close();
            return bandera;
        }
        private void EliminarDep(string codAcf)
        {
            string ssql = "delete from adcacfdep where codigo='" + codAcf + "'";
            SqlCommand cmd = new SqlCommand(ssql, conectarBDD);
            if (conectarBDD.State == ConnectionState.Open)
                conectarBDD.Close();
            conectarBDD.Open();
            cmd.ExecuteNonQuery();
            conectarBDD.Close();
        }
        private void MoverValoresAClaseData()
        {
            dataAcf.Codigo = txtCodigo.Text;
            dataAcf.Nombre = txtDescrip.Text;
            dataAcf.TipoActivo = cboTipoActivos.Text;
            dataAcf.Categoria = cboCategoria.SelectedValue.ToString();
            dataAcf.Clase = cboClase.SelectedValue.ToString();
            dataAcf.Grupo = cboGrupo.SelectedValue.ToString();
            dataAcf.Marca = txtMarca.Text;
            dataAcf.Serie = txtSerie.Text;
            dataAcf.NroLote = TxtLote.Text;
            dataAcf.CentroCosto = txtCCostoCod.Text;
            dataAcf.CodActivoPrincipal = txtActPrinCod.Text;
            dataAcf.EsComponente = chkComponente.Checked;
            dataAcf.Descripcion = txtActPrin.Text;
            dataAcf.Responsable = txtRespCod.Text;
            dataAcf.Estado = txtEstado.Text;

            if (IsDate(txtFechaIng.Value))
                dataAcf.FecIngreso = (DateTime)txtFechaIng.Value;
            else
                dataAcf.FecIngreso = txtfechaSal.Text;
            dataAcf.CostoIngreso = Val(txtCostoIng.Text);
            dataAcf.DocTipIngreso = txtDocIng.Text;
            if (txtNDocIng.Text != "")
                dataAcf.DocNumIngreso = txtNDocIng.Text;
            else
                dataAcf.DocNumIngreso = 0;
            // If txtfechaSal.Text = "  /  /" Then dataAcf.FecSalida = "1900/01/01" Else 
            dataAcf.FecSalida = Txtfechasal.Value;
            dataAcf.DocTipSalida = txtDocSal.Text;
            dataAcf.DocNumSalida = 0;
            if (txtNDocSal.Text != "")
                dataAcf.DocNumSalida = txtNDocSal.Text;
            dataAcf.CtaContable1 = txtIdentifCodigo1.Text;
            dataAcf.CtaContable2 = txtIdentifCodigo2.Text;
            dataAcf.CtaContable3 = txtIdentifCodigo3.Text;
            dataAcf.CtaContable4 = txtIdentifCodigo4.Text;
            dataAcf.ValorResidual = Val(txtValRes.Text);
            dataAcf.TipoDepreciacionCont = cboDepFin.SelectedIndex;
            dataAcf.TipoDepreciacionTributa = cboDepTribut.SelectedIndex;
            dataAcf.VidaUtilCont = Val(txtVidaUtConta.Text);
            dataAcf.VidaUtilTributa = Val(txtVidaUtTribut.Text);

            dataAcf.UnidacesProduccionCont = Val(txtUndProdConta.Text);
            dataAcf.UnidadesProduccionTribut = 0;
            dataAcf.TasaDepCont = 0;
            dataAcf.TasaDepTribut = Val(txtTDep.Text);
            dataAcf.ValorActualCont = 0;
            dataAcf.ValorActualTribut = 0;
            dataAcf.UltimoAñoCalc = 0;
            dataAcf.UltimoMesCalc = 0;
            dataAcf.UsuarioCrea = "";
            dataAcf.UsuarioModifica = varbleComun.VarCom.usr;
            dataAcf.FechaModifica = Strings.LSet(DateTime.Now, 10);
            dataAcf.Imagen = txtImagen;
            dataAcf.Cantidad = System.Convert.ToInt64("0" + txtCantidad.Text);
            dataAcf.Aseguradora = txtAsegCod.Text;
            dataAcf.NContrato = Convert.ToDecimal("0" + txtContrato.Text);
            if (IsDate(txtFechaInicioS.Text))
                dataAcf.FechaIngSeguro = (DateTime)txtFechaInicioS.Text;
            else
                dataAcf.FechaIngSeguro = "1900/01/01";
            if (IsDate(txtFechaFinS.Text))
                dataAcf.FechaSalSeguro = (DateTime)txtFechaFinS.Text;
            else
                dataAcf.FechaSalSeguro = "1900/01/01";
            dataAcf.MontoAsegurado = Val(txtMonto.Text);
            dataAcf.Deducible = Val(txtDeducible.Text);
            dataAcf.PagoMensual = Val(txtPagoM.Text);
            if (cboMoneda.Text == "")
                dataAcf.Moneda = "";
            else
                dataAcf.Moneda = cboMoneda.SelectedValue.ToString();
            if (txtParidad.Text == "")
                dataAcf.Paridad = 0;
            else if (txtParidad.Text == "" & cboMoneda.Text == "Dólares")
                dataAcf.Paridad = 1;
            else
                dataAcf.Paridad = txtParidad.Text;
        }

        public void consultarExt(string accion, string codigo)
        {
            codigoExterno = codigo;
            accionExterna = accion;
            this.ShowDialog();
        }
        private void AbrirActivo(string codigo)
        {
            RetNombre.AdcNomb retNom = new RetNombre.AdcNomb();

            dataAcf = new AdcAcf(varbleComun.VarCom.strConxAdcom);
            dataAcf = AdcAcf.Buscar(" codigo = '" + codigo + "'");

            if (IsDBNull(dataAcf) | dataAcf.Nombre == "")
            {
                MessageBox.Show("No existe el áctivo fijo "); return;
            }

            txtCodigo.Text = dataAcf.Codigo;
            txtDescrip.Text = dataAcf.Nombre;
            cboTipoActivos.Text = dataAcf.TipoActivo;
            cboCategoria.SelectedValue = dataAcf.Categoria;
            cboClase.SelectedValue = dataAcf.Clase;
            cboGrupo.SelectedValue = dataAcf.Grupo;
            cboSubg.SelectedValue = dataAcf.Subgrupo;
            txtMarca.Text = dataAcf.Marca;
            txtSerie.Text = dataAcf.Serie;
            TxtLote.Text = dataAcf.NroLote;

            txtActPrinCod.Text = dataAcf.CodActivoPrincipal;

            chkComponente.Checked = dataAcf.EsComponente;

            txtSucursal.Text = retNom.RetornaNombreSucursal(varbleComun.VarCom.codEmpresa, dataAcf.UbicaSucursal, varbleComun.VarCom.strConxSyscod);
            txtDep.Text = retNom.RetornaNombreSyscod("Departamento", dataAcf.UbicaDepartamento, varbleComun.VarCom.strConxSyscod);
            txtSeccion.Text = retNom.RetornaNombreSyscod("Sección", dataAcf.UbicaSeccion, varbleComun.VarCom.strConxSyscod);
            txtCCostoCod.Text = dataAcf.CentroCosto; txtCCosto.Text = retNom.RetornaNombreSyscod("Centro Costo", dataAcf.CentroCosto, varbleComun.VarCom.strConxAdcom);

            txtRespCod.Text = dataAcf.Responsable; txtResp.Text = retNom.RetornaNombreDirectorio(dataAcf.Responsable, varbleComun.VarCom.strConxAdcom);
            txtEstado.Text = dataAcf.Estado;
            txtFechaIng.Text = dataAcf.FecIngreso;
            txtCostoIng.Text = dataAcf.CostoIngreso;
            txtDocIng.Text = dataAcf.DocTipIngreso;
            txtNDocIng.Text = dataAcf.DocNumIngreso;
            txtDocSal.Text = dataAcf.DocTipSalida;
            txtNDocSal.Text = dataAcf.DocNumSalida;
            txtIdentifCodigo1.Text = dataAcf.CtaContable1;
            txtIdentifCodigo2.Text = dataAcf.CtaContable2;
            txtIdentifCodigo3.Text = dataAcf.CtaContable3;
            txtIdentifCodigo4.Text = dataAcf.CtaContable4;
            txtValRes.Text = dataAcf.ValorResidual;
            cboDepFin.SelectedIndex = dataAcf.TipoDepreciacionCont;
            cboDepFin.Text = "";
            cboDepFin.Text = cboDepFin.SelectedItem.ToString;
            cboDepTribut.SelectedIndex = dataAcf.TipoDepreciacionTributa;
            cboDepTribut.Text = "";
            cboDepTribut.Text = cboDepTribut.SelectedItem.ToString;
            txtVidaUtConta.Text = dataAcf.VidaUtilCont;
            txtVidaUtTribut.Text = dataAcf.VidaUtilTributa;
            txtUndProdConta.Text = dataAcf.UnidacesProduccionCont;
            txtTDep.Text = dataAcf.TasaDepTribut;

            txtImagen = dataAcf.Imagen; if ((dataAcf.Imagen.Length > 0))
                imgImagen.Image = Image.FromFile(dataAcf.Imagen);
            txtCantidad.Text = dataAcf.Cantidad;
            txtAsegCod.Text = dataAcf.Aseguradora;
            txtContrato.Text = dataAcf.NContrato;
            txtFechaInicioS.Text = dataAcf.FechaIngSeguro;
            txtFechaFinS.Text = dataAcf.FechaSalSeguro;
            txtMonto.Text = dataAcf.MontoAsegurado;
            txtDeducible.Text = dataAcf.Deducible;
            txtPagoM.Text = dataAcf.PagoMensual;
            cboMoneda.SelectedValue = dataAcf.Moneda;
            txtParidad.Text = dataAcf.Paridad;
            Txtfechasal.Text = dataAcf.FecSalida;

            ConsultCta(txtIdentifCodigo1.Text, 1);
            ConsultCta(txtIdentifCodigo2.Text, 2);
            ConsultCta(txtIdentifCodigo3.Text, 3);
            ConsultCta(txtIdentifCodigo4.Text, 4);
            consResp(txtRespCod.Text, "RESP");
            consResp(txtAsegCod.Text, "ASEG");
            ActivoPrincipal(txtActPrinCod.Text);
            proceso = 2;
            ControlarBotones();
        }
        public void consCCosto(string cod)
        {
            ssql = "Select CCO_Nombre from AdcCcosto where CCO_id='" + cod + "'";
            SqlCommand consulta = new SqlCommand(ssql, conectarBDD);
            SqlDataReader data;
            conectarBDD.Open();
            data = consulta.ExecuteReader();
            if (data.Read)
                txtCCosto.Text = data(0);
            else
                txtCCosto.Text = "";
            conectarBDD.Close();
        }
        public void consResp(string cod, string op)
        {
            ssql = "Select NombreImpresion as Nombre from Identificacion where Codigo='" + cod + "'";
            conectarBDD.Open(); 
            SqlCommand com = new SqlCommand(ssql, conectarBDD);
            SqlDataReader dat = com.ExecuteReader();
            if (dat.Read())
            {
                if (op == "RESP")
                    txtResp.Text = dat[0].ToString();
                else if (op == "ASEG")
                    txtAseguradora.Text = dat[0].ToString();
            }
            else if (op == "RESP")
                txtResp.Text = "";
            else if (op == "ASEG")
                txtAseguradora.Text = "";
            conectarBDD.Close();
            com.Dispose();
        }
        private void consDep(string cod, string @ref)
        {
            string cSql = "";
            SqlConnection conect = new SqlConnection();
            DaxLib.DaxLibBases conector = new DaxLib.DaxLibBases();
            conector.TipoBase = "10";
            conect.ConnectionString = conector.StrDaxsys();
            cSql = "Select Descripcion from Syscod where TipoReferencia='" + @ref + "' and Abreviación='" + cod + "'";
            SqlCommand com = new SqlCommand(cSql, conect);
            conect.Open();
            SqlDataReader dat;
            dat = com.ExecuteReader();
            if (dat.Read())
            {
                if (@ref == "Departamento")
                    txtDep.Text = dat(0);
                else
                    txtSeccion.Text = dat(0);
            }
            else if (@ref == "Departamento")
                txtDep.Text = "";
            else
                txtSeccion.Text = "";
            conect.Close();
        }


        private void BtnEliminar_Click(System.Object sender, System.EventArgs e)
        {

        }
        private void Clear()
        {
            txtCodigo.Text = "";
            txtDescrip.Text = "";
            cboTipoActivos.Text = "";
            txtMarca.Text = "";
            txtSerie.Text = "";
            TxtLote.Text = "";
            txtCCosto.Text = "";
            txtActPrinCod.Text = "";
            chkComponente.Checked = false;
            txtActPrin.Text = "";
            txtSucursal.Text = "";
            txtDep.Text = "";
            txtSeccion.Text = "";
            txtRespCod.Text = "";
            txtResp.Text = "";
            txtEstado.Text = "";
            txtTDep.Text = "";
            txtDep.Text = "";
            cboDepFin.Text = "";
            cboDepTribut.Text = "";
            txtUndProdConta.Text = "";
            txtFechaIng.Text = "";
            txtCostoIng.Text = "";
            txtDocIng.Text = "";
            txtNDocIng.Text = "";
            txtDocSal.Text = "";
            txtNDocSal.Text = "";
            txtIdentifCodigo1.Text = "";
            txtIdentifNombre1.Text = "";
            txtIdentifCodigo2.Text = "";
            txtIdentifNombre2.Text = "";
            txtIdentifCodigo3.Text = "";
            txtIdentifNombre3.Text = "";
            txtIdentifCodigo4.Text = "";
            txtIdentifNombre4.Text = "";
            txtValRes.Text = "";
            txtImagen = "";
            txtCantidad.Text = "";
            cboDepFin.Text = "";
            cboDepTribut.Text = "";
            imgImagen.Image = null;
            txtAsegCod.Text = "";
            txtAseguradora.Text = "";
            txtContrato.Text = "";
            txtMonto.Text = "";
            txtDeducible.Text = "";
            txtPagoM.Text = "";
            cboMoneda.Text = "";
            txtParidad.Text = "";
            dataAcf = new AdcAcf(varbleComun.VarCom.strConxAdcom);
            proceso = 0;
            modCosto = false;
            cambios = 0;
            ControlarBotones();
        }

        private void BtnNuevo_Click(System.Object sender, System.EventArgs e)
        {
            Nuevo();
        }

        private void btnAbrir_Click(System.Object sender, System.EventArgs e)
        {

        }
        private void btnCancelar_Click(System.Object sender, System.EventArgs e)
        {

        }
        private void actualizarRegistro()
        {
            dataAcf.Actualizar("Select * from adcacf where codigo = '" + txtCodigo.Text + "'");
        }

        private void BtnSalir_Click(System.Object sender, System.EventArgs e)
        {
            this.Dispose();
        }
        private bool verificarInformacion()
        {
            verificarInformacion = true;
            if (txtCodigo.Text == "")
            {
                Interaction.MsgBox("Es Necesario Ingresar el Código del Activo", MsgBoxStyle.Information);
                TabControl.SelectTab(0);
                txtCodigo.Focus();
            }
            else if (txtDescrip.Text == "")
            {
                Interaction.MsgBox("El Nombre es Requerido para ingresar El Activo", MsgBoxStyle.Information);
                TabControl.SelectTab(0);
                txtDescrip.Focus();
            }
            else if (cboTipoActivos.Text == "")
            {
                Interaction.MsgBox("Es Necesario Ingresar el Tipo de Activo", MsgBoxStyle.Information);
                TabControl.SelectTab(0);
                cboTipoActivos.Focus();
            }
            else if (txtCantidad.Text == "")
            {
                Interaction.MsgBox("La Cantidad No Puede se Nula", MsgBoxStyle.Information);
                txtCantidad.Focus();
            }
            else if (chkComponente.Checked == true & txtActPrinCod.Text == "")
            {
                Interaction.MsgBox("Debe registrar el Activo principal del componente", MsgBoxStyle.Information);
                txtActPrinCod.Focus();
            }
            else if (txtDocIng.Text == "")
            {
                Interaction.MsgBox("Es Necesario el Documento de Ingreso", MsgBoxStyle.Information);
                TabControl.SelectTab(1);
                txtDocIng.Focus();
            }
            else if (txtNDocIng.Text == "")
            {
                Interaction.MsgBox("Es Necesario Ingresar el Número de Documento", MsgBoxStyle.Information);
                TabControl.SelectTab(1);
                txtNDocIng.Focus();
            }
            else if (txtCostoIng.Text == "")
            {
                Interaction.MsgBox("Es Necesario Ingresar el Costo", MsgBoxStyle.Information);
                TabControl.SelectTab(1);
                txtCostoIng.Focus();
            }
            else if (txtValRes.Text == "")
            {
                Interaction.MsgBox("Es Necesario Ingresar el Valor Residual", MsgBoxStyle.Information);
                TabControl.SelectTab(1);
                txtValRes.Focus();
            }
            else if (cboDepFin.Text == "")
            {
                Interaction.MsgBox("Es Necesario el Tipo de Depreciación Financiera", MsgBoxStyle.Information);
                TabControl.SelectTab(1);
                cboDepFin.Focus();
            }
            else if (cboDepTribut.Text == "")
            {
                Interaction.MsgBox("Es Necesario el Tipo de Depreciación Tributaria", MsgBoxStyle.Information);
                TabControl.SelectTab(1);
                cboDepTribut.Focus();
            }
            else
                verificarInformacion = false;
        }

        // ESTE METODO COMPARA EL CODIGO INGRESADO EN PANTALLA CON LOS GUARDADOS EN LA BASE DE DATOS PARA QUE NO SE INGRESE
        // UN CODIGO QUE YA EXISTA
        private void ComprobarCodigo()
        {
            ssql = "Select Codigo from AdcAcf where Codigo ='" + txtCodigo.Text + "'";
            if (conectarBDD.State == ConnectionState.Open)
                conectarBDD.Close();
            SqlCommand com = new SqlCommand(ssql, conectarBDD);
            conectarBDD.Open();
            SqlDataReader datos;
            datos = com.ExecuteReader();
            if (datos.HasRows)
            {
                MsgBox("El codigo " + txtCodigo.Text + " ya existe", MsgBoxStyle.Exclamation);
                actualizar = 1;
                existeCod = 1;
            }
            conectarBDD.Close();
        }
        private void llenarMoneda()
        {
            SqlConnection conectar = new SqlConnection(); // "server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=DaxSys;pooling=false")
            DaxLib.DaxLibBases condax = new DaxLib.DaxLibBases();
            condax.TipoBase = "10";
            conectar.ConnectionString = condax.StrDaxsys;
            string ssql = "select Abreviación, Descripcion from Syscod where TipoReferencia='Monedas' and descripcion <> '' order by Descripcion";
            conectar.Open();
            BindingSource dat = new BindingSource();
            DataSet datS = new DataSet();
            SqlDataAdapter con = new SqlDataAdapter(ssql, conectar);
            con.Fill(datS, "Syscod");
            dat.DataSource = datS;
            dat.DataMember = "Syscod";
            cboMoneda.DataSource = dat;
            cboMoneda.DisplayMember = "Descripcion";
            cboMoneda.ValueMember = "Abreviación";
            conectar.Close();
        }
        // ESTE METODO LLENA LOS COMBOS DE CATEGORIA, CLASE, GRUPO Y SUBGRUPO
        private void llenarComboCat(string opcion)
        {
            DaxCbos.DaxCombobx cmb = new DaxCbos.DaxCombobx();

            cmb.DaxCombosCat("C", "A", StrConxadcom, cboCategoria);
            cmb.DaxCombosCat("CL", "A", StrConxadcom, cboClase);
            cmb.DaxCombosCat("G", "A", StrConxadcom, cboGrupo);
            cmb.DaxCombosCat("S", "A", StrConxadcom, cboGrupo);

            conectarBDD.Close();
        }
        // Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        // If e.KeyCode = 13 And txtCodigo.Text <> "" Then
        // ComprobarCodigo()
        // End If
        // End Sub
        // METODO PARA CONSULTAR LOS ACTIVOS PRINCIPALES 
        private void ActivoPrincipal(string cod)
        {
            string ssql;
            ssql = "Select * from AdcAcf where Codigo = '" + cod + "'";
            SqlCommand consulta = new SqlCommand(ssql, conectarBDD);
            consulta.CommandType = CommandType.Text;
            SqlDataReader datos;
            try
            {
                conectarBDD.Open();
                datos = consulta.ExecuteReader();
                if (datos.Read)
                {
                    txtActPrinCod.Text = datos(0);
                    txtActPrin.Text = datos(1);
                }
                conectarBDD.Close();
            }
            catch (Exception ex)
            {
                txtActPrin.Text = ex.Message.Substring(100);
            }
        }
        private void ConsultCta(string cta, int num)
        {
            ssql = "Select Cta_nombre from AdcCta where Cta_codigo= '" + cta + "'";
            if (conectarBDD.State == ConnectionState.Closed)
                conectarBDD.Open();
            SqlCommand com = new SqlCommand(ssql, conectarBDD);
            SqlDataReader dat = com.ExecuteReader();
            if (dat.Read)
            {
                if (num == 1)
                    txtIdentifNombre1.Text = dat.GetString(0);
                else if (num == 2)
                    txtIdentifNombre2.Text = dat.GetString(0);
                else if (num == 3)
                    txtIdentifNombre3.Text = dat.GetString(0);
                else
                    txtIdentifNombre4.Text = dat.GetString(0);
            }
            conectarBDD.Close();
        }
        private void Nuevo()
        {
            act = "Nuevo";
            txtCantidad.Text = "1";
            txtParidad.Text = "1";
            proceso = 1;
            ControlarBotones();
        }
        public void NuevoActivo()
        {
            Nuevo();
            this.ShowDialog();
        }

        private void btnActPrincipal_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void chkComponente_CheckedChanged(System.Object sender, System.EventArgs e)
        {

        }
        private void btnResponsable_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void btnIdentifCont1_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void btnIdentifCont2_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void btnIdentifCont3_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void btnIdentifCont4_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void btnDpto_Click_1(System.Object sender, System.EventArgs e)
        {

        }

        private void btnSeccion_Click_1(System.Object sender, System.EventArgs e)
        {

        }

        private void txtCantidad_GotFocus(object sender, System.EventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtNDocIng_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InStr(1, "0123456789.," + Strings.Chr(8), e.KeyChar) == 0)
                e.KeyChar = "";
        }

        private void txtNDocSal_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InStr(1, "0123456789.," + Strings.Chr(8), e.KeyChar) == 0)
                e.KeyChar = "";
        }

        private void txtCostoIng_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtValRes_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtVidaUtConta_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtUndProdConta_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtValActualConta_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InStr(1, "0123456789.," + Strings.Chr(8), e.KeyChar) == 0)
                e.KeyChar = "";
        }

        private void txtVidaUtTribut_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtUndProdTribut_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InStr(1, "0123456789.," + Strings.Chr(8), e.KeyChar) == 0)
                e.KeyChar = "";
        }

        private void txtTDep_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InStr(1, "0123456789.," + Strings.Chr(8), e.KeyChar) == 0)
                e.KeyChar = "";
        }

        private void txtValActualTribut_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (InStr(1, "0123456789.," + Strings.Chr(8), e.KeyChar) == 0)
                e.KeyChar = "";
        }

        private void txtCodigo_LostFocus(object sender, System.EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtDescrip_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void cboTipoActivos_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void cboCategoria_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void cboClase_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void cboGrupo_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void cboSubg_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtActPrinCod_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtActPrin_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtMarca_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtSerie_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void TxtLote_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtEstado_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void cboDepFin_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void cboDepTribut_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtImagen_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void cboSucursal_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtDep_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtSeccion_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtRespCod_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtResp_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtDocIng_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtDocSal_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtNDocIng_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtNDocSal_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            btnGuardar.Enabled = true;
        }

        private void txtFechaIng_LostFocus(object sender, System.EventArgs e)
        {
            DateTime fec;
            fec = (DateTime)"31 / 12 / 1900";
            if (IsDate(txtFechaIng.Text))
            {
                if ((DateTime)txtFechaIng.Text < fec)
                {
                    Interaction.MsgBox("Ingrese una FechaVálida", MsgBoxStyle.Exclamation);
                    txtFechaIng.Text = Strings.LSet(DateTime.Now, 10);
                    txtFechaIng.Focus();
                }
            }
        }

        private void txtFechaIng_ValueChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtFechaSal_ValueChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void cboCCosto_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtCostoIng_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
            modCosto = true;
        }

        private void txtValRes_LostFocus(object sender, System.EventArgs e)
        {

        }

        private void txtValRes_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtVidaUtConta_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtUndProdConta_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtValActualConta_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtVidaUtTribut_LostFocus(object sender, System.EventArgs e)
        {

        }

        private void txtVidaUtTribut_TextChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtUndProdTribut_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtTDep_MaskInputRejected(System.Object sender, System.Windows.Forms.MaskInputRejectedEventArgs e)
        {
            cambios = cambios + 1;
        }

        private void txtValActualTribut_TextChanged(System.Object sender, System.EventArgs e)
        {
            cambios = cambios + 1;
        }
        private void cboDepTribut_SelectedIndexChanged_1(System.Object sender, System.EventArgs e)
        {

        }
        private void cboDepFin_SelectedIndexChanged_1(System.Object sender, System.EventArgs e)
        {

        }
        private void cboDepTribut_LostFocus(object sender, System.EventArgs e)
        {

        }
        private void cboDepFin_LostFocus(object sender, System.EventArgs e)
        {

        }
        private void btnSucursal_Click(System.Object sender, System.EventArgs e)
        {

        }
        private void btnCCosto_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void imgImagen_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void txtContrato_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtMonto_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtDeducible_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void txtPagoM_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }
        private void imgImagen_MouseEnter(object sender, System.EventArgs e)
        {

        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {

        }
        // Private Sub btnParidad_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnParidad.MouseEnter, btnParidad.Click
        // ToolTip1.SetToolTip(btnParidad, "Ingresar Paridad")
        // End Sub
        private void cboMoneda_LostFocus(object sender, System.EventArgs e)
        {

        }

        private void cboMoneda_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

        }

        private void txtFechaInicioS_LostFocus(object sender, System.EventArgs e)
        {

        }

        private void txtFechaFinS_LostFocus(object sender, System.EventArgs e)
        {

        }

        private void btnReporte_Click(System.Object sender, System.EventArgs e)
        {

        }

        private void txtfechaSal_LostFocus(object sender, System.EventArgs e)
        {
            if (txtfechaSal.Text == "  /  /")
                return;
            if (!IsDate(txtfechaSal.Text))
            {
                Interaction.MsgBox("Ingrese una fecha válida!!", MsgBoxStyle.Information);
                txtfechaSal.Focus();
            }
        }
        private void ControlarBotones()
        {
            bool consultando = (proceso == 2);
            bool creando = (proceso == 1);

            BtnNuevo.Visible = (proceso == 0);
            btnAbrir.Visible = (proceso == 0);
            btnCancelar.Visible = (proceso > 0);
            btnGuardar.Visible = (proceso > 0);
            BtnEliminar.Visible = (proceso == 2);
            BtnSalir.Visible = true;
            btnReporte.Visible = (proceso == 2);
            txtCodigo.ReadOnly = (proceso == 2);
        }
    }
}
