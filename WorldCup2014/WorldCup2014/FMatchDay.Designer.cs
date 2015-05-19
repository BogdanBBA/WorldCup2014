namespace WorldCup2014
{
	partial class FMatchDay
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
			this.bgImg = new System.Windows.Forms.PictureBox();
			this.MatchDayPanel = new System.Windows.Forms.Panel();
			this.MatchDayButtonFontL = new System.Windows.Forms.Label();
			this.dateL = new System.Windows.Forms.Label();
			this.matchesL = new System.Windows.Forms.Label();
			this.MatchesPanel = new System.Windows.Forms.Panel();
			this.refreshInfoTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).BeginInit();
			this.MatchDayPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// closeB
			// 
			this.closeB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeB.Location = new System.Drawing.Point(250, 303);
			this.closeB.Name = "closeB";
			this.closeB.Size = new System.Drawing.Size(230, 50);
			this.closeB.TabIndex = 22;
			this.closeB.Text = "Close";
			this.closeB.UseVisualStyleBackColor = true;
			this.closeB.Click += new System.EventHandler(this.closeB_Click);
			// 
			// bgImg
			// 
			this.bgImg.Location = new System.Drawing.Point(22, -8);
			this.bgImg.Name = "bgImg";
			this.bgImg.Size = new System.Drawing.Size(100, 52);
			this.bgImg.TabIndex = 21;
			this.bgImg.TabStop = false;
			// 
			// MatchDayPanel
			// 
			this.MatchDayPanel.Controls.Add(this.MatchDayButtonFontL);
			this.MatchDayPanel.Location = new System.Drawing.Point(311, 87);
			this.MatchDayPanel.Name = "MatchDayPanel";
			this.MatchDayPanel.Size = new System.Drawing.Size(400, 200);
			this.MatchDayPanel.TabIndex = 20;
			// 
			// MatchDayButtonFontL
			// 
			this.MatchDayButtonFontL.AutoSize = true;
			this.MatchDayButtonFontL.BackColor = System.Drawing.Color.Transparent;
			this.MatchDayButtonFontL.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MatchDayButtonFontL.ForeColor = System.Drawing.Color.Honeydew;
			this.MatchDayButtonFontL.Location = new System.Drawing.Point(18, 140);
			this.MatchDayButtonFontL.Name = "MatchDayButtonFontL";
			this.MatchDayButtonFontL.Size = new System.Drawing.Size(156, 20);
			this.MatchDayButtonFontL.TabIndex = 24;
			this.MatchDayButtonFontL.Text = "MatchDayButtonFontL";
			this.MatchDayButtonFontL.Visible = false;
			// 
			// dateL
			// 
			this.dateL.AutoSize = true;
			this.dateL.BackColor = System.Drawing.Color.Transparent;
			this.dateL.Cursor = System.Windows.Forms.Cursors.Default;
			this.dateL.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateL.ForeColor = System.Drawing.Color.Wheat;
			this.dateL.Location = new System.Drawing.Point(39, 61);
			this.dateL.Name = "dateL";
			this.dateL.Size = new System.Drawing.Size(61, 25);
			this.dateL.TabIndex = 23;
			this.dateL.Text = "dateL";
			// 
			// matchesL
			// 
			this.matchesL.AutoSize = true;
			this.matchesL.BackColor = System.Drawing.Color.Transparent;
			this.matchesL.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.matchesL.ForeColor = System.Drawing.Color.Honeydew;
			this.matchesL.Location = new System.Drawing.Point(61, 97);
			this.matchesL.Name = "matchesL";
			this.matchesL.Size = new System.Drawing.Size(154, 15);
			this.matchesL.TabIndex = 37;
			this.matchesL.Text = "P L A Y - O F F   M A T C H E S";
			// 
			// MatchesPanel
			// 
			this.MatchesPanel.Location = new System.Drawing.Point(64, 115);
			this.MatchesPanel.Name = "MatchesPanel";
			this.MatchesPanel.Size = new System.Drawing.Size(230, 172);
			this.MatchesPanel.TabIndex = 36;
			// 
			// refreshInfoTimer
			// 
			this.refreshInfoTimer.Tick += new System.EventHandler(this.refreshInfoTimer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Honeydew;
			this.label1.Location = new System.Drawing.Point(308, 69);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 15);
			this.label1.TabIndex = 38;
			this.label1.Text = "M A T C H   D A Y S";
			// 
			// FMatchDay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(781, 392);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.MatchDayPanel);
			this.Controls.Add(this.matchesL);
			this.Controls.Add(this.MatchesPanel);
			this.Controls.Add(this.dateL);
			this.Controls.Add(this.closeB);
			this.Controls.Add(this.bgImg);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FMatchDay";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FMatchDay";
			this.Shown += new System.EventHandler(this.FMatchDay_Shown);
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).EndInit();
			this.MatchDayPanel.ResumeLayout(false);
			this.MatchDayPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button closeB;
		private System.Windows.Forms.PictureBox bgImg;
		private System.Windows.Forms.Panel MatchDayPanel;
		private System.Windows.Forms.Label MatchDayButtonFontL;
		private System.Windows.Forms.Label dateL;
		private System.Windows.Forms.Label matchesL;
		private System.Windows.Forms.Panel MatchesPanel;
		public System.Windows.Forms.Timer refreshInfoTimer;
		private System.Windows.Forms.Label label1;
	}
}