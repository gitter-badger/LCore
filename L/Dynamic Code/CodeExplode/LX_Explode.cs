using System;
using System.Collections.Generic;

namespace LCore
{
public static class LX_Explode
{
#region Method Explosions
#region L_Merge_A_F
		public static Func<Action/*X2GA*/, Func/*GF*/<U>/*X2-TI*/, Func<U>> L_Merge_A_F/*MF*/<U>()
			{
			return (In, Merge) =>
			{
				return () => { In(/*X2A*/); return Merge(/*A*//*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, U>/*X2-TI*/, Func<T1, U>> L_Merge_A_F1/*MF*/<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o1) => { In(/*X2A*/); return Merge(/*A*/o1/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, U>/*X2-TI*/, Func<T1, T2, U>> L_Merge_A_F2/*MF*/<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { In(/*X2A*/); return Merge(/*A*/o1, o2/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, U>/*X2-TI*/, Func<T1, T2, T3, U>> L_Merge_A_F3/*MF*/<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, U>/*X2-TI*/, Func<T1, T2, T3, T4, U>> L_Merge_A_F4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*X2-TI*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/); return Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*X2-OI*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<U>/*-T1*/, Func<T1, U>> L_Merge_A_Fx1/*MF*/<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o1) => { In(/*X2A*/o1); return Merge(/*A*//*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<U>/*-T1*/, Func<T1, U>> L_Merge_A_F1x1/*MF*/<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o1) => { In(/*X2A*/o1); return Merge(/*A*//*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, U>/*-T1*/, Func<T1, T2, U>> L_Merge_A_F2x1/*MF*/<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { In(/*X2A*/o1); return Merge(/*A*/o2/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, U>/*-T1*/, Func<T1, T2, T3, U>> L_Merge_A_F3x1/*MF*/<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, U>/*-T1*/, Func<T1, T2, T3, T4, U>> L_Merge_A_F4x1/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, U>/*-T1*/, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x1/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x1/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Func/*GF*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T1*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x1/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1); return Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O1*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<U>/*-T2*/, Func<T1, T2, U>> L_Merge_A_Fx2/*MF*/<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { In(/*X2A*/o1, o2); return Merge(/*A*//*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, U>/*-T2*/, Func<T1, T2, T3, U>> L_Merge_A_F3x2/*MF*/<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, U>/*-T2*/, Func<T1, T2, T3, T4, U>> L_Merge_A_F4x2/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, U>/*-T2*/, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x2/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x2/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Func/*GF*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T2*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x2/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2); return Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O2*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<U>/*-T3*/, Func<T1, T2, T3, U>> L_Merge_A_Fx3/*MF*/<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*//*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, U>/*-T3*/, Func<T1, T2, T3, T4, U>> L_Merge_A_F4x3/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, U>/*-T3*/, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x3/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x3/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, T11, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Func/*GF*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T3*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x3/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3); return Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O3*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<U>/*-T4*/, Func<T1, T2, T3, T4, U>> L_Merge_A_Fx4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*//*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, U>/*-T4*/, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_F5x4/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x4/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, T11, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10, o11/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, T11, T12, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Func/*GF*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T4*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x4/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4); return Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O4*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<U>/*-T5*/, Func<T1, T2, T3, T4, T5, U>> L_Merge_A_Fx5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*//*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_F6x5/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, T11, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10, o11/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, T11, T12, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10, o11, o12/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, T11, T12, T13, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, T11, T12, T13, T14, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Func/*GF*/<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T5*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x5/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5); return Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O5*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, U>> L_Merge_A_Fx6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*//*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_F7x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, T11, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10, o11/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, T11, T12, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10, o11, o12/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, T11, T12, T13, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10, o11, o12, o13/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, T11, T12, T13, T14, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10, o11, o12, o13, o14/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Func/*GF*/<T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T6*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x6/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); return Merge(/*A*/o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O6*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Merge_A_Fx7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*//*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_F8x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, T11, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10, o11/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, T11, T12, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10, o11, o12/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, T11, T12, T13, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10, o11, o12, o13/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, T11, T12, T13, T14, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10, o11, o12, o13, o14/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, T11, T12, T13, T14, T15, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10, o11, o12, o13, o14, o15/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Func/*GF*/<T8, T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T7*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x7/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); return Merge(/*A*/o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O7*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Merge_A_Fx8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*//*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_F9x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, T11, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10, o11/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, T11, T12, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10, o11, o12/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, T11, T12, T13, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10, o11, o12, o13/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, T11, T12, T13, T14, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10, o11, o12, o13, o14/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, T11, T12, T13, T14, T15, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10, o11, o12, o13, o14, o15/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Func/*GF*/<T9, T10, T11, T12, T13, T14, T15, T16, U>/*-T8*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); return Merge(/*A*/o9, o10, o11, o12, o13, o14, o15, o16/*-O8*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Merge_A_Fx9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*//*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_F10x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, T11, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10, o11/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, T11, T12, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10, o11, o12/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, T11, T12, T13, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10, o11, o12, o13/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, T11, T12, T13, T14, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10, o11, o12, o13, o14/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, T11, T12, T13, T14, T15, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10, o11, o12, o13, o14, o15/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Func/*GF*/<T10, T11, T12, T13, T14, T15, T16, U>/*-T9*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); return Merge(/*A*/o10, o11, o12, o13, o14, o15, o16/*-O9*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Merge_A_Fx10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*//*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<T11, U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_F11x10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*/o11/*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<T11, T12, U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*/o11, o12/*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<T11, T12, T13, U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*/o11, o12, o13/*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<T11, T12, T13, T14, U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*/o11, o12, o13, o14/*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<T11, T12, T13, T14, T15, U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*/o11, o12, o13, o14, o15/*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Func/*GF*/<T11, T12, T13, T14, T15, T16, U>/*-T10*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); return Merge(/*A*/o11, o12, o13, o14, o15, o16/*-O10*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func/*GF*/<U>/*-T11*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Merge_A_Fx11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(/*A*//*-O11*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func/*GF*/<T12, U>/*-T11*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_F12x11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(/*A*/o12/*-O11*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func/*GF*/<T12, T13, U>/*-T11*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(/*A*/o12, o13/*-O11*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func/*GF*/<T12, T13, T14, U>/*-T11*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(/*A*/o12, o13, o14/*-O11*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func/*GF*/<T12, T13, T14, T15, U>/*-T11*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(/*A*/o12, o13, o14, o15/*-O11*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Func/*GF*/<T12, T13, T14, T15, T16, U>/*-T11*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); return Merge(/*A*/o12, o13, o14, o15, o16/*-O11*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func/*GF*/<U>/*-T12*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Merge_A_Fx12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(/*A*//*-O12*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func/*GF*/<T13, U>/*-T12*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_F13x12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(/*A*/o13/*-O12*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func/*GF*/<T13, T14, U>/*-T12*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(/*A*/o13, o14/*-O12*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func/*GF*/<T13, T14, T15, U>/*-T12*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(/*A*/o13, o14, o15/*-O12*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Func/*GF*/<T13, T14, T15, T16, U>/*-T12*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); return Merge(/*A*/o13, o14, o15, o16/*-O12*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func/*GF*/<U>/*-T13*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Merge_A_Fx13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(/*A*//*-O13*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func/*GF*/<T14, U>/*-T13*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_F14x13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(/*A*/o14/*-O13*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func/*GF*/<T14, T15, U>/*-T13*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(/*A*/o14, o15/*-O13*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Func/*GF*/<T14, T15, T16, U>/*-T13*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); return Merge(/*A*/o14, o15, o16/*-O13*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func/*GF*/<U>/*-T14*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Merge_A_Fx14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return Merge(/*A*//*-O14*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func/*GF*/<T15, U>/*-T14*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_F15x14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return Merge(/*A*/o15/*-O14*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Func/*GF*/<T15, T16, U>/*-T14*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); return Merge(/*A*/o15, o16/*-O14*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func/*GF*/<U>/*-T15*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Merge_A_Fx15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); return Merge(/*A*//*-O15*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Func/*GF*/<T16, U>/*-T15*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_F16x15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); return Merge(/*A*/o16/*-O15*/); };
			};
			}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Func/*GF*/<U>/*-T16*/, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Merge_A_Fx16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); return Merge(/*A*//*-O16*/); };
			};
			}
#endregion;

#region L_To
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<T1>, Action<T1>> L_To/*MA*/<T1>()
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
		public static Func<int, int, Action<T1, T2>, Action<T1, T2>> L_To2/*MA*/<T1, T2>()
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
		public static Func<int, int, Action<T1, T2, T3>, Action<T1, T2, T3>> L_To3/*MA*/<T1, T2, T3>()
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
		public static Func<int, int, Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_To4/*MA*/<T1, T2, T3, T4>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_To5/*MA*/<T1, T2, T3, T4, T5>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_To6/*MA*/<T1, T2, T3, T4, T5, T6>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_To7/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_To8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_To9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_To10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_To11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_To12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_To13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_To14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_To15/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
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
		public static Func<int, int, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_To16/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
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
		public static Func<int, int, Action<int, /*,GA*/T1>, Action<T1>> L_ToI/*MA*/<T1>()
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
						Action(i, /*,A*/o1);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2>, Action<T1, T2>> L_ToI2/*MA*/<T1, T2>()
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
						Action(i, /*,A*/o1, o2);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3>, Action<T1, T2, T3>> L_ToI3/*MA*/<T1, T2, T3>()
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
						Action(i, /*,A*/o1, o2, o3);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4>, Action<T1, T2, T3, T4>> L_ToI4/*MA*/<T1, T2, T3, T4>()
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
						Action(i, /*,A*/o1, o2, o3, o4);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5>, Action<T1, T2, T3, T4, T5>> L_ToI5/*MA*/<T1, T2, T3, T4, T5>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6>, Action<T1, T2, T3, T4, T5, T6>> L_ToI6/*MA*/<T1, T2, T3, T4, T5, T6>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7>, Action<T1, T2, T3, T4, T5, T6, T7>> L_ToI7/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_ToI8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_ToI9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_ToI10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_ToI11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_ToI12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_ToI13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_ToI14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
						}
				};
			};
			}
/// <summary>
/// Loops an Action from a to b. a and b can be any integers.
/// </summary>
		public static Func<int, int, Action<int, /*,GA*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_ToI15/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
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
						Action(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
						}
				};
			};
			}
#endregion;

#region L_For
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, bool>, Action<T1>> L_For/*MA*/<T1>()
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
						if (!Loop(i, /*,A*/o1))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, bool>, Action<T1, T2>> L_For2/*MA*/<T1, T2>()
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
						if (!Loop(i, /*,A*/o1, o2))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, bool>, Action<T1, T2, T3>> L_For3/*MA*/<T1, T2, T3>()
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
						if (!Loop(i, /*,A*/o1, o2, o3))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>> L_For4/*MA*/<T1, T2, T3, T4>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, bool>, Action<T1, T2, T3, T4, T5>> L_For5/*MA*/<T1, T2, T3, T4, T5>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, bool>, Action<T1, T2, T3, T4, T5, T6>> L_For6/*MA*/<T1, T2, T3, T4, T5, T6>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, bool>, Action<T1, T2, T3, T4, T5, T6, T7>> L_For7/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_For8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_For9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_For10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_For11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_For12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_For13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_For14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14))
							break;
						}
				};
			};
			}
