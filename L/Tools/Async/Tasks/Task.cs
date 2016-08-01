using System;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591


namespace LCore.Tasks
    {
    using System.Threading;

    [ExcludeFromCodeCoverage]
    internal abstract class Task
        {
        protected virtual long RunIntervalSeconds => 60 * 60; // Default: Every hour.

        protected virtual bool RunAsync => false;

        protected virtual int ErrorRetries => 0;

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
                this.NextRunChanged?.Invoke(this, EventArgs.Empty);
                }
            }

        protected virtual ThreadPriority AsyncPriority => ThreadPriority.Normal;

        private Thread _TaskThread;
        public Thread TaskThread
            {
            get
                {
                if (!this.RunAsync)
                    return Thread.CurrentThread;
                return this._TaskThread ?? (this._TaskThread = new Thread(this.RunTaskSafe)
                    {
                    Priority = this.AsyncPriority
                    });
                }
            }

        private bool _IsRunning;
        public bool IsRunning => this._IsRunning;

        /// <exception cref="ThreadStateException">The thread has already been started. </exception>
        /// <exception cref="OutOfMemoryException">There is not enough memory available to start this thread. </exception>
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
                    this.TaskStarted(null, null);

                    this.Run();

                    this.TaskFinished(null, null);

                    ErrorTries = 0;
                    }
                catch
                    {
                    ErrorTries--;

                    this.TaskError(null, null);
                    }
                }
            while (ErrorTries >= 0);
            }

        public abstract void Run();

        // ReSharper disable UnusedParameter.Global
        protected virtual void TaskStarted(object Sender, EventArgs Event)
            {
            this._IsRunning = true;
            this.LastRun = DateTime.Now;
            }
        protected virtual void TaskError(object Sender, EventArgs Event)
            {
            this._IsRunning = false;
            }
        protected virtual void TaskFinished(object Sender, EventArgs Event)
            {
            this._IsRunning = false;
            }
        // ReSharper restore UnusedParameter.Global

        public event EventHandler NextRunChanged;
        }
    }