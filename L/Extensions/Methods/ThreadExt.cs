using System;
using System.Collections.Generic;
using System.Threading;
using LCore.Tools;

namespace LCore.Extensions
    {
    public static class ThreadExt
        {
        /* TODO: L: Thread: Refactor to 16 All Below */
        /* TODO: L: Thread: Comment All Below */
        #region Extensions
        // Performs an action or function asyncronously. If a function is used, a callback can be supplied to retrieve the value. If a time limit is supplied, the thread will be interrupted if it does not complete within the time period.
        #region Async
        public static Action Async(this Action In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return () =>
            {
                Thread ActionThread = new Thread(() => { In(); }) { Priority = Priority };
                ActionThread.Start();
                if (TimeLimit > 0)
                    {
                    Thread WatcherThread = new Thread(() =>
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
        public static Action<T> Async<T>(this Action<T> In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
// TODO: L: Thread: Logical operation within a return
            return o => { In.Supply(o).Async(TimeLimit, Priority)(); };
            }


        public static Action Async<U>(this Func<U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            Action SafeCallback = Callback.Surround(In).Catch<ThreadInterruptedException>();
            return SafeCallback.Async(TimeLimit);
            }
        public static Action<T1> Async<T1, U>(this Func<T1, U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            // TODO: L: Thread: Logical operation within a return
            return o => { In.Supply(o).Async(Callback, TimeLimit, Priority)(); };
            }
        #endregion
        // Performs an action, reporting back the amount of time it took to complete
        #region Profile
        public static TimeSpan Profile(this Action In, uint Repeat = Logic.DefaultProfileRepeat)
            {
            return Logic.L_ProfileActionRepeat(In, Repeat);
            }
        public static TimeSpan[] Profile(this Action In, uint Repeat = Logic.DefaultProfileRepeat, params Action[] Acts)
            {
            Action[] AllActs = Logic.Def.ArrayExt.Array(In)().Add(Acts);
            return AllActs.Convert(Logic.L_ProfileActionRepeat.Supply2(Repeat));
            }
        public static MethodProfileData Profile<U>(this Func<U> In, uint Repeat = Logic.DefaultProfileRepeat)
            {
            MethodProfileData Out = new MethodProfileData();
            DateTime Start = DateTime.Now;
            Out.Data = In.Collect(Repeat)();
            DateTime End = DateTime.Now;
            Out.Times.Add(End - Start);
            return Out;
            }
        public static MethodProfileData[] Profile<U>(this Func<U> In, uint Repeat = Logic.DefaultProfileRepeat, params Func<U>[] Acts)
            {
            Func<U>[] AllActs = Logic.Def.ArrayExt.Array(In)().Add(Acts);
            return AllActs.Convert(o => o.Profile(Repeat));
            }
        #endregion
        // Surrounds the method with logic that sends function execution times to the MethodProfile Cache
        #region Profile - Methods
        public static Action Profile(this Action In, string ProfileName)
            {
            return Logic.L_ProfileAction(In, ProfileName);
            }
        public static Action<T1> Profile<T1>(this Action<T1> In, string ProfileName)
            {
            return o => { In.Supply(o).Profile(ProfileName)(); };
            }
        public static Func<U> Profile<U>(this Func<U> In, string ProfileName)
            {
            return () =>
                {
                    if (!Logic.MethodProfile_Cache.ContainsKey(ProfileName))
                        Logic.MethodProfile_Cache.Add(ProfileName, new MethodProfileData());
                    MethodProfileData Out = In.Profile();
                    Logic.MethodProfile_Cache[ProfileName].Times.AddRange(Out.Times);
                    return (U)Out.Data;
                };
            }
        public static Func<T1, U> Profile<T1, U>(this Func<T1, U> In, string ProfileName)
            {
            return o => In.Supply(o).Profile(ProfileName)();
            }
        #endregion
        #endregion
        }
    public partial class Logic
        {
        /* TODO: L: Thread: Comment All Below */
        public const uint ParameterLimit = 4;
        public const uint DefaultProfileRepeat = 1;

        public static readonly Dictionary<string, MethodProfileData> MethodProfile_Cache = new Dictionary<string, MethodProfileData>();


        #region Profile
        public static Func<Action, uint, TimeSpan> L_ProfileActionRepeat = (In, Repeat) =>
        {
            DateTime Start = DateTime.Now;
            In.Repeat(Repeat)();
            DateTime End = DateTime.Now;
            return End - Start;
        };
        public static Func<Action, string, Action> L_ProfileAction = (In, ProfileName) =>
            {
                return () =>
                {
                    if (!MethodProfile_Cache.ContainsKey(ProfileName))
                        MethodProfile_Cache.Add(ProfileName, new MethodProfileData());
                    MethodProfile_Cache[ProfileName].Times.Add(In.Profile());
                };
            };
        public static Func<Action, TimeSpan> L_ProfileActionDefault = L_ProfileActionRepeat.Supply2(DefaultProfileRepeat);
        #endregion
        }
    }