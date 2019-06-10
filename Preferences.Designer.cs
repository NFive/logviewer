namespace NFive.LogViewer
{
	partial class Preferences
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkBoxRestoreLastFile = new System.Windows.Forms.CheckBox();
            this.numericUpDownFileHistory = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowWelcomeTab = new System.Windows.Forms.CheckBox();
            this.labelFileHistory = new System.Windows.Forms.Label();
            this.groupBoxGeneral = new System.Windows.Forms.GroupBox();
            this.groupBoxEditor = new System.Windows.Forms.GroupBox();
            this.panelEditorBackgroundColor = new System.Windows.Forms.Panel();
            this.labelEditorBackgroundColor = new System.Windows.Forms.Label();
            this.labelMarginTextColor = new System.Windows.Forms.Label();
            this.panelMarginBackgroundColor = new System.Windows.Forms.Panel();
            this.panelMarginTextColor = new System.Windows.Forms.Panel();
            this.labelMarginBackgroundColor = new System.Windows.Forms.Label();
            this.labelEditorTextColor = new System.Windows.Forms.Label();
            this.panelEditorTextColor = new System.Windows.Forms.Panel();
            this.groupBoxLevels = new System.Windows.Forms.GroupBox();
            this.panelLevelTrace = new System.Windows.Forms.Panel();
            this.labelLevelTrace = new System.Windows.Forms.Label();
            this.labelLevelDebug = new System.Windows.Forms.Label();
            this.panelLevelDebug = new System.Windows.Forms.Panel();
            this.labelLevelInfo = new System.Windows.Forms.Label();
            this.panelLevelInfo = new System.Windows.Forms.Panel();
            this.panelLevelError = new System.Windows.Forms.Panel();
            this.labelLevelWarn = new System.Windows.Forms.Label();
            this.labelLevelError = new System.Windows.Forms.Label();
            this.panelLevelWarn = new System.Windows.Forms.Panel();
            this.groupBoxSyntax = new System.Windows.Forms.GroupBox();
            this.panelSyntaxPrefix = new System.Windows.Forms.Panel();
            this.labelSyntaxPrefix = new System.Windows.Forms.Label();
            this.panelSyntaxKeyword = new System.Windows.Forms.Panel();
            this.labelSyntaxNumber = new System.Windows.Forms.Label();
            this.labelSyntaxKeyword = new System.Windows.Forms.Label();
            this.panelSyntaxNumber = new System.Windows.Forms.Panel();
            this.panelSyntaxUri = new System.Windows.Forms.Panel();
            this.labelSyntaxString = new System.Windows.Forms.Label();
            this.labelSyntaxUri = new System.Windows.Forms.Label();
            this.panelSyntaxString = new System.Windows.Forms.Panel();
            this.panelSyntaxOperator = new System.Windows.Forms.Panel();
            this.labelSyntaxProperty = new System.Windows.Forms.Label();
            this.labelSyntaxOperator = new System.Windows.Forms.Label();
            this.panelSyntaxProperty = new System.Windows.Forms.Panel();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileHistory)).BeginInit();
            this.groupBoxGeneral.SuspendLayout();
            this.groupBoxEditor.SuspendLayout();
            this.groupBoxLevels.SuspendLayout();
            this.groupBoxSyntax.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(293, 455);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(131, 455);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "&OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // checkBoxRestoreLastFile
            // 
            this.checkBoxRestoreLastFile.AutoSize = true;
            this.checkBoxRestoreLastFile.Location = new System.Drawing.Point(9, 42);
            this.checkBoxRestoreLastFile.Name = "checkBoxRestoreLastFile";
            this.checkBoxRestoreLastFile.Size = new System.Drawing.Size(194, 17);
            this.checkBoxRestoreLastFile.TabIndex = 1;
            this.checkBoxRestoreLastFile.Text = "Restore &previously open file on start";
            this.checkBoxRestoreLastFile.UseVisualStyleBackColor = true;
            // 
            // numericUpDownFileHistory
            // 
            this.numericUpDownFileHistory.Location = new System.Drawing.Point(127, 65);
            this.numericUpDownFileHistory.Name = "numericUpDownFileHistory";
            this.numericUpDownFileHistory.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownFileHistory.TabIndex = 3;
            // 
            // checkBoxShowWelcomeTab
            // 
            this.checkBoxShowWelcomeTab.AutoSize = true;
            this.checkBoxShowWelcomeTab.Location = new System.Drawing.Point(9, 19);
            this.checkBoxShowWelcomeTab.Name = "checkBoxShowWelcomeTab";
            this.checkBoxShowWelcomeTab.Size = new System.Drawing.Size(157, 17);
            this.checkBoxShowWelcomeTab.TabIndex = 0;
            this.checkBoxShowWelcomeTab.Text = "Show &Welcome tab on start";
            this.checkBoxShowWelcomeTab.UseVisualStyleBackColor = true;
            // 
            // labelFileHistory
            // 
            this.labelFileHistory.AutoSize = true;
            this.labelFileHistory.Location = new System.Drawing.Point(6, 67);
            this.labelFileHistory.Name = "labelFileHistory";
            this.labelFileHistory.Size = new System.Drawing.Size(115, 13);
            this.labelFileHistory.TabIndex = 2;
            this.labelFileHistory.Text = "Remember recent files:";
            // 
            // groupBoxGeneral
            // 
            this.groupBoxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGeneral.Controls.Add(this.checkBoxRestoreLastFile);
            this.groupBoxGeneral.Controls.Add(this.numericUpDownFileHistory);
            this.groupBoxGeneral.Controls.Add(this.labelFileHistory);
            this.groupBoxGeneral.Controls.Add(this.checkBoxShowWelcomeTab);
            this.groupBoxGeneral.Location = new System.Drawing.Point(12, 12);
            this.groupBoxGeneral.Name = "groupBoxGeneral";
            this.groupBoxGeneral.Size = new System.Drawing.Size(356, 94);
            this.groupBoxGeneral.TabIndex = 0;
            this.groupBoxGeneral.TabStop = false;
            this.groupBoxGeneral.Text = "General";
            // 
            // groupBoxEditor
            // 
            this.groupBoxEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEditor.Controls.Add(this.panelEditorBackgroundColor);
            this.groupBoxEditor.Controls.Add(this.labelEditorBackgroundColor);
            this.groupBoxEditor.Controls.Add(this.labelMarginTextColor);
            this.groupBoxEditor.Controls.Add(this.panelMarginBackgroundColor);
            this.groupBoxEditor.Controls.Add(this.panelMarginTextColor);
            this.groupBoxEditor.Controls.Add(this.labelMarginBackgroundColor);
            this.groupBoxEditor.Controls.Add(this.labelEditorTextColor);
            this.groupBoxEditor.Controls.Add(this.panelEditorTextColor);
            this.groupBoxEditor.Location = new System.Drawing.Point(12, 112);
            this.groupBoxEditor.Name = "groupBoxEditor";
            this.groupBoxEditor.Size = new System.Drawing.Size(356, 86);
            this.groupBoxEditor.TabIndex = 4;
            this.groupBoxEditor.TabStop = false;
            this.groupBoxEditor.Text = "Editor";
            // 
            // panelEditorBackgroundColor
            // 
            this.panelEditorBackgroundColor.BackColor = System.Drawing.Color.White;
            this.panelEditorBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditorBackgroundColor.Location = new System.Drawing.Point(137, 19);
            this.panelEditorBackgroundColor.Name = "panelEditorBackgroundColor";
            this.panelEditorBackgroundColor.Size = new System.Drawing.Size(25, 25);
            this.panelEditorBackgroundColor.TabIndex = 1;
            this.panelEditorBackgroundColor.TabStop = true;
            this.panelEditorBackgroundColor.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelEditorBackgroundColor
            // 
            this.labelEditorBackgroundColor.AutoSize = true;
            this.labelEditorBackgroundColor.Location = new System.Drawing.Point(6, 25);
            this.labelEditorBackgroundColor.Name = "labelEditorBackgroundColor";
            this.labelEditorBackgroundColor.Size = new System.Drawing.Size(123, 13);
            this.labelEditorBackgroundColor.TabIndex = 0;
            this.labelEditorBackgroundColor.Text = "Editor background color:";
            // 
            // labelMarginTextColor
            // 
            this.labelMarginTextColor.AutoSize = true;
            this.labelMarginTextColor.Location = new System.Drawing.Point(202, 56);
            this.labelMarginTextColor.Name = "labelMarginTextColor";
            this.labelMarginTextColor.Size = new System.Drawing.Size(88, 13);
            this.labelMarginTextColor.TabIndex = 6;
            this.labelMarginTextColor.Text = "Margin text color:";
            // 
            // panelMarginBackgroundColor
            // 
            this.panelMarginBackgroundColor.BackColor = System.Drawing.Color.White;
            this.panelMarginBackgroundColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMarginBackgroundColor.Location = new System.Drawing.Point(137, 50);
            this.panelMarginBackgroundColor.Name = "panelMarginBackgroundColor";
            this.panelMarginBackgroundColor.Size = new System.Drawing.Size(25, 25);
            this.panelMarginBackgroundColor.TabIndex = 3;
            this.panelMarginBackgroundColor.TabStop = true;
            this.panelMarginBackgroundColor.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // panelMarginTextColor
            // 
            this.panelMarginTextColor.BackColor = System.Drawing.Color.White;
            this.panelMarginTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMarginTextColor.Location = new System.Drawing.Point(323, 50);
            this.panelMarginTextColor.Name = "panelMarginTextColor";
            this.panelMarginTextColor.Size = new System.Drawing.Size(25, 25);
            this.panelMarginTextColor.TabIndex = 7;
            this.panelMarginTextColor.TabStop = true;
            this.panelMarginTextColor.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelMarginBackgroundColor
            // 
            this.labelMarginBackgroundColor.AutoSize = true;
            this.labelMarginBackgroundColor.Location = new System.Drawing.Point(6, 56);
            this.labelMarginBackgroundColor.Name = "labelMarginBackgroundColor";
            this.labelMarginBackgroundColor.Size = new System.Drawing.Size(128, 13);
            this.labelMarginBackgroundColor.TabIndex = 2;
            this.labelMarginBackgroundColor.Text = "Margin background color:";
            // 
            // labelEditorTextColor
            // 
            this.labelEditorTextColor.AutoSize = true;
            this.labelEditorTextColor.Location = new System.Drawing.Point(202, 25);
            this.labelEditorTextColor.Name = "labelEditorTextColor";
            this.labelEditorTextColor.Size = new System.Drawing.Size(83, 13);
            this.labelEditorTextColor.TabIndex = 4;
            this.labelEditorTextColor.Text = "Editor text color:";
            // 
            // panelEditorTextColor
            // 
            this.panelEditorTextColor.BackColor = System.Drawing.Color.White;
            this.panelEditorTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditorTextColor.Location = new System.Drawing.Point(323, 19);
            this.panelEditorTextColor.Name = "panelEditorTextColor";
            this.panelEditorTextColor.Size = new System.Drawing.Size(25, 25);
            this.panelEditorTextColor.TabIndex = 5;
            this.panelEditorTextColor.TabStop = true;
            this.panelEditorTextColor.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // groupBoxLevels
            // 
            this.groupBoxLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLevels.Controls.Add(this.panelLevelTrace);
            this.groupBoxLevels.Controls.Add(this.labelLevelTrace);
            this.groupBoxLevels.Controls.Add(this.labelLevelDebug);
            this.groupBoxLevels.Controls.Add(this.panelLevelDebug);
            this.groupBoxLevels.Controls.Add(this.labelLevelInfo);
            this.groupBoxLevels.Controls.Add(this.panelLevelInfo);
            this.groupBoxLevels.Controls.Add(this.panelLevelError);
            this.groupBoxLevels.Controls.Add(this.labelLevelWarn);
            this.groupBoxLevels.Controls.Add(this.labelLevelError);
            this.groupBoxLevels.Controls.Add(this.panelLevelWarn);
            this.groupBoxLevels.Location = new System.Drawing.Point(198, 204);
            this.groupBoxLevels.Name = "groupBoxLevels";
            this.groupBoxLevels.Size = new System.Drawing.Size(170, 241);
            this.groupBoxLevels.TabIndex = 6;
            this.groupBoxLevels.TabStop = false;
            this.groupBoxLevels.Text = "Output Levels";
            // 
            // panelLevelTrace
            // 
            this.panelLevelTrace.BackColor = System.Drawing.Color.White;
            this.panelLevelTrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevelTrace.Location = new System.Drawing.Point(137, 20);
            this.panelLevelTrace.Name = "panelLevelTrace";
            this.panelLevelTrace.Size = new System.Drawing.Size(25, 25);
            this.panelLevelTrace.TabIndex = 1;
            this.panelLevelTrace.TabStop = true;
            this.panelLevelTrace.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelLevelTrace
            // 
            this.labelLevelTrace.AutoSize = true;
            this.labelLevelTrace.Location = new System.Drawing.Point(6, 26);
            this.labelLevelTrace.Name = "labelLevelTrace";
            this.labelLevelTrace.Size = new System.Drawing.Size(64, 13);
            this.labelLevelTrace.TabIndex = 0;
            this.labelLevelTrace.Text = "Trace color:";
            // 
            // labelLevelDebug
            // 
            this.labelLevelDebug.AutoSize = true;
            this.labelLevelDebug.Location = new System.Drawing.Point(6, 57);
            this.labelLevelDebug.Name = "labelLevelDebug";
            this.labelLevelDebug.Size = new System.Drawing.Size(68, 13);
            this.labelLevelDebug.TabIndex = 2;
            this.labelLevelDebug.Text = "Debug color:";
            // 
            // panelLevelDebug
            // 
            this.panelLevelDebug.BackColor = System.Drawing.Color.White;
            this.panelLevelDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevelDebug.Location = new System.Drawing.Point(137, 51);
            this.panelLevelDebug.Name = "panelLevelDebug";
            this.panelLevelDebug.Size = new System.Drawing.Size(25, 25);
            this.panelLevelDebug.TabIndex = 3;
            this.panelLevelDebug.TabStop = true;
            this.panelLevelDebug.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelLevelInfo
            // 
            this.labelLevelInfo.AutoSize = true;
            this.labelLevelInfo.Location = new System.Drawing.Point(6, 88);
            this.labelLevelInfo.Name = "labelLevelInfo";
            this.labelLevelInfo.Size = new System.Drawing.Size(54, 13);
            this.labelLevelInfo.TabIndex = 4;
            this.labelLevelInfo.Text = "Info color:";
            // 
            // panelLevelInfo
            // 
            this.panelLevelInfo.BackColor = System.Drawing.Color.White;
            this.panelLevelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevelInfo.Location = new System.Drawing.Point(137, 82);
            this.panelLevelInfo.Name = "panelLevelInfo";
            this.panelLevelInfo.Size = new System.Drawing.Size(25, 25);
            this.panelLevelInfo.TabIndex = 5;
            this.panelLevelInfo.TabStop = true;
            this.panelLevelInfo.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // panelLevelError
            // 
            this.panelLevelError.BackColor = System.Drawing.Color.White;
            this.panelLevelError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevelError.Location = new System.Drawing.Point(137, 144);
            this.panelLevelError.Name = "panelLevelError";
            this.panelLevelError.Size = new System.Drawing.Size(25, 25);
            this.panelLevelError.TabIndex = 9;
            this.panelLevelError.TabStop = true;
            this.panelLevelError.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelLevelWarn
            // 
            this.labelLevelWarn.AutoSize = true;
            this.labelLevelWarn.Location = new System.Drawing.Point(6, 119);
            this.labelLevelWarn.Name = "labelLevelWarn";
            this.labelLevelWarn.Size = new System.Drawing.Size(62, 13);
            this.labelLevelWarn.TabIndex = 6;
            this.labelLevelWarn.Text = "Warn color:";
            // 
            // labelLevelError
            // 
            this.labelLevelError.AutoSize = true;
            this.labelLevelError.Location = new System.Drawing.Point(6, 150);
            this.labelLevelError.Name = "labelLevelError";
            this.labelLevelError.Size = new System.Drawing.Size(58, 13);
            this.labelLevelError.TabIndex = 8;
            this.labelLevelError.Text = "Error color:";
            // 
            // panelLevelWarn
            // 
            this.panelLevelWarn.BackColor = System.Drawing.Color.White;
            this.panelLevelWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLevelWarn.Location = new System.Drawing.Point(137, 113);
            this.panelLevelWarn.Name = "panelLevelWarn";
            this.panelLevelWarn.Size = new System.Drawing.Size(25, 25);
            this.panelLevelWarn.TabIndex = 7;
            this.panelLevelWarn.TabStop = true;
            this.panelLevelWarn.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // groupBoxSyntax
            // 
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxPrefix);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxPrefix);
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxKeyword);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxNumber);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxKeyword);
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxNumber);
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxUri);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxString);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxUri);
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxString);
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxOperator);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxProperty);
            this.groupBoxSyntax.Controls.Add(this.labelSyntaxOperator);
            this.groupBoxSyntax.Controls.Add(this.panelSyntaxProperty);
            this.groupBoxSyntax.Location = new System.Drawing.Point(12, 204);
            this.groupBoxSyntax.Name = "groupBoxSyntax";
            this.groupBoxSyntax.Size = new System.Drawing.Size(170, 241);
            this.groupBoxSyntax.TabIndex = 5;
            this.groupBoxSyntax.TabStop = false;
            this.groupBoxSyntax.Text = "Syntax Highlighting";
            // 
            // panelSyntaxPrefix
            // 
            this.panelSyntaxPrefix.BackColor = System.Drawing.Color.White;
            this.panelSyntaxPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxPrefix.Location = new System.Drawing.Point(137, 20);
            this.panelSyntaxPrefix.Name = "panelSyntaxPrefix";
            this.panelSyntaxPrefix.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxPrefix.TabIndex = 1;
            this.panelSyntaxPrefix.TabStop = true;
            this.panelSyntaxPrefix.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelSyntaxPrefix
            // 
            this.labelSyntaxPrefix.AutoSize = true;
            this.labelSyntaxPrefix.Location = new System.Drawing.Point(6, 26);
            this.labelSyntaxPrefix.Name = "labelSyntaxPrefix";
            this.labelSyntaxPrefix.Size = new System.Drawing.Size(62, 13);
            this.labelSyntaxPrefix.TabIndex = 0;
            this.labelSyntaxPrefix.Text = "Prefix color:";
            // 
            // panelSyntaxKeyword
            // 
            this.panelSyntaxKeyword.BackColor = System.Drawing.Color.White;
            this.panelSyntaxKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxKeyword.Location = new System.Drawing.Point(137, 206);
            this.panelSyntaxKeyword.Name = "panelSyntaxKeyword";
            this.panelSyntaxKeyword.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxKeyword.TabIndex = 13;
            this.panelSyntaxKeyword.TabStop = true;
            this.panelSyntaxKeyword.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelSyntaxNumber
            // 
            this.labelSyntaxNumber.AutoSize = true;
            this.labelSyntaxNumber.Location = new System.Drawing.Point(6, 57);
            this.labelSyntaxNumber.Name = "labelSyntaxNumber";
            this.labelSyntaxNumber.Size = new System.Drawing.Size(73, 13);
            this.labelSyntaxNumber.TabIndex = 2;
            this.labelSyntaxNumber.Text = "Number color:";
            // 
            // labelSyntaxKeyword
            // 
            this.labelSyntaxKeyword.AutoSize = true;
            this.labelSyntaxKeyword.Location = new System.Drawing.Point(6, 212);
            this.labelSyntaxKeyword.Name = "labelSyntaxKeyword";
            this.labelSyntaxKeyword.Size = new System.Drawing.Size(77, 13);
            this.labelSyntaxKeyword.TabIndex = 12;
            this.labelSyntaxKeyword.Text = "Keyword color:";
            // 
            // panelSyntaxNumber
            // 
            this.panelSyntaxNumber.BackColor = System.Drawing.Color.White;
            this.panelSyntaxNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxNumber.Location = new System.Drawing.Point(137, 51);
            this.panelSyntaxNumber.Name = "panelSyntaxNumber";
            this.panelSyntaxNumber.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxNumber.TabIndex = 3;
            this.panelSyntaxNumber.TabStop = true;
            this.panelSyntaxNumber.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // panelSyntaxUri
            // 
            this.panelSyntaxUri.BackColor = System.Drawing.Color.White;
            this.panelSyntaxUri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxUri.Location = new System.Drawing.Point(137, 175);
            this.panelSyntaxUri.Name = "panelSyntaxUri";
            this.panelSyntaxUri.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxUri.TabIndex = 11;
            this.panelSyntaxUri.TabStop = true;
            this.panelSyntaxUri.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelSyntaxString
            // 
            this.labelSyntaxString.AutoSize = true;
            this.labelSyntaxString.Location = new System.Drawing.Point(6, 88);
            this.labelSyntaxString.Name = "labelSyntaxString";
            this.labelSyntaxString.Size = new System.Drawing.Size(63, 13);
            this.labelSyntaxString.TabIndex = 4;
            this.labelSyntaxString.Text = "String color:";
            // 
            // labelSyntaxUri
            // 
            this.labelSyntaxUri.AutoSize = true;
            this.labelSyntaxUri.Location = new System.Drawing.Point(6, 181);
            this.labelSyntaxUri.Name = "labelSyntaxUri";
            this.labelSyntaxUri.Size = new System.Drawing.Size(55, 13);
            this.labelSyntaxUri.TabIndex = 10;
            this.labelSyntaxUri.Text = "URI color:";
            // 
            // panelSyntaxString
            // 
            this.panelSyntaxString.BackColor = System.Drawing.Color.White;
            this.panelSyntaxString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxString.Location = new System.Drawing.Point(137, 82);
            this.panelSyntaxString.Name = "panelSyntaxString";
            this.panelSyntaxString.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxString.TabIndex = 5;
            this.panelSyntaxString.TabStop = true;
            this.panelSyntaxString.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // panelSyntaxOperator
            // 
            this.panelSyntaxOperator.BackColor = System.Drawing.Color.White;
            this.panelSyntaxOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxOperator.Location = new System.Drawing.Point(137, 144);
            this.panelSyntaxOperator.Name = "panelSyntaxOperator";
            this.panelSyntaxOperator.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxOperator.TabIndex = 9;
            this.panelSyntaxOperator.TabStop = true;
            this.panelSyntaxOperator.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // labelSyntaxProperty
            // 
            this.labelSyntaxProperty.AutoSize = true;
            this.labelSyntaxProperty.Location = new System.Drawing.Point(6, 119);
            this.labelSyntaxProperty.Name = "labelSyntaxProperty";
            this.labelSyntaxProperty.Size = new System.Drawing.Size(75, 13);
            this.labelSyntaxProperty.TabIndex = 6;
            this.labelSyntaxProperty.Text = "Property color:";
            // 
            // labelSyntaxOperator
            // 
            this.labelSyntaxOperator.AutoSize = true;
            this.labelSyntaxOperator.Location = new System.Drawing.Point(6, 150);
            this.labelSyntaxOperator.Name = "labelSyntaxOperator";
            this.labelSyntaxOperator.Size = new System.Drawing.Size(77, 13);
            this.labelSyntaxOperator.TabIndex = 8;
            this.labelSyntaxOperator.Text = "Operator color:";
            // 
            // panelSyntaxProperty
            // 
            this.panelSyntaxProperty.BackColor = System.Drawing.Color.White;
            this.panelSyntaxProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSyntaxProperty.Location = new System.Drawing.Point(137, 113);
            this.panelSyntaxProperty.Name = "panelSyntaxProperty";
            this.panelSyntaxProperty.Size = new System.Drawing.Size(25, 25);
            this.panelSyntaxProperty.TabIndex = 7;
            this.panelSyntaxProperty.TabStop = true;
            this.panelSyntaxProperty.Click += new System.EventHandler(this.PanelColor_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(212, 455);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 7;
            this.buttonApply.Text = "&Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(12, 455);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "&Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // Preferences
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(380, 490);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.groupBoxEditor);
            this.Controls.Add(this.groupBoxLevels);
            this.Controls.Add(this.groupBoxSyntax);
            this.Controls.Add(this.groupBoxGeneral);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFileHistory)).EndInit();
            this.groupBoxGeneral.ResumeLayout(false);
            this.groupBoxGeneral.PerformLayout();
            this.groupBoxEditor.ResumeLayout(false);
            this.groupBoxEditor.PerformLayout();
            this.groupBoxLevels.ResumeLayout(false);
            this.groupBoxLevels.PerformLayout();
            this.groupBoxSyntax.ResumeLayout(false);
            this.groupBoxSyntax.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.CheckBox checkBoxRestoreLastFile;
		private System.Windows.Forms.NumericUpDown numericUpDownFileHistory;
		private System.Windows.Forms.CheckBox checkBoxShowWelcomeTab;
		private System.Windows.Forms.Label labelFileHistory;
		private System.Windows.Forms.GroupBox groupBoxGeneral;
		private System.Windows.Forms.GroupBox groupBoxEditor;
		private System.Windows.Forms.Panel panelEditorBackgroundColor;
		private System.Windows.Forms.Label labelEditorBackgroundColor;
		private System.Windows.Forms.Label labelMarginTextColor;
		private System.Windows.Forms.Panel panelMarginBackgroundColor;
		private System.Windows.Forms.Panel panelMarginTextColor;
		private System.Windows.Forms.Label labelMarginBackgroundColor;
		private System.Windows.Forms.Label labelEditorTextColor;
		private System.Windows.Forms.Panel panelEditorTextColor;
		private System.Windows.Forms.GroupBox groupBoxLevels;
		private System.Windows.Forms.Panel panelLevelTrace;
		private System.Windows.Forms.Label labelLevelTrace;
		private System.Windows.Forms.Label labelLevelDebug;
		private System.Windows.Forms.Panel panelLevelDebug;
		private System.Windows.Forms.Label labelLevelInfo;
		private System.Windows.Forms.Panel panelLevelInfo;
		private System.Windows.Forms.Panel panelLevelError;
		private System.Windows.Forms.Label labelLevelWarn;
		private System.Windows.Forms.Label labelLevelError;
		private System.Windows.Forms.Panel panelLevelWarn;
		private System.Windows.Forms.GroupBox groupBoxSyntax;
		private System.Windows.Forms.Panel panelSyntaxPrefix;
		private System.Windows.Forms.Label labelSyntaxPrefix;
		private System.Windows.Forms.Panel panelSyntaxKeyword;
		private System.Windows.Forms.Label labelSyntaxNumber;
		private System.Windows.Forms.Label labelSyntaxKeyword;
		private System.Windows.Forms.Panel panelSyntaxNumber;
		private System.Windows.Forms.Panel panelSyntaxUri;
		private System.Windows.Forms.Label labelSyntaxString;
		private System.Windows.Forms.Label labelSyntaxUri;
		private System.Windows.Forms.Panel panelSyntaxString;
		private System.Windows.Forms.Panel panelSyntaxOperator;
		private System.Windows.Forms.Label labelSyntaxProperty;
		private System.Windows.Forms.Label labelSyntaxOperator;
		private System.Windows.Forms.Panel panelSyntaxProperty;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonReset;
	}
}
