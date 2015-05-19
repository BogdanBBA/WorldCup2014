namespace WorldCup2014
{
	partial class FMatch
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
			this.bgImg = new System.Windows.Forms.PictureBox();
			this.matchListCB = new System.Windows.Forms.ComboBox();
			this.groupL = new System.Windows.Forms.Label();
			this.dateL = new System.Windows.Forms.Label();
			this.stadiumL = new System.Windows.Forms.Label();
			this.team1L = new System.Windows.Forms.Label();
			this.team2L = new System.Windows.Forms.Label();
			this.finalScoreL = new System.Windows.Forms.Label();
			this.scoreInfoL = new System.Windows.Forms.Label();
			this.editB = new System.Windows.Forms.Button();
			this.closeB = new System.Windows.Forms.Button();
			this.flagTeam1 = new System.Windows.Forms.PictureBox();
			this.flagTeam2 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.temperatureL = new System.Windows.Forms.Label();
			this.windSpeedL = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.humidityL = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flagTeam1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.flagTeam2)).BeginInit();
			this.SuspendLayout();
			// 
			// bgImg
			// 
			this.bgImg.Location = new System.Drawing.Point(46, 378);
			this.bgImg.Name = "bgImg";
			this.bgImg.Size = new System.Drawing.Size(100, 50);
			this.bgImg.TabIndex = 0;
			this.bgImg.TabStop = false;
			// 
			// matchListCB
			// 
			this.matchListCB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.matchListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.matchListCB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.matchListCB.FormattingEnabled = true;
			this.matchListCB.IntegralHeight = false;
			this.matchListCB.Location = new System.Drawing.Point(203, 42);
			this.matchListCB.MaxDropDownItems = 16;
			this.matchListCB.Name = "matchListCB";
			this.matchListCB.Size = new System.Drawing.Size(600, 33);
			this.matchListCB.TabIndex = 1;
			this.matchListCB.SelectedIndexChanged += new System.EventHandler(this.matchListCB_SelectedIndexChanged);
			// 
			// groupL
			// 
			this.groupL.BackColor = System.Drawing.Color.Transparent;
			this.groupL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.groupL.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupL.ForeColor = System.Drawing.Color.White;
			this.groupL.Location = new System.Drawing.Point(203, 78);
			this.groupL.Name = "groupL";
			this.groupL.Size = new System.Drawing.Size(600, 48);
			this.groupL.TabIndex = 2;
			this.groupL.Text = "groupL";
			this.groupL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.groupL.Click += new System.EventHandler(this.groupL_Click);
			// 
			// dateL
			// 
			this.dateL.AutoSize = true;
			this.dateL.BackColor = System.Drawing.Color.Transparent;
			this.dateL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dateL.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateL.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.dateL.Location = new System.Drawing.Point(248, 145);
			this.dateL.Name = "dateL";
			this.dateL.Size = new System.Drawing.Size(58, 25);
			this.dateL.TabIndex = 3;
			this.dateL.Text = "dateL";
			this.dateL.Click += new System.EventHandler(this.dateL_Click);
			// 
			// stadiumL
			// 
			this.stadiumL.AutoSize = true;
			this.stadiumL.BackColor = System.Drawing.Color.Transparent;
			this.stadiumL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.stadiumL.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stadiumL.ForeColor = System.Drawing.Color.Honeydew;
			this.stadiumL.Location = new System.Drawing.Point(248, 220);
			this.stadiumL.Name = "stadiumL";
			this.stadiumL.Size = new System.Drawing.Size(91, 25);
			this.stadiumL.TabIndex = 4;
			this.stadiumL.Text = "stadiumL";
			this.stadiumL.Click += new System.EventHandler(this.stadiumL_Click);
			// 
			// team1L
			// 
			this.team1L.BackColor = System.Drawing.Color.Transparent;
			this.team1L.Cursor = System.Windows.Forms.Cursors.Hand;
			this.team1L.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.team1L.ForeColor = System.Drawing.Color.White;
			this.team1L.Location = new System.Drawing.Point(38, 285);
			this.team1L.Name = "team1L";
			this.team1L.Size = new System.Drawing.Size(300, 46);
			this.team1L.TabIndex = 5;
			this.team1L.Text = "team1L";
			this.team1L.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.team1L.Click += new System.EventHandler(this.team1L_Click);
			// 
			// team2L
			// 
			this.team2L.BackColor = System.Drawing.Color.Transparent;
			this.team2L.Cursor = System.Windows.Forms.Cursors.Hand;
			this.team2L.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.team2L.ForeColor = System.Drawing.Color.White;
			this.team2L.Location = new System.Drawing.Point(646, 285);
			this.team2L.Name = "team2L";
			this.team2L.Size = new System.Drawing.Size(300, 46);
			this.team2L.TabIndex = 6;
			this.team2L.Text = "team2L";
			this.team2L.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.team2L.Click += new System.EventHandler(this.team2L_Click);
			// 
			// finalScoreL
			// 
			this.finalScoreL.BackColor = System.Drawing.Color.Transparent;
			this.finalScoreL.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.finalScoreL.ForeColor = System.Drawing.Color.Wheat;
			this.finalScoreL.Location = new System.Drawing.Point(420, 285);
			this.finalScoreL.Name = "finalScoreL";
			this.finalScoreL.Size = new System.Drawing.Size(144, 46);
			this.finalScoreL.TabIndex = 7;
			this.finalScoreL.Text = "finalScoreL";
			this.finalScoreL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scoreInfoL
			// 
			this.scoreInfoL.AutoSize = true;
			this.scoreInfoL.BackColor = System.Drawing.Color.Transparent;
			this.scoreInfoL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scoreInfoL.ForeColor = System.Drawing.Color.LavenderBlush;
			this.scoreInfoL.Location = new System.Drawing.Point(215, 348);
			this.scoreInfoL.Name = "scoreInfoL";
			this.scoreInfoL.Size = new System.Drawing.Size(80, 21);
			this.scoreInfoL.TabIndex = 8;
			this.scoreInfoL.Text = "scoreInfoL";
			// 
			// editB
			// 
			this.editB.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editB.Location = new System.Drawing.Point(344, 418);
			this.editB.Name = "editB";
			this.editB.Size = new System.Drawing.Size(140, 50);
			this.editB.TabIndex = 9;
			this.editB.Text = "Edit";
			this.editB.UseVisualStyleBackColor = true;
			this.editB.Click += new System.EventHandler(this.editB_Click);
			// 
			// closeB
			// 
			this.closeB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeB.Location = new System.Drawing.Point(500, 418);
			this.closeB.Name = "closeB";
			this.closeB.Size = new System.Drawing.Size(140, 50);
			this.closeB.TabIndex = 10;
			this.closeB.Text = "Close";
			this.closeB.UseVisualStyleBackColor = true;
			this.closeB.Click += new System.EventHandler(this.closeB_Click);
			// 
			// flagTeam1
			// 
			this.flagTeam1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.flagTeam1.Location = new System.Drawing.Point(344, 285);
			this.flagTeam1.Name = "flagTeam1";
			this.flagTeam1.Size = new System.Drawing.Size(70, 46);
			this.flagTeam1.TabIndex = 11;
			this.flagTeam1.TabStop = false;
			this.flagTeam1.Click += new System.EventHandler(this.team1L_Click);
			// 
			// flagTeam2
			// 
			this.flagTeam2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.flagTeam2.Location = new System.Drawing.Point(570, 285);
			this.flagTeam2.Name = "flagTeam2";
			this.flagTeam2.Size = new System.Drawing.Size(70, 46);
			this.flagTeam2.TabIndex = 12;
			this.flagTeam2.TabStop = false;
			this.flagTeam2.Click += new System.EventHandler(this.team2L_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label2.Location = new System.Drawing.Point(611, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 25);
			this.label2.TabIndex = 14;
			this.label2.Text = "Temperature:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// temperatureL
			// 
			this.temperatureL.BackColor = System.Drawing.Color.Transparent;
			this.temperatureL.Cursor = System.Windows.Forms.Cursors.Default;
			this.temperatureL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.temperatureL.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.temperatureL.Location = new System.Drawing.Point(748, 145);
			this.temperatureL.Name = "temperatureL";
			this.temperatureL.Size = new System.Drawing.Size(55, 25);
			this.temperatureL.TabIndex = 15;
			this.temperatureL.Text = "100%";
			this.temperatureL.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// windSpeedL
			// 
			this.windSpeedL.BackColor = System.Drawing.Color.Transparent;
			this.windSpeedL.Cursor = System.Windows.Forms.Cursors.Default;
			this.windSpeedL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windSpeedL.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.windSpeedL.Location = new System.Drawing.Point(748, 170);
			this.windSpeedL.Name = "windSpeedL";
			this.windSpeedL.Size = new System.Drawing.Size(55, 25);
			this.windSpeedL.TabIndex = 17;
			this.windSpeedL.Text = "100%";
			this.windSpeedL.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label4.Location = new System.Drawing.Point(611, 170);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(131, 25);
			this.label4.TabIndex = 16;
			this.label4.Text = "Wind speed (m/s):";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// humidityL
			// 
			this.humidityL.BackColor = System.Drawing.Color.Transparent;
			this.humidityL.Cursor = System.Windows.Forms.Cursors.Default;
			this.humidityL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.humidityL.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.humidityL.Location = new System.Drawing.Point(748, 195);
			this.humidityL.Name = "humidityL";
			this.humidityL.Size = new System.Drawing.Size(55, 25);
			this.humidityL.TabIndex = 19;
			this.humidityL.Text = "100%";
			this.humidityL.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.label6.Location = new System.Drawing.Point(611, 195);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 25);
			this.label6.TabIndex = 18;
			this.label6.Text = "Rel. humidity:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// FMatch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(995, 503);
			this.ControlBox = false;
			this.Controls.Add(this.humidityL);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.windSpeedL);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.temperatureL);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.flagTeam2);
			this.Controls.Add(this.flagTeam1);
			this.Controls.Add(this.closeB);
			this.Controls.Add(this.editB);
			this.Controls.Add(this.scoreInfoL);
			this.Controls.Add(this.finalScoreL);
			this.Controls.Add(this.team2L);
			this.Controls.Add(this.team1L);
			this.Controls.Add(this.stadiumL);
			this.Controls.Add(this.dateL);
			this.Controls.Add(this.groupL);
			this.Controls.Add(this.matchListCB);
			this.Controls.Add(this.bgImg);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FMatch";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FMatch";
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flagTeam1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.flagTeam2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox bgImg;
		private System.Windows.Forms.Label groupL;
		private System.Windows.Forms.Label dateL;
		private System.Windows.Forms.Label stadiumL;
		private System.Windows.Forms.Label team1L;
		private System.Windows.Forms.Label team2L;
		private System.Windows.Forms.Label finalScoreL;
		private System.Windows.Forms.Label scoreInfoL;
		private System.Windows.Forms.Button editB;
		private System.Windows.Forms.Button closeB;
		private System.Windows.Forms.PictureBox flagTeam1;
		private System.Windows.Forms.PictureBox flagTeam2;
		public System.Windows.Forms.ComboBox matchListCB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label temperatureL;
		private System.Windows.Forms.Label windSpeedL;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label humidityL;
		private System.Windows.Forms.Label label6;
	}
}