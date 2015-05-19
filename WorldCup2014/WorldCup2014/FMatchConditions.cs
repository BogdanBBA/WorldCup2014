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
	public partial class FMatchConditions : Form
	{
		public static List<TPictureBox> MenuButtons = new List<TPictureBox>();
		public static List<TPictureBox> MatchesInfo = new List<TPictureBox>();
		private static List<TMatch> Matches;

		private static int MatchesStartIndex = 0, SortingCriteria = 1;

		public FMatchConditions()
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
			for (int i = 0, k = 1, h = MenuButtonPanel.Height / 4; i < 4; i++, k = i * 16 + 1)
			{
				TPictureBox pic = new TPictureBox(string.Format("Matches {0}-{1}", k, k + 15));
				pic.Parent = MenuButtonPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(0, i * h, MenuButtonPanel.Width, h);
				pic.MouseEnter += new EventHandler(MenuButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MenuButton_MouseLeave);
				pic.Click += new EventHandler(MenuButton_Click);
				MenuButtons.Add(pic);
			}
			for (int i = 1, lastY = 37; i <= 16; i++)
			{
				TPictureBox pic = new TPictureBox("NULL");
				pic.Parent = MatchPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(0, lastY, MatchPanel.Width, i == 1 ? 31 : 28);
				lastY += i == 1 ? 31 : 28;
				pic.MouseEnter += new EventHandler(MatchInfo_MouseEnter);
				pic.MouseLeave += new EventHandler(MatchInfo_MouseLeave);
				pic.Click += new EventHandler(MatchInfo_Click);
				MatchesInfo.Add(pic);
			}
		}

		private void FMatchConditions_Shown(object sender, EventArgs e)
		{
			RefreshMenuButtons();
		}

		private void RefreshMenuButtons()
		{
			foreach (TPictureBox pic in MenuButtons)
				DrawMenuButton(pic, false);
		}

		public void RefreshMatchList()
		{
			Matches = Var.DB.GetAllMatches();
			TDatabase.SortMatches(Matches, 1);
			MenuButton_Click(MenuButtons[0], null);
		}

		private int DecodeMenuButtonStartIndex(string s)
		{
			s = s.Substring(s.IndexOf(' ') + 1);
			return Int32.Parse(s.Substring(0, s.IndexOf('-')));
		}

		private void MenuButton_Click(object sender, EventArgs e)
		{
			MatchesStartIndex = DecodeMenuButtonStartIndex(((TPictureBox) sender).Information) - 1;
			RefreshMenuButtons();
			DrawMenuButton((TPictureBox) sender, true);
			RefreshMatchesInfo();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			SortingCriteria = Int32.Parse(((Label) sender).Name[5].ToString());
			TDatabase.SortMatches(Matches, SortingCriteria);
			RefreshMatchesInfo();
		}

		private void RefreshMatchesInfo()
		{
			for (int i = 0, k = i + MatchesStartIndex; i < 16; i++, k++)
			{
				MatchesInfo[i].Information = "Match " + Matches[k].ID;
				DrawMatchInfo(MatchesInfo[i], false);
			}
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
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

		private void MatchInfo_MouseEnter(object sender, EventArgs e)
		{
			DrawMatchInfo((TPictureBox) sender, true);
		}

		private void MatchInfo_MouseLeave(object sender, EventArgs e)
		{
			DrawMatchInfo((TPictureBox) sender, false);
		}

		// DRAW

		private Point GetCenteredCoordsMB(string S, Graphics g, Font font, int fromY, int height)
		{
			int x = MenuButtonPanel.Width / 2 - (int) g.MeasureString(S, font).Width / 2;
			int y = fromY + height / 2 - (int) g.MeasureString(S, font).Height / 2;
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

			if (MatchesStartIndex + 1 == DecodeMenuButtonStartIndex(pic.Information))
				g.FillRectangle(textBrush, 0, pic.Height - 3, pic.Width, pic.Height);

			Point p = GetCenteredCoordsMB(pic.Information, g, GroupTableTitleL.Font, 0, MenuButtonPanel.Height / 4);
			g.DrawString(pic.Information, GroupTableTitleL.Font, textBrush, p);

			pic.Image = bmp;
		}

		private Point GetCenteredCoordsP(string S, Graphics g, Font font, int fromX, int width)
		{
			int x = fromX + width / 2 - (int) g.MeasureString(S, font).Width / 2;
			int y = 15 - (int) g.MeasureString(S, font).Height / 2;
			return new Point(x, y);
		}

		private void DrawMatchInfo(TPictureBox pic, bool Selected)
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

			TMatch match = Var.DB.GetMatchByID(Int32.Parse(pic.Information.Substring(6)));
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font;
			string s;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);

			if (pic == MatchesInfo[0])
				g.FillRectangle(new SolidBrush(Color.Wheat), 0, 0, pic.Width, 3);

			font = thickerFontL.Font;
			s = match.ID.ToString();
			Point p = GetCenteredCoordsP(s, g, font, label1.Left, label1.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			s = match.Type[0] == 'G' ? "Group " + match.Type[1] : TDatabase.PlayOffPhaseName(match.Type);
			p = GetCenteredCoordsP(s, g, font, label9.Left, label9.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			font = regularFontL.Font;
			s = match.When.ToString("ddd, MMMM d, HH:mm");
			p = GetCenteredCoordsP(s, g, font, label2.Left, label2.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			font = thickerFontL.Font;
			s = match.Where.City;
			p = GetCenteredCoordsP(s, g, font, label3.Left, label3.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			//

			Font resFont = match.Played ? GroupTableContent2L.Font : MatchHourFontL.Font;

			TTeam team1 = Var.DB.GetTeamReferenceType(match.Team1Ref) == TTeam.NominalTeamReference ? Var.DB.GetTeamByNominalID(match.Team1Ref) : Var.DB.GetTeamByPlayOffReference(match.Team1Ref);
			TTeam team2 = Var.DB.GetTeamReferenceType(match.Team2Ref) == TTeam.NominalTeamReference ? Var.DB.GetTeamByNominalID(match.Team2Ref) : Var.DB.GetTeamByPlayOffReference(match.Team2Ref);

			team1 = team1 == null ? Var.DB.UnknownTeam : team1;
			team2 = team2 == null ? Var.DB.UnknownTeam : team2;

			s = match.Played ? match.FormatScore() : string.Format("{0}@{1}", match.When.ToString("ddd"), match.When.ToString("HH"));
			int xm = label4.Left + label4.Width / 2, x = xm - (int) g.MeasureString(s, font).Width / 2;
			g.DrawString(s, font, Brushes.Wheat, new Point(x, pic.Height / 2 - (int) g.MeasureString(s, font).Height / 2));

			x = xm - 25 - 4 - team1.FlagSmall.Width;
			g.DrawImage(team1.FlagSmall, new Point(x, 6));
			g.DrawImage(team2.FlagSmall, new Point(xm + 25 + 4, 6));

			s = team1.ID;
			font = MatchTeamFontL.Font;
			x -= (int) g.MeasureString(s, font).Width + 6;
			g.DrawString(s, font, textBrush, new Point(x, pic.Height / 2 - (int) g.MeasureString(s, font).Height / 2));

			s = team2.ID;
			x = xm + 25 + 4 + team2.FlagSmall.Width + 4;
			g.DrawString(s, font, textBrush, new Point(x, pic.Height / 2 - (int) g.MeasureString(s, font).Height / 2));

			//

			font = valuesFontL.Font;
			s = match.Conditions.Temperature + "°";
			p = GetCenteredCoordsP(s, g, font, label5.Left, label5.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			s = match.Conditions.WindSpeed + " m/s";
			p = GetCenteredCoordsP(s, g, font, label6.Left, label6.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			s = match.Conditions.RelativeHumidity + "%";
			p = GetCenteredCoordsP(s, g, font, label7.Left, label7.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			font = thickerValuesFontL.Font;
			s = match.ConditionAverage().ToString("0.00");
			p = GetCenteredCoordsP(s, g, font, label8.Left, label8.Width);
			p.Y += pic.Equals(MatchesInfo[0]) ? 3 : 0;
			g.DrawString(s, font, textBrush, p);

			pic.Image = bmp;
		}

		public void MatchInfo_Click(object sender, EventArgs e)
		{
			TMatch match = Var.DB.GetMatchByID(Int32.Parse(((TPictureBox) sender).Information.Substring(6)));
			FMatch mf = Var.MatchForm;
			mf.Show();
			mf.BringToFront();
			mf.RefreshMatchList();
			mf.matchListCB.SelectedIndex = mf.matchListCB.Items.IndexOf(Var.DB.EncodeMatchForMatchList(match));
			Var.CloseAllNonMainFormsExcept(mf);
		}
	}
}
