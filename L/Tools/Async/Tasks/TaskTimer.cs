using System;
using System.Diagnostics.CodeAnalysis;
using LCore.Extensions;
using System.Timers;

#pragma warning disable 1591

namespace LCore.Tasks
    {
    [ExcludeFromCodeCoverage]
    internal class TaskTimer
        {
        public TaskTimer(Task Task)
            {
            this.TimerTask = Task;

            this.Timer_Reset();
            }

        public static TimeSpan DefaultWait { get; } = new TimeSpan(hours: 0, minutes: 0, seconds: 10);

        private Timer _RunTaskTimer;
        public Task TimerTask { get; }

        private void Timer_Reset(object Obj, ElapsedEventArgs Event)
            {
            this.Timer_Reset();
            }

        private void Timer_Elapsed(object Obj, ElapsedEventArgs Event)
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

            double Wait = (int) (WaitTime*L.Date.TicksToMilliseconds/1000)*(double) 1000;

            if (Wait != 0)
                {
                if (this._RunTaskTimer?.Enabled == true)
                    try
                        {
                        this._RunTaskTimer.Stop();
                        }
                    catch {}

                if (Wait > L.Date.MaxTimerInterval)
                    {
                    this._RunTaskTimer = new Timer(L.Date.MaxTimerInterval);

                    this._RunTaskTimer.Elapsed += this.Timer_Reset;
                    this._RunTaskTimer.AutoReset = false;
                    }
                else
                    {
                    this._RunTaskTimer = new Timer(Wait) {AutoReset = false};


                    this._RunTaskTimer.Elapsed += this.Timer_Elapsed;
                    }


                this._RunTaskTimer.Start();
                }
            }
        }
    }