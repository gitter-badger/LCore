
using System;
using System.Collections.Generic;
using LCore.Tools;

// ReSharper disable All


namespace LCore.Extensions
    {
    /// <summary>
    /// Logical function explosion static methods.
    /// </summary>
    public static class LX_Explode
        {
        #region Method Explosions
        #region L_Merge_A_F
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<U>, Func<U>> L_Merge_A_F<U>()
            {
            return (In, Merge) =>
            {
                return () => { In(); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, U>, Func<T1, U>> L_Merge_A_F1<T1, U>()
            {
            return (In, Merge) =>
            {
                return (o1) => { In(); return Merge(o1); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, U>, Func<T1, T2, U>> L_Merge_A_F2<T1, T2, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2) => { In(); return Merge(o1, o2); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, U>, Func<T1, T2, T3, U>> L_Merge_A_F3<T1, T2, T3, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3) => { In(); return Merge(o1, o2, o3); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_A_F4<T1, T2, T3, T4, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4) => { In(); return Merge(o1, o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5<T1, T2, T3, T4, T5, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5) => { In(); return Merge(o1, o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(); return Merge(o1, o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(); return Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<U>, Func<T1, U>> L_Merge_A_Fx1<T1, U>()
            {
            return (In, Merge) =>
            {
                return (o1) => { In(o1); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<U>, Func<T1, U>> L_Merge_A_F1x1<T1, U>()
            {
            return (In, Merge) =>
            {
                return (o1) => { In(o1); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, U>, Func<T1, T2, U>> L_Merge_A_F2x1<T1, T2, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2) => { In(o1); return Merge(o2); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, U>, Func<T1, T2, T3, U>> L_Merge_A_F3x1<T1, T2, T3, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3) => { In(o1); return Merge(o2, o3); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_A_F4x1<T1, T2, T3, T4, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4) => { In(o1); return Merge(o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x1<T1, T2, T3, T4, T5, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5) => { In(o1); return Merge(o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x1<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1); return Merge(o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x1<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x1<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1); return Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<U>, Func<T1, T2, U>> L_Merge_A_Fx2<T1, T2, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2) => { In(o1, o2); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, U>, Func<T1, T2, T3, U>> L_Merge_A_F3x2<T1, T2, T3, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3) => { In(o1, o2); return Merge(o3); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_A_F4x2<T1, T2, T3, T4, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4) => { In(o1, o2); return Merge(o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x2<T1, T2, T3, T4, T5, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5) => { In(o1, o2); return Merge(o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x2<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2); return Merge(o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x2<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x2<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2); return Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<U>, Func<T1, T2, T3, U>> L_Merge_A_Fx3<T1, T2, T3, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3) => { In(o1, o2, o3); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_A_F4x3<T1, T2, T3, T4, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4) => { In(o1, o2, o3); return Merge(o4); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, U>, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x3<T1, T2, T3, T4, T5, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3); return Merge(o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x3<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3); return Merge(o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x3<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x3<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3); return Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<U>, Func<T1, T2, T3, T4, U>> L_Merge_A_Fx4<T1, T2, T3, T4, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, U>, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x4<T1, T2, T3, T4, T5, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4); return Merge(o5); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x4<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4); return Merge(o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x4<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x4<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4); return Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<U>, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_Fx5<T1, T2, T3, T4, T5, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4, o5); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x5<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5); return Merge(o6); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x5<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x5<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5); return Merge(o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<U>, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_Fx6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5, o6); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x6<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x6<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6); return Merge(o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_Fx7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x7<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7); return Merge(o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_Fx8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8); return Merge(o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_Fx9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_Fx10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(o11); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(o11, o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_Fx11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(o12); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(o12, o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_Fx12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(o13); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(o13, o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_Fx13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(o14); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(o14, o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_Fx14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func<T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return Merge(o15); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func<T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return Merge(o15, o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_Fx15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); return Merge(); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func<T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); return Merge(o16); };
            };
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Func<U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_Fx16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Merge) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); return Merge(); };
            };
            }
        #endregion;

        #region L_To
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1>, Action<T1>> L_To<T1>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1) => { };

                return (o1) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2>, Action<T1, T2>> L_To2<T1, T2>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2) => { };

                return (o1, o2) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3>, Action<T1, T2, T3>> L_To3<T1, T2, T3>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3) => { };

                return (o1, o2, o3) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_To4<T1, T2, T3, T4>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4) => { };

                return (o1, o2, o3, o4) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_To5<T1, T2, T3, T4, T5>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5) => { };

                return (o1, o2, o3, o4, o5) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_To6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6) => { };

                return (o1, o2, o3, o4, o5, o6) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_To7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7) => { };

                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_To8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_To9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_To10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_To11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_To12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_To13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_To14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_To15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_To16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
                        }
                };
            };
            }
        #endregion;

        #region L_ToI
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1>, Action<T1>> L_ToI<T1>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1) => { };

                return (o1) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2>, Action<T1, T2>> L_ToI2<T1, T2>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2) => { };

                return (o1, o2) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3>, Action<T1, T2, T3>> L_ToI3<T1, T2, T3>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3) => { };

                return (o1, o2, o3) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_ToI4<T1, T2, T3, T4>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4) => { };

                return (o1, o2, o3, o4) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_ToI5<T1, T2, T3, T4, T5>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5) => { };

                return (o1, o2, o3, o4, o5) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_ToI6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6) => { };

                return (o1, o2, o3, o4, o5, o6) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_ToI7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7) => { };

                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_ToI8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_ToI9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_ToI10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_ToI11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_ToI12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_ToI13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_ToI14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action from a to b. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Action<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_ToI15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, To, Action) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i <= To : i >= To; i += Increment)
                        {
                        Action(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                        }
                };
            };
            }
        #endregion;

        #region L_For
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, bool>, Action<T1>> L_For<T1>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1) => { };

                return (o1) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, bool>, Action<T1, T2>> L_For2<T1, T2>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2) => { };

                return (o1, o2) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, bool>, Action<T1, T2, T3>> L_For3<T1, T2, T3>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3) => { };

                return (o1, o2, o3) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>> L_For4<T1, T2, T3, T4>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4) => { };

                return (o1, o2, o3, o4) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, bool>, Action<T1, T2, T3, T4, T5>> L_For5<T1, T2, T3, T4, T5>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5) => { };

                return (o1, o2, o3, o4, o5) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, bool>, Action<T1, T2, T3, T4, T5, T6>> L_For6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6) => { };

                return (o1, o2, o3, o4, o5, o6) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, bool>, Action<T1, T2, T3, T4, T5, T6, T7>> L_For7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7) => { };

                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_For8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_For9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_For10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_For11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_For12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_For13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_For14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14))
                            break;
                        }
                };
            };
            }
        /// <summary>
        /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
        /// </summary>
        public static Func<int, int, Func<int, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_For15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, To, Loop) =>
            {
                if (In == To)
                    return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { };

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    Boolean Positive = In < To;
                    int Increment = Positive ? 1 : -1;
                    for (int i = In; Positive ? i < To : i > To; i += Increment)
                        {
                        if (!Loop(i, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15))
                            break;
                        }
                };
            };
            }
        #endregion;

        #region L_Do
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, U>, Action<T1>> L_Do<T1, U>()
            {
            return (In) =>
            {
                return (o1) => { In(o1); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, U>, Action<T1, T2>> L_Do2<T1, T2, U>()
            {
            return (In) =>
            {
                return (o1, o2) => { In(o1, o2); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, Action<T1, T2, T3>> L_Do3<T1, T2, T3, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3) => { In(o1, o2, o3); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2, T3, T4>> L_Do4<T1, T2, T3, T4, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, Action<T1, T2, T3, T4, T5>> L_Do5<T1, T2, T3, T4, T5, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, Action<T1, T2, T3, T4, T5, T6>> L_Do6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Do7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Do8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Do9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Do10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Do11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Do12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Do13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Do14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Do15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns an Action from the supplied Func. The return value is discarded.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Do16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Cache
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, U>, String, Func<T1, U>> L_Cache<T1, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, U>, String, Func<T1, T2, U>> L_Cache2<T1, T2, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, String, Func<T1, T2, T3, U>> L_Cache3<T1, T2, T3, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, String, Func<T1, T2, T3, T4, U>> L_Cache4<T1, T2, T3, T4, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, String, Func<T1, T2, T3, T4, T5, U>> L_Cache5<T1, T2, T3, T4, T5, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, String, Func<T1, T2, T3, T4, T5, T6, U>> L_Cache6<T1, T2, T3, T4, T5, T6, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Cache7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Cache8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Cache9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Cache10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Cache11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Cache12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Cache13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Cache14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Cache15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        /// <summary>
        /// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Cache16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            L.Logic.Cache(ref L.Logic.L_ResultCacheData,
                () => { return new Dictionary<String, Dictionary<String, CacheData>>(); });

            return (In, CacheID) =>
            {
                Dictionary<String, CacheData> CacheDict = null;
                if (!L.Logic.L_ResultCacheData.ContainsKey(CacheID))
                    {
                    CacheDict = new Dictionary<String, CacheData>();
                    L.Logic.L_ResultCacheData.Add(CacheID, CacheDict);
                    }
                else
                    {
                    CacheDict = L.Logic.L_ResultCacheData[CacheID];
                    }

                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                {
                    DateTime Start = DateTime.Now;

                    String Key = L.Obj.Objects_ToString(L.IEn.Array<Object>(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16)());
                    Boolean Exists = CacheDict.ContainsKey(Key);
                    if (Exists)
                        {
                        CacheData CachedResult = CacheDict[Key];

                        if (CachedResult.Data is U)
                            {
                            DateTime End = DateTime.Now;

                            CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * L.Date.TicksToMilliseconds));

                            return (U)CachedResult.Data;
                            }
                        }
                    U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
                    DateTime End2 = DateTime.Now;
                    if (!Exists)
                        CacheDict.Add(Key, new CacheData(Out, (long)((End2 - Start).Ticks * L.Date.TicksToMilliseconds)));
                    return Out;
                };
            };
            }
        #endregion;

        #region L_SetFunc_A
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2>, Func<T1>, Action<T1, T2>> L_SetFunc_A2<T1, T2>()
            {
            return (Func, In) =>
            {
                return (o1, o2) => { Func(In(), o2); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T1>, Action<T1, T2, T3>> L_SetFunc_A3<T1, T2, T3>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3) => { Func(In(), o2, o3); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T1>, Action<T1, T2, T3, T4>> L_SetFunc_A4<T1, T2, T3, T4>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4) => { Func(In(), o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T1>, Action<T1, T2, T3, T4, T5>> L_SetFunc_A5<T1, T2, T3, T4, T5>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5) => { Func(In(), o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T1>, Action<T1, T2, T3, T4, T5, T6>> L_SetFunc_A6<T1, T2, T3, T4, T5, T6>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { Func(In(), o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7>> L_SetFunc_A7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { Func(In(), o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_SetFunc_A8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { Func(In(), o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_SetFunc_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_SetFunc_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_SetFunc_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_SetFunc_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_SetFunc_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_SetFunc_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_SetFunc_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Func<T1>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_SetFunc_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_SetFunc_F
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, U>, Func<T1>, Func<T1, T2, U>> L_SetFunc_F2<T1, T2, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2) => { return Func(In(), o2); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, Func<T1>, Func<T1, T2, T3, U>> L_SetFunc_F3<T1, T2, T3, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3) => { return Func(In(), o2, o3); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, Func<T1>, Func<T1, T2, T3, T4, U>> L_SetFunc_F4<T1, T2, T3, T4, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4) => { return Func(In(), o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, Func<T1>, Func<T1, T2, T3, T4, T5, U>> L_SetFunc_F5<T1, T2, T3, T4, T5, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5) => { return Func(In(), o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, U>> L_SetFunc_F6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { return Func(In(), o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_SetFunc_F7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { return Func(In(), o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_SetFunc_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_SetFunc_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_SetFunc_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_SetFunc_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_SetFunc_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_SetFunc_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_SetFunc_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_SetFunc_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with the result of In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_SetFunc_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (Func, In) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set_A
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2>, T1, Action<T1, T2>> L_Set_A2<T1, T2>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2) => { Func(Obj, o2); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3>, T1, Action<T1, T2, T3>> L_Set_A3<T1, T2, T3>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3) => { Func(Obj, o2, o3); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, T1, Action<T1, T2, T3, T4>> L_Set_A4<T1, T2, T3, T4>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4) => { Func(Obj, o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, T1, Action<T1, T2, T3, T4, T5>> L_Set_A5<T1, T2, T3, T4, T5>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { Func(Obj, o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, T1, Action<T1, T2, T3, T4, T5, T6>> L_Set_A6<T1, T2, T3, T4, T5, T6>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { Func(Obj, o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, T1, Action<T1, T2, T3, T4, T5, T6, T7>> L_Set_A7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { Func(Obj, o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Set_A8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Set_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Set_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Set_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Set_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Set_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Set_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Set_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, T1, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Set_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set_F
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, U>, T1, Func<T1, T2, U>> L_Set_F2<T1, T2, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2) => { return Func(Obj, o2); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, T1, Func<T1, T2, T3, U>> L_Set_F3<T1, T2, T3, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3) => { return Func(Obj, o2, o3); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, T1, Func<T1, T2, T3, T4, U>> L_Set_F4<T1, T2, T3, T4, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4) => { return Func(Obj, o2, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, T1, Func<T1, T2, T3, T4, T5, U>> L_Set_F5<T1, T2, T3, T4, T5, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { return Func(Obj, o2, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T1, Func<T1, T2, T3, T4, T5, T6, U>> L_Set_F6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { return Func(Obj, o2, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set_F7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { return Func(Obj, o2, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the first parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set2_A
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3>, T2, Action<T1, T2, T3>> L_Set2_A3<T1, T2, T3>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3) => { Func(o1, Obj, o3); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, T2, Action<T1, T2, T3, T4>> L_Set2_A4<T1, T2, T3, T4>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4) => { Func(o1, Obj, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, T2, Action<T1, T2, T3, T4, T5>> L_Set2_A5<T1, T2, T3, T4, T5>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { Func(o1, Obj, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, T2, Action<T1, T2, T3, T4, T5, T6>> L_Set2_A6<T1, T2, T3, T4, T5, T6>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { Func(o1, Obj, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, T2, Action<T1, T2, T3, T4, T5, T6, T7>> L_Set2_A7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { Func(o1, Obj, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Set2_A8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Set2_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Set2_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Set2_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Set2_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Set2_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Set2_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Set2_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, T2, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Set2_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set2_F
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, T2, Func<T1, T2, T3, U>> L_Set2_F3<T1, T2, T3, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3) => { return Func(o1, Obj, o3); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, T2, Func<T1, T2, T3, T4, U>> L_Set2_F4<T1, T2, T3, T4, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4) => { return Func(o1, Obj, o3, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, T2, Func<T1, T2, T3, T4, T5, U>> L_Set2_F5<T1, T2, T3, T4, T5, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { return Func(o1, Obj, o3, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T2, Func<T1, T2, T3, T4, T5, T6, U>> L_Set2_F6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { return Func(o1, Obj, o3, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set2_F7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { return Func(o1, Obj, o3, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set2_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set2_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set2_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set2_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set2_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set2_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set2_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set2_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the second parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set2_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set3_A
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, T3, Action<T1, T2, T3, T4>> L_Set3_A4<T1, T2, T3, T4>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4) => { Func(o1, o2, Obj, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, T3, Action<T1, T2, T3, T4, T5>> L_Set3_A5<T1, T2, T3, T4, T5>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { Func(o1, o2, Obj, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, T3, Action<T1, T2, T3, T4, T5, T6>> L_Set3_A6<T1, T2, T3, T4, T5, T6>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { Func(o1, o2, Obj, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, T3, Action<T1, T2, T3, T4, T5, T6, T7>> L_Set3_A7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { Func(o1, o2, Obj, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Set3_A8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Set3_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Set3_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Set3_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Set3_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Set3_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Set3_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Set3_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, T3, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Set3_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set3_F
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, T3, Func<T1, T2, T3, T4, U>> L_Set3_F4<T1, T2, T3, T4, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4) => { return Func(o1, o2, Obj, o4); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, T3, Func<T1, T2, T3, T4, T5, U>> L_Set3_F5<T1, T2, T3, T4, T5, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { return Func(o1, o2, Obj, o4, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T3, Func<T1, T2, T3, T4, T5, T6, U>> L_Set3_F6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { return Func(o1, o2, Obj, o4, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set3_F7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { return Func(o1, o2, Obj, o4, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set3_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set3_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set3_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set3_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set3_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set3_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set3_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set3_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the third parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set3_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set4_A
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, T4, Action<T1, T2, T3, T4, T5>> L_Set4_A5<T1, T2, T3, T4, T5>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { Func(o1, o2, o3, Obj, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, T4, Action<T1, T2, T3, T4, T5, T6>> L_Set4_A6<T1, T2, T3, T4, T5, T6>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { Func(o1, o2, o3, Obj, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, T4, Action<T1, T2, T3, T4, T5, T6, T7>> L_Set4_A7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { Func(o1, o2, o3, Obj, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Set4_A8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Set4_A9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Set4_A10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Set4_A11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Set4_A12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Set4_A13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Set4_A14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Set4_A15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, T4, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Set4_A16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_Set4_F
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, T4, Func<T1, T2, T3, T4, T5, U>> L_Set4_F5<T1, T2, T3, T4, T5, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5) => { return Func(o1, o2, o3, Obj, o5); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T4, Func<T1, T2, T3, T4, T5, T6, U>> L_Set4_F6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6) => { return Func(o1, o2, o3, Obj, o5, o6); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set4_F7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) => { return Func(o1, o2, o3, Obj, o5, o6, o7); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set4_F8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set4_F9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set4_F10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set4_F11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set4_F12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set4_F13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set4_F14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set4_F15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
            };
            }
        /// <summary>
        /// Returns a function that sets (overrides) the fourth parameter in Func with In
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set4_F16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (Func, Obj) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); };
            };
            }
        #endregion;

        #region L_DoWhile
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1>, Func<T1, Boolean>, Action<T1>> L_DoWhile<T1>()
            {
            return (In, Continue) =>
            {
                return (o1) =>
                {
                    do
                        {
                        In(o1);
                        }
                    while (Continue(o1));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T1, T2, Boolean>, Action<T1, T2>> L_DoWhile2<T1, T2>()
            {
            return (In, Continue) =>
            {
                return (o1, o2) =>
                {
                    do
                        {
                        In(o1, o2);
                        }
                    while (Continue(o1, o2));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T1, T2, T3, Boolean>, Action<T1, T2, T3>> L_DoWhile3<T1, T2, T3>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3) =>
                {
                    do
                        {
                        In(o1, o2, o3);
                        }
                    while (Continue(o1, o2, o3));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, Boolean>, Action<T1, T2, T3, T4>> L_DoWhile4<T1, T2, T3, T4>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4);
                        }
                    while (Continue(o1, o2, o3, o4));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T1, T2, T3, T4, T5, Boolean>, Action<T1, T2, T3, T4, T5>> L_DoWhile5<T1, T2, T3, T4, T5>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5);
                        }
                    while (Continue(o1, o2, o3, o4, o5));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T1, T2, T3, T4, T5, T6, Boolean>, Action<T1, T2, T3, T4, T5, T6>> L_DoWhile6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T1, T2, T3, T4, T5, T6, T7, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7>> L_DoWhile7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_DoWhile8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_DoWhile9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_DoWhile10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_DoWhile11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_DoWhile12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_DoWhile13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_DoWhile14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_DoWhile15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15));
                };
            };
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_DoWhile16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Continue) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                {
                    do
                        {
                        In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
                        }
                    while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16));
                };
            };
            }
        #endregion;

        #region L_Until
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, U>, Func<T1, Boolean>, Func<T1, U>> L_Until<T1, U>()
            {
            return (In, Break) =>
            {
                return (o1) =>
                {
                    U Out = default(U);
                    while (!Break(o1) && Out == null)
                        {
                        Out = In(o1);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, U>, Func<T1, T2, Boolean>, Func<T1, T2, U>> L_Until2<T1, T2, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2) && Out == null)
                        {
                        Out = In(o1, o2);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, Func<T1, T2, T3, Boolean>, Func<T1, T2, T3, U>> L_Until3<T1, T2, T3, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3) && Out == null)
                        {
                        Out = In(o1, o2, o3);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, Boolean>, Func<T1, T2, T3, T4, U>> L_Until4<T1, T2, T3, T4, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, Boolean>, Func<T1, T2, T3, T4, T5, U>> L_Until5<T1, T2, T3, T4, T5, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, Boolean>, Func<T1, T2, T3, T4, T5, T6, U>> L_Until6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Until7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Until8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Until9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Until10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Until11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Until12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Until13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Until14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Until15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                        }
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Until16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                {
                    U Out = default(U);
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) && Out == null)
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
                        }
                    return Out;
                };
            };
            }
        #endregion;

        #region L_DoUntil
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, U>, Func<T1, Boolean>, Func<T1, U>> L_DoUntil<T1, U>()
            {
            return (In, Break) =>
            {
                return (o1) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1);
                        }
                    while (!Break(o1) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, U>, Func<T1, T2, Boolean>, Func<T1, T2, U>> L_DoUntil2<T1, T2, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2);
                        }
                    while (!Break(o1, o2) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, U>, Func<T1, T2, T3, Boolean>, Func<T1, T2, T3, U>> L_DoUntil3<T1, T2, T3, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3);
                        }
                    while (!Break(o1, o2, o3) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, Boolean>, Func<T1, T2, T3, T4, U>> L_DoUntil4<T1, T2, T3, T4, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4);
                        }
                    while (!Break(o1, o2, o3, o4) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, Boolean>, Func<T1, T2, T3, T4, T5, U>> L_DoUntil5<T1, T2, T3, T4, T5, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5);
                        }
                    while (!Break(o1, o2, o3, o4, o5) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, Boolean>, Func<T1, T2, T3, T4, T5, T6, U>> L_DoUntil6<T1, T2, T3, T4, T5, T6, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_DoUntil7<T1, T2, T3, T4, T5, T6, T7, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_DoUntil8<T1, T2, T3, T4, T5, T6, T7, T8, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_DoUntil9<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_DoUntil10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_DoUntil11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_DoUntil12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_DoUntil13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_DoUntil14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_DoUntil15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) && Out == null);
                    return Out;
                };
            };
            }
        /// <summary>
        /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
        /// </summary>
        public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_DoUntil16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
            {
            return (In, Break) =>
            {
                return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                {
                    U Out = default(U);
                    do
                        {
                        Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
                        }
                    while (!Break(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) && Out == null);
                    return Out;
                };
            };
            }
        #endregion;

        #region L_While
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1>, Func<T1, Boolean>, Action<T1>> L_While<T1>()
            {
            return (In, Continue) =>
                    {
                        return (o1) =>
                        {
                            while (Continue(o1))
                                {
                                In(o1);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2>, Func<T1, T2, Boolean>, Action<T1, T2>> L_While2<T1, T2>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2) =>
                        {
                            while (Continue(o1, o2))
                                {
                                In(o1, o2);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Func<T1, T2, T3, Boolean>, Action<T1, T2, T3>> L_While3<T1, T2, T3>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3) =>
                        {
                            while (Continue(o1, o2, o3))
                                {
                                In(o1, o2, o3);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, Boolean>, Action<T1, T2, T3, T4>> L_While4<T1, T2, T3, T4>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4) =>
                        {
                            while (Continue(o1, o2, o3, o4))
                                {
                                In(o1, o2, o3, o4);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Func<T1, T2, T3, T4, T5, Boolean>, Action<T1, T2, T3, T4, T5>> L_While5<T1, T2, T3, T4, T5>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5))
                                {
                                In(o1, o2, o3, o4, o5);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Func<T1, T2, T3, T4, T5, T6, Boolean>, Action<T1, T2, T3, T4, T5, T6>> L_While6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6))
                                {
                                In(o1, o2, o3, o4, o5, o6);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Func<T1, T2, T3, T4, T5, T6, T7, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7>> L_While7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_While8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_While9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_While10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_While11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_While12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_While13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_While14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_While15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
                                }
                        };
                    }
            ;
            }
        /// <summary>
        /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_While16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Continue) =>
                    {
                        return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
                        {
                            while (Continue(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16))
                                {
                                In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
                                }
                        };
                    }
            ;
            }
        #endregion;

        #region L_Merge
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action, Action> L_Merge()
            {
            return (In, Merge) => { return () => { In(); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1>, Action<T1>> L_Merge1<T1>()
            {
            return (In, Merge) => { return (o1) => { In(); Merge(o1); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2>, Action<T1, T2>> L_Merge2<T1, T2>()
            {
            return (In, Merge) => { return (o1, o2) => { In(); Merge(o1, o2); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3>, Action<T1, T2, T3>> L_Merge3<T1, T2, T3>()
            {
            return (In, Merge) => { return (o1, o2, o3) => { In(); Merge(o1, o2, o3); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_Merge4<T1, T2, T3, T4>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4) => { In(); Merge(o1, o2, o3, o4); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_Merge5<T1, T2, T3, T4, T5>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(); Merge(o1, o2, o3, o4, o5); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_Merge6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(); Merge(o1, o2, o3, o4, o5, o6); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(); Merge(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action, Action<T1>> L_Mergex1<T1>()
            {
            return (In, Merge) => { return (o1) => { In(o1); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action, Action<T1>> L_Merge1x1<T1>()
            {
            return (In, Merge) => { return (o1) => { In(o1); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2>, Action<T1, T2>> L_Merge2x1<T1, T2>()
            {
            return (In, Merge) => { return (o1, o2) => { In(o1); Merge(o2); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3>, Action<T1, T2, T3>> L_Merge3x1<T1, T2, T3>()
            {
            return (In, Merge) => { return (o1, o2, o3) => { In(o1); Merge(o2, o3); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4>, Action<T1, T2, T3, T4>> L_Merge4x1<T1, T2, T3, T4>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4) => { In(o1); Merge(o2, o3, o4); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_Merge5x1<T1, T2, T3, T4, T5>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(o1); Merge(o2, o3, o4, o5); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x1<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(o1); Merge(o2, o3, o4, o5, o6); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x1<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1); Merge(o2, o3, o4, o5, o6, o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x1<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x1<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1>, Action<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x1<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1); Merge(o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action, Action<T1, T2>> L_Mergex2<T1, T2>()
            {
            return (In, Merge) => { return (o1, o2) => { In(o1, o2); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3>, Action<T1, T2, T3>> L_Merge3x2<T1, T2, T3>()
            {
            return (In, Merge) => { return (o1, o2, o3) => { In(o1, o2); Merge(o3); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4>, Action<T1, T2, T3, T4>> L_Merge4x2<T1, T2, T3, T4>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4) => { In(o1, o2); Merge(o3, o4); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_Merge5x2<T1, T2, T3, T4, T5>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(o1, o2); Merge(o3, o4, o5); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x2<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(o1, o2); Merge(o3, o4, o5, o6); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x2<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2); Merge(o3, o4, o5, o6, o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x2<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x2<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2>, Action<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x2<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2); Merge(o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action, Action<T1, T2, T3>> L_Mergex3<T1, T2, T3>()
            {
            return (In, Merge) => { return (o1, o2, o3) => { In(o1, o2, o3); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4>, Action<T1, T2, T3, T4>> L_Merge4x3<T1, T2, T3, T4>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4) => { In(o1, o2, o3); Merge(o4); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5>, Action<T1, T2, T3, T4, T5>> L_Merge5x3<T1, T2, T3, T4, T5>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(o1, o2, o3); Merge(o4, o5); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x3<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3); Merge(o4, o5, o6); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x3<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3); Merge(o4, o5, o6, o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x3<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x3<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3>, Action<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3); Merge(o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action, Action<T1, T2, T3, T4>> L_Mergex4<T1, T2, T3, T4>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5>, Action<T1, T2, T3, T4, T5>> L_Merge5x4<T1, T2, T3, T4, T5>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4); Merge(o5); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x4<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4); Merge(o5, o6); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x4<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4); Merge(o5, o6, o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x4<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x4<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4>, Action<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x4<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4); Merge(o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action, Action<T1, T2, T3, T4, T5>> L_Mergex5<T1, T2, T3, T4, T5>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4, o5); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6>, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x5<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5); Merge(o6); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x5<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5); Merge(o6, o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x5<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x5<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5>, Action<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x5<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5); Merge(o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action, Action<T1, T2, T3, T4, T5, T6>> L_Mergex6<T1, T2, T3, T4, T5, T6>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5, o6); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x6<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6); Merge(o7); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x6<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x6<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6>, Action<T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x6<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6); Merge(o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action, Action<T1, T2, T3, T4, T5, T6, T7>> L_Mergex7<T1, T2, T3, T4, T5, T6, T7>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x7<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x7<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7>, Action<T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x7<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7); Merge(o8, o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Mergex8<T1, T2, T3, T4, T5, T6, T7, T8>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x8<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x8<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8); Merge(o9, o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Mergex9<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10, o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10, o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10, o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10, o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10, o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(o10, o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Mergex10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(o11); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(o11, o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(o11, o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(o11, o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(o11, o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(o11, o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Mergex11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(o12); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(o12, o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(o12, o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(o12, o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(o12, o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Mergex12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(o13); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(o13, o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(o13, o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x12<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(o13, o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Mergex13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(o14); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(o14, o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x13<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(o14, o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Mergex14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); Merge(o15); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x14<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); Merge(o15, o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Mergex15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); Merge(); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x15<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); Merge(o16); }; }
            ;
            }
        /// <summary>
        /// Returns a function that Performs In, then Merge. Parameter lists are merged.
        /// </summary>
        public static Func<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Mergex16<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
            {
            return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); Merge(); }; }
            ;
            }
        #endregion;
        #endregion
        }
    }