namespace DaxBan
{
    partial class ImpForm
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
            this.mostrarreportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mostrarreportViewer
            // 
            this.mostrarreportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mostrarreportViewer.Location = new System.Drawing.Point(0, 0);
            this.mostrarreportViewer.Name = "mostrarreportViewer";
            this.mostrarreportViewer.Size = new System.Drawing.Size(645, 402);
            this.mostrarreportViewer.TabIndex = 0;
            // 
            // ImpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 402);
            this.Controls.Add(this.mostrarreportViewer);
            this.Name = "ImpForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.ImpForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer mostrarreportViewer;
    }
}