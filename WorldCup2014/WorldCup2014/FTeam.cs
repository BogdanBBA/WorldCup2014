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
	public partial class FTeam : Form
	{
		public static List<TPictureBox> TeamButtons = new List<TPictureBox>();
		public static string CurrentTeam = null;
		public static List<TPictureBox> GroupMatches = new List<TPictureBox>();
		public static List<TPictureBox> PlayOffMatches = new List<TPictureBox>();

		public FTeam()
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
			for (int i = 0; i < 32; i++)
			{
				TPictureBox pic = new TPictureBox("Teambox" + (i + 1));
				pic.Parent = TeamButtonPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds((i / 4) * (48 + 8 + 7), (i % 4) * (32 + 8), 48, 32);
				pic.Click += new EventHandler(TeamButton_Click);
				TeamButtons.Add(pic);
			}
			for (int i = 1; i <= 7; i++)
			{
				TPictureBox pic = new TPictureBox("Matchbox " + i);
				pic.Parent = i <= 3 ? GroupMatchesPanel : PlayOffMatchesPanel;
				pic.Cursor = Cursors.Hand;
				pic.MouseEnter += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseEnter);
				pic.MouseLeave += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseLeave);
				pic.Click += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_Click);
				if (i <= 3)
					GroupMatches.Add(pic);
				else
					PlayOffMatches.Add(pic);
			}
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void FTeam_Shown(object sender, EventArgs e)
		{
			for (int i = 0, lastY = 0; i < 4; i++)
			{
				if (i < 3)
					GroupMatches[i].SetBounds(0, lastY, Var.MatchBoxSize.Width, Var.MatchBoxSize.Height);
				PlayOffMatches[i].SetBounds(0, lastY, Var.MatchBoxSize.Width, Var.MatchBoxSize.Height);
				lastY += Var.MatchBoxSize.Height + 8;
			}
			SelectTeam(CurrentTeam);
		}

		private void TeamButton_Click(object sender, EventArgs e)
		{
			SelectTeam(((TPictureBox) sender).Information);
		}

		public void SelectTeam(string teamID)
		{
			TTeam team = Var.DB.GetTeamByNominalID(teamID);
			CurrentTeam = team.ID;
			teamIDL.Text = team.ID;
			nameL.Text = team.Name;
			nameEnglishL.Text = team.EnglishName;
			flagImg.Image = team.FlagLarge;
			DrawTeamColors(colorImg, team.Colors);
			//
			int totalMatchesPlayed = 0;
			THalfScore score = new THalfScore(0, 0);
			List<TMatch> matches = Var.DB.GetGroupMatchesForTeam(team.ID);
			groupMatchesL.Text = string.Format("G R O U P   M A T C H E S   ({0})", Var.DB.GetGroupByTeam(team).ID);
			for (int i = 0; i < 3; i++)
			{
				TMatch match = i < matches.Count ? matches[i] : null;
				GroupMatches[i].Information = match != null ? "Match " + match.ID : "NULL";
				GroupMatches[i].Cursor = match != null ? Cursors.Hand : Cursors.Default;
				((FMain) Application.OpenForms[0]).DrawMatch(GroupMatches[i], false);
				//
				if (match != null)
				{
					if (match.Played)
						totalMatchesPlayed++;
					if (Var.DB.MatchInvolvesTeam(match, team.ID) == TMatch.HomeTeam)
						score.AddGoals(match.Score.FinalScore().Goals1, match.Score.FinalScore().Goals2);
					else if (Var.DB.MatchInvolvesTeam(match, team.ID) == TMatch.AwayTeam)
						score.AddGoals(match.Score.FinalScore().Goals2, match.Score.FinalScore().Goals1);
				}
			}
			matches = Var.DB.GetPlayOffMatchesForTeam(team.ID);
			playOffMatchesL.Text = string.Format("P L A Y - O F F   M A T C H E S   ({0})", matches.Count);
			for (int i = 0; i < 4; i++)
			{
				TMatch match = i < matches.Count ? matches[i] : null;
				PlayOffMatches[i].Information = match != null ? "Match " + match.ID : "NULL";
				PlayOffMatches[i].Cursor = match != null ? Cursors.Hand : Cursors.Default;
				((FMain) Application.OpenForms[0]).DrawMatch(PlayOffMatches[i], false);
				//
				if (match != null)
				{
					if (match.Played)
					{
						totalMatchesPlayed++;
						for (int h = 0; h < (4 <= match.Score.Halves.Count ? 4 : match.Score.Halves.Count); h++)
							if (Var.DB.MatchInvolvesTeam(match, team.ID) == TMatch.HomeTeam)
								score.AddGoals(match.Score.Halves[h].Goals1, match.Score.Halves[h].Goals2);
							else if (Var.DB.MatchInvolvesTeam(match, team.ID) == TMatch.AwayTeam)
								score.AddGoals(match.Score.Halves[h].Goals2, match.Score.Halves[h].Goals1);
					}
				}
			}
			goalsL.Text = string.Format("{0} - {1}", score.Goals1, score.Goals2);
			double gf = totalMatchesPlayed > 0 ? (double) score.Goals1 / totalMatchesPlayed : 0;
			double ga = totalMatchesPlayed > 0 ? (double) score.Goals2 / totalMatchesPlayed : 0;
			averageGoalsL.Text = string.Format("{0} - {1}", gf.ToString("F2"), ga.ToString("F2"));
			TPlayerCountry pCountry = Var.PDB.GetCountryByID(team.ID);
			playersL.Text = pCountry.Players.Count.ToString();
		}

		private void DrawTeamColors(PictureBox pic, List<Color> colors)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);

			for (int i = 0, w = pic.Width / colors.Count; i < colors.Count; i++)
			{
				Brush bgBrush = new SolidBrush(colors[i]);
				g.FillRectangle(bgBrush, i * w, 0, pic.Width, pic.Height);
			}

			pic.Image = bmp;
		}

		private void groupMatchesL_MouseEnter(object sender, EventArgs e)
		{
			((Label) sender).ForeColor = Color.Wheat;
		}

		private void groupMatchesL_MouseLeave(object sender, EventArgs e)
		{
			((Label) sender).ForeColor = Color.Honeydew;
		}

		private void groupMatchesL_Click(object sender, EventArgs e)
		{
			string s = ((Label) sender).Text;
			s = s.Substring(s.IndexOf('(') + 1, 2);
			if (Var.DB.GetGroupByID(s) == null)
				return;
			FGroup gf = Var.GroupForm;
			gf.Show();
			gf.SelectGroup(s);
			gf.DrawGroupButton(gf.GetTPictureBoxByGroupID(s), false);
			gf.BringToFront();
			Var.CloseAllNonMainFormsExcept(gf);
		}

		private void label5_MouseEnter(object sender, EventArgs e)
		{
			playersL.ForeColor = Color.Wheat;
		}

		private void label5_MouseLeave(object sender, EventArgs e)
		{
			playersL.ForeColor = Color.White;
		}

		private void label5_Click(object sender, EventArgs e)
		{
			FPlayers pf = Var.PlayersForm;
			pf.Show();
			pf.SetTimerToSelectTeam(Var.DB.GetTeamByNominalID(teamIDL.Text));
			Var.CloseAllNonMainFormsExcept(pf);
		}
	}
}
