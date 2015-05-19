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
	public partial class FMenu : Form
	{
		private static string[] ButtonCaptions = new string[6] { "Matchdays", "Match conditions", "Players", "Statistics", "SETTINGS", "CLOSE" };
		public static List<TPictureBox> MenuButtons = new List<TPictureBox>();

		public FMenu()
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
				else if (control is Panel)
					((Panel) control).BackColor = FMain.BackgroundColor;
			//
			for (int i = 0; i < ButtonCaptions.Length; i++)
			{
				TPictureBox pic = new TPictureBox(ButtonCaptions[i]);
				pic.Parent = ButtonPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(0, i * 60, 300, 60);
				pic.MouseEnter += new EventHandler(MenuButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MenuButton_MouseLeave);
				pic.Click += new EventHandler(MenuButton_Click);
				MenuButtons.Add(pic);
			}
			MenuButtons[ButtonCaptions.Length - 1].Top = MenuButtons[ButtonCaptions.Length - 1].Top + 30;
		}

		public void RefreshMenuButtons()
		{
			foreach (TPictureBox pic in MenuButtons)
				DrawMenuButton(pic, false);
		}

		private void MenuButton_MouseEnter(object sender, EventArgs e)
		{
			DrawMenuButton((TPictureBox) sender, true);
		}

		private void MenuButton_MouseLeave(object sender, EventArgs e)
		{
			DrawMenuButton((TPictureBox) sender, false);
		}

		//

		private Point GetCenteredCoordsMB(string S, Graphics g, Font font, int fromX, int width)
		{
			int x = fromX + width / 2 - (int) g.MeasureString(S, font).Width / 2;
			int y = 30 - (int) g.MeasureString(S, font).Height / 2;
			return new Point(x, y);
		}

		private void DrawMenuButton(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);

			Point p = GetCenteredCoordsMB(pic.Information, g, GroupTableTitleL.Font, 0, 300);
			g.DrawString(pic.Information, GroupTableTitleL.Font, textBrush, p);

			pic.Image = bmp;
		}

		private void MenuButton_Click(object sender, EventArgs e)
		{
			int r = -1;
			for (int i = 0; i < MenuButtons.Count; i++)
				if (ButtonCaptions[i].Equals(((TPictureBox) sender).Information))
					r = i;
			switch (r)
			{
				// matchdays
				case 0:
					{
						FMatchDay mdf = Var.MatchDayForm;
						mdf.Show();
						mdf.BringToFront();
						FMatchDay.CurrentMatchDay = TDatabase.EncodeDate(Var.DB.GetFirstUnplayedMatchDate());
						mdf.refreshInfoTimer.Enabled = true;
						Var.CloseAllNonMainFormsExcept(mdf);
						break;
					}
				// match conditions
				case 1:
					{
						FMatchConditions mc = Var.MatchConditionsForm;
						mc.Show();
						mc.BringToFront();
						mc.RefreshMatchList();
						Var.CloseAllNonMainFormsExcept(mc);
						break;
					}
				// players
				case 2:
					{
						FPlayers pf = Var.PlayersForm;
						pf.Show();
						pf.BringToFront();
						pf.SetTimerToSelectTeam(Var.DB.Settings.FavoriteTeam);
						Var.CloseAllNonMainFormsExcept(pf);
						break;
					}
				// statistics
				case 3:
					{
						FStatistics sf = Var.StatsForm;
						sf.Show();
						sf.BringToFront();
						sf.RefreshStatistics();
						Var.CloseAllNonMainFormsExcept(sf);
						break;
					}
				// settings
				case 4:
					{
						FSettings sf = Var.SettingsForm;
						sf.Show();
						sf.BringToFront();
						sf.RefreshSettings();
						Var.CloseAllNonMainFormsExcept(sf);
						break;
					}
				// close
				case 5:
					{ Var.CloseAllNonMainFormsExcept(null); break; }
			}
		}
	}
}
