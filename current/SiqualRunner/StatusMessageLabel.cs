using System;
using System.Windows.Forms;

namespace SiqualRunner
{
	public class StatusMessageLabel : ToolStripStatusLabel
	{
		private Timer _timer;
		private int _dotsCounter;

		public StatusMessageLabel()
		{
			_timer = new Timer { Enabled = true, Interval = 300 };
			_timer.Tick += TimerTick;
		}

		public void SetInWork()
		{
			this.Text = "Executing Scripts ";
			_timer.Start();
		}

		public void SetIdle()
		{
			this.Text = "Idle";
			_timer.Stop();
			_dotsCounter = 0;
		}

		void TimerTick(object sender, EventArgs e)
		{
			if (_dotsCounter == 2)
			{
				Text = Text.Replace("...", "");
				_dotsCounter = 0;
			}
			else
			{
				this.Text += ".";
				_dotsCounter++;
			}

		}
	}
}