using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using AxWMPLib;
//using WMPLib;

namespace WorldCup2014
{
	public partial class FMain : Form
	{
		public static Color BackgroundColor = Color.FromArgb(66, 129, 7);
		public static Color SelectedColor = Color.FromArgb(74, 147, 9);
		public static Color MenuButtonColor = Color.FromArgb(8, 8, 8);

		private static List<TPictureBox> MenuButtons = new List<TPictureBox>();
		private static List<TPictureBox> MusicPlayerButtons = new List<TPictureBox>();
		private static List<TPictureBox> GroupTables = new List<TPictureBox>();
		private static List<TPictureBox> MatchDayButtons = new List<TPictureBox>();
		private static List<TPictureBox> MatchBoxes = new List<TPictureBox>();

		//WindowsMediaPlayer MusicPlayer = new WindowsMediaPlayer();
		private static string lastMusicFilePlayed = null;

		private static int MatchDay = 1;
		private static string[] MenuButtonCaptions = new string[8] { "Arenas", "Teams", "Groups", "Matches", "EXIT", "MORE", "About", "PLAY-OFF" };
		private const string PlayButton = "֎", PauseButton = "○", NextButton = "♪";

		public FMain()
		{
			InitializeComponent();
		}

		private void FMain_Load(object sender, EventArgs e)
		{
			GroupTablePanel.BackColor = BackgroundColor;
			MatchDayButtonPanel.BackColor = BackgroundColor;
			MatchBoxPanel.BackColor = BackgroundColor;
			MenuButtonPanel1.BackColor = BackgroundColor;
			MenuButtonPanel2.BackColor = BackgroundColor;
		}

		private void FMain_Shown(object sender, EventArgs e)
		{
			// INIT
			this.BackColor = BackgroundColor;
			foreach (Control control in this.Controls)
			{
				if (control is Panel)
					((Panel) control).BackColor = BackgroundColor;
				else if (control is PictureBox)
					((PictureBox) control).BackColor = BackgroundColor;
				if (control is Panel || control is PictureBox)
					control.Visible = true;
			}
			//
			WelcomePanel.Left = this.Width / 2 - WelcomePanel.Width / 2;
			WelcomePanel.Top = this.Height / 2 - WelcomePanel.Height / 2;
			initialRefreshT.Enabled = true;
		}

