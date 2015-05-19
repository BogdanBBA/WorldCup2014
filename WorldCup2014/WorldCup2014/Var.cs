using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace WorldCup2014
{
	/// 
	/// Static VAR class
	/// 

	public static class Var
	{
		public static TDatabase DB = new TDatabase();
		public static TPlayerDatabase PDB = new TPlayerDatabase();

		public static FAbout AboutForm = new FAbout();
		public static FArena ArenaForm = new FArena();
		public static FMatch MatchForm = new FMatch();
		public static FMatchEditor MatchEditorForm = new FMatchEditor();
		public static FTeam TeamForm = new FTeam();
		public static FGroup GroupForm = new FGroup();
		public static FSettings SettingsForm = new FSettings();
		public static FPlayOff PlayOffForm = new FPlayOff();
		public static FMatchDay MatchDayForm = new FMatchDay();
		public static FMatchConditions MatchConditionsForm = new FMatchConditions();
		public static FPlayers PlayersForm = new FPlayers();
		public static FMenu MenuForm = new FMenu();
		public static FStatistics StatsForm = new FStatistics();

		public static Size MenuButtonSize = new Size(128, 54);
		public static Size GroupTableSize = new Size(230, 175);
		public static Size MatchBoxSize = new Size(230, 28);

		public static string MusicPath = "data\\music";
		public static string ImagesPath = "data\\images";
		public static string FlagsSmallPath = "data\\images\\flagsSmall";
		public static string FlagsMediumSmallPath = "data\\images\\flagsMediumSmall";
		public static string FlagsMediumPath = "data\\images\\flagsMedium";
		public static string FlagsLargePath = "data\\images\\flagsLarge";
		public static string ArenaImagesPath = "data\\images\\arenas";
		public static string CityLocationImagesPath = "data\\images\\cityLocations";
		public static string FlagsAllCountriesPath = "data\\images\\flagsAllCountries";

		public static void PaintBackgroundImage(PictureBox pic)
		{
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			const int margin = 6, border = margin + 8;
			g.FillRectangle(new SolidBrush(FMain.BackgroundColor), 0, 0, pic.Width, pic.Height);
			g.FillRectangle(new SolidBrush(Color.WhiteSmoke), margin, margin, pic.Width - 2 * margin, pic.Height - 2 * margin);
			g.FillRectangle(new SolidBrush(FMain.BackgroundColor), border, border, pic.Width - 2 * border, pic.Height - 2 * border);
			pic.Image = bmp;
		}

		public static void CloseAllNonMainFormsExcept(object ExceptForForm)
		{
			if (AboutForm != ExceptForForm)
				AboutForm.Hide();
			if (ArenaForm != ExceptForForm)
				ArenaForm.Hide();
			if (MatchForm != ExceptForForm)
				MatchForm.Hide();
			if (MatchEditorForm != ExceptForForm)
				MatchEditorForm.Hide();
			if (TeamForm != ExceptForForm)
				TeamForm.Hide();
			if (GroupForm != ExceptForForm)
				GroupForm.Hide();
			if (SettingsForm != ExceptForForm)
				SettingsForm.Hide();
			if (PlayOffForm != ExceptForForm)
				PlayOffForm.Hide();
			if (MatchDayForm != ExceptForForm)
				MatchDayForm.Hide();
			if (MatchConditionsForm != ExceptForForm)
				MatchConditionsForm.Hide();
			if (PlayersForm != ExceptForForm)
				PlayersForm.Hide();
			if (MenuForm != ExceptForForm)
				MenuForm.Hide();
			if (StatsForm != ExceptForForm)
				StatsForm.Hide();
		}
	}

	public class TSettings
	{
		private string FilePath;

		public TTeam FavoriteTeam;
		public bool PlayMusicOnStartup, SetMatchDayToLastUnplayedMatchDay, ShowPlayoffsWhenGroupPhaseHasFinished;

		public TSettings(string FilePath)
		{
			this.FilePath = FilePath;
		}

		public void ReadFromFile()
		{
			try
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(FilePath);
				XmlNode node = doc.SelectNodes("/SETTINGS")[0];

				try { FavoriteTeam = Var.DB.GetTeamByNominalID(node["FavoriteTeam"].Attributes["value"].Value); }
				catch (Exception E) { FavoriteTeam = Var.DB.Teams[0]; }

				try { PlayMusicOnStartup = Boolean.Parse(node["PlayMusicOnStartup"].Attributes["value"].Value); }
				catch (Exception E) { PlayMusicOnStartup = true; }

				try { SetMatchDayToLastUnplayedMatchDay = Boolean.Parse(node["SetMatchDayToLastUnplayedMatchDay"].Attributes["value"].Value); }
				catch (Exception E) { PlayMusicOnStartup = true; }

				try { ShowPlayoffsWhenGroupPhaseHasFinished = Boolean.Parse(node["ShowPlayoffsWhenGroupPhaseHasFinished"].Attributes["value"].Value); }
				catch (Exception E) { PlayMusicOnStartup = true; }
			}
			catch (Exception E)
			{
				MessageBox.Show(E.ToString(), "TSettings.ReadFromFile() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void SaveToFile()
		{
			try
			{
				XmlDocument doc = new XmlDocument();
				XmlNode root, node;

				root = doc.AppendChild(doc.CreateElement("SETTINGS"));
				root.Attributes.Append(TDatabase.GetNewAttribute(doc, "lastSavedCirca", TDatabase.FormatDateTimeForComparison(DateTime.Now)));

				node = root.AppendChild(doc.CreateElement("FavoriteTeam"));
				node.Attributes.Append(TDatabase.GetNewAttribute(doc, "value", FavoriteTeam.ID));

				node = root.AppendChild(doc.CreateElement("PlayMusicOnStartup"));
				node.Attributes.Append(TDatabase.GetNewAttribute(doc, "value", PlayMusicOnStartup.ToString()));

				node = root.AppendChild(doc.CreateElement("SetMatchDayToLastUnplayedMatchDay"));
				node.Attributes.Append(TDatabase.GetNewAttribute(doc, "value", SetMatchDayToLastUnplayedMatchDay.ToString()));

				node = root.AppendChild(doc.CreateElement("ShowPlayoffsWhenGroupPhaseHasFinished"));
				node.Attributes.Append(TDatabase.GetNewAttribute(doc, "value", ShowPlayoffsWhenGroupPhaseHasFinished.ToString()));

				doc.Save(FilePath);
			}
			catch (Exception E)
			{
				MessageBox.Show(E.ToString(), "TSettings.SaveToFile() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	public class TPictureBox : PictureBox
	{
		public string Information;

		public TPictureBox(string Information)
			: base()
		{
			this.Information = Information;
		}
	}

	/// 
	/// ARENA
	/// 
	public class TArena
	{
		public string City, ArenaName;
		public int Capacity, YearBuilt;
		public Bitmap ArenaImage, CityLocationImage;

		public TArena(string City, string ArenaName, int Capacity, int YearBuilt)
		{
			this.City = City;
			this.ArenaName = ArenaName;
			this.Capacity = Capacity;
			this.YearBuilt = YearBuilt;
		}
	}

	/// 
	/// TEAM
	/// 
	public class TTeam
	{
		public static int NominalTeamReference = 1, PlayOffTeamReference = 2, IncorrectTeamReference = 3;

		public string ID, Name, EnglishName;
		public List<Color> Colors;
		public Bitmap FlagSmall, FlagMediumSmall, FlagMedium, FlagLarge;

		public TTeam(string ID, string Name, string EnglishName, List<Color> Colors)
		{
			this.ID = ID;
			this.Name = Name;
			this.EnglishName = EnglishName;
			this.Colors = Colors;
		}
	}

	/// 
	/// TABLE POSITION
	/// 
	public class TTablePosition
	{
		public TTeam Team;

		public int MP, W, D, L, GF, GA, GDiff, Points;

		public TTablePosition(TTeam Team)
		{
			this.Team = Team;
			ResetInfo();
		}

		public void ResetInfo()
		{
			MP = 0;
			W = 0;
			D = 0;
			L = 0;
			GF = 0;
			GA = 0;
			GDiff = 0;
			Points = 0;
		}

		public void AddMatchResult(TMatch match)
		{
			bool home = Team.ID.Equals(match.Team1.ID), away = Team.ID.Equals(match.Team2.ID);
			if (!home && !away)
			{
				MessageBox.Show("TTablePosition.AddMatchResult(match IDReference=" + match.ID + ") ERROR: table position team " + Team.ID + " not involved!");
				return;
			}
			if (home)
			{
				if (match.Score.EqualResult())
					D++;
				else if (match.Score.HomeWin())
					W++;
				else if (match.Score.AwayWin())
					L++;
				GF += match.Score.FinalScore().Goals1;
				GA += match.Score.FinalScore().Goals2;
			}
			else
			{
				if (match.Score.EqualResult())
					D++;
				else if (match.Score.HomeWin())
					L++;
				else if (match.Score.AwayWin())
					W++;
				GA += match.Score.FinalScore().Goals1;
				GF += match.Score.FinalScore().Goals2;
			}
			MP = W + D + L;
			GDiff = GF - GA;
			Points = 3 * W + D;
		}
	}

	/// 
	/// GROUP
	/// 
	public class TGroup
	{
		public string ID, Name;
		public List<TTablePosition> Teams = new List<TTablePosition>();

		public TGroup(string ID, string Name, List<TTeam> TeamList)
		{
			this.ID = ID;
			this.Name = Name;
			foreach (TTeam team in TeamList)
				Teams.Add(new TTablePosition(team));
		}

		public void RefreshGroupStandings()
		{
			foreach (TTablePosition posTeam in Teams)
			{
				posTeam.ResetInfo();
				foreach (TMatch match in Var.DB.Matches)
					if (match.Type.Equals(ID) && match.Played && (match.Team1.ID.Equals(posTeam.Team.ID) || match.Team2.ID.Equals(posTeam.Team.ID)))
						posTeam.AddMatchResult(match);
			}
			SortTeams();
		}

		private bool ShouldSwitchPlaces(TTablePosition T1, TTablePosition T2)
		{
			if (T1.Points < T2.Points)
				return true;
			else
				if (T1.Points == T2.Points && T1.GDiff < T2.GDiff)
					return true;
				else
					if (T1.Points == T2.Points && T1.GDiff == T2.GDiff && T1.GF < T2.GF)
						return true;
					else
						if (T1.Points == T2.Points && T1.GDiff == T2.GDiff && T1.GF == T2.GF && T1.Team.ID.CompareTo(T2.Team.ID) > 0)
							return true;
			return false;
		}

		private void SortTeams()
		{
			for (int i = 0; i < Teams.Count - 1; i++)
				for (int j = i + 1; j < Teams.Count; j++)
					if (ShouldSwitchPlaces(Teams[i], Teams[j]))
					{
						TTablePosition aux = Teams[i];
						Teams[i] = Teams[j];
						Teams[j] = aux;
					}
			//Teams.Reverse(i, 2) DOESN"T FUCKING WORK

			/*string s = "";
			foreach (TTablePosition t in Teams)
				s = string.Format("{0}{1}: {2}pts ({3}-{4})\n", s, t.Team.Name, t.Points, t.GF, t.GA);
			MessageBox.Show(s);*/
		}
	}

	///
	/// HALF
	///
	public struct THalfScore
	{
		public int Goals1, Goals2;

		public THalfScore(int G1, int G2)
		{
			Goals1 = G1;
			Goals2 = G2;
		}

		public void ResetScore()
		{
			Goals1 = 0;
			Goals2 = 0;
		}

		public void AddGoals(int G1, int G2)
		{
			Goals1 += G1;
			Goals2 += G2;
		}

		public bool EqualScore()
		{
			return Goals1 == Goals2;
		}

		public string FormatHalfScore()
		{
			return string.Format("{0}-{1}", Goals1, Goals2);
		}
	}

	///
	/// SCORE
	/// 
	public class TScore : IComparable
	{
		public List<THalfScore> Halves = new List<THalfScore>();

		public TScore(bool initializeWithNilNil)
		{
			if (initializeWithNilNil)
			{
				Halves.Add(new THalfScore(0, 0));
				Halves.Add(new THalfScore(0, 0));
			}
		}

		public THalfScore FinalScore()
		{
			return ScoreUpToMoment(Halves.Count);
		}

		public THalfScore ScoreUpToMoment(int NumberOfHalves)
		{
			THalfScore score = new THalfScore();
			for (int i = 0; i < Halves.Count && i < NumberOfHalves; i++)
				score.AddGoals(Halves[i].Goals1, Halves[i].Goals2);
			return score;
		}

		// To be used only for played matches for correct results
		// > 0 means current is greater, < 0 means current is lower
		// NOTE THAT THIS MIGHT NOT BE 100% CORRECT
		public int CompareTo(object scoreObj)
		{
			TScore sc = scoreObj as TScore;

			// were they draws in the end?
			if (this.EqualResult() && sc.EqualResult())
				return this.TotalGoalsScored().CompareTo(sc.TotalGoalsScored());
			else
			{
				// no; which had the clearest winner in 90/120 mins?
				if (this.GoalDifference() != sc.GoalDifference())
					return this.GoalDifference().CompareTo(sc.GoalDifference());
				else
				{
					// no one; ok, did anyone actually win in any of them? 
					bool w1 = this.HomeWin() || this.AwayWin(), w2 = sc.HomeWin() || sc.AwayWin();
					if (w1 != w2)
						return w1.CompareTo(w2);
					else
					{
						// no... they both must be a ties; in which one did someone score more?
						if (this.TotalGoalsScored() != sc.TotalGoalsScored())
							return this.TotalGoalsScored().CompareTo(sc.TotalGoalsScored());
						// it's basically the same tie
						return this.Halves.Count.CompareTo(sc.Halves.Count);
					}
				}
			}
		}

		public bool EqualResult()
		{ return FinalScore().Goals1 == FinalScore().Goals2; }

		public bool HomeWin()
		{ return FinalScore().Goals1 > FinalScore().Goals2; }

		public bool AwayWin()
		{ return FinalScore().Goals1 < FinalScore().Goals2; }

		public bool FinishedInRegularTime()
		{ return Halves.Count == 2; }

		public bool FinishedInExtraTime()
		{ return Halves.Count == 4; }

		public bool FinishedAtPenalties()
		{ return Halves.Count == 5; }

		public int TotalGoalsScored()
		{ return ScoreUpToMoment(Halves.Count >= 4 ? 4 : 2).Goals1 + ScoreUpToMoment(Halves.Count >= 4 ? 4 : 2).Goals2; }

		public int GoalDifference()
		{ int d = ScoreUpToMoment(Halves.Count >= 4 ? 4 : 2).Goals1 - ScoreUpToMoment(Halves.Count >= 4 ? 4 : 2).Goals2; return d < 0 ? -d : d; }
	}

	///
	/// MATCH CONDITIONS
	/// 
	public class TMatchConditions
	{
		public string Temperature;
		public string WindSpeed;
		public string RelativeHumidity;

		public TMatchConditions(string Temperature, string WindSpeed, string RelativeHumidity)
		{
			this.Temperature = Temperature;
			this.WindSpeed = WindSpeed;
			this.RelativeHumidity = RelativeHumidity;
		}

		public override string ToString()
		{
			return string.Format("{0}/{1}/{2}", Temperature, WindSpeed, RelativeHumidity);
		}
	}

	/// 
	/// MATCH
	/// 
	public class TMatch
	{
		public static int TeamNotInvolved = 0, HomeTeam = 1, AwayTeam = 2;

		public int ID;
		public string Type, Team1Ref, Team2Ref;
		public TTeam Team1, Team2;
		public DateTime When;
		public TArena Where;
		public bool Played;
		public TScore Score;
		public TMatchConditions Conditions;

		public TMatch(int ID, string Type, string Team1Ref, string Team2Ref, TTeam Team1, TTeam Team2, DateTime When, TArena Where, bool Played, TScore Score, TMatchConditions MatchConditions)
		{
			this.ID = ID;
			this.Type = Type;
			this.Team1Ref = Team1Ref;
			this.Team2Ref = Team2Ref;
			this.Team1 = Team1;
			this.Team2 = Team2;
			this.When = When;
			this.Where = Where;
			this.Played = Played;
			this.Score = Score;
			this.Conditions = MatchConditions;
		}

		public string FormatScore()
		{
			if (!Played)
				return "-";
			if (Score.FinishedAtPenalties())
			{
				string s = Score.ScoreUpToMoment(4).FormatHalfScore();
				s = Score.AwayWin() ? s + "*" : "*" + s;
				return s;
			}
			return Score.FinalScore().FormatHalfScore();
		}

		public string FormatSubscore()
		{
			if (!Played)
				return "the match has not been played yet\nafter it has, click the Edit button and fill in the scores";
			string[] sc = new string[5];
			for (int i = 0; i < Score.Halves.Count; i++)
				sc[i] = Score.ScoreUpToMoment(i + 1).FormatHalfScore();
			switch (Score.Halves.Count)
			{
				case 2:
					return "match finished in regular time\nthe score was " + sc[0] + " at half-time";
				case 4:
					return string.Format("match finished in extra-time\n{0} at half-time; {1} after 90 mins, and {2} after the first extra-time period",
						sc[0], sc[1], sc[2]);
				case 5:
					return string.Format("match finished at penalties, {0}\n{1} at half-time; {2} after 90 mins, {3} after the first extra-time period, and {4} after 120 mins",
						Score.Halves[4].FormatHalfScore(), sc[0], sc[1], sc[2], sc[3]);
				default:
					return "TMatch.FormatSubscore() ERROR: invalid no. of halves";
			}
		}

		public string FormatFullScore()
		{
			if (!Played)
				return "-";
			string res = Score.FinalScore().FormatHalfScore() + " (";
			foreach (THalfScore half in Score.Halves)
				res = res + half.FormatHalfScore() + ", ";
			return res.Substring(0, res.Length - 2) + ")";
		}

		public string ScoreLogicProblems()
		{
			if (!Played)
				return "";
			foreach (THalfScore half in Score.Halves)
				if (half.Goals1 < 0 || half.Goals2 < 0)
					return "negative goal values";
			//group match
			if (Var.DB.GetGroupByID(Type) != null && Score.Halves.Count > 2)
				return "can not have extra time/penalties for group match";
			//eliminatory match
			if (Var.DB.GetGroupByID(Type) == null)
			{
				if (Score.EqualResult())
					return "final score equal in eliminatory match";
				if (Score.Halves.Count > 2 && !Score.ScoreUpToMoment(2).EqualScore())
					return "had extra-time/penalties, although the score after 90 mins was not equal";
				if (Score.Halves.Count == 5 && !Score.ScoreUpToMoment(4).EqualScore())
					return "had penalties, although the score after 120 mins was not equal";
			}
			return "";
		}

		public bool IsGroupMatch()
		{
			return this.Type[0] == 'G';
		}

		public double ConditionAverage()
		{
			int t, w, h;
			if (!Int32.TryParse(Conditions.Temperature, out t) || !Int32.TryParse(Conditions.WindSpeed, out w) || !Int32.TryParse(Conditions.RelativeHumidity, out h))
				return 0;
			return (double) (t * 85 + h * 9 - w * 6) / 100;
		}
	}

	/// 
	/// DATABASE
	///
	public class TDatabase
	{
		private static string dataFilePath = "data\\data.xml";
		private static string settingsFilePath = "data\\settings.xml";
		private static DateTime defaultDateTime = new DateTime(2014, 1, 1);
		public static Random RandomNumber = new Random();

		public TSettings Settings = new TSettings(settingsFilePath);
		public string[] MusicFiles = new string[0];

		public List<TArena> Arenas = new List<TArena>();
		public List<TTeam> Teams = new List<TTeam>();
		public List<TGroup> Groups = new List<TGroup>();
		public List<TMatch> Matches = new List<TMatch>();

		public TTeam UnknownTeam = null;

		public Bitmap BackgroundImage, LogoImage, LogoSmallImage;
		public Bitmap UnknownTeamFlagSmall, UnknownTeamFlagMediumSmall, UnknownTeamFlagMedium, UnknownTeamFlagLarge;
		public Bitmap GoogleImage, WikipediaImage;
		public Bitmap PlayOffImage;
		public string TimeZone = "unknown timezone";

		//
		public bool ReadFromFile()
		{
			bool errors = false;
			string Phase = "";

			try
			{
				Phase = "initializing/resetting";
				Arenas.Clear();
				Teams.Clear();
				Groups.Clear();
				Matches.Clear();

				Phase = "reading from xml";
				XmlDocument doc = new XmlDocument();
				doc.Load(dataFilePath);

				// Arenas
				Phase = "decoding arenas";
				XmlNode node = doc.ChildNodes[0].ChildNodes[0];
				foreach (XmlNode arena in node)
				{
					string city = arena.Attributes["city"].Value, name = arena.Attributes["name"].Value;
					int capacity = Int32.Parse(arena.Attributes["capacity"].Value), built = Int32.Parse(arena.Attributes["built"].Value);
					Arenas.Add(new TArena(city, name, capacity, built));
				}

				// Teams
				Phase = "decoding teams";
				node = node.NextSibling;
				foreach (XmlNode team in node)
				{
					string id = team.Attributes["id"].Value, name = team.Attributes["name"].Value, english = team.Attributes["english"].Value;
					List<Color> col = new List<Color>();
					foreach (string s in team.Attributes["colors"].Value.Split(','))
						col.Add(System.Drawing.ColorTranslator.FromHtml(s));
					Teams.Add(new TTeam(id, name, english, col));
				}

				// Groups
				Phase = "decoding groups";
				node = node.NextSibling;
				foreach (XmlNode group in node)
				{
					string id = group.Attributes["id"].Value, name = group.Attributes["name"].Value;
					List<TTeam> teams = new List<TTeam>();
					foreach (string s in group.Attributes["teams"].Value.Split(','))
						teams.Add(GetTeamByNominalID(s));
					Groups.Add(new TGroup(id, name, teams));
				}

				// MatchesInfo
				Phase = "decoding matches";
				node = node.NextSibling;
				TimeZone = node.Attributes["timezone"].Value;
				foreach (XmlNode match in node)
				{
					int id = Int32.Parse(match.Attributes["id"].Value);
					string type = match.Attributes["type"].Value;
					string[] teamRefs = match.Attributes["teams"].Value.Split(',');
					List<TTeam> teams = new List<TTeam>();
					foreach (string s in teamRefs)
					{
						TTeam t = GetTeamReferenceType(s) == TTeam.NominalTeamReference ? GetTeamByNominalID(s) : null;
						teams.Add(t);
					}
					DateTime when = DecodeDateTime(match.Attributes["when"].Value);
					TArena where = GetArenaByCity(match.Attributes["where"].Value);
					bool played = Boolean.Parse(match.Attributes["played"].Value);
					TScore score = DecodeScore(match.Attributes["score"].Value);
					string[] cond = match.Attributes["conditions"].Value.Split('/');
					TMatchConditions conditions = new TMatchConditions(cond[0], cond[1], cond[2]);
					Matches.Add(new TMatch(id, type, teamRefs[0], teamRefs[1], teams[0], teams[1], when, where, played, score, conditions));
				}

				Phase = "done?";
			}
			catch (Exception E)
			{
				MessageBox.Show(E.ToString() + "\n\nPhase: " + Phase, "TDatabase.ReadFromFile() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				errors = true;
			}
			return !errors;
		}

		//
		public bool VerifyAndConnectData()
		{
			bool errors = false;
			string s = "init?";
			try
			{
				s = "Music file checks: ";
				MusicFiles = Directory.GetFiles(Var.MusicPath, "*.mp3", SearchOption.TopDirectoryOnly);

				s = "Image file checks: ";
				if (!File.Exists(Var.ImagesPath + "\\background.png"))
					throw new Exception(s + "background image does not exist");
				BackgroundImage = new Bitmap(Var.ImagesPath + "\\background.png");
				if (!File.Exists(Var.ImagesPath + "\\logo.png"))
					throw new Exception(s + "logo image does not exist");
				LogoImage = new Bitmap(Var.ImagesPath + "\\logo.png");
				if (!File.Exists(Var.ImagesPath + "\\logoSmall.png"))
					throw new Exception(s + "small logo image does not exist");
				LogoSmallImage = new Bitmap(Var.ImagesPath + "\\logoSmall.png");

				if (!File.Exists(Var.FlagsSmallPath + "\\unknown.png"))
					throw new Exception(s + "small unknown team flag does not exist");
				UnknownTeamFlagSmall = new Bitmap(Var.FlagsSmallPath + "\\unknown.png");
				if (!File.Exists(Var.FlagsMediumSmallPath + "\\unknown.png"))
					throw new Exception(s + "medium/small unknown team flag does not exist");
				UnknownTeamFlagMediumSmall = new Bitmap(Var.FlagsMediumSmallPath + "\\unknown.png");
				if (!File.Exists(Var.FlagsMediumPath + "\\unknown.png"))
					throw new Exception(s + "medium unknown team flag does not exist");
				UnknownTeamFlagMedium = new Bitmap(Var.FlagsMediumPath + "\\unknown.png");
				if (!File.Exists(Var.FlagsLargePath + "\\unknown.png"))
					throw new Exception(s + "large unknown team flag does not exist");
				UnknownTeamFlagLarge = new Bitmap(Var.FlagsLargePath + "\\unknown.png");

				UnknownTeam = new TTeam("TBD", "To be determined", "To be determined", new List<Color>());
				UnknownTeam.Colors.Add(Color.White);
				UnknownTeam.FlagSmall = UnknownTeamFlagSmall;
				UnknownTeam.FlagMediumSmall = UnknownTeamFlagMediumSmall;
				UnknownTeam.FlagMedium = UnknownTeamFlagMedium;
				UnknownTeam.FlagLarge = UnknownTeamFlagLarge;

				if (!File.Exists(Var.ImagesPath + "\\google.png"))
					throw new Exception(s + "google image does not exist");
				GoogleImage = new Bitmap(Var.ImagesPath + "\\google.png");
				if (!File.Exists(Var.ImagesPath + "\\wikipedia.png"))
					throw new Exception(s + "wikipedia image does not exist");
				WikipediaImage = new Bitmap(Var.ImagesPath + "\\wikipedia.png");

				if (!File.Exists(Var.ImagesPath + "\\playoff.png"))
					throw new Exception(s + "playoff image does not exist");
				PlayOffImage = new Bitmap(Var.ImagesPath + "\\playoff.png");

				s = "Global checks: ";
				if (this.Arenas.Count != 12)
					throw new Exception(s + "incorrect number of arenas");
				if (this.Teams.Count != 32)
					throw new Exception(s + "incorrect number of teams");
				if (this.Groups.Count != 8)
					throw new Exception(s + "incorrect number of groups");
				if (this.Matches.Count != 64)
					throw new Exception(s + "incorrect number of total matches");

				s = "Arenas verification: ";
				for (int i = 0; i < Arenas.Count - 1; i++)
					for (int j = i + 1; j < Arenas.Count; j++)
						if (Arenas[i].City.Equals(Arenas[j].City))
							throw new Exception(s + "duplicate arena city \"" + Arenas[j].City + "\"");
				for (int i = 0; i < Arenas.Count; i++)
				{
					if (!File.Exists(Var.ArenaImagesPath + "\\" + Arenas[i].City + ".jpg"))
						throw new Exception(s + "arena image for arena with city \"" + Arenas[i].City + "\" does not exist");
					if (!File.Exists(Var.CityLocationImagesPath + "\\" + Arenas[i].City + ".png"))
						throw new Exception(s + "city location image for city \"" + Arenas[i].City + "\" does not exist");
					Arenas[i].ArenaImage = new Bitmap(Var.ArenaImagesPath + "\\" + Arenas[i].City + ".jpg");
					Arenas[i].CityLocationImage = new Bitmap(Var.CityLocationImagesPath + "\\" + Arenas[i].City + ".png");
					FArena.ArenaButtons[i].Information = Var.DB.Arenas[i].City;
				}

				s = "Teams verification: ";
				for (int i = 0; i < Teams.Count - 1; i++)
					for (int j = i + 1; j < Teams.Count; j++)
						if (Teams[i].ID.Equals(Teams[j].ID))
							throw new Exception(s + "duplicate posTeam IDReference \"" + Teams[j].ID + "\"");
				for (int i = 0; i < Teams.Count; i++)
				{
					if (Teams[i].Colors.Count == 0)
						throw new Exception(s + "color list is empty for posTeam with IDReference \"" + Teams[i].ID + "\"");

					if (!File.Exists(Var.FlagsSmallPath + "\\" + Teams[i].ID + ".png"))
						throw new Exception(s + "small flag image for posTeam with IDReference \"" + Teams[i].ID + "\" does not exist");
					if (!File.Exists(Var.FlagsMediumSmallPath + "\\" + Teams[i].ID + ".png"))
						throw new Exception(s + "medium/small flag image for posTeam with IDReference \"" + Teams[i].ID + "\" does not exist");
					if (!File.Exists(Var.FlagsMediumPath + "\\" + Teams[i].ID + ".png"))
						throw new Exception(s + "medium flag image for posTeam with IDReference \"" + Teams[i].ID + "\" does not exist");
					if (!File.Exists(Var.FlagsLargePath + "\\" + Teams[i].ID + ".png"))
						throw new Exception(s + "large flag image for posTeam with IDReference \"" + Teams[i].ID + "\" does not exist");

					Teams[i].FlagSmall = new Bitmap(Var.FlagsSmallPath + "\\" + Teams[i].ID + ".png");
					Teams[i].FlagMediumSmall = new Bitmap(Var.FlagsMediumSmallPath + "\\" + Teams[i].ID + ".png");
					Teams[i].FlagMedium = new Bitmap(Var.FlagsMediumPath + "\\" + Teams[i].ID + ".png");
					Teams[i].FlagLarge = new Bitmap(Var.FlagsLargePath + "\\" + Teams[i].ID + ".png");

					FTeam.TeamButtons[i].Information = Var.DB.Teams[i].ID;
					FTeam.TeamButtons[i].Image = Var.DB.Teams[i].FlagMediumSmall;
				}

				s = "Groups verification: ";
				for (int i = 0; i < Groups.Count - 1; i++)
					for (int j = i + 1; j < Groups.Count; j++)
						if (Groups[i].ID.Equals(Groups[j].ID))
							throw new Exception(s + "duplicate group IDReference \"" + Groups[j].ID + "\"");
				for (int i = 0; i < Groups.Count; i++)
				{
					string id = Groups[i].ID;
					if (id.Length != 2 || id[0] != 'G' || (id[1] < 'A' && id[1] > 'H'))
						throw new Exception(s + "incorrect group IDReference \"" + id + "\"");
					if (Groups[i].Teams.Count != 4)
						throw new Exception(s + "incorrect number of teams for group with IDReference \"" + id + "\"");
					foreach (TTablePosition posTeam in Groups[i].Teams)
						if (posTeam == null)
							throw new Exception(s + "null posTeam in group with IDReference \"" + id + "\"");
				}

				s = "MatchesInfo verification: ";
				for (int i = 0; i < Matches.Count - 1; i++)
					for (int j = i + 1; j < Matches.Count; j++)
						if (Matches[i].ID.Equals(Matches[j].ID))
							throw new Exception(s + "duplicate match IDReference \"" + Matches[j].ID + "\"");
				for (int i = 0; i < Matches.Count; i++)
				{
					if (Matches[i].ID < 1 && Matches[i].ID > 64)
						throw new Exception(s + "illegal match IDReference \"" + Matches[i].ID + "\"");
					string t = Matches[i].Type;
					bool a = (t.Length == 2 && t[0] == 'G' && CharInSet(t[0], "ABCDEFGH"));
					bool b = (t.Length == 2 && t[1] == 'F' && CharInSet(t[0], "842LW"));
					if (!a && !b)
						throw new Exception(s + "illegal match type for match with IDReference \"" + Matches[i].ID + "\"");
					if (i < 48 && Matches[i].Team1 == null)
						throw new Exception(s + "null (host) posTeam for match with IDReference \"" + Matches[i].ID + "\"");
					if (i < 48 && Matches[i].Team2 == null)
						throw new Exception(s + "null (guest) posTeam for match with IDReference \"" + Matches[i].ID + "\"");
					if (Matches[i].Where == null)
						throw new Exception(s + "null arena for match with IDReference \"" + Matches[i].ID + "\"");
					a = FormatDateTimeForComparison(Matches[i].When).CompareTo("2014/06/12 00:00") >= 0;
					b = FormatDateTimeForComparison(Matches[i].When).CompareTo("2014/07/13 23:59") <= 0;
					if (!a && !b)
						throw new Exception(s + "illegal datetime for match with IDReference \"" + Matches[i].ID + "\"");
					int n = Matches[i].Score.Halves.Count;
					if (n != 2 && n != 4 && n != 5)
						throw new Exception(s + "incorrect score for match with IDReference \"" + Matches[i].ID + "\"");
					if (!Matches[i].ScoreLogicProblems().Equals(""))
						MessageBox.Show("The score " + Matches[i].FormatFullScore() + " for match with IDReference \"" + Matches[i].ID +
							"\" is illogic: " + Matches[i].ScoreLogicProblems() + "!\nThis, however, will not affect the functioning of the application. Only the final score will be taken into account.",
							"TDatabase.VerifyAndConnectData() WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception E)
			{
				MessageBox.Show("ERROR: " + E.Message + "!\n\nPhase: " + s, "TDatabase.VerifyAndConnectData() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				errors = true;
			}
			return !errors;
		}

		public static XmlAttribute GetNewAttribute(XmlDocument doc, string name, string value)
		{
			XmlAttribute attr = doc.CreateAttribute(name);
			attr.Value = value;
			return attr;
		}

		public static XmlAttribute GetNewAttribute(XmlDocument doc, string name, int value)
		{
			return GetNewAttribute(doc, name, value.ToString());
		}

		//
		public bool SaveToFile()
		{
			bool errors = false;
			string Phase = "initializing";
			try
			{
				XmlDocument doc = new XmlDocument();
				XmlNode root, node, item;

				root = doc.AppendChild(doc.CreateElement("DATABASE"));
				root.Attributes.Append(GetNewAttribute(doc, "lastSavedCirca", FormatDateTimeForComparison(DateTime.Now)));

				Phase = "arenas";
				node = root.AppendChild(doc.CreateElement("ARENAS"));
				foreach (TArena arena in Arenas)
				{
					item = node.AppendChild(doc.CreateElement("Arena"));
					item.Attributes.Append(GetNewAttribute(doc, "city", arena.City));
					item.Attributes.Append(GetNewAttribute(doc, "name", arena.ArenaName));
					item.Attributes.Append(GetNewAttribute(doc, "capacity", arena.Capacity));
					item.Attributes.Append(GetNewAttribute(doc, "built", arena.YearBuilt));
				}

				Phase = "teams";
				node = root.AppendChild(doc.CreateElement("TEAMS"));
				foreach (TTeam team in Teams)
				{
					item = node.AppendChild(doc.CreateElement("Team"));
					item.Attributes.Append(GetNewAttribute(doc, "id", team.ID));
					item.Attributes.Append(GetNewAttribute(doc, "name", team.Name));
					item.Attributes.Append(GetNewAttribute(doc, "english", team.EnglishName));
					string s = "";
					foreach (Color col in team.Colors)
						s = string.Format("{0},{1}", s, System.Drawing.ColorTranslator.ToHtml(col));
					if (s.Length > 0)
						s = s.Substring(1, s.Length - 1);
					item.Attributes.Append(GetNewAttribute(doc, "colors", s));
				}

				Phase = "groups";
				node = root.AppendChild(doc.CreateElement("GROUPS"));
				foreach (TGroup group in Groups)
				{
					item = node.AppendChild(doc.CreateElement("Group"));
					item.Attributes.Append(GetNewAttribute(doc, "id", group.ID));
					item.Attributes.Append(GetNewAttribute(doc, "name", group.Name));
					string s = "";
					foreach (TTablePosition posTeam in group.Teams)
						s = string.Format("{0},{1}", s, posTeam.Team.ID);
					if (s.Length > 0)
						s = s.Substring(1, s.Length - 1);
					item.Attributes.Append(GetNewAttribute(doc, "teams", s));
				}

				Phase = "matches";
				node = root.AppendChild(doc.CreateElement("MATCHES"));
				node.Attributes.Append(GetNewAttribute(doc, "timezone", Var.DB.TimeZone));
				foreach (TMatch match in Matches)
				{
					item = node.AppendChild(doc.CreateElement("Match"));
					item.Attributes.Append(GetNewAttribute(doc, "id", match.ID));
					item.Attributes.Append(GetNewAttribute(doc, "type", match.Type));
					item.Attributes.Append(GetNewAttribute(doc, "teams", match.Team1Ref + "," + match.Team2Ref));
					item.Attributes.Append(GetNewAttribute(doc, "when", EncodeDateTime(match.When)));
					item.Attributes.Append(GetNewAttribute(doc, "where", match.Where.City));
					item.Attributes.Append(GetNewAttribute(doc, "played", match.Played.ToString()));
					item.Attributes.Append(GetNewAttribute(doc, "score", EncodeScore(match.Score)));
					item.Attributes.Append(GetNewAttribute(doc, "conditions", match.Conditions.ToString()));
				}

				Phase = "saving xml";
				doc.Save(dataFilePath);
			}
			catch (Exception E)
			{
				MessageBox.Show(E.ToString() + "\n\nPhase: " + Phase, "TDatabase.SaveToFile() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				errors = true;
			}
			return !errors;
		}

		// OTHER METHODS:

		//
		public void RefreshAllGroupStandings()
		{
			foreach (TGroup group in Groups)
				group.RefreshGroupStandings();
		}

		//
		public int GetTeamReferenceType(string Reference)
		{
			// test if it's an eight-final or other-file match ref
			bool a = (Reference.Length == 3 && Reference[0] == 'G' && CharInSet(Reference[1], "ABCDEFGH") && CharInSet(Reference[2], "12"));
			bool b = (Reference.Length == 3 && CharInSet(Reference[0], "WL") && CharInSet(Reference[1], "456") && CharInSet(Reference[2], "0123456789"));
			if (a || b)
				return TTeam.PlayOffTeamReference;
			// test if it's actually a nominal reference
			foreach (TTeam team in Teams)
				if (team.ID.Equals(Reference))
					return TTeam.NominalTeamReference;
			// it's not
			MessageBox.Show("TDatabase.GetTeamReferenceType() ERROR: Could not decide what team reference \"" + Reference + "\" is!", "TDatabase.GetTeamByNominalID() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return TTeam.IncorrectTeamReference;
		}

		//
		public TTeam GetTeamByNominalID(string IDReference)
		{
			// search in group (nominal) teams
			foreach (TTeam team in Teams)
				if (team.ID.Equals(IDReference))
					return team;
			// it's not 
			MessageBox.Show("TDatabase.GetTeamByNominalID() ERROR: Could not find posTeam with IDReference \"" + IDReference + "\" !", "TDatabase.GetTeamByNominalID() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		//
		public TTeam GetTeamByPlayOffReference(string Reference)
		{
			// look up play off matches for team reference (eg. "W52")
			// we need to extract a group team
			if (Reference[0] == 'G')
			{
				TGroup group = GetGroupByID(Reference.Substring(0, 2));
				int pos = Int32.Parse(Reference[2].ToString());
				TTeam team = GetTeamByNominalID(group.Teams[pos - 1].Team.ID);
				// if the team has played all its 3 group matches, it's good for forwarding
				List<TMatch> matches = GetMatchesForTeam(team.ID, true);
				if (matches.Count == 3)
				{
					int nP = 0;
					foreach (TMatch match in matches)
						if (match.Played)
							nP++;
					if (nP == 3)
						return team;
				}
				// otherwise the reference will be null
				return null;
			}
			// we need to get the winner of a previous match
			else if (Reference[0] == 'W')
			{
				TMatch match = GetMatchByID(Int32.Parse(Reference.Substring(1, 2)));
				// if it hasn't been played, no need to worry
				if (!match.Played)
					return null;
				// get the winner (default to home win if score is tied - which it should'nt be anyway)
				if (match.Score.AwayWin())
					return GetTeamByPlayOffReference(match.Team2Ref);
				return GetTeamByPlayOffReference(match.Team1Ref);
			}
			// we need to get the losers of a previous match (the semifinals, but the code isn't that discrimating)
			else if (Reference[0] == 'L')
			{
				TMatch match = GetMatchByID(Int32.Parse(Reference.Substring(1, 2)));
				// if it hasn't been played, no need to worry
				if (!match.Played)
					return null;
				// get the loser (default to away loss if score is tied - which it should'nt be anyway)
				if (!match.Score.HomeWin())
					return GetTeamByPlayOffReference(match.Team1Ref);
				return GetTeamByPlayOffReference(match.Team2Ref);
			}
			// somnething's dubious
			else
			{
				MessageBox.Show("TDatabase.GetTeamByPlayOffReference(Reference \"" + Reference + "\"): incorrect play off reference");
				return null;
			}
		}

		//
		public TArena GetArenaByCity(string City)
		{
			foreach (TArena arena in Arenas)
				if (arena.City.Equals(City))
					return arena;
			MessageBox.Show("Could not find arena with City \"" + City + "\" !", "TDatabase.GetArenaByCity() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		//
		public TGroup GetGroupByID(string ID)
		{
			foreach (TGroup group in Groups)
				if (group.ID.Equals(ID))
					return group;
			return null;
		}

		//
		public TGroup GetGroupByTeam(TTeam team)
		{
			foreach (TGroup group in Groups)
				foreach (TTablePosition posTeam in group.Teams)
					if (posTeam.Team.ID.Equals(team.ID))
						return group;
			return null;
		}

		//
		public TMatch GetMatchByID(int ID)
		{
			foreach (TMatch match in Matches)
				if (match.ID == ID)
					return match;
			return null;
		}

		//
		public List<TMatch> GetAllMatches()
		{
			List<TMatch> list = new List<TMatch>();
			foreach (TMatch match in Matches)
				list.Add(match);
			return list;
		}

		//
		public int MatchInvolvesTeam(TMatch match, string teamID)
		{
			bool a, b;
			if (match.Team1 != null)
				a = match.Team1.ID.Equals(teamID);
			else
			{
				TTeam TeamRef = GetTeamByPlayOffReference(match.Team1Ref);
				a = TeamRef != null ? TeamRef.ID.Equals(teamID) : false;
			}
			if (match.Team2 != null)
				b = match.Team2.ID.Equals(teamID);
			else
			{
				TTeam TeamRef = GetTeamByPlayOffReference(match.Team2Ref);
				b = TeamRef != null ? TeamRef.ID.Equals(teamID) : false;
			}
			if (a)
				return TMatch.HomeTeam;
			if (b)
				return TMatch.AwayTeam;
			return TMatch.TeamNotInvolved;
		}

		//
		private List<TMatch> GetMatchesForTeam(string teamID, bool groupMatches)
		{
			List<TMatch> res = new List<TMatch>();
			foreach (TMatch match in Matches)
				if (match.IsGroupMatch() == groupMatches && MatchInvolvesTeam(match, teamID) != TMatch.TeamNotInvolved)
					res.Add(match);
			return res;
		}

		//
		public List<TMatch> GetGroupMatchesForTeam(string teamID)
		{
			return GetMatchesForTeam(teamID, true);
		}

		//
		public List<TMatch> GetPlayOffMatchesForTeam(string teamID)
		{
			return GetMatchesForTeam(teamID, false);
		}

		//
		public List<TMatch> GetMatchesForGroup(string groupID)
		{
			List<TMatch> res = new List<TMatch>();
			foreach (TMatch match in Matches)
				if (match.Type.Equals(groupID))
					res.Add(match);
			return res;
		}

		//
		public List<TMatch> GetMatchesByDate(DateTime dt)
		{
			List<TMatch> res = new List<TMatch>();
			foreach (TMatch match in Matches)
				if (FormatDateForComparison(match.When).Equals(FormatDateForComparison(dt)))
					res.Add(match);
			return res;
		}

		//
		public List<TMatch> GetMatchesByArena(string City)
		{
			List<TMatch> res = new List<TMatch>();
			foreach (TMatch match in Matches)
				if (match.Where.City.Equals(City))
					res.Add(match);
			return res;
		}

		//
		public TMatchConditions GetMatchConditionsForArena(string city)
		{
			int t = 0, w = 0, h = 0, nt = 0, nw = 0, nh = 0, temp;
			foreach (TMatch match in Matches)
				if (match.Where.City.Equals(city))
				{
					if (Int32.TryParse(match.Conditions.Temperature, out temp))
					{ t += temp; nt++; }
					if (Int32.TryParse(match.Conditions.WindSpeed, out temp))
					{ w += temp; nw++; }
					if (Int32.TryParse(match.Conditions.RelativeHumidity, out temp))
					{ h += temp; nh++; }
				}
			double dt = nt > 0 ? ((double) t / nt) : 0, dw = nw > 0 ? ((double) w / nw) : 0, dh = nh > 0 ? ((double) h / nh) : 0;
			return new TMatchConditions(dt.ToString("0.0"), dw.ToString("0.0"), dh.ToString("0.0"));
		}

		//
		public static DateTime DecodeDateTime(string s)
		{
			DateTime dt = defaultDateTime;
			try
			{
				int day = Int32.Parse(s.Substring(0, 2)), month = Int32.Parse(s.Substring(3, 2)), hour = Int32.Parse(s.Substring(6, 2));
				dt = new DateTime(2014, month, day, hour, 0, 0);
			}
			catch (Exception E)
			{ MessageBox.Show(E.ToString(), "TDatabase.DecodeDateTime() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			return dt;
		}

		//
		public static string EncodeDateTime(DateTime dt)
		{
			return string.Format("{0}/{1}@{2}", dt.Day.ToString("D2"), dt.Month.ToString("D2"), dt.Hour.ToString("D2"));
		}

		//
		public static string EncodeDate(DateTime d)
		{
			return d.ToString("MMM d");
		}

		//
		public static DateTime DecodeDate(string S)
		{
			int m = S[2] == 'n' ? 6 : 7, d = Int32.Parse(S.Substring(4, S.Length - 4));
			return new DateTime(2014, m, d);
		}

		//
		public static string FormatDateForComparison(DateTime dt)
		{
			return string.Format("{0}/{1}/{2}", dt.Year.ToString("D2"), dt.Day.ToString("D2"), dt.Month.ToString("D2"));
		}

		//
		public static string FormatDateTimeForComparison(DateTime dt)
		{
			return string.Format("{0}/{1}/{2} {3}:00", dt.Year.ToString("D2"), dt.Day.ToString("D2"), dt.Month.ToString("D2"), dt.Hour.ToString("D2"));
		}

		//
		public static TScore DecodeScore(string scoreString)
		{
			TScore score = new TScore(false);
			try
			{
				foreach (string half in scoreString.Split(','))
				{
					int a = Int32.Parse(half.Substring(0, half.IndexOf('-')));
					int b = Int32.Parse(half.Substring(half.IndexOf('-') + 1, half.Length - half.IndexOf('-') - 1));
					score.Halves.Add(new THalfScore(a, b));
				}
			}
			catch (Exception E)
			{ MessageBox.Show(E.ToString(), "TDatabase.DecodeScore() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			return score;
		}

		//
		public static string EncodeScore(TScore score)
		{
			string s = "";
			foreach (THalfScore half in score.Halves)
				s = string.Format("{0},{1}-{2}", s, half.Goals1, half.Goals2);
			if (s.Length > 0)
				s = s.Substring(1, s.Length - 1);
			return s;
		}

		//
		public string EncodeMatchForMatchList(TMatch match)
		{
			if (match.Team1 != null && match.Team2 != null)
				return string.Format("Match {0}: {1}-{2}", match.ID, match.Team1.Name, match.Team2.Name);
			return string.Format("Match {0}: {1}-{2}", match.ID, match.Team1Ref, match.Team2Ref);
		}

		//
		public TMatch DecodeMatchFromMatchList(string S)
		{
			int matchID = Int32.Parse(S.Substring(S.IndexOf(' ') + 1, S.IndexOf(':') - S.IndexOf(' ') - 1));
			return GetMatchByID(matchID);
		}

		//
		public string EncodeTeamForTeamList(TTeam team)
		{
			return string.Format("[{0}]: {1}", team.ID, team.Name);
		}

		//
		public TTeam DecodeTeamFromTeamList(string S)
		{
			S = S.Substring(S.IndexOf('[') + 1);
			return Var.DB.GetTeamByNominalID(S.Substring(0, S.IndexOf(']')));
		}

		//
		public int GoalsScoredInGroup(string groupID)
		{
			int res = 0;
			foreach (TMatch match in Matches)
				if (match.Type.Equals(groupID))
					res += match.Score.FinalScore().Goals1 + match.Score.FinalScore().Goals2;
			return res;
		}

		//
		public int TotalGoalsScored()
		{
			int res = 0;
			foreach (TMatch match in Matches)
				res += match.Score.FinalScore().Goals1 + match.Score.FinalScore().Goals2;
			return res;
		}

		//
		public int MatchesPlayedInGroup(string groupID)
		{
			int res = 0;
			foreach (TMatch match in Matches)
				if (match.Type.Equals(groupID) && match.Played)
					res++;
			return res;
		}

		//
		public int TotalMatchesPlayed()
		{
			int res = 0;
			foreach (TMatch match in Matches)
				if (match.Played)
					res++;
			return res;
		}

		//
		public bool GroupPhaseOver()
		{
			for (int i = 0; i < 48; i++)
				if (!Matches[i].Played)
					return false;
			return true;
		}

		//
		public static string FormatGoalDifference(int GDiff)
		{
			if (GDiff > 0)
				return "+" + GDiff.ToString();
			return GDiff.ToString();
		}

		//
		public static TScore GetRandomScore(bool extraTimeOrPenaltiesAndThereforeSomeoneMustWin)
		{
			TScore sc = new TScore(false);

			if (extraTimeOrPenaltiesAndThereforeSomeoneMustWin)
			{
				for (int i = 1, a = 0, b = 0, r = TDatabase.RandomNumber.Next(4); i <= 5; i++, r = TDatabase.RandomNumber.Next(4))
					if (i < 5)
					{
						if (i % 2 == 1) { a = 0; b = TDatabase.RandomNumber.Next(4); }
						else { int c = a; a = b; b = c; }
						sc.Halves.Add(new THalfScore(r + a, r + b));
					}
					else
					{
						a = 0;
						b = TDatabase.RandomNumber.Next(1, 3);
						if (TDatabase.RandomNumber.Next(2) == 1) { int c = a; a = b; b = c; }
						sc.Halves.Add(new THalfScore(r + a, r + b));
					}
			}
			else
			{
				for (int i = 1, a = 0, b = 0, r = TDatabase.RandomNumber.Next(4); i <= 2; i++, r = TDatabase.RandomNumber.Next(4))
				{
					a = 0;
					b = TDatabase.RandomNumber.Next(5);
					if (TDatabase.RandomNumber.Next(2) == 1) { int c = a; a = b; b = c; }
					sc.Halves.Add(new THalfScore(r + a, r + b));
				}
			}

			return sc;
		}

		//
		public static bool CharInSet(char Character, string CharacterSet)
		{
			return CharacterSet.Contains(Character.ToString());
		}

		//
		public static string PlayOffPhaseName(string Type)
		{
			switch (Type[0])
			{
				case '8':
					return "Eighth-finals";
				case '4':
					return "Quarter-finals";
				case '2':
					return "Semi-finals";
				case 'L':
					return "Third place match";
				case 'W':
					return "Final";
			}
			return "???";
		}

		//
		public string PlayOffReferenceName(string Reference)
		{
			if (Reference[0] == 'G')
			{
				TGroup group = GetGroupByID(Reference.Substring(0, 2));
				if (Reference[2] == '1')
					return "Winner of " + group.Name;
				return "Runner-up in " + group.Name;
			}
			else if (Reference[0] == 'W')
			{
				TMatch match = GetMatchByID(Int32.Parse(Reference.Substring(1, 2)));
				if (!match.Played)
					return "Winner of match " + Reference.Substring(1, 2);
			}
			else if (Reference[0] == 'L')
			{
				TMatch match = GetMatchByID(Int32.Parse(Reference.Substring(1, 2)));
				if (!match.Played)
					return "Loser of match " + Reference.Substring(1, 2);
			}
			return "TDatabase.GetTeamByPlayOffReference(Reference \"" + Reference + "\"): incorrect play-off reference";
		}

		//
		public DateTime GetFirstUnplayedMatchDate()
		{
			DateTime earliestUnplayedMatchDate = new DateTime(2014, 7, 13);
			foreach (TMatch match in Matches)
				if (!match.Played && match.When.CompareTo(earliestUnplayedMatchDate) < 0)
					earliestUnplayedMatchDate = match.When;
			return earliestUnplayedMatchDate;
		}

		//
		public static void SortMatches(List<TMatch> list, int criteria)
		{
			if (list.Count < 2)
				return;

			for (int i = 0; i < list.Count - 1; i++)
				for (int j = i + 1; j < list.Count; j++)
				{
					TMatch m1 = list[i], m2 = list[j];
					bool shouldSwitch = false;
					switch (criteria)
					{
						case 1: //id
							{ shouldSwitch = m1.ID > m2.ID; break; }
						case 9: //phase
							{
								if (m1.IsGroupMatch() == m2.IsGroupMatch())
								{
									List<char> chrs = new List<char>(new char[5] { 'W', 'L', '2', '4', '8' });
									if (m1.IsGroupMatch())
										shouldSwitch = (m1.Type.CompareTo(m2.Type) > 0) || (m1.Type.Equals(m2.Type) && m1.When.CompareTo(m2.When) > 0);
									else
										shouldSwitch = (chrs.IndexOf(m1.Type[0]) > chrs.IndexOf(m2.Type[0])) || (m1.Type.Equals(m2.Type) && m1.When.CompareTo(m2.When) > 0);
								}
								else
									shouldSwitch = (m1.IsGroupMatch().CompareTo(m2.IsGroupMatch()) > 0) || (m1.Type.Equals(m2.Type) && m1.When.CompareTo(m2.When) > 0);
								break;
							}
						case 2: //datetime
							{ shouldSwitch = m1.When.CompareTo(m2.When) > 0; break; }
						case 3: //city
							{ shouldSwitch = (m1.Where.City.CompareTo(m2.Where.City) > 0) || (m1.Where.City.Equals(m2.Where.City) && m1.When.CompareTo(m2.When) > 0); break; }
						case 4: //result
							{
								shouldSwitch = m1.Played && m2.Played ? m1.Score.CompareTo(m2.Score) < 0 : m1.Played.CompareTo(m2.Played) < 0;
								break;
							}
						case 5: //temperature
							{
								int temp;
								int r1 = Int32.TryParse(m1.Conditions.Temperature, out temp) ? Int32.Parse(m1.Conditions.Temperature) : 0;
								int r2 = Int32.TryParse(m2.Conditions.Temperature, out temp) ? Int32.Parse(m2.Conditions.Temperature) : 0;
								shouldSwitch = (r1 < r2) || (r1 == r2 && m1.ConditionAverage() < m2.ConditionAverage());
								break;
							}
						case 6: //wind
							{
								int temp;
								int r1 = Int32.TryParse(m1.Conditions.WindSpeed, out temp) ? Int32.Parse(m1.Conditions.WindSpeed) : 0;
								int r2 = Int32.TryParse(m2.Conditions.WindSpeed, out temp) ? Int32.Parse(m2.Conditions.WindSpeed) : 0;
								shouldSwitch = (r1 < r2) || (r1 == r2 && m1.ConditionAverage() < m2.ConditionAverage());
								break;
							}
						case 7: //humidity
							{
								int temp;
								int r1 = Int32.TryParse(m1.Conditions.RelativeHumidity, out temp) ? Int32.Parse(m1.Conditions.RelativeHumidity) : 0;
								int r2 = Int32.TryParse(m2.Conditions.RelativeHumidity, out temp) ? Int32.Parse(m2.Conditions.RelativeHumidity) : 0;
								shouldSwitch = (r1 < r2) || (r1 == r2 && m1.ConditionAverage() < m2.ConditionAverage());
								break;
							}
						case 8: //conditions
							{
								shouldSwitch = m1.ConditionAverage() < m2.ConditionAverage();
								break;
							}
					}

					if (shouldSwitch)
					{
						TMatch aux = list[i];
						list[i] = list[j];
						list[j] = aux;
					}
				}
		}
	}

	/*/																		\\\
	///								PLAYER DATABASE							\\\
	///																		 */

	/// 
	/// PLAYER COUNTRY
	///	
	public class TPlayerCountry
	{
		public string ID;
		public string Name;
		public string CoachName;
		public TPlayerCountry CoachNationality = null;
		public Bitmap Flag = null;

		public List<TPlayer> Players = new List<TPlayer>();

		public TPlayerCountry(string ID, string Name)
		{
			this.ID = ID;
			this.Name = Name;
		}
	}

	/// 
	/// PLAYER CLUB
	/// 
	public class TPlayerClub
	{
		public string ID;
		public string Name;
		public TPlayerCountry Country = null;

		public List<TPlayer> Players = new List<TPlayer>();

		public TPlayerClub(string ID, string Name, TPlayerCountry Country)
		{
			this.ID = ID;
			this.Name = Name;
			this.Country = Country;
		}
	}

	/// 
	/// PLAYER
	/// 
	public class TPlayer
	{
		public string ID;
		public string Number;
		public string Position;
		public string Name;
		public DateTime BirthDate;
		public int Caps;
		public TPlayerCountry Country = null;
		public TPlayerClub Club = null;
	}

	/// 
	/// PLAYER DATABASE
	/// 

	public class TPlayerDatabase
	{
		private static string dataFilePath = "data\\players.xml";
		private static DateTime defaultDateTime = new DateTime(2014, 1, 1);

		public List<TPlayerCountry> Countries = new List<TPlayerCountry>();
		public List<TPlayerClub> Clubs = new List<TPlayerClub>();

		//
		public bool ReadFromFile()
		{
			bool errors = false;
			string Phase = "";

			try
			{
				Phase = "initializing/resetting";
				Countries.Clear();
				Clubs.Clear();

				Phase = "reading from xml";
				XmlDocument doc = new XmlDocument();
				doc.Load(dataFilePath);

				// Countries
				Phase = "decoding countries";
				XmlNode node = doc.ChildNodes[0].ChildNodes[0];
				foreach (XmlNode country in node)
					Countries.Add(new TPlayerCountry(country.Attributes["id"].Value, country.Attributes["name"].Value));

				// Clubs
				Phase = "decoding clubs";
				node = node.NextSibling;
				foreach (XmlNode club in node)
					Clubs.Add(new TPlayerClub(club.Attributes["id"].Value, club.Attributes["name"].Value, GetCountryByID(club.Attributes["countryID"].Value)));

				// Players
				Phase = "decoding players";
				node = node.NextSibling;
				foreach (XmlNode subNode in node)
				{
					TPlayerCountry country = GetCountryByID(subNode.Attributes["countryID"].Value);
					Phase = "decoding players: country " + country.ID;
					country.CoachName = subNode.Attributes["coachName"].Value;
					country.CoachNationality = GetCountryByID(subNode.Attributes["coachNationality"].Value);
					foreach (XmlNode px in subNode)
					{
						TPlayer p = new TPlayer();
						p.ID = px.Attributes["id"].Value;
						p.Position = px.Attributes["pos"].Value;
						p.Number = px.Attributes["no"].Value;
						p.Name = px.Attributes["name"].Value;
						p.BirthDate = DecodeBirthDate(px.Attributes["born"].Value);
						p.Caps = Int32.Parse(px.Attributes["caps"].Value);
						p.Club = GetClubByID(px.Attributes["clubID"].Value);
						p.Country = country;
						country.Players.Add(p);
						GetClubByID(px.Attributes["clubID"].Value).Players.Add(p);
					}
				}

				Phase = "done?";
			}
			catch (Exception E)
			{
				MessageBox.Show(E.ToString() + "\n\nPhase: " + Phase, "TPlayerDatabase.ReadFromFile() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				errors = true;
			}
			return !errors;
		}

		//
		public bool VerifyAndConnectData()
		{
			bool errors = false;
			string s = "init?";
			try
			{
				s = "Flag checks";
				foreach (TPlayerCountry country in Countries)
				{
					if (!File.Exists(Var.FlagsAllCountriesPath + "\\" + country.ID + ".png"))
						throw new Exception(s + "flag for MusicPlayer country " + country.ID + " does not exist");
					country.Flag = new Bitmap(Var.FlagsAllCountriesPath + "\\" + country.ID + ".png");
				}
			}
			catch (Exception E)
			{
				MessageBox.Show("ERROR: " + E.Message + "!\n\nPhase: " + s, "TPlayerDatabase.VerifyAndConnectData() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				errors = true;
			}
			return !errors;
		}

		//
		public TPlayerCountry GetCountryByID(string ID)
		{
			foreach (TPlayerCountry country in Countries)
				if (country.ID.Equals(ID))
					return country;
			MessageBox.Show("Could not find MusicPlayer country with ID \"" + ID + "\" !", "TPlayerDatabase.GetCountryByID() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		//
		public TPlayerClub GetClubByID(string ID)
		{
			foreach (TPlayerClub club in Clubs)
				if (club.ID.Equals(ID))
					return club;
			MessageBox.Show("Could not find MusicPlayer club with ID \"" + ID + "\" !", "TPlayerDatabase.GetClubByID() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		//
		public TPlayer GetPlayerByCountryAndID(string IDs)
		{
			string countryID = IDs.Substring(0, IDs.IndexOf(':')), ID = IDs.Substring(IDs.IndexOf(':') + 1);
			TPlayerCountry country = GetCountryByID(countryID);
			foreach (TPlayer player in country.Players)
				if (player.ID.Equals(ID))
					return player;
			MessageBox.Show("Could not find MusicPlayer with ID \"" + ID + "\" in country \"" + countryID + "\" !", "TPlayerDatabase.GetClubByID() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		//
		public TPlayer GetPlayerByClubAndID(string IDs)
		{
			string clubID = IDs.Substring(0, IDs.IndexOf(':')), ID = IDs.Substring(IDs.IndexOf(':') + 1);
			TPlayerClub club = GetClubByID(clubID);
			foreach (TPlayer player in club.Players)
				if (player.ID.Equals(ID))
					return player;
			MessageBox.Show("Could not find MusicPlayer with ID \"" + ID + "\" in club \"" + clubID + "\" !", "TPlayerDatabase.GetClubByID() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return null;
		}

		//
		private static int PosIndex(string pos)
		{
			if (pos.Equals("GK"))
				return 1;
			if (pos.Equals("DF"))
				return 2;
			if (pos.Equals("MF"))
				return 3;
			if (pos.Equals("FW"))
				return 4;
			return 0;
		}

		//
		public static void SortPlayers(List<TPlayer> list, int criteria)
		{
			if (list.Count < 2)
				return;
			for (int i = 0; i < list.Count - 1; i++)
				for (int j = i + 1; j < list.Count; j++)
				{
					TPlayer p1 = list[i], p2 = list[j];
					bool shouldSwitch = false;
					switch (criteria)
					{
						case 1:
							{ shouldSwitch = Int32.Parse(p1.Number) > Int32.Parse(p2.Number); break; }
						case 2:
							{ shouldSwitch = p1.Name.CompareTo(p2.Name) > 0; break; }
						case 3:
							{ shouldSwitch = ((PosIndex(p1.Position) > PosIndex(p2.Position)) || (PosIndex(p1.Position) == PosIndex(p2.Position) && p1.Caps < p2.Caps)); break; }
						case 4:
						case 5:
							{ shouldSwitch = p1.BirthDate.CompareTo(p2.BirthDate) > 0; break; }
						case 6:
							{ shouldSwitch = p1.Caps < p2.Caps; break; }
						case 7:
							{ shouldSwitch = ((p1.Club.Country.Name.CompareTo(p2.Club.Country.Name) > 0) || (p1.Club.Country.Name.CompareTo(p2.Club.Country.Name) == 0 && p1.Club.Name.CompareTo(p2.Club.Name) > 0)); break; }
					}

					if (shouldSwitch)
					{
						TPlayer aux = list[i];
						list[i] = list[j];
						list[j] = aux;
					}
				}
		}

		//
		public DateTime DecodeBirthDate(string s)
		{
			int d = defaultDateTime.Day, m = defaultDateTime.Month, y = defaultDateTime.Year;
			try
			{
				d = Int32.Parse(s.Substring(0, 2));
				m = Int32.Parse(s.Substring(3, 2));
				y = Int32.Parse(s.Substring(6, 4));
			}
			catch (Exception E)
			{ MessageBox.Show("Failed to decode birth date \"" + s + "\" !\n\n" + E.ToString(), "TPlayerDatabase.DecodeBirthDate() ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
			return new DateTime(y, m, d);
		}

		//
		public static int GetPlayerAgeForWorldCup(DateTime birthdate)
		{
			DateTime today = new DateTime(2014, 6, 12);
			int age = today.Year - birthdate.Year;
			if (birthdate > today.AddYears(-age))
				age--;
			return age;
		}
	}
}
