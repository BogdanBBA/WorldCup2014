using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup2014
{
	public partial class FAbout : Form
	{
		public FAbout()
		{
			InitializeComponent();
			bgImg.SetBounds(0, 0, this.Width, this.Height);
			bgImg.SendToBack();
			Var.PaintBackgroundImage(bgImg);
			foreach (Control control in this.Controls)
				if (control is Label)
					((Label) control).BackColor = FMain.BackgroundColor;
				else if (control is PictureBox)
					((PictureBox) control).BackColor = FMain.BackgroundColor;
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void FAbout_Shown(object sender, EventArgs e)
		{
			logoImg.Image = Var.DB.LogoSmallImage;
			RefreshInformation();
		}

		public void RefreshInformation()
		{
			teamSupportImg.Image = Var.DB.Settings.FavoriteTeam.FlagSmall;
			teamSupportL.Text = string.Format("Go {0}!", Var.DB.Settings.FavoriteTeam.EnglishName);
			//
			int w = teamSupportImg.Width + 8 + teamSupportL.Width;
			teamSupportImg.Left = logoImg.Left + logoImg.Width / 2 - w / 2;
			teamSupportL.Left = teamSupportImg.Right + 8;
		}
	}
}
