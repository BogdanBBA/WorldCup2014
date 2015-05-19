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
	public partial class FPlayOff : Form
	{
		public List<TPictureBox> PlayOffs = new List<TPictureBox>();

		public FPlayOff()
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

		private void FPlayOff_Shown(object sender, EventArgs e)
		{
			playOffImg.Image = Var.DB.PlayOffImage;
			foreach (Control control in this.Controls)
				if (control is PictureBox && ((PictureBox) control).Name[0] == 'M')
				{
					PictureBox picBox = (PictureBox) control;
					TPictureBox pic = new TPictureBox("Match " + ((PictureBox) control).Name.Substring(1, 2));
					//MessageBox.Show("created pic with Info = " + pic.Information);
					picBox.Hide();
					pic.Parent = this;
					pic.SetBounds(picBox.Left, picBox.Top, picBox.Width, picBox.Height);
					pic.Cursor = Cursors.Hand;
					pic.MouseEnter += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseEnter);
					pic.MouseLeave += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseLeave);
					pic.Click += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_Click);
					PlayOffs.Add(pic);
				}
			playOffImg.SendToBack();
			bgImg.SendToBack();
			RefreshInformation();
		}

		public void RefreshInformation()
		{
			foreach (TPictureBox pic in PlayOffs)
				((FMain) Application.OpenForms[0]).DrawMatch(pic, false);
		}
	}
}
