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
	public partial class FSettings : Form
	{
		public FSettings()
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

		public void RefreshSettings()
		{
			teamListCB.Items.Clear();
			foreach (TTeam team in Var.DB.Teams)
				teamListCB.Items.Add(Var.DB.EncodeTeamForTeamList(team));
			teamListCB.SelectedIndex = teamListCB.Items.IndexOf(Var.DB.EncodeTeamForTeamList(Var.DB.Settings.FavoriteTeam));

			playMusicOnStartupChB.Checked = Var.DB.Settings.PlayMusicOnStartup;
			setMatchdayBlablaChB.Checked = Var.DB.Settings.SetMatchDayToLastUnplayedMatchDay;
			showPlayoffsChB.Checked = Var.DB.Settings.ShowPlayoffsWhenGroupPhaseHasFinished;

			playMusicOnStartupChB_CheckedChanged(playMusicOnStartupChB, null);
			playMusicOnStartupChB_CheckedChanged(setMatchdayBlablaChB, null);
			playMusicOnStartupChB_CheckedChanged(showPlayoffsChB, null);
		}

		private void playMusicOnStartupChB_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox ch = (CheckBox) sender;
			ch.Text = ch.Checked ? "Yes" : "No";
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			Var.DB.Settings.FavoriteTeam = Var.DB.DecodeTeamFromTeamList((string) teamListCB.SelectedItem);
			Var.DB.Settings.PlayMusicOnStartup = playMusicOnStartupChB.Checked;
			Var.DB.Settings.SetMatchDayToLastUnplayedMatchDay = setMatchdayBlablaChB.Checked;
			Var.DB.Settings.ShowPlayoffsWhenGroupPhaseHasFinished = showPlayoffsChB.Checked;
			Var.DB.Settings.SaveToFile();
			this.Hide();
		}

		private void optionsB_Click(object sender, EventArgs e)
		{
			Point p = System.Windows.Forms.Cursor.Position;
			optionsMenu.Show(p.X, p.Y);
		}

		private void resetAllResults_Click(object sender, EventArgs e)
		{
			if (sender != null & MessageBox.Show("This will delete any existing results.\nAre you sure you want to do this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return;
			for (int i = 0; i < 64; i++)
			{
				Var.DB.Matches[i].Played = false;
				Var.DB.Matches[i].Score = new TScore(true);
			}
			SaveDataAndRefreshMainForm();
		}

		private void randomizeGroupMatches_Click(object sender, EventArgs e)
		{
			if (sender != null)
				if (MessageBox.Show("This will delete any existing results.\nAre you sure you want to do this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
					return;
			for (int i = 0; i < 64; i++)
			{
				Var.DB.Matches[i].Played = i < 48;
				Var.DB.Matches[i].Score = i < 48 ? TDatabase.GetRandomScore(false) : new TScore(true);
			}
			if (sender != null)
				SaveDataAndRefreshMainForm();
		}

		private void randomizePlayOffMatches_Click(object sender, EventArgs e)
		{
			if (sender != null)
				if (MessageBox.Show("This will delete any existing play-off results.\nAre you sure you want to do this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
					return;
			for (int i = 0; i < 48; i++)
				if (!Var.DB.Matches[i].Played)
				{
					MessageBox.Show("Not all group matches have been played!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			for (int i = 48; i < 64; i++)
			{
				Var.DB.Matches[i].Played = true;
				Var.DB.Matches[i].Score = TDatabase.GetRandomScore(true);
			}
			if (sender != null)
				SaveDataAndRefreshMainForm();
		}

		private void randomizeAllMatches_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This will delete any existing results.\nAre you sure you want to do this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
				return;
			randomizeGroupMatches_Click(null, e);
			randomizePlayOffMatches_Click(null, e);
			SaveDataAndRefreshMainForm();
		}

		private void SaveDataAndRefreshMainForm()
		{
			if (!Var.DB.SaveToFile())
				MessageBox.Show("An error has occured while saving data to file :( !\nHope this doesn't break your program...", "FMatchEditor.closeB_Click() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			((FMain) Application.OpenForms[0]).RefreshGroupTables();
			((FMain) Application.OpenForms[0]).RefreshMatchBoxes();
		}
	}
}
