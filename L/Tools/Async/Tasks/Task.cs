using System;
using System.Collections.Generic;

using System.Text;


namespace LCore.Tasks
	{
	public abstract class Task
		{
		public virtual long RunIntervalSeconds { get { return 60 * 60; } } // Default: Every hour.
		public virtual Boolean RunAsync { get { return false; } }
		public virtual int ErrorRetries { get { return 0; } }

		public virtual DateTime NextRun
			{
			get
				{
				if (LastRun == DateTime.MinValue)
					return DateTime.Now.AddSeconds(10);

				return LastRun.AddSeconds(this.RunIntervalSeconds);
				}
			}
		private DateTime _LastRun = DateTime.MinValue;
		public DateTime LastRun
			{
			get
				{
				return _LastRun;
				}
			set
				{
				_LastRun = value;
				if (this.NextRun_Changed != null)
					NextRun_Changed(this, EventArgs.Empty);
				}
			}

		public virtual System.Threading.ThreadPriority AsyncPriority { get { return System.Threading.ThreadPriority.Normal; } }

		private System.Threading.Thread _TaskThread;
		public System.Threading.Thread TaskThread
			{
			get
				{
				if (!this.RunAsync)
					return System.Threading.Thread.CurrentThread;
				else
					{
					if (_TaskThread == null)
						{
						_TaskThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(this.RunTaskSafe));
						_TaskThread.Priority = this.AsyncPriority;
						}

					return _TaskThread;
					}
				}
			}

		private Boolean _IsRunning = false;
		public Boolean IsRunning
			{
			get
				{
				return _IsRunning;
				}
			}

		public void RunTask()
			{
			if (this.IsRunning)
				return;

			if (RunAsync)
				{
				TaskThread.Start();
				}
			else
				{
				RunTaskSafe(null);
				}
			}

		private void RunTaskSafe(Object o)
			{
			int ErrorTries = this.ErrorRetries;
			do
				{
				try
					{
					Task_Started(null, null);

					Run();

					Task_Finished(null, null);

					ErrorTries = 0;
					}
				catch
					{
					ErrorTries--;

					Task_Error(null, null);
					}
				}
			while (ErrorRetries >= 0);
			}

		public abstract void Run();

		protected void Task_Started(Object sender, EventArgs e)
			{
			_IsRunning = true;
			LastRun = DateTime.Now;
			}
		protected void Task_Error(Object sender, EventArgs e)
			{
			_IsRunning = false;
			}
		protected void Task_Finished(Object sender, EventArgs e)
			{
			_IsRunning = false;
			}

		public event EventHandler NextRun_Changed;
		}
	}