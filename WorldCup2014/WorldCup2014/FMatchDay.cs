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
	public partial class FMatchDay : Form
	{
		private static List<string> MatchDays = new List<string>();
		private static List<TPictureBox> MatchDayButtons = new List<TPictureBox>();
		public static string CurrentMatchDay = "Jun 12";
		private static List<TPictureBox> Matches = new List<TPictureBox>();

		public FMatchDay()
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
			for (int i = 0; i < 5; i++)
			{
				TPictureBox pic = new TPictureBox("Matchbox " + (i + 1));
				pic.Parent = MatchesPanel;
				pic.Cursor = Cursors.Hand;
				pic.MouseEnter += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseEnter);
				pic.MouseLeave += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_MouseLeave);
				pic.Click += new EventHandler(((FMain) Application.OpenForms[0]).MatchBox_Click);
				Matches.Add(pic);
			}
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void FMatchDay_Shown(object sender, EventArgs e)
		{
			for (int i = 0, plusY = 8; i < 5; i++)
				Matches[i].SetBounds(0, i * (Var.MatchBoxSize.Height + plusY), Var.MatchBoxSize.Width, Var.MatchBoxSize.Height);
			//
			foreach (TMatch match in Var.DB.Matches)
				if (!MatchDays.Contains(TDatabase.EncodeDate(match.When)))
					MatchDays.Add(TDatabase.EncodeDate(match.When));
			//
			for (int i = 0, lastX = 0, lastY = 0; i < 25; i++)
			{
				TPictureBox pic = new TPictureBox(MatchDays[i]);
				pic.Parent = MatchDayPanel;
				pic.Cursor = Cursors.Hand;
				pic.SetBounds(lastX, lastY, 80, 40);
				pic.MouseEnter += new EventHandler(MatchDayButton_MouseEnter);
				pic.MouseLeave += new EventHandler(MatchDayButton_MouseLeave);
				pic.Click += new EventHandler(MatchDayButton_Click);
				MatchDayButtons.Add(pic);
				lastX += 80;
				if (lastX > 320)
				{
					lastY += 40;
					lastX = 0;
				}
			}
			//
		}

		public void RefreshMatchDayButtons()
		{
			for (int i = 0; i < 25; i++)
				DrawMatchDayButton(MatchDayButtons[i], false);
		}

		public void SelectMatchDay(string S)
		{
			foreach (TPictureBox pic in MatchDayButtons)
			{
				if (pic.Information.Equals(S))
				{
					CurrentMatchDay = S; 
					RefreshMatchDayButtons();

					DateTime dt = TDatabase.DecodeDate(S);
					dateL.Text = dt.ToString("dddd, d MMMM yyyy");

					List<TMatch> matches = Var.DB.GetMatchesByDate(dt);
					matchesL.Text = string.Format("M A T C H E S   ({0})", matches.Count);
					for (int i = 0; i < 5; i++)
					{
						Matches[i].Information = i < matches.Count ? "Match " + matches[i].ID : "NULL";
						((FMain) Application.OpenForms[0]).DrawMatch(Matches[i], false);
					}

					break;
				}
			}
		}

		public void DrawMatchDayButton(TPictureBox pic, bool Selected)
		{
			if (pic.Image != null)
				pic.Image.Dispose();
			Bitmap bmp = new Bitmap(pic.Width, pic.Height);
			Graphics g = Graphics.FromImage(bmp);
			Brush bgBrush = Selected ? new SolidBrush(FMain.SelectedColor) : new SolidBrush(FMain.BackgroundColor);
			Brush textBrush = Selected ? new SolidBrush(Color.WhiteSmoke) : new SolidBrush(Color.LemonChiffon);
			Font font = MatchDayButtonFontL.Font;
			g.FillRectangle(bgBrush, 0, 0, pic.Width, pic.Height);
			g.DrawString(pic.Information, font, textBrush, new Point(pic.Width / 2 - (int) g.MeasureString(pic.Information, font).Width / 2, 8));

			if (pic.Information.Equals(CurrentMatchDay))
				g.FillRectangle(textBrush, 0, pic.Height - 3, pic.Width, pic.Height);

			pic.Image = bmp;
		}

		private void MatchDayButton_MouseEnter(object sender, EventArgs e)
		{
			DrawMatchDayButton((TPictureBox) sender, true);
		}

		private void MatchDayButton_MouseLeave(object sender, EventArgs e)
		{
			DrawMatchDayButton((TPictureBox) sender, false);
		}

		private void MatchDayButton_Click(object sender, EventArgs e)
		{
			SelectMatchDay(((TPictureBox) sender).Information);
			DrawMatchDayButton((TPictureBox) sender, true);
		}

		private void refreshInfoTimer_Tick(object sender, EventArgs e)
		{
			refreshInfoTimer.Enabled = false;
			if (this.Visible && MatchDays.Count > 0)
			{
				RefreshMatchDayButtons();
				SelectMatchDay(CurrentMatchDay);
			}
		}
	}
}
