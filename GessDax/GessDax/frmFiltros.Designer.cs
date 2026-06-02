namespace GessDax
{
    partial class frmFiltros
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
        private void InitializeComponent()
        {
            this.btnIgual = new System.Windows.Forms.RadioButton();
            this.btnMenor = new System.Windows.Forms.RadioButton();
            this.btnMayor = new System.Windows.Forms.RadioButton();
            this.btnDiferente = new System.Windows.Forms.RadioButton();
            this.ValorFiltro = new System.Windows.Forms.TextBox();
            this.Aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.btnParecido = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnIgual
            // 
            this.btnIgual.AutoSize = true;
            this.btnIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgual.Location = new System.Drawing.Point(12, 12);
            this.btnIgual.Name = "btnIgual";
            this.btnIgual.Size = new System.Drawing.Size(69, 20);
            this.btnIgual.TabIndex = 0;
            this.btnIgual.TabStop = true;
            this.btnIgual.Text = "Igual a:";
            this.btnIgual.UseVisualStyleBackColor = true;
            // 
            // btnMenor
            // 
            this.btnMenor.AutoSize = true;
            this.btnMenor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenor.Location = new System.Drawing.Point(292, 12);
            this.btnMenor.Name = "btnMenor";
            this.btnMenor.Size = new System.Drawing.Size(78, 20);
            this.btnMenor.TabIndex = 1;
            this.btnMenor.TabStop = true;
            this.btnMenor.Text = "Menor a:";
            this.btnMenor.UseVisualStyleBackColor = true;
            // 
            // btnMayor
            // 
            this.btnMayor.AutoSize = true;
            this.btnMayor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMayor.Location = new System.Drawing.Point(190, 12);
            this.btnMayor.Name = "btnMayor";
            this.btnMayor.Size = new System.Drawing.Size(78, 20);
            this.btnMayor.TabIndex = 2;
            this.btnMayor.TabStop = true;
            this.btnMayor.Text = "Mayor a:";
            this.btnMayor.UseVisualStyleBackColor = true;
            // 
            // btnDiferente
            // 
            this.btnDiferente.AutoSize = true;
            this.btnDiferente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiferente.Location = new System.Drawing.Point(87, 12);
            this.btnDiferente.Name = "btnDiferente";
            this.btnDiferente.Size = new System.Drawing.Size(94, 20);
            this.btnDiferente.TabIndex = 3;
            this.btnDiferente.TabStop = true;
            this.btnDiferente.Text = "Diferente a:";
            this.btnDiferente.UseVisualStyleBackColor = true;
            // 
            // ValorFiltro
            // 
            this.ValorFiltro.Location = new System.Drawing.Point(12, 69);
            this.ValorFiltro.Name = "ValorFiltro";
            this.ValorFiltro.Size = new System.Drawing.Size(368, 20);
            this.ValorFiltro.TabIndex = 4;
            // 
            // Aceptar
            // 
            this.Aceptar.BackColor = System.Drawing.Color.SteelBlue;
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar.ForeColor = System.Drawing.Color.White;
            this.Aceptar.Location = new System.Drawing.Point(292, 112);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(90, 21);
            this.Aceptar.TabIndex = 5;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cancelar.BackColor = System.Drawing.Color.SteelBlue;
            this.cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar.ForeColor = System.Drawing.Color.White;
            this.cancelar.Location = new System.Drawing.Point(190, 112);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(90, 21);
            this.cancelar.TabIndex = 6;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // btnParecido
            // 
            this.btnParecido.AutoSize = true;
            this.btnParecido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParecido.Location = new System.Drawing.Point(12, 38);
            this.btnParecido.Name = "btnParecido";
            this.btnParecido.Size = new System.Drawing.Size(95, 20);
            this.btnParecido.TabIndex = 7;
            this.btnParecido.TabStop = true;
            this.btnParecido.Text = "Parecido a:";
            this.btnParecido.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(392, 141);
            this.ControlBox = false;
            this.Controls.Add(this.btnParecido);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.ValorFiltro);
            this.Controls.Add(this.btnDiferente);
            this.Controls.Add(this.btnMayor);
            this.Controls.Add(this.btnMenor);
            this.Controls.Add(this.btnIgual);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingrese valor de filtrado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton btnIgual;
        private System.Windows.Forms.RadioButton btnMenor;
        private System.Windows.Forms.RadioButton btnMayor;
        private System.Windows.Forms.RadioButton btnDiferente;
        private System.Windows.Forms.TextBox ValorFiltro;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.RadioButton btnParecido;
    }
}