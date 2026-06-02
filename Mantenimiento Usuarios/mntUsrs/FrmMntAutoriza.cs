using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DattCom;

namespace mntUsrs
{
    public partial class frmMntAutoriza : Form
    {
        string PathServidor = "";
        string strConxDaxsys = "";
        string strConxAdcom = "";
        string usuario = "";
        int empresa = 0;
        string nomEmpresa = "";
        string sistema = "";

        Boolean cambiado = false;
        ManejoBases progBas = new ManejoBases();

        private bool isLoading = false;
        private bool isUpdating = false;
        private ToolTip toolTip;

        public frmMntAutoriza(string PathServ, string strsys, string strConx, string usr, int emp, string nomEmp, string sys)
        {
            InitializeComponent();
            PathServidor = PathServ;
            strConxDaxsys = strsys;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = sys;
            strConxAdcom = strConx;
            this.Text = "Registrar accesos al sistema de " + nomEmp + " - Usuario: " + usr;
            this.WindowState = FormWindowState.Maximized;




            // Ocultar DataGridView
            if (mallaMenu != null)
            {
                mallaMenu.Visible = false;
                mallaMenu.Enabled = false;
            }

            if (splitContainer1 != null)
            {
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.SplitterDistance = 500;
                splitContainer1.Panel1MinSize = 300;
                splitContainer1.IsSplitterFixed = false;
                splitContainer1.FixedPanel = FixedPanel.Panel1;
            }

            ConfigurarFormulario();

            this.Shown += frmMntAutoriza_Shown;

            cargarMenus();
           }

        private void frmMntAutoriza_Shown(object sender, EventArgs e)
        {
            // Configurar ToolTip después de que el formulario está visible
            ConfigurarToolTip();

            // Ajustar el ancho después de que todo está cargado y visible
            AjustarAnchoOptimizado();
        }

