using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using LCore.Extensions;

#pragma warning disable 1591

namespace LCore.Threads
    {
    public class FakeThreadPool
        {
        private Task _WatcherTask { get; }
        private bool CancelWatcher { get; set; }

        public const int WaitIncrement = 1;

        public FakeThreadPool(DateTime? StartTime = null)
            {
            this.StartTime = StartTime ?? DateTime.Now;
            this.CurrentTime = this.StartTime;

            this._WatcherTask = Task.Run(this.GetWatcherTask);
            }

        ~FakeThreadPool()
            {
            this.CancelWatcher = true;
            }

        protected DateTime StartTime { get; set; }

        protected DateTime CurrentTime { get; set; }

        public DateTime GetCurrentTime()
            {
            return this.CurrentTime;
            }


        private async Task GetWatcherTask()
            {
            while (!this.CancelWatcher)
                {
                while (this.ThreadsWaiting.Count == 0)
                    await Task.Delay(WaitIncrement);

                var FirstThread = this.ThreadsWaiting.Min(Thread => Thread.ResumeTime);

                var TimeWaited = FirstThread.ResumeTime - this.CurrentTime;

                // Advance the current time
                this.CurrentTime = FirstThread.ResumeTime;

                // Resume the thread
                FirstThread.StopWaiting();

                // Remove the thread from the pool
                this.ThreadsWaiting.Remove(FirstThread);

                this.FinishedThreads++;

                this.ThreadHistory.Add(FirstThread);

                await Task.Delay(WaitIncrement);
                }
            }

        public async Task AwaitAllThreads()
            {
            while (this.FinishedThreads < this.TotalThreads)
                await Task.Delay(WaitIncrement);
            }

        public async Task Delay(int Milliseconds)
            {
            await this.Delay(TimeSpan.FromMilliseconds(Milliseconds));
            }

        public async Task Delay(TimeSpan Duration)
            {
            //await Task.Delay(Duration);
            var Spinner = new ThreadSpinner(this, this.CurrentTime.Add(Duration));

            this.TotalThreads++;

            this.ThreadsWaiting.Add(Spinner);

            await Spinner.Wait();
            }

        public int TotalThreads { get; protected set; }
        public int FinishedThreads { get; protected set; }


        public List<ThreadSpinner> ThreadsWaiting { get; } = new List<ThreadSpinner>();

        public List<ThreadSpinner> ThreadHistory { get; } = new List<ThreadSpinner>();
        }

    public class ThreadSpinner
        {
        protected bool ResumeThread { get; set; }

        public DateTime ResumeTime { get; }
        public DateTime StartTime { get; protected set; }

        public TimeSpan DurationWaited => this.ResumeTime - this.StartTime;

        public ThreadSpinner(FakeThreadPool Pool, DateTime ResumeTime)
            {
            this.StartTime = Pool.GetCurrentTime();
            this.ResumeTime = ResumeTime;
            }

        [DebuggerStepThrough]
        public async Task Wait()
            {
            while (!this.ResumeThread)
                await Task.Delay(FakeThreadPool.WaitIncrement);
            }

        public void StopWaiting()
            {
            this.ResumeThread = true;
            }
        }
    }