namespace WorldCup2014
{
	partial class FPlayers
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
			this.positionFontL = new System.Windows.Forms.Label();
			this.playerNameFontL = new System.Windows.Forms.Label();
			this.label0c = new System.Windows.Forms.Label();
			this.PlayerPanel = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.regularFontL = new System.Windows.Forms.Label();
			this.GroupTableTitleL = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.closeB = new System.Windows.Forms.Button();
			this.bgImg = new System.Windows.Forms.PictureBox();
			this.MenuButtonPanel = new System.Windows.Forms.Panel();
			this.titleL = new System.Windows.Forms.Label();
			this.listCB = new System.Windows.Forms.ComboBox();
			this.auxL = new System.Windows.Forms.Label();
			this.auxFlagImg = new System.Windows.Forms.PictureBox();
			this.label0d = new System.Windows.Forms.Label();
			this.selectT = new System.Windows.Forms.Timer(this.components);
			this.ageAvgL = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.PlayerPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.auxFlagImg)).BeginInit();
			this.SuspendLayout();
			// 
			// positionFontL
			// 
			this.positionFontL.AutoSize = true;
			this.positionFontL.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.positionFontL.Location = new System.Drawing.Point(422, 251);
			this.positionFontL.Name = "positionFontL";
			this.positionFontL.Size = new System.Drawing.Size(80, 13);
			this.positionFontL.TabIndex = 41;
			this.positionFontL.Text = "positionFontL";
			this.positionFontL.Visible = false;
			// 
			// playerNameFontL
			// 
			this.playerNameFontL.AutoSize = true;
			this.playerNameFontL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playerNameFontL.Location = new System.Drawing.Point(422, 232);
			this.playerNameFontL.Name = "playerNameFontL";
			this.playerNameFontL.Size = new System.Drawing.Size(128, 19);
			this.playerNameFontL.TabIndex = 40;
			this.playerNameFontL.Text = "playerNameFontL";
			this.playerNameFontL.Visible = false;
			// 
			// label0c
			// 
			this.label0c.AutoSize = true;
			this.label0c.BackColor = System.Drawing.Color.Transparent;
			this.label0c.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label0c.ForeColor = System.Drawing.Color.Honeydew;
			this.label0c.Location = new System.Drawing.Point(419, 29);
			this.label0c.Name = "label0c";
			this.label0c.Size = new System.Drawing.Size(69, 15);
			this.label0c.TabIndex = 39;
			this.label0c.Text = "P L A Y E R S";
			// 
			// MatchPanel
			// 
			this.PlayerPanel.Controls.Add(this.label6);
			this.PlayerPanel.Controls.Add(this.label2);
			this.PlayerPanel.Controls.Add(this.label1);
			this.PlayerPanel.Controls.Add(this.label3);
			this.PlayerPanel.Controls.Add(this.regularFontL);
			this.PlayerPanel.Controls.Add(this.GroupTableTitleL);
			this.PlayerPanel.Controls.Add(this.label4);
			this.PlayerPanel.Controls.Add(this.label5);
			this.PlayerPanel.Controls.Add(this.label7);
			this.PlayerPanel.Controls.Add(this.positionFontL);
			this.PlayerPanel.Controls.Add(this.playerNameFontL);
			this.PlayerPanel.Location = new System.Drawing.Point(418, 47);
			this.PlayerPanel.Name = "MatchPanel";
			this.PlayerPanel.Size = new System.Drawing.Size(801, 500);
			this.PlayerPanel.TabIndex = 38;
			// 
			// label6
			// 
			this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label6.Location = new System.Drawing.Point(510, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 37);
			this.label6.TabIndex = 46;
			this.label6.Text = "Caps";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label6.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label2.Location = new System.Drawing.Point(50, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(240, 37);
			this.label2.TabIndex = 2;
			this.label2.Text = "Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label2.Click += new System.EventHandler(this.label1_Click);
			// 
			// label1
			// 
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 37);
			this.label1.TabIndex = 0;
			this.label1.Text = "No";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label3
			// 
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label3.Location = new System.Drawing.Point(290, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 37);
			this.label3.TabIndex = 3;
			this.label3.Text = "Pos";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.Click += new System.EventHandler(this.label1_Click);
			// 
			// regularFontL
			// 
			this.regularFontL.AutoSize = true;
			this.regularFontL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.regularFontL.Location = new System.Drawing.Point(422, 212);
			this.regularFontL.Name = "regularFontL";
			this.regularFontL.Size = new System.Drawing.Size(74, 15);
			this.regularFontL.TabIndex = 45;
			this.regularFontL.Text = "regularFontL";
			this.regularFontL.Visible = false;
			// 
			// GroupTableTitleL
			// 
			this.GroupTableTitleL.AutoSize = true;
			this.GroupTableTitleL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupTableTitleL.Location = new System.Drawing.Point(421, 268);
			this.GroupTableTitleL.Name = "GroupTableTitleL";
			this.GroupTableTitleL.Size = new System.Drawing.Size(209, 32);
			this.GroupTableTitleL.TabIndex = 44;
			this.GroupTableTitleL.Text = "GroupTableTitleL";
			this.GroupTableTitleL.Visible = false;
			// 
			// label4
			// 
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label4.Location = new System.Drawing.Point(340, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 37);
			this.label4.TabIndex = 4;
			this.label4.Text = "Born";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label4.Click += new System.EventHandler(this.label1_Click);
			// 
			// label5
			// 
			this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label5.Location = new System.Drawing.Point(460, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 37);
			this.label5.TabIndex = 5;
			this.label5.Text = "Age";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label5.Click += new System.EventHandler(this.label1_Click);
			// 
			// label7
			// 
			this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.LemonChiffon;
			this.label7.Location = new System.Drawing.Point(560, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(240, 37);
			this.label7.TabIndex = 6;
			this.label7.Text = "Club";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label7.Click += new System.EventHandler(this.label1_Click);
			// 
			// closeB
			// 
			this.closeB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.closeB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.closeB.Location = new System.Drawing.Point(33, 497);
			this.closeB.Name = "closeB";
			this.closeB.Size = new System.Drawing.Size(368, 50);
			this.closeB.TabIndex = 37;
			this.closeB.Text = "Close";
			this.closeB.UseVisualStyleBackColor = true;
			this.closeB.Click += new System.EventHandler(this.closeB_Click);
			// 
			// bgImg
			// 
			this.bgImg.Location = new System.Drawing.Point(12, 12);
			this.bgImg.Name = "bgImg";
			this.bgImg.Size = new System.Drawing.Size(100, 52);
			this.bgImg.TabIndex = 36;
			this.bgImg.TabStop = false;
			// 
			// MenuButtonPanel
			// 
			this.MenuButtonPanel.Location = new System.Drawing.Point(27, 29);
			this.MenuButtonPanel.Name = "MenuButtonPanel";
			this.MenuButtonPanel.Size = new System.Drawing.Size(374, 47);
			this.MenuButtonPanel.TabIndex = 35;
			// 
			// titleL
			// 
			this.titleL.BackColor = System.Drawing.Color.Transparent;
			this.titleL.Cursor = System.Windows.Forms.Cursors.Default;
			this.titleL.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleL.ForeColor = System.Drawing.Color.White;
			this.titleL.Location = new System.Drawing.Point(26, 118);
			this.titleL.Name = "titleL";
			this.titleL.Size = new System.Drawing.Size(375, 45);
			this.titleL.TabIndex = 43;
			this.titleL.Text = "titleL";
			this.titleL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listCB
			// 
			this.listCB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.listCB.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listCB.FormattingEnabled = true;
			this.listCB.IntegralHeight = false;
			this.listCB.Location = new System.Drawing.Point(27, 82);
			this.listCB.MaxDropDownItems = 16;
			this.listCB.Name = "listCB";
			this.listCB.Size = new System.Drawing.Size(374, 33);
			this.listCB.TabIndex = 42;
			this.listCB.SelectedIndexChanged += new System.EventHandler(this.listCB_SelectedIndexChanged);
			// 
			// auxL
			// 
			this.auxL.AutoSize = true;
			this.auxL.BackColor = System.Drawing.Color.Transparent;
			this.auxL.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.auxL.ForeColor = System.Drawing.Color.White;
			this.auxL.Location = new System.Drawing.Point(63, 220);
			this.auxL.Name = "auxL";
			this.auxL.Size = new System.Drawing.Size(32, 15);
			this.auxL.TabIndex = 47;
			this.auxL.Text = "auxL";
			this.auxL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// auxFlagImg
			// 
			this.auxFlagImg.Location = new System.Drawing.Point(33, 220);
			this.auxFlagImg.Name = "auxFlagImg";
			this.auxFlagImg.Size = new System.Drawing.Size(24, 16);
			this.auxFlagImg.TabIndex = 46;
			this.auxFlagImg.TabStop = false;
			// 
			// label0d
			// 
			this.label0d.AutoSize = true;
			this.label0d.BackColor = System.Drawing.Color.Transparent;
			this.label0d.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label0d.ForeColor = System.Drawing.Color.Honeydew;
			this.label0d.Location = new System.Drawing.Point(30, 202);
			this.label0d.Name = "label0d";
			this.label0d.Size = new System.Drawing.Size(69, 15);
			this.label0d.TabIndex = 48;
			this.label0d.Text = "P L A Y E R S";
			// 
			// selectT
			// 
			this.selectT.Tick += new System.EventHandler(this.selectT_Tick);
			// 
			// ageAvgL
			// 
			this.ageAvgL.AutoSize = true;
			this.ageAvgL.BackColor = System.Drawing.Color.Transparent;
			this.ageAvgL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ageAvgL.ForeColor = System.Drawing.Color.Honeydew;
			this.ageAvgL.Location = new System.Drawing.Point(27, 274);
			this.ageAvgL.Name = "ageAvgL";
			this.ageAvgL.Size = new System.Drawing.Size(106, 32);
			this.ageAvgL.TabIndex = 50;
			this.ageAvgL.Text = "ageAvgL";
			this.ageAvgL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Honeydew;
			this.label11.Location = new System.Drawing.Point(30, 259);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(109, 15);
			this.label11.TabIndex = 49;
			this.label11.Text = "A G E   A V E R A G E";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FPlayers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(1239, 581);
			this.ControlBox = false;
			this.Controls.Add(this.ageAvgL);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label0d);
			this.Controls.Add(this.auxL);
			this.Controls.Add(this.auxFlagImg);
			this.Controls.Add(this.titleL);
			this.Controls.Add(this.listCB);
			this.Controls.Add(this.label0c);
			this.Controls.Add(this.PlayerPanel);
			this.Controls.Add(this.closeB);
			this.Controls.Add(this.bgImg);
			this.Controls.Add(this.MenuButtonPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FPlayers";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FPlayers";
			this.Shown += new System.EventHandler(this.FPlayers_Shown);
			this.PlayerPanel.ResumeLayout(false);
			this.PlayerPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.auxFlagImg)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label positionFontL;
		public System.Windows.Forms.Label playerNameFontL;
		private System.Windows.Forms.Label label0c;
		private System.Windows.Forms.Panel PlayerPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button closeB;
		private System.Windows.Forms.PictureBox bgImg;
		private System.Windows.Forms.Panel MenuButtonPanel;
		private System.Windows.Forms.Label titleL;
		public System.Windows.Forms.ComboBox listCB;
		public System.Windows.Forms.Label GroupTableTitleL;
		public System.Windows.Forms.Label regularFontL;
		private System.Windows.Forms.Label auxL;
		private System.Windows.Forms.PictureBox auxFlagImg;
		private System.Windows.Forms.Label label0d;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Timer selectT;
		private System.Windows.Forms.Label ageAvgL;
		private System.Windows.Forms.Label label11;
	}
}