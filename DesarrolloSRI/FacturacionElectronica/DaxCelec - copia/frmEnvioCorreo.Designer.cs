
using System.Windows.Forms;

namespace SesFelec
{
	partial class frmEnvioCorreo
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //          this.txtDestino = new System.Windows.Forms.TextBox();
        //          this.label1 = new System.Windows.Forms.Label();
        //          this.label2 = new System.Windows.Forms.Label();
        //          this.txtConCopia = new System.Windows.Forms.TextBox();
        //          this.label3 = new System.Windows.Forms.Label();
        //          this.txtAsunto = new System.Windows.Forms.TextBox();
        //          this.label4 = new System.Windows.Forms.Label();
        //          this.txtAdjuntos = new System.Windows.Forms.TextBox();
        //          this.txtDetalle = new System.Windows.Forms.TextBox();
        //          this.label5 = new System.Windows.Forms.Label();
        //          this.btnAceptar = new System.Windows.Forms.Button();
        //          this.btnCancelar = new System.Windows.Forms.Button();
        //          this.btnAdjuntar = new System.Windows.Forms.Button();
        //          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        //          this.SuspendLayout();
        //          // 
        //          // txtDestino
        //          // 
        //          this.txtDestino.Location = new System.Drawing.Point(129, 47);
        //          this.txtDestino.Name = "txtDestino";
        //          this.txtDestino.Size = new System.Drawing.Size(388, 20);
        //          this.txtDestino.TabIndex = 0;
        //          // 
        //          // label1
        //          // 
        //          this.label1.AutoSize = true;
        //          this.label1.Location = new System.Drawing.Point(48, 54);
        //          this.label1.Name = "label1";
        //          this.label1.Size = new System.Drawing.Size(75, 13);
        //          this.label1.TabIndex = 1;
        //          this.label1.Text = "Correo destino";
        //          // 
        //          // label2
        //          // 
        //          this.label2.AutoSize = true;
        //          this.label2.Location = new System.Drawing.Point(48, 80);
        //          this.label2.Name = "label2";
        //          this.label2.Size = new System.Drawing.Size(21, 13);
        //          this.label2.TabIndex = 3;
        //          this.label2.Text = "CC";
        //          // 
        //          // txtConCopia
        //          // 
        //          this.txtConCopia.Location = new System.Drawing.Point(129, 73);
        //          this.txtConCopia.Name = "txtConCopia";
        //          this.txtConCopia.Size = new System.Drawing.Size(388, 20);
        //          this.txtConCopia.TabIndex = 2;
        //          // 
        //          // label3
        //          // 
        //          this.label3.AutoSize = true;
        //          this.label3.Location = new System.Drawing.Point(48, 106);
        //          this.label3.Name = "label3";
        //          this.label3.Size = new System.Drawing.Size(40, 13);
        //          this.label3.TabIndex = 5;
        //          this.label3.Text = "Asunto";
        //          // 
        //          // txtAsunto
        //          // 
        //          this.txtAsunto.Location = new System.Drawing.Point(129, 99);
        //          this.txtAsunto.Name = "txtAsunto";
        //          this.txtAsunto.Size = new System.Drawing.Size(388, 20);
        //          this.txtAsunto.TabIndex = 4;
        //          // 
        //          // label4
        //          // 
        //          this.label4.AutoSize = true;
        //          this.label4.Location = new System.Drawing.Point(48, 141);
        //          this.label4.Name = "label4";
        //          this.label4.Size = new System.Drawing.Size(93, 13);
        //          this.label4.TabIndex = 7;
        //          this.label4.Text = "Rutas de archivos";
        //          // 
        //          // txtAdjuntos
        //          // 
        //          this.txtAdjuntos.Location = new System.Drawing.Point(151, 134);
        //          this.txtAdjuntos.Multiline = true;
        //          this.txtAdjuntos.Name = "txtAdjuntos";
        //          this.txtAdjuntos.Size = new System.Drawing.Size(559, 49);
        //          this.txtAdjuntos.TabIndex = 6;
        //          // 
        //          // txtDetalle
        //          // 
        //          this.txtDetalle.Location = new System.Drawing.Point(151, 200);
        //          this.txtDetalle.Multiline = true;
        //          this.txtDetalle.Name = "txtDetalle";
        //          this.txtDetalle.Size = new System.Drawing.Size(559, 99);
        //          this.txtDetalle.TabIndex = 8;
        //          // 
        //          // label5
        //          // 
        //          this.label5.AutoSize = true;
        //          this.label5.Location = new System.Drawing.Point(52, 203);
        //          this.label5.Name = "label5";
        //          this.label5.Size = new System.Drawing.Size(31, 13);
        //          this.label5.TabIndex = 9;
        //          this.label5.Text = "Body";
        //          // 
        //          // btnAceptar
        //          // 
        //          this.btnAceptar.Location = new System.Drawing.Point(96, 332);
        //          this.btnAceptar.Name = "btnAceptar";
        //          this.btnAceptar.Size = new System.Drawing.Size(75, 23);
        //          this.btnAceptar.TabIndex = 10;
        //          this.btnAceptar.Text = "Aceptar";
        //          this.btnAceptar.UseVisualStyleBackColor = true;
        //          this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
        //          // 
        //          // btnCancelar
        //          // 
        //          this.btnCancelar.Location = new System.Drawing.Point(202, 331);
        //          this.btnCancelar.Name = "btnCancelar";
        //          this.btnCancelar.Size = new System.Drawing.Size(75, 23);
        //          this.btnCancelar.TabIndex = 11;
        //          this.btnCancelar.Text = "Cerrar";
        //          this.btnCancelar.UseVisualStyleBackColor = true;
        //          this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        //          // 
        //          // btnAdjuntar
        //          // 
        //          this.btnAdjuntar.Location = new System.Drawing.Point(325, 332);
        //          this.btnAdjuntar.Name = "btnAdjuntar";
        //          this.btnAdjuntar.Size = new System.Drawing.Size(140, 23);
        //          this.btnAdjuntar.TabIndex = 12;
        //          this.btnAdjuntar.Text = "Buscar archivo";
        //          this.btnAdjuntar.UseVisualStyleBackColor = true;
        //          this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
        //          // 
        //          // openFileDialog1
        //          // 
        //          this.openFileDialog1.FileName = "openFileDialog1";
        //          // 
        //          // frmEnvioCorreo
        //          // 
        //          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //          this.ClientSize = new System.Drawing.Size(800, 450);
        //          this.Controls.Add(this.btnAdjuntar);
        //          this.Controls.Add(this.btnCancelar);
        //          this.Controls.Add(this.btnAceptar);
        //          this.Controls.Add(this.label5);
        //          this.Controls.Add(this.txtDetalle);
        //          this.Controls.Add(this.label4);
        //          this.Controls.Add(this.txtAdjuntos);
        //          this.Controls.Add(this.label3);
        //          this.Controls.Add(this.txtAsunto);
        //          this.Controls.Add(this.label2);
        //          this.Controls.Add(this.txtConCopia);
        //          this.Controls.Add(this.label1);
        //          this.Controls.Add(this.txtDestino);
        //          this.Name = "frmEnvioCorreo";
        //          this.Text = "frmEnvioCorreo";
        //          this.ResumeLayout(false);
        //          this.PerformLayout();