        private void ConfigurarToolTip()
        {
            try
            {
                toolTip = new ToolTip();
                toolTip.InitialDelay = 500;
                toolTip.ReshowDelay = 100;
                toolTip.AutoPopDelay = 5000;
                toolTip.ShowAlways = true;

                // Verificar que treeViewMenu tiene handle
                if (treeViewMenu != null && treeViewMenu.IsHandleCreated)
                {
                    treeViewMenu.NodeMouseHover += (sender, e) =>
                    {
                        string textoCompleto = e.Node.Text;
                        toolTip.SetToolTip(treeViewMenu, textoCompleto);
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error configurando ToolTip: " + ex.Message);
            }
        }

        private void ConfigurarFormulario()
        {
            if (treeViewMenu != null)
            {
                treeViewMenu.Dock = DockStyle.Fill;
                treeViewMenu.CheckBoxes = true;
                treeViewMenu.FullRowSelect = true;
                treeViewMenu.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                treeViewMenu.HideSelection = false;
                treeViewMenu.ItemHeight = 32;
                treeViewMenu.BackColor = Color.White;
                treeViewMenu.BorderStyle = BorderStyle.None;
                treeViewMenu.Indent = 25;
            }

            if (splitContainer1 != null)
            {
                splitContainer1.Dock = DockStyle.Fill;
            }
        }

        private void cargarMenus()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CargarMenuEnTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar menús: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void AjustarAnchoOptimizado()
        {
            if (treeViewMenu == null || treeViewMenu.Nodes.Count == 0) return;

            try
            {
                // Verificar que el control ya tiene handle
                if (!treeViewMenu.IsHandleCreated)
                {
                    treeViewMenu.HandleCreated += (s, e) => AjustarAnchoOptimizado();
                    return;
                }

                int maxWidth = 0;

                // Guardar estado de expansión
                treeViewMenu.BeginUpdate();
                var expandedStates = new Dictionary<TreeNode, bool>();

                foreach (TreeNode node in treeViewMenu.Nodes)
                {
                    expandedStates[node] = node.IsExpanded;
                    node.ExpandAll();
                }

                // Medir el ancho necesario
                using (Graphics g = treeViewMenu.CreateGraphics())
                {
                    foreach (TreeNode node in treeViewMenu.Nodes)
                    {
                        int nodeWidth = TextRenderer.MeasureText(node.Text, treeViewMenu.Font).Width + 50;
                        maxWidth = Math.Max(maxWidth, nodeWidth);

                        foreach (TreeNode child in node.Nodes)
                        {
                            int childWidth = TextRenderer.MeasureText(child.Text, treeViewMenu.Font).Width + 70;
                            maxWidth = Math.Max(maxWidth, childWidth);
                        }
                    }
                }

                // Restaurar estado de expansión
                foreach (var kvp in expandedStates)
                {
                    if (!kvp.Value)
                        kvp.Key.Collapse();
                }
                treeViewMenu.EndUpdate();

                // Aplicar nuevo ancho
                if (splitContainer1 != null && maxWidth > 0 && splitContainer1.IsHandleCreated)
                {
                    int nuevoAncho = Math.Min(maxWidth + 40, this.ClientSize.Width - 150);
                    if (nuevoAncho > splitContainer1.Panel1MinSize)
                    {
                        splitContainer1.SplitterDistance = nuevoAncho;
                        splitContainer1.Panel1MinSize = nuevoAncho;
                        splitContainer1.IsSplitterFixed = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error ajustando ancho: " + ex.Message);
            }
        }

        private void CargarMenuEnTreeView()
        {
            if (isLoading) return;
            isLoading = true;

            try
            {
                if (!treeViewMenu.IsHandleCreated)
                {
                    treeViewMenu.CreateControl();
                }

                treeViewMenu.BeginUpdate();
                treeViewMenu.Nodes.Clear();

                HashSet<string> opcionesPermitidas = ObtenerPermisosUsuario();

                string ssql = @"SELECT Clave, Menuprincipal, Descripcion, orden 
                               FROM MenuSES 
                               WHERE Clave IS NOT NULL
                               ORDER BY Menuprincipal, ISNULL(orden, 999)";

                DataTable dtMenu = SqlDatos.leerTabla(ssql, strConxDaxsys);

                if (dtMenu == null || dtMenu.Rows.Count == 0)
                {
                    TreeNode nodoInfo = new TreeNode("No se encontraron datos del menú");
                    nodoInfo.Tag = "INFO";
                    nodoInfo.ForeColor = Color.Gray;
                    treeViewMenu.Nodes.Add(nodoInfo);
                    return;
                }

                var gruposMenu = new Dictionary<string, GrupoMenuInfo>();

                foreach (DataRow row in dtMenu.Rows)
                {
                    string menuPrincipal = row["Menuprincipal"].ToString();
                    if (string.IsNullOrEmpty(menuPrincipal)) continue;

                    if (!gruposMenu.ContainsKey(menuPrincipal))
                    {
                        gruposMenu[menuPrincipal] = new GrupoMenuInfo
                        {
                            Nombre = menuPrincipal,
                            OrdenMinimo = 999,
                            Items = new List<DataRow>()
                        };
                    }

                    object ordenObj = row["orden"];
                    int orden = ordenObj == DBNull.Value ? 999 : Convert.ToInt32(ordenObj);
                    if (orden < gruposMenu[menuPrincipal].OrdenMinimo)
                    {
                        gruposMenu[menuPrincipal].OrdenMinimo = orden;
                    }

                    gruposMenu[menuPrincipal].Items.Add(row);
                }

                var gruposOrdenados = gruposMenu.Values
                    .OrderBy(g => g.OrdenMinimo)
                    .ThenBy(g => g.Nombre)
                    .ToList();

                foreach (var grupo in gruposOrdenados)
                {
                    TreeNode nodoModulo = new TreeNode(grupo.Nombre);
                    nodoModulo.Tag = "MODULO";
                    nodoModulo.Name = "MOD_" + LimpiarNombre(grupo.Nombre);
                    nodoModulo.ForeColor = Color.DarkBlue;
                    nodoModulo.NodeFont = new Font("Segoe UI", 10F, FontStyle.Bold);

                    var hijosOrdenados = grupo.Items.OrderBy(r =>
                    {
                        object val = r["orden"];
                        return val == DBNull.Value ? 999 : Convert.ToInt32(val);
                    });

                    foreach (DataRow row in hijosOrdenados)
                    {
                        string clave = row["Clave"].ToString();
                        string descripcion = row["Descripcion"].ToString();

                        if (!string.IsNullOrEmpty(descripcion))
                        {
                            TreeNode nodoOpcion = new TreeNode(descripcion);
                            nodoOpcion.Tag = "OPCION";
                            nodoOpcion.Name = clave;
                            nodoOpcion.Checked = opcionesPermitidas.Contains(clave);
                            nodoOpcion.ForeColor = Color.Black;
                            nodoModulo.Nodes.Add(nodoOpcion);
                        }
                    }

                    ActualizarEstadoModulo(nodoModulo);
                    treeViewMenu.Nodes.Add(nodoModulo);
                }

                treeViewMenu.CollapseAll();

                if (treeViewMenu.Nodes.Count > 0)
                {
                    treeViewMenu.SelectedNode = treeViewMenu.Nodes[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el árbol de menú: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                treeViewMenu.EndUpdate();
                isLoading = false;
            }
        }
        private void AjustarAnchoTreeView()
        {
            try
            {
                // Calcular el ancho máximo necesario
                int anchoMaximo = 0;

                using (Graphics g = treeViewMenu.CreateGraphics())
                {
                    // Usar la fuente real del TreeView
                    Font fuenteNodo = treeViewMenu.Font;

                    foreach (TreeNode nodo in treeViewMenu.Nodes)
                    {
                        // Medir texto del nodo principal
                        SizeF tamaño = g.MeasureString(nodo.Text, fuenteNodo);
                        int anchoNodo = (int)tamaño.Width + 50; // Margen para checkbox y padding

                        // Medir nodos hijos
                        foreach (TreeNode hijo in nodo.Nodes)
                        {
                            SizeF tamañoHijo = g.MeasureString(hijo.Text, fuenteNodo);
                            int anchoHijo = (int)tamañoHijo.Width + 70; // Más sangría
                            if (anchoHijo > anchoNodo)
                                anchoNodo = anchoHijo;
                        }

                        if (anchoNodo > anchoMaximo)
                            anchoMaximo = anchoNodo;
                    }
                }

                // Ajustar el SplitterDistance
                if (splitContainer1 != null && anchoMaximo > 0)
                {
                    // Agregar márgenes y scroll
                    splitContainer1.SplitterDistance = Math.Min(anchoMaximo + 40, this.ClientSize.Width - 200);
                    splitContainer1.Panel1MinSize = splitContainer1.SplitterDistance;
                    splitContainer1.IsSplitterFixed = true;

                    // Forzar el redibujado
                    treeViewMenu.Refresh();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error ajustando ancho: " + ex.Message);
            }
        }

        private HashSet<string> ObtenerPermisosUsuario()
        {
            HashSet<string> opcionesPermitidas = new HashSet<string>();

            try
            {
                string ssql = @"SELECT IdOpcion FROM sys_Accesos 
                               WHERE IdUsuario = '" + usuario.Replace("'", "''") + @"' 
                               AND IdEmpresa = " + empresa + @" 
                               AND IdSistema = '" + sistema.Replace("'", "''") + @"' 
                               AND Accesos = 'T'";

                DataTable dtPermisos = SqlDatos.leerTabla(ssql, strConxDaxsys);

                if (dtPermisos != null && dtPermisos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtPermisos.Rows)
                    {
                        string opcion = row["IdOpcion"].ToString().Trim();
                        if (!string.IsNullOrEmpty(opcion))
                        {
                            opcionesPermitidas.Add(opcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener permisos: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return opcionesPermitidas;
        }

        private string LimpiarNombre(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return texto.Replace(" ", "").Replace("á", "a").Replace("é", "e")
                       .Replace("í", "i").Replace("ó", "o").Replace("ú", "u")
                       .Replace("ñ", "n");
        }

        private void ActualizarEstadoModulo(TreeNode nodoModulo)
        {
            if (nodoModulo == null || nodoModulo.Nodes.Count == 0) return;

            int marcados = 0;
            foreach (TreeNode hijo in nodoModulo.Nodes)
            {
                if (hijo.Checked) marcados++;
            }

            nodoModulo.Checked = marcados == nodoModulo.Nodes.Count;
        }

        private void treeViewMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (isLoading || isUpdating) return;

            if (e.Node.Tag != null && e.Node.Tag.ToString() == "INFO")
            {
                e.Node.Checked = false;
                return;
            }

            try
            {
                isUpdating = true;

                if (e.Node.Tag != null && e.Node.Tag.ToString() == "MODULO")
                {
                    treeViewMenu.BeginUpdate();
                    foreach (TreeNode hijo in e.Node.Nodes)
                    {
                        hijo.Checked = e.Node.Checked;
                    }
                    treeViewMenu.EndUpdate();
                }
                else if (e.Node.Tag != null && e.Node.Tag.ToString() == "OPCION")
                {
                    if (e.Node.Parent != null)
                    {
                        ActualizarEstadoModulo(e.Node.Parent);
                    }
                }

                cambiado = true;
            }
            finally
            {
                isUpdating = false;
            }
        }

        private void GuardarPermisos()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                using (SqlConnection conn = new SqlConnection(strConxDaxsys))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlDelete = @"DELETE FROM sys_Accesos 
                                               WHERE IdUsuario = @usuario 
                                               AND IdEmpresa = @empresa 
                                               AND IdSistema = @sistema";

                            using (SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn, trans))
                            {
                                cmdDelete.Parameters.AddWithValue("@usuario", usuario);
                                cmdDelete.Parameters.AddWithValue("@empresa", empresa);
                                cmdDelete.Parameters.AddWithValue("@sistema", sistema);
                                cmdDelete.ExecuteNonQuery();
                            }

                            string sqlInsert = @"INSERT INTO sys_Accesos 
                                               (IdUsuario, IdEmpresa, IdSistema, IdOpcion, IdNomOpcion, Accesos) 
                                               VALUES (@usuario, @empresa, @sistema, @opcion, @nomopcion, 'T')";

                            int contador = 0;
                            using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn, trans))
                            {
                                cmdInsert.Parameters.AddWithValue("@usuario", usuario);
                                cmdInsert.Parameters.AddWithValue("@empresa", empresa);
                                cmdInsert.Parameters.AddWithValue("@sistema", sistema);

                                SqlParameter paramOpcion = cmdInsert.Parameters.Add("@opcion", SqlDbType.NVarChar, 255);
                                SqlParameter paramNomOpcion = cmdInsert.Parameters.Add("@nomopcion", SqlDbType.NVarChar, 512);

                                foreach (TreeNode nodoModulo in treeViewMenu.Nodes)
                                {
                                    if (nodoModulo.Tag != null && nodoModulo.Tag.ToString() == "INFO") continue;

                                    foreach (TreeNode nodoOpcion in nodoModulo.Nodes)
                                    {
                                        if (nodoOpcion.Checked)
                                        {
                                            paramOpcion.Value = nodoOpcion.Name;
                                            paramNomOpcion.Value = nodoOpcion.Text;
                                            cmdInsert.ExecuteNonQuery();
                                            contador++;
                                        }
                                    }
                                }
                            }

                            trans.Commit();

                            MessageBox.Show($"Permisos guardados exitosamente!\n\nSe asignaron {contador} accesos para el usuario {usuario}",
                                           "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cambiado = false;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar permisos: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tnCambia_Click(object sender, EventArgs e)
        {
            if (treeViewMenu.SelectedNode != null && treeViewMenu.SelectedNode.Tag != null
                && treeViewMenu.SelectedNode.Tag.ToString() != "INFO")
            {
                treeViewMenu.SelectedNode.Checked = !treeViewMenu.SelectedNode.Checked;
                cambiado = true;
            }
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            isUpdating = true;
            try
            {
                treeViewMenu.BeginUpdate();
                foreach (TreeNode nodoModulo in treeViewMenu.Nodes)
                {
                    if (nodoModulo.Tag != null && nodoModulo.Tag.ToString() == "INFO") continue;

                    nodoModulo.Checked = true;
                    foreach (TreeNode nodoOpcion in nodoModulo.Nodes)
                    {
                        nodoOpcion.Checked = true;
                    }
                }
                treeViewMenu.EndUpdate();
                cambiado = true;
            }
            finally
            {
                isUpdating = false;
            }
        }

        private void btnColumna_Click(object sender, EventArgs e)
        {
            if (treeViewMenu.SelectedNode != null && treeViewMenu.SelectedNode.Parent != null
                && treeViewMenu.SelectedNode.Tag != null && treeViewMenu.SelectedNode.Tag.ToString() != "INFO")
            {
                TreeNode nodoPadre = treeViewMenu.SelectedNode.Parent;
                bool todosMarcados = true;

                foreach (TreeNode hijo in nodoPadre.Nodes)
                {
                    if (!hijo.Checked)
                    {
                        todosMarcados = false;
                        break;
                    }
                }

                foreach (TreeNode hijo in nodoPadre.Nodes)
                {
                    hijo.Checked = !todosMarcados;
                }

                ActualizarEstadoModulo(nodoPadre);
                cambiado = true;
            }
        }

        private void btnLinea_Click(object sender, EventArgs e)
        {
            if (treeViewMenu.SelectedNode != null && treeViewMenu.SelectedNode.Tag != null
                && treeViewMenu.SelectedNode.Tag.ToString() != "INFO")
            {
                treeViewMenu.SelectedNode.Checked = !treeViewMenu.SelectedNode.Checked;

                if (treeViewMenu.SelectedNode.Tag.ToString() == "MODULO")
                {
                    foreach (TreeNode hijo in treeViewMenu.SelectedNode.Nodes)
                    {
                        hijo.Checked = treeViewMenu.SelectedNode.Checked;
                    }
                }
                else if (treeViewMenu.SelectedNode.Parent != null)
                {
                    ActualizarEstadoModulo(treeViewMenu.SelectedNode.Parent);
                }

                cambiado = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPermisos();
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (cambiado)
            {
                DialogResult resp = MessageBox.Show("¿Desea guardar los cambios antes de salir?",
                    "Salir del proceso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resp == DialogResult.Cancel) return;
                if (resp == DialogResult.Yes)
                {
                    GuardarPermisos();
                }
            }
            this.Close();
        }

        private void frmMntAutoriza_Load(object sender, EventArgs e) { }
        private void mallaMenu_KeyDown(object sender, KeyEventArgs e) { }
        private void controlBotones() { }
        private void btnEliminar_Click(object sender, EventArgs e) { }
    }
}