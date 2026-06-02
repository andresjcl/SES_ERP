namespace DaxBan
{
    partial class CtasBanForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buscarbutton = new System.Windows.Forms.Button();
            this.numeroCuentatextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctatextBox = new System.Windows.Forms.TextBox();
            this.abrevtextBox = new System.Windows.Forms.TextBox();
            this.Ctalabel = new System.Windows.Forms.Label();
            this.abrevlabel = new System.Windows.Forms.Label();
            this.corrienteradioButton = new System.Windows.Forms.RadioButton();
            this.ahorroradioButton = new System.Windows.Forms.RadioButton();
            this.inversiradioButton = new System.Windows.Forms.RadioButton();
            this.tipoCtagroupBox = new System.Windows.Forms.GroupBox();
            this.bancocomboBox = new System.Windows.Forms.ComboBox();
            this.bancolabel = new System.Windows.Forms.Label();
            this.nuevotoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abrirtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.guardartoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cancelartoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.eliminartoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.imprimirtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.menutoolStrip = new System.Windows.Forms.ToolStrip();
            this.tipoCtagroupBox.SuspendLayout();
            this.menutoolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buscarbutton
            // 
            this.buscarbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarbutton.BackColor = System.Drawing.Color.Transparent;
            this.buscarbutton.FlatAppearance.BorderSize = 0;
            this.buscarbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscarbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarbutton.ForeColor = System.Drawing.Color.White;
            this.buscarbutton.Location = new System.Drawing.Point(117, 158);
            this.buscarbutton.Name = "buscarbutton";
            this.buscarbutton.Size = new System.Drawing.Size(20, 20);
            this.buscarbutton.TabIndex = 46;
            this.buscarbutton.UseVisualStyleBackColor = false;
            this.buscarbutton.Click += new System.EventHandler(this.buscarCtaContable_Click);
            // 
            // numeroCuentatextBox
            // 
            this.numeroCuentatextBox.Location = new System.Drawing.Point(273, 122);
            this.numeroCuentatextBox.Name = "numeroCuentatextBox";
            this.numeroCuentatextBox.ReadOnly = true;
            this.numeroCuentatextBox.Size = new System.Drawing.Size(100, 20);
            this.numeroCuentatextBox.TabIndex = 10;
            this.numeroCuentatextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroCuentatextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nº de Cuenta bancaria:";
            // 
            // ctatextBox
            // 
            this.ctatextBox.Location = new System.Drawing.Point(140, 158);
            this.ctatextBox.Name = "ctatextBox";
            this.ctatextBox.ReadOnly = true;
            this.ctatextBox.Size = new System.Drawing.Size(105, 20);
            this.ctatextBox.TabIndex = 7;
            // 
            // abrevtextBox
            // 
            this.abrevtextBox.Location = new System.Drawing.Point(99, 122);
            this.abrevtextBox.Name = "abrevtextBox";
            this.abrevtextBox.ReadOnly = true;
            this.abrevtextBox.Size = new System.Drawing.Size(38, 20);
            this.abrevtextBox.TabIndex = 6;
            this.abrevtextBox.Validating += new System.ComponentModel.CancelEventHandler(this.abrevtextBox_Validating);
            // 
            // Ctalabel
            // 
            this.Ctalabel.AutoSize = true;
            this.Ctalabel.Location = new System.Drawing.Point(27, 165);
            this.Ctalabel.Name = "Ctalabel";
            this.Ctalabel.Size = new System.Drawing.Size(88, 13);
            this.Ctalabel.TabIndex = 5;
            this.Ctalabel.Text = "Cuenta contable:";
            // 
            // abrevlabel
            // 
            this.abrevlabel.AutoSize = true;
            this.abrevlabel.Location = new System.Drawing.Point(27, 129);
            this.abrevlabel.Name = "abrevlabel";
            this.abrevlabel.Size = new System.Drawing.Size(66, 13);
            this.abrevlabel.TabIndex = 4;
            this.abrevlabel.Text = "Abreviación:";
            this.abrevlabel.Click += new System.EventHandler(this.abrevlabel_Click);
            // 
            // corrienteradioButton
            // 
            this.corrienteradioButton.AutoSize = true;
            this.corrienteradioButton.Checked = true;
            this.corrienteradioButton.Location = new System.Drawing.Point(25, 21);
            this.corrienteradioButton.Name = "corrienteradioButton";
            this.corrienteradioButton.Size = new System.Drawing.Size(67, 17);
            this.corrienteradioButton.TabIndex = 0;
            this.corrienteradioButton.TabStop = true;
            this.corrienteradioButton.Text = "Corriente";
            this.corrienteradioButton.UseVisualStyleBackColor = true;
            // 
            // ahorroradioButton
            // 
            this.ahorroradioButton.AutoSize = true;
            this.ahorroradioButton.Location = new System.Drawing.Point(153, 19);
            this.ahorroradioButton.Name = "ahorroradioButton";
            this.ahorroradioButton.Size = new System.Drawing.Size(56, 17);
            this.ahorroradioButton.TabIndex = 1;
            this.ahorroradioButton.Text = "Ahorro";
            this.ahorroradioButton.UseVisualStyleBackColor = true;
            // 
            // inversiradioButton
            // 
            this.inversiradioButton.AutoSize = true;
            this.inversiradioButton.Location = new System.Drawing.Point(276, 19);
            this.inversiradioButton.Name = "inversiradioButton";
            this.inversiradioButton.Size = new System.Drawing.Size(50, 17);
            this.inversiradioButton.TabIndex = 2;
            this.inversiradioButton.Text = "Otros";
            this.inversiradioButton.UseVisualStyleBackColor = true;
            // 
            // tipoCtagroupBox
            // 
            this.tipoCtagroupBox.Controls.Add(this.inversiradioButton);
            this.tipoCtagroupBox.Controls.Add(this.ahorroradioButton);
            this.tipoCtagroupBox.Controls.Add(this.corrienteradioButton);
            this.tipoCtagroupBox.Enabled = false;
            this.tipoCtagroupBox.Location = new System.Drawing.Point(30, 210);
            this.tipoCtagroupBox.Name = "tipoCtagroupBox";
            this.tipoCtagroupBox.Size = new System.Drawing.Size(385, 53);
            this.tipoCtagroupBox.TabIndex = 3;
            this.tipoCtagroupBox.TabStop = false;
            this.tipoCtagroupBox.Text = "Tipo de Cuenta";
            // 
            // bancocomboBox
            // 
            this.bancocomboBox.FormattingEnabled = true;
            this.bancocomboBox.Location = new System.Drawing.Point(87, 84);
            this.bancocomboBox.Name = "bancocomboBox";
            this.bancocomboBox.Size = new System.Drawing.Size(269, 21);
            this.bancocomboBox.TabIndex = 2;
            this.bancocomboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bancocomboBox_KeyPress);
            // 
            // bancolabel
            // 
            this.bancolabel.AutoSize = true;
            this.bancolabel.Location = new System.Drawing.Point(27, 92);
            this.bancolabel.Name = "bancolabel";
            this.bancolabel.Size = new System.Drawing.Size(41, 13);
            this.bancolabel.TabIndex = 1;
            this.bancolabel.Text = "Banco:";
            // 
            // nuevotoolStripButton
            // 
            this.nuevotoolStripButton.ForeColor = System.Drawing.Color.White;
            this.nuevotoolStripButton.Image = global::DaxBan.Properties.Resources.nuevo2;
            this.nuevotoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevotoolStripButton.Name = "nuevotoolStripButton";
            this.nuevotoolStripButton.Size = new System.Drawing.Size(46, 50);
            this.nuevotoolStripButton.Text = "Nuevo";
            this.nuevotoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.nuevotoolStripButton.Click += new System.EventHandler(this.nuevotoolStripButton_Click);
            // 
            // abrirtoolStripButton
            // 
            this.abrirtoolStripButton.ForeColor = System.Drawing.Color.White;
            this.abrirtoolStripButton.Image = global::DaxBan.Properties.Resources.Abrir_16;
            this.abrirtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirtoolStripButton.Name = "abrirtoolStripButton";
            this.abrirtoolStripButton.Size = new System.Drawing.Size(33, 50);
            this.abrirtoolStripButton.Text = "Abir";
            this.abrirtoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.abrirtoolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // guardartoolStripButton
            // 
            this.guardartoolStripButton.ForeColor = System.Drawing.Color.White;
            this.guardartoolStripButton.Image = global::DaxBan.Properties.Resources.Grabar_16;
            this.guardartoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardartoolStripButton.Name = "guardartoolStripButton";
            this.guardartoolStripButton.Size = new System.Drawing.Size(53, 50);
            this.guardartoolStripButton.Text = "Guardar";
            this.guardartoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.guardartoolStripButton.Click += new System.EventHandler(this.guardartoolStripButton_Click);
            // 
            // cancelartoolStripButton
            // 
            this.cancelartoolStripButton.ForeColor = System.Drawing.Color.White;
            this.cancelartoolStripButton.Image = global::DaxBan.Properties.Resources.Cancelar;
            this.cancelartoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelartoolStripButton.Name = "cancelartoolStripButton";
            this.cancelartoolStripButton.Size = new System.Drawing.Size(57, 50);
            this.cancelartoolStripButton.Text = "Cancelar";
            this.cancelartoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cancelartoolStripButton.Click += new System.EventHandler(this.cancelartoolStripButton_Click);
            // 
            // eliminartoolStripButton
            // 
            this.eliminartoolStripButton.ForeColor = System.Drawing.Color.White;
            this.eliminartoolStripButton.Image = global::DaxBan.Properties.Resources.Eliminar_16;
            this.eliminartoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eliminartoolStripButton.Name = "eliminartoolStripButton";
            this.eliminartoolStripButton.Size = new System.Drawing.Size(54, 50);
            this.eliminartoolStripButton.Text = "Eliminar";
            this.eliminartoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.eliminartoolStripButton.Click += new System.EventHandler(this.eliminartoolStripButton_Click);
            // 
            // imprimirtoolStripButton
            // 
            this.imprimirtoolStripButton.ForeColor = System.Drawing.Color.White;
            this.imprimirtoolStripButton.Image = global::DaxBan.Properties.Resources.Imprimir;
            this.imprimirtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimirtoolStripButton.Name = "imprimirtoolStripButton";
            this.imprimirtoolStripButton.Size = new System.Drawing.Size(57, 50);
            this.imprimirtoolStripButton.Text = "Imprimir";
            this.imprimirtoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imprimirtoolStripButton.Click += new System.EventHandler(this.imprimirtoolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // salirtoolStripButton
            // 
            this.salirtoolStripButton.ForeColor = System.Drawing.Color.White;
            this.salirtoolStripButton.Image = global::DaxBan.Properties.Resources.EXit;
            this.salirtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salirtoolStripButton.Name = "salirtoolStripButton";
            this.salirtoolStripButton.Size = new System.Drawing.Size(33, 50);
            this.salirtoolStripButton.Text = "Salir";
            this.salirtoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.salirtoolStripButton.Click += new System.EventHandler(this.salirtoolStripButton_Click);
            // 
            // menutoolStrip
            // 
            this.menutoolStrip.AutoSize = false;
            this.menutoolStrip.BackColor = System.Drawing.Color.SteelBlue;
            this.menutoolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menutoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevotoolStripButton,
            this.abrirtoolStripButton,
            this.guardartoolStripButton,
            this.cancelartoolStripButton,
            this.eliminartoolStripButton,
            this.imprimirtoolStripButton,
            this.toolStripSeparator1,
            this.salirtoolStripButton});
            this.menutoolStrip.Location = new System.Drawing.Point(0, 0);
            this.menutoolStrip.Name = "menutoolStrip";
            this.menutoolStrip.Size = new System.Drawing.Size(454, 53);
            this.menutoolStrip.TabIndex = 0;
            this.menutoolStrip.Text = "toolStrip1";
            // 
            // CtasBanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(454, 281);
            this.ControlBox = false;
            this.Controls.Add(this.buscarbutton);
            this.Controls.Add(this.numeroCuentatextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctatextBox);
            this.Controls.Add(this.abrevtextBox);
            this.Controls.Add(this.Ctalabel);
            this.Controls.Add(this.abrevlabel);
            this.Controls.Add(this.tipoCtagroupBox);
            this.Controls.Add(this.bancocomboBox);
            this.Controls.Add(this.bancolabel);
            this.Controls.Add(this.menutoolStrip);
            this.Name = "CtasBanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definición de Cuentas Bancarias";
            this.Load += new System.EventHandler(this.CtasBanForm_Load);
            this.tipoCtagroupBox.ResumeLayout(false);
            this.tipoCtagroupBox.PerformLayout();
            this.menutoolStrip.ResumeLayout(false);
            this.menutoolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscarbutton;
        private System.Windows.Forms.TextBox numeroCuentatextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ctatextBox;
        private System.Windows.Forms.TextBox abrevtextBox;
        private System.Windows.Forms.Label Ctalabel;
        private System.Windows.Forms.Label abrevlabel;
        private System.Windows.Forms.RadioButton corrienteradioButton;
        private System.Windows.Forms.RadioButton ahorroradioButton;
        private System.Windows.Forms.RadioButton inversiradioButton;
        private System.Windows.Forms.GroupBox tipoCtagroupBox;
        private System.Windows.Forms.ComboBox bancocomboBox;
        private System.Windows.Forms.Label bancolabel;
        private System.Windows.Forms.ToolStripButton nuevotoolStripButton;
        private System.Windows.Forms.ToolStripButton abrirtoolStripButton;
        private System.Windows.Forms.ToolStripButton guardartoolStripButton;
        private System.Windows.Forms.ToolStripButton cancelartoolStripButton;
        private System.Windows.Forms.ToolStripButton eliminartoolStripButton;
        private System.Windows.Forms.ToolStripButton imprimirtoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton salirtoolStripButton;
        private System.Windows.Forms.ToolStrip menutoolStrip;
    }
}

