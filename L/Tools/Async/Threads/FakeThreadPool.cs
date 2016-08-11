using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LCore.Extensions;

#pragma warning disable 1591

namespace LCore.Threads
    {
    public class FakeThreadPool
        {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private Task _WatcherTask { get; }
        private bool CancelWatcher { get; set; }

        public const int WaitIncrement = 10;

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

        protected DateTime StartTime { get; }

        protected DateTime CurrentTime { get; set; }

        public DateTime GetCurrentTime()
            {
            return this.CurrentTime;
            }


        private async Task GetWatcherTask()
            {
            while (!this.CancelWatcher)
                {
                try
                    {
                    while (this.ThreadsWaiting.Count == 0)
                        await Task.Delay(WaitIncrement);

                    ThreadSpinner FirstThread;

                    int? LastResumedTask = int.MinValue;

                    lock (this.ThreadsWaiting)
                        {
                        FirstThread = this.ThreadsWaiting.Min(Thread => Thread.TaskId != LastResumedTask
                            ? Thread.ResumeTime
                            : DateTime.MaxValue) ??
                                      this.ThreadsWaiting.Min(Thread => Thread.ResumeTime);

                        if (FirstThread != null)
                            {
                            LastResumedTask = FirstThread.TaskId;

                            // Advance the current time
                            this.CurrentTime = FirstThread.ResumeTime;

                            // Resume the thread
                            FirstThread.StopWaiting();

                            // Remove the thread from the pool
                            this.ThreadsWaiting.Remove(FirstThread);

                            lock (this.ThreadHistory)
                                {
                                this.ThreadHistory.Add(FirstThread);
                                }
                            }
                        }

                    bool Continue = false;

                    FirstThread?.YieldTask.GetAwaiter().OnCompleted(() => { Continue = true; });

                    int TaskCount = this.ThreadsWaiting.Count;

                    while (!Continue)
                        {
                        await Task.Delay(WaitIncrement);
                        Continue = Continue || this.ThreadsWaiting.Count > TaskCount;
                        }

                    this.FinishedThreads++;

                    await Task.Delay(WaitIncrement);
                    }
                catch (Exception) {}
                }
            }

        public async Task AwaitAllThreadsResumed()
            {
            while (this.FinishedThreads < this.TotalThreads)
                await Task.Delay(WaitIncrement);
            }

        public async Task AwaitThreadAdded()
            {
            while (this.TotalThreads == 0)
                await Task.Delay(WaitIncrement);
            }


        public async Task Delay(int Milliseconds)
            {
            await this.Delay(TimeSpan.FromMilliseconds(Milliseconds));
            }

        public async Task Delay(uint Milliseconds)
            {
            await this.Delay(TimeSpan.FromMilliseconds(Milliseconds));
            }

        public async Task Delay(TimeSpan Duration)
            {
            //await Task.Delay(Duration);
            var Spinner = new ThreadSpinner(this, this.CurrentTime.Add(Duration));

            this.TotalThreads++;

            lock (this.ThreadsWaiting)
                {
                this.ThreadsWaiting.Add(Spinner);
                }

            await Spinner.Wait();
            }

        public uint TotalThreads { get; protected set; }
        public uint FinishedThreads { get; protected set; }


        protected List<ThreadSpinner> ThreadsWaiting { get; } = new List<ThreadSpinner>();

        protected List<ThreadSpinner> ThreadHistory { get; } = new List<ThreadSpinner>();

        public List<ThreadSpinner> GetThreadHistory()
            {
            lock (this.ThreadHistory)
                {
                return this.ThreadHistory.List();
                }
            }

        public List<ThreadSpinner> GetThreadsWaiting()
            {
            lock (this.ThreadsWaiting)
                {
                return this.ThreadsWaiting.List();
                }
            }
        }

    public class ThreadSpinner
        {
        protected bool ResumeThread { get; set; }

        public DateTime ResumeTime { get; }
        public DateTime StartTime { get; }

        public YieldAwaitable YieldTask { get; }

        public int? TaskId { get; }

        public TimeSpan DurationWaited => this.ResumeTime - this.StartTime;

        public ThreadSpinner(FakeThreadPool Pool, DateTime ResumeTime)
            {
            this.YieldTask = Task.Yield();
            this.TaskId = Task.CurrentId;
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