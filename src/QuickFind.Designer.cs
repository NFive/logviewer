namespace NFive.LogViewer
{
	partial class QuickFind
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.checkBoxRegex = new System.Windows.Forms.CheckBox();
            this.checkBoxWholeWord = new System.Windows.Forms.CheckBox();
            this.labelMatches = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFind.Location = new System.Drawing.Point(5, 5);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(210, 23);
            this.textBoxFind.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxFind, "Search term");
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            this.textBoxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFind_KeyDown);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(221, 32);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(24, 24);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "🠟";
            this.toolTip.SetToolTip(this.buttonNext, "Find next");
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(221, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.buttonClose.Size = new System.Drawing.Size(24, 24);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "🗙";
            this.toolTip.SetToolTip(this.buttonClose, "Close");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.Location = new System.Drawing.Point(195, 32);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(24, 24);
            this.buttonPrevious.TabIndex = 4;
            this.buttonPrevious.Text = "🠝";
            this.toolTip.SetToolTip(this.buttonPrevious, "Find previous");
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCase.Location = new System.Drawing.Point(5, 32);
            this.checkBoxCase.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(34, 24);
            this.checkBoxCase.TabIndex = 8;
            this.checkBoxCase.Text = "Aa";
            this.checkBoxCase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxCase, "Match case");
            this.checkBoxCase.UseVisualStyleBackColor = true;
            this.checkBoxCase.CheckedChanged += new System.EventHandler(this.checkBoxCase_CheckedChanged);
            // 
            // checkBoxRegex
            // 
            this.checkBoxRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxRegex.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRegex.Location = new System.Drawing.Point(77, 32);
            this.checkBoxRegex.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.checkBoxRegex.Name = "checkBoxRegex";
            this.checkBoxRegex.Size = new System.Drawing.Size(34, 24);
            this.checkBoxRegex.TabIndex = 9;
            this.checkBoxRegex.Text = "·*";
            this.checkBoxRegex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxRegex, "Use Regular Expressions");
            this.checkBoxRegex.UseVisualStyleBackColor = true;
            this.checkBoxRegex.CheckedChanged += new System.EventHandler(this.checkBoxRegex_CheckedChanged);
            // 
            // checkBoxWholeWord
            // 
            this.checkBoxWholeWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxWholeWord.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxWholeWord.Location = new System.Drawing.Point(41, 32);
            this.checkBoxWholeWord.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.checkBoxWholeWord.Name = "checkBoxWholeWord";
            this.checkBoxWholeWord.Size = new System.Drawing.Size(34, 24);
            this.checkBoxWholeWord.TabIndex = 10;
            this.checkBoxWholeWord.Text = "[Aa]";
            this.checkBoxWholeWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.checkBoxWholeWord, "Match whole word");
            this.checkBoxWholeWord.UseVisualStyleBackColor = true;
            this.checkBoxWholeWord.CheckedChanged += new System.EventHandler(this.checkBoxWholeWord_CheckedChanged);
            // 
            // labelMatches
            // 
            this.labelMatches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMatches.AutoEllipsis = true;
            this.labelMatches.Location = new System.Drawing.Point(114, 32);
            this.labelMatches.Name = "labelMatches";
            this.labelMatches.Size = new System.Drawing.Size(75, 24);
            this.labelMatches.TabIndex = 11;
            this.labelMatches.Text = "No results";
            this.labelMatches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuickFind
            // 
            this.Controls.Add(this.labelMatches);
            this.Controls.Add(this.checkBoxWholeWord);
            this.Controls.Add(this.checkBoxRegex);
            this.Controls.Add(this.checkBoxCase);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.textBoxFind);
            this.Name = "QuickFind";
            this.Size = new System.Drawing.Size(250, 60);
            this.VisibleChanged += new System.EventHandler(this.QuickFind_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBoxFind;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonPrevious;
		private System.Windows.Forms.CheckBox checkBoxCase;
		private System.Windows.Forms.CheckBox checkBoxRegex;
		private System.Windows.Forms.CheckBox checkBoxWholeWord;
		private System.Windows.Forms.Label labelMatches;
		private System.Windows.Forms.ToolTip toolTip;
	}
}
