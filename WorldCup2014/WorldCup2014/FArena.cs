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
	public partial class FArena : Form
	{
		public static List<TPictureBox> ArenaButtons = new List<TPictureBox>();
		public static string CurrentArena = null;
		public static List<TPictureBox> ArenaMatches = new List<TPictureBox>();

		public FArena()
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
			// CREATE AND FORMAT ARENA BUTTONS
			for (int i = 0; i < 12; i++)
			{
				TPictureBox pic = new TPictureBox("Arenabox" + (i + 1));
				pic.Parent = i <= 5 ? panel1 : panel2;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds((i % 6) * (panel1.Width / 6), 0, panel1.Width / 6, panel1.Height);
				pic.MouseEnter += new EventHandler(ArenaButton_MouseEnter);
				pic.MouseLeave += new EventHandler(ArenaButton_MouseLeave);
				pic.Click += new EventHandler(ArenaButton_Click);
				ArenaButtons.Add(pic);
			}
			for (int i = 0; i < 7; i++)
			{
				TPictureBox pic = new TPictureBox("ArenaMatch " + (i + 1));
				pic.Parent = ArenaMatchesPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(0, i * (28 + 8), 230, 28);
				pic.MouseEnter += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseEnter);
				pic.MouseLeave += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseLeave);
				pic.Click += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_Click);
				ArenaMatches.Add(pic);
			}
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void FArena_Shown(object sender, EventArgs e)
		{
			googleImg.Image = Var.DB.GoogleImage;
			wikipediaImg.Image = Var.DB.WikipediaImage;
		}

		public void SelectArena(string City)
		{
			int r = -1;
			for (int i = 0; i < Var.DB.Arenas.Count; i++)
				if (Var.DB.Arenas[i].City.Equals(City))
					r = i;
			if (r != -1)
			{
				ArenaButton_Click(ArenaButtons[r], null);
				DrawArenaButton(ArenaButtons[r], false);
			}
			else
				MessageBox.Show("FArena.SelectArena() ERROR: could not find arena with city \"" + City + "\"");
		}

		public void RefreshArenaButtons()
		{
			for (int i = 0; i < 12; i++)
				DrawArenaButton(ArenaButtons[i], false);
		}

		public void DrawArenaButton(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.Wheat);
			Font font = ArenaButtonFontL.Font;
			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);
			g.DrawString(pic.Information, font, textBrush, new Point(pic.Width / 2 - (int) g.MeasureString(pic.Information, font).Width / 2, 8));

			if (pic.Information.Equals(CurrentArena))
				g.FillRectangle(textBrush, 0, pic.Height - 3, pic.Width, pic.Height);

			pic.Image = bmp;
		}

		private void ArenaButton_MouseEnter(object sender, EventArgs e)
		{
			DrawArenaButton((TPictureBox) sender, true);
		}

		private void ArenaButton_MouseLeave(object sender, EventArgs e)
		{
			DrawArenaButton((TPictureBox) sender, false);
		}

		private void ArenaButton_Click(object sender, EventArgs e)
		{
			CurrentArena = ((TPictureBox) sender).Information;
			RefreshArenaButtons();
			DrawArenaButton((TPictureBox) sender, true);
			//
			TArena arena = Var.DB.GetArenaByCity(CurrentArena);
			arenaL.Text = arena.ArenaName + ", " + arena.City;
			builtL.Text = arena.YearBuilt.ToString() + " / " + arena.Capacity.ToString("00,000");
			arenaImg.Image = arena.ArenaImage;
			cityLocationImg.Image = arena.CityLocationImage;
			TMatchConditions mCond = Var.DB.GetMatchConditionsForArena(arena.City);
			conditionsL.Text = string.Format("{0}° | {1} m/s | {2}%", mCond.Temperature, mCond.WindSpeed, mCond.RelativeHumidity);
			//
			List<TMatch> matches = Var.DB.GetMatchesByArena(arena.City);
			matchesL.Text = string.Format("M A T C H E S   ({0})", matches.Count);
			for (int i = 0; i < 7; i++)
			{
				ArenaMatches[i].Information = i < matches.Count ? "Match " + matches[i].ID : "NULL";
				ArenaMatches[i].Cursor = i < matches.Count ? Cursors.Hand : Cursors.Default;
				((FMain) Application.OpenForms[0]).DrawMatch(ArenaMatches[i], false);
			}
		}

		private void googleImg_Click(object sender, EventArgs e)
		{
			TArena arena = Var.DB.GetArenaByCity(CurrentArena);
			string link = string.Format("https://www.google.ro/search?q={0}%2C+{1}&ie=UTF-8&tbm=isch",
				arena.ArenaName, arena.City);
			System.Diagnostics.Process.Start(link);
		}

		private void wikipediaImg_Click(object sender, EventArgs e)
		{
			TArena arena = Var.DB.GetArenaByCity(CurrentArena);
			string link = string.Format("http://en.wikipedia.org/w/index.php?title=Special:Search&search={0}%2C+{1}",
				arena.ArenaName, arena.City);
			System.Diagnostics.Process.Start(link);
		}
	}
}
