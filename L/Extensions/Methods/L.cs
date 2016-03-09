using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using LCore.Dynamic;
using System.Linq.Expressions;

namespace LCore
	{
	public partial class L : Logic
		{
		/// <summary>
		/// Empty method. Takes no parameters and performs no actions.
		/// </summary>
		public static readonly Action E = Empty;

		#region Method Creators - Shorthand
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <returns></returns>
		public static Action A()
			{
			return L.E;
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Action<T1> A<T1>()
			{
			return L.Arg<T1>();
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		public static Action<T1, T2> A<T1, T2>()
			{
			return L.Arg<T1, T2>();
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		public static Action<T1, T2, T3> A<T1, T2, T3>()
			{
			return L.Arg<T1, T2, T3>();
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> A<T1, T2, T3, T4>()
			{
			return L.Arg<T1, T2, T3, T4>();
			}

		public static Func<U> F<U>()
			{
			return L.Do<U>();
			}

		public static Func<T1, U> F<T1, U>()
			{
			return L.Do<T1, U>();
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, T2, U> F<T1, T2, U>()
			{
			return L.Do<T1, T2, U>();
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> F<T1, T2, T3, U>()
			{
			return L.Do<T1, T2, T3, U>();
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> F<T1, T2, T3, T4, U>()
			{
			return L.Do<T1, T2, T3, T4, U>();
			}
		#endregion

		#region Method Retrievers - Shorthand
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action A(Action In)
			{
			return L.Action(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1> A<T1>(Action<T1> In)
			{
			return L.Action(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2> A<T1, T2>(Action<T1, T2> In)
			{
			return L.Action(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> A<T1, T2, T3>(Action<T1, T2, T3> In)
			{
			return L.Action(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> A<T1, T2, T3, T4>(Action<T1, T2, T3, T4> In)
			{
			return L.Action(In);
			}

		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<U> F<U>(Func<U> In)
			{
			return L.Function(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, U> F<T1, U>(Func<T1, U> In)
			{
			return L.Function(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> F<T1, T2, U>(Func<T1, T2, U> In)
			{
			return L.Function(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> F<T1, T2, T3, U>(Func<T1, T2, T3, U> In)
			{
			return L.Function(In);
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> F<T1, T2, T3, T4, U>(Func<T1, T2, T3, T4, U> In)
			{
			return L.Function(In);
			}
		#endregion
		}

	[CodeExplode_ExtendLogic("Method Extensions", "Logic_Extension", "LCore")]
	[CodeExplode_ExplodeLogic("Method Explosions", "LX", "LCore", new Type[] { typeof(Boolean) })]
	public partial class Logic
		{
		//TODO Set all static lambdas to readonly

		/// <summary>
		/// The limit for parameters was 4 in .NET 3.5 - it is now 16 with .NET 4. 
		/// Increase when CodeExplode is ready.
		/// </summary>
		public const int ParameterLimit = 4;
		public static Type[] L_Used_GenericOutputTypes = new Type[] { typeof(Boolean) };

		public static readonly Action Empty = () => { };
		
		#region Logic Lambdas +
		#region Do
		/// <summary>
		/// Returns an Action from the supplied Func. The return value is discarded.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Do", new String[] { "In" }, L.Comments.Do, false, true)]
		[CodeExplodeGenerics("Do", L.Comments.Do)]
		public static Func<Func/*GF*/<U>, Action> L_Do/*MF*/<U>()
			{
			return (In) =>
			{
				return () => { In(); };
			};
			}
		#endregion
		#region Cache
		public class CacheData
			{
			public Object Data;
			public long OriginalTimeMS;

			public List<long> TimeTakenMS = new List<long>();

			public void AddTime(long Time)
				{
				TimeTakenMS.Add(Time);
				}
			public CacheData(Object Data, long OriginalTimeMS)
				{
				this.Data = Data;
				this.OriginalTimeMS = OriginalTimeMS;
				}

			public long TotalTimeSaved
				{
				get
					{
					return OriginalTimeMS - (long)TimeTakenMS.Average();
					}
				}
			public float PercentSaved
				{
				get
					{
					return (float)1 - (float)(TimeTakenMS.Average() / OriginalTimeMS);
					}
				}
			}
		public static Dictionary<String, Dictionary<String, Object>> L_ResultCaches;
		public static Dictionary<String, Dictionary<String, CacheData>> L_ResultCacheData;

		/// <summary>
		/// Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Cache", new String[] { "In", "CacheID" }, L.Comments.Cache, false, true)]
		[CodeExplodeGenerics("Cache", L.Comments.Cache)]
		public static Func<Func<U>, String, Func<U>> L_Cache/*MF*/<U>()
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

				return () =>
				{
					DateTime Start = DateTime.Now;

					String Key = L.Objects_ToString(L.Array<Object>(/*A*/)());
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
					U Out = In();
					DateTime End2 = DateTime.Now;
					if (!Exists)
						CacheDict.Add(Key, new L.CacheData(Out, (long)((End2 - Start).Ticks * DateExt.TicksToMilliseconds)));
					return Out;
				};
			};
			}
		public static T Cache<T>(ref Object CacheStore, Func<T> Default)
			{
			if (CacheStore == null || !(CacheStore is T))
				CacheStore = Default();
			return (T)CacheStore;
			}
		public static T Cache<T>(ref T CacheStore, Func<T> Default)
			{
			if (CacheStore == null)
				CacheStore = Default();
			return CacheStore;
			}
		#endregion
		#region Set Func
		#region Set Func 1
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set", new int[] { 0 }, new String[] { "In()" }, L.Comments.SetFunc)]
		[CodeExplodeExtensionMethod("Set", new String[] { "Func", "In", }, L.Comments.SetFunc, false, true)]
		public static Func<Action<T1>, Func<T1>, Action<T1>> L_SetFunc_A<T1>()
			{
			return (Func, In) =>
			{
				return (o1) => { Func(In()); };
			};
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set", new int[] { 0 }, new String[] { "In()" }, L.Comments.SetFunc)]
		[CodeExplodeExtensionMethod("Set", new String[] { "Func", "In", }, L.Comments.SetFunc, false, true)]
		public static Func<Func<T1, U>, Func<T1>, Func<T1, U>> L_SetFunc_F/*MF*/<T1, U>()
			{
			return (Func, In) =>
			{
				return (o1) => { return Func(In()); };
			};
			}
		#endregion
		#endregion
		#region Set
		#region Set 1
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set", new int[] { 0 }, new String[] { "Obj" }, L.Comments.Set)]
		[CodeExplodeExtensionMethod("Set", new String[] { "Func", "Obj", }, L.Comments.Set, false, true)]
		public static Func<Action<T1>, T1, Action<T1>> L_Set_A<T1>()
			{
			return (Func, Obj) =>
			{
				return (o1) => { Func(Obj); };
			};
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set", new int[] { 0 }, new String[] { "Obj" }, L.Comments.Set)]
		[CodeExplodeExtensionMethod("Set", new String[] { "Func", "Obj", }, L.Comments.Set, false, true)]
		public static Func<Func<T1, U>, T1, Func<T1, U>> L_Set_F/*MF*/<T1, U>()
			{
			return (Func, Obj) =>
			{
				return (o1) => { return Func(Obj); };
			};
			}
		#endregion
		#region Set 2
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set2", new int[] { 1 }, new String[] { "Obj" }, L.Comments.Set2)]
		[CodeExplodeExtensionMethod("Set2", new String[] { "Func", "Obj", }, L.Comments.Set2, false, true)]
		public static Func<Action<T1, T2>, T2, Action<T1, T2>> L_Set2_A<T1, T2>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2) => { Func(o1, Obj); };
			};
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set2", new int[] { 1 }, new String[] { "Obj" }, L.Comments.Set2)]
		[CodeExplodeExtensionMethod("Set2", new String[] { "Func", "Obj", }, L.Comments.Set2, false, true)]
		public static Func<Func<T1, T2, U>, T2, Func<T1, T2, U>> L_Set2_F/*MF*/<T1, T2, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2) => { return Func(o1, Obj); };
			};
			}
		#endregion
		#region Set 3
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set3", new int[] { 2 }, new String[] { "Obj" }, L.Comments.Set3)]
		[CodeExplodeExtensionMethod("Set3", new String[] { "Func", "Obj", }, L.Comments.Set3, false, true)]
		public static Func<Action<T1, T2, T3>, T3, Action<T1, T2, T3>> L_Set3_A<T1, T2, T3>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3) => { Func(o1, o2, Obj); };
			};
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set3", new int[] { 2 }, new String[] { "Obj" }, L.Comments.Set3)]
		[CodeExplodeExtensionMethod("Set3", new String[] { "Func", "Obj", }, L.Comments.Set3, false, true)]
		public static Func<Func<T1, T2, T3, U>, T3, Func<T1, T2, T3, U>> L_Set3_F/*MF*/<T1, T2, T3, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3) => { return Func(o1, o2, Obj); };
			};
			}
		#endregion
		#region Set 4
		/// <summary>
		/// Returns a function that sets (overrides) the fourt parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set4", new int[] { 3 }, new String[] { "Obj" }, L.Comments.Set4)]
		[CodeExplodeExtensionMethod("Set4", new String[] { "Func", "Obj", }, L.Comments.Set4, false, true)]
		public static Func<Action<T1, T2, T3, T4>, T4, Action<T1, T2, T3, T4>> L_Set4_A<T1, T2, T3, T4>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4) => { Func(o1, o2, o3, Obj); };
			};
			}
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter in Func with In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeGenerics_ReplaceArguments("Set4", new int[] { 3 }, new String[] { "Obj" }, L.Comments.Set4)]
		[CodeExplodeExtensionMethod("Set4", new String[] { "Func", "Obj", }, L.Comments.Set4, false, true)]
		public static Func<Func<T1, T2, T3, T4, U>, T4, Func<T1, T2, T3, T4, U>> L_Set4_F/*MF*/<T1, T2, T3, T4, U>()
			{
			return (Func, Obj) =>
			{
				return (o1, o2, o3, o4) => { return Func(o1, o2, o3, Obj); };
			};
			}
		#endregion
		#endregion
		//Explode
		#region Arg A0
		/// <summary>
		/// Returns a new function with an added argument of Type T1
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T1")]
		public static Func<Action, Action<T1>> L_Arg_A0<T1>()
			{
			return (In) => { return (o) => { In(); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Type T1, T2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added arguments of Type T1, T2")]
		public static Func<Action, Action<T1, T2>> L_Arg_A0<T1, T2>()
			{
			return (In) => { return (o1, o2) => { In(); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Type T1, T2, T3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added arguments of Type T1, T2, T3")]
		public static Func<Action, Action<T1, T2, T3>> L_Arg_A0<T1, T2, T3>()
			{
			return (In) => { return (o1, o2, o3) => { In(); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Type T1, T2, T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added arguments of Type T1, T2, T3, T4")]
		public static Func<Action, Action<T1, T2, T3, T4>> L_Arg_A0<T1, T2, T3, T4>()
			{
			return (In) => { return (o1, o2, o3, o4) => { In(); }; };
			}
		#endregion
		#region Arg A1
		/// <summary>
		/// Returns a new function with an added argument of Type T2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T2")]
		public static Func<Action<T1>, Action<T1, T2>> L_Arg_A1<T1, T2>()
			{
			return (In) => { return (o1, o2) => { In(o1); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T2, T3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added arguments of Type T2, T3")]
		public static Func<Action<T1>, Action<T1, T2, T3>> L_Arg_A1<T1, T2, T3>()
			{
			return (In) => { return (o1, o2, o3) => { In(o1); }; };
			}
		/// <summary>
		/// Returns a new function with an added argument Types T2, T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added arguments of Type T2, T3, T4")]
		public static Func<Action<T1>, Action<T1, T2, T3, T4>> L_Arg_A1<T1, T2, T3, T4>()
			{
			return (In) => { return (o1, o2, o3, o4) => { In(o1); }; };
			}
		#endregion
		#region Arg A2
		/// <summary>
		/// Returns a new function with an added argument Type T3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T3")]
		public static Func<Action<T1, T2>, Action<T1, T2, T3>> L_Arg_A2<T1, T2, T3>()
			{
			return (In) => { return (o1, o2, o3) => { In(o1, o2); }; };
			}
		/// <summary>
		/// Returns a new function with an added argument Types T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added arguments of Type T3, T4")]
		public static Func<Action<T1, T2>, Action<T1, T2, T3, T4>> L_Arg_A2<T1, T2, T3, T4>()
			{
			return (In) => { return (o1, o2, o3, o4) => { In(o1, o2); }; };
			}
		#endregion
		#region Arg A3
		/// <summary>
		/// Returns a new function with an added argument Type T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T4")]
		public static Func<Action<T1, T2, T3>, Action<T1, T2, T3, T4>> L_Arg_A3<T1, T2, T3, T4>()
			{
			return (In) => { return (o1, o2, o3, o4) => { In(o1, o2, o3); }; };
			}
		#endregion
		#region Arg F0
		/// <summary>
		/// Returns a new function with an added argument of Type T1
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T1")]
		public static Func<Func<U>, Func<T1, U>> L_Arg_F0<T1, U>()
			{
			return (In) => { return (o) => { return In(); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T1, T2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with added arguments of Types T1, T2")]
		public static Func<Func<U>, Func<T1, T2, U>> L_Arg_F0<T1, T2, U>()
			{
			return (In) => { return (o1, o2) => { return In(); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T1, T2, T3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with added arguments of Types T1, T2, T3")]
		public static Func<Func<U>, Func<T1, T2, T3, U>> L_Arg_F0<T1, T2, T3, U>()
			{
			return (In) => { return (o1, o2, o3) => { return In(); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T1, T2, T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with added arguments of Types T1, T2, T3, T4")]
		public static Func<Func<U>, Func<T1, T2, T3, T4, U>> L_Arg_F0<T1, T2, T3, T4, U>()
			{
			return (In) => { return (o1, o2, o3, o4) => { return In(); }; };
			}
		#endregion
		#region Arg F1
		/// <summary>
		/// Returns a new function with an added argument of Type T2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T2")]
		public static Func<Func<T1, U>, Func<T1, T2, U>> L_Arg_F1<T1, T2, U>()
			{
			return (In) => { return (o1, o2) => { return In(o1); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T2, T3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with added arguments of Types T2, T3")]
		public static Func<Func<T1, U>, Func<T1, T2, T3, U>> L_Arg_F1<T1, T2, T3, U>()
			{
			return (In) => { return (o1, o2, o3) => { return In(o1); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T2, T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", "Returns a new function with added arguments of Types T2, T3, T4")]
		public static Func<Func<T1, U>, Func<T1, T2, T3, T4, U>> L_Arg_F1<T1, T2, T3, T4, U>()
			{
			return (In) => { return (o1, o2, o3, o4) => { return In(o1); }; };
			}
		#endregion
		#region Arg F2
		/// <summary>
		/// Returns a new function with an added argument of Type T3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T3")]
		public static Func<Func<T1, T2, U>, Func<T1, T2, T3, U>> L_Arg_F2<T1, T2, T3, U>()
			{
			return (In) => { return (o1, o2, o3) => { return In(o1, o2); }; };
			}
		/// <summary>
		/// Returns a new function with added arguments of Types T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with added arguments of Types T3, T4")]
		public static Func<Func<T1, T2, U>, Func<T1, T2, T3, T4, U>> L_Arg_F2<T1, T2, T3, T4, U>()
			{
			return (In) => { return (o1, o2, o3, o4) => { return In(o1, o2); }; };
			}
		#endregion
		#region Arg F3
		/// <summary>
		/// Returns a new function with an added argument of Type T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Arg", new String[] { "In" }, "Returns a new function with an added argument of Type T4")]
		public static Func<Func<T1, T2, T3, U>, Func<T1, T2, T3, T4, U>> L_Arg_F3<T1, T2, T3, T4, U>()
			{
			return (In) => { return (o1, o2, o3, o4) => { return In(o1, o2, o3); }; };
			}
		#endregion
		#region Return
		/// <summary>
		/// Returns a function that converts an action to a Func, returning the specified value.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Action, U, Func<U>> L_Return_A<U>()
			{
			return (In, Obj) => { return () => { In(); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that converts an action to a Func, returning the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Action<T1>, U, Func<T1, U>> L_Return_A<T1, U>()
			{
			return (In, Obj) => { return (o1) => { In(o1); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that converts an action to a Func, returning the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Action<T1, T2>, U, Func<T1, T2, U>> L_Return_A<T1, T2, U>()
			{
			return (In, Obj) => { return (o1, o2) => { In(o1, o2); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that converts an action to a Func, returning the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Action<T1, T2, T3>, U, Func<T1, T2, T3, U>> L_Return_A<T1, T2, T3, U>()
			{
			return (In, Obj) => { return (o1, o2, o3) => { In(o1, o2, o3); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that converts an action to a Func, returning the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Action<T1, T2, T3, T4>, U, Func<T1, T2, T3, T4, U>> L_Return_A<T1, T2, T3, T4, U>()
			{
			return (In, Obj) => { return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that Overrides the return value of In with the specified value.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return_Func)]
		public static Func<Func<U>, U, Func<U>> L_Return_F<U>()
			{
			return (In, Obj) => { return () => { In(); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that Overrides the return value of In with the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Func<T1, U>, U, Func<T1, U>> L_Return_F<T1, U>()
			{
			return (In, Obj) => { return (o1) => { In(o1); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that Overrides the return value of In with the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Func<T1, T2, U>, U, Func<T1, T2, U>> L_Return_F<T1, T2, U>()
			{
			return (In, Obj) => { return (o1, o2) => { In(o1, o2); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that Overrides the return value of In with the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Func<T1, T2, T3, U>, U, Func<T1, T2, T3, U>> L_Return_F<T1, T2, T3, U>()
			{
			return (In, Obj) => { return (o1, o2, o3) => { In(o1, o2, o3); return Obj; }; };
			}
		/// <summary>
		/// Returns a function that Overrides the return value of In with the specified value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Return", new String[] { "In", "Obj = default(U)" }, L.Comments.Return)]
		public static Func<Func<T1, T2, T3, T4, U>, U, Func<T1, T2, T3, T4, U>> L_Return_F<T1, T2, T3, T4, U>()
			{
			return (In, Obj) => { return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return Obj; }; };
			}
		#endregion
		#region Rotate
		/// <summary>
		/// Returns a function that rotates the list of parameters to the right.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Rotate", new String[] { "In" }, L.Comments.Rotate)]
		public static Func<Action<T1, T2>, Action<T2, T1>> L_Rotate_A<T1, T2>()
			{
			return (In) => { return (o1, o2) => { In(o2, o1); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the right.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Rotate", new String[] { "In" }, L.Comments.Rotate)]
		public static Func<Action<T1, T2, T3>, Action<T3, T1, T2>> L_Rotate_A<T1, T2, T3>()
			{
			return (In) => { return (o3, o1, o2) => { In(o1, o2, o3); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the right.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Rotate", new String[] { "In" }, L.Comments.Rotate)]
		public static Func<Action<T1, T2, T3, T4>, Action<T4, T1, T2, T3>> L_Rotate_A<T1, T2, T3, T4>()
			{
			return (In) => { return (o4, o1, o2, o3) => { In(o1, o2, o3, o4); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the right.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Rotate", new String[] { "In" }, L.Comments.Rotate)]
		public static Func<Func<T1, T2, U>, Func<T2, T1, U>> L_Rotate_F<T1, T2, U>()
			{
			return (In) => { return (o2, o1) => { return In(o1, o2); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the right.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Rotate", new String[] { "In" }, L.Comments.Rotate)]
		public static Func<Func<T1, T2, T3, U>, Func<T3, T1, T2, U>> L_Rotate_F<T1, T2, T3, U>()
			{
			return (In) => { return (o3, o1, o2) => { return In(o1, o2, o3); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the right.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Rotate", new String[] { "In" }, L.Comments.Rotate)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<T4, T1, T2, T3, U>> L_Rotate_F<T1, T2, T3, T4, U>()
			{
			return (In) => { return (o4, o1, o2, o3) => { return In(o1, o2, o3, o4); }; };
			}
		#endregion
		#region RotateBack
		/// <summary>
		/// Returns a function that rotates the list of parameters to the left.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RotateBack", new String[] { "In" }, L.Comments.RotateBack)]
		public static Func<Action<T1, T2>, Action<T2, T1>> L_RotateBack_A<T1, T2>()
			{
			return (In) => { return (o1, o2) => { In(o2, o1); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the left.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		public static Func<Action<T1, T2, T3>, Action<T2, T3, T1>> L_RotateBack_A<T1, T2, T3>()
			{
			return (In) => { return (o1, o2, o3) => { In(o3, o1, o2); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the left.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		public static Func<Action<T1, T2, T3, T4>, Action<T2, T3, T4, T1>> L_RotateBack_A<T1, T2, T3, T4>()
			{
			return (In) => { return (o1, o2, o3, o4) => { In(o4, o1, o2, o3); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the left.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, T2, U>, Func<T2, T1, U>> L_RotateBack_F<T1, T2, U>()
			{
			return (In) => { return (o1, o2) => { return In(o2, o1); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the left.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, T2, T3, U>, Func<T2, T3, T1, U>> L_RotateBack_F<T1, T2, T3, U>()
			{
			return (In) => { return (o2, o3, o1) => { return In(o1, o2, o3); }; };
			}
		/// <summary>
		/// Returns a function that rotates the list of parameters to the left.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, T2, T3, T4, U>, Func<T2, T3, T4, T1, U>> L_RotateBack_F<T1, T2, T3, T4, U>()
			{
			return (In) => { return (o2, o3, o4, o1) => { return In(o1, o2, o3, o4); }; };
			}
		#endregion
		#region Default
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Action<T1>, T1, Action<T1>> L_Default_A<T1>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					In(o1);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Action<T1, T2>, T1, Action<T1, T2>> L_Default_A<T1, T2>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1, o2) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					In(o1, o2);
				};
			};
			}
		/// <summary>
		/// If the second argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default2", new String[] { "In", "Default" }, L.Comments.Default2)]
		public static Func<Action<T1, T2>, T2, Action<T1, T2>> L_Default2_A<T1, T2>()
			{
			return (In, Default2) =>
			{
				Func<T2, Boolean> NullFunc = L.IsNull<T2>();
				return (o1, o2) =>
				{
					if (NullFunc(o2))
						{
						o2 = Default2;
						}
					In(o1, o2);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Action<T1, T2, T3>, T1, Action<T1, T2, T3>> L_Default_A<T1, T2, T3>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the second argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default2", new String[] { "In", "Default2" }, L.Comments.Default2)]
		public static Func<Action<T1, T2, T3>, T2, Action<T1, T2, T3>> L_Default2_A<T1, T2, T3>()
			{
			return (In, Default2) =>
			{
				Func<T2, Boolean> NullFunc = L.IsNull<T2>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o2))
						{
						o2 = Default2;
						}
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the third argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default3", new String[] { "In", "Default3" }, L.Comments.Default3)]
		public static Func<Action<T1, T2, T3>, T3, Action<T1, T2, T3>> L_Default3_A<T1, T2, T3>()
			{
			return (In, Default3) =>
			{
				Func<T3, Boolean> NullFunc = L.IsNull<T3>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o3))
						{
						o3 = Default3;
						}
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Action<T1, T2, T3, T4>, T1, Action<T1, T2, T3, T4>> L_Default_A<T1, T2, T3, T4>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the second argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default2", new String[] { "In", "Default2" }, L.Comments.Default2)]
		public static Func<Action<T1, T2, T3, T4>, T2, Action<T1, T2, T3, T4>> L_Default2_A<T1, T2, T3, T4>()
			{
			return (In, Default2) =>
			{
				Func<T2, Boolean> NullFunc = L.IsNull<T2>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o2))
						{
						o2 = Default2;
						}
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the third argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default3", new String[] { "In", "Default3" }, L.Comments.Default3)]
		public static Func<Action<T1, T2, T3, T4>, T3, Action<T1, T2, T3, T4>> L_Default3_A<T1, T2, T3, T4>()
			{
			return (In, Default3) =>
			{
				Func<T3, Boolean> NullFunc = L.IsNull<T3>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o3))
						{
						o3 = Default3;
						}
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the fourth argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default4", new String[] { "In", "Default4" }, L.Comments.Default4)]
		public static Func<Action<T1, T2, T3, T4>, T4, Action<T1, T2, T3, T4>> L_Default4_A<T1, T2, T3, T4>()
			{
			return (In, Default4) =>
			{
				Func<T4, Boolean> NullFunc = L.IsNull<T4>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o4))
						{
						o4 = Default4;
						}
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Func<T1, U>, T1, Func<T1, U>> L_Default_F<T1, U>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					return In(o1);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Func<T1, T2, U>, T1, Func<T1, T2, U>> L_Default_F<T1, T2, U>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1, o2) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					return In(o1, o2);
				};
			};
			}
		/// <summary>
		/// If the second argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default2", new String[] { "In", "Default2" }, L.Comments.Default2)]
		public static Func<Func<T1, T2, U>, T2, Func<T1, T2, U>> L_Default2_F<T1, T2, U>()
			{
			return (In, Default) =>
			{
				Func<T2, Boolean> NullFunc = L.IsNull<T2>();
				return (o1, o2) =>
				{
					if (NullFunc(o2))
						{
						o2 = Default;
						}
					return In(o1, o2);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Func<T1, T2, T3, U>, T1, Func<T1, T2, T3, U>> L_Default_F<T1, T2, T3, U>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the second argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default2", new String[] { "In", "Default2" }, L.Comments.Default2)]
		public static Func<Func<T1, T2, T3, U>, T2, Func<T1, T2, T3, U>> L_Default2_F<T1, T2, T3, U>()
			{
			return (In, Default) =>
			{
				Func<T2, Boolean> NullFunc = L.IsNull<T2>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o2))
						{
						o2 = Default;
						}
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the third argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default3", new String[] { "In", "Default3" }, L.Comments.Default3)]
		public static Func<Func<T1, T2, T3, U>, T3, Func<T1, T2, T3, U>> L_Default3_F<T1, T2, T3, U>()
			{
			return (In, Default) =>
			{
				Func<T3, Boolean> NullFunc = L.IsNull<T3>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o3))
						{
						o3 = Default;
						}
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the first argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default", new String[] { "In", "Default" }, L.Comments.Default)]
		public static Func<Func<T1, T2, T3, T4, U>, T1, Func<T1, T2, T3, T4, U>> L_Default_F<T1, T2, T3, T4, U>()
			{
			return (In, Default) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o1))
						{
						o1 = Default;
						}
					return In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the second argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default2", new String[] { "In", "Default2" }, L.Comments.Default2)]
		public static Func<Func<T1, T2, T3, T4, U>, T2, Func<T1, T2, T3, T4, U>> L_Default2_F<T1, T2, T3, T4, U>()
			{
			return (In, Default) =>
			{
				Func<T2, Boolean> NullFunc = L.IsNull<T2>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o2))
						{
						o2 = Default;
						}
					return In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the third argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default3", new String[] { "In", "Default3" }, L.Comments.Default3)]
		public static Func<Func<T1, T2, T3, T4, U>, T3, Func<T1, T2, T3, T4, U>> L_Default3_F<T1, T2, T3, T4, U>()
			{
			return (In, Default) =>
			{
				Func<T3, Boolean> NullFunc = L.IsNull<T3>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o3))
						{
						o3 = Default;
						}
					return In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the fourth argument passed is null or empty, the Default value is used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Default4", new String[] { "In", "Default4" }, L.Comments.Default4)]
		public static Func<Func<T1, T2, T3, T4, U>, T4, Func<T1, T2, T3, T4, U>> L_Default4_F<T1, T2, T3, T4, U>()
			{
			return (In, Default) =>
			{
				Func<T4, Boolean> NullFunc = L.IsNull<T4>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o4))
						{
						o4 = Default;
						}
					return In(o1, o2, o3, o4);
				};
			};
			}
		#endregion
		#region Defaults
		/// <summary>
		/// If the arguments passed are null or empty, the Default values are used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Defaults", new String[] { "In", "Default", "Default2" }, L.Comments.Defaults)]
		public static Func<Action<T1, T2>, T1, T2, Action<T1, T2>> L_Defaults_A<T1, T2>()
			{
			return (In, Default, Default2) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				Func<T2, Boolean> NullFunc2 = L.IsNull<T2>();
				return (o1, o2) =>
				{
					if (NullFunc(o1))
						o1 = Default;
					if (NullFunc2(o2))
						o2 = Default2;
					In(o1, o2);
				};
			};
			}
		/// <summary>
		/// If the arguments passed are null or empty, the Default values are used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Defaults", new String[] { "In", "Default", "Default2", "Default3" }, L.Comments.Defaults)]
		public static Func<Action<T1, T2, T3>, T1, T2, T3, Action<T1, T2, T3>> L_Defaults_A<T1, T2, T3>()
			{
			return (In, Default, Default2, Default3) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				Func<T2, Boolean> NullFunc2 = L.IsNull<T2>();
				Func<T3, Boolean> NullFunc3 = L.IsNull<T3>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o1))
						o1 = Default;
					if (NullFunc2(o2))
						o2 = Default2;
					if (NullFunc3(o3))
						o3 = Default3;
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the arguments passed are null or empty, the Default values are used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Defaults", new String[] { "In", "Default", "Default2", "Default3", "Default4" }, L.Comments.Defaults)]
		public static Func<Action<T1, T2, T3, T4>, T1, T2, T3, T4, Action<T1, T2, T3, T4>> L_Defaults_A<T1, T2, T3, T4>()
			{
			return (In, Default, Default2, Default3, Default4) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				Func<T2, Boolean> NullFunc2 = L.IsNull<T2>();
				Func<T3, Boolean> NullFunc3 = L.IsNull<T3>();
				Func<T4, Boolean> NullFunc4 = L.IsNull<T4>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o1))
						o1 = Default;
					if (NullFunc2(o2))
						o2 = Default2;
					if (NullFunc3(o3))
						o3 = Default3;
					if (NullFunc4(o4))
						o4 = Default4;
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// If the arguments passed are null or empty, the Default values are used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Defaults", new String[] { "In", "Default", "Default2" }, L.Comments.Defaults)]
		public static Func<Func<T1, T2, U>, T1, T2, Func<T1, T2, U>> L_Defaults_F<T1, T2, U>()
			{
			return (In, Default, Default2) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				Func<T2, Boolean> NullFunc2 = L.IsNull<T2>();
				return (o1, o2) =>
				{
					if (NullFunc(o1))
						o1 = Default;
					if (NullFunc2(o2))
						o2 = Default2;
					return In(o1, o2);
				};
			};
			}
		/// <summary>
		/// If the arguments passed are null or empty, the Default values are used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Defaults", new String[] { "In", "Default", "Default2", "Default3" }, L.Comments.Defaults)]
		public static Func<Func<T1, T2, T3, U>, T1, T2, T3, Func<T1, T2, T3, U>> L_Defaults_F<T1, T2, T3, U>()
			{
			return (In, Default, Default2, Default3) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				Func<T2, Boolean> NullFunc2 = L.IsNull<T2>();
				Func<T3, Boolean> NullFunc3 = L.IsNull<T3>();
				return (o1, o2, o3) =>
				{
					if (NullFunc(o1))
						o1 = Default;
					if (NullFunc2(o2))
						o2 = Default2;
					if (NullFunc3(o3))
						o3 = Default3;
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// If the arguments passed are null or empty, the Default values are used instead.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Defaults", new String[] { "In", "Default", "Default2", "Default3", "Default4" }, L.Comments.Defaults)]
		public static Func<Func<T1, T2, T3, T4, U>, T1, T2, T3, T4, Func<T1, T2, T3, T4, U>> L_Defaults_F<T1, T2, T3, T4, U>()
			{
			return (In, Default, Default2, Default3, Default4) =>
			{
				Func<T1, Boolean> NullFunc = L.IsNull<T1>();
				Func<T2, Boolean> NullFunc2 = L.IsNull<T2>();
				Func<T3, Boolean> NullFunc3 = L.IsNull<T3>();
				Func<T4, Boolean> NullFunc4 = L.IsNull<T4>();
				return (o1, o2, o3, o4) =>
				{
					if (NullFunc(o1))
						o1 = Default;
					if (NullFunc2(o2))
						o2 = Default2;
					if (NullFunc3(o3))
						o3 = Default3;
					if (NullFunc4(o4))
						o4 = Default4;
					return In(o1, o2, o3, o4);
				};
			};
			}
		#endregion
		#region Require
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Action<T1>, String, Action<T1>> L_Require_A<T1>()
			{
			return (In, ParameterName) =>
			{
				return (o1) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					In(o1);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Action<T1, T2>, String, Action<T1, T2>> L_Require_A<T1, T2>()
			{
			return (In, ParameterName) =>
			{
				return (o1, o2) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					In(o1, o2);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require2", new String[] { "In", "ParameterName2 = null" }, L.Comments.Require2)]
		public static Func<Action<T1, T2>, String, Action<T1, T2>> L_Require2_A<T1, T2>()
			{
			return (In, ParameterName2) =>
			{
				return (o1, o2) =>
				{
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					In(o1, o2);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Action<T1, T2, T3>, String, Action<T1, T2, T3>> L_Require_A<T1, T2, T3>()
			{
			return (In, ParameterName) =>
			{
				return (o1, o2, o3) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require2", new String[] { "In", "ParameterName2 = null" }, L.Comments.Require2)]
		public static Func<Action<T1, T2, T3>, String, Action<T1, T2, T3>> L_Require2_A<T1, T2, T3>()
			{
			return (In, ParameterName2) =>
			{
				return (o1, o2, o3) =>
				{
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require3", new String[] { "In", "ParameterName3 = null" }, L.Comments.Require3)]
		public static Func<Action<T1, T2, T3>, String, Action<T1, T2, T3>> L_Require3_A<T1, T2, T3>()
			{
			return (In, ParameterName3) =>
			{
				return (o1, o2, o3) =>
				{
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Action<T1, T2, T3, T4>, String, Action<T1, T2, T3, T4>> L_Require_A<T1, T2, T3, T4>()
			{
			return (In, ParameterName) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require2", new String[] { "In", "ParameterName2 = null" }, L.Comments.Require2)]
		public static Func<Action<T1, T2, T3, T4>, String, Action<T1, T2, T3, T4>> L_Require2_A<T1, T2, T3, T4>()
			{
			return (In, ParameterName2) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require3", new String[] { "In", "ParameterName3 = null" }, L.Comments.Require3)]
		public static Func<Action<T1, T2, T3, T4>, String, Action<T1, T2, T3, T4>> L_Require3_A<T1, T2, T3, T4>()
			{
			return (In, ParameterName3) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the fourth parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require4", new String[] { "In", "ParameterName4 = null" }, L.Comments.Require4)]
		public static Func<Action<T1, T2, T3, T4>, String, Action<T1, T2, T3, T4>> L_Require4_A<T1, T2, T3, T4>()
			{
			return (In, ParameterName4) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o4 == null)
						throw new ArgumentNullException(ParameterName4 ?? "Parameter 4 - " + typeof(T4).Name);
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Func<T1, U>, String, Func<T1, U>> L_Require_F<T1, U>()
			{
			return (In, ParameterName) =>
			{
				return (o1) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					return In(o1);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Func<T1, T2, U>, String, Func<T1, T2, U>> L_Require_F<T1, T2, U>()
			{
			return (In, ParameterName) =>
			{
				return (o1, o2) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					return In(o1, o2);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require2", new String[] { "In", "ParameterName2 = null" }, L.Comments.Require2)]
		public static Func<Func<T1, T2, U>, String, Func<T1, T2, U>> L_Require2_F<T1, T2, U>()
			{
			return (In, ParameterName2) =>
			{
				return (o1, o2) =>
				{
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					return In(o1, o2);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Func<T1, T2, T3, U>, String, Func<T1, T2, T3, U>> L_Require_F<T1, T2, T3, U>()
			{
			return (In, ParameterName) =>
			{
				return (o1, o2, o3) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require2", new String[] { "In", "ParameterName2 = null" }, L.Comments.Require2)]
		public static Func<Func<T1, T2, T3, U>, String, Func<T1, T2, T3, U>> L_Require2_F<T1, T2, T3, U>()
			{
			return (In, ParameterName2) =>
			{
				return (o1, o2, o3) =>
				{
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require3", new String[] { "In", "ParameterName3 = null" }, L.Comments.Require3)]
		public static Func<Func<T1, T2, T3, U>, String, Func<T1, T2, T3, U>> L_Require3_F<T1, T2, T3, U>()
			{
			return (In, ParameterName3) =>
			{
				return (o1, o2, o3) =>
				{
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require", new String[] { "In", "ParameterName = null" }, L.Comments.Require)]
		public static Func<Func<T1, T2, T3, T4, U>, String, Func<T1, T2, T3, T4, U>> L_Require_F<T1, T2, T3, T4, U>()
			{
			return (In, ParameterName) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					return In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the second parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require2", new String[] { "In", "ParameterName2 = null" }, L.Comments.Require2)]
		public static Func<Func<T1, T2, T3, T4, U>, String, Func<T1, T2, T3, T4, U>> L_Require2_F<T1, T2, T3, T4, U>()
			{
			return (In, ParameterName2) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					return In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the third parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require3", new String[] { "In", "ParameterName3 = null" }, L.Comments.Require3)]
		public static Func<Func<T1, T2, T3, T4, U>, String, Func<T1, T2, T3, T4, U>> L_Require3_F<T1, T2, T3, T4, U>()
			{
			return (In, ParameterName3) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					return In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires the fourth parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Require4", new String[] { "In", "ParameterName4 = null" }, L.Comments.Require4)]
		public static Func<Func<T1, T2, T3, T4, U>, String, Func<T1, T2, T3, T4, U>> L_Require4_F<T1, T2, T3, T4, U>()
			{
			return (In, ParameterName4) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o4 == null)
						throw new ArgumentNullException(ParameterName4 ?? "Parameter 4 - " + typeof(T4).Name);
					return In(o1, o2, o3, o4);
				};
			};
			}
		#endregion
		#region RequireAll
		/// <summary>
		/// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RequireAll", new String[] { "In", "ParameterName = null", "ParameterName2 = null" }, L.Comments.RequireAll)]
		public static Func<Action<T1, T2>, String, String, Action<T1, T2>> L_RequireAll_A<T1, T2>()
			{
			return (In, ParameterName, ParameterName2) =>
			{
				return (o1, o2) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					In(o1, o2);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RequireAll", new String[] { "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null" }, L.Comments.RequireAll)]
		public static Func<Action<T1, T2, T3>, String, String, String, Action<T1, T2, T3>> L_RequireAll_A<T1, T2, T3>()
			{
			return (In, ParameterName, ParameterName2, ParameterName3) =>
			{
				return (o1, o2, o3) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RequireAll", new String[] { "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null", "ParameterName4 = null" }, L.Comments.RequireAll)]
		public static Func<Action<T1, T2, T3, T4>, String, String, String, String, Action<T1, T2, T3, T4>> L_RequireAll_A<T1, T2, T3, T4>()
			{
			return (In, ParameterName, ParameterName2, ParameterName3, ParameterName4) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					if (o4 == null)
						throw new ArgumentNullException(ParameterName4 ?? "Parameter 4 - " + typeof(T4).Name);
					In(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RequireAll", new String[] { "In", "ParameterName = null", "ParameterName2 = null" }, L.Comments.RequireAll)]
		public static Func<Func<T1, T2, U>, String, String, Func<T1, T2, U>> L_RequireAll_F<T1, T2, U>()
			{
			return (In, ParameterName, ParameterName2) =>
			{
				return (o1, o2) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					return In(o1, o2);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RequireAll", new String[] { "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null" }, L.Comments.RequireAll)]
		public static Func<Func<T1, T2, T3, U>, String, String, String, Func<T1, T2, T3, U>> L_RequireAll_F<T1, T2, T3, U>()
			{
			return (In, ParameterName, ParameterName2, ParameterName3) =>
			{
				return (o1, o2, o3) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					return In(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// Returns a method that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("RequireAll", new String[] { "In", "ParameterName = null", "ParameterName2 = null", "ParameterName3 = null", "ParameterName4 = null" }, L.Comments.RequireAll)]
		public static Func<Func<T1, T2, T3, T4, U>, String, String, String, String, Func<T1, T2, T3, T4, U>> L_RequireAll_F<T1, T2, T3, T4, U>()
			{
			return (In, ParameterName, ParameterName2, ParameterName3, ParameterName4) =>
			{
				return (o1, o2, o3, o4) =>
				{
					if (o1 == null)
						throw new ArgumentNullException(ParameterName ?? "Parameter 1 - " + typeof(T1).Name);
					if (o2 == null)
						throw new ArgumentNullException(ParameterName2 ?? "Parameter 2 - " + typeof(T2).Name);
					if (o3 == null)
						throw new ArgumentNullException(ParameterName3 ?? "Parameter 3 - " + typeof(T3).Name);
					if (o4 == null)
						throw new ArgumentNullException(ParameterName4 ?? "Parameter 4 - " + typeof(T4).Name);
					return In(o1, o2, o3, o4);
				};
			};
			}
		#endregion
		#region Yield
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Action<U>, Func<U, U>> L_Yield_A<U>()
			{
			return (In) =>
			{
				return (o) => { In(o); return o; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Action<U, T1>, Func<U, T1, U>> L_Yield_A<T1, U>()
			{
			return (In) =>
			{
				return (o1, o2) => { In(o1, o2); return o1; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the second parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield2", new String[] { "In" }, L.Comments.Yield2)]
		public static Func<Action<T1, U>, Func<T1, U, U>> L_Yield2_A<T1, U>()
			{
			return (In) =>
			{
				return (o1, o2) => { In(o1, o2); return o2; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Action<U, T1, T2>, Func<U, T1, T2, U>> L_Yield_A<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return o1; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the second parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield2", new String[] { "In" }, L.Comments.Yield2)]
		public static Func<Action<T1, U, T2>, Func<T1, U, T2, U>> L_Yield2_A<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return o2; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the third parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield3", new String[] { "In" }, L.Comments.Yield3)]
		public static Func<Action<T1, T2, U>, Func<T1, T2, U, U>> L_Yield3_A<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return o3; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Action<U, T1, T2, T3>, Func<U, T1, T2, T3, U>> L_Yield_A<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o1; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the second parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield2", new String[] { "In" }, L.Comments.Yield2)]
		public static Func<Action<T1, U, T2, T3>, Func<T1, U, T2, T3, U>> L_Yield2_A<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o2; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the third parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield3", new String[] { "In" }, L.Comments.Yield3)]
		public static Func<Action<T1, T2, U, T3>, Func<T1, T2, U, T3, U>> L_Yield3_A<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o3; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the fourth parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield4", new String[] { "In" }, L.Comments.Yield4)]
		public static Func<Action<T1, T2, T3, U>, Func<T1, T2, T3, U, U>> L_Yield4_A<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o4; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Func<U, U>, Func<U, U>> L_Yield_F<U>()
			{
			return (In) =>
			{
				return (o) => { In(o); return o; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Func<U, T1, U>, Func<U, T1, U>> L_Yield_F<T1, U>()
			{
			return (In) =>
			{
				return (o1, o2) => { In(o1, o2); return o1; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the second parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield2", new String[] { "In" }, L.Comments.Yield2)]
		public static Func<Func<T1, U, U>, Func<T1, U, U>> L_Yield2_F<T1, U>()
			{
			return (In) =>
			{
				return (o1, o2) => { In(o1, o2); return o2; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Func<U, T1, T2, U>, Func<U, T1, T2, U>> L_Yield_F<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return o1; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the second parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield2", new String[] { "In" }, L.Comments.Yield2)]
		public static Func<Func<T1, U, T2, U>, Func<T1, U, T2, U>> L_Yield2_F<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return o2; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the third parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield3", new String[] { "In" }, L.Comments.Yield3)]
		public static Func<Func<T1, T2, U, U>, Func<T1, T2, U, U>> L_Yield3_F<T1, T2, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return o3; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the first parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield", new String[] { "In" }, L.Comments.Yield)]
		public static Func<Func<U, T1, T2, T3, U>, Func<U, T1, T2, T3, U>> L_Yield_F<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o1; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the second parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield2", new String[] { "In" }, L.Comments.Yield2)]
		public static Func<Func<T1, U, T2, T3, U>, Func<T1, U, T2, T3, U>> L_Yield2_F<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o2; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the third parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield3", new String[] { "In" }, L.Comments.Yield3)]
		public static Func<Func<T1, T2, U, T3, U>, Func<T1, T2, U, T3, U>> L_Yield3_F<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o3; };
			};
			}
		/// <summary>
		/// Takes an Action and returns a Func that returns the fourth parameter after the action is performed.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Yield4", new String[] { "In" }, L.Comments.Yield4)]
		public static Func<Func<T1, T2, T3, U, U>, Func<T1, T2, T3, U, U>> L_Yield4_F<T1, T2, T3, U>()
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return o4; };
			};
			}
		#endregion
		#region Execute
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Action>, Action> L_Execute_A()
			{
			return (Act) =>
			{
				return () =>
				{
					Act()();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Action<T1>>, Action<T1>> L_Execute_A<T1>()
			{
			return (Act) =>
			{
				return (o1) =>
				{
					Act()(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Action<T1, T2>>, Action<T1, T2>> L_Execute_A<T1, T2>()
			{
			return (Act) =>
			{
				return (o1, o2) =>
				{
					Act()(o1, o2);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Action<T1, T2, T3>>, Action<T1, T2, T3>> L_Execute_A<T1, T2, T3>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					Act()(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Action<T1, T2, T3, T4>>, Action<T1, T2, T3, T4>> L_Execute_A<T1, T2, T3, T4>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					Act()(o1, o2, o3, o4);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Func<U>>, Func<U>> L_Execute_F<U>()
			{
			return (Act) =>
			{
				return () =>
				{
					return Act()();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Func<T1, U>>, Func<T1, U>> L_Execute_F<T1, U>()
			{
			return (Act) =>
			{
				return (o1) =>
				{
					return Act()(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Func<T1, T2, U>>, Func<T1, T2, U>> L_Execute_F<T1, T2, U>()
			{
			return (Act) =>
			{
				return (o1, o2) =>
				{
					return Act()(o1, o2);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Func<T1, T2, T3, U>>, Func<T1, T2, T3, U>> L_Execute_F<T1, T2, T3, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					return Act()(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.Execute)]
		public static Func<Func<Func<T1, T2, T3, T4, U>>, Func<T1, T2, T3, T4, U>> L_Execute_F<T1, T2, T3, T4, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					return Act()(o1, o2, o3, o4);
				};
			};
			}
		#endregion
		#region Execute2
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, Action>, Action<T1>> L_Execute2_A<T1>()
			{
			return (Act) =>
			{
				return (o1) =>
				{
					Act(o1)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T2, Action<T1>>, Action<T1, T2>> L_Execute2_A<T1, T2>()
			{
			return (Act) =>
			{
				return (o1, o2) =>
				{
					Act(o2)(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T3, Action<T1, T2>>, Action<T1, T2, T3>> L_Execute2_A<T1, T2, T3>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					Act(o3)(o1, o2);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T4, Action<T1, T2, T3>>, Action<T1, T2, T3, T4>> L_Execute2_A<T1, T2, T3, T4>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					Act(o4)(o1, o2, o3);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, Func<U>>, Func<T1, U>> L_Execute2_F<T1, U>()
			{
			return (Act) =>
			{
				return (o1) =>
				{
					return Act(o1)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T2, Func<T1, U>>, Func<T1, T2, U>> L_Execute2_F<T1, T2, U>()
			{
			return (Act) =>
			{
				return (o1, o2) =>
				{
					return Act(o2)(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T3, Func<T1, T2, U>>, Func<T1, T2, T3, U>> L_Execute2_F<T1, T2, T3, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					return Act(o3)(o1, o2);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T4, Func<T1, T2, T3, U>>, Func<T1, T2, T3, T4, U>> L_Execute2_F<T1, T2, T3, T4, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					return Act(o4)(o1, o2, o3);
				};
			};
			}
		#endregion
		#region Execute3
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, T2, Action>, Action<T1, T2>> L_Execute3_A<T1, T2>()
			{
			return (Act) =>
			{
				return (o1, o2) =>
				{
					Act(o1, o2)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T2, T3, Action<T1>>, Action<T1, T2, T3>> L_Execute3_A<T1, T2, T3>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					Act(o2, o3)(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T3, T4, Action<T1, T2>>, Action<T1, T2, T3, T4>> L_Execute3_A<T1, T2, T3, T4>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					Act(o3, o4)(o1, o2);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, T2, Func<U>>, Func<T1, T2, U>> L_Execute3_F<T1, T2, U>()
			{
			return (Act) =>
			{
				return (o1, o2) =>
				{
					return Act(o1, o2)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T2, T3, Func<T1, U>>, Func<T1, T2, T3, U>> L_Execute3_F<T1, T2, T3, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					return Act(o2, o3)(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T3, T4, Func<T1, T2, U>>, Func<T1, T2, T3, T4, U>> L_Execute3_F<T1, T2, T3, T4, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					return Act(o3, o4)(o1, o2);
				};
			};
			}
		#endregion
		#region Execute4
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, T2, T3, Action>, Action<T1, T2, T3>> L_Execute4_A<T1, T2, T3>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					Act(o1, o2, o3)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T2, T3, T4, Action<T1>>, Action<T1, T2, T3, T4>> L_Execute4_A<T1, T2, T3, T4>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					Act(o2, o3, o4)(o1);
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, T2, T3, Func<U>>, Func<T1, T2, T3, U>> L_Execute4_F<T1, T2, T3, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3) =>
				{
					return Act(o1, o2, o3)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T2, T3, T4, Func<T1, U>>, Func<T1, T2, T3, T4, U>> L_Execute4_F<T1, T2, T3, T4, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					return Act(o2, o3, o4)(o1);
				};
			};
			}
		#endregion
		#region Execute5
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, T2, T3, T4, Action>, Action<T1, T2, T3, T4>> L_Execute5_A<T1, T2, T3, T4>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					Act(o1, o2, o3, o4)();
				};
			};
			}
		/// <summary>
		/// For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Execute", new String[] { "Act" }, L.Comments.ExecuteMerge)]
		public static Func<Func<T1, T2, T3, T4, Func<U>>, Func<T1, T2, T3, T4, U>> L_Execute5_F<T1, T2, T3, T4, U>()
			{
			return (Act) =>
			{
				return (o1, o2, o3, o4) =>
				{
					return Act(o1, o2, o3, o4)();
				};
			};
			}
		#endregion

		#region Cast
		/// <summary>
		/// Returns a function that takes a Casts the paramater of the Action to U1
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <returns></returns>
		public static Func<Action<T1>, Action<U1>> L_Cast_A<T1, U1>()
			where U1 : T1
			{
			return (In) =>
			{
				return (o) => { In(o); };
			};
			}
		/// <summary>
		/// Returns a function that takes a Casts the paramaters of the Action to U1, U2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <returns></returns>
		public static Func<Action<T1, T2>, Action<U1, U2>> L_Cast_A<T1, T2, U1, U2>()
			where U1 : T1
			where U2 : T2
			{
			return (In) =>
			{
				return (o1, o2) => { In(o1, o2); };
			};
			}
		/// <summary>
		/// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <typeparam name="U3"></typeparam>
		/// <returns></returns>
		public static Func<Action<T1, T2, T3>, Action<U1, U2, U3>> L_Cast_A<T1, T2, T3, U1, U2, U3>()
			where U1 : T1
			where U2 : T2
			where U3 : T3
			{
			return (In) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3, U4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <typeparam name="U3"></typeparam>
		/// <typeparam name="U4"></typeparam>
		/// <returns></returns>
		public static Func<Action<T1, T2, T3, T4>, Action<U1, U2, U3, U4>> L_Cast_A<T1, T2, T3, T4, U1, U2, U3, U4>()
			where U1 : T1
			where U2 : T2
			where U3 : T3
			where U4 : T4
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); };
			};
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2
		/// </summary>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <returns></returns>
		public static Func<Func<U1>, Func<U2>> L_Cast_F<U1, U2>()
			{
			return (In) =>
			{
				return () => { return (U2)(Object)In(); };
			};
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the input to T2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, U1>, Func<T2, U2>> L_Cast_F<T1, U1, T2, U2>()
			where T2 : T1
			where U2 : U1
			{
			return (In) =>
			{
				return (o1) => { return (U2)In(o1); };
			};
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the inputs to T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, T2, U1>, Func<T3, T4, U2>> L_Cast_F<T1, T2, U1, T3, T4, U2>()
			where T3 : T1
			where T4 : T2
			where U2 : U1
			{
			return (In) =>
			{
				return (o1, o2) => { return (U2)In(o1, o2); };
			};
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the inputs to T4, T5, T6
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, T2, T3, U1>, Func<T4, T5, T6, U2>> L_Cast_F<T1, T2, T3, U1, T4, T5, T6, U2>()
			where T4 : T1
			where T5 : T2
			where T6 : T3
			where U2 : U1
			{
			return (In) =>
			{
				return (o1, o2, o3) => { return (U2)In(o1, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the inputs to T7, T8, T9
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		/// <typeparam name="T7"></typeparam>
		/// <typeparam name="T8"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <returns></returns>
		public static Func<Func<T1, T2, T3, T4, U1>, Func<T5, T6, T7, T8, U2>> L_Cast_F<T1, T2, T3, T4, U1, T5, T6, T7, T8, U2>()
			where T5 : T1
			where T6 : T2
			where T7 : T3
			where T8 : T4
			where U2 : U1
			{
			return (In) =>
			{
				return (o1, o2, o3, o4) => { return (U2)In(o1, o2, o3, o4); };
			};
			}
		#endregion
		#region Then
		/// <summary>
		/// Joins two methods together, performing one then another.
		/// </summary>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "Act" }, L.Comments.Then)]
		public static readonly Func<Action, Action, Action> L_Then = (a, b) => { return () => { a(); b(); }; };

		/// <summary>
		/// Joins multiple actions together, performing them in order.
		/// </summary>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action, Action[], Action> L_Then_A()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = L.L_Then(In, a); }); ;
				return In;
			};
			}
		/// <summary>
		/// Joins multiple actions together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1>, Action<T1>[], Action<T1>> L_Then_A<T1>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o) => { In(o); a(o); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1, T2>, Action<T1, T2>[], Action<T1, T2>> L_Then_A<T1, T2>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { In(o1, o2); a(o1, o2); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple actions together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1, T2, T3>, Action<T1, T2, T3>[], Action<T1, T2, T3>> L_Then_A<T1, T2, T3>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); a(o1, o2, o3); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3, T4>[], Action<T1, T2, T3, T4>> L_Then_A<T1, T2, T3, T4>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); a(o1, o2, o3, o4); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action, Func<U>[], Func<U>> L_Then_A_F<U>()
			{
			return (In, Acts) =>
			{
				return In.Return<U>().Then<U>(Acts);
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1>, Func<T1, U>[], Func<T1, U>> L_Then_A_F<T1, U>()
			{
			return (In, Acts) =>
			{
				return In.Return<T1, U>().Then<T1, U>(Acts);
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1, T2>, Func<T1, T2, U>[], Func<T1, T2, U>> L_Then_A_F<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				return In.Return<T1, T2, U>().Then<T1, T2, U>(Acts);
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1, T2, T3>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, U>> L_Then_A_F<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				return In.Return<T1, T2, T3, U>().Then<T1, T2, T3, U>(Acts);
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, U>[], Func<T1, T2, T3, T4, U>> L_Then_A_F<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				return In.Return<T1, T2, T3, T4, U>().Then<T1, T2, T3, T4, U>(Acts);
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<U>, Action[], Func<U>> L_Then_F<U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = () => { U Out = In(); a(); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, U>, Action<T1>[], Func<T1, U>> L_Then_F<T1, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1) => { U Out = In(o1); a(o1); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, T2, U>, Action<T1, T2>[], Func<T1, T2, U>> L_Then_F<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { U Out = In(o1, o2); a(o1, o2); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, T2, T3, U>, Action<T1, T2, T3>[], Func<T1, T2, T3, U>> L_Then_F<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { U Out = In(o1, o2, o3); a(o1, o2, o3); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2, T3, T4>[], Func<T1, T2, T3, T4, U>> L_Then_F<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { U Out = In(o1, o2, o3, o4); a(o1, o2, o3, o4); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<U>, Func<U>[], Func<U>> L_Then_F_F<U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = () => { In(); return a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, U>, Func<T1, U>[], Func<T1, U>> L_Then_F_F<T1, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, U> Out = In;
				Acts.Each((a) => { Out = (o1) => { Out(o1); return a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, T2, U>, Func<T1, T2, U>[], Func<T1, T2, U>> L_Then_F_F<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { In(o1, o2); return a(o1, o2); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, T2, T3, U>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, U>> L_Then_F_F<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); return a(o1, o2, o3); }; });
				return In;
			};
			}
		/// <summary>
		/// Joins multiple methods together, performing them in order. The last operation in the list's result will be the final return value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Multiple)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>[], Func<T1, T2, T3, T4, U>> L_Then_F_F<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1, o2, o3, o4); }; });
				return In;
			};
			}
		#endregion
		#region Then - Missing
		#region Then - Missing - Action - Action
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1>, Action[], Action<T1>> L_ThenMissing_A<T1>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o) => { In(o); a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2>, Action<T1>[], Action<T1, T2>> L_ThenMissing_A<T1, T2>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { In(o1, o2); a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2>, Action[], Action<T1, T2>> L_ThenMissing_A2<T1, T2>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { In(o1, o2); a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3>, Action<T1, T2>[], Action<T1, T2, T3>> L_ThenMissing_A<T1, T2, T3>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); a(o1, o2); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3>, Action<T1>[], Action<T1, T2, T3>> L_ThenMissing_A2<T1, T2, T3>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3>, Action[], Action<T1, T2, T3>> L_ThenMissing_A3<T1, T2, T3>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3, T4>, Action<T1, T2, T3>[], Action<T1, T2, T3, T4>> L_ThenMissing_A<T1, T2, T3, T4>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); a(o1, o2, o3); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3, T4>, Action<T1, T2>[], Action<T1, T2, T3, T4>> L_ThenMissing_A2<T1, T2, T3, T4>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); a(o1, o2); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3, T4>, Action<T1>[], Action<T1, T2, T3, T4>> L_ThenMissing_A3<T1, T2, T3, T4>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Action<T1, T2, T3, T4>, Action[], Action<T1, T2, T3, T4>> L_ThenMissing_A4<T1, T2, T3, T4>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); a(); }; });
				return In;
			};
			}
		#endregion
		#region Then - Missing - Action - Func
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1>, Func<U>[], Func<T1, U>> L_ThenMissing_A_F<T1, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, U> Out = In.Return<T1, U>();
				Acts.Each((a) => { Out = (o1) => { In(o1); return a(); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2>, Func<T1, U>[], Func<T1, T2, U>> L_ThenMissing_A_F<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, U> Out = In.Return<T1, T2, U>();
				Acts.Each((a) => { Out = (o1, o2) => { In(o1, o2); return a(o1); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3>, Func<T1, T2, U>[], Func<T1, T2, T3, U>> L_ThenMissing_A_F<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, U> Out = In.Return<T1, T2, T3, U>();
				Acts.Each((a) => { Out = (o1, o2, o3) => { In(o1, o2, o3); return a(o1, o2); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2>, Func<U>[], Func<T1, T2, U>> L_ThenMissing_A_F2<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, U> Out = In.Return<T1, T2, U>();
				Acts.Each((a) => { Out = (o1, o2) => { In(o1, o2); return a(); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3>, Func<U>[], Func<T1, T2, T3, U>> L_ThenMissing_A_F3<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, U> Out = In.Return<T1, T2, T3, U>();
				Acts.Each((a) => { Out = (o1, o2, o3) => { In(o1, o2, o3); return a(); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3>, Func<T1, U>[], Func<T1, T2, T3, U>> L_ThenMissing_A_F2<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, U> Out = In.Return<T1, T2, T3, U>();
				Acts.Each((a) => { Out = (o1, o2, o3) => { In(o1, o2, o3); return a(o1); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
				Acts.Each((a) => { Out = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1, o2, o3); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F2<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
				Acts.Each((a) => { Out = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1, o2); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3, T4>, Func<T1, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F3<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
				Acts.Each((a) => { Out = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1); }; });
				return Out;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Action<T1, T2, T3, T4>, Func<U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_A_F4<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Func<T1, T2, T3, T4, U> Out = In.Return<T1, T2, T3, T4, U>();
				Acts.Each((a) => { Out = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(); }; });
				return Out;
			};
			}
		#endregion
		#region Then - Missing - Func - Action
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, U>, Action[], Func<T1, U>> L_ThenMissing_F_A<T1, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o) => { U Out = In(o); a(); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, U>, Action<T1>[], Func<T1, T2, U>> L_ThenMissing_F_A<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { U Out = In(o1, o2); a(o1); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, U>, Action[], Func<T1, T2, U>> L_ThenMissing_F_A2<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { U Out = In(o1, o2); a(); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, U>, Action<T1, T2>[], Func<T1, T2, T3, U>> L_ThenMissing_F_A<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { U Out = In(o1, o2, o3); a(o1, o2); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, U>, Action<T1>[], Func<T1, T2, T3, U>> L_ThenMissing_F_A2<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { U Out = In(o1, o2, o3); a(o1); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, U>, Action[], Func<T1, T2, T3, U>> L_ThenMissing_F_A3<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { U Out = In(o1, o2, o3); a(); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2, T3>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { U Out = In(o1, o2, o3, o4); a(o1, o2, o3); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, T4, U>, Action<T1, T2>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A2<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { U Out = In(o1, o2, o3, o4); a(o1, o2); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, T4, U>, Action<T1>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A3<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { U Out = In(o1, o2, o3, o4); a(o1); return Out; }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing)]
		public static Func<Func<T1, T2, T3, T4, U>, Action[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_A4<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { U Out = In(o1, o2, o3, o4); a(); return Out; }; });
				return In;
			};
			}
		#endregion
		#region Then - Missing - Func - Func
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, U>, Func<U>[], Func<T1, U>> L_ThenMissing_F_F<T1, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o) => { In(o); return a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, U>, Func<T1, U>[], Func<T1, T2, U>> L_ThenMissing_F_F<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { In(o1, o2); return a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, U>, Func<U>[], Func<T1, T2, U>> L_ThenMissing_F_F2<T1, T2, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2) => { In(o1, o2); return a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, U>, Func<T1, U>[], Func<T1, T2, T3, U>> L_ThenMissing_F_F2<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); return a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, U>, Func<U>[], Func<T1, T2, T3, U>> L_ThenMissing_F_F3<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); return a(); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, U>, Func<T1, T2, U>[], Func<T1, T2, T3, U>> L_ThenMissing_F_F<T1, T2, T3, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3) => { In(o1, o2, o3); return a(o1, o2); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1, o2, o3); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<T1, T2, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F2<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1, o2); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<T1, U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F3<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(o1); }; });
				return In;
			};
			}
		/// <summary>
		/// Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Then", new String[] { "In", "params Acts" }, L.Comments.Then_Missing_Func)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<U>[], Func<T1, T2, T3, T4, U>> L_ThenMissing_F_F4<T1, T2, T3, T4, U>()
			{
			return (In, Acts) =>
			{
				Acts.Each((a) => { In = (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return a(); }; });
				return In;
			};
			}
		#endregion
		#endregion
		#region Merge

		public static Func<Func/*X2GF*/<U>, Action/*GA*//*X2-TI*/, Func<U>> TestMultiSplode/*MF*/<U>()
			{
			return (In, Merge) =>
			{
				return () => { U Out = In(/*X2A*/); Merge(/*A*//*X2-OI*/); return Out; };
			};
			}

		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge, false, true)]
		[CodeExplodeGenerics("Merge", L.Comments.Merge)]
		public static readonly Func<Action/*X2GA*/, Action/*GA*//*X2-TI*/, Action> L_Merge/*MA*/ = (In, Merge) => { return () => { In(/*X2A*/); Merge(/*A*//*X2-OI*/); }; };
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge, false, true)]
		[CodeExplodeGenerics("Merge", L.Comments.Merge)]
		public static Func<Action/*X2GA*/, Func/*GF*/<U>/*X2-TI*/, Func<U>> L_Merge_A_F/*MF*/<U>()
			{
			return (In, Merge) =>
			{
				return () => { In(/*X2A*/); return Merge(/*A*//*X2-OI*/); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Action, Func<U>> L_Merge_F_A<U>()
			{
			return (In, Merge) =>
			{
				return () => { U Out = In(); Merge(); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Action<T1>, Func<T1, U>> L_Merge_F_A1<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o) => { U Out = In(); Merge(o); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Action<T1, T2>, Func<T1, T2, U>> L_Merge_F_A2<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { U Out = In(); Merge(o1, o2); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Action<T1, T2, T3>, Func<T1, T2, T3, U>> L_Merge_F_A3<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { U Out = In(); Merge(o1, o2, o3); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, U>> L_Merge_F_A4<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { U Out = In(); Merge(o1, o2, o3, o4); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Action, Func<T1, U>> L_Merge_F1_A<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o1) => { U Out = In(o1); Merge(); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Action<T2>, Func<T1, T2, U>> L_Merge_F1_A1<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { U Out = In(o1); Merge(o2); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Action<T2, T3>, Func<T1, T2, T3, U>> L_Merge_F1_A2<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { U Out = In(o1); Merge(o2, o3); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Action<T2, T3, T4>, Func<T1, T2, T3, T4, U>> L_Merge_F1_A3<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { U Out = In(o1); Merge(o2, o3, o4); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, U>, Action, Func<T1, T2, U>> L_Merge_F2_A<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { U Out = In(o1, o2); Merge(); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, U>, Action<T3>, Func<T1, T2, T3, U>> L_Merge_F2_A1<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { U Out = In(o1, o2); Merge(o3); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, U>, Action<T3, T4>, Func<T1, T2, T3, T4, U>> L_Merge_F2_A2<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { U Out = In(o1, o2); Merge(o3, o4); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, T3, U>, Action, Func<T1, T2, T3, U>> L_Merge_F3_A<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { U Out = In(o1, o2, o3); Merge(); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, T3, U>, Action<T4>, Func<T1, T2, T3, T4, U>> L_Merge_F3_A1<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { U Out = In(o1, o2, o3); Merge(o4); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, T3, T4, U>, Action, Func<T1, T2, T3, T4, U>> L_Merge_F3_A<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { U Out = In(o1, o2, o3, o4); Merge(); return Out; };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Func<U>, Func<U>> L_Merge_F_F<U>()
			{
			return (In, Merge) =>
			{
				return () => { In(); return Merge(); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Func<T1, U>, Func<T1, U>> L_Merge_F_F1<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o1) => { In(); return Merge(o1); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Func<T1, T2, U>, Func<T1, T2, U>> L_Merge_F_F2<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { In(); return Merge(o1, o2); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Func<T1, T2, T3, U>, Func<T1, T2, T3, U>> L_Merge_F_F3<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(); return Merge(o1, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<U>, Func<T1, T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F_F4<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(); return Merge(o1, o2, o3, o4); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Func<U>, Func<T1, U>> L_Merge_F1_F<T1, U>()
			{
			return (In, Merge) =>
			{
				return (o1) => { In(o1); return Merge(); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Func<T3, U>, Func<T1, T3, U>> L_Merge_F1_F1<T1, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { In(o1); return Merge(o2); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Func<T3, T4, U>, Func<T1, T3, T4, U>> L_Merge_F1_F2<T1, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(o1); return Merge(o2, o3); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, U>, Func<T2, T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F1_F3<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(o1); return Merge(o2, o3, o4); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, U>, Func<U>, Func<T1, T2, U>> L_Merge_F2_F<T1, T2, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2) => { In(o1, o2); return Merge(); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, U>, Func<T4, U>, Func<T1, T2, T4, U>> L_Merge_F2_F1<T1, T2, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(o1, o2); return Merge(o3); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, U>, Func<T3, T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F2_F2<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2); return Merge(o3, o4); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, T3, U>, Func<U>, Func<T1, T2, T3, U>> L_Merge_F3_F<T1, T2, T3, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3); return Merge(); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, T3, U>, Func<T4, U>, Func<T1, T2, T3, T4, U>> L_Merge_F3_F1<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3); return Merge(o4); };
			};
			}
		/// <summary>
		/// Returns a function that Performs In, then Merge. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Merge", new String[] { "In", "Merge" }, L.Comments.Merge)]
		public static Func<Func<T1, T2, T3, T4, U>, Func<U>, Func<T1, T2, T3, T4, U>> L_Merge_F4_F<T1, T2, T3, T4, U>()
			{
			return (In, Merge) =>
			{
				return (o1, o2, o3, o4) => { In(o1, o2, o3, o4); return Merge(); };
			};
			}
		#endregion
		#region Supply
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Action<T1>, T1, Action> L_Supply_A<T1>()
			{
			return (In, Obj) =>
			{
				return () => { In(Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Action<T1, T2>, T1, Action<T2>> L_Supply_A<T1, T2>()
			{
			return (In, Obj) =>
			{
				return (o) => { In(Obj, o); };
			};
			}
		/// <summary>
		/// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj" }, L.Comments.Supply_2)]
		public static Func<Action<T1, T2>, T2, Action<T1>> L_Supply_A2<T1, T2>()
			{
			return (In, Obj) =>
			{
				return (o) => { In(o, Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Action<T1, T2, T3>, T1, Action<T2, T3>> L_Supply_A<T1, T2, T3>()
			{
			return (In, Obj) =>
			{
				return (o1, o2) => { In(Obj, o1, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj" }, L.Comments.Supply_2)]
		public static Func<Action<T1, T2, T3>, T2, Action<T1, T3>> L_Supply_A2<T1, T2, T3>()
			{
			return (In, Obj) =>
			{
				return (o1, o2) => { In(o1, Obj, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply3", new String[] { "In", "Obj" }, L.Comments.Supply_3)]
		public static Func<Action<T1, T2, T3>, T3, Action<T1, T2>> L_Supply_A3<T1, T2, T3>()
			{
			return (In, Obj) =>
			{
				return (o1, o2) => { In(o1, o2, Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Action<T1, T2, T3, T4>, T1, Action<T2, T3, T4>> L_Supply_A<T1, T2, T3, T4>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { In(Obj, o1, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj" }, L.Comments.Supply_2)]
		public static Func<Action<T1, T2, T3, T4>, T2, Action<T1, T3, T4>> L_Supply_A2<T1, T2, T3, T4>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { In(o1, Obj, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply3", new String[] { "In", "Obj" }, L.Comments.Supply_3)]
		public static Func<Action<T1, T2, T3, T4>, T3, Action<T1, T2, T4>> L_Supply_A3<T1, T2, T3, T4>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { In(o1, o2, Obj, o3); };
			};
			}
		/// <summary>
		/// Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply4", new String[] { "In", "Obj" }, L.Comments.Supply_4)]
		public static Func<Action<T1, T2, T3, T4>, T4, Action<T1, T2, T3>> L_Supply_A4<T1, T2, T3, T4>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { In(o1, o2, o3, Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Func<T1, U>, T1, Func<U>> L_Supply_F<T1, U>()
			{
			return (In, Obj) =>
			{
				return () => { return In(Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Func<T1, T2, U>, T1, Func<T2, U>> L_Supply_F<T1, T2, U>()
			{
			return (In, Obj) =>
			{
				return (o) => { return In(Obj, o); };
			};
			}
		/// <summary>
		/// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj" }, L.Comments.Supply_2)]
		public static Func<Func<T1, T2, U>, T2, Func<T1, U>> L_Supply_F2<T1, T2, U>()
			{
			return (In, Obj) =>
			{
				return (o) => { return In(o, Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Func<T1, T2, T3, U>, T1, Func<T2, T3, U>> L_Supply_F<T1, T2, T3, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2) => { return In(Obj, o1, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj" }, L.Comments.Supply_2)]
		public static Func<Func<T1, T2, T3, U>, T2, Func<T1, T3, U>> L_Supply_F2<T1, T2, T3, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2) => { return In(o1, Obj, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply3", new String[] { "In", "Obj" }, L.Comments.Supply_3)]
		public static Func<Func<T1, T2, T3, U>, T3, Func<T1, T2, U>> L_Supply_F3<T1, T2, T3, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2) => { return In(o1, o2, Obj); };
			};
			}
		/// <summary>
		/// Returns a method with the first parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj" }, L.Comments.Supply)]
		public static Func<Func<T1, T2, T3, T4, U>, T1, Func<T2, T3, T4, U>> L_Supply_F<T1, T2, T3, T4, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { return In(Obj, o1, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a method with the second parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj" }, L.Comments.Supply_2)]
		public static Func<Func<T1, T2, T3, T4, U>, T2, Func<T1, T3, T4, U>> L_Supply_F2<T1, T2, T3, T4, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { return In(o1, Obj, o2, o3); };
			};
			}
		/// <summary>
		/// Returns a method with the third parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply3", new String[] { "In", "Obj" }, L.Comments.Supply_3)]
		public static Func<Func<T1, T2, T3, T4, U>, T3, Func<T1, T2, T4, U>> L_Supply_F3<T1, T2, T3, T4, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { return In(o1, o2, Obj, o3); };
			};
			}
		/// <summary>
		/// Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply4", new String[] { "In", "Obj" }, L.Comments.Supply_4)]
		public static Func<Func<T1, T2, T3, T4, U>, T4, Func<T1, T2, T3, U>> L_Supply_F4<T1, T2, T3, T4, U>()
			{
			return (In, Obj) =>
			{
				return (o1, o2, o3) => { return In(o1, o2, o3, Obj); };
			};
			}
		#endregion
		#region Supply 2
		/// <summary>
		/// Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2)]
		public static Func<Action<T1, T2>, T1, T2, Action> L_Supply2_A<T1, T2>()
			{
			return (In, Obj, Obj2) =>
			{
				return () => { In(Obj, Obj2); };
			};
			}
		/// <summary>
		/// Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2)]
		public static Func<Action<T1, T2, T3>, T1, T2, Action<T3>> L_Supply2_A<T1, T2, T3>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1) => { In(Obj, Obj2, o1); };
			};
			}
		/// <summary>
		/// Returns a method with the second two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2_2)]
		public static Func<Action<T1, T2, T3>, T2, T3, Action<T1>> L_Supply2_A2<T1, T2, T3>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1) => { In(o1, Obj, Obj2); };
			};
			}
		/// <summary>
		/// Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2)]
		public static Func<Action<T1, T2, T3, T4>, T1, T2, Action<T3, T4>> L_Supply2_A<T1, T2, T3, T4>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1, o2) => { In(Obj, Obj2, o1, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the second two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2_2)]
		public static Func<Action<T1, T2, T3, T4>, T2, T3, Action<T1, T4>> L_Supply2_A2<T1, T2, T3, T4>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1, o2) => { In(o1, Obj, Obj2, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the third two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply3", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2_3)]
		public static Func<Action<T1, T2, T3, T4>, T3, T4, Action<T1, T2>> L_Supply2_A3<T1, T2, T3, T4>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1, o2) => { In(o1, o2, Obj, Obj2); };
			};
			}
		/// <summary>
		/// Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2)]
		public static Func<Func<T1, T2, U>, T1, T2, Func<U>> L_Supply2_F<T1, T2, U>()
			{
			return (In, Obj, Obj2) =>
			{
				return () => { return In(Obj, Obj2); };
			};
			}
		/// <summary>
		/// Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2)]
		public static Func<Func<T1, T2, T3, U>, T1, T2, Func<T3, U>> L_Supply2_F<T1, T2, T3, U>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1) => { return In(Obj, Obj2, o1); };
			};
			}
		/// <summary>
		/// Returns a method with the second two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2_2)]
		public static Func<Func<T1, T2, T3, U>, T2, T3, Func<T1, U>> L_Supply2_F2<T1, T2, T3, U>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1) => { return In(o1, Obj, Obj2); };
			};
			}
		/// <summary>
		/// Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2)]
		public static Func<Func<T1, T2, T3, T4, U>, T1, T2, Func<T3, T4, U>> L_Supply2_F<T1, T2, T3, T4, U>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1, o2) => { return In(Obj, Obj2, o1, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the second two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2_2)]
		public static Func<Func<T1, T2, T3, T4, U>, T2, T3, Func<T1, T4, U>> L_Supply2_F2<T1, T2, T3, T4, U>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1, o2) => { return In(o1, Obj, Obj2, o2); };
			};
			}
		/// <summary>
		/// Returns a method with the third two parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply3", new String[] { "In", "Obj", "Obj2" }, L.Comments.Supply2_3)]
		public static Func<Func<T1, T2, T3, T4, U>, T3, T4, Func<T1, T2, U>> L_Supply2_F3<T1, T2, T3, T4, U>()
			{
			return (In, Obj, Obj2) =>
			{
				return (o1, o2) => { return In(o1, o2, Obj, Obj2); };
			};
			}
		#endregion
		#region Supply 3
		/// <summary>
		/// Returns a method with the first three parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2", "Obj3" }, L.Comments.Supply3)]
		public static Func<Action<T1, T2, T3>, T1, T2, T3, Action> L_Supply3_A<T1, T2, T3>()
			{
			return (In, Obj, Obj2, Obj3) =>
			{
				return () => { In(Obj, Obj2, Obj3); };
			};
			}
		/// <summary>
		/// Returns a method with the first three parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2", "Obj3" }, L.Comments.Supply3)]
		public static Func<Action<T1, T2, T3, T4>, T1, T2, T3, Action<T4>> L_Supply3_A<T1, T2, T3, T4>()
			{
			return (In, Obj, Obj2, Obj3) =>
			{
				return (o1) => { In(Obj, Obj2, Obj3, o1); };
			};
			}
		/// <summary>
		/// Returns a method with the second three parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj", "Obj2", "Obj3" }, L.Comments.Supply3_2)]
		public static Func<Action<T1, T2, T3, T4>, T2, T3, T4, Action<T1>> L_Supply3_A2<T1, T2, T3, T4>()
			{
			return (In, Obj, Obj2, Obj3) =>
			{
				return (o1) => { In(o1, Obj, Obj2, Obj3); };
			};
			}
		/// <summary>
		/// Returns a method with the first three parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2", "Obj3" }, L.Comments.Supply3)]
		public static Func<Func<T1, T2, T3, U>, T1, T2, T3, Func<U>> L_Supply3_F<T1, T2, T3, U>()
			{
			return (In, Obj, Obj2, Obj3) =>
			{
				return () => { return In(Obj, Obj2, Obj3); };
			};
			}
		/// <summary>
		/// Returns a method with the first three parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2", "Obj3" }, L.Comments.Supply3)]
		public static Func<Func<T1, T2, T3, T4, U>, T1, T2, T3, Func<T4, U>> L_Supply3_F<T1, T2, T3, T4, U>()
			{
			return (In, Obj, Obj2, Obj3) =>
			{
				return (o1) => { return In(Obj, Obj2, Obj3, o1); };
			};
			}
		/// <summary>
		/// Returns a method with the second three parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply2", new String[] { "In", "Obj", "Obj2", "Obj3" }, L.Comments.Supply3_2)]
		public static Func<Func<T1, T2, T3, T4, U>, T2, T3, T4, Func<T1, U>> L_Supply3_F2<T1, T2, T3, T4, U>()
			{
			return (In, Obj, Obj2, Obj3) =>
			{
				return (o1) => { return In(o1, Obj, Obj2, Obj3); };
			};
			}
		#endregion
		#region Supply 4
		/// <summary>
		/// Returns a method with the first four parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2", "Obj3", "Obj4" }, L.Comments.Supply4)]
		public static Func<Action<T1, T2, T3, T4>, T1, T2, T3, T4, Action> L_Supply4_A<T1, T2, T3, T4>()
			{
			return (In, Obj, Obj2, Obj3, Obj4) =>
			{
				return () => { In(Obj, Obj2, Obj3, Obj4); };
			};
			}
		/// <summary>
		/// Returns a method with the first four parameters removed. When the method is called, Obj and Obj2 will be supplied.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		[CodeExplodeExtensionMethod("Supply", new String[] { "In", "Obj", "Obj2", "Obj3", "Obj4" }, L.Comments.Supply4)]
		public static Func<Func<T1, T2, T3, T4, U>, T1, T2, T3, T4, Func<U>> L_Supply4_F<T1, T2, T3, T4, U>()
			{
			return (In, Obj, Obj2, Obj3, Obj4) =>
			{
				return () => { return In(Obj, Obj2, Obj3, Obj4); };
			};
			}
		#endregion
		
		#region Arg
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Action<T1> Arg<T1>()
			{
			return (o1) => { };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <returns></returns>
		public static Action<T1, T2> Arg<T1, T2>()
			{
			return (o1, o2) => { };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <returns></returns>
		public static Action<T1, T2, T3> Arg<T1, T2, T3>()
			{
			return (o1, o2, o3) => { };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Arg<T1, T2, T3, T4>()
			{
			return (o1, o2, o3, o4) => { };
			}
		#endregion
		#region Do
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<U> Do<U>()
			{
			return () => { return default(U); };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, U> Do<T1, U>()
			{
			return (o1) => { return default(U); };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, T2, U> Do<T1, T2, U>()
			{
			return (o1, o2) => { return default(U); };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Do<T1, T2, T3, U>()
			{
			return (o1, o2, o3) => { return default(U); };
			}
		/// <summary>
		/// Creates an empty method using the specified Type Arguments.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Do<T1, T2, T3, T4, U>()
			{
			return (o1, o2, o3, o4) => { return default(U); };
			}
		#endregion
		
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Action Action(Action In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Action<T1> Action<T1>(Action<T1> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Action<T1, T2> Action<T1, T2>(Action<T1, T2> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Action<T1, T2, T3> Action<T1, T2, T3>(Action<T1, T2, T3> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Action<T1, T2, T3, T4> Action<T1, T2, T3, T4>(Action<T1, T2, T3, T4> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Func<U> Function<U>(Func<U> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Func<T1, U> Function<T1, U>(Func<T1, U> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Func<T1, T2, U> Function<T1, T2, U>(Func<T1, T2, U> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Func<T1, T2, T3, U> Function<T1, T2, T3, U>(Func<T1, T2, T3, U> In)
			{
			return In;
			}
		/// <summary>
		/// Returns a method from a static or instance reference
		/// </summary>
		public static Func<T1, T2, T3, T4, U> Function<T1, T2, T3, T4, U>(Func<T1, T2, T3, T4, U> In)
			{
			return In;
			}
		#endregion

		#region Method Retrievers
		#endregion

		#region Return
		/// <summary>
		/// Returns a function that returns an empty object of Type U
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <returns></returns>
		public static Func<U> Return<U>()
			{
			return L.Do<U>();
			}
		/// <summary>
		/// Returns a function that returns the supplied Object
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<U> Return<U>(U In)
			{
			return () => { return In; };
			}
		#endregion
		#region Pass
		/// <summary>
		/// Returns a function that takes a Typed value and returns it, performing no action.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Func<T1, T1> Pass<T1>()
			{
			return (o) => { return o; };
			}
		#endregion

		// Do
		//[CodeExplodeExtensionMethod("Cast", new String[] { "In" }, L.Comments.Cast)]
		public static Func<Action<T1>, Action<U1>> L_Cast<T1, U1>()
			where U1 : T1
			{
			return (In) =>
			{
				return L.L_Cast_A<T1, U1>()(In);
			};
			}

		#region Comments
		public partial class Comments
			{
			public const String Return = "Returns a function that converts an action to a Func, returning the specified value.";
			public const String Return_Func = "Returns a function that Overrides the return value of In with the specified value.";
			public const String Rotate = "Returns a function that rotates the list of parameters to the right.";
			public const String RotateBack = "Returns a function that rotates the list of parameters to the left.";
			public const String Default = "If the first argument passed is null or empty, the Default value is used instead.";
			public const String Default2 = "If the second argument passed is null or empty, the Default value is used instead.";
			public const String Default3 = "If the third argument passed is null or empty, the Default value is used instead.";
			public const String Default4 = "If the fourth argument passed is null or empty, the Default value is used instead.";
			public const String Defaults = "If the arguments passed are null or empty, the Default values are used instead.";
			public const String Require = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
			public const String Require2 = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
			public const String Require3 = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
			public const String Require4 = "Returns a function that requires the first parameter to be non-null. If the parameter is null, an exception is thrown with the parameter name.";
			public const String RequireAll = "Returns a function that requires all parameters to be non-null. If any parameter is null, an exception is thrown with the parameter name.";
			public const String Do = "Returns an Action from the supplied Func. The return value is discarded.";
			public const String Cache = "Caches the results of In using a Unique CacheID, combined with the string representation of all parameters.";
			public const String Yield = "Takes an Action and returns a Func that returns the first parameter after the action is performed.";
			public const String Yield2 = "Takes an Action and returns a Func that returns the second parameter after the action is performed.";
			public const String Yield3 = "Takes an Action and returns a Func that returns the third parameter after the action is performed.";
			public const String Yield4 = "Takes an Action and returns a Func that returns the fourth parameter after the action is performed.";
			public const String Execute = "For a method Act that returns a method, Returns a method that executes the Method passed and its result.";
			public const String ExecuteMerge = "For a method Act that returns a method, Returns a method that executes the Method passed and its result. Parameters within Act and the result are joined in the result.";
			public const String Then = "Joins two methods together, performing one then another.";
			public const String Then_Multiple = "Joins multiple actions together, performing them in order.";
			public const String Then_Missing = "Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored.";
			public const String Then_Missing_Func = "Returns a method that concatonates In with Acts. Parameters are shared. Any missing parameters in In that are missing from Acts are ignored. The last method in Acts will be the return value that is used.";
			public const String Merge = "Returns a function that Performs In, then Merge. Parameter lists are merged.";
			public const String Supply = "Returns a method with the first parameter removed. When the method is called, Obj will be supplied.";
			public const String Supply_2 = "Returns a method with the second parameter removed. When the method is called, Obj will be supplied.";
			public const String Supply_3 = "Returns a method with the third parameter removed. When the method is called, Obj will be supplied.";
			public const String Supply_4 = "Returns a method with the fourth parameter removed. When the method is called, Obj will be supplied.";
			public const String Supply2 = "Returns a method with the first two parameters removed. When the method is called, Obj and Obj2 will be supplied.";
			public const String Supply2_2 = "Returns a method with the second two parameters removed. When the method is called, Obj and Obj2 will be supplied.";
			public const String Supply2_3 = "Returns a method with the third two parameters removed. When the method is called, Obj and Obj2 will be supplied.";
			public const String Supply3 = "Returns a method with the first three parameters removed. When the method is called, Obj and Obj2 will be supplied.";
			public const String Supply3_2 = "Returns a method with the second three parameters removed. When the method is called, Obj and Obj2 will be supplied.";
			public const String Supply4 = "Returns a method with the first four parameters removed. When the method is called, Obj and Obj2 will be supplied.";
			public const String Cast = "Returns a function that takes a Casts the paramater of the Action to U1";
			public const String Set = "Returns a function that sets (overrides) the first parameter in Func with In";
			public const String Set2 = "Returns a function that sets (overrides) the second parameter in Func with In";
			public const String Set3 = "Returns a function that sets (overrides) the third parameter in Func with In";
			public const String Set4 = "Returns a function that sets (overrides) the fourth parameter in Func with In";
			public const String SetFunc = "Returns a function that sets (overrides) the first parameter in Func with the result of In";
			}
		#endregion

		#region Set 5
		#endregion
		#region Set 6
		#endregion
		#region Set 7
		#endregion
		#region Set 8
		#endregion
		#region Set 9
		#endregion
		#region Set 10
		#endregion
		#region Set 11
		#endregion
		#region Set 12
		#endregion
		#region Set 13
		#endregion
		#region Set 14
		#endregion
		#region Set 15
		#endregion
		#region Set 16
		#endregion
		}
	public static partial class LogicExt
		{
		#region Cast
		/// <summary>
		/// Returns a function that takes a Casts the paramater of the Action to U1
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<U1> Cast<T1, U1>(this Action<T1> In) where U1 : T1
			{
			return L.L_Cast_A<T1, U1>()(In);
			}
		/// <summary>
		/// Returns a function that takes a Casts the paramaters of the Action to U1, U2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<U1, U2> Cast<T1, T2, U1, U2>(this Action<T1, T2> In)
			where U1 : T1
			where U2 : T2
			{
			return L.L_Cast_A<T1, T2, U1, U2>()(In);
			}
		/// <summary>
		/// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <typeparam name="U3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<U1, U2, U3> Cast<T1, T2, T3, U1, U2, U3>(this Action<T1, T2, T3> In)
			where U1 : T1
			where U2 : T2
			where U3 : T3
			{
			return L.L_Cast_A<T1, T2, T3, U1, U2, U3>()(In);
			}
		/// <summary>
		/// Returns a function that takes a Casts the paramaters of the Action to U1, U2, U3, U4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <typeparam name="U3"></typeparam>
		/// <typeparam name="U4"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<U1, U2, U3, U4> Cast<T1, T2, T3, T4, U1, U2, U3, U4>(this Action<T1, T2, T3, T4> In)
			where U1 : T1
			where U2 : T2
			where U3 : T3
			where U4 : T4
			{
			return L.L_Cast_A<T1, T2, T3, T4, U1, U2, U3, U4>()(In);
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2
		/// </summary>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<U2> Cast<U1, U2>(this Func<U1> In)
			{
			return L.L_Cast_F<U1, U2>()(In);
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the input to T2
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T2, U2> Cast<T1, U1, T2, U2>(this Func<T1, U1> In)
			where T2 : T1
			where U2 : U1
			{
			return L.L_Cast_F<T1, U1, T2, U2>()(In);
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the inputs to T3, T4
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T3, T4, U2> Cast<T1, T2, U1, T3, T4, U2>(this Func<T1, T2, U1> In)
			where T3 : T1
			where T4 : T2
			where U2 : U1
			{
			return L.L_Cast_F<T1, T2, U1, T3, T4, U2>()(In);
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the inputs to T4, T5, T6
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T4, T5, T6, U2> Cast<T1, T2, T3, U1, T4, T5, T6, U2>(this Func<T1, T2, T3, U1> In)
			where T4 : T1
			where T5 : T2
			where T6 : T3
			where U2 : U1
			{
			return L.L_Cast_F<T1, T2, T3, U1, T4, T5, T6, U2>()(In);
			}
		/// <summary>
		/// Returns a function that Casts the output of the Func to U2 and the inputs to T7, T8, T9
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U1"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="T6"></typeparam>
		/// <typeparam name="T7"></typeparam>
		/// <typeparam name="T8"></typeparam>
		/// <typeparam name="U2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T5, T6, T7, T8, U2> Cast<T1, T2, T3, T4, U1, T5, T6, T7, T8, U2>(this Func<T1, T2, T3, T4, U1> In)
			where T5 : T1
			where T6 : T2
			where T7 : T3
			where T8 : T4
			where U2 : U1
			{
			return L.L_Cast_F<T1, T2, T3, T4, U1, T5, T6, T7, T8, U2>()(In);
			}
		#endregion

		// Refactor
		#region Supply Parameter +
		#region Surround +
		#region Surround - Action_T
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func.
		/// </summary>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action Surround<U>(this Action<U> In, Func<U> Func)
			{
			return () => { In(Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1> Surround<T1, U>(this Action<U> In, Func<T1, U> Func)
			{
			return (o) => { In(Func(o)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2> Surround<T1, T2, U>(this Action<U> In, Func<T1, T2, U> Func)
			{
			return (o1, o2) => { In(Func(o1, o2)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Surround<T1, T2, T3, U>(this Action<U> In, Func<T1, T2, T3, U> Func)
			{
			return (o1, o2, o3) => { In(Func(o1, o2, o3)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Surround<T1, T2, T3, T4, U>(this Action<U> In, Func<T1, T2, T3, T4, U> Func)
			{
			return (o1, o2, o3, o4) => { In(Func(o1, o2, o3, o4)); };
			}
		#endregion
		#region Surround - Action_T_T
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2> Surround<T1, T2>(this Action<T1, T2> In, Func<T1> Func)
			{
			return (o) => { In(Func(), o); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1> Surround2<T1, T2>(this Action<T1, T2> In, Func<T2> Func)
			{
			return (o) => { In(o, Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3> Surround<T1, T2, T3>(this Action<T1, T2> In, Func<T3, T1> Func)
			{
			return (o1, o2) => { In(Func(o2), o1); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3> Surround2<T1, T2, T3>(this Action<T1, T2> In, Func<T3, T2> Func)
			{
			return (o1, o2) => { In(o1, Func(o2)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Surround<T1, T2, T3, T4>(this Action<T1, T2> In, Func<T3, T4, T1> Func)
			{
			return (o1, o2, o3) => { In(Func(o2, o3), o1); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4> Surround2<T1, T2, T3, T4>(this Action<T1, T2> In, Func<T3, T4, T2> Func)
			{
			return (o1, o2, o3) => { In(o1, Func(o2, o3)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Surround<T1, T2, T3, T4, T5>(this Action<T1, T2> In, Func<T3, T4, T5, T1> Func)
			{
			return (o1, o2, o3, o4) => { In(Func(o2, o3, o4), o1); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4, T5> Surround2<T1, T2, T3, T4, T5>(this Action<T1, T2> In, Func<T3, T4, T5, T2> Func)
			{
			return (o1, o2, o3, o4) => { In(o1, Func(o2, o3, o4)); };
			}
		#endregion
		#region Surround - Action_T_T_T
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3> Surround<T1, T2, T3>(this Action<T1, T2, T3> In, Func<T1> Func)
			{
			return (o1, o2) => { In(Func(), o1, o2); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3> Surround2<T1, T2, T3>(this Action<T1, T2, T3> In, Func<T2> Func)
			{
			return (o1, o2) => { In(o1, Func(), o2); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2> Surround3<T1, T2, T3>(this Action<T1, T2, T3> In, Func<T3> Func)
			{
			return (o1, o2) => { In(o1, o2, Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Surround<T1, T2, T3, T4>(this Action<T1, T2, T3> In, Func<T4, T1> Func)
			{
			return (o1, o2, o3) => { In(Func(o3), o1, o2); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4> Surround2<T1, T2, T3, T4>(this Action<T1, T2, T3> In, Func<T4, T2> Func)
			{
			return (o1, o2, o3) => { In(o1, Func(o3), o2); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4> Surround3<T1, T2, T3, T4>(this Action<T1, T2, T3> In, Func<T4, T3> Func)
			{
			return (o1, o2, o3) => { In(o1, o2, Func(o3)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Surround<T1, T2, T3, T4, T5>(this Action<T1, T2, T3> In, Func<T4, T5, T1> Func)
			{
			return (o1, o2, o3, o4) => { In(Func(o3, o4), o1, o2); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4, T5> Surround2<T1, T2, T3, T4, T5>(this Action<T1, T2, T3> In, Func<T4, T5, T2> Func)
			{
			return (o1, o2, o3, o4) => { In(o1, Func(o3, o4), o2); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4, T5> Surround3<T1, T2, T3, T4, T5>(this Action<T1, T2, T3> In, Func<T4, T5, T3> Func)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, Func(o3, o4)); };
			}
		#endregion
		#region Surround - Action_T_T_T_T
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Surround<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<T1> Func)
			{
			return (o1, o2, o3) => { In(Func(), o1, o2, o3); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4> Surround2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<T2> Func)
			{
			return (o1, o2, o3) => { In(o1, Func(), o2, o3); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4> Surround3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<T3> Func)
			{
			return (o1, o2, o3) => { In(o1, o2, Func(), o3); };
			}
		/// <summary>
		/// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Surround4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> In, Func<T4> Func)
			{
			return (o1, o2, o3) => { In(o1, o2, o3, Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Surround<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4> In, Func<T5, T1> Func)
			{
			return (o1, o2, o3, o4) => { In(Func(o4), o1, o2, o3); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4, T5> Surround2<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4> In, Func<T5, T2> Func)
			{
			return (o1, o2, o3, o4) => { In(o1, Func(o4), o2, o3); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4, T5> Surround3<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4> In, Func<T5, T3> Func)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, Func(o4), o3); };
			}
		/// <summary>
		/// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T5> Surround4<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4> In, Func<T5, T4> Func)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o3, Func(o4)); };
			}
		#endregion
		#region Surround - Func_T_U
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<U> Surround<T1, U>(this Func<T1, U> In, Func<T1> Func)
			{
			return () => { return In(Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, U> Surround<T1, T2, U>(this Func<T2, U> In, Func<T1, T2> Func)
			{
			return (o) => { return In(Func(o)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Surround<T1, T2, T3, U>(this Func<T3, U> In, Func<T1, T2, T3> Func)
			{
			return (o1, o2) => { return In(Func(o1, o2)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Surround<T1, T2, T3, T4, U>(this Func<T4, U> In, Func<T1, T2, T3, T4> Func)
			{
			return (o1, o2, o3) => { return In(Func(o1, o2, o3)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Surround<T1, T2, T3, T4, T5, U>(this Func<T5, U> In, Func<T1, T2, T3, T4, T5> Func)
			{
			return (o1, o2, o3, o4) => { return In(Func(o1, o2, o3, o4)); };
			}
		#endregion
		#region Surround - Func_T_T_U
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, U> Surround<T1, T2, U>(this Func<T1, T2, U> In, Func<T1> Func)
			{
			return (o) => { return In(Func(), o); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, U> Surround2<T1, T2, U>(this Func<T1, T2, U> In, Func<T2> Func)
			{
			return (o) => { return In(o, Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, U> Surround<T1, T2, T3, U>(this Func<T1, T2, U> In, Func<T3, T1> Func)
			{
			return (o1, o2) => { return In(Func(o2), o1); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, U> Surround2<T1, T2, T3, U>(this Func<T1, T2, U> In, Func<T3, T2> Func)
			{
			return (o1, o2) => { return In(o1, Func(o2)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, U> Surround<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, Func<T3, T4, T1> Func)
			{
			return (o1, o2, o3) => { return In(Func(o2, o3), o1); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, U> Surround2<T1, T2, T3, T4, U>(this Func<T1, T2, U> In, Func<T3, T4, T2> Func)
			{
			return (o1, o2, o3) => { return In(o1, Func(o2, o3)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, T5, U> Surround<T1, T2, T3, T4, T5, U>(this Func<T1, T2, U> In, Func<T3, T4, T5, T1> Func)
			{
			return (o1, o2, o3, o4) => { return In(Func(o2, o3, o4), o1); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, T5, U> Surround2<T1, T2, T3, T4, T5, U>(this Func<T1, T2, U> In, Func<T3, T4, T5, T2> Func)
			{
			return (o1, o2, o3, o4) => { return In(o1, Func(o2, o3, o4)); };
			}
		#endregion
		#region Surround - Func_T_T_T_U
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, U> Surround<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T1> Func)
			{
			return (o1, o2) => { return In(Func(), o1, o2); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, U> Surround2<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T2> Func)
			{
			return (o1, o2) => { return In(o1, Func(), o2); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Surround3<T1, T2, T3, U>(this Func<T1, T2, T3, U> In, Func<T3> Func)
			{
			return (o1, o2) => { return In(o1, o2, Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, U> Surround<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Func<T4, T1> Func)
			{
			return (o1, o2, o3) => { return In(Func(o3), o1, o2); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, U> Surround2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Func<T4, T2> Func)
			{
			return (o1, o2, o3) => { return In(o1, Func(o3), o2); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, U> Surround3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, U> In, Func<T4, T3> Func)
			{
			return (o1, o2, o3) => { return In(o1, o2, Func(o3)); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, T5, U> Surround<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, U> In, Func<T4, T5, T1> Func)
			{
			return (o1, o2, o3, o4) => { return In(Func(o3, o4), o1, o2); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, T5, U> Surround2<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, U> In, Func<T4, T5, T2> Func)
			{
			return (o1, o2, o3, o4) => { return In(o1, Func(o3, o4), o2); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, T5, U> Surround3<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, U> In, Func<T4, T5, T3> Func)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, Func(o3, o4)); };
			}
		#endregion
		#region Surround - Func_T_T_T_T_U
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, U> Surround<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T1> Func)
			{
			return (o1, o2, o3) => { return In(Func(), o1, o2, o3); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, U> Surround2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T2> Func)
			{
			return (o1, o2, o3) => { return In(o1, Func(), o2, o3); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, U> Surround3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T3> Func)
			{
			return (o1, o2, o3) => { return In(o1, o2, Func(), o3); };
			}
		/// <summary>
		/// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Surround4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> In, Func<T4> Func)
			{
			return (o1, o2, o3) => { return In(o1, o2, o3, Func()); };
			}
		/// <summary>
		/// Returns a method with the first parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, T5, U> Surround<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, U> In, Func<T5, T1> Func)
			{
			return (o1, o2, o3, o4) => { return In(Func(o4), o1, o2, o3); };
			}
		/// <summary>
		/// Returns a method with the second parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, T5, U> Surround2<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, U> In, Func<T5, T2> Func)
			{
			return (o1, o2, o3, o4) => { return In(o1, Func(o4), o2, o3); };
			}
		/// <summary>
		/// Returns a method with the third parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, T5, U> Surround3<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, U> In, Func<T5, T3> Func)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, Func(o4), o3); };
			}
		/// <summary>
		/// Returns a method with the fourth parameter removed and supplied with the result of Func. Parameter liss are merged.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <param name="Func"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T5, U> Surround4<T1, T2, T3, T4, T5, U>(this Func<T1, T2, T3, T4, U> In, Func<T5, T4> Func)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o3, Func(o4)); };
			}
		#endregion
		#endregion
		#region Enclose +
		#region Enclose - Action_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action Enclose<T1>(this Func<T1> Func, Action<T1> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2> Enclose<T1, T2>(this Func<T2, T1> Func, Action<T1> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3> Enclose<T1, T2, T3>(this Func<T2, T3, T1> Func, Action<T1> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>(this Func<T2, T3, T4, T1> Func, Action<T1> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>(this Func<T2, T3, T4, T5, T1> Func, Action<T1> Outer)
			{
			return Outer.Surround(Func);
			}
		#endregion
		#region Enclose - Action_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2> Enclose<T1, T2>(this Func<T1> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1> Enclose2<T1, T2>(this Func<T2> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3> Enclose<T1, T2, T3>(this Func<T3, T1> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3> Enclose2<T1, T2, T3>(this Func<T3, T2> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>(this Func<T3, T4, T1> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4> Enclose2<T1, T2, T3, T4>(this Func<T3, T4, T2> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>(this Func<T3, T4, T5, T1> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4, T5> Enclose2<T1, T2, T3, T4, T5>(this  Func<T3, T4, T5, T2> Func, Action<T1, T2> Outer)
			{
			return Outer.Surround2(Func);
			}
		#endregion
		#region Enclose - Action_T_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3> Enclose<T1, T2, T3>(this Func<T1> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3> Enclose2<T1, T2, T3>(this Func<T2> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2> Enclose3<T1, T2, T3>(this Func<T3> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>(this Func<T4, T1> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4> Enclose2<T1, T2, T3, T4>(this Func<T4, T2> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4> Enclose3<T1, T2, T3, T4>(this Func<T4, T3> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>(this  Func<T4, T5, T1> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4, T5> Enclose2<T1, T2, T3, T4, T5>(this Func<T4, T5, T2> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4, T5> Enclose3<T1, T2, T3, T4, T5>(this Func<T4, T5, T3> Func, Action<T1, T2, T3> Outer)
			{
			return Outer.Surround3(Func);
			}
		#endregion
		#region Enclose - Action_T_T_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4> Enclose<T1, T2, T3, T4>(this Func<T1> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4> Enclose2<T1, T2, T3, T4>(this Func<T2> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4> Enclose3<T1, T2, T3, T4>(this Func<T3> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Enclose4<T1, T2, T3, T4>(this Func<T4> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround4(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T2, T3, T4, T5> Enclose<T1, T2, T3, T4, T5>(this Func<T5, T1> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T3, T4, T5> Enclose2<T1, T2, T3, T4, T5>(this Func<T5, T2> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2, T4, T5> Enclose3<T1, T2, T3, T4, T5>(this Func<T5, T3> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T5> Enclose4<T1, T2, T3, T4, T5>(this Func<T5, T4> Func, Action<T1, T2, T3, T4> Outer)
			{
			return Outer.Surround4(Func);
			}
		#endregion
		#region Enclose - Func_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<U> Enclose<T1, U>(this Func<T1> Func, Func<T1, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, U> Enclose<T1, T2, U>(this Func<T1, T2> Func, Func<T2, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Enclose<T1, T2, T3, U>(this Func<T1, T2, T3> Func, Func<T3, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Enclose<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4> Func, Func<T4, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Enclose<T1, T2, T3, T4, T5, U>(this  Func<T1, T2, T3, T4, T5> Func, Func<T5, U> Outer)
			{
			return Outer.Surround(Func);
			}
		#endregion
		#region Enclose - Func_T_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, U> Enclose<T1, T2, U>(this Func<T1> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, U> Enclose2<T1, T2, U>(this Func<T2> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, U> Enclose<T1, T2, T3, U>(this Func<T3, T1> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, U> Enclose2<T1, T2, T3, U>(this Func<T3, T2> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, U> Enclose<T1, T2, T3, T4, U>(this Func<T3, T4, T1> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, U> Enclose2<T1, T2, T3, T4, U>(this Func<T3, T4, T2> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, T5, U> Enclose<T1, T2, T3, T4, T5, U>(this Func<T3, T4, T5, T1> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, T5, U> Enclose2<T1, T2, T3, T4, T5, U>(this Func<T3, T4, T5, T2> Func, Func<T1, T2, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		#endregion
		#region Enclose - Func_T_T_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, U> Enclose<T1, T2, T3, U>(this Func<T1> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, U> Enclose2<T1, T2, T3, U>(this Func<T2> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Enclose3<T1, T2, T3, U>(this Func<T3> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, U> Enclose<T1, T2, T3, T4, U>(this Func<T4, T1> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, U> Enclose2<T1, T2, T3, T4, U>(this Func<T4, T2> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, U> Enclose3<T1, T2, T3, T4, U>(this Func<T4, T3> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, T5, U> Enclose<T1, T2, T3, T4, T5, U>(this Func<T4, T5, T1> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, T5, U> Enclose2<T1, T2, T3, T4, T5, U>(this Func<T4, T5, T2> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, T5, U> Enclose3<T1, T2, T3, T4, T5, U>(this Func<T4, T5, T3> Func, Func<T1, T2, T3, U> Outer)
			{
			return Outer.Surround3(Func);
			}
		#endregion
		#region Enclose - Func_T_T_T_T_T
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, U> Enclose<T1, T2, T3, T4, U>(this Func<T1> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, U> Enclose2<T1, T2, T3, T4, U>(this Func<T2> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, U> Enclose3<T1, T2, T3, T4, U>(this Func<T3> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Enclose4<T1, T2, T3, T4, U>(this Func<T4> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround4(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the first parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T2, T3, T4, T5, U> Enclose<T1, T2, T3, T4, T5, U>(this Func<T5, T1> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the second parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T3, T4, T5, U> Enclose2<T1, T2, T3, T4, T5, U>(this Func<T5, T2> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround2(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the third parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T4, T5, U> Enclose3<T1, T2, T3, T4, T5, U>(this Func<T5, T3> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround3(Func);
			}
		/// <summary>
		/// Returns a method that uses the Func method as the fourth parameter to the Outer method. Inverse of Surround.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="T5"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="Outer"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T5, U> Enclose4<T1, T2, T3, T4, T5, U>(this Func<T5, T4> Func, Func<T1, T2, T3, T4, U> Outer)
			{
			return Outer.Surround4(Func);
			}
		#endregion
		#endregion
		#endregion
		#region Set Parameter +
		#region Set # to #
		#region Set 1 to 2
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T1> Set_1_To_2<T1>(this Action<T1, T1> In)
			{
			return (o1, o2) => { In(o2, o2); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T1, T2> Set_1_To_2<T1, T2>(this Action<T1, T1, T2> In)
			{
			return (o1, o2, o3) => { In(o2, o2, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T1, T2, T3> Set_1_To_<T1, T2, T3>(this Action<T1, T1, T2, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o2, o2, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T1, U> Set_1_To_2<T1, U>(this Func<T1, T1, U> In)
			{
			return (o1, o2) => { return In(o2, o2); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T1, T2, U> Set_1_To_2<T1, T2, U>(this Func<T1, T1, T2, U> In)
			{
			return (o1, o2, o3) => { return In(o2, o2, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T1, T2, T3, U> Set_1_To_2<T1, T2, T3, U>(this Func<T1, T1, T2, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o2, o2, o3, o4); };
			}
		#endregion
		#region Set 1 to 3
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T1> Set_1_To_3<T1, T2>(this Action<T1, T2, T1> In)
			{
			return (o1, o2, o3) => { In(o3, o2, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T1, T3> Set_1_To_3<T1, T2, T3>(this Action<T1, T2, T1, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o3, o2, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T1, U> Set_1_To_3<T1, T2, U>(this Func<T1, T2, T1, U> In)
			{
			return (o1, o2, o3) => { return In(o3, o2, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T1, T3, U> Set_1_To_3<T1, T2, T3, U>(this Func<T1, T2, T1, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o3, o2, o3, o4); };
			}
		#endregion
		#region Set 1 to 4
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the fourth parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T1> Set_1_To_4<T1, T2, T3>(this Action<T1, T2, T3, T1> In)
			{
			return (o1, o2, o3, o4) => { In(o4, o2, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the first parameter with the fourth parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T1, U> Set_1_To_4<T1, T2, T3, U>(this Func<T1, T2, T3, T1, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o4, o2, o3, o4); };
			}
		#endregion
		#region Set 2 to 1
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T1> Set_2_To_1<T1>(this Action<T1, T1> In)
			{
			return (o1, o2) => { In(o1, o1); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T1, T2> Set_2_To_1<T1, T2>(this Action<T1, T1, T2> In)
			{
			return (o1, o2, o3) => { In(o1, o1, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T1, T2, T3> Set_2_To_1<T1, T2, T3>(this Action<T1, T1, T2, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o1, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T1, U> Set_2_To_1<T1, U>(this Func<T1, T1, U> In)
			{
			return (o1, o2) => { return In(o1, o1); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T1, T2, U> Set_2_To_1<T1, T2, U>(this Func<T1, T1, T2, U> In)
			{
			return (o1, o2, o3) => { return In(o1, o1, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T1, T2, T3, U> Set_2_To_1<T1, T2, T3, U>(this Func<T1, T1, T2, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o1, o3, o4); };
			}
		#endregion
		#region Set 2 to 3
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T2> Set_2_To_3<T1, T2>(this Action<T1, T2, T2> In)
			{
			return (o1, o2, o3) => { In(o1, o3, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T2, T3> Set_2_To_3<T1, T2, T3>(this Action<T1, T2, T2, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o3, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T2, U> Set_2_To_3<T1, T2, U>(this Func<T1, T2, T2, U> In)
			{
			return (o1, o2, o3) => { return In(o1, o3, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T2, T3, U> Set_2_To_3<T1, T2, T3, U>(this Func<T1, T2, T2, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o3, o3, o4); };
			}
		#endregion
		#region Set 2 to 4
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the fourth parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T3, T2, T3> Set_2_To_4<T1, T2, T3>(this Action<T1, T3, T2, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o4, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter with the fourth parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T3, T2, T3, U> Set_2_To_4<T1, T2, T3, U>(this Func<T1, T3, T2, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o4, o3, o4); };
			}
		#endregion
		#region Set 3 to 1
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T1> Set_3_To_1<T1, T2>(this Action<T1, T2, T1> In)
			{
			return (o1, o2, o3) => { In(o1, o2, o1); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T1, T3> Set_3_To_1<T1, T2, T3>(this Action<T1, T2, T1, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o1, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T1, U> Set_3_To_1<T1, T2, U>(this Func<T1, T2, T1, U> In)
			{
			return (o1, o2, o3) => { return In(o1, o2, o1); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T1, T3, U> Set_3_To_1<T1, T2, T3, U>(this Func<T1, T2, T1, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o1, o4); };
			}
		#endregion
		#region Set 3 to 2
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T2> Set_3_To_2<T1, T2>(this Action<T1, T2, T2> In)
			{
			return (o1, o2, o3) => { In(o1, o2, o2); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T2, T3> Set_3_To_2<T1, T2, T3>(this Action<T1, T2, T2, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o2, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T2, U> Set_3_To_2<T1, T2, U>(this Func<T1, T2, T2, U> In)
			{
			return (o1, o2, o3) => { return In(o1, o2, o2); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T2, T3, U> Set_3_To_2<T1, T2, T3, U>(this Func<T1, T2, T2, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o2, o4); };
			}
		#endregion
		#region Set 3 to 4
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the fourth parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T3> Set_3_To_4<T1, T2, T3>(this Action<T1, T2, T3, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o4, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter with the fourth parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T3, U> Set_3_To_4<T1, T2, T3, U>(this Func<T1, T2, T3, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o4, o4); };
			}
		#endregion
		#region Set 4 to 1
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T1, T3> Set_4_To_1<T1, T2, T3>(this Action<T1, T2, T3, T1> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o4, o1); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter with the first parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T1, U> Set_4_To_1<T1, T2, T3, U>(this Func<T1, T2, T3, T1, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o3, o1); };
			}
		#endregion
		#region Set 4 to 2
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T2> Set_4_To_2<T1, T2, T3>(this Action<T1, T2, T3, T2> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o3, o2); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter with the second parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T2, U> Set_4_To_2<T1, T2, T3, U>(this Func<T1, T2, T3, T2, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o3, o2); };
			}
		#endregion
		#region Set 4 to 3
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T3> Set_4_To_3<T1, T2, T3>(this Action<T1, T2, T3, T3> In)
			{
			return (o1, o2, o3, o4) => { In(o1, o2, o3, o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter with the third parameter
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T3, U> Set_4_To_3<T1, T2, T3, U>(this Func<T1, T2, T3, T3, U> In)
			{
			return (o1, o2, o3, o4) => { return In(o1, o2, o3, o3); };
			}
		#endregion
		#endregion
		#region Set Func
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2> Set2<T1, T2>(this Action<T1, T2> Func, Func<T2> In)
			{
			return (o1, o2) => { Func(o1, In()); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Set2<T1, T2, T3>(this Action<T1, T2, T3> Func, Func<T2> In)
			{
			return (o1, o2, o3) => { Func(o1, In(), o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Set3<T1, T2, T3>(this Action<T1, T2, T3> Func, Func<T3> In)
			{
			return (o1, o2, o3) => { Func(o1, o2, In()); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Set2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T2> In)
			{
			return (o1, o2, o3, o4) => { Func(o1, In(), o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Set3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T3> In)
			{
			return (o1, o2, o3, o4) => { Func(o1, o2, In(), o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>es
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Set4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T4> In)
			{
			return (o1, o2, o3, o4) => { Func(o1, o2, o3, In()); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Set2<T1, T2, U>(this Func<T1, T2, U> Func, Func<T2> In)
			{
			return (o1, o2) => { return Func(o1, In()); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Set2<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, Func<T2> In)
			{
			return (o1, o2, o3) => { return Func(o1, In(), o3); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Set3<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, Func<T3> In)
			{
			return (o1, o2, o3) => { return Func(o1, o2, In()); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the second parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Set2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T2> In)
			{
			return (o1, o2, o3, o4) => { return Func(o1, In(), o3, o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the third parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Set3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T3> In)
			{
			return (o1, o2, o3, o4) => { return Func(o1, o2, In(), o4); };
			}
		/// <summary>
		/// Returns a function that sets (overrides) the fourth parameter in Func with the result of In
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Set4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T4> In)
			{
			return (o1, o2, o3, o4) => { return Func(o1, o2, o3, In()); };
			}
		#endregion
		#region Send
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1> Send<T1>(this Action<T1> Func, Func<T1, T1> In)
			{
			return (o) => { Func(In(o)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2> Send<T1, T2>(this Action<T1, T2> Func, Func<T1, T1> In)
			{
			return (o1, o2) => { Func(In(o1), o2); };
			}
		/// <summary>
		/// Returns a function that sends the second parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2> Send2<T1, T2>(this Action<T1, T2> Func, Func<T2, T2> In)
			{
			return (o1, o2) => { Func(o1, In(o2)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Send<T1, T2, T3>(this Action<T1, T2, T3> Func, Func<T1, T1> In)
			{
			return (o1, o2, o3) => { Func(In(o1), o2, o3); };
			}
		/// <summary>
		/// Returns a function that sends the second parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Send2<T1, T2, T3>(this Action<T1, T2, T3> Func, Func<T2, T2> In)
			{
			return (o1, o2, o3) => { Func(o1, In(o2), o3); };
			}
		/// <summary>
		/// Returns a function that sends the third parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3> Send3<T1, T2, T3>(this Action<T1, T2, T3> Func, Func<T3, T3> In)
			{
			return (o1, o2, o3) => { Func(o1, o2, In(o3)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Send<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T1, T1> In)
			{
			return (o1, o2, o3, o4) => { Func(In(o1), o2, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sends the second parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Send2<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T2, T2> In)
			{
			return (o1, o2, o3, o4) => { Func(o1, In(o2), o3, o4); };
			}
		/// <summary>
		/// Returns a function that sends the third parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Send3<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T3, T3> In)
			{
			return (o1, o2, o3, o4) => { Func(o1, o2, In(o3), o4); };
			}
		/// <summary>
		/// Returns a function that sends the fourth parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Action<T1, T2, T3, T4> Send4<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> Func, Func<T4, T4> In)
			{
			return (o1, o2, o3, o4) => { Func(o1, o2, o3, In(o4)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, U> Send<T1, U>(this Func<T1, U> Func, Func<T1, T1> In)
			{
			return (o) => { return Func(In(o)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Send<T1, T2, U>(this Func<T1, T2, U> Func, Func<T1, T1> In)
			{
			return (o1, o2) => { return Func(In(o1), o2); };
			}
		/// <summary>
		/// Returns a function that sends the second parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, U> Send2<T1, T2, U>(this Func<T1, T2, U> Func, Func<T2, T2> In)
			{
			return (o1, o2) => { return Func(o1, In(o2)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Send<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, Func<T1, T1> In)
			{
			return (o1, o2, o3) => { return Func(In(o1), o2, o3); };
			}
		/// <summary>
		/// Returns a function that sends the second parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Send2<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, Func<T2, T2> In)
			{
			return (o1, o2, o3) => { return Func(o1, In(o2), o3); };
			}
		/// <summary>
		/// Returns a function that sends the third parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, U> Send3<T1, T2, T3, U>(this Func<T1, T2, T3, U> Func, Func<T3, T3> In)
			{
			return (o1, o2, o3) => { return Func(o1, o2, In(o3)); };
			}
		/// <summary>
		/// Returns a function that sends the first parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Send<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T1, T1> In)
			{
			return (o1, o2, o3, o4) => { return Func(In(o1), o2, o3, o4); };
			}
		/// <summary>
		/// Returns a function that sends the second parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Send2<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T2, T2> In)
			{
			return (o1, o2, o3, o4) => { return Func(o1, In(o2), o3, o4); };
			}
		/// <summary>
		/// Returns a function that sends the third parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Send3<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T3, T3> In)
			{
			return (o1, o2, o3, o4) => { return Func(o1, o2, In(o3), o4); };
			}
		/// <summary>
		/// Returns a function that sends the fourth parameter in Func through In, taking the result as the new value.
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <typeparam name="T2"></typeparam>
		/// <typeparam name="T3"></typeparam>
		/// <typeparam name="T4"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="Func"></param>
		/// <param name="In"></param>
		/// <returns></returns>
		public static Func<T1, T2, T3, T4, U> Send4<T1, T2, T3, T4, U>(this Func<T1, T2, T3, T4, U> Func, Func<T4, T4> In)
			{
			return (o1, o2, o3, o4) => { return Func(o1, o2, o3, In(o4)); };
			}
		#endregion
		#endregion

		#region Failover
		public static Action Failover<T>(this Action<T> In, IEnumerable<T> Tries)
			{
			return () =>
				{
					List<Exception> Errors = new List<Exception>();

					Boolean Sucess = Tries.While((t) =>
						{
							try
								{
								In(t);
								return false;
								}
							catch (Exception e)
								{
								Errors.Add(e);
								return true;
								}
						});

					if (!Sucess && !Errors.IsEmpty())
						{
						throw new ExceptionList(Errors);
						}
				};
			}
		public static Func<U> Failover<T,U>(this Func<T,U> In, IEnumerable<T> Tries)
			{
			return () =>
			{
				List<Exception> Errors = new List<Exception>();
				U Out = default(U);

				Tries.While((t) =>
				{
					try
						{
						Out = In(t);
						return false;
						}
					catch (Exception e)
						{
						return true;
						}
				});

				if (Out == null && !Errors.IsEmpty())
					{
					throw new ExceptionList(Errors);
					}

				return Out;
			};
			}
		#endregion

        public static Expression<Func<T,Boolean>> Not<T>(this Expression<Func<T,Boolean>> In)
            {
            Func<T, Boolean> In2 = In.Compile();

            Expression<Func<T, Boolean>> Out = o => !In2(o);

            return Out;
            }
		}
	}