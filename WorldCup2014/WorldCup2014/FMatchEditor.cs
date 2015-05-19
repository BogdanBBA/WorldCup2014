using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup2014
{
	public partial class FMatchEditor : Form
	{
		public FMatchEditor()
		{
			InitializeComponent();
			bgImg.SetBounds(0, 0, this.Width, this.Height);
			bgImg.SendToBack();
			Var.PaintBackgroundImage(bgImg);
			foreach (Control control in this.Controls)
				if (control is Label)
					((Label) control).BackColor = FMain.BackgroundColor;
				else if (control is CheckBox)
					((CheckBox) control).BackColor = FMain.BackgroundColor;
		}

		private TextBox GetTextBox(int index)
		{
			return (TextBox) this.Controls.Find("TB" + index, true)[0];
		}

		public void RefreshInfoForMatch(TMatch match)
		{
			TTeam team1 = Var.DB.GetTeamReferenceType(match.Team1Ref) == TTeam.NominalTeamReference ? Var.DB.GetTeamByNominalID(match.Team1Ref) : Var.DB.GetTeamByPlayOffReference(match.Team1Ref);
			TTeam team2 = Var.DB.GetTeamReferenceType(match.Team2Ref) == TTeam.NominalTeamReference ? Var.DB.GetTeamByNominalID(match.Team2Ref) : Var.DB.GetTeamByPlayOffReference(match.Team2Ref);
			if (team1 == null || team2 == null)
			{
				MessageBox.Show("One or both team references for match with matchID \"" + match.ID + "\" are null!", "RefreshInfoForMatch.RefreshInfoForMatch() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			matchL.Text = "Match " + match.ID;
			team1L.Text = team1.Name;
			team2L.Text = team2.Name;
			playedChB.Checked = match.Played;
			extraTimeChB.Checked = match.Score.FinishedInExtraTime() || match.Score.FinishedAtPenalties();
			penaltiesChB.Checked = match.Score.FinishedAtPenalties();
			playedChB_CheckedChanged(null, null);
			flagTeam1.Image = team1.FlagMedium;
			flagTeam2.Image = team2.FlagMedium;
			for (int i = 0; i < 5; i++)
				GetTextBox(i + 1).Text = i < match.Score.Halves.Count ? match.Score.Halves[i].FormatHalfScore() : "0-0";
			temperatureTB.Text = match.Conditions.Temperature;
			windSpeedTB.Text = match.Conditions.WindSpeed;
			humidityTB.Text = match.Conditions.RelativeHumidity;
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			for (int i = 1; i <= 5; i++)
				if (GetTextBox(i).Enabled && !Regex.Match(GetTextBox(i).Text, @"\A\d+-\d+\Z").Success)
				{
					MessageBox.Show("Incorrect score in text box for half number " + i + "!");
					return;
				}
			//
			TMatch match = Var.DB.GetMatchByID(Int32.Parse(matchL.Text.Substring(matchL.Text.IndexOf(' ') + 1)));
			match.Score.Halves.Clear();
			match.Played = playedChB.Checked;
			for (int i = 1; i <= 5; i++)
				if (GetTextBox(i).Enabled)
				{
					string s = GetTextBox(i).Text;
					int a = Int32.Parse(s.Substring(0, s.IndexOf('-'))), b = Int32.Parse(s.Substring(s.IndexOf('-') + 1));
					match.Score.Halves.Add(new THalfScore(a, b));
				}
			if (match.Score.Halves.Count == 0)
			{
				match.Score.Halves.Add(new THalfScore(0, 0));
				match.Score.Halves.Add(new THalfScore(0, 0));
			}
			match.Conditions.Temperature = temperatureTB.Text;
			match.Conditions.WindSpeed = windSpeedTB.Text;
			match.Conditions.RelativeHumidity = humidityTB.Text;
			//
			if (!Var.DB.SaveToFile())
				MessageBox.Show("An error has occured while saving data to file :( !\nHope this doesn't break your program...", "FMatchEditor.closeB_Click() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//
			((FMain) Application.OpenForms[0]).RefreshGroupTables();
			((FMain) Application.OpenForms[0]).RefreshMatchBoxes();
			FMatch mf = Var.MatchForm;
			mf.Show();
			mf.BringToFront();
			mf.RefreshMatchList();
			mf.matchListCB.SelectedIndex = mf.matchListCB.Items.IndexOf(Var.DB.EncodeMatchForMatchList(match));
			Var.CloseAllNonMainFormsExcept(mf);
		}

		private void playedChB_CheckedChanged(object sender, EventArgs e)
		{
			TB1.Enabled = playedChB.Checked;
			TB2.Enabled = TB1.Enabled;
			temperatureTB.Enabled = TB1.Enabled;
			windSpeedTB.Enabled = TB1.Enabled;
			humidityTB.Enabled = TB1.Enabled;
			extraTimeChB_CheckedChanged(null, null);
		}

		private void extraTimeChB_CheckedChanged(object sender, EventArgs e)
		{
			TB3.Enabled = playedChB.Checked && extraTimeChB.Checked;
			TB4.Enabled = TB3.Enabled;
			extraTimeChB.Enabled = playedChB.Checked;
			if (!extraTimeChB.Enabled)
				extraTimeChB.Checked = false;
			penaltiesChB_CheckedChanged(null, null);
		}

		private void penaltiesChB_CheckedChanged(object sender, EventArgs e)
		{
			TB5.Enabled = playedChB.Checked && extraTimeChB.Checked && penaltiesChB.Checked;
			penaltiesChB.Enabled = playedChB.Checked && extraTimeChB.Checked;
			if (!penaltiesChB.Enabled)
				penaltiesChB.Checked = false;
		}
	}
}
