namespace WorldCup2014
{
	partial class FMenu
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
			this.ButtonPanel = new System.Windows.Forms.Panel();
			this.GroupTableTitleL = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).BeginInit();
			this.SuspendLayout();
			// 
			// bgImg
			// 
			this.bgImg.Location = new System.Drawing.Point(12, 12);
			this.bgImg.Name = "bgImg";
			this.bgImg.Size = new System.Drawing.Size(100, 50);
			this.bgImg.TabIndex = 21;
			this.bgImg.TabStop = false;
			// 
			// ButtonPanel
			// 
			this.ButtonPanel.Location = new System.Drawing.Point(27, 27);
			this.ButtonPanel.Name = "ButtonPanel";
			this.ButtonPanel.Size = new System.Drawing.Size(300, 390);
			this.ButtonPanel.TabIndex = 22;
			// 
			// GroupTableTitleL
			// 
			this.GroupTableTitleL.AutoSize = true;
			this.GroupTableTitleL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupTableTitleL.Location = new System.Drawing.Point(153, -8);
			this.GroupTableTitleL.Name = "GroupTableTitleL";
			this.GroupTableTitleL.Size = new System.Drawing.Size(209, 32);
			this.GroupTableTitleL.TabIndex = 45;
			this.GroupTableTitleL.Text = "GroupTableTitleL";
			this.GroupTableTitleL.Visible = false;
			// 
			// FMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(354, 448);
			this.ControlBox = false;
			this.Controls.Add(this.GroupTableTitleL);
			this.Controls.Add(this.ButtonPanel);
			this.Controls.Add(this.bgImg);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FMenu";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FMenu";
			((System.ComponentModel.ISupportInitialize)(this.bgImg)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox bgImg;
		private System.Windows.Forms.Panel ButtonPanel;
		public System.Windows.Forms.Label GroupTableTitleL;
	}
}