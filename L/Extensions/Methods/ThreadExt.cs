using System;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using LCore.Interfaces;
using LCore.LUnit;
using LCore.Tools;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions to methods to help with asynchronous actions and timing.
    /// </summary>
    [ExtensionProvider]
    public static class ThreadExt
        {
        #region Extensions +

        #region Async +

        #region Async Priority No Parameters
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        public static Action Async([CanBeNull]this Action In)
            {
            In = In ?? L.A();

            return () =>
            {
                var ActionThread = new Thread(() => { In(); }) { Priority = ThreadPriority.Normal };
                ActionThread.Start();
            };
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        public static Action<T> Async<T>([CanBeNull]this Action<T> In)
            {
            In = In ?? L.A<T>();
            return o => { In.Supply(o).Async()(); };
            }

        #endregion

        #region Async Priority No Limit
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        // ReSharper disable MethodOverloadWithOptionalParameter
        public static Action Async([CanBeNull]this Action In, ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.A();

            return () =>
            {
                var ActionThread = new Thread(() => { In(); }) { Priority = Priority };
                ActionThread.Start();
            };
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T> Async<T>([CanBeNull]this Action<T> In, ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.A<T>();
            return o => { In.Supply(o).Async(Priority)(); };
            }

        #endregion

        #region Async TimeSpan
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action Async([CanBeNull]this Action In, TimeSpan TimeLimit = default(TimeSpan), ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.A();

            return () =>
            {
                var ActionThread = new Thread(() => { In(); }) { Priority = Priority };
                ActionThread.Start();
                double TimeLimitMilliseconds = TimeLimit.TotalMilliseconds;

                if (TimeLimitMilliseconds > 0)
                    {
                    var WatcherThread = new Thread(() =>
                    {
                        int? Wait = (TimeLimitMilliseconds / 10).Round().ConvertTo<int>();
                        while (Wait != null && Wait > 1)
                            {
                            Thread.Sleep((int)Wait);
                            TimeLimitMilliseconds -= (int)Wait;
                            Wait = (int)TimeLimitMilliseconds / 10;
                            if (!ActionThread.IsAlive)
                                return;
                            }
                        if (ActionThread.IsAlive)
                            {
                            ActionThread.Interrupt();
                            ActionThread.Abort();
                            }
                    });
                    WatcherThread.Start();
                    }
            };
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T> Async<T>([CanBeNull]this Action<T> In, TimeSpan TimeLimit = default(TimeSpan), ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.A<T>();
            return o => { In.Supply(o).Async(TimeLimit, Priority)(); };
            }

        #endregion

        #region Async int

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0, 5000)]
        public static Action Async([CanBeNull]this Action In, int TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0, 5000)]
        public static Action<T> Async<T>([CanBeNull]this Action<T> In, int TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        #endregion

        #region Async uint

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        [TestBound(1, 0u, 5000u)]
        public static Action Async([CanBeNull]this Action In, uint TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        [TestBound(1, 0u, 5000u)]
        public static Action<T> Async<T>([CanBeNull]this Action<T> In, uint TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        #endregion

        #region Async long
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0L, 5000L)]
        public static Action Async([CanBeNull]this Action In, long TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0L, 5000L)]
        public static Action<T> Async<T>([CanBeNull]this Action<T> In, long TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        #endregion

        #region Async ulong
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action Async([CanBeNull]this Action In, ulong TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T> Async<T>([CanBeNull]this Action<T> In, ulong TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        #endregion

        #endregion

        #region AsyncResult +

        #region Async Priority No Parameters

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback)
            {
            In = In ?? L.F<U>();
            Callback = Callback ?? L.A<U>();
            var SafeCallback = Callback.Surround(In).Catch<ThreadInterruptedException>();
            return SafeCallback.Async();
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback)
            {
            In = In ?? L.F<T1, U>();
            Callback = Callback ?? L.A<U>();
            return o => { In.Supply(o).AsyncResult(Callback)(); };
            }
        #endregion

        #region Async Priority No Limit

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback, ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.F<U>();
            Callback = Callback ?? L.A<U>();
            var SafeCallback = Callback.Surround(In).Catch<ThreadInterruptedException>();
            return SafeCallback.Async(Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback, ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.F<T1, U>();
            Callback = Callback ?? L.A<U>();
            return o => { In.Supply(o).AsyncResult(Callback, Priority)(); };
            }
        #endregion

        #region Async TimeSpan
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback, TimeSpan TimeLimit = default(TimeSpan), ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.F<U>();
            Callback = Callback ?? L.A<U>();
            var SafeCallback = Callback.Surround(In).Catch<ThreadInterruptedException>();
            return SafeCallback.Async(TimeLimit, Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback, TimeSpan TimeLimit = default(TimeSpan), ThreadPriority Priority = ThreadPriority.Normal)
            {
            In = In ?? L.F<T1, U>();
            Callback = Callback ?? L.A<U>();
            return o => { In.Supply(o).AsyncResult(Callback, TimeLimit, Priority)(); };
            }

        #endregion

        #region Async int
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        [TestBound(1, -1, 5000)]
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback, int TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        [TestBound(1, -1, 5000)]
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback, int TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        #endregion

        #region Async uint
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0u, 5000u)]
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback, uint TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0u, 5000u)]
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback, uint TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        #endregion

        #region Async long
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0L, 5000L)]
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback, long TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>

        [TestBound(1, 0L, 5000L)]
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback, long TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        #endregion

        #region Async ulong
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [TestBound(1, 0uL, 5000uL)]
        public static Action AsyncResult<U>([CanBeNull]this Func<U> In, [CanBeNull]Action<U> Callback, ulong TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>

        [TestBound(1, 0uL, 5000uL)]
        public static Action<T1> AsyncResult<T1, U>([CanBeNull]this Func<T1, U> In, [CanBeNull]Action<U> Callback, ulong TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        // ReSharper restore MethodOverloadWithOptionalParameter
        #endregion

        #endregion

        #region CountExecutions

        /// <summary>
        /// Counts how many times <paramref name="In"/> can be performed in the given number of <paramref name="Milliseconds"/>
        /// </summary>
        [Tested]
        [TestBound(1, 0u, 100u)]
        public static uint CountExecutions([CanBeNull]this Action In, uint Milliseconds)
            {
            if (In == null)
                In = () => { };

            var Start = DateTime.Now;
            double Elapsed = 0;

            uint Count = 0;
            while (Elapsed < Milliseconds)
                {
                In();
                Count++;

                Elapsed = (DateTime.Now.Ticks - Start.Ticks) * L.Date.TicksToMilliseconds;
                }

            return Count;
            }

        #endregion

        #region Profile
        /// <summary>
        /// Performs an action, reporting back the amount of time it took to complete
        /// </summary>
        [Tested]
        [TestBound(1, 0, 100)]
        public static TimeSpan Profile([CanBeNull]this Action In, uint Repeat = L.Thread.DefaultProfileRepeat)
            {
            return L.Thread.ProfileActionRepeat(In, Repeat);
            }
        /// <summary>
        /// Performs a function, reporting back the amount of time it took to complete
        /// </summary>
        [Tested]
        [TestBound(1, 0u, 100u)]
        public static MethodProfileData<U> Profile<U>([CanBeNull]this Func<U> In, uint Repeat = L.Thread.DefaultProfileRepeat)
            {
            var Out = new MethodProfileData<U>();

            if (In == null)
                return Out;

            var OutList = new List<U>();
            Out.Data = OutList;

            L.A(() =>
                {
                    var Start = DateTime.Now;
                    OutList.Add(In());
                    var End = DateTime.Now;
                    Out.Times.Add(new TimeSpan(End.Ticks - Start.Ticks));
                }).Repeat(Repeat)();

            return Out;
            }
        #endregion

        #region Profile - Methods
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Action Profile([CanBeNull]this Action In, string ProfileName)
            {
            return L.Thread.ProfileAction(In, ProfileName);
            }
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Action<T1> Profile<T1>([CanBeNull]this Action<T1> In, string ProfileName)
            {
            return o => { In.Supply(o).Profile(ProfileName)(); };
            }
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Func<U> Profile<U>([CanBeNull]this Func<U> In, string ProfileName)
            {
            return () =>
                {
                    L.Thread.MethodProfileCache.SafeAdd(ProfileName, new MethodProfileData());

                    MethodProfileData<U> Out = In.Profile();

                    var Cache = L.Thread.MethodProfileCache[ProfileName];

                    Cache.Times.AddRange(Out.Times);

                    List<object> TempList = Cache.Data.List();
                    TempList.AddRange(Out.Data.List<object>());
                    Cache.Data = TempList;

                    return Out.Data.First();
                };
            }
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Func<T1, U> Profile<T1, U>([CanBeNull]this Func<T1, U> In, string ProfileName)
            {
            return o => In.Supply(o).Profile(ProfileName)();
            }
        #endregion

        #endregion
        }
    public static partial class L
        {
        /// <summary>
        /// Contains static methods and lambdas pertaining to timing and threading.
        /// </summary>
        public static class Thread
            {
            internal const uint DefaultProfileRepeat = 0;

            /// <summary>
            /// Access profile data from methods passed through Profile.
            /// </summary>
            public static readonly Dictionary<string, MethodProfileData> MethodProfileCache = new Dictionary<string, MethodProfileData>();

            #region Profile
            internal static readonly Func<Action, uint, TimeSpan> ProfileActionRepeat = (In, Repeat) =>
                {
                    if (In == null)
                        return new TimeSpan(0);

                    var Start = DateTime.Now;
                    In.Repeat(Repeat)();
                    var End = DateTime.Now;
                    return End - Start;
                };
            internal static readonly Func<Action, string, Action> ProfileAction = (In, ProfileName) =>
                {
                    return () =>
                        {
                            MethodProfileCache.SafeAdd(ProfileName, new MethodProfileData());
                            MethodProfileCache[ProfileName].Times.Add(In.Profile());
                        };
                };
            internal static Func<Action, TimeSpan> ProfileActionDefault = ProfileActionRepeat.Supply2(DefaultProfileRepeat);
            #endregion
            }
        }
    }