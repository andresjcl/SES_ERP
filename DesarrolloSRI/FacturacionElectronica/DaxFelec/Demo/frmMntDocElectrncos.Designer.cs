using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using WebServiseSRI;

namespace DaxDocElectronicos
{
    [DesignerGenerated()]
    public partial class frmMntDocElectrncos : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMntDocElectrncos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.ToolStripContainer4 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip12 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._btnSalir = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip7 = new System.Windows.Forms.ToolStrip();
            this.ToolStrip4 = new System.Windows.Forms.ToolStrip();
            this.btnAbre = new System.Windows.Forms.ToolStripButton();
            this._btnGenerar = new System.Windows.Forms.ToolStripButton();
            this.btnFirmar = new System.Windows.Forms.ToolStripButton();
            this._btnAutorizar = new System.Windows.Forms.ToolStripButton();
            this._btnCorreoXml = new System.Windows.Forms.ToolStripButton();
            this._btnEnviar = new System.Windows.Forms.ToolStripButton();
            this._ToolStrip5 = new System.Windows.Forms.ToolStrip();
            this._btnGenerarGrupo = new System.Windows.Forms.ToolStripButton();
            this._btn = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Label1 = new System.Windows.Forms.Label();
            this.LabTipo = new System.Windows.Forms.Label();
            this.LabId = new System.Windows.Forms.Label();
            this.LabNumero = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.LabCiRuc = new System.Windows.Forms.Label();
            this.LabNombre = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.LabClave = new System.Windows.Forms.Label();
            this.LabEstado = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.LabFechaAutoriza = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.LabNumeroAutoriza = new System.Windows.Forms.Label();
            this.mensaje = new System.Windows.Forms.Label();
            this.chkOnLine = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.ToolStripContainer4.ContentPanel.SuspendLayout();
            this.ToolStripContainer4.SuspendLayout();
            this.ToolStrip12.SuspendLayout();
            this.ToolStrip4.SuspendLayout();
            this._ToolStrip5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ToolStripContainer4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 58);
            this.panel2.TabIndex = 6;
            // 
            // ToolStripContainer4
            // 
            this.ToolStripContainer4.BottomToolStripPanelVisible = false;
            // 
            // ToolStripContainer4.ContentPanel
            // 
            this.ToolStripContainer4.ContentPanel.BackColor = System.Drawing.Color.DimGray;
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip12);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip7);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip4);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this._ToolStrip5);
            this.ToolStripContainer4.ContentPanel.Size = new System.Drawing.Size(814, 58);
            this.ToolStripContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer4.LeftToolStripPanelVisible = false;
            this.ToolStripContainer4.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer4.Name = "ToolStripContainer4";
            this.ToolStripContainer4.RightToolStripPanelVisible = false;
            this.ToolStripContainer4.Size = new System.Drawing.Size(814, 58);
            this.ToolStripContainer4.TabIndex = 3;
            this.ToolStripContainer4.Text = "ToolStripContainer4";
            // 
            // ToolStripContainer4.TopToolStripPanel
            // 
            this.ToolStripContainer4.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
            this.ToolStripContainer4.TopToolStripPanelVisible = false;
            // 
            // ToolStrip12
            // 
            this.ToolStrip12.AutoSize = false;
            this.ToolStrip12.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip12.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip12.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.ToolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator7,
            this._btnSalir});
            this.ToolStrip12.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip12.Location = new System.Drawing.Point(396, 0);
            this.ToolStrip12.Name = "ToolStrip12";
            this.ToolStrip12.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip12.Size = new System.Drawing.Size(418, 58);
            this.ToolStrip12.Stretch = true;
            this.ToolStrip12.TabIndex = 9;
            this.ToolStrip12.Text = "ToolStrip12";
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 58);
            // 
            // _btnSalir
            // 
            this._btnSalir.ForeColor = System.Drawing.Color.White;
            this._btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("_btnSalir.Image")));
            this._btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(68, 55);
            this._btnSalir.Text = "Salir";
            this._btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ToolStrip7
            // 
            this.ToolStrip7.AutoSize = false;
            this.ToolStrip7.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip7.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip7.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip7.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip7.Location = new System.Drawing.Point(386, 0);
            this.ToolStrip7.Name = "ToolStrip7";
            this.ToolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip7.Size = new System.Drawing.Size(10, 58);
            this.ToolStrip7.Stretch = true;
            this.ToolStrip7.TabIndex = 4;
            this.ToolStrip7.Text = "ToolStrip7";
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbre,
            this._btnGenerar,
            this.btnFirmar,
            this._btnAutorizar,
            this._btnCorreoXml,
            this._btnEnviar});
            this.ToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip4.Location = new System.Drawing.Point(55, 0);
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip4.Size = new System.Drawing.Size(331, 58);
            this.ToolStrip4.Stretch = true;
            this.ToolStrip4.TabIndex = 0;
            this.ToolStrip4.Text = "ToolStrip4";
            // 
            // btnAbre
            // 
            this.btnAbre.ForeColor = System.Drawing.Color.White;
            this.btnAbre.Image = ((System.Drawing.Image)(resources.GetObject("btnAbre.Image")));
            this.btnAbre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAbre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbre.Name = "btnAbre";
            this.btnAbre.Size = new System.Drawing.Size(42, 55);
            this.btnAbre.Text = "Abre  ";
            this.btnAbre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbre.ToolTipText = "Abrir un documento existente";
            // 
            // _btnGenerar
            // 
            this._btnGenerar.ForeColor = System.Drawing.Color.White;
            this._btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("_btnGenerar.Image")));
            this._btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGenerar.Name = "_btnGenerar";
            this._btnGenerar.Size = new System.Drawing.Size(52, 55);
            this._btnGenerar.Text = "Generar";
            this._btnGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnGenerar.ToolTipText = "Generar archivo XML";
            this._btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnFirmar
            // 
            this.btnFirmar.ForeColor = System.Drawing.Color.White;
            this.btnFirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnFirmar.Image")));
            this.btnFirmar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFirmar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirmar.Name = "btnFirmar";
            this.btnFirmar.Size = new System.Drawing.Size(45, 55);
            this.btnFirmar.Text = "Firmar";
            this.btnFirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFirmar.ToolTipText = "Firmar electrónicamente el comprobante";
            // 
            // _btnAutorizar
            // 
            this._btnAutorizar.ForeColor = System.Drawing.Color.White;
            this._btnAutorizar.Image = ((System.Drawing.Image)(resources.GetObject("_btnAutorizar.Image")));
            this._btnAutorizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAutorizar.Name = "_btnAutorizar";
            this._btnAutorizar.Size = new System.Drawing.Size(59, 55);
            this._btnAutorizar.Text = "Autorizar";
            this._btnAutorizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnAutorizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnAutorizar.ToolTipText = "Enviar el comprobante al SRI para autorización";
            this._btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
            // 
            // _btnCorreoXml
            // 
            this._btnCorreoXml.ForeColor = System.Drawing.Color.White;
            this._btnCorreoXml.Image = ((System.Drawing.Image)(resources.GetObject("_btnCorreoXml.Image")));
            this._btnCorreoXml.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnCorreoXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCorreoXml.Name = "_btnCorreoXml";
            this._btnCorreoXml.Size = new System.Drawing.Size(79, 55);
            this._btnCorreoXml.Text = "EnviarCorreo";
            this._btnCorreoXml.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnCorreoXml.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnCorreoXml.ToolTipText = "Enviar el comprobante XML al Cliente";
            this._btnCorreoXml.Click += new System.EventHandler(this.btnCorreoXml_Click);
            // 
            // _btnEnviar
            // 
            this._btnEnviar.ForeColor = System.Drawing.Color.White;
            this._btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("_btnEnviar.Image")));
            this._btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnEnviar.Name = "_btnEnviar";
            this._btnEnviar.Size = new System.Drawing.Size(51, 55);
            this._btnEnviar.Text = "Imagen";
            this._btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnEnviar.ToolTipText = "Enviar o imprimir la imagen de Comprobante";
            this._btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // _ToolStrip5
            // 
            this._ToolStrip5.BackColor = System.Drawing.Color.Transparent;
            this._ToolStrip5.CanOverflow = false;
            this._ToolStrip5.Dock = System.Windows.Forms.DockStyle.Left;
            this._ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._ToolStrip5.ImageScalingSize = new System.Drawing.Size(32, 32);
            this._ToolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnGenerarGrupo,
            this._btn,
            this.ToolStripSeparator3});
            this._ToolStrip5.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this._ToolStrip5.Location = new System.Drawing.Point(0, 0);
            this._ToolStrip5.Name = "_ToolStrip5";
            this._ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this._ToolStrip5.Size = new System.Drawing.Size(55, 58);
            this._ToolStrip5.TabIndex = 3;
            this._ToolStrip5.Text = "ToolStrip5";
            this._ToolStrip5.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip5_ItemClicked);
            // 
            // _btnGenerarGrupo
            // 
            this._btnGenerarGrupo.ForeColor = System.Drawing.Color.White;
            this._btnGenerarGrupo.Image = ((System.Drawing.Image)(resources.GetObject("_btnGenerarGrupo.Image")));
            this._btnGenerarGrupo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnGenerarGrupo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnGenerarGrupo.Name = "_btnGenerarGrupo";
            this._btnGenerarGrupo.Size = new System.Drawing.Size(46, 55);
            this._btnGenerarGrupo.Text = "Grupal";
            this._btnGenerarGrupo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnGenerarGrupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnGenerarGrupo.ToolTipText = "Enviar documentos escojidos en grupo";
            this._btnGenerarGrupo.Click += new System.EventHandler(this.btnGenerarGrupo_Click);
            // 
            // _btn
            // 
            this._btn.ForeColor = System.Drawing.Color.White;
            this._btn.Image = ((System.Drawing.Image)(resources.GetObject("_btn.Image")));
            this._btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btn.Name = "_btn";
            this._btn.Size = new System.Drawing.Size(75, 55);
            this._btn.Text = "Contigencia";
            this._btn.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this._btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btn.ToolTipText = "Manejo claves de contingencia";
            this._btn.Visible = false;
            this._btn.Click += new System.EventHandler(this.btnContingencia_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 58);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.Label1.Location = new System.Drawing.Point(41, 98);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 13);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Comprobante: ";
            // 
            // LabTipo
            // 
            this.LabTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabTipo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTipo.Location = new System.Drawing.Point(141, 94);
            this.LabTipo.Name = "LabTipo";
            this.LabTipo.Size = new System.Drawing.Size(47, 17);
            this.LabTipo.TabIndex = 8;
            // 
            // LabId
            // 
            this.LabId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabId.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabId.Location = new System.Drawing.Point(194, 94);
            this.LabId.Name = "LabId";
            this.LabId.Size = new System.Drawing.Size(66, 17);
            this.LabId.TabIndex = 9;
            // 
            // LabNumero
            // 
            this.LabNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabNumero.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabNumero.Location = new System.Drawing.Point(266, 94);
            this.LabNumero.Name = "LabNumero";
            this.LabNumero.Size = new System.Drawing.Size(110, 17);
            this.LabNumero.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.Label4.Location = new System.Drawing.Point(41, 124);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(116, 13);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Cliente/Proveedor:";
            // 
            // LabCiRuc
            // 
            this.LabCiRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabCiRuc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabCiRuc.Location = new System.Drawing.Point(163, 120);
            this.LabCiRuc.Name = "LabCiRuc";
            this.LabCiRuc.Size = new System.Drawing.Size(148, 17);
            this.LabCiRuc.TabIndex = 12;
            // 
            // LabNombre
            // 
            this.LabNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabNombre.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabNombre.Location = new System.Drawing.Point(317, 121);
            this.LabNombre.Name = "LabNombre";
            this.LabNombre.Size = new System.Drawing.Size(419, 17);
            this.LabNombre.TabIndex = 13;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.Label7.Location = new System.Drawing.Point(41, 151);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(124, 13);
            this.Label7.TabIndex = 14;
            this.Label7.Text = "Clave comprobante:";
            // 
            // LabClave
            // 
            this.LabClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabClave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabClave.Location = new System.Drawing.Point(171, 151);
            this.LabClave.Name = "LabClave";
            this.LabClave.Size = new System.Drawing.Size(419, 17);
            this.LabClave.TabIndex = 15;
            // 
            // LabEstado
            // 
            this.LabEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabEstado.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabEstado.Location = new System.Drawing.Point(98, 179);
            this.LabEstado.Name = "LabEstado";
            this.LabEstado.Size = new System.Drawing.Size(105, 17);
            this.LabEstado.TabIndex = 17;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.Label10.Location = new System.Drawing.Point(41, 183);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(50, 13);
            this.Label10.TabIndex = 16;
            this.Label10.Text = "Estado:";
            // 
            // LabFechaAutoriza
            // 
            this.LabFechaAutoriza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabFechaAutoriza.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabFechaAutoriza.Location = new System.Drawing.Point(129, 209);
            this.LabFechaAutoriza.Name = "LabFechaAutoriza";
            this.LabFechaAutoriza.Size = new System.Drawing.Size(157, 17);
            this.LabFechaAutoriza.TabIndex = 19;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.Label12.Location = new System.Drawing.Point(41, 213);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(82, 13);
            this.Label12.TabIndex = 18;
            this.Label12.Text = "Autorización:";
            // 
            // LabNumeroAutoriza
            // 
            this.LabNumeroAutoriza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabNumeroAutoriza.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabNumeroAutoriza.Location = new System.Drawing.Point(292, 209);
            this.LabNumeroAutoriza.Name = "LabNumeroAutoriza";
            this.LabNumeroAutoriza.Size = new System.Drawing.Size(481, 17);
            this.LabNumeroAutoriza.TabIndex = 20;
            // 
            // mensaje
            // 
            this.mensaje.BackColor = System.Drawing.Color.White;
            this.mensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mensaje.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mensaje.Location = new System.Drawing.Point(0, 240);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(814, 201);
            this.mensaje.TabIndex = 21;
            // 
            // chkOnLine
            // 
            this.chkOnLine.AutoSize = true;
            this.chkOnLine.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnLine.Location = new System.Drawing.Point(635, 64);
            this.chkOnLine.Name = "chkOnLine";
            this.chkOnLine.Size = new System.Drawing.Size(149, 20);
            this.chkOnLine.TabIndex = 22;
            this.chkOnLine.Text = "Emisión en Linea";
            this.chkOnLine.UseVisualStyleBackColor = true;
            this.chkOnLine.Visible = false;
            this.chkOnLine.CheckedChanged += new System.EventHandler(this.chkCotingencia_CheckedChanged);
            // 
            // frmMntDocElectrncos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(814, 441);
            this.Controls.Add(this.chkOnLine);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.LabNumeroAutoriza);
            this.Controls.Add(this.LabFechaAutoriza);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.LabEstado);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.LabClave);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.LabNombre);
            this.Controls.Add(this.LabCiRuc);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.LabNumero);
            this.Controls.Add(this.LabId);
            this.Controls.Add(this.LabTipo);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMntDocElectrncos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCOMDAX - Gestión de documentos electrónicos versión OFFLINE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ToolStripContainer4.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer4.ContentPanel.PerformLayout();
            this.ToolStripContainer4.ResumeLayout(false);
            this.ToolStripContainer4.PerformLayout();
            this.ToolStrip12.ResumeLayout(false);
            this.ToolStrip12.PerformLayout();
            this.ToolStrip4.ResumeLayout(false);
            this.ToolStrip4.PerformLayout();
            this._ToolStrip5.ResumeLayout(false);
            this._ToolStrip5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panel2;
        internal ToolStripContainer ToolStripContainer4;
        internal ToolStrip ToolStrip12;
        internal ToolStripSeparator ToolStripSeparator7;
        private ToolStripButton _btnSalir;

        internal ToolStripButton btnSalir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSalir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSalir != null)
                {
                    _btnSalir.Click -= btnSalir_Click;
                }

                _btnSalir = value;
                if (_btnSalir != null)
                {
                    _btnSalir.Click += btnSalir_Click;
                }
            }
        }

        internal ToolStrip ToolStrip7;
        internal ToolStrip ToolStrip4;
        internal ToolStripButton btnFirmar;
        private ToolStripButton _btnAutorizar;

        internal ToolStripButton btnAutorizar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAutorizar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAutorizar != null)
                {
                    _btnAutorizar.Click -= btnAutorizar_Click;
                }

                _btnAutorizar = value;
                if (_btnAutorizar != null)
                {
                    _btnAutorizar.Click += btnAutorizar_Click;
                }
            }
        }

        private ToolStripButton _btnCorreoXml;

        internal ToolStripButton btnCorreoXml
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCorreoXml;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCorreoXml != null)
                {
                    _btnCorreoXml.Click -= btnCorreoXml_Click;
                }

                _btnCorreoXml = value;
                if (_btnCorreoXml != null)
                {
                    _btnCorreoXml.Click += btnCorreoXml_Click;
                }
            }
        }

        private ToolStrip _ToolStrip5;

        internal ToolStrip ToolStrip5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStrip5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStrip5 != null)
                {
                    _ToolStrip5.ItemClicked -= ToolStrip5_ItemClicked;
                }

                _ToolStrip5 = value;
                if (_ToolStrip5 != null)
                {
                    _ToolStrip5.ItemClicked += ToolStrip5_ItemClicked;
                }
            }
        }

        private ToolStripButton _btn;

        internal ToolStripButton btn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btn != null)
                {
                    _btn.Click -= btnContingencia_Click;
                }

                _btn = value;
                if (_btn != null)
                {
                    _btn.Click += btnContingencia_Click;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator3;
        private ToolStripButton _btnEnviar;

        internal ToolStripButton btnEnviar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEnviar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEnviar != null)
                {
                    _btnEnviar.Click -= btnEnviar_Click;
                }

                _btnEnviar = value;
                if (_btnEnviar != null)
                {
                    _btnEnviar.Click += btnEnviar_Click;
                }
            }
        }

        private ToolStripButton _btnGenerar;

        internal ToolStripButton btnGenerar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenerar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerar != null)
                {
                    _btnGenerar.Click -= btnGenerar_Click;
                }

                _btnGenerar = value;
                if (_btnGenerar != null)
                {
                    _btnGenerar.Click += btnGenerar_Click;
                }
            }
        }

        internal Label Label1;
        internal Label LabTipo;
        internal Label LabId;
        internal Label LabNumero;
        internal Label Label4;
        internal Label LabCiRuc;
        internal Label LabNombre;
        internal Label Label7;
        internal Label LabClave;
        internal Label LabEstado;
        internal Label Label10;
        internal Label LabFechaAutoriza;
        internal Label Label12;
        internal Label LabNumeroAutoriza;
        internal Label mensaje;
        private CheckBox chkOnLine;

        internal CheckBox chkOnLine
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return chkOnLine;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (chkOnLine != null)
                {
                    chkOnLine.CheckedChanged -= chkCotingencia_CheckedChanged;
                }

                chkOnLine = value;
                if (chkOnLine != null)
                {
                    chkOnLine.CheckedChanged += chkCotingencia_CheckedChanged;
                }
            }
        }

        private ToolStripButton _btnGenerarGrupo;

        internal ToolStripButton btnGenerarGrupo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnGenerarGrupo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnGenerarGrupo != null)
                {
                    _btnGenerarGrupo.Click -= btnGenerarGrupo_Click;
                }

                _btnGenerarGrupo = value;
                if (_btnGenerarGrupo != null)
                {
                    _btnGenerarGrupo.Click += btnGenerarGrupo_Click;
                }
            }
        }

        internal ToolStripButton btnAbre;
    }
}