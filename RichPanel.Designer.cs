using ScintillaNET;

namespace NFive.LogViewer
{
	partial class RichPanel
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
			this.scintilla = new ScintillaNET.Scintilla();
			this.SuspendLayout();
			// 
			// scintilla1
			// 
			this.scintilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scintilla.Location = new System.Drawing.Point(0, 0);
			this.scintilla.Name = "scintilla";
			this.scintilla.TabIndex = 0;
			// 
			// RichPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.scintilla);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "RichPanel";
			this.Icon = global::NFive.LogViewer.Properties.Resources.icon;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.ResumeLayout(false);

		}

		#endregion

		private ScintillaNET.Scintilla scintilla;
	}
}
