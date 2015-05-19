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
	public partial class FStatistics : Form
	{
		public FStatistics()
		{
			InitializeComponent();
			bgImg.SetBounds(0, 0, this.Width, this.Height);
			bgImg.SendToBack();
			Var.PaintBackgroundImage(bgImg);
			foreach (Control control in this.Controls)
				if (control is Label)
					((Label) control).BackColor = FMain.BackgroundColor;
				else if (control is PictureBox)
					((PictureBox) control).BackColor = FMain.BackgroundColor;
				else if (control is Panel)
					((Panel) control).BackColor = FMain.BackgroundColor;
		}

		private void closeB_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		public void RefreshStatistics()
		{
			// Initialization
			int mRegularTime = 0, mExtraTime = 0, mPenalties = 0, mPlayedTotal = 0, mTotal = 0;

			int[] gScored = new int[5];
			int gScoredTotal = 0;

			// Generate stats
			foreach (TMatch match in Var.DB.Matches)
			{
				mTotal++;

				if (match.Played)
				{
					mPlayedTotal++;

					if (match.Score.FinishedInRegularTime())
						mRegularTime++;
					else if (match.Score.FinishedInExtraTime())
						mExtraTime++;
					else if (match.Score.FinishedAtPenalties())
						mPenalties++;

					for (int i = 0; i < match.Score.Halves.Count; i++)
					{
						THalfScore h = match.Score.Halves[i];
						gScored[i] += h.Goals1 + h.Goals2;
						if (i < 4)
							gScoredTotal += h.Goals1 + h.Goals2;
					}
				}
			}

			// Display
			// Matches
			SetLabelValue(label11, mRegularTime, mPlayedTotal);
			SetLabelValue(label13, mExtraTime, mPlayedTotal);
			SetLabelValue(label15, mPenalties, mPlayedTotal);
			SetLabelValue(matchesPlayedL, mPlayedTotal, mTotal);
			// Goals
			SetLabelValue(label1, gScored[0], gScoredTotal);
			SetLabelValue(label5, gScored[1], gScoredTotal);
			SetLabelValue(label7, gScored[2], gScoredTotal);
			SetLabelValue(label17, gScored[3], gScoredTotal);
			SetLabelValue(label19, gScored[4]);
			SetLabelValue(goalsScoredL, gScoredTotal);
		}

		private void SetLabelValue(Label label, int a, int b)
		{
			double f = b != 0 ? (double) (a * 100) / b : 0;
			string s = ((int) f) == f ? f.ToString("0") : f.ToString("F2");
			label.Text = string.Format("{0} / {1} ({2}%)", a, b, s);
		}

		private void SetLabelValue(Label label, int a)
		{
			label.Text = string.Format("{0}", a);
		}
	}
}