		private void initialRefreshT_Tick(object sender, EventArgs e)
		{
			initialRefreshT.Enabled = false;
			// READ AND REFRESH
			if (!Var.DB.ReadFromFile())
			{
				MessageBox.Show("Errors were encountered when reading the data source file.\n\nCheck \"data\\data.xml\" and fix any errors. The program will now close.", "Initialization failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			if (!Var.DB.VerifyAndConnectData())
			{
				MessageBox.Show("The data that was read had some errors.\n\nOpen \"data\\data.xml\" and fix the errors that were mentioned previously, or check the file structure to be sure it's how it should be; otherwise contact the author for more information. The program will now close.", "Initialization failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			if (!Var.PDB.ReadFromFile())
			{
				MessageBox.Show("Errors were encountered when reading the data source file.\n\nCheck \"data\\players.xml\" and fix any errors. The program will now close.", "Initialization failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			if (!Var.PDB.VerifyAndConnectData())
			{
				MessageBox.Show("The data that was read had some errors.\n\nOpen \"data\\players.xml\" and fix the errors that were mentioned previously, or check the file structure to be sure it's how it should be; otherwise contact the author for more information. The program will now close.", "Initialization failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}

			// It's ok
			Var.DB.Settings.ReadFromFile();
			Var.DB.Settings.SaveToFile();
			// 
			LogoImg.Image = Var.DB.LogoImage;
			LogoImg.SetBounds(50, this.Height / 2 - 300, 500, 600);
			LogoImg.SendToBack();
			BackgroundImg.Image = Var.DB.BackgroundImage;
			BackgroundImg.SetBounds(0, 0, this.Width, this.Height);
			BackgroundImg.SendToBack();

			// CREATE PICTURE BOXES
			for (int i = 0; i < 8; i++)
			{
				TPictureBox pic = new TPictureBox(MenuButtonCaptions[i]);
				pic.Parent = i < 4 ? MenuButtonPanel1 : MenuButtonPanel2;
				pic.Cursor = Cursors.Hand;
				pic.MouseEnter += new EventHandler(MenuButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MenuButton_MouseLeave);
				pic.Click += new EventHandler(MenuButton_Click);
				MenuButtons.Add(pic);
			}
			for (int i = 1; i <= 8; i++)
			{
				TPictureBox pic = new TPictureBox("G" + (char) (64 + i));
				pic.Parent = GroupTablePanel;
				pic.Cursor = Cursors.Hand;
				pic.MouseEnter += new EventHandler(GroupTable_MouseEnter);
				pic.MouseLeave += new EventHandler(GroupTable_MouseLeave);
				pic.Click += new EventHandler(GroupTable_Click);
				GroupTables.Add(pic);
			}
			for (int i = 1; i <= 3; i++)
			{
				TPictureBox pic = new TPictureBox("Day " + i);
				pic.Parent = MatchDayButtonPanel;
				pic.Cursor = Cursors.Hand;
				pic.MouseEnter += new EventHandler(MatchDayButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MatchDayButton_MouseLeave);
				pic.Click += new EventHandler(MatchDayButton_Click);
				MatchDayButtons.Add(pic);
			}
			for (int i = 1; i <= (1 + 2) * 8; i++)
			{
				TPictureBox pic = new TPictureBox("Matchbox i=" + i);
				pic.Parent = MatchBoxPanel;
				if (i % 3 != 1)
				{
					pic.Cursor = Cursors.Hand;
					pic.MouseEnter += new EventHandler(MatchBox_MouseEnter);
					pic.MouseLeave += new EventHandler(MatchBox_MouseLeave);
					pic.Click += new EventHandler(MatchBox_Click);
				}
				MatchBoxes.Add(pic);
			}
			for (int i = 1; i <= 2; i++)
			{
				TPictureBox pic = new TPictureBox(i == 1 ? "???" : NextButton);
				pic.Parent = MusicPlayerPanel;
				pic.Cursor = Cursors.Hand;
				pic.MouseEnter += new EventHandler(MusicPlayerButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MusicPlayerButton_MouseLeave);
				pic.Click += new EventHandler(MusicPlayerButton_Click);
				MusicPlayerButtons.Add(pic);
			}
			// POSITION AND SIZE PICTURE BOXES
			MenuButtonPanel1.SetBounds(20, 20, MenuButtons.Count * Var.MenuButtonSize.Width / 2, Var.MenuButtonSize.Height);
			MenuButtonPanel2.SetBounds(20, this.Height - Var.MenuButtonSize.Height - 20, MenuButtons.Count * Var.MenuButtonSize.Width / 2, Var.MenuButtonSize.Height);
			for (int i = 0; i < MenuButtons.Count; i++)
			{
				MenuButtons[i].SetBounds((i % 4) * Var.MenuButtonSize.Width, 0, Var.MenuButtonSize.Width, Var.MenuButtonSize.Height);
			}
			GroupTablePanel.SetBounds(this.Width - (2 * Var.GroupTableSize.Width + 20) - 20, 20, 2 * Var.GroupTableSize.Width + 20, this.Height - 40);
			for (int i = 1, plus = (GroupTablePanel.Height - Var.GroupTableSize.Height - 3 * (Var.GroupTableSize.Height + 20)) / 3; i <= 8; i++)
			{
				int x = i % 2 == 1 ? 0 : Var.GroupTableSize.Width + 20;
				int y = ((i - 1) / 2) * (Var.GroupTableSize.Height + 20 + plus);
				GroupTables[i - 1].SetBounds(x, y, Var.GroupTableSize.Width, Var.GroupTableSize.Height);
			}
			MatchDayButtonPanel.SetBounds(GroupTablePanel.Left - Var.MatchBoxSize.Width - 80, GroupTablePanel.Top, Var.MatchBoxSize.Width, 40);
			for (int i = 1, w3 = MatchDayButtonPanel.Width / 3; i <= 3; i++)
			{
				MatchDayButtons[i - 1].SetBounds((i - 1) * w3, 0, w3, MatchDayButtonPanel.Height);
			}
			MatchBoxPanel.SetBounds(MatchDayButtonPanel.Left, MatchDayButtonPanel.Bottom + 4, MatchDayButtonPanel.Width, GroupTablePanel.Height - MatchDayButtonPanel.Height - 4);
			int plusY = (int) Math.Round((double) (MatchBoxPanel.Height - (1 + 2) * 8 * Var.MatchBoxSize.Height) / ((1 + 2) * 8));
			for (int i = 1, lastY = 0; i <= (1 + 2) * 8; i++)
			{
				MatchBoxes[i - 1].SetBounds(0, lastY, Var.MatchBoxSize.Width, Var.MatchBoxSize.Height);
				lastY += Var.MatchBoxSize.Height + plusY;
			}
			MusicPlayerPanel.SetBounds(MenuButtonPanel2.Left, MenuButtonPanel2.Top - 50, 100, 50);
			for (int i = 0; i < 2; i++)
			{
				MusicPlayerButtons[i].SetBounds(i * 50, 0, 50, 50);
			}

			//
			if (Var.DB.Settings.SetMatchDayToLastUnplayedMatchDay)
				for (int i = 0; i < 48; i++)
					if (!Var.DB.Matches[i].Played)
					{
						MatchDay = (i + 16) / 16;
						break;
					}

			WelcomePanel.Hide();
			RefreshMenuButtons();
			RefreshGroupTables();
			RefreshMatchDayButtons();
			RefreshMatchBoxes();
			RefreshMusicPlayerButtons();

			if (Var.DB.Settings.ShowPlayoffsWhenGroupPhaseHasFinished && Var.DB.GroupPhaseOver())
				MenuButton_Click(MenuButtons[7], null);

			//MusicPlayer.settings.volume = 30;
			MusicPlayerPanel.Visible = Var.DB.MusicFiles.Length > 0;
			PlayMusic(null);
			if (Var.DB.Settings.PlayMusicOnStartup && MusicPlayerPanel.Visible)
				try
				{
					PlayMusic(Var.DB.MusicFiles[TDatabase.RandomNumber.Next(Var.DB.MusicFiles.Length)]);
					RefreshMusicPlayerButtons();
				}
				catch (Exception E)
				{
					MessageBox.Show("An error occured while trying to initialize the music MusicPlayer (see below).\n\nPlease check that you have 'AxInterop.WMPLib.dll' and 'Interop.WMPLib.dll' alongside the executable file and that you have a fairly recent of Windows Media Player installed on your computer. Alternatively, contact the author for more information.\n\nTo stop showing this message on startup, uncheck the 'Play music on startup' option in the settings.\n\n" + E.ToString(),
						"Music MusicPlayer initialization ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					MusicPlayerPanel.Hide();
				}
		}

		public void RefreshMenuButtons()
		{
			for (int i = 0; i < MenuButtons.Count; i++)
				DrawMenuButton(MenuButtons[i], false);
		}

		public void RefreshGroupTables()
		{
			Var.DB.RefreshAllGroupStandings();
			for (int i = 0; i < 8; i++)
				DrawGroup(GroupTables[i], false);
		}

		public void RefreshMatchDayButtons()
		{
			for (int i = 0; i < 3; i++)
				DrawMatchDayButton(MatchDayButtons[i], false);
		}

		public void RefreshMatchBoxes()
		{
			for (int boxIndex = 0, matchIndex = (MatchDay - 1) * (2 * 8); boxIndex < (1 + 2) * 8; boxIndex++)
				switch (boxIndex % 3)
				{
					case 0:
						DrawMatchGroup(MatchBoxes[boxIndex], Var.DB.GetGroupByID(Var.DB.Matches[matchIndex].Type).Name);
						break;
					case 1:
					case 2:
						MatchBoxes[boxIndex].Information = "Match " + Var.DB.Matches[matchIndex].ID;
						DrawMatch(MatchBoxes[boxIndex], false);
						matchIndex++;
						break;
				}
		}

		public void RefreshMusicPlayerButtons()
		{
			for (int i = 0; i < 2; i++)
				DrawMusicPlayerButton(MusicPlayerButtons[i], false);
		}

		///
		///	DRAWING METHODS
		///

		private void DrawMusicPlayerButton(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(SelectedColor) : new SolidBrush(BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font = MenuButtonFontL.Font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);
			g.DrawString(pic.Information, font, textBrush,
				new Point(pic.Width / 2 - (int) g.MeasureString(pic.Information, font).Width / 2, pic.Height / 2 - (int) g.MeasureString(pic.Information, font).Height / 2));

			pic.Image = bmp;
		}

		private void DrawMenuButton(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(SelectedColor) : new SolidBrush(BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			if (Selected && (pic.Information.Equals(MenuButtonCaptions[4]) || pic.Information.Equals(MenuButtonCaptions[5])))
			{
				bgBrush = new SolidBrush(MenuButtonColor);
				textBrush = new SolidBrush(Color.White);
			}
			Font font = MenuButtonFontL.Font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);
			g.DrawString(pic.Information, font, textBrush,
				new Point(pic.Width / 2 - (int) g.MeasureString(pic.Information, font).Width / 2, pic.Height / 2 - (int) g.MeasureString(pic.Information, font).Height / 2));

			pic.Image = bmp;
		}

		private void DrawGroup(TPictureBox pic, bool Selected)
		{
			TGroup group = Var.DB.GetGroupByID(pic.Information);

			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = new SolidBrush(BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);

			g.FillRectangle(bgBrush, 0, 0, Var.GroupTableSize.Width, Var.GroupTableSize.Height);

			if (Selected)
				g.FillRectangle(new SolidBrush(SelectedColor), 0, 0, Var.GroupTableSize.Width, 47);

			g.DrawString(group.Name, GroupTableTitleL.Font, textBrush,
				Var.GroupTableSize.Width / 2 - (int) g.MeasureString(group.Name, GroupTableTitleL.Font).Width / 2,
				47 / 2 - (int) g.MeasureString(group.Name, GroupTableTitleL.Font).Height / 2);

			int lastY = 47;

			foreach (TTablePosition posTeam in group.Teams)
			{
				g.DrawImage(posTeam.Team.FlagSmall, new Point(0, lastY + 8));
				g.DrawString(posTeam.Team.Name, GroupTableContentL.Font, Brushes.WhiteSmoke, new Point(32, lastY + 5));
				g.DrawString(posTeam.Points + "p", GroupTableContent2L.Font, Brushes.NavajoWhite, new Point(Var.GroupTableSize.Width - 48, lastY + 5));

				lastY += 32;
			}

			pic.Image = bmp;
		}

		private void DrawMatchDayButton(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(SelectedColor) : new SolidBrush(BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font = MatchDayL.Font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);
			g.DrawString(pic.Information, font, textBrush,
				new Point(pic.Width / 2 - (int) g.MeasureString(pic.Information, font).Width / 2, pic.Height / 2 - (int) g.MeasureString(pic.Information, font).Height / 2));

			if (pic.Information.Equals("Day " + MatchDay))
				g.FillRectangle(textBrush, 0, pic.Height - 3, pic.Width, pic.Height);

			pic.Image = bmp;
		}

		private void DrawMatchGroup(TPictureBox pic, string GroupName)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = new SolidBrush(BackgroundColor);
			Font font = GroupTableContent2L.Font;

			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);
			g.DrawString(GroupName, font, Brushes.NavajoWhite, new Point(20, pic.Height / 2 - (int) g.MeasureString(GroupName, font).Height / 2));

			pic.Image = bmp;
		}

		public void DrawMatch(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(SelectedColor) : new SolidBrush(BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);

			if (pic.Information.Equals("NULL"))
			{
				bgBrush = new SolidBrush(BackgroundColor);
				g.FillRectangle(bgBrush, 0, 0, Var.MatchBoxSize.Width, Var.MatchBoxSize.Height);
				pic.Image = bmp;
				return;
			}

			g.FillRectangle(bgBrush, 0, 0, Var.MatchBoxSize.Width, Var.MatchBoxSize.Height);

			string s = pic.Information.Substring(pic.Information.IndexOf(' ') + 1);
			TMatch match = Var.DB.GetMatchByID(Int32.Parse(s));
			Font font = match.Played ? GroupTableContent2L.Font : MatchHourFontL.Font;

			TTeam team1 = Var.DB.GetTeamReferenceType(match.Team1Ref) == TTeam.NominalTeamReference ? Var.DB.GetTeamByNominalID(match.Team1Ref) : Var.DB.GetTeamByPlayOffReference(match.Team1Ref);
			TTeam team2 = Var.DB.GetTeamReferenceType(match.Team2Ref) == TTeam.NominalTeamReference ? Var.DB.GetTeamByNominalID(match.Team2Ref) : Var.DB.GetTeamByPlayOffReference(match.Team2Ref);

			team1 = team1 == null ? Var.DB.UnknownTeam : team1;
			team2 = team2 == null ? Var.DB.UnknownTeam : team2;

			s = match.Played ? match.FormatScore() : string.Format("{0}@{1}", match.When.ToString("ddd"), match.When.ToString("HH"));
			int xm = Var.MatchBoxSize.Width / 2, x = xm - (int) g.MeasureString(s, font).Width / 2;
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

			pic.Image = bmp;
		}

		///
		/// ON MOUSE OVER ACTIONS
		/// 

		public void MusicPlayerButton_MouseEnter(object sender, EventArgs e)
		{
			DrawMusicPlayerButton((TPictureBox) sender, true);
		}

		public void MusicPlayerButton_MouseLeave(object sender, EventArgs e)
		{
			DrawMusicPlayerButton((TPictureBox) sender, false);
		}

		public void MenuButton_MouseEnter(object sender, EventArgs e)
		{
			DrawMenuButton((TPictureBox) sender, true);
		}

		public void MenuButton_MouseLeave(object sender, EventArgs e)
		{
			DrawMenuButton((TPictureBox) sender, false);
		}

		private void MatchDayButton_MouseEnter(object sender, EventArgs e)
		{
			DrawMatchDayButton((TPictureBox) sender, true);
		}

		private void MatchDayButton_MouseLeave(object sender, EventArgs e)
		{
			DrawMatchDayButton((TPictureBox) sender, false);
		}

		public void MatchBox_MouseEnter(object sender, EventArgs e)
		{
			DrawMatch((TPictureBox) sender, true);
		}

		public void MatchBox_MouseLeave(object sender, EventArgs e)
		{
			DrawMatch((TPictureBox) sender, false);
		}

		private void GroupTable_MouseEnter(object sender, EventArgs e)
		{
			DrawGroup((TPictureBox) sender, true);
		}

		private void GroupTable_MouseLeave(object sender, EventArgs e)
		{
			DrawGroup((TPictureBox) sender, false);
		}

		///
		/// ON CLICK ACTIONS
		/// 

		private void MusicPlayerButton_Click(object sender, EventArgs e)
		{
			TPictureBox pic = (TPictureBox) sender;
			if (pic.Information.Equals(PlayButton))
			{
				PlayMusic(null);
				DrawMusicPlayerButton(MusicPlayerButtons[0], true);
			}
			else if (pic.Information.Equals(PauseButton))
			{
				PlayMusic(lastMusicFilePlayed != null ? lastMusicFilePlayed : Var.DB.MusicFiles[TDatabase.RandomNumber.Next(Var.DB.MusicFiles.Length)]);
				DrawMusicPlayerButton(MusicPlayerButtons[0], true);
			}
			else if (pic.Information.Equals(NextButton))
			{
				PlayMusic(Var.DB.MusicFiles[TDatabase.RandomNumber.Next(Var.DB.MusicFiles.Length)]);
				DrawMusicPlayerButton(MusicPlayerButtons[1], true);
			}
			else
				MessageBox.Show("Could not identify TPictureBox with Information=\"" + pic.Information + "\"!", "MusicPlayerButton_Click() WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void PlayMusic(string url)
		{
			/*if (url == null)
			{
				MusicPlayer.controls.pause();
				MusicPlayerButtons[0].Information = PauseButton;
				DrawMusicPlayerButton(MusicPlayerButtons[0], false);
			}
			else
			{
				if (!url.Equals(lastMusicFilePlayed))
				{
					MusicPlayer.URL = url;
					lastMusicFilePlayed = url;
				}
				MusicPlayer.controls.play();
				MusicPlayerButtons[0].Information = PlayButton;
				DrawMusicPlayerButton(MusicPlayerButtons[0], false);
			}*/
		}

		private void MatchDayButton_Click(object sender, EventArgs e)
		{
			MatchDay = Int32.Parse(((TPictureBox) sender).Information[4].ToString());
			RefreshMatchDayButtons();
			DrawMatchDayButton((TPictureBox) sender, true);
			RefreshMatchBoxes();
		}

		public void MatchBox_Click(object sender, EventArgs e)
		{
			string s = ((TPictureBox) sender).Information;
			if (s.Equals("NULL"))
				return;
			int matchID = Int32.Parse(s.Substring(s.IndexOf(' ') + 1));
			FMatch mf = Var.MatchForm;
			if (!mf.Visible)
				mf.Show();
			mf.BringToFront();
			mf.RefreshMatchList();
			mf.matchListCB.SelectedIndex = mf.matchListCB.Items.IndexOf(Var.DB.EncodeMatchForMatchList(Var.DB.GetMatchByID(matchID)));
			Var.CloseAllNonMainFormsExcept(mf);
		}

		private void GroupTable_Click(object sender, EventArgs e)
		{
			string groupID = ((TPictureBox) sender).Information.Substring(((TPictureBox) sender).Information.IndexOf(' ') + 1);
			Var.GroupForm.Show();
			Var.GroupForm.SelectGroup(groupID);
			Var.GroupForm.DrawGroupButton(Var.GroupForm.GetTPictureBoxByGroupID(groupID), false);
			Var.GroupForm.BringToFront();
			Var.CloseAllNonMainFormsExcept(Var.GroupForm);
		}

		private void MenuButton_Click(object sender, EventArgs e)
		{
			int r = -1;
			for (int i = 0; i < MenuButtons.Count; i++)
				if (MenuButtonCaptions[i].Equals(((TPictureBox) sender).Information))
					r = i;
			switch (r)
			{
				// ARENAS
				case 0:
					Var.CloseAllNonMainFormsExcept(Var.ArenaForm);
					if (!Var.ArenaForm.Visible)
					{
						Var.ArenaForm.Show();
						Var.ArenaForm.SelectArena(Var.DB.Arenas[0].City);
					}
					else
						Var.ArenaForm.Hide();
					Var.ArenaForm.BringToFront();
					break;
				// TEAMS
				case 1:
					Var.CloseAllNonMainFormsExcept(Var.TeamForm);
					if (!Var.TeamForm.Visible)
					{
						Var.TeamForm.Show();
						Var.TeamForm.SelectTeam(Var.DB.Settings.FavoriteTeam.ID);
					}
					else
						Var.TeamForm.Hide();
					Var.TeamForm.BringToFront();
					break;
				// GROUPS
				case 2:
					Var.CloseAllNonMainFormsExcept(Var.GroupForm);
					if (!Var.GroupForm.Visible)
					{
						string groupID = Var.DB.GetGroupByTeam(Var.DB.Settings.FavoriteTeam).ID;
						Var.GroupForm.Show();
						Var.GroupForm.SelectGroup(groupID);
						Var.GroupForm.DrawGroupButton(Var.GroupForm.GetTPictureBoxByGroupID(groupID), false);
					}
					else
						Var.GroupForm.Hide();
					Var.GroupForm.BringToFront();
					break;
				// MATCHES
				case 3:
					Var.CloseAllNonMainFormsExcept(Var.MatchForm);
					if (!Var.MatchForm.Visible)
					{
						Var.MatchForm.Show();
						Var.MatchForm.RefreshMatchList();
						Var.MatchForm.matchListCB.SelectedIndex = 0;
					}
					else
						Var.MatchForm.Hide();
					Var.MatchForm.BringToFront();
					break;
				// EXIT
				case 4:
					Application.Exit();
					break;
				// MORE
				case 5:
					Var.CloseAllNonMainFormsExcept(Var.MenuForm);
					if (!Var.MenuForm.Visible)
					{
						Var.MenuForm.Show();
						Var.MenuForm.RefreshMenuButtons();
					}
					else
						Var.MenuForm.Hide();
					Var.MenuForm.BringToFront();
					break;
				// ABOUT
				case 6:
					Var.CloseAllNonMainFormsExcept(Var.AboutForm);
					if (!Var.AboutForm.Visible)
					{
						Var.AboutForm.Show();
						Var.AboutForm.RefreshInformation();
					}
					else
						Var.AboutForm.Hide();
					Var.AboutForm.BringToFront();
					break;
				// PLAY-OFF
				case 7:
					Var.CloseAllNonMainFormsExcept(Var.PlayOffForm);
					if (!Var.PlayOffForm.Visible)
					{
						Var.PlayOffForm.Show();
						Var.PlayOffForm.RefreshInformation();
					}
					else
						Var.PlayOffForm.Hide();
					Var.PlayOffForm.BringToFront();
					break;
			}
		}
	}
}