/// <summary>
/// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
/// </summary>
		public static Func<int, int, Func<int, /*GA,*/T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_For15/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
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
						if (!Loop(i, /*,A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15))
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
		public static Func<Func/*GF*/<T1, U>, Action<T1>> L_Do/*MF*/<T1, U>()
			{
			return (In) =>
			{
				return (o1) => { In(o1); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, U>, Action<T1, T2>> L_Do2/*MF*/<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2) => { In(o1, o2); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, U>, Action<T1, T2, T3>> L_Do3/*MF*/<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, U>, Action<T1, T2, T3, T4>> L_Do4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, U>, Action<T1, T2, T3, T4, T5>> L_Do5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5) => { In(o1, o2, o3, o4, o5); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, U>, Action<T1, T2, T3, T4, T5, T6>> L_Do6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { In(o1, o2, o3, o4, o5, o6); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, U>, Action<T1, T2, T3, T4, T5, T6, T7>> L_Do7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { In(o1, o2, o3, o4, o5, o6, o7); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Do8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(o1, o2, o3, o4, o5, o6, o7, o8); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Do9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Do10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Do11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Do12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Do13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Do14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Do15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
			};
			}
/// <summary>
/// Returns an Action from the supplied Func. The return value is discarded.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Do16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
		public static Func<Func<T1, U>, String, Func<T1, U>> L_Cache/*MF*/<T1, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, U>, String, Func<T1, T2, U>> L_Cache2/*MF*/<T1, T2, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, U>, String, Func<T1, T2, T3, U>> L_Cache3/*MF*/<T1, T2, T3, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, U>, String, Func<T1, T2, T3, T4, U>> L_Cache4/*MF*/<T1, T2, T3, T4, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, U>, String, Func<T1, T2, T3, T4, T5, U>> L_Cache5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, U>, String, Func<T1, T2, T3, T4, T5, T6, U>> L_Cache6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Cache7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Cache8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Cache9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Cache10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Cache11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Cache12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Cache13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Cache14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Cache15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
/// <summary>
/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, String, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Cache16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			L.Cache(ref L.L_ResultCacheData,
				(/**/) => { return new Dictionary<String, Dictionary<String, L.CacheData>>(/**/); });

			return (In, CacheID) =>
			{
			Dictionary<String, L.CacheData> CacheDict = null;
			if (!L.L_ResultCacheData.ContainsKey(CacheID))
					{
					CacheDict = new Dictionary<String, L.CacheData>(/**/);
					L.L_ResultCacheData.Add(CacheID, CacheDict);
					}
				else
					{
					CacheDict = L.L_ResultCacheData[CacheID];
					}

				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16)());
					Boolean Exists = CacheDict.ContainsKey(Key);
					if (Exists)
						{
						L.CacheData CachedResult = CacheDict[Key];

						if (CachedResult.Data is U)
							{
							DateTime End = DateTime.Now;

							CachedResult.AddTime((long)(CachedResult.OriginalTimeMS - (End - Start).Ticks * DateExt.TicksToMilliseconds));

							return (U)CachedResult.Data;
							}
						}
					U Out = In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
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
		public static Func<Func<T1, T2, U>, Func<T1>, Func<T1, T2, U>> L_SetFunc_F2/*MF*/<T1, T2, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2) => { return Func(In(), o2); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, U>, Func<T1>, Func<T1, T2, T3, U>> L_SetFunc_F3/*MF*/<T1, T2, T3, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3) => { return Func(In(), o2, o3); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, U>, Func<T1>, Func<T1, T2, T3, T4, U>> L_SetFunc_F4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4) => { return Func(In(), o2, o3, o4); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, U>, Func<T1>, Func<T1, T2, T3, T4, T5, U>> L_SetFunc_F5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5) => { return Func(In(), o2, o3, o4, o5); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, U>> L_SetFunc_F6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { return Func(In(), o2, o3, o4, o5, o6); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_SetFunc_F7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { return Func(In(), o2, o3, o4, o5, o6, o7); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_SetFunc_F8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_SetFunc_F9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_SetFunc_F10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_SetFunc_F11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_SetFunc_F12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_SetFunc_F13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_SetFunc_F14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_SetFunc_F15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (Func, In) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(In(), o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with the result of In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_SetFunc_F16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
		public static Func<Func<T1, T2, U>, T1, Func<T1, T2, U>> L_Set_F2/*MF*/<T1, T2, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2) => { return Func(Obj, o2); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, U>, T1, Func<T1, T2, T3, U>> L_Set_F3/*MF*/<T1, T2, T3, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3) => { return Func(Obj, o2, o3); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, U>, T1, Func<T1, T2, T3, T4, U>> L_Set_F4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4) => { return Func(Obj, o2, o3, o4); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, U>, T1, Func<T1, T2, T3, T4, T5, U>> L_Set_F5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5) => { return Func(Obj, o2, o3, o4, o5); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T1, Func<T1, T2, T3, T4, T5, T6, U>> L_Set_F6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { return Func(Obj, o2, o3, o4, o5, o6); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set_F7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { return Func(Obj, o2, o3, o4, o5, o6, o7); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set_F8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set_F9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set_F10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set_F11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set_F12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set_F13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set_F14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set_F15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(Obj, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the first parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T1, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set_F16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
		public static Func<Func<T1, T2, T3, U>, T2, Func<T1, T2, T3, U>> L_Set2_F3/*MF*/<T1, T2, T3, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3) => { return Func(o1, Obj, o3); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, U>, T2, Func<T1, T2, T3, T4, U>> L_Set2_F4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4) => { return Func(o1, Obj, o3, o4); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, U>, T2, Func<T1, T2, T3, T4, T5, U>> L_Set2_F5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5) => { return Func(o1, Obj, o3, o4, o5); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T2, Func<T1, T2, T3, T4, T5, T6, U>> L_Set2_F6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { return Func(o1, Obj, o3, o4, o5, o6); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set2_F7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { return Func(o1, Obj, o3, o4, o5, o6, o7); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set2_F8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set2_F9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set2_F10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set2_F11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set2_F12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set2_F13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set2_F14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set2_F15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(o1, Obj, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the second parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T2, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set2_F16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
		public static Func<Func<T1, T2, T3, T4, U>, T3, Func<T1, T2, T3, T4, U>> L_Set3_F4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4) => { return Func(o1, o2, Obj, o4); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, U>, T3, Func<T1, T2, T3, T4, T5, U>> L_Set3_F5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5) => { return Func(o1, o2, Obj, o4, o5); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T3, Func<T1, T2, T3, T4, T5, T6, U>> L_Set3_F6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { return Func(o1, o2, Obj, o4, o5, o6); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set3_F7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { return Func(o1, o2, Obj, o4, o5, o6, o7); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set3_F8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set3_F9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set3_F10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set3_F11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set3_F12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set3_F13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set3_F14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set3_F15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(o1, o2, Obj, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the third parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T3, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set3_F16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
		public static Func<Func<T1, T2, T3, T4, T5, U>, T4, Func<T1, T2, T3, T4, T5, U>> L_Set4_F5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5) => { return Func(o1, o2, o3, Obj, o5); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, U>, T4, Func<T1, T2, T3, T4, T5, T6, U>> L_Set4_F6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6) => { return Func(o1, o2, o3, Obj, o5, o6); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, U>> L_Set4_F7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) => { return Func(o1, o2, o3, Obj, o5, o6, o7); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Set4_F8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Set4_F9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Set4_F10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Set4_F11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Set4_F12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Set4_F13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Set4_F14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Set4_F15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { return Func(o1, o2, o3, Obj, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); };
			};
			}
/// <summary>
/// Returns a function that sets (overrides) the fourth parameter in Func with In
/// </summary>
		public static Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, T4, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Set4_F16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
					while (Continue(/*A*/o1));
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
					while (Continue(/*A*/o1, o2));
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
					while (Continue(/*A*/o1, o2, o3));
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
					while (Continue(/*A*/o1, o2, o3, o4));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15));
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
					while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16));
				};
			};
			}
#endregion;

#region L_Until
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, U>, Func<T1, Boolean>, Func/*GF*/<T1, U>> L_Until/*MF*/<T1, U>()
			{
			return (In, Break) =>
			{
				return (o1) =>
				{
					U Out = default(U);
                    while (!Break(/*A*/o1) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, U>, Func<T1, T2, Boolean>, Func/*GF*/<T1, T2, U>> L_Until2/*MF*/<T1, T2, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, U>, Func<T1, T2, T3, Boolean>, Func/*GF*/<T1, T2, T3, U>> L_Until3/*MF*/<T1, T2, T3, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, Boolean>, Func/*GF*/<T1, T2, T3, T4, U>> L_Until4/*MF*/<T1, T2, T3, T4, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, U>> L_Until5/*MF*/<T1, T2, T3, T4, T5, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, U>> L_Until6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, U>> L_Until7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_Until8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_Until9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_Until10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_Until11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_Until12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_Until13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_Until14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_Until15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) && Out == null)
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
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_Until16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
			{
			return (In, Break) =>
			{
				return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) =>
				{
					U Out = default(U);
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) && Out == null)
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
		public static Func<Func/*GF*/<T1, U>, Func<T1, Boolean>, Func/*GF*/<T1, U>> L_DoUntil/*MF*/<T1, U>()
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
					while (!Break(/*A*/o1) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, U>, Func<T1, T2, Boolean>, Func/*GF*/<T1, T2, U>> L_DoUntil2/*MF*/<T1, T2, U>()
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
					while (!Break(/*A*/o1, o2) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, U>, Func<T1, T2, T3, Boolean>, Func/*GF*/<T1, T2, T3, U>> L_DoUntil3/*MF*/<T1, T2, T3, U>()
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
					while (!Break(/*A*/o1, o2, o3) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, Boolean>, Func/*GF*/<T1, T2, T3, T4, U>> L_DoUntil4/*MF*/<T1, T2, T3, T4, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, U>, Func<T1, T2, T3, T4, T5, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, U>> L_DoUntil5/*MF*/<T1, T2, T3, T4, T5, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, U>, Func<T1, T2, T3, T4, T5, T6, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, U>> L_DoUntil6/*MF*/<T1, T2, T3, T4, T5, T6, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, U>, Func<T1, T2, T3, T4, T5, T6, T7, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, U>> L_DoUntil7/*MF*/<T1, T2, T3, T4, T5, T6, T7, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>> L_DoUntil8/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>> L_DoUntil9/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>> L_DoUntil10/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>> L_DoUntil11/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>> L_DoUntil12/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>> L_DoUntil13/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>> L_DoUntil14/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>> L_DoUntil15/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) && Out == null);
					return Out;
				};
			};
			}
/// <summary>
/// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
/// </summary>
		public static Func<Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Boolean>, Func/*GF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>> L_DoUntil16/*MF*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, U>()
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
					while (!Break(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) && Out == null);
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
				while (Continue(/*A*/o1))
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
				while (Continue(/*A*/o1, o2))
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
				while (Continue(/*A*/o1, o2, o3))
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
				while (Continue(/*A*/o1, o2, o3, o4))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15))
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
				while (Continue(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16))
					{
					In(o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16);
					}
			};
		}
;
}
#endregion;

