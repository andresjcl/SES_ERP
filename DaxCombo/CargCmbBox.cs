using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DattCom;
namespace DaxCombobx
{
    public class CargCmbBox
    {
        string condicion = "";
        bool conIniciacion = false;
        public bool DaxCombosDoc(string ClaseDoc, string TipoDoc, bool todos, string strCon, ref ComboBox PasCombo)
        {
            string usuar = DatosUsuario.Identifica;
            string CLASE = "";
            string tds = "select '   Todos los Documentos' as Opc_nombre,'0' as Opc_documento ";
            condicion = DatosUsuario.DocsUsr(ClaseDoc).Replace(" ", "','");
            string ssql = " select top 100 percent Opc_nombre,Opc_documento from AdcOpc where opc_documento <> ''";
            if (!string.IsNullOrEmpty(ClaseDoc))
            {
                CLASE = " and (";
                var loopTo = ClaseDoc.Length - 1;
                for (var I = 0; I <= loopTo; I += 3)
                {
                    switch (ClaseDoc.Substring(I, 3).ToUpper())
                    {
                        case "ELE":
                            {
                                ssql += CLASE + " EsElectronico=1 "; CLASE = " OR ";
                                break;
                            }
                        case "AUT":
                            {
                                ssql += CLASE + " documentonoactivado=1 "; CLASE = " OR ";
                                break;
                            }

                        case "INV":
                            {
                                ssql += CLASE + " substring(opc_extension,5,1) <> '0' "; CLASE = " OR ";
                                break;
                            }

                        case "TTB":
                            {
                                ssql += CLASE + " opc_contabiliza = 1 "; CLASE = " OR ";
                                break;
                            }

                        case "CTB":
                            {
                                ssql += CLASE + " opc_tipo='DIA' OR opc_contabiliza = 1 "; CLASE = " OR ";
                                break;
                            }

                        case "SRI":
                            {
                                ssql += CLASE + " opc_tipoSRI > '' "; CLASE = " Or ";
                                break;
                            }

                        default:
                            {
                                ssql += (CLASE + " opc_tipo='") + ClaseDoc.Substring(I, 3).ToUpper() + "'"; CLASE = " OR ";
                                break;
                            }
                    }
                }
                ssql += ") ";
            }
            if (TipoDoc.Length == 3)
                ssql += " and Opc_documento ='" + TipoDoc + "'";
            else if (TipoDoc.Length > 3)
                ssql += " and Opc_documento in(" + TipoDoc + ")";

            if (!((usuar.ToUpper() == "ADMINISTRADOR") | (usuar.ToUpper() == "CONTROL")))
            {
                if (!string.IsNullOrEmpty(TipoDoc))
                    ssql += " and Opc_documento ='" + TipoDoc + "'";
                ssql += " and Opc_documento in('" + condicion + "')";
            }
            if (todos == true) ssql = tds + " union all " + ssql;
            ssql = "select ltrim(opc_nombre) as nombre,Opc_documento from (" + ssql + " ) r1 order by opc_nombre";            

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, strCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);

                // Verifica que las columnas existan
                if (dat.Columns.Contains("nombre") && dat.Columns.Contains("Opc_documento"))
                {                   
                    PasCombo.DataSource = dat;
                    PasCombo.DisplayMember = "nombre";
                    PasCombo.ValueMember = "Opc_documento";
                }
                else
                {
                    MessageBox.Show("Las columnas 'nombre' u 'Opc_documento' no existen en el resultado.");
                }
            }

