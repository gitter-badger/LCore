using System;
using LCore.Extensions;
using System.Timers;


namespace LCore.Tasks
    {
    public class TaskTimer
        {
        public TaskTimer(Task t)
            {
            this.TimerTask = t;

            this.Timer_Reset();
            }

        public static TimeSpan DefaultWait { get; } = new TimeSpan(0, 0, 10);

        private Timer RunTaskTimer;
        public Task TimerTask { get; }

        private void Timer_Reset(object o, ElapsedEventArgs e)
            {
            this.Timer_Reset();
            }
        private void Timer_Elapsed(object o, ElapsedEventArgs e)
            {
            this.TimerTask?.Run();
            }

        public void Timer_Reset()
            {
            if (this.TimerTask == null)
                return;

            long WaitTime = this.TimerTask.NextRun.Ticks - DateTime.Now.Ticks;

            if (WaitTime < 0)
                return;

            double d = (int)(WaitTime * DateExt.TicksToMilliseconds / 1000) * (double)1000;

            if (d != 0)
                {
                if (this.RunTaskTimer?.Enabled == true)
                    try
                        {
                        this.RunTaskTimer.Stop();
                        }
                    catch { }

                if (d > DateExt.MaxTimerInterval)
                    {
                    this.RunTaskTimer = new Timer(DateExt.MaxTimerInterval);

                    this.RunTaskTimer.Elapsed += this.Timer_Reset;
                    this.RunTaskTimer.AutoReset = false;
                    }
                else
                    {
                        this.RunTaskTimer = new Timer(d) {AutoReset = false};


                        this.RunTaskTimer.Elapsed += this.Timer_Elapsed;
                    }


                this.RunTaskTimer.Start();
                }
            }
        }
    }