        //}

        private void InitializeComponent()
        {
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtConCopia = new System.Windows.Forms.TextBox();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.lstAdjuntos = new System.Windows.Forms.ListView();
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(100, 7);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(692, 20);
            this.txtDestino.TabIndex = 1;
            // 
            // txtConCopia
            // 
            this.txtConCopia.Location = new System.Drawing.Point(100, 31);
            this.txtConCopia.Name = "txtConCopia";
            this.txtConCopia.Size = new System.Drawing.Size(692, 20);
            this.txtConCopia.TabIndex = 3;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(100, 55);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(692, 20);
            this.txtAsunto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "CC:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Asunto:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Adjuntos:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mensaje:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(140, 458);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(170, 35);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Enviar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(371, 458);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 35);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.Location = new System.Drawing.Point(599, 92);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(110, 40);
            this.btnAdjuntar.TabIndex = 8;
            this.btnAdjuntar.Text = "Adjuntar";
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // lstAdjuntos
            // 
            this.lstAdjuntos.HideSelection = false;
            this.lstAdjuntos.Location = new System.Drawing.Point(100, 79);
            this.lstAdjuntos.MultiSelect = false;
            this.lstAdjuntos.Name = "lstAdjuntos";
            this.lstAdjuntos.Size = new System.Drawing.Size(462, 71);
            this.lstAdjuntos.TabIndex = 14;
            this.lstAdjuntos.UseCompatibleStateImageBehavior = false;
            this.lstAdjuntos.DoubleClick += new System.EventHandler(this.lstAdjuntos_DoubleClick);
            // 
            // wbPreview
            // 
            this.wbPreview.Location = new System.Drawing.Point(12, 156);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.Size = new System.Drawing.Size(780, 296);
            this.wbPreview.TabIndex = 15;
            this.wbPreview.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbPreview_DocumentCompleted);
            // 
            // frmEnvioCorreo
            // 
            this.ClientSize = new System.Drawing.Size(804, 505);
            this.Controls.Add(this.wbPreview);
            this.Controls.Add(this.lstAdjuntos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConCopia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEnvioCorreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envío de Comprobante Electrónico";
            this.Load += new System.EventHandler(this.frmEnvioCorreo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDestino;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtConCopia;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAsunto;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAdjuntar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ListView lstAdjuntos;
        private WebBrowser wbPreview;
    }
}