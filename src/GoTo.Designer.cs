namespace NFive.LogViewer
{
	partial class GoTo
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
            this.buttonGoTo = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelLine = new System.Windows.Forms.Label();
            this.numericUpDownLine = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLine)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGoTo
            // 
            this.buttonGoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGoTo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGoTo.Location = new System.Drawing.Point(55, 43);
            this.buttonGoTo.Name = "buttonGoTo";
            this.buttonGoTo.Size = new System.Drawing.Size(75, 23);
            this.buttonGoTo.TabIndex = 2;
            this.buttonGoTo.Text = "&Go To";
            this.buttonGoTo.UseVisualStyleBackColor = true;
            this.buttonGoTo.Click += new System.EventHandler(this.buttonGoTo_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(136, 43);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelLine
            // 
            this.labelLine.AutoSize = true;
            this.labelLine.Location = new System.Drawing.Point(12, 14);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(68, 13);
            this.labelLine.TabIndex = 0;
            this.labelLine.Text = "Line number:";
            // 
            // numericUpDownLine
            // 
            this.numericUpDownLine.Location = new System.Drawing.Point(86, 12);
            this.numericUpDownLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLine.Name = "numericUpDownLine";
            this.numericUpDownLine.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLine.TabIndex = 1;
            this.numericUpDownLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GoTo
            // 
            this.AcceptButton = this.buttonGoTo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(223, 78);
            this.Controls.Add(this.numericUpDownLine);
            this.Controls.Add(this.labelLine);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGoTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoTo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go To Line";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonGoTo;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelLine;
		private System.Windows.Forms.NumericUpDown numericUpDownLine;
	}
}
