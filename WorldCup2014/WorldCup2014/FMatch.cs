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
	public partial class FMatch : Form
	{
		public FMatch()
		{
			InitializeComponent();
			bgImg.SetBounds(0, 0, this.Width, this.Height);
			bgImg.SendToBack();
			Var.PaintBackgroundImage(bgImg);
			foreach (Control control in this.Controls)
				if (control is Label)
					((Label) control).BackColor = FMain.BackgroundColor;
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		public void RefreshMatchList()
		{
			matchListCB.Items.Clear();
			foreach (TMatch match in Var.DB.Matches)
				matchListCB.Items.Add(Var.DB.EncodeMatchForMatchList(match));
			matchListCB.SelectedIndex = 0;
		}

		private void matchListCB_SelectedIndexChanged(object sender, EventArgs e)
		{
			TMatch match = Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem);
			TGroup group = Var.DB.GetGroupByID(match.Type);
			if (group != null)
			{
				groupL.Text = group.Name;
				team1L.Text = match.Team1.Name;
				team2L.Text = match.Team2.Name;
				flagTeam1.Image = Var.DB.GetTeamByNominalID(match.Team1.ID).FlagMedium;
				flagTeam2.Image = Var.DB.GetTeamByNominalID(match.Team2.ID).FlagMedium;
				editB.Enabled = true;
			}
			else
			{
				groupL.Text = TDatabase.PlayOffPhaseName(match.Type);
				TTeam team = Var.DB.GetTeamByPlayOffReference(match.Team1Ref);
				team1L.Text = team != null ? team.Name : Var.DB.PlayOffReferenceName(match.Team1Ref);
				flagTeam1.Image = team != null ? team.FlagMedium : Var.DB.UnknownTeamFlagMedium;
				team = Var.DB.GetTeamByPlayOffReference(match.Team2Ref);
				team2L.Text = team != null ? team.Name : Var.DB.PlayOffReferenceName(match.Team2Ref);
				flagTeam2.Image = team != null ? team.FlagMedium : Var.DB.UnknownTeamFlagMedium;
				editB.Enabled = (Var.DB.GetTeamByPlayOffReference(match.Team1Ref) != null && Var.DB.GetTeamByPlayOffReference(match.Team2Ref) != null);
			}
			dateL.Text = match.When.ToString("dddd, d MMMM yyyy, HH:mm") + " (" + Var.DB.TimeZone + ")";
			stadiumL.Text = match.Where.ArenaName + ", " + match.Where.City;
			finalScoreL.Text = match.FormatScore();
			scoreInfoL.Text = match.FormatSubscore();
			temperatureL.Text = match.Conditions.Temperature + "°";
			windSpeedL.Text = match.Conditions.WindSpeed;
			humidityL.Text = match.Conditions.RelativeHumidity + "%";
		}

		private void stadiumL_Click(object sender, EventArgs e)
		{
			FArena af = Var.ArenaForm;
			af.Show();
			af.BringToFront();
			af.RefreshArenaButtons();
			af.SelectArena(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem).Where.City);
			Var.CloseAllNonMainFormsExcept(af);
		}

		private void editB_Click(object sender, EventArgs e)
		{
			FMatchEditor mef = Var.MatchEditorForm;
			mef.Show();
			mef.BringToFront();
			mef.RefreshInfoForMatch(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem));
			Var.CloseAllNonMainFormsExcept(mef);
		}

		private void team1L_Click(object sender, EventArgs e)
		{
			if (groupL.Text.Substring(0, 5).Equals("Group"))
				TeamLink(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem).Team1);
			else
				TeamLink(Var.DB.GetTeamByPlayOffReference(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem).Team1Ref));
		}

		private void team2L_Click(object sender, EventArgs e)
		{
			if (groupL.Text.Substring(0, 5).Equals("Group"))
				TeamLink(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem).Team2);
			else
				TeamLink(Var.DB.GetTeamByPlayOffReference(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem).Team2Ref));
		}

		private void TeamLink(TTeam team)
		{
			if (team == null)
				return;
			FTeam tf = Var.TeamForm;
			FTeam.CurrentTeam = team.ID;
			tf.Show();
			tf.SelectTeam(team.ID);
			tf.BringToFront();
			Var.CloseAllNonMainFormsExcept(tf);
		}

		private void groupL_Click(object sender, EventArgs e)
		{
			if (groupL.Text.Substring(0, 5).Equals("Group"))
			{
				FGroup gf = Var.GroupForm;
				gf.Show();
				gf.SelectGroup("G" + groupL.Text.Substring(groupL.Text.IndexOf(' ') + 1));
				gf.BringToFront();
				Var.CloseAllNonMainFormsExcept(gf);
			}
			else
			{
				FPlayOff pof = Var.PlayOffForm;
				pof.Show();
				pof.RefreshInformation();
				pof.BringToFront();
				Var.CloseAllNonMainFormsExcept(pof);
			}
		}

		private void dateL_Click(object sender, EventArgs e)
		{
			string s = TDatabase.EncodeDate(Var.DB.DecodeMatchFromMatchList((string) matchListCB.SelectedItem).When);
			FMatchDay mdf = Var.MatchDayForm;
			mdf.Show();
			mdf.BringToFront();
			FMatchDay.CurrentMatchDay = s;
			mdf.refreshInfoTimer.Enabled = true;
			Var.CloseAllNonMainFormsExcept(mdf);
		}
	}
}
