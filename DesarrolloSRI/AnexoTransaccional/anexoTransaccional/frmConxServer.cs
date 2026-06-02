//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Text;
//using System.Windows.Forms;

//namespace anexoTransaccional
//{
//    public partial class FrmConxServer : Form
//    {
//        //string strConxDaxsys = "";
       
//        //public frmConxServer()
//        //{
//        //    InitializeComponent();
//        //    cargarValores();
//        //}

//        //private void Command1_Click(object sender, EventArgs e)
//        //{
//        //    SqlConnection  cnn = new SqlConnection();
//        //    string Conx ="";
//        //    string error ="";
//        //    Boolean esOK=true;
//        //    if (ValidaClave(TxtPassword.Text, TxtPasswordc.Text) == false ) return;
//        //    if ( TxtServidor.Text != "") 
//        //    try
//        //    {
//        //        Conx = PROG.ArmStr("master", TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text).ToString();
//        //        cnn.ConnectionString = Conx;
//        //        cnn.Open();
//        //        if (cnn.State != ConnectionState.Open) esOK = false;
//        //    }
//        //    catch (Exception ex) { esOK=false;error = ex.Message ;}
//        //    if (esOK == false)
//        //    {
//        //        MessageBox.Show ("No se pudo efectuar la conexión al servidor de base de datos","Conexión a servidor externo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return ;
//        //    }
//        //    MessageBox.Show ("Conexión al servidor exitosa","Conexión a servidor externo", MessageBoxButtons.OK);        
//        //    cnn.Close();
            
//        //    esOK = true;
//        //    try
//        //    {
//        //        Conx = PROG.ArmStr("Daxsys", TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text).ToString();
//        //        cnn.ConnectionString = Conx;
//        //        cnn.Open();
//        //        if (cnn.State != ConnectionState.Open) esOK = false;
//        //    }
//        //    catch (Exception ex) { esOK=false;error = ex.Message ;}

//        //    if (esOK == false)
//        //    {
//        //        MessageBox.Show ("No se ha instalado la base de datos control del sistema AdcomDx en el servidor","Conexión a servidor externo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return ;
//        //    }
//        //    cnn.Close();
//        //    grabarValores();
            
//        //}
//        //private void grabarValores()
//        //{
//        //    AdcHisOpc.AdcHistOpc progini = new AdcHisOpc.AdcHistOpc();            

//        //    progini.GrabarOpcionHis (strConxDaxsys, "externo","adcomdax","conexion","ats", "servidor", TxtServidor.Text);
//        //    progini.GrabarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "usuario", TxtUsuario.Text);
//        //    progini.GrabarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "clave", TxtPassword.Text);
//        //    progini.GrabarOpcionHis(strConxDaxsys, "externo","adcomdax","conexion","ats", "Servidor", TxtServidor.Text);
//        //    progini.GrabarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "Base", TxtUrl.Text);
//        //    progini = null;

//        //}
//        //private void cargarValores()
//        //{
//        //    PROG.TipoBase = "10";
//        //    strConxDaxsys = PROG.StrDaxsys();
//        //    AdcHisOpc.AdcHistOpc progini = new AdcHisOpc.AdcHistOpc();
//        //    TxtServidor.Text = progini.CargarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "servidor");
//        //    TxtUsuario.Text = progini.CargarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "usuario");
//        //    TxtPassword.Text = progini.CargarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "clave");
//        //    TxtServidor.Text = progini.CargarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "Servidor");
//        //    TxtUrl.Text = progini.CargarOpcionHis(strConxDaxsys, "externo", "adcomdax", "conexion", "ats", "Base");
//        //    progini = null;        
//        //}

//        //private Boolean ValidaClave(string Cl1, string Cl2)
//        //{
//        //    if (Cl1 != Cl2 )
//        //    {
//        //        MessageBox.Show ("No coinciden las contraseñas","Datos de conexion eterna", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//        //        TxtPassword.Focus();
//        //        return false;
//        //    }
//        //    return true;
//        //}

//        //private void Command3_Click(object sender, EventArgs e)
//        //{
//        //    this.Close();
//        //}

//        //private void frmConxServer_Load(object sender, EventArgs e)
//        //{

//        //}

//        //private void Command2_Click(object sender, EventArgs e)
//        //{
//        //    if (ValidaClave(TxtPassword.Text, TxtPasswordc.Text) == false) return;
//        //    grabarValores();
//        //    this.Close();
//        //}

//    }
//}
