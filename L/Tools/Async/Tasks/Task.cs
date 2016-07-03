using System;
#pragma warning disable 1591


namespace LCore.Tasks
    {
    public abstract class Task
        {
        public virtual long RunIntervalSeconds => 60 * 60; // Default: Every hour.
        public virtual bool RunAsync => false;
        public virtual int ErrorRetries => 0;

        public virtual DateTime NextRun => this.LastRun == DateTime.MinValue ? DateTime.Now.AddSeconds(10) : this.LastRun.AddSeconds(this.RunIntervalSeconds);
        private DateTime _LastRun = DateTime.MinValue;
        public DateTime LastRun
            {
            get
                {
                return this._LastRun;
                }
            set
                {
                this._LastRun = value;
                this.NextRun_Changed?.Invoke(this, EventArgs.Empty);
                }
            }

        public virtual System.Threading.ThreadPriority AsyncPriority => System.Threading.ThreadPriority.Normal;

        private System.Threading.Thread _TaskThread;
        public System.Threading.Thread TaskThread
            {
            get
                {
                if (!this.RunAsync)
                    return System.Threading.Thread.CurrentThread;
                return this._TaskThread ?? (this._TaskThread = new System.Threading.Thread(this.RunTaskSafe)
                    {
                    Priority = this.AsyncPriority
                    });
                }
            }

        private bool _IsRunning;
        public bool IsRunning => this._IsRunning;

        public void RunTask()
            {
            if (this.IsRunning)
                return;

            if (this.RunAsync)
                {
                this.TaskThread.Start();
                }
            else
                {
                this.RunTaskSafe(null);
                }
            }

        private void RunTaskSafe(object o)
            {
            int ErrorTries = this.ErrorRetries;
            do
                {
                try
                    {
                    this.Task_Started(null, null);

                    this.Run();

                    this.Task_Finished(null, null);

                    ErrorTries = 0;
                    }
                catch
                    {
                    ErrorTries--;

                    this.Task_Error(null, null);
                    }
                }
            while (ErrorTries >= 0);
            }

        public abstract void Run();

        protected void Task_Started(object sender, EventArgs e)
            {
            this._IsRunning = true;
            this.LastRun = DateTime.Now;
            }
        protected void Task_Error(object sender, EventArgs e)
            {
            this._IsRunning = false;
            }
        protected void Task_Finished(object sender, EventArgs e)
            {
            this._IsRunning = false;
            }

        public event EventHandler NextRun_Changed;
        }
    }