#region L_Merge
		public static Func<Action/*X2GA*/, Action/*GA*//*X2-TI*/, Action> L_Merge/*MA*/()
{
return (In, Merge) => { return () => { In(/*X2A*/); Merge(/*A*//*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1>/*X2-TI*/, Action<T1>> L_Merge1/*MA*/<T1>()
{
return (In, Merge) => { return (o1) => { In(/*X2A*/); Merge(/*A*/o1/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2>/*X2-TI*/, Action<T1, T2>> L_Merge2/*MA*/<T1, T2>()
{
return (In, Merge) => { return (o1, o2) => { In(/*X2A*/); Merge(/*A*/o1, o2/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3>/*X2-TI*/, Action<T1, T2, T3>> L_Merge3/*MA*/<T1, T2, T3>()
{
return (In, Merge) => { return (o1, o2, o3) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4>/*X2-TI*/, Action<T1, T2, T3, T4>> L_Merge4/*MA*/<T1, T2, T3, T4>()
{
return (In, Merge) => { return (o1, o2, o3, o4) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5>/*X2-TI*/, Action<T1, T2, T3, T4, T5>> L_Merge5/*MA*/<T1, T2, T3, T4, T5>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6>> L_Merge6/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/, Action/*GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*X2-TI*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/); Merge(/*A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*X2-OI*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*//*-T1*/, Action<T1>> L_Mergex1/*MA*/<T1>()
{
return (In, Merge) => { return (o1) => { In(/*X2A*/o1); Merge(/*A*//*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*//*-T1*/, Action<T1>> L_Merge1x1/*MA*/<T1>()
{
return (In, Merge) => { return (o1) => { In(/*X2A*/o1); Merge(/*A*//*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2>/*-T1*/, Action<T1, T2>> L_Merge2x1/*MA*/<T1, T2>()
{
return (In, Merge) => { return (o1, o2) => { In(/*X2A*/o1); Merge(/*A*/o2/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3>/*-T1*/, Action<T1, T2, T3>> L_Merge3x1/*MA*/<T1, T2, T3>()
{
return (In, Merge) => { return (o1, o2, o3) => { In(/*X2A*/o1); Merge(/*A*/o2, o3/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4>/*-T1*/, Action<T1, T2, T3, T4>> L_Merge4x1/*MA*/<T1, T2, T3, T4>()
{
return (In, Merge) => { return (o1, o2, o3, o4) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5>/*-T1*/, Action<T1, T2, T3, T4, T5>> L_Merge5x1/*MA*/<T1, T2, T3, T4, T5>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6>/*-T1*/, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x1/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x1/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1>, Action/*GA*/<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T1*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x1/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1); Merge(/*A*/o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O1*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*//*-T2*/, Action<T1, T2>> L_Mergex2/*MA*/<T1, T2>()
{
return (In, Merge) => { return (o1, o2) => { In(/*X2A*/o1, o2); Merge(/*A*//*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3>/*-T2*/, Action<T1, T2, T3>> L_Merge3x2/*MA*/<T1, T2, T3>()
{
return (In, Merge) => { return (o1, o2, o3) => { In(/*X2A*/o1, o2); Merge(/*A*/o3/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4>/*-T2*/, Action<T1, T2, T3, T4>> L_Merge4x2/*MA*/<T1, T2, T3, T4>()
{
return (In, Merge) => { return (o1, o2, o3, o4) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5>/*-T2*/, Action<T1, T2, T3, T4, T5>> L_Merge5x2/*MA*/<T1, T2, T3, T4, T5>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6>/*-T2*/, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x2/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x2/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10, T11>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2>, Action/*GA*/<T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T2*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x2/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2); Merge(/*A*/o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O2*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*//*-T3*/, Action<T1, T2, T3>> L_Mergex3/*MA*/<T1, T2, T3>()
{
return (In, Merge) => { return (o1, o2, o3) => { In(/*X2A*/o1, o2, o3); Merge(/*A*//*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4>/*-T3*/, Action<T1, T2, T3, T4>> L_Merge4x3/*MA*/<T1, T2, T3, T4>()
{
return (In, Merge) => { return (o1, o2, o3, o4) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5>/*-T3*/, Action<T1, T2, T3, T4, T5>> L_Merge5x3/*MA*/<T1, T2, T3, T4, T5>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6>/*-T3*/, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x3/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x3/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10, T11>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10, T11, T12>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3>, Action/*GA*/<T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T3*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x3/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3); Merge(/*A*/o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O3*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*//*-T4*/, Action<T1, T2, T3, T4>> L_Mergex4/*MA*/<T1, T2, T3, T4>()
{
return (In, Merge) => { return (o1, o2, o3, o4) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*//*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5>/*-T4*/, Action<T1, T2, T3, T4, T5>> L_Merge5x4/*MA*/<T1, T2, T3, T4, T5>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6>/*-T4*/, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x4/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x4/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10, T11>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10, o11/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10, T11, T12>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10, T11, T12, T13>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4>, Action/*GA*/<T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T4*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x4/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4); Merge(/*A*/o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O4*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*//*-T5*/, Action<T1, T2, T3, T4, T5>> L_Mergex5/*MA*/<T1, T2, T3, T4, T5>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*//*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6>/*-T5*/, Action<T1, T2, T3, T4, T5, T6>> L_Merge6x5/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x5/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10, T11>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10, o11/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10, T11, T12>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10, o11, o12/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10, T11, T12, T13>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10, T11, T12, T13, T14>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13, o14/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5>, Action/*GA*/<T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T5*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x5/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5); Merge(/*A*/o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O5*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*//*-T6*/, Action<T1, T2, T3, T4, T5, T6>> L_Mergex6/*MA*/<T1, T2, T3, T4, T5, T6>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*//*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Merge7x6/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10, T11>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10, o11/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10, T11, T12>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10, o11, o12/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10, T11, T12, T13>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10, o11, o12, o13/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10, T11, T12, T13, T14>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10, o11, o12, o13, o14/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10, T11, T12, T13, T14, T15>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10, o11, o12, o13, o14, o15/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6>, Action/*GA*/<T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T6*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x6/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6); Merge(/*A*/o7, o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O6*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*//*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7>> L_Mergex7/*MA*/<T1, T2, T3, T4, T5, T6, T7>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*//*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Merge8x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10, T11>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10, o11/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10, T11, T12>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10, o11, o12/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10, T11, T12, T13>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10, o11, o12, o13/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10, T11, T12, T13, T14>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10, o11, o12, o13, o14/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10, T11, T12, T13, T14, T15>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10, o11, o12, o13, o14, o15/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7>, Action/*GA*/<T8, T9, T10, T11, T12, T13, T14, T15, T16>/*-T7*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x7/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7); Merge(/*A*/o8, o9, o10, o11, o12, o13, o14, o15, o16/*-O7*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*//*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8>> L_Mergex8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*//*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Merge9x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10, T11>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10, o11/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10, T11, T12>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10, o11, o12/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10, T11, T12, T13>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10, o11, o12, o13/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10, T11, T12, T13, T14>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10, o11, o12, o13, o14/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10, T11, T12, T13, T14, T15>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10, o11, o12, o13, o14, o15/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8>, Action/*GA*/<T9, T10, T11, T12, T13, T14, T15, T16>/*-T8*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x8/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8); Merge(/*A*/o9, o10, o11, o12, o13, o14, o15, o16/*-O8*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*//*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> L_Mergex9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*//*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Merge10x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10, T11>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10, o11/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10, T11, T12>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10, o11, o12/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10, T11, T12, T13>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10, o11, o12, o13/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10, T11, T12, T13, T14>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10, o11, o12, o13, o14/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10, T11, T12, T13, T14, T15>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10, o11, o12, o13, o14, o15/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9>, Action/*GA*/<T10, T11, T12, T13, T14, T15, T16>/*-T9*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x9/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9); Merge(/*A*/o10, o11, o12, o13, o14, o15, o16/*-O9*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*//*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> L_Mergex10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*//*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*/<T11>/*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Merge11x10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*/o11/*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*/<T11, T12>/*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*/o11, o12/*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*/<T11, T12, T13>/*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*/o11, o12, o13/*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*/<T11, T12, T13, T14>/*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*/o11, o12, o13, o14/*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*/<T11, T12, T13, T14, T15>/*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*/o11, o12, o13, o14, o15/*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, Action/*GA*/<T11, T12, T13, T14, T15, T16>/*-T10*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x10/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10); Merge(/*A*/o11, o12, o13, o14, o15, o16/*-O10*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action/*GA*//*-T11*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> L_Mergex11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(/*A*//*-O11*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action/*GA*/<T12>/*-T11*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Merge12x11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(/*A*/o12/*-O11*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action/*GA*/<T12, T13>/*-T11*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(/*A*/o12, o13/*-O11*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action/*GA*/<T12, T13, T14>/*-T11*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(/*A*/o12, o13, o14/*-O11*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action/*GA*/<T12, T13, T14, T15>/*-T11*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(/*A*/o12, o13, o14, o15/*-O11*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, Action/*GA*/<T12, T13, T14, T15, T16>/*-T11*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x11/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11); Merge(/*A*/o12, o13, o14, o15, o16/*-O11*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action/*GA*//*-T12*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> L_Mergex12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(/*A*//*-O12*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action/*GA*/<T13>/*-T12*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Merge13x12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(/*A*/o13/*-O12*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action/*GA*/<T13, T14>/*-T12*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(/*A*/o13, o14/*-O12*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action/*GA*/<T13, T14, T15>/*-T12*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(/*A*/o13, o14, o15/*-O12*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>, Action/*GA*/<T13, T14, T15, T16>/*-T12*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x12/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12); Merge(/*A*/o13, o14, o15, o16/*-O12*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action/*GA*//*-T13*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> L_Mergex13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(/*A*//*-O13*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action/*GA*/<T14>/*-T13*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Merge14x13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(/*A*/o14/*-O13*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action/*GA*/<T14, T15>/*-T13*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(/*A*/o14, o15/*-O13*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>, Action/*GA*/<T14, T15, T16>/*-T13*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x13/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13); Merge(/*A*/o14, o15, o16/*-O13*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action/*GA*//*-T14*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> L_Mergex14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); Merge(/*A*//*-O14*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action/*GA*/<T15>/*-T14*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Merge15x14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); Merge(/*A*/o15/*-O14*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>, Action/*GA*/<T15, T16>/*-T14*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x14/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14); Merge(/*A*/o15, o16/*-O14*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action/*GA*//*-T15*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> L_Mergex15/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); Merge(/*A*//*-O15*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>, Action/*GA*/<T16>/*-T15*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Merge16x15/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15); Merge(/*A*/o16/*-O15*/); }; }
;
}
/// <summary>
/// Returns a function that Performs In, then Merge. Parameter lists are merged.
/// </summary>
		public static Func<Action/*X2GA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>, Action/*GA*//*-T16*/, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> L_Mergex16/*MA*/<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
{
return (In, Merge) => { return (o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16) => { In(/*X2A*/o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13, o14, o15, o16); Merge(/*A*//*-O16*/); }; }
;
}
#endregion;
#endregion
}
}
