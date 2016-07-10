using System;
using System.Collections.Generic;
using System.Threading;
using LCore.Interfaces;
using LCore.Tests;
using LCore.Tools;

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions to methods to help with asynchronous actions and timing.
    /// </summary>
    [ExtensionProvider]
    public static class ThreadExt
        {
        /* TODO: L: Thread: Refactor to 16 All Below */
        #region Extensions +

        #region Async
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        [Tested]
        public static Action Async(this Action In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return () =>
            {
                var ActionThread = new Thread(() => { In(); }) { Priority = Priority };
                ActionThread.Start();
                if (TimeLimit > 0)
                    {
                    var WatcherThread = new Thread(() =>
                        {
                            int Wait = TimeLimit / 10;
                            while (Wait > 1)
                                {
                                Thread.Sleep(Wait);
                                TimeLimit -= Wait;
                                Wait = TimeLimit / 10;
                                if (!ActionThread.IsAlive)
                                    return;
                                }
                            if (ActionThread.IsAlive)
                                try
                                    {
                                    ActionThread.Interrupt();
                                    ActionThread.Abort();
                                    }
                                catch { }
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
        public static Action<T> Async<T>(this Action<T> In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return o => { In.Supply(o).Async(TimeLimit, Priority)(); };
            }


        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action Async<U>(this Func<U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            var SafeCallback = Callback.Surround(In).Catch<ThreadInterruptedException>();
            return SafeCallback.Async(TimeLimit, Priority);
            }
        /// <summary>
        /// Performs an action or function asynchronously. 
        /// If a function is used, a callback can be supplied to retrieve the value. 
        /// If a time limit is supplied, the thread will be interrupted if it does not 
        /// complete within the time period.
        /// </summary>
        public static Action<T1> Async<T1, U>(this Func<T1, U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return o => { In.Supply(o).Async(Callback, TimeLimit, Priority)(); };
            }
        #endregion

        #region Profile
        /// <summary>
        /// Performs an action, reporting back the amount of time it took to complete
        /// </summary>
        public static TimeSpan Profile(this Action In, uint Repeat = L.Thread.DefaultProfileRepeat)
            {
            return L.Thread.ProfileActionRepeat(In, Repeat);
            }
        /// <summary>
        /// Performs an action, reporting back the amount of time it took to complete
        /// </summary>
        public static TimeSpan[] Profile(this Action In, uint Repeat = L.Thread.DefaultProfileRepeat, params Action[] Acts)
            {
            Action[] AllActs = L.Ary.Array(In)().Add(Acts);
            return AllActs.Convert(L.Thread.ProfileActionRepeat.Supply2(Repeat));
            }
        /// <summary>
        /// Performs a function, reporting back the amount of time it took to complete
        /// </summary>
        public static MethodProfileData Profile<U>(this Func<U> In, uint Repeat = L.Thread.DefaultProfileRepeat)
            {
            var Out = new MethodProfileData();
            var Start = DateTime.Now;
            Out.Data = In.Collect(Repeat)();
            var End = DateTime.Now;
            Out.Times.Add(End - Start);
            return Out;
            }
        /// <summary>
        /// Performs a function, reporting back the amount of time it took to complete
        /// </summary>
        public static MethodProfileData[] Profile<U>(this Func<U> In, uint Repeat = L.Thread.DefaultProfileRepeat, params Func<U>[] Acts)
            {
            Func<U>[] AllActs = L.Ary.Array(In)().Add(Acts);
            return AllActs.Convert(o => o.Profile(Repeat));
            }
        #endregion

        #region Profile - Methods
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.MethodProfileCache
        /// </summary>
        public static Action Profile(this Action In, string ProfileName)
            {
            return L.Thread.ProfileAction(In, ProfileName);
            }
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.MethodProfileCache
        /// </summary>
        public static Action<T1> Profile<T1>(this Action<T1> In, string ProfileName)
            {
            return o => { In.Supply(o).Profile(ProfileName)(); };
            }
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.MethodProfileCache
        /// </summary>
        public static Func<U> Profile<U>(this Func<U> In, string ProfileName)
            {
            return () =>
                {
                    if (!L.Thread.MethodProfileCache.ContainsKey(ProfileName))
                        L.Thread.MethodProfileCache.Add(ProfileName, new MethodProfileData());
                    var Out = In.Profile();
                    L.Thread.MethodProfileCache[ProfileName].Times.AddRange(Out.Times);
                    return (U)Out.Data;
                };
            }
        /// <summary>
        /// Surrounds the method with logic that logs all execution times.
        /// Access the data using: L.MethodProfileCache
        /// </summary>
        public static Func<T1, U> Profile<T1, U>(this Func<T1, U> In, string ProfileName)
            {
            return o => In.Supply(o).Profile(ProfileName)();
            }
        #endregion

        #endregion

        // Does not work yet
        internal static int CountExecutions(this Action In, int Milliseconds)
            {
            var Start = DateTime.Now;
            int Elapsed = 0;

            int Count = 0;
            while (Elapsed < Milliseconds)
                {
                In();
                Count++;

                Elapsed = DateTime.Now.Subtract(Start).Milliseconds.Abs();
                }

            return Count;
            }
        }
    public static partial class L
        {
        /// <summary>
        /// Contains static methods and lambdas pertaining to timing and threading.
        /// </summary>
        public static class Thread
            {
            internal const uint DefaultProfileRepeat = 1;

            /// <summary>
            /// Access profile data from methods passed through Profile.
            /// </summary>
            public static readonly Dictionary<string, MethodProfileData> MethodProfileCache = new Dictionary<string, MethodProfileData>();

            #region Profile
            internal static readonly Func<Action, uint, TimeSpan> ProfileActionRepeat = (In, Repeat) =>
            {
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