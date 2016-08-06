using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static Action Async([CanBeNull] this Action In)
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
        public static Action<T> Async<T>([CanBeNull] this Action<T> In)
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
        public static Action Async([CanBeNull] this Action In, ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action<T> Async<T>([CanBeNull] this Action<T> In, ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action Async([CanBeNull] this Action In, TimeSpan TimeLimit = default(TimeSpan),
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action<T> Async<T>([CanBeNull] this Action<T> In, TimeSpan TimeLimit = default(TimeSpan),
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action Async([CanBeNull] this Action In,
            [TestBound(0, 5000)]int TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T> Async<T>([CanBeNull] this Action<T> In,
            [TestBound(0, 5000)]int TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action Async([CanBeNull] this Action In,
            [TestBound(0u, 5000u)] uint TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action<T> Async<T>([CanBeNull] this Action<T> In,
            [TestBound(0u, 5000u)]uint TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action Async([CanBeNull] this Action In,
            [TestBound(0L, 5000L)]long TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T> Async<T>([CanBeNull] this Action<T> In,
            [TestBound(0L, 5000L)]long TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action Async([CanBeNull] this Action In, ulong TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.Async(TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T> Async<T>([CanBeNull] this Action<T> In, ulong TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback)
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
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback,
            TimeSpan TimeLimit = default(TimeSpan), ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback,
            TimeSpan TimeLimit = default(TimeSpan), ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback,
            [TestBound(-1, 5000)]int TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback,
            [TestBound(-1, 5000)]int TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback,
            [TestBound(0u, 5000u)]uint TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback,
            [TestBound(0u, 5000u)] uint TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback,
            [TestBound(0L, 5000L)]long TimeLimitMilliseconds = 0,
            ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback,
            [TestBound(0L, 5000L)]long TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
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
        public static Action AsyncResult<U>([CanBeNull] this Func<U> In, [CanBeNull] Action<U> Callback,
            [TestBound(0uL, 5000uL)]ulong TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return In.AsyncResult(Callback, TimeSpan.FromMilliseconds(TimeLimitMilliseconds), Priority);
            }

        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> AsyncResult<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] Action<U> Callback,
            [TestBound(0uL, 5000uL)]ulong TimeLimitMilliseconds = 0, ThreadPriority Priority = ThreadPriority.Normal)
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
        public static uint CountExecutions([CanBeNull] this Action In,
            [TestBound(0u, 100u)]uint Milliseconds)
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
        public static TimeSpan Profile([CanBeNull] this Action In,
        [TestBound(0, 100)]uint Repeat = L.Thread.DefaultProfileRepeat)
            {
            return L.Thread.ProfileActionRepeat(In, Repeat);
            }

        /// <summary>
        /// Performs a function, reporting back the amount of time it took to complete
        /// </summary>
        [Tested]
        public static MethodProfileData<U> Profile<U>([CanBeNull] this Func<U> In,
        [TestBound(0u, 100u)] uint Repeat = L.Thread.DefaultProfileRepeat)
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
        public static Action Profile([CanBeNull] this Action In, [CanBeNull] string ProfileName)
            {
            return L.Thread.ProfileAction(In, ProfileName);
            }

        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Action<T1> Profile<T1>([CanBeNull] this Action<T1> In, [CanBeNull] string ProfileName)
            {
            return o => { In.Supply(o).Profile(ProfileName)(); };
            }

        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Func<U> Profile<U>([CanBeNull] this Func<U> In, [CanBeNull] string ProfileName)
            {
            MethodProfileData Cache;

            if (L.Thread.MethodProfileData_Has(ProfileName))
                {
                Cache = L.Thread.MethodProfileData_Get(ProfileName);
                }
            else
                {
                Cache = new MethodProfileData();
                L.Thread.MethodProfileData_Add(ProfileName, Cache);
                }

            Debug.Assert(Cache != null, "Cache != null");

            return () =>
                {
                    MethodProfileData<U> Out = In.Profile();

                    var Result = Out.Data.First();

                    Cache.Times.AddRange(Out.Times);

                    List<object> TempList = Cache.Data.List();
                    TempList.Add(Result);
                    Cache.Data = TempList;

                    return Result;
                };
            }

        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.Thread.MethodProfileCache
        /// </summary>
        [Tested]
        public static Func<T1, U> Profile<T1, U>([CanBeNull] this Func<T1, U> In, [CanBeNull] string ProfileName)
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

            #region MethodProfileCache

            private static readonly Dictionary<string, MethodProfileData> _MethodProfileCache =
                new Dictionary<string, MethodProfileData>();

            /// <summary>
            /// Access profile data from methods passed through Profile.
            /// </summary>
            [CanBeNull]
            public static MethodProfileData MethodProfileData_Get([CanBeNull]string Method)
                {
                if (Method != null && _MethodProfileCache.ContainsKey(Method))
                    return _MethodProfileCache[Method];

                return null;
                }

            /// <summary>
            /// Removes a method's profile data from the profile data dictionary.
            /// </summary>
            public static void MethodProfileData_Remove([CanBeNull] string Method)
                {
                _MethodProfileCache.SafeRemove(Method);
                }

            /// <summary>
            /// Adds a method's profile data to the profile data dictionary.
            /// </summary>
            public static void MethodProfileData_Add([CanBeNull] string Method, [CanBeNull] MethodProfileData Profile)
                {
                if (Profile != null)
                    _MethodProfileCache.SafeAdd(Method, Profile);
                }

            /// <summary>
            /// Determines if a method has any profile data tracked.
            /// </summary>
            public static bool MethodProfileData_Has([CanBeNull] string Method)
                {
                return _MethodProfileCache.ContainsKey(Method);
                }


            #endregion

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
                            _MethodProfileCache.SafeAdd(ProfileName, new MethodProfileData());
                            _MethodProfileCache[ProfileName].Times.Add(In.Profile());
                        };
                };

            internal static Func<Action, TimeSpan> ProfileActionDefault = ProfileActionRepeat.Supply2(DefaultProfileRepeat);

            #endregion
            }
        }
    }