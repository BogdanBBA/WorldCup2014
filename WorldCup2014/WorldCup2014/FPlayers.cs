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
	public partial class FPlayers : Form
	{
		public static List<TPictureBox> MenuButtons = new List<TPictureBox>();
		public static List<TPictureBox> Players = new List<TPictureBox>();

		public static bool ShowingCountries = true;
		private static TTeam TeamToBeSelected = null;
		private static int SortingCriteria = 1;

		public FPlayers()
		{
			InitializeComponent();
			bgImg.SetBounds(0, 0, this.Width, this.Height);
			bgImg.SendToBack();
			Var.PaintBackgroundImage(bgImg);
			foreach (Control control in this.Controls)
				if (control is Label)
					((Label) control).BackColor = FMain.BackgroundColor;
				else if (control is Panel)
					((Panel) control).BackColor = FMain.BackgroundColor;
				else if (control is PictureBox)
					((PictureBox) control).BackColor = FMain.BackgroundColor;
			//
			for (int i = 0, w = MenuButtonPanel.Width / 2; i < 2; i++)
			{
				TPictureBox pic = new TPictureBox(i == 0 ? "Countries" : "Clubs");
				pic.Parent = MenuButtonPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(i * w, 0, w, MenuButtonPanel.Height);
				pic.MouseEnter += new EventHandler(MenuButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MenuButton_MouseLeave);
				pic.Click += new EventHandler(MenuButton_Click);
				MenuButtons.Add(pic);
			}
			for (int i = 1, lastY = 37; i <= 23; i++)
			{
				TPictureBox pic = new TPictureBox("NULL");
				pic.Parent = PlayerPanel;
				pic.SetBounds(0, lastY, PlayerPanel.Width, i == 1 ? 23 : 20);
				lastY += i == 1 ? 23 : 20;
				pic.MouseEnter += new EventHandler(Player_MouseEnter);
				pic.MouseLeave += new EventHandler(Player_MouseLeave);
				Players.Add(pic);
			}
		}

		private void FPlayers_Shown(object sender, EventArgs e)
		{
			RefreshMenuButtons();
		}

		private void RefreshMenuButtons()
		{
			DrawMenuButton(MenuButtons[0], false);
			DrawMenuButton(MenuButtons[1], false);
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		// DRAW

		private Point GetCenteredCoordsMB(string S, Graphics g, Font font, int fromX, int width)
		{
			int x = fromX + width / 2 - (int) g.MeasureString(S, font).Width / 2;
			int y = MenuButtonPanel.Height / 2 - (int) g.MeasureString(S, font).Height / 2;
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

			Point p = GetCenteredCoordsMB(pic.Information, g, GroupTableTitleL.Font, 0, MenuButtonPanel.Width / 2);
			g.DrawString(pic.Information, GroupTableTitleL.Font, textBrush, p);

			if (ShowingCountries == pic.Equals(MenuButtons[0]))
				g.FillRectangle(textBrush, 0, pic.Height - 3, pic.Width, pic.Height);

			pic.Image = bmp;
		}

		private Color GetColorForPosition(string s)
		{
			if (s.Equals("GK"))
				return System.Drawing.ColorTranslator.FromHtml("#FF8800");
			if (s.Equals("DF"))
				return System.Drawing.ColorTranslator.FromHtml("#2DB300");
			if (s.Equals("MF"))
				return System.Drawing.ColorTranslator.FromHtml("#0059B3");
			if (s.Equals("FW"))
				return System.Drawing.ColorTranslator.FromHtml("#C41247");
			return System.Drawing.ColorTranslator.FromHtml("#DDDDDD");
		}

		private Point GetCenteredCoordsP(string S, Graphics g, Font font, int fromX, int width)
		{
			int x = fromX + width / 2 - (int) g.MeasureString(S, font).Width / 2;
			int y = 10 - (int) g.MeasureString(S, font).Height / 2;
			return new Point(x, y);
		}

		private void DrawPlayer(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);

			if (pic.Information.Equals("NULL"))
			{
				g.FillRectangle(new SolidBrush(FMain.BackgroundColor), 0, 0, pic.Width, pic.Height);
				pic.Image = bmp;
				return;
			}

			TPlayer player = pic.Information[0] == 'C' ? Var.PDB.GetPlayerByCountryAndID(pic.Information.Substring(1)) : Var.PDB.GetPlayerByClubAndID(pic.Information.Substring(1));
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);

			if (pic == Players[0])
				g.FillRectangle(new SolidBrush(Color.Wheat), 0, 0, pic.Width, 3);

			string s = player.Number;
			font = regularFontL.Font;
			Point p = GetCenteredCoordsP(s, g, font, label1.Left, label1.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			s = player.BirthDate.ToString("d MMM yyyy");
			p = GetCenteredCoordsP(s, g, font, label4.Left, label4.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			s = player.Caps.ToString();
			p = GetCenteredCoordsP(s, g, font, label6.Left, label6.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			s = player.Position;
			font = positionFontL.Font;
			p = GetCenteredCoordsP(s, g, font, label3.Left, label3.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.FillRectangle(new SolidBrush(GetColorForPosition(s)), label3.Left + 10, p.Y - 1, 30, 16);
			g.DrawString(s, font, new SolidBrush(Color.White), p);

			s = player.Name;
			font = playerNameFontL.Font;
			p = GetCenteredCoordsP(s, g, font, label2.Left, label2.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, label2.Left + 32 + 20, p.Y);

			s = player.Club.Name;
			p = GetCenteredCoordsP(s, g, font, label7.Left, label7.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, label7.Left + 32 + 20, p.Y);

			s = TPlayerDatabase.GetPlayerAgeForWorldCup(player.BirthDate).ToString();
			p = GetCenteredCoordsP(s, g, font, label5.Left, label5.Width);
			p.Y += pic.Equals(Players[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			g.DrawImage(player.Country.Flag, label2.Left + 20, pic.Equals(Players[0]) ? 5 : 2);
			g.DrawImage(player.Club.Country.Flag, label7.Left + 20, pic.Equals(Players[0]) ? 5 : 2);

			pic.Image = bmp;
		}

		// MOUSE

		private void MenuButton_MouseEnter(object sender, EventArgs e)
		{
			DrawMenuButton((TPictureBox) sender, true);
		}

		private void MenuButton_MouseLeave(object sender, EventArgs e)
		{
			DrawMenuButton((TPictureBox) sender, false);
		}

		private void Player_MouseEnter(object sender, EventArgs e)
		{
			DrawPlayer((TPictureBox) sender, true);
		}

		private void Player_MouseLeave(object sender, EventArgs e)
		{
			DrawPlayer((TPictureBox) sender, false);
		}

		// CLICK

		public void SetTimerToSelectTeam(TTeam team)
		{
			TeamToBeSelected = team;
			selectT.Enabled = true;
		}

		private void selectT_Tick(object sender, EventArgs e)
		{
			selectT.Enabled = false;
			SelectPlayerCountry(TeamToBeSelected);
		}

		private void SelectPlayerCountry(TTeam team)
		{
			TPlayerCountry res = null;
			foreach (TPlayerCountry country in Var.PDB.Countries)
				if (country.ID.Equals(team.ID))
				{
					res = country;
					break;
				}
			if (res != null)
				SelectPlayerCountry(res);
			else
				MessageBox.Show("SelectPlayerCountry() ERROR: can not find country with teamID: " + team.ID);
		}

		private void SelectPlayerCountry(TPlayerCountry country)
		{
			//if (!ShowingCountries)
			MenuButton_Click(MenuButtons[0], null);
			listCB.SelectedIndex = listCB.Items.IndexOf(EncodePCountry(country));
		}

		private string EncodePCountry(TPlayerCountry c)
		{
			return string.Format("[{0}]: {1}", c.ID, c.Name);
		}

		private string EncodePClub(TPlayerClub c)
		{
			return string.Format("({0}): {1}", c.ID, c.Name);
		}

		private string DecodeID(string s, char c1, char c2)
		{
			int p1 = s.IndexOf(c1), p2 = s.IndexOf(c2);
			return s.Substring(p1 + 1, p2 - p1 - 1);
		}

		private void MenuButton_Click(object sender, EventArgs e)
		{
			ShowingCountries = ((TPictureBox) sender).Information.Equals("Countries");
			RefreshMenuButtons();
			DrawMenuButton((TPictureBox) sender, true);
			listCB.Items.Clear();

			if (ShowingCountries)
				foreach (TPlayerCountry country in Var.PDB.Countries)
					listCB.Items.Add(EncodePCountry(country));
			else
				foreach (TPlayerClub club in Var.PDB.Clubs)
					listCB.Items.Add(EncodePClub(club));

			listCB.SelectedIndex = 0;
		}

		private void listCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			string id = ShowingCountries ? DecodeID((string) listCB.Items[listCB.SelectedIndex], '[', ']') : DecodeID((string) listCB.Items[listCB.SelectedIndex], '(', ')');
			if (ShowingCountries)
			{
				TPlayerCountry country = Var.PDB.GetCountryByID(id);
				titleL.Text = country.Name;
				label0c.Text = "P L A Y E R S   (" + country.Players.Count + ")";
				label0d.Text = country.CoachNationality != null ? "C O A C H" : null;
				auxL.Text = country.CoachName;
				auxFlagImg.Image = country.CoachNationality != null ? country.CoachNationality.Flag : null;
				TPlayerDatabase.SortPlayers(country.Players, SortingCriteria);
				int ageSum = 0;
				for (int i = 0; i < 23; i++)
				{
					ageSum += i < country.Players.Count ? TPlayerDatabase.GetPlayerAgeForWorldCup(country.Players[i].BirthDate) : 0;
					Players[i].Information = i < country.Players.Count ? "C" + country.ID + ":" + country.Players[i].ID : "NULL";
					DrawPlayer(Players[i], false);
				}
				double f = country.Players.Count != 0 ? (double) ageSum / country.Players.Count : 0;
				ageAvgL.Text = f.ToString("F2");
			}
			else
			{
				TPlayerClub club = Var.PDB.GetClubByID(id);
				titleL.Text = club.Name;
				label0c.Text = "P L A Y E R S   (" + club.Players.Count + ")";
				label0d.Text = "L E A G U E";
				auxL.Text = club.Country.Name;
				auxFlagImg.Image = club.Country.Flag;
				TPlayerDatabase.SortPlayers(club.Players, SortingCriteria);
				int ageSum = 0;
				for (int i = 0; i < 23; i++)
				{
					ageSum += i < club.Players.Count ? TPlayerDatabase.GetPlayerAgeForWorldCup(club.Players[i].BirthDate) : 0;
					Players[i].Information = i < club.Players.Count ? "c" + club.ID + ":" + club.Players[i].ID : "NULL";
					DrawPlayer(Players[i], false);
				}
				double f = club.Players.Count != 0 ? (double) ageSum / club.Players.Count : 0;
				ageAvgL.Text = f.ToString("F2");
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			SortingCriteria = Int32.Parse(((Label) sender).Name[5].ToString());
			listCB_SelectedIndexChanged(null, null);
		}
	}
}
