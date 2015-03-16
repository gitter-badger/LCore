using System;
using System.Collections.Generic;
using LCore;
using System.Text;
using System.Timers;


namespace LCore.Tasks
	{
	public class TaskTimer
		{
		public TaskTimer(Task t)
			{
			this._TimerTask = t;

			this.Timer_Reset();
			}

		private static TimeSpan DefaultWait = new TimeSpan(0, 0, 10);

		private Timer RunTaskTimer = null;
		private Task _TimerTask = null;
		public Task TimerTask
			{
			get
				{
				return _TimerTask;
				}
			}

		private void Timer_Reset(Object o, System.Timers.ElapsedEventArgs e)
			{
			Timer_Reset();
			}
		private void Timer_Elapsed(Object o, System.Timers.ElapsedEventArgs e)
			{
			if (this.TimerTask != null)
				this.TimerTask.Run();
			}

		public void Timer_Reset()
			{
			long WaitTime = -1;

			if (this.TimerTask == null)
				return;

			WaitTime = this.TimerTask.NextRun.Ticks - DateTime.Now.Ticks;

			if (WaitTime < 0)
				return;

			Double d = (double)((int)((WaitTime * DateExt.TicksToMilliseconds) / 1000) * (double)1000);

			if (d != 0)
				{
				if (RunTaskTimer != null && RunTaskTimer.Enabled)
					try { RunTaskTimer.Stop(); }
					catch { }

				if (d > DateExt.MaxTimerInterval)
					{
					RunTaskTimer = new System.Timers.Timer(DateExt.MaxTimerInterval);

					RunTaskTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Reset);
					RunTaskTimer.AutoReset = false;
					}
				else
					{
					RunTaskTimer = new System.Timers.Timer(d);

					RunTaskTimer.AutoReset = false;

					RunTaskTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
					}


				RunTaskTimer.Start();
				}
			}
		}
	}