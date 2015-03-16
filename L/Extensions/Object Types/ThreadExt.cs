using System;
using System.Collections.Generic;
using LCore.ObjectExtensions;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Globalization;
using System.Security.Principal;

namespace LCore
    {
    public partial class Logic
        {
        // Comment
        public const uint DefaultProfileRepeat = 1;

        public static readonly Dictionary<String, MethodProfileData> MethodProfile_Cache = new Dictionary<String, MethodProfileData>();

        #region Base Lambdas
        #region Thread
        public static Func<Thread, Int32> Thread_GetManagedThreadId = (t) => { return t.ManagedThreadId; };
        /* Missing in mono
        public static Func<Thread, ExecutionContext> Thread_GetExecutionContext = (t) => { return t.ExecutionContext; };
         */
        public static Func<Thread, ThreadPriority> Thread_GetPriority = (t) => { return t.Priority; };
        public static Action<Thread, ThreadPriority> Thread_SetPriority = (t, t2) => { t.Priority = t2; };
        public static Func<Thread, Boolean> Thread_GetIsAlive = (t) => { return t.IsAlive; };
        public static Func<Thread, Boolean> Thread_GetIsThreadPoolThread = (t) => { return t.IsThreadPoolThread; };
        public static Func<Thread> Thread_GetCurrentThread = () => { return Thread.CurrentThread; };
        public static Func<Thread, Boolean> Thread_GetIsBackground = (t) => { return t.IsBackground; };
        public static Action<Thread, Boolean> Thread_SetIsBackground = (t, b) => { t.IsBackground = b; };
        public static Func<Thread, ThreadState> Thread_GetThreadState = (t) => { return t.ThreadState; };
        public static Func<Thread, ApartmentState> Thread_GetApartmentState = (t) => { return t.ApartmentState; };
        public static Action<Thread, ApartmentState> Thread_SetApartmentState = (t, a) => { t.ApartmentState = a; };
        public static Func<Thread, CultureInfo> Thread_GetCurrentUICulture = (t) => { return t.CurrentUICulture; };
        public static Action<Thread, CultureInfo> Thread_SetCurrentUICulture = (t, c) => { t.CurrentUICulture = c; };
        public static Func<Thread, CultureInfo> Thread_GetCurrentCulture = (t) => { return t.CurrentCulture; };
        public static Action<Thread, CultureInfo> Thread_SetCurrentCulture = (t, c) => { t.CurrentCulture = c; };
        public static Func<Context> Thread_GetCurrentContext = () => { return Thread.CurrentContext; };
        public static Func<IPrincipal> Thread_GetCurrentPrincipal = () => { return Thread.CurrentPrincipal; };
        public static Action<IPrincipal> Thread_SetCurrentPrincipal = (i) => { Thread.CurrentPrincipal = i; };
        public static Func<Thread, String> Thread_GetName = (t) => { return t.Name; };
        public static Action<Thread, String> Thread_SetName = (t, s) => { t.Name = s; };
        public static Func<Thread, Int32> Thread_GetHashCode = (t) => { return t.GetHashCode(); };
        public static Action<Thread> Thread_Start = (t) => { t.Start(); };
        public static Action<Thread, Object> Thread_Start2 = (t, parameter) => { t.Start(parameter); };
        public static Action<Thread, CompressedStack> Thread_SetCompressedStack = (t, stack) => { t.SetCompressedStack(stack); };
        public static Func<Thread, CompressedStack> Thread_GetCompressedStack = (t) => { return t.GetCompressedStack(); };
        public static Action<Thread, Object> Thread_Abort = (t, stateInfo) => { t.Abort(stateInfo); };
        public static Action<Thread> Thread_Abort2 = (t) => { t.Abort(); };
        public static Action Thread_ResetAbort = () => { Thread.ResetAbort(); };
        public static Action<Thread> Thread_Suspend = (t) => { t.Suspend(); };
        public static Action<Thread> Thread_Resume = (t) => { t.Resume(); };
        public static Action<Thread> Thread_Interrupt = (t) => { t.Interrupt(); };
        public static Action<Thread> Thread_Join = (t) => { t.Join(); };
        public static Func<Thread, Int32, Boolean> Thread_Join2 = (t, millisecondsTimeout) => { return t.Join(millisecondsTimeout); };
        public static Func<Thread, TimeSpan, Boolean> Thread_Join3 = (t, timeout) => { return t.Join(timeout); };
        public static Action<Int32> Thread_Sleep = (millisecondsTimeout) => { Thread.Sleep(millisecondsTimeout); };
        public static Action<TimeSpan> Thread_Sleep2 = (timeout) => { Thread.Sleep(timeout); };
        public static Action<Int32> Thread_SpinWait = (iterations) => { Thread.SpinWait(iterations); };
        public static Func<Boolean> Thread_Yield = () => { return Thread.Yield(); };
        /* Missing in Mono
        public static Action<Thread> Thread_DisableComObjectEagerCleanup = (t) => { t.DisableComObjectEagerCleanup(); };
        */
        public static Func<Thread, ApartmentState> Thread_GetApartmentState2 = (t) => { return t.GetApartmentState(); };
        public static Func<Thread, ApartmentState, Boolean> Thread_TrySetApartmentState = (t, state) => { return t.TrySetApartmentState(state); };
        public static Action<Thread, ApartmentState> Thread_SetApartmentState2 = (t, state) => { t.SetApartmentState(state); };
        public static Func<LocalDataStoreSlot> Thread_AllocateDataSlot = () => { return Thread.AllocateDataSlot(); };
        public static Func<String, LocalDataStoreSlot> Thread_AllocateNamedDataSlot = (name) => { return Thread.AllocateNamedDataSlot(name); };
        public static Func<String, LocalDataStoreSlot> Thread_GetNamedDataSlot = (name) => { return Thread.GetNamedDataSlot(name); };
        public static Action<String> Thread_FreeNamedDataSlot = (name) => { Thread.FreeNamedDataSlot(name); };
        public static Func<LocalDataStoreSlot, Object> Thread_GetData = (slot) => { return Thread.GetData(slot); };
        public static Action<LocalDataStoreSlot, Object> Thread_SetData = (slot, data) => { Thread.SetData(slot, data); };
        public static Func<AppDomain> Thread_GetDomain = () => { return Thread.GetDomain(); };
        public static Func<Int32> Thread_GetDomainID = () => { return Thread.GetDomainID(); };
        public static Action Thread_BeginCriticalRegion = () => { Thread.BeginCriticalRegion(); };
        public static Action Thread_EndCriticalRegion = () => { Thread.EndCriticalRegion(); };
        public static Action Thread_BeginThreadAffinity = () => { Thread.BeginThreadAffinity(); };
        public static Action Thread_EndThreadAffinity = () => { Thread.EndThreadAffinity(); };
        /* No Ref or Out Types 
        public static Func<Byte&, Byte> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<Int16&, Int16> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<Int32&, Int32> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<Int64&, Int64> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<SByte&, SByte> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<UInt16&, UInt16> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<UInt32&, UInt32> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<IntPtr&, IntPtr> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<UIntPtr&, UIntPtr> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<UInt64&, UInt64> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<Single&, Single> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<Double&, Double> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Func<Object&, Object> Thread_VolatileRead = (address) => { return Thread.VolatileRead(address); };
        */
        /* No Ref or Out Types 
        public static Action<Byte&, Byte> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<Int16&, Int16> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<Int32&, Int32> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<Int64&, Int64> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<SByte&, SByte> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<UInt16&, UInt16> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<UInt32&, UInt32> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<IntPtr&, IntPtr> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<UIntPtr&, UIntPtr> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<UInt64&, UInt64> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<Single&, Single> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<Double&, Double> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        /* No Ref or Out Types 
        public static Action<Object&, Object> Thread_VolatileWrite = (address, value) => {Thread.VolatileWrite(address, value); };
        */
        public static Action Thread_MemoryBarrier = () => { Thread.MemoryBarrier(); };
        /* Method found on base type 
        public static Func<Object, String> Object_ToString = (o) => { return o.ToString(); };
        */
        /* Method found on base type 
        public static Func<Object, Object, Boolean> Object_Equals = (o, obj) => { return o.Equals(obj); };
        */
        /* Method found on base type 
        public static Func<Object, Type> Object_GetType = (o) => { return o.GetType(); };
        */
        public static Func<ThreadStart, Thread> Thread_New = (start) => { return new Thread(start); };
        public static Func<ThreadStart, Int32, Thread> Thread_New2 = (start, maxStackSize) => { return new Thread(start, maxStackSize); };
        public static Func<ParameterizedThreadStart, Thread> Thread_New3 = (start) => { return new Thread(start); };
        public static Func<ParameterizedThreadStart, Int32, Thread> Thread_New4 = (start, maxStackSize) => { return new Thread(start, maxStackSize); };
        #endregion
        #endregion

        #region Profile
        public static Func<Action, uint, TimeSpan> L_ProfileActionRepeat = (In, Repeat) =>
            {
                DateTime Start = DateTime.Now;
                In.Repeat(Repeat)();
                DateTime End = DateTime.Now;
                return End - Start;
            };
        public static Func<Action, String, Action> L_ProfileAction = (In, ProfileName) =>
            {
                return () =>
                {
                    if (!L.MethodProfile_Cache.ContainsKey(ProfileName))
                        L.MethodProfile_Cache.Add(ProfileName, new MethodProfileData());
                    L.MethodProfile_Cache[ProfileName].Times.Add(In.Profile());
                };
            };
        public static Func<Action, TimeSpan> L_ProfileActionDefault = L_ProfileActionRepeat.Supply2(DefaultProfileRepeat);
        #endregion
        }
    public static class ThreadExt
        {
        // Comment

        // Performs an action or function asyncronously. If a function is used, a callback can be supplied to retrieve the value. If a time limit is supplied, the thread will be interrupted if it does not complete within the time period.
        #region Async
        public static Action Async(this Action In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            return () =>
            {
                Thread ActionThread = new Thread(new ThreadStart(() => { In(); }));
                ActionThread.Priority = Priority;
                ActionThread.Start();
                if (TimeLimit > 0)
                    {
                    Thread WatcherThread = new Thread(new ThreadStart(() =>
                    {
                        int Wait = (TimeLimit / 10);
                        while (Wait > 1)
                            {
                            Thread.Sleep(Wait);
                            TimeLimit -= Wait;
                            Wait = (TimeLimit / 10);
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
                    }));
                    WatcherThread.Start();
                    }
            };
            }
        public static Action<T> Async<T>(this Action<T> In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o) => { In.Supply(o).Async(TimeLimit, Priority)(); };
            }
        public static Action<T1, T2> Async<T1, T2>(this Action<T1, T2> In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o1, o2) => { In.Supply(o1, o2).Async(TimeLimit, Priority)(); };
            }
        public static Action<T1, T2, T3> Async<T1, T2, T3>(this Action<T1, T2, T3> In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o1, o2, o3) => { In.Supply(o1, o2, o3).Async(TimeLimit, Priority)(); };
            }
        public static Action<T1, T2, T3, T4> Async<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o1, o2, o3, o4) => { In.Supply(o1, o2, o3, o4).Async(TimeLimit, Priority)(); };
            }
        public static Action Async<U>(this Func<U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
            Action SafeCallback = Callback.Surround(In).Catch<ThreadInterruptedException>();
            return SafeCallback.Async(TimeLimit);
            }
        public static Action<T1> Async<T1, U>(this Func<T1, U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o) => { In.Supply(o).Async(Callback, TimeLimit, Priority)(); };
            }
        public static Action<T1, T2> Async<T1, T2, U>(this Func<T1, T2, U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o1, o2) => { In.Supply(o1, o2).Async(Callback, TimeLimit, Priority)(); };
            }
        public static Action<T1, T2, T3> Async<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o1, o2, o3) => { In.Supply(o1, o2, o3).Async(Callback, TimeLimit, Priority)(); };
            }
        public static Action<T1, T2, T3, T4> Async<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Action<U> Callback, int TimeLimit = -1, ThreadPriority Priority = ThreadPriority.Normal)
            {
#warning Logical operation within a return
            return (o1, o2, o3, o4) => { In.Supply(o1, o2, o3, o4).Async(Callback, TimeLimit, Priority)(); };
            }
        #endregion
        // Performs an action, reporting back the amount of time it took to complete
        #region Profile
        public static TimeSpan Profile(this Action In, uint Repeat = L.DefaultProfileRepeat)
            {
            return L.L_ProfileActionRepeat(In, Repeat);
            }
        public static TimeSpan[] Profile(this Action In, uint Repeat = L.DefaultProfileRepeat, params Action[] Acts)
            {
            Action[] AllActs = In.Array()().Add(Acts);
            return AllActs.Convert(L.L_ProfileActionRepeat.Supply2(Repeat));
            }
        public static MethodProfileData Profile<U>(this Func<U> In, uint Repeat = L.DefaultProfileRepeat)
            {
            MethodProfileData Out = new MethodProfileData();
            DateTime Start = DateTime.Now;
            Out.Data = In.Collect<U>(Repeat)();
            DateTime End = DateTime.Now;
            Out.Times.Add(End - Start);
            return Out;
            }
        public static MethodProfileData[] Profile<U>(this Func<U> In, uint Repeat = L.DefaultProfileRepeat, params Func<U>[] Acts)
            {
            Func<U>[] AllActs = In.Array()().Add(Acts);
            return AllActs.Convert<Func<U>, MethodProfileData>((o) => { return o.Profile<U>(Repeat); });
            }
        #endregion
        // Surrounds the method with logic that sends function execution times to the MethodProfile Cache
        #region Profile - Methods
        public static Action Profile(this Action In, String ProfileName)
            {
            return L.L_ProfileAction(In, ProfileName);
            }
        public static Action<T1> Profile<T1>(this Action<T1> In, String ProfileName)
            {
            return (o) => { In.Supply(o).Profile(ProfileName)(); };
            }
        public static Action<T1, T2> Profile<T1, T2>(this Action<T1, T2> In, String ProfileName)
            {
            return (o1, o2) => { In.Supply(o1, o2).Profile(ProfileName)(); };
            }
        public static Action<T1, T2, T3> Profile<T1, T2, T3>(this Action<T1, T2, T3> In, String ProfileName)
            {
            return (o1, o2, o3) => { In.Supply(o1, o2, o3).Profile(ProfileName)(); };
            }
        public static Action<T1, T2, T3, T4> Profile<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String ProfileName)
            {
            return (o1, o2, o3, o4) => { In.Supply(o1, o2, o3, o4).Profile(ProfileName)(); };
            }
        public static Func<U> Profile<U>(this Func<U> In, String ProfileName)
            {
            return () =>
                {
                    if (!L.MethodProfile_Cache.ContainsKey(ProfileName))
                        L.MethodProfile_Cache.Add(ProfileName, new MethodProfileData());
                    MethodProfileData Out = In.Profile();
                    L.MethodProfile_Cache[ProfileName].Times.AddRange(Out.Times);
                    return (U)Out.Data;
                };
            }
        public static Func<T1, U> Profile<T1, U>(this Func<T1, U> In, String ProfileName)
            {
            return (o) => { return In.Supply(o).Profile(ProfileName)(); };
            }
        public static Func<T1, T2, U> Profile<T1, T2, U>(this Func<T1, T2, U> In, String ProfileName)
            {
            return (o1, o2) => { return In.Supply(o1, o2).Profile(ProfileName)(); };
            }
        public static Func<T1, T2, T3, U> Profile<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String ProfileName)
            {
            return (o1, o2, o3) => { return In.Supply(o1, o2, o3).Profile(ProfileName)(); };
            }
        public static Func<T1, T2, T3, T4, U> Profile<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String ProfileName)
            {
            return (o1, o2, o3, o4) => { return In.Supply(o1, o2, o3, o4).Profile(ProfileName)(); };
            }
        #endregion

        // Do
        #region MultiThread
        #endregion
        #region MultiThread Results
        #endregion
        }
    public class MethodProfileData
        {
        public List<TimeSpan> Times = new List<TimeSpan>();
        public Object Data;
        public double AverageMS
            {
            get
                {
                double Out = 0;
                Times.Each((t) => { Out += t.Ticks; });
                Out = Out / Times.Count;
                Out = Out * DateExt.TicksToMilliseconds;
                return Out;
                }
            }
        }
    }