using System;
using System.Collections.Generic;
using LCore.Dynamic;
using LCore.Interfaces;
using LCore.LUnit;

// ReSharper disable ClassNeverInstantiated.Global

namespace LCore.Extensions
    {
    /// <summary>
    /// Provides extensions for looping
    /// </summary>
    [ExtensionProvider]
    public static class LoopExt
        {
        #region Extensions +

        #region To

        /// <summary>
        /// Loops from In to To, performing Func. The results of Func are returned in a List`<typeparamref name="U" />.
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="In"></param>
        /// <param name="To"></param>
        /// <param name="Func"></param>
        /// <returns></returns>

        [Tested]
        public static List<U> To<U>(this int In, int To, Func<U> Func)
            {
            var Out = new List<U>();
            In.To(To, i => { Out.Add(Func()); });
            return Out;
            }

        /// <summary>
        /// Loops from In to To, performing Func. The results of Func are returned in a List`<typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="In"></param>
        /// <param name="To"></param>
        /// <param name="Func"></param>
        /// <returns></returns>

        [Tested]
        public static List<T> To<T>(this int In, int To, Func<int, T> Func)
            {
            var Out = new List<T>();
            In.To(To, i =>
                {
                    Out.Add(Func(i));
                }
                );
            return Out;
            }

        #endregion

        #endregion
        }
    public static partial class L
        {
        /// <summary>
        /// Contains static methods and lambdas pertaining to loops and iteration.
        /// </summary>
        public static class Loop
            {
            #region Base Lambdas +

            /// <summary>
            /// This is a simple function that takes an int and returns true, causing loops to continue until completion. Merge this with any function to turn it into a Loop, or use the Loop function.
            /// </summary>
            public static readonly Func<int, bool> AlwaysLoop = i => true;

            #endregion

            #region Static Methods +

            #region While

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            [CodeExplodeExtensionMethod("While", new[] { "In", "Continue" }, Comments.While, false, true)]
            [CodeExplodeGenerics("While", Comments.While)]
            public static readonly Func<Action, Func<bool>, Action>
                While = (In, Continue) =>
                    {
                        return () =>
                            {
                                while (Continue( /*A*/))
                                    {
                                    In();
                                    }
                            };
                    };

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>

            public static Func<Action<T1>, Func<T1, bool>, Action<T1>> While_T<T1>()
                {
                return (In, Continue) =>
                    {
                        return o1 =>
                            {
                                while (Continue(o1))
                                    {
                                    In(o1);
                                    }
                            };
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2>, Func<T1, T2, bool>, Action<T1, T2>> While_T<T1, T2>()
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
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2, T3>, Func<T1, T2, T3, bool>, Action<T1, T2, T3>> While_T<T1, T2, T3>()
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
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <returns></returns>

            public static Func<Action<T1, T2, T3, T4>, Func<T1, T2, T3, T4, bool>, Action<T1, T2, T3, T4>> While_T
                <T1, T2, T3, T4>()
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
                    };
                }

            #endregion

            #region DoWhile

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>

            [CodeExplodeExtensionMethod("DoWhile", new[] { "In", "Continue" }, Comments.DoWhile, false, true)]
            [CodeExplodeGenerics("DoWhile", Comments.DoWhile)]
            public static Func<Action, Func<bool>, Action> L_DoWhile()
                {
                return (In, Continue) =>
                    {
                        return () =>
                            {
                                do
                                    {
                                    In();
                                    } while (Continue( /*A*/));
                            };
                    };
                }

            #endregion

            #region Until

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Until", new[] { "In", "Break" }, Comments.Until, false, true)]
            [CodeExplodeGenerics("Until", Comments.Until)]
            public static Func<Func /*GF*/<U>, Func<bool>, Func /*GF*/<U>> L_Until /*MF*/<U>()
                {
                return (In, Break) =>
                    {
                        return () =>
                            {
                                var Out = default(U);
                                while (!Break( /*A*/) && Out == null)
                                    {
                                    Out = In();
                                    }
                                return Out;
                            };
                    };
                }

            #endregion

            #region DoUntil

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoUntil", new[] { "In", "Break" }, Comments.DoUntil, false, true)]
            [CodeExplodeGenerics("DoUntil", Comments.DoUntil)]
            public static Func<Func /*GF*/<U>, Func<bool>, Func /*GF*/<U>> L_DoUntil /*MF*/<U>()
                {
                return (In, Break) =>
                    {
                        return () =>
                            {
                                U Out;
                                do
                                    {
                                    Out = In();
                                    } while (!Break( /*A*/) && Out == null);
                                return Out;
                            };
                    };
                }

            #endregion

            #region Repeat

            /// <summary>
            /// Returns an action that is repeated a number of times.
            /// </summary>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("Repeat", new[] { "Act", "Times" }, Comments.Repeat, false, true)]
            public static Func<Action, uint, Action> L_Repeat_uint()
                {
                return (Act, Times) =>
                {
                    // ReSharper disable once ConvertIfStatementToReturnStatement
                    if (Times == 0)
                        return Act;

                    return L_To /*IGA*/()(1, (int)Times + 1, Act);
                };
                }
            /// <summary>
            /// Returns an action that is repeated a number of times.
            /// </summary>
            [CodeExplodeExtensionMethod("Repeat", new[] { "Act", "Times" }, Comments.Repeat, false, true)]
            public static Func<Action, int, Action> L_Repeat_int()
                {
                return (Act, Times) =>
                {
                    if (Times < 0)
                        return () => { };
                    // ReSharper disable once ConvertIfStatementToReturnStatement
                    if (Times == 0)
                        return Act;

                    return L_To /*IGA*/()(1, Times + 1, Act);
                };
                }

            #endregion

            #region WhileI

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            [CodeExplodeExtensionMethod("WhileI", new[] { "In", "Continue" }, Comments.While)]
            public static readonly
                Func<Action<int>, Func<int, bool>, Action> WhileI = (In, Continue) =>
                    {
                        return () =>
                            {
                                int Index = 0;
                                while (Continue(Index))
                                    {
                                    In(Index);
                                    Index++;
                                    }
                            };
                    };

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("WhileI", new[] { "In", "Continue" }, Comments.While)]
            public static Func<Action<int, T1>, Func<int, T1, bool>, Action<T1>> WhileI_T<T1>()
                {
                return (In, Continue) =>
                    {
                        int Index = 0;
                        return o1 =>
                            {
                                while (Continue(Index, o1))
                                    {
                                    In(Index, o1);
                                    Index++;
                                    }
                            };
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("WhileI", new[] { "In", "Continue" }, Comments.While)]
            public static Func<Action<int, T1, T2>, Func<int, T1, T2, bool>, Action<T1, T2>> WhileI_T<T1, T2>()
                {
                return (In, Continue) =>
                    {
                        int Index = 0;
                        return (o1, o2) =>
                            {
                                while (Continue(Index, o1, o2))
                                    {
                                    In(Index, o1, o2);
                                    Index++;
                                    }
                            };
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("WhileI", new[] { "In", "Continue" }, Comments.While)]
            public static Func<Action<int, T1, T2, T3>, Func<int, T1, T2, T3, bool>, Action<T1, T2, T3>> WhileI_T
                <T1, T2, T3>()
                {
                return (In, Continue) =>
                    {
                        int Index = 0;
                        return (o1, o2, o3) =>
                            {
                                while (Continue(Index, o1, o2, o3))
                                    {
                                    In(Index, o1, o2, o3);
                                    Index++;
                                    }
                            };
                    };
                }

            #endregion

            #region Until

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("UntilI", new[] { "In", "Break" }, Comments.Until)]
            public static Func<Func<int, U>, Func<int, bool>, Func<U>> Until<U>()
                {
                return (In, Break) =>
                    {
                        int Index = 0;
                        return () =>
                            {
                                var Out = default(U);
                                while (!Break(Index) && Out == null)
                                    {
                                    Out = In(Index);
                                    Index++;
                                    }
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("UntilI", new[] { "In", "Break" }, Comments.Until)]
            public static Func<Func<int, T1, U>, Func<int, T1, bool>, Func<T1, U>> Until<T1, U>()
                {
                return (In, Break) =>
                    {
                        return o1 =>
                            {
                                int Index = 0;
                                var Out = default(U);
                                while (!Break(Index, o1) && Out == null)
                                    {
                                    Out = In(Index, o1);
                                    Index++;
                                    }
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("UntilI", new[] { "In", "Break" }, Comments.Until)]
            public static Func<Func<int, T1, T2, U>, Func<int, T1, T2, bool>, Func<T1, T2, U>> Until<T1, T2, U>()
                {
                return (In, Break) =>
                    {
                        return (o1, o2) =>
                            {
                                int Index = 0;
                                var Out = default(U);
                                while (!Break(Index, o1, o2) && Out == null)
                                    {
                                    Out = In(Index, o1, o2);
                                    Index++;
                                    }
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("UntilI", new[] { "In", "Break" }, Comments.Until)]
            public static Func<Func<int, T1, T2, T3, U>, Func<int, T1, T2, T3, bool>, Func<T1, T2, T3, U>> Until
                <T1, T2, T3, U>()
                {
                return (In, Break) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                int Index = 0;
                                var Out = default(U);
                                while (!Break(Index, o1, o2, o3) && Out == null)
                                    {
                                    Out = In(Index, o1, o2, o3);
                                    Index++;
                                    }
                                return Out;
                            };
                    };
                }

            #endregion

            #region DoWhile

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>

            [CodeExplodeExtensionMethod("DoWhileI", new[] { "In", "Continue" }, Comments.DoWhile)]
            public static Func<Action<int>, Func<int, bool>, Action> DoWhile()
                {
                return (In, Condition) =>
                    {
                        return () =>
                            {
                                int Index = 0;
                                do
                                    {
                                    In(Index);
                                    Index++;
                                    } while (Condition(Index));
                            };
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoWhileI", new[] { "In", "Continue" }, Comments.DoWhile)]
            public static Func<Action<int, T1>, Func<int, T1, bool>, Action<T1>> DoWhile<T1>()
                {
                return (In, Condition) =>
                    {
                        return o1 =>
                            {
                                int Index = 0;
                                do
                                    {
                                    In(Index, o1);
                                    Index++;
                                    } while (Condition(Index, o1));
                            };
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoWhileI", new[] { "In", "Continue" }, Comments.DoWhile)]
            public static Func<Action<int, T1, T2>, Func<int, T1, T2, bool>, Action<T1, T2>> DoWhile<T1, T2>()
                {
                return (In, Condition) =>
                    {
                        return (o1, o2) =>
                            {
                                int Index = 0;
                                do
                                    {
                                    In(Index, o1, o2);
                                    Index++;
                                    } while (Condition(Index, o1, o2));
                            };
                    };
                }

            /// <summary>
            /// Takes action In and returns an action that is performed for as long as Continue evaluates to true.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoWhileI", new[] { "In", "Continue" }, Comments.DoWhile)]
            public static Func<Action<int, T1, T2, T3>, Func<int, T1, T2, T3, bool>, Action<T1, T2, T3>> DoWhile
                <T1, T2, T3>()
                {
                return (In, Condition) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                int Index = 0;
                                do
                                    {
                                    In(Index, o1, o2, o3);
                                    Index++;
                                    } while (Condition(Index, o1, o2, o3));
                            };
                    };
                }

            #endregion

            #region DoUntil

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoUntilI", new[] { "In", "Break" }, Comments.DoUntil)]
            public static Func<Func<int, U>, Func<int, bool>, Func<U>> DoUntil<U>()
                {
                return (In, Break) =>
                    {
                        return () =>
                            {
                                int Index = 0;
                                U Out;
                                do
                                    {
                                    Out = In(Index);
                                    Index++;
                                    } while (!Break(Index) && Out == null);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoUntilI", new[] { "In", "Break" }, Comments.DoUntil)]
            public static Func<Func<int, T1, U>, Func<int, T1, bool>, Func<T1, U>> DoUntil<T1, U>()
                {
                return (In, Break) =>
                    {
                        return o1 =>
                            {
                                int Index = 0;
                                U Out;
                                do
                                    {
                                    Out = In(Index, o1);
                                    Index++;
                                    } while (!Break(Index, o1) && Out == null);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoUntilI", new[] { "In", "Break" }, Comments.DoUntil)]
            public static Func<Func<int, T1, T2, U>, Func<int, T1, T2, bool>, Func<T1, T2, U>> DoUntil<T1, T2, U>()
                {
                return (In, Break) =>
                    {
                        return (o1, o2) =>
                            {
                                int Index = 0;
                                U Out;
                                do
                                    {
                                    Out = In(Index, o1, o2);
                                    Index++;
                                    } while (!Break(Index, o1, o2) && Out == null);
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("DoUntilI", new[] { "In", "Break" }, Comments.DoUntil)]
            public static Func<Func<int, T1, T2, T3, U>, Func<int, T1, T2, T3, bool>, Func<T1, T2, T3, U>> DoUntil
                <T1, T2, T3, U>()
                {
                return (In, Break) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                int Index = 0;
                                U Out;
                                do
                                    {
                                    Out = In(Index, o1, o2, o3);
                                    Index++;
                                    } while (!Break(Index, o1, o2, o3) && Out == null);
                                return Out;
                            };
                    };
                }

            #endregion

            #region Collect

            /// <summary>
            /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
            /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items 
            /// in the resulting List`<typeparamref name="U" />.
            /// </summary>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("Collect", new[] { "Func", "Times" }, Comments.Collect)]
            //  [CodeExplodeGenerics("Collect", L.Comments.Collect)]
            public static Func<Func<U>, uint, Func<List<U>>> L_Collect<U>()
                {
                return (Func, Times) =>
                    {
                        return () =>
                            {
                                var Out = new List<U>( /**/);
                                0.To((int)Times - 1, () => Out.Add(Func()))();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
            /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items 
            /// in the resulting List`<typeparamref name="U" />.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Collect", new[] { "Func", "Times" }, Comments.Collect)]
            public static Func<Func<T1, U>, uint, Func<T1, List<U>>> L_Collect<T1, U>()
                {
                return (Func, Times) =>
                    {
                        return o1 =>
                            {
                                var Out = new List<U>();
                                0.To((int)Times - 1, () => Out.Add(Func(o1)))();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
            /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items 
            /// in the resulting List`<typeparamref name="U" />.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Collect", new[] { "Func", "Times" }, Comments.Collect)]
            public static Func<Func<T1, T2, U>, uint, Func<T1, T2, List<U>>> L_Collect<T1, T2, U>()
                {
                return (Func, Times) =>
                    {
                        return (o1, o2) =>
                            {
                                var Out = new List<U>();
                                0.To((int)Times - 1, () => Out.Add(Func(o1, o2)))();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
            /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items 
            /// in the resulting List`<typeparamref name="U" />.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Collect", new[] { "Func", "Times" }, Comments.Collect)]
            public static Func<Func<T1, T2, T3, U>, uint, Func<T1, T2, T3, List<U>>> L_Collect<T1, T2, T3, U>()
                {
                return (Func, Times) =>
                    {
                        return (o1, o2, o3) =>
                            {
                                var Out = new List<U>();
                                0.To((int)Times - 1, () => Out.Add(Func(o1, o2, o3)))();
                                return Out;
                            };
                    };
                }

            /// <summary>
            /// Returns a Func that collects the result of In into a List`<typeparamref name="U" />. 
            /// The Func will be run <paramref><name>Count</name></paramref> times and there will be that many items 
            /// in the resulting List`<typeparamref name="U" />.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <typeparam name="T4"></typeparam>
            /// <typeparam name="U"></typeparam>
            /// <returns></returns>
            [CodeExplodeExtensionMethod("Collect", new[] { "Func", "Times" }, Comments.Collect)]
            public static Func<Func<T1, T2, T3, T4, U>, uint, Func<T1, T2, T3, T4, List<U>>> L_Collect
                <T1, T2, T3, T4, U>()
                {
                return (Func, Times) =>
                    {
                        return (o1, o2, o3, o4) =>
                            {
                                var Out = new List<U>();
                                0.To((int)Times - 1, () => Out.Add(Func(o1, o2, o3, o4)))();
                                return Out;
                            };
                    };
                }

            #endregion

            #region Loop

            /// <summary>
            /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
            /// </summary>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Loop", new[] { "In" }, Comments.MergeLoop, false, true)]
            //  [CodeExplodeGenerics("To", L.Comments.To)]
            public static Func<Action, Func<int, /*GA,*/ bool>> L_MergeLoop /*M*/()
                {
                return In => In.Merge(AlwaysLoop);
                }

            /// <summary>
            /// /Loop takes an action and returns a loop function, that takes an index and returns true to continue.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Loop", new[] { "In" }, Comments.MergeLoop)]
            public static Func<Action<T1>, Func<int, T1, bool>> L_MergeLoop<T1>()
                {
                return In => In.Merge(AlwaysLoop).Rotate();
                }

            /// <summary>
            /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Loop", new[] { "In" }, Comments.MergeLoop)]
            public static Func<Action<T1, T2>, Func<int, T1, T2, bool>> L_MergeLoop<T1, T2>()
                {
                return In => In.Merge(AlwaysLoop).Rotate();
                }

            /// <summary>
            /// Loop takes an action and returns a loop function, that takes an index and returns true to continue.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("Loop", new[] { "In" }, Comments.MergeLoop)]
            public static Func<Action<T1, T2, T3>, Func<int, T1, T2, T3, bool>> L_MergeLoop<T1, T2, T3>()
                {
                return In => In.Merge(AlwaysLoop).Rotate();
                }

            #endregion

            #region To

            /// <summary>
            /// Loops an Action from a to b. a and b can be any integers.
            /// </summary>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("To", new[] { "In", "To", "Act" }, Comments.To, false, true)]
            [CodeExplodeGenerics("To", Comments.To)]
            public static Func<int, int, Action, Action> L_To /*MA*/()
                {
                return (In, To, Action) =>
                {
                    if (In == To)
                        return Action;

                    return () =>
                    {
                        bool Positive = In < To;
                        int Increment = Positive ? 1 : -1;
                        for (int Index = In; Positive ? Index <= To : Index >= To; Index += Increment)
                            {
                            Action();
                            }
                    };
                };
                }

            /// <summary>
            /// Loops an Action from a to b. a and b can be any integers.
            /// </summary>
            /// <returns></returns>

            [CodeExplodeExtensionMethod("To", new[] { "In", "To", "Act" }, Comments.To, true, true)]
            [CodeExplodeGenerics("To", Comments.To, CodeExplodeLogic.ExplodeCount - 1)]
            public static Func<int, int, Action<int /*,GA*/>, Action> L_ToI /*MA*/()
                {
                return (In, To, Action) =>
                    {
                        if (In == To)
                            return () => { Action(In); };

                        return () =>
                            {
                                bool Positive = In < To;
                                int Increment = Positive ? 1 : -1;
                                for (int Index = In; Positive ? Index <= To : Index >= To; Index += Increment)
                                    {
                                    Action(Index /*,A*/);
                                    }
                            };
                    };
                }

            /// <summary>
            /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
            /// </summary>

            [CodeExplodeExtensionMethod("For", new[] { "In", "To", "Loop" }, Comments.For, true, true)]
            [CodeExplodeGenerics("For", Comments.For, CodeExplodeLogic.ExplodeCount - 1)]
            public static Func<int, int, Func<int, /*GA,*/ bool>, Action> L_For /*MA*/()
                {
                return (In, To, Loop) =>
                {
                    if (In == To)
                        return () => { Loop(In); };

                    return () =>
                            {
                                bool Positive = In < To;
                                int Increment = Positive ? 1 : -1;
                                for (int Index = In; Positive ? Index < To : Index > To; Index += Increment)
                                    {
                                    if (!Loop(Index /*,A*/))
                                        break;
                                    }
                            };
                };
                }

            #endregion

            #endregion

            internal class Comments
                {
                #region Comments +

                public const string While =
                    "Takes action In and returns an action that is performed for as long as Continue evaluates to true.";

                public const string Until =
                    "Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.";

                public const string DoWhile =
                    "Takes action In and returns an action that is performed for as long as Continue evaluates to true.";

                public const string DoUntil =
                    "Takes Func In and returns a Func that is performed until Break evaluates to true, or In returns a non-null value. This value will be the method's return value.";

                public const string Repeat = "Returns an action that is repeated a number of times.";

                public const string Collect =
                    "Returns a Func that collects the result of In into a List[U]. The Func will be run [Count] times and there will be that many items in the resulting List[U].";

                public const string MergeLoop =
                    "Loop takes an action and returns a loop function, that takes an index and returns true to continue.";

                public const string To = "Loops an Action from a to b. a and b can be any integers.";

                public const string For =
                    "Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.";

                #endregion
                }

            /*
            /// <summary>
            /// Loops an Action from a to b. a and b can be any integers.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>
            public static Func<int, int, Action<T1>, Action<T1>> L_To<T1>()
                {
                return (In, To, Action) =>
                {
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
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>
            public static Func<int, int, Action<T1, T2>, Action<T1, T2>> L_To<T1, T2>()
                {
                return (In, To, Action) =>
                {
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
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>
            public static Func<int, int, Action<T1, T2, T3>, Action<T1, T2, T3>> L_To<T1, T2, T3>()
                {
                return (In, To, Action) =>
                {
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
            /// Loops an Action that takes an index from a to b. a and b can be any integers.
            /// </summary>
            /// <returns></returns>
            */
            /*
            /// <summary>
            /// Loops an Action that takes an index from a to b. a and b can be any integers.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <returns></returns>
            public static Func<int, int, Action<int, T1>, Action<T1>> L_ToI<T1>()
                {
                return (In, To, Action) =>
                {
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
            /// Loops an Action that takes an index from a to b. a and b can be any integers.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <returns></returns>
            public static Func<int, int, Action<int, T1, T2>, Action<T1, T2>> L_ToI<T1, T2>()
                {
                return (In, To, Action) =>
                {
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
            /// Loops an Action that takes an index from a to b. a and b can be any integers.
            /// </summary>
            /// <typeparam name="T1"></typeparam>
            /// <typeparam name="T2"></typeparam>
            /// <typeparam name="T3"></typeparam>
            /// <returns></returns>
            public static Func<int, int, Action<int, T1, T2, T3>, Action<T1, T2, T3>> L_ToI<T1, T2, T3>()
                {
                return (In, To, Action) =>
                {
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
            */
            /*
          /// <summary>
          /// Loops an Action that takes an index and returns false to break out of the loop. a and b can be any integers.
          /// </summary>
          /// <typeparam name="T1"></typeparam>
          /// <returns></returns>
          public static Func<int, int, Func<int, T1, Boolean>, Action<T1>> L_TEMPFor<T1>()
              {
              return (a, b, Loop) =>
              {
                  return (o1) =>
                  {
                      Boolean Positive = a < b;
                      for (int i = a; i < b; i++)
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
          /// <typeparam name="T1"></typeparam>
          /// <typeparam name="T2"></typeparam>
          /// <returns></returns>
          public static Func<int, int, Func<int, T1, T2, Boolean>, Action<T1, T2>> L_TEMPFor<T1, T2>()
              {
              return (a, b, Loop) =>
              {
                  return (o1, o2) =>
                  {
                      Boolean Positive = a < b;
                      for (int i = a; i < b; i++)
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
          /// <typeparam name="T1"></typeparam>
          /// <typeparam name="T2"></typeparam>
          /// <typeparam name="T3"></typeparam>
          /// <returns></returns>
          public static Func<int, int, Func<int, T1, T2, T3, Boolean>, Action<T1, T2, T3>> L_TEMPFor<T1, T2, T3>()
              {
              return (a, b, Loop) =>
              {
                  return (o1, o2, o3) =>
                  {
                      Boolean Positive = a < b;
                      for (int i = a; i < b; i++)
                          {
                          if (!Loop(i, o1, o2, o3))
                              break;
                          }
                  };
              };
              }
          */
            }
        }
    }