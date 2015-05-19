namespace WorldCup2014
{
	partial class FSettings
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
			this.components = new System.ComponentModel.Container();
			this.closeB = new System.Windows.Forms.Button();
			this.groupL = new System.Windows.Forms.Label();
			this.teamListCB = new System.Windows.Forms.ComboBox();
			this.bgImg = new System.Windows.Forms.PictureBox();
			this.dateL = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.playMusicOnStartupChB = new System.Windows.Forms.CheckBox();
			this.optionsB = new System.Windows.Forms.Button();
			this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.resetAllResults = new System.Windows.Forms.ToolStripMenuItem();
			this.randomizeGroupMatches = new System.Windows.Forms.ToolStripMenuItem();
			this.randomizePlayOffMatches = new System.Windows.Forms.ToolStripMenuItem();
			this.randomizeAllMatches = new System.Windows.Forms.ToolStripMenuItem();
			this.showPlayoffsChB = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.setMatchdayBlablaChB = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).BeginInit();
			this.optionsMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// closeB
			// 
			this.closeB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeB.Location = new System.Drawing.Point(350, 405);
			this.closeB.Name = "closeB";
			this.closeB.Size = new System.Drawing.Size(211, 50);
			this.closeB.TabIndex = 14;
			this.closeB.Text = "Save and close";
			this.closeB.UseVisualStyleBackColor = true;
			this.closeB.Click += new System.EventHandler(this.closeB_Click);
			// 
			// groupL
			// 
			this.groupL.AutoSize = true;
			this.groupL.BackColor = System.Drawing.Color.Transparent;
			this.groupL.Cursor = System.Windows.Forms.Cursors.Default;
			this.groupL.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupL.ForeColor = System.Drawing.Color.White;
			this.groupL.Location = new System.Drawing.Point(42, 38);
			this.groupL.Name = "groupL";
			this.groupL.Size = new System.Drawing.Size(134, 41);
			this.groupL.TabIndex = 13;
			this.groupL.Text = "Settings";
			this.groupL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// teamListCB
			// 
			this.teamListCB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.teamListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.teamListCB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.teamListCB.FormattingEnabled = true;
			this.teamListCB.IntegralHeight = false;
			this.teamListCB.Location = new System.Drawing.Point(131, 118);
			this.teamListCB.MaxDropDownItems = 16;
			this.teamListCB.Name = "teamListCB";
			this.teamListCB.Size = new System.Drawing.Size(430, 33);
			this.teamListCB.TabIndex = 12;
			// 
			// bgImg
			// 
			this.bgImg.Location = new System.Drawing.Point(461, 29);
			this.bgImg.Name = "bgImg";
			this.bgImg.Size = new System.Drawing.Size(100, 50);
			this.bgImg.TabIndex = 11;
			this.bgImg.TabStop = false;
			// 
			// dateL
			// 
			this.dateL.AutoSize = true;
			this.dateL.BackColor = System.Drawing.Color.Transparent;
			this.dateL.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateL.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.dateL.Location = new System.Drawing.Point(96, 90);
			this.dateL.Name = "dateL";
			this.dateL.Size = new System.Drawing.Size(126, 25);
			this.dateL.TabIndex = 15;
			this.dateL.Text = "Favorite team";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label1.Location = new System.Drawing.Point(96, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(454, 25);
			this.label1.TabIndex = 16;
			this.label1.Text = "Set matchday to last unplayed match date on startup";
			// 
			// playMusicOnStartupChB
			// 
			this.playMusicOnStartupChB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.playMusicOnStartupChB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playMusicOnStartupChB.ForeColor = System.Drawing.Color.White;
			this.playMusicOnStartupChB.Location = new System.Drawing.Point(131, 338);
			this.playMusicOnStartupChB.Name = "playMusicOnStartupChB";
			this.playMusicOnStartupChB.Size = new System.Drawing.Size(430, 29);
			this.playMusicOnStartupChB.TabIndex = 17;
			this.playMusicOnStartupChB.Text = "playMusicOnStartupChB";
			this.playMusicOnStartupChB.UseVisualStyleBackColor = true;
			this.playMusicOnStartupChB.CheckedChanged += new System.EventHandler(this.playMusicOnStartupChB_CheckedChanged);
			// 
			// optionsB
			// 
			this.optionsB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.optionsB.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optionsB.Location = new System.Drawing.Point(131, 405);
			this.optionsB.Name = "optionsB";
			this.optionsB.Size = new System.Drawing.Size(211, 50);
			this.optionsB.TabIndex = 18;
			this.optionsB.Text = "More options";
			this.optionsB.UseVisualStyleBackColor = true;
			this.optionsB.Click += new System.EventHandler(this.optionsB_Click);
			// 
			// optionsMenu
			// 
			this.optionsMenu.BackColor = System.Drawing.SystemColors.Control;
			this.optionsMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetAllResults,
            this.randomizeGroupMatches,
            this.randomizePlayOffMatches,
            this.randomizeAllMatches});
			this.optionsMenu.Name = "optionsMenu";
			this.optionsMenu.Size = new System.Drawing.Size(296, 100);
			this.optionsMenu.Text = "Options";
			// 
			// resetAllResults
			// 
			this.resetAllResults.Name = "resetAllResults";
			this.resetAllResults.Size = new System.Drawing.Size(295, 24);
			this.resetAllResults.Text = "Reset all match results";
			this.resetAllResults.Click += new System.EventHandler(this.resetAllResults_Click);
			// 
			// randomizeGroupMatches
			// 
			this.randomizeGroupMatches.Name = "randomizeGroupMatches";
			this.randomizeGroupMatches.Size = new System.Drawing.Size(295, 24);
			this.randomizeGroupMatches.Text = "Randomize group matches results";
			this.randomizeGroupMatches.Click += new System.EventHandler(this.randomizeGroupMatches_Click);
			// 
			// randomizePlayOffMatches
			// 
			this.randomizePlayOffMatches.Name = "randomizePlayOffMatches";
			this.randomizePlayOffMatches.Size = new System.Drawing.Size(295, 24);
			this.randomizePlayOffMatches.Text = "Randomize play-off matches results";
			this.randomizePlayOffMatches.Click += new System.EventHandler(this.randomizePlayOffMatches_Click);
			// 
			// randomizeAllMatches
			// 
			this.randomizeAllMatches.Name = "randomizeAllMatches";
			this.randomizeAllMatches.Size = new System.Drawing.Size(295, 24);
			this.randomizeAllMatches.Text = "Randomize all results";
			this.randomizeAllMatches.Click += new System.EventHandler(this.randomizeAllMatches_Click);
			// 
			// showPlayoffsChB
			// 
			this.showPlayoffsChB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.showPlayoffsChB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.showPlayoffsChB.ForeColor = System.Drawing.Color.White;
			this.showPlayoffsChB.Location = new System.Drawing.Point(131, 265);
			this.showPlayoffsChB.Name = "showPlayoffsChB";
			this.showPlayoffsChB.Size = new System.Drawing.Size(430, 29);
			this.showPlayoffsChB.TabIndex = 20;
			this.showPlayoffsChB.Text = "showPlayoffsChB";
			this.showPlayoffsChB.UseVisualStyleBackColor = true;
			this.showPlayoffsChB.CheckedChanged += new System.EventHandler(this.playMusicOnStartupChB_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label2.Location = new System.Drawing.Point(96, 237);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(485, 25);
			this.label2.TabIndex = 19;
			this.label2.Text = "Show playoffs on startup if the group phase has finished";
			// 
			// setMatchdayBlablaChB
			// 
			this.setMatchdayBlablaChB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.setMatchdayBlablaChB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.setMatchdayBlablaChB.ForeColor = System.Drawing.Color.White;
			this.setMatchdayBlablaChB.Location = new System.Drawing.Point(131, 196);
			this.setMatchdayBlablaChB.Name = "setMatchdayBlablaChB";
			this.setMatchdayBlablaChB.Size = new System.Drawing.Size(430, 29);
			this.setMatchdayBlablaChB.TabIndex = 22;
			this.setMatchdayBlablaChB.Text = "setMatchdayBlablaChB";
			this.setMatchdayBlablaChB.UseVisualStyleBackColor = true;
			this.setMatchdayBlablaChB.CheckedChanged += new System.EventHandler(this.playMusicOnStartupChB_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label4.Location = new System.Drawing.Point(96, 310);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(192, 25);
			this.label4.TabIndex = 21;
			this.label4.Text = "Play music on startup";
			// 
			// FSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(691, 516);
			this.ControlBox = false;
			this.Controls.Add(this.setMatchdayBlablaChB);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.showPlayoffsChB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.optionsB);
			this.Controls.Add(this.playMusicOnStartupChB);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateL);
			this.Controls.Add(this.closeB);
			this.Controls.Add(this.groupL);
			this.Controls.Add(this.teamListCB);
			this.Controls.Add(this.bgImg);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FSettings";
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).EndInit();
			this.optionsMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button closeB;
		private System.Windows.Forms.Label groupL;
		public System.Windows.Forms.ComboBox teamListCB;
		private System.Windows.Forms.PictureBox bgImg;
		private System.Windows.Forms.Label dateL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox playMusicOnStartupChB;
		private System.Windows.Forms.Button optionsB;
		private System.Windows.Forms.ContextMenuStrip optionsMenu;
		private System.Windows.Forms.ToolStripMenuItem randomizeGroupMatches;
		private System.Windows.Forms.ToolStripMenuItem resetAllResults;
		private System.Windows.Forms.ToolStripMenuItem randomizePlayOffMatches;
		private System.Windows.Forms.ToolStripMenuItem randomizeAllMatches;
		private System.Windows.Forms.CheckBox showPlayoffsChB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox setMatchdayBlablaChB;
		private System.Windows.Forms.Label label4;

	}
}