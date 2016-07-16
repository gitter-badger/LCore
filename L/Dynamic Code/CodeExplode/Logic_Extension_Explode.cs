
using System;
using System.Collections.Generic;
// ReSharper disable All


namespace LCore.Extensions
    {
    /// <summary>
    /// Logic method explosion extension methods.
    /// </summary>
    public static class Logic_Extension_Explode
        {
        #region Method Extensions
        #region Supply
        #endregion
        #region Merge
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T3, U> Merge<T1, T3, U>(this Func<T1, U> In, Func<T3, U> Merge)
            {
            return L.Logic.L_Merge_F1_F1<T1, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T3, T4, U> Merge<T1, T3, T4, U>(this Func<T1, U> In, Func<T3, T4, U> Merge)
            {
            return L.Logic.L_Merge_F1_F2<T1, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, U> In, Func<T2, T3, T4, U> Merge)
            {
            return L.Logic.L_Merge_F1_F3<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Func<T1, T2, U> In, Func<U> Merge)
            {
            return L.Logic.L_Merge_F2_F<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T4, U> Merge<T1, T2, T4, U>(this Func<T1, T2, U> In, Func<T4, U> Merge)
            {
            return L.Logic.L_Merge_F2_F1<T1, T2, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, Func<T3, T4, U> Merge)
            {
            return L.Logic.L_Merge_F2_F2<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<U> Merge)
            {
            return L.Logic.L_Merge_F3_F<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Func<T4, U> Merge)
            {
            return L.Logic.L_Merge_F3_F1<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<U> Merge)
            {
            return L.Logic.L_Merge_F4_F<T1, T2, T3, T4, U>()(In, Merge);
            }
        #endregion
        #region Supply
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action Supply<T1>(this Action<T1> In, T1 Obj)
            {
            return L.Logic.L_Supply_A<T1>()(In, Obj);
            }
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T2> Supply<T1, T2>(this Action<T1, T2> In, T1 Obj)
            {
            return L.Logic.L_Supply_A<T1, T2>()(In, Obj);
            }
        #endregion
        #region Supply2
        /// <summary>
        /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T1> Supply2<T1, T2>(this Action<T1, T2> In, T2 Obj)
            {
            return L.Logic.L_Supply_A2<T1, T2>()(In, Obj);
            }
        #endregion
        #region Supply
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T2, T3> Supply<T1, T2, T3>(this Action<T1, T2, T3> In, T1 Obj)
            {
            return L.Logic.L_Supply_A<T1, T2, T3>()(In, Obj);
            }
        #endregion
        #region Supply2
        /// <summary>
        /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T1, T3> Supply2<T1, T2, T3>(this Action<T1, T2, T3> In, T2 Obj)
            {
            return L.Logic.L_Supply_A2<T1, T2, T3>()(In, Obj);
            }
        #endregion
        #region Supply3
        /// <summary>
        /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T1, T2> Supply3<T1, T2, T3>(this Action<T1, T2, T3> In, T3 Obj)
            {
            return L.Logic.L_Supply_A3<T1, T2, T3>()(In, Obj);
            }
        #endregion
        #region Supply
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T2, T3, T4> Supply<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T1 Obj)
            {
            return L.Logic.L_Supply_A<T1, T2, T3, T4>()(In, Obj);
            }
        #endregion
        #region Supply2
        /// <summary>
        /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T1, T3, T4> Supply2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T2 Obj)
            {
            return L.Logic.L_Supply_A2<T1, T2, T3, T4>()(In, Obj);
            }
        #endregion
        #region Supply3
        /// <summary>
        /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T1, T2, T4> Supply3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T3 Obj)
            {
            return L.Logic.L_Supply_A3<T1, T2, T3, T4>()(In, Obj);
            }
        #endregion
        #region Supply4
        /// <summary>
        /// Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Action<T1, T2, T3> Supply4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T4 Obj)
            {
            return L.Logic.L_Supply_A4<T1, T2, T3, T4>()(In, Obj);
            }
        #endregion
        #region Supply
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<U> Supply<T1, U>(this Func<T1, U> In, T1 Obj)
            {
            return L.Logic.L_Supply_F<T1, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T2, U> Supply<T1, T2, U>(this Func<T1, T2, U> In, T1 Obj)
            {
            return L.Logic.L_Supply_F<T1, T2, U>()(In, Obj);
            }
        #endregion
        #region Supply2
        /// <summary>
        /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T1, U> Supply2<T1, T2, U>(this Func<T1, T2, U> In, T2 Obj)
            {
            return L.Logic.L_Supply_F2<T1, T2, U>()(In, Obj);
            }
        #endregion
        #region Supply
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T2, T3, U> Supply<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T1 Obj)
            {
            return L.Logic.L_Supply_F<T1, T2, T3, U>()(In, Obj);
            }
        #endregion
        #region Supply2
        /// <summary>
        /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T1, T3, U> Supply2<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T2 Obj)
            {
            return L.Logic.L_Supply_F2<T1, T2, T3, U>()(In, Obj);
            }
        #endregion
        #region Supply3
        /// <summary>
        /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T1, T2, U> Supply3<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T3 Obj)
            {
            return L.Logic.L_Supply_F3<T1, T2, T3, U>()(In, Obj);
            }
        #endregion
        #region Supply
        /// <summary>
        /// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T2, T3, T4, U> Supply<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T1 Obj)
            {
            return L.Logic.L_Supply_F<T1, T2, T3, T4, U>()(In, Obj);
            }
        #endregion
        #region Supply2
        /// <summary>
        /// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T1, T3, T4, U> Supply2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T2 Obj)
            {
            return L.Logic.L_Supply_F2<T1, T2, T3, T4, U>()(In, Obj);
            }
        #endregion
        #region Supply3
        /// <summary>
        /// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T1, T2, T4, U> Supply3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T3 Obj)
            {
            return L.Logic.L_Supply_F3<T1, T2, T3, T4, U>()(In, Obj);
            }
        #endregion
        #region Supply4
        /// <summary>
        /// Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.
        /// </summary>
        public static Func<T1, T2, T3, U> Supply4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T4 Obj)
            {
            return L.Logic.L_Supply_F4<T1, T2, T3, T4, U>()(In, Obj);
            }
        #endregion
        #region Supply
        #endregion
        #region Supply2
        #endregion
        #region Supply
        #endregion
        #region Supply2
        #endregion
        #region Supply3
        #endregion
        #region Supply
        #endregion
        #region Supply2
        #endregion
        #region Supply
        #endregion
        #region Supply2
        #endregion
        #region Supply3
        #endregion
        #region Supply
        #endregion
        #region Then
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Func<T1, T2, U> In, params Action<T1>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Func<T1, T2, U> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A2<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Action<T1, T2>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Action<T1>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A2<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A3<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Action<T1, T2, T3>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Action<T1, T2>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A2<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Action<T1>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A3<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A4<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, U> Then<T1, U>(this Func<T1, U> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F<T1, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Func<T1, T2, U> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Func<T1, T2, U> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F2<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F2<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F3<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<T1, T2, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<T1, T2, T3, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<T1, T2, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F2<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F3<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_F_F4<T1, T2, T3, T4, U>()(In, Acts);
            }
        #endregion
        #region Merge
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<U> Merge<U>(this Action In, Func<U> Merge)
            {
            return L.Logic.L_Merge_A_F<U>()(In, Merge);
            }
        #region Merge
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action<T1, T2, T3, T4, T5, T6> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx6<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1, T2, T3, T4, T5, T6> In, Func<T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7x6<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2, T3, T4, T5, T6> In, Func<T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x6<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3, T4, T5, T6> In, Func<T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx7<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Func<T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x7<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Func<T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Func<T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Action<T1, T2, T3> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx3<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Action<T1, T2, T3> In, Func<T4, U> Merge)
            {
            return LX_Explode.L_Merge_A_F4x3<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Merge<T1, T2, T3, T4, T5, U>(this Action<T1, T2, T3> In, Func<T4, T5, U> Merge)
            {
            return LX_Explode.L_Merge_A_F5x3<T1, T2, T3, T4, T5, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action<T1, T2, T3> In, Func<T4, T5, T6, U> Merge)
            {
            return LX_Explode.L_Merge_A_F6x3<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1, T2, T3> In, Func<T4, T5, T6, T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7x3<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2, T3> In, Func<T4, T5, T6, T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x3<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3> In, Func<T4, T5, T6, T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx4<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Merge<T1, T2, T3, T4, T5, U>(this Action<T1, T2, T3, T4> In, Func<T5, U> Merge)
            {
            return LX_Explode.L_Merge_A_F5x4<T1, T2, T3, T4, T5, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action<T1, T2, T3, T4> In, Func<T5, T6, U> Merge)
            {
            return LX_Explode.L_Merge_A_F6x4<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1, T2, T3, T4> In, Func<T5, T6, T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7x4<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2, T3, T4> In, Func<T5, T6, T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x4<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3, T4> In, Func<T5, T6, T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Merge<T1, T2, T3, T4, T5, U>(this Action<T1, T2, T3, T4, T5> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx5<T1, T2, T3, T4, T5, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action<T1, T2, T3, T4, T5> In, Func<T6, U> Merge)
            {
            return LX_Explode.L_Merge_A_F6x5<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1, T2, T3, T4, T5> In, Func<T6, T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7x5<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2, T3, T4, T5> In, Func<T6, T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x5<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2, T3, T4, T5> In, Func<T6, T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, U> Merge<T1, U>(this Action In, Func<T1, U> Merge)
            {
            return LX_Explode.L_Merge_A_F1<T1, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Action In, Func<T1, T2, U> Merge)
            {
            return LX_Explode.L_Merge_A_F2<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Action In, Func<T1, T2, T3, U> Merge)
            {
            return LX_Explode.L_Merge_A_F3<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Action In, Func<T1, T2, T3, T4, U> Merge)
            {
            return LX_Explode.L_Merge_A_F4<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Merge<T1, T2, T3, T4, T5, U>(this Action In, Func<T1, T2, T3, T4, T5, U> Merge)
            {
            return LX_Explode.L_Merge_A_F5<T1, T2, T3, T4, T5, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, U> Merge)
            {
            return LX_Explode.L_Merge_A_F6<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Merge)
            {
            return LX_Explode.L_Merge_A_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Merge)
            {
            return LX_Explode.L_Merge_A_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Merge)
            {
            return LX_Explode.L_Merge_A_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Merge)
            {
            return LX_Explode.L_Merge_A_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Merge)
            {
            return LX_Explode.L_Merge_A_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Merge)
            {
            return LX_Explode.L_Merge_A_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Action In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Merge)
            {
            return LX_Explode.L_Merge_A_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, U> Merge<T1, U>(this Action<T1> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx1<T1, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Action<T1> In, Func<T2, U> Merge)
            {
            return LX_Explode.L_Merge_A_F2x1<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Action<T1> In, Func<T2, T3, U> Merge)
            {
            return LX_Explode.L_Merge_A_F3x1<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Action<T1> In, Func<T2, T3, T4, U> Merge)
            {
            return LX_Explode.L_Merge_A_F4x1<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Merge<T1, T2, T3, T4, T5, U>(this Action<T1> In, Func<T2, T3, T4, T5, U> Merge)
            {
            return LX_Explode.L_Merge_A_F5x1<T1, T2, T3, T4, T5, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action<T1> In, Func<T2, T3, T4, T5, T6, U> Merge)
            {
            return LX_Explode.L_Merge_A_F6x1<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1> In, Func<T2, T3, T4, T5, T6, T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7x1<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1> In, Func<T2, T3, T4, T5, T6, T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x1<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1> In, Func<T2, T3, T4, T5, T6, T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Action<T1, T2> In, Func<U> Merge)
            {
            return LX_Explode.L_Merge_A_Fx2<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Action<T1, T2> In, Func<T3, U> Merge)
            {
            return LX_Explode.L_Merge_A_F3x2<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Action<T1, T2> In, Func<T3, T4, U> Merge)
            {
            return LX_Explode.L_Merge_A_F4x2<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Merge<T1, T2, T3, T4, T5, U>(this Action<T1, T2> In, Func<T3, T4, T5, U> Merge)
            {
            return LX_Explode.L_Merge_A_F5x2<T1, T2, T3, T4, T5, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Merge<T1, T2, T3, T4, T5, T6, U>(this Action<T1, T2> In, Func<T3, T4, T5, T6, U> Merge)
            {
            return LX_Explode.L_Merge_A_F6x2<T1, T2, T3, T4, T5, T6, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Merge<T1, T2, T3, T4, T5, T6, T7, U>(this Action<T1, T2> In, Func<T3, T4, T5, T6, T7, U> Merge)
            {
            return LX_Explode.L_Merge_A_F7x2<T1, T2, T3, T4, T5, T6, T7, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Action<T1, T2> In, Func<T3, T4, T5, T6, T7, T8, U> Merge)
            {
            return LX_Explode.L_Merge_A_F8x2<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Action<T1, T2> In, Func<T3, T4, T5, T6, T7, T8, T9, U> Merge)
            {
            return LX_Explode.L_Merge_A_F9x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Merge);
            }
        #endregion
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<U> Merge<U>(this Func<U> In, Action Merge)
            {
            return L.Logic.L_Merge_F_A<U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, U> Merge<T1, U>(this Func<U> In, Action<T1> Merge)
            {
            return L.Logic.L_Merge_F_A1<T1, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Func<U> In, Action<T1, T2> Merge)
            {
            return L.Logic.L_Merge_F_A2<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Func<U> In, Action<T1, T2, T3> Merge)
            {
            return L.Logic.L_Merge_F_A3<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<U> In, Action<T1, T2, T3, T4> Merge)
            {
            return L.Logic.L_Merge_F_A4<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, U> Merge<T1, U>(this Func<T1, U> In, Action Merge)
            {
            return L.Logic.L_Merge_F1_A<T1, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Func<T1, U> In, Action<T2> Merge)
            {
            return L.Logic.L_Merge_F1_A1<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Func<T1, U> In, Action<T2, T3> Merge)
            {
            return L.Logic.L_Merge_F1_A2<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, U> In, Action<T2, T3, T4> Merge)
            {
            return L.Logic.L_Merge_F1_A3<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Func<T1, T2, U> In, Action Merge)
            {
            return L.Logic.L_Merge_F2_A<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Func<T1, T2, U> In, Action<T3> Merge)
            {
            return L.Logic.L_Merge_F2_A1<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, Action<T3, T4> Merge)
            {
            return L.Logic.L_Merge_F2_A2<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Action Merge)
            {
            return L.Logic.L_Merge_F3_A<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Action<T4> Merge)
            {
            return L.Logic.L_Merge_F3_A1<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Action Merge)
            {
            return L.Logic.L_Merge_F3_A<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<U> Merge<U>(this Func<U> In, Func<U> Merge)
            {
            return L.Logic.L_Merge_F_F<U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, U> Merge<T1, U>(this Func<U> In, Func<T1, U> Merge)
            {
            return L.Logic.L_Merge_F_F1<T1, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, U> Merge<T1, T2, U>(this Func<U> In, Func<T1, T2, U> Merge)
            {
            return L.Logic.L_Merge_F_F2<T1, T2, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, U> Merge<T1, T2, T3, U>(this Func<U> In, Func<T1, T2, T3, U> Merge)
            {
            return L.Logic.L_Merge_F_F3<T1, T2, T3, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Merge<T1, T2, T3, T4, U>(this Func<U> In, Func<T1, T2, T3, T4, U> Merge)
            {
            return L.Logic.L_Merge_F_F4<T1, T2, T3, T4, U>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<T1, U> Merge<T1, U>(this Func<T1, U> In, Func<U> Merge)
            {
            return L.Logic.L_Merge_F1_F<T1, U>()(In, Merge);
            }
        #endregion
        #region Then
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Action Then(this Action In, params Action[] Acts)
            {
            return L.Logic.Then_A()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Action<T1> Then<T1>(this Action<T1> In, params Action<T1>[] Acts)
            {
            return L.Logic.Then_A<T1>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Action<T1, T2> Then<T1, T2>(this Action<T1, T2> In, params Action<T1, T2>[] Acts)
            {
            return L.Logic.Then_A<T1, T2>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Action<T1, T2, T3> Then<T1, T2, T3>(this Action<T1, T2, T3> In, params Action<T1, T2, T3>[] Acts)
            {
            return L.Logic.Then_A<T1, T2, T3>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Action<T1, T2, T3, T4> Then<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Action<T1, T2, T3, T4>[] Acts)
            {
            return L.Logic.Then_A<T1, T2, T3, T4>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<U> Then<U>(this Action In, params Func<U>[] Acts)
            {
            return L.Logic.Then_A_F<U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, U> Then<T1, U>(this Action<T1> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.Then_A_F<T1, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Action<T1, T2> In, params Func<T1, T2, U>[] Acts)
            {
            return L.Logic.Then_A_F<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Action<T1, T2, T3> In, params Func<T1, T2, T3, U>[] Acts)
            {
            return L.Logic.Then_A_F<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, params Func<T1, T2, T3, T4, U>[] Acts)
            {
            return L.Logic.Then_A_F<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<U> Then<U>(this Func<U> In, params Action[] Acts)
            {
            return L.Logic.Then_F<U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, U> Then<T1, U>(this Func<T1, U> In, params Action<T1>[] Acts)
            {
            return L.Logic.Then_F<T1, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Func<T1, T2, U> In, params Action<T1, T2>[] Acts)
            {
            return L.Logic.Then_F<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Action<T1, T2, T3>[] Acts)
            {
            return L.Logic.Then_F<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Action<T1, T2, T3, T4>[] Acts)
            {
            return L.Logic.Then_F<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<U> Then<U>(this Func<U> In, params Func<U>[] Acts)
            {
            return L.Logic.L_Then_F_F<U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, U> Then<T1, U>(this Func<T1, U> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_Then_F_F<T1, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Func<T1, T2, U> In, params Func<T1, T2, U>[] Acts)
            {
            return L.Logic.L_Then_F_F<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, params Func<T1, T2, T3, U>[] Acts)
            {
            return L.Logic.L_Then_F_F<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Joins multiple actions together, performing them in order.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, params Func<T1, T2, T3, T4, U>[] Acts)
            {
            return L.Logic.L_Then_F_F<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1> Then<T1>(this Action<T1> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_A<T1>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2> Then<T1, T2>(this Action<T1, T2> In, params Action<T1>[] Acts)
            {
            return L.Logic.L_ThenMissing_A<T1, T2>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2> Then<T1, T2>(this Action<T1, T2> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_A2<T1, T2>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3> Then<T1, T2, T3>(this Action<T1, T2, T3> In, params Action<T1, T2>[] Acts)
            {
            return L.Logic.L_ThenMissing_A<T1, T2, T3>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3> Then<T1, T2, T3>(this Action<T1, T2, T3> In, params Action<T1>[] Acts)
            {
            return L.Logic.L_ThenMissing_A2<T1, T2, T3>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3> Then<T1, T2, T3>(this Action<T1, T2, T3> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_A3<T1, T2, T3>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3, T4> Then<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Action<T1, T2, T3>[] Acts)
            {
            return L.Logic.L_ThenMissing_A<T1, T2, T3, T4>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3, T4> Then<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Action<T1, T2>[] Acts)
            {
            return L.Logic.L_ThenMissing_A2<T1, T2, T3, T4>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3, T4> Then<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Action<T1>[] Acts)
            {
            return L.Logic.L_ThenMissing_A3<T1, T2, T3, T4>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Action<T1, T2, T3, T4> Then<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_A4<T1, T2, T3, T4>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, U> Then<T1, U>(this Action<T1> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F<T1, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Action<T1, T2> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Action<T1, T2, T3> In, params Func<T1, T2, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, U> Then<T1, T2, U>(this Action<T1, T2> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F2<T1, T2, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Action<T1, T2, T3> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F3<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, U> Then<T1, T2, T3, U>(this Action<T1, T2, T3> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F2<T1, T2, T3, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, params Func<T1, T2, T3, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, params Func<T1, T2, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F2<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, params Func<T1, U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F3<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Then<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, params Func<U>[] Acts)
            {
            return L.Logic.L_ThenMissing_A_F4<T1, T2, T3, T4, U>()(In, Acts);
            }
        /// <summary>
        /// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
        /// </summary>
        public static Func<T1, U> Then<T1, U>(this Func<T1, U> In, params Action[] Acts)
            {
            return L.Logic.L_ThenMissing_F_A<T1, U>()(In, Acts);
            }
        #endregion
        #region Yield2
        /// <summary>
        /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
        /// </summary>
        public static Func<T1, U, T2, U> Yield2<T1, T2, U>(this Func<T1, U, T2, U> In)
            {
            return L.Logic.L_Yield2_F<T1, T2, U>()(In);
            }
        #endregion
        #region Yield3
        /// <summary>
        /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
        /// </summary>
        public static Func<T1, T2, U, U> Yield3<T1, T2, U>(this Func<T1, T2, U, U> In)
            {
            return L.Logic.L_Yield3_F<T1, T2, U>()(In);
            }
        #endregion
        #region Yield
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, T1, T2, T3, U> Yield<T1, T2, T3, U>(this Func<U, T1, T2, T3, U> In)
            {
            return L.Logic.L_Yield_F<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield2
        /// <summary>
        /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
        /// </summary>
        public static Func<T1, U, T2, T3, U> Yield2<T1, T2, T3, U>(this Func<T1, U, T2, T3, U> In)
            {
            return L.Logic.L_Yield2_F<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield3
        /// <summary>
        /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
        /// </summary>
        public static Func<T1, T2, U, T3, U> Yield3<T1, T2, T3, U>(this Func<T1, T2, U, T3, U> In)
            {
            return L.Logic.L_Yield3_F<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield4
        /// <summary>
        /// Takes an Action and returns a Func that returns the fourth parameter after the action is performed.
        /// </summary>
        public static Func<T1, T2, T3, U, U> Yield4<T1, T2, T3, U>(this Func<T1, T2, T3, U, U> In)
            {
            return L.Logic.L_Yield4_F<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Execute
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Action Execute(this Func<Action> Act)
            {
            return L.Logic.L_Execute_A()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Action<T1> Execute<T1>(this Func<Action<T1>> Act)
            {
            return L.Logic.L_Execute_A<T1>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Action<T1, T2> Execute<T1, T2>(this Func<Action<T1, T2>> Act)
            {
            return L.Logic.L_Execute_A<T1, T2>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Action<T1, T2, T3> Execute<T1, T2, T3>(this Func<Action<T1, T2, T3>> Act)
            {
            return L.Logic.L_Execute_A<T1, T2, T3>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Action<T1, T2, T3, T4> Execute<T1, T2, T3, T4>(this Func<Action<T1, T2, T3, T4>> Act)
            {
            return L.Logic.L_Execute_A<T1, T2, T3, T4>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Func<U> Execute<U>(this Func<Func<U>> Act)
            {
            return L.Logic.L_Execute_F<U>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Func<T1, U> Execute<T1, U>(this Func<Func<T1, U>> Act)
            {
            return L.Logic.L_Execute_F<T1, U>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Func<T1, T2, U> Execute<T1, T2, U>(this Func<Func<T1, T2, U>> Act)
            {
            return L.Logic.L_Execute_F<T1, T2, U>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Func<T1, T2, T3, U> Execute<T1, T2, T3, U>(this Func<Func<T1, T2, T3, U>> Act)
            {
            return L.Logic.L_Execute_F<T1, T2, T3, U>()(Act);
            }
        /// <summary>
        /// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Execute<T1, T2, T3, T4, U>(this Func<Func<T1, T2, T3, T4, U>> Act)
            {
            return L.Logic.L_Execute_F<T1, T2, T3, T4, U>()(Act);
            }

        #endregion
        #region Defaults
        /// <summary>
        /// If the arguments passed are null or empty, the Default values are used instead.
        /// </summary>
        public static Func<T1, T2, T3, U> Defaults<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T1 Default, T2 Default2, T3 Default3)
            {
            return L.Logic.L_Defaults_F<T1, T2, T3, U>()(In, Default, Default2, Default3);
            }
        /// <summary>
        /// If the arguments passed are null or empty, the Default values are used instead.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Defaults<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T1 Default, T2 Default2, T3 Default3, T4 Default4)
            {
            return L.Logic.L_Defaults_F<T1, T2, T3, T4, U>()(In, Default, Default2, Default3, Default4);
            }
        #endregion
        #region Require
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1> Require<T1>(this Action<T1> In, String ParameterName = null)
            {
            return L.Logic.L_Require_A<T1>()(In, ParameterName);
            }
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2> Require<T1, T2>(this Action<T1, T2> In, String ParameterName = null)
            {
            return L.Logic.L_Require_A<T1, T2>()(In, ParameterName);
            }
        #endregion
        #region Require2
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2> Require2<T1, T2>(this Action<T1, T2> In, String ParameterName2 = null)
            {
            return L.Logic.L_Require2_A<T1, T2>()(In, ParameterName2);
            }
        #endregion
        #region Require
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3> Require<T1, T2, T3>(this Action<T1, T2, T3> In, String ParameterName = null)
            {
            return L.Logic.L_Require_A<T1, T2, T3>()(In, ParameterName);
            }
        #endregion
        #region Require2
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3> Require2<T1, T2, T3>(this Action<T1, T2, T3> In, String ParameterName2 = null)
            {
            return L.Logic.L_Require2_A<T1, T2, T3>()(In, ParameterName2);
            }
        #endregion
        #region Require3
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3> Require3<T1, T2, T3>(this Action<T1, T2, T3> In, String ParameterName3 = null)
            {
            return L.Logic.L_Require3_A<T1, T2, T3>()(In, ParameterName3);
            }
        #endregion
        #region Require
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3, T4> Require<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String ParameterName = null)
            {
            return L.Logic.L_Require_A<T1, T2, T3, T4>()(In, ParameterName);
            }
        #endregion
        #region Require2
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3, T4> Require2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String ParameterName2 = null)
            {
            return L.Logic.L_Require2_A<T1, T2, T3, T4>()(In, ParameterName2);
            }
        #endregion
        #region Require3
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3, T4> Require3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String ParameterName3 = null)
            {
            return L.Logic.L_Require3_A<T1, T2, T3, T4>()(In, ParameterName3);
            }
        #endregion
        #region Require4
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3, T4> Require4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String ParameterName4 = null)
            {
            return L.Logic.L_Require4_A<T1, T2, T3, T4>()(In, ParameterName4);
            }
        #endregion
        #region Require
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, U> Require<T1, U>(this Func<T1, U> In, String ParameterName = null)
            {
            return L.Logic.L_Require_F<T1, U>()(In, ParameterName);
            }
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, U> Require<T1, T2, U>(this Func<T1, T2, U> In, String ParameterName = null)
            {
            return L.Logic.L_Require_F<T1, T2, U>()(In, ParameterName);
            }
        #endregion
        #region Require2
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, U> Require2<T1, T2, U>(this Func<T1, T2, U> In, String ParameterName2 = null)
            {
            return L.Logic.L_Require2_F<T1, T2, U>()(In, ParameterName2);
            }
        #endregion
        #region Require
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, U> Require<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String ParameterName = null)
            {
            return L.Logic.L_Require_F<T1, T2, T3, U>()(In, ParameterName);
            }
        #endregion
        #region Require2
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, U> Require2<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String ParameterName2 = null)
            {
            return L.Logic.L_Require2_F<T1, T2, T3, U>()(In, ParameterName2);
            }
        #endregion
        #region Require3
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, U> Require3<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String ParameterName3 = null)
            {
            return L.Logic.L_Require3_F<T1, T2, T3, U>()(In, ParameterName3);
            }
        #endregion
        #region Require
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Require<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String ParameterName = null)
            {
            return L.Logic.L_Require_F<T1, T2, T3, T4, U>()(In, ParameterName);
            }
        #endregion
        #region Require2
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Require2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String ParameterName2 = null)
            {
            return L.Logic.L_Require2_F<T1, T2, T3, T4, U>()(In, ParameterName2);
            }
        #endregion
        #region Require3
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Require3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String ParameterName3 = null)
            {
            return L.Logic.L_Require3_F<T1, T2, T3, T4, U>()(In, ParameterName3);
            }
        #endregion
        #region Require4
        /// <summary>
        /// Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Require4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String ParameterName4 = null)
            {
            return L.Logic.L_Require4_F<T1, T2, T3, T4, U>()(In, ParameterName4);
            }
        #endregion
        #region RequireAll
        /// <summary>
        /// Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2> RequireAll<T1, T2>(this Action<T1, T2> In, String ParameterName = null, String ParameterName2 = null)
            {
            return L.Logic.L_RequireAll_A<T1, T2>()(In, ParameterName, ParameterName2);
            }
        /// <summary>
        /// Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3> RequireAll<T1, T2, T3>(this Action<T1, T2, T3> In, String ParameterName = null, String ParameterName2 = null, String ParameterName3 = null)
            {
            return L.Logic.L_RequireAll_A<T1, T2, T3>()(In, ParameterName, ParameterName2, ParameterName3);
            }
        /// <summary>
        /// Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Action<T1, T2, T3, T4> RequireAll<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, String ParameterName = null, String ParameterName2 = null, String ParameterName3 = null, String ParameterName4 = null)
            {
            return L.Logic.L_RequireAll_A<T1, T2, T3, T4>()(In, ParameterName, ParameterName2, ParameterName3, ParameterName4);
            }
        /// <summary>
        /// Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, U> RequireAll<T1, T2, U>(this Func<T1, T2, U> In, String ParameterName = null, String ParameterName2 = null)
            {
            return L.Logic.L_RequireAll_F<T1, T2, U>()(In, ParameterName, ParameterName2);
            }
        /// <summary>
        /// Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, U> RequireAll<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String ParameterName = null, String ParameterName2 = null, String ParameterName3 = null)
            {
            return L.Logic.L_RequireAll_F<T1, T2, T3, U>()(In, ParameterName, ParameterName2, ParameterName3);
            }
        /// <summary>
        /// Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> RequireAll<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String ParameterName = null, String ParameterName2 = null, String ParameterName3 = null, String ParameterName4 = null)
            {
            return L.Logic.L_RequireAll_F<T1, T2, T3, T4, U>()(In, ParameterName, ParameterName2, ParameterName3, ParameterName4);
            }
        #endregion
        #region Yield
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, U> Yield<U>(this Action<U> In)
            {
            return L.Logic.L_Yield_A<U>()(In);
            }
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, T1, U> Yield<T1, U>(this Action<U, T1> In)
            {
            return L.Logic.L_Yield_A<T1, U>()(In);
            }
        #endregion
        #region Yield2
        /// <summary>
        /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
        /// </summary>
        public static Func<T1, U, U> Yield2<T1, U>(this Action<T1, U> In)
            {
            return L.Logic.L_Yield2_A<T1, U>()(In);
            }
        #endregion
        #region Yield
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, T1, T2, U> Yield<T1, T2, U>(this Action<U, T1, T2> In)
            {
            return L.Logic.L_Yield_A<T1, T2, U>()(In);
            }
        #endregion
        #region Yield2
        /// <summary>
        /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
        /// </summary>
        public static Func<T1, U, T2, U> Yield2<T1, T2, U>(this Action<T1, U, T2> In)
            {
            return L.Logic.L_Yield2_A<T1, T2, U>()(In);
            }
        #endregion
        #region Yield3
        /// <summary>
        /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
        /// </summary>
        public static Func<T1, T2, U, U> Yield3<T1, T2, U>(this Action<T1, T2, U> In)
            {
            return L.Logic.L_Yield3_A<T1, T2, U>()(In);
            }
        #endregion
        #region Yield
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, T1, T2, T3, U> Yield<T1, T2, T3, U>(this Action<U, T1, T2, T3> In)
            {
            return L.Logic.L_Yield_A<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield2
        /// <summary>
        /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
        /// </summary>
        public static Func<T1, U, T2, T3, U> Yield2<T1, T2, T3, U>(this Action<T1, U, T2, T3> In)
            {
            return L.Logic.L_Yield2_A<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield3
        /// <summary>
        /// Takes an Action and returns a Func that returns the third parameter after the action is performed.
        /// </summary>
        public static Func<T1, T2, U, T3, U> Yield3<T1, T2, T3, U>(this Action<T1, T2, U, T3> In)
            {
            return L.Logic.L_Yield3_A<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield4
        /// <summary>
        /// Takes an Action and returns a Func that returns the fourth parameter after the action is performed.
        /// </summary>
        public static Func<T1, T2, T3, U, U> Yield4<T1, T2, T3, U>(this Action<T1, T2, T3, U> In)
            {
            return L.Logic.L_Yield4_A<T1, T2, T3, U>()(In);
            }
        #endregion
        #region Yield
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, U> Yield<U>(this Func<U, U> In)
            {
            return L.Logic.L_Yield_F<U>()(In);
            }
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, T1, U> Yield<T1, U>(this Func<U, T1, U> In)
            {
            return L.Logic.L_Yield_F<T1, U>()(In);
            }
        #endregion
        #region Yield2
        /// <summary>
        /// Takes an Action and returns a Func that returns the second parameter after the action is performed.
        /// </summary>
        public static Func<T1, U, U> Yield2<T1, U>(this Func<T1, U, U> In)
            {
            return L.Logic.L_Yield2_F<T1, U>()(In);
            }
        #endregion
        #region Yield
        /// <summary>
        /// Takes an Action and returns a Func that returns the first parameter after the action is performed.
        /// </summary>
        public static Func<U, T1, T2, U> Yield<T1, T2, U>(this Func<U, T1, T2, U> In)
            {
            return L.Logic.L_Yield_F<T1, T2, U>()(In);
            }
        #endregion
        #region Return
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Return<T1, T2, T3, T4, U>(this Action<T1, T2, T3, T4> In, U Obj = default(U))
            {
            return L.Logic.L_Return_A<T1, T2, T3, T4, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that Overrides the return value of In with the specified value.
        /// </summary>
        public static Func<U> Return<U>(this Func<U> In, U Obj = default(U))
            {
            return L.Logic.L_Return_F<U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, U> Return<T1, U>(this Func<T1, U> In, U Obj = default(U))
            {
            return L.Logic.L_Return_F<T1, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, T2, U> Return<T1, T2, U>(this Func<T1, T2, U> In, U Obj = default(U))
            {
            return L.Logic.L_Return_F<T1, T2, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, T2, T3, U> Return<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, U Obj = default(U))
            {
            return L.Logic.L_Return_F<T1, T2, T3, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Return<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, U Obj = default(U))
            {
            return L.Logic.L_Return_F<T1, T2, T3, T4, U>()(In, Obj);
            }
        #endregion
        #region Rotate
        /// <summary>
        /// Returns a function that rotates the list of parameters to the right.
        /// </summary>
        public static Action<T2, T1> Rotate<T1, T2>(this Action<T1, T2> In)
            {
            return L.Logic.L_Rotate_A<T1, T2>()(In);
            }
        /// <summary>
        /// Returns a function that rotates the list of parameters to the right.
        /// </summary>
        public static Action<T3, T1, T2> Rotate<T1, T2, T3>(this Action<T1, T2, T3> In)
            {
            return L.Logic.L_Rotate_A<T1, T2, T3>()(In);
            }
        /// <summary>
        /// Returns a function that rotates the list of parameters to the right.
        /// </summary>
        public static Action<T4, T1, T2, T3> Rotate<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In)
            {
            return L.Logic.L_Rotate_A<T1, T2, T3, T4>()(In);
            }
        /// <summary>
        /// Returns a function that rotates the list of parameters to the right.
        /// </summary>
        public static Func<T2, T1, U> Rotate<T1, T2, U>(this Func<T1, T2, U> In)
            {
            return L.Logic.L_Rotate_F<T1, T2, U>()(In);
            }
        /// <summary>
        /// Returns a function that rotates the list of parameters to the right.
        /// </summary>
        public static Func<T3, T1, T2, U> Rotate<T1, T2, T3, U>(this Func<T1, T2, T3, U> In)
            {
            return L.Logic.L_Rotate_F<T1, T2, T3, U>()(In);
            }
        /// <summary>
        /// Returns a function that rotates the list of parameters to the right.
        /// </summary>
        public static Func<T4, T1, T2, T3, U> Rotate<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In)
            {
            return L.Logic.L_Rotate_F<T1, T2, T3, T4, U>()(In);
            }
        #endregion
        #region RotateBack
        /// <summary>
        /// Returns a function that rotates the list of parameters to the left.
        /// </summary>
        public static Action<T2, T1> RotateBack<T1, T2>(this Action<T1, T2> In)
            {
            return L.Logic.L_RotateBack_A<T1, T2>()(In);
            }
        #endregion
        #region Default
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1> Default<T1>(this Action<T1> In, T1 Default)
            {
            return L.Logic.L_Default_A<T1>()(In, Default);
            }
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2> Default<T1, T2>(this Action<T1, T2> In, T1 Default)
            {
            return L.Logic.L_Default_A<T1, T2>()(In, Default);
            }
        #endregion
        #region Default2
        /// <summary>
        /// If the second argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2> Default2<T1, T2>(this Action<T1, T2> In, T2 Default)
            {
            return L.Logic.L_Default2_A<T1, T2>()(In, Default);
            }
        #endregion
        #region Default
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3> Default<T1, T2, T3>(this Action<T1, T2, T3> In, T1 Default)
            {
            return L.Logic.L_Default_A<T1, T2, T3>()(In, Default);
            }
        #endregion
        #region Default2
        /// <summary>
        /// If the second argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3> Default2<T1, T2, T3>(this Action<T1, T2, T3> In, T2 Default2)
            {
            return L.Logic.L_Default2_A<T1, T2, T3>()(In, Default2);
            }
        #endregion
        #region Default3
        /// <summary>
        /// If the third argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3> Default3<T1, T2, T3>(this Action<T1, T2, T3> In, T3 Default3)
            {
            return L.Logic.L_Default3_A<T1, T2, T3>()(In, Default3);
            }
        #endregion
        #region Default
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3, T4> Default<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T1 Default)
            {
            return L.Logic.L_Default_A<T1, T2, T3, T4>()(In, Default);
            }
        #endregion
        #region Default2
        /// <summary>
        /// If the second argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3, T4> Default2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T2 Default2)
            {
            return L.Logic.L_Default2_A<T1, T2, T3, T4>()(In, Default2);
            }
        #endregion
        #region Default3
        /// <summary>
        /// If the third argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3, T4> Default3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T3 Default3)
            {
            return L.Logic.L_Default3_A<T1, T2, T3, T4>()(In, Default3);
            }
        #endregion
        #region Default4
        /// <summary>
        /// If the fourth argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Action<T1, T2, T3, T4> Default4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T4 Default4)
            {
            return L.Logic.L_Default4_A<T1, T2, T3, T4>()(In, Default4);
            }
        #endregion
        #region Default
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, U> Default<T1, U>(this Func<T1, U> In, T1 Default)
            {
            return L.Logic.L_Default_F<T1, U>()(In, Default);
            }
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, U> Default<T1, T2, U>(this Func<T1, T2, U> In, T1 Default)
            {
            return L.Logic.L_Default_F<T1, T2, U>()(In, Default);
            }
        #endregion
        #region Default2
        /// <summary>
        /// If the second argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, U> Default2<T1, T2, U>(this Func<T1, T2, U> In, T2 Default2)
            {
            return L.Logic.L_Default2_F<T1, T2, U>()(In, Default2);
            }
        #endregion
        #region Default
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, U> Default<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T1 Default)
            {
            return L.Logic.L_Default_F<T1, T2, T3, U>()(In, Default);
            }
        #endregion
        #region Default2
        /// <summary>
        /// If the second argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, U> Default2<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T2 Default2)
            {
            return L.Logic.L_Default2_F<T1, T2, T3, U>()(In, Default2);
            }
        #endregion
        #region Default3
        /// <summary>
        /// If the third argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, U> Default3<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, T3 Default3)
            {
            return L.Logic.L_Default3_F<T1, T2, T3, U>()(In, Default3);
            }
        #endregion
        #region Default
        /// <summary>
        /// If the first argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Default<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T1 Default)
            {
            return L.Logic.L_Default_F<T1, T2, T3, T4, U>()(In, Default);
            }
        #endregion
        #region Default2
        /// <summary>
        /// If the second argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Default2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T2 Default2)
            {
            return L.Logic.L_Default2_F<T1, T2, T3, T4, U>()(In, Default2);
            }
        #endregion
        #region Default3
        /// <summary>
        /// If the third argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Default3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T3 Default3)
            {
            return L.Logic.L_Default3_F<T1, T2, T3, T4, U>()(In, Default3);
            }
        #endregion
        #region Default4
        /// <summary>
        /// If the fourth argument passed is null or empty, the Default value is used instead.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Default4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, T4 Default4)
            {
            return L.Logic.L_Default4_F<T1, T2, T3, T4, U>()(In, Default4);
            }
        #endregion
        #region Defaults
        /// <summary>
        /// If the arguments passed are null or empty, the Default values are used instead.
        /// </summary>
        public static Action<T1, T2> Defaults<T1, T2>(this Action<T1, T2> In, T1 Default, T2 Default2)
            {
            return L.Logic.L_Defaults_A<T1, T2>()(In, Default, Default2);
            }
        /// <summary>
        /// If the arguments passed are null or empty, the Default values are used instead.
        /// </summary>
        public static Action<T1, T2, T3> Defaults<T1, T2, T3>(this Action<T1, T2, T3> In, T1 Default, T2 Default2, T3 Default3)
            {
            return L.Logic.L_Defaults_A<T1, T2, T3>()(In, Default, Default2, Default3);
            }
        /// <summary>
        /// If the arguments passed are null or empty, the Default values are used instead.
        /// </summary>
        public static Action<T1, T2, T3, T4> Defaults<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, T1 Default, T2 Default2, T3 Default3, T4 Default4)
            {
            return L.Logic.L_Defaults_A<T1, T2, T3, T4>()(In, Default, Default2, Default3, Default4);
            }
        /// <summary>
        /// If the arguments passed are null or empty, the Default values are used instead.
        /// </summary>
        public static Func<T1, T2, U> Defaults<T1, T2, U>(this Func<T1, T2, U> In, T1 Default, T2 Default2)
            {
            return L.Logic.L_Defaults_F<T1, T2, U>()(In, Default, Default2);
            }
        #endregion
        #region Loop
        /// <summary>
        /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
        /// </summary>
        public static Func<Int32, T1, Boolean> Loop<T1>(this Action<T1> In)
            {
            return L.Loop.L_MergeLoop<T1>()(In);
            }
        /// <summary>
        /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
        /// </summary>
        public static Func<Int32, T1, T2, Boolean> Loop<T1, T2>(this Action<T1, T2> In)
            {
            return L.Loop.L_MergeLoop<T1, T2>()(In);
            }
        /// <summary>
        /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
        /// </summary>
        public static Func<Int32, T1, T2, T3, Boolean> Loop<T1, T2, T3>(this Action<T1, T2, T3> In)
            {
            return L.Loop.L_MergeLoop<T1, T2, T3>()(In);
            }
        #endregion
        #region To
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action To(this Int32 In, Int32 To, Action Act)
            {
            return L.Loop.L_To()(In, To, Act);
            }
        #region To
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Act)
            {
            return LX_Explode.L_To15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Act)
            {
            return LX_Explode.L_To16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1> To<T1>(this Int32 In, Int32 To, Action<T1> Act)
            {
            return LX_Explode.L_To<T1>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2> To<T1, T2>(this Int32 In, Int32 To, Action<T1, T2> Act)
            {
            return LX_Explode.L_To2<T1, T2>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3> To<T1, T2, T3>(this Int32 In, Int32 To, Action<T1, T2, T3> Act)
            {
            return LX_Explode.L_To3<T1, T2, T3>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4> To<T1, T2, T3, T4>(this Int32 In, Int32 To, Action<T1, T2, T3, T4> Act)
            {
            return LX_Explode.L_To4<T1, T2, T3, T4>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> To<T1, T2, T3, T4, T5>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5> Act)
            {
            return LX_Explode.L_To5<T1, T2, T3, T4, T5>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> To<T1, T2, T3, T4, T5, T6>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6> Act)
            {
            return LX_Explode.L_To6<T1, T2, T3, T4, T5, T6>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> To<T1, T2, T3, T4, T5, T6, T7>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7> Act)
            {
            return LX_Explode.L_To7<T1, T2, T3, T4, T5, T6, T7>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> To<T1, T2, T3, T4, T5, T6, T7, T8>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8> Act)
            {
            return LX_Explode.L_To8<T1, T2, T3, T4, T5, T6, T7, T8>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> To<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Act)
            {
            return LX_Explode.L_To9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Act)
            {
            return LX_Explode.L_To10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Act)
            {
            return LX_Explode.L_To11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Act)
            {
            return LX_Explode.L_To12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Act)
            {
            return LX_Explode.L_To13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(In, To, Act);
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> To<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Int32 In, Int32 To, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Act)
            {
            return LX_Explode.L_To14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(In, To, Act);
            }
        #endregion
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static void To(this Int32 In, Int32 To, Action<Int32> Act)
            {
            L.Loop.L_ToI()(In, To, Act)();
            }
        #endregion
        #region For
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static void For(this Int32 In, Int32 To, Func<Int32, Boolean> Loop)
            {
            L.Loop.L_For()(In, To, Loop)();
            }
        #region For
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1> For<T1>(this Int32 In, Int32 To, Func<Int32, T1, Boolean> Loop)
            {
            return LX_Explode.L_For<T1>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2> For<T1, T2>(this Int32 In, Int32 To, Func<Int32, T1, T2, Boolean> Loop)
            {
            return LX_Explode.L_For2<T1, T2>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3> For<T1, T2, T3>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, Boolean> Loop)
            {
            return LX_Explode.L_For3<T1, T2, T3>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4> For<T1, T2, T3, T4>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, Boolean> Loop)
            {
            return LX_Explode.L_For4<T1, T2, T3, T4>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> For<T1, T2, T3, T4, T5>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, Boolean> Loop)
            {
            return LX_Explode.L_For5<T1, T2, T3, T4, T5>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> For<T1, T2, T3, T4, T5, T6>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, Boolean> Loop)
            {
            return LX_Explode.L_For6<T1, T2, T3, T4, T5, T6>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> For<T1, T2, T3, T4, T5, T6, T7>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, Boolean> Loop)
            {
            return LX_Explode.L_For7<T1, T2, T3, T4, T5, T6, T7>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> For<T1, T2, T3, T4, T5, T6, T7, T8>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, Boolean> Loop)
            {
            return LX_Explode.L_For8<T1, T2, T3, T4, T5, T6, T7, T8>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> For<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean> Loop)
            {
            return LX_Explode.L_For9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> For<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean> Loop)
            {
            return LX_Explode.L_For10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> For<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean> Loop)
            {
            return LX_Explode.L_For11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> For<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean> Loop)
            {
            return LX_Explode.L_For12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> For<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean> Loop)
            {
            return LX_Explode.L_For13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> For<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean> Loop)
            {
            return LX_Explode.L_For14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(In, To, Loop);
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> For<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Int32 In, Int32 To, Func<Int32, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean> Loop)
            {
            return LX_Explode.L_For15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(In, To, Loop);
            }
        #endregion
        #endregion
        #region Do
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action Do<U>(this Func<U> In)
            {
            return L.Logic.L_Do<U>()(In);
            }
        #region Do
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1> Do<T1, U>(this Func<T1, U> In)
            {
            return LX_Explode.L_Do<T1, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2> Do<T1, T2, U>(this Func<T1, T2, U> In)
            {
            return LX_Explode.L_Do2<T1, T2, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3> Do<T1, T2, T3, U>(this Func<T1, T2, T3, U> In)
            {
            return LX_Explode.L_Do3<T1, T2, T3, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4> Do<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In)
            {
            return LX_Explode.L_Do4<T1, T2, T3, T4, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Do<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In)
            {
            return LX_Explode.L_Do5<T1, T2, T3, T4, T5, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Do<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> In)
            {
            return LX_Explode.L_Do6<T1, T2, T3, T4, T5, T6, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Do<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In)
            {
            return LX_Explode.L_Do7<T1, T2, T3, T4, T5, T6, T7, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Do<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In)
            {
            return LX_Explode.L_Do8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In)
            {
            return LX_Explode.L_Do9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In)
            {
            return LX_Explode.L_Do10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In)
            {
            return LX_Explode.L_Do11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In)
            {
            return LX_Explode.L_Do12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In)
            {
            return LX_Explode.L_Do13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In)
            {
            return LX_Explode.L_Do14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In)
            {
            return LX_Explode.L_Do15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(In);
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Do<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In)
            {
            return LX_Explode.L_Do16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(In);
            }
        #endregion
        #endregion
        #region Cache
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<U> Cache<U>(this Func<U> In, String CacheID)
            {
            return L.Logic.L_Cache<U>()(In, CacheID);
            }
        #region Cache
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In, String CacheID)
            {
            return LX_Explode.L_Cache10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In, String CacheID)
            {
            return LX_Explode.L_Cache11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In, String CacheID)
            {
            return LX_Explode.L_Cache12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In, String CacheID)
            {
            return LX_Explode.L_Cache13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In, String CacheID)
            {
            return LX_Explode.L_Cache14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In, String CacheID)
            {
            return LX_Explode.L_Cache15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In, String CacheID)
            {
            return LX_Explode.L_Cache16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, U> Cache<T1, U>(this Func<T1, U> In, String CacheID)
            {
            return LX_Explode.L_Cache<T1, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, U> Cache<T1, T2, U>(this Func<T1, T2, U> In, String CacheID)
            {
            return LX_Explode.L_Cache2<T1, T2, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, U> Cache<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, String CacheID)
            {
            return LX_Explode.L_Cache3<T1, T2, T3, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Cache<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, String CacheID)
            {
            return LX_Explode.L_Cache4<T1, T2, T3, T4, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Cache<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In, String CacheID)
            {
            return LX_Explode.L_Cache5<T1, T2, T3, T4, T5, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Cache<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> In, String CacheID)
            {
            return LX_Explode.L_Cache6<T1, T2, T3, T4, T5, T6, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Cache<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In, String CacheID)
            {
            return LX_Explode.L_Cache7<T1, T2, T3, T4, T5, T6, T7, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In, String CacheID)
            {
            return LX_Explode.L_Cache8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, CacheID);
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Cache<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In, String CacheID)
            {
            return LX_Explode.L_Cache9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, CacheID);
            }
        #endregion
        #endregion
        #region Set
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1> Set<T1>(this Action<T1> Func, Func<T1> In)
            {
            return L.Logic.L_SetFunc_A<T1>()(Func, In);
            }
        #region Set
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2> Set<T1, T2>(this Action<T1, T2> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A2<T1, T2>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3> Set<T1, T2, T3>(this Action<T1, T2, T3> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A3<T1, T2, T3>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4> Set<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A4<T1, T2, T3, T4>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Set<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A5<T1, T2, T3, T4, T5>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Set<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A6<T1, T2, T3, T4, T5, T6>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Set<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A7<T1, T2, T3, T4, T5, T6, T7>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Set<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A8<T1, T2, T3, T4, T5, T6, T7, T8>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(Func, In);
            }
        #endregion
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, U> Set<T1, U>(this Func<T1, U> Func, Func<T1> In)
            {
            return L.Logic.L_SetFunc_F<T1, U>()(Func, In);
            }
        #region Set
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, U> Set<T1, T2, U>(this Func<T1, T2, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F2<T1, T2, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, U> Set<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F3<T1, T2, T3, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Set<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F4<T1, T2, T3, T4, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Set<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F5<T1, T2, T3, T4, T5, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Set<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F6<T1, T2, T3, T4, T5, T6, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Set<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F7<T1, T2, T3, T4, T5, T6, T7, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(Func, In);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Func, Func<T1> In)
            {
            return LX_Explode.L_SetFunc_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(Func, In);
            }
        #endregion
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1> Set<T1>(this Action<T1> Func, T1 Obj)
            {
            return L.Logic.L_Set_A<T1>()(Func, Obj);
            }
        #region Set
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Set<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A7<T1, T2, T3, T4, T5, T6, T7>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Set<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A8<T1, T2, T3, T4, T5, T6, T7, T8>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2> Set<T1, T2>(this Action<T1, T2> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A2<T1, T2>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3> Set<T1, T2, T3>(this Action<T1, T2, T3> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A3<T1, T2, T3>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4> Set<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A4<T1, T2, T3, T4>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Set<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A5<T1, T2, T3, T4, T5>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Set<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> Func, T1 Obj)
            {
            return LX_Explode.L_Set_A6<T1, T2, T3, T4, T5, T6>()(Func, Obj);
            }
        #endregion
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, U> Set<T1, U>(this Func<T1, U> Func, T1 Obj)
            {
            return L.Logic.L_Set_F<T1, U>()(Func, Obj);
            }
        #region Set
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, U> Set<T1, T2, U>(this Func<T1, T2, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F2<T1, T2, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, U> Set<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F3<T1, T2, T3, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Set<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F4<T1, T2, T3, T4, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Set<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F5<T1, T2, T3, T4, T5, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Set<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F6<T1, T2, T3, T4, T5, T6, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Set<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F7<T1, T2, T3, T4, T5, T6, T7, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Set<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Func, T1 Obj)
            {
            return LX_Explode.L_Set_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(Func, Obj);
            }
        #endregion
        #endregion
        #region Set2
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2> Set2<T1, T2>(this Action<T1, T2> Func, T2 Obj)
            {
            return L.Logic.L_Set2_A<T1, T2>()(Func, Obj);
            }
        #region Set2
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3> Set2<T1, T2, T3>(this Action<T1, T2, T3> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A3<T1, T2, T3>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4> Set2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A4<T1, T2, T3, T4>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Set2<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A5<T1, T2, T3, T4, T5>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Set2<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A6<T1, T2, T3, T4, T5, T6>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Set2<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A7<T1, T2, T3, T4, T5, T6, T7>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Set2<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A8<T1, T2, T3, T4, T5, T6, T7, T8>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(Func, Obj);
            }
        #endregion
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, U> Set2<T1, T2, U>(this Func<T1, T2, U> Func, T2 Obj)
            {
            return L.Logic.L_Set2_F<T1, T2, U>()(Func, Obj);
            }
        #region Set2
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Set2<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F6<T1, T2, T3, T4, T5, T6, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Set2<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F7<T1, T2, T3, T4, T5, T6, T7, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Set2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, U> Set2<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F3<T1, T2, T3, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Set2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F4<T1, T2, T3, T4, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Set2<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> Func, T2 Obj)
            {
            return LX_Explode.L_Set2_F5<T1, T2, T3, T4, T5, U>()(Func, Obj);
            }
        #endregion
        #endregion
        #region Set3
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3> Set3<T1, T2, T3>(this Action<T1, T2, T3> Func, T3 Obj)
            {
            return L.Logic.L_Set3_A<T1, T2, T3>()(Func, Obj);
            }
        #region Set3
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4> Set3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A4<T1, T2, T3, T4>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Set3<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A5<T1, T2, T3, T4, T5>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Set3<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A6<T1, T2, T3, T4, T5, T6>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Set3<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A7<T1, T2, T3, T4, T5, T6, T7>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Set3<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A8<T1, T2, T3, T4, T5, T6, T7, T8>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(Func, Obj);
            }
        #endregion
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, U> Set3<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, T3 Obj)
            {
            return L.Logic.L_Set3_F<T1, T2, T3, U>()(Func, Obj);
            }
        #region Set3
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Set3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F4<T1, T2, T3, T4, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Set3<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F5<T1, T2, T3, T4, T5, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Set3<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F6<T1, T2, T3, T4, T5, T6, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Set3<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F7<T1, T2, T3, T4, T5, T6, T7, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Set3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Func, T3 Obj)
            {
            return LX_Explode.L_Set3_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(Func, Obj);
            }
        #endregion
        #endregion
        #region Set4
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4> Set4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, T4 Obj)
            {
            return L.Logic.L_Set4_A<T1, T2, T3, T4>()(Func, Obj);
            }
        #region Set4
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Set4<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A5<T1, T2, T3, T4, T5>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Set4<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A6<T1, T2, T3, T4, T5, T6>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Set4<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A7<T1, T2, T3, T4, T5, T6, T7>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Set4<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A8<T1, T2, T3, T4, T5, T6, T7, T8>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(Func, Obj);
            }
        #endregion
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Set4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, T4 Obj)
            {
            return L.Logic.L_Set4_F<T1, T2, T3, T4, U>()(Func, Obj);
            }
        #region Set4
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Set4<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F5<T1, T2, T3, T4, T5, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Set4<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F6<T1, T2, T3, T4, T5, T6, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Set4<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F7<T1, T2, T3, T4, T5, T6, T7, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(Func, Obj);
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Set4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Func, T4 Obj)
            {
            return LX_Explode.L_Set4_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(Func, Obj);
            }
        #endregion
        #endregion
        #region Return
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<U> Return<U>(this Action In, U Obj = default(U))
            {
            return L.Logic.L_Return_A<U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, U> Return<T1, U>(this Action<T1> In, U Obj = default(U))
            {
            return L.Logic.L_Return_A<T1, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, T2, U> Return<T1, T2, U>(this Action<T1, T2> In, U Obj = default(U))
            {
            return L.Logic.L_Return_A<T1, T2, U>()(In, Obj);
            }
        /// <summary>
        /// Returns a function that converts an action to a Func, returning the specified value.
        /// </summary>
        public static Func<T1, T2, T3, U> Return<T1, T2, T3, U>(this Action<T1, T2, T3> In, U Obj = default(U))
            {
            return L.Logic.L_Return_A<T1, T2, T3, U>()(In, Obj);
            }
        #endregion
        #region If
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<Boolean> If(this Func<Boolean> Condition, Action Action)
            {
            return L.Bool.L_If_A()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, Boolean> If<T1>(this Func<T1, Boolean> Condition, Action<T1> Action)
            {
            return L.Bool.L_If_A<T1>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, Boolean> If<T1, T2>(this Func<T1, T2, Boolean> Condition, Action<T1, T2> Action)
            {
            return L.Bool.L_If_A<T1, T2>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, T3, Boolean> If<T1, T2, T3>(this Func<T1, T2, T3, Boolean> Condition, Action<T1, T2, T3> Action)
            {
            return L.Bool.L_If_A<T1, T2, T3>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, T3, T4, Boolean> If<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> Condition, Action<T1, T2, T3, T4> Action)
            {
            return L.Bool.L_If_A<T1, T2, T3, T4>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<U> If<U>(this Func<Boolean> Condition, Func<U> Action)
            {
            return L.Bool.L_If_F<U>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, U> If<T1, U>(this Func<T1, Boolean> Condition, Func<T1, U> Action)
            {
            return L.Bool.L_If_F<T1, U>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, U> If<T1, T2, U>(this Func<T1, T2, Boolean> Condition, Func<T1, T2, U> Action)
            {
            return L.Bool.L_If_F<T1, T2, U>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, T3, U> If<T1, T2, T3, U>(this Func<T1, T2, T3, Boolean> Condition, Func<T1, T2, T3, U> Action)
            {
            return L.Bool.L_If_F<T1, T2, T3, U>()(Condition, Action);
            }
        /// <summary>
        /// Logical If Statement. If the condition passed is true, the action passed is executed.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> If<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, Boolean> Condition, Func<T1, T2, T3, T4, U> Action)
            {
            return L.Bool.L_If_F<T1, T2, T3, T4, U>()(Condition, Action);
            }
        #endregion
        #region IfElse
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        public static Action IfElse(this Func<Boolean> Condition, Action Action, Action Else)
            {
            return L.Bool.L_IfElse()(Condition, Action, Else);
            }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        public static Action<T1> IfElse<T1>(this Func<T1, Boolean> Condition, Action<T1> Action, Action<T1> Else)
            {
            return L.Bool.L_IfElse<T1>()(Condition, Action, Else);
            }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        public static Action<T1, T2> IfElse<T1, T2>(this Func<T1, T2, Boolean> Condition, Action<T1, T2> Action, Action<T1, T2> Else)
            {
            return L.Bool.L_IfElse<T1, T2>()(Condition, Action, Else);
            }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        public static Action<T1, T2, T3> IfElse<T1, T2, T3>(this Func<T1, T2, T3, Boolean> Condition, Action<T1, T2, T3> Action, Action<T1, T2, T3> Else)
            {
            return L.Bool.L_IfElse<T1, T2, T3>()(Condition, Action, Else);
            }
        /// <summary>
        /// Logical If Else Statment. If the condition passed is true, the first action passed is executed. Otherwise, the second action is executed.
        /// </summary>
        public static Action<T1, T2, T3, T4> IfElse<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Boolean> Condition, Action<T1, T2, T3, T4> Action, Action<T1, T2, T3, T4> Else)
            {
            return L.Bool.L_IfElse<T1, T2, T3, T4>()(Condition, Action, Else);
            }
        #endregion
        #region DoWhile
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action DoWhile(this Action In, Func<Boolean> Continue)
            {
            return L.Loop.L_DoWhile()(In, Continue);
            }
        #region DoWhile
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1> DoWhile<T1>(this Action<T1> In, Func<T1, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile<T1>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2> DoWhile<T1, T2>(this Action<T1, T2> In, Func<T1, T2, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile2<T1, T2>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3> DoWhile<T1, T2, T3>(this Action<T1, T2, T3> In, Func<T1, T2, T3, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile3<T1, T2, T3>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4> DoWhile<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<T1, T2, T3, T4, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile4<T1, T2, T3, T4>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> DoWhile<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> In, Func<T1, T2, T3, T4, T5, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile5<T1, T2, T3, T4, T5>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> DoWhile<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> In, Func<T1, T2, T3, T4, T5, T6, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile6<T1, T2, T3, T4, T5, T6>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> DoWhile<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Func<T1, T2, T3, T4, T5, T6, T7, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile7<T1, T2, T3, T4, T5, T6, T7>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile8<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> DoWhile<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean> Continue)
            {
            return LX_Explode.L_DoWhile16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(In, Continue);
            }
        #endregion
        #endregion
        #region Until
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<U> Until<U>(this Func<U> In, Func<Boolean> Break)
            {
            return L.Loop.L_Until<U>()(In, Break);
            }
        #region Until
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean> Break)
            {
            return LX_Explode.L_Until8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean> Break)
            {
            return LX_Explode.L_Until9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean> Break)
            {
            return LX_Explode.L_Until10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean> Break)
            {
            return LX_Explode.L_Until11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean> Break)
            {
            return LX_Explode.L_Until12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean> Break)
            {
            return LX_Explode.L_Until13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean> Break)
            {
            return LX_Explode.L_Until14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean> Break)
            {
            return LX_Explode.L_Until15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> Until<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean> Break)
            {
            return LX_Explode.L_Until16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, U> Until<T1, U>(this Func<T1, U> In, Func<T1, Boolean> Break)
            {
            return LX_Explode.L_Until<T1, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, U> Until<T1, T2, U>(this Func<T1, T2, U> In, Func<T1, T2, Boolean> Break)
            {
            return LX_Explode.L_Until2<T1, T2, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, U> Until<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1, T2, T3, Boolean> Break)
            {
            return LX_Explode.L_Until3<T1, T2, T3, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> Until<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1, T2, T3, T4, Boolean> Break)
            {
            return LX_Explode.L_Until4<T1, T2, T3, T4, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> Until<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In, Func<T1, T2, T3, T4, T5, Boolean> Break)
            {
            return LX_Explode.L_Until5<T1, T2, T3, T4, T5, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> Until<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> In, Func<T1, T2, T3, T4, T5, T6, Boolean> Break)
            {
            return LX_Explode.L_Until6<T1, T2, T3, T4, T5, T6, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> Until<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In, Func<T1, T2, T3, T4, T5, T6, T7, Boolean> Break)
            {
            return LX_Explode.L_Until7<T1, T2, T3, T4, T5, T6, T7, U>()(In, Break);
            }
        #endregion
        #endregion
        #region DoUntil
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<U> DoUntil<U>(this Func<U> In, Func<Boolean> Break)
            {
            return L.Loop.L_DoUntil<U>()(In, Break);
            }
        #region DoUntil
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, U> DoUntil<T1, U>(this Func<T1, U> In, Func<T1, Boolean> Break)
            {
            return LX_Explode.L_DoUntil<T1, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, U> DoUntil<T1, T2, U>(this Func<T1, T2, U> In, Func<T1, T2, Boolean> Break)
            {
            return LX_Explode.L_DoUntil2<T1, T2, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, U> DoUntil<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1, T2, T3, Boolean> Break)
            {
            return LX_Explode.L_DoUntil3<T1, T2, T3, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, U> DoUntil<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1, T2, T3, T4, Boolean> Break)
            {
            return LX_Explode.L_DoUntil4<T1, T2, T3, T4, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, U> DoUntil<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, T5, U> In, Func<T1, T2, T3, T4, T5, Boolean> Break)
            {
            return LX_Explode.L_DoUntil5<T1, T2, T3, T4, T5, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, U> DoUntil<T1, T2, T3, T4, T5, T6, U>(this Func<T1, T2, T3, T4, T5, T6, U> In, Func<T1, T2, T3, T4, T5, T6, Boolean> Break)
            {
            return LX_Explode.L_DoUntil6<T1, T2, T3, T4, T5, T6, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, U>(this Func<T1, T2, T3, T4, T5, T6, T7, U> In, Func<T1, T2, T3, T4, T5, T6, T7, Boolean> Break)
            {
            return LX_Explode.L_DoUntil7<T1, T2, T3, T4, T5, T6, T7, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean> Break)
            {
            return LX_Explode.L_DoUntil8<T1, T2, T3, T4, T5, T6, T7, T8, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean> Break)
            {
            return LX_Explode.L_DoUntil9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean> Break)
            {
            return LX_Explode.L_DoUntil10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean> Break)
            {
            return LX_Explode.L_DoUntil11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean> Break)
            {
            return LX_Explode.L_DoUntil12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean> Break)
            {
            return LX_Explode.L_DoUntil13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean> Break)
            {
            return LX_Explode.L_DoUntil14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean> Break)
            {
            return LX_Explode.L_DoUntil15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> DoUntil<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean> Break)
            {
            return LX_Explode.L_DoUntil16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()(In, Break);
            }
        #endregion
        #endregion
        #region Repeat
        /// <summary>
        /// Returns an action that is repeated a number of times.
        /// </summary>
        public static Action Repeat(this Action Act, UInt32 Times)
            {
            return L.Loop.L_Repeat()(Act, Times);
            }
        #endregion
        #region WhileI
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1> WhileI<T1>(this Action<Int32, T1> In, Func<Int32, T1, Boolean> Continue)
            {
            return L.Loop.WhileI_T<T1>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2> WhileI<T1, T2>(this Action<Int32, T1, T2> In, Func<Int32, T1, T2, Boolean> Continue)
            {
            return L.Loop.WhileI_T<T1, T2>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3> WhileI<T1, T2, T3>(this Action<Int32, T1, T2, T3> In, Func<Int32, T1, T2, T3, Boolean> Continue)
            {
            return L.Loop.WhileI_T<T1, T2, T3>()(In, Continue);
            }
        #endregion
        #region UntilI
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<U> UntilI<U>(this Func<Int32, U> In, Func<Int32, Boolean> Break)
            {
            return L.Loop.Until<U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, U> UntilI<T1, U>(this Func<Int32, T1, U> In, Func<Int32, T1, Boolean> Break)
            {
            return L.Loop.Until<T1, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, U> UntilI<T1, T2, U>(this Func<Int32, T1, T2, U> In, Func<Int32, T1, T2, Boolean> Break)
            {
            return L.Loop.Until<T1, T2, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, U> UntilI<T1, T2, T3, U>(this Func<Int32, T1, T2, T3, U> In, Func<Int32, T1, T2, T3, Boolean> Break)
            {
            return L.Loop.Until<T1, T2, T3, U>()(In, Break);
            }
        #endregion
        #region DoWhileI
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action DoWhileI(this Action<Int32> In, Func<Int32, Boolean> Continue)
            {
            return L.Loop.DoWhile()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1> DoWhileI<T1>(this Action<Int32, T1> In, Func<Int32, T1, Boolean> Continue)
            {
            return L.Loop.DoWhile<T1>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2> DoWhileI<T1, T2>(this Action<Int32, T1, T2> In, Func<Int32, T1, T2, Boolean> Continue)
            {
            return L.Loop.DoWhile<T1, T2>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3> DoWhileI<T1, T2, T3>(this Action<Int32, T1, T2, T3> In, Func<Int32, T1, T2, T3, Boolean> Continue)
            {
            return L.Loop.DoWhile<T1, T2, T3>()(In, Continue);
            }
        #endregion
        #region DoUntilI
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<U> DoUntilI<U>(this Func<Int32, U> In, Func<Int32, Boolean> Break)
            {
            return L.Loop.DoUntil<U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, U> DoUntilI<T1, U>(this Func<Int32, T1, U> In, Func<Int32, T1, Boolean> Break)
            {
            return L.Loop.DoUntil<T1, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, U> DoUntilI<T1, T2, U>(this Func<Int32, T1, T2, U> In, Func<Int32, T1, T2, Boolean> Break)
            {
            return L.Loop.DoUntil<T1, T2, U>()(In, Break);
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<T1, T2, T3, U> DoUntilI<T1, T2, T3, U>(this Func<Int32, T1, T2, T3, U> In, Func<Int32, T1, T2, T3, Boolean> Break)
            {
            return L.Loop.DoUntil<T1, T2, T3, U>()(In, Break);
            }
        #endregion
        #region Collect
        /// <summary>
        /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
        /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items in the resulting List`<typeparamref name="U" />.
        /// </summary>
        public static Func<List<U>> Collect<U>(this Func<U> Func, UInt32 Times)
            {
            return L.Loop.L_Collect<U>()(Func, Times);
            }
        /// <summary>
        /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
        /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items in the resulting List`<typeparamref name="U" />.
        /// </summary>
        public static Func<T1, List<U>> Collect<T1, U>(this Func<T1, U> Func, UInt32 Times)
            {
            return L.Loop.L_Collect<T1, U>()(Func, Times);
            }
        /// <summary>
        /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
        /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items in the resulting List`<typeparamref name="U" />.
        /// </summary>
        public static Func<T1, T2, List<U>> Collect<T1, T2, U>(this Func<T1, T2, U> Func, UInt32 Times)
            {
            return L.Loop.L_Collect<T1, T2, U>()(Func, Times);
            }
        /// <summary>
        /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
        /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items in the resulting List`<typeparamref name="U" />.
        /// </summary>
        public static Func<T1, T2, T3, List<U>> Collect<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, UInt32 Times)
            {
            return L.Loop.L_Collect<T1, T2, T3, U>()(Func, Times);
            }

        /// <summary>
        /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
        /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items in the resulting List`<typeparamref name="U" />.
        /// </summary>
        public static Func<T1, T2, T3, T4, List<U>> Collect<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, UInt32 Times)
            {
            return L.Loop.L_Collect<T1, T2, T3, T4, U>()(Func, Times);
            }
        #endregion
        #region Loop
        /// <summary>
        /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
        /// </summary>
        public static Func<Int32, Boolean> Loop(this Action In)
            {
            return L.Loop.L_MergeLoop()(In);
            }
        #endregion
        #region While

        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        /// <exception cref="Exception">Exceptions thrown by parameters are not caught.</exception>
        public static Action While(this Action In, Func<Boolean> Continue)
            {
            return L.Loop.While(In, Continue);
            }
        #region While
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1> While<T1>(this Action<T1> In, Func<T1, Boolean> Continue)
            {
            return LX_Explode.L_While<T1>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2> While<T1, T2>(this Action<T1, T2> In, Func<T1, T2, Boolean> Continue)
            {
            return LX_Explode.L_While2<T1, T2>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3> While<T1, T2, T3>(this Action<T1, T2, T3> In, Func<T1, T2, T3, Boolean> Continue)
            {
            return LX_Explode.L_While3<T1, T2, T3>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4> While<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<T1, T2, T3, T4, Boolean> Continue)
            {
            return LX_Explode.L_While4<T1, T2, T3, T4>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> While<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> In, Func<T1, T2, T3, T4, T5, Boolean> Continue)
            {
            return LX_Explode.L_While5<T1, T2, T3, T4, T5>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> While<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> In, Func<T1, T2, T3, T4, T5, T6, Boolean> Continue)
            {
            return LX_Explode.L_While6<T1, T2, T3, T4, T5, T6>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> While<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Func<T1, T2, T3, T4, T5, T6, T7, Boolean> Continue)
            {
            return LX_Explode.L_While7<T1, T2, T3, T4, T5, T6, T7>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> While<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean> Continue)
            {
            return LX_Explode.L_While8<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> While<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean> Continue)
            {
            return LX_Explode.L_While9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean> Continue)
            {
            return LX_Explode.L_While10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean> Continue)
            {
            return LX_Explode.L_While11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean> Continue)
            {
            return LX_Explode.L_While12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean> Continue)
            {
            return LX_Explode.L_While13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean> Continue)
            {
            return LX_Explode.L_While14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean> Continue)
            {
            return LX_Explode.L_While15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(In, Continue);
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> While<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean> Continue)
            {
            return LX_Explode.L_While16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(In, Continue);
            }
        #endregion
        #endregion
        #region WhileI
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        /// <exception cref="Exception">Exceptions thrown by parameters are not caught.</exception>
        public static Action WhileI(this Action<Int32> In, Func<Int32, Boolean> Continue)
            {
            return L.Loop.WhileI(In, Continue);
            }
        #endregion
        #region Then
        /// <summary>
        /// Joins two methods together, performing one then another.
        /// </summary>
        /// <exception cref="Exception">Exceptions thrown by parameters are not caught.</exception>
        public static Action Then(this Action In, Action Act)
            {
            return L.Logic.Then(In, Act);
            }
        #endregion
        #region Merge
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action Merge(this Action In, Action Merge)
            {
            return L.Logic.L_Merge()(In, Merge);
            }
        #endregion
        #region Merge
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> In, Action Merge)
            {
            return LX_Explode.L_Mergex11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> In, Action Merge)
            {
            return LX_Explode.L_Mergex12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> In, Action Merge)
            {
            return LX_Explode.L_Mergex13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> In, Action Merge)
            {
            return LX_Explode.L_Mergex14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> In, Action Merge)
            {
            return LX_Explode.L_Mergex15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> In, Action Merge)
            {
            return LX_Explode.L_Mergex16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> In, Action Merge)
            {
            return LX_Explode.L_Mergex6<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6> In, Action<T7> Merge)
            {
            return LX_Explode.L_Merge7x6<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6> In, Action<T7, T8> Merge)
            {
            return LX_Explode.L_Merge8x6<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6> In, Action<T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x6<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Action Merge)
            {
            return LX_Explode.L_Mergex7<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Action<T8> Merge)
            {
            return LX_Explode.L_Merge8x7<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7> In, Action<T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x7<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Action Merge)
            {
            return LX_Explode.L_Mergex8<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> In, Action<T9> Merge)
            {
            return LX_Explode.L_Merge9x8<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> In, Action Merge)
            {
            return LX_Explode.L_Mergex9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> In, Action Merge)
            {
            return LX_Explode.L_Mergex10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3> Merge<T1, T2, T3>(this Action<T1, T2, T3> In, Action Merge)
            {
            return LX_Explode.L_Mergex3<T1, T2, T3>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4> Merge<T1, T2, T3, T4>(this Action<T1, T2, T3> In, Action<T4> Merge)
            {
            return LX_Explode.L_Merge4x3<T1, T2, T3, T4>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Merge<T1, T2, T3, T4, T5>(this Action<T1, T2, T3> In, Action<T4, T5> Merge)
            {
            return LX_Explode.L_Merge5x3<T1, T2, T3, T4, T5>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3> In, Action<T4, T5, T6> Merge)
            {
            return LX_Explode.L_Merge6x3<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3> In, Action<T4, T5, T6, T7> Merge)
            {
            return LX_Explode.L_Merge7x3<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3> In, Action<T4, T5, T6, T7, T8> Merge)
            {
            return LX_Explode.L_Merge8x3<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3> In, Action<T4, T5, T6, T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x3<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4> Merge<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Action Merge)
            {
            return LX_Explode.L_Mergex4<T1, T2, T3, T4>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Merge<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4> In, Action<T5> Merge)
            {
            return LX_Explode.L_Merge5x4<T1, T2, T3, T4, T5>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4> In, Action<T5, T6> Merge)
            {
            return LX_Explode.L_Merge6x4<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4> In, Action<T5, T6, T7> Merge)
            {
            return LX_Explode.L_Merge7x4<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4> In, Action<T5, T6, T7, T8> Merge)
            {
            return LX_Explode.L_Merge8x4<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4> In, Action<T5, T6, T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x4<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Merge<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> In, Action Merge)
            {
            return LX_Explode.L_Mergex5<T1, T2, T3, T4, T5>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5> In, Action<T6> Merge)
            {
            return LX_Explode.L_Merge6x5<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5> In, Action<T6, T7> Merge)
            {
            return LX_Explode.L_Merge7x5<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5> In, Action<T6, T7, T8> Merge)
            {
            return LX_Explode.L_Merge8x5<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5> In, Action<T6, T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x5<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2> Merge<T1, T2>(this Action In, Action<T1, T2> Merge)
            {
            return LX_Explode.L_Merge2<T1, T2>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3> Merge<T1, T2, T3>(this Action In, Action<T1, T2, T3> Merge)
            {
            return LX_Explode.L_Merge3<T1, T2, T3>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4> Merge<T1, T2, T3, T4>(this Action In, Action<T1, T2, T3, T4> Merge)
            {
            return LX_Explode.L_Merge4<T1, T2, T3, T4>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Merge<T1, T2, T3, T4, T5>(this Action In, Action<T1, T2, T3, T4, T5> Merge)
            {
            return LX_Explode.L_Merge5<T1, T2, T3, T4, T5>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action In, Action<T1, T2, T3, T4, T5, T6> Merge)
            {
            return LX_Explode.L_Merge6<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7> Merge)
            {
            return LX_Explode.L_Merge7<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge)
            {
            return LX_Explode.L_Merge8<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Merge)
            {
            return LX_Explode.L_Merge10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Merge)
            {
            return LX_Explode.L_Merge11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Merge)
            {
            return LX_Explode.L_Merge12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Merge)
            {
            return LX_Explode.L_Merge13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Merge)
            {
            return LX_Explode.L_Merge14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Merge)
            {
            return LX_Explode.L_Merge15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Action In, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Merge)
            {
            return LX_Explode.L_Merge16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1> Merge<T1>(this Action<T1> In, Action Merge)
            {
            return LX_Explode.L_Mergex1<T1>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2> Merge<T1, T2>(this Action<T1> In, Action<T2> Merge)
            {
            return LX_Explode.L_Merge2x1<T1, T2>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3> Merge<T1, T2, T3>(this Action<T1> In, Action<T2, T3> Merge)
            {
            return LX_Explode.L_Merge3x1<T1, T2, T3>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4> Merge<T1, T2, T3, T4>(this Action<T1> In, Action<T2, T3, T4> Merge)
            {
            return LX_Explode.L_Merge4x1<T1, T2, T3, T4>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Merge<T1, T2, T3, T4, T5>(this Action<T1> In, Action<T2, T3, T4, T5> Merge)
            {
            return LX_Explode.L_Merge5x1<T1, T2, T3, T4, T5>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action<T1> In, Action<T2, T3, T4, T5, T6> Merge)
            {
            return LX_Explode.L_Merge6x1<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1> In, Action<T2, T3, T4, T5, T6, T7> Merge)
            {
            return LX_Explode.L_Merge7x1<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1> In, Action<T2, T3, T4, T5, T6, T7, T8> Merge)
            {
            return LX_Explode.L_Merge8x1<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1> In, Action<T2, T3, T4, T5, T6, T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x1<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2> Merge<T1, T2>(this Action<T1, T2> In, Action Merge)
            {
            return LX_Explode.L_Mergex2<T1, T2>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3> Merge<T1, T2, T3>(this Action<T1, T2> In, Action<T3> Merge)
            {
            return LX_Explode.L_Merge3x2<T1, T2, T3>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4> Merge<T1, T2, T3, T4>(this Action<T1, T2> In, Action<T3, T4> Merge)
            {
            return LX_Explode.L_Merge4x2<T1, T2, T3, T4>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5> Merge<T1, T2, T3, T4, T5>(this Action<T1, T2> In, Action<T3, T4, T5> Merge)
            {
            return LX_Explode.L_Merge5x2<T1, T2, T3, T4, T5>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6> Merge<T1, T2, T3, T4, T5, T6>(this Action<T1, T2> In, Action<T3, T4, T5, T6> Merge)
            {
            return LX_Explode.L_Merge6x2<T1, T2, T3, T4, T5, T6>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Merge<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2> In, Action<T3, T4, T5, T6, T7> Merge)
            {
            return LX_Explode.L_Merge7x2<T1, T2, T3, T4, T5, T6, T7>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Merge<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2> In, Action<T3, T4, T5, T6, T7, T8> Merge)
            {
            return LX_Explode.L_Merge8x2<T1, T2, T3, T4, T5, T6, T7, T8>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Merge<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2> In, Action<T3, T4, T5, T6, T7, T8, T9> Merge)
            {
            return LX_Explode.L_Merge9x2<T1, T2, T3, T4, T5, T6, T7, T8, T9>()(In, Merge);
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Action<T1> Merge<T1>(this Action In, Action<T1> Merge)
            {
            return LX_Explode.L_Merge1<T1>()(In, Merge);
            }
        #endregion
        #endregion
        }
    }