            return true;
        }
        public bool DaxCombosDoc(string ClaseDoc, string TipoDoc, bool todos, string strCon, ref ToolStripComboBox PasCombo)
        {
            string CLASE = "";
            string tds = "select 'Todos los Documentos' as Opc_nombre,'0' as Opc_documento ";
            PasCombo.Items.Clear();
            condicion = DatosUsuario.DocsUsr(ClaseDoc).Replace(" ", "','");
            string ssql = " select TOP 100 percent Opc_nombre,Opc_documento from AdcOpc where opc_documento <> ''";
            if (!string.IsNullOrEmpty(ClaseDoc))
            {
                CLASE = " and (";
                var loopTo = ClaseDoc.Length - 1;
                for (var I = 0; I <= loopTo; I += 3)
                {
                    switch (ClaseDoc.Substring(I, 3).ToUpper())
                    {
                        case "ELE":
                            {
                                ssql += CLASE + " EsElectronico=1 "; CLASE = " OR ";
                                break;
                            }
                        case "AUT":
                            {
                                ssql += CLASE + " documentonoactivado=1 "; CLASE = " OR ";
                                break;
                            }

                        case "INV":
                            {
                                ssql += CLASE + " substring(opc_extension,5,1) <> '0' "; CLASE = " OR ";
                                break;
                            }

                        case "TTB":
                            {
                                ssql += CLASE + " opc_contabiliza = 1 "; CLASE = " OR ";
                                break;
                            }

                        case "CTB":
                            {
                                ssql += CLASE + " opc_tipo='DIA' OR opc_contabiliza = 1 "; CLASE = " OR ";
                                break;
                            }

                        case "SRI":
                            {
                                ssql += CLASE + " opc_tipoSRI > '' "; CLASE = " Or ";
                                break;
                            }

                        default:
                            {
                                ssql += (CLASE + " opc_tipo='") + ClaseDoc.Substring(I, 3).ToUpper() + "'"; CLASE = " OR ";
                                break;
                            }
                    }
                }
                ssql += ") ";
            }
            if (!((datosEmpresa.usr.ToUpper() == "ADMINISTRADOR") | (datosEmpresa.usr.ToUpper() == "CONTROL")))
            {
                if (!string.IsNullOrEmpty(TipoDoc))
                    ssql += " and Opc_documento ='" + TipoDoc + "'";
                ssql += " and Opc_documento in('" + condicion + "')";
            }
            if (todos == true) ssql = tds + " union all " + ssql;
            ssql = "select ltrim(opc_nombre) as nombre,Opc_documento from (" + ssql + " ) r1 order by opc_nombre";
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, strCon))
            {
                 DataTable dat = new DataTable();
                datA.Fill(dat);
                foreach (DataRow row in dat.Rows)
                {
                    PasCombo.Items.Add(row["Opc_documento"].ToString() + "-" + row["Opc_nombre"].ToString());
                }
            }
            return true;
        }

        public bool DaxCombosVend(string StrCon, ref ComboBox PasCombo, bool TODOS = true)
        {
            string ssql = "select NombreImpresion as Nombre, codigo from identificacion where esVendedor=1 ";
            if (TODOS) ssql = " select '    Todos' as Nombre, '0' as codigo  UNION ALL " + ssql;                        
            ssql = " SELECT LTRIM(Nombre) as NombreImpresion, Codigo from(" + ssql + ") r1 order by Nombre ";

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "NombreImpresion";
                PasCombo.ValueMember = "codigo";
            }
            return true;
        }

        public bool DaxCombosPtoVta(string StrCon, ref ComboBox PasCombo, bool TODOS = true)
        {
            string ssql = "DaxOpcPtoVta " + datosEmpresa.codEmpresa + ",1" ;
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat; ;
                PasCombo.DisplayMember = "puntoo";
                PasCombo.ValueMember = "codigo";
            }
            return true;
        }
        public bool DaxCombosPtoVtaReg(string StrSys, ref ComboBox PasCombo, bool TODOS = true,string SUC = "")
        {
            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                string Todos = "N";
                if (TODOS == true) { Todos = "S"; }
                string ssql = "CmbPtosVta " + datosEmpresa.codEmpresa.ToString() + ", '" + SUC + "','" + Todos + "'";
                SqlCommand comm = new SqlCommand(ssql, conn);
                comm.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter datA = new SqlDataAdapter(ssql, conn))
                {
                    conn.Open();
                    DataTable dat = new DataTable();
                    datA.Fill(dat);
                    PasCombo.DataSource = dat;
                    PasCombo.DisplayMember = "nombre";
                    PasCombo.ValueMember = "codigo";
                }
            }                        
            return true;
        }

        public bool DaxCombosBancos(string StrCon, ref ComboBox PasCombo)
        {
            string ssql = "select NombreImpresion, codigo from identificacion where esBanco=1 order by NombreImpresion";
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "NombreImpresion";
                PasCombo.ValueMember = "codigo";
            }
            return true;
        }

        public bool DaxCombosCat(string categoria, string InvServAcf, string StrCon, ref ComboBox PasCombo,bool Todos = true)
        {
            string tabla = "";
            string td = "select 'Todo' as Niv_nombre, '0' as Niv_abrevia union all ";
            if (Todos == false) td = "";
            string cat = "";
            switch (categoria.ToUpper())
            {
                case "CL":
                    {
                        cat = "2";
                        break;
                    }

                case "G":
                    {
                        cat = "3";
                        break;
                    }

                case "S":
                    {
                        cat = "4";
                        break;
                    }

                default:
                    {
                        cat = "1";
                        break;
                    }
            }
            if (InvServAcf == "A")
                tabla = "AdcNivAcf";
            else if (InvServAcf == "S")
                tabla = "AdcNivServ";
            else
                tabla = "AdcNiv";
            string ssql = td + " select Niv_nombre, Niv_abrevia from " + tabla + " where Niv_categor=" + cat;

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon ))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Niv_nombre";
                PasCombo.ValueMember = "Niv_abrevia";
            }
            return true;
        }

        public bool DaxCombosSuc(string empresa, bool todo, string StrCon, ref ComboBox PasCombo, bool userSuc = true)
        {

            string td = "select 'Todas las sucursales' as Suc_Nombre, '0' as Suc_Codigo union all ";
            if (!(DattCom.DatosUsuario.SucsUsr()  == null))
                condicion = DattCom.DatosUsuario.SucsUsr().Replace(" ", "','");
            else
                condicion = "";
            string ssql = "select * from (select top 100 percent Suc_Nombre, Suc_Codigo from Emp_Suc where Suc_Codigo<>'' and emp_codigo=" + empresa;
            if (todo == true) ssql = td + ssql;
            if (!((datosEmpresa.usr.ToUpper() == "ADMINISTRADOR") || (datosEmpresa.usr.ToUpper() == "CONTROL")) && userSuc) ssql += " and Suc_Codigo in('" + condicion + "')";
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql + " order by suc_nombre) r1", StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Suc_Nombre";
                PasCombo.ValueMember = "Suc_Codigo";
            }
            return true;
        }

        public bool DaxCombosBods(string Suc, bool todo, string StrCon, ref ComboBox PasCombo, bool deUser = true)
        {
            string ssql = "";
            if (todo) ssql = "select 'Todas las bodegas' as Bod_nombre, '0' as Bod_codigo union all ";
            condicion = DattCom.DatosUsuario.Bods.Replace(" ", "','");
            ssql += "select Bod_nombre, Bod_codigo from Emp_bod where Bod_codigo<>'' and emp_codigo=" + datosEmpresa.codEmpresa;
            if (!string.IsNullOrEmpty(Suc)) ssql += " And Suc_codigo='" + Suc + "'";
            if (DattCom.DatosUsuario.codigo.ToUpper() != "ADMINISTRADOR" & DattCom.DatosUsuario.codigo.ToUpper() != "CONTROL" & deUser)
            {
                ssql += " and Bod_Codigo in('" + condicion + "')";
            }
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Bod_nombre";
                PasCombo.ValueMember = "Bod_codigo";
            }
            return true;
        }

        public bool DaxCombosReferencia(string referencia, string StrCon, ref ComboBox PasCombo, string conVacio)
        {
            try { if (conVacio == "S") conIniciacion = true; else conIniciacion = false; } catch { }
            return DaxCombosReferencia(referencia, StrCon, ref PasCombo,false);
        }
        public bool DaxCombosReferencia(string referencia, string StrCon, ref ComboBox PasCombo, bool todos = false)
        {
            string ssql = "";
            ssql = "select top 100 percent Descripcion, Abreviación from SysCod where TipoReferencia ='" + referencia + "'";
            ssql += " and Abreviación <>'#'";
            if (todos)
                ssql = "select ' Todos' as Descripcion, '0' as Abreviación union all select * from (" + ssql + ") r1 ";
            if (conIniciacion)
                ssql = "select ' ' as Descripcion, '' as Abreviación union all select * from (" + ssql + ") r1 ";
            ssql += " order by descripcion ";

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Descripcion";
                PasCombo.ValueMember = "Abreviación";
            }
            if (todos) PasCombo.SelectedValue = "0";
            if (conIniciacion) PasCombo.SelectedValue = "";
            return true;
        }
        public bool DaxCombosReferencia(string StrCon, ref ComboBox PasCombo, bool todos = false)
        {
            string ssql = "select top 100 percent TipoReferencia , TipoReferencia as Cod from SysCod where abreviación ='#' order by TipoReferencia";
            if (todos)
                ssql = "select 'Todos' as TipoReferencia, '0' as Cod union all select * from (" + ssql + ") r1 ";
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "TipoReferencia";
                PasCombo.ValueMember = "Cod";
            }
            return true;
        }

        public bool DaxCombosCtasCorrientes(string StrCon, ref ComboBox PasCombo)
        {
            string ssql = "select Bco_Nombre, Bco_NumCta from Adcctabco ";
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Bco_Nombre";
                PasCombo.ValueMember = "Bco_NumCta";
            }
            return true;
        }

        public bool DaxCombosClasf(string StrCon, ref ComboBox PasCombo)
        {
            string ssql = "select nombre from adcclasfctb where esclasificador = 1";
            DataTable dat = new DataTable();
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "nombre";
                PasCombo.ValueMember = "nombre";
            }
            return true;
        }

        public bool DaxCombosFormPago(string StrCon, ref ComboBox PasCombo)
        {
            string ssql = "select idFormasDePago,Descripcion  from FormasDePago ";
            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Descripcion";
                PasCombo.ValueMember = "idFormasDePago";
            }
            return true;
        }
        public bool DaxCombosCiudades(string StrCon, ref ComboBox PasCombo, bool todos = false,string Provincia = "",string Canton="",bool conIniciacion=false)
        {
            string ssql = "";
            ssql = "select top 100 percent Descripcion, Abreviación from SysCod where TipoReferencia ='Ciudades'";
            ssql += " and Abreviación <>'#' and substring(Abreviación,2,2)='" + Provincia + "'";
            if (Canton.Length > 0 ) ssql += " and substring(Abreviación,4,2)='"+""+Canton+"'";
            if (todos)
                ssql = "select ' Todos' as Descripcion, '0' as Abreviación union all select * from (" + ssql + ") r1 ";
            if (conIniciacion)
                ssql = "select ' ' as Descripcion, '' as Abreviación union all select * from (" + ssql + ") r1 ";
            ssql += " order by descripcion ";

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Descripcion";
                PasCombo.ValueMember = "Abreviación";
            }
            if (todos) PasCombo.SelectedValue = "0";
            if (conIniciacion) PasCombo.SelectedValue = "";
            return true;
        }
        public bool DaxCombosCantones(string StrCon, ref ComboBox PasCombo, bool todos = false, string Provincia = "", bool conIniciacion = false)
        {
            string ssql = "";
            ssql = "select top 100 percent Descripcion, Abreviación from SysCod where TipoReferencia ='Cantones'";
            ssql += " and Abreviación <>'#' and substring(Abreviación,1,2)='" + Provincia + "'";
            if (todos)
                ssql = "select ' Todos' as Descripcion, '0' as Abreviación union all select * from (" + ssql + ") r1 ";
            if (conIniciacion)
                ssql = "select ' ' as Descripcion, '' as Abreviación union all select * from (" + ssql + ") r1 ";
            ssql += " order by descripcion ";

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Descripcion";
                PasCombo.ValueMember = "Abreviación";
            }
            if (todos) PasCombo.SelectedValue = "0";
            if (conIniciacion) PasCombo.SelectedValue = "";
            return true;
        }
        public bool DaxCombosParroquias(string StrCon, ref ComboBox PasCombo, bool todos = false, string Provincia = "",string Canton = "", bool conIniciacion = false)
        {
            string ssql = "";
            ssql = "select top 100 percent Descripcion, Abreviación from SysCod where TipoReferencia ='Parroquias'";
            ssql += " and Abreviación <>'#' and substring(Abreviación,1,2)='" + Provincia + "'";
            if (Canton.Length > 0) ssql += " and substring(Abreviación,3,2)='" + "" + Canton + "'";
            if (todos)
                ssql = "select ' Todos' as Descripcion, '0' as Abreviación union all select * from (" + ssql + ") r1 ";
            if (conIniciacion)
                ssql = "select ' ' as Descripcion, '' as Abreviación union all select * from (" + ssql + ") r1 ";
            ssql += " order by descripcion ";

            using (SqlDataAdapter datA = new SqlDataAdapter(ssql, StrCon))
            {
                DataTable dat = new DataTable();
                datA.Fill(dat);
                PasCombo.DataSource = dat;
                PasCombo.DisplayMember = "Descripcion";
                PasCombo.ValueMember = "Abreviación";
            }
            if (todos) PasCombo.SelectedValue = "0";
            if (conIniciacion) PasCombo.SelectedValue = "";
            return true;
        }

    }
}
