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
	public partial class FGroup : Form
	{
		public static List<TPictureBox> GroupButtons = new List<TPictureBox>();
		public static string CurrentGroup = null;
		public static List<TPictureBox> StandingsLines = new List<TPictureBox>();
		public static List<TPictureBox> GroupMatches = new List<TPictureBox>();

		public FGroup()
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
			// CREATE AND FORMAT BUTTONS
			for (int i = 0, w = GroupButtonPanel.Width / 8; i < 8; i++)
			{
				TPictureBox pic = new TPictureBox("G" + (char) (65 + i));
				pic.Parent = GroupButtonPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(i * w, 0, w, 47);
				pic.MouseEnter += new EventHandler(GroupButton_MouseEnter);
				pic.MouseLeave += new EventHandler(GroupButton_MouseLeave);
				pic.Click += new EventHandler(GroupButton_Click);
				GroupButtons.Add(pic);
			}
			for (int i = 1, lastY = 44; i <= 4; i++)
			{
				TPictureBox pic = new TPictureBox("Standingsbox " + i);
				pic.Parent = StandingsPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(0, lastY, StandingsPanel.Width, i == 1 ? 50 : 47);
				lastY += i == 1 ? 50 : 47;
				pic.MouseEnter += new EventHandler(StandingsLine_MouseEnter);
				pic.MouseLeave += new EventHandler(StandingsLine_MouseLeave);
				pic.Click += new EventHandler(StandingsLine_Click);
				StandingsLines.Add(pic);
			}
			for (int i = 1, lastY = 0; i <= 6; i++)
			{
				TPictureBox pic = new TPictureBox("Matchbox " + i);
				pic.Parent = GroupMatchesPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(0, lastY, 230, 28);
				lastY += 28 + 8;
				pic.MouseEnter += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseEnter);
				pic.MouseLeave += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseLeave);
				pic.Click += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_Click);
				GroupMatches.Add(pic);
			}
		}

		public TPictureBox GetTPictureBoxByGroupID(string groupID)
		{
			foreach (TPictureBox pic in GroupButtons)
				if (pic.Information.Equals(groupID))
					return pic;
			return null;
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void FGroup_Shown(object sender, EventArgs e)
		{
			RefreshGroupButtons();
		}

		private void RefreshGroupButtons()
		{
			foreach (TPictureBox pic in GroupButtons)
				DrawGroupButton(pic, false);
		}

		private void RefreshStandings()
		{
			foreach (TPictureBox pic in StandingsLines)
				DrawStandlingsLine(pic, false);
		}

		public void SelectGroup(string groupID)
		{
			foreach (TPictureBox pic in GroupButtons)
				if (pic.Information.Equals(groupID))
					GroupButton_Click(pic, null);
		}

		// MOUSE OVER

		private void GroupButton_MouseEnter(object sender, EventArgs e)
		{
			DrawGroupButton((TPictureBox) sender, true);
		}

		private void GroupButton_MouseLeave(object sender, EventArgs e)
		{
			DrawGroupButton((TPictureBox) sender, false);
		}

		private void StandingsLine_MouseEnter(object sender, EventArgs e)
		{
			DrawStandlingsLine((TPictureBox) sender, true);
		}

		private void StandingsLine_MouseLeave(object sender, EventArgs e)
		{
			DrawStandlingsLine((TPictureBox) sender, false);
		}

		// MOUSE CLICK

		private void GroupButton_Click(object sender, EventArgs e)
		{
			TGroup group = Var.DB.GetGroupByID(((TPictureBox) sender).Information);
			CurrentGroup = group.ID;
			groupIDL.Text = group.ID;
			groupNameL.Text = group.Name;

			int a = Var.DB.MatchesPlayedInGroup(CurrentGroup), b = Var.DB.TotalMatchesPlayed();
			double f = b != 0 ? (double) (100 * a) / b : 0;
			matchesPlayedL.Text = string.Format("{0} / {1} ({2}%)", a, b, f.ToString("F2"));
			a = Var.DB.GoalsScoredInGroup(CurrentGroup);
			b = Var.DB.TotalGoalsScored();
			f = b != 0 ? (double) (100 * a) / b : 0;
			goalsScoredL.Text = string.Format("{0} / {1} ({2}%)", a, b, f.ToString("F2"));

			List<TMatch> matches = Var.DB.GetMatchesForGroup(group.ID);
			for (int i = 0; i < 6; i++)
			{
				TMatch match = i < matches.Count ? matches[i] : null;
				GroupMatches[i].Information = match != null ? "Match " + match.ID : "NULL";
				GroupMatches[i].Cursor = match != null ? Cursors.Hand : Cursors.Default;
				((FMain) Application.OpenForms[0]).DrawMatch(GroupMatches[i], false);
			}

			RefreshGroupButtons();
			DrawGroupButton((TPictureBox) sender, true);
			RefreshStandings();
		}

		private void StandingsLine_Click(object sender, EventArgs e)
		{
			string s = ((TPictureBox) sender).Information;
			FTeam tf = Var.TeamForm;
			tf.Show();
			tf.BringToFront();
			tf.SelectTeam(Var.DB.GetGroupByID(groupIDL.Text).Teams[Int32.Parse(s.Substring(s.IndexOf(' ') + 1)) - 1].Team.ID);
			Var.CloseAllNonMainFormsExcept(tf);
		}

		// DRAW

		public void DrawGroupButton(TPictureBox pic, bool Selected)
		{
			TGroup group = Var.DB.GetGroupByID(pic.Information);

			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font = ((FMain) Application.OpenForms[0]).GroupTableTitleL.Font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);

			g.DrawString(group.Name, font, textBrush,
				pic.Width / 2 - (int) g.MeasureString(group.Name, font).Width / 2,
				47 / 2 - (int) g.MeasureString(group.Name, font).Height / 2);

			if (pic.Information.Equals(CurrentGroup))
				g.FillRectangle(textBrush, 0, pic.Height - 3, pic.Width, pic.Height);

			pic.Image = bmp;
		}

		private Point GetCoords(string S, Graphics g, Font font, int fromX, int width)
		{
			int x = fromX + width / 2 - (int) g.MeasureString(S, font).Width / 2;
			int y = 23 - (int) g.MeasureString(S, font).Height / 2;
			return new Point(x, y);
		}

		private Point GetCoords(Bitmap bmp, int fromX, int width)
		{
			int x = fromX + width / 2 - bmp.Width / 2;
			int y = 24 - bmp.Height / 2;
			return new Point(x, y);
		}

		private void DrawStandlingsLine(TPictureBox pic, bool Selected)
		{
			TGroup group = Var.DB.GetGroupByID(groupIDL.Text);
			TTablePosition pos = group.Teams[Int32.Parse(pic.Information.Substring(pic.Information.IndexOf(' ') + 1)) - 1];

			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);

			if (pic == StandingsLines[0])
				g.FillRectangle(new SolidBrush(Color.Wheat), 0, 0, pic.Width, 3);

			string s = pic.Information.Substring(pic.Information.IndexOf(' ')) + ".";
			font = TeamBoldFontL.Font;
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label1.Left, label1.Width));

			g.DrawImage(pos.Team.FlagMediumSmall, GetCoords(pos.Team.FlagMediumSmall, label1.Width, pos.Team.FlagMediumSmall.Width));

			s = pos.Team.Name;
			g.DrawString(s, font, textBrush, GetCoords(pos.Team.FlagMedium, label1.Width, pos.Team.FlagMedium.Width).X + pos.Team.FlagMedium.Width + 8, GetCoords(s, g, font, label1.Left, label1.Width).Y);

			font = TeamFontL.Font;
			s = pos.MP.ToString();
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label3.Left, label3.Width));

			s = pos.W.ToString();
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label4.Left, label4.Width));

			s = pos.D.ToString();
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label5.Left, label5.Width));

			s = pos.L.ToString();
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label6.Left, label6.Width));

			s = pos.GF.ToString() + "-" + pos.GA.ToString();
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label7.Left, label7.Width));

			s = TDatabase.FormatGoalDifference(pos.GDiff);
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label8.Left, label8.Width));

			font = TeamBoldFontL.Font;
			s = pos.Points.ToString();
			g.DrawString(s, font, textBrush, GetCoords(s, g, font, label9.Left, label9.Width));

			pic.Image = bmp;
		}
	}
}
