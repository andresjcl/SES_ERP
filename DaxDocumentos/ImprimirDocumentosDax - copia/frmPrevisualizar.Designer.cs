
namespace ImpresionDoc
{
	partial class frmPrevisualizar
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
			this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
			this.VisorDeReportes = new Microsoft.Reporting.WinForms.ReportViewer();
			this.SuspendLayout();
			// 
			// VisorDeReportes
			// 
			this.VisorDeReportes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VisorDeReportes.Location = new System.Drawing.Point(0, 0);
			this.VisorDeReportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.VisorDeReportes.Name = "VisorDeReportes";
			//this.VisorDeReportes.ServerReport.BearerToken = null;
			this.VisorDeReportes.Size = new System.Drawing.Size(1156, 749);
			this.VisorDeReportes.TabIndex = 1;
			// 
			// frmPrevisualizar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1156, 749);
			this.Controls.Add(this.VisorDeReportes);
			this.Name = "frmPrevisualizar";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Previsualizar";
			this.ResumeLayout(false);

		}

		#endregion

		private System.DirectoryServices.DirectoryEntry directoryEntry1;
		public Microsoft.Reporting.WinForms.ReportViewer VisorDeReportes;
	}
}